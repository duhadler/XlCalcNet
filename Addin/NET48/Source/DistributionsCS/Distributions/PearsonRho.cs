using System;
using ArbPrecNet;

namespace Distributions
{


    static class DemoPearsonDouble
    {





        // **********************************************************************
        // Pearson's rho cdf
        // '**********************************************************************

        #region PearsonRho

        // Algorithm by Hotelling, 1953
        public static void RhoDisN2_2(double n, double r, double rho, ref double LeftTail, ref double RightTail)
        {
            double a; // , LeftTail2 As Double
            double gf;
            double A1;
            double sum3;
            double summand;
            double RelError2;
            int m;
            int k;
            int smax;
            int j;
            int S;
            double RelError;
            double Q;
            double BK;
            double sign;
            double t2;
            double X;
            double y;
            double sum;
            double sum2;
            double Factor;
            double TWO;
            var fs = new double[2];
            var Betas = new double[2];
            var Dens = new double[2];
            double[] IBeta;
            double[] nk;
            bool Swapped;
            int slimit;
            int mlimit;
            slimit = 100;
            mlimit = 10;

            IBeta = new double[slimit + 1];
            nk = new double[mlimit + 1];
            Swapped = false;
            if (rho > r)
            {
                r = -r;
                rho = -rho;
                Swapped = true;
            }
            n = n - 1d;
            smax = -1;
            Q = (n - 1d) * 0.398942280401433d;
            Q = Q * Math.Exp(DistMain.LnGamma(n) - DistMain.LnGamma(n + 0.5d));
            X = (r - rho) / (1d - rho * r);
            X = X * X;
            y = 1d - X;
            Factor = 1d;
            A1 = 1d - rho * rho;
            a = 1d;
            TWO = 1d;
            RelError = 1d;
            m = 0;
            sum3 = 0d;
            sum = 0d;
            while (Math.Abs(RelError) > 0.0000000001d)
            {
                S = 0;
                gf = 1d;
                RelError2 = 1d;
                while (Math.Abs(RelError2) > 0.0000000001d)
                {
                    if (S > smax)
                    {
                        smax = S;
                        if (smax > slimit)
                        {
                            slimit = 2 * slimit;
                            Array.Resize(ref IBeta, slimit + 1);
                        }
                        if (S % 2 != 0)
                            j = 1;
                        else
                            j = 0;
                        if (S <= 1)
                        {
                            DistMain.betadis((S + 1) / 2d, (n - 1d) / 2d, X, y, ref LeftTail, ref Betas[j], ref Dens[j]);
                            fs[j] = Math.Exp(DistMain.Lnbeta((S + 1) / 2d, (n - 1d) / 2d));
                            Dens[j] = 2d * y * Dens[j];
                        }
                        else
                        {
                            fs[j] = fs[j] * (S - 1) / (n + S - 2d);
                            Dens[j] = Dens[j] * X / (S - 1);
                            Betas[j] = Betas[j] + Dens[j];
                            Dens[j] = Dens[j] * (n + S - 2d);
                        }
                        IBeta[S] = Betas[j] * fs[j];
                    }
                    if (S == 0)
                    {
                        sum3 = IBeta[0];
                    }
                    else
                    {
                        gf = gf * rho * (1.5d - m - S) / S;
                        summand = gf * IBeta[S];
                        sum3 = sum3 + summand;
                        if (sum3 != 0d)
                            RelError2 = summand / sum3;
                    }
                    S = S + 1;
                }
                nk[m] = a * sum3 / 2d;
                a = a * A1;
                if (m == 0)
                {
                    sum = nk[0];
                }
                else
                {
                    TWO = TWO * 2d;
                    Factor = Factor * (2.0d * m - 1d) * (2.0d * m - 1d) / (m * 4 * (2d * n + 2 * m - 1d));
                    sum2 = TWO * nk[0];
                    t2 = TWO;
                    sign = -1;
                    BK = 1d;
                    var loopTo = m;
                    for (k = 1; k <= loopTo; k++)
                    {
                        BK = BK * (m - k + 1) / k;
                        t2 = t2 / 2d;
                        sum2 = sum2 + sign * BK * t2 * nk[k];
                        sign = -sign;
                    }
                    sum2 = Factor * sum2;
                    sum = sum + sum2;
                    RelError = sum2 / sum;
                }
                m = m + 1;
                if (m > mlimit)
                {
                    mlimit = 2 * mlimit;
                    Array.Resize(ref nk, mlimit + 1);
                }
            }
            // Debug.Print "smax,m", smax, m, slimit, mlimit
            RightTail = Q * sum;
            LeftTail = 1d - RightTail;
            if (Swapped)
            {
                sum = RightTail;
                RightTail = LeftTail;
                LeftTail = sum;
            }
            IBeta = null;
            nk = null;
            // Debug.Print "slimit: ", slimit, "mlimit:", mlimit
        }



        public static void RhoDisN1_2(int n, double r, double rho, double LeftTail, double RightTail)
        {
            double delta;
            double t;
            double result;
            t = r * Math.Sqrt((n - 2) / (1d - r * r));
            delta = rho * Math.Sqrt((n - 2) / (1d - rho * rho));
            // result = tdisn(n - 2, t, delta, LeftTail, RightTail)
            result = DistN.TdisnOwen(n - 2, t, delta, ref LeftTail, ref RightTail);

        }





        public static double CornishFisher4_kappa_2(double z, double k1, double k2, double k3, double k4)
        {
            double U;
            double u2;
            double u3;
            double X;
            double g1;
            double g2;
            g1 = k3 / (Math.Sqrt(k2) * k2);
            g2 = k4 / (k2 * k2);
            U = (z - k1) / Math.Sqrt(k2);
            u2 = U * U;
            u3 = U * u2;
            X = U - (u2 - 1d) * g1 / 6d - (u3 - 3d * U) * g2 / 24d + (4d * u3 - 7d * U) * g1 * g1 / 36d;
            return DistMain.ndis(X);
        }


