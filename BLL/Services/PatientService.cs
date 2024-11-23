/*using AutoMapper;
using BLL.Intrefaces.Auth;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

public interface IPatientService
{
    Task RegisterPatientAsync(PatientModel patientModel);
    Task<PatientModel> GetPatientByIdAsync(Guid patientId);
    Task<IEnumerable<PatientModel>> GetAllPatientsAsync();
}

public class PatientService : IPatientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public PatientService(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task RegisterPatientAsync(PatientModel patientModel)
    {
        var userId = await _userService.RegisterUserAsync(new UserModel
        {
            FirstName = patientModel.FirstName,
            LastName = patientModel.LastName,
            MiddleName = patientModel.MiddleName,
            Email = patientModel.Email,
            PhoneNumber = patientModel.PhoneNumber,
            AvatarImage = patientModel.AvatarImage,
            DateOfBirth = patientModel.DateOfBirth,
            GenderId = patientModel.GenderId,
            Password = patientModel.Password
        }, "Patient");

        var patient = _mapper.Map<Patient>(patientModel);
        patient.UserId = userId;

        await _unitOfWork.Patients.AddAsync(patient);

        var medicalBook = new MedicalBook
        {
            Number = Guid.NewGuid().ToString(),
            IssueDate = DateTime.UtcNow,
            PatientId = patient.Id
        };
        await _unitOfWork.MedicalBooks.AddAsync(medicalBook);

        await _unitOfWork.SaveChangesAsync();
    }



    public async Task<PatientModel> GetPatientByIdAsync(Guid patientId)
    {
        var patient = await _unitOfWork.Patients.GetByIdAsync(patientId);
        if (patient == null) throw new KeyNotFoundException("Patient not found.");

        return _mapper.Map<PatientModel>(patient);
    }

    public async Task<IEnumerable<PatientModel>> GetAllPatientsAsync()
    {
        var patients = await _unitOfWork.Patients.GetAllAsync();
        return _mapper.Map<IEnumerable<PatientModel>>(patients);
    }
}*/