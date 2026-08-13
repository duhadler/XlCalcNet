using System;
using System.IO;
using System.Numerics;
using System.Windows.Media.Media3D;
using System.Threading;
using System.Globalization;
using FixedPrecNet;
using System.Data;
using System.Windows.Forms;


//See also: http://www.3d-meier.de/tut3/Seite302.html

//See also: https://mathworld.wolfram.com/Trinoid.html



namespace TestBinaryReadWriteCS
{


    public class Data3D
    {

        public bool IsValid = true;

        public double[,] yvalues = null;
        public double[,] y2values = null;
        public double[,] yvalues_re = null;
        public double[,] yvalues_im = null;

        public double[,] xvalues = null;
        public double[,] zvalues = null;
        public int xResolution = 0;
        public int zResolution = 0;

        private double xmin = 0;
        private double xmax = 0;
        private double zmin = 0;
        private double zmax = 0;

        private string FullWorkPath = "";




        public Data3D(string FullWorkPath2, String Function3D, int xResolution2, int zResolution2,
               double xmin1, double xmax1, double zmin1, double zmax1)
        {
            FullWorkPath = FullWorkPath2;
            xResolution = xResolution2;
            zResolution = zResolution2;
            xmin = xmin1; xmax = xmax1; zmin = zmin1; zmax = zmax1;
            yvalues = new double[xResolution + 1, zResolution + 1];
            y2values = new double[xResolution + 1, zResolution + 1];
            yvalues_re = new double[xResolution + 1, zResolution + 1];
            yvalues_im = new double[xResolution + 1, zResolution + 1];

            xvalues = new double[xResolution + 1, zResolution + 1];
            zvalues = new double[xResolution + 1, zResolution + 1];
            CalculateXYZ(Function3D);
        }