        public static double CornishFisher4_kappa_X_2(double LeftTail, double RightTail, double k1, double k2, double k3, double k4)
        {
            double U;
            double u2;
            double u3;
            double X;
            double g1;
            double g2;
            g1 = k3 / (Math.Sqrt(k2) * k2);
            g2 = k4 / (k2 * k2);
            U = DistX.ndisx(LeftTail, RightTail);
            u2 = U * U;
            u3 = U * u2;
            X = U + (u2 - 1d) * g1 / 6d + (u3 - 3d * U) * g2 / 24d + (2d * u3 - 5d * U) * g1 * g1 / 36d;
            return k1 + Math.Sqrt(k2) * X;
        }


        public static double Fisher_kappa_X_2(double LeftTail, double RightTail, double n, double rho)
        {
            double Rho2;
            double rho3;
            double rho4;
            double N1;
            double N2;
            double n3;
            double k1;
            double k2;
            double k3;
            double k4;
            double y; // , e As Double
                      // Note: n = sample size
            N1 = n - 1d;
            N2 = N1 * N1;
            n3 = N2 * N1;
            Rho2 = rho * rho;
            rho3 = Rho2 * rho;
            rho4 = Rho2 * Rho2;
            k1 = 0.5d * Math.Log((1d + rho) / (1d - rho)) + rho * (1d + (5d + Rho2) / (4d * N1) + (11d + 2d * Rho2 + 3d * rho4) / (8d * N2)) / (2d * N1);
            k2 = (1d + (4d - Rho2) / (2d * N1) + (22d - 6d * Rho2 - 3d * rho4) / (6d * N2)) / N1;
            k3 = rho3 / n3;
            k4 = 2d / n3;
            y = CornishFisher4_kappa_X_2(LeftTail, RightTail, k1, k2, k3, k4);
            return DistN.zTransformInverse(y);
        }


        public static double zTransformInverse_2(double y)
        {
            y = Math.Exp(2d * y);
            return (y - 1d) / (y + 1d);
        }


        public static double zTransform_2(double r)
        {
            return 0.5d * Math.Log((1d + r) / (1d - r));
        }


        public static double Fisher_simple_2(double r, double n, double rho)
        {
            double X;
            double Result;
            X = (zTransform_2(r) - zTransform_2(rho)) * Math.Sqrt(n - 3d);
            Result = DistMain.ndis(X);
            return Result;
        }



        public static double Fisher_simple_X_2(double LeftTail, double RightTail, double n, double rho)
        {
            double k1;
            double U;
            double y; // , e As Double
            U = DistX.ndisx(LeftTail, RightTail);
            k1 = zTransform_2(rho);
            // k1 = 0.5 * Log((1 + rho) / (1 - rho))
            y = U / Math.Sqrt(n - 3d) + k1;
            return zTransformInverse_2(y);
        }

        public static double Fisher_kappa_2(double r, double n, double rho)
        {
            double Rho2;
            double rho3;
            double rho4;
            double N1;
            double N2;
            double n3;
            double z;
            double k1;
            double k2;
            double k3;
            double k4;
            // Note: n = sample size
            N1 = n - 1d;
            N2 = N1 * N1;
            n3 = N2 * N1;
            Rho2 = rho * rho;
            rho3 = Rho2 * rho;
            rho4 = Rho2 * Rho2;
            z = 0.5d * Math.Log((1d + r) / (1d - r));
            k1 = 0.5d * Math.Log((1d + rho) / (1d - rho)) + rho * (1d + (5d + Rho2) / (4d * N1) + (11d + 2d * Rho2 + 3d * rho4) / (8d * N2)) / (2d * N1);
            k2 = (1d + (4d - Rho2) / (2d * N1) + (22d - 6d * Rho2 - 3d * rho4) / (6d * N2)) / N1;
            k3 = rho3 / n3;
            k4 = 2d / n3;
            return CornishFisher4_kappa2_2(z, k1, k2, k3, k4, 0d);
        }


        public static double CornishFisher4_kappa2_2(double z, double k1, double k2, double k3, double k4, double k6)
        {
            double U;
            double u2;
            double u3;
            double u4;
            double u5;
            double X;
            double g1;
            double g2;
            double g4;
            g1 = k3 / (Math.Sqrt(k2) * k2);
            g2 = k4 / (k2 * k2);
            g4 = k6 / (k2 * k2 * k2);
            U = (z - k1) / Math.Sqrt(k2);
            u2 = U * U;
            u3 = U * u2;
            u5 = u3 * u2;
            u4 = u2 * u2;
            X = U - (u2 - 1d) * g1 / 6d - (u3 - 3d * U) * g2 / 24d + (4d * u3 - 7d * U) * g1 * g1 / 36d;
            X = X + (11d * u4 - 42d * u2 + 15d) * g1 * g2 / 144d;
            X = X - (u5 - 10d * u3 + 15d * U) * g4 / 720d;
            return DistMain.ndis(X);
        }


        public static double Fisher_kappa2_2(double r, double n, double rho)
        {
            double Rho2;
            double rho3;
            double rho4;
            double N1;
            double N2;
            double n3;
            double z;
            double k1;
            double k2;
            double k3;
            double k4;
            double k6;
            // Note: n = sample size
            N1 = n - 1d;
            N2 = N1 * N1;
            n3 = N2 * N1;
            Rho2 = rho * rho;
            rho3 = Rho2 * rho;
            rho4 = Rho2 * Rho2;
            z = 0.5d * Math.Log((1d + r) / (1d - r)) - 0.5d * Math.Log((1d + rho) / (1d - rho));
            k1 = rho * (1d + (5d + Rho2) / (4d * N1) + (11d + 2d * Rho2 + 3d * rho4) / (8d * N2)) / (2d * N1);
            k2 = (1d + (4d - Rho2) / (2d * N1) + (22d - 6d * Rho2 - 3d * rho4) / (6d * N2)) / N1;
            k3 = rho3 / n3;
            k4 = 2d / n3 + 3d * (4d - rho4) / (N2 * N2);
            k6 = 24d / (n3 * N2);
            k6 = 0d;
            return CornishFisher4_kappa2_2(z, k1, k2, k3, k4, k6);
        }





