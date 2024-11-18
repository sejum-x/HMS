namespace DAL.Entities;

public class MedicalBook : BaseEntity
{
    public string Number { get; set; } // Номер медичної книги
    public DateTime IssueDate { get; set; } // Дата видачі
    public Guid PatientId { get; set; } // Зв’язок із пацієнтом
    public Patient Patient { get; set; }

    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
}