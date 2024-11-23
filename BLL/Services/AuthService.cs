using AutoMapper;
using BLL.Intrefaces.Auth;
using Business.Models;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

public interface IAuthService
{
    Task<string> RegisterDoctorAsync(DoctorDTO doctorDto, string password);
    Task<string> RegisterPatientAsync(PatientDTO patientDto, string password);

    Task<string> LoginUserAsync(string email, string password);
}


public class AuthService : IAuthService
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(IJwtProvider jwtProvider, IPasswordHasher passwordHasher, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _jwtProvider = jwtProvider;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    private async Task<User> CreateUserAsync(
        string email,
        string password,
        string role,
        string firstName,
        string lastName,
        string middleName,
        string phoneNumber,
        Guid genderId,
        DateTime dateOfBirth,
        string avatarImage = "default-avatar.png")
    {
        // Перевірка на існування користувача
        if (await _unitOfWork.Users.AnyAsync(u => u.Email == email))
            throw new ValidationException("Користувач із такою електронною поштою вже існує.");

        // Отримання ролі
        var roleEntity = await _unitOfWork.Roles.FirstOrDefaultAsync(r => r.Name == role);
        if (roleEntity == null)
            throw new ValidationException($"Роль '{role}' не знайдена.");

        // Створення нового користувача
        var hashedPassword = _passwordHasher.Generate(password);
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            HashPassword = hashedPassword,
            CreatedAt = DateTime.UtcNow,
            Role = roleEntity,
            FirstName = firstName,
            LastName = lastName,
            MiddleName = middleName,
            PhoneNumber = phoneNumber,
            GenderId = genderId,
            DateOfBirth = dateOfBirth,
            AvatarImage = avatarImage
        };

        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();
        return user;
    }


    public async Task<string> RegisterPatientAsync(PatientDTO patientDto, string password)
    {
        // Перевірка на існування пацієнта
        if (await _unitOfWork.Patients.AnyAsync(d => d.User.Email == patientDto.Email))
            throw new ValidationException("Пацієнт із такою електронною поштою вже існує.");

        var user = await CreateUserAsync(
            patientDto.Email,
            password,
            "Patient",
            patientDto.FirstName,
            patientDto.LastName,
            patientDto.MiddleName,
            patientDto.PhoneNumber,
            patientDto.GenderId,
            patientDto.DateOfBirth);

        // Створення профілю пацієнта
        var patient = _mapper.Map<Patient>(patientDto);
        patient.Id = Guid.NewGuid();
        patient.UserId = user.Id;
        patient.User = user;

        await _unitOfWork.Patients.AddAsync(patient);
        await _unitOfWork.SaveChangesAsync();

        return _jwtProvider.GenerateToken(user.Id, user.Role.Name, user.Email);
    }


    public async Task<string> RegisterDoctorAsync(DoctorDTO doctorDto, string password)
    {
        // Перевірка на існування доктора
        if (await _unitOfWork.Doctors.AnyAsync(d => d.User.Email == doctorDto.Email))
            throw new ValidationException("Доктор із такою електронною поштою вже існує.");

        var user = await CreateUserAsync(
            doctorDto.Email,
            password,
            "Doctor",
            doctorDto.FirstName,
            doctorDto.LastName,
            doctorDto.MiddleName,
            doctorDto.PhoneNumber,
            doctorDto.GenderId,
            doctorDto.DateOfBirth);

        // Створення профілю доктора
        var doctor = _mapper.Map<Doctor>(doctorDto);
        doctor.Id = Guid.NewGuid();
        doctor.UserId = user.Id;
        doctor.User = user;

        await _unitOfWork.Doctors.AddAsync(doctor);
        await _unitOfWork.SaveChangesAsync();

        return _jwtProvider.GenerateToken(user.Id, user.Role.Name, user.Email);
    }

    public async Task<string> LoginUserAsync(string email, string password)
    {
        // Завантаження користувача разом із роллю
        var user = await _unitOfWork.Users.GetUserWithRoleAsync(email);

        if (user == null)
            throw new UnauthorizedAccessException("Invalid email.");

        if (!_passwordHasher.Verify(password, user.HashPassword))
            throw new UnauthorizedAccessException("Invalid password.");

        if (user.Role == null)
            throw new UnauthorizedAccessException("User role is not defined.");

        var token = _jwtProvider.GenerateToken(user.Id, user.Role.Name, user.Email);
        return token;
    }

}