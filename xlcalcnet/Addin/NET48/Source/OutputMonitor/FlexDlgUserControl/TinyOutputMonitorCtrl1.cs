using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
//using System.Windows.Controls;
using System.Windows.Forms;


namespace TinyOutputMonitorCtrl
{
    public partial class OutputMonitorCtrl : UserControl
    {
        string _PythonRootDir = "";
        private string ActiveFileName = "";
        private float Row0Height = 0;
        private float Col1Width = 0;
        DataTable dtFiles = new DataTable();
        private bool IsInitializing = true;
        private bool IsTableGridInitializing = true;
        bool dataGridViewTablesIsNotFormatted = true;


        public string GetFullOutputPathTop()
        {
            string LocalAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return LocalAppDataDir + @"\XlCalcNetIDE\OutputMonitor";
        }


        public OutputMonitorCtrl(string PythonRootDir)
        {
            _PythonRootDir = PythonRootDir;
            InitializeComponent();
            SuspendLayout();
            dtFiles.Columns.Add("FileName", typeof(string));
            dtFiles.Columns.Add("DateTime", typeof(DateTime));
            dtFiles.Columns.Add("Size", typeof(Int64));
            Row0Height = tableLayoutPanelMain.RowStyles[0].Height;
            Col1Width = Row0Height * 12;
            tableLayoutPanelMain.ColumnStyles[1].Width = Col1Width;  // Width is in pixel

            // Enable DoubleBuffered in dataGridViewProject
            typeof(DataGridView).InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null,
            dataGridViewProject,
            new object[] { true });
            // Strangely, this is necessary to keep the scrollbars visible
            dataGridViewProject.Height = 100;


            // Enable DoubleBuffered in dataGridViewTables
            typeof(DataGridView).InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null,
            dataGridViewTables,
            new object[] { true });
            // Strangely, this is necessary to keep the scrollbars visible
            dataGridViewTables.Height = 100;


