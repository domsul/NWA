using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.EntityFrameworkCore;
using NotesAPI.Data;
using NotesAPI.Models;

namespace NotesAPI.Services
{
        public interface INotesService
        {
            Task<IEnumerable<Note>> GetNotes();
            Task<Note> GetNoteById(int id);
            Task<Note> CreateNote(Note note);
            Task UpdateNote(Note note);
            Task DeleteNote(int id);
        }

        public class NotesService : INotesService
        {
            private readonly NotesContext _context;

            public NotesService(NotesContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Note>> GetNotes()
            {
                return await _context.Notes.ToListAsync();
            }

            public async Task<Note> GetNoteById(int id)
            {
                return await _context.Notes.FindAsync(id);
            }

            public async Task<Note> CreateNote(Note note)
            {
                _context.Notes.Add(note);
                await _context.SaveChangesAsync();
                return note;
            }

            public async Task UpdateNote(Note note)
            {
                _context.Entry(note).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteNote(int id)
            {
                var note = await _context.Notes.FindAsync(id);
                if (note == null)
                {
                    throw new ArgumentException("Cannot delete - note already deleted.");
                }
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
        }
}