using System;
using System.Runtime.InteropServices;
using System.Numerics;


namespace FixedPrecNet
{


    public partial class QuadrupleC
    {


        #region Init

        public IntPtr mpPtr = IntPtr.Zero;


        private void Init()
        {
            xcn.Init();
            mpPtr = Lib_QCplx_Init_Func();
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_QCplx_Init_Func();


        ~QuadrupleC()
        {
            Lib_QCplx_Clear(mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Clear(IntPtr x);


        #endregion


        #region Conversions

        public QuadrupleC()
        {
            Init();
        }


        public Quadruple real
        {
            get
            {
                var res = new Quadruple();
                Lib_QCplx_Real(res.mpPtr, mpPtr);
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Real", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Real(IntPtr res, IntPtr z);


        public Quadruple imag
        {
            get
            {
                var res = new Quadruple();
                Lib_QCplx_Imag(res.mpPtr, mpPtr);
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Imag", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Imag(IntPtr res, IntPtr z);



        public override string ToString()
        {
            return "(" + real.ToString() + ", " + imag.ToString() + ")";
        }


        public string __str__()
        {
            return ToString();
        }


        public string __repr__()
        {
            return "qcplx('" + ToString() + "')";
        }

        #endregion




        #region Arithmetic operators


        public static bool operator ==(dynamic x, QuadrupleC y)
        {
            return qcplx.t(x) == y;
        }

        public static bool operator ==(QuadrupleC x, dynamic y)
        {
            return x == qcplx.t(y);
        }


        public static bool operator !=(dynamic x, QuadrupleC y)
        {
            return qcplx.t(x) != y;
        }

        public static bool operator !=(QuadrupleC x, dynamic y)
        {
            return x != qcplx.t(y);
        }


        public static bool operator ==(QuadrupleC x, QuadrupleC y)
        {
            return x.real == y.real & x.imag == y.imag;
        }


        public static bool operator !=(QuadrupleC x, QuadrupleC y)
        {
            return x.real != y.real | x.imag != y.imag;
        }






        public static QuadrupleC operator +(QuadrupleC x)
        {
            //return qcplx.t(x);
            return x + qcplx.zero();
        }


        public static QuadrupleC operator -(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Neg(res.mpPtr, x.mpPtr);
            return res;
        }
        public static QuadrupleC Negate(QuadrupleC x)
        {
            return -x;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Neg", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Neg(IntPtr res, IntPtr x);






        public static QuadrupleC operator +(QuadrupleC x, dynamic y)
        {
            return x + qcplx.t(y);
        }

        public static QuadrupleC operator +(dynamic x, QuadrupleC y)
        {
            return qcplx.t(x) + y;
        }



        public static QuadrupleC operator +(QuadrupleC x, Quadruple y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Add_QReal(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Add_QReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Add_QReal(IntPtr res, IntPtr x, IntPtr y);


        public static QuadrupleC operator +(QuadrupleC x, QuadrupleC y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Add(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Add(IntPtr res, IntPtr x, IntPtr y);


        public static QuadrupleMatC operator +(QuadrupleC m2, QuadrupleMat M1)
        {
            var Res = new QuadrupleMatC();
            qlib.Lib_Eigen_QReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, m2.real.mpPtr, m2.imag.mpPtr);
            return Res;
        }


        public static QuadrupleMatC operator +(QuadrupleC m2, QuadrupleMatC M1)
        {
            var Res = new QuadrupleMatC();
            var t = qcplx.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }










        public static QuadrupleC operator -(QuadrupleC x, dynamic y)
        {
            return x - qcplx.t(y);
        }

        public static QuadrupleC operator -(dynamic x, QuadrupleC y)
        {
            return qcplx.t(x) - y;
        }


        public static QuadrupleC operator -(QuadrupleC x, Quadruple y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Sub_QReal(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Sub_QReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Sub_QReal(IntPtr res, IntPtr x, IntPtr y);


        public static QuadrupleC operator -(QuadrupleC x, QuadrupleC y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Sub(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Sub(IntPtr res, IntPtr x, IntPtr y);


        public static QuadrupleMatC operator -(QuadrupleC m2, QuadrupleMat M1)
        {
            var Res = new QuadrupleMatC();
            qlib.Lib_Eigen_QReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, m2.real.mpPtr, m2.imag.mpPtr);
            return -Res;
        }


        public static QuadrupleMatC operator -(QuadrupleC m2, QuadrupleMatC M1)
        {
            var Res = new QuadrupleMatC();
            var t = qcplx.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_minus, M1.mpPtr, t.mpPtr);
            return -Res;
        }







        public static QuadrupleC operator *(QuadrupleC x, dynamic y)
        {
            return x * qcplx.t(y);
        }

        public static QuadrupleC operator *(dynamic x, QuadrupleC y)
        {
            return qcplx.t(x) * y;
        }


        public static QuadrupleC operator *(QuadrupleC x, Quadruple y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Mul_QReal(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Mul_QReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Mul_QReal(IntPtr res, IntPtr x, IntPtr y);

        public static QuadrupleC operator *(QuadrupleC x, QuadrupleC y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Mul(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Mul", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Mul(IntPtr res, IntPtr x, IntPtr y);


        public static QuadrupleMatC operator *(QuadrupleC m2, QuadrupleMat M1)
        {
            var Res = new QuadrupleMatC();
            qlib.Lib_Eigen_QReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, m2.real.mpPtr, m2.imag.mpPtr);
            return Res;
        }


        public static QuadrupleMatC operator *(QuadrupleC m2, QuadrupleMatC M1)
        {
            var Res = new QuadrupleMatC();
            var t = qcplx.mat_t(m2);
            qlib.Lib_Eigen_QReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }








        public static QuadrupleC operator /(QuadrupleC x, dynamic y)
        {
            return x / qcplx.t(y);
        }

        public static QuadrupleC operator /(dynamic x, QuadrupleC y)
        {
            return qcplx.t(x) / y;
        }



        public static QuadrupleC operator /(QuadrupleC x, Quadruple y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Div_QReal(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Div_QReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Div_QReal(IntPtr res, IntPtr x, IntPtr y);


        public static QuadrupleC operator /(QuadrupleC x, QuadrupleC y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Div(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Div(IntPtr res, IntPtr x, IntPtr y);








        #endregion


    }




    public partial class qcplx
    {

        public static String fmt(QuadrupleC z)
        {
            string s1 = z.real.ToString();
            string s2 = z.imag.ToString();
            string s = " " + "(" + s1 + ", " + s2 + ")";
            return s;
        }

        public static String fmt(Quadruple x)
        {
            return qreal.fmt(x);
        }


        public static String fmt(dynamic z)
        {
            return fmt(t(z));
        }


        #region General

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/name/*' />
        public static String name
        {
            get { return "qcplx"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  qcplx"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/prec/*' />
        public static Int32 prec
        {
            get { return 113; }
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



        /// <summary>
        /// Returns a new QuadrupleC using a general object as input
        /// </summary>
        public static QuadrupleC t(dynamic z)
        {
            // MsgBox(y_.GetType().ToString())
            // MsgBox(y_.ToString())
            // MsgBox(y_.real.ToString())
            string s_re = z.real.ToString();
            string s_im = z.imag.ToString();
            return qcplx.t(qreal.t(s_re), qreal.t(s_im));
        }


        /// <summary>
        /// Returns a new QuadrupleC using an Octuple as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static QuadrupleC t(Octuple x)
        {
            return qcplx.t(qreal.t(x));
        }


        /// <summary>
        /// Returns a new QuadrupleC using a Quadruple as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static QuadrupleC t(Quadruple x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Set_Real(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Set_Real", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Set_Real(IntPtr res, IntPtr x);




        /// <summary>
        /// Returns a new QuadrupleC using an Extended as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static QuadrupleC t(Extended x)
        {
            return qcplx.t(qreal.t(x));
        }



        /// <summary>
        /// Returns a new QuadrupleC using a Double (System.Double) for the real part; the imaginary part is set to zero.
        /// </summary>
        public static QuadrupleC t(Double x)
        {
            return qcplx.t(qreal.t(x));
        }





        /// <summary>
        /// Returns a new QuadrupleC using a Single (System.Single)  as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static QuadrupleC t(Single x)
        {
            return qcplx.t(qreal.t(x));
        }



        /// <summary>
        /// Returns a new QuadrupleC using a signed 32 bit integer (System.Int32) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static QuadrupleC t(Int32 x)
        {
            return qcplx.t(qreal.t(x));
        }


        /// <summary>
        /// Returns a new QuadrupleC using an unsigned 32 bit integer (System.UInt32) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static QuadrupleC t(UInt32 x)
        {
            return qcplx.t(qreal.t(x));
        }


        /// <summary>
        /// Returns a new QuadrupleC using using a signed 64 bit integer (System.Int64) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static QuadrupleC t(Int64 x)
        {
            return qcplx.t(qreal.t(x));
        }


        /// <summary>
        /// Returns a new QuadrupleC using an unsigned 64 bit integer (System.UInt64) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static QuadrupleC t(UInt64 x)
        {
            return qcplx.t(qreal.t(x));
        }


        /// <summary>
        /// Returns a new Extended using a decimal number (System.Decimal) as input
        /// </summary>
        public static QuadrupleC t(decimal x)
        {
            return qcplx.t(qreal.t(x));
        }




        /// <summary>
        /// Returns a new QuadrupleC using a BigInteger (System.Numerics.BigInteger) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static QuadrupleC t(BigInteger x)
        {
            return qcplx.t(qreal.t(x));
        }


        /// <summary>
        /// Returns a new QuadrupleC using a string (System.String) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static QuadrupleC t(string s)
        {
            return qcplx.t(qreal.t(s));
        }



        /// <summary>
        /// Returns a new QuadrupleC using 2 Quadruples as input for the real and imaginary part
        /// </summary>
        public static QuadrupleC t(Quadruple re, Quadruple im)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Set2(res.mpPtr, re.mpPtr, im.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Set2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Set2(IntPtr res, IntPtr re, IntPtr im);



        /// <summary>
        /// Returns a new QuadrupleC using a OctupleC as input
        /// </summary>
        public static QuadrupleC t(OctupleC z)
        {
            return qcplx.t(qreal.t(z.real), qreal.t(z.imag));
        }




        /// <summary>
        /// Returns a new QuadrupleC using using a QuadrupleC as input
        /// </summary>
        public static QuadrupleC t(QuadrupleC z)
        {
            return +z;
        }



        /// <summary>
        /// Returns a new QuadrupleC using using an ExtendedC as input
        /// </summary>
        public static QuadrupleC t(ExtendedC z)
        {
            return qcplx.t(qreal.t(z.real), qreal.t(z.imag));
        }



        /// <summary>
        /// Returns a new QuadrupleC using a Complex (System.Numerics.Complex) as input
        /// </summary>
        public static QuadrupleC t(Complex z)
        {
            return qcplx.t(qreal.t(z.Real), qreal.t(z.Imaginary));
        }





        /// <summary>
        /// Returns a new QuadrupleC using a SingleC as input
        /// </summary>
        public static QuadrupleC t(SingleC z)
        {
            return qcplx.t(qreal.t(z.real), qreal.t(z.imag));
        }



        /// <summary>
        /// Returns a new QuadrupleC using 2 Doubles (System.Double) as input for the real and imaginary part
        /// </summary>
        public static QuadrupleC t(Double d_re, Double d_im)
        {
            return qcplx.t(qreal.t(d_re), qreal.t(d_im));
        }


        /// <summary>
        /// Returns a new QuadrupleC using 2 strings (System.String) as input for the real and imaginary part
        /// </summary>
        public static QuadrupleC t(string s_re, string s_im)
        {
            return qcplx.t(qreal.t(s_re), qreal.t(s_im));
        }


        #endregion





        #region Basic Arithmetic and Comparisons



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/add/*' />
        public static QuadrupleC add(QuadrupleC x, QuadrupleC y)
        {
            return x + y;
        }
        public static QuadrupleC add(dynamic x, dynamic y)
        {
            return t(x) + t(y);
        }

        public static void rawadd(QuadrupleC res, QuadrupleC x, QuadrupleC y)
        {
            Lib_QCplx_Add(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Add(IntPtr res, IntPtr x, IntPtr y);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/subtract/*' />
        public static QuadrupleC subtract(QuadrupleC x, QuadrupleC y)
        {
            return x - y;
        }
        public static QuadrupleC subtract(dynamic x, dynamic y)
        {
            return t(x) - t(y);
        }

        public static void rawsub(QuadrupleC res, QuadrupleC x, QuadrupleC y)
        {
            Lib_QCplx_Sub(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Sub(IntPtr res, IntPtr x, IntPtr y);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/multiply/*' />
        public static QuadrupleC multiply(QuadrupleC x, QuadrupleC y)
        {
            return x * y;
        }
        public static QuadrupleC multiply(dynamic x, dynamic y)
        {
            return t(x) * t(y);
        }

        public static void rawmul(QuadrupleC res, QuadrupleC x, QuadrupleC y)
        {
            Lib_QCplx_Add(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Si_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Si_Sub(IntPtr res, IntPtr y, Int32 x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/divide/*' />
        public static QuadrupleC divide(QuadrupleC x, QuadrupleC y)
        {
            return x / y;
        }
        public static QuadrupleC divide(dynamic x, dynamic y)
        {
            return t(x) / t(y);
        }

        public static void rawdiv(QuadrupleC res, QuadrupleC x, QuadrupleC y)
        {
            Lib_QCplx_Div(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Div(IntPtr res, IntPtr x, IntPtr y);




        public static bool Cmp(QuadrupleC x, QuadrupleC y)
        {
            return true;
        }

        public static bool CmpAbs(QuadrupleC x, QuadrupleC y)
        {
            return true;
        }




        #endregion



        #region Machine constants and properties of numbers


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isreal/*' />
        public static bool isreal(QuadrupleC z)
        {
            return (z.imag == qreal.t(0.0d));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/iszero/*' />
        public static bool iszero(QuadrupleC z)
        {
            return (z.real == qreal.t(0.0d)) && (z.imag == qreal.t(0.0d));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isone/*' />
        public static bool isone(QuadrupleC z)
        {
            return (z.real == qreal.t(1.0d)) && (z.imag == qreal.t(0.0d));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isinf/*' />
        public static bool isinf(QuadrupleC z)
        {
            return (qreal.isinf(z.real)) || (qreal.isinf(z.imag));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnan/*' />
        public static bool isnan(QuadrupleC z)
        {
            return (qreal.isnan(z.real)) || (qreal.isnan(z.imag));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isfinite/*' />
        public static bool isfinite(QuadrupleC z)
        {
            return (qreal.isfinite(z.real)) && (qreal.isfinite(z.imag));
        }





        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/zero/*' />
        public static QuadrupleC zero()
        {
            return qcplx.t(0, 0);
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/one/*' />
        public static QuadrupleC one()
        {
            return qcplx.t(1, 0);
        }


        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/ImaginaryOne/*' />
        //public static QuadrupleC ImaginaryOne()
        //{
        //    return qcplx.t(0, 1);
        //}


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/onej/*' />
        public static QuadrupleC onej()
        {
            return qcplx.t(0, 1);
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/nan/*' />
        public static QuadrupleC nan()
        {
            return qcplx.t(qreal.nan(), qreal.nan());
        }




        #endregion








        #region Complex components


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Quadruple abs(QuadrupleC z)
        {
            var res = new Quadruple();
            Lib_QCplx_Abs(res.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Abs", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Abs(IntPtr res, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Quadruple abs(dynamic z)
        {
            return abs(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Quadruple fabs(QuadrupleC z)
        {
            var res = new Quadruple();
            Lib_QCplx_Abs(res.mpPtr, z.mpPtr);
            return res;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Quadruple fabs(dynamic z)
        {
            return fabs(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static QuadrupleC sign(QuadrupleC z)
        {
            if (iszero(z)) return zero();
            else return z / abs(z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static QuadrupleC sign(dynamic z)
        {
            return sign(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Quadruple real(QuadrupleC z)
        {
            return z.real;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Quadruple real(dynamic z)
        {
            return real(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Quadruple imag(QuadrupleC z)
        {
            return z.imag;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Quadruple imag(dynamic z)
        {
            return imag(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Quadruple phase(QuadrupleC z)
        {
            var res = new Quadruple();
            Lib_QCplx_Arg(res.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Arg", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Arg(IntPtr res, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Quadruple phase(dynamic z)
        {
            return phase(t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static QuadrupleC conj(QuadrupleC z)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Conj(res.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Conj", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Conj(IntPtr res, IntPtr x);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static QuadrupleC conj(dynamic z)
        {
            return conj(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Quadruple, Quadruple> polar(QuadrupleC x)
        {
            return new Tuple<Quadruple, Quadruple>(abs(x), phase(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Quadruple, Quadruple> polar(dynamic x)
        {
            return polar(qcplx.t(x));
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



        #region Roots and quadratic, cubic, and quartic 



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static QuadrupleC sqrt(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Sqrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Sqrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Sqrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static QuadrupleC sqrt(dynamic x)
        {
            return sqrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static QuadrupleC sqrt1pm1(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Sqrt1pm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Sqrt1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Sqrt1pm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static QuadrupleC sqrt1pm1(dynamic x)
        {
            return sqrt1pm1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static QuadrupleC rsqrt(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Rsqrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Rsqrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Rsqrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static QuadrupleC rsqrt(dynamic x)
        {
            return rsqrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static QuadrupleC cbrt(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Cbrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Cbrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Cbrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static QuadrupleC cbrt(dynamic x)
        {
            return cbrt(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static QuadrupleC unitroot(Int32 k)
        {
            QuadrupleC ks = qcplx.t(k);
            return qcplx.pow(one(), one() / ks);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static QuadrupleC unitroot(dynamic x)
        {
            return unitroot(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static QuadrupleC root_si(QuadrupleC x, Int32 k)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Root_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Root_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Root_Si(IntPtr res, IntPtr x, Int32 k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static QuadrupleC root_si(dynamic x, Int32 k)
        {
            return root_si(t(x), k);
        }





        #region poly_equations


        public static QuadrupleC eval_quadratic(QuadrupleC x, QuadrupleC A, QuadrupleC B, QuadrupleC C)
        {
            return (A * x + B) * x + C;
        }

        public static QuadrupleC eval_quadratic(dynamic x, dynamic A, dynamic B, dynamic C)
        {
            return eval_quadratic(qcplx.t(x), qcplx.t(A), qcplx.t(B), qcplx.t(C));
        }


        // See also: Press, 3rd edition, page 227
        public static Tuple<QuadrupleC, QuadrupleC> quadratic_equation(QuadrupleC a, QuadrupleC b, QuadrupleC c)
        {
            QuadrupleC x1, x2;
            QuadrupleC D = qcplx.sqrt(b * b - 4 * a * c);
            QuadrupleC bStar = qcplx.conj(b);
            if ((bStar * D).real < qreal.t(0))
            {
                D = -D;
            }
            QuadrupleC q = -0.5 * (b + D);
            x1 = q / a;
            x2 = c / q;
            return new Tuple<QuadrupleC, QuadrupleC>(x1, x2);
        }
        public static Tuple<QuadrupleC, QuadrupleC> quadratic_equation(dynamic A, dynamic B, dynamic C)
        {
            return quadratic_equation(qcplx.t(A), qcplx.t(B), qcplx.t(C));
        }




        public static QuadrupleC eval_monic_cubic(QuadrupleC x, QuadrupleC a, QuadrupleC b, QuadrupleC c)
        {
            return ((x + a) * x + b) * x + c;
        }

        public static QuadrupleC eval_monic_cubic(dynamic x, dynamic a, dynamic b, dynamic c)
        {
            return eval_monic_cubic(qcplx.t(x), qcplx.t(a), qcplx.t(b), qcplx.t(c));
        }


        // See also: Press, 3rd edition, page 228
        public static Tuple<QuadrupleC, QuadrupleC, QuadrupleC> cubic_equation_monic(QuadrupleC a, QuadrupleC b, QuadrupleC c)
        {
            QuadrupleC x1, x2, x3;
            QuadrupleC Q = (a * a - 3 * b) / 9;
            QuadrupleC R = (2 * a * a * a - 9 * a * b + 27 * c) / 54;
            Quadruple Qr = Q.real;
            Quadruple Rr = R.real;
            if ((Q.imag == qreal.t(0.0)) && (R.imag == qreal.t(0.0)) && (Rr * Rr < Qr * Qr * Qr))
            {
                Console.WriteLine("In qcplx real Case");
                Quadruple SqrtQr = qreal.sqrt(Qr);
                Quadruple theta = qreal.acos(Rr / (SqrtQr * SqrtQr * SqrtQr));
                x1 = -2 * SqrtQr * qreal.cos((theta) / 3) - a / 3;
                x2 = -2 * SqrtQr * qreal.cos((theta + 2 * qreal.pi()) / 3) - a / 3;
                x3 = -2 * SqrtQr * qreal.cos((theta - 2 * qreal.pi()) / 3) - a / 3;
            }
            else
            {
                Console.WriteLine("In qcplx QuadrupleC Case");
                QuadrupleC D = qcplx.sqrt(R * R - Q * Q * Q);
                QuadrupleC RStar = qcplx.conj(R);
                if ((RStar * D).real < qreal.t(0))
                {
                    D = -D;
                }
                QuadrupleC A = -qcplx.cbrt(R + D);
                QuadrupleC B = qcplx.zero();
                if (A != qcplx.zero())
                {
                    B = Q / A;
                }
                Console.WriteLine("A: {0}", A);
                Console.WriteLine("B: {0}", B);

                x1 = (A + B) - a / 3;
                x2 = -0.5 * (A + B) - a / 3 + 0.5 * qcplx.onej() * qreal.sqrt(3) * (A - B);
                x3 = -0.5 * (A + B) - a / 3 - 0.5 * qcplx.onej() * qreal.sqrt(3) * (A - B);
            }
            return new Tuple<QuadrupleC, QuadrupleC, QuadrupleC>(x1, x2, x3);
        }
        public static Tuple<QuadrupleC, QuadrupleC, QuadrupleC> cubic_equation_monic(dynamic a, dynamic b, dynamic c)
        {
            return cubic_equation_monic(qcplx.t(a), qcplx.t(b), qcplx.t(c));
        }




        public static QuadrupleC eval_cubic(QuadrupleC x, QuadrupleC A, QuadrupleC B, QuadrupleC C, QuadrupleC D)
        {
            return ((A * x + B) * x + C) * x + D;
        }

        public static QuadrupleC eval_cubic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return eval_cubic(qcplx.t(x), qcplx.t(A), qcplx.t(B), qcplx.t(C), qcplx.t(D));
        }


        public static Tuple<QuadrupleC, QuadrupleC, QuadrupleC> cubic_equation(QuadrupleC A, QuadrupleC B, QuadrupleC C, QuadrupleC D)
        {
            return cubic_equation_monic(B / A, C / A, D / A);
        }
        public static Tuple<QuadrupleC, QuadrupleC, QuadrupleC> cubic_equation(dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return cubic_equation(qcplx.t(A), qcplx.t(B), qcplx.t(C), qcplx.t(D));
        }




        public static QuadrupleC eval_quartic(QuadrupleC x, QuadrupleC A, QuadrupleC B, QuadrupleC C, QuadrupleC D, QuadrupleC E)
        {
            return (((A * x + B) * x + C) * x + D) * x + E;
        }

        public static QuadrupleC eval_quartic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return eval_quartic(qcplx.t(x), qcplx.t(A), qcplx.t(B), qcplx.t(C), qcplx.t(D), qcplx.t(E));
        }


        // See also: https://en.wikipedia.org/wiki/Quartic_equation#Summary_of_Ferrari's_method
        public static Tuple<QuadrupleC, QuadrupleC, QuadrupleC, QuadrupleC> quartic_equation(QuadrupleC A, QuadrupleC B, QuadrupleC C, QuadrupleC D, QuadrupleC E)
        {
            QuadrupleC x1, x2, x3, x4;
            QuadrupleC a = -(3 * B * B) / (8 * A * A) + C / A;
            QuadrupleC b = (B * B * B) / (8 * A * A * A) - (B * C) / (2 * A * A) + D / A;
            QuadrupleC c = -(3 * B * B * B * B) / (256 * A * A * A * A) + (C * B * B) / (16 * A * A * A) - (B * D) / (4 * A * A) + E / A;
            QuadrupleC V = -B / (4 * A);

            if (qcplx.iszero(b))
            {
                QuadrupleC W = qcplx.sqrt(a * a - 4 * c);
                QuadrupleC Z1 = qcplx.sqrt((-a + W) / 2);
                QuadrupleC Z2 = qcplx.sqrt((-a - W) / 2);
                x1 = V + Z1;
                x2 = V - Z1;
                x3 = V + Z2;
                x4 = V - Z2;
            }
            else
            {
                QuadrupleC e = 5 * a / 2;
                QuadrupleC f = 2 * a * a - c;
                QuadrupleC g = a * a * a / 2 - a * c / 2 - b * b / 8;
                var res = cubic_equation_monic(e, f, g);
                QuadrupleC y = res.Item1;
                QuadrupleC W = qcplx.sqrt(a + 2 * y);
                QuadrupleC Z1 = qcplx.sqrt(-(3 * a + 2 * y + 2 * b / W));
                QuadrupleC Z2 = qcplx.sqrt(-(3 * a + 2 * y - 2 * b / W));
                x1 = V + (W + Z1) / 2;
                x2 = V + (W - Z1) / 2;
                x3 = V - (W + Z2) / 2;
                x4 = V - (W - Z2) / 2;
            }
            return new Tuple<QuadrupleC, QuadrupleC, QuadrupleC, QuadrupleC>(x1, x2, x3, x4);
        }

        public static Tuple<QuadrupleC, QuadrupleC, QuadrupleC, QuadrupleC> quartic_equation(dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return quartic_equation(qcplx.t(A), qcplx.t(B), qcplx.t(C), qcplx.t(D), qcplx.t(E));
        }

        #endregion








        #endregion



        #region Exponential and related functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static QuadrupleC exp(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Exp(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Exp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Exp(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static QuadrupleC exp(dynamic x)
        {
            return exp(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static QuadrupleC expj(QuadrupleC x)
        {
            return cos(x) + onej() * sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static QuadrupleC expj(dynamic x)
        {
            return expj(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static QuadrupleC expjpi(QuadrupleC x)
        {
            return cospi(x) + onej() * sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static QuadrupleC expjpi(dynamic x)
        {
            return expjpi(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static QuadrupleC exp2(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Exp2(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Exp2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Exp2(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static QuadrupleC exp2(dynamic x)
        {
            return exp2(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static QuadrupleC exp10(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Exp10(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Exp10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Exp10(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static QuadrupleC exp10(dynamic x)
        {
            return exp10(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static QuadrupleC expm1(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Expm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Expm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Expm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static QuadrupleC expm1(dynamic x)
        {
            return expm1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static QuadrupleC exp2m1(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Exp2m1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Exp2m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Exp2m1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static QuadrupleC exp2m1(dynamic x)
        {
            return exp2m1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static QuadrupleC exp10m1(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Exp10m1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Exp10m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Exp10m1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static QuadrupleC exp10m1(dynamic x)
        {
            return exp10m1(t(x));
        }







        #endregion



        #region Logarithms and related functions




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static QuadrupleC log(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Log(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Log", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Log(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static QuadrupleC log(dynamic x)
        {
            return log(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static QuadrupleC log2(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Log2(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Log2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Log2(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static QuadrupleC log2(dynamic x)
        {
            return log2(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static QuadrupleC log10(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Log10(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Log10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Log10(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static QuadrupleC log10(dynamic x)
        {
            return log10(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static QuadrupleC log1p(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Log1p(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Log1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Log1p(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static QuadrupleC log1p(dynamic x)
        {
            return log1p(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static QuadrupleC log2p1(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Log2p1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Log2p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Log2p1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static QuadrupleC log2p1(dynamic x)
        {
            return log2p1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static QuadrupleC log10p1(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Log10p1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Log10p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Log10p1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static QuadrupleC log10p1(dynamic x)
        {
            return log10p1(t(x));
        }






        #endregion



        #region Power functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static QuadrupleC sqr(QuadrupleC x)
        {
            return x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static QuadrupleC sqr(dynamic x)
        {
            return sqr(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static QuadrupleC cube(QuadrupleC x)
        {
            return x * x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static QuadrupleC cube(dynamic x)
        {
            return cube(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static QuadrupleC hypot(QuadrupleC x, QuadrupleC y)
        {
            return sqrt(x * x + y * y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static QuadrupleC hypot(dynamic x, dynamic y)
        {
            return hypot(t(x), t(y));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static QuadrupleC pow(QuadrupleC x, QuadrupleC y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Pow(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Pow", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Pow(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static QuadrupleC pow(dynamic x, dynamic y)
        {
            return pow(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static QuadrupleC powm1(QuadrupleC x, QuadrupleC y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Powm1(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Powm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Powm1(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static QuadrupleC powm1(dynamic x, dynamic y)
        {
            return powm1(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static QuadrupleC pow1p(QuadrupleC x, QuadrupleC y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Pow1p(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Pow1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Pow1p(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static QuadrupleC pow1p(dynamic x, dynamic y)
        {
            return pow1p(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static QuadrupleC pow1pm1(QuadrupleC x, QuadrupleC y)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Pow1pm1(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Pow1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Pow1pm1(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static QuadrupleC pow1pm1(dynamic x, dynamic y)
        {
            return pow1pm1(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static QuadrupleC pow_si(QuadrupleC x, Int32 k)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Pow_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Pow_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Pow_Si(IntPtr res, IntPtr x, Int32 k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static QuadrupleC pow_si(dynamic x, Int32 k)
        {
            return pow_si(t(x), k);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static QuadrupleC compound_si(QuadrupleC x, Int32 k)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Compound_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Compound_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Compound_Si(IntPtr res, IntPtr x, Int32 k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static QuadrupleC compound_si(dynamic x, Int32 k)
        {
            return compound_si(t(x), k);
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static QuadrupleC sin(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Sin(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Sin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Sin(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static QuadrupleC sin(dynamic x)
        {
            return sin(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static QuadrupleC cos(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Cos(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Cos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Cos(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static QuadrupleC cos(dynamic x)
        {
            return cos(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static QuadrupleC tan(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Tan(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Tan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Tan(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static QuadrupleC tan(dynamic x)
        {
            return tan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static QuadrupleC csc(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Csc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Csc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Csc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static QuadrupleC csc(dynamic x)
        {
            return csc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static QuadrupleC sec(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Sec(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Sec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Sec(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static QuadrupleC sec(dynamic x)
        {
            return sec(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static QuadrupleC cot(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Cot(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Cot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Cot(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static QuadrupleC cot(dynamic x)
        {
            return cot(t(x));
        }


        public static Tuple<Quadruple, Quadruple> divmod(Quadruple a, Quadruple b)
        {
            Quadruple r = qreal.fmod(a, b);
            Quadruple q = (a - r) / b;
            return new Tuple<Quadruple, Quadruple>(q, r);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinpi/*' />
        public static QuadrupleC sinpi(QuadrupleC x)
        {
            if (x.real < 0) return -sinpi(-x);
            var n_r = divmod(x.real, qreal.t(0.5));
            x = qcplx.t(n_r.Item2, x.imag) * qreal.pi();
            Int32 n = qreal.lrint(qreal.fmod(n_r.Item1, 4));
            if (n == 0) return qcplx.sin(x);
            else if (n == 1) return qcplx.cos(x);
            else if (n == 2) return -qcplx.sin(x);
            else return -qcplx.cos(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinpi/*' />
        public static QuadrupleC sinpi(dynamic x)
        {
            return sinpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static QuadrupleC cospi(QuadrupleC x)
        {
            if (x.real < 0) x = -x;
            var n_r = divmod(x.real, qreal.t(0.5));
            x = qcplx.t(n_r.Item2, x.imag) * qreal.pi();
            Int32 n = qreal.lrint(qreal.fmod(n_r.Item1, 4));
            if (n == 0) return qcplx.cos(x);
            else if (n == 1) return -qcplx.sin(x);
            else if (n == 2) return -qcplx.cos(x);
            else return qcplx.sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static QuadrupleC cospi(dynamic x)
        {
            return cospi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static QuadrupleC tanpi(QuadrupleC x)
        {
            return qcplx.sinpi(x) / qcplx.cospi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static QuadrupleC tanpi(dynamic x)
        {
            return tanpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static QuadrupleC cscpi(QuadrupleC x)
        {
            return 1.0 / qcplx.sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static QuadrupleC cscpi(dynamic x)
        {
            return cscpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static QuadrupleC secpi(QuadrupleC x)
        {
            return 1.0 / qcplx.cospi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static QuadrupleC secpi(dynamic x)
        {
            return secpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cotpi/*' />
        public static QuadrupleC cotpi(QuadrupleC x)
        {
            return qcplx.cospi(x) / qcplx.sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cotpi/*' />
        public static QuadrupleC cotpi(dynamic x)
        {
            return cotpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinc/*' />
        public static QuadrupleC sinc(QuadrupleC x)
        {
            if (qcplx.iszero(x)) return qcplx.t(1, 0);
            else return qcplx.sin(x) / (x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinc/*' />
        public static QuadrupleC sinc(dynamic x)
        {
            return sinc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static QuadrupleC sincpi(QuadrupleC x)
        {
            if (qcplx.iszero(x)) return qcplx.t(1, 0);
            else return qcplx.sinpi(x) / (x * qreal.pi());
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static QuadrupleC sincpi(dynamic x)
        {
            return sincpi(t(x));
        }







        #endregion



        #region Hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static QuadrupleC sinh(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Sinh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Sinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Sinh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static QuadrupleC sinh(dynamic x)
        {
            return sinh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static QuadrupleC cosh(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Cosh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Cosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Cosh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static QuadrupleC cosh(dynamic x)
        {
            return cosh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static QuadrupleC tanh(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Tanh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Tanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Tanh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static QuadrupleC tanh(dynamic x)
        {
            return tanh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static QuadrupleC csch(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Csch(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Csch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Csch(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static QuadrupleC csch(dynamic x)
        {
            return csch(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static QuadrupleC sech(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Sech(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Sech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Sech(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static QuadrupleC sech(dynamic x)
        {
            return sech(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static QuadrupleC coth(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Coth(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Coth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Coth(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static QuadrupleC coth(dynamic x)
        {
            return coth(t(x));
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static QuadrupleC asin(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Asin(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Asin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Asin(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static QuadrupleC asin(dynamic x)
        {
            return asin(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static QuadrupleC acos(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Acos(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Acos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Acos(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static QuadrupleC acos(dynamic x)
        {
            return acos(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static QuadrupleC atan(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Atan(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Atan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Atan(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static QuadrupleC atan(dynamic x)
        {
            return atan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static QuadrupleC acsc(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Acsc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Acsc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Acsc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static QuadrupleC acsc(dynamic x)
        {
            return acsc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static QuadrupleC asec(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Asec(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Asec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Asec(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static QuadrupleC asec(dynamic x)
        {
            return asec(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static QuadrupleC acot(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Acot(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Acot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Acot(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static QuadrupleC acot(dynamic x)
        {
            return acot(t(x));
        }




        #endregion



        #region Inverse hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static QuadrupleC asinh(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Asinh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Asinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Asinh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static QuadrupleC asinh(dynamic x)
        {
            return asinh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static QuadrupleC acosh(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Acosh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Acosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Acosh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static QuadrupleC acosh(dynamic x)
        {
            return acosh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static QuadrupleC atanh(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Atanh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Atanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Atanh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static QuadrupleC atanh(dynamic x)
        {
            return atanh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static QuadrupleC acsch(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Acsch(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Acsch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Acsch(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static QuadrupleC acsch(dynamic x)
        {
            return acsch(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static QuadrupleC asech(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Asech(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Asech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Asech(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static QuadrupleC asech(dynamic x)
        {
            return asech(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static QuadrupleC acoth(QuadrupleC x)
        {
            var res = new QuadrupleC();
            Lib_QCplx_Acoth(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_QCplx_Acoth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_QCplx_Acoth(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static QuadrupleC acoth(dynamic x)
        {
            return acoth(t(x));
        }




        #endregion






        #region Matrix Creation



        public static QuadrupleMatC mat_t(QuadrupleC x)
        {
            var matA = new QuadrupleMatC();
            matA[0, 0] = x;
            return matA;
        }


        public static QuadrupleMatC mat_t(QuadrupleMat matA)
        {
            var x = mat_zeros(matA.rows, matA.cols);
            Lib_Eigen_QReal_ConvertRealCplx(matA.mpPtr, constants.mp_conv_set_to_complex_dbl, x.mpPtr);
            return x;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_QReal_ConvertRealCplx", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_QReal_ConvertRealCplx(IntPtr RMat, int what, IntPtr CMat);


        /// <summary>
        /// Makes a deep copy from a complex matrix of type YCplxMatT
        /// </summary>
        public static QuadrupleMatC mat_t(QuadrupleMatC matA)
        {
            var matX = mat_zeros(matA.rows, matA.cols);
            matX = +matA;
            return matX;
        }

        public static QuadrupleMatC mat_zeros(int n, int m)
        {
            var resout = new QuadrupleMatC();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setZero, n, m);
            return resout;
        }

        /* *********************** */

        public static QuadrupleMatC mat_cplx_t(QuadrupleMatC matA)
        {
            return mat_t(matA);
        }


        public static QuadrupleMatC mat_cplx_zeros(int n, int m)
        {
            return mat_zeros(n, m);
        }

        /* *********************** */






        public static QuadrupleMatC mat_ones(int n, int m)
        {
            var resout = new QuadrupleMatC();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setOnes, n, m);
            return resout;
        }



        public static QuadrupleMatC mat_identity(int n, int m)
        {
            var resout = new QuadrupleMatC();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setIdentity, n, m);
            return resout;
        }



        public static QuadrupleMatC mat_random(int n, int m)
        {
            var resout = new QuadrupleMatC();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandom_nm, n, m);
            return resout;
        }



        public static QuadrupleMatC mat_random_symmetric(int n)
        {
            var resout = new QuadrupleMatC();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSymmetric, n, n);
            return resout;
        }



        public static QuadrupleMatC mat_random_selfadjoint(int n)
        {
            var resout = new QuadrupleMatC();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSA, n, n);
            return resout;
        }



        public static QuadrupleMatC mat_random_selfadjoint_posdef(int n)
        {
            var resout = new QuadrupleMatC();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSAPosDef, n, n);
            return resout;
        }



        public static QuadrupleMatC mat_fill_linear(int n, int m)
        {
            var resout = new QuadrupleMatC();
            qlib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_FillLinear, n, m);
            return resout;
        }



        #endregion






    }






}