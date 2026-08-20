using FixedPrecNet;
using System;

namespace NewDistrib
{
    internal class EdgeworthClass
    {

        //double[] kappa;
        double[] H;
        double[,] B;

        public EdgeworthClass()
        {
        }


        //# 9.1.1 Edgeworth expansion: general approximation to the pdf, cdf and sf
        public double edgeworth(double X, int Order, double[] kappa)
        {
            double mean = kappa[1];
            double sigma = Math.Sqrt(kappa[2]);
            double Z = (X - mean) / sigma;
            BellPoly(Order + 1, kappa);  // sets B
            HermitePoly(Order + 1, Z);   // sets H
            double s3 = dreal.ndis(Z);
            double s4 = dreal.ndens(Z);
            ////Console.WriteLine("j: {0}, s3: {1}", 0, s3);
            for (int j = 1; j < Order - 0; j++)
            {
                double s1 = h0j(j);
                double s2 = -s1 * s4;
                s3 = s3 + s2;
                //Console.WriteLine("j: {0}, s3: {1}, s2: {2}", j, s3, s2);
            }
            double LeftTail1 = s3;
            //double RightTail1 = 1 - LeftTail1;
            return LeftTail1;   //, RightTail1
        }

        public void BellPoly(int Order, double[] kappa)
        {
            int d0 = 3 + Order;
            var alpha = new double[d0+1];
            double sigma = Math.Sqrt(kappa[2]);
            alpha[2] = 0;
            double fakt = kappa[2];
            for (int i = 3; i < d0; i++)
            {
                //Console.WriteLine(i);
                fakt = fakt * sigma;
                alpha[i] = kappa[i] / fakt;
            }

            B = new double[3 * Order + 8, 3 * Order + 8];
            B[0, 0] = 1;
            for (int r = 3; r < d0; r++)
            {
                B[r, 1] = alpha[r];
            }
            for (int r = 4; r < 3 * Order + 1; r++)
            {
                int t = r / 3;
                t = t + 1;
                double r1 = r;
                for (int k = 2; k < t + 1; k++)
                {
                    double s = 0;
                    double d = r - k + 2;
                    if (d > d0)
                        d = d0;
                    double bk = (r1 - 1) * (r1 - 2) / 2;
                    for (int i = 3; i < d; i++)
                    {
                        s = s + bk * alpha[i] * B[r - i, k - 1];
                        bk = bk * (r1 - i) / i;
                    }
                    B[r, k] = s;
                }
            }
        }

        public void HermitePoly(int Order, double x)
        {
            int k = 3 * Order;
            H = new double[k + 8];
            H[0] = 1;
            H[1] = x;
            for (int r = 1; r < k + 1; r++)
            {
                H[r + 1] = x * H[r] - r * H[r - 1];
            }
        }

        public double h0j(int j)
        {
            double s = 0;
            for (int k = 1; k < j + 1; k++)
            {
                int r = j + 2 * k;
                s = s + B[r, k] 
                    * H[r - 1] 
                    / dreal.gamma(r + 1);
            }
            return s;
        }




    }


}
