using System;
using System.Numerics;
using System.Runtime.InteropServices;


namespace FixedPrecNet
{


    // Size of FPC boolean: 1 byte, C# type: Byte
    // Size of FPC word: Uint16
    // Size of FPC integer: Int16
    // Size of FPC longint: Int32
    // Size of FPC mp_digit = cardinal: Uint32
    // Size of FPC cardinal: Uint32
    // Size of FPC mp_word: Int64

    // MAXDigits = $1000000

    // <: &lt;
    // >: &gt;
    // >=: &#8805;
    // <>: &#8800;
    // <=: &#8804;



    // https://web.archive.org/web/20190628091417/http://www.wolfgang-ehrhardt.de/index.html




    public partial class math53
    {



        public delegate Double cb1SRet1S(Double x); // cb1SRet1S


        public static String fmt(Double x)
        {
            string s = " " + x.ToString("G15", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
            return s;
        }


        public static String fmt(dynamic x)
        {
            return fmt(t(x));
        }



        #region General

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/name/*' />
        public static String name
        {
            get { return "math53"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  dreal"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/prec/*' />
        public static Int32 prec
        {
            get { return 53; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/isboostctx/*' />
        public static bool isboostctx
        {
            get { return true; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/iscplxctx/*' />
        public static bool iscplxctx
        {
            get { return false; }
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
            get { return true; }
        }


        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/realctx/*' />
        public static math53 realctx
        {
            get { return new math53(); }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static cmath53 cplxctx
        {
            get { return new cmath53(); }
        }





        #endregion



        #region Basic floating point functions




        #region Conversion


        /// <summary>
        /// Returns t(Double d)
        /// </summary>
        public static Double t(Double d)
        {
            return d;
        }

        /// <summary>
        /// Returns a Double using a string as input
        /// </summary>
        public static Double t(string s)
        {
            Double res = 0.0;
            Lib_FReal_Set_Str(ref res, s);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Set_Str", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Set_Str(ref Double res, string s);


        /// <summary>
        /// Returns a Double using a Quadruple as input
        /// </summary>
        public static Double t(Quadruple q)
        {
            Double res = 0.0;
            Lib_FReal_Set_QReal(ref res, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Set_QReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Set_QReal(ref Double res, IntPtr q);


        #endregion



        #region General real functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fma/*' />
        public static Double fma(Double x, Double y, Double z)
        {
            return x * y + z;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fma/*' />
        public static Double fma(dynamic x, dynamic y, dynamic z)
        {
            return fma(t(x), t(y), t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fmax/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_maxd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fmax(Double x, Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fmin/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_mind", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fmin(Double x, Double y);




        #endregion



        #region Machine constants, general


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/zero/*' />
        public static Double zero
        {
            get
            {
                return 0.0d;
            }
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/negzero/*' />
        public static Double negzero
        {
            get
            {
                return -0.0d;
            }
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/one/*' />
        public static Double one
        {
            get
            {
                return 1.0d;
            }
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/inf/*' />
        public static Double inf
        {
            get
            {
                return Double.PositiveInfinity;
            }
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/neginf/*' />
        public static Double neginf
        {
            get
            {
                return Double.NegativeInfinity;
            }
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/nan/*' />
        public static Double nan
        {
            get
            {
                return Double.NaN;
            }
        }


        #endregion



        #region Properties of numbers


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/signbit/*' />
        public static int signbit(Double x)
        {
            return Lib_FReal_Signbit(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Signbit", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Signbit(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/signbit/*' />
        public static int signbit(dynamic x)
        {
            return signbit(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isfinite/*' />
        public static bool isfinite(Double x)
        {
            return 0 != Lib_FReal_Finite(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Finite", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Finite(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isfinite/*' />
        public static bool isfinite(dynamic x)
        {
            return isfinite(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isinf/*' />
        public static bool isinf(Double x)
        {
            return 0 != (Lib_FReal_Isinf(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isinf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isinf(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isinf/*' />
        public static bool isinf(dynamic x)
        {
            return isinf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isposinf/*' />
        public static bool isposinf(Double x)
        {
            return 0 != (Lib_FReal_Isposinf(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isposinf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isposinf(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isposinf/*' />
        public static bool isposinf(dynamic x)
        {
            return isposinf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isneginf/*' />
        public static bool isneginf(Double x)
        {
            return 0 != (Lib_FReal_Isneginf(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isneginf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isneginf(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isneginf/*' />
        public static bool isneginf(dynamic x)
        {
            return isneginf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isnan/*' />
        public static bool isnan(Double x)
        {
            return 0 != (Lib_FReal_Isnan(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isnan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isnan(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isnan/*' />
        public static bool isnan(dynamic x)
        {
            return isnan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/iszero/*' />
        public static bool iszero(Double x)
        {
            return 0 != (Lib_FReal_Iszero(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Iszero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Iszero(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/iszero/*' />
        public static bool iszero(dynamic x)
        {
            return iszero(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isone/*' />
        public static bool isone(Double x)
        {
            return 0 != (Lib_FReal_Isone(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isone(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isone/*' />
        public static bool isone(dynamic x)
        {
            return isone(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isinteger/*' />
        public static bool isinteger(Double x)
        {
            return 0 != (Lib_FReal_Isinteger(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isinteger", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isinteger(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isinteger/*' />
        public static bool isinteger(dynamic x)
        {
            return isinteger(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isnumber/*' />
        public static bool isnumber(Double x)
        {
            return 0 != (Lib_FReal_Isnumber(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isnumber", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isnumber(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isnumber/*' />
        public static bool isnumber(dynamic x)
        {
            return isnumber(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isregular/*' />
        public static bool isregular(Double x)
        {
            return 0 != (Lib_FReal_Isregular(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isregular", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isregular(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isregular/*' />
        public static bool isregular(dynamic x)
        {
            return isregular(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isnormal/*' />
        public static bool isnormal(Double x)
        {
            return 0 != (Lib_FReal_Isnormal(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isnormal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isnormal(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isnormal/*' />
        public static bool isnormal(dynamic x)
        {
            return isnormal(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isunordered/*' />
        public static bool isunordered(Double x, Double y)
        {
            return 0 != (Lib_FReal_Isunordered(ref x, ref y));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isunordered", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isunordered(ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/isunordered/*' />
        public static bool isunordered(dynamic x, dynamic y)
        {
            return isunordered(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fitsint32/*' />
        public static bool fitsint32(Double x)
        {
            return 0 != (Lib_FReal_FitsInt32(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_FitsInt32", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_FitsInt32(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fitsint32/*' />
        public static bool fitsint32(dynamic x)
        {
            return fitsint32(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fitsint64/*' />
        public static bool fitsint64(Double x)
        {
            return 0 != (Lib_FReal_FitsInt64(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_FitsInt64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_FitsInt64(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fitsint64/*' />
        public static bool fitsint64(dynamic x)
        {
            return fitsint64(t(x));
        }



        #endregion




        #region Integer Related Functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/nearbyint/*' />
        public static Double nearbyint(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Nearbyint(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Nearbyint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Nearbyint(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/nearbyint/*' />
        public static Double nearbyint(dynamic x)
        {
            return nearbyint(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rint/*' />
        public static Double rint(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Rint(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Rint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Rint(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rint/*' />
        public static Double rint(dynamic x)
        {
            return rint(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lrint/*' />
        public static Int32 lrint(Double x)
        {
            return Lib_FReal_Lrint(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Lrint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_FReal_Lrint(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lrint/*' />
        public static Int32 lrint(dynamic x)
        {
            return lrint(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/llrint/*' />
        public static Int64 llrint(Double x)
        {
            return Lib_FReal_Llrint(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Llrint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int64 Lib_FReal_Llrint(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/llrint/*' />
        public static Int64 llrint(dynamic x)
        {
            return llrint(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ceil/*' />
        public static Double ceil(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Ceil(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ceil", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Ceil(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ceil/*' />
        public static Double ceil(dynamic x)
        {
            return ceil(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/floor/*' />
        public static Double floor(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Floor(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Floor", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Floor(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/floor/*' />
        public static Double floor(dynamic x)
        {
            return floor(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/trunc/*' />
        public static Double trunc(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Trunc(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Trunc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Trunc(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/trunc/*' />
        public static Double trunc(dynamic x)
        {
            return trunc(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/round/*' />
        public static Double round(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Round(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Round", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Round(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/round/*' />
        public static Double round(dynamic x)
        {
            return round(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lround/*' />
        public static Int32 lround(Double x)
        {
            return Lib_FReal_Lround(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Lround", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_FReal_Lround(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lround/*' />
        public static Int32 lround(dynamic x)
        {
            return lround(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/llround/*' />
        public static Int64 llround(Double x)
        {
            return Lib_FReal_Llround(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Llround", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int64 Lib_FReal_Llround(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/llround/*' />
        public static Int64 llround(dynamic x)
        {
            return llround(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ToInt32/*' />
        public static Int32 ToInt32(Double x)
        {
            return Lib_FReal_ToInt32(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_ToInt32", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_FReal_ToInt32(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ToInt32/*' />
        public static Int32 ToInt32(dynamic x)
        {
            return ToInt32(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ToInt64/*' />
        public static Int64 ToInt64(Double x)
        {
            return Lib_FReal_ToInt64(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_ToInt64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int64 Lib_FReal_ToInt64(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ToInt64/*' />
        public static Int64 ToInt64(dynamic x)
        {
            return ToInt64(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ToUInt32/*' />
        public static UInt32 ToUInt32(Double x)
        {
            return Lib_FReal_ToUInt32(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_ToUInt32", CallingConvention = CallingConvention.Cdecl)]
        internal static extern UInt32 Lib_FReal_ToUInt32(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ToUInt32/*' />
        public static UInt32 ToUInt32(dynamic x)
        {
            return ToUInt32(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ToUInt64/*' />
        public static UInt64 ToUInt64(Double x)
        {
            return Lib_FReal_ToUInt64(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_ToUInt64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern UInt64 Lib_FReal_ToUInt64(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ToUInt64/*' />
        public static UInt64 ToUInt64(dynamic x)
        {
            return ToUInt64(t(x));
        }




        #endregion





        #region Floating point functions for real numbers


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/copysign/*' />
        public static Double copysign(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Copysign(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Copysign", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Copysign(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/copysign/*' />
        public static Double copysign(dynamic x, dynamic y)
        {
            return copysign(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/frexp/*' />
        public static Tuple<Double, Int32> frexp(Double x)
        {
            Double res = 0.0;
            Int32 e = 0;
            Lib_FReal_Frexp(ref res, ref x, ref e);
            return new Tuple<Double, int>(res, e);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Frexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Frexp(ref Double res, ref Double x, ref Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/frexp/*' />
        public static Tuple<Double, Int32> frexp(dynamic x)
        {
            return frexp(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logb/*' />
        public static Double logb(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Logb(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Logb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Logb(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logb/*' />
        public static Double logb(dynamic x)
        {
            return logb(t(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ilogb/*' />
        public static Int32 ilogb(Double x)
        {
            return Lib_FReal_Ilogb(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ilogb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_FReal_Ilogb(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ilogb/*' />
        public static Int32 ilogb(dynamic x)
        {
            return ilogb(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ldexp/*' />
        public static Double ldexp(Double x, Int32 e)
        {
            Double res = 0.0;
            Lib_FReal_Ldexp(ref res, ref x, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ldexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Ldexp(ref Double res, ref Double x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ldexp/*' />
        public static Double ldexp(dynamic x, dynamic e)
        {
            return ldexp(t(x), ToInt32(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/scalbn/*' />
        public static Double scalbn(Double x, Int32 e)
        {
            Double res = 0.0;
            Lib_FReal_Scalbn(ref res, ref x, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Scalbn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Scalbn(ref Double res, ref Double x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/scalbn/*' />
        public static Double scalbn(dynamic x, dynamic e)
        {
            return scalbn(t(x), ToInt32(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/scalbln/*' />
        public static Double scalbln(Double x, Int32 e)
        {
            Double res = 0.0;
            Lib_FReal_Scalbln(ref res, ref x, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Scalbln", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Scalbln(ref Double res, ref Double x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/scalbln/*' />
        public static Double scalbln(dynamic x, dynamic e)
        {
            return scalbln(t(x), ToInt32(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fdim/*' />
        public static Double fdim(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Fdim(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Fdim", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Fdim(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fdim/*' />
        public static Double fdim(dynamic x, dynamic y)
        {
            return fdim(t(x), t(y));
        }


        #endregion




        #region Fraction and remainder Related Functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/modf/*' />
        public static Tuple<Double, Double> modf(Double x)
        {
            Double iptr = 0.0;
            Double frac = 0.0;
            Lib_FReal_Modf(ref frac, ref x, ref iptr);
            return new Tuple<Double, Double>(iptr, frac);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Modf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Modf(ref Double frac, ref Double x, ref Double iptr);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/modf/*' />
        public static Tuple<Double, Double> modf(dynamic x)
        {
            return modf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fmod/*' />
        public static Double fmod(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Fmod(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Fmod", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Fmod(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fmod/*' />
        public static Double fmod(dynamic x, dynamic y)
        {
            return fmod(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/remainder/*' />
        public static Double remainder(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Remainder(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Remainder", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Remainder(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/remainder/*' />
        public static Double remainder(dynamic x, dynamic y)
        {
            return remainder(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/remquo/*' />
        public static Tuple<Double, Int32> remquo(Double x, Double y)
        {
            Double res = 0.0;
            Int32 e = 0;
            Lib_FReal_Remquo(ref res, ref x, ref y, ref e);
            return new Tuple<Double, int>(res, e);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Remquo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Remquo(ref Double res, ref Double x, ref Double y, ref Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/remquo/*' />
        public static Tuple<Double, Int32> remquo(dynamic x, dynamic y)
        {
            return remquo(t(x), t(y));
        }

        #endregion




        #region Functions related to mantissa width and exponent range


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/epsilon/*' />
        public static Double epsilon()
        {
            Double res = 0.0;
            Lib_FReal_Epsilon(ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Epsilon", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Epsilon(ref Double res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ulp/*' />
        public static Double ulp(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Ulp(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ulp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Ulp(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ulp/*' />
        public static Double ulp(dynamic x)
        {
            return ulp(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/maxvalue/*' />
        public static Double maxvalue()
        {
            Double res = 0.0;
            Lib_FReal_Max(ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Max", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Max(ref Double res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lowestvalue/*' />
        public static Double lowestvalue()
        {
            Double res = 0.0;
            Lib_FReal_Lowest(ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Lowest", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Lowest(ref Double res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/minposvalue/*' />
        public static Double minposvalue()
        {
            Double res = 0.0;
            Lib_FReal_Min(ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Min", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Min(ref Double res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/nextafter/*' />
        public static Double nextafter(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Nexttoward(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Nexttoward", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Nexttoward(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/nextafter/*' />
        public static Double nextafter(dynamic x, dynamic y)
        {
            return nextafter(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/nextabove/*' />
        public static Double nextabove(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Nextabove(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Nextabove", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Nextabove(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/nextabove/*' />
        public static Double nextabove(dynamic x)
        {
            return nextabove(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/nextbelow/*' />
        public static Double nextbelow(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Nextbelow(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Nextbelow", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Nextbelow(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/nextbelow/*' />
        public static Double nextbelow(dynamic x)
        {
            return nextbelow(t(x));
        }


        #endregion




        #region Mathematical Constants


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/degree/*' />
        public static Double degree
        {
            get { return 0.017453292519943295; }
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/phi/*' />
        public static Double phi
        {
            get { return 1.6180339887498949; }
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ln2/*' />
        public static Double ln2
        {
            get { return 0.69314718055994529; }
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ln10/*' />
        public static Double ln10
        {
            get { return 2.3025850929940459; }
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pi/*' />
        public static Double pi
        {
            get { return 3.14159265358979; }
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/e/*' />
        public static Double e
        {
            get { return 2.718281828459045; }
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/egamma/*' />
        public static Double egamma
        {
            get { return 0.57721566490153287; }
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/apery/*' />
        public static Double apery
        {
            get { return 1.2020569031595942; }
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/catalan/*' />
        public static Double catalan
        {
            get { return 0.915965594177219; }
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/glaisher/*' />
        public static Double glaisher
        {
            get { return 1.2824271291006226; }
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/khinchin/*' />
        public static Double khinchin
        {
            get { return 2.6854520010653062; }
        }


        #endregion




        #endregion







        #region Elementary scalar functions


        #region Complex components


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/abs/*' />
        public static Double abs(Double x)
        {
            return Math.Abs(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/abs/*' />
        public static Double abs(dynamic x)
        {
            return abs(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fabs/*' />
        public static Double fabs(Double x)
        {
            return Math.Abs(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fabs/*' />
        public static Double fabs(dynamic x)
        {
            return fabs(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sign/*' />
        public static Double sign(Double x)
        {
            return Math.Sign(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sign/*' />
        public static Double sign(dynamic x)
        {
            return sign(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/real/*' />
        public static Double real(Double x)
        {
            return +x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/real/*' />
        public static Double real(dynamic x)
        {
            return real(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/imag/*' />
        public static Double imag(Double x)
        {
            return 0.0;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/imag/*' />
        public static Double imag(dynamic x)
        {
            return 0.0;
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/phase/*' />
        public static Double phase(Double x)
        {
            if (x >= 0.0) return 0.0;
            else return pi;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/phase/*' />
        public static Double phase(dynamic x)
        {
            return phase(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/conj/*' />
        public static Double conj(Double x)
        {
            return +x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/conj/*' />
        public static Double conj(dynamic x)
        {
            return conj(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/polar/*' />
        public static Tuple<Double, Double> polar(Double x)
        {
            return new Tuple<Double, Double>(abs(x), phase(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/polar/*' />
        public static Tuple<Double, Double> polar(dynamic x)
        {
            return polar(dreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rect/*' />
        public static Complex rect(Double r, Double phi)
        {
            return r * expj(phi);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rect/*' />
        public static Complex rect(dynamic r, dynamic phi)
        {
            return rect(dreal.t(r), dreal.t(phi));
        }







        #endregion



        #region Roots

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqrt/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sqrt", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sqrt(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rsqrt/*' />
        public static Double rsqrt(Double x)
        {
            return 1.0 / sqrt(x);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqrt1pm1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sqrt1pm1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sqrt1pm1(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cbrt/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cbrt", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cbrt(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cuberoot/*' />
        public static Double cuberoot(Double x)
        {
            return cbrt(x);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/root_si/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_nroot", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double root_si(Double x, int n);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/surd/*' />
        public static Double surd(Double x, int n)
        {
            return root_si(x, dreal.lrint(n));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/unitroots/*' />
        public static Double unitroots(Double x, int n)
        {
            return root_si(x, dreal.lrint(n));
        }


        //// See also: Press, 3rd edition, page 227
        //public static Tuple<Complex, Complex> quadratic_equation(Double a, Double b, Double c)
        //{
        //    return cmath53.quadratic_equation(a, b, c);
        //}


        //// See also: Press, 3rd edition, page 228
        //public static Tuple<Complex, Complex, Complex> cubic_equation_monic(Double a, Double b, Double c)
        //{
        //    return cmath53.cubic_equation_monic(a, b, c);
        //}


        //public static Tuple<Complex, Complex, Complex> cubic_equation(Double A, Double B, Double C, Double D)
        //{
        //    return cmath53.cubic_equation_monic(B / A, C / A, D / A);
        //}



        //// See also: https://en.wikipedia.org/wiki/Quartic_equation#Summary_of_Ferrari's_method
        //public static Tuple<Complex, Complex, Complex, Complex> quartic_equation(Double A, Double B, Double C, Double D, Double E)
        //{
        //    return cmath53.quartic_equation(A, B, C, D, E);
        //}





        #endregion



        #region Exponential and related functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expj/*' />
        public static Complex expj(Double x)
        {
            return new Complex(cos(x), sin(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expjpi/*' />
        public static Complex expjpi(Double x)
        {
            return new Complex(cospi(x), sinpi(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp10/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp10", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp10(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp2/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp2(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expm1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expm1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expm1(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp10m1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp10m1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp10m1(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp2m1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp2m1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp2m1(Double x);






        #endregion



        #region Logarithms and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ln", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log10/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_log10", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log10(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log2/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_log2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log2(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logbase/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logbase", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logbase(Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log1p/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ln1p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log1p(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log2p1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_log2p1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log2p1(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log10p1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_log10p1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log10p1(Double x);







        #endregion



        #region Power functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqr/*' />
        public static Double sqr(Double x)
        {
            return x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqr/*' />
        public static Double cube(Double x)
        {
            return x * x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow_si/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_intpower", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pow_si(Double x, int n);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hypot/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hypot", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hypot(Double x, Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow1p/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pow1p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pow1p(Double x, Double y);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow1pm1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pow1pm1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pow1pm1(Double x, Double y);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pow/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_power", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pow(Double x, Double y);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/powm1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_powm1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double powm1(Double x, Double y);



        #endregion



        #region Trigonometric functions, in radians

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sin/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sin", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sin(Double x);
        public static Double sin(dynamic x)
        {
            return sin(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cos/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cos", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cos(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cot/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cot", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cot(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/csc/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_csc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double csc(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sec/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sec", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sec(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinc/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinc(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tan/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_tan", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double tan(Double x);


        #endregion



        #region Trigonometric functions, in multiples of pi

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cospi/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cosPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cospi(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sincpi/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sincPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sincpi(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinpi/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinpi(Double x);

        
        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tanpi/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_tanPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double tanpi(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cscpi/*' />    
        public static Double cscpi(Double x)
        {
            return 1.0 / sinpi(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/secpi/*' />    
        public static Double secpi(Double x)
        {
            return 1.0 / cospi(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cotpi/*' />    
        public static Double cotpi(Double x)
        {
            return 1.0 / tanpi(x);
        }


        #endregion



        #region Hyperbolic functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cosh/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cosh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cosh(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coth/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_coth", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double coth(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/csch/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_csch", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double csch(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sech/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sech", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sech(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinh/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinh(Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tanh/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_tanh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double tanh(Double x);


        #endregion



        #region Inverse trigonometric functions, in radians


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acos/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccos", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acos(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acot/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccot", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acot(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acsc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccsc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acsc(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asec/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcsec", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double asec(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asin/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcsin", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double asin(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/atan2/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arctan2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double atan2(Double y, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/atan/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arctan", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double atan(Double x);


        #endregion



        #region Inverse hyperbolic functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acosh/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccosh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acosh(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acoth/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccoth", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acoth(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acsch/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccsch", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acsch(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asech/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcsech", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double asech(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asinh/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcsinh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double asinh(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/atanh/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arctanh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double atanh(Double x);



        #endregion



        #region Gamma and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma1pm1/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma1pm1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma1pm1(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lgamma/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lngamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lgamma(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rgamma/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_rgamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double rgamma(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/factorial/*' />    
        public static Double factorial(Double x)
        {
            return dreal.factorial(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/doublefactorial/*' />    
        public static Double doublefactorial(Double x)
        {
            return dreal.doublefactorial(x);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rising_factorial/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pochhammer", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double rising_factorial(Double a, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/falling_factorial/*' />    
        public static Double falling_factorial(Double x, Double y)
        {
            return dreal.falling_factorial(x, y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_ratio/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma_ratio", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_ratio(Double x, Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_delta_ratio/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma_delta_ratio", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_delta_ratio(Double x, Double d);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/beta/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_beta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double beta(Double x, Double y);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/binomial/*' />    
        public static Double binomial(Double x, Double y)
        {
            return dreal.binomial(x, y);
        }



        #endregion



        #region Miscellaneous



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lambert_w0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_LambertW", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lambert_w0(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lambert_wm1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_LambertW1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lambert_wm1(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lambert_wk/*' />
        public static Complex lambert_wk(Double x, int k)
        {
            return cmath53.lambert_wk(x, k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lambert_wk/*' />
        public static Complex lambert_wk(dynamic z1, int k)
        {
            return lambert_wk(t(z1), k);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lambert_w0_prime/*' />
        public static Double lambert_w0_prime(Double x)
        {
            Double res = 0.0;
            Lib_FReal_LambertW0Prime(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LambertW0Prime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_LambertW0Prime(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lambert_wm1_prime/*' />
        public static Double lambert_wm1_prime(Double x)
        {
            Double res = 0.0;
            Lib_FReal_LambertWm1Prime(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LambertWm1Prime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_LambertWm1Prime(ref Double res, ref Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/agm/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_agm", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double agm(Double x, Double y);




        #endregion



        #endregion





        #region Statistical distributions



        #region Distributions based on elementary functions


        // {---------------------- Arcsine distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/arcsine_pdf/*' />
        public static Double arcsine_pdf(Double a, Double b, Double x)
        {
            return dreal.dist_arcsine(a, b).pdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/arcsine_cdf/*' />
        public static Double arcsine_cdf(Double a, Double b, Double x)
        {
            return dreal.dist_arcsine(a, b).cdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/arcsine_qtf/*' />
        public static Double arcsine_qtf(Double a, Double b, Double q)
        {
            return dreal.dist_arcsine(a, b).qtf(q);
        }


        // {---------------------- Cauchy distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cauchy_pdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cauchy_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cauchy_pdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cauchy_cdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cauchy_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cauchy_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cauchy_qtf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cauchy_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cauchy_qtf(Double a, Double b, Double y);



        // {---------------------- Exponential distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exponential_pdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp_pdf", CallingConvention = CallingConvention.Cdecl)]
        private static extern Double exp_pdf(Double a, Double alpha, Double x);

        public static Double exponential_pdf(Double lambda1, Double x)
        {
            return exp_pdf(0, lambda1, x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exponential_cdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp_cdf", CallingConvention = CallingConvention.Cdecl)]
        private static extern Double exp_cdf(Double a, Double alpha, Double x);

        public static Double exponential_cdf(Double lambda1, Double x)
        {
            return exp_cdf(0, lambda1, x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exponential_qtf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp_inv", CallingConvention = CallingConvention.Cdecl)]
        private static extern Double exp_qtf(Double a, Double alpha, Double q);

        public static Double exponential_qtf(Double lambda1, Double q)
        {
            return exp_qtf(0, lambda1, q);
        }



        // {---------------------- Gumbel distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gumbel_pdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_evt1_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gumbel_pdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gumbel_cdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_evt1_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gumbel_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gumbel_qtf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_evt1_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gumbel_qtf(Double a, Double b, Double y);



        // {---------------------- Hyperexponential distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperexponential_pdf/*' />
        public static Double hyperexponential_pdf(DoubleVec Prob, DoubleVec Rate, Double x)
        {
            return dreal.dist_hyperexponential(Prob, Rate).pdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperexponential_cdf/*' />
        public static Double hyperexponential_cdf(DoubleVec Prob, DoubleVec Rate, Double x)
        {
            return dreal.dist_hyperexponential(Prob, Rate).cdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperexponential_qtf/*' />
        public static Double hyperexponential_qtf(DoubleVec Prob, DoubleVec Rate, Double q)
        {
            return dreal.dist_hyperexponential(Prob, Rate).cdf(q);
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kumaraswamy_pdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kumaraswamy_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kumaraswamy_pdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kumaraswamy_cdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kumaraswamy_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kumaraswamy_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kumaraswamy_qtf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kumaraswamy_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kumaraswamy_qtf(Double a, Double b, Double y);



        // {---------------------- Laplace distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/laplace_pdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_laplace_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double laplace_pdf(Double a, Double b, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/laplace_cdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_laplace_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double laplace_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/laplace_qtf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_laplace_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double laplace_qtf(Double a, Double b, Double y);



        // {---------------------- Logistic distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logistic_pdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logistic_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logistic_pdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logistic_cdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logistic_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logistic_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logistic_qtf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logistic_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logistic_qtf(Double a, Double b, Double y);




        // {---------------------- Pareto distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pareto_pdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pareto_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pareto_pdf(Double k, Double a, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pareto_cdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pareto_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pareto_cdf(Double k, Double a, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pareto_qtf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pareto_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pareto_qtf(Double k, Double a, Double x);



        // {---------------------- Rayleigh distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rayleigh_pdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_rayleigh_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double rayleigh_pdf(Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rayleigh_cdf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_rayleigh_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double rayleigh_cdf(Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rayleigh_qtf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_rayleigh_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double rayleigh_qtf(Double b, Double x);




        // {---------------------- Triangular distribution --------------------------}

        [DllImport(xcn.libwe64d, EntryPoint = "damath_triangular_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double triang_pdf(Double a, Double b, Double c, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/triangular_pdf/*' />
        public static Double triangular_pdf(Double a, Double b, Double c, Double x)
        {
            return triang_pdf(a, c, b, x);
        }


        [DllImport(xcn.libwe64d, EntryPoint = "damath_triangular_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double triang_cdf(Double a, Double b, Double c, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/triangular_cdf/*' />
        public static Double triangular_cdf(Double a, Double b, Double c, Double x)
        {
            return triang_cdf(a, c, b, x);
        }

        [DllImport(xcn.libwe64d, EntryPoint = "damath_triangular_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double triang_qtf(Double a, Double b, Double c, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/triangular_qtf/*' />   
        public static Double triangular_qtf(Double a, Double b, Double c, Double q)
        {
            return triang_qtf(a, c, b, q);
        }


        // {---------------------- Uniform distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/uniform_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_uniform_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double uniform_pdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/uniform_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_uniform_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double uniform_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/uniform_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_uniform_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double uniform_qtf(Double a, Double b, Double y);



        // {---------------------- Weibull distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weibull_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_weibull_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weibull_pdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weibull_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_weibull_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weibull_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weibull_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_weibull_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weibull_qtf(Double a, Double b, Double x);


        #endregion



        #region Distributions based on the error function



        // {---------------------- Levy distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/levy_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_levy_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double levy_pdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/levy_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_levy_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double levy_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/levy_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_levy_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double levy_qtf(Double a, Double b, Double y);



        // {---------------------- log-normal distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lognormal_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lognormal_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lognormal_pdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lognormal_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lognormal_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lognormal_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lognormal_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lognormal_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lognormal_qtf(Double a, Double b, Double y);



        // {---------------------- Moyal distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/moyal_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_moyal_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double moyal_pdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/moyal_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_moyal_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double moyal_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/moyal_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_moyal_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double moyal_qtf(Double a, Double b, Double y);



        // {---------------------- Normal (Gaussian) distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/normal_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_normal_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double normal_pdf(Double mu, Double sd, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/normal_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_normal_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double normal_cdf(Double mu, Double sd, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/normal_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_normal_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double normal_qtf(Double mu, Double sd, Double x);







        // {---------------------- Skew normal distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/skewnormal_pdf/*' />   
        public static Double skewnormal_pdf(Double a, Double b, Double c, Double x)
        {
            return dreal.dist_skewnormal(a, b, c).pdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/skewnormal_cdf/*' />   
        public static Double skewnormal_cdf(Double a, Double b, Double c, Double x)
        {
            return dreal.dist_skewnormal(a, b, c).cdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/skewnormal_qtf/*' />   
        public static Double skewnormal_qtf(Double a, Double b, Double c, Double q)
        {
            return dreal.dist_skewnormal(a, b, c).qtf(q);
        }




        // {---------------------- Wald or inverse Gaussian distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/wald_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wald_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double wald_pdf(Double mu, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/wald_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wald_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double wald_cdf(Double mu, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/wald_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wald_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double wald_qtf(Double mu, Double b, Double x);


        #endregion



        #region Distributions based on the incomplete gamma function



        // {---------------------- Chi distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chi_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chi_pdf(int nu, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chi_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chi_cdf(int nu, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chi_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chi_qtf(int nu, Double p);





        // {---------------------- Chi-sqr distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chi2_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi2_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chi2_pdf(int nu, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chi2_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi2_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chi2_cdf(int nu, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chi2_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi2_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chi2_qtf(int nu, Double p);





        // {---------------------- Gamma distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_pdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_qtf(Double a, Double b, Double y);



        // {---------------------- Inverse Chi2 distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/inverse_chi2_pdf/*' />   
        public static Double inverse_chi2_pdf(Double a, Double b, Double x)
        {
            return dreal.dist_inverse_chi2(a, b).pdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/inverse_chi2_cdf/*' />   
        public static Double inverse_chi2_cdf(Double a, Double b, Double x)
        {
            return dreal.dist_inverse_chi2(a, b).cdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/inverse_chi2_qtf/*' />   
        public static Double inverse_chi2_qtf(Double a, Double b, Double q)
        {
            return dreal.dist_inverse_chi2(a, b).qtf(q);
        }


        // {---------------------- Inverse gamma distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/inverse_gamma_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_invgamma_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double inverse_gamma_pdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/inverse_gamma_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_invgamma_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double inverse_gamma_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/inverse_gamma_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_invgamma_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double inverse_gamma_qtf(Double a, Double b, Double y);




        // {---------------------- Maxwell distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/maxwell_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_maxwell_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double maxwell_pdf(Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/maxwell_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_maxwell_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double maxwell_cdf(Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/maxwell_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_maxwell_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double maxwell_qtf(Double b, Double x);



        // {---------------------- Nakagami distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/nakagami_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_nakagami_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double nakagami_pdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/nakagami_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_nakagami_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double nakagami_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/nakagami_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_nakagami_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double nakagami_qtf(Double a, Double b, Double x);



        #endregion



        #region Distributions based on the incomplete beta function


        // {---------------------- beta distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/beta_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_beta_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double beta_pdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/beta_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_beta_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double beta_cdf(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/beta_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_beta_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double beta_qtf(Double a, Double b, Double y);





        // {---------------------- F-distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fisher_f_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_f_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fisher_f_pdf(int nu1, int nu2, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fisher_f_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_f_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fisher_f_cdf(int nu1, int nu2, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fisher_f_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_f_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fisher_f_qtf(int nu1, int nu2, Double x);



        // {---------------------- t-distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/student_t_pdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_t_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double student_t_pdf(int nu, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/student_t_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_t_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double student_t_cdf(int nu, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/student_t_qtf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_t_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double student_t_qtf(int nu, Double x);


        #endregion



        #region Noncentral distributions



        // {---------------------- Non-central chi2-distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chi2_nc_pdf/*' />   
        public static Double chi2_nc_pdf(Double n, Double lambda1, Double x)
        {
            return dreal.dist_chi2_nc(n, lambda1).pdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chi2_nc_cdf/*' />   
        public static Double chi2_nc_cdf(Double n, Double lambda1, Double x)
        {
            return dreal.dist_chi2_nc(n, lambda1).cdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chi2_nc_qtf/*' />   
        public static Double chi2_nc_qtf(Double n, Double lambda1, Double q)
        {
            return dreal.dist_chi2_nc(n, lambda1).qtf(q);
        }



        // {---------------------- Non-central Student t-distribution --------------------------}

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/student_t_nc_pdf/*' />   
        public static Double student_t_nc_pdf(Double n, Double delta, Double x)
        {
            return dreal.dist_student_t_nc(n, delta).pdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/student_t_nc_cdf/*' />   
        public static Double student_t_nc_cdf(Double n, Double delta, Double x)
        {
            return dreal.dist_student_t_nc(n, delta).cdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/student_t_nc_qtf/*' />   
        public static Double student_t_nc_qtf(Double n, Double delta, Double q)
        {
            return dreal.dist_student_t_nc(n, delta).qtf(q);
        }



        // {---------------------- Non-central Fisher F-distribution --------------------------}


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fisher_f_nc_pdf/*' />   
        public static Double fisher_f_nc_pdf(Double m, Double n, Double lambda1, Double x)
        {
            return dreal.dist_fisher_f_nc(m, n, lambda1).pdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fisher_f_nc_cdf/*' />   
        public static Double fisher_f_nc_cdf(Double m, Double n, Double lambda1, Double x)
        {
            return dreal.dist_fisher_f_nc(m, n, lambda1).cdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fisher_f_nc_qtf/*' />   
        public static Double fisher_f_nc_qtf(Double m, Double n, Double lambda1, Double q)
        {
            return dreal.dist_fisher_f_nc(m, n, lambda1).qtf(q);
        }



        // {---------------------- Non-central Beta-distribution --------------------------}


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/beta_nc_pdf/*' />   
        public static Double beta_nc_pdf(Double a, Double b, Double lambda1, Double x)
        {
            return dreal.dist_beta_nc(a, b, lambda1).pdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/beta_nc_cdf/*' />   
        public static Double beta_nc_cdf(Double a, Double b, Double lambda1, Double x)
        {
            return dreal.dist_beta_nc(a, b, lambda1).cdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/beta_nc_qtf/*' />   
        public static Double beta_nc_qtf(Double a, Double b, Double lambda1, Double q)
        {
            return dreal.dist_beta_nc(a, b, lambda1).qtf(q);
        }






        #endregion



        #region Miscellaneous distributions

        // {---------------------- Kolmogorov-Smirnov-distribution --------------------------}


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kolmogorov_smirnov_pdf/*' />   
        public static Double kolmogorov_smirnov_pdf(Double n, Double x)
        {
            return dreal.dist_kolmogorov_smirnov(n).pdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kolmogorov_smirnov_cdf/*' />   
        public static Double kolmogorov_smirnov_cdf(Double n, Double x)
        {
            return dreal.dist_kolmogorov_smirnov(n).cdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kolmogorov_smirnov_qtf/*' />   
        public static Double kolmogorov_smirnov_qtf(Double n, Double q)
        {
            return dreal.dist_kolmogorov_smirnov(n).qtf(q);
        }




        // {---------------------- Landau-distribution --------------------------}


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/landau_pdf/*' />   
        public static Double landau_pdf(Double mu, Double c, Double x)
        {
            return dreal.dist_landau(mu, c).pdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/landau_cdf/*' />   
        public static Double landau_cdf(Double mu, Double c, Double x)
        {
            return dreal.dist_landau(mu, c).cdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/landau_cdf/*' />   
        public static Double landau_qtf(Double mu, Double c, Double q)
        {
            return dreal.dist_landau(mu, c).qtf(q);
        }



        // {---------------------- Holtsmark-distribution --------------------------}


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/holtsmark_pdf/*' />   
        public static Double holtsmark_pdf(Double mu, Double c, Double x)
        {
            return dreal.dist_holtsmark(mu, c).pdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/holtsmark_cdf/*' />   
        public static Double holtsmark_cdf(Double mu, Double c, Double x)
        {
            return dreal.dist_holtsmark(mu, c).cdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/holtsmark_qtf/*' />   
        public static Double holtsmark_qtf(Double mu, Double c, Double q)
        {
            return dreal.dist_holtsmark(mu, c).qtf(q);
        }



        // {---------------------- Mapairy-distribution --------------------------}


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/mapairy_pdf/*' />   
        public static Double mapairy_pdf(Double mu, Double c, Double x)
        {
            return dreal.dist_mapairy(mu, c).pdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/mapairy_cdf/*' />   
        public static Double mapairy_cdf(Double mu, Double c, Double x)
        {
            return dreal.dist_mapairy(mu, c).cdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/mapairy_qtf/*' />   
        public static Double mapairy_qtf(Double mu, Double c, Double q)
        {
            return dreal.dist_mapairy(mu, c).qtf(q);
        }


        // {---------------------- Saspoint5-distribution --------------------------}


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/saspoint5_pdf/*' />   
        public static Double saspoint5_pdf(Double mu, Double c, Double x)
        {
            return dreal.dist_saspoint5(mu, c).pdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/saspoint5_cdf/*' />   
        public static Double saspoint5_cdf(Double mu, Double c, Double x)
        {
            return dreal.dist_saspoint5(mu, c).cdf(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/saspoint5_qtf/*' />   
        public static Double saspoint5_qtf(Double mu, Double c, Double q)
        {
            return dreal.dist_saspoint5(mu, c).qtf(q);
        }






        #endregion



        #region Basic lattice distributions



        // {---------------------- Bernoulli distribution --------------------------}


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bernoulli_pmf/*' />   
        public static Double bernoulli_pmf(Double p, int k)
        {
            return dreal.dist_bernoulli(p).pmf(k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bernoulli_cdf/*' />   
        public static Double bernoulli_cdf(Double p, int k)
        {
            return dreal.dist_bernoulli(p).cdf(k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bernoulli_qtf/*' />   
        public static Double bernoulli_qtf(Double p, Double q)
        {
            return dreal.dist_bernoulli(p).qtf(q);
        }




        // {---------------------- Geometric distribution --------------------------}


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/geometric_pmf/*' />   
        public static Double geometric_pmf(Double p, int k)
        {
            return dreal.dist_geometric(p).pmf(k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/geometric_cdf/*' />   
        public static Double geometric_cdf(Double p, int k)
        {
            return dreal.dist_geometric(p).cdf(k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/geometric_qtf/*' />   
        public static Double geometric_qtf(Double p, Double q)
        {
            return dreal.dist_geometric(p).qtf(q);
        }



        // {---------------------- Poisson distribution --------------------------}


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/poisson_pmf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_poisson_pmf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double poisson_pmf(Double mu, int x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/poisson_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_poisson_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double poisson_cdf(Double mu, int x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/poisson_qtf/*' />   
        public static Double poisson_qtf(Double mu, Double q)
        {
            return dreal.dist_poisson(mu).qtf(q);
        }




        // {---------------------- binomial distribution --------------------------}

        [DllImport(xcn.libwe64d, EntryPoint = "damath_binomial_pmf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_binomial_pmf(Double p, int n, int k);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/binomial_pmf/*' />   
        public static Double binomial_pmf(int n, Double p, int k)
        {
            return damath_binomial_pmf(p, dreal.lrint(n), k);
        }


        [DllImport(xcn.libwe64d, EntryPoint = "damath_binomial_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_binomial_cdf(Double p, int n, int k);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/binomial_cdf/*' />   
        public static Double binomial_cdf(int n, Double p, int k)
        {
            return damath_binomial_cdf(p, dreal.lrint(n), k);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/binomial_qtf/*' />   
        public static Double binomial_qtf(int n, Double p, Double q)
        {
            return dreal.dist_binomial(n, p).qtf(q);
        }




        // {---------------------- Negative binomial distribution --------------------------}

        [DllImport(xcn.libwe64d, EntryPoint = "damath_negbinom_pmf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_negbinom_pmf(Double p, Double r, int k);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/damath_negbinom_pmf/*' />   
        public static Double negbinomial_pmf(int r, Double p, int k)
        {
            return damath_negbinom_pmf(p, r, k);
        }


        [DllImport(xcn.libwe64d, EntryPoint = "damath_negbinom_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_negbinom_cdf(Double p, Double r, int k);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/negbinomial_cdf/*' />   
        public static Double negbinomial_cdf(int r, Double p, int k)
        {
            return damath_negbinom_cdf(p, r, k);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/negbinomial_qtf/*' />   
        public static Double negbinomial_qtf(int r, Double p, Double q)
        {
            return dreal.dist_negbinomial(r, p).qtf(q);
        }



        // {---------------------- Hypergeometric distribution --------------------------}


        [DllImport(xcn.libwe64d, EntryPoint = "damath_hypergeo_pmf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_hypergeo_pmf(int n1, int n2, int n, int k);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hypergeometric_pmf/*' />   
        public static Double hypergeometric_pmf(ulong r, ulong n, ulong N, int k)
        {
            return damath_hypergeo_pmf((int)r, (int)(N - r), (int)n, (int)k);
        }


        [DllImport(xcn.libwe64d, EntryPoint = "damath_hypergeo_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_hypergeo_cdf(int n1, int n2, int n, int k);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hypergeometric_cdf/*' />   
        public static Double hypergeometric_cdf(ulong r, ulong n, ulong N, int k)
        {
            return damath_hypergeo_cdf((int)r, (int)(N - r), (int)n, (int)k);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hypergeometric_qtf/*' />   
        public static Double hypergeometric_qtf(ulong r, ulong n, ulong N, Double q)
        {
            return dreal.dist_hypergeometric(r, n, N).qtf(q);
        }




        #endregion




        #endregion





        #region Special Functions



        #region Elliptic Functions



        #region Carlson symmetric elliptic integrals


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_rf/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ell_rf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_rf(Double x, Double y, Double z);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_rg/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ell_rg", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_rg(Double x, Double y, Double z);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_rj/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ell_rj", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_rj(Double x, Double y, Double z, Double r);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_rd/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ell_rd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_rd(Double x, Double y, Double z);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_rc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ell_rc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_rc(Double x, Double y);


        #endregion



        #region Legendre elliptic integrals (elliptic parameter m)


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/m_elliptic_k/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_M_EllipticK", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double m_elliptic_k(Double m);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/m_elliptic_e/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_M_EllipticEC", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double m_elliptic_e(Double m);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/m_elliptic_pi/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_M_EllipticPiC", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double m_elliptic_pi(Double n, Double m);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/m_elliptic_f/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_M_EllipticF", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double m_elliptic_f(Double phi, Double m);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/m_elliptic_e_inc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_M_EllipticE", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double m_elliptic_e_inc(Double phi, Double m);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/m_elliptic_pi_inc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_M_EllipticPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double m_elliptic_pi_inc(Double n, Double phi, Double m);




        #endregion



        #region Legendre elliptic integrals (elliptic modulus k), and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_k/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_comp_ellint_1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_k(Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_e/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_comp_ellint_2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_e(Double k);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_pi/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_comp_ellint_3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_pi(Double nu, Double k);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_f/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ellint_1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_f(Double phi, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_e_inc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ellint_2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_e_inc(Double phi, Double k);


        [DllImport(xcn.libwe64d, EntryPoint = "damath_ellint_3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double damath_ellint_3(Double phi, Double nu, Double k);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_pi_inc/*' />    
        public static Double elliptic_pi_inc(Double n, Double phi, Double k)
        {
            return damath_ellint_3(phi, dreal.lrint(n), k);
        }



        #endregion



        #region Jacobi elliptic functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_sn/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_sn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_sn(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_cn/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_cn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_cn(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_dn/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_dn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_dn(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_nc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_nc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_nc(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_sc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_sc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_sc(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_dc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_dc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_dc(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_nd/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_nd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_nd(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_sd/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_sd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_sd(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_cd/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_cd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_cd(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_ns/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_ns", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_ns(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_cs/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_cs", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_cs(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_ds/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_ds", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_ds(Double x, Double k);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_sncndn/*' />    
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_sncndn", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void sncndn(Double x, Double mc, ref Double sn, ref Double cn, ref Double dn);





        #endregion



        #region Jacobi theta functions


        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_theta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double jacobi_theta(int n, Double x, Double q);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_theta1/*' />    
        public static Double jacobi_theta1(Double x, Double q)
        {
            return jacobi_theta(1, x, q);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_theta2/*' />    
        public static Double jacobi_theta2(Double x, Double q)
        {
            return jacobi_theta(2, x, q);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_theta3/*' />    
        public static Double jacobi_theta3(Double x, Double q)
        {
            return jacobi_theta(3, x, q);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_theta4/*' />    
        public static Double jacobi_theta4(Double x, Double q)
        {
            return jacobi_theta(4, x, q);
        }



        #endregion



        #endregion




        #region Lerch’s transcendent and related


        #region Lerch’s transcendent: Overview

        [DllImport(xcn.libwe64d, EntryPoint = "damath_LerchPhi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double damath_LerchPhi(Double z, Double s, Double a);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lerch_phi/*' />    
        public static Double lerch_phi(Double z, Double s, Double a)
        {
            if ((Math.Abs(z) > 1.0) || (s < -1.0) || (a < 0.0)) return Double.NaN;
            return damath_LerchPhi(z, s, a);
        }


        #endregion



        #region Polygamma functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/polygamma/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_polygamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double polygamma(int n, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/trigamma/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_trigamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double trigamma(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/digamma/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_psi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double digamma(Double x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/psi/*' />    
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_psi", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double psi(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/harmonic/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_harmonic", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double harmonic(Double x);


        #endregion



        #region Polylogarithms and related functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/polylog/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_polylogr", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double polylog(Double s, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/trilog/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_trilog", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double trilog(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/trilog/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_dilog", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dilog(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/clausen_sin/*' />
        public static Double clausen_sin(Double n, Double z)
        {
            return cmath53.clausen_sin(dcplx.t(dreal.lrint(n)), dcplx.t(z)).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/clausen_sin/*' />
        public static Double clausen_sin(int n, dynamic z)
        {
            return cmath53.clausen_sin(dcplx.t(dreal.lrint(n)), dcplx.t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/clausen_cos/*' />
        public static Double clausen_cos(Double n, Double z)
        {
            return cmath53.clausen_cos(dcplx.t(dreal.lrint(n)), dcplx.t(z)).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/clausen_cos/*' />
        public static Double clausen_cos(int n, dynamic z)
        {
            return cmath53.clausen_cos(dcplx.t(dreal.lrint(n)), dcplx.t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/clausen2/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cl2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double clausen2(Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bose_einstein/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bose_einstein", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bose_einstein(Double s, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fermi_dirac/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fermi_dirac_r", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fermi_dirac(Double s, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/legendre_chi/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_LegendreChi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double legendre_chi(Double s, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/inverse_tan_integral/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ti", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double inverse_tan_integral(Double s, Double x);





        #endregion



        #region Hurwitz zeta function and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hurwitz_zeta/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zetah", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hurwitz_zeta(Double s, Double a);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/harmonic2/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_harmonic2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double harmonic2(Double x, Double r);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bernoulli/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bernoulli", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bernoulli(int n);


        [DllImport(xcn.libwe64d, EntryPoint = "damath_bernpoly", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bernpoly_(int n, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bernoulli/*' />
        public static Double bernpoly(Double x, int n)
        {
            return bernpoly_(dreal.lrint(n), x);
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/eulernum/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_euler", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double eulernum(int n);


        [DllImport(xcn.libwe64d, EntryPoint = "damath_eulerpoly", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double eulerpoly_(int n, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/eulernum/*' />
        public static Double eulerpoly(Double x, int n)
        {
            return eulerpoly_(dreal.lrint(n), x);
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logbarnes_g/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lnBarnesG", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logbarnes_g(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/barnes_g/*' />
        public static Double barnes_g(Double x)
        {
            Double res = Math.Exp(logbarnes_g(x));
            if (x < 0) res = -res;
            return res;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperfactorial/*' />
        public static Double hyperfactorial(Double z)
        {
            return Math.Exp(lgamma(z + 1) * z - logbarnes_g(z + 1));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/superfactorial/*' />
        public static Double superfactorial(Double z)
        {
            return barnes_g(z + 2);
        }


        #endregion



        #region Riemann zeta function, and related functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/zeta/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zeta(Double s);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/zetam1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zetam1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zetam1(Double s);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hardy_theta/*' />
        public static Double hardy_theta(Double z)
        {
            return cmath53.hardy_theta(dcplx.t(z)).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hardy_theta/*' />
        public static Double hardy_theta(dynamic z)
        {
            return cmath53.hardy_theta(dreal.t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hardy_z/*' />
        public static Double hardy_z(Double z)
        {
            return cmath53.hardy_z(dcplx.t(z)).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hardy_z/*' />
        public static Double hardy_z(dynamic z)
        {
            return cmath53.hardy_z(dreal.t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/riemann_xi/*' />
        public static Double riemann_xi(Double z)
        {
            return cmath53.riemann_xi(dcplx.t(z)).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/riemann_xi/*' />
        public static Double riemann_xi(dynamic z)
        {
            return cmath53.riemann_xi(dreal.t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dirichlet_eta/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_eta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dirichlet_eta(Double s);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dirichlet_etam1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_etam1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dirichlet_etam1(Double s);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dirichlet_beta/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_DirichletBeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dirichlet_beta(Double s);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dirichlet_lambda/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_DirichletLambda", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dirichlet_lambda(Double s);




        #endregion



        #endregion




        #region Hypergeometric function 0F1 and related


        #region 0F1: Overview


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_0f1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_0F1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_0f1(Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_0f1r/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_0F1r", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_0f1r(Double b, Double x);



        #endregion



        #region Bessel functions



        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_jv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bessel_jv_(Double v, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_jv/*' />
        public static  Double bessel_jv(Double v, Double x, bool scaled = false)
        {
            return bessel_jv_(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_jv/*' />
        public static Double bessel_jv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_jv(t(nu), t(x), scaled);
        }



        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_yv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bessel_yv_(Double v, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_yv/*' />
        public static Double bessel_yv(Double v, Double x, bool scaled = false)
        {
            return bessel_yv_(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_yv/*' />
        public static Double bessel_yv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_yv(t(nu), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_jv_prime/*' />
        public static Double bessel_jv_prime(Double v, Double x, bool scaled = false)
        {
            return dreal.bessel_jv_prime(v, x, scaled);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_jv_prime/*' />
        public static Double bessel_jv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_jv_prime(t(nu), t(x), scaled);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_yv_prime/*' />
        public static Double bessel_yv_prime(Double v, Double x, bool scaled = false)
        {
            return dreal.bessel_yv_prime(v, x, scaled);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_yv_prime/*' />
        public static Double bessel_yv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_yv_prime(t(nu), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_jv_zero/*' />
        public static Double bessel_jv_zero(Double v, int m)
        {
            return dreal.bessel_jv_zero(v, m);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_jv_zero/*' />
        public static Double bessel_yv_zero(Double v, int m)
        {
            return dreal.bessel_yv_zero(v, m);
        }



        #endregion



        #region Modified Bessel functions



        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_iv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bessel_iv_(Double v, Double x);

        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_ive", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bessel_ive(Double v, Double x);

        public static Double bessel_iv(Double v, Double x, bool scaled = false)
        {
            if (scaled) return bessel_ive(v, x); else return bessel_iv_(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_iv/*' />
        public static Double bessel_iv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_iv(t(nu), t(x), scaled);
        }



        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_kv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bessel_kv_(Double v, Double x);

        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_kve", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bessel_kve(Double v, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_kv/*' />
        public static Double bessel_kv(Double v, Double x, bool scaled = false)
        {
            if (scaled) return bessel_kve(v, x); else return bessel_kv_(v, x);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_iv_prime/*' />
        public static Double bessel_iv_prime(Double v, Double x, bool scaled = false)
        {
            return dreal.bessel_iv_prime(v, x, scaled);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_iv_prime/*' />
        public static Double bessel_iv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_iv_prime(t(nu), t(x), scaled);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_kv_prime/*' />
        public static Double bessel_kv_prime(Double v, Double x, bool scaled = false)
        {
            return dreal.bessel_kv_prime(v, x, scaled);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_kv_prime/*' />
        public static Double bessel_kv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_kv_prime(t(nu), t(x), scaled);
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/marcum_q/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_MarcumQ", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double marcum_q(int m, Double a, Double b);




        #endregion



        #region Spherical Bessel functions


        [DllImport(xcn.libwe64d, EntryPoint = "damath_sph_bessel_jn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double sph_bessel_jn_(int n, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_jn/*' />
        public static Double sph_bessel_jn(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan;

            if (dreal.isnan(x)) return dreal.nan;
            if (dreal.isinf(x)) return dreal.zero;
            if (dreal.isneginf(x)) return dreal.zero;
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if ((n == 0)) return dreal.one;
                    else return dreal.zero;
                }
                else
                {
                    if (n % 2 == 0) return dreal.neginf; else return dreal.nan;
                }
            }
            return sph_bessel_jn_(dreal.lrint(n), x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_jn/*' />
        public static Double sph_bessel_jn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_jn(dreal.t(n), dreal.t(x));
        }





        [DllImport(xcn.libwe64d, EntryPoint = "damath_sph_bessel_yn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double sph_bessel_yn_(int n, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_jn/*' />
        public static Double sph_bessel_yn(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan;

            if (dreal.isnan(x)) return dreal.nan;
            if (dreal.isinf(x)) return dreal.zero;
            if (dreal.isneginf(x)) return dreal.zero;
            if (x == 0.0)
            {
                if (n < 0)
                {
                    if ((n == -1)) return dreal.one;
                    else return dreal.zero;
                }
                else
                {
                    if (n % 2 != 0) return dreal.neginf; else return dreal.nan;
                }
            }
            return sph_bessel_yn_(dreal.lrint(n), x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_jn/*' />
        public static Double sph_bessel_yn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_yn(dreal.t(n), dreal.t(x), scaled);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_jn_prime/*' />
        public static Double sph_bessel_jn_prime(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan;

            if (dreal.isnan(x)) return dreal.nan;
            if (dreal.isinf(x)) return dreal.zero;
            if (dreal.isneginf(x)) return dreal.zero;
            if (x == 0.0)
            {
                if (n == 1) return 1 / dreal.t(3);
                if (n >= 0) return dreal.zero;
                else
                {
                    if (n % 2 != 0) return dreal.neginf; else return dreal.nan;
                }
            }
            return (n * sph_bessel_jn(n - 1, x, scaled) - (n + 1) * sph_bessel_jn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_jn_prime/*' />
        public static Double sph_bessel_jn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_jn_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_yn_prime/*' />
        public static Double sph_bessel_yn_prime(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan;

            if (dreal.isnan(x)) return dreal.nan;
            if (dreal.isinf(x)) return dreal.zero;
            if (dreal.isneginf(x)) return dreal.zero;
            if (x == 0.0)
            {
                if (n == -2) return -1 / dreal.t(3);
                if (n < 0) return dreal.zero;
                else
                {
                    if (n % 2 == 0) return dreal.inf; else return dreal.nan;
                }
            }
            return (n * sph_bessel_yn(n - 1, x, scaled) - (n + 1) * sph_bessel_yn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_yn_prime/*' />
        public static Double sph_bessel_yn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_yn_prime(t(n), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_jn_zero/*' />
        public static Double sph_bessel_jn_zero(int n, int m)
        {
            return bessel_jv_zero(n + 0.5, m);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_yn_zero/*' />
        public static Double sph_bessel_yn_zero(int n, int m)
        {
            return bessel_yv_zero(n + 0.5, m);
        }




        #endregion



        #region Modified Spherical Bessel functions




        [DllImport(xcn.libwe64d, EntryPoint = "damath_sph_bessel_in", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double sph_bessel_in_(int n, Double x);

        [DllImport(xcn.libwe64d, EntryPoint = "damath_sph_bessel_ine", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double sph_bessel_ine(int n, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_kn/*' />
        public static Double sph_bessel_in(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan;

            if (!dreal.isinteger(n)) return dreal.nan;
            if (dreal.isnan(x)) return dreal.nan;
            if (dreal.isinf(x)) return dreal.inf;
            if (dreal.isneginf(x)) return dreal.zero;
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if ((n == 0)) return dreal.one;
                    else return dreal.zero;
                }
                else
                {
                    if (n % 2 == 0) return dreal.neginf; else return dreal.nan;
                }
            }
            if (scaled) return sph_bessel_ine(dreal.lrint(n), x); else return sph_bessel_in_(dreal.lrint(n), x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_kn/*' />
        public static Double sph_bessel_in(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_in(dreal.t(n), dreal.t(x), scaled);
        }





        [DllImport(xcn.libwe64d, EntryPoint = "damath_sph_bessel_kn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double sph_bessel_kn_(int n, Double x);

        [DllImport(xcn.libwe64d, EntryPoint = "damath_sph_bessel_kne", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double sph_bessel_kne_(int n, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_kn/*' />
        public static Double sph_bessel_kn(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan;

            if (dreal.isnan(x)) return dreal.nan;
            if (dreal.isinf(x)) return dreal.zero;
            if (dreal.isneginf(x)) return dreal.neginf;
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if (n % 2 == 0) return dreal.nan; else return dreal.inf;
                }
                else
                {
                    if (n % 2 == 0) return dreal.inf; else return dreal.nan;
                }
            }
            if (scaled)
            {
                if (x >= 0.0) return math53.sph_bessel_kne_(dreal.lrint(n), x);
                //else return math53.sph_bessel_kn(n, x) * exp(x);
                else return -0.5 * dreal.pi * (sph_bessel_in(dreal.lrint(n), abs(x), scaled) + sph_bessel_in(-dreal.lrint(n) - 1, abs(x), scaled));
            }
            else
            {
                if (x >= 0.0) return math53.sph_bessel_kn_(dreal.lrint(n), x);
                else return -0.5 * dreal.pi * (sph_bessel_in(dreal.lrint(n), abs(x)) + sph_bessel_in(-dreal.lrint(n) - 1, abs(x)));
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_kn/*' />
        public static Double sph_bessel_kn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_kn(dreal.t(n), dreal.t(x), scaled);
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_in_prime/*' />
        public static Double sph_bessel_in_prime(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan;

            if (dreal.isnan(x)) return dreal.nan;
            if (dreal.isinf(x)) return dreal.inf;
            if (dreal.isneginf(x))
            {
                if (n % 2 == 0) return dreal.neginf; else return dreal.inf;
            }
            if (x == 0.0)
            {
                if (n == 0) return dreal.zero;
                if (n < 0)
                {
                    if (n % 2 != 0) return dreal.neginf; else return dreal.nan;
                }
            }
            return (n * sph_bessel_in(n - 1, x, scaled) + (n + 1) * sph_bessel_in(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_in_prime/*' />
        public static Double sph_bessel_in_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_in_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_kn_prime/*' />
        public static Double sph_bessel_kn_prime(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan;

            if (dreal.isnan(x)) return dreal.nan;
            if (dreal.isinf(x)) return dreal.zero;
            if (dreal.isneginf(x)) return dreal.neginf;
            if (x == 0.0)
            {
                if (((n >= 0) && (n % 2 == 0)) || ((n < 0) && (n % 2 != 0))) return dreal.neginf;
                else return dreal.nan;
            }
            return -(n * sph_bessel_kn(n - 1, x, scaled) + (n + 1) * sph_bessel_kn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_bessel_kn_prime/*' />
        public static Double sph_bessel_kn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_kn_prime(t(n), t(x), scaled);
        }





        [DllImport(xcn.libwe64d, EntryPoint = "damath_besselpoly", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double besselpoly_(int n, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/besselpoly/*' />
        public static Double besselpoly(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan;
            return besselpoly_(dreal.lrint(n), x);

        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/besselpoly/*' />
        public static Double besselpoly(dynamic n, dynamic x, bool scaled = false)
        {
            return besselpoly(t(n), t(x), scaled);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/besseltheta/*' />
        public static Double besseltheta(Double n, Double x, bool scaled = false)
        {
            return dreal.besseltheta(n, x);

        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/besseltheta/*' />
        public static Double besseltheta(dynamic n, dynamic x, bool scaled = false)
        {
            return besseltheta(t(n), t(x), scaled);
        }



        #endregion



        #region Hankel functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hankel_h1/*' />
        public static Complex hankel_h1(Double v, Double x)
        {
            return bessel_jv(v, x) + dcplx.onej * bessel_yv(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hankel_h1/*' />
        public static Complex hankel_h1(dynamic v, dynamic x)
        {
            return hankel_h1(t(v), t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hankel_h2/*' />
        public static Complex hankel_h2(Double v, Double x)
        {
            return bessel_jv(v, x) - dcplx.onej * bessel_yv(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hankel_h2/*' />
        public static Complex hankel_h2(dynamic v, dynamic x)
        {
            return hankel_h2(t(v), t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_hankel_h1/*' />
        public static Complex sph_hankel_h1(int n, Double x)
        {
            return sph_bessel_jn(dreal.lrint(n), x) + dcplx.onej * sph_bessel_yn(dreal.lrint(n), x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_hankel_h1/*' />
        public static Complex sph_hankel_h1(int n, dynamic x)
        {
            return sph_hankel_h1(dreal.lrint(n), t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_hankel_h2/*' />
        public static Complex sph_hankel_h2(int n, Double x)
        {
            return sph_bessel_jn(dreal.lrint(n), x) - dcplx.onej * sph_bessel_yn(dreal.lrint(n), x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sph_hankel_h2/*' />
        public static Complex sph_hankel_h2(int n, dynamic x)
        {
            return sph_hankel_h2(dreal.lrint(n), t(x));
        }





        #endregion



        #region Airy functions


        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_ai", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double airy_ai_(Double x);

        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_ais", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double airy_ai_scaled_(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_ai_/*' />
        public static Double airy_ai(Double x, bool scaled = false)
        {
            if (scaled) return airy_ai_scaled_(x);
            else return airy_ai_(x);
        }


        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_bi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double airy_bi_(Double x);

        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_bis", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double airy_bi_scaled_(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_bi_/*' />
        public static Double airy_bi(Double x, bool scaled = false)
        {
            if (scaled) return airy_bi_scaled_(x);
            else return airy_bi_(x);
        }




        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_aip", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double airy_ai_prime_(Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_ai_prime_/*' />
        public static Double airy_ai_prime(Double x, bool scaled = false)
        {
            double res;
            if ((scaled) && (x > 0.0))
            {
                if (x < 100.0)
                {
                    res = airy_ai_prime_(x);
                    res *= exp((dreal.t(2) / dreal.t(3)) * x * sqrt(x));
                }
                else res = cmath53.airy_ai_scaled_prime(x).Real;
            }
            else res = airy_ai_prime_(x);
            return res;
        }



        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_bip", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double airy_bi_prime_(Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_bi_prime_/*' />
        public static Double airy_bi_prime(Double x, bool scaled = false)
        {
            double res;
            if ((scaled) && (x > 0.0))
            {
                if (x < 100.0)
                {
                    res = airy_bi_prime_(x);
                    res *= exp(-abs(dreal.t(2) / dreal.t(3) * (x * sqrt(x))));
                }
                else res = cmath53.airy_bi_scaled_prime(x).Real;
            }
            else res = airy_bi_prime_(x);
            return res;
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_ai_zero/*' />
        public static Double airy_ai_zero(int n)
        {
            return dreal.airy_ai_zero(n);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_bi_zero/*' />
        public static Double airy_bi_zero(int n)
        {
            return dreal.airy_bi_zero(n);
        }




        #endregion



        #region Kelvin functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_ber/*' />
        public static Double kelvin_ber(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_ber(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_ber/*' />
        public static Double kelvin_ber(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_ber(t(v), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_bei/*' />
        public static Double kelvin_bei(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_bei(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_bei/*' />
        public static Double kelvin_bei(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_bei(t(v), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_ker/*' />
        public static Double kelvin_ker(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_ker(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_ker/*' />
        public static Double kelvin_ker(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_ker(t(v), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_kei/*' />
        public static Double kelvin_kei(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_kei(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_kei/*' />
        public static Double kelvin_kei(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_kei(t(v), t(x), scaled);
        }






        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_ber_prime/*' />
        public static Double kelvin_ber_prime(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_ber_prime(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_ber_prime/*' />
        public static Double kelvin_ber_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_ber_prime(t(v), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_bei_prime/*' />
        public static Double kelvin_bei_prime(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_bei_prime(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_bei_prime/*' />
        public static Double kelvin_bei_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_bei_prime(t(v), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_ker_prime/*' />
        public static Double kelvin_ker_prime(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_ker_prime(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_ker_prime/*' />
        public static Double kelvin_ker_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_ker_prime(t(v), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_kei_prime/*' />
        public static Double kelvin_kei_prime(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_kei_prime(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_kei_prime/*' />
        public static Double kelvin_kei_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_kei_prime(t(v), t(x), scaled);
        }




        #endregion



        #endregion




        #region Hypergeometric function 1F1 and related



        #region Hypergeometric Functions 1F1 (Kummer) and U (Tricomi)



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_1f1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_1F1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_1f1(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_1f1r/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_1F1r", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_1f1r(Double a, Double b, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_u/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_u", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_u(Double a, Double b, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/laguerre_l/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_laguerre_ass", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double laguerre_l(int n, int m, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/laguerre/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_laguerre", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double laguerre(int n, Double a, Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hermite_h/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hermite_h", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hermite_h(int n, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hermite_he/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hermite_he", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hermite_he(int n, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hermite_hv/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_HermiteH", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hermite_hv(Double v, Double x);




        #endregion



        #region Incomplete gamma functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_p/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammap", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_p(Double a, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_q/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammaq", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_q(Double a, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_lower/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammal", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_lower(Double a, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_upper/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_upper(Double a, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_tricomi/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammat", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_tricomi(Double a, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_p_prime/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammap_der", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_p_prime(Double a, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_p_inv/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammap_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_p_inv(Double a, Double p);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_q_inv/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammaq_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_q_inv(Double a, Double q);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_p_inva/*' />    
        public static Double gamma_p_inva(Double x, Double p)
        {
            return dreal.gamma_p_inva(x, p);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_q_inva/*' />    
        public static Double gamma_q_inva(Double x, Double q)
        {
            return dreal.gamma_q_inva(x, q);
        }




        #endregion



        #region Coulomb, Whittaker and parabolic cylinder function



        [DllImport(xcn.libwe64d, EntryPoint = "damath_CoulombF", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double coulomb_f_(int L, Double eta, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coulomb_f/*' />
        public static Double coulomb_f(Double L, Double eta, Double x)
        {
            if (!dreal.isinteger(L)) return dreal.nan;
            int l1 = dreal.lrint(L);
            return coulomb_f_(l1, eta, x);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coulomb_g/*' />
        public static Double coulomb_g(Double L, Double eta, Double x)
        {
            if (!dreal.isinteger(L)) return dreal.nan;
            int l1 = dreal.lrint(L);
            Double gc = 0.0;
            Double gcp = 0.0;
            int ifail = 0;
            coulomb_g_gprime(l1, eta, x, ref gc, ref gcp, ref ifail);
            return gc;
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/whittaker_m/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_WhittakerM", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double whittaker_m(Double k, Double m, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/whittaker_w/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_WhittakerW", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double whittaker_w(Double k, Double m, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pcfd/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CylinderD", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pcfd(Double v, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pcfu/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CylinderU", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pcfu(Double a, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pcfv/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CylinderV", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pcfv(Double a, Double x);




        #endregion



        #region Error function and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erf/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erf(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erfc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfc(Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erf_inv/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erf_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_erf_inv(Double x);
        public static Double erf_inv(Double x)
        {
            if (x == -1.0) return dreal.inf;
            else if (x == 1.0) return dreal.neginf;
            else return damath_erf_inv(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erfc_inv/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfc_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_erfc_inv(Double x);
        public static Double erfc_inv(Double x)
        {
            if (x == 0.0) return dreal.inf;
            else if (x == 2.0) return dreal.neginf;
            else return damath_erfc_inv(x);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ndens/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erf_z", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ndens(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ndis/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erf_p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ndis(Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erfi/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfi(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dawson/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_dawson", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dawson(Double x);





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fresnel_s/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_FresnelS", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fresnel_s(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fresnel_c/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_FresnelC", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fresnel_c(Double x);





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/owen_t/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_OwenT", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double owen_t(Double h, Double a);






        #endregion



        #region Exponential integrals and related functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp_integral_e1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_e1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp_integral_e1(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp_integral_ei/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ei", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp_integral_ei(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log_integral/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_li", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log_integral(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinh_integral/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_shi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinh_integral(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cosh_integral/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cosh_integral(Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp_integral_en/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_en", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp_integral_en(int n, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cos_integral/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ci", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cos_integral(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sin_integral/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_si", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sin_integral(Double x);



        #endregion



        #endregion




        #region Hypergeometric function pFq and related



        #region Gauss Hypergeometric Function 2F1 and related


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_2f1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_2F1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_2f1(Double a, Double b, Double c, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_2f1r/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_2F1r", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_2f1r(Double a, Double b, Double c, Double x);





        #endregion



        #region Chebyshev, Gegenbauer and Jacobi polynomials


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chebyshev_t/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chebyshev_t", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chebyshev_t(int n, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chebyshev_u/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chebyshev_u", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chebyshev_u(int n, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chebyshev_v/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chebyshev_v", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chebyshev_v(int n, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/chebyshev_w/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chebyshev_w", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chebyshev_w(int n, Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gegenbauer_c/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gegenbauer_c", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gegenbauer_c(int n, Double a, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_p/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_p(int n, Double a, Double b, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/zernike_r/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zernike_r", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zernike_r(int n, int m, Double r);




        #endregion



        #region Legendre polynomials and related


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/legendre_p/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_legendre_p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double legendre_p(int l, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/legendre_plm/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_legendre_plm", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double legendre_plm(int l, int m, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/legendre_q/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_legendre_q", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double legendre_q(int l, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/legendre_qlm/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_legendre_qlm", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double legendre_qlm(int l, int m, Double x);



        [DllImport(xcn.libwe64d, EntryPoint = "damath_spherical_harmonic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void spherical_harmonic_(int l, int m, Double theta, Double phi, ref Double yr, ref Double yi);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/spherical_y/*' />
        public static Complex spherical_y(Double n, Double m, Double theta, Double phi)
        {
            Double yr = 0.0;
            Double yi = 0.0;
            spherical_harmonic_(lrint(n), lrint(m), theta, phi, ref yr, ref yi);
            return dcplx.t(yr, yi);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/toroidal_qlm_2f1/*' />
        public static Double toroidal_qlm_2f1(int n, int m, Double x)
        {
            if (x <= 1.0) return dreal.nan;
            Double nu = n - 0.5;
            Double f1a = sqrt(pi) * gamma(nu + m + 1) * pow(x * x - 1, 1.0 * m / 2.0);
            Double f1b = pow(2.0,nu + 1) * gamma(nu + 1.5) * pow(x, nu + m + 1);
            Double f1 = f1a / f1b;
            Double f2 = hyperg_2f1((nu + m + 2) / 2.0, (nu + m + 1) / 2.0, nu + 1.5, 1 / (x * x));
            int s = -1; if (m % 2 == 0) s = 1;
            return s * f1 * f2;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/toroidal_plm_2f1/*' />
        public static Double toroidal_plm_2f1(int n, int m, Double x)
        {
            if (x < 1.0) return dreal.nan;
            Double nu = n - 0.5;
            Double f2 = hyperg_2f1r(nu + 1, -nu, 1 - m, (1 - x) / 2);
            if (x == 1.0) return f2; 
            else return pow((x + 1) / (x - 1), m / 2.0) * f2;
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/toroidal_plm/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_toroidal_plm", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double toroidal_plm(int l, int m, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/toroidal_qlm/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_toroidal_qlm", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double toroidal_qlm(int l, int m, Double x);







        #endregion



        #region Incomplete beta Function


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/beta_lower/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_beta3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double beta_lower(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ibeta/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ibeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ibeta(Double a, Double b, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ibeta_prime/*' />
        public static Double ibeta_prime(Double a, Double b, Double x)
        {
            return dreal.ibeta_prime(a, b, x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/beta_upper/*' />
        public static Double beta_upper(Double a, Double b, Double x)
        {
            return dreal.beta_upper(a, b, x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ibetac/*' />
        public static Double ibetac(Double a, Double b, Double x)
        {
            return dreal.ibetac(a, b, x);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ibeta_inv/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ibeta_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ibeta_inv(Double a, Double b, Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ibetac_inv/*' />
        public static Double ibetac_inv(Double a, Double b, Double q)
        {
            return dreal.ibetac_inv(a, b, q);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ibeta_inva/*' />
        public static Double ibeta_inva(Double b, Double x, Double p)
        {
            return dreal.ibeta_inva(b, x, p);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ibetac_inva/*' />
        public static Double ibetac_inva(Double b, Double x, Double q)
        {
            return dreal.ibetac_inva(b, x, q);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ibeta_invb/*' />
        public static Double ibeta_invb(Double a, Double x, Double p)
        {
            return dreal.ibeta_invb(a, x, p);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ibetac_invb/*' />
        public static Double ibetac_invb(Double a, Double x, Double q)
        {
            return dreal.ibetac_invb(a, x, q);
        }



        #endregion



        #region Hypergeometric Function 1F2, overview


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_1f2/*' />
        public static Double hyperg_1f2(Double a1, Double b1, Double b2, Double x)
        {
            dreal.cb1SRet1S F2 = (Double t) =>
            {
                Double res = pow(1 - t, b2 - a1 - 1) * pow(t, a1 - 1) * hyperg_0f1(b1, t * x);
                return res;
            };

            var res1 = dreal.GaussKronrod(F2, a: 0.0, b: 1, tol: 0.0);
            Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            Console.WriteLine();
            return res1.Item1 * gamma(b2) / (gamma(a1) * gamma(b2 - a1));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_1f2r/*' />
        public static Double hyperg_1f2r(Double a1, Double b1, Double b2, Double x)
        {
            return hyperg_1f2(a1, b1, b2, x) / (dreal.gamma(b1) * dreal.gamma(b2));
        }



        #endregion



        #region Scorer functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_gi/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_gi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double airy_gi(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_hi/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_hi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double airy_hi(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_gi_prime/*' />
        public static Double airy_gi_prime(Double x)
        {
            return airy_bi_prime(x) - airy_hi_prime(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/airy_hi_prime/*' />
        public static Double airy_hi_prime(Double x)
        {
            dreal.cb1SRet1S F2 = (Double t) =>
            {
                Double res = t * exp(x * t - t * t * t / 3);
                return res;
            };
            var res1 = dreal.GaussKronrod(F2, a: 0.0, b: dreal.inf, tol: 0.0);
            //Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            //Console.WriteLine();
            return res1.Item1 / dreal.pi;
        }



        #endregion



        #region Struve functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/struve_h/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_struve_h", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double struve_h(Double v, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/struve_l/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_struve_l", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double struve_l(Double v, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/struve_k/*' />
        public static  Double struve_k(Double v, Double x)
        {
            return struve_h(v,x) - bessel_yv(v,x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/struve_m/*' />
        public static Double struve_m(Double v, Double x)
        {
            return struve_l(v, x) - bessel_iv(v, x);
        }




        #endregion



        #region Anger, Weber and Lommel functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/anger_j/*' />
        public static Double anger_j(Double nu, Double x)
        {
            dreal.cb1SRet1S F2 = (Double t) =>
            {
                Double res = cos(nu * t - x * sin(t));
                return res;
            };
            var res1 = dreal.GaussKronrod(F2, a: 0.0, b: dreal.pi, tol: 0.0);
            //Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            //Console.WriteLine();
            return res1.Item1 / dreal.pi;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weber_e/*' />
        public static Double weber_e(Double nu, Double x)
        {
            dreal.cb1SRet1S F2 = (Double t) =>
            {
                Double res = sin(nu * t - x * sin(t));
                return res;
            };
            var res1 = dreal.GaussKronrod(F2, a:0.0, b: dreal.pi, tol: 0.0);
            //Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            //Console.WriteLine();
            return res1.Item1 / dreal.pi;
        }


        internal static Double lommels1int1(Double mu, Double nu, Double x)
        {
            dreal.cb1SRet1S F2 = (Double t) =>
            {
                Double res = pow(t, mu) * bessel_jv(nu, t);
                return res;
            };
            var res1 = dreal.GaussKronrod(F2, a: 0.0, b: x, tol: 0.0);
            //Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            //Console.WriteLine();
            return res1.Item1 / dreal.pi;
        }


        internal static Double lommels1int2(Double mu, Double nu, Double x)
        {
            dreal.cb1SRet1S F2 = (Double t) =>
            {
                Double res = pow(t, mu) * bessel_yv(nu, t);
                return res;
            };
            var res1 = dreal.GaussKronrod(F2, a: 0.0, b: x, tol: 0.0);
            //Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            //Console.WriteLine();
            return res1.Item1 / dreal.pi;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lommel_s1/*' />
        public static Double lommel_s1(Double mu, Double nu, Double x)
        {
            Double res1 = bessel_yv(nu, x) * lommels1int1(mu, nu, x);
            Double res2 = bessel_jv(nu, x) * lommels1int2(mu, nu, x);
            return 0.5 * dreal.pi * dreal.pi * (res1 - res2);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lommel_s2/*' />
        public static Double lommel_s2(Double mu, Double nu, Double x)
        {
            Double f1 = lommel_s1(mu, nu, x);
            Double res1 = exp2(mu - 1) * gamma((mu - nu + 1) / 2) * gamma((mu + nu + 1) / 2);
            Double res2 = sinpi((mu - nu) / 2) * bessel_jv(nu, x) - cospi((mu - nu) / 2) * bessel_yv(nu, x);
            return f1 + res1 * res2;
        }




        #endregion



        #region Generalized hypergeometric functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hyperg_2f0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_2F0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_2f0(Double a, Double b, Double x);



        #endregion




        #endregion



        #endregion









        #region Calculus DAMath


        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/squadx/*' />
        public static Tuple<Complex, Complex> squadx(Double a, Double b, Double c)
        {
            Double x1 = 0.0, x2 = 0.0, y1 = 0.0, y2 = 0.0;
            short ic = damath_squadx(a, b, c, ref x1, ref y1, ref x2, ref y2);
            return new Tuple<Complex, Complex>(new Complex(x1, y1), new Complex(x2, y2));
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_squadx", CallingConvention = CallingConvention.Cdecl)]
        internal static extern short damath_squadx(Double a, Double b, Double c, ref Double x1, ref Double y1, ref Double x2, ref Double y2);



        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/cubsolve/*' />
        public static Tuple<Double, Complex, Complex> cubsolve(Double a, Double b, Double c, Double d)
        {
            Double x = 0.0, x1 = 0.0, x2 = 0.0, y1 = 0.0, y2 = 0.0;
            damath_cubsolve(a, b, c, d, ref x, ref x1, ref y1, ref x2, ref y2);
            return new Tuple<Double, Complex, Complex>(x, new Complex(x1, y1), new Complex(x2, y2));
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cubsolve", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_cubsolve(Double a, Double b, Double c, Double d, ref Double x, ref Double x1, ref Double y1, ref Double x2, ref Double y2);



        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/localmin/*' />
        public static Tuple<Double, Double, short> localmin(cb1SRet1S f, Double a, Double b, Double eps, Double tol)
        {
            Double x = 0.0, fx = 0.0;
            short ic = 0;
            damath_localmin(f, a, b, eps, tol, ref x, ref fx, ref ic);
            return new Tuple<Double, Double, short>(x, fx, ic);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_localmin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_localmin(cb1SRet1S f, Double a, Double b, Double eps, Double tol, ref Double x, ref Double fx, ref short ic);



        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/mbrent/*' />
        public static Tuple<Double, Double, short> mbrent(cb1SRet1S f, Double a, Double b, Double tol)
        {
            Double x = 0.0, fx = 0.0;
            short ic = 0;
            damath_mbrent(f, a, b, tol, ref x, ref fx, ref ic);
            return new Tuple<Double, Double, short>(x, fx, ic);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_mbrent", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_mbrent(cb1SRet1S f, Double a, Double b, Double t, ref Double x, ref Double fx, ref short ic);



        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/zbrent/*' />
        public static Tuple<Double, short, short> zbrent(cb1SRet1S f, Double a, Double b, Double tol)
        {
            short ic = 0;
            short err = 0;
            Double Res = damath_zbrent(f, a, b, tol, ref ic, ref err);
            return new Tuple<Double, short, short>(Res, ic, err);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zbrent", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double damath_zbrent(cb1SRet1S f, Double a, Double b, Double tol, ref short ic, ref short err);




        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/zeroin/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zeroin", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zeroin(cb1SRet1S f, Double a, Double b, Double tol);








        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/quanc8/*' />
        public static Tuple<Double, Double, Double, int> quanc8(cb1SRet1S f, Double a, Double b, Double abserr, Double relerr)
        {
            Double result = 0.0, errest = 0.0, flag = 0;
            int neval = 0;
            damath_quanc8(f, a, b, abserr, relerr, ref result, ref errest, ref flag, ref neval);
            return new Tuple<Double, Double, Double, int>(result, errest, flag, neval);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_quanc8", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_quanc8(cb1SRet1S f, Double a, Double b, Double abserr, Double relerr, ref Double result, ref Double errest, ref Double flag, ref int neval);




        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/qags/*' />
        public static Tuple<Double, Double, int, short> qags(cb1SRet1S f, Double a, Double b, Double epsabs, Double epsrel, int limit = 0)
        {
            Double result = 0.0, abserr = 0.0;
            int neval = 0;
            short ier = 0;
            damath_qags(f, a, b, epsabs, epsrel, limit, ref result, ref abserr, ref neval, ref ier);
            return new Tuple<Double, Double, int, short>(result, abserr, neval, ier);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_qags", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_qags(cb1SRet1S f, Double a, Double b, Double epsabs, Double epsrel, int limit, ref Double result, ref Double abserr, ref int neval, ref short ier);




        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/qagi/*' />
        public static Tuple<Double, Double, int, short> qagi(cb1SRet1S f, Double bound, int inf, Double epsabs, Double epsrel, int limit = 0)
        {
            Double result = 0.0, abserr = 0.0;
            int neval = 0;
            short ier = 0;
            damath_qagi(f, bound, inf, epsabs, epsrel, limit, ref result, ref abserr, ref neval, ref ier);
            return new Tuple<Double, Double, int, short>(result, abserr, neval, ier);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_qagi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_qagi(cb1SRet1S f, Double bound, int inf, Double epsabs, Double epsrel, int limit, ref Double result, ref Double abserr, ref int neval, ref short ier);



        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/qawc/*' />
        public static Tuple<Double, Double, int, short> qawc(cb1SRet1S f, Double a, Double b, Double c, Double epsabs, Double epsrel, short limit = 0)
        {
            Double result = 0.0, abserr = 0.0;
            int neval = 0;
            short ier = 0;
            damath_qawc(f, a, b, c, epsabs, epsrel, limit, ref result, ref abserr, ref neval, ref ier);
            return new Tuple<Double, Double, int, short>(result, abserr, neval, ier);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_qawc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_qawc(cb1SRet1S f, Double a, Double b, Double c, Double epsabs, Double epsrel, short limit, ref Double result, ref Double abserr, ref int neval, ref short ier);




        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/intde/*' />
        public static Tuple<Double, Double, int, short> intde(cb1SRet1S f, Double a, Double b, Double eps)
        {
            Double result = 0.0, abserr = 0.0;
            int neval = 0;
            short ier = 0;
            damath_intde(f, a, b, eps, ref result, ref abserr, ref neval, ref ier);
            return new Tuple<Double, Double, int, short>(result, abserr, neval, ier);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_intde", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_intde(cb1SRet1S f, Double a, Double b, Double eps, ref Double result, ref Double abserr, ref int neval, ref short ier);


        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/intdei/*' />
        public static Tuple<Double, Double, int, short> intdei(cb1SRet1S f, Double a, Double eps)
        {
            Double result = 0.0, abserr = 0.0;
            int neval = 0;
            short ier = 0;
            damath_intdei(f, a, eps, ref result, ref abserr, ref neval, ref ier);
            return new Tuple<Double, Double, int, short>(result, abserr, neval, ier);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_intdei", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_intdei(cb1SRet1S f, Double a, Double eps, ref Double result, ref Double abserr, ref int neval, ref short ier);



        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/intdeo/*' />
        public static Tuple<Double, Double, int, short> intdeo(cb1SRet1S f, Double a, Double omega, Double eps)
        {
            Double result = 0.0, abserr = 0.0;
            int neval = 0;
            short ier = 0;
            damath_intdeo(f, a, omega, eps, ref result, ref abserr, ref neval, ref ier);
            return new Tuple<Double, Double, int, short>(result, abserr, neval, ier);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_intdeo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_intdeo(cb1SRet1S f, Double a, Double omega, Double eps, ref Double result, ref Double abserr, ref int neval, ref short ier);




        #endregion






        #region Numpy-compatible functions, real



        /// <summary>
        /// Return vec_p1
        /// </summary>
        public static void vec_p1(cb1SRet1S f, Double[] a, Double[] res)
        {
            int rows = a.GetUpperBound(0);
            for (int i = 0; i <= rows; i++)
            {
                res[i] = f(a[i]);
            }
        }



        /// <summary>
        /// Return mat_p1
        /// </summary>
        public static void mat_p1(cb1SRet1S f, Double[,] a, Double[,] res)
        {
            int rows = a.GetUpperBound(0);
            int cols = a.GetUpperBound(1);
            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    res[i, j] = f(a[i, j]);
                }
            }
        }



        /// <summary>
        /// Return vec_p2
        /// </summary>
        public static void vec_p2(cb2SDouble1S f, Double[] a, Double[] b, Double[] res)
        {
            int ra = a.GetUpperBound(0);
            int rb = b.GetUpperBound(0);
            int rows = Math.Max(ra, rb);
            Double ai = a[0];
            Double bi = b[0];
            bool rca = ra != 0;
            bool rcb = rb != 0;
            for (int i = 0; i <= rows; i++)
            {
                if (rca) ai = a[i];
                if (rcb) bi = b[i];
                res[i] = f(ai, bi);
            }
        }



        /// <summary>
        /// Return mat_p2
        /// </summary>
        public static void mat_p2(cb2SDouble1S f, Double[,] a, Double[,] b, Double[,] res)
        {
            int ra = a.GetUpperBound(0);
            int rb = b.GetUpperBound(0);
            int rows = Math.Max(ra, rb);
            int ca = a.GetUpperBound(1);
            int cb = b.GetUpperBound(1);
            int cols = Math.Max(ca, cb);
            Double aij = a[0, 0];
            Double bij = b[0, 0];
            bool rca = ra + ca != 0;
            bool rcb = rb + cb != 0;
            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    if (rca) aij = a[i, j];
                    if (rcb) bij = b[i, j];
                    res[i, j] = f(aij, bij);
                }
            }
        }




        /// <summary>
        /// Return vec_p3
        /// </summary>
        public static void vec_p3(cb3SDouble1S f, Double[] a, Double[] b, Double[] c, Double[] res)
        {
            int ra = a.GetUpperBound(0);
            int rb = b.GetUpperBound(0);
            int rc = c.GetUpperBound(0);
            int rows = Math.Max(ra, rb); rows = Math.Max(rows, rc);
            Double ai = a[0];
            Double bi = b[0];
            Double ci = c[0];
            bool rca = ra != 0;
            bool rcb = rb != 0;
            bool rcc = rc != 0;
            for (int i = 0; i <= rows; i++)
            {
                if (rca) ai = a[i];
                if (rcb) bi = b[i];
                if (rcc) ci = c[i];
                res[i] = f(ai, bi, ci);
            }
        }



        /// <summary>
        /// Return mat_p3
        /// </summary>
        public static void mat_p3(cb3SDouble1S f, Double[,] a, Double[,] b, Double[,] c, Double[,] res)
        {
            int ra = a.GetUpperBound(0);
            int rb = b.GetUpperBound(0);
            int rc = c.GetUpperBound(0);
            int rows = Math.Max(ra, rb); rows = Math.Max(rows, rc);
            int ca = a.GetUpperBound(1);
            int cb = b.GetUpperBound(1);
            int cc = c.GetUpperBound(1);
            int cols = Math.Max(ca, cb); cols = Math.Max(cols, cc);
            Double aij = a[0, 0];
            Double bij = b[0, 0];
            Double cij = c[0, 0];
            bool rca = ra + ca != 0;
            bool rcb = rb + cb != 0;
            bool rcc = rc + cc != 0;
            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    if (rca) aij = a[i, j];
                    if (rcb) bij = b[i, j];
                    if (rcc) cij = c[i, j];
                    res[i, j] = f(aij, bij, cij);
                }
            }
        }



        /// <summary>
        /// Return vec_p3
        /// </summary>
        public static void vec_p4(cb4SDouble1S f, Double[] a, Double[] b, Double[] c, Double[] d, Double[] res)
        {
            int ra = a.GetUpperBound(0);
            int rb = b.GetUpperBound(0);
            int rc = c.GetUpperBound(0);
            int rd = d.GetUpperBound(0);
            int rows = Math.Max(ra, rb); rows = Math.Max(rows, rc); rows = Math.Max(rows, rd);
            Double ai = a[0];
            Double bi = b[0];
            Double ci = c[0];
            Double di = d[0];
            bool rca = ra != 0;
            bool rcb = rb != 0;
            bool rcc = rc != 0;
            bool rcd = rd != 0;
            for (int i = 0; i <= rows; i++)
            {
                if (rca) ai = a[i];
                if (rcb) bi = b[i];
                if (rcc) ci = c[i];
                if (rcd) di = c[i];
                res[i] = f(ai, bi, ci, di);
            }
        }



        /// <summary>
        /// Return mat_p4
        /// </summary>
        public static void mat_p4(cb4SDouble1S f, Double[,] a, Double[,] b, Double[,] c, Double[,] d, Double[,] res)
        {
            int ra = a.GetUpperBound(0);
            int rb = b.GetUpperBound(0);
            int rc = c.GetUpperBound(0);
            int rd = d.GetUpperBound(0);
            int rows = Math.Max(ra, rb); rows = Math.Max(rows, rc); rows = Math.Max(rows, rd);
            int ca = a.GetUpperBound(1);
            int cb = b.GetUpperBound(1);
            int cc = c.GetUpperBound(1);
            int cd = d.GetUpperBound(1);
            int cols = Math.Max(ca, cb); cols = Math.Max(cols, cc); cols = Math.Max(cols, cd);
            Double aij = a[0, 0];
            Double bij = b[0, 0];
            Double cij = c[0, 0];
            Double dij = d[0, 0];
            bool rca = ra + ca != 0;
            bool rcb = rb + cb != 0;
            bool rcc = rc + cc != 0;
            bool rcd = rd + cd != 0;
            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    if (rca) aij = a[i, j];
                    if (rcb) bij = b[i, j];
                    if (rcc) cij = c[i, j];
                    if (rcd) dij = d[i, j];
                    res[i, j] = f(aij, bij, cij, dij);
                }
            }
        }




        #endregion







        #region Additional Functions in Double Precision



        #region Additional Elementary Functions




        #region Additional root, exponential, logarithmic and power functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sqrt1pmx/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sqrt1pmx", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sqrt1pmx(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bring/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bring", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bring(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expmx2h/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expmx2h", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expmx2h(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exprel/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exprel", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exprel(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expx2/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expx2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expx2(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logistic/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logistic", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logistic(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/einstein/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_einstein", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double einstein(int n, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log1mexp/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ln1mexp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log1mexp(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log1pexp/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ln1pexp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log1pexp(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log1pmx/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ln1pmx", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log1pmx(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logaddexp/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logaddexp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logaddexp(Double x, Double y);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logsubexp/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logsubexp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logsubexp(Double b, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logit/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logit", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logit(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/wright_omega/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_omega", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double wright_omega(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hypot3/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hypot3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hypot3(Double x, Double y, Double z);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/compound_si/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_compound", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double compound_si(Double x, int n);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/comprel/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_comprel", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double comprel(Double x, int n);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fibpoly/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fibpoly", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fibpoly(int n, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lucpoly/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lucpoly", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lucpoly(int n, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fibfun/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fibfun", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fibfun(Double v, Double x);



        #endregion




        #region Additional trigonometric functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sind/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sind", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sind(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/asind/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcsind", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double asind(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cosd/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cosd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cosd(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acosd/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccosd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acosd(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tand/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_tand", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double tand(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/atand/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arctand", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double atand(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cotd/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cotd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cotd(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acotd/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccotd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acotd(Double x);












        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acos1m/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccos1m", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acos1m(Double x);





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/hav/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hav", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hav(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/archav/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_archav", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double archav(Double x);





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/vers/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_vers", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double vers(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/covers/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_covers", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double covers(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/versint/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_versint", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double versint(Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cosint/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cosint", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cosint(int n, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinint/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinint", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinint(int n, Double x);







        #endregion



        #region Additional hyperbolic functions 



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinhc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinhc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinhc(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinhmx/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinhmx", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinhmx(Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coshm1/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_coshm1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double coshm1(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acosh1p/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccosh1p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acosh1p(Double x);





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logcosh/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lncosh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logcosh(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logsinh/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lnsinh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logsinh(Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gudermann/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gd(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/arcgd/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcgd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double arcgd(Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/langevinl/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_LangevinL", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double langevinl(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/langevinlinv/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_LangevinL_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double langevinlinv(Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kepler/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kepler", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kepler(Double M, Double e);





        #endregion





        #region Additional gamma functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/signgamma/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_signgamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double signgamma(Double x);



        [DllImport(xcn.libwe64d, EntryPoint = "damath_lngammas", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double damath_lngammas(Double x, ref int s);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lgamma_s/*' />    
        public static Tuple<Double, int> lgamma_s(Double x)
        {
            int res2 = 0;
            Double res1 = damath_lngammas(x, ref res2);
            return new Tuple<Double, int>(res1, res2);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lgamma1p/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lngamma1p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lgamma1p(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logfactorial/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lnfac", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logfactorial(int n);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logbinomial/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lnbinomial", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logbinomial(Double n, Double k);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logbeta/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lnbeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logbeta(Double x, Double y);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gamma_inv/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_inv_gamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_inv(Double y);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lgamma_inv/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lngamma_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lgamma_inv(Double y);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gammastar/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gammastar", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gammastar(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/poch1/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_poch1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double poch1(Double a, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/catalan_c/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_catalan", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double catalan_c(Double x);



        #endregion



        #endregion




        #region Additional Elliptic Functions



        #region Conversions of parameters of elliptic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_nome/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticNome", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_nome(Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_modulus/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticModulus", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_modulus(Double q);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_amplitude/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_am", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_amplitude(Double x, Double k);


        #endregion


        #region Elliptic integrals and functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_b/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_comp_ellint_b", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_b(Double k);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_d/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_comp_ellint_d", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_d(Double k);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_b_inc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ellint_b", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_b_inc(Double phi, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_d_inc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ellint_d", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_d_inc(Double phi, Double k);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/heuman_lambda/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_heuman_lambda", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double heuman_lambda(Double phi, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_zeta/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_zeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_zeta(Double phi, Double k);



        #endregion



        #region Bulirsch elliptic integrals


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cel1/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cel1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cel1(Double kc);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cel2/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cel2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cel2(Double kc, Double a, Double b);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cel/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cel", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cel(Double kc, Double p, Double a, Double b);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/el1/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_el1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double el1(Double x, Double kc);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/el2/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_el2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double el2(Double x, Double kc, Double a, Double b);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/el3/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_el3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double el3(Double x, Double kc, Double p);


        #endregion



        #region Maple style elliptic integrals


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticK/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticK", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double EllipticK(Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticKim/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticKim", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double EllipticKim(Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticCK/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticCK", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double EllipticCK(Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticEC/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticEC", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double EllipticEC(Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticECim/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticECim", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double EllipticECim(Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticCE/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticCE", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double EllipticCE(Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticPiC/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticPiC", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double EllipticPiC(Double nu, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticPiCim/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticPiCim", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double EllipticPiCim(Double nu, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticCPi/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticCPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double EllipticCPi(Double nu, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticF/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticF", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double EllipticF(Double z, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticE/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticE", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double EllipticE(Double z, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/EllipticPi/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double EllipticPi(Double z, Double nu, Double k);


        #endregion



        #region Additional Jacobi Theta Functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_theta1p/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_theta1p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_theta1p(Double q);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_theta02/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_theta2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_theta02(Double q);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_theta03/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_theta3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_theta03(Double q);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_theta04/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_theta4", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_theta04(Double q);


        #endregion



        #region Inverses of Jacobi elliptic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_arcsn/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcsn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcsn(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_arccn/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arccn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arccn(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_arcdn/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcdn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcdn(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_arccd/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arccd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arccd(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_arcsd/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcsd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcsd(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_arcnd/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcnd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcnd(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_arcdc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcdc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcdc(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_arcnc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcnc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcnc(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_arcsc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcsc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcsc(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_arcns/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcns", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcns(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_arcds/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcds", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcds(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/jacobi_arccs/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arccs", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arccs(Double x, Double k);




        #endregion



        #region Lemniscate functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/sinlemn/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sin_lemn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinlemn(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coslemn/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cos_lemn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double coslemn(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/arcsl/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccl", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double arcsl(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/arccl/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcsl", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double arccl(Double x);


        #endregion


        #endregion




        #region Additional Functions Related to Lerchs Phi



        #region Polygamma functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/pentagamma/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pentagamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pentagamma(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tetragamma/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_tetragamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double tetragamma(Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/psistar/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_psistar", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double psistar(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/psi_inv/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_psi_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double psi_inv(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bateman_g/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_BatemanG", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bateman_g(Double x);


        #endregion



        #region Polylogarithms and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/polylog_i/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_polylog", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double polylog_i(int n, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fermi_dirac_i/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fermi_dirac", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fermi_dirac_i(int n, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fermi_dirac_m05/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fermi_dirac_m05", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fermi_dirac_m05(Double s);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fermi_dirac_p05/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fermi_dirac_p05", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fermi_dirac_p05(Double s);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fermi_dirac_p15/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fermi_dirac_p15", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fermi_dirac_p15(Double s);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fermi_dirac_p25/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fermi_dirac_p25", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fermi_dirac_p25(Double s);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/tangent_int_2/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ti2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double tangent_int_2(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lobachevsky_c/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lobachevsky_c", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lobachevsky_c(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/lobachevsky_s/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lobachevsky_s", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lobachevsky_s(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/debye/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_debye", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double debye(int n, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/transport_jn/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_transport", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double transport_jn(int n, Double x);



        #endregion



        #region Riemann zeta function, and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/zeta_i/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zetaint", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zeta_i(int n);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/zeta1p/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zeta1p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zeta1p(Double s);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dirichlet_eta_i/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_etaint", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dirichlet_eta_i(int s);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/primezeta/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_primezeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double primezeta(Double s);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/riemann_r/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_RiemannR", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double riemann_r(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/riemann_r_inv/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_RiemannR_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double riemann_r_inv(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/rogers_ramanujan_cf/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_rrcf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double rogers_ramanujan_cf(Double q);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/moebius/*' />
        public static short moebius(int n)
        {
            return mpi_Moebius32(dreal.lrint(n));
        }
        [DllImport(xcn.libwe64d, EntryPoint = "mpi_Moebius32", CallingConvention = CallingConvention.Cdecl)]
        internal static extern short mpi_Moebius32(int n);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/moebius/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_euler_q", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double euler_q(Double q);



        #endregion



        #endregion




        #region Additional Functions Related to 0F1


        #region Bessel functions of integer order



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_j0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_j0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_j0(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_j1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_j1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_j1(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_jn/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_jn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_jn(int n, Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_y0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_y0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_y0(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_y1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_y1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_y1(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_yn/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_yn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_yn(int n, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_lambda/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_lambda", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_lambda(Double v, Double x);




        #endregion



        #region Modified Bessel functions of integer order


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_i0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_i0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_i0(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_i1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_i1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_i1(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_in/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_in", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_in(int n, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_k0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_k0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_k0(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_k1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_k1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_k1(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_kn/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_kn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_kn(int n, Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_i0e/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_i0e", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_i0e(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_i1e/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_i1e", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_i1e(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_k0e/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_k0e", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_k0e(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_k1e/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_k1e", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_k1e(Double x);


        #endregion



        #region Integrals of zero order Bessel functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_i0_int/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_i0_int", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_i0_int(Double u);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_j0_int/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_j0_int", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_j0_int(Double u);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_k0_int/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_k0_int", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_k0_int(Double u);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/bessel_y0_int/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_y0_int", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_y0_int(Double u);





        #endregion



        #region Kelvin0 functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_ber0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_ber", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_ber0(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_bei0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_bei", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_bei0(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_ker0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_ker", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_ker0(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_kei0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_kei", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_kei0(Double x);





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_ber_prime0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_berp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_ber_prime0(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_bei_prime0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_beip", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_bei_prime0(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_ker_prime0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_kerp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_ker_prime0(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/kelvin_kei_prime0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_keip", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_kei_prime0(Double x);




        #endregion



        #region Synchrotron functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/synchrotron_f/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_SynchF", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double synchrotron_f(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/synchrotron_g/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_SynchG", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double synchrotron_g(Double x);


        #endregion



        #endregion




        #region Additional Functions Related to 1F1


        #region Additional incomplete gamma functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expn/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expn(int n, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expreln/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expreln", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expreln(int n, Double x);




        #endregion




        #region Coulomb wave functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coulomb_cl/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CoulombCL", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double coulomb_cl(int L, Double eta);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coulomb_sl/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CoulombSL", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double coulomb_sl(int L, Double eta);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coulomb_f_fprime/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CoulombFFp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void coulomb_f_fprime(int L, Double eta, Double x, ref Double fc, ref Double fcp, ref int ifail);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/coulomb_g_gprime/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CoulombGGp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void coulomb_g_gprime(int L, Double eta, Double x, ref Double gc, ref Double gcp, ref int ifail);

        #endregion




        #region Additional error functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erfcx/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfce", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfcx(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erfh/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfh(Double x, Double h);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erf2/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erf2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erf2(Double x1, Double x2);





        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erfq/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erf_q", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfq(Double x);


        // !! MISSING: Standard normal quantile function.


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erfcx_inv/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfce_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfcx_inv(Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erfi_inv/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfi_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfi_inv(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dawson2/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_dawson2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dawson2(Double p, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/erfg/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfg(Double p, Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/expint3/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expint3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expint3(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/inerfc/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_inerfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double inerfc(int p, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fresnel_f/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_FresnelF", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fresnel_f(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/fresnel_g/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_FresnelG", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fresnel_g(Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/goodwin_staton/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gsi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double goodwin_staton(Double x);



        #endregion




        #region Additional Exponential integrals and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cin/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cin", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cin(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/cinh/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cinh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cinh(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ein/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ein", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ein(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp_integral_e1_scaled/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_e1s", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp_integral_e1_scaled(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp_integral_ei_scaled/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_eis", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp_integral_ei_scaled(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/exp_integral_ei_scaled/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_eisx2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double eisx2(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/ei_inv/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ei_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ei_inv(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/gei/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gei", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gei(Double p, Double x);




        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/eibeta/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_eibeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double eibeta(int n, Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/log_integral_inv/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_li_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log_integral_inv(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/shifted_sin_integral/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ssi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double shifted_sin_integral(Double x);



        #endregion



        #region Struve functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/struve_h0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_struve_h0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double struve_h0(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/struve_h1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_struve_h1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double struve_h1(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/struve_l0/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_struve_l0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double struve_l0(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/struve_l1/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_struve_l1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double struve_l1(Double x);



        #endregion



        #region Miscellaneous functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logseries_pmf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logseries_pmf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logseries_pmf(Double a, int k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/logseries_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logseries_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logseries_cdf(Double a, int k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/zeta_pmf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zipf_pmf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zeta_pmf(Double a, int k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/zeta_cdf/*' />   
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zipf_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zeta_cdf(Double a, int k);





        #endregion



        #endregion




        #region Additional functions for both real and complex arguments 


        #region Additional elementary complex functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acotcd/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccotcd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acotcd(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/acotc/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccotc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acotc(Double x);




        #endregion



        #region Neville theta functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/neville_theta_s/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ntheta_s", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double neville_theta_s(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/neville_theta_c/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ntheta_c", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double neville_theta_c(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/neville_theta_d/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ntheta_d", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double neville_theta_d(Double x, Double k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/neville_theta_n/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ntheta_n", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double neville_theta_n(Double x, Double k);




        #endregion




        #region Weierstrass elliptic and modular functions, real or imaginary arguments, real parameters


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_pl/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpl", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pl(Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_pe/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpe", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pe(Double x, Double e1, Double e2);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_pe_prime/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpe_der", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pe_prime(Double x, Double e1, Double e2);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_pe_im/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpe_im", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pe_im(Double y, Double e1, Double e2);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_pg/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpg", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pg(Double x, Double g2, Double g3);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_pg_prime/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpg_der", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pg_prime(Double x, Double g2, Double g3);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_pg_im/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpg_im", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pg_im(Double y, Double g2, Double g3);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_pe_inv/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpe_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pe_inv(Double y, Double e1, Double e2);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/weierstrass_pg_inv/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpg_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pg_inv(Double y, Double g2, Double g3);



        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/dedekind_eta_i/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_detai", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dedekind_eta_i(Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/elliptic_modular_lambda/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_emlambda", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_modular_lambda(Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarFunctions"]/klein_j_i/*' />    
        [DllImport(xcn.libwe64d, EntryPoint = "damath_KleinJ", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double klein_j_i(Double y);




        #endregion




        #endregion



        #endregion




    }
}





