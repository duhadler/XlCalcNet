using System;
using Microsoft.VisualBasic;

namespace NewDistrib
{


    static class PermMilton
    {


        private const double sqrt2pi = 0.398942280401433d;
        private const int MaxGroup = 6;
        private const int rFieldsize = 1601;
        // type rfeldMilton=array(0..rFieldsize) of extended
        // rfeldpointer=^rfeldMilton
        // type ifeldMilton=array(0..100) of integer
        private static double[] s;
        private static double[,,] f2;
        private static double[,,] v;
        private static double[] HH = new double[11];
        private static double[] t2 = new double[11];
        private static double[,] a = new double[11, 11];
        private static double[] delta = new double[7];
        private static double Factor;
        private static double sum;
        private static double h;
        private static int icount;
        private static int Index;
        private static int left;
        private static int Right;
        private static int plimit;
        private static int vp;
        private static int p;
        private static bool IsNormal;
        private static bool IsWilcoxon;
        private static double GlobalP1;


        public static void DemoMilton()
        {
            // Milton_Wilcoxon_Demo()
            MiltonDemo();
            // CalcNormalRO()
            // DemoCalcLehmannRO()
            // LehmanndemoNew()
            // LehmannDemoRecursive()
            // DemoSampleEstRO()
            // DemoUniformEstRO()
        }

        // Log von n über k
        public static double LnBin(double n, double k)
        {
            double LnBinRet = default;
            LnBinRet = DistMain.LnGamma(n + 1d) - DistMain.LnGamma(k + 1d) - DistMain.LnGamma(n - k + 1d);
            return LnBinRet;
        }

        // density of the binomial distribution
        // k: number of successes
        // n: sample size
        // p: prob of success
        public static double BinDens(double k, double n, double p)
        {
            double BinDensRet = default;
            if (k < 0d | k > n | n < 1d)
                BinDensRet = 0d;
            else
                BinDensRet = Math.Exp(LnBin(n, k) + Math.Log(p) * k + Math.Log(1d - p) * (n - k));
            return BinDensRet;
        }



        public static double Myfunction(double x, int j)
        {
            double MyfunctionRet = default;
            //double b;
            //double z;
            var LeftTail = default(double);
            var Righttail = default(double);
            var density = default(double);
            double k;
            var x1 = default(double);
            double d;
            double Lp1;
            if (IsWilcoxon)
            {
                d = delta[1];
                x = x + 8.0d + 0.00301d;
                Lp1 = 1d;
                // If j = 1 Then Lp1 = 1 * GlobalP1 Else Lp1 = 1 * (1 - GlobalP1)
                if (j == 1)
                    x1 = x - d;
                if (j == 2)
                    x1 = Math.Abs(-x - d);
                // Console.WriteLine( "x1:", x1
                MyfunctionRet = Math.Exp(-Math.Pow(x1, 2d) / 2d) * sqrt2pi / Lp1;
                return MyfunctionRet;
            }

            // If IsWilcoxon Then
            // d = delta(1)
            // 'x = x + 8.0025
            // X = X + 8#
            // X = X / 2
            // '    Lp1 = 1
            // If j = 1 Then Lp1 = 1 * GlobalP1 Else Lp1 = 1 * (1 - GlobalP1)
            // Lp1 = Lp1 * 2
            // If (j = 1) And (X >= 0) Then x1 = X - d
            // '   If (j = 1) And (x < 0) Then x1 = x - d
            // If (j = 2) And (X >= 0) Then x1 = -X - d
            // '   If (j = 2) And (x < 0) Then x1 = -x - d
            // 
            // If X < 0 Then Myfunction = 0 Else Myfunction = (Exp(-(x1 ^ 2) / 2) * sqrt2pi) / Lp1
            // 'Myfunction = (Exp(-(x1 ^ 2) / 2) * sqrt2pi) / Lp1
            // Exit Function
            // End If


            if (IsNormal)
            {
                MyfunctionRet = Math.Exp(-Math.Pow(x - delta[j], 2d) / 2d) * sqrt2pi;
            }
            else
            {
                DistMain.ndis2(false, x, ref LeftTail, ref Righttail, ref density);
                k = delta[j];
                MyfunctionRet = density * k * Math.Pow(LeftTail, k - 1d);
                // Myfunction = density * (k * (RightTail ^ (k - 1)))

                // IsLogistic
                // b = 1
                // b = 0.25
                // z = Exp(-(x - delta(j)) / b)
                // Myfunction = z / (b * (1 + z) * (1 + z))
            }

            return MyfunctionRet;
        }

        public static void demo()
        {
            double x;
            double Result;
            IsNormal = true;
            for (x = -8; x <= 8d; x++)
            {
                delta[1] = 0.08d;
                Result = Myfunction(x, 1);
                Console.WriteLine("x: {0}, Result: {1}", x, Result);
            }
        }

        public static void InitMilton(int GroupAnz, ref int[] n)
        {
            int k;
            int i;
            int j;
            int iteration;
            Factor = 1d;
            p = 0;
            var loopTo = GroupAnz;
            for (j = 1; j <= loopTo; j++)
            {
                var loopTo1 = n[j];
                for (i = 1; i <= loopTo1; i++)
                    Factor = Factor * i;
                p = p + n[j];
            }
            plimit = 20;
            icount = 8;
            left = 0;
            vp = p;
            if (p > plimit)
                vp = plimit;
            s = new double[1602];
            f2 = new double[icount + 1 + 1, GroupAnz, 1602];
            v = new double[p + 1 + 1, vp + 1 + 1, 1602];

            t2[0] = 4d;
            var loopTo2 = icount - 2;
            for (k = 1; k <= loopTo2; k++)
                t2[k] = t2[k - 1] * 4d;
            Right = 1600 * 2;
            h = 0.01d / 2d;
            var loopTo3 = icount;
            for (iteration = 1; iteration <= loopTo3; iteration++)
            {
                Right = Right / 2;
                h = h * 2d;
                HH[iteration] = 1d;
                var loopTo4 = p;
                for (i = 1; i <= loopTo4; i++)
                    HH[iteration] = HH[iteration] * h;
                var loopTo5 = Right;
                for (k = left; k <= loopTo5; k++)
                {
                    var loopTo6 = GroupAnz - 1;
                    for (j = 0; j <= loopTo6; j++)
                    {
                        if (IsNormal)
                        {
                            f2[iteration, j, k] = Myfunction(k * h - 8d, j + 1);
                        }
                        else
                        {
                            f2[iteration, j, k] = Myfunction((k * h - 8d) * 1.0d, j + 1);
                        }
                    }
                }
            }
        } // {InitMilton}

        public static double RunMilton(int[] z)
        {
            double RunMiltonRet = default;
            int i;
            int k;
            int j;
            int iteration;
            Right = 1600 * 2;
            h = 0.01d / 2d;
            var loopTo = icount;
            for (iteration = 1; iteration <= loopTo; iteration++)
            {
                Right = Right / 2;
                h = h * 2d;
                Index = z[1];
                s[left] = 0d;
                var loopTo1 = Right;
                for (k = left; k <= loopTo1; k++)
                {
                    v[1, 1, k] = f2[iteration, Index, k];
                    s[k + 1] = s[k] + v[1, 1, k];
                }

                var loopTo2 = p;
                for (j = 2; j <= loopTo2; j++)
                {
                    Index = z[j];
                    vp = j - 1;
                    if (vp > plimit)
                        vp = plimit;
                    var loopTo3 = vp;
                    for (i = 1; i <= loopTo3; i++)
                    {
                        var loopTo4 = Right;
                        for (k = left; k <= loopTo4; k++)
                            v[j, i, k] = v[j - 1, i, k] * f2[iteration, Index, k] / (j + 1 - i);
                    }
                    if (j <= plimit)
                    {
                        var loopTo5 = Right;
                        for (k = left; k <= loopTo5; k++)
                            v[j, j, k] = s[k] * f2[iteration, Index, k];
                    }
                    s[0] = 0d;
                    var loopTo6 = Right;
                    for (k = left; k <= loopTo6; k++)
                    {
                        sum = 0d;
                        vp = j;
                        if (vp > plimit)
                            vp = plimit;
                        var loopTo7 = vp;
                        for (i = 1; i <= loopTo7; i++)
                            sum = sum + v[j, i, k];
                        s[k + 1] = s[k] + sum;
                    }
                }
                a[icount - iteration, 0] = Factor * HH[iteration] * s[Right + 1];
            }

            var loopTo8 = icount - 2;
            for (k = 0; k <= loopTo8; k++)
            {
                var loopTo9 = icount - 1;
                for (i = k + 1; i <= loopTo9; i++)
                    a[i, k + 1] = (t2[k] * a[i, k] - a[i - 1, k]) / (t2[k] - 1d);
            }
            RunMiltonRet = a[icount - 1, icount - 1];
            return RunMiltonRet;
        } // RunMilton

        public static void DoneMilton()
        {
            v = null;
            f2 = null;
            s = null;
        } // DoneMilton

