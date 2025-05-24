using CuestionarioWeb10;
using CuestionarioWeb10.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Usamos navegación con hash (#) para compatibilidad con GitHub Pages
builder.RootComponents.Add<App>("#app");

// Inyectamos nuestra clase personalizada de navegación
builder.Services.AddScoped<NavigationManager, CustomHashNavigationManager>();

// Servicios
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<PreguntaService>();

await builder.Build().RunAsync();
