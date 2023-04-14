using Domain.Board;

namespace IRepository.Boards;

public interface IBoardRepository
{
    Task<BoardEntity> GetBoardById(Guid tenantId, Guid boardId);

    Task Add(BoardEntity boardEntity);

    Task Update(BoardEntity boardEntity);
}