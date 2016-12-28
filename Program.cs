using System;
using System.Linq;
using AppContext;
using GerenciadorDeTarefas.Config.Models;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tarefas = new GerenciadorDeTarefasContext();
            // Salvando Um usuario
            // var usuario = new Usuario(){
            //     Nome = "Pedro",
            //     Email = "Pedro@bol.com.br",
            //     Senha = "123",
            //     NivelDeAcesso = Nivel.Admin,
                
            // };
            // tarefas.Add(usuario);
            // tarefas.SaveChanges();


            // Salvando uma tarefa
            var tarefa = new Tarefa(){
                Nome ="Tarefa de TEste",
                Descricao = "Tarefa para testar o  relacionamento entre as entidades criadas"
            };
            var usuario = tarefas.Usuarios.First(x=>x.UsuarioId == 1);
            usuario.Tarefas.Add(tarefa);
            tarefas.SaveChanges();

        }
    }
}
