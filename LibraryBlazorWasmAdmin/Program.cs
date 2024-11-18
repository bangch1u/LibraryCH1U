using LibraryBlazorWasmAdmin;
using LibraryBlazorWasmAdmin.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7026") });
builder.Services.AddTransient<IBookManagerApiClient, BookMangerApiClient>();
builder.Services.AddTransient<IAuthorManagerApiClient, AuthorManagerApiClient>();
builder.Services.AddTransient<IGenreManagerApiClient, GenreManagerApiClient>();
await builder.Build().RunAsync();
