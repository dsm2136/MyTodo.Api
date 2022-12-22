using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;

namespace MyTodo.Domain.Services
{
    public interface ITodoItemService
    {
        Task<TodoListItemModel?> GetByIdAsync(int id);
        Task<IEnumerable<TodoListItemModel>> SearchByTodoListIdAsync(int todoListId);
        Task CreateAsync(CreateListItemInputModel inputModel);
        Task<bool> UpdateAsync(UpdateListItemInputModel inputModel);
        Task<bool> DeleteByIdAsync(int id);
    }
}
