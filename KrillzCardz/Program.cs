using KrillzCardz;
using KrillzCardz.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IProduct, RepositoryProduct>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7219") });

await builder.Build().RunAsync();
