using System;

namespace Distributions
{



    static class DistMCP
    {



        private const double NegMax = -1.79769313486231E+308d;
        private const double sqrt2pi = 0.398942280401433d;
        //private static double Lastvalue;
        private static double X;
        private static int k;
        private static int lmax;
        private static double[] mu = new double[101];
        private static double[] lambda = new double[101];
        private static int[] L = new int[101];
        //private static bool ShowRange;
        private static bool twosided;
        private static bool UseRightTail;
        private static bool range;
        //private static bool ShowSums;
        //private static bool ShowBorders;




        public static double interpolate(bool UseRational, double X, int start, int n, double[] xt, double[] t0)
        {
            double interpolateRet = 0.0;
            var t = new double[21, 21];
            var x0 = new double[21];
            int i;
            int k;
            double d;
            double o;
            double U;
            double RelError;
            double result2;
            // Dim UseRational As Boolean
            // UseRational = False
            k = 0;
            var loopTo = n;
            for (i = 0; i <= loopTo; i++)
            {
                t[i, 0] = t0[i + start];
                x0[i] = xt[i + start];
                // Debug.Print i, k, t(i, k), x0(i)
            }
            // For i = 0 To n
            // If Abs((x0(i) - x) / x) < 0.00000000000001 Then
            // Debug.Print "Replace", i, x0(i), x
            // interpolate = t(i, 0)
            // Exit Function
            // End If
            // Next i

            // Debug.Print "-------------"
            result2 = t0[0];
            RelError = 1d;
            k = 0;
            while (k < n & RelError > 0.0000000000000001d)
            {
                k = k + 1;
                var loopTo1 = n;
                for (i = k; i <= loopTo1; i++)
                {
                    o = t[i, k - 1] - t[i - 1, k - 1];
                    U = t[i, k - 1];
                    if (k > 1)
                        U = U - t[i - 1, k - 2];
                    if (UseRational & U != 0d)
                        d = o / U;
                    else
                        d = 0d;
                    U = (X - x0[i - k]) / (X - x0[i]) * (1d - d) - 1d;
                    t[i, k] = t[i, k - 1] + o / U;
                    // Debug.Print i, k, T(i, k)
                }
                RelError = Math.Abs((result2 - t[n, k]) / t[n, k]);
                // Debug.Print "RelError: ", RelError
                result2 = t[n, k];
            }
            // Debug.Print "RelError: ", RelError
            interpolateRet = result2;
            return interpolateRet;
        }

        public static void NewtonInter(int start, int n, double[] xt, double[] yt, double[] deriv)
        {
            var a = new double[101];
            var b = new double[101];
            var X = new double[101];
            var y = new double[101];
            int i;
            int j;
            int k;
            double y2;
            var loopTo = n;
            for (i = 1; i <= loopTo; i++)
            {
                X[i] = xt[i + start - 1];
                y[i] = yt[i + start - 1];
            }
            a[1] = y[1];
            var loopTo1 = n - 1;
            for (j = 1; j <= loopTo1; j++)
            {
                var loopTo2 = n - j;
                for (i = 1; i <= loopTo2; i++)
                    y[i] = (y[i + 1] - y[i]) / (X[i + j] - X[i]);
                a[j + 1] = y[1];
            }
            b[n] = a[n];
            for (k = n - 1; k >= 1; k -= 1)
            {
                for (j = n - 1; j >= 1; j -= 1)
                    b[j] = a[j];
                var loopTo3 = k;
                for (i = n - 1; i >= loopTo3; i -= 1)
                    a[i] = a[i] - b[i + 1] * X[k];
            }
            var loopTo4 = n;
            for (j = 1; j <= loopTo4; j++)
            {
                // y1 = a(n)
                // For i = n - 1 To 1 Step -1
                // y1 = y1 * x(j) + a(i)
                // Next i
                y2 = (n - 1) * a[n];
                for (i = n - 1; i >= 2; i -= 1)
                    y2 = y2 * X[j] + (i - 1) * a[i];
                deriv[j + start - 1] = y2;
                // Debug.Print x(j), y1, y(j)
                // Debug.Print x(j), y(j)
            }
        }


        private static double Hoch(double RightTail, double k)
        {
            double HochRet = 0.0;
            double z;
            double z2;
            double z3;
            double sum;
            double i;

            if (RightTail >= 1d)
            {
                HochRet = 1d;
                return HochRet;
            }
            if (RightTail > 0.01d)
            {
                HochRet = 1d - Math.Exp(Math.Log(1d - RightTail) * k);
                return HochRet;
            }
            z2 = RightTail;
            z3 = z2;
            z = -RightTail;
            sum = z;
            i = 1d;
            do
            {
                i = i + 1d;
                z2 = z2 * z3;
                sum = sum - z2 / i;
            }
            while (sum != sum + z2 / i);
            sum = sum * k;
            z = sum;
            z2 = z;
            i = 1d;
            do
            {
                i = i + 1d;
                z2 = z2 * z / i;
                sum = sum + z2;
            }
            while (sum != sum + z2);
            HochRet = -sum;
            return HochRet;
        }

