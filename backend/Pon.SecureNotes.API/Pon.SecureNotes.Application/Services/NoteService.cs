using Pon.SecureNotes.Application.DTOs.Notes;
using Pon.SecureNotes.Application.Interfaces.Repository;
using Pon.SecureNotes.Application.Interfaces.Services;
using Pon.SecureNotes.Domain.Entities;

namespace Pon.SecureNotes.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRespository;
        private readonly ICryptoService _cryptoService;
        
        public NoteService(INoteRepository noteRespository, ICryptoService cryptoService)
        {
            _noteRespository = noteRespository;
            _cryptoService = cryptoService;
        }

        public async Task<NoteResponseDto> Create(Guid userId, CreateNoteRequestDto dto)
        {
            var content = dto.Encrypt ? _cryptoService.Encrypt(dto.Content) : dto.Content;

            var note = new Note()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Title = dto.Title,
                Content = content,
                IsEncrypted = dto.Encrypt,
                CreatedAt = DateTime.UtcNow
            };

            await _noteRespository.Create(note);
            await _noteRespository.SaveChanges();

            return new NoteResponseDto
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                CreatedAt = note.CreatedAt
            };
        }

        public async Task<bool> Delete(Guid userId, Guid noteId)
        {
            var notes = await GetNotesByUserId(userId); // Ensure the user has access to the note

            if(!notes.Any(n => n.Id == noteId))
            {
                throw new UnauthorizedAccessException("You do not have permission to delete this note.");
            }

            return await _noteRespository.Delete(noteId);
        }

        public async Task<IEnumerable<NoteResponseDto>> GetNotesByUserId(Guid userId)
        {
            var notes = await _noteRespository.GetNotesByUserId(userId);

            var notesDto = notes.Select(n => new NoteResponseDto
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.IsEncrypted ? _cryptoService.Decrypt(n.Content) : n.Content,
                CreatedAt = n.CreatedAt,
                IsEncrypted = n.IsEncrypted
            });

            return notesDto;
        }
    }
}
