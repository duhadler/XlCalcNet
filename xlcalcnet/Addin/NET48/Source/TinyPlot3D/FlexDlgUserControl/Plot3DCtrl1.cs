using CodingSeb.ExpressionEvaluator;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;


namespace TinyPlot3DCtrl
{

    public partial class Plot3DCtrl : UserControl
    {


        #region Init

        private static string LibArbPrecNet;
        private static string LibUserFixedPrecNet;
        private static string LibUserArbPrecNet;


        private static bool HasArbPrecNet = false;
        private static bool HasUserFixedPrecNet = false;
        private static bool HasUserArbPrecNet = false;

        private static string ActiveFileName = "";
        private static string StartWorkDir = "";

        ExpressionEvaluator evaluator = new ExpressionEvaluator();

        public static WpfGraphicsSettings wpfSettings1 = new WpfGraphicsSettings();

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

        private ElementHost elementHost3D = new ElementHost();
        private Wpf3DCtrl Wpf3DCtrl1 = new Wpf3DCtrl();
        private Data3DNew Data3D1New = null;
        private Boolean WpfIsInitializing = true;


        static System.Reflection.Assembly LoadFromXlCalcNet(object sender,
            ResolveEventArgs args)
        {
            string folderPath2 = _PythonRootDir +
                @"\Lib\site-packages\xlcalcnet\Addin\NET48\Bin";
            string assemblyPath = System.IO.Path.Combine(folderPath2, new System
                .Reflection.AssemblyName(args.Name).Name + ".dll");
            if (!System.IO.File.Exists(assemblyPath)) return null;
            else return System.Reflection.Assembly.LoadFrom(assemblyPath);
        }


        static System.Reflection.Assembly LoadFromXlCalcNet2(object sender,
            ResolveEventArgs args)
        {
            string folderPath2 = _PythonRootDir +
                @"\Lib\site-packages\xlcalcnet2\Addin\NET48\Bin";
            string assemblyPath = System.IO.Path.Combine(folderPath2, new System
                .Reflection.AssemblyName(args.Name).Name + ".dll");
            if (!System.IO.File.Exists(assemblyPath)) return null;
            else return System.Reflection.Assembly.LoadFrom(assemblyPath);
        }


        static System.Reflection.Assembly LoadFromAppLocal(object sender,
            ResolveEventArgs args)
        {
            string folderPath2 = _LocalAppDataDir + @"\Local\XlCalcNetIDE\Bin";
            string assemblyPath = System.IO.Path.Combine(folderPath2, new System
                .Reflection.AssemblyName(args.Name).Name + ".dll");
            if (!System.IO.File.Exists(assemblyPath)) return null;
            else return System.Reflection.Assembly.LoadFrom(assemblyPath);
        }


        public Plot3DCtrl(string PythonRootDir)
        {
            _PythonRootDir = PythonRootDir;
            _MyDocDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _WorkDir = _MyDocDir + @"\DataXlCalcNet";
            _TexturePath = _WorkDir + @"\DataExamples\MainExamples\Pics"; // + Texture1; ;
            _LocalAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            LibArbPrecNet = _PythonRootDir + @"\Lib\site-packages\xlcalcnet2\Addin\NET48\Bin\ArbPrecNet.dll";
            LibUserFixedPrecNet = _LocalAppDataDir + @"\XlCalcNetIDE\Bin\UserFixedPrecNet.dll";
            LibUserArbPrecNet = _LocalAppDataDir + @"\XlCalcNetIDE\Bin\UserArbPrecNet.dll";

            if (File.Exists(LibArbPrecNet)) HasArbPrecNet = true;
            if (File.Exists(LibUserFixedPrecNet)) HasUserFixedPrecNet = true;
            if (File.Exists(LibUserArbPrecNet)) HasUserArbPrecNet = true;

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve +=
                new ResolveEventHandler(LoadFromXlCalcNet);
            currentDomain.AssemblyResolve +=
                new ResolveEventHandler(LoadFromXlCalcNet2);
            currentDomain.AssemblyResolve +=
                new ResolveEventHandler(LoadFromAppLocal);


            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            var ci = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            Thread.CurrentThread.CurrentCulture = ci;
            InitCtrl();
        }


