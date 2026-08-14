using System;
using System.Windows.Forms;

namespace TinyPlot3DCtrl
{
    public partial class SaveAsForm : Form
    {

        public string FileName
        {
            get
            {
                return SaveAsTextBox.Text;
            }

            set
            {
                SaveAsTextBox.Text = value;
            }
        }


        public SaveAsForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
