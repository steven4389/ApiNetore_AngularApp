using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence_;
using Persistence_.data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CreditosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Creditos
        [HttpGet]
        public IEnumerable<Creditos> GetCreditos()
        {
            return _context.Creditos;
        }

        // GET: api/Creditos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCreditos([FromRoute] byte id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creditos = await _context.Creditos.FindAsync(id);

            if (creditos == null)
            {
                return NotFound();
            }

            return Ok(creditos);
        }

        // PUT: api/Creditos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreditos([FromRoute] byte id, [FromBody] Creditos creditos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != creditos.Id)
            {
                return BadRequest();
            }

            _context.Entry(creditos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditosExists(id))
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

        // POST: api/Creditos
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostCreditos([FromBody] Creditos creditos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Creditos.Add(creditos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CreditosExists(creditos.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCreditos", new { id = creditos.Id }, creditos);
        }

        // DELETE: api/Creditos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreditos([FromRoute] byte id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var creditos = await _context.Creditos.FindAsync(id);
            if (creditos == null)
            {
                return NotFound();
            }

            _context.Creditos.Remove(creditos);
            await _context.SaveChangesAsync();

            return Ok(creditos);
        }

        private bool CreditosExists(byte id)
        {
            return _context.Creditos.Any(e => e.Id == id);
        }
    }
}