using LaneSimulator.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneSimulator.Model.Domain.Dto
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
}
