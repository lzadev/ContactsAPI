namespace Contacts.DataAccess.Repositories.Concret
{
    using Contacts.DataAccess.Configurations.Contexts;
    using Contacts.DataAccess.Repositories.Abstract;
    using Contacts.Domain.Entities;
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(ContactContext context) : base(context)
        {
        }
    }
}
