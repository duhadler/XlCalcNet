using System;

namespace Distributions
{

    static class DistCornish
    {




        public static void RawMomentsToMoments(int k, ref double[] mraw, ref double[] mu)
        {
            int n;
            int j;
            double sign;
            double sum;
            double prod;
            double BK;
            mraw[0] = 1d;
            mu[1] = mraw[1];
            var loopTo = k;
            for (n = 2; n <= loopTo; n++)
            {
                sum = 0d;
                BK = 1d;
                prod = 1d;
                sign = 1d;
                for (j = n; j >= 0; j -= 1)
                {
                    sum = sum + sign * BK * mraw[j] * prod;
                    BK = BK * j / (n - j + 1);
                    sign = -sign;
                    prod = prod * mu[1];
                }
                mu[n] = sum;
            }
        }

        public static void MomentsToRawMoments(int k, ref double[] mraw, ref double[] mu)
        {
            int n;
            int j;
            double sum;
            double prod;
            double BK;
            mu[0] = 1d;
            mraw[1] = mu[1];
            mu[1] = 0d;
            var loopTo = k;
            for (n = 2; n <= loopTo; n++)
            {
                sum = 0d;
                BK = 1d;
                prod = 1d;
                var loopTo1 = n;
                for (j = 0; j <= loopTo1; j++)
                {
                    sum = sum + BK * mu[n - j] * prod;
                    BK = BK * (n - j) / (j + 1);
                    prod = prod * mraw[1];
                }
                mraw[n] = sum;
            }
            mu[1] = mraw[1];
        }

        public static void MomentsToCumulants(int n, ref double[] mu, ref double[] kappa)
        {
            // Calculates cumulants from central moments
            // Lee, 1992
            int r;
            int j;
            double sum;
            double F;
            kappa[1] = mu[1];
            var loopTo = n;
            for (r = 2; r <= loopTo; r++)
            {
                sum = 0d;
                F = r - 1;
                var loopTo1 = r - 2;
                for (j = 2; j <= loopTo1; j++)
                {
                    sum = sum + F * mu[r - j] * kappa[j];
                    F = F * (r - j) / j;
                }
                kappa[r] = mu[r] - sum;
            }
        }


        public static void RawMomentsToCumulants(int n, ref double[] mu, ref double[] kappa)
        {
            // Calculates cumulants from raw moments
            int r;
            int j;
            double sum;
            double f;
            kappa[1] = mu[1];
            var loopTo = n;
            for (r = 1; r <= loopTo; r++)
            {
                sum = 0d;
                f = 1d;
                var loopTo1 = r - 1;
                for (j = 1; j <= loopTo1; j++)
                {
                    sum = sum + f * mu[r - j] * kappa[j];
                    f = f * (r - j) / j;
                }
                kappa[r] = mu[r] - sum;
            }
        }



        public static void CumulantsToRawMoments(int n, ref double[] kappa, ref double[] mu)
        {
            // Calculates cumulants from raw moments
            int r;
            int j;
            double sum;
            double f;
            mu[1] = kappa[1];
            var loopTo = n;
            for (r = 1; r <= loopTo; r++)
            {
                sum = 0d;
                f = 1d;
                var loopTo1 = r - 1;
                for (j = 1; j <= loopTo1; j++)
                {
                    sum = sum + f * mu[r - j] * kappa[j];
                    f = f * (r - j) / j;
                }
                mu[r] = kappa[r] + sum;
            }
        }




        public static void CumulantToGamma(int m, double mean, ref double sigma, ref double[] k, ref double[] o)
        {
            // Calculates gamma-coefficients (for the Edgeworth expansion) from cumulants
            double sign;
            double fakt;
            int i;
            sigma = Math.Sqrt(k[2]);
            mean = (mean - k[1]) / sigma;
            sign = -1;
            fakt = 2d * k[2];
            var loopTo = m;
            for (i = 3; i <= loopTo; i++)
            {
                fakt = fakt * sigma * i;
                o[i - 2] = sign * k[i] / fakt;
                sign = -sign;
            }
        }



        // Get cumulants from discrete null-distribution
        public static void GetRawMoments(int nl, int maxmoment, double[] x, double[] mu)
        {
            int s;
            int i;
            int j;
            double sk;
            s = 0;
            mu = new double[maxmoment + 1]; // : ReDim kappa(maxmoment)
            var loopTo = maxmoment;
            for (j = 1; j <= loopTo; j++)
                mu[j] = 0d;
            var loopTo1 = nl;
            for (i = 0; i <= loopTo1; i++)
            {
                sk = 1d;
                var loopTo2 = maxmoment;
                for (j = 1; j <= loopTo2; j += 1)
                {
                    sk = sk * s;
                    mu[j] = mu[j] + x[i] * sk;
                }
                s = s + 1;
            }
            // Call MomentsToCumulants(maxmoment, mu(), kappa())
            Console.WriteLine("Raw Moments");
            var loopTo3 = maxmoment;
            for (j = 1; j <= loopTo3; j++)
                Console.WriteLine("j: {0}, mu(j): {1}", j, mu[j]);

        }













        private static void enumerate(int m, int nr, ref int[] p, ref int[] t, ref int[] hcount)
        {
            int sum;
            int F;
            bool minus;
            sum = 0;
            minus = (m - nr) % 2 > 0;
            var loopTo = nr;
            for (F = 1; F <= loopTo; F++)
                sum = sum + p[t[F]];
            if (minus)
                hcount[sum] = hcount[sum] - 1;
            else
                hcount[sum] = hcount[sum] + 1;
        }

        private static void initialize(int a, int active, int nr, ref int[] t)
        {
            int i;
            t[a] = t[a] + 1;
            var loopTo = nr;
            for (i = a + 1; i <= loopTo; i++)
                t[i] = t[i - 1] + 1;
            active = nr;
        }

