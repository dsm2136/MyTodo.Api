namespace MyTodo.Storage.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Username { get; set; } = $"user_{ DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() }";
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public ICollection<TodoList>? TodoLists { get; set; }
    }
}
