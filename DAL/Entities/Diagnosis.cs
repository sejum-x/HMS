namespace DAL.Entities
{
    public class Diagnosis : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Зв'язок з медичними записами
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    }
}