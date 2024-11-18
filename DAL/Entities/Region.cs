namespace DAL.Entities;

public class Region : BaseEntity
{
    public string Name { get; set; }
    public Guid CountryId { get; set; }

    public Country Country { get; set; }
    public ICollection<City> Cities { get; set; }
}