using System;
using ArbPrecNet;

namespace Distributions
{




    static class DistPillaiHotelling
    {


        public static void CalcT2VMoments2(bool IsT2, int k, int m, double N1, double n2, double[] Moment)
        {
            // calculates the raw moments of the null distribution of Hotelling's T2 and Pillai's V
            var mu = new double[101];
            var L0 = new double[101];
            var nu = new double[101];
            var lambda = new double[101];
            var a = new double[101];
            var Lr = new double[101];
            int r;
            int j;
            double rfakt;
            double weight;
            double sum;
            var loopTo = m;
            for (r = 0; r <= loopTo; r++)
            {
                a[r] = 0.5d * (m - r) * (n2 - r);
                if (r == m)
                    lambda[r] = 0d;
                else
                    lambda[r] = (r + 1) * (n2 - r - 1d) * (m + n2 - r) * (N1 - m + 1d + r) / ((m + n2 - 2 * r - 2d) * (m + n2 - 2 * r - 1d));
                mu[r] = (-r * (m + n2 - r) * (m + 2d * N1 + n2 + 1d) + m * (N1 + n2) * (m + n2 + 1d)) / ((m + n2 - 2 * r - 1d) * (m + n2 - 2 * r + 1d));
                if (r == 0)
                    nu[r] = 0d;
                else
                    nu[r] = -(m - r + 1) * (N1 + n2 - r + 1d) / ((m + n2 - 2 * r + 1d) * (m + n2 - 2 * r + 2d));
                if (r < m)
                    L0[r] = 0d;
                else
                    L0[r] = 1d;
            }
            rfakt = 1d;
            var loopTo1 = k;
            for (r = 1; r <= loopTo1; r++)
            {
                rfakt = rfakt * r;
                Moment[r] = 0d;
                weight = 1d;
                for (j = m; j >= 0; j -= 1)
                {
                    sum = 0d;
                    if (j > 0)
                        sum = sum + nu[j] * L0[j - 1];
                    sum = sum + mu[j] * L0[j];
                    if (j < m)
                        sum = sum + lambda[j] * L0[j + 1];
                    sum = sum / (r - a[j]);
                    Lr[j] = sum;
                    Moment[r] = Moment[r] + sum / weight;
                    weight = weight * (n2 + m - j + 1d);
                }
                if (IsT2 & r % 2 != 0)
                    Moment[r] = -Moment[r];
                Moment[r] = Moment[r] * rfakt;
                // Debug.Print r, Moment(r)
                var loopTo2 = m;
                for (j = 0; j <= loopTo2; j++)
                    L0[j] = Lr[j];
            }
        }


        public static void CalcT2VMoments2Arb(bool IsT2, int k, int m, Arb N1, Arb n2, ArbMat Moment)
        {
            // calculates the raw moments of the null distribution of Hotelling's T2 and Pillai's V
            // Dim mu(0 To 100) As Double, L0(0 To 100) As Double, nu(0 To 100) As Double, lambda(0 To 100) As Double, a(0 To 100) As Double, Lr(0 To 100) As Double

            ArbMat mu = new ArbMat(), L0 = new ArbMat(), nu = new ArbMat(), lambda = new ArbMat(), a = new ArbMat(), Lr = new ArbMat();
            mu.Resize(k + 1, 1);
            L0.Resize(k + 1, 1);
            nu.Resize(k + 1, 1);
            lambda.Resize(k + 1, 1);
            a.Resize(k + 1, 1);
            Lr.Resize(k + 1, 1);

            int r;
            int j;
            // Dim rfakt As Double, weight As Double, sum As Double
            Arb rfakt = new Arb(), weight = new Arb(), sum = new Arb();

            var loopTo = m;
            for (r = 0; r <= loopTo; r++)
            {
                a[r] = 0.5d * (m - r) * (n2 - r);
                if (r == m)
                    lambda[r] = aflint.t(0);
                else
                    lambda[r] = (r + 1) * (n2 - r - 1) * (m + n2 - r) * (N1 - m + 1 + r) / ((m + n2 - 2 * r - 2) * (m + n2 - 2 * r - 1));
                mu[r] = (-r * (m + n2 - r) * (m + 2 * N1 + n2 + 1) + m * (N1 + n2) * (m + n2 + 1)) / ((m + n2 - 2 * r - 1) * (m + n2 - 2 * r + 1));
                if (r == 0)
                    nu[r] = aflint.t(0);
                else
                    nu[r] = -(m - r + 1) * (N1 + n2 - r + 1) / ((m + n2 - 2 * r + 1) * (m + n2 - 2 * r + 2));
                if (r < m)
                    L0[r] = aflint.t(0);
                else
                    L0[r] = aflint.t(1);
            }
            rfakt = aflint.t(1);
            var loopTo1 = k;
            for (r = 1; r <= loopTo1; r++)
            {
                rfakt = rfakt * r;
                Moment[r] = aflint.t(0);
                weight = aflint.t(1);
                for (j = m; j >= 0; j -= 1)
                {
                    sum = aflint.t(0);
                    if (j > 0)
                        sum = sum + nu[j] * L0[j - 1];
                    sum = sum + mu[j] * L0[j];
                    if (j < m)
                        sum = sum + lambda[j] * L0[j + 1];
                    sum = sum / (r - a[j]);
                    Lr[j] = sum;
                    Moment[r] = Moment[r] + sum / weight;
                    weight = weight * (n2 + m - j + 1);
                }
                if (IsT2 & r % 2 != 0)
                    Moment[r] = -Moment[r];
                Moment[r] = Moment[r] * rfakt;
                // Debug.Print r, Moment(r)
                var loopTo2 = m;
                for (j = 0; j <= loopTo2; j++)
                    L0[j] = Lr[j];
            }
        }



