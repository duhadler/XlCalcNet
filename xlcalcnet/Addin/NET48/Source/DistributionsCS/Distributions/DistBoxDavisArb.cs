using System;
using ArbPrecNet;

namespace Distributions
{



    static class DistBoxDavisArb
    {


        // Function Arb_ChiSquare_pdf(x As Arb, nu As Arb, log_p As Boolean) As Arb
        // Dim result As New Arb
        // result = aflint.gamma_p_derivative(nu / 2, x / 2) / 2
        // If log_p Then result = aflint.log(result)
        // Return result
        // End Function


        // Function Arb_ChiSquare_CDF(x As Arb, nu As Arb, lower_tail As Boolean, log_p As Boolean) As Arb
        // Dim result As New Arb
        // If lower_tail Then result = aflint.gamma_p(nu / 2, x / 2) Else result = aflint.gamma_q(nu / 2, x / 2)
        // If log_p Then result = aflint.log(result)
        // Return result
        // End Function


        public static void BoxFApproxArb(string result, Arb f1, ref Arb m, Arb omeg1, Arb omeg2, Arb LeftTail, Arb RightTail)
        {
            var f2 = new Arb();
            var A1 = new Arb();
            var A2 = new Arb();
            var C = new Arb();
            var b = new Arb();
            var x = new Arb();
            A1 = 2 * omeg1 / f1;
            A2 = 4 * omeg2 / f1;
            C = A2 - A1 * A1;
            // x = 1
            x = aflint.one();
            if (C > 0)
            {
                f2 = (f1 + 2) / C;
                b = f1 / (1 - A1 - f1 / f2);
                if (result == "PValue")
                    x = m / b;
            }
            else
            {
                f2 = -(f1 + 2) / C;
                b = f2 / (1 - A1 + 2.0d / f2);
                if (result == "PValue")
                    x = f2 * m / (f1 * (b - m));
            }
            if (result == "PValue")
            {
                // LeftTail = Fdisn(f1, f2, x, 0, l1, r1)
                // RightTail = 1 - LeftTail
                // LeftTail = Fdisn(f1.AsDouble, f2.AsDouble, x.AsDouble, 0)
                LeftTail = aflint.t(DistN.Fdisn(f1.AsDouble(), f2.AsDouble(), x.AsDouble(), 0d));
            }
            else
            {
                x = aflint.t(DistX.fdisx(f1.AsDouble(), f2.AsDouble(), LeftTail.AsDouble(), RightTail.AsDouble()));
                if (C > 0)
                    m = x * b;
                else
                    m = b / (f2 / (f1 * x) + 1);
            }
        }


