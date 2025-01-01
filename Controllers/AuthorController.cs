using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class AuthorController : Controller
    {
        private readonly LibraryAppContext _context;

        public AuthorController(LibraryAppContext context)
        {
            _context = context;
        }

        // GET: AuthorController
        public ActionResult Index()
        {
            return View(_context.Authors);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            var author = _context.Authors.Find(id);
            return View(author);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View(new Author());
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            try
            {
                _context.Authors.Add(author);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            var current = _context.Authors.Find(id);

            return View(current);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author author)
        {
            try
            {
                _context.Authors.Update(author);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var current = _context.Authors.Find(id);
            var authorBooks = _context.Books.Where(a => a.AuthorId == id).ToList();

            if (authorBooks != null)
            {
                ViewBag.Books = authorBooks;
            }

            return View(current);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author author)
        {
            try
            {
                _context.Authors.Remove(author);
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
