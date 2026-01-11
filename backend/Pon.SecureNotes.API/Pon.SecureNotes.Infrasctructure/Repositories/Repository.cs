using Microsoft.EntityFrameworkCore;
using Pon.SecureNotes.Application.Interfaces.Repository;
using Pon.SecureNotes.Domain.Entities;
using Pon.SecureNotes.Infrasctructure.Data;

namespace Pon.SecureNotes.Infrasctructure.Repositories
{
    public class Repository<T>(ApplicationDbContext db) : IRepository<T> where T : BaseEntity
    {
        public async Task<T> Create(T entity)
        {
            await db.Set<T>().AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var entity = await db.Set<T>().FindAsync(id);
                db.Set<T>().Remove(entity);
                await SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await db.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChanges()
        {
            await db.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            db.Set<T>().Update(entity);
            await SaveChanges();
            return entity;
        }
    }
}