        public static void DemoRhoExplicit_2()
        {
            int n;
            double r;
            double rho;
            double result;
            var LeftTail = default(double);
            double density;
            // Smallest N: N = 3
            n = 6;
            r = 0.1d;
            rho = 0.99d;
            result = DistN.RhoExplicit(n, r, rho);
            // Call RhoDisN2(n, r, rho, LeftTail, RightTail)
            // Debug.Print LeftTail, RightTail
            Console.WriteLine("result: {0}, result / LeftTail: {1}", result, result / LeftTail);
            density = DistN.RhoDensity(n, r, rho);
            Console.WriteLine("density: {0}", density);
        }


        public static double RhoDensity_2(long n, double r, double rho)
        {
            double w;
            double t;
            double X;
            double x2;
            double r2;
            double Rho2;
            double U;
            double k1;
            double A2;
            double a;
            double c2;
            double C;
            double b2;
            double b;
            double ACTerm;
            double density;

            const double Pi = 3.14159265358979d;
            r2 = r * r;
            Rho2 = rho * rho;
            X = r * rho;
            x2 = X * X;
            w = 0.5d * (1d + X);
            A2 = 1d - Rho2;
            a = Math.Sqrt(A2);
            c2 = 1d - r2;
            C = Math.Sqrt(c2);
            b2 = 1d - x2;
            b = Math.Sqrt(b2);
            U = Math.Acos(-X) / b;

            t = DistN.t1(n, w);
            k1 = (n - 2L) / Math.Sqrt(2d * Pi) * Math.Exp(DistMain.LnGamma(n - 1L) - DistMain.LnGamma(n - 0.5d));
            ACTerm = Math.Exp(Math.Log(a) * (n - 1L) + Math.Log(C) * (n - 4L) + Math.Log(1d - X) * (1.5d - n));
            density = k1 * ACTerm * t;
            return density;

        }


        // Hypergeometric function for density of pearson's rho
        public static double t1_2(double n, double w)
        {
            int i;
            double A1;
            double C1;
            double m1;
            double sum;
            double RelErr;
            A1 = 0.5d;
            C1 = n - 0.5d;
            m1 = 0.25d * w / C1;
            sum = 1d + m1;
            i = 1;
            do
            {
                i = i + 1;
                A1 = A1 + 1d;
                C1 = C1 + 1d;
                m1 = m1 * A1 * A1 * w / (C1 * i);
                sum = sum + m1;
                RelErr = m1 / sum;
            }
            // Debug.Print i, sum, M1, M1 / sum
            while (RelErr >= 0.0000000000000001d);
            return sum;
        }



        public static double RhoExplicit_2(int n, double r, double rho)
        {
            double[] F;
            double[] d;
            double sum1;
            double sum2;
            double sum3;
            double sum31;
            double sum32;
            double X;
            double x2;
            double r2;
            double Rho2;
            double U;
            double A2;
            double a;
            double c2;
            double C;
            double b2;
            double b;
            double d1;
            double f6;
            double f6u;
            double result;
            int k;
            int k1;
            int k4;
            const double Pi = 3.14159265358979d;
            r2 = r * r;
            Rho2 = rho * rho;
            X = r * rho;
            x2 = X * X;
            A2 = 1d - Rho2;
            a = Math.Sqrt(A2);
            c2 = 1d - r2;
            C = Math.Sqrt(c2);
            b2 = 1d - x2;
            b = Math.Sqrt(b2);
            U = Math.Acos(-X) / b;
            F = new double[n + 1];
            d = new double[n + 1];

            if (n % 2 != 0)
            {
                k1 = 2;
                d1 = Math.Acos(-r) / Pi;
                result = d1 - rho * C * U / Pi;
                if (n == 3)
                {
                    return result;
                    //return default;
                }
                else
                {
                }

                F[1 + k1] = result;
                result = d1 + ((x2 + 2d - 3d * Rho2) * r * C * A2 + (Rho2 - 3d + 2d * Rho2 * x2) * rho * c2 * C * U) / (2d * Pi * b2 * b2);
                if (n == 5)
                {
                    return result;
                    //return default;
                }
                else
                {
                }

                F[3 + k1] = result;
            }
            else
            {
                k1 = 3;
                d1 = Math.Acos(rho) / Pi;
                result = d1 + (-rho * a * c2 + r * A2 * a * U) / (Pi * b2);
                if (n == 4)
                {
                    return result;
                    //return default;
                }
                else
                {
                }

                F[1 + k1] = result;
                f6 = (X * r * (2d * x2 + 13d) - 2d * rho * (4d * x2 * x2 + 6d * x2 + 5d) + Rho2 * rho * (11d * x2 + 4d)) * a * c2;
                f6u = (-r2 + 3d + 2d * x2 * (-2 * r2 + 1d)) * r * A2 * A2 * a * U;
                result = d1 + (f6 + 3d * f6u) / (6d * Pi * b2 * b2 * b2);
                if (n == 6)
                {
                    return result;
                    //return default;
                }
                else
                {
                }

                F[3 + k1] = result;
            }

            d[3] = A2 * (1d + X * U) / (Pi * b2 * C);
            d[4] = A2 * a * (b2 * U + 3d * X * (1d + X * U)) / (b2 * b2 * Pi);

            // This is calculating the density
            var loopTo = n;
            for (k = 5; k <= loopTo; k++)
                d[k] = (a * C * X * d[k - 1] * (2 * k - 5) / (k - 3) + A2 * c2 * d[k - 2] * (k - 3) / (k - 4)) / b2;

            // This is calculating the CDF
            var loopTo1 = n;
            for (k = k1 + 5; k <= loopTo1; k += 2)
            {
                k4 = k - 4;
                sum1 = (2 * k4 * Rho2 - k + 5d) * F[k - 2];
                sum2 = (k - 5) * A2 * F[k4];
                sum31 = rho * (k4 * a * C - (2 * k - 9) * b2 / (a * C)) * d[k - 1] / k4;
                k4 = k4 * k4;
                sum32 = r * (k4 + (3 * k * (k - 8) + 47) * Rho2) * d[k - 2] / k4;
                sum3 = sum31 + sum32;
                F[k] = (sum1 + sum2 + sum3) / ((k - 3) * Rho2);
                // Debug.Print k, F(k + 5), sum1, sum2, sum31, sum32, (sum31 + sum32) / sum31
            }


            return F[n];
        }



