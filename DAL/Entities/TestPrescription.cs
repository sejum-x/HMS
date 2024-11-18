namespace DAL.Entities;

public class TestPrescription : BaseEntity
{
   // Дата створення запису
    public DateTime RecordDate { get; set; }

    // Зв'язок із медичним записом
    public Guid MedicalRecordId { get; set; }
    public MedicalRecord MedicalRecord { get; set; }

    // Примітки щодо аналізу
    public string Notes { get; set; }

    // Зв'язок з лікуваннями, які входять до цього плану
    public ICollection<MedicalTest> MedicalTests { get; set; } = new List<MedicalTest>();
}