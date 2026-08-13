using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;


namespace UserMpPrecNet
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






    public class ipmlib
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
            get { return "ipm"; }
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
        public static ipmlib realctx
        {
            get { return new ipmlib(); }
        }

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static ipmlib cplxctx
        {
            get { return new ipmlib(); }
        }


        #endregion




        #endregion






        #region Elementary scalar functions





        #region dynamic components



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static iv_mpi real(dynamic z)
        {
            return new iv_mpi();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static iv_mpi imag(dynamic z)
        {
            return new iv_mpi();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static iv_mpi abs(dynamic z)
        {
            return new iv_mpi();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static iv_mpi phase(dynamic z)
        {
            return new iv_mpi();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static iv_mpi_or_mpc conj(dynamic z)
        {
            return new iv_mpi_or_mpc();
        }







        #endregion






        #region Roots, quartic etc.



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static iv_mpi_or_mpc sqrt(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt1pm1/*' />
        public static iv_mpi_or_mpc sqrt1pm1(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static iv_mpi_or_mpc rsqrt(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static iv_mpi_or_mpc cbrt(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static iv_mpi_or_mpc unitroot(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static iv_mpi_or_mpc root_si(dynamic x, Int32 k)
        {
            return new iv_mpi_or_mpc();
        }




        #endregion




        #region Exponential and related functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static iv_mpi_or_mpc exp(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static iv_mpi_or_mpc exp2(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static iv_mpi_or_mpc exp10(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static iv_mpi_or_mpc expm1(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static iv_mpi_or_mpc exp2m1(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static iv_mpi_or_mpc exp10m1(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static iv_mpi_or_mpc expj(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }







        #endregion



        #region Logarithms and related functions




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static iv_mpi_or_mpc log(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static iv_mpi_or_mpc log2(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static iv_mpi_or_mpc log10(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static iv_mpi_or_mpc log1p(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static iv_mpi_or_mpc log2p1(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static iv_mpi_or_mpc log10p1(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }






        #endregion



        #region Power functions



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static iv_mpi_or_mpc sqr(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static iv_mpi_or_mpc cube(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static iv_mpi_or_mpc pow(dynamic x, dynamic y)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static iv_mpi_or_mpc powm1(dynamic x, dynamic y)
        {
            return new iv_mpi_or_mpc();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static iv_mpi_or_mpc pow1p(dynamic x, dynamic y)
        {
            return new iv_mpi_or_mpc();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static iv_mpi_or_mpc pow1pm1(dynamic x, dynamic y)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static iv_mpi_or_mpc pow_si(dynamic x, Int32 k)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static iv_mpi_or_mpc compound_si(dynamic x, Int32 k)
        {
            return new iv_mpi_or_mpc();
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static iv_mpi_or_mpc sin(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static iv_mpi_or_mpc cos(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static iv_mpi_or_mpc tan(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static iv_mpi_or_mpc csc(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static iv_mpi_or_mpc sec(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static iv_mpi_or_mpc cot(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        #endregion



        #region Hyperbolic functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static iv_mpi_or_mpc sinh(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static iv_mpi_or_mpc cosh(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static iv_mpi_or_mpc tanh(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static iv_mpi_or_mpc csch(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static iv_mpi_or_mpc sech(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static iv_mpi_or_mpc coth(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static iv_mpi_or_mpc asin(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static iv_mpi_or_mpc acos(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static iv_mpi_or_mpc atan(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static iv_mpi_or_mpc acsc(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static iv_mpi_or_mpc asec(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static iv_mpi_or_mpc acot(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        #endregion



        #region Inverse hyperbolic functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static iv_mpi_or_mpc asinh(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static iv_mpi_or_mpc acosh(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static iv_mpi_or_mpc atanh(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static iv_mpi_or_mpc acsch(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static iv_mpi_or_mpc acoth(dynamic x)
        {
            return new iv_mpi_or_mpc();
        }




        #endregion


        #endregion








    }





}