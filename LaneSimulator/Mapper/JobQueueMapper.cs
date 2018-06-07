using LaneSimulator.Model.Domain;
using LaneSimulator.Model.Domain.Dto;
using LaneSimulator.Model.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaneSimulator.Mapper
{
    public class JobQueueMapper
    {

        public jobQueueDTO toDto(JobQueue jobQueue)
        {
            jobQueueDTO jobQueueDto = new jobQueueDTO();
            jobQueueDto.jobQueueCode = jobQueue.jobQueueCode;
            jobQueueDto.businessType = jobQueue.businessType;
            jobQueueDto.laneCode = jobQueue.laneCode;
            jobQueueDto.laneName = jobQueue.laneName;
            jobQueueDto.laneType = jobQueue.laneType;
            jobQueueDto.direction = jobQueue.direction;
            jobQueueDto.startTime = Convert.ToDateTime(jobQueue.startTime).ToString("s") + "Z";
            jobQueueDto.endTime = Convert.ToDateTime(jobQueue.endTime).ToString("s") + "Z";
            jobQueueDto.licensePlateNumber = jobQueue.licensePlateNumber;
            jobQueueDto.ocrLicensePlateNumber = jobQueue.ocrLicensePlateNumber;
            jobQueueDto.isOcrLicensePlateNumberSucceeded = jobQueue.isOcrLicensePlateNumberSucceeded;
            jobQueueDto.rfidLicensePlateNumber = jobQueue.rfidLicensePlateNumber;
            jobQueueDto.rfidCardNumber = jobQueue.rfidCardNumber;
            jobQueueDto.icCardNumber = jobQueue.icCardNumber;
            jobQueueDto.customsLockNumber = jobQueue.customsLockNumber;
            jobQueueDto.totalWeight = jobQueue.totalWeight;
            jobQueueDto.containerQuantity = jobQueue.containerQuantity;
            jobQueueDto.releaseResult = jobQueue.releaseResult;
            jobQueueDto.releaseRuleResults = jobQueue.releaseRuleResults;
            foreach (var item in jobQueueDto.releaseRuleResults)
            {
                item.updateTime = Convert.ToDateTime(jobQueue.endTime).ToString("s") + "Z";

            }
            jobQueueDto.releasedType = jobQueue.releasedType;
            jobQueueDto.releasedBy = jobQueue.releasedBy;
            jobQueueDto.releasedTime = Convert.ToDateTime(jobQueue.releasedTime).ToString("s") + "Z";
            jobQueueDto.pictures = JsonConvert.SerializeObject(jobQueue.pictures);
            jobQueueDto.processes = JsonConvert.SerializeObject(jobQueue.processes);
            jobQueueDto.extras = JsonConvert.SerializeObject(jobQueue.extras);
            jobQueueDto.createdBy = jobQueue.laneCode;
            jobQueueDto.createdTime = Convert.ToDateTime(jobQueue.startTime).ToString("s") + "Z";
            jobQueueDto.lastModifiedBy = jobQueue.laneCode;
            jobQueueDto.lastModifiedTime = Convert.ToDateTime(jobQueue.endTime).ToString("s") + "Z";
            List<ContainerDTO> list = new List<ContainerDTO>();
            foreach (var item in jobQueue.containers)
            {
                ContainerDTO cdto = new ContainerDTO();
                cdto.containerNumber = item.containerNumber;
                cdto.createdBy = jobQueue.laneCode;
                cdto.createdTime = DateTime.UtcNow.ToString("s") + "Z";
                cdto.isOcrContainerNumberSucceeded = true;
                cdto.jobQueueCode = jobQueue.jobQueueCode;
                cdto.ocrContainerNumber = item.ocrContainerNumber;
                cdto.lastModifiedBy = jobQueue.laneCode;
                cdto.lastModifiedTime = DateTime.UtcNow.ToString("s") + "Z";
                cdto.ocrIsoCode = item.isoCode;
                cdto.damages = JsonConvert.SerializeObject(item.damages);
                list.Add(cdto);
            }
            jobQueueDto.containers = list;

            return jobQueueDto;



        }



        public JobQueue toEntity(jobQueueDTO jobqueueDto,JobQueue jobQueue)
        {            
            jobQueue.jobQueueCode = jobqueueDto.jobQueueCode;
            jobQueue.businessType = jobqueueDto.businessType;
            jobQueue.laneCode = jobqueueDto.laneCode;
            jobQueue.laneName = jobqueueDto.laneName;
            jobQueue.laneType = jobqueueDto.laneType;
            jobQueue.direction = jobqueueDto.direction;
            jobQueue.startTime = jobqueueDto.startTime;
            jobQueue.endTime = jobqueueDto.endTime;
            jobQueue.licensePlateNumber = jobqueueDto.licensePlateNumber;
            jobQueue.ocrLicensePlateNumber = jobqueueDto.ocrLicensePlateNumber;
            jobQueue.rfidCardNumber = jobqueueDto.rfidCardNumber;
            jobQueue.isOcrLicensePlateNumberSucceeded = jobqueueDto.isOcrLicensePlateNumberSucceeded;
            jobQueue.rfidLicensePlateNumber = jobqueueDto.rfidLicensePlateNumber;
            jobQueue.icCardNumber = jobqueueDto.icCardNumber;
            jobQueue.customsLockNumber = jobqueueDto.customsLockNumber;
            jobQueue.totalWeight = jobqueueDto.totalWeight;
            jobQueue.containerQuantity = jobqueueDto.containerQuantity;
            jobQueue.isEditable = true;
            //jobQueue.isLocked = false;
            //jobQueue.lockedBy = jobqueueDto.createdBy;
            jobQueue.releasedBy = jobqueueDto.releasedBy;
            jobQueue.releasedTime = jobqueueDto.releasedTime;
            jobQueue.releasedType = jobqueueDto.releasedType;
            jobQueue.releaseResult = jobqueueDto.releaseResult;
            jobQueue.releaseRuleResults = jobqueueDto.releaseRuleResults;
            List<Container> containers = new List<Container>();
            foreach (var item in jobqueueDto.containers)
            {
                Container container = new Container();
                List<Damage> damages = JsonConvert.DeserializeObject<List<Damage>>(item.damages.ToString());

                container.containerNumber = item.containerNumber;
                container.damages = damages;
                container.isoCode = item.ocrIsoCode;
                container.ocrContainerNumber = item.ocrContainerNumber;

                containers.Add(container);
                
            }
            jobQueue.containers = containers;
            jobQueue.pictures = JsonConvert.DeserializeObject<Picture>(jobqueueDto.pictures);
            jobQueue.processes = JsonConvert.DeserializeObject<List<Process>>(jobqueueDto.processes);
            jobQueue.extras = JsonConvert.DeserializeObject<object>(jobqueueDto.extras);

            return jobQueue;







        }




    }
}
