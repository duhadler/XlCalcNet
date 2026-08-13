using System;
using FixedPrecNet;
using Microsoft.VisualBasic;

namespace Distributions
{

    static class DistN
    {





        // **********************************************************************
        // Noncentral ChiSquare
        // '**********************************************************************


        #region Noncentral ChiSquare



        public static double Get_Normal_Delta(double alpha, double Beta)
        {
            double xa = DistX.ndisx(1d - alpha, alpha);
            double xb = DistX.ndisx(Beta, 1d - Beta);
            double Delta = xa - xb;
            return Delta;
        }



        public static void GetL(double F, ref double Chi2, ref double lambda, double alpha, double Beta)
        {
            double t;
            double n;
            double t2;
            double t3;
            double t4;
            double X;
            double x2;
            double x3;
            double x4;
            double x5;
            double y;
            double Y_12;
            double Y_32;
            double Y_52;
            double Y_4;
            double Y_112;
            X = DistX.ndisx(1d - Beta, Beta);
            Chi2 = DistX.cdisx(1d - alpha, alpha, F);
            t = (Chi2 - F) / F;
            n = F;
            t2 = t * t;
            t3 = t2 * t;
            t4 = t3 * t;
            x2 = X * X;
            x3 = x2 * X;
            x4 = x3 * X;
            x5 = x4 * X;
            y = 2d * t + 1d;
            Y_12 = Math.Sqrt(y);
            Y_32 = y * Y_12 * Math.Sqrt(n);
            Y_52 = y * Y_32;
            Y_4 = Y_52 * Y_32;
            Y_112 = Y_4 * Y_32;
            lambda = n * t + Math.Sqrt(2d * n * y) * X + 2d * ((3d * t + 2d) * x2 + (3d * t + 1d)) / (3d * y) - Math.Sqrt(2d) * ((6d * t + 5d) * x3 - (36d * t2 + 42d * t + 17d) * X) / (18d * Y_52) + ((324d * t2 + 594d * t + 276d) * x4 - (1080d * t3 + 2484d * t2 + 2394d * t + 976d) * x2 + (1080d * t3 + 1512d * t2 + 612d * t + 148d)) / (405d * Y_4) - Math.Sqrt(2d) * ((10368d * t3 + 30780d * t2 + 30564d * t + 10143d) * x5 - (25920d * t4 + 98928d * t3 + 163080d * t2 + 137544d * t + 47188d) * x3 + (45360d * t4 + 106704d * t3 + 80460d * t2 + 31092d * t + 13489d) * X) / (9720d * Y_112);





            if (lambda < 0d)
                lambda = 0.00001d;
        }



        public static double NoncentralChisquareX_Approx(double n, double lambda, double LeftTail, double RightTail)
        {
            double n1 = Math.Pow(n + lambda, 2d) / (n + 2d * lambda);
            double b = lambda / (n + lambda);
            double x = DistX.cdisx(LeftTail, RightTail, n1);
            return (1d + b) * x;
        }


        public static void DemoQuantileNoncentralChisquare()
        {
            double LeftTail;
            double Righttail;
            double RefTail;
            double x1;
            double lambda;
            bool IsGLM = true;
            bool IsExact = false;
            int Df1 = 24;
            lambda = 30.0d;
            // LeftTail = 0.9999
            // Righttail = 1 - LeftTail
            LeftTail = 0.0001d;
            Righttail = 1d - LeftTail;

            if (LeftTail < 0.5d)
                RefTail = LeftTail;
            else
                RefTail = Righttail;
            double LogBeta = Math.Log(LeftTail);

            x1 = NoncentralChisquareX_Approx(Df1, lambda, LeftTail, Righttail);
            LeftTail = non_central_chi_square_cdf(x1, Df1, lambda);

            double fx1 = LeftTail;
            Console.WriteLine("x1: {0}, fx1: {1}", x1, fx1);

            double lnPower = Math.Log(LeftTail);
            double L1 = x1;
            double L2 = L1;
            double LSign = 0.0d;
            double F_L1 = LogBeta - lnPower;
            double F_L2 = F_L1;
            if (F_L1 > 0d)
                LSign = +1;
            else
                LSign = -1;
            double Factor = 0.1d;
            double LStep = x1 * Factor;
            Console.WriteLine("L1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L1, LeftTail, lnPower, F_L1);

            do
            {
                L1 = L2;
                F_L1 = F_L2;
                L2 = L1 + LStep * LSign;
                LeftTail = non_central_chi_square_cdf(L2, Df1, lambda);
                lnPower = Math.Log(LeftTail);
                F_L2 = LogBeta - lnPower;
                Console.WriteLine("L2: {0}, LeftTail: {1}, lnPower: {2}, F_L2: {3}", L2, LeftTail, lnPower, F_L2);
                Factor = Factor + 0.1d;
                LStep = x1 * Factor;
            }
            while (F_L2 * LSign >= 0d);

            BrentNoncentralChisquareQuantile(IsExact, IsGLM, ref L1, ref L2, F_L1, F_L2, lambda, LogBeta, Df1, 0d, 0d);

        }



        public static double NoncentralChisquare_Quantile(bool IsExact, bool IsGLM, double x1, double lambda, double LogBeta, double Df1, double Df2, double omega)
        {
            double lnPower;
            double LeftTail;
            //double Righttail;
            LeftTail = non_central_chi_square_cdf(x1, Df1, lambda);
            lnPower = Math.Log(LeftTail);
            return LogBeta - lnPower;
        }


        public static void BrentNoncentralChisquareQuantile(bool IsExact, bool IsGLM, ref double a, ref double b, double fa, double fb, double t1, double LogBeta, double Df1, double Df2, double omega)
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
            var m = default(double);
            long iter;
            long maxiter;
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
                // Function
                fb = NoncentralChisquare_Quantile(IsExact, IsGLM, b, t1, LogBeta, Df1, Df2, omega);
                Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            }

        Finish:
            ;

            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            xs = b;
        }




        public static void Demo_ChiSquare_Lambda()
        {
            var lambda = default(double);
            double alpha;
            double Beta;
            double DF1, LeftTail; //, Righttail;
            var x1 = default(double);

            bool IsGLM = true;
            bool IsExact = false;
            DF1 = 4d;
            alpha = 0.0002d;
            Beta = 0.003d; // Beta must be < 1-alpha
            Console.WriteLine();


            double LogBeta = Math.Log(Beta);
            Console.WriteLine();
            GetL(DF1, ref x1, ref lambda, alpha, Beta); // this returns a value for x1 (at level alpha) and lambda

            double lambda_x1 = lambda;
            LeftTail = non_central_chi_square_cdf(x1, DF1, lambda);
            Console.WriteLine("lambda_x1: {0}, fx1: {1}", lambda_x1, LeftTail);

            double lnPower = Math.Log(LeftTail);
            double L1 = lambda_x1;
            double L2 = L1;
            double LSign = 0.0d;
            double F_L1 = LogBeta - lnPower;
            double F_L2 = F_L1;
            if (F_L1 > 0d)
                LSign = -1;
            else
                LSign = 1d;
            double Factor = 0.2d;
            double LStep = lambda * Factor;
            Console.WriteLine("L1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L1, LeftTail, lnPower, F_L1);
            do
            {
                L1 = L2;
                F_L1 = F_L2;
                L2 = L1 + LStep * LSign;
                LeftTail = non_central_chi_square_cdf(x1, DF1, L2);
                lnPower = Math.Log(LeftTail);
                F_L2 = LogBeta - lnPower;
                Console.WriteLine("L2: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L2, LeftTail, lnPower, F_L2);
                Factor = Factor + 0.2d;
                LStep = lambda * Factor;
            }
            while (F_L2 * LSign <= 0d);

            BrentChisquareLambda(IsExact, IsGLM, ref L1, ref L2, F_L1, F_L2, x1, LogBeta, DF1, 0d, 0d);

        }



        public static double Chisquare_New_Lambda(bool IsExact, bool IsGLM, double L2, double x1, double LogBeta, double Df1, double Df2, double omega)
        {
            double lnPower;
            double LeftTail;
            //double Righttail;
            LeftTail = non_central_chi_square_cdf(x1, Df1, L2);
            // FDisnByRhoSquareDis(IsExact, IsGLM, Df1, Df2, x1, L2, omega, LeftTail, Righttail)
            lnPower = Math.Log(LeftTail);
            return LogBeta - lnPower;
        }


        public static void BrentChisquareLambda(bool IsExact, bool IsGLM, ref double a, ref double b, double fa, double fb, double x1, double LogBeta, double Df1, double Df2, double omega)
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
            var m = default(double);
            long iter;
            long maxiter;
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
                // Function
                fb = Chisquare_New_Lambda(IsExact, IsGLM, b, x1, LogBeta, Df1, Df2, omega);
                Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            }

        Finish:
            ;

            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            xs = b;
        }




        public static double non_central_chi_square_cdf(double x, double k, double l)
        {
            double result;
            bool invert = false;
            if (x > k + l)
            {
                result = non_central_chi_square_q(x, k, l, -1.0d);
                invert = !invert;
            }
            else
            {
                result = non_central_chi_square_p(x, k, l, 0.0d);
            }
            if (invert)
                result = -result;
            return result;
        }


        public static double non_central_chi_square_cdf_complement(double x, double k, double l)
        {
            double result;
            bool invert = true;
            if (x > k + l)
            {
                result = non_central_chi_square_q(x, k, l, 0.0d);
                invert = !invert;
            }
            else
            {
                result = non_central_chi_square_p(x, k, l, -1.0d);
            }
            if (invert)
                result = -result;
            return result;
        }



        public static double non_central_chi_square_q(double x, double f, double theta, double init_sum)
        {
            if (x == 0d)
                return 1.0d;

            double lambda = theta / 2d;
            double del = f / 2d;
            double y = x / 2d;
            int max_iter = 1000000; // policies::get_max_series_iterations<Policy>()
            double errtol = 0.000000000000001d; // boost::math::policies::get_epsilon<T, Policy>()
            double sum = init_sum;

            // Dim k As Int32 = Convert.ToInt32(round(lambda))
            int k = Convert.ToInt32(Math.Round(lambda));
            // Forwards and backwards Poisson weights:
            double poisf = dreal.real_gamma_p_prime(1 + k, lambda);
            // Dim poisf As Double = boost2.gamma_p_derivative((1 + k), lambda)
            double poisb = poisf * k / lambda;
            // Initial forwards central chi squared term:
            double gamf = dreal.real_gamma_q(del + k, y);
            // Dim gamf As Double = boost2.gamma_q(del + k, y)
            // Forwards and backwards recursion terms on the central chi squared:
            double xtermf = dreal.real_gamma_p_prime(del + 1d + k, y);
            // Dim xtermf As Double = boost2.gamma_p_derivative(del + 1 + k, y)
            double xtermb = xtermf * (del + k) / y;
            // Initial backwards central chi squared term:
            double gamb = gamf - xtermb;

            // Forwards iteration first, this is the
            // stable direction for the gamma function
            // recurrences:
            // 
            var i = default(int);
            var loopTo = max_iter - (i - k);
            for (i = k; i <= loopTo; i++)
            {
                double term = poisf * gamf;
                sum += term;
                poisf *= lambda / (i + 1);
                gamf += xtermf;
                xtermf *= y / (del + i + 1d);
                if ((sum == 0d | Math.Abs(term / sum) < errtol) & term >= poisf * gamf)
                    break;
            }
            // Error check:
            if (i - k >= max_iter)
            {
                Console.WriteLine("cdf(non_central_chi_squared_distribution Series did not converge, closest value was {0}", sum);
                return 0.0d;
            }

            // Now backwards iteration: the gamma
            // function recurrences are unstable in this
            // direction, we rely on the terms deminishing in size
            // faster than we introduce cancellation errors.
            // For this reason it's very important that we start
            // *before* the largest term so that backwards iteration
            // is strictly converging.
            // 
            for (i = k - 1; i >= 0; i -= 1)
            {
                double term = poisb * gamb;
                sum += term;
                poisb *= i / lambda;
                xtermb *= (del + i) / y;
                gamb -= xtermb;
                if (sum == 0d | Math.Abs(term / sum) < errtol)
                    break;
            }

            return sum;
        }





        public static double non_central_chi_square_p(double y, double n, double lambda, double init_sum)
        {
            if (y == 0d)
                return 0.0d;

            // Dim lambda As Double = theta / 2
            int max_iter = 1000000; // policies::get_max_series_iterations<Policy>()
            double errtol = 0.000000000000001d; // boost::math::policies::get_epsilon<T, Policy>()
            double errorf = 0.0d;
            double errorb = 0.0d;

            double x = y / 2d;
            double del = lambda / 2d;
            // 
            // Starting location for the iteration, we'll iterate
            // both forwards and backwards from this point.  The
            // location chosen is the maximum of the Poisson weight
            // function, which ocurrs *after* the largest term in the
            // sum.
            // 

            // Dim k As Int32 = Convert.ToInt32(round(lambda))
            int k = (int)Math.Round(Math.Round(lambda));
            double a = n / 2d + k;
            // Central chi squared term for forward iteration:
            double gamkf = dreal.real_gamma_p(a, x);
            // Dim gamkf As Double = boost2.gamma_p(a, x)

            if (lambda == 0d)
                return gamkf;
            // Central chi squared term for backward iteration:
            double gamkb = gamkf;
            // Forwards Poisson weight:
            double poiskf = dreal.real_gamma_p_prime(k + 1, del);
            // Dim poiskf As Double = boost2.gamma_p_derivative((k + 1), del)
            // Backwards Poisson weight:
            double poiskb = poiskf;
            // Forwards gamma function recursion term:
            double xtermf = dreal.real_gamma_p_prime(a, x);
            // Dim xtermf As Double = boost2.gamma_p_derivative(a, x)

            // Backwards gamma function recursion term:
            double xtermb = xtermf * x / a;
            double sum = init_sum + poiskf * gamkf;
            if (sum == 0d)
                return sum;
            int i = 1;
            // 
            // Backwards recursion first, this is the stable
            // direction for gamma function recurrences:
            // 
            while (i <= k)
            {
                xtermb *= (a - i + 1d) / x;
                gamkb += xtermb;
                poiskb = poiskb * (k - i + 1) / del;
                errorf = errorb;
                errorb = gamkb * poiskb;
                sum += errorb;
                if (Math.Abs(errorb / sum) < errtol & errorb <= errorf)
                    break;
                i = i + 1;
            }

            i = 1;
            // 
            // Now forwards recursion, the gamma function
            // recurrence relation is unstable in this direction,
            // so we rely on the magnitude of successive terms
            // decreasing faster than we introduce cancellation error.
            // For this reason it's vital that k is chosen to be *after*
            // the largest term, so that successive forward iterations
            // are strictly (and rapidly) converging.
            // 
            do
            {
                xtermf = xtermf * x / (a + i - 1d);
                gamkf = gamkf - xtermf;
                poiskf = poiskf * del / (k + i);
                errorf = poiskf * gamkf;
                sum += errorf;
                i = i + 1;
            }
            while (Math.Abs(errorf / sum) > errtol & i < max_iter);

            // Error check:
            if (i >= max_iter)
            {
                Console.WriteLine("cdf(non_central_chi_squared_distribution Series did not converge, closest value was {0}", sum);
                return sum;
            }

            return sum;
        }





