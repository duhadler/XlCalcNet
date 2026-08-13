/*
 * Created by SharpDevelop.
 * User: dietrichhadler
 * Date: 21.04.2023
 * Time: 12:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace FlexDlgUserCtrl
{
    partial class OptionsForm
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
            this.tableLayoutPanelOptionsMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelOptionsButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOptionsCancel = new System.Windows.Forms.Button();
            this.btnOptionsOK = new System.Windows.Forms.Button();
            this.propertyGridOptions = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanelOptionsMain.SuspendLayout();
            this.tableLayoutPanelOptionsButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelOptionsMain
            // 
            this.tableLayoutPanelOptionsMain.ColumnCount = 1;
            this.tableLayoutPanelOptionsMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOptionsMain.Controls.Add(this.tableLayoutPanelOptionsButtons, 0, 1);
            this.tableLayoutPanelOptionsMain.Controls.Add(this.propertyGridOptions, 0, 0);
            this.tableLayoutPanelOptionsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOptionsMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelOptionsMain.Name = "tableLayoutPanelOptionsMain";
            this.tableLayoutPanelOptionsMain.RowCount = 2;
            this.tableLayoutPanelOptionsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOptionsMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanelOptionsMain.Size = new System.Drawing.Size(840, 673);
            this.tableLayoutPanelOptionsMain.TabIndex = 0;
            // 
            // tableLayoutPanelOptionsButtons
            // 
            this.tableLayoutPanelOptionsButtons.ColumnCount = 5;
            this.tableLayoutPanelOptionsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanelOptionsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOptionsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelOptionsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelOptionsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanelOptionsButtons.Controls.Add(this.btnOptionsCancel, 4, 0);
            this.tableLayoutPanelOptionsButtons.Controls.Add(this.btnOptionsOK, 3, 0);
            this.tableLayoutPanelOptionsButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelOptionsButtons.Location = new System.Drawing.Point(3, 618);
            this.tableLayoutPanelOptionsButtons.Name = "tableLayoutPanelOptionsButtons";
            this.tableLayoutPanelOptionsButtons.RowCount = 1;
            this.tableLayoutPanelOptionsButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelOptionsButtons.Size = new System.Drawing.Size(834, 52);
            this.tableLayoutPanelOptionsButtons.TabIndex = 0;
            // 
            // btnOptionsCancel
            // 
            this.btnOptionsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOptionsCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOptionsCancel.Location = new System.Drawing.Point(669, 3);
            this.btnOptionsCancel.Name = "btnOptionsCancel";
            this.btnOptionsCancel.Size = new System.Drawing.Size(162, 46);
            this.btnOptionsCancel.TabIndex = 1;
            this.btnOptionsCancel.Text = "Cancel";
            this.btnOptionsCancel.UseVisualStyleBackColor = true;
            // 
            // btnOptionsOK
            // 
            this.btnOptionsOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOptionsOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOptionsOK.Location = new System.Drawing.Point(519, 3);
            this.btnOptionsOK.Name = "btnOptionsOK";
            this.btnOptionsOK.Size = new System.Drawing.Size(144, 46);
            this.btnOptionsOK.TabIndex = 4;
            this.btnOptionsOK.Text = "OK";
            this.btnOptionsOK.UseVisualStyleBackColor = true;
            this.btnOptionsOK.Click += new System.EventHandler(this.BtnOptionsOKClick);
            // 
            // propertyGridOptions
            // 
            this.propertyGridOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridOptions.Location = new System.Drawing.Point(3, 3);
            this.propertyGridOptions.Name = "propertyGridOptions";
            this.propertyGridOptions.Size = new System.Drawing.Size(834, 609);
            this.propertyGridOptions.TabIndex = 1;
            this.propertyGridOptions.ToolbarVisible = false;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnOptionsOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOptionsCancel;
            this.ClientSize = new System.Drawing.Size(840, 673);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelOptionsMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Options";
            this.tableLayoutPanelOptionsMain.ResumeLayout(false);
            this.tableLayoutPanelOptionsButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Button btnOptionsOK;
        private System.Windows.Forms.PropertyGrid propertyGridOptions;
        private System.Windows.Forms.Button btnOptionsCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOptionsButtons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOptionsMain;
    }
}
