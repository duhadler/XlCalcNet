using System;

namespace Distributions
{


    static class PermFriedman
    {



        public static void DemoFriedman()
        {
            int k = 3;  // number of groups
            int n = 10; // Number of blocks
            int Quade = 2;  // 1=friedman 2=quade
            int Mode = 1;  // 1=anova 2=page
            int Mode2 = 1; // 1=SAQ  2=Range  3=Dunnett-1 4=Dunnett-2  5=Youden  6=Quit
            var Result = Friedman(k, n, Quade, Mode, Mode2);
        }

        public static object Friedman(int k, int n, int Quade, int Mode, int Mode2)
        {

            // k : number of groups
            // N: Number of blocks
            // quade: 1=friedman 2=quade
            // ties:  'J'
            // mode : 1=anova 2=page
            // mode2: 1=SAQ  2=Range  3=Dunnett-1 4=Dunnett-2  5=Youden  6=Quit
            const int vlimit = 1000000;
            int ve = 0;
            var permnew = 0;
            int sumcount = 0;
            int vref = 0;
            int dloop = 0;
            bool first;

            var x = new int[n + 1 + 1, k + 1 + 1];
            var zfak = new double[1000001];
            var vfak = new double[1000001];
            var zv = new int[k + 1 + 1, 1000002];
            var v = new int[k + 1 + 1, 1000002];
            var w = new int[k + 1 + 1];
            var zz = new int[k + 1 + 1];
            var b = new int[k + 1 + 1];
            var y = new int[k + 1 + 1];
            var z = new int[k + 1 + 1];
            var diff = new int[2 * (k + 1) + 1 + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    if (Quade == 2)
                        x[i, j] = 2 * j * i;
                    else
                        x[i, j] = 2 * j;
                    Console.Write("{0}, ", x[i, j]);
                }
                Console.WriteLine();
            }
            int asymend = 0;


            int sdiv2 = k / 2;
            int sum3 = k + 1;
            if (Mode >= 2)
                sumcount = 1;
            else
                sumcount = k - 1;
            int fit = 1;
            int h = sumcount;
            int permcount = 1;
            int Last = 0;
            double variance = 0d;
            for (int kk = 1; kk <= k; kk++)
            {
                zv[kk, 1] = 0;
                y[kk] = 0;
                permcount = permcount * kk;
            }

            var perm = new int[k + 1 + 1, permcount + 1 + 1];
            var pfak = new int[permcount + 1 + 1];

            int vlength = 1;
            int rsum = 0;
            zfak[1] = 1.0E-300d; // (*permcount;*)
            vfak[1] = 0d;

            for (int it = 1; it <= n; it++)
            {
                int vnewend = 1;
                int lastrsum = rsum;
                first = true;
                bool notsame = false;
                int mean = 0;
                for (int kk = 1; kk <= k; kk++)
                    mean = mean + fit * x[it, kk];
                mean = mean / k;
                for (int kk = 1; kk <= k; kk++)
                {
                    int yk = fit * x[it, kk] - mean;
                    rsum = rsum + yk;
                    variance = variance + yk * yk;
                    if (yk != y[kk])
                        notsame = true;
                    y[kk] = yk;
                }

                // (************************************
                // *  permutations of the ith block  *
                // ************************************)

                if (notsame)
                {
                    permnew = 0;
                    for (int j = permcount; j >= 1; j -= 1)
                    {
                        z[1] = 0;
                        int nr = j;
                        int pn = permcount;
                        for (int kk = 1; kk <= k; kk++)
                            b[kk] = kk;
                        for (int kk = k; kk >= 1; kk -= 1)
                        {
                            pn = pn / kk;
                            int s2 = (nr - 1) / pn;
                            nr = nr - pn * s2;
                            s2 = s2 + 1;
                            if (Mode == 1)
                                z[kk] = y[b[s2]];
                            if (Mode == 2)
                                z[1] = z[1] - (2 * kk - sum3) * y[b[s2]];
                            for (int k1 = s2; k1 <= kk - 1; k1++)
                                b[k1] = b[k1 + 1];
                        }
                        int i = 1;
                        bool notfound = true;
                        while (notfound & i <= permnew)
                        {
                            int kk = 1;
                            while (perm[kk, i] == z[kk] & kk < k)
                                kk = kk + 1;
                            if (kk == k)
                                notfound = false;
                            else
                                i = i + 1;
                        }
                        if (notfound)
                        {
                            permnew = permnew + 1;
                            for (int kk = 1; kk <= k; kk++)
                                perm[kk, i] = z[kk];
                            pfak[i] = 1;
                        }
                        else
                        {
                            pfak[i] = pfak[i] + 1;
                        }
                    }
                } // (*if notsame*)

                // (**************************************
                // *   Calculate rank sums        *
                // **************************************)

                for (int i = 1; i <= vlength; i++)
                {
                    double zfaki1 = zfak[i];
                    int tsum = 0;
                    for (int kk = 1; kk <= h; kk++)
                    {
                        zz[kk] = zv[kk, i];
                        tsum = tsum + zz[kk];
                    }
                    zz[k] = lastrsum - tsum;

                    for (int j = 1; j <= permnew; j++)
                    {
                        double zfaki = zfaki1 * pfak[j];
                        if (Mode > 1)
                        {
                            w[1] = zz[1] + perm[1, j];
                        }
                        else
                        {
                            bool sorted;
                            for (int kk = 1; kk <= k; kk++)
                                w[kk] = zz[kk] + perm[kk, j];
                            do
                            {
                                sorted = true;
                                for (int kk = 1; kk <= sumcount; kk++)
                                {
                                    int k1 = kk + 1;
                                    if (w[kk] > w[k1])
                                    {
                                        int w1 = w[kk];
                                        w[kk] = w[k1];
                                        w[k1] = w1;
                                        sorted = false;
                                    }
                                }
                            }
                            while (!sorted);

                            if (it >= asymend)
                            {
                                int kk = 0;
                                int k1 = sum3;
                                do
                                {
                                    kk = kk + 1;
                                    k1 = k1 - 1;
                                }
                                while (!(-w[kk] != w[k1] | kk == sdiv2));

                                if (-w[kk] < w[k1])
                                {
                                    for (kk = 1; kk <= k; kk++)
                                        w[kk] = -w[kk];
                                    k1 = k;
                                    for (kk = 1; kk <= sdiv2; kk++)
                                    {
                                        int w1 = w[kk];
                                        w[kk] = w[k1];
                                        w[k1] = w1;
                                        k1 = k1 - 1;
                                    }
                                }
                            }
                        }

                        if (first)
                        {
                            first = false;
                            for (int kk = 1; kk <= h; kk++)
                                v[kk, 1] = w[kk];
                            vfak[1] = zfaki;
                        }
                        else
                        {
                            int l = 1;
                            int r = vnewend;
                            do
                            {
                                int m = (l + r + 1) / 2;
                                int k1 = 0;
                                bool EQ;
                                do
                                {
                                    k1 = k1 + 1;
                                    vref = v[k1, m];
                                    EQ = vref == w[k1];
                                }
                                while (k1 < h & EQ);
                                bool LE = (vref <= w[k1]);
                                if (LE)
                                    l = m;
                                else
                                    r = m - 1;
                            }
                            while (l != r);

                            int kk = 1;
                            while (v[kk, l] == w[kk] & kk <= h)
                                kk = kk + 1;
                            if (kk == h + 1)
                            {
                                vfak[l] = vfak[l] + zfaki;
                            }
                            else
                            {
                                vnewend = vnewend + 1;
                                l = l + 1;
                                if (ve > vlimit)
                                {
                                    Console.WriteLine("Not enough memory");
                                    return null;
                                }

                                if (vnewend != l)
                                {
                                    for (int i1 = vnewend; i1 >= l; i1 -= 1)
                                    {
                                        int i2 = i1 + 1;
                                        vfak[i2] = vfak[i1];
                                        for (kk = 1; kk <= h; kk++)
                                            v[kk, i2] = v[kk, i1];
                                    }
                                }
                                vfak[l] = zfaki;
                                for (kk = 1; kk <= h; kk++)
                                    v[kk, l] = w[kk];
                            }
                        }
                    }
                }

                ve = vnewend;
                for (int i = 0; i <= ve; i++)
                {
                    zfak[i] = vfak[i];
                    for (int kk = 1; kk <= h; kk++)
                        zv[kk, i] = v[kk, i];
                }
                vlength = vnewend;
                Console.WriteLine("vlength: {0}", vlength);
                Last = vnewend;
            }



            double s = 0d;
            v = null;
            vfak = null;
            var rv = new double[1000002];
            var rvfak = new double[1000002];

            Console.WriteLine("Start Sorting");

            if (Mode2 >= 7)
                return null;
            int slength = 1;
            first = true;
            //int k2 = 0;

            int[,] Ranks;
            Ranks = new int[vlength, h + 1];
            for (int i = 1; i <= vlength; i++)
            {
                double zfaki = zfak[i];
                //Console.WriteLine("i: {0}, zfaki: {1}", i, zfaki);
                int sanz = 1;
                int tsum = 0;
                for (int kk = 1; kk <= h; kk++)
                {
                    //k2a = k2a + 1;
                    w[kk] = zv[kk, i];
                    tsum = tsum + w[kk];
                    Ranks[i - 1, kk - 1] = zv[kk, i] / 2;


                }
                w[k] = rsum - tsum;
                Ranks[i - 1, h] = w[k] / 2;
                if (Mode2 == 1)
                {
                    s = 0d;
                    for (int kk = 1; kk <= k; kk++)
                    {
                        double stemp = w[kk];
                        stemp = stemp * stemp;
                        s = s + stemp;
                    }
                }

                if (Mode2 == 6)
                {
                    s = w[1];
                    for (int j = 2; j <= k; j++)
                        s = s + j * w[j];
                }

                if (Mode2 == 2)
                    s = w[k] - w[1];


                if (Mode2 == 3 | Mode2 == 4)
                {
                    if (Mode2 == 3)
                        dloop = 2;
                    else
                        dloop = 1;
                    int k3 = 1;
                    for (int j = 1; j <= dloop; j++)
                    {
                        for (int kk = 1; kk <= k; kk++)
                            w[kk] = -w[kk];
                        for (int kk = 1; kk <= k; kk++)
                        {
                            int dun1 = -30000;
                            for (int k1 = 1; k1 <= k; k1++)
                            {
                                if (k1 != kk)
                                {
                                    int dun = w[kk] - w[k1];
                                    if (Mode2 == 4)
                                        dun = Math.Abs(dun);
                                    if (dun > dun1)
                                        dun1 = dun;
                                }
                            }
                            diff[k3] = dun1;
                            k3 = k3 + 1;
                        }
                    }
                    sanz = dloop * k;
                }

                if (Mode2 == 5)
                {
                    s = -w[1];
                    if (s < w[k])
                        s = w[k];
                }

                while (sanz > 0)
                {
                    if (Mode2 == 3 | Mode2 == 4)
                        s = diff[sanz];
                    if (first)
                    {
                        first = false;
                        rv[1] = s;
                        rvfak[1] = zfaki;
                    }
                    else
                    {
                        int l = 1;
                        int r = slength;
                        do
                        {
                            int m = (l + r + 1) / 2;     // (* M:=(L+r+1) div 2;*)
                            if (rv[m] >= s)
                                l = m;
                            else
                                r = m - 1;
                        }
                        while (l != r);

                        if (rv[l] == s)
                        {
                            rvfak[l] = rvfak[l] + zfaki;
                        }
                        else
                        {
                            slength = slength + 1;
                            l = l + 1;
                            for (int i1 = slength; i1 >= l; i1 -= 1)
                            {
                                int i2 = i1 + 1;
                                rv[i2] = rv[i1];
                                rvfak[i2] = rvfak[i1];
                            }
                            rvfak[l] = zfaki;
                            rv[l] = s;
                        }
                    }
                    sanz = sanz - 1;
                }
            }

            double nnr = 1.0E-300d;
            if (Mode2 == 3 | Mode2 == 4)
                nnr = nnr * k * dloop;
            for (int i = 1; i <= n; i++)
                nnr = nnr * permcount;
            double pcum = 0d;
            var Output = new double[slength, 4];
            Console.WriteLine("     W,            pmf,            CDF,           Approx to CDF");

            for (int i = 1; i <= slength; i++)
            {
                double p1 = rvfak[i] / nnr;
                pcum = pcum + p1;
                double Chi2 = 0.0;
                if (Mode2 == 1)
                    Chi2 = rv[i] / variance * h;
                else
                    Chi2 = rv[i] / 2d;
                Output[i - 1, 0] = Chi2 / 2d;
                Output[i - 1, 1] = p1;
                Output[i - 1, 2] = pcum;
                Output[i - 1, 3] = 1d - DistMain.cdis(h, Chi2);
                Console.WriteLine("{0:E10}, {1:E10}, {2:E10}, {3:E10}", Output[i - 1, 0], Output[i - 1, 1], Output[i - 1, 2], Output[i - 1, 3]);
            }

            Console.WriteLine("Number der Permutationen: {0}", 1.0E+300d * nnr);
            return Output;
        }



        // N : total sample size; m: sample size of the first group
        private static double[] perm2(int[] X, int N, int m, out int panz)
        {
            var ir = new int[10000];
            var ira = new int[10000];
            var ic = new int[10000];
            if (m > N / 2d)
            {
                m = N - m;
            }
            for (int i = 1; i <= N; i++)
                ir[i] = X[i];
            ic[1] = 1;
            int ih = 1;
            int iminm = 0;
            for (int i = 1; i <= m; i++)
            {
                ic[i + 1] = ic[i] + ih;
                iminm = iminm + ir[i];
                ih = ih + ir[N - i + 1] - ir[i];
            }
            int icm = ic[m + 1] + ih;
            int ASize = icm + 10;
            var a = new double[ASize + 1];

            for (int i = 1; i <= icm; i++)
                a[i] = 0d;
            a[1] = 1d;
            ira[1] = 0;
            for (int L = 2; L <= N; L++)
            {
                int irl = ir[L];
                int l2 = L / 2;
                int ib = m + 1 - l2;
                if (ib < 1)
                {
                    ib = 1;
                }
                else if (2 * l2 == L)
                {
                    int jb = ic[l2];
                    int je = jb + ira[l2];
                    int icj = ic[l2 + 1] + je;
                    for (int j = jb; j <= je; j++)
                        a[icj - j] = a[j];
                }
                for (int k = ib; k <= m; k++)
                {
                    int il = m + 1 - k;
                    int jb = ic[il + 1] + irl - ir[il];
                    int je = jb + ira[il];
                    int ici = ic[il] - jb;
                    for (int j = jb; j <= je; j++)
                        a[j] = a[j] + a[ici + j];
                    ira[il + 1] = ira[il] + irl - ir[il];
                }
            }

            double asum = 1d;
            double msum = 1d;
            for (int i = 1; i <= N; i++)
                asum = asum * i;
            for (int i = 1; i <= m; i++)
                msum = msum * i;
            for (int i = 1; i <= N - m; i++)
                msum = msum * i;
            asum = asum / msum;
            int qmin = iminm;
            int qmax = iminm + icm - ic[m + 1] - 1;
            for (int i = ic[m + 1]; i <= icm; i++)
            {
                int j3 = i - ic[m + 1] + 1;
                a[j3] = a[i] / asum;
            }
            double pcum = 0d;
            panz = qmax - qmin;
            var pprob = new double[panz + 1];
            for (int i = 1; i <= qmax - qmin + 1; i++)
            {
                int i1 = i - 1;
                double ai = a[i];
                pprob[i1] = ai;
                pcum = pcum + ai;
            }
            a = null;
            return pprob;
        }



        public static double[] MannWhitneyCalc(int m, int n)
        {
            int[] nn = new int[] { 0, m, n };
            return TerpstaCalc(2, nn);
        }



        public static double[] TerpstaCalc(int k, int[] n)
        {
            int panz = 0;
            int qanz = 0;
            var m = new int[k + 1 + 1];
            m[0] = 0;
            for (int j = 1; j <= k; j++)
                m[j] = m[j - 1] + n[j];
            int TS = 0;
            for (int j = 1; j <= k - 1; j++)
                TS = TS + m[j] * n[j + 1];
            var pneu = new double[TS + 2 + 1];
            var X = new int[m[k] + 2 + 1];
            for (int i = 1; i <= m[k]; i++)
                X[i] = i;
            var pprob = perm2(X, m[2], m[1], out panz);
            for (int j = 3; j <= k; j++)
            {
                var qprob = perm2(X, m[j], m[j - 1], out qanz);
                for (int i = 0; i <= qanz + panz; i++)
                    pneu[i] = 0d;
                for (int i = 0; i <= qanz; i++)
                {
                    for (int i2 = 0; i2 <= panz; i2++)
                    {
                        int i4 = i + i2;
                        pneu[i4] = pneu[i4] + pprob[i2] * qprob[i];
                    }
                }
                panz = panz + qanz;
                if (j == 3)
                    pprob = new double[TS + 2 + 1];
                for (int i = 0; i <= panz; i++)
                    pprob[i] = pneu[i];
            }
            Array.Resize(ref pprob, panz + 1);
            return pprob;
        }



        public static double[] KendallCalc(int n)
        {
            int nmax = n * (n - 1) + 1;
            var X = new double[nmax + 2 + 1];
            var y = new double[nmax + 2 + 1];
            double permcount = 1d;
            X[1] = permcount;
            int nl = 1;
            for (int it = 2; it <= n; it++)
            {
                permcount = permcount * it;
                nl = nl + it - 1;
                int center = (nl + 1) / 2;
                for (int i = 1; i <= nl; i++)
                    y[i] = 0d;
                for (int i = center; i >= 1; i -= 1)
                {
                    int limit = i - it + 1;
                    if (limit < 1)
                        limit = 1;
                    double yy = y[i];
                    for (int j1 = i; j1 >= limit; j1 -= 1)
                        yy = yy + X[j1];
                    y[i] = yy;
                }
                int j = nl + 1;
                for (int i = 1; i <= center; i++)
                {
                    j = j - 1;
                    double yy = y[i];
                    X[i] = yy;
                    X[j] = yy;
                }
            }
            permcount = 1d;
            for (int i = 2; i <= n; i++)
                permcount = permcount * i;
            for (int i = 1; i <= nl; i++)
                X[i - 1] = X[i] / permcount;
            nl = nl - 1;
            Array.Resize(ref X, nl + 1);
            return X;
        }



        public static double[] PageQuadeCalc(bool UseRanks, int k, int n, int Order)
        {
            var p = default(double[]);
            int pl = 0;
            int F = n;
            if (UseRanks)
                F = n * (n + 1) / 2;
            DistCornish.SpearmanCalc(k, Order, ref pl, ref p);
            var Q = new double[pl * F + 1];
            var r = new double[pl * F + 1];
            for (int i = 0; i <= pl; i++)
                Q[i] = p[i];
            int ql = pl;
            for (int h = 2; h <= n; h++)
            {
                if (UseRanks)
                    F = h;
                else
                    F = 1;
                for (int i = 0; i <= pl; i++)
                {
                    for (int j = 0; j <= ql; j++)
                        r[F * i + j] = r[F * i + j] + p[i] * Q[j];
                }
                ql = ql + F * pl;
                for (int i = 0; i <= ql; i++)
                {
                    Q[i] = r[i];
                    r[i] = 0d;
                }
            }
            return Q;
        }



        public static double[] PageCalc(int k, int N)
        {
            return PageQuadeCalc(false, k, N, 0);
        }

        public static double[] PageQCalc(int k, int N)
        {
            return PageQuadeCalc(true, k, N, 0);
        }

        public static double[] WilcoxonCalc(int N)
        {
            return PageQuadeCalc(true, 2, N, 0);
        }

        public static double[] SignCalc(int N)
        {
            return PageQuadeCalc(false, 2, N, 0);
        }






    }
}