        public static void Chase2(ref int x, ref int y, int k, int u, ref bool done, ref int[] p)
        {
            int s;
            int i;
            int j;
            int b;
            j = 0;
            b = 0;
            s = 0;
        l1:
            ;
            j = j + 1;
            if (Math.Abs(p[j]) == k)
            {
                if (p[j] < 0)
                    s = j;
                goto l1;
            }
            if (p[j - 1] == k)
            {
                for (i = j - s - 1; i >= 2; i -= 1)
                    p[s + i] = -k;
                if (s > b)
                    p[s] = k;
                p[s + 1] = p[j];
                p[j] = k;
                x = s + 1;
                y = j;
                return;
            }
            if (s > b)
                p[s] = k;
            l2:
            ;
            j = j + 1;
            if (Math.Abs(p[j]) < k)
                goto l2;
            if (j == u)
            {
                if (k == 2)
                {
                    done = true;
                    return;
                }
                j = s;
                b = s;
                k = k - 1;
                goto l1;
            }
            b = j - 1;
            i = b;
        l3:
            ;
            i = i + 1;
            if (p[i] == k)
            {
                p[i] = -k;
                goto l3;
            }
            if (p[i] == -k)
            {
                p[i] = p[b];
                p[b] = -k;
                x = b;
                y = i;
                return;
            }
            if (i == u)
            {
                if (k == 2)
                {
                    done = true;
                    return;
                }
                u = j;
                j = s;
                b = s;
                k = k - 1;
                goto l1;
            }
            x = j;
            y = i;
            p[j] = p[i];
            p[i] = k;
        } // Chase

        public static void demoP1toP2()
        {
            double p1;
            double p2;
            double pxy;
            double d;
            double p1_2;
            double p2_2;
            double pxy_2;
            d = 1d;
            p1 = DistMain.ndis(d);
            p2 = DistMain.ndis(d * Math.Sqrt(2d));
            pxy = (DistMain.ndis(d * Math.Sqrt(2d)) - DistMain.ndis(d)) / (DistMain.ndis(d) * DistMain.ndis(-d));
            p1_2 = 1d / (2d * pxy) * (pxy + 1d - Math.Sqrt(Math.Pow(pxy + 1d, 2d) - 4d * pxy * p2));
            p2_2 = (p1 - p1 * p1) * pxy + p1;
            pxy_2 = (p2 - p1) / (p1 - p1 * p1);
            Console.WriteLine("p1: {0}, p2: {1}, pxy: {2}", p1, p2, pxy);
            Console.WriteLine("p1_2: {0}, p2_2: {1}, pxy_2: {2}", p1_2, p2_2, pxy_2);
        }



        public static void Milton_Wilcoxon_Demo()
        {
            var a = new int[101];
            var n = new int[102];
            var p = new int[101];
            var id = new int[101];
            var Ranks = new int[101];
            int GroupAnz;
            int x;
            int y;
            int temp;
            int k;
            int u;
            int i1;
            int i2;
            int csum;
            int count;
            bool done;
            int icount2;
            string ss;
            string s3;
            double Result;
            var pcum = new double[101];
            var ptotal = new double[101];
            int Rmin;
            int Rmax;
            int m;
            int NTotal;
            int RTotalMax;
            double p1;
            double Pr;
            double p2;
            double ptotalsum;
            Rmin = 32000;
            Rmax = 0;
            RTotalMax = 0;
            double CdfSum;

            for (i1 = 0; i1 <= 100; i1++)
            {
                pcum[i1] = 0d;
                ptotal[i1] = 0d;
            }
            NTotal = 6;
            var loopTo = NTotal;
            for (m = 0; m <= loopTo; m++)
            {
                IsNormal = true;
                IsWilcoxon = true;
                GroupAnz = 2; // (*zahl der gruppen mit verschiedenen werten*)
                n[1] = m; // (*gruppenstaerken*)
                n[2] = NTotal - m;
                n[3] = 2;
                n[4] = 1;
                n[5] = 1;
                n[6] = 1;
                delta[1] = 1.12d;
                delta[2] = 0d;
                delta[3] = 0d;
                delta[4] = 2.5d;
                delta[5] = 2.5d;
                delta[6] = 2.5d;
                GlobalP1 = DistMain.ndis(delta[1]);
                var loopTo1 = GroupAnz;
                for (i1 = 1; i1 <= loopTo1; i1++)

                    id[i1] = i1 - 1; // (*werte der gruppen*)
                InitMilton(GroupAnz, ref n);

                csum = 0;
                count = 0;
                var loopTo2 = GroupAnz;
                for (i1 = 1; i1 <= loopTo2; i1++)
                {
                    csum = csum + n[i1];
                    var loopTo3 = n[i1];
                    for (i2 = 1; i2 <= loopTo3; i2++)
                    {
                        count = count + 1;
                        a[count] = id[i1];
                        p[count] = GroupAnz - i1 + 1;
                    }
                }

                icount2 = 1;
                x = 1;
                y = 2;
                k = GroupAnz;
                u = csum + 1;
                done = false;
                p[0] = GroupAnz + 1;
                p[u] = GroupAnz + 1;

                while (!done)
                {
                    ss = Strings.Format(icount2, "#00") + ": ";
                    var loopTo4 = GroupAnz;
                    for (i1 = 0; i1 <= loopTo4; i1++)
                        Ranks[i1] = 0;
                    var loopTo5 = csum;
                    for (i1 = 1; i1 <= loopTo5; i1++)
                    {
                        ss = ss + Conversion.Str(a[i1]);
                        Ranks[a[i1]] = Ranks[a[i1]] + i1;
                    }
                    if (Ranks[0] < Rmin)
                        Rmin = Ranks[0];
                    if (Ranks[0] > Rmax)
                        Rmax = Ranks[0];
                    if (Ranks[0] > RTotalMax)
                        RTotalMax = Ranks[0];
                    s3 = "[";
                    var loopTo6 = GroupAnz;
                    for (i1 = 1; i1 <= loopTo6; i1++)
                        s3 = s3 + Conversion.Str(Ranks[i1 - 1]) + ",";
                    s3 = s3 + "]";
                    Result = RunMilton(a);
                    Console.WriteLine("Ranks(0): {0}, ss: {1}, s3: {2}, Result: {3}", Ranks[0], ss, s3, Result);
                    pcum[Ranks[0]] = pcum[Ranks[0]] + Result;
                    // Console.WriteLine( ss, "        ", Format(result, "Scientific")
                    if (m == NTotal)
                        done = true;
                    Chase2(ref x, ref y, k, u, ref done, ref p);
                    temp = a[x];
                    a[x] = a[y];
                    a[y] = temp;
                    icount2 = icount2 + 1;
                }

                p1 = GlobalP1;
                Pr = BinDens(n[1], n[1] + n[2], p1);
                Console.WriteLine("Pr:: {0}", Pr);

                ptotalsum = 0d;
                var loopTo7 = Rmax;
                for (i1 = Rmin; i1 <= loopTo7; i1++)
                    ptotalsum = ptotalsum + pcum[i1];
                Console.WriteLine("local ptotalsum:: {0}", ptotalsum);
                var loopTo8 = Rmax;
                for (i1 = Rmin; i1 <= loopTo8; i1++)
                {
                    ptotal[i1] = ptotal[i1] + pcum[i1] * Pr / ptotalsum;
                    Console.WriteLine("i1: {0}, pcum(i1): {1}, pcum(i1) / ptotalsum: {2}", i1, pcum[i1], pcum[i1] / ptotalsum);
                }
                Rmin = 32000;
                Rmax = 0;
                for (i1 = 0; i1 <= 100; i1++)
                    pcum[i1] = 0d;

            }
            Console.WriteLine("Total distribution");
            ptotalsum = 0d;
            var loopTo9 = RTotalMax;
            for (i1 = 0; i1 <= loopTo9; i1++)
                ptotalsum = ptotalsum + ptotal[i1];

            double mu1;
            //double mu2;
            CdfSum = 0d;
            mu1 = 0d;
            //double mu2 = 0d;
            Console.WriteLine("ptotalsum:: {0}", ptotalsum);
            var loopTo10 = RTotalMax;
            for (i1 = 0; i1 <= loopTo10; i1++)
            {
                CdfSum = CdfSum + ptotal[i1] / ptotalsum;
                mu1 = mu1 + i1 * (ptotal[i1] / ptotalsum);
                Console.WriteLine("i1: {0}, CdfSum: {1}, 1 - CdfSum: {2}", i1, CdfSum, 1d - CdfSum);
                // Console.WriteLine( i1, Format((ptotal(i1) / ptotalsum), "0.00000000000E+000"), Format(ptotal(i1), "0.00000000000E+000")
            }
            Console.WriteLine("mu1: {0}", mu1);
            p1 = DistMain.ndis(delta[1]);
            p2 = DistMain.ndis(delta[1] * Math.Sqrt(2d));
            mu1 = NTotal * p1 + NTotal * (NTotal - 1) * p2 / 2d;
            Console.WriteLine("mu1: {0}", mu1);
            DoneMilton();
        }



