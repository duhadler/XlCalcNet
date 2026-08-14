using System;
using ArbPrecNet;

namespace Distributions
{


    static class Module1
    {

        public delegate Arb aflintFunction(Arb x);

        public delegate ArbC apcFunction(ArbC x);


        // wolfram alpha: integrate sin(exp(x))/sqrt(x) from 0 to 2 = 1.50572...
        public static void Calc_Integration(Arb a, Arb b, Arb epsabsStart, Arb alpha, Arb beta)
        {
            Console.WriteLine("Test_Integration");

            var pi = aflint.pi();
            var p2 = pi / 2;
            var zero = aflint.t(0);
            var one = aflint.t(1);

            var hmin = zero;
            var C1Final = zero;
            var epsabsFinal = zero;
            string ds = "", radX = "", radY = "";
            var nmin = aflint.t("1E1000000000000");

            var mu = beta;
            var nu = alpha;
            if (alpha < beta)
            {
                mu = alpha;
                nu = beta;
            }
            var ab1 = alpha + beta - 1;

            // Determine optimal h and n
            for (int d1 = 1; d1 <= 26; d1++)
            {
                GetRectAndK(d1, ref radX, ref radY, ref ds);
                var d = aflint.t(ds);
                // Console.WriteLine("radX: {0:f}, radY: {1:f}, d: {2:f}", radX, radY, d)
                var radX_ = aflint.t(radX);
                var radY_ = aflint.t(radY);
                var K = GetAcbK(a.Mid, b.Mid, radX_, radY_);


                // Dim C1 = (1 / mu) * 2 * K * (b - a) ^ ab1
                var C1 = 1 / mu * 2 * K * (b - a);
                // 'If (ab1 <> one) Then C1 = C1 ^ ab1
                if (ab1 != one)
                    C1 = aflint.pow(C1, ab1);
                var epsabs = epsabsStart / C1;
                // Dim C2 = 2 / ((aflint.cos(p2 * aflint.sin(d))) ^ (alpha + beta) * aflint.cos(d))
                var C2 = 2 / (aflint.pow(aflint.cos(p2 * aflint.sin(d)), alpha + beta) * aflint.cos(d));
                // Console.WriteLine("C1: {0}", C1)
                // Console.WriteLine("C2: {0}", C2)
                // Console.WriteLine("epsabs: {0}", epsabs)
                var h = 2 * pi * d / aflint.log(1 + 2 * C2 / epsabs);
                var n = 1 / h * aflint.log(2 / (pi * mu) * aflint.log(2 * aflint.exp(p2 * nu) / epsabs));

                if (n < nmin)
                {
                    nmin = n;
                    hmin = h;
                    C1Final = C1;
                    epsabsFinal = epsabs;
                }
                Console.WriteLine("h: {0}, n: {1:f}", h.Mid, n.Mid);
                // Console.WriteLine()
                // Console.WriteLine()
                // Console.WriteLine("hmin: {0}, nmin: {1:f}", hmin,nmin)
            }

            Console.WriteLine("Final epsabs {0}: ", epsabsFinal);
            Console.WriteLine("Final C1 {0:f}: ", C1Final);
            // Determine NN and MM if alpha <> beta
            Console.WriteLine("hmin: {0}, nmin: {1:f}", hmin, nmin);
            // Dim MM = aflint.ceil(nmin).ToInt32 : Dim NN = MM
            int MM = aflint.lrint(aflint.ceil(nmin));
            int NN = MM;
            Console.WriteLine("n0: {0}", NN);
            if (mu == alpha)
            {
                // NN = NN - (aflint.floor(aflint.log(beta / alpha) / hmin)).ToInt32
                NN = NN - aflint.lrint(aflint.floor(aflint.log(beta / alpha) / hmin));
            }
            else
            {
                MM = MM - aflint.lrint(aflint.floor(aflint.log(alpha / beta) / hmin));
            }
            Console.WriteLine("NN: {0}", NN);
            Console.WriteLine("MM: {0}", MM);


            // Perform actual integration
            var sum = aflint.t(0);
            // c = p2 * ((b-a)/2) ^ (alpha+beta-1) 
            var b1 = (b - a) / 2;
            var b2 = (b + a) / 2;
            // Dim c = p2 * (b1) ^ ab1
            var c = p2 * aflint.pow(b1, ab1);

            for (int kk = -MM, loopTo = NN; kk <= loopTo; kk++)
            {
                var u = hmin * kk;
                var eu1 = aflint.exp(u);
                var eu2 = 1 / eu1;
                var su = (eu1 - eu2) * 0.5d;
                var cu = (eu1 + eu2) * 0.5d;
                var x1 = p2 * su;
                var e1 = aflint.exp(x1);
                var e2 = 1 / e1;
                var e3 = 1 / (e1 + e2);
                var f = (e1 - e2) * e3;
                var fp1 = 2 * e1 * e3;
                var fm1 = 2 * e2 * e3;
                // PHI2 = c * aflint.cosh(u) * (aflint.abs(1+f))^alpha * (aflint.abs(1-f))^beta
                // If alpha <> 1 Then fp1 = fp1 ^ alpha
                if (alpha != 1)
                    fp1 = aflint.pow(fp1, alpha);
                // If beta <> 1 Then fm1 = fm1 ^ beta
                if (beta != 1)
                    fm1 = aflint.pow(fm1, beta);
                var PHI2 = c * cu * fp1 * fm1;
                var t = f * b1 + b2;
                sum = sum + g(t) * PHI2;
            }
            var res = hmin * sum;
            Console.WriteLine("ED+ET: {0}", C1Final * epsabsFinal);
            Console.WriteLine("Int1: {0}", res);
            Console.WriteLine("Int2: {0} = aflint.sqrt(2*p2)/2)", aflint.sqrt(2 * p2) / 2);

        }





