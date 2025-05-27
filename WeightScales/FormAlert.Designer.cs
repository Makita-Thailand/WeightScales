namespace WeightScales
{
    partial class FormAlert
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
            this.aldateil = new System.Windows.Forms.Label();
            this.panelAl = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAl = new System.Windows.Forms.Button();
            this.alTitle = new System.Windows.Forms.Label();
            this.panelAl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aldateil
            // 
            this.aldateil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aldateil.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aldateil.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.aldateil.Location = new System.Drawing.Point(91, 134);
            this.aldateil.Name = "aldateil";
            this.aldateil.Size = new System.Drawing.Size(380, 38);
            this.aldateil.TabIndex = 1;
            this.aldateil.Text = "ยกของออกจากเครื่องชั่ง ก่อนกดปุ่ม Unlook";
            this.aldateil.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panelAl
            // 
            this.panelAl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelAl.Controls.Add(this.panel1);
            this.panelAl.Controls.Add(this.aldateil);
            this.panelAl.Controls.Add(this.alTitle);
            this.panelAl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAl.Location = new System.Drawing.Point(0, 0);
            this.panelAl.Name = "panelAl";
            this.panelAl.Size = new System.Drawing.Size(566, 246);
            this.panelAl.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnAl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 38);
            this.panel1.TabIndex = 4;
            // 
            // btnAl
            // 
            this.btnAl.BackColor = System.Drawing.Color.Transparent;
            this.btnAl.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAl.FlatAppearance.BorderSize = 0;
            this.btnAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAl.ForeColor = System.Drawing.Color.LightPink;
            this.btnAl.Location = new System.Drawing.Point(522, 0);
            this.btnAl.Name = "btnAl";
            this.btnAl.Size = new System.Drawing.Size(44, 38);
            this.btnAl.TabIndex = 3;
            this.btnAl.Text = "X";
            this.btnAl.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAl.UseVisualStyleBackColor = false;
            this.btnAl.Click += new System.EventHandler(this.button1_Click);
            // 
            // alTitle
            // 
            this.alTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alTitle.Font = new System.Drawing.Font("Calibri", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alTitle.Location = new System.Drawing.Point(71, 58);
            this.alTitle.Name = "alTitle";
            this.alTitle.Size = new System.Drawing.Size(421, 76);
            this.alTitle.TabIndex = 0;
            this.alTitle.Text = "No Good(NG)";
            this.alTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(566, 246);
            this.Controls.Add(this.panelAl);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FormAlert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelAl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label aldateil;
        private System.Windows.Forms.Panel panelAl;
        private System.Windows.Forms.Label alTitle;
        private System.Windows.Forms.Button btnAl;
        private System.Windows.Forms.Panel panel1;
    }
}