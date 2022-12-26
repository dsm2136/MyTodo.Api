namespace MyTodo.Domain.Models
{
    public class TodoItemModel
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string? Description { get; init; }
        public int? ParentId { get; init; }
        public int TodoListId { get; init; }
        public DateTimeOffset CreatedOn { get; init; }
        public DateTimeOffset? UpdatedOn { get; init; }
        public bool IsDone { get; init; }

        public string TodoListName { get; init; }
        public IEnumerable<TodoItemModel>? Steps { get; init; }
    }
}