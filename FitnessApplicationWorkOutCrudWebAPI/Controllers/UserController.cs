using FitnessApplicationWorkOutCrudWebAPI.Data;
using FitnessApplicationWorkOutCrudWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApplicationWorkOutCrudWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public UserController(ILogger<UserController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _applicationDbContext.Users.ToList();
            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _applicationDbContext.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        //Get User by mail
        [HttpGet("getbyemail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        //user login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel loginModel)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == loginModel.Email && u.Password == loginModel.Password);

            if (user == null)
            {
                // Authentication failed
                return Unauthorized();
            }

            // Authentication succeeded
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            _applicationDbContext.Users.Add(user);
            await _applicationDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User updatedUser)
        {
            var user = await _applicationDbContext.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;

            await _applicationDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("updatebyemail")]
        public async Task<IActionResult> UpdateUserByEmail([FromBody] User updatedUser)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == updatedUser.Email);

            if (user == null)
                return NotFound();

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Password = updatedUser.Password;

            await _applicationDbContext.SaveChangesAsync();
            return Ok(user);
        }


        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _applicationDbContext.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _applicationDbContext.Users.Remove(user);
            await _applicationDbContext.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/User/{email}
        [HttpDelete("deletebyemail/{id}")]
        public async Task<IActionResult> DeleteUserByEmail(Guid id)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound();

            // Check if user has any workout details before attempting to delete
            if (user.UserWorkOutDetails != null && user.UserWorkOutDetails.Any())
            {
                // Delete all the user's workout details
                _applicationDbContext.WorkOutDetails.RemoveRange(user.UserWorkOutDetails);
            }

            // Save the changes to the database
            await _applicationDbContext.SaveChangesAsync();

            return NoContent();
        }
    }    
}
