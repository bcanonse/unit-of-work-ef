using Microsoft.EntityFrameworkCore;
using PocketBook.Core.IRepositories;
using PocketBook.Data;

namespace PocketBook.Core.Repositories;

public class GenericRepository<T>(
    ApplicationDbContext context,
    ILogger logger
) : IGenericRepository<T> where T : class
{
    protected ApplicationDbContext _context = context;
    protected DbSet<T> dbSet = context.Set<T>();
    protected ILogger _logger = logger;
    public async Task<bool> Add(T entity)
    {
        await dbSet.AddAsync(entity);
        return true;
    }

    public virtual Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<IEnumerable<T>> GetAll() =>
        await dbSet.ToListAsync();

    public virtual async Task<T?> GetById(Guid id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual Task<bool> Upsert(T entity)
    {
        throw new NotImplementedException();
    }
}