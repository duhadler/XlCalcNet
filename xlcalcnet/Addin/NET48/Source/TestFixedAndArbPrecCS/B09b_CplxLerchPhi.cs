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




        public static void RunTests_CplxLerchPhi()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(70);
#endif
            string[] NTA1 = new[] { "cmath53" };
            string[] NTA2 = new[] { "sflintc", "dflintc", "eflintc", "qflintc", "oflintc", "mflintc", "aflintc" };
            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();

            //string[] FunctionArray = new[] { "all" };
            string[] FunctionArray = new[] { "zeta_zero" };

            DemoChapterCplxLerchPhi(NumTypeArray, FunctionArray);

        }


        public static void DemoChapterCplxLerchPhi(string[] NumTypeArray, string[] FunctionArray)
        {

            Complex[] InputArray1;
            Complex[] InputArray2;
            Complex[] InputArray3;
            //Complex[] InputArray4;
            int[] InputArrayInt1;


            #region LerchPhi


            if (FunctionArray.Contains("all") | FunctionArray.Contains("lerch_phi"))
            {
                InputArray1 = new[] {dcplx.t(1.5, 1.0), dcplx.t(2.5, 1.0), dcplx.t(13.5, 1.0)};  // z
                InputArray2 = new[] {dcplx.t(2.1, 1.0), dcplx.t(12.1, 1.0), dcplx.t(53.5, 1.0)};  // s
                InputArray3 = new[] {dcplx.t(0.01, 1.0), dcplx.t(0.5, 1.0), dcplx.t(1.0-0.001, 1.0)};  // a
                foreach (var z in InputArray1)
                {
                    foreach (var s in InputArray2)
                    {
                        foreach (var a in InputArray3)
                        {
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.lerch_phi(z, s, a); break; }
                                    case "dflintc": { res1 = dflintc.lerch_phi(z, s, a); break; }
                                    case "eflintc": { res1 = eflintc.lerch_phi(z, s, a); break; }
                                    case "qflintc": { res1 = qflintc.lerch_phi(z, s, a); break; }
                                    case "oflintc": { res1 = oflintc.lerch_phi(z, s, a); break; }
                                    case "mflintc": { res1 = mflintc.lerch_phi(z, s, a); break; }
                                    case "aflintc": { res1 = aflintc.lerch_phi(z, s, a); break; }
#endif
                                }
                                Console.WriteLine("{0}: lerch_phi(z={1}, s={2}, a={3}): {4}", NumType, z, s, a, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("lerch_zeta"))
            {
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) }; // s
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) }; // z
                InputArray3 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) }; // a
                foreach (var lambda1 in InputArray1)
                {
                    foreach (var alpha in InputArray2)
                    {
                        foreach (var s in InputArray3)
                        {
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.lerch_zeta(lambda1, alpha, s); break; }
                                    case "dflintc": { res1 = dflintc.lerch_zeta(lambda1, alpha, s); break; }
                                    case "eflintc": { res1 = eflintc.lerch_zeta(lambda1, alpha, s); break; }
                                    case "qflintc": { res1 = qflintc.lerch_zeta(lambda1, alpha, s); break; }
                                    case "oflintc": { res1 = oflintc.lerch_zeta(lambda1, alpha, s); break; }
                                    case "mflintc": { res1 = mflintc.lerch_zeta(lambda1, alpha, s); break; }
                                    case "aflintc": { res1 = aflintc.lerch_zeta(lambda1, alpha, s); break; }
#endif
                                }
                                Console.WriteLine("{0}: lerch_phi(lambda1={1}, alpha={2}, s={3}): {4}", NumType, lambda1, alpha, s, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }





            #endregion



            #region Polygamma functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("polygamma"))
            {
                InputArray1 = new[] { dcplx.t(0), dcplx.t(1), dcplx.t(2), dcplx.t(4), dcplx.t(6), dcplx.t(8), dcplx.t(10) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var n in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.polygamma(n, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.polygamma(n, x); break; }
                                case "dflintc": { res1 = dflintc.polygamma(n, x); break; }
                                case "eflintc": { res1 = eflintc.polygamma(n, x); break; }
                                case "qflintc": { res1 = qflintc.polygamma(n, x); break; }
                                case "oflintc": { res1 = oflintc.polygamma(n, x); break; }
                                case "mflintc": { res1 = mflintc.polygamma(n, x); break; }
                                case "aflintc": { res1 = aflintc.polygamma(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: polygamma({1}, {2}): {3}", NumType, n, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            if (FunctionArray.Contains("all") | FunctionArray.Contains("trigamma"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.trigamma(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.trigamma(x1); break; }
                            case "dflintc": { res1 = dflintc.trigamma(x1); break; }
                            case "eflintc": { res1 = eflintc.trigamma(x1); break; }
                            case "qflintc": { res1 = qflintc.trigamma(x1); break; }
                            case "oflintc": { res1 = oflintc.trigamma(x1); break; }
                            case "mflintc": { res1 = mflintc.trigamma(x1); break; }
                            case "aflintc": { res1 = aflintc.trigamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: trigamma({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("digamma"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.digamma(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.digamma(x1); break; }
                            case "dflintc": { res1 = dflintc.digamma(x1); break; }
                            case "eflintc": { res1 = eflintc.digamma(x1); break; }
                            case "qflintc": { res1 = qflintc.digamma(x1); break; }
                            case "oflintc": { res1 = oflintc.digamma(x1); break; }
                            case "mflintc": { res1 = mflintc.digamma(x1); break; }
                            case "aflintc": { res1 = aflintc.digamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: digamma({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("harmonic"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.harmonic(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.harmonic(x1); break; }
                            case "dflintc": { res1 = dflintc.harmonic(x1); break; }
                            case "eflintc": { res1 = eflintc.harmonic(x1); break; }
                            case "qflintc": { res1 = qflintc.harmonic(x1); break; }
                            case "oflintc": { res1 = oflintc.harmonic(x1); break; }
                            case "mflintc": { res1 = mflintc.harmonic(x1); break; }
                            case "aflintc": { res1 = aflintc.harmonic(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: harmonic({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Polylogarithm


            if (FunctionArray.Contains("all") | FunctionArray.Contains("polylog"))
            {
                InputArray1 = new[] { dcplx.t(0), dcplx.t(1), dcplx.t(2), dcplx.t(4), dcplx.t(6), dcplx.t(8) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var s in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.polylog(s, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.polylog(s, x); break; }  // might need higher prec for larger s 
                                case "dflintc": { res1 = dflintc.polylog(s, x); break; }
                                case "eflintc": { res1 = eflintc.polylog(s, x); break; }
                                case "qflintc": { res1 = qflintc.polylog(s, x); break; }
                                case "oflintc": { res1 = oflintc.polylog(s, x); break; }
                                case "mflintc": { res1 = mflintc.polylog(s, x); break; }
                                case "aflintc": { res1 = aflintc.polylog(s, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: polylog(s:{1}, x:{2}): {3}", NumType, s, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("trilog"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.trilog(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.trilog(x1); break; }
                            case "dflintc": { res1 = dflintc.trilog(x1); break; }
                            case "eflintc": { res1 = eflintc.trilog(x1); break; }
                            case "qflintc": { res1 = qflintc.trilog(x1); break; }
                            case "oflintc": { res1 = oflintc.trilog(x1); break; }
                            case "mflintc": { res1 = mflintc.trilog(x1); break; }
                            case "aflintc": { res1 = aflintc.trilog(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: trilog({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("dilog"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.dilog(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.dilog(x1); break; }
                            case "dflintc": { res1 = dflintc.dilog(x1); break; }
                            case "eflintc": { res1 = eflintc.dilog(x1); break; }
                            case "qflintc": { res1 = qflintc.dilog(x1); break; }
                            case "oflintc": { res1 = oflintc.dilog(x1); break; }
                            case "mflintc": { res1 = mflintc.dilog(x1); break; }
                            case "aflintc": { res1 = aflintc.dilog(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: dilog({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("clausen_sin"))
            {
                InputArray1 = new[] { dcplx.t(0), dcplx.t(1), dcplx.t(2), dcplx.t(4), dcplx.t(6), dcplx.t(8) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var s in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.clausen_sin(s, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.clausen_sin(s, x); break; }  // might need higher prec for larger s 
                                case "dflintc": { res1 = dflintc.clausen_sin(s, x); break; }
                                case "eflintc": { res1 = eflintc.clausen_sin(s, x); break; }
                                case "qflintc": { res1 = qflintc.clausen_sin(s, x); break; }
                                case "oflintc": { res1 = oflintc.clausen_sin(s, x); break; }
                                case "mflintc": { res1 = mflintc.clausen_sin(s, x); break; }
                                case "aflintc": { res1 = aflintc.clausen_sin(s, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: clausen_sin(s:{1}, x:{2}): {3}", NumType, s, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("clausen_cos"))
            {
                InputArray1 = new[] { dcplx.t(0), dcplx.t(1), dcplx.t(2), dcplx.t(4), dcplx.t(6), dcplx.t(8) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var s in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.clausen_cos(s, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.clausen_cos(s, x); break; }  // might need higher prec for larger s 
                                case "dflintc": { res1 = dflintc.clausen_cos(s, x); break; }
                                case "eflintc": { res1 = eflintc.clausen_cos(s, x); break; }
                                case "qflintc": { res1 = qflintc.clausen_cos(s, x); break; }
                                case "oflintc": { res1 = oflintc.clausen_cos(s, x); break; }
                                case "mflintc": { res1 = mflintc.clausen_cos(s, x); break; }
                                case "aflintc": { res1 = aflintc.clausen_cos(s, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: clausen_cos(s:{1}, x:{2}): {3}", NumType, s, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("bose_einstein"))
            {
                InputArray1 = new[] { dcplx.t(0), dcplx.t(1), dcplx.t(2), dcplx.t(4), dcplx.t(6), dcplx.t(8) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var s in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.bose_einstein(s, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.bose_einstein(s, x); break; }  // might need higher prec for larger s 
                                case "dflintc": { res1 = dflintc.bose_einstein(s, x); break; }
                                case "eflintc": { res1 = eflintc.bose_einstein(s, x); break; }
                                case "qflintc": { res1 = qflintc.bose_einstein(s, x); break; }
                                case "oflintc": { res1 = oflintc.bose_einstein(s, x); break; }
                                case "mflintc": { res1 = mflintc.bose_einstein(s, x); break; }
                                case "aflintc": { res1 = aflintc.bose_einstein(s, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: bose_einstein(s:{1}, x:{2}): {3}", NumType, s, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("fermi_dirac"))
            {
                InputArray1 = new[] { dcplx.t(0), dcplx.t(1), dcplx.t(2), dcplx.t(4), dcplx.t(6), dcplx.t(8) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var s in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.fermi_dirac(s, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.fermi_dirac(s, x); break; }  // might need higher prec for larger s 
                                case "dflintc": { res1 = dflintc.fermi_dirac(s, x); break; }
                                case "eflintc": { res1 = eflintc.fermi_dirac(s, x); break; }
                                case "qflintc": { res1 = qflintc.fermi_dirac(s, x); break; }
                                case "oflintc": { res1 = oflintc.fermi_dirac(s, x); break; }
                                case "mflintc": { res1 = mflintc.fermi_dirac(s, x); break; }
                                case "aflintc": { res1 = aflintc.fermi_dirac(s, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: fermi_dirac(s:{1}, x:{2}): {3}", NumType, s, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_chi"))
            {
                InputArray1 = new[] { dcplx.t(0), dcplx.t(1), dcplx.t(2), dcplx.t(4), dcplx.t(6), dcplx.t(8) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var s in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.legendre_chi(s, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.legendre_chi(s, x); break; }  // might need higher prec for larger s 
                                case "dflintc": { res1 = dflintc.legendre_chi(s, x); break; }
                                case "eflintc": { res1 = eflintc.legendre_chi(s, x); break; }
                                case "qflintc": { res1 = qflintc.legendre_chi(s, x); break; }
                                case "oflintc": { res1 = oflintc.legendre_chi(s, x); break; }
                                case "mflintc": { res1 = mflintc.legendre_chi(s, x); break; }
                                case "aflintc": { res1 = aflintc.legendre_chi(s, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: legendre_chi(s:{1}, x:{2}): {3}", NumType, s, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("inverse_tan_integral"))
            {
                InputArray1 = new[] { dcplx.t(0), dcplx.t(1), dcplx.t(2), dcplx.t(4), dcplx.t(6), dcplx.t(8) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var s in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.inverse_tan_integral(s, x); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.inverse_tan_integral(s, x); break; }  // might need higher prec for larger s 
                                case "dflintc": { res1 = dflintc.inverse_tan_integral(s, x); break; }
                                case "eflintc": { res1 = eflintc.inverse_tan_integral(s, x); break; }
                                case "qflintc": { res1 = qflintc.inverse_tan_integral(s, x); break; }
                                case "oflintc": { res1 = oflintc.inverse_tan_integral(s, x); break; }
                                case "mflintc": { res1 = mflintc.inverse_tan_integral(s, x); break; }
                                case "aflintc": { res1 = aflintc.inverse_tan_integral(s, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: inverse_tan_integral(s:{1}, x:{2}): {3}", NumType, s, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }






            #endregion



            #region Hurwitz zeta function and related functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hurwitz_zeta"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2), dcplx.t(-4.333d, -2), dcplx.t(0.0d, -2), dcplx.t(4.333d, -2) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2), dcplx.t(-4.333d, -2), dcplx.t(0.0d, -2), dcplx.t(4.333d, -2) };
                foreach (var s in InputArray1)
                {
                    foreach (var a in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.hurwitz_zeta(s, a); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.hurwitz_zeta(s, a); break; }
                                case "dflintc": { res1 = dflintc.hurwitz_zeta(s, a); break; }
                                case "eflintc": { res1 = eflintc.hurwitz_zeta(s, a); break; }
                                case "qflintc": { res1 = qflintc.hurwitz_zeta(s, a); break; }
                                case "oflintc": { res1 = oflintc.hurwitz_zeta(s, a); break; }
                                case "mflintc": { res1 = mflintc.hurwitz_zeta(s, a); break; }
                                case "aflintc": { res1 = aflintc.hurwitz_zeta(s, a); break; }
#endif
                            }
                            Console.WriteLine("{0}: hurwitz_zeta(s:{1}, a:{2}): {3}", NumType, s, a, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("harmonic2"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2), dcplx.t(-4.333d, -2), dcplx.t(0.0d, -2), dcplx.t(4.333d, -2) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2), dcplx.t(-4.333d, -2), dcplx.t(0.0d, -2), dcplx.t(4.333d, -2) };
                foreach (var z in InputArray1)
                {
                    foreach (var r in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.harmonic2(z, r); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.harmonic2(z, r); break; }
                                case "dflintc": { res1 = dflintc.harmonic2(z, r); break; }
                                case "eflintc": { res1 = eflintc.harmonic2(z, r); break; }
                                case "qflintc": { res1 = qflintc.harmonic2(z, r); break; }
                                case "oflintc": { res1 = oflintc.harmonic2(z, r); break; }
                                case "mflintc": { res1 = mflintc.harmonic2(z, r); break; }
                                case "aflintc": { res1 = aflintc.harmonic2(z, r); break; }
#endif
                            }
                            Console.WriteLine("{0}: harmonic2(z:{1}, r:{2}): {3}", NumType, z, r, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("bernpoly"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2), dcplx.t(-4.333d, -2), dcplx.t(0.0d, -2), dcplx.t(4.333d, -2) };
                InputArrayInt1 = new[] { 1, 2, 3, 4 };
                foreach (var s in InputArray1)
                {
                    foreach (var n in InputArrayInt1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.bernpoly(s, n); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.bernpoly(s, n); break; }
                                case "dflintc": { res1 = dflintc.bernpoly(s, n); break; }
                                case "eflintc": { res1 = eflintc.bernpoly(s, n); break; }
                                case "qflintc": { res1 = qflintc.bernpoly(s, n); break; }
                                case "oflintc": { res1 = oflintc.bernpoly(s, n); break; }
                                case "mflintc": { res1 = mflintc.bernpoly(s, n); break; }
                                case "aflintc": { res1 = aflintc.bernpoly(s, n); break; }
#endif
                            }
                            Console.WriteLine("{0}: bernpoly(s:{1}, n:{2}): {3}", NumType, s, n, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("eulerpoly"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2), dcplx.t(-4.333d, -2), dcplx.t(0.0d, -2), dcplx.t(4.333d, -2) };
                InputArrayInt1 = new[] { 1, 2, 3, 4 };
                foreach (var s in InputArray1)
                {
                    foreach (var n in InputArrayInt1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.eulerpoly(s, n); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.eulerpoly(s, n); break; }
                                case "dflintc": { res1 = dflintc.eulerpoly(s, n); break; }
                                case "eflintc": { res1 = eflintc.eulerpoly(s, n); break; }
                                case "qflintc": { res1 = qflintc.eulerpoly(s, n); break; }
                                case "oflintc": { res1 = oflintc.eulerpoly(s, n); break; }
                                case "mflintc": { res1 = mflintc.eulerpoly(s, n); break; }
                                case "aflintc": { res1 = aflintc.eulerpoly(s, n); break; }
#endif
                            }
                            Console.WriteLine("{0}: eulerpoly(s:{1}, n:{2}): {3}", NumType, s, n, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("barnes_g"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.barnes_g(x1); break; }
                            case "dflintc": { res1 = dflintc.barnes_g(x1); break; }
                            case "eflintc": { res1 = eflintc.barnes_g(x1); break; }
                            case "qflintc": { res1 = qflintc.barnes_g(x1); break; }
                            case "oflintc": { res1 = oflintc.barnes_g(x1); break; }
                            case "mflintc": { res1 = mflintc.barnes_g(x1); break; }
                            case "aflintc": { res1 = aflintc.barnes_g(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: barnes_g({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("logbarnes_g"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            //case "cmath53": { res1 = cmath53.logbarnes_g(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.logbarnes_g(x1); break; }
                            case "dflintc": { res1 = dflintc.logbarnes_g(x1); break; }
                            case "eflintc": { res1 = eflintc.logbarnes_g(x1); break; }
                            case "qflintc": { res1 = qflintc.logbarnes_g(x1); break; }
                            case "oflintc": { res1 = oflintc.logbarnes_g(x1); break; }
                            case "mflintc": { res1 = mflintc.logbarnes_g(x1); break; }
                            case "aflintc": { res1 = aflintc.logbarnes_g(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: logbarnes_g({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperfactorial"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.hyperfactorial(x1); break; }
                            case "dflintc": { res1 = dflintc.hyperfactorial(x1); break; }
                            case "eflintc": { res1 = eflintc.hyperfactorial(x1); break; }
                            case "qflintc": { res1 = qflintc.hyperfactorial(x1); break; }
                            case "oflintc": { res1 = oflintc.hyperfactorial(x1); break; }
                            case "mflintc": { res1 = mflintc.hyperfactorial(x1); break; }
                            case "aflintc": { res1 = aflintc.hyperfactorial(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: hyperfactorial({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("superfactorial"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.superfactorial(x1); break; }
                            case "dflintc": { res1 = dflintc.superfactorial(x1); break; }
                            case "eflintc": { res1 = eflintc.superfactorial(x1); break; }
                            case "qflintc": { res1 = qflintc.superfactorial(x1); break; }
                            case "oflintc": { res1 = oflintc.superfactorial(x1); break; }
                            case "mflintc": { res1 = mflintc.superfactorial(x1); break; }
                            case "aflintc": { res1 = aflintc.superfactorial(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: superfactorial({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }










            #endregion



            #region Riemann zeta function, and related functions

            if (FunctionArray.Contains("all") | FunctionArray.Contains("zeta"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.zeta(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.zeta(x1); break; }
                            case "dflintc": { res1 = dflintc.zeta(x1); break; }
                            case "eflintc": { res1 = eflintc.zeta(x1); break; }
                            case "qflintc": { res1 = qflintc.zeta(x1); break; }
                            case "oflintc": { res1 = oflintc.zeta(x1); break; }
                            case "mflintc": { res1 = mflintc.zeta(x1); break; }
                            case "aflintc": { res1 = aflintc.zeta(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: zeta({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("zetam1"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(104.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.zetam1(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.zetam1(x1); break; }
                            case "dflintc": { res1 = dflintc.zetam1(x1); break; }
                            case "eflintc": { res1 = eflintc.zetam1(x1); break; }
                            case "qflintc": { res1 = qflintc.zetam1(x1); break; }
                            case "oflintc": { res1 = oflintc.zetam1(x1); break; }
                            case "mflintc": { res1 = mflintc.zetam1(x1); break; }
                            case "aflintc": { res1 = aflintc.zetam1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: zetam1({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("hardy_theta"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(2.1d, 0), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.hardy_theta(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.hardy_theta(x1); break; }
                            case "dflintc": { res1 = dflintc.hardy_theta(x1); break; }
                            case "eflintc": { res1 = eflintc.hardy_theta(x1); break; }
                            case "qflintc": { res1 = qflintc.hardy_theta(x1); break; }
                            case "oflintc": { res1 = oflintc.hardy_theta(x1); break; }
                            case "mflintc": { res1 = mflintc.hardy_theta(x1); break; }
                            case "aflintc": { res1 = aflintc.hardy_theta(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: hardy_theta({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("hardy_z"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(2.1d, 0), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.hardy_z(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.hardy_z(x1); break; }
                            case "dflintc": { res1 = dflintc.hardy_z(x1); break; }
                            case "eflintc": { res1 = eflintc.hardy_z(x1); break; }
                            case "qflintc": { res1 = qflintc.hardy_z(x1); break; }
                            case "oflintc": { res1 = oflintc.hardy_z(x1); break; }
                            case "mflintc": { res1 = mflintc.hardy_z(x1); break; }
                            case "aflintc": { res1 = aflintc.hardy_z(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: hardy_z({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("riemann_xi"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.riemann_xi(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.riemann_xi(x1); break; }
                            case "dflintc": { res1 = dflintc.riemann_xi(x1); break; }
                            case "eflintc": { res1 = eflintc.riemann_xi(x1); break; }
                            case "qflintc": { res1 = qflintc.riemann_xi(x1); break; }
                            case "oflintc": { res1 = oflintc.riemann_xi(x1); break; }
                            case "mflintc": { res1 = mflintc.riemann_xi(x1); break; }
                            case "aflintc": { res1 = aflintc.riemann_xi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: riemann_xi({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("dirichlet_eta"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.dirichlet_eta(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.dirichlet_eta(x1); break; }
                            case "dflintc": { res1 = dflintc.dirichlet_eta(x1); break; }
                            case "eflintc": { res1 = eflintc.dirichlet_eta(x1); break; }
                            case "qflintc": { res1 = qflintc.dirichlet_eta(x1); break; }
                            case "oflintc": { res1 = oflintc.dirichlet_eta(x1); break; }
                            case "mflintc": { res1 = mflintc.dirichlet_eta(x1); break; }
                            case "aflintc": { res1 = aflintc.dirichlet_eta(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: dirichlet_eta({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("dirichlet_etam1"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.dirichlet_etam1(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.dirichlet_etam1(x1); break; }
                            case "dflintc": { res1 = dflintc.dirichlet_etam1(x1); break; }
                            case "eflintc": { res1 = eflintc.dirichlet_etam1(x1); break; }
                            case "qflintc": { res1 = qflintc.dirichlet_etam1(x1); break; }
                            case "oflintc": { res1 = oflintc.dirichlet_etam1(x1); break; }
                            case "mflintc": { res1 = mflintc.dirichlet_etam1(x1); break; }
                            case "aflintc": { res1 = aflintc.dirichlet_etam1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: dirichlet_etam1({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("dirichlet_beta"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.dirichlet_beta(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.dirichlet_beta(x1); break; }
                            case "dflintc": { res1 = dflintc.dirichlet_beta(x1); break; }
                            case "eflintc": { res1 = eflintc.dirichlet_beta(x1); break; }
                            case "qflintc": { res1 = qflintc.dirichlet_beta(x1); break; }
                            case "oflintc": { res1 = oflintc.dirichlet_beta(x1); break; }
                            case "mflintc": { res1 = mflintc.dirichlet_beta(x1); break; }
                            case "aflintc": { res1 = aflintc.dirichlet_beta(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: dirichlet_beta({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("dirichlet_lambda"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.dirichlet_lambda(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.dirichlet_lambda(x1); break; }
                            case "dflintc": { res1 = dflintc.dirichlet_lambda(x1); break; }
                            case "eflintc": { res1 = eflintc.dirichlet_lambda(x1); break; }
                            case "qflintc": { res1 = qflintc.dirichlet_lambda(x1); break; }
                            case "oflintc": { res1 = oflintc.dirichlet_lambda(x1); break; }
                            case "mflintc": { res1 = mflintc.dirichlet_lambda(x1); break; }
                            case "aflintc": { res1 = aflintc.dirichlet_lambda(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: dirichlet_lambda({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("zeta_zero"))
            {
                InputArrayInt1 = new[] { 1, 2, 3, 4 };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.zeta_zero(n); break; }
                            case "dflintc": { res1 = dflintc.zeta_zero(n); break; }
                            case "eflintc": { res1 = eflintc.zeta_zero(n); break; }
                            case "qflintc": { res1 = qflintc.zeta_zero(n); break; }
                            case "oflintc": { res1 = oflintc.zeta_zero(n); break; }
                            case "mflintc": { res1 = mflintc.zeta_zero(n); break; }
                            case "aflintc": { res1 = aflintc.zeta_zero(n); break; }
#endif
                        }
                        Console.WriteLine("{0}: zeta_zero({1}): {2}", NumType, n, res1);
                    }
                }
                Console.WriteLine();
            }



            #endregion



            #region Additional numbertheoretic functions



            #endregion




        }








        public static void CplxLerchPhi()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTests_CplxLerchPhi();
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