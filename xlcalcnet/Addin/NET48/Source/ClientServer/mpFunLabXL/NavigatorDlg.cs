using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ExcelDna.Integration;
using Microsoft.VisualBasic.CompilerServices;

namespace MpFunLabAddin64
{



    public partial class NavigatorDlg : Form
    {

        private string _LibName;
        private string _ProcName;

        private string _MenuLevel1;
        private string _MenuLevel2;
        private string _NavigatorCmdDesc;


        public NavigatorDlg(string MenuLevel1, string MenuLevel2, string NavigatorCmdDesc)
        {
            try
            {
                //MessageBox.Show("in NavigatorDlg1");
                InitializeComponent();
                _MenuLevel1 = MenuLevel1;
                _MenuLevel2 = MenuLevel2;
                _NavigatorCmdDesc = NavigatorCmdDesc;

                //MessageBox.Show("in NavigatorDlg2");
                var Selector1Array = ((dynamic)ExcelDnaUtil.Application).Run("MpFunLabLocal.xlam!" + _MenuLevel1);
                //MessageBox.Show("in NavigatorDlg3");
                string Selector1 = Selector1Array[0].ToString();
                //string Selector1 = Selector1Array(0).ToString();
                //MessageBox.Show("in NavigatorDlg4");
                // MsgBox(Selector1 + ": " + LBound(Selector1Array).ToString + ": " + UBound(Selector1Array).ToString)
                var Selector2Array = ((dynamic)ExcelDnaUtil.Application).Run("MpFunLabLocal.xlam!" + _MenuLevel2, Selector1);
                //MessageBox.Show("in NavigatorDlg5");
                string Selector2 = Selector2Array[0].ToString();
                //MessageBox.Show(Selector2);
                lbLibrary.Items.AddRange(Selector1Array);
                lbProc.Items.AddRange(Selector2Array);

                lbLibrary.SelectedIndex = 0;
                lbProc.SelectedIndex = 0;
                var Desc = ((dynamic)ExcelDnaUtil.Application).Run("MpFunLabLocal.xlam!" + _NavigatorCmdDesc, Selector1, Selector2);
                RichTextBox1.Text = Conversions.ToString(Desc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString());
                throw;
            }
        }



        public string ProcName
        {
            get
            {
                return _ProcName;
            }

            set
            {
                _ProcName = value;
            }
        }

        public string LibName
        {
            get
            {
                return _LibName;
            }

            set
            {
                _LibName = value;
            }
        }

        private void lbLibrary_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Selector1 = lbLibrary.SelectedItem.ToString();
            LibName = Selector1;
            var Selector2Array = ((dynamic)ExcelDnaUtil.Application).Run("MpFunLabLocal.xlam!" + _MenuLevel2, Selector1);
            lbProc.Items.Clear();
            lbProc.Items.AddRange(Selector2Array);
            lbProc.SelectedIndex = 0;
        }

        private void lbProc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcName = lbProc.SelectedItem.ToString();
            var Desc = ((dynamic)ExcelDnaUtil.Application).Run("MpFunLabLocal.xlam!" + _NavigatorCmdDesc, LibName, ProcName);
            RichTextBox1.Text = Conversions.ToString(Desc);

        }

        private string GetCPythonPath()
        {
            string BinPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(BinPath);
            bool found = false;
            while (!found)
            {
                try
                {
                    BinPath = Directory.GetParent(BinPath).FullName;
                    string Temp = BinPath + @"\python.exe";
                    //MessageBox.Show(Temp);
                    if (File.Exists(Temp)) found = true;
                }
                catch (Exception)
                {
                    found = true;
                    BinPath = "";
                    MessageBox.Show("Could not find path to python.exe");
                }
            }
            //MessageBox.Show(BinPath);
            return BinPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PyScriptPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string MainPath = GetCPythonPath();
            //if (MainPath == "") return;
            string PyExe = GetCPythonPath() + @"\python.exe";
            if (File.Exists(PyExe))
            {
                var process = new Process();
                process.StartInfo.FileName = PyExe;
                process.StartInfo.Arguments = PyScriptPath + @"\socketspy.py";
                process.StartInfo.CreateNoWindow = false;
                // process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                //process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            else
            {
                MessageBox.Show("Could not find: " + PyExe);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }



    public static class NavigatorModule
    {


        private static string GetCPythonPath()
        {
            string BinPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(BinPath);
            bool found = false;
            while (!found)
            {
                try
                {
                    BinPath = Directory.GetParent(BinPath).FullName;
                    string Temp = BinPath + @"\python.exe";
                    //MessageBox.Show(Temp);
                    if (File.Exists(Temp)) found = true;
                }
                catch (Exception)
                {
                    found = true;
                    BinPath = "";
                    MessageBox.Show("Could not find path to python.exe");
                }
            }
            //MessageBox.Show(BinPath);
            return BinPath;
        }



        [ComVisible(true)]
        public static void ShowNavigatorDlg(string MenuLevel1, string MenuLevel2, string Desc)
        {
            string Result = "";
            //MessageBox.Show("In ShowNavigatorDlg 1");
            var MyDlg = new NavigatorDlg(MenuLevel1, MenuLevel2, Desc);
            //MessageBox.Show("In ShowNavigatorDlg 2");
            var MyResult = MyDlg.ShowDialog();
            //MessageBox.Show("In ShowNavigatorDlg 3");
            if (MyResult == DialogResult.OK)
            {
                string _MyDocDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string _WorkDir = _MyDocDir + @"\DataXlCalcNet";
                string _LocalAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string _LocalAppDir = _LocalAppDataDir + @"\XlCalcNetIDE";
                Result = MyDlg.LibName + "|" + MyDlg.ProcName + "|" + GetCPythonPath() + "|" + _WorkDir + "|" + _LocalAppDir;
            }
            var Res = ((dynamic)ExcelDnaUtil.Application).Run("MpFunLabLocal.xlam!" + "SetNavigatorResult", Result);
        }



    }



}