namespace Pon.SecureNotes.Domain.Entities
{
    public class Note : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsEncrypted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