        public static void MiltonDemo()
        {
            var a = new int[101];
            var n = new int[102];
            var p = new int[101];
            var id = new int[101];
            var Ranks = new int[101];
            int GroupAnz;
            int x;
            int y;
            int temp;
            int k;
            int u;
            int i1;
            int i2;
            int csum;
            int count;
            bool done;
            int icount2;
            string ss;
            string s3;
            double Result;
            IsNormal = true;
            IsWilcoxon = false;
            GroupAnz = 2; // (*zahl der gruppen mit verschiedenen werten*)
            n[1] = 2; // (*gruppenstaerken*)
            n[2] = 2;
            n[3] = 2;
            n[1] = 5; // (*gruppenstaerken*)
            n[2] = 5;
            n[3] = 1;
            n[4] = 1;
            n[5] = 1;
            n[6] = 1;
            delta[1] = 1d;
            delta[2] = 2d;
            delta[3] = 3d;
            delta[4] = 4.5d;
            delta[5] = 2.5d;
            delta[6] = 2.5d;
            var loopTo = GroupAnz;
            for (i1 = 1; i1 <= loopTo; i1++)

                id[i1] = i1 - 1; // (*werte der gruppen*)
            InitMilton(GroupAnz, ref n);

            csum = 0;
            count = 0;
            var loopTo1 = GroupAnz;
            for (i1 = 1; i1 <= loopTo1; i1++)
            {
                csum = csum + n[i1];
                var loopTo2 = n[i1];
                for (i2 = 1; i2 <= loopTo2; i2++)
                {
                    count = count + 1;
                    a[count] = id[i1];
                    p[count] = GroupAnz - i1 + 1;
                }
            }

            icount2 = 1;
            x = 1;
            y = 2;
            k = GroupAnz;
            u = csum + 1;
            done = false;
            p[0] = GroupAnz + 1;
            p[u] = GroupAnz + 1;

            while (!done)
            {
                ss = Strings.Format(icount2, "#00") + ": ";
                var loopTo3 = GroupAnz;
                for (i1 = 0; i1 <= loopTo3; i1++)
                    Ranks[i1] = 0;
                var loopTo4 = csum;
                for (i1 = 1; i1 <= loopTo4; i1++)
                {
                    ss = ss + Conversion.Str(a[i1]);
                    Ranks[a[i1]] = Ranks[a[i1]] + i1;
                }
                s3 = "[";
                var loopTo5 = GroupAnz;
                for (i1 = 1; i1 <= loopTo5; i1++)
                    s3 = s3 + Conversion.Str(Ranks[i1 - 1]) + ",";
                s3 = s3 + "]";
                Result = RunMilton(a);
                Console.WriteLine("ss: {0}, s3: {1}, Result: {2}", ss, s3, Result);

                // Console.WriteLine( ss, "        ", Format(result, "Scientific")
                Chase2(ref x, ref y, k, u, ref done, ref p);
                temp = a[x];
                a[x] = a[y];
                a[y] = temp;
                icount2 = icount2 + 1;
            }

            DoneMilton();
        }

        public static double logistic(double x, double a, double b)
        {
            double logisticRet = default;
            logisticRet = 1d / (1d + Math.Exp(-(x - a) / b));
            return logisticRet;
        }


        public static void cn(bool Usenormal, double TargetU, string ParName, double ParValue, double p, double q, double s, double u, double v, double aa, double w, double y)
        {
            var a = new int[101];
            var n = new int[102];
            int GroupAnz;
            string ss;
            double Result;
            double mu;
            IsNormal = Usenormal;
            IsWilcoxon = false;
            if (IsNormal)
            {
                mu = Math.Sqrt(2d) * DistX.ndisx(TargetU, 1d - TargetU);
                Console.WriteLine("Normal Distribution, mu = {0}", mu);
            }
            else
            {
                mu = 0.25d * 1.5d * Math.Log(TargetU / (1d - TargetU));
                Console.WriteLine("Logistic Distribution, mu = {0}", mu);

            }


            ParName = "mu";
            ParValue = mu;
            // mu = 0.9 * Sqr(2)
            GroupAnz = 2;
            delta[1] = 0d;
            delta[2] = mu;
            // Console.WriteLine( "mu: ", delta(2)
            n[1] = 1;
            n[2] = 1;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 1;
            ss = "0, 1 :";
            Result = RunMilton(a);
            p = Result;
            Console.WriteLine("ss: {0}, p: {1}", ss, p);
            DoneMilton();
            // mu = Sqr(2) * ndisx(p, 1 - p)
            // Console.WriteLine( "mu: ", mu
            // Console.WriteLine( "ndis: ", ndis(delta(2) / Sqr(2))
            // Console.WriteLine( "ndis: ", ndis(mu / Sqr(2))
            n[1] = 2;
            n[2] = 1;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            ss = "0, 0, 1 :";
            Result = RunMilton(a);
            q = Result;
            Console.WriteLine("ss: {0}, q: {1}", ss, q);
            DoneMilton();

            n[1] = 3;
            n[2] = 1;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 0;
            a[3] = 0;
            a[4] = 1;
            ss = "0, 0, 0, 1 :";
            Result = RunMilton(a);
            s = Result;
            Console.WriteLine("ss: {0}, s: {1}", ss, s);
            DoneMilton();

            n[1] = 4;
            n[2] = 1;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 0;
            a[3] = 0;
            a[4] = 0;
            a[5] = 1;
            ss = "0, 0, 0, 0, 1 :";
            Result = RunMilton(a);
            aa = Result;
            Console.WriteLine("ss: {0}, aa: {1}", ss, aa);
            DoneMilton();

            n[1] = 2;
            n[2] = 2;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            a[4] = 1;
            ss = "0, 0, 1, 1 :";
            Result = RunMilton(a);
            v = Result;
            Console.WriteLine("ss: {0}, v: {1}", ss, v);
            DoneMilton();

            n[1] = 2;
            n[2] = 2;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 1;
            a[3] = 0;
            a[4] = 1;
            ss = "0, 1, 0, 1 :";
            Result = RunMilton(a);
            u = v + 1d / 4d * Result;
            Console.WriteLine("ss: {0}, u: {1}", ss, u);
            DoneMilton();

            n[1] = 3;
            n[2] = 2;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 0;
            a[3] = 0;
            a[4] = 1;
            a[5] = 1;
            ss = "0, 0, 0, 1, 1 :";
            Result = RunMilton(a);
            w = Result;
            Console.WriteLine("ss: {0}, w1: {1}", ss, w);
            DoneMilton();

            n[1] = 3;
            n[2] = 2;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            a[4] = 0;
            a[5] = 1;
            ss = "0, 0, 1, 0, 1 :";
            Result = RunMilton(a);
            w = w + 1d / 3d * Result;
            Console.WriteLine("ss: {0}, w: {1}", ss, w);
            DoneMilton();

            n[1] = 3;
            n[2] = 2;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 1;
            a[3] = 0;
            a[4] = 0;
            a[5] = 1;
            ss = "0, 1, 0, 0, 1 :";
            Result = RunMilton(a);
            y = w + 1d / 6d * Result;
            Console.WriteLine("ss: {0}, y: {1}", ss, y);
            DoneMilton();

        }




        public static void CalcNormalRO()
        {
            var a = new int[101];
            var n = new int[102];
            int GroupAnz;
            string ss;
            double Result;
            double p;
            double q;
            //double r;
            double s;
            //double t;
            double u;
            double v;
            double aa;
            //double b;
            double w;
            //double x;
            double y;
            //double z;
            IsNormal = true;
            IsWilcoxon = false;
            GroupAnz = 2;
            delta[1] = 0d;
            delta[2] = 0.5d * Math.Sqrt(2d);
            if (IsNormal)
            {
                Console.WriteLine("Normal Distribution, D = {0}", delta[2]);
            }
            else
            {
                Console.WriteLine("Logistic Distribution, D = {0}", delta[2]);
            }
            n[1] = 1;
            n[2] = 1;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 1;
            ss = "0, 1 :";
            Result = RunMilton(a);
            p = Result;
            Console.WriteLine("ss: {0}, p: {1}", ss, p);
            DoneMilton();

            n[1] = 2;
            n[2] = 1;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            ss = "0, 0, 1 :";
            Result = RunMilton(a);
            q = Result;
            Console.WriteLine("ss: {0}, q: {1}", ss, q);
            DoneMilton();

            n[1] = 3;
            n[2] = 1;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 0;
            a[3] = 0;
            a[4] = 1;
            ss = "0, 0, 0, 1 :";
            Result = RunMilton(a);
            s = Result;
            Console.WriteLine("ss: {0}, s: {1}", ss, s);
            DoneMilton();

            n[1] = 4;
            n[2] = 1;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 0;
            a[3] = 0;
            a[4] = 0;
            a[5] = 1;
            ss = "0, 0, 0, 0, 1 :";
            Result = RunMilton(a);
            aa = Result;
            Console.WriteLine("ss: {0}, a: {1}", ss, a);
            DoneMilton();

            n[1] = 2;
            n[2] = 2;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            a[4] = 1;
            ss = "0, 0, 1, 1 :";
            Result = RunMilton(a);
            v = Result;
            Console.WriteLine("ss: {0}, v: {1}", ss, v);
            DoneMilton();

            n[1] = 2;
            n[2] = 2;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 1;
            a[3] = 0;
            a[4] = 1;
            ss = "0, 1, 0, 1 :";
            Result = RunMilton(a);
            u = v + 1d / 4d * Result;
            Console.WriteLine("ss: {0}, u: {1}", ss, u);
            DoneMilton();

            n[1] = 3;
            n[2] = 2;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 0;
            a[3] = 0;
            a[4] = 1;
            a[5] = 1;
            ss = "0, 0, 0, 1, 1 :";
            Result = RunMilton(a);
            w = Result;
            Console.WriteLine("ss: {0}, w1: {1}", ss, w);
            DoneMilton();

            n[1] = 3;
            n[2] = 2;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            a[4] = 0;
            a[5] = 1;
            ss = "0, 0, 1, 0, 1 :";
            Result = RunMilton(a);
            w = w + 1d / 3d * Result;
            Console.WriteLine("ss: {0}, w: {1}", ss, w);
            DoneMilton();

            n[1] = 3;
            n[2] = 2;
            InitMilton(GroupAnz, ref n);
            a[1] = 0;
            a[2] = 1;
            a[3] = 0;
            a[4] = 0;
            a[5] = 1;
            ss = "0, 1, 0, 0, 1 :";
            Result = RunMilton(a);
            y = w + 1d / 6d * Result;
            Console.WriteLine("ss: {0}, y: {1}", ss, y);
            DoneMilton();
        }



