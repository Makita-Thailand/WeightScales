using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeightScales
{
    public partial class ItSetting : Form
    {
        public SqlConnection conn = new SqlConnection();
        DBConnect db;

        public ItSetting()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "Weight Scales " + String.Format("{0}", version);
            
            db = new DBConnect(this);
            string[] portCom = SerialPort.GetPortNames();
            cbPortSet.Items.AddRange(portCom);

            foreach (DataRow item in db.getListLocName().Rows)
            {
                cbDeviceSet.Items.Add(item[0].ToString());
            }
        }

        private void btnBackSet_Click(object sender, EventArgs e)
        {
            FormNavigator.GotoInputData(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetModelITSettings();
            DialogResult result1 = MessageBox.Show("บันทึกค่าเรียบร้อย!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result1 == DialogResult.OK)
            {
                FormNavigator.GotoInputData(this);
            }
        }
        private void SetModelITSettings()
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.dataDevice = cbDeviceSet.Text;
            Properties.Settings.Default.dataPort = cbPortSet.Text;
            Properties.Settings.Default.Save();
        }

        private void ItSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormNavigator.GotoInputData(this);
        }
    }
}
