using System;
using ArbPrecNet;

namespace Distributions
{


    // 
    public static class DistXArb
    {


        internal const int mp_ndisx = 0;
        internal const int mp_cdisx = 1;
        internal const int mp_fdisx = 2;

        public static Arb gamma_p(Arb a, Arb x)
        {
            Arb LeftTail = new Arb(), RightTail = new Arb();
            gamma_inc_Arb(a, x, ref LeftTail, ref RightTail);
            return LeftTail;
        }


        public static void DemoGamma_Arb_p()
        {
            Arb a = new Arb(), x = new Arb();
            a = aflint.t("12123.1");
            x = aflint.t("11134.1");
            // a = aflint.t("1000000000000")
            // x = a
            // x = x - 150 * aflint.sqrt(x)
            Console.WriteLine("a: {0}", a);
            Console.WriteLine("x:  {0}", x);
            // Dim result1 = aflint.gamma_p_hyper(a, x)
            // Console.WriteLine("result1: {0}", result1)
            var result2 = aflint.gamma_p(a, x);
            Console.WriteLine("result2: {0}", result2);
            var result3 = gamma_p(a, x);
            Console.WriteLine("result3: {0}", result3);
        }


        public static Arb gamma_q(Arb a, Arb x)
        {
            Arb LeftTail = new Arb(), RightTail = new Arb();
            gamma_inc_Arb(a, x, ref LeftTail, ref RightTail);
            return RightTail;
        }


        public static void DemoGamma_q()
        {
            Arb a = new Arb(), x = new Arb();
            // a = aflint.t("5")
            // x = aflint.t("6")
            a = aflint.t("18");
            x = aflint.t("10");
            // Dim result1 = aflint.gamma_q_hyper(a, x)
            // Console.WriteLine("result1: {0}", result1)
            var result2 = aflint.gamma_q(a, x);
            Console.WriteLine("result2: {0}", result2);
            var result3 = gamma_q(a, x);
            Console.WriteLine("result3: {0}", result3);
        }


        public static void gamma_inc_Arb(Arb b, Arb m, ref Arb LeftTail, ref Arb RightTail)
        {
            int j;
            int i;
            Arb eps, k, sum0, sum1;
            Arb xsum;
            Arb a0;
            Arb a1;
            Arb a2;
            Arb an;
            Arb b0;
            Arb b1;
            Arb b2;
            Arb bn;
            Arb MinRelError;
            bool swapped;
            MinRelError = aflint.epsilon();
            if (m <= aflint.t("0"))
            {
                LeftTail = aflint.t(0);
                RightTail = aflint.t(1);
                return;
            }
            k = aflint.gamma_p_derivative(b, m);
            if (m <= aflint.t("6.0") | m <= b)
            {
                swapped = true;
            }
            // Console.WriteLine("Using C3")
            else
            {
                swapped = false;
                // Console.WriteLine("NOT Using C3")
            }
            a0 = aflint.t(1);
            b0 = aflint.t(1);
            bn = aflint.t(0);
            j = 0;
            sum0 = aflint.t(1);
            sum1 = aflint.t(1);
            if (swapped)
            {
                k = k * m / b;
                b1 = b + 1;
                bn = b1;
                a1 = -m;
            }
            else
            {
                b1 = m;
                a1 = 1 - b;
            }
            int nord = 100000;
            var aCoeff = new ArbMat();
            var bCoeff = new ArbMat();
            aCoeff.Resize(nord + 1, 1);
            bCoeff.Resize(nord + 1, 1);
            aCoeff[0] = a0;
            aCoeff[1] = a1;
            bCoeff[0] = b0;
            bCoeff[1] = b1;
            Console.WriteLine("2*j+i: {0}, an: {1}, bn: {2}", 0, a0, b0);
            Console.WriteLine("2*j+i: {0}, an: {1}, bn: {2}", 1, a1, b1);

            a1 = b1 + a1;
            do
            {
                j = j + 1;
                for (i = 0; i <= 1; i++)
                {
                    if (i == 1)
                    {
                        if (swapped)
                        {
                            an = -(b + j) * m;
                            bn = bn + 1;
                        }
                        else
                        {
                            an = j + 1 - b;
                            bn = m;
                        }
                    }
                    else if (swapped)
                    {
                        an = j * m;
                        bn = bn + 1;
                    }
                    else
                    {
                        an = aflint.t(j);
                        bn = aflint.t(1);
                    }

                    aCoeff[2 * j + i] = an;
                    bCoeff[2 * j + i] = bn;
                    a2 = bn * a1 + an * a0;
                    b2 = bn * b1 + an * b0;
                    var b2_inv = 1 / b2;
                    a2 = a2 * b2_inv;
                    a1 = a1 * b2_inv;
                    b1 = b1 * b2_inv;
                    b2 = aflint.t(1);
                    a0 = a1;
                    a1 = a2;
                    b0 = b1;
                    b1 = b2;
                    a2.Rad = aflint.t(0);
                    Console.WriteLine("2*j+i: {0}, an: {1}, bn: {2}, a2: {2}", 2 * j + i, an, bn, a2);
                    if (i == 0)
                        sum0 = a2;
                    else
                        sum1 = a2;
                }
                // xsum = aflint.union(sum0, sum1)
                xsum = (sum0 + sum1) / 2;
                eps = (sum0 - sum1) / xsum;
            }
            // Console.WriteLine("sum{0}: {1}, sum{2}: {3},  eps: {4}, xsum: {5}", 2 * j - 2, sum0, 2 * j - 1, sum1, eps, xsum)
            while (!(aflint.abs(eps) < MinRelError & j % 2 == 0));
            // Console.WriteLine("j: {0,4}", j)
            // Console.WriteLine("1/xsum: {0}", 1 / xsum)

            var Fk1 = aflint.t("0");
            for (i = 2 * j + 1; i >= 0; i -= 1)
                // Console.WriteLine("i: {0}, aCoeff(i): {1}, bCoeff(i): {2}, Fk1: {3}", i, aCoeff(i), bCoeff(i), Fk1)
                Fk1 = aCoeff[i] / (bCoeff[i] + Fk1);
            // Console.WriteLine("Fk1:    {0}", Fk1)

            var Fk0 = aflint.t("0");
            for (i = 2 * j + 0; i >= 0; i -= 1)
                // Console.WriteLine("i: {0}, aCoeff(i): {1}, bCoeff(i): {2}, Fk0: {3}", i, aCoeff(i), bCoeff(i), Fk0)
                Fk0 = aCoeff[i] / (bCoeff[i] + Fk0);
            // Console.WriteLine("Fk0:    {0}", Fk0)

            // Dim Fk = aflint.union(Fk1, Fk0)
            var Fk = Fk1 + Fk0;
            RightTail = k * Fk;
            LeftTail = 1 - RightTail;
            if (swapped)
            {
                var temp = LeftTail;
                LeftTail = RightTail;
                RightTail = temp;
                // aflint.swap(LeftTail, RightTail)
            }
        }


