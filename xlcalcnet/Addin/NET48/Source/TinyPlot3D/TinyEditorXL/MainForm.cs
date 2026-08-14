
using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace TinyPlot3D
{

    public class DPI
    {

        public static float[] GetDpi()
        {
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                float dpiX = graphics.DpiX;
                float dpiY = graphics.DpiY;
                float[] result = new float[] { dpiX, dpiY };
                return result;
            }
        }
    }


    public partial class MainForm : Form
    {
        private TinyPlot3DCtrl.Plot3DCtrl userControl11;


        public MainForm(string[] args)
        {
            InitializeComponent();
            string PythonRootDir = @"C:\Python313";

            this.userControl11 = new TinyPlot3DCtrl.Plot3DCtrl(PythonRootDir);

            this.SuspendLayout();
            this.userControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(this.userControl11);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiny 3D plot viewer";

            float[] Dpi = DPI.GetDpi();
            int Width = (int)(6 * Dpi[0]);
            int Height = (int)(9 * Dpi[1]);
            this.Height = Height;
            this.Width = Width;
            this.ClientSize = new Size(Width, Height);

            this.ResumeLayout(true);

        }



    }
}
