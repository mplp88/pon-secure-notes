using Microsoft.EntityFrameworkCore;
using Pon.SecureNotes.Application.Interfaces.Repository;
using Pon.SecureNotes.Domain.Entities;
using Pon.SecureNotes.Infrasctructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pon.SecureNotes.Infrasctructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
        
    {
        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext db)
            : base(db) => this.db = db;

        public async Task<User?> GetByEmail(string email)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
