using System.Web.Mvc;

namespace MRT.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "My Rate Tables";
            return View();
        }
    }
}