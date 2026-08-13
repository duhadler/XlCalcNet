using System;

namespace Distributions
{



    static class DistMain
    {



        public static void LugannaniRice(double w, double U, double k2, double k3, double k4, ref double density, ref double LeftTail, ref double RightTail)
        {
            double w1;
            double U1;
            double Adj1;
            double Adj;
            w1 = 1d / w;
            U1 = 1d / U;
            k3 = k3 / (k2 * Math.Sqrt(k2));
            k4 = k4 / (k2 * k2);
            Adj1 = 0.125d * k4 - 5d * k3 * k3 / 24d;
            Adj = U1 * Adj1 - U1 * U1 * U1 - 0.5d * k3 * U1 * U1 + w1 * w1 * w1;

            ndis2(false, w, ref LeftTail, ref RightTail, ref density);
            // Console.WriteLine("LeftTail0: {0}", LeftTail)
            double LeftTail1 = LeftTail + density * (w1 - U1);
            double Diff0 = LeftTail1 - LeftTail;
            // Console.WriteLine("LeftTail1: {0}", LeftTail1)
            LeftTail = LeftTail + density * (w1 - U1 - Adj);
            // Console.WriteLine("LeftTail2: {0}", LeftTail)
            double Diff1 = LeftTail - LeftTail1;

            // Console.WriteLine("Diff0: {0}", Diff0)
            // Console.WriteLine("Diff1: {0}", Diff1)

            // Console.WriteLine("w1^3: {0}", density * w1 * w1 * w1)

            RightTail = RightTail - density * (w1 - U1 - Adj);

            // Console.WriteLine("w1: {0}, u1: {1}", w1, U1)
            // Console.WriteLine("density * Adjustment1: {0}", density * (w1 - U1))
            // Console.WriteLine("density * Adjustment2: {0}", density * (-Adj))
            // density = density * S * U1 * v2 * (t2 * v2 + N2) * (1 - 2 * Adj1 / 3)

        }



        public static double JensenR(double w, double U)
        {
            double JensenRRet = 0.0;
            JensenRRet = w + 1d / w * Math.Log(U / w);
            return JensenRRet;
        }


        public static void Jensen(double w, double U)
        {
            double r;
            var lefttail1 = default(double);
            var RightTail1 = default(double);
            var density1 = default(double);
            r = JensenR(w, U);
            ndis2(false, r, ref lefttail1, ref RightTail1, ref density1);
            Console.WriteLine("Lr_s: {0}, R: {1}", lefttail1, RightTail1);
        }




        public static void SwapTails(ref double LeftTail, ref double RightTail)
        {
            double temp;
            temp = LeftTail;
            LeftTail = RightTail;
            RightTail = temp;
        }

        public static double LogZPlusA(double z, double a)
        {
            double LogZPlusARet = 0.0;
            // LogZPlusA = log(z+a) - log(a) for a>>z
            double y;
            double S1;
            double s2;
            double s3;
            double i;
            y = z / (2d * a + z);
            S1 = y;
            s2 = S1;
            i = 1d;
            y = y * y;
            do
            {
                i = i + 2d;
                s2 = s2 * y;
                s3 = s2 / i;
                S1 = S1 + s3;
            }
            while (S1 != S1 + s3);
            // Debug.Print "Iterations:", (i - 1) / 2
            LogZPlusARet = 2d * S1;
            return LogZPlusARet;
        }

        public static double LnGamma(double z)
        {
            double LnGammaRet = 0.0;
            var bb = new double[11];
            double ln2pi;
            double lnz;
            double a;
            double z3;
            double z2;
            double sum2;
            double sum;
            int i;
            bb[1] = -0.00277777777777778d;
            bb[2] = 0.000793650793650794d;
            bb[3] = -0.000595238095238095d;
            bb[4] = 0.000841750841750842d;
            bb[5] = -0.00191752691752692d;
            bb[6] = 0.00641025641025641d;
            bb[7] = -0.0295506535947712d;
            bb[8] = 0.179644372368831d;
            bb[9] = -1.3924322169059d;
            bb[10] = 13.4028640441684d;
            a = 1.0d;
            while (z < 15.0d)
            {
                a = a * z;
                z = z + 1.0d;
            }


            lnz = (z - 0.5d) * Math.Log(z);
            ln2pi = 0.918938533204673d;
            z2 = 1.0d / (1.0d * z * z);
            sum2 = 1.0d / (12.0d * z);
            i = 0;
            z3 = 1.0d / z;
            do
            {
                i = i + 1;
                z3 = z3 * z2;
                sum = sum2;
                sum2 = sum + bb[i] * z3;
            }
            while (!(sum2 == sum | i > 9));
            sum2 = sum2 + lnz - z;
            sum2 = sum2 + ln2pi;
            LnGammaRet = sum2 - Math.Log(a);
            return LnGammaRet;
        }

