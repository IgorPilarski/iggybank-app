using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using iggybank_app.Data;
using iggybank_app.Models;

namespace iggybank_app.Controllers;

[ApiController]
[Route("api/transactions")]
[Authorize]
public class TransactionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TransactionsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("deposit")]
    public IActionResult Deposit([FromBody] Transactions request)
    {
        string username = User.FindFirstValue(ClaimTypes.Name);
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        if (user == null) return NotFound();

        user.Balance += request.Amount;
        _context.SaveChanges();

        return Ok(new { message = "Deposit successful", user.Balance });
    }

    [HttpPost("withdraw")]
    public IActionResult Withdraw([FromBody] Transactions request)
    {
        string username = User.FindFirstValue(ClaimTypes.Name);
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        if (user == null) return NotFound();
        if (user.Balance < request.Amount)
        {
            return BadRequest(new { message = "Insufficient funds" });
        }

        user.Balance -= request.Amount;
        _context.SaveChanges();

        return Ok(new { message = "Withdrawal successful", user.Balance });
    }
}