        public static void cdis2Arb(Arb n, Arb X, ref Arb LeftTail, ref Arb RightTail, ref Arb density)
        {
            gamma_inc_Arb(n / 2, X / 2, ref LeftTail, ref RightTail);
            density = DistFromBoost.Arb_ChiSquare_pdf(X, n, false);
        }







        public static void beta_inc_Arb_(Arb aa, Arb bb, Arb qq, Arb pp, ref Arb LeftTail, ref Arb RightTail, ref Arb density)
        {
            //bool swapped;
            int j;
            int i;
            Arb eps;
            Arb qp;
            Arb xsum, sum0, sum1, n;
            Arb a0;
            Arb a1;
            Arb a2;
            Arb an;
            Arb b0;
            Arb b1;
            Arb b2;
            Arb bn;
            //Arb x;
            //Arb limit;
            Arb MinRelError;
            Arb a = new Arb(), b = new Arb(), p = new Arb(), q = new Arb();
            a = aa + 0;
            b = bb + 0;
            q = qq + 0;
            p = pp + 0;
            // Console.WriteLine("a: {0}, b: {1}", a, b)
            // Console.WriteLine("q: {0}, p: {1}", q, p)
            MinRelError = 1 * aflint.epsilon();
            if (q <= aflint.t("0.0"))
            {
                LeftTail = aflint.t(0);
                RightTail = aflint.t(1);
                return;
            }
            if (p <= aflint.t("0.0"))
            {
                LeftTail = aflint.t(1);
                RightTail = aflint.t(0);
                return;
            }
            density = aflint.ibeta_derivative(a, b, q);

            // Dim BBB = aflint.floor(b)
            // Console.WriteLine("BBB: {0}", BBB)
            qp = q / p;
            b0 = aflint.t(1);
            b1 = a + 1;
            a0 = aflint.t(1);
            a1 = -(b - 1) * qp;
            n = a + b - 1;
            j = 0;
            bn = a + 1;
            sum0 = aflint.t(1);
            sum1 = aflint.t(1);
            int nord = 100000;
            var aCoeff = new ArbMat();
            var bCoeff = new ArbMat();
            aCoeff.Resize(nord + 1, 1);
            bCoeff.Resize(nord + 1, 1);

            aCoeff[0] = a0;
            aCoeff[1] = a1;
            bCoeff[0] = b0;
            bCoeff[1] = b1;
            // Console.WriteLine("2*j+i: {0}, an: {1}, bn: {2}", 0, a0, b0)
            // Console.WriteLine("2*j+i: {0}, an: {1}, bn: {2}", 1, a1, b1)

            a1 = a1 + b1;
            do
            {
                j = j + 1;
                for (i = 0; i <= 1; i++)
                {

                    if (i == 1)
                    {
                        an = -(a + j) * (b - j - 1) * qp;
                        bn = bn + 1;
                    }
                    else
                    {
                        an = j * (n + j) * qp;
                        bn = bn + 1;
                    }

                    aCoeff[2 * j + i] = an;
                    bCoeff[2 * j + i] = bn;
                    a2 = bn.Mid * a1.Mid + an.Mid * a0.Mid;
                    b2 = bn.Mid * b1.Mid + an.Mid * b0.Mid;
                    var b2_inv = 1 / b2.Mid;
                    a2 = a2 * b2_inv;
                    a1 = a1 * b2_inv;
                    b1 = b1 * b2_inv;
                    b2 = aflint.t(1);
                    a0 = a1;
                    a1 = a2;
                    b0 = b1;
                    b1 = b2;
                    a2.Rad = aflint.t(0);
                    // Console.WriteLine("2*j+{0}: {1}, an: {2}, bn: {3}", i, 2 * j + i, an, bn)
                    if (i == 0)
                        sum0 = a2;
                    else
                        sum1 = a2;
                }
                // xsum = aflint.union(sum0, sum1)
                xsum = (sum0 + sum1) / 2;
                eps = (sum0 - sum1) / xsum;
            }
            // Console.WriteLine("sum{0}: {1}, sum{2}: {3},  eps: {4}, xsum: {5}", 2 * j - 2, sum0, 2 * j - 1, sum1, eps, xsum)
            while (!(aflint.abs(eps) < MinRelError & j % 2 == 0));
            Console.WriteLine("j: {0,4}", j);
            // Console.WriteLine("1/xsum: {0}", 1 / xsum)

            var Fk1 = aflint.t("0");
            for (i = 2 * j + 1; i >= 0; i -= 1)
                // Console.WriteLine("i: {0}, aCoeff(i): {1}, bCoeff(i): {2}, Fk1: {3}", i, aCoeff(i), bCoeff(i), Fk1)
                Fk1 = aCoeff[i] / (bCoeff[i] + Fk1);
            // Console.WriteLine("Fk1:    {0}", Fk1)

            var Fk0 = aflint.t("0");
            for (i = 2 * j + 0; i >= 0; i -= 1)
                // Console.WriteLine("i: {0}, aCoeff(i): {1}, bCoeff(i): {2}, Fk0: {3}", i, aCoeff(i), bCoeff(i), Fk0)
                Fk0 = aCoeff[i] / (bCoeff[i] + Fk0);
            // Console.WriteLine("Fk0:    {0}", Fk0)

            // Dim Fk = aflint.union(Fk1, Fk0)
            var Fk = (Fk1 + Fk0) / 2;
            LeftTail = Fk * density * q / a;
            RightTail = 1 - LeftTail;

        }


        public static void beta_inc_Arb(Arb a, Arb b, Arb q, Arb p, ref Arb L, ref Arb R, ref Arb density)
        {
            bool NeedToConvert;
            var Temp = new Arb();
            NeedToConvert = !(b - 0.5d <= (a + b - 1) * p);
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
            beta_inc_Arb_(a, b, q, p, ref L, ref R, ref density);
            if (NeedToConvert)
            {
                Temp = L;
                L = R;
                R = Temp;
            }
        }


        public static void betadisArb(Arb a, Arb b, Arb q, Arb p, ref Arb L, ref Arb R, ref Arb density)
        {
            beta_inc_Arb(a, b, q, p, ref L, ref R, ref density);
        }


        public static Arb ibeta(Arb a, Arb b, Arb x)
        {
            Arb LeftTail = new Arb(), RightTail = new Arb(), density = new Arb(), y = new Arb();
            y = 1 - x;
            beta_inc_Arb(a, b, x, y, ref LeftTail, ref RightTail, ref density);
            return LeftTail;
        }



        public static Arb ibetac(Arb a, Arb b, Arb x)
        {
            Arb LeftTail = new Arb(), RightTail = new Arb(), density = new Arb(), y = new Arb();
            y = 1 - x;
            beta_inc_Arb(a, b, x, y, ref LeftTail, ref RightTail, ref density);
            return RightTail;
        }



        public static void Demo_arb_ibeta()
        {
            Arb a = new Arb(), b = new Arb(), x = new Arb();
            // x = aflint.t("0.52")
            // a = aflint.t("1124.1")
            // b = aflint.t("1114.1")

            a = aflint.t("50000000.1");
            b = aflint.t("50000000.1");
            // x = aflint.t("0.4991")
            x = aflint.t("0.5009");
            Console.WriteLine("a: {0}, b: {1}, x: {2}", a, b, x);

            // Dim result1 = aflint.ibeta_hyper(a, b, x)
            // Console.WriteLine("result1: {0}", result1)
            var result2 = aflint.ibeta(a, b, x);
            Console.WriteLine("result2: {0}", result2);
            var result3 = ibeta(a, b, x);
            Console.WriteLine("ibeta : {0}", result3);
            var result4 = ibetac(a, b, x);
            Console.WriteLine("ibetac: {0}", result4);

        }







