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
    public class ActionListsController : Controller
    {
        private readonly MasterContext _context;

        public ActionListsController(MasterContext context)
        {
            _context = context;
        }

        // GET: ActionLists
        public async Task<IActionResult> Index()
        {
            var masterContext = _context.ActionLists.Include(a => a.ActionBook).Include(a => a.Choise1Navigation).Include(a => a.Choise2Navigation).Include(a => a.Choise3Navigation).Include(a => a.Choise4Navigation);
            return View(await masterContext.ToListAsync());
        }

        // GET: ActionLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionLists = await _context.ActionLists
                .Include(a => a.ActionBook)
                .Include(a => a.Choise1Navigation)
                .Include(a => a.Choise2Navigation)
                .Include(a => a.Choise3Navigation)
                .Include(a => a.Choise4Navigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (actionLists == null)
            {
                return NotFound();
            }

            return View(actionLists);
        }

        // GET: ActionLists/Create
        public IActionResult Create()
        {
            ViewData["ActionBookId"] = new SelectList(_context.ActionBooks, "Id", "Name");
            ViewData["Choise1"] = new SelectList(_context.ActionLists, "Id", "Name");
            ViewData["Choise2"] = new SelectList(_context.ActionLists, "Id", "Name");
            ViewData["Choise3"] = new SelectList(_context.ActionLists, "Id", "Name");
            ViewData["Choise4"] = new SelectList(_context.ActionLists, "Id", "Name");
            return View();
        }

        // POST: ActionLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActionBookId,Name,Image1,Image2,Image3,Image4,Text1,Text2,Text3,Text4,Choise1,Choise2,Choise3,Choise4,ListType")] ActionLists actionLists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actionLists);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActionBookId"] = new SelectList(_context.ActionBooks, "Id", "Name", actionLists.ActionBookId);
            ViewData["Choise1"] = new SelectList(_context.ActionLists, "Id", "Name", actionLists.Choise1);
            ViewData["Choise2"] = new SelectList(_context.ActionLists, "Id", "Name", actionLists.Choise2);
            ViewData["Choise3"] = new SelectList(_context.ActionLists, "Id", "Name", actionLists.Choise3);
            ViewData["Choise4"] = new SelectList(_context.ActionLists, "Id", "Name", actionLists.Choise4);
            return View(actionLists);
        }

        // GET: ActionLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionLists = await _context.ActionLists.SingleOrDefaultAsync(m => m.Id == id);
            if (actionLists == null)
            {
                return NotFound();
            }
            ViewData["ActionBookId"] = new SelectList(_context.ActionBooks, "Id", "Name", actionLists.ActionBookId);
            ViewData["Choise1"] = new SelectList(_context.ActionLists, "Id", "Name", actionLists.Choise1);
            ViewData["Choise2"] = new SelectList(_context.ActionLists, "Id", "Name", actionLists.Choise2);
            ViewData["Choise3"] = new SelectList(_context.ActionLists, "Id", "Name", actionLists.Choise3);
            ViewData["Choise4"] = new SelectList(_context.ActionLists, "Id", "Name", actionLists.Choise4);
            return View(actionLists);
        }

        // POST: ActionLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActionBookId,Name,Image1,Image2,Image3,Image4,Text1,Text2,Text3,Text4,Choise1,Choise2,Choise3,Choise4,ListType")] ActionLists actionLists)
        {
            if (id != actionLists.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actionLists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActionListsExists(actionLists.Id))
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
            ViewData["ActionBookId"] = new SelectList(_context.ActionBooks, "Id", "Name", actionLists.ActionBookId);
            ViewData["Choise1"] = new SelectList(_context.ActionLists, "Id", "Name", actionLists.Choise1);
            ViewData["Choise2"] = new SelectList(_context.ActionLists, "Id", "Name", actionLists.Choise2);
            ViewData["Choise3"] = new SelectList(_context.ActionLists, "Id", "Name", actionLists.Choise3);
            ViewData["Choise4"] = new SelectList(_context.ActionLists, "Id", "Name", actionLists.Choise4);
            return View(actionLists);
        }

        // GET: ActionLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actionLists = await _context.ActionLists
                .Include(a => a.ActionBook)
                .Include(a => a.Choise1Navigation)
                .Include(a => a.Choise2Navigation)
                .Include(a => a.Choise3Navigation)
                .Include(a => a.Choise4Navigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (actionLists == null)
            {
                return NotFound();
            }

            return View(actionLists);
        }

        // POST: ActionLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actionLists = await _context.ActionLists.SingleOrDefaultAsync(m => m.Id == id);
            _context.ActionLists.Remove(actionLists);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActionListsExists(int id)
        {
            return _context.ActionLists.Any(e => e.Id == id);
        }
    }
}
