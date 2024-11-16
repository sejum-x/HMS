namespace DAL.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public Guid DepartmentTypeId { get; set; }
        public DepartmentType DepartmentType { get; set; }

        // Колекція кімнат у відділенні
        public ICollection<Room> Rooms { get; set; } = new List<Room>();

        // Колекція історій роботи лікарів у цьому відділенні
        public ICollection<DoctorWorkHistory> WorkHistories { get; set; } = new List<DoctorWorkHistory>();
    }
}