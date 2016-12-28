using GerenciadorDeTarefas.Config.Models;
using Microsoft.EntityFrameworkCore;

namespace AppContext
{
    public class GerenciadorDeTarefasContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=GerenciadorDeTarefas;User Id=postgres; Password=Silver99;");
        }

    }
}