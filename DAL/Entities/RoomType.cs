namespace DAL.Entities;

public class RoomType : BaseEntity
{
    public string Name { get; set; } 
    public string Description { get; set; }

    public ICollection<Room> Rooms { get; set; } = new List<Room>();
}