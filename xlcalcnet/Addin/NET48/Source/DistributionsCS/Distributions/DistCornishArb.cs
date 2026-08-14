using System;
using ArbPrecNet;

namespace Distributions
{


    static class DistCornishArb
    {


        public static Arb CF_xp(Arb xp, ArbMat kappa)
        {
            var result = new Arb();
            var xp2 = new Arb();
            var xp3 = new Arb();
            var xp5 = new Arb();
            var kappa3 = new Arb();
            var kappa4 = new Arb();
            var kappa5 = new Arb();
            var kappa6 = new Arb();
            var S2 = new Arb();
            xp2 = xp * xp;
            xp3 = xp * xp2;
            xp5 = xp3 * xp2;
            S2 = kappa[2] * kappa[2];
            kappa4 = kappa[4] / S2;
            kappa6 = kappa[6] / (S2 * S2);
            result = xp + kappa4 * (xp3 - 3 * xp) / 24 + kappa6 * (xp5 - 100 * xp3 + 15 * xp) / 720 - kappa4 * kappa4 * (3 * xp5 - 24 * xp3 + 29 * xp) / 384;
            return result;
        }


        public static Arb CF_xp_new(Arb xp, ArbMat kappa)
        {
            var result = new Arb();
            var xp2 = new Arb();
            var xp3 = new Arb();
            var xp4 = new Arb();
            var xp5 = new Arb();
            var kappa3 = new Arb();
            var kappa4 = new Arb();
            var kappa5 = new Arb();
            var kappa6 = new Arb();
            var S = new Arb();
            var S2 = new Arb();
            var LeftApprox = new Arb();
            var Adj = new Arb();
            xp2 = xp * xp;
            xp3 = xp * xp2;
            xp4 = xp * xp3;
            xp5 = xp3 * xp2;
            S = aflint.sqrt(kappa[2]);
            S2 = kappa[2]; // * kappa(2)
            kappa3 = kappa[3] / (S2 * S);
            kappa4 = kappa[4] / (S2 * S2);
            kappa5 = kappa[5] / (S2 * S2 * S);
            kappa6 = kappa[6] / (S2 * S2 * S2);
            // Console.WriteLine("kappa3: {0}", kappa3)
            // Console.WriteLine("kappa4: {0}", kappa4)
            // Console.WriteLine("kappa5: {0}", kappa5)
            // Console.WriteLine("kappa6: {0}", kappa6)

            // Console.WriteLine("")
            result = xp;
            Console.WriteLine("result: {0}", result);

            Console.WriteLine("");
            Adj = +kappa3 * (xp2 - 1) / 6;
            result = result + Adj;
            Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result);

            Console.WriteLine("");
            Adj = +kappa4 * (xp3 - 3 * xp) / 24;
            result = result + Adj;
            Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result);

