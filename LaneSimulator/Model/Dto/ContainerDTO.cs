using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneSimulator.Model.Dto
{
    public class ContainerDTO
    {
        public long? id { get; set; }

        public string containerNumber { get; set; }

        public string ocrContainerNumber { get; set; }


        public string ocrIsoCode { get; set; }

        public bool isOcrContainerNumberSucceeded { get; set; }


        public object damages { get; set; }


        public string sealNumber { get; set; }


        public string createdBy { get; set; }

        public string createdTime { get; set; }


        public string lastModifiedBy { get; set; }

        public string lastModifiedTime { get; set; }

        public long? jobQueueId { get; set; }

        public string jobQueueCode { get; set; }

    }
}
