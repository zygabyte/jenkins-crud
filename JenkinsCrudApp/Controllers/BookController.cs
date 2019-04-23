using System.Web.Mvc;

namespace JenkinsCrudApp.Controllers
{
    public class BookController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return
            View();
        }
    }
}