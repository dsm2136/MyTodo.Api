using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;

namespace MyTodo.Domain.Storages
{
    public interface IUserStorage
    {
        Task<UserModel?> GetByIdAsync(int id);
        Task<bool> IsUsernameUniqueAsync(string username);
        Task InsertAsync(CreateUserInputModel inputModel);
        Task<bool> UpdateAsync(UpdateUserInputModel inputModel);
        Task<bool> DeleteByIdAsync(int id);
    }
}
