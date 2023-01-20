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
    public class CustomerItemsController : Controller
    {
        private readonly TAppContext _context;

        public CustomerItemsController(TAppContext context)
        {
            _context = context;
        }

        // GET: CustomerItems
        public async Task<IActionResult> Index()
        {
              return View(await _context.CustomerItem.ToListAsync());
        }

        // GET: CustomerItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CustomerItem == null)
            {
                return NotFound();
            }

            var customerItem = await _context.CustomerItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerItem == null)
            {
                return NotFound();
            }

            ViewBag.CustomerTotal = customerItem.Price* customerItem.Quantity;

            return View(customerItem);
        }

        // GET: CustomerItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Quantity,Price")] CustomerItem customerItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerItem);
        }

        // GET: CustomerItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CustomerItem == null)
            {
                return NotFound();
            }

            var customerItem = await _context.CustomerItem.FindAsync(id);
            if (customerItem == null)
            {
                return NotFound();
            }
            return View(customerItem);
        }

        // POST: CustomerItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Quantity,Price")] CustomerItem customerItem)
        {
            if (id != customerItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerItemExists(customerItem.Id))
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
            return View(customerItem);
        }

        // GET: CustomerItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CustomerItem == null)
            {
                return NotFound();
            }

            var customerItem = await _context.CustomerItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerItem == null)
            {
                return NotFound();
            }

            return View(customerItem);
        }

        // POST: CustomerItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CustomerItem == null)
            {
                return Problem("Entity set 'TAppContext.CustomerItem'  is null.");
            }
            var customerItem = await _context.CustomerItem.FindAsync(id);
            if (customerItem != null)
            {
                _context.CustomerItem.Remove(customerItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerItemExists(int id)
        {
          return _context.CustomerItem.Any(e => e.Id == id);
        }
    }
}
