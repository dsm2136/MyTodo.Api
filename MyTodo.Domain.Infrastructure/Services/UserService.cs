using MyTodo.Domain.Exceptions;
using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;
using MyTodo.Domain.Services;
using MyTodo.Domain.Storages;

namespace MyTodo.Domain.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserStorage userStorage;

        public UserService(IUserStorage userStorage)
        {
            this.userStorage = userStorage;
        }

        public Task<UserModel?> GetByIdAsync(int id)
        {
            return userStorage.GetByIdAsync(id);
        }

        public async Task InsertAsync(CreateUserInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException(nameof(inputModel));
            }

            if (await userStorage.IsUsernameUniqueAsync(inputModel.Username))
            {
                throw new UserCreationException("Username already exists");
            }

            await userStorage.InsertAsync(inputModel); 
        }

        public async Task<bool> UpdateAsync(UpdateUserInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException(nameof(inputModel));
            }

            if (!string.IsNullOrEmpty(inputModel.Username) && 
                await userStorage.IsUsernameUniqueAsync(inputModel.Username))
            {
                throw new UserUpdatingException("Username already exists");
            }

            return await userStorage.UpdateAsync(inputModel);
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            return userStorage.DeleteByIdAsync(id);
        }
    }
}
