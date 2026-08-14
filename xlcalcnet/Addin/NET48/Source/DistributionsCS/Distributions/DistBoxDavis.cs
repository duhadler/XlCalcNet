using System;
using FixedPrecNet;

namespace Distributions
{


    static class DistBoxDavis
    {



        public static void BoxFApprox(string result, double f1, ref double m, double omeg1, double omeg2, ref double LeftTail, ref double RightTail)
        {
            double f2;
            double A1;
            double A2;
            double C;
            double b;
            double x;
            A1 = 2d * omeg1 / f1;
            A2 = 4d * omeg2 / f1;
            C = A2 - A1 * A1;
            x = 1d;
            if (C > 0d)
            {
                f2 = (f1 + 2d) / C;
                b = f1 / (1d - A1 - f1 / f2);
                if (result == "PValue")
                    x = m / b;
            }
            else
            {
                f2 = -(f1 + 2d) / C;
                b = f2 / (1d - A1 + 2.0d / f2);
                if (result == "PValue")
                    x = f2 * m / (f1 * (b - m));
            }
            if (result == "PValue")
            {
                // LeftTail = Fdisn(f1, f2, x, 0, l1, r1)
                // RightTail = 1 - LeftTail
                LeftTail = DistN.Fdisn2(f1, f2, x, 0d, ref LeftTail, ref RightTail);
            }
            else
            {
                x = DistX.fdisx(f1, f2, LeftTail, RightTail);
                if (C > 0d)
                    m = x * b;
                else
                    m = b / (f2 / (f1 * x) + 1d);
            }
        }


        public static void DavisPercentile(double f, ref double x, double LeftTail, double RightTail, double rho, double[] o)
        {
            double p1;
            double p2;
            double p3;
            double p4;
            double P5;
            double p6;
            double P7;
            double P22;
            double P32;
            double P42;
            double P33;
            double P222;
            double P52;
            double P43;
            double P322;
            double f2;
            double f3;
            double f4;
            double f5;
            double f6;
            double f7;
            double f12;
            double f13;
            double f22;
            double S1;
            double u;
            double u2;
            double u3;
            double u4;
            double u5;
            double u6;
            double u7;
            double sum;
            var s = new double[8];
            int i;
            bool show;
            show = true;
            Console.WriteLine("LeftTail: {0}, RightTail: {1}", LeftTail, RightTail);
            u = DistX.cdisx(LeftTail, RightTail, f);
            Console.WriteLine("u: {0}", u);
            f2 = f * (f + 2d);
            f3 = f2 * (f + 4d);
            f4 = f3 * (f + 6d);
            f5 = f4 * (f + 8d);
            f6 = f5 * (f + 10d);
            f7 = f6 * (f + 12d);
            f12 = f * f;
            f13 = f12 * f;
            f22 = f2 * f2;
            u2 = u * u;
            u3 = u * u2;
            u4 = u * u3;
            u5 = u * u4;
            u6 = u * u5;
            u7 = u * u6;
            S1 = u2 * (3d * f + 4 * 2 - 2d) / (f2 * f2) + u3 * (3d * f + 4 * 3 - 2d) / (f2 * f3) + u4 * (3d * f + 4 * 4 - 2d) / (f2 * f4) + u5 * (3d * f + 4 * 5 - 2d) / (f2 * f5);


            p1 = u / f;
            p2 = p1 + u2 / f2;
            p3 = p2 + u3 / f3;
            p4 = p3 + u4 / f4;
            P5 = p4 + u5 / f5;
            p6 = P5 + u6 / f6;
            P7 = p6 + u7 / f7;
            P22 = -8 * u4 * (f + 3d) / (f2 * f4) + 8d * u3 / (f2 * f3) + 6d * u2 / (f * f2) + 2d * u / f12;
            P32 = -12 * u5 * (f + 4d) / (f2 * f5) - 2d * u4 * (f - 6d) / (f2 * f4) + 2d * u3 * (3d * f + 10d) / (f2 * f3) + 6d * u2 / (f * f2) + 2d * u / f12;
            P42 = -16 * u6 * (f + 5d) / (f2 * f6) - 4d * u5 * (f - 4d) / (f2 * f5) + 2d * u4 * (3d * f + 14d) / (f2 * f4) + 2d * u3 * (3d * f + 10d) / (f2 * f3) + 6d * u2 / (f * f2) + 2d * u / f12;
            P33 = -6 * u6 * (3d * f12 + 30d * f + 80d) / (f3 * f6) - 6d * u5 * (f2 + 2d * f - 16d) / (f3 * f5) + 4d * u4 * (f + 12d) / (f2 * f4) + 4d * u3 * (3d * f + 8d) / (f2 * f3) + 6d * u2 / (f * f2) + 2d * u / f12;
            P222 = 32d * u6 * (7d * f12 + 62d * f + 120d) / (f22 * f6) - 32d * u5 * (2d * f12 + 37d * f + 96d) / (f22 * f5) - 8d * u4 * (23d * f12 + 124d * f + 132d) / (f22 * f4) - 8d * u3 * (f - 10d) / (f * f2 * f3) + 28d * u2 / (f12 * f2) + 4d * u / f13;
            P52 = -20 * u7 * (f + 6d) / (f2 * f7) - 2d * u6 * (3d * f - 10d) / (f2 * f6) + S1 + 2d * u / f12;
            P43 = -24 * u7 * (f2 + 12d * f + 40d) / (f3 * f7) - 2d * u6 * (5d * f2 + 18d * f - 80d) / (f3 * f6) + 2d * u5 * (f2 + 42d * f + 176d) / (f3 * f5) + 4d * u4 * (3d * f + 16d) / (f2 * f4) + 4d * u3 * (3d * f + 8d) / (f2 * f3) + 6d * u2 / (f * f2) + 2d * u / f12;

            P322 = 192d * u7 * (2d * f13 + 31d * f12 + 154d * f + 240d) / (f2 * f3 * f7) - 16d * u6 * (4d * f13 + 153d * f12 + 1106d * f + 2160d) / (f2 * f3 * f6) - 8d * u5 * (35d * f3 + 420d * f12 + 1540d * f + 1632d) / (f2 * f3 * f5) - 4d * u4 * (25d * f12 + 80d * f + 12d) / (f22 * f4) + 4d * u3 * (7d * f + 38d) / (f * f2 * f3) + 28d * u2 / (f12 * f3) + 4d * u / f13;


            s[2] = o[2] * p2;
            s[3] = o[3] * p3;
            s[4] = o[4] * p4 + 0.5d * Math.Pow(o[2], 2d) * P22;
            s[5] = o[5] * P5 + o[3] * o[2] * P32;
            s[6] = o[6] * p6 + o[4] * o[2] * P42 + 0.5d * Math.Pow(o[3], 2d) * P33 + o[2] * o[2] * o[2] * P222 / 6d;
            s[7] = o[7] * P7 + o[5] * o[2] * P52 + o[4] * o[3] * P43 + 0.5d * o[3] * Math.Pow(o[2], 2d) * P322;
            sum = 0d;
            if (show)
                Console.WriteLine("u: {0}", u);
            for (i = 2; i <= 7; i++)
            {
                sum = sum + s[i];
                if (show)
                    Console.WriteLine("i: {0}, sum: {1}, s(i): {2}", i, sum, s[i]);
            }
            x = u + 2d * sum;
            Console.WriteLine("resultM in DavisPercentile: {0}", x);
            Console.WriteLine("resultM/rho in DavisPercentile: {0}", x / rho);
            // x = x / rho
        }


