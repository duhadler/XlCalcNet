using ScintillaNET;
using ScintillaNET_FindReplaceDialog;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace FlexDlgUserCtrl
{
    public partial class FlexDlgUserControl1 : UserControl
    {



        #region Init

        private string ActiveFileName = "";
        private float Row0Height = 0;
        private float Row1Height = 0;
        private float Col1Width = 0;
        DataTable dtFiles = new DataTable();

        string _PythonRootDir;
        string _PythonNetPyDll;
        string _MyDocDir;
        string _WorkDir;
        string _LocalAppDataDir;
        string _FileToOpen;



        public FlexDlgUserControl1(string PythonRootDir, string PythonNetPyDll, string FileToOpen)
        {
            _PythonRootDir = PythonRootDir;
            _PythonNetPyDll = PythonNetPyDll;
            _FileToOpen = FileToOpen;
            _MyDocDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _WorkDir = _MyDocDir + @"\DataXlCalcNet";
            _LocalAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            var ci = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;


            InitCtrl();
        }





        public void InitCtrl()
        {
            InitializeComponent();
            SuspendLayout();

            toolStripButtonMoreInfo.Visible = false;

            dtFiles.Columns.Add("FileName", typeof(string));
            Row0Height = tableLayoutPanelMain.RowStyles[0].Height;
            Row1Height = tableLayoutPanelMain.RowStyles[1].Height;
            Col1Width = Row0Height * 8;
            LowerPanelThird();

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
                if ((s.Length > 3) && ("A".IndexOf(s[0]) != -1) && ("0123456789".IndexOf(s[1]) != -1) && ("0123456789".IndexOf(s[2]) != -1))
                { comboBoxLanguage.Items.Add(s); }
            }


            InitScintilla();
            InitTextData();
            InitInfoData();
            InitNewLogData();

            /*
             * Strategy:
             * If triggered from Tools|Tiny IDE: 
             * Start a new external instance, just pass the 3 SelectedIndexes (will load the file) 
             * 
             * 
             * If triggered from the error messages:
             * If the file is in the tree, but is not the present open file, do not start a new external instance. Instead, preserve the error messages. Calculate the indices from the filename, and open the file via the indices.
             * 
             * Otherwise start a new external instance. Set the indices to zero, then load the file directly. Hide the project panel (permanently for this instance), and the Run and Hide buttons. Disable Open Project Panel, Save and SaveAs. Show. Set Editor to Read-only. Show full file name in extra pane. Include lists of all errors in this file.
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             */


            comboBoxLanguage.SelectedIndex = 0;
            comboBoxDirectories.SelectedIndex = 0;
            comboBoxFiles.SelectedIndex = 0;

            //comboBoxLanguage.SelectedIndex = 1;
            //comboBoxDirectories.SelectedIndex = 2;
            //comboBoxFiles.SelectedIndex = 5;


            ComboBoxProjectUpdate();
            //UpdateLabelBuild();
            ResumeLayout();
        }

        private void UpdateLabelBuild()
        {
            if (IsBuildingUserLibDoc()) toolStripLabelBuild.Text = "[BuildDocs]";
            else if (IsBuildingUserLibCSharp()) toolStripLabelBuild.Text = "[BuildDLL]";
            else toolStripLabelBuild.Text = "";
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



        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillComboBoxdirectories();
            comboBoxDirectories.SelectedIndex = 0;
            UpdateLabelBuild();

        }

        void ComboBoxDirectoriesSelectedIndexChanged(object sender, EventArgs e)
        {
            FillComboBoxFiles2();
            comboBoxFiles.SelectedIndex = 0;
            //}
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
            //toolStripButtonHideBottomPanel.ToolTipText = "Show Bottom Panel";
            toolStripButtonHideBottomPanel.ToolTipText = "";
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
            string s = comboBoxDirectories.SelectedItem.ToString();
            //s = s.Substring(6) + @"\" + comboBoxFiles.SelectedItem.ToString();
            s = s + @"\" + comboBoxFiles.SelectedItem.ToString();
            //s = comboBoxFiles.SelectedItem.ToString();
            showProjectTree2(s);
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
                if ((file.Name.ToLower().EndsWith(".py")) || (file.Name.ToLower().EndsWith(".txt")) || (file.Name.ToLower().EndsWith(".bib")) || (file.Name.ToLower().EndsWith(".css")) || (file.Name.ToLower().EndsWith(".svg")) || (file.Name.ToLower().EndsWith(".rst")) || (file.Name.ToLower().EndsWith(".cs")) || (file.Name.ToLower().EndsWith(".vb")) || (file.Name.ToLower().EndsWith(".r")) || (file.Name.ToLower().EndsWith(".xml")) || (file.Name.ToLower().EndsWith(".h")) || (file.Name.ToLower().EndsWith(".bat")) || (file.Name.ToLower().EndsWith(".tex")) || (file.Name.ToLower().EndsWith(".pas")))
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
                openFileByName(FName);
            }
        }



        private void comboBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxProjectUpdate();
        }



        private void FillComboBoxFilesSetByName(string DirName)
        {
            for (int i = 0; i < comboBoxFiles.Items.Count; i++)
            {
                string text = comboBoxFiles.Items[i].ToString();
                if (text == DirName)
                {
                    comboBoxFiles.SelectedIndex = i;
                    break;
                }
            }
        }




        private void showProjectTreeAndFind(string FileName)
        {
            DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(ActiveFileName));
            dataGridViewProject.DataSource = null;
            dtFiles.Clear();
            foreach (var file in di.GetFiles())
            {
                DataRow row = dtFiles.NewRow();
                row["FileName"] = file.Name;
                dtFiles.Rows.Add(row);
            }
            dataGridViewProject.DataSource = dtFiles;
            dataGridViewProject.Columns[0].Width = 800;

            if (dtFiles.Rows.Count > 0)
            {
                String searchValue = FileName.ToLower();
                //MessageBox.Show(searchValue);
                int rowIndex = -1;
                foreach (DataGridViewRow row in dataGridViewProject.Rows)
                {
                    //MessageBox.Show(row.Cells[0].Value.ToString() + ": " +row.Index.ToString());
                    if (row.Cells[0].Value.ToString().ToLower().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                if (rowIndex > -1)
                {
                    dataGridViewProject.Rows[rowIndex].Selected = true;
                    dataGridViewProject.Rows[rowIndex].Selected = true;
                }
                dataGridViewProject.FirstDisplayedScrollingRowIndex = dataGridViewProject.SelectedRows[0].Index;
            }
        }

        private bool IsBuildingUserLibDoc()
        {
            return comboBoxLanguage.SelectedItem.ToString().ToLower().Contains("userlibdocs");
        }

        private bool IsBuildingUserLibCSharp()
        {
            return comboBoxLanguage.SelectedItem.ToString().ToLower().Contains("userlibcsharp");
        }


        private void openFileByName(string FName)
        {
            //MessageBox.Show(FName);
            string Ext = Path.GetExtension(FName).ToLower();
            string s = comboBoxDirectories.SelectedItem.ToString();
            s = s + @"\" + comboBoxFiles.SelectedItem.ToString();

            //string FileName = GetDataPath() + s + @"\" + FName;
            string FileName = GetDataPath() + @"\" + s + @"\" + FName;

            if ((Ext == ".cs") || (Ext == ".vb") || (Ext == ".r") || (Ext == ".txt") || (Ext == ".css") || (Ext == ".rst") || (Ext == ".svg") || (Ext == ".bib") || (Ext == ".xml") || (Ext == ".py") || (Ext == ".tex") || (Ext == ".bat") || (Ext == ".h") || (Ext == ".pas"))
            {
                if ((!IsBuildingUserLibDoc()) && (!IsBuildingUserLibCSharp())) LogScintilla.Text = "";
                //richTextBoxLog.Clear();
                ActiveFileName = FileName;
                //MessageBox.Show(ActiveFileName);
                LoadScriptFromFile(FileName);
                scintilla1.SetSavePoint();
                UpdateChangeIndicator();
                tabControl1.SelectedTab = tabNewLog;
            }

        }


        #endregion



        #region Menu



        #region Menu, File



        private void openContainingFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/select, " + "\"" + ActiveFileName + "\"");
        }


        private void openAppdataFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", _LocalAppDataDir + @"\XlCalcNetIDE");
        }

        private void openBinFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", GetBinPath());
        }


        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            objPPdialog.Document = Printer.PrintDocument;
            objPPdialog.WindowState = FormWindowState.Maximized;
            objPPdialog.ShowDialog();
        }


        private void pageSetupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Printer.ShowPageSetupDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Printer.Print();
        }



        private void Save()
        {
            SaveScript();
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
                //string Ext = "";
                //string ew = ActiveFileName.ToLower();
                //bool ewfound = false;
                //if (!ewfound) { Ext = Path.GetExtension(ActiveFileName); }
                showProjectTreeAndFind(Path.GetFileName(ActiveFileName));
                mSaveAsForm.Dispose();
            }
            else
            {
                mSaveAsForm.Dispose();
            }

        }


        #endregion



        #region Scintilla specific menu items, Edit


        private void toolStripDropDownButtonEdit_MouseEnter(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = scintilla1.CanUndo;
            redoToolStripMenuItem.Enabled = scintilla1.CanRedo;
            pasteToolStripMenuItem.Enabled = scintilla1.CanPaste;
            Boolean HasSelection = (scintilla1.SelectionStart != scintilla1.SelectionEnd);
            cutToolStripMenuItem.Enabled = HasSelection;
            copyToolStripMenuItem.Enabled = HasSelection;
            deleteToolStripMenuItem.Enabled = HasSelection;
        }



        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.SelectAll();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // !!! NOT working !!!
            scintilla1.SetEmptySelection(0);
        }

        private void insertBlockCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (scintilla1.SelectedText.Length > 0)
            {
                int f = scintilla1.LineFromPosition(scintilla1.SelectionStart);
                int t = scintilla1.LineFromPosition(scintilla1.SelectionEnd - 1);
                for (int i = f; i <= t; i++)
                {
                    scintilla1.InsertText(scintilla1.Lines[i].Position, CommentStr);
                }
            }
        }

        private void removeBlockCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (scintilla1.SelectedText.Length > 0)
            {
                int f = scintilla1.LineFromPosition(scintilla1.SelectionStart);
                int t = scintilla1.LineFromPosition(scintilla1.SelectionEnd - 1);
                for (int i = f; i <= t; i++)
                {
                    if (scintilla1.Lines[i].Text.StartsWith(CommentStr))
                    {
                        scintilla1.DeleteRange(scintilla1.Lines[i].Position, CommentStr.Length);
                    }
                }
            }
            scintilla1.SelectionStart = scintilla1.SelectionEnd;
        }

        private void GenerateKeystrokes(string keys)
        {
            scintilla1.Focus();
            SendKeys.Send(keys);
        }


        private void indentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateKeystrokes("{TAB}");
        }

        private void outdentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateKeystrokes("+{TAB}");
        }


        #endregion



        #region Scintilla specific menu items, View




        private void collapseAllFoldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveFileName.EndsWith(".cs"))
            {
                // See also: https://github.com/jacobslusser/ScintillaNET/issues/307
                int mylinecount = scintilla1.Lines.Count - 1;
                for (int i = mylinecount; i > 0; i--)
                {
                    string curline = scintilla1.Lines[i].Text;
                    if (curline.Contains("#region "))
                    {
                        scintilla1.Lines[i].FoldLine(FoldAction.Contract);
                    }
                }
            }
            else if (ActiveFileName.EndsWith(".py"))
            {
                scintilla1.FoldAll(FoldAction.Contract);
                int mylinecount = scintilla1.Lines.Count - 1;
                for (int i = 0; i < mylinecount; i++)
                {
                    string curline = scintilla1.Lines[i].Text;
                    if (curline.Contains("def main_tests():"))
                    {
                        scintilla1.Lines[i].FoldLine(FoldAction.Expand);
                    }
                }
            }


            else scintilla1.FoldAll(FoldAction.Contract);
        }

        private void expandAllFoldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.FoldAll(FoldAction.Expand);
        }





        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // toggle word wrap
            wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;
            scintilla1.WrapMode = wordWrapToolStripMenuItem.Checked ? WrapMode.Word : WrapMode.None;
        }

        private void showIndentGuidesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // toggle indent guides
            showIndentGuidesToolStripMenuItem.Checked = !showIndentGuidesToolStripMenuItem.Checked;
            scintilla1.IndentationGuides = showIndentGuidesToolStripMenuItem.Checked ? IndentView.LookBoth : IndentView.None;
        }

        private void showWhitespaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // toggle view whitespace
            showWhitespaceToolStripMenuItem.Checked = !showWhitespaceToolStripMenuItem.Checked;
            scintilla1.ViewWhitespace = showWhitespaceToolStripMenuItem.Checked ? WhitespaceMode.VisibleAlways : WhitespaceMode.Invisible;
        }

        private void showEOLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // toggle view EOL
            showEOLToolStripMenuItem.Checked = !showEOLToolStripMenuItem.Checked;
            scintilla1.ViewEol = showEOLToolStripMenuItem.Checked ? true : false;
        }


        //private void viewItem1ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ShowEditor();
        //}

        //private void viewItem2ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ShowPropertyGrid();
        //}

        //private void showDataInputToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ShowDataInput();
        //}

        //        private void showEditorAndPropertygridToolStripMenuItem_Click(object sender, EventArgs e)
        //        {
        //            ShowEditorAndPropertyGrid();
        //        }

        //        private void showGridAndDataInputToolStripMenuItem_Click(object sender, EventArgs e)
        //        {
        //            ShowPropertyGridAndDataInput();
        //        }


        #endregion



        #region Scintilla specific menu items, Search



        private void OpenFindDialog()
        {
            ScFindReplace.ShowFind();
        }
        private void OpenReplaceDialog()
        {
            ScFindReplace.ShowReplace();

        }


        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFindDialog();
        }

        private void findAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenReplaceDialog();
        }

        private void goToLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoTo MyGoTo = new GoTo(ScFindReplace.Scintilla);
            MyGoTo.ShowGoToDialog();
        }




        private void toggleBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleBookmark(scintilla1.CurrentPosition);
        }

        private void previousBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var line = scintilla1.LineFromPosition(scintilla1.CurrentPosition);
            var prevLine = scintilla1.Lines[--line].MarkerPrevious(1 << BOOKMARK_MARKER);
            if (prevLine != -1)
                scintilla1.Lines[prevLine].Goto();
        }

        private void nextBookmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var line = scintilla1.LineFromPosition(scintilla1.CurrentPosition);
            var nextLine = scintilla1.Lines[++line].MarkerNext(1 << BOOKMARK_MARKER);
            if (nextLine != -1)
                scintilla1.Lines[nextLine].Goto();
        }

        private void deleteAllBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla1.MarkerDeleteAll(BOOKMARK_MARKER);
        }


        #endregion




        private void toolStripButtonRun_Click(object sender, EventArgs e)
        {
            RunScript();

        }





        private void pythonTutorialonlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.python.org/3.9/tutorial/index.html");
        }


        private void mpmath11onlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://mpmath.org/doc/1.3.0/");
        }


        void NumericalExplorationsToolStripMenuItemClick(object sender, EventArgs e)
        {
            Process.Start("https://duhadler.wordpress.com/");
        }

        void PythonAnywhereToolStripMenuItemClick(object sender, EventArgs e)
        {
            Process.Start("https://www.pythonanywhere.com/");
        }


        #endregion





        //private void scriptEditorexternalToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string FullDLLPath = GetBinPath();
        //    FullDLLPath = FullDLLPath + @"\TinyCSharpPythonIDE.exe";
        //    Process.Start(FullDLLPath);
        //}


        private void characterMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FullPath = Environment.GetEnvironmentVariable("SystemRoot") + @"\System32\charmap.exe";
            Process.Start(FullPath);
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FullPath = Environment.GetEnvironmentVariable("SystemRoot") + @"\System32\calc.exe";
            Process.Start(FullPath);
        }



        // Standard Python Console
        private void CPythonConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string MainPath = _PythonRootDir;
            if (MainPath == "") return;
            string FullPathExe = MainPath + @"\python.exe";
            Process process = new Process();
            process.StartInfo.FileName = FullPathExe;
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.WorkingDirectory = _WorkDir;
            process.StartInfo.UseShellExecute = false;
            process.Start();
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


        private void sampleDataViewerToolStripMenuItem_Click(object sender, EventArgs e)
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



        private void dPlotsViewerToolStripMenuItem1_Click(object sender, EventArgs e)
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




        // Standard python idle shell
        void StartStandardPythonIDLEShellToolStripMenuItemClick(object sender, EventArgs e)
        {
            string MainPath = _PythonRootDir;
            if (MainPath == "") return;
            string FullPathExe = MainPath + @"\python.exe";
            string FullPathArg = MainPath + @"\Lib\idlelib\idle.pyw";
            Process process = new Process();
            process.StartInfo.FileName = FullPathExe;
            process.StartInfo.Arguments = FullPathArg;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            //process.StartInfo.WorkingDirectory = GetDataPath();
            process.StartInfo.WorkingDirectory = _WorkDir;
            process.StartInfo.UseShellExecute = false;
            process.Start();
        }


        private void startSocketServerToolStripMenuItem_Click(object sender, EventArgs e)
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

        void OptionsToolStripMenuItemClick(object sender, EventArgs e)
        {
            Control mParent = this.Parent;
            OptionsForm mOptionsForm = new OptionsForm(_optionsSettings1);
            mOptionsForm.StartPosition = FormStartPosition.CenterParent;

            if (mOptionsForm.ShowDialog(mParent) == DialogResult.OK)
            {
                _optionsSettings1.Save(GetOptionsPath());
            }
            else
            {
                _optionsSettings1 = _optionsSettings1.Load(GetOptionsPath());
            }
            mOptionsForm.Dispose();
        }




        private void ClearAllAnnotations()
        {
            scintilla1.AnnotationClearAll();
            scintilla1.IndicatorCurrent = WARNING_INDICATOR;
            scintilla1.IndicatorClearRange(0, scintilla1.TextLength);
            scintilla1.IndicatorCurrent = ERROR_INDICATOR;
            scintilla1.IndicatorClearRange(0, scintilla1.TextLength);
            scintilla1.Update();
        }

        private void clearAllAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAllAnnotations();
        }



        private void toolStripButtonMoreInfo_Click(object sender, EventArgs e)
        {
            string res = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string site = "";
            if (DocFileHtml == "xlcalcnet")
                site = "file:///" + res + @"/Docs/XlCalcNet/html/";
            if (DocFileHtml == "mpfunlab")
                site = "file:///" + res + @"/Docs/mpfunlab/html/";
            if (DocFileHtml == "userlibnet")
            {
                res = _LocalAppDataDir;
                site = "file:///" + res + @"/XlCalcNetIDE/html/";
            }

            string topic = MoreInfo;
            if (MoreInfo != "") Process.Start("msedge", site + topic);
            //Process.Start("iexplore", site + topic);
            //Process.Start("chrome", site + topic);
            //Process.Start("firefox", site + topic);
            //richTextBoxLog.Text = site + topic;

            // file:///C:/Users/DUHad/Documents/DataXlCalcNet/A05UserLibsDocs/htmlUserDoc/_z06NumericalCalculus/01Polynomials.html

            // file:///C:/Users/DUHad/Documents/Docs/mpfunlab/html/03ElementaryScalarFunctions/06TrigonometricA.html#ctx.sin
        }

        private void infoOnFunctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int startpos = scintilla1.CurrentPosition;
            string MethodName = scintilla1.GetWordFromPosition(startpos);
            //MessageBox.Show(MethodName);

            int curpos = startpos;
            int LastLen = 0;
            char c = (char)scintilla1.GetCharAt(curpos);
            while ((c != '.') && (curpos>10) && (LastLen < 100))
            {
                curpos--;
                LastLen++;
                c = (char)scintilla1.GetCharAt(curpos);
            }
            curpos--;
            string LastCat = scintilla1.GetWordFromPosition(curpos);
            //MessageBox.Show(LastCat);

            if (XlCalcKeyWords1.Contains(LastCat) && !XlCalcKeyWords1.Contains(MethodName))
            { 
            AutoCSelectionChange2(LastCat, MethodName);
            tabControl1.SelectedTab = tabFunctionInfo;
            }
        }


        private void contextMenuStripEditor_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

    }
}
