namespace MyTodo.Storage.Models
{
    internal class TodoListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public int TodoListId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public bool IsDone { get; set; }

        public TodoList? TodoList { get; set; }
        public ICollection<TodoListItem>? Steps { get; set;}
    }
}
