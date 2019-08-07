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
    public class AfiliadosCreditosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AfiliadosCreditosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AfiliadosCreditos
        [HttpGet]
        public IEnumerable<AfiliadosCreditos> GetAfiliadosCreditos()
        {
            return _context.AfiliadosCreditos;
        }

        // GET: api/AfiliadosCreditos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAfiliadosCreditos([FromRoute] byte id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var afiliadosCreditos = await _context.AfiliadosCreditos.FindAsync(id);

            if (afiliadosCreditos == null)
            {
                return NotFound();
            }

            return Ok(afiliadosCreditos);
        }

        // PUT: api/AfiliadosCreditos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAfiliadosCreditos([FromRoute] byte id, [FromBody] AfiliadosCreditos afiliadosCreditos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != afiliadosCreditos.CreditoId)
            {
                return BadRequest();
            }

            _context.Entry(afiliadosCreditos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AfiliadosCreditosExists(id))
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

        // POST: api/AfiliadosCreditos
        [HttpPost]
        public async Task<IActionResult> PostAfiliadosCreditos([FromBody] AfiliadosCreditos afiliadosCreditos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            _context.AfiliadosCreditos.Add(afiliadosCreditos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AfiliadosCreditosExists(afiliadosCreditos.CreditoId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAfiliadosCreditos", new { id = afiliadosCreditos.CreditoId }, afiliadosCreditos);
        }

        // DELETE: api/AfiliadosCreditos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAfiliadosCreditos([FromRoute] byte id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var afiliadosCreditos = await _context.AfiliadosCreditos.FindAsync(id);
            if (afiliadosCreditos == null)
            {
                return NotFound();
            }

            _context.AfiliadosCreditos.Remove(afiliadosCreditos);
            await _context.SaveChangesAsync();

            return Ok(afiliadosCreditos);
        }

        private bool AfiliadosCreditosExists(byte id)
        {
            return _context.AfiliadosCreditos.Any(e => e.CreditoId == id);
        }
    }
}