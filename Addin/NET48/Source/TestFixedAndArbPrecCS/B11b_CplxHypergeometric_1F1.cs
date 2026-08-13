using System;
using System.Numerics;
using System.Diagnostics;
using System.Linq;
using FixedPrecNet;


#if HasArbPrecNet
using ArbPrecNet;
#endif




namespace TestXlCalcNetPrecCS
{

    static partial class Tests
    {



        public static void RunTests_CplxHypergeometric_1F1()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(80);
#endif
            string[] NTA1 = new[] { "cmath53"};
            string[] NTA2 = new[] { "sflintc", "dflintc", "eflintc", "qflintc", "oflintc", "mflintc", "aflintc" };

            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();
            //string[] NumTypeArray = NTA1.Concat(NTA2).Concat(NTA3).ToArray();


            //string[] FunctionArray = new[] { "all" };
            string[] FunctionArray = new[] { "cosh_integral" };

            DemoChapterCplx1F1(NumTypeArray, FunctionArray);

        }




        public static void DemoChapterCplx1F1(string[] NumTypeArray, string[] FunctionArray)
        {

            Complex[] InputArray1;
            Complex[] InputArray2;
            Complex[] InputArray3;


            #region 1F1 Overview


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_1f1"))
            {
                string name = "hyperg_1f1";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
                InputArray2 = new[] { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray3 = new[] {dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2)  };
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
                                    case "cmath53": { res1 = cmath53.hyperg_1f1(a, b, x); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.hyperg_1f1(a, b, x); break; }
                                    case "dflintc": { res1 = dflintc.hyperg_1f1(a, b, x); break; }
                                    case "eflintc": { res1 = eflintc.hyperg_1f1(a, b, x); break; }
                                    case "qflintc": { res1 = qflintc.hyperg_1f1(a, b, x); break; }
                                    case "oflintc": { res1 = oflintc.hyperg_1f1(a, b, x); break; }
                                    case "mflintc": { res1 = mflintc.hyperg_1f1(a, b, x); break; }
                                    case "aflintc": { res1 = aflintc.hyperg_1f1(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_1f1r"))
            {
                string name = "hyperg_1f1r";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
                InputArray2 = new[] { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray3 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
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
                                    case "cmath53": { res1 = cmath53.hyperg_1f1r(a, b, x); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.hyperg_1f1r(a, b, x); break; }
                                    case "dflintc": { res1 = dflintc.hyperg_1f1r(a, b, x); break; }
                                    case "eflintc": { res1 = eflintc.hyperg_1f1r(a, b, x); break; }
                                    case "qflintc": { res1 = qflintc.hyperg_1f1r(a, b, x); break; }
                                    case "oflintc": { res1 = oflintc.hyperg_1f1r(a, b, x); break; }
                                    case "mflintc": { res1 = mflintc.hyperg_1f1r(a, b, x); break; }
                                    case "aflintc": { res1 = aflintc.hyperg_1f1r(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_u"))
            {
                string name = "hyperg_u";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
                InputArray2 = new[] { 2d, 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray3 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
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
                                    case "cmath53": { res1 = cmath53.hyperg_u(a, b, x); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.hyperg_u(a, b, x); break; }
                                    case "dflintc": { res1 = dflintc.hyperg_u(a, b, x); break; }
                                    case "eflintc": { res1 = eflintc.hyperg_u(a, b, x); break; }
                                    case "qflintc": { res1 = qflintc.hyperg_u(a, b, x); break; }
                                    case "oflintc": { res1 = oflintc.hyperg_u(a, b, x); break; }
                                    case "mflintc": { res1 = mflintc.hyperg_u(a, b, x); break; }
                                    case "aflintc": { res1 = aflintc.hyperg_u(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("laguerre_l"))
            {
                string name = "laguerre_l";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
                InputArray2 = new[] { 2d, 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray3 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var n in InputArray1)
                {
                    foreach (var a in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(n={0}, a={1}, x={2})", n, a, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "cmath53": { res1 = cmath53.laguerre_l(n, a, x); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.laguerre_l(n, a, x); break; }
                                    case "dflintc": { res1 = dflintc.laguerre_l(n, a, x); break; }
                                    case "eflintc": { res1 = eflintc.laguerre_l(n, a, x); break; }
                                    case "qflintc": { res1 = qflintc.laguerre_l(n, a, x); break; }
                                    case "oflintc": { res1 = oflintc.laguerre_l(n, a, x); break; }
                                    case "mflintc": { res1 = mflintc.laguerre_l(n, a, x); break; }
                                    case "aflintc": { res1 = aflintc.laguerre_l(n, a, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hermite_h"))
            {
                string name = "hermite_h";
                InputArray1 = new[] { dcplx.t(-6), dcplx.t(-6.3), 0, 1, 2, 4, 6, 8, 10 };
                InputArray2 = new[] {0,  dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
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
                                case "cmath53": { res1 = cmath53.hermite_h(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.hermite_h(n, x); break; }
                                case "dflintc": { res1 = dflintc.hermite_h(n, x); break; }
                                case "eflintc": { res1 = eflintc.hermite_h(n, x); break; }
                                case "qflintc": { res1 = qflintc.hermite_h(n, x); break; }
                                case "oflintc": { res1 = oflintc.hermite_h(n, x); break; }
                                case "mflintc": { res1 = mflintc.hermite_h(n, x); break; }
                                case "aflintc": { res1 = aflintc.hermite_h(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hermite_he"))
            {
                string name = "hermite_he";
                InputArray1 = new[] { dcplx.t(-6), dcplx.t(-6.3), 0, 1, 2, 4, 6, 8, 10 };
                InputArray2 = new[] { 0, dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
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
                                case "cmath53": { res1 = cmath53.hermite_he(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.hermite_he(n, x); break; }
                                case "dflintc": { res1 = dflintc.hermite_he(n, x); break; }
                                case "eflintc": { res1 = eflintc.hermite_he(n, x); break; }
                                case "qflintc": { res1 = qflintc.hermite_he(n, x); break; }
                                case "oflintc": { res1 = oflintc.hermite_he(n, x); break; }
                                case "mflintc": { res1 = mflintc.hermite_he(n, x); break; }
                                case "aflintc": { res1 = aflintc.hermite_he(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Incomplete gamma functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_p"))
            {
                string name = "gamma_p";
                InputArray1 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.gamma_p(a, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.gamma_p(a, x); break; }
                                case "dflintc": { res1 = dflintc.gamma_p(a, x); break; }
                                case "eflintc": { res1 = eflintc.gamma_p(a, x); break; }
                                case "qflintc": { res1 = qflintc.gamma_p(a, x); break; }
                                case "oflintc": { res1 = oflintc.gamma_p(a, x); break; }
                                case "mflintc": { res1 = mflintc.gamma_p(a, x); break; }
                                case "aflintc": { res1 = aflintc.gamma_p(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_q"))
            {
                string name = "gamma_q";
                InputArray1 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.gamma_q(a, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.gamma_q(a, x); break; }
                                case "dflintc": { res1 = dflintc.gamma_q(a, x); break; }
                                case "eflintc": { res1 = eflintc.gamma_q(a, x); break; }
                                case "qflintc": { res1 = qflintc.gamma_q(a, x); break; }
                                case "oflintc": { res1 = oflintc.gamma_q(a, x); break; }
                                case "mflintc": { res1 = mflintc.gamma_q(a, x); break; }
                                case "aflintc": { res1 = aflintc.gamma_q(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_lower"))
            {
                string name = "gamma_lower";
                InputArray1 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.gamma_lower(a, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.gamma_lower(a, x); break; }
                                case "dflintc": { res1 = dflintc.gamma_lower(a, x); break; }
                                case "eflintc": { res1 = eflintc.gamma_lower(a, x); break; }
                                case "qflintc": { res1 = qflintc.gamma_lower(a, x); break; }
                                case "oflintc": { res1 = oflintc.gamma_lower(a, x); break; }
                                case "mflintc": { res1 = mflintc.gamma_lower(a, x); break; }
                                case "aflintc": { res1 = aflintc.gamma_lower(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_upper"))
            {
                string name = "gamma_upper";
                InputArray1 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.gamma_upper(a, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.gamma_upper(a, x); break; }
                                case "dflintc": { res1 = dflintc.gamma_upper(a, x); break; }
                                case "eflintc": { res1 = eflintc.gamma_upper(a, x); break; }
                                case "qflintc": { res1 = qflintc.gamma_upper(a, x); break; }
                                case "oflintc": { res1 = oflintc.gamma_upper(a, x); break; }
                                case "mflintc": { res1 = mflintc.gamma_upper(a, x); break; }
                                case "aflintc": { res1 = aflintc.gamma_upper(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_p_prime"))
            {
                string name = "gamma_p_prime";
                InputArray1 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.gamma_p_prime(a, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.gamma_p_prime(a, x); break; }
                                case "dflintc": { res1 = dflintc.gamma_p_prime(a, x); break; }
                                case "eflintc": { res1 = eflintc.gamma_p_prime(a, x); break; }
                                case "qflintc": { res1 = qflintc.gamma_p_prime(a, x); break; }
                                case "oflintc": { res1 = oflintc.gamma_p_prime(a, x); break; }
                                case "mflintc": { res1 = mflintc.gamma_p_prime(a, x); break; }
                                case "aflintc": { res1 = aflintc.gamma_p_prime(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Coulomb, Whittaker and parabolic cylinder function


            if (FunctionArray.Contains("all") | FunctionArray.Contains("coulomb_f"))
            {
                string name = "coulomb_f";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
                InputArray2 = new[] { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray3 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var l in InputArray1)
                {
                    foreach (var eta in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(l={0}, eta={1}, x={2})", l, eta, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.coulomb_f(l, eta, x); break; }
                                    case "dflintc": { res1 = dflintc.coulomb_f(l, eta, x); break; }
                                    case "eflintc": { res1 = eflintc.coulomb_f(l, eta, x); break; }
                                    case "qflintc": { res1 = qflintc.coulomb_f(l, eta, x); break; }
                                    case "oflintc": { res1 = oflintc.coulomb_f(l, eta, x); break; }
                                    case "mflintc": { res1 = mflintc.coulomb_f(l, eta, x); break; }
                                    case "aflintc": { res1 = aflintc.coulomb_f(l, eta, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("coulomb_g"))
            {
                string name = "coulomb_g";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
                InputArray2 = new[] { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray3 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var l in InputArray1)
                {
                    foreach (var eta in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(l={0}, eta={1}, x={2})", l, eta, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.coulomb_g(l, eta, x); break; }
                                    case "dflintc": { res1 = dflintc.coulomb_g(l, eta, x); break; }
                                    case "eflintc": { res1 = eflintc.coulomb_g(l, eta, x); break; }
                                    case "qflintc": { res1 = qflintc.coulomb_g(l, eta, x); break; }
                                    case "oflintc": { res1 = oflintc.coulomb_g(l, eta, x); break; }
                                    case "mflintc": { res1 = mflintc.coulomb_g(l, eta, x); break; }
                                    case "aflintc": { res1 = aflintc.coulomb_g(l, eta, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("coulomb_hpos"))
            {
                string name = "coulomb_hpos";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
                InputArray2 = new[] { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray3 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var l in InputArray1)
                {
                    foreach (var eta in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(l={0}, eta={1}, x={2})", l, eta, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.coulomb_hpos(l, eta, x); break; }
                                    case "dflintc": { res1 = dflintc.coulomb_hpos(l, eta, x); break; }
                                    case "eflintc": { res1 = eflintc.coulomb_hpos(l, eta, x); break; }
                                    case "qflintc": { res1 = qflintc.coulomb_hpos(l, eta, x); break; }
                                    case "oflintc": { res1 = oflintc.coulomb_hpos(l, eta, x); break; }
                                    case "mflintc": { res1 = mflintc.coulomb_hpos(l, eta, x); break; }
                                    case "aflintc": { res1 = aflintc.coulomb_hpos(l, eta, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("coulomb_hneg"))
            {
                string name = "coulomb_hneg";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
                InputArray2 = new[] { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray3 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var l in InputArray1)
                {
                    foreach (var eta in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(l={0}, eta={1}, x={2})", l, eta, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.coulomb_hneg(l, eta, x); break; }
                                    case "dflintc": { res1 = dflintc.coulomb_hneg(l, eta, x); break; }
                                    case "eflintc": { res1 = eflintc.coulomb_hneg(l, eta, x); break; }
                                    case "qflintc": { res1 = qflintc.coulomb_hneg(l, eta, x); break; }
                                    case "oflintc": { res1 = oflintc.coulomb_hneg(l, eta, x); break; }
                                    case "mflintc": { res1 = mflintc.coulomb_hneg(l, eta, x); break; }
                                    case "aflintc": { res1 = aflintc.coulomb_hneg(l, eta, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }




            if (FunctionArray.Contains("all") | FunctionArray.Contains("whittaker_m"))
            {
                string name = "whittaker_m";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
                InputArray2 = new[] { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray3 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var k in InputArray1)
                {
                    foreach (var m in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(k={0}, m={1}, x={2})", k, m, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.whittaker_m(k, m, x); break; }
                                    case "dflintc": { res1 = dflintc.whittaker_m(k, m, x); break; }
                                    case "eflintc": { res1 = eflintc.whittaker_m(k, m, x); break; }
                                    case "qflintc": { res1 = qflintc.whittaker_m(k, m, x); break; }
                                    case "oflintc": { res1 = oflintc.whittaker_m(k, m, x); break; }
                                    case "mflintc": { res1 = mflintc.whittaker_m(k, m, x); break; }
                                    case "aflintc": { res1 = aflintc.whittaker_m(k, m, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("whittaker_w"))
            {
                string name = "whittaker_w";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
                InputArray2 = new[] { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
                InputArray3 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var k in InputArray1)
                {
                    foreach (var m in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(k={0}, m={1}, x={2})", k, m, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.whittaker_w(k, m, x); break; }
                                    case "dflintc": { res1 = dflintc.whittaker_w(k, m, x); break; }
                                    case "eflintc": { res1 = eflintc.whittaker_w(k, m, x); break; }
                                    case "qflintc": { res1 = qflintc.whittaker_w(k, m, x); break; }
                                    case "oflintc": { res1 = oflintc.whittaker_w(k, m, x); break; }
                                    case "mflintc": { res1 = mflintc.whittaker_w(k, m, x); break; }
                                    case "aflintc": { res1 = aflintc.whittaker_w(k, m, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("pcfd"))
            {
                string name = "pcfd";
                InputArray1 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.pcfd(a, x); break; }
                                case "dflintc": { res1 = dflintc.pcfd(a, x); break; }
                                case "eflintc": { res1 = eflintc.pcfd(a, x); break; }
                                case "qflintc": { res1 = qflintc.pcfd(a, x); break; }
                                case "oflintc": { res1 = oflintc.pcfd(a, x); break; }
                                case "mflintc": { res1 = mflintc.pcfd(a, x); break; }
                                case "aflintc": { res1 = aflintc.pcfd(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pcfu"))
            {
                string name = "pcfu";
                InputArray1 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.pcfu(a, x); break; }
                                case "dflintc": { res1 = dflintc.pcfu(a, x); break; }
                                case "eflintc": { res1 = eflintc.pcfu(a, x); break; }
                                case "qflintc": { res1 = qflintc.pcfu(a, x); break; }
                                case "oflintc": { res1 = oflintc.pcfu(a, x); break; }
                                case "mflintc": { res1 = mflintc.pcfu(a, x); break; }
                                case "aflintc": { res1 = aflintc.pcfu(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pcfv"))
            {
                string name = "pcfv";
                InputArray1 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.pcfv(a, x); break; }
                                case "dflintc": { res1 = dflintc.pcfv(a, x); break; }
                                case "eflintc": { res1 = eflintc.pcfv(a, x); break; }
                                case "qflintc": { res1 = qflintc.pcfv(a, x); break; }
                                case "oflintc": { res1 = oflintc.pcfv(a, x); break; }
                                case "mflintc": { res1 = mflintc.pcfv(a, x); break; }
                                case "aflintc": { res1 = aflintc.pcfv(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pcfw"))
            {
                string name = "pcfw";
                InputArray1 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.pcfw(a, x); break; }
                                case "dflintc": { res1 = dflintc.pcfw(a, x); break; }
                                case "eflintc": { res1 = eflintc.pcfw(a, x); break; }
                                case "qflintc": { res1 = qflintc.pcfw(a, x); break; }
                                case "oflintc": { res1 = oflintc.pcfw(a, x); break; }
                                case "mflintc": { res1 = mflintc.pcfw(a, x); break; }
                                case "aflintc": { res1 = aflintc.pcfw(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }





            #endregion



            #region Error functions and related functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("erf"))
            {
                string name = "erf";
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.erf(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.erf(x); break; }
                            case "dflintc": { res1 = dflintc.erf(x); break; }
                            case "eflintc": { res1 = eflintc.erf(x); break; }
                            case "qflintc": { res1 = qflintc.erf(x); break; }
                            case "oflintc": { res1 = oflintc.erf(x); break; }
                            case "mflintc": { res1 = mflintc.erf(x); break; }
                            case "aflintc": { res1 = aflintc.erf(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("erfc"))
            {
                string name = "erfc";
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.erfc(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.erfc(x); break; }
                            case "dflintc": { res1 = dflintc.erfc(x); break; }
                            case "eflintc": { res1 = eflintc.erfc(x); break; }
                            case "qflintc": { res1 = qflintc.erfc(x); break; }
                            case "oflintc": { res1 = oflintc.erfc(x); break; }
                            case "mflintc": { res1 = mflintc.erfc(x); break; }
                            case "aflintc": { res1 = aflintc.erfc(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("erfi"))
            {
                string name = "erfi";
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            //case "cmath53": { res1 = cmath53.erfi(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.erfi(x); break; }
                            case "dflintc": { res1 = dflintc.erfi(x); break; }
                            case "eflintc": { res1 = eflintc.erfi(x); break; }
                            case "qflintc": { res1 = qflintc.erfi(x); break; }
                            case "oflintc": { res1 = oflintc.erfi(x); break; }
                            case "mflintc": { res1 = mflintc.erfi(x); break; }
                            case "aflintc": { res1 = aflintc.erfi(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("dawson"))
            {
                string name = "dawson";
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.dawson(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.dawson(x); break; }
                            case "dflintc": { res1 = dflintc.dawson(x); break; }
                            case "eflintc": { res1 = eflintc.dawson(x); break; }
                            case "qflintc": { res1 = qflintc.dawson(x); break; }
                            case "oflintc": { res1 = oflintc.dawson(x); break; }
                            case "mflintc": { res1 = mflintc.dawson(x); break; }
                            case "aflintc": { res1 = aflintc.dawson(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("faddeeva"))
            {
                string name = "faddeeva";
                InputArray1 = new[] { dcplx.t(-4.333d, -2), dcplx.t(0.0d, -2), dcplx.t(4.333d, -2), dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.faddeeva(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.faddeeva(x); break; }
                            case "dflintc": { res1 = dflintc.faddeeva(x); break; }
                            case "eflintc": { res1 = eflintc.faddeeva(x); break; }
                            case "qflintc": { res1 = qflintc.faddeeva(x); break; }
                            case "oflintc": { res1 = oflintc.faddeeva(x); break; }
                            case "mflintc": { res1 = mflintc.faddeeva(x); break; }
                            case "aflintc": { res1 = aflintc.faddeeva(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("fresnel_s"))
            {
                string name = "fresnel_s";
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.fresnel_c(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.fresnel_s(x); break; }
                            case "dflintc": { res1 = dflintc.fresnel_s(x); break; }
                            case "eflintc": { res1 = eflintc.fresnel_s(x); break; }
                            case "qflintc": { res1 = qflintc.fresnel_s(x); break; }
                            case "oflintc": { res1 = oflintc.fresnel_s(x); break; }
                            case "mflintc": { res1 = mflintc.fresnel_s(x); break; }
                            case "aflintc": { res1 = aflintc.fresnel_s(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("fresnel_c"))
            {
                string name = "fresnel_c";
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.fresnel_s(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.fresnel_c(x); break; }
                            case "dflintc": { res1 = dflintc.fresnel_c(x); break; }
                            case "eflintc": { res1 = eflintc.fresnel_c(x); break; }
                            case "qflintc": { res1 = qflintc.fresnel_c(x); break; }
                            case "oflintc": { res1 = oflintc.fresnel_c(x); break; }
                            case "mflintc": { res1 = mflintc.fresnel_c(x); break; }
                            case "aflintc": { res1 = aflintc.fresnel_c(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ndens"))
            {
                string name = "ndens";
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.ndens(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.ndens(x); break; }
                            case "dflintc": { res1 = dflintc.ndens(x); break; }
                            case "eflintc": { res1 = eflintc.ndens(x); break; }
                            case "qflintc": { res1 = qflintc.ndens(x); break; }
                            case "oflintc": { res1 = oflintc.ndens(x); break; }
                            case "mflintc": { res1 = mflintc.ndens(x); break; }
                            case "aflintc": { res1 = aflintc.ndens(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ndis"))
            {
                string name = "ndis";
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.ndis(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.ndis(x); break; }
                            case "dflintc": { res1 = dflintc.ndis(x); break; }
                            case "eflintc": { res1 = eflintc.ndis(x); break; }
                            case "qflintc": { res1 = qflintc.ndis(x); break; }
                            case "oflintc": { res1 = oflintc.ndis(x); break; }
                            case "mflintc": { res1 = mflintc.ndis(x); break; }
                            case "aflintc": { res1 = aflintc.ndis(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Exponential integrals and related functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp_integral_e1"))
            {
                string name = "exp_integral_e1";
                InputArray1 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.exp_integral_e1(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.exp_integral_e1(x); break; }
                            case "dflintc": { res1 = dflintc.exp_integral_e1(x); break; }
                            case "eflintc": { res1 = eflintc.exp_integral_e1(x); break; }
                            case "qflintc": { res1 = qflintc.exp_integral_e1(x); break; }
                            case "oflintc": { res1 = oflintc.exp_integral_e1(x); break; }
                            case "mflintc": { res1 = mflintc.exp_integral_e1(x); break; }
                            case "aflintc": { res1 = aflintc.exp_integral_e1(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp_integral_ei"))
            {
                string name = "exp_integral_ei";
                InputArray1 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.exp_integral_ei(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.exp_integral_ei(x); break; }
                            case "dflintc": { res1 = dflintc.exp_integral_ei(x); break; }
                            case "eflintc": { res1 = eflintc.exp_integral_ei(x); break; }
                            case "qflintc": { res1 = qflintc.exp_integral_ei(x); break; }
                            case "oflintc": { res1 = oflintc.exp_integral_ei(x); break; }
                            case "mflintc": { res1 = mflintc.exp_integral_ei(x); break; }
                            case "aflintc": { res1 = aflintc.exp_integral_ei(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log_integral"))
            {
                string name = "log_integral";
                InputArray1 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.log_integral(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.log_integral(x); break; }
                            case "dflintc": { res1 = dflintc.log_integral(x); break; }
                            case "eflintc": { res1 = eflintc.log_integral(x); break; }
                            case "qflintc": { res1 = qflintc.log_integral(x); break; }
                            case "oflintc": { res1 = oflintc.log_integral(x); break; }
                            case "mflintc": { res1 = mflintc.log_integral(x); break; }
                            case "aflintc": { res1 = aflintc.log_integral(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cosh_integral"))
            {
                string name = "cosh_integral";
                InputArray1 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.cosh_integral(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.cosh_integral(x); break; }
                            case "dflintc": { res1 = dflintc.cosh_integral(x); break; }
                            case "eflintc": { res1 = eflintc.cosh_integral(x); break; }
                            case "qflintc": { res1 = qflintc.cosh_integral(x); break; }
                            case "oflintc": { res1 = oflintc.cosh_integral(x); break; }
                            case "mflintc": { res1 = mflintc.cosh_integral(x); break; }
                            case "aflintc": { res1 = aflintc.cosh_integral(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sinh_integral"))
            {
                string name = "sinh_integral";
                InputArray1 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.sinh_integral(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.sinh_integral(x); break; }
                            case "dflintc": { res1 = dflintc.sinh_integral(x); break; }
                            case "eflintc": { res1 = eflintc.sinh_integral(x); break; }
                            case "qflintc": { res1 = qflintc.sinh_integral(x); break; }
                            case "oflintc": { res1 = oflintc.sinh_integral(x); break; }
                            case "mflintc": { res1 = mflintc.sinh_integral(x); break; }
                            case "aflintc": { res1 = aflintc.sinh_integral(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp_integral_en"))
            {
                string name = "exp_integral_en";
                InputArray1 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(1.0), 1.5d, 4.333d };
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
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.exp_integral_en(n, x); break; }
                                case "dflintc": { res1 = dflintc.exp_integral_en(n, x); break; }
                                case "eflintc": { res1 = eflintc.exp_integral_en(n, x); break; }
                                case "qflintc": { res1 = qflintc.exp_integral_en(n, x); break; }
                                case "oflintc": { res1 = oflintc.exp_integral_en(n, x); break; }
                                case "mflintc": { res1 = mflintc.exp_integral_en(n, x); break; }
                                case "aflintc": { res1 = aflintc.exp_integral_en(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cos_integral"))
            {
                string name = "cos_integral";
                InputArray1 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.cos_integral(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.cos_integral(x); break; }
                            case "dflintc": { res1 = dflintc.cos_integral(x); break; }
                            case "eflintc": { res1 = eflintc.cos_integral(x); break; }
                            case "qflintc": { res1 = qflintc.cos_integral(x); break; }
                            case "oflintc": { res1 = oflintc.cos_integral(x); break; }
                            case "mflintc": { res1 = mflintc.cos_integral(x); break; }
                            case "aflintc": { res1 = aflintc.cos_integral(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sin_integral"))
            {
                string name = "sin_integral";
                InputArray1 = new[] { dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), dcplx.t(1.5d, 2) };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.sin_integral(x); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.sin_integral(x); break; }
                            case "dflintc": { res1 = dflintc.sin_integral(x); break; }
                            case "eflintc": { res1 = eflintc.sin_integral(x); break; }
                            case "qflintc": { res1 = qflintc.sin_integral(x); break; }
                            case "oflintc": { res1 = oflintc.sin_integral(x); break; }
                            case "mflintc": { res1 = mflintc.sin_integral(x); break; }
                            case "aflintc": { res1 = aflintc.sin_integral(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }




            #endregion




        }








        public static void CplxHypergeometric_1F1()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTests_CplxHypergeometric_1F1();
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