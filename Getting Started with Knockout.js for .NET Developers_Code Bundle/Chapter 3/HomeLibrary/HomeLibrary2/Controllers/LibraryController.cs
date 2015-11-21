using System;
using System.Web.Mvc;
using HomeLibrary2.Models;

namespace HomeLibrary2.Controllers
{
  public class LibraryController : Controller
  {
    private static readonly LibraryModel Library = new LibraryModel();

    public ActionResult Index()
    {
      return View(Library);
    }

    public JsonResult GetName()
    {
      return Json(Library.Name, JsonRequestBehavior.AllowGet);
    }

    public JsonResult GetBooks()
    {
      return Json(Library.GetBooks(), JsonRequestBehavior.AllowGet);
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

    public JsonResult Add()
    {
      var book = new BookModel
      {
        Title = "New book",
        Author = "Unknown",
        Year = DateTime.Now.Year
      };
      Library.AddBook(book);
      return Json(Library.GetBooks(), JsonRequestBehavior.AllowGet);
    }

    public JsonResult Remove(int id)
    {
      Library.RemoveBook(id);
      return Json(Library.GetBooks(), JsonRequestBehavior.AllowGet);
    }
  }
}
