using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirStore.Data;
using AirStore.Models;

namespace AirStore.Controllers
{
    public class SuperBusketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperBusketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperBuskets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SuperBuskets.Include(s => s.Product).Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SuperBuskets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superBusket = await _context.SuperBuskets
                .Include(s => s.Product)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.IdSuperBasket == id);
            if (superBusket == null)
            {
                return NotFound();
            }

            return View(superBusket);
        }

        // GET: SuperBuskets/Create
        public IActionResult Create()
        {
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct");
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser");
            return View();
        }

        // POST: SuperBuskets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSuperBasket,IdUser,IdProduct,Visibility")] SuperBusket superBusket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superBusket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct", superBusket.IdProduct);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", superBusket.IdUser);
            return View(superBusket);
        }

        // GET: SuperBuskets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superBusket = await _context.SuperBuskets.FindAsync(id);
            if (superBusket == null)
            {
                return NotFound();
            }
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct", superBusket.IdProduct);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", superBusket.IdUser);
            return View(superBusket);
        }

        // POST: SuperBuskets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IdSuperBasket,IdUser,IdProduct,Visibility")] SuperBusket superBusket)
        {
            if (id != superBusket.IdSuperBasket)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superBusket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperBusketExists(superBusket.IdSuperBasket))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct", superBusket.IdProduct);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", superBusket.IdUser);
            return View(superBusket);
        }

        // GET: SuperBuskets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superBusket = await _context.SuperBuskets
                .Include(s => s.Product)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.IdSuperBasket == id);
            if (superBusket == null)
            {
                return NotFound();
            }

            return View(superBusket);
        }

        // POST: SuperBuskets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var superBusket = await _context.SuperBuskets.FindAsync(id);
            if (superBusket != null)
            {
                _context.SuperBuskets.Remove(superBusket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperBusketExists(int? id)
        {
            return _context.SuperBuskets.Any(e => e.IdSuperBasket == id);
        }
    }
}
