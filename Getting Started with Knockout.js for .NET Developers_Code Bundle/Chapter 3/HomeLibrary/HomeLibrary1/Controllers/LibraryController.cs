using HomeLibrary1.Models;
using System;
using System.Web.Mvc;

namespace HomeLibrary1.Controllers
{
  public class LibraryController : Controller
  {
    private static readonly LibraryModel Library = new LibraryModel();

    public ActionResult Index()
    {
      return View(Library);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
      return View(Library.GetBook(id));
    }

    [HttpPost]
    public ActionResult Edit(BookModel book)
    {
      Library.UpdateBook(book);
      return RedirectToAction("Index");
    }

    public ActionResult Add()
    {
      var book = new BookModel
      {
        Title = "New Book",
        Author = "Unknown",
        Year = DateTime.Now.Year
      };
      Library.AddBook(book);
      return RedirectToAction("Index");
    }

    public ActionResult Remove(int id)
    {
      Library.RemoveBook(id);
      return RedirectToAction("Index");
    }
  }
}
