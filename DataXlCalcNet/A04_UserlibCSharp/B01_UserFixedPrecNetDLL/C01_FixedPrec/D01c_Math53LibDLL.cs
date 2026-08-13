/* C# */


#define UsingDouble

#region Usings
using System;
using System.Diagnostics;
using System.Numerics;
using FixedPrecNet;


//using Ctx = FixedPrecNet.sreal;
//using CtxScalar = System.Single;
//using cb1SCtx1S =  FixedPrecNet.cb1SSingle1S;

using Ctx = FixedPrecNet.dreal;
using CtxScalar = System.Double;
using cb1SCtx1S =  FixedPrecNet.cb1SDouble1S;

//using Ctx = FixedPrecNet.ereal;
//using CtxScalar = FixedPrecNet.Extended;
//using cb1SCtx1S =  FixedPrecNet.cb1SExtended1S;

//using Ctx = FixedPrecNet.qreal;
//using CtxScalar = FixedPrecNet.Quadruple;
//using cb1SCtx1S =  FixedPrecNet.cb1SQuadruple1S;

//using Ctx = FixedPrecNet.oreal;
//using CtxScalar = FixedPrecNet.Octuple;
//using cb1SCtx1S =  FixedPrecNet.cb1SOctuple1S;

//#if HasArbPrecNet
//using Ctx = ArbPrecNet.mreal;
//using CtxScalar = ArbPrecNet.Mpfr;
//using cb1SCtx1S =  FixedPrecNet.cb1SMpfr1S;
//#endif
#endregion


namespace UserFixedPrecNet
{

    /// <summary>
    /// User defined functions based on the Double data type, using math53
    /// </summary>
    public partial class m53lib
    {




#region Rank test distributions




        private static void perm2(ref double[] pprob, int[] X, int n, int m, ref int panz, ref bool success)
        {
            success = false;
            var ir = new int[1025];
            var ira = new int[1025];
            var ic = new int[1025];
            if (m > n / 2d)
                m = n - m;
            for (int i = 1; i <= n; i++)
                ir[i] = X[i];
            ic[1] = 1;
            int ih = 1;
            int iminm = 0;
            for (int i = 1; i <= m; i++)
            {
                ic[i + 1] = ic[i] + ih;
                iminm = iminm + ir[i];
                ih = ih + ir[n - i + 1] - ir[i];
            }
            int icm = ic[m + 1] + ih;
            int ASize = icm + 10;
            var a = new double[ASize + 1];

            for (int i = 1; i <= icm; i++)
                a[i] = 0d;
            a[1] = 1d;
            ira[1] = 0;
            for (int L = 2; L <= n; L++)
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
            for (int i = 1; i <= n; i++)
                asum = asum * i;
            for (int i = 1; i <= m; i++)
                msum = msum * i;
            for (int i = 1; i <= n - m; i++)
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
            pprob = new double[panz + 1];
            for (int i = 1; i <= qmax - qmin + 1; i++)
            {
                int i1 = i - 1;
                double ai = a[i];
                pprob[i1] = ai;
                pcum = pcum + ai;
            }
            success = true;
        }


        public static double[] MannWhitneyPmfVector(int m, int n)
        {
            var N = new int[3];
            N[1] = m;
            N[2] = n;
            return TerpstaPmfVector(2, N);
        }


