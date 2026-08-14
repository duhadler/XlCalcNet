using System;
using System.Numerics;
using System.Runtime.InteropServices;


namespace FixedPrecNet
{



    public class SingleC
    {


        #region Init


        public IntPtr mpPtr = IntPtr.Zero;


        private void Init()
        {
            xcn.Init();
            mpPtr = Lib_SCplx_Init_Func();
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_SCplx_Init_Func();




        ~SingleC()
        {
            Lib_SCplx_Clear(mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Clear(IntPtr x);


        #endregion



        #region Conversions


        public SingleC()
        {
            Init();
        }




        public Single real
        {
            get
            {
                var res = new Single();
                Lib_SCplx_Real(ref res, mpPtr);
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Real", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Real(ref Single res, IntPtr z);


        public Single imag
        {
            get
            {
                var res = new Single();
                Lib_SCplx_Imag(ref res, mpPtr);
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Imag", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Imag(ref Single res, IntPtr z);



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
            return "SingleC('" + ToString() + "')";
        }


        #endregion




        #region Arithmetic operators


        public static bool operator ==(dynamic x, SingleC y)
        {
            return scplx.t(x) == y;
        }

        public static bool operator ==(SingleC x, dynamic y)
        {
            return x == scplx.t(y);
        }


        public static bool operator !=(dynamic x, SingleC y)
        {
            return scplx.t(x) != y;
        }

        public static bool operator !=(SingleC x, dynamic y)
        {
            return x != scplx.t(y);
        }


        public static bool operator ==(SingleC x, SingleC y)
        {
            return x.real == y.real & x.imag == y.imag;
        }

        public static bool operator !=(SingleC x, SingleC y)
        {
            return x.real != y.real | x.imag != y.imag;
        }




        public static SingleC operator +(SingleC x)
        {
            //return scplx.t(x);
            return x + scplx.zero();
        }


        public static SingleC operator -(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Neg(res.mpPtr, x.mpPtr);
            return res;
        }
        public static SingleC Negate(SingleC x)
        {
            return -x;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Neg", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Neg(IntPtr res, IntPtr x);








        public static SingleC operator +(SingleC x, dynamic y)
        {
            return x + scplx.t(y);
        }

        public static SingleC operator +(dynamic x, SingleC y)
        {
            return scplx.t(x) + y;
        }


        public static SingleC operator +(SingleC x, Single y)
        {
            var res = new SingleC();
            Lib_SCplx_Add_SReal(res.mpPtr, x.mpPtr, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Add_SReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Add_SReal(IntPtr res, IntPtr x, ref Single y);


        public static SingleC operator +(SingleC x, SingleC y)
        {
            var res = new SingleC();
            Lib_SCplx_Add(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Add(IntPtr res, IntPtr x, IntPtr y);


        public static SingleMatC operator +(SingleC m2, SingleMat M1)
        {
            var Res = new SingleMatC();
            Single x = m2.real;
            Single y = m2.imag;
            slib.Lib_Eigen_SReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, ref x, ref y);
            return Res;
        }


        public static SingleMatC operator +(SingleC m2, SingleMatC M1)
        {
            var Res = new SingleMatC();
            var t = scplx.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }




        public static SingleC operator -(SingleC x, dynamic y)
        {
            return x - scplx.t(y);
        }

        public static SingleC operator -(dynamic x, SingleC y)
        {
            return scplx.t(x) - y;
        }


        public static SingleC operator -(SingleC x, Single y)
        {
            var res = new SingleC();
            Lib_SCplx_Sub_SReal(res.mpPtr, x.mpPtr, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Sub_SReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Sub_SReal(IntPtr res, IntPtr x, ref Single y);


        public static SingleC operator -(SingleC x, SingleC y)
        {
            var res = new SingleC();
            Lib_SCplx_Sub(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Sub(IntPtr res, IntPtr x, IntPtr y);


        public static SingleMatC operator -(SingleC m2, SingleMat M1)
        {
            var Res = new SingleMatC();
            Single x = m2.real;
            Single y = m2.imag;
            slib.Lib_Eigen_SReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, ref x, ref y);
            return -Res;
        }


        public static SingleMatC operator -(SingleC m2, SingleMatC M1)
        {
            var Res = new SingleMatC();
            var t = scplx.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_minus, M1.mpPtr, t.mpPtr);
            return -Res;
        }





        public static SingleC operator *(SingleC x, dynamic y)
        {
            return x * scplx.t(y);
        }

        public static SingleC operator *(dynamic x, SingleC y)
        {
            return scplx.t(x) * y;
        }


        public static SingleC operator *(SingleC x, Single y)
        {
            var res = new SingleC();
            Lib_SCplx_Mul_SReal(res.mpPtr, x.mpPtr, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Mul_SReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Mul_SReal(IntPtr res, IntPtr x, ref Single y);


        public static SingleC operator *(SingleC x, SingleC y)
        {
            var res = new SingleC();
            Lib_SCplx_Mul(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Mul", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Mul(IntPtr res, IntPtr x, IntPtr y);


        public static SingleMatC operator *(SingleC m2, SingleMat M1)
        {
            var Res = new SingleMatC();
            Single x = m2.real;
            Single y = m2.imag;
            slib.Lib_Eigen_SReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, ref x, ref y);
            return Res;
        }


        public static SingleMatC operator *(SingleC m2, SingleMatC M1)
        {
            var Res = new SingleMatC();
            var t = scplx.mat_t(m2);
            slib.Lib_Eigen_SReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }





        public static SingleC operator /(SingleC x, dynamic y)
        {
            return x / scplx.t(y);
        }

        public static SingleC operator /(dynamic x, SingleC y)
        {
            return scplx.t(x) / y;
        }


        public static SingleC operator /(SingleC x, Single y)
        {
            var res = new SingleC();
            Lib_SCplx_Div_SReal(res.mpPtr, x.mpPtr, ref y);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Div_SReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Div_SReal(IntPtr res, IntPtr x, ref Single y);


        public static SingleC operator /(SingleC x, SingleC y)
        {
            var res = new SingleC();
            Lib_SCplx_Div(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Div(IntPtr res, IntPtr x, IntPtr y);





        #endregion



    }






    public class scplx
    {


        public static String fmt(SingleC x)
        {
            string s = " " + x.ToString();
            return s;
        }


        public static String fmt(Single x)
        {
            return sreal.fmt(x);
        }


        public static String fmt(dynamic x)
        {
            return fmt(t(x));
        }



        #region General

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/name/*' />
        public static String name
        {
            get { return "scplx"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  scplx"; }
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



        /// <summary>
        /// Returns a new SingleC using a general object as input
        /// </summary>
        public static SingleC t(dynamic z)
        {
            // MsgBox(y_.GetType().ToString())
            // MsgBox(y_.ToString())
            // MsgBox(y_.real.ToString())
            string s_re = z.real.ToString();
            string s_im = z.imag.ToString();
            return scplx.t(sreal.t(s_re), sreal.t(s_im));
        }





        /// <summary>
        /// Returns a new SingleC using an Octuple as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static SingleC t(Octuple x)
        {
            return scplx.t(sreal.t(x));
        }



        /// <summary>
        /// Returns a new SingleC using a Quadruple as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static SingleC t(Quadruple x)
        {
            return scplx.t(sreal.t(x));
        }



        /// <summary>
        /// Returns a new SingleC using an Extended as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static SingleC t(Extended x)
        {
            return scplx.t(sreal.t(x));
        }



        /// <summary>
        /// Returns a new SingleC using a Double (System.Double) for the real part; the imaginary part is set to zero.
        /// </summary>
        public static SingleC t(Double x)
        {
            return scplx.t(sreal.t(x));
        }


        /// <summary>
        /// Returns a new SingleC using a Single (System.Single)  as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static SingleC t(Single x)
        {
            var res = new SingleC();
            Lib_SCplx_Set_Real(res.mpPtr, ref x);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Set_Real", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Set_Real(IntPtr res, ref Single x);





        /// <summary>
        /// Returns a new SingleC using a signed 32 bit integer (System.Int32) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static SingleC t(Int32 x)
        {
            return scplx.t(sreal.t(x));
        }


        /// <summary>
        /// Returns a new SingleC using an an unsigned 32 bit integer (System.UInt32) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static SingleC t(UInt32 x)
        {
            return scplx.t(sreal.t(x));
        }


        /// <summary>
        /// Returns a new SingleC using a signed 64 bit integer (System.Int64) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static SingleC t(Int64 x)
        {
            return scplx.t(sreal.t(x));
        }


        /// <summary>
        /// Returns a new SingleC using an unsigned 64 bit integer (System.UInt64) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static SingleC t(UInt64 x)
        {
            return scplx.t(sreal.t(x));
        }


        /// <summary>
        /// Returns a new SingleC using a BigInteger (System.Numerics.BigInteger) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static SingleC t(BigInteger x)
        {
            return scplx.t(sreal.t(x));
        }



        /// <summary>
        /// Returns a new SingleC using a Decimal (System.Decimal) for the real part; the imaginary part is set to zero.
        /// </summary>
        public static SingleC t(decimal x)
        {
            return scplx.t(sreal.t(x));
        }



        /// <summary>
        /// Returns a new SingleC using a string (System.String) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static SingleC t(string s)
        {
            return scplx.t(sreal.t(s));
        }



        /// <summary>
        /// Returns a new SingleC using 2 Singles as input for the real and imaginary part
        /// </summary>
        public static SingleC t(Single re, Single im)
        {
            var res = new SingleC();
            Lib_SCplx_Set2(res.mpPtr, ref re, ref im);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Set2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Set2(IntPtr res, ref Single re, ref Single im);







        /// <summary>
        /// Returns a new SingleC using a OctupleC as input
        /// </summary>
        public static SingleC t(OctupleC z)
        {
            return scplx.t(sreal.t(z.real), sreal.t(z.imag));
        }



        /// <summary>
        /// Returns a new SingleC using a QuadrupleC as input
        /// </summary>
        public static SingleC t(QuadrupleC z)
        {
            return scplx.t(sreal.t(z.real), sreal.t(z.imag));
        }



        /// <summary>
        /// Returns a new SingleC using an ExtendedC as input
        /// </summary>
        public static SingleC t(ExtendedC z)
        {
            return scplx.t(sreal.t(z.real), sreal.t(z.imag));
        }



        /// <summary>
        /// Returns a new SingleC using a complex Double precision binary floating point number (System.Complex) as input
        /// </summary>
        public static SingleC t(Complex z)
        {
            return scplx.t(sreal.t(z.Real), sreal.t(z.Imaginary));
        }



        /// <summary>
        /// Returns a new SingleC using a complex single precision binary floating point number as input
        /// </summary>
        public static SingleC t(SingleC z)
        {
            return +z;
        }





        /// <summary>
        /// Returns a new SingleC using 2 Double as input for the real and imaginary part
        /// </summary>
        public static SingleC t(Double d_re, Double d_im)
        {
            return scplx.t(sreal.t(d_re), sreal.t(d_im));
        }


        /// <summary>
        /// Returns a new SingleC using 2 strings as input for the real and imaginary part
        /// </summary>
        public static SingleC t(string s_re, string s_im)
        {
            return scplx.t(sreal.t(s_re), sreal.t(s_im));
        }


        #endregion



        #region Linspace, SCplxMatTFunc






        #endregion



        #region Basic Arithmetic and Comparisons




        public static SingleC add(SingleC x, SingleC y)
        {
            return x + y;
        }
        public static SingleC add(dynamic x, dynamic y)
        {
            return t(x) + t(y);
        }

        public static void rawadd(SingleC res, SingleC x, SingleC y)
        {
            Lib_SCplx_Add(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Add(IntPtr res, IntPtr x, IntPtr y);



        public static SingleC subtract(SingleC x, SingleC y)
        {
            return x - y;
        }
        public static SingleC subtract(dynamic x, dynamic y)
        {
            return t(x) - t(y);
        }

        public static void rawsub(SingleC res, SingleC x, SingleC y)
        {
            Lib_SCplx_Sub(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Sub(IntPtr res, IntPtr x, IntPtr y);



        public static SingleC multiply(SingleC x, SingleC y)
        {
            return x * y;
        }
        public static SingleC multiply(dynamic x, dynamic y)
        {
            return t(x) * t(y);
        }

        public static void rawmul(SingleC res, SingleC x, SingleC y)
        {
            Lib_SCplx_Mul(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Mul", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Mul(IntPtr res, IntPtr x, IntPtr y);



        public static SingleC divide(SingleC x, SingleC y)
        {
            return x / y;
        }
        public static SingleC divide(dynamic x, dynamic y)
        {
            return t(x) / t(y);
        }

        public static void rawdiv(SingleC res, SingleC x, SingleC y)
        {
            Lib_SCplx_Div(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Div(IntPtr res, IntPtr x, IntPtr y);




        public static bool Cmp(SingleC x, SingleC y)
        {
            return true;
        }

        public static bool CmpAbs(SingleC x, SingleC y)
        {
            return true;
        }






        #endregion



        #region Machine constants and properties of numbers


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isreal/*' />
        public static bool isreal(SingleC z)
        {
            return (z.imag == sreal.t(0.0f));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/iszero/*' />
        public static bool iszero(SingleC z)
        {
            return (z.real == sreal.t(0.0f)) && (z.imag == sreal.t(0.0f));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isone/*' />
        public static bool isone(SingleC z)
        {
            return (z.real == sreal.t(1.0f)) && (z.imag == sreal.t(0.0f));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isinf/*' />
        public static bool isinf(SingleC z)
        {
            return (sreal.isinf(z.real)) || (sreal.isinf(z.imag));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnan/*' />
        public static bool isnan(SingleC z)
        {
            return (sreal.isnan(z.real)) || (sreal.isnan(z.imag));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isfinite/*' />
        public static bool isfinite(SingleC z)
        {
            return (sreal.isfinite(z.real)) && (sreal.isfinite(z.imag));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/zero/*' />
        public static SingleC zero()
        {
            return scplx.t(0, 0);
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/one/*' />
        public static SingleC one()
        {
            return scplx.t(1, 0);
        }


        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/ImaginaryOne/*' />
        //public static SingleC ImaginaryOne()
        //{
        //    return scplx.t(0, 1);
        //}


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/onej/*' />
        public static SingleC onej()
        {
            return scplx.t(0, 1);
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/nan/*' />
        public static SingleC nan()
        {
            return scplx.t(sreal.nan(), sreal.nan());
        }



        #endregion






        #region Complex components


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Single abs(SingleC z)
        {
            Single res = 0.0f;
            Lib_SCplx_Abs(ref res, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Abs", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Abs(ref Single res, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Single abs(dynamic z)
        {
            return abs(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Single fabs(SingleC z)
        {
            Single res = 0.0f;
            Lib_SCplx_Abs(ref res, z.mpPtr);
            return res;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Single fabs(dynamic z)
        {
            return fabs(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static SingleC sign(SingleC z)
        {
            if (iszero(z)) return zero();
            else return z / abs(z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static SingleC sign(dynamic z)
        {
            return sign(t(z));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Single real(SingleC z)
        {
            return z.real;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Single real(dynamic z)
        {
            return real(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Single imag(SingleC z)
        {
            return z.imag;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Single imag(dynamic z)
        {
            return imag(t(z));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Single phase(SingleC z)
        {
            Single res = 0.0f;
            Lib_SCplx_Arg(ref res, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Arg", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Arg(ref Single res, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Single phase(dynamic z)
        {
            return phase(t(z));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static SingleC conj(SingleC z)
        {
            var res = new SingleC();
            Lib_SCplx_Conj(res.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Conj", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Conj(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static SingleC conj(dynamic z)
        {
            return conj(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Single, Single> polar(SingleC x)
        {
            return new Tuple<Single, Single>(abs(x), phase(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Single, Single> polar(dynamic x)
        {
            return polar(scplx.t(x));
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
        public static SingleC sqrt(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Sqrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Sqrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Sqrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static SingleC sqrt(dynamic x)
        {
            return sqrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static SingleC sqrt1pm1(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Sqrt1pm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Sqrt1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Sqrt1pm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static SingleC sqrt1pm1(dynamic x)
        {
            return sqrt1pm1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static SingleC rsqrt(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Rsqrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Rsqrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Rsqrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static SingleC rsqrt(dynamic x)
        {
            return rsqrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static SingleC cbrt(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Cbrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Cbrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Cbrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static SingleC cbrt(dynamic x)
        {
            return cbrt(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static SingleC unitroot(Int32 k)
        {
            SingleC ks = scplx.t(k);
            return scplx.pow(one(), one() / ks);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static SingleC unitroot(dynamic x)
        {
            return unitroot(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static SingleC root_si(SingleC x, Int32 k)
        {
            var res = new SingleC();
            Lib_SCplx_Root_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Root_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Root_Si(IntPtr res, IntPtr x, Int32 k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static SingleC root_si(dynamic x, Int32 k)
        {
            return root_si(t(x), k);
        }




        #region poly_equations


        public static SingleC eval_quadratic(SingleC x, SingleC A, SingleC B, SingleC C)
        {
            return (A * x + B) * x + C;
        }

        public static SingleC eval_quadratic(dynamic x, dynamic A, dynamic B, dynamic C)
        {
            return eval_quadratic(scplx.t(x), scplx.t(A), scplx.t(B), scplx.t(C));
        }


        // See also: Press, 3rd edition, page 227
        public static Tuple<SingleC, SingleC> quadratic_equation(SingleC a, SingleC b, SingleC c)
        {
            SingleC x1, x2;
            SingleC D = scplx.sqrt(b * b - 4 * a * c);
            SingleC bStar = scplx.conj(b);
            if ((bStar * D).real < sreal.t(0))
            {
                D = -D;
            }
            SingleC q = -0.5 * (b + D);
            x1 = q / a;
            x2 = c / q;
            return new Tuple<SingleC, SingleC>(x1, x2);
        }
        public static Tuple<SingleC, SingleC> quadratic_equation(dynamic A, dynamic B, dynamic C)
        {
            return scplx.quadratic_equation(scplx.t(A), scplx.t(B), scplx.t(C));
        }





        public static SingleC eval_monic_cubic(SingleC x, SingleC a, SingleC b, SingleC c)
        {
            return ((x + a) * x + b) * x + c;
        }

        public static SingleC eval_monic_cubic(dynamic x, dynamic a, dynamic b, dynamic c)
        {
            return eval_monic_cubic(scplx.t(x), scplx.t(a), scplx.t(b), scplx.t(c));
        }


        // See also: Press, 3rd edition, page 228
        public static Tuple<SingleC, SingleC, SingleC> cubic_equation_monic(SingleC a, SingleC b, SingleC c)
        {
            SingleC x1, x2, x3;
            SingleC Q = (a * a - 3 * b) / 9;
            SingleC R = (2 * a * a * a - 9 * a * b + 27 * c) / 54;
            Single Qr = Q.real;
            Single Rr = R.real;
            if ((Q.imag == sreal.t(0.0)) && (R.imag == sreal.t(0.0)) && (Rr * Rr < Qr * Qr * Qr))
            {
                Console.WriteLine("In scplx real Case");
                Single SqrtQr = sreal.sqrt(Qr);
                Single theta = sreal.acos(Rr / (SqrtQr * SqrtQr * SqrtQr));
                x1 = -2 * SqrtQr * sreal.cos((theta) / 3) - a / 3;
                x2 = -2 * SqrtQr * sreal.cos((theta + 2 * sreal.pi()) / 3) - a / 3;
                x3 = -2 * SqrtQr * sreal.cos((theta - 2 * sreal.pi()) / 3) - a / 3;
            }
            else
            {
                Console.WriteLine("In scplx SingleC Case");
                SingleC D = scplx.sqrt(R * R - Q * Q * Q);
                SingleC RStar = scplx.conj(R);
                if ((RStar * D).real < sreal.t(0))
                {
                    D = -D;
                }
                SingleC A = -scplx.cbrt(R + D);
                SingleC B = scplx.zero();
                if (A != scplx.zero())
                {
                    B = Q / A;
                }
                Console.WriteLine("A: {0}", A);
                Console.WriteLine("B: {0}", B);

                x1 = (A + B) - a / 3;
                x2 = -0.5 * (A + B) - a / 3 + 0.5 * scplx.onej() * sreal.sqrt(3) * (A - B);
                x3 = -0.5 * (A + B) - a / 3 - 0.5 * scplx.onej() * sreal.sqrt(3) * (A - B);
            }
            return new Tuple<SingleC, SingleC, SingleC>(x1, x2, x3);
        }
        public static Tuple<SingleC, SingleC, SingleC> cubic_equation_monic(dynamic a, dynamic b, dynamic c)
        {
            return cubic_equation_monic(scplx.t(a), scplx.t(b), scplx.t(c));
        }





        public static SingleC eval_cubic(SingleC x, SingleC A, SingleC B, SingleC C, SingleC D)
        {
            return ((A * x + B) * x + C) * x + D;
        }

        public static SingleC eval_cubic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return eval_cubic(scplx.t(x), scplx.t(A), scplx.t(B), scplx.t(C), scplx.t(D));
        }


        public static Tuple<SingleC, SingleC, SingleC> cubic_equation(SingleC A, SingleC B, SingleC C, SingleC D)
        {
            return cubic_equation_monic(B / A, C / A, D / A);
        }
        public static Tuple<SingleC, SingleC, SingleC> cubic_equation(dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return cubic_equation(scplx.t(A), scplx.t(B), scplx.t(C), scplx.t(D));
        }





        public static SingleC eval_quartic(SingleC x, SingleC A, SingleC B, SingleC C, SingleC D, SingleC E)
        {
            return (((A * x + B) * x + C) * x + D) * x + E;
        }

        public static SingleC eval_quartic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return eval_quartic(scplx.t(x), scplx.t(A), scplx.t(B), scplx.t(C), scplx.t(D), scplx.t(E));
        }


        // See also: https://en.wikipedia.org/wiki/Quartic_equation#Summary_of_Ferrari's_method
        public static Tuple<SingleC, SingleC, SingleC, SingleC> quartic_equation(SingleC A, SingleC B, SingleC C, SingleC D, SingleC E)
        {
            SingleC x1, x2, x3, x4;
            SingleC a = -(3 * B * B) / (8 * A * A) + C / A;
            SingleC b = (B * B * B) / (8 * A * A * A) - (B * C) / (2 * A * A) + D / A;
            SingleC c = -(3 * B * B * B * B) / (256 * A * A * A * A) + (C * B * B) / (16 * A * A * A) - (B * D) / (4 * A * A) + E / A;
            SingleC V = -B / (4 * A);

            if (scplx.iszero(b))
            {
                SingleC W = scplx.sqrt(a * a - 4 * c);
                SingleC Z1 = scplx.sqrt((-a + W) / 2);
                SingleC Z2 = scplx.sqrt((-a - W) / 2);
                x1 = V + Z1;
                x2 = V - Z1;
                x3 = V + Z2;
                x4 = V - Z2;
            }
            else
            {
                SingleC e = 5 * a / 2;
                SingleC f = 2 * a * a - c;
                SingleC g = a * a * a / 2 - a * c / 2 - b * b / 8;
                var res = cubic_equation_monic(e, f, g);
                SingleC y = res.Item1;
                SingleC W = scplx.sqrt(a + 2 * y);
                SingleC Z1 = scplx.sqrt(-(3 * a + 2 * y + 2 * b / W));
                SingleC Z2 = scplx.sqrt(-(3 * a + 2 * y - 2 * b / W));
                x1 = V + (W + Z1) / 2;
                x2 = V + (W - Z1) / 2;
                x3 = V - (W + Z2) / 2;
                x4 = V - (W - Z2) / 2;
            }
            return new Tuple<SingleC, SingleC, SingleC, SingleC>(x1, x2, x3, x4);
        }

        public static Tuple<SingleC, SingleC, SingleC, SingleC> quartic_equation(dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return quartic_equation(scplx.t(A), scplx.t(B), scplx.t(C), scplx.t(D), scplx.t(E));
        }


        #endregion



        #endregion



        #region Exponential and related functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static SingleC exp(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Exp(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Exp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Exp(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static SingleC exp(dynamic x)
        {
            return exp(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static SingleC expj(SingleC x)
        {
            return cos(x) + onej() * sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static SingleC expj(dynamic x)
        {
            return expj(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static SingleC expjpi(SingleC x)
        {
            return cospi(x) + onej() * sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static SingleC expjpi(dynamic x)
        {
            return expjpi(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static SingleC exp2(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Exp2(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Exp2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Exp2(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static SingleC exp2(dynamic x)
        {
            return exp2(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static SingleC exp10(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Exp10(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Exp10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Exp10(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static SingleC exp10(dynamic x)
        {
            return exp10(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static SingleC expm1(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Expm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Expm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Expm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static SingleC expm1(dynamic x)
        {
            return expm1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static SingleC exp2m1(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Exp2m1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Exp2m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Exp2m1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static SingleC exp2m1(dynamic x)
        {
            return exp2m1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static SingleC exp10m1(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Exp10m1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Exp10m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Exp10m1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static SingleC exp10m1(dynamic x)
        {
            return exp2m1(t(x));
        }








        #endregion



        #region Logarithms and related functions




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static SingleC log(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Log(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Log", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Log(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static SingleC log(dynamic x)
        {
            return log(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static SingleC log2(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Log2(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Log2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Log2(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static SingleC log2(dynamic x)
        {
            return log2(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static SingleC log10(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Log10(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Log10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Log10(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static SingleC log10(dynamic x)
        {
            return log10(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static SingleC log1p(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Log1p(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Log1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Log1p(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static SingleC log1p(dynamic x)
        {
            return log1p(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static SingleC log2p1(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Log2p1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Log2p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Log2p1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static SingleC log2p1(dynamic x)
        {
            return log2p1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static SingleC log10p1(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Log10p1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Log10p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Log10p1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static SingleC log10p1(dynamic x)
        {
            return log10p1(t(x));
        }






        #endregion



        #region Power functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static SingleC sqr(SingleC x)
        {
            return x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static SingleC sqr(dynamic x)
        {
            return sqr(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static SingleC cube(SingleC x)
        {
            return x * x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static SingleC cube(dynamic x)
        {
            return cube(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static SingleC hypot(SingleC x, SingleC y)
        {
            return sqrt(x * x + y * y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static SingleC hypot(dynamic x, dynamic y)
        {
            return hypot(t(x), t(y));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static SingleC pow(SingleC x, SingleC y)
        {
            var res = new SingleC();
            Lib_SCplx_Pow(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Pow", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Pow(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static SingleC pow(dynamic x, dynamic y)
        {
            return pow(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static SingleC powm1(SingleC x, SingleC y)
        {
            var res = new SingleC();
            Lib_SCplx_Powm1(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Powm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Powm1(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static SingleC powm1(dynamic x, dynamic y)
        {
            return powm1(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static SingleC pow1p(SingleC x, SingleC y)
        {
            var res = new SingleC();
            Lib_SCplx_Pow1p(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Pow1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Pow1p(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static SingleC pow1p(dynamic x, dynamic y)
        {
            return pow1p(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static SingleC pow1pm1(SingleC x, SingleC y)
        {
            var res = new SingleC();
            Lib_SCplx_Pow1pm1(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Pow1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Pow1pm1(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static SingleC pow1pm1(dynamic x, dynamic y)
        {
            return pow1pm1(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static SingleC pow_si(SingleC x, Int32 k)
        {
            var res = new SingleC();
            Lib_SCplx_Pow_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Pow_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Pow_Si(IntPtr res, IntPtr x, Int32 k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static SingleC pow_si(dynamic x, Int32 k)
        {
            return pow_si(t(x), k);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static SingleC compound_si(SingleC x, Int32 k)
        {
            var res = new SingleC();
            Lib_SCplx_Compound_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Compound_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Compound_Si(IntPtr res, IntPtr x, Int32 k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static SingleC compound_si(dynamic x, Int32 k)
        {
            return compound_si(t(x), k);
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static SingleC sin(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Sin(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Sin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Sin(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static SingleC sin(dynamic x)
        {
            return sin(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static SingleC cos(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Cos(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Cos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Cos(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static SingleC cos(dynamic x)
        {
            return cos(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static SingleC tan(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Tan(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Tan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Tan(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static SingleC tan(dynamic x)
        {
            return tan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static SingleC csc(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Csc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Csc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Csc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static SingleC csc(dynamic x)
        {
            return csc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static SingleC sec(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Sec(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Sec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Sec(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static SingleC sec(dynamic x)
        {
            return sec(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static SingleC cot(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Cot(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Cot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Cot(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static SingleC cot(dynamic x)
        {
            return cot(t(x));
        }


        public static Tuple<Single, Single> divmod(Single a, Single b)
        {
            Single r = sreal.fmod(a, b);
            Single q = (a - r) / b;
            return new Tuple<Single, Single>(q, r);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinpi/*' />
        public static SingleC sinpi(SingleC x)
        {
            if (x.real < 0) return -sinpi(-x);
            var n_r = divmod(x.real, 0.5f);
            x = scplx.t(n_r.Item2, x.imag) * sreal.pi();
            Int32 n = sreal.lrint(sreal.fmod(n_r.Item1, 4));
            if (n == 0) return scplx.sin(x);
            else if (n == 1) return scplx.cos(x);
            else if (n == 2) return -scplx.sin(x);
            else return -scplx.cos(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinpi/*' />
        public static SingleC sinpi(dynamic x)
        {
            return sinpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static SingleC cospi(SingleC x)
        {
            if (x.real < 0) x = -x;
            var n_r = divmod(x.real, 0.5f);
            x = scplx.t(n_r.Item2, x.imag) * sreal.pi();
            Int32 n = sreal.lrint(sreal.fmod(n_r.Item1, 4));
            if (n == 0) return scplx.cos(x);
            else if (n == 1) return -scplx.sin(x);
            else if (n == 2) return -scplx.cos(x);
            else return scplx.sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static SingleC cospi(dynamic x)
        {
            return cospi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static SingleC tanpi(SingleC x)
        {
            return scplx.sinpi(x) / scplx.cospi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static SingleC tanpi(dynamic x)
        {
            return tanpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static SingleC cscpi(SingleC x)
        {
            return 1.0 / scplx.sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static SingleC cscpi(dynamic x)
        {
            return cscpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static SingleC secpi(SingleC x)
        {
            return 1.0 / scplx.cospi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static SingleC secpi(dynamic x)
        {
            return secpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cotpi/*' />
        public static SingleC cotpi(SingleC x)
        {
            return scplx.cospi(x) / scplx.sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cotpi/*' />
        public static SingleC cotpi(dynamic x)
        {
            return cotpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinc/*' />
        public static SingleC sinc(SingleC x)
        {
            if (scplx.iszero(x)) return scplx.t(1, 0);
            else return dcplx.sin(x) / (x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinc/*' />
        public static SingleC sinc(dynamic x)
        {
            return sinc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static SingleC sincpi(SingleC x)
        {
            if (scplx.iszero(x)) return scplx.t(1, 0);
            else return dcplx.sinpi(x) / (x * sreal.pi());
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static SingleC sincpi(dynamic x)
        {
            return sincpi(t(x));
        }








        #endregion



        #region Hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static SingleC sinh(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Sinh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Sinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Sinh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static SingleC sinh(dynamic x)
        {
            return sinh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static SingleC cosh(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Cosh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Cosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Cosh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static SingleC cosh(dynamic x)
        {
            return cosh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static SingleC tanh(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Tanh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Tanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Tanh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static SingleC tanh(dynamic x)
        {
            return tanh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static SingleC csch(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Csch(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Csch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Csch(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static SingleC csch(dynamic x)
        {
            return csch(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static SingleC sech(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Sech(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Sech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Sech(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static SingleC sech(dynamic x)
        {
            return sech(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static SingleC coth(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Coth(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Coth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Coth(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static SingleC coth(dynamic x)
        {
            return coth(t(x));
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static SingleC asin(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Asin(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Asin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Asin(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static SingleC asin(dynamic x)
        {
            return asin(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static SingleC acos(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Acos(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Acos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Acos(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static SingleC acos(dynamic x)
        {
            return acos(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static SingleC atan(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Atan(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Atan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Atan(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static SingleC atan(dynamic x)
        {
            return atan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static SingleC acsc(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Acsc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Acsc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Acsc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static SingleC acsc(dynamic x)
        {
            return acsc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static SingleC asec(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Asec(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Asec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Asec(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static SingleC asec(dynamic x)
        {
            return asec(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static SingleC acot(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Acot(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Acot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Acot(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static SingleC acot(dynamic x)
        {
            return acot(t(x));
        }




        #endregion



        #region Inverse hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static SingleC asinh(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Asinh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Asinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Asinh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static SingleC asinh(dynamic x)
        {
            return asinh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static SingleC acosh(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Acosh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Acosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Acosh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static SingleC acosh(dynamic x)
        {
            return acosh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static SingleC atanh(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Atanh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Atanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Atanh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static SingleC atanh(dynamic x)
        {
            return atanh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static SingleC acsch(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Acsch(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Acsch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Acsch(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static SingleC acsch(dynamic x)
        {
            return acsch(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static SingleC asech(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Asech(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Asech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Asech(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static SingleC asech(dynamic x)
        {
            return asech(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static SingleC acoth(SingleC x)
        {
            var res = new SingleC();
            Lib_SCplx_Acoth(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_SCplx_Acoth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_SCplx_Acoth(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static SingleC acoth(dynamic x)
        {
            return acoth(t(x));
        }




        #endregion


        #region Matrix Creation



        public static SingleMatC mat_t(SingleC x)
        {
            var matA = new SingleMatC();
            matA[0, 0] = x;
            return matA;
        }


        public static SingleMatC mat_t(SingleMat matA)
        {
            var x = mat_zeros(matA.rows, matA.cols);
            Lib_Eigen_SReal_ConvertRealCplx(matA.mpPtr, constants.mp_conv_set_to_complex_dbl, x.mpPtr);
            return x;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_SReal_ConvertRealCplx", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_SReal_ConvertRealCplx(IntPtr RMat, int what, IntPtr CMat);


        /// <summary>
        /// Makes a deep copy from a complex matrix of type YCplxMatT
        /// </summary>
        public static SingleMatC mat_t(SingleMatC matA)
        {
            var matX = mat_zeros(matA.rows, matA.cols);
            matX = +matA;
            return matX;
        }


        public static SingleMatC mat_zeros(int n, int m)
        {
            var resout = new SingleMatC();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setZero, n, m);
            return resout;
        }

        /* *********************** */

        public static SingleMatC mat_cplx_t(SingleMatC matA)
        {
            return mat_t(matA);
        }


        public static SingleMatC mat_cplx_zeros(int n, int m)
        {
            return mat_zeros(n, m);
        }

        /* *********************** */



        public static SingleMatC mat_ones(int n, int m)
        {
            var resout = new SingleMatC();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setOnes, n, m);
            return resout;
        }



        public static SingleMatC mat_identity(int n, int m)
        {
            var resout = new SingleMatC();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setIdentity, n, m);
            return resout;
        }



        public static SingleMatC mat_random(int n, int m)
        {
            var resout = new SingleMatC();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandom_nm, n, m);
            return resout;
        }



        public static SingleMatC mat_random_symmetric(int n)
        {
            var resout = new SingleMatC();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSymmetric, n, n);
            return resout;
        }



        public static SingleMatC mat_random_selfadjoint(int n)
        {
            var resout = new SingleMatC();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSA, n, n);
            return resout;
        }



        public static SingleMatC mat_random_selfadjoint_posdef(int n)
        {
            var resout = new SingleMatC();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSAPosDef, n, n);
            return resout;
        }



        public static SingleMatC mat_fill_linear(int n, int m)
        {
            var resout = new SingleMatC();
            slib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_FillLinear, n, m);
            return resout;
        }



        #endregion




    }









}