        public static double Cdisn(double n, double X, double lambda, ref double LeftTail, ref double RightTail)
        {
            double CdisnRet = 0.0;
            Cdisn2(n, X, lambda, ref LeftTail, ref RightTail);
            CdisnRet = LeftTail;
            return CdisnRet;
        }

        public static void Cdisn2(double n, double X, double lambda, ref double LeftTail, ref double RightTail)
        {
            long j;
            double EL;
            double L;
            double Lj;
            var sumL = default(double);
            var sumR = default(double);
            double Left1;
            double Right1;
            double RelError;
            var density = default(double);
            double r2;
            double Right2;
            double lefttail1;
            double RightTail1;
            bool NotAccurate;
            L = lambda / 2d;
            EL = Math.Exp(-L);
            DistMain.cdis2(n, X, ref sumL, ref sumR, ref density);
            Right2 = sumR;
            r2 = 2d * density * X / n;
            Lj = 1d;
            RelError = 1d;
            NotAccurate = true;
            j = 0L;

            while (NotAccurate)
            {
                j = j + 1L;
                Lj = Lj * L / j;
                Right2 = Right2 + r2;
                r2 = r2 * X / (n + 2L * j);
                RightTail1 = Right2;
                lefttail1 = 1d - RightTail1;
                Left1 = lefttail1;
                Right1 = RightTail1;
                sumL = sumL + Left1 * Lj;
                sumR = sumR + Right1 * Lj;
                RelError = sumL * Lj / sumL;
                NotAccurate = RelError > 0.0000000000000001d;
            }
            LeftTail = sumL * EL;
            RightTail = sumR * EL;
        }





        public static void CdisnCohen(double n, double X, double lambda, ref double LeftTail, ref double RightTail)
        {
            // Dim n As Int32 = 9
            // Dim x = 4
            // Dim lambda = 6
            double x1 = Math.Sqrt(X);
            double d = Math.Sqrt(lambda);
            double e = Math.Exp(0.5d * (X + lambda));

            double g1 = Math.Cosh(Math.Sqrt(X * lambda)) / Math.Sqrt(2d * Math.PI * X) / e;
            double g3 = Math.Sinh(Math.Sqrt(X * lambda)) / Math.Sqrt(2d * Math.PI * lambda) / e;
            double F1 = dreal.ndis(x1 - d) - dreal.ndis(-x1 - d);
            // Dim F1 = boost2.dist_normal(x1 - d, 0, 1, 2) - boost2.dist_normal(-x1 - d, 0, 1, 2)
            double F3 = F1 - 2d * g3;

            // Console.WriteLine("F1: {0}", F1)
            // Console.WriteLine("i: {0}; g1: {1}; F1: {2}", 1, g1, F1)
            // Console.WriteLine("i: {0}; g3: {1}; F3: {2}", 3, g3, F3)
            for (double i = 5d, loopTo = n; i <= loopTo; i += 2d)
            {
                double g5 = (X * g1 - (i - 4d) * g3) / lambda;
                double F5 = F3 - 2d * g5;
                g1 = g3;
                g3 = g5;
                F3 = F5;
                // Console.WriteLine("i: {0}; g5: {1}; F3: {2}", i, g5, F5)
            }
            LeftTail = F3;
            RightTail = 1d - LeftTail;

        }


        public static void Cdisn_Penev(double n, double x, double l, ref double LeftTail, ref double RightTail)
        {
            double s;
            double z;
            double m2;
            double hs;
            double sg;
            m2 = l / n;
            if (m2 == 0d)
                s = x / n;
            else
                s = (-1 + Math.Sqrt(1d + 4d * x * m2 / n)) / (2d * m2);
            // Debug.Print "s:", S
            if (s == 1d)
                s = 1d + 0.0000001d / n;
            if (s > 1d)
                sg = 1d;
            else
                sg = -1;
            hs = h(s);
            z = n * Math.Pow(s - 1d, 2d);
            z = z * (1d / (2d * s) + m2 - 1d / s * hs);
            z = z - Math.Log(1d / s - 2d / s * hs / (1d + 2d * m2 * s));
            z = z + 2d * Math.Pow(1d + 3d * m2, 2d) / (9d * n * Math.Pow(1d + 2d * m2, 3d));
            z = sg * Math.Sqrt(Math.Abs(z));
            LeftTail = DistMain.ndis(z);
            RightTail = 1d - LeftTail;
        }


        private static double h2(double y)
        {
            if (y == 0d)
            {
                return 0.0d;
            }
            else
            {
                return 1d / (y * y) * ((1d - y) * Math.Log(1d - y) + y - 0.5d * y * y);
            }
        }


        private static double h(double s)
        {
            double hRet = 0.0;
            if (s <= 0d)
                hRet = h2(1d - s);
            else
                hRet = -h2(1d - 1d / s);
            return hRet;
        }




        public static void NonCentralChi2_SPA(double n, double x, double lambda, ref double LeftTail, ref double Righttail)
        {
            double k;
            double k1;
            double k2;
            double k3;
            double k4;
            double s;
            double t;
            double t2;
            double t3;
            double t4;
            double u;
            double w;
            var density = default(double);

            s = -(1d / (4d * x)) * (n - 2d * x + Math.Sqrt(n * n + 4d * x * lambda));
            t = 1d / (1d - 2d * s);
            t2 = t * t;
            t3 = t2 * t;
            t4 = t3 * t;
            k = -(n / 2d) * Math.Log(1d - 2d * s) + lambda * s * t;
            k1 = t * (n + lambda * t);
            k2 = 2d * t2 * (n + 2d * lambda * t);
            k3 = 8d * t3 * (n + 3d * lambda * t);
            k4 = 48d * t4 * (n + 4d * lambda * t);
            w = Math.Sign(s) * Math.Sqrt(2d * (s * k1 - k));
            u = s * Math.Sqrt(k2);
            DistMain.LugannaniRice(w, u, k2, k3, k4, ref density, ref LeftTail, ref Righttail);
        }


        public static double NonCentralChi2_CGF_Derivative(double t, double n, double lambda, int j)
        {
            double p1;
            double p2;
            p1 = Math.Pow(2d, j - 1) * dreal.real_gamma(j) / Math.Pow(1d - 2d * t, j);
            // p1 = (2 ^ (j - 1)) * boost2.gamma(j) / ((1 - 2 * t) ^ j)
            p2 = n + lambda * j / (1d - 2d * t);
            return p1 * p2;
        }


        public static void NonCentralChi2_SPA2(double n, double x, double lambda, ref double LeftTail, ref double Righttail)
        {
            double s, density = 0.0;
            Console.WriteLine("n: {0}, x: {1}, lambda: {2}", n, x, lambda);
            s = -(1d / (4d * x)) * (n - 2d * x + Math.Sqrt(n * n + 4d * x * lambda));

            int order = 28;
            var kappa = new double[order + 1 + 1];
            kappa[0] = -(n / 2d) * Math.Log(1d - 2d * s) + lambda * s / (1d - 2d * s);
            for (int j = 1, loopTo = order; j <= loopTo; j++)
                // Console.WriteLine("j: {0}, kappa: {1}", j, kappa(j))
                kappa[j] = NonCentralChi2_CGF_Derivative(s, n, lambda, j);

            // Console.WriteLine("")
            LugannaniRiceNew(order, kappa, s, ref density, ref LeftTail, ref Righttail);
        }


        public static void Fill_d(int order, ref double[,] d, double[] theta)
        {
            d[0, 0] = 1d;
            for (int m = 0, loopTo = order; m <= loopTo; m++)
            {
                for (int n = m, loopTo1 = order; n <= loopTo1; n++)
                {
                    double sum = 0.0d;
                    for (int k = 1, loopTo2 = n - m + 1; k <= loopTo2; k++)
                        sum = sum + k * theta[k + 2] * d[m, n - k + 1];
                    d[m + 1, n + 1] = sum / (n + 1);
                }
            }
        }



        public static double GammaHalf(int mj)
        {
            return dreal.real_gamma(mj + 0.5d) / Math.Sqrt(Math.PI);
            // Return boost2.gamma(mj + 0.5) / Math.Sqrt(Math.PI)
        }


        public static double Calc_A(int j, double A0, double mu, double[,] d, double[] theta)
        {
            double sum1 = 0.0d;
            for (int n = 0, loopTo = 2 * j; n <= loopTo; n++)
            {
                double sum2 = 0.0d;
                for (int m = 0, loopTo1 = n; m <= loopTo1; m++)
                {
                    double delta = d[m, n];
                    // Console.WriteLine("m: {0}, n: {1}, delta: {2}", m, n, delta)
                    double summand2 = delta * Math.Pow(-2, m + j) * GammaHalf(m + j);
                    sum2 = sum2 + summand2;
                }
                double factor = Math.Pow(-mu, 2 * j - n);
                // Console.WriteLine("factor: {0}, sum2: {1}, -mu: {2}", factor, sum2, -mu)
                sum1 = sum1 + factor * sum2;
            }
            return A0 * sum1;
        }

        public static void LugannaniRiceNew(int order, double[] kappa, double s, ref double density, ref double LeftTail, ref double RightTail)
        {
            double mu, w1, w2, LeftTail0 = 0.0, RightTail0 = 0.0, u, w;
            var theta = new double[order + 1 + 1];
            var A = new double[order + 1 + 1];
            var B = new double[order + 1 + 1];
            var sum = new double[order + 1 + 1];
            var d = new double[2 * order + 3 + 1, 2 * order + 3 + 1];


            w = Math.Sign(s) * Math.Sqrt(2d * (s * kappa[1] - kappa[0]));
            u = s * Math.Sqrt(kappa[2]);
            w1 = 1d / w;
            w2 = -2 * w1 * w1;
            mu = 1d / u;

            double k = Math.Sqrt(kappa[2]);
            double factor = 2d * kappa[2];
            for (int j = 3, loopTo = order; j <= loopTo; j++)
            {
                factor = factor * j * k;
                theta[j] = kappa[j] / factor;
                // Console.WriteLine("j: {0}, theta: {1}", j, theta(j))
            }
            // Console.WriteLine("")


            DistMain.ndis2(false, w, ref LeftTail0, ref RightTail0, ref density);
            B[0] = density * w1;
            factor = 0.5d;
            for (int j = 1, loopTo1 = order; j <= loopTo1; j++)
            {
                B[j] = B[j - 1] * w2 * factor;
                factor = factor + 1d;
            }

            Fill_d(order - 2, ref d, theta);
            A[0] = density * mu;
            for (int j = 1, loopTo2 = order - 2; j <= loopTo2; j++)
                A[j] = Calc_A(j, A[0], mu, d, theta);

            double totalsum = 0d;
            int useorder = order - 2;
            Console.WriteLine("j: {0}, Leftj: {1}, Rightj: {2}", 0, LeftTail0 - totalsum, RightTail0 + totalsum);
            for (int j = 0, loopTo3 = useorder; j <= loopTo3; j++)
            {
                sum[j] = A[j] - B[j];
                totalsum = totalsum + sum[j];
                Console.WriteLine("j: {0}, Leftj: {1}, Rightj: {2}, Aj: {3}, Bj: {4}, sumj: {5}", j, LeftTail0 - totalsum, RightTail0 + totalsum, A[j], B[j], sum[j]);
            }

            LeftTail = LeftTail0 - totalsum;
            RightTail = RightTail0 + totalsum;
            Console.WriteLine("");
            Console.WriteLine("");
        }




        public static void TestNonCentralChi2()
        {
            double n;
            double lambda;
            double x;
            var LeftTail = default(double);
            var Righttail = default(double);
            x = 10d;
            n = 12.5d;
            lambda = 200d;

            NonCentralChi2_SPA(n, x, lambda, ref LeftTail, ref Righttail);
            Console.WriteLine("LeftTail: {0}, Righttail:{1}", LeftTail, Righttail);

            // LeftTail = dreal.dist_pchisq_nc(x, n, lambda, True, False)
            // LeftTail = boost2.dist_chisq_nc(x, n, lambda, 2)
            // Righttail = dreal.dist_pchisq_nc(x, n, lambda, False, False)
            // Righttail = boost2.dist_chisq_nc(x, n, lambda, 3)
            // Console.WriteLine("LeftTail: {0}, Righttail:{1}", LeftTail, Righttail)

            Cdisn_Penev(n, x, lambda, ref LeftTail, ref Righttail);
            Console.WriteLine("LeftTail: {0}, Righttail:{1}", LeftTail, Righttail);
        }



        public static double MarcumQ(double nu, double a, double b)
        {
            // Return dreal.dist_pchisq_nc(b * b, nu * 2, a * a, False, False)
            // Return boost2.dist_chisq_nc(b * b, nu * 2, a * a, 3)
            return 1d;
        }

        public static void DemoMarcumQ()
        {
            double nu = 7.7d;
            double a = 2.2d;
            double b = 2.6d;
            double result = MarcumQ(nu, a, b);
            Console.WriteLine("MarcumQ result: {0}", result);
        }



        #endregion







        // **********************************************************************
        // Noncentral Beta cdf
        // '**********************************************************************


        #region Noncentral Beta

        public static double ibeta_imp(double a, double b, double x, bool inv, bool normalised, ref double xterm)
        {
            xterm = dreal.real_ibeta_prime(a, b, x);
            // xterm = boost2.ibeta_derivative(a, b, x)
            return dreal.real_ibeta(a, b, x);
            // Return boost2.ibeta(a, b, x)
        }




        public static double non_central_beta_cdf(double a, double b, double lambda, double x, double y)
        {
            bool invert = false;
            double result;
            double c = a + b + lambda / 2d;
            double cross = 1d - b / c * (1d + lambda / (2d * c * c));
            if (x > cross)
            {
                result = non_central_beta_q(a, b, lambda, x, y, -1.0d);
                invert = !invert;
            }
            else
            {
                result = non_central_beta_p(a, b, lambda, x, y, 0.0d);
            }
            if (invert)
                result = -result;
            return result;
        }



        public static double non_central_beta_cdf_complement(double a, double b, double lambda, double x, double y)
        {
            bool invert = true;
            double result;
            double c = a + b + lambda / 2d;
            double cross = 1d - b / c * (1d + lambda / (2d * c * c));
            if (x > cross)
            {
                result = non_central_beta_q(a, b, lambda, x, y, 0.0d);
                invert = !invert;
            }
            else
            {
                result = non_central_beta_p(a, b, lambda, x, y, -1.0d);
            }
            if (invert)
                result = -result;
            return result;
        }


