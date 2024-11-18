using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class MedicalTestRepository : RepositoryBase<MedicalTest>, IMedicalTestRepository
{
    public MedicalTestRepository(DbContext context) : base(context) { }

    public async Task<MedicalTest?> GetWithTestPrescriptionAsync(Guid id)
    {
        return await _dbSet
            .Include(mt => mt.TestPrescription)
            .FirstOrDefaultAsync(mt => mt.Id == id);
    }
}