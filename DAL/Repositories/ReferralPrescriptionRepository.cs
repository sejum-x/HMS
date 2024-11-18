using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ReferralPrescriptionRepository : RepositoryBase<ReferralPrescription>, IReferralPrescriptionRepository
{
    public ReferralPrescriptionRepository(DbContext context) : base(context) { }

    public async Task<ReferralPrescription?> GetWithMedicalRecordAndDoctorAsync(Guid id)
    {
        return await _dbSet
            .Include(rp => rp.MedicalRecord)
            .Include(rp => rp.Doctor)
            .FirstOrDefaultAsync(rp => rp.Id == id);
    }
}