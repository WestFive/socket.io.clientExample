using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneSimulator.Model.Dto
{
    public class ReleaseRuleResultDTO
    {
        public long? id { get; set; }

        public int? sequence { get; set; }


        public string releaseRuleName { get; set; }

        public object releaseRuleStatus { get; set; }


        public string releaseResultMessage { get; set; }

        public string updateTime { get; set; }

        public long? jobQueueId { get; set; }

        public string jobQueueCode { get; set; }

    }
}
