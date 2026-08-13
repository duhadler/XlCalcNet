using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace FlexDlgUserCtrl
{

    public partial class FlexDlgUserControl1 : UserControl
    {
        private OptionsSettings _optionsSettings1 = new OptionsSettings();
        
        private string GetOptionsPath()
        {
            string s = GetBinPath();
//            MessageBox.Show(s);
            return GetBinPath() + @"\Options.xml";
        }
        
        private void InitOptions()
        {
            _optionsSettings1 = _optionsSettings1.Load(GetOptionsPath());

        }
        
        



    }
}
