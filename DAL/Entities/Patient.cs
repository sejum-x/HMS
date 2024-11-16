namespace DAL.Entities;

public class Patient : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public Guid MedicalBookId { get; set; }
    public MedicalBook MedicalBook { get; set; }
}