using KursProjectLast.BLL.Services.IServices;
using KursProjectLast.Models;
using KursProjectLast.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KursProjectLast.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserToAddDTO user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", user);
            }
            else
            {
                user.Password = Hasher.HashPassword(user.Password);
                await _userService.Add(user);
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
