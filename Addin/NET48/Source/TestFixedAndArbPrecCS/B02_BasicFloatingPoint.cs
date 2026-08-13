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
                                    case " mreal": { res1 = mreal.fma(x, y, z); break; }
                                    case "sflint": { res1 = sflint.fma(x, y, z); break; }
                                    case "dflint": { res1 = dflint.fma(x, y, z); break; }
                                    case "eflint": { res1 = eflint.fma(x, y, z); break; }
                                    case "qflint": { res1 = qflint.fma(x, y, z); break; }
                                    case "oflint": { res1 = oflint.fma(x, y, z); break; }
                                    case "mflint": { res1 = mflint.fma(x, y, z); break; }
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
                                case " mreal": { res1 = mreal.fmax(x, y); break; }
                                case "sflint": { res1 = sflint.fmax(x, y); break; }
                                case "dflint": { res1 = dflint.fmax(x, y); break; }
                                case "eflint": { res1 = eflint.fmax(x, y); break; }
                                case "qflint": { res1 = qflint.fmax(x, y); break; }
                                case "oflint": { res1 = oflint.fmax(x, y); break; }
                                case "mflint": { res1 = mflint.fmax(x, y); break; }
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
                                case " mreal": { res1 = mreal.fmin(x, y); break; }
                                case "sflint": { res1 = sflint.fmin(x, y); break; }
                                case "dflint": { res1 = dflint.fmin(x, y); break; }
                                case "eflint": { res1 = eflint.fmin(x, y); break; }
                                case "qflint": { res1 = qflint.fmin(x, y); break; }
                                case "oflint": { res1 = oflint.fmin(x, y); break; }
                                case "mflint": { res1 = mflint.fmin(x, y); break; }
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
                        case " mreal": { res1 = mreal.zero(); break; }
                        case "sflint": { res1 = sflint.zero(); break; }
                        case "dflint": { res1 = dflint.zero(); break; }
                        case "eflint": { res1 = eflint.zero(); break; }
                        case "qflint": { res1 = qflint.zero(); break; }
                        case "oflint": { res1 = oflint.zero(); break; }
                        case "mflint": { res1 = mflint.zero(); break; }
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
                        case " mreal": { res1 = mreal.negzero(); break; }
                        case "sflint": { res1 = sflint.negzero(); break; }
                        case "dflint": { res1 = dflint.negzero(); break; }
                        case "eflint": { res1 = eflint.negzero(); break; }
                        case "qflint": { res1 = qflint.negzero(); break; }
                        case "oflint": { res1 = oflint.negzero(); break; }
                        case "mflint": { res1 = mflint.negzero(); break; }
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
                        case " mreal": { res1 = mreal.one(); break; }
                        case "sflint": { res1 = sflint.one(); break; }
                        case "dflint": { res1 = dflint.one(); break; }
                        case "eflint": { res1 = eflint.one(); break; }
                        case "qflint": { res1 = qflint.one(); break; }
                        case "oflint": { res1 = oflint.one(); break; }
                        case "mflint": { res1 = mflint.one(); break; }
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
                        case " mreal": { res1 = mreal.inf(); break; }
                        case "sflint": { res1 = sflint.inf(); break; }
                        case "dflint": { res1 = dflint.inf(); break; }
                        case "eflint": { res1 = eflint.inf(); break; }
                        case "qflint": { res1 = qflint.inf(); break; }
                        case "oflint": { res1 = oflint.inf(); break; }
                        case "mflint": { res1 = mflint.inf(); break; }
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
                        case " mreal": { res1 = mreal.neginf(); break; }
                        case "sflint": { res1 = sflint.neginf(); break; }
                        case "dflint": { res1 = dflint.neginf(); break; }
                        case "eflint": { res1 = eflint.neginf(); break; }
                        case "qflint": { res1 = qflint.neginf(); break; }
                        case "oflint": { res1 = oflint.neginf(); break; }
                        case "mflint": { res1 = mflint.neginf(); break; }
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
                        case " mreal": { res1 = mreal.nan(); break; }
                        case "sflint": { res1 = sflint.nan(); break; }
                        case "dflint": { res1 = dflint.nan(); break; }
                        case "eflint": { res1 = eflint.nan(); break; }
                        case "qflint": { res1 = qflint.nan(); break; }
                        case "oflint": { res1 = oflint.nan(); break; }
                        case "mflint": { res1 = mflint.nan(); break; }
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
                            case " mreal": { res1 = mreal.signbit(x1); break; }
                            case "sflint": { res1 = sflint.signbit(x1); break; }
                            case "dflint": { res1 = dflint.signbit(x1); break; }
                            case "eflint": { res1 = eflint.signbit(x1); break; }
                            case "qflint": { res1 = qflint.signbit(x1); break; }
                            case "oflint": { res1 = oflint.signbit(x1); break; }
                            case "mflint": { res1 = mflint.signbit(x1); break; }
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
                            case " mreal": { res1 = mreal.isfinite(x1); break; }
                            case "sflint": { res1 = sflint.isfinite(x1); break; }
                            case "dflint": { res1 = dflint.isfinite(x1); break; }
                            case "eflint": { res1 = eflint.isfinite(x1); break; }
                            case "qflint": { res1 = qflint.isfinite(x1); break; }
                            case "oflint": { res1 = oflint.isfinite(x1); break; }
                            case "mflint": { res1 = mflint.isfinite(x1); break; }
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
                            case " mreal": { res1 = mreal.isinf(x1); break; }
                            case "sflint": { res1 = sflint.isinf(x1); break; }
                            case "dflint": { res1 = dflint.isinf(x1); break; }
                            case "eflint": { res1 = eflint.isinf(x1); break; }
                            case "qflint": { res1 = qflint.isinf(x1); break; }
                            case "oflint": { res1 = oflint.isinf(x1); break; }
                            case "mflint": { res1 = mflint.isinf(x1); break; }
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
                            case " mreal": { res1 = mreal.isposinf(x1); break; }
                            case "sflint": { res1 = sflint.isposinf(x1); break; }
                            case "dflint": { res1 = dflint.isposinf(x1); break; }
                            case "eflint": { res1 = eflint.isposinf(x1); break; }
                            case "qflint": { res1 = qflint.isposinf(x1); break; }
                            case "oflint": { res1 = oflint.isposinf(x1); break; }
                            case "mflint": { res1 = mflint.isposinf(x1); break; }
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
                            case " mreal": { res1 = mreal.isneginf(x1); break; }
                            case "sflint": { res1 = sflint.isneginf(x1); break; }
                            case "dflint": { res1 = dflint.isneginf(x1); break; }
                            case "eflint": { res1 = eflint.isneginf(x1); break; }
                            case "qflint": { res1 = qflint.isneginf(x1); break; }
                            case "oflint": { res1 = oflint.isneginf(x1); break; }
                            case "mflint": { res1 = mflint.isneginf(x1); break; }
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
                            case " mreal": { res1 = mreal.isnan(x1); break; }
                            case "sflint": { res1 = sflint.isnan(x1); break; }
                            case "dflint": { res1 = dflint.isnan(x1); break; }
                            case "eflint": { res1 = eflint.isnan(x1); break; }
                            case "qflint": { res1 = qflint.isnan(x1); break; }
                            case "oflint": { res1 = oflint.isnan(x1); break; }
                            case "mflint": { res1 = mflint.isnan(x1); break; }
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
                            case " mreal": { res1 = mreal.iszero(x1); break; }
                            case "sflint": { res1 = sflint.iszero(x1); break; }
                            case "dflint": { res1 = dflint.iszero(x1); break; }
                            case "eflint": { res1 = eflint.iszero(x1); break; }
                            case "qflint": { res1 = qflint.iszero(x1); break; }
                            case "oflint": { res1 = oflint.iszero(x1); break; }
                            case "mflint": { res1 = mflint.iszero(x1); break; }
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
                            case " mreal": { res1 = mreal.isone(x1); break; }
                            case "sflint": { res1 = sflint.isone(x1); break; }
                            case "dflint": { res1 = dflint.isone(x1); break; }
                            case "eflint": { res1 = eflint.isone(x1); break; }
                            case "qflint": { res1 = qflint.isone(x1); break; }
                            case "oflint": { res1 = oflint.isone(x1); break; }
                            case "mflint": { res1 = mflint.isone(x1); break; }
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
                            case " mreal": { res1 = mreal.isinteger(x1); break; }
                            case "sflint": { res1 = sflint.isinteger(x1); break; }
                            case "dflint": { res1 = dflint.isinteger(x1); break; }
                            case "eflint": { res1 = eflint.isinteger(x1); break; }
                            case "qflint": { res1 = qflint.isinteger(x1); break; }
                            case "oflint": { res1 = oflint.isinteger(x1); break; }
                            case "mflint": { res1 = mflint.isinteger(x1); break; }
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
                            case " mreal": { res1 = mreal.isnumber(x1); break; }
                            case "sflint": { res1 = sflint.isnumber(x1); break; }
                            case "dflint": { res1 = dflint.isnumber(x1); break; }
                            case "eflint": { res1 = eflint.isnumber(x1); break; }
                            case "qflint": { res1 = qflint.isnumber(x1); break; }
                            case "oflint": { res1 = oflint.isnumber(x1); break; }
                            case "mflint": { res1 = mflint.isnumber(x1); break; }
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
                            case " mreal": { res1 = mreal.isregular(x1); break; }
                            case "sflint": { res1 = sflint.isregular(x1); break; }
                            case "dflint": { res1 = dflint.isregular(x1); break; }
                            case "eflint": { res1 = eflint.isregular(x1); break; }
                            case "qflint": { res1 = qflint.isregular(x1); break; }
                            case "oflint": { res1 = oflint.isregular(x1); break; }
                            case "mflint": { res1 = mflint.isregular(x1); break; }
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
                            case " mreal": { res1 = mreal.isnormal(x1); break; }
                            case "sflint": { res1 = sflint.isnormal(x1); break; }
                            case "dflint": { res1 = dflint.isnormal(x1); break; }
                            case "eflint": { res1 = eflint.isnormal(x1); break; }
                            case "qflint": { res1 = qflint.isnormal(x1); break; }
                            case "oflint": { res1 = oflint.isnormal(x1); break; }
                            case "mflint": { res1 = mflint.isnormal(x1); break; }
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
                                case " mreal": { res1 = mreal.isunordered(x, y); break; }
                                case "sflint": { res1 = sflint.isunordered(x, y); break; }
                                case "dflint": { res1 = dflint.isunordered(x, y); break; }
                                case "eflint": { res1 = eflint.isunordered(x, y); break; }
                                case "qflint": { res1 = qflint.isunordered(x, y); break; }
                                case "oflint": { res1 = oflint.isunordered(x, y); break; }
                                case "mflint": { res1 = mflint.isunordered(x, y); break; }
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
                            case " mreal": { res1 = mreal.fitsint32(x1); break; }
                            case "sflint": { res1 = sflint.fitsint32(x1); break; }
                            case "dflint": { res1 = dflint.fitsint32(x1); break; }
                            case "eflint": { res1 = eflint.fitsint32(x1); break; }
                            case "qflint": { res1 = qflint.fitsint32(x1); break; }
                            case "oflint": { res1 = oflint.fitsint32(x1); break; }
                            case "mflint": { res1 = mflint.fitsint32(x1); break; }
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
                            case " mreal": { res1 = mreal.fitsint64(x1); break; }
                            case "sflint": { res1 = sflint.fitsint64(x1); break; }
                            case "dflint": { res1 = dflint.fitsint64(x1); break; }
                            case "eflint": { res1 = eflint.fitsint64(x1); break; }
                            case "qflint": { res1 = qflint.fitsint64(x1); break; }
                            case "oflint": { res1 = oflint.fitsint64(x1); break; }
                            case "mflint": { res1 = mflint.fitsint64(x1); break; }
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
                            case " mreal": { res1 = mreal.nearbyint(x1); break; }
                            case "sflint": { res1 = sflint.nearbyint(x1); break; }
                            case "dflint": { res1 = dflint.nearbyint(x1); break; }
                            case "eflint": { res1 = eflint.nearbyint(x1); break; }
                            case "qflint": { res1 = qflint.nearbyint(x1); break; }
                            case "oflint": { res1 = oflint.nearbyint(x1); break; }
                            case "mflint": { res1 = mflint.nearbyint(x1); break; }
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
                            case " mreal": { res1 = mreal.rint(x1); break; }
                            case "sflint": { res1 = sflint.rint(x1); break; }
                            case "dflint": { res1 = dflint.rint(x1); break; }
                            case "eflint": { res1 = eflint.rint(x1); break; }
                            case "qflint": { res1 = qflint.rint(x1); break; }
                            case "oflint": { res1 = oflint.rint(x1); break; }
                            case "mflint": { res1 = mflint.rint(x1); break; }
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
                            case " mreal": { res1 = mreal.lrint(x1); break; }
                            case "sflint": { res1 = sflint.lrint(x1); break; }
                            case "dflint": { res1 = dflint.lrint(x1); break; }
                            case "eflint": { res1 = eflint.lrint(x1); break; }
                            case "qflint": { res1 = qflint.lrint(x1); break; }
                            case "oflint": { res1 = oflint.lrint(x1); break; }
                            case "mflint": { res1 = mflint.lrint(x1); break; }
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
                            case " mreal": { res1 = mreal.llrint(x1); break; }
                            case "sflint": { res1 = sflint.llrint(x1); break; }
                            case "dflint": { res1 = dflint.llrint(x1); break; }
                            case "eflint": { res1 = eflint.llrint(x1); break; }
                            case "qflint": { res1 = qflint.llrint(x1); break; }
                            case "oflint": { res1 = oflint.llrint(x1); break; }
                            case "mflint": { res1 = mflint.llrint(x1); break; }
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
                            case " mreal": { res1 = mreal.ceil(x1); break; }
                            case "sflint": { res1 = sflint.ceil(x1); break; }
                            case "dflint": { res1 = dflint.ceil(x1); break; }
                            case "eflint": { res1 = eflint.ceil(x1); break; }
                            case "qflint": { res1 = qflint.ceil(x1); break; }
                            case "oflint": { res1 = oflint.ceil(x1); break; }
                            case "mflint": { res1 = mflint.ceil(x1); break; }
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
                            case " mreal": { res1 = mreal.floor(x1); break; }
                            case "sflint": { res1 = sflint.floor(x1); break; }
                            case "dflint": { res1 = dflint.floor(x1); break; }
                            case "eflint": { res1 = eflint.floor(x1); break; }
                            case "qflint": { res1 = qflint.floor(x1); break; }
                            case "oflint": { res1 = oflint.floor(x1); break; }
                            case "mflint": { res1 = mflint.floor(x1); break; }
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
                            case " mreal": { res1 = mreal.trunc(x1); break; }
                            case "sflint": { res1 = sflint.trunc(x1); break; }
                            case "dflint": { res1 = dflint.trunc(x1); break; }
                            case "eflint": { res1 = eflint.trunc(x1); break; }
                            case "qflint": { res1 = qflint.trunc(x1); break; }
                            case "oflint": { res1 = oflint.trunc(x1); break; }
                            case "mflint": { res1 = mflint.trunc(x1); break; }
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
                            case " mreal": { res1 = mreal.round(x1); break; }
                            case "sflint": { res1 = sflint.round(x1); break; }
                            case "dflint": { res1 = dflint.round(x1); break; }
                            case "eflint": { res1 = eflint.round(x1); break; }
                            case "qflint": { res1 = qflint.round(x1); break; }
                            case "oflint": { res1 = oflint.round(x1); break; }
                            case "mflint": { res1 = mflint.round(x1); break; }
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
                            case " mreal": { res1 = mreal.lround(x1); break; }
                            case "sflint": { res1 = sflint.lround(x1); break; }
                            case "dflint": { res1 = dflint.lround(x1); break; }
                            case "eflint": { res1 = eflint.lround(x1); break; }
                            case "qflint": { res1 = qflint.lround(x1); break; }
                            case "oflint": { res1 = oflint.lround(x1); break; }
                            case "mflint": { res1 = mflint.lround(x1); break; }
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
                            case " mreal": { res1 = mreal.llround(x1); break; }
                            case "sflint": { res1 = sflint.llround(x1); break; }
                            case "dflint": { res1 = dflint.llround(x1); break; }
                            case "eflint": { res1 = eflint.llround(x1); break; }
                            case "qflint": { res1 = qflint.llround(x1); break; }
                            case "oflint": { res1 = oflint.llround(x1); break; }
                            case "mflint": { res1 = mflint.llround(x1); break; }
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
                                case " mreal": { res1 = mreal.copysign(x, y); break; }
                                case "sflint": { res1 = sflint.copysign(x, y); break; }
                                case "dflint": { res1 = dflint.copysign(x, y); break; }
                                case "eflint": { res1 = eflint.copysign(x, y); break; }
                                case "qflint": { res1 = qflint.copysign(x, y); break; }
                                case "oflint": { res1 = oflint.copysign(x, y); break; }
                                case "mflint": { res1 = mflint.copysign(x, y); break; }
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
                            case " mreal": { res1 = mreal.frexp(x1); break; }
                            case "sflint": { res1 = sflint.frexp(x1); break; }
                            case "dflint": { res1 = dflint.frexp(x1); break; }
                            case "eflint": { res1 = eflint.frexp(x1); break; }
                            case "qflint": { res1 = qflint.frexp(x1); break; }
                            case "oflint": { res1 = oflint.frexp(x1); break; }
                            //case "mflint": { res1 = mflint.frexp(x1); break; }
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
                            case " mreal": { res1 = mreal.logb(x1); break; }
                            case "sflint": { res1 = sflint.logb(x1); break; }
                            case "dflint": { res1 = dflint.logb(x1); break; }
                            case "eflint": { res1 = eflint.logb(x1); break; }
                            case "qflint": { res1 = qflint.logb(x1); break; }
                            case "oflint": { res1 = oflint.logb(x1); break; }
                            case "mflint": { res1 = mflint.logb(x1); break; }
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
                            case " mreal": { res1 = mreal.ilogb(x1); break; }
                            case "sflint": { res1 = sflint.ilogb(x1); break; }
                            case "dflint": { res1 = dflint.ilogb(x1); break; }
                            case "eflint": { res1 = eflint.ilogb(x1); break; }
                            case "qflint": { res1 = qflint.ilogb(x1); break; }
                            case "oflint": { res1 = oflint.ilogb(x1); break; }
                            case "mflint": { res1 = mflint.ilogb(x1); break; }
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
                                case " mreal": { res1 = mreal.ldexp(x1, e); break; }
                                case "sflint": { res1 = sflint.ldexp(x1, e); break; }
                                case "dflint": { res1 = dflint.ldexp(x1, e); break; }
                                case "eflint": { res1 = eflint.ldexp(x1, e); break; }
                                case "qflint": { res1 = qflint.ldexp(x1, e); break; }
                                case "oflint": { res1 = oflint.ldexp(x1, e); break; }
                                case "mflint": { res1 = mflint.ldexp(x1, e); break; }
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
                                case " mreal": { res1 = mreal.scalbn(x1, e); break; }
                                case "sflint": { res1 = sflint.scalbn(x1, e); break; }
                                case "dflint": { res1 = dflint.scalbn(x1, e); break; }
                                case "eflint": { res1 = eflint.scalbn(x1, e); break; }
                                case "qflint": { res1 = qflint.scalbn(x1, e); break; }
                                case "oflint": { res1 = oflint.scalbn(x1, e); break; }
                                case "mflint": { res1 = mflint.scalbn(x1, e); break; }
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
                                case " mreal": { res1 = mreal.scalbln(x1, e); break; }
                                case "sflint": { res1 = sflint.scalbln(x1, e); break; }
                                case "dflint": { res1 = dflint.scalbln(x1, e); break; }
                                case "eflint": { res1 = eflint.scalbln(x1, e); break; }
                                case "qflint": { res1 = qflint.scalbln(x1, e); break; }
                                case "oflint": { res1 = oflint.scalbln(x1, e); break; }
                                case "mflint": { res1 = mflint.scalbln(x1, e); break; }
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
                                case " mreal": { res1 = mreal.fdim(x, y); break; }
                                case "sflint": { res1 = sflint.fdim(x, y); break; }
                                case "dflint": { res1 = dflint.fdim(x, y); break; }
                                case "eflint": { res1 = eflint.fdim(x, y); break; }
                                case "qflint": { res1 = qflint.fdim(x, y); break; }
                                case "oflint": { res1 = oflint.fdim(x, y); break; }
                                case "mflint": { res1 = mflint.fdim(x, y); break; }
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
                            case " mreal": { res1 = mreal.modf(x1); break; }
                            case "sflint": { res1 = sflint.modf(x1); break; }
                            case "dflint": { res1 = dflint.modf(x1); break; }
                            case "eflint": { res1 = eflint.modf(x1); break; }
                            case "qflint": { res1 = qflint.modf(x1); break; }
                            case "oflint": { res1 = oflint.modf(x1); break; }
                            case "mflint": { res1 = mflint.modf(x1); break; }
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
                                case " mreal": { res1 = mreal.fmod(x, y); break; }
                                case "sflint": { res1 = sflint.fmod(x, y); break; }
                                case "dflint": { res1 = dflint.fmod(x, y); break; }
                                case "eflint": { res1 = eflint.fmod(x, y); break; }
                                case "qflint": { res1 = qflint.fmod(x, y); break; }
                                case "oflint": { res1 = oflint.fmod(x, y); break; }
                                case "mflint": { res1 = mflint.fmod(x, y); break; }
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
                                case " mreal": { res1 = mreal.remainder(x, y); break; }
                                case "sflint": { res1 = sflint.remainder(x, y); break; }
                                case "dflint": { res1 = dflint.remainder(x, y); break; }
                                case "eflint": { res1 = eflint.remainder(x, y); break; }
                                case "qflint": { res1 = qflint.remainder(x, y); break; }
                                case "oflint": { res1 = oflint.remainder(x, y); break; }
                                case "mflint": { res1 = mflint.remainder(x, y); break; }
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
                                case " mreal": { res1 = mreal.remquo(x, y); break; }
                                case "sflint": { res1 = sflint.remquo(x, y); break; }
                                case "dflint": { res1 = dflint.remquo(x, y); break; }
                                case "eflint": { res1 = eflint.remquo(x, y); break; }
                                case "qflint": { res1 = qflint.remquo(x, y); break; }
                                case "oflint": { res1 = oflint.remquo(x, y); break; }
                                //case "mflint": { res1 = mflint.remquo(x, y); break; }
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
                        case " mreal": { res1 = mreal.epsilon(); break; }
                        case "sflint": { res1 = sflint.epsilon(); break; }
                        case "dflint": { res1 = dflint.epsilon(); break; }
                        case "eflint": { res1 = eflint.epsilon(); break; }
                        case "qflint": { res1 = qflint.epsilon(); break; }
                        case "oflint": { res1 = oflint.epsilon(); break; }
                        case "mflint": { res1 = mflint.epsilon(); break; }
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
                            case " mreal": { res1 = mreal.ulp(x1); break; }
                            case "sflint": { res1 = sflint.ulp(x1); break; }
                            case "dflint": { res1 = dflint.ulp(x1); break; }
                            case "eflint": { res1 = eflint.ulp(x1); break; }
                            case "qflint": { res1 = qflint.ulp(x1); break; }
                            case "oflint": { res1 = oflint.ulp(x1); break; }
                            //case "mflint": { res1 = mflint.ulp(x1); break; }
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
                        case " mreal": { res1 = mreal.maxvalue(); break; }
                        case "sflint": { res1 = sflint.maxvalue(); break; }
                        case "dflint": { res1 = dflint.maxvalue(); break; }
                        case "eflint": { res1 = eflint.maxvalue(); break; }
                        case "qflint": { res1 = qflint.maxvalue(); break; }
                        case "oflint": { res1 = oflint.maxvalue(); break; }
                        case "mflint": { res1 = mflint.maxvalue(); break; }
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
                        case " mreal": { res1 = mreal.lowestvalue(); break; }
                        case "sflint": { res1 = sflint.lowestvalue(); break; }
                        case "dflint": { res1 = dflint.lowestvalue(); break; }
                        case "eflint": { res1 = eflint.lowestvalue(); break; }
                        case "qflint": { res1 = qflint.lowestvalue(); break; }
                        case "oflint": { res1 = oflint.lowestvalue(); break; }
                        case "mflint": { res1 = mflint.lowestvalue(); break; }
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
                        case " mreal": { res1 = mreal.minposvalue(); break; }
                        case "sflint": { res1 = sflint.minposvalue(); break; }
                        case "dflint": { res1 = dflint.minposvalue(); break; }
                        case "eflint": { res1 = eflint.minposvalue(); break; }
                        case "qflint": { res1 = qflint.minposvalue(); break; }
                        case "oflint": { res1 = oflint.minposvalue(); break; }
                        case "mflint": { res1 = mflint.minposvalue(); break; }
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
                                case " mreal": { res1 = mreal.nextafter(x, y); break; }
                                case "sflint": { res1 = sflint.nextafter(x, y); break; }
                                case "dflint": { res1 = dflint.nextafter(x, y); break; }
                                case "eflint": { res1 = eflint.nextafter(x, y); break; }
                                case "qflint": { res1 = qflint.nextafter(x, y); break; }
                                case "oflint": { res1 = oflint.nextafter(x, y); break; }
                                //case "mflint": { res1 = mflint.nextafter(x, y); break; }
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
                            case " mreal": { res1 = mreal.nextabove(x1); break; }
                            case "sflint": { res1 = sflint.nextabove(x1); break; }
                            case "dflint": { res1 = dflint.nextabove(x1); break; }
                            case "eflint": { res1 = eflint.nextabove(x1); break; }
                            case "qflint": { res1 = qflint.nextabove(x1); break; }
                            case "oflint": { res1 = oflint.nextabove(x1); break; }
                            case "mflint": { res1 = mflint.nextabove(x1); break; }
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
                            case " mreal": { res1 = mreal.nextbelow(x1); break; }
                            case "sflint": { res1 = sflint.nextbelow(x1); break; }
                            case "dflint": { res1 = dflint.nextbelow(x1); break; }
                            case "eflint": { res1 = eflint.nextbelow(x1); break; }
                            case "qflint": { res1 = qflint.nextbelow(x1); break; }
                            case "oflint": { res1 = oflint.nextbelow(x1); break; }
                            case "mflint": { res1 = mflint.nextbelow(x1); break; }
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
                        case " mreal": { res1 = mreal.degree(); break; }
                        case "sflint": { res1 = sflint.degree(); break; }
                        case "dflint": { res1 = dflint.degree(); break; }
                        case "eflint": { res1 = eflint.degree(); break; }
                        case "qflint": { res1 = qflint.degree(); break; }
                        case "oflint": { res1 = oflint.degree(); break; }
                        case "mflint": { res1 = mflint.degree(); break; }
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
                        case " mreal": { res1 = mreal.phi(); break; }
                        case "sflint": { res1 = sflint.phi(); break; }
                        case "dflint": { res1 = dflint.phi(); break; }
                        case "eflint": { res1 = eflint.phi(); break; }
                        case "qflint": { res1 = qflint.phi(); break; }
                        case "oflint": { res1 = oflint.phi(); break; }
                        case "mflint": { res1 = mflint.phi(); break; }
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
                        case " mreal": { res1 = mreal.ln2(); break; }
                        case "sflint": { res1 = sflint.ln2(); break; }
                        case "dflint": { res1 = dflint.ln2(); break; }
                        case "eflint": { res1 = eflint.ln2(); break; }
                        case "qflint": { res1 = qflint.ln2(); break; }
                        case "oflint": { res1 = oflint.ln2(); break; }
                        case "mflint": { res1 = mflint.ln2(); break; }
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
                        case " mreal": { res1 = mreal.ln10(); break; }
                        case "sflint": { res1 = sflint.ln10(); break; }
                        case "dflint": { res1 = dflint.ln10(); break; }
                        case "eflint": { res1 = eflint.ln10(); break; }
                        case "qflint": { res1 = qflint.ln10(); break; }
                        case "oflint": { res1 = oflint.ln10(); break; }
                        case "mflint": { res1 = mflint.ln10(); break; }
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
                        case " mreal": { res1 = mreal.pi(); break; }
                        case "sflint": { res1 = sflint.pi(); break; }
                        case "dflint": { res1 = dflint.pi(); break; }
                        case "eflint": { res1 = eflint.pi(); break; }
                        case "qflint": { res1 = qflint.pi(); break; }
                        case "oflint": { res1 = oflint.pi(); break; }
                        case "mflint": { res1 = mflint.pi(); break; }
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
                        case " mreal": { res1 = mreal.e(); break; }
                        case "sflint": { res1 = sflint.e(); break; }
                        case "dflint": { res1 = dflint.e(); break; }
                        case "eflint": { res1 = eflint.e(); break; }
                        case "qflint": { res1 = qflint.e(); break; }
                        case "oflint": { res1 = oflint.e(); break; }
                        case "mflint": { res1 = mflint.e(); break; }
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
                        case " mreal": { res1 = mreal.egamma(); break; }
                        case "sflint": { res1 = sflint.egamma(); break; }
                        case "dflint": { res1 = dflint.egamma(); break; }
                        case "eflint": { res1 = eflint.egamma(); break; }
                        case "qflint": { res1 = qflint.egamma(); break; }
                        case "oflint": { res1 = oflint.egamma(); break; }
                        case "mflint": { res1 = mflint.egamma(); break; }
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
                        case " mreal": { res1 = mreal.apery(); break; }
                        case "sflint": { res1 = sflint.apery(); break; }
                        case "dflint": { res1 = dflint.apery(); break; }
                        case "eflint": { res1 = eflint.apery(); break; }
                        case "qflint": { res1 = qflint.apery(); break; }
                        case "oflint": { res1 = oflint.apery(); break; }
                        case "mflint": { res1 = mflint.apery(); break; }
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
                        case " mreal": { res1 = mreal.catalan(); break; }
                        case "sflint": { res1 = sflint.catalan(); break; }
                        case "dflint": { res1 = dflint.catalan(); break; }
                        case "eflint": { res1 = eflint.catalan(); break; }
                        case "qflint": { res1 = qflint.catalan(); break; }
                        case "oflint": { res1 = oflint.catalan(); break; }
                        case "mflint": { res1 = mflint.catalan(); break; }
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
                        case " mreal": { res1 = mreal.glaisher(); break; }
                        case "sflint": { res1 = sflint.glaisher(); break; }
                        case "dflint": { res1 = dflint.glaisher(); break; }
                        case "eflint": { res1 = eflint.glaisher(); break; }
                        case "qflint": { res1 = qflint.glaisher(); break; }
                        case "oflint": { res1 = oflint.glaisher(); break; }
                        case "mflint": { res1 = mflint.glaisher(); break; }
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
                        case " mreal": { res1 = mreal.khinchin(); break; }
                        case "sflint": { res1 = sflint.khinchin(); break; }
                        case "dflint": { res1 = dflint.khinchin(); break; }
                        case "eflint": { res1 = eflint.khinchin(); break; }
                        case "qflint": { res1 = qflint.khinchin(); break; }
                        case "oflint": { res1 = oflint.khinchin(); break; }
                        case "mflint": { res1 = mflint.khinchin(); break; }
                        case "aflint": { res1 = aflint.khinchin(); break; }
#endif
                    }
                    Console.WriteLine("{0}: khinchin(): " + f(NumType) + "{1}", NumType, res1);
                }
                Console.WriteLine();
            }


            #endregion





        }





        public static void RunTestsBasicFloatingPointFunctions()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(80);
#endif
            string[] NTA1 = new[] { "math53", " sreal", " dreal", " ereal", " qreal", " oreal" };
            string[] NTA2 = new[] { " mreal", "sflint", "dflint", "eflint", "qflint", "oflint", "mflint", "aflint" };

            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();
            //string[] NumTypeArray = new[] { "math53"};

            string[] FunctionArray = new[] { "all" };
            //string[] FunctionArray = new[] { "fmax" };

            DemoChapterBasicFloatingPoint(NumTypeArray, FunctionArray);

        }



        public static void BasicFloatingPointFunctions()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTestsBasicFloatingPointFunctions();
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