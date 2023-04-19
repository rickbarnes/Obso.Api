using Domain.Board;

namespace IServices.Board;

public interface IBoardService 
{
    Task<BoardEntity?> GetBoardById(Guid tenantId, Guid boardId);
    Task<BoardEntity> AddBoard(BoardEntity board);
    Task<bool> UpdateBoard(BoardEntity board);
}