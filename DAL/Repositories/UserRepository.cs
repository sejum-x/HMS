using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context) { }

    public async Task<User?> GetByEmailAsync(string email)
        => await _dbSet.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<IEnumerable<User>> GetUsersWithRoleAsync(Guid roleId)
        => await _dbSet.Include(u => u.Role).Where(u => u.RoleId == roleId).ToListAsync();

    public async Task<User> GetUserWithRoleAsync(string email)
        => await _dbSet.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);

}