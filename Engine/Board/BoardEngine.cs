using Domain.Board;
using IRepository.Boards;
using System.Reflection.Metadata;

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
    
    public async Task<BoardEntity> AddBoard(BoardEntity board)
    {
        return await this._boardRepository.Add(board);
    }    
    
    public async Task<bool> UpdateBoard(BoardEntity board)
    {
        return await this._boardRepository.Update(board);
    }
}