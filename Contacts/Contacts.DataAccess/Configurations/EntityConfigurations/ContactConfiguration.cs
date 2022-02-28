namespace Contacts.DataAccess.Configurations.EntityConfigurations
{
    using Contacts.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(x => x.CreatedAt)
                .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ModifiedAt)
                .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(x => x.DeletedAt)
                .HasDefaultValue(null);
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
