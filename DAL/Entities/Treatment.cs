namespace DAL.Entities;

public class Treatment : BaseEntity
{
    // Зв'язок з планом лікування, до якого входить це лікування
    public Guid TreatmentPlanId { get; set; }
    public TreatmentPrescription TreatmentPrescription { get; set; }

    // Ліки, які призначені пацієнту
    public Guid MedicineId { get; set; }
    public Medicine Medicine { get; set; }

    // Дата початку і кінця лікування
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Примітки щодо лікування (наприклад, дозування, рекомендації)
    public string Notes { get; set; }
}