        public static double LnGammaZPLusA(double z, double a)
        {
            double LnGammaZPLusARet = 0.0;
            var bb = new double[11];
            double lnz;
            // Dim a1 As Double, za1 As Double, aza1 As Double
            // Dim a2 As Double, za2 As Double, aza2 As Double
            double sum2;
            double sum3;
            double sum;
            double d1;
            int i;
            int j;
            int k;
            int n;
            var C = new double[31];
            var d = new double[31];
            var e = new double[31];
            bb[1] = -0.00277777777777778d;
            bb[2] = 0.000793650793650794d;
            bb[3] = -0.000595238095238095d;
            bb[4] = 0.000841750841750842d;
            bb[5] = -0.00191752691752692d;
            bb[6] = 0.00641025641025641d;
            bb[7] = -0.0295506535947712d;
            bb[8] = 0.179644372368831d;
            bb[9] = -1.3924322169059d;
            bb[10] = 13.4028640441684d;
            d1 = LogZPlusA(z, a);
            lnz = (z + a - 0.5d) * d1 + z * Math.Log(a) - z;
            // a1 = a
            // za1 = z + a
            // aza1 = a * (z + a)
            // a2 = a1 * a1
            // za2 = za1 * za1
            // aza2 = aza1 * aza1
            // sum2 = -z / (12# * aza1)
            // i = 0
            // Do
            // i = i + 1
            // a1 = a1 * a2
            // za1 = za1 * za2
            // aza1 = aza1 * aza2
            // sum = sum2
            // sum3 = bb(i) * (a1 - za1) / aza1
            // Debug.Print i, sum3
            // sum2 = sum + sum3
            // Loop Until ((sum2 = sum) Or (i > 9))
            // Debug.Print "sum2, lnz:", sum2, lnz

            sum2 = -z / (12.0d * a * (z + a));
            i = 0;
            n = 1;
            C[0] = 1d;
            C[1] = 1d;
            d[0] = 1d;
            e[0] = 1d;
            d[1] = 1d / (z + a);
            e[1] = z / (a * (z + a));
            do
            {
                i = i + 1;
                for (k = 1; k <= 2; k++)
                {
                    n = n + 1;
                    C[n] = 1d;
                    for (j = n - 1; j >= 1; j -= 1)
                        C[j] = C[j] + C[j - 1];
                    d[n] = d[n - 1] * d[1];
                    e[n] = e[n - 1] * e[1];
                }
                sum3 = 0d;
                var loopTo = n;
                for (j = 1; j <= loopTo; j++)
                    sum3 = sum3 + C[j] * d[n - j] * e[j];
                sum3 = -bb[i] * sum3;
                sum = sum2;
                sum2 = sum2 + sum3;
            }
            while (!(sum2 == sum | i > 9));
            sum2 = sum2 + lnz;
            LnGammaZPLusARet = sum2;
            return LnGammaZPLusARet;
        }

        public static double Lnbeta1(double a, double b)
        {
            double Lnbeta1Ret = 0.0;
            double t;
            t = LnGamma(a);
            t = t + LnGamma(b);
            Lnbeta1Ret = t - LnGamma(a + b);
            return Lnbeta1Ret;
        }

        public static double Lnbeta(double a, double b)
        {
            double LnbetaRet = 0.0;
            double l2;
            // L1 = Lnbeta1(a, b)
            l2 = LnBeta2(a, b);
            // Debug.Print "a,b,1,2: ", a, b, L1, L2
            LnbetaRet = l2;
            return LnbetaRet;
        }

        public static double LnBeta2(double a, double b)
        {
            double LnBeta2Ret = 0.0;
            double t;
            if (a > b)
                SwapTails(ref a, ref b);
            if (a < b / 100d)
            {
                t = LnGamma(a) - LnGammaZPLusA(a, b);
            }
            else
            {
                t = Lnbeta1(a, b);
            }
            LnBeta2Ret = t;
            return LnBeta2Ret;
        }

