using System;
using System.Diagnostics;
using System.Linq;
using FixedPrecNet;


#if HasArbPrecNet
using ArbPrecNet;
#endif




namespace TestXlCalcNetPrecCS
{

    static class TestRealSpecialFunctions
    {


        public static string f(string NumType)
        {
            return (NumType == "aflint") ? "" : " ";
        }





        public static void DemoChapterElliptic(string[] NumTypeArray, string[] FunctionArray)
        {

            double[] InputArray1;
            double[] InputArray2;
            double[] InputArray3;
            double[] InputArray4;
            // Dim InputArrayInt1 As Integer()
            // Dim InputArrayInt2 As Integer()



            #region Conversions of parameters of elliptic functions



            #endregion





            #region Carlson symmetric elliptic integrals


            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_rc"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
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
                                //case " yreal": { res1 = yreal.elliptic_rc(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.elliptic_rc(x, y); break; }
                                case "sflint": { res1 = sflint.elliptic_rc(x, y); break; }
                                case "dflint": { res1 = dflint.elliptic_rc(x, y); break; }
                                case "eflint": { res1 = eflint.elliptic_rc(x, y); break; }
                                case "qflint": { res1 = qflint.elliptic_rc(x, y); break; }
                                case "oflint": { res1 = oflint.elliptic_rc(x, y); break; }
                                case "cflint": { res1 = cflint.elliptic_rc(x, y); break; }
                                case "mflint": { res1 = mflint.elliptic_rc(x, y); break; }
                                case "iflint": { res1 = iflint.elliptic_rc(x, y); break; }
                                case "aflint": { res1 = aflint.elliptic_rc(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: elliptic_rc(x={1}, y={2}): {3}", NumType, x, y, res1);
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
                                    //case " yreal": { res1 = yreal.elliptic_rf(x, y, z); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.elliptic_rf(x, y, z); break; }
                                    case "sflint": { res1 = sflint.elliptic_rf(x, y, z); break; }
                                    case "dflint": { res1 = dflint.elliptic_rf(x, y, z); break; }
                                    case "eflint": { res1 = eflint.elliptic_rf(x, y, z); break; }
                                    case "qflint": { res1 = qflint.elliptic_rf(x, y, z); break; }
                                    case "oflint": { res1 = oflint.elliptic_rf(x, y, z); break; }
                                    case "cflint": { res1 = cflint.elliptic_rf(x, y, z); break; }
                                    case "mflint": { res1 = mflint.elliptic_rf(x, y, z); break; }
                                    case "iflint": { res1 = iflint.elliptic_rf(x, y, z); break; }
                                    case "aflint": { res1 = aflint.elliptic_rf(x, y, z); break; }
#endif
                                }
                                Console.WriteLine("{0}: elliptic_rf(x={1}, y={2}, z={3}): {4}", NumType, x, y, z, res1);
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
                                    //case " yreal": { res1 = yreal.elliptic_rd(x, y, z); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.elliptic_rd(x, y, z); break; }
                                    case "sflint": { res1 = sflint.elliptic_rd(x, y, z); break; }
                                    case "dflint": { res1 = dflint.elliptic_rd(x, y, z); break; }
                                    case "eflint": { res1 = eflint.elliptic_rd(x, y, z); break; }
                                    case "qflint": { res1 = qflint.elliptic_rd(x, y, z); break; }
                                    case "oflint": { res1 = oflint.elliptic_rd(x, y, z); break; }
                                    case "cflint": { res1 = cflint.elliptic_rd(x, y, z); break; }
                                    case "mflint": { res1 = mflint.elliptic_rd(x, y, z); break; }
                                    case "iflint": { res1 = iflint.elliptic_rd(x, y, z); break; }
                                    case "aflint": { res1 = aflint.elliptic_rd(x, y, z); break; }
#endif
                                }
                                Console.WriteLine("{0}: elliptic_rd(x={1}, y={2}, z={3}): {4}", NumType, x, y, z, res1);
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
                                        //case " yreal": { res1 = yreal.elliptic_rj(x, y, z, p); break; }
#if HasArbPrecNet
                                        case " mreal": { res1 = mreal.elliptic_rj(x, y, z, p); break; }
                                        case "sflint": { res1 = sflint.elliptic_rj(x, y, z, p); break; }
                                        case "dflint": { res1 = dflint.elliptic_rj(x, y, z, p); break; }
                                        case "eflint": { res1 = eflint.elliptic_rj(x, y, z, p); break; }
                                        case "qflint": { res1 = qflint.elliptic_rj(x, y, z, p); break; }
                                        case "oflint": { res1 = oflint.elliptic_rj(x, y, z, p); break; }
                                        case "cflint": { res1 = cflint.elliptic_rj(x, y, z, p); break; }
                                        case "mflint": { res1 = mflint.elliptic_rj(x, y, z, p); break; }
                                        case "iflint": { res1 = iflint.elliptic_rj(x, y, z, p); break; }
                                        case "aflint": { res1 = aflint.elliptic_rj(x, y, z, p); break; }
#endif
                                    }
                                    Console.WriteLine("{0}: elliptic_rj(x={1}, y={2}, z={3}, p={4}): {5}", NumType, x, y, z, p, res1);
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
                            //case " yreal": { res1 = yreal.elliptic_k(k); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.elliptic_k(k); break; }
                            case "sflint": { res1 = sflint.elliptic_k(k); break; }
                            case "dflint": { res1 = dflint.elliptic_k(k); break; }
                            case "eflint": { res1 = eflint.elliptic_k(k); break; }
                            case "qflint": { res1 = qflint.elliptic_k(k); break; }
                            case "oflint": { res1 = oflint.elliptic_k(k); break; }
                            case "cflint": { res1 = cflint.elliptic_k(k); break; }
                            case "mflint": { res1 = mflint.elliptic_k(k); break; }
                            case "iflint": { res1 = iflint.elliptic_k(k); break; }
                            case "aflint": { res1 = aflint.elliptic_k(k); break; }
#endif

                        }
                        Console.WriteLine("{0}: elliptic_k({1}): {2}", NumType, k, res1);
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
                            //case " yreal": { res1 = yreal.elliptic_e(k); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.elliptic_e(k); break; }
                            case "sflint": { res1 = sflint.elliptic_e(k); break; }
                            case "dflint": { res1 = dflint.elliptic_e(k); break; }
                            case "eflint": { res1 = eflint.elliptic_e(k); break; }
                            case "qflint": { res1 = qflint.elliptic_e(k); break; }
                            case "oflint": { res1 = oflint.elliptic_e(k); break; }
                            case "cflint": { res1 = cflint.elliptic_e(k); break; }
                            case "mflint": { res1 = mflint.elliptic_e(k); break; }
                            case "iflint": { res1 = iflint.elliptic_e(k); break; }
                            case "aflint": { res1 = aflint.elliptic_e(k); break; }
#endif
                        }
                        Console.WriteLine("{0}: elliptic_k({1}): {2}", NumType, k, res1);
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
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.elliptic_f(phi, k); break; } // math53.elliptic_f(k, phi);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.elliptic_f(phi, k); break; }
                                case " dreal": { res1 = dreal.elliptic_f(phi, k); break; }
                                case " ereal": { res1 = ereal.elliptic_f(phi, k); break; }
                                case " qreal": { res1 = qreal.elliptic_f(phi, k); break; }
                                case " oreal": { res1 = oreal.elliptic_f(phi, k); break; }
                                //case " yreal": { res1 = yreal.elliptic_f(phi, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.elliptic_f(phi, k); break; }
                                case "sflint": { res1 = sflint.elliptic_f(phi, k); break; }
                                case "dflint": { res1 = dflint.elliptic_f(phi, k); break; }
                                case "eflint": { res1 = eflint.elliptic_f(phi, k); break; }
                                case "qflint": { res1 = qflint.elliptic_f(phi, k); break; }
                                case "oflint": { res1 = oflint.elliptic_f(phi, k); break; }
                                case "cflint": { res1 = cflint.elliptic_f(phi, k); break; }
                                case "mflint": { res1 = mflint.elliptic_f(phi, k); break; }
                                case "iflint": { res1 = iflint.elliptic_f(phi, k); break; }
                                case "aflint": { res1 = aflint.elliptic_f(phi, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: elliptic_f(phi={1}, k={2}): {3}", NumType, phi, k, res1);
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
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.elliptic_e_inc(phi, k); break; }  //math53.elliptic_e_inc(phi, k);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.elliptic_e_inc(phi, k); break; }
                                case " dreal": { res1 = dreal.elliptic_e_inc(phi, k); break; }
                                case " ereal": { res1 = ereal.elliptic_e_inc(phi, k); break; }
                                case " qreal": { res1 = qreal.elliptic_e_inc(phi, k); break; }
                                case " oreal": { res1 = oreal.elliptic_e_inc(phi, k); break; }
                                //case " yreal": { res1 = yreal.elliptic_e_inc(phi, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.elliptic_e_inc(phi, k); break; }
                                case "sflint": { res1 = sflint.elliptic_e_inc(phi, k); break; }
                                case "dflint": { res1 = dflint.elliptic_e_inc(phi, k); break; }
                                case "eflint": { res1 = eflint.elliptic_e_inc(phi, k); break; }
                                case "qflint": { res1 = qflint.elliptic_e_inc(phi, k); break; }
                                case "oflint": { res1 = oflint.elliptic_e_inc(phi, k); break; }
                                case "cflint": { res1 = cflint.elliptic_e_inc(phi, k); break; }
                                case "mflint": { res1 = mflint.elliptic_e_inc(phi, k); break; }
                                case "iflint": { res1 = iflint.elliptic_e_inc(phi, k); break; }
                                case "aflint": { res1 = aflint.elliptic_e_inc(phi, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: elliptic_e_inc(phi={1}, k={2}): {3}", NumType, phi, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_pi"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var nu in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.elliptic_pi(nu, k); break; }  // math53.elliptic_pi(k, nu);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.elliptic_pi(nu, k); break; }
                                case " dreal": { res1 = dreal.elliptic_pi(nu, k); break; }
                                case " ereal": { res1 = ereal.elliptic_pi(nu, k); break; }
                                case " qreal": { res1 = qreal.elliptic_pi(nu, k); break; }
                                case " oreal": { res1 = oreal.elliptic_pi(nu, k); break; }
                                //case " yreal": { res1 = yreal.elliptic_pi(nu, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.elliptic_pi(nu, k); break; }
                                case "sflint": { res1 = sflint.elliptic_pi(nu, k); break; }
                                case "dflint": { res1 = dflint.elliptic_pi(nu, k); break; }
                                case "eflint": { res1 = eflint.elliptic_pi(nu, k); break; }
                                case "qflint": { res1 = qflint.elliptic_pi(nu, k); break; }
                                case "oflint": { res1 = oflint.elliptic_pi(nu, k); break; }
                                case "cflint": { res1 = cflint.elliptic_pi(nu, k); break; }
                                case "mflint": { res1 = mflint.elliptic_pi(nu, k); break; }
                                case "iflint": { res1 = iflint.elliptic_pi(nu, k); break; }
                                case "aflint": { res1 = aflint.elliptic_pi(nu, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: elliptic_pi(nu={1}, k={2}): {3}", NumType, nu, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_pi_inc"))
            {
                InputArray1 = new[] { 0.01d, 0.5d, 0.99d };
                InputArray2 = new[] { 0.01d, 0.5d, 0.99d };
                InputArray3 = new[] { 0.1d, 0.5d, 1.0d, 1.5d };
                foreach (var k in InputArray1)
                {
                    foreach (var n in InputArray2)
                    {
                        foreach (var phi in InputArray3)
                        {
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    //case "math53": { res1 = math53.elliptic_pi_inc(k, n, phi); break; }  //  math53.elliptic_pi_inc(k, n, phi);  // different order of terms
                                    case " sreal": { res1 = sreal.elliptic_pi_inc(k, n, phi); break; }
                                    case " dreal": { res1 = dreal.elliptic_pi_inc(k, n, phi); break; }
                                    case " ereal": { res1 = ereal.elliptic_pi_inc(k, n, phi); break; }
                                    case " qreal": { res1 = qreal.elliptic_pi_inc(k, n, phi); break; }
                                    case " oreal": { res1 = oreal.elliptic_pi_inc(k, n, phi); break; }
                                    //case " yreal": { res1 = yreal.elliptic_pi_inc(k, n, phi); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.elliptic_pi_inc(k, n, phi); break; }
                                    case "sflint": { res1 = sflint.elliptic_pi_inc(k, n, phi); break; }
                                    case "dflint": { res1 = dflint.elliptic_pi_inc(k, n, phi); break; }
                                    case "eflint": { res1 = eflint.elliptic_pi_inc(k, n, phi); break; }
                                    case "qflint": { res1 = qflint.elliptic_pi_inc(k, n, phi); break; }
                                    case "oflint": { res1 = oflint.elliptic_pi_inc(k, n, phi); break; }
                                    case "cflint": { res1 = cflint.elliptic_pi_inc(k, n, phi); break; }
                                    case "mflint": { res1 = mflint.elliptic_pi_inc(k, n, phi); break; }
                                    case "iflint": { res1 = iflint.elliptic_pi_inc(k, n, phi); break; }
                                    case "aflint": { res1 = aflint.elliptic_pi_inc(k, n, phi); break; }
#endif
                                }
                                Console.WriteLine("{0}: elliptic_pi_inc(k={1}, n={2}, phi={3}): {4}", NumType, k, n, phi, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }





            #endregion




            #region Bulirsch elliptic integrals



            #endregion



            #region Maple style elliptic integrals



            #endregion




            #region Jacobi elliptic functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_cd"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                // case "math53": { res1 = math53.jacobi_cd(x, k); break; } //  math53.jacobi_cd(k, x);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.jacobi_cd(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_cd(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_cd(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_cd(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_cd(x, k); break; }
                                //case " yreal": { res1 = yreal.jacobi_cd(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_cd(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_cd(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_cd(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_cd(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_cd(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_cd(x, k); break; }
                                case "cflint": { res1 = cflint.jacobi_cd(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_cd(x, k); break; }
                                case "iflint": { res1 = iflint.jacobi_cd(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_cd(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_cd(x={1}, k={2}): {3}", NumType, x, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_cn"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.jacobi_cn(x, k); break; }  // math53.jacobi_cn(k, x);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.jacobi_cn(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_cn(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_cn(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_cn(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_cn(x, k); break; }
                                //case " yreal": { res1 = yreal.jacobi_cn(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_cn(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_cn(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_cn(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_cn(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_cn(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_cn(x, k); break; }
                                case "cflint": { res1 = cflint.jacobi_cn(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_cn(x, k); break; }
                                case "iflint": { res1 = iflint.jacobi_cn(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_cn(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_cn(x={1}, k={2}): {3}", NumType, x, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_cs"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.jacobi_cs(x, k); break; } // math53.jacobi_cs(k, x);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.jacobi_cs(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_cs(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_cs(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_cs(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_cs(x, k); break; }
                                //case " yreal": { res1 = yreal.jacobi_cs(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_cs(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_cs(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_cs(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_cs(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_cs(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_cs(x, k); break; }
                                case "cflint": { res1 = cflint.jacobi_cs(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_cs(x, k); break; }
                                case "iflint": { res1 = iflint.jacobi_cs(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_cs(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_cs(x={1}, k={2}): {3}", NumType, x, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_dc"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.jacobi_dc(x, k); break; } // math53.jacobi_dc(k, x);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.jacobi_dc(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_dc(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_dc(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_dc(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_dc(x, k); break; }
                                //case " yreal": { res1 = yreal.jacobi_dc(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_dc(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_dc(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_dc(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_dc(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_dc(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_dc(x, k); break; }
                                case "cflint": { res1 = cflint.jacobi_dc(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_dc(x, k); break; }
                                case "iflint": { res1 = iflint.jacobi_dc(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_dc(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_dc(x={1}, k={2}): {3}", NumType, x, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_dn"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.jacobi_dn(x, k); break; } // math53.jacobi_dn(k, x);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.jacobi_dn(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_dn(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_dn(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_dn(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_dn(x, k); break; }
                                //case " yreal": { res1 = yreal.jacobi_dn(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_dn(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_dn(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_dn(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_dn(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_dn(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_dn(x, k); break; }
                                case "cflint": { res1 = cflint.jacobi_dn(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_dn(x, k); break; }
                                case "iflint": { res1 = iflint.jacobi_dn(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_dn(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_dn(x={1}, k={2}): {3}", NumType, x, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_ds"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.jacobi_ds(x, k); break; }  //math53.jacobi_ds(k, x);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.jacobi_ds(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_ds(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_ds(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_ds(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_ds(x, k); break; }
                                //case " yreal": { res1 = yreal.jacobi_ds(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_ds(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_ds(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_ds(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_ds(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_ds(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_ds(x, k); break; }
                                case "cflint": { res1 = cflint.jacobi_ds(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_ds(x, k); break; }
                                case "iflint": { res1 = iflint.jacobi_ds(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_ds(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_ds(x={1}, k={2}): {3}", NumType, x, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_nc"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.jacobi_nc(x, k); break; } // math53.jacobi_nc(k, x);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.jacobi_nc(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_nc(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_nc(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_nc(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_nc(x, k); break; }
                                //case " yreal": { res1 = yreal.jacobi_nc(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_nc(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_nc(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_nc(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_nc(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_nc(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_nc(x, k); break; }
                                case "cflint": { res1 = cflint.jacobi_nc(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_nc(x, k); break; }
                                case "iflint": { res1 = iflint.jacobi_nc(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_nc(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_nc(x={1}, k={2}): {3}", NumType, x, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_nd"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.jacobi_nd(x, k); break; } // math53.jacobi_nd(k, x);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.jacobi_nd(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_nd(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_nd(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_nd(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_nd(x, k); break; }
                                //case " yreal": { res1 = yreal.jacobi_nd(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_nd(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_nd(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_nd(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_nd(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_nd(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_nd(x, k); break; }
                                case "cflint": { res1 = cflint.jacobi_nd(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_nd(x, k); break; }
                                case "iflint": { res1 = iflint.jacobi_nd(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_nd(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_nd(x={1}, k={2}): {3}", NumType, x, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_ns"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.jacobi_ns(x, k); break; } // math53.jacobi_ns(k, x);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.jacobi_ns(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_ns(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_ns(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_ns(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_ns(x, k); break; }
                                //case " yreal": { res1 = yreal.jacobi_ns(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_ns(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_ns(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_ns(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_ns(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_ns(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_ns(x, k); break; }
                                case "cflint": { res1 = cflint.jacobi_ns(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_ns(x, k); break; }
                                case "iflint": { res1 = iflint.jacobi_ns(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_ns(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_ns(x={1}, k={2}): {3}", NumType, x, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_sc"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.jacobi_sc(x, k); break; } // math53.jacobi_sc(k, x);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.jacobi_sc(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_sc(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_sc(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_sc(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_sc(x, k); break; }
                                //case " yreal": { res1 = yreal.jacobi_sc(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_sc(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_sc(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_sc(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_sc(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_sc(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_sc(x, k); break; }
                                case "cflint": { res1 = cflint.jacobi_sc(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_sc(x, k); break; }
                                case "iflint": { res1 = iflint.jacobi_sc(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_sc(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_sc(x={1}, k={2}): {3}", NumType, x, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_sd"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.jacobi_sd(x, k); break; } // math53.jacobi_sd(k, x);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.jacobi_sd(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_sd(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_sd(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_sd(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_sd(x, k); break; }
                                //case " yreal": { res1 = yreal.jacobi_sd(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_sd(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_sd(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_sd(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_sd(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_sd(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_sd(x, k); break; }
                                case "cflint": { res1 = cflint.jacobi_sd(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_sd(x, k); break; }
                                case "iflint": { res1 = iflint.jacobi_sd(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_sd(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_sd(x={1}, k={2}): {3}", NumType, x, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_sn"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.jacobi_sn(x, k); break; } // math53.jacobi_sn(k, x);  // reversed order in DAMath
                                case " sreal": { res1 = sreal.jacobi_sn(x, k); break; }
                                case " dreal": { res1 = dreal.jacobi_sn(x, k); break; }
                                case " ereal": { res1 = ereal.jacobi_sn(x, k); break; }
                                case " qreal": { res1 = qreal.jacobi_sn(x, k); break; }
                                case " oreal": { res1 = oreal.jacobi_sn(x, k); break; }
                                //case " yreal": { res1 = yreal.jacobi_sn(x, k); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_sn(x, k); break; }
                                case "sflint": { res1 = sflint.jacobi_sn(x, k); break; }
                                case "dflint": { res1 = dflint.jacobi_sn(x, k); break; }
                                case "eflint": { res1 = eflint.jacobi_sn(x, k); break; }
                                case "qflint": { res1 = qflint.jacobi_sn(x, k); break; }
                                case "oflint": { res1 = oflint.jacobi_sn(x, k); break; }
                                case "cflint": { res1 = cflint.jacobi_sn(x, k); break; }
                                case "mflint": { res1 = mflint.jacobi_sn(x, k); break; }
                                case "iflint": { res1 = iflint.jacobi_sn(x, k); break; }
                                case "aflint": { res1 = aflint.jacobi_sn(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_sn(x={1}, k={2}): {3}", NumType, x, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion





            #region Inverse Jacobi elliptic functions



            #endregion




            #region Lemniscate functions



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
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                // case "math53": { res1 = math53.jacobi_theta1(x, q); break; }  // math53.jacobi_theta(1, x, q);
                                case " sreal": { res1 = sreal.jacobi_theta1(x, q); break; }
                                case " dreal": { res1 = dreal.jacobi_theta1(x, q); break; }
                                case " ereal": { res1 = ereal.jacobi_theta1(x, q); break; }
                                case " qreal": { res1 = qreal.jacobi_theta1(x, q); break; }
                                case " oreal": { res1 = oreal.jacobi_theta1(x, q); break; }
                                //case " yreal": { res1 = yreal.jacobi_theta1(x, q); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_theta1(x, q); break; }
                                case "sflint": { res1 = sflint.jacobi_theta1(x, q); break; }
                                case "dflint": { res1 = dflint.jacobi_theta1(x, q); break; }
                                case "eflint": { res1 = eflint.jacobi_theta1(x, q); break; }
                                case "qflint": { res1 = qflint.jacobi_theta1(x, q); break; }
                                case "oflint": { res1 = oflint.jacobi_theta1(x, q); break; }
                                case "cflint": { res1 = cflint.jacobi_theta1(x, q); break; }
                                case "mflint": { res1 = mflint.jacobi_theta1(x, q); break; }
                                case "iflint": { res1 = iflint.jacobi_theta1(x, q); break; }
                                case "aflint": { res1 = aflint.jacobi_theta1(x, q); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_theta1(x={1}, q={2}): {3}", NumType, x, q, res1);
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
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.jacobi_theta2(x, q); break; }  // math53.jacobi_theta(2, x, q);
                                case " sreal": { res1 = sreal.jacobi_theta2(x, q); break; }
                                case " dreal": { res1 = dreal.jacobi_theta2(x, q); break; }
                                case " ereal": { res1 = ereal.jacobi_theta2(x, q); break; }
                                case " qreal": { res1 = qreal.jacobi_theta2(x, q); break; }
                                case " oreal": { res1 = oreal.jacobi_theta2(x, q); break; }
                                //case " yreal": { res1 = yreal.jacobi_theta2(x, q); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_theta2(x, q); break; }
                                case "sflint": { res1 = sflint.jacobi_theta2(x, q); break; }
                                case "dflint": { res1 = dflint.jacobi_theta2(x, q); break; }
                                case "eflint": { res1 = eflint.jacobi_theta2(x, q); break; }
                                case "qflint": { res1 = qflint.jacobi_theta2(x, q); break; }
                                case "oflint": { res1 = oflint.jacobi_theta2(x, q); break; }
                                case "cflint": { res1 = cflint.jacobi_theta2(x, q); break; }
                                case "mflint": { res1 = mflint.jacobi_theta2(x, q); break; }
                                case "iflint": { res1 = iflint.jacobi_theta2(x, q); break; }
                                case "aflint": { res1 = aflint.jacobi_theta2(x, q); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_theta2(x={1}, q={2}): {3}", NumType, x, q, res1);
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
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.jacobi_theta3(x, q); break; } // math53.jacobi_theta(3, x, q);
                                case " sreal": { res1 = sreal.jacobi_theta3(x, q); break; }
                                case " dreal": { res1 = dreal.jacobi_theta3(x, q); break; }
                                case " ereal": { res1 = ereal.jacobi_theta3(x, q); break; }
                                case " qreal": { res1 = qreal.jacobi_theta3(x, q); break; }
                                case " oreal": { res1 = oreal.jacobi_theta3(x, q); break; }
                                //case " yreal": { res1 = yreal.jacobi_theta3(x, q); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_theta3(x, q); break; }
                                case "sflint": { res1 = sflint.jacobi_theta3(x, q); break; }
                                case "dflint": { res1 = dflint.jacobi_theta3(x, q); break; }
                                case "eflint": { res1 = eflint.jacobi_theta3(x, q); break; }
                                case "qflint": { res1 = qflint.jacobi_theta3(x, q); break; }
                                case "oflint": { res1 = oflint.jacobi_theta3(x, q); break; }
                                case "cflint": { res1 = cflint.jacobi_theta3(x, q); break; }
                                case "mflint": { res1 = mflint.jacobi_theta3(x, q); break; }
                                case "iflint": { res1 = iflint.jacobi_theta3(x, q); break; }
                                case "aflint": { res1 = aflint.jacobi_theta3(x, q); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_theta3(x={1}, q={2}): {3}", NumType, x, q, res1);
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
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                // case "math53": { res1 = math53.jacobi_theta4(x, q); break; } // math53.jacobi_theta(4, x, q);
                                case " sreal": { res1 = sreal.jacobi_theta4(x, q); break; }
                                case " dreal": { res1 = dreal.jacobi_theta4(x, q); break; }
                                case " ereal": { res1 = ereal.jacobi_theta4(x, q); break; }
                                case " qreal": { res1 = qreal.jacobi_theta4(x, q); break; }
                                case " oreal": { res1 = oreal.jacobi_theta4(x, q); break; }
                                //case " yreal": { res1 = yreal.jacobi_theta4(x, q); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.jacobi_theta4(x, q); break; }
                                case "sflint": { res1 = sflint.jacobi_theta4(x, q); break; }
                                case "dflint": { res1 = dflint.jacobi_theta4(x, q); break; }
                                case "eflint": { res1 = eflint.jacobi_theta4(x, q); break; }
                                case "qflint": { res1 = qflint.jacobi_theta4(x, q); break; }
                                case "oflint": { res1 = oflint.jacobi_theta4(x, q); break; }
                                case "cflint": { res1 = cflint.jacobi_theta4(x, q); break; }
                                case "mflint": { res1 = mflint.jacobi_theta4(x, q); break; }
                                case "iflint": { res1 = iflint.jacobi_theta4(x, q); break; }
                                case "aflint": { res1 = aflint.jacobi_theta4(x, q); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_theta4(x={1}, q={2}): {3}", NumType, x, q, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion




            #region Neville theta functions



            #endregion




            #region  Conversions of parameters of Weierstrass



            #endregion



            #region  Weierstrass elliptic functions, in terms of (real) lattice invariants g2, g3



            #endregion



            #region  Weierstrass elliptic functions, in terms of (real) lattice roots e1, e2



            #endregion



            #region  Weierstrass elliptic functions, in terms of lattice roots half-periods omega1, omega2



            #endregion



            #region  Weierstrass elliptic functions, in terms of elliptic period ratio tau



            #endregion




            #region  Modular forms and related



            #endregion



        }



        public static void DemoChapterLerchPhi(string[] NumTypeArray, string[] FunctionArray)
        {

            double[] InputArray1;
            // Dim InputArray2 As Double()
            // Dim InputArray3 As Double()
            // Dim InputArray4 As Double()
            int[] InputArrayInt1;
            // Dim InputArrayInt2 As Integer()


            #region LerchPhi



            #endregion



            #region Polygamma functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("digamma"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
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
                            //case " yreal": { res1 = yreal.digamma(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.digamma(x1); break; }
                            case "sflint": { res1 = sflint.digamma(x1); break; }
                            case "dflint": { res1 = dflint.digamma(x1); break; }
                            case "eflint": { res1 = eflint.digamma(x1); break; }
                            case "qflint": { res1 = qflint.digamma(x1); break; }
                            case "oflint": { res1 = oflint.digamma(x1); break; }
                            case "cflint": { res1 = cflint.digamma(x1); break; }
                            case "mflint": { res1 = mflint.digamma(x1); break; }
                            case "iflint": { res1 = iflint.digamma(x1); break; }
                            case "aflint": { res1 = aflint.digamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: digamma({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("trigamma"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
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
                            //case " yreal": { res1 = yreal.trigamma(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.trigamma(x1); break; }
                            //case "sflint": { res1 = sflint.trigamma(x1); break; }
                            //case "dflint": { res1 = dflint.trigamma(x1); break; }
                            //case "eflint": { res1 = eflint.trigamma(x1); break; }
                            //case "qflint": { res1 = qflint.trigamma(x1); break; }
                            //case "oflint": { res1 = oflint.trigamma(x1); break; }
                            //case "cflint": { res1 = cflint.trigamma(x1); break; }
                            //case "mflint": { res1 = mflint.trigamma(x1); break; }
                            //case "iflint": { res1 = iflint.trigamma(x1); break; }
                            //case "aflint": { res1 = aflint.trigamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: trigamma({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("polygamma"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d, double.PositiveInfinity }; // -inf , Nan crashes
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
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
                                //case " yreal": { res1 = yreal.polygamma(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.polygamma(n, x); break; }
                                case "sflint": { res1 = sflint.polygamma(n, x); break; }
                                case "dflint": { res1 = dflint.polygamma(n, x); break; }
                                case "eflint": { res1 = eflint.polygamma(n, x); break; }
                                case "qflint": { res1 = qflint.polygamma(n, x); break; }
                                case "oflint": { res1 = oflint.polygamma(n, x); break; }
                                case "cflint": { res1 = cflint.polygamma(n, x); break; }
                                case "mflint": { res1 = mflint.polygamma(n, x); break; }
                                case "iflint": { res1 = iflint.polygamma(n, x); break; }
                                case "aflint": { res1 = aflint.polygamma(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: polygamma({1}, {2}): {3}", NumType, n, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Polylogarithm



            #endregion



            #region Hurwitz zeta function and related functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bernoulli"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                foreach (var n in InputArrayInt1)
                {
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
                            //case " yreal": { res1 = yreal.bernoulli(n); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.bernoulli(n); break; }
                            case "sflint": { res1 = sflint.bernoulli(n); break; }
                            case "dflint": { res1 = dflint.bernoulli(n); break; }
                            case "eflint": { res1 = eflint.bernoulli(n); break; }
                            case "qflint": { res1 = qflint.bernoulli(n); break; }
                            case "oflint": { res1 = oflint.bernoulli(n); break; }
                            case "cflint": { res1 = cflint.bernoulli(n); break; }
                            case "mflint": { res1 = mflint.bernoulli(n); break; }
                            case "iflint": { res1 = iflint.bernoulli(n); break; }
                            case "aflint": { res1 = aflint.bernoulli(n); break; }
#endif
                        }
                        Console.WriteLine("{0}: bernoulli({1}): {2}", NumType, n, res1);
                    }
                }
                Console.WriteLine();
            }

            #endregion



            #region Dirichlet L-Series, Riemann zeta function, and related functions

            if (FunctionArray.Contains("all") | FunctionArray.Contains("zeta"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
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
                            //case " yreal": { res1 = yreal.zeta(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.zeta(x1); break; }
                            case "sflint": { res1 = sflint.zeta(x1); break; }
                            case "dflint": { res1 = dflint.zeta(x1); break; }
                            case "eflint": { res1 = eflint.zeta(x1); break; }
                            case "qflint": { res1 = qflint.zeta(x1); break; }
                            case "oflint": { res1 = oflint.zeta(x1); break; }
                            case "cflint": { res1 = cflint.zeta(x1); break; }
                            case "mflint": { res1 = mflint.zeta(x1); break; }
                            case "iflint": { res1 = iflint.zeta(x1); break; }
                            case "aflint": { res1 = aflint.zeta(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: zeta({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Additional numbertheoretic functions



            #endregion




        }



        public static void DemoChapter0F1(string[] NumTypeArray, string[] FunctionArray)
        {

            double[] InputArray1;
            double[] InputArray2;
            // Dim InputArray3 As Double()
            // Dim InputArray4 As Double()
            int[] InputArrayInt1;
            // Dim InputArrayInt2 As Integer()

            int n_;
            double x_, res_; //, v_, u_


            #region 0F1: Overview


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_0f1"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var b in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.hyperg_0f1(b, x); break; }
                                case " sreal": { res1 = sreal.hyperg_0f1(b, x); break; }
                                case " dreal": { res1 = dreal.hyperg_0f1(b, x); break; }
                                case " ereal": { res1 = ereal.hyperg_0f1(b, x); break; }
                                case " qreal": { res1 = qreal.hyperg_0f1(b, x); break; }
                                case " oreal": { res1 = oreal.hyperg_0f1(b, x); break; }
                                //case " yreal": { res1 = yreal.hyperg_0f1(b, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.hyperg_0f1(b, x); break; }
                                case "sflint": { res1 = sflint.hyperg_0f1(b, x); break; }
                                case "dflint": { res1 = dflint.hyperg_0f1(b, x); break; }
                                case "eflint": { res1 = eflint.hyperg_0f1(b, x); break; }
                                case "qflint": { res1 = qflint.hyperg_0f1(b, x); break; }
                                case "oflint": { res1 = oflint.hyperg_0f1(b, x); break; }
                                case "cflint": { res1 = cflint.hyperg_0f1(b, x); break; }
                                case "mflint": { res1 = mflint.hyperg_0f1(b, x); break; }
                                case "iflint": { res1 = iflint.hyperg_0f1(b, x); break; }
                                case "aflint": { res1 = aflint.hyperg_0f1(b, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: hyperg_0f1(b={1}, x={2}): {3}", NumType, b, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            #endregion




            #region Bessel functions of integer order

            Console.WriteLine("Hello DemoDoubleBessel!");


            x_ = 0.75d;
            res_ = math53.bessel_j0(x_);
            Console.WriteLine("x_: {0}, math53.BesselJ0(x_): {1}", x_, res_);

            x_ = 0.75d;
            res_ = math53.bessel_j1(x_);
            Console.WriteLine("x_: {0}, math53.BesselJ1(x_): {1}", x_, res_);

            x_ = 0.75d;
            n_ = 3;
            res_ = math53.bessel_jn(n_, x_);
            Console.WriteLine("n_: {0}, x_: {1}, math53.BesselJn(n_, x_): {2}", n_, x_, res_);


            Console.WriteLine();


            x_ = 0.75d;
            res_ = math53.bessel_y0(x_);
            Console.WriteLine("x_: {0}, math53.BesselY0(x_): {1}", x_, res_);

            x_ = 0.75d;
            res_ = math53.bessel_y1(x_);
            Console.WriteLine("x_: {0}, math53.BesselY1(x_): {1}", x_, res_);

            x_ = 0.75d;
            n_ = 3;
            res_ = math53.bessel_yn(n_, x_);
            Console.WriteLine("n_: {0}, x_: {1}, math53.BesselYn(n_, x_): {2}", n_, x_, res_);


            Console.WriteLine();



            #endregion




            #region Modified Bessel functions of integer order



            x_ = 0.75d;
            res_ = math53.bessel_i0(x_);
            Console.WriteLine("x_: {0}, math53.BesselI0(x_): {1}", x_, res_);

            x_ = 0.75d;
            res_ = math53.bessel_i0e(x_);
            Console.WriteLine("x_: {0}, math53.BesselI0e(x_): {1}", x_, res_);

            x_ = 0.75d;
            res_ = math53.bessel_i1(x_);
            Console.WriteLine("x_: {0}, math53.BesselI1(x_): {1}", x_, res_);

            x_ = 0.75d;
            res_ = math53.bessel_i1e(x_);
            Console.WriteLine("x_: {0}, math53.BesselI1e(x_): {1}", x_, res_);

            x_ = 0.75d;
            n_ = 3;
            res_ = math53.bessel_in(n_, x_);
            Console.WriteLine("n_: {0}, x_: {1}, math53.BesselIn(n_, x_): {2}", n_, x_, res_);


            Console.WriteLine();


            x_ = 0.75d;
            res_ = math53.bessel_k0(x_);
            Console.WriteLine("x_: {0}, math53.BesselK0(x_): {1}", x_, res_);

            x_ = 0.75d;
            res_ = math53.bessel_k0e(x_);
            Console.WriteLine("x_: {0}, math53.BesselK0e(x_): {1}", x_, res_);

            x_ = 0.75d;
            res_ = math53.bessel_k1(x_);
            Console.WriteLine("x_: {0}, math53.BesselK1(x_): {1}", x_, res_);

            x_ = 0.75d;
            res_ = math53.bessel_k1e(x_);
            Console.WriteLine("x_: {0}, math53.BesselK1e(x_): {1}", x_, res_);

            x_ = 0.75d;
            n_ = 3;
            res_ = math53.bessel_kn(n_, x_);
            Console.WriteLine("n_: {0}, x_: {1}, math53.BesselIn(n_, x_): {2}", n_, x_, res_);







            #endregion




            #region Bessel functions and modified Bessel functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_jv"))
            {
                // InputArray1 = {-4.333, 0.0, 1.0, 1.5, 4.333}
                // InputArray2 = {-4.333, 0.0, 1.0, 1.5, 4.333}
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_jv(nu, x); break; }
                                case " sreal": { res1 = sreal.bessel_jv(nu, x); break; }
                                case " dreal": { res1 = dreal.bessel_jv(nu, x); break; }
                                case " ereal": { res1 = ereal.bessel_jv(nu, x); break; }
                                case " qreal": { res1 = qreal.bessel_jv(nu, x); break; }
                                case " oreal": { res1 = oreal.bessel_jv(nu, x); break; }
                                //case " yreal": { res1 = yreal.bessel_jv(nu, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_jv(nu, x); break; }
                                case "sflint": { res1 = sflint.bessel_jv(nu, x); break; }
                                case "dflint": { res1 = dflint.bessel_jv(nu, x); break; }
                                case "eflint": { res1 = eflint.bessel_jv(nu, x); break; }
                                case "qflint": { res1 = qflint.bessel_jv(nu, x); break; }
                                case "oflint": { res1 = oflint.bessel_jv(nu, x); break; }
                                case "cflint": { res1 = cflint.bessel_jv(nu, x); break; }
                                case "mflint": { res1 = mflint.bessel_jv(nu, x); break; }
                                case "iflint": { res1 = iflint.bessel_jv(nu, x); break; }
                                case "aflint": { res1 = aflint.bessel_jv(nu, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: bessel_jv({1}, {2}): {3}", NumType, nu, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_yv"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_yv(nu, x); break; }
                                case " sreal": { res1 = sreal.bessel_yv(nu, x); break; }
                                case " dreal": { res1 = dreal.bessel_yv(nu, x); break; }
                                case " ereal": { res1 = ereal.bessel_yv(nu, x); break; }
                                case " qreal": { res1 = qreal.bessel_yv(nu, x); break; }
                                case " oreal": { res1 = oreal.bessel_yv(nu, x); break; }
                                //case " yreal": { res1 = yreal.bessel_yv(nu, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_yv(nu, x); break; }
                                case "sflint": { res1 = sflint.bessel_yv(nu, x); break; }
                                case "dflint": { res1 = dflint.bessel_yv(nu, x); break; }
                                case "eflint": { res1 = eflint.bessel_yv(nu, x); break; }
                                case "qflint": { res1 = qflint.bessel_yv(nu, x); break; }
                                case "oflint": { res1 = oflint.bessel_yv(nu, x); break; }
                                case "cflint": { res1 = cflint.bessel_yv(nu, x); break; }
                                case "mflint": { res1 = mflint.bessel_yv(nu, x); break; }
                                case "iflint": { res1 = iflint.bessel_yv(nu, x); break; }
                                case "aflint": { res1 = aflint.bessel_yv(nu, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: bessel_yv({1}, {2}): {3}", NumType, nu, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_iv"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_iv(nu, x); break; }
                                case " sreal": { res1 = sreal.bessel_iv(nu, x); break; }
                                case " dreal": { res1 = dreal.bessel_iv(nu, x); break; }
                                case " ereal": { res1 = ereal.bessel_iv(nu, x); break; }
                                case " qreal": { res1 = qreal.bessel_iv(nu, x); break; }
                                case " oreal": { res1 = oreal.bessel_iv(nu, x); break; }
                                //case " yreal": { res1 = yreal.bessel_iv(nu, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_iv(nu, x); break; }
                                case "sflint": { res1 = sflint.bessel_iv(nu, x); break; }
                                case "dflint": { res1 = dflint.bessel_iv(nu, x); break; }
                                case "eflint": { res1 = eflint.bessel_iv(nu, x); break; }
                                case "qflint": { res1 = qflint.bessel_iv(nu, x); break; }
                                case "oflint": { res1 = oflint.bessel_iv(nu, x); break; }
                                case "cflint": { res1 = cflint.bessel_iv(nu, x); break; }
                                case "mflint": { res1 = mflint.bessel_iv(nu, x); break; }
                                case "iflint": { res1 = iflint.bessel_iv(nu, x); break; }
                                case "aflint": { res1 = aflint.bessel_iv(nu, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: bessel_iv({1}, {2}): {3}", NumType, nu, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_kv"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_kv(nu, x); break; }
                                case " sreal": { res1 = sreal.bessel_kv(nu, x); break; }
                                case " dreal": { res1 = dreal.bessel_kv(nu, x); break; }
                                case " ereal": { res1 = ereal.bessel_kv(nu, x); break; }
                                case " qreal": { res1 = qreal.bessel_kv(nu, x); break; }
                                case " oreal": { res1 = oreal.bessel_kv(nu, x); break; }
                                //case " yreal": { res1 = yreal.bessel_kv(nu, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_kv(nu, x); break; }
                                case "sflint": { res1 = sflint.bessel_kv(nu, x); break; }
                                case "dflint": { res1 = dflint.bessel_kv(nu, x); break; }
                                case "eflint": { res1 = eflint.bessel_kv(nu, x); break; }
                                case "qflint": { res1 = qflint.bessel_kv(nu, x); break; }
                                case "oflint": { res1 = oflint.bessel_kv(nu, x); break; }
                                case "cflint": { res1 = cflint.bessel_kv(nu, x); break; }
                                case "mflint": { res1 = mflint.bessel_kv(nu, x); break; }
                                case "iflint": { res1 = iflint.bessel_kv(nu, x); break; }
                                case "aflint": { res1 = aflint.bessel_kv(nu, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: bessel_kv({1}, {2}): {3}", NumType, nu, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_jv_prime"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.bessel_jv_prime(nu, x); break; }
                                case " sreal": { res1 = sreal.bessel_jv_prime(nu, x); break; }
                                case " dreal": { res1 = dreal.bessel_jv_prime(nu, x); break; }
                                case " ereal": { res1 = ereal.bessel_jv_prime(nu, x); break; }
                                case " qreal": { res1 = qreal.bessel_jv_prime(nu, x); break; }
                                case " oreal": { res1 = oreal.bessel_jv_prime(nu, x); break; }
                                //case " yreal": { res1 = yreal.bessel_jv_prime(nu, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_jv_prime(nu, x); break; }
                                //case "sflint": { res1 = sflint.bessel_jv_prime(nu, x); break; }
                                //case "dflint": { res1 = dflint.bessel_jv_prime(nu, x); break; }
                                //case "eflint": { res1 = eflint.bessel_jv_prime(nu, x); break; }
                                //case "qflint": { res1 = qflint.bessel_jv_prime(nu, x); break; }
                                //case "oflint": { res1 = oflint.bessel_jv_prime(nu, x); break; }
                                //case "cflint": { res1 = cflint.bessel_jv_prime(nu, x); break; }
                                //case "mflint": { res1 = mflint.bessel_jv_prime(nu, x); break; }
                                //case "iflint": { res1 = iflint.bessel_jv_prime(nu, x); break; }
                                //case "aflint": { res1 = aflint.bessel_jv_prime(nu, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: bessel_jv_prime({1}, {2}): {3}", NumType, nu, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_yv_prime"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.bessel_yv_prime(nu, x); break; }
                                case " sreal": { res1 = sreal.bessel_yv_prime(nu, x); break; }
                                case " dreal": { res1 = dreal.bessel_yv_prime(nu, x); break; }
                                case " ereal": { res1 = ereal.bessel_yv_prime(nu, x); break; }
                                case " qreal": { res1 = qreal.bessel_yv_prime(nu, x); break; }
                                case " oreal": { res1 = oreal.bessel_yv_prime(nu, x); break; }
                                //case " yreal": { res1 = yreal.bessel_yv_prime(nu, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_yv_prime(nu, x); break; }
                                //case "sflint": { res1 = sflint.bessel_yv_prime(nu, x); break; }
                                //case "dflint": { res1 = dflint.bessel_yv_prime(nu, x); break; }
                                //case "eflint": { res1 = eflint.bessel_yv_prime(nu, x); break; }
                                //case "qflint": { res1 = qflint.bessel_yv_prime(nu, x); break; }
                                //case "oflint": { res1 = oflint.bessel_yv_prime(nu, x); break; }
                                //case "cflint": { res1 = cflint.bessel_yv_prime(nu, x); break; }
                                //case "mflint": { res1 = mflint.bessel_yv_prime(nu, x); break; }
                                //case "iflint": { res1 = iflint.bessel_yv_prime(nu, x); break; }
                                //case "aflint": { res1 = aflint.bessel_yv_prime(nu, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: bessel_yv_prime({1}, {2}): {3}", NumType, nu, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_iv_prime"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.bessel_iv_prime(nu, x); break; }
                                case " sreal": { res1 = sreal.bessel_iv_prime(nu, x); break; }
                                case " dreal": { res1 = dreal.bessel_iv_prime(nu, x); break; }
                                case " ereal": { res1 = ereal.bessel_iv_prime(nu, x); break; }
                                case " qreal": { res1 = qreal.bessel_iv_prime(nu, x); break; }
                                case " oreal": { res1 = oreal.bessel_iv_prime(nu, x); break; }
                                //case " yreal": { res1 = yreal.bessel_iv_prime(nu, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_iv_prime(nu, x); break; }
                                //case "sflint": { res1 = sflint.bessel_iv_prime(nu, x); break; }
                                //case "dflint": { res1 = dflint.bessel_iv_prime(nu, x); break; }
                                //case "eflint": { res1 = eflint.bessel_iv_prime(nu, x); break; }
                                //case "qflint": { res1 = qflint.bessel_iv_prime(nu, x); break; }
                                //case "oflint": { res1 = oflint.bessel_iv_prime(nu, x); break; }
                                //case "cflint": { res1 = cflint.bessel_iv_prime(nu, x); break; }
                                //case "mflint": { res1 = mflint.bessel_iv_prime(nu, x); break; }
                                //case "iflint": { res1 = iflint.bessel_iv_prime(nu, x); break; }
                                //case "aflint": { res1 = aflint.bessel_iv_prime(nu, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: bessel_iv_prime({1}, {2}): {3}", NumType, nu, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_kv_prime"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.bessel_kv_prime(nu, x); break; }
                                case " sreal": { res1 = sreal.bessel_kv_prime(nu, x); break; }
                                case " dreal": { res1 = dreal.bessel_kv_prime(nu, x); break; }
                                case " ereal": { res1 = ereal.bessel_kv_prime(nu, x); break; }
                                case " qreal": { res1 = qreal.bessel_kv_prime(nu, x); break; }
                                case " oreal": { res1 = oreal.bessel_kv_prime(nu, x); break; }
                                //case " yreal": { res1 = yreal.bessel_kv_prime(nu, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_kv_prime(nu, x); break; }
                                //case "sflint": { res1 = sflint.bessel_kv_prime(nu, x); break; }
                                //case "dflint": { res1 = dflint.bessel_kv_prime(nu, x); break; }
                                //case "eflint": { res1 = eflint.bessel_kv_prime(nu, x); break; }
                                //case "qflint": { res1 = qflint.bessel_kv_prime(nu, x); break; }
                                //case "oflint": { res1 = oflint.bessel_kv_prime(nu, x); break; }
                                //case "cflint": { res1 = cflint.bessel_kv_prime(nu, x); break; }
                                //case "mflint": { res1 = mflint.bessel_kv_prime(nu, x); break; }
                                //case "iflint": { res1 = iflint.bessel_kv_prime(nu, x); break; }
                                //case "aflint": { res1 = aflint.bessel_kv_prime(nu, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: bessel_kv_prime({1}, {2}): {3}", NumType, nu, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_jv_zero"))
            {
                InputArray1 = new[] { -0.333d, 0.0d, 1.333d, 10.333d, double.PositiveInfinity }; // crashes with nan
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                foreach (var nu in InputArray1)
                {
                    foreach (var m in InputArrayInt1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.bessel_jv_zero(sreal.t(nu), m); break; }
                                case " sreal": { res1 = sreal.bessel_jv_zero(sreal.t(nu), m); break; }
                                case " dreal": { res1 = dreal.bessel_jv_zero(sreal.t(nu), m); break; }
                                case " ereal": { res1 = ereal.bessel_jv_zero(sreal.t(nu), m); break; }
                                case " qreal": { res1 = qreal.bessel_jv_zero(sreal.t(nu), m); break; }
                                case " oreal": { res1 = oreal.bessel_jv_zero(sreal.t(nu), m); break; }
                                //case " yreal": { res1 = yreal.bessel_jv_zero(sreal.t(nu), m); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_jv_zero(sreal.t(nu), m); break; }
                                //case "sflint": { res1 = sflint.bessel_jv_zero(sreal.t(nu), m); break; }
                                //case "dflint": { res1 = dflint.bessel_jv_zero(sreal.t(nu), m); break; }
                                //case "eflint": { res1 = eflint.bessel_jv_zero(sreal.t(nu), m); break; }
                                //case "qflint": { res1 = qflint.bessel_jv_zero(sreal.t(nu), m); break; }
                                //case "oflint": { res1 = oflint.bessel_jv_zero(sreal.t(nu), m); break; }
                                //case "cflint": { res1 = cflint.bessel_jv_zero(sreal.t(nu), m); break; }
                                //case "mflint": { res1 = mflint.bessel_jv_zero(sreal.t(nu), m); break; }
                                //case "iflint": { res1 = iflint.bessel_jv_zero(sreal.t(nu), m); break; }
                                //case "aflint": { res1 = aflint.bessel_jv_zero(sreal.t(nu), m); break; }
#endif
                            }
                            Console.WriteLine("{0}: bessel_jv_zero(nu={1}, m={2}): {3}", NumType, nu, m, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_yv_zero"))
            {
                InputArray1 = new[] { -0.333d, 0.0d, 1.333d, 10.333d, double.PositiveInfinity }; // crashes with nan
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                foreach (var nu in InputArray1)
                {
                    foreach (var m in InputArrayInt1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.bessel_yv_zero(sreal.t(nu), m); break; }
                                case " sreal": { res1 = sreal.bessel_yv_zero(sreal.t(nu), m); break; }
                                case " dreal": { res1 = dreal.bessel_yv_zero(sreal.t(nu), m); break; }
                                case " ereal": { res1 = ereal.bessel_yv_zero(sreal.t(nu), m); break; }
                                case " qreal": { res1 = qreal.bessel_yv_zero(sreal.t(nu), m); break; }
                                case " oreal": { res1 = oreal.bessel_yv_zero(sreal.t(nu), m); break; }
                                //case " yreal": { res1 = yreal.bessel_yv_zero(sreal.t(nu), m); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_yv_zero(sreal.t(nu), m); break; }
                                //case "sflint": { res1 = sflint.bessel_yv_zero(sreal.t(nu), m); break; }
                                //case "dflint": { res1 = dflint.bessel_yv_zero(sreal.t(nu), m); break; }
                                //case "eflint": { res1 = eflint.bessel_yv_zero(sreal.t(nu), m); break; }
                                //case "qflint": { res1 = qflint.bessel_yv_zero(sreal.t(nu), m); break; }
                                //case "oflint": { res1 = oflint.bessel_yv_zero(sreal.t(nu), m); break; }
                                //case "cflint": { res1 = cflint.bessel_yv_zero(sreal.t(nu), m); break; }
                                //case "mflint": { res1 = mflint.bessel_yv_zero(sreal.t(nu), m); break; }
                                //case "iflint": { res1 = iflint.bessel_yv_zero(sreal.t(nu), m); break; }
                                //case "aflint": { res1 = aflint.bessel_yv_zero(sreal.t(nu), m); break; }
#endif
                            }
                            Console.WriteLine("{0}: bessel_yv_zero(nu={1}, m={2}): {3}", NumType, nu, m, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            #endregion




            #region Spherical Bessel functions

            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_jn"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                // InputArray1 = {-0.333, 0.0, 0.333, Double.PositiveInfinity} ' crashes with nan
                InputArray1 = new[] { -0.33d, 0.0d, 0.333d, double.PositiveInfinity }; // crashes with nan or negative inf
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_bessel_jn(n, x); break; }
                                case " sreal": { res1 = sreal.sph_bessel_jn(n, x); break; }
                                //case " dreal": { res1 = dreal.sph_bessel_jn(n, x); break; }  // cannot convert from int to uint
                                case " ereal": { res1 = ereal.sph_bessel_jn(n, x); break; }
                                case " qreal": { res1 = qreal.sph_bessel_jn(n, x); break; }
                                case " oreal": { res1 = oreal.sph_bessel_jn(n, x); break; }
                                //case " yreal": { res1 = yreal.sph_bessel_jn(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_bessel_jn(n, x); break; }
                                    //case "sflint": { res1 = sflint.sph_bessel_jn(n, x); break; }
                                    //case "dflint": { res1 = dflint.sph_bessel_jn(n, x); break; }
                                    //case "eflint": { res1 = eflint.sph_bessel_jn(n, x); break; }
                                    //case "qflint": { res1 = qflint.sph_bessel_jn(n, x); break; }
                                    //case "oflint": { res1 = oflint.sph_bessel_jn(n, x); break; }
                                    //case "cflint": { res1 = cflint.sph_bessel_jn(n, x); break; }
                                    //case "mflint": { res1 = mflint.sph_bessel_jn(n, x); break; }
                                    //case "iflint": { res1 = iflint.sph_bessel_jn(n, x); break; }
                                    //case "aflint": { res1 = aflint.sph_bessel_jn(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: sph_bessel_jn({1}, {2}): {3}", NumType, n, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_yn"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                // InputArray1 = {-0.333, 0.0, 0.333, Double.PositiveInfinity} ' crashes with nan
                InputArray1 = new[] { -0.33d, 0.0d, 0.333d, double.PositiveInfinity }; // crashes with nan or negative inf
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_bessel_yn(n, x); break; }
                                case " sreal": { res1 = sreal.sph_bessel_yn(n, x); break; }
                                //case " dreal": { res1 = dreal.sph_bessel_yn(n, x); break; }  // cannot convert from int to uint
                                case " ereal": { res1 = ereal.sph_bessel_yn(n, x); break; }
                                case " qreal": { res1 = qreal.sph_bessel_yn(n, x); break; }
                                case " oreal": { res1 = oreal.sph_bessel_yn(n, x); break; }
                                //case " yreal": { res1 = yreal.sph_bessel_yn(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_bessel_yn(n, x); break; }
                                    //case "sflint": { res1 = sflint.sph_bessel_yn(n, x); break; }
                                    //case "dflint": { res1 = dflint.sph_bessel_yn(n, x); break; }
                                    //case "eflint": { res1 = eflint.sph_bessel_yn(n, x); break; }
                                    //case "qflint": { res1 = qflint.sph_bessel_yn(n, x); break; }
                                    //case "oflint": { res1 = oflint.sph_bessel_yn(n, x); break; }
                                    //case "cflint": { res1 = cflint.sph_bessel_yn(n, x); break; }
                                    //case "mflint": { res1 = mflint.sph_bessel_yn(n, x); break; }
                                    //case "iflint": { res1 = iflint.sph_bessel_yn(n, x); break; }
                                    //case "aflint": { res1 = aflint.sph_bessel_yn(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: sph_bessel_yn({1}, {2}): {3}", NumType, n, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_jn_prime"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                // InputArray1 = {-0.333, 0.0, 0.333, Double.PositiveInfinity} ' crashes with nan
                InputArray1 = new[] { -0.33d, 0.0d, 0.333d, double.PositiveInfinity }; // crashes with nan or negative inf
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.sph_bessel_jn_prime(n, x); break; }
                                case " sreal": { res1 = sreal.sph_bessel_jn_prime(n, x); break; }
                                //case " dreal": { res1 = dreal.sph_bessel_jn_prime(n, x); break; }  // cannot convert from int to uint
                                case " ereal": { res1 = ereal.sph_bessel_jn_prime(n, x); break; }
                                case " qreal": { res1 = qreal.sph_bessel_jn_prime(n, x); break; }
                                case " oreal": { res1 = oreal.sph_bessel_jn_prime(n, x); break; }
                                //case " yreal": { res1 = yreal.sph_bessel_jn_prime(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_bessel_jn_prime(n, x); break; }
                                    //case "sflint": { res1 = sflint.sph_bessel_jn_prime(n, x); break; }
                                    //case "dflint": { res1 = dflint.sph_bessel_jn_prime(n, x); break; }
                                    //case "eflint": { res1 = eflint.sph_bessel_jn_prime(n, x); break; }
                                    //case "qflint": { res1 = qflint.sph_bessel_jn_prime(n, x); break; }
                                    //case "oflint": { res1 = oflint.sph_bessel_jn_prime(n, x); break; }
                                    //case "cflint": { res1 = cflint.sph_bessel_jn_prime(n, x); break; }
                                    //case "mflint": { res1 = mflint.sph_bessel_jn_prime(n, x); break; }
                                    //case "iflint": { res1 = iflint.sph_bessel_jn_prime(n, x); break; }
                                    //case "aflint": { res1 = aflint.sph_bessel_jn_prime(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: sph_bessel_jn({1}, {2}): {3}", NumType, n, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_yn_prime"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d, double.PositiveInfinity }; // crashes with nan
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.sph_bessel_yn_prime(n, x); break; }
                                case " sreal": { res1 = sreal.sph_bessel_yn_prime(n, x); break; }
                                //case " dreal": { res1 = dreal.sph_bessel_yn_prime(n, x); break; } // cannot convert from int to uint
                                case " ereal": { res1 = ereal.sph_bessel_yn_prime(n, x); break; }
                                //case " qreal": { res1 = qreal.sph_bessel_yn_prime(n, x); break; } // cannot convert from int to uint //  cannot convert from 'double' to 'FixedPrecNet.Quadruple' 

                                case " oreal": { res1 = oreal.sph_bessel_yn_prime(n, x); break; }
                                //case " yreal": { res1 = yreal.sph_bessel_yn_prime(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_bessel_yn_prime(n, x); break; }
                                    //case "sflint": { res1 = sflint.sph_bessel_yn_prime(n, x); break; }
                                    //case "dflint": { res1 = dflint.sph_bessel_yn_prime(n, x); break; }
                                    //case "eflint": { res1 = eflint.sph_bessel_yn_prime(n, x); break; }
                                    //case "qflint": { res1 = qflint.sph_bessel_yn_prime(n, x); break; }
                                    //case "oflint": { res1 = oflint.sph_bessel_yn_prime(n, x); break; }
                                    //case "cflint": { res1 = cflint.sph_bessel_yn_prime(n, x); break; }
                                    //case "mflint": { res1 = mflint.sph_bessel_yn_prime(n, x); break; }
                                    //case "iflint": { res1 = iflint.sph_bessel_yn_prime(n, x); break; }
                                    //case "aflint": { res1 = aflint.sph_bessel_yn_prime(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: sph_bessel_yn_prime({1}, {2}): {3}", NumType, n, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }






            #endregion




            #region Hankel functions



            #endregion





            #region Airy functions

            // crashes with NaN
            // InputArray = {-4.333, 0.0, 4.333, Double.PositiveInfinity}
            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_ai"))
            {
                InputArray1 = new[] { -10000000.0d, -4.333d, 0.0d, 4.333d, +100.0d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_ai(x1); break; }
                            case " sreal": { res1 = sreal.airy_ai(x1); break; }
                            case " dreal": { res1 = dreal.airy_ai(x1); break; }
                            case " ereal": { res1 = ereal.airy_ai(x1); break; }
                            case " qreal": { res1 = qreal.airy_ai(x1); break; }
                            case " oreal": { res1 = oreal.airy_ai(x1); break; }
                            //case " yreal": { res1 = yreal.airy_ai(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.airy_ai(x1); break; }
                            case "sflint": { res1 = sflint.airy_ai(x1); break; }
                            case "dflint": { res1 = dflint.airy_ai(x1); break; }
                            case "eflint": { res1 = eflint.airy_ai(x1); break; }
                            case "qflint": { res1 = qflint.airy_ai(x1); break; }
                            case "oflint": { res1 = oflint.airy_ai(x1); break; }
                            case "cflint": { res1 = cflint.airy_ai(x1); break; }
                            case "mflint": { res1 = mflint.airy_ai(x1); break; }
                            case "iflint": { res1 = iflint.airy_ai(x1); break; }
                            case "aflint": { res1 = aflint.airy_ai(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: airy_ai({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }

            // crashes with NaN
            // InputArray = {-4.333, 0.0, 4.333, Double.PositiveInfinity}
            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_bi"))
            {
                InputArray1 = new[] { -10000000.0d, -4.333d, 0.0d, 4.333d, +100.0d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_bi(x1); break; }
                            case " sreal": { res1 = sreal.airy_bi(x1); break; }
                            case " dreal": { res1 = dreal.airy_bi(x1); break; }
                            case " ereal": { res1 = ereal.airy_bi(x1); break; }
                            case " qreal": { res1 = qreal.airy_bi(x1); break; }
                            case " oreal": { res1 = oreal.airy_bi(x1); break; }
                            //case " yreal": { res1 = yreal.airy_bi(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.airy_bi(x1); break; }
                            case "sflint": { res1 = sflint.airy_bi(x1); break; }
                            case "dflint": { res1 = dflint.airy_bi(x1); break; }
                            case "eflint": { res1 = eflint.airy_bi(x1); break; }
                            case "qflint": { res1 = qflint.airy_bi(x1); break; }
                            case "oflint": { res1 = oflint.airy_bi(x1); break; }
                            case "cflint": { res1 = cflint.airy_bi(x1); break; }
                            case "mflint": { res1 = mflint.airy_bi(x1); break; }
                            case "iflint": { res1 = iflint.airy_bi(x1); break; }
                            case "aflint": { res1 = aflint.airy_bi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: airy_bi({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }

            // crashes with NaN
            // InputArray = {-4.333, 0.0, 4.333, Double.PositiveInfinity}
            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_ai_prime"))
            {
                InputArray1 = new[] { -10000000.0d, -4.333d, 0.0d, 4.333d, +100.0d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_ai_prime(x1); break; }
                            case " sreal": { res1 = sreal.airy_ai_prime(x1); break; }
                            case " dreal": { res1 = dreal.airy_ai_prime(x1); break; }
                            case " ereal": { res1 = ereal.airy_ai_prime(x1); break; }
                            case " qreal": { res1 = qreal.airy_ai_prime(x1); break; }
                            case " oreal": { res1 = oreal.airy_ai_prime(x1); break; }
                            //case " yreal": { res1 = yreal.airy_ai_prime(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.airy_ai_prime(x1); break; }
                            case "sflint": { res1 = sflint.airy_ai_prime(x1); break; }
                            case "dflint": { res1 = dflint.airy_ai_prime(x1); break; }
                            case "eflint": { res1 = eflint.airy_ai_prime(x1); break; }
                            case "qflint": { res1 = qflint.airy_ai_prime(x1); break; }
                            case "oflint": { res1 = oflint.airy_ai_prime(x1); break; }
                            case "cflint": { res1 = cflint.airy_ai_prime(x1); break; }
                            case "mflint": { res1 = mflint.airy_ai_prime(x1); break; }
                            case "iflint": { res1 = iflint.airy_ai_prime(x1); break; }
                            case "aflint": { res1 = aflint.airy_ai_prime(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: airy_ai_prime({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }

            // crashes with NaN
            // InputArray = {-4.333, 0.0, 4.333, Double.PositiveInfinity}
            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_bi_prime"))
            {
                InputArray1 = new[] { -10000000.0d, -4.333d, 0.0d, 4.333d, +100.0d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_bi_prime(x1); break; }
                            case " sreal": { res1 = sreal.airy_bi_prime(x1); break; }
                            case " dreal": { res1 = dreal.airy_bi_prime(x1); break; }
                            case " ereal": { res1 = ereal.airy_bi_prime(x1); break; }
                            case " qreal": { res1 = qreal.airy_bi_prime(x1); break; }
                            case " oreal": { res1 = oreal.airy_bi_prime(x1); break; }
                            //case " yreal": { res1 = yreal.airy_bi_prime(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.airy_bi_prime(x1); break; }
                            case "sflint": { res1 = sflint.airy_bi_prime(x1); break; }
                            case "dflint": { res1 = dflint.airy_bi_prime(x1); break; }
                            case "eflint": { res1 = eflint.airy_bi_prime(x1); break; }
                            case "qflint": { res1 = qflint.airy_bi_prime(x1); break; }
                            case "oflint": { res1 = oflint.airy_bi_prime(x1); break; }
                            case "cflint": { res1 = cflint.airy_bi_prime(x1); break; }
                            case "mflint": { res1 = mflint.airy_bi_prime(x1); break; }
                            case "iflint": { res1 = iflint.airy_bi_prime(x1); break; }
                            case "aflint": { res1 = aflint.airy_bi_prime(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: airy_bi_prime({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_ai_zero"))
            {
                InputArrayInt1 = new[] { 1, 2, 3, 4, 5 };
                foreach (var m in InputArrayInt1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            //case "math53": { res1 = math53.airy_ai_zero(m); break; }
                            case " sreal": { res1 = sreal.airy_ai_zero(m); break; }
                            case " dreal": { res1 = dreal.airy_ai_zero(m); break; }
                            case " ereal": { res1 = ereal.airy_ai_zero(m); break; }
                            case " qreal": { res1 = qreal.airy_ai_zero(m); break; }
                            case " oreal": { res1 = oreal.airy_ai_zero(m); break; }
                            //case " yreal": { res1 = yreal.airy_ai_zero(m); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.airy_ai_zero(m); break; }
                            //case "sflint": { res1 = sflint.airy_ai_zero(m); break; }  // cannot convert from int to uint
                            //case "dflint": { res1 = dflint.airy_ai_zero(m); break; }
                            //case "eflint": { res1 = eflint.airy_ai_zero(m); break; }
                            //case "qflint": { res1 = qflint.airy_ai_zero(m); break; }
                            //case "oflint": { res1 = oflint.airy_ai_zero(m); break; }
                            //case "cflint": { res1 = cflint.airy_ai_zero(m); break; }
                            //case "mflint": { res1 = mflint.airy_ai_zero(m); break; }
                            //case "iflint": { res1 = iflint.airy_ai_zero(m); break; }
                            //case "aflint": { res1 = aflint.airy_ai_zero(m); break; }
#endif
                        }
                        Console.WriteLine("{0}: airy_ai_zero({1}): {2}", NumType, m, res1);
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_ai_zero"))
            {
                InputArrayInt1 = new[] { 1, 2, 3, 4, 5 };
                foreach (var m in InputArrayInt1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            //case "math53": { res1 = math53.airy_bi_zero(m); break; }
                            case " sreal": { res1 = sreal.airy_bi_zero(m); break; }
                            case " dreal": { res1 = dreal.airy_bi_zero(m); break; }
                            case " ereal": { res1 = ereal.airy_bi_zero(m); break; }
                            case " qreal": { res1 = qreal.airy_bi_zero(m); break; }
                            case " oreal": { res1 = oreal.airy_bi_zero(m); break; }
                            //case " yreal": { res1 = yreal.airy_bi_zero(m); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.airy_bi_zero(m); break; }
                                //case "sflint": { res1 = sflint.airy_bi_zero(m); break; }  // cannot convert from int to uint
                                //case "dflint": { res1 = dflint.airy_bi_zero(m); break; }
                                //case "eflint": { res1 = eflint.airy_bi_zero(m); break; }
                                //case "qflint": { res1 = qflint.airy_bi_zero(m); break; }
                                //case "oflint": { res1 = oflint.airy_bi_zero(m); break; }
                                //case "cflint": { res1 = cflint.airy_bi_zero(m); break; }
                                //case "mflint": { res1 = mflint.airy_bi_zero(m); break; }
                                //case "iflint": { res1 = iflint.airy_bi_zero(m); break; }
                                //case "aflint": { res1 = aflint.airy_bi_zero(m); break; }
#endif
                        }
                        Console.WriteLine("{0}: airy_bi_zero({1}): {2}", NumType, m, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion




            #region Kelvin functions



            #endregion




            #region Synchrotron functions



            #endregion




        }




        public static void DemoChapter1F1(string[] NumTypeArray, string[] FunctionArray)
        {

            double[] InputArray1;
            double[] InputArray2;
            double[] InputArray3;
            // Dim InputArray4 As Double()
            int[] InputArrayInt1;
            // Dim InputArrayInt2 As Integer()


            #region 1F1 Overview


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_1f1"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { -1.5d, 0.0d, 1.5d };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.hyperg_1f1(a, b, x); break; }
                                    case " sreal": { res1 = sreal.hyperg_1f1(a, b, x); break; }
                                    case " dreal": { res1 = dreal.hyperg_1f1(a, b, x); break; }
                                    case " ereal": { res1 = ereal.hyperg_1f1(a, b, x); break; }
                                    case " qreal": { res1 = qreal.hyperg_1f1(a, b, x); break; }
                                    case " oreal": { res1 = oreal.hyperg_1f1(a, b, x); break; }
                                    //case " yreal": { res1 = yreal.hyperg_1f1(a, b, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.hyperg_1f1(a, b, x); break; }
                                    case "sflint": { res1 = sflint.hyperg_1f1(a, b, x); break; }
                                    case "dflint": { res1 = dflint.hyperg_1f1(a, b, x); break; }
                                    case "eflint": { res1 = eflint.hyperg_1f1(a, b, x); break; }
                                    case "qflint": { res1 = qflint.hyperg_1f1(a, b, x); break; }
                                    case "oflint": { res1 = oflint.hyperg_1f1(a, b, x); break; }
                                    case "cflint": { res1 = cflint.hyperg_1f1(a, b, x); break; }
                                    case "mflint": { res1 = mflint.hyperg_1f1(a, b, x); break; }
                                    case "iflint": { res1 = iflint.hyperg_1f1(a, b, x); break; }
                                    case "aflint": { res1 = aflint.hyperg_1f1(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: hyperg_1f1(a={1}, b={2}, x={3}): {4}", NumType, a, b, x, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_1f1r"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { -1.5d, 0.0d, 1.5d };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.hyperg_1f1r(a, b, x); break; }
                                    case " sreal": { res1 = sreal.hyperg_1f1r(a, b, x); break; }
                                    case " dreal": { res1 = dreal.hyperg_1f1r(a, b, x); break; }
                                    case " ereal": { res1 = ereal.hyperg_1f1r(a, b, x); break; }
                                    case " qreal": { res1 = qreal.hyperg_1f1r(a, b, x); break; }
                                    case " oreal": { res1 = oreal.hyperg_1f1r(a, b, x); break; }
                                    //case " yreal": { res1 = yreal.hyperg_1f1r(a, b, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.hyperg_1f1r(a, b, x); break; }
                                    case "sflint": { res1 = sflint.hyperg_1f1r(a, b, x); break; }
                                    case "dflint": { res1 = dflint.hyperg_1f1r(a, b, x); break; }
                                    case "eflint": { res1 = eflint.hyperg_1f1r(a, b, x); break; }
                                    case "qflint": { res1 = qflint.hyperg_1f1r(a, b, x); break; }
                                    case "oflint": { res1 = oflint.hyperg_1f1r(a, b, x); break; }
                                    case "cflint": { res1 = cflint.hyperg_1f1r(a, b, x); break; }
                                    case "mflint": { res1 = mflint.hyperg_1f1r(a, b, x); break; }
                                    case "iflint": { res1 = iflint.hyperg_1f1r(a, b, x); break; }
                                    case "aflint": { res1 = aflint.hyperg_1f1r(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: hyperg_1f1r(a={1}, b={2}, x={3}): {4}", NumType, a, b, x, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log_hyperg_1f1"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { -1.5d, 0.0d, 90000.7d };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    //case "math53": { res1 = math53.log_hyperg_1f1(a, b, x); break; }
                                    case " sreal": { res1 = sreal.log_hyperg_1f1(a, b, x); break; }
                                    case " dreal": { res1 = dreal.log_hyperg_1f1(a, b, x); break; }
                                    case " ereal": { res1 = ereal.log_hyperg_1f1(a, b, x); break; }
                                    case " qreal": { res1 = qreal.log_hyperg_1f1(a, b, x); break; }
                                    case " oreal": { res1 = oreal.log_hyperg_1f1(a, b, x); break; }
                                    //case " yreal": { res1 = yreal.log_hyperg_1f1(a, b, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.log_hyperg_1f1(a, b, x); break; }
                                    //case "sflint": { res1 = sflint.log_hyperg_1f1(a, b, x); break; }
                                    //case "dflint": { res1 = dflint.log_hyperg_1f1(a, b, x); break; }
                                    //case "eflint": { res1 = eflint.log_hyperg_1f1(a, b, x); break; }
                                    //case "qflint": { res1 = qflint.log_hyperg_1f1(a, b, x); break; }
                                    //case "oflint": { res1 = oflint.log_hyperg_1f1(a, b, x); break; }
                                    //case "cflint": { res1 = cflint.log_hyperg_1f1(a, b, x); break; }
                                    //case "mflint": { res1 = mflint.log_hyperg_1f1(a, b, x); break; }
                                    //case "iflint": { res1 = iflint.log_hyperg_1f1(a, b, x); break; }
                                    //case "aflint": { res1 = aflint.log_hyperg_1f1(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: log_hyperg_1f1(a={1}, b={2}, x={3}): {4}", NumType, a, b, x, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("laguerre_l"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.laguerre_l(n, x); break; }
                                case " sreal": { res1 = sreal.laguerre_l(n, x); break; }
                                case " dreal": { res1 = dreal.laguerre_l(n, x); break; }
                                case " ereal": { res1 = ereal.laguerre_l(n, x); break; }
                                case " qreal": { res1 = qreal.laguerre_l(n, x); break; }
                                case " oreal": { res1 = oreal.laguerre_l(n, x); break; }
                                //case " yreal": { res1 = yreal.laguerre_l(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.laguerre_l(n, x); break; }
                                    //case "sflint": { res1 = sflint.laguerre_l(n, x); break; }
                                    //case "dflint": { res1 = dflint.laguerre_l(n, x); break; }
                                    //case "eflint": { res1 = eflint.laguerre_l(n, x); break; }
                                    //case "qflint": { res1 = qflint.laguerre_l(n, x); break; }
                                    //case "oflint": { res1 = oflint.laguerre_l(n, x); break; }
                                    //case "cflint": { res1 = cflint.laguerre_l(n, x); break; }
                                    //case "mflint": { res1 = mflint.laguerre_l(n, x); break; }
                                    //case "iflint": { res1 = iflint.laguerre_l(n, x); break; }
                                    //case "aflint": { res1 = aflint.laguerre_l(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: laguerre_l({1}, {2}): {3}", NumType, n, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hermite_h"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.hermite_h(n, x); break; }
                                case " sreal": { res1 = sreal.hermite_h(n, x); break; }
                                case " dreal": { res1 = dreal.hermite_h(n, x); break; }
                                case " ereal": { res1 = ereal.hermite_h(n, x); break; }
                                case " qreal": { res1 = qreal.hermite_h(n, x); break; }
                                case " oreal": { res1 = oreal.hermite_h(n, x); break; }
                                //case " yreal": { res1 = yreal.hermite_h(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.hermite_h(n, x); break; }
                                case "sflint": { res1 = sflint.hermite_h(n, x); break; }
                                case "dflint": { res1 = dflint.hermite_h(n, x); break; }
                                case "eflint": { res1 = eflint.hermite_h(n, x); break; }
                                case "qflint": { res1 = qflint.hermite_h(n, x); break; }
                                case "oflint": { res1 = oflint.hermite_h(n, x); break; }
                                case "cflint": { res1 = cflint.hermite_h(n, x); break; }
                                case "mflint": { res1 = mflint.hermite_h(n, x); break; }
                                case "iflint": { res1 = iflint.hermite_h(n, x); break; }
                                case "aflint": { res1 = aflint.hermite_h(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: hermite_h({1}, {2}): {3}", NumType, n, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion




            #region Factorials, Gamma and related functions



            #endregion



            #region Incomplete gamma functions



            #endregion




            #region Coulomb, Whittaker and parabolic cylinder function



            #endregion



            #region Error functions and related functions



            #endregion



            #region Exponential integrals and related functions

            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp_integral_ei"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.exp_integral_ei(x1); break; }
                            case " sreal": { res1 = sreal.exp_integral_ei(x1); break; }
                            case " dreal": { res1 = dreal.exp_integral_ei(x1); break; }
                            case " ereal": { res1 = ereal.exp_integral_ei(x1); break; }
                            case " qreal": { res1 = qreal.exp_integral_ei(x1); break; }
                            case " oreal": { res1 = oreal.exp_integral_ei(x1); break; }
                            //case " yreal": { res1 = yreal.exp_integral_ei(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.exp_integral_ei(x1); break; }
                            case "sflint": { res1 = sflint.exp_integral_ei(x1); break; }
                            case "dflint": { res1 = dflint.exp_integral_ei(x1); break; }
                            case "eflint": { res1 = eflint.exp_integral_ei(x1); break; }
                            case "qflint": { res1 = qflint.exp_integral_ei(x1); break; }
                            case "oflint": { res1 = oflint.exp_integral_ei(x1); break; }
                            case "cflint": { res1 = cflint.exp_integral_ei(x1); break; }
                            case "mflint": { res1 = mflint.exp_integral_ei(x1); break; }
                            case "iflint": { res1 = iflint.exp_integral_ei(x1); break; }
                            case "aflint": { res1 = aflint.exp_integral_ei(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: exp_integral_ei({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp_integral_en"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d, double.PositiveInfinity }; // -inf , Nan crashes
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.exp_integral_en(n, x); break; }
                                case " sreal": { res1 = sreal.exp_integral_en(n, x); break; }
                                case " dreal": { res1 = dreal.exp_integral_en(n, x); break; }
                                case " ereal": { res1 = ereal.exp_integral_en(n, x); break; }
                                case " qreal": { res1 = qreal.exp_integral_en(n, x); break; }
                                case " oreal": { res1 = oreal.exp_integral_en(n, x); break; }
                                //case " yreal": { res1 = yreal.exp_integral_en(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.exp_integral_en(n, x); break; }
                                //case "sflint": { res1 = sflint.exp_integral_en(n, x); break; }
                                //case "dflint": { res1 = dflint.exp_integral_en(n, x); break; }
                                //case "eflint": { res1 = eflint.exp_integral_en(n, x); break; }
                                //case "qflint": { res1 = qflint.exp_integral_en(n, x); break; }
                                //case "oflint": { res1 = oflint.exp_integral_en(n, x); break; }
                                //case "cflint": { res1 = cflint.exp_integral_en(n, x); break; }
                                //case "mflint": { res1 = mflint.exp_integral_en(n, x); break; }
                                //case "iflint": { res1 = iflint.exp_integral_en(n, x); break; }
                                //case "aflint": { res1 = aflint.exp_integral_en(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: exp_integral_en({1}, {2}): {3}", NumType, n, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion







        }




        public static void DemoChapterpFq(string[] NumTypeArray, string[] FunctionArray)
        {

            double[] InputArray1;
            double[] InputArray2;
            // Dim InputArray3 As Double()
            // Dim InputArray4 As Double()
            int[] InputArrayInt1;
            int[] InputArrayInt2;



            #region Gauss Hypergeometric Function 2F1



            #endregion




            #region Chebyshev, Gegenbauer and Jacobi polynomials


            if (FunctionArray.Contains("all") | FunctionArray.Contains("chebyshev_t"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
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
                                //case " yreal": { res1 = yreal.chebyshev_t(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.chebyshev_t(n, x); break; }
                                case "sflint": { res1 = sflint.chebyshev_t(n, x); break; }
                                case "dflint": { res1 = dflint.chebyshev_t(n, x); break; }
                                case "eflint": { res1 = eflint.chebyshev_t(n, x); break; }
                                case "qflint": { res1 = qflint.chebyshev_t(n, x); break; }
                                case "oflint": { res1 = oflint.chebyshev_t(n, x); break; }
                                case "cflint": { res1 = cflint.chebyshev_t(n, x); break; }
                                case "mflint": { res1 = mflint.chebyshev_t(n, x); break; }
                                case "iflint": { res1 = iflint.chebyshev_t(n, x); break; }
                                case "aflint": { res1 = aflint.chebyshev_t(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: chebyshev_t({1}, {2}): {3}", NumType, n, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("chebyshev_u"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
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
                                //case " yreal": { res1 = yreal.chebyshev_u(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.chebyshev_u(n, x); break; }
                                case "sflint": { res1 = sflint.chebyshev_u(n, x); break; }
                                case "dflint": { res1 = dflint.chebyshev_u(n, x); break; }
                                case "eflint": { res1 = eflint.chebyshev_u(n, x); break; }
                                case "qflint": { res1 = qflint.chebyshev_u(n, x); break; }
                                case "oflint": { res1 = oflint.chebyshev_u(n, x); break; }
                                case "cflint": { res1 = cflint.chebyshev_u(n, x); break; }
                                case "mflint": { res1 = mflint.chebyshev_u(n, x); break; }
                                case "iflint": { res1 = iflint.chebyshev_u(n, x); break; }
                                case "aflint": { res1 = aflint.chebyshev_u(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: chebyshev_u({1}, {2}): {3}", NumType, n, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_p"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
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
                                //case " yreal": { res1 = yreal.legendre_p(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.legendre_p(n, x); break; }
                                //case "sflint": { res1 = sflint.legendre_p(n, x); break; }
                                //case "dflint": { res1 = dflint.legendre_p(n, x); break; }
                                //case "eflint": { res1 = eflint.legendre_p(n, x); break; }
                                //case "qflint": { res1 = qflint.legendre_p(n, x); break; }
                                //case "oflint": { res1 = oflint.legendre_p(n, x); break; }
                                //case "cflint": { res1 = cflint.legendre_p(n, x); break; }
                                //case "mflint": { res1 = mflint.legendre_p(n, x); break; }
                                //case "iflint": { res1 = iflint.legendre_p(n, x); break; }
                                //case "aflint": { res1 = aflint.legendre_p(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: legendre_p({1}, {2}): {3}", NumType, n, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_q"))
            {
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
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
                                //case " yreal": { res1 = yreal.legendre_q(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.legendre_q(n, x); break; }
                                //case "sflint": { res1 = sflint.legendre_q(n, x); break; }
                                //case "dflint": { res1 = dflint.legendre_q(n, x); break; }
                                //case "eflint": { res1 = eflint.legendre_q(n, x); break; }
                                //case "qflint": { res1 = qflint.legendre_q(n, x); break; }
                                //case "oflint": { res1 = oflint.legendre_q(n, x); break; }
                                //case "cflint": { res1 = cflint.legendre_q(n, x); break; }
                                //case "mflint": { res1 = mflint.legendre_q(n, x); break; }
                                //case "iflint": { res1 = iflint.legendre_q(n, x); break; }
                                //case "aflint": { res1 = aflint.legendre_q(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: legendre_q({1}, {2}): {3}", NumType, n, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("legendre_plm"))
            {
                InputArrayInt1 = new[] { 7, 9, 13 };  // n > 0
                InputArrayInt2 = new[] { 1, 4, 6 };  // m > 0
                InputArray1 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };  // 0.0 < x < 1.0
                foreach (var n in InputArrayInt1)
                {
                    foreach (var m in InputArrayInt2)
                    {
                        foreach (var x in InputArray1)
                        {
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
                                    //case " yreal": { res1 = yreal.legendre_plm(n, m, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.legendre_plm(n, m, x); break; }
                                    case "sflint": { res1 = sflint.legendre_plm(n, m, x); break; }
                                    case "dflint": { res1 = dflint.legendre_plm(n, m, x); break; }
                                    case "eflint": { res1 = eflint.legendre_plm(n, m, x); break; }
                                    case "qflint": { res1 = qflint.legendre_plm(n, m, x); break; }
                                    case "oflint": { res1 = oflint.legendre_plm(n, m, x); break; }
                                    case "cflint": { res1 = cflint.legendre_plm(n, m, x); break; }
                                    case "mflint": { res1 = mflint.legendre_plm(n, m, x); break; }
                                    case "iflint": { res1 = iflint.legendre_plm(n, m, x); break; }
                                    case "aflint": { res1 = aflint.legendre_plm(n, m, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: legendre_plm(n={1}, m={2}, x={3}): {4}", NumType, n, m, x, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("laguerre_ass"))
            {
                InputArrayInt1 = new[] { 7, 9, 13 };  // n > 0
                InputArrayInt2 = new[] { 1, 4, 6 };  // m > 0
                InputArray1 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };  // 0.0 < x < 1.0
                foreach (var n in InputArrayInt1)
                {
                    foreach (var m in InputArrayInt2)
                    {
                        foreach (var x in InputArray1)
                        {
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.laguerre_ass(n, m, x); break; }
                                    case " sreal": { res1 = sreal.laguerre_ass(n, m, x); break; }
                                    case " dreal": { res1 = dreal.laguerre_ass(n, m, x); break; }
                                    case " ereal": { res1 = ereal.laguerre_ass(n, m, x); break; }
                                    case " qreal": { res1 = qreal.laguerre_ass(n, m, x); break; }
                                    case " oreal": { res1 = oreal.laguerre_ass(n, m, x); break; }
                                    //case " yreal": { res1 = yreal.laguerre_ass(n, m, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.laguerre_ass(n, m, x); break; }
                                    //case "sflint": { res1 = sflint.laguerre_ass(n, m, x); break; }
                                    //case "dflint": { res1 = dflint.laguerre_ass(n, m, x); break; }
                                    //case "eflint": { res1 = eflint.laguerre_ass(n, m, x); break; }
                                    //case "qflint": { res1 = qflint.laguerre_ass(n, m, x); break; }
                                    //case "oflint": { res1 = oflint.laguerre_ass(n, m, x); break; }
                                    //case "cflint": { res1 = cflint.laguerre_ass(n, m, x); break; }
                                    //case "mflint": { res1 = mflint.laguerre_ass(n, m, x); break; }
                                    //case "iflint": { res1 = iflint.laguerre_ass(n, m, x); break; }
                                    //case "aflint": { res1 = aflint.laguerre_ass(n, m, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: laguerre_ass(n={1}, m={2}, x={3}): {4}", NumType, n, m, x, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("spherical_harmonic_r"))
            {
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
                                foreach (var NumType in NumTypeArray)
                                {
                                    object res1 = "Not done";
                                    switch (NumType ?? "")
                                    {
                                        //case "math53": { res1 = math53.spherical_harmonic_r(n, m, theta, phi); break; }
                                        case " sreal": { res1 = sreal.spherical_harmonic_r(n, m, theta, phi); break; }
                                        case " dreal": { res1 = dreal.spherical_harmonic_r(n, m, theta, phi); break; }
                                        case " ereal": { res1 = ereal.spherical_harmonic_r(n, m, theta, phi); break; }
                                        case " qreal": { res1 = qreal.spherical_harmonic_r(n, m, theta, phi); break; }
                                        case " oreal": { res1 = oreal.spherical_harmonic_r(n, m, theta, phi); break; }
                                        //case " yreal": { res1 = yreal.spherical_harmonic_r(n, m, theta, phi); break; }
#if HasArbPrecNet
                                        case " mreal": { res1 = mreal.spherical_harmonic_r(n, m, theta, phi); break; }
                                        //case "sflint": { res1 = sflint.spherical_harmonic_r(n, m, theta, phi); break; }
                                        //case "dflint": { res1 = dflint.spherical_harmonic_r(n, m, theta, phi); break; }
                                        //case "eflint": { res1 = eflint.spherical_harmonic_r(n, m, theta, phi); break; }
                                        //case "qflint": { res1 = qflint.spherical_harmonic_r(n, m, theta, phi); break; }
                                        //case "oflint": { res1 = oflint.spherical_harmonic_r(n, m, theta, phi); break; }
                                        //case "cflint": { res1 = cflint.spherical_harmonic_r(n, m, theta, phi); break; }
                                        //case "mflint": { res1 = mflint.spherical_harmonic_r(n, m, theta, phi); break; }
                                        //case "iflint": { res1 = iflint.spherical_harmonic_r(n, m, theta, phi); break; }
                                        //case "aflint": { res1 = aflint.spherical_harmonic_r(n, m, theta, phi); break; }
#endif
                                    }
                                    Console.WriteLine("{0}: spherical_harmonic_r(n={1}, m={2}, theta={3}, phi={4}): {5}", NumType, n, m, theta, phi, res1);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("spherical_harmonic_i"))
            {
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
                                foreach (var NumType in NumTypeArray)
                                {
                                    object res1 = "Not done";
                                    switch (NumType ?? "")
                                    {
                                        //case "math53": { res1 = math53.spherical_harmonic_i(n, m, theta, phi); break; }
                                        case " sreal": { res1 = sreal.spherical_harmonic_i(n, m, theta, phi); break; }
                                        case " dreal": { res1 = dreal.spherical_harmonic_i(n, m, theta, phi); break; }
                                        case " ereal": { res1 = ereal.spherical_harmonic_i(n, m, theta, phi); break; }
                                        case " qreal": { res1 = qreal.spherical_harmonic_i(n, m, theta, phi); break; }
                                        case " oreal": { res1 = oreal.spherical_harmonic_i(n, m, theta, phi); break; }
                                        //case " yreal": { res1 = yreal.spherical_harmonic_i(n, m, theta, phi); break; }
#if HasArbPrecNet
                                        case " mreal": { res1 = mreal.spherical_harmonic_i(n, m, theta, phi); break; }
                                        //case "sflint": { res1 = sflint.spherical_harmonic_i(n, m, theta, phi); break; }
                                        //case "dflint": { res1 = dflint.spherical_harmonic_i(n, m, theta, phi); break; }
                                        //case "eflint": { res1 = eflint.spherical_harmonic_i(n, m, theta, phi); break; }
                                        //case "qflint": { res1 = qflint.spherical_harmonic_i(n, m, theta, phi); break; }
                                        //case "oflint": { res1 = oflint.spherical_harmonic_i(n, m, theta, phi); break; }
                                        //case "cflint": { res1 = cflint.spherical_harmonic_i(n, m, theta, phi); break; }
                                        //case "mflint": { res1 = mflint.spherical_harmonic_i(n, m, theta, phi); break; }
                                        //case "iflint": { res1 = iflint.spherical_harmonic_i(n, m, theta, phi); break; }
                                        //case "aflint": { res1 = aflint.spherical_harmonic_i(n, m, theta, phi); break; }
#endif
                                    }
                                    Console.WriteLine("{0}: spherical_harmonic_i(n={1}, m={2}, theta={3}, phi={4}): {5}", NumType, n, m, theta, phi, res1);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
            }





            #endregion




            #region Legendre polynomials and related



            #endregion




            #region General incomplete beta function



            #endregion




            #region Gauss Hypergeometric Function 1F2



            #endregion




            #region Scorer functions



            #endregion




            #region Struve functions



            #endregion





            #region Anger, Weber and Lommel functions



            #endregion




        }








        public static void RunTests_RealSpecialFunctions()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(80);
#endif
            //string[] NTA1 = new[] { "math53", " sreal", " dreal", " ereal", " qreal", " oreal", " yreal", " zreal", " creal" };
            string[] NTA1 = new[] { "math53", " sreal", " dreal", " ereal", " qreal", " oreal" };
            //string[] NTA2 = new[] { " mreal", "sflint", "dflint", "eflint", "qflint", "oflint", "cflint", "mflint", "aflint" };
            string[] NTA2 = new[] { " mreal", " creal", "aflint" };
            ////string[] NTA3 = new[] { "mflint", "iflint", "aflint" };

            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();
            //string[] NumTypeArray = NTA1.Concat(NTA2).Concat(NTA3).ToArray();

            //string[] NumTypeArray = new[] { "math53", " sreal", " dreal", " ereal", " qreal", " oreal", " mreal" };



            //string[] FunctionArray = new[] { "all" };
            string[] FunctionArray = new[] { "elliptic_rc" };

            DemoChapterElliptic(NumTypeArray, FunctionArray);
            // DemoChapterLerchPhi(NumTypeArray, FunctionArray);
            // DemoChapter0F1(NumTypeArray, FunctionArray);
            // DemoChapter1F1(NumTypeArray, FunctionArray);
            //DemoChapterpFq(NumTypeArray, FunctionArray);

        }



        public static void Test_RealSpecialFunctions()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTests_RealSpecialFunctions();
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