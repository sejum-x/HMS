using AutoMapper;
using BLL.Intrefaces.Auth;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public interface IUserService
{
    Task<Guid> RegisterUserAsync(UserModel userModel, string roleName);
    Task<UserModel> GetUserByIdAsync(Guid userId);
    Task<string> LoginUserAsync(string email, string password);
}

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task<Guid> RegisterUserAsync(UserModel userModel, string roleName)
    {
        if (await _unitOfWork.Users.AnyAsync(u => u.Email == userModel.Email))
            throw new ArgumentException("Email already in use.");

        // Перевірка ролі
        var role = await _unitOfWork.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        if (role == null)
            throw new KeyNotFoundException($"Role '{roleName}' not found.");

        // Перевірка статі
        var gender = await _unitOfWork.Genders.FirstOrDefaultAsync(g => g.Id == userModel.GenderId);
        if (gender == null)
            throw new KeyNotFoundException("Gender not found.");

        // Мапінг і створення користувача
        var user = _mapper.Map<User>(userModel);
        user.CreatedAt = DateTime.UtcNow;
        user.HashPassword = _passwordHasher.Generate(userModel.Password);
        user.RoleId = role.Id;

        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return user.Id;
    }



    public async Task<string> LoginUserAsync(string email, string password)
    {
        var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null) throw new UnauthorizedAccessException("Invalid email.");

        if (!_passwordHasher.Verify(password, user.HashPassword))
            throw new UnauthorizedAccessException("Invalid password.");
        
        var token = _jwtProvider.GenerateToken(user.Id, user.Role.Name, user.Email);
        return token;
    }

    public async Task<UserModel> GetUserByIdAsync(Guid userId)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId);
        if (user == null) throw new KeyNotFoundException("User not found.");

        return _mapper.Map<UserModel>(user);
    }
}