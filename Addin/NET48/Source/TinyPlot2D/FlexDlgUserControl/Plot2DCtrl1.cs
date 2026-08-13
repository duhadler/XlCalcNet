using CodingSeb.ExpressionEvaluator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using TinyPlot2DUserCtrl;


namespace TinyPlot2DCtrl
{

    public partial class Plot2DCtrl : UserControl
    {


        #region Init


        private static string ActiveFileName = "";
        private static string StartWorkDir = "";

        ExpressionEvaluator evaluator = new ExpressionEvaluator();

        public static WpfGraphicsSettings wpfSettings1 = new WpfGraphicsSettings();
        public static CallServer CallServer1 = new CallServer();

        private float Row0Height = 0;
        private float Row1Height = 0;
        private float Col1Width = 0;
        DataTable dtFiles = new DataTable();
        DataTable dtTables = new DataTable();

        static string _PythonRootDir;
        public static string _MyDocDir;
        string _WorkDir;
        static string _LocalAppDataDir;
        public static string _TexturePath;

        public PropertyGrid propertyGrid1;

        //private ElementHost elementHost3D = new ElementHost();
        //private Boolean WpfIsInitializing = true;



        public Plot2DCtrl(string PythonRootDir)
        {
            _PythonRootDir = PythonRootDir;
            _MyDocDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _WorkDir = _MyDocDir + @"\DataXlCalcNet";
            _TexturePath = _WorkDir + @"\DataExamples\MainExamples\Pics"; // + Texture1; ;
            _LocalAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);


            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            var ci = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            Thread.CurrentThread.CurrentCulture = ci;
            InitCtrl();
        }


        //private void InitWpfGraphics()
        //{
        //    WpfIsInitializing = false;
        //}

        //void NewModel()
        //{
        //    string Title = "Evaluation has started ...";

        //    Title = wpfSettings1.Title;

        //}






        public string GetBinPath()
        {
            string BinPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(BinPath);
            return BinPath;
        }

        public string GetDataPath()
        {
            var mainItem = comboBoxLanguage.SelectedItem;
            if (mainItem == null)
            {
                mainItem = comboBoxLanguage.Items[0];
            }
            string mainItemStr = mainItem.ToString().Trim();
            string res = _WorkDir + @"\" + mainItemStr;
            //MessageBox.Show(res);
            return res;
        }



        public string GetTemplatePath()
        {
            return GetDataPath();
        }


        public string GetFullWorkPath()
        {
            string FullWorkPath = "";
            if (comboBoxDirectories.SelectedItem != null)
            {
                string ts1 = comboBoxLanguage.SelectedItem.ToString();
                ts1 = _WorkDir + @"\" + ts1 + @"\";

                string ts2 = comboBoxDirectories.SelectedItem.ToString();
                ts2 = ts1 + ts2 + @"\";

                string ts3 = comboBoxFiles.SelectedItem.ToString();
                FullWorkPath = ts2 + ts3 + @"\";
            }
            return FullWorkPath;
        }






        public void InitCtrl()
        {
            StartWorkDir = Directory.GetCurrentDirectory();
            InitializeComponent();
            StartSocketServer();


            SuspendLayout();

            propertyGrid1 = new InheritedPropertyGrid();

            tableLayoutPanelMain.Controls.Add(propertyGrid1, 0, 1);

            propertyGrid1.ContextMenuStrip = contextMenuStripPropertyGrid;
            propertyGrid1.Dock = DockStyle.Fill;
            propertyGrid1.Location = new Point(0, 50);
            propertyGrid1.Margin = new Padding(0);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(764, 476);
            propertyGrid1.TabIndex = 0;
            propertyGrid1.ToolbarVisible = false;
            propertyGrid1.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGrid1_PropertyValueChanged);
            propertyGrid1.SelectedGridItemChanged += new SelectedGridItemChangedEventHandler(propertyGrid1_SelectedGridItemChanged);
            propertyGrid1.LineColor = SystemColors.ControlLight;
            foreach (Control control in propertyGrid1.Controls)
                if (control.GetType().Name == "DocComment")
                {
                    FieldInfo fieldInfo = control.GetType().BaseType.GetField("userSized",
                      BindingFlags.Instance |
                      BindingFlags.NonPublic);
                    fieldInfo.SetValue(control, true);
                    control.Height = 100;
                    Font = new Font(new FontFamily("Microsoft Sans Serif"), 8f); //replace 8f with desired font size
                    control.Font = Font;
                }
            float FontSize = 9.125F;
            var NewFont = new Font("Lucida Sans Typewriter", FontSize);
            propertyGrid1.Font = NewFont;

