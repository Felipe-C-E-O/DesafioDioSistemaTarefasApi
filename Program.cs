using ApiSistemaTarefas.Repositorio;
using ApiSistemaTarefas.ServicesDb;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Passos para configurar o ambiente 
// 1 -- Instalar os Pacotes do Entity Framework OK
// 2 -- Criar classe de Context OK

// 3 -- Pegar string de Conexão no appsettings OK
var connectionString = builder.Configuration.GetConnectionString("ConexaoPadrao");
// 4 -- injetar classe context
builder.Services.AddDbContext<BancoContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<ITarefaService, TarefaService>();
// 5 -- criar migrations OK
// 6 -- executar migrations OK

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
