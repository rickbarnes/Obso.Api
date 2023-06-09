using Domain.Board;
using Engine.Board;
using IServices.Board;

namespace Services.Board;

public sealed class BoardService : IBoardService
{
    private readonly IBoardEngine _engine;
    
    public BoardService(IBoardEngine engine)
    {
        this._engine = engine;
    }
    
    public async Task<BoardEntity?> GetBoardById(Guid tenantId, Guid boardId)
    {
        return await this._engine.GetBoardById(tenantId, boardId);
    }
}