using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EnsaioRegional.Data;
using EnsaioRegional.Models;

namespace EnsaioRegional.Controllers
{
    public class InstrumentoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstrumentoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Instrumentoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Instrumento.Include(i => i.TipoInstrumento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Instrumentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Instrumento == null)
            {
                return NotFound();
            }

            var instrumento = await _context.Instrumento
                .Include(i => i.TipoInstrumento)
                .FirstOrDefaultAsync(m => m.IdInstrumento == id);
            if (instrumento == null)
            {
                return NotFound();
            }

            return View(instrumento);
        }

        // GET: Instrumentoes/Create
        public IActionResult Create()
        {
            ViewData["IdTipoInstrumento"] = new SelectList(_context.TipoInstrumento, "IdTipoInstrumento", "Descricao");
            return View();
        }

        // POST: Instrumentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInstrumento,NomeInstrumento,IdTipoInstrumento")] Instrumento instrumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instrumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoInstrumento"] = new SelectList(_context.TipoInstrumento, "IdTipoInstrumento", "Descricao", instrumento.IdTipoInstrumento);
            return View(instrumento);
        }

        // GET: Instrumentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Instrumento == null)
            {
                return NotFound();
            }

            var instrumento = await _context.Instrumento.FindAsync(id);
            if (instrumento == null)
            {
                return NotFound();
            }
            ViewData["IdTipoInstrumento"] = new SelectList(_context.TipoInstrumento, "IdTipoInstrumento", "Descricao", instrumento.IdTipoInstrumento);
            return View(instrumento);
        }

        // POST: Instrumentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInstrumento,NomeInstrumento,IdTipoInstrumento")] Instrumento instrumento)
        {
            if (id != instrumento.IdInstrumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrumentoExists(instrumento.IdInstrumento))
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
            ViewData["IdTipoInstrumento"] = new SelectList(_context.TipoInstrumento, "IdTipoInstrumento", "Descricao", instrumento.IdTipoInstrumento);
            return View(instrumento);
        }

        // GET: Instrumentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Instrumento == null)
            {
                return NotFound();
            }

            var instrumento = await _context.Instrumento
                .Include(i => i.TipoInstrumento)
                .FirstOrDefaultAsync(m => m.IdInstrumento == id);
            if (instrumento == null)
            {
                return NotFound();
            }

            return View(instrumento);
        }

        // POST: Instrumentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Instrumento == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Instrumento'  is null.");
            }
            var instrumento = await _context.Instrumento.FindAsync(id);
            if (instrumento != null)
            {
                _context.Instrumento.Remove(instrumento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrumentoExists(int id)
        {
          return _context.Instrumento.Any(e => e.IdInstrumento == id);
        }
    }
}
