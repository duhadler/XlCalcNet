/* C# */

#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
#endregion


namespace UserFixedPrecNet
{

    /// <summary>
    /// User defined functions based on the Complex data type
    /// </summary>
    public partial class dlibc
    {

#region General


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/name/*' />
        public static String name
        {
            get { return "dlibc"; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  dlibc"; }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static Int32 prec
        {
            get { return dreal.prec; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static dlib realctx
        {
            get { return new dlib(); }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(Complex x)
        {
            return dcplx.fmt(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(dynamic x)
        {
            return dcplx.fmt(x);
        }




        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Double real(Complex x)
        {
            return dcplx.real(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Double real(dynamic x)
        {
            return real(dcplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Double imag(Complex x)
        {
            return dcplx.imag(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Double imag(dynamic x)
        {
            return imag(dcplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Double abs(Complex x)
        {
            return dcplx.abs(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Double abs(dynamic x)
        {
            return abs(dcplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Complex sin(Complex x)
        {
            return dcplx.sin(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Complex sin(dynamic x)
        {
            return sin(dcplx.t(x));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static Complex test_add(Complex x, Complex y)
        {
            return x + y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static Complex test_add(dynamic x, dynamic y)
        {
            return test_add(dcplx.t(x), dcplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static Complex test_sub(Complex x, Complex y)
        {
            return x - y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static Complex test_sub(dynamic x, dynamic y)
        {
            return test_sub(dcplx.t(x), dcplx.t(y));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static Complex test_mul(Complex x, Complex y)
        {
            return x * y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static Complex test_mul(dynamic x, dynamic y)
        {
            return test_mul(dcplx.t(x), dcplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static Complex test_div(Complex x, Complex y)
        {
            return x / y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static Complex test_div(dynamic x, dynamic y)
        {
            return test_div(dcplx.t(x), dcplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_submul/*' />
        public static Complex test_submul(Complex x, Complex y)
        {
            return x - y + test_mul(x, y);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static Complex test_submul(dynamic x, dynamic y)
        {
            return test_submul(dcplx.t(x), dcplx.t(y));
        }


#endregion




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




    }
}




/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion




