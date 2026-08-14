using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MpFunLabClient;

namespace TestServer
{

    static class Program
    {

        //public static void CloseSocketServer()
        //{
        //    var scc = new MpFunLabSocketClientClass();
        //    string Code = "sys.exit(0)";
        //    string Result = scc.CallSocketServer(Code);

        //}

        //public static bool SocketServerIsRunning()
        //{
        //    bool Found = false;
        //    Process[] aProc1 = Process.GetProcessesByName("python");
        //    for (int i = 1, loopTo = aProc1.Length; i <= loopTo; i++)
        //    {
        //        string Title = aProc1[i - 1].MainWindowTitle;
        //        bool IsInWordPad = Title.Contains("mpfunlab socket server 64 bit on port 11958");
        //        if (IsInWordPad)
        //        {
        //            Found = true;
        //        }
        //    }
        //    return Found;
        //}



        //public static void ListProcs()
        //{
        //    Process[] aProc1 = Process.GetProcessesByName("python");
        //    for (int i = 1, loopTo = aProc1.Length; i <= loopTo; i++)
        //    {
        //        string Title = aProc1[i - 1].MainWindowTitle;
        //        string Info = aProc1[i - 1].ToString();
        //        Console.WriteLine("Title: {0}", Title);
        //        Console.WriteLine("Info: {0}", Info);
        //        bool IsInWordPad = Title.Contains("mpfunlab socket server 64 bit on port 11958");
        //        if (IsInWordPad)
        //        {
        //            Console.WriteLine("!FoundServer!");
        //        }
        //    }

        //}

        public static dynamic GetTypedData(string Result2)
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



        public static dynamic CallSocketServer1(string Code, bool Transpose, bool ShowShape)
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
                Console.WriteLine("VB: write to file");
                string MyPath = @"C:\Temp\FileTempIn.txt";
                File.WriteAllText(MyPath, Code, utf8WithoutBOM);
                string Code2 = "$file:$" + MyPath;
                ResultStr = scc.CallSocketServer(Code2);
            }
            else
            {
                ResultStr = scc.CallSocketServer(Code);
            }

