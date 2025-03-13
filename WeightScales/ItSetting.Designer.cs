namespace WeightScales
{
    partial class ItSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItSetting));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBackSet = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSetting = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.cbDeviceSet = new System.Windows.Forms.ComboBox();
            this.cbPortSet = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.btnBackSet);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 109);
            this.panel1.TabIndex = 30;
            // 
            // btnBackSet
            // 
            this.btnBackSet.BackColor = System.Drawing.Color.Transparent;
            this.btnBackSet.Image = ((System.Drawing.Image)(resources.GetObject("btnBackSet.Image")));
            this.btnBackSet.InitialImage = null;
            this.btnBackSet.Location = new System.Drawing.Point(21, 39);
            this.btnBackSet.Name = "btnBackSet";
            this.btnBackSet.Size = new System.Drawing.Size(35, 31);
            this.btnBackSet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBackSet.TabIndex = 24;
            this.btnBackSet.TabStop = false;
            this.btnBackSet.Click += new System.EventHandler(this.btnBackSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 59);
            this.label1.TabIndex = 23;
            this.label1.Text = "SETTING";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSetting
            // 
            this.lbSetting.AutoSize = true;
            this.lbSetting.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSetting.Location = new System.Drawing.Point(32, 162);
            this.lbSetting.Name = "lbSetting";
            this.lbSetting.Size = new System.Drawing.Size(79, 26);
            this.lbSetting.TabIndex = 31;
            this.lbSetting.Text = "Device: ";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPort.Location = new System.Drawing.Point(313, 162);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(54, 26);
            this.lbPort.TabIndex = 32;
            this.lbPort.Text = "Port:";
            // 
            // cbDeviceSet
            // 
            this.cbDeviceSet.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDeviceSet.FormattingEnabled = true;
            this.cbDeviceSet.Location = new System.Drawing.Point(117, 158);
            this.cbDeviceSet.Name = "cbDeviceSet";
            this.cbDeviceSet.Size = new System.Drawing.Size(132, 37);
            this.cbDeviceSet.TabIndex = 33;
            // 
            // cbPortSet
            // 
            this.cbPortSet.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPortSet.FormattingEnabled = true;
            this.cbPortSet.Location = new System.Drawing.Point(373, 158);
            this.cbPortSet.Name = "cbPortSet";
            this.cbPortSet.Size = new System.Drawing.Size(139, 37);
            this.cbPortSet.TabIndex = 34;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(205, 252);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 44);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ItSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(555, 360);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbPortSet);
            this.Controls.Add(this.cbDeviceSet);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbSetting);
            this.Controls.Add(this.panel1);
            this.Name = "ItSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "itSetting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ItSetting_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSetting;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.ComboBox cbDeviceSet;
        private System.Windows.Forms.ComboBox cbPortSet;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox btnBackSet;
    }
}