        private void InitWpfGraphics()
        {
            tableLayoutPanel3DGraph.Controls.Add(elementHost3D, 1, 1);
            elementHost3D.BackColor = System.Drawing.SystemColors.Window;
            elementHost3D.Dock = DockStyle.Fill;
            elementHost3D.ContextMenuStrip = contextMenu3D;
            elementHost3D.Name = "elementHost1";
            elementHost3D.Child = Wpf3DCtrl1;
            WpfIsInitializing = false;
        }

        void NewModel()
        {
            string Title = "Evaluation has started ...";
            labelGraphics3D.Text = Title;

            double CameraAnglePhi = wpfSettings1.CameraAnglePhi;
            ScrollBarPhi.Value = (int)CameraAnglePhi;
            double valuePhi = (CameraAnglePhi - 90.0) * Math.PI / 180.0;
            Wpf3DCtrl1.SetCameraPhi(valuePhi);

            double CameraAngleTheta = wpfSettings1.CameraAngleTheta;
            if (CameraAngleTheta == 0) CameraAngleTheta = 180;
            ScrollBarTheta.Value = (int)CameraAngleTheta;

            Wpf3DCtrl1.SetCameraTheta(CameraAngleTheta);

            double CameraRadius = wpfSettings1.CameraRadius;
            if (CameraRadius == 0) CameraRadius = 0;
            SetRadiusFromValue(CameraRadius);
            ScrollBarRadius.Value = (int)CameraRadius;

            Wpf3DCtrl1.SetCameraType(wpfSettings1.CameraIsOrthographic);


            if ((wpfSettings1.Plot3DType1 == "Altitude surface, real function") || (wpfSettings1.Plot3DType1 == "Altitude surface, complex function") || (wpfSettings1.Plot3DType1 == "Parametric surface"))
            {
                Wpf3DCtrl1.ClearModel();
                Data3D1New = new Data3DNew(this);
                Wpf3DCtrl1.DefineExplicitOrParametricModel(this, Data3D1New);
            }
            else if (wpfSettings1.Plot3DType1 == "Path surface")
            {
                Wpf3DCtrl1.ClearModel();
                Wpf3DCtrl1.Define3DPathModel(this);
            }
            else if (wpfSettings1.Plot3DType1 == "Builtin solid")
            {
                Wpf3DCtrl1.ClearModel();
                Wpf3DCtrl1.DefineBuiltInModel(this);
            }

            Title = wpfSettings1.Title;
            labelGraphics3D.Text = Title;

        }






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
            //MessageBox.Show("Start3");


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
                if (s.ToLower().StartsWith("plots3d"))
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
            evaluator.Types.Add(typeof(BuiltIn));


            InitWpfGraphics();
            wpfSettings1.SetParams(pictureBox1, tabControl1, lblPictures);

            comboBoxLanguage.SelectedIndex = 0;
            comboBoxDirectories.SelectedIndex = 0;

            // Make sure propertygrid is shown with item 'Title' selected
            GridItem gi = propertyGrid1.EnumerateAllItems().First((item) =>
                    item.PropertyDescriptor != null &&
                    item.PropertyDescriptor.Name.Contains("Title"));
            gi.Select();
            dataGridViewProject.Select();
            dataGridViewProject.Focus();