        public static void cU(double TargetU, string ParName, double ParValue, double p, double q, double s, double u, double v, double a, double w, double y)
        {
            double d;
            double d2;
            double D3;
            double D4;
            double D5;
            d = 1d - Math.Sqrt(1d + 2d * (0.5d - TargetU));
            ParName = "D";
            ParValue = d;
            // D = -1 / 3
            d2 = d * d;
            D3 = d2 * d;
            D4 = D3 * d;
            D5 = D4 * d;
            p = 1d / 2d + d - d2 / 2d;
            q = 1d / 3d + d - D3 / 3d;
            s = 1d / 4d + d - D4 / 4d;
            a = 1d / 5d + d - D5 / 5d;
            u = 5d / 24d + 5d / 6d * d + 3d / 4d * d2 - 5d / 6d * D3 + 1d / 24d * D4;
            v = 1d / 6d + 2d / 3d * d + d2 - 2d / 3d * D3 - 1d / 6d * D4;
            w = 2d / 15d + 2d / 3d * d + d2 - D3 / 3d - 2d / 3d * D4 + D5 / 5d;
            y = 3d / 20d + 3d / 4d * d + 5d / 6d * d2 - 1d / 2d * D3 - 1d / 4d * D4 + 1d / 60d * D5;
        }

        public static void cL(double TargetU, string ParName, double ParValue, double p, double q, double s2, double u, double v, double aa, double w, double y, double r, double t, double b, double x, double z)
        {
            var a = new int[101];
            var s = new int[101];
            var n = new int[102];
            //string ss;
            double Result;
            double k;
            k = TargetU / (1d - TargetU);
            ParName = "k";
            ParValue = k;

            n[1] = 1;
            n[2] = 1;
            a[1] = 0;
            a[2] = 1;
            //ss = "0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            p = Result;
            // Console.WriteLine( ss, "        p", Format(p, "0.00000000000E+000")
            // DoneMilton

            n[1] = 2;
            n[2] = 1; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            //ss = "0, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            q = Result;
            // Console.WriteLine( ss, "        q:", Format(q, "0.00000000000E+000")
            // DoneMilton

            n[1] = 3;
            n[2] = 1; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 0;
            a[3] = 0;
            a[4] = 1;
            //ss = "0, 0, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            s2 = Result;
            // Console.WriteLine( ss, "        s:", Format(S2, "0.00000000000E+000")
            // DoneMilton

            n[1] = 4;
            n[2] = 1; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 0;
            a[3] = 0;
            a[4] = 0;
            a[5] = 1;
            //ss = "0, 0, 0, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            aa = Result;
            // Console.WriteLine( ss, "        a:", Format(aa, "0.00000000000E+000")
            // DoneMilton



            n[1] = 1;
            n[2] = 2; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 1;
            a[3] = 1;
            //ss = "0, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            r = Result;
            // Console.WriteLine( ss, "        r:", Format(r, "0.00000000000E+000")
            // DoneMilton

            n[1] = 1;
            n[2] = 3; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 1;
            a[3] = 1;
            a[4] = 1;
            //ss = "0, 1, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            t = Result;
            // Console.WriteLine( ss, "        t:", Format(T, "0.00000000000E+000")
            // DoneMilton

            n[1] = 1;
            n[2] = 4; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 1;
            a[3] = 1;
            a[4] = 1;
            a[5] = 1;
            //ss = "0, 1, 1, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            b = Result;
            // Console.WriteLine( ss, "        b:", Format(b, "0.00000000000E+000")
            // DoneMilton

            n[1] = 2;
            n[2] = 2; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            a[4] = 1;
            ////ss = "0, 0, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            v = Result;
            // Console.WriteLine( ss, "        v:", Format(v, "0.00000000000E+000")
            // DoneMilton

            n[1] = 2;
            n[2] = 2; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 1;
            a[3] = 0;
            a[4] = 1;
            //ss = "0, 1, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            u = v + 1d / 4d * Result;
            // Console.WriteLine( ss, "       u: ", Format(u, "0.00000000000E+000")
            // DoneMilton

            n[1] = 3;
            n[2] = 2; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 0;
            a[3] = 0;
            a[4] = 1;
            a[5] = 1;
            //ss = "0, 0, 0, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            w = Result;
            // Console.WriteLine( ss, "       w1: ", Format(w, "0.00000000000E+000")
            // DoneMilton

            n[1] = 3;
            n[2] = 2; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            a[4] = 0;
            a[5] = 1;
            //ss = "0, 0, 1, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            w = w + 1d / 3d * Result;
            // Console.WriteLine( ss, "        w:", Format(w, "0.00000000000E+000")
            // DoneMilton

            n[1] = 3;
            n[2] = 2; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 1;
            a[3] = 0;
            a[4] = 0;
            a[5] = 1;
            //ss = "0, 1, 0, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            y = w + 1d / 6d * Result;
            // Console.WriteLine( ss, "       y: ", Format(y, "0.00000000000E+000")
            // DoneMilton


            n[1] = 2;
            n[2] = 3; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            a[4] = 1;
            a[5] = 1;
            //ss = "0, 0, 1, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            x = Result;
            // Console.WriteLine( ss, "       x1: ", Format(x, "0.00000000000E+000")
            // DoneMilton

            n[1] = 2;
            n[2] = 3; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 1;
            a[3] = 0;
            a[4] = 1;
            a[5] = 1;
            //ss = "0, 1, 0, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            x = x + 1d / 3d * Result;
            // Console.WriteLine( ss, "        x:", Format(x, "0.00000000000E+000")
            // DoneMilton

            n[1] = 2;
            n[2] = 3; // :  Call InitMilton(GroupAnz, n())
            a[1] = 0;
            a[2] = 1;
            a[3] = 1;
            a[4] = 0;
            a[5] = 1;
            //ss = "0, 1, 1, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            z = x + 1d / 6d * Result;
            // Console.WriteLine( ss, "       z: ", Format(z, "0.00000000000E+000")
            // DoneMilton



        }

        public static void DemoCalcLehmannRO()
        {
            var a = new int[101];
            var s = new int[101];
            var n = new int[102];
            //int GroupAnz;
            string ss;
            double Result;
            double p;
            double q;
            double r;
            double s2;
            double t;
            double u;
            double v;
            double aa;
            double b;
            double w;
            double x;
            double y;
            double z;

            double k;

            k = 2.3d;
            //int GroupAnz = 2;
            Console.WriteLine("Lehmann Alternatives");

            n[1] = 1;
            n[2] = 1;
            a[1] = 0;
            a[2] = 1;
            ss = "0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            p = Result;
            Console.WriteLine("ss: {0}, p:{1}", ss, p);

            n[1] = 2;
            n[2] = 1;
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            ss = "0, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            q = Result;
            Console.WriteLine("ss: {0}, q:{1}", ss, q);

            n[1] = 3;
            n[2] = 1;
            a[1] = 0;
            a[2] = 0;
            a[3] = 0;
            a[4] = 1;
            ss = "0, 0, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            s2 = Result;
            Console.WriteLine("ss: {0}, s2:{1}", ss, s2);

            n[1] = 4;
            n[2] = 1;
            a[1] = 0;
            a[2] = 0;
            a[3] = 0;
            a[4] = 0;
            a[5] = 1;
            ss = "0, 0, 0, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            aa = Result;
            Console.WriteLine("ss: {0}, aa:{1}", ss, aa);



            n[1] = 1;
            n[2] = 2;
            a[1] = 0;
            a[2] = 1;
            a[3] = 1;
            ss = "0, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            r = Result;
            Console.WriteLine("ss: {0}, r:{1}", ss, r);

            n[1] = 1;
            n[2] = 3;
            a[1] = 0;
            a[2] = 1;
            a[3] = 1;
            a[4] = 1;
            ss = "0, 1, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            t = Result;
            Console.WriteLine("ss: {0}, t:{1}", ss, t);

            n[1] = 1;
            n[2] = 4;
            a[1] = 0;
            a[2] = 1;
            a[3] = 1;
            a[4] = 1;
            a[5] = 1;
            ss = "0, 1, 1, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            b = Result;
            Console.WriteLine("ss: {0}, b:{1}", ss, b);

            n[1] = 2;
            n[2] = 2;
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            a[4] = 1;
            ss = "0, 0, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            v = Result;
            Console.WriteLine("ss: {0}, v:{1}", ss, v);

            n[1] = 2;
            n[2] = 2;
            a[1] = 0;
            a[2] = 1;
            a[3] = 0;
            a[4] = 1;
            ss = "0, 1, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            u = v + 1d / 4d * Result;
            Console.WriteLine("ss: {0}, u:{1}", ss, u);

            n[1] = 3;
            n[2] = 2;
            a[1] = 0;
            a[2] = 0;
            a[3] = 0;
            a[4] = 1;
            a[5] = 1;
            ss = "0, 0, 0, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            w = Result;
            Console.WriteLine("ss: {0}, w1:{1}", ss, w);

            n[1] = 3;
            n[2] = 2;
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            a[4] = 0;
            a[5] = 1;
            ss = "0, 0, 1, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            w = w + 1d / 3d * Result;
            Console.WriteLine("ss: {0}, w:{1}", ss, w);

            n[1] = 3;
            n[2] = 2;
            a[1] = 0;
            a[2] = 1;
            a[3] = 0;
            a[4] = 0;
            a[5] = 1;
            ss = "0, 1, 0, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            y = w + 1d / 6d * Result;
            Console.WriteLine("ss: {0}, y:{1}", ss, y);


            n[1] = 2;
            n[2] = 3;
            a[1] = 0;
            a[2] = 0;
            a[3] = 1;
            a[4] = 1;
            a[5] = 1;
            ss = "0, 0, 1, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            x = Result;
            Console.WriteLine("ss: {0}, x1:{1}", ss, x);

            n[1] = 2;
            n[2] = 3;
            a[1] = 0;
            a[2] = 1;
            a[3] = 0;
            a[4] = 1;
            a[5] = 1;
            ss = "0, 1, 0, 1, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            x = x + 1d / 3d * Result;
            Console.WriteLine("ss: {0}, x:{1}", ss, x);

            n[1] = 2;
            n[2] = 3;
            a[1] = 0;
            a[2] = 1;
            a[3] = 1;
            a[4] = 0;
            a[5] = 1;
            ss = "0, 1, 1, 0, 1 :";
            A2S(a, s, n[1], n[2]);
            Result = LehmannRO(s, n[1], n[2], k);
            z = x + 1d / 6d * Result;
            Console.WriteLine("ss: {0}, z:{1}", ss, z);


        }



