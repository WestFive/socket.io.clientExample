using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseRuleExecutor.dto
{
    public class jobQueueDTO
    {
        public string id { get; set; }

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

        public float totalWeight { get; set; }

        public int containerQuantity { get; set; }

        public string releaseResult;

        // 获取ReleaseRuleResult数组
        public List<ReleaseRuleResultDTO> releaseRuleResults { get; set; }


        public string releasedType { get; set; }


        public string releasedBy { get; set; }

        public string releasedTime { get; set; }


        public string pictures { get; set; }


        public string processes { get; set; }


        public string extras { get; set; }


        public string createdBy { get; set; }

        public string createdTime { get; set; }


        public string lastModifiedBy { get; set; }

        public string lastModifiedTime { get; set; }

        // 获取Container数组
        public List<ContainerDTO> containers { get; set; }

    }

    public class ReleaseRuleResultDTO
    {
        public string id { get; set; }

        public string releaseRuleName { get; set; }

        public string description { get; set; }

        public string priority { get; set; }

        public bool isEnabled { get; set; }

        public string onPermit { get; set; }

        public string onDeny { get; set; }

        public string onPending { get; set; }

        public string releaseRuleClass { get; set; }

        public string releaseRuleMethod { get; set; }

        public string releaseRuleParameters { get; set; }

        public string createdBy { get; set; }

        public string createdTime { get; set; }


        public string lastModifiedBy { get; set; }

        public string lastModifiedTime { get; set; }

    }

    public class ContainerDTO
    {
        public string id { get; set; }

        public string containerNumber { get; set; }

        public string ocrContainerNumber { get; set; }


        public string ocrIsoCode { get; set; }

        public bool isOcrContainerNumberSucceeded { get; set; }


        public string damages { get; set; }


        public string sealNumber { get; set; }


        public string createdBy { get; set; }

        public string createdTime { get; set; }


        public string lastModifiedBy { get; set; }

        public string lastModifiedTime { get; set; }

        public string jobQueueId { get; set; }

        public string jobQueueCode { get; set; }

    }
}
