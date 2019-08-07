using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence_;
using Persistence_.data;



namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfiliadosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AfiliadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Afiliados
        [HttpGet]
        public IEnumerable<Afiliados> GetAfiliados()
        {
            return _context.Afiliados;
        }

        // GET: api/Afiliados/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAfiliados([FromRoute] byte id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var afiliados = await _context.Afiliados.FindAsync(id);

            if (afiliados == null)
            {
                return NotFound();
            }

            return Ok(afiliados);
        }

        // PUT: api/Afiliados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAfiliados([FromRoute] byte id, [FromBody] Afiliados afiliados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != afiliados.Id)
            {
                return BadRequest();
            }

            _context.Entry(afiliados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AfiliadosExists(id))
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

        // POST: api/Afiliados
        [HttpPost]
        public async Task<IActionResult> PostAfiliados([FromBody] Afiliados afiliados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Afiliados.Add(afiliados);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AfiliadosExists(afiliados.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAfiliados", new { id = afiliados.Id }, afiliados);
        }

        // DELETE: api/Afiliados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAfiliados([FromRoute] byte id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var afiliados = await _context.Afiliados.FindAsync(id);
            if (afiliados == null)
            {
                return NotFound();
            }

            _context.Afiliados.Remove(afiliados);
            await _context.SaveChangesAsync();

            return Ok(afiliados);
        }

        private bool AfiliadosExists(byte id)
        {
            return _context.Afiliados.Any(e => e.Id == id);
        }
    }
}