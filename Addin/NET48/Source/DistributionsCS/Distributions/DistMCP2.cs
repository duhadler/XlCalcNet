using System;

namespace Distributions
{



    static class DistMCP2
    {

        private const double sqrtpi = 1.77245385090552d;
        private static double S1;
        private static double S;
        private static double n;
        private static double X;
        private static double N1;
        private static double N2;
        private static double gamman2;
        //private static double Lastvalue;
        private static double lefttail1;
        private static double RightTail1;
        private static int k;
        private static int dis;
        private static int[] L = new int[101];
        private static double[] mu2 = new double[101];
        //private static int i;
        //private static int lmax;
        private static bool IsDuncan;
        //private static bool ShowRange;
        //private static bool ShowSum;
        //private static bool ShowBorder;
        private static double[] mu = new double[101];
        private static double[] xvalue = new double[101];
        private static double[] YValue = new double[101];

        private static double Q(double X)
        {
            double QRet = 0.0;
            double myrho;
            // dis=1: SR, 2: Duncan, 3: SMM1, 4:SMM2, 5: Dunnett1, 6: Dunnett2
            myrho = 0.5d;
            S1 = 1d;
            if (dis == 1)
                DistMCP.NormalRangeDis(X, k, ref lefttail1, ref RightTail1);
            if (dis == 2)
                DistMCP.NormalRangeDis(X, k, ref lefttail1, ref RightTail1);
            if (dis == 3)
                DistMCP.ModulusDisN(false, X, k, ref lefttail1, ref RightTail1, mu, L);
            if (dis == 4)
                DistMCP.ModulusDisN(true, X, k, ref lefttail1, ref RightTail1, mu, L);
            if (dis == 5)
                DistMCP.NMultEqualCorrDisN(false, X, k, myrho, ref lefttail1, ref RightTail1, mu2, L);
            if (dis == 6)
                DistMCP.NMultEqualCorrDisN(true, X, k, myrho, ref lefttail1, ref RightTail1, mu2, L);
            S1 = RightTail1;
            QRet = S1;
            return QRet;
        }

        private static double LnQ(double X)
        {
            double LnQRet = 0.0;
            int k1;
            k1 = k;
            if (dis == 1 | dis == 2)
                k1 = (k + 1) * k / 2;
            S1 = 1d;
            // Call LnModulusDisN(True, True, x, k1, LeftTail1, RightTail1, mu, l)
            DistMCP.LnModulusDisN(true, true, X, k1, ref lefttail1, ref RightTail1);
            S1 = RightTail1;
            LnQRet = S1;
            return LnQRet;
        }

        private static double CalcF(double y)
        {
            double CalcFRet = 0.0;
            double F;
            double f1;
            double f5;
            if (y <= 0d & N1 > 0d)
            {
                CalcFRet = 0d;
            }
            else
            {
                F = -N2 * y * y;
                if (N1 > 0d)
                    f5 = N1 * Math.Log(y);
                else
                    f5 = 0d;
                F = F + f5;
                F = F - gamman2;
                f1 = Q(X * y);
                CalcFRet = Math.Exp(F) * f1;
            }

            return CalcFRet;
        }

        private static double CalcLnF(double y)
        {
            double CalcLnFRet = 0.0;
            double F;
            double f2;
            double f3;
            double f5;
            double C;
            C = 100d;
            if (y <= 0d & N1 > 0d)
                y = 1.0E-100d;
            F = -N2 * y * y;
            if (N1 > 0d)
                f5 = N1 * Math.Log(y);
            else
                f5 = 0d;
            F = F + f5;
            F = F - gamman2;
            // f2 = LnQ(x * y)
            f2 = Math.Log(Q(X * y));
            f3 = F + f2;
            F = -Math.Log(-f3 + C);
            CalcLnFRet = F;
            return CalcLnFRet;
        }

        private static double[] _studdis1_null2 = new double[14];
        private static double[] _studdis1_gew2 = new double[14];

