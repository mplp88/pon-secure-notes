using Microsoft.EntityFrameworkCore;
using Pon.SecureNotes.Application.Interfaces.Repository;
using Pon.SecureNotes.Domain.Entities;
using Pon.SecureNotes.Infrasctructure.Data;

namespace Pon.SecureNotes.Infrasctructure.Repositories
{
    public class NoteRepository(ApplicationDbContext db) : Repository<Note>(db), INoteRepository
    {
        public async Task<IEnumerable<Note>> GetNotesByUserId(Guid userId)
        {
            var notes = await db.Notes.Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return notes;
        }
    }
}
