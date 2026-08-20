using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using ExcelDna.Integration;
using ExcelDna.Integration.CustomUI;
using Microsoft.VisualBasic;
using MpFunLabClient;

namespace MpFunLabAddin64
{


    public static class MpFunctions
    {


        private static MpFunLabSocketClientClass scc = null;

        [ComVisible(false)]
        public class MyAddIn : IExcelAddIn
        {

            public void AutoOpen()
            {
                const string ContextPopups = Constants.vbCr + Constants.vbLf 
                    + "    <commandBars xmlns='http://schemas.excel-dna.net/office/2003/01/commandbars' >" + Constants.vbCr + Constants.vbLf 
                    + "        <commandBar name='Cell'>"  + Constants.vbCr + Constants.vbLf 
                    + "        <button before='1' caption='Navigator for XlCalcNet...' enabled='true' onAction='StartNavigator'  />" + Constants.vbCr + Constants.vbLf 
                    + "        </commandBar>" + Constants.vbCr + Constants.vbLf 
                    + "    </commandBars>";
                ExcelCommandBarUtil.LoadCommandBars(ContextPopups, null);
                System.Windows.Forms.Application.EnableVisualStyles();
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                scc = new MpFunLabSocketClientClass();

            }

            public void AutoClose()
            {
            }

        }




        [ComVisible(true)]
        public static void StartNavigator()
        {
            // MsgBox("In StartNavigator") 
            ((dynamic)ExcelDnaUtil.Application).Run("MpFunLabLocal.xlam!ShowNavigator");
        }



        private const string PythonCodeDesc = "specifies the Python code, using $n for newline and $t for indentation.";
        private const string PD1 = " parameter, referred to as P";
        private const string PD2 = " in the Python code.";

        private const string P1Desc = "the first" + PD1 + "1" + PD2;

        // Const FunctionNameDesc = "specifies the function name (which is case sensitive)."
        // Const Parameter1Desc = "the first" + PD1 + "1" + PD2
        // Const Parameter2Desc = "the second" + PD1 + "2" + PD2
        // Const Parameter3Desc = "the third" + PD1 + "3" + PD2
        // Const Parameter4Desc = "the fourth" + PD1 + "4" + PD2
        // Const Parameter5Desc = "the fifth" + PD1 + "5" + PD2
        // Const Parameter6Desc = "the sixth" + PD1 + "6" + PD2
        // Const Parameter7Desc = "the seventh" + PD1 + "7" + PD2
        // Const Parameter8Desc = "the eigth" + PD1 + "8" + PD2
        // Const Parameter9Desc = "the ninth" + PD1 + "9" + PD2
        private const string TransposeDesc = "Optional: If set to a non-zero value, the output will be transposed";
        private const string ShowShapeDesc = "Optional: If set to a non-zero value, the shape will be indicated in the output";

        private const string HelpRef = "https://duhadler.github.io/XlCalcNetDocsOnline/B01_GeneralUsage/C01_Setup.html#installing-and-using-the-tiny-ide-as-a-python-application";


        private const string P2Desc = "the second" + PD1 + "2";
        private const string P3Desc = "the third" + PD1 + "3";
        private const string P4Desc = "the fourth" + PD1 + "4";
        private const string P5Desc = "the fifth" + PD1 + "5";
        private const string P6Desc = "the sixth" + PD1 + "6";
        private const string P7Desc = "the seventh" + PD1 + "7";
        private const string P8Desc = "the eigth" + PD1 + "8";
        private const string P9Desc = "the ninth" + PD1 + "9";




        private static string MakeParam(dynamic P)
        {
            string PStr = "";
            if (P is Array)
            {
                dynamic[,] oTable = (dynamic[,])P;
                int NoOfRows, NoOfCols;
                NoOfRows = oTable.GetUpperBound(0);
                NoOfCols = oTable.GetUpperBound(1);
                var RowsJoined = new string[NoOfRows + 1 + 1];
                RowsJoined[0] = "||" + "$list$";
                for (int i = 0, loopTo = NoOfRows - 0; i <= loopTo; i++)
                {
                    var ColsJoined = new string[NoOfCols + 1];
                    for (int j = 0, loopTo1 = NoOfCols - 0; j <= loopTo1; j++)
                    {
                        if (oTable[i, j] is double)
                        {
                            ColsJoined[j] = "$float$" + oTable[i, j].ToString();
                        }
                        else if (oTable[i, j] is bool)
                        {
                            ColsJoined[j] = "$bool$" + oTable[i, j].ToString();
                        }
                        else
                        {
                            ColsJoined[j] = oTable[i, j].ToString();
                        }
                    }
                    RowsJoined[i + 1] = Strings.Join(ColsJoined, "§_§");
                }
                PStr = Strings.Join(RowsJoined, "§__§");
            }
            else if (P is double)
            {
                PStr = "||" + "$float$" + P.ToString();
            }
            else if (P is bool)
            {
                PStr = "||" + "$bool$" + P.ToString();
            }
            return PStr;
        }



        private static dynamic GetTypedData(string Result2)
        {
            dynamic ResultFinal;
            if (Result2.StartsWith("$float$"))
            {
                string ResultTemp = Result2.Substring(7);
                ResultFinal = double.Parse(ResultTemp);
            }
            else if (Result2.StartsWith("$bool$"))
            {
                string ResultTemp = Result2.Substring(6);
                ResultFinal = bool.Parse(ResultTemp);
            }
            else if (Result2.StartsWith("$datetime$"))
            {
                string ResultTemp = Result2.Substring(10);
                ResultFinal = double.Parse(ResultTemp);
            }
            else
            {
                ResultFinal = Result2;
            }
            return ResultFinal;
        }

        private static dynamic CallSocketServer0OLD(string Code2, bool Transpose, bool ShowShape)
        {
            var scc = new MpFunLabSocketClientClass();
            string Result = scc.CallSocketServer(Code2);
            // MsgBox(Code2)
            if (Result.StartsWith("$list$"))
            {
                dynamic[,] oTable;
                string[] ResArray = Strings.Split(Result, "§__§");
                int NoOfRows = ResArray.Length;
                string Row = ResArray[1];
                string[] RowArray = Strings.Split(Row, "§_§");
                int NoOfCols = RowArray.Length;
                if (Transpose)
                {
                    oTable = new dynamic[NoOfCols, NoOfRows - 2 + 1];
                }
                else
                {
                    oTable = new dynamic[NoOfRows - 2 + 1, NoOfCols];
                }
                for (int i = 0, loopTo = NoOfRows - 2; i <= loopTo; i++)
                {
                    Row = ResArray[i + 1];
                    RowArray = Strings.Split(Row, "§_§");
                    for (int j = 0, loopTo1 = RowArray.Length - 1; j <= loopTo1; j++)
                    {
                        string Val = RowArray[j];
                        if (Transpose)
                        {
                            oTable[j, i] = GetTypedData(Val);
                        }
                        else
                        {
                            oTable[i, j] = GetTypedData(Val);
                        }
                    }
                }
                if (ShowShape)
                {
                    string RxC;
                    if (Transpose)
                    {
                        RxC = "R" + NoOfCols.ToString().Trim() + "xC" + (NoOfRows - 1).ToString().Trim() + "| ";
                    }
                    else
                    {
                        RxC = "R" + (NoOfRows - 1).ToString().Trim() + "xC" + NoOfCols.ToString().Trim() + "| ";
                    }
                    oTable[0, 0] = RxC + oTable[0, 0].ToString();
                }
                return oTable;
            }
            else
            {
                return GetTypedData(Result);
            }
        }








