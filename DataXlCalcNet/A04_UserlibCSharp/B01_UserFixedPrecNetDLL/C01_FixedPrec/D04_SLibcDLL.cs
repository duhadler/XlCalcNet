/* C# */

#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
#endregion


namespace UserFixedPrecNet
{

    /// <summary>
    /// User defined functions based on the SingleC data type
    /// </summary>
    public partial class slibc
    {

#region General

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/name/*' />
        public static String name
        {
            get { return "slibc"; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  slibc"; }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static Int32 prec
        {
            get { return sreal.prec; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static slib realctx
        {
            get { return new slib(); }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(SingleC x)
        {
            return scplx.fmt(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(dynamic x)
        {
            return scplx.fmt(x);
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Single real(SingleC x)
        {
            return scplx.real(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Single real(dynamic x)
        {
            return real(scplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Single imag(SingleC x)
        {
            return scplx.imag(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Single imag(dynamic x)
        {
            return imag(scplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Single abs(SingleC x)
        {
            return scplx.abs(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Single abs(dynamic x)
        {
            return abs(scplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static SingleC sin(SingleC x)
        {
            return scplx.sin(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static SingleC sin(dynamic x)
        {
            return sin(scplx.t(x));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static SingleC test_add(SingleC x, SingleC y)
        {
            return x + y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static SingleC test_add(dynamic x, dynamic y)
        {
            return test_add(scplx.t(x), scplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static SingleC test_sub(SingleC x, SingleC y)
        {
            return x - y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static SingleC test_sub(dynamic x, dynamic y)
        {
            return test_sub(scplx.t(x), scplx.t(y));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static SingleC test_mul(SingleC x, SingleC y)
        {
            return x * y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static SingleC test_mul(dynamic x, dynamic y)
        {
            return test_mul(scplx.t(x), scplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static SingleC test_div(SingleC x, SingleC y)
        {
            return x / y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static SingleC test_div(dynamic x, dynamic y)
        {
            return test_div(scplx.t(x), scplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_submul/*' />
        public static SingleC test_submul(SingleC x, SingleC y)
        {
            return x - y + test_mul(x, y);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static SingleC test_submul(dynamic x, dynamic y)
        {
            return test_submul(scplx.t(x), scplx.t(y));
        }


#endregion




#region poly_equations


        public static SingleC eval_quadratic(SingleC x, SingleC A, SingleC B, SingleC C)
        {
            return (A * x + B) * x + C;
        }

        public static SingleC eval_quadratic(dynamic x, dynamic A, dynamic B, dynamic C)
        {
            return eval_quadratic(scplx.t(x), scplx.t(A), scplx.t(B), scplx.t(C));
        }


        // See also: Press, 3rd edition, page 227
        public static Tuple<SingleC, SingleC> quadratic_equation(SingleC a, SingleC b, SingleC c)
        {
            SingleC x1, x2;
            SingleC D = scplx.sqrt(b * b - 4 * a * c);
            SingleC bStar = scplx.conj(b);
            if ((bStar * D).real < sreal.t(0))
            {
                D = -D;
            }
            SingleC q = -0.5 * (b + D);
            x1 = q / a;
            x2 = c / q;
            return new Tuple<SingleC, SingleC>(x1, x2);
        }
        public static Tuple<SingleC, SingleC> quadratic_equation(dynamic A, dynamic B, dynamic C)
        {
            return scplx.quadratic_equation(scplx.t(A), scplx.t(B), scplx.t(C));
        }





        public static SingleC eval_monic_cubic(SingleC x, SingleC a, SingleC b, SingleC c)
        {
            return ((x + a) * x + b) * x + c;
        }

        public static SingleC eval_monic_cubic(dynamic x, dynamic a, dynamic b, dynamic c)
        {
            return eval_monic_cubic(scplx.t(x), scplx.t(a), scplx.t(b), scplx.t(c));
        }


        // See also: Press, 3rd edition, page 228
        public static Tuple<SingleC, SingleC, SingleC> cubic_equation_monic(SingleC a, SingleC b, SingleC c)
        {
            SingleC x1, x2, x3;
            SingleC Q = (a * a - 3 * b) / 9;
            SingleC R = (2 * a * a * a - 9 * a * b + 27 * c) / 54;
            Single Qr = Q.real;
            Single Rr = R.real;
            if ((Q.imag == sreal.t(0.0)) && (R.imag == sreal.t(0.0)) && (Rr * Rr < Qr * Qr * Qr))
            {
                Console.WriteLine("In scplx real Case");
                Single SqrtQr = sreal.sqrt(Qr);
                Single theta = sreal.acos(Rr / (SqrtQr * SqrtQr * SqrtQr));
                x1 = -2 * SqrtQr * sreal.cos((theta) / 3) - a / 3;
                x2 = -2 * SqrtQr * sreal.cos((theta + 2 * sreal.pi()) / 3) - a / 3;
                x3 = -2 * SqrtQr * sreal.cos((theta - 2 * sreal.pi()) / 3) - a / 3;
            }
            else
            {
                Console.WriteLine("In scplx SingleC Case");
                SingleC D = scplx.sqrt(R * R - Q * Q * Q);
                SingleC RStar = scplx.conj(R);
                if ((RStar * D).real < sreal.t(0))
                {
                    D = -D;
                }
                SingleC A = -scplx.cbrt(R + D);
                SingleC B = scplx.zero();
                if (A != scplx.zero())
                {
                    B = Q / A;
                }
                Console.WriteLine("A: {0}", A);
                Console.WriteLine("B: {0}", B);

                x1 = (A + B) - a / 3;
                x2 = -0.5 * (A + B) - a / 3 + 0.5 * scplx.ImaginaryOne() * sreal.sqrt(3) * (A - B);
                x3 = -0.5 * (A + B) - a / 3 - 0.5 * scplx.ImaginaryOne() * sreal.sqrt(3) * (A - B);
            }
            return new Tuple<SingleC, SingleC, SingleC>(x1, x2, x3);
        }
        public static Tuple<SingleC, SingleC, SingleC> cubic_equation_monic(dynamic a, dynamic b, dynamic c)
        {
            return cubic_equation_monic(scplx.t(a), scplx.t(b), scplx.t(c));
        }





        public static SingleC eval_cubic(SingleC x, SingleC A, SingleC B, SingleC C, SingleC D)
        {
            return ((A * x + B) * x + C) * x + D;
        }

        public static SingleC eval_cubic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return eval_cubic(scplx.t(x), scplx.t(A), scplx.t(B), scplx.t(C), scplx.t(D));
        }


        public static Tuple<SingleC, SingleC, SingleC> cubic_equation(SingleC A, SingleC B, SingleC C, SingleC D)
        {
            return cubic_equation_monic(B / A, C / A, D / A);
        }
        public static Tuple<SingleC, SingleC, SingleC> cubic_equation(dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return cubic_equation(scplx.t(A), scplx.t(B), scplx.t(C), scplx.t(D));
        }





        public static SingleC eval_quartic(SingleC x, SingleC A, SingleC B, SingleC C, SingleC D, SingleC E)
        {
            return (((A * x + B) * x + C) * x + D) * x + E;
        }

        public static SingleC eval_quartic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return eval_quartic(scplx.t(x), scplx.t(A), scplx.t(B), scplx.t(C), scplx.t(D), scplx.t(E));
        }


        // See also: https://en.wikipedia.org/wiki/Quartic_equation#Summary_of_Ferrari's_method
        public static Tuple<SingleC, SingleC, SingleC, SingleC> quartic_equation(SingleC A, SingleC B, SingleC C, SingleC D, SingleC E)
        {
            SingleC x1, x2, x3, x4;
            SingleC a = -(3 * B * B) / (8 * A * A) + C / A;
            SingleC b = (B * B * B) / (8 * A * A * A) - (B * C) / (2 * A * A) + D / A;
            SingleC c = -(3 * B * B * B * B) / (256 * A * A * A * A) + (C * B * B) / (16 * A * A * A) - (B * D) / (4 * A * A) + E / A;
            SingleC V = -B / (4 * A);

            if (scplx.iszero(b))
            {
                SingleC W = scplx.sqrt(a * a - 4 * c);
                SingleC Z1 = scplx.sqrt((-a + W) / 2);
                SingleC Z2 = scplx.sqrt((-a - W) / 2);
                x1 = V + Z1;
                x2 = V - Z1;
                x3 = V + Z2;
                x4 = V - Z2;
            }
            else
            {
                SingleC e = 5 * a / 2;
                SingleC f = 2 * a * a - c;
                SingleC g = a * a * a / 2 - a * c / 2 - b * b / 8;
                var res = cubic_equation_monic(e, f, g);
                SingleC y = res.Item1;
                SingleC W = scplx.sqrt(a + 2 * y);
                SingleC Z1 = scplx.sqrt(-(3 * a + 2 * y + 2 * b / W));
                SingleC Z2 = scplx.sqrt(-(3 * a + 2 * y - 2 * b / W));
                x1 = V + (W + Z1) / 2;
                x2 = V + (W - Z1) / 2;
                x3 = V - (W + Z2) / 2;
                x4 = V - (W - Z2) / 2;
            }
            return new Tuple<SingleC, SingleC, SingleC, SingleC>(x1, x2, x3, x4);
        }

        public static Tuple<SingleC, SingleC, SingleC, SingleC> quartic_equation(dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return quartic_equation(scplx.t(A), scplx.t(B), scplx.t(C), scplx.t(D), scplx.t(E));
        }


#endregion




    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion




