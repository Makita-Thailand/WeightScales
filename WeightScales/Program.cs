using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeightScales
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        
        

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Console.WriteLine("dataDevice : " + Properties.Settings.Default.dataDevice);
            Console.WriteLine("dataPort : " + Properties.Settings.Default.dataPort);

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.dataDevice) && !string.IsNullOrWhiteSpace(Properties.Settings.Default.dataPort))
            {
                Application.Run(new InputData());
                //break;
            }
            else
            {
                // เปิดหน้าต่าง ItSetting ให้ผู้ใช้ตั้งค่า
                ItSetting itSetting = new ItSetting();
                itSetting.ShowDialog();
            }
        }
    }
}