        public static void A2S(int[] a, int[] s, int m, int n)
        {
            int i;
            int j;
            j = 0;
            var loopTo = m + n;
            for (i = 1; i <= loopTo; i++)
            {
                if (a[i] == 1)
                {
                    j = j + 1;
                    s[j] = i;
                }
            }
        }

        public static double LehmannRO(int[] s, int m, int n, double k)
        {
            double lnFaktor;
            double lnProd;
            int j;
            lnFaktor = Math.Log(k) * n + DistMain.LnGamma(n + 1) + DistMain.LnGamma(m + 1) - DistMain.LnGamma(n + m + 1 + n * (k - 1d));
            lnProd = 0d;
            var loopTo = n;
            for (j = 1; j <= loopTo; j++)
                lnProd = lnProd + DistMain.LnGamma(s[j] + j * (k - 1d)) - DistMain.LnGamma(s[j] + (j - 1) * (k - 1d));
            return Math.Exp(lnFaktor + lnProd);
        }

        public static double ExtremeValue(double TargetU, int m, int n, int ind)
        {
            double ExtremeValueRet = default;
            int i;
            double k;
            double Result;
            int[] a;
            int[] s;
            a = new int[m + n + 1];
            s = new int[m + n + 1];
            k = TargetU / (1d - TargetU);
            var loopTo = m;
            for (i = 1; i <= loopTo; i++)
                a[i] = Math.Abs(0 - ind);
            var loopTo1 = m + n;
            for (i = m + 1; i <= loopTo1; i++)
                a[i] = 1 - ind;
            A2S(a, s, m, n);
            // For i = 1 To m + n
            // Console.WriteLine( i, a(i), s(i)
            // Next i
            Result = LehmannRO(s, m, n, k);
            Console.WriteLine("Result: {0}", Result);
            ExtremeValueRet = Result;
            return ExtremeValueRet;
        }

        public static void LehmanndemoNew()
        {
            double pcum2;
            var a = new int[101];
            var s = new int[101];
            var n = new int[102];
            var pcum = new double[101];
            var p = new int[101];
            var id = new int[101];
            int GroupAnz;
            int Index;
            int x;
            int y;
            int temp;
            int k;
            int u;
            int i1;
            int i2;
            int csum;
            int count;
            bool done;
            int icount2;
            string ss;
            double Result;
            int nmin;
            double kValue;
            // IsNormal = True
            GroupAnz = 3; // (*zahl der gruppen mit verschiedenen werten*)
            kValue = 8d;
            n[1] = 2; // (*gruppenstaerken*)
            n[2] = 2;
            n[3] = 1;
            n[4] = 1;
            n[5] = 1;
            n[6] = 1;
            // delta(1) = 0
            // delta(2) = -1.2
            // delta(3) = 3
            // delta(4) = 2.5
            // delta(5) = 2.5
            // delta(6) = 2.5
            var loopTo = GroupAnz;
            for (i1 = 1; i1 <= loopTo; i1++)
                id[i1] = i1 - 1; // (*werte der gruppen*)
                                 // Call InitMilton(GroupAnz, n())

            csum = 0;
            count = 0;
            var loopTo1 = GroupAnz;
            for (i1 = 1; i1 <= loopTo1; i1++)
            {
                csum = csum + n[i1];
                var loopTo2 = n[i1];
                for (i2 = 1; i2 <= loopTo2; i2++)
                {
                    count = count + 1;
                    a[count] = id[i1];
                    p[count] = GroupAnz - i1 + 1;
                }
            }

            icount2 = 1;
            x = 1;
            y = 2;
            k = GroupAnz;
            u = csum + 1;
            done = false;
            p[0] = GroupAnz + 1;
            p[u] = GroupAnz + 1;

            while (!done)
            {
                ss = Strings.Format(icount2, "#00") + ": ";
                Index = 0;
                var loopTo3 = csum;
                for (i1 = 1; i1 <= loopTo3; i1++)
                {
                    ss = ss + Conversion.Str(a[i1]);
                    if (a[i1] == 0)
                        Index = Index + i1;
                }
                A2S(a, s, n[1], n[2]);
                Result = LehmannRO(s, n[1], n[2], kValue);
                pcum[Index] = pcum[Index] + Result;

                // result = RunMilton(a)
                Console.WriteLine("ss: {0}, Index: {1}, Result: {2}", ss, Index, Result);

                // Console.WriteLine( ss, "        ", Format(Result, "Scientific")
                Chase2(ref x, ref y, k, u, ref done, ref p);
                temp = a[x];
                a[x] = a[y];
                a[y] = temp;
                icount2 = icount2 + 1;
            }

            // DoneMilton

            nmin = n[1] * (n[1] + 1) / 2;
            Console.WriteLine("Verteilung");
            pcum2 = 0d;
            var loopTo4 = nmin + n[1] * n[2];
            for (Index = nmin; Index <= loopTo4; Index++)
            {
                pcum2 = pcum2 + pcum[Index];
                Console.WriteLine("Index: {0}, pcum(Index): {1}, pcum2: {2}", Index, pcum[Index], pcum2);
            }
        }



        public static void LehmannDemoRecursive()
        {
            double kValue;
            double[] pprob;
            int N1;
            int n2;
            var panz = default(int);
            int i;
            double p;
            double pcum;
            kValue = 2d;
            N1 = 8;
            n2 = 8;
            pprob = new double[2];
            CalcMWLehmann(kValue, N1, n2, ref panz, ref pprob);

            Console.WriteLine("Final Result");
            pcum = 0d;
            var loopTo = panz;
            for (i = 0; i <= loopTo; i++)
            {
                p = pprob[i];
                pcum = pcum + p;
                Console.WriteLine("i: {0}, p: {1}, pcum: {2}, 1 - pcum: {3}", i, p, pcum, 1d - pcum);
            }
        }

        // Recursive algorithm for Lehmann alternatives for the Mann-Whitney test
        public static void CalcMWLehmann(double kValue, int N1, int n2, ref int panz, ref double[] pprob)
        {
            int[] Rank;
            int[] n;
            int j;
            int m;
            int ng;
            double[,,] xvec;
            int i; // , p As Double, pcum As Double
            m = 1;
            n = new int[m + 1];
            n[0] = N1;
            n[1] = n2;
            ng = 0;
            var loopTo = m;
            for (j = 0; j <= loopTo; j++)
                ng = ng + n[j];

            Rank = new int[ng + 1 + 1];
            var loopTo1 = ng;
            for (j = 0; j <= loopTo1; j++)
                Rank[j] = j;
            xvec = new double[2, 2, 2];
            CalcRankSums(kValue, ref xvec, ref m, ref ng, ref n, ref Rank);
            panz = n[0] * n[1];
            pprob = new double[panz + 1];
            var loopTo2 = panz;
            for (i = 0; i <= loopTo2; i++)
                pprob[panz - i] = xvec[0, 0, i];
            xvec = null;
        }

