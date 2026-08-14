using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace FixedPrecNet
{


    public delegate Single cb1SSingle1S(Single x);


    public delegate void cbSingle1S1V(Single t, SingleVec x);

    public delegate void cbSingle1S2V(Single t, SingleVec x, SingleVec y);


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void cb2RefSingle(ref Single x, ref Single result);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void cb2Ptr1RefSingle(IntPtr x, IntPtr result, ref Single t);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void cb1Ptr1RefSingle(IntPtr x, ref Single t);


    public delegate void cbSingle2M(SingleMat x, SingleMat y);


    public delegate Single cb1SSingle1V(SingleVec x);

    public delegate void cbSingle2V(SingleVec x, SingleVec y);

    public delegate void cbSingle1V1M(SingleVec x, SingleMat y);





    public class SingleVec
    {

        public IntPtr mpPtr = IntPtr.Zero;

        public SingleVec()
        {
            xcn.Init();
            mpPtr = Lib_Eigen_SReal_Init_Func(constants.mp_eigen, constants.mp_real);
        }

        public SingleVec(int N)
        {
            xcn.Init();
            mpPtr = Lib_Eigen_SReal_Init_Func(constants.mp_eigen, constants.mp_real);
            Lib_Eigen_SReal_SetSpecialValue(constants.mp_eigen, constants.mp_real, mpPtr, constants.mp_Resize, N, 1);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_Eigen_SReal_Init_Func(int mpCat, int mpType);
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_SetSpecialValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_SetSpecialValue(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int m, int n);


        ~SingleVec()
        {
            Lib_Eigen_SReal_Clear(constants.mp_eigen, constants.mp_real, mpPtr);
        }

        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Clear(int mpCat, int mpType, IntPtr AnyPtr);


        public int Size
        {
            get
            {
                return Lib_Eigen_SReal_GetInfo(constants.mp_eigen, constants.mp_real, constants.mp_const_size, mpPtr);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_GetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_Eigen_SReal_GetInfo(int mpCat, int mpType, int what, IntPtr MatrixPtr_source);


        public Single this[int row_i]
        {
            get
            {
                var result = new Single();
                Eigen_SReal_GetCoeff(ref result, row_i, 0, mpPtr);
                return result;
            }

            set
            {
                Eigen_SReal_SetCoeff(mpPtr, ref value, row_i, 0);
            }

        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_GetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_SReal_GetCoeff(ref Single result, int row, int col, IntPtr MatrixPtr_source);

        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_SetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_SReal_SetCoeff(IntPtr MatrixPtr_result, ref Single in1, int row, int col);


    }








    /// <summary>
    /// Provides numerical functions in single precision, based on Boost Math/Multiprecision
    /// </summary>
    public class sreal
    {

        public static String fmt(Single x)
        {
            string s = " " + x.ToString("G7", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
            return s;
        }


        public static String fmt(Double x)
        {
            return fmt(t(x));
        }


        public static String fmt(dynamic x)
        {
            return fmt(t(x));
        }


        #region VecParams


        public static SingleVec VecParams(params dynamic[] args)
        {
            int N = args.Length;
            var matX3 = new SingleVec(N);
            for (int i = 0; i < N; i++)
                matX3[i] = t(args[i]);


            return matX3;
        }




        #endregion



        #region General

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/name/*' />
        public static String name
        {
            get { return "sreal"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  sreal"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/prec/*' />
        public static Int32 prec
        {
            get { return 24; }
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
        public static sreal realctx
        {
            get { return new sreal(); }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static scplx cplxctx
        {
            get { return new scplx(); }
        }


        #endregion



        #region Conversions

        // Note: the conversion from dynamic needs to be at the top of this list

        /// <summary>
        /// Returns a new Single using a dynamic (an object whose operations will be resolved at runtime) as input
        /// </summary>
        public static Single t(dynamic x)
        {
            //MessageBox.Show("In sboost_t t(dynamic i)");
            string s = x.ToString();
            if (s.Contains("/"))
            {
                var res = s.Split('/');
                return t(res[0]) / t(res[1]);
            }
            else
            {
                return t(s);
            }
        }




        /// <summary>
        /// Returns a new Single using a octuple precision binary floating point number as input
        /// </summary>
        public static Single t(Octuple x)
        {
            Single res = 0.0F;
            Lib_OReal_Get_S(ref res, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Get_S", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Get_S(ref Single res, IntPtr x);


        /// <summary>
        /// Returns a new Single using a quadruple precision binary floating point number as input
        /// </summary>
        public static Single t(Quadruple x)
        {
            Single res = 0.0F;
            Lib_SReal_Set_QReal(ref res, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Set_QReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Set_QReal(ref Single res, IntPtr x);



        /// <summary>
        /// Returns a new Single using an extended precision floating point number as input
        /// </summary>
        public static Single t(Extended x)
        {
            Single res = 0.0F;
            Lib_SReal_Set_LD(ref res, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Set_LD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Set_LD(ref Single res, IntPtr x);



        /// <summary>
        /// Returns a new sboost_t using a Double precision floating point number as input
        /// </summary>
        public static Single t(Double d)
        {
            return (float)d;
        }



        /// <summary>
        /// Returns a Single using a single precision binary floating point number as input
        /// </summary>
        public static Single t(Single x)
        {
            return +x;
        }


        /// <summary>
        /// Returns a Single using a signed 32 bit integer as input
        /// </summary>
        public static Single t(Int32 si)
        {
            return (float)si;
        }



        /// <summary>
        /// Returns a Single using an unsigned 32 bit integer as input
        /// </summary>
        public static Single t(UInt32 ui)
        {
            return (float)ui;
        }



        /// <summary>
        /// Returns a Single using a signed 64 bit integer as input
        /// </summary>
        public static Single t(Int64 si64)
        {
            return (float)si64;
        }


        /// <summary>
        /// Returns a Single using an unsigned 64 bit integer as input
        /// </summary>
        public static Single t(UInt64 ui64)
        {
            return (float)ui64;
        }


        /// <summary>
        /// Returns a Single using an arbitrary precision integer as input
        /// </summary>
        public static Single t(BigInteger i)
        {
            return (float)i;
        }


        /// <summary>
        /// Returns a Single using a System.Decimal as input
        /// </summary>
        public static Single t(decimal dec)
        {
            return (float)dec;
        }



        /// <summary>
        /// Returns a Single using a string as input
        /// </summary>
        public static Single t(string s)
        {
            var res = 0.0F;
            Lib_SReal_Set_Str(ref res, s);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Set_Str", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Set_Str(ref Single res, string s);






        #endregion




        #region Basic Arithmetic


        public static Single add(Single x, Single y)
        {
            return x + y;
        }
        public static Single add(dynamic x, dynamic y)
        {
            return t(x) + t(y);
        }

        public static void rawadd(ref Single res, Single x, Single y)
        {
            res = x + y;
        }



        public static Single subtract(Single x, Single y)
        {
            return x - y;
        }
        public static Single subtract(dynamic x, dynamic y)
        {
            return t(x) - t(y);
        }

        public static void rawsub(ref Single res, Single x, Single y)
        {
            res = x - y;
        }



        public static Single multiply(Single x, Single y)
        {
            return x * y;
        }
        public static Single multiply(dynamic x, dynamic y)
        {
            return t(x) * t(y);
        }

        public static void rawmul(ref Single res, Single x, Single y)
        {
            res = x * y;
        }



        public static Single divide(Single x, Single y)
        {
            return x / y;
        }
        public static Single divide(dynamic x, dynamic y)
        {
            return t(x) / t(y);
        }

        public static void rawdiv(ref Single res, Single x, Single y)
        {
            res = x / y;
        }


        #endregion







        #region Basic floating point functions




        #region General functions for real numbers


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fma/*' />
        public static Single fma(Single x, Single y, Single z)
        {
            return x * y + z;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fma/*' />
        public static Single fma(dynamic x, dynamic y, dynamic z)
        {
            return fma(t(x), t(y), t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmax/*' />
        public static Single fmax(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Fmax(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Fmax", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Fmax(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmax/*' />
        public static Single fmax(dynamic x, dynamic y)
        {
            return fmax(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmin/*' />
        public static Single fmin(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Fmax(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Fmin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Fmin(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmin/*' />
        public static Single fmin(dynamic x, dynamic y)
        {
            return fmin(t(x), t(y));
        }


        #endregion



        #region Machine constants


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/zero/*' />
        public static Single zero()
        {
            return 0.0F;
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/negzero/*' />
        public static Single negzero()
        {
            return -0.0F;
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/one/*' />
        public static Single one()
        {
            return 1.0F;
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/onej/*' />
        public static SingleC onej()
        {
            return scplx.t(0, 1);
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isposinf/*' />
        public static Single inf()
        {
            return Single.PositiveInfinity;
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/neginf/*' />
        public static Single neginf()
        {
            return -Single.PositiveInfinity;
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/nan/*' />
        public static Single nan()
        {
            return Single.NaN;
        }



        #endregion



        #region Properties of numbers


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/signbit/*' />
        public static int signbit(Single x)
        {
            return Lib_SReal_Signbit(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Signbit", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_Signbit(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/signbit/*' />
        public static int signbit(dynamic x)
        {
            return signbit(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isfinite/*' />
        public static bool isfinite(Single x)
        {
            return 0 != Lib_SReal_Finite(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Finite", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_Finite(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isfinite/*' />
        public static bool isfinite(dynamic x)
        {
            return isfinite(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isinf/*' />
        public static bool isinf(Single x)
        {
            return 0 != (Lib_SReal_Isinf(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Isinf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_Isinf(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isinf/*' />
        public static bool isinf(dynamic x)
        {
            return isinf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isposinf/*' />
        public static bool isposinf(Single x)
        {
            return 0 != (Lib_SReal_Isposinf(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Isposinf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_Isposinf(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isposinf/*' />
        public static bool isposinf(dynamic x)
        {
            return isposinf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isneginf/*' />
        public static bool isneginf(Single x)
        {
            return 0 != (Lib_SReal_Isneginf(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Isneginf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_Isneginf(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isneginf/*' />
        public static bool isneginf(dynamic x)
        {
            return isneginf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnan/*' />
        public static bool isnan(Single x)
        {
            return 0 != (Lib_SReal_Isnan(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Isnan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_Isnan(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isnan/*' />
        public static bool isnan(dynamic x)
        {
            return isnan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/iszero/*' />
        public static bool iszero(Single x)
        {
            return 0 != (Lib_SReal_Iszero(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Iszero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_Iszero(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/iszero/*' />
        public static bool iszero(dynamic x)
        {
            return iszero(t(x));
        }




        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/IsNegativeZero/*' />
        //public static bool IsNegativeZero(sboost_t x)
        //{
        //    return 0 != (Lib_SReal_Isnegzero(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Isnegzero", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_SReal_Isnegzero(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/IsNegativeZero/*' />
        //public static bool IsNegativeZero(dynamic x)
        //{
        //    return IsNegativeZero(t(x));
        //}



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isone/*' />
        public static bool isone(Single x)
        {
            return 0 != (Lib_SReal_Isone(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Isone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_Isone(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isone/*' />
        public static bool isone(dynamic x)
        {
            return isone(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isinteger/*' />
        public static bool isinteger(Single x)
        {
            return 0 != (Lib_SReal_Isinteger(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Isinteger", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_Isinteger(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isinteger/*' />
        public static bool isinteger(dynamic x)
        {
            return isinteger(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnumber/*' />
        public static bool isnumber(Single x)
        {
            return 0 != (Lib_SReal_Isnumber(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Isnumber", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_Isnumber(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isnumber/*' />
        public static bool isnumber(dynamic x)
        {
            return isnumber(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isregular/*' />
        public static bool isregular(Single x)
        {
            return 0 != (Lib_SReal_Isregular(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Isregular", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_Isregular(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isregular/*' />
        public static bool isregular(dynamic x)
        {
            return isregular(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnormal/*' />
        public static bool isnormal(Single x)
        {
            return 0 != (Lib_SReal_Isnormal(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Isnormal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_Isnormal(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isnormal/*' />
        public static bool isnormal(dynamic x)
        {
            return isnormal(t(x));
        }



        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/IsSubnormal/*' />
        //public static bool IsSubnormal(sboost_t x)
        //{
        //    return 0 != (Lib_SReal_Issubnormal(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Issubnormal", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_SReal_Issubnormal(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/IsSubnormal/*' />
        //public static bool IsSubnormal(dynamic x)
        //{
        //    return IsSubnormal(t(x));
        //}



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isunordered/*' />
        public static bool isunordered(Single x, Single y)
        {
            return 0 != (Lib_SReal_Isunordered(ref x, ref y));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Isunordered", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_Isunordered(ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isunordered/*' />
        public static bool isunordered(dynamic x, dynamic y)
        {
            return isunordered(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/fitsint32/*' />
        public static bool fitsint32(Single x)
        {
            return 0 != (Lib_SReal_FitsInt32(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_FitsInt32", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_FitsInt32(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fitsint32/*' />
        public static bool fitsint32(dynamic x)
        {
            return fitsint32(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/fitsint64/*' />
        public static bool fitsint64(Single x)
        {
            return 0 != (Lib_SReal_FitsInt64(ref x));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_FitsInt64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_SReal_FitsInt64(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fitsint64/*' />
        public static bool fitsint64(dynamic x)
        {
            return fitsint64(t(x));
        }



        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/FitsUInt32/*' />
        //public static bool FitsUInt32(sboost_t x)
        //{
        //    return 0 != (Lib_SReal_FitsUInt32(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_FitsUInt32", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_SReal_FitsUInt32(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/FitsUInt32/*' />
        //public static bool FitsUInt32(dynamic x)
        //{
        //    return FitsUInt32(t(x));
        //}



        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/FitsUInt64/*' />
        //public static bool FitsUInt64(sboost_t x)
        //{
        //    return 0 != (Lib_SReal_FitsUInt64(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_FitsUInt64", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_SReal_FitsUInt64(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/FitsUInt64/*' />
        //public static bool FitsUInt64(dynamic x)
        //{
        //    return FitsUInt64(t(x));
        //}




        #endregion



        #region Integer Related Functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nearbyint/*' />
        public static Single nearbyint(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Nearbyint(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Nearbyint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Nearbyint(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nearbyint/*' />
        public static Single nearbyint(dynamic x)
        {
            return nearbyint(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rint/*' />
        public static Single rint(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Rint(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Rint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Rint(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rint/*' />
        public static Single rint(dynamic x)
        {
            return rint(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lrint/*' />
        public static Int32 lrint(Single x)
        {
            return Lib_SReal_Lrint(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Lrint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_SReal_Lrint(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lrint/*' />
        public static Int32 lrint(dynamic x)
        {
            return lrint(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llrint/*' />
        public static Int64 llrint(Single x)
        {
            return Lib_SReal_Llrint(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Llrint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int64 Lib_SReal_Llrint(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llrint/*' />
        public static Int64 llrint(dynamic x)
        {
            return llrint(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ceil/*' />
        public static Single ceil(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Ceil(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Ceil", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Ceil(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ceil/*' />
        public static Single ceil(dynamic x)
        {
            return ceil(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/floor/*' />
        public static Single floor(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Floor(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Floor", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Floor(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/floor/*' />
        public static Single floor(dynamic x)
        {
            return floor(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/trunc/*' />
        public static Single trunc(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Trunc(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Trunc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Trunc(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/trunc/*' />
        public static Single trunc(dynamic x)
        {
            return trunc(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/round/*' />
        public static Single round(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Round(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Round", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Round(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/round/*' />
        public static Single round(dynamic x)
        {
            return round(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lround/*' />
        public static Int32 lround(Single x)
        {
            return Lib_SReal_Lround(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Lround", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_SReal_Lround(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lround/*' />
        public static Int32 lround(dynamic x)
        {
            return lround(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llround/*' />
        public static Int64 llround(Single x)
        {
            return Lib_SReal_Llround(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Llround", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int64 Lib_SReal_Llround(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llround/*' />
        public static Int64 llround(dynamic x)
        {
            return llround(t(x));
        }




        #endregion



        #region Floating point functions for real numbers


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/copysign/*' />
        public static Single copysign(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Copysign(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Copysign", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Copysign(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/copysign/*' />
        public static Single copysign(dynamic x, dynamic y)
        {
            return copysign(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/frexp/*' />
        public static Tuple<Single, Int32> frexp(Single x)
        {
            Single res = 0.0F;
            Int32 e = 0;
            Lib_SReal_Frexp(ref res, ref x, ref e);
            return new Tuple<Single, int>(res, e);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Frexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Frexp(ref Single res, ref Single x, ref Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/frexp/*' />
        public static Tuple<Single, Int32> frexp(dynamic x)
        {
            return frexp(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logb/*' />
        public static Single logb(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Logb(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Logb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Logb(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logb/*' />
        public static Single logb(dynamic x)
        {
            return logb(t(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ilogb/*' />
        public static Int32 ilogb(Single x)
        {
            return Lib_SReal_Ilogb(ref x);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Ilogb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_SReal_Ilogb(ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ilogb/*' />
        public static Int32 ilogb(dynamic x)
        {
            return ilogb(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ldexp/*' />
        public static Single ldexp(Single x, Int32 e)
        {
            Single res = 0.0F;
            Lib_SReal_Ldexp(ref res, ref x, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Ldexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Ldexp(ref Single res, ref Single x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ldexp/*' />
        public static Single ldexp(dynamic x, dynamic e)
        {
            return ldexp(t(x), lround(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbn/*' />
        public static Single scalbn(Single x, Int32 e)
        {
            Single res = 0.0F;
            Lib_SReal_Scalbn(ref res, ref x, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Scalbn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Scalbn(ref Single res, ref Single x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbn/*' />
        public static Single scalbn(dynamic x, dynamic e)
        {
            return scalbn(t(x), lround(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbln/*' />
        public static Single scalbln(Single x, Int32 e)
        {
            Single res = 0.0F;
            Lib_SReal_Scalbln(ref res, ref x, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Scalbln", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Scalbln(ref Single res, ref Single x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbln/*' />
        public static Single scalbln(dynamic x, dynamic e)
        {
            return scalbln(t(x), lround(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fdim/*' />
        public static Single fdim(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Fdim(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Fdim", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Fdim(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fdim/*' />
        public static Single fdim(dynamic x, dynamic y)
        {
            return fdim(t(x), t(y));
        }


        #endregion



        #region Fraction and remainder Related Functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/modf/*' />
        public static Tuple<Single, Single> modf(Single x)
        {
            Single iptr = 0.0F;
            Single frac = 0.0F;
            Lib_SReal_Modf(ref frac, ref x, ref iptr);
            return new Tuple<Single, Single>(iptr, frac);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Modf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Modf(ref Single frac, ref Single x, ref Single iptr);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/modf/*' />
        public static Tuple<Single, Single> modf(dynamic x)
        {
            return modf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmod/*' />
        public static Single fmod(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Fmod(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Fmod", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Fmod(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmod/*' />
        public static Single fmod(dynamic x, dynamic y)
        {
            return fmod(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remainder/*' />
        public static Single remainder(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Remainder(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Remainder", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Remainder(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remainder/*' />
        public static Single remainder(dynamic x, dynamic y)
        {
            return remainder(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remquo/*' />
        public static Tuple<Single, Int32> remquo(Single x, Single y)
        {
            Single res = 0.0F;
            Int32 e = 0;
            Lib_SReal_Remquo(ref res, ref x, ref y, ref e);
            return new Tuple<Single, int>(res, e);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Remquo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Remquo(ref Single res, ref Single x, ref Single y, ref Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remquo/*' />
        public static Tuple<Single, Int32> remquo(dynamic x, dynamic y)
        {
            return remquo(t(x), t(y));
        }

        #endregion



        #region Functions related to mantissa width and exponent range


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/epsilon/*' />
        public static Single epsilon()
        {
            Single res = 0.0F;
            Lib_SReal_Epsilon(ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Epsilon", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Epsilon(ref Single res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ulp/*' />
        public static Single ulp(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Ulp(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Ulp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Ulp(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ulp/*' />
        public static Single ulp(dynamic x)
        {
            return ulp(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/maxvalue/*' />
        public static Single maxvalue()
        {
            Single res = 0.0F;
            Lib_SReal_Max(ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Max", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Max(ref Single res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/lowestvalue/*' />
        public static Single lowestvalue()
        {
            Single res = 0.0F;
            Lib_SReal_Lowest(ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Lowest", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Lowest(ref Single res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/minposvalue/*' />
        public static Single minposvalue()
        {
            Single res = 0.0F;
            Lib_SReal_Min(ref res);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Min", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Min(ref Single res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextafter/*' />
        public static Single nextafter(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Nexttoward(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Nexttoward", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Nexttoward(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextafter/*' />
        public static Single nextafter(dynamic x, dynamic y)
        {
            return nextafter(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextabove/*' />
        public static Single nextabove(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Nextabove(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Nextabove", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Nextabove(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextabove/*' />
        public static Single nextabove(dynamic x)
        {
            return nextabove(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextbelow/*' />
        public static Single nextbelow(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Nextbelow(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Nextbelow", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Nextbelow(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextbelow/*' />
        public static Single nextbelow(dynamic x)
        {
            return nextbelow(t(x));
        }


        #endregion



        #region Mathematical Constants


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/degree/*' />
        public static Single degree()
        {
            return 0.017453292519943295F;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phi/*' />
        public static Single phi()
        {
            return 1.6180339887498949F;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ln2/*' />
        public static Single ln2()
        {
            return 0.69314718055994529F;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ln10/*' />
        public static Single ln10()
        {
            return 2.3025850929940459F;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pi/*' />
        public static Single pi()
        {
            return 3.14159265358979F;
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/e/*' />
        public static Single e()
        {
            return 2.718281828459045F;
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/egamma/*' />
        public static Single egamma()
        {
            return 0.57721566490153287F;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/apery/*' />
        public static Single apery()
        {
            return 1.2020569031595942F;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/catalan/*' />
        public static Single catalan()
        {
            return 0.915965594177219F;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/glaisher/*' />
        public static Single glaisher()
        {
            return 1.2824271291006226F;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/khinchin/*' />
        public static Single khinchin()
        {
            return 2.6854520010653062F;
        }


        #endregion




        #endregion




        #region Elementary scalar functions




        #region Complex components


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Single abs(Single x)
        {
            return Math.Abs(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Single abs(dynamic x)
        {
            return abs(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Single fabs(Single x)
        {
            return Math.Abs(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Single fabs(dynamic x)
        {
            return fabs(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static Single sign(Single x)
        {
            return Math.Sign(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static Single sign(dynamic x)
        {
            return sign(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Single real(Single x)
        {
            return +x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Single real(dynamic x)
        {
            return real(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Single imag(Single x)
        {
            return 0.0F;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Single imag(dynamic x)
        {
            return 0.0F;
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Single phase(Single x)
        {
            if (x >= 0.0F) return 0.0F;
            else return pi();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Single phase(dynamic x)
        {
            return phase(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static Single conj(Single x)
        {
            return +x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static Single conj(dynamic x)
        {
            return conj(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Single, Single> polar(Single x)
        {
            return new Tuple<Single, Single>(abs(x), phase(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Single, Single> polar(dynamic x)
        {
            return polar(sreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rect/*' />
        public static SingleC rect(Single r, Single phi)
        {
            return r * expj(phi);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rect/*' />
        public static SingleC rect(dynamic r, dynamic phi)
        {
            return rect(sreal.t(r), sreal.t(phi));
        }






        #endregion



        #region Roots and quadratic, cubic, and quartic 


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static Single sqrt(Single x)
        {
            return (float)Math.Sqrt(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static Single sqrt(dynamic x)
        {
            return sqrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sqrt1pm1/*' />
        public static Single sqrt1pm1(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Sqrt1pm1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Sqrt1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Sqrt1pm1(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sqrt1pm1/*' />
        public static Single sqrt1pm1(dynamic x)
        {
            return sqrt1pm1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Single rsqrt(Single x)
        {
            return t(1) / sqrt(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Single rsqrt(dynamic x)
        {
            return rsqrt(t(x)); ;
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static Single cbrt(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Cbrt(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Cbrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Cbrt(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static Single cbrt(dynamic x)
        {
            return cbrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static Single root_si(Single x, int k)
        {
            var res = new Single();
            Lib_SReal_Root_Si(ref res, ref x, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Root_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Root_Si(ref Single res, ref Single x, int k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static Single root_si(dynamic x, int k)
        {
            return root_si(t(x), k);
        }



        #endregion



        #region Exponential and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static Single exp(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Exp(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Exp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Exp(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static Single exp(dynamic x)
        {
            return exp(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static SingleC expj(Single x)
        {
            return cos(x) + onej() * sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static SingleC expj(dynamic x)
        {
            return expj(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static SingleC expjpi(Single x)
        {
            return cospi(x) + onej() * sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static SingleC expjpi(dynamic x)
        {
            return expjpi(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Single exp2(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Exp2(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Exp2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Exp2(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Single exp2(dynamic x)
        {
            return exp2(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static Single exp10(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Exp10(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Exp10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Exp10(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static Single exp10(dynamic x)
        {
            return exp10(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Single expm1(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Expm1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Expm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Expm1(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Single expm1(dynamic x)
        {
            return expm1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Single exp2m1(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Exp2m1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Exp2m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Exp2m1(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Single exp2m1(dynamic x)
        {
            return exp2m1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static Single exp10m1(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Exp10m1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Exp10m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Exp10m1(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static Single exp10m1(dynamic x)
        {
            return exp10m1(t(x));
        }




        #endregion



        #region Logarithms and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static Single log(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Log(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Log", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Log(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static Single log(dynamic x)
        {
            return log(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Single log2(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Log2(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Log2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Log2(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Single log2(dynamic x)
        {
            return log2(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Single log10(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Log10(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Log10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Log10(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Single log10(dynamic x)
        {
            return log10(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Single log1p(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Log1p(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Log1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Log1p(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Single log1p(dynamic x)
        {
            return log1p(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static Single log2p1(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Log2p1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Log2p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Log2p1(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static Single log2p1(dynamic x)
        {
            return log2p1(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static Single log10p1(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Log10p1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Log10p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Log10p1(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static Single log10p1(dynamic x)
        {
            return log10p1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logaddexp/*' />
        public static Single logaddexp(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Logaddexp(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Logaddexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Logaddexp(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logaddexp/*' />
        public static Single logaddexp(dynamic x, dynamic y)
        {
            return logaddexp(t(x), t(y));
        }





        #endregion



        #region Power functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static Single sqr(Single x)
        {
            return x * x;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static Single sqr(dynamic x)
        {
            return sqr(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static Single cube(Single x)
        {
            return x * x * x;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static Single cube(dynamic x)
        {
            return cube(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static Single hypot(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Hypot(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Hypot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Hypot(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static Single hypot(dynamic x, dynamic y)
        {
            return hypot(t(x), t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static Single pow(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Pow(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Pow", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Pow(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static Single pow(dynamic x, dynamic y)
        {
            return pow(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/powm1/*' />
        public static Single powm1(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Powm1(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Powm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Powm1(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/powm1/*' />
        public static Single powm1(dynamic x, dynamic y)
        {
            return powm1(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1p/*' />
        public static Single pow1p(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Pow1p(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Pow1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Pow1p(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1p/*' />
        public static Single pow1p(dynamic x, dynamic y)
        {
            return pow1p(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1pm1/*' />
        public static Single pow1pm1(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Pow1pm1(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Pow1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Pow1pm1(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1pm1/*' />
        public static Single pow1pm1(dynamic x, dynamic y)
        {
            return pow1p(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow_si/*' />
        public static Single pow_si(Single x, int n)
        {
            Single res = 0.0F;
            Lib_SReal_Pow_Si(ref res, ref x, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Pow_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Pow_Si(ref Single res, ref Single x, int n);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow_si/*' />
        public static Single pow_si(dynamic x, int n)
        {
            return pow_si(t(x), n);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/compound_si/*' />
        public static Single compound_si(Single x, int n)
        {
            Single res = 0.0F;
            Lib_SReal_Compound_Si(ref res, ref x, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Compound_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Compound_Si(ref Single res, ref Single x, int n);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/compound_si/*' />
        public static Single compound_si(dynamic x, int n)
        {
            return compound_si(t(x), n);
        }






        #endregion



        #region Trigonometric and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Single sin(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Sin(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Sin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Sin(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Single sin(dynamic x)
        {
            return sin(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static Single cos(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Cos(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Cos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Cos(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static Single cos(dynamic x)
        {
            return cos(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static Single tan(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Tan(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Tan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Tan(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static Single tan(dynamic x)
        {
            return tan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static Single csc(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Csc(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Csc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Csc(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static Single csc(dynamic x)
        {
            return csc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static Single sec(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Sec(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Sec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Sec(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static Single sec(dynamic x)
        {
            return csc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static Single cot(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Cot(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Cot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Cot(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static Single cot(dynamic x)
        {
            return cot(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinpi/*' />
        public static Single sinpi(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_SinPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_SinPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_SinPi(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinpi/*' />
        public static Single sinpi(dynamic x)
        {
            return sinpi(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cospi/*' />
        public static Single cospi(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_CosPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_CosPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_CosPi(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cospi/*' />
        public static Single cospi(dynamic x)
        {
            return cospi(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/tanpi/*' />
        public static Single tanpi(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_TanPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_TanPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_TanPi(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/tanpi/*' />
        public static Single tanpi(dynamic x)
        {
            return tanpi(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cscpi/*' />
        public static Single cscpi(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_CscPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_CscPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_CscPi(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cscpi/*' />
        public static Single cscpi(dynamic x)
        {
            return cscpi(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/secpi/*' />
        public static Single secpi(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_SecPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_SecPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_SecPi(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/secpi/*' />
        public static Single secpi(dynamic x)
        {
            return secpi(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cotpi/*' />
        public static Single cotpi(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_CotPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_CotPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_CotPi(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cotpi/*' />
        public static Single cotpi(dynamic x)
        {
            return cotpi(t(x));
        }






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinc/*' />
        public static Single sinc(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_SincPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_SincPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_SincPi(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinc/*' />
        public static Single sinc(dynamic x)
        {
            return sinc(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sincpi/*' />
        public static Single sincpi(Single x)
        {
            Single x1 = x * sreal.pi();

            if (sreal.abs(x) < 0.1f)
            {
                return sinc(x1);
            }
            else return sinpi(x) / x1;
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sincpi/*' />
        public static Single sincpi(dynamic x)
        {
            return sincpi(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinhcpi/*' />
        public static Single sinhcpi(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_SinhcPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_SinhcPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_SinhcPi(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinhcpi/*' />
        public static Single sinhcpi(dynamic x)
        {
            return sinhcpi(t(x));
        }




        #endregion



        #region Hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static Single sinh(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Sinh(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Sinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Sinh(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static Single sinh(dynamic x)
        {
            return sinh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static Single cosh(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Cosh(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Cosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Cosh(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static Single cosh(dynamic x)
        {
            return cosh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static Single tanh(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Tanh(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Tanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Tanh(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static Single tanh(dynamic x)
        {
            return tanh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static Single csch(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Csch(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Csch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Csch(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static Single csch(dynamic x)
        {
            return csch(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static Single sech(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Sech(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Sech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Sech(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static Single sech(dynamic x)
        {
            return sech(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static Single coth(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Coth(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Coth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Coth(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static Single coth(dynamic x)
        {
            return coth(t(x));
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static Single asin(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Asin(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Asin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Asin(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static Single asin(dynamic x)
        {
            return asin(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static Single acos(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Acos(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Acos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Acos(ref Single res, ref Single x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static Single acos(dynamic x)
        {
            return acos(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static Single atan(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Atan(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Atan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Atan(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static Single atan(dynamic x)
        {
            return atan(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan2/*' />
        public static Single atan2(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Atan2(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Atan2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Atan2(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan2/*' />
        public static Single atan2(dynamic x, dynamic y)
        {
            return atan2(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static Single acsc(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Acsc(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Acsc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Acsc(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static Single acsc(dynamic x)
        {
            return acsc(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static Single asec(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Asec(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Asec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Asec(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static Single asec(dynamic x)
        {
            return asec(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static Single acot(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Acot(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Acot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Acot(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static Single acot(dynamic x)
        {
            return acot(t(x));
        }




        #endregion



        #region Inverse hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static Single asinh(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Asinh(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Asinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Asinh(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static Single asinh(dynamic x)
        {
            return asinh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static Single acosh(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Acosh(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Acosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Acosh(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static Single acosh(dynamic x)
        {
            return acosh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static Single atanh(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Atanh(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Atanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Atanh(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static Single atanh(dynamic x)
        {
            return atanh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static Single acsch(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Acsch(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Acsch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Acsch(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static Single acsch(dynamic x)
        {
            return acsch(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static Single asech(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Asech(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Asech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Asech(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static Single asech(dynamic x)
        {
            return asech(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static Single acoth(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Acoth(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Acoth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Acoth(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static Single acoth(dynamic x)
        {
            return acoth(t(x));
        }




        #endregion



        #region Miscellaneous




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_w0/*' />
        public static Single lambert_w0(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_LambertW0(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_LambertW0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_LambertW0(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_w0/*' />
        public static Single lambert_w0(dynamic x)
        {
            return lambert_w0(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_wm1/*' />
        public static Single lambert_wm1(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_LambertWm1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_LambertWm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_LambertWm1(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_wm1/*' />
        public static Single lambert_wm1(dynamic x)
        {
            return lambert_wm1(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_w0_prime/*' />
        public static Single lambert_w0_prime(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_LambertW0Prime(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_LambertW0Prime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_LambertW0Prime(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_w0_prime/*' />
        public static Single lambert_w0_prime(dynamic x)
        {
            return lambert_w0_prime(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_wm1_prime/*' />
        public static Single lambert_wm1_prime(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_LambertWm1Prime(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_LambertWm1Prime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_LambertWm1Prime(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_wm1_prime/*' />
        public static Single lambert_wm1_prime(dynamic x)
        {
            return lambert_wm1_prime(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/agm/*' />
        public static Single agm(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Agm(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Agm", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Agm(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/agm/*' />
        public static Single agm(dynamic x, dynamic y)
        {
            return agm(t(x), t(y));
        }


        #endregion



        #endregion





        #region Special real functions



        #region Error functions for real arguments


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndens/*' />
        public static Single ndens(Single x)
        {
            return exp(-0.5f * x * x) / sqrt(2 * pi());
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndens/*' />
        public static Single ndens(dynamic x)
        {
            return ndens(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndis/*' />
        public static Single ndis(Single x)
        {
            return 0.5f * erfc(-x / sqrt(2));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndis/*' />
        public static Single ndis(dynamic x)
        {
            return ndis(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erf/*' />
        public static Single erf(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Erf_(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Erf_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Erf_(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erf/*' />
        public static Single erf(dynamic x)
        {
            return erf(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erfc/*' />
        public static Single erfc(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Erfc_(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Erfc_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Erfc_(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erfc/*' />
        public static Single erfc(dynamic x)
        {
            return erfc(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ErfInv/*' />
        public static Single erf_inv(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Erf_inv(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Erf_inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Erf_inv(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ErfInv/*' />
        public static Single erf_inv(dynamic x)
        {
            return erf_inv(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ErfcInv/*' />
        public static Single erfc_inv(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Erfc_inv(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Erfc_inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Erfc_inv(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ErfcInv/*' />
        public static Single erfc_inv(dynamic x)
        {
            return erfc_inv(t(x));
        }



        #endregion



        #region Gamma and related functions for real arguments and parameters


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lgamma/*' />
        //public static Single lgamma(Single x)
        //{
        //    Single res = 0.0F;
        //    Lib_SReal_Lgamma(ref res, ref x);
        //    return res;
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Lgamma", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void Lib_SReal_Lgamma(ref Single res, ref Single x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lgamma/*' />
        //public static Single lgamma(dynamic x)
        //{
        //    return lgamma(t(x));
        //}


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rgamma/*' />
        public static Single rgamma(Single x)
        {
            return t(1) / gamma(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rgamma/*' />
        public static Single rgamma(dynamic x)
        {
            return rgamma(t(x));
        }





        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        //public static Single gamma(Single x)
        //{
        //    Single res = 0.0F;
        //    Lib_SReal_Tgamma(ref res, ref x);
        //    return res;
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Tgamma", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void Lib_SReal_Tgamma(ref Single res, ref Single x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        //public static Single gamma(dynamic x)
        //{
        //    return gamma(t(x));
        //}




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        public static Single gamma(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Tgamma_(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Tgamma_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Tgamma_(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        public static Single gamma(dynamic x)
        {
            return gamma(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma1pm1/*' />
        public static Single gamma1pm1(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Tgamma1pm1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Tgamma1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Tgamma1pm1(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma1pm1/*' />
        public static Single gamma1pm1(dynamic x)
        {
            return gamma1pm1(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lgamma/*' />
        public static Single lgamma(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Lgamma_(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Lgamma_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Lgamma_(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lgamma/*' />
        public static Single lgamma(dynamic x)
        {
            return lgamma(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/factorial/*' />
        public static Single factorial(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Factorial(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Factorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Factorial(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/factorial/*' />
        public static Single factorial(dynamic x)
        {
            return factorial(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/doublefactorial/*' />
        public static Single doublefactorial(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_DoubleFactorial(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_DoubleFactorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_DoubleFactorial(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/doublefactorial/*' />
        public static Single doublefactorial(dynamic x)
        {
            return doublefactorial(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_ratio/*' />
        public static Single gamma_ratio(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_TgammaRatio(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_TgammaRatio", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_TgammaRatio(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_ratio/*' />
        public static Single gamma_ratio(dynamic x, dynamic y)
        {
            return gamma_ratio(t(x), t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_delta_ratio/*' />
        public static Single gamma_delta_ratio(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_TgammaDeltaRatio(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_TgammaDeltaRatio", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_TgammaDeltaRatio(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_delta_ratio/*' />
        public static Single gamma_delta_ratio(dynamic x, dynamic y)
        {
            return gamma_delta_ratio(t(x), t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/binomial/*' />
        public static Single binomial(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_Binomial(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Binomial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Binomial(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/binomial/*' />
        public static Single binomial(dynamic x, dynamic y)
        {
            return binomial(t(x), t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/rising_factorial/*' />
        public static Single rising_factorial(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_RisingFactorial(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_RisingFactorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_RisingFactorial(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/rising_factorial/*' />
        public static Single rising_factorial(dynamic x, dynamic y)
        {
            return rising_factorial(t(x), t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/falling_factorial/*' />
        public static Single falling_factorial(Single x, Single y)
        {
            Single res = 0.0F;
            Lib_SReal_FallingFactorial(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_FallingFactorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_FallingFactorial(ref Single res, ref Single x, ref Single y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/falling_factorial/*' />
        public static Single falling_factorial(dynamic x, dynamic y)
        {
            return falling_factorial(t(x), t(y));
        }







        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta/*' />
        public static Single beta(Single a, Single b)
        {
            Single res = 0.0F;
            Lib_SReal_Beta(ref res, ref a, ref b);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Beta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Beta(ref Single res, ref Single a, ref Single b);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta/*' />
        public static Single beta(dynamic a, dynamic b)
        {
            return beta(t(a), t(b));
        }








        #endregion



        #region Incomplete gamma functions for real arguments and parameters




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p/*' />
        public static Single gamma_p(Single a, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_GammaP(ref res, ref a, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_GammaP", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_GammaP(ref Single res, ref Single a, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p/*' />
        public static Single gamma_p(dynamic a, dynamic x)
        {
            return gamma_p(t(a), t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q/*' />
        public static Single gamma_q(Single a, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_GammaQ(ref res, ref a, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_GammaQ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_GammaQ(ref Single res, ref Single a, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q/*' />
        public static Single gamma_q(dynamic a, dynamic x)
        {
            return gamma_q(t(a), t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_lower/*' />
        public static Single gamma_lower(Single a, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_TgammaLower(ref res, ref a, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_TgammaLower", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_TgammaLower(ref Single res, ref Single a, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_lower/*' />
        public static Single gamma_lower(dynamic a, dynamic x)
        {
            return gamma_lower(t(a), t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_upper/*' />
        public static Single gamma_upper(Single a, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_TgammaUpper(ref res, ref a, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_TgammaUpper", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_TgammaUpper(ref Single res, ref Single a, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_upper/*' />
        public static Single gamma_upper(dynamic a, dynamic x)
        {
            return gamma_upper(t(a), t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inv/*' />
        public static Single gamma_p_inv(Single a, Single p)
        {
            Single res = 0.0F;
            Lib_SReal_GammaPInv(ref res, ref a, ref p);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_GammaPInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_GammaPInv(ref Single res, ref Single a, ref Single p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inv/*' />
        public static Single gamma_p_inv(dynamic a, dynamic p)
        {
            return gamma_p_inv(t(a), t(p));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inv/*' />
        public static Single gamma_q_inv(Single a, Single q)
        {
            Single res = 0.0F;
            Lib_SReal_GammaQInv(ref res, ref a, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_GammaQInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_GammaQInv(ref Single res, ref Single a, ref Single q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inv/*' />
        public static Single gamma_q_inv(dynamic a, dynamic q)
        {
            return gamma_q_inv(t(a), t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inva/*' />
        public static Single gamma_p_inva(Single x, Single p)
        {
            Single res = 0.0F;
            Lib_SReal_GammaPInva(ref res, ref x, ref p);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_GammaPInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_GammaPInva(ref Single res, ref Single x, ref Single p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inva/*' />
        public static Single gamma_p_inva(dynamic x, dynamic p)
        {
            return gamma_p_inva(t(x), t(p));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inva/*' />
        public static Single gamma_q_inva(Single x, Single q)
        {
            Single res = 0.0F;
            Lib_SReal_GammaQInva(ref res, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_GammaQInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_GammaQInva(ref Single res, ref Single x, ref Single q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inva/*' />
        public static Single gamma_q_inva(dynamic x, dynamic q)
        {
            return gamma_q_inva(t(x), t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_prime/*' />
        public static Single gamma_p_prime(Single a, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_GammaPDerivative(ref res, ref a, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_GammaPDerivative", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_GammaPDerivative(ref Single res, ref Single a, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_prime/*' />
        public static Single gamma_p_prime(dynamic a, dynamic x)
        {
            return gamma_p_prime(t(a), t(x));
        }





        #endregion



        #region Incomplete beta functions for real arguments and parameters


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta/*' />
        public static Single ibeta(Single a, Single b, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_IBeta(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_IBeta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_IBeta(ref Single res, ref Single a, ref Single b, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta/*' />
        public static Single ibeta(dynamic a, dynamic b, dynamic x)
        {
            return ibeta(t(a), t(b), t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac/*' />
        public static Single ibetac(Single a, Single b, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_IBetac(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_IBetac", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_IBetac(ref Single res, ref Single a, ref Single b, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac/*' />
        public static Single ibetac(dynamic a, dynamic b, dynamic x)
        {
            return ibetac(t(a), t(b), t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta_lower/*' />
        public static Single beta_lower(Single a, Single b, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_IBetaNonNormalized(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_IBetaNonNormalized", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_IBetaNonNormalized(ref Single res, ref Single a, ref Single b, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta_lower/*' />
        public static Single beta_lower(dynamic a, dynamic b, dynamic x)
        {
            return beta_lower(t(a), t(b), t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta_upper/*' />
        public static Single beta_upper(Single a, Single b, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_IBetacNonNormalized(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_IBetacNonNormalized", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_IBetacNonNormalized(ref Single res, ref Single a, ref Single b, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta_upper/*' />
        public static Single beta_upper(dynamic a, dynamic b, dynamic x)
        {
            return beta_upper(t(a), t(b), t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inv/*' />
        public static Single ibeta_inv(Single a, Single b, Single p)
        {
            Single res = 0.0F;
            Lib_SReal_IBetaInv(ref res, ref a, ref b, ref p);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_IBetaInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_IBetaInv(ref Single res, ref Single a, ref Single b, ref Single p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inv/*' />
        public static Single ibeta_inv(dynamic a, dynamic b, dynamic p)
        {
            return ibeta_inv(t(a), t(b), t(p));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inv/*' />
        public static Single ibetac_inv(Single a, Single b, Single q)
        {
            Single res = 0.0F;
            Lib_SReal_IBetacInv(ref res, ref a, ref b, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_IBetacInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_IBetacInv(ref Single res, ref Single a, ref Single b, ref Single q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inv/*' />
        public static Single ibetac_inv(dynamic a, dynamic b, dynamic q)
        {
            return ibetac_inv(t(a), t(b), t(q));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inva/*' />
        public static Single ibeta_inva(Single b, Single x, Single p)
        {
            Single res = 0.0F;
            Lib_SReal_IBetaInva(ref res, ref b, ref x, ref p);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_IBetaInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_IBetaInva(ref Single res, ref Single b, ref Single x, ref Single p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inva/*' />
        public static Single ibeta_inva(dynamic b, dynamic x, dynamic p)
        {
            return ibeta_inva(t(b), t(x), t(p));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inva/*' />
        public static Single ibetac_inva(Single b, Single x, Single q)
        {
            Single res = 0.0F;
            Lib_SReal_IBetacInva(ref res, ref b, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_IBetacInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_IBetacInva(ref Single res, ref Single b, ref Single x, ref Single q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inva/*' />
        public static Single ibetac_inva(dynamic b, dynamic x, dynamic q)
        {
            return ibetac_inva(t(b), t(x), t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_invb/*' />
        public static Single ibeta_invb(Single a, Single x, Single p)
        {
            Single res = 0.0F;
            Lib_SReal_IBetaInvb(ref res, ref a, ref x, ref p);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_IBetaInvb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_IBetaInvb(ref Single res, ref Single a, ref Single x, ref Single p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_invb/*' />
        public static Single ibeta_invb(dynamic a, dynamic x, dynamic p)
        {
            return ibeta_invb(t(a), t(x), t(p));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_invb/*' />
        public static Single ibetac_invb(Single a, Single x, Single q)
        {
            Single res = 0.0F;
            Lib_SReal_IBetacInvb(ref res, ref a, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_IBetacInvb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_IBetacInvb(ref Single res, ref Single a, ref Single x, ref Single q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_invb/*' />
        public static Single ibetac_invb(dynamic a, dynamic x, dynamic q)
        {
            return ibetac_invb(t(a), t(x), t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_prime/*' />
        public static Single ibeta_prime(Single a, Single b, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_IBetaDerivative(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_IBetaDerivative", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_IBetaDerivative(ref Single res, ref Single a, ref Single b, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_prime/*' />
        public static Single ibeta_prime(dynamic a, dynamic b, dynamic x)
        {
            return ibeta_prime(t(a), t(b), t(x));
        }





        #endregion



        #region Miscellaneous real functions




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/owen_t/*' />
        public static Single owen_t(Single h, Single a)
        {
            Single res = 0.0F;
            Lib_SReal_OwenT(ref res, ref h, ref a);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_OwenT", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_OwenT(ref Single res, ref Single h, ref Single a);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/owen_t/*' />
        public static Single owen_t(dynamic h, dynamic a)
        {
            return owen_t(t(h), t(a));
        }





        #endregion




        #endregion










        #region Boost Special Functions



        #region Legendre elliptic integrals (elliptic modulus k), and related functions


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Ellint1K/*' />
        public static Single elliptic_k(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Ellint_1_K(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Ellint_1_K", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Ellint_1_K(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Ellint1K/*' />
        public static Single elliptic_k(dynamic x)
        {
            return elliptic_k(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Ellint2K/*' />
        public static Single elliptic_e(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Ellint_2_K(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Ellint_2_K", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Ellint_2_K(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Ellint2K/*' />
        public static Single elliptic_e(dynamic x)
        {
            return elliptic_e(t(x));
        }






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rc/*' />
        public static Single elliptic_rc(Single a, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_EllintRC(ref res, ref a, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_EllintRC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_EllintRC(ref Single res, ref Single a, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rc/*' />
        public static Single elliptic_rc(dynamic a, dynamic x)
        {
            return elliptic_rc(t(a), t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_f/*' />
        public static Single elliptic_f(Single phi, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_Ellint1F(ref res, ref k, ref phi);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Ellint1F", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Ellint1F(ref Single res, ref Single a, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_f/*' />
        public static Single elliptic_f(dynamic phi, dynamic k)
        {
            return elliptic_f(t(phi), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_e_inc/*' />
        public static Single elliptic_e_inc(Single n, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_Ellint2F(ref res, ref k, ref n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Ellint2F", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Ellint2F(ref Single res, ref Single a, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_e_inc/*' />
        public static Single elliptic_e_inc(dynamic n, dynamic k)
        {
            return elliptic_e_inc(t(n), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_pi/*' />
        public static Single elliptic_pi(Single phi, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_Ellint3K(ref res, ref k, ref phi);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Ellint3K", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Ellint3K(ref Single res, ref Single a, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_pi/*' />
        public static Single elliptic_pi(dynamic phi, dynamic k)
        {
            return elliptic_pi(t(phi), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_pi_inc/*' />
        public static Single elliptic_pi_inc(Single n, Single phi, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_Ellint3F(ref res, ref k, ref n, ref phi);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Ellint3F", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Ellint3F(ref Single res, ref Single k, ref Single n, ref Single phi);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_pi_inc/*' />
        public static Single elliptic_pi_inc(dynamic n, dynamic phi, dynamic k)
        {
            return elliptic_pi_inc(t(n), t(phi), t(k));
        }








        #endregion



        #region Carlson symmetric elliptic integrals




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rf/*' />
        public static Single elliptic_rf(Single x, Single y, Single z)
        {
            Single res = 0.0F;
            Lib_SReal_EllipticRF(ref res, ref x, ref y, ref z);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_EllipticRF", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_EllipticRF(ref Single res, ref Single x, ref Single y, ref Single z);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rf/*' />
        public static Single elliptic_rf(dynamic x, dynamic y, dynamic z)
        {
            return elliptic_rf(t(x), t(y), t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rd/*' />
        public static Single elliptic_rd(Single x, Single y, Single z)
        {
            Single res = 0.0F;
            Lib_SReal_EllipticRD(ref res, ref x, ref y, ref z);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_EllipticRD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_EllipticRD(ref Single res, ref Single x, ref Single y, ref Single z);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rd/*' />
        public static Single elliptic_rd(dynamic x, dynamic y, dynamic z)
        {
            return elliptic_rd(t(x), t(y), t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rg/*' />
        public static Single elliptic_rg(Single x, Single y, Single z)
        {
            Single res = 0.0F;
            Lib_SReal_EllipticRG(ref res, ref x, ref y, ref z);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_EllipticRG", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_EllipticRG(ref Single res, ref Single x, ref Single y, ref Single z);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rg/*' />
        public static Single elliptic_rg(dynamic x, dynamic y, dynamic z)
        {
            return elliptic_rg(t(x), t(y), t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rj/*' />
        public static Single elliptic_rj(Single x, Single y, Single z, Single p)
        {
            Single res = 0.0F;
            Lib_SReal_EllipticRJ(ref res, ref x, ref y, ref z, ref p);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_EllipticRJ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_EllipticRJ(ref Single res, ref Single x, ref Single y, ref Single z, ref Single p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rj/*' />
        public static Single elliptic_rj(dynamic x, dynamic y, dynamic z, dynamic p)
        {
            return elliptic_rj(t(x), t(y), t(z), t(p));
        }



        #endregion



        #region Jacobi theta functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta1/*' />
        public static Single jacobi_theta1(Single x, Single q)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiTheta1(ref res, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiTheta1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiTheta1(ref Single res, ref Single x, ref Single q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta1/*' />
        public static Single jacobi_theta1(dynamic x, dynamic q)
        {
            return jacobi_theta1(t(x), t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta2/*' />
        public static Single jacobi_theta2(Single x, Single q)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiTheta2(ref res, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiTheta2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiTheta2(ref Single res, ref Single x, ref Single q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta2/*' />
        public static Single jacobi_theta2(dynamic x, dynamic q)
        {
            return jacobi_theta2(t(x), t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta3/*' />
        public static Single jacobi_theta3(Single x, Single q)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiTheta3(ref res, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiTheta3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiTheta3(ref Single res, ref Single x, ref Single q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta3/*' />
        public static Single jacobi_theta3(dynamic x, dynamic q)
        {
            return jacobi_theta3(t(x), t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta3/*' />
        public static Single jacobi_theta4(Single x, Single q)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiTheta4(ref res, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiTheta4", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiTheta4(ref Single res, ref Single x, ref Single q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta3/*' />
        public static Single jacobi_theta4(dynamic x, dynamic q)
        {
            return jacobi_theta4(t(x), t(q));
        }





        #endregion



        #region Jacobi elliptic functions


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cd/*' />
        public static Single jacobi_cd(Single u, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiCD(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiCD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiCD(ref Single res, ref Single k, ref Single u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cd/*' />
        public static Single jacobi_cd(dynamic u, dynamic k)
        {
            return jacobi_cd(t(u), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cn/*' />
        public static Single jacobi_cn(Single u, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiCN(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiCN", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiCN(ref Single res, ref Single k, ref Single u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cn/*' />
        public static Single jacobi_cn(dynamic u, dynamic k)
        {
            return jacobi_cn(t(u), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cs/*' />
        public static Single jacobi_cs(Single u, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiCS(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiCS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiCS(ref Single res, ref Single k, ref Single u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cs/*' />
        public static Single jacobi_cs(dynamic u, dynamic k)
        {
            return jacobi_cs(t(u), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_dc/*' />
        public static Single jacobi_dc(Single u, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiDC(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiDC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiDC(ref Single res, ref Single k, ref Single u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_dc/*' />
        public static Single jacobi_dc(dynamic u, dynamic k)
        {
            return jacobi_dc(t(u), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_dn/*' />
        public static Single jacobi_dn(Single u, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiDN(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiDN", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiDN(ref Single res, ref Single k, ref Single u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_dn/*' />
        public static Single jacobi_dn(dynamic u, dynamic k)
        {
            return jacobi_dn(t(u), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_ds/*' />
        public static Single jacobi_ds(Single u, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiDS(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiDS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiDS(ref Single res, ref Single k, ref Single u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_ds/*' />
        public static Single jacobi_ds(dynamic u, dynamic k)
        {
            return jacobi_ds(t(u), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_nc/*' />
        public static Single jacobi_nc(Single u, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiNC(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiNC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiNC(ref Single res, ref Single k, ref Single u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_nc/*' />
        public static Single jacobi_nc(dynamic u, dynamic k)
        {
            return jacobi_nc(t(u), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_nd/*' />
        public static Single jacobi_nd(Single u, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiND(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiND", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiND(ref Single res, ref Single k, ref Single u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_nd/*' />
        public static Single jacobi_nd(dynamic u, dynamic k)
        {
            return jacobi_nd(t(u), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_ns/*' />
        public static Single jacobi_ns(Single u, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiNS(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiNS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiNS(ref Single res, ref Single k, ref Single u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_ns/*' />
        public static Single jacobi_ns(dynamic u, dynamic k)
        {
            return jacobi_ns(t(u), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sc/*' />
        public static Single jacobi_sc(Single u, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiSC(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiSC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiSC(ref Single res, ref Single k, ref Single u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sc/*' />
        public static Single jacobi_sc(dynamic u, dynamic k)
        {
            return jacobi_sc(t(u), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sd/*' />
        public static Single jacobi_sd(Single u, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiSD(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiSD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiSD(ref Single res, ref Single k, ref Single u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sd/*' />
        public static Single jacobi_sd(dynamic u, dynamic k)
        {
            return jacobi_sd(t(u), t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sn/*' />
        public static Single jacobi_sn(Single u, Single k)
        {
            Single res = 0.0F;
            Lib_SReal_JacobiSN(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_JacobiSN", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_JacobiSN(ref Single res, ref Single k, ref Single u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sn/*' />
        public static Single jacobi_sn(dynamic u, dynamic k)
        {
            return jacobi_sn(t(u), t(k));
        }




        #endregion



        #region polygamma functions




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/polygamma/*' />
        public static Single polygamma(int n, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Polygamma(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Polygamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Polygamma(ref Single res, int n, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/polygamma/*' />
        public static Single polygamma(int n, dynamic y)
        {
            return polygamma(n, t(y));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/digamma/*' />
        public static Single digamma(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Digamma(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Digamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Digamma(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/digamma/*' />
        public static Single digamma(dynamic x)
        {
            return digamma(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/trigamma/*' />
        public static Single trigamma(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Trigamma(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Trigamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Trigamma(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/trigamma/*' />
        public static Single trigamma(dynamic x)
        {
            return trigamma(t(x));
        }





        #endregion



        #region Hurwitz zeta function and related functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bernoulli/*' />
        public static Single bernoulli(int n)
        {
            if (n == 1) return -0.5F;
            if (n % 2 != 0) return 0.0F;
            Single res = 0.0F;
            Lib_SReal_BernoulliB2n(ref res, n / 2);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BernoulliB2n", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_BernoulliB2n(ref Single res, int n);




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TangentT2n/*' />
        public static Single TangentT2n(int n)
        {
            Single res = 0.0F;
            Lib_SReal_TangentT2n(ref res, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_TangentT2n", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_TangentT2n(ref Single res, int n);



        #endregion



        #region Dirichlet L-Series, Riemann zeta function, and related functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/zeta/*' />
        public static Single zeta(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Zeta(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Zeta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Zeta(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/zeta/*' />
        public static Single zeta(dynamic x)
        {
            return zeta(t(x));
        }


        #endregion



        #region 0F1: Overview



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_0f1/*' />
        public static Single hyperg_0f1(Single b, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Hypergeo0F1(ref res, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Hypergeo0F1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Hypergeo0F1(ref Single res, ref Single b, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_0f1/*' />
        public static Single hyperg_0f1(dynamic b, dynamic x)
        {
            return hyperg_0f1(t(b), t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_0f1r/*' />
        public static Single hyperg_0f1r(Single b, Single x)
        {
            if (oreal.isinteger(b) && (b <= 0))
            {
                return pow(x, -b + 1) * hyperg_0f1(-b + 2, x) / gamma(-b + 2);
            }
            else
            {
                return hyperg_0f1(b, x) / gamma(b);
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_0f1r/*' />
        public static Single hyperg_0f1r(dynamic b, dynamic x)
        {
            return hyperg_0f1r(sreal.t(b), sreal.t(x));
        }





        #endregion



        #region Bessel functions and modified Bessel functions




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv/*' />
        public static Single bessel_jv(Single nu, Single x, bool scaled = false)
        {
            Single res = 0.0F;
            Lib_SReal_BesselJ(ref res, ref nu, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BesselJ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_BesselJ(ref Single res, ref Single nu, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv/*' />
        public static Single bessel_jv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_jv(t(nu), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv/*' />
        public static Single bessel_yv(Single nu, Single x, bool scaled = false)
        {
            Single res = 0.0F;
            Lib_SReal_BesselY(ref res, ref nu, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BesselY", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_BesselY(ref Single res, ref Single nu, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv/*' />
        public static Single bessel_yv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_yv(t(nu), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv/*' />
        public static Single bessel_iv(Single nu, Single x, bool scaled = false)
        {
            Single res = 0.0F;
            Lib_SReal_BesselI(ref res, ref nu, ref x);
            if (scaled) res *= exp(-abs(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BesselI", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_BesselI(ref Single res, ref Single nu, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv/*' />
        public static Single bessel_iv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_iv(t(nu), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv/*' />
        public static Single bessel_kv(Single nu, Single x, bool scaled = false)
        {
            Single res = 0.0F;
            Lib_SReal_BesselK(ref res, ref nu, ref x);
            if (scaled) res *= exp(x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BesselK", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_BesselK(ref Single res, ref Single nu, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv/*' />
        public static Single bessel_kv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_kv(t(nu), t(x), scaled);
        }






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_prime/*' />
        public static Single bessel_jv_prime(Single nu, Single x, bool scaled = false)
        {
            Single res = 0.0F;
            Lib_SReal_BesselJPrime(ref res, ref nu, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BesselJPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_BesselJPrime(ref Single res, ref Single nu, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_prime/*' />
        public static Single bessel_jv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_jv_prime(t(nu), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_prime/*' />
        public static Single bessel_yv_prime(Single nu, Single x, bool scaled = false)
        {
            Single res = 0.0F;
            Lib_SReal_BesselYPrime(ref res, ref nu, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BesselYPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_BesselYPrime(ref Single res, ref Single nu, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_prime/*' />
        public static Single bessel_yv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_yv_prime(t(nu), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv_prime/*' />
        public static Single bessel_iv_prime(Single nu, Single x, bool scaled = false)
        {
            Single res = 0.0F;
            Lib_SReal_BesselIPrime(ref res, ref nu, ref x);
            if (scaled) res *= exp(-abs(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BesselIPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_BesselIPrime(ref Single res, ref Single nu, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv_prime/*' />
        public static Single bessel_iv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_iv_prime(t(nu), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv_prime/*' />
        public static Single bessel_kv_prime(Single nu, Single x, bool scaled = false)
        {
            Single res = 0.0F;
            Lib_SReal_BesselKPrime(ref res, ref nu, ref x);
            if (scaled) res *= exp(x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BesselKPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_BesselKPrime(ref Single res, ref Single nu, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv_prime/*' />
        public static Single bessel_kv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_kv_prime(t(nu), t(x), scaled);
        }







        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_zero/*' />
        public static Single bessel_jv_zero(Single x, int m)
        {
            Single res = 0.0F;
            Lib_SReal_BesselJZero(ref res, ref x, m);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BesselJZero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_BesselJZero(ref Single res, ref Single x, int m);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_zero/*' />
        public static Single bessel_jv_zero(dynamic x, int m)
        {
            return bessel_jv_zero(t(x), m);
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_zero/*' />
        public static Single bessel_yv_zero(Single x, int m)
        {
            Single res = 0.0F;
            Lib_SReal_BesselYZero(ref res, ref x, m);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BesselYZero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_BesselYZero(ref Single res, ref Single x, int m);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_zero/*' />
        public static Single bessel_yv_zero(dynamic x, int m)
        {
            return bessel_yv_zero(t(x), m);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_zero/*' />
        public static Single sph_bessel_jn_zero(int n, int m)
        {
            return bessel_jv_zero(n + 0.5, m);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_zero/*' />
        public static Single sph_bessel_yn_zero(int n, int m)
        {
            return bessel_yv_zero(n + 0.5, m);
        }




        #endregion






        #region Spherical Bessel functions and spherical modified Bessel functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn/*' />
        public static Single sph_bessel_jn(Single n, Single x, bool scaled = false)
        {
            if (!sreal.isinteger(n)) return sreal.nan();

            if (sreal.isnan(x)) return sreal.nan();
            if (sreal.isinf(x)) return sreal.zero();
            if (sreal.isneginf(x)) return sreal.zero();
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if ((n == 0)) return sreal.one();
                    else return sreal.zero();
                }
                else
                {
                    if (n % 2 == 0) return sreal.neginf(); else return sreal.nan();
                }
            }

            if (n < 0)
            {
                Single res = sph_bessel_yn(-n - 1, x);
                if ((n + 1) % 2 == 0) res = -res;
                return res;
            }
            else
            {
                Single x1 = x;
                if (x1 <= 0) x1 = -x1;
                Single res = 0.0F;
                Lib_SReal_SphBessel(ref res, sreal.lrint(n), ref x1);
                if ((x < 0) && !(n % 2 == 0)) res = -res;
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_SphBessel", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_SphBessel(ref Single res, int n, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn/*' />
        public static Single sph_bessel_jn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_jn(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn' />
        public static Single sph_bessel_yn(Single n, Single x, bool scaled = false)
        {
            if (!sreal.isinteger(n)) return sreal.nan();

            if (sreal.isnan(x)) return sreal.nan();
            if (sreal.isinf(x)) return sreal.zero();
            if (sreal.isneginf(x)) return sreal.zero();
            if (x == 0.0)
            {
                if (n < 0)
                {
                    if ((n == -1)) return sreal.one();
                    else return sreal.zero();
                }
                else
                {
                    if (n % 2 != 0) return sreal.neginf(); else return sreal.nan();
                }
            }

            if (n < 0)
            {
                Single res = sph_bessel_jn(-n - 1, x);
                if ((n + 2) % 2 == 0) res = -res;
                return res;
            }
            else
            {
                Single x1 = x;
                if (x1 <= 0) x1 = -x1;
                Single res = 0.0F;
                Lib_SReal_SphNeumann(ref res, sreal.lrint(n), ref x1);
                if ((x < 0) && !((n + 1) % 2 == 0)) res = -res;
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_SphNeumann", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_SphNeumann(ref Single res, int n, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn/*' />
        public static Single sph_bessel_yn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_yn(t(n), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in/*' />
        public static Single sph_bessel_in(Single n, Single x, bool scaled = false)
        {
            if (!sreal.isinteger(n)) return sreal.nan();

            if (sreal.isnan(x)) return sreal.nan();
            if (sreal.isinf(x)) return sreal.inf();
            if (sreal.isneginf(x)) return sreal.zero();
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if ((n == 0)) return sreal.one();
                    else return sreal.zero();
                }
                else
                {
                    if (n % 2 == 0) return sreal.neginf(); else return sreal.nan();
                }
            }

            Single x1 = x;
            if (x1 <= 0) x1 = -x1;
            Single res = bessel_iv(n + 0.5, x1) / sqrt(2 * x1 / pi());
            if ((x < 0) && !(n % 2 == 0)) res = -res;
            if (scaled) res *= exp(-abs(x));
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in/*' />
        public static Single sph_bessel_in(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_in(t(n), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn/*' />
        public static Single sph_bessel_kn(Single n, Single x, bool scaled = false)
        {
            if (!sreal.isinteger(n)) return sreal.nan();

            if (sreal.isnan(x)) return sreal.nan();
            if (sreal.isinf(x)) return sreal.zero();
            if (sreal.isneginf(x)) return sreal.neginf();
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if (n % 2 == 0) return sreal.nan(); else return sreal.inf();
                }
                else
                {
                    if (n % 2 == 0) return sreal.inf(); else return sreal.nan();
                }
            }
            Single res;
            if (x >= 0.0f) res = bessel_kv(n + 0.5, x) / sqrt(2 * x / pi());
            else res = -0.5f * pi() * (sph_bessel_in(n, -x) + sph_bessel_in(-n - 1, -x));
            if (scaled) res *= exp(x);
            return res;

        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn/*' />
        public static Single sph_bessel_kn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_kn(t(n), t(x), scaled);
        }




        internal static Single besselpoly_(int n, Single x)
        {
            if (n < 0) n = Math.Abs(n) - 1;
            if (n == 0) return t(1.0);
            if (n == 1) return x + 1;
            var y = new Single[n + 2];
            y[0] = 1;
            y[1] = x + 1;
            for (int i = 2; i <= n; i++)
            {
                y[i] = (2 * i - 1) * x * y[i - 1] + y[i - 2];
            }
            return y[n];
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besselpoly/*' />
        public static Single besselpoly(Single n, Single x, bool scaled = false)
        {
            if (!sreal.isinteger(n)) return sreal.nan();
            if (abs(x) < t(0.01)) return besselpoly_(lrint(n), x);
            else
            {
                Single res = sph_bessel_kn(n, 1 / x);
                res *= exp(1 / x) * 2 / (pi() * x);
                return res;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besselpoly/*' />
        public static Single besselpoly(dynamic n, dynamic x, bool scaled = false)
        {
            return besselpoly(t(n), t(x), scaled);
        }





        internal static Single besseltheta_(int n, Single x)
        {
            if (n < 0) n = Math.Abs(n) - 1;
            if (n == 0) return t(1.0);
            if (n == 1) return x + 1;
            var y = new Single[n + 2];
            y[0] = 1;
            y[1] = x + 1;
            for (int i = 2; i <= n; i++)
            {
                y[i] = (2 * i - 1) * y[i - 1] + x * x * y[i - 2];
            }
            return y[n];
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besseltheta/*' />
        public static Single besseltheta(Single n, Single x, bool scaled = false)
        {
            if (!sreal.isinteger(n)) return sreal.nan();
            if ((x == 0) && (n < 0)) return sreal.nan();
            if ((abs(x) < t(0.01)) && (n >= 0)) return besseltheta_(lrint(n), x);
            if (n < 0) return pow(x, n) * besselpoly(n, 1 / x);
            else
            {
                Single res = sph_bessel_kn(n, x);
                res *= sreal.pow(x, n + 1) * exp(x) * 2 / pi();
                return res;
            }
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besseltheta/*' />
        public static Single besseltheta(dynamic n, dynamic x, bool scaled = false)
        {
            return besseltheta(t(n), t(x), scaled);
        }






        #endregion




        #region Spherical Bessel functions, first derivative




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_prime/*' />
        public static Single sph_bessel_jn_prime(Single n, Single x, bool scaled = false)
        {
            if (!sreal.isinteger(n)) return sreal.nan();

            if (sreal.isnan(x)) return sreal.nan();
            if (sreal.isinf(x)) return sreal.zero();
            if (sreal.isneginf(x)) return sreal.zero();
            if (x == 0.0)
            {
                if (n == 1) return 1 / sreal.t(3);
                if (n >= 0) return sreal.zero();
                else
                {
                    if (n % 2 != 0) return sreal.neginf(); else return sreal.nan();
                }
            }
            return (n * sph_bessel_jn(n - 1, x, scaled) - (n + 1) * sph_bessel_jn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_prime/*' />
        public static Single sph_bessel_jn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_jn_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_prime/*' />
        public static Single sph_bessel_yn_prime(Single n, Single x, bool scaled = false)
        {
            if (!sreal.isinteger(n)) return sreal.nan();

            if (sreal.isnan(x)) return sreal.nan();
            if (sreal.isinf(x)) return sreal.zero();
            if (sreal.isneginf(x)) return sreal.zero();
            if (x == 0.0)
            {
                if (n == -2) return -1 / sreal.t(3);
                if (n < 0) return sreal.zero();
                else
                {
                    if (n % 2 == 0) return sreal.inf(); else return sreal.nan();
                }
            }
            return (n * sph_bessel_yn(n - 1, x, scaled) - (n + 1) * sph_bessel_yn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_prime/*' />
        public static Single sph_bessel_yn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_yn_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in_prime/*' />
        public static Single sph_bessel_in_prime(Single n, Single x, bool scaled = false)
        {
            if (!sreal.isinteger(n)) return sreal.nan();

            if (sreal.isnan(x)) return sreal.nan();
            if (sreal.isinf(x)) return sreal.inf();
            if (sreal.isneginf(x))
            {
                if (n % 2 == 0) return sreal.neginf(); else return sreal.inf();
            }
            if (x == 0.0)
            {
                if (n == 0) return sreal.zero();
                if (n < 0)
                {
                    if (n % 2 != 0) return sreal.neginf(); else return sreal.nan();
                }
            }
            return (n * sph_bessel_in(n - 1, x, scaled) + (n + 1) * sph_bessel_in(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in_prime/*' />
        public static Single sph_bessel_in_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_in_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn_prime/*' />
        public static Single sph_bessel_kn_prime(Single n, Single x, bool scaled = false)
        {
            if (!sreal.isinteger(n)) return sreal.nan();

            if (sreal.isnan(x)) return sreal.nan();
            if (sreal.isinf(x)) return sreal.zero();
            if (sreal.isneginf(x)) return sreal.neginf();
            if (x == 0.0)
            {
                if (((n >= 0) && (n % 2 == 0)) || ((n < 0) && (n % 2 != 0))) return sreal.neginf();
                else return sreal.nan();
            }
            return -(n * sph_bessel_kn(n - 1, x, scaled) + (n + 1) * sph_bessel_kn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn_prime/*' />
        public static Single sph_bessel_kn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_kn_prime(t(n), t(x), scaled);
        }





        #endregion







        #region Hankel functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h1/*' />
        public static SingleC hankel_h1(Single v, Single x)
        {
            return bessel_jv(v, x) + scplx.onej() * bessel_yv(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h1/*' />
        public static SingleC hankel_h1(dynamic v, dynamic x)
        {
            return hankel_h1(t(v), t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h2/*' />
        public static SingleC hankel_h2(Single v, Single x)
        {
            return bessel_jv(v, x) - scplx.onej() * bessel_yv(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h2/*' />
        public static SingleC hankel_h2(dynamic v, dynamic x)
        {
            return hankel_h2(t(v), t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h1/*' />
        public static SingleC sph_hankel_h1(int n, Single x)
        {
            return sph_bessel_jn(n, x) + scplx.onej() * sph_bessel_yn(n, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h1/*' />
        public static SingleC sph_hankel_h1(int n, dynamic x)
        {
            return sph_hankel_h1(n, t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h2/*' />
        public static SingleC sph_hankel_h2(int n, Single x)
        {
            return sph_bessel_jn(n, x) - scplx.onej() * sph_bessel_yn(n, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h2/*' />
        public static SingleC sph_hankel_h2(int n, dynamic x)
        {
            return sph_hankel_h2(n, t(x));
        }






        #endregion






        #region Airy functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai/*' />
        public static Single airy_ai(Single x, bool scaled = false)
        {
            Single res = 0.0F;
            Lib_SReal_AiryAi(ref res, ref x);
            if ((scaled) && (x > 0)) res *= exp((sreal.t(2) / sreal.t(3)) * x * sqrt(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_AiryAi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_AiryAi(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai/*' />
        public static Single airy_ai(dynamic x, bool scaled = false)
        {
            return airy_ai(t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi/*' />
        public static Single airy_bi(Single x, bool scaled = false)
        {
            Single res = 0.0F;
            Lib_SReal_AiryBi(ref res, ref x);
            if ((scaled) && (x > 0)) res *= exp(-abs(sreal.t(2) / sreal.t(3) * (x * sqrt(x))));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_AiryBi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_AiryBi(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi/*' />
        public static Single airy_bi(dynamic x, bool scaled = false)
        {
            return airy_bi(t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai_prime/*' />
        public static Single airy_ai_prime(Single x, bool scaled = false)
        {
            Single res = 0.0F;
            Lib_SReal_AiryAiPrime(ref res, ref x);
            if ((scaled) && (x > 0)) res *= exp((sreal.t(2) / sreal.t(3)) * x * sqrt(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_AiryAiPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_AiryAiPrime(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai_prime/*' />
        public static Single airy_ai_prime(dynamic x, bool scaled = false)
        {
            return airy_ai_prime(t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi_prime/*' />
        public static Single airy_bi_prime(Single x, bool scaled = false)
        {
            Single res = 0.0F;
            Lib_SReal_AiryBiPrime(ref res, ref x);
            if ((scaled) && (x > 0)) res *= exp(-abs(sreal.t(2) / sreal.t(3) * (x * sqrt(x))));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_AiryBiPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_AiryBiPrime(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi_prime/*' />
        public static Single airy_bi_prime(dynamic x, bool scaled = false)
        {
            return airy_bi_prime(t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai_zero/*' />
        public static Single airy_ai_zero(int n)
        {
            Single res = 0.0F;
            Lib_SReal_Aizero(ref res, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Aizero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Aizero(ref Single res, int n);



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai_zero/*' />
        public static Single airy_bi_zero(int n)
        {
            Single res = 0.0F;
            Lib_SReal_Bizero(ref res, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Bizero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Bizero(ref Single res, int n);



        #endregion



        #region 1F1 Overview




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_1f1/*' />
        public static Single hyperg_1f1(Single a, Single b, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Hypergeo1F1(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Hypergeo1F1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Hypergeo1F1(ref Single res, ref Single a, ref Single b, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_1f1/*' />
        public static Single hyperg_1f1(dynamic a, dynamic b, dynamic x)
        {
            return hyperg_1f1(t(a), t(b), t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_1f1r/*' />
        public static Single hyperg_1f1r(Single a, Single b, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Hypergeo1F1r(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Hypergeo1F1r", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Hypergeo1F1r(ref Single res, ref Single a, ref Single b, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_1f1r/*' />
        public static Single hyperg_1f1r(dynamic a, dynamic b, dynamic x)
        {
            return hyperg_1f1r(t(a), t(b), t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/log_hyperg_1f1/*' />
        public static Single log_hyperg_1f1(Single a, Single b, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_LogHypergeo1F1(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_LogHypergeo1F1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_LogHypergeo1F1(ref Single res, ref Single a, ref Single b, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/log_hyperg_1f1/*' />
        public static Single log_hyperg_1f1(dynamic a, dynamic b, dynamic x)
        {
            return log_hyperg_1f1(t(a), t(b), t(x));
        }



        #endregion



        #region Exponential integrals and related functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/exp_integral_ei/*' />
        public static Single exp_integral_ei(Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Ei(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Ei", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Ei(ref Single res, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/exp_integral_ei/*' />
        public static Single exp_integral_ei(dynamic x)
        {
            return exp_integral_ei(t(x));
        }






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/exp_integral_en/*' />
        public static Single exp_integral_en(int n, Single x)
        {
            if (n < 0) return nan();
            Single res = 0.0F;
            Lib_SReal_expint(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_expint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_expint(ref Single res, int n, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/exp_integral_ei/*' />
        public static Single exp_integral_en(int n, dynamic x)
        {
            return exp_integral_en(n, t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp_integral_e1/*' />
        public static Single exp_integral_e1(Single z)
        {
            if (z < 0) return -exp_integral_ei(-z);
            else return exp_integral_en(1, z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp_integral_e1/*' />
        public static Single exp_integral_e1(dynamic z)
        {
            return exp_integral_e1(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log_integral/*' />
        public static Single log_integral(Single z)
        {
            if (z < 0) return nan();
            if (z == 0) return zero();
            else return exp_integral_ei(log(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log_integral/*' />
        public static Single log_integral(dynamic z)
        {
            return log_integral(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh_integral/*' />
        public static Single cosh_integral(Single x)
        {
            return (exp_integral_ei(x) - exp_integral_e1(x)) / 2;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh_integral/*' />
        public static Single cosh_integral(dynamic z)
        {
            return cosh_integral(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh_integral/*' />
        public static Single sinh_integral(Single x)
        {
            return (exp_integral_ei(x) + exp_integral_e1(x)) / 2;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh_integral/*' />
        public static Single sinh_integral(dynamic z)
        {
            return sinh_integral(t(z));
        }





        #endregion



        #region 1F1-related orthogonal polynomials



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/laguerre_l/*' />
        public static Single laguerre(int n, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Laguerre(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Laguerre", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Laguerre(ref Single res, int n, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/laguerre_l/*' />
        public static Single laguerre_l(int n, dynamic y)
        {
            return laguerre_l(n, t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hermite_h/*' />
        public static Single hermite_h(int n, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Hermite(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Hermite", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Hermite(ref Single res, int n, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hermite_h/*' />
        public static Single hermite_h(int n, dynamic y)
        {
            return hermite_h(n, t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hermite_he/*' />
        public static Single hermite_he(int n, Single x)
        {
            return exp2(-n / 2) * hermite_h(n, x / sqrt(2));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hermite_he/*' />
        public static Single hermite_he(int n, dynamic x)
        {
            return hermite_he(n, sreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/laguerre_ass/*' />
        public static Single laguerre_l(int n, int m, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_LaguerreM(ref res, n, m, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_LaguerreM", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_LaguerreM(ref Single res, int n, int m, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hermite_h/*' />
        public static Single laguerre_l(int n, int m, dynamic y)
        {
            return laguerre_l(n, m, t(y));
        }



        #endregion



        #region 2F1-related orthogonal polynomials





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_t/*' />
        public static Single chebyshev_t(int n, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_ChebyshevT(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_ChebyshevT", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_ChebyshevT(ref Single res, int n, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_t/*' />
        public static Single chebyshev_t(int n, dynamic y)
        {
            return chebyshev_t(n, t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_u/*' />
        public static Single chebyshev_u(int n, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_ChebyshevU(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_ChebyshevU", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_ChebyshevU(ref Single res, int n, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_u/*' />
        public static Single chebyshev_u(int n, dynamic y)
        {
            return chebyshev_u(n, t(y));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_v/*' />
        public static Single chebyshev_v(int n, Single x)  // same as t_n(x)
        {
            if (x < 0.0)
            {
                int m = -1; if (n % 2 == 0) m = 1; // m = exp(i * n * pi)
                return m * chebyshev_w(n, -x);
            }
            else return sqrt(2 / (1 + x)) * chebyshev_t(2 * n + 1, sqrt((x + 1) / 2));
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_u/*' />
        public static Single chebyshev_v(int n, dynamic y)
        {
            return chebyshev_v(n, t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_w/*' />
        public static Single chebyshev_w(int n, Single x)  // same as u_n(x)
        {
            if (x < 0.0)
            {
                int m = -1; if (n % 2 == 0) m = 1; // m = exp(i * n * pi)
                return m * chebyshev_v(n, -x);
            }
            else return chebyshev_u(2 * n, sqrt((x + 1) / 2));
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_w/*' />
        public static Single chebyshev_w(int n, dynamic y)
        {
            return chebyshev_w(n, t(y));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_p/*' />
        public static Single legendre_p(int n, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_LegendreP(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_LegendreP", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_LegendreP(ref Single res, int n, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_p/*' />
        public static Single legendre_p(int n, dynamic y)
        {
            return legendre_p(n, t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_q/*' />
        public static Single legendre_q(int n, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_LegendreQ(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_LegendreQ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_LegendreQ(ref Single res, int n, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_q/*' />
        public static Single legendre_q(int n, dynamic y)
        {
            return legendre_q(n, t(y));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_plm/*' />
        public static Single legendre_plm(int n, int m, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_LegendrePM(ref res, n, m, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_LegendrePM", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_LegendrePM(ref Single res, int n, int m, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_plm/*' />
        public static Single legendre_plm(int n, int m, dynamic y)
        {
            return legendre_plm(n, m, t(y));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gegenbauer_c/*' />
        public static Single gegenbauer_c(int n, Single lambda1, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Gegenbauer(ref res, n, ref lambda1, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Gegenbauer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Gegenbauer(ref Single res, int n, ref Single lambda1, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gegenbauer_c/*' />
        public static Single gegenbauer_c(int n, dynamic lambda1, dynamic x)
        {
            return gegenbauer_c(n, t(lambda1), t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_p/*' />
        public static Single jacobi_p(int n, Single alpha, Single beta, Single x)
        {
            Single res = 0.0F;
            Lib_SReal_Jacobi(ref res, n, ref alpha, ref beta, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Jacobi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Jacobi(ref Single res, int n, ref Single alpha, ref Single beta, ref Single x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_p/*' />
        public static Single jacobi_p(int n, dynamic alpha, dynamic beta, dynamic x)
        {
            return jacobi_p(n, t(alpha), t(beta), t(x));
        }





        internal static Single spherical_harmonic_r(int n, int m, Single theta, Single phi)
        {
            Single res = 0.0F;
            Lib_SReal_SphericalHarmonicR(ref res, n, m, ref theta, ref phi);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_SphericalHarmonicR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_SphericalHarmonicR(ref Single res, int n, int m, ref Single theta, ref Single phi);


        internal static Single spherical_harmonic_i(int n, int m, Single theta, Single phi)
        {
            Single res = 0.0F;
            Lib_SReal_SphericalHarmonicI(ref res, n, m, ref theta, ref phi);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_SphericalHarmonicI", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_SphericalHarmonicI(ref Single res, int n, int m, ref Single theta, ref Single phi);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/spherical_y/*' />
        public static SingleC spherical_y(Single n, Single m, Single theta, Single phi)
        {
            return scplx.t(spherical_harmonic_r(lrint(n), lrint(m), theta, phi),
                           spherical_harmonic_i(lrint(n), lrint(m), theta, phi));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/spherical_y/*' />
        public static SingleC spherical_y(dynamic n, dynamic m, dynamic theta, dynamic phi)
        {
            return spherical_y(sreal.t(n), sreal.t(m), sreal.t(theta), sreal.t(phi));
        }







        #endregion



        #endregion



        #region Boost Distributions as classes


        #region Base classes

        public class BaseDistClass
        {
            internal static Single nil = 0.0F;
            internal static int target = 1;
            //internal static Single a_;
            //internal static Single b_;
            //internal static Single c_;
            //internal static Single lambda1_;
            //internal static Single delta_;
            //internal static Single k_;
            //internal static Single m_;
            //internal static Single n_;
            //internal static Single p_;
            //internal static Single r_;
            //internal static Single mu_;
            //internal static Single sigma_;


            internal virtual Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                return res;
            }

            public static sreal ctx
            {
                get { return new sreal(); }
            }


            //public sreal ctx()
            //{
            //    return new sreal();
            //}


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/cdf/*' />
            public Single cdf(Single x)
            {
                target = 2;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/cdf/*' />
            public Single cdf(dynamic x)
            {
                target = 2;
                return BaseDist(t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/sf/*' />
            public Single sf(Single x)
            {
                target = 3;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/sf/*' />
            public Single sf(dynamic x)
            {
                target = 3;
                return BaseDist(t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/hf/*' />
            public Single hf(Single x)
            {
                target = 4;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/hf/*' />
            public Single hf(dynamic x)
            {
                target = 4;
                return BaseDist(t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/chf/*' />
            public Single chf(Single x)
            {
                target = 5;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/chf/*' />
            public Single chf(dynamic x)
            {
                target = 5;
                return BaseDist(t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/qtf/*' />
            public Single qtf(Single q)
            {
                target = 6;
                return BaseDist(q);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/qtf/*' />
            public Single qtf(dynamic q)
            {
                target = 6;
                return BaseDist(t(q));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/isf/*' />
            public Single isf(Single q)
            {
                target = 7;
                return BaseDist(q);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/isf/*' />
            public Single isf(dynamic q)
            {
                target = 7;
                return BaseDist(t(q));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/mean/*' />
            public Single mean()
            {
                target = 8;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/median/*' />
            public Single median()
            {
                target = 9;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/mode/*' />
            public Single mode()
            {
                target = 10;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/variance/*' />
            public Single variance()
            {
                target = 11;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/stdev/*' />
            public Single stdev()
            {
                target = 12;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/skewness/*' />
            public Single skewness()
            {
                target = 13;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/kurtosis/*' />
            public Single kurtosis()
            {
                target = 14;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/kurtosis_excess/*' />
            public Single kurtosis_excess()
            {
                target = 15;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/support_lower_endpoint/*' />
            public Single support_lower_endpoint()
            {
                target = 16;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/support_upper_endpoint/*' />
            public Single support_upper_endpoint()
            {
                target = 17;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/range_lower_endpoint/*' />
            public Single range_lower_endpoint()
            {
                target = 18;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/range_upper_endpoint/*' />
            public Single range_upper_endpoint()
            {
                target = 19;
                return BaseDist(nil);
            }
        }


        public class BaseDistContClass : BaseDistClass
        {

            public bool IsContinuous()
            {
                return true;
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/pdf/*' />
            public Single pdf(Single x)
            {
                target = 1;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/pdf/*' />
            public Single pdf(dynamic x)
            {
                target = 1;
                return BaseDist(t(x));
            }
        }


        public class BaseDistDiscreteClass : BaseDistClass
        {
            public bool IsContinuous()
            {
                return false;
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/pmf/*' />
            public Single pmf(Single x)
            {
                target = 1;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/pmf/*' />
            public Single pmf(dynamic x)
            {
                target = 1;
                return BaseDist(t(x));
            }
        }


        #endregion



        #region Discrete (lattice) distribution functions



        #region BernoulliDist


        public class BernoulliDistClass : BaseDistDiscreteClass
        {
            Single p;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_BernoulliDist(target, ref res, ref xqp, ref p);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BernoulliDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_BernoulliDist(int target, ref Single res, ref Single xqp, ref Single p);

            public BernoulliDistClass(Single _p)
            {
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BernoulliDist/*' />
        public static BernoulliDistClass dist_bernoulli(Single p)
        {
            return new BernoulliDistClass(p);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BernoulliDist/*' />
        public static BernoulliDistClass dist_bernoulli(dynamic p)
        {
            return dist_bernoulli(t(p));
        }

        #endregion




        #region GeometricDist


        public class GeometricDistClass : BaseDistDiscreteClass
        {
            Single p;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_GeometricDist(target, ref res, ref xqp, ref p);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_GeometricDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_GeometricDist(int target, ref Single res, ref Single xqp, ref Single p);

            public GeometricDistClass(Single _p)
            {
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GeometricDist/*' />
        public static GeometricDistClass dist_geometric(Single p)
        {
            return new GeometricDistClass(p);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GeometricDist/*' />
        public static GeometricDistClass dist_geometric(dynamic p)
        {
            return dist_geometric(t(p));
        }

        #endregion




        #region PoissonDist


        public class PoissonDistClass : BaseDistDiscreteClass
        {
            Single mu;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_PoissonDist(target, ref res, ref xqp, ref mu);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_PoissonDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_PoissonDist(int target, ref Single res, ref Single xqp, ref Single mu);

            public PoissonDistClass(Single _mu)
            {
                mu = _mu;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/PoissonDist/*' />
        public static PoissonDistClass dist_poisson(Single mu)
        {
            return new PoissonDistClass(mu);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/PoissonDist/*' />
        public static PoissonDistClass dist_poisson(dynamic mu)
        {
            return dist_poisson(t(mu));
        }

        #endregion



        #region BinomialDist


        public class BinomialDistClass : BaseDistDiscreteClass
        {
            Single n;
            Single p;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_BinomialDist(target, ref res, ref xqp, ref n, ref p);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BinomialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_BinomialDist(int target, ref Single res, ref Single xqp, ref Single n, ref Single p);

            public BinomialDistClass(Single _n, Single _p)
            {
                n = _n;
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BinomialDist/*' />
        public static BinomialDistClass dist_binomial(Single n, Single p)
        {
            return new BinomialDistClass(n, p);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BinomialDist/*' />
        public static BinomialDistClass dist_binomial(dynamic n, dynamic p)
        {
            return dist_binomial(t(n), t(p));
        }

        #endregion



        #region NegBinomialDist


        public class NegBinomialDistClass : BaseDistDiscreteClass
        {
            Single r;
            Single p;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_NegBinomialDist(target, ref res, ref xqp, ref r, ref p);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_NegBinomialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_NegBinomialDist(int target, ref Single res, ref Single xqp, ref Single r, ref Single p);

            public NegBinomialDistClass(Single _r, Single _p)
            {
                r = _r;
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NegBinomialDist/*' />
        public static NegBinomialDistClass dist_negbinomial(Single r, Single p)
        {
            return new NegBinomialDistClass(r, p);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NegBinomialDist/*' />
        public static NegBinomialDistClass dist_negbinomial(dynamic r, dynamic p)
        {
            return dist_negbinomial(t(r), t(p));
        }

        #endregion



        #region HypergeometricDist


        public class HypergeometricDistClass : BaseDistDiscreteClass
        {
            internal UInt64 r__;
            internal UInt64 n__;
            internal UInt64 NN__;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_HypergeometricDist(target, ref res, ref xqp, r__, n__, NN__);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_HypergeometricDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_HypergeometricDist(int target, ref Single res, ref Single xqp, UInt64 r, UInt64 n, UInt64 NN);

            public HypergeometricDistClass(UInt64 r, UInt64 n, UInt64 NN)
            {
                r__ = r;
                n__ = n;
                NN__ = NN;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/HypergeometricDist/*' />
        public static HypergeometricDistClass dist_hypergeometric(UInt64 r, UInt64 n, UInt64 NN)
        {
            return new HypergeometricDistClass(r, n, NN);
        }

        ///// <include file="docs.xml" path='docs/members[@name="Boost"]/HypergeometricDist/*' />
        //public static HypergeometricDistClass dist_hypergeometric(dynamic r, dynamic n, dynamic NN)
        //{
        //    return dist_hypergeometric(t(r), t(n), t(NN));
        //}

        #endregion





        #endregion



        #region Closed form distributions, based on elementary functions


        #region ArcsineDist


        public class ArcsineDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_ArcsineDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_ArcsineDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_ArcsineDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public ArcsineDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ArcsineDist/*' />
        public static ArcsineDistClass dist_arcsine(Single a, Single b)
        {
            return new ArcsineDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ArcsineDist/*' />
        public static ArcsineDistClass dist_arcsine(dynamic a, dynamic b)
        {
            return dist_arcsine(t(a), t(b));
        }

        #endregion




        #region CauchyDist


        public class CauchyDistClass : BaseDistContClass
        {
            Single a;
            Single b;

            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_CauchyDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_CauchyDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_CauchyDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public CauchyDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/CauchyDist/*' />
        public static CauchyDistClass dist_cauchy(Single a, Single b)
        {
            return new CauchyDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/CauchyDist/*' />
        public static CauchyDistClass dist_cauchy(dynamic a, dynamic b)
        {
            return dist_cauchy(t(a), t(b));
        }

        #endregion




        #region ExponentialDist


        public class ExponentialDistClass : BaseDistContClass
        {
            Single lambda1;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_ExponentialDist(target, ref res, ref xqp, ref lambda1);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_ExponentialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_ExponentialDist(int target, ref Single res, ref Single xqp, ref Single lambda1);

            public ExponentialDistClass(Single _lambda1)
            {
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExponentialDist/*' />
        public static ExponentialDistClass dist_exponential(Single lambda1)
        {
            return new ExponentialDistClass(lambda1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExponentialDist/*' />
        public static ExponentialDistClass dist_exponential(dynamic lambda1)
        {
            return dist_exponential(t(lambda1));
        }

        #endregion




        #region GumbelDist


        public class GumbelDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_GumbelDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_GumbelDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_GumbelDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public GumbelDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GumbelDist/*' />
        public static GumbelDistClass dist_gumbel(Single a, Single b)
        {
            return new GumbelDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GumbelDist/*' />
        public static GumbelDistClass dist_gumbel(dynamic a, dynamic b)
        {
            return dist_gumbel(t(a), t(b));
        }

        #endregion



        #region HyperexponentialDist


        public class HyperexponentialDistClass : BaseDistContClass
        {
            private SingleVec matProb_ = new SingleVec();
            private SingleVec matRate_ = new SingleVec();

            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0f;
                Lib_SReal_HyperexponentialDist(target, ref res, ref xqp, matProb_.mpPtr, matRate_.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_HyperexponentialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_HyperexponentialDist(int target, ref Single res, ref Single xqp, IntPtr Prob, IntPtr Rate);

            public HyperexponentialDistClass(SingleVec Prob, SingleVec Rate)
            {
                matProb_ = Prob;
                matRate_ = Rate;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/HyperexponentialDist/*' />
        public static HyperexponentialDistClass dist_hyperexponential(SingleVec Prob, SingleVec Rate)
        {
            return new HyperexponentialDistClass(Prob, Rate);
        }


        ///// <include file="docs.xml" path='docs/members[@name="Boost"]/HyperexponentialDist/*' />
        //public static HyperexponentialDistClass dist_hyperexponential(dynamic a, dynamic b)
        //{
        //    return dist_hyperexponential(t(a), t(b));
        //}

        #endregion




        #region KumaraswamyDist


        public class KumaraswamyDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = t(0);
                Single pdf = t(0);
                Single sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    res = a * b * pow(xqp, a - 1);
                    Single temp = pow(-powm1(xqp, a), b - 1);
                    pdf = res * temp;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    sf = pow(-powm1(xqp, a), b);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2: { res = -powm1(-powm1(xqp, a), b); break; } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6: { res = pow(-pow1pm1(-xqp, 1 / b), 1 / a); break; } // qtf, Pinv
                    case 7: { res = pow(-powm1(xqp, 1 / b), 1 / a); break; } // isf, Qinv
                    case 8: { res = t(8); break; } // Mean
                    case 9: { res = t(9); break; } // Median
                    case 10: { res = t(10); break; } // Mode
                    case 11: { res = t(11); break; } // Variance
                    case 12: { res = t(12); break; } // Stdev
                    case 13: { res = t(13); break; } // Skewness
                    case 14: { res = t(14); break; } // Kurtosis
                    case 15: { res = t(15); break; } // KurtosisExcess
                    case 16: { res = t(16); break; } // support_left
                    case 17: { res = t(17); break; } // support_right
                    case 18: { res = t(18); break; } // range_left
                    case 19: { res = t(19); break; } // range_right
                    default: break;
                }
                return res;
            }

            public KumaraswamyDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_kumaraswamy/*' />
        public static KumaraswamyDistClass dist_kumaraswamy(Single a, Single b)
        {
            return new KumaraswamyDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_kumaraswamy/*' />
        public static KumaraswamyDistClass dist_kumaraswamy(dynamic a, dynamic b)
        {
            return dist_kumaraswamy(t(a), t(b));
        }

        #endregion




        #region LaplaceDist


        public class LaplaceDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_LaplaceDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_LaplaceDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_LaplaceDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public LaplaceDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LaplaceDist/*' />
        public static LaplaceDistClass dist_laplace(Single a, Single b)
        {
            return new LaplaceDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LaplaceDist/*' />
        public static LaplaceDistClass dist_laplace(dynamic a, dynamic b)
        {
            return dist_laplace(t(a), t(b));
        }

        #endregion




        #region LogisticDist


        public class LogisticDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_LogisticDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_LogisticDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_LogisticDist(int target, ref Single res, ref Single xqp, ref Single loc, ref Single scale);

            public LogisticDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LogisticDist/*' />
        public static LogisticDistClass dist_logistic(Single a, Single b)
        {
            return new LogisticDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LogisticDist/*' />
        public static LogisticDistClass dist_logistic(dynamic a, dynamic b)
        {
            return dist_logistic(t(a), t(b));
        }

        #endregion




        #region ParetoDist


        public class ParetoDistClass : BaseDistContClass
        {
            Single k;
            Single a;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_ParetoDist(target, ref res, ref xqp, ref k, ref a);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_ParetoDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_ParetoDist(int target, ref Single res, ref Single xqp, ref Single k, ref Single a);

            public ParetoDistClass(Single _k, Single _a)
            {
                k = _k;
                a = _a;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ParetoDist/*' />
        public static ParetoDistClass dist_pareto(Single k, Single a)
        {
            return new ParetoDistClass(k, a);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ParetoDist/*' />
        public static ParetoDistClass dist_pareto(dynamic k, dynamic a)
        {
            return dist_pareto(t(k), t(a));
        }

        #endregion




        #region RayleighDist


        public class RayleighDistClass : BaseDistContClass
        {
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_RayleighDist(target, ref res, ref xqp, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_RayleighDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_RayleighDist(int target, ref Single res, ref Single xqp, ref Single b);

            public RayleighDistClass(Single _b)
            {
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RayleighDist/*' />
        public static RayleighDistClass dist_rayleigh(Single b)
        {
            return new RayleighDistClass(b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RayleighDist/*' />
        public static RayleighDistClass dist_rayleigh(dynamic b)
        {
            return dist_rayleigh(t(b));
        }

        #endregion




        #region TriangularDist


        public class TriangularDistClass : BaseDistContClass
        {
            Single a;
            Single m;
            Single b;

            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_TriangularDist(target, ref res, ref xqp, ref a, ref m, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_TriangularDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_TriangularDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single m, ref Single b);

            public TriangularDistClass(Single _a, Single _m, Single _b)
            {
                a = _a;
                m = _m;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TriangularDist/*' />
        public static TriangularDistClass dist_triangular(Single a, Single m, Single b)
        {
            return new TriangularDistClass(a, m, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TriangularDist/*' />
        public static TriangularDistClass dist_triangular(dynamic a, dynamic m, dynamic b)
        {
            return dist_triangular(t(a), t(m), t(b));
        }

        #endregion




        #region UniformDist


        public class UniformDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_UniformDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_UniformDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_UniformDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public UniformDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/UniformDist/*' />
        public static UniformDistClass dist_uniform(Single a, Single b)
        {
            return new UniformDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/UniformDist/*' />
        public static UniformDistClass dist_uniform(dynamic a, dynamic b)
        {
            return dist_uniform(t(a), t(b));
        }

        #endregion




        #region WeibullDist


        public class WeibullDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_WeibullDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_WeibullDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_WeibullDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public WeibullDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WeibullDist/*' />
        public static WeibullDistClass dist_weibull(Single a, Single b)
        {
            return new WeibullDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WeibullDist/*' />
        public static WeibullDistClass dist_weibull(dynamic a, dynamic b)
        {
            return dist_weibull(t(a), t(b));
        }

        #endregion


        #endregion



        #region Closed form distributions, based on the error function



        #region LevyDist


        public class LevyDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = t(0);
                Single pdf = t(0);
                Single sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Single s = sqrt(b / (2 * pi()));
                    Single t = exp(-b / (2 * (xqp - a)));
                    Single u = pow(xqp - a, 1.5);
                    pdf = s * t / u;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    Single s = sqrt(b / (2 * (xqp - a)));
                    sf = erf(s);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            Single s = sqrt(b / (2 * (xqp - a)));
                            res = erfc(s); break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            Single s1 = erfc_inv(xqp);
                            s1 = 2 * s1 * s1;
                            res = a + b / s1; break;
                        } // qtf, Pinv
                    case 7:
                        {
                            Single s1 = erf_inv(xqp);
                            s1 = 2 * s1 * s1;
                            res = a + b / s1; break;
                        } // isf, Qinv
                    case 8: { res = t(8); break; } // Mean
                    case 9: { res = t(9); break; } // Median
                    case 10: { res = t(10); break; } // Mode
                    case 11: { res = t(11); break; } // Variance
                    case 12: { res = t(12); break; } // Stdev
                    case 13: { res = t(13); break; } // Skewness
                    case 14: { res = t(14); break; } // Kurtosis
                    case 15: { res = t(15); break; } // KurtosisExcess
                    case 16: { res = t(16); break; } // support_left
                    case 17: { res = t(17); break; } // support_right
                    case 18: { res = t(18); break; } // range_left
                    case 19: { res = t(19); break; } // range_right
                    default: break;
                }
                return res;
            }

            public LevyDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_levy/*' />
        public static LevyDistClass dist_levy(Single a, Single b)
        {
            return new LevyDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_levy/*' />
        public static LevyDistClass dist_levy(dynamic a, dynamic b)
        {
            return dist_levy(t(a), t(b));
        }

        #endregion




        #region LognormalDist


        public class LognormalDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_LognormalDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_LognormalDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_LognormalDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public LognormalDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LognormalDist/*' />
        public static LognormalDistClass dist_lognormal(Single a, Single b)
        {
            return new LognormalDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LognormalDist/*' />
        public static LognormalDistClass dist_lognormal(dynamic a, dynamic b)
        {
            return dist_lognormal(t(a), t(b));
        }

        #endregion






        #region MoyalDist


        public class MoyalDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = t(0);
                Single pdf = t(0);
                Single sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Single t1 = (xqp - a) / (2 * b);
                    Single t2 = t("0.5") * exp(-(xqp - a) / b);
                    Single s = b * sqrt(2 * pi());
                    pdf = exp(-t1 - t2) / s;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    Single s = exp(-(xqp - a) / (2 * b)) / sqrt(2);
                    sf = erf(s);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            Single s = exp(-(xqp - a) / (2 * b)) / sqrt(2);
                            res = erfc(s); break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            Single s1 = erfc_inv(xqp);
                            s1 = 2 * s1 * s1;
                            res = a - b * log(s1); break;
                        } // qtf, Pinv
                    case 7:
                        {
                            Single s1 = erf_inv(xqp);
                            s1 = 2 * s1 * s1;
                            res = a - b * log(s1); break;
                        } // isf, Qinv
                    case 8: { res = t(8); break; } // Mean
                    case 9: { res = t(9); break; } // Median
                    case 10: { res = t(10); break; } // Mode
                    case 11: { res = t(11); break; } // Variance
                    case 12: { res = t(12); break; } // Stdev
                    case 13: { res = t(13); break; } // Skewness
                    case 14: { res = t(14); break; } // Kurtosis
                    case 15: { res = t(15); break; } // KurtosisExcess
                    case 16: { res = t(16); break; } // support_left
                    case 17: { res = t(17); break; } // support_right
                    case 18: { res = t(18); break; } // range_left
                    case 19: { res = t(19); break; } // range_right
                    default: break;
                }
                return res;
            }

            public MoyalDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_moyal/*' />
        public static MoyalDistClass dist_moyal(Single a, Single b)
        {
            return new MoyalDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_moyal/*' />
        public static MoyalDistClass dist_moyal(dynamic a, dynamic b)
        {
            return dist_moyal(t(a), t(b));
        }

        #endregion





        #region NormalDist


        public class NormalDistClass : BaseDistContClass
        {
            Single mu;
            Single sigma;

            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_NormalDist(target, ref res, ref xqp, ref mu, ref sigma);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_NormalDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_NormalDist(int target, ref Single res, ref Single xqp, ref Single mu, ref Single sigma);

            public NormalDistClass(Single _mu, Single _sigma)
            {
                mu = _mu;
                sigma = _sigma;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NormalDist/*' />
        public static NormalDistClass dist_normal(Single mu, Single sigma)
        {
            return new NormalDistClass(mu, sigma);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NormalDist/*' />
        public static NormalDistClass dist_normal(dynamic mu, dynamic sigma)
        {
            return dist_normal(t(mu), t(sigma));
        }

        #endregion





        #region SkewNormalDist


        public class SkewNormalDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            Single c;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_SkewNormalDist(target, ref res, ref xqp, ref a, ref b, ref c);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_SkewNormalDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_SkewNormalDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b, ref Single c);

            public SkewNormalDistClass(Single _a, Single _b, Single _c)
            {
                a = _a;
                b = _b;
                c = _c;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SkewNormalDist/*' />
        public static SkewNormalDistClass dist_skewnormal(Single a, Single b, Single c)
        {
            return new SkewNormalDistClass(a, b, c);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SkewNormalDist/*' />
        public static SkewNormalDistClass dist_skewnormal(dynamic a, dynamic b, dynamic c)
        {
            return dist_skewnormal(t(a), t(b), t(c));
        }

        #endregion




        #region WaldDist
        // InverseGaussianDist

        public class WaldDistClass : BaseDistContClass
        {
            Single mu;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_WaldDist(target, ref res, ref xqp, ref mu, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_WaldDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_WaldDist(int target, ref Single res, ref Single xqp, ref Single mu, ref Single b);

            public WaldDistClass(Single _mu, Single _b)
            {
                mu = _mu;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WaldDist/*' />
        public static WaldDistClass dist_wald(Single mu, Single b)
        {
            return new WaldDistClass(mu, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WaldDist/*' />
        public static WaldDistClass dist_wald(dynamic mu, dynamic b)
        {
            return dist_wald(t(mu), t(b));
        }

        #endregion





        #endregion



        #region Closed form distributions, based on the incomplete gamma function




        #region ChiDist


        public class ChiDistClass : BaseDistContClass
        {
            Single n;
            internal override Single BaseDist(Single xqp)
            {
                Single res = t(0);
                Single pdf = t(0);
                Single sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    pdf = 2 * xqp * dist_chi2(n).pdf(xqp * xqp);
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    sf = dist_chi2(n).sf(xqp * xqp);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            res = dist_chi2(n).cdf(xqp * xqp); break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            res = sqrt(dist_chi2(n).qtf(xqp)); break;
                        } // qtf, Pinv
                    case 7:
                        {
                            res = sqrt(dist_chi2(n).isf(xqp)); break;
                        } // isf, Qinv
                    case 8: { res = t(8); break; } // Mean
                    case 9: { res = t(9); break; } // Median
                    case 10: { res = t(10); break; } // Mode
                    case 11: { res = t(11); break; } // Variance
                    case 12: { res = t(12); break; } // Stdev
                    case 13: { res = t(13); break; } // Skewness
                    case 14: { res = t(14); break; } // Kurtosis
                    case 15: { res = t(15); break; } // KurtosisExcess
                    case 16: { res = t(16); break; } // support_left
                    case 17: { res = t(17); break; } // support_right
                    case 18: { res = t(18); break; } // range_left
                    case 19: { res = t(19); break; } // range_right
                    default: break;
                }
                return res;
            }

            public ChiDistClass(Single _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_chi/*' />
        public static ChiDistClass dist_chi(Single n)
        {
            return new ChiDistClass(n);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_chi/*' />
        public static ChiDistClass dist_chi(dynamic n)
        {
            return dist_chi(t(n));
        }

        #endregion





        #region Chi2Dist


        public class Chi2DistClass : BaseDistContClass
        {
            Single n;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_Chi2Dist(target, ref res, ref xqp, ref n);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Chi2Dist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_Chi2Dist(int target, ref Single res, ref Single xqp, ref Single n);

            public Chi2DistClass(Single _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2Dist/*' />
        public static Chi2DistClass dist_chi2(Single n)
        {
            return new Chi2DistClass(n);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2Dist/*' />
        public static Chi2DistClass dist_chi2(dynamic n)
        {
            return dist_chi2(t(n));
        }

        #endregion




        #region GammaDist


        public class GammaDistClass : BaseDistContClass
        {
            Single a;
            Single b;

            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_GammaDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_GammaDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_GammaDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public GammaDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GammaDist/*' />
        public static GammaDistClass dist_gamma(Single a, Single b)
        {
            return new GammaDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GammaDist/*' />
        public static GammaDistClass dist_gamma(dynamic a, dynamic b)
        {
            return dist_gamma(t(a), t(b));
        }

        #endregion




        #region InverseChi2Dist
        // a = df, b = scale

        public class InverseChi2DistClass : BaseDistContClass
        {
            Single a;
            Single b;

            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_InverseChi2Dist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_InverseChi2Dist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_InverseChi2Dist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public InverseChi2DistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseChi2Dist/*' />
        public static InverseChi2DistClass dist_inverse_chi2(Single a, Single b)
        {
            return new InverseChi2DistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseChi2Dist/*' />
        public static InverseChi2DistClass dist_inverse_chi2(dynamic a, dynamic b)
        {
            return dist_inverse_chi2(t(a), t(b));
        }

        #endregion




        #region InverseGammaDist
        // a = df, b = scale

        public class InverseGammaDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_InverseGammaDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_InverseGammaDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_InverseGammaDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public InverseGammaDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseGammaDist/*' />
        public static InverseGammaDistClass dist_inverse_gamma(Single a, Single b)
        {
            return new InverseGammaDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseGammaDist/*' />
        public static InverseGammaDistClass dist_inverse_gamma(dynamic a, dynamic b)
        {
            return dist_inverse_gamma(t(a), t(b));
        }

        #endregion




        #region MaxwellDist


        public class MaxwellDistClass : BaseDistContClass
        {
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = t(0);
                Single pdf = t(0);
                Single sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Single s = sqrt(2 / pi());
                    Single t = (xqp * xqp) / (b * b * b);
                    Single u = exp(-(xqp * xqp) / (2 * b * b));
                    pdf = s * t * u;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    Single n = t(1.5);
                    Single t2 = (xqp * xqp) / (2 * b * b);
                    sf = gamma_q(n, t2);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            Single n = t(1.5);
                            Single t2 = (xqp * xqp) / (2 * b * b);
                            res = gamma_p(n, t2);
                            break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            Single n = t(1.5);
                            Single t2 = (xqp * xqp) / (2 * b * b);
                            res = b * sqrt(2 * gamma_p_inv(n, xqp));
                            break;
                        } // qtf, Pinv
                    case 7:
                        {
                            Single n = t(1.5);
                            Single t2 = (xqp * xqp) / (2 * b * b);
                            res = b * sqrt(2 * gamma_q_inv(n, xqp));
                            break;
                        } // isf, Qinv
                    case 8: { res = t(8); break; } // Mean
                    case 9: { res = t(9); break; } // Median
                    case 10: { res = t(10); break; } // Mode
                    case 11: { res = t(11); break; } // Variance
                    case 12: { res = t(12); break; } // Stdev
                    case 13: { res = t(13); break; } // Skewness
                    case 14: { res = t(14); break; } // Kurtosis
                    case 15: { res = t(15); break; } // KurtosisExcess
                    case 16: { res = t(16); break; } // support_left
                    case 17: { res = t(17); break; } // support_right
                    case 18: { res = t(18); break; } // range_left
                    case 19: { res = t(19); break; } // range_right
                    default: break;
                }
                return res;
            }

            public MaxwellDistClass(Single _b)
            {
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_maxwell/*' />
        public static MaxwellDistClass dist_maxwell(Single b)
        {
            return new MaxwellDistClass(b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_maxwell/*' />
        public static MaxwellDistClass dist_maxwell(dynamic b)
        {
            return dist_maxwell(t(b));
        }

        #endregion



        #region NakagamiDist


        public class NakagamiDistClass : BaseDistContClass
        {
            Single m;
            Single w;
            internal override Single BaseDist(Single xqp)
            {
                Single res = t(0);
                Single pdf = t(0);
                Single sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Single s = exp(-m * xqp * xqp / w) * 2 * pow(m / w, m) * pow(xqp, 2 * m - 1);
                    Single t = gamma(m);
                    pdf = s / t;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    sf = gamma_q(m, m * xqp * xqp / w);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            res = gamma_p(m, m * xqp * xqp / w);
                            break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            res = sqrt((w / m) * gamma_p_inv(m, xqp));
                            break;
                        } // qtf, Pinv
                    case 7:
                        {
                            res = sqrt((w / m) * gamma_q_inv(m, xqp));
                            break;
                        } // isf, Qinv
                    case 8: { res = t(8); break; } // Mean
                    case 9: { res = t(9); break; } // Median
                    case 10: { res = t(10); break; } // Mode
                    case 11: { res = t(11); break; } // Variance
                    case 12: { res = t(12); break; } // Stdev
                    case 13: { res = t(13); break; } // Skewness
                    case 14: { res = t(14); break; } // Kurtosis
                    case 15: { res = t(15); break; } // KurtosisExcess
                    case 16: { res = t(16); break; } // support_left
                    case 17: { res = t(17); break; } // support_right
                    case 18: { res = t(18); break; } // range_left
                    case 19: { res = t(19); break; } // range_right
                    default: break;
                }
                return res;
            }

            public NakagamiDistClass(Single _m, Single _w)
            {
                m = _m;
                w = _w;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_nakagami/*' />
        public static NakagamiDistClass dist_nakagami(Single m, Single w)
        {
            return new NakagamiDistClass(m, w);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_nakagami/*' />
        public static NakagamiDistClass dist_nakagami(dynamic a, dynamic b)
        {
            return dist_nakagami(t(a), t(b));
        }

        #endregion






        #endregion



        #region Closed form distributions, based on the incomplete beta function


        #region BetaDist


        public class BetaDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_BetaDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BetaDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_BetaDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public BetaDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaDist/*' />
        public static BetaDistClass dist_beta(Single a, Single b)
        {
            return new BetaDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaDist/*' />
        public static BetaDistClass dist_beta(dynamic a, dynamic b)
        {
            return dist_beta(t(a), t(b));
        }

        #endregion



        #region FisherFDist


        public class FisherFDistClass : BaseDistContClass
        {
            Single m;
            Single n;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_FisherFDist(target, ref res, ref xqp, ref m, ref n);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_FisherFDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_FisherFDist(int target, ref Single res, ref Single xqp, ref Single m, ref Single n);

            public FisherFDistClass(Single _m, Single _n)
            {
                m = _m;
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherFDist/*' />
        public static FisherFDistClass dist_fisher_f(Single m, Single n)
        {
            return new FisherFDistClass(m, n);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherFDist/*' />
        public static FisherFDistClass dist_fisher_f(dynamic m, dynamic n)
        {
            return dist_fisher_f(t(m), t(n));
        }

        #endregion



        #region StudentTDist


        public class StudentTDistClass : BaseDistContClass
        {
            Single n;

            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_StudentTDist(target, ref res, ref xqp, ref n);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_StudentTDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_StudentTDist(int target, ref Single res, ref Single xqp, ref Single n);

            public StudentTDistClass(Single _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTDist/*' />
        public static StudentTDistClass dist_student_t(Single n)
        {
            return new StudentTDistClass(n);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTDist/*' />
        public static StudentTDistClass dist_student_t(dynamic n)
        {
            return dist_student_t(t(n));
        }

        #endregion


        #endregion



        #region Non-central distribution functions


        #region Chi2NcDist


        public class Chi2NcDistClass : BaseDistContClass
        {
            Single n;
            Single lambda1;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_Chi2NcDist(target, ref res, ref xqp, ref n, ref lambda1);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Chi2NcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_Chi2NcDist(int target, ref Single res, ref Single xqp, ref Single n, ref Single lambda1);

            public Chi2NcDistClass(Single _n, Single _lambda1)
            {
                n = _n;
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2NcDist/*' />
        public static Chi2NcDistClass dist_chi2_nc(Single n, Single lambda1)
        {
            return new Chi2NcDistClass(n, lambda1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2NcDist/*' />
        public static Chi2NcDistClass dist_chi2_nc(dynamic n, dynamic lambda1)
        {
            return dist_chi2_nc(t(n), t(lambda1));
        }

        #endregion



        #region StudentTNcDist


        public class StudentTNcDistClass : BaseDistContClass
        {
            Single n;
            Single delta;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_StudentTNcDist(target, ref res, ref xqp, ref n, ref delta);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_StudentTNcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_StudentTNcDist(int target, ref Single res, ref Single xqp, ref Single n, ref Single delta);

            public StudentTNcDistClass(Single _n, Single _delta)
            {
                n = _n;
                delta = _delta;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTNcDist/*' />
        public static StudentTNcDistClass dist_student_t_nc(Single n, Single delta)
        {
            return new StudentTNcDistClass(n, delta);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTNcDist/*' />
        public static StudentTNcDistClass dist_student_t_nc(dynamic n, dynamic delta)
        {
            return dist_student_t_nc(t(n), t(delta));
        }

        #endregion



        #region FisherFNcDist


        public class FisherFNcDistClass : BaseDistContClass
        {
            Single m;
            Single n;
            Single lambda1;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_FisherNcDist(target, ref res, ref xqp, ref m, ref n, ref lambda1);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_FisherNcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_FisherNcDist(int target, ref Single res, ref Single xqp, ref Single m, ref Single n, ref Single lambda1);

            public FisherFNcDistClass(Single _m, Single _n, Single _lambda1)
            {
                m = _m;
                n = _n;
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherNcDist/*' />
        public static FisherFNcDistClass dist_fisher_f_nc(Single m, Single n, Single lambda1)
        {
            return new FisherFNcDistClass(m, n, lambda1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherNcDist/*' />
        public static FisherFNcDistClass dist_fisher_f_nc(dynamic m, dynamic n, dynamic lambda1)
        {
            return dist_fisher_f_nc(t(m), t(n), t(lambda1));
        }

        #endregion



        #region BetaNcDist


        public class BetaNcDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            Single lambda1;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0F;
                Lib_SReal_BetaNcDist(target, ref res, ref xqp, ref a, ref b, ref lambda1);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BetaNcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_BetaNcDist(int target, ref Single res, ref Single xqp, ref Single nu, ref Single mu, ref Single lambda1);

            public BetaNcDistClass(Single _a, Single _b, Single _lambda1)
            {
                a = _a;
                b = _b;
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaNcDist/*' />
        public static BetaNcDistClass dist_beta_nc(Single a, Single b, Single lambda1)
        {
            return new BetaNcDistClass(a, b, lambda1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaNcDist/*' />
        public static BetaNcDistClass dist_beta_nc(dynamic a, dynamic b, dynamic lambda1)
        {
            return dist_beta_nc(t(a), t(b), t(lambda1));
        }

        #endregion



        #endregion



        #region Miscellaneous continuous distributions



        #region KolmogorovSmirnovDist


        public class KolmogorovSmirnovDistClass : BaseDistContClass
        {
            Single n;

            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0f;
                Lib_SReal_KolmogorovSmirnovDist(target, ref res, ref xqp, ref n);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_KolmogorovSmirnovDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_KolmogorovSmirnovDist(int target, ref Single res, ref Single xqp, ref Single a);

            public KolmogorovSmirnovDistClass(Single _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/KolmogorovSmirnovDist/*' />
        public static KolmogorovSmirnovDistClass dist_kolmogorov_smirnov(Single n)
        {
            return new KolmogorovSmirnovDistClass(n);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/KolmogorovSmirnovDist/*' />
        public static KolmogorovSmirnovDistClass dist_kolmogorov_smirnov(dynamic n)
        {
            return dist_kolmogorov_smirnov(t(n));
        }

        #endregion



        #region HoltsmarkDist


        public class HoltsmarkDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0f;
                Lib_SReal_HoltsmarkDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_HoltsmarkDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_HoltsmarkDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public HoltsmarkDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/HoltsmarkDist/*' />
        public static HoltsmarkDistClass dist_holtsmark(Single a, Single b)
        {
            return new HoltsmarkDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/HoltsmarkDist/*' />
        public static HoltsmarkDistClass dist_holtsmark(dynamic a, dynamic b)
        {
            return dist_holtsmark(t(a), t(b));
        }

        #endregion



        #region LandauDist


        public class LandauDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0f;
                Lib_SReal_LandauDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_LandauDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_LandauDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public LandauDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LandauDist/*' />
        public static LandauDistClass dist_landau(Single a, Single b)
        {
            return new LandauDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LandauDist/*' />
        public static LandauDistClass dist_landau(dynamic a, dynamic b)
        {
            return dist_landau(t(a), t(b));
        }

        #endregion



        #region MapAiryDist


        public class MapAiryDistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0f;
                Lib_SReal_MapAiryDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_MapAiryDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_MapAiryDist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public MapAiryDistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/MapAiryDist/*' />
        public static MapAiryDistClass dist_mapairy(Single a, Single b)
        {
            return new MapAiryDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/MapAiryDist/*' />
        public static MapAiryDistClass dist_mapairy(dynamic a, dynamic b)
        {
            return dist_mapairy(t(a), t(b));
        }

        #endregion



        #region Saspoint5Dist


        public class Saspoint5DistClass : BaseDistContClass
        {
            Single a;
            Single b;
            internal override Single BaseDist(Single xqp)
            {
                Single res = 0.0f;
                Lib_SReal_Saspoint5Dist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Saspoint5Dist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_SReal_Saspoint5Dist(int target, ref Single res, ref Single xqp, ref Single a, ref Single b);

            public Saspoint5DistClass(Single _a, Single _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Saspoint5Dist/*' />
        public static Saspoint5DistClass dist_saspoint5(Single a, Single b)
        {
            return new Saspoint5DistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Saspoint5Dist/*' />
        public static Saspoint5DistClass dist_saspoint5(dynamic a, dynamic b)
        {
            return dist_saspoint5(t(a), t(b));
        }

        #endregion



        #endregion






        #endregion





        #region Boost Calculus





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BracketRoot/*' />
        public static Tuple<Single, Single, int> BracketRoot(cb1SSingle1S f, dynamic guess, dynamic factor, bool is_rising, int get_digits, uint maxit)
        {
            return BracketRoot(f, sreal.t(guess), sreal.t(factor), is_rising, get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BracketRoot/*' />
        public static Tuple<Single, Single, int> BracketRoot(cb1SSingle1S f, Single guess, Single factor, bool is_rising, int get_digits, uint maxit)
        {
            var SBracketRoot1 = new SBracketRoot(f, guess, factor, is_rising, get_digits, maxit);
            return SBracketRoot1.Find();
        }
        internal class SBracketRoot
        {
            private cb1SSingle1S F1_;
            private Single guess_;
            private Single factor_;
            private bool is_rising_;
            private int get_digits_;
            private uint maxit_;
            public void funcptr1(ref Single xPtr, ref Single fxPtr)
            {
                fxPtr = F1_(xPtr);
            }
            public SBracketRoot(cb1SSingle1S F1, Single guess, Single factor, bool is_rising, int get_digits, uint maxit)
            {
                F1_ = F1;
                guess_ = guess;
                factor_ = factor;
                is_rising_ = is_rising;
                get_digits_ = get_digits;
                maxit_ = maxit;
            }
            public Tuple<Single, Single, int> Find()
            {
                Single res1 = 0F, res2 = 0F;
                int iter = 0;
                Lib_SReal_BracketRoot2(ref res1, ref res2, ref iter, funcptr1, ref guess_, ref factor_, is_rising_, get_digits_, maxit_);
                return new Tuple<Single, Single, int>(res1, res2, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_BracketRoot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_BracketRoot2(ref Single res1, ref Single res2, ref int iter, cb2RefSingle f, ref Single guess, ref Single factor, bool is_rising, int get_digits, uint maxit);




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NewtonRaphson/*' />
        public static Tuple<Single, int> NewtonRaphson(cb1SSingle1S f, cb1SSingle1S df, dynamic guess, dynamic xmin, dynamic xmax, int get_digits, uint maxit)
        {
            return NewtonRaphson(f, df, sreal.t(guess), sreal.t(xmin), sreal.t(xmax), get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NewtonRaphson/*' />
        public static Tuple<Single, int> NewtonRaphson(cb1SSingle1S f, cb1SSingle1S df, Single guess, Single xmin, Single xmax, int get_digits, uint maxit)
        {
            var SNewtonRaphson1 = new SNewtonRaphson(f, df, guess, xmin, xmax, get_digits, maxit);
            return SNewtonRaphson1.Find();
        }
        internal class SNewtonRaphson
        {
            private cb1SSingle1S F1_;
            private cb1SSingle1S DF1_;
            private Single guess_;
            private Single xmin_;
            private Single xmax_;
            private int get_digits_;
            private uint maxit_;
            public void funcptr0(ref Single xPtr, ref Single fxPtr)
            {
                fxPtr = F1_(xPtr);
            }
            public void funcptr1(ref Single dxPtr, ref Single dfxPtr)
            {
                dfxPtr = DF1_(dxPtr);
            }
            public SNewtonRaphson(cb1SSingle1S F1, cb1SSingle1S DF1, Single guess, Single xmin, Single xmax, int get_digits, uint maxit)
            {
                F1_ = F1;
                DF1_ = DF1;
                guess_ = guess;
                xmin_ = xmin;
                xmax_ = xmax;
                get_digits_ = get_digits;
                maxit_ = maxit;
            }
            public Tuple<Single, int> Find()
            {
                var res1 = new Single();
                int iter = 0;
                Lib_SReal_NewtonRaphson(ref res1, ref iter, funcptr0, funcptr1, ref guess_, ref xmin_, ref xmax_, get_digits_, maxit_);
                return new Tuple<Single, int>(res1, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_NewtonRaphson", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_NewtonRaphson(ref Single res, ref int iter, cb2RefSingle f1, cb2RefSingle df1, ref Single guess, ref Single xmin, ref Single xmax, int get_digits, uint maxit);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Halley/*' />
        public static Tuple<Single, int> Halley(cb1SSingle1S f, cb1SSingle1S df1, cb1SSingle1S df2, dynamic guess, dynamic xmin, dynamic xmax, int get_digits, uint maxit)
        {
            return Halley(f, df1, df2, sreal.t(guess), sreal.t(xmin), sreal.t(xmax), get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Halley/*' />
        public static Tuple<Single, int> Halley(cb1SSingle1S f, cb1SSingle1S df1, cb1SSingle1S df2, Single guess, Single xmin, Single xmax, int get_digits, uint maxit)
        {
            var SHalley1 = new SHalley(f, df1, df2, guess, xmin, xmax, get_digits, maxit);
            return SHalley1.Find();
        }
        internal class SHalley
        {
            private cb1SSingle1S F1_;
            private cb1SSingle1S DF1_;
            private cb1SSingle1S DF2_;
            private Single guess_;
            private Single xmin_;
            private Single xmax_;
            private int get_digits_;
            private uint maxit_;
            public void funcptr0(ref Single xPtr, ref Single fxPtr)
            {
                fxPtr = F1_(xPtr);
            }
            public void funcptr1(ref Single dxPtr, ref Single dfxPtr)
            {
                dfxPtr = DF1_(dxPtr);
            }
            public void funcptr2(ref Single d2xPtr, ref Single d2fxPtr)
            {
                d2fxPtr = DF2_(d2xPtr);
            }
            public SHalley(cb1SSingle1S F1, cb1SSingle1S DF1, cb1SSingle1S DF2, Single guess, Single xmin, Single xmax, int get_digits, uint maxit)
            {
                F1_ = F1;
                DF1_ = DF1;
                DF2_ = DF2;
                guess_ = guess;
                xmin_ = xmin;
                xmax_ = xmax;
                get_digits_ = get_digits;
                maxit_ = maxit;
            }
            public Tuple<Single, int> Find()
            {
                var res1 = new Single();
                int iter = 0;
                Lib_SReal_Halley(ref res1, ref iter, funcptr0, funcptr1, funcptr2, ref guess_, ref xmin_, ref xmax_, get_digits_, maxit_);
                return new Tuple<Single, int>(res1, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Halley", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Halley(ref Single res1, ref int iter, cb2RefSingle f1, cb2RefSingle df1, cb2RefSingle df2, ref Single guess, ref Single xmin, ref Single xmax, int get_digits, uint maxit);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Schroder/*' />
        public static Tuple<Single, int> Schroder(cb1SSingle1S f, cb1SSingle1S df1, cb1SSingle1S df2, dynamic guess, dynamic xmin, dynamic xmax, int get_digits, uint maxit)
        {
            return Schroder(f, df1, df2, sreal.t(guess), sreal.t(xmin), sreal.t(xmax), get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Schroder/*' />
        public static Tuple<Single, int> Schroder(cb1SSingle1S f, cb1SSingle1S df1, cb1SSingle1S df2, Single guess, Single xmin, Single xmax, int get_digits, uint maxit)
        {
            var SSchroder1 = new SSchroder(f, df1, df2, guess, xmin, xmax, get_digits, maxit);
            return SSchroder1.Find();
        }
        internal class SSchroder
        {
            private cb1SSingle1S F1_;
            private cb1SSingle1S DF1_;
            private cb1SSingle1S DF2_;
            private Single guess_;
            private Single xmin_;
            private Single xmax_;
            private int get_digits_;
            private uint maxit_;
            public void funcptr0(ref Single xPtr, ref Single fxPtr)
            {
                fxPtr = F1_(xPtr);
            }
            public void funcptr1(ref Single dxPtr, ref Single dfxPtr)
            {
                dfxPtr = DF1_(dxPtr);
            }
            public void funcptr2(ref Single d2xPtr, ref Single d2fxPtr)
            {
                d2fxPtr = DF2_(d2xPtr);
            }
            public SSchroder(cb1SSingle1S F1, cb1SSingle1S DF1, cb1SSingle1S DF2, Single guess, Single xmin, Single xmax, int get_digits, uint maxit)
            {
                F1_ = F1;
                DF1_ = DF1;
                DF2_ = DF2;
                guess_ = guess;
                xmin_ = xmin;
                xmax_ = xmax;
                get_digits_ = get_digits;
                maxit_ = maxit;
            }
            public Tuple<Single, int> Find()
            {
                var res1 = new Single();
                int iter = 0;
                Lib_SReal_Schroder(ref res1, ref iter, funcptr0, funcptr1, funcptr2, ref guess_, ref xmin_, ref xmax_, get_digits_, maxit_);
                return new Tuple<Single, int>(res1, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Schroder", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Schroder(ref Single res1, ref int iter, cb2RefSingle f1, cb2RefSingle df1, cb2RefSingle df2, ref Single guess, ref Single xmin, ref Single xmax, int get_digits, uint maxit);







        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BrentMinimum/*' />
        public static Tuple<Single, Single, int> Brent_Minimum(cb1SSingle1S f, dynamic bracket_min, dynamic bracket_max, int bits, uint maxit)
        {
            return Brent_Minimum(f, sreal.t(bracket_min), sreal.t(bracket_max), bits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BrentMinimum/*' />
        public static Tuple<Single, Single, int> Brent_Minimum(cb1SSingle1S f, Single bracket_min, Single bracket_max, int bits, uint maxit)
        {
            var SBrent_Minimum1 = new SBrent_Minimum(f, bracket_min, bracket_max, bits, maxit);
            return SBrent_Minimum1.Find();
        }
        internal class SBrent_Minimum
        {
            private cb1SSingle1S F1_;
            private Single bracket_min_;
            private Single bracket_max_;
            private int bits_;
            private uint maxit_;
            public void funcptr1(ref Single xPtr, ref Single fxPtr)
            {
                fxPtr = F1_(xPtr);
            }
            public SBrent_Minimum(cb1SSingle1S F1, Single bracket_min, Single bracket_max, int bits, uint maxit)
            {
                F1_ = F1;
                bracket_min_ = bracket_min;
                bracket_max_ = bracket_max;
                bits_ = bits;
                maxit_ = maxit;
            }
            public Tuple<Single, Single, int> Find()
            {
                var result = new Single();
                var resultFx = new Single();
                int iter = 0;
                Lib_SReal_Brent_Minimum(ref result, ref resultFx, ref iter, funcptr1, ref bracket_min_, ref bracket_max_, bits_, maxit_);
                return new Tuple<Single, Single, int>(result, resultFx, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Brent_Minimum", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Brent_Minimum(ref Single res, ref Single resFx, ref int iter, cb2RefSingle f, ref Single bracket_min, ref Single bracket_max, int bits, uint maxit);




        // ******************************************************************************************************************************************************************************************************************






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Trapezoidal/*' />
        public static Tuple<Single, Single, Single> Trapezoidal(cb1SSingle1S f, dynamic a, dynamic b, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return Trapezoidal(f, sreal.t(a), sreal.t(b), sreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Trapezoidal/*' />
        public static Tuple<Single, Single, Single> Trapezoidal(cb1SSingle1S f, Single a, Single b, Single tol, uint max_refinements = 12)
        {
            var STrapezoidal21 = new STrapezoidal2(f, a, b);
            return STrapezoidal21.Integrate();
        }
        internal class STrapezoidal2
        {
            private cb1SSingle1S F1_;
            private Single a_;
            private Single b_;
            public void funcptr1(ref Single xPtr, ref Single fxPtr)
            {
                fxPtr = F1_(xPtr);
            }
            public STrapezoidal2(cb1SSingle1S F1, Single a, Single b)
            {
                F1_ = F1;
                a_ = a;
                b_ = b;
            }
            public Tuple<Single, Single, Single> Integrate()
            {
                Single res1 = 0F, res2 = 0F, res3 = 0F;
                Lib_SReal_Trapezoidal2(ref res1, ref res2, ref res3, funcptr1, ref a_, ref b_);
                return new Tuple<Single, Single, Single>(res1, res2, res3);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Trapezoidal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Trapezoidal2(ref Single res1, ref Single res2, ref Single res3, cb2RefSingle f, ref Single a, ref Single b);







        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussLegendre/*' />
        public static Tuple<Single, Single> GaussLegendre(cb1SSingle1S f, dynamic a, dynamic b)
        {
            return GaussLegendre(f, sreal.t(a), sreal.t(b));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussLegendre/*' />
        public static Tuple<Single, Single> GaussLegendre(cb1SSingle1S f, Single a, Single b)
        {
            var SGaussLegendre1 = new SGaussLegendre(f, a, b);
            return SGaussLegendre1.Integrate();
        }
        internal class SGaussLegendre
        {
            private cb1SSingle1S F1_;
            private Single a_;
            private Single b_;
            public void funcptr1(ref Single xPtr, ref Single fxPtr)
            {
                fxPtr = F1_(xPtr);
            }
            public SGaussLegendre(cb1SSingle1S F1, Single a, Single b)
            {
                F1_ = F1;
                a_ = a;
                b_ = b;
            }
            public Tuple<Single, Single> Integrate()
            {
                Single res1 = new Single(), res3 = new Single();
                Lib_SReal_GaussLegendre(ref res1, ref res3, funcptr1, ref a_, ref b_);
                return new Tuple<Single, Single>(res1, res3);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_GaussLegendre", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_GaussLegendre(ref Single res1, ref Single res3, cb2RefSingle f, ref Single a, ref Single b);





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussKronrod/*' />
        public static Tuple<Single, Single, Single> GaussKronrod(cb1SSingle1S f, dynamic a, dynamic b, dynamic tol = null, uint max_depth = 12)
        {
            if (tol == null) { tol = t(0); }
            return GaussKronrod(f, sreal.t(a), sreal.t(b), sreal.t(tol), max_depth);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussKronrod/*' />
        public static Tuple<Single, Single, Single> GaussKronrod(cb1SSingle1S f, Single a, Single b, Single tol, uint max_depth = 12)
        {
            var SGaussKronrod1 = new SGaussKronrod(f, a, b);
            return SGaussKronrod1.Integrate();
        }
        internal class SGaussKronrod
        {
            private cb1SSingle1S F1_;
            private Single a_;
            private Single b_;
            public void funcptr1(ref Single xPtr, ref Single fxPtr)
            {
                fxPtr = F1_(xPtr);
            }
            public SGaussKronrod(cb1SSingle1S F1, Single a, Single b)
            {
                F1_ = F1;
                a_ = a;
                b_ = b;
            }
            public Tuple<Single, Single, Single> Integrate()
            {
                Single res1 = new Single(), res2 = new Single(), res3 = new Single();
                Lib_SReal_GaussKronrod(ref res1, ref res2, ref res3, funcptr1, ref a_, ref b_);
                return new Tuple<Single, Single, Single>(res1, res2, res3);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_GaussKronrod", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_GaussKronrod(ref Single res1, ref Single res2, ref Single res3, cb2RefSingle f, ref Single a, ref Single b);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TanhSinh/*' />
        public static Tuple<Single, Single, Single, int> TanhSinh(cb1SSingle1S f, dynamic a, dynamic b, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return TanhSinh(f, sreal.t(a), sreal.t(b), sreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TanhSinh/*' />
        public static Tuple<Single, Single, Single, int> TanhSinh(cb1SSingle1S f, Single a, Single b, Single tol, uint max_refinements = 12)
        {
            var STanhSinh1 = new STanhSinh(f, a, b);
            return STanhSinh1.Integrate();
        }
        internal class STanhSinh
        {
            private cb1SSingle1S F1_;
            private Single a_;
            private Single b_;
            public void funcptr1(ref Single xPtr, ref Single fxPtr)
            {
                fxPtr = F1_(xPtr);
            }
            public STanhSinh(cb1SSingle1S F1, Single a, Single b)
            {
                F1_ = F1;
                a_ = a;
                b_ = b;
            }
            public Tuple<Single, Single, Single, int> Integrate()
            {
                Single res1 = new Single(), res2 = new Single(), res3 = new Single();
                int levels = 0;
                Lib_SReal_TanhSinh(ref res1, ref res2, ref res3, ref levels, funcptr1, ref a_, ref b_);
                return new Tuple<Single, Single, Single, int>(res1, res2, res3, levels);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_TanhSinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_TanhSinh(ref Single res1, ref Single res2, ref Single res3, ref int levels, cb2RefSingle f, ref Single a, ref Single b);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SinhSinh/*' />
        public static Tuple<Single, Single, Single, int> SinhSinh(cb1SSingle1S f, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return SinhSinh(f, sreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SinhSinh/*' />
        public static Tuple<Single, Single, Single, int> SinhSinh(cb1SSingle1S f, Single tol, uint max_refinements = 12)
        {
            var SSinhSinh1 = new SSinhSinh(f);
            return SSinhSinh1.Integrate();
        }
        internal class SSinhSinh
        {
            private cb1SSingle1S F1_;
            public void funcptr1(ref Single xPtr, ref Single fxPtr)
            {
                fxPtr = F1_(xPtr);
            }
            public SSinhSinh(cb1SSingle1S F1)
            {
                F1_ = F1;
            }
            public Tuple<Single, Single, Single, int> Integrate()
            {
                Single res1 = new Single(), res2 = new Single(), res3 = new Single();
                int levels = 0;
                Lib_SReal_SinhSinh(ref res1, ref res2, ref res3, ref levels, funcptr1);
                return new Tuple<Single, Single, Single, int>(res1, res2, res3, levels);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_SinhSinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_SinhSinh(ref Single res1, ref Single res2, ref Single res3, ref int levels, cb2RefSingle f);







        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExpSinh/*' />
        public static Tuple<Single, Single, Single, int> ExpSinh(cb1SSingle1S f, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return ExpSinh(f, sreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExpSinh/*' />
        public static Tuple<Single, Single, Single, int> ExpSinh(cb1SSingle1S f, Single tol, uint max_refinements = 12)
        {
            var SExpSinh1 = new SExpSinh(f);
            return SExpSinh1.Integrate();
        }
        internal class SExpSinh
        {
            private cb1SSingle1S F1_;
            public void funcptr1(ref Single xPtr, ref Single fxPtr)
            {
                fxPtr = F1_(xPtr);
            }
            public SExpSinh(cb1SSingle1S F1)
            {
                F1_ = F1;
            }
            public Tuple<Single, Single, Single, int> Integrate()
            {
                Single res1 = new Single(), res2 = new Single(), res3 = new Single();
                int levels = 0;
                Lib_SReal_ExpSinh(ref res1, ref res2, ref res3, ref levels, funcptr1);
                return new Tuple<Single, Single, Single, int>(res1, res2, res3, levels);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_ExpSinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_ExpSinh(ref Single res1, ref Single res2, ref Single res3, ref int levels, cb2RefSingle f);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/OouraCos/*' />
        public static Tuple<Single, Single> Ooura_Cos(cb1SSingle1S f)
        {
            var SOoura_Cos1 = new SOoura_Cos(f);
            return SOoura_Cos1.Integrate();
        }
        internal class SOoura_Cos
        {
            private cb1SSingle1S F1_;
            public void funcptr1(ref Single xPtr, ref Single fxPtr)
            {
                fxPtr = F1_(xPtr);
            }
            public SOoura_Cos(cb1SSingle1S F1)
            {
                F1_ = F1;
            }
            public Tuple<Single, Single> Integrate()
            {
                Single res1 = 0.0F, res2 = 0.0F;
                Lib_SReal_Ooura_Cos(ref res1, ref res2, funcptr1);
                return new Tuple<Single, Single>(res1, res2);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Ooura_Cos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Ooura_Cos(ref Single res1, ref Single res2, cb2RefSingle f);





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/OouraSin/*' />
        public static Tuple<Single, Single> Ooura_Sin(cb1SSingle1S f)
        {
            var SOoura_Sin1 = new SOoura_Sin(f);
            return SOoura_Sin1.Integrate();
        }
        internal class SOoura_Sin
        {
            private cb1SSingle1S F1_;
            public void funcptr1(ref Single xPtr, ref Single fxPtr)
            {
                fxPtr = F1_(xPtr);
            }
            public SOoura_Sin(cb1SSingle1S F1)
            {
                F1_ = F1;
            }
            public Tuple<Single, Single> Integrate()
            {
                Single res1 = 0.0F, res2 = 0.0F;
                Lib_SReal_Ooura_Sin(ref res1, ref res2, funcptr1);
                return new Tuple<Single, Single>(res1, res2);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Ooura_Sin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Ooura_Sin(ref Single res1, ref Single res2, cb2RefSingle f);




        #endregion






        #region Boost Odeint




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RungeKutta4Const/*' />
        public static void RungeKutta4Const(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, Single StartTime, Single EndTime, Single dt)
        {
            var SOdeint1 = new SOdeintConst(1, F1, F2, matInput, StartTime, EndTime, dt);
            SOdeint1.Integrate();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RungeKutta4Const/*' />
        public static void RungeKutta4Const(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            RungeKutta4Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void CashKarp54Const(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, Single StartTime, Single EndTime, Single dt)
        {
            var SOdeint1 = new SOdeintConst(2, F1, F2, matInput, StartTime, EndTime, dt);
            SOdeint1.Integrate();
        }


        public static void CashKarp54Const(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            CashKarp54Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void DormandPrince5Const(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, Single StartTime, Single EndTime, Single dt)
        {
            var SOdeint1 = new SOdeintConst(3, F1, F2, matInput, StartTime, EndTime, dt);
            SOdeint1.Integrate();
        }


        public static void DormandPrince5Const(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            DormandPrince5Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void Fehlberg78Const(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, Single StartTime, Single EndTime, Single dt)
        {
            var SOdeint1 = new SOdeintConst(4, F1, F2, matInput, StartTime, EndTime, dt);
            SOdeint1.Integrate();
        }


        public static void Fehlberg78Const(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            Fehlberg78Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void AdamsBashforthMoultonConst(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, Single StartTime, Single EndTime, Single dt)
        {
            var SOdeint1 = new SOdeintConst(5, F1, F2, matInput, StartTime, EndTime, dt);
            SOdeint1.Integrate();
        }


        public static void AdamsBashforthMoultonConst(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            AdamsBashforthMoultonConst(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        internal class SOdeintConst
        {
            private int what_;
            private cbSingle1S2V F1_;
            private cbSingle1S1V F2_;
            private SingleVec matInit_ = new SingleVec();
            private SingleVec matX = new SingleVec();
            private SingleVec matY = new SingleVec();
            private Single StartTime_ = 0.0F;
            private Single EndTime_ = 0.0F;
            private Single dt_ = 0.0F;


            public void funcptr1(IntPtr xPtr, IntPtr fxPtr, ref Single t)
            {
                IntPtr tempxPtr = matX.mpPtr;
                matX.mpPtr = xPtr;
                IntPtr tempyPtr = matY.mpPtr;
                matY.mpPtr = fxPtr;
                F1_(t, matX, matY);
                matX.mpPtr = tempxPtr;
                matY.mpPtr = tempyPtr;
            }

            public void funcptr2(IntPtr xPtr, ref Single t)
            {
                IntPtr tempxPtr = matX.mpPtr;
                matX.mpPtr = xPtr;
                F2_(t, matX);
                matX.mpPtr = tempxPtr;
            }



            internal SOdeintConst(int what, cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInit, Single StartTime, Single EndTime, Single dt)
            {
                what_ = what;
                StartTime_ = StartTime;
                EndTime_ = EndTime;
                dt_ = dt;
                matInit_ = matInit; // Shallow copy
                F1_ = F1;
                F2_ = F2;
            }
            internal void Integrate()
            {
                switch (what_)
                {
                    case 1:
                        SReal_Const_RungeKutta4(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 2:
                        SReal_Const_CashKarp54(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 3:
                        SReal_Const_Dopri5(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 4:
                        SReal_Const_Fehlberg78(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 5:
                        SReal_Const_AdamsBashforthMoulton(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    default:
                        Console.WriteLine("Not found");
                        break;
                }
            }
        }

        public static void SReal_Const_RungeKutta4(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, SingleVec matX, Single StartTime, Single EndTime, Single dt)
        {
            Lib_SReal_Const_RungeKutta4(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Const_RungeKutta4", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Const_RungeKutta4(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, IntPtr MatrixPtr_source, ref Single StartTime, ref Single EndTime, ref Single dt);


        public static void SReal_Const_CashKarp54(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, SingleVec matX, Single StartTime, Single EndTime, Single dt)
        {
            Lib_SReal_Const_CashKarp54(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Const_CashKarp54", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Const_CashKarp54(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, IntPtr MatrixPtr_source, ref Single StartTime, ref Single EndTime, ref Single dt);


        public static void SReal_Const_Dopri5(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, SingleVec matX, Single StartTime, Single EndTime, Single dt)
        {
            Lib_SReal_Const_Dopri5(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Const_Dopri5", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Const_Dopri5(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, IntPtr MatrixPtr_source, ref Single StartTime, ref Single EndTime, ref Single dt);


        public static void SReal_Const_Fehlberg78(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, SingleVec matX, Single StartTime, Single EndTime, Single dt)
        {
            Lib_SReal_Const_Fehlberg78(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Const_Fehlberg78", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Const_Fehlberg78(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, IntPtr MatrixPtr_source, ref Single StartTime, ref Single EndTime, ref Single dt);


        public static void SReal_Const_AdamsBashforthMoulton(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, SingleVec matX, Single StartTime, Single EndTime, Single dt)
        {
            Lib_SReal_Const_AdamsBashforthMoulton(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Const_AdamsBashforthMoulton", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Const_AdamsBashforthMoulton(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, IntPtr MatrixPtr_source, ref Single StartTime, ref Single EndTime, ref Single dt);









        // ***********************************************************************************************************









        /// <include file="docs.xml" path='docs/members[@name="Boost"]/DormandPrince5Adaptive/*' />
        public static void DormandPrince5Adaptive(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, Single StartTime, Single EndTime, Single dt, Single epsabs, Single epsrel)
        {
            var SOdeint1 = new SOdeintAdaptiveDenseOutput(1, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            SOdeint1.Integrate();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/DormandPrince5Adaptive/*' />
        public static void DormandPrince5Adaptive(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            DormandPrince5Adaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void CashKarp54Adaptive(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, Single StartTime, Single EndTime, Single dt, Single epsabs, Single epsrel)
        {
            var SOdeint1 = new SOdeintAdaptiveDenseOutput(2, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            SOdeint1.Integrate();
        }


        public static void CashKarp54Adaptive(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            CashKarp54Adaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void Fehlberg78Adaptive(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, Single StartTime, Single EndTime, Single dt, Single epsabs, Single epsrel)
        {
            var SOdeint1 = new SOdeintAdaptiveDenseOutput(3, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            SOdeint1.Integrate();
        }


        public static void Fehlberg78Adaptive(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            Fehlberg78Adaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void BulirschStoerAdaptive(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, Single StartTime, Single EndTime, Single dt, Single epsabs, Single epsrel)
        {
            var SOdeint1 = new SOdeintAdaptiveDenseOutput(4, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            SOdeint1.Integrate();
        }


        public static void BulirschStoerAdaptive(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            BulirschStoerAdaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void DormandPrince5DenseOutput(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, Single StartTime, Single EndTime, Single dt, Single epsabs, Single epsrel)
        {
            var SOdeint1 = new SOdeintAdaptiveDenseOutput(5, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            SOdeint1.Integrate();
        }


        public static void DormandPrince5DenseOutput(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            DormandPrince5DenseOutput(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void BulirschStoerDenseOutput(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, Single StartTime, Single EndTime, Single dt, Single epsabs, Single epsrel)
        {
            var SOdeint1 = new SOdeintAdaptiveDenseOutput(6, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            SOdeint1.Integrate();
        }


        public static void BulirschStoerDenseOutput(cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            BulirschStoerDenseOutput(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        internal class SOdeintAdaptiveDenseOutput
        {
            int what_;
            private cbSingle1S2V F1_;
            private cbSingle1S1V F2_;
            private SingleVec matInit_ = new SingleVec();
            private SingleVec matX = new SingleVec();
            private SingleVec matY = new SingleVec();
            private Single StartTime_ = 0.0F;
            private Single EndTime_ = 0.0F;
            private Single dt_ = 0.0F;
            private Single epsabs_ = 0.0F;
            private Single epsrel_ = 0.0F;
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr, ref Single t)
            {
                IntPtr tempxPtr = matX.mpPtr;
                matX.mpPtr = xPtr;
                IntPtr tempyPtr = matY.mpPtr;
                matY.mpPtr = fxPtr;
                F1_(t, matX, matY);
                matX.mpPtr = tempxPtr;
                matY.mpPtr = tempyPtr;
            }
            public void funcptr2(IntPtr xPtr, ref Single t)
            {
                IntPtr tempxPtr = matX.mpPtr;
                matX.mpPtr = xPtr;
                F2_(t, matX);
                matX.mpPtr = tempxPtr;
            }
            internal SOdeintAdaptiveDenseOutput(int what, cbSingle1S2V F1, cbSingle1S1V F2, SingleVec matInit, Single StartTime, Single EndTime, Single dt, Single epsabs, Single epsrel)
            {
                what_ = what;
                StartTime_ = StartTime;
                EndTime_ = EndTime;
                dt_ = dt;
                matInit_ = matInit; // Shallow copy
                F1_ = F1;
                F2_ = F2;
                epsabs_ = epsabs;
                epsrel_ = epsrel;
            }
            internal void Integrate()
            {
                switch (what_)
                {
                    case 1:
                        SReal_Adaptive_RungeKuttaDopri5(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 2:
                        SReal_Adaptive_CashKarp54(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 3:
                        SReal_Adaptive_Fehlberg78(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 4:
                        SReal_Adaptive_BulirschStoer(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 5:
                        SReal_DenseOutput_Dopri5(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 6:
                        SReal_DenseOutput_BulirschStoer(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    default:
                        Console.WriteLine("Not found");
                        break;
                }
            }
        }
        public static void SReal_Adaptive_RungeKuttaDopri5(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, SingleVec matX, Single StartTime, Single EndTime, Single dt, Single epsabs, Single epsrel)
        {
            Lib_SReal_Adaptive_Dopri5(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt, ref epsabs, ref epsrel);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Adaptive_Dopri5", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Adaptive_Dopri5(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, IntPtr MatrixPtr_source, ref Single StartTime, ref Single EndTime, ref Single dt, ref Single epsabs, ref Single epsrel);


        public static void SReal_Adaptive_CashKarp54(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, SingleVec matX, Single StartTime, Single EndTime, Single dt, Single epsabs, Single epsrel)
        {
            Lib_SReal_Adaptive_CashKarp54(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt, ref epsabs, ref epsrel);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Adaptive_CashKarp54", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Adaptive_CashKarp54(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, IntPtr MatrixPtr_source, ref Single StartTime, ref Single EndTime, ref Single dt, ref Single epsabs, ref Single epsrel);


        public static void SReal_Adaptive_Fehlberg78(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, SingleVec matX, Single StartTime, Single EndTime, Single dt, Single epsabs, Single epsrel)
        {
            Lib_SReal_Adaptive_Fehlberg78(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt, ref epsabs, ref epsrel);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Adaptive_Fehlberg78", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Adaptive_Fehlberg78(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, IntPtr MatrixPtr_source, ref Single StartTime, ref Single EndTime, ref Single dt, ref Single epsabs, ref Single epsrel);


        public static void SReal_Adaptive_BulirschStoer(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, SingleVec matX, Single StartTime, Single EndTime, Single dt, Single epsabs, Single epsrel)
        {
            Lib_SReal_Adaptive_BulirschStoer(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt, ref epsabs, ref epsrel);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_Adaptive_BulirschStoer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_Adaptive_BulirschStoer(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, IntPtr MatrixPtr_source, ref Single StartTime, ref Single EndTime, ref Single dt, ref Single epsabs, ref Single epsrel);


        public static void SReal_DenseOutput_Dopri5(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, SingleVec matX, Single StartTime, Single EndTime, Single dt, Single epsabs, Single epsrel)
        {
            Lib_SReal_DenseOutput_Dopri5(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt, ref epsabs, ref epsrel);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_DenseOutput_Dopri5", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_DenseOutput_Dopri5(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, IntPtr MatrixPtr_source, ref Single StartTime, ref Single EndTime, ref Single dt, ref Single epsabs, ref Single epsrel);


        public static void SReal_DenseOutput_BulirschStoer(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, SingleVec matX, Single StartTime, Single EndTime, Single dt, Single epsabs, Single epsrel)
        {
            Lib_SReal_DenseOutput_BulirschStoer(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt, ref epsabs, ref epsrel);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SReal_DenseOutput_BulirschStoer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SReal_DenseOutput_BulirschStoer(cb2Ptr1RefSingle F1, cb1Ptr1RefSingle F2, IntPtr MatrixPtr_source, ref Single StartTime, ref Single EndTime, ref Single dt, ref Single epsabs, ref Single epsrel);











        #endregion





        #region Eigen calculus


        public static SingleMat PowellHybrd(cbSingle2M F1, cbSingle2M F2, SingleMat matInput)
        {
            var SPowellHybrd1 = new SPowellHybrd(F1, F2, matInput);
            var matX = SPowellHybrd1.Solve();
            return matX;
        }
        internal class SPowellHybrd
        {
            private cbSingle2M F1_;
            private cbSingle2M F2_;
            private SingleMat matX1 = new SingleMat();
            private SingleMat matY1 = new SingleMat();
            private SingleMat matX2 = new SingleMat();
            private SingleMat matY2 = new SingleMat();
            private SingleMat matInput_ = new SingleMat();
            private SingleMat matX = new SingleMat();
            private SingleMat matFvec = new SingleMat();
            private SingleMat matFjac = new SingleMat();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                IntPtr tempxPtr = matX1.mpPtr;
                matX1.mpPtr = xPtr;
                IntPtr tempyPtr = matY1.mpPtr;
                matY1.mpPtr = fxPtr;
                F1_(matX1, matY1);
                matX1.mpPtr = tempxPtr;
                matY1.mpPtr = tempyPtr;
            }
            public void funcptr2(IntPtr xPtr, IntPtr fxPtr)
            {
                IntPtr tempxPtr = matX2.mpPtr;
                matX2.mpPtr = xPtr;
                IntPtr tempyPtr = matY2.mpPtr;
                matY2.mpPtr = fxPtr;
                F2_(matX2, matY2);
                matX2.mpPtr = tempxPtr;
                matY2.mpPtr = tempyPtr;
            }
            internal SPowellHybrd(cbSingle2M F1, cbSingle2M F2, SingleMat matInput)
            {
                int n = matInput.rows;
                matX.Resize(n, 1);
                matFvec.Resize(n, 1);
                matFjac.Resize(n, n);
                matInput_ = matInput; // Shallow copy
                F1_ = F1;
                F2_ = F2;
            }
            internal SingleMat Solve()
            {
                slib.testHybrj_ext(funcptr1, funcptr2, matX, matFvec, matFjac, matInput_);
                return matX;
            }
        }




        public static SingleMat Levenberg(cbSingle2M F1, cbSingle2M F2, SingleMat matInput, int n, int m)
        {
            var SLevenberg1 = new SLevenberg(F1, F2, matInput, n, m);
            var matX = SLevenberg1.Solve();
            return matX;
        }
        internal class SLevenberg
        {
            private cbSingle2M F1_;
            private cbSingle2M F2_;
            private SingleMat matX1 = new SingleMat();
            private SingleMat matY1 = new SingleMat();
            private SingleMat matX2 = new SingleMat();
            private SingleMat matY2 = new SingleMat();
            private SingleMat matInput_ = new SingleMat();
            private SingleMat matX = new SingleMat();
            private SingleMat matFvec = new SingleMat();
            private SingleMat matFjac = new SingleMat();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                IntPtr tempxPtr = matX1.mpPtr;
                matX1.mpPtr = xPtr;
                IntPtr tempyPtr = matY1.mpPtr;
                matY1.mpPtr = fxPtr;
                F1_(matX1, matY1);
                matX1.mpPtr = tempxPtr;
                matY1.mpPtr = tempyPtr;
            }
            public void funcptr2(IntPtr xPtr, IntPtr fxPtr)
            {
                IntPtr tempxPtr = matX2.mpPtr;
                matX2.mpPtr = xPtr;
                IntPtr tempyPtr = matY2.mpPtr;
                matY2.mpPtr = fxPtr;
                F2_(matX2, matY2);
                matX2.mpPtr = tempxPtr;
                matY2.mpPtr = tempyPtr;
            }
            internal SLevenberg(cbSingle2M F1, cbSingle2M F2, SingleMat matInput, int n, int m)
            {
                matX.Resize(n, 1);
                matFvec.Resize(m, 1);
                matFjac.Resize(n, n);
                matInput_ = matInput; // Shallow copy
                F1_ = F1;
                F2_ = F2;
            }
            internal SingleMat Solve()
            {
                slib.testLmder_ext(funcptr1, funcptr2, matX, matFvec, matFjac, matInput_);
                return matX;
            }
        }









        #endregion






        #region Boost/CppOptLib


        public static SingleVec NelderMeadSolver(cb1SSingle1V F1, SingleVec matInput)
        {
            var SSolver11 = new SOptSolver1(constants.mp_nelder_mead_solver, F1, matInput);
            return SSolver11.Solve();
        }

        public static SingleVec CMAesSolver(cb1SSingle1V F1, SingleVec matInput)
        {
            var SSolver11 = new SOptSolver1(constants.mp_cma_es_solver, F1, matInput);
            return SSolver11.Solve();
        }

        internal class SOptSolver1
        {
            private int what_;
            private cb1SSingle1V F1_;
            private SingleVec matX1 = new SingleVec();
            private SingleVec matY1 = new SingleVec();
            private SingleVec matX_ = new SingleVec();
            private SingleVec matNorm_ = new SingleVec();
            private SingleVec X_ = new SingleVec();
            private SingleVec FX_ = new SingleVec();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                IntPtr tempxPtr = matX1.mpPtr;
                matX1.mpPtr = xPtr;
                IntPtr tempyPtr = matY1.mpPtr;
                matY1.mpPtr = fxPtr;
                matY1[0] = F1_(matX1);
                matX1.mpPtr = tempxPtr;
                matY1.mpPtr = tempyPtr;
            }
            internal SOptSolver1(int what, cb1SSingle1V F1, SingleVec X)
            {
                what_ = what;
                matX_ = new SingleVec(X.Size);
                X_ = X; // Shallow copy
                F1_ = F1;
            }
            internal SingleVec Solve()
            {
                Lib_Eigen_SReal_Real_CppOptLib1(what_, funcptr1, matX_.mpPtr, matNorm_.mpPtr, X_.mpPtr, FX_.mpPtr);
                return matX_;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Real_CppOptLib1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Real_CppOptLib1(int what, cbProc2Ptr F1, IntPtr matXPtr, IntPtr matNormPtr, IntPtr xPtr, IntPtr fxPtr);


        public static SingleVec LbfgsSolver(cb1SSingle1V F1, cbSingle2V F2, SingleVec matInput)
        {
            var SSolver21 = new SOptSolver2(constants.mp_lbfgs_solver, F1, F2, matInput);
            return SSolver21.Solve();
        }

        public static SingleVec BfgsSolver(cb1SSingle1V F1, cbSingle2V F2, SingleVec matInput)
        {
            var SSolver21 = new SOptSolver2(constants.mp_bfgs_solver, F1, F2, matInput);
            return SSolver21.Solve();
        }

        public static SingleVec GradientDescentSolver(cb1SSingle1V F1, cbSingle2V F2, SingleVec matInput)
        {
            var SSolver21 = new SOptSolver2(constants.mp_gradient_descent_solver, F1, F2, matInput);
            return SSolver21.Solve();
        }

        public static SingleVec ConjugatedGradientDescentSolver(cb1SSingle1V F1, cbSingle2V F2, SingleVec matInput)
        {
            var SSolver21 = new SOptSolver2(constants.mp_conjugated_gradient_descent_solver, F1, F2, matInput);
            return SSolver21.Solve();
        }

        internal class SOptSolver2
        {
            private int what_;
            private cb1SSingle1V F1_;
            private cbSingle2V F2_;
            private SingleVec matX1 = new SingleVec();
            private SingleVec matY1 = new SingleVec();
            private SingleVec matX2 = new SingleVec();
            private SingleVec matY2 = new SingleVec();
            private SingleVec matX_ = new SingleVec();
            private SingleVec matGrad_ = new SingleVec();
            private SingleVec matNorm_ = new SingleVec();
            private SingleVec X_ = new SingleVec();
            private SingleVec FX_ = new SingleVec();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                IntPtr tempxPtr = matX1.mpPtr;
                matX1.mpPtr = xPtr;
                IntPtr tempyPtr = matY1.mpPtr;
                matY1.mpPtr = fxPtr;
                matY1[0] = F1_(matX1);
                matX1.mpPtr = tempxPtr;
                matY1.mpPtr = tempyPtr;
            }
            public void funcptr2(IntPtr xPtr, IntPtr fxPtr)
            {
                IntPtr tempxPtr = matX2.mpPtr;
                matX2.mpPtr = xPtr;
                IntPtr tempyPtr = matY2.mpPtr;
                matY2.mpPtr = fxPtr;
                F2_(matX2, matY2);
                matX2.mpPtr = tempxPtr;
                matY2.mpPtr = tempyPtr;
            }
            internal SOptSolver2(int what, cb1SSingle1V F1, cbSingle2V F2, SingleVec X)
            {
                what_ = what;
                matX_ = new SingleVec(X.Size);
                matGrad_ = new SingleVec(X.Size);
                X_ = X; // Shallow copy
                F1_ = F1;
                F2_ = F2;
            }
            internal SingleVec Solve()
            {
                Lib_Eigen_SReal_Real_CppOptLib2(what_, funcptr1, funcptr2, matX_.mpPtr, matGrad_.mpPtr, matNorm_.mpPtr, X_.mpPtr, FX_.mpPtr);
                return matX_;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Real_CppOptLib2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Real_CppOptLib2(int what, cbProc2Ptr F1, cbProc2Ptr F2, IntPtr matXPtr, IntPtr matGradPtr, IntPtr matNormPtr, IntPtr xPtr, IntPtr fxPtr);



        public static SingleVec NewtonDescentSolver(cb1SSingle1V F1, cbSingle2V F2, cbSingle1V1M F3, SingleVec matInput)
        {
            var SSolver31 = new SOptSolver3(constants.mp_newton_descent_solver, F1, F2, F3, matInput);
            return SSolver31.Solve();
        }

        internal class SOptSolver3
        {
            private int what_;
            private cb1SSingle1V F1_;
            private cbSingle2V F2_;
            private cbSingle1V1M F3_;
            private SingleVec matX1 = new SingleVec();
            private SingleVec matY1 = new SingleVec();
            private SingleVec matX2 = new SingleVec();
            private SingleVec matY2 = new SingleVec();
            private SingleVec matX3 = new SingleVec();
            private SingleMat matY3 = new SingleMat();
            private SingleVec matX_ = new SingleVec();
            private SingleVec matGrad_ = new SingleVec();
            private SingleVec matNorm_ = new SingleVec();
            private SingleMat matHessian_ = new SingleMat();
            private SingleVec X_ = new SingleVec();
            private SingleVec FX_ = new SingleVec();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                IntPtr tempxPtr = matX1.mpPtr;
                matX1.mpPtr = xPtr;
                IntPtr tempyPtr = matY1.mpPtr;
                matY1.mpPtr = fxPtr;
                matY1[0] = F1_(matX1);
                matX1.mpPtr = tempxPtr;
                matY1.mpPtr = tempyPtr;
            }
            public void funcptr2(IntPtr xPtr, IntPtr fxPtr)
            {
                IntPtr tempxPtr = matX2.mpPtr;
                matX2.mpPtr = xPtr;
                IntPtr tempyPtr = matY2.mpPtr;
                matY2.mpPtr = fxPtr;
                F2_(matX2, matY2);
                matX2.mpPtr = tempxPtr;
                matY2.mpPtr = tempyPtr;
            }
            public void funcptr3(IntPtr xPtr, IntPtr fxPtr)
            {
                IntPtr tempxPtr = matX3.mpPtr;
                matX3.mpPtr = xPtr;
                IntPtr tempyPtr = matY3.mpPtr;
                matY3.mpPtr = fxPtr;
                F3_(matX3, matY3);
                matX3.mpPtr = tempxPtr;
                matY3.mpPtr = tempyPtr;
            }
            internal SOptSolver3(int what, cb1SSingle1V F1, cbSingle2V F2, cbSingle1V1M F3, SingleVec X)
            {
                what_ = what;
                matX_ = new SingleVec(X.Size);
                matGrad_ = new SingleVec(X.Size);
                matHessian_.Resize(X.Size, X.Size);
                X_ = X; // Shallow copy
                F1_ = F1;
                F2_ = F2;
                F3_ = F3;
            }
            internal SingleVec Solve()
            {
                Lib_Eigen_SReal_Real_CppOptLib3(what_, funcptr1, funcptr2, funcptr3, matX_.mpPtr, matHessian_.mpPtr, matGrad_.mpPtr, matNorm_.mpPtr, X_.mpPtr, FX_.mpPtr);
                return matX_;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_Real_CppOptLib3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_Real_CppOptLib3(int what, cbProc2Ptr F1, cbProc2Ptr F2, cbProc2Ptr F3, IntPtr matXPtr, IntPtr matHessianPtr, IntPtr matGradPtr, IntPtr matNormPtr, IntPtr xPtr, IntPtr fxPtr);



        #endregion







        #region Matrix Creation


        /// <summary>
        /// Converts from a real scalar of type Single
        /// </summary>
        public static SingleMat mat_t(Single x)
        {
            var matA = new SingleMat();
            matA[0, 0] = x;
            return matA;
        }


        /* *********************** */

        public static SingleMatC mat_cplx_t(SingleMat matA)
        {
            return scplx.mat_t(matA);
        }


        public static SingleMatC mat_cplx_zeros(int n, int m)
        {
            return scplx.mat_zeros(n, m);
        }

        /* *********************** */


        public static SingleMat mat_zeros(int n, int m)
        {
            var resout = new SingleMat();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setZero, n, m);
            return resout;
        }



        public static SingleMat mat_ones(int n, int m)
        {
            var resout = new SingleMat();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setOnes, n, m);
            return resout;
        }



        public static SingleMat mat_identity(int n, int m)
        {
            var resout = new SingleMat();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setIdentity, n, m);
            return resout;
        }



        public static SingleMat mat_eye(int n, int m)
        {
            var resout = new SingleMat();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setIdentity, n, m);
            return resout;
        }



        public static SingleMat mat_random(int n, int m)
        {
            var resout = new SingleMat();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandom_nm, n, m);
            return resout;
        }



        public static SingleMat mat_random_symmetric(int n)
        {
            var resout = new SingleMat();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandomSymmetric, n, n);
            return resout;
        }



        public static SingleMat mat_random_selfadjoint(int n)
        {
            var resout = new SingleMat();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandomSA, n, n);
            return resout;
        }



        public static SingleMat mat_random_selfadjoint_posdef(int n)
        {
            var resout = new SingleMat();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandomSAPosDef, n, n);
            return resout;
        }



        public static SingleMat mat_fill_linear(int n, int m)
        {
            var resout = new SingleMat();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_FillLinear, n, m);
            return resout;
        }



        #endregion











    }









}





