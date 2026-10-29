using ApiSistemaTarefas.Model;
using ApiSistemaTarefas.ServicesDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSistemaTarefas.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaService _tarefaService;
        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }
        [HttpGet("OberTodos")]
        public IActionResult ObterTodos()
        {
            var tarefas = _tarefaService.ObterTodos();
            if (!tarefas.Any())
                return NotFound("Não existe Tarefas cadastradas");
            return Ok(tarefas);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            try
            {
                var tarefas = _tarefaService.ObterPorTitulo(titulo);
                if (!tarefas.Any())
                    return NotFound("Tarefas não encontrada");
                return Ok(tarefas);
            }
            catch(Exception ex)
            {
                return NotFound($"Tarefas não encontrada Erro: {ex.Message}");
            }
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            try
            {
                var tarefas = _tarefaService.ObterPorData(data);
                if (!tarefas.Any())
                    return NotFound("Tarefas não encontrada");
                return Ok(tarefas);
            }
            catch(Exception ex)
            {
                return NotFound($"Tarefas não encontrada Erro: {ex.Message}");
            }
            
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            try
            {
                var tarefas = _tarefaService.ObterPorStatus(status);
                if (!tarefas.Any())
                    return NotFound("Tarefas não encontrada");
                return Ok(tarefas);
            }
            catch(Exception ex)
            {
                return NotFound($"Tarefas não encontrada Erro: {ex.Message}");
            }
        }

        [HttpPost("Criar")]
        public IActionResult Criar(Tarefa tarefa)
        {
            try
            {
               var tarefacriada = _tarefaService.Criar(tarefa);
                if (tarefacriada == null)
                    return BadRequest(new { Erro = "a Data da tarefa não pode ser vazia" });
                return Ok(tarefacriada);
            }
            catch (Exception ex)
            {
                return NotFound($"Erro ao criar tarefa: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            try
            {
                var tarefaAtualizada = _tarefaService.Atualizar(id, tarefa);
                if (tarefaAtualizada == null)
                    return BadRequest(new { Erro = "a Data da tarefa não pode ser vazia" });
                return Ok(tarefaAtualizada);
            }
            catch(Exception ex)
            {
                return NotFound($"Erro ao Atualizar tarefa: {ex.Message}");
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if(_tarefaService.Deletar(id))
            {
                return Ok(new { Message = "Tarefa apagar com Sucesso !" });
            }
            return NoContent();
        }
    }
}
