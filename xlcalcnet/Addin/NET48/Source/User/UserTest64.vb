Imports System.Text
Imports System.Reflection
Imports System.CodeDom.Compiler
Imports System.IO
Imports System.Threading
Imports System.Diagnostics
Imports System.Globalization

Module Program


    Function RunScriptFromFile(Language As String, FName As String, Proc As String) As Object
        Dim ProviderName As String, MainClass As String
        If Language = "VB" Then
            ProviderName = "VisualBasic"
            MainClass = "Program"
        ElseIf Language = "CS" Then
            ProviderName = "CSharp"
            MainClass = "EvaluateCS.Program"
        Else
            MsgBox("Unsupported Language")
            Return "Error"
        End If

        Dim provider As CodeDomProvider = CodeDomProvider.CreateProvider(ProviderName)
        Dim cp As CompilerParameters = New CompilerParameters

        Dim AddInPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        Dim stream_reader As New IO.StreamReader(FName)
        Dim Addline As String = ""
        Dim line As String = stream_reader.ReadLine()
        If line IsNot Nothing Then
            If line.Contains("REM Ref:") Then
                Dim Addlines = line.Split(CChar(":"))
                If Addlines.Length > 1 Then
                    Addline = Addlines(1)
                    Console.WriteLine("Addline: {0}", Addline)
                End If
            End If
        End If

        Try
            cp.ReferencedAssemblies.Add("System.dll")
            cp.ReferencedAssemblies.Add("System.Core.dll")
            cp.ReferencedAssemblies.Add("System.Data.dll")
            If Addline <> "" Then cp.ReferencedAssemblies.Add(AddInPath & "\" & Addline)

            cp.CompilerOptions = "/t:library -platform:x64"
            If Language = "VB" Then cp.CompilerOptions = cp.CompilerOptions & " -langversion:11 -optioninfer"
            If Language = "CS" Then cp.CompilerOptions = cp.CompilerOptions & " -langversion:5"



            cp.GenerateInMemory = True
            Dim cr As CompilerResults = provider.CompileAssemblyFromFile(cp, FName)

            If cr.Errors.Count > 0 Then
                Dim sbError As StringBuilder = New StringBuilder("")
                For i = 0 To cr.Errors.Count - 1
                    sbError.Append(vbCrLf & "Line " & cr.Errors(i).Line.ToString() & ":" & " Error " & cr.Errors(i).ErrorNumber & ": " & cr.Errors(i).ErrorText)
                Next
                Return sbError.ToString()
            End If

            Dim LocalAssembly As System.Reflection.Assembly = cr.CompiledAssembly
            Dim LocalInstance As Object = LocalAssembly.CreateInstance(MainClass)
            Dim LocalInstanceType As Type = LocalInstance.GetType()
            Dim mi As MethodInfo = LocalInstanceType.GetMethod(Proc)
            Dim Result As Object = Nothing
            For i = 1 To 1
                Result = mi.Invoke(LocalInstance, Nothing)
            Next i
            Return Result
        Catch ex As Exception
            MsgBox(ex.ToString())
            Return "Error"
        End Try
    End Function




    ' see also: https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.clone?view=netframework-4.0

    Sub Main()
        Console.WriteLine("Hello Compiler 6448!")
        Dim ci As New CultureInfo("en-US", False)
        ci.NumberFormat.NegativeInfinitySymbol = "-Inf"
        ci.NumberFormat.PositiveInfinitySymbol = "+Inf"
        Thread.CurrentThread.CurrentCulture = ci
        Thread.CurrentThread.CurrentUICulture = ci



        Dim Proc As String, Result As Object
        Dim Path As String = "C:\Users\dietrichhadler\Documents\Python310\Lib\site-packages\mpfebnet\Source\User"


        Dim result2 As String
        Dim originalConsoleOut = Console.Out
        Try
            Using writer As New StringWriter()
                Console.SetOut(writer)

                Dim FName As String = Path + "\UserEvaluateCSMain.cs"

                Console.WriteLine(FName)

                Proc = "test1"
                Result = RunScriptFromFile("CS", FName, Proc)
                Console.WriteLine("Result: {0}", Result)

                Proc = "test2"
                Result = RunScriptFromFile("CS", FName, Proc)
                Console.WriteLine("Result: {0}", Result)


                'Proc = "test3"
                'Result = RunScriptFromFile("CS", FName, Proc)
                'For i = 0 To 9
                '    Console.WriteLine("Result: {0}", Result(0, i))
                'Next

                writer.Flush()
                result2 = writer.GetStringBuilder().ToString()
            End Using
            '            Console.WriteLine( result2)
        Finally
            Console.SetOut(originalConsoleOut)
        End Try
        Console.WriteLine(result2)

        '        RunDirectVB()
        '        RunDirectCS()



        Console.Write("Press any key to continue . . . ")
        Console.ReadKey(True)
    End Sub













End Module
