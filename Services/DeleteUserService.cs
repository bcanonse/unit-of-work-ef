using PocketBook.Core.IConfiguration;

namespace PocketBook.Services;

public class DeleteUserService(IUnitOfWork unitOfWork)
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Execute(Guid id)
    {
        await _unitOfWork.User.Delete(id);
        await _unitOfWork.CompleteAsync();
    }

}