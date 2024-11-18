namespace DAL.Entities;

public class Address : BaseEntity
{
    public Guid CityId { get; set; }
    public string Street { get; set; }
    public string BuildingNumber { get; set; }

    public City City { get; set; }

    public ICollection<Hospital> Hospitals { get; set; }
}