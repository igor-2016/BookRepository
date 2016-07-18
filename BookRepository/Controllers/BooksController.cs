using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using BookRepository.Models;
using BookRepository.Interfaces;
using BookRepository.Database;

namespace BookRepository.Controllers
{
    public class BooksController : Controller
    {

        IBookRepository db;

        public BooksController(IBookRepository bookRepository)
        {
            db = bookRepository;
        }

        public ActionResult Index()
        {
            var books = db.SelectAll();
            return View(books);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = db.SelectById(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.GenreList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Author,GenreId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Insert(book);
                db.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.GenreList(), "Id", "Name", book.GenreId);
            return View(book);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = db.SelectById(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.GenreList(), "Id", "Name", book.GenreId);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Author,GenreId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Update(book); 
                db.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.GenreList(), "Id", "Name", book.GenreId);
            return View(book);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = db.SelectById(id.Value);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            db.Save();
            return RedirectToAction("Index");
        }

    }
}
