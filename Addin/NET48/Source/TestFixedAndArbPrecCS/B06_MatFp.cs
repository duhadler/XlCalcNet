using System;
using System.Diagnostics;
using FixedPrecNet;


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
using Ctx = ArbPrecNet.mcplx;
#endif





namespace TestXlCalcNetPrecCS
{

    static partial class Tests
    {

        public static void RunTestsAnyMainMatFp()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(18);
#endif
            DemoAnyJacobiSVDCtx(); GC.Collect();
            DemoAnyJacobiSVDThinCtx(); GC.Collect();
            DemoAnyJacobiSVDFullCtx(); GC.Collect();
            DemoAnyMatHessenbergDecompositionCtx(); GC.Collect();
            DemoAnyMatSchurCtx(); GC.Collect();
            DemoAnyMatTridiagonalizationCtx(); GC.Collect();
            DemoAnyPositiveDefiniteSqrtCtx(); GC.Collect();
            DemoAnySelfAdjointEigenValuesCtx(); GC.Collect();
            DemoAnySelfAdjointEigenSystemCtx(); GC.Collect();
            DemoAnyMatGeneralizedSelfAdjointEigenValuesCtx(); GC.Collect();
            DemoAnyMatGeneralizedSelfAdjointEigenSolverCtx(); GC.Collect();
            DemoAnyMatEigenValuesCtx(); GC.Collect();
            DemoAnyMatEigenSystemCtx(); GC.Collect();
            DemoAnyPolySolveCtx(); GC.Collect();
            DemoAnyMatFFTCtx(); GC.Collect();
            // DemoMatrixFunctions(); GC.Collect();
        }



        public static void MatFp()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            RunTestsAnyMainMatFp();

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





        public static void DemoAnyJacobiSVDCtx()
        {
            Console.WriteLine("DemoAnyJacobiSVDCtx: " + Ctx.name);
            int digits = 15;
            int m = 6;
            int n = 12;

            var A = Ctx.mat_random(n, m);
            A.Print("A: ", digits);
            var b1 = Ctx.mat_random(n, 1);
            b1.Print("B: ", digits);

            var res = A.JacobiSVD("rank, nonzeros, s");

            // Basic information
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Basic information");
            Console.WriteLine("rank: {0}", res["rank"][0, 0]);
            Console.WriteLine("nonzeros: {0}", res["nonzeros"][0, 0]);

            var S0 = res["s"];
            S0.Print("Singular values (descending): ", digits);
        }





        public static void DemoAnyJacobiSVDThinCtx()
        {
            Console.WriteLine("DemoAnyJacobiSVDThinCtx: " + Ctx.name);
            int digits = 15;
            int m = 6;
            int n = 6;
            // Dim n = 12 ' Use this to demonstrate Least Square Solving

            var A = Ctx.mat_random(n, m);
            A.Print("A: ", digits);
            var b1 = Ctx.mat_random(n, 1);
            b1.Print("B: ", digits);

            var res = A.JacobiSvdThin("rank, nonzeros, S, U, V, X, PseudoInverse, SPlus", b1);

            // Basic information
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Basic information");
            Console.WriteLine("rank: {0}", res["rank"][0, 0]);
            Console.WriteLine("nonzeros: {0}", res["nonzeros"][0, 0]);

            var S0 = res["s"];
            var U1 = res["u"];
            var V1 = res["v"];
            S0.Print("Singular values (descending): ", digits);


            // Least square solving
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Least square solving");
            var x1 = res["x"];
            x1.Print("x: ", digits);
            var b2 = A * x1;
            b2.Print("b2 = A * x: ", digits);
            var Diff = b1 - b2;
            Diff.Print("Diff = b2 - b: ", digits);


            // Confirming the validity of the decomposition
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Confirming the validity of the decomposition");
            U1.Print("Matrix U: ", digits);
            V1.Print("Matrix V: ", digits);
            var A1 = U1 * S0.AsDiagonal() * V1.Adjoint();
            A1.Print("A1 = U * S * V^T: ", digits);
            var F = A - A1;
            F.Print("Diff: A - A1: ", digits);


            // Confirming properties of the pseudoinverse
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Confirming properties of the pseudoinverse");
            var SPlus = +S0;
            for (int i = 0, loopTo = S0.rows - 1; i <= loopTo; i++)
            {
                if (S0[i] != Ctx.zero())
                    SPlus[i] = Ctx.one() / S0[i];
                else
                    SPlus[i] = Ctx.zero();
            }
            var Pinv = V1 * SPlus.AsDiagonal() * U1.Adjoint();
            Pinv.Print("Pinv = V * SPlus * U^T: ", digits);
            A1 = A - A * Pinv * A;
            A1.Print("A1 = A - A * Pinv * A: ", digits);


            // Confirming relationship to eigenvalues
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Confirming relationship to eigenvalues");
            var C = +A;
            if (n > m)
            {
                C = A.Adjoint() * A;
                C.Print("C = A^H * A : ", digits);
            }
            else
            {
                C = A * A.Adjoint();
                C.Print("C = A * A^H: ", digits);
            }

            var es = C.SelfAdjointEigenSystem("eval");

            var D = es["eval"];

            D.Print("D = Eigenvalues of A^T * A (ascending): ", digits);
            var E = S0.CwiseProduct(S0);
            E = E.ReverseFull();
            E.Print("E = Square of singular values (ascending): ", digits);
            F = D - E;
            F.Print("Diff: D - E", digits);
        }





