using Microsoft.EntityFrameworkCore;
using ReabastecimientoPanaderia.DB.Data;
using ReabastecimientoPanaderia.Repositorio.PedidoRepositorio;
using ReabastecimientoPanaderia.Repositorio.ProductoRepositorio;
using ReabastecimientoPanaderia.Server.Client.Pages;
using ReabastecimientoPanaderia.Server.Components;
using ReabastecimientoPanaderia.Services.HttpServices;
using ReabastecimientoPanaderia.Services.UtilityServices;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region Services
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7141") // ⚠️ Usa TU puerto real
});


builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));

builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();

builder.Services.AddScoped<IHttpServicio, HttpServicio>();
builder.Services.AddScoped<PedidoService>();


builder.Services.AddHttpClient();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.MapControllers();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ReabastecimientoPanaderia.Server.Client._Imports).Assembly);

app.Run();
