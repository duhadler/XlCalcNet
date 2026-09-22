using System;


namespace FixedPrecNet
{


    /// <summary>
    /// Represents a mp_mpf or mp_mpc
    /// </summary>
    public class mp_mpf_or_mpc
    {
    }


    /// <summary>
    /// Represents a mp_mpf
    /// </summary>
    public class mp_mpf
    {
    }






    public class mpm
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
            get { return "mpm"; }
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
        public static mpm realctx
        {
            get { return new mpm(); }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static mpm cplxctx
        {
            get { return new mpm(); }
        }


        #endregion




        #endregion



        #region Numerical calculus mpmath


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sign/*' />
        public static mp_mpf_or_mpc findroot(dynamic f, mp_mpf_or_mpc x0, dynamic solver, mp_mpf_or_mpc tol, bool verbose, bool verify, dynamic kwargs)
        {
            return new mp_mpf_or_mpc();
        }

        #endregion




        #region Elementary scalar functions


        #region dynamic components


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/abs/*' />
        public static mp_mpf abs(dynamic z)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sign/*' />
        public static mp_mpf_or_mpc sign(dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/real/*' />
        public static mp_mpf real(dynamic z)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/imag/*' />
        public static mp_mpf imag(dynamic z)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/phase/*' />
        public static mp_mpf phase(dynamic z)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/conj/*' />
        public static mp_mpf_or_mpc conj(dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/polar/*' />
        public static mp_mpf_or_mpc polar(dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rect/*' />
        public static mp_mpf_or_mpc rect(dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Roots


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqrt/*' />
        public static mp_mpf_or_mpc sqrt(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rsqrt/*' />
        public static mp_mpf_or_mpc rsqrt(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqrt1pm1/*' />
        public static mp_mpf_or_mpc sqrt1pm1(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cbrt/*' />
        public static mp_mpf_or_mpc cbrt(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/root_si/*' />
        public static mp_mpf_or_mpc root_si(dynamic x, Int32 k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/unitroot/*' />
        public static mp_mpf_or_mpc unitroot(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Exponential and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp/*' />
        public static mp_mpf_or_mpc exp(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expj/*' />
        public static mp_mpf_or_mpc expj(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expjpi/*' />
        public static mp_mpf_or_mpc expjpi(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp10/*' />
        public static mp_mpf_or_mpc exp10(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp2/*' />
        public static mp_mpf_or_mpc exp2(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expm1/*' />
        public static mp_mpf_or_mpc expm1(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp10m1/*' />
        public static mp_mpf_or_mpc exp10m1(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp2m1/*' />
        public static mp_mpf_or_mpc exp2m1(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Logarithms and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log/*' />
        public static mp_mpf_or_mpc log(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log10/*' />
        public static mp_mpf_or_mpc log10(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log2/*' />
        public static mp_mpf_or_mpc log2(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logbase/*' />
        public static mp_mpf_or_mpc logbase(dynamic x, dynamic b)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log1p/*' />
        public static mp_mpf_or_mpc log1p(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log10p1/*' />
        public static mp_mpf_or_mpc log10p1(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log2p1/*' />
        public static mp_mpf_or_mpc log2p1(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Power functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqr/*' />
        public static mp_mpf_or_mpc sqr(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cube/*' />
        public static mp_mpf_or_mpc cube(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow_si/*' />
        public static mp_mpf_or_mpc pow_si(dynamic x, Int32 k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/compound_si/*' />
        public static mp_mpf_or_mpc compound_si(dynamic x, Int32 k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/comprel/*' />
        public static mp_mpf_or_mpc comprel(dynamic x, Int32 k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hypot/*' />
        public static mp_mpf_or_mpc hypot(dynamic x, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow/*' />
        public static mp_mpf_or_mpc pow(dynamic x, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/powm1/*' />
        public static mp_mpf_or_mpc powm1(dynamic x, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow1p/*' />
        public static mp_mpf_or_mpc pow1p(dynamic x, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow1pm1/*' />
        public static mp_mpf_or_mpc pow1pm1(dynamic x, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Trigonometric and related functions, in radians


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sin/*' />
        public static mp_mpf_or_mpc sin(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cos/*' />
        public static mp_mpf_or_mpc cos(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tan/*' />
        public static mp_mpf_or_mpc tan(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cot/*' />
        public static mp_mpf_or_mpc cot(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/csc/*' />
        public static mp_mpf_or_mpc csc(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sec/*' />
        public static mp_mpf_or_mpc sec(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinc/*' />
        public static mp_mpf_or_mpc sinc(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Trigonometric and related functions, in multiples of pi


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinpi/*' />
        public static mp_mpf_or_mpc sinpi(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cospi/*' />
        public static mp_mpf_or_mpc cospi(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tanpi/*' />
        public static mp_mpf_or_mpc tanpi(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cotpi/*' />
        public static mp_mpf_or_mpc cotpi(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cscpi/*' />
        public static mp_mpf_or_mpc cscpi(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/secpi/*' />
        public static mp_mpf_or_mpc secpi(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sincpi/*' />
        public static mp_mpf_or_mpc sincpi(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinh/*' />
        public static mp_mpf_or_mpc sinh(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cosh/*' />
        public static mp_mpf_or_mpc cosh(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tanh/*' />
        public static mp_mpf_or_mpc tanh(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coth/*' />
        public static mp_mpf_or_mpc coth(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/csch/*' />
        public static mp_mpf_or_mpc csch(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sech/*' />
        public static mp_mpf_or_mpc sech(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Inverse trigonometric functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asin/*' />
        public static mp_mpf_or_mpc asin(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acos/*' />
        public static mp_mpf_or_mpc acos(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/atan/*' />
        public static mp_mpf_or_mpc atan(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/atan2/*' />
        public static mp_mpf_or_mpc atan2(dynamic y, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acot/*' />
        public static mp_mpf_or_mpc acot(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acsc/*' />
        public static mp_mpf_or_mpc acsc(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asec/*' />
        public static mp_mpf_or_mpc asec(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Inverse hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asinh/*' />
        public static mp_mpf_or_mpc asinh(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acosh/*' />
        public static mp_mpf_or_mpc acosh(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/atanh/*' />
        public static mp_mpf_or_mpc atanh(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acoth/*' />
        public static mp_mpf_or_mpc acoth(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asech/*' />
        public static mp_mpf_or_mpc asech(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acsch/*' />
        public static mp_mpf_or_mpc acsch(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Gamma and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma/*' />
        public static mp_mpf_or_mpc gamma(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma1pm1/*' />
        public static mp_mpf_or_mpc gamma1pm1(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lgamma/*' />
        public static mp_mpf_or_mpc lgamma(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rgamma/*' />
        public static mp_mpf_or_mpc rgamma(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/factorial/*' />
        public static mp_mpf_or_mpc factorial(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/doublefactorial/*' />
        public static mp_mpf_or_mpc doublefactorial(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rising_factorial/*' />
        public static mp_mpf_or_mpc rising_factorial(dynamic x, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/falling_factorial/*' />
        public static mp_mpf_or_mpc falling_factorial(dynamic a, dynamic n)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_ratio/*' />
        public static mp_mpf_or_mpc gamma_ratio(dynamic a, dynamic b)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_delta_ratio/*' />
        public static mp_mpf_or_mpc gamma_delta_ratio(dynamic a, dynamic delta)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/beta/*' />
        public static mp_mpf_or_mpc beta(dynamic x, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/binomial/*' />
        public static mp_mpf_or_mpc binomial(dynamic n, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Miscellaneous


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lambert_w0/*' />
        public static mp_mpf_or_mpc lambert_w0(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lambert_wm1/*' />
        public static mp_mpf_or_mpc lambert_wm1(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lambert_wk/*' />
        public static mp_mpf_or_mpc lambert_wk(dynamic x, int k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/agm/*' />
        public static mp_mpf_or_mpc agm(dynamic x, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #endregion





        #region Special Functions


        #region Carlson symmetric elliptic integrals


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_rf/*' />
        public static mp_mpf_or_mpc elliptic_rf(dynamic x, dynamic y, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_rg/*' />
        public static mp_mpf_or_mpc elliptic_rg(dynamic x, dynamic y, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_rj/*' />
        public static mp_mpf_or_mpc elliptic_rj(dynamic x, dynamic y, dynamic z, dynamic w)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_rd/*' />
        public static mp_mpf_or_mpc elliptic_rd(dynamic x, dynamic y, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_rf/*' />
        public static mp_mpf_or_mpc elliptic_rc(dynamic x, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Legendre elliptic integrals (elliptic parameter m), and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/m_elliptic_k/*' />
        public static mp_mpf_or_mpc m_elliptic_k(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/m_elliptic_e/*' />
        public static mp_mpf_or_mpc m_elliptic_e(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/m_elliptic_pi/*' />
        public static mp_mpf_or_mpc m_elliptic_pi(dynamic x, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/m_elliptic_f/*' />
        public static mp_mpf_or_mpc m_elliptic_f(dynamic phi, dynamic m)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/m_elliptic_e_inc/*' />
        public static mp_mpf_or_mpc m_elliptic_e_inc(dynamic phi, dynamic m)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/m_elliptic_pi_inc/*' />
        public static mp_mpf_or_mpc m_elliptic_pi_inc(dynamic n, dynamic phi, dynamic m)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Legendre elliptic integrals (elliptic modulus k), and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_k/*' />
        public static mp_mpf_or_mpc elliptic_k(dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_e/*' />
        public static mp_mpf_or_mpc elliptic_e(dynamic k)
        {
            return new mp_mpf_or_mpc();
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_pi/*' />
        public static mp_mpf_or_mpc elliptic_pi(dynamic n, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_f/*' />
        public static mp_mpf_or_mpc elliptic_f(dynamic phi, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_e_inc/*' />
        public static mp_mpf_or_mpc elliptic_e_inc(dynamic phi, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_pi_inc/*' />
        public static mp_mpf_or_mpc elliptic_pi_inc(dynamic n, dynamic phi, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Jacobi elliptic functions, in terms of q


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_sn/*' />
        public static mp_mpf_or_mpc jacobi_sn(dynamic x, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_cn/*' />
        public static mp_mpf_or_mpc jacobi_cn(dynamic x, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_dn/*' />
        public static mp_mpf_or_mpc jacobi_dn(dynamic x, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_nc/*' />
        public static mp_mpf_or_mpc jacobi_nc(dynamic x, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_sc/*' />
        public static mp_mpf_or_mpc jacobi_sc(dynamic x, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_dc/*' />
        public static mp_mpf_or_mpc jacobi_dc(dynamic x, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_nd/*' />
        public static mp_mpf_or_mpc jacobi_nd(dynamic x, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_sd/*' />
        public static mp_mpf_or_mpc jacobi_sd(dynamic x, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_cd/*' />
        public static mp_mpf_or_mpc jacobi_cd(dynamic x, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_ns/*' />
        public static mp_mpf_or_mpc jacobi_ns(dynamic x, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_cs/*' />
        public static mp_mpf_or_mpc jacobi_cs(dynamic x, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_ds/*' />
        public static mp_mpf_or_mpc jacobi_ds(dynamic x, dynamic k)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Jacobi theta functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_theta1/*' />
        public static mp_mpf_or_mpc jacobi_theta1(dynamic x, dynamic q)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_theta2/*' />
        public static mp_mpf_or_mpc jacobi_theta2(dynamic x, dynamic q)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_theta3/*' />
        public static mp_mpf_or_mpc jacobi_theta3(dynamic x, dynamic q)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_theta4/*' />
        public static mp_mpf_or_mpc jacobi_theta4(dynamic x, dynamic q)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Conversions of parameters of Weierstrass P


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticInvariantG2G3/*' />
        public static Tuple<mp_mpf_or_mpc, mp_mpf_or_mpc> elliptic_invariants_from_roots(dynamic e1, dynamic e2)
        {
            return new Tuple<mp_mpf_or_mpc, mp_mpf_or_mpc>(new mp_mpf_or_mpc(), new mp_mpf_or_mpc());
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticInvariantG2G3/*' />
        public static Tuple<mp_mpf_or_mpc, mp_mpf_or_mpc> elliptic_invariants_from_tau(dynamic tau)
        {
            return new Tuple<mp_mpf_or_mpc, mp_mpf_or_mpc>(new mp_mpf_or_mpc(), new mp_mpf_or_mpc());
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticInvariantG2G3/*' />
        public static Tuple<mp_mpf_or_mpc, mp_mpf_or_mpc, mp_mpf_or_mpc> elliptic_roots_from_tau(dynamic tau)
        {
            return new Tuple<mp_mpf_or_mpc, mp_mpf_or_mpc, mp_mpf_or_mpc>(new mp_mpf_or_mpc(), new mp_mpf_or_mpc(), new mp_mpf_or_mpc());
        }


        #endregion



        #region Weierstrass elliptic functions, in terms of elliptic period ratio tau

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_p_t/*' />
        public static mp_mpf_or_mpc weierstrass_p_t(dynamic z, dynamic tau)
        {
            // Weierstrass p-function in terms of tau
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_pprime_t/*' />
        public static mp_mpf_or_mpc weierstrass_pprime_t(dynamic z, dynamic tau)
        {
            // Weierstrass p-function, first drivative, in terms of tau
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_zeta_t/*' />
        public static mp_mpf_or_mpc weierstrass_zeta_t(dynamic z, dynamic tau)
        {
            // Weierstrass zeta-function in terms of tau
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_p_inv_t/*' />
        public static mp_mpf_or_mpc weierstrass_p_inv_t(dynamic z, dynamic tau)
        {
            // Weierstrass p-inverse function in terms of tau
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_sigma_t/*' />
        public static mp_mpf_or_mpc weierstrass_sigma_t(dynamic z, dynamic tau)
        {
            // Weierstrass sigma-function in terms of tau
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Modular forms


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dedekind_eta/*' />
        public static mp_mpf_or_mpc dedekind_eta(dynamic tau)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_modular_lambda/*' />
        public static mp_mpf_or_mpc elliptic_modular_lambda(dynamic tau)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_modular_delta/*' />
        public static mp_mpf_or_mpc elliptic_modular_delta(dynamic tau)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/klein_j/*' />
        public static mp_mpf_or_mpc klein_j(dynamic tau)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/klein_j_inv/*' />
        public static mp_mpf_or_mpc klein_j_inv(dynamic j)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion






        #region Lerch’s transcendent: Overview


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lerch_phi/*' />
        public static mp_mpf_or_mpc lerch_phi(dynamic s, dynamic z, dynamic a)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lerch_zeta/*' />
        public static mp_mpf_or_mpc lerch_zeta(dynamic lambda1, dynamic alpha, dynamic s)
        {
            return new mp_mpf_or_mpc();
        }






        #endregion



        #region polygamma functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/polygamma/*' />
        public static mp_mpf_or_mpc polygamma(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/trigamma/*' />
        public static mp_mpf_or_mpc trigamma(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/digamma/*' />
        public static mp_mpf_or_mpc digamma(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/harmonic/*' />
        public static mp_mpf_or_mpc harmonic(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Polylogarithms and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/polylog/*' />
        public static mp_mpf_or_mpc polylog(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/trilog/*' />
        public static mp_mpf_or_mpc trilog(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dilog/*' />
        public static mp_mpf_or_mpc dilog(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/clausen_sin/*' />
        public static mp_mpf_or_mpc clausen_sin(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/clausen_cos/*' />
        public static mp_mpf_or_mpc clausen_cos(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/trilog/*' />
        public static mp_mpf_or_mpc clausen2(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bose_einstein/*' />
        public static mp_mpf_or_mpc bose_einstein(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fermi_dirac/*' />
        public static mp_mpf_or_mpc fermi_dirac(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/legendre_chi/*' />
        public static mp_mpf_or_mpc legendre_chi(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/inverse_tan_integral/*' />
        public static mp_mpf_or_mpc inverse_tan_integral(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Hurwitz zeta function and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hurwitz_zeta/*' />
        public static mp_mpf_or_mpc hurwitz_zeta(dynamic s, dynamic a)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/harmonic2/*' />
        public static mp_mpf_or_mpc harmonic2(dynamic z, dynamic r)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bernoulli/*' />
        public static mp_mpf_or_mpc bernoulli(Int32 n)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bernoulli/*' />
        public static mp_mpf_or_mpc bernpoly(dynamic x, Int32 n)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/eulernum/*' />
        public static mp_mpf_or_mpc eulernum(Int32 n)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/eulerpoly/*' />
        public static mp_mpf_or_mpc eulerpoly(dynamic x, Int32 n)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/barnes_g/*' />
        public static mp_mpf_or_mpc barnes_g(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logbarnes_g/*' />
        public static mp_mpf_or_mpc logbarnes_g(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperfactorial/*' />
        public static mp_mpf_or_mpc hyperfactorial(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/superfactorial/*' />
        public static mp_mpf_or_mpc superfactorial(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Riemann zeta function, and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/zeta/*' />
        public static mp_mpf_or_mpc zeta(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/zetam1/*' />
        public static mp_mpf_or_mpc zetam1(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hardy_theta/*' />
        public static mp_mpf_or_mpc hardy_theta(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hardy_z/*' />
        public static mp_mpf_or_mpc hardy_z(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/riemann_xi/*' />
        public static mp_mpf_or_mpc riemann_xi(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dirichlet_eta/*' />
        public static mp_mpf_or_mpc dirichlet_eta(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dirichlet_etam1/*' />
        public static mp_mpf_or_mpc dirichlet_etam1(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dirichlet_beta/*' />
        public static mp_mpf_or_mpc dirichlet_beta(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dirichlet_lambda/*' />
        public static mp_mpf_or_mpc dirichlet_lambda(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/zeta_zero/*' />
        public static mp_mpf_or_mpc zeta_zero(dynamic n)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Additional numbertheoretic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bell/*' />
        public static mp_mpf_or_mpc bell(Int32 n)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/partitions/*' />
        public static mp_mpf_or_mpc partitions(Int32 n)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/primorial/*' />
        public static mp_mpf_or_mpc primorial(Int32 n)
        {
            return new mp_mpf_or_mpc();
        }





        #endregion








        #region 0F1: Overview


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_0f1/*' />
        public static mp_mpf_or_mpc hyperg_0f1(dynamic a, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_0f1r/*' />
        public static mp_mpf_or_mpc hyperg_0f1r(dynamic a, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Bessel functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_jv/*' />
        public static mp_mpf_or_mpc bessel_jv(dynamic nu, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_yv/*' />
        public static mp_mpf_or_mpc bessel_yv(dynamic nu, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_jv_prime/*' />
        public static mp_mpf_or_mpc bessel_jv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_yv_prime/*' />
        public static mp_mpf_or_mpc bessel_yv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_zero/*' />
        public static mp_mpf bessel_jv_zero(dynamic x, int m)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_zero/*' />
        public static mp_mpf bessel_yv_zero(dynamic x, int m)
        {
            return new mp_mpf();
        }


        #endregion



        #region Modified Bessel functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_iv/*' />
        public static mp_mpf_or_mpc bessel_iv(dynamic nu, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_kv/*' />
        public static mp_mpf_or_mpc bessel_kv(dynamic nu, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_iv_prime/*' />
        public static mp_mpf_or_mpc bessel_iv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_kv_prime/*' />
        public static mp_mpf_or_mpc bessel_kv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Spherical Bessel functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_jn/*' />
        public static mp_mpf_or_mpc sph_bessel_jn(dynamic n, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_yn/*' />
        public static mp_mpf_or_mpc sph_bessel_yn(dynamic n, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_prime/*' />
        public static mp_mpf_or_mpc sph_bessel_jn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_prime/*' />
        public static mp_mpf_or_mpc sph_bessel_yn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_zero/*' />
        public static mp_mpf sph_bessel_jn_zero(dynamic x, int m)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_zero/*' />
        public static mp_mpf sph_bessel_yn_zero(dynamic x, int m)
        {
            return new mp_mpf();
        }


        #endregion



        #region Modified Spherical Bessel functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_in/*' />
        public static mp_mpf_or_mpc sph_bessel_in(dynamic n, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_kn/*' />
        public static mp_mpf_or_mpc sph_bessel_kn(dynamic n, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in_prime/*' />
        public static mp_mpf_or_mpc sph_bessel_in_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn_prime/*' />
        public static mp_mpf_or_mpc sph_bessel_kn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/besselpoly/*' />
        public static mp_mpf_or_mpc besselpoly(dynamic nu, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/besseltheta/*' />
        public static mp_mpf_or_mpc besseltheta(dynamic nu, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Hankel functions


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h1/*' />
        public static mp_mpf_or_mpc hankel_h1(dynamic v, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h2/*' />
        public static mp_mpf_or_mpc hankel_h2(dynamic v, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h1/*' />
        public static mp_mpf_or_mpc sph_hankel_h1(int n, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h2/*' />
        public static mp_mpf_or_mpc sph_hankel_h2(int n, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region 0F1: Airy functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_ai/*' />
        public static mp_mpf_or_mpc airy_ai(dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_bi/*' />
        public static mp_mpf_or_mpc airy_bi(dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_ai_prime/*' />
        public static mp_mpf_or_mpc airy_ai_prime(dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_bi_prime/*' />
        public static mp_mpf_or_mpc airy_bi_prime(dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_ai_zero/*' />
        public static mp_mpf_or_mpc airy_ai_zero(Int32 n)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_bi_zero/*' />
        public static mp_mpf_or_mpc airy_bi_zero(Int32 n)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_ai_prime_zero/*' />
        public static mp_mpf_or_mpc airy_ai_prime_zero(UInt32 n)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_bi_prime_zero/*' />
        public static mp_mpf_or_mpc airy_bi_prime_zero(UInt32 n)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region 0F1: Kelvin functions


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ber/*' />
        public static mp_mpf_or_mpc kelvin_ber(dynamic v, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_bei/*' />
        public static mp_mpf_or_mpc kelvin_bei(dynamic v, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ker/*' />
        public static mp_mpf_or_mpc kelvin_ker(dynamic v, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_kei/*' />
        public static mp_mpf_or_mpc kelvin_kei(dynamic v, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ber_prime/*' />
        public static mp_mpf_or_mpc kelvin_ber_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_bei_prime/*' />
        public static mp_mpf_or_mpc kelvin_bei_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ker_prime/*' />
        public static mp_mpf_or_mpc kelvin_ker_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_kei_prime/*' />
        public static mp_mpf_or_mpc kelvin_kei_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion







        #region 1F1 Overview


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_1f1/*' />
        public static mp_mpf_or_mpc hyperg_1f1(dynamic a, dynamic b, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_1f1r/*' />
        public static mp_mpf_or_mpc hyperg_1f1r(dynamic a, dynamic b, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_u/*' />
        public static mp_mpf_or_mpc hyperg_u(dynamic a, dynamic b, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/laguerre_l/*' />
        public static mp_mpf_or_mpc laguerre_l(dynamic n, dynamic m, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hermite_h/*' />
        public static mp_mpf_or_mpc hermite_h(dynamic n, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hermite_he/*' />
        public static mp_mpf_or_mpc hermite_he(dynamic n, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Incomplete gamma functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_p/*' />
        public static mp_mpf_or_mpc gamma_p(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_q/*' />
        public static mp_mpf_or_mpc gamma_q(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_lower/*' />
        public static mp_mpf_or_mpc gamma_lower(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_upper/*' />
        public static mp_mpf_or_mpc gamma_upper(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_tricomi/*' />
        public static mp_mpf_or_mpc gamma_tricomi(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_p_prime/*' />
        public static mp_mpf_or_mpc gamma_p_prime(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inv/*' />
        public static mp_mpf gamma_p_inv(dynamic a, dynamic p)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inv/*' />
        public static mp_mpf gamma_q_inv(dynamic a, dynamic q)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inva/*' />
        public static mp_mpf gamma_p_inva(dynamic x, dynamic p)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inva/*' />
        public static mp_mpf gamma_q_inva(dynamic x, dynamic q)
        {
            return new mp_mpf();
        }


        #endregion



        #region Coulomb, Whittaker and parabolic cylinder function


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coulomb_f/*' />
        public static mp_mpf_or_mpc coulomb_f(dynamic l, dynamic eta, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coulomb_g/*' />
        public static mp_mpf_or_mpc coulomb_g(dynamic l, dynamic eta, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coulomb_hplus/*' />
        public static mp_mpf_or_mpc coulomb_hplus(dynamic l, dynamic eta, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coulomb_hminus/*' />
        public static mp_mpf_or_mpc coulomb_hminus(dynamic l, dynamic eta, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/whittaker_m/*' />
        public static mp_mpf_or_mpc whittaker_m(dynamic k, dynamic m, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/whittaker_w/*' />
        public static mp_mpf_or_mpc whittaker_w(dynamic k, dynamic m, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cylinder_d/*' />
        public static mp_mpf_or_mpc cylinder_d(dynamic n, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cylinder_u/*' />
        public static mp_mpf_or_mpc cylinder_u(dynamic a, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cylinder_v/*' />
        public static mp_mpf_or_mpc cylinder_v(dynamic a, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cylinder_w/*' />
        public static mp_mpf_or_mpc cylinder_w(dynamic a, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Error function and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erf/*' />
        public static mp_mpf_or_mpc erf(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erfc/*' />
        public static mp_mpf_or_mpc erfc(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erf_inv/*' />
        public static mp_mpf_or_mpc erf_inv(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erfc_inv/*' />
        public static mp_mpf_or_mpc erfc_inv(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ndens/*' />
        public static mp_mpf_or_mpc ndens(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ndis/*' />
        public static mp_mpf_or_mpc ndis(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erfi/*' />
        public static mp_mpf_or_mpc erfi(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dawson/*' />
        public static mp_mpf_or_mpc dawson(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/faddeeva/*' />
        public static mp_mpf_or_mpc faddeeva(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fresnel_s/*' />
        public static mp_mpf_or_mpc fresnel_s(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fresnel_c/*' />
        public static mp_mpf_or_mpc fresnel_c(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/owen_t/*' />
        public static mp_mpf_or_mpc owen_t(dynamic h, dynamic a)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region 1F1: Exponential integrals and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp_integral_e1/*' />
        public static mp_mpf_or_mpc exp_integral_e1(dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp_integral_ei/*' />
        public static mp_mpf_or_mpc exp_integral_ei(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log_integral/*' />
        public static mp_mpf_or_mpc log_integral(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log_integral_offset/*' />
        public static mp_mpf_or_mpc log_integral_offset(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinh_integral/*' />
        public static mp_mpf_or_mpc sinh_integral(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cosh_integral/*' />
        public static mp_mpf_or_mpc cosh_integral(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sin_integral/*' />
        public static mp_mpf_or_mpc sin_integral(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp_integral_en/*' />
        public static mp_mpf_or_mpc exp_integral_en(dynamic s, dynamic z)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cos_integral/*' />
        public static mp_mpf_or_mpc cos_integral(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion








        #region 2F1 Overview


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_2f1/*' />
        public static mp_mpf_or_mpc hyperg_2f1(dynamic a, dynamic b, dynamic c, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_2f1r/*' />
        public static mp_mpf_or_mpc hyperg_2f1r(dynamic a, dynamic b, dynamic c, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Chebyshev, Gegenbauer and Jacobi polynomials


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chebyshev_t/*' />
        public static mp_mpf_or_mpc chebyshev_t(dynamic n, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chebyshev_u/*' />
        public static mp_mpf_or_mpc chebyshev_u(dynamic n, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_v/*' />
        public static mp_mpf_or_mpc chebyshev_v(int n, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_w/*' />
        public static mp_mpf_or_mpc chebyshev_w(int n, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gegenbauer_c/*' />
        public static mp_mpf_or_mpc gegenbauer_c(dynamic n, dynamic m, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_p/*' />
        public static mp_mpf_or_mpc jacobi_p(dynamic n, dynamic a, dynamic b, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/zernike_r/*' />
        public static mp_mpf_or_mpc zernike_r(dynamic n, dynamic m, dynamic r)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Legendre polynomials and related


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_p/*' />
        public static mp_mpf_or_mpc legendre_p(dynamic n, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_plm/*' />
        public static mp_mpf_or_mpc legendre_plm(dynamic n, dynamic m, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_q/*' />
        public static mp_mpf_or_mpc legendre_q(dynamic n, dynamic y)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_qlm/*' />
        public static mp_mpf_or_mpc legendre_qlm(dynamic n, dynamic m, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/spherical_y/*' />
        public static mp_mpf_or_mpc spherical_y(dynamic n, dynamic m, dynamic theta, dynamic phi)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/toroidal_plm/*' />
        public static mp_mpf_or_mpc toroidal_plm(dynamic l, dynamic m, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/toroidal_qlm/*' />
        public static mp_mpf_or_mpc toroidal_qlm(dynamic l, dynamic m, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Incomplete beta Function


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/beta_lower/*' />
        public static mp_mpf_or_mpc beta_lower(dynamic a, dynamic b, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ibeta/*' />
        public static mp_mpf_or_mpc ibeta(dynamic a, dynamic b, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ibetac/*' />
        public static mp_mpf_or_mpc ibetac(dynamic a, dynamic b, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ibeta_prime/*' />
        public static mp_mpf_or_mpc ibeta_prime(dynamic a, dynamic b, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/beta_upper/*' />
        public static mp_mpf_or_mpc beta_upper(dynamic a, dynamic b, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inv/*' />
        public static mp_mpf ibeta_inv(dynamic a, dynamic b, dynamic p)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inv/*' />
        public static mp_mpf ibetac_inv(dynamic a, dynamic b, dynamic q)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inva/*' />
        public static mp_mpf ibeta_inva(dynamic b, dynamic x, dynamic p)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inva/*' />
        public static mp_mpf ibetac_inva(dynamic b, dynamic x, dynamic q)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_invb/*' />
        public static mp_mpf ibeta_invb(dynamic a, dynamic x, dynamic p)
        {
            return new mp_mpf();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_invb/*' />
        public static mp_mpf ibetac_invb(dynamic a, dynamic x, dynamic q)
        {
            return new mp_mpf();
        }


        #endregion





        #region Hypergeometric Function 1F2, overview


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_1f2/*' />
        public static mp_mpf_or_mpc hyperg_1f2(dynamic a1, dynamic b1, dynamic b2, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_1f2r/*' />
        public static mp_mpf_or_mpc hyperg_1f2r(dynamic a1, dynamic b1, dynamic b2, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Scorer functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_gi/*' />
        public static mp_mpf_or_mpc airy_gi(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_hi/*' />
        public static mp_mpf_or_mpc airy_hi(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_gi_prime/*' />
        public static mp_mpf_or_mpc airy_gi_prime(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_hi_prime/*' />
        public static mp_mpf_or_mpc airy_hi_prime(dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Struve functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/struve_h/*' />
        public static mp_mpf_or_mpc struve_h(dynamic v, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/struve_l/*' />
        public static mp_mpf_or_mpc struve_l(dynamic v, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/struve_k/*' />
        public static mp_mpf_or_mpc struve_k(dynamic v, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/struve_m/*' />
        public static mp_mpf_or_mpc struve_m(dynamic v, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #region Anger, Weber and Lommel functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/anger_j/*' />
        public static mp_mpf_or_mpc anger_j(dynamic v, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weber_e/*' />
        public static mp_mpf_or_mpc weber_e(dynamic v, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lommel_s1/*' />
        public static mp_mpf_or_mpc lommel_s1(dynamic mu, dynamic nu, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lommel_s2/*' />
        public static mp_mpf_or_mpc lommel_s2(dynamic mu, dynamic nu, dynamic x)
        {
            return new mp_mpf_or_mpc();
        }


        #endregion



        #endregion











    }





}