        public static void DemoAnyJacobiSVDFullCtx()
        {
            Console.WriteLine("DemoAnyJacobiSVDFullCtx: " + Ctx.name);
            int digits = 15;
            int m = 16;
            int n = 16;

            var A = Ctx.mat_random(n, m);
            A.Print("A: ", digits);
            var b1 = Ctx.mat_random(n, 1);
            b1.Print("B: ", digits);
            var res = A.JacobiSvdFull("rank, nonzeros, S, U, V, X, PseudoInverse, SPlus", b1);

            // Basic information
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Basic information");
            Console.WriteLine("rank: {0}", res["rank"][0, 0]);
            Console.WriteLine("nonzeros: {0}", res["nonzeros"][0, 0]);

            var S0 = res["s"];
            var U1 = res["u"];
            var V1 = res["v"];
            S0.Print("Singular values (descending): ", digits);


            // Least square solving
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Least square solving");
            var x1 = res["x"];
            x1.Print("x: ", digits);
            var b2 = A * x1;
            b2.Print("b2 = A * x: ", digits);
            var Diff = b1 - b2;
            Diff.Print("Diff = b2 - b: ", digits);


            // Confirming the validity of the decomposition
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Confirming the validity of the decomposition");
            U1.Print("Matrix U: ", digits);
            V1.Print("Matrix V: ", digits);
            var A1 = U1 * S0.AsDiagonal() * V1.Adjoint();
            A1.Print("A1 = U * S * V^T: ", digits);
            var F = A - A1;
            F.Print("Diff: A - A1: ", digits);


            // Confirming properties of the pseudoinverse
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Confirming properties of the pseudoinverse");
            var SPlus = +S0;
            for (int i = 0, loopTo = S0.rows - 1; i <= loopTo; i++)
            {
                if (S0[i] != Ctx.zero())
                    SPlus[i] = Ctx.one() / S0[i];
                else
                    SPlus[i] = Ctx.zero();
            }
            var Pinv = V1 * SPlus.AsDiagonal() * U1.Adjoint();
            Pinv.Print("Pinv = V * SPlus * U^T: ", digits);
            A1 = A - A * Pinv * A;
            A1.Print("A1 = A - A * Pinv * A: ", digits);


            // Confirming relationship to eigenvalues
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Confirming relationship to eigenvalues");
            var C = A;
            if (n > m)
            {
                C = A.Adjoint() * A;
                C.Print("C = A^H * A : ", digits);
            }
            else
            {
                C = A * A.Adjoint();
                C.Print("C = A * A^H: ", digits);
            }

            var es = C.SelfAdjointEigenSystem("eval");

            var D = es["eval"];

            D.Print("D = Eigenvalues of A^T * A (ascending): ", digits);
            var E = S0.CwiseProduct(S0);
            E = E.ReverseFull();
            E.Print("E = Square of singular values (ascending): ", digits);
            F = D - E;
            F.Print("Diff: D - E", digits);
        }





        public static void DemoAnyMatHessenbergDecompositionCtx()
        {
            Console.WriteLine("DemoAnyMatHessenbergDecompositionCtx: " + Ctx.name);
            int digits = 15;
            int n = 14;
            var A = Ctx.mat_random(n, n);
            A.Print("A: ", digits);

            var res = A.Hessenberg("h, q, hcoeff, packed");

            var H1 = res["h"];
            H1.Print("H1: ", digits);
            var Q1 = res["q"];
            Q1.Print("Q1: ", digits);
            var hcoeff = res["hcoeff"];
            hcoeff.Print("hcoeff: ", digits);
            var packed = res["packed"];
            packed.Print("packed: ", digits);
        }




        public static void DemoAnyMatSchurCtx()
        {
            Console.WriteLine("DemoAnyMatSchurCtx: " + Ctx.name);
            int digits = 15;
            int n = 14;
            var A = Ctx.mat_random(n, n);
            A.Print("A: ", digits);

            var res = A.Schur("u, t");

            var U1 = res["u"];
            U1.Print("U1: ", digits);
            var T1 = res["t"];
            T1.Print("T1: ", digits);
        }





        public static void DemoAnyMatTridiagonalizationCtx()
        {
            Console.WriteLine("DemoAnyMatTridiagonalizationCtx: " + Ctx.name);
            int digits = 15;
            int n = 8;
            var A = Ctx.mat_random_selfadjoint(n);

            A.Print("A: ", digits);

            var res = A.Tridiag("q, t, packed, hcoeff, diag, subdiag");

            var Q1 = res["q"];
            Q1.Print("Q1: ", digits);
            var T1 = res["t"];
            T1.Print("T1: ", digits);
            var packed = res["packed"];
            packed.Print("packed: ", digits);
            var hcoeff = res["hcoeff"];
            hcoeff.Print("hcoeff: ", digits);
            var diag = res["diag"];
            diag.Print("diag: ", digits);
            var subdiag = res["subdiag"];
            subdiag.Print("subdiag: ", digits);

            var I_n = Ctx.mat_ones(n, 1);

            var evaltridiag = diag.SelfAdjointEigenValuesFromTridiag("eval", subdiag);

            var Lambda = evaltridiag["eval"];
            Lambda.Print("Lambda: (Eigenvalues)", digits);

            Console.WriteLine("");
            Console.WriteLine("Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0");

            var X = +A; // need a deep copy
            for (int i = 0, loopTo = n - 1; i <= loopTo; i++)
            {
                // X.Diagonal = A.Diagonal - (I_n * Lambda(i))
                X.set_Diagonal(0, A.get_Diagonal(0) - I_n * Lambda[i]);
                var d = X.Det();
                Console.WriteLine("Det(A - lambda{0} * I_n): {1}", i, d);
            }
        }




        public static void DemoAnyPositiveDefiniteSqrtCtx()
        {
            Console.WriteLine("DemoAnyPositiveDefiniteSqrtCtx: " + Ctx.name);
            int digits = 15;
            int n = 4;
            var I_n = Ctx.mat_ones(n, 1);

            // To demonstrate sqrt, we need the matrix to be positive semidefinite

            var A = Ctx.mat_random_selfadjoint_posdef(n);
            A.Print("A: ", digits);

            // Dim res = FprMat.SelfAdjointEigenSystem("invsqrt, sqrt", A)

            var res = A.SelfAdjointEigenSystem("invsqrt, sqrt");

            var invsqrtA = res["invsqrt"];
            var sqrtA = res["sqrt"];

            invsqrtA.Print("invsqrtA: ", digits);
            sqrtA.Print("sqrtA: ", digits);

            var A1 = sqrtA * sqrtA;
            A1.Print("A1 = sqrtA * sqrtA : ", digits);

            var I1 = sqrtA * invsqrtA;
            I1.Print("I1 = sqrtA * invsqrtA : ", digits);

            Console.WriteLine("");
            Console.WriteLine("");
        }



