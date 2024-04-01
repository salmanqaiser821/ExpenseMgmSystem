
using Microsoft.AspNetCore.Mvc;
using ExpenseManagement.DataLayer;
using ExpenseManagement.Models;

namespace ExpenseManagement.Controllers
{
    public class UserProfileController : Controller
    {
        public readonly DBContextExpMgt _context;

        public UserProfileController(DBContextExpMgt context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration(UserProfile userProfile)
        {

            if (ModelState.IsValid)
            {
                _context.userProfiles.Add(userProfile);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }


        public IActionResult Login(string EmailAddress, string Password)
        {
            ViewBag.LoginStatus = "";
            ViewBag.CurrentUser = "";

            if (ModelState.IsValid)
            {
                var user = _context.userProfiles.FirstOrDefault(acc => acc.EmailAddress == EmailAddress && acc.Password == Password);
                if (user == null)
                {
                    ViewBag.LoginStatus = "Login Failed. Please re-enter Email and Password Correctly";

                }
                else
                {

                    return RedirectToAction("Index", "Home");
                }

            }

            return View();
        }
    }
}
