using Microsoft.AspNetCore.Mvc;
using campersproj.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace campersproj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class campingspotsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public campingspotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampingSpot>>> GetCampingSpots()
        {
            return await _context.CampingSpots.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CampingSpot>> GetCampingSpot(int id)
        {
            var campingSpot = await _context.CampingSpots.FindAsync(id);

            if (campingSpot == null)
            {
                return NotFound();
            }

            return campingSpot;
        }

        [HttpPost]
        public async Task<ActionResult<CampingSpot>> PostCampingSpot(CampingSpot campingSpot)
        {
            _context.CampingSpots.Add(campingSpot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampingSpot", new { id = campingSpot.Id }, campingSpot);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampingSpot(int id, CampingSpot campingSpot)
        {
            if (id != campingSpot.Id)
            {
                return BadRequest();
            }

            _context.Entry(campingSpot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampingSpotExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampingSpot(int id)
        {
            var campingSpot = await _context.CampingSpots.FindAsync(id);
            if (campingSpot == null)
            {
                return NotFound();
            }

            _context.CampingSpots.Remove(campingSpot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CampingSpotExists(int id)
        {
            return _context.CampingSpots.Any(e => e.Id == id);
        }
    }
}