        // Algorithm by Guenther
        public static void RhoDisN5_2(double n, double r, double rho, double LeftTail, double RightTail)
        {
            const double Pi = 3.14159265358979d;
            double sign;
            double r2;
            double Rho2;
            var Left1 = default(double);
            var Right1 = default(double);
            double RelError;
            double summand;
            double sum0;
            double sum1;
            double sum2;
            double k1;
            double k2;
            var density = default(double);
            long j;
            double sum4;
            double sum3;
            double RelError3;
            Rho2 = rho * rho;
            r2 = r * r;
            if (rho < 0d)
                sign = -1;
            else
            {
                if (rho > 0d)
                    sign = 1d;
                else
                    sign = 0d;
            }
            DistMain.betadis(1d / 2d, (n - 1d) / 2d, Rho2, 1d - Rho2, ref Left1, ref Right1, ref density);
            sum0 = 0.5d * (1d + sign * Left1);
            if (r == 0d)
            {
                RightTail = sum0;
                LeftTail = 1d - RightTail;
                return;
            }
            k1 = 0.5d * Math.Exp(Math.Log(1d - Rho2) * (n - 1d) / 2d);
            DistMain.betadis(1d / 2d, (n - 2d) / 2d, r2, 1d - r2, ref Left1, ref Right1, ref density);
            sum1 = k1 * Left1;
            sum3 = k1 * Right1;
            j = 0L;
            RelError = 1d;
            RelError3 = 1d;
            while (RelError > 0.00000000000001d)
            {
                j = j + 1L;
                k1 = (2L * j + n - 3d) / (2L * j) * Rho2 * k1;
                DistMain.betadis((2L * j + 1L) / 2d, (n - 2d) / 2d, r2, 1d - r2, ref Left1, ref Right1, ref density);
                summand = k1 * Left1;
                sum1 = sum1 + summand;
                RelError = summand / sum1;
                summand = k1 * Right1;
                sum3 = sum3 + summand;
                if (sum3 != 0d)
                    RelError3 = summand / sum3;
                // Debug.Print j, sum1, RelError, Left1
                // Debug.Print j, sum3, RelError3, Right1
            }
            // Debug.Print "Gunther j1:", j
            if (rho == 0d)
            {
                sum2 = 0d;
                sum4 = 0d;
            }
            else
            {
                k2 = rho / Math.Sqrt(Pi) * Math.Exp(DistMain.LnGamma(n / 2d) - DistMain.LnGamma((n - 1d) / 2d) + Math.Log(1d - Rho2) * (n - 1d) / 2d);
                DistMain.betadis(1d, (n - 2d) / 2d, r2, 1d - r2, ref Left1, ref Right1, ref density);
                sum2 = k2 * Left1;
                sum4 = k2 * Right1;
                j = 0L;
                RelError = 1d;
                RelError3 = 1d;
                while (RelError > 0.00000000000001d)
                {
                    j = j + 1L;
                    k2 = (2L * j + n - 2d) / (2L * j + 1L) * Rho2 * k2;
                    DistMain.betadis(j + 1L, (n - 2d) / 2d, r2, 1d - r2, ref Left1, ref Right1, ref density);
                    summand = k2 * Left1;
                    sum2 = sum2 + summand;
                    if (sum2 != 0d)
                        RelError = summand / sum2;
                    summand = k2 * Right1;
                    sum4 = sum4 + summand;
                    if (sum4 != 0d)
                        RelError3 = summand / sum4;
                    // Debug.Print j, sum2, RelError, Left1
                    // Debug.Print j, sum4, RelError3, Right1
                }
                // Debug.Print "j2:"; j
            }
            // Debug.Print "sum0:", 1 - sum0, sum0
            // Debug.Print "sum1:", sum1, sum2, sum1 + sum2
            // Debug.Print "sum3:", sum3, sum4, sum3 + sum4
            // Debug.Print "sum5:", , sum1 + sum3, sum2 + sum4
            RightTail = sum0 - (sum1 + sum2);
            LeftTail = 1d - sum0 + (sum1 + sum2);
        }



