using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TibBackend.Data;

namespace TibBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly TibDbContext _context;

    public TestController(TibDbContext context)
    {
        _context = context;
    }

    [HttpGet("db-status")]
    public async Task<IActionResult> GetDbStatus()
    {
        var canConnect = await _context.Database.CanConnectAsync();
        var lockerCount = await _context.Lockers.CountAsync();
        
        return Ok(new 
        { 
            connected = canConnect,
            lockerCount = lockerCount,
            message = "The Inn Between is open for business! 🏨✨"
        });
    }
}