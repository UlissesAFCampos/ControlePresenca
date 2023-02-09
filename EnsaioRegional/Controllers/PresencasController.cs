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
    public class PresencasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PresencasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Presencas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Presenca.Include(p => p.DataEnsaio).Include(p => p.Musico);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Presencas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Presenca == null)
            {
                return NotFound();
            }

            var presenca = await _context.Presenca
                .Include(p => p.DataEnsaio)
                .Include(p => p.Musico)
                .FirstOrDefaultAsync(m => m.IdPresenca == id);
            if (presenca == null)
            {
                return NotFound();
            }

            return View(presenca);
        }

        // GET: Presencas/Create
        public IActionResult Create()
        {
            ViewData["IdData"] = new SelectList(_context.DataEnsaio, "IdData", "CidadeRealizacao");
            ViewData["IdMusico"] = new SelectList(_context.Musico, "IdMusico", "NomeMusico");
            return View();
        }

        // POST: Presencas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPresenca,IdData,IdMusico")] Presenca presenca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presenca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdData"] = new SelectList(_context.DataEnsaio, "IdData", "CidadeRealizacao", presenca.IdData);
            ViewData["IdMusico"] = new SelectList(_context.Musico, "IdMusico", "NomeMusico", presenca.IdMusico);
            return View(presenca);
        }

        // GET: Presencas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Presenca == null)
            {
                return NotFound();
            }

            var presenca = await _context.Presenca.FindAsync(id);
            if (presenca == null)
            {
                return NotFound();
            }
            ViewData["IdData"] = new SelectList(_context.DataEnsaio, "IdData", "CidadeRealizacao", presenca.IdData);
            ViewData["IdMusico"] = new SelectList(_context.Musico, "IdMusico", "NomeMusico", presenca.IdMusico);
            return View(presenca);
        }

        // POST: Presencas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPresenca,IdData,IdMusico")] Presenca presenca)
        {
            if (id != presenca.IdPresenca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presenca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresencaExists(presenca.IdPresenca))
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
            ViewData["IdData"] = new SelectList(_context.DataEnsaio, "IdData", "CidadeRealizacao", presenca.IdData);
            ViewData["IdMusico"] = new SelectList(_context.Musico, "IdMusico", "NomeMusico", presenca.IdMusico);
            return View(presenca);
        }

        // GET: Presencas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Presenca == null)
            {
                return NotFound();
            }

            var presenca = await _context.Presenca
                .Include(p => p.DataEnsaio)
                .Include(p => p.Musico)
                .FirstOrDefaultAsync(m => m.IdPresenca == id);
            if (presenca == null)
            {
                return NotFound();
            }

            return View(presenca);
        }

        // POST: Presencas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Presenca == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Presenca'  is null.");
            }
            var presenca = await _context.Presenca.FindAsync(id);
            if (presenca != null)
            {
                _context.Presenca.Remove(presenca);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresencaExists(int id)
        {
          return _context.Presenca.Any(e => e.IdPresenca == id);
        }
    }
}
