namespace DAL.Entities;

public class Dosage : BaseEntity
{
    public string DosageAmount { get; set; }
    public string UsageInstructions { get; set; }

    public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}