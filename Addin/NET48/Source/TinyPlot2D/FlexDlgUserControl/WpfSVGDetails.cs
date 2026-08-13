using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace TinyPlot2DCtrl
{

    public partial class Plot2DCtrl : UserControl
    {
        private ElementHost elementHostSVG = new ElementHost();
        internal WpfSVGCtrl WpfSVGCtrl1 = new WpfSVGCtrl();

        private void InitWpfSVG()
        {
            tableLayoutPanel1.Controls.Add(elementHostSVG, 0, 1);
            elementHostSVG.BackColor = System.Drawing.SystemColors.Window;
            elementHostSVG.Dock = System.Windows.Forms.DockStyle.Fill;
            //elementHostSVG.ContextMenuStrip = contextMenuStripSVG;
            elementHostSVG.Name = "elementHostSVG";
            elementHostSVG.Child = WpfSVGCtrl1;
        }




    }
}
