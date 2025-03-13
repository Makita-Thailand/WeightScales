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
        //TEST
        //string connStr = @"Data Source = T6115;" +
        //                    "Initial Catalog=MMTITS;" + "User id=sa;" +
        //                    "Password=adminadmin;";
        string connStr = @"Data Source = T5134\DEV001;" +
                            "Initial Catalog=MMTITS;" + "User id=sa;" +
                            "Password=AAbb1234;";
        //
        //string connStr = @"Data Source = T0048\MMTDATA;" +
        //                    "Initial Catalog=MMTITS;" +
        //                    "User id=sa;" +
        //                    "Password=atikam@2017;";

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

        public bool executePostWeight(string _vUserID, string _vSec, string _vDev, string _vWC, decimal _vMin, decimal _vMax, string _vW)
        {
            InsertTimeDate = getDateTime();
            try
            {
                using (SqlCommand cmdPOST = new SqlCommand("SP_POST_WEIGHT_MONITORING_LOG", conn))
                {
                    cmdPOST.CommandType = CommandType.StoredProcedure;
                    cmdPOST.Parameters.AddWithValue("@EMP_CODE", _vUserID);
                    cmdPOST.Parameters.AddWithValue("@SECTION", _vSec);
                    cmdPOST.Parameters.AddWithValue("@DEVICE_NAME", _vDev);
                    cmdPOST.Parameters.AddWithValue("@WEIGHT_MONITOR_WORK_CENTER", _vWC);
                    cmdPOST.Parameters.AddWithValue("@WEIGHT_MIN", _vMin);
                    cmdPOST.Parameters.AddWithValue("@WEIGHT_MAX", _vMax);
                    cmdPOST.Parameters.AddWithValue("@WEIGHT_MONITOR_WEIGHT_KG", _vW == "x" ? 0.00m : Convert.ToDecimal(_vW));
                    cmdPOST.Parameters.AddWithValue("@WEIGHT_TIME", InsertTimeDate); // หรือใช้ InsertTimeDate ถ้ามีตัวแปรนี้จริง

                    SqlParameter outputParam = new SqlParameter("@Result", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmdPOST.Parameters.Add(outputParam);
                    cmdPOST.ExecuteNonQuery();
                    int result = (outputParam.Value != DBNull.Value) ? Convert.ToInt32(outputParam.Value) : 0;
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public bool checkTimeInsert(int _modNumber)
        {
            try
            {
                string qrySql = "SELECT SUBSTRING(CONVERT(VARCHAR(10), GETDATE(),108), 1, 5)";
                SqlCommand cmd = new SqlCommand(qrySql, conn);
                string time = cmd.ExecuteScalar().ToString();
                int minute = Convert.ToInt32(time.Split(':')[1]);
                int mod_result = minute % _modNumber;
                if (mod_result == 0)
                {
                    InsertTimeDate = getDateTime().Substring(0, 11);
                    InsertTimeDate += time;
                    string qry = "SELECT COUNT(TEMP_MONITOR_DATETIME) FROM TEMPERATURE_MONITORING_LOG_" + YearTable +
                        " WHERE TEMP_MONITOR_DATETIME = '" + InsertTimeDate + "'";
                    SqlCommand cmdchk = new SqlCommand(qry, conn);
                    if (Convert.ToInt32(cmdchk.ExecuteScalar()) == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void createNewTablePartition()
        {
            try
            {
                string strCMD = "EXEC SP_AUTO_CREATE_WEIGHT_SYSTEM_LOG";
                SqlCommand cmd = new SqlCommand(strCMD, conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string getDate()
        {
            try
            {
                string strCMD = "SELECT TOP(1) MMT_DATE FROM TEMPERATURE_MMT_TRANSAC_ONE_DAY ORDER BY ID DESC";
                SqlCommand cmd = new SqlCommand(strCMD, conn);
                string strDate = Convert.ToString(cmd.ExecuteScalar());
                return strDate;
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

        public DataTable getListUserID(string _value)
        {
            try
            {
                openConnection();
                string strCMD = @"SELECT mitsID.EMP_CODE
                                FROM [MMTITS].[dbo].[LOADCALL_LOCATION] as mmtitsLoad
                                LEFT JOIN [MITS_MMT].[dbo].[USR_PROFILE] as mitsID on mitsID.SECTION_ID = mmtitsLoad.ownerSec
                                WHERE mmtitsLoad.ownerSec = '" + _value + "'AND mitsID.DROP_DATE IS NULL";
                DataTable dataTable = new DataTable();
                SqlDataAdapter dtAdap = new SqlDataAdapter(strCMD, conn);
                dtAdap.Fill(dataTable);
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

