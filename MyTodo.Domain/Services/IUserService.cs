using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;

namespace MyTodo.Domain.Services
{
    public interface IUserService
    {
        Task<UserModel?> GetByIdAsync(int id);
        Task InsertAsync(CreateUserInputModel inputModel);
        Task<bool> UpdateAsync(UpdateUserInputModel inputModel);
        Task<bool> DeleteByIdAsync(int id);
    }
}
