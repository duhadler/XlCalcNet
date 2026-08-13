using System;
using System.Diagnostics;
using System.Numerics;
using FixedPrecNet;


#if HasArbPrecNet
using ArbPrecNet;
#endif

//using Ctx = FixedPrecNet.sreal;
//using Ctx = FixedPrecNet.dreal;
//using Ctx = FixedPrecNet.ereal;
//using Ctx = FixedPrecNet.qreal;
//using Ctx = FixedPrecNet.oreal;

#if HasArbPrecNet
//using Ctx = ArbPrecNet.mreal;
using Ctx = ArbPrecNet.aflint;
#endif



namespace TestXlCalcNetPrecCS
{

    static partial class Tests

    {



        public static void TestFunctions_Real_Compare()
        {
            Console.WriteLine("TestFunctions_Lib_BSF2");
            bool HasOpBI = true;
            bool x17 = false;

            var z1 = new BigInteger(-64);
            int si32 = -32;
            long si64 = -64;
            uint ui32 = 32U;
            ulong ui64 = 64UL;
            double d = 3.14159d;
            decimal dec = 3.14159m;
            var BI = BigInteger.Parse("4713143110832790377889");
            string s = "3.1415999999999999999922";



            // From OReal
            var OReal1 = oreal.t("10.5");
            Console.WriteLine("OReal1: {0}", OReal1);
            var x = Ctx.t(OReal1);
            Console.WriteLine("x = Ctx.T(OReal1): {0} ", x);
            Console.WriteLine();


            // From QReal
            var QReal1 = qreal.t("10.5");
            Console.WriteLine("QReal1: {0}", QReal1);
            x = Ctx.t(QReal1);
            Console.WriteLine("x = Ctx.T(QReal1): {0} ", x);
            Console.WriteLine();


            // From EReal
            var EReal1 = ereal.t("10.5");
            Console.WriteLine("EReal1: {0}", EReal1);
            x = Ctx.t(EReal1);
            Console.WriteLine("x = Ctx.T(EReal1): {0} ", x);
            Console.WriteLine();


            Console.WriteLine("si64: {0}", si64);
            Console.WriteLine("z1: {0}", z1);

            var x1 = Ctx.t(si32);
            var x2 = Ctx.t(si64);
            var x3 = Ctx.t(ui32);
            var x4 = Ctx.t(ui64);
            var x5 = Ctx.t(d);
            var x6 = Ctx.t(s);
            var x7 = Ctx.t(dec);
            var x8 = Ctx.t(BI);



            Console.WriteLine("x1 = Ctx.T(si32): {0}", x1);
            Console.WriteLine("x2 = Ctx.T(si64): {0}", x2);
            Console.WriteLine("x3 = Ctx.T(ui32): {0}", x3);
            Console.WriteLine("x4 = Ctx.T(ui64): {0}", x4);
            Console.WriteLine("x5 = Ctx.T(d): {0}", x5);
            Console.WriteLine("x6 = Ctx.T(s): {0}", x6);
            Console.WriteLine("x7 = Ctx.T(dec): {0}", x7);
            if (HasOpBI)
                Console.WriteLine("x8 = Ctx.T(BI): {0}", x8);
            Console.WriteLine();


            bool x10 = x1 < x2;
            bool x11 = x1 < si32;
            bool x12 = x1 < si64;
            bool x13 = x1 < ui32;
            bool x14 = x1 < ui64;
            bool x15 = x1 < d;
            bool x16 = x1 < Ctx.t(dec);

            Console.WriteLine("x10 = x1 < x2: {0}", x10);
            Console.WriteLine("x11 = x1 < si32: {0}", x11);
            Console.WriteLine("x12 = x1 < si64: {0}", x12);
            Console.WriteLine("x13 = x1 < ui32: {0}", x13);
            Console.WriteLine("x14 = x1 < ui64: {0}", x14);
            Console.WriteLine("x15 = x1 < d: {0}", x15);
            Console.WriteLine("x16 = x1 < dec: {0}", x16);
            if (HasOpBI)
                Console.WriteLine("x17 = x1 < BI: {0}", x17);
            Console.WriteLine();

            x10 = x2 < x1;
            x11 = si32 < x1;
            x12 = si64 < x1;
            x13 = ui32 < x1;
            x14 = ui64 < x1;
            x15 = d < x1;
            x16 = Ctx.t(dec) < x1;


            Console.WriteLine("x10 = x2 < x1: {0}", x10);
            Console.WriteLine("x11 = si32 < x1: {0}", x11);
            Console.WriteLine("x12 = si64 < x1: {0}", x12);
            Console.WriteLine("x13 = ui32 < x1: {0}", x13);
            Console.WriteLine("x14 = ui64 < x1: {0}", x14);
            Console.WriteLine("x15 = d < x1: {0}", x15);
            Console.WriteLine("x16 = dec < x1: {0}", x16);
            if (HasOpBI)
                Console.WriteLine("x17 = BI < x1: {0}", x17);
            Console.WriteLine();




            x10 = x1 > x2;
            x11 = x1 > si32;
            x12 = x1 > si64;
            x13 = x1 > ui32;
            x14 = x1 > ui64;
            x15 = x1 > d;
            x16 = x1 > Ctx.t(dec);

            Console.WriteLine("x10 = x1 > x2: {0}", x10);
            Console.WriteLine("x11 = x1 > si32: {0}", x11);
            Console.WriteLine("x12 = x1 > si64: {0}", x12);
            Console.WriteLine("x13 = x1 > ui32: {0}", x13);
            Console.WriteLine("x14 = x1 > ui64: {0}", x14);
            Console.WriteLine("x15 = x1 > d: {0}", x15);
            Console.WriteLine("x16 = x1 > dec: {0}", x16);
            if (HasOpBI)
                Console.WriteLine("x17 = x1 > BI: {0}", x17);
            Console.WriteLine();

            x10 = x2 > x1;
            x11 = si32 > x1;
            x12 = si64 > x1;
            x13 = ui32 > x1;
            x14 = ui64 > x1;
            x15 = d > x1;
            x16 = Ctx.t(dec) > x1;


            Console.WriteLine("x10 = x2 > x1: {0}", x10);
            Console.WriteLine("x11 = si32 > x1: {0}", x11);
            Console.WriteLine("x12 = si64 > x1: {0}", x12);
            Console.WriteLine("x13 = ui32 > x1: {0}", x13);
            Console.WriteLine("x14 = ui64 > x1: {0}", x14);
            Console.WriteLine("x15 = d > x1: {0}", x15);
            Console.WriteLine("x16 = dec > x1: {0}", x16);
            if (HasOpBI)
                Console.WriteLine("x17 = BI > x1: {0}", x17);
            Console.WriteLine();





            x10 = x1 <= x2;
            x11 = x1 <= si32;
            x12 = x1 <= si64;
            x13 = x1 <= ui32;
            x14 = x1 <= ui64;
            x15 = x1 <= d;
            x16 = x1 <= Ctx.t(dec);

            Console.WriteLine("x10 = x1 <= x2: {0}", x10);
            Console.WriteLine("x11 = x1 <= si32: {0}", x11);
            Console.WriteLine("x12 = x1 <= si64: {0}", x12);
            Console.WriteLine("x13 = x1 <= ui32: {0}", x13);
            Console.WriteLine("x14 = x1 <= ui64: {0}", x14);
            Console.WriteLine("x15 = x1 <= d: {0}", x15);
            Console.WriteLine("x16 = x1 <= dec: {0}", x16);
            if (HasOpBI)
                Console.WriteLine("x17 = x1 <= BI: {0}", x17);
            Console.WriteLine();

            x10 = x2 <= x1;
            x11 = si32 <= x1;
            x12 = si64 <= x1;
            x13 = ui32 <= x1;
            x14 = ui64 <= x1;
            x15 = d <= x1;
            x16 = Ctx.t(dec) <= x1;


            Console.WriteLine("x10 = x2 <= x1: {0}", x10);
            Console.WriteLine("x11 = si32 <= x1: {0}", x11);
            Console.WriteLine("x12 = si64 <= x1: {0}", x12);
            Console.WriteLine("x13 = ui32 <= x1: {0}", x13);
            Console.WriteLine("x14 = ui64 <= x1: {0}", x14);
            Console.WriteLine("x15 = d <= x1: {0}", x15);
            Console.WriteLine("x16 = dec <= x1: {0}", x16);
            if (HasOpBI)
                Console.WriteLine("x17 = BI <= x1: {0}", x17);
            Console.WriteLine();





            x10 = x1 >= x2;
            x11 = x1 >= si32;
            x12 = x1 >= si64;
            x13 = x1 >= ui32;
            x14 = x1 >= ui64;
            x15 = x1 >= d;
            x16 = x1 >= Ctx.t(dec);

            Console.WriteLine("x10 = x1 >= x2: {0}", x10);
            Console.WriteLine("x11 = x1 >= si32: {0}", x11);
            Console.WriteLine("x12 = x1 >= si64: {0}", x12);
            Console.WriteLine("x13 = x1 >= ui32: {0}", x13);
            Console.WriteLine("x14 = x1 >= ui64: {0}", x14);
            Console.WriteLine("x15 = x1 >= d  : {0}", x15);
            Console.WriteLine("x16 = x1 >= dec: {0}", x16);
            if (HasOpBI)
                Console.WriteLine("x17 = x1 >= BI: {0}", x17);
            Console.WriteLine();

            x10 = x2 >= x1;
            x11 = si32 >= x1;
            x12 = si64 >= x1;
            x13 = ui32 >= x1;
            x14 = ui64 >= x1;
            x15 = d >= x1;
            x16 = Ctx.t(dec) >= x1;


            Console.WriteLine("x10 = x2 >= x1: {0}", x10);
            Console.WriteLine("x11 = si32 >= x1: {0}", x11);
            Console.WriteLine("x12 = si64 >= x1: {0}", x12);
            Console.WriteLine("x13 = ui32 >= x1: {0}", x13);
            Console.WriteLine("x14 = ui64 >= x1: {0}", x14);
            Console.WriteLine("x15 = d >= x1  : {0}", x15);
            Console.WriteLine("x16 = dec >= x1: {0}", x16);
            if (HasOpBI)
                Console.WriteLine("x17 = BI >= x1: {0}", x17);
            Console.WriteLine();





            x10 = x1 != x2;
            x11 = x1 != si32;
            x12 = x1 != si64;
            x13 = x1 != ui32;
            x14 = x1 != ui64;
            x15 = x1 != d;
            x16 = x1 != Ctx.t(dec);

            Console.WriteLine("x10 = x1 <> x2: {0}", x10);
            Console.WriteLine("x11 = x1 <> si32: {0}", x11);
            Console.WriteLine("x12 = x1 <> si64: {0}", x12);
            Console.WriteLine("x13 = x1 <> ui32: {0}", x13);
            Console.WriteLine("x14 = x1 <> ui64: {0}", x14);
            Console.WriteLine("x15 = x1 <> d  : {0}", x15);
            Console.WriteLine("x16 = x1 <> dec: {0}", x16);
            if (HasOpBI)
                Console.WriteLine("x17 = x1 <> BI: {0}", x17);
            Console.WriteLine();

            x10 = x2 != x1;
            x11 = si32 != x1;
            x12 = si64 != x1;
            x13 = ui32 != x1;
            x14 = ui64 != x1;
            x15 = d != x1;
            x16 = Ctx.t(dec) != x1;

            Console.WriteLine("x10 = x2 <> x1: {0}", x10);
            Console.WriteLine("x11 = si32 <> x1: {0}", x11);
            Console.WriteLine("x12 = si64 <> x1: {0}", x12);
            Console.WriteLine("x13 = ui32 <> x1: {0}", x13);
            Console.WriteLine("x14 = ui64 <> x1: {0}", x14);
            Console.WriteLine("x15 = d <> x1  : {0}", x15);
            Console.WriteLine("x16 = dec <> x1: {0}", x16);
            if (HasOpBI)
                Console.WriteLine("x17 = BI <> x1: {0}", x17);
            Console.WriteLine();



            x10 = x1 == x2;
            x11 = x1 == si32;
            x12 = x1 == si64;
            x13 = x1 == ui32;
            x14 = x1 == ui64;
            x15 = x1 == d;
            x16 = x1 == Ctx.t(dec);

            Console.WriteLine("x10 = x1 = x2: {0}", x10);
            Console.WriteLine("x11 = x1 = si32: {0}", x11);
            Console.WriteLine("x12 = x1 = si64: {0}", x12);
            Console.WriteLine("x13 = x1 = ui32: {0}", x13);
            Console.WriteLine("x14 = x1 = ui64: {0}", x14);
            Console.WriteLine("x15 = x1 = d  : {0}", x15);
            Console.WriteLine("x16 = x1 = dec: {0}", x16);
            if (HasOpBI)
                Console.WriteLine("x17 = x1 = BI: {0}", x17);
            Console.WriteLine();

            x10 = x2 == x1;
            x11 = si32 == x1;
            x12 = si64 == x1;
            x13 = ui32 == x1;
            x14 = ui64 == x1;
            x15 = d == x1;
            x16 = Ctx.t(dec) == x1;

            Console.WriteLine("x10 = x2 = x1: {0}", x10);
            Console.WriteLine("x11 = si32 = x1: {0}", x11);
            Console.WriteLine("x12 = si64 = x1: {0}", x12);
            Console.WriteLine("x13 = ui32 = x1: {0}", x13);
            Console.WriteLine("x14 = ui64 = x1: {0}", x14);
            Console.WriteLine("x15 = d = x1  : {0}", x15);
            Console.WriteLine("x16 = dec = x1: {0}", x16);
            if (HasOpBI)
                Console.WriteLine("x17 = BI = x1: {0}", x17);
            Console.WriteLine();


            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();

        }






        public static void RunTestsCtxFixedScalar()
        {
            TestFunctions_Real_Compare();
        }




        public static void RealCompare()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            RunTestsCtxFixedScalar();

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