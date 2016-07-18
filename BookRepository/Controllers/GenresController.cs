using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookRepository.Interfaces;
using BookRepository.Database;

namespace BookRepository.Controllers
{
    public class GenresController : Controller
    {

        IGenreRepository db;

        public GenresController(IGenreRepository repository)
        {
            db = repository;
        }


        public ActionResult Index()
        {
            return View(db.SelectAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var genre = db.SelectById(id.Value);

            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        public ActionResult DetailsError(int? id, string errorText)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.Error = errorText;

            var genre = db.SelectById(id.Value);

            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Insert(genre);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var genre = db.SelectById(id.Value);

            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {

                db.Update(genre);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var genre = db.SelectById(id.Value);

            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var usage = db.BooksUsage(id);
            if (usage > 0)
            {
                var errorText = "Жанр используется " + usage + " раз(а). Невозможно удалить этот жанр!";
                return RedirectToAction("DetailsError", new { id = id, errorText = errorText });
            }

            db.Delete(id);
            db.Save();
            return RedirectToAction("Index");
        }

    }
}
