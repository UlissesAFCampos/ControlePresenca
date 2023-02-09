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
    public class MusicoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MusicoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Musicoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Musico.Include(m => m.Igreja).Include(m => m.Instrumento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Musicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Musico == null)
            {
                return NotFound();
            }

            var musico = await _context.Musico
                .Include(m => m.Igreja)
                .Include(m => m.Instrumento)
                .FirstOrDefaultAsync(m => m.IdMusico == id);
            if (musico == null)
            {
                return NotFound();
            }

            return View(musico);
        }

        // GET: Musicoes/Create
        public IActionResult Create()
        {
            ViewData["IdIgreja"] = new SelectList(_context.Igreja, "IdIgreja", "Cidade");
            ViewData["IdInstrumento"] = new SelectList(_context.Instrumento, "IdInstrumento", "NomeInstrumento");
            return View();
        }

        // POST: Musicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMusico,NomeMusico,IdTipoMusico,IdTipoFormacao,IdInstrumento,IdIgreja")] Musico musico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdIgreja"] = new SelectList(_context.Igreja, "IdIgreja", "Cidade", musico.IdIgreja);
            ViewData["IdInstrumento"] = new SelectList(_context.Instrumento, "IdInstrumento", "NomeInstrumento", musico.IdInstrumento);
            return View(musico);
        }

        // GET: Musicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Musico == null)
            {
                return NotFound();
            }

            var musico = await _context.Musico.FindAsync(id);
            if (musico == null)
            {
                return NotFound();
            }
            ViewData["IdIgreja"] = new SelectList(_context.Igreja, "IdIgreja", "Cidade", musico.IdIgreja);
            ViewData["IdInstrumento"] = new SelectList(_context.Instrumento, "IdInstrumento", "NomeInstrumento", musico.IdInstrumento);
            return View(musico);
        }

        // POST: Musicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMusico,NomeMusico,IdTipoMusico,IdTipoFormacao,IdInstrumento,IdIgreja")] Musico musico)
        {
            if (id != musico.IdMusico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicoExists(musico.IdMusico))
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
            ViewData["IdIgreja"] = new SelectList(_context.Igreja, "IdIgreja", "Cidade", musico.IdIgreja);
            ViewData["IdInstrumento"] = new SelectList(_context.Instrumento, "IdInstrumento", "NomeInstrumento", musico.IdInstrumento);
            return View(musico);
        }

        // GET: Musicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Musico == null)
            {
                return NotFound();
            }

            var musico = await _context.Musico
                .Include(m => m.Igreja)
                .Include(m => m.Instrumento)
                .FirstOrDefaultAsync(m => m.IdMusico == id);
            if (musico == null)
            {
                return NotFound();
            }

            return View(musico);
        }

        // POST: Musicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Musico == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Musico'  is null.");
            }
            var musico = await _context.Musico.FindAsync(id);
            if (musico != null)
            {
                _context.Musico.Remove(musico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicoExists(int id)
        {
          return _context.Musico.Any(e => e.IdMusico == id);
        }
    }
}
