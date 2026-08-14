using System;
using System.Diagnostics;
using System.Linq;
using FixedPrecNet;
using System.Diagnostics.Eventing.Reader;



#if HasArbPrecNet
using ArbPrecNet;
#endif




namespace TestXlCalcNetPrecCS
{

    static partial class Tests
    {



        public static void RunTests_RealHypergeometric_pFq()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(80);
#endif
            string[] NTA1 = new[] { "math53", " sreal", " dreal", " ereal", " qreal", " oreal" };
            string[] NTA2 = new[] { " mreal", "sflint", "dflint", "eflint", "qflint", "oflint", "mflint", "aflint" };

            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();

            //string[] FunctionArray = new[] { "all" };
            string[] FunctionArray = new[] { "spherical_y" };

            DemoChapterpFq(NumTypeArray, FunctionArray);

        }



        public static void DemoChapterpFq(string[] NumTypeArray, string[] FunctionArray)
        {

            double[] InputArray1;
            double[] InputArray2;
            double[] InputArray3;
            double[] InputArray4;
            int[] InputArrayInt1;
            int[] InputArrayInt2;



            #region Gauss Hypergeometric Function 2F1


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_2f1"))
            {
                string name = "hyperg_1f1";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 3.1d, 8.1d, 29.5d };
                InputArray4 = new[] { -1.5d, 0.0d, 0.5d };
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
                                        case "math53": { res1 = math53.hyperg_2f1(a, b, c, x); break; }
#if HasArbPrecNet
                                        case "sflint": { res1 = sflint.hyperg_2f1(a, b, c, x); break; }
                                        case "dflint": { res1 = dflint.hyperg_2f1(a, b, c, x); break; }
                                        case "eflint": { res1 = eflint.hyperg_2f1(a, b, c, x); break; }
                                        case "qflint": { res1 = qflint.hyperg_2f1(a, b, c, x); break; }
                                        case "oflint": { res1 = oflint.hyperg_2f1(a, b, c, x); break; }
                                        case "mflint": { res1 = mflint.hyperg_2f1(a, b, c, x); break; }
                                        case "aflint": { res1 = aflint.hyperg_2f1(a, b, c, x); break; }
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
                string name = "hyperg_1f1r";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 3.1d, 8.1d, 29.5d };
                InputArray4 = new[] { -1.5d, 0.0d, 0.5d };
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
                                        case "math53": { res1 = math53.hyperg_2f1r(a, b, c, x); break; }
#if HasArbPrecNet
                                        case "sflint": { res1 = sflint.hyperg_2f1r(a, b, c, x); break; }
                                        case "dflint": { res1 = dflint.hyperg_2f1r(a, b, c, x); break; }
                                        case "eflint": { res1 = eflint.hyperg_2f1r(a, b, c, x); break; }
                                        case "qflint": { res1 = qflint.hyperg_2f1r(a, b, c, x); break; }
                                        case "oflint": { res1 = oflint.hyperg_2f1r(a, b, c, x); break; }
                                        case "mflint": { res1 = mflint.hyperg_2f1r(a, b, c, x); break; }
                                        case "aflint": { res1 = aflint.hyperg_2f1r(a, b, c, x); break; }
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
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
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
                                case "math53": { res1 = math53.chebyshev_t(n, x); break; }
                                case " sreal": { res1 = sreal.chebyshev_t(n, x); break; }
                                case " dreal": { res1 = dreal.chebyshev_t(n, x); break; }
                                case " ereal": { res1 = ereal.chebyshev_t(n, x); break; }
                                case " qreal": { res1 = qreal.chebyshev_t(n, x); break; }
                                case " oreal": { res1 = oreal.chebyshev_t(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.chebyshev_t(n, x); break; }
                                case "sflint": { res1 = sflint.chebyshev_t(n, x); break; }
                                case "dflint": { res1 = dflint.chebyshev_t(n, x); break; }
                                case "eflint": { res1 = eflint.chebyshev_t(n, x); break; }
                                case "qflint": { res1 = qflint.chebyshev_t(n, x); break; }
                                case "oflint": { res1 = oflint.chebyshev_t(n, x); break; }
                                case "mflint": { res1 = mflint.chebyshev_t(n, x); break; }
                                case "aflint": { res1 = aflint.chebyshev_t(n, x); break; }
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
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
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
                                case "math53": { res1 = math53.chebyshev_u(n, x); break; }
                                case " sreal": { res1 = sreal.chebyshev_u(n, x); break; }
                                case " dreal": { res1 = dreal.chebyshev_u(n, x); break; }
                                case " ereal": { res1 = ereal.chebyshev_u(n, x); break; }
                                case " qreal": { res1 = qreal.chebyshev_u(n, x); break; }
                                case " oreal": { res1 = oreal.chebyshev_u(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.chebyshev_u(n, x); break; }
                                case "sflint": { res1 = sflint.chebyshev_u(n, x); break; }
                                case "dflint": { res1 = dflint.chebyshev_u(n, x); break; }
                                case "eflint": { res1 = eflint.chebyshev_u(n, x); break; }
                                case "qflint": { res1 = qflint.chebyshev_u(n, x); break; }
                                case "oflint": { res1 = oflint.chebyshev_u(n, x); break; }
                                case "mflint": { res1 = mflint.chebyshev_u(n, x); break; }
                                case "aflint": { res1 = aflint.chebyshev_u(n, x); break; }
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
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -1.0, -0.333d, 0.0d, 0.333d };
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
                                case "math53": { res1 = math53.chebyshev_v(n, x); break; }
                                case " sreal": { res1 = sreal.chebyshev_v(n, x); break; }
                                case " dreal": { res1 = dreal.chebyshev_v(n, x); break; }
                                case " ereal": { res1 = ereal.chebyshev_v(n, x); break; }
                                case " qreal": { res1 = qreal.chebyshev_v(n, x); break; }
                                case " oreal": { res1 = oreal.chebyshev_v(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.chebyshev_v(n, x); break; }
                                case "sflint": { res1 = sflint.chebyshev_v(n, x); break; }
                                case "dflint": { res1 = dflint.chebyshev_v(n, x); break; }
                                case "eflint": { res1 = eflint.chebyshev_v(n, x); break; }
                                case "qflint": { res1 = qflint.chebyshev_v(n, x); break; }
                                case "oflint": { res1 = oflint.chebyshev_v(n, x); break; }
                                case "mflint": { res1 = mflint.chebyshev_v(n, x); break; }
                                case "aflint": { res1 = aflint.chebyshev_v(n, x); break; }
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
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -1.0, -0.333d, 0.0d, 0.333d };
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
                                case "math53": { res1 = math53.chebyshev_w(n, x); break; }
                                case " sreal": { res1 = sreal.chebyshev_w(n, x); break; }
                                case " dreal": { res1 = dreal.chebyshev_w(n, x); break; }
                                case " ereal": { res1 = ereal.chebyshev_w(n, x); break; }
                                case " qreal": { res1 = qreal.chebyshev_w(n, x); break; }
                                case " oreal": { res1 = oreal.chebyshev_w(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.chebyshev_w(n, x); break; }
                                case "sflint": { res1 = sflint.chebyshev_w(n, x); break; }
                                case "dflint": { res1 = dflint.chebyshev_w(n, x); break; }
                                case "eflint": { res1 = eflint.chebyshev_w(n, x); break; }
                                case "qflint": { res1 = qflint.chebyshev_w(n, x); break; }
                                case "oflint": { res1 = oflint.chebyshev_w(n, x); break; }
                                case "mflint": { res1 = mflint.chebyshev_w(n, x); break; }
                                case "aflint": { res1 = aflint.chebyshev_w(n, x); break; }
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
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
                InputArray2 = new[] { -0.333d, 0.0d, 0.333d };
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
                                    case "math53": { res1 = math53.gegenbauer_c(n, lambda1, x); break; }
                                    case " sreal": { res1 = sreal.gegenbauer_c(n, lambda1, x); break; }
                                    case " dreal": { res1 = dreal.gegenbauer_c(n, lambda1, x); break; }
                                    case " ereal": { res1 = ereal.gegenbauer_c(n, lambda1, x); break; }
                                    case " qreal": { res1 = qreal.gegenbauer_c(n, lambda1, x); break; }
                                    case " oreal": { res1 = oreal.gegenbauer_c(n, lambda1, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.gegenbauer_c(n, lambda1, x); break; }
                                    case "sflint": { res1 = sflint.gegenbauer_c(n, lambda1, x); break; }
                                    case "dflint": { res1 = dflint.gegenbauer_c(n, lambda1, x); break; }
                                    case "eflint": { res1 = eflint.gegenbauer_c(n, lambda1, x); break; }
                                    case "qflint": { res1 = qflint.gegenbauer_c(n, lambda1, x); break; }
                                    case "oflint": { res1 = oflint.gegenbauer_c(n, lambda1, x); break; }
                                    case "mflint": { res1 = mflint.gegenbauer_c(n, lambda1, x); break; }
                                    case "aflint": { res1 = aflint.gegenbauer_c(n, lambda1, x); break; }
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
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
                InputArray2 = new[] { -0.333d, 0.0d, 0.333d };
                InputArray3 = new[] { -0.333d, 0.0d, 0.333d };
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
                                        case "math53": { res1 = math53.jacobi_p(n, alpha, beta, x); break; }
                                        case " sreal": { res1 = sreal.jacobi_p(n, alpha, beta, x); break; }
                                        case " dreal": { res1 = dreal.jacobi_p(n, alpha, beta, x); break; }
                                        case " ereal": { res1 = ereal.jacobi_p(n, alpha, beta, x); break; }
                                        case " qreal": { res1 = qreal.jacobi_p(n, alpha, beta, x); break; }
                                        case " oreal": { res1 = oreal.jacobi_p(n, alpha, beta, x); break; }
#if HasArbPrecNet
                                        case " mreal": { res1 = mreal.jacobi_p(n, alpha, beta, x); break; }
                                        case "sflint": { res1 = sflint.jacobi_p(n, alpha, beta, x); break; }
                                        case "dflint": { res1 = dflint.jacobi_p(n, alpha, beta, x); break; }
                                        case "eflint": { res1 = eflint.jacobi_p(n, alpha, beta, x); break; }
                                        case "qflint": { res1 = qflint.jacobi_p(n, alpha, beta, x); break; }
                                        case "oflint": { res1 = oflint.jacobi_p(n, alpha, beta, x); break; }
                                        case "mflint": { res1 = mflint.jacobi_p(n, alpha, beta, x); break; }
                                        case "aflint": { res1 = aflint.jacobi_p(n, alpha, beta, x); break; }
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


            if (FunctionArray.Contains("all") | FunctionArray.Contains("zernike_r"))
            {
                string name = "zernike_r";
                InputArrayInt1 = new[] { 0, 1, 2, 3 ,4, 5, 6 };
                InputArrayInt2 = new[] { 0, 1, 2, 3, 4, 5, 6 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d , 4.5};
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
                                    case "math53": { res1 = math53.zernike_r(n, m, x); break; }
                                    //case " sreal": { res1 = sreal.zernike_r(n, m, x); break; }
                                    case " dreal": { res1 = dreal.zernike_r(n, m, x); break; }
                                        //case " ereal": { res1 = ereal.zernike_r(n, m, x); break; }
                                        //case " qreal": { res1 = qreal.zernike_r(n, m, x); break; }
                                        //case " oreal": { res1 = oreal.zernike_r(n, m, x); break; }
#if HasArbPrecNet
                                        //case " mreal": { res1 = mreal.zernike_r(n, m, x); break; }
                                        //case "sflint": { res1 = sflint.zernike_r(n, m, x); break; }
                                        //case "dflint": { res1 = dflint.zernike_r(n, m, x); break; }
                                        //case "eflint": { res1 = eflint.zernike_r(n, m, x); break; }
                                        //case "qflint": { res1 = qflint.zernike_r(n, m, x); break; }
                                        //case "oflint": { res1 = oflint.zernike_r(n, m, x); break; }
                                        //case "mflint": { res1 = mflint.zernike_r(n, m, x); break; }
                                        //case "aflint": { res1 = aflint.zernike_r(n, m, x); break; }
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




            #region Legendre polynomials and related


            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_p"))
            {
                string name = "legendre_p";
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -5.0, -0.5, -0.01d, 0.01d, 0.5d, 1.0d - 0.001d, 5.0 };  // 0.0 < x < 1.0
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
                                case "math53": { res1 = math53.legendre_p(n, x); break; }
                                case " sreal": { res1 = sreal.legendre_p(n, x); break; }
                                case " dreal": { res1 = dreal.legendre_p(n, x); break; }
                                case " ereal": { res1 = ereal.legendre_p(n, x); break; }
                                case " qreal": { res1 = qreal.legendre_p(n, x); break; }
                                case " oreal": { res1 = oreal.legendre_p(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.legendre_p(n, x); break; }
                                case "sflint": { res1 = sflint.legendre_p(n, x); break; }
                                case "dflint": { res1 = dflint.legendre_p(n, x); break; }
                                case "eflint": { res1 = eflint.legendre_p(n, x); break; }
                                case "qflint": { res1 = qflint.legendre_p(n, x); break; }
                                case "oflint": { res1 = oflint.legendre_p(n, x); break; }
                                case "mflint": { res1 = mflint.legendre_p(n, x); break; }
                                case "aflint": { res1 = aflint.legendre_p(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_plm"))
            {
                string name = "legendre_plm";
                InputArrayInt1 = new[] { 7, 9, 13 };  // n > 0
                InputArrayInt2 = new[] { 1, 4, 6 };  // m > 0
                InputArray1 = new[] {-5.0, -0.5, -0.01d, 0.01d, 0.5d, 1.0d - 0.001d, 5.0 };  // 0.0 < x < 1.0
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
                                    case "math53": { res1 = math53.legendre_plm(n, m, x); break; }
                                    case " sreal": { res1 = sreal.legendre_plm(n, m, x); break; }
                                    case " dreal": { res1 = dreal.legendre_plm(n, m, x); break; }
                                    case " ereal": { res1 = ereal.legendre_plm(n, m, x); break; }
                                    case " qreal": { res1 = qreal.legendre_plm(n, m, x); break; }
                                    case " oreal": { res1 = oreal.legendre_plm(n, m, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.legendre_plm(n, m, x); break; }
                                    case "sflint": { res1 = sflint.legendre_plm(n, m, x); break; }
                                    case "dflint": { res1 = dflint.legendre_plm(n, m, x); break; }
                                    case "eflint": { res1 = eflint.legendre_plm(n, m, x); break; }
                                    case "qflint": { res1 = qflint.legendre_plm(n, m, x); break; }
                                    case "oflint": { res1 = oflint.legendre_plm(n, m, x); break; }
                                    case "mflint": { res1 = mflint.legendre_plm(n, m, x); break; }
                                    case "aflint": { res1 = aflint.legendre_plm(n, m, x); break; }
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
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -10.01d, -0.5d, 0.0, 0.5d, 1.0d - 0.001d, 10.01d };  // abs(x) != 1.
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
                                case "math53": { res1 = math53.legendre_q(n, x); break; }
                                case " sreal": { res1 = sreal.legendre_q(n, x); break; }
                                case " dreal": { res1 = dreal.legendre_q(n, x); break; }
                                case " ereal": { res1 = ereal.legendre_q(n, x); break; }
                                case " qreal": { res1 = qreal.legendre_q(n, x); break; }
                                case " oreal": { res1 = oreal.legendre_q(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.legendre_q(n, x); break; }
                                case "sflint": { res1 = sflint.legendre_q(n, x); break; }
                                case "dflint": { res1 = dflint.legendre_q(n, x); break; }
                                case "eflint": { res1 = eflint.legendre_q(n, x); break; }
                                case "qflint": { res1 = qflint.legendre_q(n, x); break; }
                                case "oflint": { res1 = oflint.legendre_q(n, x); break; }
                                case "mflint": { res1 = mflint.legendre_q(n, x); break; }
                                case "aflint": { res1 = aflint.legendre_q(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_qlm"))
            {
                string name = "legendre_qlm";
                InputArrayInt1 = new[] { 7, 9, 13 };  // n >= 0
                InputArrayInt2 = new[] { 1, 4, 6 };  // n + m >= 0
                InputArray1 = new[] { -10.01d, -0.5d, 0.0, 0.5d, 1.0d - 0.001d, 10.01d};  // abs(x) != 1.
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
                                    case "math53": { res1 = math53.legendre_qlm(n, m, x); break; }
#if HasArbPrecNet
                                    case "sflint": { res1 = sflint.legendre_qlm(n, m, x); break; }
                                    case "dflint": { res1 = dflint.legendre_qlm(n, m, x); break; }
                                    case "eflint": { res1 = eflint.legendre_qlm(n, m, x); break; }
                                    case "qflint": { res1 = qflint.legendre_qlm(n, m, x); break; }
                                    case "oflint": { res1 = oflint.legendre_qlm(n, m, x); break; }
                                    case "mflint": { res1 = mflint.legendre_qlm(n, m, x); break; }
                                    case "aflint": { res1 = aflint.legendre_qlm(n, m, x); break; }
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
                InputArray1 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };  // 0.0 < theta < 1.0
                InputArray2 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };  // 0.0 < phi < 1.0
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
                                        case "math53": { res1 = math53.spherical_y(n, m, theta, phi); break; }
                                        case " sreal": { res1 = sreal.spherical_y(n, m, theta, phi); break; }
                                        case " dreal": { res1 = dreal.spherical_y(n, m, theta, phi); break; }
                                        case " ereal": { res1 = ereal.spherical_y(n, m, theta, phi); break; }
                                        case " qreal": { res1 = qreal.spherical_y(n, m, theta, phi); break; }
                                        case " oreal": { res1 = oreal.spherical_y(n, m, theta, phi); break; }
#if HasArbPrecNet
                                        case " mreal": { res1 = mreal.spherical_y(n, m, theta, phi); break; }
                                        case "sflint": { res1 = sflint.spherical_y(n, m, theta, phi); break; }
                                        case "dflint": { res1 = dflint.spherical_y(n, m, theta, phi); break; }
                                        case "eflint": { res1 = eflint.spherical_y(n, m, theta, phi); break; }
                                        case "qflint": { res1 = qflint.spherical_y(n, m, theta, phi); break; }
                                        case "oflint": { res1 = oflint.spherical_y(n, m, theta, phi); break; }
                                        case "mflint": { res1 = mflint.spherical_y(n, m, theta, phi); break; }
                                        case "aflint": { res1 = aflint.spherical_y(n, m, theta, phi); break; }
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



            if (FunctionArray.Contains("all") | FunctionArray.Contains("toroidal_plm"))
            {
                string name = "toroidal_plm";
                InputArrayInt1 = new[] { 0, 1, 2, 3, 4 };  
                InputArrayInt2 = new[] {0, 1, 2, 3, 4 };  
                InputArray1 = new[] { 1.0, 1.0d + 1E-13, 1.5d, 8.0};  
                foreach (var l in InputArrayInt1)
                {
                    foreach (var m in InputArrayInt2)
                    {
                        foreach (var x in InputArray1)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(l={0}, m={1}, x={2})", l, m, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.toroidal_plm(l, m, x); break; }
                                    case " dreal": { res1 = math53.toroidal_plm_2f1(l, m, x); break; }
#if HasArbPrecNet
                                    case "sflint": { res1 = sflint.toroidal_plm(l, m, x); break; }
                                    case "dflint": { res1 = dflint.toroidal_plm(l, m, x); break; }
                                    case "eflint": { res1 = eflint.toroidal_plm(l, m, x); break; }
                                    case "qflint": { res1 = qflint.toroidal_plm(l, m, x); break; }
                                    case "oflint": { res1 = oflint.toroidal_plm(l, m, x); break; }
                                    case "mflint": { res1 = mflint.toroidal_plm(l, m, x); break; }
                                    case "aflint": { res1 = aflint.toroidal_plm(l, m, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("toroidal_qlm"))
            {
                string name = "toroidal_qlm";
                InputArrayInt1 = new[] { 0, 1, 2, 3, 4 };
                InputArrayInt2 = new[] { 0, 1, 2, 3, 4 };
                InputArray1 = new[] { 1.0d + 1E-5, 1.1d, 1.5d, 8.0 };
                foreach (var l in InputArrayInt1)
                {
                    foreach (var m in InputArrayInt2)
                    {
                        foreach (var x in InputArray1)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(l={0}, m={1}, x={2})", l, m, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.toroidal_qlm(l, m, x); break; }
                                    case " dreal": { res1 = math53.toroidal_qlm_2f1(l, m, x); break; }
#if HasArbPrecNet
                                    case "sflint": { res1 = sflint.toroidal_qlm(l, m, x); break; }
                                    case "dflint": { res1 = dflint.toroidal_qlm(l, m, x); break; }
                                    case "eflint": { res1 = eflint.toroidal_qlm(l, m, x); break; }
                                    case "qflint": { res1 = qflint.toroidal_qlm(l, m, x); break; }
                                    case "oflint": { res1 = oflint.toroidal_qlm(l, m, x); break; }
                                    case "mflint": { res1 = mflint.toroidal_qlm(l, m, x); break; }
                                    case "aflint": { res1 = aflint.toroidal_qlm(l, m, x); break; }
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






            #region Incomplete beta functions for real arguments and parameters


            if (FunctionArray.Contains("all") | FunctionArray.Contains("beta_lower"))
            {
                string name = "beta_lower";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
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
                                    case "math53": { res1 = math53.beta_lower(a, b, x); break; }
                                    case " sreal": { res1 = sreal.beta_lower(a, b, x); break; }
                                    case " dreal": { res1 = dreal.beta_lower(a, b, x); break; }
                                    case " ereal": { res1 = ereal.beta_lower(a, b, x); break; }
                                    case " qreal": { res1 = qreal.beta_lower(a, b, x); break; }
                                    case " oreal": { res1 = oreal.beta_lower(a, b, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.beta_lower(a, b, x); break; }
                                    case "sflint": { res1 = sflint.beta_lower(a, b, x); break; }
                                    case "dflint": { res1 = dflint.beta_lower(a, b, x); break; }
                                    case "eflint": { res1 = eflint.beta_lower(a, b, x); break; }
                                    case "qflint": { res1 = qflint.beta_lower(a, b, x); break; }
                                    case "oflint": { res1 = oflint.beta_lower(a, b, x); break; }
                                    case "mflint": { res1 = mflint.beta_lower(a, b, x); break; }
                                    case "aflint": { res1 = aflint.beta_lower(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("beta_upper"))
            {
                string name = "beta_lower";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
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
                                    case "math53": { res1 = math53.beta_upper(a, b, x); break; }
                                    case " sreal": { res1 = sreal.beta_upper(a, b, x); break; }
                                    case " dreal": { res1 = dreal.beta_upper(a, b, x); break; }
                                    case " ereal": { res1 = ereal.beta_upper(a, b, x); break; }
                                    case " qreal": { res1 = qreal.beta_upper(a, b, x); break; }
                                    case " oreal": { res1 = oreal.beta_upper(a, b, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.beta_upper(a, b, x); break; }
                                    ////case "sflint": { res1 = sflint.beta_upper(a, b, x); break; }
                                    ////case "dflint": { res1 = dflint.beta_upper(a, b, x); break; }
                                    ////case "eflint": { res1 = eflint.beta_upper(a, b, x); break; }
                                    ////case "qflint": { res1 = qflint.beta_upper(a, b, x); break; }
                                    ////case "oflint": { res1 = oflint.beta_upper(a, b, x); break; }
                                    ////case "mflint": { res1 = mflint.beta_upper(a, b, x); break; }
                                    ////case "aflint": { res1 = aflint.beta_upper(a, b, x); break; }
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
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
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
                                    case "math53": { res1 = math53.ibeta(a, b, x); break; }
                                    case " sreal": { res1 = sreal.ibeta(a, b, x); break; }
                                    case " dreal": { res1 = dreal.ibeta(a, b, x); break; }
                                    case " ereal": { res1 = ereal.ibeta(a, b, x); break; }
                                    case " qreal": { res1 = qreal.ibeta(a, b, x); break; }
                                    case " oreal": { res1 = oreal.ibeta(a, b, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.ibeta(a, b, x); break; }
                                    case "sflint": { res1 = sflint.ibeta(a, b, x); break; }
                                    case "dflint": { res1 = dflint.ibeta(a, b, x); break; }
                                    case "eflint": { res1 = eflint.ibeta(a, b, x); break; }
                                    case "qflint": { res1 = qflint.ibeta(a, b, x); break; }
                                    case "oflint": { res1 = oflint.ibeta(a, b, x); break; }
                                    case "mflint": { res1 = mflint.ibeta(a, b, x); break; }
                                    case "aflint": { res1 = aflint.ibeta(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ibetac"))
            {
                string name = "ibetac";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
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
                                    case "math53": { res1 = math53.ibetac(a, b, x); break; }
                                    case " sreal": { res1 = sreal.ibetac(a, b, x); break; }
                                    case " dreal": { res1 = dreal.ibetac(a, b, x); break; }
                                    case " ereal": { res1 = ereal.ibetac(a, b, x); break; }
                                    case " qreal": { res1 = qreal.ibetac(a, b, x); break; }
                                    case " oreal": { res1 = oreal.ibetac(a, b, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.ibetac(a, b, x); break; }
                                    case "sflint": { res1 = sflint.ibetac(a, b, x); break; }
                                    case "dflint": { res1 = dflint.ibetac(a, b, x); break; }
                                    case "eflint": { res1 = eflint.ibetac(a, b, x); break; }
                                    case "qflint": { res1 = qflint.ibetac(a, b, x); break; }
                                    case "oflint": { res1 = oflint.ibetac(a, b, x); break; }
                                    case "mflint": { res1 = mflint.ibetac(a, b, x); break; }
                                    case "aflint": { res1 = aflint.ibetac(a, b, x); break; }
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
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
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
                                    case "math53": { res1 = math53.ibeta_prime(a, b, x); break; }
                                    case " sreal": { res1 = sreal.ibeta_prime(a, b, x); break; }
                                    case " dreal": { res1 = dreal.ibeta_prime(a, b, x); break; }
                                    case " ereal": { res1 = ereal.ibeta_prime(a, b, x); break; }
                                    case " qreal": { res1 = qreal.ibeta_prime(a, b, x); break; }
                                    case " oreal": { res1 = oreal.ibeta_prime(a, b, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.ibeta_prime(a, b, x); break; }
                                    case "sflint": { res1 = sflint.ibeta_prime(a, b, x); break; }
                                    case "dflint": { res1 = dflint.ibeta_prime(a, b, x); break; }
                                    case "eflint": { res1 = eflint.ibeta_prime(a, b, x); break; }
                                    case "qflint": { res1 = qflint.ibeta_prime(a, b, x); break; }
                                    case "oflint": { res1 = oflint.ibeta_prime(a, b, x); break; }
                                    case "mflint": { res1 = mflint.ibeta_prime(a, b, x); break; }
                                    case "aflint": { res1 = aflint.ibeta_prime(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }




            if (FunctionArray.Contains("all") | FunctionArray.Contains("ibeta_inv"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var p in InputArray3)
                        {
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.ibeta_inv(a, b, p); break; }
                                    case " sreal": { res1 = sreal.ibeta_inv(a, b, p); break; }
                                    case " dreal": { res1 = dreal.ibeta_inv(a, b, p); break; }
                                    case " ereal": { res1 = ereal.ibeta_inv(a, b, p); break; }
                                    case " qreal": { res1 = qreal.ibeta_inv(a, b, p); break; }
                                    case " oreal": { res1 = oreal.ibeta_inv(a, b, p); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.ibeta_inv(a, b, p); break; }
#endif
                                }
                                Console.WriteLine("{0}: ibeta_inv(a={1}, b={2}, p={3}): {4}", NumType, a, b, p, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ibetac_inv"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var p in InputArray3)
                        {
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.ibetac_inv(a, b, p); break; }
                                    case " sreal": { res1 = sreal.ibetac_inv(a, b, p); break; }
                                    case " dreal": { res1 = dreal.ibetac_inv(a, b, p); break; }
                                    case " ereal": { res1 = ereal.ibetac_inv(a, b, p); break; }
                                    case " qreal": { res1 = qreal.ibetac_inv(a, b, p); break; }
                                    case " oreal": { res1 = oreal.ibetac_inv(a, b, p); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.ibetac_inv(a, b, p); break; }
#endif
                                }
                                Console.WriteLine("{0}: ibetac_inv(a={1}, b={2}, p={3}): {4}", NumType, a, b, p, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ibeta_inva"))
            {
                InputArray1 = new[] { 1.5d, 12.5d, 441d, 713.5d };  // b > 0.0
                InputArray2 = new[] { 0.1d, 0.5d, 0.7d }; // 0 < x < 1
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d }; // 0 < p < 1
                foreach (var b in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var p in InputArray3)
                        {
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.ibeta_inva(b, x, p); break; }
                                    case " sreal": { res1 = sreal.ibeta_inva(b, x, p); break; }
                                    case " dreal": { res1 = dreal.ibeta_inva(b, x, p); break; }
                                    case " ereal": { res1 = ereal.ibeta_inva(b, x, p); break; }
                                    case " qreal": { res1 = qreal.ibeta_inva(b, x, p); break; }
                                    case " oreal": { res1 = oreal.ibeta_inva(b, x, p); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.ibeta_inva(b, x, p); break; }
#endif
                                }
                                Console.WriteLine("{0}: ibeta_inva(b={1}, x={2}, p={3}): {4}", NumType, b, x, p, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ibetac_inva"))
            {
                InputArray1 = new[] { 1.5d, 12.5d, 441d, 713.5d };  // b > 0.0
                InputArray2 = new[] { 0.1d, 0.5d, 0.7d }; // 0 < x < 1
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d }; // 0 < p < 1
                foreach (var b in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var p in InputArray3)
                        {
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.ibetac_inva(b, x, p); break; }
                                    case " sreal": { res1 = sreal.ibetac_inva(b, x, p); break; }
                                    case " dreal": { res1 = dreal.ibetac_inva(b, x, p); break; }
                                    case " ereal": { res1 = ereal.ibetac_inva(b, x, p); break; }
                                    case " qreal": { res1 = qreal.ibetac_inva(b, x, p); break; }
                                    case " oreal": { res1 = oreal.ibetac_inva(b, x, p); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.ibetac_inva(b, x, p); break; }
#endif
                                }
                                Console.WriteLine("{0}: ibetac_inva(b={1}, x={2}, p={3}): {4}", NumType, b, x, p, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ibeta_invb"))
            {
                InputArray1 = new[] { 1.5d, 12.5d, 441d, 713.5d };  // a > 0.0
                InputArray2 = new[] { 0.1d, 0.5d, 0.7d }; // 0 < x < 1
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d }; // 0 < p < 1
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var p in InputArray3)
                        {
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.ibeta_invb(a, x, p); break; }
                                    case " sreal": { res1 = sreal.ibeta_invb(a, x, p); break; }
                                    case " dreal": { res1 = dreal.ibeta_invb(a, x, p); break; }
                                    case " ereal": { res1 = ereal.ibeta_invb(a, x, p); break; }
                                    case " qreal": { res1 = qreal.ibeta_invb(a, x, p); break; }
                                    case " oreal": { res1 = oreal.ibeta_invb(a, x, p); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.ibeta_invb(a, x, p); break; }
#endif
                                }
                                Console.WriteLine("{0}: ibeta_invb(a={1}, x={2}, p={3}): {4}", NumType, a, x, p, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ibetac_invb"))
            {
                InputArray1 = new[] { 1.5d, 12.5d, 441d, 713.5d };  // a > 0.0
                InputArray2 = new[] { 0.1d, 0.5d, 0.7d }; // 0 < x < 1
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d }; // 0 < p < 1
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var p in InputArray3)
                        {
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.ibetac_invb(a, x, p); break; }
                                    case " sreal": { res1 = sreal.ibetac_invb(a, x, p); break; }
                                    case " dreal": { res1 = dreal.ibetac_invb(a, x, p); break; }
                                    case " ereal": { res1 = ereal.ibetac_invb(a, x, p); break; }
                                    case " qreal": { res1 = qreal.ibetac_invb(a, x, p); break; }
                                    case " oreal": { res1 = oreal.ibetac_invb(a, x, p); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.ibetac_invb(a, x, p); break; }
#endif
                                }
                                Console.WriteLine("{0}: ibetac_invb(a={1}, x={2}, p={3}): {4}", NumType, a, x, p, res1);
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
                InputArray1 = new[] { 1.5d, 2.5d, 3.5d };
                InputArray2 = new[] { 7.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 5.1d, 8.1d, 29.5d };
                InputArray4 = new[] { -1.5d, 0.0d, 0.5d, 2.5d };
                foreach (var a in InputArray1)
                {
                    foreach (var b1 in InputArray2)
                    {
                        foreach (var b2 in InputArray3)
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
                                        case "math53": { res1 = math53.hyperg_1f2(a, b1, b2, x); break; }

#if HasArbPrecNet
                                        case "sflint": { res1 = sflint.hyperg_1f2(a, b1, b2, x); break; }
                                        case "dflint": { res1 = dflint.hyperg_1f2(a, b1, b2, x); break; }
                                        case "eflint": { res1 = eflint.hyperg_1f2(a, b1, b2, x); break; }
                                        case "qflint": { res1 = qflint.hyperg_1f2(a, b1, b2, x); break; }
                                        case "oflint": { res1 = oflint.hyperg_1f2(a, b1, b2, x); break; }
                                        case "mflint": { res1 = mflint.hyperg_1f2(a, b1, b2, x); break; }
                                        case "aflint": { res1 = aflint.hyperg_1f2(a, b1, b2, x); break; }
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
                InputArray1 = new[] { 1.5d, 2.5d, 3.5d };
                InputArray2 = new[] { 7.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 5.1d, 8.1d, 29.5d };
                InputArray4 = new[] { -1.5d, 0.0d, 0.5d, 2.5d };
                foreach (var a in InputArray1)
                {
                    foreach (var b1 in InputArray2)
                    {
                        foreach (var b2 in InputArray3)
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
                                        case "math53": { res1 = math53.hyperg_1f2r(a, b1, b2, x); break; }
#if HasArbPrecNet
                                        case "sflint": { res1 = sflint.hyperg_1f2r(a, b1, b2, x); break; }
                                        case "dflint": { res1 = dflint.hyperg_1f2r(a, b1, b2, x); break; }
                                        case "eflint": { res1 = eflint.hyperg_1f2r(a, b1, b2, x); break; }
                                        case "qflint": { res1 = qflint.hyperg_1f2r(a, b1, b2, x); break; }
                                        case "oflint": { res1 = oflint.hyperg_1f2r(a, b1, b2, x); break; }
                                        case "mflint": { res1 = mflint.hyperg_1f2r(a, b1, b2, x); break; }
                                        case "aflint": { res1 = aflint.hyperg_1f2r(a, b1, b2, x); break; }
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

                InputArray1 = new[] { -10.0d, -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x1={0})", x1);

                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_gi(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.airy_gi(x1); break; }
                            case "dflint": { res1 = dflint.airy_gi(x1); break; }
                            case "eflint": { res1 = eflint.airy_gi(x1); break; }
                            case "qflint": { res1 = qflint.airy_gi(x1); break; }
                            case "oflint": { res1 = oflint.airy_gi(x1); break; }
                            case "mflint": { res1 = mflint.airy_gi(x1); break; }
                            case "aflint": { res1 = aflint.airy_gi(x1); break; }
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

                InputArray1 = new[] { -10.0d, -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x1={0})", x1);

                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_hi(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.airy_hi(x1); break; }
                            case "dflint": { res1 = dflint.airy_hi(x1); break; }
                            case "eflint": { res1 = eflint.airy_hi(x1); break; }
                            case "qflint": { res1 = qflint.airy_hi(x1); break; }
                            case "oflint": { res1 = oflint.airy_hi(x1); break; }
                            case "mflint": { res1 = mflint.airy_hi(x1); break; }
                            case "aflint": { res1 = aflint.airy_hi(x1); break; }
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

                InputArray1 = new[] { -10.0d, -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x1={0})", x1);

                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_gi_prime(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.airy_gi_prime(x1); break; }
                            case "dflint": { res1 = dflint.airy_gi_prime(x1); break; }
                            case "eflint": { res1 = eflint.airy_gi_prime(x1); break; }
                            case "qflint": { res1 = qflint.airy_gi_prime(x1); break; }
                            case "oflint": { res1 = oflint.airy_gi_prime(x1); break; }
                            case "mflint": { res1 = mflint.airy_gi_prime(x1); break; }
                            case "aflint": { res1 = aflint.airy_gi_prime(x1); break; }
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

                InputArray1 = new[] { -10.0d, -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x1={0})", x1);

                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_hi_prime(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.airy_hi_prime(x1); break; }
                            case "dflint": { res1 = dflint.airy_hi_prime(x1); break; }
                            case "eflint": { res1 = eflint.airy_hi_prime(x1); break; }
                            case "qflint": { res1 = qflint.airy_hi_prime(x1); break; }
                            case "oflint": { res1 = oflint.airy_hi_prime(x1); break; }
                            case "mflint": { res1 = mflint.airy_hi_prime(x1); break; }
                            case "aflint": { res1 = aflint.airy_hi_prime(x1); break; }
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
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
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
                                case "math53": { res1 = math53.struve_h(n, x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.struve_h(n, x); break; }
                                case "dflint": { res1 = dflint.struve_h(n, x); break; }
                                case "eflint": { res1 = eflint.struve_h(n, x); break; }
                                case "qflint": { res1 = qflint.struve_h(n, x); break; }
                                case "oflint": { res1 = oflint.struve_h(n, x); break; }
                                case "mflint": { res1 = mflint.struve_h(n, x); break; }
                                case "aflint": { res1 = aflint.struve_h(n, x); break; }
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
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
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
                                case "math53": { res1 = math53.struve_l(n, x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.struve_l(n, x); break; }
                                case "dflint": { res1 = dflint.struve_l(n, x); break; }
                                case "eflint": { res1 = eflint.struve_l(n, x); break; }
                                case "qflint": { res1 = qflint.struve_l(n, x); break; }
                                case "oflint": { res1 = oflint.struve_l(n, x); break; }
                                case "mflint": { res1 = mflint.struve_l(n, x); break; }
                                case "aflint": { res1 = aflint.struve_l(n, x); break; }
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
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
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
                                case "math53": { res1 = math53.struve_k(n, x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.struve_k(n, x); break; }
                                case "dflint": { res1 = dflint.struve_k(n, x); break; }
                                case "eflint": { res1 = eflint.struve_k(n, x); break; }
                                case "qflint": { res1 = qflint.struve_k(n, x); break; }
                                case "oflint": { res1 = oflint.struve_k(n, x); break; }
                                case "mflint": { res1 = mflint.struve_k(n, x); break; }
                                case "aflint": { res1 = aflint.struve_k(n, x); break; }
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
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
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
                                case "math53": { res1 = math53.struve_m(n, x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.struve_m(n, x); break; }
                                case "dflint": { res1 = dflint.struve_m(n, x); break; }
                                case "eflint": { res1 = eflint.struve_m(n, x); break; }
                                case "qflint": { res1 = qflint.struve_m(n, x); break; }
                                case "oflint": { res1 = oflint.struve_m(n, x); break; }
                                case "mflint": { res1 = mflint.struve_m(n, x); break; }
                                case "aflint": { res1 = aflint.struve_m(n, x); break; }
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
                //InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                //InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
                InputArrayInt1 = new[] { 10 };
                InputArray1 = new[] {3.0 };
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
                                case "math53": { res1 = math53.anger_j(n, x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.anger_j(n, x); break; }
                                case "dflint": { res1 = dflint.anger_j(n, x); break; }
                                case "eflint": { res1 = eflint.anger_j(n, x); break; }
                                case "qflint": { res1 = qflint.anger_j(n, x); break; }
                                case "oflint": { res1 = oflint.anger_j(n, x); break; }
                                case "mflint": { res1 = mflint.anger_j(n, x); break; }
                                case "aflint": { res1 = aflint.anger_j(n, x); break; }
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
                //InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                //InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
                InputArrayInt1 = new[] { 10 };
                InputArray1 = new[] { 3.0 };
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
                                case "math53": { res1 = math53.weber_e(n, x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.weber_e(n, x); break; }
                                case "dflint": { res1 = dflint.weber_e(n, x); break; }
                                case "eflint": { res1 = eflint.weber_e(n, x); break; }
                                case "qflint": { res1 = qflint.weber_e(n, x); break; }
                                case "oflint": { res1 = oflint.weber_e(n, x); break; }
                                case "mflint": { res1 = mflint.weber_e(n, x); break; }
                                case "aflint": { res1 = aflint.weber_e(n, x); break; }
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
                //InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                //InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                //InputArray3 = new[] { -1.5d, 0.0d, 1.5d };
                InputArray1 = new[] { 11.3 };
                InputArray2 = new[] { 2.7 };
                InputArray3 = new[] { 0.3, 3 };
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
                                    case "math53": { res1 = math53.lommel_s1(mu, nu, x); break; }
#if HasArbPrecNet
                                    case "sflint": { res1 = sflint.lommel_s1(mu, nu, x); break; }
                                    case "dflint": { res1 = dflint.lommel_s1(mu, nu, x); break; }
                                    case "eflint": { res1 = eflint.lommel_s1(mu, nu, x); break; }
                                    case "qflint": { res1 = qflint.lommel_s1(mu, nu, x); break; }
                                    case "oflint": { res1 = oflint.lommel_s1(mu, nu, x); break; }
                                    case "mflint": { res1 = mflint.lommel_s1(mu, nu, x); break; }
                                    case "aflint": { res1 = aflint.lommel_s1(mu, nu, x); break; }
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
                //InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                //InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                //InputArray3 = new[] { -1.5d, 0.0d, 1.5d };
                InputArray1 = new[] { 11.3 };
                InputArray2 = new[] { 2.7 };
                InputArray3 = new[] { 0.3 };
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
                                    case "math53": { res1 = math53.lommel_s2(mu, nu, x); break; }
#if HasArbPrecNet
                                    case "sflint": { res1 = sflint.lommel_s2(mu, nu, x); break; }
                                    case "dflint": { res1 = dflint.lommel_s2(mu, nu, x); break; }
                                    case "eflint": { res1 = eflint.lommel_s2(mu, nu, x); break; }
                                    case "qflint": { res1 = qflint.lommel_s2(mu, nu, x); break; }
                                    case "oflint": { res1 = oflint.lommel_s2(mu, nu, x); break; }
                                    case "mflint": { res1 = mflint.lommel_s2(mu, nu, x); break; }
                                    case "aflint": { res1 = aflint.lommel_s2(mu, nu, x); break; }
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








        public static void RealHypergeometric_pFq()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTests_RealHypergeometric_pFq();
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