        private static double studdis1(double a, double xm, double b)
        {
            double studdis1Ret = 0.0;
            const int points = 13;
            double sneu;
            double y;
            double F;
            double S1;
            double C;
            double d;
            double S;
            int i;
            if (_studdis1_null2[1] == 0d)
            {
                _studdis1_null2[1] = 0.201128576548871d;
                _studdis1_null2[2] = 0.603921058625552d;
                _studdis1_null2[3] = 1.00833827104672d;
                _studdis1_null2[4] = 1.41552780019819d;
                _studdis1_null2[5] = 1.82674114360369d;
                _studdis1_null2[6] = 2.2433914677615d;
                _studdis1_null2[7] = 2.66713212453562d;
                _studdis1_null2[8] = 3.09997052958644d;
                _studdis1_null2[9] = 3.54444387315535d;
                _studdis1_null2[10] = 4.00390860386123d;
                _studdis1_null2[11] = 4.48305535709252d;
                _studdis1_null2[12] = 4.98891896858994d;
                _studdis1_null2[13] = 5.5331471515675d;

                _studdis1_gew2[1] = 0.402346066701903d;
                _studdis1_gew2[2] = 0.403419816924804d;
                _studdis1_gew2[3] = 0.405605123325684d;
                _studdis1_gew2[4] = 0.408981575003532d;
                _studdis1_gew2[5] = 0.413679363611139d;
                _studdis1_gew2[6] = 0.419895003736824d;
                _studdis1_gew2[7] = 0.427918062932744d;
                _studdis1_gew2[8] = 0.438177022652684d;
                _studdis1_gew2[9] = 0.451321035991189d;
                _studdis1_gew2[10] = 0.468374812564729d;
                _studdis1_gew2[11] = 0.491057995832883d;
                _studdis1_gew2[12] = 0.522525689331355d;
                _studdis1_gew2[13] = 0.569402691949641d;
            }
            F = 5.4d;
            xm = (b + a) / 2d;
            C = xm - a;
            d = xm;
            S = 0d;
            for (i = points; i >= 1; i -= 1)
            {
                y = C * _studdis1_null2[i] / F + d;
                S1 = _studdis1_gew2[i] * CalcF(y);
                // Debug.Print i, y, x * y, s1
                S = S + S1;
            }
            S = C * S / F;
            sneu = 0d;
            C = b - xm;
            d = xm;
            for (i = points; i >= 1; i -= 1)
            {
                y = -C * _studdis1_null2[i] / F + d;
                S1 = _studdis1_gew2[i] * CalcF(y);
                // Debug.Print i, y, x * y, s1
                sneu = sneu + S1;
            }
            sneu = C * sneu / F;
            studdis1Ret = S + sneu;
            return studdis1Ret;
        }

        private static double[] _studdis2_null0 = new double[21];
        private static double[] _studdis2_gew0 = new double[21];

