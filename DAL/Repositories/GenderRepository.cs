using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public interface IGenderRepository : IRepository<Gender>
    {
        IQueryable<Gender> GetAllAsNoTracking();
    }

    public class GenderRepository : RepositoryBase<Gender>, IGenderRepository
    {
        public GenderRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Gender> GetAllAsNoTracking()
        {
            return _context.Set<Gender>().AsNoTracking();
        }
    }
}