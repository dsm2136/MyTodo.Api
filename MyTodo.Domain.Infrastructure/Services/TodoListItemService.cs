using MyTodo.Domain.Exceptions;
using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;
using MyTodo.Domain.Services;
using MyTodo.Domain.Storages;

namespace MyTodo.Domain.Infrastructure.Services
{
    public class TodoListItemService : ITodoItemService
    {
        private readonly ITodoItemStorage todoItemStorage;
        private readonly ITodoListStorage listStorage;

        public TodoListItemService(ITodoItemStorage todoItemStorage, ITodoListStorage listStorage)
        {
            this.todoItemStorage = todoItemStorage;
            this.listStorage = listStorage;
        }

        public Task<TodoItemModel?> GetByIdAsync(int id)
        {
            return todoItemStorage.GetByIdAsync(id);
        }

        public Task<IEnumerable<TodoItemModel>> SearchByTodoListIdAsync(int todoListId)
        {
            return todoItemStorage.SearchByTodoListIdAsync(todoListId);
        }

        public async Task CreateAsync(CreateTodoItemInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException(nameof(inputModel));
            }

            if (!await listStorage.ExistsAsync(inputModel.TodoListId))
            {
                throw new TodoItemCreationException("Todo list does not exist");
            }

            if (inputModel.ParentId.HasValue)
            {
                if (!await listStorage.ExistsAsync(inputModel.ParentId.Value))
                {
                    throw new TodoItemCreationException("Parent task does not exist");
                }
            }

            await todoItemStorage.InsertAsync(inputModel);
        }

        public async Task<bool> UpdateAsync(UpdateListItemInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException(nameof(inputModel));
            }

            return await todoItemStorage.UpdateAsync(inputModel);
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            return todoItemStorage.DeleteByIdAsync(id);
        }
    }
}