        public static void DemoAnySelfAdjointEigenValuesCtx()
        {
            Console.WriteLine("DemoAnySelfAdjointEigenValuesCtx: " + Ctx.name);
            int digits = 15;
            int n = 4;
            var I_n = Ctx.mat_ones(n, 1);
            var A = Ctx.mat_random_selfadjoint(n);
            A.Print("A: ", digits);

            var res = A.SelfAdjointEigenValues("eval");

            var Lambda = res["eval"];
            Lambda.Print("Lambda: (Eigenvalues)", digits);

            Console.WriteLine("");
            Console.WriteLine("Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0");
            var X = +A; // need a deep copy
            for (int i = 0, loopTo = n - 1; i <= loopTo; i++)
            {
                // X.Diagonal = A.Diagonal - (I_n * Lambda(i))
                X.set_Diagonal(0, A.get_Diagonal(0) - I_n * Lambda[i]);
                var d = X.Det();
                Console.WriteLine("Det(A - lambda{0} * I_n): {1}", i, d);
            }
        }






        public static void DemoAnySelfAdjointEigenSystemCtx()
        {
            Console.WriteLine("DemoAnySelfAdjointEigenSystemCtx: " + Ctx.name);
            int digits = 15;
            int n = 4;
            var I_n = Ctx.mat_ones(n, 1);
            var A = Ctx.mat_random_selfadjoint(n);
            A.Print("A: ", digits);

            var res = A.SelfAdjointEigenSystem("eval, evec");

            var Lambda = res["eval"];
            var V = res["evec"];
            Lambda.Print("Lambda: (Eigenvalues)", digits);
            V.Print("V: (Eigenvectors)", digits);

            var A1 = V * Lambda.AsDiagonal() * V.Inverse();
            Console.WriteLine("");
            Console.WriteLine("Check Eigensystem: V * D * V^(-1) = A");
            A1.Print("A1 = V * D * V^(-1): ", digits);

            Console.WriteLine("");
            Console.WriteLine("Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0");
            var X = +A; // need a deep copy
            for (int i = 0, loopTo = n - 1; i <= loopTo; i++)
            {
                // X.Diagonal = A.Diagonal - (I_n * Lambda(i))
                X.set_Diagonal(0, A.get_Diagonal(0) - I_n * Lambda[i]);
                var d = X.Det();
                Console.WriteLine("Det(A - lambda{0} * I_n): {1}", i, d);
            }

            Console.WriteLine("");
            Console.WriteLine("Check per Eigenvector: A * v(i) - lambda * v(i) = 0");
            for (int i = 0, loopTo1 = n - 1; i <= loopTo1; i++)
            {
                // X = A * V.Col(i) - V.Col(i) * Lambda(i)
                X = A * V.get_Col(i) - V.get_Col(i) * Lambda[i];
                X.Print("A * v(i) - lambda * v(i): ", digits);
            }
        }






        public static void DemoAnyMatGeneralizedSelfAdjointEigenValuesCtx()
        {
            Console.WriteLine("DemoAnyMatGeneralizedSelfAdjointEigenValuesCtx: " + Ctx.name);
            int digits = 15;
            int n = 10;

            var A = Ctx.mat_random_selfadjoint(n);
            A.Print("A (real symmetric): ", digits);
            // Dim B = Ctx.Mat.RandomSelfAdjointPosDef(n)
            var B = Ctx.mat_random_selfadjoint_posdef(n);


            B.Print("B (real positive definite): ", digits);

            var res = A.GeneralizedSelfAdjointEigenSolver("eval, evec", B);

            var Lambda = res["eval"];
            var V = res["evec"];
            Lambda.Print("Lambda: (Eigenvalues)", digits);

            // det(A - lambda * B) = 0
            // see https://en.wikipedia.org/wiki/Eigendecomposition_of_a_matrix#Useful_facts_regarding_eigenvalues

            Console.WriteLine("");
            Console.WriteLine("Check per Eigenvalue: Det(A - Lambda(i) * B) = 0");
            for (int i = 0, loopTo = n - 1; i <= loopTo; i++)
            {
                var X = A - Lambda[i] * B;
                var d = X.Det();
                Console.WriteLine("Det(A - Lambda(i) * B): {1}", i, d);
            }
        }






