using KursProjectLast.BLL.Services.IServices;
using KursProjectLast.Models;
using KursProjectLast.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net;

namespace KursProjectLast.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public static bool CheckForInternetConnection(int timeoutMs = 10000, string url = null)
        {
            try
            {
                url ??= CultureInfo.InstalledUICulture switch
                {
                    { Name: var n } when n.StartsWith("fa") => // Iran
                        "http://www.aparat.com",
                    { Name: var n } when n.StartsWith("zh") => // China
                        "http://www.baidu.com",
                    _ =>
                        "http://www.gstatic.com/generate_204",
                };

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                using (var response = (HttpWebResponse)request.GetResponse())
                    return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<IActionResult> Index()
        {
            if (CheckForInternetConnection())
            {
                return View();
            }
            else
            {
                return View("NoINternetConnection");
            }
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("Index");
        }
        
        public async Task<IActionResult> LoginCheck(UserLoginDTO userLoginDTO)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", userLoginDTO);
            }
            else
            {
                userLoginDTO.Password = Hasher.HashPassword(userLoginDTO.Password);
                bool test = await _userService.Check(userLoginDTO);
                if (test)
                {
                    HttpContext.Session.SetString("key",userLoginDTO.UserName + userLoginDTO.Password);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Index");
                }
            }
        }
    }
}