        private static double CalcH(ref double[] h, ref int[] p, int m)
        {
            double CalcHRet = 0.0;
            int hmax;
            int i;
            //int Index;
            int nr;
            var active = default(int);
            var hcount = new int[101];
            var t = new int[101];
            double sum;
            hmax = 0;
            var loopTo = m;
            for (i = 1; i <= loopTo; i++)
                hmax = hmax + p[i];
            var loopTo1 = hmax;
            for (i = 1; i <= loopTo1; i++)
                hcount[i] = 0;
            //int Index = 1;
            var loopTo2 = m;
            for (nr = 1; nr <= loopTo2; nr++)
            {
                t[1] = 0;
                t[0] = m;
                initialize(1, active, nr, ref t);
                enumerate(m, nr, ref p, ref t, ref hcount);
                do
                {
                    if (active >= 0)
                    {
                        if (t[active] < m - (nr - active))
                        {
                            t[active] = t[active] + 1;
                            enumerate(m, nr, ref p, ref t, ref hcount);
                        }
                        else
                        {
                            active = active - 1;
                            if (active >= 0)
                            {
                                if (t[active] < m - (nr - active))
                                {
                                    initialize(active, active, nr, ref t);
                                    enumerate(m, nr, ref p, ref t, ref hcount);
                                }
                            }
                        }
                    }
                }
                while (active != 0);
            }
            sum = 0d;
            for (i = hmax; i >= 1; i -= 1)
            {
                if (hcount[i] != 0)
                {
                    sum = sum + hcount[i] * h[i];
                }
            }
            CalcHRet = sum;
            return CalcHRet;
        }

        private static void cp(int n, int k, int h, ref int[] p, bool F, bool z)
        {
            int a;
            int b;
            int i;
            int j;
            int Q;
            int r;
            if (F)
            {
                if (z)
                {
                    a = n;
                    p[k] = -1;
                }
                else
                {
                    a = n - k;
                    p[k] = 0;
                }
                F = false;
                j = k;
            }
            else
            {
                a = p[1] - p[2] - 2;
                j = 2;
                while (p[1] - p[j] < 2)
                {
                    a = a - 1 + j * (p[j] - p[j + 1]);
                    j = j + 1;
                }
            }
            b = h - 1 - p[j];
            Q = a / b;
            r = a - b * Q;
            var loopTo = Q;
            for (i = 1; i <= loopTo; i++)
                p[i] = h;
            if (Q == k)
            {
                F = true;
                return;
            }
            var loopTo1 = j;
            for (i = Q + 1; i <= loopTo1; i++)
                p[i] = 1 + p[j];
            p[Q + 1] = r + p[Q + 1];
            if (p[1] - p[k] < 2)
                F = true;
        }

        private static double CalcOmega(ref double[] o, ref int[] p, int m)
        {
            double CalcOmegaRet = 0.0;
            int j;
            int position;
            int i;
            var Value = new int[101];
            var count = new int[101];
            double prod;
            Value[1] = p[1];
            count[1] = 1;
            position = 1;
            var loopTo = m;
            for (i = 2; i <= loopTo; i++)
            {
                if (p[i - 1] == p[i])
                {
                    count[position] = count[position] + 1;
                }
                else
                {
                    position = position + 1;
                    Value[position] = p[i];
                    count[position] = 1;
                }
            }
            prod = 1d;
            var loopTo1 = position;
            for (i = 1; i <= loopTo1; i++)
            {
                prod = prod * o[Value[i]];
                var loopTo2 = count[i];
                for (j = 2; j <= loopTo2; j++)
                    prod = prod * o[Value[i]] / j;
            }
            CalcOmegaRet = prod;
            return CalcOmegaRet;
        }

        private static double CalcZ(ref double[] h, ref int[] p, int m, int n_order)
        {
            double CalcZRet = 0.0;
            int d;
            int i;
            d = 0;
            var loopTo = m;
            for (i = 1; i <= loopTo; i++)
                d = d + p[i] + 2;
            CalcZRet = h[n_order + d - 1];
            return CalcZRet;
        }

        private static double calc(bool IsBoxDavis, ref double[] h, ref double[] o, ref int[] p, int k, int n_order)
        {
            double calcRet = 0.0;
            int m;
            int i;
            double co;
            double ch;
            i = 1;
            while (p[i] != 0 & i < k + 1)
                i = i + 1;
            m = i - 1;
            if (IsBoxDavis)
            {
                co = CalcOmega(ref o, ref p, m);
                ch = CalcH(ref h, ref p, m);
                calcRet = co * ch;
            }
            else
            {
                calcRet = CalcOmega(ref o, ref p, m) * CalcZ(ref h, ref p, m, n_order);
            }

            return calcRet;
        }

        private static double BoxDavisSum(bool IsBoxDavis, bool UseOne, ref double[] h, ref double[] o, int n, int n_order)
        {
            double BoxDavisSumRet = 0.0;
            int icount;
            int k;
            int HH;
            int i;
            var p = new int[101];
            bool F;
            bool z;
            double sum;
            HH = n;
            icount = 1;
            z = true;  // Teil kann 0 sein
            F = true;
            // UseOne=true Teil kann 1 sein
            if (UseOne)
                k = n;
            else
                k = n / 2;
            sum = 0d;
            cp(n, k, HH, ref p, F, z);
            sum = sum + calc(IsBoxDavis, ref h, ref o, ref p, k, n_order);
            while (F == false)
            {
                cp(n, k, HH, ref p, F, z);
                if (!UseOne)
                {
                    i = 1;
                    while (p[i] != 1 & i < k + 1)
                        i = i + 1;
                    if (i == k + 1)
                    {
                        sum = sum + calc(IsBoxDavis, ref h, ref o, ref p, k, n_order);
                        icount = icount + 1;
                    }
                }
                else
                {
                    sum = sum + calc(IsBoxDavis, ref h, ref o, ref p, k, n_order);
                    icount = icount + 1;
                }
            }
            BoxDavisSumRet = sum;
            return BoxDavisSumRet;
        }

        public static void BoxDavis1(bool UseOne, int Order, double f1, double X, ref double[] o, ref double LeftTail, ref double RightTail)
        {
            int start;
            int i;
            int j;
            var S = new double[101];
            var F = new double[101];
            var h = new double[101];
            var density = default(double);
            double xr;
            double S1;
            double s2;
            bool show;
            show = true;
            if (UseOne)
                start = 1;
            else
                start = 2;
            F[1] = f1;
            h[1] = X / f1;
            xr = X;
            var loopTo = Order;
            for (j = 2; j <= loopTo; j++)
            {
                F[j] = F[j - 1] * (f1 + 2 * j - 2d);
                xr = xr * X;
                h[j] = h[j - 1] + xr / F[j];
            }
            DistMain.cdis2(f1, X, ref LeftTail, ref RightTail, ref density);
            S1 = RightTail;
            var loopTo1 = Order;
            for (i = start; i <= loopTo1; i++)
                S[i] = BoxDavisSum(true, UseOne, ref h, ref o, i, 0);
            s2 = 0d;
            if (!UseOne)
                S[1] = 0d;
            if (show)
                Console.WriteLine("Adjustments: ");
            var loopTo2 = Order;
            for (i = start; i <= loopTo2; i++)
            {
                s2 = s2 + S[i];
                if (show)
                    Console.WriteLine(" i: {0}, s2: {1}, S(i): {2}", i, s2, S[i]);
            }
            s2 = s2 * 2d * DistMain.cdens(f1, X);
            S1 = S1 + s2;
            LeftTail = 1d - S1;
            RightTail = S1;
        }