        public static void DemoAnyMatGeneralizedSelfAdjointEigenSolverCtx()
        {
            Console.WriteLine("DemoAnyMatGeneralizedSelfAdjointEigenSolverCtx: " + Ctx.name);
            int digits = 15;
            int n = 10;

            var A = Ctx.mat_random_selfadjoint(n);
            A.Print("A (real symmetric): ", digits);
            var B = Ctx.mat_random_selfadjoint_posdef(n);
            B.Print("B (real symmetric positive definite): ", digits);

            var res = A.GeneralizedSelfAdjointEigenSolver("eval, evec", B);

            var Lambda = res["eval"];
            var V = res["evec"];
            Lambda.Print("Lambda: (Eigenvalues)", digits);

            // det(A - lambda * B) = 0
            // see https://en.wikipedia.org/wiki/Eigendecomposition_of_a_matrix#Useful_facts_regarding_eigenvalues

            Console.WriteLine("");
            Console.WriteLine("Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0");
            for (int i = 0, loopTo = n - 1; i <= loopTo; i++)
            {
                var X = A - Lambda[i] * B;
                var d = X.Det();
                Console.WriteLine("Det(A - Lambda(i) * B): {1}", i, d);
            }

            Console.WriteLine("");
            V.Print("Eigenvectors: ", digits);
            for (int i = 0, loopTo1 = n - 1; i <= loopTo1; i++)
            {
                var X = A * V.get_Col(i) - Lambda[i] * B * V.get_Col(i);
                X.Print("A * V(i) - Lambda(i) * B * V(i) ", digits);
            }
        }






        public static void DemoAnyMatEigenValuesCtx()
        {
            Console.WriteLine("Hello DemoAnyMatEigenValuesCtx: " + Ctx.name);
            int digits = 15;
            int n = 4;
            var I_n = Ctx.mat_ones(n, 1);
            var A = Ctx.mat_random(n, n);
            A.Print("A: ", digits);

            var res = A.EigenValues("eval");
            var Lambda = res["eval"];
            Lambda.Print("Lambda: (Eigenvalues)", digits);

            Console.WriteLine("");
            Console.WriteLine("Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0");

            var X = Ctx.mat_cplx_t(A); // X needs to be complex for both real and complex A
            
            for (int i = 0, loopTo = n - 1; i <= loopTo; i++)
            {
                // X.Diagonal = A.Diagonal - (I_n * Lambda(i))
                X.set_Diagonal(0, A.get_Diagonal(0) - I_n * Lambda[i]);
                var d = X.Det();
                Console.WriteLine("Det(A - lambda{0} * I_n): {1}", i, d);
            }
        }






        public static void DemoAnyMatEigenSystemCtx()
        {
            Console.WriteLine("DemoAnyMatEigenSystemCtx: " + Ctx.name);
            int digits = 15;
            int n = 4;
            var I_n = Ctx.mat_ones(n, 1);
            var A = Ctx.mat_random(n, n);
            A.Print("A: ", digits);

            var res = A.EigenSystem("eval, evec");

            var Lambda = res["eval"];
            var V = res["evec"];
            Lambda.Print("Lambda: (Eigenvalues)", digits);
            V.Print("V: (Eigenvectors)", digits);

            var A1 = V * Lambda.AsDiagonal() * V.Inverse();
            Console.WriteLine("");
            A1.Print("Check Eigensystem: A1 = V * D * V^(-1): ", digits);

            Console.WriteLine("");
            Console.WriteLine("Check per Eigenvalue: Det(A - lambda{0} * I_n) = 0");

            var X = Ctx.mat_cplx_t(A); // X needs to be complex for both real and complex A

            for (int i = 0, loopTo = n - 1; i <= loopTo; i++)
            {
                // X.Diagonal = A.Diagonal - (I_n * Lambda(i))
                X.set_Diagonal(0, A.get_Diagonal(0) - I_n * Lambda[i]);
                var d = X.Det();
                Console.WriteLine("Det(A - lambda{0} * I_n): {1}", i, d);
            }

            Console.WriteLine("");
            Console.WriteLine("Check per Eigenvector: A * v(i) - lambda * v(i) = 0");
            for (int i = 0, loopTo1 = n - 1; i <= loopTo1; i++)
            {
                X = A * V.get_Col(i) - V.get_Col(i) * Lambda[i];
                X.Print("A * v(i) - lambda * v(i): ", digits);
            }
        }




        // Sub DemoMatrixFunctions()
        // Console.WriteLine("Hello DemoSMatrixMatrixFunctions: " + Ctx.name)
        // Dim digits = 15
        // Dim n As Int32 = 4

        // Dim A = Ctx.mat_random_selfadjoint(n)

