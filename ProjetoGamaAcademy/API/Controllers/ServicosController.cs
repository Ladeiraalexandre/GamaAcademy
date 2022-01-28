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
    public class ServicosController : Controller
    {
        private readonly Context _context;

        public ServicosController(Context context)
        {
                _context = context;
        }

        // GET: api/Servicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicos>>> GetServicos()
        {
           return await _context.Servicos.ToListAsync();
        }

        // GET: api/Servicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicos>> GetServicos(int id)
        {
            var servico = await _context.Servicos.FirstOrDefaultAsync(x => x.Id == id);

            if (servico == null)
            {
                return NotFound();
            }

            return servico;
        }

        // PUT: api/Servicos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicos(int id, Servicos servicos)
        {
            if (id != servicos.Id)
            {
                return BadRequest();
            }

            _context.SetModified(servicos);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicosExists(id))
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

        // POST: api/Servicos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Servicos>> PostServicos(Servicos servicos)
        {
            _context.Servicos.Add(servicos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicos", new { id = servicos.Id }, servicos);
        }

        // DELETE: api/Servicos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Servicos>> DeleteServicos(int id)
        {
           var servicos = await _context.Servicos.FindAsync(id);
           if (servicos == null)
           {
               return NotFound();
           }

           _context.Servicos.Remove(servicos);
           await _context.SaveChangesAsync();
           return servicos;
        }

        private bool ServicosExists(int id)
        {
           return _context.Servicos.Any(e => e.Id == id);
        }
    }

}
