namespace GerenciadorDeTarefas.Config.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Status StatusDaTarefa { get; set; } = Status.Pendente;
        public virtual Usuario Usuario { get; set; } = new Usuario();
    }

    public enum Status
    {
        Pendente,
        Concluida
    }
}