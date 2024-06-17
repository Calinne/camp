using Microsoft.AspNetCore.Mvc;
using campairbnb.Data;
using campairbnb.Models;
using System.Collections.Generic;

namespace campairbnb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ICampAirbnbDataContext _context;

        public UsersController(ICampAirbnbDataContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _context.GetUsers();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _context.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            _context.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.DeleteUser(id);

            return NoContent();
        }

        //authentication method. instead of using Tokens....:
        // POST: api/Users/login
        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] LoginRequest loginRequest)
        {
            var existingUser = _context.GetUsers()
                .FirstOrDefault(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password);

            if (existingUser == null)
            {
                return Unauthorized();
            }

            return Ok(existingUser);
        }


        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var existingUser = _context.GetUser(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Assuming your data context has a method to update the user
            _context.UpdateUser(user);

            return NoContent();
        }


    }
}
