using Microsoft.EntityFrameworkCore;
using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;
using MyTodo.Domain.Storages;
using MyTodo.Storage.Models;

namespace MyTodo.Storage.Repositories
{
    public class TodoListRepository : ITodoListStorage
    {
        private readonly TodoListDbContext dbContext;

        public TodoListRepository(TodoListDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TodoListModel?> GetByIdAsync(int id)
        {
            var todoList = await dbContext.TaskLists.FirstOrDefaultAsync(x => x.Id == id);

            if (todoList == null) 
            { 
                return null; 
            }

            return new TodoListModel
            {
                Id = id,
                Title = todoList.Title,
                UserId = todoList.UserId,
                CreatedOn = todoList.CreatedOn,
                UpdatedOn = todoList.UpdatedOn
            };
        }

        public async Task<IEnumerable<TodoListModel>> SearchByUserIdAsync(int userId)
        {
            var userTodoLists = await dbContext.TaskLists.Where(x => x.UserId == userId).ToListAsync();

            if (!userTodoLists.Any())
            {
                return Enumerable.Empty<TodoListModel>();
            }

            return userTodoLists.Select(x => new TodoListModel 
            { 
                Id = x.Id,
                Title = x.Title,
                UserId = x.UserId,
                CreatedOn = x.CreatedOn,
                UpdatedOn = x.UpdatedOn,
            });
        }

        public async Task InsertAsync(CreateTodoListInputModel inputModel)
        {
            if (inputModel == null) 
            {
                throw new ArgumentNullException(nameof(inputModel));
            }

            var todoList = new TodoList
            {
                Title = inputModel.Title,
                CreatedOn = DateTimeOffset.UtcNow,
                UserId = inputModel.UserId
            };

            dbContext.TaskLists.Add(todoList);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(UpdateTodoListInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException(nameof(inputModel));
            }

            var todoList = await dbContext.TaskLists.FirstOrDefaultAsync(x => x.Id == inputModel.Id);
            
            if (todoList == null)
            {
                return false;
            }

            todoList.Title = inputModel.Title ?? todoList.Title;
            todoList.UpdatedOn = DateTimeOffset.UtcNow;

            return await dbContext.SaveChangesAsync() > 0;
        }

        //TODO
        public async Task<bool> IsContrain(int id)
        {
            return await dbContext.TaskLists.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var todoList = await dbContext.TaskLists.FirstOrDefaultAsync(x => x.Id == id);

            if (todoList == null)
            {
                return false;
            }

            dbContext.TaskLists.Remove(todoList);

            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
