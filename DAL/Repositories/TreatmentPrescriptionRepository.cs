using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TreatmentPrescriptionRepository : RepositoryBase<TreatmentPrescription>, ITreatmentPrescriptionRepository
{
    public TreatmentPrescriptionRepository(DbContext context) : base(context) { }

    public async Task<TreatmentPrescription?> GetWithMedicalRecordAndTreatmentsAsync(Guid id)
    {
        return await _dbSet
            .Include(tp => tp.MedicalRecord)
            .Include(tp => tp.Treatments)
            .ThenInclude(t => t.Medicine)
            .FirstOrDefaultAsync(tp => tp.Id == id);
    }
}