            // Enable DoubleBuffered in dataGridViewSQLiteDb
            typeof(DataGridView).InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null,
            dataGridViewSQLiteDb,
            new object[] { true });
            // Strangely, this is necessary to keep the scrollbars visible
            dataGridViewSQLiteDb.Height = 100;


            // Enable DoubleBuffered in dataGridViewTablesOutput
            typeof(DataGridView).InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null,
            dataGridViewTablesOutput,
            new object[] { true });
            // Strangely, this is necessary to keep the scrollbars visible
            dataGridViewTablesOutput.Height = 100;


            InitWpfSVG();
            InitTextData();
            InitSQLite();
            comboBoxDataType.SelectedIndex = 0;
            comboBoxDateOrName.SelectedIndex = 0;

            IsInitializing = false;
            ComboBoxProjectUpdate();
            dataGridViewProject.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

            fileSystemWatcher1.Path = GetFullOutputPathTop();
            if (dtFiles.Rows.Count > 0)
            {
                dataGridViewProject.Sort(dataGridViewProject.Columns[1], ListSortDirection.Descending);
                dataGridViewProject.Rows[0].Selected = true;
                dataGridViewProject.FirstDisplayedScrollingRowIndex = dataGridViewProject.SelectedRows[0].Index;
            }
            ResumeLayout();
        }


        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            string FullPath = e.FullPath;
            string FileName = System.IO.Path.GetFileName(FullPath);
            string SortString = "Sort By DateTime, desc.";
            Boolean NotOpened = true;
            while (NotOpened)
            {
                try
                {
                    SortFilesByString(FileName, SortString);
                    openFileByName2(FullPath);
                    NotOpened = false;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                    NotOpened = true;
                }
            }
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
        }

        private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
        }

        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            //MessageBox.Show("Renamed:");
            //MessageBox.Show($"    Old: {e.OldFullPath}");
            //MessageBox.Show($"    New: {e.FullPath}");
        }




        private void openFileByName2(string FName)
        {
            string Ext = System.IO.Path.GetExtension(FName).ToLower();
            string FileName = FName;
            ActiveFileName = FileName;

            

            if ((Ext == ".data") || (Ext == ".txt"))
            {
                tabControlMain.SelectedTab = tabText;
                TextDataScintilla.Text = File.ReadAllText(FileName);
                InitTextDataSyntaxColoring();
            }

            else if (Ext == ".csv")
            {
                tabControlMain.SelectedTab = tabCSV;
                readCSV(FileName);
            }

            else if ((Ext == ".emf") || (Ext == ".png") || (Ext == ".jpg") || (Ext == ".jpeg"))
            {
                tabControlMain.SelectedTab = tabPic;
                //pictureBox1.Load(FileName);
                pictureBox1.ImageLocation=FileName;
            }

            else if (Ext == ".svg")
            {
                tabControlMain.SelectedTab = tabSVG;
                WpfSVGCtrl1.SetFileName(FileName);
            }

            else if (Ext == ".pdf")
            {
                webBrowserPDF.Navigate("file:///" + FileName);
                tabControlMain.SelectedTab = tabPDF;
            }

            else if (Ext == ".db")
            {
                tabControlMain.SelectedTab = tabSQLiteDb;
                GetDBInfo2(FileName);
            }

            else if ((Ext == ".xlsx") || (Ext == ".docx") || (Ext == ".pptx"))
            {
                tabControlMain.SelectedTab = tabOther;
            }


        }




        private void ComboBoxProjectUpdate()
        {
            string ts3 = GetFullOutputPathTop();

            DirectoryInfo di = new DirectoryInfo(ts3);
            dataGridViewProject.DataSource = null;
            dtFiles.Clear();
            string t = comboBoxDataType.SelectedItem.ToString();
            t = t.Substring(1);
            //MessageBox.Show(t);
            foreach (var file in di.GetFiles())
            {
                bool found = false;
                if (t == ".*")
                {
                    if (file.Name.ToLower().EndsWith(".txt") || file.Name.ToLower().EndsWith(".data") || file.Name.ToLower().EndsWith(".csv") || file.Name.ToLower().EndsWith(".svg") || file.Name.ToLower().EndsWith(".emf") || file.Name.ToLower().EndsWith(".png") || file.Name.ToLower().EndsWith(".jpg") || file.Name.ToLower().EndsWith(".jpeg") || file.Name.ToLower().EndsWith(".bmp") || file.Name.ToLower().EndsWith(".tiff") || file.Name.ToLower().EndsWith(".wmf") || file.Name.ToLower().EndsWith(".pdf") || file.Name.ToLower().EndsWith(".xlsx") || file.Name.ToLower().EndsWith(".docx") || file.Name.ToLower().EndsWith(".pptx"))
                    { found = true; }
                }
                else
                if (file.Name.ToLower().EndsWith(t))
                { found = true; }
                if (found)
                {
                    DataRow row = dtFiles.NewRow();
                    row["FileName"] = file.Name;
                    //row["DateTime"] = file.CreationTime;
                    row["DateTime"] = file.LastWriteTime;
                    row["Size"] = file.Length;
                    dtFiles.Rows.Add(row);
                }
            }
            dataGridViewProject.DataSource = dtFiles;
            dataGridViewProject.Columns[0].Width = 300;
            dataGridViewProject.Columns[1].Width = 300;
            dataGridViewProject.Columns[2].Width = 300;


            dataGridViewProject.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;
            dataGridViewProject.Columns[1].SortMode = DataGridViewColumnSortMode.Programmatic;
            dataGridViewProject.Columns[2].SortMode = DataGridViewColumnSortMode.Programmatic;



            if (dtFiles.Rows.Count > 0)
            {
                string FName = dtFiles.Rows[0].Field<String>("FileName");
                FName = ts3 + @"\" + FName;
                openFileByName2(FName);
                dataGridViewProject.Focus();
                dataGridViewProject.Update();
            }
        }


        private void comboBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxProjectUpdate();

        }


        private void dataGridViewTables_CurrentCellChanged(object sender, EventArgs e)
        {
            string FName = ActiveFileName;
            if (!IsTableGridInitializing)
            {
                string TableName = dataGridViewTables.SelectedRows[0].Cells[0].Value.ToString();
                getSQLiteTable2(FName, TableName);
            }
        }


        private void comboBoxDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsInitializing)
                ComboBoxProjectUpdate();
        }



        private void SortFilesByString(string FileName, string SortString)
        {
            string FullPath = GetFullOutputPathTop() + @"\" + FileName;
            var file = new FileInfo(FullPath);

            if (dtFiles.Rows.Count == 0)
            {
                DataRow row = dtFiles.NewRow();
                row["FileName"] = file.Name;
                row["DateTime"] = file.LastWriteTime;
                row["Size"] = file.Length;
                dtFiles.Rows.Add(row);
                dataGridViewProject.Rows[0].Selected = true;
            }
            else
            {
                String searchValue1 = FileName.ToLower();
                bool found = false;
                int rowIndex1 = -1;
                foreach (DataGridViewRow row in dataGridViewProject.Rows)
                {
                    if (row.Cells[0].Value.ToString().ToLower().Equals(searchValue1))
                    {
                        rowIndex1 = row.Index;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    DataRow row = dtFiles.NewRow();
                    row["FileName"] = file.Name;
                    row["DateTime"] = file.LastWriteTime;
                    row["Size"] = file.Length;
                    dtFiles.Rows.Add(row);
                }
                else
                {
                    DataGridViewRow row = dataGridViewProject.Rows[rowIndex1];
                    row.Cells[0].Value = file.Name;
                    row.Cells[1].Value = file.LastWriteTime;
                    row.Cells[2].Value = file.Length;
                }

                if (SortString.Trim() == "Sort By Name, asc.")
                {
                    dataGridViewProject.Sort(dataGridViewProject.Columns[0], ListSortDirection.Ascending);
                }
                else if (SortString.Trim() == "Sort By Name, desc.")
                {
                    dataGridViewProject.Sort(dataGridViewProject.Columns[0], ListSortDirection.Descending);
                }
                else if (SortString.Trim() == "Sort By DateTime, asc.")
                {
                    dataGridViewProject.Sort(dataGridViewProject.Columns[1], ListSortDirection.Ascending);
                }
                else if (SortString.Trim() == "Sort By DateTime, desc.")
                {
                    dataGridViewProject.Sort(dataGridViewProject.Columns[1], ListSortDirection.Descending);
                }
                else if (SortString.Trim() == "Sort By Size, asc.")
                {
                    dataGridViewProject.Sort(dataGridViewProject.Columns[2], ListSortDirection.Ascending);
                }
                else if (SortString.Trim() == "Sort By Size, desc.")
                {
                    dataGridViewProject.Sort(dataGridViewProject.Columns[2], ListSortDirection.Descending);
                }
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
                dataGridViewProject.FirstDisplayedScrollingRowIndex = dataGridViewProject.SelectedRows[0].Index;
            }
        }



        private void SortFiles()
        {
            if (dtFiles.Rows.Count > 0)
            {

                string FileName = dataGridViewProject.SelectedRows[0].Cells[0].Value.ToString();
                //MessageBox.Show(FileName);

                string SortString = comboBoxDateOrName.SelectedItem.ToString();
                //MessageBox.Show(SortString);

                SortFilesByString(FileName, SortString);



            }
        }


        private void comboBoxDateOrName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsInitializing)
                SortFiles();
        }

        private void dataGridViewProject_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridViewProject.SelectedRows.Count > 0)
            {
                string FName = dataGridViewProject.SelectedRows[0].Cells[0].Value.ToString();
                string ts3 = GetFullOutputPathTop();
                FName = ts3 + @"\" + FName;
                openFileByName2(FName);
            }
        }

        private void openProjectPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableLayoutPanelMain.ColumnStyles[1].Width = Col1Width;  // Width is in pixel
            toolStripButtonHideProjectPanel.Text = "Hide";
            toolStripButtonHideProjectPanel.ToolTipText = "Hide Project Panel";
        }

        private void openContainingFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/select, " + "\"" + ActiveFileName + "\"");
        }

        private void openAppdataLocalFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string LocalAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Process.Start("explorer.exe", LocalAppDataDir + @"\XlCalcNetIDE");
        }

        private void openBinaryFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string BinPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Process.Start("explorer.exe", BinPath);
        }

        private void tinyIDEexternalToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void outputViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string MainPath = _PythonRootDir;
            if (MainPath == "") return;
            string FullPathExe = MainPath + @"\pythonw.exe";
            string FullPathArg = MainPath + @"\Lib\site-packages\xlcalcnet\ShowOutputViewer.py";
            Process process = new Process();
            process.StartInfo.FileName = FullPathExe;
            process.StartInfo.Arguments = FullPathArg;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            process.StartInfo.WorkingDirectory = MainPath;
            process.StartInfo.UseShellExecute = false;
            process.Start();
        }

        private void interactive2DPlotsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void interactive3DPlotsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void toolStripButtonHideProjectPanel_Click(object sender, EventArgs e)
        {
            if (toolStripButtonHideProjectPanel.Text == "Hide")
            {
                tableLayoutPanelMain.ColumnStyles[1].Width = 0;  // Width is in pixel
                toolStripButtonHideProjectPanel.Text = "Show";
                toolStripButtonHideProjectPanel.ToolTipText = "Show Project Panel";
            }
            else
            {
                tableLayoutPanelMain.ColumnStyles[1].Width = Col1Width;  // Width is in pixel
                toolStripButtonHideProjectPanel.Text = "Hide";
                toolStripButtonHideProjectPanel.ToolTipText = "Hide Project Panel";
            }


        }

        private void buttonOffice_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(ActiveFileName);
            Process.Start(ActiveFileName);
        }

        private void getTodayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var td = DateTime.Now;
            var tdYear = td.Year.ToString();
            var tdMonth = td.Month.ToString();
            if (tdMonth.Length == 1) tdMonth = "0" + tdMonth;
            var tdDay = td.Day.ToString();
            if (tdDay.Length == 1) tdDay = "0" + tdDay;

            var tdHour = td.Hour.ToString();
        }

        private void dataGridViewProject_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = e.ColumnIndex;
            string FileName = dataGridViewProject.SelectedRows[0].Cells[0].Value.ToString();
            //MessageBox.Show(FileName);

            ListSortDirection direction = ListSortDirection.Descending;
            for (int i = 0; i < dataGridViewProject.Columns.Count; i++)
            {
                if (i == id)
                {
                    if (!(dataGridViewProject.Columns[i].HeaderCell.SortGlyphDirection == SortOrder.Ascending)) direction = ListSortDirection.Ascending;
                }
                else dataGridViewProject.Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
            }
            //direction = ListSortDirection.Ascending;
            dataGridViewProject.Columns[id].HeaderCell.SortGlyphDirection = (SortOrder)direction;
            dataGridViewProject.Sort(dataGridViewProject.Columns[id], direction);

            String searchValue = FileName.ToLower();
            //MessageBox.Show(searchValue);
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
            dataGridViewProject.FirstDisplayedScrollingRowIndex = dataGridViewProject.SelectedRows[0].Index;
            dataGridViewProject.Update();
        }

    }
}
