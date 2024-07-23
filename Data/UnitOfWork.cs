using PocketBook.Core.IConfiguration;
using PocketBook.Core.IRepositories;

namespace PocketBook.Data;

public class UnitOfWork(
    ApplicationDbContext context,
    IUserRepository user
) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;


    public IUserRepository User { get; } = user;

    public async Task CompleteAsync() =>
        await _context.SaveChangesAsync();

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }

    ~UnitOfWork()
    {
        Dispose(false);
    }
}