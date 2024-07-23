using PocketBook.Core.IConfiguration;
using PocketBook.Models;

namespace PocketBook.Services;

public class GetUserService(
    IUnitOfWork unitOfWork
)
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<User?> Execute(Guid id) =>
        await _unitOfWork.User.GetById(id);
}