namespace MyTodo.Domain.InputModels
{
    public interface CreateListItemInputModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public int TodoListId { get; set; }
    }
}