        public static void Hotelling3Moments(double p, double N1, double n2)
        {
            double n;
            double m;
            double mu1;
            double mu2;
            double mu3;
            double a;

            m = (N1 - p - 1d) / 2d;
            n = (n2 - p - 1d) / 2d;
            mu1 = p * (2d * m + p + 1d) / (2d * n);
            mu2 = mu1 * (2d * m + 2d * n + p + 1d) * (2d * n + p) / (2d * n * (n - 1d) * (2d * n + 1d));
            mu3 = 2d * mu2 * (2d * m + n + p + 1d) * (n + p) / (n * (n - 2d) * (n + 1d));
            a = mu3 + 3d * mu2 * mu1 + Math.Pow(mu1, 2d) * mu1;
            Console.WriteLine("1.: {0}, 2.: {1}, 3.: {2}", mu1, mu2 + Math.Pow(mu1, 2d), a);
        }

        public static void Pillai3Moments(double p, double N1, double n2)
        {
            double s;
            double n;
            double m;
            double mu1;
            double mu2;
            double mu3;
            double a;
            m = (N1 - p - 1d) / 2d;
            n = (n2 - p - 1d) / 2d;
            s = p;
            mu1 = s * (2d * m + s + 1d) / (2d * (m + n + s + 1d));
            mu2 = s * (2d * m + s + 1d) * (2d * n + s + 1d) * (2d * m + 2d * n + s + 2d) / (4d * Math.Pow(m + n + s + 1d, 2d) * (m + n + s + 2d) * (2d * m + 2d * n + 2d * s + 1d));
            mu3 = s * (n - m) * (2d * m + s + 1d) * (2d * n + s + 1d) * (m + n + 1d) * (2d * m + 2d * n + s + 2d) / (Math.Pow(m + n + s + 1d, 2d) * (m + n + s + 1d) * (m + n + s + 2d) * (m + n + s + 3d) * (2d * m + 2d * n + 2d * s) * (2d * m + 2d * n + 2d * s + 1d));

            a = mu3 + 3d * mu2 * mu1 + Math.Pow(mu1, 2d) * mu1;
            Console.WriteLine("1.: {0}, 2.: {1}, 3.: {2}", mu1, mu2 + Math.Pow(mu1, 2d), a);
        }

        public static void CalcT2Moments(int k, int m, double N1, double n2, double[] mraw)
        {
            CalcT2VMoments2(true, k, m, N1, n2, mraw);
        }

        public static void CalcVMoments(int k, int m, double N1, double n2, double[] mraw)
        {
            CalcT2VMoments2(false, k, m, N1, m - N1 - n2 + 1d, mraw);
        }


        public static void CalcT2MomentsArb(int k, int m, double N1, double n2, ArbMat mraw)
        {
            CalcT2VMoments2Arb(true, k, m, aflint.t(N1), aflint.t(n2), mraw);
        }

        public static void CalcVMomentsArb(int k, int m, double N1, double n2, ArbMat mraw)
        {
            CalcT2VMoments2Arb(false, k, m, aflint.t(N1), aflint.t(m - N1 - n2 + 1d), mraw);
        }


