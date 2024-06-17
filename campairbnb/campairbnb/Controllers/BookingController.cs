using Microsoft.AspNetCore.Mvc;
using campairbnb.Data;
using campairbnb.Models;
using System.Collections.Generic;

namespace campairbnb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ICampAirbnbDataContext _context;

        public BookingController(ICampAirbnbDataContext context)
        {
            _context = context;
        }

        // GET: api/Booking
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings()
        {
            var bookings = _context.GetBookings();
            return Ok(bookings);
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public ActionResult<Booking> GetBooking(int id)
        {
            var booking = _context.GetBooking(id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // POST: api/Booking
        [HttpPost]
        public ActionResult<Booking> PostBooking(Booking booking)
        {
            _context.AddBooking(booking);
            return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = _context.GetBooking(id);

            if (booking == null)
            {
                return NotFound();
            }

            _context.DeleteBooking(id);

            return NoContent();
        }

        [HttpGet("withdetails")]
        public ActionResult<IEnumerable<dynamic>> GetBookingswithDetails()
        {
            try
            {
                var bookingsWithDetails = _context.GetBookingsWithCampingSpotDetails();
                return Ok(bookingsWithDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


    }
}