        public static double Delta(int s, int p)
        {
            double DeltaRet = 0.0;
            double sum;
            int j;
            sum = 0d;
            var loopTo = p - 1;
            for (j = 0; j <= loopTo; j++)
                sum = sum + DistMain.Bernoulli(s, -j / 2d);
            DeltaRet = -sum * (s + 1) / 2d;
            return DeltaRet;
        }


        public static void Box(int cmax, string C_Dis, int C_dfVarCount, int[] C_dfVar, double[] C_dfErr, int C_dfErrCount, ref double C_x, string C_XScale, string C_Algorithm, string C_Result, double C_LeftTail, double C_RightTail)
        {
            double sum;
            double Mur;
            var z = default(double);
            double f;
            double b;
            double mu;
            double rho;
            double S1;
            double s2;
            double s3;
            double sigma2;
            double sigma3;
            int k;
            int p;
            int j;
            int r;
            int s;
            int i;
            var ss = new double[101];
            var omega = new double[101];
            double BK;
            double ks;
            double TWO;
            double nu;
            double n;
            double rhor;
            double NS;
            double ps;
            var d = new double[101];
            var Beta = new double[101];
            var nr = new double[101];

            b = 1d;
            S1 = 1d;
            p = 1;
            Mur = 1d;
            s2 = 1d;
            k = 1;
            n = 1d;
            rho = 1d;
            mu = 1d;
            nu = 1d;
            TWO = 1d;
            ks = 1d;
            f = 1.0d;
            rhor = 1d;
            NS = 1d;
            ps = 1d;
            switch (C_Dis ?? "")
            {

                // Independence of sets of variates
                // (*************************************************************
                // *  Note: P.dfErr(1) is equivalent to the sample size       *
                // *        to make results match those of the UDIS            *
                // *        sub, use                                     *
                // *        UDisX(P.dfVar(1),P.dfVar(2),P.dfErr(1)-P.dfVar(2), *
                // *        P.x,P.LeftTail,P.RightTail)                       *
                // *************************************************************)
                case "U1DIS":
                    {
                        S1 = 0d;
                        s2 = 0d;
                        s3 = 0d;
                        ss[0] = 0d;
                        var loopTo = C_dfVarCount;
                        for (i = 1; i <= loopTo; i++)
                        {
                            ss[i] = C_dfVar[i] + ss[i - 1];
                            S1 = S1 + C_dfVar[i];
                            s2 = s2 + Math.Pow(C_dfVar[i], 2d);
                            s3 = s3 + C_dfVar[i] * Math.Pow(C_dfVar[i], 2d);
                        }
                        sigma2 = Math.Pow(S1, 2d) - s2;
                        sigma3 = S1 * Math.Pow(S1, 2d) - s3;
                        f = sigma2 / 2d;
                        n = C_dfErr[1];
                        rho = 1d - (2d * sigma3 + 3d * sigma2) / (12d * f * n);
                        z = rho * C_x;
                        Console.WriteLine("C_x: {0}, z: {1}, rho: {2}", C_x, z, rho);
                        b = n * (1d - rho);
                        mu = n * rho;
                        Mur = -mu / 2d;
                        break;
                    }

                case "U2DIS":
                    {
                        S1 = 0d;
                        s2 = 0d;
                        s3 = 0d;
                        ss[0] = 0d;
                        var loopTo1 = C_dfVarCount;
                        for (i = 1; i <= loopTo1; i++)
                        {
                            ss[i] = C_dfVar[i] + ss[i - 1];
                            S1 = S1 + C_dfVar[i];
                            s2 = s2 + Math.Pow(C_dfVar[i], 2d);
                            s3 = s3 + C_dfVar[i] * Math.Pow(C_dfVar[i], 2d);
                        }
                        sigma2 = Math.Pow(S1, 2d) - s2;
                        sigma3 = S1 * Math.Pow(S1, 2d) - s3;
                        f = sigma2 / 2d;
                        n = C_dfErr[1];
                        rho = 1d - (2d * sigma3 + 3d * sigma2) / (12d * f * n);
                        z = rho * C_x;
                        Console.WriteLine("C_x: {0}, z: {1}, rho: {2}", C_x, z, rho);
                        b = n * (1d - rho);
                        mu = n * rho;
                        Mur = -mu / 2d;
                        break;
                    }

                // Bartlett Test
                case "L1DIS":
                    {
                        k = C_dfErrCount;
                        p = C_dfVar[1];
                        S1 = 0d;
                        s2 = 0d;
                        n = 0d;
                        var loopTo2 = k;
                        for (i = 1; i <= loopTo2; i++)
                        {
                            n = n + C_dfErr[i];
                            S1 = S1 + 1.0d / C_dfErr[i];
                            s2 = s2 + Math.Pow(1.0d / C_dfErr[i], 2d);
                            nr[i] = 1d;
                        }
                        S1 = S1 - 1.0d / n;
                        rho = 1d - S1 * (2 * p * p + 3 * p - 1) / (6 * (p + 1) * (k - 1));
                        nu = n / k;
                        b = (1d - rho) * nu;
                        mu = -rho * nu;
                        f = (k - 1) * p * (p + 1) / 2d;
                        z = rho * C_x;
                        TWO = 2d;
                        ks = k;
                        d[1] = TWO * (1d - 1.0d / ks) * Delta(1, p);
                        Beta[0] = 1d;
                        Mur = mu;
                        Console.WriteLine("rho: {0}", rho);
                        break;
                    }

                // Equality of normal distributions
                case "L2DIS":
                    {
                        k = C_dfErrCount;
                        p = C_dfVar[1];
                        S1 = 0d;
                        s2 = 0d;
                        n = 0d;
                        var loopTo3 = k;
                        for (i = 1; i <= loopTo3; i++)
                            n = n + C_dfErr[i];
                        var loopTo4 = k;
                        for (i = 1; i <= loopTo4; i++)
                        {
                            S1 = S1 + 1d / C_dfErr[i];
                            s2 = s2 + Math.Pow(1d / C_dfErr[i], 2d);
                        }
                        f = p * (p + 3) * (k - 1) / 2d;
                        rho = 1d - (S1 - 1d / n) * (2.0d * p * p + 9 * p + 11d) / (6 * (k - 1) * (p + 3));
                        mu = n * rho;
                        z = rho * C_x;
                        Console.WriteLine("s2: {0}", s2);
                        Console.WriteLine("f: {0}", f);
                        Console.WriteLine("rho: {0}", rho);
                        break;
                    }
                // If C_XScale = "CHI2RHO" Then z = z / rho

                // Mauchley test for sphericity
                case "LSDIS":
                    {
                        p = C_dfVar[1];
                        n = C_dfErr[1];
                        rho = 1d - (2 * p * p + p + 2.0d) / (6 * p * n);
                        f = (p - 1) * (p + 2.0d) / 2d;
                        z = rho * C_x;
                        b = 1d - rho;
                        NS = 1d;
                        ps = 1d;
                        rhor = rho;
                        d[1] = Delta(1, p) - 0.5d;
                        Beta[0] = 1d;
                        break;
                    }

                // Test for a given covariance matrix
                case "LVCDIS":
                    {
                        p = C_dfVar[1];
                        n = C_dfErr[1];
                        rho = 1d - (2 * p * p + 3 * p - 1.0d) / (6d * n * (p + 1));
                        f = p * (p + 1) / 2d;
                        z = rho * C_x;
                        NS = 1d;
                        b = 1d - rho;
                        rhor = rho;
                        d[1] = Delta(1, p);
                        Beta[0] = 1d;
                        break;
                    }

                // Test for a given covariance matrix and mean vector
                case "LVCMDIS":
                    {
                        p = C_dfVar[1];
                        n = C_dfErr[1];
                        rho = 1d - (2 * p * p + 9 * p + 11.0d) / (6d * n * (p + 3));
                        f = p * (p + 3) / 2d;
                        z = rho * C_x;
                        NS = 1d;
                        b = 1d - rho - 1.0d / n;
                        TWO = 4d;
                        rhor = rho;
                        d[1] = Delta(1, p) + p * 2.0d / TWO;
                        Beta[0] = 1d;
                        break;
                    }

            }


            if (C_Algorithm == "CHI2" | C_Algorithm == "DEF")
            {
                //cmax = cmax;
            }
            else
            {
                rho = 1d;
                cmax = 2;
            }
            var loopTo5 = cmax;
            for (r = 1; r <= loopTo5; r++)
            {
                switch (C_Dis ?? "")
                {

                    // Independence of sets of variates
                    case "U1DIS":
                        {
                            sum = 0d;
                            var loopTo6 = C_dfVarCount;
                            for (i = 2; i <= loopTo6; i++)
                            {
                                var loopTo7 = C_dfVar[i] - 1;
                                for (j = 0; j <= loopTo7; j++)
                                    sum = sum + DistMain.Bernoulli(r + 1, (b - j) / 2d) - DistMain.Bernoulli(r + 1, (b - ss[i - 1] - j) / 2d);
                            }
                            omega[r] = sum / (r * (r + 1) * Mur);
                            Mur = -Mur * mu / 2d;
                            break;
                        }

                    case "U2DIS":
                        {
                            sum = 0d;
                            var loopTo8 = C_dfVarCount;
                            for (i = 2; i <= loopTo8; i++)
                            {
                                var loopTo9 = C_dfVar[i] - 1;
                                for (j = 0; j <= loopTo9; j++)
                                    sum = sum + DistMain.Bernoulli(r + 1, (b - j) / 2d) - DistMain.Bernoulli(r + 1, (b - ss[i - 1] - j) / 2d);
                            }
                            omega[r] = sum / (r * (r + 1) * Mur);
                            Mur = -Mur * mu / 2d;
                            break;
                        }

                    // Bartlett Test
                    case "L1DIS":
                        {
                            TWO = 2d * TWO;
                            ks = ks * k;
                            sum = 0d;
                            var loopTo10 = k;
                            for (i = 1; i <= loopTo10; i++)
                            {
                                nr[i] = nr[i] * nu / C_dfErr[i];
                                sum = sum + nr[i];
                            }
                            d[r + 1] = TWO * (sum / k - 1.0d / ks) * Delta(r + 1, p);
                            Beta[r] = Beta[r - 1] * b;
                            BK = r + 2;
                            sum = 0d;
                            var loopTo11 = r + 1;
                            for (s = 1; s <= loopTo11; s++)
                            {
                                BK = BK * (r + 2 - s) / (s + 1);
                                sum = sum + BK * d[s] * Beta[r + 1 - s];
                            }
                            omega[r] = k * sum / (r * (r + 1) * (r + 2) * Mur);
                            Console.WriteLine("r: {0}, omega(r): {1}", r, omega[r]);
                            Mur = Mur * mu;
                            break;
                        }

                    // Equality of normal distributions
                    case "L2DIS":
                        {
                            if (r != 2)
                            {
                                omega[r] = 0d;
                            }
                            else
                            {
                                Console.WriteLine("s2: {0}", s2);
                                omega[r] = p * (p + 3) / (48d * Math.Pow(rho, 2d)) * ((s2 - 1d / (n * n)) * (p + 1) * (p + 2) - 6d * Math.Pow(1d - rho, 2d) * (k - 1));
                                Console.WriteLine("r: {0}, omega(r): {1}", r, omega[r]);
                            }

                            break;
                        }

                    // Mauchley test for sphericity
                    case "LSDIS":
                        {
                            NS = NS * (n / 2d);
                            ps = ps * p;
                            d[r + 1] = (Delta(r + 1, p) + (r + 2) / 2d * DistMain.Bernoulli(r + 1, 0d) / ps) / NS;
                            Beta[r] = Beta[r - 1] * b;
                            BK = r + 2;
                            sum = 0d;
                            var loopTo12 = r + 1;
                            for (s = 1; s <= loopTo12; s++)
                            {
                                BK = BK * (r + 2 - s) / (s + 1);
                                sum = sum + BK * d[s] * Beta[r + 1 - s];
                            }
                            omega[r] = 2.0d / (r * (r + 1) * (r + 2) * rhor) * sum;
                            if (r % 2 != 0)
                                omega[r] = -omega[r];
                            rhor = rhor * rho;
                            break;
                        }

                    // Test for a given covariance matrix
                    case "LVCDIS":
                        {
                            NS = NS * (n / 2d);
                            d[r + 1] = Delta(r + 1, p) / NS;
                            Beta[r] = Beta[r - 1] * b;
                            BK = r + 2;
                            sum = 0d;
                            var loopTo13 = r + 1;
                            for (s = 1; s <= loopTo13; s++)
                            {
                                BK = BK * (r + 2 - s) / (s + 1);
                                sum = sum + BK * d[s] * Beta[r + 1 - s];
                            }
                            omega[r] = 2.0d / (r * (r + 1) * (r + 2) * rhor) * sum;
                            if (r % 2 != 0)
                                omega[r] = -omega[r];
                            rhor = rhor * rho;
                            break;
                        }

                    // Test for a given covariance matrix and mean vector
                    case "LVCMDIS":
                        {
                            TWO = TWO * 2d;
                            NS = NS * (n / 2d);
                            d[r + 1] = (Delta(r + 1, p) + p * (r + 2) / TWO) / NS;
                            Beta[r] = Beta[r - 1] * b;
                            BK = r + 2;
                            sum = 0d;
                            var loopTo14 = r + 1;
                            for (s = 1; s <= loopTo14; s++)
                            {
                                BK = BK * (r + 2 - s) / (s + 1);
                                sum = sum + BK * d[s] * Beta[r + 1 - s];
                            }
                            omega[r] = 2d / (r * (r + 1) * (r + 2) * rhor) * sum;
                            if (r % 2 != 0)
                                omega[r] = -omega[r];
                            rhor = rhor * rho;
                            break;
                        }
                }
            }

            if (C_Result == "PValue") // Get p-value
            {
                if (C_XScale == "LR")
                    z = -rho * C_dfErr[1] * Math.Log(C_x);
                if (C_Algorithm == "CHI2")
                {
                    // Call BoxDavis1(False, cmax, f, z, omega, C_LeftTail, C_RightTail)
                    Gupta(cmax, f, z / rho, rho, omega);
                }
                else
                {
                    BoxFApprox("PValue", f, ref z, omega[1], omega[2], ref C_LeftTail, ref C_RightTail);
                }
            }
            else
            {
                if (C_Algorithm == "CHI2") // Get percentile
                {
                    DavisPercentile(f, ref z, C_LeftTail, C_RightTail, rho, omega);
                }
                else
                {
                    BoxFApprox("XValue", f, ref z, omega[1], omega[2], ref C_LeftTail, ref C_RightTail);
                }
                if (C_XScale == "LR")
                    z = Math.Exp(-z / C_dfErr[1]);
                if (C_XScale == "CHI2RHO")
                    z = z * rho;
                C_x = z;
            }
        }

