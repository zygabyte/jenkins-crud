using System;
using System.Web.Mvc;
using JenkinsCrudApp.Models;

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
        
        public ActionResult Create()
        {
            return null;
        }

        public JsonResult CreateBooks(Book book)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return null;
        }
    }
}