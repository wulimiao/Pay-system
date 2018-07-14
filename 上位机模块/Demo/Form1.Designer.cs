namespace Demo
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lInfo = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bRs232Discon = new System.Windows.Forms.Button();
            this.bRs232Con = new System.Windows.Forms.Button();
            this.cBaudrate = new System.Windows.Forms.ComboBox();
            this.cCommPort = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cRfFreq = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ant4 = new System.Windows.Forms.CheckBox();
            this.ant3 = new System.Windows.Forms.CheckBox();
            this.ant2 = new System.Windows.Forms.CheckBox();
            this.ant1 = new System.Windows.Forms.CheckBox();
            this.bAntSet = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cEpcWordcnt = new System.Windows.Forms.ComboBox();
            this.cEpcWordptr = new System.Windows.Forms.ComboBox();
            this.cEpcMembank = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cEpcTimes = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.bEpcId = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lvTagList = new System.Windows.Forms.ListView();
            this.clhNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhTagData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhTimes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bClear = new System.Windows.Forms.Button();
            this.timerScanISO = new System.Windows.Forms.Timer(this.components);
            this.timerScanEPC = new System.Windows.Forms.Timer(this.components);
            this.timerPing = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkFilter = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // lInfo
            // 
            this.lInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lInfo.FormattingEnabled = true;
            this.lInfo.HorizontalScrollbar = true;
            this.lInfo.ItemHeight = 17;
            this.lInfo.Location = new System.Drawing.Point(6, 22);
            this.lInfo.Name = "lInfo";
            this.lInfo.ScrollAlwaysVisible = true;
            this.lInfo.Size = new System.Drawing.Size(321, 72);
            this.lInfo.TabIndex = 0;
            this.lInfo.SelectedIndexChanged += new System.EventHandler(this.lInfo_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Azure;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bRs232Discon);
            this.groupBox1.Controls.Add(this.bRs232Con);
            this.groupBox1.Controls.Add(this.cBaudrate);
            this.groupBox1.Controls.Add(this.cCommPort);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(47, 275);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 115);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(32, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "波特率";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(32, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "串口号";
            // 
            // bRs232Discon
            // 
            this.bRs232Discon.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bRs232Discon.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRs232Discon.ForeColor = System.Drawing.Color.Ivory;
            this.bRs232Discon.Location = new System.Drawing.Point(153, 80);
            this.bRs232Discon.Name = "bRs232Discon";
            this.bRs232Discon.Size = new System.Drawing.Size(65, 35);
            this.bRs232Discon.TabIndex = 5;
            this.bRs232Discon.Text = "断开";
            this.bRs232Discon.UseVisualStyleBackColor = false;
            this.bRs232Discon.Click += new System.EventHandler(this.bRs232Discon_Click);
            // 
            // bRs232Con
            // 
            this.bRs232Con.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bRs232Con.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRs232Con.ForeColor = System.Drawing.Color.LavenderBlush;
            this.bRs232Con.Location = new System.Drawing.Point(36, 80);
            this.bRs232Con.Name = "bRs232Con";
            this.bRs232Con.Size = new System.Drawing.Size(65, 35);
            this.bRs232Con.TabIndex = 4;
            this.bRs232Con.Text = "连接";
            this.bRs232Con.UseVisualStyleBackColor = false;
            this.bRs232Con.Click += new System.EventHandler(this.bRs232Con_Click);
            // 
            // cBaudrate
            // 
            this.cBaudrate.FormattingEnabled = true;
            this.cBaudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cBaudrate.Location = new System.Drawing.Point(123, 51);
            this.cBaudrate.Name = "cBaudrate";
            this.cBaudrate.Size = new System.Drawing.Size(87, 28);
            this.cBaudrate.TabIndex = 3;
            // 
            // cCommPort
            // 
            this.cCommPort.FormattingEnabled = true;
            this.cCommPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20"});
            this.cCommPort.Location = new System.Drawing.Point(123, 22);
            this.cCommPort.Name = "cCommPort";
            this.cCommPort.Size = new System.Drawing.Size(87, 28);
            this.cCommPort.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Azure;
            this.groupBox3.Controls.Add(this.cRfFreq);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(47, 396);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 58);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RF Setting";
            // 
            // cRfFreq
            // 
            this.cRfFreq.FormattingEnabled = true;
            this.cRfFreq.Items.AddRange(new object[] {
            "CHINA",
            "AMERICA"});
            this.cRfFreq.Location = new System.Drawing.Point(103, 24);
            this.cRfFreq.Name = "cRfFreq";
            this.cRfFreq.Size = new System.Drawing.Size(87, 28);
            this.cRfFreq.TabIndex = 8;
            this.cRfFreq.SelectedIndexChanged += new System.EventHandler(this.cRfFreq_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "频段选择";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ant4);
            this.groupBox4.Controls.Add(this.ant3);
            this.groupBox4.Controls.Add(this.ant2);
            this.groupBox4.Controls.Add(this.ant1);
            this.groupBox4.Controls.Add(this.bAntSet);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBox4.Location = new System.Drawing.Point(455, 583);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(136, 118);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ANT Setting";
            this.groupBox4.Visible = false;
            // 
            // ant4
            // 
            this.ant4.AutoSize = true;
            this.ant4.Location = new System.Drawing.Point(81, 64);
            this.ant4.Name = "ant4";
            this.ant4.Size = new System.Drawing.Size(54, 18);
            this.ant4.TabIndex = 9;
            this.ant4.Text = "ANT4";
            this.ant4.UseVisualStyleBackColor = true;
            // 
            // ant3
            // 
            this.ant3.AutoSize = true;
            this.ant3.Location = new System.Drawing.Point(21, 64);
            this.ant3.Name = "ant3";
            this.ant3.Size = new System.Drawing.Size(54, 18);
            this.ant3.TabIndex = 8;
            this.ant3.Text = "ANT3";
            this.ant3.UseVisualStyleBackColor = true;
            // 
            // ant2
            // 
            this.ant2.AutoSize = true;
            this.ant2.Location = new System.Drawing.Point(81, 28);
            this.ant2.Name = "ant2";
            this.ant2.Size = new System.Drawing.Size(54, 18);
            this.ant2.TabIndex = 7;
            this.ant2.Text = "ANT2";
            this.ant2.UseVisualStyleBackColor = true;
            // 
            // ant1
            // 
            this.ant1.AutoSize = true;
            this.ant1.Location = new System.Drawing.Point(21, 28);
            this.ant1.Name = "ant1";
            this.ant1.Size = new System.Drawing.Size(54, 18);
            this.ant1.TabIndex = 6;
            this.ant1.Text = "ANT1";
            this.ant1.UseVisualStyleBackColor = true;
            this.ant1.CheckedChanged += new System.EventHandler(this.ant1_CheckedChanged);
            // 
            // bAntSet
            // 
            this.bAntSet.BackColor = System.Drawing.Color.SlateGray;
            this.bAntSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bAntSet.ForeColor = System.Drawing.Color.Gold;
            this.bAntSet.Location = new System.Drawing.Point(34, 85);
            this.bAntSet.Name = "bAntSet";
            this.bAntSet.Size = new System.Drawing.Size(77, 26);
            this.bAntSet.TabIndex = 4;
            this.bAntSet.Text = "Set";
            this.bAntSet.UseVisualStyleBackColor = false;
            this.bAntSet.Click += new System.EventHandler(this.bAntSet_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.cEpcWordcnt);
            this.groupBox6.Controls.Add(this.cEpcWordptr);
            this.groupBox6.Controls.Add(this.cEpcMembank);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.cEpcTimes);
            this.groupBox6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox6.Location = new System.Drawing.Point(597, 543);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(186, 163);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ISO18000-6C(EPC G2)";
            this.groupBox6.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(51, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 16);
            this.label16.TabIndex = 25;
            this.label16.Text = "MemBank";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(51, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 16);
            this.label15.TabIndex = 24;
            this.label15.Text = "WordCnt";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(51, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 16);
            this.label14.TabIndex = 22;
            this.label14.Text = "WordPtr";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // cEpcWordcnt
            // 
            this.cEpcWordcnt.FormattingEnabled = true;
            this.cEpcWordcnt.Location = new System.Drawing.Point(121, 134);
            this.cEpcWordcnt.Name = "cEpcWordcnt";
            this.cEpcWordcnt.Size = new System.Drawing.Size(63, 24);
            this.cEpcWordcnt.TabIndex = 20;
            // 
            // cEpcWordptr
            // 
            this.cEpcWordptr.FormattingEnabled = true;
            this.cEpcWordptr.Location = new System.Drawing.Point(121, 100);
            this.cEpcWordptr.Name = "cEpcWordptr";
            this.cEpcWordptr.Size = new System.Drawing.Size(63, 24);
            this.cEpcWordptr.TabIndex = 19;
            this.cEpcWordptr.SelectedIndexChanged += new System.EventHandler(this.cEpcWordptr_SelectedIndexChanged);
            // 
            // cEpcMembank
            // 
            this.cEpcMembank.FormattingEnabled = true;
            this.cEpcMembank.Items.AddRange(new object[] {
            "EPC"});
            this.cEpcMembank.Location = new System.Drawing.Point(121, 68);
            this.cEpcMembank.Name = "cEpcMembank";
            this.cEpcMembank.Size = new System.Drawing.Size(63, 24);
            this.cEpcMembank.TabIndex = 18;
            this.cEpcMembank.SelectedIndexChanged += new System.EventHandler(this.cEpcMembank_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(67, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Times";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // cEpcTimes
            // 
            this.cEpcTimes.FormattingEnabled = true;
            this.cEpcTimes.Items.AddRange(new object[] {
            "Continours"});
            this.cEpcTimes.Location = new System.Drawing.Point(121, 29);
            this.cEpcTimes.Name = "cEpcTimes";
            this.cEpcTimes.Size = new System.Drawing.Size(63, 24);
            this.cEpcTimes.TabIndex = 14;
            this.cEpcTimes.SelectedIndexChanged += new System.EventHandler(this.cEpcTimes_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LightPink;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(284, 384);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 36);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // bEpcId
            // 
            this.bEpcId.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bEpcId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEpcId.ForeColor = System.Drawing.Color.White;
            this.bEpcId.Location = new System.Drawing.Point(284, 284);
            this.bEpcId.Name = "bEpcId";
            this.bEpcId.Size = new System.Drawing.Size(91, 36);
            this.bEpcId.TabIndex = 5;
            this.bEpcId.Text = "start";
            this.bEpcId.UseVisualStyleBackColor = false;
            this.bEpcId.Click += new System.EventHandler(this.bEpcId_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lInfo);
            this.groupBox7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox7.Location = new System.Drawing.Point(42, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(333, 100);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "操作信息";
            // 
            // lvTagList
            // 
            this.lvTagList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhNo,
            this.clhTagData,
            this.clhTimes});
            this.lvTagList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvTagList.Location = new System.Drawing.Point(47, 112);
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(328, 157);
            this.lvTagList.TabIndex = 14;
            this.lvTagList.UseCompatibleStateImageBehavior = false;
            this.lvTagList.View = System.Windows.Forms.View.Details;
            this.lvTagList.SelectedIndexChanged += new System.EventHandler(this.lvTagList_SelectedIndexChanged);
            // 
            // clhNo
            // 
            this.clhNo.Text = "NO.";
            this.clhNo.Width = 40;
            // 
            // clhTagData
            // 
            this.clhTagData.Text = "Tag Data";
            this.clhTagData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhTagData.Width = 120;
            // 
            // clhTimes
            // 
            this.clhTimes.Text = "Times";
            this.clhTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhTimes.Width = 50;
            // 
            // bClear
            // 
            this.bClear.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bClear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bClear.ForeColor = System.Drawing.Color.White;
            this.bClear.Location = new System.Drawing.Point(284, 331);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(91, 37);
            this.bClear.TabIndex = 11;
            this.bClear.Text = "clear";
            this.bClear.UseVisualStyleBackColor = false;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // timerScanISO
            // 
            this.timerScanISO.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerScanEPC
            // 
            this.timerScanEPC.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timerPing
            // 
            this.timerPing.Interval = 3000;
            this.timerPing.Tick += new System.EventHandler(this.timerPing_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // chkFilter
            // 
            this.chkFilter.AutoSize = true;
            this.chkFilter.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkFilter.ForeColor = System.Drawing.Color.Yellow;
            this.chkFilter.Location = new System.Drawing.Point(284, 426);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Size = new System.Drawing.Size(126, 20);
            this.chkFilter.TabIndex = 19;
            this.chkFilter.Text = "Filter Same";
            this.chkFilter.UseVisualStyleBackColor = true;
            this.chkFilter.Visible = false;
            this.chkFilter.CheckedChanged += new System.EventHandler(this.chkFilter_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(409, 455);
            this.Controls.Add(this.chkFilter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lvTagList);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.bEpcId);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Form1";
            this.Text = "miao1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bRs232Con;
        private System.Windows.Forms.ComboBox cBaudrate;
        private System.Windows.Forms.ComboBox cCommPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bRs232Discon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cRfFreq;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox ant4;
        private System.Windows.Forms.CheckBox ant3;
        private System.Windows.Forms.CheckBox ant2;
        private System.Windows.Forms.Button bAntSet;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button bEpcId;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cEpcTimes;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cEpcWordcnt;
        private System.Windows.Forms.ComboBox cEpcWordptr;
        private System.Windows.Forms.ComboBox cEpcMembank;
        private System.Windows.Forms.Timer timerScanISO;
        private System.Windows.Forms.Timer timerScanEPC;
        private System.Windows.Forms.ListView lvTagList;
        private System.Windows.Forms.ColumnHeader clhNo;
        private System.Windows.Forms.ColumnHeader clhTagData;
        private System.Windows.Forms.ColumnHeader clhTimes;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer timerPing;
        private System.Windows.Forms.CheckBox ant1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkFilter;
    }
}

