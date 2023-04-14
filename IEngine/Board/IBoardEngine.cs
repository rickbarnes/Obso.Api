using Domain.Board;

namespace Engine.Board;

public interface IBoardEngine
{
    Task<BoardEntity?> GetBoardById(Guid tenantId, Guid boardId);
}