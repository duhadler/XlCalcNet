using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;


namespace FlexDlgUserCtrl
{
    /// <summary>
    /// Description of OptionsForm.
    /// </summary>
    public partial class OptionsForm : Form
    {
        public OptionsForm(OptionsSettings _optionsSettings1)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            propertyGridOptions.SelectedObject = _optionsSettings1;

            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        void BtnOptionsOKClick(object sender, EventArgs e)
        {
            
            this.Close();
        }
        
        
                

        
    }
}
