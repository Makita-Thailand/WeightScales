using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeightScales
{
    internal class DBConnect
    {
        public SqlConnection conn = new SqlConnection();

        string connStr = @"";
        string InsertTimeDate = "";
        string YearTable = "";
        List<string> lsAlertRec = new List<string>();
        private Form _component_form;
        public DBConnect(Form formInstance)
        {
            _component_form = formInstance;
        }


        public void openConnection()
        {
            try
            {
                conn.ConnectionString = connStr;
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void closeConnection()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string getDateTime()
        {
            try
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// Form_InputData
        /// 
        /// </summary>
        public DataTable getListLocName()
        {
            try
            {
                openConnection();
                string strCMD = "SELECT deviceName FROM LOADCALL_LOCATION";
                DataTable dataTable = new DataTable();
                SqlDataAdapter dtAdap = new SqlDataAdapter(strCMD, conn);
                dtAdap.Fill(dataTable);
                closeConnection();
                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getListSecName(string _valueSec)
        {
            try
            {
                openConnection();
                string strCMD = @"SELECT mmtitsLoad.*, mitsSec.SECTION_NAME
                          FROM[MMTITS].[dbo].[LOADCALL_LOCATION] as mmtitsLoad
                          LEFT JOIN[MITS_MMT].[dbo].[IT_SECTION_MASTER] as mitsSec
                          ON mitsSec.SECTION_CODE = mmtitsLoad.ownerSec
                          WHERE mmtitsLoad.deviceName = @DeviceName";
                DataTable dataTable = new DataTable();
                using (SqlCommand cmd = new SqlCommand(strCMD, conn))
                {
                    cmd.Parameters.AddWithValue("@DeviceName", _valueSec);
                    SqlDataAdapter dtAdap = new SqlDataAdapter(cmd);
                    dtAdap.Fill(dataTable);
                }
                closeConnection();
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw ex;
            }
        }
    }
}

