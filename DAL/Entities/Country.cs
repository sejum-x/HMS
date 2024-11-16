namespace DAL.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Region> Regions { get; set; }
}