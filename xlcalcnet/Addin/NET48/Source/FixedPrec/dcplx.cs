using System;
using System.Numerics;
using System.Runtime.InteropServices;


namespace FixedPrecNet
{




    public partial class dcplx
    {

        public static String fmt(Complex z)
        {
            string s1 = z.Real.ToString("G15", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
            string s2 = z.Imaginary.ToString("G15", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
            string s = " " + "(" + s1 + ", " + s2 + ")";
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
            get { return "dcplx"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  dcplx"; }
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





        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/realctx/*' />
        public static dreal realctx
        {
            get { return new dreal(); }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static dcplx cplxctx
        {
            get { return new dcplx(); }
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


        /// <summary>
        /// Returns a new Complex using an Octuple as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(Octuple x)
        {
            return new Complex(dreal.t(x), 0.0);
        }



        /// <summary>
        /// Returns a new Complex using a Quadruple as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(Quadruple x)
        {
            return new Complex(dreal.t(x), 0.0);
        }



        /// <summary>
        /// Returns a new Complex using an Extended as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(Extended x)
        {
            return new Complex(dreal.t(x), 0.0);
        }



        /// <summary>
        /// Returns a new Complex using a Double (System.Double) for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(Double x)
        {
            return new Complex(x, 0.0);
        }



        /// <summary>
        /// Returns a new Complex using a Single (System.Single)  as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(Single x)
        {
            return new Complex(x, 0.0);
        }



        /// <summary>
        /// Returns a new Complex using a signed 32 bit integer (System.Int32) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(Int32 x)
        {
            return new Complex(x, 0.0);
        }


        /// <summary>
        /// Returns a new Complex using an unsigned 32 bit integer (System.UInt32) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(UInt32 x)
        {
            return new Complex(x, 0.0);
        }


        /// <summary>
        /// Returns a new Complex using a signed 64 bit integer (System.Int64) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(Int64 x)
        {
            return new Complex(x, 0.0);
        }


        /// <summary>
        /// Returns a new Complex using an unsigned 64 bit integer (System.UInt64) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(UInt64 x)
        {
            return new Complex(x, 0.0);
        }


        /// <summary>
        /// Returns a new Complex using a BigInteger (System.Numerics.BigInteger) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(BigInteger x)
        {
            return new Complex((Double)x, 0.0);
        }


        /// <summary>
        /// Returns a new Complex using a string (System.String) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(string s)
        {
            return new Complex(dreal.t(s), 0.0);
        }



        /// <summary>
        /// Returns a new Complex using a string (System.String) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static Complex t(decimal s)
        {
            return new Complex(dreal.t(s), 0.0);
        }




        /// <summary>
        /// Returns a new Complex using a OctupleC as input
        /// </summary>
        public static Complex t(OctupleC z)
        {
            return new Complex(dreal.t(z.real), dreal.t(z.imag));
        }



        /// <summary>
        /// Returns a new Complex using a QuadrupleC as input
        /// </summary>
        public static Complex t(QuadrupleC z)
        {
            return new Complex(dreal.t(z.real), dreal.t(z.imag));
        }


        /// <summary>
        /// Returns a new Complex using a ExtendedC as input
        /// </summary>
        public static Complex t(ExtendedC z)
        {
            return new Complex(dreal.t(z.real), dreal.t(z.imag));
        }



        /// <summary>
        /// Returns a new Complex using a Complex (System.Numerics.Complex) as input
        /// </summary>
        public static Complex t(Complex z)
        {
            return new Complex(z.Real, z.Imaginary);
        }


        /// <summary>
        /// Returns a new Complex using a SingleC as input
        /// </summary>
        public static Complex t(SingleC z)
        {
            return new Complex(dreal.t(z.real), dreal.t(z.imag));
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


        #endregion



        #region Machine constants and properties of numbers


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isreal/*' />
        public static bool isreal(Complex z)
        {
            return (z.Imaginary == dreal.t(0.0d));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/iszero/*' />
        public static bool iszero(Complex z)
        {
            return (z.Real == dreal.t(0.0d)) && (z.Imaginary == dreal.t(0.0d));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isone/*' />
        public static bool isone(Complex z)
        {
            return (z.Real == dreal.t(1.0d)) && (z.Imaginary == dreal.t(0.0d));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isinf/*' />
        public static bool isinf(Complex z)
        {
            return (dreal.isinf(z.Real)) || (dreal.isinf(z.Imaginary));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnan/*' />
        public static bool isnan(Complex z)
        {
            return (dreal.isnan(z.Real)) || (dreal.isnan(z.Imaginary));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isfinite/*' />
        public static bool isfinite(Complex z)
        {
            return (dreal.isfinite(z.Real)) && (dreal.isfinite(z.Imaginary));
        }





        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/zero/*' />
        public static Complex zero()
        {
            return dcplx.t(0d, 0d);
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/one/*' />
        public static Complex one()
        {
            return dcplx.t(1d, 0d);
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/onej/*' />
        public static Complex onej()
        {
            return dcplx.t(0d, 1d);
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/nan/*' />
        public static Complex nan()
        {
            return dcplx.t(dreal.nan(), dreal.nan());
        }




        #endregion





        #endregion






        #region Elementary scalar functions





        #region Complex components



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Double abs(Complex z)
        {
            return Complex.Abs(z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Double abs(dynamic z)
        {
            return abs(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Double fabs(Complex z)
        {
            return Complex.Abs(z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Double fabs(dynamic z)
        {
            return fabs(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static Complex sign(Complex z)
        {
            if (iszero(z)) return zero();
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


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Double imag(dynamic z)
        {
            return imag(t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Double phase(Complex z)
        {
            return z.Phase;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Double phase(dynamic z)
        {
            return phase(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static Complex conj(Complex z)
        {
            return Complex.Conjugate(z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
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


        public static Complex cplx_expm1(Complex z)
        {
            /* exp(a + i*b) - 1 = expm1(a)*cos(b) + (cos(b)-1) + i*exp(a)*sin(b) */
            double x = z.Real;
            double y = z.Imaginary;
            double resx = dreal.expm1(x) * Math.Cos(y) + dreal.cosm1(y);
            double resy = Math.Exp(x) * Math.Sin(y);
            return new Complex(resx, resy);
        }


        public static Complex cplx_log1p(Complex z)
        {
            /* If max(|x|, |y|) > 0.75 or x < -0.5: resx = ln(hypot(1 + x, y)); */
            /* Otherwise: resx = 0.5 * log1p(2x + x*x + y*y); */
            /* resy =  atan2(y, 1 + x); */
            double x = z.Real;
            double y = z.Imaginary;
            double resx = 0.0;
            if ((Math.Abs(x) > 0.75) || (Math.Abs(y) > 0.75) || (x < -0.5))
            {
                resx = Math.Log(dreal.hypot(1 + x, y));
            }
            else
            {
                resx = 0.5 * dreal.log1p(2 * x + x * x + y * y);
            }
            double resy = Math.Atan2(y, 1 + x); ;
            return new Complex(resx, resy);
        }


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



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt1pm1/*' />
        public static Complex sqrt1pm1(Complex x)
        {
            return cplx_expm1(cplx_log1p(x) * 0.5);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt1pm1/*' />
        public static Complex sqrt1pm1(dynamic x)
        {
            return sqrt1pm1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Complex rsqrt(Complex x)
        {
            return (1.0) / Complex.Sqrt(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Complex rsqrt(dynamic x)
        {
            return rsqrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static Complex cbrt(Complex x)
        {
            return Complex.Pow(x, (1.0) / 3);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static Complex cbrt(dynamic x)
        {
            return cbrt(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static Complex unitroot(Int32 k)
        {
            return Complex.Pow(1.0, (1.0) / k);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static Complex unitroot(dynamic x)
        {
            return unitroot(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static Complex root_si(Complex x, Int32 k)
        {
            return Complex.Pow(x, (1.0) / k);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static Complex root_si(dynamic x, Int32 k)
        {
            return root_si(t(x), k);
        }



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
        public static Tuple<Complex, Complex> quadratic_equation(Complex A, Complex B, Complex C)
        {
            Complex x1, x2;
            Complex D = Complex.Sqrt(B * B - 4 * A * C);
            Complex bStar = Complex.Conjugate(B);
            if ((bStar * D).Real < 0.0)
            {
                D = -D;
            }
            Complex q = -0.5 * (B + D);
            x1 = q / A;
            x2 = C / q;
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
                Complex A = -dcplx.cbrt(R + D);
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
            Complex c = -(3 * B * B * B * B) / (256 * A * A * A * A)
                        + (C * B * B) / (16 * A * A * A) - (B * D) / (4 * A * A) + E / A;
            Complex V = -B / (4 * A);
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
            return cos(x) + onej() * sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static Complex expj(dynamic x)
        {
            return expj(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static Complex expjpi(Complex x)
        {
            return cospi(x) + onej() * sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static Complex expjpi(dynamic x)
        {
            return expjpi(t(x));
        }







        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Complex exp2(Complex x)
        {
            return Complex.Exp(x) * dreal.ln2();
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Complex exp2(dynamic x)
        {
            return exp2(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static Complex exp10(Complex x)
        {
            return Complex.Exp(x) * dreal.ln10();
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static Complex exp10(dynamic x)
        {
            return exp10(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Complex expm1(Complex x)
        {
            return cplx_expm1(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Complex expm1(dynamic x)
        {
            return expm1(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Complex exp2m1(Complex x)
        {
            return cplx_expm1(x * dreal.ln2());
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Complex exp2m1(dynamic x)
        {
            return exp2m1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static Complex exp10m1(Complex x)
        {
            return cplx_expm1(x * dreal.ln10());
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



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Complex log2(Complex x)
        {
            return Complex.Log(x) / dreal.ln2();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Complex log2(dynamic x)
        {
            return log2(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Complex log10(Complex x)
        {
            return Complex.Log(x) / dreal.ln10();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Complex log10(dynamic x)
        {
            return log10(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Complex log1p(Complex x)
        {
            return cplx_log1p(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Complex log1p(dynamic x)
        {
            return log1p(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static Complex log2p1(Complex x)
        {
            return cplx_log1p(x) / dreal.ln2();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static Complex log2p1(dynamic x)
        {
            return log2p1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static Complex log10p1(Complex x)
        {
            return cplx_log1p(x) / dreal.ln10();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static Complex log10p1(dynamic x)
        {
            return log10p1(t(x));
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
            return x * x * x;
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
            return cplx_expm1(Complex.Log(x) * y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static Complex powm1(dynamic x, dynamic y)
        {
            return powm1(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static Complex pow1p(Complex x, Complex y)
        {
            return Complex.Exp(cplx_log1p(x) * y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static Complex pow1p(dynamic x, dynamic y)
        {
            return pow1p(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static Complex pow1pm1(Complex x, Complex y)
        {
            return cplx_expm1(cplx_log1p(x) * y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static Complex pow1pm1(dynamic x, dynamic y)
        {
            return pow1pm1(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static Complex pow_si(Complex x, Int32 k)
        {
            return Complex.Pow(x, k);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static Complex pow_si(dynamic x, Int32 k)
        {
            return pow_si(t(x), k);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static Complex compound_si(Complex x, Int32 k)
        {
            return Complex.Pow(1.0 + x, k);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static Complex compound_si(dynamic x, Int32 k)
        {
            return compound_si(t(x), k);
        }





        #endregion



        #region Trigonometric and related functions


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


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static Complex csc(Complex x)
        {
            return 1.0 / Complex.Sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static Complex csc(dynamic x)
        {
            return csc(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static Complex sec(Complex x)
        {
            return 1.0 / Complex.Cos(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static Complex sec(dynamic x)
        {
            return sec(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static Complex cot(Complex x)
        {
            return 1.0 / Complex.Tan(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static Complex cot(dynamic x)
        {
            return cot(t(x));
        }


        public static Tuple<Double, Double> divmod(Double a, Double b)
        {
            Double r = dreal.fmod(a, b);
            Double q = (a - r) / b;
            return new Tuple<Double, Double>(q, r);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinpi/*' />
        public static Complex sinpi(Complex x)
        {
            if (x.Real < 0) return -sinpi(-x);
            var n_r = divmod(x.Real, 0.5);
            x = dcplx.t(n_r.Item2, x.Imaginary) * dreal.pi();
            Int32 n = dreal.lrint(dreal.fmod(n_r.Item1, 4));
            if (n == 0) return dcplx.sin(x);
            else if (n == 1) return dcplx.cos(x);
            else if (n == 2) return -dcplx.sin(x);
            else return -dcplx.cos(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinpi/*' />
        public static Complex sinpi(dynamic x)
        {
            return sinpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static Complex cospi(Complex x)
        {
            if (x.Real < 0) x = -x;
            var n_r = divmod(x.Real, 0.5);
            x = dcplx.t(n_r.Item2, x.Imaginary) * dreal.pi();
            Int32 n = dreal.lrint(dreal.fmod(n_r.Item1, 4));
            if (n == 0) return dcplx.cos(x);
            else if (n == 1) return -dcplx.sin(x);
            else if (n == 2) return -dcplx.cos(x);
            else return dcplx.sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static Complex cospi(dynamic x)
        {
            return cospi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static Complex tanpi(Complex x)
        {
            return dcplx.sinpi(x) / dcplx.cospi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static Complex tanpi(dynamic x)
        {
            return tanpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static Complex cscpi(Complex x)
        {
            return 1.0 / dcplx.sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static Complex cscpi(dynamic x)
        {
            return cscpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static Complex secpi(Complex x)
        {
            return 1.0 / dcplx.cospi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static Complex secpi(dynamic x)
        {
            return secpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cotpi/*' />
        public static Complex cotpi(Complex x)
        {
            return dcplx.cospi(x) / dcplx.sinpi(x);
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
            else return dcplx.sin(x) / (x);
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
            else return dcplx.sinpi(x) / (x * dreal.pi());
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static Complex sincpi(dynamic x)
        {
            return sincpi(t(x));
        }




        #endregion



        #region Hyperbolic functions


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


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static Complex csch(Complex x)
        {
            return 1.0 / Complex.Sinh(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static Complex csch(dynamic x)
        {
            return csch(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static Complex sech(Complex x)
        {
            return 1.0 / Complex.Cosh(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static Complex sech(dynamic x)
        {
            return sech(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static Complex coth(Complex x)
        {
            return 1.0 / Complex.Tanh(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static Complex coth(dynamic x)
        {
            return coth(t(x));
        }




        #endregion



        #region Inverse trigonometric functions


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


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static Complex acsc(Complex x)
        {
            return Complex.Asin((1.0) / x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static Complex acsc(dynamic x)
        {
            return acsc(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static Complex asec(Complex x)
        {
            return Complex.Acos((1.0) / x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static Complex asec(dynamic x)
        {
            return asec(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static Complex acot(Complex x)
        {
            return Complex.Atan((1.0) / x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static Complex acot(dynamic x)
        {
            return acot(t(x));
        }


        #endregion



        #region Inverse hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static Complex asinh(Complex x)
        {
            return Complex.Asin(Complex.ImaginaryOne * x) / Complex.ImaginaryOne;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static Complex asinh(dynamic x)
        {
            return asinh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static Complex acosh(Complex x)
        {
            return  Complex.Sqrt(x-1) * Complex.Acos(x) / Complex.Sqrt(1 - x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static Complex acosh(dynamic x)
        {
            return acosh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static Complex atanh(Complex x)
        {
            return Complex.Atan(Complex.ImaginaryOne * x) / Complex.ImaginaryOne;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static Complex atanh(dynamic x)
        {
            return atanh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static Complex acsch(Complex x)
        {
            return asinh((1.0) / x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static Complex acsch(dynamic x)
        {
            return acsch(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static Complex asech(Complex x)
        {
            return acosh((1.0) / x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static Complex asech(dynamic x)
        {
            return asech(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static Complex acoth(Complex x)
        {
            return atanh((1.0) / x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static Complex acoth(dynamic x)
        {
            return acoth(t(x));
        }




        #endregion


        #endregion






        #region Matrix Creation



        public static ComplexMat mat_t(Complex x)
        {
            var matA = new ComplexMat();
            matA[0, 0] = x;
            return matA;
        }


        public static ComplexMat mat_t(DoubleMat matA)
        {
            var x = mat_zeros(matA.rows, matA.cols);
            Lib_Eigen_FReal_ConvertRealCplx(matA.mpPtr, constants.mp_conv_set_to_complex_dbl, x.mpPtr);
            return x;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_ConvertRealCplx", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_ConvertRealCplx(IntPtr RMat, int what, IntPtr CMat);


        /// <summary>
        /// Makes a deep copy from a complex matrix of type YCplxMatT
        /// </summary>
        public static ComplexMat mat_t(ComplexMat matA)
        {
            var matX = mat_zeros(matA.rows, matA.cols);
            matX = +matA;
            return matX;
        }

        public static ComplexMat mat_zeros(int n, int m)
        {
            var resout = new ComplexMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setZero, n, m);
            return resout;
        }

        /* *********************** */

        public static ComplexMat mat_cplx_t(ComplexMat matA)
        {
            return mat_t(matA);
        }


        public static ComplexMat mat_cplx_zeros(int n, int m)
        {
            return mat_zeros(n, m);
        }

        /* *********************** */






        public static ComplexMat mat_ones(int n, int m)
        {
            var resout = new ComplexMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setOnes, n, m);
            return resout;
        }



        public static ComplexMat mat_identity(int n, int m)
        {
            var resout = new ComplexMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setIdentity, n, m);
            return resout;
        }



        public static ComplexMat mat_random(int n, int m)
        {
            var resout = new ComplexMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandom_nm, n, m);
            return resout;
        }



        public static ComplexMat mat_random_symmetric(int n)
        {
            var resout = new ComplexMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSymmetric, n, n);
            return resout;
        }



        public static ComplexMat mat_random_selfadjoint(int n)
        {
            var resout = new ComplexMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSA, n, n);
            return resout;
        }



        public static ComplexMat mat_random_selfadjoint_posdef(int n)
        {
            var resout = new ComplexMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSAPosDef, n, n);
            return resout;
        }



        public static ComplexMat mat_fill_linear(int n, int m)
        {
            var resout = new ComplexMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_FillLinear, n, m);
            return resout;
        }



        #endregion







    }





}