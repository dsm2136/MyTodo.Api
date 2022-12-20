﻿namespace MyTodo.Storage.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }

        public ICollection<TodoList>? TodoLists { get; set; }
    }
}