        public static double non_central_beta_p(double a, double b, double lambda, double x, double y, double init_val)
        {
            int max_iter = 1000000; // policies::get_max_series_iterations<Policy>()
            double errtol = 0.000000000000001d; // boost::math::policies::get_epsilon<T, Policy>()

            double l2 = lambda / 2d;

            // k is the starting point for iteration, And Is the
            // maximum of the poisson weighting term,
            // note that unlike other similar code, we do not set
            // k to zero, when l2 Is small, as forward iteration
            // is unstable
            int k = Convert.ToInt32(Math.Round(l2));

            if (k == 0)
                k = 1;

            // Forwards and backwards Poisson weights:
            double pois = dreal.real_gamma_p_prime(k + 1, l2);
            // Dim pois As Double = boost2.gamma_p_derivative((k + 1), l2)
            if (pois == 0d)
                return init_val;
            double xterm = 0.0, beta;
            if (x < y)
            {
                beta = ibeta_imp(a + k, b, x, false, true, ref xterm);
            }
            else
            {
                beta = ibeta_imp(b, a + k, y, true, true, ref xterm);
            }
            xterm *= y / (a + b + k - 1d);
            double poisf = pois;
            double betaf = beta;
            double xtermf = xterm;
            double sum = init_val;
            if (beta == 0d & xterm == 0d)
            {
                return init_val;
            }

            // Backwards recursion first, this is the stable
            // direction for recursion:
            double last_term = 0d;
            int count = k;
            for (int i = k; i >= 0; i -= 1)
            {
                double term = beta * pois;
                sum += term;
                if (Math.Abs(term / sum) < errtol & last_term >= term | term == 0d)
                {
                    count = k - i;
                    break; // break
                }
                pois *= i / l2;
                beta += xterm;
                xterm *= (a + i - 1d) / (x * (a + b + i - 2d));
                last_term = term;
            }

            // Now forward recursion
            for (int i = k + 1, loopTo = max_iter; i <= loopTo; i++)
            {
                poisf *= l2 / i;
                xtermf *= x * (a + b + i - 2d) / (a + i - 1d);
                betaf -= xtermf;

                double term = poisf * betaf;
                sum += term;
                if (Math.Abs(term / sum) < errtol | term == 0d)
                {
                    break; // break
                }

                // Error check:
                if (i >= max_iter)
                {
                    Console.WriteLine("cdf(non_central_beta_distribution) Series did not converge, closest value was {0}", sum);
                    return sum;
                }
            }
            return sum;

        }



        public static double non_central_beta_q(double a, double b, double lambda, double x, double y, double init_val)
        {
            int max_iter = 1000000; // policies::get_max_series_iterations<Policy>()
            double errtol = 0.000000000000001d; // boost::math::policies::get_epsilon<T, Policy>()

            double l2 = lambda / 2d;

            // k is the starting point for iteration, and is the
            // maximum of the poisson weighting term:
            int k = Convert.ToInt32(Math.Round(l2));
            double pois;
            if (k <= 30)
            {
                // Might as well start at 0 since we'll likely have this number of terms anyway:
                if (a + b > 1d)
                {
                    k = 0;
                }
                else if (k == 0)
                {
                    k = 1;
                }
            }

            if (k == 0)
            {
                // Starting Poisson weight:
                pois = Math.Exp(-l2);
            }
            else
            {
                // Starting Poisson weight:
                pois = dreal.real_gamma_p_prime(k + 1, l2);
                // pois = boost2.gamma_p_derivative((k + 1), l2)
            }

            if (pois == 0d)
                return init_val;
            // recurance term:
            double xterm = 0.0, beta;
            if (x < y)
            {
                beta = ibeta_imp(a + k, b, x, true, true, ref xterm);
            }
            else
            {
                beta = ibeta_imp(b, a + k, y, false, true, ref xterm);
            }
            xterm *= y / (a + b + k - 1d);
            double poisf = pois;
            double betaf = beta;
            double xtermf = xterm;
            double sum = init_val;
            if (beta == 0d & xterm == 0d)
            {
                return init_val;
            }

            // Forwards recursion first, this is the stable
            // direction for recursion, and the location
            // of the bulk of the sum

            double last_term = 0d;
            int count = 0;
            for (int i = k + 1, loopTo = max_iter; i <= loopTo; i++)
            {
                poisf *= l2 / i;
                xtermf *= x * (a + b + i - 2d) / (a + i - 1d);
                betaf += xtermf;

                double term = poisf * betaf;
                sum += term;
                if (Math.Abs(term / sum) < errtol & last_term >= term)
                {
                    count = i - k;
                    break; // break
                }

                // Error check:
                if (i - k >= max_iter)
                {
                    Console.WriteLine("cdf(non_central_beta_distribution) Series did not converge, closest value was {0}", sum);
                }
                last_term = term;
            }


            // Now backward recursion
            for (int i = k; i >= 0; i -= 1)
            {
                double term = beta * pois;
                sum += term;
                if (Math.Abs(term / sum) < errtol)
                {
                    break; // break
                }

                // Error check:
                if (count + k - i >= max_iter)
                {
                    Console.WriteLine("cdf(non_central_beta_distribution) Series did not converge, closest value was {0}", sum);
                }

                pois *= i / l2;
                beta -= xterm;
                xterm *= (a + i - 1d) / (x * (a + b + i - 2d));
            }

            return sum;

        }



        public static void BetadisnPaolella(double a, double b, double xbeta, double ybeta, double nc, ref double density, ref double LeftTail, ref double RightTail)
        {
            FdisnPaolella(2d * a, 2d * b, b * xbeta / (a * ybeta), nc, 0d, ref density, ref LeftTail, ref RightTail);
        }



        public static double BetadisnSeber(double x, double a, long b, double lambda, ref double LeftTail, ref double RightTail)
        {
            double C;
            double f;
            double b0;
            double b1;
            double S;
            long k;
            C = Math.Pow(x, a) * Math.Exp(lambda * (x - 1d) / 2d);
            b0 = 0d;
            b1 = 1d;
            S = 1d;
            var loopTo = b;
            for (k = 2L; k <= loopTo; k++)
            {
                f = (2L * k - 4L + a + lambda * x / 2d) * b1 + (k - 3L + a) * (x - 1d) * b0;
                f = f * (1d - x) / (k - 1L);
                S = S + f;
                b0 = b1;
                b1 = f;
            }
            LeftTail = C * S;
            RightTail = 1d - LeftTail;
            return LeftTail;
        }


        public static void Betadisn(double a, double b, double X, double y, double d, ref double LeftTail, ref double RightTail)
        {
            long n;
            long Mode;
            var density = default(double);
            double t;
            double snRight;
            double d2;
            double sn;
            double rn;
            double FehlerLeft;
            double RelFehlerLeft;
            double ResultLeft;
            double qsum;
            double expd2;
            double Lastvalue;
            var l1 = default(double);
            double RelFehlerRight;
            double ResultRight; // , l2 As Double, r2 As Double

            LeftTail = DistMain.Fdis((2d * a + d) * (2d * a + d) / (2d * (a + d)), 2d * b, 2d * b / (2d * a + d) * X / (1d - X));
            if (LeftTail < 0.01d)
                Mode = 1L;
            else
                Mode = 2L;

            // Mode = 1
            d2 = d / 2d;
            rn = 1d;
            n = 1L;
            expd2 = Math.Exp(-d2);
            // t = LnGamma(a + b) - LnGamma(a + 1) - LnGamma(b)
            // t = t + a * Log(X) + b * Log(y)
            // t = Exp(t)
            DistMain.betadis(a, b, X, y, ref LeftTail, ref RightTail, ref density);
            t = density * X * y / a;
            // Debug.Print "t: ", t, density * X * y / a
            sn = LeftTail;
            Lastvalue = LeftTail;
            snRight = RightTail;
            qsum = 1d;
            if (Mode == 1L)
            {
                do
                {
                    rn = rn * d2 / n;
                    qsum = qsum + rn;
                    LeftTail = LeftTail - t;
                    if (Lastvalue / LeftTail > 1000.0d)
                    {
                        DistMain.betadis(a + n, b, X, y, ref l1, ref RightTail, ref density);
                        Lastvalue = l1;
                        LeftTail = l1;
                    }
                    sn = sn + rn * LeftTail;
                    t = t * X * (a + b + n - 1d) / (a + n);
                    FehlerLeft = LeftTail * (1d - expd2 * qsum);
                    ResultLeft = expd2 * sn;
                    RelFehlerLeft = FehlerLeft / ResultLeft;
                    n = n + 1L;
                }
                while (RelFehlerLeft >= 0.0000000000000001d);
                LeftTail = ResultLeft;
                RightTail = 1d - LeftTail;
            }

            // Mode = 2
            if (Mode == 2L)
            {
                do
                {
                    rn = rn * d2 / n;
                    RightTail = RightTail + t;
                    snRight = snRight + rn * RightTail;
                    t = t * X * (a + b + n - 1d) / (a + n);
                    RelFehlerRight = rn * RightTail / snRight;
                    n = n + 1L;
                }
                while (RelFehlerRight >= 0.0000000000000001d);
                ResultRight = expd2 * snRight;
                RightTail = ResultRight;
                LeftTail = 1d - RightTail;
            }




        }


        #endregion







        // **********************************************************************
        // Singly noncentral F cdf
        // '**********************************************************************

        #region Noncentral F



        public static double non_central_f_cdf(double xparam, double df1, double df2, double lambda)
        {
            double alpha = df1 / 2d;
            double beta = df2 / 2d;
            double y = xparam * alpha / beta;
            double x = y / (1d + y);
            double cx = 1d / (1d + y);
            double result = non_central_beta_cdf(alpha, beta, lambda, x, cx);
            return result;
        }


        public static double non_central_f_cdf_complement(double xparam, double df1, double df2, double lambda)
        {
            double alpha = df1 / 2d;
            double beta = df2 / 2d;
            double y = xparam * alpha / beta;
            double x = y / (1d + y);
            double cx = 1d / (1d + y);
            double result = non_central_beta_cdf_complement(alpha, beta, lambda, x, cx);
            return result;
        }



        public static double Fdisn(double m, double n, double a, double NC)
        {
            double FdisnRet = 0.0;
            double X;
            double y;
            double p;
            double Q;
            var L = default(double);
            var r = default(double);
            // Dim density As Double
            if (a <= 0d)
            {
                FdisnRet = 0d;
                return FdisnRet;
            }
            X = m * a / (m * a + n);
            y = n / (m * a + n);
            p = m / 2d;
            Q = n / 2d;
            Betadisn(p, Q, X, y, NC, ref L, ref r);
            FdisnRet = r;
            return FdisnRet;
            // If Not (IsMissing(LeftTail)) Then LeftTail = L
            // If Not (IsMissing(RightTail)) Then RightTail = r
        }



        public static double Fdisn2(double m, double n, double a, double NC, ref double LeftTail, ref double RightTail)
        {
            double Fdisn2Ret = 0.0;
            double X;
            double y;
            double p;
            double Q;
            // Dim density As Double
            if (a <= 0d)
            {
                Fdisn2Ret = 0d;
                return Fdisn2Ret;
            }
            X = m * a / (m * a + n);
            y = n / (m * a + n);
            p = m / 2d;
            Q = n / 2d;
            Betadisn(p, Q, X, y, NC, ref LeftTail, ref RightTail);
            Fdisn2Ret = RightTail;
            return Fdisn2Ret;
            // If Not (IsMissing(LeftTail)) Then LeftTail = L
            // If Not (IsMissing(RightTail)) Then RightTail = r
        }




        public static double FdisnSeber(double x, double m, long n, double lambda, ref double LeftTail, ref double RightTail)
        {
            if (n % 2L != 0L)
            {
                return double.NaN;  // n needs to be an even integer
            }
            else
            {
                return BetadisnSeber(m * x / (m * x + n), m / 2d, n / 2L, lambda, ref LeftTail, ref RightTail);
            }
        }



        #endregion







        // **********************************************************************
        // Singly noncentral T cdf
        // '**********************************************************************


        #region NoncentralT



        public static double non_central_t_cdf(double v, double delta, double t)
        {
            return non_central_t_cdf_main(v, delta, t, false);
        }


        public static double non_central_t_cdf_complement(double v, double delta, double t)
        {
            return non_central_t_cdf_main(v, delta, t, true);
        }


        public static double non_central_t_cdf_main(double v, double delta, double t, bool invert)
        {
            if (t < 0d)
            {
                t = -t;
                delta = -delta;
                invert = !invert;
            }

            // x and y are the corresponding random
            // variables for the noncentral beta distribution,
            // with y = 1 - x
            double X = t * t / (v + t * t);
            double y = v / (v + t * t);
            double d2 = delta * delta;
            double a = 0.5d;
            double b = v / 2d;
            double c = a + b + d2 / 2d;
            // 
            // Crossover point for calculating p Or q Is the same
            // as for the noncentral beta:
            // 
            double cross = 1d - b / c * (1d + d2 / (2d * c * c));
            double result;

            if (X < cross)
            {
                // Calculate p
                if (X != 0d)
                {
                    result = non_central_beta_p(a, b, d2, X, y, 0.0d);
                    result = non_central_t2_p(v, delta, X, y, result);
                    result /= 2d;
                }
                else
                {
                    result = 0d;
                    result += dreal.ndis(-delta);
                    // result += boost2.dist_normal(-delta, 0, 1, 2)
                }
            }
            else
            {
                // Calculate q:
                invert = !invert;
                if (X != 0d)
                {
                    result = non_central_beta_q(a, b, d2, X, y, 0d);
                    result = non_central_t2_q(v, delta, X, y, result);
                    result /= 2d;
                }
                else // x == 0
                {
                    result = dreal.ndis(-delta);
                    // result = boost2.dist_normal(-delta, 0, 1, 2)
                }
            }
            if (invert)
                result = 1d - result;
            return result;
        }


