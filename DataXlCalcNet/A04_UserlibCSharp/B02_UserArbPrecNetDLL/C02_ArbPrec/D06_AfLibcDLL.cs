
#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
using ArbPrecNet;
#endregion


namespace UserArbPrecNet
{

    /// <summary>
    /// User defined functions based on the ArbC data type
    /// </summary>
    public partial class aflibc
    {

#region General

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/name/*' />
        public static String name
        {
            get { return "aflibc"; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmtname/*' />
        public static String fmtname
        {
            get { return " aflibc"; }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static Int32 prec
        {
            get { return mreal.prec; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static aflib realctx
        {
            get { return new aflib(); }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(ArbC x)
        {
            return aflintc.fmt(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(dynamic x)
        {
            return aflintc.fmt(x);
        }




        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Arb real(ArbC x)
        {
            return aflintc.real(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Arb real(dynamic x)
        {
            return real(aflintc.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Arb imag(ArbC x)
        {
            return aflintc.imag(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Arb imag(dynamic x)
        {
            return imag(aflintc.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Arb abs(ArbC x)
        {
            return aflintc.abs(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Arb abs(dynamic x)
        {
            return abs(aflintc.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static ArbC sin(ArbC x)
        {
            return aflintc.sin(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static ArbC sin(dynamic x)
        {
            return sin(aflintc.t(x));
        }






        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static ArbC test_add(ArbC x, ArbC y)
        {
            return x + y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static ArbC test_add(dynamic x, dynamic y)
        {
            return test_add(aflintc.t(x), aflintc.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static ArbC test_sub(ArbC x, ArbC y)
        {
            return x - y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static ArbC test_sub(dynamic x, dynamic y)
        {
            return test_sub(aflintc.t(x), aflintc.t(y));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static ArbC test_mul(ArbC x, ArbC y)
        {
            return x * y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static ArbC test_mul(dynamic x, dynamic y)
        {
            return test_mul(aflintc.t(x), aflintc.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static ArbC test_div(ArbC x, ArbC y)
        {
            return x / y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static ArbC test_div(dynamic x, dynamic y)
        {
            return test_div(aflintc.t(x), aflintc.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_submul/*' />
        public static ArbC test_submul(ArbC x, ArbC y)
        {
            return x - y + test_mul(x, y);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static ArbC testsubmul(dynamic x, dynamic y)
        {
            return test_submul(aflintc.t(x), aflintc.t(y));
        }



#endregion




#region poly_equations


        public static ArbC eval_quadratic(ArbC x, ArbC A, ArbC B, ArbC C)
        {
            return (A * x + B) * x + C;
        }

        public static ArbC eval_quadratic(dynamic x, dynamic A, dynamic B, dynamic C)
        {
            return eval_quadratic(aflintc.t(x), aflintc.t(A), aflintc.t(B), aflintc.t(C));
        }


        // See also: Press, 3rd edition, page 227
        public static Tuple<ArbC, ArbC> quadratic_equation(ArbC a, ArbC b, ArbC c)
        {
            ArbC x1, x2;
            ArbC D = aflintc.sqrt(b * b - 4 * a * c);
            ArbC bStar = aflintc.conj(b);
            if ((bStar * D).real < aflint.t(0))
            {
                D = -D;
            }
            ArbC q = -0.5 * (b + D);
            x1 = q / a;
            x2 = c / q;
            return new Tuple<ArbC, ArbC>(x1, x2);
        }
        public static Tuple<ArbC, ArbC> quadratic_equation(dynamic A, dynamic B, dynamic C)
        {
            return quadratic_equation(aflintc.t(A), aflintc.t(B), aflintc.t(C));
        }




        public static ArbC eval_monic_cubic(ArbC x, ArbC a, ArbC b, ArbC c)
        {
            return ((x + a) * x + b) * x + c;
        }

        public static ArbC eval_monic_cubic(dynamic x, dynamic a, dynamic b, dynamic c)
        {
            return eval_monic_cubic(aflintc.t(x), aflintc.t(a), aflintc.t(b), aflintc.t(c));
        }


        // See also: Press, 3rd edition, page 228
        public static Tuple<ArbC, ArbC, ArbC> cubic_equation_monic(ArbC a, ArbC b, ArbC c)
        {
            ArbC x1, x2, x3;
            ArbC Q = (a * a - 3 * b) / 9;
            ArbC R = (2 * a * a * a - 9 * a * b + 27 * c) / 54;
            Arb Qr = Q.real;
            Arb Rr = R.real;
            if ((Q.imag == aflint.t(0.0)) && (R.imag == aflint.t(0.0)) && (Rr * Rr < Qr * Qr * Qr))
            {
                Console.WriteLine("In aflintc real Case");
                Arb SqrtQr = aflint.sqrt(Qr);
                Arb theta = aflint.acos(Rr / (SqrtQr * SqrtQr * SqrtQr));
                x1 = -2 * SqrtQr * aflint.cos((theta) / 3) - a / 3;
                x2 = -2 * SqrtQr * aflint.cos((theta + 2 * aflint.pi()) / 3) - a / 3;
                x3 = -2 * SqrtQr * aflint.cos((theta - 2 * aflint.pi()) / 3) - a / 3;
            }
            else
            {
                Console.WriteLine("In aflintc ArbC Case");
                ArbC D = aflintc.sqrt(R * R - Q * Q * Q);
                ArbC RStar = aflintc.conj(R);
                if ((RStar * D).real < aflint.t(0))
                {
                    D = -D;
                }
                ArbC A = -aflintc.cbrt(R + D);
                ArbC B = aflintc.zero();
                if (A != aflintc.zero())
                {
                    B = Q / A;
                }
                Console.WriteLine("A: {0}", A);
                Console.WriteLine("B: {0}", B);

                x1 = (A + B) - a / 3;
                x2 = -0.5 * (A + B) - a / 3 + 0.5 * aflintc.onei() * aflint.sqrt(3) * (A - B);
                x3 = -0.5 * (A + B) - a / 3 - 0.5 * aflintc.onei() * aflint.sqrt(3) * (A - B);
            }
            return new Tuple<ArbC, ArbC, ArbC>(x1, x2, x3);
        }
        public static Tuple<ArbC, ArbC, ArbC> cubic_equation_monic(dynamic a, dynamic b, dynamic c)
        {
            return cubic_equation_monic(aflintc.t(a), aflintc.t(b), aflintc.t(c));
        }





        public static ArbC eval_cubic(ArbC x, ArbC A, ArbC B, ArbC C, ArbC D)
        {
            return ((A * x + B) * x + C) * x + D;
        }

        public static ArbC eval_cubic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return eval_cubic(aflintc.t(x), aflintc.t(A), aflintc.t(B), aflintc.t(C), aflintc.t(D));
        }

        public static Tuple<ArbC, ArbC, ArbC> cubic_equation(ArbC A, ArbC B, ArbC C, ArbC D)
        {
            return cubic_equation_monic(B / A, C / A, D / A);
        }
        public static Tuple<ArbC, ArbC, ArbC> cubic_equation(dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return cubic_equation(aflintc.t(A), aflintc.t(B), aflintc.t(C), aflintc.t(D));
        }






        public static ArbC eval_quartic(ArbC x, ArbC A, ArbC B, ArbC C, ArbC D, ArbC E)
        {
            return (((A * x + B) * x + C) * x + D) * x + E;
        }

        public static ArbC eval_quartic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return eval_quartic(aflintc.t(x), aflintc.t(A), aflintc.t(B), aflintc.t(C), aflintc.t(D), aflintc.t(E));
        }


        // See also: https://en.wikipedia.org/wiki/Quartic_equation#Summary_of_Ferrari's_method
        public static Tuple<ArbC, ArbC, ArbC, ArbC> quartic_equation(ArbC A, ArbC B, ArbC C, ArbC D, ArbC E)
        {
            ArbC x1, x2, x3, x4;
            ArbC a = -(3 * B * B) / (8 * A * A) + C / A;
            ArbC b = (B * B * B) / (8 * A * A * A) - (B * C) / (2 * A * A) + D / A;
            ArbC c = -(3 * B * B * B * B) / (256 * A * A * A * A) + (C * B * B) / (16 * A * A * A) - (B * D) / (4 * A * A) + E / A;
            ArbC V = -B / (4 * A);

            if (aflintc.iszero(b))
            {
                ArbC W = aflintc.sqrt(a * a - 4 * c);
                ArbC Z1 = aflintc.sqrt((-a + W) / 2);
                ArbC Z2 = aflintc.sqrt((-a - W) / 2);
                x1 = V + Z1;
                x2 = V - Z1;
                x3 = V + Z2;
                x4 = V - Z2;
            }
            else
            {
                ArbC e = 5 * a / 2;
                ArbC f = 2 * a * a - c;
                ArbC g = a * a * a / 2 - a * c / 2 - b * b / 8;
                var res = cubic_equation_monic(e, f, g);
                ArbC y = res.Item1;
                ArbC W = aflintc.sqrt(a + 2 * y);
                ArbC Z1 = aflintc.sqrt(-(3 * a + 2 * y + 2 * b / W));
                ArbC Z2 = aflintc.sqrt(-(3 * a + 2 * y - 2 * b / W));
                x1 = V + (W + Z1) / 2;
                x2 = V + (W - Z1) / 2;
                x3 = V - (W + Z2) / 2;
                x4 = V - (W - Z2) / 2;
            }
            return new Tuple<ArbC, ArbC, ArbC, ArbC>(x1, x2, x3, x4);
        }

        public static Tuple<ArbC, ArbC, ArbC, ArbC> quartic_equation(dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return quartic_equation(aflintc.t(A), aflintc.t(B), aflintc.t(C), aflintc.t(D), aflintc.t(E));
        }


#endregion





    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion


