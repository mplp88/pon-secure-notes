using Pon.SecureNotes.Domain.Entities;

namespace Pon.SecureNotes.Application.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User?> GetByEmail(string email);
    }
}
