using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data.Context;
using SacramentMeetingPlanner.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Controllers
{
    [Route("api/sacrament-meetings")]
    [ApiController]
    public class SacramentMeetingsController : ControllerBase
    {
        private readonly SacramentMeetingPlannerContext _context;

        public SacramentMeetingsController(SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SacramentMeeting>>> GetSacramentAsync()
        {
            return await _context.SacramentMeetings.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SacramentMeeting>> GetSacramentAsync(int id)
        {
            var sacramentMeeting = await _context.SacramentMeetings.FindAsync(id);

            if (sacramentMeeting == null)
            {
                return NotFound();
            }

            return sacramentMeeting;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSacramentAsync(int id, SacramentMeeting sacramentMeeting)
        {
            if (id != sacramentMeeting.Id)
            {
                return BadRequest();
            }

            _context.Entry(sacramentMeeting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SacramentExists(id))
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

        [HttpPost]
        public async Task<ActionResult<SacramentMeeting>> PostSacramentAsync(SacramentMeeting sacramentMeeting)
        {
            _context.SacramentMeetings.Add(sacramentMeeting);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSacramentAsync), new { id = sacramentMeeting.Id }, sacramentMeeting);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SacramentMeeting>> DeleteSacramentAsync(int id)
        {
            var sacramentMeeting = await _context.SacramentMeetings.FindAsync(id);
            if (sacramentMeeting == null)
            {
                return NotFound();
            }

            _context.SacramentMeetings.Remove(sacramentMeeting);
            await _context.SaveChangesAsync();

            return sacramentMeeting;
        }

        private bool SacramentExists(int id)
        {
            return _context.SacramentMeetings.Any(e => e.Id == id);
        }
    }
}
