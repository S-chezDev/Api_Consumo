using Microsoft.EntityFrameworkCore;
using WebApi.Models; // 👈 importa tu DbContext

var builder = WebApplication.CreateBuilder(args);

// 🔹 REGISTRO DEL DB CONTEXT
builder.Services.AddDbContext<InventarioDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // 👈 opcional pero recomendado
app.UseAuthorization();
app.MapControllers();
app.Run();