        public static double[] TerpstaPmfVector(int k, int[] n)
        {
            bool success = false;
            int panz = 0;
            int qanz = 0;
            int[] m = new int[k + 1 + 1];
            m[0] = 0;
            for (int j = 1; j <= k; j++)
                m[j] = m[j - 1] + n[j];
            int TS = 0;
            for (int j = 1; j <= k - 1; j++)
                TS = TS + m[j] * n[j + 1];
            double[] pneu = new double[TS + 2 + 1];
            double[] pprob = new double[TS + 2 + 1];
            double[] qprob = new double[TS + 2 + 1];
            int[] X = new int[m[k] + 2 + 1];
            for (int i = 1; i <= m[k]; i++)
                X[i] = i;
            perm2(ref pprob, X, m[2], m[1], ref panz, ref success);
            for (int j = 3; j <= k; j++)
            {
                perm2(ref qprob, X, m[j], m[j - 1], ref qanz, ref success);
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


        public static double[] KendallPmfVector(int n)
        {
            int nmax = n * (n - 1) + 1;
            var X = new double[nmax + 2 + 1];
            var y = new double[nmax + 2 + 1];
            double permanz = 1d;
            X[1] = permanz;
            int nl = 1;
            var loopTo = n;
            for (int it = 2; it <= loopTo; it++)
            {
                permanz = permanz * it;
                nl = nl + it - 1;
                int middle = (nl + 1) / 2;
                for (int i = 1; i <= nl; i++)
                    y[i] = 0d;
                for (int i = middle; i >= 1; i -= 1)
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
                for (int i = 1; i <= middle; i++)
                {
                    j = j - 1;
                    double yy = y[i];
                    X[i] = yy;
                    X[j] = yy;
                }
            }
            permanz = 1d;
            for (int i = 2; i <= n; i++)
                permanz = permanz * i;
            for (int i = 1; i <= nl; i++)
                X[i - 1] = X[i] / permanz;
            nl = nl - 1;
            Array.Resize(ref X, nl + 1);
            return X;
        }




        public static double[] SpearmanPmfVector(int n)
        {
            int[] X = new int[n + 1];
            int[] y = new int[n + 1];
            int[] p = new int[n + 1];
            int[] d = new int[n + 1];
            bool First = true;
            int nn = n;
            int count = 0;
            int Upper = 0;
            int lower = 0;

            for (int i = 1; i <= nn; i++)
            {
                X[i] = i;
                y[i] = i;
            }
            for (int i = 1; i <= nn; i++)
            {
                Upper = Upper + X[i] * y[i];
                lower = lower + X[i] * y[nn + 1 - i];
            }
            int Valcount = Upper - lower;
            int[] result = new int[Valcount + 1];
            double[] xx = new double[Valcount + 1];
            for (int i = 0; i <= Valcount; i++)
                result[i] = 0;

            do
            {
                n = nn;
                if (First)
                {
                    for (int k1 = 2; k1 <= n; k1++)
                    {
                        p[k1] = 0;
                        d[k1] = 1;
                    }
                    First = false;
                }
                int k = 0;
            index1:
                int Q = p[n] + d[n];
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
                if (n > 2)
                {
                    n = n - 1;
                    goto index1;
                }
                Q = 1;
                First = true;
            transpose1:
                Q = Q + k;
                int t = X[Q];
                X[Q] = X[Q + 1];
                X[Q + 1] = t;
                count = count + 1;
                int sum = 0;
                for (int i = 1; i <= nn; i++)
                    sum = sum + X[i] * y[i];
                result[sum - lower] = result[sum - lower] + 1;
            }
            while (!First);

            for (int i = 0; i <= Valcount; i++)
            {
                double fraction = 1.0d * result[i] / (1.0d * count);
                xx[i] = fraction;
            }
            return xx;
        }


        private static double[] PageQuadePmfVectorCalc(bool UseRanks, int k, int n)
        {
            int F = n;
            if (UseRanks) F = n * (n + 1) / 2;
            double[] p = SpearmanPmfVector(k);
            int pl = p.Length - 1;
            double[] Q = new double[pl * F + 1];
            double[] r = new double[pl * F + 1];
            for (int i = 0; i <= pl; i++)
                Q[i] = p[i];
            int ql = pl;
            for (int h = 2; h <= n; h++)
            {
                if (UseRanks) F = h;
                else F = 1;
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


        public static double[] PagePmfVector(int k, int N)
        {
            return PageQuadePmfVectorCalc(false, k, N);
        }


        public static double[] PageQuadePmfVector(int k, int N)
        {
            return PageQuadePmfVectorCalc(true, k, N);
        }


        public static double[] SignTestPmfVector(int N)
        {
            return PageQuadePmfVectorCalc(false, 2, N);
        }


        public static double[] WilcoxonPmfVector(int N)
        {
            return PageQuadePmfVectorCalc(true, 2, N);
        }


        public static double[,] Friedman(int k, int n, int Quade, int Mode, int Mode2)
        {
            // k : number of groups
            // n: Number of blocks
            // quade: 1=friedman 2=quade
            // mode : 1=anova 2=page
            // mode2: 1=SAQ  2=Range  3=Dunnett-1 4=Dunnett-2  5=Youden  6=Quit

            const int vlimit = 1000000;
            int[,] x = new int[n + 2, k + 1];
            int[,] zv = new int[k + 1, vlimit + 2];
            int[,] v = new int[k + 1, vlimit + 2];
            double[] zfak = new double[vlimit + 1];
            double[] vfak = new double[vlimit + 1];
            int[] w = new int[k + 1];
            int[] zz = new int[k + 1];
            int[] b = new int[k + 1];
            int[] y = new int[k + 1];
            int[] z = new int[k + 1];
            int[] diff = new int[2 * (k + 1) + 2];

            bool first;
            bool show = true;
            int ve = 0;
            int permnew = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    if (Quade == 2)
                        x[i, j] = 2 * j * i;
                    else
                        x[i, j] = 2 * j;
                }
            }
            int asymend = 0;

            if (show)
            {
                Console.WriteLine("Listing of data set");
                Console.WriteLine("-----------------------");
                for (int i = 1; i <= n; i++)
                {
                    string sline = i.ToString() + ".block";
                    for (int j = 1; j <= k; j++)
                        sline = sline + x[i, j].ToString() + "  ";
                    Console.WriteLine(sline);
                }
            }

            int sdiv2 = k / 2;
            int sum3 = k + 1;
            int sumcount = 1;
            if (Mode >= 2)
                sumcount = 1;
            else
                sumcount = k - 1;
            int fit = 1;
            int h = sumcount;
            int permcount = 1;
            int Last = 0;
            double variance = 0d;
            for (int kc = 1; kc <= k; kc++)
            {
                zv[kc, 1] = 0;
                y[kc] = 0;
                permcount = permcount * kc;
            }

            int[,] perm = new int[k + 2, permcount + 2];
            int[] pfak = new int[permcount + 2];

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
                for (int kc = 1; kc <= k; kc++)
                    mean = mean + fit * x[it, kc];
                mean = mean / k;
                for (int kc = 1; kc <= k; kc++)
                {
                    int yk = fit * x[it, kc] - mean;
                    rsum = rsum + yk;
                    variance = variance + yk * yk;
                    if (yk != y[kc])
                        notsame = true;
                    y[kc] = yk;
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
                        for (int kc = 1; kc <= k; kc++)
                            b[kc] = kc;
                        for (int kc = k; kc >= 1; kc -= 1)
                        {
                            pn = pn / kc;
                            int s2 = (nr - 1) / pn;
                            nr = nr - pn * s2;
                            s2 = s2 + 1;
                            if (Mode == 1)
                                z[kc] = y[b[s2]];
                            if (Mode == 2)
                                z[1] = z[1] - (2 * kc - sum3) * y[b[s2]];
                            for (int k1 = s2; k1 <= kc - 1; k1++)
                                b[k1] = b[k1 + 1];
                        }
                        int i = 1;
                        bool notfound = true;
                        while (notfound & i <= permnew)
                        {
                            int kc = 1;
                            while (perm[kc, i] == z[kc] & kc < k)
                                kc = kc + 1;
                            if (kc == k)
                                notfound = false;
                            else
                                i = i + 1;
                        }
                        if (notfound)
                        {
                            permnew = permnew + 1;
                            for (int kc = 1; kc <= k; kc++)
                                perm[kc, i] = z[kc];
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

                int k2 = 0;
                for (int i = 1; i <= vlength; i++)
                {
                    double zfaki1 = zfak[i];
                    int tsum = 0;
                    for (int kc = 1; kc <= h; kc++)
                    {
                        k2 = k2 + 1;
                        zz[kc] = zv[kc, i];
                        tsum = tsum + zz[kc];
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
                            for (int kc = 1; kc <= k; kc++)
                                w[kc] = zz[kc] + perm[kc, j];
                            bool sorted;
                            do
                            {
                                sorted = true;
                                for (int kc = 1; kc <= sumcount; kc++)
                                {
                                    int k1 = kc + 1;
                                    if (w[kc] > w[k1])
                                    {
                                        int w1 = w[kc];
                                        w[kc] = w[k1];
                                        w[k1] = w1;
                                        sorted = false;
                                    }
                                }
                            }
                            while (!sorted);

                            if (it >= asymend)
                            {
                                int kc = 0;
                                int k1 = sum3;
                                do
                                {
                                    kc = kc + 1;
                                    k1 = k1 - 1;
                                }
                                while (!(-w[kc] != w[k1] | kc == sdiv2));

                                if (-w[kc] < w[k1])
                                {
                                    for (kc = 1; kc <= k; kc++)
                                        w[kc] = -w[kc];
                                    k1 = k;
                                    for (kc = 1; kc <= sdiv2; kc++)
                                    {
                                        int w1 = w[kc];
                                        w[kc] = w[k1];
                                        w[k1] = w1;
                                        k1 = k1 - 1;
                                    }
                                }
                            }
                        }

                        if (first)
                        {
                            first = false;
                            for (int kc = 1; kc <= h; kc++)
                                v[kc, 1] = w[kc];
                            vfak[1] = zfaki;
                        }
                        else
                        {
                            int l = 1;
                            int r = vnewend;
                            do
                            {
                                int m = (l + r + 1) / 2;
                                int kk1 = 0;
                                int vref;
                                bool EQ;
                                do
                                {
                                    kk1 = kk1 + 1;
                                    vref = v[kk1, m];
                                    EQ = vref == w[kk1];
                                }
                                while (kk1 < h & EQ);
                                bool LE = vref <= w[kk1];
                                if (LE)
                                    l = m;
                                else
                                    r = m - 1;
                            }
                            while (l != r);

                            int kc = 1;
                            while (v[kc, l] == w[kc] & kc <= h)
                                kc = kc + 1;
                            if (kc == h + 1)
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
                                        for (kc = 1; kc <= h; kc++)
                                            v[kc, i2] = v[kc, i1];
                                    }
                                }
                                vfak[l] = zfaki;
                                for (kc = 1; kc <= h; kc++)
                                    v[kc, l] = w[kc];
                            }
                        }
                    }
                }

                ve = vnewend;
                for (int i = 0; i <= ve; i++)
                {
                    zfak[i] = vfak[i];
                    for (int kc = 1; kc <= h; kc++)
                        zv[kc, i] = v[kc, i];
                }
                vlength = vnewend;
                Console.WriteLine("vlength: {0}", vlength);
                Last = vnewend;
            }


