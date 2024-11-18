namespace DAL.Entities;

public class City : BaseEntity
{
    public string Name { get; set; }
    public Guid RegionId { get; set; }

    public Region Region { get; set; }
    public ICollection<Address> Addresses { get; set; }
}