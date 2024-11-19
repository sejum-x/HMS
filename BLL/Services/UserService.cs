using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

public interface IUserService
{
    Task<Guid> RegisterUserAsync(UserModel userModel);
    Task<UserModel> GetUserByIdAsync(Guid userId);
    Task<bool> ValidateUserCredentialsAsync(string email, string password);
}

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> RegisterUserAsync(UserModel userModel)
    {
        if (await _unitOfWork.Users.AnyAsync(u => u.Email == userModel.Email))
            throw new ArgumentException("Email already in use.");

        var user = _mapper.Map<User>(userModel);
        user.CreatedAt = DateTime.UtcNow;
        user.HashPassword = HashPassword(userModel.Password);

        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return user.Id;
    }

    public async Task<UserModel> GetUserByIdAsync(Guid userId)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null) throw new KeyNotFoundException("User not found.");

        return _mapper.Map<UserModel>(user);
    }

    public async Task<bool> ValidateUserCredentialsAsync(string email, string password)
    {
        var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null) return false;

        return VerifyPassword(password, user.HashPassword);
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    private bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}