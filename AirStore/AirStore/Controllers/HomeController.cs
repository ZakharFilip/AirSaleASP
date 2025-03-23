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
        public async Task<IActionResult> Index(string searchString)
        {
            // Сохраняем строку поиска в ViewBag для отображения в поле ввода
            ViewBag.SearchString = searchString;

            // Получаем все продукты
            var products = from p in _context.Products
                           select p;

            // Если строка поиска не пустая, фильтруем продукты
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p =>
                    p.Name.Contains(searchString) ||
                    (p.Diskription != null && p.Diskription.Contains(searchString)));
            }

            // Преобразуем в список и возвращаем в представление
            return View(await products.ToListAsync());
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
