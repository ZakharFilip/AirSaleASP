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
    public class CharacteristicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharacteristicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Characteristics
        public async Task<IActionResult> Index()
        {
            return View(await _context.Characteristics.ToListAsync());
        }

        // GET: Characteristics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characteristic = await _context.Characteristics
                .FirstOrDefaultAsync(m => m.IdCharacteristic == id);
            if (characteristic == null)
            {
                return NotFound();
            }

            return View(characteristic);
        }

        // GET: Characteristics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Characteristics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCharacteristic,CharName,Description")] Characteristic characteristic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(characteristic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(characteristic);
        }

        // GET: Characteristics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characteristic = await _context.Characteristics.FindAsync(id);
            if (characteristic == null)
            {
                return NotFound();
            }
            return View(characteristic);
        }

        // POST: Characteristics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IdCharacteristic,CharName,Description")] Characteristic characteristic)
        {
            if (id != characteristic.IdCharacteristic)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(characteristic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacteristicExists(characteristic.IdCharacteristic))
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
            return View(characteristic);
        }

        // GET: Characteristics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characteristic = await _context.Characteristics
                .FirstOrDefaultAsync(m => m.IdCharacteristic == id);
            if (characteristic == null)
            {
                return NotFound();
            }

            return View(characteristic);
        }

        // POST: Characteristics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var characteristic = await _context.Characteristics.FindAsync(id);
            if (characteristic != null)
            {
                _context.Characteristics.Remove(characteristic);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacteristicExists(int? id)
        {
            return _context.Characteristics.Any(e => e.IdCharacteristic == id);
        }
    }
}
