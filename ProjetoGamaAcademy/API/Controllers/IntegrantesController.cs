using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoGamaAcademy.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrantesController : Controller
    {
        private readonly Context _context;

        public IntegrantesController(Context context)
        {
                _context = context;
        }

        // GET: api/Integrantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Integrantes>>> GetIntegrantes()
        {
           return await _context.Integrantes.ToListAsync();
        }

        // GET: api/Integrantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Integrantes>> GetIntegrantes(int id)
        {
            var integrantes = await _context.Integrantes.FirstOrDefaultAsync(x => x.Id == id);

            if (integrantes == null)
            {
                return NotFound();
            }

            return integrantes;
        }

        // PUT: api/Integrantes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntegrantes(int id, Integrantes integrantes)
        {
            if (id != integrantes.Id)
            {
                return BadRequest();
            }

            _context.SetModified(integrantes);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntegrantesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Integrantes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Integrantes>> PostIntegrantes(Integrantes integrantes)
        {
            _context.Integrantes.Add(integrantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntegrantes", new { id = integrantes.Id }, integrantes);
        }

        // DELETE: api/Integrantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Integrantes>> DeleteIntegrantes(int id)
        {
           var integrantes = await _context.Integrantes.FindAsync(id);
           if (integrantes == null)
           {
               return NotFound();
           }

           _context.Integrantes.Remove(integrantes);
           await _context.SaveChangesAsync();
           return integrantes;
        }

        private bool IntegrantesExists(int id)
        {
           return _context.Integrantes.Any(e => e.Id == id);
        }
    }

}
