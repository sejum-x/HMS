namespace DAL.Entities;

public class DoctorSpecialization : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<DoctorWorkHistory> DoctorWorkHistories { get; set; }
}