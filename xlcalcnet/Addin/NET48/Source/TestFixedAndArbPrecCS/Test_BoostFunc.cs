using System;
using System.Diagnostics;
using System.Linq;
using FixedPrecNet;


#if HasArbPrecNet
using ArbPrecNet;
#endif




namespace TestXlCalcNetPrecCS
{

    static class TestBoostFunctions
    {


        public static string f(string NumType)
        {
            return (NumType == "aflint") ? "" : " ";
        }




        public static void DemoChapterBasicFloatingPoint(string[] NumTypeArray, string[] FunctionArray)
        {

            double[] InputArray1;
            double[] InputArray2;
            double[] InputArray3;
            // Dim InputArray4 As Double()
            int[] InputArrayInt1;
            // Dim InputArrayInt2 As Integer()


            #region General functions or real numbers


            if (FunctionArray.Contains("all") | FunctionArray.Contains("fma"))
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
                                switch (NumType)
                                {
                                    case "math53": { res1 = math53.fma(x, y, z); break; }
                                    case " sreal": { res1 = sreal.fma(x, y, z); break; }
                                    case " dreal": { res1 = dreal.fma(x, y, z); break; }
                                    case " ereal": { res1 = ereal.fma(x, y, z); break; }
                                    case " qreal": { res1 = qreal.fma(x, y, z); break; }
                                    case " oreal": { res1 = oreal.fma(x, y, z); break; }
#if HasArbPrecNet
                                    case " yreal": { res1 = yreal.fma(x, y, z); break; }
                                    case " zreal": { res1 = zreal.fma(x, y, z); break; }
                                    case " creal": { res1 = creal.fma(x, y, z); break; }
                                    case " mreal": { res1 = mreal.fma(x, y, z); break; }
                                    case "sflint": { res1 = sflint.fma(x, y, z); break; }
                                    case "dflint": { res1 = dflint.fma(x, y, z); break; }
                                    case "eflint": { res1 = eflint.fma(x, y, z); break; }
                                    case "qflint": { res1 = qflint.fma(x, y, z); break; }
                                    case "oflint": { res1 = oflint.fma(x, y, z); break; }
                                    case "cflint": { res1 = cflint.fma(x, y, z); break; }
                                    case "mflint": { res1 = mflint.fma(x, y, z); break; }
                                    case "iflint": { res1 = iflint.fma(x, y, z); break; }
                                    case "aflint": { res1 = aflint.fma(x, y, z); break; }
#endif
                                }
                                Console.WriteLine("{0}: fma(x={1}, y={2}, z={3}): " + f(NumType) + "{4}", NumType, x, y, z, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("fmax"))
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
                                case "math53": { res1 = math53.fmax(x, y); break; }
                                case " sreal": { res1 = sreal.fmax(x, y); break; }
                                case " dreal": { res1 = dreal.fmax(x, y); break; }
                                case " ereal": { res1 = ereal.fmax(x, y); break; }
                                case " qreal": { res1 = qreal.fmax(x, y); break; }
                                case " oreal": { res1 = oreal.fmax(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.fmax(x, y); break; }
                                case " zreal": { res1 = zreal.fmax(x, y); break; }
                                case " creal": { res1 = creal.fmax(x, y); break; }
                                case " mreal": { res1 = mreal.fmax(x, y); break; }
                                case "sflint": { res1 = sflint.fmax(x, y); break; }
                                case "dflint": { res1 = dflint.fmax(x, y); break; }
                                case "eflint": { res1 = eflint.fmax(x, y); break; }
                                case "qflint": { res1 = qflint.fmax(x, y); break; }
                                case "oflint": { res1 = oflint.fmax(x, y); break; }
                                case "cflint": { res1 = cflint.fmax(x, y); break; }
                                case "mflint": { res1 = mflint.fmax(x, y); break; }
                                case "iflint": { res1 = iflint.fmax(x, y); break; }
                                case "aflint": { res1 = aflint.fmax(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: fmax(x={1}, y={2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("fmin"))
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
                                case "math53": { res1 = math53.fmin(x, y); break; }
                                case " sreal": { res1 = sreal.fmin(x, y); break; }
                                case " dreal": { res1 = dreal.fmin(x, y); break; }
                                case " ereal": { res1 = ereal.fmin(x, y); break; }
                                case " qreal": { res1 = qreal.fmin(x, y); break; }
                                case " oreal": { res1 = oreal.fmin(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.fmin(x, y); break; }
                                case " zreal": { res1 = zreal.fmin(x, y); break; }
                                case " creal": { res1 = creal.fmin(x, y); break; }
                                case " mreal": { res1 = mreal.fmin(x, y); break; }
                                case "sflint": { res1 = sflint.fmin(x, y); break; }
                                case "dflint": { res1 = dflint.fmin(x, y); break; }
                                case "eflint": { res1 = eflint.fmin(x, y); break; }
                                case "qflint": { res1 = qflint.fmin(x, y); break; }
                                case "oflint": { res1 = oflint.fmin(x, y); break; }
                                case "cflint": { res1 = cflint.fmin(x, y); break; }
                                case "mflint": { res1 = mflint.fmin(x, y); break; }
                                case "iflint": { res1 = iflint.fmin(x, y); break; }
                                case "aflint": { res1 = aflint.fmin(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: fmin(x={1}, y={2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            #endregion



            #region Machine constants


            if (FunctionArray.Contains("all") | FunctionArray.Contains("zero"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.zero(); break; }
                        case " sreal": { res1 = sreal.zero(); break; }
                        case " dreal": { res1 = dreal.zero(); break; }
                        case " ereal": { res1 = ereal.zero(); break; }
                        case " qreal": { res1 = qreal.zero(); break; }
                        case " oreal": { res1 = oreal.zero(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.zero(); break; }
                        case " zreal": { res1 = yreal.zero(); break; }
                        case " creal": { res1 = creal.zero(); break; }
                        case " mreal": { res1 = mreal.zero(); break; }
                        case "sflint": { res1 = sflint.zero(); break; }
                        case "dflint": { res1 = dflint.zero(); break; }
                        case "eflint": { res1 = eflint.zero(); break; }
                        case "qflint": { res1 = qflint.zero(); break; }
                        case "oflint": { res1 = oflint.zero(); break; }
                        case "cflint": { res1 = cflint.zero(); break; }
                        case "mflint": { res1 = mflint.zero(); break; }
                        case "iflint": { res1 = iflint.zero(); break; }
                        case "aflint": { res1 = aflint.zero(); break; }
#endif
                    }
                    Console.WriteLine("{0}: zero(): {1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("negzero"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.negzero(); break; }
                        case " sreal": { res1 = sreal.negzero(); break; }
                        case " dreal": { res1 = dreal.negzero(); break; }
                        case " ereal": { res1 = ereal.negzero(); break; }
                        case " qreal": { res1 = qreal.negzero(); break; }
                        case " oreal": { res1 = oreal.negzero(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.negzero(); break; }
                        case " zreal": { res1 = zreal.negzero(); break; }
                        case " creal": { res1 = creal.negzero(); break; }
                        case " mreal": { res1 = mreal.negzero(); break; }
                        case "sflint": { res1 = sflint.negzero(); break; }
                        case "dflint": { res1 = dflint.negzero(); break; }
                        case "eflint": { res1 = eflint.negzero(); break; }
                        case "qflint": { res1 = qflint.negzero(); break; }
                        case "oflint": { res1 = oflint.negzero(); break; }
                        case "cflint": { res1 = cflint.negzero(); break; }
                        case "mflint": { res1 = mflint.negzero(); break; }
                        case "iflint": { res1 = iflint.negzero(); break; }
                        case "aflint": { res1 = aflint.negzero(); break; }
#endif
                    }
                    Console.WriteLine("{0}: negzero(): {1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("one"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.one(); break; }
                        case " sreal": { res1 = sreal.one(); break; }
                        case " dreal": { res1 = dreal.one(); break; }
                        case " ereal": { res1 = ereal.one(); break; }
                        case " qreal": { res1 = qreal.one(); break; }
                        case " oreal": { res1 = oreal.one(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.one(); break; }
                        case " zreal": { res1 = zreal.one(); break; }
                        case " creal": { res1 = creal.one(); break; }
                        case " mreal": { res1 = mreal.one(); break; }
                        case "sflint": { res1 = sflint.one(); break; }
                        case "dflint": { res1 = dflint.one(); break; }
                        case "eflint": { res1 = eflint.one(); break; }
                        case "qflint": { res1 = qflint.one(); break; }
                        case "oflint": { res1 = oflint.one(); break; }
                        case "cflint": { res1 = cflint.one(); break; }
                        case "mflint": { res1 = mflint.one(); break; }
                        case "iflint": { res1 = iflint.one(); break; }
                        case "aflint": { res1 = aflint.one(); break; }
#endif
                    }
                    Console.WriteLine("{0}: one(): {1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("inf"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.inf(); break; }
                        case " sreal": { res1 = sreal.inf(); break; }
                        case " dreal": { res1 = dreal.inf(); break; }
                        case " ereal": { res1 = ereal.inf(); break; }
                        case " qreal": { res1 = qreal.inf(); break; }
                        case " oreal": { res1 = oreal.inf(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.inf(); break; }
                        case " zreal": { res1 = zreal.inf(); break; }
                        case " creal": { res1 = creal.inf(); break; }
                        case " mreal": { res1 = mreal.inf(); break; }
                        case "sflint": { res1 = sflint.inf(); break; }
                        case "dflint": { res1 = dflint.inf(); break; }
                        case "eflint": { res1 = eflint.inf(); break; }
                        case "qflint": { res1 = qflint.inf(); break; }
                        case "oflint": { res1 = oflint.inf(); break; }
                        case "cflint": { res1 = cflint.inf(); break; }
                        case "mflint": { res1 = mflint.inf(); break; }
                        case "iflint": { res1 = iflint.inf(); break; }
                        case "aflint": { res1 = aflint.inf(); break; }
#endif
                    }
                    Console.WriteLine("{0}: inf(): {1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("neginf"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.neginf(); break; }
                        case " sreal": { res1 = sreal.neginf(); break; }
                        case " dreal": { res1 = dreal.neginf(); break; }
                        case " ereal": { res1 = ereal.neginf(); break; }
                        case " qreal": { res1 = qreal.neginf(); break; }
                        case " oreal": { res1 = oreal.neginf(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.neginf(); break; }
                        case " zreal": { res1 = zreal.neginf(); break; }
                        case " creal": { res1 = creal.neginf(); break; }
                        case " mreal": { res1 = mreal.neginf(); break; }
                        case "sflint": { res1 = sflint.neginf(); break; }
                        case "dflint": { res1 = dflint.neginf(); break; }
                        case "eflint": { res1 = eflint.neginf(); break; }
                        case "qflint": { res1 = qflint.neginf(); break; }
                        case "oflint": { res1 = oflint.neginf(); break; }
                        case "cflint": { res1 = cflint.neginf(); break; }
                        case "mflint": { res1 = mflint.neginf(); break; }
                        case "iflint": { res1 = iflint.neginf(); break; }
                        case "aflint": { res1 = aflint.neginf(); break; }
#endif
                    }
                    Console.WriteLine("{0}: neginf(): {1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("nan"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.nan(); break; }
                        case " sreal": { res1 = sreal.nan(); break; }
                        case " dreal": { res1 = dreal.nan(); break; }
                        case " ereal": { res1 = ereal.nan(); break; }
                        case " qreal": { res1 = qreal.nan(); break; }
                        case " oreal": { res1 = oreal.nan(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.nan(); break; }
                        case " zreal": { res1 = zreal.nan(); break; }
                        case " creal": { res1 = creal.nan(); break; }
                        case " mreal": { res1 = mreal.nan(); break; }
                        case "sflint": { res1 = sflint.nan(); break; }
                        case "dflint": { res1 = dflint.nan(); break; }
                        case "eflint": { res1 = eflint.nan(); break; }
                        case "qflint": { res1 = qflint.nan(); break; }
                        case "oflint": { res1 = oflint.nan(); break; }
                        case "cflint": { res1 = cflint.nan(); break; }
                        case "mflint": { res1 = mflint.nan(); break; }
                        case "iflint": { res1 = iflint.nan(); break; }
                        case "aflint": { res1 = aflint.nan(); break; }
#endif
                    }
                    Console.WriteLine("{0}: nan(): {1}", NumType, res1);
                }
                Console.WriteLine();
            }



            #endregion



            #region Properties of numbers


            if (FunctionArray.Contains("all") | FunctionArray.Contains("signbit"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.signbit(x1); break; }
                            case " sreal": { res1 = sreal.signbit(x1); break; }
                            case " dreal": { res1 = dreal.signbit(x1); break; }
                            case " ereal": { res1 = ereal.signbit(x1); break; }
                            case " qreal": { res1 = qreal.signbit(x1); break; }
                            case " oreal": { res1 = oreal.signbit(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.signbit(x1); break; }
                            case " zreal": { res1 = zreal.signbit(x1); break; }
                            case " creal": { res1 = creal.signbit(x1); break; }
                            case " mreal": { res1 = mreal.signbit(x1); break; }
                            case "sflint": { res1 = sflint.signbit(x1); break; }
                            case "dflint": { res1 = dflint.signbit(x1); break; }
                            case "eflint": { res1 = eflint.signbit(x1); break; }
                            case "qflint": { res1 = qflint.signbit(x1); break; }
                            case "oflint": { res1 = oflint.signbit(x1); break; }
                            case "cflint": { res1 = cflint.signbit(x1); break; }
                            case "mflint": { res1 = mflint.signbit(x1); break; }
                            case "iflint": { res1 = iflint.signbit(x1); break; }
                            case "aflint": { res1 = aflint.signbit(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: signbit({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("isfinite"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.isfinite(x1); break; }
                            case " sreal": { res1 = sreal.isfinite(x1); break; }
                            case " dreal": { res1 = dreal.isfinite(x1); break; }
                            case " ereal": { res1 = ereal.isfinite(x1); break; }
                            case " qreal": { res1 = qreal.isfinite(x1); break; }
                            case " oreal": { res1 = oreal.isfinite(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.isfinite(x1); break; }
                            case " zreal": { res1 = zreal.isfinite(x1); break; }
                            case " creal": { res1 = creal.isfinite(x1); break; }
                            case " mreal": { res1 = mreal.isfinite(x1); break; }
                            case "sflint": { res1 = sflint.isfinite(x1); break; }
                            case "dflint": { res1 = dflint.isfinite(x1); break; }
                            case "eflint": { res1 = eflint.isfinite(x1); break; }
                            case "qflint": { res1 = qflint.isfinite(x1); break; }
                            case "oflint": { res1 = oflint.isfinite(x1); break; }
                            case "cflint": { res1 = cflint.isfinite(x1); break; }
                            case "mflint": { res1 = mflint.isfinite(x1); break; }
                            case "iflint": { res1 = iflint.isfinite(x1); break; }
                            case "aflint": { res1 = aflint.isfinite(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: isfinite({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("isinf"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.isinf(x1); break; }
                            case " sreal": { res1 = sreal.isinf(x1); break; }
                            case " dreal": { res1 = dreal.isinf(x1); break; }
                            case " ereal": { res1 = ereal.isinf(x1); break; }
                            case " qreal": { res1 = qreal.isinf(x1); break; }
                            case " oreal": { res1 = oreal.isinf(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.isinf(x1); break; }
                            case " zreal": { res1 = zreal.isinf(x1); break; }
                            case " creal": { res1 = creal.isinf(x1); break; }
                            case " mreal": { res1 = mreal.isinf(x1); break; }
                            case "sflint": { res1 = sflint.isinf(x1); break; }
                            case "dflint": { res1 = dflint.isinf(x1); break; }
                            case "eflint": { res1 = eflint.isinf(x1); break; }
                            case "qflint": { res1 = qflint.isinf(x1); break; }
                            case "oflint": { res1 = oflint.isinf(x1); break; }
                            case "cflint": { res1 = cflint.isinf(x1); break; }
                            case "mflint": { res1 = mflint.isinf(x1); break; }
                            case "iflint": { res1 = iflint.isinf(x1); break; }
                            case "aflint": { res1 = aflint.isinf(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: isinf({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("isposinf"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.isposinf(x1); break; }
                            case " sreal": { res1 = sreal.isposinf(x1); break; }
                            case " dreal": { res1 = dreal.isposinf(x1); break; }
                            case " ereal": { res1 = ereal.isposinf(x1); break; }
                            case " qreal": { res1 = qreal.isposinf(x1); break; }
                            case " oreal": { res1 = oreal.isposinf(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.isposinf(x1); break; }
                            case " zreal": { res1 = zreal.isposinf(x1); break; }
                            case " creal": { res1 = creal.isposinf(x1); break; }
                            case " mreal": { res1 = mreal.isposinf(x1); break; }
                            case "sflint": { res1 = sflint.isposinf(x1); break; }
                            case "dflint": { res1 = dflint.isposinf(x1); break; }
                            case "eflint": { res1 = eflint.isposinf(x1); break; }
                            case "qflint": { res1 = qflint.isposinf(x1); break; }
                            case "oflint": { res1 = oflint.isposinf(x1); break; }
                            case "cflint": { res1 = cflint.isposinf(x1); break; }
                            case "mflint": { res1 = mflint.isposinf(x1); break; }
                            case "iflint": { res1 = iflint.isposinf(x1); break; }
                            case "aflint": { res1 = aflint.isposinf(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: isposinf({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("isneginf"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.isneginf(x1); break; }
                            case " sreal": { res1 = sreal.isneginf(x1); break; }
                            case " dreal": { res1 = dreal.isneginf(x1); break; }
                            case " ereal": { res1 = ereal.isneginf(x1); break; }
                            case " qreal": { res1 = qreal.isneginf(x1); break; }
                            case " oreal": { res1 = oreal.isneginf(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.isneginf(x1); break; }
                            case " zreal": { res1 = zreal.isneginf(x1); break; }
                            case " creal": { res1 = creal.isneginf(x1); break; }
                            case " mreal": { res1 = mreal.isneginf(x1); break; }
                            case "sflint": { res1 = sflint.isneginf(x1); break; }
                            case "dflint": { res1 = dflint.isneginf(x1); break; }
                            case "eflint": { res1 = eflint.isneginf(x1); break; }
                            case "qflint": { res1 = qflint.isneginf(x1); break; }
                            case "oflint": { res1 = oflint.isneginf(x1); break; }
                            case "cflint": { res1 = cflint.isneginf(x1); break; }
                            case "mflint": { res1 = mflint.isneginf(x1); break; }
                            case "iflint": { res1 = iflint.isneginf(x1); break; }
                            case "aflint": { res1 = aflint.isneginf(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: isneginf({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("isnan"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.isnan(x1); break; }
                            case " sreal": { res1 = sreal.isnan(x1); break; }
                            case " dreal": { res1 = dreal.isnan(x1); break; }
                            case " ereal": { res1 = ereal.isnan(x1); break; }
                            case " qreal": { res1 = qreal.isnan(x1); break; }
                            case " oreal": { res1 = oreal.isnan(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.isnan(x1); break; }
                            case " zreal": { res1 = zreal.isnan(x1); break; }
                            case " creal": { res1 = creal.isnan(x1); break; }
                            case " mreal": { res1 = mreal.isnan(x1); break; }
                            case "sflint": { res1 = sflint.isnan(x1); break; }
                            case "dflint": { res1 = dflint.isnan(x1); break; }
                            case "eflint": { res1 = eflint.isnan(x1); break; }
                            case "qflint": { res1 = qflint.isnan(x1); break; }
                            case "oflint": { res1 = oflint.isnan(x1); break; }
                            case "cflint": { res1 = cflint.isnan(x1); break; }
                            case "mflint": { res1 = mflint.isnan(x1); break; }
                            case "iflint": { res1 = iflint.isnan(x1); break; }
                            case "aflint": { res1 = aflint.isnan(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: isnan({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("iszero"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.iszero(x1); break; }
                            case " sreal": { res1 = sreal.iszero(x1); break; }
                            case " dreal": { res1 = dreal.iszero(x1); break; }
                            case " ereal": { res1 = ereal.iszero(x1); break; }
                            case " qreal": { res1 = qreal.iszero(x1); break; }
                            case " oreal": { res1 = oreal.iszero(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.iszero(x1); break; }
                            case " zreal": { res1 = zreal.iszero(x1); break; }
                            case " creal": { res1 = creal.iszero(x1); break; }
                            case " mreal": { res1 = mreal.iszero(x1); break; }
                            case "sflint": { res1 = sflint.iszero(x1); break; }
                            case "dflint": { res1 = dflint.iszero(x1); break; }
                            case "eflint": { res1 = eflint.iszero(x1); break; }
                            case "qflint": { res1 = qflint.iszero(x1); break; }
                            case "oflint": { res1 = oflint.iszero(x1); break; }
                            case "cflint": { res1 = cflint.iszero(x1); break; }
                            case "mflint": { res1 = mflint.iszero(x1); break; }
                            case "iflint": { res1 = iflint.iszero(x1); break; }
                            case "aflint": { res1 = aflint.iszero(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: iszero({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("isone"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.isone(x1); break; }
                            case " sreal": { res1 = sreal.isone(x1); break; }
                            case " dreal": { res1 = dreal.isone(x1); break; }
                            case " ereal": { res1 = ereal.isone(x1); break; }
                            case " qreal": { res1 = qreal.isone(x1); break; }
                            case " oreal": { res1 = oreal.isone(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.isone(x1); break; }
                            case " zreal": { res1 = zreal.isone(x1); break; }
                            case " creal": { res1 = creal.isone(x1); break; }
                            case " mreal": { res1 = mreal.isone(x1); break; }
                            case "sflint": { res1 = sflint.isone(x1); break; }
                            case "dflint": { res1 = dflint.isone(x1); break; }
                            case "eflint": { res1 = eflint.isone(x1); break; }
                            case "qflint": { res1 = qflint.isone(x1); break; }
                            case "oflint": { res1 = oflint.isone(x1); break; }
                            case "cflint": { res1 = cflint.isone(x1); break; }
                            case "mflint": { res1 = mflint.isone(x1); break; }
                            case "iflint": { res1 = iflint.isone(x1); break; }
                            case "aflint": { res1 = aflint.isone(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: isone({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("isinteger"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.isinteger(x1); break; }
                            case " sreal": { res1 = sreal.isinteger(x1); break; }
                            case " dreal": { res1 = dreal.isinteger(x1); break; }
                            case " ereal": { res1 = ereal.isinteger(x1); break; }
                            case " qreal": { res1 = qreal.isinteger(x1); break; }
                            case " oreal": { res1 = oreal.isinteger(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.isinteger(x1); break; }
                            case " zreal": { res1 = zreal.isinteger(x1); break; }
                            case " creal": { res1 = creal.isinteger(x1); break; }
                            case " mreal": { res1 = mreal.isinteger(x1); break; }
                            case "sflint": { res1 = sflint.isinteger(x1); break; }
                            case "dflint": { res1 = dflint.isinteger(x1); break; }
                            case "eflint": { res1 = eflint.isinteger(x1); break; }
                            case "qflint": { res1 = qflint.isinteger(x1); break; }
                            case "oflint": { res1 = oflint.isinteger(x1); break; }
                            case "cflint": { res1 = cflint.isinteger(x1); break; }
                            case "mflint": { res1 = mflint.isinteger(x1); break; }
                            case "iflint": { res1 = iflint.isinteger(x1); break; }
                            case "aflint": { res1 = aflint.isinteger(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: isinteger({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("isnumber"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.isnumber(x1); break; }
                            case " sreal": { res1 = sreal.isnumber(x1); break; }
                            case " dreal": { res1 = dreal.isnumber(x1); break; }
                            case " ereal": { res1 = ereal.isnumber(x1); break; }
                            case " qreal": { res1 = qreal.isnumber(x1); break; }
                            case " oreal": { res1 = oreal.isnumber(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.isnumber(x1); break; }
                            case " zreal": { res1 = zreal.isnumber(x1); break; }
                            //case " creal": { res1 = creal.isnumber(x1); break; }
                            case " mreal": { res1 = mreal.isnumber(x1); break; }
                            case "sflint": { res1 = sflint.isnumber(x1); break; }
                            case "dflint": { res1 = dflint.isnumber(x1); break; }
                            case "eflint": { res1 = eflint.isnumber(x1); break; }
                            case "qflint": { res1 = qflint.isnumber(x1); break; }
                            case "oflint": { res1 = oflint.isnumber(x1); break; }
                            //case "cflint": { res1 = cflint.isnumber(x1); break; }
                            case "mflint": { res1 = mflint.isnumber(x1); break; }
                            case "iflint": { res1 = iflint.isnumber(x1); break; }
                            //case "aflint": { res1 = aflint.isnumber(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: isnumber({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("isregular"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.isregular(x1); break; }
                            case " sreal": { res1 = sreal.isregular(x1); break; }
                            case " dreal": { res1 = dreal.isregular(x1); break; }
                            case " ereal": { res1 = ereal.isregular(x1); break; }
                            case " qreal": { res1 = qreal.isregular(x1); break; }
                            case " oreal": { res1 = oreal.isregular(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.isregular(x1); break; }
                            case " zreal": { res1 = zreal.isregular(x1); break; }
                            //case " creal": { res1 = creal.isregular(x1); break; }
                            case " mreal": { res1 = mreal.isregular(x1); break; }
                            case "sflint": { res1 = sflint.isregular(x1); break; }
                            case "dflint": { res1 = dflint.isregular(x1); break; }
                            case "eflint": { res1 = eflint.isregular(x1); break; }
                            case "qflint": { res1 = qflint.isregular(x1); break; }
                            case "oflint": { res1 = oflint.isregular(x1); break; }
                            //case "cflint": { res1 = cflint.isregular(x1); break; }
                            case "mflint": { res1 = mflint.isregular(x1); break; }
                            case "iflint": { res1 = iflint.isregular(x1); break; }
                            //case "aflint": { res1 = aflint.isregular(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: isregular({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("isnormal"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.isnormal(x1); break; }
                            case " sreal": { res1 = sreal.isnormal(x1); break; }
                            case " dreal": { res1 = dreal.isnormal(x1); break; }
                            case " ereal": { res1 = ereal.isnormal(x1); break; }
                            case " qreal": { res1 = qreal.isnormal(x1); break; }
                            case " oreal": { res1 = oreal.isnormal(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.isnormal(x1); break; }
                            case " zreal": { res1 = zreal.isnormal(x1); break; }
                            //case " creal": { res1 = creal.isnormal(x1); break; }
                            case " mreal": { res1 = mreal.isnormal(x1); break; }
                            case "sflint": { res1 = sflint.isnormal(x1); break; }
                            case "dflint": { res1 = dflint.isnormal(x1); break; }
                            case "eflint": { res1 = eflint.isnormal(x1); break; }
                            case "qflint": { res1 = qflint.isnormal(x1); break; }
                            case "oflint": { res1 = oflint.isnormal(x1); break; }
                            //case "cflint": { res1 = cflint.isnormal(x1); break; }
                            case "mflint": { res1 = mflint.isnormal(x1); break; }
                            case "iflint": { res1 = iflint.isnormal(x1); break; }
                            //case "aflint": { res1 = aflint.isnormal(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: isnormal({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("isunordered"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.isunordered(x, y); break; }
                                case " sreal": { res1 = sreal.isunordered(x, y); break; }
                                case " dreal": { res1 = dreal.isunordered(x, y); break; }
                                case " ereal": { res1 = ereal.isunordered(x, y); break; }
                                case " qreal": { res1 = qreal.isunordered(x, y); break; }
                                case " oreal": { res1 = oreal.isunordered(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.isunordered(x, y); break; }
                                case " zreal": { res1 = zreal.isunordered(x, y); break; }
                                //case " creal": { res1 = creal.isunordered(x, y); break; }
                                case " mreal": { res1 = mreal.isunordered(x, y); break; }
                                case "sflint": { res1 = sflint.isunordered(x, y); break; }
                                case "dflint": { res1 = dflint.isunordered(x, y); break; }
                                case "eflint": { res1 = eflint.isunordered(x, y); break; }
                                case "qflint": { res1 = qflint.isunordered(x, y); break; }
                                case "oflint": { res1 = oflint.isunordered(x, y); break; }
                                //case "cflint": { res1 = cflint.isunordered(x, y); break; }
                                case "mflint": { res1 = mflint.isunordered(x, y); break; }
                                case "iflint": { res1 = iflint.isunordered(x, y); break; }
                                //case "aflint": { res1 = aflint.isunordered(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: isunordered({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("fitsint32"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.fitsint32(x1); break; }
                            case " sreal": { res1 = sreal.fitsint32(x1); break; }
                            case " dreal": { res1 = dreal.fitsint32(x1); break; }
                            case " ereal": { res1 = ereal.fitsint32(x1); break; }
                            case " qreal": { res1 = qreal.fitsint32(x1); break; }
                            case " oreal": { res1 = oreal.fitsint32(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.fitsint32(x1); break; }
                            case " zreal": { res1 = zreal.fitsint32(x1); break; }
                            case " creal": { res1 = creal.fitsint32(x1); break; }
                            case " mreal": { res1 = mreal.fitsint32(x1); break; }
                            case "sflint": { res1 = sflint.fitsint32(x1); break; }
                            case "dflint": { res1 = dflint.fitsint32(x1); break; }
                            case "eflint": { res1 = eflint.fitsint32(x1); break; }
                            case "qflint": { res1 = qflint.fitsint32(x1); break; }
                            case "oflint": { res1 = oflint.fitsint32(x1); break; }
                            case "cflint": { res1 = cflint.fitsint32(x1); break; }
                            case "mflint": { res1 = mflint.fitsint32(x1); break; }
                            case "iflint": { res1 = iflint.fitsint32(x1); break; }
                            case "aflint": { res1 = aflint.fitsint32(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: fitsint32({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("fitsint64"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.fitsint64(x1); break; }
                            case " sreal": { res1 = sreal.fitsint64(x1); break; }
                            case " dreal": { res1 = dreal.fitsint64(x1); break; }
                            case " ereal": { res1 = ereal.fitsint64(x1); break; }
                            case " qreal": { res1 = qreal.fitsint64(x1); break; }
                            case " oreal": { res1 = oreal.fitsint64(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.fitsint64(x1); break; }
                            case " zreal": { res1 = zreal.fitsint64(x1); break; }
                            case " creal": { res1 = creal.fitsint64(x1); break; }
                            case " mreal": { res1 = mreal.fitsint64(x1); break; }
                            case "sflint": { res1 = sflint.fitsint64(x1); break; }
                            case "dflint": { res1 = dflint.fitsint64(x1); break; }
                            case "eflint": { res1 = eflint.fitsint64(x1); break; }
                            case "qflint": { res1 = qflint.fitsint64(x1); break; }
                            case "oflint": { res1 = oflint.fitsint64(x1); break; }
                            case "cflint": { res1 = cflint.fitsint64(x1); break; }
                            case "mflint": { res1 = mflint.fitsint64(x1); break; }
                            case "iflint": { res1 = iflint.fitsint64(x1); break; }
                            case "aflint": { res1 = aflint.fitsint64(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: fitsint64({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            #endregion





            #region Integer Related Functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("nearbyint"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.nearbyint(x1); break; }
                            case " sreal": { res1 = sreal.nearbyint(x1); break; }
                            case " dreal": { res1 = dreal.nearbyint(x1); break; }
                            case " ereal": { res1 = ereal.nearbyint(x1); break; }
                            case " qreal": { res1 = qreal.nearbyint(x1); break; }
                            case " oreal": { res1 = oreal.nearbyint(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.nearbyint(x1); break; }
                            case " zreal": { res1 = zreal.nearbyint(x1); break; }
                            case " creal": { res1 = creal.nearbyint(x1); break; }
                            case " mreal": { res1 = mreal.nearbyint(x1); break; }
                            case "sflint": { res1 = sflint.nearbyint(x1); break; }
                            case "dflint": { res1 = dflint.nearbyint(x1); break; }
                            case "eflint": { res1 = eflint.nearbyint(x1); break; }
                            case "qflint": { res1 = qflint.nearbyint(x1); break; }
                            case "oflint": { res1 = oflint.nearbyint(x1); break; }
                            case "cflint": { res1 = cflint.nearbyint(x1); break; }
                            case "mflint": { res1 = mflint.nearbyint(x1); break; }
                            case "iflint": { res1 = iflint.nearbyint(x1); break; }
                            case "aflint": { res1 = aflint.nearbyint(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: nearbyint({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("rint"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.rint(x1); break; }
                            case " sreal": { res1 = sreal.rint(x1); break; }
                            case " dreal": { res1 = dreal.rint(x1); break; }
                            case " ereal": { res1 = ereal.rint(x1); break; }
                            case " qreal": { res1 = qreal.rint(x1); break; }
                            case " oreal": { res1 = oreal.rint(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.rint(x1); break; }
                            case " zreal": { res1 = zreal.rint(x1); break; }
                            case " creal": { res1 = creal.rint(x1); break; }
                            case " mreal": { res1 = mreal.rint(x1); break; }
                            case "sflint": { res1 = sflint.rint(x1); break; }
                            case "dflint": { res1 = dflint.rint(x1); break; }
                            case "eflint": { res1 = eflint.rint(x1); break; }
                            case "qflint": { res1 = qflint.rint(x1); break; }
                            case "oflint": { res1 = oflint.rint(x1); break; }
                            case "cflint": { res1 = cflint.rint(x1); break; }
                            case "mflint": { res1 = mflint.rint(x1); break; }
                            case "iflint": { res1 = iflint.rint(x1); break; }
                            case "aflint": { res1 = aflint.rint(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: rint({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("lrint"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.lrint(x1); break; }
                            case " sreal": { res1 = sreal.lrint(x1); break; }
                            case " dreal": { res1 = dreal.lrint(x1); break; }
                            case " ereal": { res1 = ereal.lrint(x1); break; }
                            case " qreal": { res1 = qreal.lrint(x1); break; }
                            case " oreal": { res1 = oreal.lrint(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.lrint(x1); break; }
                            case " zreal": { res1 = zreal.lrint(x1); break; }
                            case " creal": { res1 = creal.lrint(x1); break; }
                            case " mreal": { res1 = mreal.lrint(x1); break; }
                            case "sflint": { res1 = sflint.lrint(x1); break; }
                            case "dflint": { res1 = dflint.lrint(x1); break; }
                            case "eflint": { res1 = eflint.lrint(x1); break; }
                            case "qflint": { res1 = qflint.lrint(x1); break; }
                            case "oflint": { res1 = oflint.lrint(x1); break; }
                            case "cflint": { res1 = cflint.lrint(x1); break; }
                            case "mflint": { res1 = mflint.lrint(x1); break; }
                            case "iflint": { res1 = iflint.lrint(x1); break; }
                            case "aflint": { res1 = aflint.lrint(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: lrint({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("llrint"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.llrint(x1); break; }
                            case " sreal": { res1 = sreal.llrint(x1); break; }
                            case " dreal": { res1 = dreal.llrint(x1); break; }
                            case " ereal": { res1 = ereal.llrint(x1); break; }
                            case " qreal": { res1 = qreal.llrint(x1); break; }
                            case " oreal": { res1 = oreal.llrint(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.llrint(x1); break; }
                            case " zreal": { res1 = zreal.llrint(x1); break; }
                            case " creal": { res1 = creal.llrint(x1); break; }
                            case " mreal": { res1 = mreal.llrint(x1); break; }
                            case "sflint": { res1 = sflint.llrint(x1); break; }
                            case "dflint": { res1 = dflint.llrint(x1); break; }
                            case "eflint": { res1 = eflint.llrint(x1); break; }
                            case "qflint": { res1 = qflint.llrint(x1); break; }
                            case "oflint": { res1 = oflint.llrint(x1); break; }
                            case "cflint": { res1 = cflint.llrint(x1); break; }
                            case "mflint": { res1 = mflint.llrint(x1); break; }
                            case "iflint": { res1 = iflint.llrint(x1); break; }
                            case "aflint": { res1 = aflint.llrint(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: llrint({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ceil"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.ceil(x1); break; }
                            case " sreal": { res1 = sreal.ceil(x1); break; }
                            case " dreal": { res1 = dreal.ceil(x1); break; }
                            case " ereal": { res1 = ereal.ceil(x1); break; }
                            case " qreal": { res1 = qreal.ceil(x1); break; }
                            case " oreal": { res1 = oreal.ceil(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.ceil(x1); break; }
                            case " zreal": { res1 = zreal.ceil(x1); break; }
                            case " creal": { res1 = creal.ceil(x1); break; }
                            case " mreal": { res1 = mreal.ceil(x1); break; }
                            case "sflint": { res1 = sflint.ceil(x1); break; }
                            case "dflint": { res1 = dflint.ceil(x1); break; }
                            case "eflint": { res1 = eflint.ceil(x1); break; }
                            case "qflint": { res1 = qflint.ceil(x1); break; }
                            case "oflint": { res1 = oflint.ceil(x1); break; }
                            case "cflint": { res1 = cflint.ceil(x1); break; }
                            case "mflint": { res1 = mflint.ceil(x1); break; }
                            case "iflint": { res1 = iflint.ceil(x1); break; }
                            case "aflint": { res1 = aflint.ceil(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: ceil({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("floor"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.floor(x1); break; }
                            case " sreal": { res1 = sreal.floor(x1); break; }
                            case " dreal": { res1 = dreal.floor(x1); break; }
                            case " ereal": { res1 = ereal.floor(x1); break; }
                            case " qreal": { res1 = qreal.floor(x1); break; }
                            case " oreal": { res1 = oreal.floor(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.floor(x1); break; }
                            case " zreal": { res1 = zreal.floor(x1); break; }
                            case " creal": { res1 = creal.floor(x1); break; }
                            case " mreal": { res1 = mreal.floor(x1); break; }
                            case "sflint": { res1 = sflint.floor(x1); break; }
                            case "dflint": { res1 = dflint.floor(x1); break; }
                            case "eflint": { res1 = eflint.floor(x1); break; }
                            case "qflint": { res1 = qflint.floor(x1); break; }
                            case "oflint": { res1 = oflint.floor(x1); break; }
                            case "cflint": { res1 = cflint.floor(x1); break; }
                            case "mflint": { res1 = mflint.floor(x1); break; }
                            case "iflint": { res1 = iflint.floor(x1); break; }
                            case "aflint": { res1 = aflint.floor(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: floor({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("trunc"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.trunc(x1); break; }
                            case " sreal": { res1 = sreal.trunc(x1); break; }
                            case " dreal": { res1 = dreal.trunc(x1); break; }
                            case " ereal": { res1 = ereal.trunc(x1); break; }
                            case " qreal": { res1 = qreal.trunc(x1); break; }
                            case " oreal": { res1 = oreal.trunc(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.trunc(x1); break; }
                            case " zreal": { res1 = zreal.trunc(x1); break; }
                            case " creal": { res1 = creal.trunc(x1); break; }
                            case " mreal": { res1 = mreal.trunc(x1); break; }
                            case "sflint": { res1 = sflint.trunc(x1); break; }
                            case "dflint": { res1 = dflint.trunc(x1); break; }
                            case "eflint": { res1 = eflint.trunc(x1); break; }
                            case "qflint": { res1 = qflint.trunc(x1); break; }
                            case "oflint": { res1 = oflint.trunc(x1); break; }
                            case "cflint": { res1 = cflint.trunc(x1); break; }
                            case "mflint": { res1 = mflint.trunc(x1); break; }
                            case "iflint": { res1 = iflint.trunc(x1); break; }
                            case "aflint": { res1 = aflint.trunc(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: trunc({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("round"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.round(x1); break; }
                            case " sreal": { res1 = sreal.round(x1); break; }
                            case " dreal": { res1 = dreal.round(x1); break; }
                            case " ereal": { res1 = ereal.round(x1); break; }
                            case " qreal": { res1 = qreal.round(x1); break; }
                            case " oreal": { res1 = oreal.round(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.round(x1); break; }
                            case " zreal": { res1 = zreal.round(x1); break; }
                            case " creal": { res1 = creal.round(x1); break; }
                            case " mreal": { res1 = mreal.round(x1); break; }
                            case "sflint": { res1 = sflint.round(x1); break; }
                            case "dflint": { res1 = dflint.round(x1); break; }
                            case "eflint": { res1 = eflint.round(x1); break; }
                            case "qflint": { res1 = qflint.round(x1); break; }
                            case "oflint": { res1 = oflint.round(x1); break; }
                            case "cflint": { res1 = cflint.round(x1); break; }
                            case "mflint": { res1 = mflint.round(x1); break; }
                            case "iflint": { res1 = iflint.round(x1); break; }
                            case "aflint": { res1 = aflint.round(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: round({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("lround"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.lround(x1); break; }
                            case " sreal": { res1 = sreal.lround(x1); break; }
                            case " dreal": { res1 = dreal.lround(x1); break; }
                            case " ereal": { res1 = ereal.lround(x1); break; }
                            case " qreal": { res1 = qreal.lround(x1); break; }
                            case " oreal": { res1 = oreal.lround(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.lround(x1); break; }
                            case " zreal": { res1 = zreal.lround(x1); break; }
                            case " creal": { res1 = creal.lround(x1); break; }
                            case " mreal": { res1 = mreal.lround(x1); break; }
                            case "sflint": { res1 = sflint.lround(x1); break; }
                            case "dflint": { res1 = dflint.lround(x1); break; }
                            case "eflint": { res1 = eflint.lround(x1); break; }
                            case "qflint": { res1 = qflint.lround(x1); break; }
                            case "oflint": { res1 = oflint.lround(x1); break; }
                            case "cflint": { res1 = cflint.lround(x1); break; }
                            case "mflint": { res1 = mflint.lround(x1); break; }
                            case "iflint": { res1 = iflint.lround(x1); break; }
                            case "aflint": { res1 = aflint.lround(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: lround({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("llround"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.llround(x1); break; }
                            case " sreal": { res1 = sreal.llround(x1); break; }
                            case " dreal": { res1 = dreal.llround(x1); break; }
                            case " ereal": { res1 = ereal.llround(x1); break; }
                            case " qreal": { res1 = qreal.llround(x1); break; }
                            case " oreal": { res1 = oreal.llround(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.llround(x1); break; }
                            case " zreal": { res1 = zreal.llround(x1); break; }
                            case " creal": { res1 = creal.llround(x1); break; }
                            case " mreal": { res1 = mreal.llround(x1); break; }
                            case "sflint": { res1 = sflint.llround(x1); break; }
                            case "dflint": { res1 = dflint.llround(x1); break; }
                            case "eflint": { res1 = eflint.llround(x1); break; }
                            case "qflint": { res1 = qflint.llround(x1); break; }
                            case "oflint": { res1 = oflint.llround(x1); break; }
                            case "cflint": { res1 = cflint.llround(x1); break; }
                            case "mflint": { res1 = mflint.llround(x1); break; }
                            case "iflint": { res1 = iflint.llround(x1); break; }
                            case "aflint": { res1 = aflint.llround(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: llround({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }





            #endregion





            #region Floating point functions for real numbers


            if (FunctionArray.Contains("all") | FunctionArray.Contains("copysign"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.copysign(x, y); break; }
                                case " sreal": { res1 = sreal.copysign(x, y); break; }
                                case " dreal": { res1 = dreal.copysign(x, y); break; }
                                case " ereal": { res1 = ereal.copysign(x, y); break; }
                                case " qreal": { res1 = qreal.copysign(x, y); break; }
                                case " oreal": { res1 = oreal.copysign(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.copysign(x, y); break; }
                                case " zreal": { res1 = zreal.copysign(x, y); break; }
                                case " creal": { res1 = creal.copysign(x, y); break; }
                                case " mreal": { res1 = mreal.copysign(x, y); break; }
                                case "sflint": { res1 = sflint.copysign(x, y); break; }
                                case "dflint": { res1 = dflint.copysign(x, y); break; }
                                case "eflint": { res1 = eflint.copysign(x, y); break; }
                                case "qflint": { res1 = qflint.copysign(x, y); break; }
                                case "oflint": { res1 = oflint.copysign(x, y); break; }
                                case "cflint": { res1 = cflint.copysign(x, y); break; }
                                case "mflint": { res1 = mflint.copysign(x, y); break; }
                                case "iflint": { res1 = iflint.copysign(x, y); break; }
                                case "aflint": { res1 = aflint.copysign(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: copysign({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("frexp"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.frexp(x1); break; }
                            case " sreal": { res1 = sreal.frexp(x1); break; }
                            case " dreal": { res1 = dreal.frexp(x1); break; }
                            case " ereal": { res1 = ereal.frexp(x1); break; }
                            case " qreal": { res1 = qreal.frexp(x1); break; }
                            case " oreal": { res1 = oreal.frexp(x1); break; }
#if HasArbPrecNet
                            //case " yreal": { res1 = yreal.frexp(x1); break; }
                            //case " zreal": { res1 = zreal.frexp(x1); break; }
                            //case " creal": { res1 = creal.frexp(x1); break; }
                            case " mreal": { res1 = mreal.frexp(x1); break; }
                            case "sflint": { res1 = sflint.frexp(x1); break; }
                            case "dflint": { res1 = dflint.frexp(x1); break; }
                            case "eflint": { res1 = eflint.frexp(x1); break; }
                            case "qflint": { res1 = qflint.frexp(x1); break; }
                            case "oflint": { res1 = oflint.frexp(x1); break; }
                            //case "cflint": { res1 = cflint.frexp(x1); break; }
                            //case "mflint": { res1 = mflint.frexp(x1); break; }
                            //case "iflint": { res1 = iflint.frexp(x1); break; }
                            //case "aflint": { res1 = aflint.frexp(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: frexp({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("logb"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.logb(x1); break; }
                            case " sreal": { res1 = sreal.logb(x1); break; }
                            case " dreal": { res1 = dreal.logb(x1); break; }
                            case " ereal": { res1 = ereal.logb(x1); break; }
                            case " qreal": { res1 = qreal.logb(x1); break; }
                            case " oreal": { res1 = oreal.logb(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.logb(x1); break; }
                            case " zreal": { res1 = zreal.logb(x1); break; }
                            //case " creal": { res1 = creal.logb(x1); break; }
                            case " mreal": { res1 = mreal.logb(x1); break; }
                            case "sflint": { res1 = sflint.logb(x1); break; }
                            case "dflint": { res1 = dflint.logb(x1); break; }
                            case "eflint": { res1 = eflint.logb(x1); break; }
                            case "qflint": { res1 = qflint.logb(x1); break; }
                            case "oflint": { res1 = oflint.logb(x1); break; }
                            //case "cflint": { res1 = cflint.logb(x1); break; }
                            case "mflint": { res1 = mflint.logb(x1); break; }
                            case "iflint": { res1 = iflint.logb(x1); break; }
                            case "aflint": { res1 = aflint.logb(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: logb({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ilogb"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.ilogb(x1); break; }
                            case " sreal": { res1 = sreal.ilogb(x1); break; }
                            case " dreal": { res1 = dreal.ilogb(x1); break; }
                            case " ereal": { res1 = ereal.ilogb(x1); break; }
                            case " qreal": { res1 = qreal.ilogb(x1); break; }
                            case " oreal": { res1 = oreal.ilogb(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.ilogb(x1); break; }
                            case " zreal": { res1 = zreal.ilogb(x1); break; }
                            //case " creal": { res1 = creal.ilogb(x1); break; }
                            case " mreal": { res1 = mreal.ilogb(x1); break; }
                            case "sflint": { res1 = sflint.ilogb(x1); break; }
                            case "dflint": { res1 = dflint.ilogb(x1); break; }
                            case "eflint": { res1 = eflint.ilogb(x1); break; }
                            case "qflint": { res1 = qflint.ilogb(x1); break; }
                            case "oflint": { res1 = oflint.ilogb(x1); break; }
                            //case "cflint": { res1 = cflint.ilogb(x1); break; }
                            case "mflint": { res1 = mflint.ilogb(x1); break; }
                            //case "iflint": { res1 = iflint.ilogb(x1); break; }
                            //case "aflint": { res1 = aflint.ilogb(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: ilogb({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ldexp"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                InputArrayInt1 = new[] { -2, 0, 4 };
                foreach (var x1 in InputArray1)
                {
                    foreach (var e in InputArray1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.ldexp(x1, e); break; }
                                case " sreal": { res1 = sreal.ldexp(x1, e); break; }
                                case " dreal": { res1 = dreal.ldexp(x1, e); break; }
                                case " ereal": { res1 = ereal.ldexp(x1, e); break; }
                                case " qreal": { res1 = qreal.ldexp(x1, e); break; }
                                case " oreal": { res1 = oreal.ldexp(x1, e); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.ldexp(x1, e); break; }
                                case " zreal": { res1 = zreal.ldexp(x1, e); break; }
                                case " creal": { res1 = creal.ldexp(x1, e); break; }
                                case " mreal": { res1 = mreal.ldexp(x1, e); break; }
                                case "sflint": { res1 = sflint.ldexp(x1, e); break; }
                                case "dflint": { res1 = dflint.ldexp(x1, e); break; }
                                case "eflint": { res1 = eflint.ldexp(x1, e); break; }
                                case "qflint": { res1 = qflint.ldexp(x1, e); break; }
                                case "oflint": { res1 = oflint.ldexp(x1, e); break; }
                                case "cflint": { res1 = cflint.ldexp(x1, e); break; }
                                case "mflint": { res1 = mflint.ldexp(x1, e); break; }
                                case "iflint": { res1 = iflint.ldexp(x1, e); break; }
                                case "aflint": { res1 = aflint.ldexp(x1, e); break; }
#endif
                            }
                            Console.WriteLine("{0}: ldexp({1}, {2}): " + f(NumType) + "{3}", NumType, x1, e, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("scalbn"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                InputArrayInt1 = new[] { -2, 0, 4 };
                foreach (var x1 in InputArray1)
                {
                    foreach (var e in InputArrayInt1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.scalbn(x1, e); break; }
                                case " sreal": { res1 = sreal.scalbn(x1, e); break; }
                                case " dreal": { res1 = dreal.scalbn(x1, e); break; }
                                case " ereal": { res1 = ereal.scalbn(x1, e); break; }
                                case " qreal": { res1 = qreal.scalbn(x1, e); break; }
                                case " oreal": { res1 = oreal.scalbn(x1, e); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.scalbn(x1, e); break; }
                                case " zreal": { res1 = zreal.scalbn(x1, e); break; }
                                //case " creal": { res1 = creal.scalbn(x1, e); break; }
                                case " mreal": { res1 = mreal.scalbn(x1, e); break; }
                                case "sflint": { res1 = sflint.scalbn(x1, e); break; }
                                case "dflint": { res1 = dflint.scalbn(x1, e); break; }
                                case "eflint": { res1 = eflint.scalbn(x1, e); break; }
                                case "qflint": { res1 = qflint.scalbn(x1, e); break; }
                                case "oflint": { res1 = oflint.scalbn(x1, e); break; }
                                //case "cflint": { res1 = cflint.scalbn(x1, e); break; }
                                case "mflint": { res1 = mflint.scalbn(x1, e); break; }
                                //case "iflint": { res1 = iflint.scalbn(x1, e); break; }
                                //case "aflint": { res1 = aflint.scalbn(x1, e); break; }
#endif
                            }
                            Console.WriteLine("{0}: scalbn({1}, {2}): " + f(NumType) + "{3}", NumType, x1, e, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("scalbln"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                InputArrayInt1 = new[] { -2, 0, 4 };
                foreach (var x1 in InputArray1)
                {
                    foreach (var e in InputArrayInt1)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.scalbln(x1, e); break; }
                                case " sreal": { res1 = sreal.scalbln(x1, e); break; }
                                case " dreal": { res1 = dreal.scalbln(x1, e); break; }
                                case " ereal": { res1 = ereal.scalbln(x1, e); break; }
                                case " qreal": { res1 = qreal.scalbln(x1, e); break; }
                                case " oreal": { res1 = oreal.scalbln(x1, e); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.scalbln(x1, e); break; }
                                case " zreal": { res1 = zreal.scalbln(x1, e); break; }
                                //case " creal": { res1 = creal.scalbln(x1, e); break; }
                                case " mreal": { res1 = mreal.scalbln(x1, e); break; }
                                case "sflint": { res1 = sflint.scalbln(x1, e); break; }
                                case "dflint": { res1 = dflint.scalbln(x1, e); break; }
                                case "eflint": { res1 = eflint.scalbln(x1, e); break; }
                                case "qflint": { res1 = qflint.scalbln(x1, e); break; }
                                case "oflint": { res1 = oflint.scalbln(x1, e); break; }
                                //case "cflint": { res1 = cflint.scalbln(x1, e); break; }
                                case "mflint": { res1 = mflint.scalbln(x1, e); break; }
                                //case "iflint": { res1 = iflint.scalbln(x1, e); break; }
                                //case "aflint": { res1 = aflint.scalbln(x1, e); break; }
#endif
                            }
                            Console.WriteLine("{0}: scalbln({1}, {2}): " + f(NumType) + "{3}", NumType, x1, e, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("fdim"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.fdim(x, y); break; }
                                case " sreal": { res1 = sreal.fdim(x, y); break; }
                                case " dreal": { res1 = dreal.fdim(x, y); break; }
                                case " ereal": { res1 = ereal.fdim(x, y); break; }
                                case " qreal": { res1 = qreal.fdim(x, y); break; }
                                case " oreal": { res1 = oreal.fdim(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.fdim(x, y); break; }
                                case " zreal": { res1 = zreal.fdim(x, y); break; }
                                case " creal": { res1 = creal.fdim(x, y); break; }
                                case " mreal": { res1 = mreal.fdim(x, y); break; }
                                case "sflint": { res1 = sflint.fdim(x, y); break; }
                                case "dflint": { res1 = dflint.fdim(x, y); break; }
                                case "eflint": { res1 = eflint.fdim(x, y); break; }
                                case "qflint": { res1 = qflint.fdim(x, y); break; }
                                case "oflint": { res1 = oflint.fdim(x, y); break; }
                                case "cflint": { res1 = cflint.fdim(x, y); break; }
                                case "mflint": { res1 = mflint.fdim(x, y); break; }
                                case "iflint": { res1 = iflint.fdim(x, y); break; }
                                case "aflint": { res1 = aflint.fdim(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: fdim({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion




            #region Fraction and remainder related Functions



            if (FunctionArray.Contains("all") | FunctionArray.Contains("modf"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.modf(x1); break; }
                            case " sreal": { res1 = sreal.modf(x1); break; }
                            case " dreal": { res1 = dreal.modf(x1); break; }
                            case " ereal": { res1 = ereal.modf(x1); break; }
                            case " qreal": { res1 = qreal.modf(x1); break; }
                            case " oreal": { res1 = oreal.modf(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.modf(x1); break; }
                            case " zreal": { res1 = zreal.modf(x1); break; }
                            case " creal": { res1 = creal.modf(x1); break; }
                            case " mreal": { res1 = mreal.modf(x1); break; }
                            case "sflint": { res1 = sflint.modf(x1); break; }
                            case "dflint": { res1 = dflint.modf(x1); break; }
                            case "eflint": { res1 = eflint.modf(x1); break; }
                            case "qflint": { res1 = qflint.modf(x1); break; }
                            case "oflint": { res1 = oflint.modf(x1); break; }
                            case "cflint": { res1 = cflint.modf(x1); break; }
                            case "mflint": { res1 = mflint.modf(x1); break; }
                            //case "iflint": { res1 = iflint.modf(x1); break; }
                            //case "aflint": { res1 = aflint.modf(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: modf({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("fmod"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.fmod(x, y); break; }
                                case " sreal": { res1 = sreal.fmod(x, y); break; }
                                case " dreal": { res1 = dreal.fmod(x, y); break; }
                                case " ereal": { res1 = ereal.fmod(x, y); break; }
                                case " qreal": { res1 = qreal.fmod(x, y); break; }
                                case " oreal": { res1 = oreal.fmod(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.fmod(x, y); break; }
                                case " zreal": { res1 = zreal.fmod(x, y); break; }
                                //case " creal": { res1 = creal.fmod(x, y); break; }
                                case " mreal": { res1 = mreal.fmod(x, y); break; }
                                case "sflint": { res1 = sflint.fmod(x, y); break; }
                                case "dflint": { res1 = dflint.fmod(x, y); break; }
                                case "eflint": { res1 = eflint.fmod(x, y); break; }
                                case "qflint": { res1 = qflint.fmod(x, y); break; }
                                case "oflint": { res1 = oflint.fmod(x, y); break; }
                                //case "cflint": { res1 = cflint.fmod(x, y); break; }
                                case "mflint": { res1 = mflint.fmod(x, y); break; }
                                //case "iflint": { res1 = iflint.fmod(x, y); break; }
                                //case "aflint": { res1 = aflint.fmod(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: fmod({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("remainder"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.remainder(x, y); break; }
                                case " sreal": { res1 = sreal.remainder(x, y); break; }
                                case " dreal": { res1 = dreal.remainder(x, y); break; }
                                case " ereal": { res1 = ereal.remainder(x, y); break; }
                                case " qreal": { res1 = qreal.remainder(x, y); break; }
                                case " oreal": { res1 = oreal.remainder(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.remainder(x, y); break; }
                                case " zreal": { res1 = zreal.remainder(x, y); break; }
                                //case " creal": { res1 = creal.remainder(x, y); break; }
                                case " mreal": { res1 = mreal.remainder(x, y); break; }
                                case "sflint": { res1 = sflint.remainder(x, y); break; }
                                case "dflint": { res1 = dflint.remainder(x, y); break; }
                                case "eflint": { res1 = eflint.remainder(x, y); break; }
                                case "qflint": { res1 = qflint.remainder(x, y); break; }
                                case "oflint": { res1 = oflint.remainder(x, y); break; }
                                //case "cflint": { res1 = cflint.remainder(x, y); break; }
                                case "mflint": { res1 = mflint.remainder(x, y); break; }
                                //case "iflint": { res1 = iflint.remainder(x, y); break; }
                                //case "aflint": { res1 = aflint.remainder(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: remainder({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("remquo"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.remquo(x, y); break; }
                                case " sreal": { res1 = sreal.remquo(x, y); break; }
                                case " dreal": { res1 = dreal.remquo(x, y); break; }
                                case " ereal": { res1 = ereal.remquo(x, y); break; }
                                case " qreal": { res1 = qreal.remquo(x, y); break; }
                                case " oreal": { res1 = oreal.remquo(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.remquo(x, y); break; }
                                case " zreal": { res1 = zreal.remquo(x, y); break; }
                                //case " creal": { res1 = creal.remquo(x, y); break; }
                                case " mreal": { res1 = mreal.remquo(x, y); break; }
                                case "sflint": { res1 = sflint.remquo(x, y); break; }
                                case "dflint": { res1 = dflint.remquo(x, y); break; }
                                case "eflint": { res1 = eflint.remquo(x, y); break; }
                                case "qflint": { res1 = qflint.remquo(x, y); break; }
                                case "oflint": { res1 = oflint.remquo(x, y); break; }
                                //case "cflint": { res1 = cflint.remquo(x, y); break; }
                                //case "mflint": { res1 = mflint.remquo(x, y); break; }
                                //case "iflint": { res1 = iflint.remquo(x, y); break; }
                                //case "aflint": { res1 = aflint.remquo(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: remquo({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion





            #region Functions related to mantissa width and exponent range


            if (FunctionArray.Contains("all") | FunctionArray.Contains("epsilon"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.epsilon(); break; }
                        case " sreal": { res1 = sreal.epsilon(); break; }
                        case " dreal": { res1 = dreal.epsilon(); break; }
                        case " ereal": { res1 = ereal.epsilon(); break; }
                        case " qreal": { res1 = qreal.epsilon(); break; }
                        case " oreal": { res1 = oreal.epsilon(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.epsilon(); break; }
                        case " zreal": { res1 = zreal.epsilon(); break; }
                        case " creal": { res1 = creal.epsilon(); break; }
                        case " mreal": { res1 = mreal.epsilon(); break; }
                        case "sflint": { res1 = sflint.epsilon(); break; }
                        case "dflint": { res1 = dflint.epsilon(); break; }
                        case "eflint": { res1 = eflint.epsilon(); break; }
                        case "qflint": { res1 = qflint.epsilon(); break; }
                        case "oflint": { res1 = oflint.epsilon(); break; }
                        case "cflint": { res1 = cflint.epsilon(); break; }
                        case "mflint": { res1 = mflint.epsilon(); break; }
                        case "iflint": { res1 = iflint.epsilon(); break; }
                        case "aflint": { res1 = aflint.epsilon(); break; }
#endif
                    }
                    Console.WriteLine("{0}: epsilon(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ulp"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.ulp(x1); break; }
                            case " sreal": { res1 = sreal.ulp(x1); break; }
                            case " dreal": { res1 = dreal.ulp(x1); break; }
                            case " ereal": { res1 = ereal.ulp(x1); break; }
                            case " qreal": { res1 = qreal.ulp(x1); break; }
                            case " oreal": { res1 = oreal.ulp(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.ulp(x1); break; }
                            case " zreal": { res1 = zreal.ulp(x1); break; }
                            //case " creal": { res1 = creal.ulp(x1); break; }
                            case " mreal": { res1 = mreal.ulp(x1); break; }
                            case "sflint": { res1 = sflint.ulp(x1); break; }
                            case "dflint": { res1 = dflint.ulp(x1); break; }
                            case "eflint": { res1 = eflint.ulp(x1); break; }
                            case "qflint": { res1 = qflint.ulp(x1); break; }
                            case "oflint": { res1 = oflint.ulp(x1); break; }
                            //case "cflint": { res1 = cflint.ulp(x1); break; }
                            //case "mflint": { res1 = mflint.ulp(x1); break; }
                            //case "iflint": { res1 = iflint.ulp(x1); break; }
                            //case "aflint": { res1 = aflint.ulp(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: ulp({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("maxvalue"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.maxvalue(); break; }
                        case " sreal": { res1 = sreal.maxvalue(); break; }
                        case " dreal": { res1 = dreal.maxvalue(); break; }
                        case " ereal": { res1 = ereal.maxvalue(); break; }
                        case " qreal": { res1 = qreal.maxvalue(); break; }
                        case " oreal": { res1 = oreal.maxvalue(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.maxvalue(); break; }
                        case " zreal": { res1 = zreal.maxvalue(); break; }
                        case " creal": { res1 = creal.maxvalue(); break; }
                        case " mreal": { res1 = mreal.maxvalue(); break; }
                        case "sflint": { res1 = sflint.maxvalue(); break; }
                        case "dflint": { res1 = dflint.maxvalue(); break; }
                        case "eflint": { res1 = eflint.maxvalue(); break; }
                        case "qflint": { res1 = qflint.maxvalue(); break; }
                        case "oflint": { res1 = oflint.maxvalue(); break; }
                        case "cflint": { res1 = cflint.maxvalue(); break; }
                        case "mflint": { res1 = mflint.maxvalue(); break; }
                        case "iflint": { res1 = iflint.maxvalue(); break; }
                        case "aflint": { res1 = aflint.maxvalue(); break; }
#endif
                    }
                    Console.WriteLine("{0}: maxvalue(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("lowestvalue"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.lowestvalue(); break; }
                        case " sreal": { res1 = sreal.lowestvalue(); break; }
                        case " dreal": { res1 = dreal.lowestvalue(); break; }
                        case " ereal": { res1 = ereal.lowestvalue(); break; }
                        case " qreal": { res1 = qreal.lowestvalue(); break; }
                        case " oreal": { res1 = oreal.lowestvalue(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.lowestvalue(); break; }
                        case " zreal": { res1 = zreal.lowestvalue(); break; }
                        case " creal": { res1 = creal.lowestvalue(); break; }
                        case " mreal": { res1 = mreal.lowestvalue(); break; }
                        case "sflint": { res1 = sflint.lowestvalue(); break; }
                        case "dflint": { res1 = dflint.lowestvalue(); break; }
                        case "eflint": { res1 = eflint.lowestvalue(); break; }
                        case "qflint": { res1 = qflint.lowestvalue(); break; }
                        case "oflint": { res1 = oflint.lowestvalue(); break; }
                        case "cflint": { res1 = cflint.lowestvalue(); break; }
                        case "mflint": { res1 = mflint.lowestvalue(); break; }
                        case "iflint": { res1 = iflint.lowestvalue(); break; }
                        case "aflint": { res1 = aflint.lowestvalue(); break; }
#endif
                    }
                    Console.WriteLine("{0}: lowestvalue(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("minposvalue"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.minposvalue(); break; }
                        case " sreal": { res1 = sreal.minposvalue(); break; }
                        case " dreal": { res1 = dreal.minposvalue(); break; }
                        case " ereal": { res1 = ereal.minposvalue(); break; }
                        case " qreal": { res1 = qreal.minposvalue(); break; }
                        case " oreal": { res1 = oreal.minposvalue(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.minposvalue(); break; }
                        case " zreal": { res1 = zreal.minposvalue(); break; }
                        case " creal": { res1 = creal.minposvalue(); break; }
                        case " mreal": { res1 = mreal.minposvalue(); break; }
                        case "sflint": { res1 = sflint.minposvalue(); break; }
                        case "dflint": { res1 = dflint.minposvalue(); break; }
                        case "eflint": { res1 = eflint.minposvalue(); break; }
                        case "qflint": { res1 = qflint.minposvalue(); break; }
                        case "oflint": { res1 = oflint.minposvalue(); break; }
                        case "cflint": { res1 = cflint.minposvalue(); break; }
                        case "mflint": { res1 = mflint.minposvalue(); break; }
                        case "iflint": { res1 = iflint.minposvalue(); break; }
                        case "aflint": { res1 = aflint.minposvalue(); break; }
#endif
                    }
                    Console.WriteLine("{0}: minposvalue(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("nextafter"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.nextafter(x, y); break; }
                                case " sreal": { res1 = sreal.nextafter(x, y); break; }
                                case " dreal": { res1 = dreal.nextafter(x, y); break; }
                                case " ereal": { res1 = ereal.nextafter(x, y); break; }
                                case " qreal": { res1 = qreal.nextafter(x, y); break; }
                                case " oreal": { res1 = oreal.nextafter(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.nextafter(x, y); break; }
                                case " zreal": { res1 = zreal.nextafter(x, y); break; }
                                //case " creal": { res1 = creal.nextafter(x, y); break; }
                                case " mreal": { res1 = mreal.nextafter(x, y); break; }
                                case "sflint": { res1 = sflint.nextafter(x, y); break; }
                                case "dflint": { res1 = dflint.nextafter(x, y); break; }
                                case "eflint": { res1 = eflint.nextafter(x, y); break; }
                                case "qflint": { res1 = qflint.nextafter(x, y); break; }
                                case "oflint": { res1 = oflint.nextafter(x, y); break; }
                                //case "cflint": { res1 = cflint.nextafter(x, y); break; }
                                //case "mflint": { res1 = mflint.nextafter(x, y); break; }
                                //case "iflint": { res1 = iflint.nextafter(x, y); break; }
                                //case "aflint": { res1 = aflint.nextafter(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: nextafter({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("nextabove"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.nextabove(x1); break; }
                            case " sreal": { res1 = sreal.nextabove(x1); break; }
                            case " dreal": { res1 = dreal.nextabove(x1); break; }
                            case " ereal": { res1 = ereal.nextabove(x1); break; }
                            case " qreal": { res1 = qreal.nextabove(x1); break; }
                            case " oreal": { res1 = oreal.nextabove(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.nextabove(x1); break; }
                            case " zreal": { res1 = zreal.nextabove(x1); break; }
                            case " creal": { res1 = creal.nextabove(x1); break; }
                            case " mreal": { res1 = mreal.nextabove(x1); break; }
                            case "sflint": { res1 = sflint.nextabove(x1); break; }
                            case "dflint": { res1 = dflint.nextabove(x1); break; }
                            case "eflint": { res1 = eflint.nextabove(x1); break; }
                            case "qflint": { res1 = qflint.nextabove(x1); break; }
                            case "oflint": { res1 = oflint.nextabove(x1); break; }
                            case "cflint": { res1 = cflint.nextabove(x1); break; }
                            case "mflint": { res1 = mflint.nextabove(x1); break; }
                            case "iflint": { res1 = iflint.nextabove(x1); break; }
                            //case "aflint": { res1 = aflint.nextabove(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: nextabove({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("nextbelow"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.nextbelow(x1); break; }
                            case " sreal": { res1 = sreal.nextbelow(x1); break; }
                            case " dreal": { res1 = dreal.nextbelow(x1); break; }
                            case " ereal": { res1 = ereal.nextbelow(x1); break; }
                            case " qreal": { res1 = qreal.nextbelow(x1); break; }
                            case " oreal": { res1 = oreal.nextbelow(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.nextbelow(x1); break; }
                            case " zreal": { res1 = zreal.nextbelow(x1); break; }
                            case " creal": { res1 = creal.nextbelow(x1); break; }
                            case " mreal": { res1 = mreal.nextbelow(x1); break; }
                            case "sflint": { res1 = sflint.nextbelow(x1); break; }
                            case "dflint": { res1 = dflint.nextbelow(x1); break; }
                            case "eflint": { res1 = eflint.nextbelow(x1); break; }
                            case "qflint": { res1 = qflint.nextbelow(x1); break; }
                            case "oflint": { res1 = oflint.nextbelow(x1); break; }
                            case "cflint": { res1 = cflint.nextbelow(x1); break; }
                            case "mflint": { res1 = mflint.nextbelow(x1); break; }
                            case "iflint": { res1 = iflint.nextbelow(x1); break; }
                            //case "aflint": { res1 = aflint.nextbelow(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: nextbelow({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }




            #endregion





            #region Mathematical Constants


            if (FunctionArray.Contains("all") | FunctionArray.Contains("degree"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.degree(); break; }
                        case " sreal": { res1 = sreal.degree(); break; }
                        case " dreal": { res1 = dreal.degree(); break; }
                        case " ereal": { res1 = ereal.degree(); break; }
                        case " qreal": { res1 = qreal.degree(); break; }
                        case " oreal": { res1 = oreal.degree(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.degree(); break; }
                        case " zreal": { res1 = zreal.degree(); break; }
                        //case " creal": { res1 = creal.degree(); break; }
                        case " mreal": { res1 = mreal.degree(); break; }
                        case "sflint": { res1 = sflint.degree(); break; }
                        case "dflint": { res1 = dflint.degree(); break; }
                        case "eflint": { res1 = eflint.degree(); break; }
                        case "qflint": { res1 = qflint.degree(); break; }
                        case "oflint": { res1 = oflint.degree(); break; }
                        //case "cflint": { res1 = cflint.degree(); break; }
                        case "mflint": { res1 = mflint.degree(); break; }
                        case "iflint": { res1 = iflint.degree(); break; }
                        case "aflint": { res1 = aflint.degree(); break; }
#endif
                    }
                    Console.WriteLine("{0}: degree(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("phi"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.phi(); break; }
                        case " sreal": { res1 = sreal.phi(); break; }
                        case " dreal": { res1 = dreal.phi(); break; }
                        case " ereal": { res1 = ereal.phi(); break; }
                        case " qreal": { res1 = qreal.phi(); break; }
                        case " oreal": { res1 = oreal.phi(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.phi(); break; }
                        case " zreal": { res1 = zreal.phi(); break; }
                        //case " creal": { res1 = creal.phi(); break; }
                        case " mreal": { res1 = mreal.phi(); break; }
                        case "sflint": { res1 = sflint.phi(); break; }
                        case "dflint": { res1 = dflint.phi(); break; }
                        case "eflint": { res1 = eflint.phi(); break; }
                        case "qflint": { res1 = qflint.phi(); break; }
                        case "oflint": { res1 = oflint.phi(); break; }
                        //case "cflint": { res1 = cflint.phi(); break; }
                        case "mflint": { res1 = mflint.phi(); break; }
                        case "iflint": { res1 = iflint.phi(); break; }
                        case "aflint": { res1 = aflint.phi(); break; }
#endif
                    }
                    Console.WriteLine("{0}: phi(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ln2"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.ln2(); break; }
                        case " sreal": { res1 = sreal.ln2(); break; }
                        case " dreal": { res1 = dreal.ln2(); break; }
                        case " ereal": { res1 = ereal.ln2(); break; }
                        case " qreal": { res1 = qreal.ln2(); break; }
                        case " oreal": { res1 = oreal.ln2(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.ln2(); break; }
                        case " zreal": { res1 = zreal.ln2(); break; }
                        //case " creal": { res1 = creal.ln2(); break; }
                        case " mreal": { res1 = mreal.ln2(); break; }
                        case "sflint": { res1 = sflint.ln2(); break; }
                        case "dflint": { res1 = dflint.ln2(); break; }
                        case "eflint": { res1 = eflint.ln2(); break; }
                        case "qflint": { res1 = qflint.ln2(); break; }
                        case "oflint": { res1 = oflint.ln2(); break; }
                        //case "cflint": { res1 = cflint.ln2(); break; }
                        case "mflint": { res1 = mflint.ln2(); break; }
                        case "iflint": { res1 = iflint.ln2(); break; }
                        case "aflint": { res1 = aflint.ln2(); break; }
#endif
                    }
                    Console.WriteLine("{0}: ln2(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ln10"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.ln10(); break; }
                        case " sreal": { res1 = sreal.ln10(); break; }
                        case " dreal": { res1 = dreal.ln10(); break; }
                        case " ereal": { res1 = ereal.ln10(); break; }
                        case " qreal": { res1 = qreal.ln10(); break; }
                        case " oreal": { res1 = oreal.ln10(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.ln10(); break; }
                        case " zreal": { res1 = zreal.ln10(); break; }
                        //case " creal": { res1 = creal.ln10(); break; }
                        case " mreal": { res1 = mreal.ln10(); break; }
                        case "sflint": { res1 = sflint.ln10(); break; }
                        case "dflint": { res1 = dflint.ln10(); break; }
                        case "eflint": { res1 = eflint.ln10(); break; }
                        case "qflint": { res1 = qflint.ln10(); break; }
                        case "oflint": { res1 = oflint.ln10(); break; }
                        //case "cflint": { res1 = cflint.ln10(); break; }
                        case "mflint": { res1 = mflint.ln10(); break; }
                        case "iflint": { res1 = iflint.ln10(); break; }
                        case "aflint": { res1 = aflint.ln10(); break; }
#endif
                    }
                    Console.WriteLine("{0}: ln10(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pi"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.pi(); break; }
                        case " sreal": { res1 = sreal.pi(); break; }
                        case " dreal": { res1 = dreal.pi(); break; }
                        case " ereal": { res1 = ereal.pi(); break; }
                        case " qreal": { res1 = qreal.pi(); break; }
                        case " oreal": { res1 = oreal.pi(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.pi(); break; }
                        case " zreal": { res1 = zreal.pi(); break; }
                        //case " creal": { res1 = creal.pi(); break; }
                        case " mreal": { res1 = mreal.pi(); break; }
                        case "sflint": { res1 = sflint.pi(); break; }
                        case "dflint": { res1 = dflint.pi(); break; }
                        case "eflint": { res1 = eflint.pi(); break; }
                        case "qflint": { res1 = qflint.pi(); break; }
                        case "oflint": { res1 = oflint.pi(); break; }
                        //case "cflint": { res1 = cflint.pi(); break; }
                        case "mflint": { res1 = mflint.pi(); break; }
                        case "iflint": { res1 = iflint.pi(); break; }
                        case "aflint": { res1 = aflint.pi(); break; }
#endif
                    }
                    Console.WriteLine("{0}: pi(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("e"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.e(); break; }
                        case " sreal": { res1 = sreal.e(); break; }
                        case " dreal": { res1 = dreal.e(); break; }
                        case " ereal": { res1 = ereal.e(); break; }
                        case " qreal": { res1 = qreal.e(); break; }
                        case " oreal": { res1 = oreal.e(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.e(); break; }
                        case " zreal": { res1 = zreal.e(); break; }
                        //case " creal": { res1 = creal.e(); break; }
                        case " mreal": { res1 = mreal.e(); break; }
                        case "sflint": { res1 = sflint.e(); break; }
                        case "dflint": { res1 = dflint.e(); break; }
                        case "eflint": { res1 = eflint.e(); break; }
                        case "qflint": { res1 = qflint.e(); break; }
                        case "oflint": { res1 = oflint.e(); break; }
                        //case "cflint": { res1 = cflint.e(); break; }
                        case "mflint": { res1 = mflint.e(); break; }
                        case "iflint": { res1 = iflint.e(); break; }
                        case "aflint": { res1 = aflint.e(); break; }
#endif
                    }
                    Console.WriteLine("{0}: e(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("egamma"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.egamma(); break; }
                        case " sreal": { res1 = sreal.egamma(); break; }
                        case " dreal": { res1 = dreal.egamma(); break; }
                        case " ereal": { res1 = ereal.egamma(); break; }
                        case " qreal": { res1 = qreal.egamma(); break; }
                        case " oreal": { res1 = oreal.egamma(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.egamma(); break; }
                        case " zreal": { res1 = zreal.egamma(); break; }
                        //case " creal": { res1 = creal.egamma(); break; }
                        case " mreal": { res1 = mreal.egamma(); break; }
                        case "sflint": { res1 = sflint.egamma(); break; }
                        case "dflint": { res1 = dflint.egamma(); break; }
                        case "eflint": { res1 = eflint.egamma(); break; }
                        case "qflint": { res1 = qflint.egamma(); break; }
                        case "oflint": { res1 = oflint.egamma(); break; }
                        //case "cflint": { res1 = cflint.egamma(); break; }
                        case "mflint": { res1 = mflint.egamma(); break; }
                        case "iflint": { res1 = iflint.egamma(); break; }
                        case "aflint": { res1 = aflint.egamma(); break; }
#endif
                    }
                    Console.WriteLine("{0}: egamma(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("egamma"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.apery(); break; }
                        case " sreal": { res1 = sreal.apery(); break; }
                        case " dreal": { res1 = dreal.apery(); break; }
                        case " ereal": { res1 = ereal.apery(); break; }
                        case " qreal": { res1 = qreal.apery(); break; }
                        case " oreal": { res1 = oreal.apery(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.apery(); break; }
                        case " zreal": { res1 = zreal.apery(); break; }
                        //case " creal": { res1 = creal.apery(); break; }
                        case " mreal": { res1 = mreal.apery(); break; }
                        case "sflint": { res1 = sflint.apery(); break; }
                        case "dflint": { res1 = dflint.apery(); break; }
                        case "eflint": { res1 = eflint.apery(); break; }
                        case "qflint": { res1 = qflint.apery(); break; }
                        case "oflint": { res1 = oflint.apery(); break; }
                        //case "cflint": { res1 = cflint.apery(); break; }
                        case "mflint": { res1 = mflint.apery(); break; }
                        case "iflint": { res1 = iflint.apery(); break; }
                        case "aflint": { res1 = aflint.apery(); break; }
#endif
                    }
                    Console.WriteLine("{0}: apery(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("catalan"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.catalan(); break; }
                        case " sreal": { res1 = sreal.catalan(); break; }
                        case " dreal": { res1 = dreal.catalan(); break; }
                        case " ereal": { res1 = ereal.catalan(); break; }
                        case " qreal": { res1 = qreal.catalan(); break; }
                        case " oreal": { res1 = oreal.catalan(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.catalan(); break; }
                        case " zreal": { res1 = zreal.catalan(); break; }
                        //case " creal": { res1 = creal.catalan(); break; }
                        case " mreal": { res1 = mreal.catalan(); break; }
                        case "sflint": { res1 = sflint.catalan(); break; }
                        case "dflint": { res1 = dflint.catalan(); break; }
                        case "eflint": { res1 = eflint.catalan(); break; }
                        case "qflint": { res1 = qflint.catalan(); break; }
                        case "oflint": { res1 = oflint.catalan(); break; }
                        //case "cflint": { res1 = cflint.catalan(); break; }
                        case "mflint": { res1 = mflint.catalan(); break; }
                        case "iflint": { res1 = iflint.catalan(); break; }
                        case "aflint": { res1 = aflint.catalan(); break; }
#endif
                    }
                    Console.WriteLine("{0}: catalan(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("glaisher"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.glaisher(); break; }
                        case " sreal": { res1 = sreal.glaisher(); break; }
                        case " dreal": { res1 = dreal.glaisher(); break; }
                        case " ereal": { res1 = ereal.glaisher(); break; }
                        case " qreal": { res1 = qreal.glaisher(); break; }
                        case " oreal": { res1 = oreal.glaisher(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.glaisher(); break; }
                        case " zreal": { res1 = zreal.glaisher(); break; }
                        //case " creal": { res1 = creal.glaisher(); break; }
                        case " mreal": { res1 = mreal.glaisher(); break; }
                        case "sflint": { res1 = sflint.glaisher(); break; }
                        case "dflint": { res1 = dflint.glaisher(); break; }
                        case "eflint": { res1 = eflint.glaisher(); break; }
                        case "qflint": { res1 = qflint.glaisher(); break; }
                        case "oflint": { res1 = oflint.glaisher(); break; }
                        //case "cflint": { res1 = cflint.glaisher(); break; }
                        case "mflint": { res1 = mflint.glaisher(); break; }
                        case "iflint": { res1 = iflint.glaisher(); break; }
                        case "aflint": { res1 = aflint.glaisher(); break; }
#endif
                    }
                    Console.WriteLine("{0}: glaisher(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("khinchin"))
            {
                foreach (var NumType in NumTypeArray)
                {
                    object res1 = "Not done";
                    switch (NumType ?? "")
                    {
                        case "math53": { res1 = math53.khinchin(); break; }
                        case " sreal": { res1 = sreal.khinchin(); break; }
                        case " dreal": { res1 = dreal.khinchin(); break; }
                        case " ereal": { res1 = ereal.khinchin(); break; }
                        case " qreal": { res1 = qreal.khinchin(); break; }
                        case " oreal": { res1 = oreal.khinchin(); break; }
#if HasArbPrecNet
                        case " yreal": { res1 = yreal.khinchin(); break; }
                        case " zreal": { res1 = zreal.khinchin(); break; }
                        //case " creal": { res1 = creal.khinchin(); break; }
                        case " mreal": { res1 = mreal.khinchin(); break; }
                        case "sflint": { res1 = sflint.khinchin(); break; }
                        case "dflint": { res1 = dflint.khinchin(); break; }
                        case "eflint": { res1 = eflint.khinchin(); break; }
                        case "qflint": { res1 = qflint.khinchin(); break; }
                        case "oflint": { res1 = oflint.khinchin(); break; }
                        //case "cflint": { res1 = cflint.khinchin(); break; }
                        case "mflint": { res1 = mflint.khinchin(); break; }
                        case "iflint": { res1 = iflint.khinchin(); break; }
                        case "aflint": { res1 = aflint.khinchin(); break; }
#endif
                    }
                    Console.WriteLine("{0}: khinchin(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            #endregion





        }



        public static void DemoChapterElementary(string[] NumTypeArray, string[] FunctionArray)
        {
            double[] InputArray1;
            double[] InputArray2;
            int[] InputArrayInt1;


            #region Complex components



            if (FunctionArray.Contains("all") | FunctionArray.Contains("abs"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                double[] InputArray1a = { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.abs(x1); break; }
                            case " sreal": { res1 = sreal.abs(x1); break; }
                            case " dreal": { res1 = dreal.abs(x1); break; }
                            case " ereal": { res1 = ereal.abs(x1); break; }
                            case " qreal": { res1 = qreal.abs(x1); break; }
                            case " oreal": { res1 = oreal.abs(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.abs(x1); break; }
                            case " zreal": { res1 = zreal.abs(x1); break; }
                            case " creal": { res1 = creal.abs(x1); break; }
                            case " mreal": { res1 = mreal.abs(x1); break; }
                            case "sflint": { res1 = sflint.abs(x1); break; }
                            case "dflint": { res1 = dflint.abs(x1); break; }
                            case "eflint": { res1 = eflint.abs(x1); break; }
                            case "qflint": { res1 = qflint.abs(x1); break; }
                            case "oflint": { res1 = oflint.abs(x1); break; }
                            case "cflint": { res1 = cflint.abs(x1); break; }
                            case "mflint": { res1 = mflint.abs(x1); break; }
                            case "iflint": { res1 = iflint.abs(x1); break; }
                            case "aflint": { res1 = aflint.abs(x1); break; }
#endif
                        }

                        Console.WriteLine("{0}: abs({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("fabs"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.fabs(x1); break; }
                            case " sreal": { res1 = sreal.fabs(x1); break; }
                            case " dreal": { res1 = dreal.fabs(x1); break; }
                            case " ereal": { res1 = ereal.fabs(x1); break; }
                            case " qreal": { res1 = qreal.fabs(x1); break; }
                            case " oreal": { res1 = oreal.fabs(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.fabs(x1); break; }
                            case " zreal": { res1 = zreal.fabs(x1); break; }
                            case " creal": { res1 = creal.fabs(x1); break; }
                            case " mreal": { res1 = mreal.fabs(x1); break; }
                            case "sflint": { res1 = sflint.fabs(x1); break; }
                            case "dflint": { res1 = dflint.fabs(x1); break; }
                            case "eflint": { res1 = eflint.fabs(x1); break; }
                            case "qflint": { res1 = qflint.fabs(x1); break; }
                            case "oflint": { res1 = oflint.fabs(x1); break; }
                            case "cflint": { res1 = cflint.fabs(x1); break; }
                            case "mflint": { res1 = mflint.fabs(x1); break; }
                            case "iflint": { res1 = iflint.fabs(x1); break; }
                            case "aflint": { res1 = aflint.fabs(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: fabs({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("sign"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.sign(x1); break; }
                            case " sreal": { res1 = sreal.sign(x1); break; }
                            case " dreal": { res1 = dreal.sign(x1); break; }
                            case " ereal": { res1 = ereal.sign(x1); break; }
                            case " qreal": { res1 = qreal.sign(x1); break; }
                            case " oreal": { res1 = oreal.sign(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.sign(x1); break; }
                            case " zreal": { res1 = zreal.sign(x1); break; }
                            case " creal": { res1 = zreal.sign(x1); break; }
                            case " mreal": { res1 = mreal.sign(x1); break; }
                            case "sflint": { res1 = sflint.sign(x1); break; }
                            case "dflint": { res1 = dflint.sign(x1); break; }
                            case "eflint": { res1 = eflint.sign(x1); break; }
                            case "qflint": { res1 = qflint.sign(x1); break; }
                            case "oflint": { res1 = oflint.sign(x1); break; }
                            case "cflint": { res1 = cflint.sign(x1); break; }
                            case "mflint": { res1 = mflint.sign(x1); break; }
                            case "iflint": { res1 = iflint.sign(x1); break; }
                            case "aflint": { res1 = aflint.sign(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sign({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.real(x1); break; }
                            case " sreal": { res1 = sreal.real(x1); break; }
                            case " dreal": { res1 = dreal.real(x1); break; }
                            case " ereal": { res1 = ereal.real(x1); break; }
                            case " qreal": { res1 = qreal.real(x1); break; }
                            case " oreal": { res1 = oreal.real(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.real(x1); break; }
                            case " zreal": { res1 = zreal.real(x1); break; }
                            case " creal": { res1 = creal.real(x1); break; }
                            case " mreal": { res1 = mreal.real(x1); break; }
                            case "sflint": { res1 = sflint.real(x1); break; }
                            case "dflint": { res1 = dflint.real(x1); break; }
                            case "eflint": { res1 = eflint.real(x1); break; }
                            case "qflint": { res1 = qflint.real(x1); break; }
                            case "oflint": { res1 = oflint.real(x1); break; }
                            case "cflint": { res1 = cflint.real(x1); break; }
                            case "mflint": { res1 = mflint.real(x1); break; }
                            case "iflint": { res1 = iflint.real(x1); break; }
                            case "aflint": { res1 = aflint.real(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: real({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("imag"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.imag(x1); break; }
                            case " sreal": { res1 = sreal.imag(x1); break; }
                            case " dreal": { res1 = dreal.imag(x1); break; }
                            case " ereal": { res1 = ereal.imag(x1); break; }
                            case " qreal": { res1 = qreal.imag(x1); break; }
                            case " oreal": { res1 = oreal.imag(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.imag(x1); break; }
                            case " zreal": { res1 = zreal.imag(x1); break; }
                            case " creal": { res1 = creal.imag(x1); break; }
                            case " mreal": { res1 = mreal.imag(x1); break; }
                            case "sflint": { res1 = sflint.imag(x1); break; }
                            case "dflint": { res1 = dflint.imag(x1); break; }
                            case "eflint": { res1 = eflint.imag(x1); break; }
                            case "qflint": { res1 = qflint.imag(x1); break; }
                            case "oflint": { res1 = oflint.imag(x1); break; }
                            case "cflint": { res1 = cflint.imag(x1); break; }
                            case "mflint": { res1 = mflint.imag(x1); break; }
                            case "iflint": { res1 = iflint.imag(x1); break; }
                            case "aflint": { res1 = aflint.imag(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: imag({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("phase"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.phase(x1); break; }
                            case " sreal": { res1 = sreal.phase(x1); break; }
                            case " dreal": { res1 = dreal.phase(x1); break; }
                            case " ereal": { res1 = ereal.phase(x1); break; }
                            case " qreal": { res1 = qreal.phase(x1); break; }
                            case " oreal": { res1 = oreal.phase(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.phase(x1); break; }
                            case " zreal": { res1 = zreal.phase(x1); break; }
                            case " creal": { res1 = creal.phase(x1); break; }
                            case " mreal": { res1 = mreal.phase(x1); break; }
                            case "sflint": { res1 = sflint.phase(x1); break; }
                            case "dflint": { res1 = dflint.phase(x1); break; }
                            case "eflint": { res1 = eflint.phase(x1); break; }
                            case "qflint": { res1 = qflint.phase(x1); break; }
                            case "oflint": { res1 = oflint.phase(x1); break; }
                            case "cflint": { res1 = cflint.phase(x1); break; }
                            case "mflint": { res1 = mflint.phase(x1); break; }
                            case "iflint": { res1 = iflint.phase(x1); break; }
                            case "aflint": { res1 = aflint.phase(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: phase({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("conj"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.conj(x1); break; }
                            case " sreal": { res1 = sreal.conj(x1); break; }
                            case " dreal": { res1 = dreal.conj(x1); break; }
                            case " ereal": { res1 = ereal.conj(x1); break; }
                            case " qreal": { res1 = qreal.conj(x1); break; }
                            case " oreal": { res1 = oreal.conj(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.conj(x1); break; }
                            case " zreal": { res1 = zreal.conj(x1); break; }
                            case " creal": { res1 = creal.conj(x1); break; }
                            case " mreal": { res1 = mreal.conj(x1); break; }
                            case "sflint": { res1 = sflint.conj(x1); break; }
                            case "dflint": { res1 = dflint.conj(x1); break; }
                            case "eflint": { res1 = eflint.conj(x1); break; }
                            case "qflint": { res1 = qflint.conj(x1); break; }
                            case "oflint": { res1 = oflint.conj(x1); break; }
                            case "cflint": { res1 = cflint.conj(x1); break; }
                            case "mflint": { res1 = mflint.conj(x1); break; }
                            case "iflint": { res1 = iflint.conj(x1); break; }
                            case "aflint": { res1 = aflint.conj(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: conj({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }






            #endregion



            #region Roots and quadratic, cubic, and quartic



            if (FunctionArray.Contains("all") | FunctionArray.Contains("sqrt"))
            {
                InputArray1 = new[] { 2.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.sqrt(x1); break; }
                            case " sreal": { res1 = sreal.sqrt(x1); break; }
                            case " dreal": { res1 = dreal.sqrt(x1); break; }
                            case " ereal": { res1 = ereal.sqrt(x1); break; }
                            case " qreal": { res1 = qreal.sqrt(x1); break; }
                            case " oreal": { res1 = oreal.sqrt(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.sqrt(x1); break; }
                            case " zreal": { res1 = zreal.sqrt(x1); break; }
                            case " creal": { res1 = creal.sqrt(x1); break; }
                            case " mreal": { res1 = mreal.sqrt(x1); break; }
                            case "sflint": { res1 = sflint.sqrt(x1); break; }
                            case "dflint": { res1 = dflint.sqrt(x1); break; }
                            case "eflint": { res1 = eflint.sqrt(x1); break; }
                            case "qflint": { res1 = qflint.sqrt(x1); break; }
                            case "oflint": { res1 = oflint.sqrt(x1); break; }
                            case "cflint": { res1 = cflint.sqrt(x1); break; }
                            case "mflint": { res1 = mflint.sqrt(x1); break; }
                            case "iflint": { res1 = iflint.sqrt(x1); break; }
                            case "aflint": { res1 = aflint.sqrt(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sqrt({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sqrt1pm1"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.sqrt1pm1(x1); break; }
                            case " sreal": { res1 = sreal.sqrt1pm1(x1); break; }
                            case " dreal": { res1 = dreal.sqrt1pm1(x1); break; }
                            case " ereal": { res1 = ereal.sqrt1pm1(x1); break; }
                            case " qreal": { res1 = qreal.sqrt1pm1(x1); break; }
                            case " oreal": { res1 = oreal.sqrt1pm1(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.sqrt1pm1(x1); break; }
                            //case " zreal": { res1 = zreal.sqrt1pm1(x1); break; }
                            //case " creal": { res1 = creal.sqrt1pm1(x1); break; }
                            case " mreal": { res1 = mreal.sqrt1pm1(x1); break; }
                            case "sflint": { res1 = sflint.sqrt1pm1(x1); break; }
                            case "dflint": { res1 = dflint.sqrt1pm1(x1); break; }
                            case "eflint": { res1 = eflint.sqrt1pm1(x1); break; }
                            case "qflint": { res1 = qflint.sqrt1pm1(x1); break; }
                            case "oflint": { res1 = oflint.sqrt1pm1(x1); break; }
                            case "cflint": { res1 = cflint.sqrt1pm1(x1); break; }
                            case "mflint": { res1 = mflint.sqrt1pm1(x1); break; }
                            case "iflint": { res1 = iflint.sqrt1pm1(x1); break; }
                            case "aflint": { res1 = aflint.sqrt1pm1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sqrt1pm1({1}): \" + f(NumType) + \"{2}\"", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("rsqrt"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.rsqrt(x1); break; }
                            case " sreal": { res1 = sreal.rsqrt(x1); break; }
                            case " dreal": { res1 = dreal.rsqrt(x1); break; }
                            case " ereal": { res1 = ereal.rsqrt(x1); break; }
                            case " qreal": { res1 = qreal.rsqrt(x1); break; }
                            case " oreal": { res1 = oreal.rsqrt(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.rsqrt(x1); break; }
                            case " zreal": { res1 = zreal.rsqrt(x1); break; }
                            case " creal": { res1 = creal.rsqrt(x1); break; }
                            case " mreal": { res1 = mreal.rsqrt(x1); break; }
                            case "sflint": { res1 = sflint.rsqrt(x1); break; }
                            case "dflint": { res1 = dflint.rsqrt(x1); break; }
                            case "eflint": { res1 = eflint.rsqrt(x1); break; }
                            case "qflint": { res1 = qflint.rsqrt(x1); break; }
                            case "oflint": { res1 = oflint.rsqrt(x1); break; }
                            case "cflint": { res1 = cflint.rsqrt(x1); break; }
                            case "mflint": { res1 = mflint.rsqrt(x1); break; }
                            case "iflint": { res1 = iflint.rsqrt(x1); break; }
                            case "aflint": { res1 = aflint.rsqrt(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: rsqrt({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cbrt"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.cbrt(x1); break; }
                            case " sreal": { res1 = sreal.cbrt(x1); break; }
                            case " dreal": { res1 = dreal.cbrt(x1); break; }
                            case " ereal": { res1 = ereal.cbrt(x1); break; }
                            case " qreal": { res1 = qreal.cbrt(x1); break; }
                            case " oreal": { res1 = oreal.cbrt(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.cbrt(x1); break; }
                            case " zreal": { res1 = zreal.cbrt(x1); break; }
                            case " creal": { res1 = creal.cbrt(x1); break; }
                            case " mreal": { res1 = mreal.cbrt(x1); break; }
                            case "sflint": { res1 = sflint.cbrt(x1); break; }
                            case "dflint": { res1 = dflint.cbrt(x1); break; }
                            case "eflint": { res1 = eflint.cbrt(x1); break; }
                            case "qflint": { res1 = qflint.cbrt(x1); break; }
                            case "oflint": { res1 = oflint.cbrt(x1); break; }
                            case "cflint": { res1 = cflint.cbrt(x1); break; }
                            case "mflint": { res1 = mflint.cbrt(x1); break; }
                            case "iflint": { res1 = iflint.cbrt(x1); break; }
                            case "aflint": { res1 = aflint.cbrt(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cbrt({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("root_si"))
            {
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d, double.PositiveInfinity };
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
                                case "math53": { res1 = math53.root_si(x, n); break; }
                                case " sreal": { res1 = sreal.root_si(x, n); break; }
                                case " dreal": { res1 = dreal.root_si(x, n); break; }
                                case " ereal": { res1 = ereal.root_si(x, n); break; }
                                case " qreal": { res1 = qreal.root_si(x, n); break; }
                                case " oreal": { res1 = oreal.root_si(x, n); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.root_si(x, n); break; }
                                //case " zreal": { res1 = zreal.root_si(x, n); break; }
                                //case " creal": { res1 = yreal.coot_si(x, n); break; }
                                case " mreal": { res1 = mreal.root_si(x, n); break; }
                                case "sflint": { res1 = sflint.root_si(x, n); break; }
                                case "dflint": { res1 = dflint.root_si(x, n); break; }
                                case "eflint": { res1 = eflint.root_si(x, n); break; }
                                case "qflint": { res1 = qflint.root_si(x, n); break; }
                                case "oflint": { res1 = oflint.root_si(x, n); break; }
                                case "cflint": { res1 = cflint.root_si(x, n); break; }
                                case "mflint": { res1 = mflint.root_si(x, n); break; }
                                case "iflint": { res1 = iflint.root_si(x, n); break; }
                                case "aflint": { res1 = aflint.root_si(x, n); break; }
#endif
                            }
                            Console.WriteLine("{0}: root_si({1}, {2}): " + f(NumType) + "{3}", NumType, x, n, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion



            #region Exponential and related functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.exp(x1); break; }
                            case " sreal": { res1 = sreal.exp(x1); break; }
                            case " dreal": { res1 = dreal.exp(x1); break; }
                            case " ereal": { res1 = ereal.exp(x1); break; }
                            case " qreal": { res1 = qreal.exp(x1); break; }
                            case " oreal": { res1 = oreal.exp(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.exp(x1); break; }
                            case " zreal": { res1 = zreal.exp(x1); break; }
                            case " creal": { res1 = creal.exp(x1); break; }
                            case " mreal": { res1 = mreal.exp(x1); break; }
                            case "sflint": { res1 = sflint.exp(x1); break; }
                            case "dflint": { res1 = dflint.exp(x1); break; }
                            case "eflint": { res1 = eflint.exp(x1); break; }
                            case "qflint": { res1 = qflint.exp(x1); break; }
                            case "oflint": { res1 = oflint.exp(x1); break; }
                            case "cflint": { res1 = cflint.exp(x1); break; }
                            case "mflint": { res1 = mflint.exp(x1); break; }
                            case "iflint": { res1 = iflint.exp(x1); break; }
                            case "aflint": { res1 = aflint.exp(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: exp({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp2"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.exp2(x1); break; }
                            case " sreal": { res1 = sreal.exp2(x1); break; }
                            case " dreal": { res1 = dreal.exp2(x1); break; }
                            case " ereal": { res1 = ereal.exp2(x1); break; }
                            case " qreal": { res1 = qreal.exp2(x1); break; }
                            case " oreal": { res1 = oreal.exp2(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.exp2(x1); break; }
                            case " zreal": { res1 = zreal.exp2(x1); break; }
                            case " creal": { res1 = creal.exp2(x1); break; }
                            case " mreal": { res1 = mreal.exp2(x1); break; }
                            case "sflint": { res1 = sflint.exp2(x1); break; }
                            case "dflint": { res1 = dflint.exp2(x1); break; }
                            case "eflint": { res1 = eflint.exp2(x1); break; }
                            case "qflint": { res1 = qflint.exp2(x1); break; }
                            case "oflint": { res1 = oflint.exp2(x1); break; }
                            case "cflint": { res1 = cflint.exp2(x1); break; }
                            case "mflint": { res1 = mflint.exp2(x1); break; }
                            case "iflint": { res1 = iflint.exp2(x1); break; }
                            case "aflint": { res1 = aflint.exp2(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: exp2({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp10"))
            {
                InputArray1 = new[] { -14.333d, 0.0d, 14.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.exp10(x1); break; }
                            case " sreal": { res1 = sreal.exp10(x1); break; }
                            case " dreal": { res1 = dreal.exp10(x1); break; }
                            case " ereal": { res1 = ereal.exp10(x1); break; }
                            case " qreal": { res1 = qreal.exp10(x1); break; }
                            case " oreal": { res1 = oreal.exp10(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.exp10(x1); break; }
                            //case " zreal": { res1 = zreal.exp10(x1); break; }
                            //case " creal": { res1 = creal.exp10(x1); break; }
                            case " mreal": { res1 = mreal.exp10(x1); break; }
                            case "sflint": { res1 = sflint.exp10(x1); break; }
                            case "dflint": { res1 = dflint.exp10(x1); break; }
                            case "eflint": { res1 = eflint.exp10(x1); break; }
                            case "qflint": { res1 = qflint.exp10(x1); break; }
                            case "oflint": { res1 = oflint.exp10(x1); break; }
                            case "cflint": { res1 = cflint.exp10(x1); break; }
                            case "mflint": { res1 = mflint.exp10(x1); break; }
                            case "iflint": { res1 = iflint.exp10(x1); break; }
                            case "aflint": { res1 = aflint.exp10(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: exp10({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("expm1"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.expm1(x1); break; }
                            case " sreal": { res1 = sreal.expm1(x1); break; }
                            case " dreal": { res1 = dreal.expm1(x1); break; }
                            case " ereal": { res1 = ereal.expm1(x1); break; }
                            case " qreal": { res1 = qreal.expm1(x1); break; }
                            case " oreal": { res1 = oreal.expm1(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.expm1(x1); break; }
                            case " zreal": { res1 = zreal.expm1(x1); break; }
                            case " creal": { res1 = creal.expm1(x1); break; }
                            case " mreal": { res1 = mreal.expm1(x1); break; }
                            case "sflint": { res1 = sflint.expm1(x1); break; }
                            case "dflint": { res1 = dflint.expm1(x1); break; }
                            case "eflint": { res1 = eflint.expm1(x1); break; }
                            case "qflint": { res1 = qflint.expm1(x1); break; }
                            case "oflint": { res1 = oflint.expm1(x1); break; }
                            case "cflint": { res1 = cflint.expm1(x1); break; }
                            case "mflint": { res1 = mflint.expm1(x1); break; }
                            case "iflint": { res1 = iflint.expm1(x1); break; }
                            case "aflint": { res1 = aflint.expm1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: expm1({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp2m1"))
            {
                InputArray1 = new[] { -0.00333d, 0.0d, 0.00333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.exp2m1(x1); break; }
                            case " sreal": { res1 = sreal.exp2m1(x1); break; }
                            case " dreal": { res1 = dreal.exp2m1(x1); break; }
                            case " ereal": { res1 = ereal.exp2m1(x1); break; }
                            case " qreal": { res1 = qreal.exp2m1(x1); break; }
                            case " oreal": { res1 = oreal.exp2m1(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.exp2m1(x1); break; }
                            //case " zreal": { res1 = zreal.exp2m1(x1); break; }
                            //case " creal": { res1 = creal.exp2m1(x1); break; }
                            case " mreal": { res1 = mreal.exp2m1(x1); break; }
                            case "sflint": { res1 = sflint.exp2m1(x1); break; }
                            case "dflint": { res1 = dflint.exp2m1(x1); break; }
                            case "eflint": { res1 = eflint.exp2m1(x1); break; }
                            case "qflint": { res1 = qflint.exp2m1(x1); break; }
                            case "oflint": { res1 = oflint.exp2m1(x1); break; }
                            case "cflint": { res1 = cflint.exp2m1(x1); break; }
                            case "mflint": { res1 = mflint.exp2m1(x1); break; }
                            case "iflint": { res1 = iflint.exp2m1(x1); break; }
                            case "aflint": { res1 = aflint.exp2m1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: exp2m1({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp10m1"))
            {
                InputArray1 = new[] { -0.00333d, 0.0d, 0.00333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.exp10m1(x1); break; }
                            case " sreal": { res1 = sreal.exp10m1(x1); break; }
                            case " dreal": { res1 = dreal.exp10m1(x1); break; }
                            case " ereal": { res1 = ereal.exp10m1(x1); break; }
                            case " qreal": { res1 = qreal.exp10m1(x1); break; }
                            case " oreal": { res1 = oreal.exp10m1(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.exp10m1(x1); break; }
                            //case " zreal": { res1 = zreal.exp10m1(x1); break; }
                            //case " creal": { res1 = creal.exp10m1(x1); break; }
                            case " mreal": { res1 = mreal.exp10m1(x1); break; }
                            case "sflint": { res1 = sflint.exp10m1(x1); break; }
                            case "dflint": { res1 = dflint.exp10m1(x1); break; }
                            case "eflint": { res1 = eflint.exp10m1(x1); break; }
                            case "qflint": { res1 = qflint.exp10m1(x1); break; }
                            case "oflint": { res1 = oflint.exp10m1(x1); break; }
                            case "cflint": { res1 = cflint.exp10m1(x1); break; }
                            case "mflint": { res1 = mflint.exp10m1(x1); break; }
                            case "iflint": { res1 = iflint.exp10m1(x1); break; }
                            case "aflint": { res1 = aflint.exp10m1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: exp10m1({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Logarithms and related functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.log(x1); break; }
                            case " sreal": { res1 = sreal.log(x1); break; }
                            case " dreal": { res1 = dreal.log(x1); break; }
                            case " ereal": { res1 = ereal.log(x1); break; }
                            case " qreal": { res1 = qreal.log(x1); break; }
                            case " oreal": { res1 = oreal.log(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.log(x1); break; }
                            case " zreal": { res1 = zreal.log(x1); break; }
                            case " creal": { res1 = creal.log(x1); break; }
                            case " mreal": { res1 = mreal.log(x1); break; }
                            case "sflint": { res1 = sflint.log(x1); break; }
                            case "dflint": { res1 = dflint.log(x1); break; }
                            case "eflint": { res1 = eflint.log(x1); break; }
                            case "qflint": { res1 = qflint.log(x1); break; }
                            case "oflint": { res1 = oflint.log(x1); break; }
                            case "cflint": { res1 = cflint.log(x1); break; }
                            case "mflint": { res1 = mflint.log(x1); break; }
                            case "iflint": { res1 = iflint.log(x1); break; }
                            case "aflint": { res1 = aflint.log(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: log({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log2"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.log2(x1); break; }
                            case " sreal": { res1 = sreal.log2(x1); break; }
                            case " dreal": { res1 = dreal.log2(x1); break; }
                            case " ereal": { res1 = ereal.log2(x1); break; }
                            case " qreal": { res1 = qreal.log2(x1); break; }
                            case " oreal": { res1 = oreal.log2(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.log2(x1); break; }
                            case " zreal": { res1 = zreal.log2(x1); break; }
                            case " creal": { res1 = creal.log2(x1); break; }
                            case " mreal": { res1 = mreal.log2(x1); break; }
                            case "sflint": { res1 = sflint.log2(x1); break; }
                            case "dflint": { res1 = dflint.log2(x1); break; }
                            case "eflint": { res1 = eflint.log2(x1); break; }
                            case "qflint": { res1 = qflint.log2(x1); break; }
                            case "oflint": { res1 = oflint.log2(x1); break; }
                            case "cflint": { res1 = cflint.log2(x1); break; }
                            case "mflint": { res1 = mflint.log2(x1); break; }
                            case "iflint": { res1 = iflint.log2(x1); break; }
                            case "aflint": { res1 = aflint.log2(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: log2({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log10"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.log10(x1); break; }
                            case " sreal": { res1 = sreal.log10(x1); break; }
                            case " dreal": { res1 = dreal.log10(x1); break; }
                            case " ereal": { res1 = ereal.log10(x1); break; }
                            case " qreal": { res1 = qreal.log10(x1); break; }
                            case " oreal": { res1 = oreal.log10(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.log10(x1); break; }
                            case " zreal": { res1 = zreal.log10(x1); break; }
                            case " creal": { res1 = creal.log10(x1); break; }
                            case " mreal": { res1 = mreal.log10(x1); break; }
                            case "sflint": { res1 = sflint.log10(x1); break; }
                            case "dflint": { res1 = dflint.log10(x1); break; }
                            case "eflint": { res1 = eflint.log10(x1); break; }
                            case "qflint": { res1 = qflint.log10(x1); break; }
                            case "oflint": { res1 = oflint.log10(x1); break; }
                            case "cflint": { res1 = cflint.log10(x1); break; }
                            case "mflint": { res1 = mflint.log10(x1); break; }
                            case "iflint": { res1 = iflint.log10(x1); break; }
                            case "aflint": { res1 = aflint.log10(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: log10({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log1p"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.log1p(x1); break; }
                            case " sreal": { res1 = sreal.log1p(x1); break; }
                            case " dreal": { res1 = dreal.log1p(x1); break; }
                            case " ereal": { res1 = ereal.log1p(x1); break; }
                            case " qreal": { res1 = qreal.log1p(x1); break; }
                            case " oreal": { res1 = oreal.log1p(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.log1p(x1); break; }
                            case " zreal": { res1 = zreal.log1p(x1); break; }
                            case " creal": { res1 = creal.log1p(x1); break; }
                            case " mreal": { res1 = mreal.log1p(x1); break; }
                            case "sflint": { res1 = sflint.log1p(x1); break; }
                            case "dflint": { res1 = dflint.log1p(x1); break; }
                            case "eflint": { res1 = eflint.log1p(x1); break; }
                            case "qflint": { res1 = qflint.log1p(x1); break; }
                            case "oflint": { res1 = oflint.log1p(x1); break; }
                            case "cflint": { res1 = cflint.log1p(x1); break; }
                            case "mflint": { res1 = mflint.log1p(x1); break; }
                            case "iflint": { res1 = iflint.log1p(x1); break; }
                            case "aflint": { res1 = aflint.log1p(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: log1p({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log2p1"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.log2p1(x1); break; }
                            case " sreal": { res1 = sreal.log2p1(x1); break; }
                            case " dreal": { res1 = dreal.log2p1(x1); break; }
                            case " ereal": { res1 = ereal.log2p1(x1); break; }
                            case " qreal": { res1 = qreal.log2p1(x1); break; }
                            case " oreal": { res1 = oreal.log2p1(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.log2p1(x1); break; }
                            //case " zreal": { res1 = zreal.log2p1(x1); break; }
                            //case " creal": { res1 = creal.log2p1(x1); break; }
                            case " mreal": { res1 = mreal.log2p1(x1); break; }
                            case "sflint": { res1 = sflint.log2p1(x1); break; }
                            case "dflint": { res1 = dflint.log2p1(x1); break; }
                            case "eflint": { res1 = eflint.log2p1(x1); break; }
                            case "qflint": { res1 = qflint.log2p1(x1); break; }
                            case "oflint": { res1 = oflint.log2p1(x1); break; }
                            case "cflint": { res1 = cflint.log2p1(x1); break; }
                            case "mflint": { res1 = mflint.log2p1(x1); break; }
                            case "iflint": { res1 = iflint.log2p1(x1); break; }
                            case "aflint": { res1 = aflint.log2p1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: log2p1({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log10p1"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.log10p1(x1); break; }
                            case " sreal": { res1 = sreal.log10p1(x1); break; }
                            case " dreal": { res1 = dreal.log10p1(x1); break; }
                            case " ereal": { res1 = ereal.log10p1(x1); break; }
                            case " qreal": { res1 = qreal.log10p1(x1); break; }
                            case " oreal": { res1 = oreal.log10p1(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.log10p1(x1); break; }
                            //case " zreal": { res1 = zreal.log10p1(x1); break; }
                            //case " creal": { res1 = creal.log10p1(x1); break; }
                            case " mreal": { res1 = mreal.log10p1(x1); break; }
                            case "sflint": { res1 = sflint.log10p1(x1); break; }
                            case "dflint": { res1 = dflint.log10p1(x1); break; }
                            case "eflint": { res1 = eflint.log10p1(x1); break; }
                            case "qflint": { res1 = qflint.log10p1(x1); break; }
                            case "oflint": { res1 = oflint.log10p1(x1); break; }
                            case "cflint": { res1 = cflint.log10p1(x1); break; }
                            case "mflint": { res1 = mflint.log10p1(x1); break; }
                            case "iflint": { res1 = iflint.log10p1(x1); break; }
                            case "aflint": { res1 = aflint.log10p1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: log10p1({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }





            if (FunctionArray.Contains("all") | FunctionArray.Contains("lambert_w0"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.lambert_w0(x1); break; }
                            case " sreal": { res1 = sreal.lambert_w0(x1); break; }
                            case " dreal": { res1 = dreal.lambert_w0(x1); break; }
                            case " ereal": { res1 = ereal.lambert_w0(x1); break; }
                            case " qreal": { res1 = qreal.lambert_w0(x1); break; }
                            case " oreal": { res1 = oreal.lambert_w0(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.lambert_w0(x1); break; }
                            //case " zreal": { res1 = zreal.lambert_w0(x1); break; }
                            //case " creal": { res1 = creal.lambert_w0(x1); break; }
                            case " mreal": { res1 = mreal.lambert_w0(x1); break; }
                            case "sflint": { res1 = sflint.lambert_w0(x1); break; }
                            case "dflint": { res1 = dflint.lambert_w0(x1); break; }
                            case "eflint": { res1 = eflint.lambert_w0(x1); break; }
                            case "qflint": { res1 = qflint.lambert_w0(x1); break; }
                            case "oflint": { res1 = oflint.lambert_w0(x1); break; }
                            case "cflint": { res1 = cflint.lambert_w0(x1); break; }
                            case "mflint": { res1 = mflint.lambert_w0(x1); break; }
                            case "iflint": { res1 = iflint.lambert_w0(x1); break; }
                            case "aflint": { res1 = aflint.lambert_w0(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: lambert_w0({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("lambert_wm1"))
            {
                InputArray1 = new[] { -0.2d, -0.01d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.lambert_wm1(x1); break; }
                            case " sreal": { res1 = sreal.lambert_wm1(x1); break; }
                            case " dreal": { res1 = dreal.lambert_wm1(x1); break; }
                            case " ereal": { res1 = ereal.lambert_wm1(x1); break; }
                            case " qreal": { res1 = qreal.lambert_wm1(x1); break; }
                            case " oreal": { res1 = oreal.lambert_wm1(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.lambert_wm1(x1); break; }
                            //case " zreal": { res1 = zreal.lambert_wm1(x1); break; }
                            //case " creal": { res1 = creal.lambert_wm1(x1); break; }
                            case " mreal": { res1 = mreal.lambert_wm1(x1); break; }
                            case "sflint": { res1 = sflint.lambert_wm1(x1); break; }
                            case "dflint": { res1 = dflint.lambert_wm1(x1); break; }
                            case "eflint": { res1 = eflint.lambert_wm1(x1); break; }
                            case "qflint": { res1 = qflint.lambert_wm1(x1); break; }
                            case "oflint": { res1 = oflint.lambert_wm1(x1); break; }
                            case "cflint": { res1 = cflint.lambert_wm1(x1); break; }
                            case "mflint": { res1 = mflint.lambert_wm1(x1); break; }
                            case "iflint": { res1 = iflint.lambert_wm1(x1); break; }
                            case "aflint": { res1 = aflint.lambert_wm1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: lambert_wm1({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("lambert_w0_prime"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.lambert_w0_prime(x1); break; }
                            case " sreal": { res1 = sreal.lambert_w0_prime(x1); break; }
                            case " dreal": { res1 = dreal.lambert_w0_prime(x1); break; }
                            case " ereal": { res1 = ereal.lambert_w0_prime(x1); break; }
                            case " qreal": { res1 = qreal.lambert_w0_prime(x1); break; }
                            case " oreal": { res1 = oreal.lambert_w0_prime(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.lambert_w0_prime(x1); break; }
                            //case " zreal": { res1 = zreal.lambert_w0_prime(x1); break; }
                            //case " creal": { res1 = creal.lambert_w0_prime(x1); break; }
                            case " mreal": { res1 = mreal.lambert_w0_prime(x1); break; }
                            //case "sflint": { res1 = sflint.lambert_w0_prime(x1); break; }
                            //case "dflint": { res1 = dflint.lambert_w0_prime(x1); break; }
                            //case "eflint": { res1 = eflint.lambert_w0_prime(x1); break; }
                            //case "qflint": { res1 = qflint.lambert_w0_prime(x1); break; }
                            //case "oflint": { res1 = oflint.lambert_w0_prime(x1); break; }
                            //case "cflint": { res1 = cflint.lambert_w0_prime(x1); break; }
                            //case "mflint": { res1 = mflint.lambert_w0_prime(x1); break; }
                            //case "iflint": { res1 = iflint.lambert_w0_prime(x1); break; }
                            //case "aflint": { res1 = aflint.lambert_w0_prime(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: lambert_w0_prime({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("lambert_wm1_prime"))
            {
                InputArray1 = new[] { -0.2d, -0.01d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.lambert_wm1_prime(x1); break; }
                            case " sreal": { res1 = sreal.lambert_wm1_prime(x1); break; }
                            case " dreal": { res1 = dreal.lambert_wm1_prime(x1); break; }
                            case " ereal": { res1 = ereal.lambert_wm1_prime(x1); break; }
                            case " qreal": { res1 = qreal.lambert_wm1_prime(x1); break; }
                            case " oreal": { res1 = oreal.lambert_wm1_prime(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.lambert_wm1_prime(x1); break; }
                            //case " zreal": { res1 = zreal.lambert_wm1_prime(x1); break; }
                            //case " creal": { res1 = creal.lambert_wm1_prime(x1); break; }
                            case " mreal": { res1 = mreal.lambert_wm1_prime(x1); break; }
                            //case "sflint": { res1 = sflint.lambert_wm1_prime(x1); break; }
                            //case "dflint": { res1 = dflint.lambert_wm1_prime(x1); break; }
                            //case "eflint": { res1 = eflint.lambert_wm1_prime(x1); break; }
                            //case "qflint": { res1 = qflint.lambert_wm1_prime(x1); break; }
                            //case "oflint": { res1 = oflint.lambert_wm1_prime(x1); break; }
                            //case "cflint": { res1 = cflint.lambert_wm1_prime(x1); break; }
                            //case "mflint": { res1 = mflint.lambert_wm1_prime(x1); break; }
                            //case "iflint": { res1 = iflint.lambert_wm1_prime(x1); break; }
                            //case "aflint": { res1 = aflint.lambert_wm1_prime(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: lambert_wm1_prime({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion




            #region Power functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sqr"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.sqr(x1); break; }
                            case " sreal": { res1 = sreal.sqr(x1); break; }
                            case " dreal": { res1 = dreal.sqr(x1); break; }
                            case " ereal": { res1 = ereal.sqr(x1); break; }
                            case " qreal": { res1 = qreal.sqr(x1); break; }
                            case " oreal": { res1 = oreal.sqr(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.sqr(x1); break; }
                            case " zreal": { res1 = zreal.sqr(x1); break; }
                            //case " creal": { res1 = creal.sqr(x1); break; }
                            case " mreal": { res1 = mreal.sqr(x1); break; }
                            case "sflint": { res1 = sflint.sqr(x1); break; }
                            case "dflint": { res1 = dflint.sqr(x1); break; }
                            case "eflint": { res1 = eflint.sqr(x1); break; }
                            case "qflint": { res1 = qflint.sqr(x1); break; }
                            case "oflint": { res1 = oflint.sqr(x1); break; }
                            case "cflint": { res1 = cflint.sqr(x1); break; }
                            case "mflint": { res1 = mflint.sqr(x1); break; }
                            case "iflint": { res1 = iflint.sqr(x1); break; }
                            case "aflint": { res1 = aflint.sqr(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sqr({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cube"))
            {
                InputArray1 = new[] { -0.2d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.cube(x1); break; }
                            case " sreal": { res1 = sreal.cube(x1); break; }
                            case " dreal": { res1 = dreal.cube(x1); break; }
                            case " ereal": { res1 = ereal.cube(x1); break; }
                            case " qreal": { res1 = qreal.cube(x1); break; }
                            case " oreal": { res1 = oreal.cube(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.cube(x1); break; }
                            case " zreal": { res1 = zreal.cube(x1); break; }
                            //case " creal": { res1 = creal.cube(x1); break; }
                            case " mreal": { res1 = mreal.cube(x1); break; }
                            case "sflint": { res1 = sflint.cube(x1); break; }
                            case "dflint": { res1 = dflint.cube(x1); break; }
                            case "eflint": { res1 = eflint.cube(x1); break; }
                            case "qflint": { res1 = qflint.cube(x1); break; }
                            case "oflint": { res1 = oflint.cube(x1); break; }
                            case "cflint": { res1 = cflint.cube(x1); break; }
                            case "mflint": { res1 = mflint.cube(x1); break; }
                            case "iflint": { res1 = iflint.cube(x1); break; }
                            case "aflint": { res1 = aflint.cube(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cube({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hypot"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.hypot(x, y); break; }
                                case " sreal": { res1 = sreal.hypot(x, y); break; }
                                case " dreal": { res1 = dreal.hypot(x, y); break; }
                                case " ereal": { res1 = ereal.hypot(x, y); break; }
                                case " qreal": { res1 = qreal.hypot(x, y); break; }
                                case " oreal": { res1 = oreal.hypot(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.hypot(x, y); break; }
                                case " zreal": { res1 = zreal.hypot(x, y); break; }
                                case " creal": { res1 = creal.hypot(x, y); break; }
                                case " mreal": { res1 = mreal.hypot(x, y); break; }
                                case "sflint": { res1 = sflint.hypot(x, y); break; }
                                case "dflint": { res1 = dflint.hypot(x, y); break; }
                                case "eflint": { res1 = eflint.hypot(x, y); break; }
                                case "qflint": { res1 = qflint.hypot(x, y); break; }
                                case "oflint": { res1 = oflint.hypot(x, y); break; }
                                case "cflint": { res1 = cflint.hypot(x, y); break; }
                                case "mflint": { res1 = mflint.hypot(x, y); break; }
                                case "iflint": { res1 = iflint.hypot(x, y); break; }
                                case "aflint": { res1 = aflint.hypot(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: hypot({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pow"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.pow(x, y); break; }
                                case " sreal": { res1 = sreal.pow(x, y); break; }
                                case " dreal": { res1 = dreal.pow(x, y); break; }
                                case " ereal": { res1 = ereal.pow(x, y); break; }
                                case " qreal": { res1 = qreal.pow(x, y); break; }
                                case " oreal": { res1 = oreal.pow(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.pow(x, y); break; }
                                case " zreal": { res1 = zreal.pow(x, y); break; }
                                case " creal": { res1 = creal.pow(x, y); break; }
                                case " mreal": { res1 = mreal.pow(x, y); break; }
                                case "sflint": { res1 = sflint.pow(x, y); break; }
                                case "dflint": { res1 = dflint.pow(x, y); break; }
                                case "eflint": { res1 = eflint.pow(x, y); break; }
                                case "qflint": { res1 = qflint.pow(x, y); break; }
                                case "oflint": { res1 = oflint.pow(x, y); break; }
                                case "cflint": { res1 = cflint.pow(x, y); break; }
                                case "mflint": { res1 = mflint.pow(x, y); break; }
                                case "iflint": { res1 = iflint.pow(x, y); break; }
                                case "aflint": { res1 = aflint.pow(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: pow({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("powm1"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.powm1(x, y); break; }
                                case " sreal": { res1 = sreal.powm1(x, y); break; }
                                case " dreal": { res1 = dreal.powm1(x, y); break; }
                                case " ereal": { res1 = ereal.powm1(x, y); break; }
                                case " qreal": { res1 = qreal.powm1(x, y); break; }
                                case " oreal": { res1 = oreal.powm1(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.powm1(x, y); break; }
                                //case " zreal": { res1 = zreal.powm1(x, y); break; }
                                //case " creal": { res1 = creal.powm1(x, y); break; }
                                case " mreal": { res1 = mreal.powm1(x, y); break; }
                                case "sflint": { res1 = sflint.powm1(x, y); break; }
                                case "dflint": { res1 = dflint.powm1(x, y); break; }
                                case "eflint": { res1 = eflint.powm1(x, y); break; }
                                case "qflint": { res1 = qflint.powm1(x, y); break; }
                                case "oflint": { res1 = oflint.powm1(x, y); break; }
                                case "cflint": { res1 = cflint.powm1(x, y); break; }
                                case "mflint": { res1 = mflint.powm1(x, y); break; }
                                case "iflint": { res1 = iflint.powm1(x, y); break; }
                                case "aflint": { res1 = aflint.powm1(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: powm1({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pow1pm1"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.pow1pm1(x, y); break; }
                                case " sreal": { res1 = sreal.pow1pm1(x, y); break; }
                                case " dreal": { res1 = dreal.pow1pm1(x, y); break; }
                                case " ereal": { res1 = ereal.pow1pm1(x, y); break; }
                                case " qreal": { res1 = qreal.pow1pm1(x, y); break; }
                                case " oreal": { res1 = oreal.pow1pm1(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.pow1pm1(x, y); break; }
                                //case " zreal": { res1 = zreal.pow1pm1(x, y); break; }
                                //case " creal": { res1 = creal.pow1pm1(x, y); break; }
                                case " mreal": { res1 = mreal.pow1pm1(x, y); break; }
                                case "sflint": { res1 = sflint.pow1pm1(x, y); break; }
                                case "dflint": { res1 = dflint.pow1pm1(x, y); break; }
                                case "eflint": { res1 = eflint.pow1pm1(x, y); break; }
                                case "qflint": { res1 = qflint.pow1pm1(x, y); break; }
                                case "oflint": { res1 = oflint.pow1pm1(x, y); break; }
                                case "cflint": { res1 = cflint.pow1pm1(x, y); break; }
                                case "mflint": { res1 = mflint.pow1pm1(x, y); break; }
                                case "iflint": { res1 = iflint.pow1pm1(x, y); break; }
                                case "aflint": { res1 = aflint.pow1pm1(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: pow1pm1({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pow_si"))
            {
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d, double.PositiveInfinity };
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
                                case "math53": { res1 = math53.pow_si(x, n); break; }
                                case " sreal": { res1 = sreal.pow_si(x, n); break; }
                                case " dreal": { res1 = dreal.pow_si(x, n); break; }
                                case " ereal": { res1 = ereal.pow_si(x, n); break; }
                                case " qreal": { res1 = qreal.pow_si(x, n); break; }
                                case " oreal": { res1 = oreal.pow_si(x, n); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.pow_si(x, n); break; }
                                //case " zreal": { res1 = zreal.pow_si(x, n); break; }
                                //case " creal": { res1 = creal.pow_si(x, n); break; }
                                case " mreal": { res1 = mreal.pow_si(x, n); break; }
                                case "sflint": { res1 = sflint.pow_si(x, n); break; }
                                case "dflint": { res1 = dflint.pow_si(x, n); break; }
                                case "eflint": { res1 = eflint.pow_si(x, n); break; }
                                case "qflint": { res1 = qflint.pow_si(x, n); break; }
                                case "oflint": { res1 = oflint.pow_si(x, n); break; }
                                case "cflint": { res1 = cflint.pow_si(x, n); break; }
                                case "mflint": { res1 = mflint.pow_si(x, n); break; }
                                case "iflint": { res1 = iflint.pow_si(x, n); break; }
                                case "aflint": { res1 = aflint.pow_si(x, n); break; }
#endif
                            }
                            Console.WriteLine("{0}: pow_si({1}, {2}): " + f(NumType) + "{3}", NumType, x, n, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("compound_si"))
            {
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d, double.PositiveInfinity };
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
                                case "math53": { res1 = math53.compound_si(x, n); break; }
                                case " sreal": { res1 = sreal.compound_si(x, n); break; }
                                case " dreal": { res1 = dreal.compound_si(x, n); break; }
                                case " ereal": { res1 = ereal.compound_si(x, n); break; }
                                case " qreal": { res1 = qreal.compound_si(x, n); break; }
                                case " oreal": { res1 = oreal.compound_si(x, n); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.compound_si(x, n); break; }
                                //case " zreal": { res1 = zreal.compound_si(x, n); break; }
                                //case " creal": { res1 = creal.compound_si(x, n); break; }
                                case " mreal": { res1 = mreal.compound_si(x, n); break; }
                                case "sflint": { res1 = sflint.compound_si(x, n); break; }
                                case "dflint": { res1 = dflint.compound_si(x, n); break; }
                                case "eflint": { res1 = eflint.compound_si(x, n); break; }
                                case "qflint": { res1 = qflint.compound_si(x, n); break; }
                                case "oflint": { res1 = oflint.compound_si(x, n); break; }
                                case "cflint": { res1 = cflint.compound_si(x, n); break; }
                                case "mflint": { res1 = mflint.compound_si(x, n); break; }
                                case "iflint": { res1 = iflint.compound_si(x, n); break; }
                                case "aflint": { res1 = aflint.compound_si(x, n); break; }
#endif
                            }
                            Console.WriteLine("{0}: compound_si({1}, {2}): " + f(NumType) + "{3}", NumType, x, n, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion




            #region Trigonometric and related functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sin"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.sin(x1); break; }
                            case " sreal": { res1 = sreal.sin(x1); break; }
                            case " dreal": { res1 = dreal.sin(x1); break; }
                            case " ereal": { res1 = ereal.sin(x1); break; }
                            case " qreal": { res1 = qreal.sin(x1); break; }
                            case " oreal": { res1 = oreal.sin(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.sin(x1); break; }
                            case " zreal": { res1 = zreal.sin(x1); break; }
                            case " creal": { res1 = creal.sin(x1); break; }
                            case " mreal": { res1 = mreal.sin(x1); break; }
                            case "sflint": { res1 = sflint.sin(x1); break; }
                            case "dflint": { res1 = dflint.sin(x1); break; }
                            case "eflint": { res1 = eflint.sin(x1); break; }
                            case "qflint": { res1 = qflint.sin(x1); break; }
                            case "oflint": { res1 = oflint.sin(x1); break; }
                            case "cflint": { res1 = cflint.sin(x1); break; }
                            case "mflint": { res1 = mflint.sin(x1); break; }
                            case "iflint": { res1 = iflint.sin(x1); break; }
                            case "aflint": { res1 = aflint.sin(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sin({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cos"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.cos(x1); break; }
                            case " sreal": { res1 = sreal.cos(x1); break; }
                            case " dreal": { res1 = dreal.cos(x1); break; }
                            case " ereal": { res1 = ereal.cos(x1); break; }
                            case " qreal": { res1 = qreal.cos(x1); break; }
                            case " oreal": { res1 = oreal.cos(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.cos(x1); break; }
                            case " zreal": { res1 = zreal.cos(x1); break; }
                            case " creal": { res1 = creal.cos(x1); break; }
                            case " mreal": { res1 = mreal.cos(x1); break; }
                            case "sflint": { res1 = sflint.cos(x1); break; }
                            case "dflint": { res1 = dflint.cos(x1); break; }
                            case "eflint": { res1 = eflint.cos(x1); break; }
                            case "qflint": { res1 = qflint.cos(x1); break; }
                            case "oflint": { res1 = oflint.cos(x1); break; }
                            case "cflint": { res1 = cflint.cos(x1); break; }
                            case "mflint": { res1 = mflint.cos(x1); break; }
                            case "iflint": { res1 = iflint.cos(x1); break; }
                            case "aflint": { res1 = aflint.cos(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cos({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("tan"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.tan(x1); break; }
                            case " sreal": { res1 = sreal.tan(x1); break; }
                            case " dreal": { res1 = dreal.tan(x1); break; }
                            case " ereal": { res1 = ereal.tan(x1); break; }
                            case " qreal": { res1 = qreal.tan(x1); break; }
                            case " oreal": { res1 = oreal.tan(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.tan(x1); break; }
                            case " zreal": { res1 = zreal.tan(x1); break; }
                            case " creal": { res1 = creal.tan(x1); break; }
                            case " mreal": { res1 = mreal.tan(x1); break; }
                            case "sflint": { res1 = sflint.tan(x1); break; }
                            case "dflint": { res1 = dflint.tan(x1); break; }
                            case "eflint": { res1 = eflint.tan(x1); break; }
                            case "qflint": { res1 = qflint.tan(x1); break; }
                            case "oflint": { res1 = oflint.tan(x1); break; }
                            case "cflint": { res1 = cflint.tan(x1); break; }
                            case "mflint": { res1 = mflint.tan(x1); break; }
                            case "iflint": { res1 = iflint.tan(x1); break; }
                            case "aflint": { res1 = aflint.tan(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: tan({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("csc"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.csc(x1); break; }
                            case " sreal": { res1 = sreal.csc(x1); break; }
                            case " dreal": { res1 = dreal.csc(x1); break; }
                            case " ereal": { res1 = ereal.csc(x1); break; }
                            case " qreal": { res1 = qreal.csc(x1); break; }
                            case " oreal": { res1 = oreal.csc(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.csc(x1); break; }
                            //case " zreal": { res1 = zreal.csc(x1); break; }
                            //case " creal": { res1 = creal.csc(x1); break; }
                            case " mreal": { res1 = mreal.csc(x1); break; }
                            case "sflint": { res1 = sflint.csc(x1); break; }
                            case "dflint": { res1 = dflint.csc(x1); break; }
                            case "eflint": { res1 = eflint.csc(x1); break; }
                            case "qflint": { res1 = qflint.csc(x1); break; }
                            case "oflint": { res1 = oflint.csc(x1); break; }
                            case "cflint": { res1 = cflint.csc(x1); break; }
                            case "mflint": { res1 = mflint.csc(x1); break; }
                            case "iflint": { res1 = iflint.csc(x1); break; }
                            case "aflint": { res1 = aflint.csc(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: csc({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sec"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.sec(x1); break; }
                            case " sreal": { res1 = sreal.sec(x1); break; }
                            case " dreal": { res1 = dreal.sec(x1); break; }
                            case " ereal": { res1 = ereal.sec(x1); break; }
                            case " qreal": { res1 = qreal.sec(x1); break; }
                            case " oreal": { res1 = oreal.sec(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.sec(x1); break; }
                            //case " zreal": { res1 = zreal.sec(x1); break; }
                            //case " creal": { res1 = creal.sec(x1); break; }
                            case " mreal": { res1 = mreal.sec(x1); break; }
                            case "sflint": { res1 = sflint.sec(x1); break; }
                            case "dflint": { res1 = dflint.sec(x1); break; }
                            case "eflint": { res1 = eflint.sec(x1); break; }
                            case "qflint": { res1 = qflint.sec(x1); break; }
                            case "oflint": { res1 = oflint.sec(x1); break; }
                            case "cflint": { res1 = cflint.sec(x1); break; }
                            case "mflint": { res1 = mflint.sec(x1); break; }
                            case "iflint": { res1 = iflint.sec(x1); break; }
                            case "aflint": { res1 = aflint.sec(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: csc({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cot"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.cot(x1); break; }
                            case " sreal": { res1 = sreal.cot(x1); break; }
                            case " dreal": { res1 = dreal.cot(x1); break; }
                            case " ereal": { res1 = ereal.cot(x1); break; }
                            case " qreal": { res1 = qreal.cot(x1); break; }
                            case " oreal": { res1 = oreal.cot(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.cot(x1); break; }
                            //case " zreal": { res1 = zreal.cot(x1); break; }
                            //case " creal": { res1 = creal.cot(x1); break; }
                            case " mreal": { res1 = mreal.cot(x1); break; }
                            case "sflint": { res1 = sflint.cot(x1); break; }
                            case "dflint": { res1 = dflint.cot(x1); break; }
                            case "eflint": { res1 = eflint.cot(x1); break; }
                            case "qflint": { res1 = qflint.cot(x1); break; }
                            case "oflint": { res1 = oflint.cot(x1); break; }
                            case "cflint": { res1 = cflint.cot(x1); break; }
                            case "mflint": { res1 = mflint.cot(x1); break; }
                            case "iflint": { res1 = iflint.cot(x1); break; }
                            case "aflint": { res1 = aflint.cot(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cot({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("sinpi"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.sinpi(x1); break; }
                            case " sreal": { res1 = sreal.sinpi(x1); break; }
                            case " dreal": { res1 = dreal.sinpi(x1); break; }
                            case " ereal": { res1 = ereal.sinpi(x1); break; }
                            case " qreal": { res1 = qreal.sinpi(x1); break; }
                            case " oreal": { res1 = oreal.sinpi(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.sinpi(x1); break; }
                            //case " zreal": { res1 = zreal.sinpi(x1); break; }
                            //case " creal": { res1 = creal.sinpi(x1); break; }
                            case " mreal": { res1 = mreal.sinpi(x1); break; }
                            case "sflint": { res1 = sflint.sinpi(x1); break; }
                            case "dflint": { res1 = dflint.sinpi(x1); break; }
                            case "eflint": { res1 = eflint.sinpi(x1); break; }
                            case "qflint": { res1 = qflint.sinpi(x1); break; }
                            case "oflint": { res1 = oflint.sinpi(x1); break; }
                            case "cflint": { res1 = cflint.sinpi(x1); break; }
                            case "mflint": { res1 = mflint.sinpi(x1); break; }
                            case "iflint": { res1 = iflint.sinpi(x1); break; }
                            case "aflint": { res1 = aflint.sinpi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sinpi({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("cospi"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.cospi(x1); break; }
                            case " sreal": { res1 = sreal.cospi(x1); break; }
                            case " dreal": { res1 = dreal.cospi(x1); break; }
                            case " ereal": { res1 = ereal.cospi(x1); break; }
                            case " qreal": { res1 = qreal.cospi(x1); break; }
                            case " oreal": { res1 = oreal.cospi(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.cospi(x1); break; }
                            //case " zreal": { res1 = zreal.cospi(x1); break; }
                            //case " creal": { res1 = creal.cospi(x1); break; }
                            case " mreal": { res1 = mreal.cospi(x1); break; }
                            case "sflint": { res1 = sflint.cospi(x1); break; }
                            case "dflint": { res1 = dflint.cospi(x1); break; }
                            case "eflint": { res1 = eflint.cospi(x1); break; }
                            case "qflint": { res1 = qflint.cospi(x1); break; }
                            case "oflint": { res1 = oflint.cospi(x1); break; }
                            case "cflint": { res1 = cflint.cospi(x1); break; }
                            case "mflint": { res1 = mflint.cospi(x1); break; }
                            case "iflint": { res1 = iflint.cospi(x1); break; }
                            case "aflint": { res1 = aflint.cospi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cospi({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("tanpi"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.tanpi(x1); break; }
                            case " sreal": { res1 = sreal.tanpi(x1); break; }
                            case " dreal": { res1 = dreal.tanpi(x1); break; }
                            case " ereal": { res1 = ereal.tanpi(x1); break; }
                            case " qreal": { res1 = qreal.tanpi(x1); break; }
                            case " oreal": { res1 = oreal.tanpi(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.tanpi(x1); break; }
                            //case " zreal": { res1 = zreal.tanpi(x1); break; }
                            //case " creal": { res1 = creal.tanpi(x1); break; }
                            case " mreal": { res1 = mreal.tanpi(x1); break; }
                            case "sflint": { res1 = sflint.tanpi(x1); break; }
                            case "dflint": { res1 = dflint.tanpi(x1); break; }
                            case "eflint": { res1 = eflint.tanpi(x1); break; }
                            case "qflint": { res1 = qflint.tanpi(x1); break; }
                            case "oflint": { res1 = oflint.tanpi(x1); break; }
                            case "cflint": { res1 = cflint.tanpi(x1); break; }
                            case "mflint": { res1 = mflint.tanpi(x1); break; }
                            case "iflint": { res1 = iflint.tanpi(x1); break; }
                            case "aflint": { res1 = aflint.tanpi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cospi({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cscpi"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.cscpi(x1); break; }
                            case " sreal": { res1 = sreal.cscpi(x1); break; }
                            case " dreal": { res1 = dreal.cscpi(x1); break; }
                            case " ereal": { res1 = ereal.cscpi(x1); break; }
                            case " qreal": { res1 = qreal.cscpi(x1); break; }
                            case " oreal": { res1 = oreal.cscpi(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.cscpi(x1); break; }
                            //case " zreal": { res1 = zreal.cscpi(x1); break; }
                            //case " creal": { res1 = creal.cscpi(x1); break; }
                            case " mreal": { res1 = mreal.cscpi(x1); break; }
                            case "sflint": { res1 = sflint.cscpi(x1); break; }
                            case "dflint": { res1 = dflint.cscpi(x1); break; }
                            case "eflint": { res1 = eflint.cscpi(x1); break; }
                            case "qflint": { res1 = qflint.cscpi(x1); break; }
                            case "oflint": { res1 = oflint.cscpi(x1); break; }
                            case "cflint": { res1 = cflint.cscpi(x1); break; }
                            case "mflint": { res1 = mflint.cscpi(x1); break; }
                            case "iflint": { res1 = iflint.cscpi(x1); break; }
                            case "aflint": { res1 = aflint.cscpi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cscpi({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("secpi"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.secpi(x1); break; }
                            case " sreal": { res1 = sreal.secpi(x1); break; }
                            case " dreal": { res1 = dreal.secpi(x1); break; }
                            case " ereal": { res1 = ereal.secpi(x1); break; }
                            case " qreal": { res1 = qreal.secpi(x1); break; }
                            case " oreal": { res1 = oreal.secpi(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.secpi(x1); break; }
                            //case " zreal": { res1 = zreal.secpi(x1); break; }
                            //case " creal": { res1 = creal.secpi(x1); break; }
                            case " mreal": { res1 = mreal.secpi(x1); break; }
                            case "sflint": { res1 = sflint.secpi(x1); break; }
                            case "dflint": { res1 = dflint.secpi(x1); break; }
                            case "eflint": { res1 = eflint.secpi(x1); break; }
                            case "qflint": { res1 = qflint.secpi(x1); break; }
                            case "oflint": { res1 = oflint.secpi(x1); break; }
                            case "cflint": { res1 = cflint.secpi(x1); break; }
                            case "mflint": { res1 = mflint.secpi(x1); break; }
                            case "iflint": { res1 = iflint.secpi(x1); break; }
                            case "aflint": { res1 = aflint.secpi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: secpi({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cotpi"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.cotpi(x1); break; }
                            case " sreal": { res1 = sreal.cotpi(x1); break; }
                            case " dreal": { res1 = dreal.cotpi(x1); break; }
                            case " ereal": { res1 = ereal.cotpi(x1); break; }
                            case " qreal": { res1 = qreal.cotpi(x1); break; }
                            case " oreal": { res1 = oreal.cotpi(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.cotpi(x1); break; }
                            //case " zreal": { res1 = zreal.cotpi(x1); break; }
                            //case " creal": { res1 = creal.cotpi(x1); break; }
                            case " mreal": { res1 = mreal.cotpi(x1); break; }
                            case "sflint": { res1 = sflint.cotpi(x1); break; }
                            case "dflint": { res1 = dflint.cotpi(x1); break; }
                            case "eflint": { res1 = eflint.cotpi(x1); break; }
                            case "qflint": { res1 = qflint.cotpi(x1); break; }
                            case "oflint": { res1 = oflint.cotpi(x1); break; }
                            case "cflint": { res1 = cflint.cotpi(x1); break; }
                            case "mflint": { res1 = mflint.cotpi(x1); break; }
                            case "iflint": { res1 = iflint.cotpi(x1); break; }
                            case "aflint": { res1 = aflint.cotpi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cotpi({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }





            if (FunctionArray.Contains("all") | FunctionArray.Contains("sincpi"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.sincpi(x1); break; }
                            case " sreal": { res1 = sreal.sincpi(x1); break; }
                            case " dreal": { res1 = dreal.sincpi(x1); break; }
                            case " ereal": { res1 = ereal.sincpi(x1); break; }
                            case " qreal": { res1 = qreal.sincpi(x1); break; }
                            case " oreal": { res1 = oreal.sincpi(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.sincpi(x1); break; }
                            //case " zreal": { res1 = zreal.sincpi(x1); break; }
                            //case " creal": { res1 = creal.sincpi(x1); break; }
                            case " mreal": { res1 = mreal.sincpi(x1); break; }
                            case "sflint": { res1 = sflint.sincpi(x1); break; }
                            case "dflint": { res1 = dflint.sincpi(x1); break; }
                            case "eflint": { res1 = eflint.sincpi(x1); break; }
                            case "qflint": { res1 = qflint.sincpi(x1); break; }
                            case "oflint": { res1 = oflint.sincpi(x1); break; }
                            case "cflint": { res1 = cflint.sincpi(x1); break; }
                            case "mflint": { res1 = mflint.sincpi(x1); break; }
                            case "iflint": { res1 = iflint.sincpi(x1); break; }
                            case "aflint": { res1 = aflint.sincpi(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sincpi({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Hyperbolic functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sinh"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.sinh(x1); break; }
                            case " sreal": { res1 = sreal.sinh(x1); break; }
                            case " dreal": { res1 = dreal.sinh(x1); break; }
                            case " ereal": { res1 = ereal.sinh(x1); break; }
                            case " qreal": { res1 = qreal.sinh(x1); break; }
                            case " oreal": { res1 = oreal.sinh(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.sinh(x1); break; }
                            case " zreal": { res1 = zreal.sinh(x1); break; }
                            case " creal": { res1 = creal.sinh(x1); break; }
                            case " mreal": { res1 = mreal.sinh(x1); break; }
                            case "sflint": { res1 = sflint.sinh(x1); break; }
                            case "dflint": { res1 = dflint.sinh(x1); break; }
                            case "eflint": { res1 = eflint.sinh(x1); break; }
                            case "qflint": { res1 = qflint.sinh(x1); break; }
                            case "oflint": { res1 = oflint.sinh(x1); break; }
                            case "cflint": { res1 = cflint.sinh(x1); break; }
                            case "mflint": { res1 = mflint.sinh(x1); break; }
                            case "iflint": { res1 = iflint.sinh(x1); break; }
                            case "aflint": { res1 = aflint.sinh(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sinh({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cosh"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.cosh(x1); break; }
                            case " sreal": { res1 = sreal.cosh(x1); break; }
                            case " dreal": { res1 = dreal.cosh(x1); break; }
                            case " ereal": { res1 = ereal.cosh(x1); break; }
                            case " qreal": { res1 = qreal.cosh(x1); break; }
                            case " oreal": { res1 = oreal.cosh(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.cosh(x1); break; }
                            case " zreal": { res1 = zreal.cosh(x1); break; }
                            case " creal": { res1 = creal.cosh(x1); break; }
                            case " mreal": { res1 = mreal.cosh(x1); break; }
                            case "sflint": { res1 = sflint.cosh(x1); break; }
                            case "dflint": { res1 = dflint.cosh(x1); break; }
                            case "eflint": { res1 = eflint.cosh(x1); break; }
                            case "qflint": { res1 = qflint.cosh(x1); break; }
                            case "oflint": { res1 = oflint.cosh(x1); break; }
                            case "cflint": { res1 = cflint.cosh(x1); break; }
                            case "mflint": { res1 = mflint.cosh(x1); break; }
                            case "iflint": { res1 = iflint.cosh(x1); break; }
                            case "aflint": { res1 = aflint.cosh(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cosh({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("tanh"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.tanh(x1); break; }
                            case " sreal": { res1 = sreal.tanh(x1); break; }
                            case " dreal": { res1 = dreal.tanh(x1); break; }
                            case " ereal": { res1 = ereal.tanh(x1); break; }
                            case " qreal": { res1 = qreal.tanh(x1); break; }
                            case " oreal": { res1 = oreal.tanh(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.tanh(x1); break; }
                            case " zreal": { res1 = zreal.tanh(x1); break; }
                            case " creal": { res1 = yreal.tanh(x1); break; }
                            case " mreal": { res1 = mreal.tanh(x1); break; }
                            case "sflint": { res1 = sflint.tanh(x1); break; }
                            case "dflint": { res1 = dflint.tanh(x1); break; }
                            case "eflint": { res1 = eflint.tanh(x1); break; }
                            case "qflint": { res1 = qflint.tanh(x1); break; }
                            case "oflint": { res1 = oflint.tanh(x1); break; }
                            case "cflint": { res1 = cflint.tanh(x1); break; }
                            case "mflint": { res1 = mflint.tanh(x1); break; }
                            case "iflint": { res1 = iflint.tanh(x1); break; }
                            case "aflint": { res1 = aflint.tanh(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: tanh({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("csch"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.csch(x1); break; }
                            case " sreal": { res1 = sreal.csch(x1); break; }
                            case " dreal": { res1 = dreal.csch(x1); break; }
                            case " ereal": { res1 = ereal.csch(x1); break; }
                            case " qreal": { res1 = qreal.csch(x1); break; }
                            case " oreal": { res1 = oreal.csch(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.csch(x1); break; }
                            //case " zreal": { res1 = zreal.csch(x1); break; }
                            //case " creal": { res1 = creal.csch(x1); break; }
                            case " mreal": { res1 = mreal.csch(x1); break; }
                            case "sflint": { res1 = sflint.csch(x1); break; }
                            case "dflint": { res1 = dflint.csch(x1); break; }
                            case "eflint": { res1 = eflint.csch(x1); break; }
                            case "qflint": { res1 = qflint.csch(x1); break; }
                            case "oflint": { res1 = oflint.csch(x1); break; }
                            case "cflint": { res1 = cflint.csch(x1); break; }
                            case "mflint": { res1 = mflint.csch(x1); break; }
                            case "iflint": { res1 = iflint.csch(x1); break; }
                            case "aflint": { res1 = aflint.csch(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: csch({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sech"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.sech(x1); break; }
                            case " sreal": { res1 = sreal.sech(x1); break; }
                            case " dreal": { res1 = dreal.sech(x1); break; }
                            case " ereal": { res1 = ereal.sech(x1); break; }
                            case " qreal": { res1 = qreal.sech(x1); break; }
                            case " oreal": { res1 = oreal.sech(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.sech(x1); break; }
                            //case " zreal": { res1 = zreal.sech(x1); break; }
                            //case " creal": { res1 = creal.sech(x1); break; }
                            case " mreal": { res1 = mreal.sech(x1); break; }
                            case "sflint": { res1 = sflint.sech(x1); break; }
                            case "dflint": { res1 = dflint.sech(x1); break; }
                            case "eflint": { res1 = eflint.sech(x1); break; }
                            case "qflint": { res1 = qflint.sech(x1); break; }
                            case "oflint": { res1 = oflint.sech(x1); break; }
                            case "cflint": { res1 = cflint.sech(x1); break; }
                            case "mflint": { res1 = mflint.sech(x1); break; }
                            case "iflint": { res1 = iflint.sech(x1); break; }
                            case "aflint": { res1 = aflint.sech(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: csch({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("coth"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.coth(x1); break; }
                            case " sreal": { res1 = sreal.coth(x1); break; }
                            case " dreal": { res1 = dreal.coth(x1); break; }
                            case " ereal": { res1 = ereal.coth(x1); break; }
                            case " qreal": { res1 = qreal.coth(x1); break; }
                            case " oreal": { res1 = oreal.coth(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.coth(x1); break; }
                            //case " zreal": { res1 = zreal.coth(x1); break; }
                            //case " creal": { res1 = creal.coth(x1); break; }
                            case " mreal": { res1 = mreal.coth(x1); break; }
                            case "sflint": { res1 = sflint.coth(x1); break; }
                            case "dflint": { res1 = dflint.coth(x1); break; }
                            case "eflint": { res1 = eflint.coth(x1); break; }
                            case "qflint": { res1 = qflint.coth(x1); break; }
                            case "oflint": { res1 = oflint.coth(x1); break; }
                            case "cflint": { res1 = cflint.coth(x1); break; }
                            case "mflint": { res1 = mflint.coth(x1); break; }
                            case "iflint": { res1 = iflint.coth(x1); break; }
                            case "aflint": { res1 = aflint.coth(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: coth({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }





            #endregion



            #region Inverse trigonometric functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("asin"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.asin(x1); break; }
                            case " sreal": { res1 = sreal.asin(x1); break; }
                            case " dreal": { res1 = dreal.asin(x1); break; }
                            case " ereal": { res1 = ereal.asin(x1); break; }
                            case " qreal": { res1 = qreal.asin(x1); break; }
                            case " oreal": { res1 = oreal.asin(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.asin(x1); break; }
                            case " zreal": { res1 = zreal.asin(x1); break; }
                            case " creal": { res1 = creal.asin(x1); break; }
                            case " mreal": { res1 = mreal.asin(x1); break; }
                            case "sflint": { res1 = sflint.asin(x1); break; }
                            case "dflint": { res1 = dflint.asin(x1); break; }
                            case "eflint": { res1 = eflint.asin(x1); break; }
                            case "qflint": { res1 = qflint.asin(x1); break; }
                            case "oflint": { res1 = oflint.asin(x1); break; }
                            case "cflint": { res1 = cflint.asin(x1); break; }
                            case "mflint": { res1 = mflint.asin(x1); break; }
                            case "iflint": { res1 = iflint.asin(x1); break; }
                            case "aflint": { res1 = aflint.asin(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: asin({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("acos"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.acos(x1); break; }
                            case " sreal": { res1 = sreal.acos(x1); break; }
                            case " dreal": { res1 = dreal.acos(x1); break; }
                            case " ereal": { res1 = ereal.acos(x1); break; }
                            case " qreal": { res1 = qreal.acos(x1); break; }
                            case " oreal": { res1 = oreal.acos(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.acos(x1); break; }
                            case " zreal": { res1 = zreal.acos(x1); break; }
                            case " creal": { res1 = creal.acos(x1); break; }
                            case " mreal": { res1 = mreal.acos(x1); break; }
                            case "sflint": { res1 = sflint.acos(x1); break; }
                            case "dflint": { res1 = dflint.acos(x1); break; }
                            case "eflint": { res1 = eflint.acos(x1); break; }
                            case "qflint": { res1 = qflint.acos(x1); break; }
                            case "oflint": { res1 = oflint.acos(x1); break; }
                            case "cflint": { res1 = cflint.acos(x1); break; }
                            case "mflint": { res1 = mflint.acos(x1); break; }
                            case "iflint": { res1 = iflint.acos(x1); break; }
                            case "aflint": { res1 = aflint.acos(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: acos({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("atan"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.atan(x1); break; }
                            case " sreal": { res1 = sreal.atan(x1); break; }
                            case " dreal": { res1 = dreal.atan(x1); break; }
                            case " ereal": { res1 = ereal.atan(x1); break; }
                            case " qreal": { res1 = qreal.atan(x1); break; }
                            case " oreal": { res1 = oreal.atan(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.atan(x1); break; }
                            case " zreal": { res1 = zreal.atan(x1); break; }
                            case " creal": { res1 = creal.atan(x1); break; }
                            case " mreal": { res1 = mreal.atan(x1); break; }
                            case "sflint": { res1 = sflint.atan(x1); break; }
                            case "dflint": { res1 = dflint.atan(x1); break; }
                            case "eflint": { res1 = eflint.atan(x1); break; }
                            case "qflint": { res1 = qflint.atan(x1); break; }
                            case "oflint": { res1 = oflint.atan(x1); break; }
                            case "cflint": { res1 = cflint.atan(x1); break; }
                            case "mflint": { res1 = mflint.atan(x1); break; }
                            case "iflint": { res1 = iflint.atan(x1); break; }
                            case "aflint": { res1 = aflint.atan(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: atan({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("atan2"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.atan2(x, y); break; }
                                case " sreal": { res1 = sreal.atan2(x, y); break; }
                                case " dreal": { res1 = dreal.atan2(x, y); break; }
                                case " ereal": { res1 = ereal.atan2(x, y); break; }
                                case " qreal": { res1 = qreal.atan2(x, y); break; }
                                case " oreal": { res1 = oreal.atan2(x, y); break; }
#if HasArbPrecNet
                                case " yreal": { res1 = yreal.atan2(x, y); break; }
                                case " zreal": { res1 = zreal.atan2(x, y); break; }
                                case " creal": { res1 = creal.atan2(x, y); break; }
                                case " mreal": { res1 = mreal.atan2(x, y); break; }
                                case "sflint": { res1 = sflint.atan2(x, y); break; }
                                case "dflint": { res1 = dflint.atan2(x, y); break; }
                                case "eflint": { res1 = eflint.atan2(x, y); break; }
                                case "qflint": { res1 = qflint.atan2(x, y); break; }
                                case "oflint": { res1 = oflint.atan2(x, y); break; }
                                case "cflint": { res1 = cflint.atan2(x, y); break; }
                                case "mflint": { res1 = mflint.atan2(x, y); break; }
                                case "iflint": { res1 = iflint.atan2(x, y); break; }
                                case "aflint": { res1 = aflint.atan2(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: atan2({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("acsc"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.acsc(x1); break; }
                            case " sreal": { res1 = sreal.acsc(x1); break; }
                            case " dreal": { res1 = dreal.acsc(x1); break; }
                            case " ereal": { res1 = ereal.acsc(x1); break; }
                            case " qreal": { res1 = qreal.acsc(x1); break; }
                            case " oreal": { res1 = oreal.acsc(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.acsc(x1); break; }
                            //case " zreal": { res1 = zreal.acsc(x1); break; }
                            //case " creal": { res1 = creal.acsc(x1); break; }
                            case " mreal": { res1 = mreal.acsc(x1); break; }
                            case "sflint": { res1 = sflint.acsc(x1); break; }
                            case "dflint": { res1 = dflint.acsc(x1); break; }
                            case "eflint": { res1 = eflint.acsc(x1); break; }
                            case "qflint": { res1 = qflint.acsc(x1); break; }
                            case "oflint": { res1 = oflint.acsc(x1); break; }
                            case "cflint": { res1 = cflint.acsc(x1); break; }
                            case "mflint": { res1 = mflint.acsc(x1); break; }
                            case "iflint": { res1 = iflint.acsc(x1); break; }
                            case "aflint": { res1 = aflint.acsc(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: asec({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("asec"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.asec(x1); break; }
                            case " sreal": { res1 = sreal.asec(x1); break; }
                            case " dreal": { res1 = dreal.asec(x1); break; }
                            case " ereal": { res1 = ereal.asec(x1); break; }
                            case " qreal": { res1 = qreal.asec(x1); break; }
                            case " oreal": { res1 = oreal.asec(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.asec(x1); break; }
                            //case " zreal": { res1 = zreal.asec(x1); break; }
                            //case " creal": { res1 = creal.asec(x1); break; }
                            case " mreal": { res1 = mreal.asec(x1); break; }
                            case "sflint": { res1 = sflint.asec(x1); break; }
                            case "dflint": { res1 = dflint.asec(x1); break; }
                            case "eflint": { res1 = eflint.asec(x1); break; }
                            case "qflint": { res1 = qflint.asec(x1); break; }
                            case "oflint": { res1 = oflint.asec(x1); break; }
                            case "cflint": { res1 = cflint.asec(x1); break; }
                            case "mflint": { res1 = mflint.asec(x1); break; }
                            case "iflint": { res1 = iflint.asec(x1); break; }
                            case "aflint": { res1 = aflint.asec(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: asec({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("acot"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.acot(x1); break; }
                            case " sreal": { res1 = sreal.acot(x1); break; }
                            case " dreal": { res1 = dreal.acot(x1); break; }
                            case " ereal": { res1 = ereal.acot(x1); break; }
                            case " qreal": { res1 = qreal.acot(x1); break; }
                            case " oreal": { res1 = oreal.acot(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.acot(x1); break; }
                            //case " zreal": { res1 = zreal.acot(x1); break; }
                            //case " creal": { res1 = creal.acot(x1); break; }
                            case " mreal": { res1 = mreal.acot(x1); break; }
                            case "sflint": { res1 = sflint.acot(x1); break; }
                            case "dflint": { res1 = dflint.acot(x1); break; }
                            case "eflint": { res1 = eflint.acot(x1); break; }
                            case "qflint": { res1 = qflint.acot(x1); break; }
                            case "oflint": { res1 = oflint.acot(x1); break; }
                            case "cflint": { res1 = cflint.acot(x1); break; }
                            case "mflint": { res1 = mflint.acot(x1); break; }
                            case "iflint": { res1 = iflint.acot(x1); break; }
                            case "aflint": { res1 = aflint.acot(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: acot({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            #endregion



            #region Inverse hyperbolic functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("asinh"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.asinh(x1); break; }
                            case " sreal": { res1 = sreal.asinh(x1); break; }
                            case " dreal": { res1 = dreal.asinh(x1); break; }
                            case " ereal": { res1 = ereal.asinh(x1); break; }
                            case " qreal": { res1 = qreal.asinh(x1); break; }
                            case " oreal": { res1 = oreal.asinh(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.asinh(x1); break; }
                            case " zreal": { res1 = zreal.asinh(x1); break; }
                            case " creal": { res1 = creal.asinh(x1); break; }
                            case " mreal": { res1 = mreal.asinh(x1); break; }
                            case "sflint": { res1 = sflint.asinh(x1); break; }
                            case "dflint": { res1 = dflint.asinh(x1); break; }
                            case "eflint": { res1 = eflint.asinh(x1); break; }
                            case "qflint": { res1 = qflint.asinh(x1); break; }
                            case "oflint": { res1 = oflint.asinh(x1); break; }
                            case "cflint": { res1 = cflint.asinh(x1); break; }
                            case "mflint": { res1 = mflint.asinh(x1); break; }
                            case "iflint": { res1 = iflint.asinh(x1); break; }
                            case "aflint": { res1 = aflint.asinh(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: asinh({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("acosh"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.acosh(x1); break; }
                            case " sreal": { res1 = sreal.acosh(x1); break; }
                            case " dreal": { res1 = dreal.acosh(x1); break; }
                            case " ereal": { res1 = ereal.acosh(x1); break; }
                            case " qreal": { res1 = qreal.acosh(x1); break; }
                            case " oreal": { res1 = oreal.acosh(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.acosh(x1); break; }
                            case " zreal": { res1 = zreal.acosh(x1); break; }
                            case " creal": { res1 = creal.acosh(x1); break; }
                            case " mreal": { res1 = mreal.acosh(x1); break; }
                            case "sflint": { res1 = sflint.acosh(x1); break; }
                            case "dflint": { res1 = dflint.acosh(x1); break; }
                            case "eflint": { res1 = eflint.acosh(x1); break; }
                            case "qflint": { res1 = qflint.acosh(x1); break; }
                            case "oflint": { res1 = oflint.acosh(x1); break; }
                            case "cflint": { res1 = cflint.acosh(x1); break; }
                            case "mflint": { res1 = mflint.acosh(x1); break; }
                            case "iflint": { res1 = iflint.acosh(x1); break; }
                            case "aflint": { res1 = aflint.acosh(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: acosh({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("atanh"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.atanh(x1); break; }
                            case " sreal": { res1 = sreal.atanh(x1); break; }
                            case " dreal": { res1 = dreal.atanh(x1); break; }
                            case " ereal": { res1 = ereal.atanh(x1); break; }
                            case " qreal": { res1 = qreal.atanh(x1); break; }
                            case " oreal": { res1 = oreal.atanh(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.atanh(x1); break; }
                            case " zreal": { res1 = zreal.atanh(x1); break; }
                            case " creal": { res1 = creal.atanh(x1); break; }
                            case " mreal": { res1 = mreal.atanh(x1); break; }
                            case "sflint": { res1 = sflint.atanh(x1); break; }
                            case "dflint": { res1 = dflint.atanh(x1); break; }
                            case "eflint": { res1 = eflint.atanh(x1); break; }
                            case "qflint": { res1 = qflint.atanh(x1); break; }
                            case "oflint": { res1 = oflint.atanh(x1); break; }
                            case "cflint": { res1 = cflint.atanh(x1); break; }
                            case "mflint": { res1 = mflint.atanh(x1); break; }
                            case "iflint": { res1 = iflint.atanh(x1); break; }
                            case "aflint": { res1 = aflint.atanh(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: atanh({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("acsch"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.acsch(x1); break; }
                            case " sreal": { res1 = sreal.acsch(x1); break; }
                            case " dreal": { res1 = dreal.acsch(x1); break; }
                            case " ereal": { res1 = ereal.acsch(x1); break; }
                            case " qreal": { res1 = qreal.acsch(x1); break; }
                            case " oreal": { res1 = oreal.acsch(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.acsch(x1); break; }
                            //case " zreal": { res1 = zreal.acsch(x1); break; }
                            //case " creal": { res1 = creal.acsch(x1); break; }
                            case " mreal": { res1 = mreal.acsch(x1); break; }
                            case "sflint": { res1 = sflint.acsch(x1); break; }
                            case "dflint": { res1 = dflint.acsch(x1); break; }
                            case "eflint": { res1 = eflint.acsch(x1); break; }
                            case "qflint": { res1 = qflint.acsch(x1); break; }
                            case "oflint": { res1 = oflint.acsch(x1); break; }
                            case "cflint": { res1 = cflint.acsch(x1); break; }
                            case "mflint": { res1 = mflint.acsch(x1); break; }
                            case "iflint": { res1 = iflint.acsch(x1); break; }
                            case "aflint": { res1 = aflint.acsch(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: acsch({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("asech"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.asech(x1); break; }
                            case " sreal": { res1 = sreal.asech(x1); break; }
                            case " dreal": { res1 = dreal.asech(x1); break; }
                            case " ereal": { res1 = ereal.asech(x1); break; }
                            case " qreal": { res1 = qreal.asech(x1); break; }
                            case " oreal": { res1 = oreal.asech(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.asech(x1); break; }
                            //case " zreal": { res1 = zreal.asech(x1); break; }
                            //case " creal": { res1 = creal.asech(x1); break; }
                            case " mreal": { res1 = mreal.asech(x1); break; }
                            case "sflint": { res1 = sflint.asech(x1); break; }
                            case "dflint": { res1 = dflint.asech(x1); break; }
                            case "eflint": { res1 = eflint.asech(x1); break; }
                            case "qflint": { res1 = qflint.asech(x1); break; }
                            case "oflint": { res1 = oflint.asech(x1); break; }
                            case "cflint": { res1 = cflint.asech(x1); break; }
                            case "mflint": { res1 = mflint.asech(x1); break; }
                            case "iflint": { res1 = iflint.asech(x1); break; }
                            case "aflint": { res1 = aflint.asech(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: asech({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("acoth"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.acoth(x1); break; }
                            case " sreal": { res1 = sreal.acoth(x1); break; }
                            case " dreal": { res1 = dreal.acoth(x1); break; }
                            case " ereal": { res1 = ereal.acoth(x1); break; }
                            case " qreal": { res1 = qreal.acoth(x1); break; }
                            case " oreal": { res1 = oreal.acoth(x1); break; }
#if HasArbPrecNet
                            case " yreal": { res1 = yreal.acoth(x1); break; }
                            //case " zreal": { res1 = zreal.acoth(x1); break; }
                            //case " creal": { res1 = creal.acoth(x1); break; }
                            case " mreal": { res1 = mreal.acoth(x1); break; }
                            case "sflint": { res1 = sflint.acoth(x1); break; }
                            case "dflint": { res1 = dflint.acoth(x1); break; }
                            case "eflint": { res1 = eflint.acoth(x1); break; }
                            case "qflint": { res1 = qflint.acoth(x1); break; }
                            case "oflint": { res1 = oflint.acoth(x1); break; }
                            case "cflint": { res1 = cflint.acoth(x1); break; }
                            case "mflint": { res1 = mflint.acoth(x1); break; }
                            case "iflint": { res1 = iflint.acoth(x1); break; }
                            case "aflint": { res1 = aflint.acoth(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: acoth({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion


        }



        public static void DemoChapterSpecialReal(string[] NumTypeArray, string[] FunctionArray)
        {

            double[] InputArray1;
            double[] InputArray2;
            double[] InputArray3;
            // Dim InputArray4 As Double()
            // Dim InputArrayInt1 As Integer()
            // Dim InputArrayInt2 As Integer()


            #region Error functions for real arguments

            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_erf"))
            {
                InputArray1 = new[] {dreal.neginf(), -4.333d, 0.0d, 4.333d, dreal.inf(), dreal.nan() };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.real_erf(x1); break; }
                            case " sreal": { res1 = sreal.real_erf(x1); break; }
                            case " dreal": { res1 = dreal.real_erf(x1); break; }
                            case " ereal": { res1 = ereal.real_erf(x1); break; }
                            case " qreal": { res1 = qreal.real_erf(x1); break; }
                            case " oreal": { res1 = oreal.real_erf(x1); break; }
                            case " yreal": { res1 = yreal.real_erf(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.real_erf(x1); break; }
                            case " creal": { res1 = creal.real_erf(x1); break; }
                            case "aflint": { res1 = aflint.real_erf(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: real_erfc({1}):" + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_erfc"))
            {
                InputArray1 = new[] { dreal.neginf(), -4.333d, 0.0d, 4.333d, dreal.inf(), dreal.nan() };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.real_erfc(x1); break; }
                            case " sreal": { res1 = sreal.real_erfc(x1); break; }
                            case " dreal": { res1 = dreal.real_erfc(x1); break; }
                            case " ereal": { res1 = ereal.real_erfc(x1); break; }
                            case " qreal": { res1 = qreal.real_erfc(x1); break; }
                            case " oreal": { res1 = oreal.real_erfc(x1); break; }
                            case " yreal": { res1 = yreal.real_erfc(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.real_erfc(x1); break; }
                            case " creal": { res1 = creal.real_erfc(x1); break; }
                            case "aflint": { res1 = aflint.real_erfc(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: real_erfc({1}):" + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_erf_inv"))
            {
                InputArray1 = new[] { -1.0, -0.999, -0.5, 0.0, 0.5, 0.999, 1.0};
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.real_erf_inv(x1); break; }
                            case " sreal": { res1 = sreal.real_erf_inv(x1); break; }
                            case " dreal": { res1 = dreal.real_erf_inv(x1); break; }
                            case " ereal": { res1 = ereal.real_erf_inv(x1); break; }
                            case " qreal": { res1 = qreal.real_erf_inv(x1); break; }
                            case " oreal": { res1 = oreal.real_erf_inv(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.real_erf_inv(x1); break; }
                            case " creal": { res1 = creal.real_erf_inv(x1); break; }
                            case "aflint": { res1 = aflint.real_erf_inv(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: real_erfc({1}):" + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_erfc_inv"))
            {
                InputArray1 = new[] {0.0, 0.001, 0.5, 1.0, 1.5, 1.999, 2.0 };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.real_erfc_inv(x1); break; }
                            case " sreal": { res1 = sreal.real_erfc_inv(x1); break; }
                            case " dreal": { res1 = dreal.real_erfc_inv(x1); break; }
                            case " ereal": { res1 = ereal.real_erfc_inv(x1); break; }
                            case " qreal": { res1 = qreal.real_erfc_inv(x1); break; }
                            case " oreal": { res1 = oreal.real_erfc_inv(x1); break; }
                            //case " yreal": { res1 = yreal.real_erfc_inv(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.real_erfc_inv(x1); break; }
                            case " creal": { res1 = creal.real_erfc_inv(x1); break; }
                            case "aflint": { res1 = aflint.real_erfc_inv(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: real_erfc({1}):" + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Gamma and related functions for real arguments and parameters



            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_gamma"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.real_gamma(x1); break; }
                            case " sreal": { res1 = sreal.real_gamma(x1); break; }
                            case " dreal": { res1 = dreal.real_gamma(x1); break; }
                            case " ereal": { res1 = ereal.real_gamma(x1); break; }
                            case " qreal": { res1 = qreal.real_gamma(x1); break; }
                            case " oreal": { res1 = oreal.real_gamma(x1); break; }
                            case " yreal": { res1 = yreal.real_gamma(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.real_gamma(x1); break; }
                            case " creal": { res1 = creal.real_gamma(x1); break; }
                            case "aflint": { res1 = aflint.real_gamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: real_gamma({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_gamma1pm1"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.real_gamma1pm1(x1); break; }
                            case " sreal": { res1 = sreal.real_gamma1pm1(x1); break; }
                            case " dreal": { res1 = dreal.real_gamma1pm1(x1); break; }
                            case " ereal": { res1 = ereal.real_gamma1pm1(x1); break; }
                            case " qreal": { res1 = qreal.real_gamma1pm1(x1); break; }
                            case " oreal": { res1 = oreal.real_gamma1pm1(x1); break; }
                            //case " yreal": { res1 = yreal.real_gamma1pm1(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.real_gamma1pm1(x1); break; }
                            case " creal": { res1 = creal.real_gamma1pm1(x1); break; }
                            case "aflint": { res1 = aflint.real_gamma1pm1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: real_gamma1pm1({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_lgamma"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.real_lgamma(x1); break; }
                            case " sreal": { res1 = sreal.real_lgamma(x1); break; }
                            case " dreal": { res1 = dreal.real_lgamma(x1); break; }
                            case " ereal": { res1 = ereal.real_lgamma(x1); break; }
                            case " qreal": { res1 = qreal.real_lgamma(x1); break; }
                            case " oreal": { res1 = oreal.real_lgamma(x1); break; }
                            case " yreal": { res1 = yreal.real_lgamma(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.real_lgamma(x1); break; }
                            case " creal": { res1 = creal.real_lgamma(x1); break; }
                            case "aflint": { res1 = aflint.real_lgamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: real_lgamma({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            // Inf and Nan lead to crashes; math53 needs to be moved to gamma
            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_factorial"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            //case "math53": { res1 = math53.real_factorial(x1); break; } //res1 = math53.factorial((int)Math.Round(x1));
                            case " sreal": { res1 = sreal.real_factorial(x1); break; }
                            case " dreal": { res1 = dreal.real_factorial(x1); break; }
                            case " ereal": { res1 = ereal.real_factorial(x1); break; }
                            case " qreal": { res1 = qreal.real_factorial(x1); break; }
                            case " oreal": { res1 = oreal.real_factorial(x1); break; }
                            //case " yreal": { res1 = yreal.real_factorial(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.real_factorial(x1); break; }
                            case " creal": { res1 = creal.real_factorial(x1); break; }
                            case "aflint": { res1 = aflint.real_factorial(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: real_factorial({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            // Inf and Nan lead to crashes; math53 needs to be moved to gamma
            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_doublefactorial"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            //case "math53": { res1 = math53.real_doublefactorial(x1); break; } //res1 = math53.real_doublefactorial((int)Math.Round(x1));
                            case " sreal": { res1 = sreal.real_doublefactorial(x1); break; }
                            case " dreal": { res1 = dreal.real_doublefactorial(x1); break; }
                            case " ereal": { res1 = ereal.real_doublefactorial(x1); break; }
                            case " qreal": { res1 = qreal.real_doublefactorial(x1); break; }
                            case " oreal": { res1 = oreal.real_doublefactorial(x1); break; }
                            //case " yreal": { res1 = yreal.real_doublefactorial(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.real_doublefactorial(x1); break; }
                            case " creal": { res1 = creal.real_doublefactorial(x1); break; }
                            case "aflint": { res1 = aflint.real_doublefactorial(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: real_doublefactorial({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_gamma_ratio"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.real_gamma_ratio(x, y); break; }
                                case " sreal": { res1 = sreal.real_gamma_ratio(x, y); break; }
                                case " dreal": { res1 = dreal.real_gamma_ratio(x, y); break; }
                                case " ereal": { res1 = ereal.real_gamma_ratio(x, y); break; }
                                case " qreal": { res1 = qreal.real_gamma_ratio(x, y); break; }
                                case " oreal": { res1 = oreal.real_gamma_ratio(x, y); break; }
                                //case " yreal": { res1 = yreal.real_gamma_ratio(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_gamma_ratio(x, y); break; }
                                case " creal": { res1 = creal.real_gamma_ratio(x, y); break; }
                                case "aflint": { res1 = aflint.real_gamma_ratio(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: real_gamma_ratio({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_gamma_delta_ratio"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.real_gamma_delta_ratio(x, y); break; }
                                case " sreal": { res1 = sreal.real_gamma_delta_ratio(x, y); break; }
                                case " dreal": { res1 = dreal.real_gamma_delta_ratio(x, y); break; }
                                case " ereal": { res1 = ereal.real_gamma_delta_ratio(x, y); break; }
                                case " qreal": { res1 = qreal.real_gamma_delta_ratio(x, y); break; }
                                case " oreal": { res1 = oreal.real_gamma_delta_ratio(x, y); break; }
                                //case " yreal": { res1 = yreal.real_gamma_delta_ratio(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_gamma_delta_ratio(x, y); break; }
                                case " creal": { res1 = creal.real_gamma_delta_ratio(x, y); break; }
                                case "aflint": { res1 = aflint.real_gamma_delta_ratio(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: real_gamma_delta_ratio({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_binomial"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                //case "math53": { res1 = math53.real_binomial(x, y); break; }
                                case " sreal": { res1 = sreal.real_binomial(x, y); break; }
                                case " dreal": { res1 = dreal.real_binomial(x, y); break; }
                                case " ereal": { res1 = ereal.real_binomial(x, y); break; }
                                case " qreal": { res1 = qreal.real_binomial(x, y); break; }
                                case " oreal": { res1 = oreal.real_binomial(x, y); break; }
                                //case " yreal": { res1 = yreal.real_binomial(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_binomial(x, y); break; }
                                case " creal": { res1 = creal.real_binomial(x, y); break; }
                                case "aflint": { res1 = aflint.real_binomial(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: binomial({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }

            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_rising_factorial"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.real_rising_factorial(x, y); break; }
                                case " sreal": { res1 = sreal.real_rising_factorial(x, y); break; }
                                case " dreal": { res1 = dreal.real_rising_factorial(x, y); break; }
                                case " ereal": { res1 = ereal.real_rising_factorial(x, y); break; }
                                case " qreal": { res1 = qreal.real_rising_factorial(x, y); break; }
                                case " oreal": { res1 = oreal.real_rising_factorial(x, y); break; }
                                //case " yreal": { res1 = yreal.real_rising_factorial(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_rising_factorial(x, y); break; }
                                case " creal": { res1 = creal.real_rising_factorial(x, y); break; }
                                case "aflint": { res1 = aflint.real_rising_factorial(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: real_rising_factorial({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_falling_factorial"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -4.333d, 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.real_falling_factorial(x, y); break; }
                                case " sreal": { res1 = sreal.real_falling_factorial(x, y); break; }
                                case " dreal": { res1 = dreal.real_falling_factorial(x, y); break; }
                                case " ereal": { res1 = ereal.real_falling_factorial(x, y); break; }
                                case " qreal": { res1 = qreal.real_falling_factorial(x, y); break; }
                                case " oreal": { res1 = oreal.real_falling_factorial(x, y); break; }
                                //case " yreal": { res1 = yreal.real_falling_factorial(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_falling_factorial(x, y); break; }
                                case " creal": { res1 = creal.real_falling_factorial(x, y); break; }
                                case "aflint": { res1 = aflint.real_falling_factorial(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: real_falling_factorial({1}, {2}): {3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_beta"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.real_beta(a, b); break; }
                                case " sreal": { res1 = sreal.real_beta(a, b); break; }
                                case " dreal": { res1 = dreal.real_beta(a, b); break; }
                                case " ereal": { res1 = ereal.real_beta(a, b); break; }
                                case " qreal": { res1 = qreal.real_beta(a, b); break; }
                                case " oreal": { res1 = oreal.real_beta(a, b); break; }
                                //case " yreal": { res1 = yreal.real_beta(a, b); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_beta(a, b); break; }
                                case " creal": { res1 = creal.real_beta(a, b); break; }
                                case "aflint": { res1 = aflint.real_beta(a, b); break; }
#endif
                            }
                            Console.WriteLine("{0}: real_beta(a={1}, b={2}): {3}", NumType, a, b, res1);
                        }
                    }
                }
                Console.WriteLine();
            }





            #endregion



            #region Incomplete gamma functions for real arguments and parameters


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_gamma_p"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.real_gamma_p(a, x); break; }
                                case " sreal": { res1 = sreal.real_gamma_p(a, x); break; }
                                case " dreal": { res1 = dreal.real_gamma_p(a, x); break; }
                                case " ereal": { res1 = ereal.real_gamma_p(a, x); break; }
                                case " qreal": { res1 = qreal.real_gamma_p(a, x); break; }
                                case " oreal": { res1 = oreal.real_gamma_p(a, x); break; }
                                //case " yreal": { res1 = yreal.real_gamma_p(a, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_gamma_p(a, x); break; }
                                case " creal": { res1 = creal.real_gamma_p(a, x); break; }
                                case "aflint": { res1 = aflint.real_gamma_p(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: real_gamma_p(a={1}, x={2}): {3}", NumType, a, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_gamma_q"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.real_gamma_q(a, x); break; }
                                case " sreal": { res1 = sreal.real_gamma_q(a, x); break; }
                                case " dreal": { res1 = dreal.real_gamma_q(a, x); break; }
                                case " ereal": { res1 = ereal.real_gamma_q(a, x); break; }
                                case " qreal": { res1 = qreal.real_gamma_q(a, x); break; }
                                case " oreal": { res1 = oreal.real_gamma_q(a, x); break; }
                                //case " yreal": { res1 = yreal.real_gamma_q(a, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_gamma_q(a, x); break; }
                                case " creal": { res1 = creal.real_gamma_q(a, x); break; }
                                case "aflint": { res1 = aflint.real_gamma_q(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: real_gamma_q(a={1}, x={2}): {3}", NumType, a, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_gamma_lower"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.real_gamma_lower(a, x); break; }
                                case " sreal": { res1 = sreal.real_gamma_lower(a, x); break; }
                                case " dreal": { res1 = dreal.real_gamma_lower(a, x); break; }
                                case " ereal": { res1 = ereal.real_gamma_lower(a, x); break; }
                                case " qreal": { res1 = qreal.real_gamma_lower(a, x); break; }
                                case " oreal": { res1 = oreal.real_gamma_lower(a, x); break; }
                                //case " yreal": { res1 = yreal.real_gamma_lower(a, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_gamma_lower(a, x); break; }
                                case " creal": { res1 = creal.real_gamma_lower(a, x); break; }
                                case "aflint": { res1 = aflint.real_gamma_lower(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: real_gamma_lower(a={1}, x={2}): {3}", NumType, a, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_gamma_upper"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.real_gamma_upper(a, x); break; }
                                case " sreal": { res1 = sreal.real_gamma_upper(a, x); break; }
                                case " dreal": { res1 = dreal.real_gamma_upper(a, x); break; }
                                case " ereal": { res1 = ereal.real_gamma_upper(a, x); break; }
                                case " qreal": { res1 = qreal.real_gamma_upper(a, x); break; }
                                case " oreal": { res1 = oreal.real_gamma_upper(a, x); break; }
                                //case " yreal": { res1 = yreal.real_gamma_upper(a, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_gamma_upper(a, x); break; }
                                case " creal": { res1 = creal.real_gamma_upper(a, x); break; }
                                case "aflint": { res1 = aflint.real_gamma_upper(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: real_gamma_upper(a={1}, x={2}): {3}", NumType, a, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_gamma_p_inv"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 0.0d, 0.25d, 0.75d, 1.0d };
                foreach (var a in InputArray1)
                {
                    foreach (var p in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.real_gamma_p_inv(a, p); break; }
                                case " sreal": { res1 = sreal.real_gamma_p_inv(a, p); break; }
                                case " dreal": { res1 = dreal.real_gamma_p_inv(a, p); break; }
                                case " ereal": { res1 = ereal.real_gamma_p_inv(a, p); break; }
                                case " qreal": { res1 = qreal.real_gamma_p_inv(a, p); break; }
                                case " oreal": { res1 = oreal.real_gamma_p_inv(a, p); break; }
                                //case " yreal": { res1 = yreal.real_gamma_p_inv(a, p); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_gamma_p_inv(a, p); break; }
                                case " creal": { res1 = creal.real_gamma_p_inv(a, p); break; }
                                case "aflint": { res1 = aflint.real_gamma_p_inv(a, p); break; }
#endif
                            }
                            Console.WriteLine("{0}: real_gamma_p_inv(a={1}, p={2}): {3}", NumType, a, p, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_gamma_q_inv"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 0.0d, 0.25d, 0.75d, 1.0d };
                foreach (var a in InputArray1)
                {
                    foreach (var q in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.real_gamma_q_inv(a, q); break; }
                                case " sreal": { res1 = sreal.real_gamma_q_inv(a, q); break; }
                                case " dreal": { res1 = dreal.real_gamma_q_inv(a, q); break; }
                                case " ereal": { res1 = ereal.real_gamma_q_inv(a, q); break; }
                                case " qreal": { res1 = qreal.real_gamma_q_inv(a, q); break; }
                                case " oreal": { res1 = oreal.real_gamma_q_inv(a, q); break; }
                                //case " yreal": { res1 = yreal.real_gamma_q_inv(a, q); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_gamma_q_inv(a, q); break; }
                                case " creal": { res1 = creal.real_gamma_q_inv(a, q); break; }
                                case "aflint": { res1 = aflint.real_gamma_q_inv(a, q); break; }
#endif
                            }
                            Console.WriteLine("{0}: real_gamma_q_inv(a={1}, p={2}): {3}", NumType, a, q, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_gamma_p_inva"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 0.0d, 0.25d, 0.75d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var p in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.real_gamma_p_inva(x, p); break; }
                                case " sreal": { res1 = sreal.real_gamma_p_inva(x, p); break; }
                                case " dreal": { res1 = dreal.real_gamma_p_inva(x, p); break; }
                                case " ereal": { res1 = ereal.real_gamma_p_inva(x, p); break; }
                                case " qreal": { res1 = qreal.real_gamma_p_inva(x, p); break; }
                                case " oreal": { res1 = oreal.real_gamma_p_inva(x, p); break; }
                                //case " yreal": { res1 = yreal.real_gamma_p_inva(x, p); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_gamma_p_inva(x, p); break; }
                                case " creal": { res1 = creal.real_gamma_p_inva(x, p); break; }
                                case "aflint": { res1 = aflint.real_gamma_p_inva(x, p); break; }
#endif
                            }
                            Console.WriteLine("{0}: real_gamma_p_inva(x={1}, p={2}): {3}", NumType, x, p, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_gamma_p_prime"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.real_gamma_p_prime(a, x); break; }
                                case " sreal": { res1 = sreal.real_gamma_p_prime(a, x); break; }
                                case " dreal": { res1 = dreal.real_gamma_p_prime(a, x); break; }
                                case " ereal": { res1 = ereal.real_gamma_p_prime(a, x); break; }
                                case " qreal": { res1 = qreal.real_gamma_p_prime(a, x); break; }
                                case " oreal": { res1 = oreal.real_gamma_p_prime(a, x); break; }
                                //case " yreal": { res1 = yreal.real_gamma_p_prime(a, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.real_gamma_p_prime(a, x); break; }
                                case " creal": { res1 = creal.real_gamma_p_prime(a, x); break; }
                                case "aflint": { res1 = aflint.real_gamma_p_prime(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: real_gamma_p_prime(a={1}, x={2}): {3}", NumType, a, x, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion



            #region Incomplete beta functions for real arguments and parameters


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_ibeta"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
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
                                    case "math53": { res1 = math53.real_ibeta(a, b, x); break; }
                                    case " sreal": { res1 = sreal.real_ibeta(a, b, x); break; }
                                    case " dreal": { res1 = dreal.real_ibeta(a, b, x); break; }
                                    case " ereal": { res1 = ereal.real_ibeta(a, b, x); break; }
                                    case " qreal": { res1 = qreal.real_ibeta(a, b, x); break; }
                                    case " oreal": { res1 = oreal.real_ibeta(a, b, x); break; }
                                    //case " yreal": { res1 = yreal.real_ibeta(a, b, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.real_ibeta(a, b, x); break; }
                                    case " creal": { res1 = creal.real_ibeta(a, b, x); break; }
                                    case "aflint": { res1 = aflint.real_ibeta(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: real_ibeta(a={1}, b={2}, x={3}): {4}", NumType, a, b, x, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_ibetac"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
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
                                    case "math53": { res1 = math53.real_ibetac(a, b, x); break; }
                                    case " sreal": { res1 = sreal.real_ibetac(a, b, x); break; }
                                    case " dreal": { res1 = dreal.real_ibetac(a, b, x); break; }
                                    case " ereal": { res1 = ereal.real_ibetac(a, b, x); break; }
                                    case " qreal": { res1 = qreal.real_ibetac(a, b, x); break; }
                                    case " oreal": { res1 = oreal.real_ibetac(a, b, x); break; }
                                    //case " yreal": { res1 = yreal.real_ibetac(a, b, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.real_ibetac(a, b, x); break; }
                                    case " creal": { res1 = creal.real_ibetac(a, b, x); break; }
                                    case "aflint": { res1 = aflint.real_ibetac(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: real_ibetac(a={1}, b={2}, x={3}): {4}", NumType, a, b, x, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_beta_lower"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
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
                                    case "math53": { res1 = math53.real_beta_lower(a, b, x); break; }
                                    case " sreal": { res1 = sreal.real_beta_lower(a, b, x); break; }
                                    case " dreal": { res1 = dreal.real_beta_lower(a, b, x); break; }
                                    case " ereal": { res1 = ereal.real_beta_lower(a, b, x); break; }
                                    case " qreal": { res1 = qreal.real_beta_lower(a, b, x); break; }
                                    case " oreal": { res1 = oreal.real_beta_lower(a, b, x); break; }
                                    //case " yreal": { res1 = yreal.real_beta_lower(a, b, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.real_beta_lower(a, b, x); break; }
                                    case " creal": { res1 = creal.real_beta_lower(a, b, x); break; }
                                    case "aflint": { res1 = aflint.real_beta_lower(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: real_beta_lower(a={1}, b={2}, x={3}): {4}", NumType, a, b, x, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_beta_upper"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
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
                                    case "math53": { res1 = math53.real_beta_upper(a, b, x); break; }
                                    case " sreal": { res1 = sreal.real_beta_upper(a, b, x); break; }
                                    case " dreal": { res1 = dreal.real_beta_upper(a, b, x); break; }
                                    case " ereal": { res1 = ereal.real_beta_upper(a, b, x); break; }
                                    case " qreal": { res1 = qreal.real_beta_upper(a, b, x); break; }
                                    case " oreal": { res1 = oreal.real_beta_upper(a, b, x); break; }
                                    //case " yreal": { res1 = yreal.real_beta_upper(a, b, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.real_beta_upper(a, b, x); break; }
                                    case " creal": { res1 = creal.real_beta_upper(a, b, x); break; }
                                    case "aflint": { res1 = aflint.real_beta_upper(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: real_beta_upper(a={1}, b={2}, x={3}): {4}", NumType, a, b, x, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_ibeta_inv"))
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
                                    case "math53": { res1 = math53.real_ibeta_inv(a, b, p); break; }
                                    case " sreal": { res1 = sreal.real_ibeta_inv(a, b, p); break; }
                                    case " dreal": { res1 = dreal.real_ibeta_inv(a, b, p); break; }
                                    case " ereal": { res1 = ereal.real_ibeta_inv(a, b, p); break; }
                                    case " qreal": { res1 = qreal.real_ibeta_inv(a, b, p); break; }
                                    case " oreal": { res1 = oreal.real_ibeta_inv(a, b, p); break; }
                                    //case " yreal": { res1 = yreal.real_ibeta_inv(a, b, p); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.real_ibeta_inv(a, b, p); break; }
                                    case " creal": { res1 = creal.real_ibeta_inv(a, b, p); break; }
                                    case "aflint": { res1 = aflint.real_ibeta_inv(a, b, p); break; }
#endif
                                }
                                Console.WriteLine("{0}: real_ibeta_inv(a={1}, b={2}, p={3}): {4}", NumType, a, b, p, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_ibetac_inv"))
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
                                    case "math53": { res1 = math53.real_ibetac_inv(a, b, p); break; }
                                    case " sreal": { res1 = sreal.real_ibetac_inv(a, b, p); break; }
                                    case " dreal": { res1 = dreal.real_ibetac_inv(a, b, p); break; }
                                    case " ereal": { res1 = ereal.real_ibetac_inv(a, b, p); break; }
                                    case " qreal": { res1 = qreal.real_ibetac_inv(a, b, p); break; }
                                    case " oreal": { res1 = oreal.real_ibetac_inv(a, b, p); break; }
                                    //case " yreal": { res1 = yreal.real_ibetac_inv(a, b, p); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.real_ibetac_inv(a, b, p); break; }
                                    case " creal": { res1 = mreal.real_ibetac_inv(a, b, p); break; }
                                    case "aflint": { res1 = aflint.real_ibetac_inv(a, b, p); break; }
#endif
                                }
                                Console.WriteLine("{0}: real_ibetac_inv(a={1}, b={2}, p={3}): {4}", NumType, a, b, p, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_ibeta_inva"))
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
                                    case "math53": { res1 = math53.real_ibeta_inva(b, x, p); break; }
                                    case " sreal": { res1 = sreal.real_ibeta_inva(b, x, p); break; }
                                    case " dreal": { res1 = dreal.real_ibeta_inva(b, x, p); break; }
                                    case " ereal": { res1 = ereal.real_ibeta_inva(b, x, p); break; }
                                    case " qreal": { res1 = qreal.real_ibeta_inva(b, x, p); break; }
                                    case " oreal": { res1 = oreal.real_ibeta_inva(b, x, p); break; }
                                    //case " yreal": { res1 = yreal.real_ibeta_inva(b, x, p); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.real_ibeta_inva(b, x, p); break; }
                                    case " creal": { res1 = creal.real_ibeta_inva(b, x, p); break; }
                                    case "aflint": { res1 = aflint.real_ibeta_inva(b, x, p); break; }
#endif
                                }
                                Console.WriteLine("{0}: real_ibeta_inva(b={1}, x={2}, p={3}): {4}", NumType, b, x, p, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_ibetac_inva"))
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
                                    case "math53": { res1 = math53.real_ibetac_inva(b, x, p); break; }
                                    case " sreal": { res1 = sreal.real_ibetac_inva(b, x, p); break; }
                                    case " dreal": { res1 = dreal.real_ibetac_inva(b, x, p); break; }
                                    case " ereal": { res1 = ereal.real_ibetac_inva(b, x, p); break; }
                                    case " qreal": { res1 = qreal.real_ibetac_inva(b, x, p); break; }
                                    case " oreal": { res1 = oreal.real_ibetac_inva(b, x, p); break; }
                                    //case " yreal": { res1 = yreal.real_ibetac_inva(b, x, p); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.real_ibetac_inva(b, x, p); break; }
                                    case " creal": { res1 = creal.real_ibetac_inva(b, x, p); break; }
                                    case "aflint": { res1 = aflint.real_ibetac_inva(b, x, p); break; }
#endif
                                }
                                Console.WriteLine("{0}: real_ibetac_inva(b={1}, x={2}, p={3}): {4}", NumType, b, x, p, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_ibeta_invb"))
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
                                    case "math53": { res1 = math53.real_ibeta_invb(a, x, p); break; }
                                    case " sreal": { res1 = sreal.real_ibeta_invb(a, x, p); break; }
                                    case " dreal": { res1 = dreal.real_ibeta_invb(a, x, p); break; }
                                    case " ereal": { res1 = ereal.real_ibeta_invb(a, x, p); break; }
                                    case " qreal": { res1 = qreal.real_ibeta_invb(a, x, p); break; }
                                    case " oreal": { res1 = oreal.real_ibeta_invb(a, x, p); break; }
                                    //case " yreal": { res1 = yreal.real_ibeta_invb(a, x, p); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.real_ibeta_invb(a, x, p); break; }
                                    case " creal": { res1 = creal.real_ibeta_invb(a, x, p); break; }
                                    case "aflint": { res1 = aflint.real_ibeta_invb(a, x, p); break; }
#endif
                                }
                                Console.WriteLine("{0}: real_ibeta_invb(a={1}, x={2}, p={3}): {4}", NumType, a, x, p, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_ibetac_invb"))
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
                                    case "math53": { res1 = math53.real_ibetac_invb(a, x, p); break; }
                                    case " sreal": { res1 = sreal.real_ibetac_invb(a, x, p); break; }
                                    case " dreal": { res1 = dreal.real_ibetac_invb(a, x, p); break; }
                                    case " ereal": { res1 = ereal.real_ibetac_invb(a, x, p); break; }
                                    case " qreal": { res1 = qreal.real_ibetac_invb(a, x, p); break; }
                                    case " oreal": { res1 = oreal.real_ibetac_invb(a, x, p); break; }
                                    //case " yreal": { res1 = yreal.real_ibetac_invb(a, x, p); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.real_ibetac_invb(a, x, p); break; }
                                    case " creal": { res1 = creal.real_ibetac_invb(a, x, p); break; }
                                    case "aflint": { res1 = aflint.real_ibetac_invb(a, x, p); break; }
#endif
                                }
                                Console.WriteLine("{0}: real_ibetac_invb(a={1}, x={2}, p={3}): {4}", NumType, a, x, p, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("real_ibeta_prime"))
            {
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { 0.01d, 0.5d, 1.0d - 0.001d };
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
                                    case "math53": { res1 = math53.real_ibeta_prime(a, b, x); break; }
                                    case " sreal": { res1 = sreal.real_ibeta_prime(a, b, x); break; }
                                    case " dreal": { res1 = dreal.real_ibeta_prime(a, b, x); break; }
                                    case " ereal": { res1 = ereal.real_ibeta_prime(a, b, x); break; }
                                    case " qreal": { res1 = qreal.real_ibeta_prime(a, b, x); break; }
                                    case " oreal": { res1 = oreal.real_ibeta_prime(a, b, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.real_ibeta_prime(a, b, x); break; }
                                    case " creal": { res1 = creal.real_ibeta_prime(a, b, x); break; }
                                    case "aflint": { res1 = aflint.real_ibeta_prime(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: real_ibeta_prime(a={1}, b={2}, x={3}): {4}", NumType, a, b, x, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Miscellaneous real functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("owen_t"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var h in InputArray1)
                {
                    foreach (var a in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.owen_t(h, a); break; }
                                case " sreal": { res1 = sreal.owen_t(h, a); break; }
                                case " dreal": { res1 = dreal.owen_t(h, a); break; }
                                case " ereal": { res1 = ereal.owen_t(h, a); break; }
                                case " qreal": { res1 = qreal.owen_t(h, a); break; }
                                case " oreal": { res1 = oreal.owen_t(h, a); break; }
                                //case " yreal": { res1 = yreal.owen_t(h, a); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.owen_t(h, a); break; }
                                case " creal": { res1 = creal.owen_t(h, a); break; }
                                case "aflint": { res1 = aflint.owen_t(h, a); break; }
#endif
                            }
                            Console.WriteLine("{0}: owen_t(h={1}, a={2}): {3}", NumType, h, a, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion


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








        public static void RunTestsBoostFunc()
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
            string[] FunctionArray = new[] { "real_erfc_inv" };

            //DemoChapterBasicFloatingPoint(NumTypeArray, FunctionArray);
            //DemoChapterElementary(NumTypeArray, FunctionArray);
            DemoChapterSpecialReal(NumTypeArray, FunctionArray);
            // DemoChapterElliptic(NumTypeArray, FunctionArray);
            // DemoChapterLerchPhi(NumTypeArray, FunctionArray);
            // DemoChapter0F1(NumTypeArray, FunctionArray);
            // DemoChapter1F1(NumTypeArray, FunctionArray);
            //DemoChapterpFq(NumTypeArray, FunctionArray);

        }



        public static void Test_BoostFunctions()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTestsBoostFunc();
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