using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.DAL;
using PurpleBuzz.Models;


namespace PurpleBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecentWorksController : Controller
    {
        private readonly AppDbContext _context;

        public RecentWorksController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<RecentWork> works = await _context.RecentWorks.ToListAsync();
            return View(works);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecentWork work)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _context.RecentWorks.AddAsync(work);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            RecentWork work = await _context.RecentWorks.FindAsync(id);
            if (work == null) return NotFound();
            return View(work);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RecentWork work)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            RecentWork result = await _context.RecentWorks.FirstOrDefaultAsync(t => t.Id == work.Id);
            if (result is null)
            {
                TempData["Exists"] = "Bu Member bazada yoxdur";
                return RedirectToAction(nameof(Index));
            }
            result.Name = work.Name;
            result.Description = work.Description;
            result.ImagePath = work.ImagePath;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            RecentWork? work = _context.RecentWorks.Find(id);
            if (work == null)
            {
                return NotFound();
            }
            _context.RecentWorks.Remove(work);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
