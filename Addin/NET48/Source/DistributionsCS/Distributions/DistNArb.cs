using System;
using ArbPrecNet;

namespace Distributions
{


    static class DistNArb
    {





        // **********************************************************************
        // Noncentral ChiSquare
        // '**********************************************************************


        public static Arb aflint_sign(Arb x)
        {
            if (x.Mid < aflint.zero())
                return aflint.t("-1");
            if (x.Mid > aflint.zero())
                return aflint.t("1");
            else
                return aflint.t("0");
        }


        // Function aflint_get_tol() As Arb
        // Return 10 * aflint.t(mreal.machine_epsilon().ToString())
        // End Function



        #region Noncentral ChiSquare



        public static Arb aflint_NonCentralChi2_CGF_Derivative(Arb t, Arb n, Arb lambda, int j)
        {
            var result = new Arb();
            if (j == 0)
            {
                result = -(n / 2) * aflint.log(1 - 2 * t) + lambda * t / (1 - 2 * t);
            }
            else
            {
                Arb p1;
                var p2 = new Arb();
                // p1 = (2 ^ (j - 1)) * aflint.gamma(j) / ((1 - 2 * t) ^ j)
                p1 = Math.Pow(2d, j - 1) * aflint.gamma(j) / aflint.pow(1 - 2 * t, j);
                p2 = n + lambda * j / (1 - 2 * t);
                result = p1 * p2;
            }
            return result;
        }


        public static void aflint_NonCentralChi2_SPA2(Arb n, Arb x, Arb lambda, ref Arb LeftTail, ref Arb Righttail)
        {
            Arb s, density = aflint.t(0);
            Console.WriteLine("n: {0}, x: {1}, lambda: {2}", n, x, lambda);
            s = -(1 / (4 * x)) * (n - 2 * x + aflint.sqrt(n * n + 4 * x * lambda));
            Console.WriteLine("s: {0}", s);
            int order = 18;
            var kappa = new Arb[order + 1 + 1];
            for (int j = 0, loopTo = order; j <= loopTo; j++)
            {
                kappa[j] = aflint_NonCentralChi2_CGF_Derivative(s, n, lambda, j);
                Console.WriteLine("j: {0}, K(s): {1}", j, kappa[j]);
            }

            Console.WriteLine("");
            aflint_LugannaniRiceNew(order, kappa, s, ref density, ref LeftTail, ref Righttail);
        }


        // !!!!!  d(,) needs to be changed to ArbMat  !!!!
        public static void aflint_Fill_d(int order, ref Arb[,] d, Arb[] theta)
        {
            d[0, 0] = aflint.t(1);
            for (int m = 0, loopTo = order; m <= loopTo; m++)
            {
                for (int n = m, loopTo1 = order; n <= loopTo1; n++)
                {
                    var sum = aflint.t(0.0d);
                    for (int k = 1, loopTo2 = n - m + 1; k <= loopTo2; k++)
                        sum = sum + k * theta[k + 2] * d[m, n - k + 1];
                    d[m + 1, n + 1] = sum / (n + 1);
                }
            }
        }



        public static Arb aflint_GammaHalf(int mj)
        {
            return aflint.gamma(mj + 0.5d) / aflint.sqrt(aflint.pi());
        }


        public static Arb aflint_Calc_A(int j, Arb A0, Arb mu, Arb[,] d, Arb[] theta)
        {
            var sum1 = aflint.t(0.0d);
            for (int n = 0, loopTo = 2 * j; n <= loopTo; n++)
            {
                var sum2 = aflint.t(0.0d);
                for (int m = 0, loopTo1 = n; m <= loopTo1; m++)
                {
                    var delta = d[m, n];
                    // Console.WriteLine("m: {0}, n: {1}, delta: {2}", m, n, delta)
                    var summand2 = delta * Math.Pow(-2, m + j) * aflint_GammaHalf(m + j);
                    sum2 = sum2 + summand2;
                }
                var factor = aflint.pow(-mu, 2 * j - n);
                // Console.WriteLine("factor: {0}, sum2: {1}, -mu: {2}", factor, sum2, -mu)
                sum1 = sum1 + factor * sum2;
            }
            return A0 * sum1;
        }

        public static void aflint_LugannaniRiceNew(int order, Arb[] kappa, Arb s, ref Arb density, ref Arb LeftTail, ref Arb RightTail)
        {
            Arb mu = new Arb(), w1 = new Arb(), w2 = new Arb(), LeftTail0 = new Arb(), RightTail0 = new Arb(), u = new Arb(), w = new Arb();
            var theta = new Arb[order + 1 + 1];
            var A = new Arb[order + 1 + 1];
            var B = new Arb[order + 1 + 1];
            var sum = new Arb[order + 1 + 1];
            var d = new Arb[2 * order + 3 + 1, 2 * order + 3 + 1];
            for (int i = 0, loopTo = 2 * order + 3; i <= loopTo; i++)
            {
                for (int j = 0, loopTo1 = 2 * order + 3; j <= loopTo1; j++)
                    d[i, j] = aflint.t(0);
            }

            w = aflint_sign(s) * aflint.sqrt(2 * (s * kappa[1] - kappa[0]));
            u = s * aflint.sqrt(kappa[2]);
            w1 = 1 / w;
            w2 = -2 * w1 * w1;
            mu = 1 / u;

            var k = aflint.sqrt(kappa[2]);
            var factor = 2 * kappa[2];
            for (int j = 3, loopTo2 = order; j <= loopTo2; j++)
            {
                factor = factor * j * k;
                theta[j] = kappa[j] / factor;
                // Console.WriteLine("j: {0}, theta: {1}", j, theta(j))
            }

            density = aflint.ndens(w);
            LeftTail0 = aflint.ndis(w);
            RightTail0 = aflint.ndis(-w);

            B[0] = density * w1;
            factor = aflint.t(0.5d);
            for (int j = 1, loopTo3 = order; j <= loopTo3; j++)
            {
                B[j] = B[j - 1] * w2 * factor;
                factor = factor + 1;
            }

            aflint_Fill_d(order - 3, ref d, theta);
            A[0] = density * mu;
            for (int j = 1, loopTo4 = order - 3; j <= loopTo4; j++)
                A[j] = aflint_Calc_A(j, A[0], mu, d, theta);

            var totalsum = aflint.t(0);
            int useorder = order - 3;
            var LastSumj = aflint.t("10");
            // Console.WriteLine("j: {0}, Leftj: {1}, Rightj: {2}", 0, LeftTail0 - totalsum, RightTail0 + totalsum)
            Console.WriteLine("j: {0}, Rightj: {1}", 0, RightTail0 + totalsum);

            // For j = 0 To useorder
            // sum(j) = A(j) - B(j)
            // Dim abssumj = aflint.abs(sum(j))
            // totalsum = totalsum + sum(j)
            // LastSumj = abssumj
            // 'Console.WriteLine("j: {0}, Leftj: {1}, sumj: {2}", j, LeftTail0 - totalsum, sum(j))
            // Console.WriteLine("j: {0}, Rightj: {1}, sumj: {2}", j, RightTail0 + totalsum, sum(j))
            // Next

            for (int j = 0, loopTo5 = useorder; j <= loopTo5; j++)
            {
                sum[j] = A[j] - B[j];
                var abssumj = aflint.abs(sum[j]);
                if (LastSumj > abssumj)
                {
                    totalsum = totalsum + sum[j];
                    LastSumj = abssumj;
                    // Console.WriteLine("j: {0}, Leftj: {1}, sumj: {2}", j, LeftTail0 - totalsum, sum(j))
                    Console.WriteLine("j: {0}, Rightj: {1}, sumj: {2}", j, RightTail0 + totalsum, sum[j]);
                }
                else
                {
                    break;
                }
            }


            LeftTail = LeftTail0 - totalsum;
            RightTail = RightTail0 + totalsum;
            Console.WriteLine("LeftTail: {0}", LeftTail);
            Console.WriteLine("");
        }
















        public static Arb aflint_non_central_chi_square(Arb x, Arb f, Arb theta, ref Arb LeftTail, ref Arb RightTail)
        {
            LeftTail = aflint_non_central_chi_square_p(x, f, theta, aflint.t(0));
            RightTail = aflint_non_central_chi_square_q(x, f, theta, aflint.t(0));
            return LeftTail;
        }


        public static Arb aflint_non_central_chi_square_q(Arb x, Arb f, Arb theta, Arb init_sum)
        {
            if (x == 0)
                return aflint.t(1.0d);

            var lambda = theta / 2;
            var del = f / 2;
            var y = x / 2;
            int max_iter = 1000000; // policies::get_max_series_iterations<Policy>()
            var errtol = aflint.epsilon(); // boost::math::policies::get_epsilon<T, Policy>()
            var sum = init_sum;

            // Dim k As Int32 = Convert.ToInt32(aflint.round(lambda))
            int k = aflint.lrint(lambda);
            // Forwards and backwards Poisson weights:
            var poisf = aflint.gamma_p_derivative(aflint.t(1 + k), lambda);
            var poisb = poisf * k / lambda;
            // Initial forwards central chi squared term:
            var gamf = aflint.gamma_q(del + k, y);
            // Forwards and backwards recursion terms on the central chi squared:
            var xtermf = aflint.gamma_p_derivative(del + 1 + k, y);
            var xtermb = xtermf * (del + k) / y;
            // Initial backwards central chi squared term:
            var gamb = gamf - xtermb;

            // Forwards iteration first, this is the
            // stable direction for the gamma function
            // recurrences:
            // 
            var i = default(int);
            var loopTo = max_iter - (i - k);
            for (i = k; i <= loopTo; i++)
            {
                var term = poisf * gamf;
                sum += term;
                poisf *= lambda / (i + 1);
                gamf += xtermf;
                xtermf *= y / (del + i + 1);
                if ((sum == 0 | aflint.abs(term / sum) < errtol) & term >= poisf * gamf)
                    break;
            }
            // Error check:
            if (i - k >= max_iter)
            {
                Console.WriteLine("cdf(non_central_chi_squared_distribution Series did not converge, closest value was {0}", sum);
                return aflint.t(0.0d);
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
                var term = poisb * gamb;
                sum += term;
                poisb *= i / lambda;
                xtermb *= (del + i) / y;
                gamb -= xtermb;
                if (sum == 0 | aflint.abs(term / sum) < errtol)
                    break;
            }

            return sum;
        }


