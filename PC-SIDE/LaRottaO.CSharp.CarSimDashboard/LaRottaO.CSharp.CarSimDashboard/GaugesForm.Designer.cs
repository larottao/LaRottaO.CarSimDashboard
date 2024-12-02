namespace LaRottaO.CSharp.CarSimDashboard
{
    partial class GaugesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GaugesForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelGear = new System.Windows.Forms.Label();
            this.speedometerPictureBox = new System.Windows.Forms.PictureBox();
            this.tachometerPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.speedometerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tachometerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGear
            // 
            this.labelGear.AutoSize = true;
            this.labelGear.BackColor = System.Drawing.Color.Transparent;
            this.labelGear.Font = new System.Drawing.Font("Microsoft YaHei", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGear.ForeColor = System.Drawing.Color.Gold;
            this.labelGear.Location = new System.Drawing.Point(627, 317);
            this.labelGear.Name = "labelGear";
            this.labelGear.Size = new System.Drawing.Size(108, 124);
            this.labelGear.TabIndex = 2;
            this.labelGear.Text = "1";
            this.labelGear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // speedometerPictureBox
            // 
            this.speedometerPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedometerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.speedometerPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("speedometerPictureBox.Image")));
            this.speedometerPictureBox.Location = new System.Drawing.Point(68, 95);
            this.speedometerPictureBox.Name = "speedometerPictureBox";
            this.speedometerPictureBox.Size = new System.Drawing.Size(482, 473);
            this.speedometerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.speedometerPictureBox.TabIndex = 3;
            this.speedometerPictureBox.TabStop = false;
            // 
            // tachometerPictureBox
            // 
            this.tachometerPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tachometerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.tachometerPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("tachometerPictureBox.Image")));
            this.tachometerPictureBox.Location = new System.Drawing.Point(816, 95);
            this.tachometerPictureBox.Name = "tachometerPictureBox";
            this.tachometerPictureBox.Size = new System.Drawing.Size(482, 473);
            this.tachometerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tachometerPictureBox.TabIndex = 5;
            this.tachometerPictureBox.TabStop = false;
            // 
            // GaugesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1350, 651);
            this.Controls.Add(this.tachometerPictureBox);
            this.Controls.Add(this.speedometerPictureBox);
            this.Controls.Add(this.labelGear);
            this.Name = "GaugesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GaugesForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GaugesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.speedometerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tachometerPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labelGear;
        private System.Windows.Forms.PictureBox speedometerPictureBox;
        private System.Windows.Forms.PictureBox tachometerPictureBox;
    }
}