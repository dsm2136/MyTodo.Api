using Microsoft.EntityFrameworkCore;
using MyTodo.Domain.Storages;
using MyTodo.Storage;
using MyTodo.Storage.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TodoListDbContext>(builder => 
    builder.UseSqlServer("Server=localhost, 1433;Database=MyTodo;User Id=sa;Password=roOt1234;TrustServerCertificate=True;"));

builder.Services.AddScoped<IUserStorage, UserRepository>();
builder.Services.AddScoped<ITodoListStorage, TodoListRepository>();
builder.Services.AddScoped<ITodoListItemStorage, TodoListItemRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
