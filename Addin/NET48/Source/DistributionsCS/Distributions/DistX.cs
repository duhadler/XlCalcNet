using System;
using ArbPrecNet;
using FixedPrecNet;

namespace Distributions
{

    // 
    public static class DistX
    {



        internal const int mp_cdisx = 1;
        internal const int mp_fdisx = 2;



        public static double AdjustSign(bool UseLeftTail, double x)
        {
            if (UseLeftTail)
                return x;
            else
                return -x;
        }


        public static void BrentDouble(bool UseLeftTail, bool IsExact, bool IsGLM, int proc, ref double a, ref double b, double fa, double fb, double t1, double LogTarget, double Df1, double Df2, double omega)
        {
            double c;
            double d;
            double e;
            double tol;
            double eps;
            double s;
            double p;
            double q;
            double r;
            double xs;
            double fc;
            double m;
            long iter;
            long maxiter;
            double LogRefTail;
            eps = 0.00000000000001d;
            iter = 0L;
            maxiter = 1000L;
            if (fa * fb > 0d)
            {
                Console.WriteLine("f(a) und f(b) need to have different sign");
                return;
            }
            c = a;
            fc = fa;
            d = b - a;
            e = d;
            while (iter < maxiter)
            {
                iter = iter + 1L;
                if (fb * fc > 0d)
                {
                    c = a;
                    fc = fa;
                    d = b - a;
                    e = d;
                }
                if (Math.Abs(fc) < Math.Abs(fb))
                {
                    a = b;
                    b = c;
                    c = a;
                    fa = fb;
                    fb = fc;
                    fc = fa;
                }
                tol = 2d * eps * Math.Abs(b);
                m = (c - b) / 2d;  // Tolerance
                if (Math.Abs(m) > tol & Math.Abs(fb) > 0d)
                {
                    if (Math.Abs(e) < tol | Math.Abs(fa) <= Math.Abs(fb))
                    {
                        d = m;
                        e = m;
                    }
                    else
                    {
                        s = fb / fa;
                        if (a == c)
                        {
                            p = 2d * m * s;
                            q = 1d - s;
                        }
                        else
                        {
                            q = fa / fc;
                            r = fb / fc;
                            p = s * (2d * m * q * (q - r) - (b - a) * (r - 1d));
                            q = (q - 1d) * (r - 1d) * (s - 1d);
                        }
                        if (p > 0d)
                            q = -q;
                        else
                            p = -p;
                        s = e;
                        e = d;
                        if (2d * p < 3d * m * q - Math.Abs(tol * q) & p < Math.Abs(s * q / 2d))
                        {
                            d = p / q;
                        }
                        else
                        {
                            d = m;
                            e = m;
                        }
                    }
                    a = b;
                    fa = fb;
                    if (Math.Abs(d) > tol)
                    {
                        b = b + d;
                    }
                    else if (m > 0d)
                        b = b + tol;
                    else
                        b = b - tol;
                }
                else
                {
                    goto Finish;
                }
                switch (proc)
                {
                    case mp_cdisx:
                        {
                            LogRefTail = DistFromBoost.Arb_ChiSquare_CDF(aflint.t(b), aflint.t(Df1), UseLeftTail, true).AsDouble();
                            break;
                        }
                    case mp_fdisx:
                        {
                            LogRefTail = DistFromBoost.Arb_F_CDF(aflint.t(b), aflint.t(Df1), aflint.t(Df2), UseLeftTail, true).AsDouble();
                            break;
                        }

                    default:
                        {
                            LogRefTail = double.NaN;
                            break;
                        }
                }
                fb = AdjustSign(UseLeftTail, LogTarget - LogRefTail);
                // Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
            }

        Finish:
            ;

            // Console.WriteLine("final: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m))
            xs = b;
        }




        public static double ndisx(double LeftTailTarget, double RightTailTarget)
        {
            double temp;
            if (LeftTailTarget < RightTailTarget)
            {
                temp = ndisx1(LeftTailTarget, RightTailTarget);
            }
            else
            {
                temp = ndisx1(RightTailTarget, LeftTailTarget);
            }
            if (LeftTailTarget > RightTailTarget)
                temp = -temp;
            return temp;
        }



