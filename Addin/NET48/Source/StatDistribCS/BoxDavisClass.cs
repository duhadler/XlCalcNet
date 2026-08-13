using FixedPrecNet;
using System;

namespace NewDistrib
{
    internal class BoxDavisClass
    {
        int k, j, r, rsign;
        double sum1, sum2, f, rho, TargetLeftTail;
        double[] omega;
        double[] kappa;
        double[] kderiv;
        int rmax = 20;
        int kmax = 12;


        public BoxDavisClass() 
        {
            TargetLeftTail = 0.0;
        }


        public void Calc_F_Rho(int a, int b, double[] x, double[] y, double[] xi, double[] eta)
        {

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
        }


        public void CalcOmega(int rmax_, int a, int b, double[] x, double[] y, double[] xi, double[] eta)
        {
            rmax = rmax_;
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
                // Console.WriteLine("r: {0}, omega(r) {1}", r, omega(r))
            }
        }

        public double CalcCDFByOmega(double z)
        {
            //Console.WriteLine("f: {0}, z: {1}, rho: {2}", f, z, rho);
            double LogKB = 0.0d;
            double sumCDF = DistMain.cdis(f, z);
            var a = new double[101];
            a[0] = 1.0d;
            for (int j = 1, loopTo = rmax; j <= loopTo; j++)
            {
                double temp = 0.0d;
                for (int l = 1, loopTo1 = j; l <= loopTo1; l++)
                    temp = temp + l * omega[l] * a[j - l];
                a[j] = temp / j;
                LogKB = LogKB + omega[j];
                double adjCDF = DistMain.cdis(f + 2 * j, z);
                double adjCDF2 = a[j] * adjCDF;
                sumCDF = sumCDF + adjCDF2;
                if (j % 2 == 0)
                {
                    //Console.WriteLine("j: {0}, omega(j): {1}, a(j): {2},  adjCDF: {3}, adjCDF2: {4}", j, omega[j], a[j], adjCDF, adjCDF2);
                }
            }
            double KB = Math.Exp(-LogKB);
            var LeftTail = KB * sumCDF;
            Console.WriteLine("LogKB: {0}, KB: {1}, sumCDF: {2}, LeftTail: {3}, Ret: {4}", LogKB, KB, sumCDF, LeftTail, LeftTail- TargetLeftTail);
            return LeftTail - TargetLeftTail ;
        }

        public double CalcPDFByOmega(double z)
        {
            //Console.WriteLine("f: {0}, z: {1}, rho: {2}", f, z, rho);
            double LogKB = 0.0d;
            double sumPDF = DistMain.cdens(f, z);
            var a = new double[101];
            a[0] = 1.0d;
            for (int j = 1, loopTo = rmax; j <= loopTo; j++)
            {
                double temp = 0.0d;
                for (int l = 1, loopTo1 = j; l <= loopTo1; l++)
                    temp = temp + l * omega[l] * a[j - l];
                a[j] = temp / j;
                LogKB = LogKB + omega[j];
                double adjPDF = DistMain.cdens(f + 2 * j, z);
                double adjPDF2 = a[j] * adjPDF;
                sumPDF = sumPDF + adjPDF2;
                if (j % 2 == 0)
                {
                    //Console.WriteLine("j: {0}, omega(j): {1}, a(j): {2}, adjPDF: {3}, adjPDF2: {4}", j, omega[j], a[j], adjPDF, adjPDF2);
                }
            }
            double KB = Math.Exp(-LogKB);
            //var density = rho * KB * sumPDF;
            var density = KB * sumPDF;
            //Console.WriteLine("LogKB: {0}, KB: {1}, sumPDF: {2}, Density: {3}", LogKB, KB, sumPDF, density);
            return density;
        }


