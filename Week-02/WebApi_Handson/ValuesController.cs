using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new[] { "Value1", "Value2" });

    [HttpGet("{id}")]
    public IActionResult Get(int id) => Ok($"Value: {id}");

    [HttpPost]
    public IActionResult Post([FromBody] string value) => Ok("Record Added");

    [HttpPut("{id}")]
    public IActionResult Put(int id,[FromBody] string value) => Ok("Record Updated");

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) => Ok("Record Deleted");
}
