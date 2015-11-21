using System.Collections.Generic;

namespace HomeLibrary3.Models
{
  public class LibraryModel
  {
    public List<BookModel> Books { get; set; }
    public int NextId { get; set; }
    public string Name { get; set; }

    public BookModel GetBook(int id)
    {
      return Books.Find(b => b.Id == id);
    }

    public void AddBook(BookModel book)
    {
      book.Id = NextId++;
      Books.Add(book);
    }

    public bool UpdateBook(BookModel book)
    {
      var index = Books.FindIndex(b => b.Id == book.Id);
      if (index == -1)
        return false;
      Books.RemoveAt(index);
      Books.Insert(index, book);
      return true;
    }
  }
}