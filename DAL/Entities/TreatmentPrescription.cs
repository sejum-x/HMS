namespace DAL.Entities;

public class TreatmentPrescription : BaseEntity
{

    // Дата створення запису
    public DateTime RecordDate { get; set; }

    // Примітки до плану лікування
    public string Notes { get; set; }
    
    // Зв'язок із медичним записом, до якого прив'язане призначення
    public Guid MedicalRecordId { get; set; }
    public MedicalRecord MedicalRecord { get; set; }

    // Зв'язок з лікуваннями, які входять до цього плану
    public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}