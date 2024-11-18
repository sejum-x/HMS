using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class MedicineRepository : RepositoryBase<Medicine>, IMedicineRepository
{
    public MedicineRepository(DbContext context) : base(context) { }

    public async Task<Medicine?> GetWithDetailsAsync(Guid id)
    {
        return await _dbSet
            .Include(m => m.MedicineType)
            .Include(m => m.Manufacturer)
            .Include(m => m.Dosage)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}