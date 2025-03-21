using AirStore.Data;
using AirStore.Models;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace AirStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize] // Только для авторизованных пользователей
        public async Task<IActionResult> Index()
        {
            //var superBuskets = await _context.SuperBuskets
            //    .Include(sb => sb.User)
            //    .Include(sb => sb.Product)
            //    .ToListAsync();
            //return View(superBuskets);
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email);

            // Сравниваем пароль в чистом виде (без хэширования)
            if (user == null || user.PasswordHash != password)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //return RedirectToAction(nameof(Privacy));
                return RedirectToAction("Index");
            }

            // Создаем claims для пользователя
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.RoleName)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // Сохраняем аутентификацию в cookies
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index");
           // return RedirectToAction(nameof(Privacy));
           
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
           // return RedirectToAction(nameof(Privacy));
        }


        public async Task<IActionResult> Privacy()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }
    }
}
