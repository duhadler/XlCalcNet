using System;
using System.Numerics;
using System.Runtime.InteropServices;


namespace FixedPrecNet
{



    public partial class ExtendedC
    {


        #region Init

        public IntPtr mpPtr = IntPtr.Zero;


        private void Init()
        {
            xcn.Init();
            mpPtr = Lib_XCplx_Init_Func();
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_XCplx_Init_Func();


        ~ExtendedC()
        {
            Lib_XCplx_Clear(mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Clear(IntPtr x);

        #endregion



        #region Conversions

        public ExtendedC()
        {
            Init();
        }


        public Extended real
        {
            get
            {
                var res = new Extended();
                Lib_XCplx_Real(res.mpPtr, mpPtr);
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Real", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Real(IntPtr res, IntPtr z);


        public Extended imag
        {
            get
            {
                var res = new Extended();
                Lib_XCplx_Imag(res.mpPtr, mpPtr);
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Imag", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Imag(IntPtr res, IntPtr z);



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
            return "ecplx('" + ToString() + "')";
        }

        #endregion




        #region Arithmetic operators



        public static bool operator ==(dynamic x, ExtendedC y)
        {
            return ecplx.t(x) == y;
        }

        public static bool operator ==(ExtendedC x, dynamic y)
        {
            return x == ecplx.t(y);
        }


        public static bool operator !=(dynamic x, ExtendedC y)
        {
            return ecplx.t(x) != y;
        }

        public static bool operator !=(ExtendedC x, dynamic y)
        {
            return x != ecplx.t(y);
        }


        public static bool operator ==(ExtendedC x, ExtendedC y)
        {
            return x.real == y.real & x.imag == y.imag;
        }

        public static bool operator !=(ExtendedC x, ExtendedC y)
        {
            return x.real != y.real | x.imag != y.imag;
        }




        public static ExtendedC operator +(ExtendedC x)
        {
            //return ecplx.t(x);
            return x + ecplx.zero();
        }


        public static ExtendedC operator -(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Neg(res.mpPtr, x.mpPtr);
            return res;
        }
        public static ExtendedC Negate(ExtendedC x)
        {
            return -x;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Neg", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Neg(IntPtr res, IntPtr x);







        public static ExtendedC operator +(ExtendedC x, dynamic y)
        {
            return x + ecplx.t(y);
        }

        public static ExtendedC operator +(dynamic x, ExtendedC y)
        {
            return ecplx.t(x) + y;
        }


        public static ExtendedC operator +(ExtendedC x, Extended y)
        {
            var res = new ExtendedC();
            Lib_XCplx_Add_XReal(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Add_XReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Add_XReal(IntPtr res, IntPtr x, IntPtr y);


        public static ExtendedC operator +(ExtendedC x, ExtendedC y)
        {
            var res = new ExtendedC();
            Lib_XCplx_Add(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Add(IntPtr res, IntPtr x, IntPtr y);


        public static ExtendedMatC operator +(ExtendedC m2, ExtendedMat M1)
        {
            var Res = new ExtendedMatC();
            elib.Lib_Eigen_XReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, m2.real.mpPtr, m2.imag.mpPtr);
            return Res;
        }


        public static ExtendedMatC operator +(ExtendedC m2, ExtendedMatC M1)
        {
            var Res = new ExtendedMatC();
            var t = ecplx.mat_t(m2);
            elib.Lib_Eigen_XReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }






        public static ExtendedC operator -(ExtendedC x, dynamic y)
        {
            return x - ecplx.t(y);
        }

        public static ExtendedC operator -(dynamic x, ExtendedC y)
        {
            return ecplx.t(x) - y;
        }


        public static ExtendedC operator -(ExtendedC x, Extended y)
        {
            var res = new ExtendedC();
            Lib_XCplx_Sub_XReal(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Sub_XReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Sub_XReal(IntPtr res, IntPtr x, IntPtr y);


        public static ExtendedC operator -(ExtendedC x, ExtendedC y)
        {
            var res = new ExtendedC();
            Lib_XCplx_Sub(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Sub(IntPtr res, IntPtr x, IntPtr y);


        public static ExtendedMatC operator -(ExtendedC m2, ExtendedMat M1)
        {
            var Res = new ExtendedMatC();
            elib.Lib_Eigen_XReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, m2.real.mpPtr, m2.imag.mpPtr);
            return -Res;
        }


        public static ExtendedMatC operator -(ExtendedC m2, ExtendedMatC M1)
        {
            var Res = new ExtendedMatC();
            var t = ecplx.mat_t(m2);
            elib.Lib_Eigen_XReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_minus, M1.mpPtr, t.mpPtr);
            return -Res;
        }









        public static ExtendedC operator *(ExtendedC x, dynamic y)
        {
            return x * ecplx.t(y);
        }

        public static ExtendedC operator *(dynamic x, ExtendedC y)
        {
            return ecplx.t(x) * y;
        }


        public static ExtendedC operator *(ExtendedC x, Extended y)
        {
            var res = new ExtendedC();
            Lib_XCplx_Mul_XReal(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Mul_XReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Mul_XReal(IntPtr res, IntPtr x, IntPtr y);


        public static ExtendedC operator *(ExtendedC x, ExtendedC y)
        {
            var res = new ExtendedC();
            Lib_XCplx_Mul(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Mul", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Mul(IntPtr res, IntPtr x, IntPtr y);


        public static ExtendedMatC operator *(ExtendedC m2, ExtendedMat M1)
        {
            var Res = new ExtendedMatC();
            elib.Lib_Eigen_XReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, m2.real.mpPtr, m2.imag.mpPtr);
            return Res;
        }


        public static ExtendedMatC operator *(ExtendedC m2, ExtendedMatC M1)
        {
            var Res = new ExtendedMatC();
            var t = ecplx.mat_t(m2);
            elib.Lib_Eigen_XReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }









        public static ExtendedC operator /(ExtendedC x, dynamic y)
        {
            return x / ecplx.t(y);
        }

        public static ExtendedC operator /(dynamic x, ExtendedC y)
        {
            return ecplx.t(x) / y;
        }


        public static ExtendedC operator /(ExtendedC x, Extended y)
        {
            var res = new ExtendedC();
            Lib_XCplx_Div_XReal(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Div_XReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Div_XReal(IntPtr res, IntPtr x, IntPtr y);


        public static ExtendedC operator /(ExtendedC x, ExtendedC y)
        {
            var res = new ExtendedC();
            Lib_XCplx_Div(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Div(IntPtr res, IntPtr x, IntPtr y);







        #endregion


    }




    public partial class ecplx
    {

        public static String fmt(ExtendedC z)
        {
            string s1 = z.real.ToString();
            string s2 = z.imag.ToString();
            string s = " " + "(" + s1 + ", " + s2 + ")";
            return s;
        }

        public static String fmt(Extended x)
        {
            return ereal.fmt(x);
        }


        public static String fmt(dynamic z)
        {
            return fmt(t(z));
        }



        #region General

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/name/*' />
        public static String name
        {
            get { return "ecplx"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  ecplx"; }
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
        public static ereal realctx
        {
            get { return new ereal(); }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/cplxctx/*' />
        public static ecplx cplxctx
        {
            get { return new ecplx(); }
        }


        #endregion



        #region Conversions



        /// <summary>
        /// Returns a new ExtendedC using a general object as input
        /// </summary>
        public static ExtendedC t(dynamic z)
        {
            // MsgBox(y_.GetType().ToString())
            // MsgBox(y_.ToString())
            // MsgBox(y_.real.ToString())
            string s_re = z.real.ToString();
            string s_im = z.imag.ToString();
            return ecplx.t(ereal.t(s_re), ereal.t(s_im));
        }




        /// <summary>
        /// Returns a new ExtendedC using an Octuple as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static ExtendedC t(Octuple x)
        {
            return ecplx.t(ereal.t(x));
        }



        /// <summary>
        /// Returns a new ExtendedC using a Quadruple as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static ExtendedC t(Quadruple x)
        {
            return ecplx.t(ereal.t(x));
        }



        /// <summary>
        /// Returns a new ExtendedC using an Extended as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static ExtendedC t(Extended x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Set_Real(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Set_Real", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Set_Real(IntPtr res, IntPtr x);




        /// <summary>
        /// Returns a new ExtendedC using a Double (System.Double) for the real part; the imaginary part is set to zero.
        /// </summary>
        public static ExtendedC t(Double x)
        {
            return ecplx.t(ereal.t(x));
        }



        /// <summary>
        /// Returns a new ExtendedC using a Single (System.Single)  as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static ExtendedC t(Single x)
        {
            return ecplx.t(ereal.t(x));
        }



        /// <summary>
        /// Returns a new ExtendedC using a signed 32 bit integer (System.Int32) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static ExtendedC t(Int32 x)
        {
            return ecplx.t(ereal.t(x));
        }


        /// <summary>
        /// Returns a new ExtendedC using an unsigned 32 bit integer (System.UInt32) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static ExtendedC t(UInt32 x)
        {
            return ecplx.t(ereal.t(x));
        }


        /// <summary>
        /// Returns a new ExtendedC using a signed 64 bit integer (System.Int64) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static ExtendedC t(Int64 x)
        {
            return ecplx.t(ereal.t(x));
        }


        /// <summary>
        /// Returns a new ExtendedC using an unsigned 64 bit integer (System.UInt64) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static ExtendedC t(UInt64 x)
        {
            return ecplx.t(ereal.t(x));
        }


        /// <summary>
        /// Returns a new Extended using a decimal number (System.Decimal) as input
        /// </summary>
        public static ExtendedC t(decimal x)
        {
            return ecplx.t(ereal.t(x));
        }




        /// <summary>
        /// Returns a new ExtendedC using a BigInteger (System.Numerics.BigInteger) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static ExtendedC t(BigInteger x)
        {
            return ecplx.t(ereal.t(x));
        }


        /// <summary>
        /// Returns a new ExtendedC using a string (System.String) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static ExtendedC t(string s)
        {
            return ecplx.t(ereal.t(s));
        }



        /// <summary>
        /// Returns a new ExtendedC using 2 Extended as input for the real and imaginary part
        /// </summary>
        public static ExtendedC t(Extended re, Extended im)
        {
            var res = new ExtendedC();
            Lib_XCplx_Set2(res.mpPtr, re.mpPtr, im.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Set2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Set2(IntPtr res, IntPtr re, IntPtr im);




        /// <summary>
        /// Returns a new ExtendedC using a OctupleC as input
        /// </summary>
        public static ExtendedC t(OctupleC z)
        {
            return ecplx.t(ereal.t(z.real), ereal.t(z.imag));
        }



        /// <summary>
        /// Returns a new ExtendedC using a QuadrupleC as input
        /// </summary>
        public static ExtendedC t(QuadrupleC z)
        {
            return ecplx.t(ereal.t(z.real), ereal.t(z.imag));
        }



        /// <summary>
        /// Returns a new ExtendedC using an ExtendedC as input
        /// </summary>
        public static ExtendedC t(ExtendedC z)
        {
            return ecplx.t(ereal.t(z.real), ereal.t(z.imag));
        }



        /// <summary>
        /// Returns a new ExtendedC using a a Complex (System.Numerics.Complex) as input
        /// </summary>
        public static ExtendedC t(Complex z)
        {
            return ecplx.t(ereal.t(z.Real), ereal.t(z.Imaginary));
        }




        ///// <summary>
        ///// Returns a new ExtendedC using a ExtendedC as input
        ///// </summary>
        //public static ExtendedC t(ExtendedC z)
        //{
        //    return ecplx.t(ereal.t(z.real), ereal.t(z.imag));
        //}



        /// <summary>
        /// Returns a new ExtendedC using 2 Doubles (System.Double) as input for the real and imaginary part
        /// </summary>
        public static ExtendedC t(Double d_re, Double d_im)
        {
            return ecplx.t(ereal.t(d_re), ereal.t(d_im));
        }


        /// <summary>
        /// Returns a new ExtendedC using 2 strings (System.String) as input for the real and imaginary part
        /// </summary>
        public static ExtendedC t(string s_re, string s_im)
        {
            return ecplx.t(ereal.t(s_re), ereal.t(s_im));
        }

        #endregion





        #region Basic Arithmetic and Comparisons



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/add/*' />
        public static ExtendedC add(ExtendedC x, ExtendedC y)
        {
            return x + y;
        }
        public static ExtendedC add(dynamic x, dynamic y)
        {
            return t(x) + t(y);
        }

        public static void rawadd(ExtendedC res, ExtendedC x, ExtendedC y)
        {
            Lib_XCplx_Add(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Add(IntPtr res, IntPtr x, IntPtr y);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/subtract/*' />
        public static ExtendedC subtract(ExtendedC x, ExtendedC y)
        {
            return x - y;
        }
        public static ExtendedC subtract(dynamic x, dynamic y)
        {
            return t(x) - t(y);
        }

        public static void rawsub(ExtendedC res, ExtendedC x, ExtendedC y)
        {
            Lib_XCplx_Sub(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Sub(IntPtr res, IntPtr x, IntPtr y);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/multiply/*' />
        public static ExtendedC multiply(ExtendedC x, ExtendedC y)
        {
            return x * y;
        }
        public static ExtendedC multiply(dynamic x, dynamic y)
        {
            return t(x) * t(y);
        }
        public static void rawmul(ExtendedC res, ExtendedC x, ExtendedC y)
        {
            Lib_XCplx_Add(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Mul", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Mul(IntPtr res, IntPtr x, IntPtr y);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/divide/*' />
        public static ExtendedC divide(ExtendedC x, ExtendedC y)
        {
            return x / y;
        }
        public static ExtendedC divide(dynamic x, dynamic y)
        {
            return t(x) / t(y);
        }

        public static void rawdiv(ExtendedC res, ExtendedC x, ExtendedC y)
        {
            Lib_XCplx_Div(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Div(IntPtr res, IntPtr x, IntPtr y);




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Cmp/*' />
        public static bool Cmp(ExtendedC x, ExtendedC y)
        {
            return true;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/CmpAbs/*' />
        public static bool CmpAbs(ExtendedC x, ExtendedC y)
        {
            return true;
        }




        #endregion



        #region Machine constants and properties of numbers


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isreal/*' />
        public static bool isreal(ExtendedC z)
        {
            return (z.imag == ereal.t(0.0d));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/iszero/*' />
        public static bool iszero(ExtendedC z)
        {
            return (z.real == ereal.t(0.0d)) && (z.imag == ereal.t(0.0d));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isone/*' />
        public static bool isone(ExtendedC z)
        {
            return (z.real == ereal.t(1.0d)) && (z.imag == ereal.t(0.0d));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isinf/*' />
        public static bool isinf(ExtendedC z)
        {
            return (ereal.isinf(z.real)) || (ereal.isinf(z.imag));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnan/*' />
        public static bool isnan(ExtendedC z)
        {
            return (ereal.isnan(z.real)) || (ereal.isnan(z.imag));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isfinite/*' />
        public static bool isfinite(ExtendedC z)
        {
            return (ereal.isfinite(z.real)) && (ereal.isfinite(z.imag));
        }





        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/zero/*' />
        public static ExtendedC zero()
        {
            return ecplx.t(0d, 0d);
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/one/*' />
        public static ExtendedC one()
        {
            return ecplx.t(1d, 0d);
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/ImaginaryOne/*' />
        public static ExtendedC ImaginaryOne()
        {
            return ecplx.t(0d, 1d);
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/onej/*' />
        public static ExtendedC onej()
        {
            return ecplx.t(0d, 1d);
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/nan/*' />
        public static ExtendedC nan()
        {
            return ecplx.t(ereal.nan(), ereal.nan());
        }




        #endregion







        #region Complex components



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Extended abs(ExtendedC z)
        {
            var res = new Extended();
            Lib_XCplx_Abs(res.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Abs", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Abs(IntPtr res, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Extended abs(dynamic z)
        {
            return abs(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Extended fabs(ExtendedC z)
        {
            var res = new Extended();
            Lib_XCplx_Abs(res.mpPtr, z.mpPtr);
            return res;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Extended fabs(dynamic z)
        {
            return fabs(t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static ExtendedC sign(ExtendedC z)
        {
            if (iszero(z)) return zero();
            else return z / abs(z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static ExtendedC sign(dynamic z)
        {
            return sign(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Extended real(ExtendedC z)
        {
            return z.real;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Extended real(dynamic z)
        {
            return real(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Extended imag(ExtendedC z)
        {
            return z.imag;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Extended imag(dynamic z)
        {
            return imag(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Extended phase(ExtendedC z)
        {
            var res = new Extended();
            Lib_XCplx_Arg(res.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Arg", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Arg(IntPtr res, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Extended phase(dynamic z)
        {
            return phase(t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static ExtendedC conj(ExtendedC z)
        {
            var res = new ExtendedC();
            Lib_XCplx_Conj(res.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Conj", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Conj(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static ExtendedC conj(dynamic z)
        {
            return conj(t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Extended, Extended> polar(ExtendedC x)
        {
            return new Tuple<Extended, Extended>(abs(x), phase(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Extended, Extended> polar(dynamic x)
        {
            return polar(ecplx.t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rect/*' />
        public static ExtendedC rect(Extended r, Extended phi)
        {
            return r * expj(phi);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rect/*' />
        public static ExtendedC rect(dynamic r, dynamic phi)
        {
            return rect(ereal.t(r), ereal.t(phi));
        }






        #endregion



        #region Roots and quadratic, cubic, and quartic 



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static ExtendedC sqrt(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Sqrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Sqrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Sqrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static ExtendedC sqrt(dynamic x)
        {
            return sqrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static ExtendedC sqrt1pm1(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Sqrt1pm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Sqrt1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Sqrt1pm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static ExtendedC sqrt1pm1(dynamic x)
        {
            return sqrt1pm1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static ExtendedC rsqrt(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Rsqrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Rsqrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Rsqrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static ExtendedC rsqrt(dynamic x)
        {
            return rsqrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static ExtendedC cbrt(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Cbrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Cbrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Cbrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static ExtendedC cbrt(dynamic x)
        {
            return cbrt(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static ExtendedC unitroot(Int32 k)
        {
            ExtendedC ks = ecplx.t(k);
            return ecplx.pow(one(), one() / ks);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static ExtendedC unitroot(dynamic x)
        {
            return unitroot(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static ExtendedC root_si(ExtendedC x, Int32 k)
        {
            var res = new ExtendedC();
            Lib_XCplx_Root_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Root_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Root_Si(IntPtr res, IntPtr x, Int32 k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static ExtendedC root_si(dynamic x, Int32 k)
        {
            return root_si(t(x), k);
        }



        #region poly_equations

        public static ExtendedC eval_quadratic(ExtendedC x, ExtendedC A, ExtendedC B, ExtendedC C)
        {
            return (A * x + B) * x + C;
        }

        public static ExtendedC eval_quadratic(dynamic x, dynamic A, dynamic B, dynamic C)
        {
            return eval_quadratic(ecplx.t(x), ecplx.t(A), ecplx.t(B), ecplx.t(C));
        }


        // See also: Press, 3rd edition, page 227
        public static Tuple<ExtendedC, ExtendedC> quadratic_equation(ExtendedC a, ExtendedC b, ExtendedC c)
        {
            ExtendedC x1, x2;
            ExtendedC D = ecplx.sqrt(b * b - 4 * a * c);
            ExtendedC bStar = ecplx.conj(b);
            if ((bStar * D).real < ereal.t(0))
            {
                D = -D;
            }
            ExtendedC q = -0.5 * (b + D);
            x1 = q / a;
            x2 = c / q;
            return new Tuple<ExtendedC, ExtendedC>(x1, x2);
        }
        public static Tuple<ExtendedC, ExtendedC> quadratic_equation(dynamic A, dynamic B, dynamic C)
        {
            return quadratic_equation(ecplx.t(A), ecplx.t(B), ecplx.t(C));
        }





        public static ExtendedC eval_monic_cubic(ExtendedC x, ExtendedC a, ExtendedC b, ExtendedC c)
        {
            return ((x + a) * x + b) * x + c;
        }

        public static ExtendedC eval_monic_cubic(dynamic x, dynamic a, dynamic b, dynamic c)
        {
            return eval_monic_cubic(ecplx.t(x), ecplx.t(a), ecplx.t(b), ecplx.t(c));
        }


        // See also: Press, 3rd edition, page 228
        public static Tuple<ExtendedC, ExtendedC, ExtendedC> cubic_equation_monic(ExtendedC a, ExtendedC b, ExtendedC c)
        {
            ExtendedC x1, x2, x3;
            ExtendedC Q = (a * a - 3 * b) / 9;
            ExtendedC R = (2 * a * a * a - 9 * a * b + 27 * c) / 54;
            Extended Qr = Q.real;
            Extended Rr = R.real;
            if ((Q.imag == ereal.t(0.0)) && (R.imag == ereal.t(0.0)) && (Rr * Rr < Qr * Qr * Qr))
            {
                Console.WriteLine("In ecplx real Case");
                Extended SqrtQr = ereal.sqrt(Qr);
                Extended theta = ereal.acos(Rr / (SqrtQr * SqrtQr * SqrtQr));
                x1 = -2 * SqrtQr * ereal.cos((theta) / 3) - a / 3;
                x2 = -2 * SqrtQr * ereal.cos((theta + 2 * ereal.pi()) / 3) - a / 3;
                x3 = -2 * SqrtQr * ereal.cos((theta - 2 * ereal.pi()) / 3) - a / 3;
            }
            else
            {
                Console.WriteLine("In ecplx ExtendedC Case");
                ExtendedC D = ecplx.sqrt(R * R - Q * Q * Q);
                ExtendedC RStar = ecplx.conj(R);
                if ((RStar * D).real < ereal.t(0))
                {
                    D = -D;
                }
                ExtendedC A = -ecplx.cbrt(R + D);
                ExtendedC B = ecplx.zero();
                if (A != ecplx.zero())
                {
                    B = Q / A;
                }
                Console.WriteLine("A: {0}", A);
                Console.WriteLine("B: {0}", B);

                x1 = (A + B) - a / 3;
                x2 = -0.5 * (A + B) - a / 3 + 0.5 * ecplx.ImaginaryOne() * ereal.sqrt(3) * (A - B);
                x3 = -0.5 * (A + B) - a / 3 - 0.5 * ecplx.ImaginaryOne() * ereal.sqrt(3) * (A - B);
            }
            return new Tuple<ExtendedC, ExtendedC, ExtendedC>(x1, x2, x3);
        }
        public static Tuple<ExtendedC, ExtendedC, ExtendedC> cubic_equation_monic(dynamic a, dynamic b, dynamic c)
        {
            return cubic_equation_monic(ecplx.t(a), ecplx.t(b), ecplx.t(c));
        }




        public static ExtendedC eval_cubic(ExtendedC x, ExtendedC A, ExtendedC B, ExtendedC C, ExtendedC D)
        {
            return ((A * x + B) * x + C) * x + D;
        }

        public static ExtendedC eval_cubic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return eval_cubic(ecplx.t(x), ecplx.t(A), ecplx.t(B), ecplx.t(C), ecplx.t(D));
        }


        public static Tuple<ExtendedC, ExtendedC, ExtendedC> cubic_equation(ExtendedC A, ExtendedC B, ExtendedC C, ExtendedC D)
        {
            return cubic_equation_monic(B / A, C / A, D / A);
        }
        public static Tuple<ExtendedC, ExtendedC, ExtendedC> cubic_equation(dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return cubic_equation(ecplx.t(A), ecplx.t(B), ecplx.t(C), ecplx.t(D));
        }




        public static ExtendedC eval_quartic(ExtendedC x, ExtendedC A, ExtendedC B, ExtendedC C, ExtendedC D, ExtendedC E)
        {
            return (((A * x + B) * x + C) * x + D) * x + E;
        }

        public static ExtendedC eval_quartic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return eval_quartic(ecplx.t(x), ecplx.t(A), ecplx.t(B), ecplx.t(C), ecplx.t(D), ecplx.t(E));
        }


        // See also: https://en.wikipedia.org/wiki/Quartic_equation#Summary_of_Ferrari's_method
        public static Tuple<ExtendedC, ExtendedC, ExtendedC, ExtendedC> quartic_equation(ExtendedC A, ExtendedC B, ExtendedC C, ExtendedC D, ExtendedC E)
        {
            ExtendedC x1, x2, x3, x4;
            ExtendedC a = -(3 * B * B) / (8 * A * A) + C / A;
            ExtendedC b = (B * B * B) / (8 * A * A * A) - (B * C) / (2 * A * A) + D / A;
            ExtendedC c = -(3 * B * B * B * B) / (256 * A * A * A * A) + (C * B * B) / (16 * A * A * A) - (B * D) / (4 * A * A) + E / A;
            ExtendedC V = -B / (4 * A);

            if (ecplx.iszero(b))
            {
                ExtendedC W = ecplx.sqrt(a * a - 4 * c);
                ExtendedC Z1 = ecplx.sqrt((-a + W) / 2);
                ExtendedC Z2 = ecplx.sqrt((-a - W) / 2);
                x1 = V + Z1;
                x2 = V - Z1;
                x3 = V + Z2;
                x4 = V - Z2;
            }
            else
            {
                ExtendedC e = 5 * a / 2;
                ExtendedC f = 2 * a * a - c;
                ExtendedC g = a * a * a / 2 - a * c / 2 - b * b / 8;
                var res = cubic_equation_monic(e, f, g);
                ExtendedC y = res.Item1;
                ExtendedC W = ecplx.sqrt(a + 2 * y);
                ExtendedC Z1 = ecplx.sqrt(-(3 * a + 2 * y + 2 * b / W));
                ExtendedC Z2 = ecplx.sqrt(-(3 * a + 2 * y - 2 * b / W));
                x1 = V + (W + Z1) / 2;
                x2 = V + (W - Z1) / 2;
                x3 = V - (W + Z2) / 2;
                x4 = V - (W - Z2) / 2;
            }
            return new Tuple<ExtendedC, ExtendedC, ExtendedC, ExtendedC>(x1, x2, x3, x4);
        }

        public static Tuple<ExtendedC, ExtendedC, ExtendedC, ExtendedC> quartic_equation(dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return quartic_equation(ecplx.t(A), ecplx.t(B), ecplx.t(C), ecplx.t(D), ecplx.t(E));
        }


        #endregion







        #endregion





        #region Exponential and related functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static ExtendedC exp(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Exp(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Exp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Exp(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static ExtendedC exp(dynamic x)
        {
            return exp(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static ExtendedC expj(ExtendedC x)
        {
            return cos(x) + onej() * sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static ExtendedC expj(dynamic x)
        {
            return expj(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static ExtendedC expjpi(ExtendedC x)
        {
            return cospi(x) + onej() * sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static ExtendedC expjpi(dynamic x)
        {
            return expjpi(t(x));
        }






        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static ExtendedC exp2(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Exp2(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Exp2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Exp2(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static ExtendedC exp2(dynamic x)
        {
            return exp2(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static ExtendedC exp10(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Exp10(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Exp10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Exp10(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static ExtendedC exp10(dynamic x)
        {
            return exp10(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static ExtendedC expm1(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Expm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Expm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Expm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static ExtendedC expm1(dynamic x)
        {
            return expm1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static ExtendedC exp2m1(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Exp2m1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Exp2m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Exp2m1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static ExtendedC exp2m1(dynamic x)
        {
            return exp2m1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static ExtendedC exp10m1(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Exp10m1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Exp10m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Exp10m1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static ExtendedC exp10m1(dynamic x)
        {
            return exp10m1(t(x));
        }







        #endregion



        #region Logarithms and related functions




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static ExtendedC log(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Log(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Log", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Log(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static ExtendedC log(dynamic x)
        {
            return log(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static ExtendedC log2(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Log2(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Log2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Log2(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static ExtendedC log2(dynamic x)
        {
            return log2(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static ExtendedC log10(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Log10(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Log10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Log10(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static ExtendedC log10(dynamic x)
        {
            return log10(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static ExtendedC log1p(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Log1p(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Log1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Log1p(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static ExtendedC log1p(dynamic x)
        {
            return log1p(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static ExtendedC log2p1(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Log2p1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Log2p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Log2p1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static ExtendedC log2p1(dynamic x)
        {
            return log2p1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static ExtendedC log10p1(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Log10p1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Log10p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Log10p1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static ExtendedC log10p1(dynamic x)
        {
            return log10p1(t(x));
        }






        #endregion



        #region Power functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static ExtendedC sqr(ExtendedC x)
        {
            return x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static ExtendedC sqr(dynamic x)
        {
            return sqr(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static ExtendedC cube(ExtendedC x)
        {
            return x * x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static ExtendedC cube(dynamic x)
        {
            return cube(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static ExtendedC hypot(ExtendedC x, ExtendedC y)
        {
            return sqrt(x * x + y * y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static ExtendedC hypot(dynamic x, dynamic y)
        {
            return hypot(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static ExtendedC pow(ExtendedC x, ExtendedC y)
        {
            var res = new ExtendedC();
            Lib_XCplx_Pow(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Pow", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Pow(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static ExtendedC pow(dynamic x, dynamic y)
        {
            return pow(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static ExtendedC powm1(ExtendedC x, ExtendedC y)
        {
            var res = new ExtendedC();
            Lib_XCplx_Powm1(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Powm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Powm1(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static ExtendedC powm1(dynamic x, dynamic y)
        {
            return powm1(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static ExtendedC pow1p(ExtendedC x, ExtendedC y)
        {
            var res = new ExtendedC();
            Lib_XCplx_Pow1p(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Pow1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Pow1p(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static ExtendedC pow1p(dynamic x, dynamic y)
        {
            return pow1p(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static ExtendedC pow1pm1(ExtendedC x, ExtendedC y)
        {
            var res = new ExtendedC();
            Lib_XCplx_Pow1pm1(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Pow1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Pow1pm1(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static ExtendedC pow1pm1(dynamic x, dynamic y)
        {
            return pow1pm1(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static ExtendedC pow_si(ExtendedC x, Int32 k)
        {
            var res = new ExtendedC();
            Lib_XCplx_Pow_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Pow_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Pow_Si(IntPtr res, IntPtr x, Int32 k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static ExtendedC pow_si(dynamic x, Int32 k)
        {
            return pow_si(t(x), k);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static ExtendedC compound_si(ExtendedC x, Int32 k)
        {
            var res = new ExtendedC();
            Lib_XCplx_Compound_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Compound_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Compound_Si(IntPtr res, IntPtr x, Int32 k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static ExtendedC compound_si(dynamic x, Int32 k)
        {
            return compound_si(t(x), k);
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static ExtendedC sin(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Sin(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Sin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Sin(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static ExtendedC sin(dynamic x)
        {
            return sin(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static ExtendedC cos(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Cos(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Cos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Cos(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static ExtendedC cos(dynamic x)
        {
            return cos(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static ExtendedC tan(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Tan(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Tan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Tan(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static ExtendedC tan(dynamic x)
        {
            return tan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static ExtendedC csc(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Csc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Csc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Csc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static ExtendedC csc(dynamic x)
        {
            return csc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static ExtendedC sec(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Sec(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Sec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Sec(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static ExtendedC sec(dynamic x)
        {
            return sec(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static ExtendedC cot(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Cot(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Cot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Cot(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static ExtendedC cot(dynamic x)
        {
            return cot(t(x));
        }


        public static Tuple<Extended, Extended> divmod(Extended a, Extended b)
        {
            Extended r = ereal.fmod(a, b);
            Extended q = (a - r) / b;
            return new Tuple<Extended, Extended>(q, r);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinpi/*' />
        public static ExtendedC sinpi(ExtendedC x)
        {
            if (x.real < 0) return -sinpi(-x);
            var n_r = divmod(x.real, ereal.t(0.5));
            x = ecplx.t(n_r.Item2, x.imag) * ereal.pi();
            Int32 n = ereal.lrint(ereal.fmod(n_r.Item1, 4));
            if (n == 0) return ecplx.sin(x);
            else if (n == 1) return ecplx.cos(x);
            else if (n == 2) return -ecplx.sin(x);
            else return -ecplx.cos(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinpi/*' />
        public static ExtendedC sinpi(dynamic x)
        {
            return sinpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static ExtendedC cospi(ExtendedC x)
        {
            if (x.real < 0) x = -x;
            var n_r = divmod(x.real, ereal.t(0.5));
            x = ecplx.t(n_r.Item2, x.imag) * ereal.pi();
            Int32 n = ereal.lrint(ereal.fmod(n_r.Item1, 4));
            if (n == 0) return ecplx.cos(x);
            else if (n == 1) return -ecplx.sin(x);
            else if (n == 2) return -ecplx.cos(x);
            else return ecplx.sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static ExtendedC cospi(dynamic x)
        {
            return cospi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static ExtendedC tanpi(ExtendedC x)
        {
            return ecplx.sinpi(x) / ecplx.cospi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static ExtendedC tanpi(dynamic x)
        {
            return tanpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static ExtendedC cscpi(ExtendedC x)
        {
            return 1.0 / ecplx.sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static ExtendedC cscpi(dynamic x)
        {
            return cscpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static ExtendedC secpi(ExtendedC x)
        {
            return 1.0 / ecplx.cospi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static ExtendedC secpi(dynamic x)
        {
            return secpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cotpi/*' />
        public static ExtendedC cotpi(ExtendedC x)
        {
            return ecplx.cospi(x) / ecplx.sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cotpi/*' />
        public static ExtendedC cotpi(dynamic x)
        {
            return cotpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinc/*' />
        public static ExtendedC sinc(ExtendedC x)
        {
            if (ecplx.iszero(x)) return ecplx.t(1, 0);
            else return ecplx.sin(x) / (x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinc/*' />
        public static ExtendedC sinc(dynamic x)
        {
            return sinc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static ExtendedC sincpi(ExtendedC x)
        {
            if (ecplx.iszero(x)) return ecplx.t(1, 0);
            else return ecplx.sinpi(x) / (x * ereal.pi());
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static ExtendedC sincpi(dynamic x)
        {
            return sincpi(t(x));
        }









        #endregion



        #region Hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static ExtendedC sinh(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Sinh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Sinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Sinh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static ExtendedC sinh(dynamic x)
        {
            return sinh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static ExtendedC cosh(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Cosh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Cosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Cosh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static ExtendedC cosh(dynamic x)
        {
            return cosh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static ExtendedC tanh(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Tanh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Tanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Tanh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static ExtendedC tanh(dynamic x)
        {
            return tanh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static ExtendedC csch(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Csch(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Csch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Csch(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static ExtendedC csch(dynamic x)
        {
            return csch(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static ExtendedC sech(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Sech(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Sech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Sech(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static ExtendedC sech(dynamic x)
        {
            return sech(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static ExtendedC coth(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Coth(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Coth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Coth(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static ExtendedC coth(dynamic x)
        {
            return coth(t(x));
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static ExtendedC asin(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Asin(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Asin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Asin(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static ExtendedC asin(dynamic x)
        {
            return asin(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static ExtendedC acos(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Acos(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Acos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Acos(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static ExtendedC acos(dynamic x)
        {
            return acos(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static ExtendedC atan(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Atan(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Atan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Atan(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static ExtendedC atan(dynamic x)
        {
            return atan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static ExtendedC acsc(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Acsc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Acsc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Acsc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static ExtendedC acsc(dynamic x)
        {
            return acsc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static ExtendedC asec(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Asec(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Asec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Asec(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static ExtendedC asec(dynamic x)
        {
            return asec(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static ExtendedC acot(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Acot(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Acot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Acot(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static ExtendedC acot(dynamic x)
        {
            return acot(t(x));
        }




        #endregion



        #region Inverse hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static ExtendedC asinh(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Asinh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Asinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Asinh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static ExtendedC asinh(dynamic x)
        {
            return asinh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static ExtendedC acosh(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Acosh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Acosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Acosh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static ExtendedC acosh(dynamic x)
        {
            return acosh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static ExtendedC atanh(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Atanh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Atanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Atanh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static ExtendedC atanh(dynamic x)
        {
            return atanh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static ExtendedC acsch(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Acsch(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Acsch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Acsch(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static ExtendedC acsch(dynamic x)
        {
            return acsch(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static ExtendedC asech(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Asech(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Asech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Asech(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static ExtendedC asech(dynamic x)
        {
            return asech(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static ExtendedC acoth(ExtendedC x)
        {
            var res = new ExtendedC();
            Lib_XCplx_Acoth(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_XCplx_Acoth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_XCplx_Acoth(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static ExtendedC acoth(dynamic x)
        {
            return acoth(t(x));
        }




        #endregion





        #region Matrix Creation



        public static ExtendedMatC mat_t(ExtendedC x)
        {
            var matA = new ExtendedMatC();
            matA[0, 0] = x;
            return matA;
        }


        public static ExtendedMatC mat_t(ExtendedMat matA)
        {
            var x = mat_zeros(matA.rows, matA.cols);
            Lib_Eigen_XReal_ConvertRealCplx(matA.mpPtr, constants.mp_conv_set_to_complex_dbl, x.mpPtr);
            return x;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_XReal_ConvertRealCplx", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_XReal_ConvertRealCplx(IntPtr RMat, int what, IntPtr CMat);


        /// <summary>
        /// Makes a deep copy from a complex matrix of type YCplxMatT
        /// </summary>
        public static ExtendedMatC mat_t(ExtendedMatC matA)
        {
            var matX = mat_zeros(matA.rows, matA.cols);
            matX = +matA;
            return matX;
        }

        public static ExtendedMatC mat_zeros(int n, int m)
        {
            var resout = new ExtendedMatC();
            elib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setZero, n, m);
            return resout;
        }

        /* *********************** */

        public static ExtendedMatC mat_cplx_t(ExtendedMatC matA)
        {
            return mat_t(matA);
        }


        public static ExtendedMatC mat_cplx_zeros(int n, int m)
        {
            return mat_zeros(n, m);
        }

        /* *********************** */






        public static ExtendedMatC mat_ones(int n, int m)
        {
            var resout = new ExtendedMatC();
            elib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setOnes, n, m);
            return resout;
        }



        public static ExtendedMatC mat_identity(int n, int m)
        {
            var resout = new ExtendedMatC();
            elib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setIdentity, n, m);
            return resout;
        }



        public static ExtendedMatC mat_random(int n, int m)
        {
            var resout = new ExtendedMatC();
            elib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandom_nm, n, m);
            return resout;
        }



        public static ExtendedMatC mat_random_symmetric(int n)
        {
            var resout = new ExtendedMatC();
            elib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSymmetric, n, n);
            return resout;
        }



        public static ExtendedMatC mat_random_selfadjoint(int n)
        {
            var resout = new ExtendedMatC();
            elib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSA, n, n);
            return resout;
        }



        public static ExtendedMatC mat_random_selfadjoint_posdef(int n)
        {
            var resout = new ExtendedMatC();
            elib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSAPosDef, n, n);
            return resout;
        }



        public static ExtendedMatC mat_fill_linear(int n, int m)
        {
            var resout = new ExtendedMatC();
            elib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_FillLinear, n, m);
            return resout;
        }



        #endregion




    }






}