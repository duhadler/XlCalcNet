using System;


namespace Distributions
{

    static class PermKruskal
    {

        private static double[] NewDataX;
        private static double[] OldDataX;
        private static int[,] NewDataR;
        private static int[,] OldDataR;
        private static int[] NewDataSize;
        private static int[] OldDataSize;
        private static int[] NewDataStart;
        private static int[] OldDataStart;
        private static int m;
        private static int MaxTLength;

        public static void initdata(int mm, int MaxVLength, bool linear)
        {
            MaxTLength = 8192;
            if (linear)
                m = 0;
            else
                m = mm;
            OldDataSize = new int[MaxVLength + 1];
            NewDataSize = new int[MaxVLength + 1];
            OldDataStart = new int[MaxVLength + 1];
            NewDataStart = new int[MaxVLength + 1];
            OldDataX = new double[MaxTLength];
            NewDataX = new double[MaxTLength];
            OldDataR = new int[m + 1, MaxTLength];
            NewDataR = new int[m + 1, MaxTLength];
            OldDataSize[0] = 0;
            OldDataStart[0] = 0;
            OldDataX[0] = 1d;
            for (int j = 0; j <= m; j++)
                OldDataR[j, 0] = 0;
        }


        // NextRank: The next rankvalue which will be added to form the new vector
        // NewDest : ID-# of the new vector set in which the result will be stored
        // CurNumCount: Count of the old vectors which form the new vector
        // CurNum  : ID-# of the old vectors which form the new vectors
        // AddPos: Position in the old vectors to which NextRank will be added
        // N: Sample size per group for the new vector
        // V: Parameters for the Lehmann alternative
        public static void BuildNew(int NextRank, int NewDest, int CurNumCount, ref int[] CurNum, ref int[] AddPos, ref double[] n, ref double[] v, bool linear, int[] score)
        {
            var w = new int[CurNumCount + 1, m + 1];
            var z = new double[CurNumCount + 1];
            var Min = new int[m + 1];
            var LocalPos = new int[CurNumCount + 1];
            var NV = new double[CurNumCount + 1];

            double nvSum = 0d;
            for (int j = 0; j <= CurNumCount; j++)
            {
                NV[j] = n[j] * v[j];
                nvSum = nvSum + NV[j];
            }
            for (int j = 0; j <= CurNumCount; j++)
                NV[j] = NV[j] / nvSum;
            if (NewDest == 0)
                NewDataStart[NewDest] = 0;
            else
                NewDataStart[NewDest] = NewDataStart[NewDest - 1] + NewDataSize[NewDest - 1] + 1;
            int NND = NewDataStart[NewDest];
            int NewCount = 0;
            for (int j = 0; j <= CurNumCount; j++)
            {
                LocalPos[j] = 0;
                z[j] = OldDataX[OldDataStart[CurNum[j]]];
                for (int k = 0; k <= m; k++)
                {
                    w[j, k] = OldDataR[k, OldDataStart[CurNum[j]]];
                    if (linear)
                    {
                        w[j, k] = w[j, k] + NextRank * score[AddPos[j]];
                    }
                    else if (k == AddPos[j])
                        w[j, k] = w[j, k] + NextRank;
                }
                if (j == 0)
                {
                    for (int k = 0; k <= m; k++)
                        Min[k] = w[j, k];
                }
                int k4 = -1;
                do
                    k4 = k4 + 1;
                while (k4 < m - 1 & Min[k4] == w[j, k4]);
                if (w[j, k4] < Min[k4])
                {
                    for (int k = 0; k <= m; k++)
                        Min[k] = w[j, k];
                }
            }

            // MainLoop
            while (CurNumCount >= 0)
            {
                for (int j = 0; j <= CurNumCount; j++)
                {
                    int k4 = -1;
                    do
                        k4 = k4 + 1;
                    while (k4 < m - 1 & Min[k4] == w[j, k4]);
                    if (w[j, k4] < Min[k4])
                    {
                        for (int k = 0; k <= m; k++)
                            Min[k] = w[j, k];
                    }
                }
                double NewZ = 0d;
                for (int j = 0; j <= CurNumCount; j++)
                {
                    int k4 = -1;
                    do
                        k4 = k4 + 1;
                    while (k4 < m - 1 & Min[k4] == w[j, k4]);
                    if (Min[k4] == w[j, k4])
                    {
                        NewZ = NewZ + NV[j] * z[j];
                        if (LocalPos[j] < OldDataSize[CurNum[j]])
                        {
                            LocalPos[j] = LocalPos[j] + 1;
                            int j1 = OldDataStart[CurNum[j]] + LocalPos[j];
                            z[j] = OldDataX[j1];
                            for (int k = 0; k <= m; k++)
                                w[j, k] = OldDataR[k, j1];
                            if (linear)
                            {
                                w[j, m] = w[j, m] + NextRank * score[AddPos[j]];
                            }
                            else
                            {
                                w[j, AddPos[j]] = w[j, AddPos[j]] + NextRank;
                            }
                        }
                        else
                        {
                            for (int k = j + 1; k <= CurNumCount; k++)
                            {
                                CurNum[k - 1] = CurNum[k];
                                LocalPos[k - 1] = LocalPos[k];
                                AddPos[k - 1] = AddPos[k];
                                NV[k - 1] = NV[k];
                                score[k - 1] = score[k];
                            }
                            CurNumCount = CurNumCount - 1;
                        }
                    }
                }
                if (NND + NewCount > MaxTLength - 1)
                {
                    MaxTLength = 2 * MaxTLength;
                    Array.Resize(ref OldDataX, MaxTLength);
                    Array.Resize(ref NewDataX, MaxTLength);
                    var oldOldDataR = OldDataR;
                    OldDataR = new int[m + 1, MaxTLength];
                    if (oldOldDataR != null)
                            for (var i1 = 0; i1 <= oldOldDataR.Length / oldOldDataR.GetLength(1) - 1; ++i1)
                            Array.Copy(oldOldDataR, i1 * oldOldDataR.GetLength(1), OldDataR, i1 * OldDataR.GetLength(1), Math.Min(oldOldDataR.GetLength(1), OldDataR.GetLength(1)));
                    var oldNewDataR = NewDataR;
                    NewDataR = new int[m + 1, MaxTLength];
                    if (oldNewDataR != null)
                            for (var i2 = 0; i2 <= oldNewDataR.Length / oldNewDataR.GetLength(1) - 1; ++i2)
                            Array.Copy(oldNewDataR, i2 * oldNewDataR.GetLength(1), NewDataR, i2 * NewDataR.GetLength(1), Math.Min(oldNewDataR.GetLength(1), NewDataR.GetLength(1)));
                }
                for (int k = 0; k <= m; k++)
                    NewDataR[k, NND + NewCount] = Min[k];
                NewDataX[NND + NewCount] = NewZ;
                for (int k = 0; k <= m; k++)
                    Min[k] = w[0, k];
                NewCount = NewCount + 1;
            }
            NewDataSize[NewDest] = NewCount - 1;
        }




