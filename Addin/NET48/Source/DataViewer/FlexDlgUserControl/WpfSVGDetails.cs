using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace TinyDataViewerCtrl
{

    public partial class DataViewerCtrl : UserControl
    {
        private ElementHost elementHostSVG = new ElementHost();
        private WpfSVGCtrl WpfSVGCtrl1 = new WpfSVGCtrl();

        private void InitWpfSVG()
        {
            tabSVG.Controls.Add(elementHostSVG);
            elementHostSVG.BackColor = System.Drawing.SystemColors.Window;
            elementHostSVG.Dock = System.Windows.Forms.DockStyle.Fill;
            //elementHostSVG.ContextMenuStrip = contextMenuStripSVG;
            elementHostSVG.Name = "elementHostSVG";
            elementHostSVG.Child = WpfSVGCtrl1;
        }




    }
}
