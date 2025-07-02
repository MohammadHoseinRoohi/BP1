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
app.MapPost("api/v1/members/create", (Member member) =>
{
    using var db = new LibraryDB();
    db.Members.Add(member);
    db.SaveChanges();
});
app.MapGet("api/v1/members/list", () =>
{
    using var db = new LibraryDB();
    return db.Members.ToList();
});
app.MapPut("api/v1/members/update/{id}", (int id , Member member) =>
{
    using var db = new LibraryDB();
    var m = db.Members.Find(id);
    if (m == null)
    {
        return "Book Not found!!!!";
    }
    m.Firstname = member.Firstname;
    m.Lastname = member.Lastname;
    m.PhoneNumber = member.PhoneNumber;
    m.Password = member.Password;
    m.Email = member.Email;
    m.Username = member.Username;
    db.SaveChanges();
    return "The Operation Was Successful.!";
});
app.MapDelete("api/v1/members/remove/{id}", (int id) =>
{
    using var db = new LibraryDB();
    var member = db.Members.Find(id);
    if (member == null)
    {
        return "Your Account Has Been Deleted.";
    }
    db.Members.Remove(member);
    db.SaveChanges();
    return "Book Removed!";
});
app.Run();