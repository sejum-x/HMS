using AutoMapper;
using BLL.Models;
using Business.Models;
using DAL.Entities;
using DAL.Interfaces;

public interface IDoctorService
{
    Task RegisterDoctorAsync(DoctorModel doctorModel, Guid departmentId, Guid specializationId);
    Task<DoctorModel> GetDoctorByIdAsync(Guid doctorId);
}

public class DoctorService : IDoctorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public DoctorService(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task RegisterDoctorAsync(DoctorModel doctorModel, Guid departmentId, Guid specializationId)
    {
        var userId = await _userService.RegisterUserAsync(new UserModel
        {
            FirstName = doctorModel.FirstName,
            LastName = doctorModel.LastName,
            MiddleName = doctorModel.MiddleName,
            Email = doctorModel.Email,
            PhoneNumber = doctorModel.PhoneNumber,
            AvatarImage = doctorModel.AvatarImage,
            DateOfBirth = doctorModel.DateOfBirth,
            GenderId = doctorModel.GenderId,
            RoleId = doctorModel.RoleId,
            Password = doctorModel.Password
        });

        var doctor = _mapper.Map<Doctor>(doctorModel);
        doctor.UserId = userId;

        await _unitOfWork.Doctors.AddAsync(doctor);

        var workHistory = new DoctorWorkHistory
        {
            DoctorId = doctor.Id,
            DepartmentId = departmentId,
            DoctorSpecializationId = specializationId,
            StartDate = DateTime.UtcNow
        };
        await _unitOfWork.DoctorWorkHistories.AddAsync(workHistory);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<DoctorModel> GetDoctorByIdAsync(Guid doctorId)
    {
        var doctor = await _unitOfWork.Doctors.GetByIdAsync(doctorId);
        if (doctor == null) throw new KeyNotFoundException("Doctor not found.");

        return _mapper.Map<DoctorModel>(doctor);
    }
}
