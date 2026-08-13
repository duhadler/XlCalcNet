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
    /// User defined functions based on the Double data type
    /// </summary>
    public partial class dflib
    {

#region General

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/name/*' />
        public static String name
        {
            get { return "dflib"; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  dflib"; }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static Int32 prec
        {
            get { return dreal.prec; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static dflib realctx
        {
            get { return new dflib(); }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(Double x)
        {
            return dreal.fmt(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmt/*' />
        public static String fmt(dynamic x)
        {
            return dreal.fmt(x);
        }




        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Double real(Double x)
        {
            return dflint.real(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Double real(dynamic x)
        {
            return real(dreal.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Double imag(Double x)
        {
            return dflint.imag(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Double imag(dynamic x)
        {
            return imag(dreal.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Double abs(Double x)
        {
            return dflint.abs(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Double abs(dynamic x)
        {
            return abs(dreal.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Double sin(Double x)
        {
            return dflint.sin(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Double sin(dynamic x)
        {
            return sin(dreal.t(x));
        }






        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static Double test_add(Double x, Double y)
        {
            return x + y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_add/*' />
        public static Double test_add(dynamic x, dynamic y)
        {
            return test_add(dreal.t(x), dreal.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static Double test_sub(Double x, Double y)
        {
            return x - y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_sub/*' />
        public static Double test_sub(dynamic x, dynamic y)
        {
            return test_sub(dreal.t(x), dreal.t(y));
        }





        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static Double test_mul(Double x, Double y)
        {
            return x * y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_mul/*' />
        public static Double test_mul(dynamic x, dynamic y)
        {
            return test_mul(dreal.t(x), dreal.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static Double test_div(Double x, Double y)
        {
            return x / y;
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static Double test_div(dynamic x, dynamic y)
        {
            return test_div(dreal.t(x), dreal.t(y));
        }



        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_submul/*' />
        public static Double test_submul(Double x, Double y)
        {
            return x - y + test_mul(x, y);
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/test_div/*' />
        public static Double test_submul(dynamic x, dynamic y)
        {
            return test_submul(dreal.t(x), dreal.t(y));
        }


#endregion


    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion


