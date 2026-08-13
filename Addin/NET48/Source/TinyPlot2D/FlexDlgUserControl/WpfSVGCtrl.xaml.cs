
using System.Windows.Controls;

namespace TinyPlot2DCtrl
{
    /// <summary>
    /// Interaction logic for WpfSVGUserControl.xaml
    /// </summary>
    public partial class WpfSVGCtrl : UserControl
    {
        public WpfSVGCtrl()
        {
            InitializeComponent();
        }

        public void SetFileName(string FileName)
        {
            MainSvgViewbox.Source = new System.Uri(@"file:///" + FileName);
        }


        public void Clear()
        {
            MainSvgViewbox.Source = null;
        }


    }
}
