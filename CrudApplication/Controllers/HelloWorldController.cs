using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace CrudApplication.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }

        //
        //GET: /helloworld/Welcome
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
