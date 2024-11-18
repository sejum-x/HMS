using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
{
    public PatientRepository(DbContext context) : base(context) { }

    public async Task<Patient?> GetWithUserAndMedicalBookAsync(Guid id)
        => await _dbSet
            .Include(p => p.User)
            .Include(p => p.MedicalBook)
            .FirstOrDefaultAsync(p => p.Id == id);
}