using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TApp.Data;
using TApp.Models;

namespace TApp.Controllers
{
    public class WearHouseItemsController : Controller
    {
        private readonly TAppContext _context;

        public WearHouseItemsController(TAppContext context)
        {
            _context = context;
        }

        // GET: WearHouseItems
        public async Task<IActionResult> Index()
        {
              return View(await _context.WearHouseItem.ToListAsync());
        }

        // GET: WearHouseItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WearHouseItem == null)
            {
                return NotFound();
            }

            var wearHouseItem = await _context.WearHouseItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wearHouseItem == null)
            {
                return NotFound();
            }
            ViewBag.WarehouseTotal = wearHouseItem.Price * wearHouseItem.Quantity;

            return View(wearHouseItem);
        }

        // GET: WearHouseItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WearHouseItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Quantity,Price")] WearHouseItem wearHouseItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wearHouseItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wearHouseItem);
        }

        // GET: WearHouseItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WearHouseItem == null)
            {
                return NotFound();
            }

            var wearHouseItem = await _context.WearHouseItem.FindAsync(id);
            if (wearHouseItem == null)
            {
                return NotFound();
            }
            return View(wearHouseItem);
        }

        // POST: WearHouseItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Quantity,Price")] WearHouseItem wearHouseItem)
        {
            if (id != wearHouseItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wearHouseItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WearHouseItemExists(wearHouseItem.Id))
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
            return View(wearHouseItem);
        }

        // GET: WearHouseItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WearHouseItem == null)
            {
                return NotFound();
            }

            var wearHouseItem = await _context.WearHouseItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wearHouseItem == null)
            {
                return NotFound();
            }

            return View(wearHouseItem);
        }

        // POST: WearHouseItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WearHouseItem == null)
            {
                return Problem("Entity set 'TAppContext.WearHouseItem'  is null.");
            }
            var wearHouseItem = await _context.WearHouseItem.FindAsync(id);
            if (wearHouseItem != null)
            {
                _context.WearHouseItem.Remove(wearHouseItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WearHouseItemExists(int id)
        {
          return _context.WearHouseItem.Any(e => e.Id == id);
        }
    }
}
