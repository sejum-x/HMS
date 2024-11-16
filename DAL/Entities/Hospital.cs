using System.Diagnostics.Metrics;

namespace DAL.Entities;

public class Hospital : BaseEntity
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    // Зв’язок з Address
    public int AddressId { get; set; }
    public Address Address { get; set; }

    // Колекція підрозділів лікарні
    public ICollection<Department> Departments { get; set; } = new List<Department>();
}