using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class DoctorSpecializationRepository : RepositoryBase<DoctorSpecialization>, IDoctorSpecializationRepository
{
    public DoctorSpecializationRepository(DbContext context) : base(context) { }

    // Отримати спеціалізацію з пов'язаною історією роботи лікарів
    public async Task<DoctorSpecialization?> GetWithWorkHistoriesAsync(Guid id)
    {
        return await _dbSet
            .Include(ds => ds.DoctorWorkHistories)
            .FirstOrDefaultAsync(ds => ds.Id == id);
    }

    // Отримати список усіх спеціалізацій із кількістю лікарів у кожній
    public async Task<List<(DoctorSpecialization Specialization, int DoctorCount)>> GetSpecializationDoctorCountsAsync()
    {
        return await _dbSet
            .Select(ds => new
            {
                Specialization = ds,
                DoctorCount = ds.DoctorWorkHistories.Count
            })
            .ToListAsync()
            .ContinueWith(t =>
                t.Result.Select(x => (x.Specialization, x.DoctorCount)).ToList()
            );
    }
}