using MpFunLabClient;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;


namespace TestServer
{

    static class Program
    {




        public static void TestSocketServer()
        {
            Console.WriteLine("Hello TestSocketServer!");
            bool Transpose = false;
            bool ShowShape = true;

            //string Code2 = "mpm.dps=80; x = mpm.t(5); y = mpm.sqrt(x); z = x + y; result = str(z)+ 'ÖüÄß'";
            //string Code2 = "x = 5.0; y = math.sqrt(x); z = x + y; result = z";
            //string Code2 = "x = 5.0; y = math.sqrt(x); z = x + y; result = z > x";

            //string Code2 = "result = getmatB()";
            //string Code2 = "result = sys.path";


            //string Code2 = "from A01_ExamplesPython.B18_FunctionsAndCurvesPlots.C02_BasicCurves import D02_Circle;";
            //Code2 += "D02_Circle.CircleXY(); result = 'Done'";


            string Code2 = "result = P1";
            string s1 = new string('A', 800);
            string s2 = new string('B', 800);
            string s3 = new string('C', 800);
            dynamic[,] P1;
            P1 = new dynamic[,] { { s1, s2, s3 }, { "A1", "B1", "C1" } };
            Code2 = Code2 + MpFunLabSocketClientClass.MakeParam(P1);
            //Console.WriteLine(Code2);


            dynamic ResultFinal = MpFunLabSocketClientClass.CallSocketServer0(Code2, Transpose, ShowShape);

            Console.WriteLine();

            Console.WriteLine("Returned:");
            Console.WriteLine("{0}, {1}", ResultFinal.ToString(), ResultFinal.GetType());

            try
            {
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
            catch (Exception)
            {
            }
            Console.WriteLine();
        }




        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");


            var stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < 1; i++) 
                TestSocketServer();

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