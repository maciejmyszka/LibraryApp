using LibraryApp.Areas.Identity.Data;
using LibraryApp.Data;
using LibraryApp.Migrations;
using LibraryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class LoanController : Controller
    {
        private readonly LibraryAppContext _context;
        private readonly UserManager<LibraryAppUser> _userManager;

        public LoanController(LibraryAppContext context, UserManager<LibraryAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: LoanController
        public ActionResult Index()
        {
            var results = _context.Loans.Include(f => f.User).Include(f => f.Book).ToList();
            return View(results);
        }

        // GET: LoanController/Details/5
        public ActionResult Details(int id)
        {
            var current = _context.Loans.Find(id);

            if (current != null)
            {
                var user = _context.Users.Where(a => a.Id == current.UserId).ToList();
                var book = _context.Books.Where(a => a.Id == current.BookId).ToList();

                ViewBag.User = user;
                ViewBag.Book = book;
            }

            return View(current);
        }

        // GET: LoanController/Create
        public ActionResult Create()
        {
            var books = _context.Books.Where(a => a.IsAvailable).Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Title
            }).ToList();

            var users = _userManager.Users.Select(a => new SelectListItem
            {
                Value = a.Id,
                Text = a.FirstName + " " + a.LastName
            }).ToList();

            ViewBag.books = new SelectList(books, "Value", "Text");
            ViewBag.users = new SelectList(users, "Value", "Text");

            return View(new Loan());
        }

        // POST: LoanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Loan loan)
        {
            try
            {
                var loanBook = _context.Books.Find(loan.BookId);
                if (loanBook != null)
                {
                    loanBook.IsAvailable = false;
                    _context.Books.Update(loanBook);
                }

                _context.Loans.Add(loan);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanController/Edit/5
        public ActionResult Edit(int id)
        {
            var current = _context.Loans.Find(id);

            var books = _context.Books.Where(a => a.Id == current.BookId).Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Title
            }).ToList();

            var users = _context.Users.Where(a => a.Id == current.UserId).Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.FirstName + a.LastName
            }).ToList();

            ViewBag.books = new SelectList(books, "Value", "Text");
            ViewBag.users = new SelectList(users, "Value", "Text");

            return View(current);
        }

        // POST: LoanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Loan loan)
        {
            try
            {
                if (loan.ReturnDate != null)
                {
                    var loanBook = _context.Books.Find(loan.BookId);

                    if (loanBook != null)
                    {
                        loanBook.IsAvailable = true;
                        _context.Books.Update(loanBook);
                    }
                }

                _context.Loans.Update(loan);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanController/Delete/5
        public ActionResult Delete(int id)
        {
            var current = _context.Loans.Find(id);
            return View();
        }

        // POST: LoanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Loan loan)
        {
            try
            {
                _context.Loans.Remove(loan);
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
