using Domain.Board;

namespace IRepository.Boards;

public interface IBoardRepository
{
    Task<BoardEntity?> GetBoardById(Guid tenantId, Guid boardId);
    Task<BoardEntity> Add(BoardEntity boardEntity);
    Task<bool> Update(BoardEntity boardEntity);
}