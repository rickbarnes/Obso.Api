using Domain.Column;
using IEngine.Column;
using IServices.Column;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Column
{
    public sealed class ColumnService: IColumnService
    {
        private readonly IColumnEngine _columnEngine;

        public ColumnService(IColumnEngine columnEngine)
        {
            _columnEngine = columnEngine;
        }

        public async Task<ColumnEntity?> GetColumnById(Guid columnId, Guid boardId)
        {
            return await _columnEngine.GetColumnById(columnId, boardId);
        }
    }
}
