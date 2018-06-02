using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHub.Model.Pool
{
    public class PoolCUR
    {
        public string poolName;
        public string poolMode;
        public string messagesSortColumn;
        public bool forceOverWrite;
        public string description;
        public string creator;

        public PoolCUR(string poolName,string poolMode,string messageSortColumn,bool forceOverWrite,string description,string creator)
        {
            this.poolMode = poolMode;
            this.poolName = poolName;
            this.messagesSortColumn = messageSortColumn;
            this.forceOverWrite = forceOverWrite;
            this.description = description;
            this.creator = creator;
        }

    }
}
