namespace DAL.Entities;

public class Certificate : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime IssuedDate { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
}