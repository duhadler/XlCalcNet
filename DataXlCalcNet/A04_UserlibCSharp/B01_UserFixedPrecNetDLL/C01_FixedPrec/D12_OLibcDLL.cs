/* C# */


#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
#endregion


namespace UserFixedPrecNet
{

    /// <summary>
    /// User defined functions based on the OctupleC data type
    /// </summary>
    public partial class olibc
    {

#region General

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/name/*' />
        public static String name
        {
            get { return "olibc"; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  olibc"; }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static Int32 prec
        {
            get { return oreal.prec; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static olib realctx
        {
            get { return new olib(); }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(OctupleC x)
        {
            return ocplx.fmt(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(dynamic x)
        {
            return ocplx.fmt(x);
        }




        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Octuple real(OctupleC x)
        {
            return ocplx.real(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Octuple real(dynamic x)
        {
            return real(ocplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Octuple imag(OctupleC x)
        {
            return ocplx.imag(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Octuple imag(dynamic x)
        {
            return imag(ocplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Octuple abs(OctupleC x)
        {
            return ocplx.abs(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Octuple abs(dynamic x)
        {
            return abs(ocplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static OctupleC sin(OctupleC x)
        {
            return ocplx.sin(x);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static OctupleC sin(dynamic x)
        {
            return sin(ocplx.t(x));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static OctupleC test_add(OctupleC x, OctupleC y)
        {
            return x + y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static OctupleC test_add(dynamic x, dynamic y)
        {
            return test_add(ocplx.t(x), ocplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static OctupleC test_sub(OctupleC x, OctupleC y)
        {
            return x - y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static OctupleC test_sub(dynamic x, dynamic y)
        {
            return test_sub(ocplx.t(x), ocplx.t(y));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static OctupleC test_mul(OctupleC x, OctupleC y)
        {
            return x * y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static OctupleC test_mul(dynamic x, dynamic y)
        {
            return test_mul(ocplx.t(x), ocplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static OctupleC test_div(OctupleC x, OctupleC y)
        {
            return x / y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static OctupleC test_div(dynamic x, dynamic y)
        {
            return test_div(ocplx.t(x), ocplx.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_submul/*' />
        public static OctupleC test_submul(OctupleC x, OctupleC y)
        {
            return x - y + test_mul(x, y);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static OctupleC test_submul(dynamic x, dynamic y)
        {
            return test_submul(ocplx.t(x), ocplx.t(y));
        }


#endregion




#region poly_equations


        public static OctupleC eval_quadratic(OctupleC x, OctupleC A, OctupleC B, OctupleC C)
        {
            return (A * x + B) * x + C;
        }

        public static OctupleC eval_quadratic(dynamic x, dynamic A, dynamic B, dynamic C)
        {
            return eval_quadratic(ocplx.t(x), ocplx.t(A), ocplx.t(B), ocplx.t(C));
        }


        // See also: Press, 3rd edition, page 227
        public static Tuple<OctupleC, OctupleC> quadratic_equation(OctupleC a, OctupleC b, OctupleC c)
        {
            OctupleC x1, x2;
            OctupleC D = ocplx.sqrt(b * b - 4 * a * c);
            OctupleC bStar = ocplx.conj(b);
            if ((bStar * D).real < oreal.t(0))
            {
                D = -D;
            }
            OctupleC q = -0.5 * (b + D);
            x1 = q / a;
            x2 = c / q;
            return new Tuple<OctupleC, OctupleC>(x1, x2);
        }
        public static Tuple<OctupleC, OctupleC> quadratic_equation(dynamic A, dynamic B, dynamic C)
        {
            return quadratic_equation(ocplx.t(A), ocplx.t(B), ocplx.t(C));
        }




        public static OctupleC eval_monic_cubic(OctupleC x, OctupleC a, OctupleC b, OctupleC c)
        {
            return ((x + a) * x + b) * x + c;
        }

        public static OctupleC eval_monic_cubic(dynamic x, dynamic a, dynamic b, dynamic c)
        {
            return eval_monic_cubic(ocplx.t(x), ocplx.t(a), ocplx.t(b), ocplx.t(c));
        }


        // See also: Press, 3rd edition, page 228
        public static Tuple<OctupleC, OctupleC, OctupleC> cubic_equation_monic(OctupleC a, OctupleC b, OctupleC c)
        {
            OctupleC x1, x2, x3;
            OctupleC Q = (a * a - 3 * b) / 9;
            OctupleC R = (2 * a * a * a - 9 * a * b + 27 * c) / 54;
            Octuple Qr = Q.real;
            Octuple Rr = R.real;
            if ((Q.imag == oreal.t(0.0)) && (R.imag == oreal.t(0.0)) && (Rr * Rr < Qr * Qr * Qr))
            {
                Console.WriteLine("In ocplx real Case");
                Octuple SqrtQr = oreal.sqrt(Qr);
                Octuple theta = oreal.acos(Rr / (SqrtQr * SqrtQr * SqrtQr));
                x1 = -2 * SqrtQr * oreal.cos((theta) / 3) - a / 3;
                x2 = -2 * SqrtQr * oreal.cos((theta + 2 * oreal.pi()) / 3) - a / 3;
                x3 = -2 * SqrtQr * oreal.cos((theta - 2 * oreal.pi()) / 3) - a / 3;
            }
            else
            {
                Console.WriteLine("In ocplx OctupleC Case");
                OctupleC D = ocplx.sqrt(R * R - Q * Q * Q);
                OctupleC RStar = ocplx.conj(R);
                if ((RStar * D).real < oreal.t(0))
                {
                    D = -D;
                }
                OctupleC A = -ocplx.cbrt(R + D);
                OctupleC B = ocplx.zero();
                if (A != ocplx.zero())
                {
                    B = Q / A;
                }
                Console.WriteLine("A: {0}", A);
                Console.WriteLine("B: {0}", B);

                x1 = (A + B) - a / 3;
                x2 = -0.5 * (A + B) - a / 3 + 0.5 * ocplx.ImaginaryOne() * oreal.sqrt(3) * (A - B);
                x3 = -0.5 * (A + B) - a / 3 - 0.5 * ocplx.ImaginaryOne() * oreal.sqrt(3) * (A - B);
            }
            return new Tuple<OctupleC, OctupleC, OctupleC>(x1, x2, x3);
        }
        public static Tuple<OctupleC, OctupleC, OctupleC> cubic_equation_monic(dynamic a, dynamic b, dynamic c)
        {
            return cubic_equation_monic(ocplx.t(a), ocplx.t(b), ocplx.t(c));
        }




        public static OctupleC eval_cubic(OctupleC x, OctupleC A, OctupleC B, OctupleC C, OctupleC D)
        {
            return ((A * x + B) * x + C) * x + D;
        }

        public static OctupleC eval_cubic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return eval_cubic(ocplx.t(x), ocplx.t(A), ocplx.t(B), ocplx.t(C), ocplx.t(D));
        }


        public static Tuple<OctupleC, OctupleC, OctupleC> cubic_equation(OctupleC A, OctupleC B, OctupleC C, OctupleC D)
        {
            return cubic_equation_monic(B / A, C / A, D / A);
        }
        public static Tuple<OctupleC, OctupleC, OctupleC> cubic_equation(dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return cubic_equation(ocplx.t(A), ocplx.t(B), ocplx.t(C), ocplx.t(D));
        }



        public static OctupleC eval_quartic(OctupleC x, OctupleC A, OctupleC B, OctupleC C, OctupleC D, OctupleC E)
        {
            return (((A * x + B) * x + C) * x + D) * x + E;
        }

        public static OctupleC eval_quartic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return eval_quartic(ocplx.t(x), ocplx.t(A), ocplx.t(B), ocplx.t(C), ocplx.t(D), ocplx.t(E));
        }


        // See also: https://en.wikipedia.org/wiki/Quartic_equation#Summary_of_Ferrari's_method
        public static Tuple<OctupleC, OctupleC, OctupleC, OctupleC> quartic_equation(OctupleC A, OctupleC B, OctupleC C, OctupleC D, OctupleC E)
        {
            OctupleC x1, x2, x3, x4;
            OctupleC a = -(3 * B * B) / (8 * A * A) + C / A;
            OctupleC b = (B * B * B) / (8 * A * A * A) - (B * C) / (2 * A * A) + D / A;
            OctupleC c = -(3 * B * B * B * B) / (256 * A * A * A * A) + (C * B * B) / (16 * A * A * A) - (B * D) / (4 * A * A) + E / A;
            OctupleC V = -B / (4 * A);

            if (ocplx.iszero(b))
            {
                OctupleC W = ocplx.sqrt(a * a - 4 * c);
                OctupleC Z1 = ocplx.sqrt((-a + W) / 2);
                OctupleC Z2 = ocplx.sqrt((-a - W) / 2);
                x1 = V + Z1;
                x2 = V - Z1;
                x3 = V + Z2;
                x4 = V - Z2;
            }
            else
            {
                OctupleC e = 5 * a / 2;
                OctupleC f = 2 * a * a - c;
                OctupleC g = a * a * a / 2 - a * c / 2 - b * b / 8;
                var res = cubic_equation_monic(e, f, g);
                OctupleC y = res.Item1;
                OctupleC W = ocplx.sqrt(a + 2 * y);
                OctupleC Z1 = ocplx.sqrt(-(3 * a + 2 * y + 2 * b / W));
                OctupleC Z2 = ocplx.sqrt(-(3 * a + 2 * y - 2 * b / W));
                x1 = V + (W + Z1) / 2;
                x2 = V + (W - Z1) / 2;
                x3 = V - (W + Z2) / 2;
                x4 = V - (W - Z2) / 2;
            }
            return new Tuple<OctupleC, OctupleC, OctupleC, OctupleC>(x1, x2, x3, x4);
        }

        public static Tuple<OctupleC, OctupleC, OctupleC, OctupleC> quartic_equation(dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return quartic_equation(ocplx.t(A), ocplx.t(B), ocplx.t(C), ocplx.t(D), ocplx.t(E));
        }

#endregion




    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion


