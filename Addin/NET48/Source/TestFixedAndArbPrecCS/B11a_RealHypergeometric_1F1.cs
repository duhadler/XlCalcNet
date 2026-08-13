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





        public static void RunTests_RealHypergeometric_1F1()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(80);
#endif
            string[] NTA1 = new[] { "math53", " sreal", " dreal", " ereal", " qreal", " oreal" };
            string[] NTA2 = new[] { " mreal", "sflint", "dflint", "eflint", "qflint", "oflint", "mflint", "aflint" };
            //string[] NTA2 = new[] { " mreal", "aflint" };

            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();


            //string[] FunctionArray = new[] { "all" };
            string[] FunctionArray = new[] { "cos_integral" };

            DemoChapter1F1(NumTypeArray, FunctionArray);

        }






        public static void DemoChapter1F1(string[] NumTypeArray, string[] FunctionArray)
        {

            double[] InputArray1;
            double[] InputArray2;
            double[] InputArray3;
            int[] InputArrayInt1;
            int[] InputArrayInt2;


            #region 1F1 Overview


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_1f1"))
            {
                string name = "hyperg_1f1";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { -1.5d, 0.0d, 1.5d };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(a={0}, b={1}, x={1})", a, b, x);
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
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.hyperg_1f1(a, b, x); break; }
                                    case "sflint": { res1 = sflint.hyperg_1f1(a, b, x); break; }
                                    case "dflint": { res1 = dflint.hyperg_1f1(a, b, x); break; }
                                    case "eflint": { res1 = eflint.hyperg_1f1(a, b, x); break; }
                                    case "qflint": { res1 = qflint.hyperg_1f1(a, b, x); break; }
                                    case "oflint": { res1 = oflint.hyperg_1f1(a, b, x); break; }
                                    case "mflint": { res1 = mflint.hyperg_1f1(a, b, x); break; }
                                    case "aflint": { res1 = aflint.hyperg_1f1(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_1f1r"))
            {
                string name = "hyperg_1f1r";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { -1.5d, 0.0d, 1.5d };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(a={0}, b={1}, x={1})", a, b, x);
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
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.hyperg_1f1r(a, b, x); break; }
                                    case "sflint": { res1 = sflint.hyperg_1f1r(a, b, x); break; }
                                    case "dflint": { res1 = dflint.hyperg_1f1r(a, b, x); break; }
                                    case "eflint": { res1 = eflint.hyperg_1f1r(a, b, x); break; }
                                    case "qflint": { res1 = qflint.hyperg_1f1r(a, b, x); break; }
                                    case "oflint": { res1 = oflint.hyperg_1f1r(a, b, x); break; }
                                    case "mflint": { res1 = mflint.hyperg_1f1r(a, b, x); break; }
                                    case "aflint": { res1 = aflint.hyperg_1f1r(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_u"))
            {
                string name = "hyperg_u";
                InputArray1 = new[] { 1.5d, 2.5d, 13.5d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { -1.5d, 0.0d, 1.5d };
                foreach (var a in InputArray1)
                {
                    foreach (var b in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(a={0}, b={1}, x={2})", a, b, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.hyperg_u(a, b, x); break; }
#if HasArbPrecNet
                                    case "sflint": { res1 = sflint.hyperg_u(a, b, x); break; }
                                    case "dflint": { res1 = dflint.hyperg_u(a, b, x); break; }
                                    case "eflint": { res1 = eflint.hyperg_u(a, b, x); break; }
                                    case "qflint": { res1 = qflint.hyperg_u(a, b, x); break; }
                                    case "oflint": { res1 = oflint.hyperg_u(a, b, x); break; }
                                    case "mflint": { res1 = mflint.hyperg_u(a, b, x); break; }
                                    case "aflint": { res1 = aflint.hyperg_u(a, b, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("laguerre_l"))
            {
                string name = "laguerre_l";
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArrayInt2 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var m in InputArrayInt2)
                    {
                        foreach (var x in InputArray1)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(n={0}, m={1}, x={2})", n, m, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.laguerre_l(n, m, x); break; }
                                    case " sreal": { res1 = sreal.laguerre_l(n, m, x); break; }
                                    case " dreal": { res1 = dreal.laguerre_l(n, m, x); break; }
                                    case " ereal": { res1 = ereal.laguerre_l(n, m, x); break; }
                                    case " qreal": { res1 = qreal.laguerre_l(n, m, x); break; }
                                    case " oreal": { res1 = oreal.laguerre_l(n, m, x); break; }
#if HasArbPrecNet
                                    case " mreal": { res1 = mreal.laguerre_l(n, m, x); break; }
                                    case "sflint": { res1 = sflint.laguerre_l(n, m, x); break; }
                                    case "dflint": { res1 = dflint.laguerre_l(n, m, x); break; }
                                    case "eflint": { res1 = eflint.laguerre_l(n, m, x); break; }
                                    case "qflint": { res1 = qflint.laguerre_l(n, m, x); break; }
                                    case "oflint": { res1 = oflint.laguerre_l(n, m, x); break; }
                                    case "mflint": { res1 = mflint.laguerre_l(n, m, x); break; }
                                    case "aflint": { res1 = aflint.laguerre_l(n, m, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hermite_h"))
            {
                string name = "hermite_h";
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n,x);
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
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.hermite_h(n, x); break; }
                                case "sflint": { res1 = sflint.hermite_h(n, x); break; }
                                case "dflint": { res1 = dflint.hermite_h(n, x); break; }
                                case "eflint": { res1 = eflint.hermite_h(n, x); break; }
                                case "qflint": { res1 = qflint.hermite_h(n, x); break; }
                                case "oflint": { res1 = oflint.hermite_h(n, x); break; }
                                case "mflint": { res1 = mflint.hermite_h(n, x); break; }
                                case "aflint": { res1 = aflint.hermite_h(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hermite_he"))
            {
                string name = "hermite_he";
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333678678678d };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.hermite_he(n, x); break; }
                                case " sreal": { res1 = sreal.hermite_he(n, x); break; }
                                case " dreal": { res1 = dreal.hermite_he(n, x); break; }
                                case " ereal": { res1 = ereal.hermite_he(n, x); break; }
                                case " qreal": { res1 = qreal.hermite_he(n, x); break; }
                                case " oreal": { res1 = oreal.hermite_he(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.hermite_he(n, x); break; }
                                case "sflint": { res1 = sflint.hermite_he(n, x); break; }
                                case "dflint": { res1 = dflint.hermite_he(n, x); break; }
                                case "eflint": { res1 = eflint.hermite_he(n, x); break; }
                                case "qflint": { res1 = qflint.hermite_he(n, x); break; }
                                case "oflint": { res1 = oflint.hermite_he(n, x); break; }
                                case "mflint": { res1 = mflint.hermite_he(n, x); break; }
                                case "aflint": { res1 = aflint.hermite_he(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion



            #region Incomplete gamma functions for real arguments and parameters


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_p"))
            {
                string name = "gamma_p";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.gamma_p(a, x); break; }
                                case " sreal": { res1 = sreal.gamma_p(a, x); break; }
                                case " dreal": { res1 = dreal.gamma_p(a, x); break; }
                                case " ereal": { res1 = ereal.gamma_p(a, x); break; }
                                case " qreal": { res1 = qreal.gamma_p(a, x); break; }
                                case " oreal": { res1 = oreal.gamma_p(a, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.gamma_p(a, x); break; }
                                case "sflint": { res1 = sflint.gamma_p(a, x); break; }
                                case "dflint": { res1 = dflint.gamma_p(a, x); break; }
                                case "eflint": { res1 = eflint.gamma_p(a, x); break; }
                                case "qflint": { res1 = qflint.gamma_p(a, x); break; }
                                case "oflint": { res1 = oflint.gamma_p(a, x); break; }
                                case "mflint": { res1 = mflint.gamma_p(a, x); break; }
                                case "aflint": { res1 = aflint.gamma_p(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_q"))
            {
                string name = "gamma_q";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.gamma_q(a, x); break; }
                                case " sreal": { res1 = sreal.gamma_q(a, x); break; }
                                case " dreal": { res1 = dreal.gamma_q(a, x); break; }
                                case " ereal": { res1 = ereal.gamma_q(a, x); break; }
                                case " qreal": { res1 = qreal.gamma_q(a, x); break; }
                                case " oreal": { res1 = oreal.gamma_q(a, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.gamma_q(a, x); break; }
                                case "sflint": { res1 = sflint.gamma_q(a, x); break; }
                                case "dflint": { res1 = dflint.gamma_q(a, x); break; }
                                case "eflint": { res1 = eflint.gamma_q(a, x); break; }
                                case "qflint": { res1 = qflint.gamma_q(a, x); break; }
                                case "oflint": { res1 = oflint.gamma_q(a, x); break; }
                                case "mflint": { res1 = mflint.gamma_q(a, x); break; }
                                case "aflint": { res1 = aflint.gamma_q(a, x); break; }

#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_lower"))
            {
                string name = "gamma_lower";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.gamma_lower(a, x); break; }
                                case " sreal": { res1 = sreal.gamma_lower(a, x); break; }
                                case " dreal": { res1 = dreal.gamma_lower(a, x); break; }
                                case " ereal": { res1 = ereal.gamma_lower(a, x); break; }
                                case " qreal": { res1 = qreal.gamma_lower(a, x); break; }
                                case " oreal": { res1 = oreal.gamma_lower(a, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.gamma_lower(a, x); break; }
                                case "sflint": { res1 = sflint.gamma_lower(a, x); break; }
                                case "dflint": { res1 = dflint.gamma_lower(a, x); break; }
                                case "eflint": { res1 = eflint.gamma_lower(a, x); break; }
                                case "qflint": { res1 = qflint.gamma_lower(a, x); break; }
                                case "oflint": { res1 = oflint.gamma_lower(a, x); break; }
                                case "mflint": { res1 = mflint.gamma_lower(a, x); break; }
                                case "aflint": { res1 = aflint.gamma_lower(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_upper"))
            {
                string name = "gamma_upper";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.gamma_upper(a, x); break; }
                                case " sreal": { res1 = sreal.gamma_upper(a, x); break; }
                                case " dreal": { res1 = dreal.gamma_upper(a, x); break; }
                                case " ereal": { res1 = ereal.gamma_upper(a, x); break; }
                                case " qreal": { res1 = qreal.gamma_upper(a, x); break; }
                                case " oreal": { res1 = oreal.gamma_upper(a, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.gamma_upper(a, x); break; }
                                case "sflint": { res1 = sflint.gamma_upper(a, x); break; }
                                case "dflint": { res1 = dflint.gamma_upper(a, x); break; }
                                case "eflint": { res1 = eflint.gamma_upper(a, x); break; }
                                case "qflint": { res1 = qflint.gamma_upper(a, x); break; }
                                case "oflint": { res1 = oflint.gamma_upper(a, x); break; }
                                case "mflint": { res1 = mflint.gamma_upper(a, x); break; }
                                case "aflint": { res1 = aflint.gamma_upper(a, x); break; }

#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_p_inv"))
            {
                string name = "gamma_p_inv";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 0.0d, 0.25d, 0.75d, 1.0d };
                foreach (var a in InputArray1)
                {
                    foreach (var p in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, p={1})", a, p);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.gamma_p_inv(a, p); break; }
                                case " sreal": { res1 = sreal.gamma_p_inv(a, p); break; }
                                case " dreal": { res1 = dreal.gamma_p_inv(a, p); break; }
                                case " ereal": { res1 = ereal.gamma_p_inv(a, p); break; }
                                case " qreal": { res1 = qreal.gamma_p_inv(a, p); break; }
                                case " oreal": { res1 = oreal.gamma_p_inv(a, p); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.gamma_p_inv(a, p); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_q_inv"))
            {
                string name = "gamma_q_inv";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 0.0d, 0.25d, 0.75d, 1.0d };
                foreach (var a in InputArray1)
                {
                    foreach (var q in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, q={1})", a, q);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.gamma_q_inv(a, q); break; }
                                case " sreal": { res1 = sreal.gamma_q_inv(a, q); break; }
                                case " dreal": { res1 = dreal.gamma_q_inv(a, q); break; }
                                case " ereal": { res1 = ereal.gamma_q_inv(a, q); break; }
                                case " qreal": { res1 = qreal.gamma_q_inv(a, q); break; }
                                case " oreal": { res1 = oreal.gamma_q_inv(a, q); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.gamma_q_inv(a, q); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_p_inva"))
            {
                string name = "gamma_p_inva";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 0.0d, 0.25d, 0.75d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var p in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(x={0}, q={1})", x, p);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.gamma_p_inva(x, p); break; }
                                case " sreal": { res1 = sreal.gamma_p_inva(x, p); break; }
                                case " dreal": { res1 = dreal.gamma_p_inva(x, p); break; }
                                case " ereal": { res1 = ereal.gamma_p_inva(x, p); break; }
                                case " qreal": { res1 = qreal.gamma_p_inva(x, p); break; }
                                case " oreal": { res1 = oreal.gamma_p_inva(x, p); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.gamma_p_inva(x, p); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_q_inva"))
            {
                string name = "gamma_q_inva";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 0.0d, 0.25d, 0.75d, 1.0d };
                foreach (var x in InputArray1)
                {
                    foreach (var p in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(x={0}, q={1})", x, p);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.gamma_q_inva(x, p); break; }
                                case " sreal": { res1 = sreal.gamma_q_inva(x, p); break; }
                                case " dreal": { res1 = dreal.gamma_q_inva(x, p); break; }
                                case " ereal": { res1 = ereal.gamma_q_inva(x, p); break; }
                                case " qreal": { res1 = qreal.gamma_q_inva(x, p); break; }
                                case " oreal": { res1 = oreal.gamma_q_inva(x, p); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.gamma_q_inva(x, p); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("gamma_p_prime"))
            {
                string name = "gamma_p_prime";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.gamma_p_prime(a, x); break; }
                                case " sreal": { res1 = sreal.gamma_p_prime(a, x); break; }
                                case " dreal": { res1 = dreal.gamma_p_prime(a, x); break; }
                                case " ereal": { res1 = ereal.gamma_p_prime(a, x); break; }
                                case " qreal": { res1 = qreal.gamma_p_prime(a, x); break; }
                                case " oreal": { res1 = oreal.gamma_p_prime(a, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.gamma_p_prime(a, x); break; }
                                case "sflint": { res1 = sflint.gamma_p_prime(a, x); break; }
                                case "dflint": { res1 = dflint.gamma_p_prime(a, x); break; }
                                case "eflint": { res1 = eflint.gamma_p_prime(a, x); break; }
                                case "qflint": { res1 = qflint.gamma_p_prime(a, x); break; }
                                case "oflint": { res1 = oflint.gamma_p_prime(a, x); break; }
                                case "mflint": { res1 = mflint.gamma_p_prime(a, x); break; }
                                case "aflint": { res1 = aflint.gamma_p_prime(a, x); break; }


#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion



            #region Coulomb, Whittaker and parabolic cylinder function


            if (FunctionArray.Contains("all") | FunctionArray.Contains("coulomb_f"))
            {
                string name = "coulomb_f";
                InputArray1 = new[] { 1.0d, 2.0d, 13.0d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { -1.5d, 0.0d, 1.5d };
                foreach (var l in InputArray1)
                {
                    foreach (var eta in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(l={0}, eta={1}, x={2})", l, eta, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.coulomb_f(l, eta, x); break; }
#if HasArbPrecNet
                                    case "sflint": { res1 = sflint.coulomb_f(l, eta, x); break; }
                                    case "dflint": { res1 = dflint.coulomb_f(l, eta, x); break; }
                                    case "eflint": { res1 = eflint.coulomb_f(l, eta, x); break; }
                                    case "qflint": { res1 = qflint.coulomb_f(l, eta, x); break; }
                                    case "oflint": { res1 = oflint.coulomb_f(l, eta, x); break; }
                                    case "mflint": { res1 = mflint.coulomb_f(l, eta, x); break; }
                                    case "aflint": { res1 = aflint.coulomb_f(l, eta, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("coulomb_g"))
            {
                string name = "coulomb_g";
                InputArray1 = new[] { 1.0d, 2.0d, 13.0d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { -1.5d, 0.0d, 1.5d };
                foreach (var l in InputArray1)
                {
                    foreach (var eta in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(l={0}, eta={1}, x={2})", l, eta, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.coulomb_g(l, eta, x); break; }
#if HasArbPrecNet
                                    case "sflint": { res1 = sflint.coulomb_g(l, eta, x); break; }
                                    case "dflint": { res1 = dflint.coulomb_g(l, eta, x); break; }
                                    case "eflint": { res1 = eflint.coulomb_g(l, eta, x); break; }
                                    case "qflint": { res1 = qflint.coulomb_g(l, eta, x); break; }
                                    case "oflint": { res1 = oflint.coulomb_g(l, eta, x); break; }
                                    case "mflint": { res1 = mflint.coulomb_g(l, eta, x); break; }
                                    case "aflint": { res1 = aflint.coulomb_g(l, eta, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("whittaker_m"))
            {
                string name = "whittaker_m";
                InputArray1 = new[] { 1.0d, 2.0d, 13.0d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { -1.5d, 0.0d, 1.5d };
                foreach (var k in InputArray1)
                {
                    foreach (var m in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(k={0}, m={1}, x={2})", k, m, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.whittaker_m(k, m, x); break; }
#if HasArbPrecNet
                                    case "sflint": { res1 = sflint.whittaker_m(k, m, x); break; }
                                    case "dflint": { res1 = dflint.whittaker_m(k, m, x); break; }
                                    case "eflint": { res1 = eflint.whittaker_m(k, m, x); break; }
                                    case "qflint": { res1 = qflint.whittaker_m(k, m, x); break; }
                                    case "oflint": { res1 = oflint.whittaker_m(k, m, x); break; }
                                    case "mflint": { res1 = mflint.whittaker_m(k, m, x); break; }
                                    case "aflint": { res1 = aflint.whittaker_m(k, m, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("whittaker_w"))
            {
                string name = "whittaker_w";
                InputArray1 = new[] { 1.0d, 2.0d, 13.0d };
                InputArray2 = new[] { 2.1d, 12.1d, 53.5d };
                InputArray3 = new[] { -1.5d, 0.0d, 1.5d };
                foreach (var k in InputArray1)
                {
                    foreach (var m in InputArray2)
                    {
                        foreach (var x in InputArray3)
                        {
                            Console.WriteLine();
                            Console.WriteLine(name + "(k={0}, m={1}, x={2})", k, m, x);
                            foreach (var NumType in NumTypeArray)
                            {
                                object res1 = "Not done";
                                switch (NumType ?? "")
                                {
                                    case "math53": { res1 = math53.whittaker_w(k, m, x); break; }
#if HasArbPrecNet
                                    case "sflint": { res1 = sflint.whittaker_w(k, m, x); break; }
                                    case "dflint": { res1 = dflint.whittaker_w(k, m, x); break; }
                                    case "eflint": { res1 = eflint.whittaker_w(k, m, x); break; }
                                    case "qflint": { res1 = qflint.whittaker_w(k, m, x); break; }
                                    case "oflint": { res1 = oflint.whittaker_w(k, m, x); break; }
                                    case "mflint": { res1 = mflint.whittaker_w(k, m, x); break; }
                                    case "aflint": { res1 = aflint.whittaker_w(k, m, x); break; }
#endif
                                }
                                Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("pcfd"))
            {
                string name = "pcfd";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.pcfd(a, x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.pcfd(a, x); break; }
                                case "dflint": { res1 = dflint.pcfd(a, x); break; }
                                case "eflint": { res1 = eflint.pcfd(a, x); break; }
                                case "qflint": { res1 = qflint.pcfd(a, x); break; }
                                case "oflint": { res1 = oflint.pcfd(a, x); break; }
                                case "mflint": { res1 = mflint.pcfd(a, x); break; }
                                case "aflint": { res1 = aflint.pcfd(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pcfu"))
            {
                string name = "pcfu";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.pcfu(a, x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.pcfu(a, x); break; }
                                case "dflint": { res1 = dflint.pcfu(a, x); break; }
                                case "eflint": { res1 = eflint.pcfu(a, x); break; }
                                case "qflint": { res1 = qflint.pcfu(a, x); break; }
                                case "oflint": { res1 = oflint.pcfu(a, x); break; }
                                case "mflint": { res1 = mflint.pcfu(a, x); break; }
                                case "aflint": { res1 = aflint.pcfu(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pcfv"))
            {
                string name = "pcfv";
                InputArray1 = new[] { 1.0d, 1.5d, 4.5 };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.pcfv(a, x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.pcfv(a, x); break; }
                                case "dflint": { res1 = dflint.pcfv(a, x); break; }
                                case "eflint": { res1 = eflint.pcfv(a, x); break; }
                                case "qflint": { res1 = qflint.pcfv(a, x); break; }
                                case "oflint": { res1 = oflint.pcfv(a, x); break; }
                                case "mflint": { res1 = mflint.pcfv(a, x); break; }
                                case "aflint": { res1 = aflint.pcfv(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("pcfw"))
            {
                string name = "pcfw";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var a in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(a={0}, x={1})", a, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.pcfw(a, x); break; }
                                case "dflint": { res1 = dflint.pcfw(a, x); break; }
                                case "eflint": { res1 = eflint.pcfw(a, x); break; }
                                case "qflint": { res1 = qflint.pcfw(a, x); break; }
                                case "oflint": { res1 = oflint.pcfw(a, x); break; }
                                case "mflint": { res1 = mflint.pcfw(a, x); break; }
                                case "aflint": { res1 = aflint.pcfw(a, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion



            #region Error functions and related functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("erf"))
            {
                string name = "erf";
                InputArray1 = new[] { dreal.neginf(), -4.333d, 0.0d, 4.333d, dreal.inf(), dreal.nan() };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.erf(x); break; }
                            case " sreal": { res1 = sreal.erf(x); break; }
                            case " dreal": { res1 = dreal.erf(x); break; }
                            case " ereal": { res1 = ereal.erf(x); break; }
                            case " qreal": { res1 = qreal.erf(x); break; }
                            case " oreal": { res1 = oreal.erf(x); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.erf(x); break; }
                            case "sflint": { res1 = sflint.erf(x); break; }
                            case "dflint": { res1 = dflint.erf(x); break; }
                            case "eflint": { res1 = eflint.erf(x); break; }
                            case "qflint": { res1 = qflint.erf(x); break; }
                            case "oflint": { res1 = oflint.erf(x); break; }
                            case "mflint": { res1 = mflint.erf(x); break; }
                            case "aflint": { res1 = aflint.erf(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("erfc"))
            {
                string name = "erf";
                InputArray1 = new[] { dreal.neginf(), -4.333d, 0.0d, 4.333d, dreal.inf(), dreal.nan() };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.erfc(x); break; }
                            case " sreal": { res1 = sreal.erfc(x); break; }
                            case " dreal": { res1 = dreal.erfc(x); break; }
                            case " ereal": { res1 = ereal.erfc(x); break; }
                            case " qreal": { res1 = qreal.erfc(x); break; }
                            case " oreal": { res1 = oreal.erfc(x); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.erfc(x); break; }
                            case "sflint": { res1 = sflint.erfc(x); break; }
                            case "dflint": { res1 = dflint.erfc(x); break; }
                            case "eflint": { res1 = eflint.erfc(x); break; }
                            case "qflint": { res1 = qflint.erfc(x); break; }
                            case "oflint": { res1 = oflint.erfc(x); break; }
                            case "mflint": { res1 = mflint.erfc(x); break; }
                            case "aflint": { res1 = aflint.erfc(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("erf_inv"))
            {
                string name = "erf_inv";
                InputArray1 = new[] { -1.0, -0.999, -0.5, 0.0, 0.5, 0.999, 1.0 };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.erf_inv(x); break; }
                            case " sreal": { res1 = sreal.erf_inv(x); break; }
                            case " dreal": { res1 = dreal.erf_inv(x); break; }
                            case " ereal": { res1 = ereal.erf_inv(x); break; }
                            case " qreal": { res1 = qreal.erf_inv(x); break; }
                            case " oreal": { res1 = oreal.erf_inv(x); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.erf_inv(x); break; }
                            //case "sflint": { res1 = sflint.erfc_inv(x); break; }
                            //case "dflint": { res1 = dflint.erfc_inv(x); break; }
                            //case "eflint": { res1 = eflint.erfc_inv(x); break; }
                            //case "qflint": { res1 = qflint.erfc_inv(x); break; }
                            //case "oflint": { res1 = oflint.erfc_inv(x); break; }
                            //case "mflint": { res1 = mflint.erfc_inv(x); break; }
                            //case "aflint": { res1 = aflint.erfc_inv(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("erfc_inv"))
            {
                InputArray1 = new[] { 0.0, 0.001, 0.5, 1.0, 1.5, 1.999, 2.0 };
                foreach (var x1 in InputArray1)
                {
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.erfc_inv(x1); break; }
                            case " sreal": { res1 = sreal.erfc_inv(x1); break; }
                            case " dreal": { res1 = dreal.erfc_inv(x1); break; }
                            case " ereal": { res1 = ereal.erfc_inv(x1); break; }
                            case " qreal": { res1 = qreal.erfc_inv(x1); break; }
                            case " oreal": { res1 = oreal.erfc_inv(x1); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.erfc_inv(x1); break; }
#endif
                        }
                        Console.WriteLine("{0}: erfc({1}):" + f(NumType) + "{2}", NumType, x1, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("erfi"))
            {
                string name = "erfi";
                InputArray1 = new[] { dreal.neginf(), -4.333d, 0.0d, 4.333d, dreal.inf(), dreal.nan() };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.erfi(x); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.erfi(x); break; }
                            case "dflint": { res1 = dflint.erfi(x); break; }
                            case "eflint": { res1 = eflint.erfi(x); break; }
                            case "qflint": { res1 = qflint.erfi(x); break; }
                            case "oflint": { res1 = oflint.erfi(x); break; }
                            case "mflint": { res1 = mflint.erfi(x); break; }
                            case "aflint": { res1 = aflint.erfi(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("dawson"))
            {
                string name = "dawson";
                InputArray1 = new[] { dreal.neginf(), -4.333d, 0.0d, 4.333d, dreal.inf(), dreal.nan() };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.dawson(x); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.dawson(x); break; }
                            case "dflint": { res1 = dflint.dawson(x); break; }
                            case "eflint": { res1 = eflint.dawson(x); break; }
                            case "qflint": { res1 = qflint.dawson(x); break; }
                            case "oflint": { res1 = oflint.dawson(x); break; }
                            case "mflint": { res1 = mflint.dawson(x); break; }
                            case "aflint": { res1 = aflint.dawson(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("fresnel_s"))
            {
                string name = "fresnel_s";
                InputArray1 = new[] { dreal.neginf(), -4.333d, 0.0d, 4.333d, dreal.inf(), dreal.nan() };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.fresnel_c(x); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.fresnel_s(x); break; }
                            case "dflint": { res1 = dflint.fresnel_s(x); break; }
                            case "eflint": { res1 = eflint.fresnel_s(x); break; }
                            case "qflint": { res1 = qflint.fresnel_s(x); break; }
                            case "oflint": { res1 = oflint.fresnel_s(x); break; }
                            case "mflint": { res1 = mflint.fresnel_s(x); break; }
                            case "aflint": { res1 = aflint.fresnel_s(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("fresnel_c"))
            {
                string name = "fresnel_c";
                InputArray1 = new[] { dreal.neginf(), -4.333d, 0.0d, 4.333d, dreal.inf(), dreal.nan() };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.fresnel_s(x); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.fresnel_c(x); break; }
                            case "dflint": { res1 = dflint.fresnel_c(x); break; }
                            case "eflint": { res1 = eflint.fresnel_c(x); break; }
                            case "qflint": { res1 = qflint.fresnel_c(x); break; }
                            case "oflint": { res1 = oflint.fresnel_c(x); break; }
                            case "mflint": { res1 = mflint.fresnel_c(x); break; }
                            case "aflint": { res1 = aflint.fresnel_c(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("ndens"))
            {
                string name = "erf";
                InputArray1 = new[] { dreal.neginf(), -4.333d, 0.0d, 4.333d, dreal.inf(), dreal.nan() };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.ndens(x); break; }
                            case " sreal": { res1 = sreal.ndens(x); break; }
                            case " dreal": { res1 = dreal.ndens(x); break; }
                            case " ereal": { res1 = ereal.ndens(x); break; }
                            case " qreal": { res1 = qreal.ndens(x); break; }
                            case " oreal": { res1 = oreal.ndens(x); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.ndens(x); break; }
                            case "sflint": { res1 = sflint.ndens(x); break; }
                            case "dflint": { res1 = dflint.ndens(x); break; }
                            case "eflint": { res1 = eflint.ndens(x); break; }
                            case "qflint": { res1 = qflint.ndens(x); break; }
                            case "oflint": { res1 = oflint.ndens(x); break; }
                            case "mflint": { res1 = mflint.ndens(x); break; }
                            case "aflint": { res1 = aflint.ndens(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("ndis"))
            {
                string name = "erf";
                InputArray1 = new[] { dreal.neginf(), -4.333d, 0.0d, 4.333d, dreal.inf(), dreal.nan() };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.ndis(x); break; }
                            case " sreal": { res1 = sreal.ndis(x); break; }
                            case " dreal": { res1 = dreal.ndis(x); break; }
                            case " ereal": { res1 = ereal.ndis(x); break; }
                            case " qreal": { res1 = qreal.ndis(x); break; }
                            case " oreal": { res1 = oreal.ndis(x); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.ndis(x); break; }
                            case "sflint": { res1 = sflint.ndis(x); break; }
                            case "dflint": { res1 = dflint.ndis(x); break; }
                            case "eflint": { res1 = eflint.ndis(x); break; }
                            case "qflint": { res1 = qflint.ndis(x); break; }
                            case "oflint": { res1 = oflint.ndis(x); break; }
                            case "mflint": { res1 = mflint.ndis(x); break; }
                            case "aflint": { res1 = aflint.ndis(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



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
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.owen_t(h, a); break; }
#endif
                            }
                            Console.WriteLine("{0}: owen_t(h={1}, a={2}): {3}", NumType, h, a, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Exponential integrals and related functions



            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp_integral_e1"))
            {
                string name = "exp_integral_e1";
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.exp_integral_e1(x); break; }
                            case " sreal": { res1 = sreal.exp_integral_e1(x); break; }
                            case " dreal": { res1 = dreal.exp_integral_e1(x); break; }
                            case " ereal": { res1 = ereal.exp_integral_e1(x); break; }
                            case " qreal": { res1 = qreal.exp_integral_e1(x); break; }
                            case " oreal": { res1 = oreal.exp_integral_e1(x); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.exp_integral_e1(x); break; }
                            case "sflint": { res1 = sflint.exp_integral_e1(x); break; }
                            case "dflint": { res1 = dflint.exp_integral_e1(x); break; }
                            case "eflint": { res1 = eflint.exp_integral_e1(x); break; }
                            case "qflint": { res1 = qflint.exp_integral_e1(x); break; }
                            case "oflint": { res1 = oflint.exp_integral_e1(x); break; }
                            case "mflint": { res1 = mflint.exp_integral_e1(x); break; }
                            case "aflint": { res1 = aflint.exp_integral_e1(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp_integral_ei"))
            {
                string name = "exp_integral_ei";
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.exp_integral_ei(x); break; }
                            case " sreal": { res1 = sreal.exp_integral_ei(x); break; }
                            case " dreal": { res1 = dreal.exp_integral_ei(x); break; }
                            case " ereal": { res1 = ereal.exp_integral_ei(x); break; }
                            case " qreal": { res1 = qreal.exp_integral_ei(x); break; }
                            case " oreal": { res1 = oreal.exp_integral_ei(x); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.exp_integral_ei(x); break; }
                            case "sflint": { res1 = sflint.exp_integral_ei(x); break; }
                            case "dflint": { res1 = dflint.exp_integral_ei(x); break; }
                            case "eflint": { res1 = eflint.exp_integral_ei(x); break; }
                            case "qflint": { res1 = qflint.exp_integral_ei(x); break; }
                            case "oflint": { res1 = oflint.exp_integral_ei(x); break; }
                            case "mflint": { res1 = mflint.exp_integral_ei(x); break; }
                            case "aflint": { res1 = aflint.exp_integral_ei(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("log_integral"))
            {
                string name = "log_integral";
                InputArray1 = new[] { -4.333d, 0.0d, 1.333d, 4.333d, 14.333d };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.log_integral(x); break; }
                            case " sreal": { res1 = sreal.log_integral(x); break; }
                            case " dreal": { res1 = dreal.log_integral(x); break; }
                            case " ereal": { res1 = ereal.log_integral(x); break; }
                            case " qreal": { res1 = qreal.log_integral(x); break; }
                            case " oreal": { res1 = oreal.log_integral(x); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.log_integral(x); break; }
                            case "sflint": { res1 = sflint.log_integral(x); break; }
                            case "dflint": { res1 = dflint.log_integral(x); break; }
                            case "eflint": { res1 = eflint.log_integral(x); break; }
                            case "qflint": { res1 = qflint.log_integral(x); break; }
                            case "oflint": { res1 = oflint.log_integral(x); break; }
                            case "mflint": { res1 = mflint.log_integral(x); break; }
                            case "aflint": { res1 = aflint.log_integral(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cosh_integral"))
            {
                string name = "cosh_integral";
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.cosh_integral(x); break; }
                            case " sreal": { res1 = sreal.cosh_integral(x); break; }
                            case " dreal": { res1 = dreal.cosh_integral(x); break; }
                            case " ereal": { res1 = ereal.cosh_integral(x); break; }
                            case " qreal": { res1 = qreal.cosh_integral(x); break; }
                            case " oreal": { res1 = oreal.cosh_integral(x); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.cosh_integral(x); break; }
                            case "sflint": { res1 = sflint.cosh_integral(x); break; }
                            case "dflint": { res1 = dflint.cosh_integral(x); break; }
                            case "eflint": { res1 = eflint.cosh_integral(x); break; }
                            case "qflint": { res1 = qflint.cosh_integral(x); break; }
                            case "oflint": { res1 = oflint.cosh_integral(x); break; }
                            case "mflint": { res1 = mflint.cosh_integral(x); break; }
                            case "aflint": { res1 = aflint.cosh_integral(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sinh_integral"))
            {
                string name = "sinh_integral";
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.sinh_integral(x); break; }
                            case " sreal": { res1 = sreal.sinh_integral(x); break; }
                            case " dreal": { res1 = dreal.sinh_integral(x); break; }
                            case " ereal": { res1 = ereal.sinh_integral(x); break; }
                            case " qreal": { res1 = qreal.sinh_integral(x); break; }
                            case " oreal": { res1 = oreal.sinh_integral(x); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.sinh_integral(x); break; }
                            case "sflint": { res1 = sflint.sinh_integral(x); break; }
                            case "dflint": { res1 = dflint.sinh_integral(x); break; }
                            case "eflint": { res1 = eflint.sinh_integral(x); break; }
                            case "qflint": { res1 = qflint.sinh_integral(x); break; }
                            case "oflint": { res1 = oflint.sinh_integral(x); break; }
                            case "mflint": { res1 = mflint.sinh_integral(x); break; }
                            case "aflint": { res1 = aflint.sinh_integral(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("exp_integral_en"))
            {
                string name = "exp_integral_en";
                InputArrayInt1 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                InputArray1 = new[] { -0.333d, 0.0d, 0.333d, double.PositiveInfinity }; // -inf , Nan crashes
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1})", n, x);
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
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.exp_integral_en(n, x); break; }
                                case "sflint": { res1 = sflint.exp_integral_en(n, x); break; }
                                case "dflint": { res1 = dflint.exp_integral_en(n, x); break; }
                                case "eflint": { res1 = eflint.exp_integral_en(n, x); break; }
                                case "qflint": { res1 = qflint.exp_integral_en(n, x); break; }
                                case "oflint": { res1 = oflint.exp_integral_en(n, x); break; }
                                case "mflint": { res1 = mflint.exp_integral_en(n, x); break; }
                                case "aflint": { res1 = aflint.exp_integral_en(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("cos_integral"))
            {
                string name = "cos_integral";
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.cos_integral(x); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.cos_integral(x); break; }
                            case "dflint": { res1 = dflint.cos_integral(x); break; }
                            case "eflint": { res1 = eflint.cos_integral(x); break; }
                            case "qflint": { res1 = qflint.cos_integral(x); break; }
                            case "oflint": { res1 = oflint.cos_integral(x); break; }
                            case "mflint": { res1 = mflint.cos_integral(x); break; }
                            case "aflint": { res1 = aflint.cos_integral(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sin_integral"))
            {
                string name = "sin_integral";
                InputArray1 = new[] { -4.333d, 0.0d, 4.333d };
                foreach (var x in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x={0})", x);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.sin_integral(x); break; }
#if HasArbPrecNet
                            case "sflint": { res1 = sflint.sin_integral(x); break; }
                            case "dflint": { res1 = dflint.sin_integral(x); break; }
                            case "eflint": { res1 = eflint.sin_integral(x); break; }
                            case "qflint": { res1 = qflint.sin_integral(x); break; }
                            case "oflint": { res1 = oflint.sin_integral(x); break; }
                            case "mflint": { res1 = mflint.sin_integral(x); break; }
                            case "aflint": { res1 = aflint.sin_integral(x); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }





            #endregion







        }






        public static void RealHypergeometric_1F1()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTests_RealHypergeometric_1F1();
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