            dtFiles.Columns.Add("FileName", typeof(string));
            dtTables.Columns.Add("TableName", typeof(string));

            Row0Height = tableLayoutPanelMain.RowStyles[0].Height;
            Row1Height = tableLayoutPanelMain.RowStyles[1].Height;
            Col1Width = Row0Height * 8;

            // Enable DoubleBuffered in dataGridViewProject
            typeof(DataGridView).InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null,
            dataGridViewProject,
            new object[] { true });
            // Strangely, this is necessary to keep the scrollbars visible
            dataGridViewProject.Height = 100;



            string[] folders0 = Directory.GetDirectories(_WorkDir + @"\", "*", SearchOption.TopDirectoryOnly);
            comboBoxDirectories.Items.Clear();
            foreach (var element in folders0)
            {
                string s = Path.GetFileName(element);
                if (s.ToLower().StartsWith("plots2d"))
                { comboBoxLanguage.Items.Add(s); }
            }





            string[] folders = Directory.GetDirectories(GetTemplatePath(), "*", SearchOption.TopDirectoryOnly);
            comboBoxDirectories.Items.Clear();
            foreach (var element in folders)
            {
                string s = Path.GetFileName(element);
                comboBoxDirectories.Items.Add(s);
            }

            evaluator.Variables = new Dictionary<string, object>() { };
            evaluator.Variables["START1"] = 2.5;
            //evaluator.Types.Add(typeof(BuiltIn));

            //InitWpfGraphics();
            //wpfSettings1.SetParams(pictureBox1, tabControl1, lblPictures);

            InitWpfSVG();
            CallServer1.SetParams1(this);

            comboBoxLanguage.SelectedIndex = 0;
            comboBoxDirectories.SelectedIndex = 0;

            // Make sure propertygrid is shown with item 'Import' selected
            GridItem gi = propertyGrid1.EnumerateAllItems().First((item) =>
                    item.PropertyDescriptor != null &&
                    item.PropertyDescriptor.Name.Contains("Import"));
            gi.Select();
            dataGridViewProject.Select();
            dataGridViewProject.Focus();


            LowerPanel2Thirds();
            ResumeLayout();

            tabControl1.SelectedTab = tabSVG;

        }


        public string GetFullOutputPathTop()
        {
            string LocalAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return LocalAppDataDir + @"\XlCalcNetIDE\OutputMonitor";
        }


        private void FillComboBoxdirectories()
        {
            string[] folders = Directory.GetDirectories(GetDataPath() + @"\", "*", SearchOption.TopDirectoryOnly);
            comboBoxDirectories.Items.Clear();
            foreach (var element in folders)
            {
                string s = Path.GetFileName(element);
                comboBoxDirectories.Items.Add(s);
            }
        }


        private void FillComboBoxFiles2()
        {
            string ts = comboBoxDirectories.SelectedItem.ToString();
            //ts = ts.Substring(12) + @"\";
            string TemplatePath = GetDataPath() + @"\" + ts;
            string[] folders = Directory.GetDirectories(TemplatePath, "*", SearchOption.TopDirectoryOnly);
            comboBoxFiles.Items.Clear();
            foreach (var element in folders)
            {
                string s = Path.GetFileName(element);
                comboBoxFiles.Items.Add(s);
            }
        }


        #endregion



        #region Hide and Show

        private void toolStripButtonHide_Click(object sender, EventArgs e)
        {

            if (toolStripButtonHideProjectPanel.Text == "Hide")
            {
                tableLayoutPanelMain.ColumnStyles[1].Width = 0;  // Width is in pixel
                toolStripButtonHideProjectPanel.Text = "Show";
                toolStripButtonHideProjectPanel.ToolTipText = "Show Project Panel";
                string FName = Path.GetFileName(ActiveFileName);
                LabelWorkFile.Text = "  [File: " + FName + "]";
            }
            else
            {
                tableLayoutPanelMain.ColumnStyles[1].Width = Col1Width;  // Width is in pixel
                toolStripButtonHideProjectPanel.Text = "Hide";
                toolStripButtonHideProjectPanel.ToolTipText = "Hide Project Panel";
                LabelWorkFile.Text = "";
            }
        }




        private void HideBottomPanel()
        {
            Row1Height = tableLayoutPanelMain.RowStyles[1].Height;
            tableLayoutPanelMain.SuspendLayout();
            toolStripButton2_3BottomPanel.Visible = false;
            toolStripButton1_2BottomPanel.Visible = false;
            toolStripButton1_3BottomPanel.Visible = false;
            tableLayoutPanelMain.RowStyles[3].Height = 0;  // Width is in percent
            toolStripButtonHideBottomPanel.Text = "Show";
            toolStripButtonHideBottomPanel.ToolTipText = "Show Bottom Panel";
            toolStripButtonFullBottomPanel.Visible = false;
            tableLayoutPanelMain.ResumeLayout();
        }

        private void toolStripButtonHideBottomPanel_Click(object sender, EventArgs e)
        {
            if (toolStripButtonHideBottomPanel.Text == "Hide")
            {
                HideBottomPanel();
            }
            else
            {
                tableLayoutPanelMain.SuspendLayout();
                toolStripButton2_3BottomPanel.Visible = true;
                toolStripButton1_2BottomPanel.Visible = true;
                toolStripButton1_3BottomPanel.Visible = true;
                tableLayoutPanelMain.RowStyles[0].Height = Row0Height;  // Height is in pixel
                tableLayoutPanelMain.RowStyles[1].Height = Row1Height;  // Height is in percent
                tableLayoutPanelMain.RowStyles[3].Height = 100 - Row1Height;  // Height is in percent
                toolStripButtonHideBottomPanel.Text = "Hide";
                toolStripButtonHideBottomPanel.ToolTipText = "Hide Bottom Panel";
                toolStripButtonFullBottomPanel.Visible = true;
                tableLayoutPanelMain.ResumeLayout();
            }
        }


        private void LowerPanelFull()
        {
            Row1Height = tableLayoutPanelMain.RowStyles[1].Height;
            tableLayoutPanelMain.SuspendLayout();
            toolStripButton2_3BottomPanel.Visible = false;
            toolStripButton1_2BottomPanel.Visible = false;
            toolStripButton1_3BottomPanel.Visible = false;
            tableLayoutPanelMain.RowStyles[0].Height = 0;  // Height is in pixel
            tableLayoutPanelMain.RowStyles[1].Height = 0;  // Height is in percent
            toolStripButtonFullBottomPanel.Text = "Back";
            toolStripButtonFullBottomPanel.ToolTipText = "Back to previous layout";
            toolStripButtonHideBottomPanel.Visible = false;
            tableLayoutPanelMain.ResumeLayout();
        }


        private void toolStripButtonFullPanel_Click(object sender, EventArgs e)
        {
            if (toolStripButtonFullBottomPanel.Text == "Full")
            {
                LowerPanelFull();
            }
            else
            {
                tableLayoutPanelMain.SuspendLayout();
                toolStripButton2_3BottomPanel.Visible = true;
                toolStripButton1_2BottomPanel.Visible = true;
                toolStripButton1_3BottomPanel.Visible = true;
                tableLayoutPanelMain.RowStyles[0].Height = Row0Height;  // Height is in pixel
                tableLayoutPanelMain.RowStyles[1].Height = Row1Height;  // Height is in percent
                tableLayoutPanelMain.RowStyles[3].Height = 100 - Row1Height;  // Height is in percent
                toolStripButtonFullBottomPanel.Text = "Full";
                toolStripButtonFullBottomPanel.ToolTipText = "Show Bottom Panel in Full Size";
                toolStripButtonHideBottomPanel.Visible = true;
                tableLayoutPanelMain.ResumeLayout();
            }
        }



        private void LowerPanel2Thirds()
        {
            tableLayoutPanelMain.SuspendLayout();
            Row1Height = 33;
            tableLayoutPanelMain.RowStyles[1].Height = Row1Height;  // Height is in percent
            tableLayoutPanelMain.RowStyles[3].Height = 100 - Row1Height;  // Height is in percent
            tableLayoutPanelMain.ResumeLayout();
        }
        private void toolStripButton2_3_Click(object sender, EventArgs e)
        {
            LowerPanel2Thirds();
        }

        private void LowerPanelHalf()
        {
            tableLayoutPanelMain.SuspendLayout();
            Row1Height = 50;
            tableLayoutPanelMain.RowStyles[1].Height = Row1Height;  // Height is in percent
            tableLayoutPanelMain.RowStyles[3].Height = 100 - Row1Height;  // Height is in percent
            tableLayoutPanelMain.ResumeLayout();
        }


        private void toolStripButton1_2_Click(object sender, EventArgs e)
        {
            LowerPanelHalf();
        }

        private void LowerPanelThird()
        {
            tableLayoutPanelMain.SuspendLayout();
            Row1Height = 67;
            tableLayoutPanelMain.RowStyles[1].Height = Row1Height;  // Height is in percent
            tableLayoutPanelMain.RowStyles[3].Height = 100 - Row1Height;  // Height is in percent
            tableLayoutPanelMain.ResumeLayout();
        }

        private void toolStripButton1_3_Click(object sender, EventArgs e)
        {
            LowerPanelThird();
        }



        #endregion



        #region Project Panel

        private void dataGridViewProject_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridViewProject.SelectedRows.Count > 0)
            {
                string FName = dataGridViewProject.SelectedRows[0].Cells[0].Value.ToString();
                openFileByName(FName);
            }
        }



        private void ComboBoxProjectUpdate()
        {
            {
                string s = comboBoxDirectories.SelectedItem.ToString();
                s = s + @"\" + comboBoxFiles.SelectedItem.ToString();

                showProjectTree2(s);
            }

        }


        private void showProjectTree2(string s)
        {
            //string TemplatePath = GetDataPath();
            string TemplatePath = GetDataPath() + @"\";

            string GetFullWorkPath2 = TemplatePath + s;
            DirectoryInfo di = new DirectoryInfo(GetFullWorkPath2);
            dataGridViewProject.DataSource = null;
            dtFiles.Clear();
            foreach (var file in di.GetFiles())
            {
                //if (true)
                if ((file.Name.ToLower().EndsWith(".xml")))
                {
                    DataRow row = dtFiles.NewRow();
                    row["FileName"] = file.Name;
                    dtFiles.Rows.Add(row);
                }
            }
            dataGridViewProject.DataSource = dtFiles;
            dataGridViewProject.Columns[0].Width = 800;

            if (dtFiles.Rows.Count > 0)
            {
                string FName = dtFiles.Rows[0].Field<String>("FileName");
                //if (!IsInitializing)

                openFileByName(FName);
            }
        }





        private void comboBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxProjectUpdate();
        }



        private void showProjectTreeAndFind(string ext, string FileName)
        {
            DirectoryInfo di = new DirectoryInfo(GetFullWorkPath());
            dataGridViewProject.DataSource = null;
            dtFiles.Clear();
            foreach (var file in di.GetFiles())
            {
                if (file.Name.ToLower().EndsWith(ext.ToLower()))
                {
                    bool skip = false;
                    if (ext == ".m")
                    {
                        if (file.Name.ToLower().EndsWith(".oct.m")) { skip = true; }
                    }

                    if (file.Name.StartsWith("__")) { skip = true; }
                    if (skip == false)
                    {
                        DataRow row = dtFiles.NewRow();
                        row["FileName"] = file.Name;
                        dtFiles.Rows.Add(row);
                    }
                }
            }
            dataGridViewProject.DataSource = dtFiles;
            dataGridViewProject.Columns[0].Width = 800;

            if (dtFiles.Rows.Count > 0)
            {
                String searchValue = FileName.ToLower();
                int rowIndex = -1;
                foreach (DataGridViewRow row in dataGridViewProject.Rows)
                {
                    if (row.Cells[0].Value.ToString().ToLower().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                dataGridViewProject.Rows[rowIndex].Selected = true;
                dataGridViewProject.Rows[rowIndex].Selected = true;
                dataGridViewProject.FirstDisplayedScrollingRowIndex = dataGridViewProject.SelectedRows[0].Index;
            }
        }


        private async Task openFileByNameAsync(string FName, bool UseEditor)
        {
            string Ext = Path.GetExtension(FName).ToLower();
            //string FileName = GetFullWorkPath() + @"\" + FName;
            string FileName = GetFullWorkPath() + FName;

            if (Ext.Contains("xml"))
            {
                wpfSettings1.SetNoTabChange(true);
                ActiveFileName = FileName;
                try
                {
                    if (ActiveFileName.ToLower().EndsWith(".2d.xml"))
                    {
                        wpfSettings1 = wpfSettings1.Load(ActiveFileName);
                        //evaluator.Variables["RES1"] = wpfSettings1.Resolution;

                        propertyGrid1.SelectedObject = wpfSettings1;
                        tabControl1.SelectedTab = tabSVG;
                        WpfSVGCtrl1.Clear();
                        //if (!WpfIsInitializing) Wpf3DCtrl1.ClearModel(); ;

                        string RunAfterLoading = "Always";
                        string SvgPath = "Lituus";
                        if (!string.IsNullOrEmpty(wpfSettings1.RunAfterLoading)) { RunAfterLoading = wpfSettings1.RunAfterLoading; }
                        if (!string.IsNullOrEmpty(wpfSettings1.SvgPath)) 
                            { SvgPath = wpfSettings1.SvgPath; }
                        if (RunAfterLoading.Contains("Always"))
                        {
                            if (RunAfterLoading.Contains("clear previous"))
                            {
                                labelGraphicsSVD.Text = "Evaluation has started ...";
                                WpfSVGCtrl1.Clear();
                                await Task.Delay(10);
                            }
                            tabControl1.SelectedTab = tabSVG;

                            CallServer.TestSocketServerP2();

                            string Title = "";
                            if (!string.IsNullOrEmpty(wpfSettings1.Title)) { Title = wpfSettings1.Title; }
                            labelGraphicsSVD.Text = Title;
                        }
                        else
                        {
                            WpfSVGCtrl1.Clear();
                            labelGraphicsSVD.Text = "Click on Run to show the chart (may be slow)";
                        }
                    }
                }
                catch (IOException)
                {
                }
                wpfSettings1.SetNoTabChange(false);
            }
        }


        private void openFileByName(string FName)
        {
            _ = openFileByNameAsync(FName, false);
        }



        #endregion



        #region Menu



        #region Menu, File



        private void openContainingFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/select, " + "\"" + ActiveFileName + "\"");
        }




        private void Save()
        {
            if (ActiveFileName.ToLower().EndsWith(".2d.xml"))
            {
                wpfSettings1.Save(ActiveFileName);
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control mParent = Parent;
            SaveAsForm mSaveAsForm = new SaveAsForm();
            mSaveAsForm.StartPosition = FormStartPosition.CenterParent;

            mSaveAsForm.FileName = Path.GetFileName(ActiveFileName);
            if (mSaveAsForm.ShowDialog(mParent) == DialogResult.OK)
            {
                ActiveFileName = Path.GetDirectoryName(ActiveFileName) + @"\" + mSaveAsForm.FileName;
                Save();
                string Ext = "";
                string ew = ActiveFileName.ToLower();
                bool ewfound = false;
                if (ew.EndsWith(".2d.xml")) { Ext = ".2d.xml"; ewfound = true; }
                if (!ewfound) { Ext = Path.GetExtension(ActiveFileName); }
                showProjectTreeAndFind(Ext, Path.GetFileName(ActiveFileName));
                mSaveAsForm.Dispose();
            }
            else
            {
                mSaveAsForm.Dispose();
            }

        }


        #endregion




        private async Task RunScriptAsync()
        {
            if (ActiveFileName.ToLower().EndsWith("2d.xml"))
            {
                Save();
                string RunAfterLoading = "Always";
                if (!string.IsNullOrEmpty(wpfSettings1.RunAfterLoading)) { RunAfterLoading = wpfSettings1.RunAfterLoading; }
                if (RunAfterLoading.Contains("Always"))
                {
                    if (RunAfterLoading.Contains("clear previous"))
                    {
                        //if (!WpfIsInitializing) Wpf3DCtrl1.ClearModel();
                        await Task.Delay(20);
                    }
                    //if (!WpfIsInitializing) NewModel();
                }
                //if (!WpfIsInitializing) NewModel();
            }
        }



        private void toolStripButtonRun_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSVG;
            //RunScript();
            _ = RunScriptAsync();
        }


        private void btnTest_Click(object sender, EventArgs e)
        {
            CallServer.TestSocketServerP2();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            WpfSVGCtrl1.Clear();

        }






        #endregion








        void CollapseAllCategoriesToolStripMenuItemClick(object sender, EventArgs e)
        {
            GridItem root = propertyGrid1.SelectedGridItem;
            while (root.Parent != null)
            {
                root = root.Parent;
            }
            foreach (GridItem element in root.GridItems)
            {
                element.Expanded = false;
            }
        }

        void CollapseAllCatgoriesButThisToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        void ExpandAllCategoriesToolStripMenuItemClick(object sender, EventArgs e)
        {
            GridItem root = propertyGrid1.SelectedGridItem;
            while (root.Parent != null)
            {
                root = root.Parent;
            }
            foreach (GridItem element in root.GridItems)
            {
                element.Expanded = true;
            }
        }


        void ComboBoxDirectoriesSelectedIndexChanged(object sender, EventArgs e)
        {
            {
                FillComboBoxFiles2();
                comboBoxFiles.SelectedIndex = 0;
            }
        }









        public double Eval(string Stmt)
        {
            if (string.IsNullOrEmpty(Stmt)) return 0.0;
            Stmt = Stmt.Trim();
            if (Stmt.Length == 0) return 0.0;
            dynamic res;
            try
            {
                res = evaluator.Evaluate(Stmt);
                return (double)res;
            }
            catch (Exception ex)
            {
                res = ex.Message;
                MessageBox.Show(res.ToString());
                richTextBox1.AppendText("Error" + ": " + res.ToString() + Environment.NewLine);
                tabControl1.SelectedTab = tabLog;
                return Double.NaN;
            }
        }


        public double ScriptEval(string Stmt)
        {
            if (string.IsNullOrEmpty(Stmt)) return 0;
            Stmt = Stmt.Trim();
            if (Stmt.Length == 0) return 0;
            dynamic res = 0.0;
            try
            {
                res = evaluator.ScriptEvaluate(Stmt);
                return (double)res;
            }
            catch (Exception ex)
            {
                res = ex.Message;
                MessageBox.Show(res.ToString());
                richTextBox1.AppendText("Error" + ": " + res.ToString() + Environment.NewLine);
                tabControl1.SelectedTab = tabLog;
                return Double.NaN;
            }
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var xe = e.ChangedItem;

            if (xe.Tag != null)
            {
                string TagStr = xe.Tag.ToString();
                //MessageBox.Show(TagStr.ToString());
                if (TagStr == "ExpressionEvaluator")
                {
                    var xeLabel = xe.Label.Trim();
                    string Stmt = xe.Value.ToString();
                    dynamic res;
                    try
                    {
                        //res = evaluator.Evaluate(Stmt);
                        res = Eval(Stmt);
                    }
                    catch (Exception ex)
                    {
                        res = ex.Message;
                        MessageBox.Show(res.ToString());
                        tabControl1.SelectedTab = tabLog;
                    }
                    richTextBox1.AppendText(xeLabel + ": " + res.ToString() + Environment.NewLine);
                }
                //if ((TagStr == "ScriptEvaluator") && wpfSettings1.Plot3DType1.Contains("New Builtin"))
                //{
                //    var xeLabel = xe.Label.Trim();
                //    string Stmt = xe.Value.ToString();
                //    dynamic res;
                //    try
                //    {
                //        //res = evaluator.ScriptEvaluate(Stmt);
                //        res = ScriptEval(Stmt);
                //    }
                //    catch (Exception ex)
                //    {
                //        res = ex.Message;
                //        MessageBox.Show(res.ToString());
                //        tabControl1.SelectedTab = tabLog;
                //    }
                //    richTextBox1.AppendText(xeLabel + ": " + res.ToString() + Environment.NewLine);
                //}
            }
        }

        private void StartSocketServer()
        {
            string PyScriptPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string MainPath = GetCPythonPath();
            //if (MainPath == "") return;
            string PyExe = _PythonRootDir + @"\python.exe";
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

        private void startSocketServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartSocketServer();
        }


        private void startOutputMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string MainPath = _PythonRootDir;
            if (MainPath == "") return;
            string FullPathExe = MainPath + @"\pythonw.exe";
            string FullPathArg = MainPath + @"\Lib\site-packages\xlcalcnet\ShowOutputMonitor.py";
            Process process = new Process();
            process.StartInfo.FileName = FullPathExe;
            process.StartInfo.Arguments = FullPathArg;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            process.StartInfo.WorkingDirectory = MainPath;
            process.StartInfo.UseShellExecute = false;
            process.Start();
        }




        private void scriptEditorexternalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string MainPath = _PythonRootDir;
            if (MainPath == "") return;
            string FullPathExe = MainPath + @"\pythonw.exe";
            string FullPathArg = MainPath + @"\Lib\site-packages\xlcalcnet\ShowEditor.py";
            Process process = new Process();
            process.StartInfo.FileName = FullPathExe;
            process.StartInfo.Arguments = FullPathArg;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            process.StartInfo.WorkingDirectory = MainPath;
            process.StartInfo.UseShellExecute = false;
            process.Start();
        }


        private void matplotlib2DSVGPlotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string MainPath = _PythonRootDir;
            if (MainPath == "") return;
            string FullPathExe = MainPath + @"\pythonw.exe";
            string FullPathArg = MainPath + @"\Lib\site-packages\xlcalcnet\ShowPlot2d.py";
            Process process = new Process();
            process.StartInfo.FileName = FullPathExe;
            process.StartInfo.Arguments = FullPathArg;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            process.StartInfo.WorkingDirectory = MainPath;
            process.StartInfo.UseShellExecute = false;
            process.Start();
        }



        private void dViewerexternalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string MainPath = _PythonRootDir;
            if (MainPath == "") return;
            string FullPathExe = MainPath + @"\pythonw.exe";
            string FullPathArg = MainPath + @"\Lib\site-packages\xlcalcnet\ShowPlot3d.py";
            Process process = new Process();
            process.StartInfo.FileName = FullPathExe;
            process.StartInfo.Arguments = FullPathArg;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            process.StartInfo.WorkingDirectory = MainPath;
            process.StartInfo.UseShellExecute = false;
            process.Start();
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillComboBoxdirectories();
            comboBoxDirectories.SelectedIndex = 0;
        }

        private void openAppdataLocalFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", _LocalAppDataDir + @"\XlCalcNetIDE");
        }

        private void openBinaryFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", GetBinPath());
        }

        private void tinyDataViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string MainPath = _PythonRootDir;
            if (MainPath == "") return;
            string FullPathExe = MainPath + @"\pythonw.exe";
            string FullPathArg = MainPath + @"\Lib\site-packages\xlcalcnet\ShowDataViewer.py";
            Process process = new Process();
            process.StartInfo.FileName = FullPathExe;
            process.StartInfo.Arguments = FullPathArg;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            process.StartInfo.WorkingDirectory = MainPath;
            process.StartInfo.UseShellExecute = false;
            process.Start();
        }


        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            GridItem item = propertyGrid1.SelectedGridItem; //e.NewSelection
            if (item != null)
            {
                string iLabel = item.Label;
                if (iLabel == "B. Custom Properties")
                {
                    string iValue = item.Value.ToString();
                    //MessageBox.Show(iLabel + ": " + iValue);
                    //tabControl1.SelectedTab = tabCustProp;
                }
            }
        }





    }



    public static class PropertyGridExtensions
    {
        public static IEnumerable<GridItem> EnumerateAllItems(this PropertyGrid grid)
        {
            if (grid == null)
                yield break;

            // get to root item
            GridItem start = grid.SelectedGridItem;
            while (start.Parent != null)
            {
                start = start.Parent;
            }

            foreach (GridItem item in start.EnumerateAllItems())
            {
                yield return item;
            }
        }

        public static IEnumerable<GridItem> EnumerateAllItems(this GridItem item)
        {
            if (item == null)
                yield break;

            yield return item;
            foreach (GridItem child in item.GridItems)
            {
                foreach (GridItem gc in child.EnumerateAllItems())
                {
                    yield return gc;
                }
            }
        }
    }

    public partial class InheritedPropertyGrid : PropertyGrid
    {


        protected override void OnPropertyValueChanged(PropertyValueChangedEventArgs e)
        {
            var propertyInfo = SelectedObject.GetType().GetProperty(e.ChangedItem.PropertyDescriptor.Name);
            var tagAttribute = propertyInfo.GetCustomAttributes(typeof(TagAttribute), false);
            try
            {
                if (tagAttribute != null)
                    e.ChangedItem.Tag = ((TagAttribute)tagAttribute[0]).TagValue;
            }
            catch (Exception)
            {
            }
            base.OnPropertyValueChanged(e);
        }
    }




}
