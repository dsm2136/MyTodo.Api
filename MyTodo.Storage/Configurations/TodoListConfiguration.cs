using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTodo.Storage.Models;

namespace MyTodo.Storage.Configurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.ToTable("TodoList");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .HasMaxLength(300)
                .IsRequired();
            
            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.CreatedOn)
                .IsRequired();

            builder.HasMany(x => x.Tasks)
                .WithOne(x => x.TodoList).HasForeignKey(x => x.TodoListId);
        }
    }
}
