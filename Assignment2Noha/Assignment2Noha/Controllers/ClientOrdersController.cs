using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2Noha.Data;
using Assignment2Noha.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment2Noha.Controllers
{
    [Authorize]
    public class ClientOrdersController : Controller
    {
        private readonly ClientOrderDBContext _context;

        public ClientOrdersController(ClientOrderDBContext context)
        {
            _context = context;
        }

        // GET: ClientOrders
        public async Task<IActionResult> Index()
        {
            var clientOrderDBContext = _context.ClientOrders.Include(c => c.Client).Include(c => c.Order);
            return View(await clientOrderDBContext.ToListAsync());
        }

        // GET: ClientOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientOrders == null)
            {
                return NotFound();
            }

            var clientOrder = await _context.ClientOrders
                .Include(c => c.Client)
                .Include(c => c.Order)
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (clientOrder == null)
            {
                return NotFound();
            }

            return View(clientOrder);
        }

        // GET: ClientOrders/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientName");
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return View();
        }

        // POST: ClientOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,OrderId")] ClientOrder clientOrder)
        {
          //  if (ModelState.IsValid)
            {
                _context.Add(clientOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", clientOrder.ClientId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", clientOrder.OrderId);
            return View(clientOrder);
        }

        // GET: ClientOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientOrders == null)
            {
                return NotFound();
            }

            var clientOrder = await _context.ClientOrders.FindAsync(id);
            if (clientOrder == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", clientOrder.ClientId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", clientOrder.OrderId);
            return View(clientOrder);
        }

        // POST: ClientOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,OrderId")] ClientOrder clientOrder)
        {
            if (id != clientOrder.ClientId)
            {
                return NotFound();
            }

          //  if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientOrderExists(clientOrder.ClientId))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientId", clientOrder.ClientId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", clientOrder.OrderId);
            return View(clientOrder);
        }

        // GET: ClientOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientOrders == null)
            {
                return NotFound();
            }

            var clientOrder = await _context.ClientOrders
                .Include(c => c.Client)
                .Include(c => c.Order)
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (clientOrder == null)
            {
                return NotFound();
            }

            return View(clientOrder);
        }

        // POST: ClientOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientOrders == null)
            {
                return Problem("Entity set 'ClientOrderDBContext.ClientOrders'  is null.");
            }
            var clientOrder = await _context.ClientOrders.FindAsync(id);
            if (clientOrder != null)
            {
                _context.ClientOrders.Remove(clientOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientOrderExists(int id)
        {
          return _context.ClientOrders.Any(e => e.ClientId == id);
        }




    }
}
