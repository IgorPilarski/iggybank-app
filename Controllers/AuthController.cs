using Microsoft.AspNetCore.Mvc;
using iggybank_app.Data;
using iggybank_app.Models;
using Microsoft.AspNetCore.Identity;


namespace iggybank_app.Controllers
{
    [ApiController]
    [Route("api/auth")] 
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpPost("register")]
        public IActionResult Register([FromBody] User request)
        {
            if (_context.Users.Any(u => u.Username == request.Username))
            {
                return BadRequest("Username already exists");
            }
            var hasher = new PasswordHasher<User>();
            var user = new User();
            user.Username = request.Username;
            user.PasswordHash = hasher.HashPassword(user, request.PasswordHash);
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("User has been registered!");
        }
    }
}