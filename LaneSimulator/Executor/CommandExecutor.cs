using LaneSimulator.Mapper;
using LaneSimulator.Model.Domain;
using LaneSimulator.Model.Domain.Dto;
using MessageHub.Model;
using MessageHub.util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LaneSimulator.Executor
{


    /// <summary>
    /// 规则执行器，用于接收command并
    /// </summary>
    public class CommandExecutor
    {
        public delegate void commandExecutor(object obj);

        public event commandExecutor commandExecutorResult;


        public JobQueueMapper jobqueueMapper = new JobQueueMapper();
        /// <summary>
        /// 指令解析
        /// </summary>
        /// <param name="command"></param>
        /// <param name="workingQueue"></param>
        /// <param name="lane"></param>
        public void resolveCommand(Model.Domain.Command command, JobQueue workingQueue, Lane lane)
        {

            switch (command.commandName)
            {
                case "liftBarrier"://抬杆
                    commandExecutorResult?.Invoke(command);
                    break;
                case "dropBarrier"://落杆
                    commandExecutorResult?.Invoke(command);
                    break;
                case "printReceipt"://打印小票
                    commandExecutorResult?.Invoke(command);
                    break;
                case "enableLane"://开启车道
                    lane.laneStatus = true;
                    commandExecutorResult?.Invoke(lane);
                    break;
                case "disableLane"://禁用车道
                    lane.laneStatus = false;
                    commandExecutorResult?.Invoke(lane);
                    break;
                case "testPrinter"://测试打印
                    commandExecutorResult?.Invoke(command);
                    break;
                case "setKioskLedDisplay"://设置机箱LED显示屏内容
                    commandExecutorResult?.Invoke(command);
                    break;
                case "setTopLedDisplay"://设置顶部LED显示屏内容
                    commandExecutorResult?.Invoke(command);
                    break;
                case "requestReleaseRuleExecutor":
                    command.commandName = "收到请求放行规则指令";
                    commandExecutorResult?.Invoke(command);// 回调给主窗体打印日志
                    //jobQueueDTO jobqueuedto = JsonConvert.DeserializeObject<jobQueueDTO>(File.ReadAllText(Application.StartupPath + "/conf/jobQueueDTO.json"));//读取默认jobQueueDTO
                    //jobqueuedto = setJobQueueDTO(workingQueue, jobqueuedto);//将当前workingQueue的                    

                    jobQueueDTO jobqueueDto = jobqueueMapper.toDto(workingQueue);
                    command.commandName = "解析jobQueudto完成,准备调用API";
                    commandExecutorResult?.Invoke(command); //回调给主窗体打印日志
                    string result = WebApi.Post("http://10.1.1.114:8081/api/release-rule-executor", JsonConvert.SerializeObject(jobqueueDto));//请求规则执行器API
                    jobQueueDTO apiResultDto = JsonConvert.DeserializeObject<jobQueueDTO>(result);//获取返回jobQueueDTO结果
                    workingQueue = jobqueueMapper.toEntity(apiResultDto, workingQueue);
                    command.commandName = "接收结果并赋值完成";
                    commandExecutorResult?.Invoke(command); //回调给主窗体打印日志
                    commandExecutorResult?.Invoke(workingQueue);//回调给主窗体更新workingQueue推送
                    break;
                //case "test":
                //    jobQueueDTO jobqueuedtoTest = JsonConvert.DeserializeObject<jobQueueDTO>(File.ReadAllText(Application.StartupPath + "/conf/jobQueueDTO.json"));//读取默认jobQueueDTO
                //    JobQueue jobqueueTest = JsonConvert.DeserializeObject<JobQueue>(JsonConvert.SerializeObject(jobqueuedtoTest));

                //    jobQueueDTO jobqueuedtoTest1 = JsonConvert.DeserializeObject<jobQueueDTO>(JsonConvert.SerializeObject(workingQueue));
                //    break;
                case "manualRelease":
                    dynamic commandParam = JsonConvert.DeserializeObject<Dictionary<string,string>>(command.parameter.ToString());
                    workingQueue.releaseResult = commandParam["releaseResult"];
                    workingQueue.releasedType = commandParam["releasedType"];
                    workingQueue.releasedBy = commandParam["releasedBy"];
                    workingQueue.releasedTime = commandParam["releasedTime"];
                    jobQueueDTO saveDbJobQueueDto = jobqueueMapper.toDto(workingQueue);
                    //将jobQueueDTO进行持久化
                    WebApi.Post("http://10.1.1.114:8081/api/job-queues", JsonConvert.SerializeObject(saveDbJobQueueDto),"PUT");//请求规则执行器API
                    command.commandName = "持久化数据完成";
                    commandExecutorResult?.Invoke(command); //回调给主窗体打印日志
                    commandExecutorResult?.Invoke(workingQueue);//回调给主窗体更新workingQueue推送
                    break;
                default:
                    commandExecutorResult?.Invoke(command);
                    break;
            }
        }

        //private jobQueueDTO setJobQueueDTO(JobQueue workingQueue, jobQueueDTO jobQueueDTO)
        //{


        //    jobQueueDTO.laneCode = workingQueue.laneCode;
        //    jobQueueDTO.jobQueueCode = workingQueue.jobQueueCode;
        //    jobQueueDTO.laneName = workingQueue.laneName;
        //    jobQueueDTO.isOcrLicensePlateNumberSucceeded = workingQueue.isOcrLicensePlateNumberSucceeded;
        //    jobQueueDTO.ocrLicensePlateNumber = workingQueue.ocrLicensePlateNumber;
        //    jobQueueDTO.rfidCardNumber = workingQueue.rfidCardNumber;
        //    jobQueueDTO.icCardNumber = workingQueue.icCardNumber;            
        //    jobQueueDTO.customsLockNumber = workingQueue.customsLockNumber;
        //    jobQueueDTO.licensePlateNumber = workingQueue.licensePlateNumber;
        //    jobQueueDTO.processes = null;
        //    jobQueueDTO.businessType = workingQueue.businessType;
        //    jobQueueDTO.containerQuantity = workingQueue.containerQuantity;
        //    jobQueueDTO.customsLockNumber = workingQueue.customsLockNumber;
        //    jobQueueDTO.direction = workingQueue.direction;
        //    jobQueueDTO.releaseResult = workingQueue.releaseResult;
        //    List<ReleaseRuleResultDTO> list = new List<ReleaseRuleResultDTO>();
        //    foreach (var item in jobQueueDTO.releaseRuleResults)
        //    {
        //        ReleaseRuleResultDTO dto = new ReleaseRuleResultDTO();
        //        dto.id = item.id;
        //        dto.jobQueueCode = item.jobQueueCode;
        //        dto.jobQueueId = item.jobQueueId;
        //        dto.releaseResultMessage = item.releaseResultMessage;
        //        dto.releaseRuleName = item.releaseRuleName;
        //        dto.releaseRuleStatus = item.releaseRuleStatus;
        //        dto.sequence = item.sequence;
        //        dto.updateTime = DateTime.UtcNow.ToString("s") + "Z"; 
        //        list.Add(dto);

        //    }
        //    jobQueueDTO.releaseRuleResults = list;
        //    jobQueueDTO.releasedType = workingQueue.releasedType;
        //    jobQueueDTO.releasedBy = workingQueue.releasedBy;
        //    jobQueueDTO.containers = null;
        //    jobQueueDTO.endTime = DateTime.UtcNow.ToString("s") + "Z";
        //    jobQueueDTO.extras = null;
        //    jobQueueDTO.pictures = null;
        //    return jobQueueDTO;
        //}

        //private void setQueue(jobQueueDTO jobqueuedto, JobQueue workingQueue)
        //{
        //    workingQueue.businessType = jobqueuedto.businessType;
        //    workingQueue.containerQuantity = jobqueuedto.containerQuantity;
        //    workingQueue.customsLockNumber = jobqueuedto.customsLockNumber;
        //    workingQueue.direction = jobqueuedto.direction;
        //    workingQueue.releaseResult = jobqueuedto.releaseResult;
        //    workingQueue.releaseRuleResults = JsonConvert.DeserializeObject<List<ReleaseRuleResult>>(JsonConvert.SerializeObject(jobqueuedto.releaseRuleResults));
        //    workingQueue.releasedType = jobqueuedto.releasedType;
        //    workingQueue.releasedBy = jobqueuedto.releasedBy;
        //    workingQueue.containers = JsonConvert.DeserializeObject<List<Container>>(JsonConvert.SerializeObject(jobqueuedto.containers));
        //    workingQueue.endTime = jobqueuedto.endTime;
        //    workingQueue.extras = jobqueuedto.extras;
        //    workingQueue.laneCode = jobqueuedto.laneCode;
        //    workingQueue.jobQueueCode = jobqueuedto.jobQueueCode;
        //    workingQueue.laneName = jobqueuedto.laneName;
        //    workingQueue.isOcrLicensePlateNumberSucceeded = jobqueuedto.isOcrLicensePlateNumberSucceeded;
        //    workingQueue.ocrLicensePlateNumber = jobqueuedto.ocrLicensePlateNumber;
        //    workingQueue.rfidCardNumber = jobqueuedto.rfidCardNumber;
        //    workingQueue.icCardNumber = jobqueuedto.icCardNumber;
        //    workingQueue.customsLockNumber = jobqueuedto.customsLockNumber;
        //    workingQueue.licensePlateNumber = jobqueuedto.licensePlateNumber;                                       

        //}
    }
}
