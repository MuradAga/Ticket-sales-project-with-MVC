using KursProjectLast.BLL.Services.IServices;
using KursProjectLast.Models;
using KursProjectLast.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KursProjectLast.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            //List<UserToListDTO> users = await _userService.Get();
            return View();
        }

        public async Task<IActionResult> CreateUser(User user)
        {
            //await _userService.
            return View();
        }
    }
}
