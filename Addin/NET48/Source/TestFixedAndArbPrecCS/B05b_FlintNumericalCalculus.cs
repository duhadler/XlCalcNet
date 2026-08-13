using System;
using System.Diagnostics;


#if HasArbPrecNet
using ArbPrecNet;
#endif




namespace TestXlCalcNetPrecCS
{



    static partial class Tests
    {

        public static void RunTestsAnyMainMat()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(18);
#endif

            DemoYamanaka2010();
            DemoRump2010();
        }





        #region Integration



        // *************************** DE  ***********************************

        private static ArbC Yamanaka2010(ArbC t)
        {
            return aflintc.sin(aflintc.exp(t));
        }

        private static void DemoYamanaka2010()
        {
            // wolfram alpha: integrate sin(exp(x))/sqrt(x) from 0 to 2 = 1.50572...
            ArbPrec.SetDps(40);
            var a = aflint.t(0.0);
            var b = aflint.t(2.0);
            var alpha = aflint.t(0.5); // alpha = 0.5 to compensate for leaving out division by sqrt(x)
            var beta = aflint.t(1.0);
            var epsabsStart = aflint.t("1.0E-40");
            var result = aflintc.DE_Integration(Yamanaka2010, a, b, epsabsStart, alpha, beta);
            Console.WriteLine("result: {0}", result);
        }



        // *************************** GL  ***********************************



        private static ArbC Rump2010(ArbC x)
        {
            return aflintc.sin(x + aflintc.exp(x));
        }

        private static void DemoRump2010()
        {
            ArbPrec.SetPrec(100U);
            ArbC s = new ArbC(), a = new ArbC(), b = new ArbC();
            a = aflintc.t(0);
            b = aflintc.t(8);
            s = aflintc.GaussLegendre(Rump2010, a, b);
            Console.WriteLine("Integral: {0}", s);
        }



        #endregion






            public static void FlintNumericalCalculus()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            RunTestsAnyMainMat();

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
        }




    }
}