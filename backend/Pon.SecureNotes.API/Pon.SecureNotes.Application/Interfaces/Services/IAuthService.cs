using Pon.SecureNotes.Domain.Entities;

namespace Pon.SecureNotes.Application.Interfaces.Services
{
    public interface IAuthService
    {
        public string HashPassword(string password);
        public bool Verify(string password, string passwordHash);
        public string GenerateToken(User user);
    }
}
