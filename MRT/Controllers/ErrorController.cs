using System.Net;
using System.Web.Mvc;

namespace MRT.Controllers
{
    public class ErrorController : Controller
    {
        // 404
        public ActionResult NotFound()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View("NotFound");
        }

        // 500
        public ActionResult Internal()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View("Internal");
        }

        // 401
        public ActionResult Unauthorized()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return View("Unauthorized");
        }

        // 403
        public ActionResult Forbidden()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return View("Forbidden");
        }

        // 400
        public ActionResult BadRequest()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return View("BadRequest");
        }
    }
}