            LowerPanel2Thirds();
            ResumeLayout();

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
                    if (ActiveFileName.ToLower().EndsWith(".3d.xml"))
                    {
                        wpfSettings1 = wpfSettings1.Load(ActiveFileName);
                        //evaluator.Variables["RES1"] = wpfSettings1.Resolution;

                        propertyGrid1.SelectedObject = wpfSettings1;
                        tabControl1.SelectedTab = tab3DGraphics;
                        if (!WpfIsInitializing) Wpf3DCtrl1.ClearModel(); ;

                        string RunAfterLoading = "Always";
                        if (!string.IsNullOrEmpty(wpfSettings1.RunAfterLoading)) { RunAfterLoading = wpfSettings1.RunAfterLoading; }
                        if (RunAfterLoading.Contains("Always"))
                        {
                            if (RunAfterLoading.Contains("clear previous"))
                            {
                                if (!WpfIsInitializing) Wpf3DCtrl1.ClearModel();
                                await Task.Delay(10);
                            }
                            if (!WpfIsInitializing) NewModel();
                        }
                        else
                        {
                            if (!WpfIsInitializing) Wpf3DCtrl1.ClearModel();
                            labelGraphics3D.Text = "Click on Run to show the 3D plot (may be slow)";
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
            if (ActiveFileName.ToLower().EndsWith(".3d.xml"))
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
                if (ew.EndsWith(".3d.xml")) { Ext = ".3d.xml"; ewfound = true; }
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
            if (ActiveFileName.ToLower().EndsWith("3d.xml"))
            {
                Save();
                string RunAfterLoading = "Always";
                if (!string.IsNullOrEmpty(wpfSettings1.RunAfterLoading)) { RunAfterLoading = wpfSettings1.RunAfterLoading; }
                if (RunAfterLoading.Contains("Always"))
                {
                    if (RunAfterLoading.Contains("clear previous"))
                    {
                        if (!WpfIsInitializing) Wpf3DCtrl1.ClearModel();
                        await Task.Delay(10);
                    }
                    if (!WpfIsInitializing) NewModel();
                }
                //if (!WpfIsInitializing) NewModel();
            }
        }



        private void toolStripButtonRun_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tab3DGraphics;
            //RunScript();
            _ = RunScriptAsync();
        }





        #endregion




        private void ScrollBarPhi_Scroll(object sender, ScrollEventArgs e)
        {
            double value = (double)e.NewValue;
            wpfSettings1.CameraAnglePhi = value;
            value = (value - 90.0) * Math.PI / 180.0;
            Wpf3DCtrl1.SetCameraPhi(value);
            toolTip1.SetToolTip(ScrollBarPhi, "camera angle phi: " + ScrollBarPhi.Value.ToString());
            propertyGrid1.Refresh();
        }

        private void ScrollBarTheta_Scroll(object sender, ScrollEventArgs e)
        {
            double value = (double)e.NewValue;
            wpfSettings1.CameraAngleTheta = value;
            Wpf3DCtrl1.SetCameraTheta(value / 1.0);
            toolTip1.SetToolTip(ScrollBarTheta, "camera angle theta: " + ScrollBarTheta.Value.ToString());
            propertyGrid1.Refresh();
        }

        private void SetRadiusFromValue(double value)
        {
            wpfSettings1.CameraRadius = value;
            double factor = 1.0;
            if (value < 0) factor = 10 / (Math.Abs(value) + 10);
            if (value > 0) factor = (value + 10) / 10;
            Wpf3DCtrl1.SetCameraFactor(1 / factor);
            toolTip1.SetToolTip(ScrollBarRadius, "camera radius: " + (value).ToString("F"));
            propertyGrid1.Refresh();

        }

        private void ScrollBarRadius_Scroll(object sender, ScrollEventArgs e)
        {
            SetRadiusFromValue((double)e.NewValue);
        }





        #region wpf specific menu items


        private void WpfExportToJpgToolStripMenuItemClick(object sender, EventArgs e)
        {
            //MessageBox.Show(ActiveFileName + ".jpg");
            Wpf3DCtrl1.Save3DBitmap(ActiveFileName + ".jpg", "jpg", true);
        }

