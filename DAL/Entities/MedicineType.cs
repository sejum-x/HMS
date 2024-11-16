namespace DAL.Entities;

public class MedicineType : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}