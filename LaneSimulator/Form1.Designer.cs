namespace LaneDataSimulator
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.textJobQueuePoolName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textLanePoolName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxlaneName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLaneCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonConnectMessageHub = new System.Windows.Forms.Button();
            this.textBoxapiAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMessageHubUrl = new System.Windows.Forms.TextBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabLane = new System.Windows.Forms.TabPage();
            this.textLaneSend = new System.Windows.Forms.Button();
            this.textBoxLaneNodeInfo = new System.Windows.Forms.TextBox();
            this.treeLane = new System.Windows.Forms.TreeView();
            this.tabJobQueue = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxQueueNodeInfo = new System.Windows.Forms.TextBox();
            this.JobQueueControllerPanel = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.JobQueueTree = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabLane.SuspendLayout();
            this.tabJobQueue.SuspendLayout();
            this.JobQueueControllerPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textJobQueuePoolName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textLanePoolName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxlaneName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxLaneCode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonConnectMessageHub);
            this.panel1.Controls.Add(this.textBoxapiAddress);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxMessageHubUrl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 132);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1017, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 75);
            this.button2.TabIndex = 14;
            this.button2.Text = "测试指令";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textJobQueuePoolName
            // 
            this.textJobQueuePoolName.Location = new System.Drawing.Point(592, 93);
            this.textJobQueuePoolName.Name = "textJobQueuePoolName";
            this.textJobQueuePoolName.Size = new System.Drawing.Size(233, 21);
            this.textJobQueuePoolName.TabIndex = 13;
            this.textJobQueuePoolName.Text = "jobQueue";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "作业池名称";
            // 
            // textLanePoolName
            // 
            this.textLanePoolName.Location = new System.Drawing.Point(592, 65);
            this.textLanePoolName.Name = "textLanePoolName";
            this.textLanePoolName.Size = new System.Drawing.Size(233, 21);
            this.textLanePoolName.TabIndex = 11;
            this.textLanePoolName.Text = "lane";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "车道池名称";
            // 
            // textBoxlaneName
            // 
            this.textBoxlaneName.Location = new System.Drawing.Point(592, 39);
            this.textBoxlaneName.Name = "textBoxlaneName";
            this.textBoxlaneName.Size = new System.Drawing.Size(233, 21);
            this.textBoxlaneName.TabIndex = 9;
            this.textBoxlaneName.Text = "CN-RUILI-JICP1-LA01";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(527, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "车道名称";
            // 
            // textBoxLaneCode
            // 
            this.textBoxLaneCode.Location = new System.Drawing.Point(592, 12);
            this.textBoxLaneCode.Name = "textBoxLaneCode";
            this.textBoxLaneCode.Size = new System.Drawing.Size(233, 21);
            this.textBoxLaneCode.TabIndex = 7;
            this.textBoxLaneCode.Text = "CN-RUILI-JICP1-LA01";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(527, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "车道代码";
            // 
            // buttonConnectMessageHub
            // 
            this.buttonConnectMessageHub.Location = new System.Drawing.Point(894, 12);
            this.buttonConnectMessageHub.Name = "buttonConnectMessageHub";
            this.buttonConnectMessageHub.Size = new System.Drawing.Size(117, 75);
            this.buttonConnectMessageHub.TabIndex = 0;
            this.buttonConnectMessageHub.Text = "注册监听";
            this.buttonConnectMessageHub.UseVisualStyleBackColor = true;
            this.buttonConnectMessageHub.Click += new System.EventHandler(this.buttonConnectMessageHub_Click);
            // 
            // textBoxapiAddress
            // 
            this.textBoxapiAddress.Location = new System.Drawing.Point(202, 41);
            this.textBoxapiAddress.Name = "textBoxapiAddress";
            this.textBoxapiAddress.Size = new System.Drawing.Size(233, 21);
            this.textBoxapiAddress.TabIndex = 4;
            this.textBoxapiAddress.Text = "http://10.1.1.5:8082";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "消息提交地址（API）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "消息服务地址（MessageHub）";
            // 
            // textBoxMessageHubUrl
            // 
            this.textBoxMessageHubUrl.Location = new System.Drawing.Point(202, 14);
            this.textBoxMessageHubUrl.Name = "textBoxMessageHubUrl";
            this.textBoxMessageHubUrl.Size = new System.Drawing.Size(233, 21);
            this.textBoxMessageHubUrl.TabIndex = 0;
            this.textBoxMessageHubUrl.Text = "http://10.1.1.5:5004";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabLane);
            this.tabMain.Controls.Add(this.tabJobQueue);
            this.tabMain.Enabled = false;
            this.tabMain.Location = new System.Drawing.Point(0, 138);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1161, 420);
            this.tabMain.TabIndex = 1;
            this.tabMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabMain_Selected);
            // 
            // tabLane
            // 
            this.tabLane.Controls.Add(this.textLaneSend);
            this.tabLane.Controls.Add(this.textBoxLaneNodeInfo);
            this.tabLane.Controls.Add(this.treeLane);
            this.tabLane.Location = new System.Drawing.Point(4, 22);
            this.tabLane.Name = "tabLane";
            this.tabLane.Padding = new System.Windows.Forms.Padding(3);
            this.tabLane.Size = new System.Drawing.Size(1153, 394);
            this.tabLane.TabIndex = 0;
            this.tabLane.Text = "Lane";
            this.tabLane.UseVisualStyleBackColor = true;
            // 
            // textLaneSend
            // 
            this.textLaneSend.Location = new System.Drawing.Point(455, 363);
            this.textLaneSend.Name = "textLaneSend";
            this.textLaneSend.Size = new System.Drawing.Size(690, 30);
            this.textLaneSend.TabIndex = 0;
            this.textLaneSend.Text = "更新并提交";
            this.textLaneSend.UseVisualStyleBackColor = true;
            this.textLaneSend.Click += new System.EventHandler(this.textLaneSend_Click);
            // 
            // textBoxLaneNodeInfo
            // 
            this.textBoxLaneNodeInfo.Location = new System.Drawing.Point(455, 6);
            this.textBoxLaneNodeInfo.Multiline = true;
            this.textBoxLaneNodeInfo.Name = "textBoxLaneNodeInfo";
            this.textBoxLaneNodeInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxLaneNodeInfo.Size = new System.Drawing.Size(691, 351);
            this.textBoxLaneNodeInfo.TabIndex = 2;
            // 
            // treeLane
            // 
            this.treeLane.Location = new System.Drawing.Point(3, 3);
            this.treeLane.Name = "treeLane";
            this.treeLane.Size = new System.Drawing.Size(446, 387);
            this.treeLane.TabIndex = 0;
            this.treeLane.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tree_MouseDown);
            // 
            // tabJobQueue
            // 
            this.tabJobQueue.Controls.Add(this.button1);
            this.tabJobQueue.Controls.Add(this.textBoxQueueNodeInfo);
            this.tabJobQueue.Controls.Add(this.JobQueueControllerPanel);
            this.tabJobQueue.Controls.Add(this.JobQueueTree);
            this.tabJobQueue.Location = new System.Drawing.Point(4, 22);
            this.tabJobQueue.Name = "tabJobQueue";
            this.tabJobQueue.Padding = new System.Windows.Forms.Padding(3);
            this.tabJobQueue.Size = new System.Drawing.Size(1153, 394);
            this.tabJobQueue.TabIndex = 1;
            this.tabJobQueue.Text = "JobQueue";
            this.tabJobQueue.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(452, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(695, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "更新并提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBoxQueueNodeInfo
            // 
            this.textBoxQueueNodeInfo.Location = new System.Drawing.Point(454, 6);
            this.textBoxQueueNodeInfo.Multiline = true;
            this.textBoxQueueNodeInfo.Name = "textBoxQueueNodeInfo";
            this.textBoxQueueNodeInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxQueueNodeInfo.Size = new System.Drawing.Size(696, 348);
            this.textBoxQueueNodeInfo.TabIndex = 4;
            // 
            // JobQueueControllerPanel
            // 
            this.JobQueueControllerPanel.Controls.Add(this.button6);
            this.JobQueueControllerPanel.Controls.Add(this.button5);
            this.JobQueueControllerPanel.Controls.Add(this.comboBox1);
            this.JobQueueControllerPanel.Location = new System.Drawing.Point(3, 6);
            this.JobQueueControllerPanel.Name = "JobQueueControllerPanel";
            this.JobQueueControllerPanel.Size = new System.Drawing.Size(445, 47);
            this.JobQueueControllerPanel.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(367, 14);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "删除";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(292, 14);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "新建";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(283, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // JobQueueTree
            // 
            this.JobQueueTree.Location = new System.Drawing.Point(3, 59);
            this.JobQueueTree.Name = "JobQueueTree";
            this.JobQueueTree.Size = new System.Drawing.Size(445, 335);
            this.JobQueueTree.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 560);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1164, 130);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.richTextBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, -13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1164, 143);
            this.panel3.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(4, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1148, 123);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(202, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(233, 21);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "http://10.1.1.5:8081";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "云闸口核心地址（API）";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 690);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "LaneSimulator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabLane.ResumeLayout(false);
            this.tabLane.PerformLayout();
            this.tabJobQueue.ResumeLayout(false);
            this.tabJobQueue.PerformLayout();
            this.JobQueueControllerPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

       

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabLane;
        private System.Windows.Forms.TabPage tabJobQueue;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeLane;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView JobQueueTree;
        private System.Windows.Forms.Panel JobQueueControllerPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMessageHubUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxapiAddress;
        private System.Windows.Forms.Button buttonConnectMessageHub;
        private System.Windows.Forms.Button textLaneSend;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxLaneNodeInfo;
        private System.Windows.Forms.TextBox textBoxLaneCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxlaneName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxQueueNodeInfo;
        private System.Windows.Forms.TextBox textLanePoolName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textJobQueuePoolName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
    }
}

