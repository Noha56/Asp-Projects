using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeacherStudentApp.Data;
using TeacherStudentApp.Models;

namespace TeacherStudentApp.Controllers
{
    public class TeacherStudentsController : Controller
    {
        private readonly TeacherStudentDBContext _context;

        public TeacherStudentsController(TeacherStudentDBContext context)
        {
            _context = context;
        }

        // GET: TeacherStudents
        public async Task<IActionResult> Index()
        {
            var teacherStudentDBContext = _context.TeacherStudents.Include(t => t.Teacher);
            return View(await teacherStudentDBContext.ToListAsync());
        }

        // GET: TeacherStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TeacherStudents == null)
            {
                return NotFound();
            }

            var teacherStudent = await _context.TeacherStudents
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teacherStudent == null)
            {
                return NotFound();
            }

            return View(teacherStudent);
        }

        // GET: TeacherStudents/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TId", "TId");
            return View();
        }

        // POST: TeacherStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,StudentrId")] TeacherStudent teacherStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TId", "TId", teacherStudent.TeacherId);
            return View(teacherStudent);
        }

        // GET: TeacherStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TeacherStudents == null)
            {
                return NotFound();
            }

            var teacherStudent = await _context.TeacherStudents.FindAsync(id);
            if (teacherStudent == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TId", "TId", teacherStudent.TeacherId);
            return View(teacherStudent);
        }

        // POST: TeacherStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,StudentrId")] TeacherStudent teacherStudent)
        {
            if (id != teacherStudent.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherStudentExists(teacherStudent.TeacherId))
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
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "TId", "TId", teacherStudent.TeacherId);
            return View(teacherStudent);
        }

        // GET: TeacherStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TeacherStudents == null)
            {
                return NotFound();
            }

            var teacherStudent = await _context.TeacherStudents
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teacherStudent == null)
            {
                return NotFound();
            }

            return View(teacherStudent);
        }

        // POST: TeacherStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TeacherStudents == null)
            {
                return Problem("Entity set 'TeacherStudentDBContext.TeacherStudents'  is null.");
            }
            var teacherStudent = await _context.TeacherStudents.FindAsync(id);
            if (teacherStudent != null)
            {
                _context.TeacherStudents.Remove(teacherStudent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherStudentExists(int id)
        {
          return _context.TeacherStudents.Any(e => e.TeacherId == id);
        }
    }
}
