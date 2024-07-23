using PocketBook.Core.IConfiguration;
using PocketBook.Models;

namespace PocketBook.Services;

public class InsertUserServices(
    IUnitOfWork unitOfWork
)
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Execute(User user)
    {
        await _unitOfWork.User.Add(user);
        await _unitOfWork.CompleteAsync();
    }
}