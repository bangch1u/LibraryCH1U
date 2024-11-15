using LibraryBlazorWasm;
using LibraryBlazorWasm.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7026") });
builder.Services.AddTransient<IBookApiClient, BookApiClient>();
builder.Services.AddTransient<IAuthorApiClient, AuthorApiClient>();

await builder.Build().RunAsync();
