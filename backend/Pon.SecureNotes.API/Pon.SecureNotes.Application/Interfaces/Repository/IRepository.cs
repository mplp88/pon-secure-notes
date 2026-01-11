using Pon.SecureNotes.Domain.Entities;

namespace Pon.SecureNotes.Application.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(Guid id);
        Task SaveChanges();
    }
}
