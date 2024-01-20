using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectionCommission.Helpers;
using ElectionCommission.Models;

namespace ElectionCommission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommissionersController : ControllerBase
    {
        private readonly DataContext _context;

        public CommissionersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Commissioners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commissioner>>> GetOfficials()
        {
            return await _context.Officials.ToListAsync();
        }

        // GET: api/Commissioners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commissioner>> GetCommissioner(string id)
        {
            var commissioner = await _context.Officials.FindAsync(id);

            if (commissioner == null)
            {
                return NotFound();
            }

            return commissioner;
        }

        // PUT: api/Commissioners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommissioner(string id, Commissioner commissioner)
        {
            if (id != commissioner.Id)
            {
                return BadRequest();
            }

            _context.Entry(commissioner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommissionerExists(id))
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

        // POST: api/Commissioners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Commissioner>> PostCommissioner(Commissioner commissioner)
        {
            _context.Officials.Add(commissioner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommissionerExists(commissioner.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCommissioner", new { id = commissioner.Id }, commissioner);
        }

        // DELETE: api/Commissioners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommissioner(string id)
        {
            var commissioner = await _context.Officials.FindAsync(id);
            if (commissioner == null)
            {
                return NotFound();
            }

            _context.Officials.Remove(commissioner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommissionerExists(string id)
        {
            return _context.Officials.Any(e => e.Id == id);
        }
    }
}