        private Point3D ParametricF(String Function3D, double u, double v)
        {
            double x = 0.0;
            double y = 0.0;
            double z = 0.0;





            // 01. 01a TestProlateSpheroid
            if (Function3D == "_PARAMETRIC_ELLIPSOID")
            {
                // See : http://paulbourke.net/geometry/spherical/   prolate spheroid, or ellipsoid of revolution
                // See : https://en.wikipedia.org/wiki/Ellipsoid#Parameterization  ellipsoid of revolution
                // See : https://mathworld.wolfram.com/OblateSpheroid.html  Oblate Spheroid


double a = 1;
double b = 2.0;
double c = 3.0;
x = a * Math.Cos(u) * Math.Cos(v);
z = b * Math.Cos(u) * Math.Sin(v);
y = c * Math.Sin(u);
y = -y;
            }


            // 01. 02a-b TestSuperEllipsoid
            else if (Function3D == "_PARAMETRIC_SUPERELLIPSOID")
            {
                // See : http://paulbourke.net/geometry/spherical/
                // See : https://en.wikipedia.org/wiki/Superellipsoid
                // See : https://mathcurve.com/surfaces.gb/lame/lame.shtml
                // See : https://mathworld.wolfram.com/Ellipsoid.html        
                // See : https://mathworld.wolfram.com/Superellipsoid.html      
                //var r = 1;
var p1 = 2.0;
var p2 = 3.8;
var t1 = u;
var t2 = v;

var ct1 = Math.Cos(t1);
var ct2 = Math.Cos(t2);
var st1 = Math.Sin(t1);
var st2 = Math.Sin(t2);

var tmp = Math.Sign(ct1) * Math.Pow(Math.Abs(ct1), p1);
x = tmp * Math.Sign(ct2) * Math.Pow(Math.Abs(ct2), p2);
y = -Math.Sign(st1) * Math.Pow(Math.Abs(st1), p1);
z = tmp * Math.Sign(st2) * Math.Pow(Math.Abs(st2), p2);
z = -z;
            }


            // 01. 03a-b TestHexaedron
            else if (Function3D == "_PARAMETRIC_HEXAEDRON")
            {
var cosu = Math.Cos(u);
var sinu = Math.Sin(u);
var cosv = Math.Cos(v);
var sinv = Math.Sin(v);
x = cosv * cosv * cosv * cosu * cosu * cosu;
y = -sinu * sinu * sinu;
z = sinv * sinv * sinv * cosu * cosu * cosu;
z = -z;
            }


            // 01. 04a-b TestSuperToroid
            else if (Function3D == "_PARAMETRIC_SUPERTOROID")
            {
                // See : http://paulbourke.net/geometry/toroidal/
var r0 = 1;
var r1 = 0.3;

var p1 = 2.0;
var p2 = 3.8;
var t1 = u;
var t2 = v;

var ct1 = Math.Cos(t1);
var ct2 = Math.Cos(t2);
var st1 = Math.Sin(t1);
var st2 = Math.Sin(t2);

var tmp = r0 + r1 * Math.Sign(ct2) * Math.Pow(Math.Abs(ct2), p2);

x = tmp * Math.Sign(ct1) * Math.Pow(Math.Abs(ct1), p1);
y = -tmp * Math.Sign(st1) * Math.Pow(Math.Abs(st1), p1);
z = r1 * Math.Sign(st2) * Math.Pow(Math.Abs(st2), p2);
z = -z;
            }


            // 01. 05a TestEllipticHelicoid
            else if (Function3D == "_PARAMETRIC_ELLIPTICHELICOID")
            {
                // See : https://mathworld.wolfram.com/EllipticHelicoid.html
var a = 0.5;
var b = 1.5;
var c = 1;
var su = Math.Sin(u);
var cu = Math.Cos(u);

x = a * v * cu;
z = b * v * su;
y = c * u;
            }


            // 01. 06a-b TestHyperhelicoid
            else if (Function3D == "_PARAMETRIC_HYPERHELICOID")
            {
                // See : https://mathworld.wolfram.com/HyperbolicHelicoid.html
x = (Math.Sinh(v) * Math.Cos(3 * u)) / (1 + Math.Cosh(u) * Math.Cosh(v));
y = (Math.Cosh(v) * Math.Sinh(u)) / (1 + Math.Cosh(u) * Math.Cosh(v));
z = (Math.Sinh(v) * Math.Sin(3 * u)) / (1 + Math.Cosh(u) * Math.Cosh(v));
            }


            // 01. 07a-b TestDupin1
            else if (Function3D == "_PARAMETRIC_DUPIN1")
            {
                // See : https://mathcurve.com/surfaces.gb/cycliddedupin/cyclidededupin.shtml
                // See : https://en.wikipedia.org/wiki/Dupin_cyclide#Elliptic_cyclides
var a = 1.5;
var b = 1.4;
var c = Math.Sqrt(a * a - b * b);
var d = b / 2;
//                var d = a/2;
//                var d = c;
var su = Math.Sin(u);
var sv = Math.Sin(v);
var cu = Math.Cos(u);
var cv = Math.Cos(v);
var den = a - c * cu * cv;

x = (d * (c - a * cu * cv) + b * b * cu) / den;
y = -(b * su * (a - d * cv)) / den;
z = (b * sv * (c * cu - d)) / den;
z = -z;
            }


            // 01. 08a-b TestDupin2
            else if (Function3D == "_PARAMETRIC_DUPIN2")
            {
                // See : https://mathcurve.com/surfaces.gb/cycliddedupin/cyclidededupin.shtml
                // See : https://en.wikipedia.org/wiki/Dupin_cyclide#Parabolic_cyclides
var p = 2;
var k = 0.7;
var den = 1 + u * u + v * v;
x = 0.5 * p * (2 * v * v + k * (1 - u * u - v * v)) / den;
z = p * u * (v * v + k) / den;
y = p * v * (1 + u * u - k) / den;
            }


            // 01. 09a-b TestDini
            else if (Function3D == "_PARAMETRIC_DINI")
            {
                // See : https://mathworld.wolfram.com/DinisSurface.html
var a = 1;
var b = 0.2;
x = a * Math.Cos(u) * Math.Sin(v);
y = a * Math.Sin(u) * Math.Sin(v);
z = a * (Math.Cos(v) + Math.Log(Math.Tan(0.5 * v))) + b * u;
            }


            // 01. 10a-b Plücker
            else if (Function3D == "_PARAMETRIC_PLUECKER")
            {
                // See : https://mathworld.wolfram.com/PlueckersConoid.html
                // See : Gray, p. 436
                // See : https://en.wikipedia.org/wiki/Pl%C3%BCcker%27s_conoid

var n = 2;
var r = u;
var theta = v;

x = r * Math.Cos(theta);
z = r * Math.Sin(theta);
y = Math.Sin(n * theta);
            }


            // 01. 10a-b Plücker
            else if (Function3D == "_PARAMETRIC_PLUECKER_4")
            {
                // See : https://mathworld.wolfram.com/PlueckersConoid.html
                // See : Gray, p. 436
                // See : https://en.wikipedia.org/wiki/Pl%C3%BCcker%27s_conoid

var n = 4;
var r = u;
var theta = v;

x = r * Math.Cos(theta);
z = r * Math.Sin(theta);
y = Math.Sin(n * theta);
            }


            // 01. 10a-b Plücker
            else if (Function3D == "_PARAMETRIC_PLUECKER_7")
            {
                // See : https://mathworld.wolfram.com/PlueckersConoid.html
                // See : Gray, p. 436
                // See : https://en.wikipedia.org/wiki/Pl%C3%BCcker%27s_conoid

var n = 7;
var r = u;
var theta = v;

x = r * Math.Cos(theta);
z = r * Math.Sin(theta);
y = Math.Sin(n * theta);
            }






            // 01. 11a-b Umbilic Torus
            else if (Function3D == "_PARAMETRIC_UmbilicTorus")
            {
                // See also: http://www.3d-meier.de/tut3/Seite61.html  // Umbilic Torus
x = math53.sin(u) * (7 + Math.Cos(u / 3 - 2 * v) + 2 * Math.Cos(u / 3 + v));
z = math53.cos(u) * (7 + Math.Cos(u / 3 - 2 * v) + 2 * Math.Cos(u / 3 + v));
y = Math.Sin(u / 3 - 2 * v) + 2 * Math.Sin(u / 3 + v);
            }



            // 01. 12a Skidan a
            else if (Function3D == "_PARAMETRIC_Skidan")
            {
                // See also: http://www.3d-meier.de/tut3/Seite227.html  // Skidan Ruled Surface
                // See Krivoshapko, p. 499
var a = Math.PI / 4.0;
var h = 2.0;
var n = 4.0;

var b = h * Math.Abs(Math.Cos(n * v));
var ca = Math.Cos(a);
var sa = Math.Sin(a);

x = (u * sa + b * ca) * Math.Cos(v);
y = (u * sa + b * ca) * Math.Sin(v);
z = -(u * ca - b * sa);
            }



            // 01. 12a Skidan b
            else if (Function3D == "_PARAMETRIC_Skidan_b")
            {
                // See also: http://www.3d-meier.de/tut3/Seite227.html  // Skidan Ruled Surface
                // See Krivoshapko, p. 499
var a = Math.PI / 2.0;
var h = 2.0;
var n = 4.0;

var b = h * Math.Abs(Math.Cos(n * v));
var ca = Math.Cos(a);
var sa = Math.Sin(a);

x = (u * sa + b * ca) * Math.Cos(v);
y = (u * sa + b * ca) * Math.Sin(v);
z = -(u * ca - b * sa);
            }



            // 01. 12a Skidan c
            else if (Function3D == "_PARAMETRIC_Skidan_d")
            {
                // See also: http://www.3d-meier.de/tut3/Seite227.html  // Skidan Ruled Surface
                // See Krivoshapko, p. 499
var a = 0.0;
var h = 2.0;
var n = 3.0;

var b = h * Math.Abs(Math.Cos(n * v));
var ca = Math.Cos(a);
var sa = Math.Sin(a);

x = (u * sa + b * ca) * Math.Cos(v);
y = (u * sa + b * ca) * Math.Sin(v);
z = -(u * ca - b * sa);
            }



            // 01. 12a Skidan d
            else if (Function3D == "_PARAMETRIC_Skidan_e")
            {
                // See also: http://www.3d-meier.de/tut3/Seite227.html  // Skidan Ruled Surface
                // See Krivoshapko, p. 499

var a = 0.0;
var h = 2.0;
var n = 4.0;

var b = h * Math.Abs(Math.Cos(n * v));
var ca = Math.Cos(a);
var sa = Math.Sin(a);

x = (u * sa + b * ca) * Math.Cos(v);
y = (u * sa + b * ca) * Math.Sin(v);
z = -(u * ca - b * sa);
            }


            // 01. 13a-b Umbrella
            else if (Function3D == "_PARAMETRIC_Umbrella")
            {
                // See also: http://www.3d-meier.de/tut3/Seite215.html  // Umbrella Surface
                // See Krivoshapko, p. 507 - 509 
                // See Krivoshapko, p. 513 - 515 
                // See Krivoshapko, p. 521, 526, 530, 531, 533

var R = 0.6;
var h = 0.6;
var n = 8.0;

var r = R / n;
x = math53.cbrt(u) * ((R - r)) * Math.Cos(v) + r * Math.Cos((n - 1) * v);
z = math53.cbrt(u) * ((R - r)) * Math.Sin(v) - r * Math.Sin((n - 1) * v);
y = h * (1 - u);
            }



            // 01. 14a Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface0")
            {
                // See Krivoshapko, p. 376
var a = 1.0;
var b = 2.0;
var d = 0.0;
var p = 1.0;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }



            // 01. 14b Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface05")
            {
                // See Krivoshapko, p. 376
var a = 1.0;
var b = 2.0;
var d = 0.3;
var p = 0.5;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }



            // 01. 14c Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface1")
            {
                // See Krivoshapko, p. 376
var a = 1.0;
var b = 2.0;
var d = 0.3;
var p = 1.0;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }


            // 01. 14d Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface2")
            {
                // See Krivoshapko, p. 376
var a = 1.0;
var b = 2.0;
var d = 0.3;
var p = 2.0;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }


            // 01. 14e Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface3")
            {
                // See Krivoshapko, p. 376
var a = 1.0;
var b = 2.0;
var d = 0.3;
var p = 3.0;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }


            // 01. 14f Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface4")
            {
                // See Krivoshapko, p. 376
var a = 1.0;
var b = 2.0;
var d = 0.3;
var p = 4.0;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }


            // 01. 14g Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface7")
            {
                // See Krivoshapko, p. 376
var a = 1.0;
var b = 2.0;
var d = 0.3;
var p = 7.0;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }


            // 01. 14h Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface2_05")
            {
                // See Krivoshapko, p. 377
var a = 1.0;
var b = 5.0;
var d = 1.0;
var p = 0.5;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }


            // 01. 14i Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface2_3")
            {
                // See Krivoshapko, p. 377
var a = 1.0;
var b = 5.0;
var d = 1.0;
var p = 3.0;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }


            // 01. 14j Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface2_4")
            {
                // See Krivoshapko, p. 377
var a = 1.0;
var b = 5.0;
var d = 1.0;
var p = 4.0;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }


            // 01. 14k Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface2_6")
            {
                // See Krivoshapko, p. 377
var a = 1.0;
var b = 5.0;
var d = 1.0;
var p = 6.0;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }


            // 01. 14l Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface3_3")
            {
                // See Krivoshapko, p. 377
var a = 1.0;
var b = 5.0;
var d = 2.0;
var p = 3.0;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }


            // 01. 14m Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface3_5")
            {
                // See Krivoshapko, p. 377
var a = 1.0;
var b = 2.0;
var d = 1.0;
var p = 5.0;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }


            // 01. 14n Cyclic Surface
            else if (Function3D == "_PARAMETRIC_Cyclic_Surface3_7")
            {
                // See Krivoshapko, p. 377
var a = 1.0;
var b = 8.0;
var d = 0.3;
var p = 13.0;

var R = a * (1 - d * Math.Cos(p * u));
x = (b + R * math53.cos(v)) * math53.cos(u);
y = (b + R * math53.cos(v)) * math53.sin(u);
z = R * Math.Sin(v);
            }






            // 01. 15a Goursat1
            else if (Function3D == "_PARAMETRIC_Goursat1")
            {
                // See : http://www.3d-meier.de/tut3/Seite213.html
var su = Math.Sin(u);
var cu = Math.Cos(u);
var sv = Math.Sin(v);
var cv = Math.Cos(v);

var su4 = su * su * su * su;
var cu4 = cu * cu * cu * cu;

var sv4 = sv * sv * sv * sv;
var cv4 = cv * cv * cv * cv;

var D = (su4 + cu4) * cv4 + sv4;
var R = Math.Sqrt(1 / D);
x = R * cv * cu;
y = R * cv * su;
z = R * sv;
            }



            // 01. 15b Goursat2
            else if (Function3D == "_PARAMETRIC_Goursat2")
            {
                // See : Krivoshapko (2015), p. 643
                // See: https://mathworld.wolfram.com/GoursatsSurface.html
                // See Gray 1997, p. 314)
                // See: https://mathcurve.com/surfaces.gb/goursat/goursat.shtml
var a = -0.33;
var b = 0.2;
var c = -3;
var p = 1;

var su = Math.Sin(u);
var cu = Math.Cos(u);
var sv = Math.Sin(v);
var cv = Math.Cos(v);

var su4 = su * su * su * su;
var cu4 = cu * cu * cu * cu;

var sv4 = sv * sv * sv * sv;
var cv4 = cv * cv * cv * cv;

var D = (su4 + cu4) * cv4 + sv4;
var R = Math.Sqrt((-b + p * Math.Sqrt(b * b - 4 * c * (a + D))) / (2 * (a + D)));
x = R * cv * cu;
y = R * cv * su;
z = R * sv;
            }



            // 01. 15c Goursat3
            else if (Function3D == "_PARAMETRIC_Goursat3")
            {
                IsValid = true;
                // See : Krivoshapko (2015), p. 643
                // See: https://mathworld.wolfram.com/GoursatsSurface.html
                // See Gray 1997, p. 314)
                // See: https://mathcurve.com/surfaces.gb/goursat/goursat.shtml
var a = 0;
var b = -5;
var c = 11.8;
var p = 1;

var su = Math.Sin(u);
var cu = Math.Cos(u);
var sv = Math.Sin(v);
var cv = Math.Cos(v);

var su4 = su * su * su * su;
var cu4 = cu * cu * cu * cu;

var sv4 = sv * sv * sv * sv;
var cv4 = cv * cv * cv * cv;

var D = (su4 + cu4) * cv4 + sv4;
var temp1 = (b * b - 4 * c * (a + D));
var temp2 = (-b + p * Math.Sqrt(temp1)) / (2 * (a + D));
var R = Math.Sqrt(temp2);
x = R * cv * cu;
y = R * cv * su;
z = R * sv;
            }



            // 01. 15d Goursat4
            else if (Function3D == "_PARAMETRIC_Goursat4")
            {
                // See : Krivoshapko (2015), p. 643
                // See: https://mathworld.wolfram.com/GoursatsSurface.html
                // See Gray 1997, p. 314)
                // See: https://mathcurve.com/surfaces.gb/goursat/goursat.shtml
var a = -0.2;
var b = -1;
var c = -0.3125;
var p = -1;

var su = Math.Sin(u);
var cu = Math.Cos(u);
var sv = Math.Sin(v);
var cv = Math.Cos(v);

var su4 = su * su * su * su;
var cu4 = cu * cu * cu * cu;

var sv4 = sv * sv * sv * sv;
var cv4 = cv * cv * cv * cv;

var D = (su4 + cu4) * cv4 + sv4;
var R = Math.Sqrt(Math.Abs(-b + p * Math.Sqrt(Math.Abs(b * b - 4 * c * (a + D))) / (2 * (a + D))));
//var R = Math.Sqrt((-b + p * Math.Sqrt(b * b - 4 * c * (a + D))) / (2 * (a + D)));
x = R * cv * cu;
y = R * cv * su;
z = R * sv;
            }



            // 01. 15e Goursat5
            else if (Function3D == "_PARAMETRIC_Goursat5")
            {
                // See : Krivoshapko (2015), p. 643
                // See: https://mathworld.wolfram.com/GoursatsSurface.html
                // See Gray 1997, p. 314)
                // See: https://mathcurve.com/surfaces.gb/goursat/goursat.shtml

//IsValid = true;
var a = -0.2;
var b = -1;
var c = 0.3125;
var p = -1;

var su = Math.Sin(u);
var cu = Math.Cos(u);
var sv = Math.Sin(v);
var cv = Math.Cos(v);

var su4 = su * su * su * su;
var cu4 = cu * cu * cu * cu;

var sv4 = sv * sv * sv * sv;
var cv4 = cv * cv * cv * cv;

var D = (su4 + cu4) * cv4 + sv4;
var temp1 = (b * b - 4 * c * (a + D));
var temp2 = (-b + p * Math.Sqrt(temp1)) / (2 * (a + D));
var R = Math.Sqrt(temp2);

x = R * cv * cu;
y = R * cv * su;
z = R * sv;
            }





            // 01. 16a-c CyclidesTriple
            else if (Function3D == "_PARAMETRIC_CyclidesTriple")
            {
                // See : Krivoshapko (2015), p. 651

var su = Math.Sin(u);
var s2u = Math.Sin(2 * u);
var cu = Math.Cos(u);
var sv = Math.Sin(v);
var cv = Math.Cos(v);

x = cv * sv * sv * sv * s2u * cu;
y = cv * sv * sv * sv * s2u * su;
z = -cv * sv * sv * s2u;
            }



            // 01. 17a-b ShipLamé
            else if (Function3D == "_PARAMETRIC_ShipLame")
            {
                // See : Krivoshapko (2015), p. 671

var B = 6.5;
var L = 4.0;
var T = 2.0;

x = u * L;
z = Math.Sign(Math.Cos(v)) * B * Math.Sqrt(1 - u * u * u * u) * Math.Sqrt(Math.Abs(Math.Cos(v))) / 2.0;
y = -Math.Sign(Math.Sin(v)) * T * Math.Sqrt(1 - u * u) * Math.Sqrt(Math.Abs(Math.Sin(v)));
            }










            // 02. 01a-b TestHelicoid
            else if (Function3D == "_PARAMETRIC_HELICOID")
            // See also: https://mathworld.wolfram.com/Helicoid.html
            {
x = u * Math.Cos(v);
z = u * Math.Sin(v);
y = v;
z = -z;
            }


            // 02. 02a-b TestBour
            else if (Function3D == "_PARAMETRIC_BOUR")
            {
                // See : https://mathworld.wolfram.com/BoursMinimalSurface.html
var sv = Math.Sin(v);
var s2v = Math.Sin(2 * v);
var c32u = Math.Cos(1.5 * v);
var cv = Math.Cos(v);
var c2v = Math.Cos(2 * v);
var u2 = 0.5 * u * u;
var u32 = (4.0 / 3.0) * Math.Sqrt(u * u * u);

x = u * cv - u2 * c2v;
y = -u * sv - u2 * s2v;
z = u32 * c32u;
            }


            // 02. 03a-b TestCatalan
            else if (Function3D == "_PARAMETRIC_CATALAN")
            {
                // See : https://mathworld.wolfram.com/CatalansSurface.html
x = u - Math.Sin(u) * Math.Cosh(v);
y = 4 * Math.Sin(u / 2) * Math.Sinh(v / 2);
z = 1 - Math.Cos(u) * Math.Cosh(v);
            }


            // 02. 04a-b TestEnneper
            else if (Function3D == "_PARAMETRIC_ENNEPER")
            {
                // See : https://mathworld.wolfram.com/EnnepersMinimalSurface.html
                // See : https://en.wikipedia.org/wiki/Enneper_surface
                // compared to Mathworld equations 18-20, we scwitched y and z
x = u - u * u * u / 3 + u * v * v;
y = u * u - v * v;
z = v - v * v * v / 3 + v * u * u;
            }


            // 02. 05a-b TestEnneper2
            else if (Function3D == "_PARAMETRIC_ENNEPER2")
            {
                // See : https://mathcurve.com/surfaces.gb/enneper/enneper.shtml
var n = 2;
var a = 1;

Complex i = Complex.ImaginaryOne;
Complex w = new Complex(u, v);
Complex w2nm1 = Complex.Pow(w, 2 * n - 1) / (2 * n - 1);
Complex wn = Complex.Pow(w, n);
x = a * (w - w2nm1).Real;
y = a * (-i * (w + w2nm1)).Real;
z = 2 * a * (wn / n).Real;
            }


            // 02. 06a-b TestHenneberg
            else if (Function3D == "_PARAMETRIC_HENNEBERG")
            {
                // !!! Need to avoid 2/3 or similar !!! Constants need to be var !!!!
                // See : https://mathworld.wolfram.com/HennebergsMinimalSurface.html
                // See : https://en.wikipedia.org/wiki/Henneberg_surface

var sv = Math.Sin(v);
var s3v = Math.Sin(3 * v);
var cv = Math.Cos(v);
var c2v = Math.Cos(2 * v);
var c3v = Math.Cos(3 * v);

var shu = Math.Sinh(u);
var ch2u = Math.Cosh(2 * u);
var sh3u = Math.Sinh(3 * u);

x = 2 * shu * cv - (2.0 / 3.0) * sh3u * c3v;
y = 2 * shu * sv + (2.0 / 3.0) * sh3u * s3v;
z = 2 * ch2u * c2v;
            }


            // 02. 07a TestScherk1
            else if (Function3D == "_PARAMETRIC_SCHERK1KI")
            {
                // See : https://mathworld.wolfram.com/ScherksMinimalSurfaces.html
                // See : https://mathcurve.com/surfaces.gb/scherk/scherk.shtml
                // See : KI, p. 431
                // This is doubly periodic
var a = 1 / Math.PI;
x = u;
z = v;
y = a * Math.Log(Math.Cos(v / a) / Math.Cos(u / a));
z = -z;
            }


            // 02. 08a TestScherk2
            else if (Function3D == "_PARAMETRIC_SCHERK2")
            {
                // See : https://mathworld.wolfram.com/ScherksMinimalSurfaces.html (typo!!)
                // See : https://mathcurve.com/surfaces.gb/scherk/scherk.shtml
                // See : https://en.wikipedia.org/wiki/Scherk_surface
                // t = 0 .. 2pi
                // r = 0 .. 1  // 0.75
var t = v;
var r = u;
var r2 = r * r;
var ct = Math.Cos(t);
var st = Math.Sin(t);
x = Math.Log((1 + r2 + 2 * r * ct) / (1 + r2 - 2 * r * ct));
y = Math.Log((1 + r2 - 2 * r * st) / (1 + r2 + 2 * r * st));
z = 2 * Math.Atan((2 * r2 * Math.Sin(2 * t)) / (r2 * r2 - 1));
y = -y;
            }


//            // 02. 09a-b TestLichtenfels
//            else if (Function3D == "_PARAMETRIC_LICHTENFELS")
//            {
//                // See : https://mathworld.wolfram.com/LichtenfelsMinimalSurface.html
//                // See : https://www.wolframalpha.com/input/?i=lichtenfels+minimal+surface
//FRealT Sqrt2 = FReal.Sqrt(2);
//FCplxT zeta3 = FCplx.T(u, v) / 3;
//x = (Sqrt2 * FCplx.Cos(zeta3) * FCplx.Sqrt(FCplx.Cos(2 * zeta3))).Real.d;
//z = (-Sqrt2 * FCplx.Sin(zeta3) * FCplx.Sqrt(FCplx.Cos(2 * zeta3))).Real.d;
//y = (Sqrt2 * FCplxFlint.MEllipticF(zeta3, 2)).Imag.d;
//            }





            // 02. 10a-b TestCosta
            else if (Function3D == "_PARAMETRIC_COSTA")
            {
                // See : https://mathworld.wolfram.com/CostaMinimalSurface.html
                // See : https://mathcurve.com/surfaces.gb/costa/costa.shtml
                // See Bauer A (2010) Costa surface with minimal fuss
var u1 = u;
var v1 = v;

var b = 3.5;

//var a = 1.0;
var c = 189.7272;
var e1 = 6.87519;
var p4e = Math.PI / (4 * e1);
var p2e = Math.PI / (2 * e1);

Complex i = Complex.ImaginaryOne;
Complex w = new Complex(u1, v1);
var wh = w - 0.5;
var wi = w - 0.5 * i;

var Zw = cmath53.WeierstrassZeta(c, 0, w);
var Zwh = cmath53.WeierstrassZeta(c, 0, wh);
var Zwi = cmath53.WeierstrassZeta(c, 0, wi);
var Pw = cmath53.WeierstrassP(c, 0, w);

x = (Math.PI * (u1 + p4e) - Zw + p2e * (Zwh - Zwi)).Real;
z = (Math.PI * (v1 + p4e) - i * Zw - i * p2e * (Zwh - Zwi)).Real;
y = Math.Sqrt(Math.PI / 2) * Math.Log(Complex.Abs((Pw - e1) / (Pw + e1)));

if (x > b) x = b;
if (x < -b) x = -b;
if (y > b) y = b;
if (y < -b) y = -b;
if (z > b) z = b;
if (z < -b) z = -b;
            }




            // 02. 11a Richmond
            else if (Function3D == "_PARAMETRIC_Richmond")
            {
                // See also: http://www.3d-meier.de/tut3/Seite250.html  // Richmond Surface III
                // See also: https://en.wikipedia.org/wiki/Richmond_surface


var n = 2.0;
var u2s = Math.Pow(u, 2 * n + 1) / (4 * n + 2);
x = -Math.Cos(v) / (2 * u) - u2s * Math.Cos(-(2 * n + 1) * v);
y = -Math.Sin(v) / (2 * u) + u2s * Math.Sin(-(2 * n + 1) * v);
z = Math.Pow(u, n) * Math.Cos(n * v) / n;
            }




            // 02. 11b Richmond
            else if (Function3D == "_PARAMETRIC_Richmond3")
            {
                // See also: http://www.3d-meier.de/tut3/Seite250.html  // Richmond Surface III

var n = 3.0;
var u2s = Math.Pow(u, 2 * n + 1) / (4 * n + 2);
x = -Math.Cos(v) / (2 * u) - u2s * Math.Cos(-(2 * n + 1) * v);
y = -Math.Sin(v) / (2 * u) + u2s * Math.Sin(-(2 * n + 1) * v);
z = Math.Pow(u, n) * Math.Cos(n * v) / n;
            }


            // 02. 11c Richmond
            else if (Function3D == "_PARAMETRIC_Richmond4")
            {
                // See also: http://www.3d-meier.de/tut3/Seite250.html  // Richmond Surface III

var n = 4.0;
var u2s = Math.Pow(u, 2 * n + 1) / (4 * n + 2);
x = -Math.Cos(v) / (2 * u) - u2s * Math.Cos(-(2 * n + 1) * v);
y = -Math.Sin(v) / (2 * u) + u2s * Math.Sin(-(2 * n + 1) * v);
z = Math.Pow(u, n) * Math.Cos(n * v) / n;
            }


            // 02. 11d Richmond
            else if (Function3D == "_PARAMETRIC_Richmond5")
            {
                // See also: http://www.3d-meier.de/tut3/Seite250.html  // Richmond Surface III

var n = 5.0;
var u2s = Math.Pow(u, 2 * n + 1) / (4 * n + 2);
x = -Math.Cos(v) / (2 * u) - u2s * Math.Cos(-(2 * n + 1) * v);
y = -Math.Sin(v) / (2 * u) + u2s * Math.Sin(-(2 * n + 1) * v);
z = Math.Pow(u, n) * Math.Cos(n * v) / n;
            }


            // 02. 11e Richmond
            else if (Function3D == "_PARAMETRIC_Richmond9")
            {
                // See also: http://www.3d-meier.de/tut3/Seite250.html  // Richmond Surface III

var n = 9.0;
var u2s = Math.Pow(u, 2 * n + 1) / (4 * n + 2);
x = -Math.Cos(v) / (2 * u) - u2s * Math.Cos(-(2 * n + 1) * v);
y = -Math.Sin(v) / (2 * u) + u2s * Math.Sin(-(2 * n + 1) * v);
z = Math.Pow(u, n) * Math.Cos(n * v) / n;
            }


            // 02. 11f Richmond
            else if (Function3D == "_PARAMETRIC_Richmond13")
            {
                // See also: http://www.3d-meier.de/tut3/Seite250.html  // Richmond Surface III

var n = 13.0;
var u2s = Math.Pow(u, 2 * n + 1) / (4 * n + 2);
x = -Math.Cos(v) / (2 * u) - u2s * Math.Cos(-(2 * n + 1) * v);
y = -Math.Sin(v) / (2 * u) + u2s * Math.Sin(-(2 * n + 1) * v);
z = Math.Pow(u, n) * Math.Cos(n * v) / n;
            }





            // 02. 12a GenEnneper
            else if (Function3D == "_PARAMETRIC_GenEnneper")
            {
                // See also: http://www.3d-meier.de/tut3/Seite247.html  // Wavy Enneper Surface

var s = 2.0;
var u2s = Math.Pow(u, 2 * s - 1) / (2 * s - 1);
x = u * Math.Cos(v) - u2s * Math.Cos((2 * s - 1) * v);
y = -u * Math.Sin(v) - u2s * Math.Sin((2 * s - 1) * v);
z = 2 * Math.Pow(u, s) * Math.Cos(s * v) / s;
            }


            // 02. 12b GenEnneper
            else if (Function3D == "_PARAMETRIC_GenEnneper3")
            {
                // See also: http://www.3d-meier.de/tut3/Seite247.html  // Wavy Enneper Surface

var s = 3.0;
var u2s = Math.Pow(u, 2 * s - 1) / (2 * s - 1);
x = u * Math.Cos(v) - u2s * Math.Cos((2 * s - 1) * v);
y = -u * Math.Sin(v) - u2s * Math.Sin((2 * s - 1) * v);
z = 2 * Math.Pow(u, s) * Math.Cos(s * v) / s;
            }


            // 02. 12c GenEnneper
            else if (Function3D == "_PARAMETRIC_GenEnneper4")
            {
                // See also: http://www.3d-meier.de/tut3/Seite247.html  // Wavy Enneper Surface

var s = 4.0;
var u2s = Math.Pow(u, 2 * s - 1) / (2 * s - 1);
x = u * Math.Cos(v) - u2s * Math.Cos((2 * s - 1) * v);
y = -u * Math.Sin(v) - u2s * Math.Sin((2 * s - 1) * v);
z = 2 * Math.Pow(u, s) * Math.Cos(s * v) / s;
            }


            // 02. 12d GenEnneper
            else if (Function3D == "_PARAMETRIC_GenEnneper5")
            {
                // See also: http://www.3d-meier.de/tut3/Seite247.html  // Wavy Enneper Surface

var s = 5.0;
var u2s = Math.Pow(u, 2 * s - 1) / (2 * s - 1);
x = u * Math.Cos(v) - u2s * Math.Cos((2 * s - 1) * v);
y = -u * Math.Sin(v) - u2s * Math.Sin((2 * s - 1) * v);
z = 2 * Math.Pow(u, s) * Math.Cos(s * v) / s;
            }


            // 02. 12e GenEnneper
            else if (Function3D == "_PARAMETRIC_GenEnneper9")
            {
                // See also: http://www.3d-meier.de/tut3/Seite247.html  // Wavy Enneper Surface

var s = 9.0;
var u2s = Math.Pow(u, 2 * s - 1) / (2 * s - 1);
x = u * Math.Cos(v) - u2s * Math.Cos((2 * s - 1) * v);
y = -u * Math.Sin(v) - u2s * Math.Sin((2 * s - 1) * v);
z = 2 * Math.Pow(u, s) * Math.Cos(s * v) / s;
            }


            // 02. 12f GenEnneper
            else if (Function3D == "_PARAMETRIC_GenEnneper13")
            {
                // See also: http://www.3d-meier.de/tut3/Seite247.html  // Wavy Enneper Surface

var s = 13.0;
var u2s = Math.Pow(u, 2 * s - 1) / (2 * s - 1);
x = u * Math.Cos(v) - u2s * Math.Cos((2 * s - 1) * v);
y = -u * Math.Sin(v) - u2s * Math.Sin((2 * s - 1) * v);
z = 2 * Math.Pow(u, s) * Math.Cos(s * v) / s;
            }



            //// 02. 13 k-noid
            //else if (Function3D == "_PARAMETRIC_K_NOID")
            //{
            //    // See : https://en.wikipedia.org/wiki/K-noid
            //    var k = 7.0;
            //    Complex z_ = new Complex(u, v);
            //    Complex z2 = z_ * z_;
            //    Complex zk = Complex.Pow(z_, k);
            //    Complex A = (k - 1) * (zk - 1) * cmath53.Hypergeom2F1(1.0, -1.0 / k, (k - 1.0) / k, zk);
            //    Complex B = (k - 1) * z2 * (zk - 1) * cmath53.Hypergeom2F1(1.0, 1.0 / k, 1 + 1.0 / k, zk);
            //    Complex C1 = -k * zk + k + z2 - 1;
            //    Complex C2 = -k * zk + k - z2 - 1;

            //    x = 0.5 * ((-1 / (k * z_ * (zk - 1))) * (A - B + C1)).Real;
            //    y = 0.5 * ((Complex.ImaginaryOne / (k * z_ * (zk - 1))) * (A + B + C2)).Real;
            //    z = (1 / (k - k * zk)).Real;

            //    if (x * x + y * y + z * z > 0.5)
            //    {
            //        x = double.NaN;
            //        y = double.NaN;
            //        z = double.NaN;
            //    }

            //}











            // 03. 01a TestMoebius
            else if (Function3D == "_PARAMETRIC_MOEBIUS")
            {
                // See also: http://en.wikipedia.org/wiki/M%C3%B6bius_strip
                // See also: https://mathworld.wolfram.com/MoebiusStrip.html
                // See Krivoshapko p.419

var a = 1.0;
var b = 1.0;
int m = 1;

x = (a + u * Math.Sin(m * v / 2)) * Math.Cos(v);
z = (b + u * Math.Sin(m * v / 2)) * Math.Sin(v);
y = (u / 2) * Math.Cos(v / 2);
z = -z;
            }


            // 03. 01b TestMoebius
            else if (Function3D == "_PARAMETRIC_MOEBIUS2")
            {
                // See also: http://en.wikipedia.org/wiki/M%C3%B6bius_strip
                // See also: https://mathworld.wolfram.com/MoebiusStrip.html
                // See Krivoshapko p.419

var a = 1.0;
var b = 1.0;
int m = 5;

x = (a + u * Math.Sin(m * v / 2)) * Math.Cos(v);
z = (b + u * Math.Sin(m * v / 2)) * Math.Sin(v);
y = (u / 2) * Math.Cos(v / 2);
z = -z;
            }


            // 03. 02a-b TestCrossCap
            else if (Function3D == "_PARAMETRIC_CROSSCAP")
            {
                // See : https://mathworld.wolfram.com/Cross-Cap.html
var su = Math.Sin(u);
var sv = Math.Sin(v);
var s2v = Math.Sin(2 * v);
var cu = Math.Cos(u);
var cv = Math.Cos(v);
x = 0.5 * cu * s2v;
z = 0.5 * su * s2v;
y = 0.5 * (cv * cv - cu * cu * sv * sv);
            }


            // 03. 03a-b TestPseudoCrossCap
            else if (Function3D == "_PARAMETRIC_PSEUDOCROSSCAP")
            {
                // See : https://mathworld.wolfram.com/Pseudocrosscap.html
                // See : http://www.3d-meier.de/tut3/Seite51.html
var sv = Math.Sin(v);
var s2v = Math.Sin(2 * v);
x = (1 - u * u) * sv;
y = (1 - u * u) * s2v;
z = u;
            }



            // 03. 04a-b TestRoman
            else if (Function3D == "_PARAMETRIC_ROMAN")
            {
                // See : https://mathworld.wolfram.com/RomanSurface.html
                // See : https://en.wikipedia.org/wiki/Roman_surface

var r2 = 1;
var su = Math.Sin(u);
var sv = Math.Sin(v);
var cu = Math.Cos(u);
var cv = Math.Cos(v);
x = r2 * cu * su * sv;
y = r2 * cu * su * cv;
z = r2 * cu * cu * sv * cv;
            }


            // 03. 05a-b TestKleinBagel
            else if (Function3D == "_PARAMETRIC_KLEINBAGEL")
            {
                // See also: https://en.wikipedia.org/wiki/Klein_bottle#The_figure_8_immersion	    
                // See also: https://mathworld.wolfram.com/KleinBottle.html
var r = 2.1;
x = (r + Math.Cos(u / 2) * Math.Sin(v) - Math.Sin(u / 2) * Math.Sin(2 * v)) * Math.Cos(u);
z = (r + Math.Cos(u / 2) * Math.Sin(v) - Math.Sin(u / 2) * Math.Sin(2 * v)) * Math.Sin(u);
y = Math.Sin(u / 2) * Math.Sin(v) + Math.Cos(u / 2) * Math.Sin(2 * v);
            }


            // 03. 06a-b TestKleinBottle
            else if (Function3D == "_PARAMETRIC_KLEINBOTTLE")
            {
                //          http://www.mapleprimes.com/maplesoftblog/95570-Klein-Bottle-Plot
                //          http://www.chebfun.org/examples/geom/ParametricSurfaces.html
                // See also: https://mathworld.wolfram.com/KleinBottle.html
x = (3 * (1 + Math.Sin(v)) + 2 * (1 - Math.Cos(v) / 2) * Math.Cos(u)) * Math.Cos(v);
y = (-2 * (1 - Math.Cos(v) / 2) * Math.Sin(u));
z = (4 + 2 * (1 - Math.Cos(v) / 2) * Math.Cos(u)) * Math.Sin(v);
z = -z;
            }


            // 03. 07a-b TestKleinBottle2
            else if (Function3D == "_PARAMETRIC_KLEINBOTTLE2")
            {
                // See also: https://mathworld.wolfram.com/KleinBottle.html
var sinV = Math.Sin(v);
var cosV = Math.Cos(v);
var sinU = Math.Sin(u);
var cosU = Math.Cos(u);
var cosU2 = cosU * cosU;
var cosU3 = cosU2 * cosU;
var cosU4 = cosU3 * cosU;
var cosU5 = cosU4 * cosU;
var cosU6 = cosU5 * cosU;
var cosU7 = cosU6 * cosU;

x = -2.0 / 15 * cosU * (3 * cosV - 30 * sinU + 90 * cosU4 * sinU -
    60 * cosU6 * sinU + 5 * cosU * cosV * sinU);
y = -1.0 / 15 * sinU * (3 * cosV - 3 * cosU2 * cosV -
    48 * cosU4 * cosV + 48 * cosU6 * cosV -
    60 * sinU + 5 * cosU * cosV * sinU - 5 * cosU3 * cosV * sinU -
    80 * cosU5 * cosV * sinU + 80 * cosU7 * cosV * sinU);
z = 2.0 / 15 * (3 + 5 * cosU * sinU) * sinV;

// Note: Move y up a bit and invert.
// Invert x to orient the "outer" parts of the bottle outwardly.
// If you don't use a BackMaterial, then parts inside the opening are culled.
var a = 1.5;
x = a * (-x);
y = a * (2 - y);
z = a * (z);
z = -z;
            }


            // 03. 08a-b TestKleinBottle3
            else if (Function3D == "_PARAMETRIC_KLEINBOTTLE3")
            {
                //          http://www.mapleprimes.com/maplesoftblog/95570-Klein-Bottle-Plot
                //          http://www.chebfun.org/examples/geom/ParametricSurfaces.html
                // See also: https://mathworld.wolfram.com/KleinBottle.html
var a = Math.Cos(u);
var b = Math.Sin(u);
var c = Math.Cos(v);
var a2 = a * a;
var a4 = a2 * a2;

x = -(2.0 / 15.0) * a * (3 * c + b * (-30 + a4 * (90 - 60 * a2) + 5 * a * c));
z = -(1.0 / 15.0) * b * b * (c * b * (3 - 48 * a4 + 5 * a * b * (1 - 16 * a4)) - 60);
y = -(2.0 / 15.0) * (3 + 5 * a * b) * Math.Sin(v);
z = -z;
            }





            // 03. 09a-b TestBoySurface
            else if (Function3D == "_PARAMETRIC_BOY")
            {
                // See also: http://jalape.no/math/boytxt.htm
                // See also: https://virtualmathmuseum.org/Surface/boys_apery/boys_apery.html

                // For the basics, see:
                //      https://en.wikipedia.org/wiki/Boy%27s_surface
                //      http://mathworld.wolfram.com/BoySurface.html
                // Here 0 <= i <= 1, 0 <= v <= 2*pi. This is stated at:
                //      https://mathcurve.com/surfaces/boy/boy.shtml
                // The real number is w = u*e^(iv). To see how to solve that, see:
                //      https://mathcurve.com/surfaces/boy/boy.shtml

var sqrt5 = Math.Sqrt(5);
var wr = Math.Cos(v);
var wi = Math.Sin(v);
Complex w = u * new Complex(wr, wi);
Complex w3 = w * w * w;
Complex w4 = w3 * w;
Complex w6 = w3 * w3;

Complex d = w6 + sqrt5 * w3 - 1;
Complex wa = w * (1 - w4) / d;
Complex wb = w * (1 + w4) / d;
Complex wc = (1 + w6) / d;

var g1 = -1.5 * wa.Imaginary;
var g2 = -1.5 * wb.Real;
var g3 = wc.Imaginary - 0.5;
var l2 = g1 * g1 + g2 * g2 + g3 * g3;

x = g1 / l2;
y = -g2 / l2;
z = g3 / l2;
z = -z;
            }

            // 03. 10a-b TestBoySurface
            else if (Function3D == "_PARAMETRIC_BOY2")
            {
                // See also: http://mathworld.wolfram.com/BoySurface.html
                // See Krivoshapko, p. 424
var sqrt2 = Math.Sqrt(2);

var cu = Math.Cos(u);
var cv = Math.Cos(v);
var cv2 = cv * cv;
var s2v = Math.Sin(2 * v);
var d = 2 - sqrt2 * Math.Sin(3 * u) * s2v;

var xn = sqrt2 * cv2 * Math.Cos(2 * u) + cu * s2v;
var yn = sqrt2 * cv2 * Math.Sin(2 * u) - Math.Sin(u) * s2v;
var zn = 3 * cv2;

x = xn / d;
y = yn / d;
z = zn / d;
            }





            // 03. 11a-b Morin
            else if (Function3D == "_PARAMETRIC_Morin_k1.0n3")
            {
                // See also: http://www.3d-meier.de/tut3/Seite221.html  // Morin Surface
                // See also: https://mathcurve.com/surfaces.gb/morin/morin.shtml
                // See also: https://en.wikipedia.org/wiki/Morin_surface
                // See also: Bednorz 2019
var k = 1.0;
var n = 3.0;

var Sqrt2 = Math.Sqrt(2);
var cu = Math.Cos(u);
var su = Math.Sin(u);
var K = cu / (Sqrt2 - k * Math.Sin(2 * u) * Math.Sin(n * v));

x = K * (2 / (n - 1) * cu * Math.Cos((n - 1) * v) + Sqrt2 * su * Math.Cos(v));
y = K * (2 / (n - 1) * cu * Math.Sin((n - 1) * v) - Sqrt2 * su * Math.Sin(v));
z = K * cu;

            }

            // 03. 11c-d Morin
            else if (Function3D == "_PARAMETRIC_Morin_k0.6n3")
            {
                // See also: http://www.3d-meier.de/tut3/Seite221.html  // Morin Surface
                // See also: https://mathcurve.com/surfaces.gb/morin/morin.shtml
                // See also: https://en.wikipedia.org/wiki/Morin_surface
                // See also: Bednorz 2019

var k = 0.6;
var n = 3.0;

var Sqrt2 = Math.Sqrt(2);
var cu = Math.Cos(u);
var su = Math.Sin(u);
var K = cu / (Sqrt2 - k * Math.Sin(2 * u) * Math.Sin(n * v));

x = K * (2 / (n - 1) * cu * Math.Cos((n - 1) * v) + Sqrt2 * su * Math.Cos(v));
y = K * (2 / (n - 1) * cu * Math.Sin((n - 1) * v) - Sqrt2 * su * Math.Sin(v));
z = K * cu;

            }

            // 03. 11e-f Morin
            else if (Function3D == "_PARAMETRIC_Morin_k1.25n3")
            {
                // See also: http://www.3d-meier.de/tut3/Seite221.html  // Morin Surface
                // See also: https://mathcurve.com/surfaces.gb/morin/morin.shtml
                // See also: https://en.wikipedia.org/wiki/Morin_surface
                // See also: Bednorz 2019

var k = 1.25;
var n = 3.0;

var Sqrt2 = Math.Sqrt(2);
var cu = Math.Cos(u);
var su = Math.Sin(u);
var K = cu / (Sqrt2 - k * Math.Sin(2 * u) * Math.Sin(n * v));

x = K * (2 / (n - 1) * cu * Math.Cos((n - 1) * v) + Sqrt2 * su * Math.Cos(v));
y = K * (2 / (n - 1) * cu * Math.Sin((n - 1) * v) - Sqrt2 * su * Math.Sin(v));
z = K * cu;

            }



            // 03. 12a-b Morin
            else if (Function3D == "_PARAMETRIC_Morin_k1.00n5")
            {
                // See also: http://www.3d-meier.de/tut3/Seite221.html  // Morin Surface
                // See also: https://mathcurve.com/surfaces.gb/morin/morin.shtml
                // See also: https://en.wikipedia.org/wiki/Morin_surface
                // See also: Bednorz 2019
var k = 1.0;
var n = 5.0;

var Sqrt2 = Math.Sqrt(2);
var cu = Math.Cos(u);
var su = Math.Sin(u);
var K = cu / (Sqrt2 - k * Math.Sin(2 * u) * Math.Sin(n * v));

x = K * (2 / (n - 1) * cu * Math.Cos((n - 1) * v) + Sqrt2 * su * Math.Cos(v));
y = K * (2 / (n - 1) * cu * Math.Sin((n - 1) * v) - Sqrt2 * su * Math.Sin(v));
z = K * cu;

            }


            // 03. 12c-d Morin
            else if (Function3D == "_PARAMETRIC_Morin_k0.75n5")
            {
                // See also: http://www.3d-meier.de/tut3/Seite221.html  // Morin Surface
                // See also: https://mathcurve.com/surfaces.gb/morin/morin.shtml
                // See also: https://en.wikipedia.org/wiki/Morin_surface
                // See also: Bednorz 2019
var k = 0.2;
var n = 5.0;

var Sqrt2 = Math.Sqrt(2);
var cu = Math.Cos(u);
var su = Math.Sin(u);
var K = cu / (Sqrt2 - k * Math.Sin(2 * u) * Math.Sin(n * v));

x = K * (2 / (n - 1) * cu * Math.Cos((n - 1) * v) + Sqrt2 * su * Math.Cos(v));
y = K * (2 / (n - 1) * cu * Math.Sin((n - 1) * v) - Sqrt2 * su * Math.Sin(v));
z = K * cu;

            }


            // 03. 12e-f Morin
            else if (Function3D == "_PARAMETRIC_Morin_k1.25n5")
            {
                // See also: http://www.3d-meier.de/tut3/Seite221.html  // Morin Surface
                // See also: https://mathcurve.com/surfaces.gb/morin/morin.shtml
                // See also: https://en.wikipedia.org/wiki/Morin_surface
                // See also: Bednorz 2019
var k = 1.2;
var n = 5.0;

var Sqrt2 = Math.Sqrt(2);
var cu = Math.Cos(u);
var su = Math.Sin(u);
var K = cu / (Sqrt2 - k * Math.Sin(2 * u) * Math.Sin(n * v));

x = K * (2 / (n - 1) * cu * Math.Cos((n - 1) * v) + Sqrt2 * su * Math.Cos(v));
y = K * (2 / (n - 1) * cu * Math.Sin((n - 1) * v) - Sqrt2 * su * Math.Sin(v));
z = K * cu;

            }




            // 03. 13a-b Morin
            else if (Function3D == "_PARAMETRIC_Morin_k1.00n9")
            {
                // See also: http://www.3d-meier.de/tut3/Seite221.html  // Morin Surface
                // See also: https://mathcurve.com/surfaces.gb/morin/morin.shtml
                // See also: https://en.wikipedia.org/wiki/Morin_surface
                // See also: Bednorz 2019
var k = 1.0;
var n = 9.0;

var Sqrt2 = Math.Sqrt(2);
var cu = Math.Cos(u);
var su = Math.Sin(u);
var K = cu / (Sqrt2 - k * Math.Sin(2 * u) * Math.Sin(n * v));

x = K * (2 / (n - 1) * cu * Math.Cos((n - 1) * v) + Sqrt2 * su * Math.Cos(v));
y = K * (2 / (n - 1) * cu * Math.Sin((n - 1) * v) - Sqrt2 * su * Math.Sin(v));
z = K * cu;

            }


            // 03. 12c-d Morin
            else if (Function3D == "_PARAMETRIC_Morin_k0.75n9")
            {
                // See also: http://www.3d-meier.de/tut3/Seite221.html  // Morin Surface
                // See also: https://mathcurve.com/surfaces.gb/morin/morin.shtml
                // See also: https://en.wikipedia.org/wiki/Morin_surface
                // See also: Bednorz 2019
var k = 0.2;
var n = 9.0;

var Sqrt2 = Math.Sqrt(2);
var cu = Math.Cos(u);
var su = Math.Sin(u);
var K = cu / (Sqrt2 - k * Math.Sin(2 * u) * Math.Sin(n * v));

x = K * (2 / (n - 1) * cu * Math.Cos((n - 1) * v) + Sqrt2 * su * Math.Cos(v));
y = K * (2 / (n - 1) * cu * Math.Sin((n - 1) * v) - Sqrt2 * su * Math.Sin(v));
z = K * cu;

            }


            // 03. 12e-f Morin
            else if (Function3D == "_PARAMETRIC_Morin_k1.25n9")
            {
                // See also: http://www.3d-meier.de/tut3/Seite221.html  // Morin Surface
                // See also: https://mathcurve.com/surfaces.gb/morin/morin.shtml
                // See also: https://en.wikipedia.org/wiki/Morin_surface
                // See also: Bednorz 2019
var k = 1.2;
var n = 9.0;

var Sqrt2 = Math.Sqrt(2);
var cu = Math.Cos(u);
var su = Math.Sin(u);
var K = cu / (Sqrt2 - k * Math.Sin(2 * u) * Math.Sin(n * v));

x = K * (2 / (n - 1) * cu * Math.Cos((n - 1) * v) + Sqrt2 * su * Math.Cos(v));
y = K * (2 / (n - 1) * cu * Math.Sin((n - 1) * v) - Sqrt2 * su * Math.Sin(v));
z = K * cu;
            }













            // 04. 01a-b TestBourkeSeaShell
            else if (Function3D == "_PARAMETRIC_BOURNE_SEASHELL")
            {
                // See : http://paulbourke.net/geometry/spiral/

var n = 3;  // number of spirals
var a = 1;  // final shell radius
var b = 2;  // height
var c = 0.4;  // inner radius

var s = v;
var t = u;
var pt = t / (2 * Math.PI);  // inner radius

x = a * (1 - pt) * Math.Cos(n * t) * (1 + Math.Cos(s)) + c * Math.Cos(n * t);
z = a * (1 - pt) * Math.Sin(n * t) * (1 + Math.Cos(s)) + c * Math.Sin(n * t);
y = b * pt + a * (1 - pt) * Math.Sin(s);
z = -z;
            }


            // 04. 02a-b TestSeashell
            else if (Function3D == "_PARAMETRIC_SEASHELL")
            {
                // See also: https://mathworld.wolfram.com/Seashell.html
var a = Math.Exp(u / (6.0 * Math.PI));
var b = Math.Cos(v / 2.0);

x = 2.0 * (1.0 - a) * Math.Cos(u) * b * b;
y = 2.0 * (-1.0 + a) * Math.Sin(u) * b * b;
z = (1.0 - a * a - Math.Sin(v) * (1.0 - a));
z = -z;
            }


            // 04. 03a-b TestApple
            else if (Function3D == "_PARAMETRIC_APPLE")
            {
                // See : http://www.3d-meier.de/tut3/Seite100.html

var R1 = 5.0;
var R2 = 4.8;
var su = Math.Sin(u);
var sv = Math.Sin(v);
var cu = Math.Cos(u);
var c5u = Math.Cos(5 * u);
var cv = Math.Cos(v);
x = cu * (R1 + R2 * cv) + Math.Pow(v / Math.PI, 20);
z = su * (R1 + R2 * cv) + 0.25 * c5u;
y = -2.3 * Math.Log(1 - v * 0.3157) + 6 * sv + 2 * cv;
z = -z;
            }


            // 04. 04a-b TestBowCurve
            else if (Function3D == "_PARAMETRIC_BOWCURVE")
            {
                // See : http://paulbourke.net/geometry/toroidal/
var p2 = 2 * Math.PI;
var p4 = 4 * Math.PI;
var T = 0.5; //Thickness

x = (2 + T * Math.Sin(p2 * u)) * Math.Sin(p4 * v);
y = (2 + T * Math.Sin(p2 * u)) * Math.Cos(p4 * v);
z = T * Math.Cos(p2 * u) + 3 * Math.Cos(p2 * v);
z = -z;
            }


            // 04. 05a-b TestFish
            else if (Function3D == "_PARAMETRIC_FISH")
            {
                // See : http://www.3d-meier.de/tut3/Seite47.html

var su = Math.Sin(u);
var s2u = Math.Sin(2 * u);
var sv = Math.Sin(v);
var cu = Math.Cos(u);
var c2u = Math.Cos(2 * u);
var cv = Math.Cos(v);

x = (cu - c2u) * cv / 4.0;
y = (su - s2u) * sv / 4.0;
z = cu;
            }


            // 04. 06a-b TestBourkeHorn
            else if (Function3D == "_PARAMETRIC_BOURNE_HORN")
            {
                // See : http://paulbourke.net/geometry/spiral/
var p2 = 2 * Math.PI;
x = (2 + u * Math.Cos(v)) * Math.Sin(p2 * u);
y = (2 + u * Math.Cos(v)) * Math.Cos(p2 * u) + 2 * u;
z = u * Math.Sin(v);
z = -z;
            }


            // 04. 07a-b TestHexaTorus
            else if (Function3D == "_PARAMETRIC_HEXATORUS")
            {
                // See : http://paulbourke.net/geometry/toroidal/
var s = Math.Sqrt(2);
var p = 2 * Math.PI / 3;

x = Math.Sin(u) / (s + Math.Cos(v));
y = Math.Sin(u + p) / (s + Math.Cos(v + p));
z = Math.Cos(u - p) / (s + Math.Cos(v - p));
            }


            // 04.08a-b TestBreather
            if (Function3D == "_PARAMETRIC_BREATHER")
            {
var b = 0.4;
var r = 1 - b * b;
var w = Math.Sqrt(r);
var denom = b * (
    (w * Math.Cosh(b * u)) * (w * Math.Cosh(b * u)) +
    (b * Math.Sin(w * v)) * (b * Math.Sin(w * v)));

x = -u + (2 * r * Math.Cosh(b * u) * Math.Sinh(b * u)) / denom;
y = (2 * w * Math.Cosh(b * u) * (-(w * Math.Cos(v) * Math.Cos(w * v)) - Math.Sin(v) * Math.Sin(w * v))) / denom;
z = (2 * w * Math.Cosh(b * u) * (-(w * Math.Sin(v) * Math.Cos(w * v)) + Math.Cos(v) * Math.Sin(w * v))) / denom;
z = -z;
            }


            // 04. 09a-b TestKuen
            else if (Function3D == "_PARAMETRIC_KUEN")
            {
var a = 1.0 * Math.Sin(v);
var b = 1.0 + u * u * a * a;

x = 2.0 * a * (Math.Cos(u) + u * Math.Sin(u)) / b;
z = 2.0 * a * (Math.Sin(u) - u * Math.Cos(u)) / b;
y = Math.Log(Math.Tan(v / 2.0)) + 2.0 * Math.Cos(v) / b;
z = -z;
            }


            // 04. 10a-b TestTranguloidTrefoil
            else if (Function3D == "_PARAMETRIC_TRANGULOID_TREFOIL")
            {
                // See : http://paulbourke.net/geometry/tranguloid/
var p2 = 2 * Math.PI / 3;
x = 2 * Math.Sin(3 * u) / (2 + Math.Cos(v));
y = 2 * (Math.Sin(u) + 2 * Math.Sin(2 * u)) / (2 + Math.Cos(v + p2));
z = (Math.Cos(u) - 2 * Math.Cos(2 * u)) * (2 + Math.Cos(v)) * (2 + Math.Cos(v + p2)) / 4;
            }


            // 04. 11a-b TestTeardrop
            else if (Function3D == "_PARAMETRIC_TRIAXIAL_TEARDROP")
            {
                // See : http://paulbourke.net/geometry/triaxtear/
var p2 = 2 * Math.PI / 3;
x = (1 - Math.Cos(u)) * Math.Cos(u + p2) * Math.Cos(v + p2) / 2;
y = -(1 - Math.Cos(u)) * Math.Cos(u + p2) * Math.Cos(v - p2) / 2;
z = Math.Cos(u - p2);
z = -z;
            }


            // 04. 12a-b TestGrayBottle
            else if (Function3D == "_PARAMETRIC_GRAYBOTTLE")
            {
                // See : http://paulbourke.net/geometry/toroidal/
var a = 2;
var n = 2;
var m = 1;

x = (a + Math.Cos(n * u / 2.0) * Math.Sin(v) - Math.Sin(n * u / 2.0) * Math.Sin(2 * v)) * Math.Cos(m * u / 2.0);
y = (a + Math.Cos(n * u / 2.0) * Math.Sin(v) - Math.Sin(n * u / 2.0) * Math.Sin(2 * v)) * Math.Sin(m * u / 2.0);
z = Math.Sin(n * u / 2.0) * Math.Sin(v) + Math.Cos(n * u / 2.0) * Math.Sin(2 * v);
            }







            // 04. 21a-b TestSnail1
            else if (Function3D == "_PARAMETRIC_SNAIL1")
            {
                // See : http://www.3d-meier.de/tut3/Seite89.html
var R = 1;
var a = 1.6;
var b = 1.6;
var c = 1.0;
var h = 1.5;
var k = -7.0;
var w = 0.075;
//  umin = -50, umax = -1,    name:  Pseudoheliceras subcatenatum

var su = Math.Sin(u);
var scu = Math.Sin(c * u);
var sv = Math.Sin(v);
var cv = Math.Cos(v);
var ccu = Math.Cos(c * u);

var ewu = Math.Exp(w * u);

x = ewu * (h + a * cv) * ccu;
z = R * ewu * (h + a * cv) * scu;
y = ewu * (k + b * sv);
z = -z;
            }


            // 04. 22a-b TestSnail2
            else if (Function3D == "_PARAMETRIC_SNAIL2")
            {
                // See : http://www.3d-meier.de/tut3/Seite90.html
var R = 1;
var a = 1.25;
var b = 1.25;
var c = 1.0;
var h = 3.5;
var k = 0.0;
var w = 0.12;
//  umin = -40, umax = -1,    name: Astroceras

var su = Math.Sin(u);
var scu = Math.Sin(c * u);
var sv = Math.Sin(v);
var cv = Math.Cos(v);
var ccu = Math.Cos(c * u);

var ewu = Math.Exp(w * u);

x = ewu * (h + a * cv) * ccu;
y = -R * ewu * (h + a * cv) * scu;
z = ewu * (k + b * sv);
z = -z;
            }


            // 04. 23a-b TestSnail3
            else if (Function3D == "_PARAMETRIC_SNAIL3")
            {
                // See : http://www.3d-meier.de/tut3/Seite91.html
var R = 1;
var a = 0.85;
var b = 1.2;
var c = 1.0;
var h = 0.75;
var k = 0.0;
var w = 0.06;
//  umin = -10, umax = -1,    name: Bellerophina

var su = Math.Sin(u);
var scu = Math.Sin(c * u);
var sv = Math.Sin(v);
var cv = Math.Cos(v);
var ccu = Math.Cos(c * u);

var ewu = Math.Exp(w * u);

x = ewu * (h + a * cv) * ccu;
z = R * ewu * (h + a * cv) * scu;
y = ewu * (k + b * sv);
z = -z;
            }


            // 04. 24a-b TestSnail4
            else if (Function3D == "_PARAMETRIC_SNAIL4")
            {
                // See : http://www.3d-meier.de/tut3/Seite92.html
var R = 1;
var a = 0.6;
var b = 0.4;
var c = 1.0;
var h = 0.9;
var k = 0.0;
var w = 0.1626;
//  umin = -40, umax = -1,    name: Euhoplites

var su = Math.Sin(u);
var scu = Math.Sin(c * u);
var sv = Math.Sin(v);
var cv = Math.Cos(v);
var ccu = Math.Cos(c * u);

var ewu = Math.Exp(w * u);

x = ewu * (h + a * cv) * ccu;
z = R * ewu * (h + a * cv) * scu;
y = ewu * (k + b * sv);
z = -z;
            }


            // 04. 25a-b TestSnail5
            else if (Function3D == "_PARAMETRIC_SNAIL5")
            {
                // See : http://www.3d-meier.de/tut3/Seite93.html
var R = 1;
var a = 1.0;
var b = 0.6;
var c = 1.0;
var h = 1.0;
var k = 0.0;
var w = 0.18;
//  umin = -20, umax = +1,    name: Nautilus

var su = Math.Sin(u);
var scu = Math.Sin(c * u);
var sv = Math.Sin(v);
var cv = Math.Cos(v);
var ccu = Math.Cos(c * u);

var ewu = Math.Exp(w * u);

x = ewu * (h + a * cv) * ccu;
z = R * ewu * (h + a * cv) * scu;
y = ewu * (k + b * sv);
z = -z;
            }


            // 04. 26a-b TestSnail6
            else if (Function3D == "_PARAMETRIC_SNAIL6")
            {
                // See : http://www.3d-meier.de/tut3/Seite94.html
var R = 1;
var a = 2.6;
var b = 2.4;
var c = 1.0;
var h = 1.25;
var k = -2.8;
var w = 0.18;
//  umin = -20, umax = +1,    name: Natica stellata

var su = Math.Sin(u);
var scu = Math.Sin(c * u);
var sv = Math.Sin(v);
var cv = Math.Cos(v);
var ccu = Math.Cos(c * u);

var ewu = Math.Exp(w * u);

x = ewu * (h + a * cv) * ccu;
z = R * ewu * (h + a * cv) * scu;
y = ewu * (k + b * sv);
z = -z;
            }


            // 04. 27a-b TestSnail7
            else if (Function3D == "_PARAMETRIC_SNAIL7")
            {
                // See : http://www.3d-meier.de/tut3/Seite95.html
var R = 1;
var a = 0.85;
var b = 1.6;
var c = 3.0;
var h = 0.9;
var k = 0;
var w = 2.5;
//  umin = -1, umax = 0.52,    name: Mya arenaria

var su = Math.Sin(u);
var scu = Math.Sin(c * u);
var sv = Math.Sin(v);
var cv = Math.Cos(v);
var ccu = Math.Cos(c * u);

var ewu = Math.Exp(w * u);

x = ewu * (h + a * cv) * ccu;
z = R * ewu * (h + a * cv) * scu;
y = ewu * (k + b * sv);
z = -z;
            }






            // 05. 01a-b TestLemnescate
            else if (Function3D == "_PARAMETRIC_LEMNESCATE")
            {
                // See : http://paulbourke.net/geometry/lemniscape/
x = Math.Cos(v) * Math.Sqrt(Math.Abs(Math.Sin(2 * u))) * Math.Cos(u);
y = Math.Cos(v) * Math.Sqrt(Math.Abs(Math.Sin(2 * u))) * Math.Sin(u);
z = x * x - y * y + 2 * x * y * Math.Tan(v) * Math.Tan(v);
            }


            // 05. 02a-b TestTwister
            else if (Function3D == "_PARAMETRIC_TWISTER")
            {
var r2 = (u * u + v * v) / 4;
var r = Math.Sqrt(r2);
y = 2 - 1 / (r2 + 0.0001);
x = u * Math.Cos(r) - v * Math.Sin(r);
z = u * Math.Sin(r) + v * Math.Cos(r);
if (y < -2) y = -4;
            }


            // 05. 03a-b TestBohemianDome
            else if (Function3D == "_PARAMETRIC_BOHEMIANDOME")
            {
                // See : https://mathworld.wolfram.com/BohemianDome.html
var a = 0.5;
var b = 1.5;
var c = 1;
var su = Math.Sin(u);
var sv = Math.Sin(v);
var cu = Math.Cos(u);
var cv = Math.Cos(v);

x = a * cu;
z = b * cv + a * su;
y = c * sv;
            }







            /* ********************************  OLD  ******************************** */




            // 06. 01b TestSphere
            else if (Function3D == "_PARAMETRIC_SPHERE")
            {
x = Math.Cos(u) * Math.Cos(v);
z = Math.Cos(u) * Math.Sin(v);
y = -Math.Sin(u);
            }


            // 06. 01c TestROT4_Sphere
            else if (Function3D == "_PARAMETRIC_ROT4")
            {
                // See : https://mathworld.wolfram.com/Sphere.html, Sphere

var r = 1.0;  // u from 0 to 1

var fu = Math.Sqrt(r * r - u * u);
var gu = u;

x = fu * Math.Sin(v);
z = -fu * Math.Cos(v);
y = -gu;
z = -z;
            }



            // 06. 04x TestProlateSpheroid
            else if (Function3D == "_PARAMETRIC_PROLATESPHEROID")
            {
                // See : http://paulbourke.net/geometry/spherical/   prolate spheroid, or ellipsoid of revolution
                // See : https://en.wikipedia.org/wiki/Ellipsoid#Parameterization  ellipsoid of revolution
                // See : https://mathworld.wolfram.com/OblateSpheroid.html  Oblate Spheroid


var a = 1;
var b = 1.0;
var c = 3.0;
x = a * Math.Cos(u) * Math.Cos(v);
z = b * Math.Cos(u) * Math.Sin(v);
y = c * Math.Sin(u);
y = -y;
            }


            // 06. 15b TestROT3_Egg
            else if (Function3D == "_PARAMETRIC_ROT3")
            {
                // See : http://www.3d-meier.de/tut3/Seite87.html, // Egg

var a = 1.0;  // a<=b
var b = 1.4;
var c = 1.3;

var fu = c * Math.Sqrt(u * (u - a) * (u - b));
var gu = u;

x = fu * Math.Sin(v);
y = -fu * Math.Cos(v);
z = gu;
z = -z;
            }



            // 06. 06b TestPseudosphere
            else if (Function3D == "_PARAMETRIC_PSEUDOSPHERE")
            {
                // See : https://mathworld.wolfram.com/Pseudosphere.html
x = Math.Cos(u) * Math.Sin(v);
y = -Math.Sin(u) * Math.Sin(v);
z = Math.Cos(v) + Math.Log(Math.Tan(0.5 * v));
z = -z;
            }



            // 06. 07x TestTorus
            else if (Function3D == "_PARAMETRIC_TORUS")
            {
var r0 = 1;
var r1 = 0.3;
x = Math.Cos(u) * (r0 + r1 * Math.Cos(v));
y = Math.Sin(u) * (r0 + r1 * Math.Cos(v));
z = r1 * Math.Sin(v);
            }



            // 06. 08b TestEllipticTorus
            else if (Function3D == "_PARAMETRIC_ELLIPTICTORUS")
            {
                // See : https://mathworld.wolfram.com/EllipticTorus.html
var a = 0.2;
var b = 0.5;
var c = 1;
var su = Math.Sin(u);
var sv = Math.Sin(v);
var cu = Math.Cos(u);
var cv = Math.Cos(v);

x = (c + a * cv) * cu;
y = -(c + a * cv) * su;
z = b * sv;
z = -z;
            }



            // 06. 09a TestCardioidTorus
            else if (Function3D == "_PARAMETRIC_CARDOIDTORUS")
            {
                // See : http://www.3d-meier.de/tut3/Seite165.html
var R = 1.5;
var r = 0.275;

var su = Math.Sin(u);
var sv = Math.Sin(v);
var s2v = Math.Sin(2 * v);
var cu = Math.Cos(u);
var cv = Math.Cos(v);
var c2v = Math.Cos(2 * v);

x = (R + r * (2 * cv - c2v)) * cu;
y = r * (2 * sv - s2v);
z = (R + r * (2 * cv - c2v)) * su;
z = -z;
            }



            // 06. 11b TestEightSurface
            else if (Function3D == "_PARAMETRIC_EIGHTSURFACE")
            {
                // See : https://mathworld.wolfram.com/EightSurface.html
var su = Math.Sin(u);
var sv = Math.Sin(v);
var s2v = Math.Sin(2 * v);
var cu = Math.Cos(u);

x = cu * s2v;
y = -su * s2v;
z = sv;
z = -z;
            }



            /* ************************************************************************************ */





            // 06. 01b TestROT0_Cylinder
            else if (Function3D == "_PARAMETRIC_ROT0")
            {
                // See : http://www.3d-meier.de/tut3/Seite84.html, Zylinder
                // See : https://mathworld.wolfram.com/Cylinder.html, Zylinder

var fu = 2;
var gu = u;

x = fu * Math.Sin(v);
y = -fu * Math.Cos(v);
z = gu;
            }




            // 06. 02b TestROT1_Cone
            else if (Function3D == "_PARAMETRIC_ROT1")
            {
                // See : http://www.3d-meier.de/tut3/Seite85.html , Kegel

var a = 1;

var fu = a * u;
var gu = u;

x = fu * Math.Sin(v);
y = -fu * Math.Cos(v);
z = gu;
z = -z;
            }


            // 06. 03b TestROT2_Insolator
            else if (Function3D == "_PARAMETRIC_ROT2")
            {
                // See : http://www.3d-meier.de/tut3/Seite86.html, Isolator
var a = 2.5;
var b = 0.9;
var c = 1.1;  // controls number of turns

var fu = a + b * Math.Sin(c * u * 2 * Math.PI);
var gu = u;

x = fu * Math.Sin(v);
y = -fu * Math.Cos(v);
z = gu;
z = -z;
            }


            // 06. 04b TestGabrielHorn
            else if (Function3D == "_PARAMETRIC_GABRIELHORN")
            {
                // See : https://mathworld.wolfram.com/GabrielsHorn.html
var a = 1;
x = u;
y = a * Math.Cos(v) / u;
z = a * Math.Sin(v) / u;
z = -z;
            }


            // 06. 05b TestFunnel
            else if (Function3D == "_PARAMETRIC_FUNNEL")
            {
                // See : https://mathworld.wolfram.com/Funnel.html
var a = 1;
x = u * Math.Cos(v);
y = u * Math.Sin(v);
z = a * Math.Log(u);
            }


            // 06. 06b TestHyperboloid1
            else if (Function3D == "_PARAMETRIC_HYPERBOLOID1")
            {
                // See : https://mathworld.wolfram.com/One-SheetedHyperboloid.html
                // See : https://en.wikipedia.org/wiki/Hyperboloid
var a = 1;
var c = 1;
var b = Math.Sqrt(1 + u * u);
x = a * b * Math.Cos(v);
y = a * b * Math.Sin(v); ;
z = c * u;
z = -z;
            }



            // 06. 07b TestCatenoid
            else if (Function3D == "_PARAMETRIC_CATENOID")
            {
                // See : https://mathworld.wolfram.com/Catenoid.html
                // See : https://archive.lib.msu.edu/crcmath/math/math/c/c111.htm
                // See : https://archive.lib.msu.edu/crcmath/math/math/c/c107.htm

var c = 2;
x = c * Math.Cosh(v / c) * Math.Cos(u);
y = -c * Math.Cosh(v / c) * Math.Sin(u);
z = v;
            }


            // 06. 08b TestGCylinder
            else if (Function3D == "_PARAMETRIC_GZYLINDER")
            {
                // See : http://www.3d-meier.de/tut3/Seite157.html    Gauss Zylinder
                //                var R = 1.5;
                //                var a = 0.2;
                //                var b = 1.275;

var R = -2.5;
var a = 1.0;
var b = 1.275;

var su = Math.Sin(u);
var cu = Math.Cos(u);
var ev = Math.Exp(-a * a * v * v);

x = (R + b * ev) * cu;
y = v;
z = (R + b * ev) * su;
z = -z;
            }



            // 06. 11a-b TestBonbon
            else if (Function3D == "_PARAMETRIC_BONBON")
            {
x = Math.Cos(u) * Math.Sin(v);
y = Math.Cos(u) * Math.Cos(v);
z = u;
            }




            // 06. 07a-b TestShell
            else if (Function3D == "_PARAMETRIC_SHELL")
            {
var sinu2 = Math.Sin(u) * Math.Sin(u);
x = Math.Pow(1.2, v) * (sinu2 * Math.Sin(v));
y = Math.Pow(1.2, v) * (Math.Sin(u) * Math.Cos(u));
z = Math.Pow(1.2, v) * (sinu2 * Math.Cos(v));
            }





            return new Point3D(x, y, z);
        }






