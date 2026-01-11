namespace Pon.SecureNotes.Application.DTOs.Notes
{
    public class CreateNoteRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty; 
        public bool Encrypt { get; set; }
    }
}
