using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyTodo.Storage
{
    internal class DbContextFactory : IDesignTimeDbContextFactory<TodoListDbContext>
    {
        public TodoListDbContext CreateDbContext(string[] args)
        {
            //var builder = new ConfigurationBuilder.
            //    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
            //    .AddJsonFile("appSettings.Development.json", optional: true, reloadOnChange: true);

            var optionsBuilder = new DbContextOptionsBuilder<TodoListDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=MyTodo;User Id=sa;Password=roOt1234;TrustServerCertificate=True;");

            return new TodoListDbContext(optionsBuilder.Options);
        }
    }
}
