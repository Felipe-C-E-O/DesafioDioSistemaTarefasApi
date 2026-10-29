using ApiSistemaTarefas.Model;

namespace ApiSistemaTarefas.ServicesDb
{
    public interface ITarefaService
    {
        Tarefa ObterPorId(int id);
        List<Tarefa> ObterTodos();
        List<Tarefa> ObterPorTitulo(string titulo);
        List<Tarefa> ObterPorData(DateTime data);
        List<Tarefa> ObterPorStatus(EnumStatusTarefa status);
        Tarefa Criar(Tarefa tarefa);
        Tarefa Atualizar(int id,Tarefa tarefa);
        bool Deletar(int id);

    }
}
