using BLL.Models;
using DAL.Entities;

namespace Business.Models
{
    public class Doctor : BaseModel
    {
        public Guid UserId { get; set; }
        public ICollection<Guid> MedicalRecordIds { get; set; } = new List<Guid>();
        public ICollection<Guid> WorkHistoryIds { get; set; } = new List<Guid>();
        public ICollection<Guid> ReferralPrescriptionIds { get; set; } = new List<Guid>();
        public ICollection<Guid> AwardIds { get; set; } = new List<Guid>();
        public ICollection<Guid> CertificateIds { get; set; } = new List<Guid>();
    }
    public class DoctorWorkHistory : BaseModel
    {
        public Guid DoctorId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid DoctorSpecializationId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class Award : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AwardedDate { get; set; }
        public Guid DoctorId { get; set; }
    }

    public class Certificate : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime IssuedDate { get; set; }
        public Guid DoctorId { get; set; }
    }

    public class DoctorSpecialization : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        // Тільки ID
        public ICollection<Guid> DoctorWorkHistoryIds { get; set; } = new List<Guid>();
    }

    public class Department : BaseModel
    {
        public string Name { get; set; }
        public Guid HospitalId { get; set; }
        public Guid DepartmentTypeId { get; set; }

        // Колекції тільки ID
        public ICollection<Guid> RoomIds { get; set; } = new List<Guid>();
        public ICollection<Guid> WorkHistoryIds { get; set; } = new List<Guid>();
    }

    public class Hospital : BaseModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Guid AddressId { get; set; }

        // Колекція тільки ID
        public ICollection<Guid> DepartmentIds { get; set; } = new List<Guid>();
    }

    public class DepartmentType : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Колекції тільки ID
        public ICollection<Guid> DepartmentIds { get; set; } = new List<Guid>();
    }

    public class Room : BaseModel
    {
        public int RoomNumber { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid RoomTypeId { get; set; }

        // Колекції тільки ID
        public ICollection<Guid> MedicalRecordIds { get; set; } = new List<Guid>();
    }

    public class RoomType : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Колекції тільки ID
        public ICollection<Guid> RoomIds { get; set; } = new List<Guid>();
    }

    public class CityModel : BaseModel
        {
            public string Name { get; set; } // Назва міста
            public Guid RegionId { get; set; } // Ідентифікатор регіону

            public ICollection<Guid> Addresses { get; set; } // Список адрес у місті
        }

    public class AddressModel : BaseModel
        {
            public string Street { get; set; } 
            public string BuildingNumber { get; set; } 
            public Guid CityId { get; set; } // Ідентифікатор міста

            public ICollection<Guid> Hospitals { get; set; }
        }
    
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


}