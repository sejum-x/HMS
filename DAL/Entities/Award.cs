namespace DAL.Entities;

public class Award : BaseEntity
{ 
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime AwardedDate { get; set; }
    public Guid DoctorId { get; set; }

    public Doctor Doctor { get; set; }
}