        private void WpfExportToPngToolStripMenuItemClick(object sender, EventArgs e)
        {
            //MessageBox.Show(ActiveFileName + ".png");
            Wpf3DCtrl1.Save3DBitmap(ActiveFileName + ".png", "png", false);
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







        public string GetCodePath(string GetFunctionPath, int numPoints, int ExtraDt, double tmin, double tmax)
        {
            var ci = new CultureInfo("en-US", false);
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            string nstr = numPoints.ToString().Trim();
            string EDstr = ExtraDt.ToString().Trim();
            string tminstr = tmin.ToString().Trim();
            string tmaxstr = tmax.ToString().Trim();

            StringBuilder sb = new StringBuilder(10000);
            sb.Append("using System;" + Environment.NewLine);
            sb.Append("using System.Numerics;" + Environment.NewLine);
            sb.Append("using FixedPrecNet;" + Environment.NewLine);

            if (HasArbPrecNet) sb.Append("using ArbPrecNet;" + Environment.NewLine);
            if (HasUserFixedPrecNet) sb.Append("using UserFixedPrecNet;" + Environment.NewLine);
            if (HasUserArbPrecNet) sb.Append("using UserArbPrecNet;" + Environment.NewLine);

            sb.Append(Environment.NewLine);
            sb.Append("namespace EvaluateCS" + Environment.NewLine);
            sb.Append("{" + Environment.NewLine);
            sb.Append("    public class Program" + Environment.NewLine);
            sb.Append("    {" + Environment.NewLine);
            sb.Append("        public double[,] test4()" + Environment.NewLine);
            sb.Append("        {" + Environment.NewLine);
            sb.Append(Environment.NewLine);

            sb.Append("            int numPoints = " + nstr + ";" + Environment.NewLine);
            sb.Append("            int ExtraDt = " + EDstr + ";" + Environment.NewLine);
            sb.Append("            double tmin = " + tminstr + ";" + Environment.NewLine);
            sb.Append("            double tmax = " + tmaxstr + ";" + Environment.NewLine);

            sb.Append("            double[,] d3 = new double[3, numPoints+ExtraDt+1];" + Environment.NewLine);
            sb.Append("            double t = tmin;" + Environment.NewLine);
            sb.Append("            double dt = (tmax - tmin) / (numPoints);" + Environment.NewLine);

            sb.Append("            for (int i = 0; i < numPoints +ExtraDt; i++)" + Environment.NewLine);
            sb.Append("            {" + Environment.NewLine);

            sb.Append("                // Start function definition" + Environment.NewLine);
            sb.Append(GetFunctionPath);
            sb.Append("                // End function definition" + Environment.NewLine);

            if (string.IsNullOrEmpty(wpfSettings1.PathEvalOrder) || (wpfSettings1.PathEvalOrder == "N/A") || (wpfSettings1.PathEvalOrder == "SequenceX"))
            {
                sb.Append("                d3[0, i] = x;" + Environment.NewLine);
                sb.Append("                d3[1, i] = z;" + Environment.NewLine);
                sb.Append("                d3[2, i] = -y;" + Environment.NewLine);
            }
            else if (wpfSettings1.PathEvalOrder == "SequenceY")
            {
                sb.Append("                d3[0, i] = y;" + Environment.NewLine);
                sb.Append("                d3[1, i] = -z;" + Environment.NewLine);
                sb.Append("                d3[2, i] = -x;" + Environment.NewLine);
            }
            else if (wpfSettings1.PathEvalOrder == "SequenceZ")
            {
                sb.Append("                d3[0, i] = -y;" + Environment.NewLine);
                sb.Append("                d3[1, i] = x;" + Environment.NewLine);
                sb.Append("                d3[2, i] = z;" + Environment.NewLine);
            }
            sb.Append("                t += dt;" + Environment.NewLine);
            sb.Append("            }" + Environment.NewLine);
            sb.Append("            return d3;" + Environment.NewLine);
            sb.Append("        }" + Environment.NewLine);
            sb.Append("    }" + Environment.NewLine);
            sb.Append("}" + Environment.NewLine);
            return sb.ToString();
        }


        public string GetCodeReal(string GetFunctionReal, int xResolution, int yResolution, double xmin, double xmax, double ymin, double ymax)
        {
            Directory.SetCurrentDirectory(GetBinPath());
            var ci = new CultureInfo("en-US", false);
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            string xResstr = xResolution.ToString().Trim();
            string yResstr = yResolution.ToString().Trim();
            string xminstr = xmin.ToString().Trim();
            string xmaxstr = xmax.ToString().Trim();
            string yminstr = ymin.ToString().Trim();
            string ymaxstr = ymax.ToString().Trim();

            StringBuilder sb = new StringBuilder(10000);
            sb.Append("using System;" + Environment.NewLine);
            sb.Append("using System.Numerics;" + Environment.NewLine);
            sb.Append("using FixedPrecNet;" + Environment.NewLine);

            if (HasArbPrecNet) sb.Append("using ArbPrecNet;" + Environment.NewLine);
            if (HasUserFixedPrecNet) sb.Append("using UserFixedPrecNet;" + Environment.NewLine);
            if (HasUserArbPrecNet) sb.Append("using UserArbPrecNet;" + Environment.NewLine);

            sb.Append(Environment.NewLine);
            sb.Append("namespace EvaluateCS" + Environment.NewLine);
            sb.Append("{" + Environment.NewLine);
            sb.Append("    public class Program" + Environment.NewLine);
            sb.Append("    {" + Environment.NewLine);
            sb.Append("        public double[,,] test4()" + Environment.NewLine);
            sb.Append("        {" + Environment.NewLine);
            sb.Append(Environment.NewLine);

            sb.Append("            int xResolution = " + xResstr + ";" + Environment.NewLine);
            sb.Append("            int yResolution = " + yResstr + ";" + Environment.NewLine);
            sb.Append("            double xmin = " + xminstr + ";" + Environment.NewLine);
            sb.Append("            double xmax = " + xmaxstr + ";" + Environment.NewLine);
            sb.Append("            double ymin = " + yminstr + ";" + Environment.NewLine);
            sb.Append("            double ymax = " + ymaxstr + ";" + Environment.NewLine);

            sb.Append("            double[,,] d3 = new double[3, xResolution+2, yResolution+2];" + Environment.NewLine);
            sb.Append("            double dx = (xmax - xmin) / xResolution;" + Environment.NewLine);
            sb.Append("            double dy = (ymax - ymin) / yResolution;" + Environment.NewLine);

            sb.Append("            double x = 0.0;" + Environment.NewLine);
            sb.Append("            double y = 0.0;" + Environment.NewLine);

            sb.Append("            for (int ix = 0; ix <= xResolution + 1; ix++)" + Environment.NewLine);
            sb.Append("            {" + Environment.NewLine);
            sb.Append("                for (int iy = 0; iy <= yResolution + 1; iy++)" + Environment.NewLine);
            sb.Append("                {" + Environment.NewLine);
            sb.Append("                    x = xmin + ix * dx;" + Environment.NewLine);
            sb.Append("                    y = ymin + iy * dy;" + Environment.NewLine);

            sb.Append("                    // Start function definition" + Environment.NewLine);
            sb.Append(GetFunctionReal);
            sb.Append("                    // End function definition" + Environment.NewLine);

            sb.Append("                    d3[0, ix, iy] = xmin + ix * dx;" + Environment.NewLine);
            sb.Append("                    d3[1, ix, iy] = ymin + iy * dy;" + Environment.NewLine);
            sb.Append("                    d3[2, ix, iy] = res;" + Environment.NewLine);
            sb.Append("                }" + Environment.NewLine);
            sb.Append("            }" + Environment.NewLine);
            sb.Append("            return d3;" + Environment.NewLine);
            sb.Append("        }" + Environment.NewLine);
            sb.Append("    }" + Environment.NewLine);
            sb.Append("}" + Environment.NewLine);

            return sb.ToString();
        }



        public string GetCodeComplex(string GetFunctionComplex, int xResolution, int yResolution, double xmin, double xmax, double ymin, double ymax)
        {
            var ci = new CultureInfo("en-US", false);
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            string xResstr = xResolution.ToString().Trim();
            string yResstr = yResolution.ToString().Trim();
            string xminstr = xmin.ToString().Trim();
            string xmaxstr = xmax.ToString().Trim();
            string yminstr = ymin.ToString().Trim();
            string ymaxstr = ymax.ToString().Trim();

            StringBuilder sb = new StringBuilder(10000);
            sb.Append("using System;" + Environment.NewLine);
            sb.Append("using System.Numerics;" + Environment.NewLine);
            sb.Append("using FixedPrecNet;" + Environment.NewLine);

            if (HasArbPrecNet) sb.Append("using ArbPrecNet;" + Environment.NewLine);
            if (HasUserFixedPrecNet) sb.Append("using UserFixedPrecNet;" + Environment.NewLine);
            if (HasUserArbPrecNet) sb.Append("using UserArbPrecNet;" + Environment.NewLine);

            sb.Append(Environment.NewLine);
            sb.Append("namespace EvaluateCS" + Environment.NewLine);
            sb.Append("{" + Environment.NewLine);
            sb.Append("    public class Program" + Environment.NewLine);
            sb.Append("    {" + Environment.NewLine);
            sb.Append("        public double[,,] test4()" + Environment.NewLine);
            sb.Append("        {" + Environment.NewLine);
            sb.Append(Environment.NewLine);

            sb.Append("            int xResolution = " + xResstr + ";" + Environment.NewLine);
            sb.Append("            int yResolution = " + yResstr + ";" + Environment.NewLine);
            sb.Append("            double xmin = " + xminstr + ";" + Environment.NewLine);
            sb.Append("            double xmax = " + xmaxstr + ";" + Environment.NewLine);
            sb.Append("            double ymin = " + yminstr + ";" + Environment.NewLine);
            sb.Append("            double ymax = " + ymaxstr + ";" + Environment.NewLine);

            sb.Append("            double[,,] d3 = new double[4, xResolution+2, yResolution+2];" + Environment.NewLine);
            sb.Append("            double dx = (xmax - xmin) / xResolution;" + Environment.NewLine);
            sb.Append("            double dy = (ymax - ymin) / yResolution;" + Environment.NewLine);

            sb.Append("            double x = 0.0;" + Environment.NewLine);
            sb.Append("            double y = 0.0;" + Environment.NewLine);

            sb.Append("            for (int ix = 0; ix <= xResolution + 1; ix++)" + Environment.NewLine);
            sb.Append("            {" + Environment.NewLine);
            sb.Append("                for (int iy = 0; iy <= yResolution + 1; iy++)" + Environment.NewLine);
            sb.Append("                {" + Environment.NewLine);
            sb.Append("                    x = xmin + ix * dx;" + Environment.NewLine);
            sb.Append("                    y = ymin + iy * dy;" + Environment.NewLine);
            sb.Append("                    Complex z = new Complex(x, y);" + Environment.NewLine);

            sb.Append("                    // Start function definition" + Environment.NewLine);
            sb.Append(GetFunctionComplex);
            sb.Append("                    // End function definition" + Environment.NewLine);

            sb.Append("                    d3[0, ix, iy] = xmin + ix * dx;" + Environment.NewLine);
            sb.Append("                    d3[1, ix, iy] = ymin + iy * dy;" + Environment.NewLine);
            sb.Append("                    d3[2, ix, iy] = res.Real;" + Environment.NewLine);
            sb.Append("                    d3[3, ix, iy] = res.Imaginary;" + Environment.NewLine);
            sb.Append("                }" + Environment.NewLine);
            sb.Append("            }" + Environment.NewLine);
            sb.Append("            return d3;" + Environment.NewLine);
            sb.Append("        }" + Environment.NewLine);
            sb.Append("    }" + Environment.NewLine);
            sb.Append("}" + Environment.NewLine);

            return sb.ToString();
        }



        public string GetCodeParams(string GetFunctionParams, int xResolution, int yResolution, double xmin, double xmax, double ymin, double ymax)
        {
            var ci = new CultureInfo("en-US", false);
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            string xResstr = xResolution.ToString().Trim();
            string yResstr = yResolution.ToString().Trim();
            string xminstr = xmin.ToString().Trim();
            string xmaxstr = xmax.ToString().Trim();
            string yminstr = ymin.ToString().Trim();
            string ymaxstr = ymax.ToString().Trim();

            StringBuilder sb = new StringBuilder(10000);
            sb.Append("using System;" + Environment.NewLine);
            sb.Append("using System.Numerics;" + Environment.NewLine);
            sb.Append("using FixedPrecNet;" + Environment.NewLine);

            if (HasArbPrecNet) sb.Append("using ArbPrecNet;" + Environment.NewLine);
            if (HasUserFixedPrecNet) sb.Append("using UserFixedPrecNet;" + Environment.NewLine);
            if (HasUserArbPrecNet) sb.Append("using UserArbPrecNet;" + Environment.NewLine);

            sb.Append(Environment.NewLine);
            sb.Append("namespace EvaluateCS" + Environment.NewLine);
            sb.Append("{" + Environment.NewLine);
            sb.Append("    public class Program" + Environment.NewLine);
            sb.Append("    {" + Environment.NewLine);
            sb.Append("        public double[,,] test4()" + Environment.NewLine);
            sb.Append("        {" + Environment.NewLine);
            sb.Append(Environment.NewLine);

            sb.Append("            int xResolution = " + xResstr + ";" + Environment.NewLine);
            sb.Append("            int yResolution = " + yResstr + ";" + Environment.NewLine);
            sb.Append("            double xmin = " + xminstr + ";" + Environment.NewLine);
            sb.Append("            double xmax = " + xmaxstr + ";" + Environment.NewLine);
            sb.Append("            double ymin = " + yminstr + ";" + Environment.NewLine);
            sb.Append("            double ymax = " + ymaxstr + ";" + Environment.NewLine);

            sb.Append("            double[,,] d3 = new double[3, xResolution+2, yResolution+2];" + Environment.NewLine);
            sb.Append("            double dx = (xmax - xmin) / xResolution;" + Environment.NewLine);
            sb.Append("            double dy = (ymax - ymin) / yResolution;" + Environment.NewLine);

            sb.Append("            double u = 0.0;" + Environment.NewLine);
            sb.Append("            double v = 0.0;" + Environment.NewLine);

            sb.Append("            for (int ix = 0; ix <= xResolution + 1; ix++)" + Environment.NewLine);
            sb.Append("            {" + Environment.NewLine);
            sb.Append("                for (int iy = 0; iy <= yResolution + 1; iy++)" + Environment.NewLine);
            sb.Append("                {" + Environment.NewLine);
            sb.Append("                    u = xmin + ix * dx;" + Environment.NewLine);
            sb.Append("                    v = ymin + iy * dy;" + Environment.NewLine);

            sb.Append("                    // Start function definition" + Environment.NewLine);
            sb.Append(GetFunctionParams);
            sb.Append("                    // End function definition" + Environment.NewLine);

            sb.Append("                    d3[0, ix, iy] = x;" + Environment.NewLine);
            //sb.Append("                    d3[1, ix, iy] = -z;" + Environment.NewLine);
            //sb.Append("                    d3[2, ix, iy] = y;" + Environment.NewLine);
            sb.Append("                    d3[1, ix, iy] = z;" + Environment.NewLine);
            sb.Append("                    d3[2, ix, iy] = -y;" + Environment.NewLine);
            sb.Append("                }" + Environment.NewLine);
            sb.Append("            }" + Environment.NewLine);
            sb.Append("            return d3;" + Environment.NewLine);
            sb.Append("        }" + Environment.NewLine);
            sb.Append("    }" + Environment.NewLine);
            sb.Append("}" + Environment.NewLine);

            return sb.ToString();
        }





        public object RunScriptFromFile(string FName, string Proc)
        {
            // Documents\DataXlCalcNet\Plots3DInteractiveExamplesCodeTest.txt
            //MessageBox.Show(FName + " : " + Proc);
            string ProviderName;
            string MainClass;
            ProviderName = "CSharp";
            MainClass = "EvaluateCS.Program";
            var provider = CodeDomProvider.CreateProvider(ProviderName);
            var cp = new CompilerParameters();
            Directory.SetCurrentDirectory(GetBinPath());
            try
            {
                cp.ReferencedAssemblies.Add("System.dll");
                cp.ReferencedAssemblies.Add("System.Core.dll");
                cp.ReferencedAssemblies.Add("System.Numerics.dll");
                cp.ReferencedAssemblies.Add("System.Data.dll");
                cp.ReferencedAssemblies.Add("FixedPrecNet.dll");

                if (HasArbPrecNet) cp.ReferencedAssemblies.Add(LibArbPrecNet);
                if (HasUserFixedPrecNet) cp.ReferencedAssemblies.Add(LibUserFixedPrecNet);
                if (HasUserArbPrecNet) cp.ReferencedAssemblies.Add(LibUserArbPrecNet);

                cp.CompilerOptions = "/t:library -platform:x64";
                cp.CompilerOptions = cp.CompilerOptions + " -langversion:5 -preferreduilang:en-us";
                cp.GenerateInMemory = true;
                var cr = provider.CompileAssemblyFromFile(cp, FName);
                if (cr.Errors.Count > 0)
                {
                    var sbError = new StringBuilder("");
                    for (int i = 0, loopTo = cr.Errors.Count - 1; i <= loopTo; i++)
                        sbError.Append(Environment.NewLine + "Line " + cr.Errors[i].Line.ToString() + ":" + " Error " + cr.Errors[i].ErrorNumber + ": " + cr.Errors[i].ErrorText);
                    return sbError.ToString();
                }
                var LocalAssembly = cr.CompiledAssembly;
                var LocalInstance = LocalAssembly.CreateInstance(MainClass);
                var LocalInstanceType = LocalInstance.GetType();
                var mi = LocalInstanceType.GetMethod(Proc);
                object Result = null;
                for (int i = 1; i <= 1; i++)
                    Result = mi.Invoke(LocalInstance, null);
                Directory.SetCurrentDirectory(StartWorkDir);
                return Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Directory.SetCurrentDirectory(StartWorkDir);
                return "Error";
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
                if ((TagStr == "ScriptEvaluator") && wpfSettings1.Plot3DType1.Contains("New Builtin"))
                {
                    var xeLabel = xe.Label.Trim();
                    string Stmt = xe.Value.ToString();
                    dynamic res;
                    try
                    {
                        //res = evaluator.ScriptEvaluate(Stmt);
                        res = ScriptEval(Stmt);
                    }
                    catch (Exception ex)
                    {
                        res = ex.Message;
                        MessageBox.Show(res.ToString());
                        tabControl1.SelectedTab = tabLog;
                    }
                    richTextBox1.AppendText(xeLabel + ": " + res.ToString() + Environment.NewLine);
                }
            }
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

        private void toolStripTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void xlCalcNetManualonlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://duhadler.github.io/XlCalcNetDocsOnline/");
        }

        private void interactive3DPlotsTutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://duhadler.github.io/XlCalcNetDocsOnline/B01_GeneralUsage/C02_GuiFunctions.html#starting-the-interactive-3d-wpf-plots");
        }

        private void xlCalcNetSectionHelponlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = comboBoxDirectories.Text + "/" + comboBoxFiles.Text + ".html";
            Process.Start("https://duhadler.github.io/XlCalcNetDocsOnline/" + target);
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