        private static double studdis2(double a, double xm, double b)
        {
            double studdis2Ret = 0.0;
            const int points = 20;
            double y;
            double S1;
            double S;
            int i;

            if (_studdis2_null0[1] == 0d)
            {
                _studdis2_null0[1] = 0.0567047754527055d;
                _studdis2_null0[2] = 0.299010898586989d;
                _studdis2_null0[3] = 0.735909555435016d;
                _studdis2_null0[4] = 1.36918311603519d;
                _studdis2_null0[5] = 2.20132605372147d;
                _studdis2_null0[6] = 3.23567580355804d;
                _studdis2_null0[7] = 4.47649661507383d;
                _studdis2_null0[8] = 5.92908376270045d;
                _studdis2_null0[9] = 7.59989930995675d;
                _studdis2_null0[10] = 9.49674922093243d;
                _studdis2_null0[11] = 11.6290149117788d;
                _studdis2_null0[12] = 14.0079579765451d;
                _studdis2_null0[13] = 16.6471255972888d;
                _studdis2_null0[14] = 19.5628980114691d;
                _studdis2_null0[15] = 22.775241986835d;
                _studdis2_null0[16] = 26.3087723909689d;
                _studdis2_null0[17] = 30.1942911633161d;
                _studdis2_null0[18] = 34.471097571922d;
                _studdis2_null0[19] = 39.1906088039374d;
                _studdis2_null0[20] = 44.422349336162d;

                _studdis2_gew0[1] = 0.145549737845463d;
                _studdis2_gew0[2] = 0.33934977178631d;
                _studdis2_gew0[3] = 0.534736592221058d;
                _studdis2_gew0[4] = 0.732224872375163d;
                _studdis2_gew0[5] = 0.932615901494606d;
                _studdis2_gew0[6] = 1.1367925903897d;
                _studdis2_gew0[7] = 1.34572933788286d;
                _studdis2_gew0[8] = 1.56051904645081d;
                _studdis2_gew0[9] = 1.78240922631583d;
                _studdis2_gew0[10] = 2.01284914982045d;
                _studdis2_gew0[11] = 2.25355250263736d;
                _studdis2_gew0[12] = 2.50658251263117d;
                _studdis2_gew0[13] = 2.77447044296858d;
                _studdis2_gew0[14] = 3.06038486968816d;
                _studdis2_gew0[15] = 3.36838056665888d;
                _studdis2_gew0[16] = 3.70377658323782d;
                _studdis2_gew0[17] = 4.07375278882884d;
                _studdis2_gew0[18] = 4.48833451696969d;
                _studdis2_gew0[19] = 4.96210931402317d;
                _studdis2_gew0[20] = 5.51743186577412d;
            }
            S = 0d;
            // Debug.Print "Show Sum Short"
            for (i = points; i >= 1; i -= 1)
            {
                y = a + b * _studdis2_null0[i] / 45d;
                S1 = _studdis2_gew0[i] * CalcF(y);
                // Debug.Print i, y, x * y, s1
                S = S + S1;
            }
            S = b * S / 45d;
            studdis2Ret = S;
            return studdis2Ret;
        }