            if (ResultStr.StartsWith("$file:$"))
            {
                Console.WriteLine("VB: read from file");
                string ResultPath = @"C:\Temp\FileTempOut.txt";
                string ResultFinal2 = File.ReadAllText(ResultPath, utf8WithoutBOM);
                Console.WriteLine("ResultFinal2: {0}", ResultFinal2);
                return ResultStringTodynamic(ResultFinal2, Transpose, ShowShape);
            }
            else
            {
                return ResultStringTodynamic(ResultStr, Transpose, ShowShape);
            }
        }


        private static dynamic CallSocketServer0(string Code2, bool Transpose, bool ShowShape)
        {
            var scc = new MpFunLabSocketClientClass();
            string Result = scc.CallSocketServer(Code2);
            // MsgBox(Code2)
            if (Result.StartsWith("$list$"))
            {
                dynamic[,] oTable;
                string[] ResArray = Strings.Split(Result, "§__§");
                //string[] ResArray = string.Split(Result, "§__§");
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




        public static dynamic ResultStringTodynamic(string Result, bool Transpose, bool ShowShape)
        {
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
                    // Console.WriteLine(Row)
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
                        // Console.WriteLine("i:{0}, j:{1}, val:{2}", i, j, Val)
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


        public static void TestSocketServer()
        {
            Console.WriteLine("Hello TestSocketServer!");
            bool Transpose;
            bool ShowShape;
            Transpose = true;
            ShowShape = true;
            var scc = new MpFunLabSocketClientClass();

            //string Code2 = "mpm.dps=80; x = mpm.t(5); y = mpm.sqrt(x); z = x + y; result = str(z)+ 'ÖüÄß'";
            //string Code2 = "x = 5.0; y = math.sqrt(x); z = x + y; result = z"
            //string Code2 = "x = 5.0; y = math.sqrt(x); z = x + y; result = z > x"

            //string Code2 = "result = getmatB()";
            string Code2 = "result = sys.path";


            // Dim ResultFinal = CallSocketServer0(Code2, Transpose, ShowShape)
            dynamic[,] ResultFinal = CallSocketServer1(Code2, Transpose, ShowShape);
            Console.WriteLine("{0}, {1}", ResultFinal.ToString(), ResultFinal.GetType());
            int U0 = ResultFinal.GetUpperBound(0);
            int U1 = ResultFinal.GetUpperBound(1);
            Console.WriteLine("U0: {0}, U1: {1}", U0, U1);
            for (int i = 0; i <= U0; i++)
            {
                for (int j = 0; j <= U1; j++)
                {
                    Console.WriteLine("{0}, {1}", ResultFinal[i, j], ResultFinal[i, j].GetType());
                }
            }
        }





        public static string MakeParam(dynamic P)
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
                    //RowsJoined[i + 1] = Strings.Join(ColsJoined, "§_§");
                    RowsJoined[i + 1] = string.Join("§_§", ColsJoined);
                }
                //PStr = Strings.Join(RowsJoined, "§__§");
                PStr = string.Join("§__§", RowsJoined);
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


        public static void TestSocketServerP1()
        {
            Console.WriteLine("Hello TestSocketServerP1!");
            bool Transpose;
            bool ShowShape;
            Transpose = false;
            ShowShape = false;
            var scc = new MpFunLabSocketClientClass();
            string Code2 = "x = 5.0; y = math.sqrt(x); z = x + y; result = P1";

            dynamic[,] P1;
            P1 = new dynamic[,] { { 3.1111d, 4.2222d, 5.3333d }, { "A", "B1", "C" } };

            Code2 = Code2 + MakeParam(P1);
            Console.WriteLine(Code2);

            dynamic[,] ResultFinal = CallSocketServer0(Code2, Transpose, ShowShape);
            Console.WriteLine("{0}, {1}", ResultFinal.ToString(), ResultFinal.GetType());
            int U0 = ResultFinal.GetUpperBound(0);
            int U1 = ResultFinal.GetUpperBound(1);
            Console.WriteLine("U0: {0}, U1: {1}", U0, U1);
            for (int i = 0; i <= U0; i++)
            {
                for (int j = 0; j <= U1; j++)
                {
                    Console.WriteLine("{0}, {1}", ResultFinal[i, j], ResultFinal[i, j].GetType());
                }
            }
        }


        public static void TestSocketServerP2()
        {
            Console.WriteLine("Hello TestSocketServerP2!");
            bool Transpose;
            bool ShowShape;
            Transpose = false;
            ShowShape = false;
            var scc = new MpFunLabSocketClientClass();
            //string Code2 = "x = 5.0; y = math.sqrt(x); z = x + y; result = P1";

            string Code2 = "from xlcalcnet import gui; gui.adduserpath();";
            Code2 += "from A01_XlcalcnetExamplesPython.B19_FunctionsPlots.C02_BasicCurves import D02_Circle;";
            Code2 += "D02_Circle.CircleXY(); result = 'Done'";

            dynamic[,] P1;
            P1 = new dynamic[,] { { 3.1111d, 4.2222d, 5.3333d }, { "A", "B1", "C" } };

            Code2 = Code2 + MakeParam(P1);
            Console.WriteLine(Code2);

            dynamic ResultFinal = CallSocketServer0(Code2, Transpose, ShowShape);
            //Console.WriteLine("{0}, {1}", ResultFinal.ToString(), ResultFinal.GetType());
            //int U0 = ResultFinal.GetUpperBound(0);
            //int U1 = ResultFinal.GetUpperBound(1);
            //Console.WriteLine("U0: {0}, U1: {1}", U0, U1);
            //for (int i = 0; i <= U0; i++)
            //{
            //    for (int j = 0; j <= U1; j++)
            //    {
            //        Console.WriteLine("{0}, {1}", ResultFinal[i, j], ResultFinal[i, j].GetType());
            //    }
            //}
        }



        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            //TestSocketServer();
            //TestSocketServerP1();
            TestSocketServerP2();

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10d);
            Console.WriteLine("Elapsed Time " + elapsedTime);
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Memory used before collection:       {0:N0}", GC.GetTotalMemory(false));
            GC.Collect();
            Console.WriteLine("Memory used after full collection:   {0:N0}", GC.GetTotalMemory(true));
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("");

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

    }
}