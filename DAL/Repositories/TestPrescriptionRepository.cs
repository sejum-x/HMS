using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TestPrescriptionRepository : RepositoryBase<TestPrescription>, ITestPrescriptionRepository
{
    public TestPrescriptionRepository(DbContext context) : base(context) { }

    public async Task<TestPrescription?> GetWithMedicalRecordAndTestsAsync(Guid id)
    {
        return await _dbSet
            .Include(tp => tp.MedicalRecord)
            .Include(tp => tp.MedicalTests)
            .FirstOrDefaultAsync(tp => tp.Id == id);
    }
}