            Adj = -kappa3 * kappa3 * (2 * xp3 - 5 * xp) / 36;
            result = result + Adj;
            Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result);

            Console.WriteLine("");
            Adj = +kappa5 * (xp4 - 6 * xp2 + 3) / 120;
            result = result + Adj;
            Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result);


            Adj = -kappa3 * kappa4 * (1 * xp4 - 5 * xp2 + 2) / 24;
            result = result + Adj;
            Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result);


            Adj = +kappa3 * kappa3 * kappa3 * (12 * xp4 - 53 * xp2 + 17) / 324;
            result = result + Adj;
            Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result);

            // Console.WriteLine("")

            // Adj = +kappa6 * (xp5 - 100 * xp3 + 15 * xp) / 720
            // result = result + Adj
            // Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)


            // Adj = -kappa3 * kappa5 * (2 * xp5 - 17 * xp3 + 21 * xp) / 180
            // result = result + Adj
            // Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)

            // Adj = -kappa4 * kappa4 * (3 * xp5 - 24 * xp3 + 29 * xp) / 384
            // result = result + Adj
            // Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)


            // Adj = +kappa3 * kappa3 * kappa4 * (14 * xp5 - 103 * xp3 + 107 * xp) / 288
            // result = result + Adj
            // Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)


            // Adj = +kappa4 * kappa4 * kappa4 * (252 * xp5 - 1688 * xp3 + 1511 * xp) / 7776
            // result = result + Adj
            // Console.WriteLine("result: {0}, Adj/result: {1}", result, Adj / result)






            // result = xp + kappa4 * (xp3 - 3 * xp) / 24 + kappa6 * (xp5 - 100 * xp3 + 15 * xp) / 720 - kappa4 * kappa4 * (3 * xp5 - 24 * xp3 + 29 * xp) / 384
            return result;
        }

        public static Arb CF_up(Arb xp, ArbMat kappa)
        {
            var result = new Arb();
            var xp2 = new Arb();
            var xp3 = new Arb();
            var xp4 = new Arb();
            var xp5 = new Arb();
            var kappa3 = new Arb();
            var kappa4 = new Arb();
            var kappa5 = new Arb();
            var kappa6 = new Arb();
            var S = new Arb();
            var S2 = new Arb();
            var LeftApprox = new Arb();
            var Adj = new Arb();
            xp2 = xp * xp;
            xp3 = xp * xp2;
            xp4 = xp * xp3;
            xp5 = xp3 * xp2;
            S = aflint.sqrt(kappa[2]);
            S2 = kappa[2]; // * kappa(2)
            kappa3 = kappa[3] / (S2 * S);
            kappa4 = kappa[4] / (S2 * S2);
            kappa5 = kappa[5] / (S2 * S2 * S);
            kappa6 = kappa[6] / (S2 * S2 * S2);
            result = xp;
            LeftApprox = DistXArb.NdisArb(result);
            // Console.WriteLine("result: {0}, LeftApprox: {1}", result, LeftApprox)

            // Console.WriteLine("")
            Adj = -kappa3 * (xp2 - 1) / 6;
            result = result + Adj;
            LeftApprox = DistXArb.NdisArb(result);
            // Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)

            // Console.WriteLine("")
            Adj = -kappa4 * (xp3 - 3 * xp) / 24;
            result = result + Adj;
            LeftApprox = DistXArb.NdisArb(result);
            // Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)


            Adj = +kappa3 * kappa3 * (4 * xp3 - 7 * xp) / 36;
            result = result + Adj;
            LeftApprox = DistXArb.NdisArb(result);
            // Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)

            // Console.WriteLine("")
            Adj = -kappa5 * (xp4 - 6 * xp2 + 3) / 120;
            result = result + Adj;
            LeftApprox = DistXArb.NdisArb(result);
            // Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)


            Adj = +kappa3 * kappa4 * (11 * xp4 - 42 * xp2 + 15) / 144;
            result = result + Adj;
            LeftApprox = DistXArb.NdisArb(result);
            // Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)


            Adj = -kappa3 * kappa3 * kappa3 * (69 * xp4 - 187 * xp2 + 52) / 648;
            result = result + Adj;
            LeftApprox = DistXArb.NdisArb(result);
            // Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)

            // Console.WriteLine("")
            // Adj = -kappa6 * (xp5 - 10 * xp3 + 15 * xp) / 720
            // result = result + Adj
            // LeftApprox = NdisArb(result)
            // Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)


            // Adj = +kappa3 * kappa5 * (7 * xp5 - 48 * xp3 + 51 * xp) / 360
            // result = result + Adj
            // LeftApprox = NdisArb(result)
            // Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)

            // Console.WriteLine("")
            // Adj = +kappa4 * kappa4 * (5 * xp5 - 32 * xp3 + 35 * xp) / 384
            // result = result + Adj
            // LeftApprox = NdisArb(result)
            // Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)


            // Adj = -kappa3 * kappa3 * kappa4 * (111 * xp5 - 547 * xp3 + 456 * xp) / 8640
            // result = result + Adj
            // LeftApprox = NdisArb(result)
            // Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)


            // Adj = +kappa4 * kappa4 * kappa4 * (948 * xp5 - 3628 * xp3 + 2473 * xp) / 7776
            // result = result + Adj
            // LeftApprox = NdisArb(result)
            // Console.WriteLine("result: {0}, LeftApprox: {1}, Adj/result: {2}", result, LeftApprox, Adj / result)

            // Console.WriteLine("")
            // Console.WriteLine("")

            return result;
        }



        public static Arb GuessLeftTailArb(Arb x, ArbMat kappa)
        {
            var result = new Arb();
            var xp = new Arb();
            var up1 = new Arb();
            var mean = new Arb();
            var sigma = new Arb();
            xp = x;
            Console.WriteLine("x: {0}", x);
            mean = kappa[1];
            Console.WriteLine("mean: {0}", mean);

            sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("sigma: {0}", sigma);

            up1 = CF_up(xp, kappa);
            Console.WriteLine("up1: {0}", up1);

            var LeftApprox = DistXArb.NdisArb(up1);
            Console.WriteLine("LeftApprox: {0}", LeftApprox);

            return LeftApprox;
        }






        public static Arb GuessQuantileArb(Arb LeftTail, ArbMat kappa)
        {
            var result = new Arb();
            var xp = new Arb();
            var up1 = new Arb();
            var mean = new Arb();
            var sigma = new Arb();
            xp = DistXArb.ndisxArb(LeftTail, 1 - LeftTail);
            Console.WriteLine("xp: {0}", xp);
            mean = kappa[1];
            Console.WriteLine("mean: {0}", mean);

            sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("sigma: {0}", sigma);

            up1 = CF_xp(xp, kappa);
            Console.WriteLine("up1: {0}", up1);


            result = mean + sigma * up1;
            return result;
        }


        public static void aflint_NoncentralChi2_Cumulants(int Order, Arb nu, Arb lambda, ArbMat kappa)
        {
            kappa.Resize(Order + 1, 1);
            kappa[1] = nu + lambda;
            for (int i = 2, loopTo = Order; i <= loopTo; i++)
                // Console.WriteLine("i: {0}, kappa(i): {1}, gamma(i+1): {2}", i, kappa(i), kappa(i) * s1 / aflint.gamma(i + 1))
                kappa[i] = kappa[i - 1] * 2 * (i - 1) * (1 + lambda / (nu + (i - 1) * lambda));
        }


        public static void aflint_NoncentralChi2_CGF_By_Cumulants(int deriv, int Order, Arb s, ArbMat kappa)
        {
            var s1 = aflint.t("1");
            var sum = aflint.t("0");
            if (deriv > 0)
            {
                sum = kappa[deriv];
            }
            var count = default(int);
            for (int i = 1, loopTo = Order - deriv; i <= loopTo; i++)
            {
                count = count + 1;
                s1 = s1 * s;
                var k = kappa[i + deriv];
                var summand = k * s1 / aflint.gamma(i + 1);
                sum = sum + summand;
                // Console.WriteLine("i: {0}, kappa(i): {1}, summand: {2}, sum: {3}", i, k, summand, sum)
                if (i % 2 == 0)
                {
                    var RelErr = summand / sum;
                    // Console.WriteLine("RelErr: {0}", RelErr)
                    // If RelErr < aflint.epsilon() Then Exit For
                    if (RelErr < aflint.epsilon())
                        break;
                }
            }
            Console.WriteLine("count: {0}", count);
            Console.WriteLine("result1: {0}", sum);
        }

        public static void Demo_CGF_By_Cumulants()
        {
            ArbPrec.SetDps(60);
            Arb s, nu, lambda;
            int Order;
            Order = 300;
            nu = aflint.t(5000);
            lambda = aflint.t(0);
            s = aflint.t("0.3");

            var kappa = new ArbMat();
            aflint_NoncentralChi2_Cumulants(Order, nu, lambda, kappa);
            int deriv = 3;
            aflint_NoncentralChi2_CGF_By_Cumulants(deriv, Order, s, kappa);

            var result2 = DistNArb.aflint_NonCentralChi2_CGF_Derivative(s, nu, lambda, deriv);
            Console.WriteLine("result2: {0}", result2);
        }


        public static void Demo_Saddlepoint_By_Cumulants()
        {
            ArbPrec.SetDps(60);
            Arb s, nu, lambda;
            //int Order;
            //int Order = 300;
            nu = aflint.t(50);
            lambda = aflint.t(10);
            int deriv = 1;
            var x = aflint.t("40.3");

            for (int i = -10; i <= 10; i++)
            {
                s = aflint.t(i) / 11;
                var result2 = DistNArb.aflint_NonCentralChi2_CGF_Derivative(s, nu, lambda, deriv);
                result2 = result2 - x;
                Console.WriteLine("s: {0}, result2: {1}", s, result2);
            }

            s = -(1 / (4 * x)) * (nu - 2 * x + aflint.sqrt(nu * nu + 4 * x * lambda));
            Console.WriteLine("s: {0}", s);


        }











        public static void CornishEdgeworthDemoArb()
        {
            ArbPrec.SetDps(760);

            // Dim i As Integer
            Arb mean;
            Arb x;
            Arb sigma;
            Arb nu;
            Arb lambda;
            Arb LeftTail;
            Arb RightTail; // , density As Arb
            int Order;
            Order = 200;
            nu = aflint.t(5000);
            lambda = aflint.t(0);
            LeftTail = aflint.t("1E-16");
            RightTail = 1 - LeftTail;

            // aflint.swap(LeftTail, RightTail)
            Console.WriteLine("Target LeftTail: {0}, Target RightTail: {1}", LeftTail, RightTail);


            var kappa = new ArbMat();
            aflint_NoncentralChi2_Cumulants(Order, nu, lambda, kappa);


            // aflint.mat_resize(kappa, Order + 1, 1)
            // kappa(1) = nu + lambda
            // For i = 2 To Order
            // kappa(i) = kappa(i - 1) * 2 * (i - 1) * (1 + lambda / (nu + (i - 1) * lambda))
            // Next i



            mean = kappa[1];
            Console.WriteLine("mean: {0}", mean);

            sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("sigma: {0}", sigma);


            x = DistXArb.ndisxArb(LeftTail, RightTail);
            Console.WriteLine("");

            var XAdj = CFArb_Continuous(Order - 2 * 0, x, kappa, aflint.t("1E-40"));
            var Quantile = mean + sigma * XAdj;
            Console.WriteLine("(mean + sigma * XAdj): {0}", Quantile);

            // Quantile = aflint.floor(Quantile)
            Console.WriteLine("Quantile1: {0}", Quantile);

            Quantile = Quantile.Supremum();

            Console.WriteLine("Quantile2: {0}", Quantile);


            Arb LeftTail1 = new Arb(), RightTail1 = new Arb(), density = new Arb();
            double argLeftTail = LeftTail1.AsDouble();
            double argRightTail = RightTail1.AsDouble();
            DistN.Cdisn_Penev(nu.AsDouble(), Quantile.AsDouble(), lambda.AsDouble(), ref argLeftTail, ref argRightTail);
            Console.WriteLine("LeftTail1: {0}, RightTail1: {1}", LeftTail1, RightTail1);

            DistXArb.cdis2Arb(nu, Quantile, ref LeftTail1, ref RightTail1, ref density);
            // cdis2Arb(F, aflint.t("51184"), LeftTail1, RightTail1, density)
            Console.WriteLine("LeftTail1: {0}, RightTail1: {1}, density: {2},", LeftTail1, RightTail1, density);

        }



        public static Arb InvCornArbContinuous(Arb fxTarget, Arb x3Start, ArbMat kappa, int nord, Arb TargetError)
        {
            var RelErrorEst = new Arb();
            var x1 = new Arb();
            var x2 = new Arb();
            var x3 = new Arb();
            var fx1 = new Arb();
            var fx2 = new Arb();
            var fx3 = new Arb();
            fxTarget = fxTarget.Mid;
            x2 = x3Start * aflint.t("0.9999");
            fx2 = CFArb_Continuous(nord - 2, x2, kappa, TargetError).Mid;
            int i = 0;
            do
            {
                if (i == 0)
                    x3 = x3Start.Mid;
                else
                    x3 = (x1 - (x2 - x1) / (fx2 - fx1) * (fx1 - fxTarget)).Mid;
                fx3 = CFArb_Continuous(nord - 2, x3, kappa, TargetError).Mid;
                RelErrorEst = aflint.abs((fx3 - fxTarget) / fxTarget);
                Console.WriteLine("i: {0}, RelErrorEst: {1}", i, RelErrorEst);
                x1 = x2.Mid;
                x2 = x3.Mid;
                fx1 = fx2.Mid;
                fx2 = fx3.Mid;
                i = i + 1;
            }
            // Loop Until ((RelErrorEst < aflint.t("1E-45")) Or (i > 100))
            while (!(RelErrorEst < TargetError | i > 100));
            return x3;
        }



        public static Arb CFArb_Continuous(int nord, Arb X, ArbMat kappa, Arb TargetError)
        {
            // Calculates adjustments for Cornish expansion
            var a = new ArbMat();
            var d = new ArbMat();
            var h = new ArbMat();
            var p = new ArbMat();
            int j;
            int ja;
            int jal;
            int jb;
            int jbl;
            int k;
            int L;
            var aa = new Arb();
            var bc = new Arb();
            var cc = new Arb();
            var DD = new Arb();
            var fac = new Arb();

            int i;
            var Sigma = new Arb();
            var S2 = new Arb();
            var ac = new ArbMat();
            var del = new ArbMat();
            ac.Resize(nord + 1, 1);
            del.Resize(nord + 1, 1);
            Sigma = aflint.sqrt(kappa[2]);
            S2 = Sigma * Sigma;
            var loopTo = nord;
            for (i = 3; i <= loopTo; i++)
            {
                S2 = S2 * Sigma;
                ac[i - 2] = kappa[i] / S2;
                // Console.WriteLine("i: {0}, kappa(i): {1}, ac(i - 2): {2}", i, kappa(i), ac(i - 2))
            }

            a.Resize(nord + 1, 1);
            d.Resize(nord + 1, 1);
            h.Resize(3 * nord + 3, 1);
            p.Resize((3 * nord + 3) * (nord + 1 + 1) / 2, 1);
            var Xadj = new Arb();
            var dXadj = new Arb();
            var LowestXadj = new Arb();
            var LowestdXadj = new Arb();
            bool NoConvergence = false;
            int LowestXAdjPos = 0;
            int PosDiffMax = 18;
            // Xadj = X
            LowestXadj = X;
            LowestdXadj = aflint.t(100);

            // Console.WriteLine("X: {0}", X)

            cc = aflint.t(-1);
            var loopTo1 = nord;
            for (j = 1; j <= loopTo1; j++)
            {
                a[j] = cc * ac[j] / ((j + 1) * (j + 2));
                cc = -cc;
                // Console.WriteLine("j: {0}, a(j): {1}", j, a(j))
            }
            h[1] = -X;
            h[2] = X * X - 1;
            var loopTo2 = 3 * nord;
            for (j = 3; j <= loopTo2; j++)
                h[j] = -(X * h[j - 1] + (j - 1) * h[j - 2]);
            var loopTo3 = 3 * nord * (nord + 1) / 2;
            for (j = 1; j <= loopTo3; j++)
                p[j] = aflint.t(0);
            d[1] = -a[1] * h[2];
            del[1] = d[1];
            Xadj = X + del[1]; // New
            p[1] = d[1];
            p[3] = a[1];
            ja = 0;
            fac = aflint.t(1);

            j = 1;
            do
            {
                j = j + 1;
                fac = fac * j;
                ja = ja + 3 * (j - 1);
                jb = ja;
                bc = aflint.t(1);
                var loopTo4 = j - 1;
                for (k = 1; k <= loopTo4; k++)
                {
                    DD = bc * d[k];
                    aa = bc * a[k];
                    jb = jb - 3 * (j - k);
                    var loopTo5 = 3 * (j - k);
                    for (L = 1; L <= loopTo5; L++)
                    {
                        jbl = jb + L;
                        jal = ja + L;
                        p[jal + 1] = p[jal + 1] + DD * p[jbl];
                        p[jal + k + 2] = p[jal + k + 2] + aa * p[jbl];
                    }
                    bc = bc * (j - k) / k;
                }
                p[ja + j + 2] = p[ja + j + 2] + a[j];
                d[j] = aflint.t(0);
                var loopTo6 = 3 * j;
                for (L = 2; L <= loopTo6; L++)
                {
                    var temp = p[ja + L] * h[L - 1];
                    d[j] = d[j] - temp;
                }
                p[ja + 1] = d[j];
                del[j] = d[j] / fac;
                // Console.WriteLine("del(j): {0}, fac: {1}", del(j), fac)


                if (aflint.abs(del[j]) > aflint.t(0))
                {
                    Xadj = Xadj + del[j];
                    dXadj = del[j] / Xadj;
                    if (aflint.abs(dXadj) < aflint.abs(LowestdXadj))
                    {
                        if (j >= 6)
                        {
                            LowestdXadj = dXadj;
                            LowestXadj = Xadj;
                            LowestXAdjPos = j;
                        }
                    }
                    // Console.WriteLine(" j: {0}, Xadj: {1}, dXadj: {2},  LowestXAdjPos: {3},  PosDiff: {4}", j, Xadj, dXadj, LowestXAdjPos, j - LowestXAdjPos)
                }
            }
            // Next j
            // If (aflint.abs(dXadj) > aflint.t("0.4")) Then NoConvergence = True

            // Loop Until (j >= nord) Or (aflint.abs(dXadj) < aflint.t("1E-18") Or ((j - LowestXAdjPos) > PosDiffMax) Or NoConvergence)
            while (!(j >= nord - 2 | aflint.abs(dXadj) < TargetError | j - LowestXAdjPos > PosDiffMax | NoConvergence));

            Console.WriteLine(" LowestXAdjPos: {0}, LowestXadj: {1}, LowestdXadj: {2},  ", LowestXAdjPos, LowestXadj, LowestdXadj);
            // If (aflint.abs(LowestdXadj) > aflint.t("1E-5") And (nord > 8)) Then NoConvergence = True
            // If (aflint.abs(LowestdXadj) > aflint.t("1E-1") And (nord > 8)) Then NoConvergence = True
            if (NoConvergence)
                Xadj = aflint.nan();
            return Xadj;
        }



        public static Arb CFArb(int nord, Arb X, ArbMat kappa)
        {
            // Calculates adjustments for Cornish expansion
            var a = new ArbMat();
            var d = new ArbMat();
            var h = new ArbMat();
            var p = new ArbMat();
            int j;
            int ja;
            int jal;
            int jb;
            int jbl;
            int k;
            int L;
            var aa = new Arb();
            var bc = new Arb();
            var cc = new Arb();
            var DD = new Arb();
            var fac = new Arb();

            int i;
            var Sigma = new Arb();
            var S2 = new Arb();
            var ac = new ArbMat();
            var del = new ArbMat();
            ac.Resize(nord + 1, 1);
            del.Resize(nord + 1, 1);
            Sigma = aflint.sqrt(kappa[2]);
            S2 = Sigma * Sigma;
            var loopTo = nord;
            for (i = 3; i <= loopTo; i++)
            {
                S2 = S2 * Sigma;
                ac[i - 2] = kappa[i] / S2;
                // Console.WriteLine("i: {0}, kappa(i): {1}, ac(i - 2): {2}", i, kappa(i), ac(i - 2))
            }

            a.Resize(nord + 1, 1);
            d.Resize(nord + 1, 1);
            h.Resize(3 * nord + 3, 1);
            p.Resize((3 * nord + 3) * (nord + 1 + 1) / 2, 1);
            var Xadj = new Arb();
            var dXadj = new Arb();
            var LowestXadj = new Arb();
            var LowestdXadj = new Arb();
            bool NoConvergence = false;
            int LowestXAdjPos = 0;
            int PosDiffMax = 18;
            // Xadj = X
            LowestXadj = X;
            LowestdXadj = aflint.t(100);

            Console.WriteLine("X: {0}", X);

            cc = aflint.t(-1);
            var loopTo1 = nord;
            for (j = 1; j <= loopTo1; j++)
            {
                a[j] = cc * ac[j] / ((j + 1) * (j + 2));
                cc = -cc;
                // Console.WriteLine("j: {0}, a(j): {1}", j, a(j))
            }
            h[1] = -X;
            h[2] = X * X - 1;
            var loopTo2 = 3 * nord;
            for (j = 3; j <= loopTo2; j++)
                h[j] = -(X * h[j - 1] + (j - 1) * h[j - 2]);
            var loopTo3 = 3 * nord * (nord + 1) / 2;
            for (j = 1; j <= loopTo3; j++)
                p[j] = aflint.t(0);
            d[1] = -a[1] * h[2];
            del[1] = d[1];
            Xadj = X + del[1]; // New
            p[1] = d[1];
            p[3] = a[1];
            ja = 0;
            fac = aflint.t(1);

            j = 1;
            do
            {
                j = j + 1;
                fac = fac * j;
                ja = ja + 3 * (j - 1);
                jb = ja;
                bc = aflint.t(1);
                var loopTo4 = j - 1;
                for (k = 1; k <= loopTo4; k++)
                {
                    DD = bc * d[k];
                    aa = bc * a[k];
                    jb = jb - 3 * (j - k);
                    var loopTo5 = 3 * (j - k);
                    for (L = 1; L <= loopTo5; L++)
                    {
                        jbl = jb + L;
                        jal = ja + L;
                        p[jal + 1] = p[jal + 1] + DD * p[jbl];
                        p[jal + k + 2] = p[jal + k + 2] + aa * p[jbl];
                    }
                    bc = bc * (j - k) / k;
                }
                p[ja + j + 2] = p[ja + j + 2] + a[j];
                d[j] = aflint.t(0);
                var loopTo6 = 3 * j;
                for (L = 2; L <= loopTo6; L++)
                {
                    var temp = p[ja + L] * h[L - 1];
                    d[j] = d[j] - temp;
                }
                p[ja + 1] = d[j];
                del[j] = d[j] / fac;
                // Console.WriteLine("del(j): {0}, fac: {1}", del(j), fac)


                if (aflint.abs(del[j]) > aflint.t(0))
                {
                    Xadj = Xadj + del[j];
                    dXadj = del[j] / Xadj;
                    if (aflint.abs(dXadj) < aflint.abs(LowestdXadj))
                    {
                        if (j >= 6)
                        {
                            LowestdXadj = dXadj;
                            LowestXadj = Xadj;
                            LowestXAdjPos = j;
                        }
                    }
                    Console.WriteLine(" j: {0}, Xadj: {1}, dXadj: {2},  LowestXAdjPos: {3},  PosDiff: {4}", j, Xadj, dXadj, LowestXAdjPos, j - LowestXAdjPos);
                }
                // Next j
                if (aflint.abs(dXadj) > aflint.t("0.4"))
                    NoConvergence = true;
            }

            // Loop Until (j >= nord) Or (aflint.abs(dXadj) < aflint.t("1E-18") Or ((j - LowestXAdjPos) > PosDiffMax) Or NoConvergence)
            while (!(j >= nord - 2 | aflint.abs(dXadj) < aflint.t("1E-18") | j - LowestXAdjPos > PosDiffMax | NoConvergence));

            Console.WriteLine(" LowestXAdjPos: {0}, LowestXadj: {1}, LowestdXadj: {2},  ", LowestXAdjPos, LowestXadj, LowestdXadj);
            // If (aflint.abs(LowestdXadj) > aflint.t("1E-5") And (nord > 8)) Then NoConvergence = True
            if (aflint.abs(LowestdXadj) > aflint.t("1E-1") & nord > 8)
                NoConvergence = true;
            if (NoConvergence)
                Xadj = aflint.nan();
            return Xadj;
        }



        public static Arb InvCornArb(Arb fxTarget, Arb x3Start, ArbMat kappa, int nord)
        {
            var RelErrorEst = new Arb();
            var x1 = new Arb();
            var x2 = new Arb();
            var x3 = new Arb();
            var fx1 = new Arb();
            var fx2 = new Arb();
            var fx3 = new Arb();
            fxTarget = fxTarget.Mid;
            x2 = x3Start * aflint.t("0.9999");
            fx2 = CFArb(nord - 2, x2, kappa).Mid;
            int i = 0;
            do
            {
                if (i == 0)
                    x3 = x3Start.Mid;
                else
                    x3 = (x1 - (x2 - x1) / (fx2 - fx1) * (fx1 - fxTarget)).Mid;
                fx3 = CFArb(nord - 2, x3, kappa).Mid;
                RelErrorEst = aflint.abs((fx3 - fxTarget) / fxTarget);
                Console.WriteLine("i: {0}, RelErrorEst: {1}", i, RelErrorEst);
                x1 = x2.Mid;
                x2 = x3.Mid;
                fx1 = fx2.Mid;
                fx2 = fx3.Mid;
                i = i + 1;
            }
            while (!(RelErrorEst < aflint.t("1E-45") | i > 100));
            return x3;
        }




        public static void RawToCentralArb(int k, ArbMat mraw, ArbMat mu)
        {
            int n;
            int j;
            var sign = new Arb();
            var sum = new Arb();
            var prod = new Arb();
            var BK = new Arb();
            mraw[0] = aflint.t(1);
            mu[1] = mraw[1];
            var loopTo = k;
            for (n = 2; n <= loopTo; n++)
            {
                sum = aflint.t(0);
                BK = aflint.t(1);
                prod = aflint.t(1);
                sign = aflint.t(1);
                for (j = n; j >= 0; j -= 1)
                {
                    sum = sum + sign * BK * mraw[j] * prod;
                    BK = BK * aflint.t(j) / aflint.t(n - j + 1);
                    sign = -sign;
                    prod = prod * mu[1];
                }
                mu[n] = sum;
            }
        }

        public static void CentralToRawArb(int k, ArbMat mraw, ArbMat mu)
        {
            int n;
            int j;
            var sum = new Arb();
            var prod = new Arb();
            var BK = new Arb();
            mu[0] = aflint.t(1);
            mraw[1] = mu[1];
            mu[1] = aflint.t(0);
            var loopTo = k;
            for (n = 2; n <= loopTo; n++)
            {
                sum = aflint.t(0);
                BK = aflint.t(1);
                prod = aflint.t(1);
                var loopTo1 = n;
                for (j = 0; j <= loopTo1; j++)
                {
                    sum = sum + BK * mu[n - j] * prod;
                    BK = BK * aflint.t(n - j) / aflint.t(j + 1);
                    prod = prod * mraw[1];
                }
                mraw[n] = sum;
            }
            mu[1] = mraw[1];
        }

        public static void MomentsToCumulantsArb(int n, ArbMat mu, ArbMat kappa)
        {
            // Calculates cumulants from central moments
            // Lee, 1992
            int r;
            int j;
            var sum = new Arb();
            var F = new Arb();
            kappa[1] = mu[1];
            var loopTo = n;
            for (r = 2; r <= loopTo; r++)
            {
                sum = aflint.t(0);
                F = aflint.t(r - 1);
                var loopTo1 = r - 2;
                for (j = 2; j <= loopTo1; j++)
                {
                    sum = sum + F * mu[r - j] * kappa[j];
                    F = F * (r - j) / aflint.t(j);
                }
                kappa[r] = mu[r] - sum;
            }
        }


        public static void RawMomentsToCumulantsArb(int n, ArbMat mu, ArbMat kappa)
        {
            // Calculates cumulants from central moments
            // Lee, 1992
            int r;
            int j;
            var sum = new Arb();
            var F = new Arb();
            kappa[1] = mu[1];
            var loopTo = n;
            for (r = 2; r <= loopTo; r++)
            {
                sum = aflint.t(0);
                F = aflint.t(1);
                var loopTo1 = r - 1;
                for (j = 1; j <= loopTo1; j++)
                {
                    sum = sum + F * mu[r - j] * kappa[j];
                    F = F * (r - j) / aflint.t(j);
                }
                kappa[r] = mu[r] - sum;
            }
        }




        // Get cumulants from discrete null-distribution
        public static void GetCumulantsArb(int nl, int maxmoment, ArbMat X, ArbMat kappa)
        {
            int S;
            int i;
            int j;
            var sk = new Arb();
            var mu = new ArbMat();
            S = -nl;

            mu.Resize(maxmoment + 1, 1);
            kappa.Resize(maxmoment + 1, 1);

            // ReDim mu(maxmoment)
            // ReDim kappa(maxmoment)

            var loopTo = maxmoment;
            for (j = 1; j <= loopTo; j++)
                mu[j] = aflint.t(0);
            var loopTo1 = nl;
            for (i = 0; i <= loopTo1; i++)
            {
                sk = aflint.t(1);
                var loopTo2 = maxmoment;
                for (j = 1; j <= loopTo2; j += 1)
                {
                    sk = sk * S;
                    if (j % 2 == 0)
                        mu[j] = mu[j] + X[i] * sk;
                }
                S = S + 2;
            }
            MomentsToCumulantsArb(maxmoment, mu, kappa);
            // Debug.Print "Cumulants"
            // For j = 1 To maxmoment
            // Debug.Print j, mu(j), kappa(j)
            // Next j

        }




        public static Arb JTCumArb(int j, int k, ref int[] n, ref int[] m)
        {
            // Robillard, 1972
            var F = new Arb();
            int i;
            int j2;
            int j21;
            int k1;
            int nn;
            var sum = new Arb();
            nn = m[k];
            k1 = k;
            j2 = j;
            j21 = j2 + 1;
            sum = aflint.t(0);
            F = aflint.t(1);
            var loopTo = j;
            for (i = 1; i <= loopTo; i++)
                F = F * 2;
            var loopTo1 = k;
            for (i = 1; i <= loopTo1; i++)
                // sum = sum + aflint.bernpoly(j21, n(i) + 1)
                // sum = sum + aflint.bernpoly(n(i) + 1, j21)
                sum = sum + aflint.bernpoly(aflint.t(n[i] + 1), j21);


            // Return F * aflint.bernoulli(j2) / aflint.t(j2 * j21) _
            // * (aflint.bernpoly(j21, nn + 1) + (k - 1) * aflint.bernoulli(j21) - sum)

            return F * aflint.bernoulli(j2) / aflint.t(j2 * j21) * (aflint.bernpoly(aflint.t(nn + 1), j21) + (k - 1) * aflint.bernoulli(j21) - sum);

            // JTCum = F * Bn0(j2) / (1.0 * j2 * j21) _
            // * (Bernoulli(j21, nn + 1) + (k - 1) * Bn0(j21) - sum)


        }



        public static void TerpstaCumArb(int k, int[] n, int maxmoment, ArbMat kappa, ref int TS)
        {
            var m = new int[k + 1];
            int j;
            // Dim TS As Integer
            // ReDim m(k) As Integer
            m[0] = 0;
            var loopTo = k;
            for (j = 1; j <= loopTo; j++)
                m[j] = m[j - 1] + n[j];
            TS = 0;
            var loopTo1 = k - 1;
            for (j = 1; j <= loopTo1; j++)
                TS = TS + m[j] * n[j + 1];
            // Debug.Print "TS:", TS
            var loopTo2 = maxmoment;
            for (j = 2; j <= loopTo2; j += 2)
                // kappa(j) = JTCum(j, k, n, m)
                kappa[j] = JTCumArb(j, k, ref n, ref m);
        }



        public static void MannWhitneyCumArb(int m, int n, int maxmoment, ArbMat kappa, ref int TS)
        {
            var NN = new int[3];
            NN[1] = m;
            NN[2] = n;
            TerpstaCumArb(2, NN, maxmoment, kappa, ref TS);
        }



        public static void KendallCumArb(int n, int maxcum, ArbMat kappa, ref int nl)
        {
            // Praskova, 1976
            int j2;
            int j; // , t As Integer, r As Integer
            var sign = new Arb();
            var sum = new Arb();
            var sum2 = new Arb();
            var p2 = new Arb();
            var Bn0j2 = new Arb();
            var Bn0j2_1 = new Arb();
            var Bern = new Arb();
            // Dim bn0dblj2 As Double

            maxcum = maxcum / 2;
            var loopTo = 2 * maxcum;
            for (j = 1; j <= loopTo; j++)
                kappa[j] = aflint.t(0.0d);
            p2 = aflint.t(0.5d);
            var loopTo1 = maxcum;
            for (j = 1; j <= loopTo1; j++)
            {
                if (j % 2 != 0)
                    sign = aflint.t(1);
                else
                    sign = aflint.t(-1);
                j2 = 2 * j;
                p2 = p2 * 4;

                Bern = aflint.bernpoly(aflint.t(n + 1), j2 + 1);
                Bn0j2_1 = aflint.bernoulli(j2 + 1);
                sum = (Bern - Bn0j2_1) / (j2 + 1);

                // sum = (aflint.bernpoly(n + 1, j2 + 1) - aflint.bernoulli(j2 + 1)) / (j2 + 1.0)

                // Bn0j2 = aflint.neg(aflint.bernoulli(j2))
                Bn0j2 = aflint.abs(aflint.bernoulli(j2));
                // Bn0j2 = (aflint.bernoulli(j2))

                // Console.WriteLine("Bern: {0}, Bn0j2_1: {1}, sum: {2}, Bn0j2: {3}", Bern, Bn0j2_1, sum, Bn0j2)


                sum2 = sign * p2 * Bn0j2 * (sum - n) / j;
                kappa[j2] = sum2;
                // Console.WriteLine("sign: {0}, p2: {1}, j2: {2}, (sum - n): {3}", sign, p2, j2, (sum - n))
                // Console.WriteLine("j: {0}, sum: {1}, sum2: {2}, kappa(j): {3}", j, sum, sum2, kappa(j))
                // Debug.Print j2, "  ", kappa(j2)
            }
            nl = n * (n - 1) / 2;
        }



        public static void WilcoxonCumArb(int n, int maxcum, ArbMat kappa, ref int nl)
        {
            // Fellingham, 1964
            int j2;
            int j; // , t As Integer, r As Integer
            var sum = new Arb();
            var p2 = new Arb();
            var S = new Arb();
            var sigma2 = new Arb();
            maxcum = maxcum / 2;
            var loopTo = 2 * maxcum;
            for (j = 1; j <= loopTo; j++)
                kappa[j] = aflint.t(0.0d);
            sigma2 = aflint.t(1.0d * n * (n + 1.0d) * (2.0d * n + 1.0d)) / aflint.t(6.0d);
            kappa[2] = sigma2;
            S = sigma2;
            p2 = aflint.t(4.0d);
            var loopTo1 = maxcum;
            for (j = 2; j <= loopTo1; j++)
            {
                j2 = 2 * j;
                p2 = p2 * 4.0d;
                sum = aflint.bernpoly(aflint.t(n + 1), j2 + 1);
                sum = sum - aflint.bernoulli(j2 + 1);
                sum = sum / aflint.t(j2 + 1.0d);
                S = S * sigma2;
                kappa[j2] = p2 * (p2 - 1.0d) * aflint.bernoulli(j2) * sum / aflint.t(j2);
            }
            nl = n * (n + 1) / 2;
        }






        public static void PageCumArb(int k, int n, int maxmoment, ArbMat kappa, ref int nl)
        {
            var X = new ArbMat();
            var kl = default(int);
            int i;
            SpearmanCalcArb(k, 0, ref kl, X);
            GetCumulantsArb(kl, maxmoment, X, kappa);
            var loopTo = maxmoment;
            for (i = 1; i <= loopTo; i++)
                kappa[i] = kappa[i] * n;
            nl = n * kl;
            Console.WriteLine("nl: {0}", nl);
        }








        public static void KendallInversCornishDemoArb()
        {

            var kappa = new ArbMat();
            var mean = new Arb();
            var X = new Arb();
            var sigma = new Arb();
            var z = new Arb();
            var LeftTail = new Arb();
            var RightTail = new Arb();
            var TargetLeftTail = new Arb();
            int n;
            var nl = default(int);
            int Order;
            bool CompareToExact = true;

            ArbPrec.SetDps(240);
            Order = 64; // 128 '96 '64 '32      ' multiple of 4
            n = 80;
            TargetLeftTail = aflint.t("1.0E-5");
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

            kappa.Resize(Order + 1, 1);
            KendallCumArb(n, Order, kappa, ref nl);  // Kendall  
            Console.WriteLine("nl: {0}", nl);  // 3160 for n=80;  16110 for n=180

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                // Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
                if (i > 0)
                    kappa[i] = kappa[i] - d * aflint.bernoulli(i) / i;
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }

            X = KendallCornishArb(n, TargetLeftTail);
            X = aflint.floor(X);
            Console.WriteLine("New X: {0}", X);

            mean = kappa[1];
            sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);

            z = (X - mean) / sigma;
            Console.WriteLine("z: {0}", z);

            LeftTail = GuessLeftTailArb(z, kappa);
            RightTail = 1 - LeftTail;
            Console.WriteLine("GuessLeftTailArb LeftTail {0}, RightTail: {1}", LeftTail, RightTail);

            var fxTarget = z;
            var x3Start = CF_up(z, kappa);
            Console.WriteLine("fxTarget: {0}", fxTarget);
            Console.WriteLine("x3Start : {0}", x3Start);

            var Result = InvCornArb(fxTarget, x3Start, kappa, Order);
            Console.WriteLine("Result : {0}", Result);
            Console.WriteLine("x3Start: {0}", x3Start);

            LeftTail = DistXArb.NdisArb(Result);
            RightTail = 1 - LeftTail;
            Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail);

            if (CompareToExact)
            {
                var CDF_KR = new Arb[nl + 1 + 1];
                var ExactResult = new Arb();
                var sumKR = new Arb();
                var KR = new ArbMat();
                KR = KendallCalcArb(n);
                i = 0;
                for (int Index = -nl; Index <= 0; Index += 2)
                {
                    sumKR = sumKR + KR[i];
                    CDF_KR[i] = sumKR;
                    if (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(10))
                        Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR[i]);
                    i = i + 1;
                }
                // Dim xpos As Int32 = (X + nl).ToInt32() \ 2
                int xpos = aflint.lrint(X + nl) / 2;
                // Dim xpos As Int32 = Convert.ToInt32((X + nl)) \ 2
                ExactResult = CDF_KR[xpos - 1];
                Console.WriteLine("ExactResult: {0}, xpos: {1}", ExactResult, xpos);
                Console.WriteLine("RelError:    {0}", (ExactResult - LeftTail) / ExactResult);
            }

        }

        // 


        public static void WilcoxonInversCornishDemoArb()
        {

            var kappa = new ArbMat();
            var mean = new Arb();
            var X = new Arb();
            var sigma = new Arb();
            var z = new Arb();
            var LeftTail = new Arb();
            var RightTail = new Arb();
            var TargetLeftTail = new Arb();
            int n;
            var nl = default(int);
            int Order;
            bool CompareToExact = true;

            ArbPrec.SetDps(240);
            Order = 64; // 128 '96 '64 '32      ' multiple of 4
            n = 80;
            TargetLeftTail = aflint.t("1.0E-5");
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

            kappa.Resize(Order + 1, 1);
            WilcoxonCumArb(n, Order, kappa, ref nl);  // Wilcoxon  
            Console.WriteLine("nl: {0}", nl);  // 3160 for n=80;  16110 for n=180

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                // Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
                if (i > 0)
                    kappa[i] = kappa[i] - d * aflint.bernoulli(i) / i;
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }

            X = WilcoxonCornishArb(n, TargetLeftTail);
            X = aflint.floor(X);
            Console.WriteLine("New X: {0}", X);

            mean = kappa[1];
            sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);

            z = (X - mean) / sigma;
            Console.WriteLine("z: {0}", z);

            LeftTail = GuessLeftTailArb(z, kappa);
            RightTail = 1 - LeftTail;
            Console.WriteLine("GuessLeftTailArb LeftTail {0}, RightTail: {1}", LeftTail, RightTail);

            var fxTarget = z;
            var x3Start = CF_up(z, kappa);
            Console.WriteLine("fxTarget: {0}", fxTarget);
            Console.WriteLine("x3Start : {0}", x3Start);

            var Result = InvCornArb(fxTarget, x3Start, kappa, Order);
            Console.WriteLine("Result : {0}", Result);
            Console.WriteLine("x3Start: {0}", x3Start);

            LeftTail = DistXArb.NdisArb(Result);
            RightTail = 1 - LeftTail;
            Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail);

            if (CompareToExact)
            {
                var CDF_KR = new Arb[nl + 1 + 1];
                var ExactResult = new Arb();
                var sumKR = new Arb();
                var KR = new ArbMat();
                KR = WilcoxonCalcArb(n);
                i = 0;
                for (int Index = -nl; Index <= 0; Index += 2)
                {
                    sumKR = sumKR + KR[i];
                    CDF_KR[i] = sumKR;
                    if (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(10))
                        Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR[i]);
                    i = i + 1;
                }
                // Dim xpos As Int32 = (X + nl).ToInt32() \ 2
                int xpos = aflint.lrint(X + nl) / 2;
                ExactResult = CDF_KR[xpos - 1];
                Console.WriteLine("ExactResult: {0}, xpos: {1}", ExactResult, xpos);
                Console.WriteLine("RelError:    {0}", (ExactResult - LeftTail) / ExactResult);
            }

        }



        // Need to make sure that X is even or odd, as appropriate
        public static void MannWhitneyInversCornishDemoArb()
        {

            var kappa = new ArbMat();
            var mean = new Arb();
            var X = new Arb();
            var sigma = new Arb();
            var z = new Arb();
            var LeftTail = new Arb();
            var RightTail = new Arb();
            var TargetLeftTail = new Arb();
            int m;
            int n;
            var nl = default(int);
            int Order;
            bool CompareToExact = true;

            ArbPrec.SetDps(240);
            Order = 64; // 128 '96 '64 '32      ' multiple of 4
                        // m = 40
                        // n = 60
            m = 30;
            n = 30;
            TargetLeftTail = aflint.t("1.0E-5");
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

            kappa.Resize(Order + 1, 1);
            MannWhitneyCumArb(m, n, Order, kappa, ref nl);  // MannWhitney  
            Console.WriteLine("nl: {0}", nl);  // 3160 for n=80;  16110 for n=180

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                // Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
                if (i > 0)
                    kappa[i] = kappa[i] - d * aflint.bernoulli(i) / i;
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }

            X = MannWhitneyCornishArb(m, n, TargetLeftTail);
            X = aflint.floor(X);
            Console.WriteLine("New X: {0}", X);

            mean = kappa[1];
            sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);

            z = (X - mean) / sigma;
            Console.WriteLine("z: {0}", z);

            LeftTail = GuessLeftTailArb(z, kappa);
            RightTail = 1 - LeftTail;
            Console.WriteLine("GuessLeftTailArb LeftTail {0}, RightTail: {1}", LeftTail, RightTail);

            var fxTarget = z;
            var x3Start = CF_up(z, kappa);
            Console.WriteLine("fxTarget: {0}", fxTarget);
            Console.WriteLine("x3Start : {0}", x3Start);

            var Result = InvCornArb(fxTarget, x3Start, kappa, Order);
            Console.WriteLine("Result : {0}", Result);
            Console.WriteLine("x3Start: {0}", x3Start);

            LeftTail = DistXArb.NdisArb(Result);
            RightTail = 1 - LeftTail;
            Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail);

            if (CompareToExact)
            {
                var CDF_KR = new Arb[nl + 1 + 1];
                var ExactResult = new Arb();
                var sumKR = new Arb();
                var KR = new ArbMat();
                KR = MannWhitneyCalcArb(m, n);
                i = 0;
                for (int Index = -nl; Index <= 0; Index += 2)
                {
                    sumKR = sumKR + KR[i];
                    CDF_KR[i] = sumKR;
                    if (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(10))
                        Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR[i]);
                    i = i + 1;
                }
                // Dim xpos As Int32 = (X + nl).ToInt32() \ 2
                int xpos = aflint.lrint(X + nl) / 2;
                ExactResult = CDF_KR[xpos - 1];
                Console.WriteLine("ExactResult: {0}, xpos: {1}", ExactResult, xpos);
                Console.WriteLine("RelError:    {0}", (ExactResult - LeftTail) / ExactResult);
            }

        }


        public static void TerpstaInversCornishDemoArb2()
        {
            int k = 6;
            var n = new int[k + 1];
            for (int i = 1, loopTo = k; i <= loopTo; i++)
                n[i] = 10;
            var TargetLeftTail = aflint.t("1.0E-5");
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);
            InversCornishDemoArb(k, n, TargetLeftTail);
        }

        // Need to make sure that X is even or odd, as appropriate
        public static void InversCornishDemoArb(int m, int[] n, Arb TargetLeftTail)
        {

            var kappa = new ArbMat();
            var mean = new Arb();
            var X = new Arb();
            var sigma = new Arb();
            var z = new Arb();
            var LeftTail = new Arb();
            var RightTail = new Arb();
            var nl = default(int);
            int Order;
            int i;
            bool CompareToExact = true;

            ArbPrec.SetDps(240);
            Order = 64; // 128 '96 '64 '32      ' multiple of 4
                        // m = 6
                        // Dim n(m) As Int32
                        // For i = 1 To m: n(i) = 10: Next i
                        // TargetLeftTail = aflint.t("1.0E-5")
                        // Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail)  

            kappa.Resize(Order + 1, 1);
            TerpstaCumArb(m, n, Order, kappa, ref nl);  // Terpsta  
            Console.WriteLine("nl: {0}", nl);  // 3160 for n=80;  16110 for n=180

            i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                // Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
                if (i > 0)
                    kappa[i] = kappa[i] - d * aflint.bernoulli(i) / i;
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }

            X = TerpstaCornishArb(m, n, TargetLeftTail);
            X = aflint.floor(X);
            Console.WriteLine("New X: {0}", X);

            mean = kappa[1];
            sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);

            z = (X - mean) / sigma;
            Console.WriteLine("z: {0}", z);

            LeftTail = GuessLeftTailArb(z, kappa);
            RightTail = 1 - LeftTail;
            Console.WriteLine("GuessLeftTailArb LeftTail {0}, RightTail: {1}", LeftTail, RightTail);

            var fxTarget = z;
            var x3Start = CF_up(z, kappa);
            Console.WriteLine("fxTarget: {0}", fxTarget);
            Console.WriteLine("x3Start : {0}", x3Start);

            var Result = InvCornArb(fxTarget, x3Start, kappa, Order);
            Console.WriteLine("Result : {0}", Result);
            Console.WriteLine("x3Start: {0}", x3Start);

            LeftTail = DistXArb.NdisArb(Result);
            RightTail = 1 - LeftTail;
            Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail);

            if (CompareToExact)
            {
                var CDF_KR = new Arb[nl + 1 + 1];
                var ExactResult = new Arb();
                var sumKR = new Arb();
                var KR = new ArbMat();
                KR = TerpstaCalcArb(m, n);
                i = 0;
                for (int Index = -nl; Index <= 0; Index += 2)
                {
                    sumKR = sumKR + KR[i];
                    CDF_KR[i] = sumKR;
                    if (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(10))
                        Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR[i]);
                    i = i + 1;
                }
                // Dim xpos As Int32 = (X + nl).ToInt32() \ 2
                int xpos = aflint.lrint(X + nl) / 2;
                ExactResult = CDF_KR[xpos - 1];
                Console.WriteLine("ExactResult: {0}, xpos: {1}", ExactResult, xpos);
                Console.WriteLine("RelError:    {0}", (ExactResult - LeftTail) / ExactResult);
            }

        }



        // Need to make sure that X is even or odd, as appropriate
        public static void PageInversCornishDemoArb()
        {

            var kappa = new ArbMat();
            var mean = new Arb();
            var X = new Arb();
            var sigma = new Arb();
            var z = new Arb();
            var LeftTail = new Arb();
            var RightTail = new Arb();
            var TargetLeftTail = new Arb();
            int m;
            int n;
            var nl = default(int);
            int Order;
            bool CompareToExact = true;

            ArbPrec.SetDps(240);
            Order = 64; // 128 '96 '64 '32      ' multiple of 4
            m = 6;
            n = 40;
            TargetLeftTail = aflint.t("1.0E-5");
            Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

            kappa.Resize(Order + 1, 1);
            PageCumArb(m, n, Order, kappa, ref nl);  // Page  
            Console.WriteLine("nl: {0}", nl);  // 3160 for n=80;  16110 for n=180

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                // Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
                if (i > 0)
                    kappa[i] = kappa[i] - d * aflint.bernoulli(i) / i;
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }

            X = PageCornishArb(m, n, TargetLeftTail);
            X = aflint.floor(X);
            Console.WriteLine("New X: {0}", X);

            mean = kappa[1];
            sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);

            z = (X - mean) / sigma;
            Console.WriteLine("z: {0}", z);

            LeftTail = GuessLeftTailArb(z, kappa);
            RightTail = 1 - LeftTail;
            Console.WriteLine("GuessLeftTailArb LeftTail {0}, RightTail: {1}", LeftTail, RightTail);

            var fxTarget = z;
            var x3Start = CF_up(z, kappa);
            Console.WriteLine("fxTarget: {0}", fxTarget);
            Console.WriteLine("x3Start : {0}", x3Start);

            var Result = InvCornArb(fxTarget, x3Start, kappa, Order);
            Console.WriteLine("Result : {0}", Result);
            Console.WriteLine("x3Start: {0}", x3Start);

            LeftTail = DistXArb.NdisArb(Result);
            RightTail = 1 - LeftTail;
            Console.WriteLine("LeftTail:    {0}, RightTail: {1}", LeftTail, RightTail);

            if (CompareToExact)
            {
                var CDF_KR = new Arb[nl + 1 + 1];
                var ExactResult = new Arb();
                var sumKR = new Arb();
                var KR = new ArbMat();
                int argOrder = 0;
                KR = PageCalcArb(m, n, ref argOrder);
                i = 0;
                for (int Index = -nl; Index <= 0; Index += 2)
                {
                    sumKR = sumKR + KR[i];
                    CDF_KR[i] = sumKR;
                    if (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(10))
                        Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR[i]);
                    i = i + 1;
                }
                // Dim xpos As Int32 = (X + nl).ToInt32() \ 2
                int xpos = aflint.lrint(X + nl) / 2;
                ExactResult = CDF_KR[xpos - 1];
                Console.WriteLine("ExactResult: {0}, xpos: {1}", ExactResult, xpos);
                Console.WriteLine("RelError:    {0}", (ExactResult - LeftTail) / ExactResult);
            }

        }



        public static void KendallCornishDemoArb()
        {
            int n = 80;
            var LeftTail = new Arb();
            var Result = new Arb();
            LeftTail = aflint.t(0.00000000001d);
            Result = KendallCornishArb(n, LeftTail);
            Console.WriteLine("Result: {0}", Result);
        }



        public static Arb KendallCornishArb(int n, Arb TargetLeftTail0)
        {
            var kappa = new ArbMat();
            var omega = new ArbMat();
            var mean = new Arb();
            var X = new Arb();
            var sigma = new Arb();
            var z = new Arb();
            var RightTail = new Arb();
            var sumKR = new Arb();
            int Order;
            var nl = default(int);
            var LeftTail = new Arb();
            var TargetLeftTail = new Arb();
            var GuessedQuantile = new Arb();

            ArbPrec.SetDps(60);
            Order = 64; // 128 '96 '64 '32      ' multiple of 4
            n = 80;
            kappa.Resize(Order + 1, 1);
            KendallCumArb(n, Order, kappa, ref nl);  // Kendall  
            Console.WriteLine("nl: {0}", nl);

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                // Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
                if (i > 0)
                    kappa[i] = kappa[i] - d * aflint.bernoulli(i) / i;
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }


            mean = kappa[1];
            sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);

            GuessedQuantile = GuessQuantileArb(TargetLeftTail0, kappa);
            Console.WriteLine("1: GuessedQuantile: {0}", GuessedQuantile);

            TargetLeftTail = TargetLeftTail0 / 1000;
            do
            {
                TargetLeftTail = TargetLeftTail * 1000;
                Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

                X = DistXArb.ndisxArb(TargetLeftTail, 1 - TargetLeftTail);
                var XAdj = CFArb(6, X, kappa);
                Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj);
                GuessedQuantile = mean + sigma * XAdj;

                Console.WriteLine("2: GuessedQuantile: {0}", GuessedQuantile);
            }
            // Loop While X.IsNan
            while (aflint.isnan(X));


            TargetLeftTail = TargetLeftTail0 / 1000;
            var fx2 = new Arb();
            do
            {
                TargetLeftTail = TargetLeftTail * 1000;
                Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

                // z = (X - mean) / sigma
                // Console.WriteLine( "z: {0}", z)
                // 
                // LeftTail = NdisArb(z)
                // RightTail = 1-LeftTail
                // Console.WriteLine( "Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

                X = DistXArb.ndisxArb(TargetLeftTail, 1 - TargetLeftTail);
                var XAdj = CFArb(Order - 2, X, kappa);
                Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj);
                fx2 = mean + sigma * XAdj;
                Console.WriteLine("X: {0}, XAdj: {1}", X, XAdj);
            }
            // Loop While fx2.IsNan
            while (aflint.isnan(fx2));


            // Dim xd As Int32 = fx2.ToInt32
            int xd = aflint.lrint(fx2);
            if (xd % 2 != 0)
            {
                xd = xd - 1;
            }
            X = aflint.t(xd);
            if (Math.Abs(xd) > nl)
                X = aflint.t(nl);
            Console.WriteLine("X: {0}", X);
            var KR = new ArbMat();
            KR = KendallCalcArb(n);
            i = 0;
            var CDF_KR = new Arb[nl + 1 + 1];
            for (int Index = -nl; Index <= 0; Index += 2)
            {
                sumKR = sumKR + KR[i];
                CDF_KR[i] = sumKR;
                if (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(20))
                    Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR[i]);
                i = i + 1;
            }

            return fx2;
        }









        public static void WilcoxonCornishDemoArb()
        {
            int n = 10;
            var LeftTail = new Arb();
            var Result = new Arb();
            LeftTail = aflint.t(0.00001d);
            Result = WilcoxonCornishArb(n, LeftTail);
            Console.WriteLine("Result: {0}", Result);
        }



        public static Arb WilcoxonCornishArb(int n, Arb TargetLeftTail0)
        {
            var kappa = new ArbMat();
            var omega = new ArbMat();
            var mean = new Arb();
            var X = new Arb();
            var sigma = new Arb();
            var z = new Arb();
            var RightTail = new Arb();
            var sumKR = new Arb();
            int Order;
            var nl = default(int);
            var LeftTail = new Arb();
            var TargetLeftTail = new Arb();
            var GuessedQuantile = new Arb();

            ArbPrec.SetDps(240);
            Order = 64; // 128 '96 '64 '32      ' multiple of 4
            n = 80;
            kappa.Resize(Order + 1, 1);
            WilcoxonCumArb(n, Order, kappa, ref nl);  // Wilcoxon  
            Console.WriteLine("nl: {0}", nl);

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                // Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
                if (i > 0)
                    kappa[i] = kappa[i] - d * aflint.bernoulli(i) / i;
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }


            mean = kappa[1];
            sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);

            GuessedQuantile = GuessQuantileArb(TargetLeftTail0, kappa);
            Console.WriteLine("1: GuessedQuantile: {0}", GuessedQuantile);

            TargetLeftTail = TargetLeftTail0 / 1000;
            do
            {
                TargetLeftTail = TargetLeftTail * 1000;
                Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

                X = DistXArb.ndisxArb(TargetLeftTail, 1 - TargetLeftTail);
                var XAdj = CFArb(6, X, kappa);
                Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj);
                GuessedQuantile = mean + sigma * XAdj;

                Console.WriteLine("2: GuessedQuantile: {0}", GuessedQuantile);
            }
            // Loop While X.IsNan
            while (aflint.isnan(X));


            TargetLeftTail = TargetLeftTail0 / 1000;
            var fx2 = new Arb();
            do
            {
                TargetLeftTail = TargetLeftTail * 1000;
                Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

                // z = (X - mean) / sigma
                // Console.WriteLine( "z: {0}", z)
                // 
                // LeftTail = NdisArb(z)
                // RightTail = 1-LeftTail
                // Console.WriteLine( "Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

                X = DistXArb.ndisxArb(TargetLeftTail, 1 - TargetLeftTail);
                var XAdj = CFArb(Order - 2, X, kappa);
                Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj);
                fx2 = mean + sigma * XAdj;
                Console.WriteLine("X: {0}, XAdj: {1}", X, XAdj);
            }
            // Loop While fx2.IsNan
            while (aflint.isnan(fx2));

            // Dim xd As Int32 = fx2.ToInt32
            int xd = aflint.lrint(fx2);
            if (xd % 2 != 0)
            {
                xd = xd - 1;
            }
            X = aflint.t(xd);
            if (Math.Abs(xd) > nl)
                X = aflint.t(nl);
            Console.WriteLine("X: {0}", X);
            var KR = new ArbMat();
            KR = WilcoxonCalcArb(n);
            i = 0;
            var CDF_KR = new Arb[nl + 1 + 1];
            for (int Index = -nl; Index <= 0; Index += 2)
            {
                sumKR = sumKR + KR[i];
                CDF_KR[i] = sumKR;
                if (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(20))
                    Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR[i]);
                i = i + 1;
            }

            return fx2;
        }



        public static void MannWhitneyCornishDemoArb()
        {
            int m = 30;
            int n = 30;

            var LeftTail = new Arb();
            var Result = new Arb();
            // LeftTail = aflint.t(0.001)
            LeftTail = aflint.t(0.95325d);
            Result = MannWhitneyCornishArb(m, n, LeftTail);
            Console.WriteLine("Result: {0}", Result);
        }



        public static Arb MannWhitneyCornishArb(int m, int n, Arb TargetLeftTail0)
        {
            var kappa = new ArbMat();
            var omega = new ArbMat();
            var mean = new Arb();
            var X = new Arb();
            var sigma = new Arb();
            var z = new Arb();
            var RightTail = new Arb();
            var sumKR = new Arb();
            int Order;
            var nl = default(int);
            var LeftTail = new Arb();
            var TargetLeftTail = new Arb();
            var GuessedQuantile = new Arb();

            ArbPrec.SetDps(40);
            Order = 64; // 128 '96 '64 '32      ' multiple of 4
            kappa.Resize(Order + 1, 1);
            MannWhitneyCumArb(m, n, Order, kappa, ref nl);  // MannWhitney  
            Console.WriteLine("nl: {0}", nl);

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                // Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
                if (i > 0)
                    kappa[i] = kappa[i] - d * aflint.bernoulli(i) / i;
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }


            mean = kappa[1];
            sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);

            GuessedQuantile = GuessQuantileArb(TargetLeftTail0, kappa);
            Console.WriteLine("1: GuessedQuantile: {0}", GuessedQuantile);

            TargetLeftTail = TargetLeftTail0 / 1000;
            do
            {
                TargetLeftTail = TargetLeftTail * 1000;
                Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

                X = DistXArb.ndisxArb(TargetLeftTail, 1 - TargetLeftTail);
                var XAdj = CFArb(6, X, kappa);
                Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj);
                GuessedQuantile = mean + sigma * XAdj;

                Console.WriteLine("2: GuessedQuantile: {0}", GuessedQuantile);
            }
            // Loop While X.IsNan
            while (aflint.isnan(X));


            TargetLeftTail = TargetLeftTail0 / 1000;
            var fx2 = new Arb();
            do
            {
                TargetLeftTail = TargetLeftTail * 1000;
                Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

                // z = (X - mean) / sigma
                // Console.WriteLine( "z: {0}", z)
                // 
                // LeftTail = NdisArb(z)
                // RightTail = 1-LeftTail
                // Console.WriteLine( "Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

                X = DistXArb.ndisxArb(TargetLeftTail, 1 - TargetLeftTail);
                var XAdj = CFArb(Order - 2, X, kappa);
                Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj);
                fx2 = mean + sigma * XAdj;
                Console.WriteLine("X: {0}, XAdj: {1}", X, XAdj);
            }
            // Loop While fx2.IsNan
            while (aflint.isnan(fx2));


            // Dim xd As Int32 = fx2.ToInt32
            int xd = aflint.lrint(fx2);
            if (xd % 2 != 0)
            {
                xd = xd - 1;
            }
            X = aflint.t(xd);
            if (Math.Abs(xd) > nl)
                X = aflint.t(nl);
            Console.WriteLine("X: {0}", X);
            var KR = new ArbMat();
            KR = MannWhitneyCalcArb(m, n);
            i = 0;
            var CDF_KR = new Arb[nl + 1 + 1];
            for (int Index = -nl; Index <= 0; Index += 2)
            {
                sumKR = sumKR + KR[i];
                CDF_KR[i] = sumKR;
                if (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(20))
                    Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR[i]);
                i = i + 1;
            }

            return fx2;
        }





        public static void TerpstaCornishDemoArb()
        {
            int k = 3;
            var n = new int[k + 1];
            for (int j = 1, loopTo = k; j <= loopTo; j++)
                n[j] = 15;
            var LeftTail = new Arb();
            var Result = new Arb();
            LeftTail = aflint.t(0.01d);
            Result = TerpstaCornishArb(k, n, LeftTail);
            Console.WriteLine("Result: {0}", Result);
        }



        public static Arb TerpstaCornishArb(int m, int[] n, Arb TargetLeftTail0)
        {
            var kappa = new ArbMat();
            var omega = new ArbMat();
            var mean = new Arb();
            var X = new Arb();
            var sigma = new Arb();
            var z = new Arb();
            var RightTail = new Arb();
            var sumKR = new Arb();
            int Order;
            var nl = default(int);
            var LeftTail = new Arb();
            var TargetLeftTail = new Arb();
            var GuessedQuantile = new Arb();

            ArbPrec.SetDps(60);
            Order = 64; // 128 '96 '64 '32      ' multiple of 4
            kappa.Resize(Order + 1, 1);
            TerpstaCumArb(m, n, Order, kappa, ref nl);  // Terpsta  
            Console.WriteLine("nl: {0}", nl);

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                // Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
                if (i > 0)
                    kappa[i] = kappa[i] - d * aflint.bernoulli(i) / i;
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }


            mean = kappa[1];
            sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);

            GuessedQuantile = GuessQuantileArb(TargetLeftTail0, kappa);
            Console.WriteLine("1: GuessedQuantile: {0}", GuessedQuantile);

            TargetLeftTail = TargetLeftTail0 / 1000;
            do
            {
                TargetLeftTail = TargetLeftTail * 1000;
                Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

                X = DistXArb.ndisxArb(TargetLeftTail, 1 - TargetLeftTail);
                var XAdj = CFArb(6, X, kappa);
                Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj);
                GuessedQuantile = mean + sigma * XAdj;

                Console.WriteLine("2: GuessedQuantile: {0}", GuessedQuantile);
            }
            // Loop While X.IsNan
            while (aflint.isnan(X));


            TargetLeftTail = TargetLeftTail0 / 1000;
            var fx2 = new Arb();
            do
            {
                TargetLeftTail = TargetLeftTail * 1000;
                Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

                // z = (X - mean) / sigma
                // Console.WriteLine( "z: {0}", z)
                // 
                // LeftTail = NdisArb(z)
                // RightTail = 1-LeftTail
                // Console.WriteLine( "Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

                X = DistXArb.ndisxArb(TargetLeftTail, 1 - TargetLeftTail);
                var XAdj = CFArb(Order - 2, X, kappa);
                Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj);
                fx2 = mean + sigma * XAdj;
                Console.WriteLine("X: {0}, XAdj: {1}", X, XAdj);
            }
            // Loop While fx2.IsNan
            while (aflint.isnan(fx2));


            // Dim xd As Int32 = fx2.ToInt32
            int xd = aflint.lrint(fx2);
            if (xd % 2 != 0)
            {
                xd = xd - 1;
            }
            X = aflint.t(xd);
            if (Math.Abs(xd) > nl)
                X = aflint.t(nl);
            Console.WriteLine("X: {0}", X);
            var KR = new ArbMat();
            KR = TerpstaCalcArb(m, n);
            i = 0;
            var CDF_KR = new Arb[nl + 1 + 1];
            for (int Index = -nl; Index <= 0; Index += 2)
            {
                sumKR = sumKR + KR[i];
                CDF_KR[i] = sumKR;
                if (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(20))
                    Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR[i]);
                i = i + 1;
            }

            return fx2;
        }





        public static void PageCornishDemoArb()
        {
            int k = 6;
            int n = 40;

            var LeftTail = new Arb();
            var Result = new Arb();
            LeftTail = aflint.t(0.00001d);
            Result = PageCornishArb(k, n, LeftTail);
            Console.WriteLine("Result: {0}", Result);
        }



        public static Arb PageCornishArb(int m, int n, Arb TargetLeftTail0)
        {
            var kappa = new ArbMat();
            var omega = new ArbMat();
            var mean = new Arb();
            var X = new Arb();
            var sigma = new Arb();
            var z = new Arb();
            var RightTail = new Arb();
            var sumKR = new Arb();
            int Order;
            var nl = default(int);
            var LeftTail = new Arb();
            var TargetLeftTail = new Arb();
            var GuessedQuantile = new Arb();

            ArbPrec.SetDps(240);
            Order = 64; // 128 '96 '64 '32      ' multiple of 4
            kappa.Resize(Order + 1, 1);
            PageCumArb(m, n, Order, kappa, ref nl);  // Page  
            Console.WriteLine("nl: {0}", nl);

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                // Console.WriteLine("i: {0}, kappa(i): {1}, Bn0(i): {2}", i, kappa(i), d*aflint.bernoulli(i)/i)
                if (i > 0)
                    kappa[i] = kappa[i] - d * aflint.bernoulli(i) / i;
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }


            mean = kappa[1];
            sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);

            GuessedQuantile = GuessQuantileArb(TargetLeftTail0, kappa);
            Console.WriteLine("1: GuessedQuantile: {0}", GuessedQuantile);

            TargetLeftTail = TargetLeftTail0 / 1000;
            do
            {
                TargetLeftTail = TargetLeftTail * 1000;
                Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

                X = DistXArb.ndisxArb(TargetLeftTail, 1 - TargetLeftTail);
                var XAdj = CFArb(6, X, kappa);
                Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj);
                GuessedQuantile = mean + sigma * XAdj;

                Console.WriteLine("2: GuessedQuantile: {0}", GuessedQuantile);
            }
            // Loop While X.IsNan
            while (aflint.isnan(X));


            TargetLeftTail = TargetLeftTail0 / 1000;
            var fx2 = new Arb();
            do
            {
                TargetLeftTail = TargetLeftTail * 1000;
                Console.WriteLine("TargetLeftTail: {0}", TargetLeftTail);

                // z = (X - mean) / sigma
                // Console.WriteLine( "z: {0}", z)
                // 
                // LeftTail = NdisArb(z)
                // RightTail = 1-LeftTail
                // Console.WriteLine( "Edgeworth LeftTail {0}, RightTail: {1}", LeftTail, RightTail)

                X = DistXArb.ndisxArb(TargetLeftTail, 1 - TargetLeftTail);
                var XAdj = CFArb(Order - 2, X, kappa);
                Console.WriteLine("-1 + mean + sigma * XAdj: {0}", -1 + mean + sigma * XAdj);
                fx2 = mean + sigma * XAdj;
                Console.WriteLine("X: {0}, XAdj: {1}", X, XAdj);
            }
            // Loop While fx2.IsNan
            while (aflint.isnan(fx2));


            // Dim xd As Int32 = fx2.ToInt32
            int xd = aflint.lrint(fx2);
            if (xd % 2 != 0)
            {
                xd = xd - 1;
            }
            X = aflint.t(xd);
            if (Math.Abs(xd) > nl)
                X = aflint.t(nl);
            Console.WriteLine("X: {0}", X);
            var KR = new ArbMat();
            int argOrder = 0;
            KR = PageCalcArb(m, n, ref argOrder);
            i = 0;
            var CDF_KR = new Arb[nl + 1 + 1];
            for (int Index = -nl; Index <= 0; Index += 2)
            {
                sumKR = sumKR + KR[i];
                CDF_KR[i] = sumKR;
                if (aflint.abs(aflint.abs(X) - aflint.abs(Index)) < aflint.t(20))
                    Console.WriteLine("Index: {0}, CDF_KR(i): {1}", Index, CDF_KR[i]);
                i = i + 1;
            }

            return fx2;
        }



        // ********************************************************************************************************************************************
        // ********************************************************************************************************************************************
        // ********************************************************************************************************************************************



        private static void perm2Arb(ArbMat pprob, int[] X, int n, int m, ref int panz, ref bool success)
        {
            var ic = new int[1025];
            var ir = new int[1025];
            var ira = new int[1025];
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
            var pcum = new Arb();
            var ai = new Arb();
            var msum = new Arb();
            var asum = new Arb();
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

            // Dim a(ASize) As Double

            var a = new ArbMat();
            a.Resize(ASize + 1, 1);

            var loopTo2 = icm;
            for (i = 1; i <= loopTo2; i++)
                a[i] = aflint.t(0);
            a[1] = aflint.t(1);
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

            asum = aflint.t(1);
            msum = aflint.t(1);
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
            pcum = aflint.t(0);
            panz = qmax - qmin;

            // ReDim pprob(panz)

            // Dim a As New ArbMat()
            pprob.Resize(panz + 1, 1);

            var loopTo11 = qmax - qmin + 1;
            for (i = 1; i <= loopTo11; i++)
            {
                i1 = i - 1;
                ai = a[i];
                pprob[i1] = ai;
                pcum = pcum + ai;
            }
            success = true;
        }






        public static ArbMat TerpstaCalcArb(int k, int[] n)
        {

            var panz = default(int);
            int[] X;
            int TS;
            int j;
            int i4;
            int i2;
            var success = default(bool);
            var qanz = default(int);
            int i; // , t As Integer, success As Boolean

            var pneu = new ArbMat();
            var qprob = new ArbMat();
            var pprob = new ArbMat();

            var m = new int[k + 1 + 1];
            m[0] = 0;
            var loopTo = k;
            for (j = 1; j <= loopTo; j++)
                m[j] = m[j - 1] + n[j];
            TS = 0;
            var loopTo1 = k - 1;
            for (j = 1; j <= loopTo1; j++)
                TS = TS + m[j] * n[j + 1];

            pneu.Resize(TS + 3, 1); // ReDim pneu(TS + 2)
            X = new int[m[k] + 2 + 1];

            var loopTo2 = m[k];
            for (i = 1; i <= loopTo2; i++)
                X[i] = i;

            // t = 0
            perm2Arb(pprob, X, m[2], m[1], ref panz, ref success);
            var loopTo3 = k;
            for (j = 3; j <= loopTo3; j++)
            {
                perm2Arb(qprob, X, m[j], m[j - 1], ref qanz, ref success);
                var loopTo4 = qanz + panz;
                for (i = 0; i <= loopTo4; i++)
                    pneu[i] = aflint.t(0);
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

                // If j = 3 Then ReDim pprob(TS + 2)
                if (j == 3)
                    pprob.Resize(TS + 3, 1);

                var loopTo7 = panz;
                for (i = 0; i <= loopTo7; i++)
                    pprob[i] = pneu[i];
            }
            // ReDim Preserve pprob(panz)
            // pprob.conservative_resize(panz + 1, 1)
            pprob.ConservativeResize(panz + 1, 1);
            success = true;
            return pprob;
        }



        public static ArbMat MannWhitneyCalcArb(int m, int n)
        {
            var NN = new int[3];
            NN[1] = m;
            NN[2] = n;
            return TerpstaCalcArb(2, NN);
        }

        public static ArbMat MannWhitneyCalcArb2(int m, int n)
        {
            var panz = default(int);
            var success = default(bool);
            int[] X;
            X = new int[m + n + 2 + 1];
            for (int i = 1, loopTo = m + n; i <= loopTo; i++)
                X[i] = i;
            var pprob = new ArbMat();
            perm2Arb(pprob, X, m + n, n, ref panz, ref success);
            return pprob;
        }




        public static ArbMat KendallCalcArb(int n)
        {
            int nl; // , y() As Double , X() As Double
            int nmax;
            int it;
            int mitte;
            int limit;
            int j;
            int i;
            var yy = new Arb();
            var permanz = new Arb(); // , SD As Double, p As Double
            nmax = n * (n - 1) + 1;


            var X = new ArbMat();
            X.Resize(nmax + 3, 1);

            var y = new ArbMat();
            y.Resize(nmax + 3, 1);

            // Dim X(nmax + 2) As Double
            // Dim y(nmax + 2) As Double
            // SD = Math.Sqrt(2 * (2 * n + 5) / (9 * n * (n - 1)))
            permanz = aflint.t(1);
            X[1] = permanz;
            nl = 1;
            var loopTo = n;
            for (it = 2; it <= loopTo; it++)
            {
                // Console.WriteLine("it: {0}", it)
                permanz = permanz * it;
                nl = nl + it - 1;
                // p = 0
                mitte = (nl + 1) / 2;
                var loopTo1 = nl;
                for (i = 1; i <= loopTo1; i++)
                    y[i] = aflint.t(0);
                for (i = mitte; i >= 1; i -= 1)
                {
                    // Console.WriteLine("i: {0}", i)
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
            permanz = aflint.t(1);
            var loopTo4 = n;
            for (i = 2; i <= loopTo4; i++)
                permanz = permanz * i;
            var loopTo5 = nl;
            for (i = 1; i <= loopTo5; i++)
                X[i - 1] = X[i] / permanz;
            nl = nl - 1;
            // X.conservative_resize(nl + 1, 1)
            X.ConservativeResize(nl + 1, 1);
            // ReDim Preserve X(nl)
            return X;
        }





        public static void SpearmanCalcArb(int n, int Order, ref int Valcount, ArbMat xx)
        {
            int[] X;
            int[] y;
            int[] p;
            int[] d;
            int[] result;
            int i;
            int nn;
            int count;
            int sum;
            int k;
            int Q;
            int Upper;
            int lower;
            int t;

            var fraction = new Arb();
            bool First;

            if (n <= 0)
                return;

            X = new int[n + 1];
            y = new int[n + 1];
            p = new int[n + 1];
            d = new int[n + 1];

            nn = n;
            First = true;
            count = 0;
            Upper = 0;
            lower = 0;
            var loopTo = nn;
            for (i = 1; i <= loopTo; i++)
            {
                X[i] = i;
                y[i] = i;
            }

            // If Order > 0 Then
            // Select Case n
            // Case 3:  Select Case Order '3 groups
            // Case 1:                    ' linear: no change
            // Case 2:  X(1) = 0: X(2) = 1: X(3) = 1 'quadratic
            // End Select
            // Case 4: Select Case Order '4 groups
            // Case 1:                   ' linear: no change
            // Case 2:  X(1) = 0: X(2) = 0: X(3) = 1: X(4) = 1 ' quadratic
            // Case 3:                   'cubic: no Change
            // End Select
            // Case 5: Select Case Order '5 groups
            // Case 1:                   ' linear: no change
            // Case 2:  X(1) = 0: X(2) = 1: X(3) = 1: X(4) = 4: X(5) = 4 ' quadratic
            // Case 3:                   ' cubic: no change
            // Case 4:  X(1) = 0: X(2) = 0: X(3) = 1: X(4) = 1: X(5) = 2 ' quartic
            // End Select
            // End Select
            // End If

            var loopTo1 = nn;
            for (i = 1; i <= loopTo1; i++)
            {
                Upper = Upper + X[i] * y[i];
                lower = lower + X[i] * y[nn + 1 - i];
            }
            Valcount = Upper - lower;

            // aflint.mat_resize(result, Valcount + 1, 1) ' ReDim result(Valcount)

            result = new int[Valcount + 1];
            var loopTo2 = Valcount;
            for (i = 0; i <= loopTo2; i++)
                result[i] = 0;
            // Debug.Print "Lower:", Lower, "Upper:", Upper, "ValCount:", Valcount

            do
            {
                n = nn;
                if (First)
                {
                    var loopTo3 = n;
                    for (k = 2; k <= loopTo3; k++)
                    {
                        p[k] = 0;
                        d[k] = 1;
                    }
                    First = false;
                }
                k = 0;
            index1:
                ;

                Q = p[n] + d[n];
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
                ;

                if (n > 2)
                {
                    n = n - 1;
                    goto index1;
                }
                Q = 1;
                First = true;
            transpose1:
                ;

                Q = Q + k;
                t = X[Q];
                X[Q] = X[Q + 1];
                X[Q + 1] = t;
                count = count + 1;
                sum = 0;
                var loopTo4 = nn;
                for (i = 1; i <= loopTo4; i++)
                    sum = sum + X[i] * y[i];
                result[sum - lower] = result[sum - lower] + 1;
            }
            while (First != true);

            // Debug.Print "Anzahl der Permutationen:", count

            xx.Resize(Valcount + 1, 1); // ReDim xx(Valcount)
            var loopTo5 = Valcount;
            for (i = 0; i <= loopTo5; i++)
            {
                fraction = aflint.t(result[i]) / aflint.t(count);
                Console.WriteLine(" i: {0}, fraction: {1}", i, fraction);
                xx[i] = fraction;
            }

        }




        public static ArbMat PageQuadeCalcArb(bool UseRanks, int k, int n, int Order)
        {
            int h;
            var pl = default(int);
            int j;
            int i;
            int F;
            int ql;
            var p = new ArbMat();
            var r = new ArbMat();
            var Q = new ArbMat();
            if (UseRanks)
                F = n * (n + 1) / 2;
            else
                F = n;
            SpearmanCalcArb(k, Order, ref pl, p);

            Q.Resize(pl * F + 1, 1); // ReDim Q(pl * F)
            r.Resize(pl * F + 1, 1); // ReDim r(pl * F)

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
                    r[i] = aflint.t(0);
                }
            }
            return Q;
        }



        // ********************************************************************************************************************************************
        // ********************************************************************************************************************************************
        // ********************************************************************************************************************************************


        public static ArbMat PageCalcArb(int k, int N, ref int Order)
        {
            return PageQuadeCalcArb(false, k, N, Order);
        }



        public static ArbMat PageQuadeCalcArb(int k, int N, ref int Order)
        {
            return PageQuadeCalcArb(true, k, N, Order);
        }


        public static ArbMat WilcoxonCalcArb(int N)
        {
            return PageQuadeCalcArb(true, 2, N, 0);
        }


        public static ArbMat SignCalcArb(int N)
        {
            return PageQuadeCalcArb(false, 2, N, 0);
        }


        public static void DemoPageCalcArb()
        {
            int k, N, Order, nl;
            var x = new ArbMat();
            ArbPrec.SetDps(40);
            k = 5;
            N = 8;
            Order = 0;
            x = PageCalcArb(k, N, ref Order);
            nl = x.rows - 1;
            for (int i = 0, loopTo = nl; i <= loopTo; i++)
                Console.WriteLine("i: {0}, x(i): {1}", i, x[i]);
        }


        public static void DemoQuadePageCalcArb()
        {
            int k, N, Order, nl;
            var x = new ArbMat();
            ArbPrec.SetDps(40);
            k = 3;
            N = 10;
            Order = 0;
            x = PageQuadeCalcArb(k, N, ref Order);
            nl = x.rows - 1;
            for (int i = 0, loopTo = nl; i <= loopTo; i++)
                Console.WriteLine("i: {0}, x(i): {1}", i, x[i]);
        }



        public static void DemoSignCalcArb()
        {
            int N, nl;
            var x = new ArbMat();
            ArbPrec.SetDps(40);
            N = 30;
            x = SignCalcArb(N);
            nl = x.rows - 1;
            for (int i = 0, loopTo = nl; i <= loopTo; i++)
                Console.WriteLine("i: {0}, x(i): {1}", i, x[i]);
        }


        public static void DemoMannWhitneyCalcArb()
        {
            int m, n, nl;
            var x = new ArbMat();
            ArbPrec.SetDps(40);
            m = 30;
            n = 30;
            // x = MannWhitneyCalcArb(m, n)
            x = MannWhitneyCalcArb2(m, n);
            nl = x.rows - 1;
            for (int i = 0, loopTo = nl; i <= loopTo; i++)
                Console.WriteLine("i: {0}, x(i): {1}", i, x[i]);
        }


        public static void DemoMannWhitneyCalcArb2(int xvalue)
        {
            int m, n, nl;
            var x = new ArbMat();
            ArbPrec.SetDps(80);
            m = 60;
            n = 60;
            x = MannWhitneyCalcArb(m, n);
            nl = x.rows - 1;
            var sum = aflint.t("0");
            for (int i = 0, loopTo = nl; i <= loopTo; i++)
            {
                sum = sum + x[i];
                int j = 2 * (i - nl / 2);
                if (Math.Abs(Math.Abs(j) - Math.Abs(xvalue)) < 10)
                {
                    Console.WriteLine("i: {0}, x(i): {1}, sum: {2}", j, x[i], sum);
                }
            }
        }


        public static void DemoTerpstaCalcArb()
        {
            int k, nl;
            // Dim x As New ArbMat()
            ArbPrec.SetDps(25);
            k = 5;
            var n = new int[k + 1];
            for (int j = 1, loopTo = k; j <= loopTo; j++)
                n[j] = 8;
            var x = TerpstaCalcArb(k, n);
            nl = x.rows - 1;
            for (int i = 0, loopTo1 = nl; i <= loopTo1; i++)
                Console.WriteLine("i: {0}, x(i): {1}", i, x[i]);
        }


        public static void DemoKendallCalcArb()
        {
            int N, nl;
            var x = new ArbMat();
            ArbPrec.SetDps(40);
            N = 20;
            x = KendallCalcArb(N);
            nl = x.rows - 1;
            for (int i = 0, loopTo = nl; i <= loopTo; i++)
                Console.WriteLine("i: {0}, x(i): {1}", i, x[i]);
        }




        public static void DemoWilcoxonCalcArb()
        {
            int N, nl;
            var x = new ArbMat();
            ArbPrec.SetDps(40);
            N = 10;
            x = WilcoxonCalcArb(N);
            nl = x.rows - 1;
            for (int i = 0, loopTo = nl; i <= loopTo; i++)
                Console.WriteLine("i: {0}, x(i): {1}", i, x[i]);
        }


        public static void DemoWilcoxonCalcArb2(int xvalue)
        {
            int N, nl;
            var x = new ArbMat();
            ArbPrec.SetDps(40);
            N = 80;
            x = WilcoxonCalcArb(N);
            nl = x.rows - 1;
            var sum = aflint.t("0");
            for (int i = 0, loopTo = nl; i <= loopTo; i++)
            {
                int j = i - N * (N + 1) / 4;
                sum = sum + x[i];
                if (Math.Abs(2 * Math.Abs(j) - Math.Abs(xvalue)) < 10)
                {
                    Console.WriteLine("i: {0}, x(i): {1}, sum: {2}", 2 * j, x[i], sum);
                }
            }
        }


        public static void DemoWilcoxonCalcArb3(int N, int xvalue)
        {
            int nl;
            var x = new ArbMat();
            ArbPrec.SetDps(40);
            // N = 80
            x = WilcoxonCalcArb(N);
            nl = x.rows - 1;
            var sum = aflint.t("0");
            for (int i = 0, loopTo = nl; i <= loopTo; i++)
            {
                int j = i - N * (N + 1) / 4;
                sum = sum + x[i];
                if (Math.Abs(2 * Math.Abs(j) - Math.Abs(xvalue)) < 10)
                {
                    Console.WriteLine("i: {0}, x(i): {1}, sum: {2}", 1 * j, x[i], sum);
                }
            }
        }


        public static void aflint_MannWhitney_Cumulants(int Order, int m, int n, ArbMat kappa)
        {
            var nl = default(int);
            kappa.Resize(Order + 1, 1);
            MannWhitneyCumArb(m, n, Order, kappa, ref nl);  // MannWhitney  
                                                            // Console.WriteLine("nl: {0}", nl)

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                var adj = d * aflint.bernoulli(i) / i;
                if (i == 1 | i % 2 == 0)
                {
                    // Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
                }
                if (i > 0)
                    kappa[i] = (kappa[i] - adj) / Math.Pow(2d, i);
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }


            var mean = kappa[1];
            var sigma = aflint.sqrt(kappa[2]);
            // Console.WriteLine("mean {0}, sigma: {1}", mean, sigma)
        }




        public static void aflint_MannWhitney_Cumulants_Raw(int Order, int m, int n, ArbMat kappa)
        {
            var nl = default(int);
            kappa.Resize(Order + 1, 1);
            MannWhitneyCumArb(m, n, Order, kappa, ref nl);  // MannWhitney  
            Console.WriteLine("nl: {0}", nl);

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                // Dim adj = d * aflint.bernoulli(i) / i
                ////int adj = 0;
                if (i == 1 | i % 2 == 0)
                {
                    // Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
                }
                // If (i > 0) Then kappa(i) = kappa(i) - adj
                if (i > 0)
                    kappa[i] = kappa[i] / Math.Pow(2d, i);
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }


            var mean = kappa[1];
            var sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);
        }


        public static Arb aflint_MannWhitney_CGF_By_Cumulants(int deriv, int Order, Arb s, ArbMat kappa)
        {
            var s1 = aflint.t("1");
            var sum = aflint.t("0");
            if (deriv > 0)
            {
                sum = kappa[deriv];
            }
            var count = default(int);
            var RelErr = aflint.t("1");
            for (int i = 1, loopTo = Order - deriv; i <= loopTo; i++)
            {
                count = count + 1;
                s1 = s1 * s;
                var k = kappa[i + deriv];
                var summand = k * s1 / aflint.gamma(i + 1);
                sum = sum + summand;
                if (i == 1 | (i + deriv) % 2 == 0)
                {
                    // Console.WriteLine("i: {0}, kappa(i): {1}, summand: {2}, sum: {3}", i, k, summand, sum)
                }
                if ((i + deriv) % 2 == 0)
                {
                    RelErr = aflint.abs(summand / sum);
                    // Console.WriteLine("RelErr: {0}", RelErr)
                    if (RelErr < aflint.epsilon())
                        break;
                }
            }
            // Console.WriteLine("count: {0}", count)
            // Console.WriteLine("result1: {0}", sum)
            return sum;
        }


        public static Arb aflint_CGF_Sheppard(int deriv, int MaxOrder, Arb stepsize, Arb s)
        {
            var s1 = aflint.t("1");
            var sum = aflint.t("0");
            var tol = aflint.epsilon();
            MaxOrder = 1000;
            if (deriv > 0)
            {
                sum = aflint.bernoulli(deriv) / deriv;
            }
            var count = default(int);
            var RelErr = aflint.t("1");
            var d = aflint.t("1");
            for (int i = 1, loopTo = MaxOrder - deriv; i <= loopTo; i++)
            {
                count = count + 1;
                d = stepsize * d;
                var k = d * aflint.bernoulli(i + deriv) / (i + deriv);
                s1 = s1 * s;
                var summand = k * s1 / aflint.gamma(i + 1);
                sum = sum + summand;
                if ((i + deriv) % 2 == 0)
                {
                    RelErr = aflint.abs(summand / sum);
                    if (RelErr < tol)
                        break;
                }
            }
            // Console.WriteLine("count: {0}", count)
            return sum;
        }



        public static Arb Murakami2(int m, int n, Arb s)
        {
            Arb Ni = new Arb(), sum = new Arb(), result = new Arb();
            Ni = aflint.t(n);
            sum = aflint.t(0);
            for (int r = 1, loopTo = m; r <= loopTo; r++)
            {
                int r2 = r * r;
                var Nir = Ni + r;
                var a1 = aflint.exp(r * s);
                var a2 = 1 - aflint.exp(r * s);
                a2 = a2 * a2;
                var a3 = 1 - aflint.exp(Nir * s);
                a3 = a3 * a3;
                var b1 = aflint.exp(2 * s * Nir);
                var b2 = aflint.exp(Ni * s);
                var b3 = aflint.exp(s * (Ni + 2 * r));
                var b4 = aflint.exp(s * Nir);

                var f = a1 / (a2 * a3);
                // Dim g = r2 + b1 * r2 - (Nir) ^ 2 * b2 - (Nir) ^ 2 * b3 + 2 * Ni * (Ni + 2 * r) * b4
                var g = r2 + b1 * r2 - Nir * Nir * b2 - Nir * Nir * b3 + 2 * Ni * (Ni + 2 * r) * b4;
                sum = sum + f * g;
            }
            return sum;
        }


        public static Arb Murakami1(int m, int n, Arb s)
        {
            Arb Ni = new Arb(), sum = new Arb(), result = new Arb();
            Ni = aflint.t(n);
            sum = aflint.t(0);
            for (int r = 1, loopTo = m; r <= loopTo; r++)
            {
                var Nir = Ni + r;
                var a1 = aflint.exp(r * s);
                var a2 = 1 - a1;
                var a3 = 1 - aflint.exp(s * Nir);

                var b1 = aflint.exp(Ni * s);
                var b2 = aflint.exp(s * Nir);

                var f = a1 / (a2 * a3);
                var g = Ni * b2 + r - Nir * b1;
                sum = sum + f * g;
            }
            return sum;
        }




        public static Arb Murakami1_new(int m, int n, Arb s)
        {
            Arb Ni = new Arb(), sum = new Arb(), result = new Arb();
            Ni = aflint.t(n);
            sum = aflint.t(0);
            for (int r = 1, loopTo = m; r <= loopTo; r++)
            {
                var b = Ni + r;
                var ebs = aflint.expm1(b * s);
                var sumA = b / ebs;
                // Console.WriteLine("sumA2: {0}", sumA)

                var ers = aflint.expm1(r * s);
                var sumB = (-(b - r) * (ers + 1) + b) / ers;
                // Console.WriteLine("sumB2: {0}", sumB)

                sum = sum + sumA - sumB;
            }
            return sum;
        }



        public static Arb Murakami2_new(int m, int n, Arb s)
        {
            Arb Ni = new Arb(), sum = new Arb(), result = new Arb();
            Ni = aflint.t(n);
            sum = aflint.t(0);
            for (int r = 1, loopTo = m; r <= loopTo; r++)
            {
                var b = Ni + r;
                var a = b * b;
                var ebs = aflint.expm1(b * s);
                var sumA = -a / ebs - a / (ebs * ebs);
                // Console.WriteLine("sumA2: {0}", sumA)

                var ers = aflint.expm1(r * s);
                a = aflint.t(r * r);
                var sumB = -a / ers - a / (ers * ers);
                // Console.WriteLine("sumB2: {0}", sumB)

                sum = sum + sumA - sumB;
            }
            return sum;
        }


        public static Arb Murakami2_deriv(int deriv, int m, int n, Arb s)
        {
            Arb Ni = new Arb(), result = new Arb(), t = new Arb(), a = new Arb(), z = new Arb(), ar = new Arb();
            var coeff = new int[21, 21];
            int rsign = -1;
            int d = deriv - 2;
            var sum = new Arb[3];
            sum[0] = aflint.t("0");
            sum[1] = aflint.t("0");
            coeff[0, 1] = 1;
            coeff[0, 2] = 1;


            Ni = aflint.t(n);
            result = aflint.t(0);
            for (int r = 1, loopTo = m; r <= loopTo; r++)
            {
                var b = Ni + r;
                for (int i = 0; i <= 1; i++)
                {
                    if (i == 0)
                        t = b;
                    else
                        t = aflint.t(r);
                    a = t * t;
                    ar = a * Math.Pow(r, d);
                    z = 1 / aflint.expm1(t * s);
                    var localsum = aflint.t("0");
                    for (int j = 1, loopTo1 = d + 2; j <= loopTo1; j++)
                        // localsum = localsum + coeff(d, j) * z ^ j
                        localsum = localsum + coeff[d, j] * aflint.pow(z, j);
                    sum[i] = rsign * ar * localsum;

                }
                result = result + sum[0] - sum[1];
            }
            return result;
        }


        public static Arb Murakami2_deriv2(int deriv, int m, int n, Arb s)
        {
            Arb Ni = new Arb(), result = new Arb(), t = new Arb(), a = new Arb(), z = new Arb(), ar = new Arb();
            // Dim coeff(20, 20) As Int64
            var coeff = new ArbMat();
            // coeff.setZero(deriv + 3, deriv + 3)
            coeff.Resize(deriv + 3, deriv + 3);
            int rsign = 1;
            int d = deriv - 2;
            var sum = new Arb[3];
            if (deriv % 2 == 0)
                rsign = -1;
            sum[0] = aflint.t("0");
            sum[1] = aflint.t("0");
            coeff[0, 1] = aflint.t(1);
            coeff[0, 2] = aflint.t(1);

            for (int i = 1, loopTo = deriv; i <= loopTo; i++)
            {
                coeff[i, 1] = aflint.t(1);
                for (int j = 2, loopTo1 = deriv + 2; j <= loopTo1; j++)
                    coeff[i, j] = (j - 1) * coeff[i - 1, j - 1] + j * coeff[i - 1, j];
            }

            Ni = aflint.t(n);
            result = aflint.t(0);
            for (int r = 1, loopTo2 = m; r <= loopTo2; r++)
            {
                for (int i = 0; i <= 1; i++)
                {
                    if (i == 0)
                        t = Ni + r;
                    else
                        t = aflint.t(r);
                    z = 1 / aflint.expm1(t * s);
                    var localsum = aflint.t("0");
                    var zj = z;
                    for (int j = 1, loopTo3 = deriv; j <= loopTo3; j++)
                    {
                        localsum = localsum + coeff[d, j] * zj;
                        zj = zj * z;
                        // Console.WriteLine("deriv: {0}, j: {1}, coeff(i, j): {2}", deriv, j, coeff(d, j))
                    }
                    // sum(i) = (t ^ (d + 2)) * localsum
                    sum[i] = aflint.pow(t, d + 2) * localsum;
                }
                result = result + sum[0] - sum[1];
            }
            return rsign * result;
        }



        public static Arb Murakami0(int m, int n, Arb s)
        {
            Arb Ni = new Arb(), sum = new Arb(), result = new Arb();
            Ni = aflint.t(n);
            sum = aflint.t(0);
            for (int r = 1, loopTo = m; r <= loopTo; r++)
            {
                var Nir = Ni + r;
                var a1 = 1 - aflint.exp(s * Nir);
                var a2 = 1 - aflint.exp(r * s);

                var f = a1 / a2;
                var g = r / Nir;
                sum = sum + aflint.log(f * g);
            }
            return sum;
        }


        public static Arb Murakami(int deriv, int m, int n, Arb s)
        {
            Arb Ni = new Arb(), sum = new Arb(), result = new Arb();
            if (deriv == 0)
            {
                result = Murakami0(m, n, s);
                result = result - s * n * m / 2;
                return result;
            }
            if (deriv == 1)
            {
                result = Murakami1(m, n, s);
                result = result - n * m / 2d;
                return result;
            }
            else
            {
                return Murakami2_deriv2(deriv, m, n, s);
            }
        }



        public static void Demo_MannWhitney_CGF_By_Cumulants()
        {
            ArbPrec.SetDps(150);
            var kappa = new ArbMat();
            int Order = 600; // 128 '96 '64 '32      ' multiple of 4
            int m = 60;
            int n = 40;
            int NN = m + n;
            var x = aflint.t("600");
            var stepsize = aflint.t("1");
            Console.WriteLine("m: {0}, n: {1}, x: {2}, nl: {3}", m, n, x, n * m / 2d);
            Console.WriteLine("var: {0}", n * m * (n + m + 1) / 12d);
            // Dim C = aflint.pi() * aflint.sqrt(1 / aflint.t("12"))
            // Console.WriteLine("C: {0}", C)
            // Dim CN = C * aflint.sqrt(NN)
            // Console.WriteLine("CN: {0}", CN)

            aflint_MannWhitney_Cumulants_Raw(Order, m, n, kappa);
            var s = (x - kappa[1]) / kappa[2];
            Console.WriteLine("s: {0}", s);
            Console.WriteLine("Kappa(1): {0}", kappa[1]);
            Console.WriteLine("Kappa(2): {0}", kappa[2]);


            var fx_raw = aflint_MannWhitney_CGF_By_Cumulants(0, Order, s, kappa);
            Console.WriteLine("CGF0 raw : {0}", fx_raw);

            aflint_MannWhitney_Cumulants(Order, m, n, kappa);
            var fx_corr = aflint_MannWhitney_CGF_By_Cumulants(0, Order, s, kappa);
            Console.WriteLine("CGF0 shep: {0}", fx_corr);

            var fx_diff = aflint_CGF_Sheppard(0, Order, stepsize, s);
            Console.WriteLine("CGF0 corr: {0}", fx_raw - fx_diff);
            Console.WriteLine("CGF0 diff: {0}", fx_diff);



            Console.WriteLine("");
            aflint_MannWhitney_Cumulants_Raw(Order, m, n, kappa);
            var fx_raw1 = aflint_MannWhitney_CGF_By_Cumulants(1, Order, s, kappa);
            Console.WriteLine("CGF1 raw : {0}", fx_raw1);

            aflint_MannWhitney_Cumulants(Order, m, n, kappa);
            var fx_corr1 = aflint_MannWhitney_CGF_By_Cumulants(1, Order, s, kappa);
            Console.WriteLine("CGF1 shep: {0}", fx_corr1);

            var fx_diff1 = aflint_CGF_Sheppard(1, Order, stepsize, s);
            Console.WriteLine("CGF1 corr: {0}", fx_raw1 - fx_diff1);
            Console.WriteLine("CGF1 diff: {0}", fx_diff1);



            Console.WriteLine("");
            aflint_MannWhitney_Cumulants_Raw(Order, m, n, kappa);
            var fx_raw2 = aflint_MannWhitney_CGF_By_Cumulants(2, Order, s, kappa);
            Console.WriteLine("CGF2 raw : {0}", fx_raw2);

            aflint_MannWhitney_Cumulants(Order, m, n, kappa);
            var fx_corr2 = aflint_MannWhitney_CGF_By_Cumulants(2, Order, s, kappa);
            Console.WriteLine("CGF2 shep: {0}", fx_corr2);

            var fx_diff2 = aflint_CGF_Sheppard(2, Order, stepsize, s);
            Console.WriteLine("CGF2 corr: {0}", fx_raw2 - fx_diff2);
            Console.WriteLine("CGF2 diff: {0}", fx_diff2);



            Console.WriteLine("");
            aflint_MannWhitney_Cumulants_Raw(Order, m, n, kappa);
            var fx_raw3 = aflint_MannWhitney_CGF_By_Cumulants(3, Order, s, kappa);
            Console.WriteLine("CGF3 raw : {0}", fx_raw3);

            aflint_MannWhitney_Cumulants(Order, m, n, kappa);
            var fx_corr3 = aflint_MannWhitney_CGF_By_Cumulants(3, Order, s, kappa);
            Console.WriteLine("CGF3 shep: {0}", fx_corr3);

            var fx_diff3 = aflint_CGF_Sheppard(3, Order, stepsize, s);
            Console.WriteLine("CGF3 corr: {0}", fx_raw3 - fx_diff3);
            Console.WriteLine("CGF3 diff: {0}", fx_diff3);


        }



        public static void Demo_MannWhitney_CGF()
        {
            ArbPrec.SetDps(50);
            var kappa = new ArbMat();
            int Order = 600; // 128 '96 '64 '32      ' multiple of 4
            int m = 60;
            int n = 40;
            int NN = m + n;
            var x = aflint.t("600");
            var stepsize = aflint.t("1");
            Console.WriteLine("m: {0}, n: {1}, x: {2}, nl: {3}", m, n, x, n * m / 2d);
            Console.WriteLine("var: {0}", n * m * (n + m + 1) / 12d);

            aflint_MannWhitney_Cumulants(Order, m, n, kappa);
            var s = (x - kappa[1]) / kappa[2];
            Console.WriteLine("s: {0}", s);
            Console.WriteLine("Kappa(1): {0}", kappa[1]);
            Console.WriteLine("Kappa(2): {0}", kappa[2]);

            for (int j = 0; j <= 6; j++)
            {
                Console.WriteLine("");
                Console.WriteLine("j: {0}", j);

                var CGF_cum = aflint_MannWhitney_CGF_By_Cumulants(j, Order, s, kappa);
                Console.WriteLine("CGF cum:  {0}", CGF_cum);

                var CGF_raw = Murakami(j, m, n, s);
                var CGF_sheppard = aflint_CGF_Sheppard(j, Order, stepsize, s);
                var CGF = CGF_raw - CGF_sheppard;
                Console.WriteLine("CGF     : {0}", CGF);
                Console.WriteLine("Murakami: {0}", CGF_raw);
                Console.WriteLine("CGF diff: {0}", CGF_sheppard);
            }

        }



        public static Arb aflint_MannWhitney_CGF(int j, int m, int n, Arb s, int Order, Arb stepsize)
        {
            var CGF_raw = Murakami(j, m, n, s);
            var CGF_sheppard = aflint_CGF_Sheppard(j, Order, stepsize, s);
            var CGF = CGF_raw - CGF_sheppard;
            return CGF;
        }


        public static Arb MannWhitney_Get_Saddlepoint(int m, int n, Arb x, int Order, Arb stepsize)
        {
            var s = aflint.t("0.1");
            var RelErr = aflint.t("1");
            var tol = aflint.epsilon() * 100;
            do
            {
                Console.WriteLine("s: {0}", s);
                var fx = x - aflint_MannWhitney_CGF(1, m, n, s, Order, stepsize);
                var dfx = aflint_MannWhitney_CGF(2, m, n, s, Order, stepsize);
                var adj = (fx / dfx).Mid;
                s = (s + adj).Mid;
                RelErr = aflint.abs(adj / s);
                Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr);
            }
            while (RelErr >= tol);
            return s;
        }


        public static Arb MannWhitney_Get_Saddlepoint_By_Cumulants(Arb x, int Order, ArbMat kappa)
        {
            var s = (x - kappa[1]) / kappa[2];
            var RelErr = aflint.t("1");
            do
            {
                // Console.WriteLine("s1: {0}", s)
                //int deriv = 1;
                var fx = x - aflint_MannWhitney_CGF_By_Cumulants(1, Order, s, kappa);
                RelErr = aflint.abs(fx / x);
                // Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr)
                // Console.WriteLine("fx: {0}", fx)
                var dfx = aflint_MannWhitney_CGF_By_Cumulants(2, Order, s, kappa);
                // Console.WriteLine("dfx: {0}", dfx)
                var adj = fx / dfx;
                // Console.WriteLine("adj: {0}", adj)
                s = s + adj;
            }
            while (RelErr >= aflint.epsilon());
            return s;
        }


        public static void Demo_MannWhitney_Saddlepoint_By_Cumulants()
        {
            ArbPrec.SetDps(240);
            var kappa = new ArbMat();

            int Order = 800; // 128 '96 '64 '32      ' multiple of 4
            int m = 60;
            int n = 40;
            int NN = m + n;
            var x = aflint.t("1300");
            x = x / 2;
            var stepsize = aflint.t("1");
            Console.WriteLine("m: {0}, n: {1}, x: {2}, nl: {3}", m, n, x, n * m / 2d);
            Console.WriteLine("var: {0}", n * m * (n + m + 1) / 12d);


            aflint_MannWhitney_Cumulants(Order, m, n, kappa);
            var s = (x - kappa[1]) / kappa[2];
            var RelErr = aflint.t("1");
            do
            {
                // Console.WriteLine("")
                Console.WriteLine("s1: {0}", s);
                //int deriv = 1;
                var fx = x - aflint_MannWhitney_CGF_By_Cumulants(1, Order, s, kappa);
                RelErr = aflint.abs(fx / x);
                Console.WriteLine("fx:        {0}, RelErr: {1}", fx, RelErr);

                var k1 = Murakami1(m, n, s);
                k1 = k1 - n * m / 2d;
                var fx_diff1 = aflint_CGF_Sheppard(1, Order, stepsize, s);
                k1 = x - (k1 - fx_diff1);
                Console.WriteLine("CGF1 corr: {0}", k1);
                // Console.WriteLine("CGF1 diff: {0}", fx_diff1)

                Console.WriteLine("");

                Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr);
                // Console.WriteLine("fx: {0}", fx)
                var dfx = aflint_MannWhitney_CGF_By_Cumulants(2, Order, s, kappa);
                Console.WriteLine("dfx:         {0}", dfx);
                var k2 = Murakami2(m, n, s);
                var fx_diff2 = aflint_CGF_Sheppard(2, Order, stepsize, s);

                Console.WriteLine("Murakami k2: {0}", k2 - fx_diff2);

                Console.WriteLine("");

                // Console.WriteLine("dfx: {0}", dfx)
                var adj = fx / dfx;
                // Console.WriteLine("adj: {0}", adj)
                s = s + adj;
            }
            while (RelErr >= aflint.epsilon());
        }


        public static void Demo_MannWhitney_Saddlepoint_By_CGF()
        {
            ArbPrec.SetDps(240);
            var kappa = new ArbMat();

            int Order = 800; // 128 '96 '64 '32      ' multiple of 4
            int m = 60;
            int n = 40;
            int NN = m + n;
            var x = aflint.t("2400");
            x = x / 2;
            var stepsize = aflint.t("1");
            Console.WriteLine("m: {0}, n: {1}, x: {2}, nl: {3}", m, n, x, n * m / 2d);
            Console.WriteLine("var: {0}", n * m * (n + m + 1) / 12d);


            aflint_MannWhitney_Cumulants(Order, m, n, kappa);
            var s = (x - kappa[1]) / kappa[2];
            var RelErr = aflint.t("1");
            do
            {
                Console.WriteLine("s1: {0}", s);

                var CGF_raw = Murakami(1, m, n, s);
                var CGF_sheppard = aflint_CGF_Sheppard(1, Order, stepsize, s);
                var k1 = x - (CGF_raw - CGF_sheppard);
                Console.WriteLine("k1: {0}", k1);

                CGF_raw = Murakami(2, m, n, s);
                CGF_sheppard = aflint_CGF_Sheppard(2, Order, stepsize, s);
                var k2 = CGF_raw - CGF_sheppard;
                Console.WriteLine("k2: {0}", k2);

                var fx = k1;
                var dfx = k2;
                RelErr = aflint.abs(fx / x);
                Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr);
                // Console.WriteLine("dfx: {0}", dfx)
                var adj = fx / dfx;
                // Console.WriteLine("adj: {0}", adj)
                s = s + adj;
                Console.WriteLine("");
            }

            // Loop Until (RelErr < aflint_get_tol())
            while (RelErr >= aflint.t("1E-40"));
        }



        public static void Demo_MannWhitney_CDF_SPA_By_Cumulants()
        {
            ArbPrec.SetDps(140);
            var kappa = new ArbMat();
            int Order = 100; // 128 '96 '64 '32      ' multiple of 4
            int m = 60;
            int n = 40;
            int NN = m + n;
            var x = aflint.t("1180");
            x = x / 2;
            var stepsize = aflint.t("1");
            Console.WriteLine("m: {0}, n: {1}, x: {2}, nl: {3}", m, n, x, n * m / 2d);
            Console.WriteLine("var: {0}", n * m * (n + m + 1) / 12d);


            Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n - 1) / 2d);

            aflint_MannWhitney_Cumulants(Order, m, n, kappa);
            var s = MannWhitney_Get_Saddlepoint_By_Cumulants(x, Order, kappa);
            Console.WriteLine("s: {0}", s);

            int K_Order = 12;
            var K = new Arb[K_Order + 1 + 1];
            for (int j = 0, loopTo = K_Order; j <= loopTo; j++)
            {
                K[j] = aflint_MannWhitney_CGF_By_Cumulants(j, Order, s, kappa);
                Console.WriteLine("j: {0}, K(s): {1}", j, K[j]);
            }

            Console.WriteLine("");
            Arb density = new Arb(), LeftTail = new Arb(), Righttail = new Arb();
            DistNArb.aflint_LugannaniRiceNew(K_Order, K, s, ref density, ref LeftTail, ref Righttail);

        }


        public static void Demo_MannWhitney_CDF_SPA()
        {
            ArbPrec.SetDps(50);
            int m = 30;
            int n = 30;
            int NN = m + n;
            // Dim x = aflint.t("3528")
            var x = aflint.t("228");
            x = x / 2;
            Console.WriteLine("x: {0}", x);
            var stepsize = aflint.t("1");
            Console.WriteLine("m: {0}, n: {1}, x: {2}, nl: {3}", m, n, 2 * x, n * m / 2d);
            Console.WriteLine("var: {0}", n * m * (n + m + 1) / 12d);

            var s = MannWhitney_Get_Saddlepoint(m, n, x, 1000, stepsize);
            Console.WriteLine("s: {0}", s);

            int K_Order = 24;
            var K = new Arb[K_Order + 1 + 1];
            for (int j = 0, loopTo = K_Order; j <= loopTo; j++)
            {
                K[j] = aflint_MannWhitney_CGF(j, m, n, s, 1000, stepsize);
                Console.WriteLine("j: {0}, K(s): {1}", j, K[j]);
            }

            Console.WriteLine("");
            Arb density = new Arb(), LeftTail = new Arb(), Righttail = new Arb();
            DistNArb.aflint_LugannaniRiceNew(K_Order, K, s, ref density, ref LeftTail, ref Righttail);

            // DemoMannWhitneyCalcArb2(2 * x.ToInt32)

        }






        public static void aflint_Wilcoxon_Cumulants_Raw(int Order, int n, ArbMat kappa)
        {
            var nl = default(int);
            kappa.Resize(Order + 1, 1);
            WilcoxonCumArb(n, Order, kappa, ref nl);  // Kendall  
            Console.WriteLine("nl: {0}", nl);

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                // Dim adj = d * aflint.bernoulli(i) / i
                //int adj = 0;
                if (i == 1 | i % 2 == 0)
                {
                    // Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
                }
                // If (i > 0) Then kappa(i) = kappa(i) - adj
                if (i > -1)
                    kappa[i] = kappa[i] / Math.Pow(2d, i);
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }


            var mean = kappa[1];
            var sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);
        }


        public static Arb Bennett0(int n, Arb s)
        {
            var sum = aflint.t("0");
            for (int h = 1, loopTo = n; h <= loopTo; h++)
                sum = sum + aflint.log(aflint.cosh(0.5d * h * s));
            // Return sum
            return 0.25d * n * (n + 1) * s + sum;
        }


        public static Arb Bennett1a(int n, Arb s)
        {
            var sum = aflint.t("0");
            for (int h = 1, loopTo = n; h <= loopTo; h++)
                sum = sum + aflint.tanh(0.5d * h * s) * 0.5d * h;
            return sum;
        }


        public static Arb Bennett1(int n, Arb s)
        {
            var sum = aflint.t("0");
            for (int h = 1, loopTo = n; h <= loopTo; h++)
                sum = sum + (1 - 2 / (aflint.exp(h * s) + 1)) * 0.5d * h;
            return sum;
        }


        public static Arb Bennett2(int n, Arb s)
        {
            var sum = aflint.t("0");
            for (int h = 1, loopTo = n + 0; h <= loopTo; h++)
            {
                var z = 1 / (aflint.exp(h * s) + 1);
                sum = sum + h * h * (z - z * z);
            }
            return sum;
        }


        public static Arb Bennett3(int n, Arb s)
        {
            var sum = aflint.t("0");
            for (int h = 1, loopTo = n + 0; h <= loopTo; h++)
            {
                var z = 1 / (aflint.exp(h * s) + 1);
                sum = sum + h * h * h * (-z + 3 * z * z - 2 * z * z * z);
            }
            return sum;
        }


        public static Arb Bennett4(int n, Arb s)
        {
            var sum = aflint.t("0");
            for (int h = 1, loopTo = n + 0; h <= loopTo; h++)
            {
                var z = 1 / (aflint.exp(h * s) + 1);
                sum = sum + h * h * h * h * (z - 7 * z * z + 12 * z * z * z - 6 * z * z * z * z);
            }
            return sum;
        }



        public static Arb Bennet_deriv(int deriv, int n, Arb s)
        {
            Arb result = new Arb(), z = new Arb();
            // Dim coeff(deriv + 2, deriv + 2) As Int64
            var coeff = new ArbMat();
            // coeff.setZero(deriv + 3, deriv + 3)
            coeff.Resize(deriv + 3, deriv + 3);
            int d = deriv - 2;
            Arb sum;
            // sum = aflint.t("0")
            coeff[0, 1] = aflint.t(1);
            coeff[0, 2] = aflint.t(1);

            for (int i = 1, loopTo = deriv; i <= loopTo; i++)
            {
                coeff[i, 1] = aflint.t(1);
                for (int j = 2, loopTo1 = deriv + 2; j <= loopTo1; j++)
                    coeff[i, j] = (j - 1) * coeff[i - 1, j - 1] + j * coeff[i - 1, j];
            }

            int loopsign = -1;
            for (int i = 0, loopTo2 = deriv; i <= loopTo2; i++)
            {
                loopsign = -loopsign;
                int loopsign2 = loopsign;
                for (int j = 1, loopTo3 = deriv + 2; j <= loopTo3; j++)
                {
                    coeff[i, j] = loopsign2 * coeff[i, j];
                    // Console.WriteLine("i: {0}, j: {1}, coeff(i, j): {2}", i, j, coeff(i, j))
                    loopsign2 = -loopsign2;
                }
                // Console.WriteLine()
            }

            result = aflint.t(0);
            for (int h = 1, loopTo4 = n; h <= loopTo4; h++)
            {
                z = 1 / (aflint.exp(h * s) + 1);
                var localsum = aflint.t("0");
                var zj = z;
                for (int j = 1, loopTo5 = deriv; j <= loopTo5; j++)
                {
                    localsum = localsum + coeff[d, j] * zj;
                    zj = zj * z;
                    // Console.WriteLine("deriv: {0}, j: {1}, coeff(i, j): {2}", deriv, j, coeff(d, j))
                }
                sum = Math.Pow(h, d + 2) * localsum;
                result = result + sum;
            }
            return result;
        }



        public static Arb Bennett(int deriv, int n, Arb s)
        {
            Arb Ni = new Arb(), sum = new Arb(), result = new Arb();
            if (deriv == 0)
            {
                result = Bennett0(n, s);
                return result;
            }
            if (deriv == 1)
            {
                result = Bennett1(n, s);
                return result;
            }
            if (deriv == 2)
            {
                result = Bennett2(n, s);
                return result;
            }
            else
            {
                return Bennet_deriv(deriv, n, s);
            }
        }



        public static Arb aflint_Wilcoxon_CGF(int j, int n, Arb s, Arb stepsize)
        {
            var CGF_raw = Bennett(j, n, s);
            var CGF_sheppard = aflint_CGF_Sheppard(j, 1000, stepsize, s);
            var CGF = CGF_raw - CGF_sheppard;
            return CGF;
        }



        public static void Demo_Wilcoxon_CGF_By_Cumulants()
        {
            ArbPrec.SetDps(60);
            var kappa = new ArbMat();
            int Order = 464; // 128 '96 '64 '32      ' multiple of 4
            int n = 8;
            var x = aflint.t("622");
            Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n + 1) / 4d);

            // aflint_Kendall_Cumulants(Order, n, kappa)
            aflint_Wilcoxon_Cumulants_Raw(Order, n, kappa);
            var s = (x - kappa[1]) / kappa[2];
            s = aflint.t(0.01d);
            Console.WriteLine("s: {0}", s);
            Console.WriteLine("Kappa(1): {0}", kappa[1]);
            Console.WriteLine("Kappa(2): {0}", kappa[2]);


            for (int j = 0; j <= 12; j++)
            {
                Console.WriteLine();
                Console.WriteLine("j: {0}", j);
                var fx_cum = aflint_Wilcoxon_CGF_By_Cumulants(j, Order, s, kappa);
                Console.WriteLine("fx_cum: {0}", fx_cum);
                var fx_ben = Bennett(j, n, s);
                Console.WriteLine("fx_ben: {0}", fx_ben);
                Console.WriteLine("ratio: {0}", fx_cum / fx_ben);

            }

        }



        public static Arb aflint_Wilcoxon_CGF_By_Cumulants(int deriv, int Order, Arb s, ArbMat kappa)
        {
            var s1 = aflint.t("1");
            var sum = aflint.t("0");
            if (deriv > 0)
            {
                sum = kappa[deriv];
            }
            var count = default(int);
            var RelErr = aflint.t("1");
            for (int i = 1, loopTo = Order - deriv; i <= loopTo; i++)
            {
                count = count + 1;
                s1 = s1 * s;
                var k = kappa[i + deriv];
                var summand = k * s1 / aflint.gamma(i + 1);
                sum = sum + summand;
                if (i == 1 | (i + deriv) % 2 == 0)
                {
                    // Console.WriteLine("i: {0}, kappa(i): {1}, summand: {2}, sum: {3}", i, k, summand, sum)
                }
                if ((i + deriv) % 2 == 0)
                {
                    RelErr = aflint.abs(summand / sum);
                    // Console.WriteLine("RelErr: {0}", RelErr)
                    if (RelErr < aflint.epsilon())
                        break;
                }
            }
            // Console.WriteLine("count: {0}", count)
            // Console.WriteLine("result1: {0}", sum)
            return sum;
        }


        // NOTE: limited RelErr
        public static Arb Wilcoxon_Get_Saddlepoint_By_Cumulants(Arb x, int Order, ArbMat kappa)
        {
            var s = (x - kappa[1]) / kappa[2];
            var RelErr = aflint.t("1");
            do
            {
                // Console.WriteLine("s1: {0}", s)
                //int deriv = 1;
                var fx = x - aflint_Wilcoxon_CGF_By_Cumulants(1, Order, s, kappa);
                RelErr = aflint.abs(fx / x);
                // Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr)
                // Console.WriteLine("fx: {0}", fx)
                var dfx = aflint_Wilcoxon_CGF_By_Cumulants(2, Order, s, kappa);
                // Console.WriteLine("dfx: {0}", dfx)
                var adj = fx / dfx;
                // Console.WriteLine("adj: {0}", adj)
                s = s + adj;
                Console.WriteLine("s :{0}", s);
            }
            // Loop Until (RelErr < aflint.epsilon())
            while (RelErr >= aflint.t(0.0000000001d));
            return s;
        }



        public static void aflint_Wilcoxon_Cumulants(int Order, int n, ArbMat kappa)
        {
            var nl = default(int);
            kappa.Resize(Order + 1, 1);
            WilcoxonCumArb(n, Order, kappa, ref nl);  // Kendall  
            Console.WriteLine("nl: {0}", nl);

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                var adj = d * aflint.bernoulli(i) / i;
                if (i == 1 | i % 2 == 0)
                {
                    // Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
                }
                if (i > 0)
                    kappa[i] = kappa[i] - adj;
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }


            var mean = kappa[1];
            var sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);
        }






        public static Arb Wilcoxon_Get_Saddlepoint(int n, Arb x, Arb stepsize)
        {
            var s = aflint.t("0");
            var RelErr = aflint.t("1");
            var tol = aflint.epsilon() * 100;
            aflint.epsilon();
            do
            {
                Console.WriteLine("s: {0}", s);
                var fx = x - aflint_Wilcoxon_CGF(1, n, s, stepsize);
                var dfx = aflint_Wilcoxon_CGF(2, n, s, stepsize);
                var adj = (fx / dfx).Mid;
                s = (s + adj).Mid;
                RelErr = aflint.abs(adj / s);
                Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr);
            }
            while (RelErr >= tol);
            return s;
        }



        public static Arb CoshArb(Arb x)
        {
            // Return 0.5 * (aflint.exp(x) + aflint.exp(-x))
            return 1.0d * (aflint.exp(x) + aflint.exp(-x));

        }

        public static void Demo_Wilcoxon_CDF_SPA()
        {
            ArbPrec.SetDps(40);
            var aflint_get_tol = aflint.epsilon();
            Console.WriteLine("aflint_get_tol: {0}", aflint_get_tol);
            // Dim n = 50
            // Dim x = aflint.t("308")

            int n = 80;
            var x = aflint.t("1240");


            double maxvalue = n * (n + 1) / 4d;
            Console.WriteLine("maxvalue: {0}", maxvalue);
            var stepsize = aflint.t("1");
            Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n + 1) / 2d);

            // Dim s = Wilcoxon_Get_Saddlepoint(n, x, stepsize)
            var s = aflint.t(0.00764263498788246d);

            Console.WriteLine("s: {0}", s);

            int K_Order = 24;
            var K = new Arb[K_Order + 1 + 1];

            // Need to calculate K(0) separately

            var sum = aflint.t("0");

            // For h = 1 To n
            // 'sum = sum + aflint.log(aflint.cosh(0.5 * h * s))

            // Dim temp0 = 0.5 * h * s
            // 'Dim temp1 = aflint.cosh(temp0)
            // Dim temp1 = CoshArb(temp0)
            // Dim temp2 = aflint.log(temp1)
            // sum = sum + temp2
            // Next

            for (int h = 1, loopTo = n; h <= loopTo; h++)
                sum = sum + aflint.log(1 + aflint.exp(h * s));
            sum = sum + aflint.log(1.0d / Math.Pow(2d, n));

            // K(0) = 0.25 * n * (n + 1) * s + sum
            K[0] = sum;
            Console.WriteLine("j: {0}, K(s): {1}", 0, K[0]);

            // For j = 1 To K_Order
            // K(j) = aflint_Wilcoxon_CGF(j, n, s, stepsize)
            // Console.WriteLine("j: {0}, K(s): {1}", j, K(j))
            // Next

            // Console.WriteLine("")
            // Dim density, LeftTail, Righttail As New Arb
            // aflint_LugannaniRiceNew(K_Order, K, s, density, LeftTail, Righttail)

            // DemoWilcoxonCalcArb3(n, 2 * x.ToInt32)
        }



        public static void Demo_Wilcoxon_CDF_SPA_By_Cumulants()
        {
            // ArbPrec.SetDps(240)
            ArbPrec.SetDps(100);
            var kappa = new ArbMat();
            int Order = 864; // 128 '96 '64 '32      ' multiple of 4
            int n = 80;
            var x = aflint.t("1240");

            Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n - 1) / 2d);

            aflint_Wilcoxon_Cumulants(Order, n, kappa);
            var s = Wilcoxon_Get_Saddlepoint_By_Cumulants(x, Order, kappa);
            Console.WriteLine("s: {0}", s);

            int K_Order = 18;
            var K = new Arb[K_Order + 1 + 1];
            for (int j = 0, loopTo = K_Order; j <= loopTo; j++)
            {
                K[j] = aflint_Wilcoxon_CGF_By_Cumulants(j, Order, s, kappa);
                Console.WriteLine("j: {0}, K(s): {1}", j, K[j]);
            }

            Console.WriteLine("");
            Arb density = new Arb(), LeftTail = new Arb(), Righttail = new Arb();
            DistNArb.aflint_LugannaniRiceNew(K_Order, K, s, ref density, ref LeftTail, ref Righttail);

            // DemoWilcoxonCalcArb2(x.ToInt32)
            DemoWilcoxonCalcArb2(aflint.lrint(x));
        }






        public static void aflint_Kendall_Cumulants_Raw(int Order, int n, ArbMat kappa)
        {
            var nl = default(int);
            kappa.Resize(Order + 1, 1);
            KendallCumArb(n, Order, kappa, ref nl);  // Kendall  
            Console.WriteLine("nl: {0}", nl);

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                // Dim adj = d * aflint.bernoulli(i) / i
                ////int adj = 0;
                if (i == 1 | i % 2 == 0)
                {
                    // Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
                }
                // If (i > 0) Then kappa(i) = kappa(i) - adj
                if (i > 0)
                    kappa[i] = kappa[i] / Math.Pow(2d, 0d);
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }


            var mean = kappa[1];
            var sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);
        }




        public static Arb Kendall_Get_Saddlepoint_By_Cumulants(Arb x, int Order, ArbMat kappa)
        {
            var s = (x - kappa[1]) / kappa[2];
            var RelErr = aflint.t("1");
            do
            {
                // Console.WriteLine("s1: {0}", s)
                //int deriv = 1;
                var fx = x - aflint_Kendall_CGF_By_Cumulants(1, Order, s, kappa);
                RelErr = aflint.abs(fx / x);
                // Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr)
                // Console.WriteLine("fx: {0}", fx)
                var dfx = aflint_Kendall_CGF_By_Cumulants(2, Order, s, kappa);
                // Console.WriteLine("dfx: {0}", dfx)
                var adj = fx / dfx;
                // Console.WriteLine("adj: {0}", adj)
                s = s + adj;
            }
            while (RelErr >= aflint.epsilon());
            return s;
        }





        public static Arb aflint_Kendall_CGF_By_Cumulants(int deriv, int Order, Arb s, ArbMat kappa)
        {
            var s1 = aflint.t("1");
            var sum = aflint.t("0");
            if (deriv > 0)
            {
                sum = kappa[deriv];
            }
            var count = default(int);
            var RelErr = aflint.t("1");
            for (int i = 1, loopTo = Order - deriv; i <= loopTo; i++)
            {
                count = count + 1;
                s1 = s1 * s;
                var k = kappa[i + deriv];
                var summand = k * s1 / aflint.gamma(i + 1);
                sum = sum + summand;
                if (i == 1 | (i + deriv) % 2 == 0)
                {
                    // Console.WriteLine("i: {0}, kappa(i): {1}, summand: {2}, sum: {3}", i, k, summand, sum)
                }
                if ((i + deriv) % 2 == 0)
                {
                    RelErr = aflint.abs(summand / sum);
                    // Console.WriteLine("RelErr: {0}", RelErr)
                    if (RelErr < aflint.epsilon())
                        break;
                }
            }
            // Console.WriteLine("count: {0}", count)
            // Console.WriteLine("result1: {0}", sum)
            return sum;
        }



        public static void Demo_Kendall_Saddlepoint_By_Cumulants()
        {
            ArbPrec.SetDps(140);
            var kappa = new ArbMat();
            int Order = 464; // 128 '96 '64 '32      ' multiple of 4
            int n = 80;
            var x = aflint.t("1578");

            aflint_Kendall_Cumulants(Order, n, kappa);
            var s = (x - kappa[1]) / kappa[2];
            var RelErr = aflint.t("1");
            do
            {
                // Console.WriteLine("")
                Console.WriteLine("s1: {0}", s);
                //int deriv = 1;
                var fx = x - aflint_Kendall_CGF_By_Cumulants(1, Order, s, kappa);
                RelErr = aflint.abs(fx / x);
                Console.WriteLine("fx: {0}, RelErr: {1}", fx, RelErr);
                // Console.WriteLine("fx: {0}", fx)
                var dfx = aflint_Kendall_CGF_By_Cumulants(2, Order, s, kappa);
                // Console.WriteLine("dfx: {0}", dfx)
                var adj = fx / dfx;
                // Console.WriteLine("adj: {0}", adj)
                s = s + adj;
            }
            while (RelErr >= aflint.epsilon());
        }



        public static void aflint_Kendall_Cumulants(int Order, int n, ArbMat kappa)
        {
            var nl = default(int);
            kappa.Resize(Order + 1, 1);
            KendallCumArb(n, Order, kappa, ref nl);  // Kendall  
            Console.WriteLine("nl: {0}", nl);

            int i = 0;
            var d = aflint.t(1);
            var loopTo = Order;
            for (i = 1; i <= loopTo; i++)
            {
                d = 2 * d;
                var adj = d * aflint.bernoulli(i) / i;
                if (i == 1 | i % 2 == 0)
                {
                    // Console.WriteLine("i: {0}, kappa(i): {1}, adj: {2}, adj/kappa: {3}", i, kappa(i), adj, adj / kappa(i))
                }
                if (i > 0)
                    kappa[i] = kappa[i] - adj;
                // Console.WriteLine("i: {0}, kappa(i): {1}", i, kappa(i))
            }


            var mean = kappa[1];
            var sigma = aflint.sqrt(kappa[2]);
            Console.WriteLine("mean {0}, sigma: {1}", mean, sigma);
        }




        public static void Demo_Kendall_CDF_SPA()
        {
            ArbPrec.SetDps(40);
            var kappa = new ArbMat();
            int Order = 864; // 128 '96 '64 '32      ' multiple of 4
            int n = 80;
            var x = aflint.t("1278");
            // Dim x = aflint.t("1606")
            // Dim x = aflint.t("40")

            Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n - 1) / 2d);

            aflint_Kendall_Cumulants(Order, n, kappa);
            var s = Kendall_Get_Saddlepoint_By_Cumulants(x, Order, kappa);
            Console.WriteLine("s: {0}", s);

            int K_Order = 18;
            var K = new Arb[K_Order + 1 + 1];
            for (int j = 0, loopTo = K_Order; j <= loopTo; j++)
            {
                K[j] = aflint_Kendall_CGF_By_Cumulants(j, Order, s, kappa);
                Console.WriteLine("j: {0}, K(s): {1}", j, K[j]);
            }

            Console.WriteLine("");
            Arb density = new Arb(), LeftTail = new Arb(), Righttail = new Arb();
            DistNArb.aflint_LugannaniRiceNew(K_Order, K, s, ref density, ref LeftTail, ref Righttail);

        }



        public static void Demo_Kendall_CGF_By_Cumulants()
        {
            ArbPrec.SetDps(240);
            var kappa = new ArbMat();
            int Order = 464; // 128 '96 '64 '32      ' multiple of 4
            int n = 80;
            var x = aflint.t("622");
            Console.WriteLine("n: {0}, x: {1}, nl: {2}", n, x, n * (n - 1) / 2d);

            // aflint_Kendall_Cumulants(Order, n, kappa)
            aflint_Kendall_Cumulants_Raw(Order, n, kappa);
            var s = (x - kappa[1]) / kappa[2];
            s = aflint.t(0.01d);
            var limit = aflint.pi() / n;
            Console.WriteLine("limit: {0}", limit);
            Console.WriteLine("s: {0}", s);
            Console.WriteLine("Kappa(1): {0}", kappa[1]);
            Console.WriteLine("Kappa(2): {0}", kappa[2]);

            var RelErr = aflint.t("1");

            // Dim k1 = aflint_Kendall_CGF_By_Cumulants(1, Order, 0, kappa)
            // Console.WriteLine("k1: {0}", k1)

            var fx_new = aflint_Kendall_CGF_By_Cumulants(0, Order, s, kappa);
            Console.WriteLine("fx1: {0}", fx_new);


        }






    }
}