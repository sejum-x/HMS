namespace DAL.Entities;

public class Room : BaseEntity
{
    public int RoomNumber { get; set; }
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }
    public Guid RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }
    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
}