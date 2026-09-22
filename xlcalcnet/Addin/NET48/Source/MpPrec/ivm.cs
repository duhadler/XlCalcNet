using System;


namespace FixedPrecNet
{


    /// <summary>
    /// Represents a iv_mpi or mp_mpc
    /// </summary>
    public class iv_mpi_or_mpc
    {
    }


    /// <summary>
    /// Represents a iv_mpi
    /// </summary>
    public class iv_mpi
    {
    }






    public class ivm
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
            get { return "ivm"; }
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
        public static ivm realctx
        {
            get { return new ivm(); }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static ivm cplxctx
        {
            get { return new ivm(); }
        }


        #endregion




        #endregion






        #region Elementary scalar functions





        #region dynamic components



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/real/*' />
        public static iv_mpi real(dynamic z)
        {
            return new iv_mpi();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/imag/*' />
        public static iv_mpi imag(dynamic z)
        {
            return new iv_mpi();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/abs/*' />
        public static iv_mpi abs(dynamic z)
        {
            return new iv_mpi();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/phase/*' />
        public static iv_mpi phase(dynamic z)
        {
            return new iv_mpi();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/conj/*' />
        public static iv_mpi_or_mpc conj(dynamic z)
        {
            return new iv_mpi_or_mpc();
        }







        #endregion






        #region Roots, quartic etc.



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqrt/*' />
        public static iv_mpi_or_mpc sqrt(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqrt1pm1/*' />
        public static iv_mpi_or_mpc sqrt1pm1(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rsqrt/*' />
        public static iv_mpi_or_mpc rsqrt(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cbrt/*' />
        public static iv_mpi_or_mpc cbrt(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/unitroot/*' />
        public static iv_mpi_or_mpc unitroot(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/root_si/*' />
        public static iv_mpi_or_mpc root_si(dynamic x, Int32 k)
        {
            return new iv_mpi_or_mpc();
        }




        #endregion




        #region Exponential and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp/*' />
        public static iv_mpi_or_mpc exp(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp2/*' />
        public static iv_mpi_or_mpc exp2(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp10/*' />
        public static iv_mpi_or_mpc exp10(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expm1/*' />
        public static iv_mpi_or_mpc expm1(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp2m1/*' />
        public static iv_mpi_or_mpc exp2m1(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp10m1/*' />
        public static iv_mpi_or_mpc exp10m1(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expj/*' />
        public static iv_mpi_or_mpc expj(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }







        #endregion



        #region Logarithms and related functions




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log/*' />
        public static iv_mpi_or_mpc log(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log2/*' />
        public static iv_mpi_or_mpc log2(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log10/*' />
        public static iv_mpi_or_mpc log10(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log1p/*' />
        public static iv_mpi_or_mpc log1p(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log2p1/*' />
        public static iv_mpi_or_mpc log2p1(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log10p1/*' />
        public static iv_mpi_or_mpc log10p1(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }






        #endregion



        #region Power functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqr/*' />
        public static iv_mpi_or_mpc sqr(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cube/*' />
        public static iv_mpi_or_mpc cube(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow/*' />
        public static iv_mpi_or_mpc pow(dynamic x, dynamic y)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/powm1/*' />
        public static iv_mpi_or_mpc powm1(dynamic x, dynamic y)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow1p/*' />
        public static iv_mpi_or_mpc pow1p(dynamic x, dynamic y)
        {
            return new iv_mpi_or_mpc();
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow1pm1/*' />
        public static iv_mpi_or_mpc pow1pm1(dynamic x, dynamic y)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow_si/*' />
        public static iv_mpi_or_mpc pow_si(dynamic x, Int32 k)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/compound_si/*' />
        public static iv_mpi_or_mpc compound_si(dynamic x, Int32 k)
        {
            return new iv_mpi_or_mpc();
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sin/*' />
        public static iv_mpi_or_mpc sin(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cos/*' />
        public static iv_mpi_or_mpc cos(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tan/*' />
        public static iv_mpi_or_mpc tan(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/csc/*' />
        public static iv_mpi_or_mpc csc(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sec/*' />
        public static iv_mpi_or_mpc sec(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cot/*' />
        public static iv_mpi_or_mpc cot(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        #endregion



        #region Hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinh/*' />
        public static iv_mpi_or_mpc sinh(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cosh/*' />
        public static iv_mpi_or_mpc cosh(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tanh/*' />
        public static iv_mpi_or_mpc tanh(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/csch/*' />
        public static iv_mpi_or_mpc csch(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sech/*' />
        public static iv_mpi_or_mpc sech(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coth/*' />
        public static iv_mpi_or_mpc coth(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asin/*' />
        public static iv_mpi_or_mpc asin(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acos/*' />
        public static iv_mpi_or_mpc acos(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/atan/*' />
        public static iv_mpi_or_mpc atan(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acsc/*' />
        public static iv_mpi_or_mpc acsc(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asec/*' />
        public static iv_mpi_or_mpc asec(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acot/*' />
        public static iv_mpi_or_mpc acot(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        #endregion



        #region Inverse hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asinh/*' />
        public static iv_mpi_or_mpc asinh(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acosh/*' />
        public static iv_mpi_or_mpc acosh(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/atanh/*' />
        public static iv_mpi_or_mpc atanh(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acsch/*' />
        public static iv_mpi_or_mpc acsch(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acoth/*' />
        public static iv_mpi_or_mpc acoth(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        #endregion


        #endregion








    }





}