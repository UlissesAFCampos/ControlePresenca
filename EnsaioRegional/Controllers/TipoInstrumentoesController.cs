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
    public class TipoInstrumentoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoInstrumentoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoInstrumentoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.TipoInstrumento.ToListAsync());
        }

        // GET: TipoInstrumentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoInstrumento == null)
            {
                return NotFound();
            }

            var tipoInstrumento = await _context.TipoInstrumento
                .FirstOrDefaultAsync(m => m.IdTipoInstrumento == id);
            if (tipoInstrumento == null)
            {
                return NotFound();
            }

            return View(tipoInstrumento);
        }

        // GET: TipoInstrumentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoInstrumentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoInstrumento,Descricao")] TipoInstrumento tipoInstrumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoInstrumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoInstrumento);
        }

        // GET: TipoInstrumentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoInstrumento == null)
            {
                return NotFound();
            }

            var tipoInstrumento = await _context.TipoInstrumento.FindAsync(id);
            if (tipoInstrumento == null)
            {
                return NotFound();
            }
            return View(tipoInstrumento);
        }

        // POST: TipoInstrumentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoInstrumento,Descricao")] TipoInstrumento tipoInstrumento)
        {
            if (id != tipoInstrumento.IdTipoInstrumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoInstrumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoInstrumentoExists(tipoInstrumento.IdTipoInstrumento))
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
            return View(tipoInstrumento);
        }

        // GET: TipoInstrumentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoInstrumento == null)
            {
                return NotFound();
            }

            var tipoInstrumento = await _context.TipoInstrumento
                .FirstOrDefaultAsync(m => m.IdTipoInstrumento == id);
            if (tipoInstrumento == null)
            {
                return NotFound();
            }

            return View(tipoInstrumento);
        }

        // POST: TipoInstrumentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoInstrumento == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TipoInstrumento'  is null.");
            }
            var tipoInstrumento = await _context.TipoInstrumento.FindAsync(id);
            if (tipoInstrumento != null)
            {
                _context.TipoInstrumento.Remove(tipoInstrumento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoInstrumentoExists(int id)
        {
          return _context.TipoInstrumento.Any(e => e.IdTipoInstrumento == id);
        }
    }
}
