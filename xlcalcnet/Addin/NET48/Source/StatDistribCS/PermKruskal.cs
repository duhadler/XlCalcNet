using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace NewDistrib
{


    static class PermKruskal
    {




        // Module to create and sort vectors for Kruskal-Wallis

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
            int j;
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
            var loopTo = m;
            for (j = 0; j <= loopTo; j++)
                OldDataR[j, 0] = 0;
        }

        public static void DoneData()
        {
            NewDataSize = null;
            OldDataSize = null;
            NewDataStart = null;
            OldDataStart = null;
            NewDataX = null;
            OldDataX = null;
            NewDataR = null;
            OldDataR = null;
        }

        // NextRank: The next rankvalue which will be added to form the new vector
        // NewDest : ID-# of the new vector set in which the result will be stored
        // CurNumCount: Count of the old vectors which form the new vector
        // CurNum  : ID-# of the old vectors which form the new vectors
        // AddPos: Position in the old vectors to which NextRank will be added
        // N: Sample size per group for the new vector
        // V: Parameters fot the Lehmann alternative
        public static void BuildNew(int NextRank, int NewDest, int CurNumCount, ref int[] CurNum, ref int[] AddPos, ref double[] n, ref double[] v, bool linear, int[] score)
        {
            int[,] w;
            double[] z;
            int[] Min;
            int[] LocalPos;
            double[] NV;
            double NewZ;
            int NewCount;
            int NND;
            int j1;
            int j;
            int k;
            int k4;
            double nvSum;
            w = new int[CurNumCount + 1, m + 1];
            z = new double[CurNumCount + 1];
            Min = new int[m + 1];
            LocalPos = new int[CurNumCount + 1];
            NV = new double[CurNumCount + 1];
            nvSum = 0d;
            var loopTo = CurNumCount;
            for (j = 0; j <= loopTo; j++)
            {
                NV[j] = n[j] * v[j];
                nvSum = nvSum + NV[j];
            }
            var loopTo1 = CurNumCount;
            for (j = 0; j <= loopTo1; j++)
                NV[j] = NV[j] / nvSum;
            if (NewDest == 0)
                NewDataStart[NewDest] = 0;
            else
                NewDataStart[NewDest] = NewDataStart[NewDest - 1] + NewDataSize[NewDest - 1] + 1;
            NND = NewDataStart[NewDest];
            NewCount = 0;
            var loopTo2 = CurNumCount;
            for (j = 0; j <= loopTo2; j++)
            {
                LocalPos[j] = 0;
                z[j] = OldDataX[OldDataStart[CurNum[j]]];
                var loopTo3 = m;
                for (k = 0; k <= loopTo3; k++)
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
                    var loopTo4 = m;
                    for (k = 0; k <= loopTo4; k++)
                        Min[k] = w[j, k];
                }
                k4 = -1;
                do
                    k4 = k4 + 1;
                while (k4 < m - 1 & Min[k4] == w[j, k4]);
                if (w[j, k4] < Min[k4])
                {
                    var loopTo5 = m;
                    for (k = 0; k <= loopTo5; k++)
                        Min[k] = w[j, k];
                }
            }

            // MainLoop
            while (CurNumCount >= 0)
            {
                var loopTo6 = CurNumCount;
                for (j = 0; j <= loopTo6; j++)
                {
                    k4 = -1;
                    do
                        k4 = k4 + 1;
                    while (k4 < m - 1 & Min[k4] == w[j, k4]);
                    if (w[j, k4] < Min[k4])
                    {
                        var loopTo7 = m;
                        for (k = 0; k <= loopTo7; k++)
                            Min[k] = w[j, k];
                    }
                }
                NewZ = 0d;
                var loopTo8 = CurNumCount;
                for (j = 0; j <= loopTo8; j++)
                {
                    k4 = -1;
                    do
                        k4 = k4 + 1;
                    while (k4 < m - 1 & Min[k4] == w[j, k4]);
                    if (Min[k4] == w[j, k4])
                    {
                        NewZ = NewZ + NV[j] * z[j];
                        if (LocalPos[j] < OldDataSize[CurNum[j]])
                        {
                            LocalPos[j] = LocalPos[j] + 1;
                            j1 = OldDataStart[CurNum[j]] + LocalPos[j];
                            z[j] = OldDataX[j1];
                            var loopTo9 = m;
                            for (k = 0; k <= loopTo9; k++)
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
                            var loopTo10 = CurNumCount;
                            for (k = j + 1; k <= loopTo10; k++)
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
                    if (oldOldDataR is not null)
                        for (var i1 = 0; i1 <= oldOldDataR.Length / oldOldDataR.GetLength(1) - 1; ++i1)
                            Array.Copy(oldOldDataR, i1 * oldOldDataR.GetLength(1), OldDataR, i1 * OldDataR.GetLength(1), Math.Min(oldOldDataR.GetLength(1), OldDataR.GetLength(1)));
                    var oldNewDataR = NewDataR;
                    NewDataR = new int[m + 1, MaxTLength];
                    if (oldNewDataR is not null)
                        for (var i2 = 0; i2 <= oldNewDataR.Length / oldNewDataR.GetLength(1) - 1; ++i2)
                            Array.Copy(oldNewDataR, i2 * oldNewDataR.GetLength(1), NewDataR, i2 * NewDataR.GetLength(1), Math.Min(oldNewDataR.GetLength(1), NewDataR.GetLength(1)));
                }
                var loopTo11 = m;
                for (k = 0; k <= loopTo11; k++)
                    NewDataR[k, NND + NewCount] = Min[k];
                NewDataX[NND + NewCount] = NewZ;
                var loopTo12 = m;
                for (k = 0; k <= loopTo12; k++)
                    Min[k] = w[0, k];
                NewCount = NewCount + 1;
            }
            NewDataSize[NewDest] = NewCount - 1;
        }



        // ' NextRank: The next rankvalue which will be added to form the new vector
        // ' NewDest : ID-# of the new vector set in which the result will be stored
        // ' CurNumCount: Count of the old vectors which form the new vector
        // ' CurNum  : ID-# of the old vectors which form the new vectors
        // ' AddPos: Position in the old vectors to which NextRank will be added
        // ' N: Sample size per group for the new vector
        // ' V: Parameters for the Lehmann alternative



        public static void GetFinalVector(ref int FinalSize, ref double[] FinalX, ref int[,] FinalR)
        {
            int j;
            int i;
            int ok;
            int k;
            k = 0;
            FinalSize = OldDataSize[k];
            ok = OldDataStart[k];
            FinalX = new double[FinalSize + 1];
            FinalR = new int[m + 1, FinalSize + 1];
            // Debug.Print "---Old Vector------Size: " + Str(OldDataSize(k))
            // s2 = ""
            var loopTo = OldDataSize[k];
            for (i = 0; i <= loopTo; i++)
            {
                FinalX[i] = OldDataX[ok + i];
                // s2 = Str(i) + ".  " + Str(OldDataX(ok + i)) + ": "
                var loopTo1 = m;
                for (j = 0; j <= loopTo1; j++)
                    // s2 = s2 + Str(OldDataR(j, ok + i))
                    // If j < m Then s2 = s2 + ","
                    FinalR[j, i] = OldDataR[j, ok + i];
                // Debug.Print s2
            }
        }


        public static void ShowOldVector(int k)
        {
            int j;
            int i;
            int ok;
            string s2;
            ok = OldDataStart[k];
            Console.WriteLine("---Old Vector------Size: " + Conversion.Str(OldDataSize[k]));
            s2 = "";
            var loopTo = OldDataSize[k];
            for (i = 0; i <= loopTo; i++)
            {
                s2 = Conversion.Str(i) + ".  " + Conversion.Str(OldDataX[ok + i]) + ": ";
                var loopTo1 = m;
                for (j = 0; j <= loopTo1; j++)
                {
                    s2 = s2 + Conversion.Str(OldDataR[j, ok + i]);
                    if (j < m)
                        s2 = s2 + ",";
                }
                Console.WriteLine(s2);
            }
        }

        public static void ShowNewVector(int k)
        {
            int j;
            int i;
            int nk;
            string s2;
            nk = NewDataStart[k];
            Console.WriteLine("---New Vector------Size: " + Conversion.Str(NewDataSize[k]));
            s2 = "";
            var loopTo = NewDataSize[k];
            for (i = 0; i <= loopTo; i++)
            {
                s2 = Conversion.Str(i) + ".  " + Conversion.Str(NewDataX[nk + i]) + ": ";
                var loopTo1 = m;
                for (j = 0; j <= loopTo1; j++)
                {
                    s2 = s2 + Conversion.Str(NewDataR[j, nk + i]);
                    if (j < m)
                        s2 = s2 + ",";
                }
                Console.WriteLine(s2);
            }
            Console.WriteLine("---End New Vector-----");
        }

        public static void NewToOld(int MaxVLength)
        {
            int k;
            int i;
            int j;
            int nk;
            // Debug.Print "NewToOld: ", MaxVLength

            var loopTo = MaxVLength;
            for (k = 0; k <= loopTo; k++)
            {
                nk = NewDataStart[k];
                OldDataSize[k] = NewDataSize[k];
                OldDataStart[k] = NewDataStart[k];
                var loopTo1 = NewDataSize[k];
                for (i = 0; i <= loopTo1; i++)
                {
                    OldDataX[nk + i] = NewDataX[nk + i];
                    var loopTo2 = m;
                    for (j = 0; j <= loopTo2; j++)
                        OldDataR[j, nk + i] = NewDataR[j, nk + i];
                }
            }
        }



        // Recursive algorithm for Kruskal-Wallis


        public static void CalcRankSums(int m, int ng, ref int[] n, ref double[] v, ref int[] Rank, bool linear, ref int[] score, ref int FinalSize, ref double[] FinalX, ref int[,] FinalR)
        {

            int[] AddPos;
            int[] w;
            int[] CurNum;
            int[] t;
            int[] z;
            int[] zstart;
            int[] zlength;
            int[] ztemp;
            int[] Last;
            bool sortiert;
            bool first;
            bool EQ;
            bool LE;
            int CurNumCount;
            int zmax;
            int h;
            int k2;
            int i;
            int r;
            int k1;
            int i1;
            int i2;
            int vref;
            int w1;
            int q;
            int m1;
            int CurrentNumber;
            int Lastj;
            //int scount;
            bool calc;
            bool showstruc;
            bool showvec;
            string s2;
            string s3;
            int j2;
            int k3;
            int j;
            int k;
            int l;
            int zsize;
            int ztempsize;
            double[] v4;
            double[] n4;
            int[] Score4;

            calc = true;
            showstruc = false;
            showvec = false;
            h = m - 1;
            m1 = m + 1;
            zsize = m1 * 6;
            ztempsize = m1 * 6;
            zlength = new int[ng + 1];
            zstart = new int[ng + 1];
            AddPos = new int[m + 1];
            w = new int[m + 1];
            CurNum = new int[m + 1];
            t = new int[m + 1];
            v4 = new double[m + 1];
            n4 = new double[m + 1];
            Score4 = new int[m + 1];
            ztemp = new int[ztempsize + 1];
            z = new int[zsize + 1];
            var loopTo = m;
            for (j = 0; j <= loopTo; j++)
                w[j] = n[j];
            var loopTo1 = m;
            for (j = 0; j <= loopTo1; j++)
                t[j] = j;

            // Sorting should be eliminated
            do
            {
                sortiert = true;
                var loopTo2 = m - 1;
                for (k = 0; k <= loopTo2; k++)
                {
                    k1 = k + 1;
                    if (w[k] < w[k1])
                    {
                        w1 = w[k];
                        w[k] = w[k1];
                        w[k1] = w1;
                        w1 = t[k];
                        t[k] = t[k1];
                        t[k1] = w1;
                        sortiert = false;
                    }
                }
            }
            while (!sortiert);

            var loopTo3 = m;
            for (j = 0; j <= loopTo3; j++)
                n[j] = w[j];
            var loopTo4 = m;
            for (k = 0; k <= loopTo4; k++)
                z[k] = w[k];
            zlength[ng] = 0;
            zstart[ng] = 0;

            zmax = 0;
            for (i = ng - 1; i >= 0; i -= 1)
            {
                i1 = i + 1;
                zstart[i] = zstart[i1] + (zlength[i1] + 1) * m1;
                first = true;
                var loopTo5 = zlength[i1];
                for (j = 0; j <= loopTo5; j++)
                {
                    var loopTo6 = m;
                    for (k2 = 0; k2 <= loopTo6; k2++)
                    {
                        if (z[zstart[i1] + j * m1 + k2] > 0)
                        {
                            var loopTo7 = m;
                            for (k1 = 0; k1 <= loopTo7; k1++)
                                w[k1] = z[zstart[i1] + j * m1 + k1];
                            w[k2] = w[k2] - 1;
                            if (first)
                            {
                                first = false;
                                zlength[i] = 0;
                                var loopTo8 = m;
                                for (k = 0; k <= loopTo8; k++)
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
                                    if ((zlength[i] + 1) * m1 > ztempsize)
                                    {
                                        ztempsize = ztempsize + (zlength[i] + 1) * m1;
                                        Array.Resize(ref ztemp, ztempsize + 1);
                                        // Debug.Print "New ztempsize: ", ztempsize
                                    }
                                    l = l + 1;
                                    if (zlength[i] != l)
                                    {
                                        for (i2 = zlength[i]; i2 >= 0; i2 -= 1)
                                        {
                                            var loopTo9 = m;
                                            for (k = 0; k <= loopTo9; k++)
                                                ztemp[(i2 + 1) * m1 + k] = ztemp[i2 * m1 + k];
                                        }
                                    }
                                    var loopTo10 = m;
                                    for (k = 0; k <= loopTo10; k++)
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
                    // Debug.Print "New zsize: ", zsize
                }
                var loopTo11 = (zlength[i] + 1) * m1 - 1;
                for (j = 0; j <= loopTo11; j++)
                    z[zstart[i] + j] = ztemp[j];
                if (zlength[i] > zmax)
                    zmax = zlength[i];
            }
            // Dim ztotal As Double, zfactorial As Double
            // ztotal = 0: zfactorial = 1
            // For i = 1 To ng
            // ztotal = ztotal + zlength(i) + 1
            // zfactorial = zfactorial * i
            // Debug.Print i, zlength(i) + 1
            // Next i
            // Debug.Print "ztotal: ", ztotal, zfactorial


            Last = new int[(zmax + 1) * m1 + 1];

            // Calculate the Vectors
            s2 = "";
            s3 = "";
            if (calc)
                initdata(m, zmax, linear);
            if (calc & showvec)
                ShowOldVector(0);
            var loopTo12 = ng;
            for (i = 1; i <= loopTo12; i++)
            {
                // Debug.Print "Iteration: ", i
                i1 = i - 1;
                var loopTo13 = (zlength[i1] + 1) * m1;
                for (j = 0; j <= loopTo13; j++)
                    Last[j] = z[zstart[i1] + j];
                Lastj = zlength[i1];
                if (showstruc)
                    Debug.Print(Conversion.Str(i) + ". Iteration");
                //int scount = 0;

                var loopTo14 = zlength[i];
                for (j = 0; j <= loopTo14; j++)
                {
                    if (showstruc)
                    {
                        s2 = "";
                        var loopTo15 = m;
                        for (k = 0; k <= loopTo15; k++)
                            s2 = s2 + Conversion.Str(z[zstart[i] + j * m1 + k]);
                        s2 = s2 + "  :";
                        s3 = "   ";
                    }
                    CurNumCount = -1;
                    var loopTo16 = m;
                    for (k = 0; k <= loopTo16; k++)
                    {
                        if (z[zstart[i] + j * m1 + k] > 0)
                        {
                            var loopTo17 = m;
                            for (k1 = 0; k1 <= loopTo17; k1++)
                                w[k1] = z[zstart[i] + j * m1 + k1];
                            w[k] = w[k] - 1;
                            if (showstruc)
                            {
                                var loopTo18 = m;
                                for (k1 = 0; k1 <= loopTo18; k1++)
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
                            n4[CurNumCount] = w[k] + 1;
                            v4[CurNumCount] = v[k];
                            Score4[CurNumCount] = score[k];
                            if (showstruc)
                            {
                                s3 = s3 + " [" + Conversion.Str(n4[CurNumCount]) + "; " + Conversion.Str(v4[CurNumCount]) + Conversion.Str(Score4[CurNumCount]) + "], ";
                                s2 = s2 + " (" + Conversion.Str(CurNum[CurNumCount]) + "; " + Conversion.Str(AddPos[CurNumCount]) + ")";
                                s2 = s2 + ", ";
                            }
                        }
                    }
                    if (showstruc)
                        Console.WriteLine(s2 + s3);
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
                    if (calc & showvec)
                        ShowNewVector(j);
                }
                if (calc)
                    NewToOld(zlength[i]);
            }

            zlength = null;
            zstart = null;
            Last = null;
            z = null;
            ztemp = null;
            AddPos = null;
            w = null;
            CurNum = null;
            t = null;
            v4 = null;
            n4 = null;

            if (calc)
                GetFinalVector(ref FinalSize, ref FinalX, ref FinalR);
            // If calc Then Call ShowOldVector(0)
            if (calc)
                DoneData();
        }


        public static object KruskalDemoMain(int GetWhat, int k, int CommonN)
        {
            object KruskalDemoMainRet = default;
            int[] Rank;
            int[] n;
            double[] v;
            int[] score;
            bool linear;
            int ng;
            int Mode;
            int m;
            int j;
            int i;
            // Dim IntCoeff() As Integer, m As Integer, Order As Integer, j As Integer, i As Integer
            var FinalSize = default(int);
            double[] FinalX;
            int[,] FinalR;
            var nlength = default(int);
            double[] Prob;
            double[] x;
            double p1;
            var pcum = default(double);
            double Chi2;
            double Varianz;
            double std;
            var LeftTail = default(double);
            var Righttail = default(double);
            var cdens = default(double);
            double[,] Output; // , title() As String
                              // If GetWhat = 1 Then
                              // ReDim title(0, 6)
                              // If Mode = 1 Then title(0, 0) = "Chi2" Else title(0, 0) = "Z"
                              // title(0, 1) = "Density"
                              // title(0, 2) = "RightTail"
                              // title(0, 3) = "cdisx"
                              // title(0, 4) = "Temp"
                              // title(0, 5) = "Temp"
                              // title(0, 6) = "Temp"
                              // KruskalDemoMain = title
                              // Exit Function
                              // End If

            m = k - 1;
            linear = false;
            n = new int[m + 1];
            v = new double[m + 1];
            score = new int[m + 1];
            // If linear Then

            // Call GetIntCoeff(k, IntCoeff)
            // ' For order = 1 To k - 1
            // Order = 2
            // Debug.Print "Coeff of order :", Order
            // For j = 1 To k
            // score(j - 1) = IntCoeff(Order, j) + 0
            // Debug.Print j - 1, IntCoeff(Order, j)
            // Next j
            // 'Next order
            // End If

            var loopTo = m;
            for (j = 0; j <= loopTo; j++)
                v[j] = j * 0 + 1;
            var loopTo1 = m;
            for (j = 0; j <= loopTo1; j++)
                n[j] = CommonN;
            ng = 0;
            var loopTo2 = m;
            for (j = 0; j <= loopTo2; j++)
                // Debug.Print (Str(j) + Str(N(j)))
                ng = ng + n[j];
            Rank = new int[ng + 1 + 1];
            var loopTo3 = ng;
            for (j = 0; j <= loopTo3; j++)
                Rank[j] = j;
            FinalX = new double[2];
            FinalR = new int[2, 2];
            CalcRankSums(m, ng, ref n, ref v, ref Rank, linear, ref score, ref FinalSize, ref FinalX, ref FinalR);
            // Define and set mode !!!!


            Mode = 2;
            Mode = 1;
            Prob = new double[2];
            x = new double[2];

            CalcStats(Mode, m, FinalSize, ref FinalX, ref FinalR, ref nlength, ref Prob, ref x);

            // For i = 0 To nlength
            // Debug.Print i, x(i), Prob(i)
            // Next i


            Output = new double[nlength + 1, 4];
            Varianz = 12d / (ng * (ng + 1) * CommonN);
            std = Math.Sqrt(Varianz);
            for (i = nlength; i >= 0; i -= 1)
            {
                p1 = Prob[i];
                pcum = pcum + p1;
                if (Mode == 1)
                    Chi2 = x[i] * Varianz;
                else
                    Chi2 = x[i] * std;
                Output[i, 0] = Chi2;
                Output[i, 1] = p1;
                Output[i, 2] = pcum;
                if (Mode == 1)
                {
                    DistMain.cdis2(m, Chi2, ref LeftTail, ref Righttail, ref cdens);
                    Output[i, 3] = Righttail;
                }
                else
                {
                    DistMCP.NormalRangeDis(Chi2 * Math.Sqrt(1d), m + 1, ref LeftTail, ref Righttail);
                    Output[i, 3] = Righttail;
                }
            }
            x = null;
            Prob = null;
            KruskalDemoMainRet = Output;
            return KruskalDemoMainRet;

        }




        public static void CalcStats(int Mode, int m, int FinalSize, ref double[] FinalX, ref int[,] FinalR, ref int nlength, ref double[] Prob, ref double[] x)
        {
            int j;
            int i;
            int mean;
            int sum;
            int sum2;
            int d;
            int vmax;
            double[] Chi2;
            int j1;
            string s2;
            Console.WriteLine("---Final Vector------Size: " + Conversion.Str(FinalSize));
            switch (Mode)
            {
                case 1:
                    {
                        sum = 0;
                        var loopTo = m;
                        for (j = 0; j <= loopTo; j++)
                            sum = sum + FinalR[j, 0];
                        mean = sum / (m + 1);
                        sum2 = 0;
                        var loopTo1 = m;
                        for (j = 0; j <= loopTo1; j++)
                        {
                            d = FinalR[j, 0] - mean;
                            sum2 = sum2 + d * d;
                        }
                        vmax = sum2 + 2;
                        Chi2 = new double[vmax + 1];
                        // ReDim Chi2(10000)
                        var loopTo2 = vmax;
                        for (i = 0; i <= loopTo2; i++)
                            Chi2[i] = 0d;
                        var loopTo3 = FinalSize;
                        for (i = 0; i <= loopTo3; i++)
                        {
                            s2 = Conversion.Str(i) + ".  " + Conversion.Str(FinalX[i]) + ": ";
                            sum2 = 0;
                            var loopTo4 = m;
                            for (j = 0; j <= loopTo4; j++)
                            {
                                d = FinalR[j, i] - mean;
                                sum2 = sum2 + d * d;
                                s2 = s2 + Conversion.Str(FinalR[j, i]);
                                if (j < m)
                                    s2 = s2 + ",";
                            }
                            Chi2[sum2] = Chi2[sum2] + FinalX[i];
                            s2 = s2 + "  ;  " + Conversion.Str(sum2);
                            // Console.WriteLine(s2)
                            // Debug.Print s2
                        }
                        FinalX = null;
                        FinalR = null;
                        Console.WriteLine("Chi2");
                        j = 0;
                        var loopTo5 = vmax;
                        for (i = 0; i <= loopTo5; i++)
                        {
                            if (Chi2[i] > 0d)
                                j = j + 1;
                        }
                        nlength = j - 1;

                        x = new double[nlength + 1];
                        Prob = new double[nlength + 1];
                        j = 0;
                        var loopTo6 = vmax;
                        for (i = 0; i <= loopTo6; i++)
                        {
                            if (Chi2[i] > 0d)
                            {
                                Prob[j] = Chi2[i];
                                x[j] = i;
                                j = j + 1;
                            }
                        }
                        Chi2 = null;
                        break;
                    }
                case 2:
                    {
                        sum = 0;
                        vmax = Math.Abs(FinalR[m, 0]);
                        Chi2 = new double[vmax + 1];
                        var loopTo7 = vmax;
                        for (i = 0; i <= loopTo7; i++)
                            Chi2[i] = 0d;
                        var loopTo8 = FinalSize;
                        for (i = 0; i <= loopTo8; i++)
                        {
                            s2 = Conversion.Str(i) + ".  " + Conversion.Str(FinalX[i]) + ": ";
                            sum2 = 0;
                            var loopTo9 = m;
                            for (j = 0; j <= loopTo9; j++)
                            {
                                var loopTo10 = m;
                                for (j1 = j + 1; j1 <= loopTo10; j1++)
                                {
                                    d = FinalR[j, i] - FinalR[j1, i];
                                    d = Math.Abs(d);
                                    if (d > sum2)
                                        sum2 = d;

                                    s2 = s2 + Conversion.Str(FinalR[j, i]);
                                    if (j < m)
                                        s2 = s2 + ",";
                                }
                            }
                            Chi2[sum2] = Chi2[sum2] + FinalX[i];
                            s2 = s2 + "  ;  " + Conversion.Str(sum2);
                            Console.WriteLine(s2);
                            // Debug.Print s2
                        }
                        FinalX = null;
                        FinalR = null;
                        Console.WriteLine("Chi2");
                        j = 0;
                        var loopTo11 = vmax;
                        for (i = 0; i <= loopTo11; i++)
                        {
                            if (Chi2[i] > 0d)
                                j = j + 1;
                        }
                        nlength = j - 1;

                        x = new double[nlength + 1];
                        Prob = new double[nlength + 1];
                        j = 0;
                        var loopTo12 = vmax;
                        for (i = 0; i <= loopTo12; i++)
                        {
                            if (Chi2[i] > 0d)
                            {
                                Prob[j] = Chi2[i];
                                x[j] = i;
                                j = j + 1;
                            }
                        }
                        Chi2 = null;
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }



        public static void Kruskaldemo2()
        {
            int[] Rank;
            int[] n;
            double[] v;
            int[] score;
            bool linear;
            int m;
            int ng;
            int Mode;
            int j;
            int i;
            // Dim IntCoeff() As Integer, k As Integer, Order As Integer, j As Integer, i As Integer
            var FinalSize = default(int);
            double[] FinalX;
            int[,] FinalR;
            var nlength = default(int);
            double[] Prob;
            double[] x;

            m = 2;  // number of groups -1
                    // linear = True
            linear = false;
            n = new int[m + 1];
            v = new double[m + 1];
            score = new int[m + 1];
            // If linear Then
            // k = m + 1
            // Call GetIntCoeff(k, IntCoeff)
            // ' For order = 1 To k - 1
            // Order = 2
            // Debug.Print "Coeff of order :", Order
            // For j = 1 To k
            // score(j - 1) = IntCoeff(Order, j) + 0
            // Debug.Print j - 1, IntCoeff(Order, j)
            // Next j
            // 'Next order
            // End If

            var loopTo = m;
            for (j = 0; j <= loopTo; j++)
                v[j] = j * 0 + 1;
            var loopTo1 = m;
            for (j = 0; j <= loopTo1; j++)
                n[j] = 5;
            // n(0) = 3
            // For j = 0 To m : n(j) = 10 : Next j
            ng = 0;
            var loopTo2 = m;
            for (j = 0; j <= loopTo2; j++)
                // Debug.Print (Str(j) + Str(N(j)))
                ng = ng + n[j];
            Rank = new int[ng + 1 + 1];
            var loopTo3 = ng;
            for (j = 0; j <= loopTo3; j++)
                Rank[j] = j;
            FinalX = new double[2];
            FinalR = new int[2, 2];

            CalcRankSums(m, ng, ref n, ref v, ref Rank, linear, ref score, ref FinalSize, ref FinalX, ref FinalR);
            Mode = 1;

            Prob = new double[2];
            x = new double[2];

            CalcStats(Mode, m, FinalSize, ref FinalX, ref FinalR, ref nlength, ref Prob, ref x);

            var loopTo4 = nlength;
            for (i = 0; i <= loopTo4; i++)
                Console.WriteLine("i: {0}, x(i): {1}, Prob(i): {2}", i, x[i], Prob[i]);

        }






    }






}