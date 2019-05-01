using System;
using System.Web.Mvc;
using JenkinsCrudApp.Constants;
using JenkinsCrudApp.Data;
using JenkinsCrudApp.Models;
using JenkinsCrudApp.Services.Implementations;
using JenkinsCrudApp.Services.Interfaces;

namespace JenkinsCrudApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private const string objectName = "Book";

        public BookController()
        {
                _bookService = new BookService();
        }
        public BookController(IBookService bookService = null) 
        {
            _bookService = bookService ?? new BookService();
        }
        // GET
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Create()
        {
            return null;
        }

        public JsonResult CreateBook(Book book)
        {
            try
            {
                if (book == null)
                    return Json(new ResponseData { Status = false, Message = string.Format(DefaultConstants.NullObject, objectName) }, JsonRequestBehavior.AllowGet);

                return Json(_bookService.AddBook(book) 
                    ? new ResponseData { Status = true, Message = string.Format(DefaultConstants.SuccessfullyCreated, objectName) } 
                    : new ResponseData { Status = false, Message = string.Format(DefaultConstants.FailedCreate, objectName) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new ResponseData { Status = false, Message = string.Format(DefaultConstants.ErrorCreate, objectName) }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ReadBooks()
        {
            try
            {
                return Json(new ResponseData { Status = true, Data = _bookService.GetBooks() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new ResponseData { Status = false, Message = string.Format(DefaultConstants.ErrorRead, objectName) }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ReadBook(int bookId)
        {
            try
            {
                return Json(new ResponseData { Status = true,  Data = _bookService.GetBook(bookId) });
            }
            catch (Exception e)
            {
                return Json(new ResponseData { Status = false, Message = string.Format(DefaultConstants.ErrorReadSingle, objectName, bookId) }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateBook(int bookId, Book book)
        {
            try
            {
                if (book == null)
                    return Json(new ResponseData { Status = false, Message = string.Format(DefaultConstants.NullObject, objectName) }, JsonRequestBehavior.AllowGet);

                return Json(_bookService.UpdateBook(bookId, book) 
                    ? new ResponseData { Status = true, Message = string.Format(DefaultConstants.SuccessfullyUpdated, objectName) } 
                    : new ResponseData { Status = false, Message = string.Format(DefaultConstants.FailedUpdate, objectName) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new ResponseData { Status = false, Message = string.Format(DefaultConstants.ErrorUpdate, objectName) }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteBook(int bookId)
        {
            try
            {
                return Json(_bookService.DeleteBook(bookId) 
                    ? new ResponseData { Status = true, Message = string.Format(DefaultConstants.SuccessfullyDeleted, objectName) } 
                    : new ResponseData { Status = false, Message = string.Format(DefaultConstants.FailedDelete, objectName) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new ResponseData { Status = false, Message = string.Format(DefaultConstants.ErrorDelete, objectName) }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}