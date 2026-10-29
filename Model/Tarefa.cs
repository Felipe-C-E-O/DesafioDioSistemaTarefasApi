namespace ApiSistemaTarefas.Model
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titilo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa StatusTarefa { get; set; }
    }
}