        public static void CalcRankSums(double kValue, ref double[,,] xvec, ref int m, ref int ng, ref int[] n, ref int[] Rank)
        {
            var AddPos = new int[11];
            var w = new int[11];
            var CurNum = new int[11];
            int[,] z;
            int[] zlength;
            int[] ztemp;
            int[] Last;
            bool first;
            bool EQ;
            bool LE;
            int CurNumCount;
            int zmax;
            int h;
            int k2;
            int i;
            int j;
            int k;
            int l;
            int j2;
            int k3;
            int zul;
            int r;
            int k1;
            int i1;
            int i2;
            //int msize;
            int vref;
            //int w1;
            //int j1;
            int q;
            int m1;
            int CurrentNumber;
            int Lastj;
            int xstart;
            bool calc;
            bool showstruc; // , showvec As Boolean
            string s2;

            calc = true;
            showstruc = false; // : showvec = False
            h = m - 1;
            m1 = m + 1;
            zlength = new int[ng + 1 + 1];
            zul = 1000;
            if (m == 1)
            {
                if (n[0] < n[1])
                    zul = n[0] * (m1 + 1);
                else
                    zul = n[1] * (m1 + 1);
            }
            ztemp = new int[zul + 1];
            Last = new int[zul + 1];
            z = new int[ng + 1 + 1, zul + 1];

            var loopTo = m;
            for (j = 0; j <= loopTo; j++)
                w[j] = n[j];

            var loopTo1 = m;
            for (j = 0; j <= loopTo1; j++)
                n[j] = w[j];
            var loopTo2 = m;
            for (k = 0; k <= loopTo2; k++)
                z[ng, k] = w[k];
            zlength[ng] = 0;

            zmax = 0;
            for (i = ng - 1; i >= 0; i -= 1)
            {
                i1 = i + 1;
                first = true;
                var loopTo3 = zlength[i1];
                for (j = 0; j <= loopTo3; j++)
                {
                    var loopTo4 = m;
                    for (k2 = 0; k2 <= loopTo4; k2++)
                    {
                        if (z[i1, j * m1 + k2] > 0)
                        {
                            var loopTo5 = m;
                            for (k1 = 0; k1 <= loopTo5; k1++)
                                w[k1] = z[i1, j * m1 + k1];
                            w[k2] = w[k2] - 1;
                            if (first)
                            {
                                first = false;
                                zlength[i] = 0;
                                var loopTo6 = m;
                                for (k = 0; k <= loopTo6; k++)
                                    ztemp[k] = w[k];
                            }
                            else
                            {
                                l = 0;
                                r = zlength[i];
                                do
                                {
                                    q = (l + r + 1) / 2;
                                    k = -1;
                                    do
                                    {
                                        k = k + 1;
                                        vref = ztemp[q * m1 + k];
                                        EQ = vref == w[k];
                                    }
                                    while (k < h & EQ);
                                    LE = vref <= w[k];
                                    if (LE)
                                        l = q;
                                    else
                                        r = q - 1;
                                }
                                while (l != r);
                                k = 0;
                                while (ztemp[l * m1 + k] == w[k] & k <= h)
                                    k = k + 1;
                                if (k < m)
                                {
                                    zlength[i] = zlength[i] + 1;
                                    l = l + 1;
                                    if (zlength[i] != l)
                                    {
                                        for (i2 = zlength[i]; i2 >= 0; i2 -= 1)
                                        {
                                            var loopTo7 = m;
                                            for (k = 0; k <= loopTo7; k++)
                                                ztemp[(i2 + 1) * m1 + k] = ztemp[i2 * m1 + k];
                                        }
                                    }
                                    var loopTo8 = m;
                                    for (k = 0; k <= loopTo8; k++)
                                        ztemp[l * m1 + k] = w[k];
                                }
                            }
                        } // (*if w(k)-1>0*)
                    }
                }

                var loopTo9 = (zlength[i] + 1) * m1 - 1;
                for (j = 0; j <= loopTo9; j++)
                    z[i, j] = ztemp[j];
                if (zlength[i] > zmax)
                    zmax = zlength[i];
            }

            // {Calculate the Vectors}
            s2 = "";
            xvec = new double[2, zmax + 1, n[0] * n[1] + 1];
            xvec[0, 0, 0] = 1d;
            xstart = ng % 2;
            var loopTo10 = ng;
            for (i = 1; i <= loopTo10; i++)
            {
                if (calc)
                {
                    if (xstart == 1)
                        xstart = 0;
                    else
                        xstart = 1;
                }

                i1 = i - 1;
                var loopTo11 = (zlength[i1] + 1) * m1;
                for (j = 0; j <= loopTo11; j++)
                    Last[j] = z[i1, j];
                Lastj = zlength[i1];
                if (showstruc)
                    Console.WriteLine(Conversion.Str(i) + ". Iteration");

                var loopTo12 = zlength[i];
                for (j = 0; j <= loopTo12; j++)
                {
                    if (showstruc)
                    {
                        s2 = Conversion.Str(j) + ". Vector";
                        var loopTo13 = m;
                        for (k = 0; k <= loopTo13; k++)
                            s2 = s2 + Conversion.Str(z[i, j * m1 + k]);
                        s2 = s2 + "  :";
                    }
                    CurNumCount = -1;
                    var loopTo14 = m;
                    for (k = 0; k <= loopTo14; k++)
                    {
                        if (z[i, j * m1 + k] > 0)
                        {
                            var loopTo15 = m;
                            for (k1 = 0; k1 <= loopTo15; k1++)
                                w[k1] = z[i, j * m1 + k1];
                            w[k] = w[k] - 1;
                            if (showstruc)
                            {
                                var loopTo16 = m;
                                for (k1 = 0; k1 <= loopTo16; k1++)
                                {
                                    s2 = s2 + Conversion.Str(w[k1]);
                                    if (k == k1)
                                        s2 = s2 + "+";
                                }
                            }

                            j2 = -1;
                            do
                            {
                                j2 = j2 + 1;
                                k3 = -1;
                                do
                                {
                                    k3 = k3 + 1;
                                    EQ = w[k3] == Last[j2 * m1 + k3];
                                }
                                while (EQ & k3 < m);
                            }
                            while (!(EQ | j2 == Lastj));
                            CurrentNumber = j2;

                            if (!EQ)
                                CurrentNumber = CurrentNumber + 1;
                            CurNumCount = CurNumCount + 1;
                            CurNum[CurNumCount] = CurrentNumber;
                            AddPos[CurNumCount] = k;
                            if (showstruc)
                            {
                                s2 = s2 + " (" + Conversion.Str(CurNum[CurNumCount]) + "; " + Conversion.Str(AddPos[CurNumCount]) + ")";
                                s2 = s2 + ", ";
                            }
                        }
                    }
                    if (showstruc)
                        Console.WriteLine(s2);
                    if (calc)
                        BuildMWVector(xvec, xstart, kValue, z[i, j * m1], z[i, j * m1 + 1], j, CurNum[0], CurNum[1]);
                }
            }
            zlength = null;
            Last = null;
            z = null;
            ztemp = null;
        }

        public static void BuildMWVector(double[,,] xvec, int xstart, double k, int n, int m, int Target, int Source1, int Source2)
        {

            double f1;
            double f2;
            //double pcum;
            var i = default(int);
            int ystart;
            //double p;
            if (xstart == 1)
                ystart = 0;
            else
                ystart = 1;
            if (n == 0 | m == 0)
            {
                xvec[xstart, Target, i] = 1d;
                return;
            }
            f1 = n / (k * m + n);
            f2 = k * m / (k * m + n);
            var loopTo = n * m;
            for (i = 0; i <= loopTo; i++)
                xvec[xstart, Target, i] = 0d;
            if (f2 > 0d)
            {
                var loopTo1 = n * (m - 1);
                for (i = 0; i <= loopTo1; i++)
                    xvec[xstart, Target, i] = xvec[xstart, Target, i] + f2 * xvec[ystart, Source2, i];
            }
            if (f1 > 0d)
            {
                var loopTo2 = m * n;
                for (i = m; i <= loopTo2; i++)
                    xvec[xstart, Target, i] = xvec[xstart, Target, i] + f1 * xvec[ystart, Source1, i - m];
            }
        }


        // *************************************************************************************************************
        // *************************************************************************************************************


        public static void EstimateRankOrders2(int m, int n, ref double[] u)
        {
            int i;
            //int j;
            double m1;
            double m2;
            double m3;
            double N1;
            double n2;
            double n3;
            double mn;
            //double Uj;
            double P11;
            double P21;
            double P31;
            double P41;
            double P12;
            double P13;
            double P14;
            double P22;
            double P32;
            double P23;
            double P22j1;
            double P32j1;
            double P32j2;
            double P23j1;
            double P23j2;
            double U11;
            double U21;
            double U31;
            double U41;
            double U12;
            double U13;
            double U14;
            double U22;
            double U32;
            double U23;
            double U22j1; // , U32j1 As Double, U32j2 As Double
            double U23j1;
            double U23j2;
            // Dim p As Double, q As Double, r As Double, s As Double, t As Double, uu As Double, vv As Double
            // Dim a As Double, b As Double, ww As Double, x As Double, y As Double, z As Double

            double[] v;
            double[] w;
            double[] v2;
            double[] vs;
            v = new double[m + 1];
            w = new double[m + 1];
            v2 = new double[m + 1];
            vs = new double[m + 1];
            Console.WriteLine("Fast");

            v[1] = u[1];
            var loopTo = m;
            for (i = 2; i <= loopTo; i++)
                v[i] = v[i - 1] + u[i];
            vs[1] = v[1];
            var loopTo1 = m;
            for (i = 2; i <= loopTo1; i++)
                vs[i] = vs[i - 1] + v[i];
            v2[1] = 1.0d * u[1] * u[1];
            var loopTo2 = m;
            for (i = 2; i <= loopTo2; i++)
                v2[i] = v2[i - 1] + 1.0d * u[i] * u[i];
            w[m] = u[m];
            for (i = m - 1; i >= 1; i -= 1)
                w[i] = w[i + 1] + u[i];

            P11 = 0d;
            P21 = 0d;
            P31 = 0d;
            P41 = 0d;
            P12 = 0d;
            P13 = 0d;
            P14 = 0d;
            P22 = 0d;
            P32 = 0d;
            P23 = 0d;
            P22j1 = 0d;
            P32j1 = 0d;
            P32j2 = 0d;
            P23j1 = 0d;
            P23j2 = 0d;
            var loopTo3 = m;
            for (i = 1; i <= loopTo3; i++)
            {
                U11 = u[i];
                U21 = U11 * (i - 1);
                U31 = U21 * (i - 2);
                U41 = U31 * (i - 3);
                U12 = U11 * (U11 - 1d);
                U13 = U12 * (U11 - 2d);
                U14 = U13 * (U11 - 3d);
                U22 = U12 * (i - 1);
                U32 = U22 * (i - 2);
                U23 = U13 * (i - 1);
                P11 = P11 + U11;
                P21 = P21 + U21;
                P31 = P31 + U31;
                P41 = P41 + U41;
                P12 = P12 + U12;
                P13 = P13 + U13;
                P14 = P14 + U14;
                P22 = P22 + U22;
                P32 = P32 + U32;
                P23 = P23 + U23;
            }
            var loopTo4 = m;
            for (i = 2; i <= loopTo4; i++)
            {
                U22j1 = u[i] * (v[i - 1] - u[i] * (i - 1));
                U23j1 = U22j1 * (u[i] - 1.0d);
                U23j2 = v2[i - 1] - v[i - 1] * u[i];
                P22j1 = P22j1 + U22j1;
                P23j1 = P23j1 + U23j1;
                P23j2 = P23j2 + u[i] * (U23j2 - U22j1) - U22j1;
            }
            var loopTo5 = m - 1;
            for (i = 2; i <= loopTo5; i++)
            {
                P32j1 = P32j1 + (u[i] * w[i + 1] - 0.5d * i * u[i + 1] * u[i + 1]) * (i - 1);
                P32j2 = P32j2 + u[i + 1] * (vs[i - 1] - 0.5d * i * (i - 1) * u[i + 1]);
            }
            mn = 1.0d * m * n;
            m1 = m - 1;
            m2 = m - 2;
            m3 = m - 3;
            N1 = n - 1;
            n2 = n - 2;
            n3 = n - 3;
            P11 = P11 / mn;
            P21 = 2d * P21 / (mn * m1);
            P31 = 3d * P31 / (mn * m1 * m2);
            P41 = 4d * P41 / (mn * m1 * m2 * m3);
            P12 = P12 / (mn * N1);
            P13 = P13 / (mn * N1 * n2);
            P14 = P14 / (mn * N1 * n2 * n3);
            P22 = 2d * P22 / (mn * m1 * N1);
            P32 = 3d * P32 / (mn * m1 * m2 * N1);
            P23 = 2d * P23 / (mn * m1 * N1 * n2);
            P22j1 = 4d * P22j1 / (mn * m1 * N1);
            P32j1 = 12d * P32j1 / (mn * m1 * m2 * N1);
            P32j2 = 6d * P32j2 / (mn * m1 * m2 * N1);
            P23j1 = 6d * P23j1 / (mn * m1 * N1 * n2);
            P23j2 = 6d * P23j2 / (mn * m1 * N1 * n2);
            Console.WriteLine("P11:  {0}", P11);
            Console.WriteLine("P21:  {0}", P21);
            Console.WriteLine("P31:  {0}", P31);
            Console.WriteLine("P41:  {0}", P41);
            Console.WriteLine("P12:  {0}", P12);
            Console.WriteLine("P13:  {0}", P13);
            Console.WriteLine("P14:  {0}", P14);
            Console.WriteLine("P22:  {0}", P22);
            Console.WriteLine("P32:  {0}", P32);
            Console.WriteLine("P23:  {0}", P23);
            Console.WriteLine("P22j1:  {0}", P22j1);
            Console.WriteLine("P32j1:  {0}", P32j1);
            Console.WriteLine("P32j2:  {0}", P32j2);
            Console.WriteLine("P23j1:  {0}", P23j1);
            Console.WriteLine("P23j2:  {0}", P23j2);
            // 
            // p = P11
            // q = P12
            // s = P13
            // a = P14
            // vv = P22
            // uu = vv + (1 / 4) * P22j1
            // ww = P32 + (1 / 3) * P32j1
            // y = ww + (1 / 6) * P32j2
            // r = P21
            // t = P31
            // b = P41
            // x = P23 + (1 / 3) * P23j1
            // z = x + (1 / 6) * P23j2
            // Console.WriteLine( "p: ", p
            // Console.WriteLine( "q: ", s
            // Console.WriteLine( "s: ", s
            // Console.WriteLine( "a: ", a
            // Console.WriteLine( "u: ", uu
            // Console.WriteLine( "v: ", vv
            // Console.WriteLine( "w: ", ww
            // Console.WriteLine( "y: ", y
            // Console.WriteLine( "r: ", r
            // Console.WriteLine( "t: ", t
            // Console.WriteLine( "b: ", b
            // Console.WriteLine( "x: ", x
            // Console.WriteLine( "z: ", z

        }