        public static Arb aflint_non_central_chi_square_p(Arb y, Arb n, Arb lambda, Arb init_sum)
        {
            if (y == 0)
                return aflint.t(0.0d);

            // Dim lambda As Arb = theta / 2
            int max_iter = 1000000; // policies::get_max_series_iterations<Policy>()
            var errtol = aflint.epsilon(); // boost::math::policies::get_epsilon<T, Policy>()
                                           // Dim errtol As Arb = aflint.t("1E-15") 'boost::math::policies::get_epsilon<T, Policy>()
            var errorf = aflint.t(0.0d);
            var errorb = aflint.t(0.0d);



            var x = y / 2;
            var del = lambda / 2;
            // 
            // Starting location for the iteration, we'll iterate
            // both forwards and backwards from this point.  The
            // location chosen is the maximum of the Poisson weight
            // function, which ocurrs *after* the largest term in the
            // sum.
            // 

            // Dim k As Int32 = Convert.ToInt32(round(lambda))
            int k = aflint.lrint(lambda);
            var a = n / 2 + k;
            // Central chi squared term for forward iteration:
            var gamkf = aflint.gamma_p(a, x);

            if (lambda == 0)
                return gamkf;
            // Central chi squared term for backward iteration:
            var gamkb = gamkf;
            // Forwards Poisson weight:
            var poiskf = aflint.gamma_p_derivative(aflint.t(k + 1), del);
            // Backwards Poisson weight:
            var poiskb = poiskf;
            // Forwards gamma function recursion term:
            var xtermf = aflint.gamma_p_derivative(a, x);
            // Backwards gamma function recursion term:
            var xtermb = xtermf * x / a;
            var sum = init_sum + poiskf * gamkf;
            if (sum == 0)
                return sum;
            int i = 1;
            // 
            // Backwards recursion first, this is the stable
            // direction for gamma function recurrences:
            // 
            while (i <= k)
            {
                xtermb *= (a - i + 1) / x;
                gamkb += xtermb;
                poiskb = poiskb * (k - i + 1) / del;
                errorf = errorb;
                errorb = gamkb * poiskb;
                sum += errorb;
                if (aflint.abs(errorb / sum) < errtol & errorb <= errorf)
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
                xtermf = xtermf * x / (a + i - 1);
                gamkf = gamkf - xtermf;
                poiskf = poiskf * del / (k + i);
                errorf = poiskf * gamkf;
                sum += errorf;
                i = i + 1;
            }
            while (aflint.abs(errorf / sum) > errtol & i < max_iter);

            // Error check:
            if (i >= max_iter)
            {
                Console.WriteLine("cdf(non_central_chi_squared_distribution Series did not converge, closest value was {0}", sum);
                return sum;
            }

            return sum;
        }


        public static void aflint_GetL(Arb F, Arb Chi2, Arb lambda, Arb alpha, Arb Beta)
        {
            Arb t;
            Arb n;
            Arb t2;
            Arb t3;
            Arb t4;
            Arb X;
            Arb x2;
            Arb x3;
            Arb x4;
            Arb x5;
            Arb y;
            Arb Y_12;
            Arb Y_32;
            Arb Y_52;
            Arb Y_4;
            Arb Y_112;
            X = DistXArb.ndisxArb(1 - Beta, Beta);
            Chi2 = DistXArb.cdisxArb(1 - alpha, alpha, F);
            t = (Chi2 - F) / F;
            n = F;
            t2 = t * t;
            t3 = t2 * t;
            t4 = t3 * t;
            x2 = X * X;
            x3 = x2 * X;
            x4 = x3 * X;
            x5 = x4 * X;
            y = 2 * t + 1;
            Y_12 = aflint.sqrt(y);
            Y_32 = y * Y_12 * aflint.sqrt(n);
            Y_52 = y * Y_32;
            Y_4 = Y_52 * Y_32;
            Y_112 = Y_4 * Y_32;
            lambda = n * t + aflint.sqrt(2 * n * y) * X + 2 * ((3 * t + 2) * x2 + (3 * t + 1)) / (3 * y) - aflint.sqrt(2) * ((6 * t + 5) * x3 - (36 * t2 + 42 * t + 17) * X) / (18 * Y_52) + ((324 * t2 + 594 * t + 276) * x4 - (1080 * t3 + 2484 * t2 + 2394 * t + 976) * x2 + (1080 * t3 + 1512 * t2 + 612 * t + 148)) / (405 * Y_4) - aflint.sqrt(2) * ((10368 * t3 + 30780 * t2 + 30564 * t + 10143) * x5 - (25920 * t4 + 98928 * t3 + 163080 * t2 + 137544 * t + 47188) * x3 + (45360 * t4 + 106704 * t3 + 80460 * t2 + 31092 * t + 13489) * X) / (9720 * Y_112);





            if (lambda < 0)
                lambda = aflint.t(0.00001d);
        }






        #endregion







        // **********************************************************************
        // Noncentral Beta cdf
        // '**********************************************************************


        #region Noncentral Beta



        // Function non_central_beta_p(a As Arb, b As Arb, lambda As Arb, x As Arb, y As Arb, init_val As Arb) As Arb

        // Dim max_iter As Int32 = 1000000 'policies::get_max_series_iterations<Policy>()
        // Dim errtol As Arb = 0.000000000000001 'boost::math::policies::get_epsilon<T, Policy>()

        // Dim l2 As Arb = lambda / 2



        // Dim k As Int32 = Convert.ToInt32(round(l2))

        // ' Forwards and backwards Poisson weights:
        // Dim poisf As Arb = boost.gamma_p_derivative((1 + k), lambda)
        // Dim poisb As Arb = poisf * k / lambda
        // ' Initial forwards central chi squared term:
        // Dim gamf As Arb = boost.gamma_q(del + k, y)
        // ' Forwards and backwards recursion terms on the central chi squared:
        // Dim xtermf As Arb = boost.gamma_p_derivative(del + 1 + k, y)
        // Dim xtermb As Arb = xtermf * (del + k) / y
        // ' Initial backwards central chi squared term:
        // Dim gamb As Arb = gamf - xtermb

        // ' Forwards iteration first, this is the
        // ' stable direction for the gamma function
        // ' recurrences:
        // '
        // Dim i As Int32
        // For i = k To (max_iter - (i - k))
        // Dim term As Arb = poisf * gamf
        // sum += term
        // poisf *= lambda / (i + 1)
        // gamf += xtermf
        // xtermf *= y / (del + i + 1)
        // If (((sum = 0) Or (aflint.abs(term / sum) < errtol)) And (term >= poisf * gamf)) Then Exit For
        // Next
        // 'Error check:
        // If ((i - k) >= max_iter) Then
        // Console.WriteLine("cdf(non_central_chi_squared_distribution Series did not converge, closest value was {0}", sum)
        // Return 0.0
        // End If

        // ' Now backwards iteration: the gamma
        // ' function recurrences are unstable in this
        // ' direction, we rely on the terms deminishing in size
        // ' faster than we introduce cancellation errors.
        // ' For this reason it's very important that we start
        // ' *before* the largest term so that backwards iteration
        // ' is strictly converging.
        // '
        // For i = k - 1 To 0 Step -1
        // Dim term As Arb = poisb * gamb
        // sum += term
        // poisb *= i / lambda
        // xtermb *= (del + i) / y
        // gamb -= xtermb
        // If ((sum = 0) Or (aflint.abs(term / sum) < errtol)) Then Exit For
        // Next

        // Return sum
        // End Function






        public static void aflint_Betadisn(Arb a, Arb b, Arb X, Arb y, Arb d, ref Arb LeftTail, ref Arb RightTail)
        {
            long n;
            long Mode;
            var density = default(Arb);
            Arb t;
            Arb snRight;
            Arb d2;
            Arb sn;
            Arb rn;
            Arb FehlerLeft;
            var RelFehlerLeft = default(Arb);
            Arb ResultLeft;
            Arb qsum;
            Arb expd2;
            Arb Lastvalue;
            var l1 = default(Arb);
            Arb RelFehlerRight;
            Arb ResultRight; // , l2 As Arb, r2 As Arb

            LeftTail = DistXArb.FdisArb((2 * a + d) * (2 * a + d) / (2 * (a + d)), 2 * b, 2 * b / (2 * a + d) * X / (1 - X));
            if (LeftTail < aflint.t("0.01"))
                Mode = 1L;
            else
                Mode = 2L;

            // Mode = 1
            d2 = d / 2;
            rn = aflint.t(1);
            n = 1L;
            expd2 = aflint.exp(-d2);
            // t = LnGamma(a + b) - LnGamma(a + 1) - LnGamma(b)
            // t = t + a * Log(X) + b * Log(y)
            // t = Exp(t)
            DistXArb.betadisArb(a, b, X, y, ref LeftTail, ref RightTail, ref density);
            t = density * X * y / a;
            // Debug.Print "t: ", t, density * X * y / a
            sn = LeftTail;
            Lastvalue = LeftTail;
            snRight = RightTail;
            qsum = aflint.t(1);
            if (Mode == 1L)
            {
                do
                {
                    rn = rn * d2 / n;
                    qsum = qsum + rn;
                    LeftTail = LeftTail - t;
                    if (Lastvalue / LeftTail > aflint.t("1000"))
                    {
                        DistXArb.betadisArb(a + n, b, X, y, ref l1, ref RightTail, ref density);
                        Lastvalue = l1;
                        LeftTail = l1;
                    }
                    sn = sn + rn * LeftTail;
                    t = t * X * (a + b + n - 1) / (a + n);
                    FehlerLeft = LeftTail * (1 - expd2 * qsum);
                    ResultLeft = expd2 * sn;
                    RelFehlerLeft = FehlerLeft / ResultLeft;
                    n = n + 1L;
                }
                while (RelFehlerLeft >= aflint.t("1E-15"));
                LeftTail = ResultLeft;
                RightTail = 1 - LeftTail;
            }

            // Mode = 2
            if (Mode == 2L)
            {
                do
                {
                    rn = rn * d2 / n;
                    RightTail = RightTail + t;
                    snRight = snRight + rn * RightTail;
                    t = t * X * (a + b + n - 1) / (a + n);
                    RelFehlerRight = rn * RightTail / snRight;
                    n = n + 1L;
                }
                while (RelFehlerLeft >= aflint.t("1E-15"));
                ResultRight = expd2 * snRight;
                RightTail = ResultRight;
                LeftTail = 1 - RightTail;
            }




        }


        #endregion







        // **********************************************************************
        // Singly noncentral F cdf
        // '**********************************************************************


        #region Noncentral F


