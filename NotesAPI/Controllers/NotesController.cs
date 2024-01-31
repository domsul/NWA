using NotesAPI.Models;
using NotesAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace NotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            var notes = await _notesService.GetNotes();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNoteById(int id)
        {
            var note = await _notesService.GetNoteById(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        [HttpPost]
        public async Task<ActionResult<Note>> CreateNote([FromBody] Note note)
        {
            try
            {
                var createdNote = await _notesService.CreateNote(note);
                return CreatedAtAction(nameof(GetNoteById), new { id = createdNote.Id }, createdNote);
            }
            catch (Exception ex)
            {
                return BadRequest($"Note creating failed: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, [FromBody] Note note)
        {
            if (id != note.Id)
            {
                return BadRequest("Cannot update - this note doesn't exists.");
            }

            try
            {
                await _notesService.UpdateNote(note);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Note updating failed: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            try
            {
                await _notesService.DeleteNote(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Note deleting failed: {ex.Message}");
            }
        }
    }
}