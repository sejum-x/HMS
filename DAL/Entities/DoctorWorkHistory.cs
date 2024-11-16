namespace DAL.Entities;

public class DoctorWorkHistory : BaseEntity
{
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }

    public Guid DoctorSpecializationId { get; set; }
    public DoctorSpecialization DoctorSpecialization { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}