using System.Web.Mvc;

namespace JenkinsCrudApp.Controllers
{
    public class Book : Controller
    {
        // GET
        public ActionResult Index()
        {
            return
            View();
        }
    }
}