        private static dynamic CallSocketServer0(string Code, bool Transpose, bool ShowShape)
        {
            int TotalBytesThreshold = 1000;
            var scc = new MpFunLabSocketClientClass();
            var utf8WithoutBOM = new UTF8Encoding(false);
            string ResultStr;
            Console.WriteLine("Code1.Length(): {0}", Code.Length);
            int TotalBytes = Encoding.UTF8.GetBytes(Code).Length;
            Console.WriteLine("Code2.Length(): {0}", TotalBytes);
            if (TotalBytes > TotalBytesThreshold)
            {
                Console.WriteLine("C#: write to file");
                string MyPath = @"C:\Temp\FileTempIn.txt";
                File.WriteAllText(MyPath, Code, utf8WithoutBOM);
                string Code2 = "$file:$" + MyPath;
                ResultStr = scc.CallSocketServer(Code2);
            }
            else
            {
                Console.WriteLine("C#: no write to file");
                ResultStr = scc.CallSocketServer(Code);
            }



            if (ResultStr.StartsWith("$file:$"))
            {
                Console.WriteLine("C#: read from file");
                string ResultPath = @"C:\Temp\FileTempOut.txt";
                ResultStr = File.ReadAllText(ResultPath, utf8WithoutBOM);
                Console.WriteLine("ResultStr: {0}", ResultStr);
            }
            else
            {
                Console.WriteLine("C#: no read from file");
            }


            if (ResultStr.StartsWith("$list$"))
            {
                dynamic[,] oTable;
                string[] ResArray = Strings.Split(ResultStr, "§__§");
                //string[] ResArray = string.Split(ResultStr, "§__§");
                int NoOfRows = ResArray.Length;
                string Row = ResArray[1];
                string[] RowArray = Strings.Split(Row, "§_§");
                int NoOfCols = RowArray.Length;
                if (Transpose)
                {
                    oTable = new dynamic[NoOfCols, NoOfRows - 2 + 1];
                }
                else
                {
                    oTable = new dynamic[NoOfRows - 2 + 1, NoOfCols];
                }
                for (int i = 0, loopTo = NoOfRows - 2; i <= loopTo; i++)
                {
                    Row = ResArray[i + 1];
                    RowArray = Strings.Split(Row, "§_§");
                    for (int j = 0, loopTo1 = RowArray.Length - 1; j <= loopTo1; j++)
                    {
                        string Val = RowArray[j];
                        if (Transpose)
                        {
                            oTable[j, i] = GetTypedData(Val);
                        }
                        else
                        {
                            oTable[i, j] = GetTypedData(Val);
                        }
                    }
                }
                if (ShowShape)
                {
                    string RxC;
                    if (Transpose)
                    {
                        RxC = "R" + NoOfCols.ToString().Trim() + "xC" + (NoOfRows - 1).ToString().Trim() + "| ";
                    }
                    else
                    {
                        RxC = "R" + (NoOfRows - 1).ToString().Trim() + "xC" + NoOfCols.ToString().Trim() + "| ";
                    }
                    oTable[0, 0] = RxC + oTable[0, 0].ToString();
                }
                return oTable;
            }
            else
            {
                return GetTypedData(ResultStr);
            }
        }









        [ExcelFunction(Description = "Converts the string representation of a multiple-precision number into a double", HelpTopic = HelpRef)]
        public static dynamic ASDOUBLE([ExcelArgument(Description = PythonCodeDesc)] string MpString)
        {
            string Result;
            Result = scc.CallSocketServer("result = float(" + MpString + ")");
            return Result;
        }




        [ExcelFunction(Description = "CPython code without parameters.", HelpTopic = HelpRef)]
        public static dynamic CPY_0([ExcelArgument(Description = PythonCodeDesc)] string PythonCode, [ExcelArgument(Description = TransposeDesc)] double Transposed = 0.0d, [ExcelArgument(Description = ShowShapeDesc)] double ShowShape = 0.0d)
        {
            dynamic Result;
            Result = CallSocketServer0("result = 1;" + PythonCode, Transposed != 0.0d, ShowShape != 0.0d);
            return Result;
        }





        [ExcelFunction(Description = "CPython code with 1 parameter.", HelpTopic = HelpRef)]
        public static dynamic CPY_1([ExcelArgument(Description = PythonCodeDesc)] string PythonCode, [ExcelArgument(Description = P1Desc)] dynamic P1, [ExcelArgument(Description = TransposeDesc)] double Transposed = 0.0d, [ExcelArgument(Description = ShowShapeDesc)] double ShowShape = 0.0d)
        {
            dynamic Result;
            // If IsArray(P1) Then
            // MsgBox("Array: (" & P1.GetUpperBound(0).ToString() & ", " & P1.GetUpperBound(1).ToString() & ")")
            // End If
            // MsgBox(P1.ToString() & ":  " & P1.GetType().ToString())
            Result = CallSocketServer0("result = 1;" + PythonCode + MakeParam(P1), Transposed != 0.0d, ShowShape != 0.0d);
            return Result;
        }



        [ExcelFunction(Description = "CPython code with 2 parameters.", HelpTopic = HelpRef)]
        public static dynamic CPY_2([ExcelArgument(Description = PythonCodeDesc)] string PythonCode, [ExcelArgument(Description = P1Desc)] dynamic P1, [ExcelArgument(Description = P2Desc)] dynamic P2, [ExcelArgument(Description = TransposeDesc)] double Transposed = 0.0d, [ExcelArgument(Description = ShowShapeDesc)] double ShowShape = 0.0d)
        {
            dynamic Result;
            Result = CallSocketServer0("result = 1;" + PythonCode + MakeParam(P1) + MakeParam(P2), Transposed != 0.0d, ShowShape != 0.0d);
            return Result;
        }



        [ExcelFunction(Description = "CPython code with 3 parameters.", HelpTopic = HelpRef)]
        public static dynamic CPY_3([ExcelArgument(Description = PythonCodeDesc)] string PythonCode, [ExcelArgument(Description = P1Desc)] dynamic P1, [ExcelArgument(Description = P2Desc)] dynamic P2, [ExcelArgument(Description = P3Desc)] dynamic P3, [ExcelArgument(Description = TransposeDesc)] double Transposed = 0.0d, [ExcelArgument(Description = ShowShapeDesc)] double ShowShape = 0.0d)
        {
            dynamic Result;
            Result = CallSocketServer0("result = 1;" + PythonCode + MakeParam(P1) + MakeParam(P2) + MakeParam(P3), Transposed != 0.0d, ShowShape != 0.0d);
            return Result;
        }



        [ExcelFunction(Description = "CPython code with 4 parameters.", HelpTopic = HelpRef)]
        public static dynamic CPY_4([ExcelArgument(Description = PythonCodeDesc)] string PythonCode, [ExcelArgument(Description = P1Desc)] dynamic P1, [ExcelArgument(Description = P2Desc)] dynamic P2, [ExcelArgument(Description = P3Desc)] dynamic P3, [ExcelArgument(Description = P4Desc)] dynamic P4, [ExcelArgument(Description = TransposeDesc)] double Transposed = 0.0d, [ExcelArgument(Description = ShowShapeDesc)] double ShowShape = 0.0d)
        {
            dynamic Result;
            Result = CallSocketServer0("result = 1;" + PythonCode + MakeParam(P1) + MakeParam(P2) + MakeParam(P3) + MakeParam(P4), Transposed != 0.0d, ShowShape != 0.0d);
            return Result;
        }



        [ExcelFunction(Description = "CPython code with 5 parameters.", HelpTopic = HelpRef)]
        public static dynamic CPY_5([ExcelArgument(Description = PythonCodeDesc)] string PythonCode, [ExcelArgument(Description = P1Desc)] dynamic P1, [ExcelArgument(Description = P2Desc)] dynamic P2, [ExcelArgument(Description = P3Desc)] dynamic P3, [ExcelArgument(Description = P4Desc)] dynamic P4, [ExcelArgument(Description = P5Desc)] dynamic P5, [ExcelArgument(Description = TransposeDesc)] double Transposed = 0.0d, [ExcelArgument(Description = ShowShapeDesc)] double ShowShape = 0.0d)
        {
            dynamic Result;
            Result = CallSocketServer0("result = 1;" + PythonCode + MakeParam(P1) + MakeParam(P2) + MakeParam(P3) + MakeParam(P4) + MakeParam(P5), Transposed != 0.0d, ShowShape != 0.0d);
            return Result;
        }



        [ExcelFunction(Description = "CPython code with 6 parameters.", HelpTopic = HelpRef)]
        public static dynamic CPY_6([ExcelArgument(Description = PythonCodeDesc)] string PythonCode, [ExcelArgument(Description = P1Desc)] dynamic P1, [ExcelArgument(Description = P2Desc)] dynamic P2, [ExcelArgument(Description = P3Desc)] dynamic P3, [ExcelArgument(Description = P4Desc)] dynamic P4, [ExcelArgument(Description = P5Desc)] dynamic P5, [ExcelArgument(Description = P6Desc)] dynamic P6, [ExcelArgument(Description = TransposeDesc)] double Transposed = 0.0d, [ExcelArgument(Description = ShowShapeDesc)] double ShowShape = 0.0d)
        {
            dynamic Result;
            Result = CallSocketServer0("result = 1;" + PythonCode + MakeParam(P1) + MakeParam(P2) + MakeParam(P3) + MakeParam(P4) + MakeParam(P5) + MakeParam(P6), Transposed != 0.0d, ShowShape != 0.0d);
            return Result;
        }



        [ExcelFunction(Description = "CPython code with 7 parameters.", HelpTopic = HelpRef)]
        public static dynamic CPY_7([ExcelArgument(Description = PythonCodeDesc)] string PythonCode, [ExcelArgument(Description = P1Desc)] dynamic P1, [ExcelArgument(Description = P2Desc)] dynamic P2, [ExcelArgument(Description = P3Desc)] dynamic P3, [ExcelArgument(Description = P4Desc)] dynamic P4, [ExcelArgument(Description = P5Desc)] dynamic P5, [ExcelArgument(Description = P6Desc)] dynamic P6, [ExcelArgument(Description = P7Desc)] dynamic P7, [ExcelArgument(Description = TransposeDesc)] double Transposed = 0.0d, [ExcelArgument(Description = ShowShapeDesc)] double ShowShape = 0.0d)
        {
            dynamic Result;
            Result = CallSocketServer0("result = 1;" + PythonCode + MakeParam(P1) + MakeParam(P2) + MakeParam(P3) + MakeParam(P4) + MakeParam(P5) + MakeParam(P6) + MakeParam(P7), Transposed != 0.0d, ShowShape != 0.0d);
            return Result;
        }



        [ExcelFunction(Description = "CPython code with 8 parameters.", HelpTopic = HelpRef)]
        public static dynamic CPY_8([ExcelArgument(Description = PythonCodeDesc)] string PythonCode, [ExcelArgument(Description = P1Desc)] dynamic P1, [ExcelArgument(Description = P2Desc)] dynamic P2, [ExcelArgument(Description = P3Desc)] dynamic P3, [ExcelArgument(Description = P4Desc)] dynamic P4, [ExcelArgument(Description = P5Desc)] dynamic P5, [ExcelArgument(Description = P6Desc)] dynamic P6, [ExcelArgument(Description = P7Desc)] dynamic P7, [ExcelArgument(Description = P8Desc)] dynamic P8, [ExcelArgument(Description = TransposeDesc)] double Transposed = 0.0d, [ExcelArgument(Description = ShowShapeDesc)] double ShowShape = 0.0d)
        {
            dynamic Result;
            Result = CallSocketServer0("result = 1;" + PythonCode + MakeParam(P1) + MakeParam(P2) + MakeParam(P3) + MakeParam(P4) + MakeParam(P5) + MakeParam(P6) + MakeParam(P7) + MakeParam(P8), Transposed != 0.0d, ShowShape != 0.0d);
            return Result;
        }



        [ExcelFunction(Description = "CPython code with 9 parameters.", HelpTopic = HelpRef)]
        public static dynamic CPY_9([ExcelArgument(Description = PythonCodeDesc)] string PythonCode, [ExcelArgument(Description = P1Desc)] dynamic P1, [ExcelArgument(Description = P2Desc)] dynamic P2, [ExcelArgument(Description = P3Desc)] dynamic P3, [ExcelArgument(Description = P4Desc)] dynamic P4, [ExcelArgument(Description = P5Desc)] dynamic P5, [ExcelArgument(Description = P6Desc)] dynamic P6, [ExcelArgument(Description = P7Desc)] dynamic P7, [ExcelArgument(Description = P8Desc)] dynamic P8, [ExcelArgument(Description = P9Desc)] dynamic P9, [ExcelArgument(Description = TransposeDesc)] double Transposed = 0.0d, [ExcelArgument(Description = ShowShapeDesc)] double ShowShape = 0.0d)
        {
            dynamic Result;
            Result = CallSocketServer0("result = 1;" + PythonCode + MakeParam(P1) + MakeParam(P2) + MakeParam(P3) + MakeParam(P4) + MakeParam(P5) + MakeParam(P6) + MakeParam(P7) + MakeParam(P8) + MakeParam(P9), Transposed != 0.0d, ShowShape != 0.0d);
            return Result;
        }









    }
}