using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public interface IGenderRepository : IRepository<Gender>
{
}

public class GenderRepository : RepositoryBase<Gender>, IGenderRepository
{
    public GenderRepository(DbContext context) : base(context)
    {
    }
}
