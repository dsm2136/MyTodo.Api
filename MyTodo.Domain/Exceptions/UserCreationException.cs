namespace MyTodo.Domain.Exceptions
{
    public class UserCreationException : Exception
    {
        public UserCreationException(string errorMessage) : base(errorMessage) { }
    }
}
