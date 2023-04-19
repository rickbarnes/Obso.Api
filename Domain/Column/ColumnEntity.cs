using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Column
{
    public sealed class ColumnEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Header { get; set; }

        public List<string> TaskIds { get; set; }

        public Guid BoardId { get; set; }
    }
}
