using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HomeLibrary3.Models;

namespace HomeLibrary3.Controllers
{
    public class LibraryController : Controller
    {
        private static LibraryModel Library;

        static LibraryController()
        {
            var model = new LibraryModel
            {
                Name = "My home library",
                Books = new List<BookModel>(),
                NextId = 1
            };
            model.AddBook(new BookModel { Title = "Oliver Twist", Author = "Charles Dickens", Year = 1837 });
            model.AddBook(new BookModel { Title = "Winnie-the-Pooh", Author = "A. A. Milne", Year = 1926 });
            model.AddBook(new BookModel { Title = "The Hobbit", Author = "J. R. R. Tolkien", Year = 1937 });
            model.AddBook(new BookModel { Title = "The Bicentennial Man", Author = "Isaac Asimov", Year = 1976 });
            model.AddBook(new BookModel { Title = "The Green Mile", Author = "Stephen King", Year = 1996 });
            Library = model;
        }

        public ActionResult Index()
        {
            return View(Library);
        }

        public ActionResult Edit(int index)
        {
            return View(Library.Books[index]);
        }

        [HttpPost]
        public ActionResult Edit(BookModel book)
        {
            Library.UpdateBook(book);
            return RedirectToAction("Index");
        }

        public ActionResult EditRedirect(LibraryModel clientLibrary, int index)
        {
            Library = clientLibrary;            
            return Json(new { redirect = true, url = "Library/Edit?index=" + index });
        }

        public ActionResult Add(LibraryModel clientLibrary)
        {
            var book = new BookModel
            {
                Title = "New book",
                Author = "Unknown",
                Year = DateTime.Now.Year
            };
            clientLibrary.AddBook(book);
            Library = clientLibrary;
            return Json(clientLibrary);
        }

        public ActionResult Remove(LibraryModel clientLibrary, int index)
        {
            clientLibrary.Books.RemoveAt(index);
            Library = clientLibrary;
            return Json(clientLibrary);
        }
    }
}