        public static double non_central_t2_p(double v, double delta, double x, double y, double init_val)
        {
            int max_iter = 1000000; // policies::get_max_series_iterations<Policy>()
            double errtol = 0.000000000000001d; // boost::math::policies::get_epsilon<T, Policy>()

            double d2 = delta * delta / 2d;

            // k is the starting point for iteration, And Is the
            // maximum of the poisson weighting term,
            // note that unlike other similar code, we do not set
            // k to zero, when l2 Is small, as forward iteration
            // is unstable
            int k = Convert.ToInt32(Math.Round(d2));
            if (k == 0)
                k = 1;
            double pois;
            if (k == 0)
                k = 1;
            // Forwards and backwards Poisson weights:
            pois = dreal.real_gamma_p_prime(k + 1, d2) * dreal.real_gamma_delta_ratio(k + 1, 0.5d) * delta / Math.Sqrt(2d);

            // pois = boost2.gamma_p_derivative((k + 1), d2) _
            // * boost2.gamma_delta_ratio(k + 1, 0.5) _
            // * delta / Math.Sqrt(2)

            if (pois == 0d)
                return init_val;
            double xterm = 0.0, beta;
            // Recurrance & starting beta terms:
            if (x < y)
            {
                beta = ibeta_imp(k + 1, v / 2d, x, false, true, ref xterm);
            }
            else
            {
                beta = ibeta_imp(v / 2d, k + 1, y, true, true, ref xterm);
            }
            xterm *= y / (v / 2d + k);
            double poisf = pois;
            double betaf = beta;
            double xtermf = xterm;
            double sum = init_val;
            if (beta == 0d & xterm == 0d)
            {
                return init_val;
            }

            // Backwards recursion first, this is the stable
            // direction for recursion:
            double last_term = 0d;
            int count = 0;
            for (int i = k; i >= 0; i -= 1)
            {
                double term = beta * pois;
                sum += term;
                // Don't terminate on first term in case we "fixed" k above:
                if (Math.Abs(last_term) >= Math.Abs(term) & Math.Abs(term / sum) < errtol)
                {
                    break; // break
                }
                last_term = term;
                pois *= (i + 0.5d) / d2;
                beta += xterm;
                xterm *= i / (x * (v / 2d + i - 1d));
                count = count + 1;
            }

            // Now forward recursion
            last_term = 0d;
            for (int i = k + 1, loopTo = max_iter; i <= loopTo; i++)
            {
                poisf *= d2 / (i + 0.5d);
                xtermf *= x * (v / 2d + i - 1d) / i;
                betaf -= xtermf;
                double term = poisf * betaf;
                sum += term;
                if (Math.Abs(last_term) >= Math.Abs(term) & Math.Abs(term / sum) < errtol)
                {
                    break; // break
                }
                last_term = term;
                count = count + 1;

                // Error check:
                if (count >= max_iter)
                {
                    Console.WriteLine("cdf(non_central_t_distribution) Series did not converge, closest value was {0}", sum);
                    return sum;
                }
            }
            return sum;

        }


        public static double non_central_t2_q(double v, double delta, double x, double y, double init_val)
        {
            int max_iter = 1000000; // policies::get_max_series_iterations<Policy>()
            double errtol = 0.000000000000001d; // boost::math::policies::get_epsilon<T, Policy>()

            double d2 = delta * delta / 2d;

            // k Is the starting point for iteration, And Is the
            // maximum of the poisson weighting term, we don't allow
            // k == 0 as this can cause catastrophic cancellation errors
            // (test case Is v = 561908036470413.25, delta = 0.056190803647041321,
            // x = 1.6155232703966216)

            int k = Convert.ToInt32(Math.Round(d2));
            if (k == 0)
                k = 1;
            // Starting Poisson weight:
            double pois;
            // Forwards and backwards Poisson weights:
            pois = dreal.real_gamma_p_prime(k + 1, d2) * dreal.real_gamma_delta_ratio(k + 1, 0.5d) * delta / Math.Sqrt(2d);

            // pois = boost2.gamma_p_derivative((k + 1), d2) _
            // * boost2.gamma_delta_ratio(k + 1, 0.5) _
            // * delta / Math.Sqrt(2)
            if (pois == 0d)
                return init_val;
            double xterm = 0.0, beta;
            // Recurrance & starting beta terms:
            if (x < y)
            {
                beta = ibeta_imp(k + 1, v / 2d, x, false, true, ref xterm);
            }
            else
            {
                beta = ibeta_imp(v / 2d, k + 1, y, true, true, ref xterm);
            }
            xterm *= y / (v / 2d + k);
            double poisf = pois;
            double betaf = beta;
            double xtermf = xterm;
            double sum = init_val;
            if (beta == 0d & xterm == 0d)
            {
                return init_val;
            }

            // Fused forward And backwards recursion
            double last_term = 0d;
            int count = 0;
            int j = k + 1;
            for (int i = k + 1, loopTo = max_iter; i <= loopTo; i++)
            {
                j = j - 1;
                poisf *= d2 / (i + 0.5d);
                xtermf *= x * (v / 2d + i - 1d) / i;
                betaf += xtermf;
                double term = poisf * betaf;

                if (j >= 0)
                {
                    term += beta * pois;
                    pois *= (j + 0.5d) / d2;
                    beta -= xterm;
                    xterm *= j / (x * (v / 2d + j - 1d));
                }

                sum += term;
                // Don't terminate on first term in case we "fixed" k above:
                if (Math.Abs(last_term) >= Math.Abs(term) & Math.Abs(term / sum) < errtol)
                {
                    break; // break
                }
                last_term = term;
                // Error check:
                if (count >= max_iter)
                {
                    Console.WriteLine("cdf(non_central_t_distribution) Series did not converge, closest value was {0}", sum);
                    return sum;
                }
                count = count + 1;
            }
            return sum;

        }




        public static double tdisn(double F, double t, double d, ref double LeftTail, ref double RightTail)
        {
            double tdisnRet = 0.0;
            const double sqrtpi = 1.77245385090552d;
            var S = new double[2];
            double a;
            double b;
            double y;
            double X;
            double z;
            double h;
            double g;
            double k;
            double r;
            double ss;
            double ak;
            double C;
            double pk0;
            double pk1;
            double pk2; // , lnB As Double
            int i;
            bool fit;
            if (d == 0d)
            {
                tdisnRet = DistMain.tdis(F, t, ref LeftTail, ref RightTail);
                return tdisnRet;
            }
            fit = true;
            if (t > 0d)
            {
                fit = false;
                t = -t;
                d = -d;
            }
            a = t / Math.Sqrt(F);
            b = F / (F + t * t);
            y = d * Math.Sqrt(b / 2d) / sqrtpi;
            X = d * d * b / 2d;
            z = a * a * b;
            h = DistMain.ndis(-d * Math.Sqrt(b));
            g = Math.Exp(-DistMain.Lnbeta(F / 2d, 1d / 2d));
            ak = 1d;
            C = 0.5d;
            for (i = 0; i <= 1; i++)
            {
                k = 0d;
                S[i] = 0d;
                pk2 = 1d;
                pk1 = 0d;
                do
                {
                    S[i] = S[i] + ak * pk2;
                    pk0 = pk1;
                    pk1 = pk2;
                    ss = k + C;
                    pk2 = pk1 * (1d + (k - X) / ss) - pk0 * k / ss;
                    k = k + 1d;
                    r = 2d * k;
                    if (i == 0)
                    {
                        ak = ak * z * (r - F) * (r - 1d) / (r * (r + 1d));
                    }
                    else
                    {
                        ak = ak * z * (r + 1d - F) / (r + 2d);
                    }
                }
                while (S[i] != S[i] + ak * pk2);
                ak = z * (1d - F) / 2d;
                C = 1.5d;
            }
            h = h + (g * a * Math.Sqrt(b) * S[0] - y * S[1]) * Math.Exp(-X);
            if (h < 0d)
                h = 0d;
            if (h > 1d)
                h = 1d;
            LeftTail = h;
            RightTail = 1d - h;
            if (!fit)
            {
                RightTail = h;
                LeftTail = 1d - h;
            }
            return LeftTail;
        }




        public static void tdisnOwen_Combined(long n, double t, double d, ref double PDF, ref double CDF)
        {
            double F0;
            double f2;
            var LeftTail = default(double);
            var RightTail = default(double);
            F0 = TdisnOwen(n, t, d, ref LeftTail, ref RightTail);
            f2 = TdisnOwen(n + 2L, t * Math.Sqrt(1d + 2d / n), d, ref LeftTail, ref RightTail);
            CDF = F0;
            PDF = n / t * (f2 - F0);
        }


        public static double TdisnOwen(long n, double X, double d, ref double LeftTail, ref double RightTail)
        {
            const double h = 0.797884560802866d; // H = 2 / Sqrt(2 * Pi)
            double a;
            double b;
            double b2;
            long k;
            long i;
            long j;
            double C;
            double C0;
            double C1;
            double g;
            double F;
            a = X / Math.Sqrt(n);
            b2 = 1d / (1d + a * a);
            b = Math.Sqrt(b2);
            k = n % 2L;
            if (k == 0L)
                F = DistMain.ndis(-d);
            else
                F = DistMain.ndis(-d * b) + 2d * dreal.owen_t(d * b, a);
            // If k = 0 Then F = ndis(-d) Else F = ndis(-d * b) + 2 * boost2.owens_t(d * b, a)

            if (n > 1L)
            {
                C0 = a * b * DistMain.ndis(d * a * b) * Math.Exp(-0.5d * d * d * b2);
                C1 = a * b2 * (d * C0 + 0.5d * Math.Exp(-0.5d * d * d) * h);
                if (k == 0L)
                    F = F + C0;
                else
                    F = F + h * C1;
                g = 1d;
                i = 2L;
                while (!(i >= n - k))
                {
                    for (j = 1L; j <= 2L; j++)
                    {
                        C = b2 * (1d - 1d / i) * (a * g * d * C1 + C0);
                        C0 = C1;
                        C1 = C;
                        i = i + 1L;
                        g = 1d / (g * (i - 2L));
                    }
                    if (k == 0L)
                        F = F + C0;
                    else
                        F = F + h * C1;
                }
            }
            LeftTail = F;
            RightTail = 1d - F;
            return F;
        }


        public static double tdisn_delta_approx(bool IsGLM, double Df2, double t, double beta)
        {
            double delta;
            if (IsGLM)
            {
                // Algorithm by Akahira (1995)
                double k;
                double bn;
                double a;
                double u;
                double b;
                double c;
                double nn = Df2;
                bn = Math.Sqrt(2d / nn) * Math.Exp(DistMain.LnGamma((nn + 1d) / 2d) - DistMain.LnGamma(nn / 2d));
                k = 1d + (1d - bn * bn) * t * t;
                a = t * t * t * (1d / (nn * nn) + 1d / (4d * nn * nn * nn)) / (24d * k);
                b = -Math.Sqrt(k);
                c = bn * t - a;
                u = DistX.ndisx(beta, 1d - beta);
                delta = a * u * u + b * u + c;
            }
            else
            {
                // Algorithm by Winterbottom (1980)
                double r = t / Math.Sqrt(t * t + Df2);
                double rho = Rhodis_NC(beta, 1d - beta, Df2 + 2d, r);
                delta = rho * Math.Sqrt(Df2 / (1d - rho * rho));
            }
            Console.WriteLine("delta: {0}", delta);
            return delta;
        }


        public static void demo_tdisn_delta()
        {
            var LeftTail = default(double);
            var Righttail = default(double);
            double t;

            bool IsGLM = true;
            bool IsExact = false;
            int Df2 = 20;
            int omega = 0;
            double alpha = 0.01d;
            double beta = 0.03d; // Beta must be < 1-alpha
            double LogBeta = Math.Log(beta);
            Console.WriteLine();

            t = DistX.Tdisx(1d - alpha, alpha, Df2);
            Console.WriteLine("t: {0}", t);
            double delta = tdisn_delta_approx(IsGLM, Df2, t, beta);

            double x1 = t;
            double lambda_x1 = delta;
            TDisnOrRhoSquareDis(IsExact, IsGLM, Df2, x1, lambda_x1, omega, ref LeftTail, ref Righttail);
            double fx1 = LeftTail;
            Console.WriteLine("lambda_x1: {0}, fx1: {1}", lambda_x1, fx1);

            double lnPower = Math.Log(LeftTail);
            double L1 = lambda_x1;
            double L2 = L1;
            double LSign = 0.0d;
            double F_L1 = LogBeta - lnPower;
            double F_L2 = F_L1;
            if (F_L1 > 0d)
                LSign = -1;
            else
                LSign = 1d;
            double Factor = 0.2d;
            double LStep = Math.Abs(delta) * Factor;
            Console.WriteLine("L1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L1, LeftTail, lnPower, F_L1);
            do
            {
                L1 = L2;
                F_L1 = F_L2;
                L2 = L1 + LStep * LSign;
                TDisnOrRhoSquareDis(IsExact, IsGLM, Df2, x1, L2, omega, ref LeftTail, ref Righttail);
                lnPower = Math.Log(LeftTail);
                F_L2 = LogBeta - lnPower;
                Console.WriteLine("L2: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L2, LeftTail, lnPower, F_L2);
                Factor = Factor + 0.2d;
                LStep = Math.Abs(delta) * Factor;
            }
            while (F_L2 * LSign <= 0d);

            DemoBrentDelta(IsExact, IsGLM, ref L1, ref L2, F_L1, F_L2, x1, LogBeta, 0d, Df2, omega);

        }


        public static double T_New_Lambda(bool IsExact, bool IsGLM, double L2, double x1, double LogBeta, double Df1, double Df2, double omega)
        {
            double lnPower;
            var LeftTail = default(double);
            var Righttail = default(double);
            TDisnOrRhoSquareDis(IsExact, IsGLM, Df2, x1, L2, omega, ref LeftTail, ref Righttail);
            // FDisnByRhoSquareDis(IsExact, IsGLM, Df1, Df2, x1, L2, omega, LeftTail, Righttail)
            lnPower = Math.Log(LeftTail);
            return LogBeta - lnPower;
        }


        public static void DemoBrentDelta(bool IsExact, bool IsGLM, ref double a, ref double b, double fa, double fb, double x1, double LogBeta, double Df1, double Df2, double omega)
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
            var m = default(double);
            long iter;
            long maxiter;
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
                // Function
                fb = T_New_Lambda(IsExact, IsGLM, b, x1, LogBeta, Df1, Df2, omega);
                Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            }

        Finish:
            ;

            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            xs = b;
        }



        public static double tdix_approx(bool IsGLM, double LeftTail, double RightTail, double n, double d)
        {
            double t;
            double z = DistX.ndisx(LeftTail, RightTail);
            if (IsGLM & d <= 0d)
            {
                t = z + d;
            }
            else
            {
                double rho = d / Math.Sqrt(d * d + n);
                Console.WriteLine("rho: {0}", rho);
                double r = Rhodisx_W(LeftTail, RightTail, n + 2d, rho);
                Console.WriteLine("r_alpha W, r: {0}, 1 - r: {1}, LeftTail: {2}, Righttail: {3}", r, 1d - r, LeftTail, RightTail);
                t = r * Math.Sqrt(n / (1d - r * r));
                Console.WriteLine("T_r: {0}", t);
            }
            return t;
        }

