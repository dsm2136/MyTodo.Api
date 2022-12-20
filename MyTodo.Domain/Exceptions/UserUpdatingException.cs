namespace MyTodo.Domain.Exceptions
{
    public class UserUpdatingException : Exception
    {
        public UserUpdatingException(string errorMessage) : base(errorMessage) { }
    }
}
