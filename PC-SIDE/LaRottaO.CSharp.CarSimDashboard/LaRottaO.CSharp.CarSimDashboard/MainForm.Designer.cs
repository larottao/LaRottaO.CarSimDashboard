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
            this.comboBoxComPorts = new System.Windows.Forms.ComboBox();
            this.buttonConnectPort = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonDisconnectPort = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.FormTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxKMH
            // 
            this.textBoxKMH.Enabled = false;
            this.textBoxKMH.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKMH.Location = new System.Drawing.Point(16, 98);
            this.textBoxKMH.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBoxKMH.Name = "textBoxKMH";
            this.textBoxKMH.Size = new System.Drawing.Size(119, 54);
            this.textBoxKMH.TabIndex = 0;
            this.textBoxKMH.Text = "000";
            this.textBoxKMH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // textBoxRPM
            // 
            this.textBoxRPM.Enabled = false;
            this.textBoxRPM.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRPM.Location = new System.Drawing.Point(16, 30);
            this.textBoxRPM.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBoxRPM.Name = "textBoxRPM";
            this.textBoxRPM.Size = new System.Drawing.Size(119, 54);
            this.textBoxRPM.TabIndex = 1;
            this.textBoxRPM.Text = "000";
            this.textBoxRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
     
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "RPM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Km/h";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(153, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gear";
            // 
            // textBoxGear
            // 
            this.textBoxGear.Enabled = false;
            this.textBoxGear.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGear.Location = new System.Drawing.Point(76, 232);
            this.textBoxGear.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBoxGear.Name = "textBoxGear";
            this.textBoxGear.Size = new System.Drawing.Size(59, 54);
            this.textBoxGear.TabIndex = 4;
            this.textBoxGear.Text = "1";
            this.textBoxGear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(153, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 37);
            this.label4.TabIndex = 7;
            this.label4.Text = "Liters";
            // 
            // textBoxFuel
            // 
            this.textBoxFuel.Enabled = false;
            this.textBoxFuel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFuel.Location = new System.Drawing.Point(16, 166);
            this.textBoxFuel.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textBoxFuel.Name = "textBoxFuel";
            this.textBoxFuel.Size = new System.Drawing.Size(119, 54);
            this.textBoxFuel.TabIndex = 6;
            this.textBoxFuel.Text = "000";
            this.textBoxFuel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // radioAssetoData
            // 
            this.radioAssetoData.AutoSize = true;
            this.radioAssetoData.Checked = true;
            this.radioAssetoData.Location = new System.Drawing.Point(24, 42);
            this.radioAssetoData.Name = "radioAssetoData";
            this.radioAssetoData.Size = new System.Drawing.Size(330, 25);
            this.radioAssetoData.TabIndex = 8;
            this.radioAssetoData.TabStop = true;
            this.radioAssetoData.Text = "Asseto Corsa (when racing window is open)";
            this.radioAssetoData.UseVisualStyleBackColor = true;
            this.radioAssetoData.Click += new System.EventHandler(this.radioAssetoData_Click);
            // 
            // radioManualInput
            // 
            this.radioManualInput.AutoSize = true;
            this.radioManualInput.Location = new System.Drawing.Point(24, 73);
            this.radioManualInput.Name = "radioManualInput";
            this.radioManualInput.Size = new System.Drawing.Size(120, 25);
            this.radioManualInput.TabIndex = 9;
            this.radioManualInput.Text = "Manual Input";
            this.radioManualInput.UseVisualStyleBackColor = true;
            this.radioManualInput.Click += new System.EventHandler(this.radioManualInput_Click);
            // 
            // textBoxRpmFreq
            // 
            this.textBoxRpmFreq.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRpmFreq.Location = new System.Drawing.Point(69, 150);
            this.textBoxRpmFreq.Name = "textBoxRpmFreq";
            this.textBoxRpmFreq.Size = new System.Drawing.Size(46, 25);
            this.textBoxRpmFreq.TabIndex = 10;
            this.textBoxRpmFreq.Text = "0";
            // 
            // textBoxKmhFreq
            // 
            this.textBoxKmhFreq.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKmhFreq.Location = new System.Drawing.Point(186, 150);
            this.textBoxKmhFreq.Name = "textBoxKmhFreq";
            this.textBoxKmhFreq.Size = new System.Drawing.Size(46, 25);
            this.textBoxKmhFreq.TabIndex = 11;
            this.textBoxKmhFreq.Text = "0";
            // 
            // checkBoxUseFreqTable
            // 
            this.checkBoxUseFreqTable.AutoSize = true;
            this.checkBoxUseFreqTable.Checked = true;
            this.checkBoxUseFreqTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseFreqTable.Location = new System.Drawing.Point(24, 113);
            this.checkBoxUseFreqTable.Name = "checkBoxUseFreqTable";
            this.checkBoxUseFreqTable.Size = new System.Drawing.Size(204, 25);
            this.checkBoxUseFreqTable.TabIndex = 12;
            this.checkBoxUseFreqTable.Text = "Calculate freq using table";
            this.checkBoxUseFreqTable.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.checkBoxUseFreqTable);
            this.groupBox1.Controls.Add(this.textBoxKmhFreq);
            this.groupBox1.Controls.Add(this.radioAssetoData);
            this.groupBox1.Controls.Add(this.textBoxRpmFreq);
            this.groupBox1.Controls.Add(this.radioManualInput);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.Location = new System.Drawing.Point(270, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 187);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datasource";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.Location = new System.Drawing.Point(130, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 21);
            this.label6.TabIndex = 19;
            this.label6.Text = "KM/H";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(20, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "RPM";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radio10KRedLineMatchMaxPw);
            this.groupBox2.Controls.Add(this.radioMatchRealScale);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(270, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 144);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RPM Scale";
            // 
            // radio10KRedLineMatchMaxPw
            // 
            this.radio10KRedLineMatchMaxPw.Checked = true;
            this.radio10KRedLineMatchMaxPw.Location = new System.Drawing.Point(24, 68);
            this.radio10KRedLineMatchMaxPw.Name = "radio10KRedLineMatchMaxPw";
            this.radio10KRedLineMatchMaxPw.Size = new System.Drawing.Size(300, 56);
            this.radio10KRedLineMatchMaxPw.TabIndex = 10;
            this.radio10KRedLineMatchMaxPw.TabStop = true;
            this.radio10KRedLineMatchMaxPw.Text = "The dashboard 10K redline (and red light) matches car\'s Max Power";
            this.radio10KRedLineMatchMaxPw.UseVisualStyleBackColor = true;
            // 
            // radioMatchRealScale
            // 
            this.radioMatchRealScale.AutoSize = true;
            this.radioMatchRealScale.Location = new System.Drawing.Point(24, 37);
            this.radioMatchRealScale.Name = "radioMatchRealScale";
            this.radioMatchRealScale.Size = new System.Drawing.Size(57, 25);
            this.radioMatchRealScale.TabIndex = 9;
            this.radioMatchRealScale.Text = "1 : 1";
            this.radioMatchRealScale.UseVisualStyleBackColor = true;
            // 
            // comboBoxComPorts
            // 
            this.comboBoxComPorts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxComPorts.FormattingEnabled = true;
            this.comboBoxComPorts.Location = new System.Drawing.Point(23, 39);
            this.comboBoxComPorts.Name = "comboBoxComPorts";
            this.comboBoxComPorts.Size = new System.Drawing.Size(314, 29);
            this.comboBoxComPorts.TabIndex = 15;
            // 
            // buttonConnectPort
            // 
            this.buttonConnectPort.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnectPort.Location = new System.Drawing.Point(23, 85);
            this.buttonConnectPort.Name = "buttonConnectPort";
            this.buttonConnectPort.Size = new System.Drawing.Size(98, 31);
            this.buttonConnectPort.TabIndex = 16;
            this.buttonConnectPort.Text = "Connect";
            this.buttonConnectPort.UseVisualStyleBackColor = true;
            this.buttonConnectPort.Click += new System.EventHandler(this.buttonConnectPort_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonDisconnectPort);
            this.groupBox3.Controls.Add(this.comboBoxComPorts);
            this.groupBox3.Controls.Add(this.buttonConnectPort);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(270, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(353, 133);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Physic Dashboard μC port";
            // 
            // buttonDisconnectPort
            // 
            this.buttonDisconnectPort.Enabled = false;
            this.buttonDisconnectPort.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisconnectPort.Location = new System.Drawing.Point(130, 85);
            this.buttonDisconnectPort.Name = "buttonDisconnectPort";
            this.buttonDisconnectPort.Size = new System.Drawing.Size(98, 31);
            this.buttonDisconnectPort.TabIndex = 17;
            this.buttonDisconnectPort.Text = "Disconnect";
            this.buttonDisconnectPort.UseVisualStyleBackColor = true;
            this.buttonDisconnectPort.Click += new System.EventHandler(this.buttonDisconnectPort_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.Location = new System.Drawing.Point(12, 499);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 536);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxFuel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxGear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRPM);
            this.Controls.Add(this.textBoxKMH);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Physical Dashboard for Asseto Corsa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox comboBoxComPorts;
        private System.Windows.Forms.Button buttonConnectPort;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonDisconnectPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer FormTimer;
    }
}

