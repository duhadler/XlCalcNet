using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace TinyPlot3D
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"C:\Python313");

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            var ci = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            Thread.CurrentThread.CurrentCulture = ci;
            Application.EnableVisualStyles();
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm(args));
            var Main2DForm = new MainForm(args);
            Application.Run(Main2DForm);
            
            
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        
    }
}
