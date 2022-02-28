namespace Contacts.DataAccess.Configurations.EntityConfigurations
{
    using Contacts.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.CreatedAt)
                .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ModifiedAt)
                .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(x => x.DeletedAt)
                .HasDefaultValue(null);
            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);
        }
    }
}
