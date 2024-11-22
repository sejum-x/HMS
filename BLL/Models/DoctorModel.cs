using BLL.Models;
using DAL.Entities;

namespace Business.Models
{
    public class DoctorModel : BaseModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarImage { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid GenderId { get; set; }

        public ICollection<Guid>? MedicalRecordIds { get; set; } = new List<Guid>();
        public ICollection<Guid>? WorkHistoryIds { get; set; } = new List<Guid>();
        public ICollection<Guid>? ReferralPrescriptionIds { get; set; } = new List<Guid>();
        public ICollection<Guid>? AwardIds { get; set; } = new List<Guid>();
        public ICollection<Guid>? CertificateIds { get; set; } = new List<Guid>();
    }

    public class DoctorWorkHistoryModel : BaseModel
    {
        public Guid DoctorId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid DoctorSpecializationId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class AwardModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AwardedDate { get; set; }
        public Guid DoctorId { get; set; }
    }

    public class CertificateModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime IssuedDate { get; set; }
        public Guid DoctorId { get; set; }
    }

    public class DoctorSpecializationModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        // Тільки ID
        public ICollection<Guid> DoctorWorkHistoryIds { get; set; } = new List<Guid>();
    }

    public class DepartmentModel : BaseModel
    {
        public string Name { get; set; }
        public Guid HospitalId { get; set; }
        public Guid DepartmentTypeId { get; set; }

        // Колекції тільки ID
        public ICollection<Guid> RoomIds { get; set; } = new List<Guid>();
        public ICollection<Guid> WorkHistoryIds { get; set; } = new List<Guid>();
    }

    public class HospitalModel : BaseModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Guid AddressId { get; set; }

        // Колекція тільки ID
        public ICollection<Guid> DepartmentIds { get; set; } = new List<Guid>();
    }

    public class DepartmentTypeModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Колекції тільки ID
        public ICollection<Guid> DepartmentIds { get; set; } = new List<Guid>();
    }

    public class RoomModel : BaseModel
    {
        public int RoomNumber { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid RoomTypeId { get; set; }

        // Колекції тільки ID
        public ICollection<Guid> MedicalRecordIds { get; set; } = new List<Guid>();
    }

    public class RoomTypeModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Guid> RoomIds { get; set; } = new List<Guid>();
    }

    public class CityModel : BaseModel
        {
            public string Name { get; set; } 
            public Guid RegionId { get; set; } 

            public ICollection<Guid> Addresses { get; set; } // Список адрес у місті
        }

    /*public class AddressModel : BaseModel
        {
            public string Street { get; set; } 
            public string BuildingNumber { get; set; } 
            public Guid CityId { get; set; } // Ідентифікатор міста

            public ICollection<Guid> Hospitals { get; set; }
        }*/
    
    public class RegionModel : BaseModel
        {
            public string Name { get; set; } // Назва регіону
            public Guid CountryId { get; set; }
            public ICollection<Guid> Cities { get; set; } // Список міст у регіоні
        }

    public class CountryModel : BaseModel
        {
            public string Name { get; set; }

            public ICollection<Guid> Regions { get; set; } 
        }

    public class DoctorWorkplaceDetailModel
    {
        public string DepartmentName { get; set; }
        public string SpecializationName { get; set; }
        public string HospitalName { get; set; }
        public string HospitalPhoneNumber { get; set; }
        public AddressModel Address { get; set; }
    }

    public class AddressModel
    {
        public string City { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
    }
}