namespace DAL.Entities;

public class Gender : BaseEntity
{
    public string Name { get; set; } 
    public ICollection<User>? Users { get; set; }
}