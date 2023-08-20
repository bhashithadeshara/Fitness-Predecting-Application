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
    public class WorkOutDetailController : Controller
    {
        private readonly ILogger<WorkOutDetailController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public WorkOutDetailController(ILogger<WorkOutDetailController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkOutDetails()
        {
            var workOutDetails = await Task.Run(() => _applicationDbContext.WorkOutDetails.ToList());
            return Ok(workOutDetails);
        }

        // GET: api/WorkOutDetail/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkOutDetailById(Guid id)
        {
            var workOutDetail = await Task.Run(() => _applicationDbContext.WorkOutDetails.Find(id));
            if (workOutDetail == null)
                return NotFound();

            return Ok(workOutDetail);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetWorkOutDetailsByEmail(string email)
        {
            var user = await Task.Run(() => _applicationDbContext.Users.FirstOrDefault(u => u.Email == email));
            if (user == null)
                return NotFound();

            var workOutDetails = await Task.Run(() => _applicationDbContext.WorkOutDetails.Where(w => w.UserId == user.Id).ToList());
            if (workOutDetails == null || workOutDetails.Count == 0)
                return NotFound();

            return Ok(workOutDetails);
        }

        // GET: api/WorkOutDetail
        [HttpPost("daterange")]
        public async Task<IActionResult> GetWorkOutDetailsByEmailAndDateRange([FromBody] WorkOutDetailsByEmailAndDateRange workOutDetail)
        {
            var user = await Task.Run(() => _applicationDbContext.Users.FirstOrDefault(u => u.Email == workOutDetail.Email));
            if (user == null)
                return NotFound();

            var workOutDetails = await Task.Run(() => _applicationDbContext.WorkOutDetails
                .Where(w => w.UserId == user.Id && w.WorkOutDate >= workOutDetail.StartDate && w.WorkOutDate <= workOutDetail.EndDate)
                .ToList());

            if (workOutDetails == null || workOutDetails.Count == 0)
                return NotFound();

            return Ok(workOutDetails);
        }

        //check work out for day by emai and date
        [HttpPost("checkWorkOutForDay")]
        public async Task<IActionResult> CheckWorkoutForDay(WorkoutDayRequest request)
        {
            // Get the user by UserId
            User user = await Task.Run(() => _applicationDbContext.Users
                .Include(u => u.UserWorkOutDetails)
                .FirstOrDefault(u => u.Email == request.Email));

            if (user == null)
            {
                return NotFound("User not found");
            }

            // Check if there is any workout data for the specified date
            bool hasWorkoutForDay = await Task.Run(() => user.UserWorkOutDetails.Any(workout => workout.WorkOutDate.Date == request.WorkOutDate));

            return Ok(hasWorkoutForDay);
        }

        // POST: api/WorkOutDetail
        [HttpPost]
        public async Task<IActionResult> CreateWorkOutDetail([FromBody] WorkOutDetail workOutDetail)
        {
            await Task.Run(() =>
            {
                _applicationDbContext.WorkOutDetails.Add(workOutDetail);
                _applicationDbContext.SaveChanges();
            });

            return CreatedAtAction(nameof(GetWorkOutDetailById), new { id = workOutDetail.Id }, workOutDetail);
        }

        // PUT: api/WorkOutDetail
        [HttpPut]
        public async Task<IActionResult> UpdateWorkOutDetail([FromBody] WorkOutDetail updatedWorkOutDetail)
        {
            var workOutDetail = await Task.Run(() => _applicationDbContext.WorkOutDetails.Find(updatedWorkOutDetail.Id));
            if (workOutDetail == null)
                return NotFound();

            workOutDetail.Weight = updatedWorkOutDetail.Weight;
            workOutDetail.Height = updatedWorkOutDetail.Height;
            workOutDetail.CheatMeal = updatedWorkOutDetail.CheatMeal;
            workOutDetail.WorkOut = updatedWorkOutDetail.WorkOut;
            workOutDetail.WorkOutType = updatedWorkOutDetail.WorkOutType;
            workOutDetail.WorkOutDuration = updatedWorkOutDetail.WorkOutDuration;

            await Task.Run(() => _applicationDbContext.SaveChanges());

            return NoContent();
        }

        // DELETE: api/WorkOutDetail/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkOutDetail(Guid id)
        {
            var workOutDetail = await _applicationDbContext.WorkOutDetails.FindAsync(id);
            if (workOutDetail == null)
                return NotFound();

            _applicationDbContext.WorkOutDetails.Remove(workOutDetail);
            await _applicationDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("delete/{email}")]
        public async Task<IActionResult> DeleteWorkOutDetailsByEmail(string email)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return NotFound();

            var workOutDetails = await _applicationDbContext.WorkOutDetails.Where(w => w.UserId == user.Id).ToListAsync();

            // Check if user has any workout details before attempting to delete
            if (workOutDetails != null && workOutDetails.Any())
            {
                // Delete all the user's workout details
                _applicationDbContext.WorkOutDetails.RemoveRange(workOutDetails);
            }

            // Save the changes to the database
            await _applicationDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