        public static void DavisPercentileArb(Arb f, ref Arb x, Arb LeftTail, Arb RightTail, Arb rho, ArbMat o)
        {
            var p1 = new Arb();
            var p2 = new Arb();
            var p3 = new Arb();
            var p4 = new Arb();
            var P5 = new Arb();
            var p6 = new Arb();
            var P7 = new Arb();
            var P22 = new Arb();
            var P32 = new Arb();
            var P42 = new Arb();
            var P33 = new Arb();
            var P222 = new Arb();
            var P52 = new Arb();
            var P43 = new Arb();
            var P322 = new Arb();
            var f2 = new Arb();
            var f3 = new Arb();
            var f4 = new Arb();
            var f5 = new Arb();
            var f6 = new Arb();
            var f7 = new Arb();
            var f12 = new Arb();
            var f13 = new Arb();
            var f22 = new Arb();
            var S1 = new Arb();
            var u = new Arb();
            var u2 = new Arb();
            var u3 = new Arb();
            var u4 = new Arb();
            var u5 = new Arb();
            var u6 = new Arb();
            var u7 = new Arb();
            var sum = new Arb();
            int i;
            bool show;
            var s = new ArbMat();
            s.Resize(7 + 1, 1);
            show = true;
            u = DistXArb.cdisxArb(LeftTail, RightTail, f);
            f2 = f * (f + 2);
            f3 = f2 * (f + 4);
            f4 = f3 * (f + 6);
            f5 = f4 * (f + 8);
            f6 = f5 * (f + 10);
            f7 = f6 * (f + 12);
            f12 = f * f;
            f13 = f12 * f;
            f22 = f2 * f2;
            u2 = u * u;
            u3 = u * u2;
            u4 = u * u3;
            u5 = u * u4;
            u6 = u * u5;
            u7 = u * u6;
            S1 = u2 * (3 * f + 4 * 2 - 2) / (f2 * f2) + u3 * (3 * f + 4 * 3 - 2) / (f2 * f3) + u4 * (3 * f + 4 * 4 - 2) / (f2 * f4) + u5 * (3 * f + 4 * 5 - 2) / (f2 * f5);


            p1 = u / f;
            p2 = p1 + u2 / f2;
            p3 = p2 + u3 / f3;
            p4 = p3 + u4 / f4;
            P5 = p4 + u5 / f5;
            p6 = P5 + u6 / f6;
            P7 = p6 + u7 / f7;
            P22 = -8 * u4 * (f + 3) / (f2 * f4) + 8 * u3 / (f2 * f3) + 6 * u2 / (f * f2) + 2 * u / f12;
            P32 = -12 * u5 * (f + 4) / (f2 * f5) - 2 * u4 * (f - 6) / (f2 * f4) + 2 * u3 * (3 * f + 10) / (f2 * f3) + 6 * u2 / (f * f2) + 2 * u / f12;
            P42 = -16 * u6 * (f + 5) / (f2 * f6) - 4 * u5 * (f - 4) / (f2 * f5) + 2 * u4 * (3 * f + 14) / (f2 * f4) + 2 * u3 * (3 * f + 10) / (f2 * f3) + 6 * u2 / (f * f2) + 2 * u / f12;
            P33 = -6 * u6 * (3 * f12 + 30 * f + 80) / (f3 * f6) - 6 * u5 * (f2 + 2 * f - 16) / (f3 * f5) + 4 * u4 * (f + 12) / (f2 * f4) + 4 * u3 * (3 * f + 8) / (f2 * f3) + 6 * u2 / (f * f2) + 2 * u / f12;
            P222 = 32 * u6 * (7 * f12 + 62 * f + 120) / (f22 * f6) - 32 * u5 * (2 * f12 + 37 * f + 96) / (f22 * f5) - 8 * u4 * (23 * f12 + 124 * f + 132) / (f22 * f4) - 8 * u3 * (f - 10) / (f * f2 * f3) + 28 * u2 / (f12 * f2) + 4 * u / f13;
            P52 = -20 * u7 * (f + 6) / (f2 * f7) - 2 * u6 * (3 * f - 10) / (f2 * f6) + S1 + 2 * u / f12;
            P43 = -24 * u7 * (f2 + 12 * f + 40) / (f3 * f7) - 2 * u6 * (5 * f2 + 18 * f - 80) / (f3 * f6) + 2 * u5 * (f2 + 42 * f + 176) / (f3 * f5) + 4 * u4 * (3 * f + 16) / (f2 * f4) + 4 * u3 * (3 * f + 8) / (f2 * f3) + 6 * u2 / (f * f2) + 2 * u / f12;

            P322 = 192 * u7 * (2 * f13 + 31 * f12 + 154 * f + 240) / (f2 * f3 * f7) - 16 * u6 * (4 * f13 + 153 * f12 + 1106 * f + 2160) / (f2 * f3 * f6) - 8 * u5 * (35 * f3 + 420 * f12 + 1540 * f + 1632) / (f2 * f3 * f5) - 4 * u4 * (25 * f12 + 80 * f + 12) / (f22 * f4) + 4 * u3 * (7 * f + 38) / (f * f2 * f3) + 28 * u2 / (f12 * f3) + 4 * u / f13;


            s[2] = o[2] * p2;
            s[3] = o[3] * p3;
            // s(4) = o(4) * p4 + 0.5 * (o(2) ^ 2) * P22
            s[4] = o[4] * p4 + 0.5d * aflint.pow(o[2], 2) * P22;
            s[5] = o[5] * P5 + o[3] * o[2] * P32;
            // s(6) = o(6) * p6 + o(4) * o(2) * P42 + 0.5 * (o(3) ^ 2) * P33 _
            // + o(2) * o(2) * o(2) * P222 / 6
            s[6] = o[6] * p6 + o[4] * o[2] * P42 + 0.5d * aflint.pow(o[3], 2) * P33 + o[2] * o[2] * o[2] * P222 / 6;
            // s(7) = o(7) * P7 + o(5) * o(2) * P52 + o(4) * o(3) * P43 _
            // + 0.5 * o(3) * (o(2) ^ 2) * P322
            s[7] = o[7] * P7 + o[5] * o[2] * P52 + o[4] * o[3] * P43 + 0.5d * o[3] * aflint.pow(o[2], 2) * P322;
            // sum = 0
            sum = aflint.zero();
            if (show)
                Console.WriteLine("u: {0}", u);
            for (i = 2; i <= 7; i++)
            {
                sum = sum + s[i];
                if (show)
                    Console.WriteLine("i: {0}, sum: {1}, s(i): {2}", i, sum, s[i]);
            }
            x = u + 2 * sum;
            Console.WriteLine("resultM/rho in DavisPercentile: {0}", x / rho);
            // x = x / rho
        }


        public static Arb DeltaArb(int s, int p)
        {
            Arb DeltaArbRet = aflint.t(0);
            var sum = new Arb();
            int j;
            // sum = 0
            sum = aflint.zero();
            var loopTo = p - 1;
            for (j = 0; j <= loopTo; j++)
                // sum = sum + Bernoulli(s, -j / 2)
                // sum = sum + aflint.bernpoly(-aflint.t(j) / 2, s)
                sum = sum + aflint.bernpoly(-aflint.t(j) / 2, s);
            DeltaArbRet = -sum * (s + 1) / 2;
            return DeltaArbRet;
        }



