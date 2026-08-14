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

        public static void RunTestsElementaryFunctions()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(80);
#endif
            string[] NTA1 = new[] { "math53", " sreal", " dreal", " ereal", " qreal", " oreal" };
            string[] NTA2 = new[] { " mreal", "sflint", "dflint", "eflint", "qflint", "oflint", "mflint", "aflint" };
            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();
            //string[] NumTypeArray = new[] { "math53"};



            //string[] FunctionArray = new[] { "all" };
            string[] FunctionArray = new[] { "binomial" };

            DemoChapterElementary(NumTypeArray, FunctionArray);

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
                            case " mreal": { res1 = mreal.abs(x1); break; }
                            case "sflint": { res1 = sflint.abs(x1); break; }
                            case "dflint": { res1 = dflint.abs(x1); break; }
                            case "eflint": { res1 = eflint.abs(x1); break; }
                            case "qflint": { res1 = qflint.abs(x1); break; }
                            case "oflint": { res1 = oflint.abs(x1); break; }
                            case "mflint": { res1 = mflint.abs(x1); break; }
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
                            case " mreal": { res1 = mreal.fabs(x1); break; }
                            case "sflint": { res1 = sflint.fabs(x1); break; }
                            case "dflint": { res1 = dflint.fabs(x1); break; }
                            case "eflint": { res1 = eflint.fabs(x1); break; }
                            case "qflint": { res1 = qflint.fabs(x1); break; }
                            case "oflint": { res1 = oflint.fabs(x1); break; }
                            case "mflint": { res1 = mflint.fabs(x1); break; }
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
                            case " mreal": { res1 = mreal.sign(x1); break; }
                            case "sflint": { res1 = sflint.sign(x1); break; }
                            case "dflint": { res1 = dflint.sign(x1); break; }
                            case "eflint": { res1 = eflint.sign(x1); break; }
                            case "qflint": { res1 = qflint.sign(x1); break; }
                            case "oflint": { res1 = oflint.sign(x1); break; }
                            case "mflint": { res1 = mflint.sign(x1); break; }
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
                            case " mreal": { res1 = mreal.real(x1); break; }
                            case "sflint": { res1 = sflint.real(x1); break; }
                            case "dflint": { res1 = dflint.real(x1); break; }
                            case "eflint": { res1 = eflint.real(x1); break; }
                            case "qflint": { res1 = qflint.real(x1); break; }
                            case "oflint": { res1 = oflint.real(x1); break; }
                            case "mflint": { res1 = mflint.real(x1); break; }
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
                            case " mreal": { res1 = mreal.imag(x1); break; }
                            case "sflint": { res1 = sflint.imag(x1); break; }
                            case "dflint": { res1 = dflint.imag(x1); break; }
                            case "eflint": { res1 = eflint.imag(x1); break; }
                            case "qflint": { res1 = qflint.imag(x1); break; }
                            case "oflint": { res1 = oflint.imag(x1); break; }
                            case "mflint": { res1 = mflint.imag(x1); break; }
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
                            case " mreal": { res1 = mreal.phase(x1); break; }
                            case "sflint": { res1 = sflint.phase(x1); break; }
                            case "dflint": { res1 = dflint.phase(x1); break; }
                            case "eflint": { res1 = eflint.phase(x1); break; }
                            case "qflint": { res1 = qflint.phase(x1); break; }
                            case "oflint": { res1 = oflint.phase(x1); break; }
                            case "mflint": { res1 = mflint.phase(x1); break; }
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
                            case " mreal": { res1 = mreal.conj(x1); break; }
                            case "sflint": { res1 = sflint.conj(x1); break; }
                            case "dflint": { res1 = dflint.conj(x1); break; }
                            case "eflint": { res1 = eflint.conj(x1); break; }
                            case "qflint": { res1 = qflint.conj(x1); break; }
                            case "oflint": { res1 = oflint.conj(x1); break; }
                            case "mflint": { res1 = mflint.conj(x1); break; }
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
                            case " mreal": { res1 = mreal.sqrt(x1); break; }
                            case "sflint": { res1 = sflint.sqrt(x1); break; }
                            case "dflint": { res1 = dflint.sqrt(x1); break; }
                            case "eflint": { res1 = eflint.sqrt(x1); break; }
                            case "qflint": { res1 = qflint.sqrt(x1); break; }
                            case "oflint": { res1 = oflint.sqrt(x1); break; }
                            case "mflint": { res1 = mflint.sqrt(x1); break; }
                            case "aflint": { res1 = aflint.sqrt(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sqrt({1}): " + f(NumType) + "{2}", NumType, x1, res1);
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
                            case " mreal": { res1 = mreal.rsqrt(x1); break; }
                            case "sflint": { res1 = sflint.rsqrt(x1); break; }
                            case "dflint": { res1 = dflint.rsqrt(x1); break; }
                            case "eflint": { res1 = eflint.rsqrt(x1); break; }
                            case "qflint": { res1 = qflint.rsqrt(x1); break; }
                            case "oflint": { res1 = oflint.rsqrt(x1); break; }
                            case "mflint": { res1 = mflint.rsqrt(x1); break; }
                            case "aflint": { res1 = aflint.rsqrt(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: rsqrt({1}): " + f(NumType) + "{2}", NumType, x1, res1);
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
                            case " mreal": { res1 = mreal.sqrt1pm1(x1); break; }
                            case "sflint": { res1 = sflint.sqrt1pm1(x1); break; }
                            case "dflint": { res1 = dflint.sqrt1pm1(x1); break; }
                            case "eflint": { res1 = eflint.sqrt1pm1(x1); break; }
                            case "qflint": { res1 = qflint.sqrt1pm1(x1); break; }
                            case "oflint": { res1 = oflint.sqrt1pm1(x1); break; }
                            case "mflint": { res1 = mflint.sqrt1pm1(x1); break; }
                            case "aflint": { res1 = aflint.sqrt1pm1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: sqrt1pm1({1}): \" + f(NumType) + \"{2}\"", NumType, x1, res1);
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
                            case " mreal": { res1 = mreal.cbrt(x1); break; }
                            case "sflint": { res1 = sflint.cbrt(x1); break; }
                            case "dflint": { res1 = dflint.cbrt(x1); break; }
                            case "eflint": { res1 = eflint.cbrt(x1); break; }
                            case "qflint": { res1 = qflint.cbrt(x1); break; }
                            case "oflint": { res1 = oflint.cbrt(x1); break; }
                            case "mflint": { res1 = mflint.cbrt(x1); break; }
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
                                case " mreal": { res1 = mreal.root_si(x, n); break; }
                                case "sflint": { res1 = sflint.root_si(x, n); break; }
                                case "dflint": { res1 = dflint.root_si(x, n); break; }
                                case "eflint": { res1 = eflint.root_si(x, n); break; }
                                case "qflint": { res1 = qflint.root_si(x, n); break; }
                                case "oflint": { res1 = oflint.root_si(x, n); break; }
                                case "mflint": { res1 = mflint.root_si(x, n); break; }
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
                            case " mreal": { res1 = mreal.exp(x1); break; }
                            case "sflint": { res1 = sflint.exp(x1); break; }
                            case "dflint": { res1 = dflint.exp(x1); break; }
                            case "eflint": { res1 = eflint.exp(x1); break; }
                            case "qflint": { res1 = qflint.exp(x1); break; }
                            case "oflint": { res1 = oflint.exp(x1); break; }
                            case "mflint": { res1 = mflint.exp(x1); break; }
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
                            case " mreal": { res1 = mreal.exp2(x1); break; }
                            case "sflint": { res1 = sflint.exp2(x1); break; }
                            case "dflint": { res1 = dflint.exp2(x1); break; }
                            case "eflint": { res1 = eflint.exp2(x1); break; }
                            case "qflint": { res1 = qflint.exp2(x1); break; }
                            case "oflint": { res1 = oflint.exp2(x1); break; }
                            case "mflint": { res1 = mflint.exp2(x1); break; }
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
                            case " mreal": { res1 = mreal.exp10(x1); break; }
                            case "sflint": { res1 = sflint.exp10(x1); break; }
                            case "dflint": { res1 = dflint.exp10(x1); break; }
                            case "eflint": { res1 = eflint.exp10(x1); break; }
                            case "qflint": { res1 = qflint.exp10(x1); break; }
                            case "oflint": { res1 = oflint.exp10(x1); break; }
                            case "mflint": { res1 = mflint.exp10(x1); break; }
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
                            case " mreal": { res1 = mreal.expm1(x1); break; }
                            case "sflint": { res1 = sflint.expm1(x1); break; }
                            case "dflint": { res1 = dflint.expm1(x1); break; }
                            case "eflint": { res1 = eflint.expm1(x1); break; }
                            case "qflint": { res1 = qflint.expm1(x1); break; }
                            case "oflint": { res1 = oflint.expm1(x1); break; }
                            case "mflint": { res1 = mflint.expm1(x1); break; }
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
                            case " mreal": { res1 = mreal.exp2m1(x1); break; }
                            case "sflint": { res1 = sflint.exp2m1(x1); break; }
                            case "dflint": { res1 = dflint.exp2m1(x1); break; }
                            case "eflint": { res1 = eflint.exp2m1(x1); break; }
                            case "qflint": { res1 = qflint.exp2m1(x1); break; }
                            case "oflint": { res1 = oflint.exp2m1(x1); break; }
                            case "mflint": { res1 = mflint.exp2m1(x1); break; }
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
                            case " mreal": { res1 = mreal.exp10m1(x1); break; }
                            case "sflint": { res1 = sflint.exp10m1(x1); break; }
                            case "dflint": { res1 = dflint.exp10m1(x1); break; }
                            case "eflint": { res1 = eflint.exp10m1(x1); break; }
                            case "qflint": { res1 = qflint.exp10m1(x1); break; }
                            case "oflint": { res1 = oflint.exp10m1(x1); break; }
                            case "mflint": { res1 = mflint.exp10m1(x1); break; }
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
                            case " mreal": { res1 = mreal.log(x1); break; }
                            case "sflint": { res1 = sflint.log(x1); break; }
                            case "dflint": { res1 = dflint.log(x1); break; }
                            case "eflint": { res1 = eflint.log(x1); break; }
                            case "qflint": { res1 = qflint.log(x1); break; }
                            case "oflint": { res1 = oflint.log(x1); break; }
                            case "mflint": { res1 = mflint.log(x1); break; }
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
                            case " mreal": { res1 = mreal.log2(x1); break; }
                            case "sflint": { res1 = sflint.log2(x1); break; }
                            case "dflint": { res1 = dflint.log2(x1); break; }
                            case "eflint": { res1 = eflint.log2(x1); break; }
                            case "qflint": { res1 = qflint.log2(x1); break; }
                            case "oflint": { res1 = oflint.log2(x1); break; }
                            case "mflint": { res1 = mflint.log2(x1); break; }
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
                            case " mreal": { res1 = mreal.log10(x1); break; }
                            case "sflint": { res1 = sflint.log10(x1); break; }
                            case "dflint": { res1 = dflint.log10(x1); break; }
                            case "eflint": { res1 = eflint.log10(x1); break; }
                            case "qflint": { res1 = qflint.log10(x1); break; }
                            case "oflint": { res1 = oflint.log10(x1); break; }
                            case "mflint": { res1 = mflint.log10(x1); break; }
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
                            case " mreal": { res1 = mreal.log1p(x1); break; }
                            case "sflint": { res1 = sflint.log1p(x1); break; }
                            case "dflint": { res1 = dflint.log1p(x1); break; }
                            case "eflint": { res1 = eflint.log1p(x1); break; }
                            case "qflint": { res1 = qflint.log1p(x1); break; }
                            case "oflint": { res1 = oflint.log1p(x1); break; }
                            case "mflint": { res1 = mflint.log1p(x1); break; }
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
                            case " mreal": { res1 = mreal.log2p1(x1); break; }
                            case "sflint": { res1 = sflint.log2p1(x1); break; }
                            case "dflint": { res1 = dflint.log2p1(x1); break; }
                            case "eflint": { res1 = eflint.log2p1(x1); break; }
                            case "qflint": { res1 = qflint.log2p1(x1); break; }
                            case "oflint": { res1 = oflint.log2p1(x1); break; }
                            case "mflint": { res1 = mflint.log2p1(x1); break; }
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
                            case " mreal": { res1 = mreal.log10p1(x1); break; }
                            case "sflint": { res1 = sflint.log10p1(x1); break; }
                            case "dflint": { res1 = dflint.log10p1(x1); break; }
                            case "eflint": { res1 = eflint.log10p1(x1); break; }
                            case "qflint": { res1 = qflint.log10p1(x1); break; }
                            case "oflint": { res1 = oflint.log10p1(x1); break; }
                            case "mflint": { res1 = mflint.log10p1(x1); break; }
                            case "aflint": { res1 = aflint.log10p1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: log10p1({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("logaddexp"))
            {
                InputArray1 = new[] { 1.0E-10, 0.001d, 4.333d };
                InputArray2 = new[] { 1.0E-10, 0.001d, 4.333d };
                foreach (var x in InputArray1)
                {
                    foreach (var y in InputArray2)
                    {
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.logaddexp(x, y); break; }
                                case " sreal": { res1 = sreal.logaddexp(x, y); break; }
                                case " dreal": { res1 = dreal.logaddexp(x, y); break; }
                                case " ereal": { res1 = ereal.logaddexp(x, y); break; }
                                case " qreal": { res1 = qreal.logaddexp(x, y); break; }
                                case " oreal": { res1 = oreal.logaddexp(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.logaddexp(x, y); break; }
                                    //case "sflint": { res1 = sflint.logaddexp(x, y); break; }
                                    //case "dflint": { res1 = dflint.logaddexp(x, y); break; }
                                    //case "eflint": { res1 = eflint.logaddexp(x, y); break; }
                                    //case "qflint": { res1 = qflint.logaddexp(x, y); break; }
                                    //case "oflint": { res1 = oflint.logaddexp(x, y); break; }
                                    //case "mflint": { res1 = mflint.logaddexp(x, y); break; }
                                    //case "aflint": { res1 = aflint.logaddexp(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: pow({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
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
                            case " mreal": { res1 = mreal.sqr(x1); break; }
                            case "sflint": { res1 = sflint.sqr(x1); break; }
                            case "dflint": { res1 = dflint.sqr(x1); break; }
                            case "eflint": { res1 = eflint.sqr(x1); break; }
                            case "qflint": { res1 = qflint.sqr(x1); break; }
                            case "oflint": { res1 = oflint.sqr(x1); break; }
                            case "mflint": { res1 = mflint.sqr(x1); break; }
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
                            case " mreal": { res1 = mreal.cube(x1); break; }
                            case "sflint": { res1 = sflint.cube(x1); break; }
                            case "dflint": { res1 = dflint.cube(x1); break; }
                            case "eflint": { res1 = eflint.cube(x1); break; }
                            case "qflint": { res1 = qflint.cube(x1); break; }
                            case "oflint": { res1 = oflint.cube(x1); break; }
                            case "mflint": { res1 = mflint.cube(x1); break; }
                            case "aflint": { res1 = aflint.cube(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: cube({1}): " + f(NumType) + "{2}", NumType, x1, res1);
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
                                case " mreal": { res1 = mreal.pow_si(x, n); break; }
                                case "sflint": { res1 = sflint.pow_si(x, n); break; }
                                case "dflint": { res1 = dflint.pow_si(x, n); break; }
                                case "eflint": { res1 = eflint.pow_si(x, n); break; }
                                case "qflint": { res1 = qflint.pow_si(x, n); break; }
                                case "oflint": { res1 = oflint.pow_si(x, n); break; }
                                case "mflint": { res1 = mflint.pow_si(x, n); break; }
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
                                case " mreal": { res1 = mreal.compound_si(x, n); break; }
                                case "sflint": { res1 = sflint.compound_si(x, n); break; }
                                case "dflint": { res1 = dflint.compound_si(x, n); break; }
                                case "eflint": { res1 = eflint.compound_si(x, n); break; }
                                case "qflint": { res1 = qflint.compound_si(x, n); break; }
                                case "oflint": { res1 = oflint.compound_si(x, n); break; }
                                case "mflint": { res1 = mflint.compound_si(x, n); break; }
                                case "aflint": { res1 = aflint.compound_si(x, n); break; }
#endif
                            }
                            Console.WriteLine("{0}: compound_si({1}, {2}): " + f(NumType) + "{3}", NumType, x, n, res1);
                        }
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
                                case " mreal": { res1 = mreal.hypot(x, y); break; }
                                case "sflint": { res1 = sflint.hypot(x, y); break; }
                                case "dflint": { res1 = dflint.hypot(x, y); break; }
                                case "eflint": { res1 = eflint.hypot(x, y); break; }
                                case "qflint": { res1 = qflint.hypot(x, y); break; }
                                case "oflint": { res1 = oflint.hypot(x, y); break; }
                                case "mflint": { res1 = mflint.hypot(x, y); break; }
                                case "aflint": { res1 = aflint.hypot(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: hypot({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
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
                                case " mreal": { res1 = mreal.powm1(x, y); break; }
                                case "sflint": { res1 = sflint.powm1(x, y); break; }
                                case "dflint": { res1 = dflint.powm1(x, y); break; }
                                case "eflint": { res1 = eflint.powm1(x, y); break; }
                                case "qflint": { res1 = qflint.powm1(x, y); break; }
                                case "oflint": { res1 = oflint.powm1(x, y); break; }
                                case "mflint": { res1 = mflint.powm1(x, y); break; }
                                case "aflint": { res1 = aflint.powm1(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: powm1({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pow1p"))
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
                                case "math53": { res1 = math53.pow1p(x, y); break; }
                                case " sreal": { res1 = sreal.pow1p(x, y); break; }
                                case " dreal": { res1 = dreal.pow1p(x, y); break; }
                                case " ereal": { res1 = ereal.pow1p(x, y); break; }
                                case " qreal": { res1 = qreal.pow1p(x, y); break; }
                                case " oreal": { res1 = oreal.pow1p(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.pow1p(x, y); break; }
                                case "sflint": { res1 = sflint.pow1p(x, y); break; }
                                case "dflint": { res1 = dflint.pow1p(x, y); break; }
                                case "eflint": { res1 = eflint.pow1p(x, y); break; }
                                case "qflint": { res1 = qflint.pow1p(x, y); break; }
                                case "oflint": { res1 = oflint.pow1p(x, y); break; }
                                case "mflint": { res1 = mflint.pow1p(x, y); break; }
                                case "aflint": { res1 = aflint.pow1p(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: pow1p({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
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
                                case " mreal": { res1 = mreal.pow1pm1(x, y); break; }
                                case "sflint": { res1 = sflint.pow1pm1(x, y); break; }
                                case "dflint": { res1 = dflint.pow1pm1(x, y); break; }
                                case "eflint": { res1 = eflint.pow1pm1(x, y); break; }
                                case "qflint": { res1 = qflint.pow1pm1(x, y); break; }
                                case "oflint": { res1 = oflint.pow1pm1(x, y); break; }
                                case "mflint": { res1 = mflint.pow1pm1(x, y); break; }
                                case "aflint": { res1 = aflint.pow1pm1(x, y); break; }
#endif
                            }
                            Console.WriteLine("{0}: pow1pm1({1}, {2}): " + f(NumType) + "{3}", NumType, x, y, res1);
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
                            case " mreal": { res1 = mreal.sin(x1); break; }
                            case "sflint": { res1 = sflint.sin(x1); break; }
                            case "dflint": { res1 = dflint.sin(x1); break; }
                            case "eflint": { res1 = eflint.sin(x1); break; }
                            case "qflint": { res1 = qflint.sin(x1); break; }
                            case "oflint": { res1 = oflint.sin(x1); break; }
                            case "mflint": { res1 = mflint.sin(x1); break; }
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
                            case " mreal": { res1 = mreal.cos(x1); break; }
                            case "sflint": { res1 = sflint.cos(x1); break; }
                            case "dflint": { res1 = dflint.cos(x1); break; }
                            case "eflint": { res1 = eflint.cos(x1); break; }
                            case "qflint": { res1 = qflint.cos(x1); break; }
                            case "oflint": { res1 = oflint.cos(x1); break; }
                            case "mflint": { res1 = mflint.cos(x1); break; }
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
                            case " mreal": { res1 = mreal.tan(x1); break; }
                            case "sflint": { res1 = sflint.tan(x1); break; }
                            case "dflint": { res1 = dflint.tan(x1); break; }
                            case "eflint": { res1 = eflint.tan(x1); break; }
                            case "qflint": { res1 = qflint.tan(x1); break; }
                            case "oflint": { res1 = oflint.tan(x1); break; }
                            case "mflint": { res1 = mflint.tan(x1); break; }
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
                            case " mreal": { res1 = mreal.csc(x1); break; }
                            case "sflint": { res1 = sflint.csc(x1); break; }
                            case "dflint": { res1 = dflint.csc(x1); break; }
                            case "eflint": { res1 = eflint.csc(x1); break; }
                            case "qflint": { res1 = qflint.csc(x1); break; }
                            case "oflint": { res1 = oflint.csc(x1); break; }
                            case "mflint": { res1 = mflint.csc(x1); break; }
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
                            case " mreal": { res1 = mreal.sec(x1); break; }
                            case "sflint": { res1 = sflint.sec(x1); break; }
                            case "dflint": { res1 = dflint.sec(x1); break; }
                            case "eflint": { res1 = eflint.sec(x1); break; }
                            case "qflint": { res1 = qflint.sec(x1); break; }
                            case "oflint": { res1 = oflint.sec(x1); break; }
                            case "mflint": { res1 = mflint.sec(x1); break; }
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
                            case " mreal": { res1 = mreal.cot(x1); break; }
                            case "sflint": { res1 = sflint.cot(x1); break; }
                            case "dflint": { res1 = dflint.cot(x1); break; }
                            case "eflint": { res1 = eflint.cot(x1); break; }
                            case "qflint": { res1 = qflint.cot(x1); break; }
                            case "oflint": { res1 = oflint.cot(x1); break; }
                            case "mflint": { res1 = mflint.cot(x1); break; }
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
                            case " mreal": { res1 = mreal.sinpi(x1); break; }
                            case "sflint": { res1 = sflint.sinpi(x1); break; }
                            case "dflint": { res1 = dflint.sinpi(x1); break; }
                            case "eflint": { res1 = eflint.sinpi(x1); break; }
                            case "qflint": { res1 = qflint.sinpi(x1); break; }
                            case "oflint": { res1 = oflint.sinpi(x1); break; }
                            case "mflint": { res1 = mflint.sinpi(x1); break; }
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
                            case " mreal": { res1 = mreal.cospi(x1); break; }
                            case "sflint": { res1 = sflint.cospi(x1); break; }
                            case "dflint": { res1 = dflint.cospi(x1); break; }
                            case "eflint": { res1 = eflint.cospi(x1); break; }
                            case "qflint": { res1 = qflint.cospi(x1); break; }
                            case "oflint": { res1 = oflint.cospi(x1); break; }
                            case "mflint": { res1 = mflint.cospi(x1); break; }
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
                            case " mreal": { res1 = mreal.tanpi(x1); break; }
                            case "sflint": { res1 = sflint.tanpi(x1); break; }
                            case "dflint": { res1 = dflint.tanpi(x1); break; }
                            case "eflint": { res1 = eflint.tanpi(x1); break; }
                            case "qflint": { res1 = qflint.tanpi(x1); break; }
                            case "oflint": { res1 = oflint.tanpi(x1); break; }
                            case "mflint": { res1 = mflint.tanpi(x1); break; }
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
                            case " mreal": { res1 = mreal.cscpi(x1); break; }
                            case "sflint": { res1 = sflint.cscpi(x1); break; }
                            case "dflint": { res1 = dflint.cscpi(x1); break; }
                            case "eflint": { res1 = eflint.cscpi(x1); break; }
                            case "qflint": { res1 = qflint.cscpi(x1); break; }
                            case "oflint": { res1 = oflint.cscpi(x1); break; }
                            case "mflint": { res1 = mflint.cscpi(x1); break; }
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
                            case " mreal": { res1 = mreal.secpi(x1); break; }
                            case "sflint": { res1 = sflint.secpi(x1); break; }
                            case "dflint": { res1 = dflint.secpi(x1); break; }
                            case "eflint": { res1 = eflint.secpi(x1); break; }
                            case "qflint": { res1 = qflint.secpi(x1); break; }
                            case "oflint": { res1 = oflint.secpi(x1); break; }
                            case "mflint": { res1 = mflint.secpi(x1); break; }
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
                            case " mreal": { res1 = mreal.cotpi(x1); break; }
                            case "sflint": { res1 = sflint.cotpi(x1); break; }
                            case "dflint": { res1 = dflint.cotpi(x1); break; }
                            case "eflint": { res1 = eflint.cotpi(x1); break; }
                            case "qflint": { res1 = qflint.cotpi(x1); break; }
                            case "oflint": { res1 = oflint.cotpi(x1); break; }
                            case "mflint": { res1 = mflint.cotpi(x1); break; }
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
                            case " mreal": { res1 = mreal.sincpi(x1); break; }
                            case "sflint": { res1 = sflint.sincpi(x1); break; }
                            case "dflint": { res1 = dflint.sincpi(x1); break; }
                            case "eflint": { res1 = eflint.sincpi(x1); break; }
                            case "qflint": { res1 = qflint.sincpi(x1); break; }
                            case "oflint": { res1 = oflint.sincpi(x1); break; }
                            case "mflint": { res1 = mflint.sincpi(x1); break; }
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
                            case " mreal": { res1 = mreal.sinh(x1); break; }
                            case "sflint": { res1 = sflint.sinh(x1); break; }
                            case "dflint": { res1 = dflint.sinh(x1); break; }
                            case "eflint": { res1 = eflint.sinh(x1); break; }
                            case "qflint": { res1 = qflint.sinh(x1); break; }
                            case "oflint": { res1 = oflint.sinh(x1); break; }
                            case "mflint": { res1 = mflint.sinh(x1); break; }
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
                            case " mreal": { res1 = mreal.cosh(x1); break; }
                            case "sflint": { res1 = sflint.cosh(x1); break; }
                            case "dflint": { res1 = dflint.cosh(x1); break; }
                            case "eflint": { res1 = eflint.cosh(x1); break; }
                            case "qflint": { res1 = qflint.cosh(x1); break; }
                            case "oflint": { res1 = oflint.cosh(x1); break; }
                            case "mflint": { res1 = mflint.cosh(x1); break; }
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
                            case " mreal": { res1 = mreal.tanh(x1); break; }
                            case "sflint": { res1 = sflint.tanh(x1); break; }
                            case "dflint": { res1 = dflint.tanh(x1); break; }
                            case "eflint": { res1 = eflint.tanh(x1); break; }
                            case "qflint": { res1 = qflint.tanh(x1); break; }
                            case "oflint": { res1 = oflint.tanh(x1); break; }
                            case "mflint": { res1 = mflint.tanh(x1); break; }
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
                            case " mreal": { res1 = mreal.csch(x1); break; }
                            case "sflint": { res1 = sflint.csch(x1); break; }
                            case "dflint": { res1 = dflint.csch(x1); break; }
                            case "eflint": { res1 = eflint.csch(x1); break; }
                            case "qflint": { res1 = qflint.csch(x1); break; }
                            case "oflint": { res1 = oflint.csch(x1); break; }
                            case "mflint": { res1 = mflint.csch(x1); break; }
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
                            case " mreal": { res1 = mreal.sech(x1); break; }
                            case "sflint": { res1 = sflint.sech(x1); break; }
                            case "dflint": { res1 = dflint.sech(x1); break; }
                            case "eflint": { res1 = eflint.sech(x1); break; }
                            case "qflint": { res1 = qflint.sech(x1); break; }
                            case "oflint": { res1 = oflint.sech(x1); break; }
                            case "mflint": { res1 = mflint.sech(x1); break; }
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
                            case " mreal": { res1 = mreal.coth(x1); break; }
                            case "sflint": { res1 = sflint.coth(x1); break; }
                            case "dflint": { res1 = dflint.coth(x1); break; }
                            case "eflint": { res1 = eflint.coth(x1); break; }
                            case "qflint": { res1 = qflint.coth(x1); break; }
                            case "oflint": { res1 = oflint.coth(x1); break; }
                            case "mflint": { res1 = mflint.coth(x1); break; }
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
                            case " mreal": { res1 = mreal.asin(x1); break; }
                            case "sflint": { res1 = sflint.asin(x1); break; }
                            case "dflint": { res1 = dflint.asin(x1); break; }
                            case "eflint": { res1 = eflint.asin(x1); break; }
                            case "qflint": { res1 = qflint.asin(x1); break; }
                            case "oflint": { res1 = oflint.asin(x1); break; }
                            case "mflint": { res1 = mflint.asin(x1); break; }
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
                            case " mreal": { res1 = mreal.acos(x1); break; }
                            case "sflint": { res1 = sflint.acos(x1); break; }
                            case "dflint": { res1 = dflint.acos(x1); break; }
                            case "eflint": { res1 = eflint.acos(x1); break; }
                            case "qflint": { res1 = qflint.acos(x1); break; }
                            case "oflint": { res1 = oflint.acos(x1); break; }
                            case "mflint": { res1 = mflint.acos(x1); break; }
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
                            case " mreal": { res1 = mreal.atan(x1); break; }
                            case "sflint": { res1 = sflint.atan(x1); break; }
                            case "dflint": { res1 = dflint.atan(x1); break; }
                            case "eflint": { res1 = eflint.atan(x1); break; }
                            case "qflint": { res1 = qflint.atan(x1); break; }
                            case "oflint": { res1 = oflint.atan(x1); break; }
                            case "mflint": { res1 = mflint.atan(x1); break; }
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
                                case "math53": { res1 = math53.atan2(y, x); break; }
                                case " sreal": { res1 = sreal.atan2(y, x); break; }
                                case " dreal": { res1 = dreal.atan2(y, x); break; }
                                case " ereal": { res1 = ereal.atan2(y, x); break; }
                                case " qreal": { res1 = qreal.atan2(y, x); break; }
                                case " oreal": { res1 = oreal.atan2(y, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.atan2(y, x); break; }
                                case "sflint": { res1 = sflint.atan2(y, x); break; }
                                case "dflint": { res1 = dflint.atan2(y, x); break; }
                                case "eflint": { res1 = eflint.atan2(y, x); break; }
                                case "qflint": { res1 = qflint.atan2(y, x); break; }
                                case "oflint": { res1 = oflint.atan2(y, x); break; }
                                case "mflint": { res1 = mflint.atan2(y, x); break; }
                                case "aflint": { res1 = aflint.atan2(y, x); break; }
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
                            case " mreal": { res1 = mreal.acsc(x1); break; }
                            case "sflint": { res1 = sflint.acsc(x1); break; }
                            case "dflint": { res1 = dflint.acsc(x1); break; }
                            case "eflint": { res1 = eflint.acsc(x1); break; }
                            case "qflint": { res1 = qflint.acsc(x1); break; }
                            case "oflint": { res1 = oflint.acsc(x1); break; }
                            case "mflint": { res1 = mflint.acsc(x1); break; }
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
                            case " mreal": { res1 = mreal.asec(x1); break; }
                            case "sflint": { res1 = sflint.asec(x1); break; }
                            case "dflint": { res1 = dflint.asec(x1); break; }
                            case "eflint": { res1 = eflint.asec(x1); break; }
                            case "qflint": { res1 = qflint.asec(x1); break; }
                            case "oflint": { res1 = oflint.asec(x1); break; }
                            case "mflint": { res1 = mflint.asec(x1); break; }
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
                            case " mreal": { res1 = mreal.acot(x1); break; }
                            case "sflint": { res1 = sflint.acot(x1); break; }
                            case "dflint": { res1 = dflint.acot(x1); break; }
                            case "eflint": { res1 = eflint.acot(x1); break; }
                            case "qflint": { res1 = qflint.acot(x1); break; }
                            case "oflint": { res1 = oflint.acot(x1); break; }
                            case "mflint": { res1 = mflint.acot(x1); break; }
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
                            case " mreal": { res1 = mreal.asinh(x1); break; }
                            case "sflint": { res1 = sflint.asinh(x1); break; }
                            case "dflint": { res1 = dflint.asinh(x1); break; }
                            case "eflint": { res1 = eflint.asinh(x1); break; }
                            case "qflint": { res1 = qflint.asinh(x1); break; }
                            case "oflint": { res1 = oflint.asinh(x1); break; }
                            case "mflint": { res1 = mflint.asinh(x1); break; }
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
                            case " mreal": { res1 = mreal.acosh(x1); break; }
                            case "sflint": { res1 = sflint.acosh(x1); break; }
                            case "dflint": { res1 = dflint.acosh(x1); break; }
                            case "eflint": { res1 = eflint.acosh(x1); break; }
                            case "qflint": { res1 = qflint.acosh(x1); break; }
                            case "oflint": { res1 = oflint.acosh(x1); break; }
                            case "mflint": { res1 = mflint.acosh(x1); break; }
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
                            case " mreal": { res1 = mreal.atanh(x1); break; }
                            case "sflint": { res1 = sflint.atanh(x1); break; }
                            case "dflint": { res1 = dflint.atanh(x1); break; }
                            case "eflint": { res1 = eflint.atanh(x1); break; }
                            case "qflint": { res1 = qflint.atanh(x1); break; }
                            case "oflint": { res1 = oflint.atanh(x1); break; }
                            case "mflint": { res1 = mflint.atanh(x1); break; }
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
                            case " mreal": { res1 = mreal.acsch(x1); break; }
                            case "sflint": { res1 = sflint.acsch(x1); break; }
                            case "dflint": { res1 = dflint.acsch(x1); break; }
                            case "eflint": { res1 = eflint.acsch(x1); break; }
                            case "qflint": { res1 = qflint.acsch(x1); break; }
                            case "oflint": { res1 = oflint.acsch(x1); break; }
                            case "mflint": { res1 = mflint.acsch(x1); break; }
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
                            case " mreal": { res1 = mreal.asech(x1); break; }
                            case "sflint": { res1 = sflint.asech(x1); break; }
                            case "dflint": { res1 = dflint.asech(x1); break; }
                            case "eflint": { res1 = eflint.asech(x1); break; }
                            case "qflint": { res1 = qflint.asech(x1); break; }
                            case "oflint": { res1 = oflint.asech(x1); break; }
                            case "mflint": { res1 = mflint.asech(x1); break; }
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
                            case " mreal": { res1 = mreal.acoth(x1); break; }
                            case "sflint": { res1 = sflint.acoth(x1); break; }
                            case "dflint": { res1 = dflint.acoth(x1); break; }
                            case "eflint": { res1 = eflint.acoth(x1); break; }
                            case "qflint": { res1 = qflint.acoth(x1); break; }
                            case "oflint": { res1 = oflint.acoth(x1); break; }
                            case "mflint": { res1 = mflint.acoth(x1); break; }
                            case "aflint": { res1 = aflint.acoth(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: acoth({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Gamma and related functions



            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.gamma(x1); break; }
                            case " sreal": { res1 = sreal.gamma(x1); break; }
                            case " dreal": { res1 = dreal.gamma(x1); break; }
                            case " ereal": { res1 = ereal.gamma(x1); break; }
                            case " qreal": { res1 = qreal.gamma(x1); break; }
                            case " oreal": { res1 = oreal.gamma(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.gamma(x1); break; }
                            case "sflint": { res1 = sflint.gamma(x1); break; }
                            case "dflint": { res1 = dflint.gamma(x1); break; }
                            case "eflint": { res1 = eflint.gamma(x1); break; }
                            case "qflint": { res1 = qflint.gamma(x1); break; }
                            case "oflint": { res1 = oflint.gamma(x1); break; }
                            case "mflint": { res1 = mflint.gamma(x1); break; }
                            case "aflint": { res1 = aflint.gamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: gamma({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma1pm1"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.gamma1pm1(x1); break; }
                            case " sreal": { res1 = sreal.gamma1pm1(x1); break; }
                            case " dreal": { res1 = dreal.gamma1pm1(x1); break; }
                            case " ereal": { res1 = ereal.gamma1pm1(x1); break; }
                            case " qreal": { res1 = qreal.gamma1pm1(x1); break; }
                            case " oreal": { res1 = oreal.gamma1pm1(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.gamma1pm1(x1); break; }
                            case "sflint": { res1 = sflint.gamma1pm1(x1); break; }
                            case "dflint": { res1 = dflint.gamma1pm1(x1); break; }
                            case "eflint": { res1 = eflint.gamma1pm1(x1); break; }
                            case "qflint": { res1 = qflint.gamma1pm1(x1); break; }
                            case "oflint": { res1 = oflint.gamma1pm1(x1); break; }
                            case "mflint": { res1 = mflint.gamma1pm1(x1); break; }
                            case "aflint": { res1 = aflint.gamma1pm1(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: gamma1pm1({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("lgamma"))
            {
                InputArray1 = new[] { -5.333d, 0.0d, 5.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.lgamma(x1); break; }
                            case " sreal": { res1 = sreal.lgamma(x1); break; }
                            case " dreal": { res1 = dreal.lgamma(x1); break; }
                            case " ereal": { res1 = ereal.lgamma(x1); break; }
                            case " qreal": { res1 = qreal.lgamma(x1); break; }
                            case " oreal": { res1 = oreal.lgamma(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.lgamma(x1); break; }
                            case "sflint": { res1 = sflint.lgamma(x1); break; }
                            case "dflint": { res1 = dflint.lgamma(x1); break; }
                            case "eflint": { res1 = eflint.lgamma(x1); break; }
                            case "qflint": { res1 = qflint.lgamma(x1); break; }
                            case "oflint": { res1 = oflint.lgamma(x1); break; }
                            case "mflint": { res1 = mflint.lgamma(x1); break; }
                            case "aflint": { res1 = aflint.lgamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: lgamma({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("rgamma"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.rgamma(x1); break; }
                            case " sreal": { res1 = sreal.rgamma(x1); break; }
                            case " dreal": { res1 = dreal.rgamma(x1); break; }
                            case " ereal": { res1 = ereal.rgamma(x1); break; }
                            case " qreal": { res1 = qreal.rgamma(x1); break; }
                            case " oreal": { res1 = oreal.rgamma(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.rgamma(x1); break; }
                            case "sflint": { res1 = sflint.rgamma(x1); break; }
                            case "dflint": { res1 = dflint.rgamma(x1); break; }
                            case "eflint": { res1 = eflint.rgamma(x1); break; }
                            case "qflint": { res1 = qflint.rgamma(x1); break; }
                            case "oflint": { res1 = oflint.rgamma(x1); break; }
                            case "mflint": { res1 = mflint.rgamma(x1); break; }
                            case "aflint": { res1 = aflint.rgamma(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: rgamma({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            // Inf and Nan lead to crashes; math53 needs to be moved to gamma
            if (FunctionArray.Contains("all") | FunctionArray.Contains("factorial"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.factorial(x1); break; }
                            case " sreal": { res1 = sreal.factorial(x1); break; }
                            case " dreal": { res1 = dreal.factorial(x1); break; }
                            case " ereal": { res1 = ereal.factorial(x1); break; }
                            case " qreal": { res1 = qreal.factorial(x1); break; }
                            case " oreal": { res1 = oreal.factorial(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.factorial(x1); break; }
                            case "sflint": { res1 = sflint.factorial(x1); break; }
                            case "dflint": { res1 = dflint.factorial(x1); break; }
                            case "eflint": { res1 = eflint.factorial(x1); break; }
                            case "qflint": { res1 = qflint.factorial(x1); break; }
                            case "oflint": { res1 = oflint.factorial(x1); break; }
                            case "mflint": { res1 = mflint.factorial(x1); break; }
                            case "aflint": { res1 = aflint.factorial(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: factorial({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            // Inf and Nan lead to crashes; math53 needs to be moved to gamma
            if (FunctionArray.Contains("all") | FunctionArray.Contains("doublefactorial"))
            {
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.doublefactorial(x1); break; }
                            case " sreal": { res1 = sreal.doublefactorial(x1); break; }
                            case " dreal": { res1 = dreal.doublefactorial(x1); break; }
                            case " ereal": { res1 = ereal.doublefactorial(x1); break; }
                            case " qreal": { res1 = qreal.doublefactorial(x1); break; }
                            case " oreal": { res1 = oreal.doublefactorial(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.doublefactorial(x1); break; }
                            case "sflint": { res1 = sflint.doublefactorial(x1); break; }
                            case "dflint": { res1 = dflint.doublefactorial(x1); break; }
                            case "eflint": { res1 = eflint.doublefactorial(x1); break; }
                            case "qflint": { res1 = qflint.doublefactorial(x1); break; }
                            case "oflint": { res1 = oflint.doublefactorial(x1); break; }
                            case "mflint": { res1 = mflint.doublefactorial(x1); break; }
                            case "aflint": { res1 = aflint.doublefactorial(x1); break; }

#endif
                        }
                        Console.WriteLine("{0}: doublefactorial({1}): {2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("rising_factorial"))
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
                                case "math53": { res1 = math53.rising_factorial(x, y); break; }
                                case " sreal": { res1 = sreal.rising_factorial(x, y); break; }
                                case " dreal": { res1 = dreal.rising_factorial(x, y); break; }
                                case " ereal": { res1 = ereal.rising_factorial(x, y); break; }
                                case " qreal": { res1 = qreal.rising_factorial(x, y); break; }
                                case " oreal": { res1 = oreal.rising_factorial(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.rising_factorial(x, y); break; }
                                case "sflint": { res1 = sflint.rising_factorial(x, y); break; }
                                case "dflint": { res1 = dflint.rising_factorial(x, y); break; }
                                case "eflint": { res1 = eflint.rising_factorial(x, y); break; }
                                case "qflint": { res1 = qflint.rising_factorial(x, y); break; }
                                case "oflint": { res1 = oflint.rising_factorial(x, y); break; }
                                case "mflint": { res1 = mflint.rising_factorial(x, y); break; }
                                case "aflint": { res1 = aflint.rising_factorial(x, y); break; }
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
                                case "math53": { res1 = math53.falling_factorial(x, y); break; }
                                case " sreal": { res1 = sreal.falling_factorial(x, y); break; }
                                case " dreal": { res1 = dreal.falling_factorial(x, y); break; }
                                case " ereal": { res1 = ereal.falling_factorial(x, y); break; }
                                case " qreal": { res1 = qreal.falling_factorial(x, y); break; }
                                case " oreal": { res1 = oreal.falling_factorial(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.falling_factorial(x, y); break; }
                                case "sflint": { res1 = sflint.falling_factorial(x, y); break; }
                                case "dflint": { res1 = dflint.falling_factorial(x, y); break; }
                                case "eflint": { res1 = eflint.falling_factorial(x, y); break; }
                                case "qflint": { res1 = qflint.falling_factorial(x, y); break; }
                                case "oflint": { res1 = oflint.falling_factorial(x, y); break; }
                                case "mflint": { res1 = mflint.falling_factorial(x, y); break; }
                                case "aflint": { res1 = aflint.falling_factorial(x, y); break; }
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
                                case "math53": { res1 = math53.gamma_ratio(x, y); break; }
                                case " sreal": { res1 = sreal.gamma_ratio(x, y); break; }
                                case " dreal": { res1 = dreal.gamma_ratio(x, y); break; }
                                case " ereal": { res1 = ereal.gamma_ratio(x, y); break; }
                                case " qreal": { res1 = qreal.gamma_ratio(x, y); break; }
                                case " oreal": { res1 = oreal.gamma_ratio(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.gamma_ratio(x, y); break; }
                                case "sflint": { res1 = sflint.gamma_ratio(x, y); break; }
                                case "dflint": { res1 = dflint.gamma_ratio(x, y); break; }
                                case "eflint": { res1 = eflint.gamma_ratio(x, y); break; }
                                case "qflint": { res1 = qflint.gamma_ratio(x, y); break; }
                                case "oflint": { res1 = oflint.gamma_ratio(x, y); break; }
                                case "mflint": { res1 = mflint.gamma_ratio(x, y); break; }
                                case "aflint": { res1 = aflint.gamma_ratio(x, y); break; }
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
                                case "math53": { res1 = math53.gamma_delta_ratio(x, y); break; }
                                case " sreal": { res1 = sreal.gamma_delta_ratio(x, y); break; }
                                case " dreal": { res1 = dreal.gamma_delta_ratio(x, y); break; }
                                case " ereal": { res1 = ereal.gamma_delta_ratio(x, y); break; }
                                case " qreal": { res1 = qreal.gamma_delta_ratio(x, y); break; }
                                case " oreal": { res1 = oreal.gamma_delta_ratio(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.gamma_delta_ratio(x, y); break; }
                                case "sflint": { res1 = sflint.gamma_delta_ratio(x, y); break; }
                                case "dflint": { res1 = dflint.gamma_delta_ratio(x, y); break; }
                                case "eflint": { res1 = eflint.gamma_delta_ratio(x, y); break; }
                                case "qflint": { res1 = qflint.gamma_delta_ratio(x, y); break; }
                                case "oflint": { res1 = oflint.gamma_delta_ratio(x, y); break; }
                                case "mflint": { res1 = mflint.gamma_delta_ratio(x, y); break; }
                                case "aflint": { res1 = aflint.gamma_delta_ratio(x, y); break; }
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
                                case "math53": { res1 = math53.beta(x, y); break; }
                                case " sreal": { res1 = sreal.beta(x, y); break; }
                                case " dreal": { res1 = dreal.beta(x, y); break; }
                                case " ereal": { res1 = ereal.beta(x, y); break; }
                                case " qreal": { res1 = qreal.beta(x, y); break; }
                                case " oreal": { res1 = oreal.beta(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.beta(x, y); break; }
                                case "sflint": { res1 = sflint.beta(x, y); break; }
                                case "dflint": { res1 = dflint.beta(x, y); break; }
                                case "eflint": { res1 = eflint.beta(x, y); break; }
                                case "qflint": { res1 = qflint.beta(x, y); break; }
                                case "oflint": { res1 = oflint.beta(x, y); break; }
                                case "mflint": { res1 = mflint.beta(x, y); break; }
                                case "aflint": { res1 = aflint.beta(x, y); break; }
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
                InputArray1 = new[] { -4, 0.0d, 1.0d, 1.5d, 4.333d };
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
                                case "math53": { res1 = math53.binomial(x, y); break; }
                                case " sreal": { res1 = sreal.binomial(x, y); break; }
                                case " dreal": { res1 = dreal.binomial(x, y); break; }
                                case " ereal": { res1 = ereal.binomial(x, y); break; }
                                case " qreal": { res1 = qreal.binomial(x, y); break; }
                                case " oreal": { res1 = oreal.binomial(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.binomial(x, y); break; }
                                case "sflint": { res1 = sflint.binomial(x, y); break; }
                                case "dflint": { res1 = dflint.binomial(x, y); break; }
                                case "eflint": { res1 = eflint.binomial(x, y); break; }
                                case "qflint": { res1 = qflint.binomial(x, y); break; }
                                case "oflint": { res1 = oflint.binomial(x, y); break; }
                                case "mflint": { res1 = mflint.binomial(x, y); break; }
                                case "aflint": { res1 = aflint.binomial(x, y); break; }
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
                            case " mreal": { res1 = mreal.lambert_w0(x1); break; }
                            case "sflint": { res1 = sflint.lambert_w0(x1); break; }
                            case "dflint": { res1 = dflint.lambert_w0(x1); break; }
                            case "eflint": { res1 = eflint.lambert_w0(x1); break; }
                            case "qflint": { res1 = qflint.lambert_w0(x1); break; }
                            case "oflint": { res1 = oflint.lambert_w0(x1); break; }
                            case "mflint": { res1 = mflint.lambert_w0(x1); break; }
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
                            case " mreal": { res1 = mreal.lambert_wm1(x1); break; }
                            case "sflint": { res1 = sflint.lambert_wm1(x1); break; }
                            case "dflint": { res1 = dflint.lambert_wm1(x1); break; }
                            case "eflint": { res1 = eflint.lambert_wm1(x1); break; }
                            case "qflint": { res1 = qflint.lambert_wm1(x1); break; }
                            case "oflint": { res1 = oflint.lambert_wm1(x1); break; }
                            case "mflint": { res1 = mflint.lambert_wm1(x1); break; }
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
                            case " mreal": { res1 = mreal.lambert_w0_prime(x1); break; }
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
                            case " mreal": { res1 = mreal.lambert_wm1_prime(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: lambert_wm1_prime({1}): " + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("agm"))
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
                                case "math53": { res1 = math53.agm(x, y); break; }
                                case " sreal": { res1 = sreal.agm(x, y); break; }
                                case " dreal": { res1 = dreal.agm(x, y); break; }
                                case " ereal": { res1 = ereal.agm(x, y); break; }
                                case " qreal": { res1 = qreal.agm(x, y); break; }
                                case " oreal": { res1 = oreal.agm(x, y); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.agm(x, y); break; }
                                case "sflint": { res1 = sflint.agm(x, y); break; }
                                case "dflint": { res1 = dflint.agm(x, y); break; }
                                case "eflint": { res1 = eflint.agm(x, y); break; }
                                case "qflint": { res1 = qflint.agm(x, y); break; }
                                case "oflint": { res1 = oflint.agm(x, y); break; }
                                case "mflint": { res1 = mflint.agm(x, y); break; }
                                case "aflint": { res1 = aflint.agm(x, y); break; }
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






        public static void RealElementaryFunctions()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTestsElementaryFunctions();
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