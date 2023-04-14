using IServices.Board;
using Microsoft.AspNetCore.Mvc;

namespace Obso.Api.Controllers.Board;

[Produces("application/json")]
[Route("v1")]
public sealed class BoardController : Controller
{
    private readonly IBoardService _service;

    public BoardController(IBoardService service)
    {
       this._service = service; 
    }
    
    [Route("tenant/{tenantId}/board/{boardId}")]
    [HttpGet]
    public async Task<IActionResult> GetBoard(Guid tenantId, Guid boardId)
    {
        var result = await this._service.GetBoardById(tenantId, boardId);
        
        if (result == null)
        {
            return this.NoContent();
        }
        
        return this.Ok(result);
    }
}