        public static double ndisx1(double LeftTailTarget, double RightTailTarget)
        {
            double split1 = 0.425d;
            double split2 = 5.0d;
            double const1 = 0.180625d;
            double const2 = 1.6d;
            double a0 = 3.38713287279637d;
            double A1 = 133.141667891784d;
            double A2 = 1971.59095030655d;
            double a3 = 13731.6937655095d;
            double a4 = 45921.9539315499d;
            double A5 = 67265.7709270087d;
            double a6 = 33430.5755835881d;
            double A7 = 2509.08092873012d;
            double b1 = 42.3133307016009d;
            double b2 = 687.187007492058d;
            double B3 = 5394.19602142475d;
            double b4 = 21213.7943015866d;
            double B5 = 39307.8958000927d;
            double B6 = 28729.0857357219d;
            double B7 = 5226.49527885285d;
            double C0 = 1.42343711074968d;
            double C1 = 4.63033784615655d;
            double c2 = 5.76949722146069d;
            double c3 = 3.6478483247632d;
            double c4 = 1.27045825245237d;
            double c5 = 0.241780725177451d;
            double c6 = 0.0227238449892692d;
            double C7 = 0.000774545014278341d;
            double d1 = 2.05319162663776d;
            double d2 = 1.6763848301838d;
            double D3 = 0.6897673349851d;
            double D4 = 0.14810397642748d;
            double D5 = 0.0151986665636165d;
            double D6 = 0.000547593808499535d;
            double D7 = 0.00000000105075007164442d;
            double E0 = 6.6579046435011d;
            double e1 = 5.46378491116411d;
            double e2 = 1.78482653991729d;
            double E3 = 0.296560571828505d;
            double E4 = 0.0265321895265761d;
            double E5 = 0.00124266094738808d;
            double E6 = 0.0000271155556874349d;
            double E7 = 0.000000201033439929229d;
            double f1 = 0.599832206555888d;
            double f2 = 0.136929880922736d;
            double f3 = 0.0148753612908506d;
            double f4 = 0.000786869131145613d;
            double f5 = 0.0000184631831751005d;
            double f6 = 0.000000142151175831645d;
            double f7 = 0.00000000000000204426310338994d;

            double ppnd16;
            double r;
            double r0; // or Arb
            double Q = LeftTailTarget - 0.5d;  // calculation done in Arb, result converted back to double
            if (Q < 0d)
                r0 = LeftTailTarget;
            else
                r0 = RightTailTarget;
            if (r0 <= 0d)
                return double.NaN; // {     ifault=1}

            if (Math.Abs(Q) <= split1)
            {
                r = const1 - Q * Q;
                ppnd16 = Q * (((((((A7 * r + a6) * r + A5) * r + a4) * r + a3) * r + A2) * r + A1) * r + a0) / (((((((B7 * r + B6) * r + B5) * r + b4) * r + B3) * r + b2) * r + b1) * r + 1d);
                return ppnd16;
            }
            else
            {
                // Console.WriteLine("in > split1")
                r = Math.Sqrt(-Math.Log(r0));  // calculation done in Arb, result converted back to double
                if (r <= split2)
                {
                    r = r - const2;
                    ppnd16 = (((((((C7 * r + c6) * r + c5) * r + c4) * r + c3) * r + c2) * r + C1) * r + C0) / (((((((D7 * r + D6) * r + D5) * r + D4) * r + D3) * r + d2) * r + d1) * r + 1d);
                }
                else
                {
                    r = r - split2;
                    // Console.WriteLine("in r - split2")
                    ppnd16 = (((((((E7 * r + E6) * r + E5) * r + E4) * r + E3) * r + e2) * r + e1) * r + E0) / (((((((f7 * r + f6) * r + f5) * r + f4) * r + f3) * r + f2) * r + f1) * r + 1d);
                }
                if (Q < 0d)
                    ppnd16 = -ppnd16;
                return ppnd16;
            }
        }







        // Function cdisx_approx(ByVal LeftTail As Double, ByVal RightTail As Double, ByVal n As Double) As Double
        // Dim t As Double, d As Double, k As Double, a As Double, result As Double, UseLambert As Boolean
        // Dim h As Double, L As Double, mean As Double, stdev As Double, u As Double
        // Dim m As Double, m2 As Double, m3 As Double, g As Double, z As Double
        // 'If (n < 1) Then n = 1
        // UseLambert = True
        // a = 1 / (0.5 * (n + 2) - 1)
        // k = LnGamma(0.5 * (n + 2))
        // d = a * (Math.Log(LeftTail) + k)
        // t = -a * Math.Exp(LeftTail + d)
        // If Math.Abs(t) > 0.1 Then UseLambert = False
        // If UseLambert Then
        // result = -(((((125 * t - 64) * t + 36) * t - 24) * t + 24) * t) / (12 * a)  'Result = -2 * LambertW(t) / a
        // Else
        // z = ndisx(LeftTail, RightTail)
        // m = 1 / n : m2 = m * m : m3 = m2 * m
        // mean = (14580 - 1944 * m - 189 * m2 + 200 * m3) / 17496
        // stdev = Math.Sqrt(Math.Abs(648 * m + 72 * m2 - 37 * m3)) / 108
        // g = Math.Sqrt(0.5 * m3) / 162
        // z = z - g + (z * g) * (z - (2 * z * z - 5) * g)
        // L = 6 * (z * stdev + mean)
        // h = dreal.cbrt(2 * (L + Math.Sqrt(13 + L * (L - 5))) - 5)
        // u = 0.5 + 0.5 * h - 1.5 / h
        // u = u * u * u
        // result = n * u * u
        // End If
        // 'Console.WriteLine("chisquare quantile: {0} ", result)
        // Return Math.Abs(result)
        // End Function



