using System;
using System.Diagnostics;
using System.Numerics;
using FixedPrecNet;



#if HasArbPrecNet
using ArbPrecNet;
#endif

using Ctx = FixedPrecNet.sreal;
//using Ctx = FixedPrecNet.scplx;
//using Ctx = FixedPrecNet.dreal;
//using Ctx = FixedPrecNet.dcplx;
//using Ctx = FixedPrecNet.ereal;
//using Ctx = FixedPrecNet.ecplx;
//using Ctx = FixedPrecNet.qreal;
//using Ctx = FixedPrecNet.qcplx;
//using Ctx = FixedPrecNet.oreal;
//using Ctx = FixedPrecNet.ocplx;

#if HasArbPrecNet
//using Ctx = ArbPrecNet.mreal;
//using Ctx = ArbPrecNet.mcplx;
//using Ctx = ArbPrecNet.aflint;
//using Ctx = ArbPrecNet.aflintc;
#endif



namespace TestXlCalcNetPrecCS
{

    static partial class Tests
    {


        public static void TestFunctionsConversionFromReal()
        {
            var x = Ctx.t(0);


            // From OReal
            var OReal1 = oreal.t("10.5");
            Console.WriteLine("OReal1: {0}", OReal1);
            x = Ctx.t(OReal1);
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


            // From Double
            double d = 3.14159d;
            Console.WriteLine("d: {0}", d);
            x = Ctx.t(d);
            Console.WriteLine("x = Ctx.T(d): {0} ", x);
            Console.WriteLine();


            // From Int32
            int si32 = -32;
            si32 = int.MaxValue;
            Console.WriteLine("si32: {0}", si32);
            x = Ctx.t(si32);
            Console.WriteLine("x = Ctx.T(si32): {0} ", x);
            Console.WriteLine();


            // From Int64
            long si64 = -64L;
            si64 = long.MaxValue;
            Console.WriteLine("si64: {0}", si64);
            x = Ctx.t(si64);
            Console.WriteLine("x = Ctx.T(si64): {0} ", x);
            Console.WriteLine();


            // From UInt32
            uint ui32 = 32U;
            ui32 = uint.MaxValue;
            Console.WriteLine("ui32: {0}", ui32);
            x = Ctx.t(ui32);
            Console.WriteLine("x = Ctx.T(ui32): {0} ", x);
            Console.WriteLine();


            // From Uint64
            ulong ui64 = 64UL;
            ui64 = ulong.MaxValue;
            Console.WriteLine("ui64: {0}", ui64);
            x = Ctx.t(ui64);
            Console.WriteLine("x = Ctx.T(ui64): {0} ", x);
            Console.WriteLine();


            // From Decimal, part 1
            decimal dec1 = -79228162514264337593543950335m;
            Console.WriteLine("dec1: {0}", dec1);
            x = Ctx.t(dec1);
            Console.WriteLine("x = Ctx.T(dec1): {0} ", x);
            Console.WriteLine();

            // From Decimal, part 2
            decimal dec2 = 0.0000000000000000000000000001m;
            Console.WriteLine("dec2: {0}", dec2);
            x = Ctx.t(dec2);
            Console.WriteLine("x = Ctx.T(dec2): {0} ", x);
            Console.WriteLine();



            // From Biginteger
            string s2 = "-9031583741089631207100208803714000090315837410896312071002088037140000903158374108963129999";
            var negBigInt = new BigInteger();
            BigInteger.TryParse(s2, out negBigInt);
            Console.WriteLine("negBigInt: {0}", negBigInt);
            x = Ctx.t(negBigInt);
            Console.WriteLine("x = Ctx.T(negBigInt): {0} ", x);
            Console.WriteLine();



            // From String, part 1
            string s = "174535653333";
            Console.WriteLine("s: {0}", s);
            x = Ctx.t(s);
            Console.WriteLine("x: {0}", x);
            Console.WriteLine();


            // From String, part 2
            string s1 = "9138968124.7993671255432112000000";
            Console.WriteLine("s1: {0}", s1);
            x = Ctx.t(s1);
            Console.WriteLine("x = Ctx.T(s1): {0} ", x);
            Console.WriteLine();




            Console.WriteLine("-------------------------------------------------");
        }



