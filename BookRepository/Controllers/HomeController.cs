using BookRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookRepository.Controllers
{
    public class HomeController : Controller
    {

        IGenreRepository _genreDb;
        IBookRepository _bookDb;

        public HomeController(IGenreRepository genreDb, IBookRepository bookDb)
        {
            _genreDb = genreDb;
            _bookDb = bookDb;
        }

        public ActionResult Index()
        {
            ViewBag.TotalBooks = _bookDb.TotalBooks();
            ViewBag.TotalGenres = _genreDb.TotalGenres();
            return View();
        }

        public ActionResult BookListing()
        {
            ViewBag.Message = "Book Listing";

            return View();
        }

        public ActionResult GenreListing()
        {
            ViewBag.Message = "Genre Listing";

            return View();
        }
    }
}