        public static void FillData(int NStart, int Nstop, ref double[] a, ref int[] Ranks, double d)
        {
            int i;
            //int j;
            // ReDim a(n): ReDim Ranks(n)

            var loopTo = Nstop;
            for (i = NStart; i <= loopTo; i++)
            {
                Ranks[i] = i;
                a[i] = (double)VBMath.Rnd() + d;
            }
        }

        public static void ShowData(int n, ref double[] a, ref int[] Ranks)
        {
            int i;
            var loopTo = n;
            for (i = 0; i <= loopTo; i++)
                Console.WriteLine(" i: {0}, Ranks(i) {1}, a(i) {2}", i, Ranks[i], a[i]);
        }


        private static void InsertSort(ref double[] a, ref int Lb, ref int Ub)
        {
            int i;
            int j;
            double x;
            var loopTo = Ub;
            for (i = Lb + 1; i <= loopTo; i++)
            {
                x = a[i];
                var loopTo1 = Lb;
                for (j = i - 1; j >= loopTo1; j -= 1)
                {
                    if (!(x < a[j]))
                        break;
                    a[j + 1] = a[j];
                }
                a[j + 1] = x;
            }
        }


        public static void InsertSortRanks(ref double[] a, ref int[] Rank, ref int Lb, ref int Ub)
        {
            int i;
            int j;
            double x;
            int u;
            var loopTo = Ub;
            for (i = Lb + 1; i <= loopTo; i++)
            {
                x = a[i];
                u = Rank[i];
                var loopTo1 = Lb;
                for (j = i - 1; j >= loopTo1; j -= 1)
                {
                    if (!(x < a[j]))
                        break;
                    a[j + 1] = a[j];
                    Rank[j + 1] = Rank[j];
                }
                a[j + 1] = x;
                Rank[j + 1] = u;
            }
        }


        public static void SortRanks2(ref double[] a, ref int[] Rank, int Lb, int Ub, int m, bool MedianOf3)
        {
            int i;
            int j;
            int l;
            int r;
            int s;
            double x;
            double w;
            int u;
            var sl = new int[65];
            var sr = new int[65];
            var v = new double[4];
            // Dim smax As Integer
            // If IsMissing(m) Then m = 10
            // If IsMissing(MedianOf3) Then MedianOf3 = True

            s = 1;
            sl[1] = Lb;
            sr[1] = Ub;
            do
            {
                l = sl[s];
                r = sr[s];
                s = s - 1;
                if (r - l <= m)
                {
                    InsertSortRanks(ref a, ref Rank, ref l, ref r);
                }
                else
                {
                    do
                    {
                        i = l;
                        j = r;
                        x = a[(l + r) / 2];
                        if (MedianOf3)
                        {
                            v[1] = a[l];
                            v[2] = x;
                            v[3] = a[r];
                            int argLb = 1;
                            int argUb = 3;
                            InsertSort(ref v, ref argLb, ref argUb);
                            x = v[2];
                        }
                        do
                        {
                            while (a[i] < x)
                                i = i + 1;
                            while (x < a[j])
                                j = j - 1;
                            if (i <= j)
                            {
                                w = a[i];
                                a[i] = a[j];
                                a[j] = w;
                                u = Rank[i];
                                Rank[i] = Rank[j];
                                Rank[j] = u;
                                i = i + 1;
                                j = j - 1;
                            }
                        }
                        while (i <= j);
                        if (j - l < r - i)
                        {
                            if (i < r)
                            {
                                s = s + 1;
                                sl[s] = i;
                                sr[s] = r;
                            }
                            r = j;
                        }
                        else
                        {
                            if (l < j)
                            {
                                s = s + 1;
                                sl[s] = l;
                                sr[s] = j;
                            }
                            l = i;
                        }
                    }
                    while (l < r);
                }
            }
            while (s != 0);
        }


        public static void DemoSampleEstRO()
        {
            int n;
            double[] a;
            int[] ar;
            double d;
            //int k;
            int j;
            int ysum;
            int i;
            int N1;
            int n2;
            double[] u;
            N1 = 1000;
            n2 = 1000;
            d = 0d;
            n = N1 + n2 - 1;
            u = new double[N1 + 1 + 1];
            a = new double[n + 1];
            ar = new int[n + 1];
            d = 0d;
            FillData(0, N1 - 1, ref a, ref ar, d);
            d = 0d;
            FillData(N1, n, ref a, ref ar, d);
            Console.WriteLine("Sorting");
            SortRanks2(ref a, ref ar, 0, n, 10, true);
            // Call SortRanksStats(a, ar, 0, n, 10)
            // Call ShowData(n, a, ar)
            Console.WriteLine("Calculating U");
            ysum = 0;
            j = 0;
            var loopTo = n;
            for (i = 0; i <= loopTo; i++)
            {
                if (ar[i] > N1 - 1)
                {
                    ysum = ysum + 1;
                }
                else
                {
                    j = j + 1;
                    u[j] = n2 - ysum;
                }
            }
            // For i = 1 To n1
            // Console.WriteLine( i, U(i)
            // Next i
            // Call EstimateRankOrders(n1, n2, U())
            Console.WriteLine("--------Rank Orders---------------");
            EstimateRankOrders2(N1, n2, ref u);
        }

        public static void CalcUniformRO(double d)
        {
            double d2;
            double D3;
            double D4;
            double D5;
            double p;
            double q;
            double r;
            double s;
            double t;
            double u;
            double v;
            double a;
            double b;
            double w;
            double x;
            double y;
            double z;
            d2 = d * d;
            D3 = d2 * d;
            D4 = D3 * d;
            D5 = D4 * d;
            p = 1d / 2d + d - d2 / 2d;
            q = 1d / 3d + d - D3 / 3d;
            s = 1d / 4d + d - D4 / 4d;
            a = 1d / 5d + d - D5 / 5d;
            u = 5d / 24d + 5d / 6d * d + 3d / 4d * d2 - 5d / 6d * D3 + 1d / 24d * D4;
            v = 1d / 6d + 2d / 3d * d + d2 - 2d / 3d * D3 - 1d / 6d * D4;
            w = 2d / 15d + 2d / 3d * d + d2 - D3 / 3d - 2d / 3d * D4 + D5 / 5d;
            y = 3d / 20d + 3d / 4d * d + 5d / 6d * d2 - 1d / 2d * D3 - 1d / 4d * D4 + 1d / 60d * D5;
            r = q;
            t = s;
            b = a;
            x = w;
            z = y;
            Console.WriteLine("p:  {0}", p);
            Console.WriteLine("q:  {0}", s);
            Console.WriteLine("s:  {0}", s);
            Console.WriteLine("a:  {0}", a);
            Console.WriteLine("u:  {0}", u);
            Console.WriteLine("v:  {0}", v);
            Console.WriteLine("w:  {0}", w);
            Console.WriteLine("y:  {0}", y);
            Console.WriteLine("r:  {0}", r);
            Console.WriteLine("t:  {0}", t);
            Console.WriteLine("b:  {0}", b);
            Console.WriteLine("x:  {0}", x);
            Console.WriteLine("z:  {0}", z);
        }

