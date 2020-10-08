using Models.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface INoteService
    {
        Note InsertNote(Note note);
        Note GetNoteById(int id);
        List<Note> GetNotesByCategory(string category);
        List<Note> GetAllMyNotes();
        bool DeleteNote(int id);
    }
}