        private static double LogHoch(bool UseLog, bool ReturnLog, double y, double k)
        {
            double LogHochRet = 0.0;
            double z;
            double z2;
            double z3;
            double sum;
            double i;
            double RightTail;
            if (k == 1d)
            {
                if (UseLog & !ReturnLog)
                {
                    LogHochRet = Math.Exp(y);
                }
                else if (!UseLog & ReturnLog)
                {
                    LogHochRet = Math.Log(y);
                }
                else
                {
                    LogHochRet = y;
                }
                return LogHochRet;
            }
            RightTail = y;
            if (UseLog)
            {
                if (RightTail < -50)
                {
                    z = RightTail + Math.Log(k);
                    if (ReturnLog)
                        LogHochRet = z;
                    else
                        LogHochRet = Math.Exp(z);
                    return LogHochRet;
                }
                else
                {
                    RightTail = Math.Exp(y);
                }
            }
            if (1d - RightTail <= 0d)
            {
                if (ReturnLog)
                    LogHochRet = 0d;
                else
                    LogHochRet = 1d;
                return LogHochRet;
            }
            if (RightTail > 0.1d)
            {
                z = 1d - Math.Exp(Math.Log(1d - RightTail) * k);
                if (ReturnLog)
                    LogHochRet = Math.Log(z);
                else
                    LogHochRet = z;
                return LogHochRet;
            }
            z2 = RightTail;
            z3 = z2;
            z = -RightTail;
            sum = z;
            i = 1d;
            do
            {
                i = i + 1d;
                z2 = z2 * z3;
                sum = sum - z2 / i;
            }
            while (sum != sum + z2 / i);
            sum = sum * k;
            z = sum;
            z2 = z;
            i = 1d;
            do
            {
                i = i + 1d;
                z2 = z2 * z / i;
                sum = sum + z2;
            }
            while (sum != sum + z2);
            if (ReturnLog)
                LogHochRet = Math.Log(-sum);
            else
                LogHochRet = -sum;
            return LogHochRet;
        }

        private static double CalcFRange3(bool ReturnLog, double X, double y)
        {
            double CalcFRange3Ret = 0.0;
            var l1 = default(double);
            var r1 = default(double);
            var l2 = default(double);
            var r2 = default(double); // , F As Double
            double LogZ;
            double Logf;
            var d1 = default(double);
            bool LocalUseLog; // , UseLeftTail As Boolean
            double Q1;
            double q2;
            LocalUseLog = true;
            // If y < 0 Then UseLeftTail = True Else UseLeftTail = False
            DistMain.ndis2(LocalUseLog, y, ref l1, ref r1, ref d1);
            DistMain.ndis2(LocalUseLog, y - X, ref l2, ref r2, ref d1);
            LogZ = -y * y / 2d + Math.Log((k + 1) * sqrt2pi);
            // If UseLeftTail Then LogDiff = Log(LeftTail1 - LeftTail2) _
            // Else: LogDiff = Log(RightTail2 - RightTail1)
            if (LocalUseLog)
                Q1 = l1 * k;
            else
                Q1 = Math.Log(l1) * k;
            if (LocalUseLog)
                q2 = l2 - l1;
            else
                q2 = l2 / l1;
            q2 = LogHoch(LocalUseLog, true, q2, k);
            Logf = LogZ + Q1 + q2;
            // Logf = Logz + LogDiff * k
            if (ReturnLog)
                CalcFRange3Ret = Logf;
            else
                CalcFRange3Ret = Math.Exp(Logf);
            return CalcFRange3Ret;
        }

        private static double AddLogs(double X, double y, double a, double b)
        {
            double AddLogsRet = 0.0;
            // Calculates ln(exp(x) + a * exp(y-x) - b* exp(y))
            double S;
            double t;
            if (X < y)
                DistMain.SwapTails(ref X, ref y);
            t = a * Math.Exp(y - X);
            if (b != 0d)
                t = t - b * Math.Exp(y);
            S = DistMain.LogZPlusA(t, 1d);
            AddLogsRet = X + S;
            return AddLogsRet;
        }

        private static double CalcFNMult(bool ReturnLog, double X, double y)
        {
            double CalcFNMultRet = 0.0;
            var lefttail1 = default(double);
            var RightTail1 = default(double);
            var LeftTail2 = default(double);
            var RightTail2 = default(double);
            var d1 = default(double);
            double fR;
            //double F;
            int i;
            double z;
            double result;
            double C;
            double d;
            bool LocalUseLog;
            double LogZ;
            LocalUseLog = true;
            z = Math.Exp(-y * y / 2d) * sqrt2pi;
            LogZ = -y * y / 2d + Math.Log(sqrt2pi);
            //double F = 1d;
            fR = 0d;
            var loopTo = lmax;
            for (i = 1; i <= loopTo; i++)
            {
                C = mu[i] + lambda[i] * y;
                d = Math.Sqrt(1d - lambda[i] * lambda[i]);
                DistMain.ndis2(LocalUseLog, (X - C) / d, ref lefttail1, ref RightTail1, ref d1);
                if (twosided)
                {
                    DistMain.ndis2(LocalUseLog, (-X - C) / d, ref LeftTail2, ref RightTail2, ref d1);
                    // LeftTail1 = LeftTail1 - LeftTail2
                    // Debug.Print "log R1,R2,L1,L2:", RightTail1, RightTail2, LeftTail1, LeftTail2
                    if (LocalUseLog)
                        RightTail1 = AddLogs(RightTail1, LeftTail2, 1d, 0d);
                    else
                        RightTail1 = RightTail1 + LeftTail2;
                }
                if (LocalUseLog)
                    fR = LogHoch(LocalUseLog, true, RightTail1, L[i]);
                else
                    fR = Hoch(RightTail1, L[i]);
                // For j = 1 To l(i)
                // f = f * LeftTail1
                // fR = fR + RightTail1 - (fR * RightTail1)
                // Next j
            }
            // If UseRightTail Then
            // Debug.Print "Use Righttail"
            if (ReturnLog)
                result = LogZ + fR;
            else
                result = Math.Exp(LogZ + fR);
            // Else
            // Result = f * z
            // End If
            CalcFNMultRet = result;
            return CalcFNMultRet;
            // Debug.Print "x, Result:", x, Result
        }