        public static void demoRho_Guenther_2()
        {
            //double result;
            int n;
            double rho;
            double r; // , X As Double, y As Double
            double LeftTail;
            double RightTail; // , l2 As Double, r2 As Double
            n = 7;
            r = 0.236d;
            rho = 0.9d;
            RightTail = 0.05d;
            LeftTail = 1d - RightTail;
            // r = RhoDisX0(LeftTail, RightTail, n)
            Console.WriteLine("r: {0}", r);
            DistN.RhoDisN_Guenther(n, r, rho, ref LeftTail, ref RightTail);
            Console.WriteLine("Guenther: {0}, {1} ", LeftTail, RightTail);
            // Debug.Print ndisx(LeftTail, RightTail)
            // LeftTail = tdisn(N - 2, R * Sqr((N - 2) / (1 - R * R)), 0, L2, R2)
            // RightTail = 1 - LeftTail
            // Debug.Print LeftTail, RightTail
            // Call RhoDisN2(n, r, rho, LeftTail, RightTail)
            // Debug.Print "Hotelling: ", LeftTail, RightTail
            LeftTail = DistN.RhoExplicit(n, r, rho);
            Console.WriteLine("RhoExplicit: {0}, {1} ", LeftTail, 1d - LeftTail);

            // result = Rhodis_B(r, n, rho)
            // Debug.Print "Fisherb:  ", result
            // result = Rhodis_B_2(r, n, rho)
            // Debug.Print "Fisherb2:  ", result
            // 
            // result = Fisher_kappa(r, n, rho)
            // Console.WriteLine("Fisherk: {0} ", result)
            // result = Fisher_kappa2(r, n, rho)
            // Console.WriteLine("Fisherk2: {0} ", result)

        }


        #endregion


        // Confidence interval upper limit
        public static void demordisn_nc_2()
        {
            double LeftTail;
            double RightTail;
            double n; // , d As Double, t As Double, p As Double, t2 As Double, p2 As Double
            double z;
            double RefTail; // , CDF As Double, PDF As Double, i As Long, RelErr As Double
            double rho_alpha;
            double rho;
            double rTail; // , d_rho  As Double, t_delta As Double
            LeftTail = 0.99d;
            RightTail = 1d - LeftTail;
            if (LeftTail < 0.5d)
                RefTail = LeftTail;
            else
                RefTail = RightTail;
            z = DistX.ndisx(LeftTail, RightTail);
            n = 14d;
            rho = 0.6d;

            // Debug.Print "****************************************************************"

            rho_alpha = Rhodis_NC_2(n, rho, LeftTail, RightTail);
            Console.WriteLine("rho_alpha W: {0}, {1}, {2}, {3}", rho_alpha, 1d - rho_alpha, LeftTail, RightTail);

            rTail = RhoDis_W_2(rho, n, rho_alpha);
            Console.WriteLine("rTail: {0}", rTail);


        }





        // These approximations are sensitive to whether rho and or r are negative. Still need to figure out the details!!!

        // Algorithm by Winterbottom, 1980
        public static double RhoDis_W_2(double r, double n, double rho)
        {
            double y;
            double m;
            double w;
            double r2;
            double r3;
            double r4;
            double m2;
            double w2;
            double w3;
            double w5;
            r2 = r * r;
            r3 = r2 * r;
            r4 = r2 * r2;
            m = n - 1d;
            m2 = m * m;
            w = DistN.zTransform(r) - DistN.zTransform(rho);
            w2 = w * w;
            w3 = w2 * w;
            w5 = w2 * w3;
            y = -r / (2d * m) - (3d * r + r3) / (12d * m2);
            y = y + (1d - (1d + r2) / (4d * m) + (3d - 11d * r4) / (96d * m2)) * w;
            y = y + (3d * r - 4d * r3) / (24d * m) * w2;
            y = y - (1d / 12d - (2d + 7d * r2 - 6d * r4) / (48d * m)) * w3;
            y = y + 3d / 160d * w5;
            return DistMain.ndis(Math.Sqrt(m) * y);
        }



        // Algorithm by Winterbottom, 1980
        public static double Rhodisx_W_2(double LeftTail, double RightTail, double n, double rho)
        {
            double y;
            double X;
            double m;
            double m2;
            double m12;
            double m32;
            double m52;
            double Rho2;
            double rho3;
            double rho4;
            double z;
            double x2;
            double x3;
            double x4;
            double x5;
            X = DistX.ndisx(LeftTail, RightTail);
            z = zTransform_2(rho);
            // z = 0.5 * Log((1 + rho) / (1 - rho))
            m = n - 1d;
            m2 = m * m;
            m12 = Math.Sqrt(m);
            m32 = m * m12;
            m52 = m2 * m12;
            x2 = X * X;
            x3 = x2 * X;
            x4 = x3 * X;
            x5 = x4 * X;
            Rho2 = rho * rho;
            rho3 = Rho2 * rho;
            rho4 = rho3 * rho;
            y = z + X / m12 + rho / (2d * m);
            y = y + (x3 + 3d * (3d - Rho2) * X) / (12d * m32);
            y = y + (4d * rho3 * x2 - rho3 + 15d * rho) / (24d * m2);
            y = y + (x5 + (-60 * rho4 + 30d * Rho2 + 80d) * x3 + (45d * rho4 - 21d * Rho2 + 375d) * X) / (480d * m52);
            return zTransformInverse_2(y);
            // Rhodisx_W = (Exp(2 * y) - 1) / (Exp(2 * y) + 1)
        }



        // Algorithm by Winterbottom, 1980
        // Confidence interval upper limit
        public static double Rhodis_NC_2(double n, double r, double LeftTail, double RightTail)
        {
            double y;
            double X;
            double m;
            double m2;
            double m12;
            double m32;
            double m52;
            double r2;
            double r3;
            double r4;
            double z;
            double x2;
            double x3;
            double x4;
            double x5;
            X = DistX.ndisx(LeftTail, RightTail);
            z = zTransform_2(r);
            // z = 0.5 * Log((1 + r) / (1 - r))
            m = n - 1d;
            m2 = m * m;
            m12 = Math.Sqrt(m);
            m32 = m * m12;
            m52 = m2 * m12;
            x2 = X * X;
            x3 = x2 * X;
            x4 = x3 * X;
            x5 = x4 * X;
            r2 = r * r;
            r3 = r2 * r;
            r4 = r3 * r;
            y = z + X / m12 - r / (2d * m);
            y = y + (x3 + 3d * (1d + r2) * X) / (12d * m32);
            y = y - (4d * r3 * x2 + 5d * r3 + 9d * r) / (24d * m2);
            y = y + (x5 + (60d * r4 - 30d * r2 + 20d) * x3 + (165d * r4 + 30d * r2 + 15d) * X) / (480d * m52);
            return zTransformInverse_2(y);
            // Rhodis_NC = (Exp(2 * y) - 1) / (Exp(2 * y) + 1)
        }