        public static void NdensDeriv(int k, double X, ref double[] z)
        {
            int m;
            const double sqrt2pi = 0.398942280401433d;
            z[0] = Math.Exp(-X * X / 2d) * sqrt2pi;
            z[1] = -X * z[0];
            var loopTo = k - 2;
            for (m = 0; m <= loopTo; m++)
                z[m + 2] = -X * z[m + 1] - (m + 1) * z[m];
        }

        private static void CF(int nord, double X, ref double[] ac, ref double[] del)
        {
            // Calculates adjustments for Cornish expansion
            double[] a;
            double[] d;
            double[] h;
            double[] p;
            int j;
            int ja;
            int jal;
            int jb;
            int jbl;
            int k;
            int L;
            double aa;
            double bc;
            double cc;
            double DD;
            double fac;
            a = new double[nord + 1];
            d = new double[nord + 1];
            h = new double[3 * nord + 1];
            p = new double[3 * nord * (nord + 1) / 2 + 1];
            cc = -1;
            var loopTo = nord;
            for (j = 1; j <= loopTo; j++)
            {
                a[j] = cc * ac[j] / ((j + 1) * (j + 2));
                cc = -cc;
            }
            h[1] = -X;
            h[2] = X * X - 1d;
            var loopTo1 = 3 * nord;
            for (j = 3; j <= loopTo1; j++)
                h[j] = -(X * h[j - 1] + (j - 1) * h[j - 2]);
            var loopTo2 = 3 * nord * (nord + 1) / 2;
            for (j = 1; j <= loopTo2; j++)
                p[j] = 0d;
            d[1] = -a[1] * h[2];
            del[1] = d[1];
            p[1] = d[1];
            p[3] = a[1];
            ja = 0;
            fac = 1d;
            var loopTo3 = nord;
            for (j = 2; j <= loopTo3; j++)
            {
                fac = fac * j;
                ja = ja + 3 * (j - 1);
                jb = ja;
                bc = 1d;
                var loopTo4 = j - 1;
                for (k = 1; k <= loopTo4; k++)
                {
                    DD = bc * d[k];
                    aa = bc * a[k];
                    jb = jb - 3 * (j - k);
                    var loopTo5 = 3 * (j - k);
                    for (L = 1; L <= loopTo5; L++)
                    {
                        jbl = jb + L;
                        jal = ja + L;
                        p[jal + 1] = p[jal + 1] + DD * p[jbl];
                        p[jal + k + 2] = p[jal + k + 2] + aa * p[jbl];
                    }
                    bc = bc * (j - k) / k;
                }
                p[ja + j + 2] = p[ja + j + 2] + a[j];
                d[j] = 0d;
                var loopTo6 = 3 * j;
                for (L = 2; L <= loopTo6; L++)
                    d[j] = d[j] - p[ja + L] * h[L - 1];
                p[ja + 1] = d[j];
                del[j] = d[j] / fac;
                // Console.WriteLine("del(j): {0}, fac: {1}", del(j), fac)

            }
        }

        private static double[] _CalcEdgeworth_h = new double[101];

        public static void CalcEdgeworth(bool UpdateNdis, bool UseOnlyEvenCumulants, int deriv, int Order, double X, ref double[] o, ref double LeftTail, ref double RightTail)
        {
            // UpdateNdis: true if recalculation of ndis and ndensderiv is required
            // UseOnlyEvenCumulants: true, if only even cumulants are used
            // deriv: 0 for CDF, 1 for density, or k for kth. derivative of CDF
            // order: number of standardized cumulants to be used in the calculation
            // o: array of standardised cumulants
            // x: standardized approx. normal variate, for which cdf is evaluated
            // LeftTail, RightTail: result
            int i;
            int n_order;
            var S = new double[101];
            double S1;
            double s2;
            double s3;
            if (UpdateNdis)
                NdensDeriv(100, X, ref _CalcEdgeworth_h);
            if (deriv <= 0)
                S1 = DistMain.ndis(X);
            else
                S1 = _CalcEdgeworth_h[deriv - 1];
            s3 = DistMain.ndis(-X);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                n_order = deriv;
                if (UseOnlyEvenCumulants)
                    n_order = n_order + i;
                S[i] = BoxDavisSum(false, true, ref _CalcEdgeworth_h, ref o, i, n_order);
            }
            s2 = 0d;
            var loopTo1 = Order;
            for (i = 1; i <= loopTo1; i++)
            {
                s2 = s2 + S[i];
                Console.WriteLine("i: {0}, S(i): {1}, S1 + s2: {2}", i, S[i], S1 + s2);
            }
            // s2 = S1 + s2
            LeftTail = S1 + s2;
            if (deriv > 0)
                RightTail = 1d - LeftTail;
            else
                RightTail = s3 - s2;
        }

        public static double CalcCornish(double LeftTail, double RightTail, double mean, double sigma, ref double[] kappa, int nord)
        {
            double CalcCornishRet = 0.0;
            int i;
            double S;
            double X;
            double[] ac;
            double[] del;
            // Dim m As Integer, m1 As Integer, m2 As Integer
            ac = new double[nord + 1];
            del = new double[nord + 1];
            S = sigma * sigma;
            var loopTo = nord;
            for (i = 3; i <= loopTo; i++)
            {
                S = S * sigma;
                ac[i - 2] = kappa[i] / S;
            }
            X = DistX.ndisx(LeftTail, RightTail);
            CF(nord, X, ref ac, ref del);

            // m1 = 1
            // m2 = 2
            // For i = 1 To nord - 2 Step 2
            // If Math.Abs(del(i)) < Math.Abs(del(m1)) Then m1 = i
            // '    sum = sum + del(i)
            // '    Debug.Print i, del(i), x + del(i), sum
            // Next i
            // For i = 2 To nord - 2 Step 2
            // If Math.Abs(del(i)) < Math.Abs(del(m2)) Then m2 = i
            // '    sum = sum + del(i)
            // '    Debug.Print i, del(i), x + del(i), sum
            // Next i
            // If del(m1) > del(m2) Then m = m1 Else m = m2
            // '  m = 20

            // For i = 1 To m
            // Console.WriteLine("X: {0}", X)
            var loopTo1 = nord - 2;
            for (i = 1; i <= loopTo1; i++)
            {
                X = X + del[i];
                Console.WriteLine("X: {0}, del(i): {1}, del(i)/X: {2}", X, del[i], del[i] / X);

            }
            // Debug.Print "m: ", m, "x: ", x
            CalcCornishRet = mean + sigma * X;
            return CalcCornishRet;
        }

