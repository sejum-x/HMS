using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class DiagnosisRepository : RepositoryBase<Diagnosis>, IDiagnosisRepository
{
    public DiagnosisRepository(DbContext context) : base(context) { }

    public async Task<Diagnosis?> GetWithRecordsAsync(Guid id) =>
        await _dbSet
            .Include(d => d.MedicalRecords)
            .FirstOrDefaultAsync(d => d.Id == id);
}