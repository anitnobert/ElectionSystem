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
    public class StateDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public StateDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/StateDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateDetail>>> GetStates()
        {
            return await _context.States.ToListAsync();
        }

        // GET: api/StateDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StateDetail>> GetStateDetail(int id)
        {
            var stateDetail = await _context.States.FindAsync(id);

            if (stateDetail == null)
            {
                return NotFound();
            }

            return stateDetail;
        }

        // PUT: api/StateDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStateDetail(int id, StateDetail stateDetail)
        {
            if (id != stateDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(stateDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateDetailExists(id))
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

        // POST: api/StateDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StateDetail>> PostStateDetail(StateDetail stateDetail)
        {
            _context.States.Add(stateDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStateDetail", new { id = stateDetail.Id }, stateDetail);
        }

        // DELETE: api/StateDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStateDetail(int id)
        {
            var stateDetail = await _context.States.FindAsync(id);
            if (stateDetail == null)
            {
                return NotFound();
            }

            _context.States.Remove(stateDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StateDetailExists(int id)
        {
            return _context.States.Any(e => e.Id == id);
        }
    }
}
