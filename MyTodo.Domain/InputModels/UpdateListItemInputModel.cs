﻿namespace MyTodo.Domain.InputModels
{
    public class UpdateListItemInputModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}