        public static Arb aflint_Fdisn(Arb m, Arb n, Arb a, Arb NC)
        {
            Arb X;
            Arb y;
            Arb p;
            Arb Q;
            var L = default(Arb);
            var r = default(Arb);
            // Dim density As Arb
            if (a <= 0)
            {
                return aflint.t(0);
            }
            X = m * a / (m * a + n);
            y = n / (m * a + n);
            p = m / 2;
            Q = n / 2;
            /// !!! Still Missing !!!!
            aflint_Betadisn(p, Q, X, y, NC, ref L, ref r);
            return r;
            // If Not (IsMissing(LeftTail)) Then LeftTail = L
            // If Not (IsMissing(RightTail)) Then RightTail = r
        }



        public static void aflint_Fdis_a(Arb m, Arb n, Arb a, ref Arb LeftTail, ref Arb RightTail)
        {
            Arb X;
            Arb y;
            Arb p;
            Arb Q;
            if (a <= 0)
            {
                LeftTail = aflint.t(0);
                RightTail = aflint.t(1);
                return;
            }
            X = m * a / (m * a + n);
            y = n / (m * a + n);
            p = m / 2;
            Q = n / 2;
            aflint_Betadisn(p, Q, X, y, aflint.t(0), ref LeftTail, ref RightTail);
        }



        public static Arb aflint_fdisnOwen(Arb a, Arb m, long n, Arb d)
        {
            Arb X;
            Arb p;
            long Q;
            Arb C;
            Arb b;
            Arb b0;
            Arb b1;
            Arb S;
            long k;
            X = m * a / (m * a + n);
            p = m / 2;
            Q = n / 2L;
            C = aflint.pow(X, p) * aflint.exp(d * (X - 1) / 2);
            b0 = aflint.t(0);
            b1 = aflint.t(1);
            S = aflint.t(1);
            k = n % 2L;
            if (k != 0L)
            {
                Console.WriteLine("n needs to be an even integer");
                return aflint.t(0);
            }
            else
            {
                var loopTo = Q;
                for (k = 2L; k <= loopTo; k++)
                {
                    b = (2L * k - 4L + p + d * X / 2) * b1 + (k - 3L + p) * (X - 1) * b0;
                    b = b * (1 - X) / (k - 1L);
                    S = S + b;
                    b0 = b1;
                    b1 = b;
                }
                return 1 - C * S;
            } // RightTail
        }


        public static Arb aflint_fdisnOwen2(Arb a, Arb m, long n, Arb d, ref Arb LeftTail, ref Arb RightTail)
        {
            Arb X;
            Arb p;
            long Q;
            Arb C;
            Arb b;
            Arb b0;
            Arb b1;
            Arb S;
            long k;
            X = m * a / (m * a + n);
            p = m / 2;
            Q = n / 2L;
            C = aflint.pow(X, p) * aflint.exp(d * (X - 1) / 2);
            b0 = aflint.t(0);
            b1 = aflint.t(1);
            S = aflint.t(1);
            k = n % 2L;
            if (k != 0L)
            {
                Console.WriteLine("n needs to be an even integer");
                return aflint.t(0);
            }
            else
            {
                var loopTo = Q;
                for (k = 2L; k <= loopTo; k++)
                {
                    b = (2L * k - 4L + p + d * X / 2) * b1 + (k - 3L + p) * (X - 1) * b0;
                    b = b * (1 - X) / (k - 1L);
                    S = S + b;
                    b0 = b1;
                    b1 = b;
                }
                LeftTail = C * S;
                RightTail = 1 - C * S; // RightTail
                return LeftTail;
            }
        }



        #endregion







        // **********************************************************************
        // Singly noncentral T cdf
        // '**********************************************************************


        #region NoncentralT


        public static Arb Arbdisn(Arb F, Arb t, Arb d, ref Arb LeftTail, ref Arb RightTail)
        {
            var sqrtpi = aflint.pi();
            var S = new Arb[2];
            Arb a;
            Arb b;
            Arb y;
            Arb X;
            Arb z;
            Arb h;
            Arb g;
            Arb k;
            Arb r;
            Arb ss;
            Arb ak;
            Arb C;
            Arb pk0;
            Arb pk1;
            Arb pk2; // , lnB As Arb
            int i;
            bool fit;

            // ERROR: Calculation in double precision !!!!!
            if (d == 0)
            {
                //double localtdis() { double argLeftTail = LeftTail.AsDouble(); double argRightTail = RightTail.AsDouble(); var ret = DistMain.tdis(F.AsDouble(), t.AsDouble(), ref argLeftTail, ref argRightTail); return ret; }

                return aflint.t(0);
            }
            fit = true;
            if (t > 0)
            {
                fit = false;
                t = -t;
                d = -d;
            }
            a = t / aflint.sqrt(F);
            b = F / (F + t * t);
            y = d * aflint.sqrt(b / 2) / sqrtpi;
            X = d * d * b / 2;
            z = a * a * b;
            h = DistXArb.NdisArb(-d * aflint.sqrt(b));

            // ERROR: Calculation in double precision !!!!!
            g = aflint.exp(-DistMain.Lnbeta(F.AsDouble() / 2d, 1d / 2d));
            ak = aflint.t(1);
            C = aflint.t(0.5d);
            for (i = 0; i <= 1; i++)
            {
                k = aflint.t(0);
                S[i] = aflint.t(0);
                pk2 = aflint.t(1);
                pk1 = aflint.t(0);
                do
                {
                    S[i] = S[i] + ak * pk2;
                    pk0 = pk1;
                    pk1 = pk2;
                    ss = k + C;
                    pk2 = pk1 * (1 + (k - X) / ss) - pk0 * k / ss;
                    k = k + 1;
                    r = 2 * k;
                    if (i == 0)
                    {
                        ak = ak * z * (r - F) * (r - 1) / (r * (r + 1));
                    }
                    else
                    {
                        ak = ak * z * (r + 1 - F) / (r + 2);
                    }
                }
                while (S[i] != S[i] + ak * pk2);
                ak = z * (1 - F) / 2;
                C = aflint.t(1.5d);
            }
            h = h + (g * a * aflint.sqrt(b) * S[0] - y * S[1]) * aflint.exp(-X);
            if (h < 0)
                h = aflint.t(0);
            if (h > 1)
                h = aflint.t(1);
            LeftTail = h;
            RightTail = 1 - h;
            if (!fit)
            {
                RightTail = h;
                LeftTail = 1 - h;
            }
            return LeftTail;
        }



        public static Arb ArbdisnR(Arb F, Arb t, Arb d)
        {
            var LeftTail = default(Arb);
            var RightTail = default(Arb);
            Arbdisn(F, t, d, ref LeftTail, ref RightTail);
            return RightTail;
        }


        public static void ArbdisnOwen_Combined(long n, Arb t, Arb d, ref Arb PDF, ref Arb CDF)
        {
            Arb F0;
            Arb f2;
            var LeftTail = default(Arb);
            var RightTail = default(Arb);
            F0 = ArbdisnOwen(n, t, d, ref LeftTail, ref RightTail);
            f2 = ArbdisnOwen(n + 2L, t * aflint.sqrt(1d + 2d / n), d, ref LeftTail, ref RightTail);
            CDF = F0;
            PDF = n / t * (f2 - F0);
        }




        public static Arb ArbdisnOwen(long n, Arb X, Arb d, ref Arb LeftTail, ref Arb RightTail)
        {
            // Const h = 0.797884560802866 '  H = 2 / Sqrt(2 * Pi)
            var h = 2 / aflint.sqrt(2 * aflint.pi());
            Arb a;
            Arb b;
            Arb b2;
            long k;
            long i;
            long j;
            Arb C;
            Arb C0;
            Arb C1;
            Arb g;
            var F = default(Arb);
            var one = aflint.one();
            a = X / aflint.sqrt(n);
            b2 = one / (one + a * a);
            b = aflint.sqrt(b2);
            k = n % 2L;
            if (k == 0L)
                F = DistXArb.NdisArb(-d);
            else
                Console.WriteLine("Need to implement Owen's t");
            // If k = 0 Then F = ndis(-d) Else F = ndis(-d * b) + 2 * t(d * b, a)
            // t = THA(h, 1, a, 1)

            if (n > 1L)
            {
                C0 = a * b * DistXArb.NdisArb(d * a * b) * aflint.exp(-0.5d * d * d * b2);
                C1 = a * b2 * (d * C0 + 0.5d * aflint.exp(-0.5d * d * d) * h);
                if (k == 0L)
                    F = F + C0;
                else
                    F = F + h * C1;
                g = aflint.t(1);
                i = 2L;
                while (!(i >= n - k))
                {
                    for (j = 1L; j <= 2L; j++)
                    {
                        // C = b2 * (1 - 1 / i) * (a * g * d * C1 + C0)
                        C = b2 * (one - one / i) * (a * g * d * C1 + C0);
                        C0 = C1;
                        C1 = C;
                        i = i + 1L;
                        g = one / (g * (i - 2L));
                    }
                    if (k == 0L)
                        F = F + C0;
                    else
                        F = F + h * C1;
                }
            }
            LeftTail = F;
            RightTail = 1 - F;
            return F;
        }


        #endregion









        // **********************************************************************
        // Doubly noncentral F cdf
        // '**********************************************************************

        #region DoublyNoncentralF


        public static void aflint_LugannaniRice(Arb w, Arb U, Arb k2, Arb k3, Arb k4, ref Arb density, ref Arb LeftTail, ref Arb RightTail)
        {
            Arb w1;
            Arb U1;
            Arb Adj1;
            Arb Adj;
            w1 = 1 / w;
            U1 = 1 / U;
            k3 = k3 / (k2 * aflint.sqrt(k2));
            k4 = k4 / (k2 * k2);
            Adj1 = 0.125d * k4 - 5 * k3 * k3 / 24;
            Adj = U1 * Adj1 - U1 * U1 * U1 - 0.5d * k3 * U1 * U1 + w1 * w1 * w1;

            // ERROR: !!!! Calculation in double precision !!!!
            double argLeftTail = LeftTail.AsDouble();
            double argRightTail = RightTail.AsDouble();
            double argdensity = density.AsDouble();
            DistMain.ndis2(false, w.AsDouble(), ref argLeftTail, ref argRightTail, ref argdensity);
            LeftTail = LeftTail + density * (w1 - U1 - Adj);
            RightTail = RightTail - density * (w1 - U1 - Adj);
            // density = density * S * U1 * v2 * (t2 * v2 + N2) * (1 - 2 * Adj1 / 3)

        }


        public static Arb aflint_JensenR(Arb w, Arb U)
        {
            return w + 1 / w * aflint.log(U / w);
        }