        public static void TestFunctions_Lib_Arithmetic()
        {
            Console.WriteLine("TestFunctions_Lib_Arithmetic");
            xcn.UseRawDouble = false;
            var x18 = Ctx.t(0);

            var z1 = new BigInteger(-64);
            int si32 = -32;
            long si64 = -64;
            uint ui32 = 32U;
            ulong ui64 = 64UL;

            float sng = 3.00390625f;     // = 3 + (1/256) = 3 + 2^(-8)
            double d = 3.00390625d;     // = 3 + (1/256) = 3 + 2^(-8)
            decimal dec = 3.00390625m;     // = 3 + (1/256) = 3 + 2^(-8)
            var BI = BigInteger.Parse("4713143110832790377889");

            Console.WriteLine("si64: {0}", si64);
            Console.WriteLine("z1: {0}", z1);

            var x1 = Ctx.t(si32);
            var x2 = Ctx.t(si64);
            var x3 = Ctx.t(ui32);
            var x4 = Ctx.t(ui64);
            var x5 = Ctx.t(sng);
            var x6 = Ctx.t(d);
            var x7 = Ctx.t(dec);
            var x8 = Ctx.t(BI);

            Console.WriteLine("x1 = Ctx.T(si32): {0}", x1);
            Console.WriteLine("x2 = Ctx.T(si64): {0}", x2);
            Console.WriteLine("x3 = Ctx.T(ui32): {0}", x3);
            Console.WriteLine("x4 = Ctx.T(ui64): {0}", x4);
            Console.WriteLine("x4 = Ctx.T(sng): {0}", x5);
            Console.WriteLine("x6 = Ctx.T(d)  : {0}", x6);
            Console.WriteLine("x7 = Ctx.T(dec): {0}", x7);
            Console.WriteLine("x8 = Ctx.T(BI): {0}", x8);
            Console.WriteLine();

            var x10 = x1 + x2;
            Console.WriteLine("x10 = x1 + x2: {0}", x10);

            var x11 = x1 + si32;
            Console.WriteLine("x11 = x1 + si32: {0}", x11);

            var x12 = x1 + si64;
            Console.WriteLine("x12 = x1 + si64: {0}", x12);

            var x13 = x1 + ui32;
            Console.WriteLine("x13 = x1 + ui32: {0}", x13);

            var x14 = x1 + ui64;
            Console.WriteLine("x14 = x1 + ui64: {0}", x14);

            var x15 = x1 + sng;
            Console.WriteLine("x15 = x1 + sng: {0}", x15);

            var x16 = x1 + d;
            Console.WriteLine("x16 = x1 + d:   {0}", x16);

            var x17 = x1 + Ctx.t(dec);
            Console.WriteLine("x17 = x1 + dec: {0}", x17);

            Console.WriteLine();



            x10 = x2 + x1;
            Console.WriteLine("x10 = x2 + x1: {0}", x10);

            x11 = si32 + x1;
            Console.WriteLine("x11 = si32 + x1: {0}", x11);

            x12 = si64 + x1;
            Console.WriteLine("x12 = si64 + x1: {0}", x12);

            x13 = ui32 + x1;
            Console.WriteLine("x13 = ui32 + x1: {0}", x13);

            x14 = ui64 + x1;
            Console.WriteLine("x14 = ui64 + x1: {0}", x14);

            x15 = sng + x1;
            Console.WriteLine("x15 = sng + x1: {0}", x15);

            x16 = d + x1;
            Console.WriteLine("x16 = d + x1:   {0}", x16);

            x17 = Ctx.t(dec) + x1;
            Console.WriteLine("x17 = dec + x1: {0}", x17);

            Console.WriteLine();



            x10 = x1 - x2;
            Console.WriteLine("x10 = x1 - x2: {0}", x10);

            x11 = x1 - si32;
            Console.WriteLine("x11 = x1 - si32: {0}", x11);

            x12 = x1 - si64;
            Console.WriteLine("x12 = x1 - si64: {0}", x12);

            x13 = x1 - ui32;
            Console.WriteLine("x13 = x1 - ui32: {0}", x13);

            x14 = x1 - ui64;
            Console.WriteLine("x14 = x1 - ui64: {0}", x14);

            x15 = x1 - sng;
            Console.WriteLine("x15 = x1 - sng: {0}", x15);

            x16 = x1 - d;
            Console.WriteLine("x16 = x1 - d:   {0}", x16);

            x17 = x1 - Ctx.t(dec);
            Console.WriteLine("x17 = x1 - dec: {0}", x17);

            Console.WriteLine();



            x10 = x2 - x1;
            Console.WriteLine("x10 = x2 - x1: {0}", x10);

            x11 = si32 - x1;
            Console.WriteLine("x11 = si32 - x1: {0}", x11);

            x12 = si64 - x1;
            Console.WriteLine("x12 = si64 - x1: {0}", x12);

            x13 = ui32 - x1;
            Console.WriteLine("x13 = ui32 - x1: {0}", x13);

            x14 = ui64 - x1;
            Console.WriteLine("x14 = ui64 - x1: {0}", x14);

            x15 = sng - x1;
            Console.WriteLine("x15 = sng - x1: {0}", x15);

            x16 = d - x1;
            Console.WriteLine("x16 = d - x1:   {0}", x16);

            x17 = Ctx.t(dec) - x1;
            Console.WriteLine("x17 = dec - x1: {0}", x17);

            Console.WriteLine();



            x10 = x1 * x2;
            Console.WriteLine("x10 = x1 * x2: {0}", x10);

            x11 = x1 * si32;
            Console.WriteLine("x11 = x1 * si32: {0}", x11);

            x12 = x1 * si64;
            Console.WriteLine("x12 = x1 * si64: {0}", x12);

            x13 = x1 * ui32;
            Console.WriteLine("x13 = x1 * ui32: {0}", x13);

            x14 = x1 * ui64;
            Console.WriteLine("x14 = x1 * ui64: {0}", x14);

            x15 = x1 * sng;
            Console.WriteLine("x15 = x1 * sng: {0}", x15);

            x16 = x1 * d;
            Console.WriteLine("x16 = x1 * d:   {0}", x16);

            x17 = x1 * Ctx.t(dec);
            Console.WriteLine("x17 = x1 * dec: {0}", x17);

            Console.WriteLine();



            x10 = x2 * x1;
            Console.WriteLine("x10 = x2 * x1: {0}", x10);

            x11 = si32 * x1;
            Console.WriteLine("x11 = si32 * x1: {0}", x11);

            x12 = si64 * x1;
            Console.WriteLine("x12 = si64 * x1: {0}", x12);

            x13 = ui32 * x1;
            Console.WriteLine("x13 = ui32 * x1: {0}", x13);

            x14 = ui64 * x1;
            Console.WriteLine("x14 = ui64 * x1: {0}", x14);

            x15 = sng * x1;
            Console.WriteLine("x15 = sng * x1: {0}", x15);

            x16 = d * x1;
            Console.WriteLine("x16 = d * x1:   {0}", x16);

            x17 = Ctx.t(dec) * x1;
            Console.WriteLine("x17 = dec * x1: {0}", x17);

            Console.WriteLine();



            x10 = x1 / x2;
            Console.WriteLine("x10 = x1 / x2: {0}", x10);

            x11 = x1 / si32;
            Console.WriteLine("x11 = x1 / si32: {0}", x11);

            x12 = x1 / si64;
            Console.WriteLine("x12 = x1 / si64: {0}", x12);

            x13 = x1 / ui32;
            Console.WriteLine("x13 = x1 / ui32: {0}", x13);

            x14 = x1 / ui64;
            Console.WriteLine("x14 = x1 / ui64: {0}", x14);

            x15 = x1 / sng;
            Console.WriteLine("x15 = x1 / sng: {0}", x15);

            x16 = x1 / d;
            Console.WriteLine("x16 = x1 / d  : {0}", x16);

            x17 = x1 / Ctx.t(dec);
            Console.WriteLine("x17 = x1 / dec: {0}", x17);

            Console.WriteLine();



            x10 = x2 / x1;
            Console.WriteLine("x10 = x2 / x1: {0}", x10);

            x11 = si32 / x1;
            Console.WriteLine("x11 = si32 / x1: {0}", x11);

            x12 = si64 / x1;
            Console.WriteLine("x12 = si64 / x1: {0}", x12);

            x13 = ui32 / x1;
            Console.WriteLine("x13 = ui32 / x1: {0}", x13);

            x14 = ui64 / x1;
            Console.WriteLine("x14 = ui64 / x1: {0}", x14);

            x15 = sng / x1;
            Console.WriteLine("x15 = sng / x1: {0}", x15);

            x16 = d / x1;
            Console.WriteLine("x16 = d / x1  : {0}", x16);

            x17 = Ctx.t(dec) / x1;
            Console.WriteLine("x17 = dec / x1: {0}", x17);

            Console.WriteLine();


            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();

        }


        public static void TestFunctions_Lib_Compare()
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




            bool x10 = x1 != x2;
            bool x11 = x1 != si32;
            bool x12 = x1 != si64;
            bool x13 = x1 != ui32;
            bool x14 = x1 != ui64;
            bool x15 = x1 != d;
            bool x16 = x1 != Ctx.t(dec);

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





        public static void RunTestsRealFixedScalar()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(28);
#endif
            TestFunctionsConversionFromReal();
            //TestFunctions_Lib_Arithmetic();
            //TestFunctions_Lib_Compare();


        }




        public static void Conversions()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            RunTestsRealFixedScalar();

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