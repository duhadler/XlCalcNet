using System;
using Microsoft.VisualBasic;

namespace NewDistrib
{


    static class PermFriedman
    {



        public static void DemoFriedman()
        {

            object Result;
            int What;
            int k;
            int n;
            int Quade;
            int Mode;
            int Mode2;
            What = 0; // not just titles
            k = 3;  // number of groups
            n = 10; // Number of blocks
            Quade = 1;  // 1=friedman 2=quade
            Mode = 1;  // 1=anova 2=page
            Mode2 = 1; // 1=SAQ  2=Range  3=Dunnett-1 4=Dunnett-2  5=Youden  6=Quit
            Result = Friedman(What, k, n, Quade, Mode, Mode2);
        }

        public static object Friedman(int GetWhat, int sum2, int n, int Quade, int Mode, int Mode2)
        {

            // sum2 : number of groups
            // n: Number of blocks
            // quade: 1=friedman 2=quade
            // ties:  'J'
            // asymend : number of asymmetric blocks
            // mode : 1=anova 2=page
            // mode2: 1=SAQ  2=Range  3=Dunnett-1 4=Dunnett-2  5=Youden  6=Quit
            const int vlimit = 1000000;
            double[,] Output; // , title() As String
            double[] vfak;
            double[] zfak;
            double[] rv;
            double[] rvfak;
            int[,] v;
            int[,] zv;
            int[] w;
            int[] zz;
            int[] b;
            int[] y;
            int[] z;
            int[] diff;
            int[,] perm;
            int[] pfak;
            int[,] x;
            int k;
            int asymend;
            int vlength;
            int permanz;
            int rsum;
            int i;
            int j;
            var ve = default(int);
            int vneuend;
            int Last;
            int k1;
            int k2;
            //int lh;
            int i1;
            int i2;
            int m;
            //int m1;
            int l;
            int r;
            int h;
            int w1;
            int pn;
            int s2;
            int nr;
            var permneu = default(int);
            int k3;
            int mean;
            int fit;
            int it;
            int lastrsum;
            int sdiv2;
            int sumanz;
            int yk;
            int vref;
            int sum3;
            int tsum;
            int slength;
            int sanz;
            var dloop = default(int);
            int dun1;
            int dun;
            double zfaki1;
            double s;
            double zfaki;
            double Varianz;
            //double icum;
            double pcum;
            double p1;
            double Chi2;
            double stemp;
            double nnr;
            string sline;
            bool notsame;
            bool notfound;
            bool first;
            bool show;
            bool EQ;
            bool LE;
            bool sortiert;


            x = new int[n + 1 + 1, sum2 + 1 + 1];
            zfak = new double[1000001];
            vfak = new double[1000001];
            zv = new int[sum2 + 1 + 1, 1000002];
            v = new int[sum2 + 1 + 1, 1000002];
            w = new int[sum2 + 1 + 1];
            zz = new int[sum2 + 1 + 1];
            b = new int[sum2 + 1 + 1];
            y = new int[sum2 + 1 + 1];
            z = new int[sum2 + 1 + 1];
            diff = new int[2 * (sum2 + 1) + 1 + 1];

            show = true;
            var loopTo = n;
            for (i = 1; i <= loopTo; i++)
            {
                var loopTo1 = sum2;
                for (j = 1; j <= loopTo1; j++)
                {
                    if (Quade == 2)
                        x[i, j] = 2 * j * i;
                    else
                        x[i, j] = 2 * j;
                }
            }
            asymend = 0;

            if (show)
            {
                Console.WriteLine("Listing des Datensatzes");
                Console.WriteLine("-----------------------");
                var loopTo2 = n;
                for (i = 1; i <= loopTo2; i++)
                {
                    sline = Conversion.Str(i) + ".Block";
                    var loopTo3 = sum2;
                    for (j = 1; j <= loopTo3; j++)
                        sline = sline + Conversion.Str(x[i, j]) + "  ";
                    Console.WriteLine(sline);
                }
            }

