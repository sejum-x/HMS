using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TreatmentRepository : RepositoryBase<Treatment>, ITreatmentRepository
{
    public TreatmentRepository(DbContext context) : base(context) { }

    public async Task<Treatment?> GetWithPrescriptionAndMedicineAsync(Guid id)
    {
        return await _dbSet
            .Include(t => t.TreatmentPrescription)
            .Include(t => t.Medicine)
            .ThenInclude(m => m.MedicineType)
            .Include(t => t.Medicine)
            .ThenInclude(m => m.Manufacturer)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}