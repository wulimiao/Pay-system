using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RfidApiLib;  

namespace Demo
{
    public partial class Form1 : Form
    {
        RfidApi Reader1 = new RfidApi();
        public byte IsoReading = 0;
        public byte EpcReading = 0;
        public int TagCnt = 0;
        public long ScanTimes = 0;
        public int Flag = 1;// 0：时间段内  1：时间段外
        public int Flag1 = 0;//0：还没有刷过卡，可以刷卡  1：刷过了，不能再刷了
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cCommPort.SelectedIndex = 0;
            cBaudrate.SelectedIndex = 0;
            bRs232Con.Enabled = true;    //连接使能
            bRs232Discon.Enabled = false;//断开不使能
          
            cEpcTimes.SelectedIndex = 0;//识别次数是连续识别

            cEpcMembank.SelectedIndex = 0;//识别码为EPC码
            int nLoop = 0;
            for (nLoop = 0; nLoop < 256; nLoop++)
                cEpcWordptr.Items.Add(Convert.ToString(nLoop));
            cEpcWordptr.SelectedIndex = 2;  //EPC数据起始地址是2                    
            for (nLoop = 0; nLoop < 256; nLoop++)
                cEpcWordcnt.Items.Add(Convert.ToString(nLoop));
            cEpcWordcnt.SelectedIndex = 6;  //EPC数据长度是6
        }

        private void bRs232Con_Click(object sender, EventArgs e)
        {
            int status;
            byte v1 = 0;
            byte v2 = 0;
            string s = "";
            status = Reader1.OpenCommPort(cCommPort.Text);
            if (status != 0)
            {
                lInfo.Items.Add("Open Comm Port Failed!");
                return;
            }
            status = Reader1.GetFirmwareVersion(ref v1,ref v2);
            if (status != 0)
            {
                lInfo.Items.Add("Can not connect with the reader!");
                Reader1.CloseCommPort();
                return;
            }
            lInfo.Items.Add("Connect the reader success!");
            s = string.Format("The reader's firmware version is:V{0:d2}.{1:d2}", v1, v2);
            lInfo.Items.Add(s);
            bAntQuery_Click(sender,e);
            //bTcpCon.Enabled = false;

            // 新增设置波特率功能，可提高多标签识别速度
            status = Reader1.SetBaudRate((byte)cBaudrate.SelectedIndex);
            if (status != 0)
            {
                lInfo.Items.Add("Set baudrate failed!");
                Reader1.CloseCommPort();
                return;
            }
            lInfo.Items.Add("Set baudrate success!");


            bRs232Con.Enabled = false;
            bRs232Discon.Enabled = true;

            bEpcId.Enabled = true;

            bRfQuery_Click(null,null);
        }

        private void bRs232Discon_Click(object sender, EventArgs e)
        {
            // 修改了波特率，结束或退出前要将波特率恢复为9600，否则下次会无法连接
            Reader1.SetBaudRate(0);
            Reader1.CloseCommPort();
            bRs232Con.Enabled = true;
            bRs232Discon.Enabled = false;

            bEpcId.Enabled = false;
        }

       

        private void bRfQuery_Click(object sender, EventArgs e)
        {
            byte pwr = 0;
            byte freq = 0;

            int status;

            status = Reader1.GetRf(ref pwr, ref freq);
            if (status != 0)
            {
                lInfo.Items.Add("Get Rf settings failed!");
                return;
            }
            //tRfPwr.Value = pwr;
            cRfFreq.SelectedIndex = freq;
            lInfo.Items.Add("Get Rf settings success!");
        }

        private void bRfSet_Click(object sender, EventArgs e)
        {
            byte pwr = 0;
            byte freq = 0;

            int status;
            //pwr = (byte)(tRfPwr.Value);
            freq = (byte)(cRfFreq.SelectedIndex);
            status = Reader1.SetRf(pwr, freq);
            if (status != 0)
            {
                lInfo.Items.Add("Set Rf settings failed!");
                return;
            }
            lInfo.Items.Add("Set Rf settings success!");
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            int status;
            int i, j;
            byte[,] IsoBuf = new byte[100, 12];
            byte tag_cnt = 0;
            string s = "";
            string s1 = "";
            int listIn = 0;
            // Filter same tag
            //if (!chkFilter.Checked)
            //    Reader1.ClearIdBuf();
            status = Reader1.IsoMultiTagIdentify(ref IsoBuf, ref tag_cnt);
            if (tag_cnt > 0)
            {
                for (i = 0; i < tag_cnt; i++)
                {
                    s1 = "";
                    for (j = 0; j < 8; j++)
                    {
                        s = string.Format("{0:X2} ", IsoBuf[i, j]);
                        s1 += s;
                    }
                    lInfo.Items.Add(s1);

                    ListViewItem lviList = new ListViewItem();
                    if (lvTagList.Items.Count <= 0)
                    {
                        lviList.SubItems[0].Text = "1";
                        for (i = 0; i <= 2; i++)
                            lviList.SubItems.Add("");
                        lvTagList.Items.Add(lviList);
                        listIn = 0;
                        lvTagList.Items[listIn].SubItems[1].Text = s1;
                        lvTagList.Items[listIn].SubItems[2].Text = "1";
                    }
                    else
                    {
                        listIn = -1;
                        for (i = 0; i < lvTagList.Items.Count; i++)
                        {
                            if (lvTagList.Items[i].SubItems[1].Text == s1)
                            {
                                listIn = i;
                                break;
                            }
                        }
                        if (listIn < 0)
                        {
                            listIn = lvTagList.Items.Count;
                            lviList.SubItems[0].Text = Convert.ToString(listIn + 1);
                            for (i = 0; i <= 2; i++)
                                lviList.SubItems.Add("");
                            lvTagList.Items.Add(lviList);
                        }
                        lvTagList.Items[listIn].SubItems[1].Text = s1;
                        if (lvTagList.Items[listIn].SubItems[2].Text == "")
                            lvTagList.Items[listIn].SubItems[2].Text = "0";
                        Int64 intTimes = Convert.ToInt64(lvTagList.Items[listIn].SubItems[2].Text);
                        lvTagList.Items[listIn].SubItems[2].Text = Convert.ToString(intTimes + 1);
                    }
                    TagCnt++;

                }
            }
            //if (ScanTimes <= 0)
            //{
            //    bIsoId_Click(sender, e);
            //}
        }

