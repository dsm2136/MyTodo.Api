namespace MyTodo.Storage.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }


        public ICollection<TodoListItem>? Tasks { get; set;}
        public User? User { get; set; }
    }
}