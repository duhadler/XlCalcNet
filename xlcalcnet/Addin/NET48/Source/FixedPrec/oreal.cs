using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Numerics;


namespace FixedPrecNet
{

    public delegate Octuple cb1SOctuple1S(Octuple x);

    public delegate void cbOctuple1S1V(Octuple t, OctupleVec matX);

    public delegate void cbOctuple1S2V(Octuple t, OctupleVec matX, OctupleVec matY);


    public delegate void cbOctuple2M(OctupleMat matX, OctupleMat matY);


    public delegate Octuple cb1SOctuple1V(OctupleVec x);

    public delegate void cbOctuple2V(OctupleVec x, OctupleVec y);

    public delegate void cbOctuple1V1M(OctupleVec x, OctupleMat y);





    /// <summary>
    /// Represents a octuple precision binary floating point number
    /// </summary>
    public partial class Octuple
    {

        #region Init

        public IntPtr mpPtr = IntPtr.Zero;

        private void Init()
        {
            xcn.Init();
            mpPtr = Lib_OReal_Init_Func();
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_OReal_Init_Func();


        ~Octuple()
        {
            Lib_OReal_Clear(mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Clear(IntPtr x);

        #endregion


        #region Conversions

        public Octuple()
        {
            Init();
        }

        public override string ToString()
        {
            if (0 == (Lib_OReal_Iszero(mpPtr)))
            {
                //Console.WriteLine("Non-zero");
                return Get_OReal_Str(mpPtr);
            }
            else
            {
                //Console.WriteLine("zero");
                return "0";
            }
            //return Get_OReal_Str(mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Iszero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Iszero(IntPtr x);




        internal string Get_OReal_Str(IntPtr mpPtr)
        {
            int StrSize = 128;
            var sb = new StringBuilder(StrSize + 10);
            Lib_OReal_Get_Str(sb, mpPtr);
            return (sb.ToString()).Trim();
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Get_Str", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Get_Str(StringBuilder sb, IntPtr in1);


        public string __str__()
        {
            return ToString();
        }


        public string __repr__()
        {
            return "Octuple('" + ToString() + "')";
        }


        //public override dynamic Ctx
        //{
        //    get { return new oreal(); }
        //}




        #endregion


        #region Arithmetic operators







        public static bool operator >=(Octuple x, dynamic y)
        {
            return x >= oreal.t(y);
        }
        public static bool operator <=(Octuple x, dynamic y)
        {
            return x <= oreal.t(y);
        }

        public static bool operator >=(dynamic x, Octuple y)
        {
            return oreal.t(x) >= y;
        }
        public static bool operator <=(dynamic x, Octuple y)
        {
            return oreal.t(x) <= y;
        }


        public static bool operator >(Octuple x, dynamic y)
        {
            return x > oreal.t(y);
        }
        public static bool operator <(Octuple x, dynamic y)
        {
            return x < oreal.t(y);
        }


        public static bool operator >(dynamic x, Octuple y)
        {
            return oreal.t(x) > y;
        }
        public static bool operator <(dynamic x, Octuple y)
        {
            return oreal.t(x) < y;
        }



        public static bool operator ==(Octuple x, dynamic y)
        {
            return x == oreal.t(y);
        }
        public static bool operator !=(Octuple x, dynamic y)
        {
            return x != oreal.t(y);
        }

        public static bool operator ==(dynamic x, Octuple y)
        {
            return oreal.t(x) == y;
        }
        public static bool operator !=(dynamic x, Octuple y)
        {
            return oreal.t(x) != y;
        }




        public static bool operator ==(Octuple x, Octuple y)
        {
            return 0 != Lib_OReal_EQ(x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_EQ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_EQ(IntPtr x, IntPtr y);

        public static bool operator !=(Octuple x, Octuple y)
        {
            return 0 != (Lib_OReal_NE(x.mpPtr, y.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_NE", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_NE(IntPtr x, IntPtr y);


        public static bool operator <=(Octuple x, Octuple y)
        {
            return 0 != (Lib_OReal_LE(x.mpPtr, y.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LE", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_LE(IntPtr x, IntPtr y);

        public static bool operator >(Octuple x, Octuple y)
        {
            return 0 != (Lib_OReal_GT(x.mpPtr, y.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GT", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_GT(IntPtr x, IntPtr y);


        public static bool operator >=(Octuple x, Octuple y)
        {
            return 0 != (Lib_OReal_GE(x.mpPtr, y.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GE", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_GE(IntPtr x, IntPtr y);

        public static bool operator <(Octuple x, Octuple y)
        {
            return 0 != (Lib_OReal_LT(x.mpPtr, y.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LT", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_LT(IntPtr x, IntPtr y);












        public static Octuple operator +(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Set(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Set", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Set(IntPtr res, IntPtr x);


        public static Octuple operator -(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Neg(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Neg", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Neg(IntPtr res, IntPtr x);













        public static Octuple operator +(Octuple x, dynamic i)
        {
            return x + oreal.t(i);
        }

        public static Octuple operator +(dynamic i, Octuple x)
        {
            return oreal.t(i) + x;
        }



        public static OctupleC operator +(Octuple x, OctupleC y)
        {
            var res = new OctupleC();
            Lib_OCplx_Add_OReal(res.mpPtr, y.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Add_OReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Add_OReal(IntPtr res, IntPtr y, IntPtr x);


        public static Octuple operator +(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Add(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Add(IntPtr res, IntPtr x, IntPtr y);


        public static OctupleMat operator +(Octuple m2, OctupleMat M1)
        {
            var Res = new OctupleMat();
            var t = oreal.mat_t(m2);
            olib.Lib_Eigen_OReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }






        public static Octuple operator -(Octuple x, dynamic y)
        {
            return x - oreal.t(y);
        }

        public static Octuple operator -(dynamic x, Octuple y)
        {
            return oreal.t(x) - y;
        }

        public static OctupleC operator -(Octuple x, OctupleC y)
        {
            var res = new OctupleC();
            Lib_OCplx_OReal_Sub(res.mpPtr, y.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_OReal_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_OReal_Sub(IntPtr res, IntPtr y, IntPtr x);


        public static Octuple operator -(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Sub(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Sub(IntPtr res, IntPtr x, IntPtr y);


        public static OctupleMat operator -(Octuple m2, OctupleMat M1)
        {
            var Res = new OctupleMat();
            var t = oreal.mat_t(m2);
            olib.Lib_Eigen_OReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, t.mpPtr);
            return -Res;
        }







        public static Octuple operator *(Octuple x, dynamic y)
        {
            return x * oreal.t(y);
        }

        public static Octuple operator *(dynamic x, Octuple y)
        {
            return oreal.t(x) * y;
        }




        public static OctupleC operator *(Octuple x, OctupleC y)
        {
            var res = new OctupleC();
            Lib_OCplx_Mul_OReal(res.mpPtr, y.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Mul_OReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Mul_OReal(IntPtr res, IntPtr y, IntPtr x);


        public static Octuple operator *(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Mul(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Mul", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Mul(IntPtr res, IntPtr x, IntPtr y);


        public static OctupleMat operator *(Octuple m2, OctupleMat M1)
        {
            var Res = new OctupleMat();
            var t = oreal.mat_t(m2);
            olib.Lib_Eigen_OReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }





        public static Octuple operator /(Octuple x, dynamic y)
        {
            return x / oreal.t(y);
        }

        public static Octuple operator /(dynamic x, Octuple y)
        {
            return oreal.t(x) / y;
        }



        public static OctupleC operator /(Octuple x, OctupleC y)
        {
            var res = new OctupleC();
            Lib_OCplx_OReal_Div(res.mpPtr, y.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_OReal_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_OReal_Div(IntPtr res, IntPtr y, IntPtr x);


        public static Octuple operator /(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Div(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Div(IntPtr res, IntPtr x, IntPtr y);




        #endregion

    }



    public class OctupleVec
    {

        public IntPtr mpPtr = IntPtr.Zero;

        public OctupleVec()
        {
            xcn.Init();
            mpPtr = Lib_Eigen_OReal_Init_Func(constants.mp_eigen, constants.mp_real);
        }

        public OctupleVec(int N)
        {
            xcn.Init();
            mpPtr = Lib_Eigen_OReal_Init_Func(constants.mp_eigen, constants.mp_real);
            Lib_Eigen_OReal_SetSpecialValue(constants.mp_eigen, constants.mp_real, mpPtr, constants.mp_Resize, N, 1);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_OReal_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_Eigen_OReal_Init_Func(int mpCat, int mpType);
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_OReal_SetSpecialValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_OReal_SetSpecialValue(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int m, int n);


        ~OctupleVec()
        {
            Lib_Eigen_OReal_Clear(constants.mp_eigen, constants.mp_real, mpPtr);
        }

        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_OReal_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_OReal_Clear(int mpCat, int mpType, IntPtr AnyPtr);


        public int Size
        {
            get
            {
                return Lib_Eigen_OReal_GetInfo(constants.mp_eigen, constants.mp_real, constants.mp_const_size, mpPtr);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_OReal_GetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_Eigen_OReal_GetInfo(int mpCat, int mpType, int what, IntPtr MatrixPtr_source);


        public Octuple this[int row_i]
        {
            get
            {
                var result = new Octuple();
                Eigen_OReal_GetCoeff(result.mpPtr, row_i, 0, mpPtr);
                return result;
            }

            set
            {
                Eigen_OReal_SetCoeff(mpPtr, value.mpPtr, row_i, 0);
            }

        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_OReal_GetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_OReal_GetCoeff(IntPtr result, int row, int col, IntPtr MatrixPtr_source);

        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_OReal_SetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_OReal_SetCoeff(IntPtr MatrixPtr_result, IntPtr in1, int row, int col);

    }







    /// <summary>
    /// Provides numerical functions in octuple precision, based on Boost Math/Multiprecision
    /// </summary>
    public partial class oreal
    {




        public static String fmt(Octuple x)
        {
            string s = " " + x.ToString();
            return s;
        }


        public static String fmt(dynamic x)
        {
            return fmt(t(x));
        }



        #region VecParams


        public static OctupleVec VecParams(params dynamic[] args)
        {
            int N = args.Length;
            var matX3 = new OctupleVec(N);
            for (int i = 0; i < N; i++)
                matX3[i] = t(args[i]);
            return matX3;
        }


        #endregion





        #region Basic floating point functions



        #region General

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/name/*' />
        public static String name
        {
            get { return "oreal"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  oreal"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/prec/*' />
        public static Int32 prec
        {
            get { return 237; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/isrealctx/*' />
        public static bool isrealctx
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
        public static oreal realctx
        {
            get { return new oreal(); }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static ocplx cplxctx
        {
            get { return new ocplx(); }
        }


        #endregion



        #region Conversions




        // Note: the conversion from dynamic needs to be at the top of this list

        /// <summary>
        /// Returns a new Octuple using a dynamic (an object whose operations will be resolved at runtime) as input
        /// </summary>
        public static Octuple t(dynamic x)
        {
            //MessageBox.Show("In Octuple t(dynamic i)");
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
        /// Returns a new Octuple using an Octuple as input
        /// </summary>
        public static Octuple t(Octuple x)
        {
            return +x;
        }



        /// <summary>
        /// Returns a new Octuple using an Quadruple as input
        /// </summary>
        public static Octuple t(Quadruple x)
        {
            var res = new Octuple();
            string s = x.ToString();
            Lib_OReal_Set_Str(res.mpPtr, s);
            return res;
        }


        /// <summary>
        /// Returns a new Octuple using an Extended as input
        /// </summary>
        public static Octuple t(Extended x)
        {
            var res = new Octuple();
            Lib_OReal_Set_LD(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Set_LD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Set_LD(IntPtr res, IntPtr x);




        internal static Octuple TDS(Double d)
        {
            var res = new Octuple();
            string s = d.ToString("G14", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
            Lib_OReal_Set_Str(res.mpPtr, s);
            return res;
        }

        /// <summary>
        /// Returns a new Octuple using a Double (System.Double) as input
        /// </summary>
        public static Octuple t(Double d)
        {
            if ((xcn.UseRawDouble) || (xcn.IsExactDouble(d)))
            {
                var res = new Octuple();
                Lib_OReal_Set_D(res.mpPtr, d);
                return res;
            }
            else
            {
                return TDS(d);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Set_D", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Set_D(IntPtr mpfr_out1, Double d);




        /// <summary>
        /// Returns a new Octuple using a Single (System.Single) as input
        /// </summary>
        public static Octuple t(Single x)
        {
            var res = new Octuple();
            Lib_OReal_Set_S(res.mpPtr, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Set_S", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Set_S(IntPtr res, ref Single x);




        /// <summary>
        /// Returns a new Octuple using a signed 32 bit integer (System.Int32) as input
        /// </summary>
        public static Octuple t(Int32 si)
        {
            var res = new Octuple();
            Lib_OReal_Set_Si(res.mpPtr, si);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Set_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Set_Si(IntPtr res, Int32 si);



        /// <summary>
        /// Returns a new Octuple using an unsigned 32 bit integer (System.UInt32) as input
        /// </summary>
        public static Octuple t(UInt32 ui)
        {
            var res = new Octuple();
            Lib_OReal_Set_Ui(res.mpPtr, ui);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Set_Ui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Set_Ui(IntPtr res, UInt32 ui);



        /// <summary>
        /// Returns a new Octuple using a signed 64 bit integer (System.Int64) as input
        /// </summary>
        public static Octuple t(Int64 si64)
        {
            var res = new Octuple();
            Lib_OReal_Set_Si64(res.mpPtr, si64);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Set_Si64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Set_Si64(IntPtr res, Int64 si64);


        /// <summary>
        /// Returns a new Octuple using an unsigned 64 bit integer (System.UInt64) as input
        /// </summary>
        public static Octuple t(UInt64 ui64)
        {
            var res = new Octuple();
            Lib_OReal_Set_Ui64(res.mpPtr, ui64);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Set_Ui64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Set_Ui64(IntPtr res, UInt64 ui64);


        /// <summary>
        /// Returns a new Octuple using an arbitrary precision integer (System.Numerics.BigInteger) as input
        /// </summary>
        public static Octuple t(BigInteger i)
        {
            var res = new Octuple();
            string s = i.ToString();
            Lib_OReal_Set_Str(res.mpPtr, s);
            return res;
        }


        /// <summary>
        /// Returns a new Octuple using a decimal number (System.Decimal) as input
        /// </summary>
        public static Octuple t(Decimal dec)
        {
            var res = new Octuple();
            string s = dec.ToString();
            Lib_OReal_Set_Str(res.mpPtr, s);
            return res;
        }



        /// <summary>
        /// Returns a new Octuple using a string (System.String) as input
        /// </summary>
        public static Octuple t(String s)
        {
            //Console.WriteLine("s: {0}", s);   // Crash at infinity
            var res = new Octuple();
            Lib_OReal_Set_Str(res.mpPtr, s);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Set_Str", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Set_Str(IntPtr res, string s);






        #endregion




        #region Basic Arithmetic


        public static Octuple add(Octuple x, Octuple y)
        {
            return x + y;
        }
        public static Octuple add(dynamic x, dynamic y)
        {
            return t(x) + t(y);
        }

        /// <summary>
        /// Return the sum of x and y
        /// </summary>
        public static void rawadd(Octuple res, Octuple x, Octuple y)
        {
            Lib_OReal_Add(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Add(IntPtr res, IntPtr x, IntPtr y);



        public static Octuple subtract(Octuple x, Octuple y)
        {
            return x - y;
        }
        public static Octuple subtract(dynamic x, dynamic y)
        {
            return t(x) - t(y);
        }

        /// <summary>
        /// Return the difference of x and y
        /// </summary>
        public static void rawsub(Octuple res, Octuple x, Octuple y)
        {
            Lib_OReal_Sub(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Sub(IntPtr res, IntPtr x, IntPtr y);



        public static Octuple multiply(Octuple x, Octuple y)
        {
            return x * y;
        }
        public static Octuple multiply(dynamic x, dynamic y)
        {
            return t(x) * t(y);
        }

        /// <summary>
        /// Return the product of x and y
        /// </summary>
        public static void rawmul(Octuple res, Octuple x, Octuple y)
        {
            Lib_OReal_Mul(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Mul", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Mul(IntPtr res, IntPtr x, IntPtr y);



        public static Octuple divide(Octuple x, Octuple y)
        {
            return x / y;
        }
        public static Octuple divide(dynamic x, dynamic y)
        {
            return t(x) / t(y);
        }

        /// <summary>
        /// Return the quotient of x and y
        /// </summary>
        public static void rawdiv(Octuple res, Octuple x, Octuple y)
        {
            Lib_OReal_Div(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Div(IntPtr res, IntPtr x, IntPtr y);



        #endregion



        #region General functions for real numbers


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fma/*' />
        public static Octuple fma(Octuple x, Octuple y, Octuple z)
        {
            var res = new Octuple();
            Lib_OReal_Fma(res.mpPtr, x.mpPtr, y.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Fma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Fma(IntPtr res, IntPtr x, IntPtr y, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fma/*' />
        public static Octuple fma(dynamic x, dynamic y, dynamic z)
        {
            return fma(oreal.t(x), oreal.t(y), oreal.t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmax/*' />
        public static Octuple fmax(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Fmax(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Fmax", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Fmax(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmax/*' />
        public static Octuple fmax(dynamic x, dynamic y)
        {
            return fmax(oreal.t(x), oreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmin/*' />
        public static Octuple fmin(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Fmin(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Fmin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Fmin(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmin/*' />
        public static Octuple fmin(dynamic x, dynamic y)
        {
            return fmin(oreal.t(x), oreal.t(y));
        }


        #endregion



        #region Machine constants


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/zero/*' />
        public static Octuple zero()
        {
            var res = new Octuple();
            Lib_OReal_Zero(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Zero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Zero(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/negzero/*' />
        public static Octuple negzero()
        {
            var res = new Octuple();
            Lib_OReal_NegZero(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_NegZero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_NegZero(IntPtr res);



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/one/*' />
        public static Octuple one()
        {
            var res = new Octuple();
            Lib_OReal_One(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_One", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_One(IntPtr res);




        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/onej/*' />
        public static OctupleC onej()
        {
            return ocplx.t(0, 1);
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isposinf/*' />
        public static Octuple inf()
        {
            var res = new Octuple();
            Lib_OReal_Inf(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Inf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Inf(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/neginf/*' />
        public static Octuple neginf()
        {
            var res = new Octuple();
            Lib_OReal_NegInf(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_NegInf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_NegInf(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/nan/*' />
        public static Octuple nan()
        {
            var res = new Octuple();
            Lib_OReal_Nan(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Nan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Nan(IntPtr res);



        #endregion



        #region Properties of numbers


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/signbit/*' />
        public static int signbit(Octuple x)
        {
            return Lib_OReal_Signbit(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Signbit", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Signbit(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/signbit/*' />
        public static int signbit(dynamic x)
        {
            return signbit(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isfinite/*' />
        public static bool isfinite(Octuple x)
        {
            return 0 != Lib_OReal_Finite(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Finite", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Finite(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isfinite/*' />
        public static bool isfinite(dynamic x)
        {
            return isfinite(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isinf/*' />
        public static bool isinf(Octuple x)
        {
            return 0 != (Lib_OReal_Isinf(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Isinf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Isinf(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isinf/*' />
        public static bool isinf(dynamic x)
        {
            return isinf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isposinf/*' />
        public static bool isposinf(Octuple x)
        {
            return 0 != (Lib_OReal_Isposinf(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Isposinf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Isposinf(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isposinf/*' />
        public static bool isposinf(dynamic x)
        {
            return isposinf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isneginf/*' />
        public static bool isneginf(Octuple x)
        {
            return 0 != (Lib_OReal_Isneginf(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Isneginf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Isneginf(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isneginf/*' />
        public static bool isneginf(dynamic x)
        {
            return isneginf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnan/*' />
        public static bool isnan(Octuple x)
        {
            return 0 != (Lib_OReal_Isnan(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Isnan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Isnan(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isnan/*' />
        public static bool isnan(dynamic x)
        {
            return isnan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/iszero/*' />
        public static bool iszero(Octuple x)
        {
            return 0 != (Lib_OReal_Iszero(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Iszero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Iszero(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/iszero/*' />
        public static bool iszero(dynamic x)
        {
            return iszero(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/IsNegativeZero/*' />
        public static bool IsNegativeZero(Octuple x)
        {
            return 0 != (Lib_OReal_Isnegzero(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Isnegzero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Isnegzero(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/IsNegativeZero/*' />
        public static bool IsNegativeZero(dynamic x)
        {
            return IsNegativeZero(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isone/*' />
        public static bool isone(Octuple x)
        {
            return 0 != (Lib_OReal_Isone(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Isone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Isone(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isone/*' />
        public static bool isone(dynamic x)
        {
            return isone(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isinteger/*' />
        public static bool isinteger(Octuple x)
        {
            return 0 != (Lib_OReal_Isinteger(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Isinteger", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Isinteger(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isinteger/*' />
        public static bool isinteger(dynamic x)
        {
            return isinteger(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnumber/*' />
        public static bool isnumber(Octuple x)
        {
            return 0 != (Lib_OReal_Isnumber(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Isnumber", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Isnumber(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isnumber/*' />
        public static bool isnumber(dynamic x)
        {
            return isnumber(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isregular/*' />
        public static bool isregular(Octuple x)
        {
            return 0 != (Lib_OReal_Isregular(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Isregular", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Isregular(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isregular/*' />
        public static bool isregular(dynamic x)
        {
            return isregular(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnormal/*' />
        public static bool isnormal(Octuple x)
        {
            return 0 != (Lib_OReal_Isnormal(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Isnormal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Isnormal(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isnormal/*' />
        public static bool isnormal(dynamic x)
        {
            return isnormal(t(x));
        }



        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/IsSubnormal/*' />
        //public static bool IsSubnormal(Octuple x)
        //{
        //    return 0 != (Lib_OReal_Issubnormal(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Issubnormal", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_OReal_Issubnormal(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/IsSubnormal/*' />
        //public static bool IsSubnormal(dynamic x)
        //{
        //    return IsSubnormal(t(x));
        //}



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isunordered/*' />
        public static bool isunordered(Octuple x, Octuple y)
        {
            return 0 != (Lib_OReal_Isunordered(x.mpPtr, y.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Isunordered", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_Isunordered(IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isunordered/*' />
        public static bool isunordered(dynamic x, dynamic y)
        {
            return isunordered(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/fitsint32/*' />
        public static bool fitsint32(Octuple x)
        {
            return 0 != (Lib_OReal_FitsInt32(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_FitsInt32", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_FitsInt32(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fitsint32/*' />
        public static bool fitsint32(dynamic x)
        {
            return fitsint32(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/fitsint64/*' />
        public static bool fitsint64(Octuple x)
        {
            return 0 != (Lib_OReal_FitsInt64(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_FitsInt64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_OReal_FitsInt64(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fitsint64/*' />
        public static bool fitsint64(dynamic x)
        {
            return fitsint64(t(x));
        }



        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/FitsUInt32/*' />
        //public static bool FitsUInt32(Octuple x)
        //{
        //    return 0 != (Lib_OReal_FitsUInt32(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_FitsUInt32", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_OReal_FitsUInt32(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/FitsUInt32/*' />
        //public static bool FitsUInt32(dynamic x)
        //{
        //    return FitsUInt32(t(x));
        //}



        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/FitsUInt64/*' />
        //public static bool FitsUInt64(Octuple x)
        //{
        //    return 0 != (Lib_OReal_FitsUInt64(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_FitsUInt64", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_OReal_FitsUInt64(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/FitsUInt64/*' />
        //public static bool FitsUInt64(dynamic x)
        //{
        //    return FitsUInt64(t(x));
        //}




        #endregion



        #region Integer Related Functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nearbyint/*' />
        public static Octuple nearbyint(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Nearbyint(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Nearbyint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Nearbyint(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nearbyint/*' />
        public static Octuple nearbyint(dynamic x)
        {
            return nearbyint(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rint/*' />
        public static Octuple rint(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Rint(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Rint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Rint(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rint/*' />
        public static Octuple rint(dynamic x)
        {
            return rint(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lrint/*' />
        public static Int32 lrint(Octuple x)
        {
            return Lib_OReal_Lrint(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Lrint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_OReal_Lrint(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lrint/*' />
        public static Int32 lrint(dynamic x)
        {
            return lrint(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llrint/*' />
        public static Int64 llrint(Octuple x)
        {
            return Lib_OReal_Llrint(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Llrint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int64 Lib_OReal_Llrint(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llrint/*' />
        public static Int64 llrint(dynamic x)
        {
            return llrint(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ceil/*' />
        public static Octuple ceil(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Ceil(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Ceil", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Ceil(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ceil/*' />
        public static Octuple ceil(dynamic x)
        {
            return ceil(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/floor/*' />
        public static Octuple floor(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Floor(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Floor", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Floor(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/floor/*' />
        public static Octuple floor(dynamic x)
        {
            return floor(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/trunc/*' />
        public static Octuple trunc(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Trunc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Trunc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Trunc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/trunc/*' />
        public static Octuple trunc(dynamic x)
        {
            return trunc(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/round/*' />
        public static Octuple round(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Round(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Round", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Round(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/round/*' />
        public static Octuple round(dynamic x)
        {
            return round(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lround/*' />
        public static Int32 lround(Octuple x)
        {
            return Lib_OReal_Lround(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Lround", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_OReal_Lround(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lround/*' />
        public static Int32 lround(dynamic x)
        {
            return lround(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llround/*' />
        public static Int64 llround(Octuple x)
        {
            return Lib_OReal_Llround(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Llround", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int64 Lib_OReal_Llround(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llround/*' />
        public static Int64 llround(dynamic x)
        {
            return llround(t(x));
        }




        #endregion



        #region Floating point functions for real numbers


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/copysign/*' />
        public static Octuple copysign(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Copysign(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Copysign", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Copysign(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/copysign/*' />
        public static Octuple copysign(dynamic x, dynamic y)
        {
            return copysign(oreal.t(x), oreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/frexp/*' />
        public static Tuple<Octuple, Int32> frexp(Octuple x)
        {
            var res = new Octuple();
            Int32 e = 0;
            Lib_OReal_Frexp(res.mpPtr, x.mpPtr, ref e);
            return new Tuple<Octuple, int>(res, e);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Frexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Frexp(IntPtr res, IntPtr x, ref Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/frexp/*' />
        public static Tuple<Octuple, Int32> frexp(dynamic x)
        {
            return frexp(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logb/*' />
        public static Octuple logb(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Logb(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Logb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Logb(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logb/*' />
        public static Octuple logb(dynamic x)
        {
            return logb(t(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ilogb/*' />
        public static Int32 ilogb(Octuple x)
        {
            return Lib_OReal_Ilogb(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Ilogb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_OReal_Ilogb(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ilogb/*' />
        public static Int32 ilogb(dynamic x)
        {
            return ilogb(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ldexp/*' />
        public static Octuple ldexp(Octuple x, Int32 e)
        {
            var res = new Octuple();
            Lib_OReal_Ldexp(res.mpPtr, x.mpPtr, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Ldexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Ldexp(IntPtr res, IntPtr x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ldexp/*' />
        public static Octuple ldexp(dynamic x, dynamic e)
        {
            return ldexp(t(x), lround(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbn/*' />
        public static Octuple scalbn(Octuple x, Int32 e)
        {
            var res = new Octuple();
            Lib_OReal_Scalbn(res.mpPtr, x.mpPtr, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Scalbn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Scalbn(IntPtr res, IntPtr x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbn/*' />
        public static Octuple scalbn(dynamic x, dynamic e)
        {
            return scalbn(t(x), lround(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbln/*' />
        public static Octuple scalbln(Octuple x, Int32 e)
        {
            var res = new Octuple();
            Lib_OReal_Scalbln(res.mpPtr, x.mpPtr, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Scalbln", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Scalbln(IntPtr res, IntPtr x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbln/*' />
        public static Octuple scalbln(dynamic x, dynamic e)
        {
            return scalbln(t(x), lround(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fdim/*' />
        public static Octuple fdim(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Fdim(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Fdim", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Fdim(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fdim/*' />
        public static Octuple fdim(dynamic x, dynamic y)
        {
            return fdim(oreal.t(x), oreal.t(y));
        }


        #endregion



        #region Fraction and remainder Related Functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/modf/*' />
        public static Tuple<Octuple, Octuple> modf(Octuple x)
        {
            Octuple iptr = new Octuple();
            Octuple frac = new Octuple();
            Lib_OReal_Modf(frac.mpPtr, x.mpPtr, iptr.mpPtr);
            return new Tuple<Octuple, Octuple>(iptr, frac);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Modf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Modf(IntPtr frac, IntPtr x, IntPtr iptr);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/modf/*' />
        public static Tuple<Octuple, Octuple> modf(dynamic x)
        {
            return modf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmod/*' />
        public static Octuple fmod(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Fmod(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Fmod", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Fmod(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmod/*' />
        public static Octuple fmod(dynamic x, dynamic y)
        {
            return fmod(oreal.t(x), oreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remainder/*' />
        public static Octuple remainder(Octuple x, Octuple y)
        {
            if (oreal.iszero(y)) return oreal.nan();
            var res = new Octuple();
            Lib_OReal_Remainder(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Remainder", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Remainder(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remainder/*' />
        public static Octuple remainder(dynamic x, dynamic y)
        {
            return remainder(oreal.t(x), oreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remquo/*' />
        public static Tuple<Octuple, Int32> remquo(Octuple x, Octuple y)
        {
            if (oreal.iszero(y)) return new Tuple<Octuple, int>(oreal.nan(), 0);
            var res = new Octuple();
            Int32 e = 0;
            Lib_OReal_Remquo(res.mpPtr, x.mpPtr, y.mpPtr, ref e);
            return new Tuple<Octuple, int>(res, e);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Remquo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Remquo(IntPtr res, IntPtr x, IntPtr y, ref Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remquo/*' />
        public static Tuple<Octuple, Int32> remquo(dynamic x, dynamic y)
        {
            return remquo(t(x), t(y));
        }

        #endregion



        #region Functions related to mantissa width and exponent range


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/epsilon/*' />
        public static Octuple epsilon()
        {
            var res = new Octuple();
            Lib_OReal_Epsilon(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Epsilon", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Epsilon(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ulp/*' />
        public static Octuple ulp(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Ulp(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Ulp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Ulp(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ulp/*' />
        public static Octuple ulp(dynamic x)
        {
            return ulp(t(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/maxvalue/*' />
        public static Octuple maxvalue()
        {
            var res = new Octuple();
            Lib_OReal_Max(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Max", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Max(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/lowestvalue/*' />
        public static Octuple lowestvalue()
        {
            var res = new Octuple();
            Lib_OReal_Lowest(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Lowest", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Lowest(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/minposvalue/*' />
        public static Octuple minposvalue()
        {
            var res = new Octuple();
            Lib_OReal_Min(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Min", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Min(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextafter/*' />
        public static Octuple nextafter(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Nexttoward(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Nexttoward", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Nexttoward(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextafter/*' />
        public static Octuple nextafter(dynamic x, dynamic y)
        {
            return nextafter(oreal.t(x), oreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextabove/*' />
        public static Octuple nextabove(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Nextabove(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Nextabove", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Nextabove(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextabove/*' />
        public static Octuple nextabove(dynamic x)
        {
            return nextabove(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextbelow/*' />
        public static Octuple nextbelow(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Nextbelow(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Nextbelow", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Nextbelow(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextbelow/*' />
        public static Octuple nextbelow(dynamic x)
        {
            return nextbelow(t(x));
        }


        #endregion



        #region Mathematical Constants


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/degree/*' />
        public static Octuple degree()
        {
            var res = new Octuple();
            Lib_OReal_ConstDegree(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ConstDegree", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ConstDegree(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phi/*' />
        public static Octuple phi()
        {
            var res = new Octuple();
            Lib_OReal_ConstPhi(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ConstPhi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ConstPhi(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ln2/*' />
        public static Octuple ln2()
        {
            var res = new Octuple();
            Lib_OReal_ConstLog2(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ConstLog2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ConstLog2(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ln10/*' />
        public static Octuple ln10()
        {
            var res = new Octuple();
            Lib_OReal_ConstLog10(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ConstLog10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ConstLog10(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pi/*' />
        public static Octuple pi()
        {
            var res = new Octuple();
            Lib_OReal_ConstPi(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ConstPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ConstPi(IntPtr res);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/PI/*' />
        //public static Octuple PI()
        //{
        //    return PI();
        //}


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/e/*' />
        public static Octuple e()
        {
            var res = new Octuple();
            Lib_OReal_ConstE(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ConstE", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ConstE(IntPtr res);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/E/*' />
        //public static Octuple E()
        //{
        //    return E();
        //}


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/egamma/*' />
        public static Octuple egamma()
        {
            var res = new Octuple();
            Lib_OReal_ConstEulerGamma(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ConstEulerGamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ConstEulerGamma(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/apery/*' />
        public static Octuple apery()
        {
            var res = new Octuple();
            Lib_OReal_ConstApery(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ConstApery", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ConstApery(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/catalan/*' />
        public static Octuple catalan()
        {
            var res = new Octuple();
            Lib_OReal_ConstCatalan(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ConstCatalan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ConstCatalan(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/glaisher/*' />
        public static Octuple glaisher()
        {
            var res = new Octuple();
            Lib_OReal_ConstGlaisher(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ConstGlaisher", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ConstGlaisher(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/khinchin/*' />
        public static Octuple khinchin()
        {
            var res = new Octuple();
            Lib_OReal_ConstKhinchin(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ConstKhinchin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ConstKhinchin(IntPtr res);


        #endregion




        #endregion




        #region Elementary scalar functions




        #region Complex components


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Octuple abs(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Fabs(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Fabs", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Fabs(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Octuple abs(dynamic x)
        {
            return abs(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Octuple fabs(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Fabs(res.mpPtr, x.mpPtr);
            return res;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Octuple fabs(dynamic x)
        {
            return fabs(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static Octuple sign(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Sign(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Sign", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Sign(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static Octuple sign(dynamic x)
        {
            return sign(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Octuple real(Octuple x)
        {
            return x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Octuple real(dynamic x)
        {
            return real(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Octuple imag(Octuple x)
        {
            return zero();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Octuple imag(dynamic x)
        {
            return imag(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Octuple phase(Octuple x)
        {
            if (x >= zero()) return zero();
            else return pi();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Octuple phase(dynamic x)
        {
            return phase(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static Octuple conj(Octuple x)
        {
            return x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static Octuple conj(dynamic x)
        {
            return conj(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Octuple, Octuple> polar(Octuple x)
        {
            return new Tuple<Octuple, Octuple>(abs(x), phase(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Octuple, Octuple> polar(dynamic x)
        {
            return polar(oreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rect/*' />
        public static OctupleC rect(Octuple r, Octuple phi)
        {
            return r * expj(phi);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rect/*' />
        public static OctupleC rect(dynamic r, dynamic phi)
        {
            return rect(oreal.t(r), oreal.t(phi));
        }






        #endregion



        #region Roots and quadratic, cubic, and quartic 


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static Octuple sqrt(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Sqrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Sqrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Sqrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static Octuple sqrt(dynamic x)
        {
            return sqrt(t(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sqrt1pm1/*' />
        public static Octuple sqrt1pm1(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Sqrt1pm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Sqrt1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Sqrt1pm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sqrt1pm1/*' />
        public static Octuple sqrt1pm1(dynamic x)
        {
            return sqrt1pm1(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Octuple rsqrt(Octuple x)
        {
            return t(1) / sqrt(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Octuple rsqrt(dynamic x)
        {
            return rsqrt(t(x)); ;
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static Octuple cbrt(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Cbrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Cbrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Cbrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static Octuple cbrt(dynamic x)
        {
            return cbrt(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static Octuple root_si(Octuple x, int k)
        {
            if (isinf(x)) { return inf(); }
            if (isnan(x)) { return nan(); }
            var res = new Octuple();
            Lib_OReal_Root_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Root_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Root_Si(IntPtr res, IntPtr x, int k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static Octuple root_si(dynamic x, int k)
        {
            return root_si(t(x), k);
        }


        #endregion



        #region Exponential and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static Octuple exp(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Exp(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Exp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Exp(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static Octuple exp(dynamic x)
        {
            return exp(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static OctupleC expj(Octuple x)
        {
            return cos(x) + onej() * sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static OctupleC expj(dynamic x)
        {
            return expj(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static OctupleC expjpi(Octuple x)
        {
            return cospi(x) + onej() * sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static OctupleC expjpi(dynamic x)
        {
            return expjpi(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Octuple exp2(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Exp2(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Exp2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Exp2(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Octuple exp2(dynamic x)
        {
            return exp2(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static Octuple exp10(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Exp10(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Exp10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Exp10(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Octuple exp10(dynamic x)
        {
            return exp10(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Octuple expm1(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Expm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Expm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Expm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Octuple expm1(dynamic x)
        {
            return expm1(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Octuple exp2m1(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Exp2m1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Exp2m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Exp2m1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Octuple exp2m1(dynamic x)
        {
            return exp2m1(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static Octuple exp10m1(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Exp10m1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Exp10m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Exp10m1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static Octuple exp10m1(dynamic x)
        {
            return exp10m1(t(x));
        }




        #endregion



        #region Logarithms and related functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static Octuple log(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Log(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Log", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Log(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static Octuple log(dynamic x)
        {
            return log(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Octuple log2(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Log2(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Log2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Log2(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Octuple log2(dynamic x)
        {
            return log2(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Octuple log10(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Log10(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Log10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Log10(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Octuple log10(dynamic x)
        {
            return log10(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Octuple log1p(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Log1p(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Log1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Log1p(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Octuple log1p(dynamic x)
        {
            return log1p(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static Octuple log2p1(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Log2p1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Log2p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Log2p1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Octuple log2p1(dynamic x)
        {
            return log2p1(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static Octuple log10p1(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Log10p1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Log10p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Log10p1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Octuple log10p1(dynamic x)
        {
            return log10p1(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logaddexp/*' />
        public static Octuple logaddexp(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Logaddexp(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Logaddexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Logaddexp(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logaddexp/*' />
        public static Octuple logaddexp(dynamic x, dynamic y)
        {
            return logaddexp(t(x), t(y));
        }





        #endregion



        #region Power functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static Octuple sqr(Octuple x)
        {
            return x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static Octuple sqr(dynamic x)
        {
            return sqr(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static Octuple cube(Octuple x)
        {
            return x * x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static Octuple cube(dynamic x)
        {
            return cube(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static Octuple hypot(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Hypot(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Hypot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Hypot(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static Octuple hypot(dynamic x, dynamic y)
        {
            return hypot(oreal.t(x), oreal.t(y));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static Octuple pow(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Pow(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Pow", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Pow(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static Octuple pow(dynamic x, dynamic y)
        {
            return pow(oreal.t(x), oreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/powm1/*' />
        public static Octuple powm1(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Powm1(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Powm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Powm1(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/powm1/*' />
        public static Octuple powm1(dynamic x, dynamic y)
        {
            return powm1(oreal.t(x), oreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1p/*' />
        public static Octuple pow1p(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Pow1p(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Pow1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Pow1p(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1p/*' />
        public static Octuple pow1p(dynamic x, dynamic y)
        {
            return pow1p(oreal.t(x), oreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1pm1/*' />
        public static Octuple pow1pm1(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Pow1pm1(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Pow1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Pow1pm1(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1pm1/*' />
        public static Octuple pow1pm1(dynamic x, dynamic y)
        {
            return pow1pm1(oreal.t(x), oreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static Octuple pow_si(Octuple x, int k)
        {
            var res = new Octuple();
            Lib_OReal_Pow_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Pow_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Pow_Si(IntPtr res, IntPtr x, int k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static Octuple pow_si(dynamic x, int k)
        {
            return pow_si(t(x), k);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static Octuple compound_si(Octuple x, int k)
        {
            var res = new Octuple();
            Lib_OReal_Compound_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Compound_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Compound_Si(IntPtr res, IntPtr x, int k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static Octuple compound_si(dynamic x, int k)
        {
            return compound_si(t(x), k);
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Octuple sin(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Sin(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Sin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Sin(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Octuple sin(dynamic x)
        {
            return sin(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static Octuple cos(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Cos(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Cos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Cos(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static Octuple cos(dynamic x)
        {
            return cos(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static Octuple tan(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Tan(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Tan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Tan(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static Octuple tan(dynamic x)
        {
            return tan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static Octuple csc(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Csc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Csc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Csc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static Octuple csc(dynamic x)
        {
            return csc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static Octuple sec(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Sec(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Sec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Sec(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static Octuple sec(dynamic x)
        {
            return sec(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static Octuple cot(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Cot(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Cot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Cot(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static Octuple cot(dynamic x)
        {
            return cot(t(x));
        }








        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinpi/*' />
        public static Octuple sinpi(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_SinPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_SinPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_SinPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinpi/*' />
        public static Octuple sinpi(dynamic x)
        {
            return sinpi(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cospi/*' />
        public static Octuple cospi(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_CosPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_CosPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_CosPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cospi/*' />
        public static Octuple cospi(dynamic x)
        {
            return cospi(oreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/tanpi/*' />
        public static Octuple tanpi(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_TanPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_TanPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_TanPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/tanpi/*' />
        public static Octuple tanpi(dynamic x)
        {
            return tanpi(oreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cscpi/*' />
        public static Octuple cscpi(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_CscPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_CscPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_CscPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cscpi/*' />
        public static Octuple cscpi(dynamic x)
        {
            return cscpi(oreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/secpi/*' />
        public static Octuple secpi(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_SecPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_SecPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_SecPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/secpi/*' />
        public static Octuple secpi(dynamic x)
        {
            return secpi(oreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cotpi/*' />
        public static Octuple cotpi(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_CotPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_CotPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_CotPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cotpi/*' />
        public static Octuple cotpi(dynamic x)
        {
            return cotpi(oreal.t(x));
        }






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinc/*' />
        public static Octuple sinc(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_SincPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_SincPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_SincPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinc/*' />
        public static Octuple sinc(dynamic x)
        {
            return sinc(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static Octuple sincpi(Octuple x)
        {
            Octuple x1 = x * oreal.pi();

            if (oreal.abs(x) < 0.1)
            {
                return sinc(x1);
            }
            else return sinpi(x) / x1;
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinc/*' />
        public static Octuple sincpi(dynamic x)
        {
            return sincpi(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinhcpi/*' />
        public static Octuple sinhcpi(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_SinhcPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_SinhcPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_SinhcPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinhcpi/*' />
        public static Octuple sinhcpi(dynamic x)
        {
            return sinhcpi(oreal.t(x));
        }





        #endregion



        #region Hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static Octuple sinh(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Sinh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Sinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Sinh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static Octuple sinh(dynamic x)
        {
            return sinh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static Octuple cosh(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Cosh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Cosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Cosh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static Octuple cosh(dynamic x)
        {
            return cosh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static Octuple tanh(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Tanh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Tanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Tanh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static Octuple tanh(dynamic x)
        {
            return tanh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static Octuple csch(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Csch(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Csch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Csch(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static Octuple csch(dynamic x)
        {
            return csch(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static Octuple sech(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Sech(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Sech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Sech(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static Octuple sech(dynamic x)
        {
            return sech(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static Octuple coth(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Coth(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Coth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Coth(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static Octuple coth(dynamic x)
        {
            return coth(t(x));
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static Octuple asin(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Asin(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Asin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Asin(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static Octuple asin(dynamic x)
        {
            return asin(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static Octuple acos(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Acos(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Acos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Acos(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static Octuple acos(dynamic x)
        {
            return acos(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static Octuple atan(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Atan(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Atan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Atan(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static Octuple atan(dynamic x)
        {
            return atan(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan2/*' />
        public static Octuple atan2(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Atan2(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Atan2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Atan2(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan2/*' />
        public static Octuple atan2(dynamic x, dynamic y)
        {
            return atan2(oreal.t(x), oreal.t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static Octuple acsc(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Acsc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Acsc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Acsc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static Octuple acsc(dynamic x)
        {
            return acsc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static Octuple asec(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Asec(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Asec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Asec(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static Octuple asec(dynamic x)
        {
            return asec(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static Octuple acot(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Acot(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Acot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Acot(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static Octuple acot(dynamic x)
        {
            return acot(t(x));
        }




        #endregion



        #region Inverse hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static Octuple asinh(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Asinh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Asinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Asinh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static Octuple asinh(dynamic x)
        {
            return asinh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static Octuple acosh(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Acosh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Acosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Acosh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static Octuple acosh(dynamic x)
        {
            return acosh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static Octuple atanh(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Atanh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Atanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Atanh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static Octuple atanh(dynamic x)
        {
            return atanh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static Octuple acsch(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Acsch(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Acsch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Acsch(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static Octuple acsch(dynamic x)
        {
            return acsch(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static Octuple asech(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Asech(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Asech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Asech(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static Octuple asech(dynamic x)
        {
            return asech(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static Octuple acoth(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Acoth(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Acoth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Acoth(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static Octuple acoth(dynamic x)
        {
            return acoth(t(x));
        }





        #endregion



        #region Miscellaneous




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_w0/*' />
        public static Octuple lambert_w0(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_LambertW0(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LambertW0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_LambertW0(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_w0/*' />
        public static Octuple lambert_w0(dynamic x)
        {
            return lambert_w0(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_wm1/*' />
        public static Octuple lambert_wm1(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_LambertWm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LambertWm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_LambertWm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_wm1/*' />
        public static Octuple lambert_wm1(dynamic x)
        {
            return lambert_wm1(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_w0_prime/*' />
        public static Octuple lambert_w0_prime(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_LambertW0Prime(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LambertW0Prime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_LambertW0Prime(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_w0_prime/*' />
        public static Octuple lambert_w0_prime(dynamic x)
        {
            return lambert_w0_prime(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_wm1_prime/*' />
        public static Octuple lambert_wm1_prime(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_LambertWm1Prime(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LambertWm1Prime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_LambertWm1Prime(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_wm1_prime/*' />
        public static Octuple lambert_wm1_prime(dynamic x)
        {
            return lambert_wm1_prime(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/agm/*' />
        public static Octuple agm(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Agm(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Agm", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Agm(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/agm/*' />
        public static Octuple agm(dynamic x, dynamic y)
        {
            return agm(oreal.t(x), oreal.t(y));
        }





        #endregion






        #endregion





        #region Real erf, gamma, beta functions



        #region Error functions for real arguments



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndens/*' />
        public static Octuple ndens(Octuple x)
        {
            return exp(-0.5 * x * x) / sqrt(2 * pi());
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndens/*' />
        public static Octuple ndens(dynamic x)
        {
            return ndens(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndis/*' />
        public static Octuple ndis(Octuple x)
        {
            return 0.5 * erfc(-x / sqrt(2));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndis/*' />
        public static Octuple ndis(dynamic x)
        {
            return ndis(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erf/*' />
        public static Octuple erf(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Erf_(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Erf_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Erf_(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erf/*' />
        public static Octuple erf(dynamic x)
        {
            return erf(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erfc/*' />
        public static Octuple erfc(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Erfc_(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Erfc_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Erfc_(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erfc/*' />
        public static Octuple erfc(dynamic x)
        {
            return erfc(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ErfInv/*' />
        public static Octuple erf_inv(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Erf_inv(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Erf_inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Erf_inv(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ErfInv/*' />
        public static Octuple erf_inv(dynamic x)
        {
            return erf_inv(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ErfcInv/*' />
        public static Octuple erfc_inv(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Erfc_inv(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Erfc_inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Erfc_inv(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ErfcInv/*' />
        public static Octuple erfc_inv(dynamic x)
        {
            return erfc_inv(oreal.t(x));
        }





        #endregion




        #region Gamma and related functions for real arguments and parameters


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lgamma/*' />
        //public static Octuple lgamma(Octuple x)
        //{
        //    var res = new Octuple();
        //    Lib_OReal_Lgamma(res.mpPtr, x.mpPtr);
        //    return res;
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Lgamma", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void Lib_OReal_Lgamma(IntPtr res, IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lgamma/*' />
        //public static Octuple lgamma(dynamic x)
        //{
        //    return lgamma(t(x));
        //}


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rgamma/*' />
        public static Octuple rgamma(Octuple x)
        {
            return t(1) / gamma(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rgamma/*' />
        public static Octuple rgamma(dynamic x)
        {
            return rgamma(t(x));
        }





        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        //public static Octuple gamma(Octuple x)
        //{
        //    var res = new Octuple();
        //    Lib_OReal_Tgamma(res.mpPtr, x.mpPtr);
        //    return res;
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Tgamma", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void Lib_OReal_Tgamma(IntPtr res, IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        //public static Octuple gamma(dynamic x)
        //{
        //    return gamma(t(x));
        //}




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        public static Octuple gamma(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Tgamma_(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Tgamma_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Tgamma_(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        public static Octuple gamma(dynamic x)
        {
            return gamma(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma1pm1/*' />
        public static Octuple gamma1pm1(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Tgamma1pm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Tgamma1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Tgamma1pm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma1pm1/*' />
        public static Octuple gamma1pm1(dynamic x)
        {
            return gamma1pm1(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lgamma/*' />
        public static Octuple lgamma(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Lgamma_(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Lgamma_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Lgamma_(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lgamma/*' />
        public static Octuple lgamma(dynamic x)
        {
            return lgamma(oreal.t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/factorial/*' />
        public static Octuple factorial(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Factorial(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Factorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Factorial(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/factorial/*' />
        public static Octuple factorial(dynamic x)
        {
            return factorial(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/doublefactorial/*' />
        public static Octuple doublefactorial(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_DoubleFactorial(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_DoubleFactorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_DoubleFactorial(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/doublefactorial/*' />
        public static Octuple doublefactorial(dynamic x)
        {
            return doublefactorial(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_ratio/*' />
        public static Octuple gamma_ratio(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_TgammaRatio(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_TgammaRatio", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_TgammaRatio(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_ratio/*' />
        public static Octuple gamma_ratio(dynamic x, dynamic y)
        {
            return gamma_ratio(oreal.t(x), oreal.t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_delta_ratio/*' />
        public static Octuple gamma_delta_ratio(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_TgammaDeltaRatio(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_TgammaDeltaRatio", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_TgammaDeltaRatio(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_delta_ratio/*' />
        public static Octuple gamma_delta_ratio(dynamic x, dynamic y)
        {
            return gamma_delta_ratio(oreal.t(x), oreal.t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/binomial/*' />
        public static Octuple binomial(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_Binomial(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Binomial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Binomial(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/binomial/*' />
        public static Octuple binomial(dynamic x, dynamic y)
        {
            return binomial(oreal.t(x), oreal.t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/rising_factorial/*' />
        public static Octuple rising_factorial(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_RisingFactorial(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_RisingFactorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_RisingFactorial(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/rising_factorial/*' />
        public static Octuple rising_factorial(dynamic x, dynamic y)
        {
            return rising_factorial(oreal.t(x), oreal.t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/falling_factorial/*' />
        public static Octuple falling_factorial(Octuple x, Octuple y)
        {
            var res = new Octuple();
            Lib_OReal_FallingFactorial(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_FallingFactorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_FallingFactorial(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/falling_factorial/*' />
        public static Octuple falling_factorial(dynamic x, dynamic y)
        {
            return falling_factorial(oreal.t(x), oreal.t(y));
        }







        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta/*' />
        public static Octuple beta(Octuple a, Octuple b)
        {
            var res = new Octuple();
            Lib_OReal_Beta(res.mpPtr, a.mpPtr, b.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Beta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Beta(IntPtr res, IntPtr a, IntPtr b);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta/*' />
        public static Octuple beta(dynamic a, dynamic b)
        {
            return beta(oreal.t(a), oreal.t(b));
        }









        #endregion




        #region Incomplete gamma functions for real arguments and parameters




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p/*' />
        public static Octuple gamma_p(Octuple a, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_GammaP(res.mpPtr, a.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GammaP", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_GammaP(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p/*' />
        public static Octuple gamma_p(dynamic a, dynamic x)
        {
            return gamma_p(oreal.t(a), oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q/*' />
        public static Octuple gamma_q(Octuple a, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_GammaQ(res.mpPtr, a.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GammaQ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_GammaQ(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q/*' />
        public static Octuple gamma_q(dynamic a, dynamic x)
        {
            return gamma_q(oreal.t(a), oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_lower/*' />
        public static Octuple gamma_lower(Octuple a, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_TgammaLower(res.mpPtr, a.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_TgammaLower", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_TgammaLower(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_lower/*' />
        public static Octuple gamma_lower(dynamic a, dynamic x)
        {
            return gamma_lower(oreal.t(a), oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_upper/*' />
        public static Octuple gamma_upper(Octuple a, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_TgammaUpper(res.mpPtr, a.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_TgammaUpper", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_TgammaUpper(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_upper/*' />
        public static Octuple gamma_upper(dynamic a, dynamic x)
        {
            return gamma_upper(oreal.t(a), oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inv/*' />
        public static Octuple gamma_p_inv(Octuple a, Octuple p)
        {
            var res = new Octuple();
            Lib_OReal_GammaPInv(res.mpPtr, a.mpPtr, p.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GammaPInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_GammaPInv(IntPtr res, IntPtr a, IntPtr p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inv/*' />
        public static Octuple gamma_p_inv(dynamic a, dynamic p)
        {
            return gamma_p_inv(oreal.t(a), oreal.t(p));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inv/*' />
        public static Octuple gamma_q_inv(Octuple a, Octuple q)
        {
            var res = new Octuple();
            Lib_OReal_GammaQInv(res.mpPtr, a.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GammaQInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_GammaQInv(IntPtr res, IntPtr a, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inv/*' />
        public static Octuple gamma_q_inv(dynamic a, dynamic q)
        {
            return gamma_q_inv(oreal.t(a), oreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inva/*' />
        public static Octuple gamma_p_inva(Octuple x, Octuple p)
        {
            var res = new Octuple();
            Lib_OReal_GammaPInva(res.mpPtr, x.mpPtr, p.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GammaPInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_GammaPInva(IntPtr res, IntPtr x, IntPtr p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inva/*' />
        public static Octuple gamma_p_inva(dynamic x, dynamic p)
        {
            return gamma_p_inva(oreal.t(x), oreal.t(p));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inva/*' />
        public static Octuple gamma_q_inva(Octuple x, Octuple q)
        {
            var res = new Octuple();
            Lib_OReal_GammaQInva(res.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GammaQInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_GammaQInva(IntPtr res, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inva/*' />
        public static Octuple gamma_q_inva(dynamic x, dynamic q)
        {
            return gamma_q_inva(oreal.t(x), oreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_prime/*' />
        public static Octuple gamma_p_prime(Octuple a, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_GammaPDerivative(res.mpPtr, a.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GammaPDerivative", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_GammaPDerivative(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_prime/*' />
        public static Octuple gamma_p_prime(dynamic a, dynamic x)
        {
            return gamma_p_prime(oreal.t(a), oreal.t(x));
        }





        #endregion



        #region Incomplete beta functions for real arguments and parameters


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta/*' />
        public static Octuple ibeta(Octuple a, Octuple b, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_IBeta(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_IBeta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_IBeta(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta/*' />
        public static Octuple ibeta(dynamic a, dynamic b, dynamic x)
        {
            return ibeta(oreal.t(a), oreal.t(b), oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac/*' />
        public static Octuple ibetac(Octuple a, Octuple b, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_IBetac(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_IBetac", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_IBetac(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac/*' />
        public static Octuple ibetac(dynamic a, dynamic b, dynamic x)
        {
            return ibetac(oreal.t(a), oreal.t(b), oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta_lower/*' />
        public static Octuple beta_lower(Octuple a, Octuple b, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_IBetaNonNormalized(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_IBetaNonNormalized", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_IBetaNonNormalized(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta_lower/*' />
        public static Octuple beta_lower(dynamic a, dynamic b, dynamic x)
        {
            return beta_lower(oreal.t(a), oreal.t(b), oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta_upper/*' />
        public static Octuple beta_upper(Octuple a, Octuple b, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_IBetacNonNormalized(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_IBetacNonNormalized", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_IBetacNonNormalized(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta_upper/*' />
        public static Octuple beta_upper(dynamic a, dynamic b, dynamic x)
        {
            return beta_upper(oreal.t(a), oreal.t(b), oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inv/*' />
        public static Octuple ibeta_inv(Octuple a, Octuple b, Octuple p)
        {
            var res = new Octuple();
            Lib_OReal_IBetaInv(res.mpPtr, a.mpPtr, b.mpPtr, p.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_IBetaInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_IBetaInv(IntPtr res, IntPtr a, IntPtr b, IntPtr p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inv/*' />
        public static Octuple ibeta_inv(dynamic a, dynamic b, dynamic p)
        {
            return ibeta_inv(oreal.t(a), oreal.t(b), oreal.t(p));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inv/*' />
        public static Octuple ibetac_inv(Octuple a, Octuple b, Octuple q)
        {
            var res = new Octuple();
            Lib_OReal_IBetacInv(res.mpPtr, a.mpPtr, b.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_IBetacInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_IBetacInv(IntPtr res, IntPtr a, IntPtr b, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inv/*' />
        public static Octuple ibetac_inv(dynamic a, dynamic b, dynamic q)
        {
            return ibetac_inv(oreal.t(a), oreal.t(b), oreal.t(q));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inva/*' />
        public static Octuple ibeta_inva(Octuple b, Octuple x, Octuple p)
        {
            var res = new Octuple();
            Lib_OReal_IBetaInva(res.mpPtr, b.mpPtr, x.mpPtr, p.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_IBetaInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_IBetaInva(IntPtr res, IntPtr b, IntPtr x, IntPtr p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inva/*' />
        public static Octuple ibeta_inva(dynamic b, dynamic x, dynamic p)
        {
            return ibeta_inva(oreal.t(b), oreal.t(x), oreal.t(p));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inva/*' />
        public static Octuple ibetac_inva(Octuple b, Octuple x, Octuple q)
        {
            var res = new Octuple();
            Lib_OReal_IBetacInva(res.mpPtr, b.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_IBetacInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_IBetacInva(IntPtr res, IntPtr b, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inva/*' />
        public static Octuple ibetac_inva(dynamic b, dynamic x, dynamic q)
        {
            return ibetac_inva(oreal.t(b), oreal.t(x), oreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_invb/*' />
        public static Octuple ibeta_invb(Octuple a, Octuple x, Octuple p)
        {
            var res = new Octuple();
            Lib_OReal_IBetaInvb(res.mpPtr, a.mpPtr, x.mpPtr, p.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_IBetaInvb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_IBetaInvb(IntPtr res, IntPtr a, IntPtr x, IntPtr p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_invb/*' />
        public static Octuple ibeta_invb(dynamic a, dynamic x, dynamic p)
        {
            return ibeta_invb(oreal.t(a), oreal.t(x), oreal.t(p));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_invb/*' />
        public static Octuple ibetac_invb(Octuple a, Octuple x, Octuple q)
        {
            var res = new Octuple();
            Lib_OReal_IBetacInvb(res.mpPtr, a.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_IBetacInvb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_IBetacInvb(IntPtr res, IntPtr a, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_invb/*' />
        public static Octuple ibetac_invb(dynamic a, dynamic x, dynamic q)
        {
            return ibetac_invb(oreal.t(a), oreal.t(x), oreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_prime/*' />
        public static Octuple ibeta_prime(Octuple a, Octuple b, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_IBetaDerivative(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_IBetaDerivative", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_IBetaDerivative(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_prime/*' />
        public static Octuple ibeta_prime(dynamic a, dynamic b, dynamic x)
        {
            return ibeta_prime(oreal.t(a), oreal.t(b), oreal.t(x));
        }





        #endregion



        #region Miscellaneous real functions




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/owen_t/*' />
        public static Octuple owen_t(Octuple h, Octuple a)
        {
            var res = new Octuple();
            Lib_OReal_OwenT(res.mpPtr, h.mpPtr, a.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_OwenT", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_OwenT(IntPtr res, IntPtr h, IntPtr a);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/owen_t/*' />
        public static Octuple owen_t(dynamic h, dynamic a)
        {
            return owen_t(oreal.t(h), oreal.t(a));
        }





        #endregion



        #endregion






        #region Special Functions



        #region Legendre elliptic integrals (elliptic modulus k), and related functions


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Ellint1K/*' />
        public static Octuple elliptic_k(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Ellint_1_K(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Ellint_1_K", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Ellint_1_K(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Ellint1K/*' />
        public static Octuple elliptic_k(dynamic x)
        {
            return elliptic_k(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Ellint2K/*' />
        public static Octuple elliptic_e(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Ellint_2_K(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Ellint_2_K", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Ellint_2_K(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Ellint2K/*' />
        public static Octuple elliptic_e(dynamic x)
        {
            return elliptic_e(oreal.t(x));
        }






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rc/*' />
        public static Octuple elliptic_rc(Octuple a, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_EllintRC(res.mpPtr, a.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_EllintRC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_EllintRC(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rc/*' />
        public static Octuple elliptic_rc(dynamic a, dynamic x)
        {
            return elliptic_rc(oreal.t(a), oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_f/*' />
        public static Octuple elliptic_f(Octuple phi, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_Ellint1F(res.mpPtr, k.mpPtr, phi.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Ellint1F", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Ellint1F(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_f/*' />
        public static Octuple elliptic_f(dynamic phi, dynamic k)
        {
            return elliptic_f(oreal.t(phi), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_e_inc/*' />
        public static Octuple elliptic_e_inc(Octuple phi, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_Ellint2F(res.mpPtr, k.mpPtr, phi.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Ellint2F", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Ellint2F(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_e_inc/*' />
        public static Octuple elliptic_e_inc(dynamic phi, dynamic k)
        {
            return elliptic_e_inc(oreal.t(phi), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_pi/*' />
        public static Octuple elliptic_pi(Octuple n, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_Ellint3K(res.mpPtr, k.mpPtr, n.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Ellint3K", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Ellint3K(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_pi/*' />
        public static Octuple elliptic_pi(dynamic n, dynamic k)
        {
            return elliptic_pi(oreal.t(n), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_pi_inc/*' />
        public static Octuple elliptic_pi_inc(Octuple n, Octuple phi, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_Ellint3F(res.mpPtr, k.mpPtr, n.mpPtr, phi.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Ellint3F", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Ellint3F(IntPtr res, IntPtr k, IntPtr n, IntPtr phi);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_pi_inc/*' />
        public static Octuple elliptic_pi_inc(dynamic n, dynamic phi, dynamic k)
        {
            return elliptic_pi_inc(oreal.t(n), oreal.t(phi), oreal.t(k));
        }








        #endregion



        #region Carlson symmetric elliptic integrals




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rf/*' />
        public static Octuple elliptic_rf(Octuple x, Octuple y, Octuple z)
        {
            var res = new Octuple();
            Lib_OReal_EllipticRF(res.mpPtr, x.mpPtr, y.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_EllipticRF", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_EllipticRF(IntPtr res, IntPtr x, IntPtr y, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rf/*' />
        public static Octuple elliptic_rf(dynamic x, dynamic y, dynamic z)
        {
            return elliptic_rf(oreal.t(x), oreal.t(y), oreal.t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rd/*' />
        public static Octuple elliptic_rd(Octuple x, Octuple y, Octuple z)
        {
            var res = new Octuple();
            Lib_OReal_EllipticRD(res.mpPtr, x.mpPtr, y.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_EllipticRD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_EllipticRD(IntPtr res, IntPtr x, IntPtr y, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rd/*' />
        public static Octuple elliptic_rd(dynamic x, dynamic y, dynamic z)
        {
            return elliptic_rd(oreal.t(x), oreal.t(y), oreal.t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rg/*' />
        public static Octuple elliptic_rg(Octuple x, Octuple y, Octuple z)
        {
            var res = new Octuple();
            Lib_OReal_EllipticRG(res.mpPtr, x.mpPtr, y.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_EllipticRG", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_EllipticRG(IntPtr res, IntPtr x, IntPtr y, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rg/*' />
        public static Octuple elliptic_rg(dynamic x, dynamic y, dynamic z)
        {
            return elliptic_rg(oreal.t(x), oreal.t(y), oreal.t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rj/*' />
        public static Octuple elliptic_rj(Octuple x, Octuple y, Octuple z, Octuple p)
        {
            var res = new Octuple();
            Lib_OReal_EllipticRJ(res.mpPtr, x.mpPtr, y.mpPtr, z.mpPtr, p.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_EllipticRJ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_EllipticRJ(IntPtr res, IntPtr x, IntPtr y, IntPtr z, IntPtr p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rj/*' />
        public static Octuple elliptic_rj(dynamic x, dynamic y, dynamic z, dynamic p)
        {
            return elliptic_rj(oreal.t(x), oreal.t(y), oreal.t(z), oreal.t(p));
        }



        #endregion



        #region Jacobi theta functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta1/*' />
        public static Octuple jacobi_theta1(Octuple x, Octuple q)
        {
            var res = new Octuple();
            Lib_OReal_JacobiTheta1(res.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiTheta1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiTheta1(IntPtr res, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta1/*' />
        public static Octuple jacobi_theta1(dynamic x, dynamic q)
        {
            return jacobi_theta1(oreal.t(x), oreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta2/*' />
        public static Octuple jacobi_theta2(Octuple x, Octuple q)
        {
            var res = new Octuple();
            Lib_OReal_JacobiTheta2(res.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiTheta2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiTheta2(IntPtr res, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta2/*' />
        public static Octuple jacobi_theta2(dynamic x, dynamic q)
        {
            return jacobi_theta2(oreal.t(x), oreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta3/*' />
        public static Octuple jacobi_theta3(Octuple x, Octuple q)
        {
            var res = new Octuple();
            Lib_OReal_JacobiTheta3(res.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiTheta3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiTheta3(IntPtr res, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta3/*' />
        public static Octuple jacobi_theta3(dynamic x, dynamic q)
        {
            return jacobi_theta3(oreal.t(x), oreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta3/*' />
        public static Octuple jacobi_theta4(Octuple x, Octuple q)
        {
            var res = new Octuple();
            Lib_OReal_JacobiTheta4(res.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiTheta4", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiTheta4(IntPtr res, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta3/*' />
        public static Octuple jacobi_theta4(dynamic x, dynamic q)
        {
            return jacobi_theta4(oreal.t(x), oreal.t(q));
        }





        #endregion



        #region Jacobi elliptic functions


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cd/*' />
        public static Octuple jacobi_cd(Octuple u, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_JacobiCD(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiCD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiCD(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cd/*' />
        public static Octuple jacobi_cd(dynamic u, dynamic k)
        {
            return jacobi_cd(oreal.t(u), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cn/*' />
        public static Octuple jacobi_cn(Octuple u, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_JacobiCN(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiCN", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiCN(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cn/*' />
        public static Octuple jacobi_cn(dynamic u, dynamic k)
        {
            return jacobi_cn(oreal.t(u), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cs/*' />
        public static Octuple jacobi_cs(Octuple u, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_JacobiCS(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiCS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiCS(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cs/*' />
        public static Octuple jacobi_cs(dynamic u, dynamic k)
        {
            return jacobi_cs(oreal.t(u), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_dc/*' />
        public static Octuple jacobi_dc(Octuple u, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_JacobiDC(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiDC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiDC(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_dc/*' />
        public static Octuple jacobi_dc(dynamic u, dynamic k)
        {
            return jacobi_dc(oreal.t(u), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_dn/*' />
        public static Octuple jacobi_dn(Octuple u, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_JacobiDN(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiDN", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiDN(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_dn/*' />
        public static Octuple jacobi_dn(dynamic u, dynamic k)
        {
            return jacobi_dn(oreal.t(u), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_ds/*' />
        public static Octuple jacobi_ds(Octuple u, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_JacobiDS(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiDS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiDS(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_ds/*' />
        public static Octuple jacobi_ds(dynamic u, dynamic k)
        {
            return jacobi_ds(oreal.t(u), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_nc/*' />
        public static Octuple jacobi_nc(Octuple u, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_JacobiNC(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiNC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiNC(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_nc/*' />
        public static Octuple jacobi_nc(dynamic u, dynamic k)
        {
            return jacobi_nc(oreal.t(u), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_nd/*' />
        public static Octuple jacobi_nd(Octuple u, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_JacobiND(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiND", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiND(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_nd/*' />
        public static Octuple jacobi_nd(dynamic u, dynamic k)
        {
            return jacobi_nd(oreal.t(u), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_ns/*' />
        public static Octuple jacobi_ns(Octuple u, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_JacobiNS(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiNS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiNS(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_ns/*' />
        public static Octuple jacobi_ns(dynamic u, dynamic k)
        {
            return jacobi_ns(oreal.t(u), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sc/*' />
        public static Octuple jacobi_sc(Octuple u, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_JacobiSC(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiSC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiSC(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sc/*' />
        public static Octuple jacobi_sc(dynamic u, dynamic k)
        {
            return jacobi_sc(oreal.t(u), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sd/*' />
        public static Octuple jacobi_sd(Octuple u, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_JacobiSD(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiSD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiSD(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sd/*' />
        public static Octuple jacobi_sd(dynamic u, dynamic k)
        {
            return jacobi_sd(oreal.t(u), oreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sn/*' />
        public static Octuple jacobi_sn(Octuple u, Octuple k)
        {
            var res = new Octuple();
            Lib_OReal_JacobiSN(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_JacobiSN", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_JacobiSN(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sn/*' />
        public static Octuple jacobi_sn(dynamic u, dynamic k)
        {
            return jacobi_sn(oreal.t(u), oreal.t(k));
        }




        #endregion



        #region polygamma functions




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/polygamma/*' />
        public static Octuple polygamma(int n, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Polygamma(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Polygamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Polygamma(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/polygamma/*' />
        public static Octuple polygamma(int n, dynamic y)
        {
            return polygamma(n, oreal.t(y));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/digamma/*' />
        public static Octuple digamma(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Digamma(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Digamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Digamma(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/digamma/*' />
        public static Octuple digamma(dynamic x)
        {
            return digamma(oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/trigamma/*' />
        public static Octuple trigamma(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Trigamma(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Trigamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Trigamma(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/trigamma/*' />
        public static Octuple trigamma(dynamic x)
        {
            return trigamma(oreal.t(x));
        }





        #endregion



        #region Hurwitz zeta function and related functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bernoulli/*' />
        public static Octuple bernoulli(int n)
        {
            if (n == 1) return t(-0.5);
            if (n % 2 != 0) return zero();
            var res = new Octuple();
            Lib_OReal_BernoulliB2n(res.mpPtr, n / 2);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BernoulliB2n", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_BernoulliB2n(IntPtr res, int n);




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TangentT2n/*' />
        public static Octuple TangentT2n(int n)
        {
            var res = new Octuple();
            Lib_OReal_TangentT2n(res.mpPtr, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_TangentT2n", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_TangentT2n(IntPtr res, int n);



        #endregion



        #region Dirichlet L-Series, Riemann zeta function, and related functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/zeta/*' />
        public static Octuple zeta(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Zeta(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Zeta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Zeta(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/zeta/*' />
        public static Octuple zeta(dynamic x)
        {
            return zeta(oreal.t(x));
        }


        #endregion



        #region 0F1: Overview



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_0f1/*' />
        public static Octuple hyperg_0f1(Octuple b, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Hypergeo0F1(res.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Hypergeo0F1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Hypergeo0F1(IntPtr res, IntPtr b, IntPtr x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_0f1/*' />
        public static Octuple hyperg_0f1(dynamic b, dynamic x)
        {
            return hyperg_0f1(oreal.t(b), oreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_0f1r/*' />
        public static Octuple hyperg_0f1r(Octuple b, Octuple x)
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
        public static Octuple hyperg_0f1r(dynamic b, dynamic x)
        {
            return hyperg_0f1r(oreal.t(b), oreal.t(x));
        }




        #endregion



        #region Bessel functions and modified Bessel functions




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv/*' />
        public static Octuple bessel_jv(Octuple v, Octuple x, bool scaled = false)
        {
            var res = new Octuple();
            Lib_OReal_BesselJ(res.mpPtr, v.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BesselJ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_BesselJ(IntPtr res, IntPtr v, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv/*' />
        public static Octuple bessel_jv(dynamic x, dynamic y, bool scaled = false)
        {
            return bessel_jv(oreal.t(x), oreal.t(y), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv/*' />
        public static Octuple bessel_yv(Octuple v, Octuple x, bool scaled = false)
        {
            var res = new Octuple();
            Lib_OReal_BesselY(res.mpPtr, v.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BesselY", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_BesselY(IntPtr res, IntPtr v, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv/*' />
        public static Octuple bessel_yv(dynamic x, dynamic y, bool scaled = false)
        {
            return bessel_yv(oreal.t(x), oreal.t(y), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv/*' />
        public static Octuple bessel_iv(Octuple v, Octuple x, bool scaled = false)
        {
            var res = new Octuple();
            Lib_OReal_BesselI(res.mpPtr, v.mpPtr, x.mpPtr);
            if (scaled) res *= exp(-abs(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BesselI", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_BesselI(IntPtr res, IntPtr v, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv/*' />
        public static Octuple bessel_iv(dynamic x, dynamic y, bool scaled = false)
        {
            return bessel_iv(oreal.t(x), oreal.t(y), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv/*' />
        public static Octuple bessel_kv(Octuple v, Octuple x, bool scaled = false)
        {
            var res = new Octuple();
            Lib_OReal_BesselK(res.mpPtr, v.mpPtr, x.mpPtr);
            if (scaled) res *= exp(x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BesselK", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_BesselK(IntPtr res, IntPtr v, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv/*' />
        public static Octuple bessel_kv(dynamic x, dynamic y, bool scaled = false)
        {
            return bessel_kv(oreal.t(x), oreal.t(y), scaled);
        }







        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_prime/*' />
        public static Octuple bessel_jv_prime(Octuple v, Octuple x, bool scaled = false)
        {
            var res = new Octuple();
            Lib_OReal_BesselJPrime(res.mpPtr, v.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BesselJPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_BesselJPrime(IntPtr res, IntPtr v, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_prime/*' />
        public static Octuple bessel_jv_prime(dynamic x, dynamic y, bool scaled = false)
        {
            return bessel_jv_prime(oreal.t(x), oreal.t(y), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_prime/*' />
        public static Octuple bessel_yv_prime(Octuple v, Octuple x, bool scaled = false)
        {
            var res = new Octuple();
            Lib_OReal_BesselYPrime(res.mpPtr, v.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BesselYPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_BesselYPrime(IntPtr res, IntPtr v, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_prime/*' />
        public static Octuple bessel_yv_prime(dynamic x, dynamic y, bool scaled = false)
        {
            return bessel_yv_prime(oreal.t(x), oreal.t(y), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv_prime/*' />
        public static Octuple bessel_iv_prime(Octuple v, Octuple x, bool scaled = false)
        {
            var res = new Octuple();
            Lib_OReal_BesselIPrime(res.mpPtr, v.mpPtr, x.mpPtr);
            if (scaled) res *= exp(-abs(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BesselIPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_BesselIPrime(IntPtr res, IntPtr v, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv_prime/*' />
        public static Octuple bessel_iv_prime(dynamic x, dynamic y, bool scaled = false)
        {
            return bessel_iv_prime(oreal.t(x), oreal.t(y), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv_prime/*' />
        public static Octuple bessel_kv_prime(Octuple v, Octuple x, bool scaled = false)
        {
            var res = new Octuple();
            Lib_OReal_BesselKPrime(res.mpPtr, v.mpPtr, x.mpPtr);
            if (scaled) res *= exp(x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BesselKPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_BesselKPrime(IntPtr res, IntPtr v, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv_prime/*' />
        public static Octuple bessel_kv_prime(dynamic x, dynamic y, bool scaled = false)
        {
            return bessel_kv_prime(oreal.t(x), oreal.t(y), scaled);
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_zero/*' />
        public static Octuple bessel_jv_zero(Octuple x, int m)
        {
            var res = new Octuple();
            Lib_OReal_BesselJZero(res.mpPtr, x.mpPtr, m);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BesselJZero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_BesselJZero(IntPtr res, IntPtr x, int m);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_zero/*' />
        public static Octuple bessel_jv_zero(dynamic x, int m)
        {
            return bessel_jv_zero(oreal.t(x), m);
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_zero/*' />
        public static Octuple bessel_yv_zero(Octuple x, int m)
        {
            var res = new Octuple();
            Lib_OReal_BesselYZero(res.mpPtr, x.mpPtr, m);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BesselYZero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_BesselYZero(IntPtr res, IntPtr x, int m);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_zero/*' />
        public static Octuple bessel_yv_zero(dynamic x, int m)
        {
            return bessel_yv_zero(oreal.t(x), m);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_zero/*' />
        public static Octuple sph_bessel_jn_zero(int n, int m)
        {
            return bessel_jv_zero(n + 0.5, m);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_zero/*' />
        public static Octuple sph_bessel_yn_zero(int n, int m)
        {
            return bessel_yv_zero(n + 0.5, m);
        }





        #endregion






        #region Spherical Bessel functions and spherical modified Bessel functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn/*' />
        public static Octuple sph_bessel_jn(Octuple n, Octuple x, bool scaled = false)
        {
            if (!oreal.isinteger(n)) return oreal.nan();

            if (oreal.isnan(x)) return oreal.nan();
            if (oreal.isinf(x)) return oreal.zero();
            if (oreal.isneginf(x)) return oreal.zero();
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if ((n == 0)) return oreal.one();
                    else return oreal.zero();
                }
                else
                {
                    if (lrint(n) % 2 == 0) return oreal.neginf(); else return oreal.nan();
                }
            }

            if (n < 0)
            {
                Octuple res = sph_bessel_yn(-n - 1, x);
                if ((lrint(n) + 1) % 2 == 0) res = -res;
                return res;
            }
            else
            {
                Octuple x1 = x;
                if (x1 <= 0) x1 = -x1;
                Octuple res = oreal.t(0);
                Lib_OReal_SphBessel(res.mpPtr, lrint(n), x1.mpPtr);
                if ((x < 0) && !(lrint(n) % 2 == 0)) res = -res;
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_SphBessel", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_SphBessel(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn/*' />
        public static Octuple sph_bessel_jn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_jn(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn' />
        public static Octuple sph_bessel_yn(Octuple n, Octuple x, bool scaled = false)
        {
            if (!oreal.isinteger(n)) return oreal.nan();

            if (oreal.isnan(x)) return oreal.nan();
            if (oreal.isinf(x)) return oreal.zero();
            if (oreal.isneginf(x)) return oreal.zero();
            if (x == 0.0)
            {
                if (n < 0)
                {
                    if ((n == -1)) return oreal.one();
                    else return oreal.zero();
                }
                else
                {
                    if (lrint(n) % 2 != 0) return oreal.neginf(); else return oreal.nan();
                }
            }

            if (n < 0)
            {
                Octuple res = sph_bessel_jn(-n - 1, x);
                if ((lrint(n) + 2) % 2 == 0) res = -res;
                return res;
            }
            else
            {
                Octuple x1 = x;
                if (x1 <= 0) x1 = -x1;
                Octuple res = oreal.t(0);
                Lib_OReal_SphNeumann(res.mpPtr, lrint(n), x1.mpPtr);
                if ((x < 0) && !((lrint(n) + 1) % 2 == 0)) res = -res;
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_SphNeumann", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_SphNeumann(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn/*' />
        public static Octuple sph_bessel_yn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_yn(t(n), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in/*' />
        public static Octuple sph_bessel_in(Octuple n, Octuple x, bool scaled = false)
        {
            if (!oreal.isinteger(n)) return oreal.nan();

            if (oreal.isnan(x)) return oreal.nan();
            if (oreal.isinf(x)) return oreal.inf();
            if (oreal.isneginf(x)) return oreal.zero();
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if ((n == 0)) return oreal.one();
                    else return oreal.zero();
                }
                else
                {
                    if (lrint(n) % 2 == 0) return oreal.neginf(); else return oreal.nan();
                }
            }

            Octuple x1 = x;
            if (x1 <= 0) x1 = -x1;
            Octuple res = bessel_iv(n + 0.5, x1) / sqrt(2 * x1 / pi());
            if ((x < 0) && !(lrint(n) % 2 == 0)) res = -res;
            if (scaled) res *= exp(-abs(x));
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in/*' />
        public static Octuple sph_bessel_in(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_in(t(n), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn/*' />
        public static Octuple sph_bessel_kn(Octuple n, Octuple x, bool scaled = false)
        {
            if (!oreal.isinteger(n)) return oreal.nan();

            if (oreal.isnan(x)) return oreal.nan();
            if (oreal.isinf(x)) return oreal.zero();
            if (oreal.isneginf(x)) return oreal.neginf();
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if (lrint(n) % 2 == 0) return oreal.nan(); else return oreal.inf();
                }
                else
                {
                    if (lrint(n) % 2 == 0) return oreal.inf(); else return oreal.nan();
                }
            }
            Octuple res;
            if (x >= 0.0f) res = bessel_kv(n + 0.5, x) / sqrt(2 * x / pi());
            else res = -0.5f * pi() * (sph_bessel_in(n, -x) + sph_bessel_in(-n - 1, -x));
            if (scaled) res *= exp(x);
            return res;

        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn/*' />
        public static Octuple sph_bessel_kn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_kn(t(n), t(x), scaled);
        }



        internal static Octuple besselpoly_(int n, Octuple x)
        {
            if (n < 0) n = Math.Abs(n) - 1;
            if (n == 0) return t(1.0);
            if (n == 1) return x + 1;
            var y = new Octuple[n + 2];
            y[0] = t(1);
            y[1] = x + 1;
            for (int i = 2; i <= n; i++)
            {
                y[i] = (2 * i - 1) * x * y[i - 1] + y[i - 2];
            }
            return y[n];
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besselpoly/*' />
        public static Octuple besselpoly(Octuple n, Octuple x, bool scaled = false)
        {
            if (!oreal.isinteger(n)) return oreal.nan();
            if (abs(x) < t(0.01)) return besselpoly_(lrint(n), x);
            else
            {
                Octuple res = sph_bessel_kn(n, 1 / x);
                res *= exp(1 / x) * 2 / (pi() * x);
                return res;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besselpoly/*' />
        public static Octuple besselpoly(dynamic n, dynamic x, bool scaled = false)
        {
            return besselpoly(t(n), t(x), scaled);
        }





        internal static Octuple besseltheta_(int n, Octuple x)
        {
            if (n < 0) n = Math.Abs(n) - 1;
            if (n == 0) return t(1.0);
            if (n == 1) return x + 1;
            var y = new Octuple[n + 2];
            y[0] = t(1);
            y[1] = x + 1;
            for (int i = 2; i <= n; i++)
            {
                y[i] = (2 * i - 1) * y[i - 1] + x * x * y[i - 2];
            }
            return y[n];
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besseltheta/*' />
        public static Octuple besseltheta(Octuple n, Octuple x, bool scaled = false)
        {
            if (!oreal.isinteger(n)) return oreal.nan();
            if ((x == 0) && (n < 0)) return oreal.nan();
            if ((abs(x) < t(0.01)) && (n >= 0)) return besseltheta_(lrint(n), x);
            if (n < 0) return pow(x, n) * besselpoly(n, 1 / x);
            else
            {
                Octuple res = sph_bessel_kn(n, x);
                res *= oreal.pow(x, n + 1) * exp(x) * 2 / pi();
                return res;
            }
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besseltheta/*' />
        public static Octuple besseltheta(dynamic n, dynamic x, bool scaled = false)
        {
            return besseltheta(t(n), t(x), scaled);
        }







        #endregion




        #region Spherical Bessel functions, first derivative




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_prime/*' />
        public static Octuple sph_bessel_jn_prime(Octuple n, Octuple x, bool scaled = false)
        {
            if (!oreal.isinteger(n)) return oreal.nan();

            if (oreal.isnan(x)) return oreal.nan();
            if (oreal.isinf(x)) return oreal.zero();
            if (oreal.isneginf(x)) return oreal.zero();
            if (x == 0.0)
            {
                if (n == 1) return 1 / oreal.t(3);
                if (n >= 0) return oreal.zero();
                else
                {
                    if (lrint(n) % 2 != 0) return oreal.neginf(); else return oreal.nan();
                }
            }
            return (n * sph_bessel_jn(n - 1, x, scaled) - (n + 1) * sph_bessel_jn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_prime/*' />
        public static Octuple sph_bessel_jn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_jn_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_prime/*' />
        public static Octuple sph_bessel_yn_prime(Octuple n, Octuple x, bool scaled = false)
        {
            if (!oreal.isinteger(n)) return oreal.nan();

            if (oreal.isnan(x)) return oreal.nan();
            if (oreal.isinf(x)) return oreal.zero();
            if (oreal.isneginf(x)) return oreal.zero();
            if (x == 0.0)
            {
                if (n == -2) return -1 / oreal.t(3);
                if (n < 0) return oreal.zero();
                else
                {
                    if (lrint(n) % 2 == 0) return oreal.inf(); else return oreal.nan();
                }
            }
            return (n * sph_bessel_yn(n - 1, x, scaled) - (n + 1) * sph_bessel_yn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_prime/*' />
        public static Octuple sph_bessel_yn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_yn_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in_prime/*' />
        public static Octuple sph_bessel_in_prime(Octuple n, Octuple x, bool scaled = false)
        {
            if (!oreal.isinteger(n)) return oreal.nan();

            if (oreal.isnan(x)) return oreal.nan();
            if (oreal.isinf(x)) return oreal.inf();
            if (oreal.isneginf(x))
            {
                if (lrint(n) % 2 == 0) return oreal.neginf(); else return oreal.inf();
            }
            if (x == 0.0)
            {
                if (n == 0) return oreal.zero();
                if (n < 0)
                {
                    if (lrint(n) % 2 != 0) return oreal.neginf(); else return oreal.nan();
                }
            }
            return (n * sph_bessel_in(n - 1, x, scaled) + (n + 1) * sph_bessel_in(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in_prime/*' />
        public static Octuple sph_bessel_in_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_in_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn_prime/*' />
        public static Octuple sph_bessel_kn_prime(Octuple n, Octuple x, bool scaled = false)
        {
            if (!oreal.isinteger(n)) return oreal.nan();

            if (oreal.isnan(x)) return oreal.nan();
            if (oreal.isinf(x)) return oreal.zero();
            if (oreal.isneginf(x)) return oreal.neginf();
            if (x == 0.0)
            {
                if (((n >= 0) && (lrint(n) % 2 == 0)) || ((n < 0) && (lrint(n) % 2 != 0))) return oreal.neginf();
                else return oreal.nan();
            }
            return -(n * sph_bessel_kn(n - 1, x, scaled) + (n + 1) * sph_bessel_kn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn_prime/*' />
        public static Octuple sph_bessel_kn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_kn_prime(t(n), t(x), scaled);
        }





        #endregion







        #region Hankel functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h1/*' />
        public static OctupleC hankel_h1(Octuple v, Octuple x)
        {
            return bessel_jv(v, x) + ocplx.onej() * bessel_yv(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h1/*' />
        public static OctupleC hankel_h1(dynamic v, dynamic x)
        {
            return hankel_h1(t(v), t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h2/*' />
        public static OctupleC hankel_h2(Octuple v, Octuple x)
        {
            return bessel_jv(v, x) - ocplx.onej() * bessel_yv(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h2/*' />
        public static OctupleC hankel_h2(dynamic v, dynamic x)
        {
            return hankel_h2(t(v), t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h1/*' />
        public static OctupleC sph_hankel_h1(int n, Octuple x)
        {
            return sph_bessel_jn(n, x) + ocplx.onej() * sph_bessel_yn(n, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h1/*' />
        public static OctupleC sph_hankel_h1(int n, dynamic x)
        {
            return sph_hankel_h1(n, t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h2/*' />
        public static OctupleC sph_hankel_h2(int n, Octuple x)
        {
            return sph_bessel_jn(n, x) - ocplx.onej() * sph_bessel_yn(n, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h2/*' />
        public static OctupleC sph_hankel_h2(int n, dynamic x)
        {
            return sph_hankel_h2(n, t(x));
        }






        #endregion






        #region Airy functions


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai/*' />
        public static Octuple airy_ai(Octuple x, bool scaled = false)
        {
            var res = new Octuple();
            Lib_OReal_AiryAi(res.mpPtr, x.mpPtr);
            if ((scaled) && (x > 0)) res *= exp((oreal.t(2) / oreal.t(3)) * x * sqrt(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_AiryAi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_AiryAi(IntPtr res, IntPtr x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai/*' />
        public static Octuple airy_ai(dynamic x, bool scaled = false)
        {
            return airy_ai(oreal.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi/*' />
        public static Octuple airy_bi(Octuple x, bool scaled = false)
        {
            var res = new Octuple();
            Lib_OReal_AiryBi(res.mpPtr, x.mpPtr);
            if ((scaled) && (x > 0)) res *= exp(-abs(oreal.t(2) / oreal.t(3) * (x * sqrt(x))));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_AiryBi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_AiryBi(IntPtr res, IntPtr x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi/*' />
        public static Octuple airy_bi(dynamic x, bool scaled = false)
        {
            return airy_bi(oreal.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai_prime/*' />
        public static Octuple airy_ai_prime(Octuple x, bool scaled = false)
        {
            var res = new Octuple();
            Lib_OReal_AiryAiPrime(res.mpPtr, x.mpPtr);
            if ((scaled) && (x > 0)) res *= exp((oreal.t(2) / oreal.t(3)) * x * sqrt(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_AiryAiPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_AiryAiPrime(IntPtr res, IntPtr x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai_prime/*' />
        public static Octuple airy_ai_prime(dynamic x, bool scaled = false)
        {
            return airy_ai_prime(oreal.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi_prime/*' />
        public static Octuple airy_bi_prime(Octuple x, bool scaled = false)
        {
            var res = new Octuple();
            Lib_OReal_AiryBiPrime(res.mpPtr, x.mpPtr);
            if ((scaled) && (x > 0)) res *= exp(-abs(oreal.t(2) / oreal.t(3) * (x * sqrt(x))));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_AiryBiPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_AiryBiPrime(IntPtr res, IntPtr x);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi_prime/*' />
        public static Octuple airy_bi_prime(dynamic x, bool scaled = false)
        {
            return airy_bi_prime(oreal.t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai_zero/*' />
        public static Octuple airy_ai_zero(int n)
        {
            var res = new Octuple();
            Lib_OReal_Aizero(res.mpPtr, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Aizero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Aizero(IntPtr res, int n);

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai_zero/*' />
        public static Octuple airy_bi_zero(int n)
        {
            var res = new Octuple();
            Lib_OReal_Bizero(res.mpPtr, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Bizero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Bizero(IntPtr res, int n);



        #endregion



        #region 1F1 Overview




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_1f1/*' />
        public static Octuple hyperg_1f1(Octuple a, Octuple b, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Hypergeo1F1(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Hypergeo1F1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Hypergeo1F1(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_1f1/*' />
        public static Octuple hyperg_1f1(dynamic a, dynamic b, dynamic x)
        {
            return hyperg_1f1(oreal.t(a), oreal.t(b), oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_1f1r/*' />
        public static Octuple hyperg_1f1r(Octuple a, Octuple b, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Hypergeo1F1r(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Hypergeo1F1r", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Hypergeo1F1r(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_1f1r/*' />
        public static Octuple hyperg_1f1r(dynamic a, dynamic b, dynamic x)
        {
            return hyperg_1f1r(oreal.t(a), oreal.t(b), oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/log_hyperg_1f1/*' />
        public static Octuple log_hyperg_1f1(Octuple a, Octuple b, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_LogHypergeo1F1(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LogHypergeo1F1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_LogHypergeo1F1(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/log_hyperg_1f1/*' />
        public static Octuple log_hyperg_1f1(dynamic a, dynamic b, dynamic x)
        {
            return log_hyperg_1f1(oreal.t(a), oreal.t(b), oreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hermite_h/*' />
        public static Octuple hermite_h(int n, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Hermite(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Hermite", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Hermite(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hermite_h/*' />
        public static Octuple hermite_h(int n, dynamic y)
        {
            return hermite_h(n, oreal.t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hermite_he/*' />
        public static Octuple hermite_he(int n, Octuple x)
        {
            return exp2(-n / 2) * hermite_h(n, x / sqrt(2));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hermite_he/*' />
        public static Octuple hermite_he(int n, dynamic x)
        {
            return hermite_he(n, oreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/laguerre_l/*' />
        public static Octuple laguerre_l(int n, int m, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_LaguerreM(res.mpPtr, n, m, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LaguerreM", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_LaguerreM(IntPtr res, int n, int m, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hermite_h/*' />
        public static Octuple laguerre_l(int n, int m, dynamic y)
        {
            return laguerre_l(n, m, oreal.t(y));
        }




        #endregion



        #region Exponential integrals and related functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/exp_integral_ei/*' />
        public static Octuple exp_integral_ei(Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Ei(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Ei", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Ei(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/exp_integral_ei/*' />
        public static Octuple exp_integral_ei(dynamic x)
        {
            return exp_integral_ei(oreal.t(x));
        }






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/exp_integral_en/*' />
        public static Octuple exp_integral_en(int n, Octuple x)
        {
            if (n < 0) return nan();
            var res = new Octuple();
            Lib_OReal_expint(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_expint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_expint(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/exp_integral_ei/*' />
        public static Octuple exp_integral_en(int n, dynamic x)
        {
            return exp_integral_en(n, t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp_integral_e1/*' />
        public static Octuple exp_integral_e1(Octuple z)
        {
            if (z < 0) return -exp_integral_ei(-z);
            else return exp_integral_en(1, z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp_integral_e1/*' />
        public static Octuple exp_integral_e1(dynamic z)
        {
            return exp_integral_e1(oreal.t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log_integral/*' />
        public static Octuple log_integral(Octuple z)
        {
            if (z < 0) return nan();
            if (z == 0) return zero();
            else return exp_integral_ei(log(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log_integral/*' />
        public static Octuple log_integral(dynamic z)
        {
            return log_integral(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh_integral/*' />
        public static Octuple cosh_integral(Octuple x)
        {
            return (exp_integral_ei(x) - exp_integral_e1(x)) / 2;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh_integral/*' />
        public static Octuple cosh_integral(dynamic z)
        {
            return cosh_integral(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh_integral/*' />
        public static Octuple sinh_integral(Octuple x)
        {
            return (exp_integral_ei(x) + exp_integral_e1(x)) / 2;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh_integral/*' />
        public static Octuple sinh_integral(dynamic z)
        {
            return sinh_integral(t(z));
        }






        #endregion





        #region 2F1-related orthogonal polynomials





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_t/*' />
        public static Octuple chebyshev_t(int n, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_ChebyshevT(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ChebyshevT", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ChebyshevT(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_t/*' />
        public static Octuple chebyshev_t(int n, dynamic y)
        {
            return chebyshev_t(n, oreal.t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_u/*' />
        public static Octuple chebyshev_u(int n, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_ChebyshevU(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ChebyshevU", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ChebyshevU(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_u/*' />
        public static Octuple chebyshev_u(int n, dynamic y)
        {
            return chebyshev_u(n, oreal.t(y));
        }






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_v/*' />
        public static Octuple chebyshev_v(int n, Octuple x)  // same as t_n(x)
        {
            if (x < 0.0)
            {
                int m = -1; if (n % 2 == 0) m = 1; // m = exp(i * n * pi)
                return m * chebyshev_w(n, -x);
            }
            else return sqrt(2 / (1 + x)) * chebyshev_t(2 * n + 1, sqrt((x + 1) / 2));
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_u/*' />
        public static Octuple chebyshev_v(int n, dynamic y)
        {
            return chebyshev_v(n, t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_w/*' />
        public static Octuple chebyshev_w(int n, Octuple x)  // same as u_n(x)
        {
            if (x < 0.0)
            {
                int m = -1; if (n % 2 == 0) m = 1; // m = exp(i * n * pi)
                return m * chebyshev_v(n, -x);
            }
            else return chebyshev_u(2 * n, sqrt((x + 1) / 2));
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_w/*' />
        public static Octuple chebyshev_w(int n, dynamic y)
        {
            return chebyshev_w(n, t(y));
        }







        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_p/*' />
        public static Octuple legendre_p(int n, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_LegendreP(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LegendreP", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_LegendreP(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_p/*' />
        public static Octuple legendre_p(int n, dynamic y)
        {
            return legendre_p(n, oreal.t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_q/*' />
        public static Octuple legendre_q(int n, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_LegendreQ(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LegendreQ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_LegendreQ(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_q/*' />
        public static Octuple legendre_q(int n, dynamic y)
        {
            return legendre_q(n, oreal.t(y));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_plm/*' />
        public static Octuple legendre_plm(int n, int m, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_LegendrePM(res.mpPtr, n, m, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LegendrePM", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_LegendrePM(IntPtr res, int n, int m, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_plm/*' />
        public static Octuple legendre_plm(int n, int m, dynamic y)
        {
            return legendre_plm(n, m, oreal.t(y));
        }







        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gegenbauer_c/*' />
        public static Octuple gegenbauer_c(int n, Octuple lambda1, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Gegenbauer(res.mpPtr, n, lambda1.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Gegenbauer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Gegenbauer(IntPtr res, int n, IntPtr lambda1, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gegenbauer_c/*' />
        public static Octuple gegenbauer_c(int n, dynamic lambda1, dynamic x)
        {
            return gegenbauer_c(n, t(lambda1), t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_p/*' />
        public static Octuple jacobi_p(int n, Octuple alpha, Octuple beta, Octuple x)
        {
            var res = new Octuple();
            Lib_OReal_Jacobi(res.mpPtr, n, alpha.mpPtr, beta.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Jacobi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Jacobi(IntPtr res, int n, IntPtr alpha, IntPtr beta, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_p/*' />
        public static Octuple jacobi_p(int n, dynamic alpha, dynamic beta, dynamic x)
        {
            return jacobi_p(n, t(alpha), t(beta), t(x));
        }











        internal static Octuple spherical_harmonic_r(int n, int m, Octuple theta, Octuple phi)
        {
            var res = new Octuple();
            Lib_OReal_SphericalHarmonicR(res.mpPtr, n, m, theta.mpPtr, phi.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_SphericalHarmonicR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_SphericalHarmonicR(IntPtr res, int n, int m, IntPtr theta, IntPtr phi);


        internal static Octuple spherical_harmonic_i(int n, int m, Octuple theta, Octuple phi)
        {
            var res = new Octuple();
            Lib_OReal_SphericalHarmonicI(res.mpPtr, n, m, theta.mpPtr, phi.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_SphericalHarmonicI", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_SphericalHarmonicI(IntPtr res, int n, int m, IntPtr theta, IntPtr phi);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/spherical_y/*' />
        public static OctupleC spherical_y(Octuple n, Octuple m, Octuple theta, Octuple phi)
        {
            return ocplx.t(spherical_harmonic_r(lrint(n), lrint(m), theta, phi),
                           spherical_harmonic_i(lrint(n), lrint(m), theta, phi));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/spherical_y/*' />
        public static OctupleC spherical_y(dynamic n, dynamic m, dynamic theta, dynamic phi)
        {
            return spherical_y(oreal.t(n), oreal.t(m), oreal.t(theta), oreal.t(phi));
        }




        #endregion



        #endregion





        #region Boost Distributions as classes


        #region Base classes

        public class BaseDistClass
        {
            internal static Octuple nil = zero();
            internal static int target = 1;
            //internal static Octuple a_;
            //internal static Octuple b_;
            //internal static Octuple c_;
            //internal static Octuple lambda1_;
            //internal static Octuple delta_;
            //internal static Octuple k_;
            //internal static Octuple m_;
            //internal static Octuple n_;
            //internal static Octuple p_;
            //internal static Octuple r_;
            //internal static Octuple mu_;
            //internal static Octuple sigma_;


            internal virtual Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                return res;
            }

            public static oreal ctx
            {
                get { return new oreal(); }
            }

            //public oreal ctx()
            //{
            //    return new oreal();
            //}


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/cdf/*' />
            public Octuple cdf(Octuple x)
            {
                target = 2;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/cdf/*' />
            public Octuple cdf(dynamic x)
            {
                target = 2;
                return BaseDist(oreal.t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/sf/*' />
            public Octuple sf(Octuple x)
            {
                target = 3;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/sf/*' />
            public Octuple sf(dynamic x)
            {
                target = 3;
                return BaseDist(oreal.t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/hf/*' />
            public Octuple hf(Octuple x)
            {
                target = 4;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/hf/*' />
            public Octuple hf(dynamic x)
            {
                target = 4;
                return BaseDist(oreal.t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/chf/*' />
            public Octuple chf(Octuple x)
            {
                target = 5;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/chf/*' />
            public Octuple chf(dynamic x)
            {
                target = 5;
                return BaseDist(oreal.t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/qtf/*' />
            public Octuple qtf(Octuple q)
            {
                target = 6;
                return BaseDist(q);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/qtf/*' />
            public Octuple qtf(dynamic q)
            {
                target = 6;
                return BaseDist(oreal.t(q));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/isf/*' />
            public Octuple isf(Octuple q)
            {
                target = 7;
                return BaseDist(q);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/isf/*' />
            public Octuple isf(dynamic q)
            {
                target = 7;
                return BaseDist(oreal.t(q));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/mean/*' />
            public Octuple mean()
            {
                target = 8;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/median/*' />
            public Octuple median()
            {
                target = 9;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/mode/*' />
            public Octuple mode()
            {
                target = 10;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/variance/*' />
            public Octuple variance()
            {
                target = 11;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/stdev/*' />
            public Octuple stdev()
            {
                target = 12;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/skewness/*' />
            public Octuple skewness()
            {
                target = 13;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/kurtosis/*' />
            public Octuple kurtosis()
            {
                target = 14;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/kurtosis_excess/*' />
            public Octuple kurtosis_excess()
            {
                target = 15;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/support_lower_endpoint/*' />
            public Octuple support_lower_endpoint()
            {
                target = 16;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/support_upper_endpoint/*' />
            public Octuple support_upper_endpoint()
            {
                target = 17;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/range_lower_endpoint/*' />
            public Octuple range_lower_endpoint()
            {
                target = 18;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/range_upper_endpoint/*' />
            public Octuple range_upper_endpoint()
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
            public Octuple pdf(Octuple x)
            {
                target = 1;
                return BaseDist(x);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/pdf/*' />
            public Octuple pdf(dynamic x)
            {
                target = 1;
                return BaseDist(oreal.t(x));
            }
        }


        public class BaseDistDiscreteClass : BaseDistClass
        {

            public bool IsContinuous()
            {
                return false;
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/pmf/*' />
            public Octuple pmf(Octuple x)
            {
                target = 1;
                return BaseDist(x);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/pmf/*' />
            public Octuple pmf(dynamic x)
            {
                target = 1;
                return BaseDist(oreal.t(x));
            }
        }


        #endregion



        #region Discrete (lattice) distribution functions



        #region BernoulliDist


        public class BernoulliDistClass : BaseDistDiscreteClass
        {
            Octuple p;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_BernoulliDist(target, res.mpPtr, xqp.mpPtr, p.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BernoulliDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_BernoulliDist(int target, IntPtr res, IntPtr xqp, IntPtr p);

            public BernoulliDistClass(Octuple _p)
            {
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BernoulliDist/*' />
        public static BernoulliDistClass dist_bernoulli(Octuple p)
        {
            return new BernoulliDistClass(p);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BernoulliDist/*' />
        public static BernoulliDistClass dist_bernoulli(dynamic p)
        {
            return dist_bernoulli(oreal.t(p));
        }

        #endregion



        #region GeometricDist


        public class GeometricDistClass : BaseDistDiscreteClass
        {
            Octuple p;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_GeometricDist(target, res.mpPtr, xqp.mpPtr, p.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GeometricDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_GeometricDist(int target, IntPtr res, IntPtr xqp, IntPtr p);

            public GeometricDistClass(Octuple _p)
            {
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GeometricDist/*' />
        public static GeometricDistClass dist_geometric(Octuple p)
        {
            return new GeometricDistClass(p);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GeometricDist/*' />
        public static GeometricDistClass dist_geometric(dynamic p)
        {
            return dist_geometric(oreal.t(p));
        }

        #endregion



        #region PoissonDist


        public class PoissonDistClass : BaseDistDiscreteClass
        {
            Octuple mu;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_PoissonDist(target, res.mpPtr, xqp.mpPtr, mu.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_PoissonDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_PoissonDist(int target, IntPtr res, IntPtr xqp, IntPtr mu);

            public PoissonDistClass(Octuple _mu)
            {
                mu = _mu;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/PoissonDist/*' />
        public static PoissonDistClass dist_poisson(Octuple mu)
        {
            return new PoissonDistClass(mu);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/PoissonDist/*' />
        public static PoissonDistClass dist_poisson(dynamic mu)
        {
            return dist_poisson(oreal.t(mu));
        }

        #endregion



        #region BinomialDist


        public class BinomialDistClass : BaseDistDiscreteClass
        {
            Octuple n;
            Octuple p;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_BinomialDist(target, res.mpPtr, xqp.mpPtr, n.mpPtr, p.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BinomialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_BinomialDist(int target, IntPtr res, IntPtr xqp, IntPtr n, IntPtr p);

            public BinomialDistClass(Octuple _n, Octuple _p)
            {
                n = _n;
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BinomialDist/*' />
        public static BinomialDistClass dist_binomial(Octuple n, Octuple p)
        {
            return new BinomialDistClass(n, p);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BinomialDist/*' />
        public static BinomialDistClass dist_binomial(dynamic n, dynamic p)
        {
            return dist_binomial(oreal.t(n), oreal.t(p));
        }

        #endregion



        #region NegBinomialDist


        public class NegBinomialDistClass : BaseDistDiscreteClass
        {
            Octuple r;
            Octuple p;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_NegBinomialDist(target, res.mpPtr, xqp.mpPtr, r.mpPtr, p.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_NegBinomialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_NegBinomialDist(int target, IntPtr res, IntPtr xqp, IntPtr r, IntPtr p);

            public NegBinomialDistClass(Octuple _r, Octuple _p)
            {
                r = _r;
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NegBinomialDist/*' />
        public static NegBinomialDistClass dist_negbinomial(Octuple r, Octuple p)
        {
            return new NegBinomialDistClass(r, p);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NegBinomialDist/*' />
        public static NegBinomialDistClass dist_negbinomial(dynamic r, dynamic p)
        {
            return dist_negbinomial(oreal.t(r), oreal.t(p));
        }

        #endregion



        #region HypergeometricDist


        public class HypergeometricDistClass : BaseDistDiscreteClass
        {
            internal UInt64 r__;
            internal UInt64 n__;
            internal UInt64 NN__;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_HypergeometricDist(target, res.mpPtr, xqp.mpPtr, r__, n__, NN__);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_HypergeometricDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_HypergeometricDist(int target, IntPtr res, IntPtr xqp, UInt64 r, UInt64 n, UInt64 NN);

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
        //    return dist_hypergeometric(oreal.t(r), oreal.t(n), oreal.t(NN));
        //}

        #endregion








        #endregion



        #region Closed form distributions, based on elementary functions



        #region ArcsineDist


        public class ArcsineDistClass : BaseDistContClass
        {
            Octuple a;
            Octuple b;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_ArcsineDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ArcsineDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_ArcsineDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public ArcsineDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ArcsineDist/*' />
        public static ArcsineDistClass dist_arcsine(Octuple a, Octuple b)
        {
            return new ArcsineDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ArcsineDist/*' />
        public static ArcsineDistClass dist_arcsine(dynamic a, dynamic b)
        {
            return dist_arcsine(oreal.t(a), oreal.t(b));
        }

        #endregion




        #region CauchyDist


        public class CauchyDistClass : BaseDistContClass
        {
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_CauchyDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_CauchyDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_CauchyDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public CauchyDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/CauchyDist/*' />
        public static CauchyDistClass dist_cauchy(Octuple a, Octuple b)
        {
            return new CauchyDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/CauchyDist/*' />
        public static CauchyDistClass dist_cauchy(dynamic a, dynamic b)
        {
            return dist_cauchy(oreal.t(a), oreal.t(b));
        }

        #endregion




        #region ExponentialDist


        public class ExponentialDistClass : BaseDistContClass
        {
            Octuple lambda1;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_ExponentialDist(target, res.mpPtr, xqp.mpPtr, lambda1.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ExponentialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_ExponentialDist(int target, IntPtr res, IntPtr xqp, IntPtr lambda1);

            public ExponentialDistClass(Octuple _lambda1)
            {
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExponentialDist/*' />
        public static ExponentialDistClass dist_exponential(Octuple lambda1)
        {
            return new ExponentialDistClass(lambda1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExponentialDist/*' />
        public static ExponentialDistClass dist_exponential(dynamic lambda1)
        {
            return dist_exponential(oreal.t(lambda1));
        }

        #endregion




        #region GumbelDist


        public class GumbelDistClass : BaseDistContClass
        {
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_GumbelDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GumbelDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_GumbelDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public GumbelDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GumbelDist/*' />
        public static GumbelDistClass dist_gumbel(Octuple a, Octuple b)
        {
            return new GumbelDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GumbelDist/*' />
        public static GumbelDistClass dist_gumbel(dynamic a, dynamic b)
        {
            return dist_gumbel(oreal.t(a), oreal.t(b));
        }

        #endregion



        #region HyperexponentialDist


        public class HyperexponentialDistClass : BaseDistContClass
        {
            private OctupleVec matProb_ = new OctupleVec();
            private OctupleVec matRate_ = new OctupleVec();

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_HyperexponentialDist(target, res.mpPtr, xqp.mpPtr, matProb_.mpPtr, matRate_.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_HyperexponentialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_HyperexponentialDist(int target, IntPtr res, IntPtr xqp, IntPtr Prob, IntPtr Rate);

            public HyperexponentialDistClass(OctupleVec Prob, OctupleVec Rate)
            {
                matProb_ = Prob;
                matRate_ = Rate;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/HyperexponentialDist/*' />
        public static HyperexponentialDistClass dist_hyperexponential(OctupleVec Prob, OctupleVec Rate)
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
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                Octuple res = t(0);
                Octuple pdf = t(0);
                Octuple sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    res = a * b * pow(xqp, a - 1);
                    Octuple temp = pow(-powm1(xqp, a), b - 1);
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

            public KumaraswamyDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_kumaraswamy/*' />
        public static KumaraswamyDistClass dist_kumaraswamy(Octuple a, Octuple b)
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
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_LaplaceDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LaplaceDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_LaplaceDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public LaplaceDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LaplaceDist/*' />
        public static LaplaceDistClass dist_laplace(Octuple a, Octuple b)
        {
            return new LaplaceDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LaplaceDist/*' />
        public static LaplaceDistClass dist_laplace(dynamic a, dynamic b)
        {
            return dist_laplace(oreal.t(a), oreal.t(b));
        }

        #endregion




        #region LogisticDist


        public class LogisticDistClass : BaseDistContClass
        {
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_LogisticDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LogisticDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_LogisticDist(int target, IntPtr res, IntPtr xqp, IntPtr loc, IntPtr scale);

            public LogisticDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LogisticDist/*' />
        public static LogisticDistClass dist_logistic(Octuple a, Octuple b)
        {
            return new LogisticDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LogisticDist/*' />
        public static LogisticDistClass dist_logistic(dynamic a, dynamic b)
        {
            return dist_logistic(oreal.t(a), oreal.t(b));
        }

        #endregion




        #region ParetoDist


        public class ParetoDistClass : BaseDistContClass
        {
            Octuple k;
            Octuple a;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_ParetoDist(target, res.mpPtr, xqp.mpPtr, k.mpPtr, a.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ParetoDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_ParetoDist(int target, IntPtr res, IntPtr xqp, IntPtr k, IntPtr a);

            public ParetoDistClass(Octuple _k, Octuple _a)
            {
                k = _k;
                a = _a;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ParetoDist/*' />
        public static ParetoDistClass dist_pareto(Octuple k, Octuple a)
        {
            return new ParetoDistClass(k, a);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ParetoDist/*' />
        public static ParetoDistClass dist_pareto(dynamic k, dynamic a)
        {
            return dist_pareto(oreal.t(k), oreal.t(a));
        }

        #endregion




        #region RayleighDist


        public class RayleighDistClass : BaseDistContClass
        {
            Octuple b;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_RayleighDist(target, res.mpPtr, xqp.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_RayleighDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_RayleighDist(int target, IntPtr res, IntPtr xqp, IntPtr b);

            public RayleighDistClass(Octuple _b)
            {
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RayleighDist/*' />
        public static RayleighDistClass dist_rayleigh(Octuple b)
        {
            return new RayleighDistClass(b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RayleighDist/*' />
        public static RayleighDistClass dist_rayleigh(dynamic b)
        {
            return dist_rayleigh(oreal.t(b));
        }

        #endregion




        #region TriangularDist


        public class TriangularDistClass : BaseDistContClass
        {
            Octuple a;
            Octuple m;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_TriangularDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, m.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_TriangularDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_TriangularDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr m, IntPtr b);

            public TriangularDistClass(Octuple _a, Octuple _m, Octuple _b)
            {
                a = _a;
                m = _m;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TriangularDist/*' />
        public static TriangularDistClass dist_triangular(Octuple a, Octuple m, Octuple b)
        {
            return new TriangularDistClass(a, m, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TriangularDist/*' />
        public static TriangularDistClass dist_triangular(dynamic a, dynamic m, dynamic b)
        {
            return dist_triangular(oreal.t(a), oreal.t(m), oreal.t(b));
        }

        #endregion




        #region UniformDist


        public class UniformDistClass : BaseDistContClass
        {
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_UniformDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_UniformDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_UniformDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public UniformDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/UniformDist/*' />
        public static UniformDistClass dist_uniform(Octuple a, Octuple b)
        {
            return new UniformDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/UniformDist/*' />
        public static UniformDistClass dist_uniform(dynamic a, dynamic b)
        {
            return dist_uniform(oreal.t(a), oreal.t(b));
        }

        #endregion




        #region WeibullDist


        public class WeibullDistClass : BaseDistContClass
        {
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_WeibullDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_WeibullDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_WeibullDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public WeibullDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WeibullDist/*' />
        public static WeibullDistClass dist_weibull(Octuple a, Octuple b)
        {
            return new WeibullDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WeibullDist/*' />
        public static WeibullDistClass dist_weibull(dynamic a, dynamic b)
        {
            return dist_weibull(oreal.t(a), oreal.t(b));
        }

        #endregion


        #endregion



        #region Closed form distributions, based on the error function


        #region LevyDist


        public class LevyDistClass : BaseDistContClass
        {
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                Octuple res = t(0);
                Octuple pdf = t(0);
                Octuple sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Octuple s = sqrt(b / (2 * pi()));
                    Octuple t = exp(-b / (2 * (xqp - a)));
                    Octuple u = pow(xqp - a, 1.5);
                    pdf = s * t / u;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    Octuple s = sqrt(b / (2 * (xqp - a)));
                    sf = erf(s);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            Octuple s = sqrt(b / (2 * (xqp - a)));
                            res = erfc(s); break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            Octuple s1 = erfc_inv(xqp);
                            s1 = 2 * s1 * s1;
                            res = a + b / s1; break;
                        } // qtf, Pinv
                    case 7:
                        {
                            Octuple s1 = erf_inv(xqp);
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

            public LevyDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_levy/*' />
        public static LevyDistClass dist_levy(Octuple a, Octuple b)
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
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_LognormalDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_LognormalDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_LognormalDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public LognormalDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LognormalDist/*' />
        public static LognormalDistClass dist_lognormal(Octuple a, Octuple b)
        {
            return new LognormalDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LognormalDist/*' />
        public static LognormalDistClass dist_lognormal(dynamic a, dynamic b)
        {
            return dist_lognormal(oreal.t(a), oreal.t(b));
        }

        #endregion




        #region MoyalDist


        public class MoyalDistClass : BaseDistContClass
        {
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                Octuple res = t(0);
                Octuple pdf = t(0);
                Octuple sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Octuple t1 = (xqp - a) / (2 * b);
                    Octuple t2 = t("0.5") * exp(-(xqp - a) / b);
                    Octuple s = b * sqrt(2 * pi());
                    pdf = exp(-t1 - t2) / s;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    Octuple s = exp(-(xqp - a) / (2 * b)) / sqrt(2);
                    sf = erf(s);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            Octuple s = exp(-(xqp - a) / (2 * b)) / sqrt(2);
                            res = erfc(s); break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            Octuple s1 = erfc_inv(xqp);
                            s1 = 2 * s1 * s1;
                            res = a - b * log(s1); break;
                        } // qtf, Pinv
                    case 7:
                        {
                            Octuple s1 = erf_inv(xqp);
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

            public MoyalDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_moyal/*' />
        public static MoyalDistClass dist_moyal(Octuple a, Octuple b)
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
            Octuple mu;
            Octuple sigma;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_NormalDist(target, res.mpPtr, xqp.mpPtr, mu.mpPtr, sigma.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_NormalDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_NormalDist(int target, IntPtr res, IntPtr xqp, IntPtr mu, IntPtr sigma);

            public NormalDistClass(Octuple _mu, Octuple _sigma)
            {
                mu = _mu;
                sigma = _sigma;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NormalDist/*' />
        public static NormalDistClass dist_normal(Octuple mu, Octuple sigma)
        {
            return new NormalDistClass(mu, sigma);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NormalDist/*' />
        public static NormalDistClass dist_normal(dynamic mu, dynamic sigma)
        {
            return dist_normal(oreal.t(mu), oreal.t(sigma));
        }

        #endregion




        #region SkewNormalDist


        public class SkewNormalDistClass : BaseDistContClass
        {
            Octuple a;
            Octuple b;
            Octuple c;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_SkewNormalDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr, c.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_SkewNormalDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_SkewNormalDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b, IntPtr c);

            public SkewNormalDistClass(Octuple _a, Octuple _b, Octuple _c)
            {
                a = _a;
                b = _b;
                c = _c;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SkewNormalDist/*' />
        public static SkewNormalDistClass dist_skewnormal(Octuple a, Octuple b, Octuple c)
        {
            return new SkewNormalDistClass(a, b, c);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SkewNormalDist/*' />
        public static SkewNormalDistClass dist_skewnormal(dynamic a, dynamic b, dynamic c)
        {
            return dist_skewnormal(oreal.t(a), oreal.t(b), oreal.t(c));
        }

        #endregion




        #region WaldDist
        // InverseGaussianDist

        public class WaldDistClass : BaseDistContClass
        {
            Octuple mu;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_WaldDist(target, res.mpPtr, xqp.mpPtr, mu.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_WaldDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_WaldDist(int target, IntPtr res, IntPtr xqp, IntPtr mu, IntPtr b);

            public WaldDistClass(Octuple _mu, Octuple _b)
            {
                mu = _mu;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WaldDist/*' />
        public static WaldDistClass dist_wald(Octuple mu, Octuple b)
        {
            return new WaldDistClass(mu, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WaldDist/*' />
        public static WaldDistClass dist_wald(dynamic mu, dynamic b)
        {
            return dist_wald(oreal.t(mu), oreal.t(b));
        }

        #endregion





        #endregion



        #region Closed form distributions, based on the incomplete gamma function



        #region ChiDist


        public class ChiDistClass : BaseDistContClass
        {
            Octuple n;
            internal override Octuple BaseDist(Octuple xqp)
            {
                Octuple res = t(0);
                Octuple pdf = t(0);
                Octuple sf = t(0);
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

            public ChiDistClass(Octuple _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_chi/*' />
        public static ChiDistClass dist_chi(Octuple n)
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
            Octuple n;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_Chi2Dist(target, res.mpPtr, xqp.mpPtr, n.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Chi2Dist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_Chi2Dist(int target, IntPtr res, IntPtr xqp, IntPtr n);

            public Chi2DistClass(Octuple _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2Dist/*' />
        public static Chi2DistClass dist_chi2(Octuple n)
        {
            return new Chi2DistClass(n);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2Dist/*' />
        public static Chi2DistClass dist_chi2(dynamic n)
        {
            return dist_chi2(oreal.t(n));
        }

        #endregion




        #region GammaDist


        public class GammaDistClass : BaseDistContClass
        {
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_GammaDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GammaDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_GammaDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public GammaDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GammaDist/*' />
        public static GammaDistClass dist_gamma(Octuple a, Octuple b)
        {
            return new GammaDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GammaDist/*' />
        public static GammaDistClass dist_gamma(dynamic a, dynamic b)
        {
            return dist_gamma(oreal.t(a), oreal.t(b));
        }

        #endregion




        #region InverseChi2Dist
        // a = df, b = scale

        public class InverseChi2DistClass : BaseDistContClass
        {
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_InverseChi2Dist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_InverseChi2Dist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_InverseChi2Dist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public InverseChi2DistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseChi2Dist/*' />
        public static InverseChi2DistClass dist_inverse_chi2(Octuple a, Octuple b)
        {
            return new InverseChi2DistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseChi2Dist/*' />
        public static InverseChi2DistClass dist_inverse_chi2(dynamic a, dynamic b)
        {
            return dist_inverse_chi2(oreal.t(a), oreal.t(b));
        }

        #endregion




        #region InverseGammaDist
        // a = df, b = scale

        public class InverseGammaDistClass : BaseDistContClass
        {
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_InverseGammaDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_InverseGammaDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_InverseGammaDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public InverseGammaDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseGammaDist/*' />
        public static InverseGammaDistClass dist_inverse_gamma(Octuple a, Octuple b)
        {
            return new InverseGammaDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseGammaDist/*' />
        public static InverseGammaDistClass dist_inverse_gamma(dynamic a, dynamic b)
        {
            return dist_inverse_gamma(oreal.t(a), oreal.t(b));
        }

        #endregion




        #region MaxwellDist


        public class MaxwellDistClass : BaseDistContClass
        {
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                Octuple res = t(0);
                Octuple pdf = t(0);
                Octuple sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Octuple s = sqrt(2 / pi());
                    Octuple t = (xqp * xqp) / (b * b * b);
                    Octuple u = exp(-(xqp * xqp) / (2 * b * b));
                    pdf = s * t * u;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    Octuple n = t(1.5);
                    Octuple t2 = (xqp * xqp) / (2 * b * b);
                    sf = gamma_q(n, t2);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            Octuple n = t(1.5);
                            Octuple t2 = (xqp * xqp) / (2 * b * b);
                            res = gamma_p(n, t2);
                            break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            Octuple n = t(1.5);
                            Octuple t2 = (xqp * xqp) / (2 * b * b);
                            res = b * sqrt(2 * gamma_p_inv(n, xqp));
                            break;
                        } // qtf, Pinv
                    case 7:
                        {
                            Octuple n = t(1.5);
                            Octuple t2 = (xqp * xqp) / (2 * b * b);
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

            public MaxwellDistClass(Octuple _b)
            {
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_maxwell/*' />
        public static MaxwellDistClass dist_maxwell(Octuple b)
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
            Octuple m;
            Octuple w;
            internal override Octuple BaseDist(Octuple xqp)
            {
                Octuple res = t(0);
                Octuple pdf = t(0);
                Octuple sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Octuple s = exp(-m * xqp * xqp / w) * 2 * pow(m / w, m) * pow(xqp, 2 * m - 1);
                    Octuple t = gamma(m);
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

            public NakagamiDistClass(Octuple _m, Octuple _w)
            {
                m = _m;
                w = _w;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_nakagami/*' />
        public static NakagamiDistClass dist_nakagami(Octuple m, Octuple w)
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
            Octuple a;
            Octuple b;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_BetaDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BetaDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_BetaDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public BetaDistClass(Octuple _a, Octuple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaDist/*' />
        public static BetaDistClass dist_beta(Octuple a, Octuple b)
        {
            return new BetaDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaDist/*' />
        public static BetaDistClass dist_beta(dynamic a, dynamic b)
        {
            return dist_beta(oreal.t(a), oreal.t(b));
        }

        #endregion



        #region FisherFDist


        public class FisherFDistClass : BaseDistContClass
        {
            Octuple m;
            Octuple n;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_FisherFDist(target, res.mpPtr, xqp.mpPtr, m.mpPtr, n.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_FisherFDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_FisherFDist(int target, IntPtr res, IntPtr xqp, IntPtr m, IntPtr n);

            public FisherFDistClass(Octuple _m, Octuple _n)
            {
                m = _m;
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherFDist/*' />
        public static FisherFDistClass dist_fisher_f(Octuple m, Octuple n)
        {
            return new FisherFDistClass(m, n);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherFDist/*' />
        public static FisherFDistClass dist_fisher_f(dynamic m, dynamic n)
        {
            return dist_fisher_f(oreal.t(m), oreal.t(n));
        }

        #endregion



        #region StudentTDist


        public class StudentTDistClass : BaseDistContClass
        {
            Octuple n;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_StudentTDist(target, res.mpPtr, xqp.mpPtr, n.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_StudentTDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_StudentTDist(int target, IntPtr res, IntPtr xqp, IntPtr n);

            public StudentTDistClass(Octuple _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTDist/*' />
        public static StudentTDistClass dist_student_t(Octuple n)
        {
            return new StudentTDistClass(n);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTDist/*' />
        public static StudentTDistClass dist_student_t(dynamic n)
        {
            return dist_student_t(oreal.t(n));
        }

        #endregion


        #endregion



        #region Non-central distribution functions


        #region Chi2NcDist


        public class Chi2NcDistClass : BaseDistContClass
        {
            Octuple n;
            Octuple lambda1;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_Chi2NcDist(target, res.mpPtr, xqp.mpPtr, n.mpPtr, lambda1.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Chi2NcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_Chi2NcDist(int target, IntPtr res, IntPtr xqp, IntPtr n, IntPtr lambda1);

            public Chi2NcDistClass(Octuple _n, Octuple _lambda1)
            {
                n = _n;
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2NcDist/*' />
        public static Chi2NcDistClass dist_chi2_nc(Octuple n, Octuple lambda1)
        {
            return new Chi2NcDistClass(n, lambda1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2NcDist/*' />
        public static Chi2NcDistClass dist_chi2_nc(dynamic n, dynamic lambda1)
        {
            return dist_chi2_nc(oreal.t(n), oreal.t(lambda1));
        }

        #endregion



        #region StudentTNcDist


        public class StudentTNcDistClass : BaseDistContClass
        {
            Octuple n;
            Octuple delta;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_StudentTNcDist(target, res.mpPtr, xqp.mpPtr, n.mpPtr, delta.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_StudentTNcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_StudentTNcDist(int target, IntPtr res, IntPtr xqp, IntPtr n, IntPtr delta);

            public StudentTNcDistClass(Octuple _n, Octuple _delta)
            {
                n = _n;
                delta = _delta;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTNcDist/*' />
        public static StudentTNcDistClass dist_student_t_nc(Octuple n, Octuple delta)
        {
            return new StudentTNcDistClass(n, delta);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTNcDist/*' />
        public static StudentTNcDistClass dist_student_t_nc(dynamic n, dynamic delta)
        {
            return dist_student_t_nc(oreal.t(n), oreal.t(delta));
        }

        #endregion



        #region FisherFNcDist


        public class FisherFNcDistClass : BaseDistContClass
        {
            Octuple m;
            Octuple n;
            Octuple lambda1;

            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_FisherNcDist(target, res.mpPtr, xqp.mpPtr, m.mpPtr, n.mpPtr, lambda1.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_FisherNcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_FisherNcDist(int target, IntPtr res, IntPtr xqp, IntPtr m, IntPtr n, IntPtr lambda1);

            public FisherFNcDistClass(Octuple _m, Octuple _n, Octuple _lambda1)
            {
                m = _m;
                n = _n;
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherNcDist/*' />
        public static FisherFNcDistClass dist_fisher_f_nc(Octuple m, Octuple n, Octuple lambda1)
        {
            return new FisherFNcDistClass(m, n, lambda1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherNcDist/*' />
        public static FisherFNcDistClass dist_fisher_f_nc(dynamic m, dynamic n, dynamic lambda1)
        {
            return dist_fisher_f_nc(oreal.t(m), oreal.t(n), oreal.t(lambda1));
        }

        #endregion



        #region BetaNcDist


        public class BetaNcDistClass : BaseDistContClass
        {
            Octuple a;
            Octuple b;
            Octuple lambda1;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_BetaNcDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr, lambda1.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BetaNcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_BetaNcDist(int target, IntPtr res, IntPtr xqp, IntPtr nu, IntPtr mu, IntPtr lambda1);

            public BetaNcDistClass(Octuple _a, Octuple _b, Octuple _lambda1)
            {
                a = _a;
                b = _b;
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaNcDist/*' />
        public static BetaNcDistClass dist_beta_nc(Octuple a, Octuple b, Octuple lambda1)
        {
            return new BetaNcDistClass(a, b, lambda1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaNcDist/*' />
        public static BetaNcDistClass dist_beta_nc(dynamic a, dynamic b, dynamic lambda1)
        {
            return dist_beta_nc(oreal.t(a), oreal.t(b), oreal.t(lambda1));
        }

        #endregion



        #endregion



        #region Miscellaneous continuous distributions



        #region KolmogorovSmirnovDist


        public class KolmogorovSmirnovDistClass : BaseDistContClass
        {
            Octuple n;
            internal override Octuple BaseDist(Octuple xqp)
            {
                var res = new Octuple();
                Lib_OReal_KolmogorovSmirnovDist(target, res.mpPtr, xqp.mpPtr, n.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_KolmogorovSmirnovDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_OReal_KolmogorovSmirnovDist(int target, IntPtr res, IntPtr xqp, IntPtr a);

            public KolmogorovSmirnovDistClass(Octuple _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/KolmogorovSmirnovDist/*' />
        public static KolmogorovSmirnovDistClass dist_kolmogorov_smirnov(Octuple n)
        {
            return new KolmogorovSmirnovDistClass(n);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/KolmogorovSmirnovDist/*' />
        public static KolmogorovSmirnovDistClass dist_kolmogorov_smirnov(dynamic n)
        {
            return dist_kolmogorov_smirnov(t(n));
        }

        #endregion



        #endregion



        #endregion




        #region Boost Calculus


        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Set", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Set(IntPtr res, IntPtr x);







        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BracketRoot/*' />
        public static Tuple<Octuple, Octuple, int> BracketRoot(cb1SOctuple1S f, dynamic guess, dynamic factor, bool is_rising, int get_digits, uint maxit)
        {
            return BracketRoot(f, oreal.t(guess), oreal.t(factor), is_rising, get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BracketRoot/*' />
        public static Tuple<Octuple, Octuple, int> BracketRoot(cb1SOctuple1S f, Octuple guess, Octuple factor, bool is_rising, int get_digits, uint maxit)
        {
            var OBracketRoot1 = new OBracketRoot(f, guess, factor, is_rising, get_digits, maxit);
            return OBracketRoot1.Find();
        }
        internal class OBracketRoot
        {
            private cb1SOctuple1S F1_;
            private Octuple guess_;
            private Octuple factor_;
            private bool is_rising_;
            private int get_digits_;
            private uint maxit_;
            private Octuple X1 = new Octuple();
            private Octuple Y1 = new Octuple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_OReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_OReal_Set(fxPtr, Y1.mpPtr);
            }
            public OBracketRoot(cb1SOctuple1S F1, Octuple guess, Octuple factor, bool is_rising, int get_digits, uint maxit)
            {
                F1_ = F1;
                guess_ = guess;
                factor_ = factor;
                is_rising_ = is_rising;
                get_digits_ = get_digits;
                maxit_ = maxit;
            }
            public Tuple<Octuple, Octuple, int> Find()
            {
                var res1 = new Octuple();
                var res2 = new Octuple();
                var iter = 0;
                Lib_OReal_BracketRoot(res1.mpPtr, res2.mpPtr, ref iter, funcptr1, guess_.mpPtr, factor_.mpPtr, is_rising_, get_digits_, maxit_);
                return new Tuple<Octuple, Octuple, int>(res1, res2, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_BracketRoot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_BracketRoot(IntPtr res1, IntPtr res2, ref int iter, cbProc2Ptr f, IntPtr guess, IntPtr factor, bool is_rising, int get_digits, uint maxit);





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NewtonRaphson/*' />
        public static Tuple<Octuple, int> NewtonRaphson(cb1SOctuple1S f, cb1SOctuple1S df, dynamic guess, dynamic xmin, dynamic xmax, int get_digits, uint maxit)
        {
            return NewtonRaphson(f, df, oreal.t(guess), oreal.t(xmin), oreal.t(xmax), get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NewtonRaphson/*' />
        public static Tuple<Octuple, int> NewtonRaphson(cb1SOctuple1S f, cb1SOctuple1S df, Octuple guess, Octuple xmin, Octuple xmax, int get_digits, uint maxit)
        {
            var ONewtonRaphson1 = new ONewtonRaphson(f, df, guess, xmin, xmax, get_digits, maxit);
            return ONewtonRaphson1.Find();
        }
        internal class ONewtonRaphson
        {
            private cb1SOctuple1S F1_;
            private cb1SOctuple1S DF1_;
            private Octuple guess_;
            private Octuple xmin_;
            private Octuple xmax_;
            private int get_digits_;
            private uint maxit_;
            private Octuple X1 = new Octuple();
            private Octuple Y1 = new Octuple();
            private Octuple DX1 = new Octuple();
            private Octuple DY1 = new Octuple();
            public void funcptr0(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_OReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_OReal_Set(fxPtr, Y1.mpPtr);
            }
            public void funcptr1(IntPtr dxPtr, IntPtr dfxPtr)
            {
                Lib_OReal_Set(DX1.mpPtr, dxPtr);
                DY1 = DF1_(DX1);
                Lib_OReal_Set(dfxPtr, DY1.mpPtr);
            }
            public ONewtonRaphson(cb1SOctuple1S F1, cb1SOctuple1S DF1, Octuple guess, Octuple xmin, Octuple xmax, int get_digits, uint maxit)
            {
                F1_ = F1;
                DF1_ = DF1;
                guess_ = guess;
                xmin_ = xmin;
                xmax_ = xmax;
                get_digits_ = get_digits;
                maxit_ = maxit;
            }
            public Tuple<Octuple, int> Find()
            {
                var res1 = new Octuple();
                var iter = 0;
                Lib_OReal_NewtonRaphson(res1.mpPtr, ref iter, funcptr0, funcptr1, guess_.mpPtr, xmin_.mpPtr, xmax_.mpPtr, get_digits_, maxit_);
                return new Tuple<Octuple, int>(res1, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_NewtonRaphson", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_NewtonRaphson(IntPtr res, ref int iter, cbProc2Ptr f1, cbProc2Ptr df1, IntPtr guess, IntPtr xmin, IntPtr xmax, int get_digits, uint maxit);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Halley/*' />
        public static Tuple<Octuple, int> Halley(cb1SOctuple1S f, cb1SOctuple1S df1, cb1SOctuple1S df2, dynamic guess, dynamic xmin, dynamic xmax, int get_digits, uint maxit)
        {
            return Halley(f, df1, df2, oreal.t(guess), oreal.t(xmin), oreal.t(xmax), get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Halley/*' />
        public static Tuple<Octuple, int> Halley(cb1SOctuple1S f, cb1SOctuple1S df1, cb1SOctuple1S df2, Octuple guess, Octuple xmin, Octuple xmax, int get_digits, uint maxit)
        {
            var OHalley1 = new OHalley(f, df1, df2, guess, xmin, xmax, get_digits, maxit);
            return OHalley1.Find();
        }
        internal class OHalley
        {
            private cb1SOctuple1S F1_;
            private cb1SOctuple1S DF1_;
            private cb1SOctuple1S DF2_;
            private Octuple guess_;
            private Octuple xmin_;
            private Octuple xmax_;
            private int get_digits_;
            private uint maxit_;
            private Octuple X1 = new Octuple();
            private Octuple Y1 = new Octuple();
            private Octuple DX1 = new Octuple();
            private Octuple DY1 = new Octuple();
            private Octuple D2X1 = new Octuple();
            private Octuple D2Y1 = new Octuple();
            public void funcptr0(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_OReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_OReal_Set(fxPtr, Y1.mpPtr);
            }
            public void funcptr1(IntPtr dxPtr, IntPtr dfxPtr)
            {
                Lib_OReal_Set(DX1.mpPtr, dxPtr);
                DY1 = DF1_(DX1);
                Lib_OReal_Set(dfxPtr, DY1.mpPtr);
            }
            public void funcptr2(IntPtr d2xPtr, IntPtr d2fxPtr)
            {
                Lib_OReal_Set(D2X1.mpPtr, d2xPtr);
                D2Y1 = DF2_(DX1);
                Lib_OReal_Set(d2fxPtr, D2Y1.mpPtr);
            }
            public OHalley(cb1SOctuple1S F1, cb1SOctuple1S DF1, cb1SOctuple1S DF2, Octuple guess, Octuple xmin, Octuple xmax, int get_digits, uint maxit)
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
            public Tuple<Octuple, int> Find()
            {
                var res1 = new Octuple();
                var iter = 0;
                Lib_OReal_Halley(res1.mpPtr, ref iter, funcptr0, funcptr1, funcptr2, guess_.mpPtr, xmin_.mpPtr, xmax_.mpPtr, get_digits_, maxit_);
                return new Tuple<Octuple, int>(res1, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Halley", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Halley(IntPtr res, ref int iter, cbProc2Ptr f1, cbProc2Ptr df1, cbProc2Ptr df2, IntPtr guess, IntPtr xmin, IntPtr xmax, int get_digits, uint maxit);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Schroder/*' />
        public static Tuple<Octuple, int> Schroder(cb1SOctuple1S f, cb1SOctuple1S df1, cb1SOctuple1S df2, dynamic guess, dynamic xmin, dynamic xmax, int get_digits, uint maxit)
        {
            return Schroder(f, df1, df2, oreal.t(guess), oreal.t(xmin), oreal.t(xmax), get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Schroder/*' />
        public static Tuple<Octuple, int> Schroder(cb1SOctuple1S f, cb1SOctuple1S df1, cb1SOctuple1S df2, Octuple guess, Octuple xmin, Octuple xmax, int get_digits, uint maxit)
        {
            var OSchroder1 = new OSchroder(f, df1, df2, guess, xmin, xmax, get_digits, maxit);
            return OSchroder1.Find();
        }
        internal class OSchroder
        {
            private cb1SOctuple1S F1_;
            private cb1SOctuple1S DF1_;
            private cb1SOctuple1S DF2_;
            private Octuple guess_;
            private Octuple xmin_;
            private Octuple xmax_;
            private int get_digits_;
            private uint maxit_;
            private Octuple X1 = new Octuple();
            private Octuple Y1 = new Octuple();
            private Octuple DX1 = new Octuple();
            private Octuple DY1 = new Octuple();
            private Octuple D2X1 = new Octuple();
            private Octuple D2Y1 = new Octuple();
            public void funcptr0(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_OReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_OReal_Set(fxPtr, Y1.mpPtr);
            }
            public void funcptr1(IntPtr dxPtr, IntPtr dfxPtr)
            {
                Lib_OReal_Set(DX1.mpPtr, dxPtr);
                DY1 = DF1_(DX1);
                Lib_OReal_Set(dfxPtr, DY1.mpPtr);
            }
            public void funcptr2(IntPtr d2xPtr, IntPtr d2fxPtr)
            {
                Lib_OReal_Set(D2X1.mpPtr, d2xPtr);
                D2Y1 = DF2_(DX1);
                Lib_OReal_Set(d2fxPtr, D2Y1.mpPtr);
            }
            public OSchroder(cb1SOctuple1S F1, cb1SOctuple1S DF1, cb1SOctuple1S DF2, Octuple guess, Octuple xmin, Octuple xmax, int get_digits, uint maxit)
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
            public Tuple<Octuple, int> Find()
            {
                var res1 = new Octuple();
                var iter = 0;
                Lib_OReal_Schroder(res1.mpPtr, ref iter, funcptr0, funcptr1, funcptr2, guess_.mpPtr, xmin_.mpPtr, xmax_.mpPtr, get_digits_, maxit_);
                return new Tuple<Octuple, int>(res1, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Schroder", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Schroder(IntPtr res, ref int iter, cbProc2Ptr f1, cbProc2Ptr df1, cbProc2Ptr df2, IntPtr guess, IntPtr xmin, IntPtr xmax, int get_digits, uint maxit);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BrentMinimum/*' />
        public static Tuple<Octuple, Octuple, int> Brent_Minimum(cb1SOctuple1S f, dynamic bracket_min, dynamic bracket_max, int bits, uint maxit)
        {
            return Brent_Minimum(f, oreal.t(bracket_min), oreal.t(bracket_max), bits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BrentMinimum/*' />
        public static Tuple<Octuple, Octuple, int> Brent_Minimum(cb1SOctuple1S f, Octuple bracket_min, Octuple bracket_max, int bits, uint maxit)
        {
            var OBrent_Minimum1 = new OBrent_Minimum(f, bracket_min, bracket_max, bits, maxit);
            return OBrent_Minimum1.Find();
        }
        internal class OBrent_Minimum
        {
            private cb1SOctuple1S F1_;
            private Octuple bracket_min_;
            private Octuple bracket_max_;
            private int bits_;
            private uint maxit_;
            private Octuple X1 = new Octuple();
            private Octuple Y1 = new Octuple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_OReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_OReal_Set(fxPtr, Y1.mpPtr);
            }
            public OBrent_Minimum(cb1SOctuple1S F1, Octuple bracket_min, Octuple bracket_max, int bits, uint maxit)
            {
                F1_ = F1;
                bracket_min_ = bracket_min;
                bracket_max_ = bracket_max;
                bits_ = bits;
                maxit_ = maxit;
            }
            public Tuple<Octuple, Octuple, int> Find()
            {
                var result = new Octuple();
                var resultFx = new Octuple();
                var iter = 0;
                Lib_OReal_Brent_Minimum(result.mpPtr, resultFx.mpPtr, ref iter, funcptr1, bracket_min_.mpPtr, bracket_max_.mpPtr, bits_, maxit_);
                return new Tuple<Octuple, Octuple, int>(result, resultFx, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Brent_Minimum", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Brent_Minimum(IntPtr res, IntPtr resFx, ref int iter, cbProc2Ptr f, IntPtr bracket_min, IntPtr bracket_max, int bits, uint maxit);


        // ******************************************************************************************************************************************************************************************************************



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Trapezoidal/*' />
        public static Tuple<Octuple, Octuple, Octuple> Trapezoidal(cb1SOctuple1S f, dynamic a, dynamic b, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return Trapezoidal(f, oreal.t(a), oreal.t(b), oreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Trapezoidal/*' />
        public static Tuple<Octuple, Octuple, Octuple> Trapezoidal(cb1SOctuple1S f, Octuple a, Octuple b, Octuple tol, uint max_refinements = 12)
        {
            var OTrapezoidal1 = new OTrapezoidal(f, a, b);
            return OTrapezoidal1.Integrate();
        }
        internal class OTrapezoidal
        {
            private cb1SOctuple1S F1_;
            private Octuple a_;
            private Octuple b_;
            //private Octuple tol_;
            private Octuple X1 = new Octuple();
            private Octuple Y1 = new Octuple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_OReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_OReal_Set(fxPtr, Y1.mpPtr);
            }
            public OTrapezoidal(cb1SOctuple1S F1, Octuple a, Octuple b)
            {
                F1_ = F1;
                a_ = a;
                b_ = b;
            }
            public Tuple<Octuple, Octuple, Octuple> Integrate()
            {
                Octuple res1 = new Octuple(), res2 = new Octuple(), res3 = new Octuple();
                Lib_OReal_Trapezoidal(res1.mpPtr, res2.mpPtr, res3.mpPtr, funcptr1, a_.mpPtr, b_.mpPtr);
                return new Tuple<Octuple, Octuple, Octuple>(res1, res2, res3);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Trapezoidal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Trapezoidal(IntPtr res1, IntPtr res2, IntPtr res3, cbProc2Ptr f, IntPtr a, IntPtr b);





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussLegendre/*' />
        public static Tuple<Octuple, Octuple> GaussLegendre(cb1SOctuple1S f, dynamic a, dynamic b)
        {
            return GaussLegendre(f, oreal.t(a), oreal.t(b));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussLegendre/*' />
        public static Tuple<Octuple, Octuple> GaussLegendre(cb1SOctuple1S f, Octuple a, Octuple b)
        {
            var OGaussLegendre1 = new OGaussLegendre(f, a, b);
            return OGaussLegendre1.Integrate();
        }
        internal class OGaussLegendre
        {
            private cb1SOctuple1S F1_;
            private Octuple a_;
            private Octuple b_;
            private Octuple X1 = new Octuple();
            private Octuple Y1 = new Octuple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_OReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_OReal_Set(fxPtr, Y1.mpPtr);
            }
            public OGaussLegendre(cb1SOctuple1S F1, Octuple a, Octuple b)
            {
                F1_ = F1;
                a_ = a;
                b_ = b;
            }
            public Tuple<Octuple, Octuple> Integrate()
            {
                Octuple res1 = new Octuple(), res3 = new Octuple();
                Lib_OReal_GaussLegendre(res1.mpPtr, res3.mpPtr, funcptr1, a_.mpPtr, b_.mpPtr);
                return new Tuple<Octuple, Octuple>(res1, res3);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GaussLegendre", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_GaussLegendre(IntPtr res1, IntPtr res3, cbProc2Ptr f, IntPtr a, IntPtr b);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussKronrod/*' />
        public static Tuple<Octuple, Octuple, Octuple> GaussKronrod(cb1SOctuple1S f, dynamic a, dynamic b, dynamic tol = null, uint max_depth = 12)
        {
            if (tol == null) { tol = t(0); }
            return GaussKronrod(f, oreal.t(a), oreal.t(b), oreal.t(tol), max_depth);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussKronrod/*' />
        public static Tuple<Octuple, Octuple, Octuple> GaussKronrod(cb1SOctuple1S f, Octuple a, Octuple b, Octuple tol, uint max_depth = 12)
        {
            var OGaussKronrod1 = new OGaussKronrod(f, a, b);
            return OGaussKronrod1.Integrate();
        }
        internal class OGaussKronrod
        {
            private cb1SOctuple1S F1_;
            private Octuple a_;
            private Octuple b_;
            //private Octuple tol_;
            private Octuple X1 = new Octuple();
            private Octuple Y1 = new Octuple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_OReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_OReal_Set(fxPtr, Y1.mpPtr);
            }
            public OGaussKronrod(cb1SOctuple1S F1, Octuple a, Octuple b)
            {
                F1_ = F1;
                a_ = a;
                b_ = b;
            }
            public Tuple<Octuple, Octuple, Octuple> Integrate()
            {
                Octuple res1 = new Octuple(), res2 = new Octuple(), res3 = new Octuple();
                Lib_OReal_GaussKronrod(res1.mpPtr, res2.mpPtr, res3.mpPtr, funcptr1, a_.mpPtr, b_.mpPtr);
                return new Tuple<Octuple, Octuple, Octuple>(res1, res2, res3);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_GaussKronrod", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_GaussKronrod(IntPtr res1, IntPtr res2, IntPtr res3, cbProc2Ptr f, IntPtr a, IntPtr b);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TanhSinh/*' />
        public static Tuple<Octuple, Octuple, Octuple, int> TanhSinh(cb1SOctuple1S f, dynamic a, dynamic b, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return TanhSinh(f, oreal.t(a), oreal.t(b), oreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TanhSinh/*' />
        public static Tuple<Octuple, Octuple, Octuple, int> TanhSinh(cb1SOctuple1S f, Octuple a, Octuple b, Octuple tol, uint max_refinements = 12)
        {
            var OTanhSinh1 = new OTanhSinh(f, a, b);
            return OTanhSinh1.Integrate();
        }
        internal class OTanhSinh
        {
            private cb1SOctuple1S F1_;
            private Octuple a_;
            private Octuple b_;
            private Octuple X1 = new Octuple();
            private Octuple Y1 = new Octuple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_OReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_OReal_Set(fxPtr, Y1.mpPtr);
            }
            public OTanhSinh(cb1SOctuple1S F1, Octuple a, Octuple b)
            {
                F1_ = F1;
                a_ = a;
                b_ = b;
            }
            public Tuple<Octuple, Octuple, Octuple, int> Integrate()
            {
                Octuple res1 = new Octuple(), res2 = new Octuple(), res3 = new Octuple();
                var levels = 0;
                Lib_OReal_TanhSinh(res1.mpPtr, res2.mpPtr, res3.mpPtr, ref levels, funcptr1, a_.mpPtr, b_.mpPtr);
                return new Tuple<Octuple, Octuple, Octuple, int>(res1, res2, res3, levels);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_TanhSinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_TanhSinh(IntPtr res1, IntPtr res2, IntPtr res3, ref int levels, cbProc2Ptr f, IntPtr a, IntPtr b);




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SinhSinh/*' />
        public static Tuple<Octuple, Octuple, Octuple, int> SinhSinh(cb1SOctuple1S f, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return SinhSinh(f, oreal.t(tol), max_refinements);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SinhSinh/*' />
        public static Tuple<Octuple, Octuple, Octuple, int> SinhSinh(cb1SOctuple1S f, Octuple tol, uint max_refinements = 12)
        {
            var OSinhSinh1 = new OSinhSinh(f);
            return OSinhSinh1.Integrate();
        }
        internal class OSinhSinh
        {
            private cb1SOctuple1S F1_;
            private Octuple X1 = new Octuple();
            private Octuple Y1 = new Octuple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_OReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_OReal_Set(fxPtr, Y1.mpPtr);
            }
            public OSinhSinh(cb1SOctuple1S F1)
            {
                F1_ = F1;
            }
            public Tuple<Octuple, Octuple, Octuple, int> Integrate()
            {
                Octuple res1 = new Octuple(), res2 = new Octuple(), res3 = new Octuple();
                var levels = 0;
                Lib_OReal_SinhSinh(res1.mpPtr, res2.mpPtr, res3.mpPtr, ref levels, funcptr1);
                return new Tuple<Octuple, Octuple, Octuple, int>(res1, res2, res3, levels);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_SinhSinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_SinhSinh(IntPtr res1, IntPtr res2, IntPtr res3, ref int levels, cbProc2Ptr f);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExpSinh/*' />
        public static Tuple<Octuple, Octuple, Octuple, int> ExpSinh(cb1SOctuple1S f, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return ExpSinh(f, oreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExpSinh/*' />
        public static Tuple<Octuple, Octuple, Octuple, int> ExpSinh(cb1SOctuple1S f, Octuple tol, uint max_refinements = 12)
        {
            var OExpSinh1 = new OExpSinh(f);
            return OExpSinh1.Integrate();
        }
        internal class OExpSinh
        {
            private cb1SOctuple1S F1_;
            private Octuple X1 = new Octuple();
            private Octuple Y1 = new Octuple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_OReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_OReal_Set(fxPtr, Y1.mpPtr);
            }
            public OExpSinh(cb1SOctuple1S F1)
            {
                F1_ = F1;
            }
            public Tuple<Octuple, Octuple, Octuple, int> Integrate()
            {
                Octuple res1 = new Octuple(), res2 = new Octuple(), res3 = new Octuple();
                var levels = 0;
                Lib_OReal_ExpSinh(res1.mpPtr, res2.mpPtr, res3.mpPtr, ref levels, funcptr1);
                return new Tuple<Octuple, Octuple, Octuple, int>(res1, res2, res3, levels);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_ExpSinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_ExpSinh(IntPtr res1, IntPtr res2, IntPtr res3, ref int levels, cbProc2Ptr f);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/OouraCos/*' />
        public static Tuple<Octuple, Octuple> Ooura_Cos(cb1SOctuple1S f)
        {
            var OOoura_Cos1 = new OOoura_Cos(f);
            return OOoura_Cos1.Integrate();
        }
        internal class OOoura_Cos
        {
            private cb1SOctuple1S F1_;
            private Octuple X1 = new Octuple();
            private Octuple Y1 = new Octuple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_OReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_OReal_Set(fxPtr, Y1.mpPtr);
            }
            public OOoura_Cos(cb1SOctuple1S F1)
            {
                F1_ = F1;
            }
            public Tuple<Octuple, Octuple> Integrate()
            {
                Octuple result1 = new Octuple(), result2 = new Octuple();
                Lib_OReal_Ooura_Cos(result1.mpPtr, result2.mpPtr, funcptr1);
                return new Tuple<Octuple, Octuple>(result1, result2);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Ooura_Cos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Ooura_Cos(IntPtr res1, IntPtr res2, cbProc2Ptr f);





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/OouraSin/*' />
        public static Tuple<Octuple, Octuple> Ooura_Sin(cb1SOctuple1S f)
        {
            var OOoura_Sin1 = new OOoura_Sin(f);
            return OOoura_Sin1.Integrate();
        }
        internal class OOoura_Sin
        {
            private cb1SOctuple1S F1_;
            private Octuple X1 = new Octuple();
            private Octuple Y1 = new Octuple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_OReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_OReal_Set(fxPtr, Y1.mpPtr);
            }
            public OOoura_Sin(cb1SOctuple1S F1)
            {
                F1_ = F1;
            }
            public Tuple<Octuple, Octuple> Integrate()
            {
                Octuple result1 = new Octuple(), result2 = new Octuple();
                Lib_OReal_Ooura_Sin(result1.mpPtr, result2.mpPtr, funcptr1);
                return new Tuple<Octuple, Octuple>(result1, result2);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Ooura_Sin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Ooura_Sin(IntPtr res1, IntPtr res2, cbProc2Ptr f);









        #endregion






        #region Boost Odeint




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RungeKutta4Const/*' />
        public static void RungeKutta4Const(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, Octuple StartTime, Octuple EndTime, Octuple dt)
        {
            var OOdeint1 = new OOdeintConst(1, F1, F2, matInput, StartTime, EndTime, dt);
            OOdeint1.Integrate();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RungeKutta4Const/*' />
        public static void RungeKutta4Const(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            RungeKutta4Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void CashKarp54Const(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, Octuple StartTime, Octuple EndTime, Octuple dt)
        {
            var OOdeint1 = new OOdeintConst(2, F1, F2, matInput, StartTime, EndTime, dt);
            OOdeint1.Integrate();
        }


        public static void CashKarp54Const(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            CashKarp54Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }




        public static void DormandPrince5Const(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, Octuple StartTime, Octuple EndTime, Octuple dt)
        {
            var OOdeint1 = new OOdeintConst(3, F1, F2, matInput, StartTime, EndTime, dt);
            OOdeint1.Integrate();
        }


        public static void DormandPrince5Const(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            DormandPrince5Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void Fehlberg78Const(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, Octuple StartTime, Octuple EndTime, Octuple dt)
        {
            var OOdeint1 = new OOdeintConst(4, F1, F2, matInput, StartTime, EndTime, dt);
            OOdeint1.Integrate();
        }


        public static void Fehlberg78Const(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            Fehlberg78Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void AdamsBashforthMoultonConst(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, Octuple StartTime, Octuple EndTime, Octuple dt)
        {
            var OOdeint1 = new OOdeintConst(5, F1, F2, matInput, StartTime, EndTime, dt);
            OOdeint1.Integrate();
        }


        public static void AdamsBashforthMoultonConst(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            AdamsBashforthMoultonConst(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        internal class OOdeintConst
        {
            private int what_;
            private cbOctuple1S2V F1_;
            private cbOctuple1S1V F2_;
            private OctupleVec matInit_ = new OctupleVec();
            private OctupleVec matX = new OctupleVec();
            private OctupleVec matY = new OctupleVec();
            private Octuple t = new Octuple();
            private Octuple StartTime_ = new Octuple();
            private Octuple EndTime_ = new Octuple();
            private Octuple dt_ = new Octuple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr, IntPtr tPtr)
            {
                IntPtr tempxPtr = matX.mpPtr;
                matX.mpPtr = xPtr;
                IntPtr tempyPtr = matY.mpPtr;
                matY.mpPtr = fxPtr;
                IntPtr temptPtr = t.mpPtr;
                t.mpPtr = tPtr;
                F1_(t, matX, matY);
                matX.mpPtr = tempxPtr;
                matY.mpPtr = tempyPtr;
                t.mpPtr = temptPtr;
            }
            public void funcptr2(IntPtr xPtr, IntPtr tPtr)
            {
                IntPtr tempxPtr = matX.mpPtr;
                matX.mpPtr = xPtr;
                IntPtr temptPtr = t.mpPtr;
                t.mpPtr = tPtr;
                F2_(t, matX);
                matX.mpPtr = tempxPtr;
                t.mpPtr = temptPtr;
            }
            internal OOdeintConst(int what, cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInit, Octuple StartTime, Octuple EndTime, Octuple dt)
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
                        OReal_Const_RungeKutta4(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 2:
                        OReal_Const_CashKarp54(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 3:
                        OReal_Const_Dopri5(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 4:
                        OReal_Const_Fehlberg78(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 5:
                        OReal_Const_AdamsBashforthMoulton(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    default:
                        Console.WriteLine("Not found");
                        break;
                }
            }
        }

        public static void OReal_Const_RungeKutta4(cbProc3Ptr F1, cbProc2Ptr F2, OctupleVec matX, Octuple StartTime, Octuple EndTime, Octuple dt)
        {
            Lib_OReal_Const_RungeKutta4(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Const_RungeKutta4", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Const_RungeKutta4(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt);


        public static void OReal_Const_CashKarp54(cbProc3Ptr F1, cbProc2Ptr F2, OctupleVec matX, Octuple StartTime, Octuple EndTime, Octuple dt)
        {
            Lib_OReal_Const_CashKarp54(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Const_CashKarp54", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Const_CashKarp54(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt);


        public static void OReal_Const_Dopri5(cbProc3Ptr F1, cbProc2Ptr F2, OctupleVec matX, Octuple StartTime, Octuple EndTime, Octuple dt)
        {
            Lib_OReal_Const_Dopri5(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Const_Dopri5", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Const_Dopri5(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt);


        public static void OReal_Const_Fehlberg78(cbProc3Ptr F1, cbProc2Ptr F2, OctupleVec matX, Octuple StartTime, Octuple EndTime, Octuple dt)
        {
            Lib_OReal_Const_Fehlberg78(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Const_Fehlberg78", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Const_Fehlberg78(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt);


        public static void OReal_Const_AdamsBashforthMoulton(cbProc3Ptr F1, cbProc2Ptr F2, OctupleVec matX, Octuple StartTime, Octuple EndTime, Octuple dt)
        {
            Lib_OReal_Const_AdamsBashforthMoulton(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Const_AdamsBashforthMoulton", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Const_AdamsBashforthMoulton(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt);









        // ***********************************************************************************************************









        /// <include file="docs.xml" path='docs/members[@name="Boost"]/DormandPrince5Adaptive/*' />
        public static void DormandPrince5Adaptive(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, Octuple StartTime, Octuple EndTime, Octuple dt, Octuple epsabs, Octuple epsrel)
        {
            var OOdeint1 = new OOdeintAdaptiveDenseOutput(1, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            OOdeint1.Integrate();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/DormandPrince5Adaptive/*' />
        public static void DormandPrince5Adaptive(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            DormandPrince5Adaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void CashKarp54Adaptive(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, Octuple StartTime, Octuple EndTime, Octuple dt, Octuple epsabs, Octuple epsrel)
        {
            var OOdeint1 = new OOdeintAdaptiveDenseOutput(2, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            OOdeint1.Integrate();
        }


        public static void CashKarp54Adaptive(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            CashKarp54Adaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }



        public static void Fehlberg78Adaptive(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, Octuple StartTime, Octuple EndTime, Octuple dt, Octuple epsabs, Octuple epsrel)
        {
            var OOdeint1 = new OOdeintAdaptiveDenseOutput(3, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            OOdeint1.Integrate();
        }


        public static void Fehlberg78Adaptive(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            Fehlberg78Adaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void BulirschStoerAdaptive(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, Octuple StartTime, Octuple EndTime, Octuple dt, Octuple epsabs, Octuple epsrel)
        {
            var OOdeint1 = new OOdeintAdaptiveDenseOutput(4, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            OOdeint1.Integrate();
        }


        public static void BulirschStoerAdaptive(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            BulirschStoerAdaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void DormandPrince5DenseOutput(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, Octuple StartTime, Octuple EndTime, Octuple dt, Octuple epsabs, Octuple epsrel)
        {
            var OOdeint1 = new OOdeintAdaptiveDenseOutput(5, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            OOdeint1.Integrate();
        }


        public static void DormandPrince5DenseOutput(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            DormandPrince5DenseOutput(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void BulirschStoerDenseOutput(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, Octuple StartTime, Octuple EndTime, Octuple dt, Octuple epsabs, Octuple epsrel)
        {
            var OOdeint1 = new OOdeintAdaptiveDenseOutput(6, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            OOdeint1.Integrate();
        }


        public static void BulirschStoerDenseOutput(cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            BulirschStoerDenseOutput(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        internal class OOdeintAdaptiveDenseOutput
        {
            int what_;
            private cbOctuple1S2V F1_;
            private cbOctuple1S1V F2_;
            private OctupleVec matInit_ = new OctupleVec();
            private OctupleVec matX = new OctupleVec();
            private OctupleVec matY = new OctupleVec();
            private Octuple t = new Octuple();
            private Octuple StartTime_ = new Octuple();
            private Octuple EndTime_ = new Octuple();
            private Octuple dt_ = new Octuple();
            private Octuple epsabs_ = new Octuple();
            private Octuple epsrel_ = new Octuple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr, IntPtr tPtr)
            {
                IntPtr tempxPtr = matX.mpPtr;
                matX.mpPtr = xPtr;
                IntPtr tempyPtr = matY.mpPtr;
                matY.mpPtr = fxPtr;
                IntPtr temptPtr = t.mpPtr;
                t.mpPtr = tPtr;
                F1_(t, matX, matY);
                matX.mpPtr = tempxPtr;
                matY.mpPtr = tempyPtr;
                t.mpPtr = temptPtr;
            }
            public void funcptr2(IntPtr xPtr, IntPtr tPtr)
            {
                IntPtr tempxPtr = matX.mpPtr;
                matX.mpPtr = xPtr;
                IntPtr temptPtr = t.mpPtr;
                t.mpPtr = tPtr;
                F2_(t, matX);
                matX.mpPtr = tempxPtr;
                t.mpPtr = temptPtr;
            }
            internal OOdeintAdaptiveDenseOutput(int what, cbOctuple1S2V F1, cbOctuple1S1V F2, OctupleVec matInit, Octuple StartTime, Octuple EndTime, Octuple dt, Octuple epsabs, Octuple epsrel)
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
                        OReal_Adaptive_RungeKuttaDopri5(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 2:
                        OReal_Adaptive_CashKarp54(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 3:
                        OReal_Adaptive_Fehlberg78(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 4:
                        OReal_Adaptive_BulirschStoer(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 5:
                        OReal_DenseOutput_Dopri5(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 6:
                        OReal_DenseOutput_BulirschStoer(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    default:
                        Console.WriteLine("Not found");
                        break;
                }
            }
        }
        public static void OReal_Adaptive_RungeKuttaDopri5(cbProc3Ptr F1, cbProc2Ptr F2, OctupleVec matX, Octuple StartTime, Octuple EndTime, Octuple dt, Octuple epsabs, Octuple epsrel)
        {
            Lib_OReal_Adaptive_Dopri5(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr, epsabs.mpPtr, epsrel.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Adaptive_Dopri5", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Adaptive_Dopri5(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt, IntPtr epsabs, IntPtr epsrel);


        public static void OReal_Adaptive_CashKarp54(cbProc3Ptr F1, cbProc2Ptr F2, OctupleVec matX, Octuple StartTime, Octuple EndTime, Octuple dt, Octuple epsabs, Octuple epsrel)
        {
            Lib_OReal_Adaptive_CashKarp54(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr, epsabs.mpPtr, epsrel.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Adaptive_CashKarp54", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Adaptive_CashKarp54(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt, IntPtr epsabs, IntPtr epsrel);


        public static void OReal_Adaptive_Fehlberg78(cbProc3Ptr F1, cbProc2Ptr F2, OctupleVec matX, Octuple StartTime, Octuple EndTime, Octuple dt, Octuple epsabs, Octuple epsrel)
        {
            Lib_OReal_Adaptive_Fehlberg78(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr, epsabs.mpPtr, epsrel.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Adaptive_Fehlberg78", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Adaptive_Fehlberg78(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt, IntPtr epsabs, IntPtr epsrel);


        public static void OReal_Adaptive_BulirschStoer(cbProc3Ptr F1, cbProc2Ptr F2, OctupleVec matX, Octuple StartTime, Octuple EndTime, Octuple dt, Octuple epsabs, Octuple epsrel)
        {
            Lib_OReal_Adaptive_BulirschStoer(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr, epsabs.mpPtr, epsrel.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_Adaptive_BulirschStoer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_Adaptive_BulirschStoer(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt, IntPtr epsabs, IntPtr epsrel);


        public static void OReal_DenseOutput_Dopri5(cbProc3Ptr F1, cbProc2Ptr F2, OctupleVec matX, Octuple StartTime, Octuple EndTime, Octuple dt, Octuple epsabs, Octuple epsrel)
        {
            Lib_OReal_DenseOutput_Dopri5(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr, epsabs.mpPtr, epsrel.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_DenseOutput_Dopri5", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_DenseOutput_Dopri5(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt, IntPtr epsabs, IntPtr epsrel);


        public static void OReal_DenseOutput_BulirschStoer(cbProc3Ptr F1, cbProc2Ptr F2, OctupleVec matX, Octuple StartTime, Octuple EndTime, Octuple dt, Octuple epsabs, Octuple epsrel)
        {
            Lib_OReal_DenseOutput_BulirschStoer(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr, epsabs.mpPtr, epsrel.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OReal_DenseOutput_BulirschStoer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OReal_DenseOutput_BulirschStoer(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt, IntPtr epsabs, IntPtr epsrel);











        #endregion





        #region Eigen calculus


        public static OctupleMat PowellHybrd(cbOctuple2M F1, cbOctuple2M F2, OctupleMat matInput)
        {
            var OPowellHybrd1 = new OPowellHybrd(F1, F2, matInput);
            var matX = OPowellHybrd1.Solve();
            return matX;
        }
        internal class OPowellHybrd
        {
            private cbOctuple2M F1_;
            private cbOctuple2M F2_;
            private OctupleMat matX1 = new OctupleMat();
            private OctupleMat matY1 = new OctupleMat();
            private OctupleMat matX2 = new OctupleMat();
            private OctupleMat matY2 = new OctupleMat();
            private OctupleMat matInput_ = new OctupleMat();
            private OctupleMat matX = new OctupleMat();
            private OctupleMat matFvec = new OctupleMat();
            private OctupleMat matFjac = new OctupleMat();
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
            internal OPowellHybrd(cbOctuple2M F1, cbOctuple2M F2, OctupleMat matInput)
            {
                int n = matInput.rows;
                matX.Resize(n, 1);
                matFvec.Resize(n, 1);
                matFjac.Resize(n, n);
                matInput_ = matInput; // Shallow copy
                F1_ = F1;
                F2_ = F2;
            }
            internal OctupleMat Solve()
            {
                olib.testHybrj_ext(funcptr1, funcptr2, matX, matFvec, matFjac, matInput_);
                return matX;
            }
        }




        public static OctupleMat Levenberg(cbOctuple2M F1, cbOctuple2M F2, OctupleMat matInput, int n, int m)
        {
            var OLevenberg1 = new OLevenberg(F1, F2, matInput, n, m);
            var matX = OLevenberg1.Solve();
            return matX;
        }
        internal class OLevenberg
        {
            private cbOctuple2M F1_;
            private cbOctuple2M F2_;
            private OctupleMat matX1 = new OctupleMat();
            private OctupleMat matY1 = new OctupleMat();
            private OctupleMat matX2 = new OctupleMat();
            private OctupleMat matY2 = new OctupleMat();
            private OctupleMat matInput_ = new OctupleMat();
            private OctupleMat matX = new OctupleMat();
            private OctupleMat matFvec = new OctupleMat();
            private OctupleMat matFjac = new OctupleMat();
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
            internal OLevenberg(cbOctuple2M F1, cbOctuple2M F2, OctupleMat matInput, int n, int m)
            {
                matX.Resize(n, 1);
                matFvec.Resize(m, 1);
                matFjac.Resize(n, n);
                matInput_ = matInput; // Shallow copy
                F1_ = F1;
                F2_ = F2;
            }
            internal OctupleMat Solve()
            {
                olib.testLmder_ext(funcptr1, funcptr2, matX, matFvec, matFjac, matInput_);
                return matX;
            }
        }









        #endregion








        #region Boost/CppOptLib


        public static OctupleVec NelderMeadSolver(cb1SOctuple1V F1, OctupleVec matInput)
        {
            var OSolver11 = new OOptSolver1(constants.mp_nelder_mead_solver, F1, matInput);
            return OSolver11.Solve();
        }

        public static OctupleVec CMAesSolver(cb1SOctuple1V F1, OctupleVec matInput)
        {
            var OSolver11 = new OOptSolver1(constants.mp_cma_es_solver, F1, matInput);
            return OSolver11.Solve();
        }

        internal class OOptSolver1
        {
            private int what_;
            private cb1SOctuple1V F1_;
            private OctupleVec matX1 = new OctupleVec();
            private OctupleVec matY1 = new OctupleVec();
            private OctupleVec matX_ = new OctupleVec();
            private OctupleVec matNorm_ = new OctupleVec();
            private OctupleVec X_ = new OctupleVec();
            private OctupleVec FX_ = new OctupleVec();
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
            internal OOptSolver1(int what, cb1SOctuple1V F1, OctupleVec X)
            {
                what_ = what;
                matX_ = new OctupleVec(X.Size);
                X_ = X; // Shallow copy
                F1_ = F1;
            }
            internal OctupleVec Solve()
            {
                Lib_Eigen_OReal_Real_CppOptLib1(what_, funcptr1, matX_.mpPtr, matNorm_.mpPtr, X_.mpPtr, FX_.mpPtr);
                return matX_;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_OReal_Real_CppOptLib1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_OReal_Real_CppOptLib1(int what, cbProc2Ptr F1, IntPtr matXPtr, IntPtr matNormPtr, IntPtr xPtr, IntPtr fxPtr);


        public static OctupleVec LbfgsSolver(cb1SOctuple1V F1, cbOctuple2V F2, OctupleVec matInput)
        {
            var OSolver21 = new OOptSolver2(constants.mp_lbfgs_solver, F1, F2, matInput);
            return OSolver21.Solve();
        }

        public static OctupleVec BfgsSolver(cb1SOctuple1V F1, cbOctuple2V F2, OctupleVec matInput)
        {
            var OSolver21 = new OOptSolver2(constants.mp_bfgs_solver, F1, F2, matInput);
            return OSolver21.Solve();
        }

        public static OctupleVec GradientDescentSolver(cb1SOctuple1V F1, cbOctuple2V F2, OctupleVec matInput)
        {
            var OSolver21 = new OOptSolver2(constants.mp_gradient_descent_solver, F1, F2, matInput);
            return OSolver21.Solve();
        }

        public static OctupleVec ConjugatedGradientDescentSolver(cb1SOctuple1V F1, cbOctuple2V F2, OctupleVec matInput)
        {
            var OSolver21 = new OOptSolver2(constants.mp_conjugated_gradient_descent_solver, F1, F2, matInput);
            return OSolver21.Solve();
        }

        internal class OOptSolver2
        {
            private int what_;
            private cb1SOctuple1V F1_;
            private cbOctuple2V F2_;
            private OctupleVec matX1 = new OctupleVec();
            private OctupleVec matY1 = new OctupleVec();
            private OctupleVec matX2 = new OctupleVec();
            private OctupleVec matY2 = new OctupleVec();
            private OctupleVec matX_ = new OctupleVec();
            private OctupleVec matGrad_ = new OctupleVec();
            private OctupleVec matNorm_ = new OctupleVec();
            private OctupleVec X_ = new OctupleVec();
            private OctupleVec FX_ = new OctupleVec();
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
            internal OOptSolver2(int what, cb1SOctuple1V F1, cbOctuple2V F2, OctupleVec X)
            {
                what_ = what;
                matX_ = new OctupleVec(X.Size);
                matGrad_ = new OctupleVec(X.Size);
                X_ = X; // Shallow copy
                F1_ = F1;
                F2_ = F2;
            }
            internal OctupleVec Solve()
            {
                Lib_Eigen_OReal_Real_CppOptLib2(what_, funcptr1, funcptr2, matX_.mpPtr, matGrad_.mpPtr, matNorm_.mpPtr, X_.mpPtr, FX_.mpPtr);
                return matX_;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_OReal_Real_CppOptLib2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_OReal_Real_CppOptLib2(int what, cbProc2Ptr F1, cbProc2Ptr F2, IntPtr matXPtr, IntPtr matGradPtr, IntPtr matNormPtr, IntPtr xPtr, IntPtr fxPtr);



        public static OctupleVec NewtonDescentSolver(cb1SOctuple1V F1, cbOctuple2V F2, cbOctuple1V1M F3, OctupleVec matInput)
        {
            var OSolver31 = new OOptSolver3(constants.mp_newton_descent_solver, F1, F2, F3, matInput);
            return OSolver31.Solve();
        }

        internal class OOptSolver3
        {
            private int what_;
            private cb1SOctuple1V F1_;
            private cbOctuple2V F2_;
            private cbOctuple1V1M F3_;
            private OctupleVec matX1 = new OctupleVec();
            private OctupleVec matY1 = new OctupleVec();
            private OctupleVec matX2 = new OctupleVec();
            private OctupleVec matY2 = new OctupleVec();
            private OctupleVec matX3 = new OctupleVec();
            private OctupleMat matY3 = new OctupleMat();
            private OctupleVec matX_ = new OctupleVec();
            private OctupleVec matGrad_ = new OctupleVec();
            private OctupleVec matNorm_ = new OctupleVec();
            private OctupleMat matHessian_ = new OctupleMat();
            private OctupleVec X_ = new OctupleVec();
            private OctupleVec FX_ = new OctupleVec();
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
            internal OOptSolver3(int what, cb1SOctuple1V F1, cbOctuple2V F2, cbOctuple1V1M F3, OctupleVec X)
            {
                what_ = what;
                matX_ = new OctupleVec(X.Size);
                matGrad_ = new OctupleVec(X.Size);
                matHessian_.Resize(X.Size, X.Size);
                X_ = X; // Shallow copy
                F1_ = F1;
                F2_ = F2;
                F3_ = F3;
            }
            internal OctupleVec Solve()
            {
                Lib_Eigen_OReal_Real_CppOptLib3(what_, funcptr1, funcptr2, funcptr3, matX_.mpPtr, matHessian_.mpPtr, matGrad_.mpPtr, matNorm_.mpPtr, X_.mpPtr, FX_.mpPtr);
                return matX_;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_OReal_Real_CppOptLib3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_OReal_Real_CppOptLib3(int what, cbProc2Ptr F1, cbProc2Ptr F2, cbProc2Ptr F3, IntPtr matXPtr, IntPtr matHessianPtr, IntPtr matGradPtr, IntPtr matNormPtr, IntPtr xPtr, IntPtr fxPtr);



        #endregion











        #region Matrix Creation




        /// <summary>
        /// Converts from a real scalar of type oreal
        /// </summary>
        public static OctupleMat mat_t(Octuple x)
        {
            var matA = new OctupleMat();
            matA[0, 0] = x;
            return matA;
        }


        /* *********************** */

        public static OctupleMatC mat_cplx_t(OctupleMat matA)
        {
            return ocplx.mat_t(matA);
        }


        public static OctupleMatC mat_cplx_zeros(int n, int m)
        {
            return ocplx.mat_zeros(n, m);
        }

        /* *********************** */




        public static OctupleMat mat_zeros(int n, int m)
        {
            var resout = new OctupleMat();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setZero, n, m);
            return resout;
        }



        public static OctupleMat mat_ones(int n, int m)
        {
            var resout = new OctupleMat();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setOnes, n, m);
            return resout;
        }



        public static OctupleMat mat_identity(int n, int m)
        {
            var resout = new OctupleMat();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setIdentity, n, m);
            return resout;
        }



        public static OctupleMat mat_random(int n, int m)
        {
            var resout = new OctupleMat();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandom_nm, n, m);
            return resout;
        }



        public static OctupleMat mat_random_symmetric(int n)
        {
            var resout = new OctupleMat();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandomSymmetric, n, n);
            return resout;
        }



        public static OctupleMat mat_random_selfadjoint(int n)
        {
            var resout = new OctupleMat();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandomSA, n, n);
            return resout;
        }



        public static OctupleMat mat_random_selfadjoint_posdef(int n)
        {
            var resout = new OctupleMat();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandomSAPosDef, n, n);
            return resout;
        }



        public static OctupleMat mat_fill_linear(int n, int m)
        {
            var resout = new OctupleMat();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_FillLinear, n, m);
            return resout;
        }



        #endregion












    }







}