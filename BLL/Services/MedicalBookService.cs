/*using AutoMapper;
using BLL.Models;
using Business.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;


public interface IMedicalBookService
{
    Task<MedicalBookModel> GetMedicalBookByIdAsync(Guid medicalBookId);
    Task<IEnumerable<MedicalRecordModel>> GetRecordsByMedicalBookIdAsync(Guid medicalBookId);
    Task<IEnumerable<TestPrescriptionModel>> GetTestPrescriptionsByRecordIdAsync(Guid recordId);
    Task<IEnumerable<TreatmentPrescriptionModel>> GetTreatmentPrescriptionsByRecordIdAsync(Guid recordId);
    Task<DoctorModel> GetDoctorByRecordIdAsync(Guid recordId);

    Task<IEnumerable<MedicalBookModel>> GetAllMedicalBooksAsync();
    Task<MedicalBookModel> CreateMedicalBookAsync(MedicalBookModel model);
    Task UpdateMedicalBookAsync(Guid medicalBookId, MedicalBookModel model);
    Task DeleteMedicalBookAsync(Guid medicalBookId);


    Task<MedicalRecordModel> GetMedicalRecordByIdAsync(Guid recordId);
    Task<TestPrescriptionModel> GetTestPrescriptionByIdAsync(Guid prescriptionId);
    Task<TreatmentPrescriptionModel> GetTreatmentPrescriptionByIdAsync(Guid prescriptionId);

    Task<MedicalRecordModel> CreateMedicalRecordAsync(MedicalRecordModel model);
    Task UpdateMedicalRecordAsync(Guid recordId, MedicalRecordModel model);
    Task DeleteMedicalRecordAsync(Guid recordId);

    Task<TestPrescriptionModel> CreateTestPrescriptionAsync(TestPrescriptionModel model);
    Task UpdateTestPrescriptionAsync(Guid prescriptionId, TestPrescriptionModel model);
    Task DeleteTestPrescriptionAsync(Guid prescriptionId);

    Task<TreatmentPrescriptionModel> CreateTreatmentPrescriptionAsync(TreatmentPrescriptionModel model);
    Task UpdateTreatmentPrescriptionAsync(Guid prescriptionId, TreatmentPrescriptionModel model);
    Task DeleteTreatmentPrescriptionAsync(Guid prescriptionId);
}



public class MedicalBookService : IMedicalBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MedicalBookService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // Отримання медичної книги разом із пацієнтом та записами
    public async Task<MedicalBookModel> GetMedicalBookByIdAsync(Guid medicalBookId)
    {
        var medicalBook = await _unitOfWork.MedicalBooks.GetWithPatientAndRecordsAsync(medicalBookId);
        if (medicalBook == null)
            throw new KeyNotFoundException("Medical book not found.");

        return _mapper.Map<MedicalBookModel>(medicalBook);
    }

    // Отримання записів по ID медичної книги
    public async Task<IEnumerable<MedicalRecordModel>> GetRecordsByMedicalBookIdAsync(Guid medicalBookId)
    {
        var medicalRecords = await _unitOfWork.MedicalRecords
            .GetAllAsync(record => record.MedicalBookId == medicalBookId);

        return _mapper.Map<IEnumerable<MedicalRecordModel>>(medicalRecords);
    }

    // Отримання тестових призначень по ID медичного запису
    public async Task<IEnumerable<TestPrescriptionModel>> GetTestPrescriptionsByRecordIdAsync(Guid medicalRecordId)
    {
        var prescriptions = await _unitOfWork.TestPrescriptions
            .GetAllAsync(p => p.MedicalRecordId == medicalRecordId);

        return _mapper.Map<IEnumerable<TestPrescriptionModel>>(prescriptions);
    }

    // Отримання лікувальних призначень по ID медичного запису
    public async Task<IEnumerable<TreatmentPrescriptionModel>> GetTreatmentPrescriptionsByRecordIdAsync(Guid medicalRecordId)
    {
        var prescriptions = await _unitOfWork.TreatmentPrescriptions
            .GetAllAsync(p => p.MedicalRecordId == medicalRecordId);

        return _mapper.Map<IEnumerable<TreatmentPrescriptionModel>>(prescriptions);
    }

    // Отримання лікаря, який зробив призначення
    public async Task<DoctorModel> GetDoctorByRecordIdAsync(Guid medicalRecordId)
    {
        var record = await _unitOfWork.MedicalRecords.GetFullRecordAsync(medicalRecordId);
        if (record?.Doctor == null)
            throw new KeyNotFoundException("Doctor not found for this record.");

        return _mapper.Map<DoctorModel>(record.Doctor);
    }

    // Отримати всі медичні книги
    public async Task<IEnumerable<MedicalBookModel>> GetAllMedicalBooksAsync()
    {
        var medicalBooks = await _unitOfWork.MedicalBooks.GetAllAsync();
        return _mapper.Map<IEnumerable<MedicalBookModel>>(medicalBooks);
    }

    // Створити нову медичну книгу
    public async Task<MedicalBookModel> CreateMedicalBookAsync(MedicalBookModel model)
    {
        var medicalBook = _mapper.Map<MedicalBook>(model);
        await _unitOfWork.MedicalBooks.AddAsync(medicalBook);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<MedicalBookModel>(medicalBook);
    }

    // Оновити існуючу медичну книгу
    public async Task UpdateMedicalBookAsync(Guid medicalBookId, MedicalBookModel model)
    {
        var existingBook = await _unitOfWork.MedicalBooks.GetByIdAsync(medicalBookId);
        if (existingBook == null)
            throw new KeyNotFoundException("Medical book not found.");

        _mapper.Map(model, existingBook);
        await _unitOfWork.SaveChangesAsync();
    }

    // Видалити медичну книгу
    public async Task DeleteMedicalBookAsync(Guid medicalBookId)
    {
        var medicalBook = await _unitOfWork.MedicalBooks.GetByIdAsync(medicalBookId);
        if (medicalBook == null)
            throw new KeyNotFoundException("Medical book not found.");

        _unitOfWork.MedicalBooks.Remove(medicalBook);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task<MedicalRecordModel> GetMedicalRecordByIdAsync(Guid recordId)
    {
        throw new NotImplementedException();
    }

    public Task<TestPrescriptionModel> GetTestPrescriptionByIdAsync(Guid prescriptionId)
    {
        throw new NotImplementedException();
    }

    public Task<TreatmentPrescriptionModel> GetTreatmentPrescriptionByIdAsync(Guid prescriptionId)
    {
        throw new NotImplementedException();
    }

    // Аналогічні методи для MedicalRecord, TestPrescription, TreatmentPrescription

    public async Task<MedicalRecordModel> CreateMedicalRecordAsync(MedicalRecordModel model)
    {
        var medicalRecord = _mapper.Map<MedicalRecord>(model);
        await _unitOfWork.MedicalRecords.AddAsync(medicalRecord);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<MedicalRecordModel>(medicalRecord);
    }

    public async Task UpdateMedicalRecordAsync(Guid recordId, MedicalRecordModel model)
    {
        var existingRecord = await _unitOfWork.MedicalRecords.GetByIdAsync(recordId);
        if (existingRecord == null)
            throw new KeyNotFoundException("Medical record not found.");

        _mapper.Map(model, existingRecord);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteMedicalRecordAsync(Guid recordId)
    {
        var medicalRecord = await _unitOfWork.MedicalRecords.GetByIdAsync(recordId);
        if (medicalRecord == null)
            throw new KeyNotFoundException("Medical record not found.");

        _unitOfWork.MedicalRecords.Remove(medicalRecord);
        await _unitOfWork.SaveChangesAsync();
    }

    // Методи для рецептів
    public async Task<TestPrescriptionModel> CreateTestPrescriptionAsync(TestPrescriptionModel model)
    {
        var testPrescription = _mapper.Map<TestPrescription>(model);
        await _unitOfWork.TestPrescriptions.AddAsync(testPrescription);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TestPrescriptionModel>(testPrescription);
    }

    public async Task UpdateTestPrescriptionAsync(Guid prescriptionId, TestPrescriptionModel model)
    {
        var existingPrescription = await _unitOfWork.TestPrescriptions.GetByIdAsync(prescriptionId);
        if (existingPrescription == null)
            throw new KeyNotFoundException("Test prescription not found.");

        _mapper.Map(model, existingPrescription);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteTestPrescriptionAsync(Guid prescriptionId)
    {
        var testPrescription = await _unitOfWork.TestPrescriptions.GetByIdAsync(prescriptionId);
        if (testPrescription == null)
            throw new KeyNotFoundException("Test prescription not found.");

        _unitOfWork.TestPrescriptions.Remove(testPrescription);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<TreatmentPrescriptionModel> CreateTreatmentPrescriptionAsync(TreatmentPrescriptionModel model)
    {
        var treatmentPrescription = _mapper.Map<TreatmentPrescription>(model);
        await _unitOfWork.TreatmentPrescriptions.AddAsync(treatmentPrescription);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<TreatmentPrescriptionModel>(treatmentPrescription);
    }

    public async Task UpdateTreatmentPrescriptionAsync(Guid prescriptionId, TreatmentPrescriptionModel model)
    {
        var existingPrescription = await _unitOfWork.TreatmentPrescriptions.GetByIdAsync(prescriptionId);
        if (existingPrescription == null)
            throw new KeyNotFoundException("Treatment prescription not found.");

        _mapper.Map(model, existingPrescription);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteTreatmentPrescriptionAsync(Guid prescriptionId)
    {
        var treatmentPrescription = await _unitOfWork.TreatmentPrescriptions.GetByIdAsync(prescriptionId);
        if (treatmentPrescription == null)
            throw new KeyNotFoundException("Treatment prescription not found.");

        _unitOfWork.TreatmentPrescriptions.Remove(treatmentPrescription);
        await _unitOfWork.SaveChangesAsync();
    }
}

*/