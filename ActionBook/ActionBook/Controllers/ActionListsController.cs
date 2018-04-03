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
        private readonly ActionListContext _context;

        public ActionListsController(ActionListContext context)
        {
            _context = context;
        }

        // GET: ActionLists
        public async Task<IActionResult> Index()
        {
            var actionListContext = _context.ActionLists.Include(a => a.ActionBook);
            return View(await actionListContext.ToListAsync());
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
            ViewData["ActionBookId"] = new SelectList(_context.Set<ActionBooks>(), "Id", "Id");
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
            ViewData["ActionBookId"] = new SelectList(_context.Set<ActionBooks>(), "Id", "Id", actionLists.ActionBookId);
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
            ViewData["ActionBookId"] = new SelectList(_context.Set<ActionBooks>(), "Id", "Id", actionLists.ActionBookId);
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
            ViewData["ActionBookId"] = new SelectList(_context.Set<ActionBooks>(), "Id", "Id", actionLists.ActionBookId);
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
