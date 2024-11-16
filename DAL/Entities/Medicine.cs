namespace DAL.Entities;

public class Medicine : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    // Зв’язок із типом ліків
    public int MedicineTypeId { get; set; }
    public MedicineType MedicineType { get; set; }

    // Зв’язок із виробником
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }

    // Зв’язок із дозуванням
    public int DosageId { get; set; }
    public Dosage Dosage { get; set; }

    public DateTime ExpirationDate { get; set; }

    public ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}