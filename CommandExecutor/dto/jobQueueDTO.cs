using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLate;

namespace ReleaseRuleExecutor.dto
{
    public class jobQueueDTO
    {
        public long? id { get; set; }

        public string jobQueueCode { get; set; }


        public string businessType { get; set; }


        public string laneCode { get; set; }


        public string laneName { get; set; }


        public string laneType { get; set; }


        public string direction { get; set; }

        public string startTime { get; set; }

        public string endTime { get; set; }


        public string licensePlateNumber { get; set; }


        public string ocrLicensePlateNumber { get; set; }

        public bool isOcrLicensePlateNumberSucceeded { get; set; }


        public string rfidLicensePlateNumber { get; set; }


        public string rfidCardNumber { get; set; }


        public string icCardNumber { get; set; }


        public string customsLockNumber { get; set; }

        public float? totalWeight { get; set; }

        public int? containerQuantity { get; set; }

        public string releaseResult { get; set; }

        // 获取ReleaseRuleResult数组
        public List<ReleaseRuleResultDTO> releaseRuleResults { get; set; }


        public string releasedType { get; set; }


        public string releasedBy { get; set; }

        public string releasedTime { get; set; }


        public object pictures { get; set; }


        public object processes { get; set; }


        public object extras { get; set; }


        public string createdBy { get; set; }

        public string createdTime { get; set; }


        public string lastModifiedBy { get; set; }

        public string lastModifiedTime { get; set; }

        // 获取Container数组
        public List<ContainerDTO> containers { get; set; }

    }

    public class ReleaseRuleResultDTO
    {
        public long? id { get; set; }

        public int? sequence { get; set; }

   
        public string releaseRuleName { get; set; }

        public object releaseRuleStatus { get; set; }

    
        public string releaseResultMessage { get; set; }

        public string updateTime { get; set; }

        public long? jobQueueId { get; set; }

        public string jobQueueCode { get; set;}

    }

    public class ContainerDTO
    {
        public long? id { get; set; }

        public string containerNumber { get; set; }

        public string ocrContainerNumber { get; set; }


        public string ocrIsoCode { get; set; }

        public bool isOcrContainerNumberSucceeded { get; set; }


        public object damages {get;set;}


        public string sealNumber { get; set; }


        public string createdBy { get; set; }

        public string createdTime { get; set; }


        public string lastModifiedBy { get; set; }

        public string lastModifiedTime { get; set; }

        public long? jobQueueId { get; set; }

        public string jobQueueCode { get; set; }

    }
}
