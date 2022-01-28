using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoGamaAcademy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ProjetoGamaAcademy.Controllers
{
    public class IntegrantesController : Controller
    {
        private readonly Context _context;

        public IntegrantesController(Context context)
        {
            _context = context;
        }

        // GET: Integrantes
        public async Task<IActionResult> Index()
        {
            var context = _context.Integrantes;
            return View(await context.ToListAsync());
        }

        // GET: Integrantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var integrantes = await _context.Integrantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (integrantes == null)
            {
                return NotFound();
            }

            return View(integrantes);
        }

        // GET: Integrantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Integrantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Integrantes integrantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(integrantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(integrantes);
        }

        // GET: Integrantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var integrantes = await _context.Integrantes.FindAsync(id);
            if (integrantes == null)
            {
                return NotFound();
            }
            
            return View(integrantes);
        }

        // POST: Integrantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Integrantes integrantes)
        {
            if (id != integrantes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(integrantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntegrantesExists(integrantes.Id))
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
            
            return View(integrantes);
        }

        // GET: Integrantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var integrantes = await _context.Integrantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (integrantes == null)
            {
                return NotFound();
            }

            return View(integrantes);
        }

        // POST: Integrantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var integrantes = await _context.Integrantes.FindAsync(id);
            _context.Integrantes.Remove(integrantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntegrantesExists(int id)
        {
            return _context.Integrantes.Any(e => e.Id == id);
        }
    }
}