        public static double Bn0(int n)
        {
            double Bn0Ret = 0.0;
            double ln2pi;
            ln2pi = 1.83787706640935d;
            var b1 = new double[16];
            var lnk = new double[3];
            double S1;
            double sign;
            double sum;
            int k;
            // If b1(0) = 0 Then
            b1[0] = 1.0d;
            b1[1] = 0.166666666666667d;
            b1[2] = -0.0333333333333333d;
            b1[3] = 0.0238095238095238d;
            b1[4] = -0.0333333333333333d;
            b1[5] = 0.0757575757575758d;
            b1[6] = -0.253113553113553d;
            b1[7] = 1.16666666666667d;
            b1[8] = -7.0921568627451d;
            b1[9] = 54.9711779448622d;
            b1[10] = -529.124242424242d;
            b1[11] = 6192.1231884058d;
            b1[12] = -86580.2531135531d;
            b1[13] = 1425517.16666667d;
            b1[14] = -27298231.0678161d;
            b1[15] = 601580873.900642d;

            lnk[0] = 0.693147180559945d;
            lnk[1] = 1.09861228866811d;
            lnk[2] = 1.38629436111989d;
            // End If
            if (n == 1)
            {
                Bn0Ret = -0.5d;
                return Bn0Ret;
            }
            if (n % 2 > 0)
            {
                Bn0Ret = 0d;
                return Bn0Ret;
            }
            if (n <= 30)
            {
                Bn0Ret = b1[n / 2];
                return Bn0Ret;
            }
            if (n / 2 % 2 > 0)
            {
                sign = 1d;
            }
            else
            {
                sign = -1;
            }
            sum = 1d;
            k = 0;
            do
            {
                S1 = Math.Exp(-lnk[k] * n);
                sum = sum + S1;
                k = k + 1;
            }
            while (S1 / sum >= 0.0000000000000001d);
            S1 = LnGamma(n + 1);
            S1 = S1 - n * ln2pi;
            S1 = Math.Exp(S1) * sum;
            Bn0Ret = 2d * sign * S1;
            return Bn0Ret;
        }

        public static double Bernoulli(int n, double h)
        {
            double BernoulliRet = 0.0;
            double hn;
            double Bin;
            double sum;
            int i;
            int k;
            if (h == 0d)
            {
                BernoulliRet = Bn0(n);
                return BernoulliRet;
            }
            sum = 0d;
            Bin = 1d;
            hn = 1d;
            var loopTo = n;
            for (i = 1; i <= loopTo; i++)
                hn = hn * h;
            var loopTo1 = n;
            for (k = 0; k <= loopTo1; k++)
            {
                sum = sum + Bin * Bn0(k) * hn;
                Bin = Bin / (k + 1) * (n - k);
                hn = hn / h;
            }
            BernoulliRet = sum;
            return BernoulliRet;
        }



        public static double cdens(double n, double X)
        {
            double cdensRet = 0.0;
            double b;
            double m;
            double LastLngamma;
            b = n / 2.0d;
            m = X / 2.0d;
            if (X <= 0.0d)
            {
                cdensRet = 0.0d;
            }
            else
            {
                LastLngamma = LnGamma(b);
                cdensRet = 0.5d * Math.Exp(Math.Log(m) * (b - 1.0d) - LastLngamma - m);
            }

            return cdensRet;
        }



