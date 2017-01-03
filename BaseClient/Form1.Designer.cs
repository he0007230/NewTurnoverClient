namespace BaseClient
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
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.label6 = new System.Windows.Forms.Label();
            this.p_msg = new System.Windows.Forms.Panel();
            this.tb_ResultShow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Confirm = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.login = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_worker_no = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.main = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ui = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Func1 = new System.Windows.Forms.TabPage();
            this.p_func1_check = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_func1_workerNo = new System.Windows.Forms.TextBox();
            this.tb_func1_msg = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_func1_focus = new System.Windows.Forms.TextBox();
            this.Func2 = new System.Windows.Forms.TabPage();
            this.tb_func2_sealType = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_func2_workerNo = new System.Windows.Forms.TextBox();
            this.tb_func2_bar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_func2_sealNo = new System.Windows.Forms.TextBox();
            this.Func3 = new System.Windows.Forms.TabPage();
            this.lbl_match_count = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tb_func3_srflag = new System.Windows.Forms.TextBox();
            this.tb_func3_driver = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tb_func3_batch = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.p_msg.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.login.SuspendLayout();
            this.main.SuspendLayout();
            this.Func1.SuspendLayout();
            this.p_func1_check.SuspendLayout();
            this.Func2.SuspendLayout();
            this.Func3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.statusBar1.Location = new System.Drawing.Point(0, 295);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(235, 27);
            this.statusBar1.Text = "statusBar1";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            // 
            // p_msg
            // 
            this.p_msg.Controls.Add(this.tb_ResultShow);
            this.p_msg.Controls.Add(this.label1);
            this.p_msg.Controls.Add(this.tb_Confirm);
            this.p_msg.Location = new System.Drawing.Point(0, 27);
            this.p_msg.Name = "p_msg";
            this.p_msg.Size = new System.Drawing.Size(235, 268);
            this.p_msg.Visible = false;
            // 
            // tb_ResultShow
            // 
            this.tb_ResultShow.BackColor = System.Drawing.SystemColors.Control;
            this.tb_ResultShow.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.tb_ResultShow.Location = new System.Drawing.Point(3, 30);
            this.tb_ResultShow.Multiline = true;
            this.tb_ResultShow.Name = "tb_ResultShow";
            this.tb_ResultShow.Size = new System.Drawing.Size(229, 235);
            this.tb_ResultShow.TabIndex = 7;
            this.tb_ResultShow.Text = "商品成功发出！          本次周转明细            周转文件：999          周转商品：999                    " +
                "                           请选择操作                     【1】继续                     【" +
                "2】完成  ";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(69, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.Text = "操作结果";
            // 
            // tb_Confirm
            // 
            this.tb_Confirm.BackColor = System.Drawing.SystemColors.Control;
            this.tb_Confirm.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tb_Confirm.Location = new System.Drawing.Point(-10, 0);
            this.tb_Confirm.Name = "tb_Confirm";
            this.tb_Confirm.Size = new System.Drawing.Size(10, 19);
            this.tb_Confirm.TabIndex = 0;
            this.tb_Confirm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_Confirm_KeyUp);
            this.tb_Confirm.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.login);
            this.tabControl1.Controls.Add(this.main);
            this.tabControl1.Controls.Add(this.Func1);
            this.tabControl1.Controls.Add(this.Func2);
            this.tabControl1.Controls.Add(this.Func3);
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(232, 295);
            this.tabControl1.TabIndex = 4;
            // 
            // login
            // 
            this.login.Controls.Add(this.label3);
            this.login.Controls.Add(this.label14);
            this.login.Controls.Add(this.tb_password);
            this.login.Controls.Add(this.tb_worker_no);
            this.login.Controls.Add(this.label13);
            this.login.Controls.Add(this.label12);
            this.login.Location = new System.Drawing.Point(4, 25);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(224, 266);
            this.login.Text = "login";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(15, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 32);
            this.label3.Text = "周转处理程序";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(6, 193);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 28);
            this.label14.Text = "密码";
            // 
            // tb_password
            // 
            this.tb_password.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.tb_password.Location = new System.Drawing.Point(65, 189);
            this.tb_password.MaxLength = 10;
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(137, 32);
            this.tb_password.TabIndex = 5;
            this.tb_password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_password_KeyUp);
            this.tb_password.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // tb_worker_no
            // 
            this.tb_worker_no.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.tb_worker_no.Location = new System.Drawing.Point(65, 129);
            this.tb_worker_no.MaxLength = 6;
            this.tb_worker_no.Name = "tb_worker_no";
            this.tb_worker_no.Size = new System.Drawing.Size(137, 32);
            this.tb_worker_no.TabIndex = 0;
            this.tb_worker_no.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_worker_no_KeyUp);
            this.tb_worker_no.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(3, 133);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 28);
            this.label13.Text = "工号";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(45, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 32);
            this.label12.Text = "登录界面";
            // 
            // main
            // 
            this.main.Controls.Add(this.label21);
            this.main.Controls.Add(this.label20);
            this.main.Controls.Add(this.label5);
            this.main.Controls.Add(this.label4);
            this.main.Controls.Add(this.tb_ui);
            this.main.Controls.Add(this.label2);
            this.main.Location = new System.Drawing.Point(4, 25);
            this.main.Name = "main";
            this.main.Size = new System.Drawing.Size(224, 266);
            this.main.Text = "main";
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label21.Location = new System.Drawing.Point(18, 115);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(190, 40);
            this.label21.Text = "[3]司机确认";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(18, 70);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(190, 40);
            this.label20.Text = "[2]发出处理";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(18, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 40);
            this.label5.Text = "[4]封条操作";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(18, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 38);
            this.label4.Text = "[5]退出登录";
            // 
            // tb_ui
            // 
            this.tb_ui.BackColor = System.Drawing.SystemColors.Control;
            this.tb_ui.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ui.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.tb_ui.Location = new System.Drawing.Point(-7, -2);
            this.tb_ui.Name = "tb_ui";
            this.tb_ui.ReadOnly = true;
            this.tb_ui.Size = new System.Drawing.Size(10, 39);
            this.tb_ui.TabIndex = 4;
            this.tb_ui.TabStop = false;
            this.tb_ui.WordWrap = false;
            this.tb_ui.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_ui_KeyUp);
            this.tb_ui.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(18, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 40);
            this.label2.Text = "[1]接收处理";
            // 
            // Func1
            // 
            this.Func1.Controls.Add(this.p_func1_check);
            this.Func1.Controls.Add(this.label8);
            this.Func1.Controls.Add(this.label7);
            this.Func1.Controls.Add(this.tb_func1_focus);
            this.Func1.Location = new System.Drawing.Point(4, 25);
            this.Func1.Name = "Func1";
            this.Func1.Size = new System.Drawing.Size(224, 266);
            this.Func1.Text = "Func1";
            // 
            // p_func1_check
            // 
            this.p_func1_check.Controls.Add(this.label18);
            this.p_func1_check.Controls.Add(this.tb_func1_workerNo);
            this.p_func1_check.Controls.Add(this.tb_func1_msg);
            this.p_func1_check.Controls.Add(this.label17);
            this.p_func1_check.Location = new System.Drawing.Point(3, 62);
            this.p_func1_check.Name = "p_func1_check";
            this.p_func1_check.Size = new System.Drawing.Size(218, 202);
            this.p_func1_check.Visible = false;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label18.Location = new System.Drawing.Point(3, 132);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 25);
            this.label18.Text = "员工卡号";
            // 
            // tb_func1_workerNo
            // 
            this.tb_func1_workerNo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.tb_func1_workerNo.Location = new System.Drawing.Point(88, 128);
            this.tb_func1_workerNo.Name = "tb_func1_workerNo";
            this.tb_func1_workerNo.Size = new System.Drawing.Size(110, 29);
            this.tb_func1_workerNo.TabIndex = 5;
            this.tb_func1_workerNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_func1_workerNo_KeyUp);
            this.tb_func1_workerNo.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // tb_func1_msg
            // 
            this.tb_func1_msg.BackColor = System.Drawing.SystemColors.Control;
            this.tb_func1_msg.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.tb_func1_msg.Location = new System.Drawing.Point(6, 41);
            this.tb_func1_msg.Multiline = true;
            this.tb_func1_msg.Name = "tb_func1_msg";
            this.tb_func1_msg.Size = new System.Drawing.Size(192, 58);
            this.tb_func1_msg.TabIndex = 1;
            this.tb_func1_msg.Text = "周转文件：0        周转商品：0";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.label17.Location = new System.Drawing.Point(3, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(138, 26);
            this.label17.Text = "本次调场明细";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(23, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 33);
            this.label8.Text = "周转处理界面";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(0, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 33);
            this.label7.Text = "请扫描条码：";
            // 
            // tb_func1_focus
            // 
            this.tb_func1_focus.BackColor = System.Drawing.SystemColors.Control;
            this.tb_func1_focus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_func1_focus.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.tb_func1_focus.Location = new System.Drawing.Point(23, 142);
            this.tb_func1_focus.Name = "tb_func1_focus";
            this.tb_func1_focus.Size = new System.Drawing.Size(180, 29);
            this.tb_func1_focus.TabIndex = 0;
            this.tb_func1_focus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_func1_focus_KeyUp);
            this.tb_func1_focus.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // Func2
            // 
            this.Func2.Controls.Add(this.tb_func2_sealType);
            this.Func2.Controls.Add(this.label16);
            this.Func2.Controls.Add(this.label15);
            this.Func2.Controls.Add(this.label11);
            this.Func2.Controls.Add(this.label10);
            this.Func2.Controls.Add(this.tb_func2_workerNo);
            this.Func2.Controls.Add(this.tb_func2_bar);
            this.Func2.Controls.Add(this.label9);
            this.Func2.Controls.Add(this.tb_func2_sealNo);
            this.Func2.Location = new System.Drawing.Point(4, 25);
            this.Func2.Name = "Func2";
            this.Func2.Size = new System.Drawing.Size(224, 266);
            this.Func2.Text = "Func2";
            // 
            // tb_func2_sealType
            // 
            this.tb_func2_sealType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.tb_func2_sealType.Location = new System.Drawing.Point(6, 218);
            this.tb_func2_sealType.Name = "tb_func2_sealType";
            this.tb_func2_sealType.Size = new System.Drawing.Size(18, 26);
            this.tb_func2_sealType.TabIndex = 5;
            this.tb_func2_sealType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_func2_sealType_KeyUp);
            this.tb_func2_sealType.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.label16.Location = new System.Drawing.Point(25, 218);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(196, 25);
            this.label16.Text = "1-上封条 | 2-解封条";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.label15.Location = new System.Drawing.Point(11, 177);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 25);
            this.label15.Text = "工卡";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.label11.Location = new System.Drawing.Point(11, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 25);
            this.label11.Text = "条码";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(11, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 25);
            this.label10.Text = "封条";
            // 
            // tb_func2_workerNo
            // 
            this.tb_func2_workerNo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.tb_func2_workerNo.Location = new System.Drawing.Point(72, 173);
            this.tb_func2_workerNo.Name = "tb_func2_workerNo";
            this.tb_func2_workerNo.Size = new System.Drawing.Size(138, 29);
            this.tb_func2_workerNo.TabIndex = 3;
            this.tb_func2_workerNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_func2_workerNo_KeyUp);
            this.tb_func2_workerNo.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // tb_func2_bar
            // 
            this.tb_func2_bar.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.tb_func2_bar.Location = new System.Drawing.Point(72, 125);
            this.tb_func2_bar.Name = "tb_func2_bar";
            this.tb_func2_bar.Size = new System.Drawing.Size(138, 29);
            this.tb_func2_bar.TabIndex = 2;
            this.tb_func2_bar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_func2_bar_KeyUp);
            this.tb_func2_bar.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(28, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 37);
            this.label9.Text = "周转箱封条";
            // 
            // tb_func2_sealNo
            // 
            this.tb_func2_sealNo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.tb_func2_sealNo.Location = new System.Drawing.Point(72, 78);
            this.tb_func2_sealNo.Name = "tb_func2_sealNo";
            this.tb_func2_sealNo.Size = new System.Drawing.Size(138, 29);
            this.tb_func2_sealNo.TabIndex = 0;
            this.tb_func2_sealNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_func2_sealNo_KeyUp);
            // 
            // Func3
            // 
            this.Func3.Controls.Add(this.lbl_match_count);
            this.Func3.Controls.Add(this.label19);
            this.Func3.Controls.Add(this.label25);
            this.Func3.Controls.Add(this.tb_func3_srflag);
            this.Func3.Controls.Add(this.tb_func3_driver);
            this.Func3.Controls.Add(this.label23);
            this.Func3.Controls.Add(this.tb_func3_batch);
            this.Func3.Controls.Add(this.label22);
            this.Func3.Location = new System.Drawing.Point(4, 25);
            this.Func3.Name = "Func3";
            this.Func3.Size = new System.Drawing.Size(224, 266);
            this.Func3.Text = "Func3";
            // 
            // lbl_match_count
            // 
            this.lbl_match_count.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbl_match_count.Location = new System.Drawing.Point(12, 124);
            this.lbl_match_count.Name = "lbl_match_count";
            this.lbl_match_count.Size = new System.Drawing.Size(200, 20);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.DimGray;
            this.label19.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.OrangeRed;
            this.label19.Location = new System.Drawing.Point(12, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(200, 38);
            this.label19.Text = "司机确认界面";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.label25.Location = new System.Drawing.Point(25, 227);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(206, 23);
            this.label25.Text = "按[1]接收  按[2]发出";
            // 
            // tb_func3_srflag
            // 
            this.tb_func3_srflag.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.tb_func3_srflag.Location = new System.Drawing.Point(6, 227);
            this.tb_func3_srflag.MaxLength = 1;
            this.tb_func3_srflag.Name = "tb_func3_srflag";
            this.tb_func3_srflag.Size = new System.Drawing.Size(22, 26);
            this.tb_func3_srflag.TabIndex = 6;
            this.tb_func3_srflag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_func3_srflag_KeyUp);
            this.tb_func3_srflag.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // tb_func3_driver
            // 
            this.tb_func3_driver.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.tb_func3_driver.Location = new System.Drawing.Point(89, 161);
            this.tb_func3_driver.Name = "tb_func3_driver";
            this.tb_func3_driver.Size = new System.Drawing.Size(123, 26);
            this.tb_func3_driver.TabIndex = 3;
            this.tb_func3_driver.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_func3_driver_KeyUp);
            this.tb_func3_driver.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label23.Location = new System.Drawing.Point(12, 167);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 20);
            this.label23.Text = "司机条码";
            // 
            // tb_func3_batch
            // 
            this.tb_func3_batch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.tb_func3_batch.Location = new System.Drawing.Point(89, 86);
            this.tb_func3_batch.Name = "tb_func3_batch";
            this.tb_func3_batch.Size = new System.Drawing.Size(123, 26);
            this.tb_func3_batch.TabIndex = 1;
            this.tb_func3_batch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_func3_batch_KeyUp);
            this.tb_func3_batch.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label22.Location = new System.Drawing.Point(12, 92);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 20);
            this.label22.Text = "周转清单";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 298);
            this.ControlBox = false;
            this.Controls.Add(this.p_msg);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, -30);
            this.Name = "Form1";
            this.Text = "0";
            this.p_msg.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.login.ResumeLayout(false);
            this.main.ResumeLayout(false);
            this.Func1.ResumeLayout(false);
            this.p_func1_check.ResumeLayout(false);
            this.Func2.ResumeLayout(false);
            this.Func3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel p_msg;
        private System.Windows.Forms.TextBox tb_ResultShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Confirm;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_worker_no;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage main;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_ui;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage Func1;
        private System.Windows.Forms.TextBox tb_func1_focus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage Func2;
        private System.Windows.Forms.TextBox tb_func2_sealNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_func2_workerNo;
        private System.Windows.Forms.TextBox tb_func2_bar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel p_func1_check;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tb_func1_msg;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tb_func1_workerNo;
        private System.Windows.Forms.TextBox tb_func2_sealType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tb_func3_driver;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tb_func3_batch;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tb_func3_srflag;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TabPage Func3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbl_match_count;
    }
}

