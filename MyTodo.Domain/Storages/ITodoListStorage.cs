using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;

namespace MyTodo.Domain.Storages
{
    public interface ITodoListStorage
    {
        Task<TodoListModel?> GetByIdAsync(int id);
        Task<IEnumerable<TodoListModel>> SearchByUserIdAsync(int userId);
        Task InsertAsync(CreateTodoListInputModel inputModel);
        Task<bool> UpdateAsync(UpdateTodoListInputModel inputModel);
        Task<bool> DeleteByIdAsync(int id);
    }
}