        private static double studdis(double X)
        {
            double studdisRet = 0.0;
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
            int MaxCount;
            int LeftX;
            int MidX;
            int RightX;
            if (n == 1d)
                n = 1.000001d;
            N1 = n - 1d;
            N2 = n / 2d;
            gamman2 = DistMain.LnGamma(N2) + (N2 - 1d) * Math.Log(2d) - N2 * Math.Log(n);
            if (n > 14d)
                Ratio = Math.Log(0.00000001d);
            else
                Ratio = Math.Log(0.000000001d);
            // Debug.Print "ratio:", ratio
            a = 0.6d;
            b = 1.5d;
            xm = a + (b - a) / 2d;
            if (n == 1d)
                n = 1.000001d;
            if (n == 1d)
            {
                a = 0d;
                xm = 0d;
            }
            // Debug.Print "a:", a, "b:", b, "xm:", xm
            LeftX = 49;
            MidX = 50;
            RightX = 51;
            XPos[LeftX] = a;
            XPos[RightX] = b;
            XPos[MidX] = xm;
            var loopTo = RightX;
            for (i = LeftX; i <= loopTo; i++)
                // Debug.Print i, XValue(i)
                xvalue[i] = CalcLnF(XPos[i]);
            if (n == 1d)
            {
                NewMaxValue = xvalue[MidX];
                goto GetRightBorder;
            }
            while (xvalue[RightX] > xvalue[MidX])
            {
                RightX = RightX + 1;
                XPos[RightX] = XPos[RightX - 1] * 1.5d;
                xvalue[RightX] = CalcLnF(XPos[RightX]);
                MidX = MidX + 1;
            }
            while (xvalue[LeftX] > xvalue[MidX])
            {
                LeftX = LeftX - 1;
                XPos[LeftX] = XPos[LeftX + 1] / 10d;
                xvalue[LeftX] = CalcLnF(XPos[LeftX]);
                // Debug.Print XPos(LeftX), XValue(LeftX)
                MidX = MidX - 1;
            }
            LeftX = MidX - 1;
            RightX = MidX + 1;

            DistMCP.NewtonInter(LeftX, RightX - LeftX + 1, XPos, xvalue, deriv);
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
                        NewMaxPos = DistMCP.interpolate(true, 0d, kl, kR - kl, deriv, XPos);
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

                NewMaxValue = CalcLnF(NewMaxPos);
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
                DistMCP.NewtonInter(LeftX, RightX - LeftX + 1, XPos, xvalue, deriv);
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

            NewMaxValue = -Math.Exp(-NewMaxValue) + Ratio;
            NewMaxValue = -Math.Log(-NewMaxValue);

            if (n < 6d & n > 1d)
            {
                a = Math.Pow(10d, n - 10d);
                goto GetRightBorder;
            }
            // Debug.Print "LeftBorder, NewMaxValue:", NewMaxValue
            MaxCount = 0;
            while (xvalue[LeftX] > NewMaxValue)
            {
                LeftX = LeftX - 1;
                XPos[LeftX] = XPos[LeftX + 1] / 6d;
                xvalue[LeftX] = CalcLnF(XPos[LeftX]);
                // Debug.Print XPos(LeftX), XValue(LeftX)
            }
            // LR: rechte grenze der besten schätzung für Leftborder
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
                    NewLPos = DistMCP.interpolate(true, NewMaxValue, LeftX, MidX - LeftX, xvalue, XPos);
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
                NewLValue = CalcLnF(NewLPos);
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
            // Debug.Print "Iteration: ", MaxCount
            // Debug.Print "LeftX, MidX, LR, RightX", LeftX, MidX, LR, RightX
            // For i = MidX To LeftX Step -1
            // Debug.Print XPos(i), XValue(i)
            // Next i

            a = NewLPos;

        GetRightBorder:
            ;

            NewMaxValue = -Math.Exp(-NewMaxValue) + Ratio;
            NewMaxValue = -Math.Log(-NewMaxValue);

            // Debug.Print "RightBorder"
            MaxCount = 0;
            while (xvalue[RightX] > NewMaxValue)
            {
                RightX = RightX + 1;
                XPos[RightX] = XPos[RightX - 1] * 2d;
                xvalue[RightX] = CalcLnF(XPos[RightX]);
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
                    NewLPos = DistMCP.interpolate(true, NewMaxValue, MidX, RightX - MidX, xvalue, XPos);
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
                NewLValue = CalcLnF(NewLPos);
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
            if (n > 14d)
                studdisRet = studdis1(a, xm, b);
            else
                studdisRet = studdis2(a, xm, b);
            return studdisRet;
        }

        public static void MCPdis3(int dis_1, int k_1, double n_1, double x_1, ref double LeftTail, ref double RightTail)
        {
            int i;
            dis = dis_1;
            k = k_1;
            n = n_1;
            X = x_1;
            var loopTo = k;
            for (i = 0; i <= loopTo; i++)
            {
                L[i] = 1;
                mu[i] = 0d;
            }
            //ShowSum = true;
            //ShowRange = true;
            //ShowBorder = true;
            if (dis == 1 | dis == 2)
                X = X * Math.Sqrt(2d);
            if (dis == 2)
            {
                dis = 1;
                IsDuncan = true;
            }
            else
            {
                IsDuncan = false;
            }
            if (n > 0d & n < 1d)
                n = 1d;
            if (n > 1000000.0d | n <= 0d)
                S = Q(X);
            else
                S = studdis(X);
            RightTail = S;
            LeftTail = 1d - RightTail;
            if (IsDuncan)
            {
                LeftTail = Math.Exp(Math.Log(LeftTail) / k); // (*Duncan*)
                RightTail = 1d - LeftTail;
            }
        }

        public static void DemoMCP3()
        {
            Console.WriteLine("");
            Console.WriteLine("Hello DemoMCP3!");
            int i;
            int k;
            var LeftTail = default(double);
            var RightTail = default(double);
            double X;
            double n;
            var mu = new double[101]; // , l1 As Double, r1 As Double
            k = 1;
            n = 14.0d;
            X = 4.1d;
            var loopTo = k;
            for (i = 0; i <= loopTo; i++)
                mu[i] = 0d;
            mu[1] = 0d;
            MCPdis3(4, k, n, X, ref LeftTail, ref RightTail);
            Console.WriteLine("LeftTail: {0}, RightTail: {1}", LeftTail, RightTail);
            // LeftTail = tdisn(n, x, mu(1)): RightTail = tdisn(n, -x, mu(1))
            // Debug.Print LeftTail, RightTail, LeftTail - RightTail
            RightTail = DistN.Fdisn(1d, n, X * X, mu[1] * mu[1]);
            LeftTail = 1d - RightTail;
            Console.WriteLine("LeftTail: {0}, RightTail: {1}", LeftTail, RightTail);
            // Call Logndis2(x - mu(1), LeftTail, RightTail)
            // Debug.Print LeftTail, RightTail, x - mu(1)
        }


        private static double ManyOneDisX2(int MCP, double LeftTail, double RightTail, int Proc, int m, double n)
        {
            double temp, L, r;
            switch (Proc)
            {
                case 0:
                    {
                        return DistX.Tdisx(LeftTail, RightTail, n);
                    }
                case 1:
                    {
                        temp = DistX.fdisx(LeftTail, RightTail, 1d, n);
                        return Math.Sqrt(temp);
                    }
                case 2:
                    {
                        return Dunnett1disx(LeftTail, RightTail, m, n);
                    }
                case 3:
                    {
                        return Dunnett2disx(LeftTail, RightTail, m, n);
                    }
                case 4:
                    {
                        r = RightTail / m;
                        L = 1d - r;
                        return DistX.Tdisx(L, r, n);
                    }
                case 5:
                    {
                        r = RightTail / m;
                        L = 1d - r;
                        temp = DistX.fdisx(L, r, 1d, n);
                        return Math.Sqrt(temp);
                    }

                default:
                    {
                        Console.WriteLine("Außerhalb");
                        return 0d;
                    }
            }
        }

        private static double MCPDisX3(int dis, int m, double n, double LeftTail2, double RightTail2)
        {
            double MCPDisX3Ret = 0.0;
            double sg;
            double S;
            double x1;
            double fx1;
            var p1 = default(double);
            double x2;
            double fx2;
            double fx3;
            double x3;
            double delta;
            var LeftTail = default(double);
            var RightTail = default(double);
            //bool show;
            double sg2;
            //bool show = true;
            S = LeftTail2;
            sg2 = RightTail2;
            sg = S;
            switch (dis)
            {
                case 1:
                case 2:
                    {
                        S = 1d - (1d - S) / 2d;
                        p1 = Math.Exp(Math.Log(S) / ((m + 1) * m / 2d));
                        if (dis == 2)
                            p1 = Math.Exp(Math.Log(p1) * (m - 1));
                        break;
                    }
                case 3:
                case 4:
                case 5:
                case 6:
                    {
                        if (dis == 4 | dis == 6)
                            S = 1d - (1d - S) / 2d;
                        p1 = Math.Exp(Math.Log(S) / m);
                        break;
                    }
            }
            x1 = DistX.Tdisx(p1, 1d - p1, n);
            if (m == 1)
            {
                MCPDisX3Ret = x1;
                return MCPDisX3Ret;
            }
            MCPdis3(dis, m, n, x1, ref LeftTail, ref RightTail);
            fx1 = RightTail;
            // If show Then Debug.Print x1, fx1
            x2 = 0.95d * x1;
            MCPdis3(dis, m, n, x2, ref LeftTail, ref RightTail);
            fx2 = RightTail;
            // If show Then Debug.Print x2, fx2
            do
            {
                x3 = x1 - (x2 - x1) / (fx2 - fx1) * (fx1 - sg2);
                MCPdis3(dis, m, n, x3, ref LeftTail, ref RightTail);
                fx3 = RightTail;
                delta = Math.Abs(fx3 - sg2) / sg2;
                x1 = x2;
                x2 = x3;
                fx1 = fx2;
                fx2 = fx3;
            }
            // If show Then Debug.Print x3, fx3, delta
            while (delta >= 0.000000000001d);
            MCPDisX3Ret = x3;
            return MCPDisX3Ret;
        }

        public static double SRdis(int m, double n, double X, ref double LeftTail, ref double RightTail)
        {
            double SRdisRet = 0.0;
            MCPdis3(1, m, n, X, ref LeftTail, ref RightTail);
            SRdisRet = LeftTail;
            return SRdisRet;
        }

        public static double Duncandis(int m, double n, double X, ref double LeftTail, ref double RightTail)
        {
            double DuncandisRet = 0.0;
            MCPdis3(2, m, n, X, ref LeftTail, ref RightTail);
            DuncandisRet = LeftTail;
            return DuncandisRet;
        }

        public static double SMM1dis(int m, double n, double X, ref double LeftTail, ref double RightTail)
        {
            double SMM1disRet = 0.0;
            MCPdis3(3, m, n, X, ref LeftTail, ref RightTail);
            SMM1disRet = LeftTail;
            return SMM1disRet;
        }

        public static double SMM2dis(int m, double n, double X, ref double LeftTail, ref double RightTail)
        {
            double SMM2disRet = 0.0;
            MCPdis3(4, m, n, X, ref LeftTail, ref RightTail);
            SMM2disRet = LeftTail;
            return SMM2disRet;
        }

        public static double Dunnett1dis(int m, double n, double X, ref double LeftTail, ref double RightTail)
        {
            double Dunnett1disRet = 0.0;
            MCPdis3(5, m, n, X, ref LeftTail, ref RightTail);
            Dunnett1disRet = LeftTail;
            return Dunnett1disRet;
        }

        public static double Dunnett2dis(int m, double n, double X, ref double LeftTail, ref double RightTail)
        {
            double Dunnett2disRet = 0.0;
            MCPdis3(6, m, n, X, ref LeftTail, ref RightTail);
            Dunnett2disRet = LeftTail;
            return Dunnett2disRet;
        }

        public static double SRdisx(double LeftTail, double RightTail, int m, double n)
        {
            double SRdisxRet = 0.0;
            SRdisxRet = MCPDisX3(1, m, n, LeftTail, RightTail);
            return SRdisxRet;
        }

        public static double Duncandisx(double LeftTail, double RightTail, int m, double n)
        {
            double DuncandisxRet = 0.0;
            DuncandisxRet = MCPDisX3(2, m, n, LeftTail, RightTail);
            return DuncandisxRet;
        }

        public static double SMM1disx(double LeftTail, double RightTail, int m, double n)
        {
            double SMM1disxRet = 0.0;
            SMM1disxRet = MCPDisX3(3, m, n, LeftTail, RightTail);
            return SMM1disxRet;
        }

        public static double SMM2disx(double LeftTail, double RightTail, int m, double n)
        {
            double SMM2disxRet = 0.0;
            SMM2disxRet = MCPDisX3(4, m, n, LeftTail, RightTail);
            return SMM2disxRet;
        }

        public static double Dunnett1disx(double LeftTail, double RightTail, int m, double n)
        {
            double Dunnett1disxRet = 0.0;
            Dunnett1disxRet = MCPDisX3(5, m, n, LeftTail, RightTail);
            return Dunnett1disxRet;
        }

        public static double Dunnett2disx(double LeftTail, double RightTail, int m, double n)
        {
            double Dunnett2disxRet = 0.0;
            Dunnett2disxRet = MCPDisX3(6, m, n, LeftTail, RightTail);
            return Dunnett2disxRet;
        }

        public static void demoMCP2()
        {
            int m;
            double n;
            var LeftTail = default(double);
            var RightTail = default(double);
            double result;
            double d;
            m = 3; // number of groups - 1
            n = 14d;
            d = 0d;
            X = 3.1d;

            result = Dunnett1dis(m, n, X, ref LeftTail, ref RightTail);
            Console.WriteLine("result: {0}", result);
            result = DistN.tdisn(n, X, d, ref LeftTail, ref RightTail);
            Console.WriteLine("result:  {0}", result);

            // result = Dunnett2dis(m, n, X, LeftTail, RightTail)
            // Console.WriteLine("result: {0}", result)
            // result = tdisn(n, X, d, LeftTail, RightTail) - tdisn(n, -X, d, LeftTail, RightTail)
            // Console.WriteLine("result:  {0}", result)

            // result = SRdis(m, n, X, LeftTail, RightTail)
            // Console.WriteLine("result: {0}", result)
            // result = tdisn(n, X / Math.Sqrt(2), d, LeftTail, RightTail) - tdisn(n, -X / Math.Sqrt(2), d, LeftTail, RightTail)
            // Console.WriteLine("result:  {0}", result)
            // result = result ^ (m * (m + 1) / 2)
            // Console.WriteLine("result:  {0}", result)

        }



    }
}