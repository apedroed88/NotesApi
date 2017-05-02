using NotesApi.Config.Models;
using Microsoft.EntityFrameworkCore;

namespace AppContext
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {               
            options.UseSqlite("Data Source=ApiNotes.db");
        }

    }
}