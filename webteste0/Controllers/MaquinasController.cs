using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webteste0.Data;
using webteste0.Models;

namespace webteste0.Controllers
{
    public class MaquinasController : Controller
    {
        private readonly dbContext _context;

        public MaquinasController(dbContext context)
        {
            _context = context;
        }

        // GET: Maquinas
        public async Task<IActionResult> Index()
        {
              return _context.Maquina != null ? 
                          View(await _context.Maquina.ToListAsync()) :
                          Problem("Entity set 'dbContext.Maquina'  is null.");
        }

        // GET: Maquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Maquina == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina
                .FirstOrDefaultAsync(m => m.maquina_id == id);
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // GET: Maquinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Maquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maquina_id,nome_maquina,descricao")] Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maquina);
        }

        // GET: Maquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Maquina == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina.FindAsync(id);
            if (maquina == null)
            {
                return NotFound();
            }
            return View(maquina);
        }

        // POST: Maquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("maquina_id,nome_maquina,descricao")] Maquina maquina)
        {
            if (id != maquina.maquina_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maquina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaquinaExists(maquina.maquina_id))
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
            return View(maquina);
        }

        // GET: Maquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Maquina == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina
                .FirstOrDefaultAsync(m => m.maquina_id == id);
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // POST: Maquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Maquina == null)
            {
                return Problem("Entity set 'dbContext.Maquina'  is null.");
            }
            var maquina = await _context.Maquina.FindAsync(id);
            if (maquina != null)
            {
                _context.Maquina.Remove(maquina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaquinaExists(int id)
        {
          return (_context.Maquina?.Any(e => e.maquina_id == id)).GetValueOrDefault();
        }
    }
}
