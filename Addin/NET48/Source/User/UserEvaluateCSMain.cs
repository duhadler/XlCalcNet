using System;
using System.Numerics;
using FixedPrecNet;

namespace EvaluateCS
{
    public class Program
    {

        public double[,,] test4()
        {
            int xResolution = 32 ;
            int yResolution = 32;
            double xmin = -1.0;
            double xmax = 1.0;
            double ymin = -1.0;
            double ymax = 1.0;

            double[,,] d3 = new double[3, xResolution + 1, yResolution + 1];

            double dx = (xmax - xmin) / xResolution;
            double dy = (ymax - ymin) / yResolution;

            double u = 0.0;
            double v = 0.0;

            for (int ix = 0; ix < xResolution + 1; ix++)
            {
                for (int iy = 0; iy < yResolution + 1; iy++)
                {
                    u = xmin + ix * dx;
                    v = ymin + iy * dy;
                    // Start function definition
                    var x = Math.Cos(u) * Math.Sin(v);
                    var y = Math.Cos(u) * Math.Cos(v);
                    var z = u;
                    // End function definition
                    d3[0, ix, iy] = x;
                    d3[1, ix, iy] = y;
                    d3[2, ix, iy] = z;
                }
            }
            return d3;
        }
    }
}


//using System;
//using System.Numerics;
//using FixedPrecNet;

//namespace EvaluateCS
//{
//    public class Program
//    {

//        public double[,,] test4()
//        {
//            int xResolution = 32;
//            int yResolution = 32;
//            double xmin = -1.0;
//            double xmax = 1.0;
//            double ymin = -1.0;
//            double ymax = 1.0;

//            double[,,] d3 = new double[3, xResolution + 1, yResolution + 1];

//            double dx = (xmax - xmin) / xResolution;
//            double dy = (ymax - ymin) / yResolution;

//            double x = 0.0;
//            double y = 0.0;

//            for (int ix = 0; ix < xResolution + 1; ix++)
//            {
//                for (int iy = 0; iy < yResolution + 1; iy++)
//                {
//                    x = xmin + ix * dx;
//                    y = ymin + iy * dy;
//                    // Start function definition
//                    var a = 1.0;
//                    var b = 1.0;
//                    var z = x * x / (b * b) - y * y / (a * a);
//                    // End function definition
//                    d3[0, ix, iy] = xmin + ix * dx;
//                    d3[1, ix, iy] = ymin + iy * dy;
//                    d3[2, ix, iy] = z;
//                }
//            }
//            return d3;
//        }
//    }
//}





//using System;
//using System.Numerics;
//using FixedPrecNet;

//namespace EvaluateCS
//{
//    public class Program
//    {

//        public double[,] test4()
//        {
//            int numPoints = 32;
//            int ExtraDt = 3;
//            double tmin = 0;
//            double tmax = 3.14159265358979;
//            double[,] d3 = new double[3, numPoints + 1];
//            double t = tmin;
//            double dt = (tmax - tmin) / (numPoints);

//            for (int i = 0; i < numPoints + ExtraDt; i++)
//            {
//                // Start function definition
//                var r = Math.Sqrt(3) / 3;
//                var x = Math.Cos(t);
//                var y = Math.Sin(t) + r;
//                var z = Math.Cos(3 * t) / 3;
//                // End function definition
//                d3[0, i] = x;
//                d3[1, i] = y;
//                d3[2, i] = z;
//                t += dt;
//            }
//            return d3;
//        }
//    }
//}



//using System;
//namespace EvaluateCS
//{
//    public class Program
//    {
//        public delegate double cbFuncDouble(double x);
//        cbFuncDouble phi = null;
//        cbFuncDouble psi = null;

//        public double[,] test4()
//        {
//            // Start function definition
//            double c = 1.0;
//            phi = (double t) => c * Math.Cos(t);
//            psi = (double t) => c * Math.Sin(t);
//            // End function definition

//            int numPoints = 20;
//            double tmin = 0.0;
//            double tmax = Math.PI;

//            double[,] twod = new double[2, numPoints + 1];
//            double tt = tmin;
//            double dt = (tmax - tmin) / (numPoints);

//            for (int i = 0; i < numPoints - 0; i++)
//            {
//                twod[0, i] = phi(tt);
//                twod[1, i] = psi(tt);
//                tt += dt;
//            }
//            twod[0, numPoints] = phi(tmax);
//            twod[1, numPoints] = psi(tmax);
//            return twod;
//        }
//    }
//}



//using System;
//namespace EvaluateCS
//{
//    public class Program
//    {
//        public delegate double cbFuncDouble(double x);
//        cbFuncDouble phi = null;
//        cbFuncDouble psi = null;

//        public double[,] test4()
//        {
//            // Start function definition
//            double c = 0.025;
//            phi = (double t) => c * Math.Cos(t) * t;
//            psi = (double t) => c * Math.Sin(t) * t;
//            // End function definition

//            double tt = 0.0;
//            int n = 10;
//            double[,] twod = new double[2, n];
//            for (int i = 0; i < n; i++)
//            {
//                twod[0, i] = phi(tt);
//                twod[1, i] = psi(tt);
//                tt = tt + 0.1;
//            }
//            return twod;
//        }
//    }
//}