        public static void DemoCalcT2()
        {
            int k;
            int p;
            double N1;
            double n2;
            double[] mraw;
            double[] mu;
            double[] kappa;
            k = 14;
            p = 12;
            N1 = 25d;
            n2 = 225d;


            double RightTail = 0.1d;
            double LeftTail = 1d - RightTail;


            Pillai3Moments(p, N1, n2);
            mraw = new double[k + 1];
            CalcVMoments(k, p, N1, n2, mraw);
            int i;
            var loopTo = k;
            for (i = 1; i <= loopTo; i++)
                Console.WriteLine("i: {0}, mraw(i): {1}", i, mraw[i]);

            mu = new double[k + 1];
            kappa = new double[k + 1];

            // !!!!! Replace with RawMomentsToCumulants !!!!

            DistCornish.RawMomentsToMoments(k, ref mraw, ref mu);
            var loopTo1 = k;
            for (i = 1; i <= loopTo1; i++)
                Console.WriteLine("i: {0}, mu(i): {1}", i, mu[i]);

            DistCornish.MomentsToCumulants(k, ref mu, ref kappa);
            var loopTo2 = k;
            for (i = 1; i <= loopTo2; i++)
                Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa[i]);

            // !!!!! Replace with RawMomentsToCumulants !!!!

            var kappaArb = new ArbMat();
            kappaArb.Resize(100, 1);
            var loopTo3 = k;
            for (i = 1; i <= loopTo3; i++)
                kappaArb[i] = aflint.t(kappa[i]);

            var mean = kappaArb[1];
            var sigma = aflint.sqrt(kappaArb[2]);
            // Dim sigma2 = kappaArb(2)

            var result = new Arb();

            var XX = DistXArb.ndisxArb(aflint.t(LeftTail), aflint.t(1d - LeftTail));

            var XAdj = DistCornishArb.CFArb(k - 2, XX, kappaArb);
            Console.WriteLine("mean: {0}, sigma: {1}, XAdj: {2}", mean, sigma, XAdj);
            Console.WriteLine("(mean + sigma * XAdj): {0}", mean + sigma * XAdj);

            var fxTarget = XAdj;
            Console.WriteLine("fxTarget: {0}", fxTarget);

            Console.WriteLine("");
            var x3Start = DistCornishArb.CF_up(fxTarget, kappaArb);
            Console.WriteLine("x3Start : {0}", x3Start);

            // Dim Result2 As Arb = InvCornArb(fxTarget, x3Start, kappaArb, k)
            // Console.WriteLine("Result2 : {0}", Result2)
            // Console.WriteLine("x3Start: {0}", x3Start)

            // LeftTail = NdisArb(Result2)
            // RightTail = 1 - LeftTail
            // Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail)


        }



        public static void Pillai3Cumulants(double p, double n1, double n2)
        {
            double s;
            double n;
            double m;
            double k1;
            double k2;
            double k3;
            m = (n1 - p - 1d) / 2d;
            n = (n2 - p - 1d) / 2d;
            s = p;
            k1 = s * (2d * m + s + 1d) / (2d * (m + n + s + 1d));
            k2 = s * (2d * m + s + 1d) * (2d * n + s + 1d) * (2d * m + 2d * n + s + 2d) / (4d * Math.Pow(m + n + s + 1d, 2d) * (m + n + s + 2d) * (2d * m + 2d * n + 2d * s + 1d));
            k3 = s * (n - m) * (2d * m + s + 1d) * (2d * n + s + 1d) * (m + n + 1d) * (2d * m + 2d * n + s + 2d) / (Math.Pow(m + n + s + 1d, 2d) * (m + n + s + 1d) * (m + n + s + 2d) * (m + n + s + 3d) * (2d * m + 2d * n + 2d * s) * (2d * m + 2d * n + 2d * s + 1d));

            Console.WriteLine("1.: {0}, 2.: {1}, 3.: {2}", k1, k2, k3);

            double k12, k22, f1, f2, b;
            k12 = k1 * k1;
            k22 = k2 * k2;
            f1 = 4d * k1 * (k12 * k2 - k22 + k1 * k3) / (4d * k1 * k22 - k12 * k3 + k2 * k3);
            f2 = 4d * k2 * (2d * k1 * k2 + k3) * (k12 * k2 - k22 + k1 * k3) / ((k1 * k3 - 2d * k22) * (k12 * k3 - 4d * k1 * k22 - k2 * k3));
            b = (k12 * k3 - 4d * k1 * k22 - k2 * k3) / (k1 * k3 - 2d * k22);

            double RightTail = 0.01d;
            double LeftTail = 1d - RightTail;
            double wx = 0.0, wy = 0.0;
            DistX.betadisx(LeftTail, RightTail, f1 / 2d, f2 / 2d, ref wx, ref wy);
            double V = b * wx;
            Console.WriteLine("V: {0}", V);
        }


