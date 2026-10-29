using ApiSistemaTarefas.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiSistemaTarefas.Repositorio
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions options) : base (options)
        {

        }
        public DbSet<Tarefa> Tarefa { get; set; }
    }
}
