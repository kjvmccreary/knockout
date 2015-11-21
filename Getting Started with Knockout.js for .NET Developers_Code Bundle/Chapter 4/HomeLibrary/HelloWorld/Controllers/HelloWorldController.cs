using System.Web.Mvc;
using HelloWorld.Models;
using PerpetuumSoft.Knockout;

namespace HelloWorld.Controllers
{    
    public class HelloWorldController : KnockoutController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Hello world";
            return View(new HelloWorldModel
            {
                FirstName = "Steve",
                LastName = "Sanderson"
            });
        }
    }
}