        private static double CalcFRange(double X, double y)
        {
            double CalcFRangeRet = 0.0;
            var lefttail1 = default(double);
            var RightTail1 = default(double);
            var LeftTail2 = default(double);
            var RightTail2 = default(double);
            var d1 = default(double);
            double sum;
            double S1;
            double s2;
            double prod;
            int j1;
            int m;
            int i;
            int j;
            sum = 0d;
            var loopTo = lmax;
            for (i = 0; i <= loopTo; i++)
            {
                S1 = Math.Exp(-(y - mu[i]) * (y - mu[i]) / 2d) * sqrt2pi;
                prod = 1d;
                var loopTo1 = lmax;
                for (j = 0; j <= loopTo1; j++)
                {
                    if (!(i == j & L[i] == 1))
                    {
                        DistMain.ndis2(false, y - mu[j], ref lefttail1, ref RightTail1, ref d1);
                        DistMain.ndis2(false, y - mu[j] - X, ref LeftTail2, ref RightTail2, ref d1);
                        s2 = lefttail1 - LeftTail2;
                        if (i == j)
                            m = L[j] - 1;
                        else
                            m = L[j];
                        var loopTo2 = m;
                        for (j1 = 1; j1 <= loopTo2; j1++)
                            prod = prod * s2;
                    }
                }
                sum = sum + S1 * prod * L[i];
            }
            CalcFRangeRet = sum;
            return CalcFRangeRet;
        }

        private static double CalcF2(double y)
        {
            double CalcF2Ret = 0.0;
            if (range)
                CalcF2Ret = CalcFRange3(false, X, y);
            else
                CalcF2Ret = CalcFNMult(false, X, y);
            return CalcF2Ret;
        }

        private static double CalcLnF2(double y)
        {
            double CalcLnF2Ret = 0.0;
            if (range)
                CalcLnF2Ret = CalcFRange3(true, X, y);
            else
                CalcLnF2Ret = CalcFNMult(true, X, y);
            return CalcLnF2Ret;
        }

        private static double[] _studdis12_null4 = new double[11];
        private static double[] _studdis12_gew4 = new double[11];

        private static double studdis12(double a, double xm, double b)
        {
            double studdis12Ret = 0.0;
            const int points = 10;
            double sneu;
            double y;
            double F;
            double S1;
            double C;
            double d;
            double S;
            int i;
            if (_studdis12_null4[1] == 0d)
            {
                _studdis12_null4[1] = 0.245340708300901d;
                _studdis12_null4[2] = 0.737473728545394d;
                _studdis12_null4[3] = 1.23407621539532d;
                _studdis12_null4[4] = 1.73853771211659d;
                _studdis12_null4[5] = 2.25497400208928d;
                _studdis12_null4[6] = 2.78880605842813d;
                _studdis12_null4[7] = 3.34785456738322d;
                _studdis12_null4[8] = 3.94476404011563d;
                _studdis12_null4[9] = 4.60368244955074d;
                _studdis12_null4[10] = 5.38748089001123d;
                _studdis12_gew4[1] = 0.490921500666746d;
                _studdis12_gew4[2] = 0.493843385272053d;
                _studdis12_gew4[3] = 0.499920871336291d;
                _studdis12_gew4[4] = 0.509679027117458d;
                _studdis12_gew4[5] = 0.524080350948558d;
                _studdis12_gew4[6] = 0.54485174236452d;
                _studdis12_gew4[7] = 0.575262442852503d;
                _studdis12_gew4[8] = 0.622278696191412d;
                _studdis12_gew4[9] = 0.704332961176942d;
                _studdis12_gew4[10] = 0.898591961453191d;
            }
            F = 5.4d;
            xm = (b + a) / 2d;
            C = xm - a;
            d = xm;
            S = 0d;
            for (i = points; i >= 1; i -= 1)
            {
                y = C * _studdis12_null4[i] / F + d;
                S1 = C * _studdis12_gew4[i] / F * CalcF2(y);
                // Debug.Print y, s1
                S = S + S1;
            }
            sneu = 0d;
            C = b - xm;
            d = xm;
            for (i = points; i >= 1; i -= 1)
            {
                y = -C * _studdis12_null4[i] / F + d;
                S1 = C * _studdis12_gew4[i] / F * CalcF2(y);
                // Debug.Print y, s1
                sneu = sneu + S1;
            }
            studdis12Ret = S + sneu;
            return studdis12Ret;
        }