        public static void aflint_Jensen(Arb w, Arb U)
        {
            Arb r;
            var lefttail1 = default(Arb);
            var RightTail1 = default(Arb);
            var density1 = default(Arb);
            r = aflint_JensenR(w, U);

            // ERROR: !!!! Calculation in double precision !!!!
            double argLeftTail = lefttail1.AsDouble();
            double argRightTail = RightTail1.AsDouble();
            double argdensity = density1.AsDouble();
            DistMain.ndis2(false, r.AsDouble(), ref argLeftTail, ref argRightTail, ref argdensity);
            Console.WriteLine("Lr_s: {0}, R: {1}", lefttail1, RightTail1);
        }



        public static void aflint_FdisnCalcSaddlepoint(ref Arb S, Arb N1, Arb N2, Arb F, Arb t1, Arb t2)
        {
            var Pi = aflint.pi();
            Arb f2;
            Arb n22;
            Arb n12;
            Arb a;
            Arb a0;
            Arb A1;
            Arb A2;
            Arb Q;
            Arb p;

            f2 = F * F;
            n22 = N2 * N2;
            n12 = N1 * N1;

            if (t1 * t2 != 0)
            {
                a = 1 / (8 * f2 * n22 * (N1 + N2));
                a0 = (F * t2 * n12 - (1 - F) * n12 * N2 - N1 * N2 * t1) * a;
                A1 = (2 * (n22 * N1 + n12 * N2 * f2) - 4 * F * N1 * N2 * (N1 + N2 + t1 + t2)) * a;
                A2 = (8 * F * (1 - F) * N1 * n22 + 4 * F * (N2 * n22 + t2 * n22 - n12 * N2 * F - N1 * N2 * t1 * F)) * a / 3;
                p = aflint.sqrt(aflint.abs(A1 - 3 * A2 * A2) / 3);
                Q = A2 * (2 * A2 * A2 - A1) + a0;
                S = -2 * p * aflint.cos((aflint.acos(-Q / (2 * p * p * p)) + Pi) / 3) - A2;
            }
            else if (t1 > 0)
            {
                p = f2 * N1 * n12 + 2 * f2 * n12 * t1 + 2 * n12 * F * N2 + 4 * f2 * N1 * N2 * t1 + N1 * t1 * t1 * f2 + 2 * N1 * t1 * F * N2 + n22 * N1 + 4 * F * n22 * t1;
                S = (F * N1 * (N1 + 2 * N2 + t1) - N1 * N2 - aflint.sqrt(N1 * p)) / (4 * N2 * F * (N1 + N2));
            }
            else
            {
                S = N1 * (F - 1) / (2 * F * (N1 + N2));
            }



        }



        public static void aflint_FdisNCalcSaddlepointCum(Arb S, Arb N1, Arb N2, Arb F, Arb t1, Arb t2, ref Arb k, ref Arb k1, ref Arb k2, ref Arb k3, ref Arb k4, ref Arb w, ref Arb U)
        {

            Arb l1;
            Arb l2;
            Arb v1;
            Arb v2;
            Arb g1;
            Arb g2;
            Arb H1;
            Arb h2;
            Arb g12;
            Arb g22;
            l1 = N2 / N1;
            l2 = -F;
            v1 = 1 / (1 - 2 * S * l1);
            v2 = 1 / (1 - 2 * S * l2);
            g1 = l1 * v1;
            g2 = l2 * v2;
            H1 = t1 * v1;
            h2 = t2 * v2;
            g12 = g1 * g1;
            g22 = g2 * g2;

            k = 0.5d * (N1 * aflint.log(v1) + N2 * aflint.log(v2)) + S * (t1 * g1 + t2 * g2);
            k1 = g1 * (N1 + H1) + g2 * (N2 + h2);
            k2 = 2 * (g12 * (N1 + 2 * H1) + g22 * (N2 + 2 * h2));
            k3 = 8 * (g1 * g12 * (N1 + 3 * H1) + g2 * g22 * (N2 + 3 * h2));
            k4 = 48 * (g12 * g12 * (N1 + 4 * H1) + g22 * g22 * (N2 + 4 * h2));

            U = S * aflint.sqrt(k2);
            w = aflint_sign(S) * aflint.sqrt(2 * (S * k1 - k));

            // Debug.Print "K1: ", k1
            // Debug.Print "s: ", S
            Arb C;
            Arb f2;
            Arb a;
            Arb b;
            Arb Q;
            if (t2 == 0)
            {
                Console.WriteLine("Linear");
                C = -(g1 * (N1 + H1)) / N2;
                f2 = -C / (1 + 2 * S * C);
                Console.WriteLine("F2: {0}", f2);
            }
            else
            {
                Console.WriteLine("Quadratic");
                C = -(g1 * (N1 + H1));
                a = 4 * C * S * S + 2 * S * N2;
                b = -(4 * C * S + t2 + N2);
                Q = aflint.sqrt(b * b - 4 * a * C) / (2 * a);
                Console.WriteLine("F1: {0}", -(b / (2 * a)) + Q, -(b / (2 * a)) - Q);
                f2 = a * (l2 * l2) + b * l2 + C;
            }

        }



        public static void ArbestFdisnPaolella(Arb N1, Arb N2, Arb F, Arb t1, Arb t2, ref Arb density, ref Arb LeftTail, ref Arb RightTail)
        {
            var S = default(Arb);
            var w = default(Arb);
            var U = default(Arb);
            var k = default(Arb);
            var k1 = default(Arb);
            var k2 = default(Arb);
            var k3 = default(Arb);
            var k4 = default(Arb);

            aflint_FdisnCalcSaddlepoint(ref S, N1, N2, F, t1, t2);
            aflint_FdisNCalcSaddlepointCum(S, N1, N2, F, t1, t2, ref k, ref k1, ref k2, ref k3, ref k4, ref w, ref U);
            aflint_LugannaniRice(w, U, k2, k3, k4, ref density, ref LeftTail, ref RightTail);
            aflint_Jensen(w, U);
        }




        public static void aflint_Doubly_Fdisn(Arb N1, Arb n2, Arb F, Arb Theta1, Arb Theta2, ref Arb left, ref Arb Right)
        {
            Arb l2;
            Arb q;
            Arb x;
            Arb sum;
            long k;
            Arb summand;
            Arb RelError;
            Arb Result;
            Arb y;
            Arb a;
            Arb b;
            var l = default(Arb);
            var r = default(Arb);
            l2 = Theta2 / 2;
            q = aflint.t(1);
            x = N1 * F / (n2 + N1 * F);
            y = n2 / (N1 * F + n2);
            a = N1 / 2;
            b = n2 / 2;
            aflint_Betadisn(a, b, x, y, Theta1, ref l, ref r);
            sum = l;
            k = 0L;
            // Console.WriteLine("sum0: {0}", sum)
            do
            {
                k = k + 1L;
                q = q * l2 / k;
                aflint_Betadisn(a, b + k, x, y, Theta1, ref l, ref r);
                summand = q * l;
                sum = sum + summand;
                RelError = summand / sum;
            }
            // Console.WriteLine("k: {0}, sum: {1}, summand: {2}, RelError: {3}", k, sum, summand, RelError)
            while (aflint.abs(RelError) >= aflint.t(0.00000000000001d));
            // Console.WriteLine("k: {0}, sum: {1}, summand: {2}, RelError: {3}", k, sum, summand, RelError)

            Result = aflint.exp(-l2) * sum;
            left = Result;
            Right = 1 - left;
        }



        public static void aflint_Doubly_Fdisn_Paolella_Combined(Arb N1, Arb n2, Arb F, Arb t1, Arb t2, ref Arb density, ref Arb LeftTail, ref Arb Righttail)
        {
            const double eps = 0.1d;
            Arb sx;
            var density1 = default(Arb);
            var lefttail1 = default(Arb);
            var RightTail1 = default(Arb);
            var Density2 = default(Arb);
            var LeftTail2 = default(Arb);
            var RightTail2 = default(Arb);
            sx = (1 + t1 / N1) / (1 + t2 / n2);
            if (aflint.abs(F - sx) > eps)
            {
                ArbestFdisnPaolella(N1, n2, F, t1, t2, ref density, ref LeftTail, ref Righttail);
                return;
            }
            Console.WriteLine("Arb");
            ArbestFdisnPaolella(N1, n2, sx - eps, t1, t2, ref density1, ref lefttail1, ref RightTail1);
            ArbestFdisnPaolella(N1, n2, sx + eps, t1, t2, ref Density2, ref LeftTail2, ref RightTail2);
            density = density1 + (Density2 - density1) * (eps + F - sx) / (2d * eps);
            LeftTail = lefttail1 + (LeftTail2 - lefttail1) * (eps + F - sx) / (2d * eps);
            Righttail = RightTail1 + (RightTail2 - RightTail1) * (eps + F - sx) / (2d * eps);
        }



        public static Arb aflint_Doubly_Fdisn_2M(Arb f1, Arb f2, Arb x, Arb l1, Arb l2, ref Arb LeftTail, ref Arb Righttail)
        {
            Arb x1;
            Arb m1;
            Arb m2;
            Arb A1;
            Arb b1;
            Arb A2;
            Arb b2;
            // 2 moment approximation
            A1 = f1 + l1;
            b1 = A1 + l1;
            m1 = A1 * A1 / b1;
            A2 = f2 + l2;
            b2 = A2 + l2;
            m2 = A2 * A2 / b2;
            x1 = f1 * A2 * x / (A1 * f2);
            aflint_Fdis_a(m1, m2, x1, ref LeftTail, ref Righttail);
            return LeftTail;
        }


        public static Arb aflint_Doubly_Fdisnx_2M(Arb LeftTail, Arb Righttail, Arb f1, Arb f2, Arb l1, Arb l2)
        {
            Arb x1;
            Arb m1;
            Arb m2;
            Arb A1;
            Arb b1;
            Arb A2;
            Arb b2;
            // 2 moment approximation
            A1 = f1 + l1;
            b1 = A1 + l1;
            m1 = A1 * A1 / b1;
            A2 = f2 + l2;
            b2 = A2 + l2;
            m2 = A2 * A2 / b2;
            x1 = DistXArb.fdisxArb(LeftTail, Righttail, m1, m2);
            return x1 * A1 * f2 / (f1 * A2);
        }


        public static void aflint_Demo_Doubly_Fdisn()
        {
            Arb N1;
            Arb n2;
            Arb F;
            Arb t1;
            Arb t2;
            Arb eps;
            var l = default(Arb);
            var rt = default(Arb); // , rt2 As Arb , rt3 As Arb
            var density = default(Arb);
            var LeftTail = default(Arb);
            var Righttail = default(Arb);
            N1 = aflint.t(1);
            n2 = aflint.t(72);
            F = aflint.t(14.5d);
            t1 = aflint.t(10);
            t2 = aflint.t(10);
            eps = aflint.t(0.0000001d);
            aflint_Doubly_Fdisn_Paolella_Combined(N1, n2, F, t1, t2, ref density, ref LeftTail, ref Righttail);
            Console.WriteLine("L3:   {0}, R: {1}:", LeftTail, Righttail);
            aflint_Doubly_Fdisn(N1, n2, F, t1, t2, ref l, ref rt);
            Console.WriteLine("L_:   {0}, R: {1}:", l, rt);
            Console.WriteLine("Density: {0}:", density);

        }


