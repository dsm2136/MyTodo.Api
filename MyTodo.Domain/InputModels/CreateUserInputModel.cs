namespace MyTodo.Domain.InputModels
{
    public class CreateUserInputModel
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