            sdiv2 = sum2 / 2;
            sum3 = sum2 + 1;
            if (Mode >= 2)
                sumanz = 1;
            else
                sumanz = sum2 - 1;
            fit = 1;
            h = sumanz;
            permanz = 1;
            Last = 0;
            Varianz = 0d;
            var loopTo4 = sum2;
            for (k = 1; k <= loopTo4; k++)
            {
                zv[k, 1] = 0;
                y[k] = 0;
                permanz = permanz * k;
            }

            perm = new int[sum2 + 1 + 1, permanz + 1 + 1];
            pfak = new int[permanz + 1 + 1];

            vlength = 1;
            rsum = 0;
            zfak[1] = 1.0E-300d; // (*permanz;*)
            vfak[1] = 0d;

            var loopTo5 = n;
            for (it = 1; it <= loopTo5; it++)
            {
                vneuend = 1;
                lastrsum = rsum;
                first = true;
                notsame = false;
                mean = 0;
                var loopTo6 = sum2;
                for (k = 1; k <= loopTo6; k++)
                    mean = mean + fit * x[it, k];
                mean = mean / sum2;
                var loopTo7 = sum2;
                for (k = 1; k <= loopTo7; k++)
                {
                    yk = fit * x[it, k] - mean;
                    rsum = rsum + yk;
                    Varianz = Varianz + yk * yk;
                    if (yk != y[k])
                        notsame = true;
                    y[k] = yk;
                }

                // (************************************
                // *  permutations of the ith block  *
                // ************************************)

                if (notsame)
                {
                    permneu = 0;
                    for (j = permanz; j >= 1; j -= 1)
                    {
                        z[1] = 0;
                        nr = j;
                        pn = permanz;
                        var loopTo8 = sum2;
                        for (k = 1; k <= loopTo8; k++)
                            b[k] = k;
                        for (k = sum2; k >= 1; k -= 1)
                        {
                            pn = pn / k;
                            s2 = (nr - 1) / pn;
                            nr = nr - pn * s2;
                            s2 = s2 + 1;
                            if (Mode == 1)
                                z[k] = y[b[s2]];
                            if (Mode == 2)
                                z[1] = z[1] - (2 * k - sum3) * y[b[s2]];
                            var loopTo9 = k - 1;
                            for (k1 = s2; k1 <= loopTo9; k1++)
                                b[k1] = b[k1 + 1];
                        }
                        i = 1;
                        notfound = true;
                        while (notfound & i <= permneu)
                        {
                            k = 1;
                            while (perm[k, i] == z[k] & k < sum2)
                                k = k + 1;
                            if (k == sum2)
                                notfound = false;
                            else
                                i = i + 1;
                        }
                        if (notfound)
                        {
                            permneu = permneu + 1;
                            var loopTo10 = sum2;
                            for (k = 1; k <= loopTo10; k++)
                                perm[k, i] = z[k];
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

                k2 = 0;
                var loopTo11 = vlength;
                for (i = 1; i <= loopTo11; i++)
                {
                    zfaki1 = zfak[i];
                    tsum = 0;
                    var loopTo12 = h;
                    for (k = 1; k <= loopTo12; k++)
                    {
                        k2 = k2 + 1;
                        zz[k] = zv[k, i];
                        tsum = tsum + zz[k];
                    }
                    zz[sum2] = lastrsum - tsum;

                    var loopTo13 = permneu;
                    for (j = 1; j <= loopTo13; j++)
                    {
                        zfaki = zfaki1 * pfak[j];
                        if (Mode > 1)
                        {
                            w[1] = zz[1] + perm[1, j];
                        }
                        else
                        {
                            var loopTo14 = sum2;
                            for (k = 1; k <= loopTo14; k++)
                                w[k] = zz[k] + perm[k, j];
                            do
                            {
                                sortiert = true;
                                var loopTo15 = sumanz;
                                for (k = 1; k <= loopTo15; k++)
                                {
                                    k1 = k + 1;
                                    if (w[k] > w[k1])
                                    {
                                        w1 = w[k];
                                        w[k] = w[k1];
                                        w[k1] = w1;
                                        sortiert = false;
                                    }
                                }
                            }
                            while (!sortiert);

                            if (it >= asymend)
                            {
                                k = 0;
                                k1 = sum3;
                                do
                                {
                                    k = k + 1;
                                    k1 = k1 - 1;
                                }
                                while (!(-w[k] != w[k1] | k == sdiv2));

                                if (-w[k] < w[k1])
                                {
                                    var loopTo16 = sum2;
                                    for (k = 1; k <= loopTo16; k++)
                                        w[k] = -w[k];
                                    k1 = sum2;
                                    var loopTo17 = sdiv2;
                                    for (k = 1; k <= loopTo17; k++)
                                    {
                                        w1 = w[k];
                                        w[k] = w[k1];
                                        w[k1] = w1;
                                        k1 = k1 - 1;
                                    }
                                }
                            }
                        }

                        if (first)
                        {
                            first = false;
                            var loopTo18 = h;
                            for (k = 1; k <= loopTo18; k++)
                                v[k, 1] = w[k];
                            vfak[1] = zfaki;
                        }
                        else
                        {
                            l = 1;
                            r = vneuend;
                            do
                            {
                                m = (l + r + 1) / 2;
                                k = 0;
                                do
                                {
                                    k = k + 1;
                                    vref = v[k, m];
                                    EQ = vref == w[k];
                                }
                                while (k < h & EQ);
                                LE = vref <= w[k];
                                if (LE)
                                    l = m;
                                else
                                    r = m - 1;
                            }
                            while (l != r);

                            k = 1;
                            while (v[k, l] == w[k] & k <= h)
                                k = k + 1;
                            if (k == h + 1)
                            {
                                vfak[l] = vfak[l] + zfaki;
                            }
                            else
                            {
                                vneuend = vneuend + 1;
                                l = l + 1;
                                if (ve > vlimit)
                                {
                                    Console.WriteLine("Not enough memory");
                                    return null;
                                }

                                if (vneuend != l)
                                {
                                    var loopTo19 = l;
                                    for (i1 = vneuend; i1 >= loopTo19; i1 -= 1)
                                    {
                                        i2 = i1 + 1;
                                        vfak[i2] = vfak[i1];
                                        var loopTo20 = h;
                                        for (k = 1; k <= loopTo20; k++)
                                            v[k, i2] = v[k, i1];
                                    }
                                }
                                vfak[l] = zfaki;
                                var loopTo21 = h;
                                for (k = 1; k <= loopTo21; k++)
                                    v[k, l] = w[k];
                            }
                        }
                    }
                }

                ve = vneuend;
                var loopTo22 = ve;
                for (i = 0; i <= loopTo22; i++)
                {
                    zfak[i] = vfak[i];
                    var loopTo23 = h;
                    for (k = 1; k <= loopTo23; k++)
                        zv[k, i] = v[k, i];
                }
                vlength = vneuend;
                Console.WriteLine("vlength: {0}", vlength);
                Last = vneuend;
            }


            // {    CalcTestDis(mode2,sum2-1,vlength);}

            s = 0d;
            v = null;
            vfak = null;
            rv = new double[1000002];
            rvfak = new double[1000002];

            Console.WriteLine("Start Sorting");

            if (Mode2 >= 7)
                return null;
            slength = 1;
            first = true;
            k2 = 0;

            int[,] Ranks;
            Ranks = new int[vlength, h + 1];
            var loopTo24 = vlength;
            for (i = 1; i <= loopTo24; i++)
            {
                zfaki = zfak[i];
                Console.WriteLine("i: {0}, zfaki: {1}", i, zfaki);
                sanz = 1;
                tsum = 0;
                var loopTo25 = h;
                for (k = 1; k <= loopTo25; k++)
                {
                    k2 = k2 + 1;
                    w[k] = zv[k, i];
                    tsum = tsum + w[k];
                    // Console.WriteLine("i: {0}, k: {1}, Index: {2}, Z: {3}, V: {4}", i, k, zv(k, i), zfak(i), vfak(i))
                    Ranks[i - 1, k - 1] = zv[k, i] / 2;
                    // Console.WriteLine("i: {0}, k: {1}, Index: {2}", i, k, zv(k, i))


                }
                w[sum2] = rsum - tsum;
                Ranks[i - 1, h] = w[sum2] / 2;
                // Dim l1 As Integer, l2 As Integer, l3 As Integer
                // l1 = -1 * w(1) + 2 * w(2) - 1 * w(3)
                // l2 = 2 * w(1) - 1 * w(2) - 1 * w(3)
                // l3 = -1 * w(1) - 1 * w(2) + 2 * w(3)
                // Debug.Print w(1), w(2), w(3), l1, l2, l3, Round(zfaki * 1E+300)
                // 
                if (Mode2 == 1)
                {
                    s = 0d;
                    var loopTo26 = sum2;
                    for (k = 1; k <= loopTo26; k++)
                    {
                        stemp = w[k];
                        stemp = stemp * stemp;
                        s = s + stemp;
                    }
                }

                if (Mode2 == 6)
                {
                    s = w[1];
                    var loopTo27 = sum2;
                    for (j = 2; j <= loopTo27; j++)
                        s = s + j * w[j];
                }

                if (Mode2 == 2)
                    s = w[sum2] - w[1];


                if (Mode2 == 3 | Mode2 == 4)
                {
                    if (Mode2 == 3)
                        dloop = 2;
                    else
                        dloop = 1;
                    k3 = 1;
                    var loopTo28 = dloop;
                    for (j = 1; j <= loopTo28; j++)
                    {
                        var loopTo29 = sum2;
                        for (k = 1; k <= loopTo29; k++)
                            w[k] = -w[k];
                        var loopTo30 = sum2;
                        for (k = 1; k <= loopTo30; k++)
                        {
                            dun1 = -30000;
                            var loopTo31 = sum2;
                            for (k1 = 1; k1 <= loopTo31; k1++)
                            {
                                if (k1 != k)
                                {
                                    dun = w[k] - w[k1];
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
                    sanz = dloop * sum2;
                }

                if (Mode2 == 5)
                {
                    s = -w[1];
                    if (s < w[sum2])
                        s = w[sum2];
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
                        l = 1;
                        r = slength;
                        do
                        {
                            m = (l + r + 1) / 2;     // (* M:=(L+r+1) div 2;*)
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
                            var loopTo32 = l;
                            for (i1 = slength; i1 >= loopTo32; i1 -= 1)
                            {
                                i2 = i1 + 1;
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

            nnr = 1.0E-300d;
            ////double icum = 0d;
            if (Mode2 == 3 | Mode2 == 4)
                nnr = nnr * sum2 * dloop;
            var loopTo33 = n;
            for (i = 1; i <= loopTo33; i++)
                nnr = nnr * permanz;
            pcum = 0d;
            Output = new double[slength, 4];
            Console.WriteLine("W,            pmf,               CDF,             Approx to CDF");

            var loopTo34 = slength;
            for (i = 1; i <= loopTo34; i++)
            {
                p1 = rvfak[i] / nnr;
                pcum = pcum + p1;
                // If mode2 = 1 Then chi2 = rv(i) / 2 Else chi2 = rv(i) / 2
                if (Mode2 == 1)
                    Chi2 = rv[i] / Varianz * h;
                else
                    Chi2 = rv[i] / 2d;
                // output(i - 1, 0) = Chi2
                Output[i - 1, 0] = Chi2 / 2d;
                Output[i - 1, 1] = p1;
                Output[i - 1, 2] = pcum;
                Output[i - 1, 3] = 1d - DistMain.cdis(h, Chi2);
                Console.WriteLine("{0}, {1}, {2}, {3}", Output[i - 1, 0], Output[i - 1, 1], Output[i - 1, 2], Output[i - 1, 3]);
                // If show Then
                // sline = Str(i) + ".  "
                // Debug.Print sline, Chi2, "  ", pcum
                // End If
            }


            Console.WriteLine("Anzahl der Permutationen: {0}", 1.0E+300d * nnr);
            rv = null;
            rvfak = null;
            zfak = null;
            zv = null;
            return Output;
        }



        private static void perm2(ref double[] pprob, int[] X, int n, int m, ref int panz, ref bool success)
        {
            var ir = new int[1025];
            var ira = new int[1025];
            var ic = new int[1025];
            int i1;
            int j3;
            int i;
            int L;
            int j;
            int k;
            int ici;
            int il;
            int ih;
            int iminm;
            int icm;
            int irl;
            int l2;
            int ib;
            int jb;
            int je;
            int icj;
            double pcum;
            double ai;
            double msum;
            double asum;
            int qmin;
            int qmax;
            int ASize;
            // Dim a() As Double
            success = false;
            if (m > n / 2d)
                m = n - m;
            var loopTo = n;
            for (i = 1; i <= loopTo; i++)
                ir[i] = X[i];
            ic[1] = 1;
            ih = 1;
            iminm = 0;
            var loopTo1 = m;
            for (i = 1; i <= loopTo1; i++)
            {
                ic[i + 1] = ic[i] + ih;
                iminm = iminm + ir[i];
                ih = ih + ir[n - i + 1] - ir[i];
            }
            icm = ic[m + 1] + ih;
            ASize = icm + 10;
            var a = new double[ASize + 1];

            var loopTo2 = icm;
            for (i = 1; i <= loopTo2; i++)
                a[i] = 0d;
            a[1] = 1d;
            ira[1] = 0;
            var loopTo3 = n;
            for (L = 2; L <= loopTo3; L++)
            {
                irl = ir[L];
                l2 = L / 2;
                ib = m + 1 - l2;
                if (ib < 1)
                {
                    ib = 1;
                }
                else if (2 * l2 == L)
                {
                    jb = ic[l2];
                    je = jb + ira[l2];
                    icj = ic[l2 + 1] + je;
                    var loopTo4 = je;
                    for (j = jb; j <= loopTo4; j++)
                        a[icj - j] = a[j];
                }
                var loopTo5 = m;
                for (k = ib; k <= loopTo5; k++)
                {
                    il = m + 1 - k;
                    jb = ic[il + 1] + irl - ir[il];
                    je = jb + ira[il];
                    ici = ic[il] - jb;
                    var loopTo6 = je;
                    for (j = jb; j <= loopTo6; j++)
                        a[j] = a[j] + a[ici + j];
                    ira[il + 1] = ira[il] + irl - ir[il];
                }
            }

            asum = 1d;
            msum = 1d;
            var loopTo7 = n;
            for (i = 1; i <= loopTo7; i++)
                asum = asum * i;
            var loopTo8 = m;
            for (i = 1; i <= loopTo8; i++)
                msum = msum * i;
            var loopTo9 = n - m;
            for (i = 1; i <= loopTo9; i++)
                msum = msum * i;
            asum = asum / msum;
            qmin = iminm;
            qmax = iminm + icm - ic[m + 1] - 1;
            var loopTo10 = icm;
            for (i = ic[m + 1]; i <= loopTo10; i++)
            {
                j3 = i - ic[m + 1] + 1;
                a[j3] = a[i] / asum;
            }
            pcum = 0d;
            panz = qmax - qmin;
            pprob = new double[panz + 1];
            var loopTo11 = qmax - qmin + 1;
            for (i = 1; i <= loopTo11; i++)
            {
                i1 = i - 1;
                ai = a[i];
                pprob[i1] = ai;
                pcum = pcum + ai;
            }
            a = null;
            success = true;
        }




        public static void MannWhitneyCalcdemo0()
        {
            int m = 5;
            int n = 5;

            var N = new int[3];
            N[1] = m;
            N[2] = n;
            double[] X = TerpstaCalc(2, N);
            for (int i = 0; i <= X.Length - 1; i++)
                Console.WriteLine("i: {0}, X[i]: {1}", i, X[i]);
        }


        public static void TerpstaCalcdemo0()
        {
            int k = 4;
            var n = new int[k + 1];
            for (int j = 1; j <= k; j++)
                n[j] = 5;

            double[] X = TerpstaCalc(k, n);
            for (int i = 0; i <= X.Length - 1; i++)
                Console.WriteLine("i: {0}, X[i]: {1}", i, X[i]);

        }


        public static double[] TerpstaCalc(int k, int[] n)
        {
            double[] TerpstaCalcRet = default;

            var panz = default(int);
            double[] pprob;
            int[] X;
            double[] pneu;
            double[] qprob;
            int TS;
            int j;
            int i4;
            int i2;
            var qanz = default(int);
            int i;
            //int t;
            var success = default(bool);
            // Dim pmax As Double, pprobi As Double, p As Double, qmin As Integer, qmax As Integer
            // Dim pcum As Double, smin As Double, maxmoment As Integer, mi As Integer
            var m = new int[k + 1 + 1];
            //pprob = new double[2];
            //qprob = new double[2];

            m[0] = 0;
            var loopTo = k;
            for (j = 1; j <= loopTo; j++)
                m[j] = m[j - 1] + n[j];
            TS = 0;
            var loopTo1 = k - 1;
            for (j = 1; j <= loopTo1; j++)
                TS = TS + m[j] * n[j + 1];
            pneu = new double[TS + 2 + 1];

            pprob = new double[TS + 2 + 1];
            qprob = new double[TS + 2 + 1];


            // ReDim pprob(TS + 2)
            // ReDim qprob(TS + 2)
            X = new int[m[k] + 2 + 1];
            var loopTo2 = m[k];
            for (i = 1; i <= loopTo2; i++)
                X[i] = i;
            // {Multiply}
            //double t = 0;
            perm2(ref pprob, X, m[2], m[1], ref panz, ref success);
            // If Not (success) Then Exit Function
            var loopTo3 = k;
            for (j = 3; j <= loopTo3; j++)
            {
                perm2(ref qprob, X, m[j], m[j - 1], ref qanz, ref success);
                // If Not (success) Then Exit Function
                var loopTo4 = qanz + panz;
                for (i = 0; i <= loopTo4; i++)
                    pneu[i] = 0d;
                var loopTo5 = qanz;
                for (i = 0; i <= loopTo5; i++)
                {
                    var loopTo6 = panz;
                    for (i2 = 0; i2 <= loopTo6; i2++)
                    {
                        i4 = i + i2;
                        pneu[i4] = pneu[i4] + pprob[i2] * qprob[i];
                    }
                }
                panz = panz + qanz;
                if (j == 3)
                    pprob = new double[TS + 2 + 1];
                var loopTo7 = panz;
                for (i = 0; i <= loopTo7; i++)
                    pprob[i] = pneu[i];
                Console.WriteLine("", i, pprob[i]);
            }
            X = null;
            qprob = null;
            pneu = null;
            m = null;
            Array.Resize(ref pprob, panz + 1);
            success = true;
            TerpstaCalcRet = pprob;
            return TerpstaCalcRet;
        }


        public static void KendallCalcdemo0()
        {
            int n = 18;
            double[] X = KendallCalc(n);
            for (int i = 0; i <= X.Length-1; i++)
                Console.WriteLine("i: {0}, X[i]: {1}", i, X[i]);

        }



        public static double[] KendallCalc(int n)
        {
            double[] KendallCalcRet = default;
            int nl; // , y() As Double , X() As Double
            int nmax;
            int it;
            int mitte;
            int limit;
            int j;
            int i;
            double yy;
            double permanz; // , SD As Double, p As Double
            nmax = n * (n - 1) + 1;
            var X = new double[nmax + 2 + 1];
            var y = new double[nmax + 2 + 1];
            // SD = Math.Sqrt(2 * (2 * n + 5) / (9 * n * (n - 1)))
            permanz = 1d;
            X[1] = permanz;
            nl = 1;
            var loopTo = n;
            for (it = 2; it <= loopTo; it++)
            {
                permanz = permanz * it;
                nl = nl + it - 1;
                // p = 0
                mitte = (nl + 1) / 2;
                var loopTo1 = nl;
                for (i = 1; i <= loopTo1; i++)
                    y[i] = 0d;
                for (i = mitte; i >= 1; i -= 1)
                {
                    limit = i - it + 1;
                    if (limit < 1)
                        limit = 1;
                    yy = y[i];
                    var loopTo2 = limit;
                    for (j = i; j >= loopTo2; j -= 1)
                        yy = yy + X[j];
                    y[i] = yy;
                }
                j = nl + 1;
                var loopTo3 = mitte;
                for (i = 1; i <= loopTo3; i++)
                {
                    j = j - 1;
                    yy = y[i];
                    X[i] = yy;
                    X[j] = yy;
                }
            }
            permanz = 1d;
            var loopTo4 = n;
            for (i = 2; i <= loopTo4; i++)
                permanz = permanz * i;
            var loopTo5 = nl;
            for (i = 1; i <= loopTo5; i++)
                X[i - 1] = X[i] / permanz;
            nl = nl - 1;
            Array.Resize(ref X, nl + 1);
            y = null;
            KendallCalcRet = X;
            return KendallCalcRet;
        }



        public static void PageQuadeCalc(bool UseRanks, int k, int n, int Order, double[] Q)
        {
            int h;
            var pl = default(int);
            int j;
            int i;
            int F;
            int ql;
            double[] p;
            double[] r;
            p = new double[2];
            if (UseRanks)
                F = n * (n + 1) / 2;
            else
                F = n;
            DistCornish.SpearmanCalc(k, Order, ref pl, ref p);
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
                    //Console.WriteLine("i: {0}, Q[i]: {1}", i, Q[i]);
                }
            }
            for (i = 0; i <= ql; i++)
            {
                //Q[i] = r[i];
                //r[i] = 0d;
                Console.WriteLine("i: {0}, Q[i]: {1}", i, Q[i]);
            }
        }



        public static void PageCalc(int k, int N, double[] x)
        {
            PageQuadeCalc(false, k, N, 0, x);
        }

        public static void PageQCalc(int k, int N, double[] x)
        {
            PageQuadeCalc(true, k, N, 0, x);
        }

        public static void WilcoxonCalc(int N, double[] x)
        {
            PageQuadeCalc(true, 2, N, 0, x);
        }

        public static void SignCalc(int N, double[] x)
        {
            PageQuadeCalc(false, 2, N, 0, x);
        }




        public static void PageCalcdemo0()
        {
            double[] X = null;
            int k = 3;
            int N = 8;
            PageCalc(k, N, X);
        }


        public static void PageQCalcdemo0()
        {
            double[] X = null;
            int k = 3;
            int N = 8;
            PageQCalc(k, N, X);
        }


        public static void WilcoxonCalcdemo0()
        {
            double[] X = null;
            int N = 18;
            WilcoxonCalc(N, X);
        }


        public static void SignCalcdemo0()
        {
            double[] X = null;
            int N = 18;
            SignCalc(N, X);
        }




    }
}