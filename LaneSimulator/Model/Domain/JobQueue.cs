using LaneSimulator.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaneSimulator.Model.Domain
{
    public class JobQueue
    {
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

        public bool isEditable { get; set; }

        public bool isLocked { get; set; }

        public string lockedBy { get; set; }

        public string lockedTime { get; set; }

        public string releaseResult { get; set; }

        public string releasedType { get; set; }

        public string releasedBy { get; set; }

        public string releasedTime { get; set; }

        public List<Container> containers { get; set; }
        public Picture pictures { get; set; }
        public List<Process> processes { get; set; }

        public List<ReleaseRuleResultDTO> releaseRuleResults { get; set; }

        public object extras { get; set; }




        

    }
    



   

  

  
}