        public static void gamma_p_q(double b, double M, ref double LeftTail, ref double RightTail, ref double density)
        {
            int j;
            int i;
            var sum = new double[3];
            double eps;
            double k;
            double xsum;
            double a0;
            double A1;
            double A2;
            double an;
            double b0;
            double b1;
            double b2;
            double bn;
            double MinRelError;
            bool c3;
            MinRelError = 0.0000000000000001d;
            if (M <= 0.0d)
            {
                LeftTail = 0.0d;
                RightTail = 1.0d;
                density = 0.0d;
                return;
            }
            // density = cdens(n, X)
            density = cdens(2d * b, 2d * M);
            // If ((X <= 12.0) Or (X <= n)) Then
            if (M <= b - 0.5d)
            {
                c3 = true;  // LeftTail probability
            }
            else
            {
                c3 = false;
            }  // RightTail probability
               // b = n / 2.0
               // m = X / 2.0
            k = 2.0d * density;
            a0 = 1.0d;
            b0 = 1.0d;
            bn = 0.0d;
            j = 0;
            sum[0] = 1.0d;
            sum[1] = 1.0d;
            if (c3)
            {
                k = k * M / b;
                A1 = b + 1.0d - M;
                b1 = b + 1.0d;
                bn = b + 1.0d;
            }
            else
            {
                A1 = M + 1.0d - b;
                b1 = M;
            }
            do
            {
                j = j + 1;
                for (i = 0; i <= 1; i++)
                {
                    if (c3)
                    {
                        if (i == 1)
                        {
                            an = -(b + j) * M;
                        }
                        else
                        {
                            an = j * M;
                        }
                        bn = bn + 1.0d;
                    }
                    else if (i == 1)
                    {
                        an = j + 1.0d - b;
                        bn = M;
                    }
                    else
                    {
                        an = j;
                        bn = 1.0d;
                    }
                    A2 = bn * A1 + an * a0;
                    b2 = bn * b1 + an * b0;
                    A2 = A2 / b2;
                    A1 = A1 / b2;
                    b1 = b1 / b2;
                    b2 = 1.0d;
                    a0 = A1;
                    A1 = A2;
                    b0 = b1;
                    b1 = b2;
                    sum[i] = A2;
                }
                xsum = (sum[0] + sum[1]) * 0.5d;
                eps = (sum[0] - sum[1]) / xsum;
            }
            while (Math.Abs(eps) >= MinRelError);
            k = k / xsum;
            LeftTail = 1.0d - k;
            RightTail = k;
            if (c3)
            {
                SwapTails(ref LeftTail, ref RightTail);
            }
        }

        public static void cdis2(double n, double X, ref double LeftTail, ref double RightTail, ref double density)
        {
            int j;
            int i;
            var sum = new double[3];
            double eps;
            double m;
            double b;
            double k;
            double xsum;
            double a0;
            double A1;
            double A2;
            double an;
            double b0;
            double b1;
            double b2;
            double bn;
            double MinRelError;
            bool c3;
            MinRelError = 0.0000000000000001d;
            if (X <= 0.0d)
            {
                LeftTail = 0.0d;
                RightTail = 1.0d;
                density = 0.0d;
                return;
            }
            density = cdens(n, X);
            // If ((X <= 12.0) Or (X <= n)) Then
            if (X <= n - 1d)
            {
                c3 = true;  // LeftTail probability
            }
            else
            {
                c3 = false;
            }  // RightTail probability
            b = n / 2.0d;
            m = X / 2.0d;
            k = 2.0d * density;
            a0 = 1.0d;
            b0 = 1.0d;
            bn = 0.0d;
            j = 0;
            sum[0] = 1.0d;
            sum[1] = 1.0d;
            if (c3)
            {
                k = k * m / b;
                A1 = b + 1.0d - m;
                b1 = b + 1.0d;
                bn = b + 1.0d;
            }
            else
            {
                A1 = m + 1.0d - b;
                b1 = m;
            }
            do
            {
                j = j + 1;
                for (i = 0; i <= 1; i++)
                {
                    if (c3)
                    {
                        if (i == 1)
                        {
                            an = -(b + j) * m;
                        }
                        else
                        {
                            an = j * m;
                        }
                        bn = bn + 1.0d;
                    }
                    else if (i == 1)
                    {
                        an = j + 1.0d - b;
                        bn = m;
                    }
                    else
                    {
                        an = j;
                        bn = 1.0d;
                    }
                    A2 = bn * A1 + an * a0;
                    b2 = bn * b1 + an * b0;
                    A2 = A2 / b2;
                    A1 = A1 / b2;
                    b1 = b1 / b2;
                    b2 = 1.0d;
                    a0 = A1;
                    A1 = A2;
                    b0 = b1;
                    b1 = b2;
                    sum[i] = A2;
                }
                xsum = (sum[0] + sum[1]) * 0.5d;
                eps = (sum[0] - sum[1]) / xsum;
            }
            while (Math.Abs(eps) >= MinRelError);
            k = k / xsum;
            LeftTail = 1.0d - k;
            RightTail = k;
            if (c3)
            {
                SwapTails(ref LeftTail, ref RightTail);
            }
        }



        public static double cdis(double n, double X)
        {
            double cdisRet = 0.0;
            var LeftTail = default(double);
            var RightTail = default(double);
            var density = default(double);
            cdis2(n, X, ref LeftTail, ref RightTail, ref density);
            cdisRet = LeftTail;
            return cdisRet;
        }