        private static double q2()
        {
            double q2Ret = 0.0;
            double xm;
            double a;
            double b;
            double NewMaxValue;
            double NewMaxPos;
            double Ratio;
            double LastMaxPos;
            int i;
            int kl;
            int kR;
            var XPos = new double[101];
            var xvalue = new double[101];
            var deriv = new double[101];
            int C1;
            double NewLPos;
            double NewLValue;
            int Lr;
            int MaxCount, LeftX;
            int MidX;
            int RightX;
            Ratio = Math.Log(0.0000000001d);
            b = 3.8d;
            a = -3.5d;
            xm = a + (b - a) / 2d;
            // Debug.Print "a:", a, "b:", b
            LeftX = 49;
            MidX = 50;
            RightX = 51;
            XPos[LeftX] = a;
            XPos[RightX] = b;
            XPos[MidX] = xm;
            var loopTo = RightX;
            for (i = LeftX; i <= loopTo; i++)
                xvalue[i] = CalcLnF2(XPos[i]);
            while (xvalue[RightX] > xvalue[MidX])
            {
                RightX = RightX + 1;
                // XPos(RightX) = XPos(RightX - 1) * 1.5
                XPos[RightX] = XPos[RightX - 1] + Math.Abs(XPos[RightX - 1] - XPos[RightX - 2]) * 2d;
                xvalue[RightX] = CalcLnF2(XPos[RightX]);
                MidX = MidX + 1;
            }
            while (xvalue[LeftX] > xvalue[MidX])
            {
                LeftX = LeftX - 1;
                XPos[LeftX] = XPos[LeftX + 1] - Math.Abs(XPos[LeftX + 1] - XPos[LeftX + 2]) * 2d;
                // XPos(LeftX) = XPos(LeftX + 1) / 10
                xvalue[LeftX] = CalcLnF2(XPos[LeftX]);
                // Debug.Print XPos(LeftX), XValue(LeftX)
                MidX = MidX - 1;
            }
            LeftX = MidX - 1;
            RightX = MidX + 1;
            // For i = LeftX To RightX
            // Debug.Print XPos(i), XValue(i)
            // Next i
            NewtonInter(LeftX, RightX - LeftX + 1, XPos, xvalue, deriv);
            // Debug.Print "Grenzen"
            // For i = LeftX To RightX: Debug.Print XPos(i), XValue(i), Deriv(i): Next i
            MaxCount = 0;
            do
            {
                MaxCount = MaxCount + 1;
                var loopTo1 = RightX;
                for (i = LeftX; i <= loopTo1; i++)
                {
                    if (xvalue[i] > xvalue[MidX])
                        MidX = i;
                }
                LastMaxPos = XPos[MidX];
                kl = MidX;
                kR = kl;
                while (kR < RightX & kR < MidX + 5 & deriv[kR + 1] < deriv[kR])
                    kR = kR + 1;
                while (kl > LeftX & kl > MidX - 5 & deriv[kl - 1] > deriv[kl])
                    kl = kl - 1;
                // Debug.Print "MidX, kL, kR"
                // Debug.Print MidX, kL, kR
                if (MidX == kl | MidX == kR)
                {
                    // Debug.Print "!!!!Ableitungen nicht korrekt"
                    if (Math.Abs(xvalue[MidX - 1] - xvalue[MidX]) > Math.Abs(xvalue[MidX + 1] - xvalue[MidX]))
                        C1 = -1;
                    else
                        C1 = 1;
                    NewMaxPos = (XPos[MidX] + XPos[MidX + C1]) / 2d;
                }
                else
                {
                    if (deriv[MidX] < 0d)
                        C1 = -1;
                    else
                        C1 = 1;
                    C1 = -(kR + kl) + 2 * MidX + C1;
                    if (Math.Abs(C1) >= 2)
                    {
                        // Debug.Print "!!!Symmetrie: Adjustment"
                        if (C1 < 0)
                            C1 = -1;
                        else
                            C1 = 1;
                        NewMaxPos = (XPos[MidX] + XPos[MidX + C1]) / 2d;
                    }
                    else
                    {
                        NewMaxPos = interpolate(true, 0d, kl, kR - kl, deriv, XPos);
                        if (NewMaxPos <= XPos[MidX - 1])
                        {
                            NewMaxPos = (XPos[MidX] + XPos[MidX - 1]) / 2d;
                        }
                        // Debug.Print "Halbierung: Interpolation zu ungenau"
                        else if (NewMaxPos >= XPos[MidX + 1])
                        {
                            NewMaxPos = (XPos[MidX] + XPos[MidX + 1]) / 2d;
                        }
                        // Debug.Print "Halbierung: Interpolation zu ungenau"
                        else
                        {
                            // Debug.Print "Interpolation"
                        }
                    }
                }

                NewMaxValue = CalcLnF2(NewMaxPos);
                i = RightX;
                while (XPos[i] > NewMaxPos)
                {
                    XPos[i + 1] = XPos[i];
                    xvalue[i + 1] = xvalue[i];
                    i = i - 1;
                }
                RightX = RightX + 1;
                kR = kR + 1;
                XPos[i + 1] = NewMaxPos;
                xvalue[i + 1] = NewMaxValue;
                NewMaxValue = xvalue[LeftX];
                var loopTo2 = RightX;
                for (i = LeftX + 1; i <= loopTo2; i++)
                {
                    deriv[i] = 0d;
                    if (xvalue[i] > NewMaxValue)
                    {
                        NewMaxValue = xvalue[i];
                        MidX = i;
                    }
                }
                NewtonInter(LeftX, RightX - LeftX + 1, XPos, xvalue, deriv);
            }
            // Debug.Print "Iteration: ", MaxCount
            // For i = LeftX To RightX
            // Debug.Print i, XPos(i), XValue(i), Deriv(i)
            // Next i
            // Debug.Print "MidX:", MidX, "Deriv(MidX):", Deriv(MidX)
            while (!(Math.Abs(deriv[MidX]) < 0.00001d | MaxCount == 20));
            xm = XPos[MidX];
            // Debug.Print "Iteration: ", MaxCount
            // For i = LeftX To RightX
            // Debug.Print i, XPos(i), XValue(i), Deriv(i)
            // Next i
            // Debug.Print "MidX:", MidX, "Deriv(MidX):", Deriv(MidX)

            NewMaxValue = NewMaxValue + Ratio;
            MaxCount = 0;
            while (xvalue[LeftX] > NewMaxValue)
            {
                LeftX = LeftX - 1;
                XPos[LeftX] = XPos[LeftX + 1] - Math.Abs(XPos[LeftX + 1] - XPos[LeftX + 2]) * 2d;
                xvalue[LeftX] = CalcLnF2(XPos[LeftX]);
                // Debug.Print XPos(LeftX), XValue(LeftX)
            }
            // LR: rechte grenze der besten schätzung für lightborder
            Lr = LeftX + 1;
            while (Lr < MidX & xvalue[Lr] < NewMaxValue)
                Lr = Lr + 1;

            do
            {
                MaxCount = MaxCount + 1;
                if (Lr == MidX & Lr - 1 == LeftX)
                {
                    NewLPos = (XPos[Lr] + XPos[Lr - 1]) / 2d;
                }
                // Debug.Print "Halbierung: nur 2 stützpunkte"
                else
                {
                    // NewLPos = interpolate(NewMaxValue, MidX, RightX - MidX, XValue(), XPos())
                    NewLPos = interpolate(true, NewMaxValue, LeftX, MidX - LeftX, xvalue, XPos);
                    if (NewLPos < XPos[Lr - 1] | NewLPos > XPos[Lr])
                    {
                        NewLPos = (XPos[Lr - 1] + XPos[Lr]) / 2d;
                    }
                    // Debug.Print "Halbierung: Interpolation zu ungenau"
                    else
                    {
                        // Debug.Print "Interpolation"
                    }
                }
                NewLValue = CalcLnF2(NewLPos);
                if (NewLValue > NewMaxValue)
                    Lr = Lr - 1;
                // Debug.Print NewLPos, NewLValue
                i = LeftX;
                while (XPos[i] < NewLPos)
                {
                    XPos[i - 1] = XPos[i];
                    xvalue[i - 1] = xvalue[i];
                    i = i + 1;
                }
                LeftX = LeftX - 1;
                XPos[i - 1] = NewLPos;
                xvalue[i - 1] = NewLValue;
            }
            while (Math.Abs(NewMaxValue - NewLValue) >= 0.0000001d);
            a = NewLPos;

        //GetRightBorder:
            //;

            // Debug.Print -Exp(-NewMaxValue)
            // NewMaxValue = -Exp(-NewMaxValue) + ratio
            // NewMaxValue = -Log(-NewMaxValue)
            // Debug.Print "NewMaxValue: ", NewMaxValue
            // NewMaxValue = NewMaxValue + ratio

            // Debug.Print "RightBorder", NewMaxValue
            MaxCount = 0;
            while (xvalue[RightX] > NewMaxValue)
            {
                RightX = RightX + 1;
                // XPos(RightX) = XPos(RightX - 1) * 2
                XPos[RightX] = XPos[RightX - 1] + Math.Abs(XPos[RightX - 1] - XPos[RightX - 2]) * 2d;
                xvalue[RightX] = CalcLnF2(XPos[RightX]);
                // Debug.Print XPos(RightX), XValue(RightX)
            }
            // LR: linke grenze der besten schätzung für rightborder
            Lr = RightX - 1;
            while (Lr > MidX & xvalue[Lr] < NewMaxValue)
                Lr = Lr - 1;

            do
            {
                MaxCount = MaxCount + 1;
                if (Lr == MidX & Lr + 1 == RightX)
                {
                    NewLPos = (XPos[Lr] + XPos[Lr + 1]) / 2d;
                }
                // Debug.Print "Halbierung: nur 2 stützpunkte"
                else
                {
                    NewLPos = interpolate(true, NewMaxValue, MidX, RightX - MidX, xvalue, XPos);
                    if (NewLPos < XPos[Lr] | NewLPos > XPos[Lr + 1])
                    {
                        NewLPos = (XPos[Lr] + XPos[Lr + 1]) / 2d;
                    }
                    // Debug.Print "Halbierung: Interpolation zu ungenau"
                    else
                    {
                        // Debug.Print "Interpolation"
                    }
                }
                NewLValue = CalcLnF2(NewLPos);
                if (NewLValue > NewMaxValue)
                    Lr = Lr + 1;
                // Debug.Print NewLPos, NewLValue
                i = RightX;
                while (XPos[i] > NewLPos)
                {
                    XPos[i + 1] = XPos[i];
                    xvalue[i + 1] = xvalue[i];
                    i = i - 1;
                }
                RightX = RightX + 1;
                XPos[i + 1] = NewLPos;
                xvalue[i + 1] = NewLValue;
            }
            while (Math.Abs(NewMaxValue - NewLValue) >= 0.0000001d);
            // Debug.Print "Iteration: ", MaxCount
            // Debug.Print "LeftX, MidX, LR, RightX", LeftX, MidX, LR, RightX
            // For i = MidX To RightX
            // Debug.Print XPos(i), XValue(i)
            // Next i

            b = NewLPos;
            // Debug.Print "a, xm, b"
            // Debug.Print a, xm, b

            // a = -b
            // xm = 0
            // Debug.Print "a, xm, b"
            // Debug.Print a, xm, b
            // 
            q2Ret = studdis12(a, xm, b);
            return q2Ret;
        }

