/*
 * Created by SharpDevelop.
 * User: dietrichhadler
 * Date: 29.10.2021
 * Time: 09:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TinyPlot3DCtrl
{
    partial class Plot3DCtrl
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plot3DCtrl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.fileItem2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAppdataLocalFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBinaryFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButtonTools = new System.Windows.Forms.ToolStripDropDownButton();
            this.scriptEditorexternalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dViewerexternalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tinyDataViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorMain1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparatorMain2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonHideProjectPanel = new System.Windows.Forms.ToolStripButton();
            this.LabelWorkFile = new System.Windows.Forms.ToolStripLabel();
            this.toolStripBottom = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonHideBottomPanel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1_3BottomPanel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1_2BottomPanel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2_3BottomPanel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFullBottomPanel = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanelProject = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewProject = new System.Windows.Forms.DataGridView();
            this.comboBoxFiles = new System.Windows.Forms.ComboBox();
            this.comboBoxDirectories = new System.Windows.Forms.ComboBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab3DGraphics = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3DGraph = new System.Windows.Forms.TableLayoutPanel();
            this.ScrollBarPhi = new System.Windows.Forms.VScrollBar();
            this.ScrollBarRadius = new System.Windows.Forms.VScrollBar();
            this.ScrollBarTheta = new System.Windows.Forms.HScrollBar();
            this.labelGraphics3D = new System.Windows.Forms.Label();
            this.tabPicture = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelPicture = new System.Windows.Forms.TableLayoutPanel();
            this.lblPictures = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripPropertyGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.collapseAllCarwgoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseAllCatgoriesButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenu3D = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelMain.SuspendLayout();
            this.toolStripTop.SuspendLayout();
            this.toolStripBottom.SuspendLayout();
            this.tableLayoutPanelProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProject)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tab3DGraphics.SuspendLayout();
            this.tableLayoutPanel3DGraph.SuspendLayout();
            this.tabPicture.SuspendLayout();
            this.tableLayoutPanelPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabLog.SuspendLayout();
            this.contextMenuStripPropertyGrid.SuspendLayout();
            this.contextMenu3D.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanelMain.Controls.Add(this.toolStripTop, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.toolStripBottom, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelProject, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tabControl1, 0, 3);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 4;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1164, 1052);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // toolStripTop
            // 
            this.toolStripTop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanelMain.SetColumnSpan(this.toolStripTop, 2);
            this.toolStripTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripTop.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonFile,
            this.toolStripDropDownButtonTools,
            this.toolStripSeparatorMain1,
            this.toolStripButtonRun,
            this.toolStripSeparatorMain2,
            this.toolStripButtonHideProjectPanel,
            this.LabelWorkFile});
            this.toolStripTop.Location = new System.Drawing.Point(0, 0);
            this.toolStripTop.Name = "toolStripTop";
            this.toolStripTop.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripTop.Size = new System.Drawing.Size(1164, 50);
            this.toolStripTop.TabIndex = 0;
            this.toolStripTop.Text = "toolStrip1";
            // 
            // toolStripDropDownButtonFile
            // 
            this.toolStripDropDownButtonFile.AutoToolTip = false;
            this.toolStripDropDownButtonFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileItem2ToolStripMenuItem,
            this.openAppdataLocalFolderToolStripMenuItem,
            this.openBinaryFolderToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.toolStripDropDownButtonFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonFile.Name = "toolStripDropDownButtonFile";
            this.toolStripDropDownButtonFile.ShowDropDownArrow = false;
            this.toolStripDropDownButtonFile.Size = new System.Drawing.Size(55, 44);
            this.toolStripDropDownButtonFile.Text = "File";
            // 
            // fileItem2ToolStripMenuItem
            // 
            this.fileItem2ToolStripMenuItem.Name = "fileItem2ToolStripMenuItem";
            this.fileItem2ToolStripMenuItem.Size = new System.Drawing.Size(437, 44);
            this.fileItem2ToolStripMenuItem.Text = "Open Containing Folder...";
            this.fileItem2ToolStripMenuItem.Click += new System.EventHandler(this.openContainingFolderToolStripMenuItem_Click);
            // 
            // openAppdataLocalFolderToolStripMenuItem
            // 
            this.openAppdataLocalFolderToolStripMenuItem.Name = "openAppdataLocalFolderToolStripMenuItem";
            this.openAppdataLocalFolderToolStripMenuItem.Size = new System.Drawing.Size(437, 44);
            this.openAppdataLocalFolderToolStripMenuItem.Text = "Open Appdata Local Folder";
            this.openAppdataLocalFolderToolStripMenuItem.Click += new System.EventHandler(this.openAppdataLocalFolderToolStripMenuItem_Click);
            // 
            // openBinaryFolderToolStripMenuItem
            // 
            this.openBinaryFolderToolStripMenuItem.Name = "openBinaryFolderToolStripMenuItem";
            this.openBinaryFolderToolStripMenuItem.Size = new System.Drawing.Size(437, 44);
            this.openBinaryFolderToolStripMenuItem.Text = "Open Binary Folder...";
            this.openBinaryFolderToolStripMenuItem.Click += new System.EventHandler(this.openBinaryFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(434, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(437, 44);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(437, 44);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripDropDownButtonTools
            // 
            this.toolStripDropDownButtonTools.AutoToolTip = false;
            this.toolStripDropDownButtonTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptEditorexternalToolStripMenuItem,
            this.dViewerexternalToolStripMenuItem1,
            this.tinyDataViewerToolStripMenuItem});
            this.toolStripDropDownButtonTools.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonTools.Image")));
            this.toolStripDropDownButtonTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonTools.Name = "toolStripDropDownButtonTools";
            this.toolStripDropDownButtonTools.ShowDropDownArrow = false;
            this.toolStripDropDownButtonTools.Size = new System.Drawing.Size(73, 44);
            this.toolStripDropDownButtonTools.Text = "Tools";
            // 
            // scriptEditorexternalToolStripMenuItem
            // 
            this.scriptEditorexternalToolStripMenuItem.Name = "scriptEditorexternalToolStripMenuItem";
            this.scriptEditorexternalToolStripMenuItem.Size = new System.Drawing.Size(382, 44);
            this.scriptEditorexternalToolStripMenuItem.Text = "Script Editor (external)";
            this.scriptEditorexternalToolStripMenuItem.Click += new System.EventHandler(this.scriptEditorexternalToolStripMenuItem_Click);
            // 
            // dViewerexternalToolStripMenuItem1
            // 
            this.dViewerexternalToolStripMenuItem1.Name = "dViewerexternalToolStripMenuItem1";
            this.dViewerexternalToolStripMenuItem1.Size = new System.Drawing.Size(382, 44);
            this.dViewerexternalToolStripMenuItem1.Text = "Interactive 3D Plots";
            this.dViewerexternalToolStripMenuItem1.Click += new System.EventHandler(this.dViewerexternalToolStripMenuItem1_Click);
            // 
            // tinyDataViewerToolStripMenuItem
            // 
            this.tinyDataViewerToolStripMenuItem.Name = "tinyDataViewerToolStripMenuItem";
            this.tinyDataViewerToolStripMenuItem.Size = new System.Drawing.Size(382, 44);
            this.tinyDataViewerToolStripMenuItem.Text = "Tiny Data Viewer";
            this.tinyDataViewerToolStripMenuItem.Click += new System.EventHandler(this.tinyDataViewerToolStripMenuItem_Click);
            // 
            // toolStripSeparatorMain1
            // 
            this.toolStripSeparatorMain1.Name = "toolStripSeparatorMain1";
            this.toolStripSeparatorMain1.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripButtonRun
            // 
            this.toolStripButtonRun.AutoToolTip = false;
            this.toolStripButtonRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRun.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStripButtonRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRun.Name = "toolStripButtonRun";
            this.toolStripButtonRun.Size = new System.Drawing.Size(60, 44);
            this.toolStripButtonRun.Text = "Run";
            this.toolStripButtonRun.Click += new System.EventHandler(this.toolStripButtonRun_Click);
            // 
            // toolStripSeparatorMain2
            // 
            this.toolStripSeparatorMain2.Name = "toolStripSeparatorMain2";
            this.toolStripSeparatorMain2.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripButtonHideProjectPanel
            // 
            this.toolStripButtonHideProjectPanel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonHideProjectPanel.AutoToolTip = false;
            this.toolStripButtonHideProjectPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonHideProjectPanel.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStripButtonHideProjectPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHideProjectPanel.Name = "toolStripButtonHideProjectPanel";
            this.toolStripButtonHideProjectPanel.Size = new System.Drawing.Size(68, 44);
            this.toolStripButtonHideProjectPanel.Text = "Hide";
            this.toolStripButtonHideProjectPanel.ToolTipText = "Hide/Show Project Panel";
            this.toolStripButtonHideProjectPanel.Click += new System.EventHandler(this.toolStripButtonHide_Click);
            // 
            // LabelWorkFile
            // 
            this.LabelWorkFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LabelWorkFile.Name = "LabelWorkFile";
            this.LabelWorkFile.Size = new System.Drawing.Size(0, 44);
            // 
            // toolStripBottom
            // 
            this.toolStripBottom.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanelMain.SetColumnSpan(this.toolStripBottom, 2);
            this.toolStripBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripBottom.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonHideBottomPanel,
            this.toolStripButton1_3BottomPanel,
            this.toolStripButton1_2BottomPanel,
            this.toolStripButton2_3BottomPanel,
            this.toolStripButtonFullBottomPanel});
            this.toolStripBottom.Location = new System.Drawing.Point(0, 526);
            this.toolStripBottom.Name = "toolStripBottom";
            this.toolStripBottom.Padding = new System.Windows.Forms.Padding(0);
            this.toolStripBottom.Size = new System.Drawing.Size(1164, 50);
            this.toolStripBottom.TabIndex = 1;
            this.toolStripBottom.Text = "toolStripBottom";
            // 
            // toolStripButtonHideBottomPanel
            // 
            this.toolStripButtonHideBottomPanel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonHideBottomPanel.AutoToolTip = false;
            this.toolStripButtonHideBottomPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonHideBottomPanel.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStripButtonHideBottomPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHideBottomPanel.Name = "toolStripButtonHideBottomPanel";
            this.toolStripButtonHideBottomPanel.Size = new System.Drawing.Size(68, 44);
            this.toolStripButtonHideBottomPanel.Text = "Hide";
            this.toolStripButtonHideBottomPanel.ToolTipText = "Change to Hide Bottom Panel";
            this.toolStripButtonHideBottomPanel.Click += new System.EventHandler(this.toolStripButtonHideBottomPanel_Click);
            // 
            // toolStripButton1_3BottomPanel
            // 
            this.toolStripButton1_3BottomPanel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1_3BottomPanel.AutoToolTip = false;
            this.toolStripButton1_3BottomPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1_3BottomPanel.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStripButton1_3BottomPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1_3BottomPanel.Name = "toolStripButton1_3BottomPanel";
            this.toolStripButton1_3BottomPanel.Size = new System.Drawing.Size(53, 44);
            this.toolStripButton1_3BottomPanel.Text = "1/3";
            this.toolStripButton1_3BottomPanel.ToolTipText = "Show Bottom Panel in 1/3 Height";
            this.toolStripButton1_3BottomPanel.Click += new System.EventHandler(this.toolStripButton1_3_Click);
            // 
            // toolStripButton1_2BottomPanel
            // 
            this.toolStripButton1_2BottomPanel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1_2BottomPanel.AutoToolTip = false;
            this.toolStripButton1_2BottomPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1_2BottomPanel.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStripButton1_2BottomPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1_2BottomPanel.Name = "toolStripButton1_2BottomPanel";
            this.toolStripButton1_2BottomPanel.Size = new System.Drawing.Size(53, 44);
            this.toolStripButton1_2BottomPanel.Text = "1/2";
            this.toolStripButton1_2BottomPanel.ToolTipText = "Show Bottom Panel in 1/2 Height";
            this.toolStripButton1_2BottomPanel.Click += new System.EventHandler(this.toolStripButton1_2_Click);
            // 
            // toolStripButton2_3BottomPanel
            // 
            this.toolStripButton2_3BottomPanel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2_3BottomPanel.AutoToolTip = false;
            this.toolStripButton2_3BottomPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2_3BottomPanel.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStripButton2_3BottomPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2_3BottomPanel.Name = "toolStripButton2_3BottomPanel";
            this.toolStripButton2_3BottomPanel.Size = new System.Drawing.Size(53, 44);
            this.toolStripButton2_3BottomPanel.Text = "2/3";
            this.toolStripButton2_3BottomPanel.ToolTipText = "Show Bottom Panel in 2/3 Height";
            this.toolStripButton2_3BottomPanel.Click += new System.EventHandler(this.toolStripButton2_3_Click);
            // 
            // toolStripButtonFullBottomPanel
            // 
            this.toolStripButtonFullBottomPanel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonFullBottomPanel.AutoToolTip = false;
            this.toolStripButtonFullBottomPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonFullBottomPanel.ForeColor = System.Drawing.Color.DarkGreen;
            this.toolStripButtonFullBottomPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFullBottomPanel.Name = "toolStripButtonFullBottomPanel";
            this.toolStripButtonFullBottomPanel.Size = new System.Drawing.Size(56, 44);
            this.toolStripButtonFullBottomPanel.Text = "Full";
            this.toolStripButtonFullBottomPanel.ToolTipText = "Show Bottom Panel in Full Height";
            this.toolStripButtonFullBottomPanel.Click += new System.EventHandler(this.toolStripButtonFullPanel_Click);
            // 
            // tableLayoutPanelProject
            // 
            this.tableLayoutPanelProject.ColumnCount = 1;
            this.tableLayoutPanelProject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProject.Controls.Add(this.dataGridViewProject, 0, 3);
            this.tableLayoutPanelProject.Controls.Add(this.comboBoxFiles, 0, 2);
            this.tableLayoutPanelProject.Controls.Add(this.comboBoxDirectories, 0, 1);
            this.tableLayoutPanelProject.Controls.Add(this.comboBoxLanguage, 0, 0);
            this.tableLayoutPanelProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProject.Location = new System.Drawing.Point(764, 50);
            this.tableLayoutPanelProject.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelProject.Name = "tableLayoutPanelProject";
            this.tableLayoutPanelProject.RowCount = 4;
            this.tableLayoutPanelProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelProject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProject.Size = new System.Drawing.Size(400, 476);
            this.tableLayoutPanelProject.TabIndex = 3;
            // 
            // dataGridViewProject
            // 
            this.dataGridViewProject.AllowUserToAddRows = false;
            this.dataGridViewProject.AllowUserToDeleteRows = false;
            this.dataGridViewProject.AllowUserToResizeRows = false;
            this.dataGridViewProject.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewProject.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewProject.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProject.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProject.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProject.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewProject.Location = new System.Drawing.Point(0, 150);
            this.dataGridViewProject.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewProject.MultiSelect = false;
            this.dataGridViewProject.Name = "dataGridViewProject";
            this.dataGridViewProject.ReadOnly = true;
            this.dataGridViewProject.RowHeadersVisible = false;
            this.dataGridViewProject.RowHeadersWidth = 82;
            this.dataGridViewProject.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewProject.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProject.Size = new System.Drawing.Size(400, 326);
            this.dataGridViewProject.TabIndex = 4;
            this.dataGridViewProject.CurrentCellChanged += new System.EventHandler(this.dataGridViewProject_CurrentCellChanged);
            // 
            // comboBoxFiles
            // 
            this.comboBoxFiles.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBoxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comboBoxFiles.FormattingEnabled = true;
            this.comboBoxFiles.Location = new System.Drawing.Point(0, 100);
            this.comboBoxFiles.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxFiles.Name = "comboBoxFiles";
            this.comboBoxFiles.Size = new System.Drawing.Size(400, 37);
            this.comboBoxFiles.TabIndex = 3;
            this.comboBoxFiles.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiles_SelectedIndexChanged);
            // 
            // comboBoxDirectories
            // 
            this.comboBoxDirectories.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBoxDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxDirectories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirectories.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxDirectories.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comboBoxDirectories.FormattingEnabled = true;
            this.comboBoxDirectories.Location = new System.Drawing.Point(0, 50);
            this.comboBoxDirectories.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxDirectories.Name = "comboBoxDirectories";
            this.comboBoxDirectories.Size = new System.Drawing.Size(400, 37);
            this.comboBoxDirectories.TabIndex = 2;
            this.comboBoxDirectories.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDirectoriesSelectedIndexChanged);
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBoxLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(3, 3);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(394, 37);
            this.comboBoxLanguage.TabIndex = 5;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tableLayoutPanelMain.SetColumnSpan(this.tabControl1, 2);
            this.tabControl1.Controls.Add(this.tab3DGraphics);
            this.tabControl1.Controls.Add(this.tabPicture);
            this.tabControl1.Controls.Add(this.tabLog);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 576);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1164, 476);
            this.tabControl1.TabIndex = 4;
            // 
            // tab3DGraphics
            // 
            this.tab3DGraphics.Controls.Add(this.tableLayoutPanel3DGraph);
            this.tab3DGraphics.Location = new System.Drawing.Point(8, 8);
            this.tab3DGraphics.Margin = new System.Windows.Forms.Padding(0);
            this.tab3DGraphics.Name = "tab3DGraphics";
            this.tab3DGraphics.Size = new System.Drawing.Size(1148, 421);
            this.tab3DGraphics.TabIndex = 4;
            this.tab3DGraphics.Text = "3D Graphics";
            this.tab3DGraphics.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3DGraph
            // 
            this.tableLayoutPanel3DGraph.ColumnCount = 3;
            this.tableLayoutPanel3DGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3DGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3DGraph.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3DGraph.Controls.Add(this.ScrollBarPhi, 0, 0);
            this.tableLayoutPanel3DGraph.Controls.Add(this.ScrollBarRadius, 2, 0);
            this.tableLayoutPanel3DGraph.Controls.Add(this.ScrollBarTheta, 1, 2);
            this.tableLayoutPanel3DGraph.Controls.Add(this.labelGraphics3D, 1, 0);
            this.tableLayoutPanel3DGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3DGraph.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3DGraph.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3DGraph.Name = "tableLayoutPanel3DGraph";
            this.tableLayoutPanel3DGraph.RowCount = 3;
            this.tableLayoutPanel3DGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3DGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3DGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3DGraph.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3DGraph.Size = new System.Drawing.Size(1148, 421);
            this.tableLayoutPanel3DGraph.TabIndex = 0;
            // 
            // ScrollBarPhi
            // 
            this.ScrollBarPhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScrollBarPhi.LargeChange = 1;
            this.ScrollBarPhi.Location = new System.Drawing.Point(0, 0);
            this.ScrollBarPhi.Maximum = 180;
            this.ScrollBarPhi.Name = "ScrollBarPhi";
            this.tableLayoutPanel3DGraph.SetRowSpan(this.ScrollBarPhi, 3);
            this.ScrollBarPhi.Size = new System.Drawing.Size(40, 421);
            this.ScrollBarPhi.TabIndex = 0;
            this.ScrollBarPhi.Value = 108;
            this.ScrollBarPhi.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBarPhi_Scroll);
            // 
            // ScrollBarRadius
            // 
            this.ScrollBarRadius.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScrollBarRadius.Location = new System.Drawing.Point(1108, 0);
            this.ScrollBarRadius.Maximum = 50;
            this.ScrollBarRadius.Minimum = -50;
            this.ScrollBarRadius.Name = "ScrollBarRadius";
            this.tableLayoutPanel3DGraph.SetRowSpan(this.ScrollBarRadius, 3);
            this.ScrollBarRadius.Size = new System.Drawing.Size(40, 421);
            this.ScrollBarRadius.TabIndex = 1;
            this.ScrollBarRadius.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBarRadius_Scroll);
            // 
            // ScrollBarTheta
            // 
            this.ScrollBarTheta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScrollBarTheta.LargeChange = 5;
            this.ScrollBarTheta.Location = new System.Drawing.Point(40, 381);
            this.ScrollBarTheta.Maximum = 364;
            this.ScrollBarTheta.Name = "ScrollBarTheta";
            this.ScrollBarTheta.Size = new System.Drawing.Size(1068, 40);
            this.ScrollBarTheta.TabIndex = 2;
            this.ScrollBarTheta.Value = 120;
            this.ScrollBarTheta.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBarTheta_Scroll);
            // 
            // labelGraphics3D
            // 
            this.labelGraphics3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGraphics3D.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelGraphics3D.Location = new System.Drawing.Point(40, 0);
            this.labelGraphics3D.Margin = new System.Windows.Forms.Padding(0);
            this.labelGraphics3D.Name = "labelGraphics3D";
            this.labelGraphics3D.Size = new System.Drawing.Size(1068, 40);
            this.labelGraphics3D.TabIndex = 4;
            this.labelGraphics3D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPicture
            // 
            this.tabPicture.Controls.Add(this.tableLayoutPanelPicture);
            this.tabPicture.Location = new System.Drawing.Point(8, 8);
            this.tabPicture.Name = "tabPicture";
            this.tabPicture.Size = new System.Drawing.Size(1148, 421);
            this.tabPicture.TabIndex = 6;
            this.tabPicture.Text = "Pictures (*.jpg, *.png)";
            this.tabPicture.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelPicture
            // 
            this.tableLayoutPanelPicture.ColumnCount = 1;
            this.tableLayoutPanelPicture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPicture.Controls.Add(this.lblPictures, 0, 0);
            this.tableLayoutPanelPicture.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanelPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPicture.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPicture.Name = "tableLayoutPanelPicture";
            this.tableLayoutPanelPicture.RowCount = 2;
            this.tableLayoutPanelPicture.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelPicture.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPicture.Size = new System.Drawing.Size(1148, 421);
            this.tableLayoutPanelPicture.TabIndex = 0;
            // 
            // lblPictures
            // 
            this.lblPictures.AutoSize = true;
            this.lblPictures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPictures.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPictures.Location = new System.Drawing.Point(3, 0);
            this.lblPictures.Name = "lblPictures";
            this.lblPictures.Size = new System.Drawing.Size(1142, 50);
            this.lblPictures.TabIndex = 0;
            this.lblPictures.Text = "lblPictures";
            this.lblPictures.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1142, 365);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.richTextBox1);
            this.tabLog.Location = new System.Drawing.Point(8, 8);
            this.tabLog.Name = "tabLog";
            this.tabLog.Size = new System.Drawing.Size(1148, 421);
            this.tabLog.TabIndex = 7;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1148, 421);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // contextMenuStripPropertyGrid
            // 
            this.contextMenuStripPropertyGrid.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripPropertyGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collapseAllCarwgoriesToolStripMenuItem,
            this.collapseAllCatgoriesButThisToolStripMenuItem,
            this.expandAllCategoriesToolStripMenuItem});
            this.contextMenuStripPropertyGrid.Name = "contextMenuStripPropertyGrid";
            this.contextMenuStripPropertyGrid.Size = new System.Drawing.Size(426, 118);
            // 
            // collapseAllCarwgoriesToolStripMenuItem
            // 
            this.collapseAllCarwgoriesToolStripMenuItem.Name = "collapseAllCarwgoriesToolStripMenuItem";
            this.collapseAllCarwgoriesToolStripMenuItem.Size = new System.Drawing.Size(425, 38);
            this.collapseAllCarwgoriesToolStripMenuItem.Text = "Collapse All Categories";
            this.collapseAllCarwgoriesToolStripMenuItem.Click += new System.EventHandler(this.CollapseAllCategoriesToolStripMenuItemClick);
            // 
            // collapseAllCatgoriesButThisToolStripMenuItem
            // 
            this.collapseAllCatgoriesButThisToolStripMenuItem.Name = "collapseAllCatgoriesButThisToolStripMenuItem";
            this.collapseAllCatgoriesButThisToolStripMenuItem.Size = new System.Drawing.Size(425, 38);
            this.collapseAllCatgoriesButThisToolStripMenuItem.Text = "Collapse All Categories But This";
            this.collapseAllCatgoriesButThisToolStripMenuItem.Click += new System.EventHandler(this.CollapseAllCatgoriesButThisToolStripMenuItemClick);
            // 
            // expandAllCategoriesToolStripMenuItem
            // 
            this.expandAllCategoriesToolStripMenuItem.Name = "expandAllCategoriesToolStripMenuItem";
            this.expandAllCategoriesToolStripMenuItem.Size = new System.Drawing.Size(425, 38);
            this.expandAllCategoriesToolStripMenuItem.Text = "Expand All Categories";
            this.expandAllCategoriesToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllCategoriesToolStripMenuItemClick);
            // 
            // contextMenu3D
            // 
            this.contextMenu3D.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenu3D.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripMenuItem7});
            this.contextMenu3D.Name = "contextMenu3D";
            this.contextMenu3D.Size = new System.Drawing.Size(281, 80);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(280, 38);
            this.toolStripMenuItem6.Text = "wpf export to jpg";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.WpfExportToJpgToolStripMenuItemClick);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(280, 38);
            this.toolStripMenuItem7.Text = "wpf export to png";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.WpfExportToPngToolStripMenuItemClick);
            // 
            // Plot3DCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Plot3DCtrl";
            this.Size = new System.Drawing.Size(1164, 1052);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.toolStripTop.ResumeLayout(false);
            this.toolStripTop.PerformLayout();
            this.toolStripBottom.ResumeLayout(false);
            this.toolStripBottom.PerformLayout();
            this.tableLayoutPanelProject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProject)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tab3DGraphics.ResumeLayout(false);
            this.tableLayoutPanel3DGraph.ResumeLayout(false);
            this.tabPicture.ResumeLayout(false);
            this.tableLayoutPanelPicture.ResumeLayout(false);
            this.tableLayoutPanelPicture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabLog.ResumeLayout(false);
            this.contextMenuStripPropertyGrid.ResumeLayout(false);
            this.contextMenu3D.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label labelGraphics3D;
        private System.Windows.Forms.HScrollBar ScrollBarTheta;
        private System.Windows.Forms.VScrollBar ScrollBarRadius;
        private System.Windows.Forms.VScrollBar ScrollBarPhi;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3DGraph;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileItem2ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewProject;
        private System.Windows.Forms.ComboBox comboBoxFiles;
        private System.Windows.Forms.ComboBox comboBoxDirectories;
        private System.Windows.Forms.TabPage tab3DGraphics;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProject;
        private System.Windows.Forms.ToolStripButton toolStripButtonHideProjectPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorMain2;
        private System.Windows.Forms.ToolStripButton toolStripButtonRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorMain1;
        private System.Windows.Forms.ToolStripButton toolStripButtonFullBottomPanel;
        private System.Windows.Forms.ToolStripButton toolStripButton2_3BottomPanel;
        private System.Windows.Forms.ToolStripButton toolStripButton1_2BottomPanel;
        private System.Windows.Forms.ToolStripButton toolStripButton1_3BottomPanel;
        private System.Windows.Forms.ToolStripButton toolStripButtonHideBottomPanel;
        private System.Windows.Forms.ToolStrip toolStripBottom;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonFile;
        private System.Windows.Forms.ToolStrip toolStripTop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPropertyGrid;
        private System.Windows.Forms.ToolStripMenuItem collapseAllCarwgoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseAllCatgoriesButThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandAllCategoriesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu3D;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.TabPage tabPicture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPicture;
        private System.Windows.Forms.Label lblPictures;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonTools;
        private System.Windows.Forms.ToolStripMenuItem scriptEditorexternalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dViewerexternalToolStripMenuItem1;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.ToolStripMenuItem openAppdataLocalFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBinaryFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tinyDataViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel LabelWorkFile;
    }
}