        public static double Pillai3VX(double p, double n1, double n2, double LeftTail, double Righttail)
        {
            double n;
            double m;
            double k1;
            double k2;
            double k3;
            double r;
            m = (n1 - p - 1d) / 2d;
            n = (n2 - p - 1d) / 2d;
            r = m + n + p;
            k1 = p * (2d * m + p + 1d) / (2d * (r + 1d));
            k2 = k1 * (2d * n + p + 1d) * (2d * m + 2d * n + p + 2d) / (2d * (r + 1d) * (r + 2d) * (2d * r + 1d));
            k3 = 4d * k2 * (n - m) * (m + n + 1d) / ((r + 1d) * (r + 3d) * (2d * r));
            // Console.WriteLine("1.: {0}, 2.: {1}, 3.: {2}", k1, k2, k3)

            double k12, k22;
            k12 = k1 * k1;
            k22 = k2 * k2;
            double a = 2d * k1 * (k12 * k2 - k22 + k1 * k3) / (4d * k1 * k22 - k12 * k3 + k2 * k3);
            double b = 2d * k2 * (2d * k1 * k2 + k3) * (k12 * k2 - k22 + k1 * k3) / ((k1 * k3 - 2d * k22) * (k12 * k3 - 4d * k1 * k22 - k2 * k3));
            double k = (k12 * k3 - 4d * k1 * k22 - k2 * k3) / (k1 * k3 - 2d * k22);

            double wx = 0.0d, wy = 0.0;
            DistX.betadisx(LeftTail, Righttail, a, b, ref wx, ref wy);
            double V = k * wx;
            // Console.WriteLine("(n + m) * V / n: {0}", (n1 + n2) * V / n1)

            return V;
        }

        public static void DemoCalcPillaiArb()
        {
            int k;
            int p;
            double n1;
            double n2;
            ArbMat mraw = new ArbMat(), mu = new ArbMat(), kappa = new ArbMat();
            // Dim mraw() As Double ', mu() As Double, kappa() As Double
            k = 22;
            p = 4;
            n1 = 10d;
            n2 = 125d;

            double RightTail = 0.05d;
            double LeftTail = 1d - RightTail;


            Pillai3Cumulants(p, n1, n2);
            mraw.Resize(k + 1, 1);
            mu.Resize(k + 1, 1);
            kappa.Resize(k + 1, 1);

            CalcVMomentsArb(k, p, n1, n2, mraw);
            int i;
            var loopTo = k;
            for (i = 1; i <= loopTo; i++)
                Console.WriteLine("i: {0}, mraw(i): {1}", i, mraw[i]);


            DistCornishArb.RawToCentralArb(k, mraw, mu);
            var loopTo1 = k;
            for (i = 1; i <= loopTo1; i++)
                Console.WriteLine("i: {0}, mu(i): {1}", i, mu[i]);

            DistCornishArb.MomentsToCumulantsArb(k, mu, kappa);
            var loopTo2 = k;
            for (i = 1; i <= loopTo2; i++)
                Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa[i]);

            var mean = kappa[1];
            var sigma = aflint.sqrt(kappa[2]);

            var result = new Arb();

            var XX = DistXArb.ndisxArb(aflint.t(LeftTail), aflint.t(1d - LeftTail));

            var XAdj = DistCornishArb.CFArb(k, XX, kappa);
            Console.WriteLine("mean: {0}, sigma: {1}, XAdj: {2}", mean, sigma, XAdj);
            Console.WriteLine("(mean + sigma * XAdj): {0}", mean + sigma * XAdj);


            var V = default(double);
            PillaiVX(p, n1, n2, ref V, LeftTail, RightTail);
            Console.WriteLine("V2: {0}", V / n2);

            // Pillai3Cumulants(p, N1, n2)
            V = Pillai3VX(p, n1, n2, LeftTail, RightTail);
            Console.WriteLine("V3: {0}", V);
            Console.WriteLine("Comparison with Anderson 2003, Table 3, page 630 - 633");
            Console.WriteLine("(n1 + n2) * V / 1: {0}", (n1 + n2) * V / n1);


            // Dim fxTarget = XAdj
            // Console.WriteLine("fxTarget: {0}", fxTarget)

            // Console.WriteLine("")
            // Dim x3Start = CF_up(fxTarget, kappa)
            // Console.WriteLine("x3Start : {0}", x3Start)

