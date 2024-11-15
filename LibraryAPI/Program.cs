using LibraryAPI.Repositories;
using LibraryAPI.Services;
using LibraryData.Context;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("LibraryData")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBookRepos, BookRepos>();
builder.Services.AddScoped<IBookService, BookService>();    
builder.Services.AddScoped<IAuthorRepos, AuthorRepos>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookGenreRepos, BookGenreRepos>();
builder.Services.AddScoped<IBookGenreService, BookGenreService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
         builder => builder
                   .SetIsOriginAllowed((host) => true)
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
  
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
