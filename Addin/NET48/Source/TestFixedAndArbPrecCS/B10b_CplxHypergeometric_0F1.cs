
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

        public static void RunTests_CplxHypergeometric_0F1()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(70);
#endif
            string[] NTA1 = new[] { "cmath53" };
            string[] NTA2 = new[] { "sflintc", "dflintc", "eflintc", "qflintc", "oflintc", "mflintc", "aflintc" };
            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();

            //string[] FunctionArray = new[] { "all" };
            string[] FunctionArray = new[] { "besseltheta" };

            bool scaled = false;

            DemoChapterCplx0F1(NumTypeArray, FunctionArray, scaled);

        }




        public static void DemoChapterCplx0F1(string[] NumTypeArray, string[] FunctionArray, bool scaled)
        {

            Complex[] InputArray1;
            Complex[] InputArray2;
            double[] InputArrayReal1;
            int[] InputArrayInt1;


            #region 0F1: Overview



            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_0f1"))
            {
                string name = "hyperg_0f1";
                InputArray1 = new[] { 0.1, 0.75d, 1.5d, dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                InputArray2 = new[] { dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                foreach (var b in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(b={0}, x={1})", b, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.hyperg_0f1(b, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.hyperg_0f1(b, x); break; }
                                case "dflintc": { res1 = dflintc.hyperg_0f1(b, x); break; }
                                case "eflintc": { res1 = eflintc.hyperg_0f1(b, x); break; }
                                case "qflintc": { res1 = qflintc.hyperg_0f1(b, x); break; }
                                case "oflintc": { res1 = oflintc.hyperg_0f1(b, x); break; }
                                case "mflintc": { res1 = mflintc.hyperg_0f1(b, x); break; }
                                case "aflintc": { res1 = aflintc.hyperg_0f1(b, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_0f1r"))
            {
                string name = "hyperg_0f1r";
                InputArray1 = new[] { 0.1, 0.75d, 1.5d, dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                InputArray2 = new[] { dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                foreach (var b in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(b={0}, x={1})", b, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.hyperg_0f1r(b, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.hyperg_0f1r(b, x); break; }
                                case "dflintc": { res1 = dflintc.hyperg_0f1r(b, x); break; }
                                case "eflintc": { res1 = eflintc.hyperg_0f1r(b, x); break; }
                                case "qflintc": { res1 = qflintc.hyperg_0f1r(b, x); break; }
                                case "oflintc": { res1 = oflintc.hyperg_0f1r(b, x); break; }
                                case "mflintc": { res1 = mflintc.hyperg_0f1r(b, x); break; }
                                case "aflintc": { res1 = aflintc.hyperg_0f1r(b, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            #endregion



            #region Bessel functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_jv"))
            {
                string name = "bessel_jv";
                InputArray1 = new[] { -1.5, -1.0, 0.0, 0.75d, 1.5d, dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                InputArray2 = new[] { dcplx.t(-2.0, 0), dcplx.t(2.0, 0), dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                foreach (var x in InputArray2)
                {
                    foreach (var nu in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.bessel_jv(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.bessel_jv(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.bessel_jv(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.bessel_jv(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.bessel_jv(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.bessel_jv(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.bessel_jv(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.bessel_jv(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_yv"))
            {
                string name = "bessel_yv";
                InputArray1 = new[] { -1.5, -1.0, 0.0, 0.75d, 1.5d, dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                InputArray2 = new[] { dcplx.t(-2.0, 0), dcplx.t(2.0, 0), dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.bessel_yv(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.bessel_yv(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.bessel_yv(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.bessel_yv(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.bessel_yv(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.bessel_yv(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.bessel_yv(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.bessel_yv(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_jv_prime"))
            {
                string name = "bessel_jv_prime";
                InputArray1 = new[] { -1.5, -1.0, 0.0, 0.75d, 1.5d, dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                InputArray2 = new[] { dcplx.t(-2.0, 0), dcplx.t(2.0, 0), dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.bessel_jv_prime(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.bessel_jv_prime(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.bessel_jv_prime(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.bessel_jv_prime(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.bessel_jv_prime(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.bessel_jv_prime(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.bessel_jv_prime(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.bessel_jv_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_yv_prime"))
            {
                string name = "bessel_yv_prime";
                InputArray1 = new[] { -1.5, -1.0, 0.0, 0.75d, 1.5d, dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                InputArray2 = new[] { dcplx.t(-2.0, 0), dcplx.t(2.0, 0), dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.bessel_yv_prime(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.bessel_yv_prime(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.bessel_yv_prime(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.bessel_yv_prime(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.bessel_yv_prime(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.bessel_yv_prime(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.bessel_yv_prime(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.bessel_yv_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Modified Bessel functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_iv"))
            {
                string name = "bessel_iv";
                InputArray1 = new[] { -1.5, -1.0, 0.0, 0.75d, 1.5d, dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                InputArray2 = new[] { dcplx.t(-2.0, 0), dcplx.t(2.0, 0), dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(100.5d, 2) };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.bessel_iv(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.bessel_iv(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.bessel_iv(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.bessel_iv(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.bessel_iv(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.bessel_iv(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.bessel_iv(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.bessel_iv(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_kv"))
            {
                string name = "bessel_kv";
                InputArray1 = new[] { -1.5, -1.0, 0.0, 0.75d, 1.5d, dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                InputArray2 = new[] { dcplx.t(-2.0, 0), dcplx.t(2.0, 0), dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(100.5d, 2) };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.bessel_kv(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.bessel_kv(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.bessel_kv(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.bessel_kv(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.bessel_kv(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.bessel_kv(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.bessel_kv(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.bessel_kv(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_iv_prime"))
            {
                string name = "bessel_iv_prime";
                InputArray1 = new[] { -1.5, -1.0, 0.0, 0.75d, 1.5d, dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                InputArray2 = new[] { dcplx.t(-2.0, 0), dcplx.t(2.0, 0), dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(100.5d, 2) };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.bessel_iv_prime(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.bessel_iv_prime(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.bessel_iv_prime(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.bessel_iv_prime(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.bessel_iv_prime(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.bessel_iv_prime(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.bessel_iv_prime(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.bessel_iv_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_kv_prime"))
            {
                string name = "bessel_kv_prime";
                InputArray1 = new[] { -1.5, -1.0, 0.0, 0.75d, 1.5d, dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                InputArray2 = new[] { dcplx.t(-2.0, 0), dcplx.t(2.0, 0), dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(100.5d, 2) };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.bessel_kv_prime(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.bessel_kv_prime(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.bessel_kv_prime(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.bessel_kv_prime(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.bessel_kv_prime(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.bessel_kv_prime(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.bessel_kv_prime(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.bessel_kv_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Spherical Bessel functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_jn"))
            {
                string name = "sph_bessel_jn";
                InputArrayInt1 = new[] { -4, -1, 0, 1, 2, 4 };
                InputArray1 = new[] { dcplx.t(-4.0), dcplx.t(-1.0), dcplx.t(0.000000001d), dcplx.t(1.0) };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.sph_bessel_jn(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.sph_bessel_jn(n, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.sph_bessel_jn(n, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.sph_bessel_jn(n, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.sph_bessel_jn(n, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.sph_bessel_jn(n, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.sph_bessel_jn(n, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.sph_bessel_jn(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_yn"))
            {
                string name = "sph_bessel_yn";
                InputArrayInt1 = new[] { -4, -1, 0, 1, 2, 4 };
                InputArray1 = new[] { dcplx.t(-4.0), dcplx.t(-1.0), dcplx.t(0.000000001d), dcplx.t(1.0) };
                foreach (var x in InputArray1)
                {
                    foreach (var n in InputArrayInt1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.sph_bessel_yn(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.sph_bessel_yn(n, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.sph_bessel_yn(n, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.sph_bessel_yn(n, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.sph_bessel_yn(n, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.sph_bessel_yn(n, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.sph_bessel_yn(n, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.sph_bessel_yn(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_jn_prime"))
            {
                string name = "sph_bessel_jn_prime";
                InputArray1 = new[] { dcplx.t(-0.5), dcplx.t(-0.50000000001), dcplx.t(-0.5000001), dcplx.t(-0.51), dcplx.t(-4.1, 1.5), dcplx.t(-1.1, 1.5), dcplx.t(0.1, 1.5), dcplx.t(1.1, 1.5), dcplx.t(2.1, 1.5), dcplx.t(4.1, 1.5) };
                InputArray2 = new[] { dcplx.t(-4.0, 2), dcplx.t(-1.0, 2), dcplx.t(1.0, 2), dcplx.t(4.0, 2) };
                foreach (var n in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.sph_bessel_jn_prime(n, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.sph_bessel_jn_prime(n, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.sph_bessel_jn_prime(n, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.sph_bessel_jn_prime(n, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.sph_bessel_jn_prime(n, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.sph_bessel_jn_prime(n, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.sph_bessel_jn_prime(n, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.sph_bessel_jn_prime(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_yn_prime"))
            {
                string name = "sph_bessel_jn_prime";
                InputArray1 = new[] { dcplx.t(-0.5), dcplx.t(-0.50000000001), dcplx.t(-0.5000001), dcplx.t(-0.51), dcplx.t(-4.1, 1.5), dcplx.t(-1.1, 1.5), dcplx.t(0.1, 1.5), dcplx.t(1.1, 1.5), dcplx.t(2.1, 1.5), dcplx.t(4.1, 1.5) };
                InputArray2 = new[] { dcplx.t(-4.0, 2), dcplx.t(-1.0, 2), dcplx.t(1.0, 2), dcplx.t(4.0, 2) };
                foreach (var n in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.sph_bessel_yn_prime(n, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.sph_bessel_yn_prime(n, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.sph_bessel_yn_prime(n, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.sph_bessel_yn_prime(n, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.sph_bessel_yn_prime(n, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.sph_bessel_yn_prime(n, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.sph_bessel_yn_prime(n, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.sph_bessel_yn_prime(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Modified Spherical Bessel functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_in"))
            {
                string name = "sph_bessel_in";
                InputArrayInt1 = new[] { -4, -1, 0, 1, 2, 4 };
                InputArray1 = new[] { dcplx.t(-4.0), dcplx.t(-1.0), dcplx.t(0.000000001d), dcplx.t(1.0) };
                foreach (var x in InputArray1)
                {
                    foreach (var n in InputArrayInt1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.sph_bessel_in(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.sph_bessel_in(n, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.sph_bessel_in(n, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.sph_bessel_in(n, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.sph_bessel_in(n, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.sph_bessel_in(n, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.sph_bessel_in(n, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.sph_bessel_in(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_kn"))
            {
                string name = "sph_bessel_kn";
                InputArrayInt1 = new[] { -4, -1, 0, 1, 2, 4 };
                InputArray1 = new[] { dcplx.t(-4.0), dcplx.t(-1.0), dcplx.t(0.000000001d), dcplx.t(1.0) };
                foreach (var x in InputArray1)
                {
                    foreach (var n in InputArrayInt1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.sph_bessel_kn(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.sph_bessel_kn(n, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.sph_bessel_kn(n, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.sph_bessel_kn(n, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.sph_bessel_kn(n, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.sph_bessel_kn(n, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.sph_bessel_kn(n, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.sph_bessel_kn(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_in_prime"))
            {
                string name = "sph_bessel_in_prime";
                InputArray1 = new[] { dcplx.t(-0.5), dcplx.t(-0.50000000001), dcplx.t(-0.5000001), dcplx.t(-0.51), dcplx.t(-4.1, 1.5), dcplx.t(-1.1, 1.5), dcplx.t(0.1, 1.5), dcplx.t(1.1, 1.5), dcplx.t(2.1, 1.5), dcplx.t(4.1, 1.5) };
                InputArray2 = new[] { dcplx.t(-4.0, 2), dcplx.t(-1.0, 2), dcplx.t(1.0, 2), dcplx.t(4.0, 2) };
                foreach (var n in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.sph_bessel_in_prime(n, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.sph_bessel_in_prime(n, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.sph_bessel_in_prime(n, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.sph_bessel_in_prime(n, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.sph_bessel_in_prime(n, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.sph_bessel_in_prime(n, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.sph_bessel_in_prime(n, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.sph_bessel_in_prime(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_kn_prime"))
            {
                string name = "sph_bessel_kn_prime";
                InputArray1 = new[] { dcplx.t(-0.5), dcplx.t(-0.50000000001), dcplx.t(-0.5000001), dcplx.t(-0.51), dcplx.t(-4.1, 1.5), dcplx.t(-1.1, 1.5), dcplx.t(0.1, 1.5), dcplx.t(1.1, 1.5), dcplx.t(2.1, 1.5), dcplx.t(4.1, 1.5) };
                InputArray2 = new[] { dcplx.t(-4.0, 2), dcplx.t(-1.0, 2), dcplx.t(1.0, 2), dcplx.t(4.0, 2) };
                foreach (var n in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.sph_bessel_kn_prime(n, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.sph_bessel_kn_prime(n, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.sph_bessel_kn_prime(n, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.sph_bessel_kn_prime(n, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.sph_bessel_kn_prime(n, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.sph_bessel_kn_prime(n, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.sph_bessel_kn_prime(n, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.sph_bessel_kn_prime(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            if (FunctionArray.Contains("all") | FunctionArray.Contains("besselpoly"))
            {
                string name = "besselpoly";
                InputArray1 = new[] { dcplx.t(-4), -3, -2, -1, 0, 1, 2, 3, 4 };
                InputArray2 = new[] { dcplx.t(-4.0), -2.0, -2.0, -1.0, -1E-8, 0.0, 1E-8, 1.0, 2.0, 1003.0 };
                foreach (var n in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.besselpoly(n, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.besselpoly(n, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.besselpoly(n, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.besselpoly(n, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.besselpoly(n, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.besselpoly(n, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.besselpoly(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("besseltheta"))
            {
                string name = "besseltheta";
                InputArray1 = new[] { dcplx.t(-4), -3, -2, -1, 0, 1, 2, 3, 4 };
                InputArray2 = new[] { dcplx.t(-4.0), -2.0, -2.0, -1.0, -1E-8, 0.0, 1E-8, 1.0, 2.0, 1003.0 };
                foreach (var n in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.besseltheta(n, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.besseltheta(n, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.besseltheta(n, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.besseltheta(n, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.besseltheta(n, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.besseltheta(n, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.besseltheta(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }





            #endregion



            #region Hankel functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hankel_h1"))
            {
                string name = "hankel_h1";
                InputArray1 = new[] { -1.5, -1.0, 0.0, 0.75d, 1.5d, dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                InputArray2 = new[] { dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.hankel_h1(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.hankel_h1(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.hankel_h1(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.hankel_h1(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.hankel_h1(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.hankel_h1(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.hankel_h1(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.hankel_h1(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hankel_h2"))
            {
                string name = "hankel_h2";
                InputArray1 = new[] { -1.5, -1.0, 0.0, 0.75d, 1.5d, dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                InputArray2 = new[] { dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), dcplx.t(1.5d, 2) };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.hankel_h2(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.hankel_h2(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.hankel_h2(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.hankel_h2(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.hankel_h2(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.hankel_h2(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.hankel_h2(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.hankel_h2(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_hankel_h1"))
            {
                string name = "sph_hankel_h1";
                InputArrayInt1 = new[] { -4, -1, 0, 1, 2, 4 };
                InputArray1 = new[] { dcplx.t(-4.0), dcplx.t(-1.0), dcplx.t(0.000000001d), dcplx.t(1.0) };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.sph_hankel_h1(n, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.sph_hankel_h1(n, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.sph_hankel_h1(n, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.sph_hankel_h1(n, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.sph_hankel_h1(n, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.sph_hankel_h1(n, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.sph_hankel_h1(n, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.sph_hankel_h1(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_hankel_h2"))
            {
                string name = "sph_hankel_h2";
                InputArrayInt1 = new[] { -4, -1, 0, 1, 2, 4 };
                InputArray1 = new[] { dcplx.t(-4.0), dcplx.t(-1.0), dcplx.t(0.000000001d), dcplx.t(1.0) };
                foreach (var x in InputArray1)
                {
                    foreach (var n in InputArrayInt1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.sph_hankel_h2(n, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.sph_hankel_h2(n, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.sph_hankel_h2(n, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.sph_hankel_h2(n, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.sph_hankel_h2(n, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.sph_hankel_h2(n, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.sph_hankel_h2(n, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.sph_hankel_h2(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion



            #region Airy functions

            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_ai"))
            {
                string name = "airy_ai";
                if (scaled) name += "_scaled";
                InputArray1 = new[] { dcplx.t(-5.5d, 2), dcplx.t(-1.75d, 2), dcplx.t(0.0d, 2), dcplx.t(1.75d, 2), dcplx.t(5.5d, 2), dcplx.t(105.5d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.airy_ai(x1, scaled); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.airy_ai(x1, scaled); break; }
                            case "dflintc": { res1 = dflintc.airy_ai(x1, scaled); break; }
                            case "eflintc": { res1 = eflintc.airy_ai(x1, scaled); break; }
                            case "qflintc": { res1 = qflintc.airy_ai(x1, scaled); break; }
                            case "oflintc": { res1 = oflintc.airy_ai(x1, scaled); break; }
                            case "mflintc": { res1 = mflintc.airy_ai(x1, scaled); break; }
                            case "aflintc": { res1 = aflintc.airy_ai(x1, scaled); break; }
#endif
                        }
                        //Console.WriteLine("{0}: airy_ai({1}): {2}", NumType, x1, res1);
                        Console.WriteLine("{0}: " + name + "({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_bi"))
            {
                string name = "airy_bi";
                if (scaled) name += "_scaled";
                InputArray1 = new[] { dcplx.t(-5.5d, 2), dcplx.t(-1.75d, 2), dcplx.t(0.0d, 2), dcplx.t(1.75d, 2), dcplx.t(5.5d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.airy_bi(x1, scaled); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.airy_bi(x1, scaled); break; }
                            case "dflintc": { res1 = dflintc.airy_bi(x1, scaled); break; }
                            case "eflintc": { res1 = eflintc.airy_bi(x1, scaled); break; }
                            case "qflintc": { res1 = qflintc.airy_bi(x1, scaled); break; }
                            case "oflintc": { res1 = oflintc.airy_bi(x1, scaled); break; }
                            case "mflintc": { res1 = mflintc.airy_bi(x1, scaled); break; }
                            case "aflintc": { res1 = aflintc.airy_bi(x1, scaled); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + name + "({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_ai_prime"))
            {
                string name = "airy_ai_prime";
                if (scaled) name += "_scaled";
                InputArray1 = new[] { dcplx.t(-5.5d, 2), dcplx.t(-1.75d, 2), dcplx.t(0.0d, 2), dcplx.t(1.75d, 2), dcplx.t(5.5d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.airy_ai_prime(x1, scaled); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.airy_ai_prime(x1, scaled); break; }
                            case "dflintc": { res1 = dflintc.airy_ai_prime(x1, scaled); break; }
                            case "eflintc": { res1 = eflintc.airy_ai_prime(x1, scaled); break; }
                            case "qflintc": { res1 = qflintc.airy_ai_prime(x1, scaled); break; }
                            case "oflintc": { res1 = oflintc.airy_ai_prime(x1, scaled); break; }
                            case "mflintc": { res1 = mflintc.airy_ai_prime(x1, scaled); break; }
                            case "aflintc": { res1 = aflintc.airy_ai_prime(x1, scaled); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + name + "({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_bi_prime"))
            {
                string name = "airy_bi_prime";
                if (scaled) name += "_scaled";
                InputArray1 = new[] { dcplx.t(-5.5d, 2), dcplx.t(-1.75d, 2), dcplx.t(0.0d, 2), dcplx.t(1.75d, 2), dcplx.t(5.5d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.airy_bi_prime(x1, scaled); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.airy_bi_prime(x1, scaled); break; }
                            case "dflintc": { res1 = dflintc.airy_bi_prime(x1, scaled); break; }
                            case "eflintc": { res1 = eflintc.airy_bi_prime(x1, scaled); break; }
                            case "qflintc": { res1 = qflintc.airy_bi_prime(x1, scaled); break; }
                            case "oflintc": { res1 = oflintc.airy_bi_prime(x1, scaled); break; }
                            case "mflintc": { res1 = mflintc.airy_bi_prime(x1, scaled); break; }
                            case "aflintc": { res1 = aflintc.airy_bi_prime(x1, scaled); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + name + "({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Kelvin functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_ber"))
            {
                string name = "kelvin_ber";
                InputArrayReal1 = new[] { -2.5, -1.5, 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-104.333d), dcplx.t(-1.5), dcplx.t(-1.0), dcplx.t(0.0d), dcplx.t(1.0d), dcplx.t(1.5d), dcplx.t(104.333d) };
                foreach (var nu in InputArrayReal1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.kelvin_ber(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.kelvin_ber(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.kelvin_ber(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.kelvin_ber(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.kelvin_ber(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.kelvin_ber(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.kelvin_ber(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.kelvin_ber(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_bei"))
            {
                string name = "kelvin_bei";
                InputArrayReal1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), dcplx.t(-1.5), dcplx.t(-1.0), dcplx.t(0.0d), dcplx.t(1.0d), dcplx.t(1.5d), dcplx.t(4.333d) };
                foreach (var nu in InputArrayReal1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.kelvin_bei(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.kelvin_bei(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.kelvin_bei(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.kelvin_bei(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.kelvin_bei(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.kelvin_bei(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.kelvin_bei(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.kelvin_bei(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_ker"))
            {
                string name = "kelvin_ker";
                InputArrayReal1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), dcplx.t(-1.5), dcplx.t(-1.0), dcplx.t(0.0d), dcplx.t(1.0d), dcplx.t(1.5d), dcplx.t(4.333d) };
                foreach (var nu in InputArrayReal1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.kelvin_ker(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.kelvin_ker(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.kelvin_ker(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.kelvin_ker(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.kelvin_ker(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.kelvin_ker(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.kelvin_ker(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.kelvin_ker(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_kei"))
            {
                string name = "kelvin_kei";
                InputArrayReal1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), dcplx.t(-1.5), dcplx.t(-1.0), dcplx.t(0.0d), dcplx.t(1.0d), dcplx.t(1.5d), dcplx.t(4.333d) };
                foreach (var nu in InputArrayReal1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.kelvin_kei(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.kelvin_kei(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.kelvin_kei(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.kelvin_kei(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.kelvin_kei(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.kelvin_kei(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.kelvin_kei(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.kelvin_kei(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }





            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_ber_prime"))
            {
                string name = "kelvin_ber_prime";
                InputArrayReal1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), dcplx.t(-1.5), dcplx.t(-1.0), dcplx.t(0.0d), dcplx.t(1.0d), dcplx.t(1.5d), dcplx.t(4.333d) };
                foreach (var nu in InputArrayReal1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.kelvin_ber_prime(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.kelvin_ber_prime(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.kelvin_ber_prime(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.kelvin_ber_prime(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.kelvin_ber_prime(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.kelvin_ber_prime(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.kelvin_ber_prime(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.kelvin_ber_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_bei_prime"))
            {
                string name = "kelvin_bei_prime";
                InputArrayReal1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), dcplx.t(-1.5), dcplx.t(-1.0), dcplx.t(0.0d), dcplx.t(1.0d), dcplx.t(1.5d), dcplx.t(4.333d) };
                foreach (var nu in InputArrayReal1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.kelvin_bei_prime(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.kelvin_bei_prime(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.kelvin_bei_prime(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.kelvin_bei_prime(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.kelvin_bei_prime(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.kelvin_bei_prime(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.kelvin_bei_prime(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.kelvin_bei_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_ker_prime"))
            {
                string name = "kelvin_ker_prime";
                InputArrayReal1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), dcplx.t(-1.5), dcplx.t(-1.0), dcplx.t(0.0d), dcplx.t(1.0d), dcplx.t(1.5d), dcplx.t(4.333d) };
                foreach (var nu in InputArrayReal1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.kelvin_ker_prime(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.kelvin_ker_prime(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.kelvin_ker_prime(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.kelvin_ker_prime(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.kelvin_ker_prime(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.kelvin_ker_prime(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.kelvin_ker_prime(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.kelvin_ker_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_kei_prime"))
            {
                string name = "kelvin_kei_prime";
                InputArrayReal1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), dcplx.t(-1.5), dcplx.t(-1.0), dcplx.t(0.0d), dcplx.t(1.0d), dcplx.t(1.5d), dcplx.t(4.333d) };
                foreach (var nu in InputArrayReal1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.kelvin_kei_prime(nu, x, scaled); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.kelvin_kei_prime(nu, x, scaled); break; }
                                case "dflintc": { res1 = dflintc.kelvin_kei_prime(nu, x, scaled); break; }
                                case "eflintc": { res1 = eflintc.kelvin_kei_prime(nu, x, scaled); break; }
                                case "qflintc": { res1 = qflintc.kelvin_kei_prime(nu, x, scaled); break; }
                                case "oflintc": { res1 = oflintc.kelvin_kei_prime(nu, x, scaled); break; }
                                case "mflintc": { res1 = mflintc.kelvin_kei_prime(nu, x, scaled); break; }
                                case "aflintc": { res1 = aflintc.kelvin_kei_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            #endregion




        }







        public static void CplxHypergeometric_0F1()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTests_CplxHypergeometric_0F1();
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