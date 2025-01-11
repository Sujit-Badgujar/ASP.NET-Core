using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Controller_1.Models;

namespace Controller_1.Controllers
{
    /*public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }*/

    public class HomeController : Microsoft.AspNetCore.Mvc.Controller   
    {
        [Route("/")]
        [Route("home")]
        //public string Index()
        public ContentResult Index()
        {
            //return new ContentResult() { Content="This is the home page.", ContentType= "Text/plain"};

            //return Content("This is the home page.", "Text/plain");

            return Content("<h1>Welcome</h1> <h2>This is ASP.NET Core</h2>","text/html");
        }

        [Route("about")]
        public string About()
        {
            return "This is about learning ASP.NET Core";
        }

        //we can implement constraints for routing
        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string ContactUs()
        {
            return "Contact me on Sujit@gmail.com";
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person() { Id= Guid.NewGuid(), FirstName= "Sujit", Lastname="Badgujar",Age=26 };

            //return new JsonResult(person);  OR 

            return Json(person);

            //return "{}";
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            return new VirtualFileResult("/Documents.txt", "text/plain");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            return new PhysicalFileResult(@"C:\Users\sujit\Desktop\Documents.txt", "text/plain");
        }


    }
}
