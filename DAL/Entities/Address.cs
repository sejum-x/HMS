namespace DAL.Entities;

public class Address : BaseEntity
{
    public int CityId { get; set; }
    public string Street { get; set; }
    public string BuildingNumber { get; set; }

    public City City { get; set; }
}