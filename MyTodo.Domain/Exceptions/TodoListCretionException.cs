namespace MyTodo.Domain.Exceptions
{
    public class TodoListCretionException : Exception
    {
        public TodoListCretionException(string errorMessage) : base(errorMessage) { }
    }
}
