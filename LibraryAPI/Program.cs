using LibraryAPI.Repositories;
using LibraryAPI.Services;
using LibraryData.Context;
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
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Cho phép tất cả các domain truy cập
              .AllowAnyHeader()  // Cho phép tất cả các header
              .AllowAnyMethod(); // Cho phép tất cả các phương thức HTTP (GET, POST, PUT, DELETE...)
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
