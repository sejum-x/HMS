using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
{
    public DepartmentRepository(DbContext context) : base(context) { }

    public async Task<Department?> GetWithHospitalAndRoomsAsync(Guid id)
    {
        return await _dbSet
            .Include(d => d.Hospital)
            .Include(d => d.Rooms)
            .FirstOrDefaultAsync(d => d.Id == id);
    }
}