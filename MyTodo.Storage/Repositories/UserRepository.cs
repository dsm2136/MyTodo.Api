using Microsoft.EntityFrameworkCore;
using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;
using MyTodo.Domain.Storages;
using MyTodo.Storage.Models;

namespace MyTodo.Storage.Repositories
{
    public class UserRepository : IUserStorage
    {
        private readonly TodoListDbContext dbContext;

        public UserRepository(TodoListDbContext dbContext) 
        {
             this.dbContext = dbContext;
        }

        public async Task<UserModel?> GetByIdAsync(int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            
            if (user == null) 
            {
                return null;
            }

            return new UserModel
            {
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                CreatedOn = user.CreatedOn
            };
        }

        public async Task InsertAsync(CreateUserInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException(nameof(inputModel));
            }

            var newUser = new User
            {
                FirstName = inputModel.FirstName,
                LastName = inputModel.LastName,
                Username = inputModel.Username,
                Email = inputModel.Email,
                CreatedOn = DateTimeOffset.UtcNow                
            };

            dbContext.Users.Add(newUser);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(UpdateUserInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException(nameof(inputModel));
            }

            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == inputModel.Id);

            if (user == null)
            {
                return false;
            }

            user.FirstName = inputModel.FirstName ?? user.FirstName;
            user.LastName = inputModel.LastName ?? user.LastName;
            user.Username = inputModel.Username ?? user.Username;
            user.UpdatedOn = DateTimeOffset.UtcNow;

            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null) 
            { 
                return false; 
            }

            dbContext.Users.Remove(user);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> IsUsernameUniqueAsync(string username)
        {
            return await dbContext.Users.AnyAsync(x => x.Username == username);
        }
    }
}
