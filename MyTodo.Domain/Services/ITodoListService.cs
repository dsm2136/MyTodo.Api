using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;

namespace MyTodo.Domain.Services
{
    public interface ITodoListService
    {
        Task<IEnumerable<TodoListModel>> SearchByAuthorIdAsync(int authorId);
        Task CreateAsync(CreateTodoListInputModel inputModel);
        Task<bool> UpdateAsync(UpdateTodoListInputModel inputModel);
        Task<bool> DeleteAsync(int id);
    }
}