        public static void GetFinalVector(ref int FinalSize, ref double[] FinalX, ref int[,] FinalR)
        {
            int k = 0;
            FinalSize = OldDataSize[k];
            int ok = OldDataStart[k];
            FinalX = new double[FinalSize + 1];
            FinalR = new int[m + 1, FinalSize + 1];
            for (int i = 0; i <= OldDataSize[k]; i++)
            {
                FinalX[i] = OldDataX[ok + i];
                for (int j = 0; j <= m; j++)
                    FinalR[j, i] = OldDataR[j, ok + i];
            }
        }


        public static void NewToOld(int MaxVLength)
        {
            for (int k = 0; k <= MaxVLength; k++)
            {
                int nk = NewDataStart[k];
                OldDataSize[k] = NewDataSize[k];
                OldDataStart[k] = NewDataStart[k];
                for (int i = 0; i <= NewDataSize[k]; i++)
                {
                    OldDataX[nk + i] = NewDataX[nk + i];
                    for (int j = 0; j <= m; j++)
                        OldDataR[j, nk + i] = NewDataR[j, nk + i];
                }
            }
        }



        public static void CalcRankSums(int m, int ng, ref int[] n, ref double[] v, ref int[] Rank, bool linear, ref int[] score, ref int FinalSize, ref double[] FinalX, ref int[,] FinalR)
        {
            bool calc = true;
            int h = m - 1;
            int m1 = m + 1;
            int zsize = m1 * 6;
            int ztempsize = m1 * 6;
            var zlength = new int[ng + 1];
            var zstart = new int[ng + 1];
            var AddPos = new int[m + 1];
            var w = new int[m + 1];
            var CurNum = new int[m + 1];
            var t = new int[m + 1];
            var v4 = new double[m + 1];
            var n4 = new double[m + 1];
            var Score4 = new int[m + 1];
            var ztemp = new int[ztempsize + 1];
            var z = new int[zsize + 1];
            for (int j = 0; j <= m; j++)
                w[j] = n[j];
            for (int j = 0; j <= m; j++)
                t[j] = j;

            bool sorted;
            do
            {
                sorted = true;
                for (int k = 0; k <= m - 1; k++)
                {
                    int k1 = k + 1;
                    if (w[k] < w[k1])
                    {
                        int w1 = w[k];
                        w[k] = w[k1];
                        w[k1] = w1;
                        w1 = t[k];
                        t[k] = t[k1];
                        t[k1] = w1;
                        sorted = false;
                    }
                }
            }
            while (!sorted);

            for (int j = 0; j <= m; j++)
                n[j] = w[j];
            for (int k = 0; k <= m; k++)
                z[k] = w[k];
            zlength[ng] = 0;
            zstart[ng] = 0;

            int zmax = 0;
            for (int i = ng - 1; i >= 0; i -= 1)
            {
                bool first;
                int i1 = i + 1;
                zstart[i] = zstart[i1] + (zlength[i1] + 1) * m1;
                first = true;
                for (int j = 0; j <= zlength[i1]; j++)
                {
                    for (int k2 = 0; k2 <= m; k2++)
                    {
                        if (z[zstart[i1] + j * m1 + k2] > 0)
                        {
                            for (int k1 = 0; k1 <= m; k1++)
                                w[k1] = z[zstart[i1] + j * m1 + k1];
                            w[k2] = w[k2] - 1;
                            if (first)
                            {
                                first = false;
                                zlength[i] = 0;
                                for (int k = 0; k <= m; k++)
                                    ztemp[k] = w[k];
                            }
                            else
                            {
                                int l = 0;
                                int r = zlength[i];
                                do
                                {
                                    int q = (l + r + 1) / 2;
                                    int k = -1;
                                    bool EQ;
                                    bool LE;
                                    int vref;
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
                                int k0 = 0;
                                while (ztemp[l * m1 + k0] == w[k0] & k0 <= h)
                                    k0 = k0 + 1;
                                if (k0 < m)
                                {
                                    zlength[i] = zlength[i] + 1;
                                    if ((zlength[i] + 1) * m1 > ztempsize)
                                    {
                                        ztempsize = ztempsize + (zlength[i] + 1) * m1;
                                        Array.Resize(ref ztemp, ztempsize + 1);
                                    }
                                    l = l + 1;
                                    if (zlength[i] != l)
                                    {
                                        for (int i2 = zlength[i]; i2 >= 0; i2 -= 1)
                                        {
                                            for (int k = 0; k <= m; k++)
                                                ztemp[(i2 + 1) * m1 + k] = ztemp[i2 * m1 + k];
                                        }
                                    }
                                    for (int k = 0; k <= m; k++)
                                        ztemp[l * m1 + k] = w[k];
                                }
                            }
                        }
                    }
                }

                if ((zlength[i] + 1) * m1 > zsize - zstart[i])
                {
                    zsize = zsize + (zlength[i] + 1) * m1;
                    Array.Resize(ref z, zsize + 1);
                }
                var zl = (zlength[i] + 1) * m1 - 1;
                for (int j = 0; j <= zl; j++)
                    z[zstart[i] + j] = ztemp[j];
                if (zlength[i] > zmax)
                    zmax = zlength[i];
            }
            var Last = new int[(zmax + 1) * m1 + 1];

            // Calculate the Vectors
            if (calc)
                initdata(m, zmax, linear);
            for (int i = 1; i <= ng; i++)
            {
                Console.WriteLine("Iteration: {0}", i);
                int i1 = i - 1;
                var zl = (zlength[i1] + 1) * m1;
                for (int j = 0; j <= zl; j++)
                    Last[j] = z[zstart[i1] + j];
                int Lastj = zlength[i1];

                var zli = zlength[i];
                for (int j = 0; j <= zli; j++)
                {
                    int CurNumCount = -1;
                    for (int k = 0; k <= m; k++)
                    {
                        if (z[zstart[i] + j * m1 + k] > 0)
                        {
                            for (int k1 = 0; k1 <= m; k1++)
                                w[k1] = z[zstart[i] + j * m1 + k1];
                            w[k] = w[k] - 1;

                            int j2 = -1;
                            bool EQ;
                            do
                            {
                                j2 = j2 + 1;
                                int k3 = -1;
                                do
                                {
                                    k3 = k3 + 1;
                                    EQ = w[k3] == Last[j2 * m1 + k3];
                                }
                                while (EQ & k3 < m);
                            }
                            while (!(EQ | j2 == Lastj));
                            int CurrentNumber = j2;

                            if (!EQ)
                                CurrentNumber = CurrentNumber + 1;
                            CurNumCount = CurNumCount + 1;
                            CurNum[CurNumCount] = CurrentNumber;
                            AddPos[CurNumCount] = k;
                            n4[CurNumCount] = w[k] + 1;
                            v4[CurNumCount] = v[k];
                            Score4[CurNumCount] = score[k];
                        }
                    }
                    if (calc)
                    {
                        if (linear)
                        {
                        }
                        // Call BuildNewLinear(Rank(i), j, CurNumCount, CurNum, AddPos, n4, v4, linear, Score4)
                        else
                        {
                            BuildNew(Rank[i], j, CurNumCount, ref CurNum, ref AddPos, ref n4, ref v4, linear, Score4);
                        }
                    }
                }
                if (calc)
                    NewToOld(zlength[i]);
            }
            if (calc)
                GetFinalVector(ref FinalSize, ref FinalX, ref FinalR);
        }



        public static void CalcStats(int Mode, int m, int FinalSize, ref double[] FinalX, ref int[,] FinalR, ref int nlength, ref double[] Prob, ref double[] x)
        {
            Console.WriteLine("---Final Vector------Size: {0}", FinalSize);
            switch (Mode)
            {
                case 1:
                    {
                        int sum = 0;
                        for (int j = 0; j <= m; j++)
                            sum = sum + FinalR[j, 0];
                        int mean = sum / (m + 1);
                        int sum2 = 0;
                        for (int j = 0; j <= m; j++)
                        {
                            int d = FinalR[j, 0] - mean;
                            sum2 = sum2 + d * d;
                        }
                        int vmax = sum2 + 2;
                        var Chi2 = new double[vmax + 1];
                        for (int i = 0; i <= vmax; i++)
                            Chi2[i] = 0d;
                        for (int i = 0; i <= FinalSize; i++)
                        {
                            string s2 = i.ToString() + ".  " + FinalX[i].ToString() + ": ";
                            sum2 = 0;
                            for (int j = 0; j <= m; j++)
                            {
                                int d = FinalR[j, i] - mean;
                                sum2 = sum2 + d * d;
                                s2 = s2 + FinalR[j, i].ToString();
                                if (j < m)
                                    s2 = s2 + ",";
                            }
                            Chi2[sum2] = Chi2[sum2] + FinalX[i];
                            s2 = s2 + "  ;  " + sum2.ToString();

                            // This shows the final vector plus criterion
                            //Console.WriteLine(s2);
                        }
                        Console.WriteLine("Chi2");
                        int j0 = 0;
                        for (int i = 0; i <= vmax; i++)
                        {
                            if (Chi2[i] > 0d)
                                j0 = j0 + 1;
                        }
                        nlength = j0 - 1;

                        x = new double[nlength + 1];
                        Prob = new double[nlength + 1];
                        int j2 = 0;
                        for (int i = 0; i <= vmax; i++)
                        {
                            if (Chi2[i] > 0d)
                            {
                                Prob[j2] = Chi2[i];
                                x[j2] = i;
                                j2 = j2 + 1;
                            }
                        }
                        Chi2 = null;
                        break;
                    }
                case 2:
                    {
                        //int sum = 0;
                        int vmax = Math.Abs(FinalR[m, 0]);
                        var Chi2 = new double[vmax + 1];
                        for (int i = 0; i <= vmax; i++)
                            Chi2[i] = 0d;
                        for (int i = 0; i <= FinalSize; i++)
                        {
                            string s2 = i.ToString() + ".  " + FinalX[i].ToString() + ": ";
                            int sum2 = 0;
                            for (int j = 0; j <= m; j++)
                            {
                                for (int j1 = j + 1; j1 <= m; j1++)
                                {
                                    int d = FinalR[j, i] - FinalR[j1, i];
                                    d = Math.Abs(d);
                                    if (d > sum2)
                                        sum2 = d;

                                    s2 = s2 + FinalR[j, i].ToString();
                                    if (j < m)
                                        s2 = s2 + ",";
                                }
                            }
                            Chi2[sum2] = Chi2[sum2] + FinalX[i];
                            s2 = s2 + "  ;  " + sum2.ToString();

                            // This shows the final vector plus criterion
                            //Console.WriteLine(s2);
                        }
                        FinalX = null;
                        FinalR = null;
                        Console.WriteLine("Chi2");
                        int j3 = 0;
                        for (int i = 0; i <= vmax; i++)
                        {
                            if (Chi2[i] > 0d)
                                j3 = j3 + 1;
                        }
                        nlength = j3 - 1;

                        x = new double[nlength + 1];
                        Prob = new double[nlength + 1];
                        int j4 = 0;
                        for (int i = 0; i <= vmax; i++)
                        {
                            if (Chi2[i] > 0d)
                            {
                                Prob[j4] = Chi2[i];
                                x[j4] = i;
                                j4 = j4 + 1;
                            }
                        }
                        break;
                    }
            }
        }


        public static void Kruskaldemo2()
        {
            int k = 3;  // number of groups
            int ncommon = 5;  // common sample size
            int Mode = 1;
            bool linear = false;

            int m = k - 1;
            var n = new int[m + 1];
            var v = new double[m + 1];
            var score = new int[m + 1];
            for (int j = 0; j <= m; j++)
                v[j] = j * 0 + 1;
            for (int j = 0; j <= m; j++)
                n[j] = ncommon;
            int ng = 0;  // total sample size
            for (int j = 0; j <= m; j++)
                ng = ng + n[j];
            var Rank = new int[ng + 1 + 1];
            for (int j = 0; j <= ng; j++)
                Rank[j] = j;

            var FinalSize = 0;
            var FinalX = default(double[]);
            var FinalR = default(int[,]);
            CalcRankSums(m, ng, ref n, ref v, ref Rank, linear, ref score, ref FinalSize, ref FinalX, ref FinalR);

            var nlength = 0;
            var Prob = default(double[]);
            var x = default(double[]);
            CalcStats(Mode, m, FinalSize, ref FinalX, ref FinalR, ref nlength, ref Prob, ref x);

            for (int i = 0; i <= nlength; i++)
                Console.WriteLine("i: {0}, x(i): {1}, Prob(i): {2}", i, x[i], Prob[i]);

        }



    }
}