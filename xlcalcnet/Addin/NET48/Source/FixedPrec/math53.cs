using System;
using System.Diagnostics.Eventing.Reader;
using System.Numerics;
using System.Runtime.CompilerServices;
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


    // http://www.wolfgang-ehrhardt.de/amath_functions.html#amath_func

    // https://web.archive.org/web/20190628091417/http://www.wolfgang-ehrhardt.de/index.html



    //public partial class math24

    public partial class math53
    {
        
        
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



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fma/*' />
        public static Double fma(Double x, Double y, Double z)
        {
            return x * y + z;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fma/*' />
        public static Double fma(dynamic x, dynamic y, dynamic z)
        {
            return fma(t(x), t(y), t(z));
        }



        /// <summary>
        /// Returns the maximum of two doubles; x,y \ne NAN
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_maxd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fmax(Double x, Double y);


        /// <summary>
        /// Returns the minimum of two doubles; x,y \ne NAN
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_mind", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fmin(Double x, Double y);


        // TODO ADD: DegToRad, RadToDeg, isign, fisEQ, fisNE


        #endregion



        #region Machine constants, general


        /// <summary>
        /// Returns zero()
        /// </summary>
        public static Double zero()
        {
            return 0.0d;
        }


        /// <summary>
        /// Returns zero()
        /// </summary>
        public static Double negzero()
        {
            return -0.0d;
        }



        /// <summary>
        /// Returns one()
        /// </summary>
        public static Double one()
        {
            return 1.0d;
        }


        /// <summary>
        /// Returns posinf()
        /// </summary>
        public static Double inf()
        {
            return Double.PositiveInfinity;
        }



        /// <summary>
        /// Returns neginf()
        /// </summary>
        public static Double neginf()
        {
            return Double.NegativeInfinity;
        }




        /// <summary>
        /// Returns nan()
        /// </summary>
        public static Double nan()
        {
            return Double.NaN;
        }


        #endregion



        #region Properties of numbers


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/signbit/*' />
        public static int signbit(Double x)
        {
            return Lib_FReal_Signbit(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Signbit", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Signbit(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/signbit/*' />
        public static int signbit(dynamic x)
        {
            return signbit(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isfinite/*' />
        public static bool isfinite(Double x)
        {
            return 0 != Lib_FReal_Finite(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Finite", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Finite(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isfinite/*' />
        public static bool isfinite(dynamic x)
        {
            return isfinite(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isinf/*' />
        public static bool isinf(Double x)
        {
            return 0 != (Lib_FReal_Isinf(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isinf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isinf(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isinf/*' />
        public static bool isinf(dynamic x)
        {
            return isinf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isposinf/*' />
        public static bool isposinf(Double x)
        {
            return 0 != (Lib_FReal_Isposinf(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isposinf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isposinf(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isposinf/*' />
        public static bool isposinf(dynamic x)
        {
            return isposinf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isneginf/*' />
        public static bool isneginf(Double x)
        {
            return 0 != (Lib_FReal_Isneginf(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isneginf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isneginf(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isneginf/*' />
        public static bool isneginf(dynamic x)
        {
            return isneginf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnan/*' />
        public static bool isnan(Double x)
        {
            return 0 != (Lib_FReal_Isnan(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isnan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isnan(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isnan/*' />
        public static bool isnan(dynamic x)
        {
            return isnan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/iszero/*' />
        public static bool iszero(Double x)
        {
            return 0 != (Lib_FReal_Iszero(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Iszero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Iszero(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/iszero/*' />
        public static bool iszero(dynamic x)
        {
            return iszero(t(x));
        }




        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/IsNegativeZero/*' />
        //public static bool IsNegativeZero(sboost_t x)
        //{
        //    return 0 != (Lib_FReal_Isnegzero(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isnegzero", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_FReal_Isnegzero(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/IsNegativeZero/*' />
        //public static bool IsNegativeZero(dynamic x)
        //{
        //    return IsNegativeZero(t(x));
        //}



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isone/*' />
        public static bool isone(Double x)
        {
            return 0 != (Lib_FReal_Isone(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isone(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isone/*' />
        public static bool isone(dynamic x)
        {
            return isone(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isinteger/*' />
        public static bool isinteger(Double x)
        {
            return 0 != (Lib_FReal_Isinteger(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isinteger", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isinteger(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isinteger/*' />
        public static bool isinteger(dynamic x)
        {
            return isinteger(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnumber/*' />
        public static bool isnumber(Double x)
        {
            return 0 != (Lib_FReal_Isnumber(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isnumber", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isnumber(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isnumber/*' />
        public static bool isnumber(dynamic x)
        {
            return isnumber(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isregular/*' />
        public static bool isregular(Double x)
        {
            return 0 != (Lib_FReal_Isregular(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isregular", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isregular(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isregular/*' />
        public static bool isregular(dynamic x)
        {
            return isregular(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnormal/*' />
        public static bool isnormal(Double x)
        {
            return 0 != (Lib_FReal_Isnormal(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isnormal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isnormal(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isnormal/*' />
        public static bool isnormal(dynamic x)
        {
            return isnormal(t(x));
        }



        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/IsSubnormal/*' />
        //public static bool IsSubnormal(sboost_t x)
        //{
        //    return 0 != (Lib_FReal_Issubnormal(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Issubnormal", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_FReal_Issubnormal(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/IsSubnormal/*' />
        //public static bool IsSubnormal(dynamic x)
        //{
        //    return IsSubnormal(t(x));
        //}



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isunordered/*' />
        public static bool isunordered(Double x, Double y)
        {
            return 0 != (Lib_FReal_Isunordered(ref x, ref y));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Isunordered", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_Isunordered(ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isunordered/*' />
        public static bool isunordered(dynamic x, dynamic y)
        {
            return isunordered(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/fitsint32/*' />
        public static bool fitsint32(Double x)
        {
            return 0 != (Lib_FReal_FitsInt32(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_FitsInt32", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_FitsInt32(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fitsint32/*' />
        public static bool fitsint32(dynamic x)
        {
            return fitsint32(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/fitsint64/*' />
        public static bool fitsint64(Double x)
        {
            return 0 != (Lib_FReal_FitsInt64(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_FitsInt64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_FReal_FitsInt64(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fitsint64/*' />
        public static bool fitsint64(dynamic x)
        {
            return fitsint64(t(x));
        }



        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/FitsUInt32/*' />
        //public static bool FitsUInt32(sboost_t x)
        //{
        //    return 0 != (Lib_FReal_FitsUInt32(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_FitsUInt32", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_FReal_FitsUInt32(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/FitsUInt32/*' />
        //public static bool FitsUInt32(dynamic x)
        //{
        //    return FitsUInt32(t(x));
        //}



        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/FitsUInt64/*' />
        //public static bool FitsUInt64(sboost_t x)
        //{
        //    return 0 != (Lib_FReal_FitsUInt64(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_FitsUInt64", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_FReal_FitsUInt64(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/FitsUInt64/*' />
        //public static bool FitsUInt64(dynamic x)
        //{
        //    return FitsUInt64(t(x));
        //}




        #endregion




        #region Integer Related Functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nearbyint/*' />
        public static Double nearbyint(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Nearbyint(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Nearbyint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Nearbyint(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nearbyint/*' />
        public static Double nearbyint(dynamic x)
        {
            return nearbyint(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rint/*' />
        public static Double rint(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Rint(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Rint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Rint(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rint/*' />
        public static Double rint(dynamic x)
        {
            return rint(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lrint/*' />
        public static Int32 lrint(Double x)
        {
            return Lib_FReal_Lrint(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Lrint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_FReal_Lrint(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lrint/*' />
        public static Int32 lrint(dynamic x)
        {
            return lrint(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llrint/*' />
        public static Int64 llrint(Double x)
        {
            return Lib_FReal_Llrint(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Llrint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int64 Lib_FReal_Llrint(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llrint/*' />
        public static Int64 llrint(dynamic x)
        {
            return llrint(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ceil/*' />
        public static Double ceil(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Ceil(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ceil", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Ceil(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ceil/*' />
        public static Double ceil(dynamic x)
        {
            return ceil(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/floor/*' />
        public static Double floor(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Floor(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Floor", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Floor(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/floor/*' />
        public static Double floor(dynamic x)
        {
            return floor(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/trunc/*' />
        public static Double trunc(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Trunc(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Trunc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Trunc(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/trunc/*' />
        public static Double trunc(dynamic x)
        {
            return trunc(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/round/*' />
        public static Double round(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Round(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Round", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Round(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/round/*' />
        public static Double round(dynamic x)
        {
            return round(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lround/*' />
        public static Int32 lround(Double x)
        {
            return Lib_FReal_Lround(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Lround", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_FReal_Lround(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lround/*' />
        public static Int32 lround(dynamic x)
        {
            return lround(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llround/*' />
        public static Int64 llround(Double x)
        {
            return Lib_FReal_Llround(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Llround", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int64 Lib_FReal_Llround(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llround/*' />
        public static Int64 llround(dynamic x)
        {
            return llround(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ToInt32/*' />
        public static Int32 ToInt32(Double x)
        {
            return Lib_FReal_ToInt32(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_ToInt32", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_FReal_ToInt32(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ToInt32/*' />
        public static Int32 ToInt32(dynamic x)
        {
            return ToInt32(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ToInt64/*' />
        public static Int64 ToInt64(Double x)
        {
            return Lib_FReal_ToInt64(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_ToInt64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int64 Lib_FReal_ToInt64(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ToInt64/*' />
        public static Int64 ToInt64(dynamic x)
        {
            return ToInt64(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ToUInt32/*' />
        public static UInt32 ToUInt32(Double x)
        {
            return Lib_FReal_ToUInt32(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_ToUInt32", CallingConvention = CallingConvention.Cdecl)]
        internal static extern UInt32 Lib_FReal_ToUInt32(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ToUInt32/*' />
        public static UInt32 ToUInt32(dynamic x)
        {
            return ToUInt32(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ToUInt64/*' />
        public static UInt64 ToUInt64(Double x)
        {
            return Lib_FReal_ToUInt64(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_ToUInt64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern UInt64 Lib_FReal_ToUInt64(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ToUInt64/*' />
        public static UInt64 ToUInt64(dynamic x)
        {
            return ToUInt64(t(x));
        }




        #endregion





        #region Floating point functions for real numbers


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/copysign/*' />
        public static Double copysign(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Copysign(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Copysign", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Copysign(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/copysign/*' />
        public static Double copysign(dynamic x, dynamic y)
        {
            return copysign(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/frexp/*' />
        public static Tuple<Double, Int32> frexp(Double x)
        {
            Double res = 0.0;
            Int32 e = 0;
            Lib_FReal_Frexp(ref res, ref x, ref e);
            return new Tuple<Double, int>(res, e);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Frexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Frexp(ref Double res, ref Double x, ref Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/frexp/*' />
        public static Tuple<Double, Int32> frexp(dynamic x)
        {
            return frexp(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logb/*' />
        public static Double logb(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Logb(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Logb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Logb(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logb/*' />
        public static Double logb(dynamic x)
        {
            return logb(t(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ilogb/*' />
        public static Int32 ilogb(Double x)
        {
            return Lib_FReal_Ilogb(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ilogb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_FReal_Ilogb(ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ilogb/*' />
        public static Int32 ilogb(dynamic x)
        {
            return ilogb(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ldexp/*' />
        public static Double ldexp(Double x, Int32 e)
        {
            Double res = 0.0;
            Lib_FReal_Ldexp(ref res, ref x, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ldexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Ldexp(ref Double res, ref Double x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ldexp/*' />
        public static Double ldexp(dynamic x, dynamic e)
        {
            return ldexp(t(x), ToInt32(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbn/*' />
        public static Double scalbn(Double x, Int32 e)
        {
            Double res = 0.0;
            Lib_FReal_Scalbn(ref res, ref x, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Scalbn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Scalbn(ref Double res, ref Double x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbn/*' />
        public static Double scalbn(dynamic x, dynamic e)
        {
            return scalbn(t(x), ToInt32(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbln/*' />
        public static Double scalbln(Double x, Int32 e)
        {
            Double res = 0.0;
            Lib_FReal_Scalbln(ref res, ref x, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Scalbln", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Scalbln(ref Double res, ref Double x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbln/*' />
        public static Double scalbln(dynamic x, dynamic e)
        {
            return scalbln(t(x), ToInt32(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fdim/*' />
        public static Double fdim(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Fdim(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Fdim", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Fdim(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fdim/*' />
        public static Double fdim(dynamic x, dynamic y)
        {
            return fdim(t(x), t(y));
        }


        #endregion




        #region Fraction and remainder Related Functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/modf/*' />
        public static Tuple<Double, Double> modf(Double x)
        {
            Double iptr = 0.0;
            Double frac = 0.0;
            Lib_FReal_Modf(ref frac, ref x, ref iptr);
            return new Tuple<Double, Double>(iptr, frac);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Modf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Modf(ref Double frac, ref Double x, ref Double iptr);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/modf/*' />
        public static Tuple<Double, Double> modf(dynamic x)
        {
            return modf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmod/*' />
        public static Double fmod(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Fmod(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Fmod", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Fmod(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmod/*' />
        public static Double fmod(dynamic x, dynamic y)
        {
            return fmod(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remainder/*' />
        public static Double remainder(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Remainder(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Remainder", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Remainder(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remainder/*' />
        public static Double remainder(dynamic x, dynamic y)
        {
            return remainder(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remquo/*' />
        public static Tuple<Double, Int32> remquo(Double x, Double y)
        {
            Double res = 0.0;
            Int32 e = 0;
            Lib_FReal_Remquo(ref res, ref x, ref y, ref e);
            return new Tuple<Double, int>(res, e);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Remquo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Remquo(ref Double res, ref Double x, ref Double y, ref Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remquo/*' />
        public static Tuple<Double, Int32> remquo(dynamic x, dynamic y)
        {
            return remquo(t(x), t(y));
        }

        #endregion




        #region Functions related to mantissa width and exponent range


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/epsilon/*' />
        public static Double epsilon()
        {
            Double res = 0.0;
            Lib_FReal_Epsilon(ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Epsilon", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Epsilon(ref Double res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ulp/*' />
        public static Double ulp(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Ulp(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ulp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Ulp(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ulp/*' />
        public static Double ulp(dynamic x)
        {
            return ulp(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/maxvalue/*' />
        public static Double maxvalue()
        {
            Double res = 0.0;
            Lib_FReal_Max(ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Max", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Max(ref Double res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/lowestvalue/*' />
        public static Double lowestvalue()
        {
            Double res = 0.0;
            Lib_FReal_Lowest(ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Lowest", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Lowest(ref Double res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/minposvalue/*' />
        public static Double minposvalue()
        {
            Double res = 0.0;
            Lib_FReal_Min(ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Min", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Min(ref Double res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextafter/*' />
        public static Double nextafter(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Nexttoward(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Nexttoward", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Nexttoward(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextafter/*' />
        public static Double nextafter(dynamic x, dynamic y)
        {
            return nextafter(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextabove/*' />
        public static Double nextabove(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Nextabove(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Nextabove", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Nextabove(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextabove/*' />
        public static Double nextabove(dynamic x)
        {
            return nextabove(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextbelow/*' />
        public static Double nextbelow(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Nextbelow(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Nextbelow", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Nextbelow(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextbelow/*' />
        public static Double nextbelow(dynamic x)
        {
            return nextbelow(t(x));
        }


        #endregion




        #region Mathematical Constants


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/degree/*' />
        public static Double degree()
        {
            return 0.017453292519943295;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phi/*' />
        public static Double phi()
        {
            return 1.6180339887498949;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ln2/*' />
        public static Double ln2()
        {
            return 0.69314718055994529;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ln10/*' />
        public static Double ln10()
        {
            return 2.3025850929940459;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pi/*' />
        public static Double pi()
        {
            return 3.14159265358979;
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/e/*' />
        public static Double e()
        {
            return 2.718281828459045;
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/egamma/*' />
        public static Double egamma()
        {
            return 0.57721566490153287;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/apery/*' />
        public static Double apery()
        {
            return 1.2020569031595942;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/catalan/*' />
        public static Double catalan()
        {
            return 0.915965594177219;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/glaisher/*' />
        public static Double glaisher()
        {
            return 1.2824271291006226;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/khinchin/*' />
        public static Double khinchin()
        {
            return 2.6854520010653062;
        }


        #endregion




        #endregion







        #region Elementary scalar functions


        #region Complex components


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Double abs(Double x)
        {
            return Math.Abs(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Double abs(dynamic x)
        {
            return abs(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Double fabs(Double x)
        {
            return Math.Abs(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Double fabs(dynamic x)
        {
            return fabs(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static Double sign(Double x)
        {
            return Math.Sign(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static Double sign(dynamic x)
        {
            return sign(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Double real(Double x)
        {
            return +x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Double real(dynamic x)
        {
            return real(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Double imag(Double x)
        {
            return 0.0;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Double imag(dynamic x)
        {
            return 0.0;
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Double phase(Double x)
        {
            if (x >= 0.0) return 0.0;
            else return pi();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Double phase(dynamic x)
        {
            return phase(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static Double conj(Double x)
        {
            return +x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static Double conj(dynamic x)
        {
            return conj(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Double, Double> polar(Double x)
        {
            return new Tuple<Double, Double>(abs(x), phase(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Double, Double> polar(dynamic x)
        {
            return polar(dreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rect/*' />
        public static Complex rect(Double r, Double phi)
        {
            return r * expj(phi);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rect/*' />
        public static Complex rect(dynamic r, dynamic phi)
        {
            return rect(dreal.t(r), dreal.t(phi));
        }







        #endregion




        #region Roots and quadratic, cubic, and quartic equations

        /// <summary>
        /// Returns the sqr root of x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sqrt", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sqrt(Double x);


        /// <summary>
        /// Returns the inverse sqr root of x
        /// </summary>
        public static Double rsqrt(Double x)
        {
            return 1.0 / sqrt(x);
        }



        /// <summary>
        /// Returns sqrt(1+x)-1, accurate even for x near 0, x>=-1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sqrt1pm1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sqrt1pm1(Double x);


        /// <summary>
        /// Returns sqrt(1+x^2)-x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sqrt1pmx", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sqrt1pmx(Double x);


        /// <summary>
        /// Returns the cube root of x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cbrt", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cbrt(Double x);


        /// <summary>
        /// Returns the cube root of x, like surd
        /// </summary>
        public static Double cuberoot(Double x)
        {
            return cbrt(x);
        }



        /// <summary>
        /// Returns the nth root of x; n \ne 0, x >= 0 if n is even
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_nroot", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double nroot(Double x, int n);


        /// <summary>
        /// Returns the nth root of x; n \ne 0, x >= 0 if n is even
        /// </summary>
        public static Double surd(Double x, int n)
        {
            return nroot(x, dreal.lrint(n));
        }
        public static Double root_si(Double x, int n)
        {
            return nroot(x, dreal.lrint(n));
        }


        /// <summary>
        /// Returns the nth root of x; n \ne 0, x >= 0 if n is even
        /// </summary>
        public static Double unitroots(Double x, int n)
        {
            return nroot(x, dreal.lrint(n));
        }


        // See also: Press, 3rd edition, page 227
        public static Tuple<Complex, Complex> quadratic_equation(Double a, Double b, Double c)
        {
            return cmath53.quadratic_equation(a, b, c);
        }


        // See also: Press, 3rd edition, page 228
        public static Tuple<Complex, Complex, Complex> cubic_equation_monic(Double a, Double b, Double c)
        {
            return cmath53.cubic_equation_monic(a, b, c);
        }


        public static Tuple<Complex, Complex, Complex> cubic_equation(Double A, Double B, Double C, Double D)
        {
            return cmath53.cubic_equation_monic(B / A, C / A, D / A);
        }



        // See also: https://en.wikipedia.org/wiki/Quartic_equation#Summary_of_Ferrari's_method
        public static Tuple<Complex, Complex, Complex, Complex> quartic_equation(Double A, Double B, Double C, Double D, Double E)
        {
            return cmath53.quartic_equation(A, B, C, D, E);
        }




        /// <summary>
        /// Returns the bring radical b := BR(x) with b^5 + b + x = 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bring", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bring(Double x);




        #endregion





        #region Exponential and related functions

        /// <summary>
        /// Accurate exp, result good to extended precision
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp(Double x);


        /// <summary>
        /// Returns z = exp(i*x) = cos(x) + i*sin(x)
        /// </summary>
        public static Complex expj(Double x)
        {
            return new Complex(cos(x), sin(x));
        }



        /// <summary>
        /// Returns z = exp(i*x*pi) = cospi(x) + i*sinpi(x)
        /// </summary>
        public static Complex expjpi(Double x)
        {
            return new Complex(cospi(x), sinpi(x));
        }



        /// <summary>
        /// Returns 10^x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp10", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp10(Double x);


        /// <summary>
        /// Returns 2^x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp2(Double x);


        /// <summary>
        /// Returns exp(x)-1, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expm1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expm1(Double x);


        /// <summary>
        /// Returns 10^x - 1; special code for small x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp10m1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp10m1(Double x);


        /// <summary>
        /// Returns 2^x-1, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp2m1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp2m1(Double x);



        /// <summary>
        /// Returns exp(-0.5*x^2) with damped error amplification
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expmx2h", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expmx2h(Double x);


        /// <summary>
        /// Returns exprel(x) = (exp(x) - 1)/x, 1 for x=0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exprel", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exprel(Double x);


        /// <summary>
        /// Returns exp(x*|x|) with damped error amplification
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expx2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expx2(Double x);



        /// <summary>
        /// Returns logistic(x) = 1/(1+exp(-x))
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logistic", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logistic(Double x);




        /// <summary>
        /// Returns the einstein function E_n, n=1..4, x > 0 for n=3,4
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_einstein", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double einstein(int n, Double x);


        /// <summary>
        /// Returns the limiting form for the cumulative Kolmogorov distribution function
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kolmogorov_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kolmogorovcdf(Double x);


        /// <summary>
        /// Returns the functional inverse of the Kolmogorov distribution
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kolmogorov_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kolmogorovinv(Double y);




        #endregion




        #region Logarithms and related functions


        /// <summary>
        /// Returns ln(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ln", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log(Double x);



        /// <summary>
        /// Returns base 10 logarithm of x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_log10", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log10(Double x);


        /// <summary>
        /// Returns base 2 logarithm of x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_log2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log2(Double x);


        /// <summary>
        /// Returns base b logarithm of x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logbase", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logbase(Double b, Double x);


        /// <summary>
        /// Returns ln(1+x), accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ln1p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log1p(Double x);



        /// <summary>
        /// Returns log2(1+x), accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_log2p1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log2p1(Double x);


        /// <summary>
        /// Returns log10(1+x), accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_log10p1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log10p1(Double x);


        /// <summary>
        /// Returns ln(1-exp(x)), x \lt 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ln1mexp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log1mexp(Double x);


        /// <summary>
        /// Accurately compute ln(1+exp(x)) without overflow
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ln1pexp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log1pexp(Double x);


        /// <summary>
        /// Returns ln(1+x)-x, accurate even for -0.5 \le x \le 0.5
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ln1pmx", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log1pmx(Double x);


        /// <summary>
        /// Accurately compute ln[exp(x) + exp(y)]
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logaddexp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logaddexp(Double x, Double y);


        /// <summary>
        /// Accurately compute ln[exp(x) - exp(y)], x > y
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logsubexp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logsubexp(Double b, Double x);


        /// <summary>
        /// Returns logit(x) = ln(x/(1.0-x)), accurate near x=0.5
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logit", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logit(Double x);


        /// <summary>
        /// Returns the Lambert W function W_(principal branch), x &#8805; -1/e
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_LambertW", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lambert_w0(Double x);

        // from Boost: first derivative of W0

        /// <summary>
        /// Returns the Lambert W function W_(-1 branch), -1/e &#8804; x &lt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_LambertW1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lambert_wm1(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lambert_wk/*' />
        public static Complex lambert_wk(Double x, int k)
        {
            return cmath53.lambert_wk(x, k);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lambert_wk/*' />
        public static Complex lambert_wk(dynamic z1, int k)
        {
            return lambert_wk(t(z1), k);
        }




        /// <summary>
        /// Returns lambert_w0_prime(Double x)
        /// </summary>
        public static Double lambert_w0_prime(Double x)
        {
            Double res = 0.0;
            Lib_FReal_LambertW0Prime(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LambertW0Prime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_LambertW0Prime(ref Double res, ref Double x);


        /// <summary>
        /// Returns lambert_wm1_prime(Double x)
        /// </summary>
        public static Double lambert_wm1_prime(Double x)
        {
            Double res = 0.0;
            Lib_FReal_LambertWm1Prime(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LambertWm1Prime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_LambertWm1Prime(ref Double res, ref Double x);






        /// <summary>
        /// Returns the Wright omega function, i.e. the solution w of w + ln(w) = x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_omega", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double wright_omega(Double x);



        #endregion



        #region Power functions

        public static Double sqr(Double x)
        {
            return x * x;
        }

        public static Double cube(Double x)
        {
            return x * x * x;
        }


        /// <summary>
        /// Returns x^n; via binary exponentiation (no overflow detection)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_intpower", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pow_si(Double x, int n);


        /// <summary>
        /// Returns (1+x)^n; accurate version of Delphi/VP internal function
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_compound", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double compound_si(Double x, int n);


        /// <summary>
        /// Returns ((1+x)^n-1)/x; accurate version of Delphi/VP internal function
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_comprel", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double comprel(Double x, int n);


        /// <summary>
        /// Returns sqrt(x*x + y*y)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hypot", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hypot(Double x, Double y);


        /// <summary>
        /// Returns sqrt(x*x + y*y + z*z)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hypot3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hypot3(Double x, Double y, Double z);


        /// <summary>
        /// Returns (1+x)^y, x > -1, with dbl2 arithmetic for critical values
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pow1p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pow1p(Double x, Double y);




        /// <summary>
        /// Returns (1+x)^y - 1; special code for small x,y
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pow1pm1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pow1pm1(Double x, Double y);




        /// <summary>
        /// Returns x^y; if frac(y) \ne 0 then x must be \gt 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_power", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pow(Double x, Double y);




        /// <summary>
        /// Returns x^y; if frac(y) \ne 0 then x must be \gt 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_powm1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double powm1(Double x, Double y);



        /// <summary>
        /// Returns the Fibonacci polynomial F_n(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fibpoly", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fibpoly(int n, Double x);


        /// <summary>
        /// Returns the Lucas polynomial L_n(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lucpoly", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lucpoly(int n, Double x);


        /// <summary>
        /// Returns the general Fibonacci function F_v(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fibfun", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fibfun(Double v, Double x);


        #endregion



        #region Trigonometric functions, in radians

        /// <summary>
        /// Accurate version of circular cosine, uses system.cos for |x| \le Pi/4
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cos", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cos(Double x);

        /// <summary>
        /// Returns the circular cotangent of x, x mod Pi \ne 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cot", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cot(Double x);

        /// <summary>
        /// Returns the coversine covers(x) = 1 - sin(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_covers", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double covers(Double x);

        /// <summary>
        /// Returns the circular cosecant of x, x mod Pi \ne 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_csc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double csc(Double x);

        /// <summary>
        /// Returns the haversine hav(x) = (1 - cos(x))/2
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hav", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hav(Double x);

        /// <summary>
        /// Returns the circular secant of x, x mod Pi \ne Pi/2
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sec", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sec(Double x);

        /// <summary>
        /// Accurate version of circular sine, uses system.sin for |x| \lt Pi/4
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sin", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sin(Double x);
        public static Double sin(dynamic x)
        {
            return sin(t(x));
        }


        /// <summary>
        /// Returns the cardinal sine sinc(x) = sin(x)/x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinc(Double x);


        /// <summary>
        /// Returns the circular tangent of x, x mod Pi \ne Pi/2
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_tan", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double tan(Double x);


        /// <summary>
        /// Returns the versine vers(x) = 1 - cos(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_vers", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double vers(Double x);


        /// <summary>
        /// Returns versint(x) = integral(vers(t),t=0..x) = x - sin(x), accurate near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_versint", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double versint(Double x);


        /// <summary>
        /// Returns cosint(n, x) = integral(cos(t)^n, t=0..x), n &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cosint", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cosint(int n, Double x);



        /// <summary>
        /// Returns sinint(n, x) = integral(sin(t)^n, t=0..x), n &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinint", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinint(int n, Double x);


        /// <summary>
        /// Solves kepler's equation, result x is the eccentric anomaly from the mean anomaly M and the
        /// <para> eccentricity e &#8805; 0; x - e*sin(x) = M, x + x^3/3 = M, or e*sinh(x) - x = M for e &lt; 1, =1, &gt; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kepler", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kepler(Double M, Double e);


        #endregion



        #region Trigonometric functions, in multiples of pi

        /// <summary>
        /// Returns cos(Pi*x), result will be 1 for abs(x) \ge 2^64
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cosPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cospi(Double x);


        /// <summary>
        /// Returns the normalised cardinal sine sincPi(x) = sin(Pi*x)/(Pi*x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sincPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sincpi(Double x);


        /// <summary>
        /// Returns sin(Pi*x), result will be 0 for abs(x) >= 2^64
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinpi(Double x);


        /// <summary>
        /// Returns tan(Pi*x), result will be 0 for abs(x) >= 2^52
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_tanPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double tanpi(Double x);

        public static Double cscpi(Double x)
        {
            return 1.0 / sinpi(x);
        }

        public static Double secpi(Double x)
        {
            return 1.0 / cospi(x);
        }

        public static Double cotpi(Double x)
        {
            return 1.0 / tanpi(x);
        }


        #endregion



        #region Trigonometric functions, in degrees

        /// <summary>
        /// Returns cos(x), x in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cosd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cosd(Double x);

        /// <summary>
        /// Returns cot(x), x in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cotd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double Cotd(Double x);


        /// <summary>
        /// Returns sin(x), x in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sind", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sind(Double x);

        /// <summary>
        /// Returns tan(x), x in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_tand", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double tand(Double x);


        #endregion



        #region Hyperbolic functions

        /// <summary>
        /// Returns the hyperbolic cosine of x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cosh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cosh(Double x);


        /// <summary>
        /// Returns cosh(x)-1, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_coshm1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double coshm1(Double x);

        /// <summary>
        /// Returns the hyperbolic cotangent of x, x \ne 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_coth", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double coth(Double x);

        /// <summary>
        /// Returns the hyperbolic cosecant of x, x \ne 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_csch", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double csch(Double x);


        /// <summary>
        /// Returns the hyperbolic secant of x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sech", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sech(Double x);


        /// <summary>
        /// Returns the hyperbolic sine of x, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinh(Double x);


        /// <summary>
        /// Returns sinh(x)/x, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinhc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinhc(Double x);

        /// <summary>
        /// Returns sinh(x)-x, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sinhmx", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinhmx(Double x);

        /// <summary>
        /// Returns the hyperbolic tangent of x, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_tanh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double tanh(Double x);


        /// <summary>
        /// Returns the Langevin function L(x) = coth(x) - 1/x, L(0) = 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_LangevinL", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double langevinl(Double x);


        /// <summary>
        /// Returns ln(cosh(x)), accurate for x ~ 0 and without overflow for large x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lncosh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logcosh(Double x);


        /// <summary>
        /// Returns ln(sinh(x)), x > 0, accurate for x ~ 0 and without overflow for large x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lnsinh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logsinh(Double x);


        #endregion



        #region Inverse trigonometric functions, in radians


        /// <summary>
        /// Returns the inverse circular cosine of x, |x| \le 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccos", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acos(Double x);


        /// <summary>
        /// Returns arccos(1-x), 0 \le x \le 2, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccos1m", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acos1m(Double x);

        /// <summary>
        /// Returns the sign symmetric inverse circular cotangent; arccot(x) = arctan(1/x), x \ne 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccot", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acot(Double x);

        /// <summary>
        /// Returns the continuous inverse circular cotangent; arccotc(x) = Pi/2 - arctan(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccotc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acotc(Double x);

        /// <summary>
        /// Returns the inverse cosecant of x, |x| >= 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccsc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acsc(Double x);

        /// <summary>
        /// Returns the inverse secant of x, |x| \ge 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcsec", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double asec(Double x);

        /// <summary>
        /// Returns the inverse circular sine of x, |x| \le 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcsin", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double asin(Double x);

        /// <summary>
        /// Returns arctan(y/x); result in [-Pi..Pi] with correct quadrant
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arctan2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_arctan2(Double x, Double y);

        public static Double atan2(Double x, Double y)
        {
            return damath_arctan2(y, x);
        }


        /// <summary>
        /// Returns the inverse circular tangent of x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arctan", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double atan(Double x);

        /// <summary>
        /// Returns the Gudermannian function gd(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gudermann(Double x);


        #endregion



        #region Inverse trigonometric functions, in degrees

        /// <summary>
        /// Returns the inverse circular cosine of x, |x| \le 1, result in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccosd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acosd(Double x);

        /// <summary>
        /// Returns the continuous inverse circular cotangent; arccotcd(x) = 90 - arctand(x), result in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccotcd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acotcd(Double x);


        /// <summary>
        /// Returns the sign symmetric inverse circular cotangent, arccotd(x) = arctand(1/x), x \ne 0, result in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccotd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acotd(Double x);

        /// <summary>
        /// Returns the inverse circular sine of x, |x| \le 1, result in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcsind", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double asind(Double x);

        /// <summary>
        /// Returns the inverse circular tangent of x, result in degrees
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arctand", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double atand(Double x);


        #endregion



        #region Inverse hyperbolic functions

        /// <summary>
        /// Returns the inverse hyperbolic cosine, x \ge 1. For x near 1 use arccosh1p(x-1) to reduce cancellation errors!
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccosh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acosh(Double x);

        /// <summary>
        /// Returns arccosh(1+x), x \ge 0, accurate even for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccosh1p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acosh1p(Double x);

        /// <summary>
        /// Returns the inverse hyperbolic cotangent of x, |x| > 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccoth", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acoth(Double x);

        /// <summary>
        /// Returns the inverse hyperbolic cosecant of x, x \ne 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccsch", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acsch(Double x);

        /// <summary>
        /// Returns the inverse Gudermannian function arcgd(x), |x| \le Pi/2
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcgd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double arcgudermann(Double x);

        /// <summary>
        /// Returns the inverse haversine archav(x), 0 \ne x \ne 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_archav", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double archav(Double x);

        /// <summary>
        /// Returns the inverse hyperbolic secant of x, 0 \lt x \le 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcsech", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double asech(Double x);

        /// <summary>
        /// Returns the inverse hyperbolic sine of x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcsinh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double asinh(Double x);

        /// <summary>
        /// Returns the inverse hyperbolic tangent of x, |x| \lt 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arctanh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double atanh(Double x);


        /// <summary>
        /// Returns the functional inverse of the Langevin function, |x| &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_LangevinL_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double langevinlinv(Double x);



        #endregion



        #endregion







        #region Special real functions




        #region Error functions for real arguments

        /// <summary>
        /// Returns the error function erf(x) = 2/sqrt(Pi)*integral((exp(-t^2), t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erf(Double x);


        /// <summary>
        /// Returns the complementary error function erfc(x) = 1-erf(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfc(Double x);



        /// <summary>
        /// Returns the exponentially scaled complementary error function erfcx(x) = exp(x^2)*erfc(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfce", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfcx(Double x);




        /// <summary>
        /// Returns the imaginary error function erfi(x) = erf(ix)/i
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfi(Double x);



        /// <summary>
        /// Accurately compute erf(x+h) - erf(x-h)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfh(Double x, Double h);




        /// <summary>
        /// Accurately compute erf(x2) - erf(x1)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erf2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erf2(Double x1, Double x2);




        /// <summary>
        /// Returns the probability function erf_z = exp(-x^2/2)/sqrt(2*Pi)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erf_z", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ndens(Double x);




        /// <summary>
        /// Returns the probability function erf_p = integral(exp(-t^2/2)/sqrt(2*Pi), t=-Inf..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erf_p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ndis(Double x);


        /// <summary>
        /// Returns the probability function erf_q = integral(exp(-t^2/2)/sqrt(2*Pi), t=x..Inf)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erf_q", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfq(Double x);


        // Missing: ndisx


        /// <summary>
        /// Returns the inverse function of erf, erf(erf_inv(x)) = x, -1 &lt; x &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erf_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_erf_inv(Double x);
        public static Double erf_inv(Double x)
        {
            if (x == -1.0) return dreal.inf();
            else if (x == 1.0) return dreal.neginf();
            else return damath_erf_inv(x);
        }


        /// <summary>
        /// Returns the inverse function of erfc, erfc(erfc_inv(x)) = x, 0 &lt; x &lt; 2
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfc_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_erfc_inv(Double x);
        public static Double erfc_inv(Double x)
        {
            if (x == 0.0) return dreal.inf();
            else if (x == 2.0) return dreal.neginf();
            else return damath_erfc_inv(x);
        }

        /// <summary>
        /// Returns the functional inverse of erfcx, erfcx(erfcx_inv(x)) = x, x &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfce_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfcx_inv(Double x);




        /// <summary>
        /// Returns the functional inverse of the imaginary error function erfi, i.e. erfi(erfi−1(y)) = y,
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfi_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfi_inv(Double x);





        #endregion



        #region Gamma and related functions for real arguments and parameters


        ///// <summary>
        ///// Returns gamma(x), x &#8804; MAXGAM; invalid if x is a non-positive integer
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_gamma", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double gamma(Double x);



        ///// <summary>
        ///// Returns the reciprocal gamma function rgamma = 1/gamma(x)
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_rgamma", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double rgamma(Double x);




        ///// <summary>
        ///// Returns ln(|gamma(x)|), |x| &#8804; MAXLGM, invalid if x is a non-positive integer function signgamma can be used if the sign of gamma(x) is needed.
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_lngamma", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double lgamma(Double x);



        /// <summary>
        /// Returns ln(|gamma(1+x)|) with increased accuracy for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lngamma1p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lgamma1p(Double x);



        /// <summary>
        /// Returns sign(gamma(x)), useless for 0 or negative integer
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_signgamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double signgamma(Double x);




        [DllImport(xcn.libwe64d, EntryPoint = "damath_lngammas", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double damath_lngammas(Double x, ref int s);


        /// <summary>
        /// Returns ln(|gamma(x)|), |x| &#8804; MAXLGM, s=-1,1 is the sign of gamma
        /// </summary>
        public static Tuple<Double, int> lgamma_s(Double x)
        {
            int res2 = 0;
            Double res1 = damath_lngammas(x, ref res2);
            return new Tuple<Double, int>(res1, res2);
        }


        /// <summary>
        /// Returns gamma(1+x)-1 with increased accuracy for x near 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma1pm1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma1pm1(Double x);



        /// <summary>
        /// Returns Temme's gammastar(x) = gamma(x)/(sqrt(2*Pi)*x^(x-0.5)*exp(-x)), x>0. For large x the asymptotic expansion is gammastar(x) = 1 + 1/12x + O(1/x^2)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gammastar", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gammastar(Double x);









        /// <summary>
        /// Returns factorial(Double x)
        /// </summary>
        public static Double factorial(Double x)
        {
            return dreal.factorial(x);
        }



        ///// <summary>
        ///// Returns the factorial n!, n &lt; MAXGAM-1; INF if n &lt; 0
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_fac", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double factorial(int n);


        /// <summary>
        /// Returns ln(n!), INF if n &lt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lnfac", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logfactorial(int n);


        /// <summary>
        /// Returns doublefactorial(Double x)
        /// </summary>
        public static Double doublefactorial(Double x)
        {
            return dreal.doublefactorial(x);
        }



        ///// <summary>
        ///// Returns the Double factorial n!!, n &#8804; MAXDFAC; INF for even n &lt; 0
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_dfac", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double doublefactorial(int n);








        /// <summary>
        /// Returns gamma(x)/gamma(y)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma_ratio", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_ratio(Double x, Double y);


        /// <summary>
        /// Returns gamma(x)/gamma(x+d), accurate even for |d| &lt;&lt; |x|
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma_delta_ratio", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_delta_ratio(Double x, Double d);



        /// <summary>
        /// Returns the rising factorial or Pochhammer symbol gamma(a+x)/gamma(a)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pochhammer", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double rising_factorial(Double a, Double x);



        // Missing: falling factorial


        /// <summary>
        /// Returns falling_factorial(Double x, Double y)
        /// </summary>
        public static Double falling_factorial(Double x, Double y)
        {
            return dreal.falling_factorial(x, y);
        }



        /// <summary>
        /// Returns the Catalan function C(x) = binomial(2x,x)/(x+1)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_catalan", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double catalan_c(Double x);



        /// <summary>
        /// Returns binomial(Double x, Double y)
        /// </summary>
        public static Double binomial(Double x, Double y)
        {
            return dreal.binomial(x, y);
        }




        /// <summary>
        /// Returns the binomial coefficient 'n choose k'
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_binomial", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double binomial(int n, int k);


        /// <summary>
        /// Returns ln(binomial(n,k)), n >= k >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lnbinomial", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logbinomial(Double n, Double k);



        // Missing: Multinomial




        /// <summary>
        /// Returns the inverse of gamma: return x with gamma(x) = y, y &#8805; 0.8857421875
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_inv_gamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_inv(Double y);


        /// <summary>
        /// Returns Inverse of lngamma: return x with lngamma(x) = y, y &#8805; -0.12142, x &gt; 1.4616
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lngamma_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lgamma_inv(Double y);





        /// <summary>
        /// Returns (pochhammer(a,x)-1)/x, psi(a) if x=0; accurate even for small |x|
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_poch1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double poch1(Double a, Double x);


        #endregion



        #region Incomplete gamma functions for real arguments and parameters



        /// <summary>
        /// Returns the non-normalised lower incomplete gamma function P(a,x), a &#8805; 0, x &#8805; 0
        /// <para> gamma(a,x) = integral(exp(-t)*t^(a-1), t=0..x)</para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammal", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_lower(Double a, Double x);


        /// <summary>
        /// Returns the non-normalised upper incomplete gamma function Q(a,x), a &#8805; 0, x &#8805; 0
        /// <para> GAMMA(a,x) = integral(exp(-t)*t^(a-1), t=x..Inf)</para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_upper(Double a, Double x);


        /// <summary>
        /// Returns the normalised lower incomplete gamma function P(a,x), a &#8805; 0, x &#8805; 0
        /// <para> P(a,x) = integral(exp(-t)*t^(a-1), t=0..x)/gamma(a)</para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammap", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_p(Double a, Double x);


        /// <summary>
        /// Returns the normalised upper incomplete gamma function Q(a,x), a &#8805; 0, x &#8805; 0
        /// <para> Q(a,x) = integral(exp(-t)*t^(a-1), t=x..Inf)/gamma(a)</para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammaq", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_q(Double a, Double x);


        /// <summary>
        /// Returns Tricomi's entire incomplete gamma function gammastar(a,x)
        /// <para> = igammal(a,x)/gamma(a)/x^a = P(a,x)/x^a </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammat", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_tricomi(Double a, Double x);



        /// <summary>
        /// Returns the inverse incomplete gamma function: returns x with P(a,x)=p, a &#8805; 0, 0 &#8804; p &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammap_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_p_inv(Double a, Double p);



        /// <summary>
        /// Returns the inverse complemented incomplete gamma function: returns x with Q(a,x)=q, a &#8805; 0, 0 &lt; q &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammaq_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_q_inv(Double a, Double q);



        /// <summary>
        /// Returns gamma_p_inva(Double x, Double p)
        /// </summary>
        public static Double gamma_p_inva(Double x, Double p)
        {
            return dreal.gamma_p_inva(x, p);
        }



        /// <summary>
        /// Returns gamma_q_inva(Double x, Double q)
        /// </summary>
        public static Double gamma_q_inva(Double x, Double q)
        {
            return dreal.gamma_q_inva(x, q);
        }


        /// <summary>
        /// Returns the partial derivative with respect to x of the normalised lower incomplete gamma function
        /// <para> P(a,x), x &#8805; 0, a &#8800; 0,-1,-2 ...</para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_igammap_der", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_p_prime(Double a, Double x);



        /// <summary>
        /// Returns the truncated exponential sum function e_n = sum(x^k/k!, k=0..n), 0 &#8804; n &lt; MAXGAM-1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expn(int n, Double x);



        /// <summary>
        /// Returns the relative exponential = (e^x-sum(x^k/k!, k=0..n-1)*n!/x^n
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expreln", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expreln(int n, Double x);



        #endregion





        #region Incomplete beta  functions for real arguments and parameters



        #endregion


        #endregion








        #region Special Functions




        #region Elliptic Functions




        #region Conversions of parameters of elliptic functions


        #endregion



        #region Carlson symmetric elliptic integrals

        /// <summary>
        /// Returns Carlson's elliptic integral of the 1st kind; x,y,z &#8805; 0, at most one =0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ell_rf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_rf(Double x, Double y, Double z);


        /// <summary>
        /// Returns Carlson's completely symmetric elliptic integral of the 2nd kind; x,y,z &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ell_rg", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_rg(Double x, Double y, Double z);


        /// <summary>
        /// Return Carlson's elliptic integral of the 3rd kind; r &#8800; 0; x,y,z &#8805; 0, at most one = 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ell_rj", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_rj(Double x, Double y, Double z, Double r);


        /// <summary>
        /// Returns Carlson's elliptic integral of the 2nd kind; z &gt; 0; x,y &#8805; 0, at most one =0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ell_rd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_rd(Double x, Double y, Double z);



        /// <summary>
        /// Returns Carlson's degenerate elliptic integral RC; x &#8805; 0, y &#8800; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ell_rc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_rc(Double x, Double y);


        #endregion




        #region Legendre elliptic integrals (elliptic parameter m)


        /// <summary>
        /// Returns the complete elliptic integral of the 1st kind, K(m) = integral(dx/sqrt(1-m*sin(x)^2),x=0..Pi/2), real part for m>1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_M_EllipticK", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double m_elliptic_k(Double m);


        /// <summary>
        /// Returns the complete elliptic integral of the 2nd kind, E(m) = integral(sqrt(1-m*sin(x)^2),x=0..Pi/2), real part for m>1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_M_EllipticEC", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double m_elliptic_e(Double m);



        /// <summary>
        /// Returns the complete elliptic integral of the 3rd kind, n &#8800; 1, m &#8800; 1, real part for m &gt; 1; Pi(n|m)
        /// <para> = integral(1/(1-n*sin(x)^2/sqrt(1-m*sin(x)^2)), x=0..Pi/2) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_M_EllipticPiC", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double m_elliptic_pi(Double n, Double m);




        /// <summary>
        /// Returns the incomplete elliptic integral of the 1st kind, F(phi,m) = integral(dx/sqrt(1-m*sin(x)^2),x=0..phi), m*sin(phi)^2 &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_M_EllipticF", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double m_elliptic_f(Double phi, Double m);


        /// <summary>
        /// Returns the incomplete elliptic integral of the 2nd kind, E(phi,m) = integral(sqrt(1-m*sin(x)^2),x=0..phi), m*sin(phi)^2 &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_M_EllipticE", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double m_elliptic_e_inc(Double phi, Double m);


        /// <summary>
        /// Returns the incomplete elliptic integral Pi(n,phi,m) of the 3rd kind
        /// <para> = integral(1/sqrt(1-m*sin(x)^2)/(1-n*sin(x)^2),x=0..phi), with n &#8800; 1, m*sin(phi)^2 &#8804; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_M_EllipticPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double m_elliptic_pi_inc(Double n, Double phi, Double m);




        #endregion



        #region Legendre elliptic integrals (elliptic modulus k), and related functions


        /// <summary>
        /// Returns the complete elliptic integral of the 1st kind, |k| &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_comp_ellint_1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_k(Double k);


        /// <summary>
        /// Returns the complete elliptic integral of the 2nd kind, |k| &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_comp_ellint_2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_e(Double k);



        /// <summary>
        /// Returns the complete elliptic integral of the 3rd kind, |k| &lt; 1, nu &#8800; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_comp_ellint_3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_pi(Double nu, Double k);


        /// <summary>
        /// Returns the complete elliptic integral B(k) = (E(k) - kc^2*K(k))/k^2, real part for |k| > 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_comp_ellint_b", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_b(Double k);




        /// <summary>
        /// Returns the complete elliptic integral D(k) = (K(k) - E(k))/k^2, |k| &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_comp_ellint_d", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_d(Double k);



        /// <summary>
        /// Returns the Legendre elliptic integral F(phi,k) of the 1st kind
        /// <para> = integral(1/sqrt(1-k^2*sin(x)^2),x=0..phi), |k*sin(phi)| &#8804; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ellint_1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_f(Double phi, Double k);


        /// <summary>
        /// Returns the Legendre elliptic integral E(phi,k) of the 2nd kind
        /// <para> = integral(sqrt(1-k^2*sin(x)^2),x=0..phi), |k*sin(phi)| &#8804; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ellint_2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_e_inc(Double phi, Double k);


        /// <summary>
        /// Returns the Legendre elliptic integral PI(phi,nu,k) of the 3rd kind
        /// <para> = integral(1/sqrt(1-k^2*sin(x)^2)/(1-nu*sin(x)^2),x=0..phi) with </para>
        /// <para> |k*sin(phi)| &#8804; 1, returns Cauchy principal value if nu*sin(phi)^2 &gt; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ellint_3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_ellint_3(Double phi, Double nu, Double k);

        public static Double elliptic_pi_inc(Double n, Double phi, Double k)
        {
            return damath_ellint_3(phi, dreal.lrint(n), k);
        }



        /// <summary>
        /// Returns the Legendre elliptic integral B(phi,k) = (E(phi,k) - kc^2*F(phi,k))/k^2
        /// <para> integral(cos(x)^2/sqrt(1-k^2*sin(x)^2),x=0..phi), |k*sin(phi)| &#8804; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ellint_b", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_b_inc(Double phi, Double k);


        /// <summary>
        /// Returns the Legendre elliptic integral D(phi,k) = (F(phi,k) - E(phi,k))/k^2
        /// <para> = integral(sin(x)^2/sqrt(1-k^2*sin(x)^2),x=0..phi), |k*sin(phi)| &#8804; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ellint_d", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_d_inc(Double phi, Double k);


        /// <summary>
        /// Returns the arithmetic-geometric mean of |x| and |y|
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_agm", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double agm(Double x, Double y);



        #endregion



        #region Additional elliptic integrals and functions



        /// <summary>
        /// Returns Heuman's function Lambda_0(phi,k) = F(phi,k')/K(k') + 2/Pi*K(k)*Z(phi,k'), |k| &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_heuman_lambda", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double heuman_lambda(Double phi, Double k);


        /// <summary>
        /// Returns the Jacobi zeta function Z(phi,k) = E(phi,k) - E(k)/K(k)*F(phi,k), |k| &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_zeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_zeta(Double phi, Double k);


        /// <summary>
        /// Returns the elliptic nome q(k) = exp(-Pi*EllipticCK(k)/EllipticK(k)), |k| &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticNome", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_nome(Double k);


        /// <summary>
        /// Returns the elliptic modulus k(q) = theta_2(q)^2/theta_3(q)^2, 0 &#8804; q &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticModulus", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_modulus(Double q);


        /// <summary>
        /// Returns the Jacobi amplitude am(x,k)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_am", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_amplitude(Double x, Double k);



        #endregion



        #region Bulirsch elliptic integrals


        /// <summary>
        /// Returns Bulirsch's complete elliptic integral of the 1st kind, kc &#8800; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cel1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cel1(Double kc);


        /// <summary>
        /// Returns Bulirsch's complete elliptic integral of the 2nd kind, kc &#8800; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cel2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cel2(Double kc, Double a, Double b);


        /// <summary>
        /// Returns Bulirsch's general complete elliptic integral, kc &#8800; 0, Cauchy principle value if p &lt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cel", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cel(Double kc, Double p, Double a, Double b);


        /// <summary>
        /// Returns Bulirsch's incomplete elliptic integral of the 1st kind
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_el1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double el1(Double x, Double kc);


        /// <summary>
        /// Returns Bulirsch's incomplete elliptic integral of the 2nd kind, kc &#8800; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_el2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double el2(Double x, Double kc, Double a, Double b);


        /// <summary>
        /// Returns Bulirsch's incomplete elliptic integral of the 3rd kind, 1+p*x^2 &#8800; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_el3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double el3(Double x, Double kc, Double p);


        #endregion




        #region Maple style elliptic integrals


        /// <summary>
        /// Returns the complete elliptic integral of the 1st kind (Maple V style), |k| &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticK", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ellipticK(Double k);


        /// <summary>
        /// Returns K(i*k), the complete elliptic integral of the 1st kind (Maple V style) with
        /// <para> imaginary modulus = integral(1/sqrt(1-x^2)/sqrt(1+k^2*x^2),x=0..1) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticKim", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ellipticKim(Double k);


        /// <summary>
        /// Returns the complementary complete elliptic integral of the 1st kind (Maple V style), k &#8800; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticCK", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ellipticCK(Double k);



        /// <summary>
        /// Returns the complete elliptic integral of the 2nd kind (Maple V style), |k| &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticEC", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ellipticEC(Double k);


        /// <summary>
        /// Returns E(i*k), the complete elliptic integral of the 2nd kind (Maple V style) with
        /// <para> imaginary modulus = integral(sqrt(1+k^2*x^2)/sqrt(1-x^2),x=0..1) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticECim", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ellipticECim(Double k);


        /// <summary>
        /// Returns the complementary complete elliptic integral of the 2nd kind (Maple V style)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticCE", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ellipticCE(Double k);




        /// <summary>
        /// Returns the complete elliptic integral of the 3rd kind (Maple V style), |k| &lt; 1, nu &#8800; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticPiC", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ellipticPiC(Double nu, Double k);




        /// <summary>
        /// Returns Pi(nu, k*i), the complete elliptic integral of the 3rd kind with imaginary modulus, nu &#8800; 1, real part if nu > 1;
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticPiCim", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ellipticPiCim(Double nu, Double k);


        /// <summary>
        /// Returns the complementary complete elliptic integral of the 3rd kind (Maple V style), k &#8800; 0, nu &#8800; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticCPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ellipticCPi(Double nu, Double k);



        /// <summary>
        /// Returns the incomplete elliptic integral of the 1st kind (Maple V style); |z| &#8804; 1, |k*z| &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticF", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ellipticF(Double z, Double k);


        /// <summary>
        /// Return the incomplete elliptic integrals of the 2nd kind (Maple V style), |z| &#8804; 1, |k*z| &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticE", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ellipticE(Double z, Double k);


        /// <summary>
        /// Returns the incomplete elliptic integral of the 3rd kind (Maple V style), |z| &#8804; 1, |k*z| &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_EllipticPi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ellipticPi(Double z, Double nu, Double k);






        #endregion




        #region Jacobi elliptic functions

        /// <summary>
        /// Returns the Jacobi elliptic function sn(x,k)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_sn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_sn(Double x, Double k);


        /// <summary>
        /// Returns the Jacobi elliptic function cn(x,k)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_cn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_cn(Double x, Double k);


        /// <summary>
        /// Returns the Jacobi elliptic function dn(x,k)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_dn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_dn(Double x, Double k);


        /// <summary>
        /// Returns the Jacobi elliptic function nc(x,k)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_nc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_nc(Double x, Double k);


        /// <summary>
        /// Returns the Jacobi elliptic function sc(x,k)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_sc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_sc(Double x, Double k);


        /// <summary>
        /// Returns the Jacobi elliptic function dc(x,k)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_dc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_dc(Double x, Double k);


        /// <summary>
        /// Returns the Jacobi elliptic function nd(x,k)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_nd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_nd(Double x, Double k);


        /// <summary>
        /// Returns the Jacobi elliptic function sd(x,k)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_sd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_sd(Double x, Double k);


        /// <summary>
        /// Returns the Jacobi elliptic function cd(x,k)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_cd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_cd(Double x, Double k);


        /// <summary>
        /// Returns the Jacobi elliptic function ns(x,k)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_ns", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_ns(Double x, Double k);


        /// <summary>
        /// Returns the Jacobi elliptic function cs(x,k)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_cs", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_cs(Double x, Double k);


        /// <summary>
        /// Returns the Jacobi elliptic function ds(x,k)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_ds", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_ds(Double x, Double k);


        /// <summary>
        /// Returns the Jacobi elliptic functions sn,cn,dn for argument x and complementary parameter mc
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sncndn", CallingConvention = CallingConvention.Cdecl)]
        public static extern void sncndn(Double x, Double mc, ref Double sn, ref Double cn, ref Double dn);





        #endregion



        #region Inverses of Jacobi elliptic functions


        /// <summary>
        /// Returns the inverse Jacobi elliptic function arcsn(x,k), |x| &#8804; 1 and |x*k| &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcsn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcsn(Double x, Double k);


        /// <summary>
        /// Returns the inverse Jacobi elliptic function arccn(x,k), |x| &#8804; 1, x &#8805; sqrt(1 - 1/k^2) if k &#8805; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arccn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arccn(Double x, Double k);


        /// <summary>
        /// Returns the inverse Jacobi elliptic function arcdn(x,k), 0 &#8804; x &#8804; 1, x^2 + k^2 &gt; 1 if |k| &lt; 1; |x| &#8804; 1 if |k| &gt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcdn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcdn(Double x, Double k);


        /// <summary>
        /// Returns the inverse Jacobi elliptic function arccd(x,k); |x| &#8804; 1 if |k| &lt; 1; |x| &#8805; 1 if |k| &gt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arccd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arccd(Double x, Double k);


        /// <summary>
        /// Returns the inverse Jacobi elliptic function arcsd(x,k), x^2*(1-k^2) &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcsd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcsd(Double x, Double k);


        /// <summary>
        /// Returns the inverse Jacobi elliptic function arcnd(x,k), x &#8805; 1, x^2 &#8804; k^2/(1-k^2) if k &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcnd", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcnd(Double x, Double k);


        /// <summary>
        /// Returns the inverse Jacobi elliptic function arcdc(x,k); |x| &#8805; 1 if |k| &lt; 1; |x| &#8804; 1 if |k| &gt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcdc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcdc(Double x, Double k);


        /// <summary>
        /// Returns the inverse Jacobi elliptic function arcnc(x,k), x &#8805; 1, x^2 &#8804; k^2/(k^2-1) for |k| &gt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcnc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcnc(Double x, Double k);


        /// <summary>
        /// Returns the inverse Jacobi elliptic function arcsc(x,k), |x| &#8804; 1/sqrt(k^2-1) for |k| &gt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcsc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcsc(Double x, Double k);


        /// <summary>
        /// Returns the inverse Jacobi elliptic function arccs(x,k), |x| &#8805; sqrt(k^2-1) for |k| &gt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arccs", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arccs(Double x, Double k);


        /// <summary>
        /// Returns the inverse Jacobi elliptic function arcns(x,k), |x| &#8805; 1, |x| &#8805; k if k &#8805; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcns", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcns(Double x, Double k);


        /// <summary>
        /// Returns the inverse Jacobi elliptic function arcds(x,k), x^2 + k^2 &#8805; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_arcds", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_arcds(Double x, Double k);





        #endregion




        #region Jacobi theta functions


        /// <summary>
        /// Returns the Jacobi theta function theta_n(x,q), n=1..4, 0 &#8804; q &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_theta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_theta(int n, Double x, Double q);

        public static Double jacobi_theta1(Double x, Double q)
        {
            return jacobi_theta(1, x, q);
        }

        public static Double jacobi_theta2(Double x, Double q)
        {
            return jacobi_theta(2, x, q);
        }

        public static Double jacobi_theta3(Double x, Double q)
        {
            return jacobi_theta(3, x, q);
        }

        public static Double jacobi_theta4(Double x, Double q)
        {
            return jacobi_theta(4, x, q);
        }



        /// <summary>
        /// Returns the derivative theta1p(q) := d/dx(theta_1(x,q)) at x=0,
        /// <para> = 2*q^(1/4)*sum((-1)^n*(2n+1)*q^(n*(n+1)), n = 0..Inf, 0 &#8804; q &lt; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_theta1p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_theta1p(Double q);


        /// <summary>
        /// Returns Jacobi theta_2(q) = 2*q^(1/4)*sum(q^(n*(n+1)),n=0..Inf) 0 &#8804; q &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_theta2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_theta02(Double q);


        /// <summary>
        /// Returns Jacobi theta_3(q) = 1 + 2*sum(q^(n*n)),n=1..Inf); |q| &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_theta3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_theta03(Double q);


        /// <summary>
        /// Returns Jacobi theta_4(q) = 1 + 2*sum((-1)^n*q^(n*(n+1)),n=1..Inf); |q| &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_theta4", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_theta04(Double q);




        #endregion




        #region Neville theta functions


        /// <summary>
        /// Returns the Neville theta_s function, |k| &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ntheta_s", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double neville_theta_s(Double x, Double k);


        /// <summary>
        /// Returns the Neville theta_c function, |k| &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ntheta_c", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double neville_theta_c(Double x, Double k);


        /// <summary>
        /// Returns the Neville theta_d function, |k| &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ntheta_d", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double neville_theta_d(Double x, Double k);


        /// <summary>
        /// Returns the Neville theta_n function, |k| &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ntheta_n", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double neville_theta_n(Double x, Double k);




        #endregion




        #region Lemniscate functions



        /// <summary>
        /// Returns the lemniscate sine function sl = sin_lemn(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_sin_lemn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sin_lemniscate(Double x);


        /// <summary>
        /// Returns the lemniscate cosine function cl = cos_lemn(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cos_lemn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cos_lemniscate(Double x);


        /// <summary>
        /// Returns the inverse lemniscate cosine function, |x| &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arccl", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double acos_lemniscate(Double x);


        /// <summary>
        /// Returns the inverse lemniscate sine function, |x| &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_arcsl", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double asin_lemniscate(Double x);




        #endregion




        #region Weierstrass elliptic and modular functions, real or imaginary arguments, real parameters


        /// <summary>
        /// Returns the Weierstrass function wp(x,1,0)=wpe(x,1/2,0), basic lemniscatic case
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpl", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pl(Double y);


        /// <summary>
        /// Returns Weierstrass P(x,e1,e2) from the lattice roots e1 &lt; e2
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpe", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pe(Double x, Double e1, Double e2);


        /// <summary>
        /// Returns Weierstrass P'(x,e1,e2) from the lattice roots e1 &lt; e2
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpe_der", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pe_prime(Double x, Double e1, Double e2);


        /// <summary>
        /// Returns the Weierstrass function P(iy,e1,e2) from the lattice roots e1 &lt; e2
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpe_im", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pe_im(Double y, Double e1, Double e2);


        /// <summary>
        /// Returns the Weierstrass function P(x,e1,e2) from lattice invariants g2, g3
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpg", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pg(Double x, Double g2, Double g3);


        /// <summary>
        /// Returns Weierstrass P'(x,e1,e2) from lattice invariants g2, g3
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpg_der", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pg_prime(Double x, Double g2, Double g3);


        /// <summary>
        /// Returns the Weierstrass function P(iy, g2, g3)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpg_im", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pg_im(Double y, Double g2, Double g3);


        /// <summary>
        /// Returns the smallest positive x with wpe(x)=y, y &#8805; e1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpe_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pe_inv(Double y, Double e1, Double e2);


        /// <summary>
        /// Returns the smallest positive x with wpg(x,g2,g3)=y, y >= g2
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wpg_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weierstrass_pg_inv(Double y, Double g2, Double g3);



        /// <summary>
        /// Returns Dedekind eta(i*x), x >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_detai", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dedekind_eta_i(Double x);


        /// <summary>
        /// Returns the elliptic modular function lambda(iy), y >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_emlambda", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double elliptic_modular_lambda(Double y);


        /// <summary>
        /// Returns Klein's complete invariant J(iy), y>0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_KleinJ", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double klein_j_i(Double y);




        #endregion





        #region Weierstrass elliptic functions, in terms of half-period omega1 and elliptic period ratio tau



        #endregion




        #region Weierstrass elliptic functions, in terms of (real) lattice invariants g2, g3



        /// <summary>
        /// Returns the real Weierstrass P function.
        /// </summary>
        public static Double weierstrass_p(Double g2, Double g3, Double x)
        {
            Double res = 0.0;
            Lib_xsf_weierstrass_p(g2, g3, x, ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_weierstrass_p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_weierstrass_p(Double g2, Double g3, Double x, ref Double res);


        /// <summary>
        /// Returns the real Weierstrass PPrime function.
        /// </summary>
        public static Double weierstrass_p_prime(Double g2, Double g3, Double x)
        {
            Double res = 0.0;
            Lib_xsf_weierstrass_pprime(g2, g3, x, ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_weierstrass_pprime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_weierstrass_pprime(Double g2, Double g3, Double x, ref Double res);


        /// <summary>
        /// Returns the real Weierstrass zeta function.
        /// </summary>
        public static Double weierstrass_zeta_g(Double g2, Double g3, Double x)
        {
            Double res = 0.0;
            Lib_xsf_cplx_weierstrass_zeta(g2, g3, x, ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_weierstrass_zeta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_weierstrass_zeta(Double g2, Double g3, Double x, ref Double res);


        /// <summary>
        /// Returns the real Weierstrass Sigma function.
        /// </summary>
        public static Double weierstrass_sigma_g(Double g2, Double g3, Double x)
        {
            Double res = 0.0;
            Lib_xsf_cplx_weierstrass_sigma(g2, g3, x, ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_xsf_cplx_weierstrass_sigma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_xsf_cplx_weierstrass_sigma(Double g2, Double g3, Double x, ref Double res);


        #endregion



        #endregion






        #region Lerch’s transcendent and related


        #region Lerch’s transcendent: Overview

        /// <summary>
        /// Returns the Lerch transcendent Phi(z,s,a) = sum(z^n/(n+a)^s, n=0..INF), |z| &#8804; 1, s &#8805; 0, a &#8805; 0; s &gt; 1 if z=1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_LerchPhi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_LerchPhi(Double z, Double s, Double a);


        public static Double lerch_phi(Double z, Double s, Double a)
        {
            if ((Math.Abs(z) > 1.0) || (s < -1.0) || (a < 0.0)) return Double.NaN;
            return damath_LerchPhi(z, s, a);
        }


        #endregion



        #region Polygamma functions


        /// <summary>
        /// Returns the polygamma function: n'th derivative of psi; n &#8805; 0, x &gt; 0 for n &gt; 12.
        /// <para> Note: Accuracy may be reduced for n>=MAXGAMX due to ln/exp operations. </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_polygamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double polygamma(int n, Double x);


        /// <summary>
        /// Returns the pentagamma function psi'''(x), INF if x is a negative integer
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pentagamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pentagamma(Double x);


        /// <summary>
        /// Returns the tetragamma function psi''(x), NAN/RTE if x is a negative integer
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_tetragamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double tetragamma(Double x);


        /// <summary>
        /// Returns the trigamma function of x, INF if x is a negative integer
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_trigamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double trigamma(Double x);


        /// <summary>
        /// Returns the psi (digamma) function of x, INF if x is a non-positive integer
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_psi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double digamma(Double x);


        /// <summary>
        /// Returns the psi (digamma) function of x, INF if x is a non-positive integer
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_psi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double psi(Double x);


        /// <summary>
        /// Returns psi(x) - ln(x), x > 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_psistar", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double psistar(Double x);


        /// <summary>
        /// -Inverse of psi, return x with psi(x)=y, y &#8804; ln_MaxDbl
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_psi_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double psi_inv(Double x);


        /// <summary>
        /// Returns the Bateman function G(x) = psi((x+1)/2) - psi(x/2), x &#8800; 0,-1,-2,...
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_BatemanG", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bateman_g(Double x);


        /// <summary>
        /// Returns the harmonic number function H(x) = psi(x+1) + EulerGamma
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_harmonic", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double harmonic(Double x);


        #endregion



        #region Polylogarithms and related functions

        /// <summary>
        /// Returns the polylogarithm Li_s(x) of real order; s &#8805; 0, |x| &#8804; 1, x &#8800; 1 if s &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_polylogr", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double polylog(Double s, Double x);


        /// <summary>
        /// Returns the polylogarithm Li_n(x) of integer order; x &lt; 1 for n &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_polylog", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double polylog_i(int n, Double x);


        /// <summary>
        /// Returns the trilogarithm function trilog(x) = Re(Li_3(x))
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_trilog", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double trilog(Double x);


        /// <summary>
        /// Returns dilog(x) = Re(Li_2(x)), Li_2(x) = -integral(ln(1-t)/t, t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_dilog", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dilog(Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/clausen_sin/*' />
        public static Double clausen_sin(Double n, Double z)
        {
            return cmath53.clausen_sin(dcplx.t(dreal.lrint(n)), dcplx.t(z)).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/clausen_sin/*' />
        public static Double clausen_sin(int n, dynamic z)
        {
            return cmath53.clausen_sin(dcplx.t(dreal.lrint(n)), dcplx.t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/clausen_cos/*' />
        public static Double clausen_cos(Double n, Double z)
        {
            return cmath53.clausen_cos(dcplx.t(dreal.lrint(n)), dcplx.t(z)).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/clausen_cos/*' />
        public static Double clausen_cos(int n, dynamic z)
        {
            return cmath53.clausen_cos(dcplx.t(dreal.lrint(n)), dcplx.t(z));
        }



        /// <summary>
        /// Returns the Clausen function: integral(-ln(2*|sin(t/2)|),t=0..x) = Im(Li_2(exp(ix)))
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cl2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double clausen2(Double x);




        /// <summary>
        /// Returns the Bose-einstein integral of real order s >= -1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bose_einstein", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bose_einstein(Double s, Double x);



        /// <summary>
        /// Returns the Fermi-Dirac integral of real order s >= -1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fermi_dirac_r", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fermi_dirac(Double s, Double x);


        /// <summary>
        /// Returns the integer order Fermi-Dirac integral F_n(x) = 1/n!*integral(t^n/(exp(t-x)+1), t=0..INF)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fermi_dirac", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fermi_dirac_i(int n, Double x);


        /// <summary>
        /// Returns the complete Fermi-Dirac integral F(-1/2,x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fermi_dirac_m05", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fermi_dirac_m05(Double s);


        /// <summary>
        /// Returns the complete Fermi-Dirac integral F(1/2,x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fermi_dirac_p05", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fermi_dirac_p05(Double s);


        /// <summary>
        /// Returns the complete Fermi-Dirac integral F(3/2,x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fermi_dirac_p15", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fermi_dirac_p15(Double s);


        /// <summary>
        /// Returns the complete Fermi-Dirac integral F(5/2,x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fermi_dirac_p25", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fermi_dirac_p25(Double s);



        /// <summary>
        /// Returns Legendre's Chi-function chi(s, x); s &#8805; 0, |x| &#8804; 1, x &#8800; 1 if s &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_LegendreChi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double legendre_chi(Double s, Double x);


        /// <summary>
        /// Returns the inverse tangent integral of order s >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ti", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double inverse_tan_integral(Double s, Double x);



        /// <summary>
        /// Returns the inverse tangent integral, ti2(x) = integral(arctan(t)/t, t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ti2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double tangent_int_2(Double x);


        /// <summary>
        /// Returns the Lobachevski function L(x) = integral(-ln(|cos(t)|), t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lobachevsky_c", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lobachevsky_c(Double x);


        /// <summary>
        /// Returns the Lobachevski function Lambda(x) = integral(-ln(|2sin(t)|), t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lobachevsky_s", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lobachevsky_s(Double x);



        /// <summary>
        /// Returns the Debye function D(n,x) = n/x^n*integral(t^n/(exp(t)-1),t=0..x) of order n &gt; 0, x &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_debye", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double debye(int n, Double x);


        /// <summary>
        /// Returns the transport integral J_n(x) for x >= 0, n >= 2; J_n(x) = integral(t^n*exp(t)/(exp(t)-1)^2, t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_transport", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double transport_jn(int n, Double x);




        #endregion



        #region Hurwitz zeta function and related functions


        /// <summary>
        /// Returns the Hurwitz zeta function zetah(s,a) = sum(1/(i+a)^s, i=0..INF), s &#8800; 1, a &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zetah", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hurwitz_zeta(Double s, Double a);


        /// <summary>
        /// Returns the generalized harmonic number.
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_harmonic2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double harmonic2(Double x, Double r);



        /// <summary>
        /// Returns the nth Bernoulli number, 0 if n &lt; 0 or odd n &#8805; 3
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bernoulli", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bernoulli(int n);


        /// <summary>
        /// Returns the Bernoulli polynomial B_n(x), 0 &#8804; n &#8804; MaxBernoulli
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bernpoly", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bernpoly_(int n, Double x);

        public static Double bernpoly(Double x, int n)
        {
            return bernpoly_(dreal.lrint(n), x);
        }




        /// <summary>
        /// Returns the nth Euler number, 0 if n &lt; 0 or odd n
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_euler", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double eulernum(int n);


        /// <summary>
        /// Returns the Euler polynomial E_n(x), 0 &#8804; n &lt; MaxBernoulli
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_eulerpoly", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double eulerpoly_(int n, Double x);

        public static Double eulerpoly(Double x, int n)
        {
            return eulerpoly_(dreal.lrint(n), x);
        }





        /// <summary>
        /// Returns ln(BarnesG(x)), real part for x &lt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lnBarnesG", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logbarnes_g(Double x);


        public static Double barnes_g(Double x)
        {
            Double res = Math.Exp(logbarnes_g(x));
            if (x < 0) res = -res;
            return res;
        }


        public static Double hyperfactorial(Double z)
        {
            return Math.Exp(lgamma(z + 1) * z - logbarnes_g(z + 1));
        }



        public static Double superfactorial(Double z)
        {
            return barnes_g(z + 2);
        }


        #endregion




        #region Riemann zeta function, and related functions

        /// <summary>
        /// Returns the Riemann zeta function at s, s &#8800; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zeta(Double s);


        /// <summary>
        /// Returns zeta(n) for integer arguments, n &#8800; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zetaint", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zeta_i(int n);


        /// <summary>
        /// Returns the Riemann zeta function at 1+s, s &#8800; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zeta1p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zeta1p(Double s);


        /// <summary>
        /// Returns Riemann zeta(s)-1, s &#8800; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zetam1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zetam1(Double s);


        /// <summary>
        /// Returns the prime zeta function P(s) = sum(1/p^s, p prime), s &gt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_primezeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double primezeta(Double s);




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hardy_theta/*' />
        public static Double hardy_theta(Double z)
        {
            return cmath53.hardy_theta(dcplx.t(z)).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hardy_theta/*' />
        public static Double hardy_theta(dynamic z)
        {
            return cmath53.hardy_theta(dreal.t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hardy_z/*' />
        public static Double hardy_z(Double z)
        {
            return cmath53.hardy_z(dcplx.t(z)).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hardy_z/*' />
        public static Double hardy_z(dynamic z)
        {
            return cmath53.hardy_z(dreal.t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/riemann_xi/*' />
        public static Double riemann_xi(Double z)
        {
            return cmath53.riemann_xi(dcplx.t(z)).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/riemann_xi/*' />
        public static Double riemann_xi(dynamic z)
        {
            return cmath53.riemann_xi(dreal.t(z));
        }



        /// <summary>
        /// Returns the Dirichlet eta function
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_eta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dirichlet_eta(Double s);


        /// <summary>
        /// Returns the Dirichlet function eta(n) for integer arguments
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_etaint", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dirichlet_eta_i(int s);


        /// <summary>
        /// Returns Dirichlet eta(s)-1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_etam1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dirichlet_etam1(Double s);


        /// <summary>
        /// Returns the Dirichlet beta function sum((-1)^n/(2n+1)^s, n=0..INF)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_DirichletBeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dirichlet_beta(Double s);



        /// <summary>
        /// Returns the Dirichlet lambda function sum(1/(2n+1)^s, n=0..INF), s &#8800; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_DirichletLambda", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dirichlet_lambda(Double s);




        #endregion



        #region Additional numbertheoretic functions





        /// <summary>
        /// Returns the Riemann prime counting function R(x), x &#8805; 1/16
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_RiemannR", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double riemann_r(Double x);


        /// <summary>
        /// Returns the functional inverse of R(x), R(RiemannR_inv(x))=x, x >= 1.125
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_RiemannR_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double riemann_r_inv(Double x);




        /// <summary>
        /// Returns the Rogers-Ramanujan continued fraction for |q| &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_rrcf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double rogers_ramanujan_cf(Double q);





        /// <summary>
        /// Return the Moebius function mu(abs(n)), mu(0)=0, mu(1)=1. mu(n)=(-1)^k
        /// if n &gt; 1 is the product of k different primes; otherwise mu(n)=0.
        /// </summary>
        public static short moebius(int n)
        {
            return mpi_Moebius32(dreal.lrint(n));
        }
        [DllImport(xcn.libwe64d, EntryPoint = "mpi_Moebius32", CallingConvention = CallingConvention.Cdecl)]
        internal static extern short mpi_Moebius32(int n);



        /// <summary>
        /// Returns the EulerQ function product(1-q^n, n=1..Inf), |q| &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_euler_q", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double euler_q(Double q);



        #endregion


        #endregion





        #region Hypergeometric function 0F1 and related



        #region 0F1: Overview


        /// <summary>
        /// Returns the confluent hypergeometric limit function 0F1(;b;x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_0F1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_0f1(Double b, Double x);


        /// <summary>
        /// Returns the regularized confluent hypergeometric limit function 0F1(;b;x)/Gamma(b)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_0F1r", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_0f1r(Double b, Double x);






        #endregion



        #region Bessel functions of integer order



        /// <summary>
        /// Returns J0(x), the Bessel function of the 1st kind, order zero
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_j0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_j0(Double x);

        /// <summary>
        /// Returns J1(x), the Bessel function of the 1st kind, order one
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_j1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_j1(Double x);

        /// <summary>
        /// Returns J_n(x), the Bessel function of the 1st kind, order n; not suitable for large n or x.
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_jn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_jn(int n, Double x);




        /// <summary>
        /// Returns Y0(x), the Bessel function of the 2nd kind, order zero; x &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_y0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_y0(Double x);

        /// <summary>
        /// Returns Y1(x), the Bessel function of the 2nd kind, order one; x &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_y1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_y1(Double x);

        /// <summary>
        /// Returns Y_n(x), the Bessel function of the 2nd kind, order n, x &gt; 0, not suitable for large n or x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_yn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_yn(int n, Double x);



        #endregion



        #region Modified Bessel functions of integer order


        /// <summary>
        /// Returns I0(x), the modified Bessel function of the 1st kind, order zero
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_i0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_i0(Double x);

        /// <summary>
        /// Returns I1(x), the modified Bessel function of the 1st kind, order one
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_i1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_i1(Double x);

        /// <summary>
        /// Returns I_n(x), the modified Bessel function of the 1st kind, order n; not suitable for large n or x.
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_in", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_in(int n, Double x);



        /// <summary>
        /// Returns K0(x), the modified Bessel function of the 2nd kind, order zero, x>0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_k0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_k0(Double x);

        /// <summary>
        /// Returns K1(x), the modified Bessel function of the 2nd kind, order one, x>0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_k1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_k1(Double x);

        /// <summary>
        /// Returns K_n(x), the modified Bessel function of the 2nd kind, order n, x>0, not suitable for large n
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_kn", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_kn(int n, Double x);


        /// <summary>
        /// Returns I0(x)*exp(-|x|), the exponentially scaled modified Bessel function of the 1st kind, order zero
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_i0e", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_i0e(Double x);

        /// <summary>
        /// Returns I1(x)*exp(-|x|), the exponentially scaled modified Bessel function of the 1st kind, order one
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_i1e", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_i1e(Double x);

        /// <summary>
        /// Returns K0(x)*exp(x), the exponentially scaled modified Bessel function of the 2nd kind, order zero, x>0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_k0e", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_k0e(Double x);


        /// <summary>
        /// Returns K1(x)*exp(x), the exponentially scaled modified Bessel function of the 2nd kind, order one, x>0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_k1e", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_k1e(Double x);


        #endregion



        #region Bessel functions and modified Bessel functions of general order



        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_jv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bessel_jv_(Double v, Double x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv/*' />
        public static  Double bessel_jv(Double v, Double x, bool scaled = false)
        {
            return bessel_jv_(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv/*' />
        public static Double bessel_jv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_jv(t(nu), t(x), scaled);
        }



        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_yv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bessel_yv_(Double v, Double x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv/*' />
        public static Double bessel_yv(Double v, Double x, bool scaled = false)
        {
            return bessel_yv_(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv/*' />
        public static Double bessel_yv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_yv(t(nu), t(x), scaled);
        }



        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_iv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bessel_iv_(Double v, Double x);

        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_ive", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bessel_ive(Double v, Double x);

        public static Double bessel_iv(Double v, Double x, bool scaled = false)
        {
            if (scaled) return bessel_ive(v, x); else return bessel_iv_(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv/*' />
        public static Double bessel_iv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_iv(t(nu), t(x), scaled);
        }



        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_kv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bessel_kv_(Double v, Double x);

        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_kve", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double bessel_kve(Double v, Double x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv/*' />

        public static Double bessel_kv(Double v, Double x, bool scaled = false)
        {
            if (scaled) return bessel_kve(v, x); else return bessel_kv_(v, x);
        }



        /// <summary>
        /// Compute lambda(v,x) = Gamma(v+1)*J(v,x)/(0.5x)^v for v,x >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_lambda", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_lambda(Double v, Double x);




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_prime/*' />
        public static Double bessel_jv_prime(Double v, Double x, bool scaled = false)
        {
            return dreal.bessel_jv_prime(v, x, scaled);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_prime/*' />
        public static Double bessel_jv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_jv_prime(t(nu), t(x), scaled);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_prime/*' />
        public static Double bessel_yv_prime(Double v, Double x, bool scaled = false)
        {
            return dreal.bessel_yv_prime(v, x, scaled);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_prime/*' />
        public static Double bessel_yv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_yv_prime(t(nu), t(x), scaled);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv_prime/*' />
        public static Double bessel_iv_prime(Double v, Double x, bool scaled = false)
        {
            return dreal.bessel_iv_prime(v, x, scaled);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv_prime/*' />
        public static Double bessel_iv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_iv_prime(t(nu), t(x), scaled);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv_prime/*' />
        public static Double bessel_kv_prime(Double v, Double x, bool scaled = false)
        {
            return dreal.bessel_kv_prime(v, x, scaled);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv_prime/*' />
        public static Double bessel_kv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_kv_prime(t(nu), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_zero/*' />
        public static Double bessel_jv_zero(Double v, int m)
        {
            return dreal.bessel_jv_zero(v, m);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_zero/*' />
        public static Double bessel_yv_zero(Double v, int m)
        {
            return dreal.bessel_yv_zero(v, m);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_zero/*' />
        public static Double sph_bessel_jn_zero(int n, int m)
        {
            return bessel_jv_zero(n + 0.5, m);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_zero/*' />
        public static Double sph_bessel_yn_zero(int n, int m)
        {
            return bessel_yv_zero(n + 0.5, m);
        }


        #endregion



        #region Integrals of zero order Bessel functions


        /// <summary>
        /// Returns the integral int(bessel_i0(x), x = 0..u)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_i0_int", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_i0_int(Double u);


        /// <summary>
        /// Returns the integral int(bessel_j0(x), x = 0..u)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_j0_int", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_j0_int(Double u);


        /// <summary>
        /// Returns the integral int(bessel_k0(x), x = 0..u), x >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_k0_int", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_k0_int(Double u);


        /// <summary>
        /// Returns the integral int(bessel_y0(x), x = 0..u), x >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_bessel_y0_int", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double bessel_y0_int(Double u);





        #endregion







        #region Spherical Bessel functions

        [DllImport(xcn.libwe64d, EntryPoint = "damath_sph_bessel_jn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double sph_bessel_jn_(int n, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_jn/*' />
        public static Double sph_bessel_jn(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan();

            if (dreal.isnan(x)) return dreal.nan();
            if (dreal.isinf(x)) return dreal.zero();
            if (dreal.isneginf(x)) return dreal.zero();
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if ((n == 0)) return dreal.one();
                    else return dreal.zero();
                }
                else
                {
                    if (n % 2 == 0) return dreal.neginf(); else return dreal.nan();
                }
            }
            return sph_bessel_jn_(dreal.lrint(n), x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_jn/*' />
        public static Double sph_bessel_jn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_jn(dreal.t(n), dreal.t(x));
        }





        [DllImport(xcn.libwe64d, EntryPoint = "damath_sph_bessel_yn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double sph_bessel_yn_(int n, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_jn/*' />
        public static Double sph_bessel_yn(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan();

            if (dreal.isnan(x)) return dreal.nan();
            if (dreal.isinf(x)) return dreal.zero();
            if (dreal.isneginf(x)) return dreal.zero();
            if (x == 0.0)
            {
                if (n < 0)
                {
                    if ((n == -1)) return dreal.one();
                    else return dreal.zero();
                }
                else
                {
                    if (n % 2 != 0) return dreal.neginf(); else return dreal.nan();
                }
            }
            return sph_bessel_yn_(dreal.lrint(n), x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_jn/*' />
        public static Double sph_bessel_yn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_yn(dreal.t(n), dreal.t(x), scaled);
        }





        [DllImport(xcn.libwe64d, EntryPoint = "damath_sph_bessel_in", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double sph_bessel_in_(int n, Double x);

        [DllImport(xcn.libwe64d, EntryPoint = "damath_sph_bessel_ine", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double sph_bessel_ine(int n, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_kn/*' />
        public static Double sph_bessel_in(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan();

            if (!dreal.isinteger(n)) return dreal.nan();
            if (dreal.isnan(x)) return dreal.nan();
            if (dreal.isinf(x)) return dreal.inf();
            if (dreal.isneginf(x)) return dreal.zero();
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if ((n == 0)) return dreal.one();
                    else return dreal.zero();
                }
                else
                {
                    if (n % 2 == 0) return dreal.neginf(); else return dreal.nan();
                }
            }
            if (scaled) return sph_bessel_ine(dreal.lrint(n), x); else return sph_bessel_in_(dreal.lrint(n), x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_kn/*' />
        public static Double sph_bessel_in(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_in(dreal.t(n), dreal.t(x), scaled);
        }





        [DllImport(xcn.libwe64d, EntryPoint = "damath_sph_bessel_kn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double sph_bessel_kn_(int n, Double x);

        [DllImport(xcn.libwe64d, EntryPoint = "damath_sph_bessel_kne", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double sph_bessel_kne_(int n, Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_kn/*' />
        public static Double sph_bessel_kn(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan();

            if (dreal.isnan(x)) return dreal.nan();
            if (dreal.isinf(x)) return dreal.zero();
            if (dreal.isneginf(x)) return dreal.neginf();
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if (n % 2 == 0) return dreal.nan(); else return dreal.inf();
                }
                else
                {
                    if (n % 2 == 0) return dreal.inf(); else return dreal.nan();
                }
            }
            if (scaled)
            {
                if (x >= 0.0) return math53.sph_bessel_kne_(dreal.lrint(n), x);
                //else return math53.sph_bessel_kn(n, x) * exp(x);
                else return -0.5 * dreal.pi() * (sph_bessel_in(dreal.lrint(n), abs(x), scaled) + sph_bessel_in(-dreal.lrint(n) - 1, abs(x), scaled));
            }
            else
            {
                if (x >= 0.0) return math53.sph_bessel_kn_(dreal.lrint(n), x);
                else return -0.5 * dreal.pi() * (sph_bessel_in(dreal.lrint(n), abs(x)) + sph_bessel_in(-dreal.lrint(n) - 1, abs(x)));
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sph_bessel_kn/*' />
        public static Double sph_bessel_kn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_kn(dreal.t(n), dreal.t(x), scaled);
        }


        [DllImport(xcn.libwe64d, EntryPoint = "damath_besselpoly", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double besselpoly_(int n, Double x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besselpoly/*' />
        public static Double besselpoly(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan();
            return besselpoly_(dreal.lrint(n), x);

        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besselpoly/*' />
        public static Double besselpoly(dynamic n, dynamic x, bool scaled = false)
        {
            return besselpoly(t(n), t(x), scaled);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besseltheta/*' />
        public static Double besseltheta(Double n, Double x, bool scaled = false)
        {
            return dreal.besseltheta(n, x);

        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besseltheta/*' />
        public static Double besseltheta(dynamic n, dynamic x, bool scaled = false)
        {
            return besseltheta(t(n), t(x), scaled);
        }



        #endregion





        #region Spherical Bessel functions, first derivative




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_prime/*' />
        public static Double sph_bessel_jn_prime(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan();

            if (dreal.isnan(x)) return dreal.nan();
            if (dreal.isinf(x)) return dreal.zero();
            if (dreal.isneginf(x)) return dreal.zero();
            if (x == 0.0)
            {
                if (n == 1) return 1 / dreal.t(3);
                if (n >= 0) return dreal.zero();
                else
                {
                    if (n % 2 != 0) return dreal.neginf(); else return dreal.nan();
                }
            }
            return (n * sph_bessel_jn(n - 1, x, scaled) - (n + 1) * sph_bessel_jn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_prime/*' />
        public static Double sph_bessel_jn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_jn_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_prime/*' />
        public static Double sph_bessel_yn_prime(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan();

            if (dreal.isnan(x)) return dreal.nan();
            if (dreal.isinf(x)) return dreal.zero();
            if (dreal.isneginf(x)) return dreal.zero();
            if (x == 0.0)
            {
                if (n == -2) return -1 / dreal.t(3);
                if (n < 0) return dreal.zero();
                else
                {
                    if (n % 2 == 0) return dreal.inf(); else return dreal.nan();
                }
            }
            return (n * sph_bessel_yn(n - 1, x, scaled) - (n + 1) * sph_bessel_yn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_prime/*' />
        public static Double sph_bessel_yn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_yn_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in_prime/*' />
        public static Double sph_bessel_in_prime(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan();

            if (dreal.isnan(x)) return dreal.nan();
            if (dreal.isinf(x)) return dreal.inf();
            if (dreal.isneginf(x))
            {
                if (n % 2 == 0) return dreal.neginf(); else return dreal.inf();
            }
            if (x == 0.0)
            {
                if (n == 0) return dreal.zero();
                if (n < 0)
                {
                    if (n % 2 != 0) return dreal.neginf(); else return dreal.nan();
                }
            }
            return (n * sph_bessel_in(n - 1, x, scaled) + (n + 1) * sph_bessel_in(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in_prime/*' />
        public static Double sph_bessel_in_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_in_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn_prime/*' />
        public static Double sph_bessel_kn_prime(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan();

            if (dreal.isnan(x)) return dreal.nan();
            if (dreal.isinf(x)) return dreal.zero();
            if (dreal.isneginf(x)) return dreal.neginf();
            if (x == 0.0)
            {
                if (((n >= 0) && (n % 2 == 0)) || ((n < 0) && (n % 2 != 0))) return dreal.neginf();
                else return dreal.nan();
            }
            return -(n * sph_bessel_kn(n - 1, x, scaled) + (n + 1) * sph_bessel_kn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn_prime/*' />
        public static Double sph_bessel_kn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_kn_prime(t(n), t(x), scaled);
        }





        #endregion







        #region Hankel functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h1/*' />
        public static Complex hankel_h1(Double v, Double x)
        {
            return bessel_jv(v, x) + dcplx.onej() * bessel_yv(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h1/*' />
        public static Complex hankel_h1(dynamic v, dynamic x)
        {
            return hankel_h1(t(v), t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h2/*' />
        public static Complex hankel_h2(Double v, Double x)
        {
            return bessel_jv(v, x) - dcplx.onej() * bessel_yv(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h2/*' />
        public static Complex hankel_h2(dynamic v, dynamic x)
        {
            return hankel_h2(t(v), t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h1/*' />
        public static Complex sph_hankel_h1(int n, Double x)
        {
            return sph_bessel_jn(dreal.lrint(n), x) + dcplx.onej() * sph_bessel_yn(dreal.lrint(n), x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h1/*' />
        public static Complex sph_hankel_h1(int n, dynamic x)
        {
            return sph_hankel_h1(dreal.lrint(n), t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h2/*' />
        public static Complex sph_hankel_h2(int n, Double x)
        {
            return sph_bessel_jn(dreal.lrint(n), x) - dcplx.onej() * sph_bessel_yn(dreal.lrint(n), x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h2/*' />
        public static Complex sph_hankel_h2(int n, dynamic x)
        {
            return sph_hankel_h2(dreal.lrint(n), t(x));
        }





        #endregion



        #region Airy functions


        /// <summary>
        /// Returns the Airy function Ai(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_ai", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double airy_ai_(Double x);

        public static Double airy_ai(Double x, bool scaled = false)
        {
            if (scaled) return airy_ai_scaled_(x);
            else return airy_ai_(x);
        }

        /// <summary>
        /// Returns the Airy function Bi(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_bi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double airy_bi_(Double x);

        public static Double airy_bi(Double x, bool scaled = false)
        {
            if (scaled) return airy_bi_scaled_(x);
            else return airy_bi_(x);
        }


        /// <summary>
        /// Returns the Airy function Ai'(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_aip", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double airy_ai_prime_(Double x);

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

        public static Double airy_ai_prime_old(Double x, bool scaled = false)
        {
            double res = airy_ai_prime_(x);
            if ((scaled) && (x > 0)) res *= exp((dreal.t(2) / dreal.t(3)) * x * sqrt(x));
            return res;
        }



        /// <summary>
        /// Returns the Airy function Bi'(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_bip", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double airy_bi_prime_(Double x);

        public static Double airy_bi_prime_old(Double x, bool scaled = false)
        {
            double res = airy_bi_prime_(x);
            if ((scaled) && (x > 0)) res *= exp(-abs(dreal.t(2) / dreal.t(3) * (x * sqrt(x))));
            return res;
        }

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




        /// <summary>
        /// Returns the scaled Airy function Ai(x) if x &#8804; 0, Ai(x)*exp(2/3*x^1.5) for x &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_ais", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double airy_ai_scaled_(Double x);

        /// <summary>
        /// Returns the scaled Airy function Bi(x) if x &#8804; 0, Bi(x)*exp(-2/3*x^1.5) for x > 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_bis", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double airy_bi_scaled_(Double x);



        /// <summary>
        /// Returns airy_ai_zero(int n)
        /// </summary>
        public static Double airy_ai_zero(int n)
        {
            return dreal.airy_ai_zero(n);
        }



        /// <summary>
        /// Returns airy_ai_zero(int n)
        /// </summary>
        public static Double airy_bi_zero(int n)
        {
            return dreal.airy_bi_zero(n);
        }




        #endregion



        #region Kelvin functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ber/*' />
        public static Double kelvin_ber(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_ber(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ber/*' />
        public static Double kelvin_ber(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_ber(t(v), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_bei/*' />
        public static Double kelvin_bei(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_bei(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_bei/*' />
        public static Double kelvin_bei(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_bei(t(v), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ker/*' />
        public static Double kelvin_ker(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_ker(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ker/*' />
        public static Double kelvin_ker(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_ker(t(v), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_kei/*' />
        public static Double kelvin_kei(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_kei(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_kei/*' />
        public static Double kelvin_kei(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_kei(t(v), t(x), scaled);
        }






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ber_prime/*' />
        public static Double kelvin_ber_prime(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_ber_prime(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ber_prime/*' />
        public static Double kelvin_ber_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_ber_prime(t(v), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_bei_prime/*' />
        public static Double kelvin_bei_prime(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_bei_prime(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_bei_prime/*' />
        public static Double kelvin_bei_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_bei_prime(t(v), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ker_prime/*' />
        public static Double kelvin_ker_prime(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_ker_prime(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_ker_prime/*' />
        public static Double kelvin_ker_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_ker_prime(t(v), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_kei_prime/*' />
        public static Double kelvin_kei_prime(Double v, Double x, bool scaled = false)
        {
            return cmath53.kelvin_kei_prime(dreal.t(v), dcplx.t(x), scaled).Real;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/kelvin_kei_prime/*' />
        public static Double kelvin_kei_prime(dynamic v, dynamic x, bool scaled = false)
        {
            return kelvin_kei_prime(t(v), t(x), scaled);
        }









        #endregion






        #region Kelvin0 functions



        /// <summary>
        /// Returns the Kelvin function ber(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_ber", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_ber0(Double x);


        /// <summary>
        /// Returns the Kelvin function bei(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_bei", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_bei0(Double x);



        /// <summary>
        /// Returns the Kelvin function ker(x), x > 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_ker", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_ker0(Double x);


        /// <summary>
        /// Returns the Kelvin function kei(x), x &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_kei", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_kei0(Double x);





        /// <summary>
        /// Returns the Kelvin function ber'(x), x >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_berp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_ber_prime0(Double x);



        /// <summary>
        /// Returns the Kelvin function bei'(x), x >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_beip", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_bei_prime0(Double x);



        /// <summary>
        /// Returns the Kelvin function ker'(x), x > 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_kerp", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_ker_prime0(Double x);


        /// <summary>
        /// Returns the the Kelvin function kei'(x), x >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_keip", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kelvin_kei_prime0(Double x);


        ///// <summary>
        ///// Simulateously calculates the Kelvin functions kr=ker(x), ki=kei(x), x &gt; 0
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_kerkei", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void kelvin_kerkei(Double x, ref Double ker, ref Double kei);



        ///// <summary>
        ///// Simulateously calculates the Kelvin functions br=ber(x), bi=bei(x)
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_berbei", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void kelvin_berbei(Double x, ref Double ber, ref Double bei);





        ///// <summary>
        ///// Returns the derivatives of the zero order Kelvin functions, x >= 0
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_kelvin_der", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void kelvin_der(Double x, ref Double berp, ref Double beip, ref Double kerp, ref Double keip);



        #endregion




        #region Synchrotron functions

        /// <summary>
        /// Returns the first synchrotron function F(x) = integral(x*bessel_kv(5/3,t), t=x..INF) for x >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_SynchF", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double synchrotron_f(Double x);


        /// <summary>
        /// Returns the second synchrotron function G(x) = x*bessel_kv(2/3,x) for x >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_SynchG", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double synchrotron_g(Double x);


        #endregion




        #endregion




        #region Hypergeometric function 1F1 and related



        #region Hypergeometric Functions 1F1 (Kummer) and U (Tricomi)



        /// <summary>
        /// Returns the confluent hypergeometric function 1F1(a,b,x); Kummer's function M(a,b,x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_1F1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_1f1(Double a, Double b, Double x);


        /// <summary>
        /// Returns the regularized Kummer hypergeometric function 1F1(a,b,x)/Gamma(b)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_1F1r", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_1f1r(Double a, Double b, Double x);


        // Missing log_hyperg_1f1(a, b, x)


        /// <summary>
        /// Returns Tricomi's confluent hypergeometric function U(a,b,x), x &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_u", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_u(Double a, Double b, Double x);





        /// <summary>
        /// Returns Hn(x), the nth hermite_h polynomial, degree n &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hermite_h", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hermite_h(int n, Double x);



        /// <summary>
        /// Returns the hermite_h function H_v(x) of degree v
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_HermiteH", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hermite_hv(Double v, Double x);



        /// <summary>
        /// Returns He_n(x), the nth "probabilists'" hermite_h polynomial, degree n >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hermite_he", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hermite_he(int n, Double x);




        /// <summary>
        /// Returns Ln(a,x), the nth generalized laguerre_l polynomial with parameter a;
        /// <para> degree n must be &#8805; 0. x &#8805; 0 and a &gt; -1 are the standard ranges. </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_laguerre", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double laguerre(int n, Double a, Double x);


        /// <summary>
        /// Returns the associated laguerre_l polynomial Ln(m,x); n,m &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_laguerre_ass", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double laguerre_l(int n, int m, Double x);


        ///// <summary>
        ///// Returns the nth laguerre_l polynomial Ln(0,x); n &#8805; 0
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_laguerre_l", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double laguerre_l(int n, int m, Double x);



        #endregion



        #region Factorials, Gamma and related functions


        /// <summary>
        /// Returns gamma(x), x &#8804; MAXGAM; invalid if x is a non-positive integer
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma(Double x);


        /// <summary>
        /// Returns ln(|gamma(x)|), |x| &#8804; MAXLGM, invalid if x is a non-positive integer function signgamma can be used if the sign of gamma(x) is needed.
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lngamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lgamma(Double x);


        /// <summary>
        /// Returns the reciprocal gamma function rgamma = 1/gamma(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_rgamma", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double rgamma(Double x);


        ///// <summary>
        ///// Returns the rising factorial or Pochhammer symbol gamma(a+x)/gamma(a)
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_pochhammer", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double rising_factorial(Double a, Double x);


        // Missing: falling_factorial



        /// <summary>
        /// Returns the factorial n!, n &lt; MAXGAM-1; INF if n &lt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_fac", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double factorial(int n);


        /// <summary>
        /// Returns the Double factorial n!!, n &#8804; MAXDFAC; INF for even n &lt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_dfac", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double doublefactorial(int n);




        ///// <summary>
        ///// Returns the binomial coefficient 'n choose k'
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_binomial", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double binomial(int n, int k);



        #endregion



        #region Incomplete gamma functions


        ///// <summary>
        ///// Returns the normalised incomplete gamma functions P and Q, a &#8805; 0, x &#8805; 0
        ///// <para> P(a,x) = integral(exp(-t)*t^(a-1), t=0..x )/gamma(a)</para>
        ///// <para> Q(a,x) = integral(exp(-t)*t^(a-1), t=x..Inf)/gamma(a)</para>
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_incgamma", CallingConvention = CallingConvention.Cdecl)]
        //public static extern void IncGamma(Double a, Double x, ref Double p, ref Double q);

        // Missing: gamma_inc (from mpmath)


        ///// <summary>
        ///// Returns the normalised lower incomplete gamma function P(a,x), a &#8805; 0, x &#8805; 0
        ///// <para> P(a,x) = integral(exp(-t)*t^(a-1), t=0..x)/gamma(a)</para>
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_igammap", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double gamma_p(Double a, Double x);


        ///// <summary>
        ///// Returns the normalised upper incomplete gamma function Q(a,x), a &#8805; 0, x &#8805; 0
        ///// <para> Q(a,x) = integral(exp(-t)*t^(a-1), t=x..Inf)/gamma(a)</para>
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_igammaq", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double gamma_q(Double a, Double x);


        ///// <summary>
        ///// Returns the non-normalised lower incomplete gamma function P(a,x), a &#8805; 0, x &#8805; 0
        ///// <para> gamma(a,x) = integral(exp(-t)*t^(a-1), t=0..x)</para>
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_igammal", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double gamma_lower(Double a, Double x);


        ///// <summary>
        ///// Returns the non-normalised upper incomplete gamma function Q(a,x), a &#8805; 0, x &#8805; 0
        ///// <para> GAMMA(a,x) = integral(exp(-t)*t^(a-1), t=x..Inf)</para>
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_igamma", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double gamma_upper(Double a, Double x);


        ///// <summary>
        ///// Returns Tricomi's entire incomplete gamma function gammastar(a,x)
        ///// <para> = igammal(a,x)/gamma(a)/x^a = P(a,x)/x^a </para>
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_igammat", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double gamma_tricomi(Double a, Double x);




        ///// <summary>
        ///// Returns the partial derivative with respect to x of the normalised lower incomplete gamma function
        ///// <para> P(a,x), x &#8805; 0, a &#8800; 0,-1,-2 ...</para>
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_igammap_der", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double gamma_p_prime(Double a, Double x);




        #endregion



        #region Coulomb, Whittaker and parabolic cylinder function


        /// <summary>
        /// Returns the normalizing constant CL for Coulomb wave function, L >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CoulombCL", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double coulomb_cl(int L, Double eta);


        /// <summary>
        /// Returns the Coulomb phase shift sigma_L(eta) for L >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CoulombSL", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double coulomb_sl(int L, Double eta);


        /// <summary>
        /// Returns the regular Coulomb wave functions fc=FL(eta,x) for L >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CoulombF", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double coulomb_f_(int L, Double eta, Double x);


        public static Double coulomb_f(Double L, Double eta, Double x)
        {
            if (!dreal.isinteger(L)) return dreal.nan();
            int l1 = dreal.lrint(L);
            return coulomb_f_(l1, eta, x);
        }



        /// <summary>
        /// Simultaneously calculates the regular Coulomb wave functions fc=FL(eta,x) and fcp=FL'(eta,x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CoulombFFp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void coulomb_f_fprime(int L, Double eta, Double x, ref Double fc, ref Double fcp, ref int ifail);



        /// <summary>
        /// Simulateously calculates the irregular Coulomb wave functions gc=GL(eta,x) and gcp=GL'(eta,x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CoulombGGp", CallingConvention = CallingConvention.Cdecl)]
        public static extern void coulomb_g_gprime(int L, Double eta, Double x, ref Double gc, ref Double gcp, ref int ifail);


        public static Double coulomb_g(Double L, Double eta, Double x)
        {
            if (!dreal.isinteger(L)) return dreal.nan();
            int l1 = dreal.lrint(L);
            Double gc = 0.0;
            Double gcp = 0.0;
            int ifail = 0;
            coulomb_g_gprime(l1, eta, x, ref gc, ref gcp, ref ifail);
            return gc;
        }






        // Missing: coulomb_f
        // Missing: coulomb_g



        /// <summary>
        /// Returns the Whittaker M function = exp(-x/2)*x^(0.5+m) * 1F1(m-k-0.5,2m+1,x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_WhittakerM", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double whittaker_m(Double k, Double m, Double x);


        /// <summary>
        /// Returns the Whittaker W function = exp(-x/2)*x^(0.5+m) * U(m-k-0.5,2m+1,x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_WhittakerW", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double whittaker_w(Double k, Double m, Double x);


        /// <summary>
        /// Returns Whittaker's parabolic cylinder function D_v(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CylinderD", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pcfd(Double v, Double x);


        /// <summary>
        /// Returns the parabolic cylinder function U(a,x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CylinderU", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pcfu(Double a, Double x);


        /// <summary>
        /// Returns the parabolic cylinder function V(a,x) with 2a integer
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_CylinderV", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pcfv(Double a, Double x);


        // Missing: cylinder_w


        #endregion



        #region Error function and related functions


        /// <summary>
        /// Returns dawson's integral: dawson(x) = exp(-x^2)*integral(exp(t^2), t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_dawson", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dawson(Double x);

        /// <summary>
        /// Returns the generalized dawson integral F(p,x) = exp(-x^p)*integral(exp(t^p), t=0..x); x,p &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_dawson2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double dawson2(Double p, Double x);


        ///// <summary>
        ///// Returns the error function erf(x) = 2/sqrt(Pi)*integral((exp(-t^2), t=0..x)
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_erf", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double erf(Double x);



        /// <summary>
        /// Returns the generalized error function integral(exp(-t^p), t=0..x); x, p &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_erfg", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double erfg(Double p, Double x);




        /// <summary>
        /// Returns the integral(exp(-t^3), t=0..x), x &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_expint3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double expint3(Double x);


        ///// <summary>
        ///// Returns the complementary error function erfc(x) = 1-erf(x)
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_erfc", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double erfc(Double x);





        ///// <summary>
        ///// Returns the exponentially scaled complementary error function erfce(x) = exp(x^2)*erfc(x)
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_erfce", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double erfcx(Double x);





        /// <summary>
        /// Returns the repeated integrals of erfc, n &#8805; -1; scaled with exp(x^2) for x &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_inerfc", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double inerfc(int p, Double x);





        ///// <summary>
        ///// Returns the imaginary error function erfi(x) = erf(ix)/i
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_erfi", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double erfi(Double x);




        // Missing: Faddeva



        /// <summary>
        /// Returns the Fresnel integral S(x)=integral(sin(Pi/2*t^2),t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_FresnelS", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fresnel_s(Double x);


        /// <summary>
        /// Returns the Fresnel integral C(x)=integral(cos(Pi/2*t^2),t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_FresnelC", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fresnel_c(Double x);



        /// <summary>
        /// Returns the Fresnel auxiliary function f for x >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_FresnelF", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fresnel_f(Double x);


        /// <summary>
        /// Returns the Fresnel auxiliary function g for x >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_FresnelG", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fresnel_g(Double x);


        // Misssing: Voigt U

        // Misssing: Voigt V

        // Misssing: Voigt H

        // Misssing: voigt_profile_pdf



        /// <summary>
        /// Returns the Goodwin-Staton integral = integral(exp(-t*t)/(t+x), t=0..Inf), x &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gsi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double goodwin_staton(Double x);






        /// <summary>
        /// Returns the generalized Marcum Q function Q(m,a,b), a,b >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_MarcumQ", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double marcum_q(int m, Double a, Double b);



        /// <summary>
        /// Returns Owen's t function t(h,a)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_OwenT", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double owen_t(Double h, Double a);






        #endregion



        #region Exponential integrals and related functions


        /// <summary>
        /// Returns the hyperbolic cosine integral = EulerGamma + ln(|x|) + integral((cosh(t)-1)/t, t=0..|x|)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cosh_integral(Double x);


        /// <summary>
        /// Returns the cosine integral, ci(x) = EulerGamma + ln(|x|) + integral((cos(t)-1)/t, t=0..|x|)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ci", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cos_integral(Double x);




        /// <summary>
        /// Returns the entire cosine integral, cin(x) = integral((1-cos(t))/t, t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cin", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cin(Double x);



        /// <summary>
        /// Returns the entire hyperbolic cosine integral, cinh(x) = integral((cosh(t)-1)/t, t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cinh", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cinh(Double x);



        /// <summary>
        /// Returns the exponential integral E1(x) = integral(exp(-x*t)/t, t=1..Inf), x &#8800; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_e1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp_integral_e1(Double x);


        /// <summary>
        /// Returns E1s(x) = exp(x)*E1(x), x &#8800; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_e1s", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp_integral_e1_scaled(Double x);


        /// <summary>
        /// Returns the exponential integral exp_integral_ei(x) = PV-integral(exp(t)/t, t=-Inf..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ei", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp_integral_ei(Double x);



        /// <summary>
        /// Returns exp(-x)*exp_integral_ei(x), x &#8800; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_eis", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp_integral_ei_scaled(Double x);


        /// <summary>
        /// Returns exp(-x^2)*exp_integral_ei(x^2), x &#8800; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_eisx2", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double eisx2(Double x);




        /// <summary>
        /// Returns the functional inverse of exp_integral_ei(x), ei_inv(ei(x)) = x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ei_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ei_inv(Double x);



        /// <summary>
        /// Returns the entire exponential integral ein(x) = integral((1-exp(-t))/t, t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ein", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ein(Double x);



        /// <summary>
        /// Returns the exponential integral E_n(x) = integral(exp(-x*t)/t^n, t=1..Inf), x &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_en", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double exp_integral_en(int n, Double x);



        /// <summary>
        /// Returns the generalized exponential integral E_p(x) = integral(exp(-x*t)/t^p, t=1..Inf), x &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gei", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gei(Double p, Double x);




        /// <summary>
        /// Returns the exponential integral beta(n,x) = int(t^n*exp(-x*t), t=-1..1), n >= 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_eibeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double eibeta(int n, Double x);




        /// <summary>
        /// Returns the logarithmic integral li(x) = PV-integral(1/ln(t), t=0..x), x &#8805; 0, x &#8800; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_li", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log_integral(Double x);


        /// <summary>
        /// Returns the functional inverse of li(x), li(li_inv(x))=x
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_li_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double log_integral_inv(Double x);

        // Missing: primepi2_upper
        // Missing: primepi2_lower


        /// <summary>
        /// Returns the hyperbolic sine integral, integral(sinh(t)/t, t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_shi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sinh_integral(Double x);


        /// <summary>
        /// Returns the sine integral, si(x) = integral(sin(t)/t, t=0..x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_si", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double sin_integral(Double x);


        /// <summary>
        /// Returns the shifted sine integral, ssi(x) = si(x) - Pi/2
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ssi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double shifted_sin_integral(Double x);



        #endregion



        #endregion





        #region Hypergeometric function pFq and related




        #region Gauss Hypergeometric Function 2F1 and related


        /// <summary>
        /// Returns the Gauss hypergeometric function 2F1(a,b;c;x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_2F1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_2f1(Double a, Double b, Double c, Double x);


        /// <summary>
        /// Returns the regularized Gauss hypergeometric function 2F1(a,b,c,x)/Gamma(c)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_2F1r", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_2f1r(Double a, Double b, Double c, Double x);





        #endregion



        #region Chebyshev, Gegenbauer and Jacobi polynomials


        /// <summary>
        /// Returns T_n(x), the Chebyshev polynomial of the first kind, degree n
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chebyshev_t", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chebyshev_t(int n, Double x);


        /// <summary>
        /// Returns U_n(x), the Chebyshev polynomial of the second kind, degree n
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chebyshev_u", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chebyshev_u(int n, Double x);


        /// <summary>
        /// Returns V_n(x), the Chebyshev polynomial of the third kind, degree n &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chebyshev_v", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chebyshev_v(int n, Double x);


        /// <summary>
        /// Returns W_n(x), the Chebyshev polynomial of the fourth kind, degree n &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chebyshev_w", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chebyshev_w(int n, Double x);



        ///// <summary>
        ///// Returns the Chebyshev function the first kind, real part for x &lt; -1
        ///// </summary>
        //[DllImport(xcn.libwe64d, EntryPoint = "damath_chebyshev_f1", CallingConvention = CallingConvention.Cdecl)]
        //public static extern Double ChebyshevF1(int n, Double x);


        /// <summary>
        /// Returns Cn(a,x), the nth Gegenbauer (ultraspherical) polynomial with
        /// <para> parameter a. The degree n must be non-negative; a should be &gt; -0.5 </para>
        /// <para> When a = 0, C0(0,x) = 1, and Cn(0,x) = 2/n*Tn(x) for n &#8800; 0. </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gegenbauer_c", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gegenbauer_c(int n, Double a, Double x);



        /// <summary>
        /// Returns Pn(a,b,x), the nth Jacobi polynomial with parameters a,b. Degree n
        /// <para> must be &#8805; 0; a,b should be &gt; -1 (a+b must not be an integer &lt; -1). </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_jacobi_p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double jacobi_p(int n, Double a, Double b, Double x);





        #endregion



        #region Legendre polynomials and related


        /// <summary>
        /// Returns P_l(x), the Legendre polynomial/function P_l, degree l
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_legendre_p", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double legendre_p(int l, Double x);


        /// <summary>
        /// Returns the associated Legendre polynomial P_lm(x)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_legendre_plm", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double legendre_plm(int l, int m, Double x);


        /// <summary>
        /// Returns Q_l(x), the Legendre function of the 2nd kind, degree l &#8805; 0, |x| &#8800; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_legendre_q", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double legendre_q(int l, Double x);


        /// <summary>
        /// Returns Q(l,m,x), the associated Legendre function of the second kind; l &#8805; 0, l+m &#8805; 0, |x| &#8800; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_legendre_qlm", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double legendre_qlm(int l, int m, Double x);



        /// <summary>
        /// Returns Re and Im of the spherical harmonic function Y_lm(theta,phi)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_spherical_harmonic", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void spherical_harmonic_(int l, int m, Double theta, Double phi, ref Double yr, ref Double yi);

        public static Complex spherical_y(Double n, Double m, Double theta, Double phi)
        {
            Double yr = 0.0;
            Double yi = 0.0;
            spherical_harmonic_(lrint(n), lrint(m), theta, phi, ref yr, ref yi);
            return dcplx.t(yr, yi);
        }



        ///// <summary>
        ///// Returns spherical_harmonic_r(int n, int m, Double theta, Double phi)
        ///// </summary>
        //public static Double spherical_harmonic_r(int n, int m, Double theta, Double phi)
        //{
        //    Double yr = 0.0;
        //    Double yi = 0.0;
        //    spherical_harmonic_(n, m, theta, phi, ref yr, ref yi);
        //    return yr;
        //}


        ///// <summary>
        ///// Returns spherical_harmonic_i(int n, int m, Double theta, Double phi)
        ///// </summary>
        //public static Double spherical_harmonic_i(int n, int m, Double theta, Double phi)
        //{
        //    Double yr = 0.0;
        //    Double yi = 0.0;
        //    spherical_harmonic_(n, m, theta, phi, ref yr, ref yi);
        //    return yi;
        //}




        public static Double toroidal_qlm_2f1(int n, int m, Double x)
        {
            if (x <= 1.0) return dreal.nan();
            Double nu = n - 0.5;
            Double f1a = sqrt(pi()) * gamma(nu + m + 1) * pow(x * x - 1, 1.0 * m / 2.0);
            Double f1b = pow(2.0,nu + 1) * gamma(nu + 1.5) * pow(x, nu + m + 1);
            Double f1 = f1a / f1b;
            Double f2 = hyperg_2f1((nu + m + 2) / 2.0, (nu + m + 1) / 2.0, nu + 1.5, 1 / (x * x));
            int s = -1; if (m % 2 == 0) s = 1;
            return s * f1 * f2;
        }



        public static Double toroidal_plm_2f1(int n, int m, Double x)
        {
            if (x < 1.0) return dreal.nan();
            Double nu = n - 0.5;
            Double f2 = hyperg_2f1r(nu + 1, -nu, 1 - m, (1 - x) / 2);
            if (x == 1.0) return f2; 
            else return pow((x + 1) / (x - 1), m / 2.0) * f2;
        }




        /// <summary>
        /// Returns the toroidal harmonic function P(l-0.5,m,x); l,m=0,1; x &#8805; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_toroidal_plm", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double toroidal_plm(int l, int m, Double x);


        /// <summary>
        /// Returns the toroidal harmonic function Q(l-0.5,m,x); l=0,1; x &gt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_toroidal_qlm", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double toroidal_qlm(int l, int m, Double x);


        /// <summary>
        /// Returns the Zernike radial polynomial Rnm(r), r &#8805; 0, n &#8805; m &#8805; 0, n-m even
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zernike_r", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zernike_r(int n, int m, Double r);







        #endregion



        #region Incomplete beta Function


        /// <summary>
        /// Returns the non-normalised incomplete beta function B_x(a,b)
        /// <para> for 0 &#8804; x &#8804; 1, B_x = integral(t^(a-1)*(1-t)^(b-1), t=0..x). </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_beta3", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double beta_lower(Double a, Double b, Double x);





        /// <summary>
        /// Returns beta_upper(Double a, Double b, Double x)
        /// </summary>
        public static Double beta_upper(Double a, Double b, Double x)
        {
            return dreal.beta_upper(a, b, x);
        }





        /// <summary>
        /// Returns the normalised incomplete beta function, a &gt; 0, b &gt; 0, 0 &#8804; x &#8804; 1,
        /// <para> ibeta = integral(t^(a-1)*(1-t)^(b-1) / betax(a,b), t=0..x) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ibeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ibeta(Double a, Double b, Double x);




        /// <summary>
        /// Returns ibetac(Double a, Double b, Double x)
        /// </summary>
        public static Double ibetac(Double a, Double b, Double x)
        {
            return dreal.ibetac(a, b, x);
        }

        /// <summary>
        /// Returns the inverse of normalised incomplete beta function for a, b &gt; 0 and 0 &#8804; y &#8804; 1,
        /// <para> i.e. they return x = ibeta_inv(a, b, y) with I_x(a, b) = y. </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_ibeta_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double ibeta_inv(Double a, Double b, Double y);



        /// <summary>
        /// Returns ibetac_inv(Double a, Double b, Double q)
        /// </summary>
        public static Double ibetac_inv(Double a, Double b, Double q)
        {
            return dreal.ibetac_inv(a, b, q);
        }



        /// <summary>
        /// Returns ibeta_inva(Double b, Double x, Double p)
        /// </summary>
        public static Double ibeta_inva(Double b, Double x, Double p)
        {
            return dreal.ibeta_inva(b, x, p);
        }



        /// <summary>
        /// Returns ibetac_inva(Double b, Double x, Double q)
        /// </summary>
        public static Double ibetac_inva(Double b, Double x, Double q)
        {
            return dreal.ibetac_inva(b, x, q);
        }



        /// <summary>
        /// Returns ibeta_invb(Double a, Double x, Double p)
        /// </summary>
        public static Double ibeta_invb(Double a, Double x, Double p)
        {
            return dreal.ibeta_invb(a, x, p);
        }



        /// <summary>
        /// Returns ibetac_invb(Double a, Double x, Double q)
        /// </summary>
        public static Double ibetac_invb(Double a, Double x, Double q)
        {
            return dreal.ibetac_invb(a, x, q);
        }


        /// <summary>
        /// Returns ibeta_prime(Double a, Double b, Double x)
        /// </summary>
        public static Double ibeta_prime(Double a, Double b, Double x)
        {
            return dreal.ibeta_prime(a, b, x);
        }




        /// <summary>
        /// Returns the function beta(x,y)=gamma(x)*gamma(y)/gamma(x+y)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_beta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double beta(Double x, Double y);


        /// <summary>
        /// Returns the logarithm of |beta(x,y)|=|gamma(x)*gamma(y)/gamma(x+y)|
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lnbeta", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logbeta(Double x, Double y);



        #endregion



        #region Hypergeometric Function 1F2, overview


        public static Double hyperg_1f2(Double a1, Double b1, Double b2, Double x)
        {
            cb1SDouble1S F2 = (Double t) =>
            {
                Double res = pow(1 - t, b2 - a1 - 1) * pow(t, a1 - 1) * hyperg_0f1(b1, t * x);
                return res;
            };

            var res1 = dreal.GaussKronrod(F2, a: 0.0, b: 1, tol: 0.0);
            Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            Console.WriteLine();
            return res1.Item1 * gamma(b2) / (gamma(a1) * gamma(b2 - a1));
        }


        public static Double hyperg_1f2r(Double a1, Double b1, Double b2, Double x)
        {
            return hyperg_1f2(a1, b1, b2, x) / (dreal.gamma(b1) * dreal.gamma(b2));
        }





        #endregion




        #region Scorer functions



        /// <summary>
        /// Returns the Airy/Scorer function Gi(x) = 1/Pi*integral(sin(x*t+t^3/3), t=0..INF)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_gi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double airy_gi(Double x);

        /// <summary>
        /// Returns the Airy/Scorer function Hi(x) = 1/Pi*integral(exp(x*t-t^3/3), t=0..INF)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_airy_hi", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double airy_hi(Double x);



        public static Double airy_gi_prime(Double x)
        {
            return airy_bi_prime(x) - airy_hi_prime(x);
        }


        public static Double airy_hi_prime(Double x)
        {
            cb1SDouble1S F2 = (Double t) =>
            {
                Double res = t * exp(x * t - t * t * t / 3);
                return res;
            };
            var res1 = dreal.GaussKronrod(F2, a: 0.0, b: dreal.inf(), tol: 0.0);
            //Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            //Console.WriteLine();
            return res1.Item1 / dreal.pi();
        }



        #endregion




        #region Struve functions

        /// <summary>
        /// Returns H0(x), the Struve function of order 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_struve_h0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double struve_h0(Double x);

        /// <summary>
        /// Returns H1(x), the Struve function of order 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_struve_h1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double struve_h1(Double x);

        /// <summary>
        /// Returns H_v(x), the Struve function of order v, x &lt; 0 only if v is an integer.
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_struve_h", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double struve_h(Double v, Double x);

        /// <summary>
        /// Returns L0(x), the modified Struve function of order 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_struve_l0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double struve_l0(Double x);

        /// <summary>
        /// Returns L1(x), the modified Struve function of order 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_struve_l1", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double struve_l1(Double x);

        /// <summary>
        /// Returns L_v(x), the modified Struve function of order v, x &lt; 0 only if v is an integer.
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_struve_l", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double struve_l(Double v, Double x);


        public static  Double struve_k(Double v, Double x)
        {
            return struve_h(v,x) - bessel_yv(v,x);
        }



        public static Double struve_m(Double v, Double x)
        {
            return struve_l(v, x) - bessel_iv(v, x);
        }




        #endregion



        #region Anger, Weber and Lommel functions


        public static Double anger_j(Double nu, Double x)
        {
            cb1SDouble1S F2 = (Double t) =>
            {
                Double res = cos(nu * t - x * sin(t));
                return res;
            };
            var res1 = dreal.GaussKronrod(F2, a: 0.0, b: dreal.pi(), tol: 0.0);
            //Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            //Console.WriteLine();
            return res1.Item1 / dreal.pi();
        }


        public static Double weber_e(Double nu, Double x)
        {
            cb1SDouble1S F2 = (Double t) =>
            {
                Double res = sin(nu * t - x * sin(t));
                return res;
            };
            var res1 = dreal.GaussKronrod(F2, a:0.0, b: dreal.pi(), tol: 0.0);
            //Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            //Console.WriteLine();
            return res1.Item1 / dreal.pi();
        }


        internal static Double lommels1int1(Double mu, Double nu, Double x)
        {
            cb1SDouble1S F2 = (Double t) =>
            {
                Double res = pow(t, mu) * bessel_jv(nu, t);
                return res;
            };
            var res1 = dreal.GaussKronrod(F2, a: 0.0, b: x, tol: 0.0);
            //Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            //Console.WriteLine();
            return res1.Item1 / dreal.pi();
        }


        internal static Double lommels1int2(Double mu, Double nu, Double x)
        {
            cb1SDouble1S F2 = (Double t) =>
            {
                Double res = pow(t, mu) * bessel_yv(nu, t);
                return res;
            };
            var res1 = dreal.GaussKronrod(F2, a: 0.0, b: x, tol: 0.0);
            //Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            //Console.WriteLine();
            return res1.Item1 / dreal.pi();
        }



        public static Double lommel_s1(Double mu, Double nu, Double x)
        {
            Double res1 = bessel_yv(nu, x) * lommels1int1(mu, nu, x);
            Double res2 = bessel_jv(nu, x) * lommels1int2(mu, nu, x);
            return 0.5 * dreal.pi() * dreal.pi() * (res1 - res2);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lommel_s2/*' />
        public static Double lommel_s2(Double mu, Double nu, Double x)
        {
            Double f1 = lommel_s1(mu, nu, x);
            Double res1 = exp2(mu - 1) * gamma((mu - nu + 1) / 2) * gamma((mu + nu + 1) / 2);
            Double res2 = sinpi((mu - nu) / 2) * bessel_jv(nu, x) - cospi((mu - nu) / 2) * bessel_yv(nu, x);
            return f1 + res1 * res2;
        }




        #endregion




        #region Generalized hypergeometric functions



        /// <summary>
        /// Returns 2F0(a,b,x), if x>0 then a or b must be a negative integer
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hyperg_2F0", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double hyperg_2f0(Double a, Double b, Double x);



        #endregion






        #endregion




        #endregion












        #region Statistical distributions


        #region Distributions based on elementary functions


        // {---------------------- Arcsine distribution --------------------------}

        public static Double arcsine_pdf(Double a, Double b, Double x)
        {
            return dreal.dist_arcsine(a, b).pdf(x);
        }

        public static Double arcsine_cdf(Double a, Double b, Double x)
        {
            return dreal.dist_arcsine(a, b).cdf(x);
        }

        public static Double arcsine_qtf(Double a, Double b, Double q)
        {
            return dreal.dist_arcsine(a, b).qtf(q);
        }


        // {---------------------- Cauchy distribution --------------------------}

        /// <summary>
        /// Returns the Cauchy probability density function with location a
        /// <para> and scale b &gt; 0, 1/(Pi*b*(1+((x-a)/b)^2)) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cauchy_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cauchy_pdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the cumulative Cauchy distribution function with location a
        /// <para> and scale b &gt; 0, = 1/2 + arctan((x-a)/b)/Pi </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cauchy_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cauchy_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of Cauchy distribution function
        /// <para> with location a and scale b &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_cauchy_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double cauchy_qtf(Double a, Double b, Double y);



        // {---------------------- Exponential distribution --------------------------}

        /// <summary>
        /// Returns the exponential probability density function with location a
        /// <para> and rate alpha &gt; 0, = alpha*exp(-alpha*(x-a)) if x &#8805; a, 0 if x &lt; a. </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp_pdf", CallingConvention = CallingConvention.Cdecl)]
        private static extern Double exp_pdf(Double a, Double alpha, Double x);

        public static Double exponential_pdf(Double lambda1, Double x)
        {
            return exp_pdf(0, lambda1, x);
        }


        /// <summary>
        /// Returns the cumulative exponential distribution function with location a
        /// <para> and rate alpha &gt; 0, = 1 - exp(-alpha*(x-a)) if x &#8805; a, 0 if x &lt; a. </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp_cdf", CallingConvention = CallingConvention.Cdecl)]
        private static extern Double exp_cdf(Double a, Double alpha, Double x);

        public static Double exponential_cdf(Double lambda1, Double x)
        {
            return exp_cdf(0, lambda1, x);
        }


        /// <summary>
        /// Returns the functional inverse of exponential distribution function with
        /// <para> location a and rate alpha &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_exp_inv", CallingConvention = CallingConvention.Cdecl)]
        private static extern Double exp_qtf(Double a, Double alpha, Double q);

        public static Double exponential_qtf(Double lambda1, Double q)
        {
            return exp_qtf(0, lambda1, q);
        }



        // {---------------------- Gumbel distribution --------------------------}

        /// <summary>
        /// Returns the probability density function of the Extreme Value Type I distribution
        /// <para> with location a and scale b &gt; 0, result = exp(-(x-a)/b)/b * exp(-exp(-(x-a)/b)) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_evt1_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gumbel_pdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the cumulative Extreme Value Type I distribution function
        /// <para> with location a and scale b &gt; 0; result = exp(-exp(-(x-a)/b)). </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_evt1_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gumbel_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the Extreme Value Type I distribution
        /// <para> function with location a and scale b &gt; 0; result = a - b*ln(ln(-y)). </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_evt1_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gumbel_qtf(Double a, Double b, Double y);


        // Missing: Hyperexponential distribution


        // {---------------------- Hyperexponential distribution --------------------------}

        public static Double hyperexponential_pdf(DoubleVec Prob, DoubleVec Rate, Double x)
        {
            return dreal.dist_hyperexponential(Prob, Rate).pdf(x);
        }

        public static Double hyperexponential_cdf(DoubleVec Prob, DoubleVec Rate, Double x)
        {
            return dreal.dist_hyperexponential(Prob, Rate).cdf(x);
        }

        public static Double hyperexponential_qtf(DoubleVec Prob, DoubleVec Rate, Double q)
        {
            return dreal.dist_hyperexponential(Prob, Rate).cdf(q);
        }





        /// <summary>
        /// Returns the Kumaraswamy probability density function with shape
        /// <para> parameters a,b &gt; 0, 0 &#8804; x &#8804; 1; result = a*b*x^(a-1)*(1-x^a)^(b-1) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kumaraswamy_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kumaraswamy_pdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the cumulative Kumaraswamy distribution function with
        /// <para> shape parameters a,b &gt; 0, 0 &#8804; x &#8804; 1; result = 1-(1-x^a)^b </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kumaraswamy_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kumaraswamy_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the Kumaraswamy distribution
        /// <para> with shape parameters a,b &gt; 0; result = [1-(1-y)^(1/b)]^(1/a) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_kumaraswamy_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double kumaraswamy_qtf(Double a, Double b, Double y);



        // {---------------------- Laplace distribution --------------------------}

        /// <summary>
        /// Returns the Laplace probability density function with location a
        /// <para> and scale b &gt; 0, result = exp(-abs(x-a)/b) / (2*b) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_laplace_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double laplace_pdf(Double a, Double b, Double x);



        /// <summary>
        /// Returns the cumulative Laplace distribution function with location a and scale b &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_laplace_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double laplace_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the Laplace distribution with location a and scale b &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_laplace_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double laplace_qtf(Double a, Double b, Double y);



        // {---------------------- Logistic distribution --------------------------}

        /// <summary>
        /// Returns the logistic probability density function with location a
        /// <para> and scale parameter b &gt; 0, exp(-(x-a)/b)/b/(1+exp(-(x-a)/b))^2 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logistic_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logistic_pdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the cumulative logistic distribution function with
        /// <para> location a and scale parameter b &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logistic_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logistic_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the logistic distribution
        /// <para> with location a and scale parameter b &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logistic_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logistic_qtf(Double a, Double b, Double y);




        // {---------------------- Pareto distribution --------------------------}

        /// <summary>
        /// Returns the Pareto probability density function with minimum value k &gt; 0
        /// <para> and shape a, x &#8805; a &gt; 0, result = (a/x)*(k/x)^a </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pareto_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pareto_pdf(Double k, Double a, Double x);


        /// <summary>
        /// Returns the cumulative Pareto distribution function minimum value k &gt; 0
        /// <para> and shape a, x &#8805; a &gt; 0, result = 1-(k/x)^a </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pareto_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pareto_cdf(Double k, Double a, Double x);


        /// <summary>
        /// Returns the functional inverse of the Pareto distribution with minimum
        /// <para> value k &gt; 0 and shape a, x &#8805; a &gt; 0, result = k/(1-x)^(1/a) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_pareto_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double pareto_qtf(Double k, Double a, Double x);



        // {---------------------- Rayleigh distribution --------------------------}

        /// <summary>
        /// Returns the Rayleigh probability density function with
        /// <para> scale b &gt; 0, x &#8805; 0; result = x*exp(-0.5*(x/b)^2)/b^2 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_rayleigh_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double rayleigh_pdf(Double b, Double x);


        /// <summary>
        /// Returns the cumulative Rayleigh distribution function with scale b &gt; 0, x &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_rayleigh_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double rayleigh_cdf(Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the Rayleigh distribution with scale b &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_rayleigh_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double rayleigh_qtf(Double b, Double x);




        // {---------------------- Triangular distribution --------------------------}

        /// <summary>
        /// Returns the triangular probability density function with
        /// <para> lower limit a, upper limit b, mode c; a &lt; b, a &#8804; c &#8804; b </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_triangular_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double triang_pdf(Double a, Double b, Double c, Double x);

        public static Double triangular_pdf(Double a, Double b, Double c, Double x)
        {
            return triang_pdf(a, c, b, x);
        }


        /// <summary>
        /// Returns the cumulative triangular distribution function with
        /// <para> lower limit a, upper limit b, mode c; a &lt; b, a &#8804; c &#8804; b </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_triangular_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double triang_cdf(Double a, Double b, Double c, Double x);

        public static Double triangular_cdf(Double a, Double b, Double c, Double x)
        {
            return triang_cdf(a, c, b, x);
        }

        /// <summary>
        /// Returns the functional inverse of the triangular distribution with
        /// <para> lower limit a, upper limit b, mode c; a &lt; b, a &#8804; c &#8804; b, 0 &#8804; y &#8804; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_triangular_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double triang_qtf(Double a, Double b, Double c, Double x);

        public static Double triangular_qtf(Double a, Double b, Double c, Double q)
        {
            return triang_qtf(a, c, b, q);
        }


        // {---------------------- Uniform distribution --------------------------}

        /// <summary>
        /// Returns the uniform probability density function on [a,b], a &lt; b
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_uniform_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double uniform_pdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the cumulative uniform distribution function on [a,b], a &lt; b
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_uniform_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double uniform_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the uniform distribution on [a,b], a &lt; b
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_uniform_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double uniform_qtf(Double a, Double b, Double y);



        // {---------------------- Weibull distribution --------------------------}

        /// <summary>
        /// Returns the Weibull probability density function with shape a &gt; 0
        /// <para> and scale b &gt; 0, result = a*x^(a-1)*exp(-(x/b)^a)/ b^a, x &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_weibull_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weibull_pdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the cumulative Weibull distribution function with
        /// <para> shape parameter a &gt; 0 and scale parameter b &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_weibull_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weibull_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the Weibull distribution
        /// <para> shape parameter a &gt; 0 and scale parameter b &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_weibull_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double weibull_qtf(Double a, Double b, Double x);


        #endregion




        #region Distributions based on the error function



        // {---------------------- Levy distribution --------------------------}

        /// <summary>
        /// Returns the Levy probability density function with
        /// <para> location a and scale parameter b &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_levy_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double levy_pdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the cumulative Levy distribution function with
        /// <para> location a and scale parameter b &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_levy_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double levy_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the Levy distribution
        /// <para> location a and scale parameter b &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_levy_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double levy_qtf(Double a, Double b, Double y);



        // {---------------------- log-normal distribution --------------------------}

        /// <summary>
        /// Returns the log-normal probability density function with
        /// <para> location a and scale parameter b &gt; 0, zero for x &#8804; 0. </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lognormal_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lognormal_pdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the cumulative log-normal distribution function with
        /// <para> location a and scale parameter b &gt; 0, zero for x &#8804; 0. </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lognormal_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lognormal_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the log-normal distribution
        /// <para> with location a and scale parameter b &gt; 0, 0 &lt; y &lt; 1. </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_lognormal_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double lognormal_qtf(Double a, Double b, Double y);



        // {---------------------- Moyal distribution --------------------------}

        /// <summary>
        /// Returns the Moyal probability density function with
        /// <para> location a and scale parameter b &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_moyal_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double moyal_pdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the cumulative Moyal distribution function with
        /// <para> location a and scale parameter b &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_moyal_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double moyal_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the Moyal distribution
        /// <para> location a and scale parameter b &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_moyal_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double moyal_qtf(Double a, Double b, Double y);



        // {---------------------- Normal (Gaussian) distribution --------------------------}

        /// <summary>
        /// Returns the normal (Gaussian) probability density function with mean mu
        /// <para> and standard deviation sd &gt; 0, exp(-0.5*(x-mu)^2/sd^2) / sqrt(2*Pi*sd^2) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_normal_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double normal_pdf(Double mu, Double sd, Double x);


        /// <summary>
        /// Returns the normal (Gaussian) distribution density function
        /// <para> with mean mu and standard deviation sd &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_normal_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double normal_cdf(Double mu, Double sd, Double x);


        /// <summary>
        /// Returns the functional inverse of the normal (Gaussian) distribution
        /// <para> with mean mu and standard deviation sd &gt; 0, 0 &lt; y &lt; 1. </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_normal_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double normal_qtf(Double mu, Double sd, Double x);


        // Missing : Normal maximum distribution

        // Missing : Normal maximum modulus distribution




        // {------------move to special real fuctions---------- Standard normal distribution --------------------------}

        /// <summary>
        /// Returns the std. normal probability density function exp(-x^2/2)/sqrt(2*Pi)
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_normstd_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double normstd_pdf(Double x);


        /// <summary>
        /// Returns the standard normal cumulative distribution function
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_normstd_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double normstd_cdf(Double x);


        /// <summary>
        /// Returns the inverse standard normal distribution function, 0 &lt; y &lt; 1.
        /// <para> For x=normstd_inv(y) and y from (0,1), normstd_cdf(x) = y </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_normstd_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double normstd_qtf(Double x);




        // Skew normal distribution

        public static Double skewnormal_pdf(Double a, Double b, Double c, Double x)
        {
            return dreal.dist_skewnormal(a, b, c).pdf(x);
        }

        public static Double skewnormal_cdf(Double a, Double b, Double c, Double x)
        {
            return dreal.dist_skewnormal(a, b, c).cdf(x);
        }

        public static Double skewnormal_qtf(Double a, Double b, Double c, Double q)
        {
            return dreal.dist_skewnormal(a, b, c).qtf(q);
        }




        // {---------------------- Wald or inverse Gaussian distribution --------------------------}

        /// <summary>
        /// Returns the Wald (inverse Gaussian) probability density
        /// <para> function with mean mu &gt; 0, scale b &gt; 0 for x &#8805; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wald_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double wald_pdf(Double mu, Double b, Double x);


        /// <summary>
        /// Returns the Wald (inverse Gaussian) probability cumulative distribution
        /// <para> function with mean mu &gt; 0, scale b &gt; 0 for x &#8805; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wald_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double wald_cdf(Double mu, Double b, Double x);


        /// <summary>
        /// Returns functional inverse of the Wald (inverse Gaussian)
        /// <para> distribution with mean mu &gt; 0, scale b &gt; 0, 0 &#8804; y &lt; 1. </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_wald_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double wald_qtf(Double mu, Double b, Double x);


        #endregion



        #region Distributions based on the incomplete gamma function



        // {---------------------- Chi distribution --------------------------}

        /// <summary>
        /// Returns the probability density function of the chi distribution, nu>0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chi_pdf(int nu, Double x);


        /// <summary>
        /// Returns the cumulative chi-sqr distribution with nu &gt; 0 degrees of freedom, x &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chi_cdf(int nu, Double x);


        /// <summary>
        /// Returns the functional inverse of the chi distribution, nu &gt; 0, 0 &#8804; p &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chi_qtf(int nu, Double p);





        // {---------------------- Chi-sqr distribution --------------------------}

        /// <summary>
        /// Returns the probability density function of the chi-sqr distribution, nu &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi2_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chi2_pdf(int nu, Double x);


        /// <summary>
        /// Returns the cumulative chi-sqr distribution with nu &gt; 0 degrees of freedom, x &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi2_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chi2_cdf(int nu, Double x);


        /// <summary>
        /// Returns the functional inverse of the chi-sqr distribution, nu &gt; 0, 0 &#8804; p &lt; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_chi2_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double chi2_qtf(int nu, Double p);





        // {---------------------- Gamma distribution --------------------------}

        /// <summary>
        /// Returns the probability density function of a gamma distribution with shape
        /// <para> a &gt; 0, scale b &gt; 0: gamma_pdf = x^(a-1)*exp(-x/b)/gamma(a)/b^a, x &gt; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_pdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the cumulative gamma distribution function, shape a &gt; 0, scale b &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the gamma distribution function, shape a &gt; 0,
        /// <para> scale b &gt; 0, 0 &#8804; p &#8804; 1, i.e. finds x such that gamma_cdf(a, b, x) = p </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_gamma_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double gamma_qtf(Double a, Double b, Double y);



        // {---------------------- Inverse Chi2 distribution --------------------------}


        public static Double inverse_chi2_pdf(Double a, Double b, Double x)
        {
            return dreal.dist_inverse_chi2(a, b).pdf(x);
        }

        public static Double inverse_chi2_cdf(Double a, Double b, Double x)
        {
            return dreal.dist_inverse_chi2(a, b).cdf(x);
        }

        public static Double inverse_chi2_qtf(Double a, Double b, Double q)
        {
            return dreal.dist_inverse_chi2(a, b).qtf(q);
        }


        // {---------------------- Inverse gamma distribution --------------------------}

        /// <summary>
        /// Returns the probability density function of an inverse gamma distribution
        /// <para> with shape a &gt; 0, scale b &gt; 0: result = (b/x)^a/x*exp(-b/x)/Gamma(a), x &#8805; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_invgamma_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double inverse_gamma_pdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the cumulative inverse gamma distribution function, shape a &gt; 0, scale
        /// <para> b &gt; 0: result = Gamma(a,b/x)/Gamma(a) = Q(a,b/x) = igammaq(a,b/x), x &#8805; 0 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_invgamma_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double inverse_gamma_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the inverse gamma distribution function, shape
        /// <para> a &gt; 0, scale b &gt; 0, 0 &#8804; y &#8804; 1, i.e. find x such that invgamma_cdf(a, b, x) = y </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_invgamma_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double inverse_gamma_qtf(Double a, Double b, Double y);




        // {---------------------- Maxwell distribution --------------------------}

        /// <summary>
        /// Returns the Maxwell probability density function with scale b &gt; 0, x &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_maxwell_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double maxwell_pdf(Double b, Double x);


        /// <summary>
        /// Returns the cumulative Maxwell distribution function with scale b &gt; 0, x &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_maxwell_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double maxwell_cdf(Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the Maxwell distribution with scale b &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_maxwell_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double maxwell_qtf(Double b, Double x);



        // {---------------------- Nakagami distribution --------------------------}

        /// <summary>
        /// Returns the probability density function of the Nakagami distribution with shape m>0, spread w>0, x>=0:
        /// <para> nakagami_pdf = 2x*gamma_pdf(m,w/m,x^2) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_nakagami_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double nakagami_pdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the cumulative Nakagami distribution function, shape m>0, spread w>0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_nakagami_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double nakagami_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the Nakagami distribution function, shape m &gt; 0, spread w &gt; 0, 0 &#8804; p &#8804; 1,
        /// <para> i.e. find x such that nakagami_cdf(m, w, x) = p </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_nakagami_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double nakagami_qtf(Double a, Double b, Double x);



        #endregion



        #region Distributions based on the incomplete beta function


        // {---------------------- beta distribution --------------------------}

        /// <summary>
        /// Returns the probability density function of the beta distribution with
        /// <para> parameters a and b: beta_pdf = x^(a-1)*(1-x)^(b-1) / beta(a,b) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_beta_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double beta_pdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the cumulative beta distribution function, a &gt; 0, b &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_beta_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double beta_cdf(Double a, Double b, Double x);


        /// <summary>
        /// Returns the functional inverse of the beta distribution function. a &gt; 0, b &gt; 0;
        /// <para> 0 &#8804; y &#8804; 1. Given y the function finds x such that beta_cdf(a, b, x) = y </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_beta_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double beta_qtf(Double a, Double b, Double y);





        // {---------------------- F-distribution --------------------------}

        /// <summary>
        /// Returns the probability density function of the F distribution; x &#8805; 0, nu1, nu2 &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_f_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fisher_f_pdf(int nu1, int nu2, Double x);



        /// <summary>
        /// Returns the cumulative F distribution function; x &#8805; 0, nu1, nu2 &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_f_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fisher_f_cdf(int nu1, int nu2, Double x);


        /// <summary>
        /// Returns the functional inverse of the F distribution, nu1, nu2 &gt; 0, 0 &#8804; y &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_f_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double fisher_f_qtf(int nu1, int nu2, Double x);



        // {---------------------- t-distribution --------------------------}

        /// <summary>
        /// Returns the probability density function of Student's t distribution, nu &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_t_pdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double student_t_pdf(int nu, Double x);


        /// <summary>
        /// Returns the cumulative Student t distribution with nu &gt; 0 degrees of freedom
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_t_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double student_t_cdf(int nu, Double x);


        /// <summary>
        /// Returns the functional inverse of Student's t distribution, nu &gt; 0, 0 &#8804; p &#8804; 1
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_t_inv", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double student_t_qtf(int nu, Double x);


        #endregion



        #region Noncentral distributions



        // {---------------------- Non-central chi2-distribution --------------------------}

        public static Double chi2_nc_pdf(Double n, Double lambda1, Double x)
        {
            return dreal.dist_chi2_nc(n, lambda1).pdf(x);
        }

        public static Double chi2_nc_cdf(Double n, Double lambda1, Double x)
        {
            return dreal.dist_chi2_nc(n, lambda1).cdf(x);
        }

        public static Double chi2_nc_qtf(Double n, Double lambda1, Double q)
        {
            return dreal.dist_chi2_nc(n, lambda1).qtf(q);
        }



        // {---------------------- Non-central Student t-distribution --------------------------}

        public static Double student_t_nc_pdf(Double n, Double delta, Double x)
        {
            return dreal.dist_student_t_nc(n, delta).pdf(x);
        }

        public static Double student_t_nc_cdf(Double n, Double delta, Double x)
        {
            return dreal.dist_student_t_nc(n, delta).cdf(x);
        }

        public static Double student_t_nc_qtf(Double n, Double delta, Double q)
        {
            return dreal.dist_student_t_nc(n, delta).qtf(q);
        }



        // {---------------------- Non-central Fisher F-distribution --------------------------}

        public static Double fisher_f_nc_pdf(Double m, Double n, Double lambda1, Double x)
        {
            return dreal.dist_fisher_f_nc(m, n, lambda1).pdf(x);
        }

        public static Double fisher_f_nc_cdf(Double m, Double n, Double lambda1, Double x)
        {
            return dreal.dist_fisher_f_nc(m, n, lambda1).cdf(x);
        }

        public static Double fisher_f_nc_qtf(Double m, Double n, Double lambda1, Double q)
        {
            return dreal.dist_fisher_f_nc(m, n, lambda1).qtf(q);
        }



        // {---------------------- Non-central Beta-distribution --------------------------}

        public static Double beta_nc_pdf(Double a, Double b, Double lambda1, Double x)
        {
            return dreal.dist_beta_nc(a, b, lambda1).pdf(x);
        }

        public static Double beta_nc_cdf(Double a, Double b, Double lambda1, Double x)
        {
            return dreal.dist_beta_nc(a, b, lambda1).cdf(x);
        }

        public static Double beta_nc_qtf(Double a, Double b, Double lambda1, Double q)
        {
            return dreal.dist_beta_nc(a, b, lambda1).qtf(q);
        }






        #endregion



        #region Miscellaneous distributions

        // {---------------------- Kolmogorov-Smirnov-distribution --------------------------}

        public static Double kolmogorov_smirnov_pdf(Double n, Double x)
        {
            return dreal.dist_kolmogorov_smirnov(n).pdf(x);
        }

        public static Double kolmogorov_smirnov_cdf(Double n, Double x)
        {
            return dreal.dist_kolmogorov_smirnov(n).cdf(x);
        }

        public static Double kolmogorov_smirnov_qtf(Double n, Double q)
        {
            return dreal.dist_kolmogorov_smirnov(n).qtf(q);
        }




        // {---------------------- Landau-distribution --------------------------}


        public static Double landau_pdf(Double mu, Double c, Double x)
        {
            return dreal.dist_landau(mu, c).pdf(x);
        }

        public static Double landau_cdf(Double mu, Double c, Double x)
        {
            return dreal.dist_landau(mu, c).cdf(x);
        }

        public static Double landau_qtf(Double mu, Double c, Double q)
        {
            return dreal.dist_landau(mu, c).qtf(q);
        }



        // {---------------------- Holtsmark-distribution --------------------------}

        public static Double holtsmark_pdf(Double mu, Double c, Double x)
        {
            return dreal.dist_holtsmark(mu, c).pdf(x);
        }

        public static Double holtsmark_cdf(Double mu, Double c, Double x)
        {
            return dreal.dist_holtsmark(mu, c).cdf(x);
        }

        public static Double holtsmark_qtf(Double mu, Double c, Double q)
        {
            return dreal.dist_holtsmark(mu, c).qtf(q);
        }



        // {---------------------- Mapairy-distribution --------------------------}


        public static Double mapairy_pdf(Double mu, Double c, Double x)
        {
            return dreal.dist_mapairy(mu, c).pdf(x);
        }

        public static Double mapairy_cdf(Double mu, Double c, Double x)
        {
            return dreal.dist_mapairy(mu, c).cdf(x);
        }

        public static Double mapairy_qtf(Double mu, Double c, Double q)
        {
            return dreal.dist_mapairy(mu, c).qtf(q);
        }


        // {---------------------- Saspoint5-distribution --------------------------}

        public static Double saspoint5_pdf(Double mu, Double c, Double x)
        {
            return dreal.dist_saspoint5(mu, c).pdf(x);
        }

        public static Double saspoint5_cdf(Double mu, Double c, Double x)
        {
            return dreal.dist_saspoint5(mu, c).cdf(x);
        }

        public static Double saspoint5_qtf(Double mu, Double c, Double q)
        {
            return dreal.dist_saspoint5(mu, c).qtf(q);
        }






        #endregion




        #region Basic lattice distributions



        // {---------------------- Bernoulli distribution --------------------------}

        public static Double bernoulli_pmf(Double p, int k)
        {
            return dreal.dist_bernoulli(p).pmf(k);
        }

        public static Double bernoulli_cdf(Double p, int k)
        {
            return dreal.dist_bernoulli(p).cdf(k);
        }

        public static Double bernoulli_qtf(Double p, Double q)
        {
            return dreal.dist_bernoulli(p).qtf(q);
        }




        // {---------------------- Geometric distribution --------------------------}

        public static Double geometric_pmf(Double p, int k)
        {
            return dreal.dist_geometric(p).pmf(k);
        }

        public static Double geometric_cdf(Double p, int k)
        {
            return dreal.dist_geometric(p).cdf(k);
        }

        public static Double geometric_qtf(Double p, Double q)
        {
            return dreal.dist_geometric(p).qtf(q);
        }



        // {---------------------- Logarithmic (series) distribution --------------------------}

        /// <summary>
        /// Returns the logarithmic (series) probability mass function
        /// <para> with shape 0 &lt; a &lt; 1, k &gt; 0; result = -a^k/(k*ln(1-a)) </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logseries_pmf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logseries_pmf(Double a, int k);


        /// <summary>
        /// Returns the cumulative logarithmic (series) distribution function with shape 0 &lt; a &lt; 1, k &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_logseries_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double logseries_cdf(Double a, int k);



        // {---------------------- Poisson distribution --------------------------}

        /// <summary>
        /// Returns the Poisson distribution probability mass function with mean mu &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_poisson_pmf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double poisson_pmf(Double mu, int x);


        /// <summary>
        /// Returns the cumulative Poisson distribution function with mean mu &#8805; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_poisson_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double poisson_cdf(Double mu, int x);


        public static Double poisson_qtf(Double mu, Double q)
        {
            return dreal.dist_poisson(mu).qtf(q);
        }




        // {---------------------- binomial distribution --------------------------}

        /// <summary>
        /// Returns the binomial distribution probability mass function with number
        /// <para> of trials n &#8805; 0 and success probability 0 &#8804; p &#8804; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_binomial_pmf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_binomial_pmf(Double p, int n, int k);


        public static Double binomial_pmf(int n, Double p, int k)
        {
            return damath_binomial_pmf(p, dreal.lrint(n), k);
        }




        /// <summary>
        /// Returns the cumulative binomial distribution function with number
        /// <para> of trials n &#8805; 0 and success probability 0 &#8804; p &#8804; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_binomial_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_binomial_cdf(Double p, int n, int k);


        public static Double binomial_cdf(int n, Double p, int k)
        {
            return damath_binomial_cdf(p, dreal.lrint(n), k);
        }


        public static Double binomial_qtf(int n, Double p, Double q)
        {
            return dreal.dist_binomial(n, p).qtf(q);
        }




        // {---------------------- Negative binomial distribution --------------------------}

        /// <summary>
        /// Returns the negative binomial distribution probability mass function with target
        /// <para> for number of successful trials r &gt; 0 and success probability 0 &#8804; p &#8804; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_negbinom_pmf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_negbinom_pmf(Double p, Double r, int k);

        public static Double negbinomial_pmf(int r, Double p, int k)
        {
            return damath_negbinom_pmf(p, r, k);
        }



        /// <summary>
        /// Returns the cumulative negative binomial distribution function with target
        /// <para> for number of successful trials r &gt; 0 and success probability 0 &#8804; p &#8804; 1 </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_negbinom_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_negbinom_cdf(Double p, Double r, int k);

        public static Double negbinomial_cdf(int r, Double p, int k)
        {
            return damath_negbinom_cdf(p, r, k);
        }


        public static Double negbinomial_qtf(int r, Double p, Double q)
        {
            return dreal.dist_negbinomial(r, p).qtf(q);
        }



        // {---------------------- Hypergeometric distribution --------------------------}

        /// <summary>
        /// Returns the hypergeometric distribution probability mass function; n,n1,n2 &#8805; 0, n &#8804; n1+n2;
        /// <para> i.e. the probability that among n randomly chosen samples from a container </para>
        /// <para> with n1 type1 objects and n2 type2 objects are exactly k type1 objects </para>
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hypergeo_pmf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_hypergeo_pmf(int n1, int n2, int n, int k);

        public static Double hypergeometric_pmf(ulong r, ulong n, ulong N, int k)
        {
            return damath_hypergeo_pmf((int)r, (int)(N - r), (int)n, (int)k);
        }


        /// <summary>
        /// Returns the cumulative hypergeometric distribution function; n,n1,n2 &#8805; 0, n &#8804; n1+n2
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_hypergeo_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double damath_hypergeo_cdf(int n1, int n2, int n, int k);

        public static Double hypergeometric_cdf(ulong r, ulong n, ulong N, int k)
        {
            return damath_hypergeo_cdf((int)r, (int)(N - r), (int)n, (int)k);
        }


        public static Double hypergeometric_qtf(ulong r, ulong n, ulong N, Double q)
        {
            return dreal.dist_hypergeometric(r, n, N).qtf(q);
        }



        // {---------------------- Zipf distribution --------------------------}

        /// <summary>
        /// Returns the Zipf distribution probability mass function k^(-(r+1))/zeta(r+1), r &gt; 0, k &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zipf_pmf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zeta_pmf(Double a, int k);


        /// <summary>
        /// Returns the cumulative Zipf distribution function H(k,r+1)/zeta(r+1), r &gt; 0, k &gt; 0
        /// </summary>
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zipf_cdf", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zeta_cdf(Double a, int k);







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
        public static Tuple<Double, Double, short> localmin(cb1SDouble1S f, Double a, Double b, Double eps, Double tol)
        {
            Double x = 0.0, fx = 0.0;
            short ic = 0;
            damath_localmin(f, a, b, eps, tol, ref x, ref fx, ref ic);
            return new Tuple<Double, Double, short>(x, fx, ic);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_localmin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_localmin(cb1SDouble1S f, Double a, Double b, Double eps, Double tol, ref Double x, ref Double fx, ref short ic);



        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/mbrent/*' />
        public static Tuple<Double, Double, short> mbrent(cb1SDouble1S f, Double a, Double b, Double tol)
        {
            Double x = 0.0, fx = 0.0;
            short ic = 0;
            damath_mbrent(f, a, b, tol, ref x, ref fx, ref ic);
            return new Tuple<Double, Double, short>(x, fx, ic);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_mbrent", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_mbrent(cb1SDouble1S f, Double a, Double b, Double t, ref Double x, ref Double fx, ref short ic);



        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/zbrent/*' />
        public static Tuple<Double, short, short> zbrent(cb1SDouble1S f, Double a, Double b, Double tol)
        {
            short ic = 0;
            short err = 0;
            Double Res = damath_zbrent(f, a, b, tol, ref ic, ref err);
            return new Tuple<Double, short, short>(Res, ic, err);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zbrent", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Double damath_zbrent(cb1SDouble1S f, Double a, Double b, Double tol, ref short ic, ref short err);




        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/zeroin/*' />
        [DllImport(xcn.libwe64d, EntryPoint = "damath_zeroin", CallingConvention = CallingConvention.Cdecl)]
        public static extern Double zeroin(cb1SDouble1S f, Double a, Double b, Double tol);








        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/quanc8/*' />
        public static Tuple<Double, Double, Double, int> quanc8(cb1SDouble1S f, Double a, Double b, Double abserr, Double relerr)
        {
            Double result = 0.0, errest = 0.0, flag = 0;
            int neval = 0;
            damath_quanc8(f, a, b, abserr, relerr, ref result, ref errest, ref flag, ref neval);
            return new Tuple<Double, Double, Double, int>(result, errest, flag, neval);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_quanc8", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_quanc8(cb1SDouble1S f, Double a, Double b, Double abserr, Double relerr, ref Double result, ref Double errest, ref Double flag, ref int neval);




        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/qags/*' />
        public static Tuple<Double, Double, int, short> qags(cb1SDouble1S f, Double a, Double b, Double epsabs, Double epsrel, int limit = 0)
        {
            Double result = 0.0, abserr = 0.0;
            int neval = 0;
            short ier = 0;
            damath_qags(f, a, b, epsabs, epsrel, limit, ref result, ref abserr, ref neval, ref ier);
            return new Tuple<Double, Double, int, short>(result, abserr, neval, ier);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_qags", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_qags(cb1SDouble1S f, Double a, Double b, Double epsabs, Double epsrel, int limit, ref Double result, ref Double abserr, ref int neval, ref short ier);




        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/qagi/*' />
        public static Tuple<Double, Double, int, short> qagi(cb1SDouble1S f, Double bound, int inf, Double epsabs, Double epsrel, int limit = 0)
        {
            Double result = 0.0, abserr = 0.0;
            int neval = 0;
            short ier = 0;
            damath_qagi(f, bound, inf, epsabs, epsrel, limit, ref result, ref abserr, ref neval, ref ier);
            return new Tuple<Double, Double, int, short>(result, abserr, neval, ier);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_qagi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_qagi(cb1SDouble1S f, Double bound, int inf, Double epsabs, Double epsrel, int limit, ref Double result, ref Double abserr, ref int neval, ref short ier);



        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/qawc/*' />
        public static Tuple<Double, Double, int, short> qawc(cb1SDouble1S f, Double a, Double b, Double c, Double epsabs, Double epsrel, short limit = 0)
        {
            Double result = 0.0, abserr = 0.0;
            int neval = 0;
            short ier = 0;
            damath_qawc(f, a, b, c, epsabs, epsrel, limit, ref result, ref abserr, ref neval, ref ier);
            return new Tuple<Double, Double, int, short>(result, abserr, neval, ier);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_qawc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_qawc(cb1SDouble1S f, Double a, Double b, Double c, Double epsabs, Double epsrel, short limit, ref Double result, ref Double abserr, ref int neval, ref short ier);




        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/intde/*' />
        public static Tuple<Double, Double, int, short> intde(cb1SDouble1S f, Double a, Double b, Double eps)
        {
            Double result = 0.0, abserr = 0.0;
            int neval = 0;
            short ier = 0;
            damath_intde(f, a, b, eps, ref result, ref abserr, ref neval, ref ier);
            return new Tuple<Double, Double, int, short>(result, abserr, neval, ier);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_intde", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_intde(cb1SDouble1S f, Double a, Double b, Double eps, ref Double result, ref Double abserr, ref int neval, ref short ier);


        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/intdei/*' />
        public static Tuple<Double, Double, int, short> intdei(cb1SDouble1S f, Double a, Double eps)
        {
            Double result = 0.0, abserr = 0.0;
            int neval = 0;
            short ier = 0;
            damath_intdei(f, a, eps, ref result, ref abserr, ref neval, ref ier);
            return new Tuple<Double, Double, int, short>(result, abserr, neval, ier);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_intdei", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_intdei(cb1SDouble1S f, Double a, Double eps, ref Double result, ref Double abserr, ref int neval, ref short ier);



        /// <include file="docs.xml" path='docs/members[@name="DAMath"]/intdeo/*' />
        public static Tuple<Double, Double, int, short> intdeo(cb1SDouble1S f, Double a, Double omega, Double eps)
        {
            Double result = 0.0, abserr = 0.0;
            int neval = 0;
            short ier = 0;
            damath_intdeo(f, a, omega, eps, ref result, ref abserr, ref neval, ref ier);
            return new Tuple<Double, Double, int, short>(result, abserr, neval, ier);
        }
        [DllImport(xcn.libwe64d, EntryPoint = "damath_intdeo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void damath_intdeo(cb1SDouble1S f, Double a, Double omega, Double eps, ref Double result, ref Double abserr, ref int neval, ref short ier);




        #endregion









        #region Numpy-compatible functions, real



        /// <summary>
        /// Return vec_p1
        /// </summary>
        public static void vec_p1(cb1SDouble1S f, Double[] a, Double[] res)
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
        public static void mat_p1(cb1SDouble1S f, Double[,] a, Double[,] res)
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




    }
}





