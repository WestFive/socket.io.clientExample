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
    }
}
