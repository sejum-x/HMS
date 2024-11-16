namespace DAL.Entities
{
    public class MedicalRecord : BaseEntity
    {
        // Зв’язок з медичною книгою
        public Guid MedicalBookId { get; set; }
        public MedicalBook MedicalBook { get; set; }

        // Зв’язок з діагнозом
        public Guid DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }

        // Лікар, який створив запис
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        
        // Примітки до медичного запису
        public string Notes { get; set; }

        // Зв'язок з лікувальними призначеннями (необов'язковий)
        public ICollection<TreatmentPrescription> TreatmentPrescriptions { get; set; } = new List<TreatmentPrescription>();

        // Зв'язок з направленнями (необов'язковий)
        public ICollection<ReferralPrescription> ReferralPrescriptions { get; set; } = new List<ReferralPrescription>();

        // Зв'язок з призначеннями для аналізів (необов'язковий)
        public ICollection<TestPrescription> TestPrescriptions { get; set; } = new List<TestPrescription>();

        // Зв'язок з кімнатою, в якій перебував пацієнт під час прийому лікаря
        public Guid? RoomId { get; set; }
        public Room Room { get; set; }
    }
}