        public static ArbMat GetS3(int n)
        {
            var S3 = new ArbMat();
            S3.Resize(3 * n + 3, n + 3);
            S3[0, 0] = aflint.t(1);
            for (int k = 3, loopTo = 3 * n; k <= loopTo; k++)
                S3[k, 1] = aflint.t(1);
            for (int j = 2, loopTo1 = n; j <= loopTo1; j++)
            {
                for (int k = 3 * j - 1, loopTo2 = 3 * n; k <= loopTo2; k++)
                    // S3(k + 1, j) = j * S3(k, j) + aflint.bin_ui_ui(k, 2) * S3(k - 2, j - 1)
                    S3[k + 1, j] = j * S3[k, j] + aflint.real_binomial(k, 2) * S3[k - 2, j - 1];
            }
            return S3;
        }

        public static ArbMat GetPK(int n, Arb x)
        {
            var pk = new ArbMat();
            pk.Resize(n + 3, 1);
            pk[0] = aflint.t(1);
            pk[1] = -x;
            for (int k = 1, loopTo = n; k <= loopTo; k++)
                pk[k + 1] = (pk[k - 1] - x * pk[k]) / (k + 1);
            return pk;
        }

        public static ArbMat GetQK(int n, Arb x)
        {
            var qk = new ArbMat();
            qk.Resize(n + 2, 1);
            qk[0] = aflint.t(0);
            qk[1] = aflint.t(-1);
            for (int k = 1, loopTo = n; k <= loopTo; k++)
                qk[k + 1] = (qk[k - 1] - x * qk[k]) / (k + 1);
            return qk;
        }

        public static Arb d0(Arb x)
        {
            var a1 = aflint.sqrt(0.5d * aflint.pi());
            var a2 = aflint.exp(0.5d * x * x);
            var a3 = aflint.erfc(x * aflint.sqrt(0.5d));
            var result = a1 * a2 * a3;
            return result;
        }


        public static void demoParis()
        {
            Arb z = new Arb(), a = new Arb(), x = new Arb(), f = new Arb(), d = new Arb(), z2 = new Arb(), result = new Arb();
            bool UseLeftTail = true;
            a = aflint.t(1000000);
            z = a - 10000;
            z2 = aflint.sqrt(z);
            x = (z - a) / z2;
            f = aflint.pow(z, a - 0.5d) * aflint.exp(-z) / aflint.gamma(a);
            if (x > 0)
                UseLeftTail = false;
            d = d0(aflint.abs(x));


            int n = 5;
            ArbMat ak = new ArbMat(), bk = new ArbMat();
            ak.Resize(n + 3, 1);
            bk.Resize(n + 3, 1);

            var S3 = GetS3(4 * n);
            var pk = GetPK(4 * n, x);
            var qk = GetQK(4 * n, x);
            for (int k = 0, loopTo = n; k <= loopTo; k++)
            {
                var sumak = aflint.t("0");
                var sumbk = aflint.t("0");
                // Console.WriteLine("k: {0}", k)
                int jsign = 1;
                for (int j = 0, loopTo1 = k; j <= loopTo1; j++)
                {
                    var s = S3[k + 2 * j, j];
                    var p = pk[k + 2 * j];
                    var q = qk[k + 2 * j];
                    sumak = sumak + jsign * s * p;
                    sumbk = sumbk + jsign * s * q;
                    // Console.WriteLine("j: {0,2}, k+2*j: {1,2}, jsign: {2}, s: {3}, p: {4}, q: {4}", k, k + 2 * j, jsign, s, p, q)
                    jsign = -jsign;
                }
                ak[k] = sumak;
                bk[k] = sumbk;
            }
            var aksum = aflint.t("0");
            var bksum = aflint.t("0");
            var zk2 = aflint.t("1");

            Console.WriteLine("a: {0}", a);
            Console.WriteLine("z: {0}", z);
            Console.WriteLine("x: {0}", x);
            Console.WriteLine("d: {0}", d);
            for (int k = 0, loopTo2 = n; k <= loopTo2; k++)
            {
                aksum = aksum + ak[k] / zk2;
                bksum = bksum + bk[k] / zk2;
                zk2 = zk2 * z2;
                Console.WriteLine("k: {0}, d*aksum: {1}, bksum: {2}", k, d * aksum, bksum);
            }
            if (UseLeftTail)
            {
                result = f * (d * aksum + bksum);
            }
            else
            {
                result = f * (d * aksum - bksum);
            }

            Console.WriteLine("result:   {0}", result);

            Arb LeftTail = new Arb(), RightTail = new Arb();
            gamma_inc_Arb(a, z, ref LeftTail, ref RightTail);
            Console.WriteLine("LeftTail: {0}, RightTail: {1}", LeftTail, RightTail);

        }






