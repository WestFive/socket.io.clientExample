using MessageHub.Model;
using MessageHub.util;
using Newtonsoft.Json;
using ReleaseRuleExecutor.dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TempLate;

namespace CommandExecutor
{


    /// <summary>
    /// 规则执行器，用于接收command并
    /// </summary>
    public class CommandExecutor
    {
        public delegate void commandExecutor(object obj);

        public event commandExecutor commandExecutorResult;


        public void resolveCommand(Command command, JobQueue workingQueue, Lane lane)
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
                    commandExecutorResult?.Invoke(command);//先打印

                    jobQueueDTO jobqueuedto = JsonConvert.DeserializeObject<jobQueueDTO>(File.ReadAllText(Application.StartupPath + "/conf/jobQueueDTO.json"));
                    command.commandName = "解析jobQueudto完成,准备调用API";
                    string result = WebApi.Post("http://10.1.1.114:8081/api/release-rule-executor", JsonConvert.SerializeObject(jobqueuedto));

                    jobQueueDTO jqdto = JsonConvert.DeserializeObject<jobQueueDTO>(result);

                    commandExecutorResult?.Invoke(command);//先打印
                    break;
                default:
                    commandExecutorResult?.Invoke(command);
                    break;
            }
        }
    }
}
