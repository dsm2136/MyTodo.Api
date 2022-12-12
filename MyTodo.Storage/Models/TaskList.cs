namespace MyTodo.Storage.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}