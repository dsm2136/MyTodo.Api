using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTodo.Storage.Models;

namespace MyTodo.Storage.Configurations
{
    public class TodoListItemConfiguration : IEntityTypeConfiguration<TodoListItem>
    {
        public void Configure(EntityTypeBuilder<TodoListItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(4096);

            builder.Property(x => x.CreatedOn)
                .IsRequired();

            builder.HasOne(x => x.TodoList)
                .WithMany().HasForeignKey(x =>  x.TodoListId);

            builder.HasMany(x => x.Steps)
                .WithOne().HasForeignKey(x => x.Id);
        }
    }
}
