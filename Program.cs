using Microsoft.EntityFrameworkCore;
using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Models;
using SistemaAtualEmprestimo.Repository;
using SistemaAtualEmprestimo.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Registrar os repositórios
// Register repositories


builder.Services.AddScoped<LivroRepository>();
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<IRepositoryCliente, ClienteRepository>();
builder.Services.AddScoped<IRepositoryLivro, LivroRepository>();
builder.Services.AddScoped<IRepositoryClienteContato, ClienteContatoRepository>();
builder.Services.AddScoped<IRepositoryMunicipio, RepositoryMunicipio>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
builder.Services.AddScoped<IDevolucaoRepository, DevolucaoRepository>();
builder.Services.AddScoped<IPagaMultaRepository, PagaMultaRepository>();



// Registrar os serviços
builder.Services.AddScoped<LivroService>();
builder.Services.AddScoped<ClienteService>();

//builder.Services.AddScoped<IRepositoryCliente, ClienteRepository>();


// Registrar o contexto do banco de dados
builder.Services.AddDbContext<EmprestimoAtualContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