        public static double cdisx(double LeftTail, double RightTail, double Df1)
        {
            //double x1;
            // If (LeftTail < 0.5) Then
            // x1 = boost2.dist_chisq(LeftTail, Df1, 6)

            // Else
            // x1 = boost2.dist_chisq(RightTail, Df1, 7)
            // End If
            // Console.WriteLine("x1: {0}", x1)
            return dreal.dist_chi2(Df1).qtf(LeftTail);
        }


        public static double gamma_p_inv_2(double a, double p)
        {
            return cdisx(p, 1d - p, 2d * a) / 2d;
        }


        public static double gamma_q_inv_2(double a, double q)
        {
            return cdisx(1d - q, q, 2d * a) / 2d;
        }





        // Function fdisx_approx_2(ByVal l As Double, ByVal r As Double, ByVal m As Double, ByVal n As Double) As Double
        // Dim z As Double, q As Double, d As Double, u As Double, v As Double, h As Double
        // q = n - 1 + m / 2
        // d = (m * m - 4) / (24 * q * q)
        // z = cdisx_approx(l, r, m)
        // z = z * (1 + d) + z * z * (d / (m + 2))
        // h = -z / q
        // u = Math.Exp(h)
        // v = -dreal.expm1(h)
        // Return (v / u) * (n / m)
        // End Function


        // Function fdisx_approx_1(ByVal l As Double, ByVal r As Double, ByVal m As Double, ByVal n As Double) As Double
        // Dim u As Double, b As Double
        // u = ndisx(l, r)
        // If u < 0 Then b = 0.8 Else b = 0.4
        // If ((m / n) < (1 - b * u / 4.7)) And (u <= n - 1) Then
        // Return fdisx_approx_2(l, r, m, n)
        // Else
        // Return 1 / fdisx_approx_2(r, l, n, m)
        // End If
        // End Function


        // Function fdisx_approx(ByVal L As Double, ByVal r As Double, ByVal m As Double, ByVal n As Double) As Double
        // If m <= n Then
        // Return fdisx_approx_1(L, r, m, n)
        // Else
        // Return 1 / fdisx_approx_1(r, L, n, m)
        // End If
        // End Function







        public static double fdisx(double LeftTail, double RightTail, double Df1, double Df2)
        {
            //double x1;

            // If (LeftTail < 0.5) Then
            // x1 = boost2.dist_fisher_f(LeftTail, Df1, Df2, 6)
            // Else
            // x1 = boost2.dist_fisher_f(RightTail, Df1, Df2, 7)
            // End If
            // Console.WriteLine("x1: {0}", x1)

            return dreal.dist_fisher_f(Df1, Df2).qtf(LeftTail);
        }


        public static void betadisx(double LeftTail, double RightTail, double a, double b, ref double x, ref double y)
        {
            double w = Math.Abs(fdisx(LeftTail, RightTail, 2d * a, 2d * b));
            x = a * w / (a * w + b);
            y = b / (a * w + b);
        }


        public static double ibeta_inv_2(double a, double b, double p)
        {
            double x = 0, y = 0;
            betadisx(p, 1d - p, a, b, ref x, ref y);
            return x;
        }


        public static double ibetac_inv_2(double a, double b, double q)
        {
            double x = 0, y = 0;
            betadisx(1d - q, q, a, b, ref x, ref y);
            return x;
        }



        public static double Tdisx(double LeftTail, double RightTail, double n)
        {
            double t;
            bool Swapped;
            if (LeftTail == 0.5d)
                return 0d;
            Swapped = false;
            if (LeftTail < 0.5d)
            {
                t = LeftTail;
                LeftTail = RightTail;
                RightTail = t;
                Swapped = true;
            }
            RightTail = 2d * RightTail;
            LeftTail = 1d - RightTail;
            t = Math.Sqrt(fdisx(LeftTail, RightTail, 1d, n));
            if (Swapped)
                t = -t;
            return t;
        }





