using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using Microsoft.VisualBasic;

namespace TestXlCalcNetPrecCS
{

    static partial class Tests
    {
        public static string f(string NumType)
        {
            return ((NumType == "aflint") || (NumType == "aflintc")) ? "" : " ";
        }
    }


        static class Program
    {
        private static string _PythonRootDir;


        static System.Reflection.Assembly LoadFromXlCalcNet(object sender, ResolveEventArgs args)
        {
            string folderPath2 = _PythonRootDir + @"\Lib\site-packages\xlcalcnet\Addin\NET48\Bin";
            string assemblyPath = System.IO.Path.Combine(folderPath2, new System.Reflection.AssemblyName(args.Name).Name + ".dll");
            if (!System.IO.File.Exists(assemblyPath)) return null; else return System.Reflection.Assembly.LoadFrom(assemblyPath);
        }


        static System.Reflection.Assembly LoadFromXlCalcNet2(object sender, ResolveEventArgs args)
        {
            string folderPath2 = _PythonRootDir + @"\Lib\site-packages\xlcalcnet2\Addin\NET48\Bin";
            string assemblyPath = System.IO.Path.Combine(folderPath2, new System.Reflection.AssemblyName(args.Name).Name + ".dll");
            if (!System.IO.File.Exists(assemblyPath)) return null; else return System.Reflection.Assembly.LoadFrom(assemblyPath);
        }

        public static void Main()
        {
            _PythonRootDir = @"C:\Python313";
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromXlCalcNet);
            currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromXlCalcNet2);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            var ci = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
            ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;

            try
            {
                var stopWatch1 = new Stopwatch();
                stopWatch1.Start();

                RunTests();

                stopWatch1.Stop();
                var ts = stopWatch1.Elapsed;
                string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10d);
                Console.WriteLine("");
                Console.WriteLine("total Elapsed Time " + elapsedTime);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Interaction.MsgBox(ex.ToString());
            }

            Console.WriteLine("Press the key q to exit . . . ");
            // Console.SetCursorPosition(0,0)
            ConsoleKeyInfo info;
            string ch;
            ch = "";
            while (ch != "q")
            {
                info = Console.ReadKey(true);
                ch = info.KeyChar.ToString();
            }

        }



        public static void RunTests()
        {
            //Tests.Conversions();  // B01

            //Tests.RealCompare();  // B01

            //Tests.BasicFloatingPointFunctions(); // B02

            //Tests.RealElementaryFunctions();  // B03

            //Tests.CplxElementaryFunctions();  // B03

            //Tests.Distributions();  // B04

            //Tests.NumericalCalculus();  // B05

            //Tests.FlintNumericalCalculus();  // B05

            //Tests.MatAll();  // B06

            //Tests.MatFp();  // B06

            //Tests.MatFpReal();  // B06

            //Tests.SparseMatrix();  // B06


            //Tests.RealEllipticFunctions();  // B08

            //Tests.CplxEllipticFunctions();  // B08

            //Tests.RealLerchPhi();  // B09

            //Tests.CplxLerchPhi();  // B09

            //Tests.RealHypergeometric_0F1();  // B10

            //Tests.CplxHypergeometric_0F1();  // B10

            //Tests.RealHypergeometric_1F1();  // B11

            //Tests.CplxHypergeometric_1F1();  // B11

            Tests.RealHypergeometric_pFq();  // B12

            //Tests.CplxHypergeometric_pFq();  // B12


            //TestMath53.Test_Math53();

            //TestmathC53.Test_mathC53();

            //Tests.RankDistributions();


        }

    }
}