namespace DAL.Entities;

public class DepartmentType : BaseEntity
{
    public string Name { get; set; } // Наприклад, "Хірургічне", "Терапевтичне"
    public string Description { get; set; } // Додатковий опис
    public ICollection<Department> Departments { get; set; } = new List<Department>();
}