        public static Arb GetAcbK(Arb a, Arb b, Arb radX, Arb radY)
        {
            var ba2 = (b - a) / 2;
            var x_re = aflint.t(0);
            x_re.Mid = (b + a) / 2;
            x_re.Rad = ba2 * radX;
            var x_im = aflint.t(0);
            x_im.Mid = aflint.t(0);
            x_im.Rad = ba2 * radY;
            // Dim x = aflintc.t(0)
            var x = aflintc.t(x_re, x_im);
            // x.real = x_re
            // x.imag = x_im
            var z = cplx_g(x);
            var av = aflintc.abs(z);
            Console.WriteLine("Infimum: {0}", av.Infimum());
            Console.WriteLine("Supremum: {0}", av.Supremum());
            return av.Supremum();
        }








        public static void GetRectAndK(int d1, ref string radX, ref string radY, ref string ds)
        {
            switch (d1)
            {
                case 1:
                    {
                        radX = "165.2";
                        radY = "254.3";
                        ds = "1.5";
                        break;
                    }
                case 2:
                    {
                        radX = "28.375";
                        radY = "43.75";
                        ds = "1.4";
                        break;
                    }
                case 3:
                    {
                        radX = "11.3";
                        radY = "17.46";
                        ds = "1.3";
                        break;
                    }
                case 4:
                    {
                        radX = "6.06";
                        radY = "9.34";
                        ds = "1.2";
                        break;
                    }
                case 5:
                    {
                        radX = "3.8";
                        radY = "5.795";
                        ds = "1.1";
                        break;
                    }
                case 6:
                    {
                        radX = "2.633";
                        radY = "3.933";
                        ds = "1.0";
                        break;
                    }
                case 7:
                    {
                        radX = "1.968";
                        radY = "2.826";
                        ds = "0.9";
                        break;
                    }
                case 8:
                    {
                        radX = "1.566";
                        radY = "2.103";
                        ds = "0.8";
                        break;
                    }
                case 9:
                    {
                        radX = "1.312";
                        radY = "1.5994";
                        ds = "0.7";
                        break;
                    }
                case 10:
                    {
                        radX = "1.1552";
                        radY = "1.2276";
                        ds = "0.6";
                        break;
                    }
                case 11:
                    {
                        radX = "1.065";
                        radY = "0.937";
                        ds = "0.5";
                        break;
                    }
                case 12:
                    {
                        radX = "1.0197";
                        radY = "0.702";
                        ds = "0.4";
                        break;
                    }
                case 13:
                    {
                        radX = "1.0032";
                        radY = "0.5008";
                        ds = "0.3";
                        break;
                    }
                case 14:
                    {
                        radX = "1.001";
                        radY = "0.41";
                        ds = "0.25";
                        break;
                    }
                case 15:
                    {
                        radX = "1.001";
                        radY = "0.3228";
                        ds = "0.2";
                        break;
                    }
                case 16:
                    {
                        radX = "1.001";
                        radY = "0.199";
                        ds = "0.125";
                        break;
                    }
                case 17:
                    {
                        radX = "1.001";
                        radY = "0.1584";
                        ds = "0.1";
                        break;
                    }
                case 18:
                    {
                        radX = "1.001";
                        radY = "0.1423";
                        ds = "0.09";
                        break;
                    }
                case 19:
                    {
                        radX = "1.001";
                        radY = "0.1263";
                        ds = "0.08";
                        break;
                    }
                case 20:
                    {
                        radX = "1.001";
                        radY = "0.11037";
                        ds = "0.07";
                        break;
                    }
                case 21:
                    {
                        radX = "1.001";
                        radY = "0.09456";
                        ds = "0.06";
                        break;
                    }
                case 22:
                    {
                        radX = "1.001";
                        radY = "0.0787";
                        ds = "0.05";
                        break;
                    }
                case 23:
                    {
                        radX = "1.001";
                        radY = "0.06296";
                        ds = "0.04";
                        break;
                    }
                case 24:
                    {
                        radX = "1.001";
                        radY = "0.0472";
                        ds = "0.03";
                        break;
                    }
                case 25:
                    {
                        radX = "1.001";
                        radY = "0.03145";
                        ds = "0.02";
                        break;
                    }
                case 26:
                    {
                        radX = "1.0";
                        radY = "0.01572";
                        ds = "0.01";
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Error");
                        break;
                    }
            }


        }



        public static Arb g(Arb t)
        {
            // Dim res = aflint.sin(aflint.exp(t))
            var res = aflint.exp(-t * t);
            // res = 1/((1-t*t)*(1-t*t) + t*t)
            // y = 1/(1+t*t)
            // res = -(1/(1+y*y)) * 1/(y*y)
            return res;
        }


        public static ArbC cplx_g(ArbC t)
        {
            // Dim res = aflintc.sin(aflintc.exp(t))
            var res = aflintc.exp(-t * t);
            return res;
        }


        public static void Test_Integration()
        {
            ArbPrec.SetDps(40);
            var a = aflint.t("0.0");
            var b = aflint.t("10.0");
            var alpha = aflint.t("1.0");
            var beta = aflint.t("1.0");
            // a = 5.0 : b = 10.0 : alpha = 1.0 : beta = 1.0
            // a = 0.0 : b = 1.0 : alpha = 0.5 : beta = 1.0
            // epsabsStart = "1.0E-2"
            var epsabsStart = aflint.t("1.0E-35");
            Calc_Integration(a, b, epsabsStart, alpha, beta);
        }





        public static void DE_Int_Main()
        {
            Test_Integration();
        }

    }
}