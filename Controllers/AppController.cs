using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class AppController : Controller
    {
        // 
        // GET: /App/

        public IActionResult Index(string firstName = "Sarah", string lastName = "Mei")
        {
          ViewData["FirstName"] = firstName;
          ViewData["LastName"] = lastName;

          return View();
        }

        // 
        // GET: /App/About/ 

        public IActionResult About(string appName = "The World's Hottest App")
        {
          ViewData["AppName"] = appName;
          return View();
        }

        // GET: /App/Contact/ 
        public IActionResult Contact()
        {
            return View();
        }
    }
}