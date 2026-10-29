using ApiSistemaTarefas.Model;
using ApiSistemaTarefas.Repositorio;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSistemaTarefas.ServicesDb
{
    public class TarefaService : ITarefaService
    {
        private readonly BancoContext _context;
        public TarefaService(BancoContext context)
        {
            _context = context;
        }
        public Tarefa Atualizar(int id ,Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefa.Find(id);
            if (tarefaBanco == null)
                return null;
            tarefaBanco.Titilo = tarefa.Titilo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.StatusTarefa = tarefa.StatusTarefa;
            tarefaBanco.Data = tarefa.Data;
            _context.Tarefa.Update(tarefaBanco);
            _context.SaveChanges();
            return tarefaBanco;


        }

        public Tarefa Criar(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
                return null;
            _context.Tarefa.Add(tarefa);
            _context.SaveChanges();
            return tarefa;
        }

        public bool Deletar(int id)
        {
            var tarefaBanco = _context.Tarefa.Find(id);
            if (tarefaBanco == null)
                return false;
            _context.Tarefa.Remove(tarefaBanco);
            _context.SaveChanges();
            return true;
        }

        public List<Tarefa> ObterPorData(DateTime data)
        {
            var tarefa = _context.Tarefa.Where(x => x.Data == data).ToList();
            if (tarefa == null)
                return null;
            return tarefa;
        }

        public Tarefa ObterPorId(int id)
        {
            var tarefa = _context.Tarefa.Find(id);
            if (tarefa == null)
                return null;
            return tarefa;
        }

        public List<Tarefa> ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefas = _context.Tarefa.Where(x => x.StatusTarefa == status).ToList();
            return tarefas;
        }

        public List<Tarefa> ObterPorTitulo(string titulo)
        {

            var tarefasPortitulo = _context.Tarefa.Where(x => x.Titilo.ToLower().Contains(titulo.ToLower())).ToList();
            if (tarefasPortitulo == null)
                return null;
            return tarefasPortitulo;
        }

        public List<Tarefa> ObterTodos()
        {
            return _context.Tarefa.ToList();
        }
    }
}
