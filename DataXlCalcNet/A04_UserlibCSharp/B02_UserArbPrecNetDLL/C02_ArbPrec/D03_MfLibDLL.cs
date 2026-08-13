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
    /// User defined functions based on the Mpfr data type
    /// </summary>
    public partial class mflib
    {


#region General

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/name/*' />
        public static String name
        {
            get { return "mflib"; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  mflib"; }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static Int32 prec
        {
            get { return mreal.prec; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static mflib realctx
        {
            get { return new mflib(); }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(Mpfr x)
        {
            return mreal.fmt(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(dynamic x)
        {
            return mreal.fmt(x);
        }




        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Mpfr real(Mpfr x)
        {
            return mflint.real(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Mpfr real(dynamic x)
        {
            return real(mreal.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Mpfr imag(Mpfr x)
        {
            return mflint.imag(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Mpfr imag(dynamic x)
        {
            return imag(mreal.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Mpfr abs(Mpfr x)
        {
            return mflint.abs(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Mpfr abs(dynamic x)
        {
            return abs(mreal.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Mpfr sin(Mpfr x)
        {
            return mflint.sin(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Mpfr sin(dynamic x)
        {
            return sin(mreal.t(x));
        }






        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static Mpfr test_add(Mpfr x, Mpfr y)
        {
            return x + y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static Mpfr test_add(dynamic x, dynamic y)
        {
            return test_add(mreal.t(x), mreal.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static Mpfr test_sub(Mpfr x, Mpfr y)
        {
            return x - y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static Mpfr test_sub(dynamic x, dynamic y)
        {
            return test_sub(mreal.t(x), mreal.t(y));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static Mpfr test_mul(Mpfr x, Mpfr y)
        {
            return x * y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static Mpfr test_mul(dynamic x, dynamic y)
        {
            return test_mul(mreal.t(x), mreal.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static Mpfr test_div(Mpfr x, Mpfr y)
        {
            return x / y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static Mpfr test_div(dynamic x, dynamic y)
        {
            return test_div(mreal.t(x), mreal.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_submul/*' />
        public static Mpfr test_submul(Mpfr x, Mpfr y)
        {
            return x - y + test_mul(x, y);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static Mpfr test_submul(dynamic x, dynamic y)
        {
            return test_submul(mreal.t(x), mreal.t(y));
        }


#endregion


    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion


