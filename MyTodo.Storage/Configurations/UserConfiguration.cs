using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTodo.Storage.Models;

namespace MyTodo.Storage.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username)
                .HasMaxLength(64)
                .IsRequired();
            builder.Property(x => x.FirstName)
                .HasMaxLength(64)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasMaxLength(64);

            builder.Property(x => x.Email)
                .HasMaxLength(254)
                .IsRequired();

            builder.Property(x => x.CreatedOn)
                .IsRequired();
        }
    }
}
