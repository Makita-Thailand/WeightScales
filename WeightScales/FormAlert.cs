using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeightScales
{
    public partial class FormAlert : Form
    {
        public FormAlert()
        {
            InitializeComponent();
            //this.BackColor = Color.FromArgb(180, 255, 0, 0);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Red; // ตั้งค่าสีพื้นหลังเป็นสีแดง
            this.Opacity = 0.7;

            btnAl.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
