using System.Collections.Generic;

namespace HomeLibrary2.Models
{
  public class LibraryModel
  {
    private readonly List<BookModel> books = new List<BookModel>();

    private int nextId = 1;

    public string Name { get; set; }

    public LibraryModel()
    {
      Name = "My home library";
      AddBook(new BookModel { Title = "Oliver Twist", Author = "Charles Dickens", Year = 1837 });
      AddBook(new BookModel { Title = "Winnie-the-Pooh", Author = "A. A. Milne", Year = 1926 });
      AddBook(new BookModel { Title = "The Hobbit", Author = "J. R. R. Tolkien", Year = 1937 });
      AddBook(new BookModel { Title = "The Bicentennial Man", Author = "Isaac Asimov", Year = 1976 });
      AddBook(new BookModel { Title = "The Green Mile", Author = "Stephen King", Year = 1996 });
    }

    public IEnumerable<BookModel> GetBooks()
    {
      return books;
    }

    public BookModel GetBook(int id)
    {
      return books.Find(b => b.Id == id);
    }

    public void AddBook(BookModel book)
    {
      book.Id = nextId++;
      books.Add(book);
    }

    public bool UpdateBook(BookModel book)
    {
      var index = books.FindIndex(b => b.Id == book.Id);
      if (index == -1)
        return false;
      books.RemoveAt(index);
      books.Insert(index, book);
      return true;
    }

    public void RemoveBook(int id)
    {
      books.RemoveAll(b => b.Id == id);
    }
  }
}