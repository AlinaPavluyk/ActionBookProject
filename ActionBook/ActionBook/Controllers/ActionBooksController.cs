using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActionBook.Models;

namespace ActionBook.Controllers
{
    public class ActionBooksController : Controller
    {
        private readonly MasterContext _context;

        public ActionBooksController(MasterContext context)
        {
            _context = context;
        }

        // GET: ActionBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActionBooks.ToListAsync());
        }

        // GET: ActionBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionBooks = await _context.ActionBooks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (actionBooks == null)
            {
                return NotFound();
            }

            return View(actionBooks);
        }

        // GET: ActionBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActionBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ActionBooks actionBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actionBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actionBooks);
        }

        // GET: ActionBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionBooks = await _context.ActionBooks.SingleOrDefaultAsync(m => m.Id == id);
            if (actionBooks == null)
            {
                return NotFound();
            }
            return View(actionBooks);
        }

        // POST: ActionBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ActionBooks actionBooks)
        {
            if (id != actionBooks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actionBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActionBooksExists(actionBooks.Id))
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
            return View(actionBooks);
        }

        // GET: ActionBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionBooks = await _context.ActionBooks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (actionBooks == null)
            {
                return NotFound();
            }

            return View(actionBooks);
        }

        // POST: ActionBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actionBooks = await _context.ActionBooks.SingleOrDefaultAsync(m => m.Id == id);
            _context.ActionBooks.Remove(actionBooks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActionBooksExists(int id)
        {
            return _context.ActionBooks.Any(e => e.Id == id);
        }
    }
}
