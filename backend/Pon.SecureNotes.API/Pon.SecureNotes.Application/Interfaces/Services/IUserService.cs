using Pon.SecureNotes.Application.DTOs.Auth;
using Pon.SecureNotes.Domain.Entities;

namespace Pon.SecureNotes.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<User> Get(Guid Id);
        public Task<User?> GetByEmail(string email);
        public Task<User> Create(RegisterDto entity);
        public Task<User> Update(User entity);
        public Task<bool> Delete(Guid id);

    }
}