        private static void MCP2(bool range1, bool Twosided1, double x1, int k1, int lmax1, ref double LeftTail, ref double RightTail, double[] lambda1, double[] mu1, int[] l1)
        {
            // x :  Stelle, an der die Funktion ausgewertet wird
            // k :  Zahl der Blöcke mit unterschiedlichen Umfängen/Mittelwerten,
            // außer Block 0 = Standard  (NMult)
            // k :  Zahl der Gruppen - 1 (Range)
            // lambda :  Zerlegung sodaß rho_ij = lambda_i*lambda_j
            // mu :  Mittelwerte der Blöcke
            // l :  Zahl der Gruppen in Block l(i)
            // Der Nichtzentralitätsparameter hat folgende Struktur as
            // mu(0) wird immer gleich 0 gesetzt
            // mu(i) (i>0) enthält die Differenz von mu(i) zu mu(0)
            int i;
            range = range1;
            twosided = Twosided1;
            X = x1;
            k = k1;
            lmax = lmax1;
            var loopTo = lmax;
            for (i = 0; i <= loopTo; i++)
            {
                mu[i] = mu1[i];
                lambda[i] = lambda1[i];
                L[i] = l1[i];
            }
            //ShowSums = false;
            //ShowBorders = false;
            //ShowRange = false;
            UseRightTail = true;
            if (UseRightTail)
            {
                RightTail = q2();
                LeftTail = 1d - RightTail;
            }
            else
            {
                LeftTail = q2();
                RightTail = 1d - LeftTail;
            }
        }

