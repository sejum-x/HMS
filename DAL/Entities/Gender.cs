namespace DAL.Entities;

public class Gender : BaseEntity
{
    public string Name { get; set; } // Наприклад, "Male", "Female", "Other"
    public ICollection<User> Users { get; set; } = new List<User>();
}