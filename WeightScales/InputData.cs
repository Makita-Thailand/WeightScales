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
    public partial class InputData : Form
    {
        SerialPort serialPortCom = new SerialPort();
        public SqlConnection conn = new SqlConnection();
        DBConnect db;

        public InputData()
        {
            InitializeComponent();
            db = new DBConnect(this);
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //this.txt_version.Text = String.Format("Version {0}", version);
            this.Text = "Weight Scales " + String.Format("{0}", version);
            clearPort();
        }

        private void InputData_Load(object sender, EventArgs e)
        {
            edDevice.Text = Properties.Settings.Default.dataDevice;
            edPortCom.Text = Properties.Settings.Default.dataPort;

            if (Properties.Settings.Default.dataUserID != "")
            {
                edSec.Text = Properties.Settings.Default.dataSection;
                edUserID.Text = Properties.Settings.Default.dataUserID;
                edWC.Text = Properties.Settings.Default.dataWorkCen;
            }
            else
            {
                DataTable dtSection = db.getListSecName(Properties.Settings.Default.dataDevice);
                if (dtSection.Rows.Count > 0)
                {
                    foreach (DataRow item in dtSection.Rows)
                    {
                        edSec.Items.Add(item[6].ToString());
                        edDepID.Text = item[4].ToString();
                        edSecID.Text = item[5].ToString();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("กรุณากรอกรข้อมูล Device และ Port ใหม่อีกครั้ง",
                                        "Warning",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        this.Close();
                        ItSetting itSetting = new ItSetting();
                        itSetting.ShowDialog();
                    }
                }
            }
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(edSec.Text) &&
                !string.IsNullOrEmpty(edUserID.Text) &&
                !string.IsNullOrEmpty(edWC.Text) &&
                !string.IsNullOrEmpty(edMin.Text) &&
                !string.IsNullOrEmpty(edMax.Text))
            {
                SetModelInput();
                //GotoShow();
                FormNavigator.GotoFormShow(this);
            }
            else
            {
                MessageBox.Show("กรอกข้อมูลให้ครบทุกช่อง!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void edSec_TextChanged(object sender, EventArgs e)
        {
            edUserID.Text = "";
            string _strSecID = edSecID.Text;
            foreach (DataRow item in db.getListUserID(_strSecID).Rows)
            {
                edUserID.Items.Add(item[0].ToString());
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            FormNavigator.GotoItSetting(this);
        }

        private void SetModelInput()
        {
            Properties.Settings.Default.dataSection = edSec.Text;
            Properties.Settings.Default.dataUserID = edUserID.Text;
            Properties.Settings.Default.dataWorkCen = edWC.Text;
            Properties.Settings.Default.dataMin = Convert.ToDecimal(edMin.Text);
            Properties.Settings.Default.dataMax = Convert.ToDecimal(edMax.Text);
            Properties.Settings.Default.Save();
        }

        private void InputData_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void InputData_FormClosing(object sender, FormClosingEventArgs e)
        {
            clearPort();
            db.closeConnection();
        }

        private void clearPort()
        {
            if (serialPortCom.IsOpen)
            {
                serialPortCom.DiscardInBuffer();
                serialPortCom.DiscardOutBuffer();
                serialPortCom.Close();
            }
        }
    }
}