        public double GuessQuantileByOmega(double LeftTail, double RightTail)
        {
            double sum;
            var s = new double[8];
            int i;
            bool show;
            show = true;
            Console.WriteLine("LeftTail: {0}, RightTail: {1}", LeftTail, RightTail);
            double u = DistX.cdisx(LeftTail, RightTail, f);
            // Console.WriteLine("f: {0}", f)
            // Console.WriteLine("rho: {0}", rho)
            double f2 = f * (f + 2d);
            double f3 = f2 * (f + 4d);
            double f4 = f3 * (f + 6d);
            double f5 = f4 * (f + 8d);
            double f6 = f5 * (f + 10d);
            double f7 = f6 * (f + 12d);
            double f12 = f * f;
            double f13 = f12 * f;
            double f22 = f2 * f2;
            double u2 = u * u;
            double u3 = u * u2;
            double u4 = u * u3;
            double u5 = u * u4;
            double u6 = u * u5;
            double u7 = u * u6;
            double S1 = u2 * (3d * f + 4 * 2 - 2d) / (f2 * f2) + u3 * (3d * f + 4 * 3 - 2d) / (f2 * f3) + u4 * (3d * f + 4 * 4 - 2d) / (f2 * f4) + u5 * (3d * f + 4 * 5 - 2d) / (f2 * f5);
            double p1 = u / f;
            double p2 = p1 + u2 / f2;
            double p3 = p2 + u3 / f3;
            double p4 = p3 + u4 / f4;
            double P5 = p4 + u5 / f5;
            double p6 = P5 + u6 / f6;
            double P7 = p6 + u7 / f7;
            double P22 = -8 * u4 * (f + 3d) / (f2 * f4) + 8d * u3 / (f2 * f3) + 6d * u2 / (f * f2) + 2d * u / f12;
            double P32 = -12 * u5 * (f + 4d) / (f2 * f5) - 2d * u4 * (f - 6d) / (f2 * f4) + 2d * u3 * (3d * f + 10d) / (f2 * f3) + 6d * u2 / (f * f2) + 2d * u / f12;
            double P42 = -16 * u6 * (f + 5d) / (f2 * f6) - 4d * u5 * (f - 4d) / (f2 * f5) + 2d * u4 * (3d * f + 14d) / (f2 * f4) + 2d * u3 * (3d * f + 10d) / (f2 * f3) + 6d * u2 / (f * f2) + 2d * u / f12;
            double P33 = -6 * u6 * (3d * f12 + 30d * f + 80d) / (f3 * f6) - 6d * u5 * (f2 + 2d * f - 16d) / (f3 * f5) + 4d * u4 * (f + 12d) / (f2 * f4) + 4d * u3 * (3d * f + 8d) / (f2 * f3) + 6d * u2 / (f * f2) + 2d * u / f12;
            double P222 = 32d * u6 * (7d * f12 + 62d * f + 120d) / (f22 * f6) - 32d * u5 * (2d * f12 + 37d * f + 96d) / (f22 * f5) - 8d * u4 * (23d * f12 + 124d * f + 132d) / (f22 * f4) - 8d * u3 * (f - 10d) / (f * f2 * f3) + 28d * u2 / (f12 * f2) + 4d * u / f13;
            double P52 = -20 * u7 * (f + 6d) / (f2 * f7) - 2d * u6 * (3d * f - 10d) / (f2 * f6) + S1 + 2d * u / f12;
            double P43 = -24 * u7 * (f2 + 12d * f + 40d) / (f3 * f7) - 2d * u6 * (5d * f2 + 18d * f - 80d) / (f3 * f6) + 2d * u5 * (f2 + 42d * f + 176d) / (f3 * f5) + 4d * u4 * (3d * f + 16d) / (f2 * f4) + 4d * u3 * (3d * f + 8d) / (f2 * f3) + 6d * u2 / (f * f2) + 2d * u / f12;
            double P322 = 192d * u7 * (2d * f13 + 31d * f12 + 154d * f + 240d) / (f2 * f3 * f7) - 16d * u6 * (4d * f13 + 153d * f12 + 1106d * f + 2160d) / (f2 * f3 * f6) - 8d * u5 * (35d * f3 + 420d * f12 + 1540d * f + 1632d) / (f2 * f3 * f5) - 4d * u4 * (25d * f12 + 80d * f + 12d) / (f22 * f4) + 4d * u3 * (7d * f + 38d) / (f * f2 * f3) + 28d * u2 / (f12 * f3) + 4d * u / f13;
            s[2] = omega[2] * p2;
            s[3] = omega[3] * p3;
            s[4] = omega[4] * p4 + 0.5d * Math.Pow(omega[2], 2d) * P22;
            s[5] = omega[5] * P5 + omega[3] * omega[2] * P32;
            s[6] = omega[6] * p6 + omega[4] * omega[2] * P42 + 0.5d * Math.Pow(omega[3], 2d) * P33 + omega[2] * omega[2] * omega[2] * P222 / 6d;
            s[7] = omega[7] * P7 + omega[5] * omega[2] * P52 + omega[4] * omega[3] * P43 + 0.5d * omega[3] * Math.Pow(omega[2], 2d) * P322;
            sum = 0d;
            if (show)
                Console.WriteLine("cdisx(f): {0}", u);
            for (i = 2; i <= 7; i++)
            {
                sum = sum + s[i];
                if (show)
                    Console.WriteLine("i: {0}, sum: {1}, s(i): {2}", i, sum, s[i]);
            }
            double x = u + 2d * sum;
            Console.WriteLine("resultM in DavisPercentile: {0}", x);
            Console.WriteLine("resultM/rho in DavisPercentile: {0}", x / rho);
            // x = x / rho
            return x;
        }

