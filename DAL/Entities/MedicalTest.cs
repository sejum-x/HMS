namespace DAL.Entities;

public class MedicalTest : BaseEntity
{
    public string Name { get; set; } // Назва аналізу, наприклад, "Кров на цукор"
    public string Description { get; set; } // Опис, наприклад, "Визначення рівня глюкози"
    public DateTime DateAssigned { get; set; }
    public DateTime? DateCompleted { get; set; } // Коли виконано
    public string Result { get; set; } // Результат аналізу

    // Зв'язок з призначеним тестом
    public Guid TestPrescriptionId { get; set; }
    public TestPrescription TestPrescription { get; set; }
}