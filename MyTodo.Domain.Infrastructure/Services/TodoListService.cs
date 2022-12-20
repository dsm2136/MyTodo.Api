using MyTodo.Domain.Exceptions;
using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;
using MyTodo.Domain.Services;
using MyTodo.Domain.Storages;

namespace MyTodo.Domain.Infrastructure.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ITodoListStorage todoListStorage;
        private readonly IUserStorage userStorage;

        public TodoListService(ITodoListStorage todoListStorage, IUserStorage userStorage)
        {
            this.todoListStorage = todoListStorage;
            this.userStorage = userStorage;
        }

        public Task<IEnumerable<TodoListModel>> SearchByAuthorIdAsync(int authorId)
        {
            return todoListStorage.SearchByUserIdAsync(authorId);
        }

        public async Task CreateAsync(CreateTodoListInputModel inputModel)
        {
            if (inputModel == null) 
            {
                throw new ArgumentNullException(nameof(inputModel));
            }

            var author = await userStorage.GetByIdAsync(inputModel.UserId);

            if (author == null) 
            {
                throw new TodoListCreationException("Author does not exist");
            }

            await todoListStorage.InsertAsync(inputModel);
        }

        public async Task<bool> UpdateAsync(UpdateTodoListInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException(nameof(inputModel));
            }

            return await todoListStorage.UpdateAsync(inputModel);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return todoListStorage.DeleteByIdAsync(id);
        }        
    }
}
