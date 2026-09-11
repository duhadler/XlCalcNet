using MpFunLabClient;
using System;
using TinyPlot2DCtrl;



namespace TinyPlot2DUserCtrl
{
    public partial class CallServer
    {

        private static WpfSVGCtrl wpfSVGCtrl1_ = null;


        public void SetParams1(Plot2DCtrl FlexDlg)
        {
            wpfSVGCtrl1_ = FlexDlg.WpfSVGCtrl1;
        }

        public static string TestSocketServerP2()
        {
            bool Transpose;
            bool ShowShape;
            Transpose = false;
            ShowShape = false;
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

            Code2 = Code2 + MpFunLabSocketClientClass.MakeParam(P1);
            Console.WriteLine(Code2);

            // ASYNC !!!

            dynamic ResultFinal = MpFunLabSocketClientClass.CallSocketServer0(Code2, Transpose, ShowShape);

            // ASYNC !!!


            string ResultFinalString = ResultFinal.ToString();
            return ResultFinalString;


        }







    }

}
