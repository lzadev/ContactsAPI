namespace Contacts.DataAccess.Extensions
{
    using Contacts.DataAccess.Configurations.Contexts;
    using Contacts.DataAccess.Repositories.Abstract;
    using Contacts.DataAccess.Repositories.Concret;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    public static class ServiceCollectionExtension
    {
        public static void InjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            //context
            services.AddDbContext<ContactContext>(options =>
                                    options.UseSqlServer(configuration.GetConnectionString("contacts")));

            //Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
        }
    }
}
