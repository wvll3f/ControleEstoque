using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Estoque.Data;
using Estoque.Models;

namespace Estoque
{
    public class categoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public categoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: categoria
        public async Task<IActionResult> Index()
        {
              return _context.categorias != null ? 
                          View(await _context.categorias.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.categorias'  is null.");
        }

        // GET: categoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.categorias == null)
            {
                return NotFound();
            }

            var categoria = await _context.categorias
                .FirstOrDefaultAsync(m => m.idCategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: categoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: categoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCategoria,nomeCategoria")] categoria categoria)
        {
            
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: categoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.categorias == null)
            {
                return NotFound();
            }

            var categoria = await _context.categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: categoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCategoria,nomeCategoria")] categoria categoria)
        {
            if (id != categoria.idCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!categoriaExists(categoria.idCategoria))
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
            return View(categoria);
        }

        // GET: categoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.categorias == null)
            {
                return NotFound();
            }

            var categoria = await _context.categorias
                .FirstOrDefaultAsync(m => m.idCategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.categorias == null)
            {
                return Problem("Entity set 'ApplicationDbContext.categorias'  is null.");
            }
            var categoria = await _context.categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.categorias.Remove(categoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool categoriaExists(int id)
        {
          return (_context.categorias?.Any(e => e.idCategoria == id)).GetValueOrDefault();
        }
    }
}
