using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaptopsIdentityApp.Data;
using LaptopsIdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;
using X.PagedList.Mvc.Core;
namespace LaptopsIdentityApp.Controllers
{
   // [Authorize]
    public class LaptopsController : Controller
    {
        private readonly LaptopsIdentityAppContext _context;
        private readonly IWebHostEnvironment _env;
        public LaptopsController(LaptopsIdentityAppContext context,
            IWebHostEnvironment _env)
        {
            _context = context;
            this._env = _env;
        }

        // GET: Laptops
        public IActionResult Index(String sortOrder,int ?page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Brand =  String.IsNullOrEmpty(sortOrder) ? "BrandDesc" : "Brand";

            ViewBag.Processor = sortOrder == "Processor" ? "ProcessorDesc" : "Processor";
            ViewBag.HDSize = sortOrder == "HDSize" ? "HDSizeDesc" : "HDSize";
            ViewBag.RAMSize = sortOrder == "RAMSize" ? "RAMSizeDesc" : "RAMSize";
            ViewBag.Price = sortOrder == "Price" ? "PriceDesc" : "Price";
            var laptops = from s in _context.Laptop select s;
            switch(sortOrder)
            {
                case "Brand":
                    laptops = laptops.OrderBy(s => s.Manufacture);
                    break;
                case "BrandDesc":
                    laptops = laptops.OrderByDescending(s => s.Manufacture);
                    break;
                case "Processor":
                    laptops = laptops.OrderBy(s => s.Processor);
                    break;
                case "ProcessorDesc":
                    laptops = laptops.OrderByDescending(s => s.Processor);
                    break;
                case "HDSize":
                    laptops = laptops.OrderBy(s => s.HDSize);
                    break;
                case "HDSizeDesc":
                    laptops = laptops.OrderByDescending(s => s.HDSize);
                    break;
                case "RAMSize":
                    laptops = laptops.OrderBy(s => s.RamSize);
                    break;
                case "RAMSizeDesc":
                    laptops = laptops.OrderByDescending(s => s.RamSize);
                    break;
                case "Price":
                    laptops = laptops.OrderBy(s => s.Price);
                    break;
                case "PriceDesc":
                    laptops = laptops.OrderByDescending(s => s.Price);
                    break;
                default:
                    laptops = laptops.OrderByDescending(s => s.Price);
                    break;
            }

            int pageSize = 6;
            int pageNumber = (page ?? 1);


            return View(laptops.ToPagedList(pageNumber, pageSize));
        }

        // GET: Laptops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Laptop == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptop
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // GET: Laptops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laptops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Manufacture,Processor,HDSize,RamSize,Price,Image")] Laptop laptop)
        {
            UploadImage(laptop);
           // if (ModelState.IsValid)
            {
                _context.Add(laptop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laptop);
        }

        // GET: Laptops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Laptop == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptop.FindAsync(id);
            if (laptop == null)
            {
                return NotFound();
            }
            return View(laptop);
        }

        // POST: Laptops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Manufacture,Processor,HDSize,RamSize,Price,Image")] Laptop laptop)
        {
            UploadImage(laptop);

            if (id != laptop.Id)
            {
                return NotFound();
            }

          //  if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laptop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaptopExists(laptop.Id))
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
            return View(laptop);
        }

        // GET: Laptops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Laptop == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptop
                .FirstOrDefaultAsync(m => m.Id == id);
            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        // POST: Laptops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Laptop == null)
            {
                return Problem("Entity set 'LaptopsIdentityAppContext.Laptop'  is null.");
            }
            var laptop = await _context.Laptop.FindAsync(id);
            if (laptop != null)
            {
                _context.Laptop.Remove(laptop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopExists(int id)
        {
          return _context.Laptop.Any(e => e.Id == id);
        }
        [AllowAnonymous]
        public ActionResult Help()
        {
            return View();

        }
        private void UploadImage(Laptop model)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count()>0)
            {
               // String imageName = Path.GetFileName(file[0].FileName);
               String imageName=Guid.NewGuid().ToString()+Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.
                    Combine(_env.WebRootPath, "Images", imageName)
                    , FileMode.Create);
                file[0].CopyTo(fileStream);
                model.Image = imageName;
            }
        }
    }
}
