using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryAppContext _context;

        public BookController(LibraryAppContext context)
        {
            _context = context;
        }

        // GET: BookController
        public ActionResult Index()
        {
            var results = _context.Books.Include(f => f.Author).ToList();
            return View(results);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var current = _context.Books.Find(id);

            if (current != null)
            {
                var author = _context.Authors.Where(a => a.Id == current.AuthorId).ToList();

                ViewBag.Author = author;
            }

            return View(current);
        }

        // GET: BookController/Create
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult Create()
        {
            var authors = _context.Authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name + " " + a.LastName
            }).ToList();
            ViewBag.Authors = new SelectList(authors, "Value", "Text");
            return View(new Book());
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult Edit(int id)
        {
            var current = _context.Books.Find(id);

            var authors = _context.Authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name + " " + a.LastName
            }).ToList();

            ViewBag.Authors = new SelectList(authors, "Value", "Text");

            return View(current);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        [Authorize(Roles = "Admin,Employee")]
        public ActionResult Delete(int id)
        {
            var current = _context.Books.Find(id);
            return View(current);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book book)
        {
            try
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}