        private static void NMultDis(bool twosided, double X, int k, int lmax, ref double LeftTail, ref double RightTail, double[] lambda, double[] mu, int[] L)
        {
            MCP2(false, twosided, X, k, lmax, ref LeftTail, ref RightTail, lambda, mu, L);
        }

        public static void NormalRangeDis(double X, int k, ref double LeftTail, ref double RightTail)
        {
            var mu = new double[101];
            var lambda = new double[101];
            var L = new int[101];
            int i;
            var loopTo = lmax;
            for (i = 0; i <= loopTo; i++)
            {
                mu[i] = 0d;
                lambda[i] = 1d;
                L[i] = 1;
            }
            MCP2(true, true, X, k, 1, ref LeftTail, ref RightTail, lambda, mu, L);
        }

        private static void NormalRangeDisN(double X, int k, int lmax, double[] mu, int[] L, double LeftTail, double RightTail)
        {
            var lambda = default(double[]);
            int i;
            var loopTo = lmax;
            for (i = 0; i <= loopTo; i++)
                lambda[i] = 1d / Math.Sqrt(2d);
            MCP2(true, true, X, k, lmax, ref LeftTail, ref RightTail, lambda, mu, L);
        }

        private static void ManyOneDis22(bool twosided, double X, int k, int lmax, double[] n, double[] mu, int[] L, double LeftTail, double RightTail)
        {
            // x : Stelle, an der die Funktion ausgewertet wird
            // k :  Zahl der Blöcke mit unterschiedlichen Umfängen/Mittelwerten,
            // außer Block 0 = Standard
            // n :  Stichprobenumfänge der Blöcke
            // mu :  Mittelwerte der Blöcke
            // l :  Zahl der Gruppen in Block l(i)

            int i;
            var lambda = default(double[]);
            var loopTo = k;
            for (i = 1; i <= loopTo; i++)
                lambda[i] = 1.0d / Math.Sqrt(1d + n[0] / n[i]);
            NMultDis(twosided, X, k, lmax, ref LeftTail, ref RightTail, lambda, mu, L);
        }

        // 
        // Sub NMultEqualCorrDis(ByVal Twosided As Boolean, ByVal x As Double, mu1() As Double, _
        // ByVal rho As Double, ByVal k As Integer, LeftTail As Double, RightTail As Double)
        // Dim mu(0 To 100) As Double, lambda(0 To 100) As Double, l(0 To 100) As Integer
        // l(1) = k
        // mu(1) = mu1(1)
        // lambda(1) = Sqr(rho)
        // k = 1
        // Call NMultDis(Twosided, x, k, k, lambda(), mu(), l(), LeftTail, RightTail)
        // End Sub

        public static void NMultEqualCorrDisN(bool twosided, double X, int k, double rho, ref double LeftTail, ref double RightTail, double[] mu, int[] L)
        {
            int i;
            var lambda = new double[101];
            int lmax;
            lmax = 1;
            L[1] = k;
            var loopTo = k;
            for (i = 1; i <= loopTo; i++)
                lambda[i] = Math.Sqrt(rho);
            NMultDis(twosided, X, k, lmax, ref LeftTail, ref RightTail, lambda, mu, L);
        }

