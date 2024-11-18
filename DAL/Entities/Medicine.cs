namespace DAL.Entities;

public class Medicine : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    // Зв’язок із типом ліків
    public Guid MedicineTypeId { get; set; }
    public MedicineType MedicineType { get; set; }

    // Зв’язок із виробником
    public Guid ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }

    // Зв’язок із дозуванням
    public Guid DosageId { get; set; }
    public Dosage Dosage { get; set; }

    public DateTime ExpirationDate { get; set; }

    public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}