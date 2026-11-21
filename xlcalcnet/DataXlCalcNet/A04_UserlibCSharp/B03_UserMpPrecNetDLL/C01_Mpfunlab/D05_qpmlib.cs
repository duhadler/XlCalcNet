using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;


namespace UserMpPrecNet
{


    /// <summary>
    /// Represents a Fraction or mp_mpc
    /// </summary>
    public class Fraction_or_QCplx
    {
    }


    /// <summary>
    /// Represents a Fraction
    /// </summary>
    public class Fraction
    {
    }






    public class qpmlib
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
            get { return "qpm"; }
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
        public static qpmlib realctx
        {
            get { return new qpmlib(); }
        }

        /// <include file="xcn.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static qpmlib cplxctx
        {
            get { return new qpmlib(); }
        }


        #endregion




        #endregion






        #region Elementary scalar functions





        #region dynamic components



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Fraction real(dynamic z)
        {
            return new Fraction();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Fraction imag(dynamic z)
        {
            return new Fraction();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Fraction abs(dynamic z)
        {
            return new Fraction();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Fraction phase(dynamic z)
        {
            return new Fraction();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static Fraction_or_QCplx conj(dynamic z)
        {
            return new Fraction_or_QCplx();
        }







        #endregion






        #region Roots, quartic etc.



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static Fraction_or_QCplx sqrt(dynamic x)
        {
            return new Fraction_or_QCplx();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt1pm1/*' />
        public static Fraction_or_QCplx sqrt1pm1(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Fraction_or_QCplx rsqrt(dynamic x)
        {
            return new Fraction_or_QCplx();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static Fraction_or_QCplx cbrt(dynamic x)
        {
            return new Fraction_or_QCplx();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static Fraction_or_QCplx unitroot(dynamic x)
        {
            return new Fraction_or_QCplx();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static Fraction_or_QCplx root_si(dynamic x, Int32 k)
        {
            return new Fraction_or_QCplx();
        }




        #endregion




        #region Exponential and related functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static Fraction_or_QCplx exp(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Fraction_or_QCplx exp2(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static Fraction_or_QCplx exp10(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Fraction_or_QCplx expm1(dynamic x)
        {
            return new Fraction_or_QCplx();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Fraction_or_QCplx exp2m1(dynamic x)
        {
            return new Fraction_or_QCplx();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static Fraction_or_QCplx exp10m1(dynamic x)
        {
            return new Fraction_or_QCplx();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static Fraction_or_QCplx expj(dynamic x)
        {
            return new Fraction_or_QCplx();
        }







        #endregion



        #region Logarithms and related functions




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static Fraction_or_QCplx log(dynamic x)
        {
            return new Fraction_or_QCplx();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Fraction_or_QCplx log2(dynamic x)
        {
            return new Fraction_or_QCplx();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Fraction_or_QCplx log10(dynamic x)
        {
            return new Fraction_or_QCplx();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Fraction_or_QCplx log1p(dynamic x)
        {
            return new Fraction_or_QCplx();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static Fraction_or_QCplx log2p1(dynamic x)
        {
            return new Fraction_or_QCplx();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static Fraction_or_QCplx log10p1(dynamic x)
        {
            return new Fraction_or_QCplx();
        }






        #endregion



        #region Power functions



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static Fraction_or_QCplx sqr(dynamic x)
        {
            return new Fraction_or_QCplx();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static Fraction_or_QCplx cube(dynamic x)
        {
            return new Fraction_or_QCplx();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static Fraction_or_QCplx pow(dynamic x, dynamic y)
        {
            return new Fraction_or_QCplx();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static Fraction_or_QCplx powm1(dynamic x, dynamic y)
        {
            return new Fraction_or_QCplx();
        }



        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static Fraction_or_QCplx pow1p(dynamic x, dynamic y)
        {
            return new Fraction_or_QCplx();
        }





        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static Fraction_or_QCplx pow1pm1(dynamic x, dynamic y)
        {
            return new Fraction_or_QCplx();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static Fraction_or_QCplx pow_si(dynamic x, Int32 k)
        {
            return new Fraction_or_QCplx();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static Fraction_or_QCplx compound_si(dynamic x, Int32 k)
        {
            return new Fraction_or_QCplx();
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Fraction_or_QCplx sin(dynamic x)
        {
            return new Fraction_or_QCplx();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static Fraction_or_QCplx cos(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static Fraction_or_QCplx tan(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static Fraction_or_QCplx csc(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static Fraction_or_QCplx sec(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static Fraction_or_QCplx cot(dynamic x)
        {
            return new Fraction_or_QCplx();
        }




        #endregion



        #region Hyperbolic functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static Fraction_or_QCplx sinh(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static Fraction_or_QCplx cosh(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static Fraction_or_QCplx tanh(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static Fraction_or_QCplx csch(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static Fraction_or_QCplx sech(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static Fraction_or_QCplx coth(dynamic x)
        {
            return new Fraction_or_QCplx();
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static Fraction_or_QCplx asin(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static Fraction_or_QCplx acos(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static Fraction_or_QCplx atan(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static Fraction_or_QCplx acsc(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static Fraction_or_QCplx asec(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static Fraction_or_QCplx acot(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        #endregion



        #region Inverse hyperbolic functions


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static Fraction_or_QCplx asinh(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static Fraction_or_QCplx acosh(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static Fraction_or_QCplx atanh(dynamic x)
        {
            return new Fraction_or_QCplx();
        }


        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static Fraction_or_QCplx acsch(dynamic x)
        {
            return new Fraction_or_QCplx();
        }




        /// <include file="xcn.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static Fraction_or_QCplx acoth(dynamic x)
        {
            return new Fraction_or_QCplx();
        }




        #endregion


        #endregion








    }





}