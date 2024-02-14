using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using StageWeb.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("LibraryDb") ?? "Data Source=books.db";
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlite<LibraryDb>(connectionString);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Library API",
        Description = "Search the books you love",
        Version = "v1"
    });
});
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API V1");
});

app.UseStaticFiles();

app.MapControllers();

app.Run();