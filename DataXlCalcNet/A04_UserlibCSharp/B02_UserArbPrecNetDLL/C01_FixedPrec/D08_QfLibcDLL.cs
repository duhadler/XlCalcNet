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
    /// User defined functions based on the QuadrupleC data type
    /// </summary>
    public partial class qflibc
    {

#region General

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/name/*' />
        public static String name
        {
            get { return "qflibc"; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmtname/*' />
        public static String fmtname
        {
            get { return " qflibc"; }
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static Int32 prec
        {
            get { return qreal.prec; }
        }

        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/prec/*' />
        public static qflib realctx
        {
            get { return new qflib(); }
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
            return qflintc.real(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Quadruple real(dynamic x)
        {
            return real(qcplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Quadruple imag(QuadrupleC x)
        {
            return qflintc.imag(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Quadruple imag(dynamic x)
        {
            return imag(qcplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Quadruple abs(QuadrupleC x)
        {
            return qflintc.abs(x);
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Quadruple abs(dynamic x)
        {
            return abs(qcplx.t(x));
        }


        /// <include file="..\XML\docs1.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static QuadrupleC sin(QuadrupleC x)
        {
            return qflintc.sin(x);
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


    }
}



/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion


