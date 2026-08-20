using System;
using System.Diagnostics;

namespace MpFunLabAddin64
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class NavigatorDlg : System.Windows.Forms.Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lbLibrary = new System.Windows.Forms.ListBox();
            this.lbProc = new System.Windows.Forms.ListBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel2, 0, 3);
            this.TableLayoutPanel1.Controls.Add(this.RichTextBox1, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.lbLibrary, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.lbProc, 1, 1);
            this.TableLayoutPanel1.Controls.Add(this.Label1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label2, 1, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.TableLayoutPanel1.RowCount = 4;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(889, 601);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 4;
            this.TableLayoutPanel1.SetColumnSpan(this.TableLayoutPanel2, 2);
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.TableLayoutPanel2.Controls.Add(this.btnCancel, 3, 0);
            this.TableLayoutPanel2.Controls.Add(this.btnOK, 2, 0);
            this.TableLayoutPanel2.Controls.Add(this.button1, 0, 0);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(6, 541);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 1;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(877, 54);
            this.TableLayoutPanel2.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(723, 3);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 48);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Location = new System.Drawing.Point(560, 3);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(151, 48);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start socket server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RichTextBox1
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.RichTextBox1, 2);
            this.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox1.Location = new System.Drawing.Point(9, 419);
            this.RichTextBox1.Margin = new System.Windows.Forms.Padding(6);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.ReadOnly = true;
            this.RichTextBox1.Size = new System.Drawing.Size(871, 113);
            this.RichTextBox1.TabIndex = 1;
            this.RichTextBox1.Text = "Description of selected procedure";
            // 
            // lbLibrary
            // 
            this.lbLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLibrary.FormattingEnabled = true;
            this.lbLibrary.IntegralHeight = false;
            this.lbLibrary.ItemHeight = 29;
            this.lbLibrary.Location = new System.Drawing.Point(9, 59);
            this.lbLibrary.Margin = new System.Windows.Forms.Padding(6);
            this.lbLibrary.Name = "lbLibrary";
            this.lbLibrary.Size = new System.Drawing.Size(429, 348);
            this.lbLibrary.TabIndex = 2;
            this.lbLibrary.SelectedIndexChanged += new System.EventHandler(this.lbLibrary_SelectedIndexChanged);
            // 
            // lbProc
            // 
            this.lbProc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbProc.FormattingEnabled = true;
            this.lbProc.IntegralHeight = false;
            this.lbProc.ItemHeight = 29;
            this.lbProc.Location = new System.Drawing.Point(450, 59);
            this.lbProc.Margin = new System.Windows.Forms.Padding(6);
            this.lbProc.Name = "lbProc";
            this.lbProc.Size = new System.Drawing.Size(430, 348);
            this.lbProc.TabIndex = 3;
            this.lbProc.SelectedIndexChanged += new System.EventHandler(this.lbProc_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Label1.Location = new System.Drawing.Point(6, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(435, 29);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Library";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Label2.Location = new System.Drawing.Point(447, 24);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(436, 29);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Procedure";
            // 
            // NavigatorDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 613);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NavigatorDlg";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Navigator for XlCalcNet";
            this.TopMost = true;
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.TableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.RichTextBox RichTextBox1;
        internal System.Windows.Forms.ListBox lbLibrary;
        internal System.Windows.Forms.ListBox lbProc;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button1;
    }
}