        public static void betadis_(double a, double b, double Q, double p, ref double LeftTail, ref double RightTail, ref double density)
        {
            //bool fit;
            int j;
            int i;
            var sum = new double[2];
            double eps;
            double qp;
            double k;
            double xsum;
            double a0;
            double A1;
            double A2;
            double an;
            double b0;
            double b1;
            double b2;
            double bn;
            //double X;
            //double limit;
            double MinRelError;
            MinRelError = 0.00000000000001d;
            if (Q <= 0d)
            {
                LeftTail = 0d;
                RightTail = 1d;
                density = 0d;
                return;
            }
            if (p <= 0d)
            {
                LeftTail = 1d;
                RightTail = 0d;
                density = 0d;
                return;
            }
            // k = LnGamma(a + b) - LnGamma(a) - LnGamma(b)
            k = -Lnbeta(a, b);
            k = k + (b - 1d) * Math.Log(p) + (a - 1d) * Math.Log(Q);
            density = Math.Exp(k);
            // X = (b * Q) / (a * p)
            // limit = 4.5 - a
            // If limit < 1 Then
            // limit = 1
            // End If
            // fit = (X < limit)
            // If Not fit Then
            // Call SwapTails(a, b)
            // Call SwapTails(p, Q)
            // End If
            qp = Q / p;
            a0 = 1d;
            A1 = a + 1d - (b - 1d) * qp;
            b0 = 1d;
            b1 = a + 1d;
            j = 0;
            bn = a + 1d;
            sum[0] = 1d;
            sum[1] = 1d;
            do
            {
                j = j + 1;
                for (i = 0; i <= 1; i++)
                {
                    if (i == 1)
                    {
                        an = -(a + j) * (b - j - 1d) * qp;
                    }
                    else
                    {
                        an = j * (a + b - 1d + j) * qp;
                    }
                    bn = bn + 1d;
                    A2 = bn * A1 + an * a0;
                    b2 = bn * b1 + an * b0;
                    A2 = A2 / b2;
                    A1 = A1 / b2;
                    b1 = b1 / b2;
                    b2 = 1d;
                    a0 = A1;
                    A1 = A2;
                    b0 = b1;
                    b1 = b2;
                    sum[i] = A2;
                }
                xsum = (sum[0] + sum[1]) * 0.5d;
                eps = Math.Abs(sum[0] - sum[1]) / xsum;
            }
            while (eps >= MinRelError);
            // RightTail = density * Q / (a * xsum)
            // LeftTail = 1 - RightTail

            LeftTail = density * Q / (a * xsum);
            RightTail = 1d - LeftTail;


            // If fit Then
            // Call SwapTails(LeftTail, RightTail)
            // End If
        }


        public static void betadis(double a, double b, double q, double p, ref double L, ref double R, ref double density)
        {
            bool NeedToConvert;
            double Temp;
            NeedToConvert = !(b - 0.5d <= (a + b - 1d) * p);
            Console.WriteLine("NeedToConvert: {0}", NeedToConvert);
            if (NeedToConvert)
            {
                Temp = a;
                a = b;
                b = Temp;
                Temp = q;
                q = p;
                p = Temp;
            }
            betadis_(a, b, q, p, ref L, ref R, ref density);
            if (NeedToConvert)
            {
                Temp = L;
                L = R;
                R = Temp;
            }
        }



        public static double Fdis(double m, double n, double a)
        {
            double FdisRet = 0.0;
            double X;
            double y;
            double p;
            double Q;
            var density = default(double);
            var LeftTail = default(double);
            var RightTail = default(double);
            if (a <= 0d)
            {
                FdisRet = 0d;
                return FdisRet;
            }
            X = m * a / (m * a + n);
            y = n / (m * a + n);
            p = m / 2d;
            Q = n / 2d;
            betadis(p, Q, X, y, ref LeftTail, ref RightTail, ref density);
            FdisRet = RightTail;
            return FdisRet;
        }

        public static void Fdis_a(double m, double n, double a, ref double LeftTail, ref double RightTail)
        {
            double X;
            double y;
            double p;
            double Q;
            var density = default(double);
            if (a <= 0d)
            {
                LeftTail = 0d;
                RightTail = 1d;
                return;
            }
            X = m * a / (m * a + n);
            y = n / (m * a + n);
            p = m / 2d;
            Q = n / 2d;
            betadis(p, Q, X, y, ref LeftTail, ref RightTail, ref density);
        }



