using Microsoft.EntityFrameworkCore;
using PocketBook.Core.IRepositories;
using PocketBook.Data;
using PocketBook.Models;

namespace PocketBook.Core.Repositories;

public class UserRepository(
    ApplicationDbContext context, 
    ILogger<UserRepository> logger
) : GenericRepository<User>(context, logger), IUserRepository
{
    public override async Task<IEnumerable<User>> GetAll()
    {
        try
        {
            return await dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} all method error", typeof(UserRepository));
            return [];
        }
    }

    public override async Task<bool> Upsert(User entity)
    {
        try
        {
            var existingUser = await dbSet.Where(usr => usr.Id == entity.Id).FirstOrDefaultAsync();

            if (existingUser is null)
                return await Add(entity);


            existingUser.FirstName = entity.FirstName;
            existingUser.LastName = entity.LastName;
            existingUser.Email = entity.Email;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert method error", typeof(UserRepository));
            return false;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var exist = await dbSet.Where(usr => usr.Id == id).FirstOrDefaultAsync();

            if(exist is null)
                return false;

            dbSet.Remove(exist);
            return true;
        }
        catch (Exception ex)
        {
            
            _logger.LogError(ex, $"{typeof(UserRepository)} {nameof(Delete)} method error");
            return false;
        }
    }
}