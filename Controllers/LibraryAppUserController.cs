using LibraryApp.Areas.Identity.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryApp.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class LibraryAppUserController : Controller
    {
        private readonly UserManager<LibraryAppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public LibraryAppUserController(UserManager<LibraryAppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: LibraryAppUserController
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var usersWithRoles = new List<UserWithRolesModel>();
            
            foreach(var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                usersWithRoles.Add(new UserWithRolesModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = string.Join(", ", roles)
                });
            }

            return View(usersWithRoles);
        }

        // GET: LibraryAppUserController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var current = _userManager.Users.ToList().Find(x => x.Id == id);
            var roles = await _userManager.GetRolesAsync(current);

            var currentWithRole = new UserWithRolesModel {
                Id = current.Id,
                Email = current.Email,
                FirstName = current.FirstName,
                LastName = current.LastName,
                Roles = string.Join(", ", roles)
            };

            return View(currentWithRole);
        }

        // GET: LibraryAppUserController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var roles = _roleManager.Roles.Select(a => new SelectListItem
            {
                Value = a.Id,
                Text = a.Name,
            }).ToList();

            ViewBag.Roles = roles;

            return View(new NewUser());
        }

        // POST: LibraryAppUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewUser user)
        {
            try
            {
                if (await _userManager.FindByEmailAsync(user.Email) == null)
                {
                    var newUser = new LibraryAppUser();
                    newUser.FirstName = user.FirstName;
                    newUser.LastName = user.LastName;
                    newUser.Email = user.Email;
                    newUser.UserName = user.Email;
                    newUser.EmailConfirmed = true;

                    await _userManager.CreateAsync(newUser, user.Password);
                    await _userManager.AddToRoleAsync(newUser, "Employee");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibraryAppUserController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LibraryAppUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LibraryAppUserController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            var current = _userManager.Users.ToList().Find(x => x.Id == id);
            return View(current);
        }

        // POST: LibraryAppUserController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
