using System;
using System.Collections.Generic;

namespace GerenciadorDeTarefas.Config.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Nivel NivelDeAcesso { get; set; } = Nivel.Usuario;
        public Guid Guid { get; set; } = Guid.NewGuid();
        public List<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
    public enum Nivel
    {
        Admin,
        Usuario,        
    }
}