﻿using System.Linq.Expressions;
using DAL.Entities;

namespace DAL.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task DeleteByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> ExistsAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

    }

    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetUsersWithRoleAsync(Guid roleId);
        Task<User> GetUserWithRoleAsync(string email);
    }

    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<Doctor?> GetDoctorWithUserAsync(Guid userId);
        Task<IEnumerable<Doctor>> GetDoctorsWithAwardsAndCertificatesAsync();
    }

    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient?> GetWithUserAndMedicalBookAsync(Guid id);
    }

    public interface IMedicalBookRepository : IRepository<MedicalBook>
    {
        Task<MedicalBook?> GetWithPatientAndRecordsAsync(Guid id);
    }

    public interface IMedicalRecordRepository : IRepository<MedicalRecord>
    {
        Task<MedicalRecord?> GetFullRecordAsync(Guid id);
    }

    public interface IDiagnosisRepository : IRepository<Diagnosis>
    {
        Task<Diagnosis?> GetWithRecordsAsync(Guid id);
    }

    public interface ITreatmentPrescriptionRepository : IRepository<TreatmentPrescription>
    {
        Task<TreatmentPrescription?> GetWithMedicalRecordAndTreatmentsAsync(Guid id);
    }

    public interface ITreatmentRepository : IRepository<Treatment>
    {
        Task<Treatment?> GetWithPrescriptionAndMedicineAsync(Guid id);
    }

    public interface IMedicineRepository : IRepository<Medicine>
    {
        Task<Medicine?> GetWithDetailsAsync(Guid id);
    }

    public interface IReferralPrescriptionRepository : IRepository<ReferralPrescription>
    {
        Task<ReferralPrescription?> GetWithMedicalRecordAndDoctorAsync(Guid id);
    }

    public interface ITestPrescriptionRepository : IRepository<TestPrescription>
    {
        Task<TestPrescription?> GetWithMedicalRecordAndTestsAsync(Guid id);
    }

    public interface IMedicalTestRepository : IRepository<MedicalTest>
    {
        Task<MedicalTest?> GetWithTestPrescriptionAsync(Guid id);
    }

    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department?> GetWithHospitalAndRoomsAsync(Guid id);
    }

    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room?> GetWithDepartmentAndRoomTypeAsync(Guid id);
    }

    public interface IDoctorSpecializationRepository : IRepository<DoctorSpecialization>
    {
        Task<DoctorSpecialization?> GetWithWorkHistoriesAsync(Guid id);
        Task<List<(DoctorSpecialization Specialization, int DoctorCount)>> GetSpecializationDoctorCountsAsync();
    }

    public interface IDoctorWorkHistoryRepository : IRepository<DoctorWorkHistory>
    {
        Task<DoctorWorkHistory?> GetWithDepartmentAndSpecializationAsync(Guid id);
        Task<List<DoctorWorkHistory>> GetByDoctorIdAsync(Guid doctorId);
        Task<List<DoctorWorkHistory>> GetByDepartmentIdAsync(Guid departmentId);
    }

}