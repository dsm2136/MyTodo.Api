namespace MyTodo.Domain.Models
{
    public class TodoListModel
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public int UserId { get; init; }
        public DateTimeOffset CreatedOn { get; init; }
        public DateTimeOffset? UpdatedOn { get; init; }


        public IEnumerable<TodoListItemModel>? Tasks { get; init; }
        public UserModel? User { get; init; }
    }
}