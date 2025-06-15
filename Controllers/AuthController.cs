using Microsoft.AspNetCore.Mvc;
using iggybank_app.Data;
using iggybank_app.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace iggybank_app.Controllers
{
    [ApiController]
    [Route("api/auth")] 
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //register:
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
            user.Password = hasher.HashPassword(user, request.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("User has been registered!");
        }
        //login:
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);
            if (user == null)
            {
                return BadRequest("User don't exists.");
            }
            
            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.Password, request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return BadRequest("Złe hasło.");
            }
            string token = CreateToken(user);
            return Ok(new { token });        }
        
        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"]!
            ));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpireMinutes"]!)),
                signingCredentials: cred
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}