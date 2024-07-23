using PocketBook.Core.IRepositories;

namespace PocketBook.Core.IConfiguration;

public interface IUnitOfWork : IDisposable
{
    IUserRepository User { get; }

    Task CompleteAsync();
}