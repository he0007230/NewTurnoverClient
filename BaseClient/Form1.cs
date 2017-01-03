using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using ArmAssistBll;
using OpenNETCF.Net.NetworkInformation;
using SYNCC;
using System.Threading;

namespace BaseClient
{
    public partial class Form1 : Form
    {
        private string _stockNo;
        private string _workerNo;
        private TextBox _nowControlModule;    //��ǰ��ȡ����Ŀؼ�
        private TextBox _nextControlModule;   //��һ������ؼ�
        private int _nowRunningState;        //��ǰ����״̬
        private string _codeStr;
        private int _pFlag;
        private string _outStr;
        //private NLSScanner scanCode = new NLSScanner();
        TcpClient m_socketClient;
        private int _ConnectTimeOut;
        private string _stockName;
        private string _workerName;
        private string _applicationName;
        private string _serverIP;
        private int _serverPort;
        private int _oldTime;
        private string _IpAddress;
        private string _barcode;
        private string _temporary;
        private string _lastMessage;
        private string _srFlag;
        private List<string> _matchList;
        private List<string> _outStrList;
        private bool _connFlag;

        // 2M �Ľ��ջ�������Ŀ����һ�ν�������������ص���Ϣ
        byte[] m_receiveBuffer = new byte[2048 * 1024];

        private bool _cFlag;
        private SYSTEM_POWER_STATUS_EX status;

        [DllImport("coredll.Dll")]
        public static extern int SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        [DllImport("coredll.Dll")]
        public static extern void SetForegroundWindow(IntPtr hwnd);

        [DllImport("coredll.dll", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(IntPtr hWnd, Int32 nCmdShow);
        public const int SW_SHOW = 5; public const int SW_HIDE = 0;
        [DllImport("Coredll.dll", EntryPoint = "GetTickCount")]
        private static extern int GetTickCount();

        private class SYSTEM_POWER_STATUS_EX
        {
            public byte ACLineStatus = 0;
            public byte BatteryFlag = 0;
            public byte BatteryLifePercent = 0;
            public byte Reserved1 = 0;
            public uint BatteryLifeTime = 0;
            public uint BatteryFullLifeTime = 0;
            public byte Reserved2 = 0;
            public byte BackupBatteryFlag = 0;
            public byte BackupBatteryLifePercent = 0;
            public byte Reserved3 = 0;
            public uint BackupBatteryLifeTime = 0;
            public uint BackupBatteryFullLifeTime = 0;
        }
        [DllImport("coredll")]
        private static extern int GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX lpSystemPowerStatus, bool fUpdate);

        public Form1()
        {
            InitializeComponent();
            Init();
        }
        /// <summary>
        /// ��ȡ���еĺ�����
        /// </summary>
        /// <returns></returns>
        private int GetTick()
        {
            return GetTickCount();
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        private int GetPower()
        {
            if (GetSystemPowerStatusEx(status, false) == 1)
            {
                if (status.BatteryLifePercent > 100)
                    status.BatteryLifePercent = 100;
                return status.BatteryLifePercent;
            }
            else
            {
                return -1;
            }
        }


        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="msg"></param>
        private void ShowMessage(string msg, string title)
        {
            /*
            try
            {
                //_nextControlModule = _nowControlModule;
                // _nowControlModule = null;
                //MessageBox.Show("test","error");
                MessageBox.Show(msg, title);
                //_nowControlModule = _nextControlModule;
            }
            catch (Exception e)
            {
                MessageBox.Show("�������:" + e.Message, "����");
            }
             * */
        }

        /// <summary>
        /// ���ܷ�������
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private string DecryInt(string code)
        {
            string mapping = "1389602457138960245713896024571389602457138960245713896024571389602457138960245713896024571389602457";
            string decry_code = "";
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (mapping[j] == code[i])
                        {
                            decry_code += j.ToString();
                        }
                    }
                }
                int offset = int.Parse(decry_code);
                //ShowMessage(decry_code);
                for (int i = 3; i < code.Length - 1; i++)
                {
                    for (int j = offset; j < 10 + offset; j++)
                    {
                        if (mapping[j] == code[i])
                        {
                            decry_code += (j - offset).ToString();
                        }
                    }
                }
                //ShowMessage(decry_code);
                string decry = "";
                for (int i = 1; i < 4; i++)
                {
                    //decry += Convert.ToString(int.Parse(decry_code.Substring(3 * i, 3)),16);
                    //decry += String.Format("{0:X}", int.Parse(decry_code.Substring(3 * i, 3)));
                    decry += int.Parse(decry_code.Substring(3 * i, 3)).ToString("X2");
                }
                //ShowMessage(decry);
                return decry;
            }
            catch
            {
                return "";
            }

        }

