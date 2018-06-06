using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TempLate
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

        public int? totalWeight { get; set; }

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

        public List<ReleaseRuleResult> releaseRuleResults { get; set; }

        public object extras { get; set; }

    }
    


    public class Container
    {
        public string position { get; set; }

        public string containerNumber { get; set; }

        public string ocrContainerNumber { get; set; }

        public string isoCode { get; set; }

        public string reliability { get; set; }

        public List<Damage> damages { get; set; }

 
    }

    public class ReleaseRuleResult
    {
        public long? id { get; set; }

        public int? sequence { get; set; }

        public string releaseRuleName { get; set; }

        public string releaseRuleStatus { get; set; }

        public string releaseResultMessage { get; set; }

        public string updateTime = "2018-04-30T16:00:00Z";

        public long? jobQueueId { get; set; }

        public string jobQueueCode { get; set; }
    }

    public class Process
    {

        public string step { get; set; }

        public string updateTime { get; set; }

    }

    public class Picture
    {
        public string vehiclePictureUrl { get; set; }
        public string licencePlatePictureUrl { get; set; }
        public string frontTopPictureUrl { get; set; }
        public string backTopPictureUrl { get; set; }
        public string leftFrontPictureUrl { get; set; }
        public string leftBackPictureUrl { get; set; }
        public string rightFrontPictureUrl { get; set; }
        public string rightBackPictureUrl { get; set; }
        public string leftFrontDamagePictureUrl { get; set; }
        public string leftBackDamagePictureUrl { get; set; }
        public string rightFrontDamagePictureUrl { get; set; }
        public string rightBackDamagePictureUrl { get; set; }
        public string leftMosaicPictureUrl { get; set; }
        public string rightMosaicPictureUrl { get; set; }
        public string topMosaicPictureUrl { get; set; }
    }

    public class Damage
    {
        public string side { get; set; }
        public string damageCode { get; set; }

        public string damageGrade { get; set; }

        public string damagePart { get; set; }

        public string remark { get; set; }


    }
}