        public static void Gupta(int cmax, double f, double z, double rho, double[] omega)
        {
            Console.WriteLine("f: {0}, z: {1}, rho: {2}", f, z, rho);

            double LogKB = 0.0d;
            double sum = DistMain.cdis(f, z);
            var a = new double[101];
            a[0] = 1.0d;
            for (int j = 1, loopTo = cmax; j <= loopTo; j++)
            {
                double temp = 0.0d;
                for (int l = 1, loopTo1 = j; l <= loopTo1; l++)
                    temp = temp + l * omega[l] * a[j - l];
                a[j] = temp / j;
                LogKB = LogKB + omega[j];
                double adj = DistMain.cdis(f + 2 * j, z);
                double adj2 = a[j] * adj;
                sum = sum + adj2;
                if (j % 2 == 0)
                {
                    Console.WriteLine("j: {0}, omega(j): {1}, a(j): {2}, adj: {3}, adj2: {4}", j, omega[j], a[j], adj, adj2);
                }
            }
            double KB = Math.Exp(-LogKB);
            Console.WriteLine("LogKB: {0}, KB: {1}, sum: {2}, LeftTail: {3}", LogKB, KB, sum, KB * sum);
        }


        public static void Udisdemo()
        {

            string C_Dis;
            int C_dfVarCount;
            int[] C_dfVar;
            double[] C_dfErr;
            int C_dfErrCount;
            double C_x;
            string C_XScale;
            string C_Algorithm;
            string C_Result;
            double C_LeftTail;
            double C_RightTail;
            C_Dis = "U1DIS";
            C_dfVarCount = 2;
            C_dfVar = new int[C_dfVarCount + 1];
            C_dfVar[1] = 14;
            C_dfVar[2] = 8;
            C_dfErrCount = 1;
            C_dfErr = new double[C_dfErrCount + 1];
            C_dfErr[1] = 125 + 7;
            C_x = 0.5d;
            C_XScale = "CHI2";
            C_Algorithm = "CHI2";
            C_Result = "XValue";
            C_LeftTail = 0.9d;
            C_RightTail = 1d - C_LeftTail;
            Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, ref C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail);
            Console.WriteLine("Result X: {0}", C_x);
            C_x = C_x * 1d;
            C_Result = "PValue";

            // C_Algorithm = "F"

            Box(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, ref C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail);
            Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail);
        }


        public static void Udis2demo()
        {
            string C_Dis;
            int C_dfVarCount;
            int[] C_dfVar;
            double[] C_dfErr;
            int C_dfErrCount;
            double C_x;
            string C_XScale;
            string C_Algorithm;
            string C_Result;
            double C_LeftTail;
            double C_RightTail;
            int i;
            C_Dis = "U2DIS";
            C_dfVarCount = 15;
            C_dfVar = new int[C_dfVarCount + 1];
            var loopTo = C_dfVarCount;
            for (i = 1; i <= loopTo; i++)
                C_dfVar[i] = 1;
            C_dfErrCount = 1;
            C_dfErr = new double[C_dfErrCount + 1];
            C_dfErr[1] = 125 - 1;
            C_x = 0.5d;
            C_XScale = "CHI2";

            // Using Mathai's tables as comparison, one needs to use "C_XScale = CHI2RHO", not "C_XScale = CHI2" !!!
            // Convergence for n = p + 1
            // C_XScale = "CHI2RHO"
            C_Algorithm = "CHI2";
            C_Result = "XValue";
            C_LeftTail = 0.99d;
            C_RightTail = 1d - C_LeftTail;
            Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, ref C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail);
            Console.WriteLine("Result X: {0}", C_x);
            C_x = C_x * 1d;
            C_Result = "PValue";

            // C_Algorithm = "F"

            Box(10, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, ref C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail);
            Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail);
        }


        public static void Udis3demo()
        {
            string C_Dis;
            int C_dfVarCount;
            int[] C_dfVar;
            double[] C_dfErr;
            int C_dfErrCount;
            double C_x;
            string C_XScale;
            string C_Algorithm;
            string C_Result;
            double C_LeftTail;
            double C_RightTail;
            C_Dis = "U2DIS";
            C_dfVarCount = 5;
            // ReDim C_dfVar(C_dfVarCount)
            C_dfVar = new int[11];
            C_dfVar[1] = 2;
            C_dfVar[2] = 2;
            C_dfVar[3] = 2;
            C_dfVar[4] = 2;
            C_dfVar[5] = 2;
            C_dfErrCount = 1;
            C_dfErr = new double[C_dfErrCount + 1];
            C_dfErr[1] = 46d;
            C_x = 0.5d;
            C_XScale = "CHI2";
            C_Algorithm = "CHI2";
            C_Result = "XValue";
            C_LeftTail = 0.9d;
            C_RightTail = 1d - C_LeftTail;
            Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, ref C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail);
            Console.WriteLine("Result X: {0}", C_x);
            // C_x = C_x * 1
            // C_Result = "PValue"

            // 'C_Algorithm = "F"

            // Call Box(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
            // Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
        }


        // Mauchley test for sphericity
        public static void Mauchlydemo()
        {
            string C_Dis;
            int C_dfVarCount;
            int[] C_dfVar;
            double[] C_dfErr;
            int C_dfErrCount;
            double C_x;
            string C_XScale;
            string C_Algorithm;
            string C_Result;
            double C_LeftTail;
            double C_RightTail;
            C_Dis = "LSDIS";
            C_dfVarCount = 1;
            C_dfVar = new int[C_dfVarCount + 1];
            C_dfVar[1] = 15;  // = p
            C_dfErrCount = 1;
            C_dfErr = new double[C_dfErrCount + 1];
            C_dfErr[1] = 125d;  // = n
            C_x = 0.5d;
            C_XScale = "CHI2";

            // Using Davis's tables as comparison,  one needs to use "C_XScale = CHI2RHO", not "C_XScale = CHI2" !!!
            // Convergence for n = p + 1
            // C_XScale = "CHI2RHO"
            C_Algorithm = "CHI2";
            C_Result = "XValue";
            C_LeftTail = 0.9d;
            C_RightTail = 1d - C_LeftTail;
            Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, ref C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail);
            double p = C_dfVar[1];
            double chix = DistX.cdisx(C_LeftTail, C_RightTail, (p - 1d) * (p + 2d) / 2d);
            Console.WriteLine("p: {0}, n: {1}, chix: {2}", C_dfVar[1], C_dfErr[1], chix);
            Console.WriteLine("X: {0}, ratio: {1}", C_x, C_x / chix);
            // C_x = C_x * 1
            // C_Result = "PValue"

            // 'C_Algorithm = "F"

            // Call Box(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
            // Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
        }


        // Test for a given covariance matrix
        public static void Lvcdemo()
        {
            string C_Dis;
            int C_dfVarCount;
            int[] C_dfVar;
            double[] C_dfErr;
            int C_dfErrCount;
            double C_x;
            string C_XScale;
            string C_Algorithm;
            string C_Result;
            double C_LeftTail;
            double C_RightTail;
            C_Dis = "LVCDIS";
            C_dfVarCount = 1;
            C_dfVar = new int[C_dfVarCount + 1];
            C_dfVar[1] = 6;  // = p
            C_dfErrCount = 1;
            C_dfErr = new double[C_dfErrCount + 1];
            C_dfErr[1] = 20d;  // = n
            C_x = 0.5d;
            C_XScale = "CHI2";

            // Using Davis's tables as comparison.
            // Convergence for n = p + 1
            // C_XScale = "CHI2RHO"
            C_Algorithm = "CHI2";
            C_Result = "XValue";
            C_LeftTail = 0.99d;
            C_RightTail = 1d - C_LeftTail;
            Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, ref C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail);
            double p = C_dfVar[1];
            double chix = DistX.cdisx(C_LeftTail, C_RightTail, p * (p + 1d) / 2d);
            Console.WriteLine("p: {0}, n: {1}, chix: {2}", C_dfVar[1], C_dfErr[1], chix);
            Console.WriteLine("X: {0}, ratio: {1}", C_x, C_x / chix);
            // C_x = C_x * 1
            // C_Result = "PValue"

            // 'C_Algorithm = "F"

            // Call Box(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
            // Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
        }


        // Test for a given covariance matrix and mean vector
        public static void Lvcmdemo()
        {
            string C_Dis;
            int C_dfVarCount;
            int[] C_dfVar;
            double[] C_dfErr;
            int C_dfErrCount;
            double C_x;
            string C_XScale;
            string C_Algorithm;
            string C_Result;
            double C_LeftTail;
            double C_RightTail;
            C_Dis = "LVCMDIS";
            C_dfVarCount = 1;
            C_dfVar = new int[C_dfVarCount + 1];
            C_dfVar[1] = 5;  // = p
            C_dfErrCount = 1;
            C_dfErr = new double[C_dfErrCount + 1];
            C_dfErr[1] = 20d;  // = n
            C_x = 0.5d;
            C_XScale = "CHI2";

            // Using Nagarsenker's (1984) tables as comparison.
            // Convergence for n = p + 1
            // C_XScale = "CHI2RHO"
            C_Algorithm = "CHI2";
            C_Result = "XValue";
            C_LeftTail = 0.99d;
            C_RightTail = 1d - C_LeftTail;
            Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, ref C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail);
            double p = C_dfVar[1];
            double chix = DistX.cdisx(C_LeftTail, C_RightTail, p * (p + 3d) / 2d);
            Console.WriteLine("p: {0}, n: {1}, chix: {2}", C_dfVar[1], C_dfErr[1], chix);
            Console.WriteLine("X: {0}, ratio: {1}", C_x, C_x / chix);
            // C_x = C_x * 1
            // C_Result = "PValue"

            // 'C_Algorithm = "F"

            // Call Box(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail)
            // Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
        }



        public static void Bartlettdemo()
        {
            string C_Dis;
            int C_dfVarCount;
            int[] C_dfVar;
            double[] C_dfErr;
            int C_dfErrCount;
            double C_x;
            string C_XScale;
            string C_Algorithm;
            string C_Result;
            double C_LeftTail;
            double C_RightTail;
            int i;

            C_Dis = "L1DIS";
            C_dfVarCount = 1;
            C_dfVar = new int[C_dfVarCount + 1];
            C_dfVar[1] = 3;  // = p
            C_dfErrCount = 5; // = q
            C_dfErr = new double[C_dfErrCount + 1];
            var loopTo = C_dfErrCount;
            for (i = 1; i <= loopTo; i++)
                C_dfErr[i] = 15d;
            C_x = 0.5d;
            // Using Anderson's (1984), page 638 tables as comparison. Also see Davis 1971

            C_XScale = "CHI2";
            C_Algorithm = "CHI2";
            C_Result = "XValue";
            C_LeftTail = 0.95d;
            C_RightTail = 1d - C_LeftTail;
            Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, ref C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail);
            Console.WriteLine("Result X: {0}", C_x);
            C_x = C_x * 1d;
            C_Result = "PValue";

            // C_Algorithm = "F"

            Box(10, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, ref C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail);
            Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail);
        }



        public static void EqualDistributions()
        {
            string C_Dis;
            int C_dfVarCount;
            int[] C_dfVar;
            double[] C_dfErr;
            int C_dfErrCount;
            double C_x;
            string C_XScale;
            string C_Algorithm;
            string C_Result;
            double C_LeftTail;
            double C_RightTail;
            int i;

            C_Dis = "L2DIS";
            C_dfVarCount = 1;
            C_dfVar = new int[C_dfVarCount + 1];
            C_dfVar[1] = 3;  // = p
            C_dfErrCount = 5; // = q
            C_dfErr = new double[C_dfErrCount + 1];
            var loopTo = C_dfErrCount;
            for (i = 1; i <= loopTo; i++)
                C_dfErr[i] = 15d;
            C_x = 0.5d;
            // Using Anderson's (1984), page 638 tables as comparison. Also see Davis 1971

            C_XScale = "CHI2";
            C_Algorithm = "CHI2";
            C_Result = "XValue";
            C_LeftTail = 0.95d;
            C_RightTail = 1d - C_LeftTail;
            Box(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, ref C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail);
            Console.WriteLine("Result X: {0}", C_x);
            // C_x = C_x * 1
            // C_Result = "PValue"

            // 'C_Algorithm = "F"

            // Call Box(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, C_x, C_XScale, C_Algorithm,
            // C_Result, C_LeftTail, C_RightTail)
            // Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail)
        }



        public static void TestBoxDavis(string C_Result, string C_Algorithm, int a, int b, double[] x, double[] y, double[] xi, double[] eta, ref double z, ref double LeftTail, ref double RightTail)
        {
            int k, j, r, rsign;
            double sum1, sum2, f, rho;
            double[] omega;

            // Calculate f
            sum1 = 0d;
            var loopTo = a;
            for (k = 1; k <= loopTo; k++)
                sum1 = sum1 + xi[k];
            sum2 = 0d;
            var loopTo1 = b;
            for (j = 1; j <= loopTo1; j++)
                sum2 = sum2 + eta[j];
            f = -2 * (sum1 - sum2 - (a - b) / 2d);
            Console.WriteLine("f: {0}", f);

            // Calculate rho
            sum1 = 0d;
            var loopTo2 = a;
            for (k = 1; k <= loopTo2; k++)
                sum1 = sum1 + DistMain.Bernoulli(2, xi[k]) / x[k];
            sum2 = 0d;
            var loopTo3 = b;
            for (j = 1; j <= loopTo3; j++)
                sum2 = sum2 + DistMain.Bernoulli(2, eta[j]) / y[j];
            rho = 1d - (sum1 - sum2) / f;
            Console.WriteLine("rho: {0}", rho);

            // Calculate omega
            int rmax = 20;
            rsign = -1;
            omega = new double[rmax + 1];
            var loopTo4 = rmax;
            for (r = 1; r <= loopTo4; r++)
            {
                rsign = -rsign;
                sum1 = 0d;
                var loopTo5 = a;
                for (k = 1; k <= loopTo5; k++)
                    sum1 = sum1 + DistMain.Bernoulli(r + 1, (1d - rho) * x[k] + xi[k]) / Math.Pow(rho * x[k], r);
                sum2 = 0d;
                var loopTo6 = b;
                for (j = 1; j <= loopTo6; j++)
                    sum2 = sum2 + DistMain.Bernoulli(r + 1, (1d - rho) * y[j] + eta[j]) / Math.Pow(rho * y[j], r);
                omega[r] = rsign * (sum1 - sum2) / (r * (r + 1));

            }

            if (C_Result == "PValue") // Get p-value
            {
                // If C_XScale = "LR" Then z = -rho * C_dfErr(1) * Math.Log(C_x)
                if (C_Algorithm == "CHI2")
                {
                    // Call BoxDavis1(False, cmax, f, z, omega, C_LeftTail, C_RightTail)
                    Gupta(rmax, f, z, rho, omega);
                }
                else
                {
                    // Call BoxFApprox("PValue", f, z, omega(1), omega(2), C_LeftTail, C_RightTail)
                }
            }
            else if (C_Algorithm == "CHI2") // Get percentile
            {
                DavisPercentile(f, ref z, LeftTail, RightTail, rho, omega);
            }
            else
            {
                // Call BoxFApprox("XValue", f, z, omega(1), omega(2), C_LeftTail, C_RightTail)
                // If C_XScale = "LR" Then z = Math.Exp(-z / C_dfErr(1))
                // If C_XScale = "CHI2RHO" Then z = z * rho
                // C_x = z
            }

            // Exit Sub

            // Calculate cumulants
            Console.WriteLine("");
            Console.WriteLine("Hello Calculate cumulants");


            rmax = 12;
            var kappa = new double[rmax + 1];
            var loopTo7 = rmax;
            for (r = 1; r <= loopTo7; r++)
            {
                sum1 = 0d;
                var loopTo8 = a;
                for (k = 1; k <= loopTo8; k++)
                    sum1 = sum1 + Math.Pow(-2 * rho * x[k], r) * math53.polygamma(r - 1, x[k] + xi[k]);
                sum2 = 0d;
                var loopTo9 = b;
                for (j = 1; j <= loopTo9; j++)
                    sum2 = sum2 + Math.Pow(-2 * rho * y[j], r) * math53.polygamma(r - 1, y[j] + eta[j]);
                kappa[r] = sum1 - sum2;
                Console.WriteLine("r: {0}, kappa (r): {1}", r, kappa[r]);
            }
            double mean = kappa[1];
            double sigma = Math.Sqrt(kappa[2]);
            double sigma2 = kappa[2];
            double fxTarget = (z - mean) / sigma;
            double testXrho = (z / rho - mean) / sigma;
            Console.WriteLine("z: {0}, fxTarget: {1}, testXrho: {2}", z, fxTarget, testXrho);

            if (C_Result == "PValue") // Get p-value
            {
                var o = new double[rmax + 10 + 1];
                DistCornish.CumulantToGamma(rmax, mean, ref sigma, ref kappa, ref o);
                DistCornish.CalcEdgeworth(true, false, 0, rmax - 2, (z - mean) / sigma, ref o, ref LeftTail, ref RightTail);
                Console.WriteLine("Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail);
            }
            else
            {
                double x2 = DistCornish.CalcCornish(LeftTail, RightTail, mean, sigma, ref kappa, rmax);
                Console.WriteLine("Cornish X2: {0}", x2);
            }


        }



        public static void NewTestR0DisX()
        {
            int j;
            double LeftTail;
            double Righttail;
            int p;
            double n;
            double LeftTail2 = 0.0, RightTail2 = 0.0;
            p = 15;  // number of variables
            n = 85 - 1;  // Coelho_2012, equation 9, n + 1 is sample size
                         // LeftTail = 0.99999
                         // Righttail = 1 - LeftTail

            Righttail = 0.001d;
            LeftTail = 1d - Righttail;

            var b = new double[p + 1];
            var c = new double[p + 1];
            var loopTo = p - 1;
            for (j = 1; j <= loopTo; j++)
            {
                b[j] = (n - p + j) / 2d;
                c[j] = b[j] + (p - j) / 2d;
                // c(j) = (p - j) / 2
                Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j, b[j], c[j]);
            }
            double result2 = DistWilks.BetaflintodDisX2(LeftTail, Righttail, p - 1, b, c);
            Console.WriteLine("result2: {0}", result2);
            double resultM = -n * Math.Log(result2);
            Console.WriteLine("resultM: {0}", resultM);
            DistWilks.BetaflintodDis2(p, b, c, result2, ref LeftTail2, ref RightTail2);
            Console.WriteLine("LeftTail2: {0}", LeftTail2);

            NewBetaflintodDist(LeftTail, Righttail, p - 1, n / 2d, b, c);
        }


        // Note: In Coelho_2016, equation 53, n is sample size 
        // Tables are on page 10
        public static void NewTestLvcDisX()
        {
            int j;
            double LeftTail;
            double Righttail;
            int p;
            double n;
            double LeftTail2 = 0.0, RightTail2 = 0.0;
            p = 5; // number of variables
            n = 65d;   // n is sample size
            LeftTail = 0.95d;
            Righttail = 1d - LeftTail;
            var b = new double[p + 1];
            var c = new double[p + 1];
            var loopTo = p;
            for (j = 2; j <= loopTo; j++)
            {
                b[j - 1] = (n - j) / 2d;
                c[j - 1] = b[j - 1] + (j - 2) / (double)(p - 1) + (j - 1) / 2d;
                Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j - 1, b[j - 1], c[j - 1]);
            }
            double result2 = DistWilks.BetaflintodDisX2(LeftTail, Righttail, p - 1, b, c);
            Console.WriteLine("result2: {0}", result2);
            double resultM = -n * Math.Log(result2);
            Console.WriteLine("resultM: {0}", resultM);
            DistWilks.BetaflintodDis2(p - 1, b, c, result2, ref LeftTail2, ref RightTail2);
            Console.WriteLine("LeftTail2: {0}", LeftTail2);

            NewBetaflintodDist(LeftTail, Righttail, p - 1, n / 2d, b, c);
        }


        // Note: In Coelho_2016, equation 32, n is sample size 
        // Tables are on page 10
        public static void NewTestLvcmDisX()
        {
            int j;
            double LeftTail;
            double Righttail;
            int p;
            double n;
            double LeftTail2 = 0.0, RightTail2 = 0.0;
            p = 15; // number of variables
            n = 65d;   // n is sample size
            LeftTail = 0.95d;
            Righttail = 1d - LeftTail;
            var b = new double[p + 1];
            var c = new double[p + 1];
            var loopTo = p;
            for (j = 2; j <= loopTo; j++)
            {
                b[j - 1] = (n - j) / 2d;
                c[j - 1] = b[j - 1] + (j - 2) / (double)(p - 1) + j / 2d;
                Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j - 1, b[j - 1], c[j - 1]);
            }
            double result2 = DistWilks.BetaflintodDisX2(LeftTail, Righttail, p - 1, b, c);
            Console.WriteLine("result2: {0}", result2);
            double resultM = -n * Math.Log(result2);
            Console.WriteLine("resultM: {0}", resultM);
            DistWilks.BetaflintodDis2(p - 1, b, c, result2, ref LeftTail2, ref RightTail2);
            Console.WriteLine("LeftTail2: {0}", LeftTail2);

            NewBetaflintodDist(LeftTail, Righttail, p - 1, n / 2d, b, c);
        }


        // Note: In Coelho_2016, equation 55, n is sample size 
        // Tables are on page 10
        public static void NewTestLvcm0DisX()
        {
            int j;
            double LeftTail;
            double Righttail;
            int p;
            double n;
            double LeftTail2 = 0.0, RightTail2 = 0.0;
            p = 15; // number of variables
            n = 65d;   // n is sample size
            LeftTail = 0.95d;
            Righttail = 1d - LeftTail;
            var b = new double[p + 1];
            var c = new double[p + 1];
            var loopTo = p;
            for (j = 2; j <= loopTo; j++)
            {
                b[j - 1] = (n - j) / 2d;
                c[j - 1] = b[j - 1] + (j - 2) / (double)(p - 1) + j / 2d;
                Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j - 1, b[j - 1], c[j - 1]);
            }
            b[p] = (n - 1d) / 2d;
            c[p] = b[p] + 1d / 2d;
            double result2 = DistWilks.BetaflintodDisX2(LeftTail, Righttail, p, b, c);
            Console.WriteLine("result2: {0}", result2);
            double resultM = -n * Math.Log(result2);
            Console.WriteLine("resultM: {0}", resultM);
            DistWilks.BetaflintodDis2(p, b, c, result2, ref LeftTail2, ref RightTail2);
            Console.WriteLine("LeftTail2: {0}", LeftTail2);

            NewBetaflintodDist(LeftTail, Righttail, p, n / 2d, b, c);
        }


        // Note: In Coelho_2012c, equation 32, n is sample size (not n+1, as we use it here)
        public static void NewTestMauchley()
        {
            Console.WriteLine("Hello NewTestMauchley");
            int j;
            double LeftTail;
            double Righttail;
            int p;
            double n;
            double LeftTail2 = 0.0, RightTail2 = 0.0;
            p = 15; // number of variables
            n = 125d;   // n is sample size
            LeftTail = 0.95d;
            Righttail = 1d - LeftTail;
            var b = new double[p + 1];
            var c = new double[p + 1];
            var loopTo = p;
            for (j = 2; j <= loopTo; j++)
            {
                b[j - 1] = (n + 1d - j) / 2d;
                c[j - 1] = b[j - 1] + (j - 1) / (double)p + (j - 1) / 2d;
                Console.WriteLine("j: {0}, b(j): {1}, c(j): {2}", j - 1, b[j - 1], c[j - 1]);
            }
            double result2 = DistWilks.BetaflintodDisX2(LeftTail, Righttail, p - 1, b, c);
            Console.WriteLine("result2: {0}", result2);
            double resultM = -n * Math.Log(result2);
            Console.WriteLine("resultM: {0}", resultM);
            DistWilks.BetaflintodDis2(p - 1, b, c, result2, ref LeftTail2, ref RightTail2);
            Console.WriteLine("LeftTail2: {0}", LeftTail2);

            NewBetaflintodDist(LeftTail, Righttail, p - 1, n / 2d, b, c);
        }


        public static void NewTestWilksU()
        {
            Console.WriteLine("Hello NewTestWilksU");
            int f1, n;
            double LeftTail;
            double Righttail;
            int p;
            double LeftTail2 = 0.0, RightTail2 = 0.0;
            // p = 4 ' number of variables
            // f1 = 7 - 1 ' number of groups
            // n = 20 - 7  ' n is sample size
            p = 5; // number of variables
            f1 = 10; // number of groups
            n = 20;  // n is sample size
            LeftTail = 0.1d;
            Righttail = 1d - LeftTail;
            var b = new double[p + 1];
            var c = new double[p + 1];
            for (int i = 1, loopTo = p; i <= loopTo; i++)
            {
                b[i] = (n - i + 1) / 2d;
                c[i] = b[i] + f1 / 2d;
                Console.WriteLine("j: {0}, b(i): {1}, c(i): {2}", i, b[i], c[i]);
            }
            double result2 = DistWilks.BetaflintodDisX2(LeftTail, Righttail, p, b, c);
            Console.WriteLine("result2: {0}", result2);
            double resultL = -Math.Log(result2);
            Console.WriteLine("resultL: {0}", resultL);
            double resultM = -n * Math.Log(result2);
            Console.WriteLine("resultM: {0}", resultM);
            DistWilks.BetaflintodDis2(p, b, c, result2, ref LeftTail2, ref RightTail2);
            Console.WriteLine("LeftTail2: {0}", LeftTail2);

            NewBetaflintodDist(LeftTail, Righttail, p, n / 2d, b, c);
        }


        // Note: In Coelho_2012c, equation 30, n is sample size (not n+1, as we use it here)
        public static void NewTestBartlett()
        {
            Console.WriteLine("Hello NewTestBartlett");
            int p, q, j, k, m, n;
            double LeftTail, Righttail, LeftTail2 = 0.0, RightTail2 = 0.0;
            p = 3; // number of variables
            q = 5; // number of variables
            n = 15;   // n + 1 is sample size
            LeftTail = 0.95d;
            Righttail = 1d - LeftTail;
            var b = new double[p * q + 1];
            var c = new double[p * q + 1];

            m = 0;
            var loopTo = p;
            for (j = 1; j <= loopTo; j++)
            {
                var loopTo1 = q;
                for (k = 1; k <= loopTo1; k++)
                {
                    if (j == 1 & k == 1)
                    {
                        Console.WriteLine("The item (j = 1 And k = 1) needs to be omitted");
                    }
                    else
                    {
                        m = m + 1;
                        b[m] = (n + 1 - j) / 2d;
                        c[m] = b[m] + (j * (q - 1) + 2 * k - 1 - q) / (double)(2 * q);
                        Console.WriteLine("m: {0}, b(i): {1}, c(i): {2}", m, b[m], c[m]);
                    }
                }
            }

            double result2 = DistWilks.BetaflintodDisX2(LeftTail, Righttail, m, b, c);
            Console.WriteLine("result2: {0}", result2);
            double resultM = -n * Math.Log(result2);
            Console.WriteLine("resultM: {0}", resultM);
            DistWilks.BetaflintodDis2(m, b, c, result2, ref LeftTail2, ref RightTail2);
            Console.WriteLine("LeftTail2: {0}", LeftTail2);

            NewBetaflintodDist(LeftTail, Righttail, m, n / 2d, b, c);
        }




        public static void NewTestR0KSetsDis()
        {
            double LeftTail;
            double Righttail;
            int k;
            double n;
            double LeftTail2 = 0.0, RightTail2 = 0.0;
            int i, j, m, pmax;
            n = 40d;
            k = 5;
            LeftTail = 0.95d;
            Righttail = 1d - LeftTail;
            var p = new int[k + 1];
            var loopTo = k;
            for (i = 1; i <= loopTo; i++)
                p[i] = 3;

            var pp = new int[k + 1];
            pp[k] = 0;
            pmax = 0;
            for (i = k - 1; i >= 1; i -= 1)
            {
                pp[i] = pp[i + 1] + p[i];
                pmax = pmax + p[i];
            }
            double[] b;
            double[] c;
            b = new double[pmax + 1];
            c = new double[pmax + 1];
            m = 0;
            var loopTo1 = k - 1;
            for (i = 1; i <= loopTo1; i++)
            {
                var loopTo2 = p[i];
                for (j = 1; j <= loopTo2; j++)
                {
                    m = m + 1;
                    b[m] = (n + 1d - pp[i] - j) / 2d;
                    c[m] = b[m] + pp[i] / 2d;
                    Console.WriteLine("m: {0}, b(i): {1}, c(i): {2}", m, b[m], c[m]);
                }
            }

            double result2 = DistWilks.BetaflintodDisX2(LeftTail, Righttail, m, b, c);
            Console.WriteLine("result2: {0}", result2);
            double resultM = -n * Math.Log(result2);
            Console.WriteLine("resultM: {0}", resultM);
            DistWilks.BetaflintodDis2(m, b, c, result2, ref LeftTail2, ref RightTail2);
            Console.WriteLine("LeftTail2: {0}", LeftTail2);

            NewBetaflintodDist(LeftTail, Righttail, m, n / 2d, b, c);
        }


        public static void NewBetaflintodDist(double LeftTail, double RightTail, int k, double n2, double[] bi, double[] ci)
        {
            int j;
            double[] y = new double[k + 1], xi = new double[k + 1], eta = new double[k + 1];

            var loopTo = k;
            for (j = 1; j <= loopTo; j++)
            {
                y[j] = n2;
                xi[j] = bi[j] - n2;
                eta[j] = ci[j] - bi[j] + xi[j];   // simplify later
                                                  // eta(j) = ci(j) - bi(j) + xi(j)   'simplify later
                Console.WriteLine("j: {0}, y(j): {1}, eta(j): {2}, xi(j): {3}", j, y[j], eta[j], xi[j]);
            }

            Console.WriteLine("");
            Console.WriteLine("Hello TestBoxDavis");

            var z = default(double); // , LeftTail As Double, RightTail As Double
                                     // LeftTail = 0.99
                                     // RightTail = 1 - LeftTail
            TestBoxDavis("Quantile", "CHI2", k, k, y, y, xi, eta, ref z, ref LeftTail, ref RightTail);
            Console.WriteLine("z: {0}", z);
            TestBoxDavis("PValue", "CHI2", k, k, y, y, xi, eta, ref z, ref LeftTail, ref RightTail);
            Console.WriteLine("LeftTail: {0}", LeftTail);
        }


        public static void NewBartlett()
        {
            int p, q, NN;
            int a, b, i, j, k, g;
            double[] x, y, xi, eta;
            int[] n; // Sample sizes -1 per group
            p = 3;
            q = 5;
            NN = 0;
            n = new int[q + 1];
            var loopTo = q;
            for (g = 1; g <= loopTo; g++)
            {
                n[g] = 15;
                NN = NN + n[g];
            }

            a = p * q;
            b = p;
            y = new double[b + 1];
            eta = new double[b + 1];
            x = new double[a + 1];
            xi = new double[a + 1];

            var loopTo1 = b;
            for (j = 1; j <= loopTo1; j++)
            {
                y[j] = NN / 2d;
                eta[j] = (1 - j) / 2d;
            }
            k = 0;
            var loopTo2 = q;
            for (g = 1; g <= loopTo2; g++)
            {
                var loopTo3 = p;
                for (i = 1; i <= loopTo3; i++)
                {
                    k = k + 1;  // k = (g - 1) * p + i
                    x[k] = n[g] / 2d;
                    xi[k] = (1 - i) / 2d;
                }
            }

            var loopTo4 = b;
            for (j = 1; j <= loopTo4; j++)
                Console.WriteLine("j: {0}, y(j): {1}, eta(j): {2}", j, y[j], eta[j]);

            var loopTo5 = a;
            for (k = 1; k <= loopTo5; k++)
                Console.WriteLine("k: {0}, x(k): {1}, xi(k): {2}", k, x[k], xi[k]);

            Console.WriteLine("");
            Console.WriteLine("Hello TestBoxDavis");

            var z = default(double);
            double LeftTail;
            double RightTail;
            LeftTail = 0.95d;
            RightTail = 1d - LeftTail;
            TestBoxDavis("Quantile", "CHI2", a, b, x, y, xi, eta, ref z, ref LeftTail, ref RightTail);
            Console.WriteLine("z: {0}", z);
            TestBoxDavis("PValue", "CHI2", a, b, x, y, xi, eta, ref z, ref LeftTail, ref RightTail);
            Console.WriteLine("LeftTail: {0}", LeftTail);


        }

        public static void NewEqualDistributions()
        {
            int p, q, NN;
            int a, b, i, j, k, g;
            double[] x, y, xi, eta;
            int[] N;  // Sample sizes per group
            p = 3;
            q = 5;
            NN = 0;
            N = new int[q + 1];
            var loopTo = q;
            for (g = 1; g <= loopTo; g++)
            {
                N[g] = 15;
                NN = NN + N[g];
            }

            a = p * q;
            b = p;
            y = new double[b + 1];
            eta = new double[b + 1];
            x = new double[a + 1];
            xi = new double[a + 1];

            var loopTo1 = b;
            for (j = 1; j <= loopTo1; j++)
            {
                y[j] = NN / 2d;
                eta[j] = -j / 2d;
            }
            k = 0;
            var loopTo2 = q;
            for (g = 1; g <= loopTo2; g++)
            {
                var loopTo3 = p;
                for (i = 1; i <= loopTo3; i++)
                {
                    k = k + 1;  // k = (g - 1) * p + i
                    x[k] = N[g] / 2d;
                    xi[k] = -i / 2d;
                }
            }

            var loopTo4 = b;
            for (j = 1; j <= loopTo4; j++)
                Console.WriteLine("j: {0}, y(j): {1}, eta(j): {2}", j, y[j], eta[j]);

            var loopTo5 = a;
            for (k = 1; k <= loopTo5; k++)
                Console.WriteLine("k: {0}, x(k): {1}, xi(k): {2}", k, x[k], xi[k]);

            Console.WriteLine("");
            Console.WriteLine("Hello TestBoxDavis");


            var z = default(double);
            double LeftTail;
            double RightTail;
            LeftTail = 0.9d;
            RightTail = 1d - LeftTail;
            TestBoxDavis("Quantile", "CHI2", a, b, x, y, xi, eta, ref z, ref LeftTail, ref RightTail);
            Console.WriteLine("z: {0}", z);
            TestBoxDavis("PValue", "CHI2", a, b, x, y, xi, eta, ref z, ref LeftTail, ref RightTail);
            Console.WriteLine("LeftTail: {0}", LeftTail);



        }

    }
}