        /// <summary>
        /// У������
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool CheckBarCode(string code)
        {
            int mOdd = 0;
            int mEven = 0;
            int mNumber = 0;
            for (int i = 1; i < code.Length; i++)
            {
                mNumber = int.Parse(code[i - 1].ToString());
                if (i % 2 == 0)
                {
                    mEven += mNumber;
                }
                else
                {
                    mOdd += mNumber;
                }
            }
            mEven *= 3;
            mNumber = mOdd + mEven;
            mNumber = (10 - (mNumber % 10)) % 10;
            if (mNumber.ToString() == code[code.Length - 1].ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ˢ�µ���
        /// </summary>
        private void ShowPower()
        {
            // statusBar1.Text = "����:" + NLSSysInfo.GetPowerPercent().ToString() + "%";
            //statusBar1.Text = GetTick().ToString();
            //statusBar1.Text = "�û�:" + _workerName + "    |����:" + GetPower() + "%";
            statusBar1.Text = _serverIP.Substring(_serverIP.Length - 3, 3) + "�û�:" + _workerName + "   | ����:" + GetPower();
        }

        /// <summary>
        /// �µ�ͨ�ŷ�ʽ
        /// </summary>
        private void NewTransmit()
        {
            string msg;
            if (!WifiCtrl.GetInstance().isConnectWifi(_IpAddress, out msg))
            {
                //MessageBox.Show(msg + ",�뻻���ط����¿���!");
                _outStr = msg;
                return;
            }
            CompactFormatter.TransDTO transDTO = new CompactFormatter.TransDTO();
            transDTO.AppName = _applicationName;
            transDTO.CodeStr = _codeStr;
            transDTO.IP = _IpAddress;
            transDTO.pFlag = _pFlag;
            transDTO.StockNo = _stockNo;
            transDTO.Remark = msg;
            NetWorkScript.Instance.write(1, 1, 1, transDTO);
            NetWorkScript.Instance.AsyncReceive();
            if (NetWorkScript.Instance.messageList.Count > 0)
            {
                SocketModel socketModel = NetWorkScript.Instance.messageList[0];
                NetWorkScript.Instance.messageList.RemoveAt(0);
                _outStr = socketModel.message.ToString();
                _connFlag = true;

            }
            else
            {
                NetWorkScript.Instance.release();
                if (_connFlag)
                {
                    _connFlag = false;
                    Thread.Sleep(2000);
                    NewTransmit();
                }
                else
                {
                    _outStr = "û�з�����Ϣ!";
                }
            }
        }


        /// <summary>
        /// �����ʼ��
        /// </summary>
        private void Init()
        {
            //SetWindowPos(this.Handle, -1, 0, 0, 0, 0, 1 | 2);
            //ShowWindow(this.Handle,SW_SHOW);
            // SetForegroundWindow(this.Handle);
            status = new SYSTEM_POWER_STATUS_EX();
            _lastMessage = "�����ɹ��ĵ�����ϸ^������Ʒ:0^��ת�ļ�:0";
            _oldTime = 0;
            _workerNo = "";
            _stockNo = "";
            _outStr = "";
            _codeStr = "";
            _stockName = "";
            _workerName = "";
            _barcode = "";
            _temporary = "";
            _srFlag = "00";
            //todo
            _applicationName = "TurnoverClient";
            _cFlag = true;
            _pFlag = 1;
            _nowRunningState = 99;
            _nowControlModule = tb_worker_no;
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(login);
            tb_worker_no.Focus();
            _matchList = new List<string>();
            _outStrList = new List<string>();
            _connFlag = true;
            //tabControl1.Focus();
            XmlDocument xml = new XmlDocument();
            xml.Load("\\Program Files\\CONFIG.XML");
            try
            {
                ProcessInfo[] list = ProcessCE.GetProcesses();
                foreach (ProcessInfo item in list)
                {
                    if (item.FullPath.IndexOf("AutoUpdate") > 0)
                    {
                        item.Kill();
                    }
                }
                _serverIP = xml.SelectSingleNode("/Root/System/server_ip").InnerText;
                _serverPort = int.Parse(xml.SelectSingleNode("/Root/System/server_port").InnerText);
                _stockName = xml.SelectSingleNode("/Root/System/stock_name").InnerText;
                _stockNo = xml.SelectSingleNode("/Root/System/stock_no").InnerText;
                _ConnectTimeOut = int.Parse(xml.SelectSingleNode("/Root/System/maxSessionTimeout").InnerText) * 1000;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����");
            }
            ShowPower();
            try
            {
                _IpAddress = WifiCtrl.GetInstance().GetWifiStatus().CurrentIpAddress.ToString();
                if (_IpAddress == "0.0.0.0")
                {
                    _IpAddress = IPHelper.GetIpAddress();
                }
            }
            catch
            {
                _IpAddress = IPHelper.GetIpAddress();
            }

        }

        /// <summary>
        /// ���ӷ�����
        /// </summary>
        private void Connect()
        {
            //lock (this)
            //{
                //try
                //{
                    //m_socketClient = new TcpClient(_serverIP, _serverPort);
                   // m_socketClient.ReceiveTimeout = 5 * 1000;
               // }
                //catch 
               // {
               // }
           // }
            //_oldTime = GetTick();
        }

        /// <summary>
        /// ��������Ͽ�����
        /// </summary>
        private void Disconnect()
        {
            //lock (this)
           // {
                //if (m_socketClient == null)
                //{
               //     return;
               // }

              //  try
              //  {
                //    m_socketClient.Close();
                    //this.AddInfo("�Ͽ����ӳɹ���");
              //  }
               // catch
              //  {
                    //this.AddInfo("�Ͽ�����ʱ����: " + err.Message);
                    // ShowMessage("�Ͽ�����ʱ����: " + err.Message,"����");
              //  }
              //  finally
              //  {
                //    m_socketClient = null;
              //      _oldTime = 0;
              //  }
           // }
        }

        /// <summary>
        /// ��ʾ��Ϣ
        /// </summary>
        /// <param name="message"></param>
        private void AddInfo(string message,int state)
        {
            ShowPower();
            //ShowMessage(msg, "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            tb_ResultShow.Text = "";
            if (message.Length == 0)
            {
                //ShowMessage("�޷�����Ϣ��","����");
                //tb_ResultShow.Text = "�޷�����Ϣ��";
                return;
            }
            else
            {
                string[] msg = message.Split('^');
                foreach (string str in msg)
                {
                    tb_ResultShow.Text = tb_ResultShow.Text + str + "\r\n";
                }
            }
            if (state == 11)
            {
                tb_ResultShow.Text += "\r\n��ѡ����һ������\r\n  ��1������\r\n  ��2�����";
            }
            else if (state == 12)
            {
                tb_ResultShow.Text += "\r\n��ѡ����һ������\r\n  ��4����\r\n  ��5����";
            }
            else
            {
                tb_ResultShow.Text += "\r\n\r\n��1ȷ�ϴ�����";
            }
            //tb_ResultShow.Text += Test();
            p_msg.Visible = true;
            _nextControlModule = _nowControlModule;
            _nowControlModule = tb_Confirm;
            tb_Confirm.Focus();
            buz_on();
            
            if (message.IndexOf("�ɹ�") == -1)
            {
                tb_ResultShow.BackColor = Color.Red;
                //ShowMessage(textBox8.BackColor.ToString(),"color");
                buz_on();
            }
            else
            {
                tb_ResultShow.BackColor = Color.Green;
            }
            //_outStr="";
            if (_outStrList.Count > 0)
            {
                _outStrList.RemoveAt(0);
            }

        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        private void SendOneDatagram()
        {
            if (GetTick() > (_oldTime + _ConnectTimeOut))
            {
                if (m_socketClient != null)
                {
                    this.Disconnect();
                }
                this.Connect();
            }

            string datagramText2 = "1#" + _pFlag + "#" + _codeStr + "#" + _applicationName + "#" + _stockNo;

            byte[] b = Encoding.UTF8.GetBytes(datagramText2);//����ָ�����뽫string����ֽ�����
            string datagramText = string.Empty;
            for (int i = 0; i < b.Length; i++)//���ֽڱ�Ϊ16�����ַ�����%����
            {
                datagramText += "%" + Convert.ToString(b[i], 16);
            }

            //byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(datagramText);
            //datagramText = Convert.ToBase64String(encbuff);
            //if (ShowMessage(datagramText, "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //Application.Exit();
            //}
            //datagramText = textBox1.Text + "#" + textBox2.Text + "#" + textBox3.Text + "|" + textBox4.Text + "|" + textBox5.Text + "|";
            //datagramText += textBox6.Text + "|" + textBox8.Text + "|" + textBox7.Text + "|#";

            byte[] Cmd = Encoding.ASCII.GetBytes(datagramText);
            byte check = (byte)(Cmd[0] ^ Cmd[1]);
            for (int i = 2; i < Cmd.Length; i++)
            {
                check = (byte)(check ^ Cmd[i]);
            }
            datagramText = "<" + datagramText + (char)check + ">";
            byte[] datagram = Encoding.ASCII.GetBytes(datagramText);

            try
            {
                m_socketClient.Client.Send(datagram);
                //this.AddInfo("send text = " + datagramText);

                //if (ck_AsyncReceive.Checked)  // �첽���ջش�
                // {
                //m_socketClient.Client.BeginReceive(m_receiveBuffer, 0, m_receiveBuffer.Length, SocketFlags.None, this.EndReceiveDatagram, this);
                //}
                // else
                // {
                this.Receive();
                //}
            }
            catch (Exception err)
            {
                if (_cFlag)
                {
                    _cFlag = false;
                    if (m_socketClient != null)
                    {
                        this.Disconnect();
                    }
                    this.Connect();
                    try
                    {
                        m_socketClient.Client.Send(datagram);
                        this.Receive();
                    }
                    catch { }

                }
                else
                {
                    //this.AddInfo("���ʹ���: " + err.Message);
                    ShowMessage("���ӷ�����ʧ��: " + err.Message, "����");
                    //this.AddInfo("���ӷ�����ʧ��:!\r\n" + err.Message);
                    _outStr = "";
                    this.CloseClientSocket();
                    _oldTime = 0;
                }

            }
        }

        private void Receive()
        {
            try
            {
                int len = m_socketClient.Client.Receive(m_receiveBuffer, 0, m_receiveBuffer.Length, SocketFlags.None);
                if (len > 0)
                {
                    CheckReplyDatagram(len);
                }
                _oldTime = GetTick();
            }
            catch (Exception err)
            {
                //this.AddInfo("���մ���: " + err.Message);
                ShowMessage("���մ���: " + err.Message, "����");
                this.CloseClientSocket();
                _oldTime = 0;
            }
        }

        private void CheckReplyDatagram(int len)
        {
            string datagramText = Encoding.ASCII.GetString(m_receiveBuffer, 0, len);
            //byte[] decbuff = Convert.FromBase64String(replyMesage);
            if (datagramText[0] != '%')
            {
                _outStr = "���ص���Ϣ����";
                return;
            }
            string[] chars = datagramText.Substring(1, datagramText.Length - 1).Split('%');
            byte[] b = new byte[chars.Length];
            //����ַ���Ϊ16�����ֽ�����
            for (int i = 0; i < chars.Length; i++)
            {
                b[i] = Convert.ToByte(chars[i], 16);
            }
            //����ָ�����뽫�ֽ������Ϊ�ַ���
            //string content = Encoding.UTF8.GetString(b);
            _outStr = Encoding.UTF8.GetString(b, 0, b.Length);
            //this.AddInfo(replyMesage);
        }

        /// <summary>
        /// �رտͻ�������
        /// </summary>
        private void CloseClientSocket()
        {
            try
            {
                //m_socketClient.Client.Shutdown(SocketShutdown.Both);
                m_socketClient.Client.Close();
                m_socketClient.Close();
            }
            catch
            {
            }
            finally
            {
                m_socketClient = null;
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        private void buz_on()
        {
            /*
            int m_iFreq = 2730;
            int m_iVolume = 60;
            int m_iMdelay = 300;
            int m_iBuzCtrlRe = -1;
            m_iBuzCtrlRe = NLSSysCtrl.buz_ctrl(m_iFreq, m_iVolume, m_iMdelay);
            NLSSysCtrl.vibrator_ctrl(m_iMdelay);
             * */
            //Sound sound = new Sound("Program Files//GoodsHandle//buz.wav");
            //sound.Play();

        }

        /// <summary>
        /// �˳�����
        /// </summary>
        public void Quit()
        {
            if (MessageBox.Show("�Ƿ��˳�?", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                _nowControlModule = null;
                _nextControlModule = null;
                this.Disconnect();
                ProcessContext pi = new ProcessContext();
                ProcessCE.CreateProcess("\\Program Files\\AutoUpdate\\AutoUpdate.exe",
                                  "", IntPtr.Zero,
                                  IntPtr.Zero, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, pi);
                Thread.Sleep(2500);
                Application.Exit();
            }
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsLostFocus(object sender, EventArgs e)
        {
            if (_nowControlModule != null)
            {
                _nowControlModule.Focus();
            }
            else
            {
                _nowControlModule = tb_ui;
                tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(main);
                _nowRunningState = 0;
                tb_ui.Focus();
            }
        }

        /// <summary>
        /// �������ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_Confirm_KeyUp(object sender, KeyEventArgs e)
        {
            /*
            if (e.KeyCode == Keys.D1)
            {
                
                try
                {
                    _pFlag = 4;
                    string codestr = _codeStr.Replace("|", "_");
                    _codeStr = _serialNo + "|" + _applicationName + "|" + _stockNo + "|" + codestr + "|" + textBox8.Text + "|" + _workerNo + "|";
                    SendOneDatagram();
                }
                catch
                {
                    ShowMessage(_outStr, "����");
                }
                finally
                {
                    tb_Confirm.Text = "";
                    tb_ResultShow.Text = "";
                    _nowControlModule = _nextControlModule;
                    p_msg.Visible = false;
                    _nowControlModule.Text = "";
                    _nowControlModule.Focus();
                    _codeStr = "";
                    _outStr = "";
                    tb_ResultShow.BackColor = Color.Yellow;
                }
            }
             * */
            if (e.KeyCode == Keys.D1 && _nowRunningState != 12)
            {
                ConfirmFinished();
            }
            else if (e.KeyCode == Keys.D2 && _nowRunningState == 11) //��ת����������ĺ˶Խ���
            {

                if (_srFlag == "01")
                {
                    _nowRunningState = 3;
                    _matchList.Clear();
                    _outStrList.Clear();
                    lbl_match_count.Text = "��������ת�嵥����" + _matchList.Count;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(Func3);
                    _nextControlModule = tb_func3_batch;
                    ConfirmFinished();
                    
                }
                else
                {
                    p_func1_check.Visible = true;
                    _nextControlModule = tb_func1_workerNo;
                    _nowRunningState = 111;
                    ConfirmFinished();
                }
            }
            else if (e.KeyCode == Keys.D4 && _nowRunningState == 12)
            {
                _nowRunningState = 1;
                _nowControlModule = _nextControlModule;
                p_msg.Visible = false;
                tb_Confirm.Text = "";
                tb_ResultShow.Text = "";
                _outStr = "";
                _codeStr = _barcode + "|" + _stockNo + "|" + _stockName + "|" + _workerNo + "|121|" + _srFlag + "|";
                //SendOneDatagram();
                NewTransmit();
                string[] data = _outStr.Split('@');
                if (data.Length > 1)
                {
                    _nowRunningState = int.Parse(data[1]);
                    string[] tmp = data[0].Split('^');
                    tb_func1_msg.Text = tmp[2] + "\r\n" + tmp[3] + "\r\n";
                    if (data[1] == "0")
                    {
                        _nowRunningState = 1;
                        _lastMessage = "�����ɹ��ĵ�����ϸ^������Ʒ:0^��ת�ļ�:0";
                    }
                    else
                    {
                        _nowRunningState = int.Parse(data[1]);
                        _lastMessage = "�����ɹ��ĵ�����ϸ^^"+tmp[2]+"^"+tmp[3];
                    }
                    AddInfo(data[0], _nowRunningState);
                }
                else
                {
                    AddInfo(_outStr,1);
                }
                
            }
            else if (e.KeyCode == Keys.D5 && _nowRunningState == 12)
            {
                _nowRunningState = 1;
                ConfirmFinished();
            }
            if (_outStrList.Count > 0)
            {
                AddInfo(_outStrList[0],_nowRunningState);
            }
        }
        /// <summary>
        /// ȷ�ϲ�������󴥷�
        /// </summary>
        void ConfirmFinished()
        {
            try
            {
                _pFlag = 4;
                string codestr = _codeStr.Replace("|", "_");
                _codeStr = _IpAddress + "|" + _applicationName + "|" + _stockNo + "|" + codestr + "|" + _outStr + "|" + _workerNo + "|";
                //SendOneDatagram();
                NewTransmit();
            }
            catch
            {
            }
            tb_Confirm.Text = "";
            tb_ResultShow.Text = "";
            _nowControlModule = _nextControlModule;
            p_msg.Visible = false;
            _nowControlModule.Text = "";
            _nowControlModule.Focus();
            _codeStr = "";
            _outStr = "";
        }
        /// <summary>
        /// ��������ת
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_ui_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    _srFlag = "01";
                    _nowRunningState = 1;
                    _lastMessage = "�����ɹ��ĵ�����ϸ^������Ʒ:0^��ת�ļ�:0";
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(Func1);
                    _nowControlModule = tb_func1_focus;
                    tb_func1_focus.Focus();
                    break;
                case Keys.D2:
                    _srFlag = "02";
                    _nowRunningState = 1;
                    _lastMessage = "�����ɹ��ĵ�����ϸ^������Ʒ:0^��ת�ļ�:0";
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(Func1);
                    _nowControlModule = tb_func1_focus;
                    tb_func1_focus.Focus();
                    break;
                case Keys.D3:
                    _nowRunningState = 3;
                    _matchList.Clear();
                    _outStrList.Clear();
                    lbl_match_count.Text = "��������ת�嵥����" + _matchList.Count;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(Func3);
                    _nowControlModule = tb_func3_batch;
                    tb_func1_focus.Focus();
                    break;
                case Keys.D4:
                    _nowRunningState = 2;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(Func2);
                    _nowControlModule = tb_func2_sealNo;
                    tb_func2_sealNo.Focus();
                    break;
                case Keys.D5:
                    _nowRunningState = 99;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(login);
                    _nowControlModule = tb_worker_no;
                    tb_worker_no.Focus();
                    break;
            }
        }
        /// <summary>
        /// ��¼����-�����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_worker_no_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (tb_worker_no.Text.Length > 0)
                    {
                        _nowControlModule = tb_password;
                        tb_password.Focus();
                    }
                    break;
                case Keys.Escape:
                    if (tb_worker_no.Text == "")
                    {
                        Quit();
                    }
                    else
                    {
                        tb_worker_no.Text = "";
                    }
                    break;
            }
        }

        /// <summary>
        /// �û���¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_password_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (tb_password.Text.Length > 0)
                    {
                        //todo
                        _pFlag = 2;
                        _codeStr = tb_worker_no.Text + "|" + tb_password.Text + "|" + _stockNo + "|";
                        //SendOneDatagram();
                        NewTransmit();
                        string[] data = _outStr.Split('#');
                        if (data[0] == "SUCCESS")
                        {
                            _workerNo = tb_worker_no.Text;
                            _workerName = data[1];
                            _nowControlModule = tb_ui;
                            //todo
                            ShowPower();
                            //statusBar2.Text = "�û�:" + _workerName + "    | ����:" + GetPower();
                            //buz_on();
                            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(main);
                            _nowRunningState = 0;
                            tb_ui.Focus();
                            //this.AddInfo("��¼�ɹ�");
                            //textBox9.Focus();
                        }
                        else
                        {
                            _nowControlModule = tb_worker_no;
                            this.AddInfo(_outStr,_nowRunningState);
                        }
                        tb_worker_no.Text = "";
                        tb_password.Text = "";
                    }
                    break;
                case Keys.Escape:
                    if (tb_password.Text == "")
                    {
                        _nowControlModule = tb_worker_no;
                        tb_worker_no.Focus();
                    }
                    else
                    {
                        tb_password.Text = "";
                    }
                    break;
            }
        }

        /// <summary>
        /// ��ת����-ɨ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_func1_focus_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_func1_focus.Text.Length == 13)
                {
                    _pFlag = 15;
                    _codeStr = tb_func1_focus.Text + "|" + _stockNo + "|" + _stockName + "|" + _workerNo + "|" + _nowRunningState + "|" + _srFlag + "|";
                    _barcode = tb_func1_focus.Text;
                    //SendOneDatagram();
                    NewTransmit();
                    string[] data = _outStr.Split('@');
                    if (data.Length > 1)
                    {
                        string[] tmp = data[0].Split('^');
                        tb_func1_msg.Text = tmp[2] + "\r\n" + tmp[3] + "\r\n";
                        if (data[1] == "0")
                        {
                            _nowRunningState = 1;
                            _lastMessage = "�����ɹ��ĵ�����ϸ^������Ʒ:0^��ת�ļ�:0";
                        }
                        else
                        {
                            _nowRunningState = int.Parse(data[1]);
                            _lastMessage = "�����ɹ��ĵ�����ϸ^" + tmp[2] + "^" + tmp[3];
                        } 
                        AddInfo(data[0], _nowRunningState);

                    }
                    else
                    {
                        AddInfo(_outStr,1);
                    }

                }
                else if ((tb_func1_focus.Text.Length == 0) && (_lastMessage.Length > 0))
                {
                    _nowRunningState = 11;
                    AddInfo(_lastMessage, _nowRunningState);
                }
                tb_func1_focus.Text = "";
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (tb_func1_focus.Text.Length > 0)
                {
                    tb_func1_focus.Text = "";
                }
                else
                {
                    //if (_lastMessage == "")
                    //{
                        _nowControlModule = tb_ui;
                        tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(main);
                        _nowControlModule.Focus();
                    //}
                   // else
                   // {
                       // _nowRunningState = 11;
                      //  AddInfo(_lastMessage, _nowRunningState);
                    //}
                }
            }
        }

        /// <summary>
        /// ��ת����-�������Ա����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_func1_workerNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_func1_workerNo.Text.Length == 0)
                {
                    tb_func1_workerNo.Text = "000000";
                }
                _nowRunningState = 1;
                _pFlag = 16;
                _codeStr = _stockNo + "|" + _stockName + "|" + tb_func1_workerNo.Text + "|000000|" + _srFlag + "|";
                //SendOneDatagram();
                NewTransmit();
                ClearFunc1Check();
                if (_outStr.IndexOf("�ɹ�") > 0)
                {
                    _lastMessage = "�����ɹ��ĵ�����ϸ^������Ʒ:0^��ת�ļ�:0";
                    p_func1_check.Visible = false;
                    tb_func1_msg.Text = "������Ʒ:0\r\n��ת�ļ�:0";
                    _nowRunningState = 0;
                    _nowControlModule = tb_ui;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(main);
                }
                else
                {
                    _nowControlModule = tb_func1_workerNo;
                }
                AddInfo(_outStr, _nowRunningState);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (tb_func1_workerNo.Text.Length > 0)
                {
                    tb_func1_workerNo.Text = "";
                }
                else
                {
                    _nowControlModule = tb_func1_focus;
                    p_func1_check.Visible = false;
                    _nowControlModule.Focus();
                    tb_func1_msg.Text = "";
                }
            }
        }
        /*
        /// <summary>
        /// ��ת����-����˾������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_func1_driverNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_func1_driverNo.Text.Length == 0)
                {
                    tb_func1_driverNo.Text = "000000";
                }
                _nowRunningState = 1;
                _pFlag = 16;
                _codeStr = _stockNo + "|" + _stockName + "|" + tb_func1_workerNo.Text + "|" + tb_func1_driverNo.Text + "|" + _srFlag + "|";
                SendOneDatagram();
                ClearFunc1Check();
                if (_outStr.IndexOf("�ɹ�") > 0)
                {
                    _lastMessage = "�����ɹ��ĵ�����ϸ^������Ʒ:0^��ת�ļ�:0";
                    p_func1_check.Visible = false;
                    tb_func1_msg.Text = "������Ʒ:0\r\n��ת�ļ�:0";
                    _nowRunningState = 0;
                    _nowControlModule = tb_ui;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(main);
                }
                else
                {
                    _nowControlModule = tb_func1_workerNo;
                }
                AddInfo(_outStr,_nowRunningState);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (tb_func1_driverNo.Text.Length > 0)
                {
                    tb_func1_driverNo.Text = "";
                }
                else
                {
                    _nowControlModule = tb_func1_workerNo;
                    _nowControlModule.Focus();
                }
            }

        }
         * */
        /// <summary>
        /// �����ת����-�����˶Խ����е���������
        /// </summary>
        private void ClearFunc1Check()
        {
            tb_func1_workerNo.Text = "";
            //tb_func1_driverNo.Text = "";
        }

        /// <summary>
        /// ��������-ɨ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_func2_sealNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_func2_sealNo.Text.Length == 6)
                {
                    _temporary = "(����)";
                    _nowControlModule = tb_func2_bar;
                    _nowControlModule.Focus();
                }
                if (tb_func2_sealNo.Text.Length == 13)
                {
                    tb_func2_sealNo.Text = DecryInt(tb_func2_sealNo.Text);
                    if (tb_func2_sealNo.Text.Length == 6)
                    {
                        _temporary = "";
                        _nowControlModule = tb_func2_bar;
                        _nowControlModule.Focus();
                    }
                }
            }
            else if(e.KeyCode==Keys.Escape)
            {
                if (tb_func2_sealNo.Text.Length > 0)
                {
                    tb_func2_sealNo.Text = "";
                }
                else
                {
                    _nowRunningState = 0;
                    _nowControlModule = tb_ui;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(main);
                    _nowControlModule.Focus();
                }
            }
        }

        /// <summary>
        /// ��������-ɨ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_func2_bar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_func2_bar.Text.Length == 13)
                {
                    _nowControlModule = tb_func2_workerNo;
                    _nowControlModule.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (tb_func2_bar.Text.Length > 0)
                {
                    tb_func2_bar.Text = "";
                }
                else
                {
                    _nowControlModule = tb_func2_sealNo;
                    _nowControlModule.Focus();
                }
            }

        }

        /// <summary>
        /// ��������-ɨ�����Ա����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_func2_workerNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_func2_workerNo.Text.Length > 0)
                {
                    _nowControlModule = tb_func2_sealType;
                    _nowControlModule.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (tb_func2_bar.Text.Length > 0)
                {
                    tb_func2_bar.Text = "";
                }
                else
                {
                    _nowControlModule = tb_func2_bar;
                    _nowControlModule.Focus();
                }
            }
        }

        /// <summary>
        /// ��������-ѡ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_func2_sealType_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
            {
                    _pFlag = 17;
                    _codeStr = tb_func2_bar.Text + "|" + tb_func2_sealNo.Text + "|01|�Ϸ���" + _temporary + "|";
                    _codeStr += tb_func2_workerNo.Text + "|" + _stockNo + "|" + _stockName + "|";
                    //SendOneDatagram();
                    NewTransmit();
                    _nowControlModule = tb_func2_sealNo;
                    tb_func2_sealNo.Text = "";
                    tb_func2_bar.Text = "";
                    tb_func2_workerNo.Text = "";
                    AddInfo(_outStr,_nowRunningState);
            }
            else if (e.KeyCode == Keys.D2)
            {
                _pFlag = 17;
                _codeStr = tb_func2_bar.Text + "|" + tb_func2_sealNo.Text + "|02|�����" + _temporary + "|";
                _codeStr += tb_func2_workerNo.Text + "|" + _stockNo + "|" + _stockName + "|";
                //SendOneDatagram();
                NewTransmit();
                _nowControlModule = tb_func2_sealNo;
                tb_func2_sealNo.Text = "";
                tb_func2_bar.Text = "";
                tb_func2_workerNo.Text = "";
                AddInfo(_outStr,_nowRunningState);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (tb_func2_workerNo.Text.Length > 0)
                {
                    tb_func2_workerNo.Text = "";
                }
                else
                {
                    _nowControlModule = tb_func2_bar;
                    _nowControlModule.Focus();
                }
            }
            tb_func2_sealType.Text = "";

        }

        /// <summary>
        /// ˾��ȷ�� ������ת�嵥
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tb_func3_batch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (tb_func3_batch.Text.Length == 0)
                {
                    _nowControlModule = tb_func3_driver;
                    tb_func3_driver.Focus();
                }
                else if (tb_func3_batch.Text.Length == 13)
                {
                    _matchList.Add(tb_func3_batch.Text);
                    lbl_match_count.Text = "��������ת�嵥����" + _matchList.Count;
                    tb_func3_batch.Text = "";
                }
                
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (tb_func3_batch.Text.Length > 0)
                {
                    tb_func3_batch.Text = "";
                }
                else
                {
                    _nowRunningState = 0;
                    _nowControlModule = tb_ui;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(main);
                    _nowControlModule.Focus();
                }

            }
        }

        /// <summary>
        /// ˾��ȷ�� ����˾������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_func3_driver_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_func3_driver.Text.Length == 0)
                {
                    tb_func3_driver.Text = "000000";
                    _nowControlModule = tb_func3_srflag;
                    tb_func3_srflag.Focus();
                }
                else if (tb_func3_driver.Text.Length == 13)
                {
                    _nowControlModule = tb_func3_srflag;
                    tb_func3_srflag.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (tb_func3_driver.Text.Length > 0)
                {
                    tb_func3_driver.Text = "";
                }
                else
                {
                    _nowControlModule = tb_func3_batch;
                    tb_func3_batch.Focus();
                }
            }

        }

        /// <summary>
        /// ˾��ȷ�� ѡ����ջ򷢳�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_func3_srflag_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    _pFlag = 21;
                    _matchList.Clear();
                    _codeStr = "0000000000000|" + tb_func3_driver.Text + "|01|" + _workerNo + "|" + _stockNo + "|";
                    //SendOneDatagram();
                    NewTransmit();
                    _nowControlModule = tb_func3_batch;
                    tb_func3_batch.Text = "";
                    tb_func3_driver.Text = "";
                    tb_func3_srflag.Text = "";
                    AddInfo(_outStr, _nowRunningState);
                    break;
                case Keys.D2:
                    _outStrList.Clear();
                    while (_matchList.Count > 0)
                    {
                        _pFlag = 21;
                        _codeStr = _matchList[0] + "|" + tb_func3_driver.Text + "|02|" + _workerNo + "|" + _stockNo + "|";
                        _matchList.RemoveAt(0);
                        //SendOneDatagram();
                        NewTransmit();
                        _outStrList.Add(_outStr);
                    }
                    //_nowControlModule = tb_func3_batch;
                    tb_func3_batch.Text = "";
                    tb_func3_driver.Text = "";
                    tb_func3_srflag.Text = "";

                    _nowRunningState = 0;
                    _nowControlModule = tb_ui;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(main);
                    if (_outStrList.Count > 0)
                    {
                        AddInfo(_outStrList[0], _nowRunningState);
                    }
                    else
                    {
                        AddInfo("��ɨ����ת�嵥!", _nowRunningState);
                    }
                    //tb_func3_batch.Focus();
                    break;
                case Keys.Escape:
                    _nowControlModule = tb_func3_driver;
                    tb_func3_srflag.Text = "";
                    tb_func3_driver.Focus();
                    break;

            }

        }


    }
}