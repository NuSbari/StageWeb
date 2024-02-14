using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using StageWeb.Models;

var builder = WebApplication.CreateBuilder(args);
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

app.MapGet("/books", async (LibraryDb db) =>
{
    var books = await db.Books.ToListAsync();
    return books;
});

app.MapGet("/books/{id}", async (LibraryDb db, int id) => await db.Books.FindAsync(id));

app.MapPost("/books", async (LibraryDb db, Book book) =>
{
    db.Books.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"/books/{book.Id}", book);
});

app.MapPut("/books/{id}", async (LibraryDb db, int id, Book book) =>
{
    if (id != book.Id)
    {
        return Results.BadRequest();
    }
    db.Entry(book).State = EntityState.Modified;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/books/{id}", async (LibraryDb db, int id) =>
{
    var book = await db.Books.FindAsync(id);
    if (book == null)
    {
        return Results.NotFound();
    }
    db.Books.Remove(book);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapGet("/Bookshelve", async (LibraryDb db) =>
{
    var bookshelves = await db.BookShelves.ToListAsync();
    return bookshelves;
});

app.MapGet("/Bookshelve/{id}", async (LibraryDb db, int id) => await db.BookShelves.FindAsync(id));

app.MapPost("/Bookshelve", async (LibraryDb db, BookShelf bookShelf) =>
{
    db.BookShelves.Add(bookShelf);
    await db.SaveChangesAsync();
    return Results.Created($"/Bookshelve/{bookShelf.Id}", bookShelf);
});

app.MapPut("/Bookshelve/{id}", async (LibraryDb db, int id, BookShelf bookShelf) =>
{
    if (id != bookShelf.Id)
    {
        return Results.BadRequest();
    }
    db.Entry(bookShelf).State = EntityState.Modified;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/Bookshelve/{id}", async (LibraryDb db, int id) =>
{
    var bookShelf = await db.BookShelves.FindAsync(id);
    if (bookShelf == null)
    {
        return Results.NotFound();
    }
    db.BookShelves.Remove(bookShelf);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapGet("/Genres", async (LibraryDb db) =>
{
    var genres = await db.Genres.ToListAsync();
    return genres;
});

app.MapGet("/Genres/{id}", async (LibraryDb db, int id) => await db.Genres.FindAsync(id));

app.MapPost("/Genres", async (LibraryDb db, Genre genre) =>
{
    db.Genres.Add(genre);
    await db.SaveChangesAsync();
    return Results.Created($"/Genres/{genre.Id}", genre);
});

app.MapPut("/Genres/{id}", async (LibraryDb db, int id, Genre genre) =>
{
    if (id != genre.Id)
    {
        return Results.BadRequest();
    }
    db.Entry(genre).State = EntityState.Modified;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/Genres/{id}", async (LibraryDb db, int id) =>
{
    var genre = await db.Genres.FindAsync(id);
    if (genre == null)
    {
        return Results.NotFound();
    }
    db.Genres.Remove(genre);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();