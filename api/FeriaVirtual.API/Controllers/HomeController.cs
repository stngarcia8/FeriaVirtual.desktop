using System.Web.Mvc;

namespace FeriaVirtual.API.Controllers {
    public class HomeController:Controller {
        public ActionResult Index() {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