        public double CalcQuantileByOmega(double LeftTail, double RightTail)
        {
            TargetLeftTail = LeftTail;
            double guess = GuessQuantileByOmega(LeftTail, RightTail);
            double xmin = 0.0;
            var xmax = guess * 2.0;
            var get_digits = 51;
            uint maxit = 50U;
            Console.WriteLine("Guess: {0}", guess);
            var res1 = dreal.NewtonRaphson(CalcCDFByOmega, CalcPDFByOmega, guess, xmin, xmax, get_digits, maxit);
            TargetLeftTail = 0.0;
            Console.WriteLine("res1 (x0, iter): {0}", res1);
            return res1.Item1;
        }




        public void CalcKappa(int kmax_, int a, int b, double[] x, double[] y, double[] xi, double[] eta)
        {
            kmax = kmax_;
            kappa = new double[kmax + 1];

            sum1 = 0d;
            for (k = 1; k <= a; k++)
                sum1 = sum1 + x[k] * dreal.digamma(x[k] + xi[k]);
            sum2 = 0d;
            for (j = 1; j <= b; j++)
                sum2 = sum2 + y[j] * dreal.digamma(y[j] + eta[j]);

            double sum3 = 0d;
            for (k = 1; k <= a; k++)
                sum3 = sum3 + x[k] * Math.Log(x[k]);
            double sum4 = 0d;
            for (j = 1; j <= b; j++)
                sum4 = sum4 + y[j] * Math.Log(y[j]);
            double mean = -2 * (sum1 - sum2 - sum3 + sum4);
            Console.WriteLine("mean0: {0}", mean);
            double newkappa1 = -2 * (1 * sum1 - 1 * sum2 - 0 * sum3 + 0 * sum4);
            Console.WriteLine("newkappa1: {0}", newkappa1);
            kappa[1] = mean;
            Console.WriteLine("r: {0}, kappa (r): {1}", 1, kappa[1]);
            for (r = 2; r <= kmax; r++)
            {
                sum1 = 0d;
                for (k = 1; k <= a; k++)
                    sum1 = sum1 + Math.Pow(-2 * x[k], r) * dreal.polygamma(r - 1, x[k] + xi[k]);
                sum2 = 0d;
                for (j = 1; j <= b; j++)
                    sum2 = sum2 + Math.Pow(-2 * y[j], r) * dreal.polygamma(r - 1, y[j] + eta[j]);
                kappa[r] = sum1 - sum2;
                Console.WriteLine("r: {0}, kappa (r): {1}", r, kappa[r]);
            }
        }


