using System;
using System.Diagnostics;

#if HasArbPrecNet
using ArbPrecNet;
#endif

//using Ctx = FixedPrecNet.sreal;
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
using Ctx = ArbPrecNet.aflintc;
#endif


namespace TestXlCalcNetPrecCS
{

    static partial class Tests
    {

        public static void RunTestsAnyMainMatAll()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(18);
#endif
            DemoAnyMatSpeedCtx(); GC.Collect();
            DemoAnyMatSpeedDetCtx(); GC.Collect();
            DemoAnyMatCtx(); GC.Collect();
            //DemoAnyMatSortCtx(); GC.Collect();
            //DemoAnyMatSelectCtx(); GC.Collect();
            DemoAnyMatSolveCtx(); GC.Collect();
            DemoAnyMatLDLTCtx(); GC.Collect();
            DemoAnyMatPartialPivLUCtx(); GC.Collect();
            DemoAnyMatFullPivLUCtx(); GC.Collect();
            DemoAnyMatLLTCtx(); GC.Collect();
            DemoAnyMatHouseholderQRCtx(); GC.Collect();
            DemoAnyMatColPivHouseholderQRCtx(); GC.Collect();
            DemoAnyMatFullPivHouseholderQRCtx(); GC.Collect();
            DemoAnyMatCODCtx(); GC.Collect();
        }




        public static void MatAll()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            RunTestsAnyMainMatAll();

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



