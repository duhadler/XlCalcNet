using CodingSeb.ExpressionEvaluator;
using Microsoft.VisualBasic;
using MpFunLabClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using TinyPlot2DCtrl;



namespace TinyPlot2DUserCtrl
{
    public partial class CallServer
    {

        private static WpfSVGCtrl wpfSVGCtrl1_ = null;
        //private static WpfGraphicsSettings _wpfSettings1 = null;


        public void SetParams1(Plot2DCtrl FlexDlg)
        {
            wpfSVGCtrl1_ = FlexDlg.WpfSVGCtrl1;
            //_wpfSettings1 = Plot2DCtrl.wpfSettings1;
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



        private static dynamic CallSocketServer0(string Code2, bool Transpose, bool ShowShape)
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
        public static string GetFullTempPathTop()
        {
            string LocalAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return LocalAppDataDir + @"\XlCalcNetIDE\Temp";
        }


        public static void TestSocketServerP2()
        {

            Console.WriteLine("Hello TestSocketServerP1!");
            bool Transpose;
            bool ShowShape;
            Transpose = false;
            ShowShape = false;
            var scc = new MpFunLabSocketClientClass();
            WpfGraphicsSettings _wpfSettings1 = Plot2DCtrl.wpfSettings1;

            string LocalImports = "";
            if (!string.IsNullOrEmpty(_wpfSettings1.LocalImports))
                LocalImports = _wpfSettings1.LocalImports;

            string Kwargs = "";
            if (!string.IsNullOrEmpty(_wpfSettings1.Code))
                Kwargs = ", " + _wpfSettings1.Code;

            string Code2 = _wpfSettings1.ImportStatement
                + LocalImports
                + _wpfSettings1.FunctionName
                + "(" 
                + "OutputDir='Temp', "
                + "Title=" + "r'" + _wpfSettings1.Title + "', "
                + "PlotStyle=" + "'" + _wpfSettings1.PlotStyle + "', "
                + "OutputMode=" + "'" + _wpfSettings1.OutputMode + "', "
                + "FigSizeX=" + "'" + _wpfSettings1.FigSizeX.ToString() + "', "
                + "FigSizeY=" + "'" + _wpfSettings1.FigSizeY.ToString() + "', "
                + "Resolution=" + "'" + _wpfSettings1.Resolution.ToString() + "' "

                + Kwargs

                + "); " 
                + "result = 'Done'";

            //MessageBox.Show(Code2);


            dynamic[,] P1;
            P1 = new dynamic[,] { { 3.1111d, 4.2222d, 5.3333d }, { "A", "B1", "C" } };

            Code2 = Code2 + MakeParam(P1);
            Console.WriteLine(Code2);

            // ASYNC !!!

            dynamic ResultFinal = CallSocketServer0(Code2, Transpose, ShowShape);

            // ASYNC !!!

            string FileName = GetFullTempPathTop() + @"\"  + "Temp.svg";
            wpfSVGCtrl1_.SetFileName(FileName);

        }











    }

}