        public static void BoxArb(int cmax, string C_Dis, int C_dfVarCount, int[] C_dfVar, ArbMat C_dfErr, int C_dfErrCount, ref Arb C_x, string C_XScale, string C_Algorithm, string C_Result, Arb C_LeftTail, Arb C_RightTail)
        {

            var sum = new Arb();
            var Mur = new Arb();
            var z = new Arb();
            var f = new Arb();
            var b = new Arb();
            var mu = new Arb();
            var rho = new Arb();
            var S1 = new Arb();
            var s2 = new Arb();
            var s3 = new Arb();
            var sigma2 = new Arb();
            var sigma3 = new Arb();
            int k;
            int p;
            int j;
            int r;
            int s;
            int i;
            var BK = new Arb();
            var ks = new Arb();
            var TWO = new Arb();
            var nu = new Arb();
            var n = new Arb();
            var rhor = new Arb();
            var NS = new Arb();
            var ps = new Arb();

            var d = new ArbMat();
            var Beta = new ArbMat();
            var nr = new ArbMat();
            var ss = new ArbMat();
            var omega = new ArbMat();

            d.Resize(100, 1);
            Beta.Resize(100, 1);
            nr.Resize(100, 1);
            ss.Resize(100, 1);
            omega.Resize(100, 1);

            b = aflint.one();
            S1 = aflint.one();
            p = 1;
            Mur = aflint.one();
            s2 = aflint.one();
            k = 1;
            n = aflint.one();
            rho = aflint.one();
            mu = aflint.one();
            nu = aflint.one();
            TWO = aflint.one();
            ks = aflint.one();
            f = aflint.one();
            rhor = aflint.one();
            NS = aflint.one();
            ps = aflint.one();
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
                        S1 = aflint.zero();
                        s2 = aflint.zero();
                        s3 = aflint.zero();
                        ss[0] = aflint.zero();
                        var loopTo = C_dfVarCount;
                        for (i = 1; i <= loopTo; i++)
                        {
                            int cdi = C_dfVar[i];
                            ss[i] = cdi + ss[i - 1];
                            S1 = S1 + cdi;
                            s2 = s2 + cdi * cdi;
                            s3 = s3 + cdi * cdi * cdi;
                        }
                        sigma2 = S1 * S1 - s2;
                        sigma3 = S1 * S1 * S1 - s3;
                        f = sigma2 / 2;
                        n = C_dfErr[1];
                        rho = aflint.t(1) - (aflint.t(2) * sigma3 + aflint.t(3) * sigma2) / aflint.t(12 * f * n);
                        z = rho * C_x;
                        Console.WriteLine("C_x: {0}, z: {1}, rho: {2}", C_x, z, rho);
                        b = n * (1 - rho);
                        mu = n * rho;
                        Mur = -mu / 2;
                        break;
                    }

                // Bartlett Test
                case "L1DIS":
                    {
                        k = C_dfErrCount;
                        p = C_dfVar[1];
                        S1 = aflint.zero();
                        s2 = aflint.zero();
                        n = aflint.zero();
                        var loopTo1 = k;
                        for (i = 1; i <= loopTo1; i++)
                        {
                            n = n + C_dfErr[i];
                            S1 = S1 + 1.0d / C_dfErr[i];
                            // s2 = s2 + (1.0 / C_dfErr(i)) ^ 2
                            s2 = s2 + aflint.sqr(1.0d / C_dfErr[i]);
                            nr[i] = aflint.one();
                        }
                        S1 = S1 - 1.0d / n;
                        rho = 1 - S1 * (2 * p * p + 3 * p - 1) / (6 * (p + 1) * (k - 1));
                        nu = n / k;
                        b = (1 - rho) * nu;
                        mu = -rho * nu;
                        // f = (k - 1) * p * (p + 1) / 2
                        f = (k - 1) * p * (p + 1) / aflint.t(2);
                        z = rho * C_x;
                        // TWO = 2
                        TWO = aflint.t(2);
                        // ks = k
                        ks = aflint.t(k);
                        d[1] = TWO * (1 - 1.0d / ks) * DeltaArb(1, p);
                        Beta[0] = aflint.one();
                        Mur = mu;
                        break;
                    }

                // Equality of normal distributions
                case "L2DIS":
                    {
                        k = C_dfErrCount;
                        p = C_dfVar[1];
                        S1 = aflint.zero();
                        s2 = aflint.zero();
                        n = aflint.zero();
                        var loopTo2 = k;
                        for (i = 1; i <= loopTo2; i++)
                            n = n + C_dfErr[i];
                        var loopTo3 = k;
                        for (i = 1; i <= loopTo3; i++)
                        {
                            S1 = S1 + n / C_dfErr[i];
                            s2 = s2 + aflint.sqr(n / C_dfErr[i]);
                        }
                        S1 = S1 - 1;
                        s2 = s2 - 1;
                        rho = 1.0d / n * (n - S1 * (2.0d * p * p + 3 * p - 1d) / (6 * (p + 3) * (k - 1)) - (p - k + 2.0d) / (p + 3));
                        mu = n * rho;
                        f = (k - 1) * p * (p + 3) / aflint.t(2);
                        z = rho * C_x;
                        if (C_XScale == "CHI2RHO")
                            z = z / rho;
                        break;
                    }

                // Mauchley test for sphericity
                case "LSDIS":
                    {
                        p = C_dfVar[1];
                        n = C_dfErr[1];
                        rho = 1 - (2 * p * p + p + 2.0d) / (6 * p * n);
                        f = (p - 1) * (p + 2.0d) / aflint.t(2);
                        z = rho * C_x;
                        b = 1 - rho;
                        NS = aflint.one();
                        ps = aflint.one();
                        rhor = rho;
                        d[1] = DeltaArb(1, p) - 0.5d;
                        Beta[0] = aflint.one();
                        break;
                    }

                // Test for a given covariance matrix
                case "LVCDIS":
                    {
                        p = C_dfVar[1];
                        n = C_dfErr[1];
                        rho = 1 - (2 * p * p + 3 * p - 1.0d) / (6 * n * (p + 1));
                        // f = p * (p + 1) / 2
                        f = p * (p + 1) / aflint.t(2);
                        z = rho * C_x;
                        NS = aflint.one();
                        b = 1 - rho;
                        rhor = rho;
                        d[1] = DeltaArb(1, p);
                        Beta[0] = aflint.one();
                        break;
                    }

                // Test for a given covariance matrix and mean vector
                case "LVCMDIS":
                    {
                        p = C_dfVar[1];
                        n = C_dfErr[1];
                        rho = 1 - (2 * p * p + 9 * p + 11.0d) / (6 * n * (p + 3));
                        // f = p * (p + 3) / 2
                        f = p * (p + 3) / aflint.t(2);
                        z = rho * C_x;
                        NS = aflint.one();
                        b = 1 - rho - 1.0d / n;
                        // TWO = 4
                        TWO = aflint.t(4);
                        rhor = rho;
                        d[1] = DeltaArb(1, p) + p * 2.0d / TWO;
                        Beta[0] = aflint.one();
                        break;
                    }

            }


            if (C_Algorithm == "CHI2" | C_Algorithm == "DEF")
            {
                //cmax = cmax;
            }
            else
            {
                rho = aflint.one();
                cmax = 2;
            }


            var loopTo4 = cmax;
            for (r = 1; r <= loopTo4; r++)
            {
                switch (C_Dis ?? "")
                {

                    // Independence of sets of variates
                    case "U1DIS":
                        {
                            sum = aflint.zero();
                            // Console.WriteLine("b: {0}, Mur: {1}", b, Mur)
                            var loopTo5 = C_dfVarCount;
                            for (i = 2; i <= loopTo5; i++)
                            {
                                var loopTo6 = C_dfVar[i] - 1;
                                for (j = 0; j <= loopTo6; j++)
                                    // sum = sum + aflint.bernpoly((b - j) / 2, r + 1) - aflint.bernpoly((b - ss(i - 1) - j) / 2, r + 1)
                                    // sum = sum + Bernoulli(r + 1, (b - j) / 2) - Bernoulli(r + 1, (b - ss(i - 1) - j) / 2)
                                    sum = sum + aflint.bernpoly((b - j) / 2, r + 1) - aflint.bernpoly((b - ss[i - 1] - j) / 2, r + 1);
                            }
                            omega[r] = sum / (r * (r + 1) * Mur);
                            Mur = -Mur * mu / 2;
                            break;
                        }

                    // Bartlett Test
                    case "L1DIS":
                        {
                            TWO = 2 * TWO;
                            ks = ks * k;
                            sum = aflint.zero();
                            var loopTo7 = k;
                            for (i = 1; i <= loopTo7; i++)
                            {
                                nr[i] = nr[i] * nu / C_dfErr[i];
                                sum = sum + nr[i];
                            }
                            d[r + 1] = TWO * (sum / k - 1.0d / ks) * DeltaArb(r + 1, p);
                            Beta[r] = Beta[r - 1] * b;
                            // BK = r + 2
                            BK = aflint.t(r + 2);
                            sum = aflint.zero();
                            var loopTo8 = r + 1;
                            for (s = 1; s <= loopTo8; s++)
                            {
                                BK = BK * (r + 2 - s) / (s + 1);
                                sum = sum + BK * d[s] * Beta[r + 1 - s];
                            }
                            omega[r] = k * sum / (r * (r + 1) * (r + 2) * Mur);
                            Mur = Mur * mu;
                            break;
                        }

                    // Equality of normal distributions
                    case "L2DIS":
                        {
                            if (r != 2)
                                omega[r] = aflint.t(0);
                            else
                            {
                            }
                            omega[r] = 1.0d * p / (288 * mu * mu) * (6 * s2 * (p + 1) * (p - 1) * (p + 2) - S1 * S1 * Math.Sqrt(2.0d * p * p + 3 * p - 1d) / ((k - 1) * (p + 3)) - 12 * S1 * (2 * p * p + 3 * p - 1) * (p - k + 2) / (p + 3) - 36 * (k - 1) * Math.Sqrt(1.0d * p - k + 2d) / (p + 3) - 12 * (k - 1) * (-2 * k * k + 7 * k + 3 * p * k - 2 * p * p - 6 * p - 4));
                            break;
                        }

                    // Mauchley test for sphericity
                    case "LSDIS":
                        {
                            NS = NS * (n / 2);
                            ps = ps * p;
                            d[r + 1] = (DeltaArb(r + 1, p) + (r + 2) / 2d * aflint.bernoulli(r + 1) / ps) / NS;
                            // d(r + 1) = (deltaArb(r + 1, p) + (r + 2) / 2 * Bernoulli(r + 1, 0) / ps) / NS
                            Beta[r] = Beta[r - 1] * b;
                            BK = aflint.t(r + 2);
                            sum = aflint.zero();
                            var loopTo9 = r + 1;
                            for (s = 1; s <= loopTo9; s++)
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
                            NS = NS * (n / 2);
                            d[r + 1] = DeltaArb(r + 1, p) / NS;
                            Beta[r] = Beta[r - 1] * b;
                            BK = aflint.t(r + 2);
                            sum = aflint.zero();
                            var loopTo10 = r + 1;
                            for (s = 1; s <= loopTo10; s++)
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
                            TWO = TWO * 2;
                            NS = NS * (n / 2);
                            d[r + 1] = (DeltaArb(r + 1, p) + p * (r + 2) / TWO) / NS;
                            Beta[r] = Beta[r - 1] * b;
                            BK = aflint.t(r + 2);
                            sum = aflint.zero();
                            var loopTo11 = r + 1;
                            for (s = 1; s <= loopTo11; s++)
                            {
                                BK = BK * (r + 2 - s) / (s + 1);
                                sum = sum + BK * d[s] * Beta[r + 1 - s];
                            }
                            omega[r] = 2 / (r * (r + 1) * (r + 2) * rhor) * sum;
                            if (r % 2 != 0)
                                omega[r] = -omega[r];
                            rhor = rhor * rho;
                            break;
                        }
                }
            }

