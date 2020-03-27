using System;
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
    public class LessonActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LessonActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LessonActivities
        public async Task<IActionResult> Index()
        {
            return View(await _context.LessonActivities.ToListAsync());
        }

        // GET: LessonActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonActivity = await _context.LessonActivities
                .FirstOrDefaultAsync(m => m.LessonActivityId == id);
            if (lessonActivity == null)
            {
                return NotFound();
            }

            return View(lessonActivity);
        }

        // GET: LessonActivities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LessonActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonActivityId,StartTime,EndTime,Description,Type")] LessonActivity lessonActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lessonActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lessonActivity);
        }

        // GET: LessonActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonActivity = await _context.LessonActivities.FindAsync(id);
            if (lessonActivity == null)
            {
                return NotFound();
            }
            return View(lessonActivity);
        }

        // POST: LessonActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonActivityId,StartTime,EndTime,Description,Type")] LessonActivity lessonActivity)
        {
            if (id != lessonActivity.LessonActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lessonActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonActivityExists(lessonActivity.LessonActivityId))
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
            return View(lessonActivity);
        }

        // GET: LessonActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessonActivity = await _context.LessonActivities
                .FirstOrDefaultAsync(m => m.LessonActivityId == id);
            if (lessonActivity == null)
            {
                return NotFound();
            }

            return View(lessonActivity);
        }

        // POST: LessonActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lessonActivity = await _context.LessonActivities.FindAsync(id);
            _context.LessonActivities.Remove(lessonActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonActivityExists(int id)
        {
            return _context.LessonActivities.Any(e => e.LessonActivityId == id);
        }
    }
}