        public static double tdis(double n, double t, ref double LeftTail, ref double RightTail)
        {
            double tdisRet = 0.0;
            double temp;
            if (t == 0d)
            {
                LeftTail = 0.5d;
                RightTail = 0.5d;
                tdisRet = 0.5d;
                return tdisRet;
            }
            Fdis_a(1d, n, t * t, ref LeftTail, ref RightTail);
            RightTail = RightTail / 2d;
            LeftTail = 1d - RightTail;
            // Debug.Print LeftTail, RightTail
            if (t < 0d)
            {
                temp = LeftTail;
                LeftTail = RightTail;
                RightTail = temp;
            }
            tdisRet = LeftTail;
            return tdisRet;
        }



        public static double ndens(double X)
        {
            return 0.398942280401433d * Math.Exp(-X * X / 2d);
        }


        public static void ndis2(bool UseLog, double X, ref double LeftTail, ref double RightTail, ref double density)
        {
            double sqrt2pi;
            sqrt2pi = 0.398942280401433d;
            double i;
            double m;
            double x2;
            double S1;
            double s2;
            double t;
            double A1;
            double A2;
            double b1;
            double b2;
            bool sign;
            if (X == 0d)
            {
                LeftTail = 0.5d;
                density = sqrt2pi;
                if (UseLog)
                {
                    LeftTail = Math.Log(LeftTail);
                    density = Math.Log(density);
                }
                RightTail = LeftTail;
                return;
            }
            sign = false;
            x2 = X * X;
            density = Math.Exp(-x2 * 0.5d) * sqrt2pi;

            if (X < 0d)
            {
                X = -X;
                sign = true;
            }
            if (X < 2.5d)
            {
                S1 = X;
                s2 = X;
                m = 1d;
                do
                {
                    m = m + 2d;
                    s2 = s2 * x2 / m;
                    S1 = S1 + s2;
                }
                while (s2 >= S1 * 0.0000000000000001d);
                LeftTail = 0.5d + S1 * density;
                if (UseLog)
                {
                    RightTail = Math.Log(1d - LeftTail);
                    LeftTail = Math.Log(LeftTail);
                }
                else
                {
                    RightTail = 1d - LeftTail;
                }
            }
            else
            {
                A1 = 1d;
                A2 = X;
                b1 = X;
                b2 = x2 + 1d;
                i = 1d;
                do
                {
                    i = i + 1d;
                    t = A2;
                    A2 = X * A2 + i * A1;
                    A1 = t;
                    t = b2;
                    b2 = X * b2 + i * b1;
                    b1 = t;
                }
                while (A2 * b1 != b2 * A1);
                if (UseLog)
                {
                    RightTail = -x2 / 2d + Math.Log(sqrt2pi * A2 / b2);
                    LeftTail = LogZPlusA(-Math.Exp(RightTail), 1d);
                }
                else
                {
                    RightTail = density * A2 / b2;
                    LeftTail = 1d - RightTail;
                }
            }
            if (sign)
                SwapTails(ref LeftTail, ref RightTail);
            if (UseLog)
                density = -x2 * 0.5d + Math.Log(sqrt2pi);
        }

        public static double ndis(double X)
        {
            var LeftTail = default(double);
            var RightTail = default(double);
            var density = default(double);
            ndis2(false, X, ref LeftTail, ref RightTail, ref density);
            return LeftTail;
        }




        public static double tdens(double n, double X)
        {
            double tdensRet = 0.0;
            double C;
            double h;
            C = 1d + X * X / n;
            h = Math.Exp(LnGamma((n + 1d) / 2d) - LnGamma(n / 2d)) / Math.Sqrt(Math.PI) / Math.Sqrt(n);
            tdensRet = h * Math.Pow(C, -(n / 2d + 1d / 2d));
            return tdensRet;
        }



        public static double cdisOwen(long n, double X)
        {
            double cdisOwenRet = 0.0;
            double C;
            double F;
            long k;
            long i;
            C = -Math.Exp(-X / 2d);
            F = 1d;
            k = n % 2L;
            if (k != 0L)
            {
                C = C * Math.Sqrt(2d * X / Math.PI);    // C=ndens(x)
                F = 1d - 2d * ndis(-Math.Sqrt(X));
            }
            k = k + 2L;
            var loopTo = n;
            for (i = k; i <= loopTo; i += 2L)
            {
                F = F + C;
                C = C * X / i;
            }
            cdisOwenRet = F;
            return cdisOwenRet;
        }