        public static void LnModulusDisN(bool ReturnLog, bool twosided, double X, int k, ref double LeftTail, ref double RightTail, double[] mu = null, int[] L = null)
        {
            var F = default(double);
            var fR = default(double);
            var l1 = default(double);
            var r1 = default(double);
            var l2 = default(double);
            var r2 = default(double);
            bool First;
            int i;
            var p = default(double);
            var d = default(double);
            var d1 = default(double);
            if (mu == null)
            {
                p = k;
                k = 1;
                d = 0d;
            }
            if (!(mu == null) & L == null)
                p = 1d;
            First = true;
            var loopTo = k;
            for (i = 1; i <= loopTo; i++)
            {
                if (!(mu == null))
                    d = mu[i];
                DistMain.ndis2(true, X - d, ref l1, ref r1, ref d1);
                if (twosided)
                {
                    DistMain.ndis2(true, -X - d, ref l2, ref r2, ref d1);
                    r1 = AddLogs(r1, l2, 1d, 0d);
                    if (l1 == l2)
                    {
                        l1 = -1.0E+20d;
                    }
                    else
                    {
                        l1 = AddLogs(l1, l2, -1, 0d);
                    }
                }
                if (!(L == null))
                    p = L[i];
                l1 = l1 * p;
                r1 = LogHoch(true, true, r1, p);
                if (First)
                {
                    First = false;
                    F = l1;
                    fR = r1;
                }
                else
                {
                    F = F + l1;
                    fR = AddLogs(fR, r1, 1d, 1d);
                }
            }
            if (ReturnLog)
            {
                LeftTail = F;
                RightTail = fR;
            }
            else
            {
                LeftTail = Math.Exp(F);
                RightTail = Math.Exp(fR);
            }
        }

        public static void ModulusDisN(bool twosided, double X, int k, ref double LeftTail, ref double RightTail, double[] mu = null, int[] L = null)
        {
            var fR = default(double);
            var F = default(double);
            var l1 = default(double);
            var r1 = default(double);
            var l2 = default(double);
            var r2 = default(double);
            bool First;
            int i;
            var p = default(double);
            var d = default(double);
            var d1 = default(double);
            if (mu == null)
            {
                p = k;
                k = 1;
                d = 0d;
            }
            if (!(mu == null) & L == null)
                p = 1d;
            First = true;
            var loopTo = k;
            for (i = 1; i <= loopTo; i++)
            {
                if (!(mu == null))
                    d = mu[i];
                DistMain.ndis2(false, X - d, ref l1, ref r1, ref d1);
                if (twosided)
                {
                    DistMain.ndis2(false, -X - d, ref l2, ref r2, ref d1);
                    r1 = r1 + l2;
                    l1 = l1 - l2;
                }
                if (!(L == null))
                    p = L[i];
                if (l1 < 1.0E-60d)
                    l1 = 0d;
                else
                    l1 = Math.Exp(Math.Log(l1) * p);
                r1 = Hoch(r1, p);
                if (First)
                {
                    First = false;
                    F = l1;
                    fR = r1;
                }
                else
                {
                    F = F * l1;
                    fR = fR + r1 - fR * r1;
                }
            }
            LeftTail = F;
            RightTail = fR;
        }

        private static void bonferroni(bool twosided, double x1, int k, double[] mu1, int[] L, double LeftTail, double RightTail)
        {
            int i;
            var lefttail1 = default(double);
            var RightTail1 = default(double);
            var LeftTail2 = default(double);
            var RightTail2 = default(double);
            var d1 = default(double);
            RightTail = 0d;
            var loopTo = k;
            for (i = 1; i <= loopTo; i++)
            {
                DistMain.ndis2(false, x1 - mu1[i], ref lefttail1, ref RightTail1, ref d1);
                if (twosided)
                {
                    DistMain.ndis2(false, -x1 - mu1[i], ref LeftTail2, ref RightTail2, ref d1);
                    RightTail1 = RightTail1 + LeftTail2;
                }
                RightTail = RightTail + RightTail1 * L[i];
            }
            LeftTail = 1d - RightTail;
        }

