/* C# */

#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
#endregion


namespace UserFixedPrecNet
{

    /// <summary>
    /// User defined functions based on the QuadrupleC data type
    /// </summary>
    public partial class qlibc
    {

#region General

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/name/*' />
        public static String name
        {
            get { return "qlibc"; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  qlibc"; }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static Int32 prec
        {
            get { return qreal.prec; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static qlib realctx
        {
            get { return new qlib(); }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(QuadrupleC x)
        {
            return qcplx.fmt(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(dynamic x)
        {
            return qcplx.fmt(x);
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Quadruple real(QuadrupleC x)
        {
            return qcplx.real(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Quadruple real(dynamic x)
        {
            return real(qcplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Quadruple imag(QuadrupleC x)
        {
            return qcplx.imag(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Quadruple imag(dynamic x)
        {
            return imag(qcplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Quadruple abs(QuadrupleC x)
        {
            return qcplx.abs(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Quadruple abs(dynamic x)
        {
            return abs(qcplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static QuadrupleC sin(QuadrupleC x)
        {
            return qcplx.sin(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static QuadrupleC sin(dynamic x)
        {
            return sin(qcplx.t(x));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static QuadrupleC test_add(QuadrupleC x, QuadrupleC y)
        {
            return x + y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static QuadrupleC test_add(dynamic x, dynamic y)
        {
            return test_add(qcplx.t(x), qcplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static QuadrupleC test_sub(QuadrupleC x, QuadrupleC y)
        {
            return x - y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static QuadrupleC test_sub(dynamic x, dynamic y)
        {
            return test_sub(qcplx.t(x), qcplx.t(y));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static QuadrupleC test_mul(QuadrupleC x, QuadrupleC y)
        {
            return x * y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static QuadrupleC test_mul(dynamic x, dynamic y)
        {
            return test_mul(qcplx.t(x), qcplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static QuadrupleC test_div(QuadrupleC x, QuadrupleC y)
        {
            return x / y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static QuadrupleC test_div(dynamic x, dynamic y)
        {
            return test_div(qcplx.t(x), qcplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_submul/*' />
        public static QuadrupleC test_submul(QuadrupleC x, QuadrupleC y)
        {
            return x - y + test_mul(x, y);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static QuadrupleC test_submul(dynamic x, dynamic y)
        {
            return test_submul(qcplx.t(x), qcplx.t(y));
        }


#endregion



#region poly_equations


        public static QuadrupleC eval_quadratic(QuadrupleC x, QuadrupleC A, QuadrupleC B, QuadrupleC C)
        {
            return (A * x + B) * x + C;
        }

        public static QuadrupleC eval_quadratic(dynamic x, dynamic A, dynamic B, dynamic C)
        {
            return eval_quadratic(qcplx.t(x), qcplx.t(A), qcplx.t(B), qcplx.t(C));
        }


        // See also: Press, 3rd edition, page 227
        public static Tuple<QuadrupleC, QuadrupleC> quadratic_equation(QuadrupleC a, QuadrupleC b, QuadrupleC c)
        {
            QuadrupleC x1, x2;
            QuadrupleC D = qcplx.sqrt(b * b - 4 * a * c);
            QuadrupleC bStar = qcplx.conj(b);
            if ((bStar * D).real < qreal.t(0))
            {
                D = -D;
            }
            QuadrupleC q = -0.5 * (b + D);
            x1 = q / a;
            x2 = c / q;
            return new Tuple<QuadrupleC, QuadrupleC>(x1, x2);
        }
        public static Tuple<QuadrupleC, QuadrupleC> quadratic_equation(dynamic A, dynamic B, dynamic C)
        {
            return quadratic_equation(qcplx.t(A), qcplx.t(B), qcplx.t(C));
        }




        public static QuadrupleC eval_monic_cubic(QuadrupleC x, QuadrupleC a, QuadrupleC b, QuadrupleC c)
        {
            return ((x + a) * x + b) * x + c;
        }

        public static QuadrupleC eval_monic_cubic(dynamic x, dynamic a, dynamic b, dynamic c)
        {
            return eval_monic_cubic(qcplx.t(x), qcplx.t(a), qcplx.t(b), qcplx.t(c));
        }


        // See also: Press, 3rd edition, page 228
        public static Tuple<QuadrupleC, QuadrupleC, QuadrupleC> cubic_equation_monic(QuadrupleC a, QuadrupleC b, QuadrupleC c)
        {
            QuadrupleC x1, x2, x3;
            QuadrupleC Q = (a * a - 3 * b) / 9;
            QuadrupleC R = (2 * a * a * a - 9 * a * b + 27 * c) / 54;
            Quadruple Qr = Q.real;
            Quadruple Rr = R.real;
            if ((Q.imag == qreal.t(0.0)) && (R.imag == qreal.t(0.0)) && (Rr * Rr < Qr * Qr * Qr))
            {
                Console.WriteLine("In qcplx real Case");
                Quadruple SqrtQr = qreal.sqrt(Qr);
                Quadruple theta = qreal.acos(Rr / (SqrtQr * SqrtQr * SqrtQr));
                x1 = -2 * SqrtQr * qreal.cos((theta) / 3) - a / 3;
                x2 = -2 * SqrtQr * qreal.cos((theta + 2 * qreal.pi()) / 3) - a / 3;
                x3 = -2 * SqrtQr * qreal.cos((theta - 2 * qreal.pi()) / 3) - a / 3;
            }
            else
            {
                Console.WriteLine("In qcplx QuadrupleC Case");
                QuadrupleC D = qcplx.sqrt(R * R - Q * Q * Q);
                QuadrupleC RStar = qcplx.conj(R);
                if ((RStar * D).real < qreal.t(0))
                {
                    D = -D;
                }
                QuadrupleC A = -qcplx.cbrt(R + D);
                QuadrupleC B = qcplx.zero();
                if (A != qcplx.zero())
                {
                    B = Q / A;
                }
                Console.WriteLine("A: {0}", A);
                Console.WriteLine("B: {0}", B);

                x1 = (A + B) - a / 3;
                x2 = -0.5 * (A + B) - a / 3 + 0.5 * qcplx.ImaginaryOne() * qreal.sqrt(3) * (A - B);
                x3 = -0.5 * (A + B) - a / 3 - 0.5 * qcplx.ImaginaryOne() * qreal.sqrt(3) * (A - B);
            }
            return new Tuple<QuadrupleC, QuadrupleC, QuadrupleC>(x1, x2, x3);
        }
        public static Tuple<QuadrupleC, QuadrupleC, QuadrupleC> cubic_equation_monic(dynamic a, dynamic b, dynamic c)
        {
            return cubic_equation_monic(qcplx.t(a), qcplx.t(b), qcplx.t(c));
        }




        public static QuadrupleC eval_cubic(QuadrupleC x, QuadrupleC A, QuadrupleC B, QuadrupleC C, QuadrupleC D)
        {
            return ((A * x + B) * x + C) * x + D;
        }

        public static QuadrupleC eval_cubic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return eval_cubic(qcplx.t(x), qcplx.t(A), qcplx.t(B), qcplx.t(C), qcplx.t(D));
        }


        public static Tuple<QuadrupleC, QuadrupleC, QuadrupleC> cubic_equation(QuadrupleC A, QuadrupleC B, QuadrupleC C, QuadrupleC D)
        {
            return cubic_equation_monic(B / A, C / A, D / A);
        }
        public static Tuple<QuadrupleC, QuadrupleC, QuadrupleC> cubic_equation(dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return cubic_equation(qcplx.t(A), qcplx.t(B), qcplx.t(C), qcplx.t(D));
        }




        public static QuadrupleC eval_quartic(QuadrupleC x, QuadrupleC A, QuadrupleC B, QuadrupleC C, QuadrupleC D, QuadrupleC E)
        {
            return (((A * x + B) * x + C) * x + D) * x + E;
        }

        public static QuadrupleC eval_quartic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return eval_quartic(qcplx.t(x), qcplx.t(A), qcplx.t(B), qcplx.t(C), qcplx.t(D), qcplx.t(E));
        }


        // See also: https://en.wikipedia.org/wiki/Quartic_equation#Summary_of_Ferrari's_method
        public static Tuple<QuadrupleC, QuadrupleC, QuadrupleC, QuadrupleC> quartic_equation(QuadrupleC A, QuadrupleC B, QuadrupleC C, QuadrupleC D, QuadrupleC E)
        {
            QuadrupleC x1, x2, x3, x4;
            QuadrupleC a = -(3 * B * B) / (8 * A * A) + C / A;
            QuadrupleC b = (B * B * B) / (8 * A * A * A) - (B * C) / (2 * A * A) + D / A;
            QuadrupleC c = -(3 * B * B * B * B) / (256 * A * A * A * A) + (C * B * B) / (16 * A * A * A) - (B * D) / (4 * A * A) + E / A;
            QuadrupleC V = -B / (4 * A);

            if (qcplx.iszero(b))
            {
                QuadrupleC W = qcplx.sqrt(a * a - 4 * c);
                QuadrupleC Z1 = qcplx.sqrt((-a + W) / 2);
                QuadrupleC Z2 = qcplx.sqrt((-a - W) / 2);
                x1 = V + Z1;
                x2 = V - Z1;
                x3 = V + Z2;
                x4 = V - Z2;
            }
            else
            {
                QuadrupleC e = 5 * a / 2;
                QuadrupleC f = 2 * a * a - c;
                QuadrupleC g = a * a * a / 2 - a * c / 2 - b * b / 8;
                var res = cubic_equation_monic(e, f, g);
                QuadrupleC y = res.Item1;
                QuadrupleC W = qcplx.sqrt(a + 2 * y);
                QuadrupleC Z1 = qcplx.sqrt(-(3 * a + 2 * y + 2 * b / W));
                QuadrupleC Z2 = qcplx.sqrt(-(3 * a + 2 * y - 2 * b / W));
                x1 = V + (W + Z1) / 2;
                x2 = V + (W - Z1) / 2;
                x3 = V - (W + Z2) / 2;
                x4 = V - (W - Z2) / 2;
            }
            return new Tuple<QuadrupleC, QuadrupleC, QuadrupleC, QuadrupleC>(x1, x2, x3, x4);
        }

        public static Tuple<QuadrupleC, QuadrupleC, QuadrupleC, QuadrupleC> quartic_equation(dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return quartic_equation(qcplx.t(A), qcplx.t(B), qcplx.t(C), qcplx.t(D), qcplx.t(E));
        }

#endregion




    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion


