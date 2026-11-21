using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;


namespace UserMpPrecNet
{


    /// <summary>
    /// Represents a Decimal or mp_mpc
    /// </summary>
    public class Decimal_or_DecC
    {
    }


    /// <summary>
    /// Represents a Decimal
    /// </summary>
    public class Decimal
    {
    }






    public class dpmlib
    {


        public static String fmt(dynamic z)
        {
            return "fmt(t(z))";
        }



        #region Basic floating point functions


        #region General

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/name/*' />
        public static String name
        {
            get { return "dpm"; }
        }

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/prec/*' />
        public static Int32 prec
        {
            get { return 64; }
        }

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/isrealctx/*' />
        public static bool isrealctx
        {
            get { return false; }
        }

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/iscplxctx/*' />
        public static bool iscplxctx
        {
            get { return true; }
        }

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/isintervalorballctx/*' />
        public static bool isintervalorballctx
        {
            get { return false; }
        }

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/isdecimalctx/*' />
        public static bool isdecimalctx
        {
            get { return false; }
        }

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/isfractionctx/*' />
        public static bool isfractionctx
        {
            get { return false; }
        }

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/hasnegativezero/*' />
        public static bool hasnegativezero
        {
            get { return true; }
        }

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/supportsboost/*' />
        public static bool supportsboost
        {
            get { return false; }
        }





        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/realctx/*' />
        public static dpmlib realctx
        {
            get { return new dpmlib(); }
        }

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static dpmlib cplxctx
        {
            get { return new dpmlib(); }
        }


        #endregion




        #endregion






        #region Elementary scalar functions





        #region dynamic components



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Decimal real(dynamic z)
        {
            return new Decimal();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Decimal imag(dynamic z)
        {
            return new Decimal();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Decimal abs(dynamic z)
        {
            return new Decimal();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Decimal phase(dynamic z)
        {
            return new Decimal();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static Decimal_or_DecC conj(dynamic z)
        {
            return new Decimal_or_DecC();
        }







        #endregion






        #region Roots, quartic etc.



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static Decimal_or_DecC sqrt(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt1pm1/*' />
        public static Decimal_or_DecC sqrt1pm1(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Decimal_or_DecC rsqrt(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static Decimal_or_DecC cbrt(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static Decimal_or_DecC unitroot(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static Decimal_or_DecC root_si(dynamic x, Int32 k)
        {
            return new Decimal_or_DecC();
        }




        #endregion




        #region Exponential and related functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static Decimal_or_DecC exp(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Decimal_or_DecC exp2(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static Decimal_or_DecC exp10(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Decimal_or_DecC expm1(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Decimal_or_DecC exp2m1(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static Decimal_or_DecC exp10m1(dynamic x)
        {
            return new Decimal_or_DecC();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static Decimal_or_DecC expj(dynamic x)
        {
            return new Decimal_or_DecC();
        }







        #endregion



        #region Logarithms and related functions




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static Decimal_or_DecC log(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Decimal_or_DecC log2(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Decimal_or_DecC log10(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Decimal_or_DecC log1p(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static Decimal_or_DecC log2p1(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static Decimal_or_DecC log10p1(dynamic x)
        {
            return new Decimal_or_DecC();
        }






        #endregion



        #region Power functions



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static Decimal_or_DecC sqr(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static Decimal_or_DecC cube(dynamic x)
        {
            return new Decimal_or_DecC();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static Decimal_or_DecC pow(dynamic x, dynamic y)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static Decimal_or_DecC powm1(dynamic x, dynamic y)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static Decimal_or_DecC pow1p(dynamic x, dynamic y)
        {
            return new Decimal_or_DecC();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static Decimal_or_DecC pow1pm1(dynamic x, dynamic y)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static Decimal_or_DecC pow_si(dynamic x, Int32 k)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static Decimal_or_DecC compound_si(dynamic x, Int32 k)
        {
            return new Decimal_or_DecC();
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Decimal_or_DecC sin(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static Decimal_or_DecC cos(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static Decimal_or_DecC tan(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static Decimal_or_DecC csc(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static Decimal_or_DecC sec(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static Decimal_or_DecC cot(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        #endregion



        #region Hyperbolic functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static Decimal_or_DecC sinh(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static Decimal_or_DecC cosh(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static Decimal_or_DecC tanh(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static Decimal_or_DecC csch(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static Decimal_or_DecC sech(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static Decimal_or_DecC coth(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static Decimal_or_DecC asin(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static Decimal_or_DecC acos(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static Decimal_or_DecC atan(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static Decimal_or_DecC acsc(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static Decimal_or_DecC asec(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static Decimal_or_DecC acot(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        #endregion



        #region Inverse hyperbolic functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static Decimal_or_DecC asinh(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static Decimal_or_DecC acosh(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static Decimal_or_DecC atanh(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static Decimal_or_DecC acsch(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static Decimal_or_DecC acoth(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        #endregion


        #endregion








    }





}