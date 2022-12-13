using Microsoft.EntityFrameworkCore;
using MyTodo.Storage.Configurations;
using MyTodo.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Storage
{
    public class TodoListDbContext : DbContext
    {
        public DbSet<TodoList> TaskLists { get; set; }
        public DbSet<TodoListItem> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoListItemConfiguration());
            modelBuilder.ApplyConfiguration(new TodoListConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=MyTodo;User Id=sa;Password=roOt1234;TrustServerCertificate=True;");
        }
    }
}
