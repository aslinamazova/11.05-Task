﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.DAL;
using PurpleBuzz.Models;

namespace PurpleBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamMembersController : Controller
    {
        private readonly AppDbContext _context;

        public TeamMembersController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<TeamMember> members = await _context.TeamMembers.ToListAsync();
            return View(members);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamMember member)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _context.TeamMembers.AddAsync(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            TeamMember member =await _context.TeamMembers.FindAsync(id);
            if (member == null) return NotFound();
            return View(member);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TeamMember member)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            TeamMember result=await _context.TeamMembers.FirstOrDefaultAsync(t=>t.Id==member.Id);
            if (result is  null)
            {
                TempData["Exists"] = "Bu Member bazada yoxdur";
                return RedirectToAction(nameof(Index));
            }
            result.FullName= member.FullName;
            result.Profession=member.Profession;
            result.ImagePath= member.ImagePath;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            TeamMember? member = _context.TeamMembers.Find(id);
            if (member == null)
            {
                return NotFound();
            }
            _context.TeamMembers.Remove(member);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
