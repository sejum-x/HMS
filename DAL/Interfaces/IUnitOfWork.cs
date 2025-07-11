﻿using DAL.Entities;
using DAL.Repositories;

namespace DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IDoctorRepository Doctors { get; }
    IPatientRepository Patients { get; }
    IMedicalBookRepository MedicalBooks { get; }
    IMedicalRecordRepository MedicalRecords { get; }
    IDiagnosisRepository Diagnoses { get; }
    ITreatmentPrescriptionRepository TreatmentPrescriptions { get; }
    ITreatmentRepository Treatments { get; }
    IMedicineRepository Medicines { get; }
    IDoctorSpecializationRepository DoctorSpecializations { get; }
    IDoctorWorkHistoryRepository DoctorWorkHistories { get; }
    IRoomRepository Rooms { get; }
    IDepartmentRepository Departments { get; }
    IGenderRepository Genders { get; }
    IRoleRepository Roles { get; }

    IAddressRepository Addresses { get; }
    ICityRepository Cities { get; }
    IRegionRepository Regions { get; }
    ICountryRepository Countries { get; }
    ITestPrescriptionRepository TestPrescriptions { get; }

    Task<int> SaveChangesAsync();
}