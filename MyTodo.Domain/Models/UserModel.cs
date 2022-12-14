namespace MyTodo.Domain.Models
{
    public class UserModel
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string? LastName { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
        public DateTimeOffset CreatedOn { get; init; }
    }
}
