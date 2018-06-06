using CommandExecutor;
using LaneDataSimulator.util;
using MessageHub;
using MessageHub.Model;
using MessageHub.util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PF_Log_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TempLate;

namespace LaneDataSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public NodeUtil nodeUtil = new NodeUtil();
        public JsonUtil jsonUtil = new JsonUtil();
        public Dictionary<string, dynamic> JobQueues = new Dictionary<string, dynamic>();
        private dynamic lane; //当前车道数据  类型为Lane声明为 dynamic
        private dynamic workingJobQueue;//当前作业类型为JobQueue声明为dynamic
        private MessageHubClient messagehubClient;
        public static PF_Log_Class pf_log_class = new PF_Log_Class(Application.StartupPath + "/" + "SystemLog", 5, 2);

        public CommandExecutor.CommandExecutor commandExecutor = new CommandExecutor.CommandExecutor();//指令处理器

        /// <summary>
        /// 重新加载左侧节点树
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tree"></param>
        private void reload(dynamic obj, TreeView tree)
        {
            tree.Nodes.Clear();
            tree.MouseDown -= tree_MouseDown;
            TreeNode RootNode = new TreeNode();
            RootNode.Tag = obj;
            if (typeof(Lane) == obj.GetType())
            {
                //RootNode.Name = "lane";
                RootNode.Text = "lane";
            }
            else
            {
                //RootNode.Name = "jobQueue";
                RootNode.Text = "jobQueue";
            }
            nodeUtil.AddChildNode(RootNode);
            tree.Nodes.Add(RootNode);
            tree.ExpandAll();
            tree.SelectedNode = RootNode;

            if (workingnode != null)
            {
                foreach (TreeNode node in tree.Nodes)
                {
                    TreeNode treenode;
                    if (null != workingnode.Parent)
                    {
                        treenode = FindNode(node, workingnode.Parent.Text + workingnode.Text);
                    }
                    else
                    {
                        treenode = FindNode(node, workingnode.Text);
                    }
                    if (treenode != null)
                    {
                        tree.SelectedNode = treenode;
                        tree.Focus();
                    }

                }
            }

            //tree.NodeMouseDoubleClick += TreeLane_NodeMouseDoubleClick;
            tree.MouseDown += tree_MouseDown;
        }

        /// <summary>
        /// 递归找寻节点
        /// </summary>
        /// <param name="tnParent"></param>
        /// <param name="strValue"></param>
        /// <returns></returns>
        private TreeNode FindNode(TreeNode tnParent, string strValue)
        {
            if (tnParent == null) return null;
            if (null != tnParent.Parent)
            {
                if (tnParent.Parent.Text + tnParent.Text == strValue) return tnParent;
            }
            else
            {
                if ("lane" == strValue || "jobQueue" == strValue) return tnParent;
            }

            TreeNode tnRet = null;
            foreach (TreeNode tn in tnParent.Nodes)
            {
                tnRet = FindNode(tn, strValue);//此处已经更新！
                if (tnRet != null) break;
            }
            return tnRet;

        }

        private void tree_MouseDown(object sender, MouseEventArgs e)
        {
            {
                if ((sender as TreeView) != null)
                {
                    if (tabMain.SelectedIndex == 1)//JobQueue选中
                    {
                        JobQueueTree.SelectedNode = JobQueueTree.GetNodeAt(e.X, e.Y);
                    }
                    else
                    {
                        treeLane.SelectedNode = treeLane.GetNodeAt(e.X, e.Y);
                    }
                }
            }
            TreeNode selectedNode = ((TreeView)sender).SelectedNode;

            if (tabMain.SelectedIndex == 1)//JobQueue选中
            {
                textBoxQueueNodeInfo.Text = JsonUtil.ConvertJsonString(JsonConvert.SerializeObject(selectedNode.Tag));
            }
            else//Lane选中
            {

                textBoxLaneNodeInfo.Text = JsonUtil.ConvertJsonString(JsonConvert.SerializeObject(selectedNode.Tag));
            }
        }




        /// <summary>
        /// 点击发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            TextBox text = (TextBox)(((Button)sender).Tag);
            string fullpath = text.Tag.ToString();
            string value = text.Text;
            UpdateData(fullpath, value);
            reload(lane, treeLane);
        }


        /// <summary>
        /// 根据点击的节点 获取完整路径 更新具体属性值
        /// </summary>
        /// <param name="fullpath"></param>
        /// <param name="value"></param>
        private void UpdateData(string fullpath, string value)
        {

            List<string> counts = fullpath.Split("\\".ToArray()).ToList();
            if (fullpath.StartsWith("lane"))
            {
                switch (counts.Count)
                {
                    case 1:
                        lane = JsonConvert.DeserializeObject<Lane>(value);
                        break;
                    case 2:
                        value = value.Replace("\"", "");
                        Dictionary<string, dynamic> dic = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(JsonConvert.SerializeObject(lane));
                        dic[counts.Last()] = value;
                        lane = JsonConvert.DeserializeObject<Lane>(JsonConvert.SerializeObject(dic));
                        break;
                    case 3:
                        int index = Convert.ToInt32(counts.Last());
                        lane.devices[index] = JsonConvert.DeserializeObject<Device>(value);
                        break;
                    case 4:
                        int iindex = Convert.ToInt32(counts[2]);
                        Dictionary<string, dynamic> dic4 = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(JsonConvert.SerializeObject(lane.devices[iindex]));
                        dic4[counts.Last()] = value.Replace("\"", "");
                        dynamic object4 = JsonConvert.DeserializeObject<Device>(JsonConvert.SerializeObject(dic4));
                        lane.devices[iindex] = object4;
                        break;


                }
                AppendLog("update", 9, "更新节点值" + counts.Last() + "成功");
                UpdateMessageToMessageHub(MessageType.Lane);
                reload(lane, treeLane);
            }
            else
            {
                switch (counts.Count)
                {
                    case 1:
                        workingJobQueue = JsonConvert.DeserializeObject<JobQueue>(value);
                        break;
                    case 2:
                        switch (counts[1])
                        {
                            case "pictures":
                                workingJobQueue.pictures = JsonConvert.DeserializeObject<Picture>(value);
                                break;
                            case "releaseRuleResults":
                                workingJobQueue.releaseRuleResults = JsonConvert.DeserializeObject<List<ReleaseRuleResult>>(value);
                                break;
                            case "containers":
                                workingJobQueue.containers = JsonConvert.DeserializeObject<List<TempLate.Container>>(value);
                                break;
                            case "processes":
                                workingJobQueue.processes = JsonConvert.DeserializeObject<List<Process>>(value);
                                break;
                            default:
                                value = value.Replace("\"", "");
                                Dictionary<string, dynamic> dic = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(JsonConvert.SerializeObject(workingJobQueue));
                                dic[counts.Last()] = value;
                                workingJobQueue = JsonConvert.DeserializeObject<JobQueue>(JsonConvert.SerializeObject(dic));
                                break;
                        }
                        break;
                    case 3:
                        int index = Convert.ToInt32(counts.Last());
                        switch (counts[1])
                        {
                            case "containers":
                                workingJobQueue.containers[index] = JsonConvert.DeserializeObject<TempLate.Container>(value);
                                break;
                            case "processes":
                                workingJobQueue.processes[index] = JsonConvert.DeserializeObject<Process>(value);
                                break;
                            case "releaseRuleResults":
                                workingJobQueue.releaseRuleResults[index] = JsonConvert.DeserializeObject<ReleaseRuleResult>(value);
                                break;


                        }
                        break;
                    case 4:
                        switch (counts[1])
                        {
                            case "containers":
                                int cindex = Convert.ToInt32(counts[2]);
                                Dictionary<string, dynamic> cdic = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(JsonConvert.SerializeObject(workingJobQueue.containers[cindex]));
                                cdic[counts.Last()] = value.Replace("\"", "");
                                dynamic object4 = JsonConvert.DeserializeObject<TempLate.Container>(JsonConvert.SerializeObject(cdic));
                                workingJobQueue.containers[cindex] = object4;
                                break;
                            case "processes":
                                int iindex = Convert.ToInt32(counts[2]);
                                Dictionary<string, dynamic> dic4 = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(JsonConvert.SerializeObject(workingJobQueue.processes[iindex]));
                                dic4[counts.Last()] = value.Replace("\"", "");
                                dynamic object5 = JsonConvert.DeserializeObject<Process>(JsonConvert.SerializeObject(dic4));
                                workingJobQueue.processes[iindex] = object5;
                                break;
                            case "releaseRuleResults":
                                int rindex = Convert.ToInt32(counts[2]);
                                Dictionary<string, dynamic> dic5 = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(JsonConvert.SerializeObject(workingJobQueue.releaseRuleResults[rindex]));
                                dic5[counts.Last()] = value.Replace("\"", "");
                                dynamic object6 = JsonConvert.DeserializeObject<ReleaseRuleResult>(JsonConvert.SerializeObject(dic5));
                                workingJobQueue.releaseRuleResults[rindex] = object6;
                                break;

                        }
                        break;
                    case 5:
                        int container_index = Convert.ToInt32(counts[2]);
                        int damages_index = Convert.ToInt32(counts[4]);
                        workingJobQueue.containers[container_index].damages[damages_index] = JsonConvert.DeserializeObject<Damage>(value);
                        break;
                    case 6:

                        int container_index1 = Convert.ToInt32(counts[2]);
                        int damages_index1 = Convert.ToInt32(counts[4]);
                        Dictionary<string, dynamic> lastdic = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(JsonConvert.SerializeObject(workingJobQueue.containers[container_index1].damages[damages_index1]));
                        lastdic[counts.Last()] = value.Replace("\"", "");
                        dynamic lastobject = JsonConvert.DeserializeObject<Damage>(JsonConvert.SerializeObject(lastdic));
                        workingJobQueue.containers[container_index1].damages[damages_index1] = lastobject;
                        break;


                }
                AppendLog("update", 9, "更新节点值" + counts.Last() + "成功");
                UpdateMessageToMessageHub(MessageType.JobQueue);
                reload(workingJobQueue, JobQueueTree);


            }


        }

        /// <summary>
        /// 更新消息服务
        /// </summary>
        /// <param name="type">更新类型</param>
        /// <param name="parms">可选参数</param>
        private void UpdateMessageToMessageHub(MessageType type, dynamic[] parms = null)
        {
            if (messagehubClient != null)
            {
                switch (type)
                {
                    case MessageType.JobQueue:
                        //更新消息服务Queue数据
                        messagehubClient.AddMessage(new MessageHub.Model.Message.MessageCUR(textJobQueuePoolName.Text, new MessageHub.Model.Message.Message(workingJobQueue.jobQueueCode, JsonConvert.SerializeObject(workingJobQueue), "", "")));
                        break;
                    case MessageType.Lane:
                        //更新消息服务Lane数据                      
                        messagehubClient.AddMessage(new MessageHub.Model.Message.MessageCUR(textLanePoolName.Text, new MessageHub.Model.Message.Message(lane.laneCode, JsonConvert.SerializeObject(lane), "", "")));
                        break;

                }

            }
        }



        private void tabMain_Selected(object sender, TabControlEventArgs e)
        {
            if (((TabControl)sender).SelectedIndex == 0)//选中的是lane Page
            {
                reload(lane, treeLane);
            }
        }


        /// <summary>
        /// 连接消息服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConnectMessageHub_Click(object sender, EventArgs e)
        {
            if (buttonConnectMessageHub.Text == "注册监听")
            {
                ///加载节点列表
                if (null == lane)
                {
                    lane = jsonUtil.LoadLaneFromLocalJson();
                    textBoxLaneCode.Text = lane.laneCode;
                    textBoxlaneName.Text = lane.laneName;

                }
                //((Lane)lane).laneStatus = false;
                updateLane(lane);
                //reload(lane, treeLane); //默认加载lane
                reloadUI();//重载UI


            }
            else
            {
                reloadUI();
            }
        }


        private void reloadUI()
        {
            if (null == messagehubClient)
            {
                messagehubClient = new MessageHubClient(textBoxMessageHubUrl.Text, textBoxapiAddress.Text, textBoxLaneCode.Text);
                tabMain.Enabled = true;
                button1.Enabled = true;
                textLaneSend.Enabled = true;
                messagehubClient.reciveMessage += MessagehubClient_reciveMessage;
                messagehubClient.reciveStatus += MessagehubClient_reciveStatus;
                messagehubClient.reciveHubError += MessagehubClient_reciveHubError;
                messagehubClient.reciveP2pMessage += MessagehubClient_reciveP2pMessage;
                commandExecutor.commandExecutorResult += CommandExecutor_commandExecutorResult;//指令处理器回调
                messagehubClient.HubInit();
                buttonConnectMessageHub.Text = "取消监听";

                textLanePoolName.Enabled = false;
                textBoxLaneCode.Enabled = false;
                textBoxapiAddress.Enabled = false;
                textBoxMessageHubUrl.Enabled = false;
                textJobQueuePoolName.Enabled = false;
                textLanePoolName.Enabled = false;
                textBoxlaneName.Enabled = false;

            }

            else if (buttonConnectMessageHub.Text == "取消监听")
            {
                JobQueueTree.Nodes.Clear();
                treeLane.Nodes.Clear();
                //button1.Enabled = false;
                textLaneSend.Enabled = false;
                tabMain.Enabled = false;
                messagehubClient.Dispose();
                messagehubClient = null;
                textBoxLaneNodeInfo.Text = "";
                textBoxQueueNodeInfo.Text = "";
                richTextBox1.Clear();
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                buttonConnectMessageHub.Text = "注册监听";
            }


        }


        private void MessagehubClient_reciveP2pMessage(string str)
        {
            try
            {
                str = str.Replace("\\", "");
                str = str.Remove(0, 1);
                str = str.Remove(str.Length - 1, 1);

                if (str.Contains("commandCode"))
                {
                    Command com = JsonConvert.DeserializeObject<Command>(str);                    
                    commandExecutor.resolveCommand(com, workingJobQueue, lane);//通知指令处理器处理指令
                }
                else
                {
                    string truestr = JsonConvert.SerializeObject(workingJobQueue);
                    string newstr = JsonConvert.SerializeObject(workingJobQueue);
                    JobQueue queue = JsonConvert.DeserializeObject<JobQueue>(str);
                    updateJobQueue(queue);
                }
            }
            catch (Exception ex)
            {
                AppendLog("reciveP2pMessage", 3, "接收到点对点数据" + str);
            }
        }

        private void updateJobQueue(JobQueue queue)
        {
            if (JobQueues.ContainsKey(queue.jobQueueCode))
            {
                workingJobQueue = queue;
                JobQueues[queue.jobQueueCode] = queue;

                Invoke(new MethodInvoker(() =>
                {
                    comboBox1.SelectedItem = queue.jobQueueCode;
                    UpdateData(textJobQueuePoolName.Text, JsonConvert.SerializeObject(queue));
                    AppendLog("reciveJobQueue", 3, "作业发生修改,已更新");
                    reload(workingJobQueue, JobQueueTree);
                }));

            }
        }

        private void updateLane(Lane ulane)
        {
            Invoke(new MethodInvoker(() =>
            {


                lane = ulane;
                UpdateData(textLanePoolName.Text, JsonConvert.SerializeObject(lane));
                reload(lane, treeLane);
            }));

        }



        private void MessagehubClient_reciveHubError(string str)
        {
            AppendLog("reciveHubError", 2, str);
        }

        private void MessagehubClient_reciveStatus(string str)
        {
            AppendLog("reciveStatusReturn", 9, str);
        }

        private void MessagehubClient_reciveMessage(string str)
        {
            AppendLog("reciveMessage", 9, str);

        }

        /// <summary>
        /// 模拟发送指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonConnectMessageHub.Enabled == true)
            {
                MessageBox.Show("请先连接消息服务！");
                return;
            }
            string command = jsonUtil.LoadCommandFromLocalJson();
            string receiver = textBoxLaneCode.Text;
            messagehubClient.sendP2pMessge(new MessageHub.Model.Message.MessageP2p(receiver, JsonConvert.SerializeObject(command)));
        }




        TreeNode workingnode;
        /// <summary>
        /// laneButton修改并推送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textLaneSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxLaneNodeInfo.Text == "" || treeLane.SelectedNode == null)
                {
                    MessageBox.Show("请先选择子节点", "Error");
                    return;
                }
                else if (treeLane.SelectedNode.Text == "laneCode")
                {
                    MessageBox.Show("laneCode不允许修改!", "Warning");
                    return;
                }
                workingnode = treeLane.SelectedNode;
                UpdateData(treeLane.SelectedNode.FullPath, textBoxLaneNodeInfo.Text);
                //Invoke(new MethodInvoker(() =>
                //{
                //    MessageBox.Show(node.Text);
                //}));
            }
            catch (Exception EX)
            {
                MessageBox.Show("发生错误,操作回滚,请稍后重新尝试", "错误");
            }

        }

        /// <summary>
        /// 增加Queue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                workingJobQueue = jsonUtil.LoadJobQueueFromLocalJson();
                workingJobQueue.jobQueueCode = Guid.NewGuid().ToString();
                workingJobQueue.laneCode = textBoxLaneCode.Text;
                workingJobQueue.laneName = textBoxlaneName.Text;
                JobQueues.Add(workingJobQueue.jobQueueCode, workingJobQueue);
                comboBox1.Items.Add(workingJobQueue.jobQueueCode);
                comboBox1.SelectedItem = workingJobQueue.jobQueueCode;

                reload(workingJobQueue, JobQueueTree);
                JobQueueTree.SelectedNode = JobQueueTree.Nodes[0];
                textBoxQueueNodeInfo.Text = JsonUtil.ConvertJsonString(JsonConvert.SerializeObject(JobQueueTree.SelectedNode.Tag));

                UpdateData(JobQueueTree.SelectedNode.FullPath, textBoxQueueNodeInfo.Text);//直接推送

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            // SendEnable();
            if (button1.Enabled == false)
            {
                button1.Enabled = true;
            }
            if (button6.Enabled == false)
            {
                button6.Enabled = true;
            }
        }

        /// <summary>
        /// 选中的queueCode发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            workingJobQueue = JobQueues[comboBox1.SelectedItem.ToString()];
            reload(workingJobQueue, JobQueueTree);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBoxQueueNodeInfo.Text == "" || JobQueueTree.SelectedNode == null)
                {
                    MessageBox.Show("请先选择子节点", "Error");
                    return;
                }
                else if (JobQueueTree.SelectedNode.Text == "jobQueueCode")
                {
                    MessageBox.Show("jobQueueCode不允许修改!", "Warning");
                    return;
                }

                workingnode = JobQueueTree.SelectedNode;

                UpdateData(JobQueueTree.SelectedNode.FullPath, textBoxQueueNodeInfo.Text);

                if (button6.Enabled == false)
                {
                    button6.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误,操作回滚,请稍后重新尝试", "错误");
            }
        }

        /// <summary>
        /// 删除作业
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "")
            {
                MessageBox.Show("请新建或重新载入jobQueue数据!", "Warning");
                return;
            }

            messagehubClient.deleteMessage(new MessageHub.Model.Message.MessageD(textJobQueuePoolName.Text, comboBox1.Text));
            JobQueues.Remove(comboBox1.Text);
            comboBox1.Items.Remove(comboBox1.Text);
            comboBox1.Text = "";
            JobQueueTree.Nodes.Clear();//清除node
            if (comboBox1.Items.Count == 0)
            {//没有作业 删除item不起作用
                button6.Enabled = false;
                textBoxQueueNodeInfo.Text = "";
            }
            else
            {
                button1.Enabled = true;

            }


            SendEnable();
        }

        private void SendEnable()
        {
            if (comboBox1.Items.Count == 0 || comboBox1.SelectedText == "")
            {
                Invoke(new MethodInvoker(() =>
                {
                    button1.Enabled = false;
                }));

            }
            else
            {

                Invoke(new MethodInvoker(() =>
                {
                    button1.Enabled = true;
                }));

            }
        }


        #region LogModule


        private void AppendLog(string module_name, int log_type, string log)
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    if (string.IsNullOrEmpty(log))
                        return;
                    string txt = string.Empty;
                    string str_mod = "";
                    string str_log_type = "";

                    if (!string.IsNullOrEmpty(module_name))
                    {
                        str_mod = module_name + ":";
                    }
                    if (log_type >= 0 && log_type < 3)
                    {
                        str_log_type = _str_log_type[log_type] + ":";
                    }

                    txt = str_mod + str_log_type + log;

                    if (richTextBox1.Lines.Length > 1000)
                    {
                        richTextBox1.Clear();
                    }
                    int Start = richTextBox1.SelectionStart;

                    switch (log_type)
                    {
                        case 0:
                            richTextBox1.SelectionColor = Color.Green;
                            break;
                        case 1:
                            richTextBox1.SelectionColor = Color.Coral;
                            break;
                        case 2:
                            richTextBox1.SelectionColor = Color.Red;
                            break;
                        case 3:
                            richTextBox1.SelectionColor = Color.Blue;
                            break;
                        default:
                            richTextBox1.SelectionColor = Color.Black;
                            break;
                    }
                    richTextBox1.AppendText("[" + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss") + "]:" + txt + "\r\n");

                    if (Start < this.richTextBox1.TextLength)
                    {
                        this.richTextBox1.ScrollToCaret();
                    }
                    else
                    {
                        richTextBox1.SelectionStart = this.richTextBox1.TextLength;
                        this.richTextBox1.ScrollToCaret();
                    }


                    sysLog sys_log;
                    sys_log.type = 0;
                    sys_log.log = "," + txt;
                    pf_log_class.WriteLog(sys_log);
                }));
            }
            catch (System.Exception ex)
            {
                string errorMes = GetExceptionMsg(ex, ex.ToString());
                //Tools.AddLog(errorMes);
                sysLog sys_log;
                sys_log.type = 2;
                sys_log.log = "," + errorMes;
                pf_log_class.WriteLog(sys_log);
            }
        }

        public void AddSystemLog(string log, int log_type = 0)
        {
            string module_name = _str_log_mod;
            AppendLog(module_name, log_type, log);

        }
        public static string[] _str_log_type = { "normal", "warning", "err", "" };
        public static string _str_log_mod = "sys";

        public static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【模块名称】：" + "主程序");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }


        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Command com = JsonConvert.DeserializeObject<Command>(File.ReadAllText(Application.StartupPath + "/conf/command.json"));
            messagehubClient.sendP2pMessge(new MessageHub.Model.Message.MessageP2p(textBoxLaneCode.Text, JsonConvert.SerializeObject(com)));
        }


        #region 指令处理

        private void CommandExecutor_commandExecutorResult(object obj)
        {
            switch (obj.GetType().FullName)
            {
                case "MessageHub.Model.Command":
                    AppendLog("commandResult", 3, ((Command)obj).commandName);
                    break;
                case "TempLate.JobQueue":
                    updateJobQueue((JobQueue)obj);
                    break;
                case "TempLate.Lane":
                    updateLane((Lane)obj);
                    break;
            }
            //AppendLog("CommandExecutorResult", 9, c.commandName);
        }

        #endregion
    }
}
