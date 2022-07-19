using Microsoft.AspNetCore.Mvc;

namespace CareHome.Controllers
{
    public class CareHomes : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