        public static void DemoUniformEstRO()
        {
            double d;
            d = 0.2d;
            Console.WriteLine("Uniform for D = {0}", d);
            CalcUniformRO(d);
        }


        public static void MW_Moments(int dis, double TargetU, int n, int m, double mu1, double sigma, double g1, double g2, double LXV, double RXV)
        {
            var p = default(double);
            var q = default(double);
            var s = default(double);
            var u = default(double);
            var v = default(double);
            var a = default(double);
            var w = default(double);
            var y = default(double);
            var r = default(double);
            var t = default(double);
            var b = default(double);
            var x = default(double);
            var z = default(double);
            double p2;
            double p3;
            double p4;
            double n2;
            double n3;
            double n4;
            double m2;
            double m3;
            double m4;
            double q2;
            double r2;
            double mu2;
            double mu3;
            double mu4;
            double temp;
            var ParValue = default(double);
            string ParName;
            bool SmallTarget;
            // Dis: 0=null, 1=normal, 2=logistic, 3=uniform, 4=lehmann
            if (TargetU < 0.5d)
            {
                TargetU = 1d - TargetU;
                SmallTarget = true;
            }
            else
            {
                SmallTarget = false;
            }
            ParName = "";
            switch (dis)
            {
                case 0:
                    {
                        p = 0.5d;
                        q = 1d / 3d;
                        s = 0.25d;
                        u = 1d / 4.8d;
                        v = 1d / 6d;
                        a = 0.2d;
                        w = 2d / 15d;
                        y = 0.15d;
                        break;
                    }
                case 1:
                    {
                        cn(true, TargetU, ParName, ParValue, p, q, s, u, v, a, w, y);
                        break;
                    }
                case 2:
                    {
                        cn(false, TargetU, ParName, ParValue, p, q, s, u, v, a, w, y);
                        break;
                    }
                case 3:
                    {
                        cU(TargetU, ParName, ParValue, p, q, s, u, v, a, w, y);
                        break;
                    }
                case 4:
                    {
                        cL(TargetU, ParName, ParValue, p, q, s, u, v, a, w, y, r, t, b, x, z);
                        break;
                    }
            }
            if (dis <= 3)
            {
                r = q;
                t = s;
                b = a;
                x = w;
                z = y;
            }
            Console.WriteLine("ParName: {0}, ParValue: {1}", ParName, ParValue);
            n2 = n * n;
            n3 = n2 * n;
            n4 = n3 * n;
            m2 = m * m;
            m3 = m2 * m;
            m4 = m3 * m;
            p2 = p * p;
            p3 = p2 * p;
            p4 = p3 * p;
            q2 = q * q;
            r2 = r * r;
            if (SmallTarget)
                mu1 = m * n * (1d - p);
            else
                mu1 = m * n * p;
            // mu2 to mu4 are central moments
            mu2 = m * n * (p - p2 + (m - 1) * (q - p2) + (n - 1) * (r - p2));
            mu3 = (6d * p3 + 6d * u - 6d * p * q - 6d * p * r) * m2 * n2 + (2d * p3 + s - 3d * p * q) * m3 * n + (2d * p3 + t - 3d * p * r) * m * n3 + (9d * p * q + 6d * p * r + 3d * q - 3d * s - 6d * u - 3d * p2 - 6d * p3) * m2 * n + (9d * p * r + 6d * p * q + 3d * r - 3d * t - 6d * u - 3d * p2 - 6d * p3) * m * n2 + (4d * p3 + 3d * p2 + p + 6d * u + 2d * s + 2d * t - 6d * p * q - 6d * p * r - 3d * q - 3d * r) * m * n;



            mu4 = 3d * Math.Pow(q - p2, 2d) * m4 * n2 + 6d * (q - p2) * (r - p2) * m3 * n3 + 3d * Math.Pow(r - p2, 2d) * m2 * n4 + (12d * q * p2 + a - 4d * s * p - 3d * q2 - 6d * p4) * m4 * n + (12d * r * p2 + b - 4d * t * p - 3d * r2 - 6d * p4) * m * n4 + (42d * r * p2 + 72d * q * p2 + 6d * q * p + 12d * w + 12d * y - 42d * p4 - 18d * q2 - 18d * q * r - 12d * s * p - 48d * u * p - 6d * p3) * m3 * n2 + (42d * q * p2 + 72d * r * p2 + 6d * r * p + 12d * x + 12d * z - 42d * p4 - 18d * r2 - 18d * q * r - 12d * t * p - 48d * u * p - 6d * p3) * m2 * n3;



            mu4 = mu4 + (36d * p4 + 18d * q2 + 12d * q * r - 72d * q * p2 - 36d * r * p2 + 24d * s * p - 6d * a + 48d * u * p - 12d * w - 12d * y + 12d * p3 - 18d * q * p + 6d * s) * m3 * n + (36d * p4 + 18d * r2 + 12d * q * r - 72d * r * p2 - 36d * q * p2 + 24d * t * p - 6d * b + 48d * u * p - 12d * x - 12d * z + 12d * p3 - 18d * r * p + 6d * t) * m * n3 + (105d * p4 + 42d * p3 + 3d * p2 + 33d * q2 + 33d * r2 + 54d * q * r - 174d * q * p2 - 174d * r * p2 - 42d * p * q - 42d * p * r + 36d * s * p + 36d * t * p + 192d * u * p - 36d * w - 36d * x - 36d * y - 36d * z + 6d * v + 36d * u) * m2 * n2;



            mu4 = mu4 + (132d * q * p2 + 108d * r * p2 - 66d * p4 - 33d * q2 - 36d * q * r - 18d * r2 - 44d * s * p - 24d * t * p + 11d * a - 144d * u * p + 36d * w + 24d * x + 36d * y + 24d * z - 6d * v - 36d * p3 - 36d * u - 7d * p2 + 54d * p * q + 36d * p * r - 18d * s + 7d * q) * m2 * n + (132d * r * p2 + 108d * q * p2 - 66d * p4 - 33d * r2 - 36d * q * r - 18d * q2 - 44d * t * p - 24d * s * p + 11d * b - 144d * u * p + 24d * w + 36d * x + 24d * y + 36d * z - 6d * v - 36d * p3 - 36d * u - 7d * p2 + 54d * p * r + 36d * p * q - 18d * t + 7d * r) * m * n2;



            mu4 = mu4 + (36d * p4 + 18d * q2 + 24d * q * r + 18d * r2 - 72d * q * p2 - 72d * r * p2 + 24d * s * p + 24d * t * p - 6d * a - 6d * b + 96d * u * p - 24d * w - 24d * x - 24d * y - 24d * z + 6d * v + 24d * p3 + 36d * u + 7d * p2 - 36d * p * q - 36d * p * r + 12d * s + 12d * t - 7d * q - 7d * r + p) * m * n;


            sigma = Math.Sqrt(mu2);
            g1 = mu3 / (mu2 * sigma);
            g2 = mu4 / (mu2 * mu2) - 3d;
            LXV = ExtremeValue(TargetU, m, n, 1);
            RXV = ExtremeValue(TargetU, m, n, 0);
            if (SmallTarget)
            {
                g1 = -g1;
                temp = RXV;
                RXV = LXV;
                LXV = temp;
            }
            Console.WriteLine("Moments from formula");
            Console.WriteLine("mu2: {0}, mu3: {1}, m4: {2}", mu2, mu3, m4);
            Console.WriteLine("g1: {0}, g2: {1}", g1, g2);
        }

        public static double MW_Density(double x, double sigma, double g1, double g2)
        {
            double MW_DensityRet = default;
            var zz = new double[7];
            double density;
            double dsum1;
            double dsum2;
            DistCornish.NdensDeriv(6, x, ref zz);
            dsum1 = -g1 * zz[3] / 6d;
            dsum2 = g2 * zz[4] / 24d + g1 * g1 * zz[6] / 72d;
            density = (zz[0] + dsum1 + dsum2) / sigma;
            if (density < 0d)
                density = -density;
            MW_DensityRet = density;
            return MW_DensityRet;
        }

        public static double MW_CDF2(double x, double sigma, double g1, double g2)
        {
            double MW_CDF2Ret = default;
            var zz = new double[6];
            double LeftTail;
            double dsum1;
            double dsum2;
            x = x + 1d / (sigma * 2d);
            LeftTail = DistMain.ndis(x);
            DistCornish.NdensDeriv(5, x, ref zz);
            dsum1 = -g1 * zz[2] / 6d;
            dsum2 = g2 * zz[3] / 24d + g1 * g1 * zz[5] / 72d;
            LeftTail = LeftTail + dsum1 + dsum2;
            if (LeftTail < 0d)
                LeftTail = -LeftTail;
            MW_CDF2Ret = LeftTail;
            return MW_CDF2Ret;
        }

        public static double MW_CDF(double x, double sigma, double g1, double g2)
        {
            double MW_CDFRet = default;
            double x2;
            double x3;
            double x5;
            double e;
            var LeftTail = default(double);
            var Righttail = default(double);
            var density = default(double);
            x2 = x * x;
            x3 = x2 * x;
            x5 = x3 * x2;
            DistMain.ndis2(false, x, ref LeftTail, ref Righttail, ref density);
            e = 1d / (2d * sigma) + x / (12d * sigma * sigma) + g1 * (1d - x2) / 6d - (g2 / 24d - g1 / (12d * sigma)) * (3d * x - x3) + g1 * g1 * (15d * x - 10d * x3 + x5) / 72d;

            MW_CDFRet = LeftTail - density * e;
            return MW_CDFRet;
        }












    }





}