        public double CalcQuantileByKappa(double LeftTail, double RightTail)
        {
            double mean = kappa[1];
            double sigma = Math.Sqrt(kappa[2]);

            double x2 = NewDistrib.DistCornish.CalcCornish(LeftTail, RightTail, mean, sigma, ref kappa, kmax);
            Console.WriteLine("resultM     in CornishPercentile X2: {0}", x2 * rho);
            Console.WriteLine("resultM/rho in CornishPercentile X2: {0}", x2);
            return x2;
        }

        public double CalcCDFByInvCorn(double z)
        {
            double mean = kappa[1];
            double sigma = Math.Sqrt(kappa[2]);

            double LeftTail = 0.6;
            double RightTail = 1 - LeftTail;

            double Result = DistCornish.InvCorn(z, LeftTail, RightTail, mean, sigma, ref kappa, kmax - 0);
            Console.WriteLine("InvCorn LeftTail: {0}, RightTail: {1}", Result, 1d - Result);
            return Result;
        }

        public double CalcCDFByEdgeworth(double z)
        {
            var ecf = new EdgeworthClass();
            double L1 = ecf.edgeworth(z, kmax - 3, kappa);
            Console.WriteLine("L1: {0}", L1);
            return L1;
        }




        public void CalcCGF(int kmax_, int a, int b, double[] x, double[] y, double[] xi, double[] eta, double x0)
        {
            double CGF_Derivative(double t, int j)
            {
                sum1 = 0d;
                for (k = 1; k <= a; k++)
                    sum1 = sum1 + Math.Pow(-2 * x[k], r) * dreal.polygamma(r - 1, x[k] * (1 - 2 * t) + xi[k]);
                sum2 = 0d;
                for (j = 1; j <= b; j++)
                    sum2 = sum2 + Math.Pow(-2 * y[j], r) * dreal.polygamma(r - 1, y[j] * (1 - 2 * t) + eta[j]);
                double result = sum1 - sum2;
                return result;
            }

            double K1(double t)
            {
                return CGF_Derivative(t, 1) - x0;
            }

            double K2(double t)
            {
                return CGF_Derivative(t, 2);
            }

            Console.WriteLine("x0: {0}", x0);
            kmax = kmax_;
            kderiv = new double[kmax + 1];

            var res1 = dreal.NewtonRaphson(K1, K2, 0.0, -1000000, 1000000, 51, 150U);
            Console.WriteLine("res1 (x0, iter): {0}", res1);
            double s = res1.Item1;
            double testS = CGF_Derivative(res1.Item1, 1);
            Console.WriteLine("testS: {0}", testS);

            double sum3 = 0d;
            for (k = 1; k <= a; k++)
                sum3 = sum3 + x[k] * Math.Log(x[k]);
            double sum4 = 0d;
            for (j = 1; j <= b; j++)
                sum4 = sum4 + y[j] * Math.Log(y[j]);
            sum1 = 0d;
            for (k = 1; k <= a; k++)
                sum1 = sum1 + x[k] * dreal.digamma(x[k] * (1 - 2 * s) + xi[k]);
            sum2 = 0d;
            for (j = 1; j <= b; j++)
                sum2 = sum2 + y[j] * dreal.digamma(y[j] * (1 - 2 * s) + eta[j]);

            kderiv[0] = 2 * (sum1 - sum2 - sum3 + sum4);
            Console.WriteLine("kderiv[0]: {0}", kderiv[0]);
            Console.WriteLine("r: {0}, kderiv (r): {1}", 0, kderiv[0]);
            for (r = 2; r <= kmax; r++)
            {
                kderiv[r - 1] = CGF_Derivative(s, r-1);
                Console.WriteLine("r: {0}, kderiv (r): {1}", r - 1, kderiv[r - 1]);
            }
            double density = 0, LeftTail = 0, RightTail = 0;

            DistN.LugannaniRiceNew(kmax, kderiv, s, ref density, ref LeftTail, ref RightTail);


        }





    }

}
