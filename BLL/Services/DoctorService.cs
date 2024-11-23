/*using AutoMapper;
using BLL.Models;
using Business.Models;
using DAL.Entities;
using DAL.Interfaces;

public interface IDoctorService
{
    Task RegisterDoctorAsync(DoctorModel doctorModel);
    Task<DoctorModel> GetDoctorByIdAsync(Guid doctorId);
    Task<IEnumerable<DoctorModel>> GetAllDoctorsAsync();

        // Методи для роботи з історією роботи лікаря
    Task<IEnumerable<DoctorWorkHistoryModel>> GetDoctorWorkHistoryAsync(Guid doctorId);
    Task<DoctorWorkHistoryModel?> GetCurrentWorkplaceAsync(Guid doctorId);
    Task UpdateDoctorWorkplaceAsync(Guid doctorId, Guid departmentId, Guid specializationId);

    Task<DoctorWorkplaceDetailModel?> GetDoctorWorkplaceDetailsAsync(Guid doctorId);

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

    public async Task RegisterDoctorAsync(DoctorModel doctorModel)
    {
        // 1. Реєстрація користувача
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
            Password = doctorModel.Password
        }, "Doctor");

        var doctor = _mapper.Map<Doctor>(doctorModel);
        doctor.UserId = userId;

        await _unitOfWork.Doctors.AddAsync(doctor);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<DoctorModel> GetDoctorByIdAsync(Guid doctorId)
    {
        var doctor = await _unitOfWork.Doctors.GetByIdAsync(doctorId);
        if (doctor == null) throw new KeyNotFoundException("Doctor not found.");

        return _mapper.Map<DoctorModel>(doctor);
    }

    public async Task<IEnumerable<DoctorModel>> GetAllDoctorsAsync()
    {
        var doctors = await _unitOfWork.Doctors.GetAllAsync();
        return _mapper.Map<IEnumerable<DoctorModel>>(doctors);
    }

    // Робота з історією лікаря
    public async Task<IEnumerable<DoctorWorkHistoryModel>> GetDoctorWorkHistoryAsync(Guid doctorId)
    {
        var workHistories = await _unitOfWork.DoctorWorkHistories
            .FindAsync(dwh => dwh.DoctorId == doctorId);

        return _mapper.Map<IEnumerable<DoctorWorkHistoryModel>>(workHistories);
    }

    public async Task<DoctorWorkHistoryModel?> GetCurrentWorkplaceAsync(Guid doctorId)
    {
        var currentWork = await _unitOfWork.DoctorWorkHistories
            .FirstOrDefaultAsync(dwh => dwh.DoctorId == doctorId && dwh.EndDate == null);

        return currentWork != null ? _mapper.Map<DoctorWorkHistoryModel>(currentWork) : null;
    }

    public async Task UpdateDoctorWorkplaceAsync(Guid doctorId, Guid departmentId, Guid specializationId)
    {
        var currentWork = await _unitOfWork.DoctorWorkHistories
            .FirstOrDefaultAsync(dwh => dwh.DoctorId == doctorId && dwh.EndDate == null);

        if (currentWork != null)
        {
            currentWork.EndDate = DateTime.UtcNow;
        }

        var newWorkHistory = new DoctorWorkHistory
        {
            DoctorId = doctorId,
            DepartmentId = departmentId,
            DoctorSpecializationId = specializationId,
            StartDate = DateTime.UtcNow
        };

        await _unitOfWork.DoctorWorkHistories.AddAsync(newWorkHistory);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<DoctorWorkplaceDetailModel?> GetDoctorWorkplaceDetailsAsync(Guid doctorId)
    {
        var currentWork = await _unitOfWork.DoctorWorkHistories
            .FirstOrDefaultAsync(dwh => dwh.DoctorId == doctorId && dwh.EndDate == null);

        if (currentWork == null) return null;

        var department = await _unitOfWork.Departments
            .GetWithHospitalAndRoomsAsync(currentWork.DepartmentId);

        if (department == null) return null;

        var hospital = department.Hospital;
        var address = hospital.Address;
        var city = address.City;

        return new DoctorWorkplaceDetailModel
        {
            DepartmentName = department.Name,
            SpecializationName = currentWork.DoctorSpecialization.Title,
            HospitalName = hospital.Name,
            HospitalPhoneNumber = hospital.PhoneNumber,
            Address = new AddressModel
            {
                City = city.Name,
                Region = city.Region.Name,
                Street = address.Street,
                BuildingNumber = address.BuildingNumber
            }
        };
    }

}
*/