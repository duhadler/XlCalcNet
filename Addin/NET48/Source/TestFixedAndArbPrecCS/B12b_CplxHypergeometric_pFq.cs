using System;
using System.Numerics;
using System.Diagnostics;
using System.Linq;
using FixedPrecNet;
using System.Xml.Linq;



#if HasArbPrecNet
using ArbPrecNet;
#endif




namespace TestXlCalcNetPrecCS
{

    static partial class Tests
    {



        public static void RunTests_CplxHypergeometric_pFq()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(80);
#endif
            string[] NTA1 = new[] { "cmath53" };
            string[] NTA2 = new[] { "sflintc", "dflintc", "eflintc", "qflintc", "oflintc", "mflintc", "aflintc" };

            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();

            //string[] FunctionArray = new[] { "all" };
            string[] FunctionArray = new[] { "spherical_y" };

            DemoChapterCplxpFq(NumTypeArray, FunctionArray);

        }





        public static void DemoChapterCplxpFq(string[] NumTypeArray, string[] FunctionArray)
        {

            Complex[] InputArray1;
            Complex[] InputArray2;
            Complex[] InputArray3;
            Complex[] InputArray4;

            int[] InputArrayInt1;
            int[] InputArrayInt2;



            #region Gauss Hypergeometric Function 2F1


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_2f1"))
            {
                string name = "hyperg_2f1";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
                InputArray2 = new[] { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray3 = new[] { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray4 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var c in InputArray3)
                        {
                            foreach (var x in InputArray4)
                            {
                                Console.WriteLine();
                                Console.WriteLine(name + "(a={0}, b={1}, c={2}, x={3})", a, b, c, x);
                                foreach (var NumType in NumTypeArray)
                                {
                                    object res1 = "Not done";
                                    switch (NumType ?? "")
                                    {
                                        case "cmath53": { res1 = cmath53.hyperg_2f1(a, b, c, x); break; }
#if HasArbPrecNet
                                        case "sflintc": { res1 = sflintc.hyperg_2f1(a, b, c, x); break; }
                                        case "dflintc": { res1 = dflintc.hyperg_2f1(a, b, c, x); break; }
                                        case "eflintc": { res1 = eflintc.hyperg_2f1(a, b, c, x); break; }
                                        case "qflintc": { res1 = qflintc.hyperg_2f1(a, b, c, x); break; }
                                        case "oflintc": { res1 = oflintc.hyperg_2f1(a, b, c, x); break; }
                                        case "mflintc": { res1 = mflintc.hyperg_2f1(a, b, c, x); break; }
                                        case "aflintc": { res1 = aflintc.hyperg_2f1(a, b, c, x); break; }
#endif
                                    }
                                    Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_2f1r"))
            {
                string name = "hyperg_2f1r";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
                InputArray2 = new[] { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray3 = new[] { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray4 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var c in InputArray3)
                        {
                            foreach (var x in InputArray4)
                            {
                                Console.WriteLine();
                                Console.WriteLine(name + "(a={0}, b={1}, c={2}, x={3})", a, b, c, x);
                                foreach (var NumType in NumTypeArray)
                                {
                                    object res1 = "Not done";
                                    switch (NumType ?? "")
                                    {
                                        case "cmath53": { res1 = cmath53.hyperg_2f1r(a, b, c, x); break; }
#if HasArbPrecNet
                                        case "sflintc": { res1 = sflintc.hyperg_2f1r(a, b, c, x); break; }
                                        case "dflintc": { res1 = dflintc.hyperg_2f1r(a, b, c, x); break; }
                                        case "eflintc": { res1 = eflintc.hyperg_2f1r(a, b, c, x); break; }
                                        case "qflintc": { res1 = qflintc.hyperg_2f1r(a, b, c, x); break; }
                                        case "oflintc": { res1 = oflintc.hyperg_2f1r(a, b, c, x); break; }
                                        case "mflintc": { res1 = mflintc.hyperg_2f1r(a, b, c, x); break; }
                                        case "aflintc": { res1 = aflintc.hyperg_2f1r(a, b, c, x); break; }
#endif
                                    }
                                    Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_2f1rNegC"))
            {
                string name = "hyperg_2f1rNegC";
                int n = 13;
                int m = 7;
                InputArray1 = new[] { dcplx.t(-n) };
                InputArray2 = new[] { dcplx.t(n + 1) };
                InputArray3 = new[] { dcplx.t(1 - m) };
                //InputArray4 = new[] { dcplx.t(-1.5d, 0), dcplx.t(0.0d, 0), dcplx.t(1.5d, 0) };
                InputArray4 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var c in InputArray3)
                        {
                            foreach (var x in InputArray4)
                            {
                                Console.WriteLine();
                                Console.WriteLine(name + "(a={0}, b={1}, c={2}, x={3})", a, b, c, x);
                                foreach (var NumType in NumTypeArray)
                                {
                                    object res1 = "Not done";
                                    switch (NumType ?? "")
                                    {
                                        case "cmath53": { res1 = cmath53.hyperg_2f1r(a, b, c, x); break; }
                                        //case " math53": { res1 = math53.hyperg_2f1r(a.Real, b.Real, c.Real, x.Real); break; }
#if HasArbPrecNet
                                        case "sflintc": { res1 = sflintc.hyperg_2f1r(a, b, c, x); break; }
                                        case "dflintc": { res1 = dflintc.hyperg_2f1r(a, b, c, x); break; }
                                        case "eflintc": { res1 = eflintc.hyperg_2f1r(a, b, c, x); break; }
                                        case "qflintc": { res1 = qflintc.hyperg_2f1r(a, b, c, x); break; }
                                        case "oflintc": { res1 = oflintc.hyperg_2f1r(a, b, c, x); break; }
                                        case "mflintc": { res1 = mflintc.hyperg_2f1r(a, b, c, x); break; }
                                        case "aflintc": { res1 = aflintc.hyperg_2f1r(a, b, c, x); break; }
#endif
                                    }
                                    Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }




            #endregion




            #region Chebyshev, Gegenbauer and Jacobi polynomials


            if (FunctionArray.Contains("all") | FunctionArray.Contains("chebyshev_t"))
            {
                string name = "chebyshev_t";
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { dcplx.t(-0.333d, 2), dcplx.t(0.0d, 2), dcplx.t(0.333d, 2) };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.chebyshev_t(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.chebyshev_t(n, x); break; }
                                case "dflintc": { res1 = dflintc.chebyshev_t(n, x); break; }
                                case "eflintc": { res1 = eflintc.chebyshev_t(n, x); break; }
                                case "qflintc": { res1 = qflintc.chebyshev_t(n, x); break; }
                                case "oflintc": { res1 = oflintc.chebyshev_t(n, x); break; }
                                case "mflintc": { res1 = mflintc.chebyshev_t(n, x); break; }
                                case "aflintc": { res1 = aflintc.chebyshev_t(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("chebyshev_u"))
            {
                string name = "chebyshev_u";
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { dcplx.t(-0.333d, 2), dcplx.t(0.0d, 2), dcplx.t(0.333d, 2) };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.chebyshev_u(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.chebyshev_u(n, x); break; }
                                case "dflintc": { res1 = dflintc.chebyshev_u(n, x); break; }
                                case "eflintc": { res1 = eflintc.chebyshev_u(n, x); break; }
                                case "qflintc": { res1 = qflintc.chebyshev_u(n, x); break; }
                                case "oflintc": { res1 = oflintc.chebyshev_u(n, x); break; }
                                case "mflintc": { res1 = mflintc.chebyshev_u(n, x); break; }
                                case "aflintc": { res1 = aflintc.chebyshev_u(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("chebyshev_v"))
            {
                string name = "chebyshev_v";
                InputArrayInt1 = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                InputArray1 = new[] { dcplx.t(-0.333d, 2), dcplx.t(0.0d, 2), dcplx.t(0.333d, 2) };
                //InputArray1 = new[] { dcplx.t(-0.333d, 0), dcplx.t(0.0d, 0), dcplx.t(0.333d, 0) };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.chebyshev_v(n, x); break; }
#if HasArbPrecNet
                                //case "dflintc": { res1 = math53.chebyshev_v(n, x.Real); break; }
                                case "sflintc": { res1 = sflintc.chebyshev_v(n, x); break; }
                                case "dflintc": { res1 = dflintc.chebyshev_v(n, x); break; }
                                case "eflintc": { res1 = eflintc.chebyshev_v(n, x); break; }
                                case "qflintc": { res1 = qflintc.chebyshev_v(n, x); break; }
                                case "oflintc": { res1 = oflintc.chebyshev_v(n, x); break; }
                                case "mflintc": { res1 = mflintc.chebyshev_v(n, x); break; }
                                case "aflintc": { res1 = aflintc.chebyshev_v(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("chebyshev_w"))
            {
                string name = "chebyshev_w";
                InputArrayInt1 = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                InputArray1 = new[] { dcplx.t(-0.333d, 2), dcplx.t(0.0d, 2), dcplx.t(0.333d, 2) };
                //InputArray1 = new[] { dcplx.t(-0.333d, 0), dcplx.t(0.0d, 0), dcplx.t(0.333d, 0) };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.chebyshev_w(n, x); break; }
#if HasArbPrecNet
                                //case "dflintc": { res1 = math53.chebyshev_w(n, x.Real); break; }
                                case "sflintc": { res1 = sflintc.chebyshev_w(n, x); break; }
                                case "dflintc": { res1 = dflintc.chebyshev_w(n, x); break; }
                                case "eflintc": { res1 = eflintc.chebyshev_w(n, x); break; }
                                case "qflintc": { res1 = qflintc.chebyshev_w(n, x); break; }
                                case "oflintc": { res1 = oflintc.chebyshev_w(n, x); break; }
                                case "mflintc": { res1 = mflintc.chebyshev_w(n, x); break; }
                                case "aflintc": { res1 = aflintc.chebyshev_w(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gegenbauer_c"))
            {
                string name = "gegenbauer_c";
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { dcplx.t(-0.333), 0.0d, 0.333d };
                InputArray2 = new[] { dcplx.t(-0.333d), 0.0d, 0.333d };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var lambda1 in InputArray1)
                    {
                        foreach (var x in InputArray1)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(n={0}, lambda1={1}, x={2})", n, lambda1, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "cmath53": { res1 = cmath53.gegenbauer_c(n, lambda1, x); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.gegenbauer_c(n, lambda1, x); break; }
                                    case "dflintc": { res1 = dflintc.gegenbauer_c(n, lambda1, x); break; }
                                    case "eflintc": { res1 = eflintc.gegenbauer_c(n, lambda1, x); break; }
                                    case "qflintc": { res1 = qflintc.gegenbauer_c(n, lambda1, x); break; }
                                    case "oflintc": { res1 = oflintc.gegenbauer_c(n, lambda1, x); break; }
                                    case "mflintc": { res1 = mflintc.gegenbauer_c(n, lambda1, x); break; }
                                    case "aflintc": { res1 = aflintc.gegenbauer_c(n, lambda1, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_p"))
            {
                string name = "jacobi_p";
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { dcplx.t(-0.333d), 0.0d, 0.333d };
                InputArray2 = new[] { dcplx.t(-0.333d), 0.0d, 0.333d };
                InputArray3 = new[] { dcplx.t(-0.333d), 0.0d, 0.333d };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var alpha in InputArray1)
                    {
                        foreach (var beta in InputArray2)
                        {
                            foreach (var x in InputArray3)
                            {
                                Console.WriteLine();
                                Console.WriteLine(name + "(n={0}, alpha={1}, c={2}, x={3})", n, alpha, beta, x);
                                foreach (var NumType in NumTypeArray)
                                {
                                    object res1 = "Not done";
                                    switch (NumType ?? "")
                                    {
                                        case "cmath53": { res1 = cmath53.jacobi_p(n, alpha, beta, x); break; }
#if HasArbPrecNet
                                        case "sflintc": { res1 = sflintc.jacobi_p(n, alpha, beta, x); break; }
                                        case "dflintc": { res1 = dflintc.jacobi_p(n, alpha, beta, x); break; }
                                        case "eflintc": { res1 = eflintc.jacobi_p(n, alpha, beta, x); break; }
                                        case "qflintc": { res1 = qflintc.jacobi_p(n, alpha, beta, x); break; }
                                        case "oflintc": { res1 = oflintc.jacobi_p(n, alpha, beta, x); break; }
                                        case "mflintc": { res1 = mflintc.jacobi_p(n, alpha, beta, x); break; }
                                        case "aflintc": { res1 = aflintc.jacobi_p(n, alpha, beta, x); break; }
#endif
                                    }
                                    Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion




            #region Legendre polynomials and related


            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_p"))
            {
                string name = "legendre_p";
                InputArrayInt1 = new[] { 7, 9, 13 };  // n > 0
                InputArray1 = new[] { dcplx.t(-0.333d, 0), dcplx.t(0.0d, 0), dcplx.t(0.333d, 0) };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.legendre_p(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.legendre_p(n, x); break; }
                                case "dflintc": { res1 = dflintc.legendre_p(n, x); break; }
                                case "eflintc": { res1 = eflintc.legendre_p(n, x); break; }
                                case "qflintc": { res1 = qflintc.legendre_p(n, x); break; }
                                case "oflintc": { res1 = oflintc.legendre_p(n, x); break; }
                                case "mflintc": { res1 = mflintc.legendre_p(n, x); break; }
                                case "aflintc": { res1 = aflintc.legendre_p(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_plm1"))
            {
                string name = "legendre_plm1";
                InputArrayInt1 = new[] { 7, 9, 13 };  // n > 0
                InputArrayInt2 = new[] { 1, 2, 3, 4, 5, 6 };  // m > 0
                InputArray1 = new[] { dcplx.t(-0.333d, 0), dcplx.t(0.0d, 0), dcplx.t(0.333d, 0) };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var m in InputArrayInt2)
                    {
                        foreach (var x in InputArray1)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(n={0}, m={1}, x={2})", n, m, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "cmath53": { res1 = cmath53.legendre_plm(n, m, x, 1); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.legendre_plm(n, m, x, 1); break; }
                                    case "dflintc": { res1 = dflintc.legendre_plm(n, m, x, 1); break; }
                                    case "eflintc": { res1 = eflintc.legendre_plm(n, m, x, 1); break; }
                                    case "qflintc": { res1 = qflintc.legendre_plm(n, m, x, 1); break; }
                                    case "oflintc": { res1 = oflintc.legendre_plm(n, m, x, 1); break; }
                                    case "mflintc": { res1 = mflintc.legendre_plm(n, m, x, 1); break; }
                                    case "aflintc": { res1 = aflintc.legendre_plm(n, m, x, 1); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_plm2"))
            {
                string name = "legendre_plm2";
                InputArrayInt1 = new[] { 7, 9, 13 };  // n > 0
                InputArrayInt2 = new[] { 1, 2, 3, 4, 5, 6 };  // m > 0
                InputArray1 = new[] { dcplx.t(-0.333d, 2), dcplx.t(0.0d, 2), dcplx.t(0.333d, 2) };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var m in InputArrayInt2)
                    {
                        foreach (var x in InputArray1)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(n={0}, m={1}, x={2})", n, m, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "cmath53": { res1 = cmath53.legendre_plm(n, m, x, 2); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.legendre_plm(n, m, x, 2); break; }
                                    case "dflintc": { res1 = dflintc.legendre_plm(n, m, x, 2); break; }
                                    case "eflintc": { res1 = eflintc.legendre_plm(n, m, x, 2); break; }
                                    case "qflintc": { res1 = qflintc.legendre_plm(n, m, x, 2); break; }
                                    case "oflintc": { res1 = oflintc.legendre_plm(n, m, x, 2); break; }
                                    case "mflintc": { res1 = mflintc.legendre_plm(n, m, x, 2); break; }
                                    case "aflintc": { res1 = aflintc.legendre_plm(n, m, x, 2); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_plm3"))
            {
                string name = "legendre_plm3";

                InputArrayInt1 = new[] { 7, 9, 13 };  // n > 0
                InputArrayInt2 = new[] { 1, 4, 6 };  // m > 0
                InputArray1 = new[] { dcplx.t(-0.333d, 2), dcplx.t(0.0d, 2), dcplx.t(0.333d, 2) };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var m in InputArrayInt2)
                    {
                        foreach (var x in InputArray1)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(n={0}, m={1}, x={2})", n, m, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "cmath53": { res1 = cmath53.legendre_plm(n, m, x, 3); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.legendre_plm(n, m, x, 3); break; }
                                    case "dflintc": { res1 = dflintc.legendre_plm(n, m, x, 3); break; }
                                    case "eflintc": { res1 = eflintc.legendre_plm(n, m, x, 3); break; }
                                    case "qflintc": { res1 = qflintc.legendre_plm(n, m, x, 3); break; }
                                    case "oflintc": { res1 = oflintc.legendre_plm(n, m, x, 3); break; }
                                    case "mflintc": { res1 = mflintc.legendre_plm(n, m, x, 3); break; }
                                    case "aflintc": { res1 = aflintc.legendre_plm(n, m, x, 3); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_q"))
            {
                string name = "legendre_q";
                InputArrayInt1 = new[] { 7, 9, 13 };  // n > 0
                //InputArrayInt2 = new[] { 1, 2, 3, 4, 5, 6 };  // m > 0
                InputArray1 = new[] { dcplx.t(-0.333d, 0), dcplx.t(0.0d, 0), dcplx.t(0.333d, 0) };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.legendre_q(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.legendre_q(n, x); break; }
                                case "dflintc": { res1 = dflintc.legendre_q(n, x); break; }
                                case "eflintc": { res1 = eflintc.legendre_q(n, x); break; }
                                case "qflintc": { res1 = qflintc.legendre_q(n, x); break; }
                                case "oflintc": { res1 = oflintc.legendre_q(n, x); break; }
                                case "mflintc": { res1 = mflintc.legendre_q(n, x); break; }
                                case "aflintc": { res1 = aflintc.legendre_q(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_qlm1"))
            {
                string name = "legendre_qlm1";
                InputArrayInt1 = new[] { 7, 9, 13 };  // n > 0
                InputArrayInt2 = new[] { 1, 4, 6 };  // m > 0
                InputArray1 = new[] { dcplx.t(-1.333, 0), dcplx.t(-0.5, 0), dcplx.t(0.0, 0), dcplx.t(1.333, 0) };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var m in InputArrayInt2)
                    {
                        foreach (var x in InputArray1)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(n={0}, m={1}, x={2})", n, m, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "cmath53": { res1 = cmath53.legendre_qlm(n, m, x, 1); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.legendre_qlm(n, m, x, 1); break; }
                                    case "dflintc": { res1 = dflintc.legendre_qlm(n, m, x, 1); break; }
                                    case "eflintc": { res1 = eflintc.legendre_qlm(n, m, x, 1); break; }
                                    case "qflintc": { res1 = qflintc.legendre_qlm(n, m, x, 1); break; }
                                    case "oflintc": { res1 = oflintc.legendre_qlm(n, m, x, 1); break; }
                                    case "mflintc": { res1 = mflintc.legendre_qlm(n, m, x, 1); break; }
                                    case "aflintc": { res1 = aflintc.legendre_qlm(n, m, x, 1); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_qlm2"))
            {
                string name = "legendre_qlm2";
                InputArrayInt1 = new[] { 7, 9, 13 };  // n > 0
                InputArrayInt2 = new[] { 1, 4, 6 };  // m > 0
                InputArray1 = new[] { dcplx.t(-1.333d, 2), dcplx.t(-0.5, 2), dcplx.t(0.0d, 2), dcplx.t(1.333d, 2) };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var m in InputArrayInt2)
                    {
                        foreach (var x in InputArray1)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(n={0}, m={1}, x={2})", n, m, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "cmath53": { res1 = cmath53.legendre_qlm(n, m, x, 2); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.legendre_qlm(n, m, x, 2); break; }
                                    case "dflintc": { res1 = dflintc.legendre_qlm(n, m, x, 2); break; }
                                    case "eflintc": { res1 = eflintc.legendre_qlm(n, m, x, 2); break; }
                                    case "qflintc": { res1 = qflintc.legendre_qlm(n, m, x, 2); break; }
                                    case "oflintc": { res1 = oflintc.legendre_qlm(n, m, x, 2); break; }
                                    case "mflintc": { res1 = mflintc.legendre_qlm(n, m, x, 2); break; }
                                    case "aflintc": { res1 = aflintc.legendre_qlm(n, m, x, 2); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_qlm3"))
            {
                string name = "legendre_qlm3";
                InputArray1 = new[] { dcplx.t(7), 9, 13 };  // n > 0
                InputArray2 = new[] { dcplx.t(1), 4, 6 };  // m > 0
                //InputArray2 = new[] { dcplx.t(1), 3, 5 };  // m > /*0*/
                InputArray1 = new[] { dcplx.t(7.1), 9.1, 13.1 };  // n > 0
                InputArray2 = new[] { dcplx.t(1.1), 4.1, 6.1 };  // m > 0
                //InputArray3 = new[] { dcplx.t(-0.1, 0), dcplx.t(-0.5, 0), dcplx.t(0.0, 0), dcplx.t(-1.333d, 2), dcplx.t(-0.5, 2), dcplx.t(0.0d, 2), dcplx.t(1.333d, 2) };
                InputArray3 = new[] { 0.5, dcplx.t(0.0, 0.0), -1E-8, 1E-8, 1.5, 0.5 };
                foreach (var n in InputArray1)
                {
                    foreach (var m in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(n={0}, m={1}, x={2})", n, m, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "cmath53": { res1 = cmath53.legendre_qlm(n, m, x, 3); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.legendre_qlm(n, m, x, 3); break; }
                                    case "dflintc": { res1 = dflintc.legendre_qlm(n, m, x, 3); break; }
                                    case "eflintc": { res1 = eflintc.legendre_qlm(n, m, x, 3); break; }
                                    case "qflintc": { res1 = qflintc.legendre_qlm(n, m, x, 3); break; }
                                    case "oflintc": { res1 = oflintc.legendre_qlm(n, m, x, 3); break; }
                                    case "mflintc": { res1 = mflintc.legendre_qlm(n, m, x, 3); break; }
                                    case "aflintc": { res1 = aflintc.legendre_qlm(n, m, x, 3); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }




            if (FunctionArray.Contains("all") | FunctionArray.Contains("spherical_y"))
            {
                string name = "spherical_y";
                InputArrayInt1 = new[] { 7, 9, 13 };  // n > 0
                InputArrayInt2 = new[] { 1, 4, 6 };  // m > 0
                InputArray1 = new[] { dcplx.t(0.01,2), 0.5d, 1.0d - 0.001d };  // 0.0 < theta < 1.0
                InputArray2 = new[] { dcplx.t(0.01,2), 0.5d, 1.0d - 0.001d };  // 0.0 < phi < 1.0
                foreach (var n in InputArrayInt1)
                {
                    foreach (var m in InputArrayInt2)
                    {
                        foreach (var theta in InputArray1)
                        {
                            foreach (var phi in InputArray2)
                            {
                                Console.WriteLine();
                                Console.WriteLine(name + "(n={0}, m={1}, theta={2}, phi={3})", n, m, theta, phi);
                                foreach (var NumType in NumTypeArray)
                                {
                                    object res1 = "Not done";
                                    switch (NumType ?? "")
                                    {
                                        //case "cmath53": { res1 = math53.spherical_harmonic_r(n, m, theta, phi); break; }
#if HasArbPrecNet
                                        case "sflintc": { res1 = sflintc.spherical_y(n, m, theta, phi); break; }
                                        case "dflintc": { res1 = dflintc.spherical_y(n, m, theta, phi); break; }
                                        case "eflintc": { res1 = eflintc.spherical_y(n, m, theta, phi); break; }
                                        case "qflintc": { res1 = qflintc.spherical_y(n, m, theta, phi); break; }
                                        case "oflintc": { res1 = oflintc.spherical_y(n, m, theta, phi); break; }
                                        case "mflintc": { res1 = mflintc.spherical_y(n, m, theta, phi); break; }
                                        case "aflintc": { res1 = aflintc.spherical_y(n, m, theta, phi); break; }
#endif
                                    }
                                    Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion




            #region Incomplete beta function



            if (FunctionArray.Contains("all") | FunctionArray.Contains("beta_lower"))
            {
                string name = "beta_lower";
                InputArray1 = new[] { dcplx.t(1.5), 2.5d, 13.5d };
                InputArray2 = new[] { dcplx.t(2.1), 12.1d, 53.5d };
                InputArray3 = new[] { dcplx.t(0.01), 0.5d, 1.0d - 0.001d };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(a={0}, b={1}, x={2})", a, b, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "cmath53": { res1 = cmath53.beta_lower(a, b, x); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.beta_lower(a, b, x); break; }
                                    case "dflintc": { res1 = dflintc.beta_lower(a, b, x); break; }
                                    case "eflintc": { res1 = eflintc.beta_lower(a, b, x); break; }
                                    case "qflintc": { res1 = qflintc.beta_lower(a, b, x); break; }
                                    case "oflintc": { res1 = oflintc.beta_lower(a, b, x); break; }
                                    case "mflintc": { res1 = mflintc.beta_lower(a, b, x); break; }
                                    case "aflintc": { res1 = aflintc.beta_lower(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ibeta"))
            {
                string name = "ibeta";
                InputArray1 = new[] { dcplx.t(1.5), 2.5d, 13.5d };
                InputArray2 = new[] { dcplx.t(2.1), 12.1d, 53.5d };
                InputArray3 = new[] { dcplx.t(0.01), 0.5d, 1.0d - 0.001d };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(a={0}, b={1}, x={2})", a, b, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "cmath53": { res1 = cmath53.ibeta(a, b, x); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.ibeta(a, b, x); break; }
                                    case "dflintc": { res1 = dflintc.ibeta(a, b, x); break; }
                                    case "eflintc": { res1 = eflintc.ibeta(a, b, x); break; }
                                    case "qflintc": { res1 = qflintc.ibeta(a, b, x); break; }
                                    case "oflintc": { res1 = oflintc.ibeta(a, b, x); break; }
                                    case "mflintc": { res1 = mflintc.ibeta(a, b, x); break; }
                                    case "aflintc": { res1 = aflintc.ibeta(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ibeta_prime"))
            {
                string name = "ibeta_prime";
                InputArray1 = new[] { dcplx.t(1.5), 2.5d, 13.5d };
                InputArray2 = new[] { dcplx.t(2.1), 12.1d, 53.5d };
                InputArray3 = new[] { dcplx.t(0.01), 0.5d, 1.0d - 0.001d };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(a={0}, b={1}, x={2})", a, b, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "cmath53": { res1 = cmath53.ibeta_prime(a, b, x); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.ibeta_prime(a, b, x); break; }
                                    case "dflintc": { res1 = dflintc.ibeta_prime(a, b, x); break; }
                                    case "eflintc": { res1 = eflintc.ibeta_prime(a, b, x); break; }
                                    case "qflintc": { res1 = qflintc.ibeta_prime(a, b, x); break; }
                                    case "oflintc": { res1 = oflintc.ibeta_prime(a, b, x); break; }
                                    case "mflintc": { res1 = mflintc.ibeta_prime(a, b, x); break; }
                                    case "aflintc": { res1 = aflintc.ibeta_prime(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }




            #endregion




            #region Hypergeometric Function 1F2


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_1f2"))
            {
                string name = "hyperg_1f2";
                InputArray1 = new[] { 1.5d, 2.5d, 3.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2) };
                InputArray2 = new[] { 5.000000001d, 12.1d, 53.5d, dcplx.t(5.1d, 2), dcplx.t(12.1d, 2) };
                InputArray3 = new[] { 5.000000001d, 12.1d, 53.5d, dcplx.t(5.1d, 2), dcplx.t(12.1d, 2) };
                InputArray4 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var a in InputArray1)
                {
                    foreach (var b1 in InputArray2)
                    {
                        foreach (var b2 in InputArray2)
                        {
                            foreach (var x in InputArray4)
                            {
                                Console.WriteLine();
                                Console.WriteLine(name + "(a={0}, b1={1}, b2={2}, x={3})", a, b1, b2, x);
                                foreach (var NumType in NumTypeArray)
                                {
                                    object res1 = "Not done";
                                    switch (NumType ?? "")
                                    {
                                        case "cmath53": { res1 = cmath53.hyperg_1f2(a, b1, b2, x); break; }
#if HasArbPrecNet
                                        case "sflintc": { res1 = sflintc.hyperg_1f2(a, b1, b2, x); break; }
                                        case "dflintc": { res1 = dflintc.hyperg_1f2(a, b1, b2, x); break; }
                                        case "eflintc": { res1 = eflintc.hyperg_1f2(a, b1, b2, x); break; }
                                        case "qflintc": { res1 = qflintc.hyperg_1f2(a, b1, b2, x); break; }
                                        case "oflintc": { res1 = oflintc.hyperg_1f2(a, b1, b2, x); break; }
                                        case "mflintc": { res1 = mflintc.hyperg_1f2(a, b1, b2, x); break; }
                                        case "aflintc": { res1 = aflintc.hyperg_1f2(a, b1, b2, x); break; }
#endif
                                    }
                                    Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_1f2r"))
            {
                string name = "hyperg_1f2r";
                InputArray1 = new[] { 1.5d, 2.5d, 3.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2) };
                InputArray2 = new[] { 5.000000001d, 12.1d, 53.5d, dcplx.t(5.1d, 2), dcplx.t(12.1d, 2) };
                InputArray3 = new[] { 5.000000001d, 12.1d, 53.5d, dcplx.t(5.1d, 2), dcplx.t(12.1d, 2) };
                InputArray4 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var a in InputArray1)
                {
                    foreach (var b1 in InputArray2)
                    {
                        foreach (var b2 in InputArray2)
                        {
                            foreach (var x in InputArray4)
                            {
                                Console.WriteLine();
                                Console.WriteLine(name + "(a={0}, b1={1}, b2={2}, x={3})", a, b1, b2, x);
                                foreach (var NumType in NumTypeArray)
                                {
                                    object res1 = "Not done";
                                    switch (NumType ?? "")
                                    {
                                        case "cmath53": { res1 = cmath53.hyperg_1f2r(a, b1, b2, x); break; }
#if HasArbPrecNet
                                        case "sflintc": { res1 = sflintc.hyperg_1f2r(a, b1, b2, x); break; }
                                        case "dflintc": { res1 = dflintc.hyperg_1f2r(a, b1, b2, x); break; }
                                        case "eflintc": { res1 = eflintc.hyperg_1f2r(a, b1, b2, x); break; }
                                        case "qflintc": { res1 = qflintc.hyperg_1f2r(a, b1, b2, x); break; }
                                        case "oflintc": { res1 = oflintc.hyperg_1f2r(a, b1, b2, x); break; }
                                        case "mflintc": { res1 = mflintc.hyperg_1f2r(a, b1, b2, x); break; }
                                        case "aflintc": { res1 = aflintc.hyperg_1f2r(a, b1, b2, x); break; }
#endif
                                    }
                                    Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion




            #region Scorer functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_gi"))
            {
                string name = "airy_gi";
                InputArray1 = new[] { dcplx.t(-10.0d, 2), dcplx.t(-2.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x1={0})", x1);

                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.airy_gi(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.airy_gi(x1); break; }
                            case "dflintc": { res1 = dflintc.airy_gi(x1); break; }
                            case "eflintc": { res1 = eflintc.airy_gi(x1); break; }
                            case "qflintc": { res1 = qflintc.airy_gi(x1); break; }
                            case "oflintc": { res1 = oflintc.airy_gi(x1); break; }
                            case "mflintc": { res1 = mflintc.airy_gi(x1); break; }
                            case "aflintc": { res1 = aflintc.airy_gi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_hi"))
            {
                string name = "airy_hi";
                InputArray1 = new[] { dcplx.t(-10.0d, 2), dcplx.t(-2.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x1={0})", x1);

                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.airy_hi(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.airy_hi(x1); break; }
                            case "dflintc": { res1 = dflintc.airy_hi(x1); break; }
                            case "eflintc": { res1 = eflintc.airy_hi(x1); break; }
                            case "qflintc": { res1 = qflintc.airy_hi(x1); break; }
                            case "oflintc": { res1 = oflintc.airy_hi(x1); break; }
                            case "mflintc": { res1 = mflintc.airy_hi(x1); break; }
                            case "aflintc": { res1 = aflintc.airy_hi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_gi_prime"))
            {
                string name = "airy_gi_prime";
                InputArray1 = new[] { dcplx.t(-10.0d, 2), dcplx.t(-2.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x1={0})", x1);

                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.airy_gi_prime(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.airy_gi_prime(x1); break; }
                            case "dflintc": { res1 = dflintc.airy_gi_prime(x1); break; }
                            case "eflintc": { res1 = eflintc.airy_gi_prime(x1); break; }
                            case "qflintc": { res1 = qflintc.airy_gi_prime(x1); break; }
                            case "oflintc": { res1 = oflintc.airy_gi_prime(x1); break; }
                            case "mflintc": { res1 = mflintc.airy_gi_prime(x1); break; }
                            case "aflintc": { res1 = aflintc.airy_gi_prime(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_hi_prime"))
            {
                string name = "airy_hi_prime";
                InputArray1 = new[] { dcplx.t(-10.0d, 2), dcplx.t(-2.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x1={0})", x1);

                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.airy_hi_prime(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.airy_hi_prime(x1); break; }
                            case "dflintc": { res1 = dflintc.airy_hi_prime(x1); break; }
                            case "eflintc": { res1 = eflintc.airy_hi_prime(x1); break; }
                            case "qflintc": { res1 = qflintc.airy_hi_prime(x1); break; }
                            case "oflintc": { res1 = oflintc.airy_hi_prime(x1); break; }
                            case "mflintc": { res1 = mflintc.airy_hi_prime(x1); break; }
                            case "aflintc": { res1 = aflintc.airy_hi_prime(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion




            #region Struve functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("struve_h"))
            {
                string name = "struve_h";
                InputArray1 = new[] { dcplx.t(0.1), 1.1, 2, 4, 6, 8, 10 };
                InputArray2 = new[] { dcplx.t(-0.333d, 2), dcplx.t(0.0, 2), dcplx.t(0.333, 2) };
                foreach (var n in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.struve_h(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.struve_h(n, x); break; }
                                case "dflintc": { res1 = dflintc.struve_h(n, x); break; }
                                case "eflintc": { res1 = eflintc.struve_h(n, x); break; }
                                case "qflintc": { res1 = qflintc.struve_h(n, x); break; }
                                case "oflintc": { res1 = oflintc.struve_h(n, x); break; }
                                case "mflintc": { res1 = mflintc.struve_h(n, x); break; }
                                case "aflintc": { res1 = aflintc.struve_h(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("struve_l"))
            {
                string name = "struve_l";
                InputArray1 = new[] { dcplx.t(0.1), 1.1, 2, 4, 6, 8, 10 };
                InputArray2 = new[] { dcplx.t(-0.333d, 2), dcplx.t(0.0, 2), dcplx.t(0.333, 2) };
                foreach (var n in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.struve_l(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.struve_l(n, x); break; }
                                case "dflintc": { res1 = dflintc.struve_l(n, x); break; }
                                case "eflintc": { res1 = eflintc.struve_l(n, x); break; }
                                case "qflintc": { res1 = qflintc.struve_l(n, x); break; }
                                case "oflintc": { res1 = oflintc.struve_l(n, x); break; }
                                case "mflintc": { res1 = mflintc.struve_l(n, x); break; }
                                case "aflintc": { res1 = aflintc.struve_l(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("struve_k"))
            {
                string name = "struve_k";
                InputArray1 = new[] { dcplx.t(0.1), 1.1, 2, 4, 6, 8, 10 };
                InputArray2 = new[] { dcplx.t(-0.333d, 2), dcplx.t(0.0, 2), dcplx.t(0.333, 2) };
                foreach (var n in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.struve_k(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.struve_k(n, x); break; }
                                case "dflintc": { res1 = dflintc.struve_k(n, x); break; }
                                case "eflintc": { res1 = eflintc.struve_k(n, x); break; }
                                case "qflintc": { res1 = qflintc.struve_k(n, x); break; }
                                case "oflintc": { res1 = oflintc.struve_k(n, x); break; }
                                case "mflintc": { res1 = mflintc.struve_k(n, x); break; }
                                case "aflintc": { res1 = aflintc.struve_k(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("struve_m"))
            {
                string name = "struve_m";
                InputArray1 = new[] { dcplx.t(0.1), 1.1, 2, 4, 6, 8, 10 };
                InputArray2 = new[] { dcplx.t(-0.333d, 2), dcplx.t(0.0, 2), dcplx.t(0.333, 2) };
                foreach (var n in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.struve_m(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.struve_m(n, x); break; }
                                case "dflintc": { res1 = dflintc.struve_m(n, x); break; }
                                case "eflintc": { res1 = eflintc.struve_m(n, x); break; }
                                case "qflintc": { res1 = qflintc.struve_m(n, x); break; }
                                case "oflintc": { res1 = oflintc.struve_m(n, x); break; }
                                case "mflintc": { res1 = mflintc.struve_m(n, x); break; }
                                case "aflintc": { res1 = aflintc.struve_m(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion




            #region Anger, Weber and Lommel functions



            if (FunctionArray.Contains("all") | FunctionArray.Contains("anger_j"))
            {
                string name = "anger_j";
                InputArray1 = new[] { dcplx.t(10.1) };  // integration does not work with 10
                InputArray2 = new[] { dcplx.t(3.0, 2) };
                foreach (var n in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.anger_j(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.anger_j(n, x); break; }
                                case "dflintc": { res1 = dflintc.anger_j(n, x); break; }
                                case "eflintc": { res1 = eflintc.anger_j(n, x); break; }
                                case "qflintc": { res1 = qflintc.anger_j(n, x); break; }
                                case "oflintc": { res1 = oflintc.anger_j(n, x); break; }
                                case "mflintc": { res1 = mflintc.anger_j(n, x); break; }
                                case "aflintc": { res1 = aflintc.anger_j(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("weber_e"))
            {
                string name = "weber_e";
                InputArray1 = new[] { dcplx.t(10.1) };  // integration does not work with 10
                InputArray2 = new[] { dcplx.t(3.0, 2) };
                foreach (var n in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.weber_e(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.weber_e(n, x); break; }
                                case "dflintc": { res1 = dflintc.weber_e(n, x); break; }
                                case "eflintc": { res1 = eflintc.weber_e(n, x); break; }
                                case "qflintc": { res1 = qflintc.weber_e(n, x); break; }
                                case "oflintc": { res1 = oflintc.weber_e(n, x); break; }
                                case "mflintc": { res1 = mflintc.weber_e(n, x); break; }
                                case "aflintc": { res1 = aflintc.weber_e(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("lommel_s1"))
            {
                string name = "lommel_s1";
                InputArray1 = new[] { dcplx.t(11.3) };
                InputArray2 = new[] { dcplx.t(2.7) };
                InputArray3 = new[] { dcplx.t(0.3, 2), dcplx.t(3, 2) };
                foreach (var mu in InputArray1)
                {
                    foreach (var nu in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(mu={0}, nu={1}, x={2})", mu, nu, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "cmath53": { res1 = cmath53.lommel_s1(mu, nu, x); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.lommel_s1(mu, nu, x); break; }
                                    case "dflintc": { res1 = dflintc.lommel_s1(mu, nu, x); break; }
                                    case "eflintc": { res1 = eflintc.lommel_s1(mu, nu, x); break; }
                                    case "qflintc": { res1 = qflintc.lommel_s1(mu, nu, x); break; }
                                    case "oflintc": { res1 = oflintc.lommel_s1(mu, nu, x); break; }
                                    case "mflintc": { res1 = mflintc.lommel_s1(mu, nu, x); break; }
                                    case "aflintc": { res1 = aflintc.lommel_s1(mu, nu, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("lommel_s2"))
            {
                string name = "lommel_s2";
                InputArray1 = new[] { dcplx.t(11.3) };
                InputArray2 = new[] { dcplx.t(2.7) };
                InputArray3 = new[] { dcplx.t(0.3, 2), dcplx.t(3, 2) };
                foreach (var mu in InputArray1)
                {
                    foreach (var nu in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(mu={0}, nu={1}, x={2})", mu, nu, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "cmath53": { res1 = cmath53.lommel_s2(mu, nu, x); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.lommel_s2(mu, nu, x); break; }
                                    case "dflintc": { res1 = dflintc.lommel_s2(mu, nu, x); break; }
                                    case "eflintc": { res1 = eflintc.lommel_s2(mu, nu, x); break; }
                                    case "qflintc": { res1 = qflintc.lommel_s2(mu, nu, x); break; }
                                    case "oflintc": { res1 = oflintc.lommel_s2(mu, nu, x); break; }
                                    case "mflintc": { res1 = mflintc.lommel_s2(mu, nu, x); break; }
                                    case "aflintc": { res1 = aflintc.lommel_s2(mu, nu, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }





            #endregion







        }







        public static void CplxHypergeometric_pFq()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTests_CplxHypergeometric_pFq();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

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