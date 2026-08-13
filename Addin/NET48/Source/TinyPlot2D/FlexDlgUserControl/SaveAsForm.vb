Imports System
Imports System.Windows.Forms

Namespace FlexDlgUserCtrl
    Public Partial Class SaveAsForm
        Inherits Form

        Public Property FileName As String
            Get
                Return SaveAsTextBox.Text
            End Get

            Set(value As String)
                SaveAsTextBox.Text = value
            End Set
        End Property


        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs)
            Close()
        End Sub

        Private Sub btnOK_Click(sender As Object, e As EventArgs)
            Close()
        End Sub
    End Class
End Namespace
