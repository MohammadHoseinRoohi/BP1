using Practice1.DbContextes;
using Practice1.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/books/list", () =>
{
    using var db = new LibraryDB();
    return db.Books.ToList();
});
app.MapPost("api/v1/books/create", (Book book) =>
{
    using var db = new LibraryDB();
    db.Books.Add(book);
    db.SaveChanges();
});
app.MapPut("api/v1/books/update/{id}", (int id , Book book) =>
{
    using var db = new LibraryDB();
    var b = db.Books.Find(id);
    if (b == null)
    {
        return "Book Not found!!!!";
    }
    b.Title = book.Title;
    b.Writer = book.Writer;
    b.Translator = book.Translator;
    b.Publisher = book.Publisher;
    b.Genre = book.Genre;
    b.Price = book.Price;
    db.SaveChanges();
    return "Book Updated!";
});
app.MapDelete("api/v1/books/remove/{id}", (int id) =>
{
    using var db = new LibraryDB();
    var book = db.Books.Find(id);
    if (book == null)
    {
        return "Book Not found!!!!";
    }
    db.Books.Remove(book);
    db.SaveChanges();
    return "Book Removed!";
});

app.Run();