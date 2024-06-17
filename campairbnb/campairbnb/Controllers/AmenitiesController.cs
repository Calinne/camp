using Microsoft.AspNetCore.Mvc;
using campairbnb.Data;
using campairbnb.Models;

namespace campairbnb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AmenitiesController : ControllerBase
    {
        private readonly ICampAirbnbDataContext _context;

        public AmenitiesController(ICampAirbnbDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAmenities());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var amenity = _context.GetAmenity(id);
            if (amenity == null)
            {
                return NotFound();
            }
            return Ok(amenity);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Amenity amenity)
        {
            _context.AddAmenity(amenity);
            return CreatedAtAction(nameof(Get), new { id = amenity.Id }, amenity);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAmenity(int id)
        {
            var amenity = _context.GetAmenity(id);

            if (amenity == null)
            {
                return NotFound();
            }

            _context.DeleteAmenity(id);

            return NoContent();
        }

    }
}
