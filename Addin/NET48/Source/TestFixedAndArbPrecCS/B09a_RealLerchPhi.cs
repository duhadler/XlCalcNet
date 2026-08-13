using System;
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



        public static void RunTests_RealLerchPhi()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(80);
#endif
            string[] NTA1 = new[] { "math53", " sreal", " dreal", " ereal", " qreal", " oreal" };
            string[] NTA2 = new[] { " mreal", "sflint", "dflint", "eflint", "qflint", "oflint", "mflint", "aflint" };
            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();

            //string[] FunctionArray = new[] { "all" };
            string[] FunctionArray = new[] { "backlund_s" };

            DemoChapterLerchPhi(NumTypeArray, FunctionArray);

        }




        public static void DemoChapterLerchPhi(string[] NumTypeArray, string[] FunctionArray)
        {

            double[] InputArray1;
            double[] InputArray2;
            double[] InputArray3;

            int[] InputArrayInt1;


            #region LerchPhi


            if (FunctionArray.Contains("all") | FunctionArray.Contains("lerch_phi"))
            {
                InputArray1 = new[] { -0.8d, -0.1d, -0.5d, 1.0d - 0.001d };  // |z|<1
                InputArray2 = new[] { -0.5d, 2.5d, 13.5d };  // s>=-1
                InputArray3 = new[] { 0.1d, 0.5d, 13.5 };  // a>=0
                foreach (var z in InputArray1)
                {
                    foreach (var s in InputArray2)
                    {
                        foreach (var a in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine("lerch_phi(s ={0}, z ={1}, a ={2})", s, z, a);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.lerch_phi(z, s, a); break; }
#if HasArbPrecNet
                                    case "sflint": { res1 = sflint.lerch_phi(z, s, a); break; }
                                    case "dflint": { res1 = dflint.lerch_phi(z, s, a); break; }
                                    case "eflint": { res1 = eflint.lerch_phi(z, s, a); break; }
                                    case "qflint": { res1 = qflint.lerch_phi(z, s, a); break; }
                                    case "oflint": { res1 = oflint.lerch_phi(z, s, a); break; }
                                    case "mflint": { res1 = mflint.lerch_phi(z, s, a); break; }
                                    case "aflint": { res1 = aflint.lerch_phi(z, s, a); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("lerch_zeta"))
            {
                InputArray1 = new[] { -0.8d, -0.1d, -0.5d, 1.0d - 0.001d };  // lambda1
                InputArray2 = new[] { -0.5d, 2.5d, 13.5d };  // alpha
                InputArray3 = new[] { 0.1d, 0.5d, 13.5 };  // s
                foreach (var lambda1 in InputArray1)
                {
                    foreach (var alpha in InputArray2)
                    {
                        foreach (var s in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine("lerch_zeta(lambda1 ={0}, alpha ={1}, s ={2})", lambda1, alpha, s);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    //case "math53": { res1 = math53.lerch_zeta(lambda1, alpha, s); break; }
#if HasArbPrecNet
                                    case "sflint": { res1 = sflint.lerch_zeta(lambda1, alpha, s); break; }
                                    case "dflint": { res1 = dflint.lerch_zeta(lambda1, alpha, s); break; }
                                    case "eflint": { res1 = eflint.lerch_zeta(lambda1, alpha, s); break; }
                                    case "qflint": { res1 = qflint.lerch_zeta(lambda1, alpha, s); break; }
                                    case "oflint": { res1 = oflint.lerch_zeta(lambda1, alpha, s); break; }
                                    case "mflint": { res1 = mflint.lerch_zeta(lambda1, alpha, s); break; }
                                    case "aflint": { res1 = aflint.lerch_zeta(lambda1, alpha, s); break; }
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



            #region Polygamma functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("polygamma"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d, double.PositiveInfinity }; // -inf , Nan crashes
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("polygamma(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.polygamma(n, x); break; }
                                case " sreal": { res1 = sreal.polygamma(n, x); break; }
                                case " dreal": { res1 = dreal.polygamma(n, x); break; }
                                case " ereal": { res1 = ereal.polygamma(n, x); break; }
                                case " qreal": { res1 = qreal.polygamma(n, x); break; }
                                case " oreal": { res1 = oreal.polygamma(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.polygamma(n, x); break; }
                                case "sflint": { res1 = sflint.polygamma(n, x); break; }
                                case "dflint": { res1 = dflint.polygamma(n, x); break; }
                                case "eflint": { res1 = eflint.polygamma(n, x); break; }
                                case "qflint": { res1 = qflint.polygamma(n, x); break; }
                                case "oflint": { res1 = oflint.polygamma(n, x); break; }
                                case "mflint": { res1 = mflint.polygamma(n, x); break; }
                                case "aflint": { res1 = aflint.polygamma(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("trigamma"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("trigamma(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.trigamma(x1); break; }
                            case " sreal": { res1 = sreal.trigamma(x1); break; }
                            case " dreal": { res1 = dreal.trigamma(x1); break; }
                            case " ereal": { res1 = ereal.trigamma(x1); break; }
                            case " qreal": { res1 = qreal.trigamma(x1); break; }
                            case " oreal": { res1 = oreal.trigamma(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.trigamma(x1); break; }
                            case "sflint": { res1 = sflint.trigamma(x1); break; }
                            case "dflint": { res1 = dflint.trigamma(x1); break; }
                            case "eflint": { res1 = eflint.trigamma(x1); break; }
                            case "qflint": { res1 = qflint.trigamma(x1); break; }
                            case "oflint": { res1 = oflint.trigamma(x1); break; }
                            case "mflint": { res1 = mflint.trigamma(x1); break; }
                            case "aflint": { res1 = aflint.trigamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("digamma"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("digamma(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.digamma(x1); break; }
                            case " sreal": { res1 = sreal.digamma(x1); break; }
                            case " dreal": { res1 = dreal.digamma(x1); break; }
                            case " ereal": { res1 = ereal.digamma(x1); break; }
                            case " qreal": { res1 = qreal.digamma(x1); break; }
                            case " oreal": { res1 = oreal.digamma(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.digamma(x1); break; }
                            case "sflint": { res1 = sflint.digamma(x1); break; }
                            case "dflint": { res1 = dflint.digamma(x1); break; }
                            case "eflint": { res1 = eflint.digamma(x1); break; }
                            case "qflint": { res1 = qflint.digamma(x1); break; }
                            case "oflint": { res1 = oflint.digamma(x1); break; }
                            case "mflint": { res1 = mflint.digamma(x1); break; }
                            case "aflint": { res1 = aflint.digamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("harmonic"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.harmonic(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.harmonic(x1); break; }
                            case "dflint": { res1 = dflint.harmonic(x1); break; }
                            case "eflint": { res1 = eflint.harmonic(x1); break; }
                            case "qflint": { res1 = qflint.harmonic(x1); break; }
                            case "oflint": { res1 = oflint.harmonic(x1); break; }
                            case "mflint": { res1 = mflint.harmonic(x1); break; }
                            case "aflint": { res1 = aflint.harmonic(x1); break; }
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
                InputArray1 = new[] { 0.0, 1.0, 2.0, 4.0, 6.0, 8.0, 10.0 };
                InputArray2 = new[] { -0.333d, 0.0d, 0.333d, double.PositiveInfinity }; // -inf , Nan crashes
                foreach (var s in InputArray1)
                {
                    foreach (var z in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("polylog(s={0}, z={1})", s, z);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.polylog(s, z); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.polylog(s, z); break; }
                                case "dflint": { res1 = dflint.polylog(s, z); break; }
                                case "eflint": { res1 = eflint.polylog(s, z); break; }
                                case "qflint": { res1 = qflint.polylog(s, z); break; }
                                case "oflint": { res1 = oflint.polylog(s, z); break; }
                                case "mflint": { res1 = mflint.polylog(s, z); break; }
                                case "aflint": { res1 = aflint.polylog(s, z); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("trilog"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("trilog(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.trilog(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.trilog(x1); break; }
                            case "dflint": { res1 = dflint.trilog(x1); break; }
                            case "eflint": { res1 = eflint.trilog(x1); break; }
                            case "qflint": { res1 = qflint.trilog(x1); break; }
                            case "oflint": { res1 = oflint.trilog(x1); break; }
                            case "mflint": { res1 = mflint.trilog(x1); break; }
                            case "aflint": { res1 = aflint.trilog(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("dilog"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("dilog(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.dilog(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.dilog(x1); break; }
                            case "dflint": { res1 = dflint.dilog(x1); break; }
                            case "eflint": { res1 = eflint.dilog(x1); break; }
                            case "qflint": { res1 = qflint.dilog(x1); break; }
                            case "oflint": { res1 = oflint.dilog(x1); break; }
                            case "mflint": { res1 = mflint.dilog(x1); break; }
                            case "aflint": { res1 = aflint.dilog(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("clausen_sin"))
            {
                InputArray1 = new[] { 0.0, 1.0, 2.0, 4.0 };
                InputArray2 = new[] { -0.333d, 0.1d, 0.333d }; 
                foreach (var s in InputArray1)
                {
                    foreach (var z in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("clausen_sin(s={0}, z={1})", s, z);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.clausen_sin(s, z); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.clausen_sin(s, z); break; }
                                case "dflint": { res1 = dflint.clausen_sin(s, z); break; }
                                case "eflint": { res1 = eflint.clausen_sin(s, z); break; }
                                case "qflint": { res1 = qflint.clausen_sin(s, z); break; }
                                case "oflint": { res1 = oflint.clausen_sin(s, z); break; }
                                case "mflint": { res1 = mflint.clausen_sin(s, z); break; }
                                case "aflint": { res1 = aflint.clausen_sin(s, z); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("clausen_cos"))
            {
                InputArray1 = new[] { 0.0, 1.0, 2.0, 4.0 };
                InputArray2 = new[] { -0.333d, 0.1d, 0.333d }; 
                foreach (var s in InputArray1)
                {
                    foreach (var z in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("clausen_cos(s={0}, z={1})", s, z);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.clausen_cos(s, z); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.clausen_cos(s, z); break; }
                                case "dflint": { res1 = dflint.clausen_cos(s, z); break; }
                                case "eflint": { res1 = eflint.clausen_cos(s, z); break; }
                                case "qflint": { res1 = qflint.clausen_cos(s, z); break; }
                                case "oflint": { res1 = oflint.clausen_cos(s, z); break; }
                                case "mflint": { res1 = mflint.clausen_cos(s, z); break; }
                                case "aflint": { res1 = aflint.clausen_cos(s, z); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("clausen2"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("clausen2(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.clausen2(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.clausen2(x1); break; }
                            case "dflint": { res1 = dflint.clausen2(x1); break; }
                            case "eflint": { res1 = eflint.clausen2(x1); break; }
                            case "qflint": { res1 = qflint.clausen2(x1); break; }
                            case "oflint": { res1 = oflint.clausen2(x1); break; }
                            case "mflint": { res1 = mflint.clausen2(x1); break; }
                            case "aflint": { res1 = aflint.clausen2(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bose_einstein"))
            {
                InputArray1 = new[] { 0.1, 1.1, 2.1, 4.1 };
                InputArray2 = new[] { -0.333d, 0.1d, 0.333d }; 
                foreach (var s in InputArray1)
                {
                    foreach (var z in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("bose_einstein(s={0}, z={1})", s, z);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bose_einstein(s, z); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.bose_einstein(s, z); break; }
                                case "dflint": { res1 = dflint.bose_einstein(s, z); break; }
                                case "eflint": { res1 = eflint.bose_einstein(s, z); break; }
                                case "qflint": { res1 = qflint.bose_einstein(s, z); break; }
                                case "oflint": { res1 = oflint.bose_einstein(s, z); break; }
                                case "mflint": { res1 = mflint.bose_einstein(s, z); break; }
                                case "aflint": { res1 = aflint.bose_einstein(s, z); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("fermi_dirac"))
            {
                InputArray1 = new[] { 0.1, 1.1, 2.1, 4.1 };
                InputArray2 = new[] { -0.333d, 0.1d, 0.333d }; 
                foreach (var s in InputArray1)
                {
                    foreach (var z in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("fermi_dirac(s={0}, z={1})", s, z);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.fermi_dirac(s, z); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.fermi_dirac(s, z); break; }
                                case "dflint": { res1 = dflint.fermi_dirac(s, z); break; }
                                case "eflint": { res1 = eflint.fermi_dirac(s, z); break; }
                                case "qflint": { res1 = qflint.fermi_dirac(s, z); break; }
                                case "oflint": { res1 = oflint.fermi_dirac(s, z); break; }
                                case "mflint": { res1 = mflint.fermi_dirac(s, z); break; }
                                case "aflint": { res1 = aflint.fermi_dirac(s, z); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_chi"))
            {
                InputArray1 = new[] { 0.1, 1.1, 2.1, 4.1 };
                InputArray2 = new[] { -0.333d, 0.1d, 0.333d }; 
                foreach (var s in InputArray1)
                {
                    foreach (var z in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("legendre_chi(s={0}, z={1})", s, z);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.legendre_chi(s, z); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.legendre_chi(s, z); break; }
                                case "dflint": { res1 = dflint.legendre_chi(s, z); break; }
                                case "eflint": { res1 = eflint.legendre_chi(s, z); break; }
                                case "qflint": { res1 = qflint.legendre_chi(s, z); break; }
                                case "oflint": { res1 = oflint.legendre_chi(s, z); break; }
                                case "mflint": { res1 = mflint.legendre_chi(s, z); break; }
                                case "aflint": { res1 = aflint.legendre_chi(s, z); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("inverse_tan_integral"))
            {
                InputArray1 = new[] { 0.1, 1.1, 2.1, 4.1 };
                InputArray2 = new[] { -0.333d, 0.1d, 0.333d }; 
                foreach (var s in InputArray1)
                {
                    foreach (var z in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("inverse_tan_integral(s={0}, z={1})", s, z);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.inverse_tan_integral(s, z); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.inverse_tan_integral(s, z); break; }
                                case "dflint": { res1 = dflint.inverse_tan_integral(s, z); break; }
                                case "eflint": { res1 = eflint.inverse_tan_integral(s, z); break; }
                                case "qflint": { res1 = qflint.inverse_tan_integral(s, z); break; }
                                case "oflint": { res1 = oflint.inverse_tan_integral(s, z); break; }
                                case "mflint": { res1 = mflint.inverse_tan_integral(s, z); break; }
                                case "aflint": { res1 = aflint.inverse_tan_integral(s, z); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Hurwitz zeta function and related functions



            if (FunctionArray.Contains("all") | FunctionArray.Contains("hurwitz_zeta"))
            {
                InputArray1 = new[] { 0.0, 1.0, 2.0, 4.0, 6.0, 8.0, 10.0 };
                InputArray2 = new[] { -0.333d, 0.0d, 0.333d, double.PositiveInfinity }; // -inf , Nan crashes
                foreach (var s in InputArray1)
                {
                    foreach (var a in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("hurwitz_zeta(s={0}, a={1})", s, a);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.hurwitz_zeta(s, a); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.hurwitz_zeta(s, a); break; }
                                case "dflint": { res1 = dflint.hurwitz_zeta(s, a); break; }
                                case "eflint": { res1 = eflint.hurwitz_zeta(s, a); break; }
                                case "qflint": { res1 = qflint.hurwitz_zeta(s, a); break; }
                                case "oflint": { res1 = oflint.hurwitz_zeta(s, a); break; }
                                case "mflint": { res1 = mflint.hurwitz_zeta(s, a); break; }
                                case "aflint": { res1 = aflint.hurwitz_zeta(s, a); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("harmonic2"))
            {
                InputArray1 = new[] { 0.0, 1.0, 2.0, 4.0, 6.0, 8.0, 10.0 };
                InputArray2 = new[] { -0.333d, 0.0d, 0.333d, 10.333d };
                foreach (var z in InputArray1)
                {
                    foreach (var r in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("harmonic2(z={0}, r={1})", z, r);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.harmonic2(z, r); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.harmonic2(z, r); break; }
                                case "dflint": { res1 = dflint.harmonic2(z, r); break; }
                                case "eflint": { res1 = eflint.harmonic2(z, r); break; }
                                case "qflint": { res1 = qflint.harmonic2(z, r); break; }
                                case "oflint": { res1 = oflint.harmonic2(z, r); break; }
                                case "mflint": { res1 = mflint.harmonic2(z, r); break; }
                                case "aflint": { res1 = aflint.harmonic2(z, r); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bernoulli"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                foreach (var n in InputArrayInt1)
                {
                    Console.WriteLine();
                    Console.WriteLine("bernoulli(n={0})", n);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.bernoulli(n); break; }
                            case " sreal": { res1 = sreal.bernoulli(n); break; }
                            case " dreal": { res1 = dreal.bernoulli(n); break; }
                            case " ereal": { res1 = ereal.bernoulli(n); break; }
                            case " qreal": { res1 = qreal.bernoulli(n); break; }
                            case " oreal": { res1 = oreal.bernoulli(n); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.bernoulli(n); break; }
                            case "sflint": { res1 = sflint.bernoulli(n); break; }
                            case "dflint": { res1 = dflint.bernoulli(n); break; }
                            case "eflint": { res1 = eflint.bernoulli(n); break; }
                            case "qflint": { res1 = qflint.bernoulli(n); break; }
                            case "oflint": { res1 = oflint.bernoulli(n); break; }
                            case "mflint": { res1 = mflint.bernoulli(n); break; }
                            case "aflint": { res1 = aflint.bernoulli(n); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bernpoly"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d, double.PositiveInfinity }; // -inf , Nan crashes
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("bernpoly(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bernpoly(x, n); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.bernpoly(x, n); break; }
                                case "dflint": { res1 = dflint.bernpoly(x, n); break; }
                                case "eflint": { res1 = eflint.bernpoly(x, n); break; }
                                case "qflint": { res1 = qflint.bernpoly(x, n); break; }
                                case "oflint": { res1 = oflint.bernpoly(x, n); break; }
                                case "mflint": { res1 = mflint.bernpoly(x, n); break; }
                                case "aflint": { res1 = aflint.bernpoly(x, n); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("eulernum"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                foreach (var n in InputArrayInt1)
                {
                    Console.WriteLine();
                    Console.WriteLine("eulernum(n={0})", n);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.eulernum(n); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.eulernum(n); break; }
                            case "dflint": { res1 = dflint.eulernum(n); break; }
                            case "eflint": { res1 = eflint.eulernum(n); break; }
                            case "qflint": { res1 = qflint.eulernum(n); break; }
                            case "oflint": { res1 = oflint.eulernum(n); break; }
                            case "mflint": { res1 = mflint.eulernum(n); break; }
                            case "aflint": { res1 = aflint.eulernum(n); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("eulerpoly"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d, };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("eulerpoly(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.eulerpoly(x, n); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.eulerpoly(x, n); break; }
                                case "dflint": { res1 = dflint.eulerpoly(x, n); break; }
                                case "eflint": { res1 = eflint.eulerpoly(x, n); break; }
                                case "qflint": { res1 = qflint.eulerpoly(x, n); break; }
                                case "oflint": { res1 = oflint.eulerpoly(x, n); break; }
                                case "mflint": { res1 = mflint.eulerpoly(x, n); break; }
                                case "aflint": { res1 = aflint.eulerpoly(x, n); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("barnes_g"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("barnes_g(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.barnes_g(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.barnes_g(x1); break; }
                            case "dflint": { res1 = dflint.barnes_g(x1); break; }
                            case "eflint": { res1 = eflint.barnes_g(x1); break; }
                            case "qflint": { res1 = qflint.barnes_g(x1); break; }
                            case "oflint": { res1 = oflint.barnes_g(x1); break; }
                            case "mflint": { res1 = mflint.barnes_g(x1); break; }
                            case "aflint": { res1 = aflint.barnes_g(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("logbarnes_g"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("logbarnes_g(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.logbarnes_g(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.logbarnes_g(x1); break; }
                            case "dflint": { res1 = dflint.logbarnes_g(x1); break; }
                            case "eflint": { res1 = eflint.logbarnes_g(x1); break; }
                            case "qflint": { res1 = qflint.logbarnes_g(x1); break; }
                            case "oflint": { res1 = oflint.logbarnes_g(x1); break; }
                            case "mflint": { res1 = mflint.logbarnes_g(x1); break; }
                            case "aflint": { res1 = aflint.logbarnes_g(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperfactorial"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 14.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("hyperfactorial(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.hyperfactorial(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.hyperfactorial(x1); break; }
                            case "dflint": { res1 = dflint.hyperfactorial(x1); break; }
                            case "eflint": { res1 = eflint.hyperfactorial(x1); break; }
                            case "qflint": { res1 = qflint.hyperfactorial(x1); break; }
                            case "oflint": { res1 = oflint.hyperfactorial(x1); break; }
                            case "mflint": { res1 = mflint.hyperfactorial(x1); break; }
                            case "aflint": { res1 = aflint.hyperfactorial(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("superfactorial"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 14.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("superfactorial(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.superfactorial(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.superfactorial(x1); break; }
                            case "dflint": { res1 = dflint.superfactorial(x1); break; }
                            case "eflint": { res1 = eflint.superfactorial(x1); break; }
                            case "qflint": { res1 = qflint.superfactorial(x1); break; }
                            case "oflint": { res1 = oflint.superfactorial(x1); break; }
                            case "mflint": { res1 = mflint.superfactorial(x1); break; }
                            case "aflint": { res1 = aflint.superfactorial(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            #endregion



            #region Riemann zeta function, and related functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("zeta"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("zeta(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.zeta(x1); break; }
                            case " sreal": { res1 = sreal.zeta(x1); break; }
                            case " dreal": { res1 = dreal.zeta(x1); break; }
                            case " ereal": { res1 = ereal.zeta(x1); break; }
                            case " qreal": { res1 = qreal.zeta(x1); break; }
                            case " oreal": { res1 = oreal.zeta(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.zeta(x1); break; }
                            case "sflint": { res1 = sflint.zeta(x1); break; }
                            case "dflint": { res1 = dflint.zeta(x1); break; }
                            case "eflint": { res1 = eflint.zeta(x1); break; }
                            case "qflint": { res1 = qflint.zeta(x1); break; }
                            case "oflint": { res1 = oflint.zeta(x1); break; }
                            case "mflint": { res1 = mflint.zeta(x1); break; }
                            case "aflint": { res1 = aflint.zeta(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("zetam1"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("zetam1(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.zetam1(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.zetam1(x1); break; }
                            case "dflint": { res1 = dflint.zetam1(x1); break; }
                            case "eflint": { res1 = eflint.zetam1(x1); break; }
                            case "qflint": { res1 = qflint.zetam1(x1); break; }
                            case "oflint": { res1 = oflint.zetam1(x1); break; }
                            case "mflint": { res1 = mflint.zetam1(x1); break; }
                            case "aflint": { res1 = aflint.zetam1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("hardy_theta"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("hardy_theta(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.hardy_theta(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.hardy_theta(x1); break; }
                            case "dflint": { res1 = dflint.hardy_theta(x1); break; }
                            case "eflint": { res1 = eflint.hardy_theta(x1); break; }
                            case "qflint": { res1 = qflint.hardy_theta(x1); break; }
                            case "oflint": { res1 = oflint.hardy_theta(x1); break; }
                            case "mflint": { res1 = mflint.hardy_theta(x1); break; }
                            case "aflint": { res1 = aflint.hardy_theta(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("hardy_z"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("hardy_z(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.hardy_z(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.hardy_z(x1); break; }
                            case "dflint": { res1 = dflint.hardy_z(x1); break; }
                            case "eflint": { res1 = eflint.hardy_z(x1); break; }
                            case "qflint": { res1 = qflint.hardy_z(x1); break; }
                            case "oflint": { res1 = oflint.hardy_z(x1); break; }
                            case "mflint": { res1 = mflint.hardy_z(x1); break; }
                            case "aflint": { res1 = aflint.hardy_z(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("riemann_xi"))
            {
                InputArray1 = new[] { -4.333d, 0.0, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("riemann_xi(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.riemann_xi(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.riemann_xi(x1); break; }
                            case "dflint": { res1 = dflint.riemann_xi(x1); break; }
                            case "eflint": { res1 = eflint.riemann_xi(x1); break; }
                            case "qflint": { res1 = qflint.riemann_xi(x1); break; }
                            case "oflint": { res1 = oflint.riemann_xi(x1); break; }
                            case "mflint": { res1 = mflint.riemann_xi(x1); break; }
                            case "aflint": { res1 = aflint.riemann_xi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("dirichlet_eta"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("dirichlet_eta(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.dirichlet_eta(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.dirichlet_eta(x1); break; }
                            case "dflint": { res1 = dflint.dirichlet_eta(x1); break; }
                            case "eflint": { res1 = eflint.dirichlet_eta(x1); break; }
                            case "qflint": { res1 = qflint.dirichlet_eta(x1); break; }
                            case "oflint": { res1 = oflint.dirichlet_eta(x1); break; }
                            case "mflint": { res1 = mflint.dirichlet_eta(x1); break; }
                            case "aflint": { res1 = aflint.dirichlet_eta(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("dirichlet_etam1"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("dirichlet_etam1(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.dirichlet_etam1(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.dirichlet_etam1(x1); break; }
                            case "dflint": { res1 = dflint.dirichlet_etam1(x1); break; }
                            case "eflint": { res1 = eflint.dirichlet_etam1(x1); break; }
                            case "qflint": { res1 = qflint.dirichlet_etam1(x1); break; }
                            case "oflint": { res1 = oflint.dirichlet_etam1(x1); break; }
                            case "mflint": { res1 = mflint.dirichlet_etam1(x1); break; }
                            case "aflint": { res1 = aflint.dirichlet_etam1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("dirichlet_beta"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("dirichlet_beta(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.dirichlet_beta(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.dirichlet_beta(x1); break; }
                            case "dflint": { res1 = dflint.dirichlet_beta(x1); break; }
                            case "eflint": { res1 = eflint.dirichlet_beta(x1); break; }
                            case "qflint": { res1 = qflint.dirichlet_beta(x1); break; }
                            case "oflint": { res1 = oflint.dirichlet_beta(x1); break; }
                            case "mflint": { res1 = mflint.dirichlet_beta(x1); break; }
                            case "aflint": { res1 = aflint.dirichlet_beta(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("dirichlet_lambda"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("dirichlet_lambda(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.dirichlet_lambda(x1); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.dirichlet_lambda(x1); break; }
                            case "dflint": { res1 = dflint.dirichlet_lambda(x1); break; }
                            case "eflint": { res1 = eflint.dirichlet_lambda(x1); break; }
                            case "qflint": { res1 = qflint.dirichlet_lambda(x1); break; }
                            case "oflint": { res1 = oflint.dirichlet_lambda(x1); break; }
                            case "mflint": { res1 = mflint.dirichlet_lambda(x1); break; }
                            case "aflint": { res1 = aflint.dirichlet_lambda(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



//            if (FunctionArray.Contains("all") | FunctionArray.Contains("backlund_s"))
//            {
//                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
//                foreach (var x1 in InputArray1)
//                {
//                    Console.WriteLine();
//                    Console.WriteLine("backlund_s(x1={0})", x1);
//                    foreach (var NumType in NumTypeArray)
//                    {
//                        object res1 = "Not done";
//                        switch (NumType ?? "")
//                        {
//#if HasArbPrecNet
//                            case "sflint": { res1 = sflint.backlund_s(x1); break; }
//                            case "dflint": { res1 = dflint.backlund_s(x1); break; }
//                            case "eflint": { res1 = eflint.backlund_s(x1); break; }
//                            case "qflint": { res1 = qflint.backlund_s(x1); break; }
//                            case "oflint": { res1 = oflint.backlund_s(x1); break; }
//                            case "mflint": { res1 = mflint.backlund_s(x1); break; }
//                            case "aflint": { res1 = aflint.backlund_s(x1); break; }
//#endif
//                        }
//                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
//                    }
//                }
//                Console.WriteLine();
//            }



//            if (FunctionArray.Contains("all") | FunctionArray.Contains("grampoint"))
//            {
//                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
//                foreach (var n in InputArrayInt1)
//                {
//                    Console.WriteLine();
//                    Console.WriteLine("grampoint(n={0})", n);
//                    foreach (var NumType in NumTypeArray)
//                    {
//                        object res1 = "Not done";
//                        switch (NumType ?? "")
//                        {
//#if HasArbPrecNet
//                            case "sflint": { res1 = sflint.grampoint(n); break; }
//                            case "dflint": { res1 = dflint.grampoint(n); break; }
//                            case "eflint": { res1 = eflint.grampoint(n); break; }
//                            case "qflint": { res1 = qflint.grampoint(n); break; }
//                            case "oflint": { res1 = oflint.grampoint(n); break; }
//                            case "mflint": { res1 = mflint.grampoint(n); break; }
//                            case "aflint": { res1 = aflint.grampoint(n); break; }
//#endif
//                        }
//                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
//                    }
//                }
//                Console.WriteLine();
//            }



            #endregion



//            #region Additional numbertheoretic functions



//            if (FunctionArray.Contains("all") | FunctionArray.Contains("bell"))
//            {
//                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
//                foreach (var n in InputArrayInt1)
//                {
//                    Console.WriteLine();
//                    Console.WriteLine("bell(n={0})", n);
//                    foreach (var NumType in NumTypeArray)
//                    {
//                        object res1 = "Not done";
//                        switch (NumType ?? "")
//                        {
//#if HasArbPrecNet
//                            case "sflint": { res1 = sflint.bell(n); break; }
//                            case "dflint": { res1 = dflint.bell(n); break; }
//                            case "eflint": { res1 = eflint.bell(n); break; }
//                            case "qflint": { res1 = qflint.bell(n); break; }
//                            case "oflint": { res1 = oflint.bell(n); break; }
//                            case "mflint": { res1 = mflint.bell(n); break; }
//                            case "aflint": { res1 = aflint.bell(n); break; }
//#endif
//                        }
//                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
//                    }
//                }
//                Console.WriteLine();
//            }



//            if (FunctionArray.Contains("all") | FunctionArray.Contains("partitions"))
//            {
//                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
//                foreach (var n in InputArrayInt1)
//                {
//                    Console.WriteLine();
//                    Console.WriteLine("partitions(n={0})", n);
//                    foreach (var NumType in NumTypeArray)
//                    {
//                        object res1 = "Not done";
//                        switch (NumType ?? "")
//                        {
//#if HasArbPrecNet
//                            case "sflint": { res1 = sflint.partitions(n); break; }
//                            case "dflint": { res1 = dflint.partitions(n); break; }
//                            case "eflint": { res1 = eflint.partitions(n); break; }
//                            case "qflint": { res1 = qflint.partitions(n); break; }
//                            case "oflint": { res1 = oflint.partitions(n); break; }
//                            case "mflint": { res1 = mflint.partitions(n); break; }
//                            case "aflint": { res1 = aflint.partitions(n); break; }
//#endif
//                        }
//                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
//                    }
//                }
//                Console.WriteLine();
//            }



//            if (FunctionArray.Contains("all") | FunctionArray.Contains("primorial"))
//            {
//                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
//                foreach (var n in InputArrayInt1)
//                {
//                    Console.WriteLine();
//                    Console.WriteLine("primorial(n={0})", n);
//                    foreach (var NumType in NumTypeArray)
//                    {
//                        object res1 = "Not done";
//                        switch (NumType ?? "")
//                        {
//#if HasArbPrecNet
//                            case "sflint": { res1 = sflint.primorial(n); break; }
//                            case "dflint": { res1 = dflint.primorial(n); break; }
//                            case "eflint": { res1 = eflint.primorial(n); break; }
//                            case "qflint": { res1 = qflint.primorial(n); break; }
//                            case "oflint": { res1 = oflint.primorial(n); break; }
//                            case "mflint": { res1 = mflint.primorial(n); break; }
//                            case "aflint": { res1 = aflint.primorial(n); break; }
//#endif
//                        }
//                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
//                    }
//                }
//                Console.WriteLine();
//            }






//            #endregion




        }






        public static void RealLerchPhi()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTests_RealLerchPhi();
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