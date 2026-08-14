' 
'  Created by SharpDevelop.
'  User: dietrichhadler
'  Date: 04.11.2021
'  Time: 09:49
'  
'  To change this template use Tools | Options | Coding | Edit Standard Headers.
' 
Namespace FlexDlgUserCtrl
    Partial Class SaveAsForm
        ''' <summary>
        ''' Designer variable used to keep track of non-visual components.
        ''' </summary>
        Private components As ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Disposes resources used by the form.
        ''' </summary>
        ''' <paramname="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        ''' <summary>
        ''' This method is required for Windows Forms designer support.
        ''' Do not change the method contents inside the source code editor. The Forms designer might
        ''' not be able to load this method if it was changed manually.
        ''' </summary>
        Private Sub InitializeComponent()
            tableLayoutPanelMain = New Windows.Forms.TableLayoutPanel()
            lblFileName = New Windows.Forms.Label()
            SaveAsTextBox = New Windows.Forms.TextBox()
            btnCancel = New Windows.Forms.Button()
            btnOK = New Windows.Forms.Button()
            tableLayoutPanelMain.SuspendLayout()
            SuspendLayout()
            ' 
            ' tableLayoutPanelMain
            ' 
            tableLayoutPanelMain.ColumnCount = 4
            tableLayoutPanelMain.ColumnStyles.Add(New Windows.Forms.ColumnStyle(Windows.Forms.SizeType.Absolute, 140F))
            tableLayoutPanelMain.ColumnStyles.Add(New Windows.Forms.ColumnStyle(Windows.Forms.SizeType.Percent, 100F))
            tableLayoutPanelMain.ColumnStyles.Add(New Windows.Forms.ColumnStyle(Windows.Forms.SizeType.Absolute, 150F))
            tableLayoutPanelMain.ColumnStyles.Add(New Windows.Forms.ColumnStyle(Windows.Forms.SizeType.Absolute, 150F))
            tableLayoutPanelMain.Controls.Add(lblFileName, 0, 1)
            tableLayoutPanelMain.Controls.Add(SaveAsTextBox, 1, 1)
            tableLayoutPanelMain.Controls.Add(btnCancel, 3, 3)
            tableLayoutPanelMain.Controls.Add(btnOK, 2, 3)
            tableLayoutPanelMain.Dock = Windows.Forms.DockStyle.Fill
            tableLayoutPanelMain.Location = New Drawing.Point(0, 0)
            tableLayoutPanelMain.Margin = New Windows.Forms.Padding(6)
            tableLayoutPanelMain.Name = "tableLayoutPanelMain"
            tableLayoutPanelMain.RowCount = 4
            tableLayoutPanelMain.RowStyles.Add(New Windows.Forms.RowStyle(Windows.Forms.SizeType.Absolute, 29F))
            tableLayoutPanelMain.RowStyles.Add(New Windows.Forms.RowStyle(Windows.Forms.SizeType.Absolute, 58F))
            tableLayoutPanelMain.RowStyles.Add(New Windows.Forms.RowStyle(Windows.Forms.SizeType.Percent, 100F))
            tableLayoutPanelMain.RowStyles.Add(New Windows.Forms.RowStyle(Windows.Forms.SizeType.Absolute, 58F))
            tableLayoutPanelMain.Size = New Drawing.Size(648, 175)
            tableLayoutPanelMain.TabIndex = 0
            ' 
            ' lblFileName
            ' 
            lblFileName.Anchor = Windows.Forms.AnchorStyles.Right
            lblFileName.AutoSize = True
            lblFileName.Font = New Drawing.Font("Microsoft Sans Serif", 9F)
            lblFileName.Location = New Drawing.Point(14, 43)
            lblFileName.Margin = New Windows.Forms.Padding(6, 0, 6, 0)
            lblFileName.Name = "lblFileName"
            lblFileName.Size = New Drawing.Size(120, 29)
            lblFileName.TabIndex = 0
            lblFileName.Text = "Filename:"
            ' 
            ' SaveAsTextBox
            ' 
            SaveAsTextBox.Anchor = Windows.Forms.AnchorStyles.Left Or Windows.Forms.AnchorStyles.Right
            tableLayoutPanelMain.SetColumnSpan(SaveAsTextBox, 3)
            SaveAsTextBox.Font = New Drawing.Font("Microsoft Sans Serif", 9F)
            SaveAsTextBox.Location = New Drawing.Point(146, 40)
            SaveAsTextBox.Margin = New Windows.Forms.Padding(6)
            SaveAsTextBox.Name = "SaveAsTextBox"
            SaveAsTextBox.Size = New Drawing.Size(496, 35)
            SaveAsTextBox.TabIndex = 1
            ' 
            ' btnCancel
            ' 
            btnCancel.BackColor = Drawing.SystemColors.Control
            btnCancel.DialogResult = Windows.Forms.DialogResult.Cancel
            btnCancel.Dock = Windows.Forms.DockStyle.Fill
            btnCancel.Font = New Drawing.Font("Microsoft Sans Serif", 9F)
            btnCancel.Location = New Drawing.Point(504, 123)
            btnCancel.Margin = New Windows.Forms.Padding(6)
            btnCancel.Name = "btnCancel"
            btnCancel.Size = New Drawing.Size(138, 46)
            btnCancel.TabIndex = 2
            btnCancel.Text = "Cancel"
            btnCancel.UseVisualStyleBackColor = False
            ' 
            ' btnOK
            ' 
            btnOK.BackColor = Drawing.SystemColors.Control
            btnOK.DialogResult = Windows.Forms.DialogResult.OK
            btnOK.Dock = Windows.Forms.DockStyle.Fill
            btnOK.Font = New Drawing.Font("Microsoft Sans Serif", 9F)
            btnOK.Location = New Drawing.Point(354, 123)
            btnOK.Margin = New Windows.Forms.Padding(6)
            btnOK.Name = "btnOK"
            btnOK.Size = New Drawing.Size(138, 46)
            btnOK.TabIndex = 3
            btnOK.Text = "OK"
            btnOK.UseVisualStyleBackColor = False
            ' 
            ' SaveAsForm
            ' 
            AcceptButton = btnOK
            AutoScaleDimensions = New Drawing.SizeF(12F, 25F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New Drawing.Size(648, 175)
            ControlBox = False
            Controls.Add(tableLayoutPanelMain)
            Margin = New Windows.Forms.Padding(6)
            Name = "SaveAsForm"
            ShowIcon = False
            ShowInTaskbar = False
            StartPosition = Windows.Forms.FormStartPosition.Manual
            Text = "Save As..."
            tableLayoutPanelMain.ResumeLayout(False)
            tableLayoutPanelMain.PerformLayout()
            ResumeLayout(False)

        End Sub
        Private btnOK As Windows.Forms.Button
        Private btnCancel As Windows.Forms.Button
        Private SaveAsTextBox As Windows.Forms.TextBox
        Private lblFileName As Windows.Forms.Label
        Private tableLayoutPanelMain As Windows.Forms.TableLayoutPanel
    End Class
End Namespace
