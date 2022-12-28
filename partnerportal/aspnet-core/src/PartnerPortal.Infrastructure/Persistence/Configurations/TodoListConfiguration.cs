using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Domain.Entities;

namespace PartnerPortal.Infrastructure.Persistence.Configurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .OwnsOne(b => b.Colour);
        }
    }
}
