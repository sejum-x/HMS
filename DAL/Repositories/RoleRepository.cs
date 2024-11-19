using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public interface IRoleRepository : IRepository<Role>
{
}

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(DbContext context) : base(context)
    {
    }
}