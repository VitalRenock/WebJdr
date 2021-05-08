using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebJdr.DAL;
using WebJdr.Models;

namespace WebJdr.Controllers
{
    public class SequenceController : Controller
    {
        private readonly DatabaseContext _context;

        public SequenceController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Sequence
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sequences.ToListAsync());
        }

        // GET: Sequence/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sequence = await _context.Sequences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sequence == null)
            {
                return NotFound();
            }

            return View(sequence);
        }

        // GET: Sequence/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sequence/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,HierchicalLevel,Title,Paragraph,ChildsId")] Sequence sequence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sequence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sequence);
        }

        // GET: Sequence/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sequence = await _context.Sequences.FindAsync(id);
            if (sequence == null)
            {
                return NotFound();
            }
            return View(sequence);
        }

        // POST: Sequence/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParentId,HierchicalLevel,Title,Paragraph,ChildsId")] Sequence sequence)
        {
            if (id != sequence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sequence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SequenceExists(sequence.Id))
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
            return View(sequence);
        }

        // GET: Sequence/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sequence = await _context.Sequences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sequence == null)
            {
                return NotFound();
            }

            return View(sequence);
        }

        // POST: Sequence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sequence = await _context.Sequences.FindAsync(id);
            _context.Sequences.Remove(sequence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SequenceExists(int id)
        {
            return _context.Sequences.Any(e => e.Id == id);
        }
    }
}
