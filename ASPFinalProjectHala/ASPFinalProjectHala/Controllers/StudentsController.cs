using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPFinalProjectHala.Data;
using ASPFinalProjectHala.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASPFinalProjectHala.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly StudentTeacherDBContext _context;
        private readonly IWebHostEnvironment _env;


        public StudentsController(StudentTeacherDBContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Students
        public async Task<IActionResult> Index(String st)
        {

            ViewBag.StudentName = st == "StudentName" ? "StudentNameDesc  " : "StudentName";
            ViewBag.StudentGender = st == "StudentGender" ? "StudentGenderDesc" : "StudentGender";

            var students = from s in _context.Students select s;
            switch (st)
            {
                case "StudentName":
                    students = students.OrderBy(s => s.StudentName);
                    break;
                case "StudentNameDesc":
                    students = students.OrderByDescending(s => s.StudentName);
                    break;
                case "StudentGender":
                    students = students.OrderBy(s => s.StudentGender);
                    break;
                case "StudentGenderDesc":
                    students = students.OrderByDescending(s => s.StudentGender);
                    break;

                default:
                    students = students.OrderByDescending(s => s.StudentName);
                    break;
            }

            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentGender,BirthDate,Image")] Student student)
        {
            UploadImage(student);
            // if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentGender,BirthDate,Image")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            //  if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'StudentTeacherDBContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }

        private void UploadImage(Student model)
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
                model.Image = imageName;
            }
        }
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(IFormCollection form)
        {
            string name = form["StudentName"];
            List<Student> students = new List<Student>();
            students = _context.Students.Where(s => s.StudentName == name).ToList();
            return View("Index", students);
        }
    }
}
