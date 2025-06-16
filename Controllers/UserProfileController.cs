
using iggybank_app.Data;
using iggybank_app.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace iggybank_app.Controllers
{
    [ApiController]
    [Route("api/profile")]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public ProfileController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // profile

        [HttpPost("profile")]
        public IActionResult Profile([FromBody] UserProfileRequest request)
        {
            string? username = User.Identity?.Name;
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return Unauthorized();

            var profile = _context.UserProfiles.FirstOrDefault(p => p.UserId == user.UserId);

            profile.FirstName = request.FirstName;
            profile.LastName = request.LastName;
            profile.Phone = request.Phone;
            profile.Address = request.Address;
            profile.Address2 = request.Address2;
            profile.State = request.State;
            profile.City = request.City;
            profile.Zipcode = request.Zipcode;

            _context.SaveChanges();

            return Ok(new { message = "User profile has been saved." });
        }
    }
}