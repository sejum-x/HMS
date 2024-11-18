using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
{
    public DoctorRepository(DbContext context) : base(context) { }

    public async Task<Doctor?> GetDoctorWithUserAsync(Guid userId)
        => await _dbSet.Include(d => d.User).FirstOrDefaultAsync(d => d.UserId == userId);

    public async Task<IEnumerable<Doctor>> GetDoctorsWithAwardsAndCertificatesAsync()
        => await _dbSet
            .Include(d => d.Awards)
            .Include(d => d.Certificates)
            .ToListAsync();
}