        public static void demoNdisx()
        {
            // Dim LeftTail As Double = 0.001
            double LeftTail = 0.999999d;
            double RightTail = 1d - LeftTail;
            // Dim RightTail As Double = 1.0E-220
            // Dim LeftTail As Double = 1 - RightTail
            double R1 = ndisx(LeftTail, RightTail);
            Console.WriteLine("R1: {0} ", R1);
            Console.WriteLine("");
            // Dim R2 As Double = dreal.dist_qnorm(LeftTail, 0, 1, True, False)
            // Console.WriteLine("R2: {0} ", R2)
            Console.WriteLine("");
        }


        public static void demoCdisx()
        {
            double m = 10.1d;
            // Dim LeftTail As Double = 0.001
            // Dim LeftTail As Double = 0.999999
            // Dim RightTail As Double = 1 - LeftTail
            double RightTail = 1.0E-220d;
            double LeftTail = 1d - RightTail;
            double X0 = cdisx(LeftTail, RightTail, m);
            Console.WriteLine("X0: {0} ", X0);
            // Dim L1 As Double = boost2.dist_chisq(X0, m, 2)
            // Console.WriteLine("L1: {0} ", L1)
            // Dim R1 As Double = boost2.dist_chisq(X0, m, 3)
            // Console.WriteLine("R1: {0} ", R1)
            Console.WriteLine("");
        }


        public static void demoFdisx()
        {
            double m = 1.5d;
            double n = 6d;
            double LeftTail = 0.901d;
            double RightTail = 1d - LeftTail;
            // Dim RightTail As Double = 1.0E-220
            // Dim LeftTail As Double = 1 - RightTail
            double X0 = fdisx(LeftTail, RightTail, m, n);
            Console.WriteLine("X0: {0} ", X0);
            // Dim L1 As Double = boost2.dist_fisher_f(X0, m, n, 2)
            // Console.WriteLine("L1: {0} ", L1)
            // Dim R1 As Double = boost2.dist_fisher_f(X0, m, n, 3)
            // Console.WriteLine("R1: {0} ", R1)

        }


        public static void demoTdisx()
        {
            double m = 10.1d;
            // Dim LeftTail As Double = 0.001
            double LeftTail = 0.999999d;
            double RightTail = 1d - LeftTail;
            // Dim RightTail As Double = 1.0E-220
            // Dim LeftTail As Double = 1 - RightTail
            double R1 = Tdisx(LeftTail, RightTail, m);
            Console.WriteLine("R1: {0} ", R1);
            Console.WriteLine("");
            // Dim R2 As Double = dreal.dist_qt(LeftTail, m, True, False)
            // Console.WriteLine("R2: {0} ", R2)
            Console.WriteLine("");
        }


        public static void demoBetadisx()
        {
            double a = 1.5d;
            double b = 6d;
            double LeftTail = 0.01d;
            double RightTail = 1d - LeftTail;
            double x = 0, y = 0;
            betadisx(LeftTail, RightTail, a, b, ref x, ref y);
            Console.WriteLine("x: {0}, y: {0} ", x, y);

            Console.WriteLine("");
            // Dim x1 = dreal.dist_qbeta(LeftTail, a, b, True, False)
            // Dim y1 = dreal.dist_qbeta(RightTail, a, b, False, False)
            // Console.WriteLine("x: {0}, y: {0} ", x1, y1)

        }


        public static void demo_ibeta_inv()
        {
            double a = 1.5d;
            double b = 6d;
            double p = 0.99d;
            double R0 = dreal.real_ibeta_inv(a, b, p);
            Console.WriteLine("R0: {0}", R0);

            double R1 = ibeta_inv_2(a, b, p);
            Console.WriteLine("R1: {0}", R1);
        }


        public static void demo_ibetac_inv()
        {
            double a = 1.5d;
            double b = 6d;
            double q = 0.99d;
            double R0 = dreal.real_ibetac_inv(a, b, q);
            Console.WriteLine("R0: {0}", R0);

            double R1 = ibetac_inv_2(a, b, q);
            Console.WriteLine("R1: {0}", R1);
        }


        public static void demoGamma_p_inv()
        {
            int a = 2;
            double p = 0.99d;
            double R0 = dreal.real_gamma_p_inv(a, p);
            Console.WriteLine("R0: {0}", R0);

            double R1 = gamma_p_inv_2(a, p);
            Console.WriteLine("R1: {0}", R1);
        }


        public static void demoGamma_q_inv()
        {
            int a = 2;
            double q = 0.99d;
            double R0 = dreal.real_gamma_q_inv(a, q);
            Console.WriteLine("R0: {0}", R0);

            double R1 = gamma_q_inv_2(a, q);
            Console.WriteLine("R1: {0}", R1);
        }



    }
}