        public static void demo_tdisnx()
        {
            // Dim LeftTail As Double, Righttail As Double, n As Double, d As Double
            double RefTail;
            bool IsGLM = true;
            bool IsExact = false;
            double LeftTail = 0.99d;
            double Righttail = 1d - LeftTail;
            int n = 20;
            int d = 288;
            int omega = 0;

            if (LeftTail < 0.5d)
                RefTail = LeftTail;
            else
                RefTail = Righttail;
            double LogBeta = Math.Log(LeftTail);
            double x1 = tdix_approx(IsGLM, LeftTail, Righttail, n, d);
            TDisnOrRhoSquareDis(IsExact, IsGLM, n, x1, d, omega, ref LeftTail, ref Righttail);
            double fx1 = LeftTail;
            Console.WriteLine("x1: {0}, fx1: {1}", x1, fx1);


            double lnPower = Math.Log(LeftTail);
            double L1 = x1;
            double L2 = L1;
            double LSign = 0.0d;
            double F_L1 = LogBeta - lnPower;
            double F_L2 = F_L1;
            if (F_L1 > 0d)
                LSign = +1;
            else
                LSign = -1;
            double Factor = 0.1d;
            double LStep = x1 * Factor;
            Console.WriteLine("L1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L1, LeftTail, lnPower, F_L1);

            do
            {
                L1 = L2;
                F_L1 = F_L2;
                L2 = L1 + LStep * LSign;
                TDisnOrRhoSquareDis(IsExact, IsGLM, n, L2, d, omega, ref LeftTail, ref Righttail);
                lnPower = Math.Log(LeftTail);
                F_L2 = LogBeta - lnPower;
                Console.WriteLine("L2: {0}, LeftTail: {1}, lnPower: {2}, F_L2: {3}", L2, LeftTail, lnPower, F_L2);
                Factor = Factor + 0.1d;
                LStep = x1 * Factor;
            }
            while (F_L2 * LSign >= 0d);

            Quantile_T_Brent(IsExact, IsGLM, ref L1, ref L2, F_L1, F_L2, d, LogBeta, 1.0d, n, omega);

        }



        public static double Quantile_T_Func(bool IsExact, bool IsGLM, double x1, double t1, double LogBeta, double Df1, double Df2, double omega)
        {
            double lnPower;
            var LeftTail = default(double);
            var Righttail = default(double);
            TDisnOrRhoSquareDis(IsExact, IsGLM, Df2, x1, t1, omega, ref LeftTail, ref Righttail);
            lnPower = Math.Log(LeftTail);
            return LogBeta - lnPower;
        }


        public static void Quantile_T_Brent(bool IsExact, bool IsGLM, ref double a, ref double b, double fa, double fb, double t1, double LogBeta, double Df1, double Df2, double omega)
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
            var m = default(double);
            long iter;
            long maxiter;
            // eps = 0.00000000000001
            eps = 0.0000001d;
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
                // Function
                fb = Quantile_T_Func(IsExact, IsGLM, b, t1, LogBeta, Df1, Df2, omega);
                Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            }

