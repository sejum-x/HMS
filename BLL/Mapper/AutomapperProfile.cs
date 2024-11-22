using AutoMapper;
using DAL.Entities;
using BLL.Models;
using Business.Models;

namespace BLL.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            // User -> UserModel
            CreateMap<User, UserModel>()
                .ForMember(um => um.RoleId, opt => opt.MapFrom(src => src.Role.Id))
                .ForMember(um => um.GenderId, opt => opt.MapFrom(src => src.Gender.Id))
                .ReverseMap();

            CreateMap<Doctor, DoctorModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.User.MiddleName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.AvatarImage, opt => opt.MapFrom(src => src.User.AvatarImage))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.User.DateOfBirth))
                .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.User.GenderId)) // Мапінг для GenderId
                .ReverseMap();

            CreateMap<Patient, PatientModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.User.MiddleName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.AvatarImage, opt => opt.MapFrom(src => src.User.AvatarImage))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.User.DateOfBirth))
                .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.User.GenderId)) 
                .ReverseMap();

            // MedicalBook -> MedicalBookModel
            CreateMap<MedicalBook, MedicalBookModel>()
                .ForMember(mbm => mbm.PatientId, opt => opt.MapFrom(src => src.PatientId))
                .ForMember(mbm => mbm.MedicalRecordIds, opt => opt.MapFrom(src => src.MedicalRecords.Select(r => r.Id)))
                .ReverseMap();

            // MedicalRecord -> MedicalRecordModel
            CreateMap<MedicalRecord, MedicalRecordModel>()
                .ForMember(mrm => mrm.MedicalBookId, opt => opt.MapFrom(src => src.MedicalBookId))
                .ForMember(mrm => mrm.DiagnosisId, opt => opt.MapFrom(src => src.DiagnosisId))
                .ForMember(mrm => mrm.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                .ForMember(mrm => mrm.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ReverseMap();

            // City -> CityModel
            CreateMap<City, CityModel>()
                .ForMember(cm => cm.RegionId, opt => opt.MapFrom(src => src.RegionId))
                .ForMember(cm => cm.Addresses, opt => opt.MapFrom(src => src.Addresses.Select(a => a.Id)))
                .ReverseMap();

            // Address -> AddressModel
            /*CreateMap<Address, AddressModel>()
                .ForMember(am => am.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(am => am.Hospitals, opt => opt.MapFrom(src => src.Hospitals.Select(h => h.Id)))
                .ReverseMap();*/

            // Region -> RegionModel
            CreateMap<Region, RegionModel>()
                .ForMember(rm => rm.CountryId, opt => opt.MapFrom(src => src.CountryId))
                .ForMember(rm => rm.Cities, opt => opt.MapFrom(src => src.Cities.Select(c => c.Id)))
                .ReverseMap();

            // Country -> CountryModel
            CreateMap<Country, CountryModel>()
                .ForMember(cm => cm.Regions, opt => opt.MapFrom(src => src.Regions.Select(r => r.Id)))
                .ReverseMap();

            // Department -> DepartmentModel
            CreateMap<Department, DepartmentModel>()
                .ForMember(dm => dm.HospitalId, opt => opt.MapFrom(src => src.HospitalId))
                .ForMember(dm => dm.RoomIds, opt => opt.MapFrom(src => src.Rooms.Select(r => r.Id)))
                .ForMember(dm => dm.WorkHistoryIds, opt => opt.MapFrom(src => src.WorkHistories.Select(wh => wh.Id)))
                .ReverseMap();

            // Diagnosis -> DiagnosisModel
            CreateMap<Diagnosis, DiagnosisModel>()
                .ForMember(dm => dm.MedicalRecords, opt => opt.MapFrom(src => src.MedicalRecords.Select(mr => mr.Id)))
                .ReverseMap();

            // TreatmentPrescription -> TreatmentPrescriptionModel
            CreateMap<TreatmentPrescription, TreatmentPrescriptionModel>()
                .ForMember(tpm => tpm.MedicalRecordId, opt => opt.MapFrom(src => src.MedicalRecord.Id))
                .ForMember(tpm => tpm.TreatmentIds, opt => opt.MapFrom(src => src.Treatments.Select(t => t.Id)))
                .ReverseMap();

            // Medicine -> MedicineModel
            CreateMap<Medicine, MedicineModel>()
                .ForMember(mm => mm.MedicineTypeId, opt => opt.MapFrom(src => src.MedicineType.Id))
                .ForMember(mm => mm.ManufacturerId, opt => opt.MapFrom(src => src.Manufacturer.Id))
                .ForMember(mm => mm.DosageId, opt => opt.MapFrom(src => src.Dosage.Id))
                .ForMember(mm => mm.Treatments, opt => opt.MapFrom(src => src.Treatments.Select(t => t.Id)))
                .ReverseMap();

            // Room -> RoomModel
            CreateMap<Room, RoomModel>()
                .ForMember(rm => rm.MedicalRecordIds, opt => opt.MapFrom(src => src.MedicalRecords.Select(mr => mr.Id)))
                .ForMember(rm => rm.RoomTypeId, opt => opt.MapFrom(src => src.RoomType.Id))
                .ReverseMap();

            // DoctorWorkHistory -> DoctorWorkHistoryModel
            CreateMap<DoctorWorkHistory, DoctorWorkHistoryModel>()
                .ForMember(dwhm => dwhm.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dwhm => dwhm.DoctorSpecializationId, opt => opt.MapFrom(src => src.DoctorSpecializationId))
                .ReverseMap();


            CreateMap<Treatment, TreatmentModel>().ReverseMap();
            CreateMap<MedicineType, MedicineTypeModel>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerModel>().ReverseMap();
            CreateMap<Dosage, DosageModel>().ReverseMap();
            CreateMap<ReferralPrescription, ReferralPrescriptionModel>().ReverseMap();
            CreateMap<TestPrescription, TestPrescriptionModel>().ReverseMap();
            CreateMap<MedicalTest, MedicalTestModel>().ReverseMap();

            CreateMap<Award, AwardModel>().ReverseMap();
            CreateMap<Certificate, CertificateModel>().ReverseMap();
            CreateMap<DoctorSpecialization, DoctorSpecializationModel>().ReverseMap();
            CreateMap<Hospital, HospitalModel>().ReverseMap();
            CreateMap<DepartmentType, DepartmentTypeModel>().ReverseMap();
            CreateMap<RoomType, RoomTypeModel>().ReverseMap();
            CreateMap<Role, RoleModel>().ReverseMap();
            CreateMap<Gender, GenderModel>().ReverseMap();

        }
    }
}
