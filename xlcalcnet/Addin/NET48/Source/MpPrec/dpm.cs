using System;


namespace FixedPrecNet
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






    public class dpm
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
            get { return "dpm"; }
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
        public static dpm realctx
        {
            get { return new dpm(); }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static dpm cplxctx
        {
            get { return new dpm(); }
        }


        #endregion




        #endregion






        #region Elementary scalar functions





        #region complex components



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/real/*' />
        public static Decimal real(dynamic z)
        {
            return new Decimal();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/imag/*' />
        public static Decimal imag(dynamic z)
        {
            return new Decimal();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/abs/*' />
        public static Decimal abs(dynamic z)
        {
            return new Decimal();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/phase/*' />
        public static Decimal phase(dynamic z)
        {
            return new Decimal();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/conj/*' />
        public static Decimal_or_DecC conj(dynamic z)
        {
            return new Decimal_or_DecC();
        }







        #endregion






        #region Roots, quartic etc.



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqrt/*' />
        public static Decimal_or_DecC sqrt(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqrt1pm1/*' />
        public static Decimal_or_DecC sqrt1pm1(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rsqrt/*' />
        public static Decimal_or_DecC rsqrt(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cbrt/*' />
        public static Decimal_or_DecC cbrt(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/unitroot/*' />
        public static Decimal_or_DecC unitroot(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/root_si/*' />
        public static Decimal_or_DecC root_si(dynamic x, Int32 k)
        {
            return new Decimal_or_DecC();
        }




        #endregion




        #region Exponential and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp/*' />
        public static Decimal_or_DecC exp(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp2/*' />
        public static Decimal_or_DecC exp2(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp10/*' />
        public static Decimal_or_DecC exp10(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expm1/*' />
        public static Decimal_or_DecC expm1(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp2m1/*' />
        public static Decimal_or_DecC exp2m1(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp10m1/*' />
        public static Decimal_or_DecC exp10m1(dynamic x)
        {
            return new Decimal_or_DecC();
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expj/*' />
        public static Decimal_or_DecC expj(dynamic x)
        {
            return new Decimal_or_DecC();
        }







        #endregion



        #region Logarithms and related functions




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log/*' />
        public static Decimal_or_DecC log(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log2/*' />
        public static Decimal_or_DecC log2(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log10/*' />
        public static Decimal_or_DecC log10(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log1p/*' />
        public static Decimal_or_DecC log1p(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log2p1/*' />
        public static Decimal_or_DecC log2p1(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log10p1/*' />
        public static Decimal_or_DecC log10p1(dynamic x)
        {
            return new Decimal_or_DecC();
        }






        #endregion



        #region Power functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqr/*' />
        public static Decimal_or_DecC sqr(dynamic x)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cube/*' />
        public static Decimal_or_DecC cube(dynamic x)
        {
            return new Decimal_or_DecC();
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow/*' />
        public static Decimal_or_DecC pow(dynamic x, dynamic y)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/powm1/*' />
        public static Decimal_or_DecC powm1(dynamic x, dynamic y)
        {
            return new Decimal_or_DecC();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow1p/*' />
        public static Decimal_or_DecC pow1p(dynamic x, dynamic y)
        {
            return new Decimal_or_DecC();
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow1pm1/*' />
        public static Decimal_or_DecC pow1pm1(dynamic x, dynamic y)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow_si/*' />
        public static Decimal_or_DecC pow_si(dynamic x, Int32 k)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/compound_si/*' />
        public static Decimal_or_DecC compound_si(dynamic x, Int32 k)
        {
            return new Decimal_or_DecC();
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sin/*' />
        public static Decimal_or_DecC sin(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cos/*' />
        public static Decimal_or_DecC cos(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tan/*' />
        public static Decimal_or_DecC tan(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/csc/*' />
        public static Decimal_or_DecC csc(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sec/*' />
        public static Decimal_or_DecC sec(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cot/*' />
        public static Decimal_or_DecC cot(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        #endregion



        #region Hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinh/*' />
        public static Decimal_or_DecC sinh(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cosh/*' />
        public static Decimal_or_DecC cosh(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tanh/*' />
        public static Decimal_or_DecC tanh(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/csch/*' />
        public static Decimal_or_DecC csch(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sech/*' />
        public static Decimal_or_DecC sech(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coth/*' />
        public static Decimal_or_DecC coth(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asin/*' />
        public static Decimal_or_DecC asin(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acos/*' />
        public static Decimal_or_DecC acos(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/atan/*' />
        public static Decimal_or_DecC atan(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acsc/*' />
        public static Decimal_or_DecC acsc(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asec/*' />
        public static Decimal_or_DecC asec(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acot/*' />
        public static Decimal_or_DecC acot(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        #endregion



        #region Inverse hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asinh/*' />
        public static Decimal_or_DecC asinh(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acosh/*' />
        public static Decimal_or_DecC acosh(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/atanh/*' />
        public static Decimal_or_DecC atanh(dynamic x)
        {
            return new Decimal_or_DecC();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acsch/*' />
        public static Decimal_or_DecC acsch(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acoth/*' />
        public static Decimal_or_DecC acoth(dynamic x)
        {
            return new Decimal_or_DecC();
        }




        #endregion


        #endregion








    }





}