        // 'Dim A = Ctx.Mat.RandomSelfAdjoint(n)
        // A.Print("A: ")
        // Dim B = A.ExpMat()
        // B.Print("B = Exp(A): ")
        // Dim C = B.LogMat()
        // C.Print("C = Log(B): ")

        // Dim D = B.SqrtMat()
        // D.Print("D = Sqrt(B): ")
        // Dim E = D * D
        // E.Print("E = D * D: ")

        // B = A.SinMat()
        // B.Print("B = Sin(A): ")
        // C = A.CosMat()
        // C.Print("C = Cos(A): ")
        // D = B * B + C * C
        // D.Print("B * B + C * C: ")

        // B = A.SinhMat()
        // B.Print("B = Sinh(A): ")
        // C = A.CoshMat()
        // C.Print("C = Cosh(A): ")
        // D = C * C - B * B
        // D.Print("C * C - B * B: ")

        // Dim res = A.SelfAdjointEigenSystem("eval, evec")
        // Dim Lambda = res("eval")
        // Dim Evec = res("evec")
        // Lambda.Print("Lambda: (Eigenvalues)")
        // Evec.Print("Evec: (Eigenvectors)")
        // Dim LambdaFunc = Ctx.mat_zeros(n, 1)

        // Dim A2 = Evec * Lambda.AsDiagonal * Evec.inverse
        // A2.Print("A2")
        // For i As Integer = 0 To n - 1
        // LambdaFunc(i) = Ctx.exp(Lambda(i))
        // Next i
        // LambdaFunc.Print("exp(Lambda)")
        // Dim A3 = Evec * LambdaFunc.AsDiagonal * Evec.inverse
        // A3.Print("A3")
        // End Sub


        public static void DemoAnyPolySolveCtx()
        {
            Console.WriteLine("Hello DemoAnyPolySolveCtx: " + Ctx.name);

            var roots = Ctx.mat_random(14, 1);
            roots.Print("roots: ", 15);

            var polynomial = roots.RootsToMonicPolynomial();
            polynomial.Print("polynomial: ", 15);

            var evaluations = polynomial.PolyEval(roots);
            evaluations.Print("evaluations: ", 15);

            var cplxroots = polynomial.PolynomialSolver();
            cplxroots.Print("cplxroots: ", 15);

            var cplxevaluations = polynomial.PolyEval(cplxroots);
            cplxevaluations.Print("cplxevaluations: ", 15);
        }







        public static void DemoAnyMatFFTCtx()
        {
            Console.WriteLine("DemoAnyMatFFTCtx: " + Ctx.name);
            int n = 4;

            var A = Ctx.mat_zeros(2 * n, 1);

            var A_real = Ctx.mat_random(n, 1);
            for (int i = 0, loopTo = n - 1; i <= loopTo; i++)
                A[i] = A_real[i];
            A.Print("A: ", 15);

            var B = Ctx.mat_zeros(2 * n, 1);
            var B_real = Ctx.mat_random(n, 1);
            for (int i = 0, loopTo1 = n - 1; i <= loopTo1; i++)
                B[i] = B_real[i];
            B.Print("B: ", 15);

            var TA = A.FFTFwd();
            TA.Print("TA: ", 15);

            var TB = B.FFTFwd();
            TB.Print("TB: ", 15);

            // Dim TC = Ctx.CplxCtx.Mat.Zeros(2 * n, 1)

            var TC = Ctx.mat_cplx_zeros(2 * n, 1);

            for (int i = 0, loopTo2 = 2 * n - 1; i <= loopTo2; i++)
                TC[i] = TA[i] * TB[i];
            TC.Print("TC: ", 15);

            if (Ctx.iscplxctx)
            {
                var C3 = TC.FFTCplxInv();
                C3.Print("C3: ", 15);
            }
            else
            {
                var C2 = TC.FFTRealInv();
                C2.Print("C2: ", 15);
            }

            var C_Real = Ctx.mat_zeros(2 * n, 1);
            for (int i = 0, loopTo3 = n - 1; i <= loopTo3; i++)
            {
                for (int j = 0, loopTo4 = n - 1; j <= loopTo4; j++)
                    C_Real[i + j] = C_Real[i + j] + A_real[i] * B_real[j];
            }
            C_Real.Print("C_Real: ", 15);
        }






    }
}