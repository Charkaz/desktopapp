using Microsoft.AspNetCore.Mvc;

namespace desktopapp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { message = "Merhaba! Bu basit bir ASP.NET Web API endpoint'idir.", timestamp = DateTime.Now });
    }
}
