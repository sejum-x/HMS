namespace DAL.Entities;

public class RoomType : BaseEntity
{
    public string Name { get; set; } // Наприклад, "Операційна", "Палата інтенсивної терапії", "Загальна палата"
    public string Description { get; set; }

    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}