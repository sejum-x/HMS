namespace DAL.Entities;

public class ReferralPrescription : BaseEntity
{
    // Дата створення запису
    public DateTime RecordDate { get; set; }

    // Термін запису
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Лікар, до якого пацієнта направляють
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    // Зв'язок із медичним записом
    public Guid MedicalRecordId { get; set; }
    public MedicalRecord MedicalRecord { get; set; }

    // Примітки щодо направлення
    public string Notes { get; set; }
}