namespace DAL.Entities;

public class Manufacturer : BaseEntity
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string Email { get; set; }

    public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}