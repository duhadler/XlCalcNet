using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;


namespace FixedPrecNet
{


    /// <summary>
    /// Represents a float or mp_mpc
    /// </summary>
    public class float_or_complex
    {
    }


    ///// <summary>
    ///// Represents a float
    ///// </summary>
    //public class float
    //{
    //}






    public class fpm
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
            get { return "fpm"; }
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
        public static fpm realctx
        {
            get { return new fpm(); }
        }

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static fpm cplxctx
        {
            get { return new fpm(); }
        }


        #endregion




        #endregion






        #region Elementary scalar functions





        #region Complex components



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static float real(dynamic z)
        {
            return new float();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static float imag(dynamic z)
        {
            return new float();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static float abs(dynamic z)
        {
            return new float();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static float phase(dynamic z)
        {
            return new float();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static float_or_complex conj(dynamic z)
        {
            return new float_or_complex();
        }







        #endregion






        #region Roots, quartic etc.



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static float_or_complex sqrt(dynamic x)
        {
            return new float_or_complex();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt1pm1/*' />
        public static float_or_complex sqrt1pm1(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static float_or_complex rsqrt(dynamic x)
        {
            return new float_or_complex();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static float_or_complex cbrt(dynamic x)
        {
            return new float_or_complex();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static float_or_complex unitroot(dynamic x)
        {
            return new float_or_complex();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static float_or_complex root_si(dynamic x, Int32 k)
        {
            return new float_or_complex();
        }




        #endregion




        #region Exponential and related functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static float_or_complex exp(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static float_or_complex exp2(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static float_or_complex exp10(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static float_or_complex expm1(dynamic x)
        {
            return new float_or_complex();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static float_or_complex exp2m1(dynamic x)
        {
            return new float_or_complex();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static float_or_complex exp10m1(dynamic x)
        {
            return new float_or_complex();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static float_or_complex expj(dynamic x)
        {
            return new float_or_complex();
        }







        #endregion



        #region Logarithms and related functions




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static float_or_complex log(dynamic x)
        {
            return new float_or_complex();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static float_or_complex log2(dynamic x)
        {
            return new float_or_complex();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static float_or_complex log10(dynamic x)
        {
            return new float_or_complex();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static float_or_complex log1p(dynamic x)
        {
            return new float_or_complex();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static float_or_complex log2p1(dynamic x)
        {
            return new float_or_complex();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static float_or_complex log10p1(dynamic x)
        {
            return new float_or_complex();
        }






        #endregion



        #region Power functions



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static float_or_complex sqr(dynamic x)
        {
            return new float_or_complex();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static float_or_complex cube(dynamic x)
        {
            return new float_or_complex();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static float_or_complex pow(dynamic x, dynamic y)
        {
            return new float_or_complex();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static float_or_complex powm1(dynamic x, dynamic y)
        {
            return new float_or_complex();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static float_or_complex pow1p(dynamic x, dynamic y)
        {
            return new float_or_complex();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static float_or_complex pow1pm1(dynamic x, dynamic y)
        {
            return new float_or_complex();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static float_or_complex pow_si(dynamic x, Int32 k)
        {
            return new float_or_complex();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static float_or_complex compound_si(dynamic x, Int32 k)
        {
            return new float_or_complex();
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static float_or_complex sin(dynamic x)
        {
            return new float_or_complex();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static float_or_complex cos(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static float_or_complex tan(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static float_or_complex csc(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static float_or_complex sec(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static float_or_complex cot(dynamic x)
        {
            return new float_or_complex();
        }




        #endregion



        #region Hyperbolic functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static float_or_complex sinh(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static float_or_complex cosh(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static float_or_complex tanh(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static float_or_complex csch(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static float_or_complex sech(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static float_or_complex coth(dynamic x)
        {
            return new float_or_complex();
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static float_or_complex asin(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static float_or_complex acos(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static float_or_complex atan(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static float_or_complex acsc(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static float_or_complex asec(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static float_or_complex acot(dynamic x)
        {
            return new float_or_complex();
        }


        #endregion



        #region Inverse hyperbolic functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static float_or_complex asinh(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static float_or_complex acosh(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static float_or_complex atanh(dynamic x)
        {
            return new float_or_complex();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static float_or_complex acsch(dynamic x)
        {
            return new float_or_complex();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static float_or_complex acoth(dynamic x)
        {
            return new float_or_complex();
        }




        #endregion


        #endregion








    }





}