        private Complex cplxF(String Function3D, double x, double y)
        {
            Complex cplxResult = new Complex(0.0, 0.0);
            Complex c1 = new Complex(x, y);


            if (Function3D == "_COMPLEX_SQUARE") cplxResult = c1 * c1;
            if (Function3D == "_COMPLEX_CUBE") cplxResult = c1 * c1 * c1;
            if (Function3D == "_COMPLEX_SQRT") cplxResult = cmath53.sqrt(c1);
            if (Function3D == "_COMPLEX_EXP") cplxResult = cmath53.exp(c1);
            if (Function3D == "_COMPLEX_LOG") cplxResult = cmath53.log(c1);
            if (Function3D == "_COMPLEX_LambertW") cplxResult = cmath53.lambert_w0(c1);


            if (Function3D == "_COMPLEX_SIN") cplxResult = cmath53.sin(c1);
            if (Function3D == "_COMPLEX_ASIN") cplxResult = cmath53.asin(c1);
            if (Function3D == "_COMPLEX_COS") cplxResult = cmath53.cos(c1);
            if (Function3D == "_COMPLEX_ACOS") cplxResult = cmath53.acos(c1);
            if (Function3D == "_COMPLEX_TAN") cplxResult = cmath53.tan(c1);
            if (Function3D == "_COMPLEX_ATAN") cplxResult = cmath53.atan(c1);
            if (Function3D == "_COMPLEX_SEC") cplxResult = cmath53.sec(c1);
            if (Function3D == "_COMPLEX_ASEC") cplxResult = cmath53.asec(c1);
            if (Function3D == "_COMPLEX_CSC") cplxResult = cmath53.csc(c1);
            if (Function3D == "_COMPLEX_ACSC") cplxResult = cmath53.acsc(c1);
            if (Function3D == "_COMPLEX_COT") cplxResult = cmath53.cot(c1);
            if (Function3D == "_COMPLEX_ACOT") cplxResult = cmath53.acot(c1);

            //if (Function3D == "_COMPLEX_SinFlint") cplxResult = MathC53Flint.Sin(c1);


            if (Function3D == "_COMPLEX_SINH") cplxResult = cmath53.sinh(c1);
            if (Function3D == "_COMPLEX_ASINH") cplxResult = cmath53.asinh(c1);
            if (Function3D == "_COMPLEX_COSH") cplxResult = cmath53.cosh(c1);
            if (Function3D == "_COMPLEX_ACOSH") cplxResult = cmath53.acosh(c1);
            if (Function3D == "_COMPLEX_TANH") cplxResult = cmath53.tanh(c1);
            if (Function3D == "_COMPLEX_ATANH") cplxResult = cmath53.atanh(c1);
            if (Function3D == "_COMPLEX_SECH") cplxResult = cmath53.sech(c1);
            if (Function3D == "_COMPLEX_ASECH") cplxResult = cmath53.asech(c1);
            if (Function3D == "_COMPLEX_CSCH") cplxResult = cmath53.csch(c1);
            if (Function3D == "_COMPLEX_ACSCH") cplxResult = cmath53.acsch(c1);
            if (Function3D == "_COMPLEX_COTH") cplxResult = cmath53.coth(c1);
            if (Function3D == "_COMPLEX_ACOTH") cplxResult = cmath53.acoth(c1);


            if (Function3D == "_COMPLEX_Agm") cplxResult = cmath53.agm(1, c1);
            if (Function3D == "_COMPLEX_Ellk") cplxResult = cmath53.elliptic_k(c1);
            if (Function3D == "_COMPLEX_Elle") cplxResult = cmath53.elliptic_e(c1);
            if (Function3D == "_COMPLEX_JacobiSN") cplxResult = cmath53.jacobi_sn(c1, 0.8);
            if (Function3D == "_COMPLEX_JacobiCN") cplxResult = cmath53.jacobi_cn(c1, 0.8);
            if (Function3D == "_COMPLEX_JacobiDN") cplxResult = cmath53.jacobi_dn(c1, 0.8);
            if (Function3D == "_COMPLEX_WeierstrassP") cplxResult = cmath53.WeierstrassP(2.2, 3.2, c1);
            if (Function3D == "_COMPLEX_WeierstrassPPrime") cplxResult = cmath53.WeierstrassPPrime(2.2, 3.2, c1);
            if (Function3D == "_COMPLEX_WeierstrassZeta") cplxResult = cmath53.WeierstrassZeta(2.2, 3.2, c1);
            if (Function3D == "_COMPLEX_WeierstrassSigma") cplxResult = cmath53.WeierstrassSigma(2.2, 3.2, c1);


            //if (Function3D == "_COMPLEX_LerchPhiFlint_0") cplxResult = MathC53Flint.LerchPhi(z: c1, s: new Complex(1, 3), a: new Complex(2, -1));
            //if (Function3D == "_COMPLEX_LerchPhiFlint_1") cplxResult = MathC53Flint.LerchPhi(z: c1, s: new Complex(1, -1), a: new Complex(1, 1));
            //if (Function3D == "_COMPLEX_LerchPhiFlint_2") cplxResult = MathC53Flint.LerchPhi(z: new Complex(0, -0.75), s: c1, a: new Complex(1, -0.5));
            //if (Function3D == "_COMPLEX_HurwitzZetaFlint_0") cplxResult = MathC53Flint.HurwitzZeta(s: c1, a: 1.0 / 3.0);
            //if (Function3D == "_COMPLEX_HurwitzZetaFlint_1") cplxResult = MathC53Flint.HurwitzZeta(s: c1, a: 24.0 / 25.0);
            //if (Function3D == "_COMPLEX_HurwitzZetaFlint_2") cplxResult = MathC53Flint.HurwitzZeta(s: new Complex(3, 4), a: c1);
            //if (Function3D == "_COMPLEX_Polygamma") cplxResult = MathC53Flint.Polygamma(1, c1);
            //if (Function3D == "_COMPLEX_Polygamma2") cplxResult = MathC53Flint.Polygamma(2, c1);
            if (Function3D == "_COMPLEX_Psi") cplxResult = cmath53.psi(c1);  // Digamma
            if (Function3D == "_COMPLEX_Polylog") cplxResult = cmath53.polylog(3, c1);
            if (Function3D == "_COMPLEX_Dilog") cplxResult = cmath53.dilog(c1);
            if (Function3D == "_COMPLEX_ClausenSin") cplxResult = cmath53.clausen_sin(3, c1); ;
            if (Function3D == "_COMPLEX_ClausenCos") cplxResult = cmath53.clausen_cos(3, c1);
            if (Function3D == "_COMPLEX_LegendreChi") cplxResult = cmath53.legendre_chi(3, c1);
            if (Function3D == "_COMPLEX_TangentInt") cplxResult = cmath53.inverse_tan_integral(3, c1); ;
            if (Function3D == "_COMPLEX_Zeta") cplxResult = cmath53.zeta(c1);
            if (Function3D == "_COMPLEX_HardyTheta") cplxResult = cmath53.hardy_theta(c1);
            if (Function3D == "_COMPLEX_HardyZ") cplxResult = cmath53.hardy_z(c1);


            if (Function3D == "_COMPLEX_Hypergeom0F1") cplxResult = cmath53.hyperg_0f1(2.2, c1);
            if (Function3D == "_COMPLEX_AiryAi") cplxResult = cmath53.airy_ai(c1);
            if (Function3D == "_COMPLEX_AiryAie") cplxResult = cmath53.airy_ai_scaled(c1);
            if (Function3D == "_COMPLEX_AiryBi") cplxResult = cmath53.airy_bi(c1);
            if (Function3D == "_COMPLEX_AiryBie") cplxResult = cmath53.airy_bi_scaled(c1);
            if (Function3D == "_COMPLEX_BesselJ0") cplxResult = cmath53.bessel_jv(0, c1);
            if (Function3D == "_COMPLEX_BesselJ0e") cplxResult = cmath53.bessel_jv_scaled(0, c1);
            if (Function3D == "_COMPLEX_BesselY0") cplxResult = cmath53.bessel_yv(0, c1);
            if (Function3D == "_COMPLEX_BesselY0e") cplxResult = cmath53.bessel_yv_scaled(0, c1);
            if (Function3D == "_COMPLEX_BesselI0") cplxResult = cmath53.bessel_iv(0, c1);
            if (Function3D == "_COMPLEX_BesselI0e") cplxResult = cmath53.bessel_iv_scaled(0, c1);
            if (Function3D == "_COMPLEX_BesselK0") cplxResult = cmath53.bessel_kv(0, c1);
            if (Function3D == "_COMPLEX_BesselK0e") cplxResult = cmath53.bessel_kv_scaled(0, c1);




            if (Function3D == "_COMPLEX_Hypergeom1F1") cplxResult = cmath53.hyperg_1f1(1.1, 2.2, c1);
            if (Function3D == "_COMPLEX_HypergeomU") cplxResult = cmath53.hyperg_u(1.1, 2.2, c1);
            if (Function3D == "_COMPLEX_Gamma") cplxResult = cmath53.gamma(c1);
            if (Function3D == "_COMPLEX_RGamma") cplxResult = cmath53.rgamma(c1);
            if (Function3D == "_COMPLEX_LnGamma") cplxResult = cmath53.lgamma(c1);
            if (Function3D == "_COMPLEX_Ei") cplxResult = cmath53.exp_integral_ei(c1);
            if (Function3D == "_COMPLEX_Li") cplxResult = cmath53.log_integral(c1);
            if (Function3D == "_COMPLEX_Erf") cplxResult = cmath53.erf(c1);
            if (Function3D == "_COMPLEX_Erfc") cplxResult = cmath53.erfc(c1);
            if (Function3D == "_COMPLEX_FresnelS") cplxResult = cmath53.fresnel_s(c1);
            if (Function3D == "_COMPLEX_FresnelC") cplxResult = cmath53.fresnel_c(c1);
            if (Function3D == "_COMPLEX_CosIntegral") cplxResult = cmath53.cos_integral(c1);
            if (Function3D == "_COMPLEX_SinIntegral") cplxResult = cmath53.sin_integral(c1);
            if (Function3D == "_COMPLEX_Dawson") cplxResult = cmath53.dawson(c1);
            if (Function3D == "_COMPLEX_FaddeevaW") cplxResult = cmath53.faddeeva(c1);



            if (Function3D == "_COMPLEX_Hypergeom2F1") cplxResult = cmath53.hyperg_2f1(1.1, 2.2, 3.3, c1);



            return cplxResult;
        }





        private double F(String Function3D, double x, double y)
        {


            double z = 0;

            if (Function3D == "HYPERBOLIC_PARABOLID")
            {
                // See : https://mathworld.wolfram.com/HyperbolicParaboloid.html
                var a = 1.0;
                var b = 1.0;
                z = x * x / (b * b) - y * y / (a * a);
            }

            else if (Function3D == "Neovius")
            {
                // See : Krivoshapko (2015), p. 433-434
                // See : http://www.3d-meier.de/tut3/Seite197.html
                z = math53.acos(-3 * (Math.Cos(x) + Math.Cos(y)) / (3 + 4 * Math.Cos(x) * Math.Cos(y)));
            }

            else if (Function3D == "Peninsula")
            {
                // See : Krivoshapko (2015), p. 657
                // See : http://www.3d-meier.de/tut3/Seite213.html    
                var temp = 1.0 - x * x - y * y * y;
                z = math53.sign(temp) * Math.Pow(Math.Abs(temp), 0.2);
            }

            else if (Function3D == "Boat1")
            {
                // See : Krivoshapko (2015), p. 668
                // See : http://www.3d-meier.de/tut3/Seite213.html    
                var B = 1.0;
                var L = 2.0;
                var T = 1.0;
                var temp2 = 3.0 * B * B * (L * L - x * x) / (4 * L * L * T * T * T * T) * ((4.0 / 3.0) * T - y) * (y - T / (L * L) * x * x) * y * y;
                z = -math53.sign(temp2) * Math.Sqrt(Math.Abs(temp2));

            }


            else if (Function3D == "MonkeySaddle")
            {
                // See also: http://www.3d-meier.de/tut3/Seite14.html  // Monkey Saddle
                z = x * x * x - 3 * x * y * y;
            }



            else if (Function3D == "CrossedTrough")
            {
                // See also: http://www.3d-meier.de/tut3/Seite228.html  // Crossed Trough Surface
                z = x * x * y * y;
            }



            else if (Function3D == "SURFACE1")
            {
                var r2 = x * x + y * y;
                z = 8 * Math.Cos(r2 / 2) / (2 + r2);
            }

            else if (Function3D == "SURFACE2")
            {
                var two_pi = 2 * Math.PI;
                var r2 = x * x + y * y;
                var r = Math.Sqrt(r2);
                var theta = Math.Atan2(y, x);
                z = Math.Exp(-r2) * Math.Sin(two_pi * r) * Math.Cos(3 * theta);
            }

            else if (Function3D == "BIVARIATENORMAL")
            {
                var two_pi = 2 * Math.PI;
                var rho = -0.5;
                var r2 = 1.0 - rho * rho;
                var f = 1 / (two_pi * Math.Sqrt(r2));
                var e = -(x * x - 2 * rho * x * y + y * y) / (2 * r2);
                z = f * Math.Exp(e);
            }
            else if (Function3D == "OwenT")
            {
                z = math53.owen_t(h: x, a: y);
            }
            else if (Function3D == "MarcumQ")
            {
                z = math53.marcum_q(m: 1, a: x, b: y);
            }
            else if (Function3D == "JacobiTheta1")
            {
                z = math53.jacobi_theta(n: 1, x: x, q: y);
            }
            else if (Function3D == "JacobiTheta2")
            {
                z = math53.jacobi_theta(n: 2, x: x, q: y);
            }
            else if (Function3D == "JacobiTheta3")
            {
                z = math53.jacobi_theta(n: 3, x: x, q: y);
            }
            else if (Function3D == "JacobiTheta4")
            {
                z = math53.jacobi_theta(n: 4, x: x, q: y);
            }


            //if (Math.Abs(z) > 10)
            //{
            //    z = 4 * math53.Sign(z);
            //}
            return z;
        }





        private void CalculateXYZ(string Function3D)
        {
            double dx = (xmax - xmin) / xResolution;
            double dz = (zmax - zmin) / zResolution;

            if (Function3D.StartsWith("_COMPLEX"))
            {
                for (int ix = 0; ix < xResolution + 1; ix++)
                {
                    double x = xmin + ix * dx;
                    for (int iz = 0; iz < zResolution + 1; iz++)
                    {
                        double z = zmin + iz * dz;
                        Complex cplxTemp = cplxF(Function3D, x, z);
                        yvalues_re[ix, zResolution - iz] = cplxTemp.Real;
                        yvalues_im[ix, zResolution - iz] = cplxTemp.Imaginary;
                    }
                }
            }
            else
            {
                for (int ix = 0; ix < xResolution + 1; ix++)
                {
                    double x = xmin + ix * dx;
                    for (int iz = 0; iz < zResolution + 1; iz++)
                    {
                        double z = zmin + iz * dz;
                        if (Function3D.StartsWith("_PARAMETRIC"))
                        {
                            //IsValid = true;
                            Point3D ParamTemp = ParametricF(Function3D, x, z); // u = x;  v = z;
                            //if (IsValid)
                            {
                                xvalues[ix, zResolution - iz] = ParamTemp.X;
                                zvalues[ix, zResolution - iz] = ParamTemp.Z;
                                yvalues[ix, zResolution - iz] = ParamTemp.Y;
                            }
                        }
                        else
                        {
                            yvalues[ix, zResolution - iz] = F(Function3D, x, z);
                        }
                    }
                }
            }







            if (Function3D.StartsWith("_PARAMETRIC"))
            {
                WriteData(FullWorkPath + "xvalues.bytes", xvalues);
                WriteData(FullWorkPath + "zvalues.bytes", zvalues);
                WriteData(FullWorkPath + "yvalues.bytes", yvalues);
            }
            else
            {
                if (Function3D.StartsWith("_COMPLEX"))
                {
                    WriteData(FullWorkPath + "yvalues_re.bytes", yvalues_re);
                    WriteData(FullWorkPath + "yvalues_im.bytes", yvalues_im);
                }
                else
                {
                    WriteData(FullWorkPath + "yvalues.bytes", yvalues);
                }
            }

        }

