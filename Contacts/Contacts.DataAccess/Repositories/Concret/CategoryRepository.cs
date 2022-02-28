namespace Contacts.DataAccess.Repositories.Concret
{
    using Contacts.DataAccess.Configurations.Contexts;
    using Contacts.DataAccess.Repositories.Abstract;
    using Contacts.Domain.Entities;

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ContactContext context) : base(context)
        {

        }
    }
}
