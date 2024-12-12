using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly TestDbConnectionService _testDbConnectionService;

    public TestController(TestDbConnectionService testDbConnectionService)
    {
        _testDbConnectionService = testDbConnectionService;
    }

    [HttpGet("test-connection")]
    public async Task<ActionResult<string>> TestConnection()
    {
        var result = await _testDbConnectionService.TestConnectionAsync();
        return Ok(result);
    }
}