        // Nemes 2016, Incomplete beta function for large a and a/b > 20; for x less than the median
        public static void demoNemes()
        {
            Arb a = new Arb(), b = new Arb(), x = new Arb(), xi = new Arb(), sum = new Arb(), scale = new Arb(), result = new Arb();
            ArbPrec.SetDps(160);
            // a = aflint.t("5000.1")
            // b = aflint.t("4000.1")
            // x = aflint.t("0.4351")

            a = aflint.t("5000000.1");
            b = aflint.t("25000.1");
            x = aflint.t("0.99481");
            Console.WriteLine("a: {0}, b: {1}, x: {2}", a, b, x);

            ArbPrec.SetDps(60);
            a = a.Mid;
            b = b.Mid;
            x = x.Mid;
            xi = -aflint.log(x).Mid;
            scale = aflint.gamma(a + b) / aflint.gamma(a);
            Console.WriteLine("scale:  {0}", scale);
            Console.WriteLine("xi:  {0}", xi);
            Console.WriteLine("a*xi:  {0}", a * xi);
            int NN = 50;
            ArbMat Fk = new ArbMat(), dk = new ArbMat();
            Fk.Resize(NN + 3, 1);
            dk.Resize(NN + 3, 1);

            var Q = aflint.gamma_q(b, a * xi);
            Console.WriteLine("Q:  {0}", Q);
            Fk[0] = (aflint.pow(a, -b) * Q).Mid;
            Fk[1] = ((b - a * xi) * Fk[0] / a + aflint.pow(xi, b) * aflint.exp(-a * xi) / (a * aflint.gamma(b))).Mid;

            dk[0] = aflint.pow((1 - x) / xi, b - 1).Mid;
            dk[1] = ((x * xi + x - 1) * (b - 1) * dk[0] / ((1 - x) * xi)).Mid;

            ArbPrec.SetDps(160);
            var ra = (1 / a).Mid;

            for (int n = 1, loopTo = NN - 1; n <= loopTo; n++)
            {
                // Fk(n + 1) = ((n + b - a * xi) * Fk(n) + n * xi * Fk(n - 1)) / a
                Fk[n + 1] = (((n + b - a * xi) * Fk[n] + n * xi * Fk[n - 1]) * ra).Mid;
                Console.WriteLine("Fk(n + 1):  {0}", Fk[n + 1]);
            }

            Console.WriteLine("");
            ArbPrec.SetDps(160);
            for (int n = 0, loopTo1 = NN - 2; n <= loopTo1; n++)
            {
                var sum1 = aflint.t("0");
                var sum2 = aflint.t("0");
                var sum3 = aflint.t("0");
                for (int m = 0, loopTo2 = n; m <= loopTo2; m++)
                {
                    sum1 += ((m + 1) * (n - 2 * m + 1 + (m - n - 1) / (b - 1)) * dk[m + 1] * dk[n - m + 1]).Mid;
                    sum2 += ((m + 1) * (n - 2 * m - 2 - xi + (m - n) / (b - 1)) * dk[m + 1] * dk[n - m]).Mid;
                    sum3 += ((1 - m - b) * dk[m] * dk[n - m]).Mid;
                }
                dk[n + 2] = ((xi * sum1 + sum2 + sum3) / (xi * (n + 1) * (n + 2) * dk[0])).Mid;
                Console.WriteLine("dk(n + 2):  {0}", dk[n + 2]);
            }
            ArbPrec.SetDps(40);
            sum = aflint.t(0);
            var LastSummand = aflint.t(0);
            // For i = 0 To 30
            for (int i = 0; i <= 50; i++)
            {
                var summand = dk[i] * Fk[i] * scale;
                sum = sum + dk[i] * Fk[i];
                Console.WriteLine("i: {0}, sum: {1}, sc: {2}, dk(i): {3}, Fk(i): {4}", i, summand, sum * scale, dk[i], Fk[i]);
                if (i > 6 & aflint.abs(summand) > aflint.abs(LastSummand))
                {
                    Console.WriteLine("No Convergence!");
                    break;
                }
                LastSummand = summand;
            }
            result = sum * scale;
            Console.WriteLine("result:  {0}", result);

            var result3 = ibeta(a, b, x);
            Console.WriteLine("result3: {0}", result3);
            Console.WriteLine("result3: {0}", 1 - result3);

        }




















        // Sub betadisArb_old(ByVal a As Arb, ByVal b As Arb, ByVal Q As Arb, ByVal p As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb, ByRef density As Arb)
        // Dim fit As Boolean
        // Dim j As Integer, i As Integer
        // Dim sum(0 To 1) As Arb
        // Dim eps As Arb, qp As Arb, k As Arb
        // Dim xsum As Arb
        // Dim a0 As Arb, A1 As Arb, A2 As Arb, an As Arb
        // Dim b0 As Arb, b1 As Arb, b2 As Arb, bn As Arb
        // Dim X As Arb, limit As Arb, MinRelError As Arb
        // MinRelError = aflint.t("1E-30")
        // If (Q <= aflint.t("0.0")) Then
        // LeftTail = 0
        // RightTail = 1
        // density = 0
        // Exit Sub
        // End If
        // If (p <= aflint.t("0.0")) Then
        // LeftTail = 1
        // RightTail = 0
        // density = 0
        // Exit Sub
        // End If
        // k = aflint.lgamma(a + b) - aflint.lgamma(a) - aflint.lgamma(b)
        // 'k = aflint.l - Lnbeta(a, b)
        // k = k + (b - 1) * aflint.log(p) + (a - 1) * aflint.log(Q)
        // density = aflint.exp(k)
        // X = (b * Q) / (a * p)
        // limit = 4.5 - a
        // If limit < aflint.t("1") Then
        // limit = 1
        // End If
        // fit = (X < limit)
        // If Not fit Then
        // Call SwapTails(a, b)
        // Call SwapTails(p, Q)
        // End If
        // qp = Q / p
        // a0 = 1
        // A1 = a + 1 - (b - 1) * qp
        // b0 = 1
        // b1 = a + 1
        // j = 0
        // bn = a + 1
        // sum(0) = 1
        // sum(1) = 1
        // Do
        // j = j + 1
        // For i = 0 To 1
        // If i = 1 Then
        // an = -(a + j) * (b - j - 1) * qp
        // Else
        // an = j * (a + b - 1 + j) * qp
        // End If
        // bn = bn + 1
        // A2 = bn * A1 + an * a0
        // b2 = bn * b1 + an * b0
        // A2 = A2 / b2
        // A1 = A1 / b2
        // b1 = b1 / b2
        // b2 = 1
        // a0 = A1
        // A1 = A2
        // b0 = b1
        // b1 = b2
        // A2.rad = 0

        // sum(i) = A2
        // Next i
        // 'xsum = (sum(0) + sum(1)) * 0.5
        // xsum = aflint.union(sum(0), sum(1))
        // eps = (sum(0) - sum(1)) / xsum
        // Console.WriteLine("j: {0}, sum(0): {1}, sum(1): {2},  eps: {3}, xsum: {4}", j, sum(0), sum(1), eps, xsum)
        // Loop Until (aflint.abs(eps) < MinRelError)
        // Console.WriteLine("j: {0}", j)
        // RightTail = density * Q / (a * xsum)
        // LeftTail = 1 - RightTail
        // If fit Then
        // Call SwapTails(LeftTail, RightTail)
        // End If
        // End Sub




        public static void SwapTails(Arb x, Arb y)
        {
            var temp = x;
            y = x;
            x = temp;
            // aflint.swap(x, y)
        }

        public static Arb FdisArb(Arb m, Arb n, Arb a)
        {
            Arb X;
            Arb y;
            Arb p;
            Arb Q;
            var density = default(Arb);
            var LeftTail = default(Arb);
            var RightTail = default(Arb);
            if (a <= 0)
            {
                return aflint.t(0);
                //return default;
            }
            X = m * a / (m * a + n);
            y = n / (m * a + n);
            p = m / 2;
            Q = n / 2;
            betadisArb(p, Q, X, y, ref LeftTail, ref RightTail, ref density);
            return RightTail;
        }

        // Sub Fdis_aArb(ByVal m As Arb, ByVal n As Arb, ByVal a As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb)
        // Dim X As Arb, y As Arb, p As Arb, Q As Arb
        // Dim density As Arb
        // If a <= 0 Then
        // LeftTail = 0
        // RightTail = 1
        // Exit Sub
        // End If
        // X = m * a / (m * a + n)
        // y = n / (m * a + n)
        // p = m / 2
        // Q = n / 2
        // Call betadis(p, Q, X, y, LeftTail, RightTail, density)
        // End Sub



        // Function tdisArb(ByVal n As Arb, ByVal t As Arb, ByRef LeftTail As Arb, ByRef RightTail As Arb) As Arb
        // Dim temp As Arb
        // If t = 0 Then
        // LeftTail = 0.5
        // RightTail = 0.5
        // Return 0.5
        // Exit Function
        // End If
        // Call Fdis_a(1, n, t * t, LeftTail, RightTail)
        // RightTail = RightTail / 2
        // LeftTail = 1 - RightTail
        // 'Debug.Print LeftTail, RightTail
        // If t < 0 Then
        // temp = LeftTail
        // LeftTail = RightTail
        // RightTail = temp
        // End If
        // Return LeftTail
        // End Function





        public static Arb tdensArb(Arb n, Arb X)
        {
            Arb C;
            Arb h;
            C = 1 + X * X / n;
            h = aflint.exp(aflint.lgamma((n + 1) / 2) - aflint.lgamma(n / 2)) / aflint.sqrt(aflint.pi()) / aflint.sqrt(n);
            // Return h * C ^ (-(n / 2 + 1 / 2))
            return h * aflint.pow(C, -(n / 2 + 1d / 2d));
        }



        public static Arb cdisOwenArb(long n, Arb X)
        {
            Arb C;
            Arb F;
            long k;
            long i;
            C = -aflint.exp(-X / 2);
            F = aflint.t(1);
            k = n % 2L;
            if (k != 0L)
            {
                C = C * aflint.sqrt(2 * X / aflint.pi());    // C=ndens(x)
                F = 1 - 2 * aflint.ndis(-aflint.sqrt(X));
            }
            k = k + 2L;
            var loopTo = n;
            for (i = k; i <= loopTo; i += 2L)
            {
                F = F + C;
                C = C * X / i;
            }
            return F;
        }


        public static Arb tdisOwen(Arb X, long n)
        {
            Arb a;
            Arb b;
            Arb C;
            Arb F;
            long k;
            long i;
            a = X / aflint.sqrt(n);
            b = 1 + a * a;
            k = n % 2L;
            if (k != 0L)
            {
                C = a / (b * aflint.pi());
                F = 0.5d + aflint.atan(a) / aflint.pi();
            }
            else
            {
                C = a / (2 * aflint.sqrt(b));
                F = aflint.t(0.5d);
            }
            k = k + 2L;
            var loopTo = n;
            for (i = k; i <= loopTo; i += 2L)
            {
                F = F + C;
                C = C * (1 - aflint.t("1") / i) / b;
            }
            return F;
        }


        public static Arb FdisOwenArb(long m, long n, Arb X)
        {
            Arb U;
            Arb sum;
            Arb a;
            Arb z;
            Arb result;
            long i;
            long k;
            k = m % 2L;
            if (k == 0L)
            {
                z = n / (n + m * X);
                // result = z ^ (n / 2)
                result = aflint.pow(z, n / 2d);
                if (m > 2L)
                {
                    U = 1 - z;
                    sum = aflint.t(1);
                    a = aflint.t(1);
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
                z = aflint.sqrt(m * X);
                result = 2 * tdisOwen(-z, n);
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
                    result = result + 2 * sum * tdensArb(aflint.t(n), z);
                }
            }
            return result;
        }


















        public static Arb AdjustSignArb(bool UseLeftTail, Arb x)
        {
            if (UseLeftTail)
                return x;
            else
                return -x;
        }


        public static void BrentArb(bool UseLeftTail, bool IsExact, bool IsGLM, int proc, ref Arb a, ref Arb b, Arb fa, Arb fb, Arb eps, Arb LogTarget, Arb Df1, Arb Df2, Arb t1, Arb omega)
        {
            Console.WriteLine("In BrentArb");
            ArbPrec.SetDps(60);
            var c = new Arb();
            var d = new Arb();
            var e = new Arb();
            var tol = new Arb(); // , eps As New Arb
            var s = new Arb();
            var p = new Arb();
            var q = new Arb();
            var r = new Arb();
            var xs = new Arb();
            var fc = new Arb();
            var m = new Arb();
            long iter;
            long maxiter;
            var LogRefTail = new Arb();
            iter = 0L;
            maxiter = 1000L;
            if (fa * fb > 0)
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
                if (fb * fc > 0)
                {
                    c = a;
                    fc = fa;
                    d = b - a;
                    e = d;
                }
                if (aflint.abs(fc) < aflint.abs(fb))
                {
                    a = b;
                    b = c;
                    c = a;
                    fa = fb;
                    fb = fc;
                    fc = fa;
                }
                tol = 2 * eps * aflint.abs(b);
                m = (c - b) / 2;  // Tolerance
                if (aflint.abs(m) > tol & aflint.abs(fb) > 0)
                {
                    if (aflint.abs(e) < tol | aflint.abs(fa) <= aflint.abs(fb))
                    {
                        d = m;
                        e = m;
                    }
                    else
                    {
                        s = fb / fa;
                        if (a == c)
                        {
                            p = 2 * m * s;
                            q = 1 - s;
                        }
                        else
                        {
                            q = fa / fc;
                            r = fb / fc;
                            p = s * (2 * m * q * (q - r) - (b - a) * (r - 1));
                            q = (q - 1) * (r - 1) * (s - 1);
                        }
                        if (p > 0)
                            q = -q;
                        else
                            p = -p;
                        s = e;
                        e = d;
                        if (2 * p < 3 * m * q - aflint.abs(tol * q) & p < aflint.abs(s * q / 2))
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
                    if (aflint.abs(d) > tol)
                    {
                        b = b + d;
                    }
                    else if (m > 0)
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
                    case mp_ndisx:
                        {
                            LogRefTail = DistFromBoost.Arb_Normal_CDF(b, aflint.t(0), aflint.t(1), UseLeftTail, true);
                            break;
                        }
                    case mp_cdisx:
                        {
                            LogRefTail = DistFromBoost.Arb_ChiSquare_CDF(b, Df1, UseLeftTail, true);
                            break;
                        }
                    case mp_fdisx:
                        {
                            LogRefTail = DistFromBoost.Arb_F_CDF(b, Df1, Df2, UseLeftTail, true);
                            break;
                        }

                    default:
                        {
                            LogRefTail = aflint.nan();
                            break;
                        }
                }
                fb = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail);
                Console.WriteLine("iter: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}, aflint.Abs(m): {5}", iter, a, b, fa, fb, aflint.abs(m));
            }

        Finish:
            ;

            // Console.WriteLine("final: {0}, a: {1}, b: {2}, fa: {3}, fb: {4}", iter, a, b, fa, fb)
            // xs = aflint.union(a, b)
            xs = (a + b) / 2;
            // Console.WriteLine("xs: {0}", xs)
            b = xs;
            ArbPrec.SetDps(40);
        }




