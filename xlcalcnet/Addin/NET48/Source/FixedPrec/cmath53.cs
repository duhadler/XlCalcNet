using System;
using System.Numerics;
using System.Runtime.InteropServices;


namespace FixedPrecNet
{





    public partial class cmath53
    {



        public static String fmt(Complex z)
        {
            string s = dcplx.fmt(z);
            return s;
        }


        public static String fmt(Double x)
        {
            return dreal.fmt(x);
        }


        public static String fmt(dynamic z)
        {
            return fmt(t(z));
        }



        #region Basic floating point functions


        #region General

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/name/*' />
        public static String name
        {
            get { return "cmath53"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/fmtname/*' />
        public static String fmtname
        {
            get { return "cmath53"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/prec/*' />
        public static Int32 prec
        {
            get { return 64; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/isrealctx/*' />
        public static bool isrealctx
        {
            get { return false; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/iscplxctx/*' />
        public static bool iscplxctx
        {
            get { return true; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/isintervalorballctx/*' />
        public static bool isintervalorballctx
        {
            get { return false; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/isdecimalctx/*' />
        public static bool isdecimalctx
        {
            get { return false; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/isfractionctx/*' />
        public static bool isfractionctx
        {
            get { return false; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/hasnegativezero/*' />
        public static bool hasnegativezero
        {
            get { return true; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/supportsboost/*' />
        public static bool supportsboost
        {
            get { return false; }
        }

        ///// <include file="docs.xml" path='docs/members[@name="Contexts"]/Mat/*' />
        //public static dcplxmat Mat
        //{
        //    get { return new dcplxmat(); }
        //}




        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/realctx/*' />
        public static math53 realctx
        {
            get { return new math53(); }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static cmath53 cplxctx
        {
            get { return new cmath53(); }
        }


        #endregion



        #region Conversions



        /// <summary>
        /// Returns a new Complex using a general object as input
        /// </summary>
        public static Complex t(dynamic z)
        {
            // MsgBox(y_.GetType().ToString())
            // MsgBox(y_.ToString())
            // MsgBox(y_.real.ToString())
            string s_re = z.real.ToString();
            string s_im = z.imag.ToString();
            return t(s_re, s_im);
        }



        ///// <summary>
        ///// Returns a new Complex using an extended precision floating point number as input for the real part; the imaginary part is set to zero.
        ///// </summary>
        //public static Complex t(Double x)
        //{
        //    return new Complex(x.d, 0.0);
        //}


        ///// <summary>
        ///// Returns a new Complex using a 50 digits precision decimal floating point number as input for the real part; the imaginary part is set to zero.
        ///// </summary>
        //public static Complex t(ct x)
        //{
        //    return new Complex(dreal.t(x).d, 0.0);
        //}



        ///// <summary>
        ///// Returns a new Complex using a quadruple precision binary floating point number as input for the real part; the imaginary part is set to zero.
        ///// </summary>
        //public static Complex t(Quadruple x)
        //{
        //    return new Complex(dreal.t(x).d, 0.0);
        //}



        ///// <summary>
        ///// Returns a new Complex using an extended precision binary floating point number as input for the real part; the imaginary part is set to zero.
        ///// </summary>
        //public static Complex T_(Double x)
        //{
        //    return new Complex(dreal.t(x).d, 0.0);
        //}



        ///// <summary>
        ///// Returns a new Complex using a Double precision binary floating point number for the real part; the imaginary part is set to zero.
        ///// </summary>
        //public static Complex t(Double x)
        //{
        //    return new Complex(dreal.t(x).d, 0.0);
        //}



        ///// <summary>
        ///// Returns a new Complex using a single precision binary floating point number as input for the real part; the imaginary part is set to zero.
        ///// </summary>
        //public static Complex t(Single x)
        //{
        //    return new Complex(dreal.t(x).d, 0.0);
        //}



        /// <summary>
        /// Returns a new Complex using a signed 32 bit integer as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(Int32 x)
        {
            return new Complex(x, 0.0);
        }


        /// <summary>
        /// Returns a new Complex using an unsigned 32 bit integer as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(UInt32 x)
        {
            return new Complex(x, 0.0);
        }


        /// <summary>
        /// Returns a new Complex using a signed 64 bit integer as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(Int64 x)
        {
            return new Complex(x, 0.0);
        }


        /// <summary>
        /// Returns a new Complex using an unsigned 64 bit integer as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(UInt64 x)
        {
            return new Complex(x, 0.0);
        }


        ///// <summary>
        ///// Returns a new Complex using an unsigned 64 bit integer as input for the real part; the imaginary part is set to zero.
        ///// </summary>
        //public static Complex t(BigInteger x)
        //{
        //    return new Complex(dreal.t(x).d, 0.0);
        //}


        ///// <summary>
        ///// Returns a new Complex using a string as input for the real part; the imaginary part is set to zero.
        ///// </summary>
        //public static Complex t(string s)
        //{
        //    return new Complex(dreal.t(s).d, 0.0);
        //}



        ///// <summary>
        ///// Returns a new Complex using 2 Double as input for the real and imaginary part
        ///// </summary>
        //public static Complex t(Double re, Double im)
        //{
        //    return new Complex(re.d, im.d);
        //}



        ///// <summary>
        ///// Returns a new Complex using a complex 50 digits precision decimal floating point number as input
        ///// </summary>
        //public static Complex t(ccplx_t z)
        //{
        //    return new Complex(dreal.t(z.real).d, dreal.t(z.imag).d);
        //}



        ///// <summary>
        ///// Returns a new Complex using a complex quadruple precision binary floating point number as input
        ///// </summary>
        //public static Complex t(QuadrupleC z)
        //{
        //    return new Complex((z.real).d, dreal.t(z.imag).d);
        //}




        /// <summary>
        /// Returns a new Complex using a complex Double precision binary floating point number(System.Complex) as input
        /// </summary>
        public static Complex t(Complex z)
        {
            return z;
        }




        /// <summary>
        /// Returns a new Complex using 2 Double as input for the real and imaginary part
        /// </summary>
        public static Complex t(Double d_re, Double d_im)
        {
            return new Complex(d_re, d_im);
        }


        /// <summary>
        /// Returns a new Complex using 2 strings as input for the real and imaginary part
        /// </summary>
        public static Complex t(string s_re, string s_im)
        {
            return new Complex(math53.t(s_re), math53.t(s_im));
        }


        ///// <summary>
        ///// Returns a new Complex using a general object as input
        ///// </summary>
        //public static Complex t(dynamic z)
        //{
        //    // MsgBox(y_.GetType().ToString())
        //    // MsgBox(y_.ToString())
        //    // MsgBox(y_.real.ToString())
        //    string s_re = z.Real.ToString();
        //    string s_im = z.imag.ToString();
        //    return t(s_re, s_im);
        //}


        #endregion



        #endregion






        #region Elementary scalar functions


        #region Complex components


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Double abs(Complex z)
        {
            return Complex.Abs(z);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static Double abs(dynamic z)
        {
            return abs(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Double fabs(Complex z)
        {
            return Complex.Abs(z);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static Double fabs(dynamic z)
        {
            return fabs(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static Complex sign(Complex z)
        {
            if (dcplx.iszero(z)) return dcplx.zero();
            else return z / abs(z);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static Complex sign(dynamic z)
        {
            return sign(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Double real(Complex z)
        {
            return z.Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Double real(dynamic z)
        {
            return real(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Double imag(Complex z)
        {
            return z.Imaginary;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Double imag(dynamic z)
        {
            return imag(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Double phase(Complex z)
        {
            return z.Phase;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Double phase(dynamic z)
        {
            return phase(t(z));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static Complex conj(Complex z)
        {
            return Complex.Conjugate(z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Complex conj(dynamic z)
        {
            return conj(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Double, Double> polar(Complex x)
        {
            return new Tuple<Double, Double>(abs(x), phase(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Double, Double> polar(dynamic x)
        {
            return polar(dcplx.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rect/*' />
        public static Complex rect(Double r, Double phi)
        {
            return r * expj(phi);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rect/*' />
        public static Complex rect(dynamic r, dynamic phi)
        {
            return rect(dreal.t(r), dreal.t(phi));
        }





        #endregion






        #region Roots, quartic etc.



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static Complex sqrt(Complex x)
        {
            return Complex.Sqrt(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static Complex sqrt(dynamic x)
        {
            return sqrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Complex rsqrt(Complex x)
        {
            return 1.0 / sqrt(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Complex rsqrt(dynamic x)
        {
            return rsqrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt1pm1/*' />
        public static Complex sqrt1pm1(Complex x)
        {
            return dcplx.sqrt1pm1(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt1pm1/*' />
        public static Complex sqrt1pm1(dynamic x)
        {
            return sqrt1pm1(t(x));
        }



        /// <summary>
        /// Returns the complex principal sqr root of (1-z^2); w = sqrt(1-z^2)
        /// </summary>
        public static Complex sqrt1mz2(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_csqrt1mz2(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_csqrt1mz2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_csqrt1mz2(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex principal sqr root of (1-z^2); w = sqrt(1-z^2)
        /// </summary>
        public static Complex sqrt1mz2(dynamic z1)
        {
            return sqrt1mz2(t(z1));
        }


        /// <summary>
        /// Returns the complex principal cube root w = cbrt(z) = z^(1/3)
        /// </summary>
        public static Complex cbrt(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_ccbrt(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ccbrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_ccbrt(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex principal cube root w = cbrt(z) = z^(1/3)
        /// </summary>
        public static Complex cbrt(dynamic z1)
        {
            return cbrt(t(z1));
        }



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
            return cuberoot(t(z1));
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
            return surd(t(z1), n);
        }



        /// <summary>
        /// Returns the complex principal n'th root w = z^(1/n)
        /// </summary>
        public static Complex root_si(Complex z1, int n)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cnroot(z1.Real, z1.Imaginary, n, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cnroot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cnroot(Double x_re, Double x_im, int n, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex principal n'th root w = z^(1/n)
        /// </summary>
        public static Complex root_si(dynamic z1, int n)
        {
            return root_si(t(z1), n);
        }


        /// <summary>
        /// Returns the principal nth root of unity z = exp(2*Pi*i/n)
        /// </summary>
        public static Complex nroot1(int n)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cnroot1(n, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cnroot1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cnroot1(int n, ref Double res_re, ref Double res_im);





        #region poly_equations


        public static Complex eval_quadratic(Complex x, Complex A, Complex B, Complex C)
        {
            return (A * x + B) * x + C;
        }

        public static Complex eval_quadratic(dynamic x, dynamic A, dynamic B, dynamic C)
        {
            return eval_quadratic(dcplx.t(x), dcplx.t(A), dcplx.t(B), dcplx.t(C));
        }


        // See also: Press, 3rd edition, page 227
        public static Tuple<Complex, Complex> quadratic_equation(Complex a, Complex b, Complex c)
        {
            Complex x1, x2;
            Complex D = Complex.Sqrt(b * b - 4 * a * c);
            Complex bStar = Complex.Conjugate(b);
            if ((bStar * D).Real < 0.0)
            {
                D = -D;
            }
            Complex q = -0.5 * (b + D);
            x1 = q / a;
            x2 = c / q;
            return new Tuple<Complex, Complex>(x1, x2);
        }

        public static Tuple<Complex, Complex> quadratic_equation(dynamic A, dynamic B, dynamic C)
        {
            return quadratic_equation(dcplx.t(A), dcplx.t(B), dcplx.t(C));
        }




        public static Complex eval_monic_cubic(Complex x, Complex a, Complex b, Complex c)
        {
            return ((x + a) * x + b) * x + c;
        }

        public static Complex eval_monic_cubic(dynamic x, dynamic a, dynamic b, dynamic c)
        {
            return eval_monic_cubic(dcplx.t(x), dcplx.t(a), dcplx.t(b), dcplx.t(c));
        }


        // See also: Press, 3rd edition, page 228
        public static Tuple<Complex, Complex, Complex> cubic_equation_monic(Complex a, Complex b, Complex c)
        {
            Complex x1, x2, x3;
            Complex Q = (a * a - 3 * b) / 9;
            Complex R = (2 * a * a * a - 9 * a * b + 27 * c) / 54;
            Double Qr = Q.Real;
            Double Rr = R.Real;
            if ((Q.Imaginary == 0.0) && (R.Imaginary == 0.0) && (Rr * Rr < Qr * Qr * Qr))
            {
                Console.WriteLine("In Complex real Case");
                Double SqrtQr = Math.Sqrt(Qr);
                Double theta = Math.Acos(Rr / (SqrtQr * SqrtQr * SqrtQr));
                x1 = -2 * SqrtQr * Math.Cos((theta) / 3) - a / 3;
                x2 = -2 * SqrtQr * Math.Cos((theta + 2 * Math.PI) / 3) - a / 3;
                x3 = -2 * SqrtQr * Math.Cos((theta - 2 * Math.PI) / 3) - a / 3;
            }
            else
            {
                Console.WriteLine("In Complex Complex Case");
                Complex D = Complex.Sqrt(R * R - Q * Q * Q);
                Complex RStar = Complex.Conjugate(R);
                if ((RStar * D).Real < 0.0)
                {
                    D = -D;
                }
                Complex A = -cmath53.cbrt(R + D);
                Complex B = new Complex(0, 0);
                if (A != new Complex(0, 0))
                {
                    B = Q / A;
                }
                Console.WriteLine("A: {0}", A);
                Console.WriteLine("B: {0}", B);

                x1 = (A + B) - a / 3;
                x2 = -0.5 * (A + B) - a / 3 + 0.5 * Complex.ImaginaryOne * Math.Sqrt(3) * (A - B);
                x3 = -0.5 * (A + B) - a / 3 - 0.5 * Complex.ImaginaryOne * Math.Sqrt(3) * (A - B);
            }
            return new Tuple<Complex, Complex, Complex>(x1, x2, x3);
        }
        public static Tuple<Complex, Complex, Complex> cubic_equation_monic(dynamic a, dynamic b, dynamic c)
        {
            return cubic_equation_monic(dcplx.t(a), dcplx.t(b), dcplx.t(c));
        }




        public static Complex eval_cubic(Complex x, Complex A, Complex B, Complex C, Complex D)
        {
            return ((A * x + B) * x + C) * x + D;
        }

        public static Complex eval_cubic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return eval_cubic(dcplx.t(x), dcplx.t(A), dcplx.t(B), dcplx.t(C), dcplx.t(D));
        }


        public static Tuple<Complex, Complex, Complex> cubic_equation(Complex A, Complex B, Complex C, Complex D)
        {
            return cubic_equation_monic(B / A, C / A, D / A);
        }
        public static Tuple<Complex, Complex, Complex> cubic_equation(dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return cubic_equation(dcplx.t(A), dcplx.t(B), dcplx.t(C), dcplx.t(D));
        }





        public static Complex eval_quartic(Complex x, Complex A, Complex B, Complex C, Complex D, Complex E)
        {
            return (((A * x + B) * x + C) * x + D) * x + E;
        }

        public static Complex eval_quartic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return eval_quartic(dcplx.t(x), dcplx.t(A), dcplx.t(B), dcplx.t(C), dcplx.t(D), dcplx.t(E));
        }


        // See also: https://en.wikipedia.org/wiki/Quartic_equation#Summary_of_Ferrari's_method
        public static Tuple<Complex, Complex, Complex, Complex> quartic_equation(Complex A, Complex B, Complex C, Complex D, Complex E)
        {
            Complex x1, x2, x3, x4;
            Complex a = -(3 * B * B) / (8 * A * A) + C / A;
            Complex b = (B * B * B) / (8 * A * A * A) - (B * C) / (2 * A * A) + D / A;
            Complex c = -(3 * B * B * B * B) / (256 * A * A * A * A) + (C * B * B) / (16 * A * A * A) - (B * D) / (4 * A * A) + E / A;
            Complex V = -B / (4 * A);

            //if (Complex.iszero(b))
            if (b == new Complex(0, 0))


            {
                Complex W = Complex.Sqrt(a * a - 4 * c);
                Complex Z1 = Complex.Sqrt((-a + W) / 2);
                Complex Z2 = Complex.Sqrt((-a - W) / 2);
                x1 = V + Z1;
                x2 = V - Z1;
                x3 = V + Z2;
                x4 = V - Z2;
            }
            else
            {
                Complex e = 5 * a / 2;
                Complex f = 2 * a * a - c;
                Complex g = a * a * a / 2 - a * c / 2 - b * b / 8;
                var res = cubic_equation_monic(e, f, g);
                Complex y = res.Item1;
                Complex W = Complex.Sqrt(a + 2 * y);
                Complex Z1 = Complex.Sqrt(-(3 * a + 2 * y + 2 * b / W));
                Complex Z2 = Complex.Sqrt(-(3 * a + 2 * y - 2 * b / W));
                x1 = V + (W + Z1) / 2;
                x2 = V + (W - Z1) / 2;
                x3 = V - (W + Z2) / 2;
                x4 = V - (W - Z2) / 2;
            }
            return new Tuple<Complex, Complex, Complex, Complex>(x1, x2, x3, x4);
        }

        public static Tuple<Complex, Complex, Complex, Complex> quartic_equation(dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return quartic_equation(dcplx.t(A), dcplx.t(B), dcplx.t(C), dcplx.t(D), dcplx.t(E));
        }


        #endregion




        #endregion




        #region Exponential and related functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static Complex exp(Complex x)
        {
            return Complex.Exp(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static Complex exp(dynamic x)
        {
            return exp(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static Complex expj(Complex x)
        {
            return cos(x) + dcplx.onej() * sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static Complex expj(dynamic x)
        {
            return expj(dcplx.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static Complex expjpi(Complex x)
        {
            return cospi(x) + dcplx.onej() * sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static Complex expjpi(dynamic x)
        {
            return expjpi(dcplx.t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Complex expm1(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cexpm1(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cexpm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cexpm1(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Complex expm1(dynamic x)
        {
            return expm1(t(x));
        }



        /// <summary>
        /// Returns w = 10^z = exp(z*ln(10))
        /// </summary>
        public static Complex exp10(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cexp10(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cexp10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cexp10(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns w = 10^z = exp(z*ln(10))
        /// </summary>
        public static Complex exp10(dynamic x)
        {
            return exp10(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Complex exp2(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cexp2(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cexp2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cexp2(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Complex exp2(dynamic x)
        {
            return exp2(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Complex exp2m1(Complex z1)
        {
            return dcplx.exp2m1(z1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Complex exp2m1(dynamic x)
        {
            return exp2m1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static Complex exp10m1(Complex z1)
        {
            return dcplx.exp10m1(z1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static Complex exp10m1(dynamic x)
        {
            return exp10m1(t(x));
        }









        #endregion



        #region Logarithms and related functions




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static Complex log(Complex x)
        {
            return Complex.Log(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static Complex log(dynamic x)
        {
            return log(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Complex log1p(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cln1p(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cln1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cln1p(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Complex log1p(dynamic z1)
        {
            return log1p(t(z1));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logbase/*' />
        public static Complex logbase(Complex z1, Complex z2)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_clogbase(z1.Real, z1.Imaginary, z2.Real, z2.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_clogbase", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_clogbase(Double x_re, Double x_im, Double y_re, Double y_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logbase/*' />
        public static Complex logbase(dynamic z1, dynamic z2)
        {
            return logbase(t(z1), t(z2));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Complex log2(Complex x)
        {
            return logbase(2, x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Complex log2(dynamic x)
        {
            return log2(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Complex log10(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_clog10(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_clog10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_clog10(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Complex log10(dynamic z1)
        {
            return log10(t(z1));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static Complex log2p1(Complex z1)
        {
            return dcplx.log2p1(z1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static Complex log2p1(dynamic x)
        {
            return log2p1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static Complex log10p1(Complex z1)
        {
            return dcplx.log10p1(z1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static Complex log10p1(dynamic x)
        {
            return log10p1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lambert_wk/*' />
        public static Complex lambert_wk(Complex z1, int k)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cLambertWk(k, z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cLambertWk", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cLambertWk(int k, Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lambert_wk/*' />
        public static Complex lambert_wk(dynamic z1, int k)
        {
            return lambert_wk(t(z1), k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lambert_w0/*' />
        public static Complex lambert_w0(Complex x)
        {
            return lambert_wk(t(x), 0);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lambert_w0/*' />
        public static Complex lambert_w0(dynamic x)
        {
            return lambert_w0(t(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lambert_wm1/*' />
        public static Complex lambert_wm1(Complex x)
        {
            return lambert_wk(t(x), -1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lambert_wm1/*' />
        public static Complex lambert_wm1(dynamic x)
        {
            return lambert_wm1(t(x));
        }



        #endregion



        #region Power functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static Complex sqr(Complex x)
        {
            return x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static Complex sqr(dynamic x)
        {
            return sqr(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static Complex cube(Complex x)
        {
            return x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static Complex cube(dynamic x)
        {
            return cube(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static Complex hypot(Complex x, Complex y)
        {
            return sqrt(x * x + y * y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static Complex hypot(dynamic x, dynamic y)
        {
            return hypot(t(x), t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static Complex pow(Complex x, Complex y)
        {
            return Complex.Pow(x, y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static Complex pow(dynamic x, dynamic y)
        {
            return pow(t(x), t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static Complex powm1(Complex x, Complex y)
        {
            return dcplx.powm1(x, y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static Complex powm1(dynamic x, dynamic y)
        {
            return powm1(t(x), t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static Complex pow1p(Complex x, Complex y)
        {
            return dcplx.pow1p(x, y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static Complex pow1p(dynamic x, dynamic y)
        {
            return pow1p(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static Complex pow1pm1(Complex x, Complex y)
        {
            return dcplx.pow1p(x, y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static Complex pow1pm1(dynamic x, dynamic y)
        {
            return pow1pm1(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static Complex pow_si(Complex x, Int32 n)
        {
            return dcplx.pow_si(x, n);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static Complex pow_si(dynamic x, Int32 n)
        {
            return pow_si(t(x), n);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static Complex compound_si(Complex x, Int32 n)
        {
            return dcplx.compound_si(x, n);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static Complex compound_si(dynamic x, Int32 n)
        {
            return compound_si(t(x), n);
        }



        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        //public static Complex Powx(Complex z1, Double x)
        //{
        //    Double res_re = 0.0, res_im = 0.0;
        //    damath_cpowx(z1.Real, z1.Imaginary, x, ref res_re, ref res_im);
        //    return new Complex(res_re, res_im);
        //}
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_cpowx", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void damath_cpowx(Double x_re, Double x_im, Double x, ref Double res_re, ref Double res_im);

        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        //public static Complex Powx(dynamic z1, Double x)
        //{
        //    return pow(t(z1), x);
        //}



        #endregion



        #region Trigonometric and related functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static Complex cos(Complex x)
        {
            return Complex.Cos(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static Complex cos(dynamic x)
        {
            return cos(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Complex sin(Complex x)
        {
            return Complex.Sin(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Complex sin(dynamic x)
        {
            return sin(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static Complex tan(Complex x)
        {
            return Complex.Tan(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static Complex tan(dynamic x)
        {
            return tan(t(x));
        }


        /// <summary>
        /// Returns the complex circular cotangent w = cot(z)
        /// </summary>
        public static Complex cot(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_ccot(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ccot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_ccot(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex circular cotangent w = cot(z)
        /// </summary>
        public static Complex cot(dynamic z1)
        {
            return cot(t(z1));
        }


        /// <summary>
        /// Returns the complex circular secant w = sec(z) = 1/cos(z)
        /// </summary>
        public static Complex sec(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_csec(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_csec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_csec(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex circular secant w = sec(z) = 1/cos(z)
        /// </summary>
        public static Complex sec(dynamic z1)
        {
            return sec(t(z1));
        }



        /// <summary>
        /// Returns the complex circular cosecant w = csc(z) = 1/sin(z)
        /// </summary>
        public static Complex csc(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_ccsc(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ccsc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_ccsc(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex circular cosecant w = csc(z) = 1/sin(z)
        /// </summary>
        public static Complex csc(dynamic z1)
        {
            return csc(t(z1));
        }



        /// <summary>
        /// Returns the complex circular sine w = sin(Pi*z)
        /// </summary>
        public static Complex sinpi(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_csinpi(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_csinpi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_csinpi(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex circular sine w = sin(Pi*z)
        /// </summary>
        public static Complex sinpi(dynamic z1)
        {
            return sinpi(t(z1));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static Complex cospi(Complex x)
        {
            return dcplx.cospi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static Complex cospi(dynamic x)
        {
            return cospi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static Complex tanpi(Complex x)
        {
            return dcplx.tanpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static Complex tanpi(dynamic x)
        {
            return tanpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static Complex cscpi(Complex x)
        {
            return dcplx.cscpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static Complex cscpi(dynamic x)
        {
            return cscpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static Complex secpi(Complex x)
        {
            return dcplx.secpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static Complex secpi(dynamic x)
        {
            return secpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cotpi/*' />
        public static Complex cotpi(Complex x)
        {
            return dcplx.cotpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cotpi/*' />
        public static Complex cotpi(dynamic x)
        {
            return cotpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinc/*' />
        public static Complex sinc(Complex x)
        {
            if (dcplx.iszero(x)) return new Complex(1, 0);
            else return sinpi(x) / (x * dreal.pi());
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinc/*' />
        public static Complex sinc(dynamic x)
        {
            return sinc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static Complex sincpi(Complex x)
        {
            if (dcplx.iszero(x)) return new Complex(1, 0);
            else return sinpi(x) / (x * dreal.pi());
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static Complex sincpi(dynamic x)
        {
            return sincpi(t(x));
        }




        #endregion



        #region Hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static Complex cosh(Complex x)
        {
            return Complex.Cosh(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static Complex cosh(dynamic x)
        {
            return cosh(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static Complex sinh(Complex x)
        {
            return Complex.Sinh(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static Complex sinh(dynamic x)
        {
            return sinh(t(x));
        }






        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static Complex tanh(Complex x)
        {
            return Complex.Tanh(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static Complex tanh(dynamic x)
        {
            return tanh(t(x));
        }


        /// <summary>
        /// Returns the complex hyperbolic cotangent w = coth(z)
        /// </summary>
        public static Complex coth(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_ccoth(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ccoth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_ccoth(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex hyperbolic cotangent w = coth(z)
        /// </summary>
        public static Complex coth(dynamic z1)
        {
            return coth(t(z1));
        }




        /// <summary>
        /// Returns the complex hyperbolic cosecant w = csch(z) = 1/sinh(z)
        /// </summary>
        public static Complex csch(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_ccsch(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ccsch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_ccsch(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex hyperbolic cosecant w = csch(z) = 1/sinh(z)
        /// </summary>
        public static Complex csch(dynamic z1)
        {
            return csch(t(z1));
        }



        /// <summary>
        /// Returns the complex hyperbolic secant w = sech(z) = 1/cosh(z)
        /// </summary>
        public static Complex sech(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_csech(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_csech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_csech(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex hyperbolic secant w = sech(z) = 1/cosh(z)
        /// </summary>
        public static Complex sech(dynamic z1)
        {
            return sech(t(z1));
        }



        #endregion



        #region Inverse trigonometric functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static Complex acos(Complex x)
        {
            return Complex.Acos(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static Complex acos(dynamic x)
        {
            return acos(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static Complex asin(Complex x)
        {
            return Complex.Asin(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static Complex asin(dynamic x)
        {
            return asin(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static Complex atan(Complex x)
        {
            return Complex.Atan(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static Complex atan(dynamic x)
        {
            return atan(t(x));
        }


        /// <summary>
        /// Returns the principal value of the complex inverse circular secant w = arcsec(z) = arccos(1/z)
        /// </summary>
        public static Complex asec(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_carcsec(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_carcsec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_carcsec(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the principal value of the complex inverse circular secant w = arcsec(z) = arccos(1/z)
        /// </summary>
        public static Complex asec(dynamic z1)
        {
            return asec(t(z1));
        }


        /// <summary>
        /// Returns the principal value of the complex inverse circular cosecant w = arccsc(z) = arcsin(1/z)
        /// </summary>
        public static Complex acsc(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_carccsc(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_carccsc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_carccsc(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the principal value of the complex inverse circular cosecant w = arccsc(z) = arcsin(1/z)
        /// </summary>
        public static Complex acsc(dynamic z1)
        {
            return acsc(t(z1));
        }



        /// <summary>
        /// Returns the principal value of the complex inverse circular cotangent w = arccot(z) = arctan(1/z)
        /// </summary>
        public static Complex acot(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_carccot(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_carccot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_carccot(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the principal value of the complex inverse circular cotangent w = arccot(z) = arctan(1/z)
        /// </summary>
        public static Complex acot(dynamic z1)
        {
            return acot(t(z1));
        }


        /// <summary>
        /// Returns the principal value of the complex inverse circular cotangent w = arccotc(z) = Pi/2 - arctan(z)
        /// </summary>
        public static Complex acotc(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_carccotc(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_carccotc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_carccotc(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the principal value of the complex inverse circular cotangent w = arccotc(z) = Pi/2 - arctan(z)
        /// </summary>
        public static Complex acotc(dynamic z1)
        {
            return acotc(t(z1));
        }


        #endregion



        #region Inverse hyperbolic functions



        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic cosine w = arccosh(z)
        /// </summary>
        public static Complex acosh(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_carccosh(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_carccosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_carccosh(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic cosine w = arccosh(z)
        /// </summary>
        public static Complex acosh(dynamic z1)
        {
            return acosh(t(z1));
        }



        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic sine w = arcsinh(z)
        /// </summary>
        public static Complex asinh(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_carcsinh(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_carcsinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_carcsinh(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic sine w = arcsinh(z)
        /// </summary>
        public static Complex asinh(dynamic z1)
        {
            return asinh(t(z1));
        }



        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic tangent w = arctanh(z)
        /// </summary>
        public static Complex atanh(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_carctanh(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_carctanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_carctanh(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic tangent w = arctanh(z)
        /// </summary>
        public static Complex atanh(dynamic z1)
        {
            return atanh(t(z1));
        }



        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic cosecant w = arccsch(z) = arcsinh(1/z)
        /// </summary>
        public static Complex acsch(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_carccsch(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_carccsch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_carccsch(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic cosecant w = arccsch(z) = arcsinh(1/z)
        /// </summary>
        public static Complex acsch(dynamic z1)
        {
            return acsch(t(z1));
        }



        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic secant w = arcsech(z) = arccosh(1/z)
        /// </summary>
        public static Complex asech(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_carcsech(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_carcsech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_carcsech(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic secant w = arcsech(z) = arccosh(1/z)
        /// </summary>
        public static Complex asech(dynamic z1)
        {
            return asech(t(z1));
        }


        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic cotangent w = arccoth(z) = arctanh(1/z)
        /// </summary>
        public static Complex acoth(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_carccoth(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_carccoth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_carccoth(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic cotangent w = arccoth(z) = arctanh(1/z)
        /// </summary>
        public static Complex acoth(dynamic z1)
        {
            return acoth(t(z1));
        }



        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic cotangent w = arccothc(z) = arctanh(z) + i*Pi/2
        /// </summary>
        public static Complex acothc(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_carccothc(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_carccothc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_carccothc(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the principal value of the complex inverse hyperbolic cotangent w = arccothc(z) = arctanh(z) + i*Pi/2
        /// </summary>
        public static Complex acothc(dynamic z1)
        {
            return acothc(t(z1));
        }





        #endregion




        #region Factorials, Gamma and related functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        public static Complex gamma(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cgamma(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cgamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cgamma(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        public static Complex gamma(dynamic x)
        {
            return gamma(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma1pm1/*' />
        public static Complex gamma1pm1(Complex x)
        {
            return gamma(x + 1) - 1;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma1pm1/*' />
        public static Complex gamma1pm1(dynamic x)
        {
            return gamma1pm1(dcplx.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/factorial/*' />
        public static Complex factorial(Complex x)
        {
            return gamma(x + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/factorial/*' />
        public static Complex factorial(dynamic x)
        {
            return factorial(dcplx.t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/doublefactorial/*' />
        public static Complex doublefactorial(Complex x)
        {
            return exp2(x / 2) * pow(dreal.pi() / 2, (cospi(x) - 1) / 4) * gamma(x / 2 + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/doublefactorial/*' />
        public static Complex doublefactorial(dynamic x)
        {
            return doublefactorial(dcplx.t(x));
        }






        /// <summary>
        /// Returns the reciprocal Gamma function w = 1/Gamma(z)
        /// </summary>
        public static Complex rgamma(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_crgamma(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_crgamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_crgamma(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the reciprocal Gamma function w = 1/Gamma(z)
        /// </summary>
        public static Complex rgamma(dynamic z1)
        {
            return rgamma(t(z1));
        }




        /// <summary>
        /// Returns w = lnGamma(z), the principal branch of the log-Gamma function
        /// </summary>
        public static Complex lgamma(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_clngamma(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_clngamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_clngamma(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns w = lnGamma(z), the principal branch of the log-Gamma function
        /// </summary>
        public static Complex lgamma(dynamic z1)
        {
            return lgamma(t(z1));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rising_factorial/*' />
        public static Complex rising_factorial(Complex a, Complex n)
        {
            Complex res = dcplx.nan();
            if ((a.Imaginary == 0.0) && (n.Imaginary == 0.0))
            {
                res = math53.rising_factorial(a.Real, n.Real);
            }
            else
            {
                res = gamma(a + n) / gamma(a);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rising_factorial/*' />
        public static Complex rising_factorial(dynamic a, dynamic n)
        {
            return rising_factorial(t(a), t(n));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/falling_factorial/*' />
        public static Complex falling_factorial(Complex a, Complex n)
        {
            return rising_factorial(a - n + 1, n);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/falling_factorial/*' />
        public static Complex falling_factorial(dynamic a, dynamic n)
        {
            return falling_factorial(dcplx.t(a), dcplx.t(n));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma_ratio/*' />
        public static Complex gamma_ratio(Complex a, Complex b)
        {
            return gamma(a) / gamma(b);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma_ratio/*' />
        public static Complex gamma_ratio(dynamic a, dynamic b)
        {
            return gamma_ratio(dcplx.t(a), dcplx.t(b));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma_delta_ratio/*' />
        public static Complex gamma_delta_ratio(Complex a, Complex delta)
        {
            return gamma(a) / gamma(a + delta);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma_delta_ratio/*' />
        public static Complex gamma_delta_ratio(dynamic a, dynamic delta)
        {
            return gamma_delta_ratio(dcplx.t(a), dcplx.t(delta));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/beta/*' />
        public static Complex beta(Complex a, Complex b)
        {
            return gamma(a) * gamma(b) / gamma(a + b);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/beta/*' />
        public static Complex beta(dynamic a, dynamic b)
        {
            return beta(dcplx.t(a), dcplx.t(b));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/binomial/*' />
        public static Complex binomial(Complex n, Complex k)
        {
            return gamma(n + 1) / (gamma(k + 1) * gamma(n - k + 1));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/binomial/*' />
        public static Complex binomial(dynamic n, dynamic k)
        {
            return binomial(dcplx.t(n), dcplx.t(k));
        }



        #endregion




        #endregion







        #region Special Functions


        #region Conversions of parameters of elliptic functions


        public static Complex qfromtau(Complex tau)
        {
            return EllipticFunctions.qfromtau(tau);
        }


        public static Complex taufromq(Complex q)
        {
            return EllipticFunctions.qfromtau(q);
        }

        public static Complex taufromq(Double q)
        {
            return EllipticFunctions.qfromtau(q);
        }



        /// <summary>
        /// Jacobi amplitude function in terms of tau
        /// </summary>
        public static Complex jacobi_am_t(Complex u, Complex tau)
        {
            return EllipticFunctions.Am(u, tau, 0, "tau");
        }


        /// <summary>
        /// Jacobi amplitude function in terms of m
        /// </summary>
        public static Complex jacobi_am_m(Complex u, Complex m)
        {
            return EllipticFunctions.Am(u, 0, m, "m");
        }



        #endregion



        #region Carlson symmetric elliptic integrals



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticRc/*' />
        public static Complex elliptic_rc(Complex x, Complex y)
        {
            return EllipticFunctions.CarlsonRC(x, y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticRf/*' />
        public static Complex elliptic_rf(dynamic x, dynamic y)
        {
            return elliptic_rc(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticRf/*' />
        public static Complex elliptic_rf(Complex x, Complex y, Complex z)
        {
            return EllipticFunctions.CarlsonRF(x, y, z);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticRf/*' />
        public static Complex elliptic_rf(dynamic x, dynamic y, dynamic z)
        {
            return elliptic_rf(t(x), t(y), t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticRf/*' />
        public static Complex elliptic_rg(Complex x, Complex y, Complex z)
        {
            return EllipticFunctions.CarlsonRG(x, y, z);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticRg/*' />
        public static Complex elliptic_rg(dynamic x, dynamic y, dynamic z)
        {
            return elliptic_rg(t(x), t(y), t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticRf/*' />
        public static Complex elliptic_rd(Complex x, Complex y, Complex z)
        {
            return EllipticFunctions.CarlsonRD(x, y, z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticRd/*' />
        public static Complex elliptic_rd(dynamic x, dynamic y, dynamic z)
        {
            return elliptic_rd(t(x), t(y), t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticRj/*' />
        public static Complex elliptic_rj(Complex x, Complex y, Complex z, Complex p)
        {
            return EllipticFunctions.CarlsonRJ(x, y, z, p);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticRj/*' />
        public static Complex elliptic_rj(dynamic x, dynamic y, dynamic z, dynamic p)
        {
            return elliptic_rj(t(x), t(y), t(z), t(p));
        }






        #endregion




        #region Legendre elliptic integrals (elliptic parameter m)




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/m_elliptic_k/*' />
        public static Complex m_elliptic_k(Complex m)
        {
            return EllipticFunctions.EllipticK(m);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/m_elliptic_k/*' />
        public static Complex m_elliptic_k(dynamic m)
        {
            return m_elliptic_k(t(m));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticE/*' />
        public static Complex m_elliptic_e(Complex m)
        {
            return EllipticFunctions.EllipticE(m);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticE/*' />
        public static Complex m_elliptic_e(dynamic m)
        {
            return m_elliptic_e(t(m));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticPi/*' />
        public static Complex m_elliptic_pi(Complex n, Complex m)
        {
            Complex pio2 = (Math.PI * Complex.One / 2) - 1.0E-5;
            return EllipticFunctions.EllipticPI(pio2, n, m);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticPi/*' />
        public static Complex m_elliptic_pi(dynamic n, dynamic m)
        {
            return m_elliptic_pi(dcplx.t(n), dcplx.t(m));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticF/*' />
        public static Complex m_elliptic_f(Complex phi, Complex m)
        {
            return EllipticFunctions.EllipticF(phi, m);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticPi/*' />
        public static Complex m_elliptic_f(dynamic phi, dynamic m)
        {
            return m_elliptic_f(t(phi), t(m));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticF/*' />
        public static Complex m_elliptic_e_inc(Complex phi, Complex m)
        {
            return EllipticFunctions.EllipticE(phi, m);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticF/*' />
        public static Complex m_elliptic_e_inc(dynamic phi, dynamic m)
        {
            return m_elliptic_e_inc(t(phi), t(m));
        }






        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticEPinc/*' />
        public static Complex m_elliptic_pi_inc(Complex n, Complex phi, Complex m)
        {
            return EllipticFunctions.EllipticPI(phi, n, m);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticPiInc/*' />
        public static Complex m_elliptic_pi_inc(dynamic n, dynamic phi, dynamic m)
        {
            return m_elliptic_pi_inc(t(n), t(phi), t(m));
        }



        ///// <summary>
        ///// Jacobi zeta function with parameter m
        ///// </summary>
        //public static Complex m_elliptic_z(Complex phi, Complex m)
        //{
        //    return EllipticFunctions.EllipticZ(phi, m);
        //}

        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticPi/*' />
        //public static Complex m_elliptic_z(dynamic phi, dynamic m)
        //{
        //    return m_elliptic_z(t(phi), t(m));
        //}




        #endregion



        #region Legendre elliptic integrals (elliptic modulus k), and related functions



        /// <summary>
        /// Returns w = K(k), the complete elliptic integral of the first kind
        /// </summary>
        public static Complex elliptic_k(Complex k)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cellk(k.Real, k.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cellk", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cellk(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns w = K(k), the complete elliptic integral of the first kind
        /// </summary>
        public static Complex elliptic_k(dynamic k)
        {
            return elliptic_k(t(k));
        }




        /// <summary>
        /// Returns w = K'(k), the complementary complete elliptic integral of the first kind
        /// </summary>
        public static Complex elliptic_ck(Complex k)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cellck(k.Real, k.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cellck", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cellck(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns w = K'(k), the complementary complete elliptic integral of the first kind
        /// </summary>
        public static Complex elliptic_ck(dynamic k)
        {
            return elliptic_ck(t(k));
        }



        /// <summary>
        /// Returns w = E(k), the complete elliptic integral of the second kind
        /// </summary>
        public static Complex elliptic_e(Complex k)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_celle(k.Real, k.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_celle", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_celle(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns w = E(k), the complete elliptic integral of the second kind
        /// </summary>
        public static Complex elliptic_e(dynamic k)
        {
            return elliptic_e(t(k));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_b/*' />
        public static Complex elliptic_b(Complex k)
        {
            return (elliptic_e(k) - sqrt(1 - k * k) * elliptic_k(k)) / (k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_b/*' />
        public static Complex elliptic_b(dynamic k)
        {
            return elliptic_b(dcplx.t(k));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_d/*' />
        public static Complex elliptic_d(Complex k)
        {
            return (elliptic_k(k) - elliptic_e(k)) / (k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_b/*' />
        public static Complex elliptic_d(dynamic k)
        {
            return elliptic_d(dcplx.t(k));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_b_inc/*' />
        public static Complex elliptic_b_inc(Complex phi, Complex k)
        {
            return (elliptic_e_inc(phi, k) - sqrt(1 - k * k) * elliptic_f(phi, k)) / (k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_b_inc/*' />
        public static Complex elliptic_b_inc(dynamic phi, dynamic k)
        {
            return elliptic_b_inc(dcplx.t(phi), dcplx.t(k));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_d_inc/*' />
        public static Complex elliptic_d_inc(Complex phi, Complex k)
        {
            return (elliptic_f(phi, k) - elliptic_e_inc(phi, k)) / (k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_d_inc/*' />
        public static Complex elliptic_d_inc(dynamic phi, dynamic k)
        {
            return elliptic_d_inc(dcplx.t(phi), dcplx.t(k));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_zeta/*' />
        public static Complex jacobi_zeta(Complex phi, Complex k)
        {
            return elliptic_e_inc(phi, k) - elliptic_f(phi, k) * elliptic_e(k) / elliptic_k(k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_zeta/*' />
        public static Complex jacobi_zeta(dynamic phi, dynamic k)
        {
            return jacobi_zeta(dcplx.t(phi), dcplx.t(k));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/heuman_lambda/*' />
        public static Complex heuman_lambda(Complex phi, Complex k)
        {
            Complex ks = sqrt(1 - k * k);
            return elliptic_f(phi, ks) / elliptic_k(ks) + (2 / dreal.pi()) * elliptic_k(k) * jacobi_zeta(phi, ks);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/heuman_lambda/*' />
        public static Complex heuman_lambda(dynamic phi, dynamic k)
        {
            return heuman_lambda(dcplx.t(phi), dcplx.t(k));
        }








        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_pi/*' />
        public static Complex elliptic_pi(Complex n, Complex k)
        {
            return EllipticFunctions.EllipticPI(Math.PI * 1.0 / 2, n, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_pi/*' />
        public static Complex elliptic_pi(dynamic n, dynamic k)
        {
            return m_elliptic_pi(t(n), t(k));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_f/*' />
        public static Complex elliptic_f(Complex phi, Complex k)
        {
            return EllipticFunctions.EllipticF(phi, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_f/*' />
        public static Complex elliptic_f(dynamic phi, dynamic k)
        {
            return m_elliptic_f(t(phi), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_e_inc/*' />
        public static Complex elliptic_e_inc(Complex phi, Complex k)
        {
            return EllipticFunctions.EllipticE(phi, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_e_inc/*' />
        public static Complex elliptic_e_inc(dynamic phi, dynamic k)
        {
            return m_elliptic_e_inc(t(phi), t(k));
        }






        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_pi_inc/*' />
        public static Complex elliptic_pi_inc(Complex n, Complex phi, Complex k)
        {
            return EllipticFunctions.EllipticPI(phi, n, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/elliptic_pi_inc/*' />
        public static Complex elliptic_pi_inc(dynamic n, dynamic phi, dynamic k)
        {
            return m_elliptic_pi_inc(t(n), t(phi), t(k));
        }











        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Agm/*' />
        public static Complex agm(Complex z1, Complex z2)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cagm(z1.Real, z1.Imaginary, z2.Real, z2.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cagm", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cagm(Double x_re, Double x_im, Double y_re, Double y_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Agm/*' />
        public static Complex agm(dynamic z1, dynamic z2)
        {
            return agm(t(z1), t(z2));
        }


        /// <summary>
        /// Returns the 'optimal' arithmetic-geometric mean w = AGM(1,z)
        /// </summary>
        public static Complex agm1(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cagm1(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cagm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cagm1(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the 'optimal' arithmetic-geometric mean w = AGM(1,z)
        /// </summary>
        public static Complex agm1(dynamic z1)
        {
            return agm1(t(z1));
        }



        #endregion



        #region Additional elliptic integrals and functions




        #endregion






        #region Jacobi elliptic functions, k complex


        /// <summary>
        /// Jacobi elliptic functions in terms of tau
        /// </summary>
        public static Complex jellip_t(string kind, Complex u, Complex tau)
        {
            return EllipticFunctions.jellip(kind, u, tau, dcplx.nan(), "tau");
        }


        /// <summary>
        /// Jacobi elliptic functions in terms of m
        /// </summary>
        public static Complex jellip_m(string kind, Complex u, Complex m)
        {
            return EllipticFunctions.jellip(kind, u, dcplx.nan(), m, "m");
        }




        #endregion



        #region Jacobi elliptic functions, x complex, k real or complex



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_sn/*' />
        public static Complex jacobi_sn(Complex x, Double k)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_csn(x.Real, x.Imaginary, k, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_csn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_csn(Double x_re, Double x_im, Double k, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_sn/*' />
        public static Complex jacobi_sn(Complex x, Complex k)
        {
            if (k.Imaginary == 0) return jacobi_sn(x, k.Real);
            else return jellip_m("sn", x, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_sn/*' />
        public static Complex jacobi_sn(dynamic x, dynamic k)
        {
            return jacobi_sn(t(x), t(k));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_cn/*' />
        public static Complex jacobi_cn(Complex x, Double k)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_ccn(x.Real, x.Imaginary, k, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ccn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_ccn(Double x_re, Double x_im, Double k, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_cn/*' />
        public static Complex jacobi_cn(Complex x, Complex k)
        {
            if (k.Imaginary == 0) return jacobi_cn(x, k.Real);
            else return jellip_m("cn", x, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_cn/*' />
        public static Complex jacobi_cn(dynamic x, dynamic k)
        {
            return jacobi_cn(t(x), t(k));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_dn/*' />
        public static Complex jacobi_dn(Complex x, Double k)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cdn(x.Real, x.Imaginary, k, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cdn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cdn(Double x_re, Double x_im, Double k, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_dn/*' />
        public static Complex jacobi_dn(Complex x, Complex k)
        {
            if (k.Imaginary == 0) return jacobi_dn(x, k.Real);
            else return jellip_m("dn", x, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_dn/*' />
        public static Complex jacobi_dn(dynamic x, dynamic k)
        {
            return jacobi_dn(t(x), t(k));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_ns/*' />
        public static Complex jacobi_ns(Complex x, Complex k)
        {
            return jellip_m("ns", x, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_ns/*' />
        public static Complex jacobi_ns(dynamic x, dynamic k)
        {
            return jacobi_ns(t(x), t(k));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_nc/*' />
        public static Complex jacobi_nc(Complex x, Complex k)
        {
            return jellip_m("nc", x, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_nc/*' />
        public static Complex jacobi_nc(dynamic x, dynamic k)
        {
            return jacobi_nc(t(x), t(k));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_nd/*' />
        public static Complex jacobi_nd(Complex x, Complex k)
        {
            return jellip_m("nd", x, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_nd/*' />
        public static Complex jacobi_nd(dynamic x, dynamic k)
        {
            return jacobi_nd(t(x), t(k));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_sc/*' />
        public static Complex jacobi_sc(Complex x, Complex k)
        {
            return jellip_m("sc", x, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_sc/*' />
        public static Complex jacobi_sc(dynamic x, dynamic k)
        {
            return jacobi_sc(t(x), t(k));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_sd/*' />
        public static Complex jacobi_sd(Complex x, Complex k)
        {
            return jellip_m("sd", x, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_sd/*' />
        public static Complex jacobi_sd(dynamic x, dynamic k)
        {
            return jacobi_sd(t(x), t(k));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_dc/*' />
        public static Complex jacobi_dc(Complex x, Complex k)
        {
            return jellip_m("dc", x, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_dc/*' />
        public static Complex jacobi_dc(dynamic x, dynamic k)
        {
            return jacobi_dc(t(x), t(k));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_ds/*' />
        public static Complex jacobi_ds(Complex x, Complex k)
        {
            return jellip_m("ds", x, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_ds/*' />
        public static Complex jacobi_ds(dynamic x, dynamic k)
        {
            return jacobi_ds(t(x), t(k));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_cs/*' />
        public static Complex jacobi_cs(Complex x, Complex k)
        {
            return jellip_m("cs", x, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_cs/*' />
        public static Complex jacobi_cs(dynamic x, dynamic k)
        {
            return jacobi_cs(t(x), t(k));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_cd/*' />
        public static Complex jacobi_cd(Complex x, Complex k)
        {
            return jellip_m("cd", x, k * k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_cd/*' />
        public static Complex jacobi_cd(dynamic x, dynamic k)
        {
            return jacobi_cd(t(x), t(k));
        }













        #endregion



        #region Inverses of Jacobi elliptic functions




        #endregion



        #region Jacobi theta functions, in terms of q


        /// <summary>
        /// First Jacobi theta function.
        /// </summary>
        public static Complex jacobi_theta1(Complex z, Complex q)
        {
            return EllipticFunctions.jtheta1(z, q);
        }


        /// <summary>
        /// Second Jacobi theta function.
        /// </summary>
        public static Complex jacobi_theta2(Complex z, Complex q)
        {
            return EllipticFunctions.jtheta2(z, q);
        }


        /// <summary>
        /// Third Jacobi theta function.
        /// </summary>
        public static Complex jacobi_theta3(Complex z, Complex q)
        {
            return EllipticFunctions.jtheta3(z, q);
        }


        /// <summary>
        /// Fourth Jacobi theta function.
        /// </summary>
        public static Complex jacobi_theta4(Complex z, Complex q)
        {
            return EllipticFunctions.jtheta4(z, q);
        }


        /// <summary>
        /// Derivative of the first Jacobi theta function.
        /// </summary>
        public static Complex jtheta1dash(Complex z, Complex q)
        {
            return EllipticFunctions.jtheta1dash(z, q);
        }




        #endregion




        #region Jacobi theta functions, in terms of tau


        /// <summary>
        /// First Jacobi theta function.
        /// </summary>
        public static Complex jtheta1_tau(Complex z, Complex tau)
        {
            return EllipticFunctions._jtheta1_raw(z, tau);
        }


        /// <summary>
        /// Second Jacobi theta function.
        /// </summary>
        public static Complex jtheta2_tau(Complex z, Complex tau)
        {
            return EllipticFunctions._jtheta2_raw(z, tau);
        }


        /// <summary>
        /// Third Jacobi theta function.
        /// </summary>
        public static Complex jtheta3_tau(Complex z, Complex tau)
        {
            return EllipticFunctions._jtheta3_raw(z, tau);
        }


        /// <summary>
        /// Fourth Jacobi theta function.
        /// </summary>
        public static Complex jtheta4_tau(Complex z, Complex tau)
        {
            return EllipticFunctions._jtheta4_raw(z, tau);
        }


        /// <summary>
        /// Derivative of the first Jacobi theta function.
        /// </summary>
        public static Complex jtheta1dash_tau(Complex z, Complex tau)
        {
            return EllipticFunctions._jtheta1dash(z, tau);
        }




        #endregion










        #region Neville theta functions


        /// <summary>
        /// Neville S-theta function, in terms of tau
        /// </summary>
        public static Complex thetaS_t(Complex z, Complex tau)
        {
            return EllipticFunctions.thetaS(z, tau, 0, "tau");
        }

        /// <summary>
        /// Neville S-theta function, in terms of m
        /// </summary>
        public static Complex thetaS_m(Complex z, Complex m)
        {
            return EllipticFunctions.thetaS(z, 0, m, "m");
        }



        /// <summary>
        /// Neville C-theta function, in terms of tau
        /// </summary>
        public static Complex thetaC_t(Complex z, Complex tau)
        {
            return EllipticFunctions.thetaC(z, tau, 0, "tau");
        }

        /// <summary>
        /// Neville S-theta function, in terms of m
        /// </summary>
        public static Complex thetaC_m(Complex z, Complex m)
        {
            return EllipticFunctions.thetaC(z, 0, m, "m");
        }



        /// <summary>
        /// Neville D-theta function, in terms of tau
        /// </summary>
        public static Complex thetaD_t(Complex z, Complex tau)
        {
            return EllipticFunctions.thetaD(z, tau, 0, "tau");
        }

        /// <summary>
        /// Neville D-theta function, in terms of m
        /// </summary>
        public static Complex thetaD_m(Complex z, Complex m)
        {
            return EllipticFunctions.thetaD(z, 0, m, "m");
        }



        /// <summary>
        /// Neville N-theta function, in terms of tau
        /// </summary>
        public static Complex thetaN_t(Complex z, Complex tau)
        {
            return EllipticFunctions.thetaN(z, tau, 0, "tau");
        }

        /// <summary>
        /// Neville N-theta function, in terms of m
        /// </summary>
        public static Complex thetaN_m(Complex z, Complex m)
        {
            return EllipticFunctions.thetaN(z, 0, m, "m");
        }





        #endregion




        #region Lemniscate functions



        #endregion


        #region Conversions of parameters of Weierstrass P

        /// <summary>
        /// Half-periods omega_1 and omega_2 from the elliptic invariants.
        /// </summary>
        /// <param name="g2">Weierstrass elliptic invariant, real or complex number</param>
        /// <param name="g3">Weierstrass elliptic invariant, real or complex number</param>
        //public static (Complex, Complex) halfPeriods(Complex g2, Complex g3)
        public static Tuple<Complex, Complex> halfPeriods(Complex g2, Complex g3)
        {
            return EllipticFunctions.halfPeriods(g2, g3);
        }


        /// <summary>
        /// Weierstrass elliptic invariants g_2 and g_3 from the half-periods.
        /// </summary>
        /// <param name="omega1">Weierstrass half period, real or complex number</param>
        /// <param name="omega2">Weierstrass half period, real or complex number</param>
        public static Tuple<Complex, Complex> ellipticInvariants(Complex omega1, Complex omega2)
        {
            return EllipticFunctions.ellipticInvariants(omega1, omega2);
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticInvariantG2G3/*' />
        public static Tuple<Complex, Complex> elliptic_invariants_from_roots(Complex e1, Complex e2)
        {
            Complex e3 = -e1 - e2;
            Complex g2 = 2 * (e1 * e1 + e2 * e2 + e3 * e3);
            Complex g3 = 4 * e1 * e2 * e3;
            return new Tuple<Complex, Complex>(g2, g3);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticInvariantG2G3/*' />
        public static Tuple<Complex, Complex> elliptic_invariants_from_roots(dynamic e1, dynamic e2)
        {
            return elliptic_invariants_from_roots(dcplx.t(e1), dcplx.t(e2));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticInvariantG2G3/*' />
        public static Tuple<Complex, Complex> elliptic_invariants_from_tau(Complex tau)
        {
            return EllipticFunctions.ellipticInvariants(0.5, 0.5 * tau);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/EllipticInvariantG2G3/*' />
        public static Tuple<Complex, Complex> elliptic_invariants_from_tau(dynamic tau)
        {
            return elliptic_invariants_from_tau(dcplx.t(tau));
        }



        #endregion


        #region Weierstrass elliptic functions, in terms of(real) lattice invariants g2, g3

        /// <summary>
        /// Weierstrass p-function in terms of g2 und g3
        /// </summary>
        public static Complex weierstrass_p_g(Complex z, Complex g2, Complex g3)
        {
            return EllipticFunctions.wp(z, 0, 0, 0, g2, g3, 0, "g2g3");
        }

        /// <summary>
        /// Weierstrass p-function, first drivative, in terms of g2 und g3
        /// </summary>
        public static Complex weierstrass_pprime_g(Complex z, Complex g2, Complex g3)
        {
            return EllipticFunctions.wp(z, 0, 0, 0, g2, g3, 1, "g2g3");
        }

        /// <summary>
        /// Weierstrass zeta-function in terms of g2 und g3
        /// </summary>
        public static Complex weierstrass_zeta_g(Complex z, Complex g2, Complex g3)
        {
            return EllipticFunctions.wzeta(z, 0, 0, 0, g2, g3, 0, "g2g3");
        }

        /// <summary>
        /// Weierstrass sigma-function in terms of g2 und g3
        /// </summary>
        public static Complex weierstrass_sigma_g(Complex z, Complex g2, Complex g3)
        {
            return EllipticFunctions.wsigma(z, 0, 0, 0, g2, g3, 0, "g2g3");
        }


        #endregion



        #region Weierstrass elliptic functions, in terms of(real) lattice roots e1 and e2


        /// <summary>
        /// Weierstrass p-function in terms of lattice roots e1 and e2
        /// </summary>
        public static Complex weierstrass_p_e(Complex z, Complex e1, Complex e2)
        {
            Complex e3 = -e1 - e2;
            Complex g2 = 2 * (e1 * e1 + e2 * e2 + e3 * e3);
            Complex g3 = 4 * e1 * e2 * e3;
            return weierstrass_p_g(z, g2, g3);
        }


        /// <summary>
        /// Weierstrass p-function, first drivative, in terms of lattice roots e1 and e2
        /// </summary>
        public static Complex weierstrass_pprime_e(Complex z, Complex e1, Complex e2)
        {
            Complex e3 = -e1 - e2;
            Complex g2 = 2 * (e1 * e1 + e2 * e2 + e3 * e3);
            Complex g3 = 4 * e1 * e2 * e3;
            return weierstrass_pprime_g(z, g2, g3);
        }


        /// <summary>
        /// Weierstrass sigma-function in terms of lattice roots e1 and e2
        /// </summary>
        public static Complex weierstrass_sigma_e(Complex z, Complex e1, Complex e2)
        {
            Complex e3 = -e1 - e2;
            Complex g2 = 2 * (e1 * e1 + e2 * e2 + e3 * e3);
            Complex g3 = 4 * e1 * e2 * e3;
            return weierstrass_sigma_g(z, g2, g3);
        }


        /// <summary>
        /// Weierstrass zeta-function in terms of lattice roots e1 and e2
        /// </summary>
        public static Complex weierstrass_zeta_e(Complex z, Complex e1, Complex e2)
        {
            Complex e3 = -e1 - e2;
            Complex g2 = 2 * (e1 * e1 + e2 * e2 + e3 * e3);
            Complex g3 = 4 * e1 * e2 * e3;
            return weierstrass_zeta_g(z, g2, g3);
        }


        #endregion




        #region Weierstrass elliptic functions, in terms of half-period omega1 and omega2


        /// <summary>
        /// Weierstrass p-function in terms of omega1 und omega2
        /// </summary>
        public static Complex weierstrass_p_o(Complex z, Complex omega1, Complex omega2)
        {
            return EllipticFunctions.wp(z, 0, omega1, omega2, 0, 0, 0, "omega");
        }


        /// <summary>
        /// Weierstrass p-function, first drivative, in terms of omega1 und omega2
        /// </summary>
        public static Complex weierstrass_pprime_o(Complex z, Complex omega1, Complex omega2)
        {
            return EllipticFunctions.wp(z, 0, omega1, omega2, 0, 0, 1, "omega");
        }

        /// <summary>
        /// Weierstrass sigma-function in terms of omega1 und omega2
        /// </summary>
        public static Complex weierstrass_sigma_o(Complex z, Complex omega1, Complex omega2)
        {
            return EllipticFunctions.wsigma(z, 0, omega1, omega2, 0, 0, 0, "omega");
        }

        /// <summary>
        /// Weierstrass zeta-function in terms of omega1 und omega2
        /// </summary>
        public static Complex weierstrass_zeta_o(Complex z, Complex omega1, Complex omega2)
        {
            return EllipticFunctions.wzeta(z, 0, omega1, omega2, 0, 0, 0, "omega");
        }






        #endregion





        #region Weierstrass elliptic functions, in terms of elliptic period ratio tau

        /// <summary>
        /// Weierstrass p-function in terms of tau
        /// </summary>
        public static Complex weierstrass_p_t(Complex z, Complex tau)
        {
            return EllipticFunctions.wp(z, tau, 0, 0, 0, 0, 0, "tau");
        }


        /// <summary>
        /// Weierstrass p-function, first drivative, in terms of tau
        /// </summary>
        public static Complex weierstrass_pprime_t(Complex z, Complex tau)
        {
            return EllipticFunctions.wp(z, tau, 0, 0, 0, 0, 1, "tau");
        }


        /// <summary>
        /// Weierstrass sigma-function in terms of tau
        /// </summary>
        public static Complex weierstrass_sigma_t(Complex z, Complex tau)
        {
            return EllipticFunctions.wsigma(z, tau, 0, 0, 0, 0, 0, "tau");
        }

        /// <summary>
        /// Weierstrass zeta-function in terms of tau
        /// </summary>
        public static Complex weierstrass_zeta_t(Complex z, Complex tau)
        {
            return EllipticFunctions.wzeta(z, tau, 0, 0, 0, 0, 0, "tau");
        }



        #endregion



        #region OLD: Weierstrass elliptic functions, in terms of (real) lattice invariants g2, g3



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/WeierstrassP/*' />
        public static Complex WeierstrassP(Double g2, Double g3, Complex z)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_weierstrass_p(g2, g3, z.Real, z.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_weierstrass_p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_weierstrass_p(Double g2, Double g3, Double z_re, Double z_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/WeierstrassP/*' />
        public static Complex WeierstrassP(Double g2, Double g3, dynamic z1)
        {
            return WeierstrassP(g2, g3, t(z1));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/WeierstrassPPrime/*' />
        public static Complex WeierstrassPPrime(Double g2, Double g3, Complex z)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_weierstrass_pprime(g2, g3, z.Real, z.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_weierstrass_pprime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_weierstrass_pprime(Double g2, Double g3, Double z_re, Double z_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/WeierstrassPPrime/*' />
        public static Complex WeierstrassPPrime(Double g2, Double g3, dynamic z1)
        {
            return WeierstrassPPrime(g2, g3, t(z1));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/WeierstrassPZeta/*' />
        public static Complex WeierstrassZeta(Double g2, Double g3, Complex z)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_weierstrass_zeta(g2, g3, z.Real, z.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_weierstrass_zeta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_weierstrass_zeta(Double g2, Double g3, Double z_re, Double z_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/WeierstrassPZeta/*' />
        public static Complex WeierstrassZeta(Double g2, Double g3, dynamic z1)
        {
            return WeierstrassZeta(g2, g3, t(z1));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/WeierstrassPSigma/*' />
        public static Complex WeierstrassSigma(Double g2, Double g3, Complex z)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_weierstrass_sigma(g2, g3, z.Real, z.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_weierstrass_sigma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_weierstrass_sigma(Double g2, Double g3, Double z_re, Double z_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/WeierstrassPSigma/*' />
        public static Complex WeierstrassSigma(Double g2, Double g3, dynamic z1)
        {
            return WeierstrassSigma(g2, g3, t(z1));
        }






        #endregion




        #region Modular forms



        /// <summary>
        /// Dedekind eta function.
        /// </summary>
        public static Complex dedekind_eta(Complex tau)
        {
            return EllipticFunctions.etaDedekind(tau);
        }


        /// <summary>
        /// Dedekind eta function.
        /// </summary>
        public static Complex modular_delta(Complex tau)
        {
            return 1 * Complex.Pow(EllipticFunctions.etaDedekind(tau), 24);
            //return 4096 * Math.Pow(Math.PI, 12) * Complex.Pow(EllipticFunctions.lambda(tau), 24);
        }


        /// <summary>
        /// Dedekind eta function.
        /// </summary>
        public static Complex modular_lambda(Complex tau)
        {
            return EllipticFunctions.lambda(tau);
        }


        /// <summary>
        /// Klein j-invariant function.
        /// </summary>
        public static Complex klein_j(Complex tau)
        {
            return EllipticFunctions.kleinj(tau);
        }



        /// <summary>
        /// Inverse of the Klein j-invariant function.
        /// </summary>
        /// <param name="j">real or complex number</param>
        public static Complex klein_j_inv(Complex j)
        {
            return EllipticFunctions.kleinjinv(j);
        }

        // Omitted: EisensteinE2
        // Omitted: EisensteinE4
        // Omitted: EisensteinE6



        #endregion



        #region Lerch’s transcendent: Overview



        #endregion



        #region polygamma functions

        /// <summary>
        /// Returns the complex polygamma function
        /// </summary>
        public static Complex polygamma(int m, Complex z)
        {
            return HurwitzZetaPolygamma.polygamma(m, z);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polygamma/*' />
        public static Complex polygamma(int n, dynamic z1)
        {
            return polygamma(n, t(z1));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polygamma/*' />
        public static Complex polygamma(Complex s, Complex z)
        {
            if ((s.Imaginary != 0.0) || (!dreal.isinteger(s.Real))) { return dcplx.nan(); }
            int n = dreal.lrint(s.Real);
            return polygamma(n, z);
        }



        /// <summary>
        /// Returns the complex trigamma function w = psi(z), z &#8800; 0,-1,-2...
        /// </summary>
        public static Complex trigamma(Complex z)
        {
            return polygamma(1, z);
        }

        /// <summary>
        /// Returns the complex digamma function w = psi(z), z &#8800; 0,-1,-2...
        /// </summary>
        public static Complex trigamma(dynamic z1)
        {
            return trigamma(t(z1));
        }



        /// <summary>
        /// Returns the complex digamma function w = psi(z), z &#8800; 0,-1,-2...
        /// </summary>
        public static Complex digamma(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cpsi(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cpsi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cpsi(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex digamma function w = psi(z), z &#8800; 0,-1,-2...
        /// </summary>
        public static Complex digamma(dynamic z1)
        {
            return digamma(t(z1));
        }



        public static Complex harmonic(Complex z1)
        {
            return digamma(z1 + 1) + dreal.egamma();
        }

        public static Complex harmonic(dynamic z1)
        {
            return harmonic(t(z1));
        }



        #endregion



        #region Polylogarithms and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polylog/*' />
        public static Complex polylog(int n, Complex z)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_polylog(n, z.Real, z.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_polylog", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_polylog(int n, Double z_re, Double z_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polylog/*' />
        public static Complex polylog(int n, dynamic z1)
        {
            return polylog(n, t(z1));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polylog/*' />
        public static Complex polylog(Complex s, Complex z)
        {
            if ((s.Imaginary != 0.0) || (!dreal.isinteger(s.Real))) { return dcplx.nan(); }
            int n = dreal.lrint(s.Real);
            return polylog(n, z);
        }




        /// <summary>
        /// Returns the principal branch of the complex trilogarithm 
        /// </summary>
        public static Complex trilog(Complex z1)
        {
            return polylog(3, z1);
        }

        /// <summary>
        /// Returns the principal branch of the complex dilogarithm w = -integral(ln(1-t)/t, t=0..z)
        /// </summary>
        public static Complex trilog(dynamic z1)
        {
            return trilog(t(z1));
        }



        /// <summary>
        /// Returns the principal branch of the complex dilogarithm w = -integral(ln(1-t)/t, t=0..z)
        /// </summary>
        public static Complex dilog(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cdilog(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cdilog", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cdilog(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the principal branch of the complex dilogarithm w = -integral(ln(1-t)/t, t=0..z)
        /// </summary>
        public static Complex dilog(dynamic z1)
        {
            return dilog(t(z1));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/clausen_sin/*' />
        public static Complex clausen_sin(int n, Complex z)
        {
            var i = Complex.ImaginaryOne;
            return (polylog(n, exp(i * z)) - polylog(n, exp(-i * z))) / (2 * i);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/clausen_sin/*' />
        public static Complex clausen_sin(int n, dynamic z1)
        {
            return clausen_sin(n, t(z1));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/clausen_sin/*' />
        public static Complex clausen_sin(Complex s, Complex z)
        {
            if ((s.Imaginary != 0.0) || (!dreal.isinteger(s.Real))) { return dcplx.nan(); }
            int n = dreal.lrint(s.Real);
            return clausen_sin(n, z);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/clausen_cos/*' />
        public static Complex clausen_cos(int n, Complex z)
        {
            var i = Complex.ImaginaryOne;
            return (polylog(n, exp(i * z)) + polylog(n, exp(-i * z))) / (2);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/clausen_cos/*' />
        public static Complex clausen_cos(int n, dynamic z1)
        {
            return clausen_cos(n, t(z1));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/clausen_cos/*' />
        public static Complex clausen_cos(Complex s, Complex z)
        {
            if ((s.Imaginary != 0.0) || (!dreal.isinteger(s.Real))) { return dcplx.nan(); }
            int n = dreal.lrint(s.Real);
            return clausen_cos(n, z);
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/legendre_chi/*' />
        public static Complex legendre_chi(int n, Complex z)
        {
            return (polylog(n, z) - polylog(n, -z)) / (2);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/legendre_chi/*' />
        public static Complex legendre_chi(int n, dynamic z1)
        {
            return legendre_chi(n, t(z1));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/legendre_chi/*' />
        public static Complex legendre_chi(Complex s, Complex z)
        {
            if ((s.Imaginary != 0.0) || (!dreal.isinteger(s.Real))) { return dcplx.nan(); }
            int n = dreal.lrint(s.Real);
            return legendre_chi(n, z);
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bose_einstein/*' />
        public static Complex bose_einstein(int n, Complex z)
        {
            return polylog(n + 1, Complex.Exp(z));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bose_einstein/*' />
        public static Complex bose_einstein(int n, dynamic z1)
        {
            return bose_einstein(n, t(z1));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bose_einstein/*' />
        public static Complex bose_einstein(Complex s, Complex z)
        {
            if ((s.Imaginary != 0.0) || (!dreal.isinteger(s.Real))) { return dcplx.nan(); }
            int n = dreal.lrint(s.Real);
            return bose_einstein(n, z);
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fermi_dirac/*' />
        public static Complex fermi_dirac(int n, Complex z)
        {
            return -polylog(n + 1, -Complex.Exp(z));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fermi_dirac/*' />
        public static Complex fermi_dirac(int n, dynamic z1)
        {
            return fermi_dirac(n, t(z1));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fermi_dirac/*' />
        public static Complex fermi_dirac(Complex s, Complex z)
        {
            if ((s.Imaginary != 0.0) || (!dreal.isinteger(s.Real))) { return dcplx.nan(); }
            int n = dreal.lrint(s.Real);
            return fermi_dirac(n, z);
        }






        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/InverseTanIntegral/*' />
        public static Complex inverse_tan_integral(int n, Complex z)
        {
            var i = Complex.ImaginaryOne;
            return (polylog(n, i * z) - polylog(n, -i * z)) / (2 * i);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/InverseTanIntegral/*' />
        public static Complex inverse_tan_integral(int n, dynamic z1)
        {
            return inverse_tan_integral(n, t(z1));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/inverse_tan_integral/*' />
        public static Complex inverse_tan_integral(Complex s, Complex z)
        {
            if ((s.Imaginary != 0.0) || (!dreal.isinteger(s.Real))) { return dcplx.nan(); }
            int n = dreal.lrint(s.Real);
            return inverse_tan_integral(n, z);
        }



        #endregion



        #region Hurwitz zeta function and related functions



        public static Complex hurwitz_zeta(Complex s, Complex a)
        {
            Double ar = a.Real;
            int m = 0;
            Complex sum = dcplx.zero();
            if (ar < 0.0)
            {
                m = dreal.lrint(dreal.ceil(-ar));
                for (int n = 0; n < m; n++)
                {
                    sum = sum + 1 / Complex.Pow(n + a, s);
                }
            }
            return HurwitzZetaPolygamma.GenZeta(s, a + m) + sum;
        }

        public static Complex gen_zeta(Complex s, Complex a)
        {
            return HurwitzZetaPolygamma.GenZeta(s, a);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/harmonic2/*' />
        public static Complex harmonic2(Complex z, Complex r)
        {
            return zeta(r) - hurwitz_zeta(r, z + 1);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/harmonic2/*' />
        public static Complex harmonic2(dynamic z, dynamic r)
        {
            return harmonic2(t(z), t(r));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bernpoly/*' />
        public static Complex bernpoly(Complex z, Complex n)
        {
            return -n * hurwitz_zeta(1 - n, z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bernpoly/*' />
        public static Complex bernpoly(dynamic z, dynamic n)
        {
            return bernpoly(t(z), t(n));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/eulerpoly/*' />
        public static Complex eulerpoly(Complex z, Complex n_1)
        {
            Complex n = n_1 + 1;
            return (2 / n) * (bernpoly(z, n) - pow(2, n) * bernpoly(z / 2, n));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/eulerpoly/*' />
        public static Complex eulerpoly(dynamic z, dynamic n)
        {
            return eulerpoly(t(z), t(n));
        }





        #endregion






        #region Riemann zeta function, and related functions





        /// <summary>
        /// Returns the complex Riemann zeta function, w=zeta(s), s &#8800; 1
        /// </summary>
        public static Complex zeta(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_czeta(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_czeta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_czeta(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex Riemann zeta function, w=zeta(s), s &#8800; 1
        /// </summary>
        public static Complex zeta(dynamic z1)
        {
            return zeta(t(z1));
        }


        public static Complex zetam1(Complex s)
        {
            if (s.Real < 2.0) return zeta(s) - 1;
            else return hurwitz_zeta(s, 2);
        }

        public static Complex zetam1(dynamic s)
        {
            return zetam1(t(s));
        }


        public static Complex riemann_xi(Complex s)
        {
            if (s == dcplx.zero()) return dcplx.t(0.5, 0.0);
            else return 0.5 * s * (s - 1) * Complex.Pow(Math.PI, -s / 2) * gamma(s / 2) * zeta(s);
        }

        public static Complex riemann_xi(dynamic s)
        {
            return riemann_xi(t(s));
        }



        public static Complex dirichlet_eta(Complex s)
        {
            //return -exp2m1(1 - s) * zeta(s);
            return (1 - Complex.Pow(2, 1 - s)) * zeta(s);
        }

        public static Complex dirichlet_eta(dynamic s)
        {
            return dirichlet_eta(t(s));
        }



        public static Complex dirichlet_etam1(Complex s)
        {
            return zetam1(s) - (Complex.Pow(2, 1 - s)) * zeta(s);
        }

        public static Complex dirichlet_etam1(dynamic s)
        {
            return dirichlet_etam1(t(s));
        }



        public static Complex dirichlet_beta(Complex s)
        {
            return Complex.Pow(4, -s) * (hurwitz_zeta(s, 0.25) - hurwitz_zeta(s, 0.75));
        }

        public static Complex dirichlet_beta(dynamic s)
        {
            return dirichlet_beta(t(s));
        }



        public static Complex dirichlet_lambda(Complex s)
        {
            //return -exp2m1(- s) * zeta(s);
            //return (1 - Complex.Pow(2, - s)) * zeta(s);
            return -powm1(2, -s) * zeta(s);
        }

        public static Complex dirichlet_lambda(dynamic s)
        {
            return dirichlet_lambda(t(s));
        }






        /// <summary>
        /// Returns the Hardy (or Riemann-Siegel) theta  function
        /// </summary>
        public static Complex hardy_theta(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_crstheta(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_crstheta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_crstheta(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the Hardy (or Riemann-Siegel) theta  function
        /// </summary>
        public static Complex hardy_theta(dynamic z1)
        {
            return hardy_theta(t(z1));
        }



        /// <summary>
        /// Returns the Hardy (or Riemann-Siegel) Z  function
        /// </summary>
        public static Complex hardy_z(Complex t)
        {
            return exp(Complex.ImaginaryOne * hardy_theta(t)) * zeta(0.5 + Complex.ImaginaryOne * t);
        }

        /// <summary>
        /// Returns the Hardy (or Riemann-Siegel) Z  function
        /// </summary>
        public static Complex hardy_z(dynamic z1)
        {
            return hardy_z(t(z1));
        }






        #endregion



        #region Additional numbertheoretic functions



        #endregion








        #region 0F1: Overview



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom0F1/*' />
        public static Complex hyperg_0f1(Complex b, Complex z)
        {
            Complex res = dcplx.nan();
            if (b.Imaginary == 0.0)
            {
                res = bessel_iv(b - 1, 2 * sqrt(z));
                res = res * math53.gamma(b.Real) * pow(z, (1 - b) / 2);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom0F1/*' />
        public static Complex hyperg_0f1(dynamic b, dynamic z)
        {
            return hyperg_0f1(t(b), t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom0F1r/*' />
        public static Complex hyperg_0f1r(Complex b, Complex z)
        {
            Complex res = dcplx.nan();
            if (b.Imaginary == 0.0)
            {
                if (dreal.isinteger(b.Real) && (b.Real <= 0))
                {
                    Double n = b.Real;
                    res = hyperg_0f1(n + 2, z) * pow(z, n + 1) / math53.gamma(n + 2);
                }
                else res = hyperg_0f1(b, z) / math53.gamma(b.Real);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom0F1r/*' />
        public static Complex hyperg_0f1r(dynamic b, dynamic z)
        {
            return hyperg_0f1r(t(b), t(z));
        }


        #endregion




        #region Bessel functions and modified Bessel functions of general order



        internal static Complex bessel_jv_(Double v, Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_bessel_j(v, z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_bessel_j", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_bessel_j(Double v, Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        internal static Complex bessel_jve_(Double v, Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_bessel_je(v, z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_bessel_je", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_bessel_je(Double v, Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_jv/*' />
        public static Complex bessel_jv(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                if (scaled) res = bessel_jve_(v.Real, x); else res = bessel_jv_(v.Real, x);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_jv/*' />
        public static Complex bessel_jv(dynamic v, dynamic z1, bool scaled = false)
        {
            return bessel_jv(scplx.t(v), scplx.t(z1), scaled);
        }






        public static Complex bessel_yv_(Double v, Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_bessel_y(v, z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_bessel_y", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_bessel_y(Double v, Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        public static Complex bessel_yve_(Double v, Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_bessel_ye(v, z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_bessel_ye", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_bessel_ye(Double v, Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_yv/*' />
        public static Complex bessel_yv(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                if (scaled) res = bessel_yve_(v.Real, x); else res = bessel_yv_(v.Real, x);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_yv/*' />
        public static Complex bessel_yv(dynamic v, dynamic z1, bool scaled = false)
        {
            return bessel_yv(sreal.t(v), scplx.t(z1), scaled);
        }








        public static Complex bessel_iv_(Double v, Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_bessel_i(v, z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_bessel_i", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_bessel_i(Double v, Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        public static Complex bessel_ive_(Double v, Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_bessel_ie(v, z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_bessel_ie", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_bessel_ie(Double v, Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_iv/*' />
        public static Complex bessel_iv(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                if (scaled) res = bessel_ive_(v.Real, x); else res = bessel_iv_(v.Real, x);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_iv/*' />
        public static Complex bessel_iv(dynamic v, dynamic z1, bool scaled = false)
        {
            return bessel_iv(scplx.t(v), scplx.t(z1), scaled);
        }






        public static Complex bessel_kv_(Double v, Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_bessel_k(v, z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_bessel_k", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_bessel_k(Double v, Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        public static Complex bessel_kve_(Double v, Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_bessel_ke(v, z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_bessel_ke", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_bessel_ke(Double v, Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_kv/*' />
        public static Complex bessel_kv(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                if (scaled) res = bessel_kve_(v.Real, x); else res = bessel_kv_(v.Real, x);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_kv/*' />
        public static Complex bessel_kv(dynamic v, dynamic z1, bool scaled = false)
        {
            return bessel_kv(sreal.t(v), scplx.t(z1), scaled);
        }






        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_jv_prime/*' />
        public static Complex bessel_jv_prime(Complex nu, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (nu.Imaginary == 0.0)
            {
                return (bessel_jv(nu - 1, x, scaled) - bessel_jv(nu + 1, x, scaled)) / 2;
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_jv_prime/*' />
        public static Complex bessel_jv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_jv_prime(dcplx.t(nu), dcplx.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_yv_prime/*' />
        public static Complex bessel_yv_prime(Complex nu, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (nu.Imaginary == 0.0)
            {
                return (bessel_yv(nu - 1, x, scaled) - bessel_yv(nu + 1, x, scaled)) / 2;
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_yv_prime/*' />
        public static Complex bessel_yv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_yv_prime(dcplx.t(nu), dcplx.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_iv_prime/*' />
        public static Complex bessel_iv_prime(Complex nu, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (nu.Imaginary == 0.0)
            {
                return (bessel_iv(nu - 1, x, scaled) + bessel_iv(nu + 1, x, scaled)) / 2;
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_iv_prime/*' />
        public static Complex bessel_iv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_iv_prime(dcplx.t(nu), dcplx.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_kv_prime/*' />
        public static Complex bessel_kv_prime(Complex nu, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (nu.Imaginary == 0.0)
            {
                return -(bessel_kv(nu - 1, x, scaled) + bessel_kv(nu + 1, x, scaled)) / 2;
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/bessel_kv_prime/*' />
        public static Complex bessel_kv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_kv_prime(dreal.t(nu), dcplx.t(x), scaled);
        }








        #endregion






        #region Spherical Bessel functions




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_jn/*' />
        public static Complex sph_bessel_jn(Complex n, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (n.Imaginary == 0.0)
            {
                return bessel_jv(n + 0.5, x, scaled) / dcplx.sqrt(2 * x / dreal.pi());
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_jn/*' />
        public static Complex sph_bessel_jn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_jn(dcplx.t(n), dcplx.t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_yn/*' />
        public static Complex sph_bessel_yn(Complex n, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (n.Imaginary == 0.0)
            {
                return bessel_yv(n + 0.5, x, scaled) / dcplx.sqrt(2 * x / dreal.pi());
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_yn/*' />
        public static Complex sph_bessel_yn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_yn(dcplx.t(n), dcplx.t(x), scaled);
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_in/*' />
        public static Complex sph_bessel_in(Complex n, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (n.Imaginary == 0.0)
            {
                return bessel_iv(n + 0.5, x, scaled) / dcplx.sqrt(2 * x / dreal.pi());
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_in/*' />
        public static Complex sph_bessel_in(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_in(dcplx.t(n), dcplx.t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_kn/*' />
        public static Complex sph_bessel_kn(Complex n, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (n.Imaginary == 0.0)
            {
                return bessel_kv(n + 0.5, x) / dcplx.sqrt(2 * x / dreal.pi());
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_kn/*' />
        public static Complex sph_bessel_kn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_kn(dcplx.t(n), dcplx.t(x), scaled);
        }






        #endregion




        #region 0F1: Spherical Bessel functions, first derivative


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_jn_prime/*' />
        public static Complex sph_bessel_jn_prime(Complex n, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (n.Imaginary == 0.0)
            {
                if (dreal.abs(2 * n + 1) > dreal.t(0.1))
                    res = (n * sph_bessel_jn(n - 1, x, scaled) - (n + 1) * sph_bessel_jn(n + 1, x, scaled)) / (2 * n + 1);
                else
                    res = (sph_bessel_jn(n - 1, x, scaled) - (n + 1) * sph_bessel_jn(n, x, scaled) / x);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_jn_prime/*' />
        public static Complex sph_bessel_jn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_jn_prime(dcplx.t(n), dcplx.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_yn_prime/*' />
        public static Complex sph_bessel_yn_prime(Complex n, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (n.Imaginary == 0.0)
            {
                if (dreal.abs(2 * n + 1) > dreal.t(0.1))
                    res = (n * sph_bessel_yn(n - 1, x, scaled) - (n + 1) * sph_bessel_yn(n + 1, x, scaled)) / (2 * n + 1);
                else
                    res = (sph_bessel_yn(n - 1, x, scaled) - (n + 1) * sph_bessel_yn(n, x, scaled) / x);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_yn_prime/*' />
        public static Complex sph_bessel_yn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_yn_prime(dcplx.t(n), dcplx.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_in_prime/*' />
        public static Complex sph_bessel_in_prime(Complex n, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (n.Imaginary == 0.0)
            {
                if (dreal.abs(2 * n + 1) > dreal.t(0.1))
                    res = (n * sph_bessel_in(n - 1, x, scaled) + (n + 1) * sph_bessel_in(n + 1, x, scaled)) / (2 * n + 1);
                else
                    res = (sph_bessel_in(n - 1, x, scaled) - (n + 1) * sph_bessel_in(n, x, scaled) / x);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_in_prime/*' />
        public static Complex sph_bessel_in_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_in_prime(dcplx.t(n), dcplx.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_kn_prime/*' />
        public static Complex sph_bessel_kn_prime(Complex n, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (n.Imaginary == 0.0)
            {
                if (dreal.abs(2 * n + 1) > dreal.t(0.1))
                    res = -(n * sph_bessel_kn(n - 1, x, scaled) + (n + 1) * sph_bessel_kn(n + 1, x, scaled)) / (2 * n + 1);
                else
                    res = -sph_bessel_kn(n - 1, x, scaled) - (n + 1) * sph_bessel_kn(n, x, scaled) / x;
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_kn_prime/*' />
        public static Complex sph_bessel_kn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_kn_prime(dcplx.t(n), dcplx.t(x), scaled);
        }



        #endregion







        #region Hankel functions




        internal static Complex hankel_h1_(Double v, Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_hankel_1(v, z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_hankel_1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_hankel_1(Double v, Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        internal static Complex hankel_1e_(Double v, Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_hankel_1e(v, z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_hankel_1e", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_hankel_1e(Double v, Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hankel_h1/*' />
        public static Complex hankel_h1(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                if (scaled) res = hankel_1e_(v.Real, x); else res = hankel_h1_(v.Real, x);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hankel_h1/*' />
        public static Complex hankel_h1(dynamic v, dynamic z1, bool scaled = false)
        {
            return hankel_h1(scplx.t(v), scplx.t(z1), scaled);
        }



        public static Complex hankel_h2_(Double v, Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_hankel_2(v, z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_hankel_2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_hankel_2(Double v, Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        public static Complex hankel_2e_(Double v, Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_hankel_2e(v, z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_hankel_2e", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_hankel_2e(Double v, Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hankel_h2/*' />
        public static Complex hankel_h2(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                if (scaled) res = hankel_2e_(v.Real, x); else res = hankel_h2_(v.Real, x);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hankel_h2/*' />
        public static Complex hankel_h2(dynamic v, dynamic z1, bool scaled = false)
        {
            return hankel_h2(scplx.t(v), scplx.t(z1), scaled);
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h1/*' />
        public static Complex sph_hankel_h1(Complex n, Complex x, bool scaled = false)
        {
            var res = hankel_h1(n + 0.5, x, scaled) / dcplx.sqrt(2 * x / dreal.pi());
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h1/*' />
        public static Complex sph_hankel_h1(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_hankel_h1(dcplx.t(n), dcplx.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h2/*' />
        public static Complex sph_hankel_h2(Complex n, Complex x, bool scaled = false)
        {
            var res = hankel_h2(n + 0.5, x, scaled) / dcplx.sqrt(2 * x / dreal.pi());
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h2/*' />
        public static Complex sph_hankel_h2(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_hankel_h2(dcplx.t(n), dcplx.t(x), scaled);
        }







        #endregion



        #region Airy functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_ai/*' />
        public static Complex airy_ai(Complex z, bool scaled = false)
        {
            if (scaled) return airy_ai_scaled(z);
            else
            {
                Double res_re = 0.0, res_im = 0.0;
                Lib_xsf_cplx_airyai(1, z.Real, z.Imaginary, ref res_re, ref res_im);
                return new Complex(res_re, res_im);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_airyai", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_airyai(int Kode, Double z_re, Double z_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_ai/*' />
        public static Complex airy_ai(dynamic z)
        {
            return airy_ai(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_bi/*' />
        public static Complex airy_bi(Complex z, bool scaled = false)
        {
            if (scaled) return airy_bi_scaled(z);
            else
            {
                Double res_re = 0.0, res_im = 0.0;
                Lib_xsf_cplx_airybi(1, z.Real, z.Imaginary, ref res_re, ref res_im);
                return new Complex(res_re, res_im);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_airybi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_airybi(int Kode, Double z_re, Double z_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_bi/*' />
        public static Complex airy_bi(dynamic z)
        {
            return airy_bi(t(z));
        }



        /// <summary>
        /// Returns the complex function airy_ai_scaled.
        /// </summary>
        public static Complex airy_ai_scaled(Complex z)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_airyai(2, z.Real, z.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }

        /// <summary>
        /// Returns the complex function airy_ai_scaled.
        /// </summary>
        public static Complex airy_ai_scaled(dynamic z)
        {
            return airy_ai_scaled(t(z));
        }



        /// <summary>
        /// Returns the complex function airy_bi_scaled.
        /// </summary>
        public static Complex airy_bi_scaled(Complex z)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_airybi(2, z.Real, z.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }

        /// <summary>
        /// Returns the complex function airy_bi_scaled.
        /// </summary>
        public static Complex airy_bi_scaled(dynamic z)
        {
            return airy_bi_scaled(t(z));
        }









        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_ai_prime/*' />
        public static Complex airy_ai_prime(Complex z, bool scaled = false)
        {
            if (scaled) return airy_ai_scaled_prime(z);
            else
            {
                Double res_re = 0.0, res_im = 0.0;
                Lib_xsf_cplx_airyaip(1, z.Real, z.Imaginary, ref res_re, ref res_im);
                return new Complex(res_re, res_im);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_airyaip", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_airyaip(int Kode, Double z_re, Double z_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_ai_prime/*' />
        public static Complex airy_ai_prime(dynamic z, bool scaled = false)
        {
            return airy_ai_prime(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_bi_prime/*' />
        public static Complex airy_bi_prime(Complex z, bool scaled = false)
        {
            if (scaled) return airy_bi_scaled_prime(z);
            else
            {

                Double res_re = 0.0, res_im = 0.0;
                Libxsf_cplx_airybip(1, z.Real, z.Imaginary, ref res_re, ref res_im);
                return new Complex(res_re, res_im);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Libxsf_cplx_airybip", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Libxsf_cplx_airybip(int Kode, Double z_re, Double z_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_bi_prime/*' />
        public static Complex airy_bi_prime(dynamic z, bool scaled = false)
        {
            return airy_bi_prime(t(z));
        }




        /// <summary>
        /// Returns the complex function airy_ai_scaled_prime.
        /// </summary>
        public static Complex airy_ai_scaled_prime(Complex z)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_airyaip(2, z.Real, z.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }

        /// <summary>
        /// Returns the complex function airy_ai_scaled_prime.
        /// </summary>
        public static Complex airy_ai_scaled_prime(dynamic z)
        {
            return airy_ai_scaled_prime(t(z));
        }


        /// <summary>
        /// Returns the complex function airy_bi_scaled_prime.
        /// </summary>
        public static Complex airy_bi_scaled_prime(Complex z)
        {
            Double res_re = 0.0, res_im = 0.0;
            Libxsf_cplx_airybip(2, z.Real, z.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }

        /// <summary>
        /// Returns the complex function airy_bi_scaled_prime.
        /// </summary>
        public static Complex airy_bi_scaled_prime(dynamic z)
        {
            return airy_bi_scaled_prime(t(z));
        }




        #endregion



        #region Kelvin functions




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ber/*' />
        public static Complex kelvin_ber(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                Double a = 0.5 * dreal.sqrt(2);
                Complex ia = dcplx.onej() * a;
                res = 0.5 * (bessel_jv(v, x * (-a + ia)) + bessel_jv(v, x * (-a - ia)));
                if (scaled) res *= exp(-dcplx.abs(x) / dreal.sqrt(2));
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ber/*' />
        public static Complex kelvin_ber(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_ber(dcplx.t(v), dcplx.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_bei/*' />
        public static Complex kelvin_bei(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                Double a = 0.5 * dreal.sqrt(2);
                Complex i = dcplx.onej();
                Complex ia = i * a;
                res = 0.5 * (bessel_jv(v, x * (-a + ia)) - bessel_jv(v, x * (-a - ia))) / i;
                if (scaled) res *= exp(-dcplx.abs(x) / dreal.sqrt(2));
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_bei/*' />
        public static Complex kelvin_bei(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_bei(dcplx.t(v), dcplx.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ker/*' />
        public static Complex kelvin_ker(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                Double a = 0.5 * dreal.sqrt(2);
                Complex i = dcplx.onej();
                Complex ia = i * a;
                Complex p = 0.5 * i * v * dreal.pi();
                Complex e1 = Complex.Exp(-p);
                Complex e2 = Complex.Exp(p);
                res = 0.5 * (e1 * bessel_kv(v, x * (a + ia)) + e2 * bessel_kv(v, x * (a - ia)));
                if (scaled) res *= exp(dcplx.abs(x) / dreal.sqrt(2));
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ker/*' />
        public static Complex kelvin_ker(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_ker(dcplx.t(v), dcplx.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_kei/*' />
        public static Complex kelvin_kei(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                Double a = 0.5 * dreal.sqrt(2);
                Complex i = dcplx.onej();
                Complex ia = i * a;
                Complex p = 0.5 * i * v * dreal.pi();
                Complex e1 = Complex.Exp(-p);
                Complex e2 = Complex.Exp(p);
                res = 0.5 * (e1 * bessel_kv(v, x * (a + ia)) - e2 * bessel_kv(v, x * (a - ia))) / i;
                if (scaled) res *= exp(dcplx.abs(x) / dreal.sqrt(2));
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_kei/*' />
        public static Complex kelvin_kei(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_kei(dcplx.t(v), dcplx.t(x), scaled);
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ber_prime/*' />
        public static Complex kelvin_ber_prime(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                Double a = 0.5 * dreal.sqrt(2);
                Complex ia = dcplx.onej() * a;
                Complex a1 = -a + ia;
                Complex a2 = -a - ia;
                res = 0.5 * (a1 * bessel_jv_prime(v, x * a1) + a2 * bessel_jv_prime(v, x * a2));
                if (scaled) res *= exp(-dcplx.abs(x) / dreal.sqrt(2));
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ber_prime/*' />
        public static Complex kelvin_ber_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_ber_prime(dcplx.t(v), dcplx.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_bei_prime/*' />
        public static Complex kelvin_bei_prime(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                Double a = 0.5 * dreal.sqrt(2);
                Complex i = dcplx.onej();
                Complex ia = i * a;
                Complex a1 = -a + ia;
                Complex a2 = -a - ia;
                res = 0.5 * (a1 * bessel_jv_prime(v, x * a1) - a2 * bessel_jv_prime(v, x * a2)) / i;
                if (scaled) res *= exp(-dcplx.abs(x) / dreal.sqrt(2));
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_bei_prime/*' />
        public static Complex kelvin_bei_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_bei_prime(dcplx.t(v), dcplx.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ker_prime/*' />
        public static Complex kelvin_ker_prime(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                Double a = 0.5 * dreal.sqrt(2);
                Complex i = dcplx.onej();
                Complex ia = i * a;
                Complex p = 0.5 * i * v * dreal.pi();
                Complex e1 = Complex.Exp(-p);
                Complex e2 = Complex.Exp(p);
                Complex a1 = a + ia;
                Complex a2 = a - ia;
                res = 0.5 * (e1 * a1 * bessel_kv_prime(v, x * a1) + e2 * a2 * bessel_kv_prime(v, x * a2));
                if (scaled) res *= exp(dcplx.abs(x) / dreal.sqrt(2));
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ker_prime/*' />
        public static Complex kelvin_ker_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_ker_prime(dcplx.t(v), dcplx.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_kei_prime/*' />
        public static Complex kelvin_kei_prime(Complex v, Complex x, bool scaled = false)
        {
            Complex res = dcplx.nan();
            if (v.Imaginary == 0.0)
            {
                Double a = 0.5 * dreal.sqrt(2);
                Complex i = dcplx.onej();
                Complex ia = i * a;
                Complex p = 0.5 * i * v * dreal.pi();
                Complex e1 = Complex.Exp(-p);
                Complex e2 = Complex.Exp(p);
                Complex a1 = a + ia;
                Complex a2 = a - ia;
                res = 0.5 * (e1 * a1 * bessel_kv_prime(v, x * a1) - e2 * a2 * bessel_kv_prime(v, x * a2)) / i;
                if (scaled) res *= exp(dcplx.abs(x) / dreal.sqrt(2));
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_kei_prime/*' />
        public static Complex kelvin_kei_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_kei_prime(dcplx.t(v), dcplx.t(x), scaled);
        }








        #endregion







        #region Hypergeometric Functions 1F1 (Kummer) and U (Tricomi)



        internal static Complex hyperg_1f1_(Double a, Double b, Complex z)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_sf_cplx_chyp1f1(a, b, z.Real, z.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_sf_cplx_chyp1f1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_sf_cplx_chyp1f1(Double a, Double b, Double z_re, Double z_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom1F1/*' />
        public static Complex hyperg_1f1(Complex a, Complex b, Complex z)
        {
            Complex res = dcplx.nan();
            if ((a.Imaginary == 0.0) && (b.Imaginary == 0.0))
            {
                res = hyperg_1f1_(a.Real, b.Real, z);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom1F1/*' />
        public static Complex hyperg_1f1(dynamic a, dynamic b, dynamic z)
        {
            return hyperg_1f1(t(a), t(b), t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom1F1r/*' />
        public static Complex hyperg_1f1r(Complex a, Complex b, Complex z)
        {
            Complex res = dcplx.nan();
            if ((a.Imaginary == 0.0) && (b.Imaginary == 0.0))
            {
                if ((b.Real <= 0) && dreal.isinteger(b.Real))
                {
                    Double n = Math.Abs(-b.Real);
                    res = rising_factorial(a, n + 1) * pow(z, n + 1) / gamma(n + 2);
                    res *= hyperg_1f1(a + n + 1, n + 2, z);
                }
                else res = hyperg_1f1(a, b, z) / gamma(b);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom1F1r/*' />
        public static Complex hyperg_1f1r(dynamic a, dynamic b, dynamic z)
        {
            return hyperg_1f1r(t(a), t(b), t(z));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log_hyperg_1f1/*' />
        public static Complex log_hyperg_1f1(Complex a, Complex b, Complex z)
        {
            Complex res = dcplx.nan();
            if ((a.Imaginary == 0.0) && (b.Imaginary == 0.0))
            {
                res = log(hyperg_1f1(a, b, z));
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log_hyperg_1f1/*' />
        public static Complex log_hyperg_1f1(dynamic a, dynamic b, dynamic z)
        {
            return log_hyperg_1f1(t(a), t(b), t(z));
        }



        internal static Complex hyperg_u_(Double a, Double b, Complex z)
        {
            var res1 = (math53.gamma(1 - b) / math53.gamma(a - b + 1)) * hyperg_1f1(a, b, z);
            var res2 = (math53.gamma(b - 1) / math53.gamma(a)) * pow(z, 1 - b) * hyperg_1f1(a - b + 1, 2 - b, z);
            return res1 + res2;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom1U/*' />
        public static Complex hyperg_u(Complex a, Complex b, Complex z)
        {
            Complex res = dcplx.nan();
            if ((a.Imaginary == 0.0) && (b.Imaginary == 0.0))
            {
                if (dreal.isinteger(b.Real))
                {
                    Double h = 1E-8;
                    Complex res1 = hyperg_u_(a.Real, b.Real - h, z);
                    Complex res2 = hyperg_u_(a.Real, b.Real + h, z);
                    res = (res2 + res1) / (2);
                }
                else res = hyperg_u_(a.Real, b.Real, z);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom1U/*' />
        public static Complex hyperg_u(dynamic a, dynamic b, dynamic z)
        {
            return hyperg_u(t(a), t(b), t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hermite_h/*' />
        public static Complex hermite_h(Complex nu, Complex z)
        {
            Complex res = dcplx.nan();
            if (nu.Imaginary == 0.0)
            {
                Double n = nu.Real;
                Complex r1 = math53.rgamma((1 - n) / 2);
                Complex r2 = math53.rgamma(-n / 2);
                if (cmath53.abs(r1) > 0.0) r1 *= hyperg_1f1(-n / 2, 0.5, z * z);
                if (cmath53.abs(r2) > 0.0) r2 *= hyperg_1f1((1 - n) / 2, 1.5, z * z) * 2 * z;
                Complex diff = r1 - r2;
                res = exp2(n) * sqrt(math53.pi()) * diff;
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hermite_h/*' />
        public static Complex hermite_h(dynamic nu, dynamic z)
        {
            return hermite_h(t(nu), t(z));
        }






        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hermite_he/*' />
        public static Complex hermite_he(Complex n, Complex x)
        {
            return exp2(n / 2) * hermite_h(n, x / sqrt(2));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hermite_he/*' />
        public static Complex hermite_he(dynamic n, dynamic x)
        {
            return hermite_h(dcplx.t(n), dcplx.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/laguerre_l/*' />
        public static Complex laguerre_l(Complex n, Complex a, Complex z)
        {
            Complex res = dcplx.nan();
            if ((n.Imaginary == 0.0) && (a.Imaginary == 0.0))
            {
                Double n_ = n.Real;
                Double a_ = a.Real;
                Double g1 = math53.gamma(n_ + a_ + 1);
                Double g2 = math53.gamma(n_ + 1);
                Double g3 = math53.gamma(a_ + 1);
                res = hyperg_1f1(-n, a + 1, z) * g1 / (g2 * g3);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/laguerre_l/*' />
        public static Complex laguerre_l(dynamic n, dynamic a, dynamic z)
        {
            return laguerre_l(t(n), t(a), t(z));
        }





        #endregion



        #region Incomplete gamma functions




        #endregion



        #region Coulomb, Whittaker and parabolic cylinder function



        #endregion






        #region Error function and related functions




        /// <summary>
        /// Returns the complex error function erf_sf.
        /// </summary>
        public static Complex CerfSF(Complex z)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_sf_cplx_cerf(z.Real, z.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_sf_cplx_cerf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_sf_cplx_cerf(Double z_re, Double z_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex error function erf_sf.
        /// </summary>
        public static Complex CerfSF(dynamic z1)
        {
            return CerfSF(t(z1));
        }



        /// <summary>
        /// Returns the complex error function w = erf(z) = 2/sqrt(Pi)*integral((exp(-t^2), t=0..z)
        /// </summary>
        public static Complex erf(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cerf(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cerf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cerf(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex error function w = erf(z) = 2/sqrt(Pi)*integral((exp(-t^2), t=0..z)
        /// </summary>
        public static Complex erf(dynamic z1)
        {
            return erf(t(z1));
        }



        /// <summary>
        /// Returns the complex complementary error function w = erfc(z) = 1-erf(z)
        /// </summary>
        public static Complex erfc(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cerfc(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cerfc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cerfc(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex complementary error function w = erfc(z) = 1-erf(z)
        /// </summary>
        public static Complex erfc(dynamic z1)
        {
            return erfc(t(z1));
        }


        /// <summary>
        /// Returns ndens(Double x)
        /// </summary>
        public static Complex ndens(Complex x)
        {
            return exp(-0.5 * x * x) / sqrt(2 * dreal.pi());
        }

        /// <summary>
        /// Returns ndis(Double x)
        /// </summary>
        public static Complex ndis(Complex x)
        {
            return 0.5 * Erfc_Xsf(-x / sqrt(2));
        }




        /// <summary>
        /// Returns the complex function faddeeva.
        /// </summary>
        public static Complex faddeeva(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_w(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_w", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_w(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex function faddeeva.
        /// </summary>
        public static Complex faddeeva(dynamic z1)
        {
            return faddeeva(t(z1));
        }



        /// <summary>
        /// Returns the complex error function erfcx.
        /// </summary>
        public static Complex erfcx(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_erfcx(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_erfcx", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_erfcx(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex error function erfcx.
        /// </summary>
        public static Complex erfcx(dynamic z1)
        {
            return erfcx(t(z1));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erf/*' />
        public static Complex Erf_Xsf(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_erf(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_erf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_erf(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erf/*' />
        public static Complex Erf_Xsf(dynamic z1)
        {
            return Erf_Xsf(t(z1));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erfc/*' />
        public static Complex Erfc_Xsf(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_erfc(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_erfc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_erfc(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erfc/*' />
        public static Complex Erfc_Xsf(dynamic z1)
        {
            return Erfc_Xsf(t(z1));
        }




        /// <summary>
        /// Returns the complex dawson function.
        /// </summary>
        public static Complex dawson(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_dawson(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_dawson", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_dawson(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex dawson function.
        /// </summary>
        public static Complex dawson(dynamic z1)
        {
            return dawson(t(z1));
        }



        #endregion





        #region Exponential integrals and related functions



        /// <summary>
        /// Returns the complex exponential integral E1(z), z &#8800; 0
        /// </summary>
        public static Complex exp_integral_e1(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_ce1(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ce1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_ce1(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex exponential integral E1(z), z &#8800; 0
        /// </summary>
        public static Complex exp_integral_e1(dynamic z1)
        {
            return exp_integral_e1(t(z1));
        }



        /// <summary>
        /// Returns the complex exponential integral exp_integral_ei(z), z &#8800; 0
        /// </summary>
        public static Complex exp_integral_ei(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cei(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cei", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cei(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex exponential integral exp_integral_ei(z), z &#8800; 0
        /// </summary>
        public static Complex exp_integral_ei(dynamic z1)
        {
            return exp_integral_ei(t(z1));
        }



        /// <summary>
        /// Returns the complex logarithmic integral w = li(z) = exp_integral_ei(ln(z)), z &#8800; 1
        /// </summary>
        public static Complex log_integral(Complex z1)
        {
            Double res_re = 0.0, res_im = 0.0;
            damath_cli(z1.Real, z1.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cli", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cli(Double x_re, Double x_im, ref Double res_re, ref Double res_im);

        /// <summary>
        /// Returns the complex logarithmic integral w = li(z) = exp_integral_ei(ln(z)), z &#8800; 1
        /// </summary>
        public static Complex log_integral(dynamic z1)
        {
            return log_integral(t(z1));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin_integral/*' />
        public static Complex sin_integral(Complex z)
        {
            Double si_re = 0.0, si_im = 0.0;
            Double ci_re = 0.0, ci_im = 0.0;
            Lib_xsf_cplx_sici(z.Real, z.Imaginary, ref si_re, ref si_im, ref ci_re, ref ci_im);
            return new Complex(si_re, si_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_sici", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_sici(Double z_re, Double z_im, ref Double si_re, ref Double si_im, ref Double ci_re, ref Double ci_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin_integral/*' />
        public static Complex sin_integral(dynamic z1)
        {
            return sin_integral(t(z1));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos_integral/*' />
        public static Complex cos_integral(Complex z)
        {
            Double si_re = 0.0, si_im = 0.0;
            Double ci_re = 0.0, ci_im = 0.0;
            Lib_xsf_cplx_sici(z.Real, z.Imaginary, ref si_re, ref si_im, ref ci_re, ref ci_im);
            return new Complex(ci_re, ci_im);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos_integral/*' />
        public static Complex cos_integral(dynamic z1)
        {
            return cos_integral(t(z1));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh_integral/*' />
        public static Complex sinh_integral(Complex z)
        {
            return -dcplx.onej() * sin_integral(dcplx.onej() * z);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh_integral/*' />
        public static Complex sinh_integral(dynamic z1)
        {
            return sinh_integral(t(z1));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh_integral/*' />
        public static Complex cosh_integral(Complex z)
        {
            return cos_integral(dcplx.onej() * z) - log(dcplx.onej() * z) + log(z);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh_integral/*' />
        public static Complex cosh_integral(dynamic z1)
        {
            return cosh_integral(t(z1));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fresnel_s/*' />
        public static Complex fresnel_s(Complex z)
        {
            Double fs_re = 0.0, fs_im = 0.0;
            Double fc_re = 0.0, fc_im = 0.0;
            Lib_xsf_cplx_fresnel(z.Real, z.Imaginary, ref fs_re, ref fs_im, ref fc_re, ref fc_im);
            return new Complex(fs_re, fs_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_fresnel", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_fresnel(Double z_re, Double z_im, ref Double fs_re, ref Double fs_im, ref Double fc_re, ref Double fc_im);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fresnel_s/*' />
        public static Complex fresnel_s(dynamic z1)
        {
            return fresnel_s(t(z1));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fresnel_c/*' />
        public static Complex fresnel_c(Complex z)
        {
            Double fs_re = 0.0, fs_im = 0.0;
            Double fc_re = 0.0, fc_im = 0.0;
            Lib_xsf_cplx_fresnel(z.Real, z.Imaginary, ref fs_re, ref fs_im, ref fc_re, ref fc_im);
            return new Complex(fc_re, fc_im);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fresnel_c/*' />
        public static Complex fresnel_c(dynamic z1)
        {
            return fresnel_c(t(z1));
        }





        #endregion










        #region Gauss Hypergeometric Function 2F1 and related



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom2F1/*' />
        public static Complex hyperg_2f1_(Double a, Double b, Double c, Complex z)
        {
            Double res_re = 0.0, res_im = 0.0;
            Lib_xsf_cplx_hyp2f1(a, b, c, z.Real, z.Imaginary, ref res_re, ref res_im);
            return new Complex(res_re, res_im);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_hyp2f1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_hyp2f1(Double a, Double b, Double c, Double z_re, Double z_im, ref Double res_re, ref Double res_im);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom1F1/*' />
        public static Complex hyperg_2f1(Complex a, Complex b, Complex c, Complex z)
        {
            Complex res = dcplx.nan();
            if ((a.Imaginary == 0.0) && (b.Imaginary == 0.0) && (c.Imaginary == 0.0))
            {
                res = hyperg_2f1_(a.Real, b.Real, c.Real, z);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom2F1/*' />
        public static Complex hyperg_2f1(dynamic a, dynamic b, dynamic c, dynamic z)
        {
            return hyperg_2f1(t(a), t(b), t(c), t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom2F1r/*' />
        public static Complex hyperg_2f1r(Complex a, Complex b, Complex c, Complex z)
        {
            Complex res = dcplx.nan();
            if ((a.Imaginary == 0.0) && (b.Imaginary == 0.0) && (c.Imaginary == 0.0))
            {
                if (dreal.isinteger(c.Real) && (c.Real <= 0))
                {
                    Double m = -c.Real;
                    Complex f = hyperg_2f1(a + m + 1, b + m + 1, m + 2, z);
                    Double p = math53.rising_factorial(a.Real, m + 1) * math53.rising_factorial(b.Real, m + 1) / math53.gamma(m + 2);
                    Complex pm = z;
                    for (int i = 0; i < m; i++) pm *= z;
                    res = pm * p * f;
                }
                else
                    res = hyperg_2f1(a, b, c, z) / math53.gamma(c.Real);
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Hypgeom2F1r/*' />
        public static Complex hyperg_2f1r(dynamic a, dynamic b, dynamic c, dynamic z)
        {
            return hyperg_2f1r(t(a), t(b), t(c), t(z));
        }



        #endregion



        #region Chebyshev, Gegenbauer and Jacobi polynomials


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/chebyshev_t/*' />
        public static Complex chebyshev_t(Complex v, Complex x)
        {
            return hyperg_2f1(-v, v, dcplx.t(0.5), (1 - x) / 2);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/chebyshev_t/*' />
        public static Complex chebyshev_t(dynamic v, dynamic x)
        {
            return chebyshev_t(dcplx.t(v), dcplx.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/chebyshev_u/*' />
        public static Complex chebyshev_u(Complex v, Complex x)
        {
            return (v + 1) * hyperg_2f1(-v, v + 2, dcplx.t(1.5), (1 - x) / 2);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/chebyshev_u/*' />
        public static Complex chebyshev_u(dynamic v, dynamic x)
        {
            return chebyshev_u(dcplx.t(v), dcplx.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/chebyshev_v/*' />
        public static Complex chebyshev_v(Complex v, Complex x)
        {
            return expjpi(v) * (2 * v + 1) * hyperg_2f1(-v, v + 1, dcplx.t(1.5), (1 + x) / 2);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/chebyshev_v/*' />
        public static Complex chebyshev_v(dynamic v, dynamic x)
        {
            return chebyshev_v(dcplx.t(v), dcplx.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/chebyshev_w/*' />
        public static Complex chebyshev_w(Complex v, Complex x)
        {
            return expjpi(v) * hyperg_2f1(-v, v + 1, dcplx.t(0.5), (1 + x) / 2);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/chebyshev_w/*' />
        public static Complex chebyshev_w(dynamic v, dynamic x)
        {
            return chebyshev_w(dcplx.t(v), dcplx.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gegenbauer_c/*' />
        public static Complex gegenbauer_c(Complex n, Complex a, Complex x)
        {
            return rising_factorial(2 * a, n) * hyperg_2f1(-n, 2 * a + n, a + dcplx.t(0.5), (1 - x) / 2) / gamma(n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gegenbauer_c/*' />
        public static Complex gegenbauer_c(dynamic n, dynamic a, dynamic x)
        {
            return gegenbauer_c(dcplx.t(n), dcplx.t(a), dcplx.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_p/*' />
        public static Complex jacobi_p(Complex n, Complex a, Complex b, Complex x)
        {
            return rising_factorial(a + 1, n) * hyperg_2f1(-n, n + a + b + 1, a + 1, (1 - x) / 2) / gamma(n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/jacobi_p/*' />
        public static Complex jacobi_p(dynamic n, dynamic a, dynamic b, dynamic x)
        {
            return jacobi_p(dcplx.t(n), dcplx.t(a), dcplx.t(b), dcplx.t(x));
        }




        #endregion



        #region Legendre polynomials and related



        internal static Complex legendre_plm2(Complex n, Complex m, Complex z)
        {
            Complex f = hyperg_2f1r(-n, n + 1, 1 - m, (1 - z) / 2);
            return f * pow(1 + z, m / 2) / pow(1 - z, m / 2);
        }


        internal static Complex legendre_plm3(Complex n, Complex m, Complex z)
        {
            Complex f = hyperg_2f1r(-n, n + 1, 1 - m, (1 - z) / 2);
            return f * pow(z + 1, m / 2) / pow(z - 1, m / 2);
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/legendre_plm/*' />
        public static Complex legendre_plm(Complex n, Complex m, Complex x, int type = 1)
        {
            Complex res = dcplx.nan();
            switch (type)
            {
                case 2: res = legendre_plm2(n, m, x); break;
                case 3: res = legendre_plm3(n, m, x); break;
                case 1:
                default:
                    if (abs(x.Real) < 1) res = legendre_plm2(n, m, x);
                    else res = legendre_plm3(n, m, x);
                    break;
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/legendre_plm/*' />
        public static Complex legendre_plm(dynamic n, dynamic m, dynamic x, int type = 1)
        {
            return legendre_plm(dcplx.t(n), dcplx.t(m), dcplx.t(x), type);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/legendre_p/*' />
        public static Complex legendre_p(Complex n, Complex x)
        {
            return legendre_plm(n, dcplx.t(0), x, 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/legendre_plm/*' />
        public static Complex legendre_p(dynamic n, dynamic x)
        {
            return legendre_p(dcplx.t(n), dcplx.t(x));
        }





        internal static Complex legendre_qlm2(Complex nu, Complex mu, Complex z)
        {
            Complex term1 = dcplx.zero();
            Complex term2 = dcplx.zero();
            Complex c = cospi((mu + nu) / 2);
            //Console.WriteLine("c: {0}, abs(c): {1}", c, abs(c));
            if (abs(c) > 0)
            {
                c *= z * gamma((mu + nu + 2) / 2) / gamma((-mu + nu + 1) / 2);
                Complex fc = hyperg_2f1((-mu - nu + 1) / 2, 1 + (nu - mu) / 2, dcplx.t(1.5), z * z);
                term1 = c * fc;
            }
            Complex s = sinpi((mu + nu) / 2);
            //Console.WriteLine("s: {0}, abs(s): {1}", s, abs(s));
            if (abs(s) > 0)
            {
                s *= gamma((mu + nu + 1) / 2) / gamma((-mu + nu + 2) / 2) / 2;
                Complex fs = hyperg_2f1((-mu - nu) / 2, (-mu + nu + 1) / 2, dcplx.t(0.5), z * z);
                term2 = s * fs;
            }
            return exp2(mu) * dreal.sqrt(dreal.pi()) * pow(1 - z * z, -mu / 2) * (term1 - term2);
        }



        internal static Complex legendre_qlm_3a(Complex nu, Complex mu, Complex x)
        {
            // See https://functions.wolfram.com/HypergeometricFunctions/LegendreQ3General/03/01/01/
            Complex f1a = sqrt(dreal.pi()) * gamma(nu + mu + 1) * pow(x - 1, mu / 2) * pow(x + 1, mu / 2);
            Complex f1b = pow(2.0, nu + 1) * pow(x, nu + mu + 1);
            Complex f1 = f1a / f1b;
            Complex f2 = hyperg_2f1r((nu + mu + 1) / 2, (nu + mu + 2) / 2, nu + 1.5, 1 / (x * x));
            Complex s = expjpi(mu);
            return s * f1 * f2;
        }


        internal static Complex legendre_qlm_3_int(Complex nu, Complex m_, Complex z)
        {
            Complex res = dcplx.nan();
            if ((m_.Imaginary == 0.0) && dreal.isinteger(m_.Real))
            {
                int m = dreal.lrint(m_.Real);
                Complex q1 = legendre_qlm2(nu, m, z);
                q1 *= pow(z - 1, m / 2) / pow(1 - z, m / 2);
                int s = -1; if (m % 2 == 0) s = 1;
                q1 *= s;
                Complex p1 = legendre_plm3(nu, m, z);
                p1 *= 0.5 * dreal.pi() * sqrt(z - 1) / sqrt(1 - z);
                res = q1 - p1;
            }
            return res;
        }


        internal static Complex legendre_qlm_3b(Complex n, Complex m, Complex z)
        {
            Complex pref = 0.5 * expjpi(m) * dreal.pi() / sinpi(m);
            Complex p1 = legendre_plm3(n, m, z);
            Complex p2 = legendre_plm3(n, -m, z) * gamma(1 + m + n) / gamma(1 - m + n);
            return pref * (p1 - p2);
        }



        internal static Complex legendre_qlm3(Complex n, Complex m, Complex z)
        {
            if ((z.Imaginary == 0.0) && (z.Real >= 0.0) && (z.Real < 1.0))
            {
                Double x = z.Real;
                if (dreal.isinteger(m.Real)) {
                    int m_ = dreal.lrint(m.Real);
                    if ((m_ % 2 == 0)) return legendre_qlm_3_int(n, m, x);
                    else
                    {
                        Double x1 = x;
                        if (x == 0.0) x1 = -1E-12;
                        Complex res = legendre_qlm_3a(n, m, x1);
                        if (x!=0.0) res = new Complex(-res.Real, res.Imaginary);
                        return res;
                    }
                }
                else { return legendre_qlm_3b(n, m, z); }
            }
            else return legendre_qlm_3a(n, m, z);
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/legendre_qlm/*' />
        public static Complex legendre_qlm(Complex n, Complex m, Complex x, int type = 1)
        {
            Complex res = dcplx.nan();
            switch (type)
            {
                case 2: res = legendre_qlm2(n, m, x); break;
                case 3: res = legendre_qlm3(n, m, x); break;
                case 1:
                default:
                    if (abs(x.Real) < 1) res = legendre_qlm2(n, m, x);
                    else res = legendre_qlm3(n, m, x);
                    break;
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/legendre_qlm/*' />
        public static Complex legendre_qlm(dynamic n, dynamic m, dynamic x, int type = 1)
        {
            return legendre_qlm(dcplx.t(n), dcplx.t(m), dcplx.t(x), type);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/legendre_q/*' />
        public static Complex legendre_q(Complex n, Complex x)
        {
            return legendre_qlm(n, dcplx.t(0), x, 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/legendre_qlm/*' />
        public static Complex legendre_q(dynamic n, dynamic x)
        {
            return legendre_q(dcplx.t(n), dcplx.t(x));
        }







        #endregion



        #region Incomplete beta Function


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/beta_lower/*' />
        public static Complex beta_lower(Complex a, Complex b, Complex z)
        {
            Complex res = dcplx.nan();
            if ((a.Imaginary == 0.0) && (b.Imaginary == 0.0))
            {
                res = pow(z, a) * hyperg_2f1_(a.Real, 1 - b.Real, a.Real + 1, z) / a;
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/beta_lower/*' />
        public static Complex beta_lower(dynamic a, dynamic b, dynamic z)
        {
            return beta_lower(t(a), t(b), t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ibeta/*' />
        public static Complex ibeta(Complex a, Complex b, Complex z)
        {
            Complex res = dcplx.nan();
            if ((a.Imaginary == 0.0) && (b.Imaginary == 0.0))
            {
                res = pow(z, a) * hyperg_2f1_(a.Real, 1 - b.Real, a.Real + 1, z) / a;
            }
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ibeta/*' />
        public static Complex ibeta(dynamic a, dynamic b, dynamic z)
        {
            return ibeta(t(a), t(b), t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ibeta_prime/*' />
        public static Complex ibeta_prime(Complex a, Complex b, Complex z)
        {
            return pow(z, a - 1) * pow(1 - z, b - 1) / beta(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ibeta_prime/*' />
        public static Complex ibeta_prime(dynamic a, dynamic b, dynamic z)
        {
            return ibeta_prime(t(a), t(b), t(z));
        }


        #endregion



        #region Hypergeometric Function 1F2, overview


        public static Complex hyperg_1f2(Complex a1, Complex b1, Complex b2, Complex x)
        {
            cb1SDouble1S FReal = (Double t) =>
            {
                Complex resR1 = pow(1 - t, b2 - a1 - 1) * pow(t, a1 - 1) * hyperg_0f1(b1, t * x);
                return resR1.Real;
            };

            cb1SDouble1S FImag = (Double t) =>
            {
                Complex resI1 = pow(1 - t, b2 - a1 - 1) * pow(t, a1 - 1) * hyperg_0f1(b1, t * x);
                return resI1.Imaginary;
            };
            Complex res = dcplx.nan();
            if ((a1.Imaginary == 0.0) && (b1.Imaginary == 0.0) && (b2.Imaginary == 0.0))
            {
                var resReal = dreal.TanhSinh(FReal, a: 0.0, b: 1, tol: 0.0);
                var resImag = dreal.TanhSinh(FImag, a: 0.0, b: 1, tol: 0.0);
                Console.WriteLine("resReal (integral, error, L1, levels): {0}", resReal);
                Console.WriteLine("resImag (integral, error, L1, levels): {0}", resImag);
                res = dcplx.t(resReal.Item1, resImag.Item1);
                Console.WriteLine();
                res = res * gamma(b2) / (gamma(a1) * gamma(b2 - a1));
            }
            return res;
        }


        public static Complex hyperg_1f2r(Complex a1, Complex b1, Complex b2, Complex x)
        {
            return hyperg_1f2(a1, b1, b2, x) / (gamma(b1) * gamma(b2));
        }







        #endregion




        #region Scorer functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_gi/*' />
        public static Complex airy_gi(Complex x)
        {
            return 1 * airy_bi(x) / 3 - (x * x) * hyperg_1f2(1, dcplx.t(4) / 3, dcplx.t(5) / 3, x * x * x / 9) / (2 * dreal.pi());
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_gi/*' />
        public static Complex airy_gi(dynamic x)
        {
            return airy_gi(dcplx.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_hi/*' />
        public static Complex airy_hi(Complex x)
        {
            return 2 * airy_bi(x) / 3 + (x * x) * hyperg_1f2(1, dcplx.t(4) / 3, dcplx.t(5) / 3, x * x * x / 9) / (2 * dreal.pi());
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_hi/*' />
        public static Complex airy_hi(dynamic x)
        {
            return airy_hi(dcplx.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_gi_prime/*' />
        public static Complex airy_gi_prime(Complex x)
        {
            Complex x3 = x * x * x;
            Complex x4 = x3 * x;
            return airy_bi_prime(x) / 3 - 1 / (40 * dreal.pi()) * (40 * x * hyperg_1f2(1, dcplx.t(4) / 3, dcplx.t(5) / 3, x3 / 9) + (3 * x4 * hyperg_1f2(2, dcplx.t(7) / 3, dcplx.t(8) / 3, x3 / 9)));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_gi_prime/*' />
        public static Complex airy_gi_prime(dynamic x)
        {
            return airy_gi_prime(dcplx.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_hi_prime/*' />
        public static Complex airy_hi_prime(Complex x)
        {
            Complex x3 = x * x * x;
            Complex x4 = x3 * x;
            return 2 * airy_bi_prime(x) / 3 + 1 / (40 * dreal.pi()) * (40 * x * hyperg_1f2(1, dcplx.t(4) / 3, dcplx.t(5) / 3, x3 / 9) + (3 * x4 * hyperg_1f2(2, dcplx.t(7) / 3, dcplx.t(8) / 3, x3 / 9)));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/airy_hi_prime/*' />
        public static Complex airy_hi_prime(dynamic x)
        {
            return airy_hi_prime(dcplx.t(x));
        }







        #endregion




        #region Struve functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/struve_h/*' />
        public static Complex struve_h(Complex v, Complex x)
        {
            return pow(x / 2, v + 1) * hyperg_1f2r(1, dcplx.t(1.5), dcplx.t(v + 1.5), -x * x / 4);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/struve_h/*' />
        public static Complex struve_h(dynamic v, dynamic x)
        {
            return struve_h(dcplx.t(v), dcplx.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/struve_h/*' />
        public static Complex struve_l(Complex v, Complex x)
        {
            Complex i = dcplx.onej();
            return -i * exp(-dreal.pi() * v * i / 2) * struve_h(v, i * x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/struve_l/*' />
        public static Complex struve_l(dynamic v, dynamic x)
        {
            return struve_l(dcplx.t(v), dcplx.t(x));
        }


        public static Complex struve_k(Complex v, Complex x)
        {
            return struve_h(v, x) - bessel_yv(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/struve_k/*' />
        public static Complex struve_k(dynamic v, dynamic x)
        {
            return struve_k(dcplx.t(v), dcplx.t(x));
        }


        public static Complex struve_m(Complex v, Complex x)
        {
            return struve_l(v, x) - bessel_iv(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/struve_m/*' />
        public static Complex struve_m(dynamic v, dynamic x)
        {
            return struve_m(dcplx.t(v), dcplx.t(x));
        }




        #endregion



        #region Anger, Weber and Lommel functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/anger_j/*' />
        public static Complex anger_j(Complex v, Complex x)
        {
            Complex f1 = hyperg_1f2r(1, 0.5 * (3 - v), 0.5 * (3 + v), -x * x / 4);
            Complex f2 = hyperg_1f2r(1, 0.5 * (2 - v), 0.5 * (2 + v), -x * x / 4);
            Complex res1 = 0.5 * x * sinpi(v / 2) * f1 + cospi(v / 2) * f2;
            return res1;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/anger_j/*' />
        public static Complex anger_j(dynamic v, dynamic x)
        {
            return anger_j(dcplx.t(v), dcplx.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/weber_e/*' />
        public static Complex weber_e(Complex v, Complex x)
        {
            Complex f1 = hyperg_1f2r(1, 0.5 * (3 - v), 0.5 * (3 + v), -x * x / 4);
            Complex f2 = hyperg_1f2r(1, 0.5 * (2 - v), 0.5 * (2 + v), -x * x / 4);
            Complex res1 = -0.5 * x * cospi(v / 2) * f1 + sinpi(v / 2) * f2;
            return res1;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/weber_e/*' />
        public static Complex weber_e(dynamic v, dynamic x)
        {
            return weber_e(dcplx.t(v), dcplx.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lommel_s1/*' />
        public static Complex lommel_s1(Complex mu, Complex nu, Complex x)
        {
            Complex f1 = pow(x, mu + 1) / ((mu - nu + 1) * (mu + nu + 1));
            Complex f2 = hyperg_1f2(1, (mu - nu + 3) / 2, (mu + nu + 3) / 2, -x * x / 4);
            Complex res1 = f1 * f2;
            return res1;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lommel_s1/*' />
        public static Complex lommel_s1(dynamic mu, dynamic nu, dynamic x)
        {
            return lommel_s1(dcplx.t(mu), dcplx.t(nu), dcplx.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lommel_s2/*' />
        public static Complex lommel_s2(Complex mu, Complex nu, Complex x)
        {
            Complex f1 = lommel_s1(mu, nu, x);
            Complex res1 = exp2(mu - 1) * gamma((mu - nu + 1) / 2) * gamma((mu + nu + 1) / 2);
            Complex res2 = sinpi((mu - nu) / 2) * bessel_jv(nu, x) - cospi((mu - nu) / 2) * bessel_yv(nu, x);
            return f1 + res1 * res2;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lommel_s2/*' />
        public static Complex lommel_s2(dynamic mu, dynamic nu, dynamic x)
        {
            return lommel_s2(dcplx.t(mu), dcplx.t(nu), dcplx.t(x));
        }




        #endregion









        #endregion





        #region Numpy-compatible functions, complex



        /// <summary>
        /// Return vec_p1
        /// </summary>
        public static void vec_p1(cb1SComplex1S f, Double[] a_re, Double[] a_im, Double[] res_re, Double[] res_im)
        {
            int rows = a_re.GetUpperBound(0);
            for (int i = 0; i <= rows; i++)
            {
                Complex cplx = new Complex(a_re[i], a_im[i]);
                Complex res_cplx = f(cplx);
                res_re[i] = res_cplx.Real;
                res_im[i] = res_cplx.Imaginary;
            }
        }



        /// <summary>
        /// Return mat_p1
        /// </summary>
        public static void mat_p1(cb1SComplex1S f, Double[,] a_re, Double[,] a_im, Double[,] res_re, Double[,] res_im)
        {
            int rows = a_re.GetUpperBound(0);
            int cols = a_re.GetUpperBound(1);
            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    Complex cplx = new Complex(a_re[i, j], a_im[i, j]);
                    Complex res_cplx = f(cplx);
                    res_re[i, j] = res_cplx.Real;
                    res_im[i, j] = res_cplx.Imaginary;
                }
            }
        }



        /// <summary>
        /// Return vec_p2
        /// </summary>
        public static void vec_p2(cb2SComplex1S f, Double[] a_re, Double[] a_im, Double[] b_re, Double[] b_im, Double[] res_re, Double[] res_im)
        {
            int ra = a_re.GetUpperBound(0);
            int rb = b_re.GetUpperBound(0);
            int rows = Math.Max(ra, rb);
            Complex a_cplx = new Complex(a_re[0], a_im[0]);
            Complex b_cplx = new Complex(b_re[0], b_im[0]);
            bool rca = ra != 0;
            bool rcb = rb != 0;
            for (int i = 0; i <= rows; i++)
            {
                if (rca) a_cplx = new Complex(a_re[i], a_im[i]);
                if (rcb) b_cplx = new Complex(b_re[i], b_im[i]);
                Complex res_cplx = f(a_cplx, b_cplx);
                res_re[i] = res_cplx.Real;
                res_im[i] = res_cplx.Imaginary;
            }
        }



        /// <summary>
        /// Return mat_p2
        /// </summary>
        public static void mat_p2(cb2SComplex1S f, Double[,] a_re, Double[,] a_im, Double[,] b_re, Double[,] b_im, Double[,] res_re, Double[,] res_im)
        {
            int ra = a_re.GetUpperBound(0);
            int rb = b_re.GetUpperBound(0);
            int rows = Math.Max(ra, rb);
            int ca = a_re.GetUpperBound(1);
            int cb = b_re.GetUpperBound(1);
            int cols = Math.Max(ca, cb);
            Complex a_cplx = new Complex(a_re[0, 0], a_im[0, 0]);
            Complex b_cplx = new Complex(b_re[0, 0], b_im[0, 0]);
            bool rca = ra + ca != 0;
            bool rcb = rb + cb != 0;
            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    if (rca) a_cplx = new Complex(a_re[i, j], a_im[i, j]);
                    if (rcb) b_cplx = new Complex(b_re[i, j], b_im[i, j]);
                    Complex res_cplx = f(a_cplx, b_cplx);
                    res_re[i, j] = res_cplx.Real;
                    res_im[i, j] = res_cplx.Imaginary;
                }
            }
        }



        /// <summary>
        /// Return vec_p3
        /// </summary>
        public static void vec_p3(cb3SComplex1S f, Double[] a_re, Double[] a_im, Double[] b_re, Double[] b_im, Double[] c_re, Double[] c_im, Double[] res_re, Double[] res_im)
        {
            int ra = a_re.GetUpperBound(0);
            int rb = b_re.GetUpperBound(0);
            int rc = c_re.GetUpperBound(0);
            int rows = Math.Max(ra, rb); rows = Math.Max(rows, rc);
            Complex a_cplx = new Complex(a_re[0], a_im[0]);
            Complex b_cplx = new Complex(b_re[0], b_im[0]);
            Complex c_cplx = new Complex(c_re[0], c_im[0]);
            bool rca = ra != 0;
            bool rcb = rb != 0;
            bool rcc = rc != 0;
            for (int i = 0; i <= rows; i++)
            {
                if (rca) a_cplx = new Complex(a_re[i], a_im[i]);
                if (rcb) b_cplx = new Complex(b_re[i], b_im[i]);
                if (rcc) c_cplx = new Complex(c_re[i], c_im[i]);
                Complex res_cplx = f(a_cplx, b_cplx, c_cplx);
                res_re[i] = res_cplx.Real;
                res_im[i] = res_cplx.Imaginary;
            }
        }



        /// <summary>
        /// Return mat_p3
        /// </summary>
        public static void mat_p3(cb3SComplex1S f, Double[,] a_re, Double[,] a_im, Double[,] b_re, Double[,] b_im, Double[,] c_re, Double[,] c_im, Double[,] res_re, Double[,] res_im)
        {
            int ra = a_re.GetUpperBound(0);
            int rb = b_re.GetUpperBound(0);
            int rc = c_re.GetUpperBound(0);
            int rows = Math.Max(ra, rb); rows = Math.Max(rows, rc);
            int ca = a_re.GetUpperBound(1);
            int cb = b_re.GetUpperBound(1);
            int cc = c_re.GetUpperBound(1);
            int cols = Math.Max(ca, cb); cols = Math.Max(cols, cc);
            Complex a_cplx = new Complex(a_re[0, 0], a_im[0, 0]);
            Complex b_cplx = new Complex(b_re[0, 0], b_im[0, 0]);
            Complex c_cplx = new Complex(c_re[0, 0], c_im[0, 0]);
            bool rca = ra + ca != 0;
            bool rcb = rb + cb != 0;
            bool rcc = rc + cc != 0;
            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    if (rca) a_cplx = new Complex(a_re[i, j], a_im[i, j]);
                    if (rcb) b_cplx = new Complex(b_re[i, j], b_im[i, j]);
                    if (rcc) c_cplx = new Complex(c_re[i, j], c_im[i, j]);
                    Complex res_cplx = f(a_cplx, b_cplx, c_cplx);
                    res_re[i, j] = res_cplx.Real;
                    res_im[i, j] = res_cplx.Imaginary;
                }
            }
        }



        /// <summary>
        /// Return vec_p4
        /// </summary>
        public static void vec_p4(cb4SComplex1S f, Double[] a_re, Double[] a_im, Double[] b_re, Double[] b_im, Double[] c_re, Double[] c_im, Double[] d_re, Double[] d_im, Double[] res_re, Double[] res_im)
        {
            int ra = a_re.GetUpperBound(0);
            int rb = b_re.GetUpperBound(0);
            int rc = c_re.GetUpperBound(0);
            int rd = d_re.GetUpperBound(0);
            int rows = Math.Max(ra, rb); rows = Math.Max(rows, rc); rows = Math.Max(rows, rd);
            Complex a_cplx = new Complex(a_re[0], a_im[0]);
            Complex b_cplx = new Complex(b_re[0], b_im[0]);
            Complex c_cplx = new Complex(c_re[0], c_im[0]);
            Complex d_cplx = new Complex(d_re[0], d_im[0]);
            bool rca = ra != 0;
            bool rcb = rb != 0;
            bool rcc = rc != 0;
            bool rcd = rd != 0;
            for (int i = 0; i <= rows; i++)
            {
                if (rca) a_cplx = new Complex(a_re[i], a_im[i]);
                if (rcb) b_cplx = new Complex(b_re[i], b_im[i]);
                if (rcc) c_cplx = new Complex(c_re[i], c_im[i]);
                if (rcd) d_cplx = new Complex(d_re[i], d_im[i]);
                Complex res_cplx = f(a_cplx, b_cplx, c_cplx, d_cplx);
                res_re[i] = res_cplx.Real;
                res_im[i] = res_cplx.Imaginary;
            }
        }



        /// <summary>
        /// Return mat_p4
        /// </summary>
        public static void mat_p4(cb4SComplex1S f, Double[,] a_re, Double[,] a_im, Double[,] b_re, Double[,] b_im, Double[,] c_re, Double[,] c_im, Double[,] d_re, Double[,] d_im, Double[,] res_re, Double[,] res_im)
        {
            int ra = a_re.GetUpperBound(0);
            int rb = b_re.GetUpperBound(0);
            int rc = c_re.GetUpperBound(0);
            int rd = d_re.GetUpperBound(0);
            int rows = Math.Max(ra, rb); rows = Math.Max(rows, rc); rows = Math.Max(rows, rd);
            int ca = a_re.GetUpperBound(1);
            int cb = b_re.GetUpperBound(1);
            int cc = c_re.GetUpperBound(1);
            int cd = d_re.GetUpperBound(1);
            int cols = Math.Max(ca, cb); cols = Math.Max(cols, cc); cols = Math.Max(cols, cd);
            Complex a_cplx = new Complex(a_re[0, 0], a_im[0, 0]);
            Complex b_cplx = new Complex(b_re[0, 0], b_im[0, 0]);
            Complex c_cplx = new Complex(c_re[0, 0], c_im[0, 0]);
            Complex d_cplx = new Complex(d_re[0, 0], d_im[0, 0]);
            bool rca = ra + ca != 0;
            bool rcb = rb + cb != 0;
            bool rcc = rc + cc != 0;
            bool rcd = rd + cd != 0;
            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    if (rca) a_cplx = new Complex(a_re[i, j], a_im[i, j]);
                    if (rcb) b_cplx = new Complex(b_re[i, j], b_im[i, j]);
                    if (rcc) c_cplx = new Complex(c_re[i, j], c_im[i, j]);
                    if (rcd) d_cplx = new Complex(d_re[i, j], d_im[i, j]);
                    Complex res_cplx = f(a_cplx, b_cplx, c_cplx, d_cplx);
                    res_re[i, j] = res_cplx.Real;
                    res_im[i, j] = res_cplx.Imaginary;
                }
            }
        }




        #endregion






    }




}