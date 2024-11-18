using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class MedicalBookRepository : RepositoryBase<MedicalBook>, IMedicalBookRepository
{
    public MedicalBookRepository(DbContext context) : base(context) { }

    public async Task<MedicalBook?> GetWithPatientAndRecordsAsync(Guid id) =>
        await _dbSet
            .Include(mb => mb.Patient)
            .Include(mb => mb.MedicalRecords)
            .FirstOrDefaultAsync(mb => mb.Id == id);
}