        public static double Wichura(double Q, double r0)
        {
            Console.WriteLine("In Wichura, Q:{0}, r0:{1}", Q, r0);
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

            if (Math.Abs(Q) <= split1)
            {
                // Console.WriteLine("in abs(Q) <= split1")
                r = const1 - Q * Q;
                ppnd16 = Q * (((((((A7 * r + a6) * r + A5) * r + a4) * r + a3) * r + A2) * r + A1) * r + a0) / (((((((B7 * r + B6) * r + B5) * r + b4) * r + B3) * r + b2) * r + b1) * r + 1d);
                return ppnd16;
            }
            else
            {
                r = r0;
                if (r <= split2)
                {
                    // Console.WriteLine("in r <= split2")
                    r = r - const2;
                    ppnd16 = (((((((C7 * r + c6) * r + c5) * r + c4) * r + c3) * r + c2) * r + C1) * r + C0) / (((((((D7 * r + D6) * r + D5) * r + D4) * r + D3) * r + d2) * r + d1) * r + 1d);
                }
                else
                {
                    // Console.WriteLine("in r > split2")
                    r = r - split2;
                    ppnd16 = (((((((E7 * r + E6) * r + E5) * r + E4) * r + E3) * r + e2) * r + e1) * r + E0) / (((((((f7 * r + f6) * r + f5) * r + f4) * r + f3) * r + f2) * r + f1) * r + 1d);
                }
                if (Q < 0d)
                    ppnd16 = -ppnd16;
                return ppnd16;
            }
        }



        public static Arb ndisxArb_approx(Arb LeftTailTarget, Arb RightTailTarget)
        {
            Arb RefTailTarget = new Arb(), result = new Arb();
            bool swapped = false;
            if (LeftTailTarget < RightTailTarget)
            {
                RefTailTarget = LeftTailTarget;
                swapped = true;
            }
            else
            {
                RefTailTarget = RightTailTarget;
            }
            if (RefTailTarget < aflint.t("1.0E-3084"))
            {
                // this solves (approximately) for x the equation  Q(x) = (1/x) * ndens(x)
                var logRefTail = aflint.log(RefTailTarget);
                var c1 = logRefTail + 0.918938533204673d;  // + ln(1/sqrt(2*pi))
                var v1 = aflint.t("4.78");  // 4.78 = log(ndisx(p)), where p = 1.0E-3084 is the crossover point from the Wichura approximation
                var d1 = v1 + c1;
                d1 = -2 * d1;
                d1 = aflint.sqrt(d1);
                v1 = aflint.log(d1);
                d1 = v1 + c1;
                d1 = -2 * d1;
                d1 = aflint.sqrt(d1);
                result = d1;
            }
            else
            {
                Arb Q = new Arb(), r0 = new Arb();
                Q = 0.5d - RefTailTarget;
                if (aflint.abs(Q) > 0.425d)
                {
                    r0 = aflint.sqrt(-aflint.log(RefTailTarget));
                }
                Console.WriteLine("Q:{0}", Q);
                double Q_ = Q.AsDouble();
                Console.WriteLine("Q.AsDouble(): {0}", Q_);
                result = aflint.t(Wichura(Q.AsDouble(), r0.AsDouble()));
                Console.WriteLine("result: {0}", result);
            }
            if (swapped)
                result = -result;
            return result;
        }


















        public static Arb NdisArb(Arb x)
        {
            return aflint.ndis(x);
        }


        public static Arb NdensArb(Arb x)
        {
            return aflint.ndens(x);
        }


        public static Arb ndisxArb(Arb LeftTail, Arb RightTail)
        {
            Console.WriteLine("L:{0}, R:{1}", LeftTail, RightTail);
            Arb x1 = new Arb(), LogTarget = new Arb(), LogRefTail = new Arb(), Factor = new Arb();
            bool UseLeftTail = true;
            if (LeftTail > aflint.t("0.5"))
                UseLeftTail = false;
            // Dim eps = aflint.t("1E-40")
            var eps = aflint.epsilon();
            if (UseLeftTail)
                LogTarget = aflint.log(LeftTail);
            else
                LogTarget = aflint.log(RightTail);

            x1 = ndisxArb_approx(LeftTail, RightTail);
            Console.WriteLine("x1: {0}", x1);
            LogRefTail = DistFromBoost.Arb_Normal_CDF(x1, aflint.t(0), aflint.t(1), UseLeftTail, true);
            var L1 = x1;
            var L2 = L1;
            double LSign = 0.0d;
            var F_L1 = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail);

            var F_L2 = F_L1;
            if (F_L1 > 0)
                LSign = +1;
            else
                LSign = -1;
            if (!UseLeftTail)
            {
                Factor = aflint.t("0.9999999");
                if (F_L1 > 0)
                    Factor = aflint.t("1.0000001");
            }
            else
            {
                Factor = aflint.t("1.0000001");
                if (F_L1 > 0)
                    Factor = aflint.t("0.9999999");
            }
            Console.WriteLine("L1: {0}, RefTail: {1}, LogRefTail: {2}, F_L1: {3}", L1, aflint.exp(LogRefTail), LogRefTail, F_L1);

