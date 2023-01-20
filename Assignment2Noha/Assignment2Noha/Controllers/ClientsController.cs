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
    public class ClientsController : Controller
    {
        private readonly ClientOrderDBContext _context;
        private readonly IWebHostEnvironment _env;

        public ClientsController(ClientOrderDBContext context, IWebHostEnvironment env)
        {
            _context = context;
           _env = env;


        }

        // GET: Clients
        public async Task<IActionResult> Index(String clients)
        {

            ViewBag.ClientName = clients == "ClientName" ? "ClientNameDesc  " : "ClientName";
            ViewBag.ClientGender = clients == "ClientGender" ? "ClientGenderDesc" : "ClientGender";
            
            var c = from s in _context.Clients select s;
            switch (clients)
            {
                case "ClientName":
                    c = c.OrderBy(s => s.ClientName);
                    break;
                case "ClientNameDesc":
                    c = c.OrderByDescending(s => s.ClientName);
                    break;
                case "ClientGender":
                    c = c.OrderBy(s => s.ClientGender);
                    break;
                case "ClientGenderDesc":
                    c = c.OrderByDescending(s => s.ClientGender);
                    break;
               
                default:
                    c = c.OrderByDescending(s => s.ClientName);
                    break;
            }

            return View(c);
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,ClientName,ClientGender,Email,ClientImage")] Client client)
        {
            UploadImage(client);
            //  if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,ClientName,ClientGender,Email,ClientImage")] Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }

          //  if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientId))
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
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clients == null)
            {
                return Problem("Entity set 'ClientOrderDBContext.Clients'  is null.");
            }
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
          return _context.Clients.Any(e => e.ClientId == id);
        }
        private void UploadImage(Client model)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {
                //String imageName = Path.GetFileName(file[0].FileName);
                String imageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.
                    Combine(_env.WebRootPath, "Images", imageName)
                    , FileMode.Create);
                file[0].CopyTo(fileStream);
                model.ClientImage = imageName;
            }
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(Client client)
        {
            List<Client> result = new List<Client>();
            result = _context.Clients.Where(s => s.ClientName == client.ClientName).ToList();
            return View("index", result);
        }


    }
}
