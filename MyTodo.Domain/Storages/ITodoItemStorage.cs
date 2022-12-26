using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;

namespace MyTodo.Domain.Storages
{
    public interface ITodoItemStorage
    {
        Task<TodoItemModel?> GetByIdAsync(int id);
        Task<IEnumerable<TodoItemModel>> SearchByTodoListIdAsync(int todoListId);
        Task<bool> IsContainAsync(int id);
        Task InsertAsync(CreateTodoItemInputModel inputModel);
        Task<bool> UpdateAsync(UpdateListItemInputModel inputModel);
        Task<bool> DeleteByIdAsync(int id);
    }
}