        public static void aflint_Demo_Doubly_FdisnX()
        {
            Arb N1;
            Arb n2;
            //Arb F;
            Arb t1;
            Arb t2;
            var density = default(Arb);
            Arb LeftTail;
            Arb Righttail;
            Arb RefTail;
            Arb RelErr;
            var l1 = default(Arb);
            var r1 = default(Arb);
            Arb x;
            N1 = aflint.t(2);
            n2 = aflint.t(14);
            t1 = aflint.t(30);
            t2 = aflint.t(20);
            LeftTail = aflint.t(0.001d);
            Righttail = 1 - LeftTail;
            if (LeftTail < aflint.t("0.5"))
                RefTail = LeftTail;
            else
                RefTail = Righttail;
            x = aflint_Doubly_Fdisnx_2M(LeftTail, Righttail, N1, n2, t1, t2);
            Console.WriteLine("***************************************************************");
            Console.WriteLine("X: {0}", x);
            aflint_Doubly_Fdisn_2M(N1, n2, x, t1, t2, ref LeftTail, ref Righttail);
            Console.WriteLine("L0_x: {0}, R: {1}", LeftTail, Righttail);
            do
            {
                aflint_Doubly_Fdisn_Paolella_Combined(N1, n2, x, t1, t2, ref density, ref l1, ref r1);
                // Console.WriteLine("L3_x: {0}, R: {1}", l1, r1)
                l1 = l1 - LeftTail;
                RelErr = l1 / RefTail;
                x = x - l1 / density;
            }
            // Console.WriteLine("X: {0}, RelErr: {1}", x, RelErr)
            while (aflint.abs(RelErr) >= aflint.t(0.0000000001d));

            aflint_Doubly_Fdisn(N1, n2, x, t1, t2, ref l1, ref r1);
            Console.WriteLine("L3_x: {0}, R: {1}", l1, r1);
            l1 = l1 - LeftTail;
            RelErr = l1 / RefTail;
            Console.WriteLine("X: {0}, RelErr: {1}", x, RelErr);

        }





        #endregion






        // **********************************************************************
        // Doubly noncentral t cdf
        // '**********************************************************************

        #region DoublyNoncentralT

        public static void ArbDisN_Broda_Combined(Arb n, Arb t, Arb mu, Arb theta, ref Arb PDF, ref Arb LeftTail, ref Arb RightTail)
        {
            var eps = aflint.t("0.001");
            Arb sx, CDF = default(Arb);
            var PDF1 = default(Arb);
            var cdf1 = default(Arb);
            var PDF2 = default(Arb);
            var cdf2 = default(Arb);
            sx = mu / aflint.sqrt(1 + theta / n);
            if (aflint.abs(t - sx) > eps)
            {
                ArbDistDoublyNC_Broda_Combined(n, t, mu, theta, ref PDF, ref CDF);
            }
            else
            {
                ArbDistDoublyNC_Broda_Combined(n, sx - eps, mu, theta, ref PDF1, ref cdf1);
                ArbDistDoublyNC_Broda_Combined(n, sx + eps, mu, theta, ref PDF2, ref cdf2);
                PDF = PDF1 + (PDF2 - PDF1) * (eps + t - sx) / (2 * eps);
                CDF = cdf1 + (cdf2 - cdf1) * (eps + t - sx) / (2 * eps);
            }
            LeftTail = CDF;
            RightTail = 1 - CDF;
        }


        public static void ArbDistDoublyNC_Broda_Combined(Arb n, Arb y1, Arb mu, Arb theta, ref Arb PDF, ref Arb CDF)
        {
            Arb y13;
            Arb y14;
            Arb N2;
            Arb nu;
            Arb alpha;
            Arb t2;
            Arb Q;
            Arb r;
            Arb a;
            Arb C1;
            Arb c2;
            Arb C0;
            Arb y12;
            Arb y2;
            Arb t1;
            Arb d;
            Arb U;
            Arb w;
            y12 = y1 * y1;

            Console.WriteLine("y1: {0}", y1);

            if (theta != 0)
            {
                y13 = y12 * y1;
                y14 = y12 * y12;
                N2 = n * n;
                a = y14 + 2 * n * y12 + N2;
                c2 = (-2 * y13 * mu - 2 * y1 * n * mu) / a;
                C1 = (y12 * mu * mu - n * y12 - N2 - theta * n) / a;
                C0 = y1 * n * mu / a;
                Q = C1 / 3 - c2 * c2 / 9;
                r = (C1 * c2 - 3 * C0) / 6 - c2 * c2 * c2 / 27;
                y2 = aflint.sqrt(-4 * Q) * aflint.cos(1d / 3d * aflint.acos(r / aflint.sqrt(-Q * Q * Q))) - c2 / 3;
                t1 = -mu + y1 * y2;
                t2 = -y1 * t1 / (2 * n * y2);
                nu = 1 / (1 - 2 * t2);
                alpha = mu / aflint.sqrt(1 + theta / n);
                d = 1 / (t1 * y2);
                U = aflint.sqrt((y12 + 2 * n * t2) * (2 * n * nu * nu + 4 * theta * nu * nu * nu) + 4 * N2 * y2 * y2) / (2 * n * y2 * y2);
                w = aflint.sqrt(-mu * t1 - n * aflint.log(nu) - 2 * theta * nu * t2) * aflint_sign(y1 - alpha);
            }
            else if (mu != 0)
            {
                y2 = (mu * y1 + aflint.sqrt(4 * n * (y12 + n) + mu * mu * y12)) / (2 * (y12 + n));
                t1 = -mu + y1 * y2;
                t2 = -y1 * t1 / (2 * n * y2);
                d = 1 / (t1 * y2);
                U = aflint.sqrt((mu * y1 * y2 + 2 * n) / (2 * n)) / y2;
                w = aflint.sqrt(-mu * t1 - 2 * n * aflint.log(y2)) * aflint_sign(y1 - mu);
            }
            else
            {
                y2 = aflint.sqrt(n / (y12 + n));
                d = 1 / (y1 * y2 * y2);
                U = 1 / y2;
                w = aflint.sqrt(-2 * n * aflint.log(y2)) * aflint_sign(y1);
            }

            CDF = DistXArb.NdisArb(w) + DistXArb.NdensArb(w) * (1 / w - d / U);
            PDF = DistXArb.NdensArb(w) * (1 / U);
        }



        #endregion







        // **********************************************************************
        // Pearson's rho cdf
        // '**********************************************************************

        #region PearsonRho

