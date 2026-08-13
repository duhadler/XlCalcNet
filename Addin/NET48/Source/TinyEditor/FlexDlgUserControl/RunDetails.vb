
Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Windows.Forms

Namespace FlexDlgUserCtrl
    Public Partial Class FlexDlgUserControl1
        Inherits UserControl


        Public Function GetDataPath() As String
            Dim res = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            res = res & "\DataMpFebNet"
            Return res
        End Function


        Public Function GetBinPath() As String
            Dim BinPath As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            'MessageBox.Show(BinPath);
            Return BinPath
        End Function

        Public Function GetCPythonPath() As String
            Dim BinPath As String = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            'MessageBox.Show(BinPath);
            Dim found = False
            While Not found
                Try
                    BinPath = Directory.GetParent(BinPath).FullName
                    Dim Temp = BinPath & "\python.exe"
                    'MessageBox.Show(Temp);
                    If File.Exists(Temp) Then found = True
                Catch __unusedException1__ As Exception
                    found = True
                    BinPath = ""
                    MessageBox.Show("Could not find path to python.exe")
                End Try
            End While
            'MessageBox.Show(BinPath);
            Return BinPath
        End Function

        Private Function RunCompiler() As Integer
            Dim ScriptName = Path.GetFileNameWithoutExtension(Me.ActiveFileName)
            Dim FWDir = Environment.GetEnvironmentVariable("SystemRoot") & "\Microsoft.NET\Framework64\v4.0.30319\"
            Dim CompilerPath = FWDir
            Dim SpecArg = "  /Debug:full /utf8output /noconfig /nologo /platform:x64 "

            If Me.ActiveFileName.EndsWith(".vb") Then
                SpecArg += "  /optioninfer  /rootnamespace:" & ScriptName & " /main:" & ScriptName & ".MainModule "
                CompilerPath += "vbc.exe"
            Else
                SpecArg += " /preferreduilang:en-us "
                CompilerPath += "csc.exe"
            End If

            Dim MyArg = SpecArg

            Dim FWarray = {"mscorlib.dll", "System.dll", "System.Core.dll", "System.Numerics.dll", "Microsoft.CSharp.dll", "Microsoft.VisualBasic.dll"}

            Dim Rootarray = {"FixedPrecNet.dll", "ArbPrecNet.dll", "UserPrecNet.dll"}

            Dim MyArg1 = ""
            For Each s In FWarray
                MyArg1 += " /reference:" & """" & FWDir & s & """"
            Next

            Dim RootDir As String = GetBinPath() & "\"
            Dim MyArg2 = ""
            For Each s In Rootarray
                MyArg2 += " /reference:" & """" & RootDir & s & """"
            Next
            MyArg += MyArg1 & MyArg2
            MyArg += " /out:" & """" & GetBinPath() & "\mpTempPrecNet.exe" & """"
            MyArg += " /target:exe " & """" & Me.ActiveFileName & """"

            Me.richTextBoxLog.Clear()
            Me.richTextBoxLog.AppendText(Date.Now.ToString("F") & Environment.NewLine)
            Me.richTextBoxLog.AppendText("Compiler: " & CompilerPath & Environment.NewLine)
            Me.richTextBoxLog.AppendText("Compiler arguments: " & MyArg & Environment.NewLine)
            Me.richTextBoxLog.AppendText(Environment.NewLine)

            Dim process As Process = New Process()
            process.StartInfo.StandardOutputEncoding = Encoding.UTF8
            process.StartInfo.FileName = CompilerPath
            process.StartInfo.Arguments = MyArg
            process.StartInfo.UseShellExecute = False
            process.StartInfo.CreateNoWindow = True
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            process.StartInfo.RedirectStandardOutput = True
            Dim eOut As String = Nothing
            process.StartInfo.RedirectStandardError = True
            AddHandler process.ErrorDataReceived, New DataReceivedEventHandler(Sub(sender, e) eOut += e.Data)


            'process.Start();
            'process.BeginErrorReadLine();
            'string output = process.StandardOutput.ReadToEnd();
            'process.WaitForExit();


            'if (eOut.Length > 0) richTextBoxLog.AppendText("error: " + eOut + Environment.NewLine);
            'richTextBoxLog.AppendText(output);


            Dim stopWatch = New Stopwatch()
            stopWatch.Start()

            process.Start()
            process.BeginErrorReadLine()
            Dim output As String = process.StandardOutput.ReadToEnd()
            process.WaitForExit()

            stopWatch.Stop()
            Dim ts = stopWatch.Elapsed
            Dim elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10R)
            Me.richTextBoxLog.AppendText("Compiler finished in " & elapsedTime & Environment.NewLine)


            If eOut.Length > 0 Then
                Me.richTextBoxLog.AppendText("compiler error: " & eOut & Environment.NewLine)
            End If

            If output.Length > 0 Then
                Me.richTextBoxLog.AppendText("The following problems were encountered: " & Environment.NewLine & Environment.NewLine)
                Me.richTextBoxLog.AppendText(output)
            Else
                Me.richTextBoxLog.AppendText(Environment.NewLine & "The file mpTempPrecNet.exe has been written to the Binary Output Folder" & Environment.NewLine)
            End If



            Return output.Length
        End Function



        Private Sub StartAppNoWaitForExit(FName As String, Args As String, UseUtf8 As Boolean)
            'if (GlobalStopWatch.IsRunning)
            '{
            Me.GlobalStopWatch.Stop()
            Me.GlobalStopWatch.Reset()
            '}
            Me.richTextBoxLog.AppendText(Environment.NewLine & "Program execution has started ..." & Environment.NewLine)
            Me.GlobalStopWatch.Start()

            Dim process As Process = New Process()
            process.StartInfo.FileName = FName
            process.StartInfo.Arguments = Args
            process.StartInfo.CreateNoWindow = True
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            'process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start()
        End Sub


        Private Function RunDLLCompiler() As Integer
            Dim ScriptDir = Path.GetDirectoryName(Me.ActiveFileName)
            Dim PrecNetDLLStr = "PrecNetDLL"
            Dim p = ScriptDir.IndexOf(PrecNetDLLStr)
            Dim DirectorytoSearch = ScriptDir.Substring(0, p + PrecNetDLLStr.Length) & "\"

            Dim RootDir As String = GetBinPath() & "\"
            Dim FWDir = Environment.GetEnvironmentVariable("SystemRoot") & "\Microsoft.NET\Framework64\v4.0.30319\"
            Dim CompilerPath = FWDir
            Dim SpecArg = "  /Debug:full /utf8output /noconfig /nologo /platform:x64 "
            Dim NameSpGen = "User"
            Dim NameSpExt = ""
            Dim OutputName = ""

            If ScriptDir.Contains("UserPrecNetDLL") Then OutputName = "UserPrecNet"
            If ScriptDir.Contains("FixedPrecNetDLL") Then OutputName = "FixedPrecNet"
            If ScriptDir.Contains("ArbPrecNetDLL") Then OutputName = "ArbPrecNet"


            NameSpExt += "CS"
            CompilerPath += "csc.exe"
            SpecArg += " /preferreduilang:en-us "

            Dim NameSp = NameSpGen & NameSpExt
            SpecArg += " /doc:" & RootDir & OutputName & ".xml"

            'SpecArg += " /nowarn:0660,0661,1589,1591 ";

            'warning CS1589: Unable to include XML fragment -- The system cannot find the file specified. 
            'warning CS1591: Missing XML comment for publicly visible type or member

            SpecArg += " /nowarn:0660,0661,1591 "

            Dim FWarray = {"mscorlib.dll", "System.dll", "System.Core.dll", "System.Numerics.dll", "Microsoft.CSharp.dll", "Microsoft.VisualBasic.dll"}
            For Each s In FWarray
                SpecArg += " /reference:" & """" & FWDir & s & """"
            Next

            If Equals(OutputName, "UserPrecNet") Then
                Dim Rootarray = {"FixedPrecNet.dll", "ArbPrecNet.dll"}
                For Each s In Rootarray
                    SpecArg += " /reference:" & """" & RootDir & s & """"
                Next
            End If

            SpecArg += " /target:library "
            SpecArg += " " & " /out:" & """" & RootDir & OutputName & ".dll" & """"
            SpecArg += "  /recurse:*." & NameSpExt.ToLower() & " "

            Me.richTextBoxLog.Clear()
            Me.richTextBoxLog.AppendText(Date.Now.ToString("F") & Environment.NewLine)
            Me.richTextBoxLog.AppendText(CompilerPath & Environment.NewLine)
            Me.richTextBoxLog.AppendText(SpecArg & Environment.NewLine)
            Me.richTextBoxLog.AppendText(Environment.NewLine)
            Me.richTextBoxLog.AppendText("Compiler has started..." & Environment.NewLine)
            Me.richTextBoxLog.Update()


            Dim process As Process = New Process()
            process.StartInfo.WorkingDirectory = DirectorytoSearch
            process.StartInfo.StandardOutputEncoding = Encoding.UTF8
            process.StartInfo.FileName = CompilerPath
            process.StartInfo.Arguments = SpecArg
            process.StartInfo.UseShellExecute = False
            process.StartInfo.CreateNoWindow = True
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            process.StartInfo.RedirectStandardOutput = True
            Dim eOut As String = Nothing
            process.StartInfo.RedirectStandardError = True
            AddHandler process.ErrorDataReceived, New DataReceivedEventHandler(Sub(sender, e) eOut += e.Data)

            Dim stopWatch = New Stopwatch()
            stopWatch.Start()

            process.Start()
            process.BeginErrorReadLine()
            Dim output As String = process.StandardOutput.ReadToEnd()
            process.WaitForExit(5000)

            stopWatch.Stop()
            Dim ts = stopWatch.Elapsed
            Dim elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10R)
            Me.richTextBoxLog.AppendText("Compiler finished in " & elapsedTime & Environment.NewLine)


            If eOut.Length > 0 Then
                Me.richTextBoxLog.AppendText("compiler error: " & eOut & Environment.NewLine)
            End If

            If output.Length > 0 Then
                Me.richTextBoxLog.AppendText("The following problems were encountered: " & Environment.NewLine & Environment.NewLine)
                Me.richTextBoxLog.AppendText(output)
            Else
                Me.richTextBoxLog.AppendText(Environment.NewLine & "The files " & OutputName & ".dll and " & OutputName & ".xml have been written to the Binary Output Folder" & Environment.NewLine)
            End If


            Return output.Length
        End Function



        Private Sub RunScript()
            Dim s As String = Me.ActiveFileName

            If Path.GetDirectoryName(CStr(Me.ActiveFileName)).Contains("PrecNetDLL") Then
                Me.ClearAllAnnotations()
                Me.SaveScript()

                Dim result As Integer = RunDLLCompiler()
                If result = 0 Then
                Else
                    If Me.richTextBoxLog.TextLength < 10000 Then
                        Me.richTextBoxLog.WordWrap = False
                        Dim searchstring1 = "warning"
                        Me.Find2(Me.richTextBoxLog, searchstring1, Color.DarkOrange)
                        Dim searchstring = "error"
                        Me.Find2(Me.richTextBoxLog, searchstring, Color.DarkRed)
                    End If
                    Me.tabControl1.SelectedTab = Me.tabLog
                End If


            ElseIf Me.ActiveFileName.EndsWith(".cs") Then
                Me.ClearAllAnnotations()
                Me.SaveScript()
                Me.tabControl1.SelectedTab = Me.tabLog

                Dim result As Integer = RunCompiler()



                If result = 0 Then

                    Dim VBExecutableName As String = GetBinPath() & "\mpTempPrecNet.exe"
                    Dim sb As StringBuilder = New StringBuilder(10000)
                    sb.Append("""" & VBExecutableName & """")
                    sb.Append(" """ & Me.ActiveFileName & """")
                    sb.Append(" 1> " & " """ & Me.ActiveFileName & ".data""")
                    sb.AppendLine(" 2> " & " """ & Me.ActiveFileName & ".Err.txt""")
                    Call File.WriteAllText(Me.ActiveFileName & ".Run.bat", sb.ToString())
                    'richTextBoxLog.Clear();
                    Dim Args As String = """" & Me.ActiveFileName & """ BatchVBCS "
                    Dim FName As String = """" & GetBinPath() & "\RunBatch.exe" & """"
                    StartAppNoWaitForExit(FName, Args, False)
                Else
                    Me.richTextBoxLog.WordWrap = False
                    Dim searchstring1 = "warning"
                    Me.Find2(Me.richTextBoxLog, searchstring1, Color.DarkOrange)
                    Dim searchstring = "error"
                    Me.Find2(Me.richTextBoxLog, searchstring, Color.DarkRed)
                    Me.tabControl1.SelectedTab = Me.tabLog
                End If


            ElseIf Me.ActiveFileName.EndsWith(".py") Then
                Me.ClearAllAnnotations()
                Me.SaveScript()
                Dim MainPath As String = GetCPythonPath()
                If Equals(MainPath, "") Then Return

                Dim CPythonExecutableName = MainPath & "\python.exe"
                Dim sb As StringBuilder = New StringBuilder(10000)
                sb.Append("""" & CPythonExecutableName & """" & " ")
                sb.Append("""" & Me.ActiveFileName & """" & " ")
                sb.Append(" 1> " & """" & Me.ActiveFileName & ".data" & """")
                sb.AppendLine(" 2> " & """" & Me.ActiveFileName & ".Err.txt" & """")
                Call File.WriteAllText(Me.ActiveFileName & ".Run.bat", sb.ToString())

                Me.richTextBoxLog.Clear()
                Me.richTextBoxLog.WordWrap = False
                Dim Args As String = """" & Me.ActiveFileName & """ BatchVBCS "
                Dim FName As String = """" & GetBinPath() & "\RunBatch.exe" & """"
                Me.richTextBoxLog.AppendText(Date.Now.ToString("F") & Environment.NewLine)

                Me.richTextBoxLog.AppendText("Python interpeter: " & MainPath & Environment.NewLine)
                Me.tabControl1.SelectedTab = Me.tabLog
                StartAppNoWaitForExit(FName, Args, False)
            End If





        End Sub


    End Class


End Namespace
