
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TinyEditorXL
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
        private TinyOutputMonitorCtrl.OutputMonitorCtrl userControl11;

        public MainForm(string[] args)
        {
            InitializeComponent();

            string PythonRootDir = @"C:\Python313";

            userControl11 = new TinyOutputMonitorCtrl.OutputMonitorCtrl(PythonRootDir);
            SuspendLayout();
            userControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            Controls.Add(userControl11);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Tiny Output Monitor (xlcalcnet)";
            float[] Dpi = DPI.GetDpi();
            int Width = (int)(7.5 * Dpi[0]);
            int Height = (int)(6 * Dpi[1]);
            this.Height = Height;
            this.Width = Width;
            ClientSize = new Size(Width, Height);
            ResumeLayout(true);
        }
    }
}
