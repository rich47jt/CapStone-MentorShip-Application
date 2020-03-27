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
    public class Sign_UpFormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Sign_UpFormController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sign_UpForm
        public async Task<IActionResult> Index()
        {
            return View(await _context.Forms.ToListAsync());
        }

        // GET: Sign_UpForm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sign_UpForm = await _context.Forms
                .FirstOrDefaultAsync(m => m.FormId == id);
            if (sign_UpForm == null)
            {
                return NotFound();
            }

            return View(sign_UpForm);
        }

        // GET: Sign_UpForm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sign_UpForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormId,Studnet_Name,Need_for_Academic_Help,Mentor_Name,IsTutor")] Sign_UpForm sign_UpForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sign_UpForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sign_UpForm);
        }

        // GET: Sign_UpForm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sign_UpForm = await _context.Forms.FindAsync(id);
            if (sign_UpForm == null)
            {
                return NotFound();
            }
            return View(sign_UpForm);
        }

        // POST: Sign_UpForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormId,Studnet_Name,Need_for_Academic_Help,Mentor_Name,IsTutor")] Sign_UpForm sign_UpForm)
        {
            if (id != sign_UpForm.FormId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sign_UpForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sign_UpFormExists(sign_UpForm.FormId))
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
            return View(sign_UpForm);
        }

        // GET: Sign_UpForm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sign_UpForm = await _context.Forms
                .FirstOrDefaultAsync(m => m.FormId == id);
            if (sign_UpForm == null)
            {
                return NotFound();
            }

            return View(sign_UpForm);
        }

        // POST: Sign_UpForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sign_UpForm = await _context.Forms.FindAsync(id);
            _context.Forms.Remove(sign_UpForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Sign_UpFormExists(int id)
        {
            return _context.Forms.Any(e => e.FormId == id);
        }
    }
}
