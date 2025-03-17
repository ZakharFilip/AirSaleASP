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
    public class ProdCharactersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdCharactersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProdCharacters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProdCharacters.Include(p => p.Characteristic).Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProdCharacters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodCharacter = await _context.ProdCharacters
                .Include(p => p.Characteristic)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.IdProdCharacter == id);
            if (prodCharacter == null)
            {
                return NotFound();
            }

            return View(prodCharacter);
        }

        // GET: ProdCharacters/Create
        public IActionResult Create()
        {
            ViewData["IdCharacteristic"] = new SelectList(_context.Characteristics, "IdCharacteristic", "CharName");
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct");
            return View();
        }

        // POST: ProdCharacters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProdCharacter,IdProduct,IdCharacteristic")] ProdCharacter prodCharacter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodCharacter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCharacteristic"] = new SelectList(_context.Characteristics, "IdCharacteristic", "CharName", prodCharacter.IdCharacteristic);
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct", prodCharacter.IdProduct);
            return View(prodCharacter);
        }

        // GET: ProdCharacters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodCharacter = await _context.ProdCharacters.FindAsync(id);
            if (prodCharacter == null)
            {
                return NotFound();
            }
            ViewData["IdCharacteristic"] = new SelectList(_context.Characteristics, "IdCharacteristic", "CharName", prodCharacter.IdCharacteristic);
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct", prodCharacter.IdProduct);
            return View(prodCharacter);
        }

        // POST: ProdCharacters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IdProdCharacter,IdProduct,IdCharacteristic")] ProdCharacter prodCharacter)
        {
            if (id != prodCharacter.IdProdCharacter)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodCharacter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdCharacterExists(prodCharacter.IdProdCharacter))
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
            ViewData["IdCharacteristic"] = new SelectList(_context.Characteristics, "IdCharacteristic", "CharName", prodCharacter.IdCharacteristic);
            ViewData["IdProduct"] = new SelectList(_context.Products, "IdProduct", "IdProduct", prodCharacter.IdProduct);
            return View(prodCharacter);
        }

        // GET: ProdCharacters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodCharacter = await _context.ProdCharacters
                .Include(p => p.Characteristic)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.IdProdCharacter == id);
            if (prodCharacter == null)
            {
                return NotFound();
            }

            return View(prodCharacter);
        }

        // POST: ProdCharacters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var prodCharacter = await _context.ProdCharacters.FindAsync(id);
            if (prodCharacter != null)
            {
                _context.ProdCharacters.Remove(prodCharacter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdCharacterExists(int? id)
        {
            return _context.ProdCharacters.Any(e => e.IdProdCharacter == id);
        }
    }
}
