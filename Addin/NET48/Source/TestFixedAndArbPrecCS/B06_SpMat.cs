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
using Ctx = ArbPrecNet.mreal;
//using Ctx = ArbPrecNet.mcplx;
//using Ctx = ArbPrecNet.aflint;
//using Ctx = ArbPrecNet.aflintc;
#endif



namespace TestXlCalcNetPrecCS
{

    static partial class Tests
    {


        public static void RunTestsSparseMatrix()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(18);
#endif
            DemoCtxSparseMat();
            DemoCtxSparseSolve();
        }





        public static void SparseMatrix()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            RunTestsSparseMatrix();
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




        public static void DemoCtxSparseMat()
        {
            Console.WriteLine("DemoSparseMat: " + Ctx.name);

            var A = Ctx.mat_random_symmetric(4);
            A.Print("A: ");

            var B = Ctx.mat_random(4, 4);
            B.Print("B: ");

            var bvec = Ctx.mat_random(4, 1);
            bvec.Print("bvec: ");

            var SparseA = A.ToSparse();
            var SparseB = B.ToSparse();

            var C = A * B;
            C.Print("C: ");

            var SparseC = SparseA * SparseB;
            var CfromSparse = SparseC.ToDense();

            CfromSparse.Print("CfromSparse: ");
            SparseC.Print("SparseC: ");

            int n = 4;

            A = Ctx.mat_zeros(n, n);
            for (int i = 0, loopTo = n - 1; i <= loopTo; i++)
            {
                A[i, i] = Ctx.t(1.0d);
                if (i > 0)
                    A[i - 1, i] = Ctx.t(2.0d);
                if (i < n - 1)
                    A[i + 1, i] = Ctx.t(2.0d);
            }
            SparseA = A.ToSparse();
            SparseA.Print("SparseA, No1: ");

            A = Ctx.mat_zeros(n, n);
            for (int i = 0, loopTo1 = n - 1; i <= loopTo1; i++)
            {
                A[i, i] = Ctx.t(1.0d);
                if (i > 0)
                    A[i - 1, i] = Ctx.t(3.0d);
                if (i < n - 1)
                    A[i + 1, i] = Ctx.t(2.0d);
            }
            SparseA = A.ToSparse();
            SparseA.Print("SparseA, No2: ");

        }




        public static void DemoCtxSparseSolve()
        {

            Console.WriteLine("");
            Console.WriteLine("****************************************");
            Console.WriteLine("DemoSparseSolve: " + Ctx.name);

            var A = Ctx.mat_random_selfadjoint_posdef(4);
            A.Print("A: ");

            var bvec = Ctx.mat_random(4, 1);
            bvec.Print("bvec: ");

            var X = A.Solve(bvec);
            X.Print("X: ");

            Console.WriteLine("");
            Console.WriteLine("****************************************");

            var SparseA = A.ToSparse();

            Console.WriteLine("SimplicialLLT_Solver");
            X = SparseA.SimplicialLLT_Solver(bvec);
            X.Print("X: ");


            Console.WriteLine("SimplicialLDLT_Solver");
            X = SparseA.SimplicialLDLT_Solver(bvec);
            X.Print("X: ");


            Console.WriteLine("SparseLU_Solver");
            X = SparseA.SparseLU_Solver(bvec);
            X.Print("X: ");


            Console.WriteLine("SparseQR_Solver");
            X = SparseA.SparseQR_Solver(bvec);
            X.Print("X: ");


            Console.WriteLine("ConjugateGradient_Solver");
            X = SparseA.ConjugateGradient_Solver(bvec);
            X.Print("X: ");


            Console.WriteLine("LeastSquaresConjugateGradient_Solver");
            X = SparseA.LeastSquaresConjugateGradient_Solver(bvec);
            X.Print("X: ");


            Console.WriteLine("BiCGSTAB_Solver");
            X = SparseA.BiCGSTAB_Solver(bvec);
            X.Print("X: ");

        }





    }
}