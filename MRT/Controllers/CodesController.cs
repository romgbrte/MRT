using System.Web.Mvc;

namespace MRT.Controllers
{
    public class CodesController : Controller
    {
        // GET: Codes
        public ActionResult Index()
        {
            ViewBag.Title = "Codes";
            ViewBag.CodesActive = "active";
            return View("Index");
        }
    }
}