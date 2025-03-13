using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeightScales
{
    public static class FormNavigator
    {
        public static void GotoItSetting(Form currentForm)
        {
            currentForm.Hide();
            ItSetting itSetting = new ItSetting();
            itSetting.Show();
        }

        public static void GotoFormShow(Form currentForm)
        {
            currentForm.Hide();
            FormShow formShow = new FormShow();
            formShow.Show();
        }

        public static void GotoInputData(Form currentForm)
        {
            currentForm.Hide();
            InputData inputData = new InputData();
            inputData.Show();
        }
    }
}
