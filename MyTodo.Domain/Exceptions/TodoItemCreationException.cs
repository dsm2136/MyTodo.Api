namespace MyTodo.Domain.Exceptions
{
    public class TodoItemCreationException : Exception
    {
        public TodoItemCreationException(string errorMessage) : base(errorMessage) { }
    }
}