        /* private void bEpcId_Click(object sender, EventArgs e)
         {
             if (EpcReading == 0)
             {
                 Reader1.ClearIdBuf();
                 lInfo.Items.Clear();
                 lInfo.Items.Add("Start multiply tags identify!");
                 TagCnt = 0;
                 //if (cEpcTimes.SelectedIndex > 0)
                 //    ScanTimes = Convert.ToInt16(cEpcTimes.Text);
                 //else
                     ScanTimes = 99999999;
                 timerScanEPC.Interval = 1000;
                 timerScanEPC.Enabled = true;
                 bEpcId.Text = "停止";
                 groupBox1.Visible = false;
                 groupBox3.Visible = false;
                 groupBox7.Visible = false;
                 lvTagList.Visible = false;
                 bEpcId.Visible = false;
                 bClear.Visible = false;
                 btnExit.Visible = false;


                 EpcReading = 1;
             }
             else
             {
                 timerScanEPC.Enabled = false;
                 EpcReading = 0;
                 bEpcId.Text = "识别";
             }
         }*/
        private void bEpcId_Click(object sender, EventArgs e)
        {
            if (EpcReading == 0)
            {
                Reader1.ClearIdBuf();
                lInfo.Items.Clear();
                lInfo.Items.Add("Start multiply tags identify!");
                TagCnt = 0;
                if (cEpcTimes.SelectedIndex > 0)
                    ScanTimes = Convert.ToInt16(cEpcTimes.Text);
                else
                    ScanTimes = 9999;
               // timerScanEPC.Interval = (tEpcSpeed.Value + 1) * 20;
                timerScanEPC.Enabled = true;
                bEpcId.Text = "Stop";
                EpcReading = 1;
            }
            else
            {
                timerScanEPC.Enabled = false;
                EpcReading = 0;
                bEpcId.Text = "Identify";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int status;
            int i, j;
            byte[,] IsoBuf = new byte[100, 12];
            byte tag_cnt = 0;
            string s = "";
            string s1 = "";
            byte tag_flag = 0;
            int listIn = 0;

            //// Filter same tag
            if (!chkFilter.Checked)
                Reader1.ClearIdBuf();
            status = Reader1.EpcMultiTagIdentify(ref IsoBuf, ref tag_cnt, ref tag_flag);
            if (tag_cnt > 0)
            {
                for (i = 0; i < tag_cnt; i++)
                {
                    s1 = "";
                    for (j = 0; j < Convert.ToInt16(cEpcWordcnt.Text) * 2; j++)
                    {
                        s = string.Format("{0:X2} ", IsoBuf[i, j]);
                        s1 += s;
                    }
                    lInfo.Items.Add(s1);
        // public int Flag = 1;// 0：时间段内  1：时间段外
        //public int Flag1 = 0;//0：还没有刷过卡，可以刷卡  1：刷过了，不能再刷了

                    if (Flag == 0)
                    {
                        if (Flag1 == 1)

                            MessageBox.Show("请勿重复刷卡！");

                        else
                        {
                            if (MessageBox.Show("刷卡成功，是否打开药盒？", "欢迎光临：", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                MessageBox.Show("药盒已打开！");
                                //Flag = 1;
                                Flag1 = 1;
                            }
                        }
                    }
                    else
                    {
                      // MessageBox.Show("不在吃药时间！");
                    }
                    
                    

                    ListViewItem lviList = new ListViewItem();
                    if (lvTagList.Items.Count <= 0)
                    {
                     //   lviList.SubItems[0].Text = "1";//显示序号
                        lviList.SubItems.Add("");
                        lviList.SubItems.Add("");
                        lvTagList.Items.Add(lviList);
                        //Flag = 1;
                        listIn = 0;
                        lvTagList.Items[listIn].SubItems[1].Text = s1;//显示标签数据
                     //   lvTagList.Items[listIn].SubItems[2].Text = "1";//次数显示为1一次
                    }
                    else
                    {
                        listIn = -1;
                        for (i = 0; i < lvTagList.Items.Count; i++)
                        {
                            if (lvTagList.Items[i].SubItems[1].Text == s1)
                            {
                                listIn = i;
                                break;
                            }
                        }
                        if (listIn < 0)
                        {
                            listIn = lvTagList.Items.Count;
                            lviList.SubItems[0].Text = Convert.ToString(listIn + 1);
                            for (i = 0; i <= 2; i++)
                                lviList.SubItems.Add("");
                            lvTagList.Items.Add(lviList);
                        }
                      //  lvTagList.Items[listIn].SubItems[1].Text = s1;
                       // if (lvTagList.Items[listIn].SubItems[2].Text == "")
                         //   lvTagList.Items[listIn].SubItems[2].Text = "0";
                       // Int64 intTimes = Convert.ToInt64(lvTagList.Items[listIn].SubItems[2].Text);
                       // lvTagList.Items[listIn].SubItems[2].Text = Convert.ToString(intTimes + 1);
                    }
                }
            }
            if (ScanTimes <= 0)
            {
                bEpcId_Click(sender, e);
            }
        }

        

        private void bClear_Click(object sender, EventArgs e)
        {
            lInfo.Items.Clear();
            lvTagList.Items.Clear();
        }

       

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

      

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reader1.EndPing();
        }

        private void timerPing_Tick(object sender, EventArgs e)
        {
            if (Reader1.CheckPing() > 0)
            {
                lInfo.Items.Add("Reader already dropped");
                // If you are identifying label,can immediately stop.
                if (1 == EpcReading)
                {
                    bEpcId_Click(sender, e);
                }
            }
        }

        private void bAntQuery_Click(object sender, EventArgs e)   //ANT setting
        {
            byte ant_sel = 0;
            //byte antH = 0;
            int status = 0;

            status = Reader1.GetAnt(ref ant_sel);
            if (status != 0)
            {
                lInfo.Items.Add("Get Ant settings failed!");
                return;
            }
            lInfo.Items.Add("Get Ant settings success!");
            //if ((ant_sel & 0x01) == 0x01)
                ant1.Checked = true;
            //else
            //    ant1.Checked = false;
            //if ((ant_sel & 0x02) == 0x02)
                ant2.Checked = true;
            //else
            //    ant2.Checked = false;
            //if ((ant_sel & 0x04) == 0x04)
                ant3.Checked = true;
            //else
            //    ant3.Checked = false;
            //if ((ant_sel & 0x08) == 0x08)
                ant4.Checked = true;
            //else
            //    ant4.Checked = false;
        }

        private void bAntSet_Click(object sender, EventArgs e)
        {
            byte ant_sel = 0;
            //byte antH = 0;
            int status = 0;

            //if (ant1.Checked)
                ant_sel |= 0x01;
            //if (ant2.Checked)
                ant_sel |= 0x02;
            //if (ant3.Checked)
                ant_sel |= 0x04;
            //if (ant4.Checked)
                ant_sel |= 0x08;

            status = Reader1.SetAnt(ant_sel);
            if (status != 0)
            {
                lInfo.Items.Add("Set ant failed!");
                return;
            }
            lInfo.Items.Add("Set ant success!");
        }

       private void timer1_Tick_1(object sender, EventArgs e)
        {
            /*label3.Text = "当前时间：" + DateTime.Now.ToString();
            label4.Text = DateTime.Now.ToLongTimeString();//得到现在的时间
            switch (label4.Text)
            {
                // public int Flag = 1;// 0：时间段内  1：时间段外
                //public int Flag1 = 0;//0：还没有刷过卡，可以刷卡  1：刷过了，不能再刷了
                //case "21:34:00":
                //    Flag = 0;
                //    Flag1 = 0;
                //    MessageBox.Show("现在是:" + DateTime.Now.ToShortTimeString() + "该吃药了，请刷卡！");
                //    break;
                //case "21:35:00":
                //    Flag = 1;
                //    break;
                //case "21:36:00":
                //    Flag = 0;
                //    Flag1 = 0;
                //    MessageBox.Show("现在是:" + DateTime.Now.ToShortTimeString() + "该吃药了，请刷卡！");
                //    break;
                //case "21:37:00":
                //    Flag = 1;
                //    break;
                case "21:47:00":
                    Flag = 0;
                    Flag1 = 0;
                    MessageBox.Show("现在是:" + DateTime.Now.ToShortTimeString() + "该吃药了，请刷卡！");
                    break;
                case "21:48:00":
                    Flag = 1;
                    break;
            }*/
            
        }


        private void btnDetail_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void ant1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cEpcTimes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cEpcWordptr_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    

        private void tIp_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void tEpcKill_TextChanged(object sender, EventArgs e)
        {

        }


        private void cEpcMembank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvTagList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void cRfFreq_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1(object sender, EventArgs e)
        {

        }

        private void lInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       
        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        
        private void chkFilter_CheckedChanged(object sender, EventArgs e)
        {

        }

        
    }
}