            int count = 1;
            do
            {
                count = count + 1;
                L1 = L2;
                F_L1 = F_L2;
                L2 = L1 * Factor;
                LogRefTail = DistFromBoost.Arb_Normal_CDF(L2, aflint.t(0), aflint.t(1), UseLeftTail, true);
                F_L2 = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail);
                Console.WriteLine("L2: {0}, RefTail: {1}, LogRefTail: {2}, F_L2: {3}", L2, aflint.exp(LogRefTail), LogRefTail, F_L2);
                Factor = Factor * Factor;
            }
            while (F_L2 * LSign >= 0);
            // Loop Until count > 10


            BrentArb(UseLeftTail, true, true, mp_ndisx, ref L1, ref L2, F_L1, F_L2, eps, LogTarget, aflint.t(0), aflint.t(0), aflint.t(0), aflint.t(0));
            return L2;
        }





        public static Arb cdisx_approxArb(Arb LeftTail, Arb RightTail, Arb n)
        {
            var t = new Arb();
            var d = new Arb();
            var k = new Arb();
            var a = new Arb();
            var result = new Arb();
            bool UseLambert;
            var h = new Arb();
            var L = new Arb();
            var mean = new Arb();
            var stdev = new Arb();
            var u = new Arb();
            var m = new Arb();
            var m2 = new Arb();
            var m3 = new Arb();
            var g = new Arb();
            var z = new Arb();
            if (n < 1)
                n = aflint.t(1);
            UseLambert = true;
            a = 1 / (0.5d * (n + 2) - 1);
            k = aflint.lgamma(0.5d * (n + 2));
            d = a * (aflint.log(LeftTail) + k);
            t = -a * aflint.exp(LeftTail + d);
            // Console.WriteLine("t :{0}", t)
            if (aflint.abs(t) > aflint.t("0.1"))
                UseLambert = false;
            if (UseLambert)
            {
                // Console.WriteLine("UseLambert")
                result = -(((((125 * t - 64) * t + 36) * t - 24) * t + 24) * t) / (12 * a);  // Result = -2 * LambertW(t) / a
            }
            else
            {
                // Console.WriteLine("UseCanal")
                z = ndisxArb_approx(LeftTail, RightTail);
                m = 1 / n;
                m2 = m * m;
                m3 = m2 * m;
                mean = (14580 - 1944 * m - 189 * m2 + 200 * m3) / 17496;
                stdev = aflint.sqrt(aflint.abs(648 * m + 72 * m2 - 37 * m3)) / 108;
                g = aflint.sqrt(0.5d * m3) / 162;
                z = z - g + z * g * (z - (2 * z * z - 5) * g);
                L = 6 * (z * stdev + mean);
                h = aflint.cbrt(2 * (L + aflint.sqrt(13 + L * (L - 5))) - 5);
                u = 0.5d + 0.5d * h - 1.5d / h;
                u = u * u * u;
                u = u * u;
                // Console.WriteLine("u :{0}", u)
                result = n * u;
            }
            // Console.WriteLine("chisquare quantile: {0} ", result)
            return aflint.abs(result);
        }



        public static Arb cdisxArb(Arb LeftTail, Arb RightTail, Arb Df1)
        {
            Arb x1 = new Arb(), LogTarget = new Arb(), LogRefTail = new Arb();
            bool UseLeftTail = true;
            if (LeftTail > aflint.t("0.5"))
                UseLeftTail = false;
            var eps = aflint.t("1E-40");
            if (UseLeftTail)
                LogTarget = aflint.log(LeftTail);
            else
                LogTarget = aflint.log(RightTail);

            x1 = cdisx_approxArb(LeftTail, RightTail, Df1);

            LogRefTail = DistFromBoost.Arb_ChiSquare_CDF(x1, Df1, UseLeftTail, true);
            var L1 = x1;
            var L2 = L1;
            double LSign = 0.0d;
            var F_L1 = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail);

            var F_L2 = F_L1;
            if (F_L1 > 0)
                LSign = +1;
            else
                LSign = -1;
            double Factor = 0.9d;
            if (F_L1 > 0)
                Factor = 1.1d;
            Console.WriteLine("L1: {0}, RefTail: {1}, LogRefTail: {2}, F_L1: {3}", L1, aflint.exp(LogRefTail), LogRefTail, F_L1);

            do
            {
                L1 = L2;
                F_L1 = F_L2;
                L2 = L1 * Factor;
                LogRefTail = DistFromBoost.Arb_ChiSquare_CDF(L2, Df1, UseLeftTail, true);
                F_L2 = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail);
                Console.WriteLine("L2: {0}, RefTail: {1}, LogRefTail: {2}, F_L2: {3}", L2, aflint.exp(LogRefTail), LogRefTail, F_L2);
                Factor = Factor * Factor;
            }
            while (F_L2 * LSign >= 0);

            BrentArb(UseLeftTail, true, true, mp_cdisx, ref L1, ref L2, F_L1, F_L2, eps, LogTarget, Df1, aflint.t(0), aflint.t(0), aflint.t(0));
            Console.WriteLine("L2 after Brent: {0}", L2);
            return L2;
        }




        public static Arb gamma_p_inv_2Arb(Arb a, Arb p)
        {
            return cdisxArb(p, 1 - p, 2 * a) / 2;
        }


        public static Arb gamma_q_inv_2Arb(Arb a, Arb q)
        {
            return cdisxArb(1 - q, q, 2 * a) / 2;
        }





        public static Arb fdisx_approx_2Arb(Arb l, Arb r, Arb m, Arb n)
        {
            Arb z = new Arb(), q = new Arb(), d = new Arb(), u = new Arb(), v = new Arb(), h = new Arb();
            q = n - 1 + m / 2;
            d = (m * m - 4) / (24 * q * q);
            z = cdisx_approxArb(l, r, m);
            z = z * (1 + d) + z * z * (d / (m + 2));
            h = -z / q;
            u = aflint.exp(h);
            v = -aflint.expm1(h);
            return v / u * (n / m);
        }


        public static Arb fdisx_approx_1Arb(Arb l, Arb r, Arb m, Arb n)
        {
            Arb u = new Arb(), b = new Arb();
            u = ndisxArb_approx(l, r);
            if (u < 0)
                b = aflint.t(0.8d);
            else
                b = aflint.t(0.4d);
            if (m / n < 1 - b * u / 4.7d & u <= n - 1)
            {
                return fdisx_approx_2Arb(l, r, m, n);
            }
            else
            {
                return 1 / fdisx_approx_2Arb(r, l, n, m);
            }
        }


        public static Arb fdisx_approxArb(Arb L, Arb r, Arb m, Arb n)
        {
            if (m <= n)
            {
                return fdisx_approx_1Arb(L, r, m, n);
            }
            else
            {
                return 1 / fdisx_approx_1Arb(r, L, n, m);
            }
        }







        public static Arb fdisxArb(Arb LeftTail, Arb RightTail, Arb Df1, Arb Df2)
        {
            Arb x1 = new Arb(), LogTarget = new Arb(), LogRefTail = new Arb();
            bool UseLeftTail = true;
            var eps = aflint.t("1E-40");
            if (LeftTail > aflint.t("0.5"))
                UseLeftTail = false;
            if (UseLeftTail)
                LogTarget = aflint.log(LeftTail);
            else
                LogTarget = aflint.log(RightTail);

            x1 = fdisx_approxArb(LeftTail, RightTail, Df1, Df2);

            LogRefTail = DistFromBoost.Arb_F_CDF(x1, Df1, Df2, UseLeftTail, true);
            var L1 = x1;
            var L2 = L1;
            double LSign = 0.0d;
            var F_L1 = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail);

            var F_L2 = F_L1;
            if (F_L1 > 0)
                LSign = +1;
            else
                LSign = -1;
            double Factor = 0.9d;
            if (F_L1 > 0)
                Factor = 1.1d;
            // Console.WriteLine("L1: {0}, RefTail: {1}, LogRefTail: {2}, F_L1: {3}", L1, aflint.exp(LogRefTail), LogRefTail, F_L1)

            do
            {
                L1 = L2;
                F_L1 = F_L2;
                L2 = L1 * Factor;
                LogRefTail = DistFromBoost.Arb_F_CDF(L2, Df1, Df2, UseLeftTail, true);
                F_L2 = AdjustSignArb(UseLeftTail, LogTarget - LogRefTail);
                // Console.WriteLine("L2: {0}, RefTail: {1}, LogRefTail: {2}, F_L2: {3}", L2, aflint.exp(LogRefTail), LogRefTail, F_L2)
                Factor = Factor * Factor;
            }
            while (F_L2 * LSign >= 0);

            BrentArb(UseLeftTail, true, true, mp_fdisx, ref L1, ref L2, F_L1, F_L2, eps, LogTarget, Df1, Df2, aflint.t(0), aflint.t(0));
            return L2;
        }


        public static void betadisxArb(Arb LeftTail, Arb RightTail, Arb a, Arb b, ref Arb x, ref Arb y)
        {
            var w = aflint.abs(fdisxArb(LeftTail, RightTail, 2 * a, 2 * b));
            x = a * w / (a * w + b);
            y = b / (a * w + b);
        }


        public static Arb ibeta_inv_2Arb(Arb a, Arb b, Arb p)
        {
            Arb x = default(Arb), y = default(Arb);
            betadisxArb(p, 1 - p, a, b, ref x, ref y);
            return x;
        }


        public static Arb ibetac_inv_2Arb(Arb a, Arb b, Arb q)
        {
            Arb x = default(Arb), y = default(Arb);
            betadisxArb(1 - q, q, a, b, ref x, ref y);
            return x;
        }



        public static Arb TdisxArb(Arb LeftTail, Arb RightTail, Arb n)
        {
            var t = new Arb();
            bool Swapped;
            if (LeftTail == aflint.t("0.5"))
                return aflint.t(0);
            Swapped = false;
            if (LeftTail < aflint.t("0.5"))
            {
                t = LeftTail;
                LeftTail = RightTail;
                RightTail = t;
                Swapped = true;
            }
            RightTail = 2 * RightTail;
            LeftTail = 1 - RightTail;
            t = aflint.sqrt(fdisxArb(LeftTail, RightTail, aflint.t(1), n));
            if (Swapped)
                t = -t;
            return t;
        }


        public static void demoNdisxArb()
        {
            ArbPrec.SetDps(60);
            Console.WriteLine(" Hello demoNdisxArb ");
            Arb LeftTail = new Arb(), RightTail = new Arb(), R0 = new Arb(), R1 = new Arb(), Check = new Arb(), Exponent = new Arb();
            RightTail = aflint.t("1.0E-1");
            Exponent = aflint.t("1.0E+0");
            // RightTail = RightTail ^ Exponent
            RightTail = aflint.pow(RightTail, Exponent);
            LeftTail = 1 - RightTail;

            Console.WriteLine(" Before swap L:{0}, R:{1}", LeftTail, RightTail);
            SwapTails(LeftTail, RightTail);
            Console.WriteLine(" After swap L:{0}, R:{1}", LeftTail, RightTail);


            R0 = ndisxArb(LeftTail, RightTail);
            Console.WriteLine("R0: {0} ", R0);
            // Console.WriteLine("R1: {0} ", Approx)
            // Dim R5 = ndisxArb_approx(LeftTail, RightTail)

            Check = NdisArb(R0);
            Console.WriteLine("Check: {0}", Check);
            Check = NdisArb(-R0);
            Console.WriteLine("Check: {0}", Check);

            Check = NdensArb(R0);
            Console.WriteLine("Check: {0}", Check);


        }


        public static void demoCdisxArb()
        {
            ArbPrec.SetDps(50);
            Arb m = new Arb(), LeftTail = new Arb(), RightTail = new Arb(), R0 = new Arb(), R1 = new Arb(), Check = new Arb(), Exponent = new Arb();
            m = aflint.t(500);
            Console.WriteLine("m: {0}", m);
            RightTail = aflint.t("1.0E-5");
            Exponent = aflint.t("1.0E+0");
            RightTail = aflint.pow(RightTail, Exponent);
            LeftTail = 1 - RightTail;

            R1 = cdisxArb(LeftTail, RightTail, m);
            Console.WriteLine("R1: {0} ", R1);
            Check = DistFromBoost.Arb_ChiSquare_CDF(R1, m, true, false);
            Console.WriteLine("CheckL1: {0}", Check);
            Check = DistFromBoost.Arb_ChiSquare_CDF(R1, m, false, false);
            Console.WriteLine("CheckR1: {0}", Check);
        }


        public static void demoFdisxArb()
        {
            ArbPrec.SetDps(50);
            Arb m = new Arb(), n = new Arb(), LeftTail = new Arb(), RightTail = new Arb(), R1 = new Arb(), Check = new Arb();
            m = aflint.t(6);
            n = aflint.t(6000);
            RightTail = aflint.t("5.0E-5");
            LeftTail = 1 - RightTail;

            SwapTails(LeftTail, RightTail);

            Console.WriteLine("");

            R1 = fdisxArb(LeftTail, RightTail, m, n);
            Console.WriteLine("R1:  {0} ", R1);

            Check = DistFromBoost.Arb_F_CDF(R1, m, n, true, false);
            Console.WriteLine("Check: {0}", Check);
            Check = DistFromBoost.Arb_F_CDF(R1, m, n, false, false);
            Console.WriteLine("Check: {0}", Check);

            // Check = DistFromBoost.Arb_F_pdf(R1, m, n, False)
            // Console.WriteLine("PDF2: {0}", Check)
        }


        public static void demoTdisxArb()
        {
            ArbPrec.SetDps(50);
            Arb m = new Arb(), LeftTail = new Arb(), RightTail = new Arb(), R1 = new Arb(), Check = new Arb();
            m = aflint.t(1000);
            RightTail = aflint.t("1.0E-2");
            LeftTail = 1 - RightTail;

            // aflint.swap(LeftTail, RightTail)

            Console.WriteLine("");
            R1 = TdisxArb(LeftTail, RightTail, m);
            Console.WriteLine("R1: {0} ", R1);
            Check = DistFromBoost.Arb_T_CDF(R1, m, true, false);
            Console.WriteLine("Check: {0}", Check);
            Check = DistFromBoost.Arb_T_CDF(R1, m, false, false);
            Console.WriteLine("Check: {0}", Check);
        }


        public static void demoBetadisxArb()
        {
            ArbPrec.SetDps(60);
            Arb x = new Arb(), y = new Arb(), a = new Arb(), b = new Arb(), LeftTail = new Arb(), RightTail = new Arb(), R1 = new Arb(), R2 = new Arb();
            a = aflint.t(2);
            b = aflint.t(6);
            LeftTail = aflint.t("0.01");
            RightTail = 1 - LeftTail;

            betadisxArb(LeftTail, RightTail, a, b, ref x, ref y);

            Console.WriteLine("x: {0} ", x);
            Console.WriteLine("");
            Console.WriteLine("y: {0} ", y);

        }


        public static void demo_ibeta_invArb()
        {
            Arb a = new Arb(), b = new Arb(), p = new Arb(), R1 = new Arb();
            a = aflint.t(1.5d);
            b = aflint.t(6);
            p = aflint.t(0.99d);
            var R0 = aflint.real_ibeta_inv(a, b, p);
            Console.WriteLine("R0:  {0}", R0);

            R1 = ibeta_inv_2Arb(a, b, p);
            Console.WriteLine("R1: {0}", R1);
        }


        public static void demo_ibetac_invArb()
        {
            Arb a = new Arb(), b = new Arb(), q = new Arb(), R1 = new Arb();
            a = aflint.t(1.5d);
            b = aflint.t(6);
            q = aflint.t(0.99d);
            var R0 = aflint.real_ibetac_inv(a, b, q);
            Console.WriteLine("R0:  {0}", R0);

            R1 = ibetac_inv_2Arb(a, b, q);
            Console.WriteLine("R1: {0}", R1);
        }


        public static void demoGamma_p_invArb()
        {
            Arb a = new Arb(), p = new Arb(), R1 = new Arb();
            a = aflint.t(1.5d);
            p = aflint.t(0.99d);
            var R0 = aflint.real_gamma_p_inv(a, p);
            Console.WriteLine("R0:  {0}", R0);

            R1 = gamma_p_inv_2Arb(a, p);
            Console.WriteLine("R1: {0}", R1);
        }


        public static void demoGamma_q_invArb()
        {
            Arb a = new Arb(), q = new Arb(), R1 = new Arb();
            a = aflint.t(1.5d);
            q = aflint.t(0.99d);
            var R0 = aflint.real_gamma_q_inv(a, q);
            Console.WriteLine("R0:  {0}", R0);

            R1 = gamma_q_inv_2Arb(a, q);
            Console.WriteLine("R1: {0}", R1);
        }



    }
}