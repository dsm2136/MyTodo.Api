namespace MyTodo.Domain.Exceptions
{
    public class TodoListCreationException : Exception
    {
        public TodoListCreationException(string errorMessage) : base(errorMessage) { }
    }
}
