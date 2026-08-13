using System;
using System.Diagnostics;


#if HasArbPrecNet
using ArbPrecNet;
#endif

//using Ctx = FixedPrecNet.sreal;
//using Ctx = FixedPrecNet.dreal;
//using Ctx = FixedPrecNet.ereal;
//using Ctx = FixedPrecNet.qreal;
//using Ctx = FixedPrecNet.oreal;

#if HasArbPrecNet
using Ctx = ArbPrecNet.mreal;
#endif




namespace TestXlCalcNetPrecCS
{



    static partial class Tests
    {

        public static void RunTestsFpRealMainMat()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(18);
#endif
            DemoAnyMatPseudoEigenSystemCtx(); GC.Collect();
            DemoAnyMatRealQZCtx(); GC.Collect();
            DemoAnyMatGeneralizedEigenValuesCtx(); GC.Collect();
            DemoAnyMatGeneralizedEigenSystemCtx(); GC.Collect();
        }





        public static void MatFpReal()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            RunTestsFpRealMainMat();

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






        public static void DemoAnyMatPseudoEigenSystemCtx()
        {
            Console.WriteLine("DemoAnyMatPseudoEigenSystemCtx: " + Ctx.name);
            int digits = 15;
            int n = 4;
            var A = Ctx.mat_random(n, n);
            A.Print("A: ", digits);

            var res = A.PseudoEigenSystem("pseudoeval, pseudoevec");

            var D = res["pseudoeval"];
            var V = res["pseudoevec"];
            D.Print("D: (PseudoEigenvalueMatrix)", digits);
            V.Print("V: (PseudoEigenvectors)", digits);

            Console.WriteLine("");
            Console.WriteLine("Check Eigensystem: A * V = V * D");
            var AV = A * V;
            AV.Print("AV = A * V : ", digits);
            var VD = V * D;
            VD.Print("VD = V * D : ", digits);
            var Diff = AV - VD;
            Diff.Print("Diff  = AV - VD : ", digits);
        }




        public static void DemoAnyMatRealQZCtx()
        {
            Console.WriteLine("DemoAnyMatRealQZCtx: " + Ctx.name);
            int digits = 15;
            int n = 4;
            var A = Ctx.mat_random(n, n);
            A.Print("A: ", digits);
            var B = Ctx.mat_random(n, n);
            B.Print("B: ", digits);

            var res = A.RealQZ("s, t, q, z", B);

            var S1 = res["s"];
            var T1 = res["t"];
            var Q1 = res["q"];
            var Z1 = res["z"];
            S1.Print("S: ", digits);
            T1.Print("T: ", digits);
            Q1.Print("Q: ", digits);
            Z1.Print("Z: ", digits);
        }





        public static void DemoAnyMatGeneralizedEigenValuesCtx()
        {
            Console.WriteLine("DemoAnyMatGeneralizedEigenValuesCtx: " + Ctx.name);
            int digits = 15;
            int n = 10;

            var A = Ctx.mat_random(n, n);
            A.Print("A (real general square): ", digits);
            var B = Ctx.mat_random(n, n);
            B.Print("B (real general square): ", digits);

            var res = A.GenEigenSystem("eval, evec", B);
            var Lambda = res["eval"];
            Lambda.Print("Lambda: (Eigenvalues)", digits);

            // det(A - lambda * B) = 0
            // see https://en.wikipedia.org/wiki/Eigendecomposition_of_a_matrix#Useful_facts_regarding_eigenvalues

            Console.WriteLine("");
            Console.WriteLine("Check per Eigenvalue: Det(A - lambda{0} * B) = 0");
            for (int i = 0, loopTo = n - 1; i <= loopTo; i++)
            {
                var X = A - Lambda[i] * B;
                var d = X.Det();
                Console.WriteLine("Det(A - Lambda(i) * B): {1}", i, d);
            }
        }





        public static void DemoAnyMatGeneralizedEigenSystemCtx()
        {
            Console.WriteLine("Hello DemoAnyMatGeneralizedEigenSystem!");
            int digits = 15;
            int n = 10;

            var A = Ctx.mat_random(n, n);
            A.Print("A (real general square): ", digits);
            var B = Ctx.mat_random(n, n);
            B.Print("B (real general square): ", digits);

            var res = A.GenEigenSystem("eval, evec", B);

            var Lambda = res["eval"];
            Lambda.Print("Lambda: (Eigenvalues)", digits);

            // det(A - lambda * B) = 0
            // see https://en.wikipedia.org/wiki/Eigendecomposition_of_a_matrix#Useful_facts_regarding_eigenvalues

            Console.WriteLine("");
            Console.WriteLine("Check per Eigenvalue: Det(A - lambda{0} * B) = 0");
            for (int i = 0, loopTo = n - 1; i <= loopTo; i++)
            {
                var X = A - Lambda[i] * B;
                var d = X.Det();
                Console.WriteLine("Det(A - Lambda(i) * B): {1}", i, d);
            }

            Console.WriteLine("");
            var V = res["evec"];
            V.Print("Eigenvectors: ", digits);
            for (int i = 0, loopTo1 = n - 1; i <= loopTo1; i++)
            {
                var X = A * V.get_Col(i) - Lambda[i] * B * V.get_Col(i);
                X.Print("A * V(i) - Lambda(i) * B * V(i) ", digits);
            }
        }











    }
}