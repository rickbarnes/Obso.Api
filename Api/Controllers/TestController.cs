using IServices;
using Microsoft.AspNetCore.Mvc;

namespace Obso.Api.Controllers;

[Produces("application/json")]
[Route("v1")]
public sealed class TestController : Controller
{
    private readonly ITestService _service;

    public TestController(ITestService service)
    {
        this._service = service;
    }
    
    [Route("test")]
    [HttpGet]
    public async Task<IActionResult> Test(string testMessage)
    {
        var result = await this._service.Test(testMessage);
        return this.Ok(result);
    }
}