using Domain.Column;
using IEngine.Column;
using IRepository.Column;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Column
{
    public sealed class ColumnEngine : IColumnEngine
    {
        private readonly IColumnRepository _columnRepository;

        public ColumnEngine(IColumnRepository columnRepository)
        {
            _columnRepository = columnRepository;
        }

        public async Task<ColumnEntity?> GetColumnById(Guid columnId, Guid boardId)
        {
            return await _columnRepository.GetColumnById(columnId, boardId);
        }
    }
}
