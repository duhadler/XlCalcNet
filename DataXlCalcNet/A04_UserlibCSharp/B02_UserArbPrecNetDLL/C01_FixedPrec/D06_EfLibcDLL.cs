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
    /// User defined functions based on the ExtendedC data type
    /// </summary>
    public partial class eflibc
    {

#region General

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/name/*' />
        public static String name
        {
            get { return "eflibc"; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmtname/*' />
        public static String fmtname
        {
            get { return " eflibc"; }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static Int32 prec
        {
            get { return ereal.prec; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static eflib realctx
        {
            get { return new eflib(); }
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
            return eflintc.real(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Extended real(dynamic x)
        {
            return real(ecplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Extended imag(ExtendedC x)
        {
            return eflintc.imag(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Extended imag(dynamic x)
        {
            return imag(ecplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Extended abs(ExtendedC x)
        {
            return eflintc.abs(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Extended abs(dynamic x)
        {
            return abs(ecplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static ExtendedC sin(ExtendedC x)
        {
            return eflintc.sin(x);
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


    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion


