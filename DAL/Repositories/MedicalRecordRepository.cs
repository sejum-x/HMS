using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class MedicalRecordRepository : RepositoryBase<MedicalRecord>, IMedicalRecordRepository
{
    public MedicalRecordRepository(DbContext context) : base(context) { }

    public async Task<MedicalRecord?> GetFullRecordAsync(Guid id) =>
        await _dbSet
            .Include(mr => mr.MedicalBook)
            .Include(mr => mr.Diagnosis)
            .Include(mr => mr.Doctor)
            .Include(mr => mr.TreatmentPrescriptions)
            .Include(mr => mr.ReferralPrescriptions)
            .Include(mr => mr.TestPrescriptions)
            .Include(mr => mr.Room)
            .FirstOrDefaultAsync(mr => mr.Id == id);
}