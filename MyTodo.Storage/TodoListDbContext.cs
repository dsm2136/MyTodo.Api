using Microsoft.EntityFrameworkCore;
using MyTodo.Storage.Configurations;
using MyTodo.Storage.Models;

namespace MyTodo.Storage
{
    public class TodoListDbContext : DbContext
    {
        internal DbSet<TodoList> TaskLists { get; set; }
        internal DbSet<TodoListItem> Tasks { get; set; }
        internal DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost, 1433;Database=MyTodo;User Id=sa;Password=roOt1234;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoListItemConfiguration());
            modelBuilder.ApplyConfiguration(new TodoListConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
