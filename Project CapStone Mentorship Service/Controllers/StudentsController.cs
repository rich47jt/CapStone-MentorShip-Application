﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_CapStone_Mentorship_Service.Data;
using Project_CapStone_Mentorship_Service.Models;

namespace Project_CapStone_Mentorship_Service.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Students.Include(s => s.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ListofAllMentors()
        {
            var ThisMentors = _context.Mentors;
            return View(ThisMentors.ToList());
        }

        public IActionResult AddtoJunction(Student student, Mentor mentor)
        {
            var form = new Sign_UpForm();
            form = _context.Forms.Where(e => e.student == student).FirstOrDefault();
            if (form.IsApptoved == true)
            {
                StudentMentor junction = new StudentMentor();
                junction.student = student;
                junction.mentor = mentor;


                _context.Add(junction);
                _context.SaveChanges();
            }
            return View();
        }

        public IActionResult MyListofMentors(int? id)
        {
            var junction = _context.Junctions.Where(j => j.student.StudentId == id).FirstOrDefault();
            var thisMentor = _context.Mentors.Where(j => j.MentorId == junction.mentor.MentorId).ToList();
            return View(thisMentor);
            ;
        }

        public IActionResult ListofLessons(int id)
        {
            var junction = _context.Junctions.Where(j => j.student.StudentId == id).FirstOrDefault();
            var lesson = _context.Lessons.Where(j => j.LessonId == junction.Lesson.LessonId).ToList();
            return View(lesson);
        }

        public IActionResult ListofActivities(int id)
        {
            var junction = _context.Junctions.Where(j => j.student.StudentId == id).FirstOrDefault();
            var activity = _context.Activities.Where(j => j.ActivityFormId == junction.activity.ActivityFormId).ToList();
            return View(activity);
        }



        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.IdentityUser)
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,FirstName,LastName,Email,ParentEmail,InstructorEmail,City,IdentityUserId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", student.IdentityUserId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", student.IdentityUserId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FirstName,LastName,Email,ParentEmail,InstructorEmail,City,IdentityUserId")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", student.IdentityUserId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.IdentityUser)
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
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
