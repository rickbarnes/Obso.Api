using Domain.Column;
using IServices.Column;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Column
{
    [Produces("application/json")]
    [Route("v1")]
    public sealed class ColumnController : Controller
    {
        private readonly IColumnService _columnService;

        public ColumnController(IColumnService columnService)
        {
            _columnService = columnService;
        }

        [Route("columnId/{columnId}/boardId/{boardId}")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid columnId, Guid boardId)
        {
            var result = await this._columnService.GetColumnById(columnId, boardId);

            if (result == null)
            {
                return this.NoContent();
            }

            return this.Ok(result);
        }
    }
}
