using System.Collections.Generic;
using System.Linq;
using AppContext;
using GerenciadorDeTarefas.Config.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Config.Repositorios
{
    public class RepositorioDeTarefas
    {
        GerenciadorDeTarefasContext _context = new GerenciadorDeTarefasContext();
        public Tarefa BuscarPorId(int tarefaId, bool incluirUsuario = false)
        {

            if (incluirUsuario)
                return _context.Tarefas.Where(x => x.TarefaId == tarefaId).Include(x => x.Usuario).SingleOrDefault();

            return _context.Tarefas.Where(x => x.TarefaId == tarefaId).SingleOrDefault();
        }

        public List<Tarefa> BuscarTodos()
        {
            var Tarefas = _context.Tarefas.ToList();
            return Tarefas;
        }

        public bool Salvar(Tarefa tarefa)
        {
            var TarefaJaCadastrado = _context.Tarefas.All(x => x.Nome == tarefa.Nome);
            if (!TarefaJaCadastrado)
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Altualizar(int id, Tarefa tarefa)
        {
            try
            {
                tarefa.TarefaId = id;
                _context.Entry(tarefa).State = EntityState.Modified;
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
            var Tarefa = _context.Tarefas.FirstOrDefault(x => x.TarefaId == id);
            _context.Tarefas.Remove(Tarefa);
            _context.SaveChanges();
        }
    }
}