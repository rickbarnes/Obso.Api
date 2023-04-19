using Domain.Column;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEngine.Column
{
    public interface IColumnEngine
    {
        Task<ColumnEntity?> GetColumnById(Guid columnId, Guid boardId);    }
}
