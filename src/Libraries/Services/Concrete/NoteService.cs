using Data.Repos;
using Models.DbEntities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Concrete
{
    public class NoteService : INoteService
    {
        private readonly IGenericRepository<Note> _repository;

        public NoteService(IGenericRepository<Note> repository)
        {
            _repository = repository;
        }

        public bool DeleteNote(int id)
        {
            Note note = _repository.GetById(id);
            if (note != null)
            {
                if (_repository.Delete(note) > 0)
                    return true;
            }
            return false;
        }

        public List<Note> GetAllMyNotes()
        {
            throw new NotImplementedException();
        }

        public Note GetNoteById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Note> GetNotesByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Note InsertNote(Note note)
        {
            return _repository.Insert(note);
        }
    }
}
