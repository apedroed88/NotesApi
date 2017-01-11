using System.Collections.Generic;
using System.Linq;
using AppContext;
using GerenciadorDeTarefas.Config.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.Config.Repositorios
{
    public class RepositorioDeUsuarios
    {
        GerenciadorDeTarefasContext _context = new GerenciadorDeTarefasContext();
        public Usuario BuscarPorId(int usurioId, bool incluirTarefas=false)
        {            
            if (incluirTarefas)
                return _context.Usuarios.Where(x => x.UsuarioId == usurioId).Include(x => x.Tarefas).FirstOrDefault();
            
            return _context.Usuarios.Where(x => x.UsuarioId == usurioId).FirstOrDefault();
        }

        public List<Usuario> BuscarTodos()
        {
            var usuarios = _context.Usuarios.ToList();
            return usuarios;
        }

        public bool Salvar(Usuario usuario)
        {
            var usuarioJaCadastrado = _context.Usuarios.All(x => x.Email == usuario.Email);
            if (!usuarioJaCadastrado)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Altualizar(int id, Usuario usuario)
        {
            try
            {
                usuario.UsuarioId = id;
                _context.Entry(usuario).State = EntityState.Modified;
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
            var usuario = _context.Usuarios.FirstOrDefault(x => x.UsuarioId == id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }
}