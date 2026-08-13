using System;
using System.Numerics;
using System.Runtime.InteropServices;


namespace FixedPrecNet
{


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate Complex cb1SComplex1S(Complex x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate Complex cb2SComplex1S(Complex a, Complex b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate Complex cb3SComplex1S(Complex a, Complex b, Complex c);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate Complex cb4SComplex1S(Complex a, Complex b, Complex c, Complex d);



    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate Double cb1SDouble1S(Double x);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate Double cb2SDouble1S(Double a, Double b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate Double cb3SDouble1S(Double a, Double b, Double c);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate Double cb4SDouble1S(Double a, Double b, Double c, Double d);




    public delegate void cbDouble1S1V(Double t, DoubleVec matX);

    public delegate void cbDouble1S2V(Double t, DoubleVec matX, DoubleVec matY);

    public delegate void cbDouble1V(DoubleVec matX);



    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void cb2RefDouble(ref Double x, ref Double result);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void cb2Ptr1RefDouble(IntPtr x, IntPtr result, ref Double t);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void cb1Ptr1RefDouble(IntPtr x, ref Double t);


    public delegate void cbDouble2M(DoubleMat matX, DoubleMat matY);


    public delegate Double cb1SDouble1V(DoubleVec x);

    public delegate void cbDouble2V(DoubleVec x, DoubleVec y);

    public delegate void cbDouble1V1M(DoubleVec x, DoubleMat y);





    public class DoubleVec
    {

        public IntPtr mpPtr = IntPtr.Zero;

        public DoubleVec()
        {
            xcn.Init();
            mpPtr = Lib_Eigen_FReal_Init_Func(constants.mp_eigen, constants.mp_real);
        }

        public DoubleVec(int N)
        {
            xcn.Init();
            mpPtr = Lib_Eigen_FReal_Init_Func(constants.mp_eigen, constants.mp_real);
            Lib_Eigen_FReal_SetSpecialValue(constants.mp_eigen, constants.mp_real, mpPtr, constants.mp_Resize, N, 1);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_Eigen_FReal_Init_Func(int mpCat, int mpType);
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_SetSpecialValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_SetSpecialValue(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int m, int n);


        ~DoubleVec()
        {
            Lib_Eigen_FReal_Clear(constants.mp_eigen, constants.mp_real, mpPtr);
        }

        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Clear(int mpCat, int mpType, IntPtr AnyPtr);


        public int Size
        {
            get
            {
                return Lib_Eigen_FReal_GetInfo(constants.mp_eigen, constants.mp_real, constants.mp_const_size, mpPtr);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_GetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_Eigen_FReal_GetInfo(int mpCat, int mpType, int what, IntPtr MatrixPtr_source);


        public Double this[int row_i]
        {
            get
            {
                var result = new Double();
                Eigen_FReal_GetCoeff(ref result, row_i, 0, mpPtr);
                return result;
            }

            set
            {
                Eigen_FReal_SetCoeff(mpPtr, ref value, row_i, 0);
            }

        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_GetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_FReal_GetCoeff(ref Double result, int row, int col, IntPtr MatrixPtr_source);

        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_SetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_FReal_SetCoeff(IntPtr MatrixPtr_result, ref Double in1, int row, int col);


    }









    /// <summary>
    /// Provides numerical functions in Double precision, based on Boost Math/Multiprecision
    /// </summary>
    public class dreal
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



        #region VecParams


        public static DoubleVec VecParams(params dynamic[] args)
        {
            int N = args.Length;
            var matX3 = new DoubleVec(N);
            for (int i = 0; i < N; i++)
                matX3[i] = t(args[i]);


            return matX3;
        }


        #endregion




        #region General

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/name/*' />
        public static String name
        {
            get { return "dreal"; }
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
        public static dreal realctx
        {
            get { return new dreal(); }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static dcplx cplxctx
        {
            get { return new dcplx(); }
        }





        #endregion




        #region Conversion

        // Note: the conversion from dynamic needs to be at the top of this list

        /// <summary>
        /// Returns a new Octuple using a dynamic (an object whose operations will be resolved at runtime) as input
        /// </summary>
        public static Double t(dynamic x)
        {
            //MessageBox.Show("In Double t(dynamic i)");
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
        /// Returns a Double using a Octuple as input
        /// </summary>
        public static Double t(Octuple x)
        {
            Double res = 0.0;
            Lib_OReal_Get_D(ref res, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Get_D", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Get_D(ref Double res, IntPtr q);


        /// <summary>
        /// Returns a Double using a Quadruple as input
        /// </summary>
        public static Double t(Quadruple x)
        {
            Double res = 0.0;
            Lib_FReal_Set_QReal(ref res, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Set_QReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Set_QReal(ref Double res, IntPtr x);




        /// <summary>
        /// Returns a Double using a Extended as input
        /// </summary>
        public static Double t(Extended x)
        {
            Double res = 0.0;
            Lib_FReal_Set_LD(ref res, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Set_LD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Set_LD(ref Double res, IntPtr x);




        /// <summary>
        /// Returns a new Double using a Double (System.Double) as input
        /// </summary>
        public static Double t(Double x)
        {
            return +x;
        }



        /// <summary>
        /// Returns a new Double using a Single (System.Single) as input
        /// </summary>
        public static Double t(Single x)
        {
            return +x;
        }




        /// <summary>
        /// Returns a Double using a signed 32 bit integer as input
        /// </summary>
        public static Double t(Int32 si)
        {
            return (double)si;
        }



        /// <summary>
        /// Returns a Double using an unsigned 32 bit integer as input
        /// </summary>
        public static Double t(UInt32 ui)
        {
            return (double)ui;
        }



        /// <summary>
        /// Returns a Double using a signed 64 bit integer as input
        /// </summary>
        public static Double t(Int64 si64)
        {
            return (double)si64;
        }


        /// <summary>
        /// Returns a Double using an unsigned 64 bit integer as input
        /// </summary>
        public static Double t(UInt64 ui64)
        {
            return (double)ui64;
        }


        /// <summary>
        /// Returns a Double using an arbitrary precision integer as input
        /// </summary>
        public static Double t(BigInteger i)
        {
            return (double)i;
        }


        /// <summary>
        /// Returns a Double using a System.Decimal as input
        /// </summary>
        public static Double t(decimal dec)
        {
            return (double)dec;
        }



        /// <summary>
        /// Returns a Double using a string (System.String) as input
        /// </summary>
        public static Double t(string s)
        {
            Double res = 0.0;
            Lib_FReal_Set_Str(ref res, s);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Set_Str", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Set_Str(ref Double res, string s);




        #endregion





        #region Basic Arithmetic


        public static Double add(Double x, Double y)
        {
            return x + y;
        }
        public static Double add(dynamic x, dynamic y)
        {
            return t(x) + t(y);
        }

        public static void rawadd(ref Double res, Double x, Double y)
        {
            res = x + y;
        }



        public static Double subtract(Double x, Double y)
        {
            return x - y;
        }
        public static Double subtract(dynamic x, dynamic y)
        {
            return t(x) - t(y);
        }

        public static void rawsub(ref Double res, Double x, Double y)
        {
            res = x - y;
        }



        public static Double multiply(Double x, Double y)
        {
            return x * y;
        }
        public static Double multiply(dynamic x, dynamic y)
        {
            return t(x) * t(y);
        }

        public static void rawmul(ref Double res, Double x, Double y)
        {
            res = x * y;
        }



        public static Double divide(Double x, Double y)
        {
            return x / y;
        }
        public static Double divide(dynamic x, dynamic y)
        {
            return t(x) / t(y);
        }

        public static void rawdiv(ref Double res, Double x, Double y)
        {
            res = x / y;
        }


        #endregion





        #region Basic floating point functions




        #region General functions for real numbers


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




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmax/*' />
        public static Double fmax(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Fmax(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Fmax", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Fmax(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmax/*' />
        public static Double fmax(dynamic x, dynamic y)
        {
            return fmax(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmin/*' />
        public static Double fmin(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Fmin(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Fmin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Fmin(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmin/*' />
        public static Double fmin(dynamic x, dynamic y)
        {
            return fmin(t(x), t(y));
        }


        #endregion




        #region Machine constants


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/zero/*' />
        public static Double zero()
        {
            return 0.0;
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/negzero/*' />
        public static Double negzero()
        {
            return -0.0;
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/one/*' />
        public static Double one()
        {
            return 1.0;
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/onej/*' />
        public static Complex onej()
        {
            return dcplx.t(0d, 1d);
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isposinf/*' />
        public static Double inf()
        {
            return Double.PositiveInfinity;
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/neginf/*' />
        public static Double neginf()
        {
            return -Double.PositiveInfinity;
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/nan/*' />
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
            return ldexp(t(x), lround(t(e)));
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
            return scalbn(t(x), lround(t(e)));
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
            return scalbln(t(x), lround(t(e)));
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



        #region Roots and quadratic, cubic, and quartic 


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static Double sqrt(Double x)
        {
            return Math.Sqrt(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static Double sqrt(dynamic x)
        {
            return sqrt(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sqrt1pm1/*' />
        public static Double sqrt1pm1(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Sqrt1pm1_Boost(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Sqrt1pm1_Boost", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Sqrt1pm1_Boost(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sqrt1pm1/*' />
        public static Double sqrt1pm1(dynamic x)
        {
            return sqrt1pm1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Double rsqrt(Double x)
        {
            return t(1) / sqrt(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Double rsqrt(dynamic x)
        {
            return rsqrt(t(x)); ;
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static Double cbrt(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Cbrt(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Cbrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Cbrt(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static Double cbrt(dynamic x)
        {
            return cbrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static Double root_si(Double x, int k)
        {
            var res = new Double();
            Lib_FReal_Root_Si(ref res, ref x, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Root_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Root_Si(ref Double res, ref Double x, int k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static Double root_si(dynamic x, int k)
        {
            return root_si(t(x), k);
        }




        #endregion



        #region Exponential and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static Double exp(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Exp(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Exp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Exp(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static Double exp(dynamic x)
        {
            return exp(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static Complex expj(Double x)
        {
            return cos(x) + onej() * sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static Complex expj(dynamic x)
        {
            return expj(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static Complex expjpi(Double x)
        {
            return cospi(x) + onej() * sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static Complex expjpi(dynamic x)
        {
            return expjpi(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Double exp2(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Exp2(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Exp2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Exp2(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Double exp2(dynamic x)
        {
            return exp2(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static Double exp10(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Exp10(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Exp10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Exp10(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static Double exp10(dynamic x)
        {
            return exp10(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Double expm1(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Expm1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Expm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Expm1(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Double expm1(dynamic x)
        {
            return expm1(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Double exp2m1(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Exp2m1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Exp2m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Exp2m1(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Double exp2m1(dynamic x)
        {
            return exp2m1(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static Double exp10m1(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Exp10m1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Exp10m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Exp10m1(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static Double exp10m1(dynamic x)
        {
            return exp10m1(t(x));
        }




        #endregion



        #region Logarithms and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static Double log(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Log(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Log", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Log(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static Double log(dynamic x)
        {
            return log(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Double log2(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Log2(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Log2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Log2(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Double log2(dynamic x)
        {
            return log2(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Double log10(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Log10(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Log10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Log10(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Double log10(dynamic x)
        {
            return log10(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Double log1p(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Log1p(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Log1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Log1p(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Double log1p(dynamic x)
        {
            return log1p(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static Double log2p1(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Log2p1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Log2p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Log2p1(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static Double log2p1(dynamic x)
        {
            return log2p1(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static Double log10p1(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Log10p1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Log10p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Log10p1(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static Double log10p1(dynamic x)
        {
            return log10p1(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logaddexp/*' />
        public static Double logaddexp(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Logaddexp(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Logaddexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Logaddexp(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logaddexp/*' />
        public static Double logaddexp(dynamic x, dynamic y)
        {
            return logaddexp(t(x), t(y));
        }




        #endregion



        #region Power functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static Double sqr(Double x)
        {
            return x * x;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static Double sqr(dynamic x)
        {
            return sqr(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static Double cube(Double x)
        {
            return x * x * x;
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static Double cube(dynamic x)
        {
            return cube(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static Double hypot(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Hypot(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Hypot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Hypot(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static Double hypot(dynamic x, dynamic y)
        {
            return hypot(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static Double pow(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Pow(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Pow", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Pow(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static Double pow(dynamic x, dynamic y)
        {
            return pow(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/powm1/*' />
        public static Double powm1(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Powm1(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Powm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Powm1(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/powm1/*' />
        public static Double powm1(dynamic x, dynamic y)
        {
            return powm1(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1p/*' />
        public static Double pow1p(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Pow1p(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Pow1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Pow1p(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1p/*' />
        public static Double pow1p(dynamic x, dynamic y)
        {
            return pow1p(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1pm1/*' />
        public static Double pow1pm1(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Pow1pm1(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Pow1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Pow1pm1(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1pm1/*' />
        public static Double pow1pm1(dynamic x, dynamic y)
        {
            return pow1pm1(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow_si/*' />
        public static Double pow_si(Double x, int n)
        {
            Double res = 0.0;
            Lib_FReal_Pow_Si(ref res, ref x, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Pow_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Pow_Si(ref Double res, ref Double x, int n);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow_si/*' />
        public static Double pow_si(dynamic x, int n)
        {
            return pow_si(t(x), n);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/compound_si/*' />
        public static Double compound_si(Double x, int n)
        {
            Double res = 0.0;
            Lib_FReal_Compound_Si(ref res, ref x, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Compound_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Compound_Si(ref Double res, ref Double x, int n);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/compound_si/*' />
        public static Double compound_si(dynamic x, int n)
        {
            return compound_si(t(x), n);
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Double sin(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Sin(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Sin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Sin(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Double sin(dynamic x)
        {
            return sin(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static Double cos(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Cos(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Cos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Cos(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static Double cos(dynamic x)
        {
            return cos(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosm1/*' />
        public static Double cosm1(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Cosm1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Cosm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Cosm1(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosm1/*' />
        public static Double cosm1(dynamic x)
        {
            return cosm1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static Double tan(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Tan(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Tan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Tan(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static Double tan(dynamic x)
        {
            return tan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static Double csc(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Csc(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Csc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Csc(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static Double csc(dynamic x)
        {
            return csc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static Double sec(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Sec(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Sec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Sec(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static Double sec(dynamic x)
        {
            return sec(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static Double cot(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Cot(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Cot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Cot(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static Double cot(dynamic x)
        {
            return cot(t(x));
        }






        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinpi/*' />
        public static Double sinpi(Double x)
        {
            Double res = 0.0;
            Lib_FReal_SinPi_Boost(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_SinPi_Boost", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_SinPi_Boost(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinpi/*' />
        public static Double sinpi(dynamic x)
        {
            return sinpi(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static Double cospi(Double x)
        {
            Double res = 0.0;
            Lib_FReal_CosPi_Boost(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_CosPi_Boost", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_CosPi_Boost(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static Double cospi(dynamic x)
        {
            return cospi(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static Double tanpi(Double x)
        {
            Double res = 0.0;
            Lib_FReal_TanPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_TanPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_TanPi(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static Double tanpi(dynamic x)
        {
            return tanpi(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static Double cscpi(Double x)
        {
            Double res = 0.0;
            Lib_FReal_CscPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_CscPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_CscPi(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static Double cscpi(dynamic x)
        {
            return cscpi(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static Double secpi(Double x)
        {
            Double res = 0.0;
            Lib_FReal_SecPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_SecPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_SecPi(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static Double secpi(dynamic x)
        {
            return secpi(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cotpi/*' />
        public static Double cotpi(Double x)
        {
            Double res = 0.0;
            Lib_FReal_CotPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_CotPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_CotPi(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cotpi/*' />
        public static Double cotpi(dynamic x)
        {
            return cotpi(t(x));
        }








        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinc/*' />
        public static Double sinc(Double x)
        {
            Double res = 0.0;
            Lib_FReal_SincPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_SincPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_SincPi(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinc/*' />
        public static Double sinc(dynamic x)
        {
            return sinc(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static Double sincpi(Double x)
        {
            Double x1 = x * dreal.pi();

            if (dreal.abs(x) < 0.1)
            {
                return sinc(x1);
            }
            else return sinpi(x) / x1;
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinc/*' />
        public static Double sincpi(dynamic x)
        {
            return sincpi(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinhcpi/*' />
        public static Double sinhcpi(Double x)
        {
            Double res = 0.0;
            Lib_FReal_SinhcPi(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_SinhcPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_SinhcPi(ref Double res, ref Double x);




        #endregion



        #region Hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static Double sinh(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Sinh(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Sinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Sinh(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static Double sinh(dynamic x)
        {
            return sinh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static Double cosh(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Cosh(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Cosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Cosh(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static Double cosh(dynamic x)
        {
            return cosh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static Double tanh(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Tanh(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Tanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Tanh(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static Double tanh(dynamic x)
        {
            return tanh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static Double csch(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Csch(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Csch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Csch(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static Double csch(dynamic x)
        {
            return csch(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static Double sech(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Sech(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Sech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Sech(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static Double sech(dynamic x)
        {
            return sech(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static Double coth(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Coth(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Coth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Coth(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static Double coth(dynamic x)
        {
            return coth(t(x));
        }





        #endregion



        #region Inverse trigonometric functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static Double asin(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Asin(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Asin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Asin(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static Double asin(dynamic x)
        {
            return asin(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static Double acos(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Acos(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Acos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Acos(ref Double res, ref Double x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static Double acos(dynamic x)
        {
            return acos(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static Double atan(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Atan(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Atan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Atan(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static Double atan(dynamic x)
        {
            return atan(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan2/*' />
        public static Double atan2(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Atan2(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Atan2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Atan2(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan2/*' />
        public static Double atan2(dynamic x, dynamic y)
        {
            return atan2(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static Double acsc(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Acsc(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Acsc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Acsc(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static Double acsc(dynamic x)
        {
            return acsc(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static Double asec(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Asec(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Asec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Asec(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static Double asec(dynamic x)
        {
            return asec(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static Double acot(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Acot(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Acot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Acot(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static Double acot(dynamic x)
        {
            return acot(t(x));
        }



        #endregion



        #region Inverse hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static Double asinh(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Asinh(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Asinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Asinh(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static Double asinh(dynamic x)
        {
            return asinh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static Double acosh(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Acosh(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Acosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Acosh(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static Double acosh(dynamic x)
        {
            return acosh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static Double atanh(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Atanh(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Atanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Atanh(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static Double atanh(dynamic x)
        {
            return atanh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static Double acsch(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Acsch(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Acsch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Acsch(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static Double acsch(dynamic x)
        {
            return acsch(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static Double asech(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Asech(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Asech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Asech(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static Double asech(dynamic x)
        {
            return asech(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static Double acoth(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Acoth(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Acoth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Acoth(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static Double acoth(dynamic x)
        {
            return acoth(t(x));
        }





        #endregion




        #region Miscellaneous





        /// <summary>
        /// Returns lambert_w0(Double x)
        /// </summary>
        public static Double lambert_w0(Double x)
        {
            Double res = 0.0;
            Lib_FReal_LambertW0(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LambertW0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_LambertW0(ref Double res, ref Double x);


        /// <summary>
        /// Returns lambert_wm1(Double x)
        /// </summary>
        public static Double lambert_wm1(Double x)
        {
            Double res = 0.0;
            Lib_FReal_LambertWm1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LambertWm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_LambertWm1(ref Double res, ref Double x);


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




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/agm/*' />
        public static Double agm(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Agm(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Agm", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Agm(ref Double res, ref Double x, ref Double y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/agm/*' />
        public static Double agm(dynamic x, dynamic y)
        {
            return agm(t(x), t(y));
        }



        #endregion




        #endregion





        #region Real Erf, Gamma, Beta




        #region Error functions for real arguments

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndens/*' />
        public static Double ndens(Double x)
        {
            return exp(-0.5*x * x) / sqrt(2 * pi());
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndens/*' />
        public static Double ndens(dynamic x)
        {
            return ndens(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndis/*' />
        public static Double ndis(Double x)
        {
            return 0.5 * erfc(-x / sqrt(2));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndis/*' />
        public static Double ndis(dynamic x)
        {
            return ndis(t(x));
        }


        /// <summary>
        /// Returns erf(Double x)
        /// </summary>
        public static Double erf(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Erf_(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Erf_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Erf_(ref Double res, ref Double x);


        /// <summary>
        /// Returns erfc(Double x)
        /// </summary>
        public static Double erfc(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Erfc_(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Erfc_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Erfc_(ref Double res, ref Double x);


        /// <summary>
        /// Returns erf_inv(Double x)
        /// </summary>
        public static Double erf_inv(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Erf_inv(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Erf_inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Erf_inv(ref Double res, ref Double x);


        /// <summary>
        /// Returns erfc_inv(Double x)
        /// </summary>
        public static Double erfc_inv(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Erfc_inv(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Erfc_inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Erfc_inv(ref Double res, ref Double x);




        #endregion



        #region Gamma and related functions for real arguments and parameters


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lgamma/*' />
        //public static Double lgamma(Double x)
        //{
        //    Double res = 0.0;
        //    Lib_FReal_Lgamma(ref res, ref x);
        //    return res;
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Lgamma", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void Lib_FReal_Lgamma(ref Double res, ref Double x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lgamma/*' />
        //public static Double lgamma(dynamic x)
        //{
        //    return lgamma(t(x));
        //}


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rgamma/*' />
        public static Double rgamma(Double x)
        {
            return t(1) / gamma(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rgamma/*' />
        public static Double rgamma(dynamic x)
        {
            return rgamma(t(x));
        }





        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        //public static Double gamma(Double x)
        //{
        //    Double res = 0.0;
        //    Lib_FReal_Tgamma(ref res, ref x);
        //    return res;
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Tgamma", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void Lib_FReal_Tgamma(ref Double res, ref Double x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        //public static Double gamma(dynamic x)
        //{
        //    return gamma(t(x));
        //}



        /// <summary>
        /// Returns gamma(Double x)
        /// </summary>
        public static Double gamma(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Tgamma_(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Tgamma_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Tgamma_(ref Double res, ref Double x);


        /// <summary>
        /// Returns gamma1pm1(Double x)
        /// </summary>
        public static Double gamma1pm1(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Tgamma1pm1(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Tgamma1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Tgamma1pm1(ref Double res, ref Double x);


        /// <summary>
        /// Returns lgamma(Double x)
        /// </summary>
        public static Double lgamma(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Lgamma_(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Lgamma_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Lgamma_(ref Double res, ref Double x);



        /// <summary>
        /// Returns factorial(Double x)
        /// </summary>
        public static Double factorial(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Factorial(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Factorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Factorial(ref Double res, ref Double x);


        /// <summary>
        /// Returns doublefactorial(Double x)
        /// </summary>
        public static Double doublefactorial(Double x)
        {
            Double res = 0.0;
            Lib_FReal_DoubleFactorial(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_DoubleFactorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_DoubleFactorial(ref Double res, ref Double x);



        /// <summary>
        /// Returns gamma_ratio(Double x, Double y)
        /// </summary>
        public static Double gamma_ratio(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_TgammaRatio(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_TgammaRatio", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_TgammaRatio(ref Double res, ref Double x, ref Double y);


        /// <summary>
        /// Returns gamma_delta_ratio(Double x, Double y)
        /// </summary>
        public static Double gamma_delta_ratio(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_TgammaDeltaRatio(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_TgammaDeltaRatio", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_TgammaDeltaRatio(ref Double res, ref Double x, ref Double y);


        /// <summary>
        /// Returns binomial(Double x, Double y)
        /// </summary>
        public static Double binomial(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_Binomial(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Binomial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Binomial(ref Double res, ref Double x, ref Double y);


        /// <summary>
        /// Returns rising_factorial(Double x, Double y)
        /// </summary>
        public static Double rising_factorial(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_RisingFactorial(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_RisingFactorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_RisingFactorial(ref Double res, ref Double x, ref Double y);


        /// <summary>
        /// Returns falling_factorial(Double x, Double y)
        /// </summary>
        public static Double falling_factorial(Double x, Double y)
        {
            Double res = 0.0;
            Lib_FReal_FallingFactorial(ref res, ref x, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_FallingFactorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_FallingFactorial(ref Double res, ref Double x, ref Double y);



        /// <summary>
        /// Returns beta(Double a, Double x)
        /// </summary>
        public static Double beta(Double a, Double x)
        {
            Double res = 0.0;
            Lib_FReal_Beta(ref res, ref a, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Beta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Beta(ref Double res, ref Double a, ref Double x);





        #endregion



        #region Incomplete gamma functions for real arguments and parameters


        /// <summary>
        /// Returns gamma_p(Double a, Double x)
        /// </summary>
        public static Double gamma_p(Double a, Double x)
        {
            Double res = 0.0;
            Lib_FReal_GammaP(ref res, ref a, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_GammaP", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_GammaP(ref Double res, ref Double a, ref Double x);



        /// <summary>
        /// Returns gamma_q(Double a, Double x)
        /// </summary>
        public static Double gamma_q(Double a, Double x)
        {
            Double res = 0.0;
            Lib_FReal_GammaQ(ref res, ref a, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_GammaQ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_GammaQ(ref Double res, ref Double a, ref Double x);



        /// <summary>
        /// Returns gamma_lower(Double a, Double x)
        /// </summary>
        public static Double gamma_lower(Double a, Double x)
        {
            Double res = 0.0;
            Lib_FReal_TgammaLower(ref res, ref a, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_TgammaLower", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_TgammaLower(ref Double res, ref Double a, ref Double x);



        /// <summary>
        /// Returns gamma_upper(Double a, Double x)
        /// </summary>
        public static Double gamma_upper(Double a, Double x)
        {
            Double res = 0.0;
            Lib_FReal_TgammaUpper(ref res, ref a, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_TgammaUpper", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_TgammaUpper(ref Double res, ref Double a, ref Double x);






        /// <summary>
        /// Returns gamma_p_inv(Double a, Double p)
        /// </summary>
        public static Double gamma_p_inv(Double a, Double p)
        {
            Double res = 0.0;
            Lib_FReal_GammaPInv(ref res, ref a, ref p);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_GammaPInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_GammaPInv(ref Double res, ref Double a, ref Double p);



        /// <summary>
        /// Returns gamma_q_inv(Double a, Double q)
        /// </summary>
        public static Double gamma_q_inv(Double a, Double q)
        {
            Double res = 0.0;
            Lib_FReal_GammaQInv(ref res, ref a, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_GammaQInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_GammaQInv(ref Double res, ref Double a, ref Double q);




        /// <summary>
        /// Returns gamma_p_inva(Double x, Double p)
        /// </summary>
        public static Double gamma_p_inva(Double x, Double p)
        {
            Double res = 0.0;
            Lib_FReal_GammaPInva(ref res, ref x, ref p);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_GammaPInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_GammaPInva(ref Double res, ref Double x, ref Double p);



        /// <summary>
        /// Returns gamma_q_inva(Double x, Double q)
        /// </summary>
        public static Double gamma_q_inva(Double x, Double q)
        {
            Double res = 0.0;
            Lib_FReal_GammaQInva(ref res, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_GammaQInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_GammaQInva(ref Double res, ref Double x, ref Double q);





        /// <summary>
        /// Returns gamma_p_prime(Double a, Double x)
        /// </summary>
        public static Double gamma_p_prime(Double a, Double x)
        {
            Double res = 0.0;
            Lib_FReal_GammaPDerivative(ref res, ref a, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_GammaPDerivative", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_GammaPDerivative(ref Double res, ref Double a, ref Double x);




        #endregion



        #region Incomplete beta functions for real arguments and parameters





        /// <summary>
        /// Returns beta_lower(Double a, Double b, Double x)
        /// </summary>
        public static Double beta_lower(Double a, Double b, Double x)
        {
            Double res = 0.0;
            Lib_FReal_IBetaNonNormalized(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_IBetaNonNormalized", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_IBetaNonNormalized(ref Double res, ref Double a, ref Double b, ref Double x);




        /// <summary>
        /// Returns beta_upper(Double a, Double b, Double x)
        /// </summary>
        public static Double beta_upper(Double a, Double b, Double x)
        {
            Double res = 0.0;
            Lib_FReal_IBetacNonNormalized(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_IBetacNonNormalized", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_IBetacNonNormalized(ref Double res, ref Double a, ref Double b, ref Double x);




        /// <summary>
        /// Returns ibeta(Double a, Double b, Double x)
        /// </summary>
        public static Double ibeta(Double a, Double b, Double x)
        {
            Double res = 0.0;
            Lib_FReal_IBeta(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_IBeta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_IBeta(ref Double res, ref Double a, ref Double b, ref Double x);




        /// <summary>
        /// Returns ibetac(Double a, Double b, Double x)
        /// </summary>
        public static Double ibetac(Double a, Double b, Double x)
        {
            Double res = 0.0;
            Lib_FReal_IBetac(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_IBetac", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_IBetac(ref Double res, ref Double a, ref Double b, ref Double x);




        /// <summary>
        /// Returns ibeta_inv(Double a, Double b, Double p)
        /// </summary>
        public static Double ibeta_inv(Double a, Double b, Double p)
        {
            Double res = 0.0;
            Lib_FReal_IBetaInv(ref res, ref a, ref b, ref p);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_IBetaInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_IBetaInv(ref Double res, ref Double a, ref Double b, ref Double p);




        /// <summary>
        /// Returns ibetac_inv(Double a, Double b, Double q)
        /// </summary>
        public static Double ibetac_inv(Double a, Double b, Double q)
        {
            Double res = 0.0;
            Lib_FReal_IBetacInv(ref res, ref a, ref b, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_IBetacInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_IBetacInv(ref Double res, ref Double a, ref Double b, ref Double q);






        /// <summary>
        /// Returns ibeta_inva(Double b, Double x, Double p)
        /// </summary>
        public static Double ibeta_inva(Double b, Double x, Double p)
        {
            Double res = 0.0;
            Lib_FReal_IBetaInva(ref res, ref b, ref x, ref p);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_IBetaInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_IBetaInva(ref Double res, ref Double b, ref Double x, ref Double p);




        /// <summary>
        /// Returns ibetac_inva(Double b, Double x, Double q)
        /// </summary>
        public static Double ibetac_inva(Double b, Double x, Double q)
        {
            Double res = 0.0;
            Lib_FReal_IBetacInva(ref res, ref b, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_IBetacInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_IBetacInva(ref Double res, ref Double b, ref Double x, ref Double q);





        /// <summary>
        /// Returns ibeta_invb(Double a, Double x, Double p)
        /// </summary>
        public static Double ibeta_invb(Double a, Double x, Double p)
        {
            Double res = 0.0;
            Lib_FReal_IBetaInvb(ref res, ref a, ref x, ref p);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_IBetaInvb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_IBetaInvb(ref Double res, ref Double a, ref Double x, ref Double p);




        /// <summary>
        /// Returns ibetac_invb(Double a, Double x, Double q)
        /// </summary>
        public static Double ibetac_invb(Double a, Double x, Double q)
        {
            Double res = 0.0;
            Lib_FReal_IBetacInvb(ref res, ref a, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_IBetacInvb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_IBetacInvb(ref Double res, ref Double a, ref Double x, ref Double q);




        /// <summary>
        /// Returns ibeta_prime(Double a, Double b, Double x)
        /// </summary>
        public static Double ibeta_prime(Double a, Double b, Double x)
        {
            Double res = 0.0;
            Lib_FReal_IBetaDerivative(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_IBetaDerivative", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_IBetaDerivative(ref Double res, ref Double a, ref Double b, ref Double x);





        #endregion



        #region Miscellaneous real functions



        /// <summary>
        /// Returns owen_t(Double h, Double a)
        /// </summary>
        public static Double owen_t(Double h, Double a)
        {
            Double res = 0.0;
            Lib_FReal_OwenT(ref res, ref h, ref a);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_OwenT", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_OwenT(ref Double res, ref Double h, ref Double a);


        #endregion




        #endregion






        #region Special Functions


        #region Legendre elliptic integrals (elliptic modulus k), and related functions



        /// <summary>
        /// Returns elliptic_k(Double x)
        /// </summary>
        public static Double elliptic_k(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Ellint_1_K(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ellint_1_K", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Ellint_1_K(ref Double res, ref Double x);


        /// <summary>
        /// Returns elliptic_e(Double x)
        /// </summary>
        public static Double elliptic_e(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Ellint_2_K(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ellint_2_K", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Ellint_2_K(ref Double res, ref Double x);



        /// <summary>
        /// Returns elliptic_f(Double k, Double phi)
        /// </summary>
        public static Double elliptic_f(Double phi, Double k)
        {
            Double res = 0.0;
            Lib_FReal_Ellint1F(ref res, ref k, ref phi);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ellint1F", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Ellint1F(ref Double res, ref Double k, ref Double phi);



        /// <summary>
        /// Returns elliptic_e_inc(Double k, Double phi)
        /// </summary>
        public static Double elliptic_e_inc(Double phi, Double k)
        {
            Double res = 0.0;
            Lib_FReal_Ellint2F(ref res, ref k, ref phi);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ellint2F", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Ellint2F(ref Double res, ref Double k, ref Double phi);



        /// <summary>
        /// Returns elliptic_pi(Double k, Double n)
        /// </summary>
        public static Double elliptic_pi(Double n, Double k)
        {
            Double res = 0.0;
            Lib_FReal_Ellint3K(ref res, ref k, ref n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ellint3K", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Ellint3K(ref Double res, ref Double k, ref Double n);




        /// <summary>
        /// Returns elliptic_pi_inc(Double k, Double n, Double phi)
        /// </summary>
        public static Double elliptic_pi_inc(Double n, Double phi, Double k)
        {
            Double res = 0.0;
            Lib_FReal_Ellint3F(ref res, ref k, ref n, ref phi);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ellint3F", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Ellint3F(ref Double res, ref Double k, ref Double n, ref Double phi);





        #endregion



        #region Carlson symmetric elliptic integrals



        /// <summary>
        /// Returns elliptic_rc(Double a, Double x)
        /// </summary>
        public static Double elliptic_rc(Double a, Double x)
        {
            Double res = 0.0;
            Lib_FReal_EllintRC(ref res, ref a, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_EllintRC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_EllintRC(ref Double res, ref Double a, ref Double x);




        /// <summary>
        /// Returns elliptic_rf(Double x, Double y, Double z)
        /// </summary>
        public static Double elliptic_rf(Double x, Double y, Double z)
        {
            Double res = 0.0;
            Lib_FReal_EllipticRF(ref res, ref x, ref y, ref z);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_EllipticRF", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_EllipticRF(ref Double res, ref Double x, ref Double y, ref Double z);




        /// <summary>
        /// Returns elliptic_rd(Double x, Double y, Double z)
        /// </summary>
        public static Double elliptic_rd(Double x, Double y, Double z)
        {
            Double res = 0.0;
            Lib_FReal_EllipticRD(ref res, ref x, ref y, ref z);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_EllipticRD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_EllipticRD(ref Double res, ref Double x, ref Double y, ref Double z);




        /// <summary>
        /// Returns elliptic_rg(Double x, Double y, Double z)
        /// </summary>
        public static Double elliptic_rg(Double x, Double y, Double z)
        {
            Double res = 0.0;
            Lib_FReal_EllipticRG(ref res, ref x, ref y, ref z);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_EllipticRG", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_EllipticRG(ref Double res, ref Double x, ref Double y, ref Double z);




        /// <summary>
        /// Returns elliptic_rj(Double x, Double y, Double z, Double p)
        /// </summary>
        public static Double elliptic_rj(Double x, Double y, Double z, Double p)
        {
            Double res = 0.0;
            Lib_FReal_EllipticRJ(ref res, ref x, ref y, ref z, ref p);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_EllipticRJ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_EllipticRJ(ref Double res, ref Double x, ref Double y, ref Double z, ref Double p);




        #endregion



        #region Jacobi theta functions




        /// <summary>
        /// Returns jacobi_theta1(Double x, Double q)
        /// </summary>
        public static Double jacobi_theta1(Double x, Double q)
        {
            Double res = 0.0;
            Lib_FReal_JacobiTheta1(ref res, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiTheta1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiTheta1(ref Double res, ref Double x, ref Double q);



        /// <summary>
        /// Returns jacobi_theta2(Double x, Double q)
        /// </summary>
        public static Double jacobi_theta2(Double x, Double q)
        {
            Double res = 0.0;
            Lib_FReal_JacobiTheta2(ref res, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiTheta2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiTheta2(ref Double res, ref Double x, ref Double q);



        /// <summary>
        /// Returns jacobi_theta3(Double x, Double q)
        /// </summary>
        public static Double jacobi_theta3(Double x, Double q)
        {
            Double res = 0.0;
            Lib_FReal_JacobiTheta3(ref res, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiTheta3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiTheta3(ref Double res, ref Double x, ref Double q);



        /// <summary>
        /// Returns jacobi_theta4(Double x, Double q)
        /// </summary>
        public static Double jacobi_theta4(Double x, Double q)
        {
            Double res = 0.0;
            Lib_FReal_JacobiTheta4(ref res, ref x, ref q);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiTheta4", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiTheta4(ref Double res, ref Double x, ref Double q);




        #endregion



        #region Jacobi elliptic functions




        /// <summary>
        /// Returns jacobi_cd(Double k, Double u)
        /// </summary>
        public static Double jacobi_cd(Double u, Double k)
        {
            Double res = 0.0;
            Lib_FReal_JacobiCD(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiCD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiCD(ref Double res, ref Double k, ref Double u);




        /// <summary>
        /// Returns jacobi_cn(Double k, Double u)
        /// </summary>
        public static Double jacobi_cn(Double u, Double k)
        {
            Double res = 0.0;
            Lib_FReal_JacobiCN(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiCN", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiCN(ref Double res, ref Double k, ref Double u);




        /// <summary>
        /// Returns jacobi_cs(Double k, Double u)
        /// </summary>
        public static Double jacobi_cs(Double u, Double k)
        {
            Double res = 0.0;
            Lib_FReal_JacobiCS(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiCS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiCS(ref Double res, ref Double k, ref Double u);




        /// <summary>
        /// Returns jacobi_dc(Double k, Double u)
        /// </summary>
        public static Double jacobi_dc(Double u, Double k)
        {
            Double res = 0.0;
            Lib_FReal_JacobiDC(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiDC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiDC(ref Double res, ref Double k, ref Double u);




        /// <summary>
        /// Returns jacobi_dn(Double k, Double u)
        /// </summary>
        public static Double jacobi_dn(Double u, Double k)
        {
            Double res = 0.0;
            Lib_FReal_JacobiDN(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiDN", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiDN(ref Double res, ref Double k, ref Double u);




        /// <summary>
        /// Returns jacobi_ds(Double k, Double u)
        /// </summary>
        public static Double jacobi_ds(Double u, Double k)
        {
            Double res = 0.0;
            Lib_FReal_JacobiDS(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiDS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiDS(ref Double res, ref Double k, ref Double u);




        /// <summary>
        /// Returns jacobi_nc(Double k, Double u)
        /// </summary>
        public static Double jacobi_nc(Double u, Double k)
        {
            Double res = 0.0;
            Lib_FReal_JacobiNC(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiNC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiNC(ref Double res, ref Double k, ref Double u);




        /// <summary>
        /// Returns jacobi_nd(Double k, Double u)
        /// </summary>
        public static Double jacobi_nd(Double u, Double k)
        {
            Double res = 0.0;
            Lib_FReal_JacobiND(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiND", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiND(ref Double res, ref Double k, ref Double u);




        /// <summary>
        /// Returns jacobi_ns(Double k, Double u)
        /// </summary>
        public static Double jacobi_ns(Double u, Double k)
        {
            Double res = 0.0;
            Lib_FReal_JacobiNS(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiNS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiNS(ref Double res, ref Double k, ref Double u);




        /// <summary>
        /// Returns jacobi_sc(Double k, Double u)
        /// </summary>
        public static Double jacobi_sc(Double u, Double k)
        {
            Double res = 0.0;
            Lib_FReal_JacobiSC(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiSC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiSC(ref Double res, ref Double k, ref Double u);




        /// <summary>
        /// Returns jacobi_sd(Double k, Double u)
        /// </summary>
        public static Double jacobi_sd(Double u, Double k)
        {
            Double res = 0.0;
            Lib_FReal_JacobiSD(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiSD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiSD(ref Double res, ref Double k, ref Double u);




        /// <summary>
        /// Returns jacobi_sn(Double k, Double u)
        /// </summary>
        public static Double jacobi_sn(Double u, Double k)
        {
            Double res = 0.0;
            Lib_FReal_JacobiSN(ref res, ref k, ref u);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_JacobiSN", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_JacobiSN(ref Double res, ref Double k, ref Double u);




        #endregion



        #region Polygamma functions


        /// <summary>
        /// Returns digamma(Double x)
        /// </summary>
        public static Double digamma(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Digamma(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Digamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Digamma(ref Double res, ref Double x);


        /// <summary>
        /// Returns trigamma(Double x)
        /// </summary>
        public static Double trigamma(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Trigamma(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Trigamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Trigamma(ref Double res, ref Double x);




        /// <summary>
        /// Returns polygamma(int n, Double x)
        /// </summary>
        public static Double polygamma(int n, Double x)
        {
            Double res = 0.0;
            Lib_FReal_Polygamma(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Polygamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Polygamma(ref Double res, int n, ref Double x);




        #endregion



        #region Hurwitz zeta function and related functions



        /// <summary>
        /// Returns bernoulli(int n)
        /// </summary>
        public static Double bernoulli(int n)
        {
            if (n == 1) return -0.5;
            if (n % 2 != 0) return 0.0;
            Double res = 0.0;
            Lib_FReal_BernoulliB2n(ref res, n / 2);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BernoulliB2n", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_BernoulliB2n(ref Double res, int n);


        /// <summary>
        /// Returns TangentT2n(int n)
        /// </summary>
        public static Double TangentT2n(int n)
        {
            Double res = 0.0;
            Lib_FReal_TangentT2n(ref res, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_TangentT2n", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_TangentT2n(ref Double res, int n);




        #endregion



        #region Dirichlet L-Series, Riemann zeta function, and related functions


        /// <summary>
        /// Returns zeta(Double x)
        /// </summary>
        public static Double zeta(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Zeta(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Zeta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Zeta(ref Double res, ref Double x);


        #endregion



        #region 0F1: Overview


        /// <summary>
        /// Returns hyperg_0f1(Double b, Double x)
        /// </summary>
        public static Double hyperg_0f1(Double b, Double x)
        {
            Double res = 0.0;
            Lib_FReal_Hypergeo0F1(ref res, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Hypergeo0F1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Hypergeo0F1(ref Double res, ref Double b, ref Double x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_0f1/*' />
        public static Double hyperg_0f1(dynamic b, dynamic x)
        {
            return hyperg_0f1(dreal.t(b), dreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_0f1r/*' />
        public static Double hyperg_0f1r(Double b, Double x)
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
        public static Double hyperg_0f1r(dynamic b, dynamic x)
        {
            return hyperg_0f1r(dreal.t(b), dreal.t(x));
        }



        #endregion



        #region Bessel functions and modified Bessel functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv/*' />
        public static Double bessel_jv(Double v, Double x, bool scaled = false)
        {
            Double res = 0.0;
            Lib_FReal_BesselJ(ref res, ref v, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BesselJ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_BesselJ(ref Double res, ref Double v, ref Double x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv/*' />
        public static Double bessel_jv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_jv(t(nu), t(x), scaled);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv/*' />
        public static Double bessel_yv(Double v, Double x, bool scaled = false)
        {
            Double res = 0.0;
            Lib_FReal_BesselY(ref res, ref v, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BesselY", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_BesselY(ref Double res, ref Double v, ref Double x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv/*' />
        public static Double bessel_yv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_yv(t(nu), t(x), scaled);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv/*' />
        public static Double bessel_iv(Double v, Double x, bool scaled = false)
        {
            Double res = 0.0;
            Lib_FReal_BesselI(ref res, ref v, ref x);
            if (scaled) res *= exp(-abs(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BesselI", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_BesselI(ref Double res, ref Double v, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv/*' />
        public static Double bessel_iv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_iv(t(nu), t(x), scaled);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv/*' />
        public static Double bessel_kv(Double v, Double x, bool scaled = false)
        {
            Double res = 0.0;
            Lib_FReal_BesselK(ref res, ref v, ref x);
            if (scaled) res *= exp(x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BesselK", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_BesselK(ref Double res, ref Double v, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv/*' />
        public static Double bessel_kv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_kv(t(nu), t(x), scaled);
        }









        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_prime/*' />
        public static Double bessel_jv_prime(Double v, Double x, bool scaled = false)
        {
            Double res = 0.0;
            Lib_FReal_BesselJPrime(ref res, ref v, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BesselJPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_BesselJPrime(ref Double res, ref Double v, ref Double x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_prime/*' />
        public static Double bessel_jv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_jv_prime(t(nu), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_prime/*' />
        public static Double bessel_yv_prime(Double v, Double x, bool scaled = false)
        {
            Double res = 0.0;
            Lib_FReal_BesselYPrime(ref res, ref v, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BesselYPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_BesselYPrime(ref Double res, ref Double v, ref Double x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_prime/*' />
        public static Double bessel_yv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_yv_prime(t(nu), t(x), scaled);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv_prime/*' />
        public static Double bessel_iv_prime(Double v, Double x, bool scaled = false)
        {
            Double res = 0.0;
            Lib_FReal_BesselIPrime(ref res, ref v, ref x);
            if (scaled) res *= exp(-abs(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BesselIPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_BesselIPrime(ref Double res, ref Double v, ref Double x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv_prime/*' />
        public static Double bessel_iv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_iv_prime(t(nu), t(x), scaled);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv_prime/*' />
        public static Double bessel_kv_prime(Double v, Double x, bool scaled = false)
        {
            Double res = 0.0;
            Lib_FReal_BesselKPrime(ref res, ref v, ref x);
            if (scaled) res *= exp(x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BesselKPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_BesselKPrime(ref Double res, ref Double v, ref Double x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv_prime/*' />
        public static Double bessel_kv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_kv_prime(t(nu), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_zero/*' />
        public static Double bessel_jv_zero(Double x, int m)
        {
            Double res = 0.0;
            Lib_FReal_BesselJZero(ref res, ref x, m);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BesselJZero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_BesselJZero(ref Double res, ref Double x, int m);



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_zero/*' />
        public static Double bessel_yv_zero(Double x, int m)
        {
            Double res = 0.0;
            Lib_FReal_BesselYZero(ref res, ref x, m);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BesselYZero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_BesselYZero(ref Double res, ref Double x, int m);



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





        #region Spherical Bessel functions and spherical modified Bessel functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn/*' />
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

            if (n < 0)
            {
                Double res = sph_bessel_yn(-n - 1, x);
                if ((n + 1) % 2 == 0) res = -res;
                return res;
            }
            else
            {
                Double x1 = x;
                if (x1 <= 0) x1 = -x1;
                Double res = 0.0;
                Lib_FReal_SphBessel(ref res, dreal.lrint(n), ref x1);
                if ((x < 0) && !(n % 2 == 0)) res = -res;
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_SphBessel", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_SphBessel(ref Double res, int v, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn/*' />
        public static Double sph_bessel_jn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_jn(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn' />
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

            if (n < 0)
            {
                Double res = sph_bessel_jn(-n - 1, x);
                if ((n + 2) % 2 == 0) res = -res;
                return res;
            }
            else
            {
                Double x1 = x;
                if (x1 <= 0) x1 = -x1;
                Double res = 0.0;
                Lib_FReal_SphNeumann(ref res, dreal.lrint(n), ref x1);
                if ((x < 0) && !((n + 1) % 2 == 0)) res = -res;
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_SphNeumann", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_SphNeumann(ref Double res, int v, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn/*' />
        public static Double sph_bessel_yn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_yn(t(n), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in/*' />
        public static Double sph_bessel_in(Double n, Double x, bool scaled = false)
        {
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

            Double x1 = x;
            if (x1 <= 0) x1 = -x1;
            Double res = bessel_iv(n + 0.5, x1) / sqrt(2 * x1 / pi());
            if ((x < 0) && !(n % 2 == 0)) res = -res;
            if (scaled) res *= exp(-abs(x));
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in/*' />
        public static Double sph_bessel_in(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_in(t(n), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn/*' />
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
            Double res;
            if (x >= 0.0f) res = bessel_kv(n + 0.5, x) / sqrt(2 * x / pi());
            else res = -0.5f * pi() * (sph_bessel_in(n, -x) + sph_bessel_in(-n - 1, -x));
            if (scaled) res *= exp(x);
            return res;

        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn/*' />
        public static Double sph_bessel_kn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_kn(t(n), t(x), scaled);
        }




        internal static Double besselpoly_(int n, Double x)
        {
            if (n < 0) n = Math.Abs(n)-1;
            if (n == 0) return t(1.0);
            if (n == 1) return x + 1;
            var y = new Double[n+2];
            y[0] = t(1);
            y[1] = x + 1;
            for (int i = 2; i <= n; i++)
            {
                y[i] = (2 * i - 1) * x * y[i - 1] + y[i - 2];
            }
            return y[n];
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besselpoly/*' />
        public static Double besselpoly(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan();
            if (abs(x) < t(0.01)) return besselpoly_(lrint(n), x);
            else
            {
                Double res = sph_bessel_kn(n, 1 / x);
                res *= exp(1 / x) * 2 / (pi() * x);
                return res;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besselpoly/*' />
        public static Double besselpoly(dynamic n, dynamic x, bool scaled = false)
        {
            return besselpoly(t(n), t(x), scaled);
        }





        internal static Double besseltheta_(int n, Double x)
        {
            if (n < 0) n = Math.Abs(n) - 1;
            if (n == 0) return t(1.0);
            if (n == 1) return x + 1;
            var y = new Double[n + 2];
            y[0] = t(1);
            y[1] = x + 1;
            for (int i = 2; i <= n; i++)
            {
                y[i] = (2 * i - 1) * y[i - 1] + x * x * y[i - 2];
            }
            return y[n];
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besseltheta/*' />
        public static Double besseltheta(Double n, Double x, bool scaled = false)
        {
            if (!dreal.isinteger(n)) return dreal.nan();
            if ((x == 0) && (n < 0)) return dreal.nan();
            if ((abs(x) < t(0.01)) && (n >= 0)) return besseltheta_(lrint(n), x);
            if (n < 0) return pow(x, n) * besselpoly(n, 1 / x);
            else
            {
                Double res = sph_bessel_kn(n, x);
                res *= dreal.pow(x, n + 1) * exp(x) * 2 / pi();
                return res;
            }
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
            return sph_bessel_jn(n, x) + dcplx.onej() * sph_bessel_yn(n, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h1/*' />
        public static Complex sph_hankel_h1(int n, dynamic x)
        {
            return sph_hankel_h1(n, t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h2/*' />
        public static Complex sph_hankel_h2(int n, Double x)
        {
            return sph_bessel_jn(n, x) - dcplx.onej() * sph_bessel_yn(n, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h2/*' />
        public static Complex sph_hankel_h2(int n, dynamic x)
        {
            return sph_hankel_h2(n, t(x));
        }






        #endregion





        #region Airy functions



        /// <summary>
        /// Returns airy_ai(Double x)
        /// </summary>
        public static Double airy_ai(Double x, bool scaled = false)
        {
            Double res = 0.0;
            Lib_FReal_AiryAi(ref res, ref x);
            if ((scaled) && (x > 0)) res *= exp((dreal.t(2) / dreal.t(3)) * x * sqrt(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_AiryAi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_AiryAi(ref Double res, ref Double x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai/*' />
        public static Double airy_ai(dynamic x, bool scaled = false)
        {
            return airy_ai(dreal.t(x), scaled);
        }



        /// <summary>
        /// Returns airy_bi(Double x)
        /// </summary>
        public static Double airy_bi(Double x, bool scaled = false)
        {
            Double res = 0.0;
            Lib_FReal_AiryBi(ref res, ref x);
            if ((scaled) && (x > 0)) res *= exp(-abs(dreal.t(2) / dreal.t(3) * (x * sqrt(x))));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_AiryBi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_AiryBi(ref Double res, ref Double x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi/*' />
        public static Double airy_bi(dynamic x, bool scaled = false)
        {
            return airy_bi(dreal.t(x), scaled);
        }



        /// <summary>
        /// Returns airy_ai_prime(Double x)
        /// </summary>
        public static Double airy_ai_prime(Double x, bool scaled = false)
        {
            Double res = 0.0;
            Lib_FReal_AiryAiPrime(ref res, ref x);
            if ((scaled) && (x > 0)) res *= exp((dreal.t(2) / dreal.t(3)) * x * sqrt(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_AiryAiPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_AiryAiPrime(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai_prime/*' />
        public static Double airy_ai_prime(dynamic x, bool scaled = false)
        {
            return airy_ai_prime(dreal.t(x), scaled);
        }


        /// <summary>
        /// Returns airy_bi_prime(Double x)
        /// </summary>
        public static Double airy_bi_prime(Double x, bool scaled = false)
        {
            Double res = 0.0;
            Lib_FReal_AiryBiPrime(ref res, ref x);
            if ((scaled) && (x > 0)) res *= exp(-abs(dreal.t(2) / dreal.t(3) * (x * sqrt(x))));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_AiryBiPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_AiryBiPrime(ref Double res, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi_prime/*' />
        public static Octuple airy_bi_prime(dynamic x, bool scaled = false)
        {
            return airy_bi_prime(dreal.t(x), scaled);
        }


        /// <summary>
        /// Returns airy_ai_zero(int n)
        /// </summary>
        public static Double airy_ai_zero(int n)
        {
            Double res = 0.0;
            Lib_FReal_Aizero(ref res, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Aizero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Aizero(ref Double res, int n);


        /// <summary>
        /// Returns airy_bi_zero(int n)
        /// </summary>
        public static Double airy_bi_zero(int n)
        {
            Double res = 0.0;
            Lib_FReal_Bizero(ref res, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Bizero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Bizero(ref Double res, int n);




        #endregion





        #region 1F1 Overview



        /// <summary>
        /// Returns hyperg_1f1(Double a, Double b, Double x)
        /// </summary>
        public static Double hyperg_1f1(Double a, Double b, Double x)
        {
            Double res = 0.0;
            Lib_FReal_Hypergeo1F1(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Hypergeo1F1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Hypergeo1F1(ref Double res, ref Double a, ref Double b, ref Double x);



        /// <summary>
        /// Returns hyperg_1f1r(Double a, Double b, Double x)
        /// </summary>
        public static Double hyperg_1f1r(Double a, Double b, Double x)
        {
            Double res = 0.0;
            Lib_FReal_Hypergeo1F1r(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Hypergeo1F1r", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Hypergeo1F1r(ref Double res, ref Double a, ref Double b, ref Double x);



        /// <summary>
        /// Returns log_hyperg_1f1(Double a, Double b, Double x)
        /// </summary>
        public static Double log_hyperg_1f1(Double a, Double b, Double x)
        {
            Double res = 0.0;
            Lib_FReal_LogHypergeo1F1(ref res, ref a, ref b, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LogHypergeo1F1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_LogHypergeo1F1(ref Double res, ref Double a, ref Double b, ref Double x);



        /// <summary>
        /// Returns hermite_h(int n, Double x)
        /// </summary>
        public static Double hermite_h(int n, Double x)
        {
            Double res = 0.0;
            Lib_FReal_Hermite(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Hermite", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Hermite(ref Double res, int n, ref Double x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hermite_he/*' />
        public static Double hermite_he(int n, Double x)
        {
            return exp2(-n / 2) * hermite_h(n, x / sqrt(2));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hermite_he/*' />
        public static Double hermite_he(int n, dynamic x)
        {
            return hermite_he(n, dreal.t(x));
        }




        /// <summary>
        /// Returns laguerre_ass(int n, int m, Double x)
        /// </summary>
        public static Double laguerre_l(int n, int m, Double x)
        {
            Double res = 0.0;
            Lib_FReal_LaguerreM(ref res, n, m, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LaguerreM", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_LaguerreM(ref Double res, int n, int m, ref Double x);






        #endregion



        #region Exponential integrals and related functions


        /// <summary>
        /// Returns Exp_integral_ei(Double x)
        /// </summary>
        public static Double exp_integral_ei(Double x)
        {
            Double res = 0.0;
            Lib_FReal_Ei(ref res, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Ei", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Ei(ref Double res, ref Double x);




        /// <summary>
        /// Returns exp_integral_en(uint n, Double x)
        /// </summary>
        public static Double exp_integral_en(int n, Double x)
        {
            if (n < 0) return nan();
            Double res = 0.0;
            Lib_FReal_expint(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_expint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_expint(ref Double res, int n, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/exp_integral_ei/*' />
        public static Double exp_integral_en(int n, dynamic x)
        {
            return exp_integral_en(n, t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp_integral_e1/*' />
        public static Double exp_integral_e1(Double z)
        {
            if (z < 0) return -exp_integral_ei(-z);
            else return exp_integral_en(1, z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp_integral_e1/*' />
        public static Double exp_integral_e1(dynamic z)
        {
            return exp_integral_e1(sreal.t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log_integral/*' />
        public static Double log_integral(Double z)
        {
            if (z < 0) return nan();
            if (z == 0) return zero();
            else return exp_integral_ei(log(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log_integral/*' />
        public static Double log_integral(dynamic z)
        {
            return log_integral(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh_integral/*' />
        public static Double cosh_integral(Double x)
        {
            return (exp_integral_ei(x) - exp_integral_e1(x)) / 2;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh_integral/*' />
        public static Double cosh_integral(dynamic z)
        {
            return cosh_integral(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh_integral/*' />
        public static Double sinh_integral(Double x)
        {
            return (exp_integral_ei(x) + exp_integral_e1(x)) / 2;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh_integral/*' />
        public static Double sinh_integral(dynamic z)
        {
            return sinh_integral(t(z));
        }






        #endregion



        #region 1F1-related orthogonal polynomials


        #endregion



        #region 2F1-related orthogonal polynomials




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_t/*' />
        public static Double chebyshev_t(int n, Double x)
        {
            Double res = 0.0;
            Lib_FReal_ChebyshevT(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_ChebyshevT", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_ChebyshevT(ref Double res, int n, ref Double x);




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_u/*' />
        public static Double chebyshev_u(int n, Double x)
        {
            Double res = 0.0;
            Lib_FReal_ChebyshevU(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_ChebyshevU", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_ChebyshevU(ref Double res, int n, ref Double x);




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_v/*' />
        public static Double chebyshev_v(int n, Double x)  // same as t_n(x)
        {
            if (x < 0.0)
            {
                int m = -1; if (n % 2 == 0) m = 1; // m = exp(i * n * pi)
                return m * chebyshev_w(n, -x);
            }
            else return sqrt(2 / (1 + x)) * chebyshev_t(2 * n + 1, sqrt((x + 1) / 2));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_w/*' />
        public static Double chebyshev_w(int n, Double x)  // same as u_n(x)
        {
            if (x < 0.0)
            {
                int m = -1; if (n % 2 == 0) m = 1; // m = exp(i * n * pi)
                return m * chebyshev_v(n, -x);
            }
            else return chebyshev_u(2 * n, sqrt((x + 1) / 2));
        }



        /// <summary>
        /// Returns legendre_p(int n, Double x)
        /// </summary>
        public static Double legendre_p(int n, Double x)
        {
            Double res = 0.0;
            Lib_FReal_LegendreP(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LegendreP", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_LegendreP(ref Double res, int n, ref Double x);




        /// <summary>
        /// Returns legendre_q(int n, Double x)
        /// </summary>
        public static Double legendre_q(int n, Double x)
        {
            Double res = 0.0;
            Lib_FReal_LegendreQ(ref res, n, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LegendreQ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_LegendreQ(ref Double res, int n, ref Double x);




        /// <summary>
        /// Returns legendre_plm(int n, int m, Double x)
        /// </summary>
        public static Double legendre_plm(int n, int m, Double x)
        {
            Double res = 0.0;
            Lib_FReal_LegendrePM(ref res, n, m, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LegendrePM", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_LegendrePM(ref Double res, int n, int m, ref Double x);





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gegenbauer_c/*' />
        public static Double gegenbauer_c(int n, Double lambda1, Double x)
        {
            Double res = 0.0;
            Lib_FReal_Gegenbauer(ref res, n, ref lambda1, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Gegenbauer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Gegenbauer(ref Double res, int n, ref Double lambda1, ref Double x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gegenbauer_c/*' />
        public static Double gegenbauer_c(int n, dynamic lambda1, dynamic x)
        {
            return gegenbauer_c(n, t(lambda1), t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_p/*' />
        public static Double jacobi_p_(int n, Double alpha, Double beta, Double x)
        {
            Double res = 0.0;
            Lib_FReal_Jacobi(ref res, n, ref alpha, ref beta, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Jacobi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Jacobi(ref Double res, int n, ref Double alpha, ref Double beta, ref Double x);

        public static Double jacobi_p(Double n, Double alpha, Double beta, Double x)
        {
            if (!dreal.isinteger(n)) return dreal.nan();
            return jacobi_p_(lrint(n), alpha, beta, x);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_p/*' />
        public static Double jacobi_p(dynamic n, dynamic alpha, dynamic beta, dynamic x)
        {
            return jacobi_p(t(n), t(alpha), t(beta), t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/zernike_r/*' />
        public static Double zernike_r(Double n, Double m, Double r)
        {
            if (!dreal.isinteger(n)) return dreal.nan();
            if (!dreal.isinteger(m)) return dreal.nan();
            if ((n < m) || (m < 0)) return dreal.zero();
            if (!((n - m) % 2 == 0)) return dreal.zero();
            if (r < 0) return dreal.zero();
            return pow(r, m) * jacobi_p((n - m) / 2, 0, m, 2 * r * r - 1);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/zernike_r/*' />
        public static Double zernike_r(dynamic n, dynamic m, dynamic r)
        {
            return zernike_r(t(n), t(m), t(r));
        }














        internal static Double spherical_harmonic_r(int n, int m, Double theta, Double phi)
        {
            Double res = 0.0;
            Lib_FReal_SphericalHarmonicR(ref res, n, m, ref theta, ref phi);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_SphericalHarmonicR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_SphericalHarmonicR(ref Double res, int n, int m, ref Double theta, ref Double phi);


        internal static Double spherical_harmonic_i(int n, int m, Double theta, Double phi)
        {
            Double res = 0.0;
            Lib_FReal_SphericalHarmonicI(ref res, n, m, ref theta, ref phi);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_SphericalHarmonicI", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_SphericalHarmonicI(ref Double res, int n, int m, ref Double theta, ref Double phi);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/spherical_y/*' />
        public static Complex spherical_y(Double n, Double m, Double theta, Double phi)
        {
            return dcplx.t(spherical_harmonic_r(lrint(n), lrint(m), theta, phi),
                           spherical_harmonic_i(lrint(n), lrint(m), theta, phi));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/spherical_y/*' />
        public static Complex spherical_y(dynamic n, dynamic m, dynamic theta, dynamic phi)
        {
            return spherical_y(dreal.t(n), dreal.t(m), dreal.t(theta), dreal.t(phi));
        }



        #endregion





        #endregion







        #region Boost Distributions as classes


        #region Base classes

        public class BaseDistClass
        {
            internal static Double nil = 0.0;
            internal static int target = 1;
            //internal static Double a_;
            //internal static Double b_;
            //internal static Double c_;
            //internal static Double lambda1_;
            //internal static Double delta_;
            //internal static Double k_;
            //internal static Double m_;
            //internal static Double n_;
            //internal static Double p_;
            //internal static Double r_;
            //internal static Double mu_;
            //internal static Double sigma_;


            internal virtual Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                return res;
            }

            public static dreal ctx
            {
                get { return new dreal(); }
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/cdf/*' />
            public Double cdf(Double x)
            {
                target = 2;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/cdf/*' />
            public Double cdf(dynamic x)
            {
                target = 2;
                return BaseDist(t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/sf/*' />
            public Double sf(Double x)
            {
                target = 3;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/sf/*' />
            public Double sf(dynamic x)
            {
                target = 3;
                return BaseDist(t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/hf/*' />
            public Double hf(Double x)
            {
                target = 4;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/hf/*' />
            public Double hf(dynamic x)
            {
                target = 4;
                return BaseDist(t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/chf/*' />
            public Double chf(Double x)
            {
                target = 5;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/chf/*' />
            public Double chf(dynamic x)
            {
                target = 5;
                return BaseDist(t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/qtf/*' />
            public Double qtf(Double q)
            {
                target = 6;
                return BaseDist(q);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/qtf/*' />
            public Double qtf(dynamic q)
            {
                target = 6;
                return BaseDist(t(q));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/isf/*' />
            public Double isf(Double q)
            {
                target = 7;
                return BaseDist(q);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/isf/*' />
            public Double isf(dynamic q)
            {
                target = 7;
                return BaseDist(t(q));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/mean/*' />
            public Double mean()
            {
                target = 8;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/median/*' />
            public Double median()
            {
                target = 9;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/mode/*' />
            public Double mode()
            {
                target = 10;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/variance/*' />
            public Double variance()
            {
                target = 11;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/stdev/*' />
            public Double stdev()
            {
                target = 12;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/skewness/*' />
            public Double skewness()
            {
                target = 13;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/kurtosis/*' />
            public Double kurtosis()
            {
                target = 14;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/kurtosis_excess/*' />
            public Double kurtosis_excess()
            {
                target = 15;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/support_lower_endpoint/*' />
            public Double support_lower_endpoint()
            {
                target = 16;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/support_upper_endpoint/*' />
            public Double support_upper_endpoint()
            {
                target = 17;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/range_lower_endpoint/*' />
            public Double range_lower_endpoint()
            {
                target = 18;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/range_upper_endpoint/*' />
            public Double range_upper_endpoint()
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
            public Double pdf(Double x)
            {
                target = 1;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/pdf/*' />
            public Double pdf(dynamic x)
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
            public Double pmf(Double x)
            {
                target = 1;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/pmf/*' />
            public Double pmf(dynamic x)
            {
                target = 1;
                return BaseDist(t(x));
            }
        }


        #endregion


        #region Closed form distributions, based on elementary functions



        #region ArcsineDist


        public class ArcsineDistClass : BaseDistContClass
        {
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_ArcsineDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_ArcsineDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_ArcsineDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            internal ArcsineDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ArcsineDist/*' />
        public static ArcsineDistClass dist_arcsine(Double a, Double b)
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
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_CauchyDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_CauchyDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_CauchyDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            internal CauchyDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/CauchyDist/*' />
        public static CauchyDistClass dist_cauchy(Double a, Double b)
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
            Double lambda1;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                //Lib_FReal_ExponentialDist(target, ref res, ref xqp, ref lambda1_);
                Lib_FReal_ExponentialDist(target, ref res, ref xqp, ref lambda1);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_ExponentialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_ExponentialDist(int target, ref Double res, ref Double xqp, ref Double lambda1);

            internal ExponentialDistClass(Double _lambda1)
            {
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExponentialDist/*' />
        public static ExponentialDistClass dist_exponential(Double lambda1)
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
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                //Lib_FReal_GumbelDist(target, ref res, ref xqp, ref a_, ref b_);
                Lib_FReal_GumbelDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_GumbelDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_GumbelDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            internal GumbelDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GumbelDist/*' />
        public static GumbelDistClass dist_gumbel(Double a, Double b)
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
            private DoubleVec matProb_ = new DoubleVec();
            private DoubleVec matRate_ = new DoubleVec();

            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_HyperexponentialDist(target, ref res, ref xqp, matProb_.mpPtr, matRate_.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_HyperexponentialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_HyperexponentialDist(int target, ref Double res, ref Double xqp, IntPtr Prob, IntPtr Rate);

            internal HyperexponentialDistClass(DoubleVec Prob, DoubleVec Rate)
            {
                matProb_ = Prob;
                matRate_ = Rate;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/HyperexponentialDist/*' />
        public static HyperexponentialDistClass dist_hyperexponential(DoubleVec Prob, DoubleVec Rate)
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
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = t(0);
                Double pdf = t(0);
                Double sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    res = a * b * pow(xqp, a - 1);
                    Double temp = pow(-powm1(xqp, a), b - 1);
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

            internal KumaraswamyDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_kumaraswamy/*' />
        public static KumaraswamyDistClass dist_kumaraswamy(Double a, Double b)
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
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                //Lib_FReal_LaplaceDist(target, ref res, ref xqp, ref a_, ref b_);
                Lib_FReal_LaplaceDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LaplaceDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_LaplaceDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            internal LaplaceDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LaplaceDist/*' />
        public static LaplaceDistClass dist_laplace(Double a, Double b)
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
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                //Lib_FReal_LogisticDist(target, ref res, ref xqp, ref a_, ref b_);
                Lib_FReal_LogisticDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LogisticDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_LogisticDist(int target, ref Double res, ref Double xqp, ref Double loc, ref Double scale);

            internal LogisticDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LogisticDist/*' />
        public static LogisticDistClass dist_logistic(Double a, Double b)
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
            Double k;
            Double a;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                //Lib_FReal_ParetoDist(target, ref res, ref xqp, ref k_, ref a_);
                Lib_FReal_ParetoDist(target, ref res, ref xqp, ref k, ref a);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_ParetoDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_ParetoDist(int target, ref Double res, ref Double xqp, ref Double k, ref Double a);

            internal ParetoDistClass(Double _k, Double _a)
            {
                k = _k;
                a = _a;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ParetoDist/*' />
        public static ParetoDistClass dist_pareto(Double k, Double a)
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
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_RayleighDist(target, ref res, ref xqp, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_RayleighDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_RayleighDist(int target, ref Double res, ref Double xqp, ref Double b);

            internal RayleighDistClass(Double _b)
            {
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RayleighDist/*' />
        public static RayleighDistClass dist_rayleigh(Double b)
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
            Double a;
            Double m;
            Double b;

            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                //Lib_FReal_TriangularDist(target, ref res, ref xqp, ref a_, ref m_, ref b_);
                Lib_FReal_TriangularDist(target, ref res, ref xqp, ref a, ref m, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_TriangularDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_TriangularDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double m, ref Double b);

            internal TriangularDistClass(Double _a, Double _m, Double _b)
            {
                a = _a;
                m = _m;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TriangularDist/*' />
        public static TriangularDistClass dist_triangular(Double a, Double m, Double b)
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
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_UniformDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_UniformDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_UniformDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            internal UniformDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/UniformDist/*' />
        public static UniformDistClass dist_uniform(Double a, Double b)
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
            Double a;
            Double b;

            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                //Lib_FReal_WeibullDist(target, ref res, ref xqp, ref a_, ref b_);
                Lib_FReal_WeibullDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_WeibullDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_WeibullDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            internal WeibullDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WeibullDist/*' />
        public static WeibullDistClass dist_weibull(Double a, Double b)
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
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = t(0);
                Double pdf = t(0);
                Double sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Double s = sqrt(b / (2 * pi()));
                    Double t = exp(-b / (2 * (xqp - a)));
                    Double u = pow(xqp - a, 1.5);
                    pdf = s * t / u;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    Double s = sqrt(b / (2 * (xqp - a)));
                    sf = erf(s);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            Double s = sqrt(b / (2 * (xqp - a)));
                            res = erfc(s); break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            Double s1 = erfc_inv(xqp);
                            s1 = 2 * s1 * s1;
                            res = a + b / s1; break;
                        } // qtf, Pinv
                    case 7:
                        {
                            Double s1 = erf_inv(xqp);
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

            public LevyDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_levy/*' />
        public static LevyDistClass dist_levy(Double a, Double b)
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
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                //Lib_FReal_LognormalDist(target, ref res, ref xqp, ref a_, ref b_);
                Lib_FReal_LognormalDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LognormalDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_LognormalDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            public LognormalDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LognormalDist/*' />
        public static LognormalDistClass dist_lognormal(Double a, Double b)
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
            Double a;
            Double b;

            internal override Double BaseDist(Double xqp)
            {
                Double res = t(0);
                Double pdf = t(0);
                Double sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Double t1 = (xqp - a) / (2 * b);
                    Double t2 = t("0.5") * exp(-(xqp - a) / b);
                    Double s = b * sqrt(2 * pi());
                    pdf = exp(-t1 - t2) / s;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    Double s = exp(-(xqp - a) / (2 * b)) / sqrt(2);
                    sf = erf(s);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            Double s = exp(-(xqp - a) / (2 * b)) / sqrt(2);
                            res = erfc(s); break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            Double s1 = erfc_inv(xqp);
                            s1 = 2 * s1 * s1;
                            res = a - b * log(s1); break;
                        } // qtf, Pinv
                    case 7:
                        {
                            Double s1 = erf_inv(xqp);
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

            public MoyalDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_moyal/*' />
        public static MoyalDistClass dist_moyal(Double a, Double b)
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
            Double mu;
            Double sigma;

            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                //Lib_FReal_NormalDist(target, ref res, ref xqp, ref mu_, ref sigma_);
                Lib_FReal_NormalDist(target, ref res, ref xqp, ref mu, ref sigma);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_NormalDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_NormalDist(int target, ref Double res, ref Double xqp, ref Double mu, ref Double sigma);

            public NormalDistClass(Double _mu, Double _sigma)
            {
                mu = _mu;
                sigma = _sigma;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NormalDist/*' />
        public static NormalDistClass dist_normal(Double mu, Double sigma)
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
            Double a;
            Double b;
            Double c;

            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                //Lib_FReal_SkewNormalDist(target, ref res, ref xqp, ref a_, ref b_, ref c_);
                Lib_FReal_SkewNormalDist(target, ref res, ref xqp, ref a, ref b, ref c);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_SkewNormalDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_SkewNormalDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b, ref Double c);

            public SkewNormalDistClass(Double _a, Double _b, Double _c)
            {
                a = _a;
                b = _b;
                c = _c;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SkewNormalDist/*' />
        public static SkewNormalDistClass dist_skewnormal(Double a, Double b, Double c)
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
            Double mu;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                //Lib_FReal_WaldDist(target, ref res, ref xqp, ref mu_, ref b_);
                Lib_FReal_WaldDist(target, ref res, ref xqp, ref mu, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_WaldDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_WaldDist(int target, ref Double res, ref Double xqp, ref Double mu, ref Double b);

            public WaldDistClass(Double _mu, Double _b)
            {
                mu = _mu;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WaldDist/*' />
        public static WaldDistClass dist_wald(Double mu, Double b)
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
            Double n;
            internal override Double BaseDist(Double xqp)
            {
                Double res = t(0);
                Double pdf = t(0);
                Double sf = t(0);
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

            public ChiDistClass(Double _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_chi/*' />
        public static ChiDistClass dist_chi(Double n)
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
            Double n;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_Chi2Dist(target, ref res, ref xqp, ref n);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Chi2Dist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_Chi2Dist(int target, ref Double res, ref Double xqp, ref Double n);

            public Chi2DistClass(Double _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2Dist/*' />
        public static Chi2DistClass dist_chi2(Double n)
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
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_GammaDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_GammaDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_GammaDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            public GammaDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GammaDist/*' />
        public static GammaDistClass dist_gamma(Double a, Double b)
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
            Double a;
            Double b;

            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_InverseChi2Dist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_InverseChi2Dist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_InverseChi2Dist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            public InverseChi2DistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseChi2Dist/*' />
        public static InverseChi2DistClass dist_inverse_chi2(Double a, Double b)
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
            Double a;
            Double b;

            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_InverseGammaDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_InverseGammaDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_InverseGammaDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            public InverseGammaDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseGammaDist/*' />
        public static InverseGammaDistClass dist_inverse_gamma(Double a, Double b)
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
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = t(0);
                Double pdf = t(0);
                Double sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Double s = sqrt(2 / pi());
                    Double t = (xqp * xqp) / (b * b * b);
                    Double u = exp(-(xqp * xqp) / (2 * b * b));
                    pdf = s * t * u;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    Double n = t(1.5);
                    Double t2 = (xqp * xqp) / (2 * b * b);
                    sf = gamma_q(n, t2);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            Double n = t(1.5);
                            Double t2 = (xqp * xqp) / (2 * b * b);
                            res = gamma_p(n, t2);
                            break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            Double n = t(1.5);
                            Double t2 = (xqp * xqp) / (2 * b * b);
                            res = b * sqrt(2 * gamma_p_inv(n, xqp));
                            break;
                        } // qtf, Pinv
                    case 7:
                        {
                            Double n = t(1.5);
                            Double t2 = (xqp * xqp) / (2 * b * b);
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

            public MaxwellDistClass(Double _b)
            {
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_maxwell/*' />
        public static MaxwellDistClass dist_maxwell(Double b)
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
            Double m;
            Double w;
            internal override Double BaseDist(Double xqp)
            {
                Double res = t(0);
                Double pdf = t(0);
                Double sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Double s = exp(-m * xqp * xqp / w) * 2 * pow(m / w, m) * pow(xqp, 2 * m - 1);
                    Double t = gamma(m);
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

            public NakagamiDistClass(Double _m, Double _w)
            {
                m = _m;
                w = _w;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_nakagami/*' />
        public static NakagamiDistClass dist_nakagami(Double m, Double w)
        {
            return new NakagamiDistClass(m, w);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_nakagami/*' />
        public static NakagamiDistClass dist_nakagami(dynamic m, dynamic w)
        {
            return dist_nakagami(t(m), t(w));
        }

        #endregion





        #endregion



        #region Closed form distributions, based on the incomplete beta function


        #region BetaDist


        public class BetaDistClass : BaseDistContClass
        {
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_BetaDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BetaDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_BetaDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            public BetaDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaDist/*' />
        public static BetaDistClass dist_beta(Double a, Double b)
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
            Double m;
            Double n;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_FisherFDist(target, ref res, ref xqp, ref m, ref n);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_FisherFDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_FisherFDist(int target, ref Double res, ref Double xqp, ref Double m, ref Double n);

            public FisherFDistClass(Double _m, Double _n)
            {
                m = _m;
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherFDist/*' />
        public static FisherFDistClass dist_fisher_f(Double m, Double n)
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
            Double n;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_StudentTDist(target, ref res, ref xqp, ref n);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_StudentTDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_StudentTDist(int target, ref Double res, ref Double xqp, ref Double n);

            public StudentTDistClass(Double _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTDist/*' />
        public static StudentTDistClass dist_student_t(Double n)
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
            Double n;
            Double lambda1;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_Chi2NcDist(target, ref res, ref xqp, ref n, ref lambda1);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Chi2NcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_Chi2NcDist(int target, ref Double res, ref Double xqp, ref Double n, ref Double lambda1);

            public Chi2NcDistClass(Double _n, Double _lambda1)
            {
                n = _n;
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2NcDist/*' />
        public static Chi2NcDistClass dist_chi2_nc(Double n, Double lambda1)
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
            Double n;
            Double delta;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_StudentTNcDist(target, ref res, ref xqp, ref n, ref delta);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_StudentTNcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_StudentTNcDist(int target, ref Double res, ref Double xqp, ref Double n, ref Double delta);

            public StudentTNcDistClass(Double _n, Double _delta)
            {
                n = _n;
                delta = _delta;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTNcDist/*' />
        public static StudentTNcDistClass dist_student_t_nc(Double n, Double delta)
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
            Double m;
            Double n;
            Double lambda1;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_FisherNcDist(target, ref res, ref xqp, ref m, ref n, ref lambda1);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_FisherNcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_FisherNcDist(int target, ref Double res, ref Double xqp, ref Double m, ref Double n, ref Double lambda1);

            public FisherFNcDistClass(Double _m, Double _n, Double _lambda1)
            {
                m = _m;
                n = _n;
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherNcDist/*' />
        public static FisherFNcDistClass dist_fisher_f_nc(Double m, Double n, Double lambda1)
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
            Double a;
            Double b;
            Double lambda1;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_BetaNcDist(target, ref res, ref xqp, ref a, ref b, ref lambda1);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BetaNcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_BetaNcDist(int target, ref Double res, ref Double xqp, ref Double nu, ref Double mu, ref Double lambda1);

            public BetaNcDistClass(Double _a, Double _b, Double _lambda1)
            {
                a = _a;
                b = _b;
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaNcDist/*' />
        public static BetaNcDistClass dist_beta_nc(Double a, Double b, Double lambda1)
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
            Double n;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_KolmogorovSmirnovDist(target, ref res, ref xqp, ref n);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_KolmogorovSmirnovDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_KolmogorovSmirnovDist(int target, ref Double res, ref Double xqp, ref Double a);

            public KolmogorovSmirnovDistClass(Double _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/KolmogorovSmirnovDist/*' />
        public static KolmogorovSmirnovDistClass dist_kolmogorov_smirnov(Double n)
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
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_HoltsmarkDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_HoltsmarkDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_HoltsmarkDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            public HoltsmarkDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/HoltsmarkDist/*' />
        public static HoltsmarkDistClass dist_holtsmark(Double a, Double b)
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
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_LandauDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_LandauDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_LandauDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            public LandauDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LandauDist/*' />
        public static LandauDistClass dist_landau(Double a, Double b)
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
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_MapAiryDist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_MapAiryDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_MapAiryDist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            public MapAiryDistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/MapAiryDist/*' />
        public static MapAiryDistClass dist_mapairy(Double a, Double b)
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
            Double a;
            Double b;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_Saspoint5Dist(target, ref res, ref xqp, ref a, ref b);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Saspoint5Dist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_Saspoint5Dist(int target, ref Double res, ref Double xqp, ref Double a, ref Double b);

            public Saspoint5DistClass(Double _a, Double _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Saspoint5Dist/*' />
        public static Saspoint5DistClass dist_saspoint5(Double a, Double b)
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




        #region Discrete (lattice) distribution functions



        #region BernoulliDist


        public class BernoulliDistClass : BaseDistDiscreteClass
        {
            Double p;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_BernoulliDist(target, ref res, ref xqp, ref p);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BernoulliDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_BernoulliDist(int target, ref Double res, ref Double xqp, ref Double p);

            public BernoulliDistClass(Double _p)
            {
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BernoulliDist/*' />
        public static BernoulliDistClass dist_bernoulli(Double p)
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
            Double p;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_GeometricDist(target, ref res, ref xqp, ref p);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_GeometricDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_GeometricDist(int target, ref Double res, ref Double xqp, ref Double p);

            public GeometricDistClass(Double _p)
            {
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GeometricDist/*' />
        public static GeometricDistClass dist_geometric(Double p)
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
            Double mu;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_PoissonDist(target, ref res, ref xqp, ref mu);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_PoissonDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_PoissonDist(int target, ref Double res, ref Double xqp, ref Double mu);

            public PoissonDistClass(Double _mu)
            {
                mu = _mu;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/PoissonDist/*' />
        public static PoissonDistClass dist_poisson(Double mu)
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
            Double n;
            Double p;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_BinomialDist(target, ref res, ref xqp, ref n, ref p);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_BinomialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_BinomialDist(int target, ref Double res, ref Double xqp, ref Double n, ref Double p);

            public BinomialDistClass(Double _n, Double _p)
            {
                n = _n;
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BinomialDist/*' />
        public static BinomialDistClass dist_binomial(Double n, Double p)
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
            Double r;
            Double p;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_NegBinomialDist(target, ref res, ref xqp, ref r, ref p);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_NegBinomialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_NegBinomialDist(int target, ref Double res, ref Double xqp, ref Double r, ref Double p);

            public NegBinomialDistClass(Double _r, Double _p)
            {
                r = _r;
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NegBinomialDist/*' />
        public static NegBinomialDistClass dist_negbinomial(Double r, Double p)
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
            internal UInt64 r;
            internal UInt64 n;
            internal UInt64 NN;
            internal override Double BaseDist(Double xqp)
            {
                Double res = 0.0;
                Lib_FReal_HypergeometricDist(target, ref res, ref xqp, r, n, NN);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_HypergeometricDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_FReal_HypergeometricDist(int target, ref Double res, ref Double xqp, UInt64 r, UInt64 n, UInt64 NN);

            public HypergeometricDistClass(UInt64 _r, UInt64 _n, UInt64 _NN)
            {
                r = _r;
                n = _n;
                NN = _NN;
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



        #endregion





        #region Boost Calculus


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BracketRoot/*' />
        public static Tuple<Double, Double, int> BracketRoot(cb1SDouble1S f, dynamic guess, dynamic factor, bool is_rising, int get_digits, uint maxit)
        {
            return BracketRoot(f, dreal.t(guess), dreal.t(factor), is_rising, get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BracketRoot/*' />
        public static Tuple<Double, Double, int> BracketRoot(cb1SDouble1S f, Double guess, Double factor, bool is_rising = true, Int32 get_digits = 0, UInt32 maxit = 50)
        {
            Double res1 = 0, res2 = 0;
            var iter = default(int);
            Lib_Double_BracketRoot(ref res1, ref res2, ref iter, f, guess, factor, is_rising, get_digits, maxit);
            return new Tuple<Double, Double, int>(res1, res2, iter);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_BracketRoot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_BracketRoot(ref Double res1, ref Double res2, ref int iter, cb1SDouble1S f, Double guess, Double factor, bool is_rising, int get_digits, uint maxit);



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NewtonRaphson/*' />
        public static Tuple<Double, int> NewtonRaphson(cb1SDouble1S f, cb1SDouble1S df, dynamic guess, dynamic xmin, dynamic xmax, int get_digits, uint maxit)
        {
            return NewtonRaphson(f, df, dreal.t(guess), dreal.t(xmin), dreal.t(xmax), get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NewtonRaphson/*' />
        public static Tuple<Double, int> NewtonRaphson(cb1SDouble1S f, cb1SDouble1S df, Double guess, Double xmin, Double xmax, int get_digits, uint maxit)
        {
            var res1 = default(Double);
            var iter = default(int);
            Lib_Double_NewtonRaphson(ref res1, ref iter, f, df, guess, xmin, xmax, get_digits, maxit);
            return new Tuple<Double, int>(res1, iter);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_NewtonRaphson", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_NewtonRaphson(ref Double res1, ref int iter, cb1SDouble1S f1, cb1SDouble1S df, Double guess, Double xmin, Double xmax, int get_digits, uint maxit);



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Halley/*' />
        public static Tuple<Double, int> Halley(cb1SDouble1S f, cb1SDouble1S df1, cb1SDouble1S df2, dynamic guess, dynamic xmin, dynamic xmax, int get_digits, uint maxit)
        {
            return Halley(f, df1, df2, dreal.t(guess), dreal.t(xmin), dreal.t(xmax), get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Halley/*' />
        public static Tuple<Double, int> Halley(cb1SDouble1S f, cb1SDouble1S df1, cb1SDouble1S df2, Double guess, Double xmin, Double xmax, int get_digits, uint maxit)
        {
            var res1 = default(Double);
            var iter = default(int);
            Lib_Double_Halley(ref res1, ref iter, f, df1, df2, guess, xmin, xmax, get_digits, maxit);
            return new Tuple<Double, int>(res1, iter);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_Halley", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_Halley(ref Double res1, ref int iter, cb1SDouble1S f1, cb1SDouble1S df1, cb1SDouble1S df2, Double guess, Double xmin, Double xmax, int get_digits, uint maxit);



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Schroder/*' />
        public static Tuple<Double, int> Schroder(cb1SDouble1S f, cb1SDouble1S df1, cb1SDouble1S df2, dynamic guess, dynamic xmin, dynamic xmax, int get_digits, uint maxit)
        {
            return Schroder(f, df1, df2, dreal.t(guess), dreal.t(xmin), dreal.t(xmax), get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Schroder/*' />
        public static Tuple<Double, int> Schroder(cb1SDouble1S f, cb1SDouble1S df1, cb1SDouble1S df2, Double guess, Double xmin, Double xmax, int get_digits, uint maxit)
        {
            var res1 = default(Double);
            var iter = default(int);
            Lib_Double_Schroder(ref res1, ref iter, f, df1, df2, guess, xmin, xmax, get_digits, maxit);
            return new Tuple<Double, int>(res1, iter);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_Schroder", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_Schroder(ref Double res1, ref int iter, cb1SDouble1S f1, cb1SDouble1S df1, cb1SDouble1S df2, Double guess, Double xmin, Double xmax, int get_digits, uint maxit);




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BrentMinimum/*' />
        public static Tuple<Double, Double, int> Brent_Minimum(cb1SDouble1S f, dynamic bracket_min, dynamic bracket_max, int bits, uint maxit)
        {
            return Brent_Minimum(f, dreal.t(bracket_min), dreal.t(bracket_max), bits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BrentMinimum/*' />
        public static Tuple<Double, Double, int> Brent_Minimum(cb1SDouble1S f, Double bracket_min, Double bracket_max, int bits, uint maxit)
        {
            var result = default(Double);
            var resultFx = default(Double);
            var iter = default(int);
            Lib_Double_Brent_Minimum(ref result, ref resultFx, ref iter, f, bracket_min, bracket_max, bits, maxit);
            return new Tuple<Double, Double, int>(result, resultFx, iter);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_Brent_Minimum", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_Brent_Minimum(ref Double res, ref Double resFx, ref int iter, cb1SDouble1S f, Double bracket_min, Double bracket_max, int bits, uint maxit);


        // ******************************************************************************************************************************************************************************************************************



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Trapezoidal/*' />

        public static Tuple<Double, Double, Double> Trapezoidal(cb1SDouble1S f, dynamic a, dynamic b, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return dreal.Trapezoidal(f, dreal.t(a), dreal.t(b), dreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Trapezoidal/*' />
        public static Tuple<Double, Double, Double> Trapezoidal(cb1SDouble1S f, Double a, Double b, Double tol, uint max_refinements = 12)
        {
            Double res1 = 0, res2 = 0, res3 = 0;
            Lib_Double_Trapezoidal(ref res1, ref res2, ref res3, f, a, b);
            return new Tuple<Double, Double, Double>(res1, res2, res3);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_Trapezoidal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_Trapezoidal(ref Double res1, ref Double res2, ref Double res3, cb1SDouble1S f, Double a, Double b);




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussLegendre/*' />
        public static Tuple<Double, Double> GaussLegendre(cb1SDouble1S f, dynamic a, dynamic b)
        {
            return GaussLegendre(f, dreal.t(a), dreal.t(b));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussLegendre/*' />
        public static Tuple<Double, Double> GaussLegendre(cb1SDouble1S f, Double a, Double b)
        {
            Double res1 = 0, res3 = 0;
            Lib_Double_GaussLegendre(ref res1, ref res3, f, a, b);
            return new Tuple<Double, Double>(res1, res3);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_GaussLegendre", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_GaussLegendre(ref Double res1, ref Double res3, cb1SDouble1S f, Double a, Double b);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussKronrod/*' />
        public static Tuple<Double, Double, Double> GaussKronrod(cb1SDouble1S f, dynamic a, dynamic b, dynamic tol = null, uint max_depth = 12)
        {
            if (tol == null) { tol = t(0); }
            return GaussKronrod(f, dreal.t(a), dreal.t(b), dreal.t(tol), max_depth);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussKronrod/*' />
        /// <returns></returns>
        public static Tuple<Double, Double, Double> GaussKronrod(cb1SDouble1S f, Double a, Double b, Double tol, uint max_depth = 12)
        {
            Double res1 = 0, res2 = 0, res3 = 0;
            Lib_Double_GaussKronrod(ref res1, ref res2, ref res3, f, a, b);
            return new Tuple<Double, Double, Double>(res1, res2, res3);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_GaussKronrod", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_GaussKronrod(ref Double res1, ref Double res2, ref Double res3, cb1SDouble1S f, Double a, Double b);



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TanhSinh/*' />
        public static Tuple<Double, Double, Double, int> TanhSinh(cb1SDouble1S f, dynamic a, dynamic b, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return TanhSinh(f, dreal.t(a), dreal.t(b), dreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TanhSinh/*' />
        public static Tuple<Double, Double, Double, int> TanhSinh(cb1SDouble1S f, Double a, Double b, Double tol, uint max_refinements = 12)
        {
            Double res1 = 0, res2 = 0, res3 = 0;
            var levels = default(int);
            Lib_Double_TanhSinh(ref res1, ref res2, ref res3, ref levels, f, a, b);
            return new Tuple<Double, Double, Double, int>(res1, res2, res3, levels);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_TanhSinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_TanhSinh(ref Double res1, ref Double res2, ref Double res3, ref int levels, cb1SDouble1S f, Double a, Double b);




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SinhSinh/*' />
        public static Tuple<Double, Double, Double, int> SinhSinh(cb1SDouble1S f, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return SinhSinh(f, dreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SinhSinh/*' />
        public static Tuple<Double, Double, Double, int> SinhSinh(cb1SDouble1S f, Double tol, uint max_refinements = 12)
        {
            Double res1 = 0, res2 = 0, res3 = 0;
            var levels = default(int);
            Lib_Double_SinhSinh(ref res1, ref res2, ref res3, ref levels, f);
            return new Tuple<Double, Double, Double, int>(res1, res2, res3, levels);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_SinhSinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_SinhSinh(ref Double res1, ref Double res2, ref Double res3, ref int levels, cb1SDouble1S f);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExpSinh/*' />
        public static Tuple<Double, Double, Double, int> ExpSinh(cb1SDouble1S f, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return ExpSinh(f, dreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExpSinh/*' />
        public static Tuple<Double, Double, Double, int> ExpSinh(cb1SDouble1S f, Double tol, uint max_refinements = 12)
        {
            Double res1 = 0, res2 = 0, res3 = 0;
            var levels = default(int);
            Lib_Double_ExpSinh(ref res1, ref res2, ref res3, ref levels, f);
            return new Tuple<Double, Double, Double, int>(res1, res2, res3, levels);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_ExpSinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_ExpSinh(ref Double res1, ref Double res2, ref Double res3, ref int levels, cb1SDouble1S f);





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/OouraCos/*' />
        public static Tuple<Double, Double> Ooura_Cos(cb1SDouble1S f)
        {
            Double res1 = 0, res2 = 0;
            Lib_Double_Ooura_Cos(ref res1, ref res2, f);
            return new Tuple<Double, Double>(res1, res2);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_Ooura_Cos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_Ooura_Cos(ref Double res1, ref Double res2, cb1SDouble1S f);





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/OouraSin/*' />
        public static Tuple<Double, Double> Ooura_Sin(cb1SDouble1S f)
        {
            Double res1 = 0, res2 = 0;
            Lib_Double_Ooura_Sin(ref res1, ref res2, f);
            return new Tuple<Double, Double>(res1, res2);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_Ooura_Sin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_Ooura_Sin(ref Double res1, ref Double res2, cb1SDouble1S f);





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/OouraCos2/*' />
        public static Tuple<Double, Double> Ooura_Cos2(cb1SDouble1S f, Double omega)
        {
            Double res1 = 0, res2 = 0;
            Lib_Double_Ooura_Cos2(ref res1, ref res2, f, omega);
            return new Tuple<Double, Double>(res1, res2);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_Ooura_Cos2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_Ooura_Cos2(ref Double res1, ref Double res2, cb1SDouble1S f, Double omega);





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/OouraSin2/*' />
        public static Tuple<Double, Double> Ooura_Sin2(cb1SDouble1S f, Double omega)
        {
            Double res1 = 0, res2 = 0;
            Lib_Double_Ooura_Sin2(ref res1, ref res2, f, omega);
            return new Tuple<Double, Double>(res1, res2);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Double_Ooura_Sin2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Double_Ooura_Sin2(ref Double res1, ref Double res2, cb1SDouble1S f, Double omega);




        #endregion







        #region Boost Odeint




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RungeKutta4Const/*' />
        public static void RungeKutta4Const(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, Double StartTime, Double EndTime, Double dt)
        {
            var SOdeint1 = new SOdeintConst(1, F1, F2, matInput, StartTime, EndTime, dt);
            SOdeint1.Integrate();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RungeKutta4Const/*' />
        public static void RungeKutta4Const(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            RungeKutta4Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void CashKarp54Const(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, Double StartTime, Double EndTime, Double dt)
        {
            var SOdeint1 = new SOdeintConst(2, F1, F2, matInput, StartTime, EndTime, dt);
            SOdeint1.Integrate();
        }


        public static void CashKarp54Const(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            CashKarp54Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void DormandPrince5Const(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, Double StartTime, Double EndTime, Double dt)
        {
            var SOdeint1 = new SOdeintConst(3, F1, F2, matInput, StartTime, EndTime, dt);
            SOdeint1.Integrate();
        }


        public static void DormandPrince5Const(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            DormandPrince5Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void Fehlberg78Const(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, Double StartTime, Double EndTime, Double dt)
        {
            var SOdeint1 = new SOdeintConst(4, F1, F2, matInput, StartTime, EndTime, dt);
            SOdeint1.Integrate();
        }


        public static void Fehlberg78Const(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            Fehlberg78Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void AdamsBashforthMoultonConst(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, Double StartTime, Double EndTime, Double dt)
        {
            var SOdeint1 = new SOdeintConst(5, F1, F2, matInput, StartTime, EndTime, dt);
            SOdeint1.Integrate();
        }


        public static void AdamsBashforthMoultonConst(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            AdamsBashforthMoultonConst(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        internal class SOdeintConst
        {
            private int what_;
            private cbDouble1S2V F1_;
            private cbDouble1S1V F2_;
            private DoubleVec matInit_ = new DoubleVec();
            private DoubleVec matX = new DoubleVec();
            private DoubleVec matY = new DoubleVec();
            private Double StartTime_ = 0.0;
            private Double EndTime_ = 0.0;
            private Double dt_ = 0.0;


            public void funcptr1(IntPtr xPtr, IntPtr fxPtr, ref Double t)
            {
                IntPtr tempxPtr = matX.mpPtr;
                matX.mpPtr = xPtr;
                IntPtr tempyPtr = matY.mpPtr;
                matY.mpPtr = fxPtr;
                F1_(t, matX, matY);
                matX.mpPtr = tempxPtr;
                matY.mpPtr = tempyPtr;
            }

            public void funcptr2(IntPtr xPtr, ref Double t)
            {
                IntPtr tempxPtr = matX.mpPtr;
                matX.mpPtr = xPtr;
                F2_(t, matX);
                matX.mpPtr = tempxPtr;
            }



            internal SOdeintConst(int what, cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInit, Double StartTime, Double EndTime, Double dt)
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
                        FReal_Const_RungeKutta4(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 2:
                        FReal_Const_CashKarp54(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 3:
                        FReal_Const_Dopri5(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 4:
                        FReal_Const_Fehlberg78(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 5:
                        FReal_Const_AdamsBashforthMoulton(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    default:
                        Console.WriteLine("Not found");
                        break;
                }
            }
        }

        public static void FReal_Const_RungeKutta4(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, DoubleVec matX, Double StartTime, Double EndTime, Double dt)
        {
            Lib_FReal_Const_RungeKutta4(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Const_RungeKutta4", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Const_RungeKutta4(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, IntPtr MatrixPtr_source, ref Double StartTime, ref Double EndTime, ref Double dt);


        public static void FReal_Const_CashKarp54(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, DoubleVec matX, Double StartTime, Double EndTime, Double dt)
        {
            Lib_FReal_Const_CashKarp54(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Const_CashKarp54", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Const_CashKarp54(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, IntPtr MatrixPtr_source, ref Double StartTime, ref Double EndTime, ref Double dt);


        public static void FReal_Const_Dopri5(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, DoubleVec matX, Double StartTime, Double EndTime, Double dt)
        {
            Lib_FReal_Const_Dopri5(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Const_Dopri5", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Const_Dopri5(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, IntPtr MatrixPtr_source, ref Double StartTime, ref Double EndTime, ref Double dt);


        public static void FReal_Const_Fehlberg78(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, DoubleVec matX, Double StartTime, Double EndTime, Double dt)
        {
            Lib_FReal_Const_Fehlberg78(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Const_Fehlberg78", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Const_Fehlberg78(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, IntPtr MatrixPtr_source, ref Double StartTime, ref Double EndTime, ref Double dt);


        public static void FReal_Const_AdamsBashforthMoulton(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, DoubleVec matX, Double StartTime, Double EndTime, Double dt)
        {
            Lib_FReal_Const_AdamsBashforthMoulton(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Const_AdamsBashforthMoulton", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Const_AdamsBashforthMoulton(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, IntPtr MatrixPtr_source, ref Double StartTime, ref Double EndTime, ref Double dt);









        // ***********************************************************************************************************









        /// <include file="docs.xml" path='docs/members[@name="Boost"]/DormandPrince5Adaptive/*' />
        public static void DormandPrince5Adaptive(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, Double StartTime, Double EndTime, Double dt, Double epsabs, Double epsrel)
        {
            var SOdeint1 = new SOdeintAdaptiveDenseOutput(1, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            SOdeint1.Integrate();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/DormandPrince5Adaptive/*' />
        public static void DormandPrince5Adaptive(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            DormandPrince5Adaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void CashKarp54Adaptive(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, Double StartTime, Double EndTime, Double dt, Double epsabs, Double epsrel)
        {
            var SOdeint1 = new SOdeintAdaptiveDenseOutput(2, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            SOdeint1.Integrate();
        }


        public static void CashKarp54Adaptive(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            CashKarp54Adaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void Fehlberg78Adaptive(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, Double StartTime, Double EndTime, Double dt, Double epsabs, Double epsrel)
        {
            var SOdeint1 = new SOdeintAdaptiveDenseOutput(3, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            SOdeint1.Integrate();
        }


        public static void Fehlberg78Adaptive(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            Fehlberg78Adaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void BulirschStoerAdaptive(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, Double StartTime, Double EndTime, Double dt, Double epsabs, Double epsrel)
        {
            var SOdeint1 = new SOdeintAdaptiveDenseOutput(4, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            SOdeint1.Integrate();
        }


        public static void BulirschStoerAdaptive(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            BulirschStoerAdaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void DormandPrince5DenseOutput(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, Double StartTime, Double EndTime, Double dt, Double epsabs, Double epsrel)
        {
            var SOdeint1 = new SOdeintAdaptiveDenseOutput(5, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            SOdeint1.Integrate();
        }


        public static void DormandPrince5DenseOutput(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            DormandPrince5DenseOutput(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void BulirschStoerDenseOutput(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, Double StartTime, Double EndTime, Double dt, Double epsabs, Double epsrel)
        {
            var SOdeint1 = new SOdeintAdaptiveDenseOutput(6, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            SOdeint1.Integrate();
        }


        public static void BulirschStoerDenseOutput(cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            BulirschStoerDenseOutput(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        internal class SOdeintAdaptiveDenseOutput
        {
            int what_;
            private cbDouble1S2V F1_;
            private cbDouble1S1V F2_;
            private DoubleVec matInit_ = new DoubleVec();
            private DoubleVec matX = new DoubleVec();
            private DoubleVec matY = new DoubleVec();
            private Double StartTime_ = 0.0;
            private Double EndTime_ = 0.0;
            private Double dt_ = 0.0;
            private Double epsabs_ = 0.0;
            private Double epsrel_ = 0.0;
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr, ref Double t)
            {
                IntPtr tempxPtr = matX.mpPtr;
                matX.mpPtr = xPtr;
                IntPtr tempyPtr = matY.mpPtr;
                matY.mpPtr = fxPtr;
                F1_(t, matX, matY);
                matX.mpPtr = tempxPtr;
                matY.mpPtr = tempyPtr;
            }
            public void funcptr2(IntPtr xPtr, ref Double t)
            {
                IntPtr tempxPtr = matX.mpPtr;
                matX.mpPtr = xPtr;
                F2_(t, matX);
                matX.mpPtr = tempxPtr;
            }
            internal SOdeintAdaptiveDenseOutput(int what, cbDouble1S2V F1, cbDouble1S1V F2, DoubleVec matInit, Double StartTime, Double EndTime, Double dt, Double epsabs, Double epsrel)
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
                        FReal_Adaptive_RungeKuttaDopri5(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 2:
                        FReal_Adaptive_CashKarp54(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 3:
                        FReal_Adaptive_Fehlberg78(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 4:
                        FReal_Adaptive_BulirschStoer(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 5:
                        FReal_DenseOutput_Dopri5(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 6:
                        FReal_DenseOutput_BulirschStoer(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    default:
                        Console.WriteLine("Not found");
                        break;
                }
            }
        }
        public static void FReal_Adaptive_RungeKuttaDopri5(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, DoubleVec matX, Double StartTime, Double EndTime, Double dt, Double epsabs, Double epsrel)
        {
            Lib_FReal_Adaptive_Dopri5(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt, ref epsabs, ref epsrel);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Adaptive_Dopri5", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Adaptive_Dopri5(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, IntPtr MatrixPtr_source, ref Double StartTime, ref Double EndTime, ref Double dt, ref Double epsabs, ref Double epsrel);


        public static void FReal_Adaptive_CashKarp54(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, DoubleVec matX, Double StartTime, Double EndTime, Double dt, Double epsabs, Double epsrel)
        {
            Lib_FReal_Adaptive_CashKarp54(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt, ref epsabs, ref epsrel);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Adaptive_CashKarp54", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Adaptive_CashKarp54(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, IntPtr MatrixPtr_source, ref Double StartTime, ref Double EndTime, ref Double dt, ref Double epsabs, ref Double epsrel);


        public static void FReal_Adaptive_Fehlberg78(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, DoubleVec matX, Double StartTime, Double EndTime, Double dt, Double epsabs, Double epsrel)
        {
            Lib_FReal_Adaptive_Fehlberg78(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt, ref epsabs, ref epsrel);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Adaptive_Fehlberg78", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Adaptive_Fehlberg78(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, IntPtr MatrixPtr_source, ref Double StartTime, ref Double EndTime, ref Double dt, ref Double epsabs, ref Double epsrel);


        public static void FReal_Adaptive_BulirschStoer(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, DoubleVec matX, Double StartTime, Double EndTime, Double dt, Double epsabs, Double epsrel)
        {
            Lib_FReal_Adaptive_BulirschStoer(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt, ref epsabs, ref epsrel);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_Adaptive_BulirschStoer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_Adaptive_BulirschStoer(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, IntPtr MatrixPtr_source, ref Double StartTime, ref Double EndTime, ref Double dt, ref Double epsabs, ref Double epsrel);


        public static void FReal_DenseOutput_Dopri5(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, DoubleVec matX, Double StartTime, Double EndTime, Double dt, Double epsabs, Double epsrel)
        {
            Lib_FReal_DenseOutput_Dopri5(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt, ref epsabs, ref epsrel);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_DenseOutput_Dopri5", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_DenseOutput_Dopri5(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, IntPtr MatrixPtr_source, ref Double StartTime, ref Double EndTime, ref Double dt, ref Double epsabs, ref Double epsrel);


        public static void FReal_DenseOutput_BulirschStoer(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, DoubleVec matX, Double StartTime, Double EndTime, Double dt, Double epsabs, Double epsrel)
        {
            Lib_FReal_DenseOutput_BulirschStoer(F1, F2, matX.mpPtr, ref StartTime, ref EndTime, ref dt, ref epsabs, ref epsrel);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_FReal_DenseOutput_BulirschStoer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_FReal_DenseOutput_BulirschStoer(cb2Ptr1RefDouble F1, cb1Ptr1RefDouble F2, IntPtr MatrixPtr_source, ref Double StartTime, ref Double EndTime, ref Double dt, ref Double epsabs, ref Double epsrel);











        #endregion





        #region Boost/Eigen calculus


        public static DoubleMat PowellHybrd(cbDouble2M F1, cbDouble2M F2, DoubleMat matInput)
        {
            var DPowellHybrd1 = new DPowellHybrd(F1, F2, matInput);
            var matX = DPowellHybrd1.Solve();
            return matX;
        }
        internal class DPowellHybrd
        {
            private cbDouble2M F1_;
            private cbDouble2M F2_;
            private DoubleMat matX1 = new DoubleMat();
            private DoubleMat matY1 = new DoubleMat();
            private DoubleMat matX2 = new DoubleMat();
            private DoubleMat matY2 = new DoubleMat();
            private DoubleMat matInput_ = new DoubleMat();
            private DoubleMat matX = new DoubleMat();
            private DoubleMat matFvec = new DoubleMat();
            private DoubleMat matFjac = new DoubleMat();
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
            internal DPowellHybrd(cbDouble2M F1, cbDouble2M F2, DoubleMat matInput)
            {
                int n = matInput.rows;
                matX.Resize(n, 1);
                matFvec.Resize(n, 1);
                matFjac.Resize(n, n);
                matInput_ = matInput; // Shallow copy
                F1_ = F1;
                F2_ = F2;
            }
            internal DoubleMat Solve()
            {
                dlib.testHybrj_ext(funcptr1, funcptr2, matX, matFvec, matFjac, matInput_);
                return matX;
            }
        }




        public static DoubleMat Levenberg(cbDouble2M F1, cbDouble2M F2, DoubleMat matInput, int n, int m)
        {
            var DLevenberg1 = new DLevenberg(F1, F2, matInput, n, m);
            var matX = DLevenberg1.Solve();
            return matX;
        }
        internal class DLevenberg
        {
            private cbDouble2M F1_;
            private cbDouble2M F2_;
            private DoubleMat matX1 = new DoubleMat();
            private DoubleMat matY1 = new DoubleMat();
            private DoubleMat matX2 = new DoubleMat();
            private DoubleMat matY2 = new DoubleMat();
            private DoubleMat matInput_ = new DoubleMat();
            private DoubleMat matX = new DoubleMat();
            private DoubleMat matFvec = new DoubleMat();
            private DoubleMat matFjac = new DoubleMat();
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
            internal DLevenberg(cbDouble2M F1, cbDouble2M F2, DoubleMat matInput, int n, int m)
            {
                matX.Resize(n, 1);
                matFvec.Resize(m, 1);
                matFjac.Resize(n, n);
                matInput_ = matInput; // Shallow copy
                F1_ = F1;
                F2_ = F2;
            }
            internal DoubleMat Solve()
            {
                dlib.testLmder_ext(funcptr1, funcptr2, matX, matFvec, matFjac, matInput_);
                return matX;
            }
        }









        #endregion






        #region Boost/CppOptLib


        public static DoubleVec NelderMeadSolver(cb1SDouble1V F1, DoubleVec matInput)
        {
            var DSolver11 = new DOptSolver1(constants.mp_nelder_mead_solver, F1, matInput);
            return DSolver11.Solve();
        }

        public static DoubleVec CMAesSolver(cb1SDouble1V F1, DoubleVec matInput)
        {
            var DSolver11 = new DOptSolver1(constants.mp_cma_es_solver, F1, matInput);
            return DSolver11.Solve();
        }

        internal class DOptSolver1
        {
            private int what_;
            private cb1SDouble1V F1_;
            private DoubleVec matX1 = new DoubleVec();
            private DoubleVec matY1 = new DoubleVec();
            private DoubleVec matX_ = new DoubleVec();
            private DoubleVec matNorm_ = new DoubleVec();
            private DoubleVec X_ = new DoubleVec();
            private DoubleVec FX_ = new DoubleVec();
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
            internal DOptSolver1(int what, cb1SDouble1V F1, DoubleVec X)
            {
                what_ = what;
                matX_ = new DoubleVec(X.Size);
                X_ = X; // Shallow copy
                F1_ = F1;
            }
            internal DoubleVec Solve()
            {
                Lib_Eigen_FReal_Real_CppOptLib1(what_, funcptr1, matX_.mpPtr, matNorm_.mpPtr, X_.mpPtr, FX_.mpPtr);
                return matX_;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Real_CppOptLib1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Real_CppOptLib1(int what, cbProc2Ptr F1, IntPtr matXPtr, IntPtr matNormPtr, IntPtr xPtr, IntPtr fxPtr);


        public static DoubleVec LbfgsSolver(cb1SDouble1V F1, cbDouble2V F2, DoubleVec matInput)
        {
            var DSolver21 = new DOptSolver2(constants.mp_lbfgs_solver, F1, F2, matInput);
            return DSolver21.Solve();
        }

        public static DoubleVec BfgsSolver(cb1SDouble1V F1, cbDouble2V F2, DoubleVec matInput)
        {
            var DSolver21 = new DOptSolver2(constants.mp_bfgs_solver, F1, F2, matInput);
            return DSolver21.Solve();
        }

        public static DoubleVec GradientDescentSolver(cb1SDouble1V F1, cbDouble2V F2, DoubleVec matInput)
        {
            var DSolver21 = new DOptSolver2(constants.mp_gradient_descent_solver, F1, F2, matInput);
            return DSolver21.Solve();
        }

        public static DoubleVec ConjugatedGradientDescentSolver(cb1SDouble1V F1, cbDouble2V F2, DoubleVec matInput)
        {
            var DSolver21 = new DOptSolver2(constants.mp_conjugated_gradient_descent_solver, F1, F2, matInput);
            return DSolver21.Solve();
        }

        internal class DOptSolver2
        {
            private int what_;
            private cb1SDouble1V F1_;
            private cbDouble2V F2_;
            private DoubleVec matX1 = new DoubleVec();
            private DoubleVec matY1 = new DoubleVec();
            private DoubleVec matX2 = new DoubleVec();
            private DoubleVec matY2 = new DoubleVec();
            private DoubleVec matX_ = new DoubleVec();
            private DoubleVec matGrad_ = new DoubleVec();
            private DoubleVec matNorm_ = new DoubleVec();
            private DoubleVec X_ = new DoubleVec();
            private DoubleVec FX_ = new DoubleVec();
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
            internal DOptSolver2(int what, cb1SDouble1V F1, cbDouble2V F2, DoubleVec X)
            {
                what_ = what;
                matX_ = new DoubleVec(X.Size);
                matGrad_ = new DoubleVec(X.Size);
                X_ = X; // Shallow copy
                F1_ = F1;
                F2_ = F2;
            }
            internal DoubleVec Solve()
            {
                Lib_Eigen_FReal_Real_CppOptLib2(what_, funcptr1, funcptr2, matX_.mpPtr, matGrad_.mpPtr, matNorm_.mpPtr, X_.mpPtr, FX_.mpPtr);
                return matX_;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Real_CppOptLib2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Real_CppOptLib2(int what, cbProc2Ptr F1, cbProc2Ptr F2, IntPtr matXPtr, IntPtr matGradPtr, IntPtr matNormPtr, IntPtr xPtr, IntPtr fxPtr);



        public static DoubleVec NewtonDescentSolver(cb1SDouble1V F1, cbDouble2V F2, cbDouble1V1M F3, DoubleVec matInput)
        {
            var DSolver31 = new DOptSolver3(constants.mp_newton_descent_solver, F1, F2, F3, matInput);
            return DSolver31.Solve();
        }

        internal class DOptSolver3
        {
            private int what_;
            private cb1SDouble1V F1_;
            private cbDouble2V F2_;
            private cbDouble1V1M F3_;
            private DoubleVec matX1 = new DoubleVec();
            private DoubleVec matY1 = new DoubleVec();
            private DoubleVec matX2 = new DoubleVec();
            private DoubleVec matY2 = new DoubleVec();
            private DoubleVec matX3 = new DoubleVec();
            private DoubleMat matY3 = new DoubleMat();
            private DoubleVec matX_ = new DoubleVec();
            private DoubleVec matGrad_ = new DoubleVec();
            private DoubleVec matNorm_ = new DoubleVec();
            private DoubleMat matHessian_ = new DoubleMat();
            private DoubleVec X_ = new DoubleVec();
            private DoubleVec FX_ = new DoubleVec();
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
            internal DOptSolver3(int what, cb1SDouble1V F1, cbDouble2V F2, cbDouble1V1M F3, DoubleVec X)
            {
                what_ = what;
                matX_ = new DoubleVec(X.Size);
                matGrad_ = new DoubleVec(X.Size);
                matHessian_.Resize(X.Size, X.Size);
                X_ = X; // Shallow copy
                F1_ = F1;
                F2_ = F2;
                F3_ = F3;
            }
            internal DoubleVec Solve()
            {
                Lib_Eigen_FReal_Real_CppOptLib3(what_, funcptr1, funcptr2, funcptr3, matX_.mpPtr, matHessian_.mpPtr, matGrad_.mpPtr, matNorm_.mpPtr, X_.mpPtr, FX_.mpPtr);
                return matX_;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_FReal_Real_CppOptLib3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_FReal_Real_CppOptLib3(int what, cbProc2Ptr F1, cbProc2Ptr F2, cbProc2Ptr F3, IntPtr matXPtr, IntPtr matHessianPtr, IntPtr matGradPtr, IntPtr matNormPtr, IntPtr xPtr, IntPtr fxPtr);



        #endregion








        #region Matrix Creation




        /// <summary>
        /// Converts from a real scalar of type dreal
        /// </summary>
        public static DoubleMat mat_t(Double x)
        {
            var matA = new DoubleMat();
            matA[0, 0] = x;
            return matA;
        }


        /* *********************** 

        public static ComplexMat mat_cplx_t(DoubleMat matA)
        {
            return dcplx.mat_t(matA);
        }


        public static ComplexMat mat_cplx_zeros(int n, int m)
        {
            return dcplx.mat_zeros(n, m);
        }

        /* *********************** */




        public static DoubleMat mat_zeros(int n, int m)
        {
            var resout = new DoubleMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setZero, n, m);
            return resout;
        }



        public static DoubleMat mat_ones(int n, int m)
        {
            var resout = new DoubleMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setOnes, n, m);
            return resout;
        }



        public static DoubleMat mat_identity(int n, int m)
        {
            var resout = new DoubleMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setIdentity, n, m);
            return resout;
        }



        public static DoubleMat mat_random(int n, int m)
        {
            var resout = new DoubleMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandom_nm, n, m);
            return resout;
        }



        public static DoubleMat mat_random_symmetric(int n)
        {
            var resout = new DoubleMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandomSymmetric, n, n);
            return resout;
        }



        public static DoubleMat mat_random_selfadjoint(int n)
        {
            var resout = new DoubleMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandomSA, n, n);
            return resout;
        }



        public static DoubleMat mat_random_selfadjoint_posdef(int n)
        {
            var resout = new DoubleMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandomSAPosDef, n, n);
            return resout;
        }



        public static DoubleMat mat_fill_linear(int n, int m)
        {
            var resout = new DoubleMat();
            dlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_FillLinear, n, m);
            return resout;
        }



        #endregion








    }








}