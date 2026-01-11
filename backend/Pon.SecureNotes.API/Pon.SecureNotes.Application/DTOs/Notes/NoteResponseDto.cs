namespace Pon.SecureNotes.Application.DTOs.Notes
{
    public class NoteResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsEncrypted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