        private void WriteData(string FName, double[,] InputDoubles)
        {
            byte[] InputBytes = new byte[InputDoubles.Length * sizeof(double)];
            Buffer.BlockCopy(InputDoubles, 0, InputBytes, 0, InputBytes.Length);
            File.WriteAllBytes(FName, InputBytes);
        }

        private void ReadData(string FName, double[,] ResultDoubles)
        {
            byte[] ResultBytes = File.ReadAllBytes(FName);
            ResultDoubles = new double[xResolution + 1, zResolution + 1];
            Buffer.BlockCopy(ResultBytes, 0, ResultDoubles, 0, ResultBytes.Length);
        }

    }  // class Data3D





    class Program
    {


        // "#BIVARIATENORMAL#128#4#-4#4#-4#"   

        // "#_COMPLEX_LOG#128#6#-6#2.5#-2.5#"        

        // "#_PARAMETRIC_SEASHELL#128#18.9#0#18.9#0#"        

        // "#SURFACE1#128#5#-5#5#-5#"        

        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");


            string FullWorkPath = "";
            string[] CmdArray = args[0].Split('#');

            for (int i = 0; i < CmdArray.Length; i++)
            {
                Console.WriteLine("i: {0}, Cmd: {1}", i, CmdArray[i]);
            }

            String Function3D = CmdArray[1];
            int Resolution = Convert.ToInt32(CmdArray[2]);
            double xmax = Convert.ToDouble(CmdArray[3]);
            double xmin = Convert.ToDouble(CmdArray[4]);
            double zmax = Convert.ToDouble(CmdArray[5]);
            double zmin = Convert.ToDouble(CmdArray[6]);

            FullWorkPath = CmdArray[0] + @"\";

            Data3D Data3D1 = new Data3D(FullWorkPath, Function3D, Resolution, Resolution, xmin, xmax, zmin, zmax);

            //            Console.Write("Press any key to continue . . . ");
            //            Console.ReadKey(true);
        }
    }
}