using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Numerics;

namespace FixedPrecNet
{

    public delegate Quadruple cb1SQuadruple1S(Quadruple x);


    public delegate void cbQuadruple1S1V(Quadruple t, QuadrupleVec matX);

    public delegate void cbQuadruple1S2V(Quadruple t, QuadrupleVec matX, QuadrupleVec matY);


    public delegate void cbQuadruple2M(QuadrupleMat matX, QuadrupleMat matY);


    public delegate Quadruple cb1SQuadruple1V(QuadrupleVec x);

    public delegate void cbQuadruple2V(QuadrupleVec x, QuadrupleVec y);

    public delegate void cbQuadruple1V1M(QuadrupleVec x, QuadrupleMat y);




    /// <summary>
    /// Represents a quadruple precision binary floating point number
    /// </summary>
    public partial class Quadruple 
    {

        #region Init

        public IntPtr mpPtr = IntPtr.Zero;

        private void Init()
        {
            xcn.Init();
            mpPtr = Lib_QReal_Init_Func();
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_QReal_Init_Func();


        ~Quadruple()
        {
            Lib_QReal_Clear(mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Clear(IntPtr x);

        #endregion


        #region Conversions

        public Quadruple()
        {
            Init();
        }




        public override string ToString()
        {
            if (0 == (Lib_QReal_Iszero(mpPtr)))
            {
                //Console.WriteLine("Non-zero");
                return Get_QReal_Str(mpPtr);
            }
            else
            {
                //Console.WriteLine("zero");
                return "0";
            }
            //return Get_QReal_Str(mpPtr);
        }

        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Iszero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Iszero(IntPtr x);



        //internal string Get_QReal_Str(IntPtr mpPtr)
        //{
        //    int StrSize = 128;
        //    var sb = new StringBuilder(StrSize + 10);
        //    Lib_QReal_Get_Str(sb, "%+-#*.34Qe", mpPtr);
        //    return (sb.ToString()).Trim();
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Get_Str", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern void Lib_QReal_Get_Str(StringBuilder sb, string Template1, IntPtr in1);


        internal string Get_QReal_Str(IntPtr mpPtr)
        {
            int StrSize = 128;
            var sb = new StringBuilder(StrSize + 10);
            ShowQuadNet(sb, mpPtr);
            return (sb.ToString().Trim());
        }
        [DllImport(xcn.mpNum, EntryPoint = "ShowQuadNet", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void ShowQuadNet(StringBuilder sb, IntPtr in1);



        public string __str__()
        {
            return ToString();
        }


        public string __repr__()
        {
            return "qreal('" + ToString() + "')";
        }


        //public override dynamic Ctx
        //{
        //    get { return new qreal(); }
        //}



        #endregion


        #region Arithmetic operators




        public static bool operator >=(Quadruple x, dynamic y)
        {
            return x >= qreal.t(y);
        }
        public static bool operator <=(Quadruple x, dynamic y)
        {
            return x <= qreal.t(y);
        }

        public static bool operator >=(dynamic x, Quadruple y)
        {
            return qreal.t(x) >= y;
        }
        public static bool operator <=(dynamic x, Quadruple y)
        {
            return qreal.t(x) <= y;
        }


        public static bool operator >(Quadruple x, dynamic y)
        {
            return x > qreal.t(y);
        }
        public static bool operator <(Quadruple x, dynamic y)
        {
            return x < qreal.t(y);
        }


        public static bool operator >(dynamic x, Quadruple y)
        {
            return qreal.t(x) > y;
        }
        public static bool operator <(dynamic x, Quadruple y)
        {
            return qreal.t(x) < y;
        }



        public static bool operator ==(Quadruple x, dynamic y)
        {
            return x == qreal.t(y);
        }
        public static bool operator !=(Quadruple x, dynamic y)
        {
            return x != qreal.t(y);
        }

        public static bool operator ==(dynamic x, Quadruple y)
        {
            return qreal.t(x) == y;
        }
        public static bool operator !=(dynamic x, Quadruple y)
        {
            return qreal.t(x) != y;
        }



        public static bool operator ==(Quadruple x, Quadruple y)
        {
            return 0 != (Lib_QReal_EQ(x.mpPtr, y.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_EQ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_EQ(IntPtr x, IntPtr y);

        public static bool operator !=(Quadruple x, Quadruple y)
        {
            return 0 != (Lib_QReal_NE(x.mpPtr, y.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_NE", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_NE(IntPtr x, IntPtr y);


        public static bool operator <=(Quadruple x, Quadruple y)
        {
            return 0 != (Lib_QReal_LE(x.mpPtr, y.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LE", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_LE(IntPtr x, IntPtr y);

        public static bool operator >(Quadruple x, Quadruple y)
        {
            return 0 != (Lib_QReal_GT(x.mpPtr, y.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GT", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_GT(IntPtr x, IntPtr y);


        public static bool operator >=(Quadruple x, Quadruple y)
        {
            return 0 != (Lib_QReal_GE(x.mpPtr, y.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GE", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_GE(IntPtr x, IntPtr y);

        public static bool operator <(Quadruple x, Quadruple y)
        {
            return 0 != (Lib_QReal_LT(x.mpPtr, y.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LT", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_LT(IntPtr x, IntPtr y);








        public static Quadruple operator +(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Set(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Set", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Set(IntPtr res, IntPtr x);


        public static Quadruple operator -(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Neg(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Neg", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Neg(IntPtr res, IntPtr x);












        public static Quadruple operator +(Quadruple x, dynamic i)
        {
            return x + qreal.t(i);
        }

        public static Quadruple operator +(dynamic i, Quadruple x)
        {
            return qreal.t(i) + x;
        }

        public static QuadrupleC operator +(Quadruple x, QuadrupleC y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Add_QReal(res.mpPtr, y.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Add_QReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Add_QReal(IntPtr res, IntPtr y, IntPtr x);


        public static Quadruple operator +(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Add(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Add(IntPtr res, IntPtr x, IntPtr y);


        public static QuadrupleMat operator +(Quadruple m2, QuadrupleMat M1)
        {
            var Res = new QuadrupleMat();
            var t = qreal.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }







        public static Quadruple operator -(Quadruple x, dynamic y)
        {
            return x - qreal.t(y);
        }

        public static Quadruple operator -(dynamic x, Quadruple y)
        {
            return qreal.t(x) - y;
        }

        public static QuadrupleC operator -(Quadruple x, QuadrupleC y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_QReal_Sub(res.mpPtr, y.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_QReal_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_QReal_Sub(IntPtr res, IntPtr y, IntPtr x);


        public static Quadruple operator -(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Sub(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Sub(IntPtr res, IntPtr x, IntPtr y);


        public static QuadrupleMat operator -(Quadruple m2, QuadrupleMat M1)
        {
            var Res = new QuadrupleMat();
            var t = qreal.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, t.mpPtr);
            return -Res;
        }










        public static Quadruple operator *(Quadruple x, dynamic y)
        {
            return x * qreal.t(y);
        }

        public static Quadruple operator *(dynamic x, Quadruple y)
        {
            return qreal.t(x) * y;
        }



        public static QuadrupleC operator *(Quadruple x, QuadrupleC y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Mul_QReal(res.mpPtr, y.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Mul_QReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Mul_QReal(IntPtr res, IntPtr x, IntPtr y);


        public static Quadruple operator *(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Mul(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Mul", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Mul(IntPtr res, IntPtr x, IntPtr y);


        public static QuadrupleMat operator *(Quadruple m2, QuadrupleMat M1)
        {
            var Res = new QuadrupleMat();
            var t = qreal.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_real, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }










        public static Quadruple operator /(Quadruple x, dynamic y)
        {
            return x / qreal.t(y);
        }

        public static Quadruple operator /(dynamic x, Quadruple y)
        {
            return qreal.t(x) / y;
        }



        public static QuadrupleC operator /(Quadruple x, QuadrupleC y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_QReal_Div(res.mpPtr, y.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_QReal_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_QReal_Div(IntPtr res, IntPtr x, IntPtr y);


        public static Quadruple operator /(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Div(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Div(IntPtr res, IntPtr x, IntPtr y);





        #endregion


    }



    public class QuadrupleVec
    {

        public IntPtr mpPtr = IntPtr.Zero;

        public QuadrupleVec()
        {
            xcn.Init();
            mpPtr = Lib_Eigen_QReal_Init_Func(constants.mp_eigen, constants.mp_real);
        }

        public QuadrupleVec(int N)
        {
            xcn.Init();
            mpPtr = Lib_Eigen_QReal_Init_Func(constants.mp_eigen, constants.mp_real);
            Lib_Eigen_QReal_SetSpecialValue(constants.mp_eigen, constants.mp_real, mpPtr, constants.mp_Resize, N, 1);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_Eigen_QReal_Init_Func(int mpCat, int mpType);
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_SetSpecialValue", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_SetSpecialValue(int mpCat, int mpType, IntPtr MatrixPtr_result, int what, int m, int n);


        ~QuadrupleVec()
        {
            Lib_Eigen_QReal_Clear(constants.mp_eigen, constants.mp_real, mpPtr);
        }

        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Clear(int mpCat, int mpType, IntPtr AnyPtr);


        public int Size
        {
            get
            {
                return Lib_Eigen_QReal_GetInfo(constants.mp_eigen, constants.mp_real, constants.mp_const_size, mpPtr);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_GetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_Eigen_QReal_GetInfo(int mpCat, int mpType, int what, IntPtr MatrixPtr_source);


        public Quadruple this[int row_i]
        {
            get
            {
                var result = new Quadruple();
                Eigen_QReal_GetCoeff(result.mpPtr, row_i, 0, mpPtr);
                return result;
            }

            set
            {
                Eigen_QReal_SetCoeff(mpPtr, value.mpPtr, row_i, 0);
            }

        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_GetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_QReal_GetCoeff(IntPtr result, int row, int col, IntPtr MatrixPtr_source);

        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_SetCoeff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Eigen_QReal_SetCoeff(IntPtr MatrixPtr_result, IntPtr in1, int row, int col);

    }







    /// <summary>
    /// Provides numerical functions in quadruple precision, based on Boost Math/Multiprecision
    /// </summary>
    public class qreal
    {




        public static String fmt(Quadruple x)
        {
            string s = " " + x.ToString();
            return s;
        }


        public static String fmt(dynamic x)
        {
            return fmt(t(x));
        }



        #region VecParams, Linspace, XRealMatTFunc


        public static QuadrupleVec VecParams(params dynamic[] args)
        {
            int N = args.Length;
            var matX3 = new QuadrupleVec(N);
            for (int i = 0; i < N; i++)
                matX3[i] = t(args[i]);
            return matX3;
        }


        #endregion





        #region General

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/name/*' />
        public static String name
        {
            get { return "qreal"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  qreal"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/prec/*' />
        public static Int32 prec
        {
            get { return 113; }
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
        public static qreal realctx
        {
            get { return new qreal(); }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static qcplx cplxctx
        {
            get { return new qcplx(); }
        }


        #endregion



        #region Conversions

        // Note: the conversion from dynamic needs to be at the top of this list

        /// <summary>
        /// Returns a new Quadruple using a dynamic (an object whose operations will be resolved at runtime) as input
        /// </summary>
        public static Quadruple t(dynamic x)
        {
            //MessageBox.Show("In Quadruple t(dynamic i)");
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
        /// Returns a new Quadruple using an Octuple as input
        /// </summary>
        public static Quadruple t(Octuple x)
        {
            var res = new Quadruple();
            string s = x.ToString();
            Lib_QReal_Set_Str(res.mpPtr, s);
            return res;
        }




        /// <summary>
        /// Returns a new Quadruple using a Quadruple as input
        /// </summary>
        public static Quadruple t(Quadruple x)
        {
            return +x;
        }



        /// <summary>
        /// Returns a new Quadruple using an Extended as input
        /// </summary>
        public static Quadruple t(Extended x)
        {
            var res = new Quadruple();
            Lib_QReal_Set_LD(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Set_LD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Set_LD(IntPtr res, IntPtr x);



        internal static Quadruple TDS(Double d)
        {
            var res = new Quadruple();
            string s = d.ToString("G14", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
            Lib_QReal_Set_Str(res.mpPtr, s);
            return res;
        }

        /// <summary>
        /// Returns a new Quadruple using a Double (System.Double) as input
        /// </summary>
        public static Quadruple t(Double d)
        {
            if ((xcn.UseRawDouble) || (xcn.IsExactDouble(d)))
            {
                var res = new Quadruple();
                Lib_QReal_Set_D(res.mpPtr, d);
                return res;
            }
            else
            {
                return TDS(d);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Set_D", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Set_D(IntPtr mpfr_out1, Double d);





        /// <summary>
        /// Returns a new Quadruple using a Single (System.Single) as input
        /// </summary>
        public static Quadruple t(Single x)
        {
            var res = new Quadruple();
            Lib_QReal_Set_S(res.mpPtr, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Set_S", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Set_S(IntPtr res, ref Single x);



        /// <summary>
        /// Returns a new Quadruple using a signed 32 bit integer (System.Int32) as input
        /// </summary>
        public static Quadruple t(Int32 si)
        {
            var res = new Quadruple();
            Lib_QReal_Set_Si(res.mpPtr, si);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Set_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Set_Si(IntPtr res, Int32 si);



        /// <summary>
        /// Returns a new Quadruple using an unsigned 32 bit integer (System.UInt32) as input
        /// </summary>
        public static Quadruple t(UInt32 ui)
        {
            var res = new Quadruple();
            Lib_QReal_Set_Ui(res.mpPtr, ui);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Set_Ui", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Set_Ui(IntPtr res, UInt32 ui);



        /// <summary>
        /// Returns a new Quadruple using a signed 64 bit integer (System.Int64) as input
        /// </summary>
        public static Quadruple t(Int64 si64)
        {
            var res = new Quadruple();
            Lib_QReal_Set_Si64(res.mpPtr, si64);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Set_Si64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Set_Si64(IntPtr res, Int64 si64);


        /// <summary>
        /// Returns a new Quadruple using an unsigned 64 bit integer (System.UInt64) as input
        /// </summary>
        public static Quadruple t(UInt64 ui64)
        {
            var res = new Quadruple();
            Lib_QReal_Set_Ui64(res.mpPtr, ui64);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Set_Ui64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Set_Ui64(IntPtr res, UInt64 ui64);


        /// <summary>
        /// Returns a new Quadruple using an arbitrary precision integer (System.Numerics.BigInteger) as input
        /// </summary>
        public static Quadruple t(BigInteger i)
        {
            var res = new Quadruple();
            string s = i.ToString();
            Lib_QReal_Set_Str(res.mpPtr, s);
            return res;
        }


        /// <summary>
        /// Returns a new Quadruple using a decimal number (System.Decimal) as input
        /// </summary>
        public static Quadruple t(Decimal dec)
        {
            var res = new Quadruple();
            string s = dec.ToString();
            Lib_QReal_Set_Str(res.mpPtr, s);
            return res;
        }




        /// <summary>
        /// Returns a new Quadruple using a string (System.String) as input
        /// </summary>
        public static Quadruple t(String s)
        {
            var res = new Quadruple();
            Lib_QReal_Set_Str(res.mpPtr, s);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Set_Str", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Set_Str(IntPtr res, string s);




        #endregion



        #region Basic Arithmetic


        public static Quadruple add(Quadruple x, Quadruple y)
        {
            return x + y;
        }
        public static Quadruple add(dynamic x, dynamic y)
        {
            return t(x) + t(y);
        }

        public static void rawadd(Quadruple res, Quadruple x, Quadruple y)
        {
            Lib_QReal_Add(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Add(IntPtr res, IntPtr x, IntPtr y);



        public static Quadruple subtract(Quadruple x, Quadruple y)
        {
            return x - y;
        }
        public static Quadruple subtract(dynamic x, dynamic y)
        {
            return t(x) - t(y);
        }

        public static void rawsub(Quadruple res, Quadruple x, Quadruple y)
        {
            Lib_QReal_Sub(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Sub(IntPtr res, IntPtr x, IntPtr y);




        public static Quadruple multiply(Quadruple x, Quadruple y)
        {
            return x * y;
        }
        public static Quadruple multiply(dynamic x, dynamic y)
        {
            return t(x) * t(y);
        }

        public static void rawmul(Quadruple res, Quadruple x, Quadruple y)
        {
            Lib_QReal_Add(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Mul", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Mul(IntPtr res, IntPtr x, IntPtr y);



        public static Quadruple divide(Quadruple x, Quadruple y)
        {
            return x / y;
        }
        public static Quadruple divide(dynamic x, dynamic y)
        {
            return t(x) / t(y);
        }
        public static void rawdiv(Quadruple res, Quadruple x, Quadruple y)
        {
            Lib_QReal_Div(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Div(IntPtr res, IntPtr x, IntPtr y);


        #endregion






        #region Basic floating point functions



        #region General functions for real numbers


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fma/*' />
        public static Quadruple fma(Quadruple x, Quadruple y, Quadruple z)
        {
            var res = new Quadruple();
            Lib_QReal_Fma(res.mpPtr, x.mpPtr, y.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Fma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Fma(IntPtr res, IntPtr x, IntPtr y, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fma/*' />
        public static Quadruple fma(dynamic x, dynamic y, dynamic z)
        {
            return fma(qreal.t(x), qreal.t(y), qreal.t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmax/*' />
        public static Quadruple fmax(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Fmax(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Fmax", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Fmax(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmax/*' />
        public static Quadruple fmax(dynamic x, dynamic y)
        {
            return fmax(qreal.t(x), qreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmin/*' />
        public static Quadruple fmin(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Fmin(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Fmin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Fmin(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmin/*' />
        public static Quadruple fmin(dynamic x, dynamic y)
        {
            return fmin(qreal.t(x), qreal.t(y));
        }


        #endregion



        #region Machine constants


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/zero/*' />
        public static Quadruple zero()
        {
            var res = new Quadruple();
            Lib_QReal_Zero(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Zero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Zero(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/negzero/*' />
        public static Quadruple negzero()
        {
            var res = new Quadruple();
            Lib_QReal_NegZero(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_NegZero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_NegZero(IntPtr res);



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/one/*' />
        public static Quadruple one()
        {
            var res = new Quadruple();
            Lib_QReal_One(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_One", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_One(IntPtr res);



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/onej/*' />
        public static QuadrupleC onej()
        {
            return qcplx.t(0, 1);
        }




        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isposinf/*' />
        public static Quadruple inf()
        {
            var res = new Quadruple();
            Lib_QReal_Inf(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Inf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Inf(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/neginf/*' />
        public static Quadruple neginf()
        {
            var res = new Quadruple();
            Lib_QReal_NegInf(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_NegInf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_NegInf(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/nan/*' />
        public static Quadruple nan()
        {
            var res = new Quadruple();
            Lib_QReal_Nan(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Nan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Nan(IntPtr res);



        #endregion



        #region Properties of numbers


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/signbit/*' />
        public static int signbit(Quadruple x)
        {
            return Lib_QReal_Signbit(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Signbit", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Signbit(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/signbit/*' />
        public static int signbit(dynamic x)
        {
            return signbit(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isfinite/*' />
        public static bool isfinite(Quadruple x)
        {
            return 0 != Lib_QReal_Finite(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Finite", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Finite(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isfinite/*' />
        public static bool isfinite(dynamic x)
        {
            return isfinite(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isinf/*' />
        public static bool isinf(Quadruple x)
        {
            return 0 != (Lib_QReal_Isinf(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Isinf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Isinf(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isinf/*' />
        public static bool isinf(dynamic x)
        {
            return isinf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isposinf/*' />
        public static bool isposinf(Quadruple x)
        {
            return 0 != (Lib_QReal_Isposinf(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Isposinf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Isposinf(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isposinf/*' />
        public static bool isposinf(dynamic x)
        {
            return isposinf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isneginf/*' />
        public static bool isneginf(Quadruple x)
        {
            return 0 != (Lib_QReal_Isneginf(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Isneginf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Isneginf(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isneginf/*' />
        public static bool isneginf(dynamic x)
        {
            return isneginf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnan/*' />
        public static bool isnan(Quadruple x)
        {
            return 0 != (Lib_QReal_Isnan(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Isnan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Isnan(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isnan/*' />
        public static bool isnan(dynamic x)
        {
            return isnan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/iszero/*' />
        public static bool iszero(Quadruple x)
        {
            return 0 != (Lib_QReal_Iszero(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Iszero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Iszero(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/iszero/*' />
        public static bool iszero(dynamic x)
        {
            return iszero(t(x));
        }




        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/IsNegativeZero/*' />
        //public static bool IsNegativeZero(Quadruple x)
        //{
        //    return 0 != (Lib_QReal_Isnegzero(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Isnegzero", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_QReal_Isnegzero(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/IsNegativeZero/*' />
        //public static bool IsNegativeZero(dynamic x)
        //{
        //    return IsNegativeZero(t(x));
        //}



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isone/*' />
        public static bool isone(Quadruple x)
        {
            return 0 != (Lib_QReal_Isone(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Isone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Isone(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isone/*' />
        public static bool isone(dynamic x)
        {
            return isone(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isinteger/*' />
        public static bool isinteger(Quadruple x)
        {
            return 0 != (Lib_QReal_Isinteger(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Isinteger", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Isinteger(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isinteger/*' />
        public static bool isinteger(dynamic x)
        {
            return isinteger(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnumber/*' />
        public static bool isnumber(Quadruple x)
        {
            return 0 != (Lib_QReal_Isnumber(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Isnumber", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Isnumber(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isnumber/*' />
        public static bool isnumber(dynamic x)
        {
            return isnumber(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isregular/*' />
        public static bool isregular(Quadruple x)
        {
            return 0 != (Lib_QReal_Isregular(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Isregular", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Isregular(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isregular/*' />
        public static bool isregular(dynamic x)
        {
            return isregular(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnormal/*' />
        public static bool isnormal(Quadruple x)
        {
            return 0 != (Lib_QReal_Isnormal(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Isnormal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Isnormal(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isnormal/*' />
        public static bool isnormal(dynamic x)
        {
            return isnormal(t(x));
        }



        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/IsSubnormal/*' />
        //public static bool IsSubnormal(Quadruple x)
        //{
        //    return 0 != (Lib_QReal_Issubnormal(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Issubnormal", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_QReal_Issubnormal(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/IsSubnormal/*' />
        //public static bool IsSubnormal(dynamic x)
        //{
        //    return IsSubnormal(t(x));
        //}



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isunordered/*' />
        public static bool isunordered(Quadruple x, Quadruple y)
        {
            return 0 != (Lib_QReal_Isunordered(x.mpPtr, y.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Isunordered", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_Isunordered(IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/isunordered/*' />
        public static bool isunordered(dynamic x, dynamic y)
        {
            return isunordered(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/fitsint32/*' />
        public static bool fitsint32(Quadruple x)
        {
            return 0 != (Lib_QReal_FitsInt32(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_FitsInt32", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_FitsInt32(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fitsint32/*' />
        public static bool fitsint32(dynamic x)
        {
            return fitsint32(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/fitsint64/*' />
        public static bool fitsint64(Quadruple x)
        {
            return 0 != (Lib_QReal_FitsInt64(x.mpPtr));
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_FitsInt64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Lib_QReal_FitsInt64(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fitsint64/*' />
        public static bool fitsint64(dynamic x)
        {
            return fitsint64(t(x));
        }



        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/FitsUInt32/*' />
        //public static bool FitsUInt32(Quadruple x)
        //{
        //    return 0 != (Lib_QReal_FitsUInt32(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_FitsUInt32", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_QReal_FitsUInt32(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/FitsUInt32/*' />
        //public static bool FitsUInt32(dynamic x)
        //{
        //    return FitsUInt32(t(x));
        //}



        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/FitsUInt64/*' />
        //public static bool FitsUInt64(Quadruple x)
        //{
        //    return 0 != (Lib_QReal_FitsUInt64(x.mpPtr));
        //}
        //[DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_FitsUInt64", CallingConvention = CallingConvention.Cdecl)]
        //internal static extern int Lib_QReal_FitsUInt64(IntPtr x);


        ///// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/FitsUInt64/*' />
        //public static bool FitsUInt64(dynamic x)
        //{
        //    return FitsUInt64(t(x));
        //}




        #endregion



        #region Integer Related Functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nearbyint/*' />
        public static Quadruple nearbyint(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Nearbyint(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Nearbyint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Nearbyint(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nearbyint/*' />
        public static Quadruple nearbyint(dynamic x)
        {
            return nearbyint(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rint/*' />
        public static Quadruple rint(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Rint(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Rint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Rint(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rint/*' />
        public static Quadruple rint(dynamic x)
        {
            return rint(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lrint/*' />
        public static Int32 lrint(Quadruple x)
        {
            return Lib_QReal_Lrint(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Lrint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_QReal_Lrint(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lrint/*' />
        public static Int32 lrint(dynamic x)
        {
            return lrint(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llrint/*' />
        public static Int64 llrint(Quadruple x)
        {
            return Lib_QReal_Llrint(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Llrint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int64 Lib_QReal_Llrint(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llrint/*' />
        public static Int64 llrint(dynamic x)
        {
            return llrint(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ceil/*' />
        public static Quadruple ceil(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Ceil(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Ceil", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Ceil(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ceil/*' />
        public static Quadruple ceil(dynamic x)
        {
            return ceil(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/floor/*' />
        public static Quadruple floor(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Floor(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Floor", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Floor(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/floor/*' />
        public static Quadruple floor(dynamic x)
        {
            return floor(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/trunc/*' />
        public static Quadruple trunc(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Trunc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Trunc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Trunc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/trunc/*' />
        public static Quadruple trunc(dynamic x)
        {
            return trunc(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/round/*' />
        public static Quadruple round(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Round(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Round", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Round(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/round/*' />
        public static Quadruple round(dynamic x)
        {
            return round(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lround/*' />
        public static Int32 lround(Quadruple x)
        {
            return Lib_QReal_Lround(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Lround", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_QReal_Lround(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lround/*' />
        public static Int32 lround(dynamic x)
        {
            return lround(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llround/*' />
        public static Int64 llround(Quadruple x)
        {
            return Lib_QReal_Llround(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Llround", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int64 Lib_QReal_Llround(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/llround/*' />
        public static Int64 llround(dynamic x)
        {
            return llround(t(x));
        }





        #endregion



        #region Floating point functions for real numbers


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/copysign/*' />
        public static Quadruple copysign(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Copysign(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Copysign", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Copysign(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/copysign/*' />
        public static Quadruple copysign(dynamic x, dynamic y)
        {
            return copysign(qreal.t(x), qreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/frexp/*' />
        public static Tuple<Quadruple, Int32> frexp(Quadruple x)
        {
            var res = new Quadruple();
            Int32 e = 0;
            Lib_QReal_Frexp(res.mpPtr, x.mpPtr, ref e);
            return new Tuple<Quadruple, int>(res, e);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Frexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Frexp(IntPtr res, IntPtr x, ref Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/frexp/*' />
        public static Tuple<Quadruple, Int32> frexp(dynamic x)
        {
            return frexp(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logb/*' />
        public static Quadruple logb(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Logb(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Logb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Logb(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logb/*' />
        public static Quadruple logb(dynamic x)
        {
            return logb(t(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ilogb/*' />
        public static Int32 ilogb(Quadruple x)
        {
            return Lib_QReal_Ilogb(x.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Ilogb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Lib_QReal_Ilogb(IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ilogb/*' />
        public static Int32 ilogb(dynamic x)
        {
            return ilogb(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ldexp/*' />
        public static Quadruple ldexp(Quadruple x, Int32 e)
        {
            var res = new Quadruple();
            Lib_QReal_Ldexp(res.mpPtr, x.mpPtr, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Ldexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Ldexp(IntPtr res, IntPtr x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ldexp/*' />
        public static Quadruple ldexp(dynamic x, dynamic e)
        {
            return ldexp(t(x), lround(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbn/*' />
        public static Quadruple scalbn(Quadruple x, Int32 e)
        {
            var res = new Quadruple();
            Lib_QReal_Scalbn(res.mpPtr, x.mpPtr, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Scalbn", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Scalbn(IntPtr res, IntPtr x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbn/*' />
        public static Quadruple scalbn(dynamic x, dynamic e)
        {
            return scalbn(t(x), lround(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbln/*' />
        public static Quadruple scalbln(Quadruple x, Int32 e)
        {
            var res = new Quadruple();
            Lib_QReal_Scalbln(res.mpPtr, x.mpPtr, e);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Scalbln", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Scalbln(IntPtr res, IntPtr x, Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/scalbln/*' />
        public static Quadruple scalbln(dynamic x, dynamic e)
        {
            return scalbln(t(x), lround(t(e)));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fdim/*' />
        public static Quadruple fdim(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Fdim(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Fdim", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Fdim(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fdim/*' />
        public static Quadruple fdim(dynamic x, dynamic y)
        {
            return fdim(qreal.t(x), qreal.t(y));
        }


        #endregion



        #region Fraction and remainder Related Functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/modf/*' />
        public static Tuple<Quadruple, Quadruple> modf(Quadruple x)
        {
            Quadruple iptr = new Quadruple();
            Quadruple frac = new Quadruple();
            Lib_QReal_Modf(frac.mpPtr, x.mpPtr, iptr.mpPtr);
            return new Tuple<Quadruple, Quadruple>(iptr, frac);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Modf", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Modf(IntPtr frac, IntPtr x, IntPtr iptr);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/modf/*' />
        public static Tuple<Quadruple, Quadruple> modf(dynamic x)
        {
            return modf(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmod/*' />
        public static Quadruple fmod(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Fmod(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Fmod", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Fmod(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fmod/*' />
        public static Quadruple fmod(dynamic x, dynamic y)
        {
            return fmod(qreal.t(x), qreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remainder/*' />
        public static Quadruple remainder(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Remainder(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Remainder", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Remainder(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remainder/*' />
        public static Quadruple remainder(dynamic x, dynamic y)
        {
            return remainder(qreal.t(x), qreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remquo/*' />
        public static Tuple<Quadruple, Int32> remquo(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Int32 e = 0;
            Lib_QReal_Remquo(res.mpPtr, x.mpPtr, y.mpPtr, ref e);
            return new Tuple<Quadruple, int>(res, e);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Remquo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Remquo(IntPtr res, IntPtr x, IntPtr y, ref Int32 e);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/remquo/*' />
        public static Tuple<Quadruple, Int32> remquo(dynamic x, dynamic y)
        {
            return remquo(t(x), t(y));
        }

        #endregion



        #region Functions related to mantissa width and exponent range


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/epsilon/*' />
        public static Quadruple epsilon()
        {
            var res = new Quadruple();
            Lib_QReal_Epsilon(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Epsilon", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Epsilon(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ulp/*' />
        public static Quadruple ulp(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Ulp(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Ulp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Ulp(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ulp/*' />
        public static Quadruple ulp(dynamic x)
        {
            return ulp(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/maxvalue/*' />
        public static Quadruple maxvalue()
        {
            var res = new Quadruple();
            Lib_QReal_Max(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Max", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Max(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/lowestvalue/*' />
        public static Quadruple lowestvalue()
        {
            var res = new Quadruple();
            Lib_QReal_Lowest(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Lowest", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Lowest(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/minposvalue/*' />
        public static Quadruple minposvalue()
        {
            var res = new Quadruple();
            Lib_QReal_Min(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Min", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Min(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextafter/*' />
        public static Quadruple nextafter(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Nexttoward(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Nexttoward", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Nexttoward(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextafter/*' />
        public static Quadruple nextafter(dynamic x, dynamic y)
        {
            return nextafter(qreal.t(x), qreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextabove/*' />
        public static Quadruple nextabove(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Nextabove(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Nextabove", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Nextabove(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextabove/*' />
        public static Quadruple nextabove(dynamic x)
        {
            return nextabove(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextbelow/*' />
        public static Quadruple nextbelow(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Nextbelow(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Nextbelow", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Nextbelow(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/nextbelow/*' />
        public static Quadruple nextbelow(dynamic x)
        {
            return nextbelow(t(x));
        }


        #endregion



        #region Mathematical Constants


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/degree/*' />
        public static Quadruple degree()
        {
            var res = new Quadruple();
            Lib_QReal_ConstDegree(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ConstDegree", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ConstDegree(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phi/*' />
        public static Quadruple phi()
        {
            var res = new Quadruple();
            Lib_QReal_ConstPhi(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ConstPhi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ConstPhi(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ln2/*' />
        public static Quadruple ln2()
        {
            var res = new Quadruple();
            Lib_QReal_ConstLog2(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ConstLog2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ConstLog2(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ln10/*' />
        public static Quadruple ln10()
        {
            var res = new Quadruple();
            Lib_QReal_ConstLog10(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ConstLog10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ConstLog10(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pi/*' />
        public static Quadruple pi()
        {
            var res = new Quadruple();
            Lib_QReal_ConstPi(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ConstPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ConstPi(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/e/*' />
        public static Quadruple e()
        {
            var res = new Quadruple();
            Lib_QReal_ConstE(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ConstE", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ConstE(IntPtr res);




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/egamma/*' />
        public static Quadruple egamma()
        {
            var res = new Quadruple();
            Lib_QReal_ConstEulerGamma(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ConstEulerGamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ConstEulerGamma(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/apery/*' />
        public static Quadruple apery()
        {
            var res = new Quadruple();
            Lib_QReal_ConstApery(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ConstApery", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ConstApery(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/catalan/*' />
        public static Quadruple catalan()
        {
            var res = new Quadruple();
            Lib_QReal_ConstCatalan(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ConstCatalan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ConstCatalan(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/glaisher/*' />
        public static Quadruple glaisher()
        {
            var res = new Quadruple();
            Lib_QReal_ConstGlaisher(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ConstGlaisher", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ConstGlaisher(IntPtr res);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/khinchin/*' />
        public static Quadruple khinchin()
        {
            var res = new Quadruple();
            Lib_QReal_ConstKhinchin(res.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ConstKhinchin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ConstKhinchin(IntPtr res);


        #endregion




        #endregion




        #region Elementary scalar functions




        #region Complex components


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Quadruple abs(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Fabs(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Fabs", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Fabs(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Quadruple abs(dynamic x)
        {
            return abs(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Quadruple fabs(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Fabs(res.mpPtr, x.mpPtr);
            return res;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Quadruple fabs(dynamic x)
        {
            return fabs(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static Quadruple sign(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Sign(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Sign", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Sign(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static Quadruple sign(dynamic x)
        {
            return sign(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Quadruple real(Quadruple x)
        {
            return x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Quadruple real(dynamic x)
        {
            return real(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Quadruple imag(Quadruple x)
        {
            return zero();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Quadruple imag(dynamic x)
        {
            return imag(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Quadruple phase(Quadruple x)
        {
            if (x >= zero()) return zero();
            else return pi();
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Quadruple phase(dynamic x)
        {
            return phase(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static Quadruple conj(Quadruple x)
        {
            return x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static Quadruple conj(dynamic x)
        {
            return conj(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Quadruple, Quadruple> polar(Quadruple x)
        {
            return new Tuple<Quadruple, Quadruple>(abs(x), phase(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Quadruple, Quadruple> polar(dynamic x)
        {
            return polar(qreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rect/*' />
        public static QuadrupleC rect(Quadruple r, Quadruple phi)
        {
            return r * expj(phi);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rect/*' />
        public static QuadrupleC rect(dynamic r, dynamic phi)
        {
            return rect(qreal.t(r), qreal.t(phi));
        }






        #endregion



        #region Roots and quadratic, cubic, and quartic equations


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static Quadruple sqrt(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Sqrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Sqrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Sqrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static Quadruple sqrt(dynamic x)
        {
            return sqrt(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sqrt1pm1/*' />
        public static Quadruple sqrt1pm1(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Sqrt1pm1_Boost(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Sqrt1pm1_Boost", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Sqrt1pm1_Boost(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sqrt1pm1/*' />
        public static Quadruple sqrt1pm1(dynamic x)
        {
            return sqrt1pm1(qreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Quadruple rsqrt(Quadruple x)
        {
            return t(1) / sqrt(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static Quadruple rsqrt(dynamic x)
        {
            return rsqrt(t(x)); ;
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static Quadruple cbrt(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Cbrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Cbrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Cbrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static Quadruple cbrt(dynamic x)
        {
            return cbrt(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static Quadruple root_si(Quadruple x, int k)
        {
            var res = new Quadruple();
            Lib_QReal_Root_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Root_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Root_Si(IntPtr res, IntPtr x, int k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static Quadruple root_si(dynamic x, int k)
        {
            return root_si(t(x), k);
        }



        #endregion



        #region Exponential and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static Quadruple exp(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Exp(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Exp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Exp(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static Quadruple exp(dynamic x)
        {
            return exp(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static QuadrupleC expj(Quadruple x)
        {
            return cos(x) + onej() * sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static QuadrupleC expj(dynamic x)
        {
            return expj(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static QuadrupleC expjpi(Quadruple x)
        {
            return cospi(x) + onej() * sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static QuadrupleC expjpi(dynamic x)
        {
            return expjpi(t(x));
        }






        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Quadruple exp2(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Exp2(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Exp2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Exp2(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static Quadruple exp2(dynamic x)
        {
            return exp2(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static Quadruple exp10(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Exp10(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Exp10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Exp10(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static Quadruple exp10(dynamic x)
        {
            return exp10(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Quadruple expm1(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Expm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Expm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Expm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static Quadruple expm1(dynamic x)
        {
            return expm1(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Quadruple exp2m1(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Exp2m1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Exp2m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Exp2m1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static Quadruple exp2m1(dynamic x)
        {
            return exp2m1(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static Quadruple exp10m1(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Exp10m1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Exp10m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Exp10m1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static Quadruple exp10m1(dynamic x)
        {
            return exp10m1(t(x));
        }


        #endregion



        #region Logarithms and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static Quadruple log(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Log(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Log", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Log(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static Quadruple log(dynamic x)
        {
            return log(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Quadruple log2(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Log2(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Log2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Log2(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static Quadruple log2(dynamic x)
        {
            return log2(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Quadruple log10(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Log10(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Log10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Log10(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static Quadruple log10(dynamic x)
        {
            return log10(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Quadruple log1p(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Log1p(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Log1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Log1p(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static Quadruple log1p(dynamic x)
        {
            return log1p(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static Quadruple log2p1(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Log2p1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Log2p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Log2p1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static Quadruple log2p1(dynamic x)
        {
            return log2p1(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static Quadruple log10p1(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Log10p1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Log10p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Log10p1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static Quadruple log10p1(dynamic x)
        {
            return log10p1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logaddexp/*' />
        public static Quadruple logaddexp(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Logaddexp(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Logaddexp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Logaddexp(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/logaddexp/*' />
        public static Quadruple logaddexp(dynamic x, dynamic y)
        {
            return logaddexp(t(x), t(y));
        }




        #endregion



        #region Power functions

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static Quadruple sqr(Quadruple x)
        {
            return x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static Quadruple sqr(dynamic x)
        {
            return sqr(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static Quadruple cube(Quadruple x)
        {
            return x * x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static Quadruple cube(dynamic x)
        {
            return cube(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static Quadruple hypot(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Hypot(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Hypot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Hypot(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static Quadruple hypot(dynamic x, dynamic y)
        {
            return hypot(qreal.t(x), qreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static Quadruple pow(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Pow(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Pow", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Pow(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static Quadruple pow(dynamic x, dynamic y)
        {
            return pow(qreal.t(x), qreal.t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/powm1/*' />
        public static Quadruple powm1(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Powm1(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Powm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Powm1(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/powm1/*' />
        public static Quadruple powm1(dynamic x, dynamic y)
        {
            return powm1(qreal.t(x), qreal.t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1p/*' />
        public static Quadruple pow1p(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Pow1p(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Pow1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Pow1p(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1p/*' />
        public static Quadruple pow1p(dynamic x, dynamic y)
        {
            return pow1p(qreal.t(x), qreal.t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1pm1/*' />
        public static Quadruple pow1pm1(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Pow1pm1(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Pow1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Pow1pm1(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/pow1pm1/*' />
        public static Quadruple pow1pm1(dynamic x, dynamic y)
        {
            return pow1pm1(qreal.t(x), qreal.t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static Quadruple pow_si(Quadruple x, int k)
        {
            var res = new Quadruple();
            Lib_QReal_Pow_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Pow_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Pow_Si(IntPtr res, IntPtr x, int k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static Quadruple pow_si(dynamic x, int k)
        {
            return pow_si(qreal.t(x), k);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static Quadruple compound_si(Quadruple x, int k)
        {
            var res = new Quadruple();
            Lib_QReal_Compound_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Compound_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Compound_Si(IntPtr res, IntPtr x, int k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static Quadruple compound_si(dynamic x, int k)
        {
            return compound_si(qreal.t(x), k);
        }




        #endregion



        #region Trigonometric and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Quadruple sin(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Sin(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Sin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Sin(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static Quadruple sin(dynamic x)
        {
            return sin(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static Quadruple cos(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Cos(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Cos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Cos(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static Quadruple cos(dynamic x)
        {
            return cos(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static Quadruple tan(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Tan(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Tan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Tan(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static Quadruple tan(dynamic x)
        {
            return tan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static Quadruple csc(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Csc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Csc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Csc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static Quadruple csc(dynamic x)
        {
            return csc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static Quadruple sec(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Sec(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Sec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Sec(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static Quadruple sec(dynamic x)
        {
            return sec(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static Quadruple cot(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Cot(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Cot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Cot(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static Quadruple cot(dynamic x)
        {
            return cot(t(x));
        }






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinpi/*' />
        public static Quadruple sinpi(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_SinPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_SinPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_SinPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinpi/*' />
        public static Quadruple sinpi(dynamic x)
        {
            return sinpi(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cospi/*' />
        public static Quadruple cospi(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_CosPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_CosPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_CosPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cospi/*' />
        public static Quadruple cospi(dynamic x)
        {
            return cospi(qreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/tanpi/*' />
        public static Quadruple tanpi(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_TanPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_TanPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_TanPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/tanpi/*' />
        public static Quadruple tanpi(dynamic x)
        {
            return tanpi(qreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cscpi/*' />
        public static Quadruple cscpi(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_CscPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_CscPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_CscPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cscpi/*' />
        public static Quadruple cscpi(dynamic x)
        {
            return cscpi(qreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/secpi/*' />
        public static Quadruple secpi(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_SecPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_SecPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_SecPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/secpi/*' />
        public static Quadruple secpi(dynamic x)
        {
            return secpi(qreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cotpi/*' />
        public static Quadruple cotpi(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_CotPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_CotPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_CotPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/cotpi/*' />
        public static Quadruple cotpi(dynamic x)
        {
            return cotpi(qreal.t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinc/*' />
        public static Quadruple sinc(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_SincPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_SincPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_SincPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinc/*' />
        public static Quadruple sinc(dynamic x)
        {
            return sinc(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static Quadruple sincpi(Quadruple x)
        {
            Quadruple x1 = x * qreal.pi();

            if (qreal.abs(x) < 0.1)
            {
                return sinc(x1);
            }
            else return sinpi(x) / x1;
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinc/*' />
        public static Quadruple sincpi(dynamic x)
        {
            return sincpi(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinhcpi/*' />
        public static Quadruple sinhcpi(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_SinhcPi(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_SinhcPi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_SinhcPi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sinhcpi/*' />
        public static Quadruple sinhcpi(dynamic x)
        {
            return sinhcpi(qreal.t(x));
        }





        #endregion



        #region Hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static Quadruple sinh(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Sinh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Sinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Sinh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static Quadruple sinh(dynamic x)
        {
            return sinh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static Quadruple cosh(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Cosh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Cosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Cosh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static Quadruple cosh(dynamic x)
        {
            return cosh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static Quadruple tanh(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Tanh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Tanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Tanh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static Quadruple tanh(dynamic x)
        {
            return tanh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static Quadruple csch(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Csch(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Csch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Csch(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static Quadruple csch(dynamic x)
        {
            return csch(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static Quadruple sech(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Sech(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Sech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Sech(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static Quadruple sech(dynamic x)
        {
            return sech(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static Quadruple coth(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Coth(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Coth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Coth(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static Quadruple coth(dynamic x)
        {
            return coth(t(x));
        }





        #endregion



        #region Inverse trigonometric functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static Quadruple asin(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Asin(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Asin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Asin(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static Quadruple asin(dynamic x)
        {
            return asin(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static Quadruple acos(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Acos(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Acos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Acos(IntPtr res, IntPtr x);

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static Quadruple acos(dynamic x)
        {
            return acos(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static Quadruple atan(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Atan(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Atan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Atan(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static Quadruple atan(dynamic x)
        {
            return atan(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan2/*' />
        public static Quadruple atan2(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Atan2(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Atan2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Atan2(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan2/*' />
        public static Quadruple atan2(dynamic x, dynamic y)
        {
            return atan2(qreal.t(x), qreal.t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static Quadruple acsc(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Acsc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Acsc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Acsc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static Quadruple acsc(dynamic x)
        {
            return acsc(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static Quadruple asec(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Asec(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Asec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Asec(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static Quadruple asec(dynamic x)
        {
            return asec(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static Quadruple acot(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Acot(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Acot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Acot(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static Quadruple acot(dynamic x)
        {
            return acot(t(x));
        }





        #endregion




        #region Inverse hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static Quadruple asinh(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Asinh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Asinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Asinh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static Quadruple asinh(dynamic x)
        {
            return asinh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static Quadruple acosh(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Acosh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Acosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Acosh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static Quadruple acosh(dynamic x)
        {
            return acosh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static Quadruple atanh(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Atanh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Atanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Atanh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static Quadruple atanh(dynamic x)
        {
            return atanh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static Quadruple acsch(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Acsch(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Acsch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Acsch(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static Quadruple acsch(dynamic x)
        {
            return acsch(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static Quadruple asech(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Asech(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Asech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Asech(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static Quadruple asech(dynamic x)
        {
            return asech(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static Quadruple acoth(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Acoth(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Acoth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Acoth(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static Quadruple acoth(dynamic x)
        {
            return acoth(t(x));
        }





        #endregion



        #region Miscellaneous




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_w0/*' />
        public static Quadruple lambert_w0(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_LambertW0(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LambertW0", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_LambertW0(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_w0/*' />
        public static Quadruple lambert_w0(dynamic x)
        {
            return lambert_w0(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_wm1/*' />
        public static Quadruple lambert_wm1(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_LambertWm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LambertWm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_LambertWm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_wm1/*' />
        public static Quadruple lambert_wm1(dynamic x)
        {
            return lambert_wm1(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_w0_prime/*' />
        public static Quadruple lambert_w0_prime(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_LambertW0Prime(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LambertW0Prime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_LambertW0Prime(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_w0_prime/*' />
        public static Quadruple lambert_w0_prime(dynamic x)
        {
            return lambert_w0_prime(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_wm1_prime/*' />
        public static Quadruple lambert_wm1_prime(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_LambertWm1Prime(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LambertWm1Prime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_LambertWm1Prime(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/lambert_wm1_prime/*' />
        public static Quadruple lambert_wm1_prime(dynamic x)
        {
            return lambert_wm1_prime(qreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/agm/*' />
        public static Quadruple agm(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Agm(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Agm", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Agm(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/agm/*' />
        public static Quadruple agm(dynamic x, dynamic y)
        {
            return agm(qreal.t(x), qreal.t(y));
        }




        #endregion





        #endregion





        #region Special real functions



        #region Error functions for real arguments

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndens/*' />
        public static Quadruple ndens(Quadruple x)
        {
            return exp(-0.5 * x * x) / sqrt(2 * pi());
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndens/*' />
        public static Quadruple ndens(dynamic x)
        {
            return ndens(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndis/*' />
        public static Quadruple ndis(Quadruple x)
        {
            return 0.5 * erfc(-x / sqrt(2));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/ndis/*' />
        public static Quadruple ndis(dynamic x)
        {
            return ndis(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erf/*' />
        public static Quadruple erf(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Erf_(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Erf_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Erf_(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erf/*' />
        public static Quadruple erf(dynamic x)
        {
            return erf(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erfc/*' />
        public static Quadruple erfc(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Erfc_(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Erfc_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Erfc_(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/erfc/*' />
        public static Quadruple erfc(dynamic x)
        {
            return erfc(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ErfInv/*' />
        public static Quadruple erf_inv(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Erf_inv(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Erf_inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Erf_inv(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ErfInv/*' />
        public static Quadruple erf_inv(dynamic x)
        {
            return erf_inv(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ErfcInv/*' />
        public static Quadruple erfc_inv(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Erfc_inv(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Erfc_inv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Erfc_inv(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ErfcInv/*' />
        public static Quadruple erfc_inv(dynamic x)
        {
            return erfc_inv(qreal.t(x));
        }





        #endregion



        #region Gamma and related functions for real arguments and parameters


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rgamma/*' />
        public static Quadruple rgamma(Quadruple x)
        {
            return t(1) / gamma(x);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rgamma/*' />
        public static Quadruple rgamma(dynamic x)
        {
            return rgamma(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        public static Quadruple gamma(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Tgamma_(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Tgamma_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Tgamma_(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/gamma/*' />
        public static Quadruple gamma(dynamic x)
        {
            return gamma(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma1pm1/*' />
        public static Quadruple gamma1pm1(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Tgamma1pm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Tgamma1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Tgamma1pm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma1pm1/*' />
        public static Quadruple gamma1pm1(dynamic x)
        {
            return gamma1pm1(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lgamma/*' />
        public static Quadruple lgamma(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Lgamma_(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Lgamma_", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Lgamma_(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/lgamma/*' />
        public static Quadruple lgamma(dynamic x)
        {
            return lgamma(qreal.t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/factorial/*' />
        public static Quadruple factorial(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Factorial(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Factorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Factorial(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/factorial/*' />
        public static Quadruple factorial(dynamic x)
        {
            return factorial(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/doublefactorial/*' />
        public static Quadruple doublefactorial(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_DoubleFactorial(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_DoubleFactorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_DoubleFactorial(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/doublefactorial/*' />
        public static Quadruple doublefactorial(dynamic x)
        {
            return doublefactorial(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_ratio/*' />
        public static Quadruple gamma_ratio(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_TgammaRatio(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_TgammaRatio", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_TgammaRatio(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_ratio/*' />
        public static Quadruple gamma_ratio(dynamic x, dynamic y)
        {
            return gamma_ratio(qreal.t(x), qreal.t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_delta_ratio/*' />
        public static Quadruple gamma_delta_ratio(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_TgammaDeltaRatio(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_TgammaDeltaRatio", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_TgammaDeltaRatio(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_delta_ratio/*' />
        public static Quadruple gamma_delta_ratio(dynamic x, dynamic y)
        {
            return gamma_delta_ratio(qreal.t(x), qreal.t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/binomial/*' />
        public static Quadruple binomial(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_Binomial(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Binomial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Binomial(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/binomial/*' />
        public static Quadruple binomial(dynamic x, dynamic y)
        {
            return binomial(qreal.t(x), qreal.t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/rising_factorial/*' />
        public static Quadruple rising_factorial(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_RisingFactorial(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_RisingFactorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_RisingFactorial(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/rising_factorial/*' />
        public static Quadruple rising_factorial(dynamic x, dynamic y)
        {
            return rising_factorial(qreal.t(x), qreal.t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/falling_factorial/*' />
        public static Quadruple falling_factorial(Quadruple x, Quadruple y)
        {
            var res = new Quadruple();
            Lib_QReal_FallingFactorial(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_FallingFactorial", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_FallingFactorial(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/falling_factorial/*' />
        public static Quadruple falling_factorial(dynamic x, dynamic y)
        {
            return falling_factorial(qreal.t(x), qreal.t(y));
        }







        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta/*' />
        public static Quadruple beta(Quadruple a, Quadruple b)
        {
            var res = new Quadruple();
            Lib_QReal_Beta(res.mpPtr, a.mpPtr, b.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Beta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Beta(IntPtr res, IntPtr a, IntPtr b);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta/*' />
        public static Quadruple beta(dynamic a, dynamic b)
        {
            return beta(qreal.t(a), qreal.t(b));
        }





        #endregion



        #region Incomplete gamma functions for real arguments and parameters




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p/*' />
        public static Quadruple gamma_p(Quadruple a, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_GammaP(res.mpPtr, a.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GammaP", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_GammaP(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p/*' />
        public static Quadruple gamma_p(dynamic a, dynamic x)
        {
            return gamma_p(qreal.t(a), qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q/*' />
        public static Quadruple gamma_q(Quadruple a, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_GammaQ(res.mpPtr, a.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GammaQ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_GammaQ(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q/*' />
        public static Quadruple gamma_q(dynamic a, dynamic x)
        {
            return gamma_q(qreal.t(a), qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_lower/*' />
        public static Quadruple gamma_lower(Quadruple a, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_TgammaLower(res.mpPtr, a.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_TgammaLower", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_TgammaLower(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_lower/*' />
        public static Quadruple gamma_lower(dynamic a, dynamic x)
        {
            return gamma_lower(qreal.t(a), qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_upper/*' />
        public static Quadruple gamma_upper(Quadruple a, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_TgammaUpper(res.mpPtr, a.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_TgammaUpper", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_TgammaUpper(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_upper/*' />
        public static Quadruple gamma_upper(dynamic a, dynamic x)
        {
            return gamma_upper(qreal.t(a), qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inv/*' />
        public static Quadruple gamma_p_inv(Quadruple a, Quadruple p)
        {
            var res = new Quadruple();
            Lib_QReal_GammaPInv(res.mpPtr, a.mpPtr, p.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GammaPInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_GammaPInv(IntPtr res, IntPtr a, IntPtr p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inv/*' />
        public static Quadruple gamma_p_inv(dynamic a, dynamic p)
        {
            return gamma_p_inv(qreal.t(a), qreal.t(p));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inv/*' />
        public static Quadruple gamma_q_inv(Quadruple a, Quadruple q)
        {
            var res = new Quadruple();
            Lib_QReal_GammaQInv(res.mpPtr, a.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GammaQInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_GammaQInv(IntPtr res, IntPtr a, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inv/*' />
        public static Quadruple gamma_q_inv(dynamic a, dynamic q)
        {
            return gamma_q_inv(qreal.t(a), qreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inva/*' />
        public static Quadruple gamma_p_inva(Quadruple x, Quadruple p)
        {
            var res = new Quadruple();
            Lib_QReal_GammaPInva(res.mpPtr, x.mpPtr, p.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GammaPInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_GammaPInva(IntPtr res, IntPtr x, IntPtr p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_inva/*' />
        public static Quadruple gamma_p_inva(dynamic x, dynamic p)
        {
            return gamma_p_inva(qreal.t(x), qreal.t(p));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inva/*' />
        public static Quadruple gamma_q_inva(Quadruple x, Quadruple q)
        {
            var res = new Quadruple();
            Lib_QReal_GammaQInva(res.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GammaQInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_GammaQInva(IntPtr res, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_q_inva/*' />
        public static Quadruple gamma_q_inva(dynamic x, dynamic q)
        {
            return gamma_q_inva(qreal.t(x), qreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_prime/*' />
        public static Quadruple gamma_p_prime(Quadruple a, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_GammaPDerivative(res.mpPtr, a.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GammaPDerivative", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_GammaPDerivative(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gamma_p_prime/*' />
        public static Quadruple gamma_p_prime(dynamic a, dynamic x)
        {
            return gamma_p_prime(qreal.t(a), qreal.t(x));
        }





        #endregion



        #region Incomplete beta functions for real arguments and parameters


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta/*' />
        public static Quadruple ibeta(Quadruple a, Quadruple b, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_IBeta(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_IBeta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_IBeta(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta/*' />
        public static Quadruple ibeta(dynamic a, dynamic b, dynamic x)
        {
            return ibeta(qreal.t(a), qreal.t(b), qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac/*' />
        public static Quadruple ibetac(Quadruple a, Quadruple b, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_IBetac(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_IBetac", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_IBetac(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac/*' />
        public static Quadruple ibetac(dynamic a, dynamic b, dynamic x)
        {
            return ibetac(qreal.t(a), qreal.t(b), qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta_lower/*' />
        public static Quadruple beta_lower(Quadruple a, Quadruple b, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_IBetaNonNormalized(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_IBetaNonNormalized", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_IBetaNonNormalized(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta_lower/*' />
        public static Quadruple beta_lower(dynamic a, dynamic b, dynamic x)
        {
            return beta_lower(qreal.t(a), qreal.t(b), qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta_upper/*' />
        public static Quadruple beta_upper(Quadruple a, Quadruple b, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_IBetacNonNormalized(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_IBetacNonNormalized", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_IBetacNonNormalized(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/beta_upper/*' />
        public static Quadruple beta_upper(dynamic a, dynamic b, dynamic x)
        {
            return beta_upper(qreal.t(a), qreal.t(b), qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inv/*' />
        public static Quadruple ibeta_inv(Quadruple a, Quadruple b, Quadruple p)
        {
            var res = new Quadruple();
            Lib_QReal_IBetaInv(res.mpPtr, a.mpPtr, b.mpPtr, p.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_IBetaInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_IBetaInv(IntPtr res, IntPtr a, IntPtr b, IntPtr p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inv/*' />
        public static Quadruple ibeta_inv(dynamic a, dynamic b, dynamic p)
        {
            return ibeta_inv(qreal.t(a), qreal.t(b), qreal.t(p));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inv/*' />
        public static Quadruple ibetac_inv(Quadruple a, Quadruple b, Quadruple q)
        {
            var res = new Quadruple();
            Lib_QReal_IBetacInv(res.mpPtr, a.mpPtr, b.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_IBetacInv", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_IBetacInv(IntPtr res, IntPtr a, IntPtr b, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inv/*' />
        public static Quadruple ibetac_inv(dynamic a, dynamic b, dynamic q)
        {
            return ibetac_inv(qreal.t(a), qreal.t(b), qreal.t(q));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inva/*' />
        public static Quadruple ibeta_inva(Quadruple b, Quadruple x, Quadruple p)
        {
            var res = new Quadruple();
            Lib_QReal_IBetaInva(res.mpPtr, b.mpPtr, x.mpPtr, p.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_IBetaInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_IBetaInva(IntPtr res, IntPtr b, IntPtr x, IntPtr p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_inva/*' />
        public static Quadruple ibeta_inva(dynamic b, dynamic x, dynamic p)
        {
            return ibeta_inva(qreal.t(b), qreal.t(x), qreal.t(p));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inva/*' />
        public static Quadruple ibetac_inva(Quadruple b, Quadruple x, Quadruple q)
        {
            var res = new Quadruple();
            Lib_QReal_IBetacInva(res.mpPtr, b.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_IBetacInva", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_IBetacInva(IntPtr res, IntPtr b, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_inva/*' />
        public static Quadruple ibetac_inva(dynamic b, dynamic x, dynamic q)
        {
            return ibetac_inva(qreal.t(b), qreal.t(x), qreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_invb/*' />
        public static Quadruple ibeta_invb(Quadruple a, Quadruple x, Quadruple p)
        {
            var res = new Quadruple();
            Lib_QReal_IBetaInvb(res.mpPtr, a.mpPtr, x.mpPtr, p.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_IBetaInvb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_IBetaInvb(IntPtr res, IntPtr a, IntPtr x, IntPtr p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_invb/*' />
        public static Quadruple ibeta_invb(dynamic a, dynamic x, dynamic p)
        {
            return ibeta_invb(qreal.t(a), qreal.t(x), qreal.t(p));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_invb/*' />
        public static Quadruple ibetac_invb(Quadruple a, Quadruple x, Quadruple q)
        {
            var res = new Quadruple();
            Lib_QReal_IBetacInvb(res.mpPtr, a.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_IBetacInvb", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_IBetacInvb(IntPtr res, IntPtr a, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibetac_invb/*' />
        public static Quadruple ibetac_invb(dynamic a, dynamic x, dynamic q)
        {
            return ibetac_invb(qreal.t(a), qreal.t(x), qreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_prime/*' />
        public static Quadruple ibeta_prime(Quadruple a, Quadruple b, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_IBetaDerivative(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_IBetaDerivative", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_IBetaDerivative(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ibeta_prime/*' />
        public static Quadruple ibeta_prime(dynamic a, dynamic b, dynamic x)
        {
            return ibeta_prime(qreal.t(a), qreal.t(b), qreal.t(x));
        }





        #endregion



        #region Miscellaneous real functions




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/owen_t/*' />
        public static Quadruple owen_t(Quadruple h, Quadruple a)
        {
            var res = new Quadruple();
            Lib_QReal_OwenT(res.mpPtr, h.mpPtr, a.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_OwenT", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_OwenT(IntPtr res, IntPtr h, IntPtr a);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/owen_t/*' />
        public static Quadruple owen_t(dynamic h, dynamic a)
        {
            return owen_t(qreal.t(h), qreal.t(a));
        }





        #endregion



        #endregion






        #region Special Functions



        #region Legendre elliptic integrals (elliptic modulus k), and related functions


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Ellint1K/*' />
        public static Quadruple elliptic_k(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Ellint_1_K(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Ellint_1_K", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Ellint_1_K(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Ellint1K/*' />
        public static Quadruple elliptic_k(dynamic x)
        {
            return elliptic_k(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Ellint2K/*' />
        public static Quadruple elliptic_e(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Ellint_2_K(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Ellint_2_K", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Ellint_2_K(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Ellint2K/*' />
        public static Quadruple elliptic_e(dynamic x)
        {
            return elliptic_e(qreal.t(x));
        }






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rc/*' />
        public static Quadruple elliptic_rc(Quadruple a, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_EllintRC(res.mpPtr, a.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_EllintRC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_EllintRC(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rc/*' />
        public static Quadruple elliptic_rc(dynamic a, dynamic x)
        {
            return elliptic_rc(qreal.t(a), qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_f/*' />
        public static Quadruple elliptic_f(Quadruple phi, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_Ellint1F(res.mpPtr, k.mpPtr, phi.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Ellint1F", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Ellint1F(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_f/*' />
        public static Quadruple elliptic_f(dynamic phi, dynamic k)
        {
            return elliptic_f(qreal.t(phi), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_e_inc/*' />
        public static Quadruple elliptic_e_inc(Quadruple phi, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_Ellint2F(res.mpPtr, k.mpPtr, phi.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Ellint2F", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Ellint2F(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_e_inc/*' />
        public static Quadruple elliptic_e_inc(dynamic phi, dynamic k)
        {
            return elliptic_e_inc(qreal.t(phi), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_pi/*' />
        public static Quadruple elliptic_pi(Quadruple n, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_Ellint3K(res.mpPtr, k.mpPtr, n.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Ellint3K", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Ellint3K(IntPtr res, IntPtr a, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_pi/*' />
        public static Quadruple elliptic_pi(dynamic n, dynamic k)
        {
            return elliptic_pi(qreal.t(n), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_pi_inc/*' />
        public static Quadruple elliptic_pi_inc(Quadruple n, Quadruple phi, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_Ellint3F(res.mpPtr, k.mpPtr, n.mpPtr, phi.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Ellint3F", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Ellint3F(IntPtr res, IntPtr k, IntPtr n, IntPtr phi);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_pi_inc/*' />
        public static Quadruple elliptic_pi_inc(dynamic n, dynamic phi, dynamic k)
        {
            return elliptic_pi_inc(qreal.t(n), qreal.t(phi), qreal.t(k));
        }








        #endregion



        #region Carlson symmetric elliptic integrals




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rf/*' />
        public static Quadruple elliptic_rf(Quadruple x, Quadruple y, Quadruple z)
        {
            var res = new Quadruple();
            Lib_QReal_EllipticRF(res.mpPtr, x.mpPtr, y.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_EllipticRF", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_EllipticRF(IntPtr res, IntPtr x, IntPtr y, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rf/*' />
        public static Quadruple elliptic_rf(dynamic x, dynamic y, dynamic z)
        {
            return elliptic_rf(qreal.t(x), qreal.t(y), qreal.t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rd/*' />
        public static Quadruple elliptic_rd(Quadruple x, Quadruple y, Quadruple z)
        {
            var res = new Quadruple();
            Lib_QReal_EllipticRD(res.mpPtr, x.mpPtr, y.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_EllipticRD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_EllipticRD(IntPtr res, IntPtr x, IntPtr y, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rd/*' />
        public static Quadruple elliptic_rd(dynamic x, dynamic y, dynamic z)
        {
            return elliptic_rd(qreal.t(x), qreal.t(y), qreal.t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rg/*' />
        public static Quadruple elliptic_rg(Quadruple x, Quadruple y, Quadruple z)
        {
            var res = new Quadruple();
            Lib_QReal_EllipticRG(res.mpPtr, x.mpPtr, y.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_EllipticRG", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_EllipticRG(IntPtr res, IntPtr x, IntPtr y, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rg/*' />
        public static Quadruple elliptic_rg(dynamic x, dynamic y, dynamic z)
        {
            return elliptic_rg(qreal.t(x), qreal.t(y), qreal.t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rj/*' />
        public static Quadruple elliptic_rj(Quadruple x, Quadruple y, Quadruple z, Quadruple p)
        {
            var res = new Quadruple();
            Lib_QReal_EllipticRJ(res.mpPtr, x.mpPtr, y.mpPtr, z.mpPtr, p.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_EllipticRJ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_EllipticRJ(IntPtr res, IntPtr x, IntPtr y, IntPtr z, IntPtr p);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/elliptic_rj/*' />
        public static Quadruple elliptic_rj(dynamic x, dynamic y, dynamic z, dynamic p)
        {
            return elliptic_rj(qreal.t(x), qreal.t(y), qreal.t(z), qreal.t(p));
        }



        #endregion



        #region Jacobi theta functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta1/*' />
        public static Quadruple jacobi_theta1(Quadruple x, Quadruple q)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiTheta1(res.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiTheta1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiTheta1(IntPtr res, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta1/*' />
        public static Quadruple jacobi_theta1(dynamic x, dynamic q)
        {
            return jacobi_theta1(qreal.t(x), qreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta2/*' />
        public static Quadruple jacobi_theta2(Quadruple x, Quadruple q)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiTheta2(res.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiTheta2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiTheta2(IntPtr res, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta2/*' />
        public static Quadruple jacobi_theta2(dynamic x, dynamic q)
        {
            return jacobi_theta2(qreal.t(x), qreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta3/*' />
        public static Quadruple jacobi_theta3(Quadruple x, Quadruple q)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiTheta3(res.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiTheta3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiTheta3(IntPtr res, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta3/*' />
        public static Quadruple jacobi_theta3(dynamic x, dynamic q)
        {
            return jacobi_theta3(qreal.t(x), qreal.t(q));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta3/*' />
        public static Quadruple jacobi_theta4(Quadruple x, Quadruple q)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiTheta4(res.mpPtr, x.mpPtr, q.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiTheta4", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiTheta4(IntPtr res, IntPtr x, IntPtr q);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_theta3/*' />
        public static Quadruple jacobi_theta4(dynamic x, dynamic q)
        {
            return jacobi_theta4(qreal.t(x), qreal.t(q));
        }





        #endregion



        #region Jacobi elliptic functions


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cd/*' />
        public static Quadruple jacobi_cd(Quadruple u, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiCD(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiCD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiCD(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cd/*' />
        public static Quadruple jacobi_cd(dynamic u, dynamic k)
        {
            return jacobi_cd(qreal.t(u), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cn/*' />
        public static Quadruple jacobi_cn(Quadruple u, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiCN(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiCN", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiCN(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cn/*' />
        public static Quadruple jacobi_cn(dynamic u, dynamic k)
        {
            return jacobi_cn(qreal.t(u), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cs/*' />
        public static Quadruple jacobi_cs(Quadruple u, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiCS(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiCS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiCS(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_cs/*' />
        public static Quadruple jacobi_cs(dynamic u, dynamic k)
        {
            return jacobi_cs(qreal.t(u), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_dc/*' />
        public static Quadruple jacobi_dc(Quadruple u, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiDC(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiDC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiDC(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_dc/*' />
        public static Quadruple jacobi_dc(dynamic u, dynamic k)
        {
            return jacobi_dc(qreal.t(u), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_dn/*' />
        public static Quadruple jacobi_dn(Quadruple u, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiDN(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiDN", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiDN(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_dn/*' />
        public static Quadruple jacobi_dn(dynamic u, dynamic k)
        {
            return jacobi_dn(qreal.t(u), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_ds/*' />
        public static Quadruple jacobi_ds(Quadruple u, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiDS(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiDS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiDS(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_ds/*' />
        public static Quadruple jacobi_ds(dynamic u, dynamic k)
        {
            return jacobi_ds(qreal.t(u), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_nc/*' />
        public static Quadruple jacobi_nc(Quadruple u, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiNC(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiNC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiNC(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_nc/*' />
        public static Quadruple jacobi_nc(dynamic u, dynamic k)
        {
            return jacobi_nc(qreal.t(u), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_nd/*' />
        public static Quadruple jacobi_nd(Quadruple u, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiND(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiND", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiND(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_nd/*' />
        public static Quadruple jacobi_nd(dynamic u, dynamic k)
        {
            return jacobi_nd(qreal.t(u), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_ns/*' />
        public static Quadruple jacobi_ns(Quadruple u, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiNS(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiNS", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiNS(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_ns/*' />
        public static Quadruple jacobi_ns(dynamic u, dynamic k)
        {
            return jacobi_ns(qreal.t(u), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sc/*' />
        public static Quadruple jacobi_sc(Quadruple u, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiSC(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiSC", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiSC(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sc/*' />
        public static Quadruple jacobi_sc(dynamic u, dynamic k)
        {
            return jacobi_sc(qreal.t(u), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sd/*' />
        public static Quadruple jacobi_sd(Quadruple u, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiSD(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiSD", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiSD(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sd/*' />
        public static Quadruple jacobi_sd(dynamic u, dynamic k)
        {
            return jacobi_sd(qreal.t(u), qreal.t(k));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sn/*' />
        public static Quadruple jacobi_sn(Quadruple u, Quadruple k)
        {
            var res = new Quadruple();
            Lib_QReal_JacobiSN(res.mpPtr, k.mpPtr, u.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_JacobiSN", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_JacobiSN(IntPtr res, IntPtr k, IntPtr u);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_sn/*' />
        public static Quadruple jacobi_sn(dynamic u, dynamic k)
        {
            return jacobi_sn(qreal.t(u), qreal.t(k));
        }




        #endregion



        #region Polygamma functions




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/polygamma/*' />
        public static Quadruple polygamma(int n, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Polygamma(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Polygamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Polygamma(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/polygamma/*' />
        public static Quadruple polygamma(int n, dynamic y)
        {
            return polygamma(n, qreal.t(y));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/digamma/*' />
        public static Quadruple digamma(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Digamma(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Digamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Digamma(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/digamma/*' />
        public static Quadruple digamma(dynamic x)
        {
            return digamma(qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/trigamma/*' />
        public static Quadruple trigamma(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Trigamma(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Trigamma", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Trigamma(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/trigamma/*' />
        public static Quadruple trigamma(dynamic x)
        {
            return trigamma(qreal.t(x));
        }





        #endregion



        #region Hurwitz zeta function and related functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bernoulli/*' />
        public static Quadruple bernoulli(int n)
        {
            if (n == 1) return t(-0.5);
            if (n % 2 != 0) return zero();
            var res = new Quadruple();
            Lib_QReal_BernoulliB2n(res.mpPtr, n/2);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BernoulliB2n", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_BernoulliB2n(IntPtr res, int n);




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TangentT2n/*' />
        public static Quadruple TangentT2n(int n)
        {
            var res = new Quadruple();
            Lib_QReal_TangentT2n(res.mpPtr, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_TangentT2n", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_TangentT2n(IntPtr res, int n);



        #endregion



        #region Dirichlet L-Series, Riemann zeta function, and related functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/zeta/*' />
        public static Quadruple zeta(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Zeta(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Zeta", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Zeta(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/zeta/*' />
        public static Quadruple zeta(dynamic x)
        {
            return zeta(qreal.t(x));
        }


        #endregion



        #region 0F1: Overview



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_0f1/*' />
        public static Quadruple hyperg_0f1(Quadruple b, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Hypergeo0F1(res.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Hypergeo0F1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Hypergeo0F1(IntPtr res, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_0f1/*' />
        public static Quadruple hyperg_0f1(dynamic b, dynamic x)
        {
            return hyperg_0f1(qreal.t(b), qreal.t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_0f1r/*' />
        public static Quadruple hyperg_0f1r(Quadruple b, Quadruple x)
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
        public static Quadruple hyperg_0f1r(dynamic b, dynamic x)
        {
            return hyperg_0f1r(qreal.t(b), qreal.t(x));
        }





        #endregion



        #region Bessel functions and modified Bessel functions




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv/*' />
        public static Quadruple bessel_jv(Quadruple nu, Quadruple x, bool scaled = false)
        {
            var res = new Quadruple();
            Lib_QReal_BesselJ(res.mpPtr, nu.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BesselJ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_BesselJ(IntPtr res, IntPtr nu, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv/*' />
        public static Quadruple bessel_jv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_jv(qreal.t(nu), qreal.t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv/*' />
        public static Quadruple bessel_yv(Quadruple nu, Quadruple x, bool scaled = false)
        {
            var res = new Quadruple();
            Lib_QReal_BesselY(res.mpPtr, nu.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BesselY", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_BesselY(IntPtr res, IntPtr nu, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv/*' />
        public static Quadruple bessel_yv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_yv(qreal.t(nu), qreal.t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv/*' />
        public static Quadruple bessel_iv(Quadruple nu, Quadruple x, bool scaled = false)
        {
            var res = new Quadruple();
            Lib_QReal_BesselI(res.mpPtr, nu.mpPtr, x.mpPtr);
            if (scaled) res *= exp(-abs(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BesselI", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_BesselI(IntPtr res, IntPtr nu, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv/*' />
        public static Quadruple bessel_iv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_iv(qreal.t(nu), qreal.t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv/*' />
        public static Quadruple bessel_kv(Quadruple nu, Quadruple x, bool scaled = false)
        {
            var res = new Quadruple();
            Lib_QReal_BesselK(res.mpPtr, nu.mpPtr, x.mpPtr);
            if (scaled) res *= exp(x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BesselK", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_BesselK(IntPtr res, IntPtr nu, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv/*' />
        public static Quadruple bessel_kv(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_kv(qreal.t(nu), qreal.t(x), scaled);
        }











        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_prime/*' />
        public static Quadruple bessel_jv_prime(Quadruple nu, Quadruple x, bool scaled = false)
        {
            var res = new Quadruple();
            Lib_QReal_BesselJPrime(res.mpPtr, nu.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BesselJPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_BesselJPrime(IntPtr res, IntPtr nu, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_prime/*' />
        public static Quadruple bessel_jv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_jv_prime(qreal.t(nu), qreal.t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_prime/*' />
        public static Quadruple bessel_yv_prime(Quadruple nu, Quadruple x, bool scaled = false)
        {
            var res = new Quadruple();
            Lib_QReal_BesselYPrime(res.mpPtr, nu.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BesselYPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_BesselYPrime(IntPtr res, IntPtr nu, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_prime/*' />
        public static Quadruple bessel_yv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_yv_prime(qreal.t(nu), qreal.t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv_prime/*' />
        public static Quadruple bessel_iv_prime(Quadruple nu, Quadruple x, bool scaled = false)
        {
            var res = new Quadruple();
            Lib_QReal_BesselIPrime(res.mpPtr, nu.mpPtr, x.mpPtr);
            if (scaled) res *= exp(-abs(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BesselIPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_BesselIPrime(IntPtr res, IntPtr nu, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_iv_prime/*' />
        public static Quadruple bessel_iv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_iv_prime(qreal.t(nu), qreal.t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv_prime/*' />
        public static Quadruple bessel_kv_prime(Quadruple nu, Quadruple x, bool scaled = false)
        {
            var res = new Quadruple();
            Lib_QReal_BesselKPrime(res.mpPtr, nu.mpPtr, x.mpPtr);
            if (scaled) res *= exp(x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BesselKPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_BesselKPrime(IntPtr res, IntPtr nu, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_kv_prime/*' />
        public static Quadruple bessel_kv_prime(dynamic nu, dynamic x, bool scaled = false)
        {
            return bessel_kv_prime(qreal.t(nu), qreal.t(x), scaled);
        }






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_zero/*' />
        public static Quadruple bessel_jv_zero(Quadruple x, int m)
        {
            var res = new Quadruple();
            Lib_QReal_BesselJZero(res.mpPtr, x.mpPtr, m);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BesselJZero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_BesselJZero(IntPtr res, IntPtr x, int m);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_jv_zero/*' />
        public static Quadruple bessel_jv_zero(dynamic x, int m)
        {
            return bessel_jv_zero(qreal.t(x), m);
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_zero/*' />
        public static Quadruple bessel_yv_zero(Quadruple x, int m)
        {
            var res = new Quadruple();
            Lib_QReal_BesselYZero(res.mpPtr, x.mpPtr, m);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BesselYZero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_BesselYZero(IntPtr res, IntPtr x, int m);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/bessel_yv_zero/*' />
        public static Quadruple bessel_yv_zero(dynamic x, int m)
        {
            return bessel_yv_zero(qreal.t(x), m);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_zero/*' />
        public static Quadruple sph_bessel_jn_zero(int n, int m)
        {
            return bessel_jv_zero(n + 0.5, m);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_zero/*' />
        public static Quadruple sph_bessel_yn_zero(int n, int m)
        {
            return bessel_yv_zero(n + 0.5, m);
        }





        #endregion







        #region Spherical Bessel functions and spherical modified Bessel functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn/*' />
        public static Quadruple sph_bessel_jn(Quadruple n, Quadruple x, bool scaled = false)
        {
            if (!qreal.isinteger(n)) return qreal.nan();

            if (qreal.isnan(x)) return qreal.nan();
            if (qreal.isinf(x)) return qreal.zero();
            if (qreal.isneginf(x)) return qreal.zero();
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if ((n == 0)) return qreal.one();
                    else return qreal.zero();
                }
                else
                {
                    if (lrint(n) % 2 == 0) return qreal.neginf(); else return qreal.nan();
                }
            }

            if (n < 0)
            {
                Quadruple res = sph_bessel_yn(-n - 1, x);
                if ((lrint(n) + 1) % 2 == 0) res = -res;
                return res;
            }
            else
            {
                Quadruple x1 = x;
                if (x1 <= 0) x1 = -x1;
                Quadruple res = qreal.t(0);
                Lib_QReal_SphBessel(res.mpPtr, lrint(n), x1.mpPtr);
                if ((x < 0) && !(lrint(n) % 2 == 0)) res = -res;
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_SphBessel", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_SphBessel(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn/*' />
        public static Quadruple sph_bessel_jn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_jn(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn' />
        public static Quadruple sph_bessel_yn(Quadruple n, Quadruple x, bool scaled = false)
        {
            if (!qreal.isinteger(n)) return qreal.nan();

            if (qreal.isnan(x)) return qreal.nan();
            if (qreal.isinf(x)) return qreal.zero();
            if (qreal.isneginf(x)) return qreal.zero();
            if (x == 0.0)
            {
                if (n < 0)
                {
                    if ((n == -1)) return qreal.one();
                    else return qreal.zero();
                }
                else
                {
                    if (lrint(n) % 2 != 0) return qreal.neginf(); else return qreal.nan();
                }
            }

            if (n < 0)
            {
                Quadruple res = sph_bessel_jn(-n - 1, x);
                if ((lrint(n) + 2) % 2 == 0) res = -res;
                return res;
            }
            else
            {
                Quadruple x1 = x;
                if (x1 <= 0) x1 = -x1;
                Quadruple res = qreal.t(0);
                Lib_QReal_SphNeumann(res.mpPtr, lrint(n), x1.mpPtr);
                if ((x < 0) && !((lrint(n) + 1) % 2 == 0)) res = -res;
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_SphNeumann", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_SphNeumann(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn/*' />
        public static Quadruple sph_bessel_yn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_yn(t(n), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in/*' />
        public static Quadruple sph_bessel_in(Quadruple n, Quadruple x, bool scaled = false)
        {
            if (!qreal.isinteger(n)) return qreal.nan();

            if (qreal.isnan(x)) return qreal.nan();
            if (qreal.isinf(x)) return qreal.inf();
            if (qreal.isneginf(x)) return qreal.zero();
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if ((n == 0)) return qreal.one();
                    else return qreal.zero();
                }
                else
                {
                    if (lrint(n) % 2 == 0) return qreal.neginf(); else return qreal.nan();
                }
            }

            Quadruple x1 = x;
            if (x1 <= 0) x1 = -x1;
            Quadruple res = bessel_iv(n + 0.5, x1) / sqrt(2 * x1 / pi());
            if ((x < 0) && !(lrint(n) % 2 == 0)) res = -res;
            if (scaled) res *= exp(-abs(x));
            return res;
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in/*' />
        public static Quadruple sph_bessel_in(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_in(t(n), t(x), scaled);
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn/*' />
        public static Quadruple sph_bessel_kn(Quadruple n, Quadruple x, bool scaled = false)
        {
            if (!qreal.isinteger(n)) return qreal.nan();

            if (qreal.isnan(x)) return qreal.nan();
            if (qreal.isinf(x)) return qreal.zero();
            if (qreal.isneginf(x)) return qreal.neginf();
            if (x == 0.0)
            {
                if (n >= 0)
                {
                    if (lrint(n) % 2 == 0) return qreal.nan(); else return qreal.inf();
                }
                else
                {
                    if (lrint(n) % 2 == 0) return qreal.inf(); else return qreal.nan();
                }
            }
            Quadruple res;
            if (x >= 0.0f) res = bessel_kv(n + 0.5, x) / sqrt(2 * x / pi());
            else res = -0.5f * pi() * (sph_bessel_in(n, -x) + sph_bessel_in(-n - 1, -x));
            if (scaled) res *= exp(x);
            return res;

        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn/*' />
        public static Quadruple sph_bessel_kn(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_kn(t(n), t(x), scaled);
        }



        internal static Quadruple besselpoly_(int n, Quadruple x)
        {
            if (n < 0) n = Math.Abs(n) - 1;
            if (n == 0) return t(1.0);
            if (n == 1) return x + 1;
            var y = new Quadruple[n + 2];
            y[0] = t(1);
            y[1] = x + 1;
            for (int i = 2; i <= n; i++)
            {
                y[i] = (2 * i - 1) * x * y[i - 1] + y[i - 2];
            }
            return y[n];
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besselpoly/*' />
        public static Quadruple besselpoly(Quadruple n, Quadruple x, bool scaled = false)
        {
            if (!qreal.isinteger(n)) return qreal.nan();
            if (abs(x) < t(0.01)) return besselpoly_(lrint(n), x);
            else
            {
                Quadruple res = sph_bessel_kn(n, 1 / x);
                res *= exp(1 / x) * 2 / (pi() * x);
                return res;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besselpoly/*' />
        public static Quadruple besselpoly(dynamic n, dynamic x, bool scaled = false)
        {
            return besselpoly(t(n), t(x), scaled);
        }





        internal static Quadruple besseltheta_(int n, Quadruple x)
        {
            if (n < 0) n = Math.Abs(n) - 1;
            if (n == 0) return t(1.0);
            if (n == 1) return x + 1;
            var y = new Quadruple[n + 2];
            y[0] = t(1);
            y[1] = x + 1;
            for (int i = 2; i <= n; i++)
            {
                y[i] = (2 * i - 1) * y[i - 1] + x * x * y[i - 2];
            }
            return y[n];
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besseltheta/*' />
        public static Quadruple besseltheta(Quadruple n, Quadruple x, bool scaled = false)
        {
            if (!qreal.isinteger(n)) return qreal.nan();
            if ((x == 0) && (n < 0)) return qreal.nan();
            if ((abs(x) < t(0.01)) && (n >= 0)) return besseltheta_(lrint(n), x);
            if (n < 0) return pow(x, n) * besselpoly(n, 1 / x);
            else
            {
                Quadruple res = sph_bessel_kn(n, x);
                res *= qreal.pow(x, n + 1) * exp(x) * 2 / pi();
                return res;
            }
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/besseltheta/*' />
        public static Quadruple besseltheta(dynamic n, dynamic x, bool scaled = false)
        {
            return besseltheta(t(n), t(x), scaled);
        }






        #endregion




        #region Spherical Bessel functions, first derivative




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_prime/*' />
        public static Quadruple sph_bessel_jn_prime(Quadruple n, Quadruple x, bool scaled = false)
        {
            if (!qreal.isinteger(n)) return qreal.nan();

            if (qreal.isnan(x)) return qreal.nan();
            if (qreal.isinf(x)) return qreal.zero();
            if (qreal.isneginf(x)) return qreal.zero();
            if (x == 0.0)
            {
                if (n == 1) return 1 / qreal.t(3);
                if (n >= 0) return qreal.zero();
                else
                {
                    if (lrint(n) % 2 != 0) return qreal.neginf(); else return qreal.nan();
                }
            }
            return (n * sph_bessel_jn(n - 1, x, scaled) - (n + 1) * sph_bessel_jn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_jn_prime/*' />
        public static Quadruple sph_bessel_jn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_jn_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_prime/*' />
        public static Quadruple sph_bessel_yn_prime(Quadruple n, Quadruple x, bool scaled = false)
        {
            if (!qreal.isinteger(n)) return qreal.nan();

            if (qreal.isnan(x)) return qreal.nan();
            if (qreal.isinf(x)) return qreal.zero();
            if (qreal.isneginf(x)) return qreal.zero();
            if (x == 0.0)
            {
                if (n == -2) return -1 / qreal.t(3);
                if (n < 0) return qreal.zero();
                else
                {
                    if (lrint(n) % 2 == 0) return qreal.inf(); else return qreal.nan();
                }
            }
            return (n * sph_bessel_yn(n - 1, x, scaled) - (n + 1) * sph_bessel_yn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_yn_prime/*' />
        public static Quadruple sph_bessel_yn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_yn_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in_prime/*' />
        public static Quadruple sph_bessel_in_prime(Quadruple n, Quadruple x, bool scaled = false)
        {
            if (!qreal.isinteger(n)) return qreal.nan();

            if (qreal.isnan(x)) return qreal.nan();
            if (qreal.isinf(x)) return qreal.inf();
            if (qreal.isneginf(x))
            {
                if (lrint(n) % 2 == 0) return qreal.neginf(); else return qreal.inf();
            }
            if (x == 0.0)
            {
                if (n == 0) return qreal.zero();
                if (n < 0)
                {
                    if (lrint(n) % 2 != 0) return qreal.neginf(); else return qreal.nan();
                }
            }
            return (n * sph_bessel_in(n - 1, x, scaled) + (n + 1) * sph_bessel_in(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_in_prime/*' />
        public static Quadruple sph_bessel_in_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_in_prime(t(n), t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn_prime/*' />
        public static Quadruple sph_bessel_kn_prime(Quadruple n, Quadruple x, bool scaled = false)
        {
            if (!qreal.isinteger(n)) return qreal.nan();

            if (qreal.isnan(x)) return qreal.nan();
            if (qreal.isinf(x)) return qreal.zero();
            if (qreal.isneginf(x)) return qreal.neginf();
            if (x == 0.0)
            {
                if (((n >= 0) && (lrint(n) % 2 == 0)) || ((n < 0) && (lrint(n) % 2 != 0))) return qreal.neginf();
                else return qreal.nan();
            }
            return -(n * sph_bessel_kn(n - 1, x, scaled) + (n + 1) * sph_bessel_kn(n + 1, x, scaled)) / (2 * n + 1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_bessel_kn_prime/*' />
        public static Quadruple sph_bessel_kn_prime(dynamic n, dynamic x, bool scaled = false)
        {
            return sph_bessel_kn_prime(t(n), t(x), scaled);
        }





        #endregion








        #region Hankel functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h1/*' />
        public static QuadrupleC hankel_h1(Quadruple v, Quadruple x)
        {
            return bessel_jv(v, x) + qcplx.onej() * bessel_yv(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h1/*' />
        public static QuadrupleC hankel_h1(dynamic v, dynamic x)
        {
            return hankel_h1(t(v), t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h2/*' />
        public static QuadrupleC hankel_h2(Quadruple v, Quadruple x)
        {
            return bessel_jv(v, x) - qcplx.onej() * bessel_yv(v, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hankel_h2/*' />
        public static QuadrupleC hankel_h2(dynamic v, dynamic x)
        {
            return hankel_h2(t(v), t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h1/*' />
        public static QuadrupleC sph_hankel_h1(int n, Quadruple x)
        {
            return sph_bessel_jn(n, x) + qcplx.onej() * sph_bessel_yn(n, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h1/*' />
        public static QuadrupleC sph_hankel_h1(int n, dynamic x)
        {
            return sph_hankel_h1(n, t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h2/*' />
        public static QuadrupleC sph_hankel_h2(int n, Quadruple x)
        {
            return sph_bessel_jn(n, x) - qcplx.onej() * sph_bessel_yn(n, x);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/sph_hankel_h2/*' />
        public static QuadrupleC sph_hankel_h2(int n, dynamic x)
        {
            return sph_hankel_h2(n, t(x));
        }






        #endregion






        #region Airy functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai/*' />
        public static Quadruple airy_ai(Quadruple x, bool scaled = false)
        {
            var res = new Quadruple();
            Lib_QReal_AiryAi(res.mpPtr, x.mpPtr);
            if ((scaled) && (x > 0)) res *= exp((qreal.t(2) / qreal.t(3)) * x * sqrt(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_AiryAi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_AiryAi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai/*' />
        public static Quadruple airy_ai(dynamic x, bool scaled = false)
        {
            return airy_ai(qreal.t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi/*' />
        public static Quadruple airy_bi(Quadruple x, bool scaled = false)
        {
            var res = new Quadruple();
            Lib_QReal_AiryBi(res.mpPtr, x.mpPtr);
            if ((scaled) && (x > 0)) res *= exp(-abs(qreal.t(2) / qreal.t(3) * (x * sqrt(x))));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_AiryBi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_AiryBi(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi/*' />
        public static Quadruple airy_bi(dynamic x, bool scaled = false)
        {
            return airy_bi(qreal.t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai_prime/*' />
        public static Quadruple airy_ai_prime(Quadruple x, bool scaled = false)
        {
            var res = new Quadruple();
            Lib_QReal_AiryAiPrime(res.mpPtr, x.mpPtr);
            if ((scaled) && (x > 0)) res *= exp((qreal.t(2) / qreal.t(3)) * x * sqrt(x));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_AiryAiPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_AiryAiPrime(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai_prime/*' />
        public static Quadruple airy_ai_prime(dynamic x, bool scaled = false)
        {
            return airy_ai_prime(qreal.t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi_prime/*' />
        public static Quadruple airy_bi_prime(Quadruple x, bool scaled = false)
        {
            var res = new Quadruple();
            Lib_QReal_AiryBiPrime(res.mpPtr, x.mpPtr);
            if ((scaled) && (x > 0)) res *= exp(-abs(qreal.t(2) / qreal.t(3) * (x * sqrt(x))));
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_AiryBiPrime", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_AiryBiPrime(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_bi_prime/*' />
        public static Quadruple airy_bi_prime(dynamic x, bool scaled = false)
        {
            return airy_bi_prime(qreal.t(x), scaled);
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai_zero/*' />
        public static Quadruple airy_ai_zero(int n)
        {
            var res = new Quadruple();
            Lib_QReal_Aizero(res.mpPtr, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Aizero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Aizero(IntPtr res, int n);



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/airy_ai_zero/*' />
        public static Quadruple airy_bi_zero(int n)
        {
            var res = new Quadruple();
            Lib_QReal_Bizero(res.mpPtr, n);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Bizero", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Bizero(IntPtr res, int n);



        #endregion



        #region 1F1 Overview




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_1f1/*' />
        public static Quadruple hyperg_1f1(Quadruple a, Quadruple b, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Hypergeo1F1(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Hypergeo1F1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Hypergeo1F1(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_1f1/*' />
        public static Quadruple hyperg_1f1(dynamic a, dynamic b, dynamic x)
        {
            return hyperg_1f1(qreal.t(a), qreal.t(b), qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_1f1r/*' />
        public static Quadruple hyperg_1f1r(Quadruple a, Quadruple b, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Hypergeo1F1r(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Hypergeo1F1r", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Hypergeo1F1r(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hyperg_1f1r/*' />
        public static Quadruple hyperg_1f1r(dynamic a, dynamic b, dynamic x)
        {
            return hyperg_1f1r(qreal.t(a), qreal.t(b), qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/log_hyperg_1f1/*' />
        public static Quadruple log_hyperg_1f1(Quadruple a, Quadruple b, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_LogHypergeo1F1(res.mpPtr, a.mpPtr, b.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LogHypergeo1F1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_LogHypergeo1F1(IntPtr res, IntPtr a, IntPtr b, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/log_hyperg_1f1/*' />
        public static Quadruple log_hyperg_1f1(dynamic a, dynamic b, dynamic x)
        {
            return log_hyperg_1f1(qreal.t(a), qreal.t(b), qreal.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/laguerre_l/*' />
        public static Quadruple laguerre_l(int n, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Laguerre(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Laguerre", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Laguerre(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/laguerre_l/*' />
        public static Quadruple laguerre_l(int n, dynamic y)
        {
            return laguerre_l(n, qreal.t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hermite_h/*' />
        public static Quadruple hermite_h(int n, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Hermite(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Hermite", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Hermite(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hermite_h/*' />
        public static Quadruple hermite_h(int n, dynamic y)
        {
            return hermite_h(n, qreal.t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hermite_he/*' />
        public static Quadruple hermite_he(int n, Quadruple x)
        {
            return exp2(-n / 2) * hermite_h(n, x / sqrt(2));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hermite_he/*' />
        public static Quadruple hermite_he(int n, dynamic x)
        {
            return hermite_he(n, qreal.t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/laguerre_l/*' />
        public static Quadruple laguerre_l(int n, int m, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_LaguerreM(res.mpPtr, n, m, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LaguerreM", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_LaguerreM(IntPtr res, int n, int m, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/hermite_h/*' />
        public static Quadruple laguerre_l(int n, int m, dynamic y)
        {
            return laguerre_l(n, m, qreal.t(y));
        }





        #endregion



        #region Exponential integrals and related functions



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/exp_integral_ei/*' />
        public static Quadruple exp_integral_ei(Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Ei(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Ei", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Ei(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/exp_integral_ei/*' />
        public static Quadruple exp_integral_ei(dynamic x)
        {
            return exp_integral_ei(qreal.t(x));
        }






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/exp_integral_en/*' />
        public static Quadruple exp_integral_en(int n, Quadruple x)
        {
            if (n < 0) return nan();
            var res = new Quadruple();
            Lib_QReal_expint(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_expint", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_expint(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/exp_integral_ei/*' />
        public static Quadruple exp_integral_en(int n, dynamic x)
        {
            return exp_integral_en(n, t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp_integral_e1/*' />
        public static Quadruple exp_integral_e1(Quadruple z)
        {
            if (z < 0) return -exp_integral_ei(-z);
            else return exp_integral_en(1, z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp_integral_e1/*' />
        public static Quadruple exp_integral_e1(dynamic z)
        {
            return exp_integral_e1(qreal.t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log_integral/*' />
        public static Quadruple log_integral(Quadruple z)
        {
            if (z < 0) return nan();
            if (z == 0) return zero();
            else return exp_integral_ei(log(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log_integral/*' />
        public static Quadruple log_integral(dynamic z)
        {
            return log_integral(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh_integral/*' />
        public static Quadruple cosh_integral(Quadruple x)
        {
            return (exp_integral_ei(x) - exp_integral_e1(x)) / 2;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh_integral/*' />
        public static Quadruple cosh_integral(dynamic z)
        {
            return cosh_integral(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh_integral/*' />
        public static Quadruple sinh_integral(Quadruple x)
        {
            return (exp_integral_ei(x) + exp_integral_e1(x)) / 2;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh_integral/*' />
        public static Quadruple sinh_integral(dynamic z)
        {
            return sinh_integral(t(z));
        }




        #endregion





        #region 2F1-related orthogonal polynomials





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_t/*' />
        public static Quadruple chebyshev_t(int n, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_ChebyshevT(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ChebyshevT", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ChebyshevT(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_t/*' />
        public static Quadruple chebyshev_t(int n, dynamic y)
        {
            return chebyshev_t(n, qreal.t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_u/*' />
        public static Quadruple chebyshev_u(int n, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_ChebyshevU(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ChebyshevU", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ChebyshevU(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_u/*' />
        public static Quadruple chebyshev_u(int n, dynamic y)
        {
            return chebyshev_u(n, qreal.t(y));
        }







        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_v/*' />
        public static Quadruple chebyshev_v(int n, Quadruple x)  // same as t_n(x)
        {
            if (x < 0.0)
            {
                int m = -1; if (n % 2 == 0) m = 1; // m = exp(i * n * pi)
                return m * chebyshev_w(n, -x);
            }
            else return sqrt(2 / (1 + x)) * chebyshev_t(2 * n + 1, sqrt((x + 1) / 2));
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_u/*' />
        public static Quadruple chebyshev_v(int n, dynamic y)
        {
            return chebyshev_v(n, t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_w/*' />
        public static Quadruple chebyshev_w(int n, Quadruple x)  // same as u_n(x)
        {
            if (x < 0.0)
            {
                int m = -1; if (n % 2 == 0) m = 1; // m = exp(i * n * pi)
                return m * chebyshev_v(n, -x);
            }
            else return chebyshev_u(2 * n, sqrt((x + 1) / 2));
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/chebyshev_w/*' />
        public static Quadruple chebyshev_w(int n, dynamic y)
        {
            return chebyshev_w(n, t(y));
        }








        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_p/*' />
        public static Quadruple legendre_p(int n, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_LegendreP(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LegendreP", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_LegendreP(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_p/*' />
        public static Quadruple legendre_p(int n, dynamic y)
        {
            return legendre_p(n, qreal.t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_q/*' />
        public static Quadruple legendre_q(int n, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_LegendreQ(res.mpPtr, n, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LegendreQ", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_LegendreQ(IntPtr res, int n, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_q/*' />
        public static Quadruple legendre_q(int n, dynamic y)
        {
            return legendre_q(n, qreal.t(y));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_plm/*' />
        public static Quadruple legendre_plm(int n, int m, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_LegendrePM(res.mpPtr, n, m, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LegendrePM", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_LegendrePM(IntPtr res, int n, int m, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/legendre_plm/*' />
        public static Quadruple legendre_plm(int n, int m, dynamic y)
        {
            return legendre_plm(n, m, qreal.t(y));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gegenbauer_c/*' />
        public static Quadruple gegenbauer_c(int n, Quadruple lambda1, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Gegenbauer(res.mpPtr, n, lambda1.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Gegenbauer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Gegenbauer(IntPtr res, int n, IntPtr lambda1, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/gegenbauer_c/*' />
        public static Quadruple gegenbauer_c(int n, dynamic lambda1, dynamic x)
        {
            return gegenbauer_c(n, t(lambda1), t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_p/*' />
        public static Quadruple jacobi_p(int n, Quadruple alpha, Quadruple beta, Quadruple x)
        {
            var res = new Quadruple();
            Lib_QReal_Jacobi(res.mpPtr, n, alpha.mpPtr, beta.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Jacobi", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Jacobi(IntPtr res, int n, IntPtr alpha, IntPtr beta, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/jacobi_p/*' />
        public static Quadruple jacobi_p(int n, dynamic alpha, dynamic beta, dynamic x)
        {
            return jacobi_p(n, t(alpha), t(beta), t(x));
        }











        internal static Quadruple spherical_harmonic_r(int n, int m, Quadruple theta, Quadruple phi)
        {
            var res = new Quadruple();
            Lib_QReal_SphericalHarmonicR(res.mpPtr, n, m, theta.mpPtr, phi.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_SphericalHarmonicR", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_SphericalHarmonicR(IntPtr res, int n, int m, IntPtr theta, IntPtr phi);


        internal static Quadruple spherical_harmonic_i(int n, int m, Quadruple theta, Quadruple phi)
        {
            var res = new Quadruple();
            Lib_QReal_SphericalHarmonicI(res.mpPtr, n, m, theta.mpPtr, phi.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_SphericalHarmonicI", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_SphericalHarmonicI(IntPtr res, int n, int m, IntPtr theta, IntPtr phi);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/spherical_y/*' />
        public static QuadrupleC spherical_y(Quadruple n, Quadruple m, Quadruple theta, Quadruple phi)
        {
            return qcplx.t(spherical_harmonic_r(lrint(n), lrint(m), theta, phi),
                           spherical_harmonic_i(lrint(n), lrint(m), theta, phi));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/spherical_y/*' />
        public static QuadrupleC spherical_y(dynamic n, dynamic m, dynamic theta, dynamic phi)
        {
            return spherical_y(qreal.t(n), qreal.t(m), qreal.t(theta), qreal.t(phi));
        }





        #endregion



        #endregion








        #region Boost Distributions as classes


        #region Base classes

        public class BaseDistClass
        {
            internal static Quadruple nil = zero();
            internal static int target = 1;
            //internal static Quadruple a_;
            //internal static Quadruple b_;
            //internal static Quadruple c_;
            //internal static Quadruple lambda1_;
            //internal static Quadruple delta_;
            //internal static Quadruple k_;
            //internal static Quadruple m_;
            //internal static Quadruple n_;
            //internal static Quadruple p_;
            //internal static Quadruple r_;
            //internal static Quadruple mu_;
            //internal static Quadruple sigma_;


            internal virtual Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                return res;
            }

            public static qreal ctx
            {
                get { return new qreal(); }
            }

            //public qreal ctx()
            //{
            //    return new qreal();
            //}


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/cdf/*' />
            public Quadruple cdf(Quadruple x)
            {
                target = 2;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/cdf/*' />
            public Quadruple cdf(dynamic x)
            {
                target = 2;
                return BaseDist(qreal.t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/sf/*' />
            public Quadruple sf(Quadruple x)
            {
                target = 3;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/sf/*' />
            public Quadruple sf(dynamic x)
            {
                target = 3;
                return BaseDist(qreal.t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/hf/*' />
            public Quadruple hf(Quadruple x)
            {
                target = 4;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/hf/*' />
            public Quadruple hf(dynamic x)
            {
                target = 4;
                return BaseDist(qreal.t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/chf/*' />
            public Quadruple chf(Quadruple x)
            {
                target = 5;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/chf/*' />
            public Quadruple chf(dynamic x)
            {
                target = 5;
                return BaseDist(qreal.t(x));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/qtf/*' />
            public Quadruple qtf(Quadruple q)
            {
                target = 6;
                return BaseDist(q);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/qtf/*' />
            public Quadruple qtf(dynamic q)
            {
                target = 6;
                return BaseDist(qreal.t(q));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/isf/*' />
            public Quadruple isf(Quadruple q)
            {
                target = 7;
                return BaseDist(q);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/isf/*' />
            public Quadruple isf(dynamic q)
            {
                target = 7;
                return BaseDist(qreal.t(q));
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/mean/*' />
            public Quadruple mean()
            {
                target = 8;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/median/*' />
            public Quadruple median()
            {
                target = 9;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/mode/*' />
            public Quadruple mode()
            {
                target = 10;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/variance/*' />
            public Quadruple variance()
            {
                target = 11;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/stdev/*' />
            public Quadruple stdev()
            {
                target = 12;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/skewness/*' />
            public Quadruple skewness()
            {
                target = 13;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/kurtosis/*' />
            public Quadruple kurtosis()
            {
                target = 14;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/kurtosis_excess/*' />
            public Quadruple kurtosis_excess()
            {
                target = 15;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/support_lower_endpoint/*' />
            public Quadruple support_lower_endpoint()
            {
                target = 16;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/support_upper_endpoint/*' />
            public Quadruple support_upper_endpoint()
            {
                target = 17;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/range_lower_endpoint/*' />
            public Quadruple range_lower_endpoint()
            {
                target = 18;
                return BaseDist(nil);
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/range_upper_endpoint/*' />
            public Quadruple range_upper_endpoint()
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
            public Quadruple pdf(Quadruple x)
            {
                target = 1;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/pdf/*' />
            public Quadruple pdf(dynamic x)
            {
                target = 1;
                return BaseDist(qreal.t(x));
            }
        }


        public class BaseDistDiscreteClass : BaseDistClass
        {
            public bool IsContinuous()
            {
                return false;
            }

            /// <include file="docs.xml" path='docs/members[@name="Boost"]/pmf/*' />
            public Quadruple pmf(Quadruple x)
            {
                target = 1;
                return BaseDist(x);
            }


            /// <include file="docs.xml" path='docs/members[@name="Boost"]/pmf/*' />
            public Quadruple pmf(dynamic x)
            {
                target = 1;
                return BaseDist(qreal.t(x));
            }
        }


        #endregion



        #region Discrete (lattice) distribution functions



        #region BernoulliDist


        public class BernoulliDistClass : BaseDistDiscreteClass
        {
            Quadruple p;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_BernoulliDist(target, res.mpPtr, xqp.mpPtr, p.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BernoulliDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_BernoulliDist(int target, IntPtr res, IntPtr xqp, IntPtr p);

            public BernoulliDistClass(Quadruple _p)
            {
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BernoulliDist/*' />
        public static BernoulliDistClass dist_bernoulli(Quadruple p)
        {
            return new BernoulliDistClass(p);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BernoulliDist/*' />
        public static BernoulliDistClass dist_bernoulli(dynamic p)
        {
            return dist_bernoulli(qreal.t(p));
        }

        #endregion



        #region GeometricDist


        public class GeometricDistClass : BaseDistDiscreteClass
        {
            Quadruple p;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_GeometricDist(target, res.mpPtr, xqp.mpPtr, p.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GeometricDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_GeometricDist(int target, IntPtr res, IntPtr xqp, IntPtr p);

            public GeometricDistClass(Quadruple _p)
            {
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GeometricDist/*' />
        public static GeometricDistClass dist_geometric(Quadruple p)
        {
            return new GeometricDistClass(p);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GeometricDist/*' />
        public static GeometricDistClass dist_geometric(dynamic p)
        {
            return dist_geometric(qreal.t(p));
        }

        #endregion



        #region PoissonDist


        public class PoissonDistClass : BaseDistDiscreteClass
        {
            Quadruple mu;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_PoissonDist(target, res.mpPtr, xqp.mpPtr, mu.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_PoissonDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_PoissonDist(int target, IntPtr res, IntPtr xqp, IntPtr mu);

            public PoissonDistClass(Quadruple _mu)
            {
                mu = _mu;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/PoissonDist/*' />
        public static PoissonDistClass dist_poisson(Quadruple mu)
        {
            return new PoissonDistClass(mu);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/PoissonDist/*' />
        public static PoissonDistClass dist_poisson(dynamic mu)
        {
            return dist_poisson(qreal.t(mu));
        }

        #endregion



        #region BinomialDist


        public class BinomialDistClass : BaseDistDiscreteClass
        {
            Quadruple n;
            Quadruple p;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_BinomialDist(target, res.mpPtr, xqp.mpPtr, n.mpPtr, p.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BinomialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_BinomialDist(int target, IntPtr res, IntPtr xqp, IntPtr n, IntPtr p);

            public BinomialDistClass(Quadruple _n, Quadruple _p)
            {
                n = _n;
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BinomialDist/*' />
        public static BinomialDistClass dist_binomial(Quadruple n, Quadruple p)
        {
            return new BinomialDistClass(n, p);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BinomialDist/*' />
        public static BinomialDistClass dist_binomial(dynamic n, dynamic p)
        {
            return dist_binomial(qreal.t(n), qreal.t(p));
        }

        #endregion



        #region NegBinomialDist


        public class NegBinomialDistClass : BaseDistDiscreteClass
        {
            Quadruple r;
            Quadruple p;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_NegBinomialDist(target, res.mpPtr, xqp.mpPtr, r.mpPtr, p.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_NegBinomialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_NegBinomialDist(int target, IntPtr res, IntPtr xqp, IntPtr r, IntPtr p);

            public NegBinomialDistClass(Quadruple _r, Quadruple _p)
            {
                r = _r;
                p = _p;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NegBinomialDist/*' />
        public static NegBinomialDistClass dist_negbinomial(Quadruple r, Quadruple p)
        {
            return new NegBinomialDistClass(r, p);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NegBinomialDist/*' />
        public static NegBinomialDistClass dist_negbinomial(dynamic r, dynamic p)
        {
            return dist_negbinomial(qreal.t(r), qreal.t(p));
        }

        #endregion



        #region HypergeometricDist


        public class HypergeometricDistClass : BaseDistDiscreteClass
        {
            internal UInt64 r__;
            internal UInt64 n__;
            internal UInt64 NN__;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_HypergeometricDist(target, res.mpPtr, xqp.mpPtr, r__, n__, NN__);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_HypergeometricDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_HypergeometricDist(int target, IntPtr res, IntPtr xqp, UInt64 r, UInt64 n, UInt64 NN);

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
        //    return dist_hypergeometric(qreal.t(r), qreal.t(n), qreal.t(NN));
        //}

        #endregion







        #endregion



        #region Closed form distributions, based on elementary functions



        #region ArcsineDist


        public class ArcsineDistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple b;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_ArcsineDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ArcsineDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_ArcsineDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public ArcsineDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ArcsineDist/*' />
        public static ArcsineDistClass dist_arcsine(Quadruple a, Quadruple b)
        {
            return new ArcsineDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ArcsineDist/*' />
        public static ArcsineDistClass dist_arcsine(dynamic a, dynamic b)
        {
            return dist_arcsine(qreal.t(a), qreal.t(b));
        }

        #endregion




        #region CauchyDist


        public class CauchyDistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_CauchyDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_CauchyDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_CauchyDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public CauchyDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/CauchyDist/*' />
        public static CauchyDistClass dist_cauchy(Quadruple a, Quadruple b)
        {
            return new CauchyDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/CauchyDist/*' />
        public static CauchyDistClass dist_cauchy(dynamic a, dynamic b)
        {
            return dist_cauchy(qreal.t(a), qreal.t(b));
        }

        #endregion




        #region ExponentialDist


        public class ExponentialDistClass : BaseDistContClass
        {
            Quadruple lambda1;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_ExponentialDist(target, res.mpPtr, xqp.mpPtr, lambda1.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ExponentialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_ExponentialDist(int target, IntPtr res, IntPtr xqp, IntPtr lambda1);

            public ExponentialDistClass(Quadruple _lambda1)
            {
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExponentialDist/*' />
        public static ExponentialDistClass dist_exponential(Quadruple lambda1)
        {
            return new ExponentialDistClass(lambda1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExponentialDist/*' />
        public static ExponentialDistClass dist_exponential(dynamic lambda1)
        {
            return dist_exponential(qreal.t(lambda1));
        }

        #endregion




        #region GumbelDist


        public class GumbelDistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_GumbelDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GumbelDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_GumbelDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public GumbelDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GumbelDist/*' />
        public static GumbelDistClass dist_gumbel(Quadruple a, Quadruple b)
        {
            return new GumbelDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GumbelDist/*' />
        public static GumbelDistClass dist_gumbel(dynamic a, dynamic b)
        {
            return dist_gumbel(qreal.t(a), qreal.t(b));
        }

        #endregion




        #region HyperexponentialDist


        public class HyperexponentialDistClass : BaseDistContClass
        {
            private QuadrupleVec matProb_ = new QuadrupleVec();
            private QuadrupleVec matRate_ = new QuadrupleVec();

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_HyperexponentialDist(target, res.mpPtr, xqp.mpPtr, matProb_.mpPtr, matRate_.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_HyperexponentialDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_HyperexponentialDist(int target, IntPtr res, IntPtr xqp, IntPtr Prob, IntPtr Rate);

            public HyperexponentialDistClass(QuadrupleVec Prob, QuadrupleVec Rate)
            {
                matProb_ = Prob;
                matRate_ = Rate;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/HyperexponentialDist/*' />
        public static HyperexponentialDistClass dist_hyperexponential(QuadrupleVec Prob, QuadrupleVec Rate)
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
            Quadruple a;
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                Quadruple res = t(0);
                Quadruple pdf = t(0);
                Quadruple sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    res = a * b * pow(xqp, a - 1);
                    Quadruple temp = pow(-powm1(xqp, a), b - 1);
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

            public KumaraswamyDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_kumaraswamy/*' />
        public static KumaraswamyDistClass dist_kumaraswamy(Quadruple a, Quadruple b)
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
            Quadruple a;
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_LaplaceDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LaplaceDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_LaplaceDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public LaplaceDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LaplaceDist/*' />
        public static LaplaceDistClass dist_laplace(Quadruple a, Quadruple b)
        {
            return new LaplaceDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LaplaceDist/*' />
        public static LaplaceDistClass dist_laplace(dynamic a, dynamic b)
        {
            return dist_laplace(qreal.t(a), qreal.t(b));
        }

        #endregion




        #region LogisticDist


        public class LogisticDistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_LogisticDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LogisticDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_LogisticDist(int target, IntPtr res, IntPtr xqp, IntPtr loc, IntPtr scale);

            public LogisticDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LogisticDist/*' />
        public static LogisticDistClass dist_logistic(Quadruple a, Quadruple b)
        {
            return new LogisticDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LogisticDist/*' />
        public static LogisticDistClass dist_logistic(dynamic a, dynamic b)
        {
            return dist_logistic(qreal.t(a), qreal.t(b));
        }

        #endregion




        #region ParetoDist


        public class ParetoDistClass : BaseDistContClass
        {
            Quadruple k;
            Quadruple a;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_ParetoDist(target, res.mpPtr, xqp.mpPtr, k.mpPtr, a.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ParetoDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_ParetoDist(int target, IntPtr res, IntPtr xqp, IntPtr k, IntPtr a);

            public ParetoDistClass(Quadruple _k, Quadruple _a)
            {
                k = _k;
                a = _a;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ParetoDist/*' />
        public static ParetoDistClass dist_pareto(Quadruple k, Quadruple a)
        {
            return new ParetoDistClass(k, a);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ParetoDist/*' />
        public static ParetoDistClass dist_pareto(dynamic k, dynamic a)
        {
            return dist_pareto(qreal.t(k), qreal.t(a));
        }

        #endregion




        #region RayleighDist


        public class RayleighDistClass : BaseDistContClass
        {
            Quadruple b;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_RayleighDist(target, res.mpPtr, xqp.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_RayleighDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_RayleighDist(int target, IntPtr res, IntPtr xqp, IntPtr b);

            public RayleighDistClass(Quadruple _b)
            {
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RayleighDist/*' />
        public static RayleighDistClass dist_rayleigh(Quadruple b)
        {
            return new RayleighDistClass(b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RayleighDist/*' />
        public static RayleighDistClass dist_rayleigh(dynamic b)
        {
            return dist_rayleigh(qreal.t(b));
        }

        #endregion




        #region TriangularDist


        public class TriangularDistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple m;
            Quadruple b;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_TriangularDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, m.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_TriangularDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_TriangularDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr m, IntPtr b);

            public TriangularDistClass(Quadruple _a, Quadruple _m, Quadruple _b)
            {
                a = _a;
                m = _m;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TriangularDist/*' />
        public static TriangularDistClass dist_triangular(Quadruple a, Quadruple m, Quadruple b)
        {
            return new TriangularDistClass(a, m, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TriangularDist/*' />
        public static TriangularDistClass dist_triangular(dynamic a, dynamic m, dynamic b)
        {
            return dist_triangular(qreal.t(a), qreal.t(m), qreal.t(b));
        }

        #endregion




        #region UniformDist


        public class UniformDistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_UniformDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_UniformDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_UniformDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public UniformDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/UniformDist/*' />
        public static UniformDistClass dist_uniform(Quadruple a, Quadruple b)
        {
            return new UniformDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/UniformDist/*' />
        public static UniformDistClass dist_uniform(dynamic a, dynamic b)
        {
            return dist_uniform(qreal.t(a), qreal.t(b));
        }

        #endregion




        #region WeibullDist


        public class WeibullDistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple b;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_WeibullDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_WeibullDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_WeibullDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public WeibullDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WeibullDist/*' />
        public static WeibullDistClass dist_weibull(Quadruple a, Quadruple b)
        {
            return new WeibullDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WeibullDist/*' />
        public static WeibullDistClass dist_weibull(dynamic a, dynamic b)
        {
            return dist_weibull(qreal.t(a), qreal.t(b));
        }

        #endregion


        #endregion



        #region Closed form distributions, based on the error function



        #region LevyDist


        public class LevyDistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple b;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                Quadruple res = t(0);
                Quadruple pdf = t(0);
                Quadruple sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Quadruple s = sqrt(b / (2 * pi()));
                    Quadruple t = exp(-b / (2 * (xqp - a)));
                    Quadruple u = pow(xqp - a, 1.5);
                    pdf = s * t / u;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    Quadruple s = sqrt(b / (2 * (xqp - a)));
                    sf = erf(s);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            Quadruple s = sqrt(b / (2 * (xqp - a)));
                            res = erfc(s); break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            Quadruple s1 = erfc_inv(xqp);
                            s1 = 2 * s1 * s1;
                            res = a + b / s1; break;
                        } // qtf, Pinv
                    case 7:
                        {
                            Quadruple s1 = erf_inv(xqp);
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

            public LevyDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_levy/*' />
        public static LevyDistClass dist_levy(Quadruple a, Quadruple b)
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
            Quadruple a;
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_LognormalDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LognormalDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_LognormalDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public LognormalDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LognormalDist/*' />
        public static LognormalDistClass dist_lognormal(Quadruple a, Quadruple b)
        {
            return new LognormalDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LognormalDist/*' />
        public static LognormalDistClass dist_lognormal(dynamic a, dynamic b)
        {
            return dist_lognormal(qreal.t(a), qreal.t(b));
        }

        #endregion





        #region MoyalDist


        public class MoyalDistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                Quadruple res = t(0);
                Quadruple pdf = t(0);
                Quadruple sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Quadruple t1 = (xqp - a) / (2 * b);
                    Quadruple t2 = t("0.5") * exp(-(xqp - a) / b);
                    Quadruple s = b * sqrt(2 * pi());
                    pdf = exp(-t1 - t2) / s;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    Quadruple s = exp(-(xqp - a) / (2 * b)) / sqrt(2);
                    sf = erf(s);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            Quadruple s = exp(-(xqp - a) / (2 * b)) / sqrt(2);
                            res = erfc(s); break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            Quadruple s1 = erfc_inv(xqp);
                            s1 = 2 * s1 * s1;
                            res = a - b * log(s1); break;
                        } // qtf, Pinv
                    case 7:
                        {
                            Quadruple s1 = erf_inv(xqp);
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

            public MoyalDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_moyal/*' />
        public static MoyalDistClass dist_moyal(Quadruple a, Quadruple b)
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
            Quadruple mu;
            Quadruple sigma;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_NormalDist(target, res.mpPtr, xqp.mpPtr, mu.mpPtr, sigma.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_NormalDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_NormalDist(int target, IntPtr res, IntPtr xqp, IntPtr mu, IntPtr sigma);

            public NormalDistClass(Quadruple _mu, Quadruple _sigma)
            {
                mu = _mu;
                sigma = _sigma;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NormalDist/*' />
        public static NormalDistClass dist_normal(Quadruple mu, Quadruple sigma)
        {
            return new NormalDistClass(mu, sigma);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NormalDist/*' />
        public static NormalDistClass dist_normal(dynamic mu, dynamic sigma)
        {
            return dist_normal(qreal.t(mu), qreal.t(sigma));
        }

        #endregion




        #region SkewNormalDist


        public class SkewNormalDistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple b;
            Quadruple c;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_SkewNormalDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr, c.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_SkewNormalDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_SkewNormalDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b, IntPtr c);

            public SkewNormalDistClass(Quadruple _a, Quadruple _b, Quadruple _c)
            {
                a = _a;
                b = _b;
                c = _c;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SkewNormalDist/*' />
        public static SkewNormalDistClass dist_skewnormal(Quadruple a, Quadruple b, Quadruple c)
        {
            return new SkewNormalDistClass(a, b, c);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SkewNormalDist/*' />
        public static SkewNormalDistClass dist_skewnormal(dynamic a, dynamic b, dynamic c)
        {
            return dist_skewnormal(qreal.t(a), qreal.t(b), qreal.t(c));
        }

        #endregion




        #region WaldDist
        // InverseGaussianDist

        public class WaldDistClass : BaseDistContClass
        {
            Quadruple mu;
            Quadruple b;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_WaldDist(target, res.mpPtr, xqp.mpPtr, mu.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_WaldDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_WaldDist(int target, IntPtr res, IntPtr xqp, IntPtr mu, IntPtr b);

            public WaldDistClass(Quadruple _mu, Quadruple _b)
            {
                mu = _mu;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WaldDist/*' />
        public static WaldDistClass dist_wald(Quadruple mu, Quadruple b)
        {
            return new WaldDistClass(mu, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/WaldDist/*' />
        public static WaldDistClass dist_wald(dynamic mu, dynamic b)
        {
            return dist_wald(qreal.t(mu), qreal.t(b));
        }

        #endregion





        #endregion



        #region Closed form distributions, based on the incomplete gamma function


        #region ChiDist


        public class ChiDistClass : BaseDistContClass
        {
            Quadruple n;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                Quadruple res = t(0);
                Quadruple pdf = t(0);
                Quadruple sf = t(0);
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

            public ChiDistClass(Quadruple _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_chi/*' />
        public static ChiDistClass dist_chi(Quadruple n)
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
            Quadruple n;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_Chi2Dist(target, res.mpPtr, xqp.mpPtr, n.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Chi2Dist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_Chi2Dist(int target, IntPtr res, IntPtr xqp, IntPtr n);

            public Chi2DistClass(Quadruple _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2Dist/*' />
        public static Chi2DistClass dist_chi2(Quadruple n)
        {
            return new Chi2DistClass(n);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2Dist/*' />
        public static Chi2DistClass dist_chi2(dynamic n)
        {
            return dist_chi2(qreal.t(n));
        }

        #endregion




        #region GammaDist


        public class GammaDistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple b;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_GammaDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GammaDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_GammaDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public GammaDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GammaDist/*' />
        public static GammaDistClass dist_gamma(Quadruple a, Quadruple b)
        {
            return new GammaDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GammaDist/*' />
        public static GammaDistClass dist_gamma(dynamic a, dynamic b)
        {
            return dist_gamma(qreal.t(a), qreal.t(b));
        }

        #endregion




        #region InverseChi2Dist
        // a = df, b = scale

        public class InverseChi2DistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_InverseChi2Dist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_InverseChi2Dist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_InverseChi2Dist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public InverseChi2DistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseChi2Dist/*' />
        public static InverseChi2DistClass dist_inverse_chi2(Quadruple a, Quadruple b)
        {
            return new InverseChi2DistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseChi2Dist/*' />
        public static InverseChi2DistClass dist_inverse_chi2(dynamic a, dynamic b)
        {
            return dist_inverse_chi2(qreal.t(a), qreal.t(b));
        }

        #endregion




        #region InverseGammaDist
        // a = df, b = scale

        public class InverseGammaDistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_InverseGammaDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_InverseGammaDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_InverseGammaDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public InverseGammaDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseGammaDist/*' />
        public static InverseGammaDistClass dist_inverse_gamma(Quadruple a, Quadruple b)
        {
            return new InverseGammaDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/InverseGammaDist/*' />
        public static InverseGammaDistClass dist_inverse_gamma(dynamic a, dynamic b)
        {
            return dist_inverse_gamma(qreal.t(a), qreal.t(b));
        }

        #endregion




        #region MaxwellDist


        public class MaxwellDistClass : BaseDistContClass
        {
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                Quadruple res = t(0);
                Quadruple pdf = t(0);
                Quadruple sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Quadruple s = sqrt(2 / pi());
                    Quadruple t = (xqp * xqp) / (b * b * b);
                    Quadruple u = exp(-(xqp * xqp) / (2 * b * b));
                    pdf = s * t * u;
                }
                if ((target == 3) || (target == 4) || (target == 5))
                {
                    Quadruple n = t(1.5);
                    Quadruple t2 = (xqp * xqp) / (2 * b * b);
                    sf = gamma_q(n, t2);
                }

                switch (target)
                {
                    case 1: { res = pdf; break; } // pdf
                    case 2:
                        {
                            Quadruple n = t(1.5);
                            Quadruple t2 = (xqp * xqp) / (2 * b * b);
                            res = gamma_p(n, t2);
                            break;
                        } // cdf_P
                    case 3: { res = sf; break; } // sf, cdf_Q
                    case 4: { res = pdf / sf; break; } // Hazard
                    case 5: { res = -log(sf); break; } // CHF
                    case 6:
                        {
                            Quadruple n = t(1.5);
                            Quadruple t2 = (xqp * xqp) / (2 * b * b);
                            res = b * sqrt(2 * gamma_p_inv(n, xqp));
                            break;
                        } // qtf, Pinv
                    case 7:
                        {
                            Quadruple n = t(1.5);
                            Quadruple t2 = (xqp * xqp) / (2 * b * b);
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

            public MaxwellDistClass(Quadruple _b)
            {
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_maxwell/*' />
        public static MaxwellDistClass dist_maxwell(Quadruple b)
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
            Quadruple m;
            Quadruple w;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                Quadruple res = t(0);
                Quadruple pdf = t(0);
                Quadruple sf = t(0);
                if ((target == 1) || (target == 4))
                {
                    Quadruple s = exp(-m * xqp * xqp / w) * 2 * pow(m / w, m) * pow(xqp, 2 * m - 1);
                    Quadruple t = gamma(m);
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

            public NakagamiDistClass(Quadruple _m, Quadruple _w)
            {
                m = _m;
                w = _w;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/dist_nakagami/*' />
        public static NakagamiDistClass dist_nakagami(Quadruple m, Quadruple w)
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
            Quadruple a;
            Quadruple b;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_BetaDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BetaDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_BetaDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public BetaDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaDist/*' />
        public static BetaDistClass dist_beta(Quadruple a, Quadruple b)
        {
            return new BetaDistClass(a, b);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaDist/*' />
        public static BetaDistClass dist_beta(dynamic a, dynamic b)
        {
            return dist_beta(qreal.t(a), qreal.t(b));
        }

        #endregion



        #region FisherFDist


        public class FisherFDistClass : BaseDistContClass
        {
            Quadruple m;
            Quadruple n;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_FisherFDist(target, res.mpPtr, xqp.mpPtr, m.mpPtr, n.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_FisherFDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_FisherFDist(int target, IntPtr res, IntPtr xqp, IntPtr m, IntPtr n);

            public FisherFDistClass(Quadruple _m, Quadruple _n)
            {
                m = _m;
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherFDist/*' />
        public static FisherFDistClass dist_fisher_f(Quadruple m, Quadruple n)
        {
            return new FisherFDistClass(m, n);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherFDist/*' />
        public static FisherFDistClass dist_fisher_f(dynamic m, dynamic n)
        {
            return dist_fisher_f(qreal.t(m), qreal.t(n));
        }

        #endregion



        #region StudentTDist


        public class StudentTDistClass : BaseDistContClass
        {
            Quadruple n;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_StudentTDist(target, res.mpPtr, xqp.mpPtr, n.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_StudentTDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_StudentTDist(int target, IntPtr res, IntPtr xqp, IntPtr n);

            public StudentTDistClass(Quadruple _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTDist/*' />
        public static StudentTDistClass dist_student_t(Quadruple n)
        {
            return new StudentTDistClass(n);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTDist/*' />
        public static StudentTDistClass dist_student_t(dynamic n)
        {
            return dist_student_t(qreal.t(n));
        }

        #endregion


        #endregion



        #region Non-central distribution functions


        #region Chi2NcDist


        public class Chi2NcDistClass : BaseDistContClass
        {
            Quadruple n;
            Quadruple lambda1;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_Chi2NcDist(target, res.mpPtr, xqp.mpPtr, n.mpPtr, lambda1.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Chi2NcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_Chi2NcDist(int target, IntPtr res, IntPtr xqp, IntPtr n, IntPtr lambda1);

            public Chi2NcDistClass(Quadruple _n, Quadruple _lambda1)
            {
                n = _n;
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2NcDist/*' />
        public static Chi2NcDistClass dist_chi2_nc(Quadruple n, Quadruple lambda1)
        {
            return new Chi2NcDistClass(n, lambda1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Chi2NcDist/*' />
        public static Chi2NcDistClass dist_chi2_nc(dynamic n, dynamic lambda1)
        {
            return dist_chi2_nc(qreal.t(n), qreal.t(lambda1));
        }

        #endregion



        #region StudentTNcDist


        public class StudentTNcDistClass : BaseDistContClass
        {
            Quadruple n;
            Quadruple delta;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_StudentTNcDist(target, res.mpPtr, xqp.mpPtr, n.mpPtr, delta.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_StudentTNcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_StudentTNcDist(int target, IntPtr res, IntPtr xqp, IntPtr n, IntPtr delta);

            public StudentTNcDistClass(Quadruple _n, Quadruple _delta)
            {
                n = _n;
                delta = _delta;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTNcDist/*' />
        public static StudentTNcDistClass dist_student_t_nc(Quadruple n, Quadruple delta)
        {
            return new StudentTNcDistClass(n, delta);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/StudentTNcDist/*' />
        public static StudentTNcDistClass dist_student_t_nc(dynamic n, dynamic delta)
        {
            return dist_student_t_nc(qreal.t(n), qreal.t(delta));
        }

        #endregion



        #region FisherFNcDist


        public class FisherFNcDistClass : BaseDistContClass
        {
            Quadruple m;
            Quadruple n;
            Quadruple lambda1;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_FisherNcDist(target, res.mpPtr, xqp.mpPtr, m.mpPtr, n.mpPtr, lambda1.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_FisherNcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_FisherNcDist(int target, IntPtr res, IntPtr xqp, IntPtr m, IntPtr n, IntPtr lambda1);

            public FisherFNcDistClass(Quadruple _m, Quadruple _n, Quadruple _lambda1)
            {
                m = _m;
                n = _n;
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherNcDist/*' />
        public static FisherFNcDistClass dist_fisher_f_nc(Quadruple m, Quadruple n, Quadruple lambda1)
        {
            return new FisherFNcDistClass(m, n, lambda1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/FisherNcDist/*' />
        public static FisherFNcDistClass dist_fisher_f_nc(dynamic m, dynamic n, dynamic lambda1)
        {
            return dist_fisher_f_nc(qreal.t(m), qreal.t(n), qreal.t(lambda1));
        }

        #endregion



        #region BetaNcDist


        public class BetaNcDistClass : BaseDistContClass
        {
            Quadruple a;
            Quadruple b;
            Quadruple lambda1;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_BetaNcDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr, lambda1.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BetaNcDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_BetaNcDist(int target, IntPtr res, IntPtr xqp, IntPtr nu, IntPtr mu, IntPtr lambda1);

            public BetaNcDistClass(Quadruple _a, Quadruple _b, Quadruple _lambda1)
            {
                a = _a;
                b = _b;
                lambda1 = _lambda1;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaNcDist/*' />
        public static BetaNcDistClass dist_beta_nc(Quadruple a, Quadruple b, Quadruple lambda1)
        {
            return new BetaNcDistClass(a, b, lambda1);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BetaNcDist/*' />
        public static BetaNcDistClass dist_beta_nc(dynamic a, dynamic b, dynamic lambda1)
        {
            return dist_beta_nc(qreal.t(a), qreal.t(b), qreal.t(lambda1));
        }

        #endregion



        #endregion



        #region Miscellaneous continuous distributions



        #region KolmogorovSmirnovDist


        public class KolmogorovSmirnovDistClass : BaseDistContClass
        {
            Quadruple n;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_KolmogorovSmirnovDist(target, res.mpPtr, xqp.mpPtr, n.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_KolmogorovSmirnovDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_KolmogorovSmirnovDist(int target, IntPtr res, IntPtr xqp, IntPtr a);

            public KolmogorovSmirnovDistClass(Quadruple _n)
            {
                n = _n;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/KolmogorovSmirnovDist/*' />
        public static KolmogorovSmirnovDistClass dist_kolmogorov_smirnov(Quadruple n)
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
            Quadruple a;
            Quadruple b;
            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_HoltsmarkDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_HoltsmarkDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_HoltsmarkDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public HoltsmarkDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/HoltsmarkDist/*' />
        public static HoltsmarkDistClass dist_holtsmark(Quadruple a, Quadruple b)
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
            Quadruple a;
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_LandauDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_LandauDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_LandauDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public LandauDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/LandauDist/*' />
        public static LandauDistClass dist_landau(Quadruple a, Quadruple b)
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
            Quadruple a;
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_MapAiryDist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_MapAiryDist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_MapAiryDist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public MapAiryDistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/MapAiryDist/*' />
        public static MapAiryDistClass dist_mapairy(Quadruple a, Quadruple b)
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
            Quadruple a;
            Quadruple b;

            internal override Quadruple BaseDist(Quadruple xqp)
            {
                var res = new Quadruple();
                Lib_QReal_Saspoint5Dist(target, res.mpPtr, xqp.mpPtr, a.mpPtr, b.mpPtr);
                return res;
            }
            [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Saspoint5Dist", CallingConvention = CallingConvention.Cdecl)]
            internal static extern void Lib_QReal_Saspoint5Dist(int target, IntPtr res, IntPtr xqp, IntPtr a, IntPtr b);

            public Saspoint5DistClass(Quadruple _a, Quadruple _b)
            {
                a = _a;
                b = _b;
            }
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Saspoint5Dist/*' />
        public static Saspoint5DistClass dist_saspoint5(Quadruple a, Quadruple b)
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



        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Set", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Set(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BracketRoot/*' />
        public static Tuple<Quadruple, Quadruple, int> BracketRoot(cb1SQuadruple1S f, dynamic guess, dynamic factor, bool is_rising, int get_digits, uint maxit)
        {
            return BracketRoot(f, qreal.t(guess), qreal.t(factor), is_rising, get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BracketRoot/*' />
        public static Tuple<Quadruple, Quadruple, int> BracketRoot(cb1SQuadruple1S f, Quadruple guess, Quadruple factor, bool is_rising, int get_digits, uint maxit)
        {
            var QBracketRoot1 = new QBracketRoot(f, guess, factor, is_rising, get_digits, maxit);
            return QBracketRoot1.Find();
        }
        internal class QBracketRoot
        {
            private cb1SQuadruple1S F1_;
            private Quadruple guess_;
            private Quadruple factor_;
            private bool is_rising_;
            private int get_digits_;
            private uint maxit_;
            private Quadruple X1 = new Quadruple();
            private Quadruple Y1 = new Quadruple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_QReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_QReal_Set(fxPtr, Y1.mpPtr);
            }
            public QBracketRoot(cb1SQuadruple1S F1, Quadruple guess, Quadruple factor, bool is_rising, int get_digits, uint maxit)
            {
                F1_ = F1;
                guess_ = guess;
                factor_ = factor;
                is_rising_ = is_rising;
                get_digits_ = get_digits;
                maxit_ = maxit;
            }
            public Tuple<Quadruple, Quadruple, int> Find()
            {
                var res1 = new Quadruple();
                var res2 = new Quadruple();
                int iter = 0;
                Lib_QReal_BracketRoot(res1.mpPtr, res2.mpPtr, ref iter, funcptr1, guess_.mpPtr, factor_.mpPtr, is_rising_, get_digits_, maxit_);
                return new Tuple<Quadruple, Quadruple, int>(res1, res2, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_BracketRoot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_BracketRoot(IntPtr res1, IntPtr res2, ref int iter, cbProc2Ptr f, IntPtr guess, IntPtr factor, bool is_rising, int get_digits, uint maxit);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NewtonRaphson/*' />
        public static Tuple<Quadruple, int> NewtonRaphson(cb1SQuadruple1S f, cb1SQuadruple1S df, dynamic guess, dynamic xmin, dynamic xmax, int get_digits, uint maxit)
        {
            return NewtonRaphson(f, df, qreal.t(guess), qreal.t(xmin), qreal.t(xmax), get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/NewtonRaphson/*' />
        public static Tuple<Quadruple, int> NewtonRaphson(cb1SQuadruple1S f, cb1SQuadruple1S df, Quadruple guess, Quadruple xmin, Quadruple xmax, int get_digits, uint maxit)
        {
            var QNewtonRaphson1 = new QNewtonRaphson(f, df, guess, xmin, xmax, get_digits, maxit);
            return QNewtonRaphson1.Find();
        }
        internal class QNewtonRaphson
        {
            private cb1SQuadruple1S F1_;
            private cb1SQuadruple1S DF1_;
            private Quadruple guess_;
            private Quadruple xmin_;
            private Quadruple xmax_;
            private int get_digits_;
            private uint maxit_;
            private Quadruple X1 = new Quadruple();
            private Quadruple Y1 = new Quadruple();
            private Quadruple DX1 = new Quadruple();
            private Quadruple DY1 = new Quadruple();
            public void funcptr0(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_QReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_QReal_Set(fxPtr, Y1.mpPtr);
            }
            public void funcptr1(IntPtr dxPtr, IntPtr dfxPtr)
            {
                Lib_QReal_Set(DX1.mpPtr, dxPtr);
                DY1 = DF1_(DX1);
                Lib_QReal_Set(dfxPtr, DY1.mpPtr);
            }
            public QNewtonRaphson(cb1SQuadruple1S F1, cb1SQuadruple1S DF1, Quadruple guess, Quadruple xmin, Quadruple xmax, int get_digits, uint maxit)
            {
                F1_ = F1;
                DF1_ = DF1;
                guess_ = guess;
                xmin_ = xmin;
                xmax_ = xmax;
                get_digits_ = get_digits;
                maxit_ = maxit;
            }
            public Tuple<Quadruple, int> Find()
            {
                var res1 = new Quadruple();
                int iter = 0;
                Lib_QReal_NewtonRaphson(res1.mpPtr, ref iter, funcptr0, funcptr1, guess_.mpPtr, xmin_.mpPtr, xmax_.mpPtr, get_digits_, maxit_);
                return new Tuple<Quadruple, int>(res1, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_NewtonRaphson", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_NewtonRaphson(IntPtr res, ref int iter, cbProc2Ptr f1, cbProc2Ptr df1, IntPtr guess, IntPtr xmin, IntPtr xmax, int get_digits, uint maxit);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Halley/*' />
        public static Tuple<Quadruple, int> Halley(cb1SQuadruple1S f, cb1SQuadruple1S df1, cb1SQuadruple1S df2, dynamic guess, dynamic xmin, dynamic xmax, int get_digits, uint maxit)
        {
            return Halley(f, df1, df2, qreal.t(guess), qreal.t(xmin), qreal.t(xmax), get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Halley/*' />
        public static Tuple<Quadruple, int> Halley(cb1SQuadruple1S f, cb1SQuadruple1S df1, cb1SQuadruple1S df2, Quadruple guess, Quadruple xmin, Quadruple xmax, int get_digits, uint maxit)
        {
            var QHalley1 = new QHalley(f, df1, df2, guess, xmin, xmax, get_digits, maxit);
            return QHalley1.Find();
        }
        internal class QHalley
        {
            private cb1SQuadruple1S F1_;
            private cb1SQuadruple1S DF1_;
            private cb1SQuadruple1S DF2_;
            private Quadruple guess_;
            private Quadruple xmin_;
            private Quadruple xmax_;
            private int get_digits_;
            private uint maxit_;
            private Quadruple X1 = new Quadruple();
            private Quadruple Y1 = new Quadruple();
            private Quadruple DX1 = new Quadruple();
            private Quadruple DY1 = new Quadruple();
            private Quadruple D2X1 = new Quadruple();
            private Quadruple D2Y1 = new Quadruple();
            public void funcptr0(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_QReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_QReal_Set(fxPtr, Y1.mpPtr);
            }
            public void funcptr1(IntPtr dxPtr, IntPtr dfxPtr)
            {
                Lib_QReal_Set(DX1.mpPtr, dxPtr);
                DY1 = DF1_(DX1);
                Lib_QReal_Set(dfxPtr, DY1.mpPtr);
            }
            public void funcptr2(IntPtr d2xPtr, IntPtr d2fxPtr)
            {
                Lib_QReal_Set(D2X1.mpPtr, d2xPtr);
                D2Y1 = DF2_(DX1);
                Lib_QReal_Set(d2fxPtr, D2Y1.mpPtr);
            }
            public QHalley(cb1SQuadruple1S F1, cb1SQuadruple1S DF1, cb1SQuadruple1S DF2, Quadruple guess, Quadruple xmin, Quadruple xmax, int get_digits, uint maxit)
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
            public Tuple<Quadruple, int> Find()
            {
                var res1 = new Quadruple();
                int iter = 0;
                Lib_QReal_Halley(res1.mpPtr, ref iter, funcptr0, funcptr1, funcptr2, guess_.mpPtr, xmin_.mpPtr, xmax_.mpPtr, get_digits_, maxit_);
                return new Tuple<Quadruple, int>(res1, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Halley", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Halley(IntPtr res, ref int iter, cbProc2Ptr f1, cbProc2Ptr df1, cbProc2Ptr df2, IntPtr guess, IntPtr xmin, IntPtr xmax, int get_digits, uint maxit);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Schroder/*' />
        public static Tuple<Quadruple, int> Schroder(cb1SQuadruple1S f, cb1SQuadruple1S df1, cb1SQuadruple1S df2, dynamic guess, dynamic xmin, dynamic xmax, int get_digits, uint maxit)
        {
            return Schroder(f, df1, df2, qreal.t(guess), qreal.t(xmin), qreal.t(xmax), get_digits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Schroder/*' />
        public static Tuple<Quadruple, int> Schroder(cb1SQuadruple1S f, cb1SQuadruple1S df1, cb1SQuadruple1S df2, Quadruple guess, Quadruple xmin, Quadruple xmax, int get_digits, uint maxit)
        {
            var QSchroder1 = new QSchroder(f, df1, df2, guess, xmin, xmax, get_digits, maxit);
            return QSchroder1.Find();
        }
        internal class QSchroder
        {
            private cb1SQuadruple1S F1_;
            private cb1SQuadruple1S DF1_;
            private cb1SQuadruple1S DF2_;
            private Quadruple guess_;
            private Quadruple xmin_;
            private Quadruple xmax_;
            private int get_digits_;
            private uint maxit_;
            private Quadruple X1 = new Quadruple();
            private Quadruple Y1 = new Quadruple();
            private Quadruple DX1 = new Quadruple();
            private Quadruple DY1 = new Quadruple();
            private Quadruple D2X1 = new Quadruple();
            private Quadruple D2Y1 = new Quadruple();
            public void funcptr0(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_QReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_QReal_Set(fxPtr, Y1.mpPtr);
            }
            public void funcptr1(IntPtr dxPtr, IntPtr dfxPtr)
            {
                Lib_QReal_Set(DX1.mpPtr, dxPtr);
                DY1 = DF1_(DX1);
                Lib_QReal_Set(dfxPtr, DY1.mpPtr);
            }
            public void funcptr2(IntPtr d2xPtr, IntPtr d2fxPtr)
            {
                Lib_QReal_Set(D2X1.mpPtr, d2xPtr);
                D2Y1 = DF2_(DX1);
                Lib_QReal_Set(d2fxPtr, D2Y1.mpPtr);
            }
            public QSchroder(cb1SQuadruple1S F1, cb1SQuadruple1S DF1, cb1SQuadruple1S DF2, Quadruple guess, Quadruple xmin, Quadruple xmax, int get_digits, uint maxit)
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
            public Tuple<Quadruple, int> Find()
            {
                var res1 = new Quadruple();
                int iter = 0;
                Lib_QReal_Schroder(res1.mpPtr, ref iter, funcptr0, funcptr1, funcptr2, guess_.mpPtr, xmin_.mpPtr, xmax_.mpPtr, get_digits_, maxit_);
                return new Tuple<Quadruple, int>(res1, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Schroder", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Schroder(IntPtr res, ref int iter, cbProc2Ptr f1, cbProc2Ptr df1, cbProc2Ptr df2, IntPtr guess, IntPtr xmin, IntPtr xmax, int get_digits, uint maxit);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BrentMinimum/*' />
        public static Tuple<Quadruple, Quadruple, int> Brent_Minimum(cb1SQuadruple1S f, dynamic bracket_min, dynamic bracket_max, int bits, uint maxit)
        {
            return Brent_Minimum(f, qreal.t(bracket_min), qreal.t(bracket_max), bits, maxit);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/BrentMinimum/*' />
        public static Tuple<Quadruple, Quadruple, int> Brent_Minimum(cb1SQuadruple1S f, Quadruple bracket_min, Quadruple bracket_max, int bits, uint maxit)
        {
            var QBrent_Minimum1 = new QBrent_Minimum(f, bracket_min, bracket_max, bits, maxit);
            return QBrent_Minimum1.Find();
        }
        internal class QBrent_Minimum
        {
            private cb1SQuadruple1S F1_;
            private Quadruple bracket_min_;
            private Quadruple bracket_max_;
            private int bits_;
            private uint maxit_;
            private Quadruple X1 = new Quadruple();
            private Quadruple Y1 = new Quadruple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_QReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_QReal_Set(fxPtr, Y1.mpPtr);
            }
            public QBrent_Minimum(cb1SQuadruple1S F1, Quadruple bracket_min, Quadruple bracket_max, int bits, uint maxit)
            {
                F1_ = F1;
                bracket_min_ = bracket_min;
                bracket_max_ = bracket_max;
                bits_ = bits;
                maxit_ = maxit;
            }
            public Tuple<Quadruple, Quadruple, int> Find()
            {
                var result = new Quadruple();
                var resultFx = new Quadruple();
                int iter = 0;
                Lib_QReal_Brent_Minimum(result.mpPtr, resultFx.mpPtr, ref iter, funcptr1, bracket_min_.mpPtr, bracket_max_.mpPtr, bits_, maxit_);
                return new Tuple<Quadruple, Quadruple, int>(result, resultFx, iter);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Brent_Minimum", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Brent_Minimum(IntPtr res, IntPtr resFx, ref int iter, cbProc2Ptr f, IntPtr bracket_min, IntPtr bracket_max, int bits, uint maxit);





        // ******************************************************************************************************************************************************************************************************************






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Trapezoidal/*' />
        public static Tuple<Quadruple, Quadruple, Quadruple> Trapezoidal(cb1SQuadruple1S f, dynamic a, dynamic b, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return Trapezoidal(f, qreal.t(a), qreal.t(b), qreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/Trapezoidal/*' />
        public static Tuple<Quadruple, Quadruple, Quadruple> Trapezoidal(cb1SQuadruple1S f, Quadruple a, Quadruple b, Quadruple tol, uint max_refinements = 12)
        {
            var QTrapezoidal1 = new QTrapezoidal(f, a, b);
            return QTrapezoidal1.Integrate();
        }
        internal class QTrapezoidal
        {
            private cb1SQuadruple1S F1_;
            private Quadruple a_;
            private Quadruple b_;
            //private Quadruple tol_;
            private Quadruple X1 = new Quadruple();
            private Quadruple Y1 = new Quadruple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_QReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_QReal_Set(fxPtr, Y1.mpPtr);
            }
            public QTrapezoidal(cb1SQuadruple1S F1, Quadruple a, Quadruple b)
            {
                F1_ = F1;
                a_ = a;
                b_ = b;
            }
            public Tuple<Quadruple, Quadruple, Quadruple> Integrate()
            {
                Quadruple res1 = new Quadruple(), res2 = new Quadruple(), res3 = new Quadruple();
                Lib_QReal_Trapezoidal(res1.mpPtr, res2.mpPtr, res3.mpPtr, funcptr1, a_.mpPtr, b_.mpPtr);
                return new Tuple<Quadruple, Quadruple, Quadruple>(res1, res2, res3);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Trapezoidal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Trapezoidal(IntPtr res1, IntPtr res2, IntPtr res3, cbProc2Ptr f, IntPtr a, IntPtr b);





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussLegendre/*' />
        public static Tuple<Quadruple, Quadruple> GaussLegendre(cb1SQuadruple1S f, dynamic a, dynamic b)
        {
            return GaussLegendre(f, qreal.t(a), qreal.t(b));
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussLegendre/*' />
        public static Tuple<Quadruple, Quadruple> GaussLegendre(cb1SQuadruple1S f, Quadruple a, Quadruple b)
        {
            var QGaussLegendre1 = new QGaussLegendre(f, a, b);
            return QGaussLegendre1.Integrate();
        }
        internal class QGaussLegendre
        {
            private cb1SQuadruple1S F1_;
            private Quadruple a_;
            private Quadruple b_;
            private Quadruple X1 = new Quadruple();
            private Quadruple Y1 = new Quadruple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_QReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_QReal_Set(fxPtr, Y1.mpPtr);
            }
            public QGaussLegendre(cb1SQuadruple1S F1, Quadruple a, Quadruple b)
            {
                F1_ = F1;
                a_ = a;
                b_ = b;
            }
            public Tuple<Quadruple, Quadruple> Integrate()
            {
                Quadruple res1 = new Quadruple(), res3 = new Quadruple();
                Lib_QReal_GaussLegendre(res1.mpPtr, res3.mpPtr, funcptr1, a_.mpPtr, b_.mpPtr);
                return new Tuple<Quadruple, Quadruple>(res1, res3);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GaussLegendre", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_GaussLegendre(IntPtr res1, IntPtr res3, cbProc2Ptr f, IntPtr a, IntPtr b);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussKronrod/*' />
        public static Tuple<Quadruple, Quadruple, Quadruple> GaussKronrod(cb1SQuadruple1S f, dynamic a, dynamic b, dynamic tol = null, uint max_depth = 12)
        {
            if (tol == null) { tol = t(0); }
            return GaussKronrod(f, qreal.t(a), qreal.t(b), qreal.t(tol), max_depth);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/GaussKronrod/*' />
        public static Tuple<Quadruple, Quadruple, Quadruple> GaussKronrod(cb1SQuadruple1S f, Quadruple a, Quadruple b, Quadruple tol, uint max_depth = 12)
        {
            var QGaussKronrod1 = new QGaussKronrod(f, a, b);
            return QGaussKronrod1.Integrate();
        }
        internal class QGaussKronrod
        {
            private cb1SQuadruple1S F1_;
            private Quadruple a_;
            private Quadruple b_;
            //private Quadruple tol_;
            private Quadruple X1 = new Quadruple();
            private Quadruple Y1 = new Quadruple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_QReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_QReal_Set(fxPtr, Y1.mpPtr);
            }
            public QGaussKronrod(cb1SQuadruple1S F1, Quadruple a, Quadruple b)
            {
                F1_ = F1;
                a_ = a;
                b_ = b;
            }
            public Tuple<Quadruple, Quadruple, Quadruple> Integrate()
            {
                Quadruple res1 = new Quadruple(), res2 = new Quadruple(), res3 = new Quadruple();
                Lib_QReal_GaussKronrod(res1.mpPtr, res2.mpPtr, res3.mpPtr, funcptr1, a_.mpPtr, b_.mpPtr);
                return new Tuple<Quadruple, Quadruple, Quadruple>(res1, res2, res3);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_GaussKronrod", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_GaussKronrod(IntPtr res1, IntPtr res2, IntPtr res3, cbProc2Ptr f, IntPtr a, IntPtr b);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TanhSinh/*' />
        public static Tuple<Quadruple, Quadruple, Quadruple, int> TanhSinh(cb1SQuadruple1S f, dynamic a, dynamic b, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return TanhSinh(f, qreal.t(a), qreal.t(b), qreal.t(tol), max_refinements);
        }

        /// <include file="docs.xml" path='docs/members[@name="Boost"]/TanhSinh/*' />
        public static Tuple<Quadruple, Quadruple, Quadruple, int> TanhSinh(cb1SQuadruple1S f, Quadruple a, Quadruple b, Quadruple tol, uint max_refinements = 12)
        {
            var QTanhSinh1 = new QTanhSinh(f, a, b);
            return QTanhSinh1.Integrate();
        }
        internal class QTanhSinh
        {
            private cb1SQuadruple1S F1_;
            private Quadruple a_;
            private Quadruple b_;
            private Quadruple X1 = new Quadruple();
            private Quadruple Y1 = new Quadruple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_QReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_QReal_Set(fxPtr, Y1.mpPtr);
            }
            public QTanhSinh(cb1SQuadruple1S F1, Quadruple a, Quadruple b)
            {
                F1_ = F1;
                a_ = a;
                b_ = b;
            }
            public Tuple<Quadruple, Quadruple, Quadruple, int> Integrate()
            {
                Quadruple res1 = new Quadruple(), res2 = new Quadruple(), res3 = new Quadruple();
                int levels = 0;
                Lib_QReal_TanhSinh(res1.mpPtr, res2.mpPtr, res3.mpPtr, ref levels, funcptr1, a_.mpPtr, b_.mpPtr);
                return new Tuple<Quadruple, Quadruple, Quadruple, int>(res1, res2, res3, levels);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_TanhSinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_TanhSinh(IntPtr res1, IntPtr res2, IntPtr res3, ref int levels, cbProc2Ptr f, IntPtr a, IntPtr b);





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SinhSinh/*' />
        public static Tuple<Quadruple, Quadruple, Quadruple, int> SinhSinh(cb1SQuadruple1S f, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return SinhSinh(f, qreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/SinhSinh/*' />
        public static Tuple<Quadruple, Quadruple, Quadruple, int> SinhSinh(cb1SQuadruple1S f, Quadruple tol, uint max_refinements = 12)
        {
            var QSinhSinh1 = new QSinhSinh(f);
            return QSinhSinh1.Integrate();
        }
        internal class QSinhSinh
        {
            private cb1SQuadruple1S F1_;
            private Quadruple X1 = new Quadruple();
            private Quadruple Y1 = new Quadruple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_QReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_QReal_Set(fxPtr, Y1.mpPtr);
            }
            public QSinhSinh(cb1SQuadruple1S F1)
            {
                F1_ = F1;
            }
            public Tuple<Quadruple, Quadruple, Quadruple, int> Integrate()
            {
                Quadruple res1 = new Quadruple(), res2 = new Quadruple(), res3 = new Quadruple();
                int levels = 0;
                Lib_QReal_SinhSinh(res1.mpPtr, res2.mpPtr, res3.mpPtr, ref levels, funcptr1);
                return new Tuple<Quadruple, Quadruple, Quadruple, int>(res1, res2, res3, levels);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_SinhSinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_SinhSinh(IntPtr res1, IntPtr res2, IntPtr res3, ref int levels, cbProc2Ptr f);






        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExpSinh/*' />
        public static Tuple<Quadruple, Quadruple, Quadruple, int> ExpSinh(cb1SQuadruple1S f, dynamic tol = null, uint max_refinements = 12)
        {
            if (tol == null) { tol = t(0); }
            return ExpSinh(f, qreal.t(tol), max_refinements);
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/ExpSinh/*' />
        public static Tuple<Quadruple, Quadruple, Quadruple, int> ExpSinh(cb1SQuadruple1S f, Quadruple tol, uint max_refinements = 12)
        {
            var QExpSinh1 = new QExpSinh(f);
            return QExpSinh1.Integrate();
        }
        internal class QExpSinh
        {
            private cb1SQuadruple1S F1_;
            private Quadruple X1 = new Quadruple();
            private Quadruple Y1 = new Quadruple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_QReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_QReal_Set(fxPtr, Y1.mpPtr);
            }
            public QExpSinh(cb1SQuadruple1S F1)
            {
                F1_ = F1;
            }
            public Tuple<Quadruple, Quadruple, Quadruple, int> Integrate()
            {
                Quadruple res1 = new Quadruple(), res2 = new Quadruple(), res3 = new Quadruple();
                int levels = 0;
                Lib_QReal_ExpSinh(res1.mpPtr, res2.mpPtr, res3.mpPtr, ref levels, funcptr1);
                return new Tuple<Quadruple, Quadruple, Quadruple, int>(res1, res2, res3, levels);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_ExpSinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_ExpSinh(IntPtr res1, IntPtr res2, IntPtr res3, ref int levels, cbProc2Ptr f);







        /// <include file="docs.xml" path='docs/members[@name="Boost"]/OouraCos/*' />
        public static Tuple<Quadruple, Quadruple> Ooura_Cos(cb1SQuadruple1S f)
        {
            var QOoura_Cos1 = new QOoura_Cos(f);
            return QOoura_Cos1.Integrate();
        }
        internal class QOoura_Cos
        {
            private cb1SQuadruple1S F1_;
            private Quadruple X1 = new Quadruple();
            private Quadruple Y1 = new Quadruple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_QReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_QReal_Set(fxPtr, Y1.mpPtr);
            }
            public QOoura_Cos(cb1SQuadruple1S F1)
            {
                F1_ = F1;
            }
            public Tuple<Quadruple, Quadruple> Integrate()
            {
                Quadruple result1 = new Quadruple(), result2 = new Quadruple();
                Lib_QReal_Ooura_Cos(result1.mpPtr, result2.mpPtr, funcptr1);
                return new Tuple<Quadruple, Quadruple>(result1, result2);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Ooura_Cos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Ooura_Cos(IntPtr res1, IntPtr res2, cbProc2Ptr f);





        /// <include file="docs.xml" path='docs/members[@name="Boost"]/OouraSin/*' />
        public static Tuple<Quadruple, Quadruple> Ooura_Sin(cb1SQuadruple1S f)
        {
            var QOoura_Sin1 = new QOoura_Sin(f);
            return QOoura_Sin1.Integrate();
        }
        internal class QOoura_Sin
        {
            private cb1SQuadruple1S F1_;
            private Quadruple X1 = new Quadruple();
            private Quadruple Y1 = new Quadruple();
            public void funcptr1(IntPtr xPtr, IntPtr fxPtr)
            {
                Lib_QReal_Set(X1.mpPtr, xPtr);
                Y1 = F1_(X1);
                Lib_QReal_Set(fxPtr, Y1.mpPtr);
            }
            public QOoura_Sin(cb1SQuadruple1S F1)
            {
                F1_ = F1;
            }
            public Tuple<Quadruple, Quadruple> Integrate()
            {
                Quadruple result1 = new Quadruple(), result2 = new Quadruple();
                Lib_QReal_Ooura_Sin(result1.mpPtr, result2.mpPtr, funcptr1);
                return new Tuple<Quadruple, Quadruple>(result1, result2);
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Ooura_Sin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Ooura_Sin(IntPtr res1, IntPtr res2, cbProc2Ptr f);





        #endregion






        #region Boost Odeint




        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RungeKutta4Const/*' />
        public static void RungeKutta4Const(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, Quadruple StartTime, Quadruple EndTime, Quadruple dt)
        {
            var QOdeint1 = new QOdeintConst(1, F1, F2, matInput, StartTime, EndTime, dt);
            QOdeint1.Integrate();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/RungeKutta4Const/*' />
        public static void RungeKutta4Const(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            RungeKutta4Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void CashKarp54Const(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, Quadruple StartTime, Quadruple EndTime, Quadruple dt)
        {
            var QOdeint1 = new QOdeintConst(2, F1, F2, matInput, StartTime, EndTime, dt);
            QOdeint1.Integrate();
        }


        public static void CashKarp54Const(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            CashKarp54Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void DormandPrince5Const(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, Quadruple StartTime, Quadruple EndTime, Quadruple dt)
        {
            var QOdeint1 = new QOdeintConst(3, F1, F2, matInput, StartTime, EndTime, dt);
            QOdeint1.Integrate();
        }


        public static void DormandPrince5Const(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            DormandPrince5Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void Fehlberg78Const(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, Quadruple StartTime, Quadruple EndTime, Quadruple dt)
        {
            var QOdeint1 = new QOdeintConst(4, F1, F2, matInput, StartTime, EndTime, dt);
            QOdeint1.Integrate();
        }


        public static void Fehlberg78Const(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            Fehlberg78Const(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        public static void AdamsBashforthMoultonConst(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, Quadruple StartTime, Quadruple EndTime, Quadruple dt)
        {
            var QOdeint1 = new QOdeintConst(5, F1, F2, matInput, StartTime, EndTime, dt);
            QOdeint1.Integrate();
        }


        public static void AdamsBashforthMoultonConst(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt)
        {
            AdamsBashforthMoultonConst(F1, F2, matInput, t(StartTime), t(EndTime), t(dt));
        }


        internal class QOdeintConst
        {
            private int what_;
            private cbQuadruple1S2V F1_;
            private cbQuadruple1S1V F2_;
            private QuadrupleVec matInit_ = new QuadrupleVec();
            private QuadrupleVec matX = new QuadrupleVec();
            private QuadrupleVec matY = new QuadrupleVec();
            private Quadruple t = new Quadruple();
            private Quadruple StartTime_ = new Quadruple();
            private Quadruple EndTime_ = new Quadruple();
            private Quadruple dt_ = new Quadruple();
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
            internal QOdeintConst(int what, cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInit, Quadruple StartTime, Quadruple EndTime, Quadruple dt)
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
                        QReal_Const_RungeKutta4(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 2:
                        QReal_Const_CashKarp54(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 3:
                        QReal_Const_Dopri5(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 4:
                        QReal_Const_Fehlberg78(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    case 5:
                        QReal_Const_AdamsBashforthMoulton(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_);
                        break;
                    default:
                        Console.WriteLine("Not found");
                        break;
                }
            }
        }

        public static void QReal_Const_RungeKutta4(cbProc3Ptr F1, cbProc2Ptr F2, QuadrupleVec matX, Quadruple StartTime, Quadruple EndTime, Quadruple dt)
        {
            Lib_QReal_Const_RungeKutta4(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Const_RungeKutta4", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Const_RungeKutta4(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt);


        public static void QReal_Const_CashKarp54(cbProc3Ptr F1, cbProc2Ptr F2, QuadrupleVec matX, Quadruple StartTime, Quadruple EndTime, Quadruple dt)
        {
            Lib_QReal_Const_CashKarp54(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Const_CashKarp54", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Const_CashKarp54(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt);


        public static void QReal_Const_Dopri5(cbProc3Ptr F1, cbProc2Ptr F2, QuadrupleVec matX, Quadruple StartTime, Quadruple EndTime, Quadruple dt)
        {
            Lib_QReal_Const_Dopri5(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Const_Dopri5", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Const_Dopri5(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt);


        public static void QReal_Const_Fehlberg78(cbProc3Ptr F1, cbProc2Ptr F2, QuadrupleVec matX, Quadruple StartTime, Quadruple EndTime, Quadruple dt)
        {
            Lib_QReal_Const_Fehlberg78(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Const_Fehlberg78", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Const_Fehlberg78(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt);


        public static void QReal_Const_AdamsBashforthMoulton(cbProc3Ptr F1, cbProc2Ptr F2, QuadrupleVec matX, Quadruple StartTime, Quadruple EndTime, Quadruple dt)
        {
            Lib_QReal_Const_AdamsBashforthMoulton(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Const_AdamsBashforthMoulton", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Const_AdamsBashforthMoulton(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt);









        // ***********************************************************************************************************









        /// <include file="docs.xml" path='docs/members[@name="Boost"]/DormandPrince5Adaptive/*' />
        public static void DormandPrince5Adaptive(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, Quadruple StartTime, Quadruple EndTime, Quadruple dt, Quadruple epsabs, Quadruple epsrel)
        {
            var QOdeint1 = new QOdeintAdaptiveDenseOutput(1, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            QOdeint1.Integrate();
        }


        /// <include file="docs.xml" path='docs/members[@name="Boost"]/DormandPrince5Adaptive/*' />
        public static void DormandPrince5Adaptive(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            DormandPrince5Adaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void CashKarp54Adaptive(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, Quadruple StartTime, Quadruple EndTime, Quadruple dt, Quadruple epsabs, Quadruple epsrel)
        {
            var QOdeint1 = new QOdeintAdaptiveDenseOutput(2, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            QOdeint1.Integrate();
        }


        public static void CashKarp54Adaptive(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            CashKarp54Adaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void Fehlberg78Adaptive(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, Quadruple StartTime, Quadruple EndTime, Quadruple dt, Quadruple epsabs, Quadruple epsrel)
        {
            var QOdeint1 = new QOdeintAdaptiveDenseOutput(3, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            QOdeint1.Integrate();
        }


        public static void Fehlberg78Adaptive(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            Fehlberg78Adaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void BulirschStoerAdaptive(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, Quadruple StartTime, Quadruple EndTime, Quadruple dt, Quadruple epsabs, Quadruple epsrel)
        {
            var QOdeint1 = new QOdeintAdaptiveDenseOutput(4, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            QOdeint1.Integrate();
        }


        public static void BulirschStoerAdaptive(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            BulirschStoerAdaptive(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void DormandPrince5DenseOutput(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, Quadruple StartTime, Quadruple EndTime, Quadruple dt, Quadruple epsabs, Quadruple epsrel)
        {
            var QOdeint1 = new QOdeintAdaptiveDenseOutput(5, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            QOdeint1.Integrate();
        }


        public static void DormandPrince5DenseOutput(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            DormandPrince5DenseOutput(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        public static void BulirschStoerDenseOutput(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, Quadruple StartTime, Quadruple EndTime, Quadruple dt, Quadruple epsabs, Quadruple epsrel)
        {
            var QOdeint1 = new QOdeintAdaptiveDenseOutput(6, F1, F2, matInput, StartTime, EndTime, dt, epsabs, epsrel);
            QOdeint1.Integrate();
        }


        public static void BulirschStoerDenseOutput(cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInput, dynamic StartTime, dynamic EndTime, dynamic dt, dynamic epsabs, dynamic epsrel)
        {
            BulirschStoerDenseOutput(F1, F2, matInput, t(StartTime), t(EndTime), t(dt), t(epsabs), t(epsrel));
        }


        internal class QOdeintAdaptiveDenseOutput
        {
            int what_;
            private cbQuadruple1S2V F1_;
            private cbQuadruple1S1V F2_;
            private QuadrupleVec matInit_ = new QuadrupleVec();
            private QuadrupleVec matX = new QuadrupleVec();
            private QuadrupleVec matY = new QuadrupleVec();
            private Quadruple t = new Quadruple();
            private Quadruple StartTime_ = new Quadruple();
            private Quadruple EndTime_ = new Quadruple();
            private Quadruple dt_ = new Quadruple();
            private Quadruple epsabs_ = new Quadruple();
            private Quadruple epsrel_ = new Quadruple();
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
            internal QOdeintAdaptiveDenseOutput(int what, cbQuadruple1S2V F1, cbQuadruple1S1V F2, QuadrupleVec matInit, Quadruple StartTime, Quadruple EndTime, Quadruple dt, Quadruple epsabs, Quadruple epsrel)
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
                        QReal_Adaptive_RungeKuttaDopri5(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 2:
                        QReal_Adaptive_CashKarp54(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 3:
                        QReal_Adaptive_Fehlberg78(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 4:
                        QReal_Adaptive_BulirschStoer(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 5:
                        QReal_DenseOutput_Dopri5(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    case 6:
                        QReal_DenseOutput_BulirschStoer(funcptr1, funcptr2, matInit_, StartTime_, EndTime_, dt_, epsabs_, epsrel_);
                        break;
                    default:
                        Console.WriteLine("Not found");
                        break;
                }
            }
        }
        public static void QReal_Adaptive_RungeKuttaDopri5(cbProc3Ptr F1, cbProc2Ptr F2, QuadrupleVec matX, Quadruple StartTime, Quadruple EndTime, Quadruple dt, Quadruple epsabs, Quadruple epsrel)
        {
            Lib_QReal_Adaptive_Dopri5(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr, epsabs.mpPtr, epsrel.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Adaptive_Dopri5", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Adaptive_Dopri5(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt, IntPtr epsabs, IntPtr epsrel);


        public static void QReal_Adaptive_CashKarp54(cbProc3Ptr F1, cbProc2Ptr F2, QuadrupleVec matX, Quadruple StartTime, Quadruple EndTime, Quadruple dt, Quadruple epsabs, Quadruple epsrel)
        {
            Lib_QReal_Adaptive_CashKarp54(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr, epsabs.mpPtr, epsrel.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Adaptive_CashKarp54", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Adaptive_CashKarp54(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt, IntPtr epsabs, IntPtr epsrel);


        public static void QReal_Adaptive_Fehlberg78(cbProc3Ptr F1, cbProc2Ptr F2, QuadrupleVec matX, Quadruple StartTime, Quadruple EndTime, Quadruple dt, Quadruple epsabs, Quadruple epsrel)
        {
            Lib_QReal_Adaptive_Fehlberg78(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr, epsabs.mpPtr, epsrel.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Adaptive_Fehlberg78", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Adaptive_Fehlberg78(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt, IntPtr epsabs, IntPtr epsrel);


        public static void QReal_Adaptive_BulirschStoer(cbProc3Ptr F1, cbProc2Ptr F2, QuadrupleVec matX, Quadruple StartTime, Quadruple EndTime, Quadruple dt, Quadruple epsabs, Quadruple epsrel)
        {
            Lib_QReal_Adaptive_BulirschStoer(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr, epsabs.mpPtr, epsrel.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_Adaptive_BulirschStoer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_Adaptive_BulirschStoer(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt, IntPtr epsabs, IntPtr epsrel);


        public static void QReal_DenseOutput_Dopri5(cbProc3Ptr F1, cbProc2Ptr F2, QuadrupleVec matX, Quadruple StartTime, Quadruple EndTime, Quadruple dt, Quadruple epsabs, Quadruple epsrel)
        {
            Lib_QReal_DenseOutput_Dopri5(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr, epsabs.mpPtr, epsrel.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_DenseOutput_Dopri5", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_DenseOutput_Dopri5(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt, IntPtr epsabs, IntPtr epsrel);


        public static void QReal_DenseOutput_BulirschStoer(cbProc3Ptr F1, cbProc2Ptr F2, QuadrupleVec matX, Quadruple StartTime, Quadruple EndTime, Quadruple dt, Quadruple epsabs, Quadruple epsrel)
        {
            Lib_QReal_DenseOutput_BulirschStoer(F1, F2, matX.mpPtr, StartTime.mpPtr, EndTime.mpPtr, dt.mpPtr, epsabs.mpPtr, epsrel.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QReal_DenseOutput_BulirschStoer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QReal_DenseOutput_BulirschStoer(cbProc3Ptr F1, cbProc2Ptr F2, IntPtr MatrixPtr_source, IntPtr StartTime, IntPtr EndTime, IntPtr dt, IntPtr epsabs, IntPtr epsrel);











        #endregion




        #region Eigen calculus


        public static QuadrupleMat PowellHybrd(cbQuadruple2M F1, cbQuadruple2M F2, QuadrupleMat matInput)
        {
            var QPowellHybrd1 = new QPowellHybrd(F1, F2, matInput);
            var matX = QPowellHybrd1.Solve();
            return matX;
        }
        internal class QPowellHybrd
        {
            private cbQuadruple2M F1_;
            private cbQuadruple2M F2_;
            private QuadrupleMat matX1 = new QuadrupleMat();
            private QuadrupleMat matY1 = new QuadrupleMat();
            private QuadrupleMat matX2 = new QuadrupleMat();
            private QuadrupleMat matY2 = new QuadrupleMat();
            private QuadrupleMat matInput_ = new QuadrupleMat();
            private QuadrupleMat matX = new QuadrupleMat();
            private QuadrupleMat matFvec = new QuadrupleMat();
            private QuadrupleMat matFjac = new QuadrupleMat();
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
            internal QPowellHybrd(cbQuadruple2M F1, cbQuadruple2M F2, QuadrupleMat matInput)
            {
                int n = matInput.rows;
                matX.Resize(n, 1);
                matFvec.Resize(n, 1);
                matFjac.Resize(n, n);
                matInput_ = matInput; // Shallow copy
                F1_ = F1;
                F2_ = F2;
            }
            internal QuadrupleMat Solve()
            {
                qlib.testHybrj_ext(funcptr1, funcptr2, matX, matFvec, matFjac, matInput_);
                return matX;
            }
        }




        public static QuadrupleMat Levenberg(cbQuadruple2M F1, cbQuadruple2M F2, QuadrupleMat matInput, int n, int m)
        {
            var QLevenberg1 = new QLevenberg(F1, F2, matInput, n, m);
            var matX = QLevenberg1.Solve();
            return matX;
        }
        internal class QLevenberg
        {
            private cbQuadruple2M F1_;
            private cbQuadruple2M F2_;
            private QuadrupleMat matX1 = new QuadrupleMat();
            private QuadrupleMat matY1 = new QuadrupleMat();
            private QuadrupleMat matX2 = new QuadrupleMat();
            private QuadrupleMat matY2 = new QuadrupleMat();
            private QuadrupleMat matInput_ = new QuadrupleMat();
            private QuadrupleMat matX = new QuadrupleMat();
            private QuadrupleMat matFvec = new QuadrupleMat();
            private QuadrupleMat matFjac = new QuadrupleMat();
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
            internal QLevenberg(cbQuadruple2M F1, cbQuadruple2M F2, QuadrupleMat matInput, int n, int m)
            {
                matX.Resize(n, 1);
                matFvec.Resize(m, 1);
                matFjac.Resize(n, n);
                matInput_ = matInput; // Shallow copy
                F1_ = F1;
                F2_ = F2;
            }
            internal QuadrupleMat Solve()
            {
                qlib.testLmder_ext(funcptr1, funcptr2, matX, matFvec, matFjac, matInput_);
                return matX;
            }
        }










        #endregion







        #region Boost/CppOptLib


        public static QuadrupleVec NelderMeadSolver(cb1SQuadruple1V F1, QuadrupleVec matInput)
        {
            var QSolver11 = new QOptSolver1(constants.mp_nelder_mead_solver, F1, matInput);
            return QSolver11.Solve();
        }

        public static QuadrupleVec CMAesSolver(cb1SQuadruple1V F1, QuadrupleVec matInput)
        {
            var QSolver11 = new QOptSolver1(constants.mp_cma_es_solver, F1, matInput);
            return QSolver11.Solve();
        }

        internal class QOptSolver1
        {
            private int what_;
            private cb1SQuadruple1V F1_;
            private QuadrupleVec matX1 = new QuadrupleVec();
            private QuadrupleVec matY1 = new QuadrupleVec();
            private QuadrupleVec matX_ = new QuadrupleVec();
            private QuadrupleVec matNorm_ = new QuadrupleVec();
            private QuadrupleVec X_ = new QuadrupleVec();
            private QuadrupleVec FX_ = new QuadrupleVec();
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
            internal QOptSolver1(int what, cb1SQuadruple1V F1, QuadrupleVec X)
            {
                what_ = what;
                matX_ = new QuadrupleVec(X.Size);
                X_ = X; // Shallow copy
                F1_ = F1;
            }
            internal QuadrupleVec Solve()
            {
                Lib_Eigen_QReal_Real_CppOptLib1(what_, funcptr1, matX_.mpPtr, matNorm_.mpPtr, X_.mpPtr, FX_.mpPtr);
                return matX_;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Real_CppOptLib1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Real_CppOptLib1(int what, cbProc2Ptr F1, IntPtr matXPtr, IntPtr matNormPtr, IntPtr xPtr, IntPtr fxPtr);


        public static QuadrupleVec LbfgsSolver(cb1SQuadruple1V F1, cbQuadruple2V F2, QuadrupleVec matInput)
        {
            var QSolver21 = new QOptSolver2(constants.mp_lbfgs_solver, F1, F2, matInput);
            return QSolver21.Solve();
        }

        public static QuadrupleVec BfgsSolver(cb1SQuadruple1V F1, cbQuadruple2V F2, QuadrupleVec matInput)
        {
            var QSolver21 = new QOptSolver2(constants.mp_bfgs_solver, F1, F2, matInput);
            return QSolver21.Solve();
        }

        public static QuadrupleVec GradientDescentSolver(cb1SQuadruple1V F1, cbQuadruple2V F2, QuadrupleVec matInput)
        {
            var QSolver21 = new QOptSolver2(constants.mp_gradient_descent_solver, F1, F2, matInput);
            return QSolver21.Solve();
        }

        public static QuadrupleVec ConjugatedGradientDescentSolver(cb1SQuadruple1V F1, cbQuadruple2V F2, QuadrupleVec matInput)
        {
            var QSolver21 = new QOptSolver2(constants.mp_conjugated_gradient_descent_solver, F1, F2, matInput);
            return QSolver21.Solve();
        }

        internal class QOptSolver2
        {
            private int what_;
            private cb1SQuadruple1V F1_;
            private cbQuadruple2V F2_;
            private QuadrupleVec matX1 = new QuadrupleVec();
            private QuadrupleVec matY1 = new QuadrupleVec();
            private QuadrupleVec matX2 = new QuadrupleVec();
            private QuadrupleVec matY2 = new QuadrupleVec();
            private QuadrupleVec matX_ = new QuadrupleVec();
            private QuadrupleVec matGrad_ = new QuadrupleVec();
            private QuadrupleVec matNorm_ = new QuadrupleVec();
            private QuadrupleVec X_ = new QuadrupleVec();
            private QuadrupleVec FX_ = new QuadrupleVec();
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
            internal QOptSolver2(int what, cb1SQuadruple1V F1, cbQuadruple2V F2, QuadrupleVec X)
            {
                what_ = what;
                matX_ = new QuadrupleVec(X.Size);
                matGrad_ = new QuadrupleVec(X.Size);
                X_ = X; // Shallow copy
                F1_ = F1;
                F2_ = F2;
            }
            internal QuadrupleVec Solve()
            {
                Lib_Eigen_QReal_Real_CppOptLib2(what_, funcptr1, funcptr2, matX_.mpPtr, matGrad_.mpPtr, matNorm_.mpPtr, X_.mpPtr, FX_.mpPtr);
                return matX_;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Real_CppOptLib2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Real_CppOptLib2(int what, cbProc2Ptr F1, cbProc2Ptr F2, IntPtr matXPtr, IntPtr matGradPtr, IntPtr matNormPtr, IntPtr xPtr, IntPtr fxPtr);



        public static QuadrupleVec NewtonDescentSolver(cb1SQuadruple1V F1, cbQuadruple2V F2, cbQuadruple1V1M F3, QuadrupleVec matInput)
        {
            var QSolver31 = new QOptSolver3(constants.mp_newton_descent_solver, F1, F2, F3, matInput);
            return QSolver31.Solve();
        }

        internal class QOptSolver3
        {
            private int what_;
            private cb1SQuadruple1V F1_;
            private cbQuadruple2V F2_;
            private cbQuadruple1V1M F3_;
            private QuadrupleVec matX1 = new QuadrupleVec();
            private QuadrupleVec matY1 = new QuadrupleVec();
            private QuadrupleVec matX2 = new QuadrupleVec();
            private QuadrupleVec matY2 = new QuadrupleVec();
            private QuadrupleVec matX3 = new QuadrupleVec();
            private QuadrupleMat matY3 = new QuadrupleMat();
            private QuadrupleVec matX_ = new QuadrupleVec();
            private QuadrupleVec matGrad_ = new QuadrupleVec();
            private QuadrupleVec matNorm_ = new QuadrupleVec();
            private QuadrupleMat matHessian_ = new QuadrupleMat();
            private QuadrupleVec X_ = new QuadrupleVec();
            private QuadrupleVec FX_ = new QuadrupleVec();
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
            internal QOptSolver3(int what, cb1SQuadruple1V F1, cbQuadruple2V F2, cbQuadruple1V1M F3, QuadrupleVec X)
            {
                what_ = what;
                matX_ = new QuadrupleVec(X.Size);
                matGrad_ = new QuadrupleVec(X.Size);
                matHessian_.Resize(X.Size, X.Size);
                X_ = X; // Shallow copy
                F1_ = F1;
                F2_ = F2;
                F3_ = F3;
            }
            internal QuadrupleVec Solve()
            {
                Lib_Eigen_QReal_Real_CppOptLib3(what_, funcptr1, funcptr2, funcptr3, matX_.mpPtr, matHessian_.mpPtr, matGrad_.mpPtr, matNorm_.mpPtr, X_.mpPtr, FX_.mpPtr);
                return matX_;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_Real_CppOptLib3", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_Real_CppOptLib3(int what, cbProc2Ptr F1, cbProc2Ptr F2, cbProc2Ptr F3, IntPtr matXPtr, IntPtr matHessianPtr, IntPtr matGradPtr, IntPtr matNormPtr, IntPtr xPtr, IntPtr fxPtr);



        #endregion










        #region Matrix Creation




        /// <summary>
        /// Converts from a real scalar of type qreal
        /// </summary>
        public static QuadrupleMat mat_t(Quadruple x)
        {
            var matA = new QuadrupleMat();
            matA[0, 0] = x;
            return matA;
        }


        /* *********************** 

        public static QuadrupleMatC mat_cplx_t(QuadrupleMat matA)
        {
            return qcplx.mat_t(matA);
        }


        public static QuadrupleMatC mat_cplx_zeros(int n, int m)
        {
            return qcplx.mat_zeros(n, m);
        }

        /* *********************** */




        public static QuadrupleMat mat_zeros(int n, int m)
        {
            var resout = new QuadrupleMat();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setZero, n, m);
            return resout;
        }



        public static QuadrupleMat mat_ones(int n, int m)
        {
            var resout = new QuadrupleMat();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setOnes, n, m);
            return resout;
        }



        public static QuadrupleMat mat_identity(int n, int m)
        {
            var resout = new QuadrupleMat();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setIdentity, n, m);
            return resout;
        }



        public static QuadrupleMat mat_random(int n, int m)
        {
            var resout = new QuadrupleMat();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandom_nm, n, m);
            return resout;
        }



        public static QuadrupleMat mat_random_symmetric(int n)
        {
            var resout = new QuadrupleMat();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandomSymmetric, n, n);
            return resout;
        }



        public static QuadrupleMat mat_random_selfadjoint(int n)
        {
            var resout = new QuadrupleMat();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandomSA, n, n);
            return resout;
        }



        public static QuadrupleMat mat_random_selfadjoint_posdef(int n)
        {
            var resout = new QuadrupleMat();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_setRandomSAPosDef, n, n);
            return resout;
        }



        public static QuadrupleMat mat_fill_linear(int n, int m)
        {
            var resout = new QuadrupleMat();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_real, resout, constants.mp_FillLinear, n, m);
            return resout;
        }



        #endregion






    }







}