        // Algorithm by Hotelling, 1953
        public static void aflint_RhoDisN2(Arb n, Arb r, Arb rho, Arb LeftTail, Arb RightTail)
        {
            Arb a; // , LeftTail2 As Arb
            Arb gf;
            Arb A1;
            Arb sum3;
            Arb summand;
            Arb RelError2;
            int m;
            int k;
            int smax;
            int j;
            int S;
            Arb RelError;
            Arb Q;
            Arb BK;
            Arb sign;
            Arb t2;
            Arb X;
            Arb y;
            Arb sum;
            Arb sum2;
            Arb Factor;
            Arb TWO;
            var fs = new Arb[2];
            var Betas = new Arb[2];
            var Dens = new Arb[2];
            Arb[] IBeta;
            Arb[] nk;
            bool Swapped;
            int slimit;
            int mlimit;
            slimit = 100;
            mlimit = 10;

            IBeta = new Arb[slimit + 1];
            nk = new Arb[mlimit + 1];
            Swapped = false;
            if (rho > r)
            {
                r = -r;
                rho = -rho;
                Swapped = true;
            }
            n = n - 1;
            smax = -1;

            // ERROR: constant needs to be in arbitrary precision !!!
            Q = (n - 1) * 0.398942280401433d;
            Q = Q * aflint.exp(aflint.lgamma(n) - aflint.lgamma(n + 0.5d));
            X = (r - rho) / (1 - rho * r);
            X = X * X;
            y = 1 - X;
            Factor = aflint.t(1);
            A1 = 1 - rho * rho;
            a = aflint.t(1);
            TWO = aflint.t(1);
            RelError = aflint.t(1);
            m = 0;
            sum3 = aflint.t(0);
            sum = aflint.t(0);
            while (aflint.abs(RelError) > aflint.t("0.0000000001"))
            {
                S = 0;
                gf = aflint.t(1);
                RelError2 = aflint.t(1);
                while (aflint.abs(RelError2) > aflint.t("0.0000000001"))
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
                            DistXArb.betadisArb(aflint.t(S + 1) / 2, (n - 1) / 2, X, y, ref LeftTail, ref Betas[j], ref Dens[j]);

                            // ERROR: Lnbeta needs to be in arbitrary precision !!!
                            fs[j] = aflint.exp(DistMain.Lnbeta((S + 1) / 2d, (n.AsDouble() - 1d) / 2d));
                            Dens[j] = 2 * y * Dens[j];
                        }
                        else
                        {
                            fs[j] = fs[j] * (S - 1) / (n + S - 2);
                            Dens[j] = Dens[j] * X / (S - 1);
                            Betas[j] = Betas[j] + Dens[j];
                            Dens[j] = Dens[j] * (n + S - 2);
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
                        if (sum3 != 0)
                            RelError2 = summand / sum3;
                    }
                    S = S + 1;
                }
                nk[m] = a * sum3 / 2;
                a = a * A1;
                if (m == 0)
                {
                    sum = nk[0];
                }
                else
                {
                    TWO = TWO * 2;
                    Factor = Factor * (2.0d * m - 1d) * (2.0d * m - 1d) / (m * 4 * (2 * n + 2 * m - 1));
                    sum2 = TWO * nk[0];
                    t2 = TWO;
                    sign = aflint.t(-1);
                    BK = aflint.t(1);
                    var loopTo = m;
                    for (k = 1; k <= loopTo; k++)
                    {
                        BK = BK * (m - k + 1) / k;
                        t2 = t2 / 2;
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
            LeftTail = 1 - RightTail;
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



        public static void aflint_RhoDisN1(int n, Arb r, Arb rho, Arb LeftTail, Arb RightTail)
        {
            Arb delta;
            Arb t;
            Arb result;
            t = r * aflint.sqrt((n - 2) / (1 - r * r));
            delta = rho * aflint.sqrt((n - 2) / (1 - rho * rho));
            // result = tdisn(n - 2, t, delta, LeftTail, RightTail)
            result = ArbdisnOwen(n - 2, t, delta, ref LeftTail, ref RightTail);

        }


        public static void aflint_demordisn_nc()
        {
            Arb LeftTail;
            Arb RightTail;
            Arb n; // , d As Arb, t As Arb, p As Arb, t2 As Arb, p2 As Arb
            Arb z;
            Arb RefTail; // , CDF As Arb, PDF As Arb, i As Long, RelErr As Arb
            Arb rho_alpha;
            Arb rho;
            Arb rTail; // , d_rho  As Arb, t_delta As Arb
            LeftTail = aflint.t(0.99d);
            RightTail = 1 - LeftTail;
            if (LeftTail < aflint.t("0.5"))
                RefTail = LeftTail;
            else
                RefTail = RightTail;
            z = DistXArb.ndisxArb(LeftTail, RightTail);
            n = aflint.t(14);
            rho = aflint.t(0.6d);

            // Debug.Print "****************************************************************"

            rho_alpha = aflint_Rhodis_NC(n, rho, LeftTail, RightTail);
            Console.WriteLine("rho_alpha W: {0}, {1}, {2}, {3}", rho_alpha, 1 - rho_alpha, LeftTail, RightTail);

            rTail = aflint_RhoDis_W(rho, n, rho_alpha);
            Console.WriteLine("rTail: {0}", rTail);


        }





        public static Arb aflint_CornishFisher4_kappa(Arb z, Arb k1, Arb k2, Arb k3, Arb k4)
        {
            Arb U;
            Arb u2;
            Arb u3;
            Arb X;
            Arb g1;
            Arb g2;
            g1 = k3 / (aflint.sqrt(k2) * k2);
            g2 = k4 / (k2 * k2);
            U = (z - k1) / aflint.sqrt(k2);
            u2 = U * U;
            u3 = U * u2;
            X = U - (u2 - 1) * g1 / 6 - (u3 - 3 * U) * g2 / 24 + (4 * u3 - 7 * U) * g1 * g1 / 36;
            return DistXArb.NdisArb(X);
        }


        public static Arb aflint_CornishFisher4_kappa_X(Arb LeftTail, Arb RightTail, Arb k1, Arb k2, Arb k3, Arb k4)
        {
            Arb U;
            Arb u2;
            Arb u3;
            Arb X;
            Arb g1;
            Arb g2;
            g1 = k3 / (aflint.sqrt(k2) * k2);
            g2 = k4 / (k2 * k2);
            U = DistXArb.ndisxArb(LeftTail, RightTail);
            u2 = U * U;
            u3 = U * u2;
            X = U + (u2 - 1) * g1 / 6 + (u3 - 3 * U) * g2 / 24 + (2 * u3 - 5 * U) * g1 * g1 / 36;
            return k1 + aflint.sqrt(k2) * X;
        }


        public static Arb aflint_Fisher_kappa_X(Arb LeftTail, Arb RightTail, Arb n, Arb rho)
        {
            Arb Rho2;
            Arb rho3;
            Arb rho4;
            Arb N1;
            Arb N2;
            Arb n3;
            Arb k1;
            Arb k2;
            Arb k3;
            Arb k4;
            Arb y; // , e As Arb
                   // Note: n = sample size
            N1 = n - 1;
            N2 = N1 * N1;
            n3 = N2 * N1;
            Rho2 = rho * rho;
            rho3 = Rho2 * rho;
            rho4 = Rho2 * Rho2;
            k1 = 0.5d * aflint.log((1 + rho) / (1 - rho)) + rho * (1 + (5 + Rho2) / (4 * N1) + (11 + 2 * Rho2 + 3 * rho4) / (8 * N2)) / (2 * N1);
            k2 = (1 + (4 - Rho2) / (2 * N1) + (22 - 6 * Rho2 - 3 * rho4) / (6 * N2)) / N1;
            k3 = rho3 / n3;
            k4 = 2 / n3;
            y = aflint_CornishFisher4_kappa_X(LeftTail, RightTail, k1, k2, k3, k4);
            return aflint_zTransformInverse(y);
        }

        public static Arb aflint_zTransformInverse(Arb y)
        {
            y = aflint.exp(2 * y);
            return (y - 1) / (y + 1);
        }

        public static Arb aflint_zTransform(Arb r)
        {
            return 0.5d * aflint.log((1 + r) / (1 - r));
        }

        public static Arb aflint_Fisher_simple(Arb r, Arb n, Arb rho)
        {
            Arb X;
            X = (aflint_zTransform(r) - aflint_zTransform(rho)) * aflint.sqrt(n - 3);
            return DistXArb.NdisArb(X);
        }



        public static Arb aflint_Fisher_simple_X(Arb LeftTail, Arb RightTail, Arb n, Arb rho)
        {
            Arb k1;
            Arb U;
            Arb y; // , e As Arb
            U = DistXArb.ndisxArb(LeftTail, RightTail);
            k1 = aflint_zTransform(rho);
            // k1 = 0.5 * Log((1 + rho) / (1 - rho))
            y = U / aflint.sqrt(n - 3) + k1;
            return aflint_zTransformInverse(y);
        }

        public static void aflint_DemoFisher_kappa_X()
        {
            Arb LeftTail;
            Arb RightTail;
            Arb r;
            Arb n;
            Arb rho;
            Arb result;
            var lefttail1 = default(Arb);
            var RightTail1 = default(Arb);
            n = aflint.t(17);
            rho = aflint.t(-0.714d);
            LeftTail = aflint.t(0.90000005d);
            RightTail = 1 - LeftTail;
            Console.WriteLine("----------------------");
            r = aflint_Fisher_simple_X(LeftTail, RightTail, n, rho);
            Console.WriteLine("r_alpha: {0}, {1}", r, 1 - r);
            result = aflint_Fisher_simple(r, n, rho);
            Console.WriteLine("Fishersimp: {0} ", result);
            aflint_RhoDisN2(n, r, rho, lefttail1, RightTail1);
            Console.WriteLine("LeftTail {0}", lefttail1);

            r = aflint_Fisher_kappa_X(LeftTail, RightTail, n, rho);
            Console.WriteLine("r_alpha: {0}, {1}", r, 1 - r);
            result = aflint_Fisher_kappa(r, n, rho);
            Console.WriteLine("Fisherk:  {0}", result);

            aflint_RhoDisN2(n, r, rho, lefttail1, RightTail1);
            Console.WriteLine("LeftTail: {0}", lefttail1);

            r = aflint_Rhodisx_W(LeftTail, RightTail, n, rho);
            Console.WriteLine("r_alpha W: {0}, {1}, {2}, {3}, {4}, {5}", r, 1 - r, LeftTail, RightTail, n, rho);

            lefttail1 = aflint_RhoDis_W(r, n, rho);
            Console.WriteLine("LeftTail W: {0}", lefttail1);

            aflint_RhoDisN2(n, r, rho, lefttail1, RightTail1);
            Console.WriteLine("LeftTail W: {0}", lefttail1);

        }

        public static Arb aflint_Fisher_kappa(Arb r, Arb n, Arb rho)
        {
            Arb Rho2;
            Arb rho3;
            Arb rho4;
            Arb N1;
            Arb N2;
            Arb n3;
            Arb z;
            Arb k1;
            Arb k2;
            Arb k3;
            Arb k4;
            // Note: n = sample size
            N1 = n - 1;
            N2 = N1 * N1;
            n3 = N2 * N1;
            Rho2 = rho * rho;
            rho3 = Rho2 * rho;
            rho4 = Rho2 * Rho2;
            z = 0.5d * aflint.log((1 + r) / (1 - r));
            k1 = 0.5d * aflint.log((1 + rho) / (1 - rho)) + rho * (1 + (5 + Rho2) / (4 * N1) + (11 + 2 * Rho2 + 3 * rho4) / (8 * N2)) / (2 * N1);
            k2 = (1 + (4 - Rho2) / (2 * N1) + (22 - 6 * Rho2 - 3 * rho4) / (6 * N2)) / N1;
            k3 = rho3 / n3;
            k4 = 2 / n3;
            return aflint_CornishFisher4_kappa(z, k1, k2, k3, k4);
        }


        public static Arb aflint_CornishFisher4_kappa2(Arb z, Arb k1, Arb k2, Arb k3, Arb k4, Arb k6)
        {
            Arb U;
            Arb u2;
            Arb u3;
            Arb u4;
            Arb u5;
            Arb X;
            Arb g1;
            Arb g2;
            Arb g4;
            g1 = k3 / (aflint.sqrt(k2) * k2);
            g2 = k4 / (k2 * k2);
            g4 = k6 / (k2 * k2 * k2);
            U = (z - k1) / aflint.sqrt(k2);
            u2 = U * U;
            u3 = U * u2;
            u5 = u3 * u2;
            u4 = u2 * u2;
            X = U - (u2 - 1) * g1 / 6 - (u3 - 3 * U) * g2 / 24 + (4 * u3 - 7 * U) * g1 * g1 / 36;
            X = X + (11 * u4 - 42 * u2 + 15) * g1 * g2 / 144;
            X = X - (u5 - 10 * u3 + 15 * U) * g4 / 720;
            return DistXArb.NdisArb(X);
        }


        public static Arb aflint_Fisher_kappa2(Arb r, Arb n, Arb rho)
        {
            Arb Rho2;
            Arb rho3;
            Arb rho4;
            Arb N1;
            Arb N2;
            Arb n3;
            Arb z;
            Arb k1;
            Arb k2;
            Arb k3;
            Arb k4;
            Arb k6;
            // Note: n = sample size
            N1 = n - 1;
            N2 = N1 * N1;
            n3 = N2 * N1;
            Rho2 = rho * rho;
            rho3 = Rho2 * rho;
            rho4 = Rho2 * Rho2;
            z = 0.5d * aflint.log((1 + r) / (1 - r)) - 0.5d * aflint.log((1 + rho) / (1 - rho));
            k1 = rho * (1 + (5 + Rho2) / (4 * N1) + (11 + 2 * Rho2 + 3 * rho4) / (8 * N2)) / (2 * N1);
            k2 = (1 + (4 - Rho2) / (2 * N1) + (22 - 6 * Rho2 - 3 * rho4) / (6 * N2)) / N1;
            k3 = rho3 / n3;
            k4 = 2 / n3 + 3 * (4 - rho4) / (N2 * N2);
            k6 = 24 / (n3 * N2);
            k6 = aflint.t(0);
            return aflint_CornishFisher4_kappa2(z, k1, k2, k3, k4, k6);
        }


        // These approximations are sensitive to whether rho and or r are negative. Still need to figure out the details!!!

        // Algorithm by Winterbottom, 1980
        public static Arb aflint_RhoDis_W(Arb r, Arb n, Arb rho)
        {
            Arb y;
            Arb m;
            Arb w;
            Arb r2;
            Arb r3;
            Arb r4;
            Arb m2;
            Arb w2;
            Arb w3;
            Arb w5;
            r2 = r * r;
            r3 = r2 * r;
            r4 = r2 * r2;
            m = n - 1;
            m2 = m * m;
            w = aflint_zTransform(r) - aflint_zTransform(rho);
            w2 = w * w;
            w3 = w2 * w;
            w5 = w2 * w3;
            y = -r / (2 * m) - (3 * r + r3) / (12 * m2);
            y = y + (1 - (1 + r2) / (4 * m) + (3 - 11 * r4) / (96 * m2)) * w;
            y = y + (3 * r - 4 * r3) / (24 * m) * w2;
            y = y - (1d / 12d - (2 + 7 * r2 - 6 * r4) / (48 * m)) * w3;
            y = y + 3d / 160d * w5;
            return DistXArb.NdisArb(aflint.sqrt(m) * y);
        }



        // Algorithm by Winterbottom, 1980
        public static Arb aflint_Rhodisx_W(Arb LeftTail, Arb RightTail, Arb n, Arb rho)
        {
            Arb y;
            Arb X;
            Arb m;
            Arb m2;
            Arb m12;
            Arb m32;
            Arb m52;
            Arb Rho2;
            Arb rho3;
            Arb rho4;
            Arb z;
            Arb x2;
            Arb x3;
            Arb x4;
            Arb x5;
            X = DistXArb.ndisxArb(LeftTail, RightTail);
            z = aflint_zTransform(rho);
            // z = 0.5 * Log((1 + rho) / (1 - rho))
            m = n - 1;
            m2 = m * m;
            m12 = aflint.sqrt(m);
            m32 = m * m12;
            m52 = m2 * m12;
            x2 = X * X;
            x3 = x2 * X;
            x4 = x3 * X;
            x5 = x4 * X;
            Rho2 = rho * rho;
            rho3 = Rho2 * rho;
            rho4 = rho3 * rho;
            y = z + X / m12 + rho / (2 * m);
            y = y + (x3 + 3 * (3 - Rho2) * X) / (12 * m32);
            y = y + (4 * rho3 * x2 - rho3 + 15 * rho) / (24 * m2);
            y = y + (x5 + (-60 * rho4 + 30 * Rho2 + 80) * x3 + (45 * rho4 - 21 * Rho2 + 375) * X) / (480 * m52);
            return aflint_zTransformInverse(y);
            // Rhodisx_W = (Exp(2 * y) - 1) / (Exp(2 * y) + 1)
        }



        // Algorithm by Winterbottom, 1980
        public static Arb aflint_Rhodis_NC(Arb n, Arb r, Arb LeftTail, Arb RightTail)
        {
            Arb y;
            Arb X;
            Arb m;
            Arb m2;
            Arb m12;
            Arb m32;
            Arb m52;
            Arb r2;
            Arb r3;
            Arb r4;
            Arb z;
            Arb x2;
            Arb x3;
            Arb x4;
            Arb x5;
            X = DistXArb.ndisxArb(LeftTail, RightTail);
            z = aflint_zTransform(r);
            // z = 0.5 * Log((1 + r) / (1 - r))
            m = n - 1;
            m2 = m * m;
            m12 = aflint.sqrt(m);
            m32 = m * m12;
            m52 = m2 * m12;
            x2 = X * X;
            x3 = x2 * X;
            x4 = x3 * X;
            x5 = x4 * X;
            r2 = r * r;
            r3 = r2 * r;
            r4 = r3 * r;
            y = z + X / m12 - r / (2 * m);
            y = y + (x3 + 3 * (1 + r2) * X) / (12 * m32);
            y = y - (4 * r3 * x2 + 5 * r3 + 9 * r) / (24 * m2);
            y = y + (x5 + (60 * r4 - 30 * r2 + 20) * x3 + (165 * r4 + 30 * r2 + 15) * X) / (480 * m52);
            return aflint_zTransformInverse(y);
            // Rhodis_NC = (Exp(2 * y) - 1) / (Exp(2 * y) + 1)
        }






        public static void aflint_DemoRhoExplicit()
        {
            int n;
            Arb r;
            Arb rho;
            Arb result;
            var LeftTail = default(Arb);
            Arb density;
            // Smallest N: N = 3
            n = 6;
            r = aflint.t(0.1d);
            rho = aflint.t(0.99d);
            result = DemoPearsonArb.RhoExplicit_Arb(n, r, rho);
            // Call RhoDisN2(n, r, rho, LeftTail, RightTail)
            // Debug.Print LeftTail, RightTail
            Console.WriteLine("result: {0}, result / LeftTail: {1}", result, result / LeftTail);
            density = aflint_RhoDensity(n, r, rho);
            Console.WriteLine("density: {0}", density);
        }


        public static Arb aflint_RhoDensity(long n, Arb r, Arb rho)
        {
            Arb w;
            Arb t;
            Arb X;
            Arb x2;
            Arb r2;
            Arb Rho2;
            Arb U;
            Arb k1;
            Arb A2;
            Arb a;
            Arb c2;
            Arb C;
            Arb b2;
            Arb b;
            Arb ACTerm;
            Arb density;

            const double Pi = 3.14159265358979d;
            r2 = r * r;
            Rho2 = rho * rho;
            X = r * rho;
            x2 = X * X;
            w = 0.5d * (1 + X);
            A2 = 1 - Rho2;
            a = aflint.sqrt(A2);
            c2 = 1 - r2;
            C = aflint.sqrt(c2);
            b2 = 1 - x2;
            b = aflint.sqrt(b2);
            U = aflint.acos(-X) / b;

            t = Arb1(aflint.t(n), w);
            k1 = (n - 2L) / aflint.sqrt(2d * Pi) * aflint.exp(DistMain.LnGamma(n - 1L) - DistMain.LnGamma(n - 0.5d));
            ACTerm = aflint.exp(aflint.log(a) * (n - 1L) + aflint.log(C) * (n - 4L) + aflint.log(1 - X) * (1.5d - n));
            density = k1 * ACTerm * t;
            return density;

        }


        // Hypergeometric function for density of pearson's rho
        public static Arb Arb1(Arb n, Arb w)
        {
            int i;
            Arb A1;
            Arb C1;
            Arb m1;
            Arb sum;
            Arb RelErr;
            A1 = aflint.t(0.5d);
            C1 = n - 0.5d;
            m1 = 0.25d * w / C1;
            sum = 1 + m1;
            i = 1;
            do
            {
                i = i + 1;
                A1 = A1 + 1;
                C1 = C1 + 1;
                m1 = m1 * A1 * A1 * w / (C1 * i);
                sum = sum + m1;
                RelErr = m1 / sum;
            }
            // Debug.Print i, sum, M1, M1 / sum
            while (RelErr >= aflint.t("1E-15"));
            return sum;
        }




        // Algorithm by Guenther
        public static void aflint_RhoDisN5(Arb n, Arb r, Arb rho, ref Arb LeftTail, ref Arb RightTail)
        {
            const double Pi = 3.14159265358979d;
            Arb sign;
            Arb r2;
            Arb Rho2;
            var Left1 = default(Arb);
            var Right1 = default(Arb);
            Arb RelError;
            Arb summand;
            Arb sum0;
            Arb sum1;
            Arb sum2;
            Arb k1;
            Arb k2;
            var density = default(Arb);
            long j;
            Arb sum4;
            Arb sum3;
            Arb RelError3;
            Rho2 = rho * rho;
            r2 = r * r;
            if (rho < 0)
                sign = aflint.t(-1);
            else
            {
                if (rho > 0)
                    sign = aflint.t(1);
                else
                    sign = aflint.t(0);
            }
            DistXArb.betadisArb(aflint.t(1d / 2d), (n - 1) / 2, Rho2, 1 - Rho2, ref Left1, ref Right1, ref density);
            sum0 = 0.5d * (1 + sign * Left1);
            if (r == 0)
            {
                RightTail = sum0;
                LeftTail = 1 - RightTail;
                return;
            }
            k1 = 0.5d * aflint.exp(aflint.log(1 - Rho2) * (n - 1) / 2);
            DistXArb.betadisArb(aflint.t(1d / 2d), (n - 2) / 2, r2, 1 - r2, ref Left1, ref Right1, ref density);
            sum1 = k1 * Left1;
            sum3 = k1 * Right1;
            j = 0L;
            RelError = aflint.t(1);
            RelError3 = aflint.t(1);
            while (RelError > aflint.t("1E-15"))
            {
                j = j + 1L;
                k1 = (2L * j + n - 3) / (2L * j) * Rho2 * k1;
                DistXArb.betadisArb(aflint.t(2L * j + 1L) / 2, (n - 2) / 2, r2, 1 - r2, ref Left1, ref Right1, ref density);
                summand = k1 * Left1;
                sum1 = sum1 + summand;
                RelError = summand / sum1;
                summand = k1 * Right1;
                sum3 = sum3 + summand;
                if (sum3 != 0)
                    RelError3 = summand / sum3;
                // Debug.Print j, sum1, RelError, Left1
                // Debug.Print j, sum3, RelError3, Right1
            }
            // Debug.Print "Gunther j1:", j
            if (rho == 0)
            {
                sum2 = aflint.t(0);
                sum4 = aflint.t(0);
            }
            else
            {
                k2 = rho / aflint.sqrt(Pi) * aflint.exp(aflint.lgamma(n / 2) - aflint.lgamma((n - 1) / 2) + aflint.log(1 - Rho2) * (n - 1) / 2);
                DistXArb.betadisArb(aflint.t(1), (n - 2) / 2, r2, 1 - r2, ref Left1, ref Right1, ref density);
                sum2 = k2 * Left1;
                sum4 = k2 * Right1;
                j = 0L;
                RelError = aflint.t(1);
                RelError3 = aflint.t(1);
                while (RelError > aflint.t("1E-15"))
                {
                    j = j + 1L;
                    k2 = (2L * j + n - 2) / (2L * j + 1L) * Rho2 * k2;
                    DistXArb.betadisArb(aflint.t(j + 1L), (n - 2) / 2, r2, 1 - r2, ref Left1, ref Right1, ref density);
                    summand = k2 * Left1;
                    sum2 = sum2 + summand;
                    if (sum2 != 0)
                        RelError = summand / sum2;
                    summand = k2 * Right1;
                    sum4 = sum4 + summand;
                    if (sum4 != 0)
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
            LeftTail = 1 - sum0 + (sum1 + sum2);
        }



        public static void aflint_demoRho_Guenther()
        {
            Arb result;
            int n;
            Arb rho;
            Arb r; // , X As Arb, y As Arb
            Arb LeftTail;
            Arb RightTail; // , l2 As Arb, r2 As Arb
            n = 7;
            r = aflint.t(0.236d);
            rho = aflint.t(0.9d);
            RightTail = aflint.t(0.05d);
            LeftTail = 1 - RightTail;
            // r = RhoDisX0(LeftTail, RightTail, n)
            Console.WriteLine("r: {0}", r);
            aflint_RhoDisN5(aflint.t(n), r, rho, ref LeftTail, ref RightTail);
            Console.WriteLine("Guenther: {0}, {1} ", LeftTail, RightTail);
            // Debug.Print ndisx(LeftTail, RightTail)
            // LeftTail = tdisn(N - 2, R * Sqr((N - 2) / (1 - R * R)), 0, L2, R2)
            // RightTail = 1 - LeftTail
            // Debug.Print LeftTail, RightTail
            // Call RhoDisN2(n, r, rho, LeftTail, RightTail)
            // Debug.Print "Hotelling: ", LeftTail, RightTail
            LeftTail = DemoPearsonArb.RhoExplicit_Arb(n, r, rho);
            Console.WriteLine("RhoExplicit: {0}, {1} ", LeftTail, 1 - LeftTail);

            // result = Rhodis_B(r, n, rho)
            // Debug.Print "Fisherb:  ", result
            // result = Rhodis_B_2(r, n, rho)
            // Debug.Print "Fisherb2:  ", result
            // 
            result = aflint_Fisher_kappa(r, aflint.t(n), rho);
            Console.WriteLine("Fisherk: {0} ", result);
            result = aflint_Fisher_kappa2(r, aflint.t(n), rho);
            Console.WriteLine("Fisherk2: {0} ", result);

        }


        #endregion








        // **********************************************************************
        // Rho2 cdf
        // '**********************************************************************


        #region Rho2

        public static Arb aflint_Rho2DisN8(bool IsGLM, Arb p, Arb n, Arb X, Arb Rho2)
        {
            var LeftTail = default(Arb);
            var RightTail = default(Arb);
            // p: df1=# of variables-1
            // N: df2=# of observatons - # of variables
            aflint_R2DisN(IsGLM, p, n, X, Rho2, ref LeftTail, ref RightTail);
            return LeftTail;
        }


        public static void aflint_R2DisN(bool IsGLM, Arb p, Arb n, Arb X, Arb Rho2, ref Arb LeftTail, ref Arb RightTail)
        {
            // p: df1=# of variables-1
            // N: df2=# of observatons - # of variables
            p = p + 1;
            if (IsGLM)
            {
                aflint_RHO2_EXACT_I(X, p, n + p, Rho2, ref LeftTail, ref RightTail);
            }
            else
            {
                aflint_RHO2_EXACT(false, X, p, n + p, Rho2, ref LeftTail, ref RightTail);
            }
        }




        public static void aflint_RHO2_EXACT(bool IsOdd, Arb X, Arb p, Arb ng, Arb Rho2, ref Arb LeftTail, ref Arb RightTail)
        {
            Arb p1;
            Arb y;
            Arb summand;
            Arb RelErr;
            Arb k;
            Arb a;
            Arb n;
            var density = default(Arb);
            Arb BK;
            Arb t1;
            Arb theta;
            Arb b;
            Arb cj;
            var lefttail1 = default(Arb);
            var RightTail1 = default(Arb);
            Arb sum;
            Arb binom;
            long j;

            a = 1.0d / (1 - Rho2);
            n = ng - 1;
            k = (ng - p) / 2;
            if (IsOdd)
            {
                theta = -Rho2;
                b = aflint.t(1);
                BK = -n / 2;
            }
            else
            {
                theta = Rho2 / (1 - Rho2);
                b = a;
                BK = k;
            }
            // {  cj=1}
            p1 = (p - 1) / 2;
            binom = aflint.t(1);
            t1 = aflint.t(1);
            y = 2 * k * X / (b * (1 - X));
            y = y / (y + 2 * k);
            DistXArb.betadisArb(p1, k, y, 1 - y, ref lefttail1, ref RightTail1, ref density);
            sum = lefttail1;
            j = 1L;
            do
            {
                binom = binom * (BK - j + 1) / j;
                t1 = t1 * theta;
                cj = binom * t1;
                DistXArb.betadisArb(p1 + j, k, y, 1 - y, ref lefttail1, ref RightTail1, ref density);
                summand = cj * lefttail1;
                sum = sum + summand;
                RelErr = summand / sum;
                j = j + 1L;
            }
            while (RelErr >= aflint.t("0.000000000001"));
            if (!IsOdd)
                sum = sum * aflint.exp(aflint.log(b) * (p - 1) / 2);
            sum = sum / aflint.exp(aflint.log(a) * n / 2);
            LeftTail = sum;
            RightTail = 1 - sum;
        }

        public static void aflint_RHO2_EXACT_I(Arb X, Arb p, Arb ng, Arb Rho2, ref Arb LeftTail, ref Arb RightTail)
        {
            Arb y;
            Arb lambda;
            Arb DF1;
            Arb DF2; // , l1 As Arb, r1 As Arb
            y = X / (1 - X) * (ng - p) / (p - 1);
            lambda = Rho2 * (ng - p) / (1 - Rho2);
            DF1 = p - 1;
            DF2 = ng - p;
            RightTail = aflint_Fdisn(DF1, DF2, y, lambda);
            LeftTail = 1 - RightTail;
            // LeftTail = Fdisn(DF1, DF2, y, lambda, l1, r1)
            // RightTail = 1 - LeftTail

        }

        #endregion




        public static void aflint_DemoNoncentral()
        {
            ArbPrec.SetDps(60);
            var eps = aflint.epsilon();
            Console.WriteLine("eps: {0}", eps);

            Arb nu = new Arb(), mu = new Arb(), a = new Arb(), b = new Arb(), x = new Arb(), nc = new Arb(), nc2 = new Arb(), xbeta = new Arb(), ybeta = new Arb(), LeftTail0 = new Arb(), RightTail0 = new Arb();
            Arb LeftTail1 = new Arb(), RightTail1 = new Arb();
            Arb LeftTail2 = new Arb(), RightTail2 = new Arb();
            Arb LeftTail3 = new Arb(), RightTail3 = new Arb();
            //double LeftTail3d, RightTail3d;
            var PDF = new Arb();
            //double PDFd;
            int dis = 4;
            mu = aflint.t(6);
            nu = aflint.t(40);
            x = aflint.t(61.0d);
            nc = aflint.t(0);
            nc2 = aflint.t(6);

            int n = aflint.lrint(nu);

            a = mu / 2;
            b = nu / 2;
            xbeta = mu * x / (mu * x + nu);
            ybeta = 1 - xbeta;

            switch (dis)
            {
                case 1:
                    {
                        Console.WriteLine("Noncentral Chi-Square");
                        // Cdisn2(nu, x, nc, LeftTail0, RightTail0)
                        // LeftTail1 = aflint.t(dreal.dist_pchisq_nc(x.AsDouble, nu.AsDouble, nc.AsDouble, True, False))
                        // RightTail1 = aflint.t(dreal.dist_pchisq_nc(x.AsDouble, nu.AsDouble, nc.AsDouble, False, False))
                        aflint_non_central_chi_square(x, nu, nc, ref LeftTail2, ref RightTail2);
                        aflint_NonCentralChi2_SPA2(nu, x, nc, ref LeftTail3, ref RightTail3);
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("Noncentral t");
                        // tdisn(nu, x, nc, LeftTail0, RightTail0)
                        // LeftTail1 = aflint.t(dreal.dist_pt_nc(x.AsDouble, nu.AsDouble, nc.AsDouble, True, False))
                        // RightTail1 = aflint.t(dreal.dist_pt_nc(x.AsDouble, nu.AsDouble, nc.AsDouble, False, False))
                        ArbdisnOwen(n, x, nc, ref LeftTail2, ref RightTail2);
                        ArbDisN_Broda_Combined(nu, x, nc, aflint.t(0), ref PDF, ref LeftTail3, ref RightTail3);
                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("Noncentral F");
                        // Fdisn2(mu, nu, x, nc, LeftTail0, RightTail0)
                        // LeftTail1 = aflint.t(dreal.dist_pf_nc(x.AsDouble, mu.AsDouble, nu.AsDouble, nc.AsDouble, True, False))
                        // RightTail1 = aflint.t(dreal.dist_pf_nc(x.AsDouble, mu.AsDouble, nu.AsDouble, nc.AsDouble, False, False))
                        aflint_fdisnOwen2(x, mu, n, nc, ref LeftTail2, ref RightTail2);
                        break;
                    }
                // FdisnPaolella(mu.AsDouble, nu.AsDouble, x.AsDouble, nc.AsDouble, 0, PDFd, LeftTail3d, RightTail3d)
                // PDF = PDFd : LeftTail3 = LeftTail3d : RightTail3 = RightTail3d

                case 4:
                    {
                        Console.WriteLine("Noncentral beta");
                        break;
                    }

                default:
                    {
                        // Betadisn(a, b, xbeta, ybeta, nc, LeftTail0, RightTail0)
                        // LeftTail1 = aflint.t(dreal.dist_pbeta_nc(xbeta.AsDouble, a.AsDouble, b.AsDouble, nc.AsDouble, True, False))
                        // RightTail1 = aflint.t(dreal.dist_pbeta_nc(xbeta.AsDouble, a.AsDouble, b.AsDouble, nc.AsDouble, False, False))
                        // LeftTail1 = dreal.dist_pf_nc(x, mu, nu, nc, True, False)
                        // RightTail1 = dreal.dist_pf_nc(x, mu, nu, nc, False, False)

                        Console.WriteLine("Not implemented");
                        break;
                    }

            }

            // Console.WriteLine("LeftTail0: {0}, RightTail0: {1}", LeftTail0, RightTail0)
            Console.WriteLine("LeftTail1: {0}, RightTail1: {1}", LeftTail1, RightTail1);
            Console.WriteLine("LeftTail2: {0}, RightTail2: {1}", LeftTail2, RightTail2);
            Console.WriteLine("LeftTail3: {0}, RightTail3: {1}", LeftTail3, RightTail3);
            Console.WriteLine("PDF:  {0}", PDF);
        }





    }
}