            // Dim Result2 As Arb = InvCornArb(fxTarget, x3Start, kappa, k)
            // Console.WriteLine("Result2 : {0}", Result2)
            // Console.WriteLine("x3Start: {0}", x3Start)

            // LeftTail = NdisArb(Result2)
            // RightTail = 1 - LeftTail
            // Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail)


        }


        public static void DemoCalcHotellingArb()
        {
            int k;
            int p;
            double n1;
            double n2;
            ArbMat mraw = new ArbMat(), mu = new ArbMat(), kappa = new ArbMat();
            // Dim mraw() As Double ', mu() As Double, kappa() As Double
            k = 22;
            p = 10;
            n1 = 35d;
            n2 = 200d;

            double RightTail = 0.05d;
            double LeftTail = 1d - RightTail;


            Hotelling3Moments(p, n1, n2);
            mraw.Resize(k + 1, 1);
            mu.Resize(k + 1, 1);
            kappa.Resize(k + 1, 1);

            CalcT2MomentsArb(k, p, n1, n2, mraw);
            int i;
            var loopTo = k;
            for (i = 1; i <= loopTo; i++)
                Console.WriteLine("i: {0}, mraw(i): {1}", i, mraw[i]);


            DistCornishArb.RawToCentralArb(k, mraw, mu);
            var loopTo1 = k;
            for (i = 1; i <= loopTo1; i++)
                Console.WriteLine("i: {0}, mu(i): {1}", i, mu[i]);

            DistCornishArb.MomentsToCumulantsArb(k, mu, kappa);
            var loopTo2 = k;
            for (i = 1; i <= loopTo2; i++)
                Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa[i]);

            var mean = kappa[1];
            var sigma = aflint.sqrt(kappa[2]);

            var result = new Arb();

            var XX = DistXArb.ndisxArb(aflint.t(LeftTail), aflint.t(1d - LeftTail));

            var XAdj = DistCornishArb.CFArb(k, XX, kappa);
            Console.WriteLine("mean: {0}, sigma: {1}, XAdj: {2}", mean, sigma, XAdj);
            Console.WriteLine("(mean + sigma * XAdj): {0}", mean + sigma * XAdj);

            var t2 = default(double);
            HotellingX2(p, n1, n2, ref t2, LeftTail, RightTail);
            Console.WriteLine("t2: {0}", t2 / n2);

            Console.WriteLine("Comparison with Anderson 2003, Table 2, page 616 - 629");
            Console.WriteLine("n2 * t2 / n1: {0}", n2 * t2 / n1 / n2);


            // Dim fxTarget = XAdj
            // Console.WriteLine("fxTarget: {0}", fxTarget)

            // Console.WriteLine("")
            // Dim x3Start = CF_up(fxTarget, kappa)
            // Console.WriteLine("x3Start : {0}", x3Start)

            // Dim Result2 As Arb = InvCornArb(fxTarget, x3Start, kappa, k)
            // Console.WriteLine("Result2 : {0}", Result2)
            // Console.WriteLine("x3Start: {0}", x3Start)

            // LeftTail = NdisArb(Result2)
            // RightTail = 1 - LeftTail
            // Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail)


        }


        public static void HotellingExact2(double m, double n, double w, double LeftTail, double Righttail)
        {
            double y;
            double sum1;
            double sum2;
            double sum3;
            double sum4;
            var density = default(double);
            const double pi = 3.14159265358979d;
            w = w / n;
            y = w / (2d + w);
            DistMain.betadis(m - 1d, n - 1d, y, 1d - y, ref LeftTail, ref Righttail, ref density);
            sum1 = LeftTail;
            DistMain.betadis((m - 1d) / 2d, (n - 1d) / 2d, y * y, 1d - y * y, ref LeftTail, ref Righttail, ref density);
            sum2 = LeftTail;
            sum3 = Math.Sqrt(pi) * Math.Exp(DistMain.LnGamma((m + n - 1d) / 2d) - DistMain.LnGamma(m / 2d) - DistMain.LnGamma(n / 2d));
            sum4 = Math.Exp(Math.Log(1d + w) * (-0.5d * (n - 1d)));
            LeftTail = sum1 - sum2 * sum3 * sum4;
            Righttail = 1d - LeftTail;
        }


        // Let m=(n1-p-1)/2 and n=(n2-p-1)/2.}

        public static void Hotelling(double p, double m, double n, double x, double LeftTail, double Righttail)
        {
            var density = default(double);
            double mu1;
            double mu2;
            double mu3;
            double mu12;
            double mu13;
            double mu22;
            double a;
            double b;
            double k;
            double w;
            mu1 = p * (2d * m + p + 1d) / (2d * n);
            mu2 = mu1 * (2d * m + 2d * n + p + 1d) * (2d * n + p) / (2d * n * (n - 1d) * (2d * n + 1d));
            mu3 = 2d * mu2 * (2d * m + n + p + 1d) * (n + p) / (n * (n - 2d) * (n + 1d));
            mu12 = Math.Pow(mu1, 2d);
            mu13 = mu1 * mu12;
            mu22 = Math.Pow(mu2, 2d);
            a = (2d * mu13 * mu2 + 3d * mu12 * mu3 - 6d * mu1 * mu22 - mu2 * mu3) / (mu2 * mu3 + 4d * mu1 * mu22 - mu12 * mu3);
            b = ((a + 1d) * (a + 3d) - mu12 / mu2) / (a + 1d - mu12 / mu2);
            k = mu1 * (b - a - 2d) / (a + 1d);
            w = x / (x + k);
            DistMain.betadis(a + 1d, b - a - 1d, w, 1d - w, ref LeftTail, ref Righttail, ref density);
        }


        public static void Hotelling2(double p, double N1, double n2, double t2, double LeftTail, double Righttail)
        {
            double m;
            double n;
            double x;
            m = (N1 - p - 1d) / 2d;
            n = (n2 - p - 1d) / 2d;
            x = t2 / n2;
            Hotelling(p, m, n, x, LeftTail, Righttail);
        }


        // cdf of S_1/(S_1 + S_2)}

        public static void PillaiV(double p, double N1, double n2, double x, double LeftTail, double Righttail)
        {
            double s;
            double n;
            double m;
            var density = default(double);
            double mu1;
            double mu2;
            double a;
            double b;
            double w;
            double m1;
            double m2;
            x = x / n2;
            m = (N1 - p - 1d) / 2d;
            n = (n2 - p - 1d) / 2d;
            s = p;
            mu1 = s * (2d * m + s + 1d) / (2d * (m + n + s + 1d));
            mu2 = s * (2d * m + s + 1d) * (2d * n + s + 1d) * (2d * m + 2d * n + s + 2d) / (4d * Math.Pow(m + n + s + 1d, 2d) * (m + n + s + 2d) * (2d * m + 2d * n + 2d * s + 1d));
            m1 = mu1 / p;
            m2 = mu2 / (p * p);
            a = m1 / m2 * (m1 - Math.Pow(m1, 2d) - m2);
            b = a * (1d - m1) / m1;
            w = x / p;
            DistMain.betadis(a, b, w, 1d - w, ref LeftTail, ref Righttail, ref density);
        }



        public static void PillaiVX(double p, double N1, double n2, ref double x, double LeftTail, double Righttail)
        {
            double s;
            double n;
            double m;
            double mu1;
            double mu2;
            double a;
            double b;
            double m1;
            double m2;
            var wx = default(double);
            var wy = default(double);
            m = (N1 - p - 1d) / 2d;
            n = (n2 - p - 1d) / 2d;
            s = p;
            mu1 = s * (2d * m + s + 1d) / (2d * (m + n + s + 1d));
            mu2 = s * (2d * m + s + 1d) * (2d * n + s + 1d) * (2d * m + 2d * n + s + 2d) / (4d * Math.Pow(m + n + s + 1d, 2d) * (m + n + s + 2d) * (2d * m + 2d * n + 2d * s + 1d));
            m1 = mu1 / p;
            m2 = mu2 / (p * p);
            a = m1 / m2 * (m1 - Math.Pow(m1, 2d) - m2);
            b = a * (1d - m1) / m1;
            DistX.betadisx(LeftTail, Righttail, a, b, ref wx, ref wy);
            x = wx * n2 * p;
        }





        public static void HotellingX(double p, double m, double n, ref double x, double LeftTail, double Righttail)
        {
            double mu1;
            double mu2;
            double mu3;
            double mu12;
            double mu13;
            double mu22;
            double a;
            double b;
            double k;
            var wx = default(double);
            var wy = default(double);
            mu1 = p * (2d * m + p + 1d) / (2d * n);
            mu2 = mu1 * (2d * m + 2d * n + p + 1d) * (2d * n + p) / (2d * n * (n - 1d) * (2d * n + 1d));
            mu3 = 2d * mu2 * (2d * m + n + p + 1d) * (n + p) / (n * (n - 2d) * (n + 1d));
            mu12 = Math.Pow(mu1, 2d);
            mu13 = mu1 * mu12;
            mu22 = Math.Pow(mu2, 2d);
            a = (2d * mu13 * mu2 + 3d * mu12 * mu3 - 6d * mu1 * mu22 - mu2 * mu3) / (mu2 * mu3 + 4d * mu1 * mu22 - mu12 * mu3);
            b = ((a + 1d) * (a + 3d) - mu12 / mu2) / (a + 1d - mu12 / mu2);
            k = mu1 * (b - a - 2d) / (a + 1d);
            DistX.betadisx(LeftTail, Righttail, a + 1d, b - a - 1d, ref wx, ref wy);
            x = k * (wx / wy);
        }

        // x=T²/n2 is distributed as Iw(a+1,b-a-1), where w=x/(x+K)


        public static void HotellingX2(double p, double n1, double n2, ref double t2, double LeftTail, double Righttail)
        {
            double m;
            double n;
            var x = default(double);
            m = (n1 - p - 1d) / 2d;
            n = (n2 - p - 1d) / 2d;
            HotellingX(p, m, n, ref x, LeftTail, Righttail);
            t2 = x * n2;
        }



        private static double Getc(int j, int r, int m, double[,] c)
        {
            double GetcRet = 0;
            if (j == 0 & r == 0)
            {
                GetcRet = 1d;
                return GetcRet;
            }
            if (j == 1 & r == 1)
            {
                GetcRet = c[1, 1]; // 
                return GetcRet;
            }
            if (j <= 0 | j > m | r <= 1)
                GetcRet = 0d;
            else
                GetcRet = c[j, r];
            return GetcRet;
        }

        public static void DavisOmega(int dis, int m, double N1, double n2, double[] omega, int cmax)
        {
            // { dis=1 as Pillai dis=2 as Hotelling }
            int i;
            int j;
            int r;
            int r1;
            int i2;
            double c11;
            double sum;
            double s;
            double a;
            double k;
            var c = new double[31, 31];
            if (dis == 1)
            {
                s = 1d;
                k = m + 1;
                a = 2d * k + N1;
            }
            else
            {
                s = -1;
                k = -N1;
                a = 2d * N1 + m + 1d;
            }
            c[1, 1] = s * m * N1;
            omega[1] = m * N1 * k / (2d * n2);
            Console.WriteLine("r: {0}, omega(r): {1}", 1, omega[1]);
            var loopTo = cmax;
            for (r = 2; r <= loopTo; r++)
            {
                r1 = r;
                if (r > m)
                    r1 = m;
                for (j = r1; j >= 1; j -= 1)
                {
                    i = r - j + 1;
                    if (j <= m)
                    {
                        c[j, i] = s * ((m - j + 1) * (N1 - j + 1d)) * Getc(j - 1, i - 1, m, c) + s * ((j * (a - 2 * j) + 2 * (i - 1)) / n2) * Getc(j, i - 1, m, c) + ((j + 1) / n2 - (j + 1) * s * (s * k - j) / (n2 * n2)) * Getc(j + 1, i - 1, m, c) - s * ((m * N1 + 2 * (i - 2)) / n2) * Getc(j, i - 2, m, c);


                        sum = 0d;
                        var loopTo1 = i - 2;
                        for (i2 = 1; i2 <= loopTo1; i2++)
                            sum = sum + s * i2 * omega[i2] * (Getc(j, i - i2 - 1, m, c) - Getc(j, i - i2 - 2, m, c));
                        sum = 2d * sum / n2;
                        c[j, i] = (c[j, i] + sum) / j;
                    }
                }
                c11 = c[1, r];
                omega[r] = (2 * (r - 1) * omega[r - 1] - s * (1d - k / n2) * c11) / (2 * r);
                Console.WriteLine("r: {0}, omega(r): {1}", r, omega[r]);
            }
        }

        public static void DemoOmega_T()
        {
            double LeftTail;
            double Righttail;
            int cmax;
            double x;
            int m;
            double N1;
            double n2;
            var omega = new double[31];
            var omegaArb = new ArbMat();
            Console.WriteLine();

            x = 6d;
            cmax = 22;
            m = 1;
            N1 = 12d;
            n2 = 180d;
            Righttail = 0.01d;
            LeftTail = 1d - Righttail;
            HotellingX2(m, N1, n2, ref x, LeftTail, Righttail);
            Console.WriteLine("x: {0}", x);
            // Debug.Print "x: ", x
            DavisOmega(2, m, N1, n2, omega, cmax);

            omegaArb.Resize(100, 1);
            for (int i = 1, loopTo = cmax; i <= loopTo; i++)
                omegaArb[i] = aflint.t(omega[i]);

            var TargetError = aflint.t("1E-40");
            DistBoxDavisArb.GuptaArb(cmax, aflint.t(m * N1), aflint.t(x), aflint.t(1.0d), omegaArb, TargetError);
        }


        public static void DemoOmega_V()
        {
            double LeftTail;
            double Righttail;
            int cmax;
            double x;
            int m;
            double N1;
            double n2;
            var omega = new double[31];
            var omegaArb = new ArbMat();
            x = 6d;
            cmax = 22;
            m = 1;
            N1 = 12d;
            n2 = 180d;
            Righttail = 0.01d;
            LeftTail = 1d - Righttail;
            PillaiVX(m, N1, n2, ref x, LeftTail, Righttail);
            Console.WriteLine("x: {0}", x);
            // Debug.Print "x: ", x
            DavisOmega(1, m, N1, n2, omega, cmax);

            omegaArb.Resize(100, 1);
            for (int i = 1, loopTo = cmax; i <= loopTo; i++)
                omegaArb[i] = aflint.t(omega[i]);
            var TargetError = aflint.t("1.0E-10");
            DistBoxDavisArb.GuptaArb(cmax, aflint.t(m * N1), aflint.t(x), aflint.t(1.0d), omegaArb, TargetError);
        }



        public static void FujiX(bool t2, double p, double q, double n, ref double x, double LeftTail, double Righttail)
        {
            double u;
            double u2;
            double u3;
            double u4;
            double u5;
            double u6;
            double h;
            double h2;
            double h3;
            double f4;
            double f6;
            double f8;
            double pq;
            double sum0;
            double sum1;
            double sum2;
            double sum3;
            double f2;
            double F;
            double G;
            double g2;

            F = p * q;
            G = p + q + 1d;
            g2 = G * G;
            f2 = F * F;
            u = DistX.cdisx(LeftTail, Righttail, F);
            u2 = u * u;
            u3 = u2 * u;
            u4 = u3 * u;
            u5 = u4 * u;
            u6 = u5 * u;
            h = F + 2d;
            h2 = h * h;
            h3 = h2 * h;
            f4 = F + 4d;
            f6 = f4 * (F + 6d);
            f8 = f6 * (F + 8d);
            pq = (p - 1d) * (p + 2d) * (q - 1d) * (q + 2d);
            sum0 = u;
            sum1 = G * (u - u2 / h);
            sum2 = u * (7d * g2 - 2d * G - 2d * h) - u2 * (11d * g2 + 2d * G + 2d * h) / h + 2d * u3 * (2d * (F + 5d) * g2 - h * G - h2) / (h2 * f4) + 6d * u4 * pq / (h2 * f6);


            sum3 = 3d * u * G * (3d * g2 - 2d * G - 2d * h) - u2 * G * (17d * g2 + 2d * G + 2d * h) / h + 2d * u3 * G * ((5d * F + 26d) * g2 - (F - 2d) * G - (F - 2d) * h) / (h2 * f4) - 2d * u4 * G * ((f2 + 24d * F + 68d) * g2 - (7d * F + 22d) * h * G - (7d * F + 22d) * h2) / (h3 * f6) + 4d * u5 * pq * ((F - 28d) * G + 6d * h) / (h3 * f8) - 8d * u6 * pq * ((F - 10d) * G + 3d * h) / (h3 * f8 * (F + 10d));



            sum1 = sum1 / (2d * n);
            sum2 = sum2 / (24d * n * n);
            sum3 = sum3 / (48d * n * n * n);

            // Console.WriteLine(sum0)
            // Console.WriteLine(sum1)
            // Console.WriteLine(sum2)
            // Console.WriteLine(sum3)

            if (t2)
            {
                x = sum0 - sum1 + sum2 - sum3;
            }
            else
            {
                x = sum0 + sum1 + sum2 + sum3;
            }
        }

        public static double VdisX(double LeftTail, double Righttail, double p, double q, double n)
        {
            double VdisXRet = 0;
            var x = default(double);
            FujiX(false, p, q, n + q, ref x, LeftTail, Righttail);
            VdisXRet = x / (n + q);
            return VdisXRet;
        }

        public static double T2disX(double LeftTail, double Righttail, double p, double q, double n)
        {
            double T2disXRet = 0;
            var x = default(double);
            double N1;
            N1 = Math.Abs(n - p - 1d);
            if (N1 == 0d)
                N1 = 1d;
            FujiX(true, p, q, N1, ref x, LeftTail, Righttail);
            T2disXRet = x / N1;
            return T2disXRet;
        }







    }
}