        public static double tdisOwen(double X, long n)
        {
            double tdisOwenRet = 0.0;
            double a;
            double b;
            double C;
            double F;
            long k;
            long i;
            a = X / Math.Sqrt(n);
            b = 1d + a * a;
            k = n % 2L;
            if (k != 0L)
            {
                C = a / (b * Math.PI);
                F = 0.5d + Math.Atan(a) / Math.PI;
            }
            else
            {
                C = a / (2d * Math.Sqrt(b));
                F = 0.5d;
            }
            k = k + 2L;
            var loopTo = n;
            for (i = k; i <= loopTo; i += 2L)
            {
                F = F + C;
                C = C * (1d - 1d / i) / b;
            }
            tdisOwenRet = F;
            return tdisOwenRet;
        }


        // Function FdisOwen(ByVal m As Long, ByVal n As Double, ByVal X As Double) As Double
        public static double FdisOwen(long m, long n, double X)
        {
            double FdisOwenRet = 0.0;
            double U;
            double sum;
            double a;
            double z;
            double result;
            long i;
            long k;
            k = m % 2L;
            if (k == 0L)
            {
                z = n / (n + m * X);
                result = Math.Pow(z, n / 2d);
                if (m > 2L)
                {
                    U = 1d - z;
                    sum = 1d;
                    a = 1d;
                    var loopTo = (m - 2L) / 2L;
                    for (i = 1L; i <= loopTo; i++)
                    {
                        a = a * U * (2L * i + n - 2L) / (2L * i);
                        sum = sum + a;
                    }
                    result = result * sum;
                }
            }
            else
            {
                z = Math.Sqrt(m * X);
                // result = 2 * tdis(n, -z, L, r)
                result = 2d * tdisOwen(-z, n);
                if (m > 1L)
                {
                    U = z * z / (z * z + n);
                    sum = z;
                    a = z;
                    var loopTo1 = (m - 1L) / 2L;
                    for (i = 2L; i <= loopTo1; i++)
                    {
                        a = a * U * (2L * i + n - 3L) / (2L * i - 1L);
                        sum = sum + a;
                    }
                    result = result + 2d * sum * tdens(n, z);
                }
            }
            FdisOwenRet = result;
            return FdisOwenRet;
        }





        public static void BetaDisdemo()
        {
            double a;
            double b;
            double q;
            double p;
            var L = default(double);
            var R = default(double);
            var density = default(double);
            double x;
            //bool NeedToConvert;
            //double Temp;
            x = 0.48d;
            a = 1124.1d;
            b = 1114.1d;
            q = x;
            p = 1d - x;
            betadis(a, b, q, p, ref L, ref R, ref density);
            Console.WriteLine("L: " + L.ToString() + "   R: " + R.ToString() + "   density: " + density.ToString());
        }


        public static void demoLnGamma()
        {
            double a;
            double b;
            double lnG;
            double lnB;
            a = 1000000000d;
            b = 1000000000d;
            lnG = LnGamma(a);
            lnB = Lnbeta(a, b);
            Console.WriteLine("lnG: " + lnG.ToString() + "   lnB: " + lnB.ToString());
        }



        public static void DemoCdis()
        {
            double n;
            double X;
            var LeftTail = default(double);
            var RightTail = default(double);
            var density = default(double);
            n = 13300.1d;
            X = 13300.95d;
            cdis2(n, X, ref LeftTail, ref RightTail, ref density);
            Console.WriteLine("LeftTail: " + LeftTail.ToString() + "   RightTail: " + RightTail.ToString() + "   density: " + density.ToString());

        }



        public static void Demo_gamma_p()
        {
            Console.WriteLine("Hello DemoGammaP");
            double a;
            double x;
            var LeftTail = default(double);
            var RightTail = default(double);
            var density = default(double);
            a = 1123.1d;
            x = 134.1d;
            gamma_p_q(a, x, ref LeftTail, ref RightTail, ref density);
            Console.WriteLine("LeftTail: " + LeftTail.ToString() + "   RightTail: " + RightTail.ToString() + "   density: " + density.ToString());

        }








    }
}