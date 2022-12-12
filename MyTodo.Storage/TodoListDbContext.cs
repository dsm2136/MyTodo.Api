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
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new TaskListConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MyTodo;User Id=sa;Password=roOt1234;");
        }
    }
}
