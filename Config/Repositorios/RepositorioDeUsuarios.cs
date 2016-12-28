using System.Collections.Generic;
using System.Linq;
using AppContext;
using GerenciadorDeTarefas.Config.Models;

namespace GerenciadorDeTarefas.Config.Repositorios
{
    public class RepositorioDeUsuarios
    {
        GerenciadorDeTarefasContext _context = new GerenciadorDeTarefasContext();
        public Usuario BuscarPorId(int usurioId)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.UsuarioId == usurioId);
            return usuario;
        }

        public List<Usuario> BuscarTodos()
        {
            var usuarios = _context.Usuarios.ToList();
            return usuarios;
        }

        public void Salvar(Usuario usuario)
        {
            var usuarioJaCadastrado = _context.Usuarios.All(x => x.Email == usuario.Email);
            if (!usuarioJaCadastrado)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
        }
        
        // Implementar metodo de Update

        public void Deletar(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.UsuarioId == id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }
}