        public static double InvCorn(double sg2, double LeftTail, double RightTail, double mean, double sigma, ref double[] k, int Order)
        {
            double InvCornRet = 0.0;
            double delta;
            double Factor;
            bool FoundLimit;
            int i;
            double x1;
            double x2;
            double x3;
            double fx1;
            double fx2;
            double fx3;
            double Leftx1;
            double Leftx2;
            double Rightx1;
            double Rightx2;
            bool UseLeftTail;

            Leftx2 = Math.Abs(LeftTail);
            Rightx2 = Math.Abs(RightTail);
            if (Leftx2 < Rightx2)
                Rightx2 = 1d - Leftx2;
            else
                Leftx2 = 1d - Rightx2;

            // Debug.Print "sg2,LeftTail,RightTail: ", sg2, Leftx2, Rightx2
            fx2 = CalcCornish(Leftx2, Rightx2, mean, sigma, ref k, Order);
            // Debug.Print "Cornish X2:", Leftx2, Rightx2, fx2
            if (fx2 > sg2)
                Factor = 2d;
            else
                Factor = 0.5d;
            do
            {
                Leftx1 = Leftx2;
                Rightx1 = Rightx2;
                fx1 = fx2;
                if (Rightx1 < 0.5d)
                {
                    Rightx2 = Rightx1 * Factor;
                    Leftx2 = 1d - Rightx2;
                }
                else
                {
                    Leftx2 = Leftx1 / Factor;
                    Rightx2 = 1d - Leftx2;
                }
                fx2 = CalcCornish(Leftx2, Rightx2, mean, sigma, ref k, Order);
                if (Factor == 0.5d)
                    FoundLimit = fx2 > sg2;
                else
                    FoundLimit = fx2 <= sg2;
            }
            // Debug.Print "Cornish X2:", Leftx2, Rightx2, fx2, FoundLimit
            while (!FoundLimit);
            if (Leftx2 < 0.5d)
            {
                x1 = Leftx1;
                x2 = Leftx2;
                UseLeftTail = true;
            }
            else
            {
                x1 = Rightx1;
                x2 = Rightx2;
                UseLeftTail = false;
            }
            i = 0;
            do
            {
                i = i + 1;
                if (fx2 - fx1 == 0d)
                {
                    x3 = x2;
                    break;
                }
                x3 = x1 - (x2 - x1) / (fx2 - fx1) * (fx1 - sg2);
                if (UseLeftTail)
                {
                    Leftx1 = x3;
                    Rightx1 = 1d - Leftx1;
                }
                else
                {
                    Rightx1 = x3;
                    Leftx1 = 1d - Rightx1;
                }
                fx3 = CalcCornish(Leftx1, Rightx1, mean, sigma, ref k, Order); // l2
                if (sg2 != 0d)
                    delta = Math.Abs((fx3 - sg2) / sg2);
                else
                    delta = 0d;
                // Console.WriteLine("x3: {0}, fx3: {1}, delta: {2}", x3, fx3, delta)
                x1 = x2;
                x2 = x3;
                fx1 = fx2;
                fx2 = fx3;
            }
            // Debug.Print x3, fx3, delta
            while (!(delta < 0.000000000000001d | i > 100));
            // Debug.Print "Result:", x3
            if (UseLeftTail)
                InvCornRet = x3;
            else
                InvCornRet = 1d - x3;
            return InvCornRet;
        }


        public static void CalcChiPowerRawMoments(int m, double n, double L, ref double[] mraw)
        {
            double a;
            int k;
            a = n / 2d;
            var loopTo = m;
            for (k = 1; k <= loopTo; k++)
                mraw[k] = Math.Exp(DistMain.LnGamma(a + k * L) - DistMain.LnGamma(a) - Math.Log(0.5d) * k * L);
        }




        public static void CalcChiPowerCumulants(int k, double n, double L, ref double[] kappa)
        {
            double[] mraw;
            double[] mu;
            // Dim i As Integer
            mraw = new double[k + 1];
            mu = new double[k + 1];
            // Call FindL(N, L)
            CalcChiPowerRawMoments(k, n, L, ref mraw);
            // !!!!! Replace with RawMomentsToCumulants !!!!
            RawMomentsToMoments(k, ref mraw, ref mu);
            MomentsToCumulants(k, ref mu, ref kappa);
            // !!!!! Replace with RawMomentsToCumulants !!!!
        }



        public static void DemoPowerCumulants()
        {
            int i;
            int k;
            double n;
            double L;
            double[] kappa;
            double mean;
            var sigma = default(double);
            double[] omega;
            double X;
            double z;
            double LeftTail;
            double RightTail;
            k = 9;
            n = 30d;
            L = 1d / 3d;
            RightTail = 0.001d;
            LeftTail = 1d - RightTail;
            X = DistX.cdisx(LeftTail, RightTail, n);
            X = Math.Pow(X, L);
            mean = X;
            kappa = new double[k + 1];
            omega = new double[k + 1];
            CalcChiPowerCumulants(k, n, L, ref kappa);
            CumulantToGamma(k, mean, ref sigma, ref kappa, ref omega);
            Console.WriteLine("Lambda: {0}", L);
            var loopTo = k;
            for (i = 1; i <= loopTo; i++)
                Console.WriteLine("i: {0}, kappa(i): {1}, omega(i): {2}", i, kappa[i], omega[i]);
            mean = X - kappa[1];
            z = mean / sigma;
            Console.WriteLine("mean: {0}, sigma: {1}, kappa(1): {2}, Sqr(kappa(2)): {3}", mean, sigma, kappa[1], Math.Sqrt(kappa[2]));
            Console.WriteLine("n: {0}, X: {1}, z: {2}, ndis(-z): {3}", n, X, z, DistMain.ndis(-z));
            CalcEdgeworth(true, false, 0, k - 2, z, ref omega, ref LeftTail, ref RightTail);
            Console.WriteLine("Edgeworth LeftTail: {0}, RightTail: {1}", LeftTail, RightTail);

        }






