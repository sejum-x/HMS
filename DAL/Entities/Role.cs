namespace DAL.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; } // Наприклад, "Admin", "Doctor", "Patient"
    public ICollection<User> Users { get; set; } = new List<User>();
}