        public static double Rhodis_B(double n, double r, double rho)
        {
            double m2;
            double m1;
            double m3;
            double m4;
            double m5;
            double r2;
            double r3;
            double r4;
            double F;
            double a;
            double b;
            double C;
            double d;
            double X;
            double p;
            double k;
            m2 = 1d / (n - 1d);
            m1 = Math.Sqrt(m2);
            m3 = m2 * m1;
            m4 = m2 * m2;
            m5 = m2 * m3;
            r2 = r * r;
            r3 = r2 * r;
            r4 = r3 * r;
            F = 1.2d;

            a = m3 / 12d + (6d * r4 - 3d * r2 + 2d * F) * m5 / 48d;
            b = -r3 * m4 / 6d;
            C = m1 + (1d + r2) * m3 / 4d + (11d * r4 + 2d * r2 + 1d) * m5 / 32d;
            d = r * m2 / 2d + (5d * r3 + 9d * r) * m4 / 24d;
            d = 0.5d * Math.Log((1d + rho) / (1d - rho)) - 0.5d * Math.Log((1d + r) / (1d - r)) + d;

            b = b / a;
            C = C / a;
            d = d / a;
            d = d + b * C / 3d - 2d * b * b * b / 27d;
            C = C - b * b / 3d;
            p = Math.Sqrt(Math.Abs(12d * C * C * C + 81d * d * d)); // revise if negative
            k = Math.Pow(108d * d + 12d * p, 1d / 3d);
            X = k / 6d - 2d * C / k - b / 3d;
            return DistMain.ndis(-X);
        }


        public static void DemoFisher_kappa_X_2()
        {
            double LeftTail;
            double RightTail;
            double r;
            int n;
            double rho;
            //double result;
            double lefttail1; // , RightTail1 As Double
            ArbPrec.SetDps(40);

            // An example, where E fails in double precision, producing a negative value
            // n = 44
            // rho = 0.9999999714
            // LeftTail = 5E-10
            // RightTail = 1 - LeftTail

            // An example, where F fails in double precision, producing a 1E+20 relative error
            // n = 14
            // rho = 0.9999999714
            // LeftTail = 5E-20
            // RightTail = 1 - LeftTail

            n = 28;
            rho = 0.99d;
            LeftTail = 0.0005d;
            RightTail = 1d - LeftTail;


            // Console.WriteLine( "----------------------")
            // r = Fisher_simple_X_2(LeftTail, RightTail, n, rho)
            // Console.WriteLine( "r_alpha: {0}, {1}", r, 1 - r)
            // result = Fisher_simple_2(r, n, rho)
            // Console.WriteLine("LeftTail S: {0} ", result)
            // 
            // lefttail1 = RhoExplicit_2(n, r, rho)
            // Console.WriteLine("LeftTail E: {0}", lefttail1)
            // 
            // 
            // Console.WriteLine( "----------------------")
            // r = Fisher_kappa_X_2(LeftTail, RightTail, n, rho)
            // Console.WriteLine( "r_alpha: {0}, {1}", r, 1 - r)
            // result = Fisher_kappa_2(r, n, rho)
            // Console.WriteLine("LeftTail F: {0}", result)
            // 
            // lefttail1 = RhoExplicit_2(n, r, rho)
            // Console.WriteLine("LeftTail E: {0}", lefttail1)


            Console.WriteLine("----------------------");
            r = Rhodisx_W_2(LeftTail, RightTail, n, rho);
            Console.WriteLine("r_alpha B: {0}, {1}", r, 1d - r);
            lefttail1 = Rhodis_B(n, r, rho);
            Console.WriteLine("LeftTail B: {0}", lefttail1);

            double r2 = Rhodisx_W_2(lefttail1, 1d - lefttail1, n, rho);
            double lefttail2 = Rhodis_B(n, r2, rho);
            Console.WriteLine("LeftTail2B: {0}", lefttail2);
            double p1, p2;
            p1 = Math.Log(lefttail1) + Math.Log(lefttail2);
            p2 = Math.Exp(p1 / 2d);
            Console.WriteLine("LeftTail2C: {0}", p2);


            lefttail1 = RhoExplicit_2(n, r, rho);
            Console.WriteLine("LeftTail E: {0}", lefttail1);


            var LeftMpfr = new Mpfr();
            LeftMpfr = DemoPearsonMpfr.RhoExplicit_Mpfr(n, mreal.t(r), mreal.t(rho));
            Console.WriteLine("LeftTail M: {0}", LeftMpfr);



            var LeftArb = new Arb();
            LeftArb = DemoPearsonArb.RhoExplicit_Arb(n, aflint.t(r), aflint.t(rho));
            Console.WriteLine("LeftTailA: {0}", LeftArb);

            // Dim rs As String = r.ToString()
            // Dim rhos As String = rho.ToString()



            // LeftMpfr = RhoExplicit_Mpfr(n, rs, rhos)
            // Console.WriteLine("LeftTail M: {0}", LeftMpfr)




            // LeftArb = RhoExplicit_Arb(n, rs, rhos)
            // Console.WriteLine("LeftTailA: {0}", LeftArb)

            // result = Fisher_simple_2(r, n, rho)
            // Console.WriteLine("LeftTail S: {0} ", result)

            // result = Fisher_kappa_2(r, n, rho)
            // Console.WriteLine("LeftTail F: {0}", result)

        }