        // Get cumulants from discrete null-distribution
        public static void GetCumulants(int nl, int maxmoment, ref double[] X, ref double[] kappa)
        {
            int S;
            int i;
            int j;
            double sk;
            double[] mu;
            double mean = 0.0;
            S = -nl;
            mu = new double[maxmoment + 1];
            kappa = new double[maxmoment + 1];
            var loopTo = maxmoment;
            for (j = 1; j <= loopTo; j++)
                mu[j] = 0d;
            var loopTo1 = nl;
            for (i = 0; i <= loopTo1; i++)
            {
                sk = 1d;
                var loopTo2 = maxmoment;
                for (j = 1; j <= loopTo2; j += 1)
                {
                    sk = sk * S;
                    if (j % 2 == 0) 
                        mu[j] = mu[j] + X[i] * sk;
                    if (j == 1)
                    {
                        mean = mean + X[i] * (sk+nl);
                        //Console.WriteLine("mu[j]: {0}, X[i]: {1}, sk: {2}", mu[j], X[i], (sk+nl));
                    }
                }
                S = S + 2;
            }
            Console.WriteLine("mean (range from 0 to {0}:   {1}", nl, mean/2);
            MomentsToCumulants(maxmoment, ref mu, ref kappa);

        }

        public static void GetCumulantsWithSpacingOne(int nl, int maxmoment, ref double[] X, ref double[] kappa)
        {
            int S;
            int i;
            int j;
            double sk;
            double[] mu;
            double mean = 0.0;
            S = -nl;
            mu = new double[maxmoment + 1];
            kappa = new double[maxmoment + 1];
            var loopTo = maxmoment;
            for (j = 1; j <= loopTo; j++)
                mu[j] = 0d;
            var loopTo1 = nl;
            for (i = 0; i <= loopTo1; i++)
            {
                sk = 1d;
                var loopTo2 = maxmoment;
                for (j = 1; j <= loopTo2; j += 1)
                {
                    sk = sk * S;
                    if (j % 2 == 0)
                        mu[j] = mu[j] + X[i] * sk;
                    if (j == 1)
                    {
                        mean = mean + X[i] * (sk + nl);
                        Console.WriteLine("mu[j]: {0}, X[i]: {1}, sk: {2}", mu[j], X[i], (sk + nl));
                    }
                }
                S = S + 2;
            }
            Console.WriteLine("mean: {0}", mean);
            MomentsToCumulants(maxmoment, ref mu, ref kappa);

        }



        public static double JTCum(int j, int k, ref int[] n, ref int[] m)
        {
            double JTCumRet = 0.0;
            // Robillard, 1972
            double F;
            int i;
            int j2;
            int j21;
            int k1;
            int nn;
            double sum;
            nn = m[k];
            k1 = k;
            j2 = j;
            j21 = j2 + 1;
            sum = 0d;
            F = 1d;
            var loopTo = j;
            for (i = 1; i <= loopTo; i++)
                F = F * 2d;
            var loopTo1 = k;
            for (i = 1; i <= loopTo1; i++)
                sum = sum + DistMain.Bernoulli(j21, n[i] + 1);
            JTCumRet = F * DistMain.Bn0(j2) / (1.0d * j2 * j21) * (DistMain.Bernoulli(j21, nn + 1) + (k - 1) * DistMain.Bn0(j21) - sum);
            return JTCumRet;
        }

        public static void TerpstaCumulants(int k, int[] n, int maxmoment, ref double[] kappa, ref int TS)
        {
            var m = new int[k + 1];
            int j;
            // Dim TS As Integer
            // ReDim m(k) As Integer
            m[0] = 0;
            var loopTo = k;
            for (j = 1; j <= loopTo; j++)
                m[j] = m[j - 1] + n[j];
            TS = 0;
            var loopTo1 = k - 1;
            for (j = 1; j <= loopTo1; j++)
                TS = TS + m[j] * n[j + 1];
            // Debug.Print "TS:", TS
            var loopTo2 = maxmoment;
            for (j = 2; j <= loopTo2; j += 2)
                kappa[j] = JTCum(j, k, ref n, ref m);
        }


        public static void MannWhitneyCumulants(int m, int n, int maxmoment, ref double[] kappa, ref int TS)
        {
            int[] nn = new int[] {0, m, n };
            TerpstaCumulants(2, nn, maxmoment, ref kappa, ref TS);
        }



        public static void KendallCumulants(int n, int maxcum, ref double[] kappa, ref int nl)
        {
            // Praskova, 1976
            int j2;
            int j; // , t As Integer, r As Integer
            double sign;
            double sum;
            double p2;
            double Bern;
            double Bn0j2_1;
            double Bn0j2;
            maxcum = maxcum / 2;
            var loopTo = 2 * maxcum;
            for (j = 1; j <= loopTo; j++)
                kappa[j] = 0.0d;
            p2 = 0.5d;
            var loopTo1 = maxcum;
            for (j = 1; j <= loopTo1; j++)
            {
                if (j % 2 != 0)
                    sign = 1.0d;
                else
                    sign = -1.0d;
                j2 = 2 * j;
                p2 = p2 * 4.0d;
                Bern = DistMain.Bernoulli(j2 + 1, n + 1.0d);
                Bn0j2_1 = DistMain.Bn0(j2 + 1);
                sum = (Bern - Bn0j2_1) / (j2 + 1.0d);

                Bn0j2 = Math.Abs(DistMain.Bn0(j2));
                Console.WriteLine("Bern: {0}, Bn0j2: {1}, sum: {2}, Bn0j2: {3}", Bern, Bn0j2_1, sum, Bn0j2);

                kappa[j2] = sign * p2 * Math.Abs(DistMain.Bn0(j2)) * (sum - n) / j;
                // Debug.Print j2, "  ", kappa(j2)
            }
            nl = n * (n - 1) / 2;
        }



        public static void WilcoxonCumulants(int n, int maxcum, ref double[] kappa, ref int nl)
        {
            // Fellingham, 1964
            var gamma = new double[21];
            int j2;
            int j; // , t As Integer, r As Integer
            double sum;
            double p2;
            double S;
            double sigma2;
            maxcum = maxcum / 2;
            var loopTo = 2 * maxcum;
            for (j = 1; j <= loopTo; j++)
            {
                gamma[j] = 0.0d;
                kappa[j] = 0.0d;
            }
            sigma2 = 1.0d * n * (n + 1.0d) * (2.0d * n + 1.0d) / 6.0d;
            kappa[2] = sigma2;
            S = sigma2;
            p2 = 4.0d;
            var loopTo1 = maxcum;
            for (j = 2; j <= loopTo1; j++)
            {
                j2 = 2 * j;
                p2 = p2 * 4.0d;
                sum = (DistMain.Bernoulli(j2 + 1, n + 1.0d) - DistMain.Bn0(j2 + 1)) / (j2 + 1.0d);
                S = S * sigma2;
                kappa[j2] = p2 * (p2 - 1.0d) * DistMain.Bn0(j2) * sum / j2;
                gamma[j2 - 2] = p2 * (p2 - 1.0d) * DistMain.Bn0(j2) * sum / (j2 * S);
                // Debug.Print j2, "  ", kappa(j2), gamma(j2 - 2)
            }
            nl = n * (n + 1) / 2;
        }







        public static void SpearmanCalcdemo0()
        {
            var X = default(double[]);
            var nl = default(int);
            int n;
            n = 8;
            SpearmanCalc(n, 0, ref nl, ref X);
            // SpearmanCalcdemo = X
        }


        // Function SpearmanCalcdemo(ByVal n As Integer) As Variant
        // Dim X() As Double, nl As Integer
        // Call SpearmanCalc(n, 0, nl, X)
        // SpearmanCalcdemo = X
        // End Function

        public static void SpearmanCalc(int n, int Order, ref int Valcount, ref double[] xx)
        {
            int[] X;
            int[] y;
            int[] p;
            int[] d;
            int[] result;
            int i;
            int nn;
            int count;
            int sum;
            int k;
            int Q;
            int Upper;
            int lower;
            int t;
            double fraction;
            bool First;
            if (n <= 0)
                return;
            X = new int[n + 1];
            y = new int[n + 1];
            p = new int[n + 1];
            d = new int[n + 1];
            nn = n;
            First = true;
            count = 0;
            Upper = 0;
            lower = 0;
            var loopTo = nn;
            for (i = 1; i <= loopTo; i++)
            {
                X[i] = i;
                y[i] = i;
            }

            // If Order > 0 Then
            // Select Case n
            // Case 3:  Select Case Order '3 groups
            // Case 1:                    ' linear: no change
            // Case 2:  X(1) = 0: X(2) = 1: X(3) = 1 'quadratic
            // End Select
            // Case 4: Select Case Order '4 groups
            // Case 1:                   ' linear: no change
            // Case 2:  X(1) = 0: X(2) = 0: X(3) = 1: X(4) = 1 ' quadratic
            // Case 3:                   'cubic: no Change
            // End Select
            // Case 5: Select Case Order '5 groups
            // Case 1:                   ' linear: no change
            // Case 2:  X(1) = 0: X(2) = 1: X(3) = 1: X(4) = 4: X(5) = 4 ' quadratic
            // Case 3:                   ' cubic: no change
            // Case 4:  X(1) = 0: X(2) = 0: X(3) = 1: X(4) = 1: X(5) = 2 ' quartic
            // End Select
            // End Select
            // End If

            var loopTo1 = nn;
            for (i = 1; i <= loopTo1; i++)
            {
                Upper = Upper + X[i] * y[i];
                lower = lower + X[i] * y[nn + 1 - i];
            }
            Valcount = Upper - lower;
            result = new int[Valcount + 1];
            xx = new double[Valcount + 1];
            var loopTo2 = Valcount;
            for (i = 0; i <= loopTo2; i++)
                result[i] = 0;
            // Debug.Print "Lower:", Lower, "Upper:", Upper, "ValCount:", Valcount
            do
            {
                n = nn;
                if (First)
                {
                    var loopTo3 = n;
                    for (k = 2; k <= loopTo3; k++)
                    {
                        p[k] = 0;
                        d[k] = 1;
                    }
                    First = false;
                }
                k = 0;
            index1:
                ;

                Q = p[n] + d[n];
                p[n] = Q;
                if (Q == n)
                {
                    d[n] = -1;
                    goto loop1;
                }
                if (Q != 0)
                    goto transpose1;
                d[n] = 1;
                k = k + 1;
            loop1:
                ;

                if (n > 2)
                {
                    n = n - 1;
                    goto index1;
                }
                Q = 1;
                First = true;
            transpose1:
                ;

                Q = Q + k;
                t = X[Q];
                X[Q] = X[Q + 1];
                X[Q + 1] = t;
                count = count + 1;
                sum = 0;
                var loopTo4 = nn;
                for (i = 1; i <= loopTo4; i++)
                    sum = sum + X[i] * y[i];
                result[sum - lower] = result[sum - lower] + 1;
            }
            while (First != true);
            // Debug.Print "Anzahl der Permutationen:", count
            var loopTo5 = Valcount;
            for (i = 0; i <= loopTo5; i++)
            {
                fraction = 1.0d * result[i] / (1.0d * count);
                Console.WriteLine(" i: {0}, fraction: {1}", i, fraction);
                xx[i] = fraction;
            }
            X = null;
            y = null;
            X = null;
            p = null;
            d = null;
            result = null;
        }

        public static double[] PageQuadeCalc(bool UseRanks, int k, int n, int Order)
        {
            double[] PageQuadeCalcRet;
            int h;
            var pl = default(int);
            int j;
            int i;
            int F;
            int ql;
            double[] Q;
            var p = default(double[]);
            double[] r;
            if (UseRanks)
                F = n * (n + 1) / 2;
            else
                F = n;
            SpearmanCalc(k, Order, ref pl, ref p);
            Q = new double[pl * F + 1];
            r = new double[pl * F + 1];
            var loopTo = pl;
            for (i = 0; i <= loopTo; i++)
                Q[i] = p[i];
            ql = pl;
            var loopTo1 = n;
            for (h = 2; h <= loopTo1; h++)
            {
                if (UseRanks)
                    F = h;
                else
                    F = 1;
                var loopTo2 = pl;
                for (i = 0; i <= loopTo2; i++)
                {
                    var loopTo3 = ql;
                    for (j = 0; j <= loopTo3; j++)
                        r[F * i + j] = r[F * i + j] + p[i] * Q[j];
                }
                ql = ql + F * pl;
                var loopTo4 = ql;
                for (i = 0; i <= loopTo4; i++)
                {
                    Q[i] = r[i];
                    r[i] = 0d;
                }
            }
            PageQuadeCalcRet = Q;
            return PageQuadeCalcRet;
        }

        // Sub PageCalc(ByVal k As Integer, ByVal N As Integer, nl As Integer, x() As Double)
        // Call PageQuadeCalc(False, k, N, 0, nl, x())
        // End Sub

