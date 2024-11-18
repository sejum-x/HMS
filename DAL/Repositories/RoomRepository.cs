using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RoomRepository : RepositoryBase<Room>, IRoomRepository
{
    public RoomRepository(DbContext context) : base(context) { }

    public async Task<Room?> GetWithDepartmentAndRoomTypeAsync(Guid id)
    {
        return await _dbSet
            .Include(r => r.Department)
            .Include(r => r.RoomType)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}