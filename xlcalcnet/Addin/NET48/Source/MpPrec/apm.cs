using System;


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

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/name/*' />
        public static String name
        {
            get { return "apm"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/prec/*' />
        public static Int32 prec
        {
            get { return 64; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/isrealctx/*' />
        public static bool isrealctx
        {
            get { return false; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/iscplxctx/*' />
        public static bool iscplxctx
        {
            get { return true; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/isintervalorballctx/*' />
        public static bool isintervalorballctx
        {
            get { return false; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/isdecimalctx/*' />
        public static bool isdecimalctx
        {
            get { return false; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/isfractionctx/*' />
        public static bool isfractionctx
        {
            get { return false; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/hasnegativezero/*' />
        public static bool hasnegativezero
        {
            get { return true; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/supportsboost/*' />
        public static bool supportsboost
        {
            get { return false; }
        }





        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/realctx/*' />
        public static apm realctx
        {
            get { return new apm(); }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static apm cplxctx
        {
            get { return new apm(); }
        }


        #endregion




        #endregion






        #region Elementary scalar functions





        #region dynamic components



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/real/*' />
        public static flint_arb real(dynamic z)
        {
            return new flint_arb();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/imag/*' />
        public static flint_arb imag(dynamic z)
        {
            return new flint_arb();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/abs/*' />
        public static flint_arb abs(dynamic z)
        {
            return new flint_arb();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/phase/*' />
        public static flint_arb phase(dynamic z)
        {
            return new flint_arb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/conj/*' />
        public static flint_arb_or_acb conj(dynamic z)
        {
            return new flint_arb_or_acb();
        }







        #endregion






        #region Roots, quartic etc.



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqrt/*' />
        public static flint_arb_or_acb sqrt(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqrt1pm1/*' />
        public static flint_arb_or_acb sqrt1pm1(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rsqrt/*' />
        public static flint_arb_or_acb rsqrt(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cbrt/*' />
        public static flint_arb_or_acb cbrt(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/unitroot/*' />
        public static flint_arb_or_acb unitroot(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/root_si/*' />
        public static flint_arb_or_acb root_si(dynamic x, Int32 k)
        {
            return new flint_arb_or_acb();
        }




        #endregion




        #region Exponential and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp/*' />
        public static flint_arb_or_acb exp(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp2/*' />
        public static flint_arb_or_acb exp2(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp10/*' />
        public static flint_arb_or_acb exp10(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expm1/*' />
        public static flint_arb_or_acb expm1(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp2m1/*' />
        public static flint_arb_or_acb exp2m1(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp10m1/*' />
        public static flint_arb_or_acb exp10m1(dynamic x)
        {
            return new flint_arb_or_acb();
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expj/*' />
        public static flint_arb_or_acb expj(dynamic x)
        {
            return new flint_arb_or_acb();
        }







        #endregion



        #region Logarithms and related functions




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log/*' />
        public static flint_arb_or_acb log(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log2/*' />
        public static flint_arb_or_acb log2(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log10/*' />
        public static flint_arb_or_acb log10(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log1p/*' />
        public static flint_arb_or_acb log1p(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log2p1/*' />
        public static flint_arb_or_acb log2p1(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log10p1/*' />
        public static flint_arb_or_acb log10p1(dynamic x)
        {
            return new flint_arb_or_acb();
        }






        #endregion



        #region Power functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqr/*' />
        public static flint_arb_or_acb sqr(dynamic x)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cube/*' />
        public static flint_arb_or_acb cube(dynamic x)
        {
            return new flint_arb_or_acb();
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow/*' />
        public static flint_arb_or_acb pow(dynamic x, dynamic y)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/powm1/*' />
        public static flint_arb_or_acb powm1(dynamic x, dynamic y)
        {
            return new flint_arb_or_acb();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow1p/*' />
        public static flint_arb_or_acb pow1p(dynamic x, dynamic y)
        {
            return new flint_arb_or_acb();
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow1pm1/*' />
        public static flint_arb_or_acb pow1pm1(dynamic x, dynamic y)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow_si/*' />
        public static flint_arb_or_acb pow_si(dynamic x, Int32 k)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/compound_si/*' />
        public static flint_arb_or_acb compound_si(dynamic x, Int32 k)
        {
            return new flint_arb_or_acb();
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sin/*' />
        public static flint_arb_or_acb sin(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cos/*' />
        public static flint_arb_or_acb cos(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tan/*' />
        public static flint_arb_or_acb tan(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/csc/*' />
        public static flint_arb_or_acb csc(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sec/*' />
        public static flint_arb_or_acb sec(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cot/*' />
        public static flint_arb_or_acb cot(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        #endregion



        #region Hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinh/*' />
        public static flint_arb_or_acb sinh(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cosh/*' />
        public static flint_arb_or_acb cosh(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tanh/*' />
        public static flint_arb_or_acb tanh(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/csch/*' />
        public static flint_arb_or_acb csch(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sech/*' />
        public static flint_arb_or_acb sech(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coth/*' />
        public static flint_arb_or_acb coth(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asin/*' />
        public static flint_arb_or_acb asin(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acos/*' />
        public static flint_arb_or_acb acos(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/atan/*' />
        public static flint_arb_or_acb atan(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acsc/*' />
        public static flint_arb_or_acb acsc(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asec/*' />
        public static flint_arb_or_acb asec(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acot/*' />
        public static flint_arb_or_acb acot(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        #endregion



        #region Inverse hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asinh/*' />
        public static flint_arb_or_acb asinh(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acosh/*' />
        public static flint_arb_or_acb acosh(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/atanh/*' />
        public static flint_arb_or_acb atanh(dynamic x)
        {
            return new flint_arb_or_acb();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acsch/*' />
        public static flint_arb_or_acb acsch(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acoth/*' />
        public static flint_arb_or_acb acoth(dynamic x)
        {
            return new flint_arb_or_acb();
        }




        #endregion


        #endregion








    }





}