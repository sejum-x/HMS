namespace DAL.Entities;

public class Doctor : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
   
    public ICollection<MedicalRecord> MedicalRecords { get; set; }

    public ICollection<DoctorWorkHistory> WorkHistory { get; set; }
    public ICollection<ReferralPrescription> ReferralPrescriptions { get; set; }

    public ICollection<Award> Awards { get; set; } = new List<Award>();
    public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
}