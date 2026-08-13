/* C# */

#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
#endregion


namespace UserFixedPrecNet
{

    /// <summary>
    /// User defined functions based on the ExtendedC data type
    /// </summary>
    public partial class elibc
    {

#region General

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/name/*' />
        public static String name
        {
            get { return "elibc"; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  elibc"; }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static Int32 prec
        {
            get { return ereal.prec; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static elib realctx
        {
            get { return new elib(); }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(ExtendedC x)
        {
            return ecplx.fmt(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(dynamic x)
        {
            return ecplx.fmt(x);
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Extended real(ExtendedC x)
        {
            return ecplx.real(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Extended real(dynamic x)
        {
            return real(ecplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Extended imag(ExtendedC x)
        {
            return ecplx.imag(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Extended imag(dynamic x)
        {
            return imag(ecplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Extended abs(ExtendedC x)
        {
            return ecplx.abs(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Extended abs(dynamic x)
        {
            return abs(ecplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static ExtendedC sin(ExtendedC x)
        {
            return ecplx.sin(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static ExtendedC sin(dynamic x)
        {
            return sin(ecplx.t(x));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static ExtendedC test_add(ExtendedC x, ExtendedC y)
        {
            return x + y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static ExtendedC test_add(dynamic x, dynamic y)
        {
            return test_add(ecplx.t(x), ecplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static ExtendedC test_sub(ExtendedC x, ExtendedC y)
        {
            return x - y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static ExtendedC test_sub(dynamic x, dynamic y)
        {
            return test_sub(ecplx.t(x), ecplx.t(y));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static ExtendedC test_mul(ExtendedC x, ExtendedC y)
        {
            return x * y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static ExtendedC test_mul(dynamic x, dynamic y)
        {
            return test_mul(ecplx.t(x), ecplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static ExtendedC test_div(ExtendedC x, ExtendedC y)
        {
            return x / y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static ExtendedC test_div(dynamic x, dynamic y)
        {
            return test_div(ecplx.t(x), ecplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_submul/*' />
        public static ExtendedC test_submul(ExtendedC x, ExtendedC y)
        {
            return x - y + test_mul(x, y);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static ExtendedC test_submul(dynamic x, dynamic y)
        {
            return test_submul(ecplx.t(x), ecplx.t(y));
        }


#endregion




#region poly_equations


        public static ExtendedC eval_quadratic(ExtendedC x, ExtendedC A, ExtendedC B, ExtendedC C)
        {
            return (A * x + B) * x + C;
        }

        public static ExtendedC eval_quadratic(dynamic x, dynamic A, dynamic B, dynamic C)
        {
            return eval_quadratic(ecplx.t(x), ecplx.t(A), ecplx.t(B), ecplx.t(C));
        }


        // See also: Press, 3rd edition, page 227
        public static Tuple<ExtendedC, ExtendedC> quadratic_equation(ExtendedC a, ExtendedC b, ExtendedC c)
        {
            ExtendedC x1, x2;
            ExtendedC D = ecplx.sqrt(b * b - 4 * a * c);
            ExtendedC bStar = ecplx.conj(b);
            if ((bStar * D).real < ereal.t(0))
            {
                D = -D;
            }
            ExtendedC q = -0.5 * (b + D);
            x1 = q / a;
            x2 = c / q;
            return new Tuple<ExtendedC, ExtendedC>(x1, x2);
        }
        public static Tuple<ExtendedC, ExtendedC> quadratic_equation(dynamic A, dynamic B, dynamic C)
        {
            return quadratic_equation(ecplx.t(A), ecplx.t(B), ecplx.t(C));
        }





        public static ExtendedC eval_monic_cubic(ExtendedC x, ExtendedC a, ExtendedC b, ExtendedC c)
        {
            return ((x + a) * x + b) * x + c;
        }

        public static ExtendedC eval_monic_cubic(dynamic x, dynamic a, dynamic b, dynamic c)
        {
            return eval_monic_cubic(ecplx.t(x), ecplx.t(a), ecplx.t(b), ecplx.t(c));
        }


        // See also: Press, 3rd edition, page 228
        public static Tuple<ExtendedC, ExtendedC, ExtendedC> cubic_equation_monic(ExtendedC a, ExtendedC b, ExtendedC c)
        {
            ExtendedC x1, x2, x3;
            ExtendedC Q = (a * a - 3 * b) / 9;
            ExtendedC R = (2 * a * a * a - 9 * a * b + 27 * c) / 54;
            Extended Qr = Q.real;
            Extended Rr = R.real;
            if ((Q.imag == ereal.t(0.0)) && (R.imag == ereal.t(0.0)) && (Rr * Rr < Qr * Qr * Qr))
            {
                Console.WriteLine("In ecplx real Case");
                Extended SqrtQr = ereal.sqrt(Qr);
                Extended theta = ereal.acos(Rr / (SqrtQr * SqrtQr * SqrtQr));
                x1 = -2 * SqrtQr * ereal.cos((theta) / 3) - a / 3;
                x2 = -2 * SqrtQr * ereal.cos((theta + 2 * ereal.pi()) / 3) - a / 3;
                x3 = -2 * SqrtQr * ereal.cos((theta - 2 * ereal.pi()) / 3) - a / 3;
            }
            else
            {
                Console.WriteLine("In ecplx ExtendedC Case");
                ExtendedC D = ecplx.sqrt(R * R - Q * Q * Q);
                ExtendedC RStar = ecplx.conj(R);
                if ((RStar * D).real < ereal.t(0))
                {
                    D = -D;
                }
                ExtendedC A = -ecplx.cbrt(R + D);
                ExtendedC B = ecplx.zero();
                if (A != ecplx.zero())
                {
                    B = Q / A;
                }
                Console.WriteLine("A: {0}", A);
                Console.WriteLine("B: {0}", B);

                x1 = (A + B) - a / 3;
                x2 = -0.5 * (A + B) - a / 3 + 0.5 * ecplx.ImaginaryOne() * ereal.sqrt(3) * (A - B);
                x3 = -0.5 * (A + B) - a / 3 - 0.5 * ecplx.ImaginaryOne() * ereal.sqrt(3) * (A - B);
            }
            return new Tuple<ExtendedC, ExtendedC, ExtendedC>(x1, x2, x3);
        }
        public static Tuple<ExtendedC, ExtendedC, ExtendedC> cubic_equation_monic(dynamic a, dynamic b, dynamic c)
        {
            return cubic_equation_monic(ecplx.t(a), ecplx.t(b), ecplx.t(c));
        }




        public static ExtendedC eval_cubic(ExtendedC x, ExtendedC A, ExtendedC B, ExtendedC C, ExtendedC D)
        {
            return ((A * x + B) * x + C) * x + D;
        }

        public static ExtendedC eval_cubic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return eval_cubic(ecplx.t(x), ecplx.t(A), ecplx.t(B), ecplx.t(C), ecplx.t(D));
        }


        public static Tuple<ExtendedC, ExtendedC, ExtendedC> cubic_equation(ExtendedC A, ExtendedC B, ExtendedC C, ExtendedC D)
        {
            return cubic_equation_monic(B / A, C / A, D / A);
        }
        public static Tuple<ExtendedC, ExtendedC, ExtendedC> cubic_equation(dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return cubic_equation(ecplx.t(A), ecplx.t(B), ecplx.t(C), ecplx.t(D));
        }




        public static ExtendedC eval_quartic(ExtendedC x, ExtendedC A, ExtendedC B, ExtendedC C, ExtendedC D, ExtendedC E)
        {
            return (((A * x + B) * x + C) * x + D) * x + E;
        }

        public static ExtendedC eval_quartic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return eval_quartic(ecplx.t(x), ecplx.t(A), ecplx.t(B), ecplx.t(C), ecplx.t(D), ecplx.t(E));
        }


        // See also: https://en.wikipedia.org/wiki/Quartic_equation#Summary_of_Ferrari's_method
        public static Tuple<ExtendedC, ExtendedC, ExtendedC, ExtendedC> quartic_equation(ExtendedC A, ExtendedC B, ExtendedC C, ExtendedC D, ExtendedC E)
        {
            ExtendedC x1, x2, x3, x4;
            ExtendedC a = -(3 * B * B) / (8 * A * A) + C / A;
            ExtendedC b = (B * B * B) / (8 * A * A * A) - (B * C) / (2 * A * A) + D / A;
            ExtendedC c = -(3 * B * B * B * B) / (256 * A * A * A * A) + (C * B * B) / (16 * A * A * A) - (B * D) / (4 * A * A) + E / A;
            ExtendedC V = -B / (4 * A);

            if (ecplx.iszero(b))
            {
                ExtendedC W = ecplx.sqrt(a * a - 4 * c);
                ExtendedC Z1 = ecplx.sqrt((-a + W) / 2);
                ExtendedC Z2 = ecplx.sqrt((-a - W) / 2);
                x1 = V + Z1;
                x2 = V - Z1;
                x3 = V + Z2;
                x4 = V - Z2;
            }
            else
            {
                ExtendedC e = 5 * a / 2;
                ExtendedC f = 2 * a * a - c;
                ExtendedC g = a * a * a / 2 - a * c / 2 - b * b / 8;
                var res = cubic_equation_monic(e, f, g);
                ExtendedC y = res.Item1;
                ExtendedC W = ecplx.sqrt(a + 2 * y);
                ExtendedC Z1 = ecplx.sqrt(-(3 * a + 2 * y + 2 * b / W));
                ExtendedC Z2 = ecplx.sqrt(-(3 * a + 2 * y - 2 * b / W));
                x1 = V + (W + Z1) / 2;
                x2 = V + (W - Z1) / 2;
                x3 = V - (W + Z2) / 2;
                x4 = V - (W - Z2) / 2;
            }
            return new Tuple<ExtendedC, ExtendedC, ExtendedC, ExtendedC>(x1, x2, x3, x4);
        }

        public static Tuple<ExtendedC, ExtendedC, ExtendedC, ExtendedC> quartic_equation(dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return quartic_equation(ecplx.t(A), ecplx.t(B), ecplx.t(C), ecplx.t(D), ecplx.t(E));
        }


#endregion




    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion


