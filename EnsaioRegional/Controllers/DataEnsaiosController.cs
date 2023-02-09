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
    public class DataEnsaiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataEnsaiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DataEnsaios
        public async Task<IActionResult> Index()
        {
              return View(await _context.DataEnsaio.ToListAsync());
        }

        // GET: DataEnsaios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DataEnsaio == null)
            {
                return NotFound();
            }

            var dataEnsaio = await _context.DataEnsaio
                .FirstOrDefaultAsync(m => m.IdData == id);
            if (dataEnsaio == null)
            {
                return NotFound();
            }

            return View(dataEnsaio);
        }

        // GET: DataEnsaios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataEnsaios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdData,Data,DescricaoEnsaio,CidadeRealizacao")] DataEnsaio dataEnsaio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataEnsaio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataEnsaio);
        }

        // GET: DataEnsaios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DataEnsaio == null)
            {
                return NotFound();
            }

            var dataEnsaio = await _context.DataEnsaio.FindAsync(id);
            if (dataEnsaio == null)
            {
                return NotFound();
            }
            return View(dataEnsaio);
        }

        // POST: DataEnsaios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdData,Data,DescricaoEnsaio,CidadeRealizacao")] DataEnsaio dataEnsaio)
        {
            if (id != dataEnsaio.IdData)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataEnsaio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataEnsaioExists(dataEnsaio.IdData))
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
            return View(dataEnsaio);
        }

        // GET: DataEnsaios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DataEnsaio == null)
            {
                return NotFound();
            }

            var dataEnsaio = await _context.DataEnsaio
                .FirstOrDefaultAsync(m => m.IdData == id);
            if (dataEnsaio == null)
            {
                return NotFound();
            }

            return View(dataEnsaio);
        }

        // POST: DataEnsaios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DataEnsaio == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DataEnsaio'  is null.");
            }
            var dataEnsaio = await _context.DataEnsaio.FindAsync(id);
            if (dataEnsaio != null)
            {
                _context.DataEnsaio.Remove(dataEnsaio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataEnsaioExists(int id)
        {
          return _context.DataEnsaio.Any(e => e.IdData == id);
        }
    }
}