        Finish:
            ;

            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            xs = b;
        }


        public static double tdisn_samplesize_approx(bool IsGLM, double alpha, double Beta, double effect_size)
        {
            double za;
            double zb;
            double a;
            double b;
            double c;
            double d;
            double p;
            double k;
            double x;
            double n;
            za = DistX.ndisx(1d - alpha, alpha);
            zb = DistX.ndisx(Beta, 1d - Beta);
            if (IsGLM)
            {
                // approximation derived from van Eden
                double r = effect_size;
                a = 4d * r;
                b = 4d * (zb - za) + r * r * zb;
                c = r * (zb * zb + 1d);
                d = zb * zb * zb + zb - (za * za * za + za);
                b = b / a;
                c = c / a;
                d = d / a;
                d = d + b * c / 3d - 2d * b * b * b / 27d;
                c = c - b * b / 3d;
                p = 12d * c * c * c + 81d * d * d; // revise if negative
                p = Math.Sqrt(Math.Abs(p)); // revise if negative
                k = 108d * d + 12d * p;
                k = Math.Pow(Math.Abs(k), 1d / 3d);
                x = k / 6d - 2d * c / k - b / 3d;
                n = Math.Round(x * x);
            }
            else
            {
                double e2 = effect_size * effect_size;
                double rho = Math.Sqrt(e2 / (1d + e2));
                a = 0.5d * Math.Log((1d + rho) / (1d - rho));
                b = zb - za;
                c = rho / 2d;
                x = -(b / (2d * a)) + 1d / (2d * a) * Math.Sqrt(b * b - 4d * a * c);
                n = Math.Round(2d + x * x);
            }
            return n;
        }


        public static void demo_tdisn_samplesize()
        {
            double alpha;
            double Beta;
            double LeftTail = 0.0, RightTail = 0.0, FSign, Factor;
            bool IsExact = false;
            bool IsGLM = true;

            alpha = 0.000000005d; // Type 1 error
            Beta = 0.00000001d;  // Type 2 error
            double effect_size = 1.57d; // effect_size = mu/sigma = rho/sqrt(1-rho^2)
            int omega = 0;
            double LogBeta = Math.Log(Beta);

            double Df2 = tdisn_samplesize_approx(IsGLM, alpha, Beta, effect_size);
            double n = Df2;
            Console.WriteLine("sample size: {0}", Df2);
            // Dim x1 = dreal.dist_qt(alpha, Df2, False)
            // Dim x1 = boost2.dist_student_t(alpha, Df2, 6)
            double x1 = dreal.dist_student_t(Df2).qtf(alpha);
            Console.WriteLine("t: {0}", x1);
            TDisnOrRhoSquareDis(IsExact, IsGLM, Df2, x1, Math.Sqrt(Df2) * effect_size, omega, ref LeftTail, ref RightTail);

            double lnPower = Math.Log(LeftTail);

            double N1 = Df2;
            double N2 = N1;
            double F_n1 = LogBeta - lnPower;
            double F_n2 = F_n1;
            if (F_n1 > 0d)
                FSign = -1;
            else
                FSign = 1d;
            Factor = 0.2d;
            double FStep = Df2 * Factor;
            if (FStep < 2d)
                FStep = 2d;
            Console.WriteLine("n1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", n, LeftTail, lnPower, F_n1);
            do
            {
                N1 = N2;
                F_n1 = F_n2;
                N2 = N1 + FStep * FSign;
                // x1 = dreal.dist_qt(alpha, N2, False)
                // x1 = boost2.dist_student_t(alpha, N2, 6)
                x1 = dreal.dist_student_t(N2).qtf(alpha);
                TDisnOrRhoSquareDis(IsExact, IsGLM, N2, x1, Math.Sqrt(N2) * effect_size, omega, ref LeftTail, ref RightTail);
                lnPower = Math.Log(LeftTail);
                F_n2 = LogBeta - lnPower;
                Console.WriteLine("n2: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", N2, LeftTail, lnPower, F_n2);
            }
            while (F_n2 * FSign <= 0d);

            BrentSampleSizeT(IsExact, IsGLM, ref N1, ref N2, F_n1, F_n2, alpha, LogBeta, 0d, effect_size, omega);

            double Final_N2 = Math.Round(N2) + 1 * 0;
            Console.WriteLine("Final_N2 size: {0}", Final_N2);
            TDisnOrRhoSquareDis(true, IsGLM, Final_N2, x1, Math.Sqrt(Final_N2) * effect_size, omega, ref LeftTail, ref RightTail);
            Console.WriteLine("LeftTail: {0}", LeftTail);
            Final_N2 = Final_N2 + 4d;
            Console.WriteLine("Final_N2 size: {0}", Final_N2);
            TDisnOrRhoSquareDis(true, IsGLM, Final_N2, x1, Math.Sqrt(Final_N2) * effect_size, omega, ref LeftTail, ref RightTail);
            Console.WriteLine("LeftTail: {0}", LeftTail);
        }


        public static double T_New_SampleSize(bool IsExact, bool IsGLM, double N2, double alpha, double LogBeta, double m, double r, double omega)
        {
            double x1;
            double lnPower;
            var LeftTail = default(double);
            var Righttail = default(double);
            // x1 = dreal.dist_qt(alpha, N2, False)
            // x1 = boost2.dist_student_t(alpha, N2, 6)
            x1 = dreal.dist_student_t(N2).qtf(alpha);
            TDisnOrRhoSquareDis(IsExact, IsGLM, N2, x1, Math.Sqrt(N2) * r, omega, ref LeftTail, ref Righttail);
            lnPower = Math.Log(LeftTail);
            return LogBeta - lnPower;
        }


        public static void BrentSampleSizeT(bool IsExact, bool IsGLM, ref double a, ref double b, double fa, double fb, double alpha, double LogBeta, double m1, double r_, double omega)
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
            var m = default(double);
            long iter;
            long maxiter;
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
                // Function
                fb = T_New_SampleSize(IsExact, IsGLM, b, alpha, LogBeta, m1, r_, omega);
                Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            }

        Finish:
            ;

            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            xs = b;
        }



        public static void demo_tdis()
        {
            demo_tdisn_samplesize();
            demo_tdisn_delta();
            demo_tdisnx();
        }


        #endregion









        // **********************************************************************
        // Doubly noncentral F cdf
        // '**********************************************************************

        #region DoublyNoncentralF


        public static void Fdisn_Doubly_nc(double N1, double n2, double F, double Theta1, double Theta2, ref double left, ref double Right)
        {
            double l2;
            double q;
            double x;
            double sum;
            long k;
            double summand;
            double RelError;
            double Result;
            double y;
            double a;
            double b;
            var l = default(double);
            var r = default(double);
            l2 = Theta2 / 2d;
            q = 1d;
            x = N1 * F / (n2 + N1 * F);
            y = n2 / (N1 * F + n2);
            a = N1 / 2d;
            b = n2 / 2d;
            Betadisn(a, b, x, y, Theta1, ref l, ref r);
            sum = l;
            k = 0L;
            // Console.WriteLine("sum0: {0}", sum)
            do
            {
                k = k + 1L;
                q = q * l2 / k;
                Betadisn(a, b + k, x, y, Theta1, ref l, ref r);
                summand = q * l;
                sum = sum + summand;
                RelError = summand / sum;
            }
            // Console.WriteLine("k: {0}, sum: {1}, summand: {2}, RelError: {3}", k, sum, summand, RelError)
            while (Math.Abs(RelError) >= 0.00000000000001d);
            // Console.WriteLine("k: {0}, sum: {1}, summand: {2}, RelError: {3}", k, sum, summand, RelError)

            Result = Math.Exp(-l2) * sum;
            left = Result;
            Right = 1d - left;
        }


        public static void FdisNCalcSaddlepoint(ref double S, double N1, double N2, double F, double t1, double t2)
        {
            const double Pi = 3.14159265358979d;
            double f2;
            double n22;
            double n12;
            double a;
            double a0;
            double A1;
            double A2;
            double Q;
            double p;

            f2 = F * F;
            n22 = N2 * N2;
            n12 = N1 * N1;

            if (t1 * t2 != 0d)
            {
                a = 1d / (8d * f2 * n22 * (N1 + N2));
                a0 = (F * t2 * n12 - (1d - F) * n12 * N2 - N1 * N2 * t1) * a;
                A1 = (2d * (n22 * N1 + n12 * N2 * f2) - 4d * F * N1 * N2 * (N1 + N2 + t1 + t2)) * a;
                A2 = (8d * F * (1d - F) * N1 * n22 + 4d * F * (N2 * n22 + t2 * n22 - n12 * N2 * F - N1 * N2 * t1 * F)) * a / 3d;
                p = Math.Sqrt(Math.Abs(A1 - 3d * A2 * A2) / 3d);
                Q = A2 * (2d * A2 * A2 - A1) + a0;
                S = -2 * p * Math.Cos((Math.Acos(-Q / (2d * p * p * p)) + Pi) / 3d) - A2;
            }
            else if (t1 > 0d)
            {
                p = f2 * N1 * n12 + 2d * f2 * n12 * t1 + 2d * n12 * F * N2 + 4d * f2 * N1 * N2 * t1 + N1 * t1 * t1 * f2 + 2d * N1 * t1 * F * N2 + n22 * N1 + 4d * F * n22 * t1;
                S = (F * N1 * (N1 + 2d * N2 + t1) - N1 * N2 - Math.Sqrt(N1 * p)) / (4d * N2 * F * (N1 + N2));
            }
            else
            {
                S = N1 * (F - 1d) / (2d * F * (N1 + N2));
            }



        }



        public static void FdisNCalcSaddlepointCum(double S, double N1, double N2, double F, double t1, double t2, ref double k, ref double k1, ref double k2, ref double k3, ref double k4, ref double w, ref double U)
        {

            double l1;
            double l2;
            double v1;
            double v2;
            double g1;
            double g2;
            double H1;
            double h2;
            double g12;
            double g22;
            l1 = N2 / N1;
            l2 = -F;
            v1 = 1d / (1d - 2d * S * l1);
            v2 = 1d / (1d - 2d * S * l2);
            g1 = l1 * v1;
            g2 = l2 * v2;
            H1 = t1 * v1;
            h2 = t2 * v2;
            g12 = g1 * g1;
            g22 = g2 * g2;

            k = 0.5d * (N1 * Math.Log(v1) + N2 * Math.Log(v2)) + S * (t1 * g1 + t2 * g2);
            k1 = g1 * (N1 + H1) + g2 * (N2 + h2);
            k2 = 2d * (g12 * (N1 + 2d * H1) + g22 * (N2 + 2d * h2));
            k3 = 8d * (g1 * g12 * (N1 + 3d * H1) + g2 * g22 * (N2 + 3d * h2));
            k4 = 48d * (g12 * g12 * (N1 + 4d * H1) + g22 * g22 * (N2 + 4d * h2));

            U = S * Math.Sqrt(k2);
            w = Math.Sign(S) * Math.Sqrt(2d * (S * k1 - k));

            // Debug.Print "K1: ", k1
            // Debug.Print "s: ", S
            double C;
            double f2;
            double a;
            double b;
            double Q;
            if (t2 == 0d)
            {
                // Console.WriteLine("Linear")
                C = -(g1 * (N1 + H1)) / N2;
                f2 = -C / (1d + 2d * S * C);
            }
            // Console.WriteLine("F2: {0}", f2)
            else
            {
                // Console.WriteLine("Quadratic")
                C = -(g1 * (N1 + H1));
                a = 4d * C * S * S + 2d * S * N2;
                b = -(4d * C * S + t2 + N2);
                Q = Math.Sqrt(b * b - 4d * a * C) / (2d * a);
                // Console.WriteLine("F1: {0}", -(b / (2 * a)) + Q, -(b / (2 * a)) - Q)
                f2 = a * (l2 * l2) + b * l2 + C;
            }

        }



        public static void FdisnPaolella(double N1, double N2, double F, double t1, double t2, ref double density, ref double LeftTail, ref double RightTail)
        {
            var S = default(double);
            var w = default(double);
            var U = default(double);
            var k = default(double);
            var k1 = default(double);
            var k2 = default(double);
            var k3 = default(double);
            var k4 = default(double);

            FdisNCalcSaddlepoint(ref S, N1, N2, F, t1, t2);
            FdisNCalcSaddlepointCum(S, N1, N2, F, t1, t2, ref k, ref k1, ref k2, ref k3, ref k4, ref w, ref U);
            DistMain.LugannaniRice(w, U, k2, k3, k4, ref density, ref LeftTail, ref RightTail);
            // Call Jensen(w, U)
        }





        public static void DoublyFdisn_Paolella_Combined(double N1, double n2, double F, double t1, double t2, ref double density, ref double LeftTail, ref double Righttail)
        {
            const double eps = 0.1d;
            double sx;
            var density1 = default(double);
            var lefttail1 = default(double);
            var RightTail1 = default(double);
            var Density2 = default(double);
            var LeftTail2 = default(double);
            var RightTail2 = default(double);
            sx = (1d + t1 / N1) / (1d + t2 / n2);
            if (Math.Abs(F - sx) > eps)
            {
                FdisnPaolella(N1, n2, F, t1, t2, ref density, ref LeftTail, ref Righttail);
                return;
            }
            Console.WriteLine("Double");
            FdisnPaolella(N1, n2, sx - eps, t1, t2, ref density1, ref lefttail1, ref RightTail1);
            FdisnPaolella(N1, n2, sx + eps, t1, t2, ref Density2, ref LeftTail2, ref RightTail2);
            density = density1 + (Density2 - density1) * (eps + F - sx) / (2d * eps);
            LeftTail = lefttail1 + (LeftTail2 - lefttail1) * (eps + F - sx) / (2d * eps);
            Righttail = RightTail1 + (RightTail2 - RightTail1) * (eps + F - sx) / (2d * eps);
        }





        public static void DemoDoublyFdisn()
        {
            double N1;
            double n2;
            double F;
            double t1;
            double t2;
            //double eps;
            var l = default(double);
            var rt = default(double); // , rt2 As Double , rt3 As Double
            var density = default(double);
            var LeftTail = default(double);
            var Righttail = default(double);
            N1 = 1d;
            n2 = 72d;
            F = 14.5d;
            t1 = 10d;
            t2 = 10d;
            //eps = 0.0000001d;
            DoublyFdisn_Paolella_Combined(N1, n2, F, t1, t2, ref density, ref LeftTail, ref Righttail);
            Console.WriteLine("L3:   {0}, R: {1}:", LeftTail, Righttail);
            Fdisn_Doubly_nc(N1, n2, F, t1, t2, ref l, ref rt);
            Console.WriteLine("L_:   {0}, R: {1}:", l, rt);
            Console.WriteLine("Density: {0}:", density);

        }




        #endregion






        // **********************************************************************
        // Doubly noncentral t cdf
        // '**********************************************************************

        #region DoublyNoncentralT


        public static void TDistDoublyNC_Broda_Combined(double n, double y1, double mu, double theta, ref double PDF, ref double CDF)
        {
            double y13;
            double y14;
            double N2;
            double nu;
            double alpha;
            double t2;
            double Q;
            double r;
            double a;
            double C1;
            double c2;
            double C0;
            double y12;
            double y2;
            double t1;
            double d;
            double U;
            double w;
            y12 = y1 * y1;
            // Console.WriteLine("y1: {0}", y1)
            if (theta != 0d)
            {
                y13 = y12 * y1;
                y14 = y12 * y12;
                N2 = n * n;
                a = y14 + 2d * n * y12 + N2;
                c2 = (-2 * y13 * mu - 2d * y1 * n * mu) / a;
                C1 = (y12 * mu * mu - n * y12 - N2 - theta * n) / a;
                C0 = y1 * n * mu / a;
                Q = C1 / 3d - c2 * c2 / 9d;
                r = (C1 * c2 - 3d * C0) / 6d - c2 * c2 * c2 / 27d;
                y2 = Math.Sqrt(-4 * Q) * Math.Cos(1d / 3d * Math.Acos(r / Math.Sqrt(-Q * Q * Q))) - c2 / 3d;
                t1 = -mu + y1 * y2;
                t2 = -y1 * t1 / (2d * n * y2);
                nu = 1d / (1d - 2d * t2);
                alpha = mu / Math.Sqrt(1d + theta / n);
                d = 1d / (t1 * y2);
                U = Math.Sqrt((y12 + 2d * n * t2) * (2d * n * nu * nu + 4d * theta * nu * nu * nu) + 4d * N2 * y2 * y2) / (2d * n * y2 * y2);
                w = Math.Sqrt(-mu * t1 - n * Math.Log(nu) - 2d * theta * nu * t2) * Math.Sign(y1 - alpha);
            }
            else if (mu != 0d)
            {
                y2 = (mu * y1 + Math.Sqrt(4d * n * (y12 + n) + mu * mu * y12)) / (2d * (y12 + n));
                t1 = -mu + y1 * y2;
                t2 = -y1 * t1 / (2d * n * y2);
                d = 1d / (t1 * y2);
                U = Math.Sqrt((mu * y1 * y2 + 2d * n) / (2d * n)) / y2;
                w = Math.Sqrt(-mu * t1 - 2d * n * Math.Log(y2)) * Math.Sign(y1 - mu);
            }
            else
            {
                y2 = Math.Sqrt(n / (y12 + n));
                d = 1d / (y1 * y2 * y2);
                U = 1d / y2;
                w = Math.Sqrt(-2 * n * Math.Log(y2)) * Math.Sign(y1);
            }
            CDF = DistMain.ndis(w) + DistMain.ndens(w) * (1d / w - d / U);
            PDF = DistMain.ndens(w) * (1d / U);
        }


        public static void TDisN_Broda_Combined(double n, double t, double mu, double theta, ref double PDF, ref double LeftTail, ref double RightTail)
        {
            const double eps = 0.001d;
            double sx, CDF = 0.0;
            var PDF1 = default(double);
            var cdf1 = default(double);
            var PDF2 = default(double);
            var cdf2 = default(double);
            sx = mu / Math.Sqrt(1d + theta / n);
            if (Math.Abs(t - sx) > eps)
            {
                TDistDoublyNC_Broda_Combined(n, t, mu, theta, ref PDF, ref CDF);
            }
            else
            {
                TDistDoublyNC_Broda_Combined(n, sx - eps, mu, theta, ref PDF1, ref cdf1);
                TDistDoublyNC_Broda_Combined(n, sx + eps, mu, theta, ref PDF2, ref cdf2);
                PDF = PDF1 + (PDF2 - PDF1) * (eps + t - sx) / (2d * eps);
                CDF = cdf1 + (cdf2 - cdf1) * (eps + t - sx) / (2d * eps);
            }
            LeftTail = CDF;
            RightTail = 1d - CDF;
        }



        public static void Tdis_Doubly_nc(double n, double t, double mu, double theta, ref double left, ref double Right)
        {
            double t2;
            double F;
            double sum;
            double summand;
            double RelError;
            double Result;
            var l = default(double);
            var r = default(double);
            long i;
            double s;
            var LeftTail = default(double);
            var RightTail = default(double);
            t2 = theta / 2d;
            F = 1d;
            i = 0L;
            sum = tdisn(n, t, mu, ref LeftTail, ref RightTail);
            // Console.WriteLine("sum0: {0}", sum)
            do
            {
                i = i + 1L;
                F = F * t2 / i;
                s = Math.Sqrt((n + 2L * i) / n);
                summand = F * tdisn(n + 2L * i, s * t, mu, ref l, ref r);
                sum = sum + summand;
                RelError = summand / sum;
            }
            // Console.WriteLine("i: {0}, summand: {1}, RelError: {2}", i, summand, RelError)
            while (Math.Abs(RelError) >= 0.000001d);
            Console.WriteLine("i: {0}, RelError: {1}", i, RelError);
            Result = Math.Exp(-t2) * sum;
            left = Result;
            Right = 1d - left;
        }





        #endregion







        // **********************************************************************
        // Pearson's rho cdf
        // '**********************************************************************

        #region PearsonRho


        public static double RhoDensity(long n, double r, double rho)
        {
            double RhoDensityRet = 0.0;
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

            t = t1(n, w);
            k1 = (n - 2L) / Math.Sqrt(2d * Pi) * Math.Exp(DistMain.LnGamma(n - 1L) - DistMain.LnGamma(n - 0.5d));
            ACTerm = Math.Exp(Math.Log(a) * (n - 1L) + Math.Log(C) * (n - 4L) + Math.Log(1d - X) * (1.5d - n));
            density = k1 * ACTerm * t;
            RhoDensityRet = density;
            return RhoDensityRet;

        }


        // Hypergeometric function for density of pearson's rho
        public static double t1(double n, double w)
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


        // Algorithm using finite series, Hotelling, 1953
        public static double RhoExplicit(int n, double r, double rho)
        {
            double RhoExplicitRet = 0.0;
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
                    RhoExplicitRet = result;
                    return RhoExplicitRet;
                }
                else
                {
                }

                F[1 + k1] = result;
                result = d1 + ((x2 + 2d - 3d * Rho2) * r * C * A2 + (Rho2 - 3d + 2d * Rho2 * x2) * rho * c2 * C * U) / (2d * Pi * b2 * b2);
                if (n == 5)
                {
                    RhoExplicitRet = result;
                    return RhoExplicitRet;
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
                    RhoExplicitRet = result;
                    return RhoExplicitRet;
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
                    RhoExplicitRet = result;
                    return RhoExplicitRet;
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


            RhoExplicitRet = F[n];
            return RhoExplicitRet;
        }


        // Algorithm using infinite series, Guenther 1971
        public static void RhoDisN_Guenther(double n, double r, double rho, ref double LeftTail, ref double RightTail)
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



        // Algorithm using infinite series, Hotelling, 1953
        public static void RhoDisN_Hotelling(double n, double r, double rho, ref double LeftTail, ref double RightTail)
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



        public static void TDisnOrRhoSquareDis(bool IsExact, bool IsGLM, double df2, double t, double delta, double omega, ref double LeftTail, ref double RightTail)
        {
            if (IsGLM)
            {
                if (IsExact)
                {
                    if (omega == 0d)
                    {
                        TdisnOwen((long)Math.Round(df2), t, delta, ref LeftTail, ref RightTail);
                    }
                    else
                    {
                        // This should be replaced by T_Doubly_Noncentral_Exact later
                        var PDF = default(double);
                        TDisN_Broda_Combined(df2, t, delta, 0.0d, ref PDF, ref LeftTail, ref RightTail);
                    }
                }
                else
                {
                    var PDF = default(double);
                    TDisN_Broda_Combined(df2, t, delta, omega, ref PDF, ref LeftTail, ref RightTail);
                }
            }
            else
            {
                double r = t / Math.Sqrt(t * t + df2);
                double rho = delta / Math.Sqrt(delta * delta + df2);
                RhoDisNew(IsExact, IsGLM, df2 + 2d, r, rho, ref LeftTail, ref RightTail);
            }
        }


        public static void RhoDisNew(bool IsExact, bool IsGLM, double N, double r, double rho, ref double LeftTail, ref double RightTail)
        {
            if (IsGLM)
            {
                double delta;
                double t; // , result As Double
                t = r * Math.Sqrt((N - 2d) / (1d - r * r));
                delta = rho * Math.Sqrt((N - 2d) / (1d - rho * rho));
                if (IsExact)
                {
                    TdisnOwen((long)Math.Round(N - 2d), t, delta, ref LeftTail, ref RightTail);
                }
                else
                {
                    var PDF = default(double);
                    TDisN_Broda_Combined(N - 2d, t, delta, 0.0d, ref PDF, ref LeftTail, ref RightTail);
                }
            }
            else
            {
                double result;
                if (IsExact)
                {
                    // result = RhoExplicit(N, r, rho)
                    // LeftTail = result
                    // RightTail = 1 - LeftTail
                    RhoDisN_Guenther(N, r, rho, ref LeftTail, ref RightTail);
                }
                else
                {
                    result = Rhodis_DH(N, r, rho);
                    LeftTail = result;
                    RightTail = 1d - LeftTail;
                }
            }
        }



        // Algorithm using non-central t, N is total sample size
        public static void RhoDisN_Fixed(int N, double r, double rho, double LeftTail, double RightTail)
        {
            double delta;
            double t;
            double result;
            t = r * Math.Sqrt((N - 2) / (1d - r * r));
            delta = rho * Math.Sqrt((N - 2) / (1d - rho * rho));
            result = TdisnOwen(N - 2, t, delta, ref LeftTail, ref RightTail);

        }




        public static double zTransformInverse(double y)
        {
            double zTransformInverseRet = 0.0;
            y = Math.Exp(2d * y);
            zTransformInverseRet = (y - 1d) / (y + 1d);
            return zTransformInverseRet;
        }

        public static double zTransform(double r)
        {
            double zTransformRet = 0.0;
            zTransformRet = 0.5d * Math.Log((1d + r) / (1d - r));
            return zTransformRet;
        }

        // These approximations are sensitive to whether rho and or r are negative. Still need to figure out the details!!!

        // Algorithm for CDF, Winterbottom 1980
        public static double RhoDis_W(double n, double r, double rho)
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
            w = zTransform(r) - zTransform(rho);
            w2 = w * w;
            w3 = w2 * w;
            w5 = w2 * w3;
            y = -r / (2d * m) - (3d * r + r3) / (12d * m2);
            y = y + (1d - (1d + r2) / (4d * m) + (3d - 11d * r4) / (96d * m2)) * w;
            y = y + (3d * r - 4d * r3) / (24d * m) * w2;
            y = y - (1d / 12d - (2d + 7d * r2 - 6d * r4) / (48d * m)) * w3;
            y = y + 3d / 160d * w5;
            double x = Math.Sqrt(m) * y;
            double result = DistMain.ndis(x);
            return result;
        }

        // Algorithm for CDF, DH version, derived from Winterbottom 1980
        public static double Rhodis_DH(double N, double r, double rho)
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
            m2 = 1d / (N - 1d);
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




        // Algorithm for ICDF, Winterbottom 1980
        public static double Rhodisx_W(double LeftTail, double RightTail, double n, double rho)
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
            z = zTransform(rho);
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
            double rdisx = zTransformInverse(y);
            Console.WriteLine("rdisx: {0}", rdisx);
            return rdisx;
        }


        // Algorithm for rho (noncentrality), Winterbottom 1980
        public static double Rhodis_NC(double LeftTail, double RightTail, double N, double r)
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
            X = -DistX.ndisx(LeftTail, RightTail);
            z = zTransform(r);
            m = N - 1d;
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
            double rdis_nc = zTransformInverse(y);
            return rdis_nc;
        }


        public static void DemoRhoExplicit()
        {
            int n;
            double r;
            double rho;
            double result;
            double LeftTail, RightTail;
            double density;
            // Smallest N: N = 3
            n = 16;
            r = 0.9d;
            rho = 0.6d;
            LeftTail = 0.95d;
            RightTail = 1d - LeftTail;

            double rho1 = Rhodis_NC(LeftTail, RightTail, n, r);
            Console.WriteLine("rho: {0}", rho1);
            result = RhoExplicit(n, r, rho1);
            Console.WriteLine("result: {0}, result / LeftTail: {1}", result, result / LeftTail);
            density = RhoDensity(n, r, rho1);
            Console.WriteLine("density: {0}", density);

            Console.WriteLine("");
            double r1 = Rhodisx_W(LeftTail, RightTail, n, rho);
            Console.WriteLine("r: {0}", r1);
            result = RhoExplicit(n, r1, rho);
            Console.WriteLine("result: {0}, result / LeftTail: {1}", result, result / LeftTail);
            density = RhoDensity(n, r1, rho);
            Console.WriteLine("density: {0}", density);
        }


        #endregion








        // **********************************************************************
        // Rho2 cdf
        // '**********************************************************************


        #region Rho2

        public static double Rho2DisN8(bool IsGLM, double p, double n, double X, double Rho2)
        {
            double Rho2DisN8Ret = 0.0;
            var LeftTail = default(double);
            var RightTail = default(double);
            // p: df1=# of variables-1
            // N: df2=# of observatons - # of variables
            R2DisN(IsGLM, p, n, X, Rho2, ref LeftTail, ref RightTail);
            Rho2DisN8Ret = LeftTail;
            return Rho2DisN8Ret;
        }


        public static void R2DisN(bool IsGLM, double p, double n, double X, double Rho2, ref double LeftTail, ref double RightTail)
        {
            // p: df1=# of variables-1
            // N: df2=# of observatons - # of variables
            p = p + 1d;
            if (IsGLM)
            {
                RHO2_EXACT_I(true, X, p, n + p, Rho2, 0d, ref LeftTail, ref RightTail);
            }
            else
            {
                RHO2_EXACT(false, X, p, n + p, Rho2, ref LeftTail, ref RightTail);
            }
        }


        public static void FDisnByRhoSquareDis(bool IsExact, bool IsGLM, double df1, double df2, double F, double Lambda, double omega, ref double LeftTail, ref double RightTail)
        {
            if (IsGLM)
            {
                if (IsExact)
                {
                    if (omega == 0d)
                    {
                        // LeftTail = dreal.dist_pf_nc(F, df1, df2, Lambda, True, False)
                        // LeftTail = boost2.dist_fisher_f_nc(F, df1, df2, Lambda, 6)
                        LeftTail = dreal.dist_fisher_f_nc(df1, df2, Lambda).cdf(F);

                        // RightTail = dreal.dist_pf_nc(F, df1, df2, Lambda, False, False)
                        // RightTail = boost2.dist_fisher_f_nc(F, df1, df2, Lambda, 7)
                        RightTail = dreal.dist_fisher_f_nc(df1, df2, Lambda).sf(F);
                    }
                    else
                    {
                        // This should be replaced by F_Doubly_Noncentral_Exact later
                        var density = default(double);
                        DoublyFdisn_Paolella_Combined(df1, df2, F, Lambda, omega, ref density, ref LeftTail, ref RightTail);
                    }
                }
                else
                {
                    var density = default(double);
                    DoublyFdisn_Paolella_Combined(df1, df2, F, Lambda, omega, ref density, ref LeftTail, ref RightTail);
                }
            }
            else
            {
                double R2 = df1 * F / (df1 * F + df2);
                double Rho2 = Lambda / (Lambda + df2);
                int p = (int)Math.Round(df1 + 1d);
                RhoSquareDis(IsExact, IsGLM, p, df2 + df1 + 1d, R2, Rho2, omega, ref LeftTail, ref RightTail);
            }
        }



        public static void RhoSquareDis(bool IsExact, bool IsGLM, int p, double N, double R2, double Rho2, double omega, ref double LeftTail, ref double RightTail)
        {
            // p: # of variables
            // N: # of observatons
            if (IsGLM)
            {
                RHO2_EXACT_I(IsExact, R2, p, N, Rho2, omega, ref LeftTail, ref RightTail);
            }
            else if (IsExact)
            {
                RHO2_EXACT(false, R2, p, N, Rho2, ref LeftTail, ref RightTail);
            }
            else
            {
                RhoSquareDis_Lee(p, N, R2, Rho2, ref LeftTail, ref RightTail);
            }
        }



        public static void RHO2_EXACT(bool IsOdd, double X, double p, double ng, double Rho2, ref double LeftTail, ref double RightTail)
        {
            double p1;
            double y;
            double summand;
            double RelErr;
            double k;
            double a;
            double n;
            var density = default(double);
            double BK;
            double t1;
            double theta;
            double b;
            double cj;
            var lefttail1 = default(double);
            var RightTail1 = default(double);
            double sum;
            double binom;
            long j;

            // Console.WriteLine("p: {0}, N: {1}, R2: {2}, Rho2: {3}", p, ng, X, Rho2)


            a = 1.0d / (1d - Rho2);
            n = ng - 1d;
            k = (ng - p) / 2d;
            if (IsOdd)
            {
                theta = -Rho2;
                b = 1d;
                BK = -n / 2d;
            }
            else
            {
                theta = Rho2 / (1d - Rho2);
                b = a;
                BK = k;
            }
            // {  cj=1}
            p1 = (p - 1d) / 2d;
            binom = 1d;
            t1 = 1d;
            y = 2d * k * X / (b * (1d - X));
            y = y / (y + 2d * k);
            DistMain.betadis(p1, k, y, 1d - y, ref lefttail1, ref RightTail1, ref density);
            sum = lefttail1;
            j = 1L;
            do
            {
                binom = binom * (BK - j + 1d) / j;
                t1 = t1 * theta;
                cj = binom * t1;
                DistMain.betadis(p1 + j, k, y, 1d - y, ref lefttail1, ref RightTail1, ref density);
                summand = cj * lefttail1;
                sum = sum + summand;
                RelErr = summand / sum;
                j = j + 1L;
            }
            while (RelErr >= 0.000000000001d);
            if (!IsOdd)
                sum = sum * Math.Exp(Math.Log(b) * (p - 1d) / 2d);
            sum = sum / Math.Exp(Math.Log(a) * n / 2d);
            LeftTail = sum;
            RightTail = 1d - sum;
        }





        public static void RHO2_EXACT_I(bool IsExact, double R2, double p, double N, double Rho2, double omega, ref double LeftTail, ref double RightTail)
        {
            double X;
            double lambda;
            double DF1;
            double DF2; // , l1 As Double, r1 As Double
            DF1 = p - 1d;
            DF2 = N - p;
            lambda = DF2 * Rho2 / (1d - Rho2);
            X = DF2 / DF1 * R2 / (1d - R2);

            if (IsExact)
            {
                if (omega == 0d)
                {
                    // LeftTail = dreal.dist_pf_nc(X, DF1, DF2, lambda, True, False)
                    // LeftTail = boost2.dist_fisher_f_nc(X, DF1, DF2, lambda, 2)
                    LeftTail = dreal.dist_fisher_f_nc(DF1, DF2, lambda).cdf(X);

                    // RightTail = dreal.dist_pf_nc(X, DF1, DF2, lambda, False, False)
                    // RightTail = boost2.dist_fisher_f_nc(X, DF1, DF2, lambda, 3)
                    RightTail = dreal.dist_fisher_f_nc(DF1, DF2, lambda).sf(X);
                }

                else
                {
                    var density = default(double);
                    DoublyFdisn_Paolella_Combined(DF1, DF2, X, lambda, omega, ref density, ref LeftTail, ref RightTail);
                }
            }
            else
            {
                var density = default(double);
                DoublyFdisn_Paolella_Combined(DF1, DF2, X, lambda, omega, ref density, ref LeftTail, ref RightTail);
            }


            // LeftTail = non_central_f_cdf(X, DF1, DF2, lambda)
            // RightTail = non_central_f_cdf_complement(X, DF1, DF2, lambda)

        }




        public static void RhoSquareDis_Lee(double p, double N, double r2, double Rho2, ref double LeftTail, ref double RightTail)
        {
            double A1;
            double A2;
            double A3;
            double x1;
            double gamma2;
            double m;
            double G;
            double lambda;
            double nu;
            var density = default(double);
            // 3 moment approximation by noncentral F (Lee, 1970)
            double f1 = p - 1d;
            double f2 = N - p;
            gamma2 = 1d / (1d - Rho2);
            m = f2 + f1;
            A1 = m * (gamma2 - 1d) + f1;
            A2 = m * (gamma2 * gamma2 - 1d) + f1;
            A3 = m * (gamma2 * gamma2 * gamma2 - 1d) + f1;
            G = (A2 - Math.Sqrt(A2 * A2 - A1 * A3)) / A1;
            lambda = Rho2 * gamma2 * Math.Sqrt(gamma2 * m * f2) / (G * G);
            nu = A2 / (G * G) - 2d * lambda;
            x1 = r2 / (1d - r2) * (f2 / (nu * G));
            DoublyFdisn_Paolella_Combined(nu, f2, x1, lambda, 0d, ref density, ref LeftTail, ref RightTail);
        }




        public static double QuantileR2_Approx(bool IsGLM, double LeftTail, double Righttail, double f1, double f2, double l1, double l2)
        {
            double x1;
            double m1;
            double m2;
            double A1;
            double b1;
            double A2;
            double b2;
            double g2;
            double Rho2;
            double n;
            // 2 moment approximation
            if (IsGLM)
            {
                A1 = f1 + l1;
                b1 = A1 + l1;
                m1 = A1 * A1 / b1;
                A2 = f2 + l2;
                b2 = A2 + l2;
                m2 = A2 * A2 / b2;
            }
            else
            {
                Rho2 = l1 / (l1 + f2);
                g2 = 1d / (1d - Rho2);
                n = f2 + f1;
                A1 = n * (g2 - 1d) + f1;
                A2 = n * (g2 * g2 - 1d) + f1;
                m1 = A1 * A1 / A2;
                m2 = f2;
            }
            x1 = DistX.fdisx(LeftTail, Righttail, m1, m2);
            if (IsGLM)
                return x1 * A1 * f2 / (f1 * A2);
            else
                return x1 * A1 / f1;
        }


        public static void DemoQuantileR2()
        {
            double LeftTail;
            double Righttail;
            double RefTail;
            double x1;
            bool IsGLM = true;
            bool IsExact = false;
            int Df1 = 24;
            int Df2 = 34;
            double t1 = 30.0d;
            int omega = 60;
            // LeftTail = 0.9999
            // Righttail = 1 - LeftTail
            LeftTail = 0.0001d;
            Righttail = 1d - LeftTail;

            if (LeftTail < 0.5d)
                RefTail = LeftTail;
            else
                RefTail = Righttail;
            double LogBeta = Math.Log(LeftTail);
            x1 = QuantileR2_Approx(IsGLM, LeftTail, Righttail, Df1, Df2, t1, omega);
            FDisnByRhoSquareDis(IsExact, IsGLM, Df1, Df2, x1, t1, omega, ref LeftTail, ref Righttail);  // fdis
            double fx1 = LeftTail;
            Console.WriteLine("x1: {0}, fx1: {1}", x1, fx1);

            double lnPower = Math.Log(LeftTail);
            double L1 = x1;
            double L2 = L1;
            double LSign = 0.0d;
            double F_L1 = LogBeta - lnPower;
            double F_L2 = F_L1;
            if (F_L1 > 0d)
                LSign = +1;
            else
                LSign = -1;
            double Factor = 0.1d;
            double LStep = x1 * Factor;
            // If LStep < 2 Then LStep = 2
            Console.WriteLine("L1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L1, LeftTail, lnPower, F_L1);

            do
            {
                L1 = L2;
                F_L1 = F_L2;
                L2 = L1 + LStep * LSign;
                FDisnByRhoSquareDis(IsExact, IsGLM, Df1, Df2, L2, t1, omega, ref LeftTail, ref Righttail);
                lnPower = Math.Log(LeftTail);
                F_L2 = LogBeta - lnPower;
                Console.WriteLine("L2: {0}, LeftTail: {1}, lnPower: {2}, F_L2: {3}", L2, LeftTail, lnPower, F_L2);
                Factor = Factor + 0.1d;
                LStep = x1 * Factor;
            }
            while (F_L2 * LSign >= 0d);

            DemoBrentQuantile(IsExact, IsGLM, ref L1, ref L2, F_L1, F_L2, t1, LogBeta, Df1, Df2, omega);

        }


        public static double F_New_Quantile(bool IsExact, bool IsGLM, double x1, double t1, double LogBeta, double Df1, double Df2, double omega)
        {
            double lnPower;
            var LeftTail = default(double);
            var Righttail = default(double);
            FDisnByRhoSquareDis(IsExact, IsGLM, Df1, Df2, x1, t1, omega, ref LeftTail, ref Righttail);
            lnPower = Math.Log(LeftTail);
            return LogBeta - lnPower;
        }


        public static void DemoBrentQuantile(bool IsExact, bool IsGLM, ref double a, ref double b, double fa, double fb, double t1, double LogBeta, double Df1, double Df2, double omega)
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
            var m = default(double);
            long iter;
            long maxiter;
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
                // Function
                fb = F_New_Quantile(IsExact, IsGLM, b, t1, LogBeta, Df1, Df2, omega);
                Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            }

        Finish:
            ;

            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            xs = b;
        }




        public static void DemoNoncentralityR2()
        {
            double DF2;
            double lambda;
            double alpha;
            double Beta;
            double DF1;
            var x1 = default(double);
            var LeftTail = default(double);
            var Righttail = default(double);

            bool IsGLM = true;
            bool IsExact = false;
            int omega = 0;
            DF1 = 4d;
            DF2 = 100d;
            lambda = 0d;
            alpha = 0.002d;
            Beta = 0.003d; // Beta must be < 1-alpha

            double LogBeta = Math.Log(Beta);
            Console.WriteLine();
            GetL(DF1, ref x1, ref lambda, alpha, Beta); // this returns a value for x1 (at level alpha) and lambda

            // lambda = Get_ChiSquare_Lambda(DF1, alpha, Beta)

            x1 = DistX.fdisx(1d - alpha, alpha, DF1, DF2);
            double lambda_x1 = lambda;
            FDisnByRhoSquareDis(IsExact, IsGLM, DF1, DF2, x1, lambda_x1, omega, ref LeftTail, ref Righttail);  // fdis
            double fx1 = LeftTail;
            Console.WriteLine("lambda_x1: {0}, fx1: {1}", lambda_x1, fx1);

            double lnPower = Math.Log(LeftTail);
            double L1 = lambda_x1;
            double L2 = L1;
            double LSign = 0.0d;
            double F_L1 = LogBeta - lnPower;
            double F_L2 = F_L1;
            if (F_L1 > 0d)
                LSign = -1;
            else
                LSign = 1d;
            double Factor = 0.2d;
            double LStep = lambda * Factor;
            // If LStep < 2 Then LStep = 2
            Console.WriteLine("L1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L1, LeftTail, lnPower, F_L1);
            do
            {
                L1 = L2;
                F_L1 = F_L2;
                L2 = L1 + LStep * LSign;
                // is the following superfluous?
                // x1 = Fdisx(1 - alpha, alpha, DF1, DF2)
                FDisnByRhoSquareDis(IsExact, IsGLM, DF1, DF2, x1, L2, omega, ref LeftTail, ref Righttail);
                lnPower = Math.Log(LeftTail);
                F_L2 = LogBeta - lnPower;
                Console.WriteLine("L2: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", L2, LeftTail, lnPower, F_L2);
                Factor = Factor + 0.2d;
                LStep = lambda * Factor;
            }
            while (F_L2 * LSign <= 0d);

            DemoBrentLambda(IsExact, IsGLM, ref L1, ref L2, F_L1, F_L2, x1, LogBeta, DF1, DF2, omega);

        }


        public static double F_New_Lambda(bool IsExact, bool IsGLM, double L2, double x1, double LogBeta, double Df1, double Df2, double omega)
        {
            double lnPower;
            var LeftTail = default(double);
            var Righttail = default(double);
            FDisnByRhoSquareDis(IsExact, IsGLM, Df1, Df2, x1, L2, omega, ref LeftTail, ref Righttail);
            lnPower = Math.Log(LeftTail);
            return LogBeta - lnPower;
        }


        public static void DemoBrentLambda(bool IsExact, bool IsGLM, ref double a, ref double b, double fa, double fb, double x1, double LogBeta, double Df1, double Df2, double omega)
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
            var m = default(double);
            long iter;
            long maxiter;
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
                // Function
                fb = F_New_Lambda(IsExact, IsGLM, b, x1, LogBeta, Df1, Df2, omega);
                Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            }

        Finish:
            ;

            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            xs = b;
        }




        public static void DemoSampleSizeR2()
        {
            double lambda;
            double alpha;
            double Beta;
            double DF1;
            var x1 = default(double);
            var LeftTail = default(double);
            var Righttail = default(double);
            bool IsGLM;
            double Rho2;
            double n;
            double R2Tilde;
            double n0;
            double LogBeta;
            double lnPower;
            bool IsExact;
            double N1;
            double n2;
            double F_n1;
            double F_n2;
            double FSign;
            double Factor;
            double FStep;

            IsExact = true;
            IsGLM = true;
            int omega = 0;

            DF1 = 4d;
            lambda = 0.0d;
            alpha = 0.04d;
            Beta = 0.001d; // Beta must be < 1-alpha
            Rho2 = 0.3d;

            LogBeta = Math.Log(Beta);
            R2Tilde = Rho2 / (1d - Rho2);

            GetL(DF1, ref x1, ref lambda, alpha, Beta); // this returns a value for x1 (at level alpha) and lambda

            // lambda = Get_ChiSquare_Lambda(m, alpha, Beta)


            Console.WriteLine("LambdaC: {0}", lambda);
            Console.WriteLine("R2Tilde: {0}", R2Tilde);
            n = lambda / R2Tilde;
            n0 = n;
            if (n < 3d)
                n = 3d;
            x1 = DistX.fdisx(1d - alpha, alpha, DF1, n);
            FDisnByRhoSquareDis(IsExact, IsGLM, DF1, n, x1, n * R2Tilde, omega, ref LeftTail, ref Righttail);

            lnPower = Math.Log(LeftTail);

            N1 = n;
            n2 = N1;
            F_n1 = LogBeta - lnPower;
            F_n2 = F_n1;
            if (F_n1 > 0d)
                FSign = -1;
            else
                FSign = 1d;
            if (Rho2 > 0.2d)
                Factor = Rho2;
            else
                Factor = 0.2d;
            FStep = n0 * Factor;
            if (FStep < 2d)
                FStep = 2d;
            Console.WriteLine("n1: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", n, LeftTail, lnPower, F_n1);
            do
            {
                N1 = n2;
                F_n1 = F_n2;
                n2 = N1 + FStep * FSign;
                x1 = DistX.fdisx(1d - alpha, alpha, DF1, n2);
                FDisnByRhoSquareDis(IsExact, IsGLM, DF1, n2, x1, n2 * R2Tilde, omega, ref LeftTail, ref Righttail);
                lnPower = Math.Log(LeftTail);
                F_n2 = LogBeta - lnPower;
                Console.WriteLine("n2: {0}, LeftTail: {1}, lnPower: {2}, F_n1: {3}", n2, LeftTail, lnPower, F_n2);
            }
            while (F_n2 * FSign <= 0d);

            DemoBrentSampleSizeR2(IsExact, IsGLM, ref N1, ref n2, F_n1, F_n2, alpha, LogBeta, DF1, R2Tilde, omega);




            n2 = n2 * 1.0d;
            Console.WriteLine("Lambda: {0}", n2 * R2Tilde);
            x1 = DistX.fdisx(1d - alpha, alpha, DF1, n2);
            FDisnByRhoSquareDis(IsExact, IsGLM, DF1, n2, x1, n2 * R2Tilde, omega, ref LeftTail, ref Righttail);
            Console.WriteLine("n2: {0}, LeftTail: {1}, Diff: {2}", n2, LeftTail, Beta - LeftTail);

            n2 = Conversion.Int(n2);
            x1 = DistX.fdisx(1d - alpha, alpha, DF1, n2);
            FDisnByRhoSquareDis(IsExact, IsGLM, DF1, n2, x1, n2 * R2Tilde, omega, ref LeftTail, ref Righttail);
            Console.WriteLine("n2: {0}, LeftTail: {1}, Diff: {2}", n2, LeftTail, Beta - LeftTail);

            n2 = n2 + 1d;
            x1 = DistX.fdisx(1d - alpha, alpha, DF1, n2);
            FDisnByRhoSquareDis(IsExact, IsGLM, DF1, n2, x1, n2 * R2Tilde, omega, ref LeftTail, ref Righttail);
            Console.WriteLine("n2: {0}, LeftTail: {1}, Diff: {2}", n2, LeftTail, Beta - LeftTail);

            FDisnByRhoSquareDis(true, IsGLM, DF1, n2, x1, n2 * R2Tilde, omega, ref LeftTail, ref Righttail);
            Console.WriteLine("n2: {0}, LeftTail: {1}, Diff: {2}", n2, LeftTail, Beta - LeftTail);
        }


        public static double F_New_SampleSizeR2(bool IsExact, bool IsGLM, double n, double alpha, double LogBeta, double m, double R2Tilde, double omega)
        {
            double x1;
            double lnPower;
            var LeftTail = default(double);
            var Righttail = default(double);
            x1 = DistX.fdisx(1d - alpha, alpha, m, n);
            FDisnByRhoSquareDis(IsExact, IsGLM, m, n, x1, n * R2Tilde, omega, ref LeftTail, ref Righttail);
            lnPower = Math.Log(LeftTail);
            return LogBeta - lnPower;
        }


        public static void DemoBrentSampleSizeR2(bool IsExact, bool IsGLM, ref double a, ref double b, double fa, double fb, double alpha, double LogBeta, double m1, double R2Tilde, double omega)
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
            var m = default(double);
            long iter;
            long maxiter;
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
                // Function
                fb = F_New_SampleSizeR2(IsExact, IsGLM, b, alpha, LogBeta, m1, R2Tilde, omega);
                Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            }

        Finish:
            ;

            Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, Math.Abs(m): {5}", iter, a, b, fa, fb, Math.Abs(m));
            xs = b;
        }






        #endregion




        public static void DemoNoncentralDouble()
        {
            double r, rho, nu, mu, a, b, x, nc, nc2, xbeta, ybeta, LeftTail0 = 0.0, RightTail0 = 0.0;
            double LeftTail1 = 0.0, RightTail1 = 0.0;
            double LeftTail2 = 0.0, RightTail2 = 0.0;
            double LeftTail3 = 0.0, RightTail3 = 0.0;
            var PDF = default(double);
            int dis = 6;
            mu = 16d;
            nu = 11d;
            x = 11.0d;
            nc = 115d;
            nc2 = 6d;

            int p = 2; // p >= 2
            int N = 11; // N >= p + 1

            r = 0.5d;
            rho = 0.59d;

            double R2 = r * r;
            double Rho2 = rho * rho;

            a = 10d;
            b = 20d;
            xbeta = 0.7d;
            ybeta = 1d - xbeta;

            switch (dis)
            {
                case 1:
                    {
                        Console.WriteLine("Noncentral Chi-Square");
                        // Cdisn2(nu, x, nc, LeftTail0, RightTail0)
                        // CdisnCohen(N, x, nc, LeftTail0, RightTail0)
                        NonCentralChi2_SPA(nu, x, nc, ref LeftTail0, ref RightTail0);
                        // LeftTail1 = dreal.dist_pchisq_nc(x, nu, nc, True, False)
                        // LeftTail1 = boost2.dist_chisq_nc(x, nu, nc, 2)
                        // RightTail1 = dreal.dist_pchisq_nc(x, nu, nc, False, False)
                        // RightTail1 = boost2.dist_chisq_nc(x, nu, nc, 3)
                        LeftTail2 = non_central_chi_square_cdf(x, nu, nc);
                        RightTail2 = non_central_chi_square_cdf_complement(x, nu, nc);
                        NonCentralChi2_SPA2(nu, x, nc, ref LeftTail3, ref RightTail3);
                        break;
                    }
                // Cdisn_Penev(nu, x, nc, LeftTail3, RightTail3)


                case 2:
                    {
                        Console.WriteLine("Noncentral t");
                        // tdisn(nu, x, nc, LeftTail0, RightTail0)
                        TdisnOwen(N, x, nc, ref LeftTail0, ref RightTail0);
                        // LeftTail1 = dreal.dist_pt_nc(x, nu, nc, True, False)
                        // LeftTail1 = boost2.dist_student_t_nc(x, nu, nc, 2)
                        // RightTail1 = dreal.dist_pt_nc(x, nu, nc, False, False)
                        // RightTail1 = boost2.dist_student_t_nc(x, nu, nc, 3)
                        LeftTail2 = non_central_t_cdf(nu, nc, x);
                        RightTail2 = non_central_t_cdf_complement(nu, nc, x);
                        TDisN_Broda_Combined(nu, x, nc, 0d, ref PDF, ref LeftTail3, ref RightTail3);
                        break;
                    }


                case 3:
                    {
                        Console.WriteLine("Noncentral F");
                        Fdisn2(mu, nu, x, nc, ref LeftTail0, ref RightTail0);
                        FdisnSeber(x, mu, N, nc, ref LeftTail0, ref RightTail0);
                        // LeftTail1 = dreal.dist_pf_nc(x, mu, nu, nc, True, False)
                        // LeftTail1 = boost2.dist_fisher_f_nc(x, mu, nu, nc, 2)
                        // RightTail1 = dreal.dist_pf_nc(x, mu, nu, nc, False, False)
                        // RightTail1 = boost2.dist_fisher_f_nc(x, mu, nu, nc, 3)
                        LeftTail2 = non_central_f_cdf(x, mu, nu, nc);
                        RightTail2 = non_central_f_cdf_complement(x, mu, nu, nc);
                        FdisnPaolella(mu, nu, x, nc, 0d, ref PDF, ref LeftTail3, ref RightTail3);
                        break;
                    }


                case 4:
                    {
                        Console.WriteLine("Noncentral beta");
                        // Console.WriteLine("xbeta: {0}, ybeta: {1}", xbeta, ybeta)
                        // Betadisn(a, b, xbeta, ybeta, nc, LeftTail0, RightTail0)
                        BetadisnSeber(xbeta, a, (long)Math.Round(b), nc, ref LeftTail0, ref RightTail0);
                        // LeftTail1 = dreal.dist_pbeta_nc(xbeta, a, b, nc, True, False)
                        // LeftTail1 = boost2.dist_beta_nc(xbeta, a, b, nc, 2)
                        // RightTail1 = dreal.dist_pbeta_nc(xbeta, a, b, nc, False, False)
                        // RightTail1 = boost2.dist_beta_nc(xbeta, a, b, nc, 3)

                        LeftTail2 = non_central_beta_cdf(a, b, nc, xbeta, ybeta);
                        RightTail2 = non_central_beta_cdf_complement(a, b, nc, xbeta, ybeta);
                        BetadisnPaolella(a, b, xbeta, ybeta, nc, ref PDF, ref LeftTail3, ref RightTail3);
                        break;
                    }


                case 5:
                    {
                        Console.WriteLine("Pearson rho");
                        // LeftTail0 = RhoExplicit_Arb(N, r, rho).AsDouble
                        RightTail0 = 1d - LeftTail0;
                        RhoDisN_Guenther(N, r, rho, ref LeftTail1, ref RightTail1);
                        RhoDisN_Hotelling(N, r, rho, ref LeftTail2, ref RightTail2);
                        LeftTail3 = RhoDis_W(N, r, rho);
                        RightTail3 = 1d - LeftTail3;
                        break;
                    }


                case 6:
                    {
                        Console.WriteLine("RhoSquare");
                        RhoSquareDis(true, true, p, N, R2, Rho2, 0d, ref LeftTail0, ref RightTail0);
                        RhoSquareDis(true, false, p, N, R2, Rho2, 0d, ref LeftTail1, ref RightTail1);
                        // LeftTail2 = RhoExplicit_Arb(N, r, rho).AsDouble - RhoExplicit_Arb(N, -r, rho).AsDouble
                        RightTail2 = 1d - LeftTail2;
                        RhoSquareDis_Lee(p, N, R2, Rho2, ref LeftTail3, ref RightTail3);
                        break;
                    }


                case 7:
                    {
                        Console.WriteLine("Doubly Noncentral t");
                        Tdis_Doubly_nc(nu, x, nc, nc2, ref LeftTail0, ref RightTail0);
                        TDisN_Broda_Combined(nu, x, nc, nc2, ref PDF, ref LeftTail1, ref RightTail1);
                        // approximation by singly noncentral t
                        double A2 = nu + nc2;
                        double B2 = nu + 2d * nc2;
                        double m2 = A2 * A2 / B2;
                        double y = x * Math.Sqrt(A2 / nu);
                        TDisN_Broda_Combined(m2, y, nc, 0d, ref PDF, ref LeftTail2, ref RightTail2);
                        break;
                    }


                case 8:
                    {
                        Console.WriteLine("Doubly Noncentral F");
                        Fdisn_Doubly_nc(mu, nu, x, nc, nc2, ref LeftTail0, ref RightTail0);
                        DoublyFdisn_Paolella_Combined(mu, nu, x, nc, nc2, ref PDF, ref LeftTail1, ref RightTail1);
                        // approximation by singly noncentral F
                        double A2 = nu + nc2;
                        double B2 = nu + 2d * nc2;
                        double m2 = A2 * A2 / B2;
                        double y = x * A2 / nu;
                        DoublyFdisn_Paolella_Combined(mu, m2, y, nc, 0d, ref PDF, ref LeftTail2, ref RightTail2);
                        break;
                    }

                default:
                    {


                        Console.WriteLine("Not implemented");
                        break;
                    }

            }

            Console.WriteLine("LeftTail0: {0}, RightTail0: {1}", LeftTail0, RightTail0);
            Console.WriteLine("LeftTail1: {0}, RightTail1: {1}", LeftTail1, RightTail1);
            Console.WriteLine("LeftTail2: {0}, RightTail2: {1}", LeftTail2, RightTail2);
            Console.WriteLine("LeftTail3: {0}, RightTail3: {1}", LeftTail3, RightTail3);
            Console.WriteLine("PDF:  {0}", PDF);
        }





    }
}