            var TargetError = aflint.t("1E-40");
            if (C_Result == "PValue") // Get p-value
            {
                if (C_XScale == "LR")
                    z = -rho * C_dfErr[1] * aflint.log(C_x);
                if (C_Algorithm == "CHI2")
                {
                    // Call BoxDavis1(False, cmax, f, z, omega, C_LeftTail, C_RightTail)
                    GuptaArb(cmax, f, z, rho, omega, TargetError);
                }
                else
                {
                    BoxFApproxArb("PValue", f, ref z, omega[1], omega[2], C_LeftTail, C_RightTail);
                }
            }
            else
            {
                if (C_Algorithm == "CHI2") // Get percentile
                {
                    DavisPercentileArb(f, ref z, C_LeftTail, C_RightTail, rho, omega);
                    Console.WriteLine("z from within: {0}", z);
                }
                else
                {
                    BoxFApproxArb("XValue", f, ref z, omega[1], omega[2], C_LeftTail, C_RightTail);
                }
                if (C_XScale == "LR")
                    z = aflint.exp(-z / C_dfErr[1]);
                if (C_XScale == "CHI2RHO")
                    z = z * rho;
                C_x = z;
            }
        }

        public static void GuptaArb(int cmax, Arb f, Arb z, Arb rho, ArbMat omega, Arb TargetError)
        {
            Console.WriteLine("f: {0}, z: {1}, rho: {2}", f, z, rho);
            Arb adj = new Arb(), adj2 = new Arb(), KB = new Arb(), RelErr = new Arb();
            var LogKB = aflint.t(0);
            var sum = DistFromBoost.Arb_ChiSquare_CDF(z, f, true, false);
            Console.WriteLine("sum: {0}", sum);
            var a = new ArbMat();
            a.Resize(100, 1);
            a[0] = aflint.one();
            for (int j = 1, loopTo = cmax; j <= loopTo; j++)
            {
                var temp = new Arb();
                temp = aflint.zero();
                for (int l = 1, loopTo1 = j; l <= loopTo1; l++)
                    temp = temp + l * omega[l] * a[j - l];
                a[j] = temp / j;
                LogKB = LogKB + omega[j];


                // Function Arb_ChiSquare_pdf(x As Arb, nu As Arb,  log_p As Boolean) As Arb


                // Function Arb_ChiSquare_CDF(x As Arb, nu As Arb,  lower_tail As Boolean, log_p As Boolean) As Arb

                // adj = cdis(f + 2*j, z)

                adj = DistFromBoost.Arb_ChiSquare_CDF(z, f + 2 * j, true, false);
                adj2 = a[j] * adj;
                sum = sum + adj2;
                if (j % 2 == 0)
                {
                    // Console.WriteLine("j: {0}, omega(j): {1}, a(j): {2}, adj: {3}, adj2: {4}", j, omega(j), a(j), adj, adj2)
                    RelErr = aflint.abs(adj2 / sum);
                    Console.WriteLine("j: {0}, sum: {1}, adj2: {2}, RelErr: {3}", j, sum, adj2, RelErr);
                    if (RelErr < TargetError)
                        break;
                }
            }
            KB = aflint.exp(-LogKB);
            Console.WriteLine("LogKB: {0}, KB: {1}, sum: {2}, LeftTail: {3}", LogKB, KB, sum, KB * sum);
        }


        public static void GuptaArbNew(int cmax, Arb f, Arb z, Arb rho, ArbMat omega, Arb TargetError, ref Arb LeftTail)
        {
            Console.WriteLine("f: {0}, z: {1}, rho: {2}", f, z, rho);
            Arb adj = new Arb(), adj2 = new Arb(), KB = new Arb(), RelErr = new Arb();
            var LogKB = aflint.t(0);
            var sum = DistFromBoost.Arb_ChiSquare_CDF(z, f, true, false);

            var a = new ArbMat();
            a.Resize(100, 1);
            a[0] = aflint.one();
            for (int j = 1, loopTo = cmax; j <= loopTo; j++)
            {
                var temp = new Arb();
                temp = aflint.zero();
                for (int l = 1, loopTo1 = j; l <= loopTo1; l++)
                    temp = temp + l * omega[l] * a[j - l];
                a[j] = temp / j;
                LogKB = LogKB + omega[j];


                // Function Arb_ChiSquare_pdf(x As Arb, nu As Arb,  log_p As Boolean) As Arb


                // Function Arb_ChiSquare_CDF(x As Arb, nu As Arb,  lower_tail As Boolean, log_p As Boolean) As Arb

                // adj = cdis(f + 2*j, z)

                adj = DistFromBoost.Arb_ChiSquare_CDF(z, f + 2 * j, true, false);
                adj2 = a[j] * adj;
                sum = sum + adj2;
                if (j % 2 == 0)
                {
                    // Console.WriteLine("j: {0}, omega(j): {1}, a(j): {2}, adj: {3}, adj2: {4}", j, omega(j), a(j), adj, adj2)
                    RelErr = aflint.abs(adj2 / sum);
                    Console.WriteLine("j: {0}, sum: {1}, adj2: {2}, RelErr: {3}", j, sum, adj2, RelErr);
                    if (RelErr < TargetError)
                        break;
                }
            }
            KB = aflint.exp(-LogKB);
            Console.WriteLine("LogKB: {0}, KB: {1}, sum: {2}, LeftTail: {3}", LogKB, KB, sum, KB * sum);
            LeftTail = KB * sum;
        }



        public static void UdisdemoArb()
        {
            string C_Dis;
            int C_dfVarCount;
            int[] C_dfVar;
            var C_dfErr = new ArbMat();
            int C_dfErrCount;
            var C_x = new Arb();
            string C_XScale;
            string C_Algorithm;
            string C_Result;
            var C_LeftTail = new Arb();
            var C_RightTail = new Arb();

            ArbPrec.SetDps(60);

            C_Dis = "U1DIS";
            C_dfVarCount = 2;
            C_dfVar = new int[C_dfVarCount + 1];
            C_dfVar[1] = 5;
            C_dfVar[2] = 7;
            C_dfErrCount = 1;
            // ReDim C_dfErr(C_dfErrCount)

            C_dfErr.Resize(C_dfErrCount + 1, 1);

            C_dfErr[1] = aflint.t(15 + 7);
            C_x = aflint.t(0.5d);
            C_XScale = "CHI2";
            C_Algorithm = "CHI2";
            C_Result = "XValue";
            C_LeftTail = aflint.t("0.99");
            C_RightTail = 1 - C_LeftTail;
            BoxArb(7, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, ref C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail);
            Console.WriteLine("Result X: {0}", C_x);
            C_x = C_x * 1;
            C_Result = "PValue";

            // C_Algorithm = "F"

            BoxArb(28, C_Dis, C_dfVarCount, C_dfVar, C_dfErr, C_dfErrCount, ref C_x, C_XScale, C_Algorithm, C_Result, C_LeftTail, C_RightTail);
            Console.WriteLine("C_LeftTail: {0}, C_RightTail: {1}", C_LeftTail, C_RightTail);
        }





        private static Arb B3Arb(Arb h)
        {
            return h * h * h - 1.5d * h * h + 0.5d * h;
        }


        // {Approximation by Nagarsenker}
        public static void BetaflintodDis2Arb(int p, ArbMat b, ArbMat c, Arb x, ref Arb LeftTail, ref Arb Righttail)
        {
            int i;
            Arb k = new Arb(), s = new Arb(), v1 = new Arb(), v2 = new Arb(), m = new Arb(), alpha = new Arb();
            v1 = aflint.zero();
            v2 = aflint.zero();
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                v1 = v1 + c[i] - b[i];
                // v2 = v2 + (c(i)) ^ 2 - (b(i)) ^ 2
                v2 = v2 + aflint.sqr(c[i]) - aflint.sqr(b[i]);
            }
            m = (v2 - v1) / (2 * v1);
            k = aflint.t(0);
            var loopTo1 = p;
            for (i = 1; i <= loopTo1; i++)
                k = k + B3Arb(b[i] - m) - B3Arb(c[i] - m);
            alpha = (1 - v1) / 2;
            s = -2 * B3Arb((1 + v1) / 2) / k;
            // Console.WriteLine("s: {0}", s)
            s = aflint.sqrt(s);
            x = aflint.exp(aflint.log(x) / s);
            var df2 = s * m + alpha;
            Console.WriteLine("x: {0}", x);

            Righttail = aflint.ibetac(v1, df2, 1 - x);

            LeftTail = 1 - Righttail;
        }



        // {Approximation by Nagarsenker}
        public static Arb BetaflintodDisX2Arb(Arb LeftTail, Arb Righttail, int p, ArbMat b, ArbMat c)
        {
            int i;
            Arb k = new Arb(), s = new Arb(), v1 = new Arb(), v2 = new Arb(), m = new Arb(), alpha = new Arb();
            Arb X2 = new Arb(), X = new Arb(), Y = new Arb();
            Console.WriteLine("In BetaflintodDisX2Arb: ");
            v1 = aflint.zero();
            v2 = aflint.zero();
            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                v1 = v1 + c[i] - b[i];
                // v2 = v2 + (c(i)) ^ 2 - (b(i)) ^ 2
                v2 = v2 + aflint.sqr(c[i]) - aflint.sqr(b[i]);
                // Console.WriteLine("j: {0}, b(i): {1}, c(i): {2}", i, b(i), c(i))
            }
            m = (v2 - v1) / (2 * v1);
            k = aflint.zero();
            var loopTo1 = p;
            for (i = 1; i <= loopTo1; i++)
                k = k + B3Arb(b[i] - m) - B3Arb(c[i] - m);
            alpha = (1 - v1) / 2;
            s = -2 * B3Arb((1 + v1) / 2) / k;
            Console.WriteLine("s: {0}", s);
            s = aflint.sqrt(s);
            var df2 = s * m + alpha;

            DistXArb.betadisxArb(LeftTail, Righttail, v1, df2, ref X, ref Y);

            X2 = aflint.exp(s * aflint.log(Y));
            return X2;

        }


        public static void NewTestWilksUArb()
        {
            ArbPrec.SetDps(20);
            Console.WriteLine("Hello NewTestWilksUArb");
            int i, f1, n, p;
            Arb LeftTail = new Arb(), Righttail = new Arb();
            Arb LeftTail2 = new Arb(), RightTail2 = new Arb();
            // p = 4 ' number of variables
            // f1 = 7 - 1 ' number of groups
            // n = 20 - 7  ' n is sample size
            p = 4; // number of variables
            f1 = 70; // number of groups
            n = 10000;  // n is sample size
            LeftTail = aflint.t("0.99");
            // LeftTail = aflint.t("0.51")
            Righttail = 1 - LeftTail;
            var b = new ArbMat();
            var c = new ArbMat();
            b.Resize(p + 1, 1);
            c.Resize(p + 1, 1);

            var loopTo = p;
            for (i = 1; i <= loopTo; i++)
            {
                b[i] = (n - i + 1) / aflint.t(2);
                c[i] = b[i] + f1 / 2d;
                // Console.WriteLine("j: {0}, b(i): {1}, c(i): {2}", i, b(i), c(i))
            }
            var result2 = BetaflintodDisX2Arb(LeftTail, Righttail, p, b, c);
            Console.WriteLine("result2: {0}", result2);
            var resultL = -aflint.log(result2);
            Console.WriteLine("resultL: {0}", resultL);
            var resultM = -n * aflint.log(result2);
            Console.WriteLine("resultM: {0}", resultM);
            BetaflintodDis2Arb(p, b, c, result2, ref LeftTail2, ref RightTail2);
            Console.WriteLine("LeftTail2: {0}", LeftTail2);

            NewBetaflintodDistArb(LeftTail, Righttail, p, n / aflint.t(2), b, c, resultM);
        }


        public static void NewBetaflintodDistArb(Arb LeftTail, Arb RightTail, int k, Arb n2, ArbMat bi, ArbMat ci, Arb resultM)
        {
            int j;
            var y = new ArbMat();
            var xi = new ArbMat();
            var eta = new ArbMat();
            y.Resize(k + 4, 1);
            xi.Resize(k + 4, 1);
            eta.Resize(k + 4, 1);

            var loopTo = k;
            for (j = 1; j <= loopTo; j++)
            {
                y[j] = n2;
                xi[j] = bi[j] - n2;
                eta[j] = ci[j] - bi[j] + xi[j];   // simplify later
                                                  // Console.WriteLine("j: {0}, y(j): {1}, eta(j): {2}, xi(j): {3}", j, y(j), eta(j), xi(j))
            }

            Console.WriteLine("");
            Console.WriteLine("Hello TestBoxDavis");
            var TargetError = aflint.t("1.0E-20");

            // TestBoxDavisArb("Quantile", "CHI2", k, k, y, y, xi, eta, resultM, LeftTail, RightTail, TargetError)
            // Console.WriteLine("resultM: {0}", resultM)
            TestBoxDavisArb("PValue", "CHI2", k, k, y, y, xi, eta, ref resultM, ref LeftTail, ref RightTail, TargetError);
            Console.WriteLine("LeftTail: {0}", LeftTail);


            // TestBoxDavisArb("Quantile", "CornishFisher", k, k, y, y, xi, eta, resultM, LeftTail, RightTail, TargetError)
            // Console.WriteLine("resultM: {0}", resultM)
            TestBoxDavisArb("PValue", "CornishFisher", k, k, y, y, xi, eta, ref resultM, ref LeftTail, ref RightTail, TargetError);
            Console.WriteLine("LeftTail: {0}, RightTail: {1}", LeftTail, RightTail);

        }


        public static void TestBoxDavisArb(string C_Result, string C_Algorithm, int a, int b, ArbMat x, ArbMat y, ArbMat xi, ArbMat eta, ref Arb z, ref Arb LeftTail, ref Arb RightTail, Arb TargetError)
        {
            int k, j, r, rsign, rmax;
            Arb sum1 = new Arb(), sum2 = new Arb(), f = new Arb(), rho = new Arb();
            var omega = new ArbMat();


            if (C_Algorithm == "CHI2")
            {

                // Calculate f
                sum1 = aflint.zero();
                var loopTo = a;
                for (k = 1; k <= loopTo; k++)
                    sum1 = sum1 + xi[k];
                sum2 = aflint.zero();
                var loopTo1 = b;
                for (j = 1; j <= loopTo1; j++)
                    sum2 = sum2 + eta[j];
                f = -2 * (sum1 - sum2 - (a - b) / 2d);
                Console.WriteLine("f: {0}", f);

                // Calculate rho
                sum1 = aflint.zero();
                var loopTo2 = a;
                for (k = 1; k <= loopTo2; k++)
                    sum1 = sum1 + aflint.bernpoly(xi[k], 2) / x[k];
                sum2 = aflint.t(0);
                var loopTo3 = b;
                for (j = 1; j <= loopTo3; j++)
                    sum2 = sum2 + aflint.bernpoly(eta[j], 2) / y[j];
                rho = 1 - (sum1 - sum2) / f;
                Console.WriteLine("rho: {0}", rho);

                // Calculate omega
                rmax = 40;
                rsign = -1;
                omega.Resize(rmax + 1, 1);

                var loopTo4 = rmax;
                for (r = 1; r <= loopTo4; r++)
                {
                    rsign = -rsign;
                    sum1 = aflint.zero();
                    var loopTo5 = a;
                    for (k = 1; k <= loopTo5; k++)
                        // sum1 = sum1 + aflint.bernpoly((1 - rho) * x(k) + xi(k), r + 1) / ((rho * x(k)) ^ r)
                        sum1 = sum1 + aflint.bernpoly((1 - rho) * x[k] + xi[k], r + 1) / aflint.pow(rho * x[k], r);
                    sum2 = aflint.zero();
                    var loopTo6 = b;
                    for (j = 1; j <= loopTo6; j++)
                        sum2 = sum2 + aflint.bernpoly((1 - rho) * y[j] + eta[j], r + 1) / aflint.pow(rho * y[j], r);
                    omega[r] = rsign * (sum1 - sum2) / (r * (r + 1));
                }

                if (C_Result == "PValue") // Get p-value
                {
                    GuptaArbNew(rmax, f, z * rho, rho, omega, TargetError, ref LeftTail);
                }

                if (C_Result == "Quantile") // Get Quantile
                {
                    DavisPercentileArb(f, ref z, LeftTail, RightTail, rho, omega);
                }

            }


            if (C_Algorithm == "CornishFisher")
            {

                // Calculate cumulants
                Console.WriteLine("");
                Console.WriteLine("Hello Calculate cumulants");

                rmax = 60;
                var kappa = new ArbMat();
                kappa.Resize(rmax + 1, 1);
                var loopTo7 = rmax;
                for (r = 1; r <= loopTo7; r++)
                {
                    sum1 = aflint.zero();
                    var loopTo8 = a;
                    for (k = 1; k <= loopTo8; k++)
                        // sum1 = sum1 + ((-2 * x(k)) ^ r) * aflint.polygamma(r - 1, x(k) + xi(k))
                        sum1 = sum1 + aflint.pow(-2 * x[k], r) * aflint.polygamma(r - 1, x[k] + xi[k]);
                    sum2 = aflint.zero();
                    var loopTo9 = b;
                    for (j = 1; j <= loopTo9; j++)
                        // sum2 = sum2 + ((-2 * y(j)) ^ r) * aflint.polygamma(r - 1, y(j) + eta(j))
                        sum2 = sum2 + aflint.pow(-2 * y[j], r) * aflint.polygamma(r - 1, y[j] + eta[j]);
                    kappa[r] = sum1 - sum2;
                    // Console.WriteLine("r: {0}, kappa (r): {1}", r, kappa(r))
                }
                var mean = kappa[1];
                var sigma = aflint.sqrt(kappa[2]);

                if (C_Result == "Quantile") // Get quantile
                {
                    var XX = DistXArb.ndisxArb(LeftTail, RightTail);
                    var XAdj = DistCornishArb.CFArb_Continuous(rmax, XX, kappa, TargetError);
                    z = mean + sigma * XAdj;
                }

                if (C_Result == "PValue") // Get p-value
                {
                    Console.WriteLine("");
                    var fxTarget = (z - mean) / sigma;
                    Console.WriteLine("z: {0}, fxTarget: {1}", z, fxTarget);
                    var x3Start = DistCornishArb.CF_up(fxTarget, kappa);
                    var Result2 = DistCornishArb.InvCornArbContinuous(fxTarget, x3Start, kappa, rmax, TargetError);
                    LeftTail = DistXArb.NdisArb(Result2);
                    RightTail = DistXArb.NdisArb(-Result2);
                }
            }

        }




    }
}