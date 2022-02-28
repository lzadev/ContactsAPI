namespace Contacts.DataAccess.Repositories.Abstract
{
    using Contacts.Domain.Entities;
    public interface IGenericRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Func<T, bool> func);
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<IEnumerable<T>> AddMany(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<int> Delete(T entity);
    }
}
