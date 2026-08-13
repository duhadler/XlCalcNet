using System;
using ArbPrecNet;

namespace Distributions
{



    static class DistRoy
    {


        public static double TW1(double x)
        {
            double k = 46.446d;
            double t = 0.186054d;
            double a = 9.84801d;
            var P1 = aflint.gamma_p(k, (x + a) / t);
            return P1.AsDouble();
        }

        public static void DemoTW1()
        {
            Console.WriteLine("Result: {0}", TW1(3.24d));
        }


        // Function IBeta(x As Double, a As Double, b As Double) As Double
        // Dim LeftTail As Double, Righttail As Double, density As Double
        // Call betadis(a, b, x, 1 - x, LeftTail, Righttail, density)
        // IBeta = LeftTail * boost.beta(a, b)
        // Dim resarb = aflint.beta_lower(a, b, x)
        // End Function

        public static double beta_lower(double a, double b, double x)
        {
            var LeftTail = default(double);
            var Righttail = default(double);
            var density = default(double);
            DistMain.betadis(a, b, x, 1d - x, ref LeftTail, ref Righttail, ref density);
            var res = LeftTail * aflint.beta(a, b);
            // Dim res2 As Double = aflint.beta_lower(a, b, x)
            // Dim resarb = aflint.beta_lower(a, b, x)
            // Console.WriteLine("res: {0}, res2: {1}, resarb: {2}", res, res2, resarb)
            return res.AsDouble();
        }


        // Chiani 2017, Algorithm 1
        public static double Roy_Chiani(double x, int s, double m, double n)
        {
            int d = s + s % 2;
            double k = n + 1d;
            var b = aflint.mat_zeros(s, 1);
            var t = aflint.mat_zeros(s, 1);
            var A = aflint.mat_zeros(d, d);

            for (int i = 0, loopTo = s - 1; i <= loopTo; i++)
            {
                t[i] = aflint.t(beta_lower(m + i + 1d, k, x));
                if (s != d)
                {
                    A[i, s] = t[i];
                    A[s, i] = -A[i, s];
                }
            }

            if (s != 1)
            {
                for (int i = 0, loopTo1 = s - 1; i <= loopTo1; i++)
                {
                    b[i] = 0.5d * t[i] * t[i];
                    for (int j = i + 1, loopTo2 = s - 1; j <= loopTo2; j++)
                    {
                        b[j] = ((m + j) * b[j - 1] - beta_lower(2d * m + i + j + 1d, 2d * k, x)) / (m + j + k);
                        A[i, j] = t[i] * t[j] - 2 * b[j];
                        A[j, i] = -A[i, j];
                    }
                }
            }

            var det = A.Det()[0, 0];


            Console.WriteLine("Det: {0}, Det: {1}", det, Math.Log(det.AsDouble()));



            // Dim res1 = A.colPivHouseholderQr2("logabsdet", A)
            var res1 = A.ColPivHouseholderQR("logabsdet", A);
            Console.WriteLine("logabsdet1: {0}", res1["logabsdet"][0, 0]);

            var res2 = A.FullPivHouseholderQR("logabsdet", A);
            Console.WriteLine("logabsdet2: {0}", res2["logabsdet"][0, 0]);


            var res3 = A.COD("logabsdet", A);
            Console.WriteLine("logabsdet3: {0}", res3["logabsdet"][0, 0]);


            var sqrtdet = aflint.sqrt(det);
            return sqrtdet.AsDouble();
        }


        // Chiani 2017, Algorithm 1
        public static ArbMat aflint_Roy_A(Arb x, int s, Arb m, Arb n)
        {
            int d = s + s % 2;
            var k = n + 1;
            // Dim b = aflint.mat_zeros(s, 1)
            var b = aflint.mat_zeros(s, 1);
            var t = aflint.mat_zeros(s, 1);
            var A = aflint.mat_zeros(d, d);
            int m2 = aflint.lrint(2 * m);
            var xinv = 1 / x;

            var b1 = k;
            // Dim z = (1 - x) ^ b1
            var z = aflint.pow(1 - x, b1);
            // Dim xa1 = z * x ^ (m + s)
            var xa1 = aflint.pow(z * x, m + s);
            t[s - 1] = aflint.beta_lower(m + s, b1, x);
            for (int i = s - 2; i >= 0; i -= 1)
            {
                var a1 = m + i + 1;
                xa1 = xa1 * xinv;
                t[i] = ((a1 + b1) * t[i + 1] + xa1) / a1;
                if (s != d)
                {
                    A[i, s] = t[i];
                    A[s, i] = -A[i, s];
                }
            }


            if (s != 1)
            {
                int amin = m2 + 2;
                int amax = m2 + 2 * (s - 1);
                var t4 = aflint.mat_zeros(amax - amin + 1, 1);
                // Console.WriteLine("amin: {0}", amin)
                // Console.WriteLine("amax: {0}", amax)

                b1 = 2 * k;
                z = aflint.pow(1 - x, b1);
                xa1 = aflint.pow(z * x, amax);
                t4[amax - amin] = aflint.beta_lower(amax, b1, x);
                for (int a1 = amax - 1, loopTo = amin; a1 >= loopTo; a1 -= 1)
                {
                    xa1 = xa1 * xinv;
                    t4[a1 - amin] = ((a1 + b1) * t4[a1 + 1 - amin] + xa1) / a1;
                }


                for (int i = 0, loopTo1 = s - 1; i <= loopTo1; i++)
                {
                    b[i] = 0.5d * t[i] * t[i];
                    for (int j = i + 1, loopTo2 = s - 1; j <= loopTo2; j++)
                    {
                        int a1 = m2 + i + j + 1;
                        var t6 = t4[a1 - amin];
                        b[j] = ((m + j) * b[j - 1] - t6) / (m + j + k);
                        A[i, j] = t[i] * t[j] - 2 * b[j];
                        A[j, i] = -A[i, j];
                    }
                }
            }

            return A;
        }

        public static Arb Trace(ArbMat A)
        {
            var sum = aflint.t(0);
            for (int i = 0, loopTo = A.rows - 1; i <= loopTo; i++)
                sum = sum + A[i, i];
            return sum;
        }


        // Chiani 2017, Algorithm 1
        public static Arb aflint_Roy_Chiani(Arb x, int s, Arb m, Arb n, ref Arb pdf_factor)
        {

            var eps = aflint.t("10E-20");
            var A = aflint_Roy_A(x, s, m, n);
            // Dim A1 = aflint_Roy_A(x + eps, s, m, n)
            // Dim A2 = aflint_Roy_A(x - eps, s, m, n)
            // Dim ADiff = (A1 - A2) / (2 * eps)

            Console.WriteLine("start det");

            // Dim res0 = A.fullPivLu2("det, x", ADiff)
            var res0 = A.FullPivLU("det, x", A);
            var det = res0["det"][0, 0];
            var Xmat = res0["x"];
            var tr = Trace(Xmat);
            Console.WriteLine("tr(Xmat): {0}", tr);
            pdf_factor = 0.5d * tr;

            Console.WriteLine("mat_fullPivLu2 det: {0}, Log(Det): {1}", det, aflint.log(det));

            var sqrtdet = aflint.sqrt(det);
            Console.WriteLine("sqrtdet: {0}", sqrtdet);
            return sqrtdet;
        }


        // Chiani 2017, Algorithm 1
        public static Arb aflint_Roy_Chiani2(Arb x, int s, Arb m, Arb n)
        {
            int d = s + s % 2;
            var k = n + 1;
            var b = aflint.mat_zeros(s, 1);
            var t = aflint.mat_zeros(s, 1);
            var A = aflint.mat_zeros(d, d);
            int m2 = aflint.lrint(2 * m);
            var xinv = 1 / x;

            var b1 = k;
            var z = aflint.pow(1 - x, b1);
            var xa1 = aflint.pow(z * x, m + s);
            t[s - 1] = aflint.beta_lower(m + s, b1, x);
            for (int i = s - 2; i >= 0; i -= 1)
            {
                var a1 = m + i + 1;
                xa1 = xa1 * xinv;
                t[i] = ((a1 + b1) * t[i + 1] + xa1) / a1;
                if (s != d)
                {
                    A[i, s] = t[i];
                    A[s, i] = -A[i, s];
                }
            }


            if (s != 1)
            {
                int amin = m2 + 2;
                int amax = m2 + 2 * (s - 1);
                var t4 = aflint.mat_zeros(amax - amin + 1, 1);
                Console.WriteLine("amin: {0}", amin);
                Console.WriteLine("amax: {0}", amax);

                b1 = 2 * k;
                z = aflint.pow(1 - x, b1);
                xa1 = aflint.pow(z * x, amax);
                t4[amax - amin] = aflint.beta_lower(amax, b1, x);
                for (int a1 = amax - 1, loopTo = amin; a1 >= loopTo; a1 -= 1)
                {
                    xa1 = xa1 * xinv;
                    t4[a1 - amin] = ((a1 + b1) * t4[a1 + 1 - amin] + xa1) / a1;
                }


                for (int i = 0, loopTo1 = s - 1; i <= loopTo1; i++)
                {
                    b[i] = 0.5d * t[i] * t[i];
                    for (int j = i + 1, loopTo2 = s - 1; j <= loopTo2; j++)
                    {
                        int a1 = m2 + i + j + 1;
                        var t6 = t4[a1 - amin];
                        b[j] = ((m + j) * b[j - 1] - t6) / (m + j + k);
                        A[i, j] = t[i] * t[j] - 2 * b[j];
                        A[j, i] = -A[i, j];
                    }
                }
            }

            A.Print("Matrix A:", 15);

            Console.WriteLine("start det");

            var res0 = A.FullPivLU("det", A);
            var det = res0["det"][0, 0];
            Console.WriteLine("mat_fullPivLu2 det: {0}, Log(Det): {1}", det, aflint.log(det));

            var sqrtdet = aflint.sqrt(det);
            Console.WriteLine("sqrtdet: {0}", sqrtdet);
            return sqrtdet;
        }


        public static double Roy_Const(int s, double m, double n)
        {
            double C1 = 0.0d;
            for (int i = 1, loopTo = s; i <= loopTo; i++)
                C1 += aflint.lgamma(0.5d * (i + 2d * m + 2d * n + s + 2d)).AsDouble() - aflint.lgamma(0.5d * i).AsDouble() - aflint.lgamma(0.5d * (i + 2d * m + 1d)).AsDouble() - aflint.lgamma(0.5d * (i + 2d * n + 1d)).AsDouble();


            double C = Math.Pow(Math.PI, 0.5d * s) * Math.Exp(C1);
            Console.WriteLine("C: {0}", C);

            return C;
        }


        public static Arb aflint_Roy_Const(int s, Arb m, Arb n)
        {
            var C1 = aflint.t(0);
            for (int i = 1, loopTo = s; i <= loopTo; i++)
                C1 += aflint.lgamma(0.5d * (i + 2 * m + 2 * n + s + 2)) - aflint.lgamma(0.5d * i) - aflint.lgamma(0.5d * (i + 2 * m + 1)) - aflint.lgamma(0.5d * (i + 2 * n + 1));


            var C = aflint.pow(aflint.pi(), 0.5d * s) * aflint.exp(C1);
            Console.WriteLine("C: {0}", C);

            return C;
        }


        public static double RoyCDF(double x, int p, double n1, double n2)
        {
            double m = 0.5d * (Math.Abs(n1 - p) - 1d);
            double n = 0.5d * (Math.Abs(n2 - p) - 1d);
            return Roy_Const(p, m, n) * Roy_Chiani(x, p, m, n);
        }

        public static Arb aflint_RoyCDF(Arb x, int p, Arb n1, Arb n2)
        {
            var pdf_factor = aflint.t(0);
            var m = 0.5d * (aflint.abs(n1 - p) - 1);
            var n = 0.5d * (aflint.abs(n2 - p) - 1);
            var C = aflint_Roy_Const(p, m, n);
            var SqrtDet = aflint_Roy_Chiani(x, p, m, n, ref pdf_factor);
            Console.WriteLine("pdf_factor: {0}", pdf_factor);
            var pdf = C * SqrtDet * pdf_factor;
            Console.WriteLine("pdf: {0}", pdf);
            return C * SqrtDet;
        }


        public static Mpfr mreal_RoyCDF(Mpfr x, int p, Mpfr n1, Mpfr n2)
        {
            var result = aflint_RoyCDF(aflint.t(x), p, aflint.t(n1), aflint.t(n2));
            return mreal.t(result);
        }



        public static double RoyCDFApprox(double t1, double p, double n1, double n2)
        {
            double k = 46.446d;
            double delta = 0.186054d;
            double alpha = 9.84801d;

            double phi = Math.Acos((n2 - n1) / (n2 + n1 - 1d));
            double g = Math.Acos((n2 + n1 - 2d * p) / (n2 + n1 - 1d));
            double s3 = 16d / (Math.Pow(n2 + n1 - 1d, 2d) * Math.Pow(Math.Sin(g + phi), 2d) * Math.Sin(g) * Math.Sin(phi));

            double mu = 2d * Math.Log(Math.Tan((g + phi) / 2d));
            double sigma = Math.Pow(s3, 1d / 3d);
            double x = (Math.Log(t1 / (1d - t1)) - mu + sigma * alpha) / (delta * sigma);
            var P1 = aflint.gamma_p(k, x);
            return P1.AsDouble();
        }



        public static double RoyQuantileApprox(double LeftTail, double p, double n1, double n2)
        {
            double k = 46.446d;
            double delta = 0.186054d;
            double alpha = 9.84801d;

            double phi = Math.Acos((n2 - n1) / (n2 + n1 - 1d));
            double g = Math.Acos((n2 + n1 - 2d * p) / (n2 + n1 - 1d));
            double s3 = 16d / (Math.Pow(n2 + n1 - 1d, 2d) * Math.Pow(Math.Sin(g + phi), 2d) * Math.Sin(g) * Math.Sin(phi));

            double mu = 2d * Math.Log(Math.Tan((g + phi) / 2d));
            double sigma = Math.Pow(s3, 1d / 3d);
            double P1 = aflint.real_gamma_p_inv(k, LeftTail).AsDouble();
            double num = Math.Exp(sigma * (delta * P1 - alpha) + mu);
            double result = num / (1d + num);
            return result;
        }


        public static void Swap(ref int a, ref int b)
        {
            int Tmp = a;
            a = b;
            b = Tmp;
        }

        public static void RoyDemoAnderson()
        {
            double x1 = 3.512d;
            x1 = 4.692d;
            // Dim x1 = 4.235
            // Dim x1 = 5.938
            // Dim x1 = aflint.t(2.16)

            int p = 2;
            int n1 = 3;
            int n2 = 123;   // 128
            Console.WriteLine("x1 (Anderson): {0}", x1);

            double f = n1 / (double)(n2 + n1);
            double x = x1 * f;
            Console.WriteLine("x: {0}", x);

            if (n1 < p)
            {
                n2 = n2 + n1 - p;
                Swap(ref p, ref n1);
                Console.WriteLine("New p: {0}", p);
                Console.WriteLine("New n1: {0}", n1);
                Console.WriteLine("New n2: {0}", n2);
            }

            // Dim Result0 = RoyCDF(x, p, n1, n2)
            // Console.WriteLine("Result0: {0}", Result0)


            var Result1 = aflint_RoyCDF(aflint.t(x), p, aflint.t(n1), aflint.t(n2));
            Console.WriteLine("Result1: {0}", Result1);

            double Result2 = RoyCDFApprox(x, p, n1, n2);
            Console.WriteLine("Result2: {0}", Result2);

            double x2 = RoyQuantileApprox(Result1.AsDouble(), p, n1, n2);
            Console.WriteLine("x2: {0}", x2);

            // x2 = x2 / f
            // Console.WriteLine("x2 (Anderson): {0}", x2)
        }


