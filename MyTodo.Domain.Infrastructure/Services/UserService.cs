using MyTodo.Domain.Exceptions;
using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;
using MyTodo.Domain.Services;
using MyTodo.Domain.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                throw new ArgumentException(nameof(inputModel));
            }

            if (await userStorage.IsUsernameUniqueAsync(inputModel.Username))
            {
                throw new UserCreationException("Username already exists");
            }

            await userStorage.InsertAsync(inputModel); 
        }

        public Task<bool> UpdateAsync(UpdateUserInputModel inputModel)
        {


            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
