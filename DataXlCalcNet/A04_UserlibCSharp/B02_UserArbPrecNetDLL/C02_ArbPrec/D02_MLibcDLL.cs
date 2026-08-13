/* C# */

#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
using ArbPrecNet;
#endregion


namespace UserArbPrecNet
{

    /// <summary>
    /// User defined functions based on the MpfrC data type
    /// </summary>
    public partial class mlibc
    {


#region General

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/name/*' />
        public static String name
        {
            get { return "mlibc"; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  mlibc"; }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static Int32 prec
        {
            get { return mreal.prec; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static mlib realctx
        {
            get { return new mlib(); }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(MpfrC x)
        {
            return mcplx.fmt(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(dynamic x)
        {
            return mcplx.fmt(x);
        }




        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Mpfr real(MpfrC x)
        {
            return mcplx.real(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Mpfr real(dynamic x)
        {
            return real(mcplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Mpfr imag(MpfrC x)
        {
            return mcplx.imag(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Mpfr imag(dynamic x)
        {
            return imag(mcplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Mpfr abs(MpfrC x)
        {
            return mcplx.abs(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Mpfr abs(dynamic x)
        {
            return abs(mcplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static MpfrC sin(MpfrC x)
        {
            return mcplx.sin(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static MpfrC sin(dynamic x)
        {
            return sin(mcplx.t(x));
        }






        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static MpfrC test_add(MpfrC x, MpfrC y)
        {
            return x + y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static MpfrC test_add(dynamic x, dynamic y)
        {
            return test_add(mcplx.t(x), mcplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static MpfrC test_sub(MpfrC x, MpfrC y)
        {
            return x - y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static MpfrC test_sub(dynamic x, dynamic y)
        {
            return test_sub(mcplx.t(x), mcplx.t(y));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static MpfrC test_mul(MpfrC x, MpfrC y)
        {
            return x * y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static MpfrC test_mul(dynamic x, dynamic y)
        {
            return test_mul(mcplx.t(x), mcplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static MpfrC test_div(MpfrC x, MpfrC y)
        {
            return x / y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static MpfrC test_div(dynamic x, dynamic y)
        {
            return test_div(mcplx.t(x), mcplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_submul/*' />
        public static MpfrC test_submul(MpfrC x, MpfrC y)
        {
            return x - y + test_mul(x, y);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static MpfrC test_submul(dynamic x, dynamic y)
        {
            return test_submul(mcplx.t(x), mcplx.t(y));
        }


#endregion




#region poly_equations


        public static MpfrC eval_quadratic(MpfrC x, MpfrC A, MpfrC B, MpfrC C)
        {
            return (A * x + B) * x + C;
        }

        public static MpfrC eval_quadratic(dynamic x, dynamic A, dynamic B, dynamic C)
        {
            return eval_quadratic(mcplx.t(x), mcplx.t(A), mcplx.t(B), mcplx.t(C));
        }


        // See also: Press, 3rd edition, page 227
        public static Tuple<MpfrC, MpfrC> quadratic_equation(MpfrC a, MpfrC b, MpfrC c)
        {
            MpfrC x1, x2;
            MpfrC D = mflintc.sqrt(b * b - 4 * a * c);
            MpfrC bStar = mflintc.conj(b);
            if ((bStar * D).real < mflint.t(0))
            {
                D = -D;
            }
            MpfrC q = -0.5 * (b + D);
            x1 = q / a;
            x2 = c / q;
            return new Tuple<MpfrC, MpfrC>(x1, x2);
        }
        public static Tuple<MpfrC, MpfrC> quadratic_equation(dynamic A, dynamic B, dynamic C)
        {
            return quadratic_equation(mcplx.t(A), mcplx.t(B), mcplx.t(C));
        }




        public static MpfrC eval_monic_cubic(MpfrC x, MpfrC a, MpfrC b, MpfrC c)
        {
            return ((x + a) * x + b) * x + c;
        }

        public static MpfrC eval_monic_cubic(dynamic x, dynamic a, dynamic b, dynamic c)
        {
            return eval_monic_cubic(mcplx.t(x), mcplx.t(a), mcplx.t(b), mcplx.t(c));
        }


        // See also: Press, 3rd edition, page 228
        public static Tuple<MpfrC, MpfrC, MpfrC> cubic_equation_monic(MpfrC a, MpfrC b, MpfrC c)
        {
            MpfrC x1, x2, x3;
            MpfrC Q = (a * a - 3 * b) / 9;
            MpfrC R = (2 * a * a * a - 9 * a * b + 27 * c) / 54;
            Mpfr Qr = Q.real;
            Mpfr Rr = R.real;
            if ((Q.imag == mflint.t(0.0)) && (R.imag == mflint.t(0.0)) && (Rr * Rr < Qr * Qr * Qr))
            {
                Console.WriteLine("In mflintc real Case");
                Mpfr SqrtQr = mflint.sqrt(Qr);
                Mpfr theta = mflint.acos(Rr / (SqrtQr * SqrtQr * SqrtQr));
                x1 = -2 * SqrtQr * mflint.cos((theta) / 3) - a / 3;
                x2 = -2 * SqrtQr * mflint.cos((theta + 2 * mflint.pi()) / 3) - a / 3;
                x3 = -2 * SqrtQr * mflint.cos((theta - 2 * mflint.pi()) / 3) - a / 3;
            }
            else
            {
                Console.WriteLine("In mflintc MpfrC Case");
                MpfrC D = mflintc.sqrt(R * R - Q * Q * Q);
                MpfrC RStar = mflintc.conj(R);
                if ((RStar * D).real < mflint.t(0))
                {
                    D = -D;
                }
                MpfrC A = -mflintc.cbrt(R + D);
                MpfrC B = mflintc.zero();
                if (A != mflintc.zero())
                {
                    B = Q / A;
                }
                Console.WriteLine("A: {0}", A);
                Console.WriteLine("B: {0}", B);

                x1 = (A + B) - a / 3;
                x2 = -0.5 * (A + B) - a / 3 + 0.5 * mflintc.onei() * mflint.sqrt(3) * (A - B);
                x3 = -0.5 * (A + B) - a / 3 - 0.5 * mflintc.onei() * mflint.sqrt(3) * (A - B);
            }
            return new Tuple<MpfrC, MpfrC, MpfrC>(x1, x2, x3);
        }
        public static Tuple<MpfrC, MpfrC, MpfrC> cubic_equation_monic(dynamic a, dynamic b, dynamic c)
        {
            return cubic_equation_monic(mcplx.t(a), mcplx.t(b), mcplx.t(c));
        }




        public static MpfrC eval_cubic(MpfrC x, MpfrC A, MpfrC B, MpfrC C, MpfrC D)
        {
            return ((A * x + B) * x + C) * x + D;
        }

        public static MpfrC eval_cubic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return eval_cubic(mcplx.t(x), mcplx.t(A), mcplx.t(B), mcplx.t(C), mcplx.t(D));
        }


        public static Tuple<MpfrC, MpfrC, MpfrC> cubic_equation(MpfrC A, MpfrC B, MpfrC C, MpfrC D)
        {
            return cubic_equation_monic(B / A, C / A, D / A);
        }
        public static Tuple<MpfrC, MpfrC, MpfrC> cubic_equation(dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return cubic_equation(mcplx.t(A), mcplx.t(B), mcplx.t(C), mcplx.t(D));
        }





        public static MpfrC eval_quartic(MpfrC x, MpfrC A, MpfrC B, MpfrC C, MpfrC D, MpfrC E)
        {
            return (((A * x + B) * x + C) * x + D) * x + E;
        }

        public static MpfrC eval_quartic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return eval_quartic(mcplx.t(x), mcplx.t(A), mcplx.t(B), mcplx.t(C), mcplx.t(D), mcplx.t(E));
        }


        // See also: https://en.wikipedia.org/wiki/Quartic_equation#Summary_of_Ferrari's_method
        public static Tuple<MpfrC, MpfrC, MpfrC, MpfrC> quartic_equation(MpfrC A, MpfrC B, MpfrC C, MpfrC D, MpfrC E)
        {
            MpfrC x1, x2, x3, x4;
            MpfrC a = -(3 * B * B) / (8 * A * A) + C / A;
            MpfrC b = (B * B * B) / (8 * A * A * A) - (B * C) / (2 * A * A) + D / A;
            MpfrC c = -(3 * B * B * B * B) / (256 * A * A * A * A) + (C * B * B) / (16 * A * A * A) - (B * D) / (4 * A * A) + E / A;
            MpfrC V = -B / (4 * A);

            if (mflintc.iszero(b))
            {
                MpfrC W = mflintc.sqrt(a * a - 4 * c);
                MpfrC Z1 = mflintc.sqrt((-a + W) / 2);
                MpfrC Z2 = mflintc.sqrt((-a - W) / 2);
                x1 = V + Z1;
                x2 = V - Z1;
                x3 = V + Z2;
                x4 = V - Z2;
            }
            else
            {
                MpfrC e = 5 * a / 2;
                MpfrC f = 2 * a * a - c;
                MpfrC g = a * a * a / 2 - a * c / 2 - b * b / 8;
                var res = cubic_equation_monic(e, f, g);
                MpfrC y = res.Item1;
                MpfrC W = mflintc.sqrt(a + 2 * y);
                MpfrC Z1 = mflintc.sqrt(-(3 * a + 2 * y + 2 * b / W));
                MpfrC Z2 = mflintc.sqrt(-(3 * a + 2 * y - 2 * b / W));
                x1 = V + (W + Z1) / 2;
                x2 = V + (W - Z1) / 2;
                x3 = V - (W + Z2) / 2;
                x4 = V - (W - Z2) / 2;
            }
            return new Tuple<MpfrC, MpfrC, MpfrC, MpfrC>(x1, x2, x3, x4);
        }

        public static Tuple<MpfrC, MpfrC, MpfrC, MpfrC> quartic_equation(dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return quartic_equation(mcplx.t(A), mcplx.t(B), mcplx.t(C), mcplx.t(D), mcplx.t(E));
        }


#endregion





    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion


