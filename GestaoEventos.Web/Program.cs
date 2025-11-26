using GestaoEventos.Application.Interfaces;
using GestaoEventos.Application.Services;
using GestaoEventos.Core.Interfaces;
using GestaoEventos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Mapster;
using MapsterMapper;
using GestaoEventos.Application.ViewModels; 
using GestaoEventos.Core.Entities;        
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

var config = TypeAdapterConfig.GlobalSettings;

config.NewConfig<CategoriaViewModel, Categoria>()
    .ConstructUsing(src => new Categoria(src.Nome));


config.NewConfig<EventoViewModel, Evento>()
    .ConstructUsing(src => new Evento(
        src.Nome, 
        src.Descricao, 
        src.Local, 
        src.DataInicio, 
        src.Capacidade, 
        src.CategoriaId
    ));


config.NewConfig<Evento, EventoViewModel>()
    .Map(dest => dest.CategoriaNome, src => src.Categoria.Nome);


builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();


builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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