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
    /// User defined functions based on the SingleC data type
    /// </summary>
    public partial class sflibc
    {

#region General

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/name/*' />
        public static String name
        {
            get { return "sflibc"; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmtname/*' />
        public static String fmtname
        {
            get { return " sflibc"; }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static Int32 prec
        {
            get { return sreal.prec; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static sflib realctx
        {
            get { return new sflib(); }
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
            return sflintc.real(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Single real(dynamic x)
        {
            return real(scplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Single imag(SingleC x)
        {
            return sflintc.imag(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Single imag(dynamic x)
        {
            return imag(scplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Single abs(SingleC x)
        {
            return sflintc.abs(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Single abs(dynamic x)
        {
            return abs(scplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static SingleC sin(SingleC x)
        {
            return sflintc.sin(x);
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


    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion


