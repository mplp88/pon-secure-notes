using Pon.SecureNotes.Application.DTOs.Notes;
using Pon.SecureNotes.Domain.Entities;

namespace Pon.SecureNotes.Application.Interfaces.Services
{
    public interface INoteService
    {
        Task<IEnumerable<NoteResponseDto>> GetNotesByUserId(Guid userId);
        Task<NoteResponseDto> Create(Guid userId, CreateNoteRequestDto dto);
        Task<bool> Delete(Guid userId, Guid noteId);
    }
}
