using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers;

[ApiController]
[Route("api/Emp")]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[]
        {
            new { Id = 1, Name = "John", Department = "HR" },
            new { Id = 2, Name = "Alice", Department = "IT" }
        });
    }
}
