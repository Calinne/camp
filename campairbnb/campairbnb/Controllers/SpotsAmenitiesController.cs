using Microsoft.AspNetCore.Mvc;
using campairbnb.Data;
using campairbnb.Models;
using System.Collections.Generic;
using System.Linq;

namespace campairbnb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotsAmenitiesController : ControllerBase
    {
        private readonly ICampAirbnbDataContext _context;

        public SpotsAmenitiesController(ICampAirbnbDataContext _context)
        {
            this._context = _context;
        }

        // GET: api/SpotsAmenities
        [HttpGet]
        public ActionResult<IEnumerable<SpotsAmenity>> GetSpotsAmenities()
        {
            var spotsAmenities = _context.GetSpotsAmenities().ToList();
            return Ok(spotsAmenities);
        }

        // GET: example api/SpotsAmenities/5
        [HttpGet("{id}")]
        public ActionResult<SpotsAmenity> GetSpotsAmenity(int id)
        {
            var spotsAmenity = _context.GetSpotsAmenity(id);

            if (spotsAmenity == null)
            {
                return NotFound();
            }

            return Ok(spotsAmenity);
        }

        // POST: api/SpotsAmenities
        [HttpPost]
        public ActionResult<SpotsAmenity> PostSpotsAmenity([FromBody] SpotsAmenity spotsAmenity)
        {
            var amenity = _context.GetAmenity(spotsAmenity.AmenityId);
            var campingSpot = _context.GetCampingSpot(spotsAmenity.CampingSpotId);

            if (amenity == null || campingSpot == null)
            {
                return BadRequest("Invalid AmenityId or CampingSpotId.");
            }

            _context.AddSpotsAmenity(spotsAmenity);
            return CreatedAtAction(nameof(GetSpotsAmenity), new { id = spotsAmenity.Id }, spotsAmenity);
        }
    }
}
