using Domain.Column;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Column
{
    public interface IColumnRepository
    {
        Task<ColumnEntity?> GetColumnById(Guid columnId, Guid boardId);
    }
}
