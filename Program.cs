using CuestionarioWeb10;
using CuestionarioWeb10.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Usa navegación con hash
builder.RootComponents.Add<App>("#app");
builder.Services.AddScoped<NavigationManager, CustomHashNavigationManager>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<PreguntaService>();

await builder.Build().RunAsync();
