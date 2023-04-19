using Domain.Board;

namespace Engine.Board;

public interface IBoardEngine
{
    Task<BoardEntity?> GetBoardById(Guid tenantId, Guid boardId);
    Task<BoardEntity> AddBoard(BoardEntity board);
    Task<bool> UpdateBoard(BoardEntity board);
}