        // Sub PageQCalc(ByVal k As Integer, ByVal N As Integer, nl As Integer, x() As Double)
        // Call PageQuadeCalc(True, k, N, 0, nl, x())
        // End Sub

        // Sub WilcoxonCalc(ByVal N As Integer, nl As Integer, x() As Double)
        // Call PageQuadeCalc(True, 2, N, 0, nl, x())
        // End Sub

        // Sub SignCalc(ByVal N As Integer, nl As Integer, x() As Double)
        // Call PageQuadeCalc(False, 2, N, 0, nl, x())
        // End Sub

        public static void PageCumulants(int k, int n, int maxmoment, ref double[] kappa, ref int nl)
        {
            var X = default(double[]);
            var kl = default(int);
            int i;
            SpearmanCalc(k, 0, ref kl, ref X);
            GetCumulants(kl, maxmoment, ref X, ref kappa);
            var loopTo = maxmoment;
            for (i = 1; i <= loopTo; i++)
                kappa[i] = kappa[i] * n;
            X = null;
            nl = n * kl;
            Console.WriteLine("nl: {0}", nl);
        }



        public static void CornishEdgeworthDemo()
        {
            int i;
            var k = new double[101];
            var o = new double[101];
            double mean;
            double X;
            double sigma;
            double F;
            double LeftTail;
            double RightTail; // , density As Double
            int Order;
            Order = 20;
            F = 100d;
            LeftTail = 1d - 0.00001d;
            RightTail = 1d - LeftTail;

            k[1] = F;
            var loopTo = Order;
            for (i = 2; i <= loopTo; i++)
                k[i] = k[i - 1] * 2d * (i - 1);
            // Call CumulantToGamma(order, mean, sigma, k(), o())
            // For i = 1 To order
            // Debug.Print i, k(i), o(i)
            // Next i
            // Exit Sub
            mean = k[1];
            sigma = Math.Sqrt(k[2]);
            X = CalcCornish(LeftTail, RightTail, mean, sigma, ref k, Order);
            Console.WriteLine("Cornish X: {0}", X);
            Console.WriteLine("Exact   X: {0}", DistX.cdisx(LeftTail, RightTail, F));
            // Call CumulantToGamma(Order, X, sigma, k, o)
            // Call CalcEdgeworth(True, False, 0, Order - 2, (X - mean) / sigma, o, LeftTail, RightTail)
            // Console.WriteLine(  "Edgeworth LeftTail: {0}, RightTail: {1}", RightTail, LeftTail)
            // Call cdis2(F, X, LeftTail, RightTail, density)
            // Console.WriteLine(  "Excat LeftTail: {0}, RightTail: {1}", RightTail, LeftTail)
        }




        public static void InversCornishEdgeworthDemo()
        {
            int i;
            var k = new double[101];
            var o = new double[101];
            double mean;
            double X;
            double sigma;
            double F;
            double LeftTail;
            double RightTail; // , density As Double
            int Order; // , delta As Double, Factor As Double, FoundLimit As Boolean
            double sg2; // , x1 As Double, x2 As Double, x3 As Double, fx1 As Double, fx2 As Double, fx3 As Double
            Order = 10;
            F = 80d;
            RightTail = 0.000001d;
            LeftTail = 1d - RightTail;
            // RightTail = 1 - LeftTail

            k[1] = F;
            var loopTo = Order;
            for (i = 2; i <= loopTo; i++)
                k[i] = k[i - 1] * 2d * (i - 1);
            mean = k[1];
            sigma = Math.Sqrt(k[2]);
            sg2 = DistX.cdisx(LeftTail, RightTail, F);
            X = sg2;
            Console.WriteLine("Exact   X: {0}", sg2);
            CumulantToGamma(Order, X, ref sigma, ref k, ref o);
            CalcEdgeworth(true, false, 0, Order - 2, (X - mean) / sigma, ref o, ref LeftTail, ref RightTail);
            Console.WriteLine("Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail);

            double Result = InvCorn(sg2, LeftTail, RightTail, mean, sigma, ref k, Order);
            Console.WriteLine("LeftTail: {0}, RightTail: {1}", Result, 1d - Result);

        }



        public static void KendallInversCornishEdgeworthDemo()
        {
            // Dim i As Integer
            var kappa = new double[101];
            var o = new double[101];
            double mean;
            double X;
            double sigma; // , F As Double
            double LeftTail;
            double RightTail;
            var sumKR = default(double); // , density As Double
            int Order; // , delta As Double, Factor As Double, FoundLimit As Boolean
                       // Dim sg2 As Double', x1 As Double, x2 As Double, x3 As Double, fx1 As Double, fx2 As Double, fx3 As Double
            int n;
            var nl = default(int);

            Order = 32;
            n = 40;
            RightTail = 0.00000000000001d;
            LeftTail = 1d - RightTail;
            // RightTail = 1 - LeftTail

            KendallCumulants(n, Order, ref kappa, ref nl);  // Kendall  

            int i = 0;
            double d = 1d;
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2d * d;
                // Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*Bn0(i)/i)
                if (i > 0)
                    kappa[i] = kappa[i] - d * DistMain.Bn0(i) / i;
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }
            double[] KR = PermFriedman.KendallCalc(n);


            X = -610;

            i = 0;
            var CDF_KR = new double[nl + 1 + 1];
            for (int Index = -nl; Index <= 0; Index += 2)
            {
                sumKR = sumKR + KR[i];
                CDF_KR[i] = sumKR;
                if (Math.Abs(Math.Abs(X) - Math.Abs(Index)) < 10d)
                    Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR[i]);
                i = i + 1;
            }



            mean = kappa[1];
            sigma = Math.Sqrt(kappa[2]);
            // sg2 = cdisx(LeftTail, RightTail, F)
            // X = sg2
            // Console.WriteLine( "Exact   X: {0}", sg2)
            CumulantToGamma(Order, X, ref sigma, ref kappa, ref o);
            // Call CalcEdgeworth(True, False, 0, Order - 2, (X - mean) / sigma, o, LeftTail, RightTail)

            double z = (X - mean) / sigma;
            LeftTail = DistMain.ndis(z);
            RightTail = 1d - LeftTail;


