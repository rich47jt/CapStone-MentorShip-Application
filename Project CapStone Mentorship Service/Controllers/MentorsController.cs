using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_CapStone_Mentorship_Service.Data;
using Project_CapStone_Mentorship_Service.Models;
using Project_CapStone_Mentorship_Service.Views;

namespace Project_CapStone_Mentorship_Service.Controllers
{
    public class MentorsController : Controller 
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public MentorsController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
        }

        // GET: Mentors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Mentors.Include(m => m.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ListofStudnent(int? id)
        {
            var mentor = _context.Mentors.Where(m => m.MentorId == id).FirstOrDefault();
            var junction = _context.StudentMentors.Where(m => m.mentor.MentorId == mentor.MentorId).FirstOrDefault();
            var students = _context.Students.Where(s => s.StudentId == junction.StudentId).ToList();
            return View(students);
        }

        // GET: Mentors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentors
                .Include(m => m.IdentityUser)
                .FirstOrDefaultAsync(m => m.MentorId == id);
            if (mentor == null)
            {
                return NotFound();
            }

            return View(mentor);
        }

        // GET: Mentors/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Mentors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("MentorId,First_Name,Last_Name,Email,City,Subject_Specialty,Description,IdentityUserId,ApplicantFromId")] Mentor mentor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(mentor);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", mentor.IdentityUserId);
        //    return View(mentor);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (MentorCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniquefilename = null;
                if(model.Photo!= null)
                {
                 string uploadfolder = Path.Combine(hostingEnvironment.WebRootPath, "imgaes");
                 uniquefilename = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filepath = Path.Combine(uploadfolder, uniquefilename);
                    model.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
                }

                Mentor mentor = new Mentor
                {
                    First_Name = model.First_Name,
                    Last_Name = model.Last_Name,
                    PhotoPath = uniquefilename
                };
                _context.Add(mentor);
                return RedirectToAction("details", new { id = mentor.MentorId });
            }
           return View();
        }

        // GET: Mentors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentors.FindAsync(id);
            if (mentor == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", mentor.IdentityUserId);
            return View(mentor);
        }

        // POST: Mentors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MentorId,First_Name,Last_Name,Email,City,Subject_Specialty,Description,IdentityUserId,ApplicantFromId")] Mentor mentor)
        {
            if (id != mentor.MentorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mentor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MentorExists(mentor.MentorId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", mentor.IdentityUserId);
            return View(mentor);
        }

        // GET: Mentors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentors
                .Include(m => m.IdentityUser)
                .FirstOrDefaultAsync(m => m.MentorId == id);
            if (mentor == null)
            {
                return NotFound();
            }

            return View(mentor);
        }

        // POST: Mentors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mentor = await _context.Mentors.FindAsync(id);
            _context.Mentors.Remove(mentor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MentorExists(int id)
        {
            return _context.Mentors.Any(e => e.MentorId == id);
        }
    }
}
