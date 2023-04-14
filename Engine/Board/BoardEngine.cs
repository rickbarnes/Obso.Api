using Domain.Board;
using IRepository.Boards;

namespace Engine.Board;

public sealed class BoardEngine : IBoardEngine
{
    private readonly IBoardRepository _boardRepository;

    public BoardEngine(IBoardRepository boardRepository)
    {
        this._boardRepository = boardRepository;
    }

    public async Task<BoardEntity?> GetBoardById(Guid tenantId, Guid boardId)
    {
        return await this._boardRepository.GetBoardById(tenantId, boardId);
    }
}