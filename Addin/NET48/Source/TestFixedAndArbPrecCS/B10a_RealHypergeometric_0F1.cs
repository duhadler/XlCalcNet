
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

        public static void RunTests_RealHypergeometric_0F1()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(80);
#endif
            string[] NTA1 = new[] { "math53", " sreal", " dreal", " ereal", " qreal", " oreal" };
            string[] NTA2 = new[] { " mreal", "sflint", "dflint", "eflint", "qflint", "oflint", "mflint", "aflint" };
            string[] NumTypeArray = NTA1.Concat(NTA2).ToArray();

            //string[] FunctionArray = new[] { "all" };
            string[] FunctionArray = new[] { "besseltheta" };
            bool scaled = true;
            DemoChapter0F1(NumTypeArray, FunctionArray, scaled);
        }


        public static void DemoChapter0F1(string[] NumTypeArray, string[] FunctionArray, bool scaled)
        {
            double[] InputArray1;
            double[] InputArray2;
            int[] InputArrayInt1;
            int[] InputArrayInt2;


            #region 0F1: Overview


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_0f1"))
            {
                InputArray1 = new[] { 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { 0.0d, 0.5d, 1.0d };
                foreach (var b in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("hyperg_0f1(b={0}, x={1})", b, x);
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
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.hyperg_0f1(b, x); break; }
                                case "sflint": { res1 = sflint.hyperg_0f1(b, x); break; }
                                case "dflint": { res1 = dflint.hyperg_0f1(b, x); break; }
                                case "eflint": { res1 = eflint.hyperg_0f1(b, x); break; }
                                case "qflint": { res1 = qflint.hyperg_0f1(b, x); break; }
                                case "oflint": { res1 = oflint.hyperg_0f1(b, x); break; }
                                case "mflint": { res1 = mflint.hyperg_0f1(b, x); break; }
                                case "aflint": { res1 = aflint.hyperg_0f1(b, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hyperg_0f1r"))
            {
                InputArray1 = new[] { -4.0, 0.0d, 0.75d, 1.5d };
                InputArray2 = new[] { -4.0, 0.0d, 0.5d, 1.0d };
                foreach (var b in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("hyperg_0f1(b={0}, x={1})", b, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.hyperg_0f1r(b, x); break; }
                                case " sreal": { res1 = sreal.hyperg_0f1r(b, x); break; }
                                case " dreal": { res1 = dreal.hyperg_0f1r(b, x); break; }
                                case " ereal": { res1 = ereal.hyperg_0f1r(b, x); break; }
                                case " qreal": { res1 = qreal.hyperg_0f1r(b, x); break; }
                                case " oreal": { res1 = oreal.hyperg_0f1r(b, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.hyperg_0f1r(b, x); break; }
                                case "sflint": { res1 = sflint.hyperg_0f1r(b, x); break; }
                                case "dflint": { res1 = dflint.hyperg_0f1r(b, x); break; }
                                case "eflint": { res1 = eflint.hyperg_0f1r(b, x); break; }
                                case "qflint": { res1 = qflint.hyperg_0f1r(b, x); break; }
                                case "oflint": { res1 = oflint.hyperg_0f1r(b, x); break; }
                                case "mflint": { res1 = mflint.hyperg_0f1r(b, x); break; }
                                case "aflint": { res1 = aflint.hyperg_0f1r(b, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            #endregion




            #region Bessel functions of integer order

            //Console.WriteLine("Hello DemoDoubleBessel!");


            //int n_;
            //double x_, res_; //, v_, u_



            //x_ = 0.75d;
            //res_ = math53.bessel_j0(x_);
            //Console.WriteLine("x_: {0}, math53.BesselJ0(x_): {1}", x_, res_);

            //x_ = 0.75d;
            //res_ = math53.bessel_j1(x_);
            //Console.WriteLine("x_: {0}, math53.BesselJ1(x_): {1}", x_, res_);

            //x_ = 0.75d;
            //n_ = 3;
            //res_ = math53.bessel_jn(n_, x_);
            //Console.WriteLine("n_: {0}, x_: {1}, math53.BesselJn(n_, x_): {2}", n_, x_, res_);


            //Console.WriteLine();


            //x_ = 0.75d;
            //res_ = math53.bessel_y0(x_);
            //Console.WriteLine("x_: {0}, math53.BesselY0(x_): {1}", x_, res_);

            //x_ = 0.75d;
            //res_ = math53.bessel_y1(x_);
            //Console.WriteLine("x_: {0}, math53.BesselY1(x_): {1}", x_, res_);

            //x_ = 0.75d;
            //n_ = 3;
            //res_ = math53.bessel_yn(n_, x_);
            //Console.WriteLine("n_: {0}, x_: {1}, math53.BesselYn(n_, x_): {2}", n_, x_, res_);


            //Console.WriteLine();



            //#endregion




            //#region Modified Bessel functions of integer order



            //x_ = 0.75d;
            //res_ = math53.bessel_i0(x_);
            //Console.WriteLine("x_: {0}, math53.BesselI0(x_): {1}", x_, res_);

            //x_ = 0.75d;
            //res_ = math53.bessel_i0e(x_);
            //Console.WriteLine("x_: {0}, math53.BesselI0e(x_): {1}", x_, res_);

            //x_ = 0.75d;
            //res_ = math53.bessel_i1(x_);
            //Console.WriteLine("x_: {0}, math53.BesselI1(x_): {1}", x_, res_);

            //x_ = 0.75d;
            //res_ = math53.bessel_i1e(x_);
            //Console.WriteLine("x_: {0}, math53.BesselI1e(x_): {1}", x_, res_);

            //x_ = 0.75d;
            //n_ = 3;
            //res_ = math53.bessel_in(n_, x_);
            //Console.WriteLine("n_: {0}, x_: {1}, math53.BesselIn(n_, x_): {2}", n_, x_, res_);


            //Console.WriteLine();


            //x_ = 0.75d;
            //res_ = math53.bessel_k0(x_);
            //Console.WriteLine("x_: {0}, math53.BesselK0(x_): {1}", x_, res_);

            //x_ = 0.75d;
            //res_ = math53.bessel_k0e(x_);
            //Console.WriteLine("x_: {0}, math53.BesselK0e(x_): {1}", x_, res_);

            //x_ = 0.75d;
            //res_ = math53.bessel_k1(x_);
            //Console.WriteLine("x_: {0}, math53.BesselK1(x_): {1}", x_, res_);

            //x_ = 0.75d;
            //res_ = math53.bessel_k1e(x_);
            //Console.WriteLine("x_: {0}, math53.BesselK1e(x_): {1}", x_, res_);

            //x_ = 0.75d;
            //n_ = 3;
            //res_ = math53.bessel_kn(n_, x_);
            //Console.WriteLine("n_: {0}, x_: {1}, math53.BesselIn(n_, x_): {2}", n_, x_, res_);







            #endregion




            #region Bessel functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_jv"))
            {
                string name = "bessel_jv";
                if (scaled) name += "_scaled";
                // InputArray1 = {-4.333, 0.0, 1.0, 1.5, 4.333}
                // InputArray2 = {-4.333, 0.0, 1.0, 1.5, 4.333}
                InputArray1 = new[] { -1.5d, -1.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -1.0d, 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1})", nu, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_jv(nu, x, scaled); break; }
                                case " sreal": { res1 = sreal.bessel_jv(nu, x, scaled); break; }
                                case " dreal": { res1 = dreal.bessel_jv(nu, x, scaled); break; }
                                case " ereal": { res1 = ereal.bessel_jv(nu, x, scaled); break; }
                                case " qreal": { res1 = qreal.bessel_jv(nu, x, scaled); break; }
                                case " oreal": { res1 = oreal.bessel_jv(nu, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_jv(nu, x, scaled); break; }
                                case "sflint": { res1 = sflint.bessel_jv(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.bessel_jv(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.bessel_jv(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.bessel_jv(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.bessel_jv(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.bessel_jv(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.bessel_jv(nu, x, scaled); break; }
#endif

                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_yv"))
            {
                string name = "bessel_yv";
                if (scaled) name += "_scaled";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1})", nu, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_yv(nu, x, scaled); break; }
                                case " sreal": { res1 = sreal.bessel_yv(nu, x, scaled); break; }
                                case " dreal": { res1 = dreal.bessel_yv(nu, x, scaled); break; }
                                case " ereal": { res1 = ereal.bessel_yv(nu, x, scaled); break; }
                                case " qreal": { res1 = qreal.bessel_yv(nu, x, scaled); break; }
                                case " oreal": { res1 = oreal.bessel_yv(nu, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_yv(nu, x, scaled); break; }
                                case "sflint": { res1 = sflint.bessel_yv(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.bessel_yv(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.bessel_yv(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.bessel_yv(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.bessel_yv(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.bessel_yv(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.bessel_yv(nu, x, scaled); break; }
#endif

                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_jv_prime"))
            {
                string name = "bessel_jv_prime";
                if (scaled) name += "_scaled";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1})", nu, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_jv_prime(nu, x, scaled); break; }
                                case " sreal": { res1 = sreal.bessel_jv_prime(nu, x, scaled); break; }
                                case " dreal": { res1 = dreal.bessel_jv_prime(nu, x, scaled); break; }
                                case " ereal": { res1 = ereal.bessel_jv_prime(nu, x, scaled); break; }
                                case " qreal": { res1 = qreal.bessel_jv_prime(nu, x, scaled); break; }
                                case " oreal": { res1 = oreal.bessel_jv_prime(nu, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_jv_prime(nu, x, scaled); break; }
                                case "sflint": { res1 = sflint.bessel_jv_prime(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.bessel_jv_prime(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.bessel_jv_prime(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.bessel_jv_prime(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.bessel_jv_prime(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.bessel_jv_prime(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.bessel_jv_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);

                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_yv_prime"))
            {
                string name = "bessel_yv_prime";
                if (scaled) name += "_scaled";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1})", nu, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_yv_prime(nu, x, scaled); break; }
                                case " sreal": { res1 = sreal.bessel_yv_prime(nu, x, scaled); break; }
                                case " dreal": { res1 = dreal.bessel_yv_prime(nu, x, scaled); break; }
                                case " ereal": { res1 = ereal.bessel_yv_prime(nu, x, scaled); break; }
                                case " qreal": { res1 = qreal.bessel_yv_prime(nu, x, scaled); break; }
                                case " oreal": { res1 = oreal.bessel_yv_prime(nu, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_yv_prime(nu, x, scaled); break; }
                                case "sflint": { res1 = sflint.bessel_yv_prime(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.bessel_yv_prime(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.bessel_yv_prime(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.bessel_yv_prime(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.bessel_yv_prime(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.bessel_yv_prime(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.bessel_yv_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
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
                        Console.WriteLine();
                        Console.WriteLine("bessel_jv_zero(nu={0}, m={1})", nu, m);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_jv_zero(nu, m); break; }
                                case " sreal": { res1 = sreal.bessel_jv_zero(nu, m); break; }
                                case " dreal": { res1 = dreal.bessel_jv_zero(nu, m); break; }
                                case " ereal": { res1 = ereal.bessel_jv_zero(nu, m); break; }
                                case " qreal": { res1 = qreal.bessel_jv_zero(nu, m); break; }
                                case " oreal": { res1 = oreal.bessel_jv_zero(nu, m); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_jv_zero(nu, m); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
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
                        Console.WriteLine();
                        Console.WriteLine("bessel_yv_zero(nu={0}, m={1})", nu, m);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_yv_zero(sreal.t(nu), m); break; }
                                case " sreal": { res1 = sreal.bessel_yv_zero(sreal.t(nu), m); break; }
                                case " dreal": { res1 = dreal.bessel_yv_zero(sreal.t(nu), m); break; }
                                case " ereal": { res1 = ereal.bessel_yv_zero(sreal.t(nu), m); break; }
                                case " qreal": { res1 = qreal.bessel_yv_zero(sreal.t(nu), m); break; }
                                case " oreal": { res1 = oreal.bessel_yv_zero(sreal.t(nu), m); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_yv_zero(sreal.t(nu), m); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            #endregion



            #region Modified Bessel functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_iv"))
            {
                string name = "bessel_iv";
                if (scaled) name += "_scaled";
                InputArray1 = new[] { -1.5d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1})", nu, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_iv(nu, x, scaled); break; }
                                case " sreal": { res1 = sreal.bessel_iv(nu, x, scaled); break; }
                                case " dreal": { res1 = dreal.bessel_iv(nu, x, scaled); break; }
                                case " ereal": { res1 = ereal.bessel_iv(nu, x, scaled); break; }
                                case " qreal": { res1 = qreal.bessel_iv(nu, x, scaled); break; }
                                case " oreal": { res1 = oreal.bessel_iv(nu, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_iv(nu, x, scaled); break; }
                                case "sflint": { res1 = sflint.bessel_iv(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.bessel_iv(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.bessel_iv(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.bessel_iv(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.bessel_iv(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.bessel_iv(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.bessel_iv(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_kv"))
            {
                string name = "bessel_kv";
                if (scaled) name += "_scaled";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1})", nu, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_kv(nu, x, scaled); break; }
                                case " sreal": { res1 = sreal.bessel_kv(nu, x, scaled); break; }
                                case " dreal": { res1 = dreal.bessel_kv(nu, x, scaled); break; }
                                case " ereal": { res1 = ereal.bessel_kv(nu, x, scaled); break; }
                                case " qreal": { res1 = qreal.bessel_kv(nu, x, scaled); break; }
                                case " oreal": { res1 = oreal.bessel_kv(nu, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_kv(nu, x, scaled); break; }
                                case "sflint": { res1 = sflint.bessel_kv(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.bessel_kv(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.bessel_kv(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.bessel_kv(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.bessel_kv(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.bessel_kv(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.bessel_kv(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_iv_prime"))
            {
                string name = "bessel_iv_prime";
                if (scaled) name += "_scaled";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1})", nu, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_iv_prime(nu, x, scaled); break; }
                                case " sreal": { res1 = sreal.bessel_iv_prime(nu, x, scaled); break; }
                                case " dreal": { res1 = dreal.bessel_iv_prime(nu, x, scaled); break; }
                                case " ereal": { res1 = ereal.bessel_iv_prime(nu, x, scaled); break; }
                                case " qreal": { res1 = qreal.bessel_iv_prime(nu, x, scaled); break; }
                                case " oreal": { res1 = oreal.bessel_iv_prime(nu, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_iv_prime(nu, x, scaled); break; }
                                case "sflint": { res1 = sflint.bessel_iv_prime(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.bessel_iv_prime(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.bessel_iv_prime(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.bessel_iv_prime(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.bessel_iv_prime(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.bessel_iv_prime(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.bessel_iv_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("bessel_kv_prime"))
            {
                string name = "bessel_kv_prime";
                if (scaled) name += "_scaled";
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1})", nu, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.bessel_kv_prime(nu, x, scaled); break; }
                                case " sreal": { res1 = sreal.bessel_kv_prime(nu, x, scaled); break; }
                                case " dreal": { res1 = dreal.bessel_kv_prime(nu, x, scaled); break; }
                                case " ereal": { res1 = ereal.bessel_kv_prime(nu, x, scaled); break; }
                                case " qreal": { res1 = qreal.bessel_kv_prime(nu, x, scaled); break; }
                                case " oreal": { res1 = oreal.bessel_kv_prime(nu, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.bessel_kv_prime(nu, x, scaled); break; }
                                case "sflint": { res1 = sflint.bessel_kv_prime(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.bessel_kv_prime(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.bessel_kv_prime(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.bessel_kv_prime(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.bessel_kv_prime(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.bessel_kv_prime(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.bessel_kv_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion




            #region Spherical Bessel functions

            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_jn"))
            {
                string name = "sph_bessel_jn";
                InputArrayInt1 = new[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
                //InputArrayInt1 = new[] { 1 };
                InputArray1 = new[] { -4.0, -2.0, -2.0, -1.0, -1E-8, 0.0, 1E-8, 1.0, 2.0, 3.0 };
                //InputArray1 = new[] { -4.0 };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_bessel_jn(n, x, scaled); break; }
                                case " sreal": { res1 = sreal.sph_bessel_jn(n, x, scaled); break; }
                                case " dreal": { res1 = dreal.sph_bessel_jn(n, x, scaled); break; }
                                case " ereal": { res1 = ereal.sph_bessel_jn(n, x, scaled); break; }
                                case " qreal": { res1 = qreal.sph_bessel_jn(n, x, scaled); break; }
                                case " oreal": { res1 = oreal.sph_bessel_jn(n, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_bessel_jn(n, x, scaled); break; }
                                case "sflint": { res1 = sflint.sph_bessel_jn(n, x, scaled); break; }
                                case "dflint": { res1 = dflint.sph_bessel_jn(n, x, scaled); break; }
                                case "eflint": { res1 = eflint.sph_bessel_jn(n, x, scaled); break; }
                                case "qflint": { res1 = qflint.sph_bessel_jn(n, x, scaled); break; }
                                case "oflint": { res1 = oflint.sph_bessel_jn(n, x, scaled); break; }
                                case "mflint": { res1 = mflint.sph_bessel_jn(n, x, scaled); break; }
                                case "aflint": { res1 = aflint.sph_bessel_jn(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_yn"))
            {
                string name = "sph_bessel_yn";
                InputArrayInt1 = new[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
                //InputArrayInt1 = new[] { 1 };
                InputArray1 = new[] { -4.0, -2.0, -2.0, -1.0, -1E-8, 0.0, 1E-8, 1.0, 2.0, 3.0 };
                //InputArray1 = new[] { -4.0 };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_bessel_yn(n, x, scaled); break; }
                                case " sreal": { res1 = sreal.sph_bessel_yn(n, x, scaled); break; }
                                case " dreal": { res1 = dreal.sph_bessel_yn(n, x, scaled); break; }
                                case " ereal": { res1 = ereal.sph_bessel_yn(n, x, scaled); break; }
                                case " qreal": { res1 = qreal.sph_bessel_yn(n, x, scaled); break; }
                                case " oreal": { res1 = oreal.sph_bessel_yn(n, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_bessel_yn(n, x, scaled); break; }
                                case "sflint": { res1 = sflint.sph_bessel_yn(n, x, scaled); break; }
                                case "dflint": { res1 = dflint.sph_bessel_yn(n, x, scaled); break; }
                                case "eflint": { res1 = eflint.sph_bessel_yn(n, x, scaled); break; }
                                case "qflint": { res1 = qflint.sph_bessel_yn(n, x, scaled); break; }
                                case "oflint": { res1 = oflint.sph_bessel_yn(n, x, scaled); break; }
                                case "mflint": { res1 = mflint.sph_bessel_yn(n, x, scaled); break; }
                                case "aflint": { res1 = aflint.sph_bessel_yn(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_jn_prime"))
            {
                string name = "sph_bessel_jn_prime";
                InputArrayInt1 = new[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
                //InputArrayInt1 = new[] { 1 };
                InputArray2 = new[] { -4.0, -2.0, -2.0, -1.0, -1E-8, 0.0, 1E-8, 1.0, 2.0, 3.0 };
                //InputArray2 = new[] { -4.0 };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_bessel_jn_prime(n, x, scaled); break; }
                                case " sreal": { res1 = sreal.sph_bessel_jn_prime(n, x, scaled); break; }
                                case " dreal": { res1 = dreal.sph_bessel_jn_prime(n, x, scaled); break; }
                                case " ereal": { res1 = ereal.sph_bessel_jn_prime(n, x, scaled); break; }
                                case " qreal": { res1 = qreal.sph_bessel_jn_prime(n, x, scaled); break; }
                                case " oreal": { res1 = oreal.sph_bessel_jn_prime(n, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_bessel_jn_prime(n, x, scaled); break; }
                                case "sflint": { res1 = sflint.sph_bessel_jn_prime(n, x, scaled); break; }
                                case "dflint": { res1 = dflint.sph_bessel_jn_prime(n, x, scaled); break; }
                                case "eflint": { res1 = eflint.sph_bessel_jn_prime(n, x, scaled); break; }
                                case "qflint": { res1 = qflint.sph_bessel_jn_prime(n, x, scaled); break; }
                                case "oflint": { res1 = oflint.sph_bessel_jn_prime(n, x, scaled); break; }
                                case "mflint": { res1 = mflint.sph_bessel_jn_prime(n, x, scaled); break; }
                                case "aflint": { res1 = aflint.sph_bessel_jn_prime(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_yn_prime"))
            {
                string name = "sph_bessel_yn_prime";
                InputArrayInt1 = new[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
                //InputArrayInt1 = new[] { 1 };
                InputArray2 = new[] { -4.0, -2.0, -2.0, -1.0, -1E-8, 0.0, 1E-8, 1.0, 2.0, 3.0 };
                //InputArray2 = new[] { -4.0 };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_bessel_yn_prime(n, x, scaled); break; }
                                case " sreal": { res1 = sreal.sph_bessel_yn_prime(n, x, scaled); break; }
                                case " dreal": { res1 = dreal.sph_bessel_yn_prime(n, x, scaled); break; }
                                case " ereal": { res1 = ereal.sph_bessel_yn_prime(n, x, scaled); break; }
                                case " qreal": { res1 = qreal.sph_bessel_yn_prime(n, x, scaled); break; }
                                case " oreal": { res1 = oreal.sph_bessel_yn_prime(n, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_bessel_yn_prime(n, x, scaled); break; }
                                case "sflint": { res1 = sflint.sph_bessel_yn_prime(n, x, scaled); break; }
                                case "dflint": { res1 = dflint.sph_bessel_yn_prime(n, x, scaled); break; }
                                case "eflint": { res1 = eflint.sph_bessel_yn_prime(n, x, scaled); break; }
                                case "qflint": { res1 = qflint.sph_bessel_yn_prime(n, x, scaled); break; }
                                case "oflint": { res1 = oflint.sph_bessel_yn_prime(n, x, scaled); break; }
                                case "mflint": { res1 = mflint.sph_bessel_yn_prime(n, x, scaled); break; }
                                case "aflint": { res1 = aflint.sph_bessel_yn_prime(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_jn_zero"))
            {
                string name = "sph_bessel_jn_zero";
                InputArrayInt1 = new[] { 1, 2, 4, 6, 8, 10 };
                InputArrayInt2 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var m in InputArrayInt2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, m={1})", n, m);

                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_bessel_jn_zero(n, m); break; }
                                case " sreal": { res1 = sreal.sph_bessel_jn_zero(n, m); break; }
                                case " dreal": { res1 = dreal.sph_bessel_jn_zero(n, m); break; }
                                case " ereal": { res1 = ereal.sph_bessel_jn_zero(n, m); break; }
                                case " qreal": { res1 = qreal.sph_bessel_jn_zero(n, m); break; }
                                case " oreal": { res1 = oreal.sph_bessel_jn_zero(n, m); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_bessel_jn_zero(n, m); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_yn_zero"))
            {
                string name = "sph_bessel_yn_zero";
                InputArrayInt1 = new[] { 1, 2, 4, 6, 8, 10 };
                InputArrayInt2 = new[] { 0, 1, 2, 4, 6, 8, 10 };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var m in InputArrayInt2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, m={1})", n, m);

                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_bessel_yn_zero(n, m); break; }
                                case " sreal": { res1 = sreal.sph_bessel_yn_zero(n, m); break; }
                                case " dreal": { res1 = dreal.sph_bessel_yn_zero(n, m); break; }
                                case " ereal": { res1 = ereal.sph_bessel_yn_zero(n, m); break; }
                                case " qreal": { res1 = qreal.sph_bessel_yn_zero(n, m); break; }
                                case " oreal": { res1 = oreal.sph_bessel_yn_zero(n, m); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_bessel_yn_zero(n, m); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }






            #endregion




            #region Modified Spherical Bessel functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_in"))
            {
                string name = "sph_bessel_in";
                InputArrayInt1 = new[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
                //InputArrayInt1 = new[] { 1 };
                InputArray1 = new[] { -4.0, -2.0, -2.0, -1.0, -1E-8, 0.0, 1E-8, 1.0, 2.0, 3.0 };
                //InputArray1 = new[] { -4.0 };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_bessel_in(n, x, scaled); break; }
                                case " sreal": { res1 = sreal.sph_bessel_in(n, x, scaled); break; }
                                case " dreal": { res1 = dreal.sph_bessel_in(n, x, scaled); break; }
                                case " ereal": { res1 = ereal.sph_bessel_in(n, x, scaled); break; }
                                case " qreal": { res1 = qreal.sph_bessel_in(n, x, scaled); break; }
                                case " oreal": { res1 = oreal.sph_bessel_in(n, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_bessel_in(n, x, scaled); break; }
                                case "sflint": { res1 = sflint.sph_bessel_in(n, x, scaled); break; }
                                case "dflint": { res1 = dflint.sph_bessel_in(n, x, scaled); break; }
                                case "eflint": { res1 = eflint.sph_bessel_in(n, x, scaled); break; }
                                case "qflint": { res1 = qflint.sph_bessel_in(n, x, scaled); break; }
                                case "oflint": { res1 = oflint.sph_bessel_in(n, x, scaled); break; }
                                case "mflint": { res1 = mflint.sph_bessel_in(n, x, scaled); break; }
                                case "aflint": { res1 = aflint.sph_bessel_in(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_kn"))
            {
                string name = "sph_bessel_kn";
                InputArrayInt1 = new[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
                //InputArrayInt1 = new[] { 1 };
                InputArray1 = new[] { -4.0, -2.0, -2.0, -1.0, -1E-8, 0.0, 1E-8, 1.0, 2.0, 3.0 };
                //InputArray1 = new[] { -4.0 };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_bessel_kn(n, x, scaled); break; }
                                case " sreal": { res1 = sreal.sph_bessel_kn(n, x, scaled); break; }
                                case " dreal": { res1 = dreal.sph_bessel_kn(n, x, scaled); break; }
                                case " ereal": { res1 = ereal.sph_bessel_kn(n, x, scaled); break; }
                                case " qreal": { res1 = qreal.sph_bessel_kn(n, x, scaled); break; }
                                case " oreal": { res1 = oreal.sph_bessel_kn(n, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_bessel_kn(n, x, scaled); break; }
                                case "sflint": { res1 = sflint.sph_bessel_kn(n, x, scaled); break; }
                                case "dflint": { res1 = dflint.sph_bessel_kn(n, x, scaled); break; }
                                case "eflint": { res1 = eflint.sph_bessel_kn(n, x, scaled); break; }
                                case "qflint": { res1 = qflint.sph_bessel_kn(n, x, scaled); break; }
                                case "oflint": { res1 = oflint.sph_bessel_kn(n, x, scaled); break; }
                                case "mflint": { res1 = mflint.sph_bessel_kn(n, x, scaled); break; }
                                case "aflint": { res1 = aflint.sph_bessel_kn(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_in_prime"))
            {
                string name = "sph_bessel_in_prime";
                InputArrayInt1 = new[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
                //InputArrayInt1 = new[] { 1 };
                InputArray2 = new[] { -4.0, -2.0, -2.0, -1.0, -1E-8, 0.0, 1E-8, 1.0, 2.0, 3.0 };
                //InputArray2 = new[] { -4.0 };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_bessel_in_prime(n, x, scaled); break; }
                                case " sreal": { res1 = sreal.sph_bessel_in_prime(n, x, scaled); break; }
                                case " dreal": { res1 = dreal.sph_bessel_in_prime(n, x, scaled); break; }
                                case " ereal": { res1 = ereal.sph_bessel_in_prime(n, x, scaled); break; }
                                case " qreal": { res1 = qreal.sph_bessel_in_prime(n, x, scaled); break; }
                                case " oreal": { res1 = oreal.sph_bessel_in_prime(n, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_bessel_in_prime(n, x, scaled); break; }
                                case "sflint": { res1 = sflint.sph_bessel_in_prime(n, x, scaled); break; }
                                case "dflint": { res1 = dflint.sph_bessel_in_prime(n, x, scaled); break; }
                                case "eflint": { res1 = eflint.sph_bessel_in_prime(n, x, scaled); break; }
                                case "qflint": { res1 = qflint.sph_bessel_in_prime(n, x, scaled); break; }
                                case "oflint": { res1 = oflint.sph_bessel_in_prime(n, x, scaled); break; }
                                case "mflint": { res1 = mflint.sph_bessel_in_prime(n, x, scaled); break; }
                                case "aflint": { res1 = aflint.sph_bessel_in_prime(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_bessel_kn_prime"))
            {
                string name = "sph_bessel_kn_prime";
                InputArrayInt1 = new[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
                //InputArrayInt1 = new[] { 1 };
                InputArray2 = new[] { -4.0, -2.0, -2.0, -1.0, -1E-8, 0.0, 1E-8, 1.0, 2.0, 3.0 };
                //InputArray2 = new[] { -4.0 };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_bessel_kn_prime(n, x, scaled); break; }
                                case " sreal": { res1 = sreal.sph_bessel_kn_prime(n, x, scaled); break; }
                                case " dreal": { res1 = dreal.sph_bessel_kn_prime(n, x, scaled); break; }
                                case " ereal": { res1 = ereal.sph_bessel_kn_prime(n, x, scaled); break; }
                                case " qreal": { res1 = qreal.sph_bessel_kn_prime(n, x, scaled); break; }
                                case " oreal": { res1 = oreal.sph_bessel_kn_prime(n, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = oreal.sph_bessel_kn_prime(n, x, scaled); break; }
                                case "sflint": { res1 = sflint.sph_bessel_kn_prime(n, x, scaled); break; }
                                case "dflint": { res1 = dflint.sph_bessel_kn_prime(n, x, scaled); break; }
                                case "eflint": { res1 = eflint.sph_bessel_kn_prime(n, x, scaled); break; }
                                case "qflint": { res1 = qflint.sph_bessel_kn_prime(n, x, scaled); break; }
                                case "oflint": { res1 = oflint.sph_bessel_kn_prime(n, x, scaled); break; }
                                case "mflint": { res1 = mflint.sph_bessel_kn_prime(n, x, scaled); break; }
                                case "aflint": { res1 = aflint.sph_bessel_kn_prime(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("besselpoly"))
            {
                string name = "besselpoly";
                InputArrayInt1 = new[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
                //InputArrayInt1 = new[] { 1 };
                InputArray2 = new[] { -4.0, -2.0, -2.0, -1.0, -1E-8, 0.0, 1E-8, 1.0, 2.0, 1003.0 };
                //InputArray2 = new[] { -4.0 };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.besselpoly(n, x, scaled); break; }
                                case " sreal": { res1 = sreal.besselpoly(n, x, scaled); break; }
                                case " dreal": { res1 = dreal.besselpoly(n, x, scaled); break; }
                                case " ereal": { res1 = ereal.besselpoly(n, x, scaled); break; }
                                case " qreal": { res1 = qreal.besselpoly(n, x, scaled); break; }
                                case " oreal": { res1 = oreal.besselpoly(n, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.besselpoly(n, x, scaled); break; }
                                case "sflint": { res1 = sflint.besselpoly(n, x, scaled); break; }
                                case "dflint": { res1 = dflint.besselpoly(n, x, scaled); break; }
                                case "eflint": { res1 = eflint.besselpoly(n, x, scaled); break; }
                                case "qflint": { res1 = qflint.besselpoly(n, x, scaled); break; }
                                case "oflint": { res1 = oflint.besselpoly(n, x, scaled); break; }
                                case "mflint": { res1 = mflint.besselpoly(n, x, scaled); break; }
                                case "aflint": { res1 = aflint.besselpoly(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("besseltheta"))
            {
                string name = "besseltheta";
                InputArrayInt1 = new[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 ,10, 20, 30, 40};
                //InputArrayInt1 = new[] { 1 };
                InputArray2 = new[] { -4.0, -2.0, -2.0, -1.0, -1E-8, 0.0, 1E-8, 1.0, 2.0, 103.0 };
                //InputArray2 = new[] { -4.0 };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(n={0}, x={1}, scaled={2})", n, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.besseltheta(n, x, scaled); break; }
                                case " sreal": { res1 = sreal.besseltheta(n, x, scaled); break; }
                                case " dreal": { res1 = dreal.besseltheta(n, x, scaled); break; }
                                case " ereal": { res1 = ereal.besseltheta(n, x, scaled); break; }
                                case " qreal": { res1 = qreal.besseltheta(n, x, scaled); break; }
                                case " oreal": { res1 = oreal.besseltheta(n, x, scaled); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.besseltheta(n, x, scaled); break; }
                                case "sflint": { res1 = sflint.besseltheta(n, x, scaled); break; }
                                case "dflint": { res1 = dflint.besseltheta(n, x, scaled); break; }
                                case "eflint": { res1 = eflint.besseltheta(n, x, scaled); break; }
                                case "qflint": { res1 = qflint.besseltheta(n, x, scaled); break; }
                                case "oflint": { res1 = oflint.besseltheta(n, x, scaled); break; }
                                case "mflint": { res1 = mflint.besseltheta(n, x, scaled); break; }
                                case "aflint": { res1 = aflint.besseltheta(n, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            #endregion





            #region Hankel functions



            if (FunctionArray.Contains("all") | FunctionArray.Contains("hankel_h1"))
            {
                // InputArray1 = {-4.333, 0.0, 1.0, 1.5, 4.333}
                // InputArray2 = {-4.333, 0.0, 1.0, 1.5, 4.333}
                InputArray1 = new[] { -1.5d, -1.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -1.0d, 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("hankel_h1(nu={0}, x={1})", nu, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.hankel_h1(nu, x); break; }
                                case " sreal": { res1 = sreal.hankel_h1(nu, x); break; }
                                case " dreal": { res1 = dreal.hankel_h1(nu, x); break; }
                                case " ereal": { res1 = ereal.hankel_h1(nu, x); break; }
                                case " qreal": { res1 = qreal.hankel_h1(nu, x); break; }
                                case " oreal": { res1 = oreal.hankel_h1(nu, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.hankel_h1(nu, x); break; }
                                case "sflint": { res1 = sflint.hankel_h1(nu, x); break; }
                                case "dflint": { res1 = dflint.hankel_h1(nu, x); break; }
                                case "eflint": { res1 = eflint.hankel_h1(nu, x); break; }
                                case "qflint": { res1 = qflint.hankel_h1(nu, x); break; }
                                case "oflint": { res1 = oflint.hankel_h1(nu, x); break; }
                                case "mflint": { res1 = mflint.hankel_h1(nu, x); break; }
                                case "aflint": { res1 = aflint.hankel_h1(nu, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("hankel_h2"))
            {
                InputArray1 = new[] { 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("hankel_h2(nu={0}, x={1})", nu, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.hankel_h2(nu, x); break; }
                                case " sreal": { res1 = sreal.hankel_h2(nu, x); break; }
                                case " dreal": { res1 = dreal.hankel_h2(nu, x); break; }
                                case " ereal": { res1 = ereal.hankel_h2(nu, x); break; }
                                case " qreal": { res1 = qreal.hankel_h2(nu, x); break; }
                                case " oreal": { res1 = oreal.hankel_h2(nu, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.hankel_h2(nu, x); break; }
                                case "sflint": { res1 = sflint.hankel_h2(nu, x); break; }
                                case "dflint": { res1 = dflint.hankel_h2(nu, x); break; }
                                case "eflint": { res1 = eflint.hankel_h2(nu, x); break; }
                                case "qflint": { res1 = qflint.hankel_h2(nu, x); break; }
                                case "oflint": { res1 = oflint.hankel_h2(nu, x); break; }
                                case "mflint": { res1 = mflint.hankel_h2(nu, x); break; }
                                case "aflint": { res1 = aflint.hankel_h2(nu, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_hankel_h1"))
            {
                InputArrayInt1 = new[] { -4, -1, 0, 1, 2, 4 };
                InputArray1 = new[] { -4.0, -1.0, 0.000000001d, 1.0, double.PositiveInfinity };
                foreach (var n in InputArrayInt1)
                {
                    foreach (var x in InputArray1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("sph_hankel_h1(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_hankel_h1(n, x); break; }
                                case " sreal": { res1 = sreal.sph_hankel_h1(n, x); break; }
                                case " dreal": { res1 = dreal.sph_hankel_h1(n, x); break; }
                                case " ereal": { res1 = ereal.sph_hankel_h1(n, x); break; }
                                case " qreal": { res1 = qreal.sph_hankel_h1(n, x); break; }
                                case " oreal": { res1 = oreal.sph_hankel_h1(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_hankel_h1(n, x); break; }
                                case "sflint": { res1 = sflint.sph_hankel_h1(n, x); break; }
                                case "dflint": { res1 = dflint.sph_hankel_h1(n, x); break; }
                                case "eflint": { res1 = eflint.sph_hankel_h1(n, x); break; }
                                case "qflint": { res1 = qflint.sph_hankel_h1(n, x); break; }
                                case "oflint": { res1 = oflint.sph_hankel_h1(n, x); break; }
                                case "mflint": { res1 = mflint.sph_hankel_h1(n, x); break; }
                                case "aflint": { res1 = aflint.sph_hankel_h1(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("sph_hankel_h2"))
            {
                InputArrayInt1 = new[] { -4, -1, 0, 1, 2, 4 };
                InputArray1 = new[] { -4.0, -1.0, 0.000000001d, 1.0, double.PositiveInfinity };
                foreach (var x in InputArray1)
                {
                    foreach (var n in InputArrayInt1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("sph_hankel_h2(n={0}, x={1})", n, x);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.sph_hankel_h2(n, x); break; }
                                case " sreal": { res1 = sreal.sph_hankel_h2(n, x); break; }
                                case " dreal": { res1 = dreal.sph_hankel_h2(n, x); break; }
                                case " ereal": { res1 = ereal.sph_hankel_h2(n, x); break; }
                                case " qreal": { res1 = qreal.sph_hankel_h2(n, x); break; }
                                case " oreal": { res1 = oreal.sph_hankel_h2(n, x); break; }
#if HasArbPrecNet
                                case " mreal": { res1 = mreal.sph_hankel_h2(n, x); break; }
                                case "sflint": { res1 = sflint.sph_hankel_h2(n, x); break; }
                                case "dflint": { res1 = dflint.sph_hankel_h2(n, x); break; }
                                case "eflint": { res1 = eflint.sph_hankel_h2(n, x); break; }
                                case "qflint": { res1 = qflint.sph_hankel_h2(n, x); break; }
                                case "oflint": { res1 = oflint.sph_hankel_h2(n, x); break; }
                                case "mflint": { res1 = mflint.sph_hankel_h2(n, x); break; }
                                case "aflint": { res1 = aflint.sph_hankel_h2(n, x); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            #endregion






            #region Airy functions

            // crashes with NaN
            // InputArray = {-4.333, 0.0, 4.333, Double.PositiveInfinity}
            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_ai_scaled"))
            {
                string name = "airy_ai";
                if (scaled) name += "_scaled";

                InputArray1 = new[] { -10000000.0d, -4.333d, 0.0d, 4.333d, +100.0d, +200.0d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x1={0})", x1);

                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_ai(x1, scaled); break; }
                            case " sreal": { res1 = sreal.airy_ai(x1, scaled); break; }
                            case " dreal": { res1 = dreal.airy_ai(x1, scaled); break; }
                            case " ereal": { res1 = ereal.airy_ai(x1, scaled); break; }
                            case " qreal": { res1 = qreal.airy_ai(x1, scaled); break; }
                            case " oreal": { res1 = oreal.airy_ai(x1, scaled); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.airy_ai(x1, scaled); break; }
                            case "sflint": { res1 = sflint.airy_ai(x1, scaled); break; }
                            case "dflint": { res1 = dflint.airy_ai(x1, scaled); break; }
                            case "eflint": { res1 = eflint.airy_ai(x1, scaled); break; }
                            case "qflint": { res1 = qflint.airy_ai(x1, scaled); break; }
                            case "oflint": { res1 = oflint.airy_ai(x1, scaled); break; }
                            case "mflint": { res1 = mflint.airy_ai(x1, scaled); break; }
                            case "aflint": { res1 = aflint.airy_ai(x1, scaled); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            // crashes with NaN
            // InputArray = {-4.333, 0.0, 4.333, Double.PositiveInfinity}
            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_bi_scaled"))
            {
                string name = "airy_bi";
                if (scaled) name += "_scaled";
                InputArray1 = new[] { -10000000.0d, -4.333d, 0.0d, 4.333d, +100.0d, +200.0d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x1={0})", x1);

                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_bi(x1, scaled); break; }
                            case " sreal": { res1 = sreal.airy_bi(x1, scaled); break; }
                            case " dreal": { res1 = dreal.airy_bi(x1, scaled); break; }
                            case " ereal": { res1 = ereal.airy_bi(x1, scaled); break; }
                            case " qreal": { res1 = qreal.airy_bi(x1, scaled); break; }
                            case " oreal": { res1 = oreal.airy_bi(x1, scaled); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = oreal.airy_bi(x1, scaled); break; }
                            case "sflint": { res1 = sflint.airy_bi(x1, scaled); break; }
                            case "dflint": { res1 = dflint.airy_bi(x1, scaled); break; }
                            case "eflint": { res1 = eflint.airy_bi(x1, scaled); break; }
                            case "qflint": { res1 = eflint.airy_bi(x1, scaled); break; }
                            case "oflint": { res1 = oflint.airy_bi(x1, scaled); break; }
                            case "mflint": { res1 = mflint.airy_bi(x1, scaled); break; }
                            case "aflint": { res1 = aflint.airy_bi(x1, scaled); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            // crashes with NaN
            // InputArray = {-4.333, 0.0, 4.333, Double.PositiveInfinity}
            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_ai_prime_scaled"))
            {
                string name = "airy_ai_prime";
                if (scaled) name += "_scaled";
                InputArray1 = new[] { -10000000.0d, -4.333d, 0.0d, 4.333d, +100.0d, +200.0d };
                //InputArray1 = new[] { +200.0d };
                foreach (var x1 in InputArray1)
                {
                    Console.WriteLine();
                    Console.WriteLine(name + "(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_ai_prime(x1, scaled); break; }
                            case " sreal": { res1 = sreal.airy_ai_prime(x1, scaled); break; }
                            case " dreal": { res1 = dreal.airy_ai_prime(x1, scaled); break; }
                            case " ereal": { res1 = ereal.airy_ai_prime(x1, scaled); break; }
                            case " qreal": { res1 = qreal.airy_ai_prime(x1, scaled); break; }
                            case " oreal": { res1 = oreal.airy_ai_prime(x1, scaled); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.airy_ai_prime(x1, scaled); break; }
                            case "sflint": { res1 = sflint.airy_ai_prime(x1, scaled); break; }
                            case "dflint": { res1 = dflint.airy_ai_prime(x1, scaled); break; }
                            case "eflint": { res1 = eflint.airy_ai_prime(x1, scaled); break; }
                            case "qflint": { res1 = qflint.airy_ai_prime(x1, scaled); break; }
                            case "oflint": { res1 = oflint.airy_ai_prime(x1, scaled); break; }
                            case "mflint": { res1 = mflint.airy_ai_prime(x1, scaled); break; }
                            case "aflint": { res1 = aflint.airy_ai_prime(x1, scaled); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }



            // crashes with NaN
            // InputArray = {-4.333, 0.0, 4.333, Double.PositiveInfinity}
            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_bi_prime_scaled"))
            {
                InputArray1 = new[] { -10000000.0d, -4.333d, 0.0d, 4.333d, +100.0d, +200.0d };
                foreach (var x1 in InputArray1)
                {
                    string name = "airy_bi_prime";
                    if (scaled) name += "_scaled";
                    Console.WriteLine();
                    Console.WriteLine(name + "(x1={0})", x1);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_bi_prime(x1, scaled); break; }
                            case " sreal": { res1 = sreal.airy_bi_prime(x1, scaled); break; }
                            case " dreal": { res1 = dreal.airy_bi_prime(x1, scaled); break; }
                            case " ereal": { res1 = ereal.airy_bi_prime(x1, scaled); break; }
                            case " qreal": { res1 = qreal.airy_bi_prime(x1, scaled); break; }
                            case " oreal": { res1 = oreal.airy_bi_prime(x1, scaled); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.airy_bi_prime(x1, scaled); break; }
                            case "sflint": { res1 = sflint.airy_bi_prime(x1, scaled); break; }
                            case "dflint": { res1 = dflint.airy_bi_prime(x1, scaled); break; }
                            case "eflint": { res1 = eflint.airy_bi_prime(x1, scaled); break; }
                            case "qflint": { res1 = qflint.airy_bi_prime(x1, scaled); break; }
                            case "oflint": { res1 = oflint.airy_bi_prime(x1, scaled); break; }
                            case "mflint": { res1 = mflint.airy_bi_prime(x1, scaled); break; }
                            case "aflint": { res1 = aflint.airy_bi_prime(x1, scaled); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_ai_zero"))
            {
                InputArrayInt1 = new[] { 1, 2, 3, 4, 5 };
                foreach (var m in InputArrayInt1)
                {
                    Console.WriteLine();
                    Console.WriteLine("airy_ai_zero(m={0})", m);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_ai_zero(m); break; }
                            case " sreal": { res1 = sreal.airy_ai_zero(m); break; }
                            case " dreal": { res1 = dreal.airy_ai_zero(m); break; }
                            case " ereal": { res1 = ereal.airy_ai_zero(m); break; }
                            case " qreal": { res1 = qreal.airy_ai_zero(m); break; }
                            case " oreal": { res1 = oreal.airy_ai_zero(m); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.airy_ai_zero(m); break; }
                            case "sflint": { res1 = sflint.airy_ai_zero(m); break; }
                            case "dflint": { res1 = dflint.airy_ai_zero(m); break; }
                            case "eflint": { res1 = eflint.airy_ai_zero(m); break; }
                            case "qflint": { res1 = qflint.airy_ai_zero(m); break; }
                            case "oflint": { res1 = oflint.airy_ai_zero(m); break; }
                            case "mflint": { res1 = mflint.airy_ai_zero(m); break; }
                            case "aflint": { res1 = aflint.airy_ai_zero(m); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            if (FunctionArray.Contains("all") | FunctionArray.Contains("airy_bi_zero"))
            {
                InputArrayInt1 = new[] { 1, 2, 3, 4, 5 };
                foreach (var m in InputArrayInt1)
                {
                    Console.WriteLine();
                    Console.WriteLine("airy_bi_zero(m={0})", m);
                    foreach (var NumType in NumTypeArray)
                    {
                        object res1 = "Not done";
                        switch (NumType ?? "")
                        {
                            case "math53": { res1 = math53.airy_bi_zero(m); break; }
                            case " sreal": { res1 = sreal.airy_bi_zero(m); break; }
                            case " dreal": { res1 = dreal.airy_bi_zero(m); break; }
                            case " ereal": { res1 = ereal.airy_bi_zero(m); break; }
                            case " qreal": { res1 = qreal.airy_bi_zero(m); break; }
                            case " oreal": { res1 = oreal.airy_bi_zero(m); break; }
#if HasArbPrecNet
                            case " mreal": { res1 = mreal.airy_bi_zero(m); break; }
                            case "sflint": { res1 = sflint.airy_bi_zero(m); break; }
                            case "dflint": { res1 = dflint.airy_bi_zero(m); break; }
                            case "eflint": { res1 = eflint.airy_bi_zero(m); break; }
                            case "qflint": { res1 = qflint.airy_bi_zero(m); break; }
                            case "oflint": { res1 = oflint.airy_bi_zero(m); break; }
                            case "mflint": { res1 = mflint.airy_bi_zero(m); break; }
#endif
                        }
                        Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                    }
                }
                Console.WriteLine();
            }


            #endregion








            #region Kelvin functions


            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_ber"))
            {
                string name = "kelvin_ber";
                InputArray1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -4.333d, -1.5, -1.0, 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.kelvin_ber(nu, x, scaled); break; }
                                case " dreal": { res1 = math53.kelvin_ber0(x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.kelvin_ber(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.kelvin_ber(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.kelvin_ber(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.kelvin_ber(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.kelvin_ber(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.kelvin_ber(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.kelvin_ber(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_bei"))
            {
                string name = "kelvin_bei";
                InputArray1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -4.333d, -1.5, -1.0, 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.kelvin_bei(nu, x, scaled); break; }
                                case " dreal": { res1 = math53.kelvin_bei0(x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.kelvin_bei(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.kelvin_bei(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.kelvin_bei(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.kelvin_bei(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.kelvin_bei(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.kelvin_bei(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.kelvin_bei(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_ker"))
            {
                string name = "kelvin_ker";
                InputArray1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -4.333d, -1.5, -1.0, 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.kelvin_ker(nu, x, scaled); break; }
                                case " dreal": { res1 = math53.kelvin_ker0(x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.kelvin_ker(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.kelvin_ker(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.kelvin_ker(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.kelvin_ker(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.kelvin_ker(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.kelvin_ker(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.kelvin_ker(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_kei"))
            {
                string name = "kelvin_kei";
                InputArray1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -4.333d, -1.5, -1.0, 0.000000001d, 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.kelvin_kei(nu, x, scaled); break; }
                                case " dreal": { res1 = math53.kelvin_kei0(x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.kelvin_kei(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.kelvin_kei(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.kelvin_kei(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.kelvin_kei(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.kelvin_kei(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.kelvin_kei(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.kelvin_kei(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }





            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_ber_prime"))
            {
                string name = "kelvin_ber_prime";
                InputArray1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                //InputArray2 = new[] { -4.333d, -1.5, -1.0, 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -4.333d, -1.5, -1.0, 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.kelvin_ber_prime(nu, x, scaled); break; }
                                case " dreal": { res1 = math53.kelvin_ber_prime0(x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.kelvin_ber_prime(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.kelvin_ber_prime(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.kelvin_ber_prime(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.kelvin_ber_prime(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.kelvin_ber_prime(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.kelvin_ber_prime(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.kelvin_ber_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_bei_prime"))
            {
                string name = "kelvin_bei_prime";
                InputArray1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -4.333d, -1.5, -1.0, 0.0d, 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.kelvin_bei_prime(nu, x, scaled); break; }
                                case " dreal": { res1 = math53.kelvin_bei_prime0(x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.kelvin_bei_prime(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.kelvin_bei_prime(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.kelvin_bei_prime(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.kelvin_bei_prime(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.kelvin_bei_prime(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.kelvin_bei_prime(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.kelvin_bei_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_ker_prime"))
            {
                string name = "kelvin_ker_prime";
                InputArray1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                //InputArray2 = new[] { -4.333d, -1.5, -1.0, 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -4.333d, -1.5, -1.0, 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.kelvin_ker_prime(nu, x, scaled); break; }
                                case " sreal":
                                    {
                                        Double h = 1E-8;
                                        var res1a = math53.kelvin_ker(nu, x - h);
                                        var res1b = math53.kelvin_ker(nu, x + h);
                                        res1 = (res1b - res1a) / (2 * h);
                                        break;
                                    }
                                case " dreal": { res1 = math53.kelvin_ker_prime0(x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.kelvin_ker_prime(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.kelvin_ker_prime(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.kelvin_ker_prime(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.kelvin_ker_prime(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.kelvin_ker_prime(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.kelvin_ker_prime(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.kelvin_ker_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }



            if (FunctionArray.Contains("all") | FunctionArray.Contains("kelvin_kei_prime"))
            {
                string name = "kelvin_kei_prime";
                InputArray1 = new[] { 0.0d, 1.0d, 1.5d, 4.333d };
                InputArray2 = new[] { -4.333d, -1.5, -1.0, 0.000000001d, 1.0d, 1.5d, 4.333d };
                foreach (var nu in InputArray1)
                {
                    foreach (var x in InputArray2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(name + "(nu={0}, x={1}, scaled={2})", nu, x, scaled);
                        foreach (var NumType in NumTypeArray)
                        {
                            object res1 = "Not done";
                            switch (NumType ?? "")
                            {
                                case "math53": { res1 = math53.kelvin_kei_prime(nu, x, scaled); break; }
                                case " dreal": { res1 = math53.kelvin_kei_prime0(x); break; }
#if HasArbPrecNet
                                case "sflint": { res1 = sflint.kelvin_kei_prime(nu, x, scaled); break; }
                                case "dflint": { res1 = dflint.kelvin_kei_prime(nu, x, scaled); break; }
                                case "eflint": { res1 = eflint.kelvin_kei_prime(nu, x, scaled); break; }
                                case "qflint": { res1 = qflint.kelvin_kei_prime(nu, x, scaled); break; }
                                case "oflint": { res1 = oflint.kelvin_kei_prime(nu, x, scaled); break; }
                                case "mflint": { res1 = mflint.kelvin_kei_prime(nu, x, scaled); break; }
                                case "aflint": { res1 = aflint.kelvin_kei_prime(nu, x, scaled); break; }
#endif
                            }
                            Console.WriteLine("{0}: " + f(NumType) + "{1}", NumType, res1);
                        }
                    }
                }
                Console.WriteLine();
            }




            #endregion






        }







        public static void RealHypergeometric_0F1()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTests_RealHypergeometric_0F1();
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