            // Call CalcEdgeworth(True, False, 0, 0, (X - mean) / sigma, o, LeftTail, RightTail)
            Console.WriteLine("Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail);

            int xpos = Convert.ToInt32(X + nl) / 2;
            double ExactResult = CDF_KR[xpos - 1];
            Console.WriteLine("ExactResult: {0}", ExactResult);

            // For Order_i = 2 To Order Step 2
            // Dim Result As Double = InvCorn(X-0, LeftTail, RightTail, mean, sigma, kappa, Order_i)
            // Console.WriteLine("Order_i: {0}, LeftTail: {1}, RefDiff: {2}", Order_i, Result, (ExactResult-Result)/ExactResult)
            // LeftTail = Result: RightTail = 1-LeftTail
            // Next

            double[,] S;
            S = new double[21, 21];



            int j = 0;
            for (int Order_i = 4, loopTo1 = Order; Order_i <= loopTo1; Order_i += 2)
            {
                double Result = InvCorn(X - 0d, LeftTail, RightTail, mean, sigma, ref kappa, Order_i);
                // Console.WriteLine("Order_i: {0}, LeftTail: {1}, RefDiff: {2}", Order_i, Result, (ExactResult - Result) / ExactResult)
                LeftTail = Result;
                RightTail = 1d - LeftTail;
                S[j, 0] = LeftTail;
                j = j + 1;
            }

            int k = j - 1;
            var loopTo2 = k;
            for (j = 0; j <= loopTo2; j++)
                Console.WriteLine("j: {0}, S(j, 0): {1}", j, S[j, 0]);

            var loopTo3 = k - 1;
            for (j = 0; j <= loopTo3; j++)
                S[j, 1] = 1d / (S[j + 1, 0] - S[j, 0]);

            var loopTo4 = k - 1;
            for (j = 0; j <= loopTo4; j++)
                Console.WriteLine("j: {0}, S(j, 1): {1}", j, S[j, 1]);

            int m;

            for (m = 2; m <= 14; m++)
            {

                var loopTo5 = k - m;
                for (j = 0; j <= loopTo5; j++)
                    S[j, m] = S[j + 1, m - 2] + 1d / (S[j + 1, m - 1] - S[j, m - 1]);

                var loopTo6 = k - m;
                for (j = 0; j <= loopTo6; j++)
                    Console.WriteLine("j: {0}, S(j, m): {1}", j, S[j, m]);

            }

            Console.WriteLine("ExactResult: {0}", ExactResult);


        }


        public static void DemoShanks()
        {
            double[,] S;
            S = new double[41, 41];

            int k = 8;

            double sum = 0.0d;
            for (int j = 0, loopTo = k; j <= loopTo; j++)
            {
                int n = j + 0;
                double temp = 4d * Math.Pow(-1, n) / (2 * n + 1);
                sum = sum + temp;
                S[j, 0] = sum;
            }

            for (int j = 0, loopTo1 = k; j <= loopTo1; j++)
                Console.WriteLine("j: {0}, S(j, 0): {1}", j, S[j, 0]);

            // Exit Sub

            for (int j = 0, loopTo2 = k - 1; j <= loopTo2; j++)
                S[j, 1] = 1d / (S[j + 1, 0] - S[j, 0]);

            for (int j = 0, loopTo3 = k - 1; j <= loopTo3; j++)
                Console.WriteLine("j: {0}, S(j, 1): {1}", j, S[j, 1]);

            int m;

            var loopTo4 = k;
            for (m = 2; m <= loopTo4; m++)
            {

                for (int j = 0, loopTo5 = k - m; j <= loopTo5; j++)
                    S[j, m] = S[j + 1, m - 2] + 1d / (S[j + 1, m - 1] - S[j, m - 1]);

                for (int j = 0, loopTo6 = k - m; j <= loopTo6; j++)
                    Console.WriteLine("j: {0}, S(j, m): {1}", j, S[j, m]);

            }

            // Console.WriteLine("ExactResult: {0}", ExactResult)


        }





        public static void ListNullCDFbyCumDemo()
        {
            Console.WriteLine("PermCumulants");
            int dis = 1;  // type of distribution: 1:Wilcoxon, 2:Kendall, 3:M-W, 4:Terpsta, 5:Page
            int k = 3;  // number of groups
            int ng = 10;  // sample size per group
            int maxmoment = 12;  // maximal number of moments

            var n = new int[k + 1];
            var loopTo = k;
            for (int j = 1; j <= loopTo; j++)
                n[j] = ng;
            // nl is the highest score, counted continuously from 0 to nl with spacing 1
            // the mean is nl/2 with spacing of 1
            // All cumulants assume a spacing of 2

            var kappa = new double[maxmoment + 1];
            double[] KR = new double[1];
            int nl = 0;
            switch (dis)
            {
                case 1:
                    {
                        Console.WriteLine("Wilcoxon");
                        WilcoxonCumulants(n[1], maxmoment, ref kappa, ref nl);
                        KR = PermFriedman.WilcoxonCalc(n[1]);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Kendall");
                        KendallCumulants(n[1], maxmoment, ref kappa, ref nl);
                        KR = PermFriedman.KendallCalc(n[1]);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Mann-Whitney");
                        Console.WriteLine("n: {0}, m: {1}, n*m: {2}", n[1], n[2], n[1] * n[2]);
                        MannWhitneyCumulants(n[1], n[2], maxmoment, ref kappa, ref nl);
                        KR = PermFriedman.MannWhitneyCalc(n[1], n[2]);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Terpsta");
                        TerpstaCumulants(k, n, maxmoment, ref kappa, ref nl);
                        KR = PermFriedman.TerpstaCalc(k, n);
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Page");
                        PageCumulants(k, n[1], maxmoment, ref kappa, ref nl);
                        KR = PermFriedman.PageCalc(k, n[1]);
                        break;
                    }
            }

            double d = 1.0;
            for (int i = 1; i <= maxmoment; i++)
            {
                d = 2 * d;
                Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa[i], d * DistMain.Bn0(i) / i);
                if (i > 0)
                    kappa[i] = kappa[i] - d * DistMain.Bn0(i) / i;
                Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa[i]);
            }

            double[] kappa2 = new double[maxmoment + 1];
            GetCumulants(nl, maxmoment, ref KR, ref kappa2);
            for (int i = 1; i <= maxmoment; i++)
            {
                Console.WriteLine("i: {0}, kappa2(i): {1}", i, kappa2[i]);
            }

            for (int i = 0; i <= nl; i++)
                Console.WriteLine("i: {0}, KR[i]: {1}", i, KR[i]);

            ////Console.WriteLine("var: {0}, n: {1}", n[1] * (n[1] - 1) * (2 * n[1] + 5) / 18, n[1]);

            return;



        }










    }
}