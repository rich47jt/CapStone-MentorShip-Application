using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicationDbContext = _context.Students.Where(s => s.IdentityUserId == userId);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult List_of_All_Mentors()
        {
            var mentors = _context.Mentors;
            return View(mentors.ToList());
        }

        public IActionResult Add_to_StudentMentor(int? id)
        {
            var student = _context.Students.Where(s => s.StudentId == id).FirstOrDefault();
            var sign_in = _context.Forms.Where(f => f.FormId == student.Sign_FormId).FirstOrDefault();
            var mentor = _context.Mentors.Where(m => m.First_Name == sign_in.Mentor_Name).FirstOrDefault();
            var junctions = _context.StudentMentors.Where(sm => sm.mentor == mentor && sm.student == student).FirstOrDefault();

            if (sign_in.IsTutor == true)
            {
                if (sign_in.Mentor_Name == mentor.First_Name)
                _context.Add(junctions);
                _context.SaveChanges();
            }
            return View(mentor);
           
        }

        public IActionResult List_of_My_Mentors(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var student = _context.Students.Where(s => s.StudentId == id && s.IdentityUserId == userId).FirstOrDefault();
            var junction = _context.StudentMentors.Where(sm => sm.student.StudentId == student.StudentId).FirstOrDefault();
            var mentor = _context.Mentors.Where(m => m.MentorId == junction.MentorId).ToList();
            return View(mentor);
        }

        public IActionResult Add_Activity_to_Activty(int? id)
        {
            var student = _context.StudentMentors.Where(sm => sm.student.StudentId == id).FirstOrDefault();
            var activity = _context.LessonActivities.Where(l => l.Student_Name == student.student.First_Name).FirstOrDefault();
            var junction = _context.StudentMentorLessonActivities.Where(sl => sl.studentMentor == student && sl.lessonActivity == activity).FirstOrDefault();
            var sign_in = _context.Forms.Where(f => f.FormId == student.student.Form.FormId).FirstOrDefault();

            if (sign_in.IsTutor == true)
            {
                if(sign_in.Studnet_Name == student.student.First_Name)
                {
                    _context.Add(junction);
                    _context.SaveChanges();
                }
            }


            return View(activity);
        }

        public IActionResult Search_By_Location(int? id)
        {
            var students = _context.Students.Where(s => s.StudentId == id).FirstOrDefault();
            var mentor = _context.Mentors.Include(m => m.City).FirstOrDefault();

            if (mentor.City == students.City)
            {
                return View(mentor);
            }
            return View();
            
            
        }


        public IActionResult List_of_My_LessonActivities(int? id)
        {
            var studnet = _context.Students.Where(s => s.StudentId == id).FirstOrDefault();
            var junction = _context.StudentMentorLessonActivities.Where(l => l.studentMentor.student == studnet).FirstOrDefault();
            var lesson = _context.LessonActivities.Where(l => l.LessonActivityId == junction.lessonActivity.LessonActivityId).ToList();
            return View(lesson);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,First_Name,Last_Name,Email,Parent_Email,Instructor_Email,City,IdentityUserId,Sign_FormId")] Student student)
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,First_Name,Last_Name,Email,Parent_Email,Instructor_Email,City,IdentityUserId,Sign_FormId")] Student student)
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
