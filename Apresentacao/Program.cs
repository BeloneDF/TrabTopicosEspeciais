using Microsoft.EntityFrameworkCore;
using Repositorio;
using Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Apresentacao"))
);

builder.Services.AddScoped<IServLivro, ServLivro>();
builder.Services.AddScoped<IRepoLivro, RepoLivro>();

builder.Services.AddScoped<IServVenda, ServVenda>();
builder.Services.AddScoped<IRepoVenda, RepoVenda>();

builder.Services.AddScoped<IServFuncionario, ServFuncionario>();
builder.Services.AddScoped<IRepoFuncionario, RepoFuncionario>();


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
