using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CheatsheetWebApp.Data;
using CheatsheetWebApp.Models;

namespace CheatsheetWebApp.Controllers
{
    public class CheatsheetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheatsheetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cheatsheets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cheatsheet.ToListAsync());
        }

        // GET: Cheatsheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheatsheet = await _context.Cheatsheet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cheatsheet == null)
            {
                return NotFound();
            }

            return View(cheatsheet);
        }

        // GET: Cheatsheets/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cheatsheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer")] Cheatsheet cheatsheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cheatsheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cheatsheet);
        }

        // GET: Cheatsheets/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheatsheet = await _context.Cheatsheet.FindAsync(id);
            if (cheatsheet == null)
            {
                return NotFound();
            }
            return View(cheatsheet);
        }

        // POST: Cheatsheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer")] Cheatsheet cheatsheet)
        {
            if (id != cheatsheet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cheatsheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheatsheetExists(cheatsheet.Id))
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
            return View(cheatsheet);
        }

        // GET: Cheatsheets/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cheatsheet = await _context.Cheatsheet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cheatsheet == null)
            {
                return NotFound();
            }

            return View(cheatsheet);
        }

        // POST: Cheatsheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cheatsheet = await _context.Cheatsheet.FindAsync(id);
            if (cheatsheet != null)
            {
                _context.Cheatsheet.Remove(cheatsheet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheatsheetExists(int id)
        {
            return _context.Cheatsheet.Any(e => e.Id == id);
        }
    }
}
