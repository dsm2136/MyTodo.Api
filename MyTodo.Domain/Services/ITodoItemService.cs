using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;

namespace MyTodo.Domain.Services
{
    public interface ITodoItemService
    {
        Task<TodoItemModel?> GetByIdAsync(int id);
        Task<IEnumerable<TodoItemModel>> SearchByTodoListIdAsync(int todoListId);
        Task CreateAsync(CreateTodoItemInputModel inputModel);
        Task<bool> UpdateAsync(UpdateListItemInputModel inputModel);
        Task<bool> DeleteByIdAsync(int id);
    }
}
