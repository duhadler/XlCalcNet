using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;


namespace FixedPrecNet
{


    /// <summary>
    /// Represents a flint_arb or mp_mpc
    /// </summary>
    public class flint_arb_or_acb
    {
    }


    /// <summary>
    /// Represents a flint_arb
    /// </summary>
    public class flint_arb
    {
    }






    public class apm
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
            get { return "apm"; }
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
        public static apm realctx
        {
            get { return new apm(); }
        }

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static apm cplxctx
        {
            get { return new apm(); }
        }


        #endregion




        #endregion






        #region Elementary scalar functions





        #region dynamic components



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static flint_arb real(dynamic z)
        {
            return new flint_arb();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static flint_arb imag(dynamic z)
        {
            return new flint_arb();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static flint_arb abs(dynamic z)
        {
            return new flint_arb();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static flint_arb phase(dynamic z)
        {
            return new flint_arb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static flint_arb_or_acb conj(dynamic z)
        {
            return new flint_arb_or_acb();
        }







        #endregion






        #region Roots, quartic etc.



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static flint_arb_or_acb sqrt(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt1pm1/*' />
        public static flint_arb_or_acb sqrt1pm1(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static flint_arb_or_acb rsqrt(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static flint_arb_or_acb cbrt(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static flint_arb_or_acb unitroot(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static flint_arb_or_acb root_si(dynamic x, Int32 k)
        {
            return new flint_arb_or_acb();
        }




        #endregion




        #region Exponential and related functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static flint_arb_or_acb exp(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static flint_arb_or_acb exp2(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static flint_arb_or_acb exp10(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static flint_arb_or_acb expm1(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static flint_arb_or_acb exp2m1(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static flint_arb_or_acb exp10m1(dynamic x)
        {
            return new flint_arb_or_acb();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static flint_arb_or_acb expj(dynamic x)
        {
            return new flint_arb_or_acb();
        }







        #endregion



        #region Logarithms and related functions




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static flint_arb_or_acb log(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static flint_arb_or_acb log2(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static flint_arb_or_acb log10(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static flint_arb_or_acb log1p(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static flint_arb_or_acb log2p1(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static flint_arb_or_acb log10p1(dynamic x)
        {
            return new flint_arb_or_acb();
        }






        #endregion



        #region Power functions



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static flint_arb_or_acb sqr(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static flint_arb_or_acb cube(dynamic x)
        {
            return new flint_arb_or_acb();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static flint_arb_or_acb pow(dynamic x, dynamic y)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static flint_arb_or_acb powm1(dynamic x, dynamic y)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static flint_arb_or_acb pow1p(dynamic x, dynamic y)
        {
            return new flint_arb_or_acb();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static flint_arb_or_acb pow1pm1(dynamic x, dynamic y)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static flint_arb_or_acb pow_si(dynamic x, Int32 k)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static flint_arb_or_acb compound_si(dynamic x, Int32 k)
        {
            return new flint_arb_or_acb();
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static flint_arb_or_acb sin(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static flint_arb_or_acb cos(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static flint_arb_or_acb tan(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static flint_arb_or_acb csc(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static flint_arb_or_acb sec(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static flint_arb_or_acb cot(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        #endregion



        #region Hyperbolic functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static flint_arb_or_acb sinh(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static flint_arb_or_acb cosh(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static flint_arb_or_acb tanh(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static flint_arb_or_acb csch(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static flint_arb_or_acb sech(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static flint_arb_or_acb coth(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static flint_arb_or_acb asin(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static flint_arb_or_acb acos(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static flint_arb_or_acb atan(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static flint_arb_or_acb acsc(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static flint_arb_or_acb asec(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static flint_arb_or_acb acot(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        #endregion



        #region Inverse hyperbolic functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static flint_arb_or_acb asinh(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static flint_arb_or_acb acosh(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static flint_arb_or_acb atanh(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static flint_arb_or_acb acsch(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static flint_arb_or_acb acoth(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        #endregion


        #endregion








    }





}