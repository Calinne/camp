using Microsoft.AspNetCore.Mvc;
using campairbnb.Data;
using campairbnb.Models;
using System.Collections.Generic;
using System.Linq;

namespace campairbnb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampingSpotsController : ControllerBase
    {
        private readonly ICampAirbnbDataContext _context;

        public CampingSpotsController(ICampAirbnbDataContext context)
        {
            _context = context;
        }

        // GET:/CampingSpots
        [HttpGet]
        public ActionResult<IEnumerable<CampingSpot>> GetCampingSpots()
        {
            var campingSpots = _context.GetCampingSpots();
            return Ok(campingSpots);
        }

        // GET:/CampingSpots/5
        [HttpGet("{id}")]
        public ActionResult<CampingSpot> GetCampingSpot(int id)
        {
            var campingSpot = _context.GetCampingSpot(id);

            if (campingSpot == null)
            {
                return NotFound();
            }

            return Ok(campingSpot);
        }

        // POST:/CampingSpots
        [HttpPost]
        public ActionResult<CampingSpot> PostCampingSpot(CampingSpot campingSpot)
        {
            _context.AddCampingSpot(campingSpot);
            return CreatedAtAction(nameof(GetCampingSpot), new { id = campingSpot.Id }, campingSpot);
        }

        // DELETE:/CampingSpots/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCampingSpot(int id)
        {
            var campingSpot = _context.GetCampingSpot(id);

            if (campingSpot == null)
            {
                return NotFound();
            }

            _context.DeleteCampingSpot(id);

            return NoContent();
        }


        // Temporary diagnostic endpoint
        //[HttpGet("inspect")]
        //public IActionResult InspectCampingSpots()
        //{
        //    try
        //    {
        //        (_context as CampAirbnbDatabase)?.InspectCampingSpotsDetailed();
        //        return Ok("Inspection complete. Check the server logs for details.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

    }
}
