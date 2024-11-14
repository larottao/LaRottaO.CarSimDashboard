namespace LRottaO.CSharp.SimDashboardCtrl
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxKMH = new System.Windows.Forms.TextBox();
            this.textBoxRPM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFuel = new System.Windows.Forms.TextBox();
            this.radioAssetoData = new System.Windows.Forms.RadioButton();
            this.radioManualInput = new System.Windows.Forms.RadioButton();
            this.textBoxRpmFreq = new System.Windows.Forms.TextBox();
            this.textBoxKmhFreq = new System.Windows.Forms.TextBox();
            this.checkBoxUseFreqTable = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radio10KRedLineMatchMaxPw = new System.Windows.Forms.RadioButton();
            this.radioMatchRealScale = new System.Windows.Forms.RadioButton();
            this.buttonConnectPort = new System.Windows.Forms.Button();
            this.buttonDisconnectPort = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.FormTimer = new System.Windows.Forms.Timer(this.components);
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelBoardStatus = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.tabPageConf = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxFullTankLiters = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageConf.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxKMH
            // 
            this.textBoxKMH.Enabled = false;
            this.textBoxKMH.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKMH.Location = new System.Drawing.Point(7, 76);
            this.textBoxKMH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxKMH.Name = "textBoxKMH";
            this.textBoxKMH.Size = new System.Drawing.Size(113, 54);
            this.textBoxKMH.TabIndex = 0;
            this.textBoxKMH.Text = "000";
            this.textBoxKMH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxRPM
            // 
            this.textBoxRPM.Enabled = false;
            this.textBoxRPM.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRPM.Location = new System.Drawing.Point(6, 19);
            this.textBoxRPM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRPM.Name = "textBoxRPM";
            this.textBoxRPM.Size = new System.Drawing.Size(113, 54);
            this.textBoxRPM.TabIndex = 1;
            this.textBoxRPM.Text = "00000";
            this.textBoxRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "RPM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(126, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Km/h";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(126, 191);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gear";
            // 
            // textBoxGear
            // 
            this.textBoxGear.Enabled = false;
            this.textBoxGear.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGear.Location = new System.Drawing.Point(6, 190);
            this.textBoxGear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGear.MaxLength = 1;
            this.textBoxGear.Name = "textBoxGear";
            this.textBoxGear.Size = new System.Drawing.Size(113, 54);
            this.textBoxGear.TabIndex = 4;
            this.textBoxGear.Text = "1";
            this.textBoxGear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(126, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 37);
            this.label4.TabIndex = 7;
            this.label4.Text = "Liters";
            // 
            // textBoxFuel
            // 
            this.textBoxFuel.Enabled = false;
            this.textBoxFuel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFuel.Location = new System.Drawing.Point(6, 133);
            this.textBoxFuel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFuel.MaxLength = 3;
            this.textBoxFuel.Name = "textBoxFuel";
            this.textBoxFuel.Size = new System.Drawing.Size(113, 54);
            this.textBoxFuel.TabIndex = 6;
            this.textBoxFuel.Text = "30";
            this.textBoxFuel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioAssetoData
            // 
            this.radioAssetoData.Checked = true;
            this.radioAssetoData.Location = new System.Drawing.Point(14, 24);
            this.radioAssetoData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioAssetoData.Name = "radioAssetoData";
            this.radioAssetoData.Size = new System.Drawing.Size(180, 42);
            this.radioAssetoData.TabIndex = 8;
            this.radioAssetoData.TabStop = true;
            this.radioAssetoData.Text = "Asseto Corsa (only when racing window is open)";
            this.radioAssetoData.UseVisualStyleBackColor = true;
            this.radioAssetoData.Click += new System.EventHandler(this.radioAssetoData_Click);
            // 
            // radioManualInput
            // 
            this.radioManualInput.AutoSize = true;
            this.radioManualInput.Location = new System.Drawing.Point(14, 69);
            this.radioManualInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioManualInput.Name = "radioManualInput";
            this.radioManualInput.Size = new System.Drawing.Size(102, 21);
            this.radioManualInput.TabIndex = 9;
            this.radioManualInput.Text = "Manual Input";
            this.radioManualInput.UseVisualStyleBackColor = true;
            this.radioManualInput.Click += new System.EventHandler(this.radioManualInput_Click);
            // 
            // textBoxRpmFreq
            // 
            this.textBoxRpmFreq.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRpmFreq.Location = new System.Drawing.Point(61, 60);
            this.textBoxRpmFreq.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRpmFreq.Name = "textBoxRpmFreq";
            this.textBoxRpmFreq.Size = new System.Drawing.Size(28, 25);
            this.textBoxRpmFreq.TabIndex = 10;
            this.textBoxRpmFreq.Text = "0";
            // 
            // textBoxKmhFreq
            // 
            this.textBoxKmhFreq.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKmhFreq.Location = new System.Drawing.Point(163, 58);
            this.textBoxKmhFreq.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxKmhFreq.Name = "textBoxKmhFreq";
            this.textBoxKmhFreq.Size = new System.Drawing.Size(28, 25);
            this.textBoxKmhFreq.TabIndex = 11;
            this.textBoxKmhFreq.Text = "0";
            // 
            // checkBoxUseFreqTable
            // 
            this.checkBoxUseFreqTable.AutoSize = true;
            this.checkBoxUseFreqTable.Checked = true;
            this.checkBoxUseFreqTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseFreqTable.Location = new System.Drawing.Point(16, 33);
            this.checkBoxUseFreqTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxUseFreqTable.Name = "checkBoxUseFreqTable";
            this.checkBoxUseFreqTable.Size = new System.Drawing.Size(210, 21);
            this.checkBoxUseFreqTable.TabIndex = 12;
            this.checkBoxUseFreqTable.Text = "Calculate PWM freq using table";
            this.checkBoxUseFreqTable.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioAssetoData);
            this.groupBox1.Controls.Add(this.radioManualInput);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(211, 137);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(206, 107);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datasource";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.Location = new System.Drawing.Point(109, 60);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 21);
            this.label6.TabIndex = 19;
            this.label6.Text = "KM/H";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(14, 60);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "RPM";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radio10KRedLineMatchMaxPw);
            this.groupBox2.Controls.Add(this.radioMatchRealScale);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 121);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(229, 93);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RPM Scale";
            // 
            // radio10KRedLineMatchMaxPw
            // 
            this.radio10KRedLineMatchMaxPw.Checked = true;
            this.radio10KRedLineMatchMaxPw.Location = new System.Drawing.Point(16, 47);
            this.radio10KRedLineMatchMaxPw.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radio10KRedLineMatchMaxPw.Name = "radio10KRedLineMatchMaxPw";
            this.radio10KRedLineMatchMaxPw.Size = new System.Drawing.Size(273, 32);
            this.radio10KRedLineMatchMaxPw.TabIndex = 10;
            this.radio10KRedLineMatchMaxPw.TabStop = true;
            this.radio10KRedLineMatchMaxPw.Text = "The dashboard 10K -> car 7K";
            this.radio10KRedLineMatchMaxPw.UseVisualStyleBackColor = true;
            this.radio10KRedLineMatchMaxPw.CheckedChanged += new System.EventHandler(this.radio10KRedLineMatchMaxPw_CheckedChanged);
            // 
            // radioMatchRealScale
            // 
            this.radioMatchRealScale.AutoSize = true;
            this.radioMatchRealScale.Location = new System.Drawing.Point(16, 22);
            this.radioMatchRealScale.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioMatchRealScale.Name = "radioMatchRealScale";
            this.radioMatchRealScale.Size = new System.Drawing.Size(158, 21);
            this.radioMatchRealScale.TabIndex = 9;
            this.radioMatchRealScale.Text = "Match dashboard face";
            this.radioMatchRealScale.UseVisualStyleBackColor = true;
            this.radioMatchRealScale.CheckedChanged += new System.EventHandler(this.radioMatchRealScale_CheckedChanged);
            // 
            // buttonConnectPort
            // 
            this.buttonConnectPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnectPort.Location = new System.Drawing.Point(336, 42);
            this.buttonConnectPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonConnectPort.Name = "buttonConnectPort";
            this.buttonConnectPort.Size = new System.Drawing.Size(81, 31);
            this.buttonConnectPort.TabIndex = 16;
            this.buttonConnectPort.Text = "Connect";
            this.buttonConnectPort.UseVisualStyleBackColor = true;
            this.buttonConnectPort.Click += new System.EventHandler(this.buttonConnectPort_Click);
            // 
            // buttonDisconnectPort
            // 
            this.buttonDisconnectPort.Enabled = false;
            this.buttonDisconnectPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisconnectPort.Location = new System.Drawing.Point(336, 77);
            this.buttonDisconnectPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDisconnectPort.Name = "buttonDisconnectPort";
            this.buttonDisconnectPort.Size = new System.Drawing.Size(81, 31);
            this.buttonDisconnectPort.TabIndex = 17;
            this.buttonDisconnectPort.Text = "Disconnect";
            this.buttonDisconnectPort.UseVisualStyleBackColor = true;
            this.buttonDisconnectPort.Click += new System.EventHandler(this.buttonDisconnectPort_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.Location = new System.Drawing.Point(378, 307);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 21);
            this.label7.TabIndex = 20;
            this.label7.Text = "LaRottaO";
            // 
            // FormTimer
            // 
            this.FormTimer.Enabled = true;
            this.FormTimer.Tick += new System.EventHandler(this.FormTimer_Tick);
            // 
            // labelInfo
            // 
            this.labelInfo.Location = new System.Drawing.Point(7, 281);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(147, 18);
            this.labelInfo.TabIndex = 21;
            // 
            // labelBoardStatus
            // 
            this.labelBoardStatus.AutoSize = true;
            this.labelBoardStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBoardStatus.Location = new System.Drawing.Point(289, 19);
            this.labelBoardStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBoardStatus.Name = "labelBoardStatus";
            this.labelBoardStatus.Size = new System.Drawing.Size(128, 17);
            this.labelBoardStatus.TabIndex = 23;
            this.labelBoardStatus.Text = "Board: Disconnected";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMain);
            this.tabControl1.Controls.Add(this.tabPageConf);
            this.tabControl1.Location = new System.Drawing.Point(10, 11);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(443, 288);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.textBoxRPM);
            this.tabPageMain.Controls.Add(this.buttonConnectPort);
            this.tabPageMain.Controls.Add(this.buttonDisconnectPort);
            this.tabPageMain.Controls.Add(this.labelBoardStatus);
            this.tabPageMain.Controls.Add(this.groupBox1);
            this.tabPageMain.Controls.Add(this.textBoxKMH);
            this.tabPageMain.Controls.Add(this.textBoxGear);
            this.tabPageMain.Controls.Add(this.textBoxFuel);
            this.tabPageMain.Controls.Add(this.label1);
            this.tabPageMain.Controls.Add(this.label2);
            this.tabPageMain.Controls.Add(this.label4);
            this.tabPageMain.Controls.Add(this.label3);
            this.tabPageMain.Location = new System.Drawing.Point(4, 26);
            this.tabPageMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageMain.Size = new System.Drawing.Size(435, 258);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // tabPageConf
            // 
            this.tabPageConf.Controls.Add(this.groupBox4);
            this.tabPageConf.Controls.Add(this.groupBox3);
            this.tabPageConf.Controls.Add(this.groupBox2);
            this.tabPageConf.Location = new System.Drawing.Point(4, 26);
            this.tabPageConf.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageConf.Name = "tabPageConf";
            this.tabPageConf.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageConf.Size = new System.Drawing.Size(435, 258);
            this.tabPageConf.TabIndex = 1;
            this.tabPageConf.Text = "Config";
            this.tabPageConf.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.checkBoxUseFreqTable);
            this.groupBox3.Controls.Add(this.textBoxKmhFreq);
            this.groupBox3.Controls.Add(this.textBoxRpmFreq);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(14, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 102);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data to PWM";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxFullTankLiters);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(258, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(159, 102);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fuel value interpolation";
            // 
            // textBoxFullTankLiters
            // 
            this.textBoxFullTankLiters.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFullTankLiters.Location = new System.Drawing.Point(10, 60);
            this.textBoxFullTankLiters.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFullTankLiters.Name = "textBoxFullTankLiters";
            this.textBoxFullTankLiters.Size = new System.Drawing.Size(28, 25);
            this.textBoxFullTankLiters.TabIndex = 10;
            this.textBoxFullTankLiters.Text = "30";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label9.Location = new System.Drawing.Point(6, 33);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 21);
            this.label9.TabIndex = 18;
            this.label9.Text = "Full tank liters";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(462, 337);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Physical Dashboard for Asseto Corsa";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageConf.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxKMH;
        private System.Windows.Forms.TextBox textBoxRPM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFuel;
        private System.Windows.Forms.RadioButton radioAssetoData;
        private System.Windows.Forms.RadioButton radioManualInput;
        private System.Windows.Forms.TextBox textBoxRpmFreq;
        private System.Windows.Forms.TextBox textBoxKmhFreq;
        private System.Windows.Forms.CheckBox checkBoxUseFreqTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radio10KRedLineMatchMaxPw;
        private System.Windows.Forms.RadioButton radioMatchRealScale;
        private System.Windows.Forms.Button buttonConnectPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonDisconnectPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer FormTimer;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelBoardStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageConf;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxFullTankLiters;
        private System.Windows.Forms.Label label9;
    }
}