        public static void DemoPearsonDoubleProcs()
        {
            Console.WriteLine("In Pearson");
            DemoFisher_kappa_X_2();
            // demordisn_nc_2()

        }



    }





    static class DemoPearsonMpfr
    {




        public static Mpfr RhoExplicit_Mpfr(int n, Mpfr r, Mpfr rho)
        {
            var F = new MpfrMat();
            var d = new MpfrMat();
            var sum1 = new Mpfr();
            var sum2 = new Mpfr();
            var sum3 = new Mpfr();
            var sum31 = new Mpfr();
            var sum32 = new Mpfr();
            var X = new Mpfr();
            var x2 = new Mpfr();
            var r2 = new Mpfr();
            var Rho2 = new Mpfr();
            var U = new Mpfr();
            var A2 = new Mpfr();
            var a = new Mpfr();
            var c2 = new Mpfr();
            var C = new Mpfr();
            var b2 = new Mpfr();
            var b = new Mpfr();
            var d1 = new Mpfr();
            var f6 = new Mpfr();
            var f6u = new Mpfr();
            var result = new Mpfr();
            int k;
            int k1;
            int k4;
            var Pi = new Mpfr();
            Pi = mreal.pi();
            r2 = r * r;
            Rho2 = rho * rho;
            X = r * rho;
            x2 = X * X;
            A2 = 1 - Rho2;
            a = mreal.sqrt(A2);
            c2 = 1 - r2;
            C = mreal.sqrt(c2);
            b2 = 1 - x2;
            b = mreal.sqrt(b2);
            U = mreal.acos(-X) / b;
            F.Resize(n + 1, 1);
            d.Resize(n + 1, 1);

            if (n % 2 != 0)
            {
                k1 = 2;
                d1 = mreal.acos(-r) / Pi;
                result = d1 - rho * C * U / Pi;
                if (n == 3)
                {
                    return result;
                    //return default;
                }
                else
                {
                }

                F[1 + k1] = result;
                result = d1 + ((x2 + 2 - 3 * Rho2) * r * C * A2 + (Rho2 - 3 + 2 * Rho2 * x2) * rho * c2 * C * U) / (2 * Pi * b2 * b2);
                if (n == 5)
                {
                    return result;
                    //return default;
                }
                else
                {
                }

                F[3 + k1] = result;
            }
            else
            {
                k1 = 3;
                d1 = mreal.acos(rho) / Pi;
                result = d1 + (-rho * a * c2 + r * A2 * a * U) / (Pi * b2);
                if (n == 4)
                {
                    return result;
                    //return default;
                }
                else
                {
                }

                F[1 + k1] = result;
                f6 = (X * r * (2 * x2 + 13) - 2 * rho * (4 * x2 * x2 + 6 * x2 + 5) + Rho2 * rho * (11 * x2 + 4)) * a * c2;
                f6u = (-r2 + 3 + 2 * x2 * (-2 * r2 + 1)) * r * A2 * A2 * a * U;
                result = d1 + (f6 + 3 * f6u) / (6 * Pi * b2 * b2 * b2);
                if (n == 6)
                {
                    return result;
                    //return default;
                }
                else
                {
                }

                F[3 + k1] = result;
            }

            d[3] = A2 * (1 + X * U) / (Pi * b2 * C);
            d[4] = A2 * a * (b2 * U + 3 * X * (1 + X * U)) / (b2 * b2 * Pi);

            // This is calculating the density
            var loopTo = n;
            for (k = 5; k <= loopTo; k++)
                d[k] = (a * C * X * d[k - 1] * (2 * k - 5) / (k - 3) + A2 * c2 * d[k - 2] * (k - 3) / (k - 4)) / b2;

            // This is calculating the CDF
            var loopTo1 = n;
            for (k = k1 + 5; k <= loopTo1; k += 2)
            {
                k4 = k - 4;
                sum1 = (2 * k4 * Rho2 - k + 5) * F[k - 2];
                sum2 = (k - 5) * A2 * F[k4];
                sum31 = rho * (k4 * a * C - (2 * k - 9) * b2 / (a * C)) * d[k - 1] / k4;
                k4 = k4 * k4;
                sum32 = r * (k4 + (3 * k * (k - 8) + 47) * Rho2) * d[k - 2] / k4;
                sum3 = sum31 + sum32;
                F[k] = (sum1 + sum2 + sum3) / ((k - 3) * Rho2);
                // Debug.Print k, F(k + 5), sum1, sum2, sum31, sum32, (sum31 + sum32) / sum31
            }


            return F[n];
        }



    }





    static class DemoPearsonArb
    {




