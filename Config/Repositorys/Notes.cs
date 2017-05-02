using System.Collections.Generic;
using System.Linq;
using AppContext;
using NotesApi.Config.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Config.Repositorios
{
    public class Notes
    {
        NotesContext _context = new NotesContext();
        public Note FindById(int noteId)
        {
            return _context.Notes.Where(x => x.Id == noteId).FirstOrDefault();
        }

        public List<Note> List()
        {
            var notes = _context.Notes.ToList();
            return notes;
        }

        public bool Add(Note note)
        {
                _context.Notes.Add(note);
                _context.SaveChanges();
                return true;
           
        }

        public bool Update(int id, Note note)
        {
            try
            {
                note.Id = id;
                _context.Entry(note).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }

        }
        public void Deletar(int id)
        {
            var note = _context.Notes.FirstOrDefault(x => x.Id == id);
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }
    }
}