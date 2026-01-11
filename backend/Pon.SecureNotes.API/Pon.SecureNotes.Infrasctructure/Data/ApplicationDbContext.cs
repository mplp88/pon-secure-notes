using Microsoft.EntityFrameworkCore;
using Pon.SecureNotes.Domain.Entities;

namespace Pon.SecureNotes.Infrasctructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