        public static Arb RhoExplicit_Arb(int n, Arb r, Arb rho)
        {
            Console.WriteLine("In RhoExplicit_Arb, n:{0}", n);
            Console.WriteLine(" r: {0}, rho: {1}", r, rho);
            var F = new ArbMat();
            var d = new ArbMat();
            var sum1 = new Arb();
            var sum2 = new Arb();
            var sum3 = new Arb();
            var sum31 = new Arb();
            var sum32 = new Arb();
            var X = new Arb();
            var x2 = new Arb();
            var r2 = new Arb();
            var Rho2 = new Arb();
            var U = new Arb();
            var A2 = new Arb();
            var a = new Arb();
            var c2 = new Arb();
            var C = new Arb();
            var b2 = new Arb();
            var b = new Arb();
            var d1 = new Arb();
            var f6 = new Arb();
            var f6u = new Arb();
            var result = new Arb();
            int k;
            int k1;
            int k4;
            var Pi = new Arb();
            Pi = aflint.pi();
            r2 = r * r;
            Rho2 = rho * rho;
            X = r * rho;
            x2 = X * X;
            A2 = 1 - Rho2;
            a = aflint.sqrt(A2);
            c2 = 1 - r2;
            C = aflint.sqrt(c2);
            b2 = 1 - x2;
            b = aflint.sqrt(b2);
            U = aflint.acos(-X) / b;
            F.Resize(n + 1, 1);
            d.Resize(n + 1, 1);

            if (n % 2 != 0)
            {
                k1 = 2;
                d1 = aflint.acos(-r) / Pi;
                result = d1 - rho * C * U / Pi;
                Console.WriteLine("result: {0}", result);
                if (n == 3)
                {
                    return result;
                    //return default;
                }
                else
                {
                }

                F[1 + k1] = result;
                result = d1 + ((x2 + 2 - 3 * Rho2) * r * C * A2 + (Rho2 - 3 + 2 * Rho2 * x2) * rho * c2 * C * U) / (2 * Pi * b2 * b2);
                if (n == 5)
                {
                    return result;
                    //return default;
                }
                else
                {
                }

                F[3 + k1] = result;
            }
            else
            {
                k1 = 3;
                d1 = aflint.acos(rho) / Pi;
                result = d1 + (-rho * a * c2 + r * A2 * a * U) / (Pi * b2);
                Console.WriteLine("result: {0}", result);
                if (n == 4)
                {
                    return result;
                    //return default;
                }
                else
                {
                }

                F[1 + k1] = result;
                f6 = (X * r * (2 * x2 + 13) - 2 * rho * (4 * x2 * x2 + 6 * x2 + 5) + Rho2 * rho * (11 * x2 + 4)) * a * c2;
                f6u = (-r2 + 3 + 2 * x2 * (-2 * r2 + 1)) * r * A2 * A2 * a * U;
                result = d1 + (f6 + 3 * f6u) / (6 * Pi * b2 * b2 * b2);
                Console.WriteLine("result: {0}", result);
                if (n == 6)
                {
                    return result;
                    //return default;
                }
                else
                {
                }

                F[3 + k1] = result;
            }

            d[3] = A2 * (1 + X * U) / (Pi * b2 * C);
            d[4] = A2 * a * (b2 * U + 3 * X * (1 + X * U)) / (b2 * b2 * Pi);

            // This is calculating the density
            var loopTo = n;
            for (k = 5; k <= loopTo; k++)
            {
                d[k] = (a * C * X * d[k - 1] * (2 * k - 5) / (k - 3) + A2 * c2 * d[k - 2] * (k - 3) / (k - 4)) / b2;
                Console.WriteLine("k: {0}, d(k): {1}", k, d[k]);
            }

            Console.WriteLine();
            // This is calculating the CDF
            var loopTo1 = n;
            for (k = k1 + 5; k <= loopTo1; k += 2)
            {
                k4 = k - 4;
                sum1 = (2 * k4 * Rho2 - k + 5) * F[k - 2];
                sum2 = (k - 5) * A2 * F[k4];
                sum31 = rho * (k4 * a * C - (2 * k - 9) * b2 / (a * C)) * d[k - 1] / k4;
                k4 = k4 * k4;
                sum32 = r * (k4 + (3 * k * (k - 8) + 47) * Rho2) * d[k - 2] / k4;
                sum3 = sum31 + sum32;
                F[k] = (sum1 + sum2 + sum3) / ((k - 3) * Rho2);
                Console.WriteLine("k: {0}, F(k): {1}", k, F[k]);
                // Debug.Print k, F(k + 5), sum1, sum2, sum31, sum32, (sum31 + sum32) / sum31
            }


            return F[n];
        }

        public static Arb RhoDensityDirect(int n, Arb r, Arb rho)
        {
            var d = new ArbMat();
            d.Resize(n + 1, 1);
            var Pi = aflint.pi();
            var r2 = r * r;
            var Rho2 = rho * rho;
            var X = r * rho;
            var x2 = X * X;
            var A2 = 1 - Rho2;
            var a = aflint.sqrt(A2);
            var c2 = 1 - r2;
            var C = aflint.sqrt(c2);
            var b2 = 1 - x2;
            var b = aflint.sqrt(b2);
            var U = aflint.acos(-X) / b;
            d[3] = A2 * (1 + X * U) / (Pi * b2 * C);
            d[4] = A2 * a * (b2 * U + 3 * X * (1 + X * U)) / (b2 * b2 * Pi);

            // This is calculating the density
            for (int k = 5, loopTo = n; k <= loopTo; k++)
                d[k] = (a * C * X * d[k - 1] * (2 * k - 5) / (k - 3) + A2 * c2 * d[k - 2] * (k - 3) / (k - 4)) / b2;
            return d[n];
        }


        public static ArbC Acb_RhoDensityDirect(int n, ArbC r, ArbC rho)
        {
            var d = new ArbMatC();
            d.Resize(n + 1, 1);
            var Pi = aflint.pi();
            var r2 = r * r;
            var Rho2 = rho * rho;
            var X = r * rho;
            var x2 = X * X;
            var A2 = 1 - Rho2;
            var a = aflintc.sqrt(A2);
            var c2 = 1 - r2;
            var C = aflintc.sqrt(c2);
            var b2 = 1 - x2;
            var b = aflintc.sqrt(b2);
            var U = aflintc.acos(-X) / b;
            d[3] = A2 * (1 + X * U) / (Pi * b2 * C);
            d[4] = A2 * a * (b2 * U + 3 * X * (1 + X * U)) / (b2 * b2 * Pi);

            // This is calculating the density
            for (int k = 5, loopTo = n; k <= loopTo; k++)
                d[k] = (a * C * X * d[k - 1] * (2 * k - 5) / (k - 3) + A2 * c2 * d[k - 2] * (k - 3) / (k - 4)) / b2;
            return d[n];
        }

    }
}