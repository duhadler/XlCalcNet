/* C# */

#region Usings
using System;
using System.Numerics;
using System.Runtime.InteropServices;
using FixedPrecNet;
#endregion


namespace UserFixedPrecNet
{

    /// <summary>
    /// User defined functions based on the Double data type, using math53
    /// </summary>
    public partial class m53lib
    {

#region General


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/name/*' />
        public static String name
        {
            get { return "m53lib"; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmtname/*' />
        public static String fmtname
        {
            get { return " m53lib"; }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static Int32 prec
        {
            get { return dreal.prec; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static m53lib realctx
        {
            get { return new m53lib(); }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(Double x)
        {
            return math53.fmt(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(dynamic x)
        {
            return math53.fmt(x);
        }




        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Double real(Double x)
        {
            return math53.real(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Double real(dynamic x)
        {
            return real(dreal.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Double imag(Double x)
        {
            return math53.imag(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Double imag(dynamic x)
        {
            return imag(dreal.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Double abs(Double x)
        {
            return math53.abs(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Double abs(dynamic x)
        {
            return abs(dreal.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Double sin(Double x)
        {
            return math53.sin(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Double sin(dynamic x)
        {
            return sin(dreal.t(x));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static Double test_add(Double x, Double y)
        {
            return x + y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static Double test_add(dynamic x, dynamic y)
        {
            return test_add(dreal.t(x), dreal.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static Double test_sub(Double x, Double y)
        {
            return x - y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static Double test_sub(dynamic x, dynamic y)
        {
            return test_sub(dreal.t(x), dreal.t(y));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static Double test_mul(Double x, Double y)
        {
            return x * y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static Double test_mul(dynamic x, dynamic y)
        {
            return test_mul(dreal.t(x), dreal.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static Double test_div(Double x, Double y)
        {
            return x / y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static Double test_div(dynamic x, dynamic y)
        {
            return test_div(dreal.t(x), dreal.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_submul/*' />
        public static Double test_submul(Double x, Double y)
        {
            return x - y + test_mul(x, y);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static Double test_submul(dynamic x, dynamic y)
        {
            return test_submul(dreal.t(x), dreal.t(y));
        }

#endregion



#region TestCdecl From DAMath, Exp Log Pow


        /// <summary>
        /// Returns sqrt(1+x^2)-x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sqrt1pmx", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sqrt1pmx(Double x);



        /// <summary>
        /// Returns the complex principal cube root w = cbrt(z) = z^(1/3)
        /// </summary>
        public static Complex cuberoot(Complex z1)
        {
            return surd(z1, 3);
        }

        /// <summary>
        /// Returns the complex principal cube root w = cbrt(z) = z^(1/3)
        /// </summary>
        public static Complex cuberoot(dynamic z1)
        {
            return cuberoot(dcplx.t(z1));
        }



        /// <summary>
        /// Returns the complex n'th root w = z^(1/n) with arg(w) closest to arg(z)
        /// </summary>
        public static Complex surd(Complex z1, int n)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_csurd(z1.Real, z1.Imaginary, n, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_csurd", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_csurd(Double x_re, Double x_im, int n, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex n'th root w = z^(1/n) with arg(w) closest to arg(z)
        /// </summary>
        public static Complex surd(dynamic z1, int n)
        {
            return surd(dcplx.t(z1), n);
        }





        /// <summary>
        /// Returns the bring radical b := BR(x) with b^5 + b + x = 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bring", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bring(Double x);






        /// <summary>
        /// Returns exp(-0.5*x^2) with damped error amplification
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expmx2h", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expmx2h(Double x);


        /// <summary>
        /// Returns exprel(x) = (exp(x) - 1)/x, 1 for x=0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exprel", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exprel(Double x);


        /// <summary>
        /// Returns exp(x*|x|) with damped error amplification
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expx2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expx2(Double x);



        /// <summary>
        /// Returns logistic(x) = 1/(1+exp(-x))
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logistic", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logistic(Double x);



        /// <summary>
        /// Returns the einstein function E_n, n=1..4, x > 0 for n=3,4
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_einstein", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double einstein(int n, Double x);



        /// <summary>
        /// Returns ln(1-exp(x)), x \lt 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ln1mexp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log1mexp(Double x);


        /// <summary>
        /// Accurately compute ln(1+exp(x)) without overflow
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ln1pexp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log1pexp(Double x);


        /// <summary>
        /// Returns ln(1+x)-x, accurate even for -0.5 \le x \le 0.5
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ln1pmx", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log1pmx(Double x);


        /// <summary>
        /// Accurately compute ln[exp(x) + exp(y)]
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logaddexp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logaddexp(Double x, Double y);


        /// <summary>
        /// Accurately compute ln[exp(x) - exp(y)], x > y
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logsubexp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logsubexp(Double b, Double x);


        /// <summary>
        /// Returns logit(x) = ln(x/(1.0-x)), accurate near x=0.5
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logit", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logit(Double x);




        /// <summary>
        /// Returns the Wright omega function, i.e. the solution w of w + ln(w) = x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_omega", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double wright_omega(Double x);



        /// <summary>
        /// Returns sqrt(x*x + y*y + z*z)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hypot3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hypot3(Double x, Double y, Double z);





        /// <summary>
        /// Returns the Fibonacci polynomial F_n(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fibpoly", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fibpoly(int n, Double x);


        /// <summary>
        /// Returns the Lucas polynomial L_n(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lucpoly", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lucpoly(int n, Double x);


        /// <summary>
        /// Returns the general Fibonacci function F_v(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fibfun", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fibfun(Double v, Double x);





#endregion



#region TestCdecl From DAMath, Trig, Hyperbolic


        /// <summary>
        /// Returns the coversine covers(x) = 1 - sin(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_covers", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double covers(Double x);


        /// <summary>
        /// Returns the haversine hav(x) = (1 - cos(x))/2
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hav", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hav(Double x);


        /// <summary>
        /// Returns the versine vers(x) = 1 - cos(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_vers", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double vers(Double x);


        /// <summary>
        /// Returns versint(x) = integral(vers(t),t=0..x) = x - sin(x), accurate near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_versint", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double versint(Double x);


        /// <summary>
        /// Returns cosint(n, x) = integral(cos(t)^n, t=0..x), n &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cosint", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cosint(int n, Double x);



        /// <summary>
        /// Returns sinint(n, x) = integral(sin(t)^n, t=0..x), n &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinint", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinint(int n, Double x);


        /// <summary>
        /// Solves kepler's equation, result x is the eccentric anomaly from the mean anomaly M and the
        /// <para> eccentricity e &#8805; 0; x - e*sin(x) = M, x + x^3/3 = M, or e*sinh(x) - x = M for e &lt; 1, =1, &gt; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kepler", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kepler(Double M, Double e);


        /// <summary>
        /// Returns cos(x), x in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cosd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cosd(Double x);

        /// <summary>
        /// Returns cot(x), x in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cotd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double Cotd(Double x);


        /// <summary>
        /// Returns sin(x), x in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sind", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sind(Double x);

        /// <summary>
        /// Returns tan(x), x in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_tand", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double tand(Double x);



        /// <summary>
        /// Returns cosh(x)-1, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_coshm1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double coshm1(Double x);


        /// <summary>
        /// Returns sinh(x)/x, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinhc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinhc(Double x);

        /// <summary>
        /// Returns sinh(x)-x, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinhmx", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinhmx(Double x);


        /// <summary>
        /// Returns the Langevin function L(x) = coth(x) - 1/x, L(0) = 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_LangevinL", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double langevinl(Double x);


        /// <summary>
        /// Returns ln(cosh(x)), accurate for x ~ 0 and without overflow for large x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lncosh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logcosh(Double x);


        /// <summary>
        /// Returns ln(sinh(x)), x > 0, accurate for x ~ 0 and without overflow for large x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lnsinh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logsinh(Double x);


        /// <summary>
        /// Returns arccos(1-x), 0 \le x \le 2, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccos1m", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acos1m(Double x);


        /// <summary>
        /// Returns the continuous inverse circular cotangent; arccotc(x) = Pi/2 - arctan(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccotc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acotc(Double x);


        /// <summary>
        /// Returns the Gudermannian function gd(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gudermann(Double x);


        /// <summary>
        /// Returns the inverse circular cosine of x, |x| \le 1, result in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccosd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acosd(Double x);

        /// <summary>
        /// Returns the continuous inverse circular cotangent; arccotcd(x) = 90 - arctand(x), result in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccotcd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acotcd(Double x);


        /// <summary>
        /// Returns the sign symmetric inverse circular cotangent, arccotd(x) = arctand(1/x), x \ne 0, result in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccotd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acotd(Double x);

        /// <summary>
        /// Returns the inverse circular sine of x, |x| \le 1, result in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcsind", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double asind(Double x);


        /// <summary>
        /// Returns the inverse circular tangent of x, result in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arctand", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double atand(Double x);


        /// <summary>
        /// Returns arccosh(1+x), x \ge 0, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccosh1p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acosh1p(Double x);


        /// <summary>
        /// Returns the inverse Gudermannian function arcgd(x), |x| \le Pi/2
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcgd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double arcgudermann(Double x);


        /// <summary>
        /// Returns the inverse haversine archav(x), 0 \ne x \ne 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_archav", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double archav(Double x);


        /// <summary>
        /// Returns the functional inverse of the Langevin function, |x| &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_LangevinL_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double langevinlinv(Double x);






#endregion




    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion




