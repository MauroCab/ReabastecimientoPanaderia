using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ReabastecimientoPanaderia.Services.HttpServices;
using ReabastecimientoPanaderia.Services.UtilityServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});


builder.Services.AddScoped<IHttpServicio, HttpServicio>();
builder.Services.AddScoped<PedidoService>();

await builder.Build().RunAsync();