        public static void RoyDemo()
        {
            var LeftTail = aflint.t("0.99");

            int p = 2;
            // Dim n1 = 100  ' m = -1/2 implies n1 = p
            // Dim n2 = 88   ' n = 100 implies n2 = 201 + p

            int n1 = 2 * p;  // m = -1/2 implies n1 = p
                             // Dim n2 = 201 + p   ' n = 100 implies n2 = 201 + p
            int n2 = 300 + p;   // n = 100 implies n2 = 201 + p

            // m=-0.5; n=100; p=5, 15, 100 
            // Dim 0 = (n1 - p) 
            // Dim 2*n+1+p = n2


            if (n1 < p)
            {
                n2 = n2 + n1 - p;
                Swap(ref p, ref n1);
                Console.WriteLine("New p: {0}", p);
                Console.WriteLine("New n1: {0}", n1);
                Console.WriteLine("New n2: {0}", n2);
            }

            double x = RoyQuantileApprox(LeftTail.AsDouble(), p, n1, n2);
            Console.WriteLine("x: {0}", x);

            var Result1 = aflint_RoyCDF(aflint.t(x), p, aflint.t(n1), aflint.t(n2));
            Console.WriteLine("Result1: {0}", Result1);

            // Dim eps = aflint.t("1E-20")
            // Dim D1 = aflint_RoyCDF(x + eps, p, n1, n2)
            // Console.WriteLine("Result1: {0}", Result1)
            // Dim D2 = aflint_RoyCDF(x - eps, p, n1, n2)
            // Console.WriteLine("Result1: {0}", Result1)
            // Dim pdf = (D1 - D2) / (2 * eps)
            // Console.WriteLine("pdf: {0}", pdf)

            // Dim Result2 = RoyCDFApprox(x, p, n1, n2)
            // Console.WriteLine("Result2: {0}", Result2)

        }






        public static Mpfr NdisMpfr(Mpfr x)
        {
            var z = new Mpfr();
            z = 0.5d * (1 + mreal.real_erf(x / mreal.sqrt(2)));
            // Console.WriteLine("x: {0}, z: {1}", x, z)
            return z;
        }


        // Function NdensMpfr(x As Mpfr) As Mpfr
        // Dim z As New Mpfr
        // z = mreal.exp(-x * x / 2) / mreal.sqrt(2 * mreal.pi())
        // '        Console.WriteLine("x: {0}, z: {1}", x, z)
        // Return z
        // End Function


        // Sub mprfF1(xPtr As IntPtr, fxPtr As IntPtr)
        // Dim x As New Mpfr(xPtr, True)
        // Dim fx As New Mpfr()
        // fx = NdisMpfr(x) - mreal.t("0.99")
        // Console.WriteLine("In  F1: x: {0}, f(x): {1}", x, fx)
        // fx.CopyToPtr(fxPtr)
        // End Sub


        // Sub DemoMpfrSolverBoost()
        // Dim result As New Mpfr
        // mp4.setprec(300)

        // Dim factor, xmin, xmax, guess, bracket_min, bracket_max As New Mpfr
        // Dim get_digits As Int32 = 49, maxit As UInt32 = 25
        // Dim is_rising As Boolean = True ' Set to true if f(x) is rising on x and false if f(x) is falling on x. This value is used along with the result of f(guess) to determine if guess is above or below the root.
        // guess = 3.33
        // xmin = 0.0
        // xmax = 4.0
        // factor = 1.2
        // get_digits = 150


        // Console.WriteLine("BracketRoot")
        // result = mpfrCallback.BracketRoot(AddressOf mprfF1, guess, factor, is_rising, get_digits, maxit)
        // Console.WriteLine("x: {0}", result)


        // End Sub

        public static Arb f(Arb x)
        {
            var y = 1 / x;
            if (aflint.iszero(x.Mid))
                y = aflint.inf();
            return aflint.exp(-y);
        }

        public static Arb s1(Arb x)
        {
            if (aflint.iszero(x.Mid))
            {
                return aflint.t(0);
            }
            else
            {
                return aflint.exp(-1 / x) / (x * x);
            }
        }

        public static void DemoArbInt()
        {
            Console.WriteLine("In DemoArbInt");
            for (int i = 0; i <= 10; i++)
            {
                double x = i / 100d;
                var y = s1(aflint.t(x));
                Console.WriteLine("i: {0}, y: {1}, f(x) * y: {2}", i, y, f(aflint.t(x)) * y);
            }
        }



    }
}