        private static void MCPdis(int PChoice, bool twosided, double X, double rho, int k, double[] n, double[] lambda, double[] mu, int[] L, double LeftTail, double RightTail)
        {
            switch (PChoice)
            {
                case 1:
                    {
                        ModulusDisN(twosided, X, k, ref LeftTail, ref RightTail);
                        break;
                    }
                case 2:
                    {
                        ModulusDisN(twosided, X, k, ref LeftTail, ref RightTail, mu, L);
                        break;
                    }
                case 3:
                    {
                        NMultEqualCorrDisN(twosided, X, k, rho, ref LeftTail, ref RightTail, mu, L);
                        break;
                    }
                case 4:
                    {
                        ManyOneDis22(twosided, X, k, k, n, mu, L, LeftTail, RightTail);
                        break;
                    }
                case 5:
                    {
                        NMultDis(twosided, X, k, k, ref LeftTail, ref RightTail, lambda, mu, L);
                        break;
                    }
                case 6:
                    {
                        NormalRangeDis(X, k, ref LeftTail, ref RightTail);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        private static void test43()
        {
            double y;
            double k;
            double z;
            k = 1d;
            y = 1.0E-18d;
            y = y * 10d;
            z = Math.Log(y);
            Console.WriteLine("y: {0}, LogZPlusA(y, 1): {1}, Math.Log(y): {02", y, DistMain.LogZPlusA(y, 1d), Math.Log(y));
            Console.WriteLine("Hoch(y, k): {0}, k * y: {1}", Hoch(y, k), k * y);
            Console.WriteLine("Math.Log(Hoch(y, k)): {0}, Math.Log(k) + z: {1}, LogHoch(True, True, z, k): {2}", Math.Log(Hoch(y, k)), Math.Log(k) + z, LogHoch(true, true, z, k));
            Console.WriteLine("LogHoch(False, True, y, k): {0}, LogHoch(False, False, y, k): {1}", LogHoch(false, true, y, k), LogHoch(false, false, y, k));
        }

        public static void DemoRange()
        {
            Console.WriteLine("");
            Console.WriteLine("Hello DemoRange!");
            double x1;
            var LeftTail = default(double);
            var RightTail = default(double);
            int k;
            range = true;
            x1 = 0.96d;
            k = 5;
            NormalRangeDis(x1 * Math.Sqrt(2d), k, ref LeftTail, ref RightTail);
            Console.WriteLine("Result:");
            Console.WriteLine("x1: {0}, LeftTail: {1}, RightTail: {2}", x1, LeftTail, RightTail);
            LnModulusDisN(false, true, x1, k * (k + 1) / 2, ref LeftTail, ref RightTail);
            Console.WriteLine("x1: {0}, LeftTail: {1}, RightTail: {2}", x1, LeftTail, RightTail);
            LnModulusDisN(false, true, x1, k, ref LeftTail, ref RightTail);
            Console.WriteLine("x1: {0}, LeftTail: {1}, RightTail: {2}", x1, LeftTail, RightTail);
            // Call LnModulusDisN(True, True, x1, k * (k + 1) \ 2, LeftTail, RightTail)
            // Console.WriteLine("x1: {0}, Math.Exp(LeftTail): {0}, Math.Exp(RightTail): {0}", x1, Math.Exp(LeftTail), Math.Exp(RightTail))
            // Console.WriteLine("x1: {0}, RightTail: {1}, LeftTail: {2}", x1, RightTail, LeftTail)
        }

        public static void DemoModulus()
        {
            Console.WriteLine("");
            Console.WriteLine("Hello DemoModulus!");
            var LeftTail = default(double);
            var RightTail = default(double);
            double x1;
            int k1;
            int i;
            int k2;
            var mu1 = new double[101];
            var l1 = new int[101];
            bool twosided;
            twosided = true;
            x1 = 4.9d;
            k1 = 6;
            Console.WriteLine("Means:");
            k2 = 0;
            var loopTo = k1;
            for (i = 1; i <= loopTo; i++)
            {
                mu1[i] = 1.5d * i / 2d;
                Console.WriteLine("i: {0}, mu1(i): {1}", i, mu1[i]);
                l1[i] = i;
                k2 = k2 + l1[i];
            }
            Console.WriteLine("Result:");
            // Call ModulusDis(Twosided, x1, k2, LeftTail, RightTail)
            // Debug.Print k2, LeftTail, RightTail
            ModulusDisN(twosided, x1, k2, ref LeftTail, ref RightTail);
            Console.WriteLine("k1: {0}, LeftTail: {1}, RightTail: {2}", k1, LeftTail, RightTail);
            ModulusDisN(twosided, x1, k1, ref LeftTail, ref RightTail, mu1, l1);
            Console.WriteLine("k1: {0}, LeftTail: {1}, RightTail: {2}", k1, LeftTail, RightTail);
            LnModulusDisN(true, twosided, x1, k1, ref LeftTail, ref RightTail, mu1, l1);
            Console.WriteLine("k1: {0}, LeftTail: {1}, RightTail: {2}", k1, Math.Exp(LeftTail), Math.Exp(RightTail));
            // Call bonferroni(Twosided, x1, k1, mu1(), l1(), LeftTail, RightTail)
            // Debug.Print k1, LeftTail, RightTail
        }

        public static void DemoDunnett()
        {
            Console.WriteLine("");
            Console.WriteLine("Hello DemoDunnett!");
            double x1;
            int k1;
            var LeftTail = default(double);
            var RightTail = default(double);
            bool twosided;
            var mu1 = new double[101];
            var L = new int[101];
            var LeftTail2 = default(double);
            var RightTail2 = default(double);
            var d1 = default(double);
            x1 = 6.021d;
            k1 = 4;
            mu1[1] = 0d;
            mu1[2] = mu1[1];
            twosided = true;
            // Call NMultEqualCorrDisN(twosided, X1, k1, 1 / 2, LeftTail, RightTail)
            NMultEqualCorrDisN(twosided, x1, k1, 1d / 2d, ref LeftTail, ref RightTail, mu1, L);
            Console.WriteLine("Result:");
            Console.WriteLine("k1: {0}, x1: {1}, LeftTail: {2}, RightTail: {3}", k1, x1, LeftTail, RightTail);
            LnModulusDisN(false, twosided, x1, k1, ref LeftTail, ref RightTail, mu);
            Console.WriteLine("k1: {0}, x1: {1}, LeftTail: {2}, RightTail: {3}", k1, x1, LeftTail, RightTail);
            DistMain.ndis2(false, x1 - mu1[1], ref LeftTail, ref RightTail, ref d1);
            if (twosided)
            {
                DistMain.ndis2(false, -x1 - mu1[1], ref LeftTail2, ref RightTail2, ref d1);
                RightTail = RightTail + LeftTail2;
                LeftTail = LeftTail - LeftTail2;
            }
            Console.WriteLine("k1: {0}, x1: {1}, LeftTail: {2}, RightTail: {3}", k1, x1, LeftTail, RightTail);
        }






    }
}