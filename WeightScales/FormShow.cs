using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WeightScales
{
    public partial class FormShow : Form
    {
        SerialPort serialPortCom = new SerialPort();
        DBConnect db;

        string LocCode = "";
        private string data;
        int count = 0;
        string sqlState = "";

        private FormAlert formAlert = null;

        public FormShow()
        {
            InitializeComponent();
            db = new DBConnect(this);
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //this.txt_version.Text = String.Format("Version {0}", version);
            this.Text = "Weight Scales " + String.Format("{0}", version);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            edInUserID.Text = Properties.Settings.Default.dataUserID;
            edInSec.Text = Properties.Settings.Default.dataSection;
            edInWC.Text = Properties.Settings.Default.dataWorkCen;
            edInDev.Text = Properties.Settings.Default.dataDevice;
            edInPort.Text = Properties.Settings.Default.dataPort;
            edInMin.Text = Convert.ToString(Properties.Settings.Default.dataMin);
            edInMax.Text = Convert.ToString(Properties.Settings.Default.dataMax);

            try
            {
                if (serialPortCom.IsOpen)
                {
                    closeSystem();
                    lbConnect.Text = "Offline";
                    lbConnect.BackColor = Color.Red;
                    lbConnect.ForeColor = Color.White;
                    //txt_scale.Text = "xx.xx   kg.";
                    lbScales.Text = "xx.xx";
                    ed_log.Clear();
                }
                else
                {
                    serialPortCom.PortName = edInPort.Text;
                    serialPortCom.BaudRate = 115200;
                    serialPortCom.ReadTimeout = 3000;  // 3000 มิลลิวินาที (3 วินาที)
                    serialPortCom.WriteTimeout = 3000;
                    serialPortCom.Open();
                    serialPortCom.DiscardInBuffer();  // เคลียร์บัฟเฟอร์ขาเข้า
                    serialPortCom.DiscardOutBuffer(); // เคลียร์บัฟเฟอร์ขาออก

                    lbConnect.Text = "Online";
                    lbConnect.BackColor = Color.Lime;
                    lbConnect.ForeColor = Color.Black;
                    LocCode = edInDev.Text;
                    if (serialPortCom.IsOpen)
                    {
                        string sendData = $"MIN:{Properties.Settings.Default.dataMin},MAX:{Properties.Settings.Default.dataMax}";
                        serialPortCom.WriteLine(sendData);
                        serialPortCom.WriteLine("START");
                        openSystem();
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Form1_Load_IOException: " + ex.Message);
                MessageBox.Show("IOException : " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorSystem();

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Form1_Load InvalidOperationException: " + ex.Message);
                MessageBox.Show("Invalid Operation Exception : " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorSystem();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Form1_Load Unexpected Error: " + ex.Message);
                MessageBox.Show("Form1_Load Unexpected Error : " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorSystem();
            }
        }

        private void SerialPortCom_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                data = serialPortCom.ReadLine()?.Trim();
                Console.WriteLine("data : " + data);
                this.BeginInvoke(new EventHandler(updateLabel));
            }
            catch (IOException ex)
            {
                Console.WriteLine("IOException: " + ex.Message);
                MessageBox.Show("IOException : " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorSystem();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("InvalidOperationException: " + ex.Message);
                MessageBox.Show("Invalid Operation Exception : " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorSystem();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
                MessageBox.Show("Form1_Load Unexpected Error : " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorSystem();
            }
        }

        private void updateLabel(object sender, EventArgs e)
        {
            try
            {
                ed_log.AppendText(data + "\n");
               
                if (data.Equals("Paused", StringComparison.OrdinalIgnoreCase))
                {
                    bool isFormOpen = Application.OpenForms.OfType<FormAlert>().Any();
                    if (!isFormOpen)
                    {
                        lbWeightStatus.BackColor = Color.Red;
                        lbWeightStatus.Text = "No Good";
                        formAlert = new FormAlert();
                        formAlert.Show();
                    }
                }
                string[] strTemp = data.Split(',');
                if (strTemp.Length == 2 && !string.IsNullOrWhiteSpace(strTemp[0]) && !string.IsNullOrWhiteSpace(strTemp[1]))
                {
                    string _strShMoni = strTemp[0].ToString();
                    count++;
                    int i = 0;
                    sqlState = "";
                    while (count > i)
                    {
                        sqlState = sqlState + ". ";
                        i++;
                    }
                    lbSqlState.Text = sqlState;
                    lbSqlState.ForeColor = Color.Green;
                    if (_strShMoni.Equals("x", StringComparison.OrdinalIgnoreCase))
                    {
                        CloseAlert();
                        lbWeightStatus.BackColor = Color.LightGray;
                        lbWeightStatus.Text = "Normal";
                        lbScales.Text = "xx.xx";
                    }
                    else
                    {
                        lbScales.Text = _strShMoni;
                        CloseAlert();
                        lbWeightStatus.Text = "GOOD";
                        lbWeightStatus.BackColor = Color.Green;
                        lbWeightStatus.Width = 59;
                        lbWeightStatus.Height = 175;
                    }
                    if (count > 5)
                    {
                        count = 0;
                        lbSqlState.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                errorSystem();
                MessageBox.Show(ex.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeSystem();
        }

        private void closeSystem()
        {
            try
            {
                if (serialPortCom.IsOpen)
                {
                    serialPortCom.DiscardInBuffer();
                    serialPortCom.DiscardOutBuffer();
                    serialPortCom.WriteLine("STOP"); // ส่งคำสั่งให้ Arduino หยุด
                    System.Threading.Thread.Sleep(500); // รอให้ Arduino รับคำสั่ง
                    serialPortCom.Close();
                }
                /* db.closeConnection();*/
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending STOP command: " + ex.Message);
            }
        }

        private void openSystem()
        {
            if (serialPortCom.IsOpen)
            {
                lbSqlState.Text = "";
                count = 0;
                //txt_scale.ForeColor = Color.Aqua;
                lbScales.ForeColor = Color.Aqua;
            
                /*
                db.openConnection();
                //Initial Tbl Log
                db.createNewTablePartition();
                */
                serialPortCom.DataReceived += new SerialDataReceivedEventHandler(SerialPortCom_DataReceived);
            }
        }

        private void errorSystem()
        {
            CloseAlert();
            lbSqlState.Text = ".  .  .  .";
            lbSqlState.ForeColor = Color.Red;
            lbScales.Text = "xx.xx";
            lbScales.ForeColor = Color.Red;
            lbConnect.Text = "ERR";
            lbConnect.BackColor = Color.Orange;

            txt_statusNetwork.Text = "Fail";
            lbWeightStatus.Text = "Normal";
            lbWeightStatus.ForeColor = Color.LightGray;
            closeSystem();
        }

        private void btnBackMain_Click(object sender, EventArgs e)
        {
            closeSystem();
            FormNavigator.GotoInputData(this);
        }

        private void FormShow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CloseAlert()
        {
            if (formAlert != null)
            {
                formAlert.Close();
                formAlert = null;
            }
        }
    }
}