            double s = 0d;
            double[] rv = new double[vlimit + 2];
            double[] rvfak = new double[vlimit + 2];

            Console.WriteLine("Start Sorting");
            int dloop = 0;

            if (Mode2 >= 7)
                return null;
            int slength = 1;
            first = true;
            int k5 = 0;

            int[,] Ranks = new int[vlength, h + 1];
            for (int i = 1; i <= vlength; i++)
            {
                double zfaki = zfak[i];
                //Console.WriteLine("i: {0}, zfaki: {1}", i, zfaki);
                int scount = 1;
                int tsum = 0;
                for (int kc = 1; kc <= h; kc++)
                {
                    k5 = k5 + 1;
                    w[kc] = zv[kc, i];
                    tsum = tsum + w[kc];
                    Ranks[i - 1, kc - 1] = zv[kc, i] / 2;


                }
                w[k] = rsum - tsum;
                Ranks[i - 1, h] = w[k] / 2;
                if (Mode2 == 1)
                {
                    s = 0d;
                    for (int kc = 1; kc <= k; kc++)
                    {
                        double stemp = w[kc];
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
                        for (int kc = 1; kc <= k; kc++)
                            w[kc] = -w[kc];
                        for (int kc = 1; kc <= k; kc++)
                        {
                            int dun1 = -30000;
                            for (int k1 = 1; k1 <= k; k1++)
                            {
                                if (k1 != kc)
                                {
                                    int dun = w[kc] - w[k1];
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
                    scount = dloop * k;
                }

                if (Mode2 == 5)
                {
                    s = -w[1];
                    if (s < w[k])
                        s = w[k];
                }

                while (scount > 0)
                {
                    if (Mode2 == 3 | Mode2 == 4)
                        s = diff[scount];
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
                            int m = (l + r + 1) / 2;
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
                    scount = scount - 1;
                }
            }

            double nnr = 1.0E-300d;
            ////double icum = 0d;
            if (Mode2 == 3 | Mode2 == 4)
                nnr = nnr * k * dloop;
            for (int i = 1; i <= n; i++)
                nnr = nnr * permcount;
            double pcum = 0d;
            double[,] Output = new double[slength, 4];

            var dist = dreal.dist_chi2(h);
            for (int i = 1; i <= slength; i++)
            {
                double p1 = rvfak[i] / nnr;
                pcum = pcum + p1;
                double Chi2 = 0d;
                if (Mode2 == 1) Chi2 = rv[i] / variance * h;
                else Chi2 = rv[i] / 2d;
                Output[i - 1, 0] = Chi2 / 2d;
                Output[i - 1, 1] = p1;
                Output[i - 1, 2] = pcum;
                Output[i - 1, 3] = dist.sf(Chi2);
            }
            Console.WriteLine("Number of permutations: {0}", 1.0E+300d * nnr);
            return Output;
        }







#endregion





    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion




