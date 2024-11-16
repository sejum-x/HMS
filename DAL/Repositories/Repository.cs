using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly HMSDbContext context;
    private readonly DbSet<TEntity> dbSet;

    public Repository(HMSDbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
        this.dbSet = context.Set<TEntity>();
    }

    protected HMSDbContext Context => this.context;

    protected DbSet<TEntity> DbSet => this.dbSet;

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await this.dbSet.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await this.dbSet.FindAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await this.dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        this.dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        this.dbSet.Remove(entity);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var entity = await this.GetByIdAsync(id);
        if (entity != null)
        {
            this.Delete(entity);
        }
    }
}