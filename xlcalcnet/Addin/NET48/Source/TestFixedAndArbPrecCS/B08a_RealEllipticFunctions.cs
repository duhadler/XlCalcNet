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


        public static void RunTests_RealEllipticFunctions()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(80);
#endif
            string[] NTA1 = new[] { "math53", " sreal", " dreal", " ereal", " qreal", " oreal" };
            string[] NTA2 = new[] { " mreal", "sflint", "dflint", "eflint", "qflint", "oflint", "mflint", "aflint" };
            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();

            //string[] FunctionArray = new[] { "all" };
            string[] FunctionArray = new[] { "elliptic_rd" };

            DemoChapterRealElliptic(NumTypeArray, FunctionArray);

        }


        public static void DemoChapterRealElliptic(string[] NumTypeArray, string[] FunctionArray)
        {

            double[] InputArray1;
            double[] InputArray2;
            double[] InputArray3;
            double[] InputArray4;





            #region Carlson symmetric elliptic integrals


            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_rc"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("elliptic_rc(x ={0}, y ={1})", x, y);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.elliptic_rc(x, y); break; }
                                case " sreal": { res1 = sreal.elliptic_rc(x, y); break; }
                                case " dreal": { res1 = dreal.elliptic_rc(x, y); break; }
                                case " ereal": { res1 = ereal.elliptic_rc(x, y); break; }
                                case " qreal": { res1 = qreal.elliptic_rc(x, y); break; }
                                case " oreal": { res1 = oreal.elliptic_rc(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.elliptic_rc(x, y); break; }
                                case "sflint": { res1 = sflint.elliptic_rc(x, y); break; }
                                case "dflint": { res1 = dflint.elliptic_rc(x, y); break; }
                                case "eflint": { res1 = eflint.elliptic_rc(x, y); break; }
                                case "qflint": { res1 = qflint.elliptic_rc(x, y); break; }
                                case "oflint": { res1 = oflint.elliptic_rc(x, y); break; }
                                case "mflint": { res1 = mflint.elliptic_rc(x, y); break; }
                                case "aflint": { res1 = aflint.elliptic_rc(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_rf"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var z in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine("elliptic_rf(x ={0}, y ={1}, z ={2})", x, y, z);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.elliptic_rf(x, y, z); break; }
                                    case " sreal": { res1 = sreal.elliptic_rf(x, y, z); break; }
                                    case " dreal": { res1 = dreal.elliptic_rf(x, y, z); break; }
                                    case " ereal": { res1 = ereal.elliptic_rf(x, y, z); break; }
                                    case " qreal": { res1 = qreal.elliptic_rf(x, y, z); break; }
                                    case " oreal": { res1 = oreal.elliptic_rf(x, y, z); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.elliptic_rf(x, y, z); break; }
                                    case "sflint": { res1 = sflint.elliptic_rf(x, y, z); break; }
                                    case "dflint": { res1 = dflint.elliptic_rf(x, y, z); break; }
                                    case "eflint": { res1 = eflint.elliptic_rf(x, y, z); break; }
                                    case "qflint": { res1 = qflint.elliptic_rf(x, y, z); break; }
                                    case "oflint": { res1 = oflint.elliptic_rf(x, y, z); break; }
                                    case "mflint": { res1 = mflint.elliptic_rf(x, y, z); break; }
                                    case "aflint": { res1 = aflint.elliptic_rf(x, y, z); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_rg"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var z in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine("elliptic_rg(x ={0}, y ={1}, z ={2})", x, y, z);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.elliptic_rg(x, y, z); break; }
                                    case " sreal": { res1 = sreal.elliptic_rg(x, y, z); break; }
                                    case " dreal": { res1 = dreal.elliptic_rg(x, y, z); break; }
                                    case " ereal": { res1 = ereal.elliptic_rg(x, y, z); break; }
                                    case " qreal": { res1 = qreal.elliptic_rg(x, y, z); break; }
                                    case " oreal": { res1 = oreal.elliptic_rg(x, y, z); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.elliptic_rg(x, y, z); break; }
                                    case "sflint": { res1 = sflint.elliptic_rg(x, y, z); break; }
                                    case "dflint": { res1 = dflint.elliptic_rg(x, y, z); break; }
                                    case "eflint": { res1 = eflint.elliptic_rg(x, y, z); break; }
                                    case "qflint": { res1 = qflint.elliptic_rg(x, y, z); break; }
                                    case "oflint": { res1 = oflint.elliptic_rg(x, y, z); break; }
                                    case "mflint": { res1 = mflint.elliptic_rg(x, y, z); break; }
                                    case "aflint": { res1 = aflint.elliptic_rg(x, y, z); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_rd"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var z in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine("elliptic_rd(x ={0}, y ={1}, z ={2})", x, y, z);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.elliptic_rd(x, y, z); break; }
                                    case " sreal": { res1 = sreal.elliptic_rd(x, y, z); break; }
                                    case " dreal": { res1 = dreal.elliptic_rd(x, y, z); break; }
                                    case " ereal": { res1 = ereal.elliptic_rd(x, y, z); break; }
                                    case " qreal": { res1 = qreal.elliptic_rd(x, y, z); break; }
                                    case " oreal": { res1 = oreal.elliptic_rd(x, y, z); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.elliptic_rd(x, y, z); break; }
                                    case "sflint": { res1 = sflint.elliptic_rd(x, y, z); break; }
                                    case "dflint": { res1 = dflint.elliptic_rd(x, y, z); break; }
                                    case "eflint": { res1 = eflint.elliptic_rd(x, y, z); break; }
                                    case "qflint": { res1 = qflint.elliptic_rd(x, y, z); break; }
                                    case "oflint": { res1 = oflint.elliptic_rd(x, y, z); break; }
                                    case "mflint": { res1 = mflint.elliptic_rd(x, y, z); break; }
                                    case "aflint": { res1 = aflint.elliptic_rd(x, y, z); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_rj"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
                InputArray4 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var z in InputArray3)
                        {
                            foreach (var p in InputArray3)
                            {
                                Console.WriteLine();
                                Console.WriteLine("elliptic_rj(x ={0}, y ={1}, z ={2}, p ={3})", x, y, z, p);
                                foreach (var NumType in NumTypeArray)
                                {
                                    object res1 = "Not done";
                                    switch (NumType ?? "")
                                    {
                                        case "math53": { res1 = math53.elliptic_rj(x, y, z, p); break; }
                                        case " sreal": { res1 = sreal.elliptic_rj(x, y, z, p); break; }
                                        case " dreal": { res1 = dreal.elliptic_rj(x, y, z, p); break; }
                                        case " ereal": { res1 = ereal.elliptic_rj(x, y, z, p); break; }
                                        case " qreal": { res1 = qreal.elliptic_rj(x, y, z, p); break; }
                                        case " oreal": { res1 = oreal.elliptic_rj(x, y, z, p); break; }
#if HasArbPrecNet
                                        case " mreal": { res1 = mreal.elliptic_rj(x, y, z, p); break; }
                                        case "sflint": { res1 = sflint.elliptic_rj(x, y, z, p); break; }
                                        case "dflint": { res1 = dflint.elliptic_rj(x, y, z, p); break; }
                                        case "eflint": { res1 = eflint.elliptic_rj(x, y, z, p); break; }
                                        case "qflint": { res1 = qflint.elliptic_rj(x, y, z, p); break; }
                                        case "oflint": { res1 = oflint.elliptic_rj(x, y, z, p); break; }
                                        case "mflint": { res1 = mflint.elliptic_rj(x, y, z, p); break; }
                                        case "aflint": { res1 = aflint.elliptic_rj(x, y, z, p); break; }
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




            #region Legendre elliptic integrals (elliptic parameter m)



            #endregion





            #region Legendre elliptic integrals (elliptic modulus k), and related functions

            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_k"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 0.999d, 0.999999d, 1.0d };
                foreach (var k in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("elliptic_k(k ={0})", k);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.elliptic_k(k); break; }
                            case " sreal": { res1 = sreal.elliptic_k(k); break; }
                            case " dreal": { res1 = dreal.elliptic_k(k); break; }
                            case " ereal": { res1 = ereal.elliptic_k(k); break; }
                            case " qreal": { res1 = qreal.elliptic_k(k); break; }
                            case " oreal": { res1 = oreal.elliptic_k(k); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.elliptic_k(k); break; }
                            case "sflint": { res1 = sflint.elliptic_k(k); break; }
                            case "dflint": { res1 = dflint.elliptic_k(k); break; }
                            case "eflint": { res1 = eflint.elliptic_k(k); break; }
                            case "qflint": { res1 = qflint.elliptic_k(k); break; }
                            case "oflint": { res1 = oflint.elliptic_k(k); break; }
                            case "mflint": { res1 = mflint.elliptic_k(k); break; }
                            case "aflint": { res1 = aflint.elliptic_k(k); break; }
#endif

                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            // crashes with NaN
            // InputArray = {0.0, 0.75, 0.999, 0.999999, 1.0}
            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_e"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 0.999d, 0.999999d, 1.0d, double.PositiveInfinity };
                foreach (var k in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine("elliptic_e(k ={0})", k);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.elliptic_e(k); break; }
                            case " sreal": { res1 = sreal.elliptic_e(k); break; }
                            case " dreal": { res1 = dreal.elliptic_e(k); break; }
                            case " ereal": { res1 = ereal.elliptic_e(k); break; }
                            case " qreal": { res1 = qreal.elliptic_e(k); break; }
                            case " oreal": { res1 = oreal.elliptic_e(k); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.elliptic_e(k); break; }
                            case "sflint": { res1 = sflint.elliptic_e(k); break; }
                            case "dflint": { res1 = dflint.elliptic_e(k); break; }
                            case "eflint": { res1 = eflint.elliptic_e(k); break; }
                            case "qflint": { res1 = qflint.elliptic_e(k); break; }
                            case "oflint": { res1 = oflint.elliptic_e(k); break; }
                            case "mflint": { res1 = mflint.elliptic_e(k); break; }
                            case "aflint": { res1 = aflint.elliptic_e(k); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_f"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var phi in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("elliptic_rc(phi ={0}, k ={1})", phi, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.elliptic_f(phi, k); break; }
                                case " sreal": { res1 = sreal.elliptic_f(phi, k); break; }
                                case " dreal": { res1 = dreal.elliptic_f(phi, k); break; }
                                case " ereal": { res1 = ereal.elliptic_f(phi, k); break; }
                                case " qreal": { res1 = qreal.elliptic_f(phi, k); break; }
                                case " oreal": { res1 = oreal.elliptic_f(phi, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.elliptic_f(phi, k); break; }
                                case "sflint": { res1 = sflint.elliptic_f(phi, k); break; }
                                case "dflint": { res1 = dflint.elliptic_f(phi, k); break; }
                                case "eflint": { res1 = eflint.elliptic_f(phi, k); break; }
                                case "qflint": { res1 = qflint.elliptic_f(phi, k); break; }
                                case "oflint": { res1 = oflint.elliptic_f(phi, k); break; }
                                case "mflint": { res1 = mflint.elliptic_f(phi, k); break; }
                                case "aflint": { res1 = aflint.elliptic_f(phi, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_e_inc"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var phi in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("elliptic_e_inc(phi ={0}, k ={1})", phi, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.elliptic_e_inc(phi, k); break; }
                                case " sreal": { res1 = sreal.elliptic_e_inc(phi, k); break; }
                                case " dreal": { res1 = dreal.elliptic_e_inc(phi, k); break; }
                                case " ereal": { res1 = ereal.elliptic_e_inc(phi, k); break; }
                                case " qreal": { res1 = qreal.elliptic_e_inc(phi, k); break; }
                                case " oreal": { res1 = oreal.elliptic_e_inc(phi, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.elliptic_e_inc(phi, k); break; }
                                case "sflint": { res1 = sflint.elliptic_e_inc(phi, k); break; }
                                case "dflint": { res1 = dflint.elliptic_e_inc(phi, k); break; }
                                case "eflint": { res1 = eflint.elliptic_e_inc(phi, k); break; }
                                case "qflint": { res1 = qflint.elliptic_e_inc(phi, k); break; }
                                case "oflint": { res1 = oflint.elliptic_e_inc(phi, k); break; }
                                case "mflint": { res1 = mflint.elliptic_e_inc(phi, k); break; }
                                case "aflint": { res1 = aflint.elliptic_e_inc(phi, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_pi"))
            {
                InputArray1 = new[] { 0.0, 0.75, 0.99};
                InputArray2 = new[] { 0.0, 0.5, 0.99};
                foreach (var n in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("elliptic_pi(n ={0}, k ={1})", n, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.elliptic_pi(n, k); break; } 
                                case " sreal": { res1 = sreal.elliptic_pi(n, k); break; }
                                case " dreal": { res1 = dreal.elliptic_pi(n, k); break; }
                                case " ereal": { res1 = ereal.elliptic_pi(n, k); break; }
                                case " qreal": { res1 = qreal.elliptic_pi(n, k); break; }
                                case " oreal": { res1 = oreal.elliptic_pi(n, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.elliptic_pi(n, k); break; }
                                case "sflint": { res1 = sflint.elliptic_pi(n, k); break; }
                                case "dflint": { res1 = dflint.elliptic_pi(n, k); break; }
                                case "eflint": { res1 = eflint.elliptic_pi(n, k); break; }
                                case "qflint": { res1 = qflint.elliptic_pi(n, k); break; }
                                case "oflint": { res1 = oflint.elliptic_pi(n, k); break; }
                                case "mflint": { res1 = mflint.elliptic_pi(n, k); break; }
                                case "aflint": { res1 = aflint.elliptic_pi(n, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_pi_inc"))
            {


                InputArray1 = new[] { 0.015d, 0.55d, 0.995d };   // n
                InputArray2 = new[] { 0.18d, 0.58d, 1.08d, 1.58d };  // phi
                InputArray3 = new[] { 0.01d, 0.5d, 0.99d };  // k

                foreach (var n in InputArray1)
                {
                    foreach (var phi in InputArray2)
                    {
                        foreach (var k in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine("elliptic_pi_inc(n ={0}, phi ={1}, k ={2})", n, phi, k);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.elliptic_pi_inc(n, phi, k); break; }
                                    case " sreal": { res1 = sreal.elliptic_pi_inc(n, phi, k); break; }
                                    case " dreal": { res1 = dreal.elliptic_pi_inc(n, phi, k); break; }
                                    case " ereal": { res1 = ereal.elliptic_pi_inc(n, phi, k); break; }
                                    case " qreal": { res1 = qreal.elliptic_pi_inc(n, phi, k); break; }
                                    case " oreal": { res1 = oreal.elliptic_pi_inc(n, phi, k); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.elliptic_pi_inc(n, phi, k); break; }

                                    case "sflint": { res1 = sflint.elliptic_pi_inc(n, phi, k); break; }
                                    case "dflint": { res1 = dflint.elliptic_pi_inc(n, phi, k); break; }
                                    case "eflint": { res1 = eflint.elliptic_pi_inc(n, phi, k); break; }
                                    case "qflint": { res1 = qflint.elliptic_pi_inc(n, phi, k); break; }
                                    case "oflint": { res1 = oflint.elliptic_pi_inc(n, phi, k); break; }
                                    case "mflint": { res1 = mflint.elliptic_pi_inc(n, phi, k); break; }
                                    case "aflint": { res1 = aflint.elliptic_pi_inc(n, phi, k); break; }
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






            #region Jacobi elliptic functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_cd"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.001d, 0.5d, 0.99d }; // not working correctly for 0 and 1 in ARB
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_cd(x ={0}, k ={1})", x, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_cd(x, k); break; }
                                case " sreal": { res1 = sreal.jacobi_cd(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_cd(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_cd(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_cd(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_cd(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_cd(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_cd(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_cd(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_cd(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_cd(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_cd(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_cd(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_cd(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_cn"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.001d, 0.5d, 0.99d }; // not working correctly for 0 and 1 in ARB
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_cn(x ={0}, k ={1})", x, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_cn(x, k); break; } 
                                case " sreal": { res1 = sreal.jacobi_cn(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_cn(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_cn(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_cn(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_cn(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_cn(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_cn(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_cn(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_cn(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_cn(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_cn(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_cn(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_cn(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_cs"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.001d, 0.5d, 0.99d }; // not working correctly for 0 and 1 in ARB
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_cs(x ={0}, k ={1})", x, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_cs(x, k); break; }
                                case " sreal": { res1 = sreal.jacobi_cs(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_cs(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_cs(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_cs(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_cs(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_cs(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_cs(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_cs(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_cs(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_cs(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_cs(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_cs(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_cs(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_dc"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.001d, 0.5d, 0.99d }; // not working correctly for 0 and 1 in ARB
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_dc(x ={0}, k ={1})", x, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_dc(x, k); break; } 
                                case " sreal": { res1 = sreal.jacobi_dc(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_dc(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_dc(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_dc(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_dc(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_dc(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_dc(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_dc(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_dc(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_dc(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_dc(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_dc(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_dc(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_dn"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.001d, 0.5d, 0.99d }; // not working correctly for 0 and 1 in ARB
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_dn(x ={0}, k ={1})", x, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_dn(x, k); break; } 
                                case " sreal": { res1 = sreal.jacobi_dn(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_dn(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_dn(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_dn(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_dn(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_dn(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_dn(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_dn(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_dn(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_dn(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_dn(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_dn(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_dn(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_ds"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.001d, 0.5d, 0.99d }; // not working correctly for 0 and 1 in ARB
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_ds(x ={0}, k ={1})", x, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_ds(x, k); break; }
                                case " sreal": { res1 = sreal.jacobi_ds(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_ds(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_ds(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_ds(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_ds(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_ds(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_ds(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_ds(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_ds(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_ds(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_ds(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_ds(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_ds(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_nc"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.001d, 0.5d, 0.99d }; // not working correctly for 0 and 1 in ARB
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_nc(x ={0}, k ={1})", x, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_nc(x, k); break; }
                                case " sreal": { res1 = sreal.jacobi_nc(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_nc(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_nc(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_nc(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_nc(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_nc(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_nc(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_nc(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_nc(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_nc(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_nc(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_nc(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_nc(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_nd"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.001d, 0.5d, 0.99d }; // not working correctly for 0 and 1 in ARB
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_nd(x ={0}, k ={1})", x, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_nd(x, k); break; }
                                case " sreal": { res1 = sreal.jacobi_nd(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_nd(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_nd(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_nd(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_nd(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_nd(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_nd(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_nd(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_nd(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_nd(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_nd(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_nd(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_nd(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_ns"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.001d, 0.5d, 0.99d }; // not working correctly for 0 and 1 in ARB
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_ns(x ={0}, k ={1})", x, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_ns(x, k); break; }
                                case " sreal": { res1 = sreal.jacobi_ns(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_ns(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_ns(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_ns(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_ns(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_ns(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_ns(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_ns(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_ns(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_ns(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_ns(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_ns(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_ns(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_sc"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.001d, 0.5d, 0.99d }; // not working correctly for 0 and 1 in ARB
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_sc (x ={0}, k ={1})", x, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_sc(x, k); break; }
                                case " sreal": { res1 = sreal.jacobi_sc(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_sc(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_sc(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_sc(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_sc(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_sc(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_sc(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_sc(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_sc(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_sc(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_sc(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_sc(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_sc(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_sd"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.001d, 0.5d, 0.99d }; // not working correctly for 0 and 1 in ARB
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_sd (x ={0}, k ={1})", x, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_sd(x, k); break; }
                                case " sreal": { res1 = sreal.jacobi_sd(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_sd(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_sd(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_sd(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_sd(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_sd(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_sd(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_sd(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_sd(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_sd(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_sd(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_sd(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_sd(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_sn"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.001d, 0.5d, 0.99d }; // not working correctly for 0 and 1 in ARB
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_sn (x ={0}, k ={1})", x, k);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_sn(x, k); break; }
                                case " sreal": { res1 = sreal.jacobi_sn(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_sn(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_sn(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_sn(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_sn(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_sn(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_sn(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_sn(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_sn(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_sn(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_sn(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_sn(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_sn(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion






            #region Jacobi theta functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_theta1"))
            {
                InputArray1 = new[] { -1.5d, 0.0d, 1.5d };
                InputArray2 = new[] { 0.01d, 0.5d, 1.0d - 0.01d };
                foreach (var x in InputArray1)
                {
                    foreach (var q in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_theta1 (x ={0}, q ={1})", x, q);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_theta1(x, q); break; }
                                case " sreal": { res1 = sreal.jacobi_theta1(x, q); break; }
                                case " dreal": { res1 = dreal.jacobi_theta1(x, q); break; }
                                case " ereal": { res1 = ereal.jacobi_theta1(x, q); break; }
                                case " qreal": { res1 = qreal.jacobi_theta1(x, q); break; }
                                case " oreal": { res1 = oreal.jacobi_theta1(x, q); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_theta1(x, q); break; }
                                case "sflint": { res1 = sflint.jacobi_theta1(x, q); break; }
                                case "dflint": { res1 = dflint.jacobi_theta1(x, q); break; }
                                case "eflint": { res1 = eflint.jacobi_theta1(x, q); break; }
                                case "qflint": { res1 = qflint.jacobi_theta1(x, q); break; }
                                case "oflint": { res1 = oflint.jacobi_theta1(x, q); break; }
                                case "mflint": { res1 = mflint.jacobi_theta1(x, q); break; }
                                case "aflint": { res1 = aflint.jacobi_theta1(x, q); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_theta2"))
            {
                InputArray1 = new[] { -1.5d, 0.0d, 1.5d };
                InputArray2 = new[] { 0.01d, 0.5d, 1.0d - 0.01d };
                foreach (var x in InputArray1)
                {
                    foreach (var q in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_theta2 (x ={0}, q ={1})", x, q);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_theta2(x, q); break; }
                                case " sreal": { res1 = sreal.jacobi_theta2(x, q); break; }
                                case " dreal": { res1 = dreal.jacobi_theta2(x, q); break; }
                                case " ereal": { res1 = ereal.jacobi_theta2(x, q); break; }
                                case " qreal": { res1 = qreal.jacobi_theta2(x, q); break; }
                                case " oreal": { res1 = oreal.jacobi_theta2(x, q); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_theta2(x, q); break; }
                                case "sflint": { res1 = sflint.jacobi_theta2(x, q); break; }
                                case "dflint": { res1 = dflint.jacobi_theta2(x, q); break; }
                                case "eflint": { res1 = eflint.jacobi_theta2(x, q); break; }
                                case "qflint": { res1 = qflint.jacobi_theta2(x, q); break; }
                                case "oflint": { res1 = oflint.jacobi_theta2(x, q); break; }
                                case "mflint": { res1 = mflint.jacobi_theta2(x, q); break; }
                                case "aflint": { res1 = aflint.jacobi_theta2(x, q); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_theta3"))
            {
                InputArray1 = new[] { -1.5d, 0.0d, 1.5d };
                InputArray2 = new[] { 0.01d, 0.5d, 1.0d - 0.01d };
                foreach (var x in InputArray1)
                {
                    foreach (var q in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_theta3 (x ={0}, q ={1})", x, q);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_theta3(x, q); break; }
                                case " sreal": { res1 = sreal.jacobi_theta3(x, q); break; }
                                case " dreal": { res1 = dreal.jacobi_theta3(x, q); break; }
                                case " ereal": { res1 = ereal.jacobi_theta3(x, q); break; }
                                case " qreal": { res1 = qreal.jacobi_theta3(x, q); break; }
                                case " oreal": { res1 = oreal.jacobi_theta3(x, q); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_theta3(x, q); break; }
                                case "sflint": { res1 = sflint.jacobi_theta3(x, q); break; }
                                case "dflint": { res1 = dflint.jacobi_theta3(x, q); break; }
                                case "eflint": { res1 = eflint.jacobi_theta3(x, q); break; }
                                case "qflint": { res1 = qflint.jacobi_theta3(x, q); break; }
                                case "oflint": { res1 = oflint.jacobi_theta3(x, q); break; }
                                case "mflint": { res1 = mflint.jacobi_theta3(x, q); break; }
                                case "aflint": { res1 = aflint.jacobi_theta3(x, q); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_theta4"))
            {
                InputArray1 = new[] { -1.5d, 0.0d, 1.5d };
                InputArray2 = new[] { 0.01d, 0.5d, 1.0d - 0.01d };
                foreach (var x in InputArray1)
                {
                    foreach (var q in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("jacobi_theta4 (x ={0}, q ={1})", x, q);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.jacobi_theta4(x, q); break; }
                                case " sreal": { res1 = sreal.jacobi_theta4(x, q); break; }
                                case " dreal": { res1 = dreal.jacobi_theta4(x, q); break; }
                                case " ereal": { res1 = ereal.jacobi_theta4(x, q); break; }
                                case " qreal": { res1 = qreal.jacobi_theta4(x, q); break; }
                                case " oreal": { res1 = oreal.jacobi_theta4(x, q); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_theta4(x, q); break; }
                                case "sflint": { res1 = sflint.jacobi_theta4(x, q); break; }
                                case "dflint": { res1 = dflint.jacobi_theta4(x, q); break; }
                                case "eflint": { res1 = eflint.jacobi_theta4(x, q); break; }
                                case "qflint": { res1 = qflint.jacobi_theta4(x, q); break; }
                                case "oflint": { res1 = oflint.jacobi_theta4(x, q); break; }
                                case "mflint": { res1 = mflint.jacobi_theta4(x, q); break; }
                                case "aflint": { res1 = aflint.jacobi_theta4(x, q); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion





            #region  Conversions of parameters of Weierstrass



            #endregion





            #region  Weierstrass elliptic functions, in terms of elliptic period ratio tau



            #endregion




            #region  Modular forms and related



            #endregion



        }







        public static void RealEllipticFunctions()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTests_RealEllipticFunctions();
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