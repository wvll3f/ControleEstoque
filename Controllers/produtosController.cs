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
    public class produtosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public produtosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: produtos
        public async Task<IActionResult> Index()
        {
            return _context.produtos != null ?
                        View(await _context.produtos.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.produtos'  is null.");
        }

        // GET: produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.produtos == null)
            {
                return NotFound();
            }

            var produtos = await _context.produtos
                .FirstOrDefaultAsync(m => m.idProdutos == id);
            if (produtos == null)
            {
                return NotFound();
            }

            return View(produtos);
        }

        // GET: produtos/Create
        public IActionResult Create()
        {
            produtos model = new produtos();
            model.categoria = _context.categorias.ToList();

            return View(model);
        }

        // POST: produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProdutos,nomeProduto,valorProduto,valorCompra,valorVenda,dataProduto,categoria")] produtos produtos)
        {

            _context.Add(produtos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.produtos == null)
            {
                return NotFound();
            }

            var produtos = await _context.produtos.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }
            return View(produtos);
        }

        // POST: produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProdutos,nomeProduto,valorProduto,valorCompra,valorVenda,dataProduto")] produtos produtos)
        {
            if (id != produtos.idProdutos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!produtosExists(produtos.idProdutos))
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
            return View(produtos);
        }

        // GET: produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.produtos == null)
            {
                return NotFound();
            }

            var produtos = await _context.produtos
                .FirstOrDefaultAsync(m => m.idProdutos == id);
            if (produtos == null)
            {
                return NotFound();
            }

            return View(produtos);
        }

        // POST: produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.produtos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.produtos'  is null.");
            }
            var produtos = await _context.produtos.FindAsync(id);
            if (produtos != null)
            {
                _context.produtos.Remove(produtos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool produtosExists(int id)
        {
            return (_context.produtos?.Any(e => e.idProdutos == id)).GetValueOrDefault();
        }
    }
}
