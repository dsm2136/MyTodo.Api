using MyTodo.Domain.Exceptions;
using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;
using MyTodo.Domain.Services;
using MyTodo.Domain.Storages;

namespace MyTodo.Domain.Infrastructure.Services
{
    public class TodoListItemService : ITodoListItemService
    {
        private readonly ITodoListItemStorage todoItemStorage;
        private readonly ITodoListStorage todoListStorage;

        public TodoListItemService(
            ITodoListItemStorage todoItemStorage,
            ITodoListStorage todoListStorage)
        {
            this.todoItemStorage = todoItemStorage;
            this.todoListStorage = todoListStorage;
        }

        public Task<TodoListItemModel?> GetByIdAsync(int id)
        {
            return todoItemStorage.GetByIdAsync(id);
        }

        public Task<IEnumerable<TodoListItemModel>> SearchByTodoListIdAsync(int todoListId)
        {
            return todoItemStorage.SearchByTodoListIdAsync(todoListId);
        }

        public async Task CreateAsync(CreateListItemInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException(nameof(inputModel));
            }

            if (await todoListStorage.IsContainAsync(inputModel.TodoListId))
            {
                throw new TodoItemCreationException("Todo list does not exist");
            }

            if (inputModel.ParentId.HasValue)
            {
                if (!await todoItemStorage.IsContainAsync(inputModel.ParentId.Value))
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
