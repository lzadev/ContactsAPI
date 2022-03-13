namespace Contacts.DataAccess.Repositories.Concret
{
    using Contacts.DataAccess.Configurations.Contexts;
    using Contacts.DataAccess.Repositories.Abstract;
    using Contacts.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        private readonly ContactContext _context;
        private readonly DbSet<T> _entity;
        public GenericRepository(ContactContext context)
        {
            _context = context;
            _entity = context.Set<T>();

        }
        public virtual async Task<T> Add(T entity)
        {
            await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<T>> AddMany(IEnumerable<T> entities)
        {
            await _entity.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public virtual async Task<int> Delete(T entity)
        {
            _entity.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public virtual Task<IEnumerable<T>> GetAll(Func<T, bool> func)
        {
            return Task.FromResult(_entity.Where(func));
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x=>x.Id == id);
        }

        public virtual async Task<T> Update(T entity)
        {
            _entity.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