        public static void DemoAnyMatSpeedCtx()
        {
            Console.WriteLine("DemoAnyMatSpeed: " + Ctx.name);
            int m = 100;
            int n = 100;
            var A = Ctx.mat_random(n, m);
            var B = Ctx.mat_random(n, m);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var C = A * B;
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10d);
            Console.WriteLine("Elapsed Time " + elapsedTime);
        }




        public static void DemoAnyMatSpeedDetCtx()
        {
            Console.WriteLine("DemoAnyMatSpeedDetCtx: " + Ctx.name);
            // Dim digits = 15
            int m = 10;
            int n = 10;
            var A = Ctx.mat_random(n, m);
            var b1 = Ctx.mat_random(n, 1);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var res = A.PartialPivLU("rcond, lu, p, det, x, inverse", b1);
            var ts = stopWatch.Elapsed;
            Console.WriteLine("det: {0}", res["det"][0, 0]);
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10d);
            Console.WriteLine("Elapsed Time " + elapsedTime);
        }





        public static void DemoAnyMatCtx()
        {
            Console.WriteLine("DemoAnyMatCtx: " + Ctx.name);
            int digits = 15;

            var x1 = Ctx.mat_random(4, 4);
            x1.Print("x1: ", digits);

            var d1 = x1;
            d1.Print("d1: ", digits);

            var d2 = Ctx.mat_random(4, 4);
            d2.Print("d2: ", digits);

            var x2 = d2;
            x2.Print("x2: ", digits);

            var z1 = x1.ConcatHorizontal(x2);
            z1.Print("z1 = x1.ConcatHorizontal(x2): ", digits);

            var z2 = x1.ConcatVertical(x2);
            z2.Print("z2 = x1.ConcatVertical(x2): ", digits);

            var y1 = x1.Inverse();
            y1.Print("y1: ", digits);

            z1 = x1 * y1;
            z1.Print("z1: ", digits);

            z2 = x1 / x2;
            z2.Print("z2: ", digits);

            var Coeff = x1[1, 1];
            Console.WriteLine("Coeff: {0}", Coeff);

            var Coeff2 = Ctx.t(1.11111111111d);
            Console.WriteLine("Coeff2: {0}", Coeff2);
            y1[1, 1] = Coeff2;
            y1.Print("y1: ", digits);

            Console.WriteLine("Rows: " + x1.rows);
            Console.WriteLine("Cols: " + x1.cols);
            Console.WriteLine("Size: " + x1.size);

            uint count = y1.GTcount(x1);
            Console.WriteLine("GT: " + count);

            z1 = x1.get_Block(0, 0, 1, 1);
            z1.Print("z1= x1.block(0, 0, 1, 1): ", digits);

            var A = Ctx.mat_random(3, 5);
            A.Print("A: ", digits);

            A.Resize(2, 4);
            A.Print("A: ", digits);

            x1.ConservativeResize(2, 5);
            x1.Print("x1: ", digits);
        }







        public static void DemoAnyMatSolveCtx()
        {
            Console.WriteLine("DemoAnyMatSolveCtx: " + Ctx.name);
            int digits = 15;
            int n = 8;

            var A = Ctx.mat_random(n, n);
            A.Print("A: ", digits);

            var b = Ctx.mat_random(n, n);
            b.Print("B: ", digits);

            var X = A.Solve(b);
            X.Print("X: ", digits);

            var b2 = A * X;
            b2.Print("b2: ", digits);

            var Diff = b - b2;
            Diff.Print("Diff: ", digits);
        }







        public static void DemoAnyMatLDLTCtx()
        {
            Console.WriteLine("DemoAnyMatLDLTCtx: " + Ctx.name);
            int digits = 15;
            int n = 4;
            int f = n;

            var A = Ctx.mat_random_selfadjoint(n);
            A.Print("A: ", digits);
            var b1 = Ctx.mat_random(n, 1);
            b1.Print("B: ", digits);

            var res = A.LDLT("info, rcond, ispos, isneg, l, u, d, p, x, inverse", b1);

            Console.WriteLine("info: {0}", res["info"][0, 0]);
            Console.WriteLine("rcond: {0}", res["rcond"][0, 0]);
            Console.WriteLine("ispos: {0}", res["ispos"][0, 0]);
            Console.WriteLine("isneg: {0}", res["isneg"][0, 0]);

            var L1 = res["l"];
            var U1 = res["u"];
            var D1 = res["d"];
            var P1 = res["p"];
            P1.Transpose().Print("P^T: ", digits);
            L1.Print("L: ", digits);
            D1.Print("D: ", digits);
            U1.Print("U: ", digits);
            P1.Print("P: ", digits);
            var Diff = A - P1.Transpose() * L1 * D1 * U1 * P1;
            Diff.Print("A - P^T * L * D * U * P: ", digits);

            var inv1 = res["inverse"];
            inv1.Print("inv: ", digits);
            Diff = A * inv1;
            Diff.Print("A * inv: ", digits);

            var x1 = res["x"];
            x1.Print("x: ", digits);
            var b2 = A * x1;
            b2.Print("b2 = A * x: ", digits);

            Diff = b1 - b2;
            Diff.Print("Diff = b2 - b: ", digits);
        }







        public static void DemoAnyMatPartialPivLUCtx()
        {
            Console.WriteLine("DemoAnyMatPartialPivLUCtx: " + Ctx.name);
            int digits = 15;
            int m = 5;
            int n = 5;

            var A = Ctx.mat_random(n, m);
            A.Print("A: ", digits);
            var b1 = Ctx.mat_random(n, 1);
            b1.Print("B: ", digits);

            var res = A.PartialPivLU("rcond, lu, p, det, x, inverse", b1);

            Console.WriteLine("det1: {0}", res["det"][0, 0]);
            // Console.WriteLine("det2: {0}", A.Det()(0, 0))

            Console.WriteLine("rcond1: {0}", res["rcond"][0, 0]);
            // Console.WriteLine("rcond2: {0}", A.Rcond()(0, 0))

            var LU1 = res["lu"];
            var P1 = res["p"];
            LU1.Print("LU: ", digits);
            P1.Print("P: ", digits);

            var inv1 = res["inverse"];
            inv1.Print("inv1: ", digits);

            var inv2 = A.Inverse();
            inv2.Print("inv2: ", digits);

            var Diff = A * inv1;
            Diff.Print("A * inv: ", digits);

            var x1 = res["x"];
            x1.Print("x1: ", digits);

            var x2 = A.Solve(b1);
            x2.Print("x2: ", digits);

            var b2 = A * x1;
            b2.Print("b2 = A * x: ", digits);

            Diff = b1 - b2;
            Diff.Print("Diff = b2 - b: ", digits);
        }






        public static void DemoAnyMatFullPivLUCtx()
        {
            Console.WriteLine("DemoAnyMatFullPivLUCtx: " + Ctx.name);
            int digits = 15;
            int m = 5;
            int n = 5;

            var A = Ctx.mat_random(n, m);
            A.Print("A: ", digits);
            var b1 = Ctx.mat_random(n, 1);
            b1.Print("B: ", digits);

            var res = A.FullPivLU("rcond, lu, p, q, isinjective, isinvertible, issurjective, det, x, inverse", b1);

            Console.WriteLine("det: {0}", res["det"][0, 0]);
            Console.WriteLine("rcond: {0}", res["rcond"][0, 0]);
            Console.WriteLine("isinjective: {0}", res["isinjective"][0, 0]);
            Console.WriteLine("isinvertible: {0}", res["isinvertible"][0, 0]);
            Console.WriteLine("issurjective: {0}", res["issurjective"][0, 0]);

            var LU1 = res["lu"];
            var P1 = res["p"];
            var Q1 = res["q"];
            LU1.Print("LU: ", digits);
            P1.Print("P: ", digits);
            Q1.Print("Q: ", digits);

            var inv1 = res["inverse"];
            inv1.Print("inv: ", digits);
            var Diff = A * inv1;
            Diff.Print("A * inv: ", digits);

            var x1 = res["x"];
            x1.Print("x: ", digits);
            var b2 = A * x1;
            b2.Print("b2 = A * x: ", digits);

            Diff = b1 - b2;
            Diff.Print("Diff = b2 - b: ", digits);
        }






        public static void DemoAnyMatLLTCtx()
        {
            Console.WriteLine("DemoAnyMatLLTCtx: " + Ctx.name);
            int digits = 15;
            int n = 4;

            var A = Ctx.mat_random_selfadjoint_posdef(n);
            A.Print("A: ", digits);
            var b1 = Ctx.mat_random(n, 1);
            b1.Print("B: ", digits);

            var res = A.LLT("info, rcond, X, L, U, Inverse", b1);

            Console.WriteLine("info: {0}", res["info"][0, 0]);
            Console.WriteLine("rcond: {0}", res["rcond"][0, 0]);

            var x1 = res["X"];
            x1.Print("X: ", digits);
            var b2 = A * x1;
            b2.Print("b2 = A * x: ", digits);
            var Diff = b1 - b2;
            Diff.Print("Diff = b2 - b: ", digits);

            var L1 = res["L"];
            var U1 = res["U"];
            L1.Print("L: ", digits);
            U1.Print("U: ", digits);
            Diff = A - L1 * U1;
            Diff.Print("A - L * U: ", digits);

            var inv1 = res["Inverse"];
            inv1.Print("inv: ", digits);
            Diff = A * inv1;
            Diff.Print("A * inv: ", digits);
        }





        public static void DemoAnyMatHouseholderQRCtx()
        {
            Console.WriteLine("Hello DemoAnyMatHouseholderQRCtx: " + Ctx.name);
            int digits = 15;
            int n = 4;

            var A = Ctx.mat_random(n, n);
            A.Print("A: ", digits);
            var b1 = Ctx.mat_random(n, 1);
            b1.Print("B: ", digits);

            var res = A.HouseholderQR("qr, absdet, logabsdet, x, inverse", b1);

            Console.WriteLine("absdet: {0}", res["absdet"][0, 0]);
            Console.WriteLine("logabsdet: {0}", res["logabsdet"][0, 0]);

            var QR1 = res["qr"];
            QR1.Print("QR: ", digits);

            var inv1 = res["inverse"];
            inv1.Print("inv: ", digits);
            var Diff = A * inv1;
            Diff.Print("A * inv: ", digits);

            var x1 = res["x"];
            x1.Print("x: ", digits);
            var b2 = A * x1;
            b2.Print("b2 = A * x: ", digits);

            Diff = b1 - b2;
            Diff.Print("Diff = b2 - b: ", digits);
        }







        public static void DemoAnyMatColPivHouseholderQRCtx()
        {
            Console.WriteLine("DemoAnyMatColPivHouseholderQRCtx: " + Ctx.name);
            int digits = 15;
            int m = 5;
            int n = 5;

            var A = Ctx.mat_random(n, m);
            A.Print("A: ", digits);
            var b1 = Ctx.mat_random(n, 1);
            b1.Print("B: ", digits);

            var res = A.ColPivHouseholderQR("info, dimofkernel, rank, nonzeropivots, isinjective, isinvertible, issurjective, absdet, logabsdet, maxpivot, qr, r, householderq, hqnonzeros, permcols, x, inverse", b1);

            Console.WriteLine("info: {0}", res["info"][0, 0]);
            Console.WriteLine("dimofkernel: {0}", res["dimofkernel"][0, 0]);
            Console.WriteLine("rank: {0}", res["rank"][0, 0]);
            Console.WriteLine("nonzeropivots: {0}", res["nonzeropivots"][0, 0]);

            Console.WriteLine("isinjective: {0}", res["isinjective"][0, 0]);
            Console.WriteLine("isinvertible: {0}", res["isinvertible"][0, 0]);
            Console.WriteLine("issurjective: {0}", res["issurjective"][0, 0]);

            Console.WriteLine("absdet: {0}", res["absdet"][0, 0]);
            Console.WriteLine("logabsdet: {0}", res["logabsdet"][0, 0]);
            Console.WriteLine("maxpivot: {0}", res["maxpivot"][0, 0]);

            var QR1 = res["qr"];
            var R1 = res["r"];
            var householderq = res["householderq"];
            var hqnonzeros = res["hqnonzeros"];
            var permcols = res["permcols"];
            QR1.Print("QR1: ", digits);
            R1.Print("R1: ", digits);
            householderq.Print("householderq: ", digits);
            hqnonzeros.Print("hqnonzeros: ", digits);
            permcols.Print("permcols: ", digits);

            var inv1 = res["inverse"];
            inv1.Print("inv: ", digits);
            var Diff = A * inv1;
            Diff.Print("A * inv: ", digits);

            var x1 = res["x"];
            x1.Print("x: ", digits);
            var b2 = A * x1;
            b2.Print("b2 = A * x: ", digits);

            Diff = b1 - b2;
            Diff.Print("Diff = b2 - b: ", digits);
        }





        public static void DemoAnyMatFullPivHouseholderQRCtx()
        {
            Console.WriteLine("DemoAnyMatFullPivHouseholderQRCtx: " + Ctx.name);
            int digits = 15;
            int m = 5;
            int n = 5;

            var A = Ctx.mat_random(n, m);
            A.Print("A: ", digits);
            var b1 = Ctx.mat_random(n, 1);
            b1.Print("B: ", digits);

            var res = A.FullPivHouseholderQR("dimofkernel, rank, nonzeropivots, isinjective, isinvertible, issurjective, absdet, logabsdet, maxpivot, qr, q, permcols, x, inverse", b1);

            Console.WriteLine("dimofkernel: {0}", res["dimofkernel"][0, 0]);
            Console.WriteLine("rank: {0}", res["rank"][0, 0]);
            Console.WriteLine("nonzeropivots: {0}", res["nonzeropivots"][0, 0]);

            Console.WriteLine("isinjective: {0}", res["isinjective"][0, 0]);
            Console.WriteLine("isinvertible: {0}", res["isinvertible"][0, 0]);
            Console.WriteLine("issurjective: {0}", res["issurjective"][0, 0]);

            Console.WriteLine("absdet: {0}", res["absdet"][0, 0]);
            Console.WriteLine("logabsdet: {0}", res["logabsdet"][0, 0]);
            Console.WriteLine("maxpivot: {0}", res["maxpivot"][0, 0]);

            var QR1 = res["qr"];
            var Q1 = res["q"];
            var permcols = res["permcols"];
            QR1.Print("QR1: ", digits);
            Q1.Print("Q1: ", digits);
            permcols.Print("permcols: ", digits);

            var inv1 = res["inverse"];
            inv1.Print("inv: ", digits);
            var Diff = A * inv1;
            Diff.Print("A * inv: ", digits);

            var x1 = res["x"];
            x1.Print("x: ", digits);
            var b2 = A * x1;
            b2.Print("b2 = A * x: ", digits);

            Diff = b1 - b2;
            Diff.Print("Diff = b2 - b: ", digits);
        }





        public static void DemoAnyMatCODCtx()
        {
            Console.WriteLine("DemoAnyMatCODCtx: " + Ctx.name);
            int digits = 15;
            int m = 5;
            int n = 5;

            var A = Ctx.mat_random(n, m);
            A.Print("A: ", digits);
            var b1 = Ctx.mat_random(n, 1);
            b1.Print("B: ", digits);

            var res = A.COD("info, dimofkernel, rank, nonzeropivots, isinjective, isinvertible, issurjective, absdet, logabsdet, maxpivot, qtz, t, z, householderq, hqnonzeros, x, pseudoinverse", b1);

            Console.WriteLine("info: {0}", res["info"][0, 0]);
            Console.WriteLine("dimofkernel: {0}", res["dimofkernel"][0, 0]);
            Console.WriteLine("rank: {0}", res["rank"][0, 0]);
            Console.WriteLine("nonzeropivots: {0}", res["nonzeropivots"][0, 0]);

            Console.WriteLine("isinjective: {0}", res["isinjective"][0, 0]);
            Console.WriteLine("isinvertible: {0}", res["isinvertible"][0, 0]);
            Console.WriteLine("issurjective: {0}", res["issurjective"][0, 0]);

            Console.WriteLine("absdet: {0}", res["absdet"][0, 0]);
            Console.WriteLine("logabsdet: {0}", res["logabsdet"][0, 0]);
            Console.WriteLine("maxpivot: {0}", res["maxpivot"][0, 0]);

            var QTZ1 = res["qtz"];
            var T1 = res["t"];
            var Z1 = res["z"];
            var householderq = res["householderq"];
            var hqnonzeros = res["hqnonzeros"];
            QTZ1.Print("QTZ1: ", digits);
            T1.Print("T1: ", digits);
            Z1.Print("Z1: ", digits);
            householderq.Print("householderq: ", digits);
            hqnonzeros.Print("hqnonzeros: ", digits);

            var inv1 = res["pseudoinverse"];
            inv1.Print("inv: ", digits);
            var Diff = A * inv1;
            Diff.Print("A * inv: ", digits);

            var x1 = res["x"];
            x1.Print("x: ", digits);
            var b2 = A * x1;
            b2.Print("b2 = A * x: ", digits);

            Diff = b1 - b2;
            Diff.Print("Diff = b2 - b: ", digits);
        }









    }
}