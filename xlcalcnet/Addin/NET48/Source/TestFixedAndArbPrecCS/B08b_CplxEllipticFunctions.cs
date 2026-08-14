using System;
using System.Diagnostics;
using System.Numerics;
using System.Linq;
using FixedPrecNet;


#if HasArbPrecNet
using ArbPrecNet;
#endif




namespace TestXlCalcNetPrecCS
{

    static partial class Tests
    {



        public static void RunTests_CplxEllipticFunctions()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(70);
#endif
            string[] NTA1 = new[] { "cmath53" };
            string[] NTA2 = new[] { "sflintc", "dflintc", "eflintc", "qflintc", "oflintc", "mflintc", "aflintc" };
            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();

            //string[] FunctionArray = new[] { "all" };
            string[] FunctionArray = new[] { "elliptic_roots_from_tau" };

            DemoChapterCplxElliptic(NumTypeArray, FunctionArray);

        }



        public static void DemoChapterCplxElliptic(string[] NumTypeArray, string[] FunctionArray)
        {

            Complex[] InputArray1;
            Complex[] InputArray2;
            Complex[] InputArray3;
            Complex[] InputArray4;



            #region See cmath53: Conversions of parameters of elliptic functions



            #endregion




            #region Carlson symmetric elliptic integrals


            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_rc"))
            {
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.elliptic_rc(x, y); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.elliptic_rc(x, y); break; }
                                case "dflintc": { res1 = dflintc.elliptic_rc(x, y); break; }
                                case "eflintc": { res1 = eflintc.elliptic_rc(x, y); break; }
                                case "qflintc": { res1 = qflintc.elliptic_rc(x, y); break; }
                                case "oflintc": { res1 = oflintc.elliptic_rc(x, y); break; }
                                case "mflintc": { res1 = mflintc.elliptic_rc(x, y); break; }
                                case "aflintc": { res1 = aflintc.elliptic_rc(x, y); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                InputArray3 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
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
                                    case "cmath53": { res1 = cmath53.elliptic_rf(x, y, z); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.elliptic_rf(x, y, z); break; }
                                    case "dflintc": { res1 = dflintc.elliptic_rf(x, y, z); break; }
                                    case "eflintc": { res1 = eflintc.elliptic_rf(x, y, z); break; }
                                    case "qflintc": { res1 = qflintc.elliptic_rf(x, y, z); break; }
                                    case "oflintc": { res1 = oflintc.elliptic_rf(x, y, z); break; }
                                    case "mflintc": { res1 = mflintc.elliptic_rf(x, y, z); break; }
                                    case "aflintc": { res1 = aflintc.elliptic_rf(x, y, z); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                InputArray3 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
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
                                    case "cmath53": { res1 = cmath53.elliptic_rd(x, y, z); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.elliptic_rd(x, y, z); break; }
                                    case "dflintc": { res1 = dflintc.elliptic_rd(x, y, z); break; }
                                    case "eflintc": { res1 = eflintc.elliptic_rd(x, y, z); break; }
                                    case "qflintc": { res1 = qflintc.elliptic_rd(x, y, z); break; }
                                    case "oflintc": { res1 = oflintc.elliptic_rd(x, y, z); break; }
                                    case "mflintc": { res1 = mflintc.elliptic_rd(x, y, z); break; }
                                    case "aflintc": { res1 = aflintc.elliptic_rd(x, y, z); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                InputArray3 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                InputArray4 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
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
                                        case "cmath53": { res1 = cmath53.elliptic_rj(x, y, z, p); break; }
#if HasArbPrecNet
                                        case "sflintc": { res1 = sflintc.elliptic_rj(x, y, z, p); break; }
                                        case "dflintc": { res1 = dflintc.elliptic_rj(x, y, z, p); break; }
                                        case "eflintc": { res1 = eflintc.elliptic_rj(x, y, z, p); break; }
                                        case "qflintc": { res1 = qflintc.elliptic_rj(x, y, z, p); break; }
                                        case "oflintc": { res1 = oflintc.elliptic_rj(x, y, z, p); break; }
                                        case "mflintc": { res1 = mflintc.elliptic_rj(x, y, z, p); break; }
                                        case "aflintc": { res1 = aflintc.elliptic_rj(x, y, z, p); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                foreach (var k in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.elliptic_k(k); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.elliptic_k(k); break; }
                            case "dflintc": { res1 = dflintc.elliptic_k(k); break; }
                            case "eflintc": { res1 = eflintc.elliptic_k(k); break; }
                            case "qflintc": { res1 = qflintc.elliptic_k(k); break; }
                            case "oflintc": { res1 = oflintc.elliptic_k(k); break; }
                            case "mflintc": { res1 = mflintc.elliptic_k(k); break; }
                            case "aflintc": { res1 = aflintc.elliptic_k(k); break; }
#endif

                        }
                        Console.WriteLine("{0}: elliptic_k({1}): {2}", NumType, k, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_e"))
            {
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                foreach (var k in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.elliptic_e(k); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.elliptic_e(k); break; }
                            case "dflintc": { res1 = dflintc.elliptic_e(k); break; }
                            case "eflintc": { res1 = eflintc.elliptic_e(k); break; }
                            case "qflintc": { res1 = qflintc.elliptic_e(k); break; }
                            case "oflintc": { res1 = oflintc.elliptic_e(k); break; }
                            case "mflintc": { res1 = mflintc.elliptic_e(k); break; }
                            case "aflintc": { res1 = aflintc.elliptic_e(k); break; }
#endif
                        }
                        Console.WriteLine("{0}: elliptic_k({1}): {2}", NumType, k, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_f"))
            {
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                foreach (var phi in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.elliptic_f(phi, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.elliptic_f(phi, k); break; }
                                case "dflintc": { res1 = dflintc.elliptic_f(phi, k); break; }
                                case "eflintc": { res1 = eflintc.elliptic_f(phi, k); break; }
                                case "qflintc": { res1 = qflintc.elliptic_f(phi, k); break; }
                                case "oflintc": { res1 = oflintc.elliptic_f(phi, k); break; }
                                case "mflintc": { res1 = mflintc.elliptic_f(phi, k); break; }
                                case "aflintc": { res1 = aflintc.elliptic_f(phi, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                foreach (var phi in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.elliptic_e_inc(phi, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.elliptic_e_inc(phi, k); break; }
                                case "dflintc": { res1 = dflintc.elliptic_e_inc(phi, k); break; }
                                case "eflintc": { res1 = eflintc.elliptic_e_inc(phi, k); break; }
                                case "qflintc": { res1 = qflintc.elliptic_e_inc(phi, k); break; }
                                case "oflintc": { res1 = oflintc.elliptic_e_inc(phi, k); break; }
                                case "mflintc": { res1 = mflintc.elliptic_e_inc(phi, k); break; }
                                case "aflintc": { res1 = aflintc.elliptic_e_inc(phi, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };
                foreach (var nu in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.elliptic_pi(nu, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.elliptic_pi(nu, k); break; }
                                case "dflintc": { res1 = dflintc.elliptic_pi(nu, k); break; }
                                case "eflintc": { res1 = eflintc.elliptic_pi(nu, k); break; }
                                case "qflintc": { res1 = qflintc.elliptic_pi(nu, k); break; }
                                case "oflintc": { res1 = oflintc.elliptic_pi(nu, k); break; }
                                case "mflintc": { res1 = mflintc.elliptic_pi(nu, k); break; }
                                case "aflintc": { res1 = aflintc.elliptic_pi(nu, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // n
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // phi
                InputArray3 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // k
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
                                    case "cmath53": { res1 = cmath53.elliptic_pi_inc(k, n, phi); break; }
#if HasArbPrecNet
                                    case "sflintc": { res1 = sflintc.elliptic_pi_inc(k, n, phi); break; }
                                    case "dflintc": { res1 = dflintc.elliptic_pi_inc(k, n, phi); break; }
                                    case "eflintc": { res1 = eflintc.elliptic_pi_inc(k, n, phi); break; }
                                    case "qflintc": { res1 = qflintc.elliptic_pi_inc(k, n, phi); break; }
                                    case "oflintc": { res1 = oflintc.elliptic_pi_inc(k, n, phi); break; }
                                    case "mflintc": { res1 = mflintc.elliptic_pi_inc(k, n, phi); break; }
                                    case "aflintc": { res1 = aflintc.elliptic_pi_inc(k, n, phi); break; }
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





            #region Jacobi elliptic functions

            // see cmath53 for general cases, dependent on k real or complex


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_cd"))
            {
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // k
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.jacobi_cd(x, k); break; } 
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_cd(x, k); break; }
                                case "dflintc": { res1 = dflintc.jacobi_cd(x, k); break; }
                                case "eflintc": { res1 = eflintc.jacobi_cd(x, k); break; }
                                case "qflintc": { res1 = qflintc.jacobi_cd(x, k); break; }
                                case "oflintc": { res1 = oflintc.jacobi_cd(x, k); break; }
                                case "mflintc": { res1 = mflintc.jacobi_cd(x, k); break; }
                                case "aflintc": { res1 = aflintc.jacobi_cd(x, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // k
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.jacobi_cn(x, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_cn(x, k); break; }
                                case "dflintc": { res1 = dflintc.jacobi_cn(x, k); break; }
                                case "eflintc": { res1 = eflintc.jacobi_cn(x, k); break; }
                                case "qflintc": { res1 = qflintc.jacobi_cn(x, k); break; }
                                case "oflintc": { res1 = oflintc.jacobi_cn(x, k); break; }
                                case "mflintc": { res1 = mflintc.jacobi_cn(x, k); break; }
                                case "aflintc": { res1 = aflintc.jacobi_cn(x, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // k
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.jacobi_cs(x, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_cs(x, k); break; }
                                case "dflintc": { res1 = dflintc.jacobi_cs(x, k); break; }
                                case "eflintc": { res1 = eflintc.jacobi_cs(x, k); break; }
                                case "qflintc": { res1 = qflintc.jacobi_cs(x, k); break; }
                                case "oflintc": { res1 = oflintc.jacobi_cs(x, k); break; }
                                case "mflintc": { res1 = mflintc.jacobi_cs(x, k); break; }
                                case "aflintc": { res1 = aflintc.jacobi_cs(x, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // k
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.jacobi_dc(x, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_dc(x, k); break; }
                                case "dflintc": { res1 = dflintc.jacobi_dc(x, k); break; }
                                case "eflintc": { res1 = eflintc.jacobi_dc(x, k); break; }
                                case "qflintc": { res1 = qflintc.jacobi_dc(x, k); break; }
                                case "oflintc": { res1 = oflintc.jacobi_dc(x, k); break; }
                                case "mflintc": { res1 = mflintc.jacobi_dc(x, k); break; }
                                case "aflintc": { res1 = aflintc.jacobi_dc(x, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // k
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.jacobi_dn(x, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_dn(x, k); break; }
                                case "dflintc": { res1 = dflintc.jacobi_dn(x, k); break; }
                                case "eflintc": { res1 = eflintc.jacobi_dn(x, k); break; }
                                case "qflintc": { res1 = qflintc.jacobi_dn(x, k); break; }
                                case "oflintc": { res1 = oflintc.jacobi_dn(x, k); break; }
                                case "mflintc": { res1 = mflintc.jacobi_dn(x, k); break; }
                                case "aflintc": { res1 = aflintc.jacobi_dn(x, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // k
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.jacobi_ds(x, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_ds(x, k); break; }
                                case "dflintc": { res1 = dflintc.jacobi_ds(x, k); break; }
                                case "eflintc": { res1 = eflintc.jacobi_ds(x, k); break; }
                                case "qflintc": { res1 = qflintc.jacobi_ds(x, k); break; }
                                case "oflintc": { res1 = oflintc.jacobi_ds(x, k); break; }
                                case "mflintc": { res1 = mflintc.jacobi_ds(x, k); break; }
                                case "aflintc": { res1 = aflintc.jacobi_ds(x, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // k
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.jacobi_nc(x, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_nc(x, k); break; }
                                case "dflintc": { res1 = dflintc.jacobi_nc(x, k); break; }
                                case "eflintc": { res1 = eflintc.jacobi_nc(x, k); break; }
                                case "qflintc": { res1 = qflintc.jacobi_nc(x, k); break; }
                                case "oflintc": { res1 = oflintc.jacobi_nc(x, k); break; }
                                case "mflintc": { res1 = mflintc.jacobi_nc(x, k); break; }
                                case "aflintc": { res1 = aflintc.jacobi_nc(x, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // k
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.jacobi_nd(x, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_nd(x, k); break; }
                                case "dflintc": { res1 = dflintc.jacobi_nd(x, k); break; }
                                case "eflintc": { res1 = eflintc.jacobi_nd(x, k); break; }
                                case "qflintc": { res1 = qflintc.jacobi_nd(x, k); break; }
                                case "oflintc": { res1 = oflintc.jacobi_nd(x, k); break; }
                                case "mflintc": { res1 = mflintc.jacobi_nd(x, k); break; }
                                case "aflintc": { res1 = aflintc.jacobi_nd(x, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // k
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.jacobi_ns(x, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_ns(x, k); break; }
                                case "dflintc": { res1 = dflintc.jacobi_ns(x, k); break; }
                                case "eflintc": { res1 = eflintc.jacobi_ns(x, k); break; }
                                case "qflintc": { res1 = qflintc.jacobi_ns(x, k); break; }
                                case "oflintc": { res1 = oflintc.jacobi_ns(x, k); break; }
                                case "mflintc": { res1 = mflintc.jacobi_ns(x, k); break; }
                                case "aflintc": { res1 = aflintc.jacobi_ns(x, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // k
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.jacobi_sc(x, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_sc(x, k); break; }
                                case "dflintc": { res1 = dflintc.jacobi_sc(x, k); break; }
                                case "eflintc": { res1 = eflintc.jacobi_sc(x, k); break; }
                                case "qflintc": { res1 = qflintc.jacobi_sc(x, k); break; }
                                case "oflintc": { res1 = oflintc.jacobi_sc(x, k); break; }
                                case "mflintc": { res1 = mflintc.jacobi_sc(x, k); break; }
                                case "aflintc": { res1 = aflintc.jacobi_sc(x, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // k
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "cmath53": { res1 = cmath53.jacobi_sd(x, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_sd(x, k); break; }
                                case "dflintc": { res1 = dflintc.jacobi_sd(x, k); break; }
                                case "eflintc": { res1 = eflintc.jacobi_sd(x, k); break; }
                                case "qflintc": { res1 = qflintc.jacobi_sd(x, k); break; }
                                case "oflintc": { res1 = oflintc.jacobi_sd(x, k); break; }
                                case "mflintc": { res1 = mflintc.jacobi_sd(x, k); break; }
                                case "aflintc": { res1 = aflintc.jacobi_sd(x, k); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };  // k
                foreach (var x in InputArray1)
                {
                    foreach (var k in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.jacobi_sn(x, k); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_sn(x, k); break; }
                                case "dflintc": { res1 = dflintc.jacobi_sn(x, k); break; }
                                case "eflintc": { res1 = eflintc.jacobi_sn(x, k); break; }
                                case "qflintc": { res1 = qflintc.jacobi_sn(x, k); break; }
                                case "oflintc": { res1 = oflintc.jacobi_sn(x, k); break; }
                                case "mflintc": { res1 = mflintc.jacobi_sn(x, k); break; }
                                case "aflintc": { res1 = aflintc.jacobi_sn(x, k); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_sn(x={1}, k={2}): {3}", NumType, x, k, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion




            #region Jacobi theta functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("jacobi_theta1"))
            {
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), dcplx.t(0.333d, 0.22) };  // q
                foreach (var x in InputArray1)
                {
                    foreach (var q in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.jacobi_theta1(x, q); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_theta1(x, q); break; }
                                case "dflintc": { res1 = dflintc.jacobi_theta1(x, q); break; }
                                case "eflintc": { res1 = eflintc.jacobi_theta1(x, q); break; }
                                case "qflintc": { res1 = qflintc.jacobi_theta1(x, q); break; }
                                case "oflintc": { res1 = oflintc.jacobi_theta1(x, q); break; }
                                case "mflintc": { res1 = mflintc.jacobi_theta1(x, q); break; }
                                case "aflintc": { res1 = aflintc.jacobi_theta1(x, q); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), dcplx.t(0.333d, 0.22) };  // q
                foreach (var x in InputArray1)
                {
                    foreach (var q in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.jacobi_theta2(x, q); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_theta2(x, q); break; }
                                case "dflintc": { res1 = dflintc.jacobi_theta2(x, q); break; }
                                case "eflintc": { res1 = eflintc.jacobi_theta2(x, q); break; }
                                case "qflintc": { res1 = qflintc.jacobi_theta2(x, q); break; }
                                case "oflintc": { res1 = oflintc.jacobi_theta2(x, q); break; }
                                case "mflintc": { res1 = mflintc.jacobi_theta2(x, q); break; }
                                case "aflintc": { res1 = aflintc.jacobi_theta2(x, q); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), dcplx.t(0.333d, 0.22) };  // q
                foreach (var x in InputArray1)
                {
                    foreach (var q in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.jacobi_theta3(x, q); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_theta3(x, q); break; }
                                case "dflintc": { res1 = dflintc.jacobi_theta3(x, q); break; }
                                case "eflintc": { res1 = eflintc.jacobi_theta3(x, q); break; }
                                case "qflintc": { res1 = qflintc.jacobi_theta3(x, q); break; }
                                case "oflintc": { res1 = oflintc.jacobi_theta3(x, q); break; }
                                case "mflintc": { res1 = mflintc.jacobi_theta3(x, q); break; }
                                case "aflintc": { res1 = aflintc.jacobi_theta3(x, q); break; }
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
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), dcplx.t(0.333d, 0.22) };  // q
                foreach (var x in InputArray1)
                {
                    foreach (var q in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.jacobi_theta4(x, q); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.jacobi_theta4(x, q); break; }
                                case "dflintc": { res1 = dflintc.jacobi_theta4(x, q); break; }
                                case "eflintc": { res1 = eflintc.jacobi_theta4(x, q); break; }
                                case "qflintc": { res1 = qflintc.jacobi_theta4(x, q); break; }
                                case "oflintc": { res1 = oflintc.jacobi_theta4(x, q); break; }
                                case "mflintc": { res1 = mflintc.jacobi_theta4(x, q); break; }
                                case "aflintc": { res1 = aflintc.jacobi_theta4(x, q); break; }
#endif
                            }
                            Console.WriteLine("{0}: jacobi_theta4(x={1}, q={2}): {3}", NumType, x, q, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion






            #region  Todo: Conversions of parameters of Weierstrass

            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_invariants_from_roots"))
            {
                InputArray1 = new[] {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), dcplx.t(4.333, 1.0)};   // e1
                InputArray2 = new[] {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), dcplx.t(4.333, 1.0)};  // e2
                foreach (var e1 in InputArray1)
                {
                    foreach (var e2 in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.elliptic_invariants_from_roots(e1, e2); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.elliptic_invariants_from_roots(e1, e2); break; }
                                case "dflintc": { res1 = dflintc.elliptic_invariants_from_roots(e1, e2); break; }
                                case "eflintc": { res1 = eflintc.elliptic_invariants_from_roots(e1, e2); break; }
                                case "qflintc": { res1 = qflintc.elliptic_invariants_from_roots(e1, e2); break; }
                                case "oflintc": { res1 = oflintc.elliptic_invariants_from_roots(e1, e2); break; }
                                case "mflintc": { res1 = mflintc.elliptic_invariants_from_roots(e1, e2); break; }
                                case "aflintc": { res1 = aflintc.elliptic_invariants_from_roots(e1, e2); break; }
#endif
                            }
                            Console.WriteLine("{0}: elliptic_invariants_from_roots(e1={1}, e2={2}): {3}", NumType, e1, e2, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_invariants_from_tau"))
            {
                InputArray1 = new[] {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), dcplx.t(4.333, 1.0)}; //tau
                foreach (var tau in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.elliptic_invariants_from_tau(tau); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.elliptic_invariants_from_tau(tau); break; }
                            case "dflintc": { res1 = dflintc.elliptic_invariants_from_tau(tau); break; }
                            case "eflintc": { res1 = eflintc.elliptic_invariants_from_tau(tau); break; }
                            case "qflintc": { res1 = qflintc.elliptic_invariants_from_tau(tau); break; }
                            case "oflintc": { res1 = oflintc.elliptic_invariants_from_tau(tau); break; }
                            case "mflintc": { res1 = mflintc.elliptic_invariants_from_tau(tau); break; }
                            case "aflintc": { res1 = aflintc.elliptic_invariants_from_tau(tau); break; }
#endif
                        }
                        Console.WriteLine("{0}: elliptic_invariants_from_tau({1}): {2}", NumType, tau, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("elliptic_roots_from_tau"))
            {
                InputArray1 = new[] { dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), dcplx.t(4.333, 1.0) }; //tau
                foreach (var tau in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            //case "cmath53": { res1 = cmath53.elliptic_roots_from_tau(tau); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.elliptic_roots_from_tau(tau); break; }
                            case "dflintc": { res1 = dflintc.elliptic_roots_from_tau(tau); break; }
                            case "eflintc": { res1 = eflintc.elliptic_roots_from_tau(tau); break; }
                            case "qflintc": { res1 = qflintc.elliptic_roots_from_tau(tau); break; }
                            case "oflintc": { res1 = oflintc.elliptic_roots_from_tau(tau); break; }
                            case "mflintc": { res1 = mflintc.elliptic_roots_from_tau(tau); break; }
                            case "aflintc": { res1 = aflintc.elliptic_roots_from_tau(tau); break; }
#endif
                        }
                        Console.WriteLine("{0}: elliptic_roots_from_tau({1}): {2}", NumType, tau, res1);
                    }
                }
                Console.WriteLine();
            }






            #endregion



            #region  Todo: Weierstrass elliptic functions, in terms of lattice roots half-periods omega1, omega2



            #endregion



            #region  Weierstrass elliptic functions, in terms of elliptic period ratio tau


            if (FunctionArray.Contains("all") | FunctionArray.Contains("weierstrass_p_t"))
            {
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), dcplx.t(0.333d, 0.22) };  // tau
                foreach (var x in InputArray1)
                {
                    foreach (var tau in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.weierstrass_p_t(x, tau); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.weierstrass_p_t(x, tau); break; }
                                case "dflintc": { res1 = dflintc.weierstrass_p_t(x, tau); break; }
                                case "eflintc": { res1 = eflintc.weierstrass_p_t(x, tau); break; }
                                case "qflintc": { res1 = qflintc.weierstrass_p_t(x, tau); break; }
                                case "oflintc": { res1 = oflintc.weierstrass_p_t(x, tau); break; }
                                case "mflintc": { res1 = mflintc.weierstrass_p_t(x, tau); break; }
                                case "aflintc": { res1 = aflintc.weierstrass_p_t(x, tau); break; }
#endif
                            }
                            Console.WriteLine("{0}: weierstrass_p_t(x={1}, tau={2}): {3}", NumType, x, tau, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("weierstrass_pprime_t"))
            {
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), dcplx.t(0.333d, 0.22) };  // tau
                foreach (var x in InputArray1)
                {
                    foreach (var tau in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.weierstrass_pprime_t(x, tau); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.weierstrass_pprime_t(x, tau); break; }
                                case "dflintc": { res1 = dflintc.weierstrass_pprime_t(x, tau); break; }
                                case "eflintc": { res1 = eflintc.weierstrass_pprime_t(x, tau); break; }
                                case "qflintc": { res1 = qflintc.weierstrass_pprime_t(x, tau); break; }
                                case "oflintc": { res1 = oflintc.weierstrass_pprime_t(x, tau); break; }
                                case "mflintc": { res1 = mflintc.weierstrass_pprime_t(x, tau); break; }
                                case "aflintc": { res1 = aflintc.weierstrass_pprime_t(x, tau); break; }
#endif
                            }
                            Console.WriteLine("{0}: weierstrass_pprime_t(x={1}, tau={2}): {3}", NumType, x, tau, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            if (FunctionArray.Contains("all") | FunctionArray.Contains("weierstrass_zeta_t"))
            {
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), dcplx.t(0.333d, 0.22) };  // tau
                foreach (var x in InputArray1)
                {
                    foreach (var tau in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.weierstrass_zeta_t(x, tau); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.weierstrass_zeta_t(x, tau); break; }
                                case "dflintc": { res1 = dflintc.weierstrass_zeta_t(x, tau); break; }
                                case "eflintc": { res1 = eflintc.weierstrass_zeta_t(x, tau); break; }
                                case "qflintc": { res1 = qflintc.weierstrass_zeta_t(x, tau); break; }
                                case "oflintc": { res1 = oflintc.weierstrass_zeta_t(x, tau); break; }
                                case "mflintc": { res1 = mflintc.weierstrass_zeta_t(x, tau); break; }
                                case "aflintc": { res1 = aflintc.weierstrass_zeta_t(x, tau); break; }
#endif
                            }
                            Console.WriteLine("{0}: weierstrass_zeta_t(x={1}, tau={2}): {3}", NumType, x, tau, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("weierstrass_sigma_t"))
            {
                InputArray1 = new[] { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), dcplx.t(4.333d, 2) };   // x
                InputArray2 = new[] { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), dcplx.t(0.333d, 0.22) };  // tau
                foreach (var x in InputArray1)
                {
                    foreach (var tau in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.weierstrass_sigma_t(x, tau); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.weierstrass_sigma_t(x, tau); break; }
                                case "dflintc": { res1 = dflintc.weierstrass_sigma_t(x, tau); break; }
                                case "eflintc": { res1 = eflintc.weierstrass_sigma_t(x, tau); break; }
                                case "qflintc": { res1 = qflintc.weierstrass_sigma_t(x, tau); break; }
                                case "oflintc": { res1 = oflintc.weierstrass_sigma_t(x, tau); break; }
                                case "mflintc": { res1 = mflintc.weierstrass_sigma_t(x, tau); break; }
                                case "aflintc": { res1 = aflintc.weierstrass_sigma_t(x, tau); break; }
#endif
                            }
                            Console.WriteLine("{0}: weierstrass_sigma_t(x={1}, tau={2}): {3}", NumType, x, tau, res1);
                        }
                    }
                }
                Console.WriteLine();
            }








            #endregion




            #region  Modular forms and related



            if (FunctionArray.Contains("all") | FunctionArray.Contains("dedekind_eta"))
            {
                InputArray1 = new[] { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), dcplx.t(0.333d, 0.22) };  // tau
                foreach (var tau in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.dedekind_eta(tau); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.dedekind_eta(tau); break; }
                            case "dflintc": { res1 = dflintc.dedekind_eta(tau); break; }
                            case "eflintc": { res1 = eflintc.dedekind_eta(tau); break; }
                            case "qflintc": { res1 = qflintc.dedekind_eta(tau); break; }
                            case "oflintc": { res1 = oflintc.dedekind_eta(tau); break; }
                            case "mflintc": { res1 = mflintc.dedekind_eta(tau); break; }
                            case "aflintc": { res1 = aflintc.dedekind_eta(tau); break; }
#endif
                        }
                        Console.WriteLine("{0}: dedekind_eta(tau={1}): {2}", NumType, tau, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("modular_delta"))
            {
                InputArray1 = new[] { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), dcplx.t(0.333d, 0.22) };  // tau
                foreach (var tau in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.modular_delta(tau); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.modular_delta(tau); break; }
                            case "dflintc": { res1 = dflintc.modular_delta(tau); break; }
                            case "eflintc": { res1 = eflintc.modular_delta(tau); break; }
                            case "qflintc": { res1 = qflintc.modular_delta(tau); break; }
                            case "oflintc": { res1 = oflintc.modular_delta(tau); break; }
                            case "mflintc": { res1 = mflintc.modular_delta(tau); break; }
                            case "aflintc": { res1 = aflintc.modular_delta(tau); break; }
#endif
                        }
                        Console.WriteLine("{0}: modular_delta(tau={1}): {2}", NumType, tau, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("modular_lambda"))
            {
                InputArray1 = new[] { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), dcplx.t(0.333d, 0.22) };  // tau
                foreach (var tau in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.modular_lambda(tau); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.modular_lambda(tau); break; }
                            case "dflintc": { res1 = dflintc.modular_lambda(tau); break; }
                            case "eflintc": { res1 = eflintc.modular_lambda(tau); break; }
                            case "qflintc": { res1 = qflintc.modular_lambda(tau); break; }
                            case "oflintc": { res1 = oflintc.modular_lambda(tau); break; }
                            case "mflintc": { res1 = mflintc.modular_lambda(tau); break; }
                            case "aflintc": { res1 = aflintc.modular_lambda(tau); break; }
#endif
                        }
                        Console.WriteLine("{0}: modular_lambda(tau={1}): {2}", NumType, tau, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("klein_j"))
            {
                InputArray1 = new[] { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), dcplx.t(0.333d, 0.22) };  // tau
                foreach (var tau in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.klein_j(tau); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.klein_j(tau); break; }
                            case "dflintc": { res1 = dflintc.klein_j(tau); break; }
                            case "eflintc": { res1 = eflintc.klein_j(tau); break; }
                            case "qflintc": { res1 = qflintc.klein_j(tau); break; }
                            case "oflintc": { res1 = oflintc.klein_j(tau); break; }
                            case "mflintc": { res1 = mflintc.klein_j(tau); break; }
                            case "aflintc": { res1 = aflintc.klein_j(tau); break; }
#endif
                        }
                        Console.WriteLine("{0}: klein_j(tau={1}): {2}", NumType, tau, res1);
                    }
                }
                Console.WriteLine();
            }






            #endregion



        }




        public static void CplxEllipticFunctions()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTests_CplxEllipticFunctions();
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