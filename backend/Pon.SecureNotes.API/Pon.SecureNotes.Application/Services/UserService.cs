using Pon.SecureNotes.Application.DTOs.Auth;
using Pon.SecureNotes.Application.Interfaces.Repository;
using Pon.SecureNotes.Application.Interfaces.Services;
using Pon.SecureNotes.Domain.Entities;

namespace Pon.SecureNotes.Application.Services
{
    public class UserService(IAuthService authService, IUserRepository repository) : IUserService
    {
        public async Task<User> Create(RegisterDto dto)
        {
            var user = new User()
            {
                CreateAt = DateTime.Now,
                Email = dto.Email,
                PasswordHash = authService.HashPassword(dto.Password)
            };

            return await repository.Create(user);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await repository.Delete(id);
        }

        public async Task<User?> Get(Guid Id)
        {
            return await repository.GetById(Id);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await repository.GetByEmail(email);
        }

        public async Task<User> Update(User entity)
        {
            return await repository.Update(entity);
        }
    }
}
