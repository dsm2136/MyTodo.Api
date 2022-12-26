using Microsoft.EntityFrameworkCore;
using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;
using MyTodo.Domain.Storages;
using MyTodo.Storage.Models;

namespace MyTodo.Storage.Repositories
{
    public class TodoItemRepository : ITodoItemStorage
    {
        private readonly TodoListDbContext dbContext;
        public TodoItemRepository(TodoListDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<TodoItemModel?> GetByIdAsync(int id)
        {
            var task = await dbContext.Tasks.FirstOrDefaultAsync(x=> x.Id == id);

            if (task == null) 
            {
                return null;
            }

            return new TodoItemModel 
            { 
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CreatedOn = task.CreatedOn,
                UpdatedOn = task.UpdatedOn,
                TodoListId = task.TodoListId,
                ParentId = task.ParentId,
                IsDone = task.IsDone
            };
        }

        public async Task<IEnumerable<TodoItemModel>> SearchByTodoListIdAsync(int toDoListId)
        {
            var tasks = await dbContext.Tasks.Where(x => x.TodoListId == toDoListId && x.ParentId == null).ToListAsync();

            if (tasks.Count == 0)
            {
                return Enumerable.Empty<TodoItemModel>();
            }

            return tasks.Select(x => new TodoItemModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CreatedOn = x.CreatedOn,
                UpdatedOn = x.UpdatedOn,
                TodoListId = x.TodoListId,
                ParentId = x.ParentId,
                IsDone = x.IsDone
            });
        }

        public async Task<bool> IsContainAsync(int id)
        {
            return await dbContext.Tasks.AnyAsync(x => x.Id == id);
        }

        public async Task InsertAsync(CreateTodoItemInputModel inputModel)
        {
            if (inputModel == null) 
            {
                throw new ArgumentNullException(nameof(inputModel));
            }

            var newTask = new TodoItem
            {
                Title = inputModel.Title,
                Description = inputModel.Description,
                ParentId = inputModel.ParentId,
                TodoListId = inputModel.TodoListId
            };

            dbContext.Tasks.Add(newTask);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(UpdateListItemInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException(nameof(inputModel));
            }

            var taskToChange = await dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == inputModel.Id);

            if (taskToChange == null)
            {
                return false;
            }

            taskToChange.Title = inputModel.Title ?? taskToChange.Title;
            taskToChange.Description = inputModel.Description ?? taskToChange.Description;
            taskToChange.IsDone = inputModel.IsDone ?? taskToChange.IsDone;
            taskToChange.UpdatedOn = DateTimeOffset.UtcNow;

            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var task = dbContext.Tasks.FirstOrDefault(x => x.Id == id);

            if (task == null) 
            {
                return false;
            }

            dbContext.Tasks.Remove(task);

            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
