using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using FixedPrecNet;


#if HasArbPrecNet
using ArbPrecNet;
#endif


namespace TestXlCalcNetPrecCS
{

    static partial class Tests
    {


        public static void RunTestsBoostFuncCplx()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(70);
#endif

            string[] NTA1 = new[] { "cmath53", "  scplx", "  dcplx", "  ecplx", "  qcplx", "  ocplx" };
            string[] NTA2 = new[] { "  mcplx", "sflintc", "dflintc", "eflintc", "qflintc", "oflintc", "mflintc", "aflintc" };
            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();
            //string[] NumTypeArray = { "cmath53", "  ecplx" };

            //string[] FunctionArray = { "all" };
            string[] FunctionArray = new[] { "binomial" };

            DemoChapterElementaryCplx(NumTypeArray, FunctionArray);

        }





        public static void DemoChapterElementaryCplx(string[] NumTypeArray, string[] FunctionArray)
        {

            Complex[] InputArray1C;
            Complex[] InputArray1;
            Complex[] InputArray2;
            int[] InputArrayInt1;



            #region Complex components



            if (FunctionArray.Contains("all") | FunctionArray.Contains("abs"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2)};
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.abs(x1); break; }
                            case "  scplx": { res1 = scplx.abs(x1); break; }
                            case "  dcplx": { res1 = dcplx.abs(x1); break; }
                            case "  ecplx": { res1 = ecplx.abs(x1); break; }
                            case "  qcplx": { res1 = qcplx.abs(x1); break; }
                            case "  ocplx": { res1 = ocplx.abs(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.abs(x1); break; }
                            case "sflintc": { res1 = sflintc.abs(x1); break; }
                            case "dflintc": { res1 = dflintc.abs(x1); break; }
                            case "eflintc": { res1 = eflintc.abs(x1); break; }
                            case "qflintc": { res1 = qflintc.abs(x1); break; }
                            case "oflintc": { res1 = oflintc.abs(x1); break; }
                            case "mflintc": { res1 = mflintc.abs(x1); break; }
                            case "aflintc": { res1 = aflintc.abs(x1); break; }
#endif

                        }
                        Console.WriteLine("{0}: abs({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("fabs"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.fabs(x1); break; }
                            case "  scplx": { res1 = scplx.fabs(x1); break; }
                            case "  dcplx": { res1 = dcplx.fabs(x1); break; }
                            case "  ecplx": { res1 = ecplx.fabs(x1); break; }
                            case "  qcplx": { res1 = qcplx.fabs(x1); break; }
                            case "  ocplx": { res1 = ocplx.fabs(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.fabs(x1); break; }
                            case "sflintc": { res1 = sflintc.fabs(x1); break; }
                            case "dflintc": { res1 = dflintc.fabs(x1); break; }
                            case "eflintc": { res1 = eflintc.fabs(x1); break; }
                            case "qflintc": { res1 = qflintc.fabs(x1); break; }
                            case "oflintc": { res1 = oflintc.fabs(x1); break; }
                            case "mflintc": { res1 = mflintc.fabs(x1); break; }
                            case "aflintc": { res1 = aflintc.fabs(x1); break; }
#endif

                        }
                        Console.WriteLine("{0}: abs({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sign"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.sign(x1); break; }
                            case "  scplx": { res1 = scplx.sign(x1); break; }
                            case "  dcplx": { res1 = dcplx.sign(x1); break; }
                            case "  ecplx": { res1 = ecplx.sign(x1); break; }
                            case "  qcplx": { res1 = qcplx.sign(x1); break; }
                            case "  ocplx": { res1 = ocplx.sign(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.sign(x1); break; }
                            case "sflintc": { res1 = sflintc.sign(x1); break; }
                            case "dflintc": { res1 = dflintc.sign(x1); break; }
                            case "eflintc": { res1 = eflintc.sign(x1); break; }
                            case "qflintc": { res1 = qflintc.sign(x1); break; }
                            case "oflintc": { res1 = oflintc.sign(x1); break; }
                            case "mflintc": { res1 = mflintc.sign(x1); break; }
                            case "aflintc": { res1 = aflintc.sign(x1); break; }
#endif

                        }
                        Console.WriteLine("{0}: sign({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("phase"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.phase(x1); break; }
                            case "  scplx": { res1 = scplx.phase(x1); break; }
                            case "  dcplx": { res1 = dcplx.phase(x1); break; }
                            case "  ecplx": { res1 = ecplx.phase(x1); break; }
                            case "  qcplx": { res1 = qcplx.phase(x1); break; }
                            case "  ocplx": { res1 = ocplx.phase(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.phase(x1); break; }
                            case "sflintc": { res1 = sflintc.phase(x1); break; }
                            case "dflintc": { res1 = dflintc.phase(x1); break; }
                            case "eflintc": { res1 = eflintc.phase(x1); break; }
                            case "qflintc": { res1 = qflintc.phase(x1); break; }
                            case "oflintc": { res1 = oflintc.phase(x1); break; }
                            case "mflintc": { res1 = mflintc.phase(x1); break; }
                            case "aflintc": { res1 = aflintc.phase(x1); break; }
#endif

                        }
                        Console.WriteLine("{0}: phase({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("real"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.real(x1); break; }
                            case "  scplx": { res1 = scplx.real(x1); break; }
                            case "  dcplx": { res1 = dcplx.real(x1); break; }
                            case "  ecplx": { res1 = ecplx.real(x1); break; }
                            case "  qcplx": { res1 = qcplx.real(x1); break; }
                            case "  ocplx": { res1 = ocplx.real(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.real(x1); break; }
                            case "sflintc": { res1 = sflintc.real(x1); break; }
                            case "dflintc": { res1 = dflintc.real(x1); break; }
                            case "eflintc": { res1 = eflintc.real(x1); break; }
                            case "qflintc": { res1 = qflintc.real(x1); break; }
                            case "oflintc": { res1 = oflintc.real(x1); break; }
                            case "mflintc": { res1 = mflintc.real(x1); break; }
                            case "aflintc": { res1 = aflintc.real(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: real({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("imag"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.imag(x1); break; }
                            case "  scplx": { res1 = scplx.imag(x1); break; }
                            case "  dcplx": { res1 = dcplx.imag(x1); break; }
                            case "  ecplx": { res1 = ecplx.imag(x1); break; }
                            case "  qcplx": { res1 = qcplx.imag(x1); break; }
                            case "  ocplx": { res1 = ocplx.imag(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.imag(x1); break; }
                            case "sflintc": { res1 = sflintc.imag(x1); break; }
                            case "dflintc": { res1 = dflintc.imag(x1); break; }
                            case "eflintc": { res1 = eflintc.imag(x1); break; }
                            case "qflintc": { res1 = qflintc.imag(x1); break; }
                            case "oflintc": { res1 = oflintc.imag(x1); break; }
                            case "mflintc": { res1 = mflintc.imag(x1); break; }
                            case "aflintc": { res1 = aflintc.imag(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: phase({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("conj"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.conj(x1); break; }
                            case "  scplx": { res1 = scplx.conj(x1); break; }
                            case "  dcplx": { res1 = dcplx.conj(x1); break; }
                            case "  ecplx": { res1 = ecplx.conj(x1); break; }
                            case "  qcplx": { res1 = qcplx.conj(x1); break; }
                            case "  ocplx": { res1 = ocplx.conj(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.conj(x1); break; }
                            case "sflintc": { res1 = sflintc.conj(x1); break; }
                            case "dflintc": { res1 = dflintc.conj(x1); break; }
                            case "eflintc": { res1 = eflintc.conj(x1); break; }
                            case "qflintc": { res1 = qflintc.conj(x1); break; }
                            case "oflintc": { res1 = oflintc.conj(x1); break; }
                            case "mflintc": { res1 = mflintc.conj(x1); break; }
                            case "aflintc": { res1 = aflintc.conj(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: conj({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }






            #endregion



            #region Roots and quadratic, cubic, and quartic



            if (FunctionArray.Contains("all") | FunctionArray.Contains("sqrt"))
            {
                // InputArray1 = {-4.333, 0.0, 4.333}
                InputArray1C = new[] { dcplx.t(-4.333d, 0.0d), dcplx.t(0.0d, 0.0d), dcplx.t(4.333d, 0.0d) };
                foreach (var x1 in InputArray1C)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.sqrt(x1); break; }
                            case "  scplx": { res1 = scplx.sqrt(x1); break; }
                            case "  dcplx": { res1 = dcplx.sqrt(x1); break; }
                            case "  ecplx": { res1 = ecplx.sqrt(x1); break; }
                            case "  qcplx": { res1 = qcplx.sqrt(x1); break; }
                            case "  ocplx": { res1 = ocplx.sqrt(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.sqrt(x1); break; }
                            case "sflintc": { res1 = sflintc.sqrt(x1); break; }
                            case "dflintc": { res1 = dflintc.sqrt(x1); break; }
                            case "eflintc": { res1 = eflintc.sqrt(x1); break; }
                            case "qflintc": { res1 = qflintc.sqrt(x1); break; }
                            case "oflintc": { res1 = oflintc.sqrt(x1); break; }
                            case "mflintc": { res1 = mflintc.sqrt(x1); break; }
                            case "aflintc": { res1 = aflintc.sqrt(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sqrt({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sqrt1pm1"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.sqrt1pm1(x1); break; }
                            case "  scplx": { res1 = scplx.sqrt1pm1(x1); break; }
                            case "  dcplx": { res1 = dcplx.sqrt1pm1(x1); break; }
                            case "  ecplx": { res1 = ecplx.sqrt1pm1(x1); break; }
                            case "  qcplx": { res1 = qcplx.sqrt1pm1(x1); break; }
                            case "  ocplx": { res1 = ocplx.sqrt1pm1(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.sqrt1pm1(x1); break; }
                            case "sflintc": { res1 = sflintc.sqrt1pm1(x1); break; }
                            case "dflintc": { res1 = dflintc.sqrt1pm1(x1); break; }
                            case "eflintc": { res1 = eflintc.sqrt1pm1(x1); break; }
                            case "qflintc": { res1 = qflintc.sqrt1pm1(x1); break; }
                            case "oflintc": { res1 = oflintc.sqrt1pm1(x1); break; }
                            case "mflintc": { res1 = mflintc.sqrt1pm1(x1); break; }
                            case "aflintc": { res1 = aflintc.sqrt1pm1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sqrt1pm1({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("rsqrt"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.rsqrt(x1); break; }
                            case "  scplx": { res1 = scplx.rsqrt(x1); break; }
                            case "  dcplx": { res1 = dcplx.rsqrt(x1); break; }
                            case "  ecplx": { res1 = ecplx.rsqrt(x1); break; }
                            case "  qcplx": { res1 = qcplx.rsqrt(x1); break; }
                            case "  ocplx": { res1 = ocplx.rsqrt(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.rsqrt(x1); break; }
                            case "sflintc": { res1 = sflintc.rsqrt(x1); break; }
                            case "dflintc": { res1 = dflintc.rsqrt(x1); break; }
                            case "eflintc": { res1 = eflintc.rsqrt(x1); break; }
                            case "qflintc": { res1 = qflintc.rsqrt(x1); break; }
                            case "oflintc": { res1 = oflintc.rsqrt(x1); break; }
                            case "mflintc": { res1 = mflintc.rsqrt(x1); break; }
                            case "aflintc": { res1 = aflintc.rsqrt(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: rsqrt({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cbrt"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.cbrt(x1); break; }
                            case "  scplx": { res1 = scplx.cbrt(x1); break; }
                            case "  dcplx": { res1 = dcplx.cbrt(x1); break; }
                            case "  ecplx": { res1 = ecplx.cbrt(x1); break; }
                            case "  qcplx": { res1 = qcplx.cbrt(x1); break; }
                            case "  ocplx": { res1 = ocplx.cbrt(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.cbrt(x1); break; }
                            case "sflintc": { res1 = sflintc.cbrt(x1); break; }
                            case "dflintc": { res1 = dflintc.cbrt(x1); break; }
                            case "eflintc": { res1 = eflintc.cbrt(x1); break; }
                            case "qflintc": { res1 = qflintc.cbrt(x1); break; }
                            case "oflintc": { res1 = oflintc.cbrt(x1); break; }
                            case "mflintc": { res1 = mflintc.cbrt(x1); break; }
                            case "aflintc": { res1 = aflintc.cbrt(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cbrt({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("root_si"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                foreach (var x in InputArray1)
                {
                    foreach (var n in InputArrayInt1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.root_si(x, n); break; }
                                case "  scplx": { res1 = scplx.root_si(x, n); break; }
                                case "  dcplx": { res1 = dcplx.root_si(x, n); break; }
                                case "  ecplx": { res1 = ecplx.root_si(x, n); break; }
                                case "  qcplx": { res1 = qcplx.root_si(x, n); break; }
                                case "  ocplx": { res1 = ocplx.root_si(x, n); break; }
#if HasArbPrecNet
                                case "  mcplx": { res1 = mcplx.root_si(x, n); break; }
                                case "sflintc": { res1 = sflintc.root_si(x, n); break; }
                                case "dflintc": { res1 = dflintc.root_si(x, n); break; }
                                case "eflintc": { res1 = eflintc.root_si(x, n); break; }
                                case "qflintc": { res1 = qflintc.root_si(x, n); break; }
                                case "oflintc": { res1 = oflintc.root_si(x, n); break; }
                                case "mflintc": { res1 = mflintc.root_si(x, n); break; }
                                case "aflintc": { res1 = aflintc.root_si(x, n); break; }
#endif
                            }
                            Console.WriteLine("{0}: root_si({1}, {2}): {3}", NumType, x, n, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion



            #region Exponential and related functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.exp(x1); break; }
                            case "  scplx": { res1 = scplx.exp(x1); break; }
                            case "  dcplx": { res1 = dcplx.exp(x1); break; }
                            case "  ecplx": { res1 = ecplx.exp(x1); break; }
                            case "  qcplx": { res1 = qcplx.exp(x1); break; }
                            case "  ocplx": { res1 = ocplx.exp(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.exp(x1); break; }
                            case "sflintc": { res1 = sflintc.exp(x1); break; }
                            case "dflintc": { res1 = dflintc.exp(x1); break; }
                            case "eflintc": { res1 = eflintc.exp(x1); break; }
                            case "qflintc": { res1 = qflintc.exp(x1); break; }
                            case "oflintc": { res1 = oflintc.exp(x1); break; }
                            case "mflintc": { res1 = mflintc.exp(x1); break; }
                            case "aflintc": { res1 = aflintc.exp(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: exp({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp2"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.exp2(x1); break; }
                            case "  scplx": { res1 = scplx.exp2(x1); break; }
                            case "  dcplx": { res1 = dcplx.exp2(x1); break; }
                            case "  ecplx": { res1 = ecplx.exp2(x1); break; }
                            case "  qcplx": { res1 = qcplx.exp2(x1); break; }
                            case "  ocplx": { res1 = ocplx.exp2(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.exp2(x1); break; }
                            case "sflintc": { res1 = sflintc.exp2(x1); break; }
                            case "dflintc": { res1 = dflintc.exp2(x1); break; }
                            case "eflintc": { res1 = eflintc.exp2(x1); break; }
                            case "qflintc": { res1 = qflintc.exp2(x1); break; }
                            case "oflintc": { res1 = oflintc.exp2(x1); break; }
                            case "mflintc": { res1 = mflintc.exp2(x1); break; }
                            case "aflintc": { res1 = aflintc.exp2(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: exp2({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp10"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.exp10(x1); break; }
                            case "  scplx": { res1 = scplx.exp10(x1); break; }
                            case "  dcplx": { res1 = dcplx.exp10(x1); break; }
                            case "  ecplx": { res1 = ecplx.exp10(x1); break; }
                            case "  qcplx": { res1 = qcplx.exp10(x1); break; }
                            case "  ocplx": { res1 = ocplx.exp10(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.exp10(x1); break; }
                            case "sflintc": { res1 = sflintc.exp10(x1); break; }
                            case "dflintc": { res1 = dflintc.exp10(x1); break; }
                            case "eflintc": { res1 = eflintc.exp10(x1); break; }
                            case "qflintc": { res1 = qflintc.exp10(x1); break; }
                            case "oflintc": { res1 = oflintc.exp10(x1); break; }
                            case "mflintc": { res1 = mflintc.exp10(x1); break; }
                            case "aflintc": { res1 = aflintc.exp10(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: exp10({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("expm1"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.expm1(x1); break; }
                            case "  scplx": { res1 = scplx.expm1(x1); break; }
                            case "  dcplx": { res1 = dcplx.expm1(x1); break; }
                            case "  ecplx": { res1 = ecplx.expm1(x1); break; }
                            case "  qcplx": { res1 = qcplx.expm1(x1); break; }
                            case "  ocplx": { res1 = ocplx.expm1(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.expm1(x1); break; }
                            case "sflintc": { res1 = sflintc.expm1(x1); break; }
                            case "dflintc": { res1 = dflintc.expm1(x1); break; }
                            case "eflintc": { res1 = eflintc.expm1(x1); break; }
                            case "qflintc": { res1 = qflintc.expm1(x1); break; }
                            case "oflintc": { res1 = oflintc.expm1(x1); break; }
                            case "mflintc": { res1 = mflintc.expm1(x1); break; }
                            case "aflintc": { res1 = aflintc.expm1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: expm1({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp2m1"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.exp2m1(x1); break; }
                            case "  scplx": { res1 = scplx.exp2m1(x1); break; }
                            case "  dcplx": { res1 = dcplx.exp2m1(x1); break; }
                            case "  ecplx": { res1 = ecplx.exp2m1(x1); break; }
                            case "  qcplx": { res1 = qcplx.exp2m1(x1); break; }
                            case "  ocplx": { res1 = ocplx.exp2m1(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.exp2m1(x1); break; }
                            case "sflintc": { res1 = sflintc.exp2m1(x1); break; }
                            case "dflintc": { res1 = dflintc.exp2m1(x1); break; }
                            case "eflintc": { res1 = eflintc.exp2m1(x1); break; }
                            case "qflintc": { res1 = qflintc.exp2m1(x1); break; }
                            case "oflintc": { res1 = oflintc.exp2m1(x1); break; }
                            case "mflintc": { res1 = mflintc.exp2m1(x1); break; }
                            case "aflintc": { res1 = aflintc.exp2m1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: exp2m1({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp10m1"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.exp10m1(x1); break; }
                            case "  scplx": { res1 = scplx.exp10m1(x1); break; }
                            case "  dcplx": { res1 = dcplx.exp10m1(x1); break; }
                            case "  ecplx": { res1 = ecplx.exp10m1(x1); break; }
                            case "  qcplx": { res1 = qcplx.exp10m1(x1); break; }
                            case "  ocplx": { res1 = ocplx.exp10m1(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.exp10m1(x1); break; }
                            case "sflintc": { res1 = sflintc.exp10m1(x1); break; }
                            case "dflintc": { res1 = dflintc.exp10m1(x1); break; }
                            case "eflintc": { res1 = eflintc.exp10m1(x1); break; }
                            case "qflintc": { res1 = qflintc.exp10m1(x1); break; }
                            case "oflintc": { res1 = oflintc.exp10m1(x1); break; }
                            case "mflintc": { res1 = mflintc.exp10m1(x1); break; }
                            case "aflintc": { res1 = aflintc.exp10m1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: exp10m1({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Logarithms and related functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.log(x1); break; }
                            case "  scplx": { res1 = scplx.log(x1); break; }
                            case "  dcplx": { res1 = dcplx.log(x1); break; }
                            case "  ecplx": { res1 = ecplx.log(x1); break; }
                            case "  qcplx": { res1 = qcplx.log(x1); break; }
                            case "  ocplx": { res1 = ocplx.log(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.log(x1); break; }
                            case "sflintc": { res1 = sflintc.log(x1); break; }
                            case "dflintc": { res1 = dflintc.log(x1); break; }
                            case "eflintc": { res1 = eflintc.log(x1); break; }
                            case "qflintc": { res1 = qflintc.log(x1); break; }
                            case "oflintc": { res1 = oflintc.log(x1); break; }
                            case "mflintc": { res1 = mflintc.log(x1); break; }
                            case "aflintc": { res1 = aflintc.log(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: log({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log2"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.log2(x1); break; }
                            case "  scplx": { res1 = scplx.log2(x1); break; }
                            case "  dcplx": { res1 = dcplx.log2(x1); break; }
                            case "  ecplx": { res1 = ecplx.log2(x1); break; }
                            case "  qcplx": { res1 = qcplx.log2(x1); break; }
                            case "  ocplx": { res1 = ocplx.log2(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.log2(x1); break; }
                            case "sflintc": { res1 = sflintc.log2(x1); break; }
                            case "dflintc": { res1 = dflintc.log2(x1); break; }
                            case "eflintc": { res1 = eflintc.log2(x1); break; }
                            case "qflintc": { res1 = qflintc.log2(x1); break; }
                            case "oflintc": { res1 = oflintc.log2(x1); break; }
                            case "mflintc": { res1 = mflintc.log2(x1); break; }
                            case "aflintc": { res1 = aflintc.log2(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: log2({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log10"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.log10(x1); break; }
                            case "  scplx": { res1 = scplx.log10(x1); break; }
                            case "  dcplx": { res1 = dcplx.log10(x1); break; }
                            case "  ecplx": { res1 = ecplx.log10(x1); break; }
                            case "  qcplx": { res1 = qcplx.log10(x1); break; }
                            case "  ocplx": { res1 = ocplx.log10(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.log10(x1); break; }
                            case "sflintc": { res1 = sflintc.log10(x1); break; }
                            case "dflintc": { res1 = dflintc.log10(x1); break; }
                            case "eflintc": { res1 = eflintc.log10(x1); break; }
                            case "qflintc": { res1 = qflintc.log10(x1); break; }
                            case "oflintc": { res1 = oflintc.log10(x1); break; }
                            case "mflintc": { res1 = mflintc.log10(x1); break; }
                            case "aflintc": { res1 = aflintc.log10(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: log10({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log1p"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.log1p(x1); break; }
                            case "  scplx": { res1 = scplx.log1p(x1); break; }
                            case "  dcplx": { res1 = dcplx.log1p(x1); break; }
                            case "  ecplx": { res1 = ecplx.log1p(x1); break; }
                            case "  qcplx": { res1 = qcplx.log1p(x1); break; }
                            case "  ocplx": { res1 = ocplx.log1p(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.log1p(x1); break; }
                            case "sflintc": { res1 = sflintc.log1p(x1); break; }
                            case "dflintc": { res1 = dflintc.log1p(x1); break; }
                            case "eflintc": { res1 = eflintc.log1p(x1); break; }
                            case "qflintc": { res1 = qflintc.log1p(x1); break; }
                            case "oflintc": { res1 = oflintc.log1p(x1); break; }
                            case "mflintc": { res1 = mflintc.log1p(x1); break; }
                            case "aflintc": { res1 = aflintc.log1p(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: log1p({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log2p1"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.log2p1(x1); break; }
                            case "  scplx": { res1 = scplx.log2p1(x1); break; }
                            case "  dcplx": { res1 = dcplx.log2p1(x1); break; }
                            case "  ecplx": { res1 = ecplx.log2p1(x1); break; }
                            case "  qcplx": { res1 = qcplx.log2p1(x1); break; }
                            case "  ocplx": { res1 = ocplx.log2p1(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.log2p1(x1); break; }
                            case "sflintc": { res1 = sflintc.log2p1(x1); break; }
                            case "dflintc": { res1 = dflintc.log2p1(x1); break; }
                            case "eflintc": { res1 = eflintc.log2p1(x1); break; }
                            case "qflintc": { res1 = qflintc.log2p1(x1); break; }
                            case "oflintc": { res1 = oflintc.log2p1(x1); break; }
                            case "mflintc": { res1 = mflintc.log2p1(x1); break; }
                            case "aflintc": { res1 = aflintc.log2p1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: log2p1({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log10p1"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.log10p1(x1); break; }
                            case "  scplx": { res1 = scplx.log10p1(x1); break; }
                            case "  dcplx": { res1 = dcplx.log10p1(x1); break; }
                            case "  ecplx": { res1 = ecplx.log10p1(x1); break; }
                            case "  qcplx": { res1 = qcplx.log10p1(x1); break; }
                            case "  ocplx": { res1 = ocplx.log10p1(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.log10p1(x1); break; }
                            case "sflintc": { res1 = sflintc.log10p1(x1); break; }
                            case "dflintc": { res1 = dflintc.log10p1(x1); break; }
                            case "eflintc": { res1 = eflintc.log10p1(x1); break; }
                            case "qflintc": { res1 = qflintc.log10p1(x1); break; }
                            case "oflintc": { res1 = oflintc.log10p1(x1); break; }
                            case "mflintc": { res1 = mflintc.log10p1(x1); break; }
                            case "aflintc": { res1 = aflintc.log10p1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: log10p1({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("lambert_wk"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.lambert_wk(x1, 2); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.lambert_wk(x1, 2); break; }
                            case "sflintc": { res1 = sflintc.lambert_wk(x1, 2); break; }
                            case "dflintc": { res1 = dflintc.lambert_wk(x1, 2); break; }
                            case "eflintc": { res1 = eflintc.lambert_wk(x1, 2); break; }
                            case "qflintc": { res1 = qflintc.lambert_wk(x1, 2); break; }
                            case "oflintc": { res1 = oflintc.lambert_wk(x1, 2); break; }
                            case "mflintc": { res1 = mflintc.lambert_wk(x1, 2); break; }
                            case "aflintc": { res1 = aflintc.lambert_wk(x1, 2); break; }
#endif
                        }
                        Console.WriteLine("{0}: lambert_wk({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }







            #endregion




            #region Power functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sqr"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.sqr(x1); break; }
                            case "  scplx": { res1 = scplx.sqr(x1); break; }
                            case "  dcplx": { res1 = dcplx.sqr(x1); break; }
                            case "  ecplx": { res1 = ecplx.sqr(x1); break; }
                            case "  qcplx": { res1 = qcplx.sqr(x1); break; }
                            case "  ocplx": { res1 = ocplx.sqr(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.sqr(x1); break; }
                            case "sflintc": { res1 = sflintc.sqr(x1); break; }
                            case "dflintc": { res1 = dflintc.sqr(x1); break; }
                            case "eflintc": { res1 = eflintc.sqr(x1); break; }
                            case "qflintc": { res1 = qflintc.sqr(x1); break; }
                            case "oflintc": { res1 = oflintc.sqr(x1); break; }
                            case "mflintc": { res1 = mflintc.sqr(x1); break; }
                            case "aflintc": { res1 = aflintc.sqr(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sqr({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cube"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.cube(x1); break; }
                            case "  scplx": { res1 = scplx.cube(x1); break; }
                            case "  dcplx": { res1 = dcplx.cube(x1); break; }
                            case "  ecplx": { res1 = ecplx.cube(x1); break; }
                            case "  qcplx": { res1 = qcplx.cube(x1); break; }
                            case "  ocplx": { res1 = ocplx.cube(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.cube(x1); break; }
                            case "sflintc": { res1 = sflintc.cube(x1); break; }
                            case "dflintc": { res1 = dflintc.cube(x1); break; }
                            case "eflintc": { res1 = eflintc.cube(x1); break; }
                            case "qflintc": { res1 = qflintc.cube(x1); break; }
                            case "oflintc": { res1 = oflintc.cube(x1); break; }
                            case "mflintc": { res1 = mflintc.cube(x1); break; }
                            case "aflintc": { res1 = aflintc.cube(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cube({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }




            if (FunctionArray.Contains("all") | FunctionArray.Contains("hypot"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.hypot(x, y); break; }
                                case "  scplx": { res1 = scplx.hypot(x, y); break; }
                                case "  dcplx": { res1 = dcplx.hypot(x, y); break; }
                                case "  ecplx": { res1 = ecplx.hypot(x, y); break; }
                                case "  qcplx": { res1 = qcplx.hypot(x, y); break; }
                                case "  ocplx": { res1 = ocplx.hypot(x, y); break; }
#if HasArbPrecNet
                                case "  mcplx": { res1 = mcplx.hypot(x, y); break; }
                                case "sflintc": { res1 = sflintc.hypot(x, y); break; }
                                case "dflintc": { res1 = dflintc.hypot(x, y); break; }
                                case "eflintc": { res1 = eflintc.hypot(x, y); break; }
                                case "qflintc": { res1 = qflintc.hypot(x, y); break; }
                                case "oflintc": { res1 = oflintc.hypot(x, y); break; }
                                case "mflintc": { res1 = mflintc.hypot(x, y); break; }
                                case "aflintc": { res1 = aflintc.hypot(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: hypot({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pow"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.pow(x, y); break; }
                                case "  scplx": { res1 = scplx.pow(x, y); break; }
                                case "  dcplx": { res1 = dcplx.pow(x, y); break; }
                                case "  ecplx": { res1 = ecplx.pow(x, y); break; }
                                case "  qcplx": { res1 = qcplx.pow(x, y); break; }
                                case "  ocplx": { res1 = ocplx.pow(x, y); break; }
#if HasArbPrecNet
                                case "  mcplx": { res1 = mcplx.pow(x, y); break; }
                                case "sflintc": { res1 = sflintc.pow(x, y); break; }
                                case "dflintc": { res1 = dflintc.pow(x, y); break; }
                                case "eflintc": { res1 = eflintc.pow(x, y); break; }
                                case "qflintc": { res1 = qflintc.pow(x, y); break; }
                                case "oflintc": { res1 = oflintc.pow(x, y); break; }
                                case "mflintc": { res1 = mflintc.pow(x, y); break; }
                                case "aflintc": { res1 = aflintc.pow(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: pow({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("powm1"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.powm1(x, y); break; }
                                case "  scplx": { res1 = scplx.powm1(x, y); break; }
                                case "  dcplx": { res1 = dcplx.powm1(x, y); break; }
                                case "  ecplx": { res1 = ecplx.powm1(x, y); break; }
                                case "  qcplx": { res1 = qcplx.powm1(x, y); break; }
                                case "  ocplx": { res1 = ocplx.powm1(x, y); break; }
#if HasArbPrecNet
                                case "  mcplx": { res1 = mcplx.powm1(x, y); break; }
                                case "sflintc": { res1 = sflintc.powm1(x, y); break; }
                                case "dflintc": { res1 = dflintc.powm1(x, y); break; }
                                case "eflintc": { res1 = eflintc.powm1(x, y); break; }
                                case "qflintc": { res1 = qflintc.powm1(x, y); break; }
                                case "oflintc": { res1 = oflintc.powm1(x, y); break; }
                                case "mflintc": { res1 = mflintc.powm1(x, y); break; }
                                case "aflintc": { res1 = aflintc.powm1(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: powm1({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pow1p"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.pow1p(x, y); break; }
                                case "  scplx": { res1 = scplx.pow1p(x, y); break; }
                                case "  dcplx": { res1 = dcplx.pow1p(x, y); break; }
                                case "  ecplx": { res1 = ecplx.pow1p(x, y); break; }
                                case "  qcplx": { res1 = qcplx.pow1p(x, y); break; }
                                case "  ocplx": { res1 = ocplx.pow1p(x, y); break; }
#if HasArbPrecNet
                                case "  mcplx": { res1 = mcplx.pow1p(x, y); break; }
                                case "sflintc": { res1 = sflintc.pow1p(x, y); break; }
                                case "dflintc": { res1 = dflintc.pow1p(x, y); break; }
                                case "eflintc": { res1 = eflintc.pow1p(x, y); break; }
                                case "qflintc": { res1 = qflintc.pow1p(x, y); break; }
                                case "oflintc": { res1 = oflintc.pow1p(x, y); break; }
                                case "mflintc": { res1 = mflintc.pow1p(x, y); break; }
                                case "aflintc": { res1 = aflintc.pow1p(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: pow1p({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pow1pm1"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                InputArray2 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.pow1pm1(x, y); break; }
                                case "  scplx": { res1 = scplx.pow1pm1(x, y); break; }
                                case "  dcplx": { res1 = dcplx.pow1pm1(x, y); break; }
                                case "  ecplx": { res1 = ecplx.pow1pm1(x, y); break; }
                                case "  qcplx": { res1 = qcplx.pow1pm1(x, y); break; }
                                case "  ocplx": { res1 = ocplx.pow1pm1(x, y); break; }
#if HasArbPrecNet
                                case "  mcplx": { res1 = mcplx.pow1pm1(x, y); break; }
                                case "sflintc": { res1 = sflintc.pow1pm1(x, y); break; }
                                case "dflintc": { res1 = dflintc.pow1pm1(x, y); break; }
                                case "eflintc": { res1 = eflintc.pow1pm1(x, y); break; }
                                case "qflintc": { res1 = qflintc.pow1pm1(x, y); break; }
                                case "oflintc": { res1 = oflintc.pow1pm1(x, y); break; }
                                case "mflintc": { res1 = mflintc.pow1pm1(x, y); break; }
                                case "aflintc": { res1 = aflintc.pow1pm1(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: pow1pm1({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pow_si"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                foreach (var x in InputArray1)
                {
                    foreach (var n in InputArrayInt1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.pow_si(x, n); break; }
                                case "  scplx": { res1 = scplx.pow_si(x, n); break; }
                                case "  dcplx": { res1 = dcplx.pow_si(x, n); break; }
                                case "  ecplx": { res1 = ecplx.pow_si(x, n); break; }
                                case "  qcplx": { res1 = qcplx.pow_si(x, n); break; }
                                case "  ocplx": { res1 = ocplx.pow_si(x, n); break; }
#if HasArbPrecNet
                                case "  mcplx": { res1 = mcplx.pow_si(x, n); break; }
                                case "sflintc": { res1 = sflintc.pow_si(x, n); break; }
                                case "dflintc": { res1 = dflintc.pow_si(x, n); break; }
                                case "eflintc": { res1 = eflintc.pow_si(x, n); break; }
                                case "qflintc": { res1 = qflintc.pow_si(x, n); break; }
                                case "oflintc": { res1 = oflintc.pow_si(x, n); break; }
                                case "mflintc": { res1 = mflintc.pow_si(x, n); break; }
                                case "aflintc": { res1 = aflintc.pow_si(x, n); break; }
#endif
                            }
                            Console.WriteLine("{0}: pow_si({1}, {2}): {3}", NumType, x, n, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("compound_si"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                foreach (var x in InputArray1)
                {
                    foreach (var n in InputArrayInt1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.compound_si(x, n); break; }
                                case "  scplx": { res1 = scplx.compound_si(x, n); break; }
                                case "  dcplx": { res1 = dcplx.compound_si(x, n); break; }
                                case "  ecplx": { res1 = ecplx.compound_si(x, n); break; }
                                case "  qcplx": { res1 = qcplx.compound_si(x, n); break; }
                                case "  ocplx": { res1 = ocplx.compound_si(x, n); break; }
#if HasArbPrecNet
                                case "  mcplx": { res1 = mcplx.compound_si(x, n); break; }
                                case "sflintc": { res1 = sflintc.compound_si(x, n); break; }
                                case "dflintc": { res1 = dflintc.compound_si(x, n); break; }
                                case "eflintc": { res1 = eflintc.compound_si(x, n); break; }
                                case "qflintc": { res1 = qflintc.compound_si(x, n); break; }
                                case "oflintc": { res1 = oflintc.compound_si(x, n); break; }
                                case "mflintc": { res1 = mflintc.compound_si(x, n); break; }
                                case "aflintc": { res1 = aflintc.compound_si(x, n); break; }
#endif
                            }
                            Console.WriteLine("{0}: compound_si({1}, {2}): {3}", NumType, x, n, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion




            #region Trigonometric and related functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sin"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.sin(x1); break; }
                            case "  scplx": { res1 = scplx.sin(x1); break; }
                            case "  dcplx": { res1 = dcplx.sin(x1); break; }
                            case "  ecplx": { res1 = ecplx.sin(x1); break; }
                            case "  qcplx": { res1 = qcplx.sin(x1); break; }
                            case "  ocplx": { res1 = ocplx.sin(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.sin(x1); break; }
                            case "sflintc": { res1 = sflintc.sin(x1); break; }
                            case "dflintc": { res1 = dflintc.sin(x1); break; }
                            case "eflintc": { res1 = eflintc.sin(x1); break; }
                            case "qflintc": { res1 = qflintc.sin(x1); break; }
                            case "oflintc": { res1 = oflintc.sin(x1); break; }
                            case "mflintc": { res1 = mflintc.sin(x1); break; }
                            case "aflintc": { res1 = aflintc.sin(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sin({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cos"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.cos(x1); break; }
                            case "  scplx": { res1 = scplx.cos(x1); break; }
                            case "  dcplx": { res1 = dcplx.cos(x1); break; }
                            case "  ecplx": { res1 = ecplx.cos(x1); break; }
                            case "  qcplx": { res1 = qcplx.cos(x1); break; }
                            case "  ocplx": { res1 = ocplx.cos(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.cos(x1); break; }
                            case "sflintc": { res1 = sflintc.cos(x1); break; }
                            case "dflintc": { res1 = dflintc.cos(x1); break; }
                            case "eflintc": { res1 = eflintc.cos(x1); break; }
                            case "qflintc": { res1 = qflintc.cos(x1); break; }
                            case "oflintc": { res1 = oflintc.cos(x1); break; }
                            case "mflintc": { res1 = mflintc.cos(x1); break; }
                            case "aflintc": { res1 = aflintc.cos(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cos({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("tan"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.tan(x1); break; }
                            case "  scplx": { res1 = scplx.tan(x1); break; }
                            case "  dcplx": { res1 = dcplx.tan(x1); break; }
                            case "  ecplx": { res1 = ecplx.tan(x1); break; }
                            case "  qcplx": { res1 = qcplx.tan(x1); break; }
                            case "  ocplx": { res1 = ocplx.tan(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.tan(x1); break; }
                            case "sflintc": { res1 = sflintc.tan(x1); break; }
                            case "dflintc": { res1 = dflintc.tan(x1); break; }
                            case "eflintc": { res1 = eflintc.tan(x1); break; }
                            case "qflintc": { res1 = qflintc.tan(x1); break; }
                            case "oflintc": { res1 = oflintc.tan(x1); break; }
                            case "mflintc": { res1 = mflintc.tan(x1); break; }
                            case "aflintc": { res1 = aflintc.tan(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: tan({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("csc"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.csc(x1); break; }
                            case "  scplx": { res1 = scplx.csc(x1); break; }
                            case "  dcplx": { res1 = dcplx.csc(x1); break; }
                            case "  ecplx": { res1 = ecplx.csc(x1); break; }
                            case "  qcplx": { res1 = qcplx.csc(x1); break; }
                            case "  ocplx": { res1 = ocplx.csc(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.csc(x1); break; }
                            case "sflintc": { res1 = sflintc.csc(x1); break; }
                            case "dflintc": { res1 = dflintc.csc(x1); break; }
                            case "eflintc": { res1 = eflintc.csc(x1); break; }
                            case "qflintc": { res1 = qflintc.csc(x1); break; }
                            case "oflintc": { res1 = oflintc.csc(x1); break; }
                            case "mflintc": { res1 = mflintc.csc(x1); break; }
                            case "aflintc": { res1 = aflintc.csc(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: csc({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sec"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.sec(x1); break; }
                            case "  scplx": { res1 = scplx.sec(x1); break; }
                            case "  dcplx": { res1 = dcplx.sec(x1); break; }
                            case "  ecplx": { res1 = ecplx.sec(x1); break; }
                            case "  qcplx": { res1 = qcplx.sec(x1); break; }
                            case "  ocplx": { res1 = ocplx.sec(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.sec(x1); break; }
                            case "sflintc": { res1 = sflintc.sec(x1); break; }
                            case "dflintc": { res1 = dflintc.sec(x1); break; }
                            case "eflintc": { res1 = eflintc.sec(x1); break; }
                            case "qflintc": { res1 = qflintc.sec(x1); break; }
                            case "oflintc": { res1 = oflintc.sec(x1); break; }
                            case "mflintc": { res1 = mflintc.sec(x1); break; }
                            case "aflintc": { res1 = aflintc.sec(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sec({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cot"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.cot(x1); break; }
                            case "  scplx": { res1 = scplx.cot(x1); break; }
                            case "  dcplx": { res1 = dcplx.cot(x1); break; }
                            case "  ecplx": { res1 = ecplx.cot(x1); break; }
                            case "  qcplx": { res1 = qcplx.cot(x1); break; }
                            case "  ocplx": { res1 = ocplx.cot(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.cot(x1); break; }
                            case "sflintc": { res1 = sflintc.cot(x1); break; }
                            case "dflintc": { res1 = dflintc.cot(x1); break; }
                            case "eflintc": { res1 = eflintc.cot(x1); break; }
                            case "qflintc": { res1 = qflintc.cot(x1); break; }
                            case "oflintc": { res1 = oflintc.cot(x1); break; }
                            case "mflintc": { res1 = mflintc.cot(x1); break; }
                            case "aflintc": { res1 = aflintc.cot(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cot({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("sinpi"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.sinpi(x1); break; }
                            case "  scplx": { res1 = scplx.sinpi(x1); break; }
                            case "  dcplx": { res1 = dcplx.sinpi(x1); break; }
                            case "  ecplx": { res1 = ecplx.sinpi(x1); break; }
                            case "  qcplx": { res1 = qcplx.sinpi(x1); break; }
                            case "  ocplx": { res1 = ocplx.sinpi(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.sinpi(x1); break; }
                            case "sflintc": { res1 = sflintc.sinpi(x1); break; }
                            case "dflintc": { res1 = dflintc.sinpi(x1); break; }
                            case "eflintc": { res1 = eflintc.sinpi(x1); break; }
                            case "qflintc": { res1 = qflintc.sinpi(x1); break; }
                            case "oflintc": { res1 = oflintc.sinpi(x1); break; }
                            case "mflintc": { res1 = mflintc.sinpi(x1); break; }
                            case "aflintc": { res1 = aflintc.sinpi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sinpi({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("cospi"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.cospi(x1); break; }
                            case "  scplx": { res1 = scplx.cospi(x1); break; }
                            case "  dcplx": { res1 = dcplx.cospi(x1); break; }
                            case "  ecplx": { res1 = ecplx.cospi(x1); break; }
                            case "  qcplx": { res1 = qcplx.cospi(x1); break; }
                            case "  ocplx": { res1 = ocplx.cospi(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.cospi(x1); break; }
                            case "sflintc": { res1 = sflintc.cospi(x1); break; }
                            case "dflintc": { res1 = dflintc.cospi(x1); break; }
                            case "eflintc": { res1 = eflintc.cospi(x1); break; }
                            case "qflintc": { res1 = qflintc.cospi(x1); break; }
                            case "oflintc": { res1 = oflintc.cospi(x1); break; }
                            case "mflintc": { res1 = mflintc.cospi(x1); break; }
                            case "aflintc": { res1 = aflintc.cospi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cospi({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("tanpi"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.tanpi(x1); break; }
                            case "  scplx": { res1 = scplx.tanpi(x1); break; }
                            case "  dcplx": { res1 = dcplx.tanpi(x1); break; }
                            case "  ecplx": { res1 = ecplx.tanpi(x1); break; }
                            case "  qcplx": { res1 = qcplx.tanpi(x1); break; }
                            case "  ocplx": { res1 = ocplx.tanpi(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.tanpi(x1); break; }
                            case "sflintc": { res1 = sflintc.tanpi(x1); break; }
                            case "dflintc": { res1 = dflintc.tanpi(x1); break; }
                            case "eflintc": { res1 = eflintc.tanpi(x1); break; }
                            case "qflintc": { res1 = qflintc.tanpi(x1); break; }
                            case "oflintc": { res1 = oflintc.tanpi(x1); break; }
                            case "mflintc": { res1 = mflintc.tanpi(x1); break; }
                            case "aflintc": { res1 = aflintc.tanpi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: tanpi({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cscpi"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.cscpi(x1); break; }
                            case "  scplx": { res1 = scplx.cscpi(x1); break; }
                            case "  dcplx": { res1 = dcplx.cscpi(x1); break; }
                            case "  ecplx": { res1 = ecplx.cscpi(x1); break; }
                            case "  qcplx": { res1 = qcplx.cscpi(x1); break; }
                            case "  ocplx": { res1 = ocplx.cscpi(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.cscpi(x1); break; }
                            case "sflintc": { res1 = sflintc.cscpi(x1); break; }
                            case "dflintc": { res1 = dflintc.cscpi(x1); break; }
                            case "eflintc": { res1 = eflintc.cscpi(x1); break; }
                            case "qflintc": { res1 = qflintc.cscpi(x1); break; }
                            case "oflintc": { res1 = oflintc.cscpi(x1); break; }
                            case "mflintc": { res1 = mflintc.cscpi(x1); break; }
                            case "aflintc": { res1 = aflintc.cscpi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cscpi({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("secpi"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.secpi(x1); break; }
                            case "  scplx": { res1 = scplx.secpi(x1); break; }
                            case "  dcplx": { res1 = dcplx.secpi(x1); break; }
                            case "  ecplx": { res1 = ecplx.secpi(x1); break; }
                            case "  qcplx": { res1 = qcplx.secpi(x1); break; }
                            case "  ocplx": { res1 = ocplx.secpi(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.secpi(x1); break; }
                            case "sflintc": { res1 = sflintc.secpi(x1); break; }
                            case "dflintc": { res1 = dflintc.secpi(x1); break; }
                            case "eflintc": { res1 = eflintc.secpi(x1); break; }
                            case "qflintc": { res1 = qflintc.secpi(x1); break; }
                            case "oflintc": { res1 = oflintc.secpi(x1); break; }
                            case "mflintc": { res1 = mflintc.secpi(x1); break; }
                            case "aflintc": { res1 = aflintc.secpi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: secpi({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cotpi"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.cotpi(x1); break; }
                            case "  scplx": { res1 = scplx.cotpi(x1); break; }
                            case "  dcplx": { res1 = dcplx.cotpi(x1); break; }
                            case "  ecplx": { res1 = ecplx.cotpi(x1); break; }
                            case "  qcplx": { res1 = qcplx.cotpi(x1); break; }
                            case "  ocplx": { res1 = ocplx.cotpi(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.cotpi(x1); break; }
                            case "sflintc": { res1 = sflintc.cotpi(x1); break; }
                            case "dflintc": { res1 = dflintc.cotpi(x1); break; }
                            case "eflintc": { res1 = eflintc.cotpi(x1); break; }
                            case "qflintc": { res1 = qflintc.cotpi(x1); break; }
                            case "oflintc": { res1 = oflintc.cotpi(x1); break; }
                            case "mflintc": { res1 = mflintc.cotpi(x1); break; }
                            case "aflintc": { res1 = aflintc.cotpi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cotpi({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }





            if (FunctionArray.Contains("all") | FunctionArray.Contains("sincpi"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.sincpi(x1); break; }
                            case "  scplx": { res1 = scplx.sincpi(x1); break; }
                            case "  dcplx": { res1 = dcplx.sincpi(x1); break; }
                            case "  ecplx": { res1 = ecplx.sincpi(x1); break; }
                            case "  qcplx": { res1 = qcplx.sincpi(x1); break; }
                            case "  ocplx": { res1 = ocplx.sincpi(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.sincpi(x1); break; }
                            case "sflintc": { res1 = sflintc.sincpi(x1); break; }
                            case "dflintc": { res1 = dflintc.sincpi(x1); break; }
                            case "eflintc": { res1 = eflintc.sincpi(x1); break; }
                            case "qflintc": { res1 = qflintc.sincpi(x1); break; }
                            case "oflintc": { res1 = oflintc.sincpi(x1); break; }
                            case "mflintc": { res1 = mflintc.sincpi(x1); break; }
                            case "aflintc": { res1 = aflintc.sincpi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sincpi({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            #endregion



            #region Hyperbolic functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sinh"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.sinh(x1); break; }
                            case "  scplx": { res1 = scplx.sinh(x1); break; }
                            case "  dcplx": { res1 = dcplx.sinh(x1); break; }
                            case "  ecplx": { res1 = ecplx.sinh(x1); break; }
                            case "  qcplx": { res1 = qcplx.sinh(x1); break; }
                            case "  ocplx": { res1 = ocplx.sinh(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.sinh(x1); break; }
                            case "sflintc": { res1 = sflintc.sinh(x1); break; }
                            case "dflintc": { res1 = dflintc.sinh(x1); break; }
                            case "eflintc": { res1 = eflintc.sinh(x1); break; }
                            case "qflintc": { res1 = qflintc.sinh(x1); break; }
                            case "oflintc": { res1 = oflintc.sinh(x1); break; }
                            case "mflintc": { res1 = mflintc.sinh(x1); break; }
                            case "aflintc": { res1 = aflintc.sinh(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sinh({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cosh"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.cosh(x1); break; }
                            case "  scplx": { res1 = scplx.cosh(x1); break; }
                            case "  dcplx": { res1 = dcplx.cosh(x1); break; }
                            case "  ecplx": { res1 = ecplx.cosh(x1); break; }
                            case "  qcplx": { res1 = qcplx.cosh(x1); break; }
                            case "  ocplx": { res1 = ocplx.cosh(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.cosh(x1); break; }
                            case "sflintc": { res1 = sflintc.cosh(x1); break; }
                            case "dflintc": { res1 = dflintc.cosh(x1); break; }
                            case "eflintc": { res1 = eflintc.cosh(x1); break; }
                            case "qflintc": { res1 = qflintc.cosh(x1); break; }
                            case "oflintc": { res1 = oflintc.cosh(x1); break; }
                            case "mflintc": { res1 = mflintc.cosh(x1); break; }
                            case "aflintc": { res1 = aflintc.cosh(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cosh({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("tanh"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.tanh(x1); break; }
                            case "  scplx": { res1 = scplx.tanh(x1); break; }
                            case "  dcplx": { res1 = dcplx.tanh(x1); break; }
                            case "  ecplx": { res1 = ecplx.tanh(x1); break; }
                            case "  qcplx": { res1 = qcplx.tanh(x1); break; }
                            case "  ocplx": { res1 = ocplx.tanh(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.tanh(x1); break; }
                            case "sflintc": { res1 = sflintc.tanh(x1); break; }
                            case "dflintc": { res1 = dflintc.tanh(x1); break; }
                            case "eflintc": { res1 = eflintc.tanh(x1); break; }
                            case "qflintc": { res1 = qflintc.tanh(x1); break; }
                            case "oflintc": { res1 = oflintc.tanh(x1); break; }
                            case "mflintc": { res1 = mflintc.tanh(x1); break; }
                            case "aflintc": { res1 = aflintc.tanh(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: tanh({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("csch"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.csch(x1); break; }
                            case "  scplx": { res1 = scplx.csch(x1); break; }
                            case "  dcplx": { res1 = dcplx.csch(x1); break; }
                            case "  ecplx": { res1 = ecplx.csch(x1); break; }
                            case "  qcplx": { res1 = qcplx.csch(x1); break; }
                            case "  ocplx": { res1 = ocplx.csch(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.csch(x1); break; }
                            case "sflintc": { res1 = sflintc.csch(x1); break; }
                            case "dflintc": { res1 = dflintc.csch(x1); break; }
                            case "eflintc": { res1 = eflintc.csch(x1); break; }
                            case "qflintc": { res1 = qflintc.csch(x1); break; }
                            case "oflintc": { res1 = oflintc.csch(x1); break; }
                            case "mflintc": { res1 = mflintc.csch(x1); break; }
                            case "aflintc": { res1 = aflintc.csch(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: csch({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sech"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.sech(x1); break; }
                            case "  scplx": { res1 = scplx.sech(x1); break; }
                            case "  dcplx": { res1 = dcplx.sech(x1); break; }
                            case "  ecplx": { res1 = ecplx.sech(x1); break; }
                            case "  qcplx": { res1 = qcplx.sech(x1); break; }
                            case "  ocplx": { res1 = ocplx.sech(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.sech(x1); break; }
                            case "sflintc": { res1 = sflintc.sech(x1); break; }
                            case "dflintc": { res1 = dflintc.sech(x1); break; }
                            case "eflintc": { res1 = eflintc.sech(x1); break; }
                            case "qflintc": { res1 = qflintc.sech(x1); break; }
                            case "oflintc": { res1 = oflintc.sech(x1); break; }
                            case "mflintc": { res1 = mflintc.sech(x1); break; }
                            case "aflintc": { res1 = aflintc.sech(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sech({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("coth"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.coth(x1); break; }
                            case "  scplx": { res1 = scplx.coth(x1); break; }
                            case "  dcplx": { res1 = dcplx.coth(x1); break; }
                            case "  ecplx": { res1 = ecplx.coth(x1); break; }
                            case "  qcplx": { res1 = qcplx.coth(x1); break; }
                            case "  ocplx": { res1 = ocplx.coth(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.coth(x1); break; }
                            case "sflintc": { res1 = sflintc.coth(x1); break; }
                            case "dflintc": { res1 = dflintc.coth(x1); break; }
                            case "eflintc": { res1 = eflintc.coth(x1); break; }
                            case "qflintc": { res1 = qflintc.coth(x1); break; }
                            case "oflintc": { res1 = oflintc.coth(x1); break; }
                            case "mflintc": { res1 = mflintc.coth(x1); break; }
                            case "aflintc": { res1 = aflintc.coth(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: coth({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }





            #endregion



            #region Inverse trigonometric functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("asin"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.asin(x1); break; }
                            case "  scplx": { res1 = scplx.asin(x1); break; }
                            case "  dcplx": { res1 = dcplx.asin(x1); break; }
                            case "  ecplx": { res1 = ecplx.asin(x1); break; }
                            case "  qcplx": { res1 = qcplx.asin(x1); break; }
                            case "  ocplx": { res1 = ocplx.asin(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.asin(x1); break; }
                            case "sflintc": { res1 = sflintc.asin(x1); break; }
                            case "dflintc": { res1 = dflintc.asin(x1); break; }
                            case "eflintc": { res1 = eflintc.asin(x1); break; }
                            case "qflintc": { res1 = qflintc.asin(x1); break; }
                            case "oflintc": { res1 = oflintc.asin(x1); break; }
                            case "mflintc": { res1 = mflintc.asin(x1); break; }
                            case "aflintc": { res1 = aflintc.asin(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: asin({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("acos"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.acos(x1); break; }
                            case "  scplx": { res1 = scplx.acos(x1); break; }
                            case "  dcplx": { res1 = dcplx.acos(x1); break; }
                            case "  ecplx": { res1 = ecplx.acos(x1); break; }
                            case "  qcplx": { res1 = qcplx.acos(x1); break; }
                            case "  ocplx": { res1 = ocplx.acos(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.acos(x1); break; }
                            case "sflintc": { res1 = sflintc.acos(x1); break; }
                            case "dflintc": { res1 = dflintc.acos(x1); break; }
                            case "eflintc": { res1 = eflintc.acos(x1); break; }
                            case "qflintc": { res1 = qflintc.acos(x1); break; }
                            case "oflintc": { res1 = oflintc.acos(x1); break; }
                            case "mflintc": { res1 = mflintc.acos(x1); break; }
                            case "aflintc": { res1 = aflintc.acos(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: acos({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("atan"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.atan(x1); break; }
                            case "  scplx": { res1 = scplx.atan(x1); break; }
                            case "  dcplx": { res1 = dcplx.atan(x1); break; }
                            case "  ecplx": { res1 = ecplx.atan(x1); break; }
                            case "  qcplx": { res1 = qcplx.atan(x1); break; }
                            case "  ocplx": { res1 = ocplx.atan(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.atan(x1); break; }
                            case "sflintc": { res1 = sflintc.atan(x1); break; }
                            case "dflintc": { res1 = dflintc.atan(x1); break; }
                            case "eflintc": { res1 = eflintc.atan(x1); break; }
                            case "qflintc": { res1 = qflintc.atan(x1); break; }
                            case "oflintc": { res1 = oflintc.atan(x1); break; }
                            case "mflintc": { res1 = mflintc.atan(x1); break; }
                            case "aflintc": { res1 = aflintc.atan(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: atan({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }




            if (FunctionArray.Contains("all") | FunctionArray.Contains("acsc"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.acsc(x1); break; }
                            case "  scplx": { res1 = scplx.acsc(x1); break; }
                            case "  dcplx": { res1 = dcplx.acsc(x1); break; }
                            case "  ecplx": { res1 = ecplx.acsc(x1); break; }
                            case "  qcplx": { res1 = qcplx.acsc(x1); break; }
                            case "  ocplx": { res1 = ocplx.acsc(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.acsc(x1); break; }
                            case "sflintc": { res1 = sflintc.acsc(x1); break; }
                            case "dflintc": { res1 = dflintc.acsc(x1); break; }
                            case "eflintc": { res1 = eflintc.acsc(x1); break; }
                            case "qflintc": { res1 = qflintc.acsc(x1); break; }
                            case "oflintc": { res1 = oflintc.acsc(x1); break; }
                            case "mflintc": { res1 = mflintc.acsc(x1); break; }
                            case "aflintc": { res1 = aflintc.acsc(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: acsc({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("asec"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.asec(x1); break; }
                            case "  scplx": { res1 = scplx.asec(x1); break; }
                            case "  dcplx": { res1 = dcplx.asec(x1); break; }
                            case "  ecplx": { res1 = ecplx.asec(x1); break; }
                            case "  qcplx": { res1 = qcplx.asec(x1); break; }
                            case "  ocplx": { res1 = ocplx.asec(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.asec(x1); break; }
                            case "sflintc": { res1 = sflintc.asec(x1); break; }
                            case "dflintc": { res1 = dflintc.asec(x1); break; }
                            case "eflintc": { res1 = eflintc.asec(x1); break; }
                            case "qflintc": { res1 = qflintc.asec(x1); break; }
                            case "oflintc": { res1 = oflintc.asec(x1); break; }
                            case "mflintc": { res1 = mflintc.asec(x1); break; }
                            case "aflintc": { res1 = aflintc.asec(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: asec({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("acot"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.acot(x1); break; }
                            case "  scplx": { res1 = scplx.acot(x1); break; }
                            case "  dcplx": { res1 = dcplx.acot(x1); break; }
                            case "  ecplx": { res1 = ecplx.acot(x1); break; }
                            case "  qcplx": { res1 = qcplx.acot(x1); break; }
                            case "  ocplx": { res1 = ocplx.acot(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.acot(x1); break; }
                            case "sflintc": { res1 = sflintc.acot(x1); break; }
                            case "dflintc": { res1 = dflintc.acot(x1); break; }
                            case "eflintc": { res1 = eflintc.acot(x1); break; }
                            case "qflintc": { res1 = qflintc.acot(x1); break; }
                            case "oflintc": { res1 = oflintc.acot(x1); break; }
                            case "mflintc": { res1 = mflintc.acot(x1); break; }
                            case "aflintc": { res1 = aflintc.acot(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: acot({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            #endregion



            #region Inverse hyperbolic functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("asinh"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.asinh(x1); break; }
                            case "  scplx": { res1 = scplx.asinh(x1); break; }
                            case "  dcplx": { res1 = dcplx.asinh(x1); break; }
                            case "  ecplx": { res1 = ecplx.asinh(x1); break; }
                            case "  qcplx": { res1 = qcplx.asinh(x1); break; }
                            case "  ocplx": { res1 = ocplx.asinh(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.asinh(x1); break; }
                            case "sflintc": { res1 = sflintc.asinh(x1); break; }
                            case "dflintc": { res1 = dflintc.asinh(x1); break; }
                            case "eflintc": { res1 = eflintc.asinh(x1); break; }
                            case "qflintc": { res1 = qflintc.asinh(x1); break; }
                            case "oflintc": { res1 = oflintc.asinh(x1); break; }
                            case "mflintc": { res1 = mflintc.asinh(x1); break; }
                            case "aflintc": { res1 = aflintc.asinh(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: asinh({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("acosh"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.acosh(x1); break; }
                            case "  scplx": { res1 = scplx.acosh(x1); break; }
                            case "  dcplx": { res1 = dcplx.acosh(x1); break; }
                            case "  ecplx": { res1 = ecplx.acosh(x1); break; }
                            case "  qcplx": { res1 = qcplx.acosh(x1); break; }
                            case "  ocplx": { res1 = ocplx.acosh(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.acosh(x1); break; }
                            case "sflintc": { res1 = sflintc.acosh(x1); break; }
                            case "dflintc": { res1 = dflintc.acosh(x1); break; }
                            case "eflintc": { res1 = eflintc.acosh(x1); break; }
                            case "qflintc": { res1 = qflintc.acosh(x1); break; }
                            case "oflintc": { res1 = oflintc.acosh(x1); break; }
                            case "mflintc": { res1 = mflintc.acosh(x1); break; }
                            case "aflintc": { res1 = aflintc.acosh(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: acosh({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("atanh"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.atanh(x1); break; }
                            case "  scplx": { res1 = scplx.atanh(x1); break; }
                            case "  dcplx": { res1 = dcplx.atanh(x1); break; }
                            case "  ecplx": { res1 = ecplx.atanh(x1); break; }
                            case "  qcplx": { res1 = qcplx.atanh(x1); break; }
                            case "  ocplx": { res1 = ocplx.atanh(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.atanh(x1); break; }
                            case "sflintc": { res1 = sflintc.atanh(x1); break; }
                            case "dflintc": { res1 = dflintc.atanh(x1); break; }
                            case "eflintc": { res1 = eflintc.atanh(x1); break; }
                            case "qflintc": { res1 = qflintc.atanh(x1); break; }
                            case "oflintc": { res1 = oflintc.atanh(x1); break; }
                            case "mflintc": { res1 = mflintc.atanh(x1); break; }
                            case "aflintc": { res1 = aflintc.atanh(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: atanh({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("acsch"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.acsch(x1); break; }
                            case "  scplx": { res1 = scplx.acsch(x1); break; }
                            case "  dcplx": { res1 = dcplx.acsch(x1); break; }
                            case "  ecplx": { res1 = ecplx.acsch(x1); break; }
                            case "  qcplx": { res1 = qcplx.acsch(x1); break; }
                            case "  ocplx": { res1 = ocplx.acsch(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.acsch(x1); break; }
                            case "sflintc": { res1 = sflintc.acsch(x1); break; }
                            case "dflintc": { res1 = dflintc.acsch(x1); break; }
                            case "eflintc": { res1 = eflintc.acsch(x1); break; }
                            case "qflintc": { res1 = qflintc.acsch(x1); break; }
                            case "oflintc": { res1 = oflintc.acsch(x1); break; }
                            case "mflintc": { res1 = mflintc.acsch(x1); break; }
                            case "aflintc": { res1 = aflintc.acsch(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: acsch({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("asech"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.asech(x1); break; }
                            case "  scplx": { res1 = scplx.asech(x1); break; }
                            case "  dcplx": { res1 = dcplx.asech(x1); break; }
                            case "  ecplx": { res1 = ecplx.asech(x1); break; }
                            case "  qcplx": { res1 = qcplx.asech(x1); break; }
                            case "  ocplx": { res1 = ocplx.asech(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.asech(x1); break; }
                            case "sflintc": { res1 = sflintc.asech(x1); break; }
                            case "dflintc": { res1 = dflintc.asech(x1); break; }
                            case "eflintc": { res1 = eflintc.asech(x1); break; }
                            case "qflintc": { res1 = qflintc.asech(x1); break; }
                            case "oflintc": { res1 = oflintc.asech(x1); break; }
                            case "mflintc": { res1 = mflintc.asech(x1); break; }
                            case "aflintc": { res1 = aflintc.asech(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: asech({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("acoth"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), dcplx.t(4.333d, 2) };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.acoth(x1); break; }
                            case "  scplx": { res1 = scplx.acoth(x1); break; }
                            case "  dcplx": { res1 = dcplx.acoth(x1); break; }
                            case "  ecplx": { res1 = ecplx.acoth(x1); break; }
                            case "  qcplx": { res1 = qcplx.acoth(x1); break; }
                            case "  ocplx": { res1 = ocplx.acoth(x1); break; }
#if HasArbPrecNet
                            case "  mcplx": { res1 = mcplx.acoth(x1); break; }
                            case "sflintc": { res1 = sflintc.acoth(x1); break; }
                            case "dflintc": { res1 = dflintc.acoth(x1); break; }
                            case "eflintc": { res1 = eflintc.acoth(x1); break; }
                            case "qflintc": { res1 = qflintc.acoth(x1); break; }
                            case "oflintc": { res1 = oflintc.acoth(x1); break; }
                            case "mflintc": { res1 = mflintc.acoth(x1); break; }
                            case "aflintc": { res1 = aflintc.acoth(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: acoth({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion




            #region Gamma and related functions for real arguments and parameters



            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d), 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.gamma(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.gamma(x1); break; }
                            case "dflintc": { res1 = dflintc.gamma(x1); break; }
                            case "eflintc": { res1 = eflintc.gamma(x1); break; }
                            case "qflintc": { res1 = qflintc.gamma(x1); break; }
                            case "oflintc": { res1 = oflintc.gamma(x1); break; }
                            case "mflintc": { res1 = mflintc.gamma(x1); break; }
                            case "aflintc": { res1 = aflintc.gamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: gamma({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma1pm1"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d), 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.gamma1pm1(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.gamma1pm1(x1); break; }
                            case "dflintc": { res1 = dflintc.gamma1pm1(x1); break; }
                            case "eflintc": { res1 = eflintc.gamma1pm1(x1); break; }
                            case "qflintc": { res1 = qflintc.gamma1pm1(x1); break; }
                            case "oflintc": { res1 = oflintc.gamma1pm1(x1); break; }
                            case "mflintc": { res1 = mflintc.gamma1pm1(x1); break; }
                            case "aflintc": { res1 = aflintc.gamma1pm1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: gamma1pm1({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("lgamma"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d), 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.lgamma(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.lgamma(x1); break; }
                            case "dflintc": { res1 = dflintc.lgamma(x1); break; }
                            case "eflintc": { res1 = eflintc.lgamma(x1); break; }
                            case "qflintc": { res1 = qflintc.lgamma(x1); break; }
                            case "oflintc": { res1 = oflintc.lgamma(x1); break; }
                            case "mflintc": { res1 = mflintc.lgamma(x1); break; }
                            case "aflintc": { res1 = aflintc.lgamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: lgamma({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("rgamma"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d), 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.rgamma(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.rgamma(x1); break; }
                            case "dflintc": { res1 = dflintc.rgamma(x1); break; }
                            case "eflintc": { res1 = eflintc.rgamma(x1); break; }
                            case "qflintc": { res1 = qflintc.rgamma(x1); break; }
                            case "oflintc": { res1 = oflintc.rgamma(x1); break; }
                            case "mflintc": { res1 = mflintc.rgamma(x1); break; }
                            case "aflintc": { res1 = aflintc.rgamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: rgamma({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("factorial"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d), 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.factorial(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.factorial(x1); break; }
                            case "dflintc": { res1 = dflintc.factorial(x1); break; }
                            case "eflintc": { res1 = eflintc.factorial(x1); break; }
                            case "qflintc": { res1 = qflintc.factorial(x1); break; }
                            case "oflintc": { res1 = oflintc.factorial(x1); break; }
                            case "mflintc": { res1 = mflintc.factorial(x1); break; }
                            case "aflintc": { res1 = aflintc.factorial(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: factorial({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("doublefactorial"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d), 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.doublefactorial(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.doublefactorial(x1); break; }
                            case "dflintc": { res1 = dflintc.doublefactorial(x1); break; }
                            case "eflintc": { res1 = eflintc.doublefactorial(x1); break; }
                            case "qflintc": { res1 = qflintc.doublefactorial(x1); break; }
                            case "oflintc": { res1 = oflintc.doublefactorial(x1); break; }
                            case "mflintc": { res1 = mflintc.doublefactorial(x1); break; }
                            case "aflintc": { res1 = aflintc.doublefactorial(x1); break; }

#endif
                        }
                        Console.WriteLine("{0}: doublefactorial({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("rising_factorial"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d), 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.rising_factorial(x, y); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.rising_factorial(x, y); break; }
                                case "dflintc": { res1 = dflintc.rising_factorial(x, y); break; }
                                case "eflintc": { res1 = eflintc.rising_factorial(x, y); break; }
                                case "qflintc": { res1 = qflintc.rising_factorial(x, y); break; }
                                case "oflintc": { res1 = oflintc.rising_factorial(x, y); break; }
                                case "mflintc": { res1 = mflintc.rising_factorial(x, y); break; }
                                case "aflintc": { res1 = aflintc.rising_factorial(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: rising_factorial({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("falling_factorial"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d), 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.falling_factorial(x, y); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.falling_factorial(x, y); break; }
                                case "dflintc": { res1 = dflintc.falling_factorial(x, y); break; }
                                case "eflintc": { res1 = eflintc.falling_factorial(x, y); break; }
                                case "qflintc": { res1 = qflintc.falling_factorial(x, y); break; }
                                case "oflintc": { res1 = oflintc.falling_factorial(x, y); break; }
                                case "mflintc": { res1 = mflintc.falling_factorial(x, y); break; }
                                case "aflintc": { res1 = aflintc.falling_factorial(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: falling_factorial({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_ratio"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d), 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.gamma_ratio(x, y); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.gamma_ratio(x, y); break; }
                                case "dflintc": { res1 = dflintc.gamma_ratio(x, y); break; }
                                case "eflintc": { res1 = eflintc.gamma_ratio(x, y); break; }
                                case "qflintc": { res1 = qflintc.gamma_ratio(x, y); break; }
                                case "oflintc": { res1 = oflintc.gamma_ratio(x, y); break; }
                                case "mflintc": { res1 = mflintc.gamma_ratio(x, y); break; }
                                case "aflintc": { res1 = aflintc.gamma_ratio(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: gamma_ratio({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_delta_ratio"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d), 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.gamma_delta_ratio(x, y); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.gamma_delta_ratio(x, y); break; }
                                case "dflintc": { res1 = dflintc.gamma_delta_ratio(x, y); break; }
                                case "eflintc": { res1 = eflintc.gamma_delta_ratio(x, y); break; }
                                case "qflintc": { res1 = qflintc.gamma_delta_ratio(x, y); break; }
                                case "oflintc": { res1 = oflintc.gamma_delta_ratio(x, y); break; }
                                case "mflintc": { res1 = mflintc.gamma_delta_ratio(x, y); break; }
                                case "aflintc": { res1 = aflintc.gamma_delta_ratio(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: gamma_delta_ratio({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("beta"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d), 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.beta(x, y); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.beta(x, y); break; }
                                case "dflintc": { res1 = dflintc.beta(x, y); break; }
                                case "eflintc": { res1 = eflintc.beta(x, y); break; }
                                case "qflintc": { res1 = qflintc.beta(x, y); break; }
                                case "oflintc": { res1 = oflintc.beta(x, y); break; }
                                case "mflintc": { res1 = mflintc.beta(x, y); break; }
                                case "aflintc": { res1 = aflintc.beta(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: beta({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("binomial"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d), 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.binomial(x, y); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.binomial(x, y); break; }
                                case "dflintc": { res1 = dflintc.binomial(x, y); break; }
                                case "eflintc": { res1 = eflintc.binomial(x, y); break; }
                                case "qflintc": { res1 = qflintc.binomial(x, y); break; }
                                case "oflintc": { res1 = oflintc.binomial(x, y); break; }
                                case "mflintc": { res1 = mflintc.binomial(x, y); break; }
                                case "aflintc": { res1 = aflintc.binomial(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: binomial({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            #endregion



            #region Miscellaneous functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("lambert_w0"))
            {
                InputArray1 = new[] { dcplx.t(-0.2d), 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.lambert_w0(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.lambert_w0(x1); break; }
                            case "dflintc": { res1 = dflintc.lambert_w0(x1); break; }
                            case "eflintc": { res1 = eflintc.lambert_w0(x1); break; }
                            case "qflintc": { res1 = qflintc.lambert_w0(x1); break; }
                            case "oflintc": { res1 = oflintc.lambert_w0(x1); break; }
                            case "mflintc": { res1 = mflintc.lambert_w0(x1); break; }
                            case "aflintc": { res1 = aflintc.lambert_w0(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: lambert_w0({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("lambert_wm1"))
            {
                InputArray1 = new[] { dcplx.t(-0.2d), -0.01d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "cmath53": { res1 = cmath53.lambert_wm1(x1); break; }
#if HasArbPrecNet
                            case "sflintc": { res1 = sflintc.lambert_wm1(x1); break; }
                            case "dflintc": { res1 = dflintc.lambert_wm1(x1); break; }
                            case "eflintc": { res1 = eflintc.lambert_wm1(x1); break; }
                            case "qflintc": { res1 = qflintc.lambert_wm1(x1); break; }
                            case "oflintc": { res1 = oflintc.lambert_wm1(x1); break; }
                            case "mflintc": { res1 = mflintc.lambert_wm1(x1); break; }
                            case "aflintc": { res1 = aflintc.lambert_wm1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: lambert_wm1({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("agm"))
            {
                InputArray1 = new[] { dcplx.t(-4.333d), 0.0d, 4.333d };
                InputArray2 = new[] { dcplx.t(-4.333d), 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "cmath53": { res1 = cmath53.agm(x, y); break; }
#if HasArbPrecNet
                                case "sflintc": { res1 = sflintc.agm(x, y); break; }
                                case "dflintc": { res1 = dflintc.agm(x, y); break; }
                                case "eflintc": { res1 = eflintc.agm(x, y); break; }
                                case "qflintc": { res1 = qflintc.agm(x, y); break; }
                                case "oflintc": { res1 = oflintc.agm(x, y); break; }
                                case "mflintc": { res1 = mflintc.agm(x, y); break; }
                                case "aflintc": { res1 = aflintc.agm(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: agm({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion



        }







        public static void CplxElementaryFunctions()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTestsBoostFuncCplx();
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