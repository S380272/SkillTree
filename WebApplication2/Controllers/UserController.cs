using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (model.Account =="sinyi" && model.Password == "ken")
            {
                TempData["Account"] = model.Account;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "帳號或密碼錯誤");
            }
            return View();
        }
    }
}
