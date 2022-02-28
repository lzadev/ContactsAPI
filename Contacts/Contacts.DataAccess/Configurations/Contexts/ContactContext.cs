namespace Contacts.DataAccess.Configurations.Contexts
{
    using Contacts.DataAccess.Configurations.EntityConfigurations;
    using Contacts.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
