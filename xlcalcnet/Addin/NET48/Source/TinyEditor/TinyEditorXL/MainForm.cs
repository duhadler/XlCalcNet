
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace TinyVBnetIDE
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
        private FlexDlgUserCtrl.FlexDlgUserControl1 userControl11;

        public MainForm(string[] args)
        {
            

            InitializeComponent();

            string PythonRootDir = @"C:\Python313";
            string PythonNetPyDll = "Python313.dll";
            //string MyDocDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //string LocalAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            //string FileToOpen = "";

            string FileToOpen = @"C:\Users\DUHad\Documents\DataXlCalcNet\A01xlcalcnetExamplesPython\B03ElementaryScalar\C06TrigonometricA\D01sin.py";


            userControl11 = new FlexDlgUserCtrl.FlexDlgUserControl1(PythonRootDir, PythonNetPyDll, FileToOpen);

            SuspendLayout();
            userControl11.Dock = DockStyle.Fill;
            Controls.Add(userControl11);
            StartPosition = FormStartPosition.CenterScreen;
            string BinPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(BinPath);
            if (BinPath.Contains("Python38")) { Text = "Tiny C#/Python38 IDE (DataXlCalcNet)"; }
            if (BinPath.Contains("Python39")) { Text = "Tiny C#/Python39 IDE (DataXlCalcNet)"; }
            if (BinPath.Contains("Python310")) { Text = "Tiny C#/Python310 IDE (DataXlCalcNet)"; }
            if (BinPath.Contains("Python311")) { Text = "Tiny C#/Python311 IDE (DataXlCalcNet)"; }
            if (BinPath.Contains("Python312")) { Text = "Tiny C#/Python312 IDE (DataXlCalcNet)"; }
            if (BinPath.Contains("Python313")) { Text = "Tiny C#/Python313 IDE (DataXlCalcNet)"; }


            float[] Dpi = DPI.GetDpi();
            int Width = (int)(7.2 * Dpi[0]);
            int Height = (int)(9 * Dpi[1]);
            this.Height = Height;
            this.Width = Width;
            ClientSize = new Size(Width, Height);


            ResumeLayout(true);

        }


    }
}
