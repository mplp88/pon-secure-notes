using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pon.SecureNotes.Application.DTOs.Notes;
using Pon.SecureNotes.Application.Interfaces.Services;
using System.Security.Claims;

namespace Pon.SecureNotes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var userId = GetUserId();

            var notes = await _noteService.GetNotesByUserId(userId);

            return Ok(notes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteRequestDto dto)
        {
            var userId = GetUserId();

            var createdNote = await _noteService.Create(userId, dto);

            return Ok(createdNote);
        }

        [HttpDelete("{noteId:Guid}")]
        public async Task<IActionResult> DeleteNote([FromRoute] Guid noteId)
        {
            var userId = GetUserId();

            var deleted = await _noteService.Delete(userId, noteId);

            return Ok(new { ok = deleted });
        }

        private Guid GetUserId()
        {
            var sub = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            return Guid.Parse(sub);
        }
    }
}
