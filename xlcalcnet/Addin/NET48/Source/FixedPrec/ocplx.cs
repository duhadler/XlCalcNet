using System;
using System.Runtime.InteropServices;
using System.Numerics;


namespace FixedPrecNet
{



    public partial class OctupleC
    {

        public static string name()
        {
            return "OctupleC";
        }

        #region Init


        public IntPtr mpPtr = IntPtr.Zero;


        private void Init()
        {
            xcn.Init();
            mpPtr = Lib_OCplx_Init_Func();
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Init_Func", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr Lib_OCplx_Init_Func();


        ~OctupleC()
        {
            Lib_OCplx_Clear(mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Clear", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Clear(IntPtr x);

        #endregion



        #region Conversions


        public OctupleC()
        {
            Init();
        }


        public Octuple real
        {
            get
            {
                var res = new Octuple();
                Lib_OCplx_Real(res.mpPtr, mpPtr);
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Real", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Real(IntPtr res, IntPtr z);


        public Octuple imag
        {
            get
            {
                var res = new Octuple();
                Lib_OCplx_Imag(res.mpPtr, mpPtr);
                return res;
            }
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Imag", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Imag(IntPtr res, IntPtr z);




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
            return "OctupleC('" + ToString() + "')";
        }


        #endregion




        #region Arithmetic operators


        public static bool operator ==(dynamic x, OctupleC y)
        {
            return ocplx.t(x) == y;
        }

        public static bool operator ==(OctupleC x, dynamic y)
        {
            return x == ocplx.t(y);
        }


        public static bool operator !=(dynamic x, OctupleC y)
        {
            return ocplx.t(x) != y;
        }

        public static bool operator !=(OctupleC x, dynamic y)
        {
            return x != ocplx.t(y);
        }





        public static bool operator ==(OctupleC x, OctupleC y)
        {
            return x.real == y.real & x.imag == y.imag;
        }

        public static bool operator !=(OctupleC x, OctupleC y)
        {
            return x.real != y.real | x.imag != y.imag;
        }




        public static OctupleC operator +(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Set(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Set", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Set(IntPtr res, IntPtr a);


        public static OctupleC operator -(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Neg(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Neg", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Neg(IntPtr res, IntPtr x);









        public static OctupleC operator +(OctupleC x, dynamic y)
        {
            return x + ocplx.t(y);
        }

        public static OctupleC operator +(dynamic x, OctupleC y)
        {
            return ocplx.t(x) + y;
        }


        public static OctupleC operator +(OctupleC x, OctupleC y)
        {
            var res = new OctupleC();
            Lib_OCplx_Add(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Add(IntPtr res, IntPtr x, IntPtr y);


        public static OctupleC operator +(OctupleC x, Octuple y)
        {
            var res = new OctupleC();
            Lib_OCplx_Add_OReal(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Add_OReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Add_OReal(IntPtr res, IntPtr x, IntPtr y);


        public static OctupleMatC operator +(OctupleC m2, OctupleMat M1)
        {
            var Res = new OctupleMatC();
            olib.Lib_Eigen_OReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, m2.real.mpPtr, m2.imag.mpPtr);
            return Res;
        }


        public static OctupleMatC operator +(OctupleC m2, OctupleMatC M1)
        {
            var Res = new OctupleMatC();
            var t = ocplx.mat_t(m2);
            olib.Lib_Eigen_OReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_plus_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }





        public static OctupleC operator -(OctupleC x, dynamic y)
        {
            return x - ocplx.t(y);
        }

        public static OctupleC operator -(dynamic x, OctupleC y)
        {
            return ocplx.t(x) - y;
        }

        public static OctupleC operator -(OctupleC x, Octuple y)
        {
            var res = new OctupleC();
            Lib_OCplx_Sub_OReal(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Sub_OReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Sub_OReal(IntPtr res, IntPtr x, IntPtr y);


        public static OctupleC operator -(OctupleC x, OctupleC y)
        {
            var res = new OctupleC();
            Lib_OCplx_Sub(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Sub(IntPtr res, IntPtr x, IntPtr y);


        public static OctupleMatC operator -(OctupleC m2, OctupleMat M1)
        {
            var Res = new OctupleMatC();
            olib.Lib_Eigen_OReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_minus_scalar, M1.mpPtr, m2.real.mpPtr, m2.imag.mpPtr);
            return -Res;
        }


        public static OctupleMatC operator -(OctupleC m2, OctupleMatC M1)
        {
            var Res = new OctupleMatC();
            var t = ocplx.mat_t(m2);
            olib.Lib_Eigen_OReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_minus, M1.mpPtr, t.mpPtr);
            return -Res;
        }








        public static OctupleC operator *(OctupleC x, dynamic y)
        {
            return x * ocplx.t(y);
        }

        public static OctupleC operator *(dynamic x, OctupleC y)
        {
            return ocplx.t(x) * y;
        }


        public static OctupleC operator *(OctupleC x, Octuple y)
        {
            var res = new OctupleC();
            Lib_OCplx_Mul_OReal(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Mul_OReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Mul_OReal(IntPtr res, IntPtr x, IntPtr y);


        public static OctupleC operator *(OctupleC x, OctupleC y)
        {
            var res = new OctupleC();
            Lib_OCplx_Mul(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Mul", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Mul(IntPtr res, IntPtr x, IntPtr y);


        public static OctupleMatC operator *(OctupleC m2, OctupleMat M1)
        {
            var Res = new OctupleMatC();
            olib.Lib_Eigen_OReal_Real_CplxScalarArithmetic(Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, m2.real.mpPtr, m2.imag.mpPtr);
            return Res;
        }


        public static OctupleMatC operator *(OctupleC m2, OctupleMatC M1)
        {
            var Res = new OctupleMatC();
            var t = ocplx.mat_t(m2);
            olib.Lib_Eigen_OReal_BasicArithmetic(constants.mp_eigen, constants.mp_cplx, Res.mpPtr, constants.mp_const_times_scalar, M1.mpPtr, t.mpPtr);
            return Res;
        }







        public static OctupleC operator /(OctupleC x, dynamic y)
        {
            return x / ocplx.t(y);
        }

        public static OctupleC operator /(dynamic x, OctupleC y)
        {
            return ocplx.t(x) / y;
        }


        public static OctupleC operator /(OctupleC x, Octuple y)
        {
            var res = new OctupleC();
            Lib_OCplx_Div_OReal(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Div_OReal", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Div_OReal(IntPtr res, IntPtr x, IntPtr y);


        public static OctupleC operator /(OctupleC x, OctupleC y)
        {
            var res = new OctupleC();
            Lib_OCplx_Div(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Div(IntPtr res, IntPtr x, IntPtr y);






        #endregion

    }









    public partial class ocplx
    {

        public static String fmt(OctupleC z)
        {
            string s1 = z.real.ToString();
            string s2 = z.imag.ToString();
            string s = " " + "(" + s1 + ", " + s2 + ")";
            return s;
        }

        public static String fmt(Octuple x)
        {
            return oreal.fmt(x);
        }


        public static String fmt(dynamic z)
        {
            return fmt(t(z));
        }



        #region General

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/name/*' />
        public static String name
        {
            get { return "ocplx"; }
        }

        /// <include file="docs.xml" path='docs/members[@name="Contexts"]/fmtname/*' />
        public static String fmtname
        {
            get { return "  ocplx"; }
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



        /// <summary>
        /// Returns a new OctupleC using a dynamic (an object whose operations will be resolved at runtime) as input
        /// </summary>
        public static OctupleC t(dynamic z)
        {
            // MsgBox(y_.GetType().ToString())
            // MsgBox(y_.ToString())
            // MsgBox(y_.real.ToString())
            string s_re = z.real.ToString();
            string s_im = z.imag.ToString();
            return ocplx.t(oreal.t(s_re), oreal.t(s_im));
        }



        /// <summary>
        /// Returns a new OctupleC using an Octuple as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static OctupleC t(Octuple x)
        {
            var res = new OctupleC();
            Lib_OCplx_Set_Real(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Set_Real", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Set_Real(IntPtr res, IntPtr x);





        /// <summary>
        /// Returns a new OctupleC using a Quadruple as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static OctupleC t(Quadruple x)
        {
            return ocplx.t(oreal.t(x));
        }



        /// <summary>
        /// Returns a new OctupleC using an Extended as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static OctupleC t(Extended x)
        {
            return ocplx.t(oreal.t(x));
        }



        /// <summary>
        /// Returns a new OctupleC using a Double (System.Double) for the real part; the imaginary part is set to zero.
        /// </summary>
        public static OctupleC t(Double x)
        {
            return ocplx.t(oreal.t(x));
        }



        /// <summary>
        /// Returns a new OctupleC using a Single (System.Single)  as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static OctupleC t(Single x)
        {
            return ocplx.t(oreal.t(x));
        }



        /// <summary>
        /// Returns a new OctupleC using a signed 32 bit integer (System.Int32) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static OctupleC t(Int32 x)
        {
            return ocplx.t(oreal.t(x));
        }


        /// <summary>
        /// Returns a new OctupleC using an unsigned 32 bit integer (System.UInt32) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static OctupleC t(UInt32 x)
        {
            return ocplx.t(oreal.t(x));
        }


        /// <summary>
        /// Returns a new OctupleC using a signed 64 bit integer (System.Int64) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static OctupleC t(Int64 x)
        {
            return ocplx.t(oreal.t(x));
        }


        /// <summary>
        /// Returns a new OctupleC using an unsigned 64 bit integer (System.UInt64) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static OctupleC t(UInt64 x)
        {
            return ocplx.t(oreal.t(x));
        }



        /// <summary>
        /// Returns a new Extended using a decimal number (System.Decimal) as input
        /// </summary>
        public static OctupleC t(decimal x)
        {
            return ocplx.t(oreal.t(x));
        }

        

        /// <summary>
        /// Returns a new OctupleC using a BigInteger (System.Numerics.BigInteger) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static OctupleC t(BigInteger x)
        {
            return ocplx.t(oreal.t(x));
        }


        /// <summary>
        /// Returns a new OctupleC using a string (System.String) as input for the real part; the imaginary part is set to zero.
        /// </summary>
        public static OctupleC t(string s)
        {
            return ocplx.t(oreal.t(s));
        }



        /// <summary>
        /// Returns a new OctupleC using 2 Octuples as input for the real and imaginary part
        /// </summary>
        public static OctupleC t(Octuple re, Octuple im)
        {
            var res = new OctupleC();
            Lib_OCplx_Set2(res.mpPtr, re.mpPtr, im.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Set2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Set2(IntPtr res, IntPtr re, IntPtr im);




        /// <summary>
        /// Returns a new OctupleC using a OctupleC as input
        /// </summary>
        public static OctupleC t(OctupleC z)
        {
            return +z;
        }




        /// <summary>
        /// Returns a new OctupleC using a QuadrupleC as input
        /// </summary>
        public static OctupleC t(QuadrupleC z)
        {
            return ocplx.t(oreal.t(z.real), oreal.t(z.imag));
        }



        /// <summary>
        /// Returns a new OctupleC using an ExtendedC as input
        /// </summary>
        public static OctupleC t(ExtendedC z)
        {
            return ocplx.t(oreal.t(z.real), oreal.t(z.imag));
        }



        /// <summary>
        /// Returns a new OctupleC using a Complex (System.Numerics.Complex) as input
        /// </summary>
        public static OctupleC t(Complex z)
        {
            return ocplx.t(oreal.t(z.Real), oreal.t(z.Imaginary));
        }





        /// <summary>
        /// Returns a new OctupleC using a SingleC as input
        /// </summary>
        public static OctupleC t(SingleC z)
        {
            return ocplx.t(oreal.t(z.real), oreal.t(z.imag));
        }



        /// <summary>
        /// Returns a new OctupleC using 2 Doubles (System.Double) as input for the real and imaginary part
        /// </summary>
        public static OctupleC t(Double d_re, Double d_im)
        {
            return ocplx.t(oreal.t(d_re), oreal.t(d_im));
        }


        /// <summary>
        /// Returns a new OctupleC using 2 strings (System.String) as input for the real and imaginary part
        /// </summary>
        public static OctupleC t(string s_re, string s_im)
        {
            return ocplx.t(oreal.t(s_re), oreal.t(s_im));
        }


        #endregion



        #region Linspace, OCplxMatTFunc




        #endregion



        #region Basic Arithmetic and Comparisons



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/add/*' />
        public static OctupleC add(OctupleC x, OctupleC y)
        {
            return x + y;
        }
        public static OctupleC add(dynamic x, dynamic y)
        {
            return t(x) + t(y);
        }

        public static void rawadd(OctupleC res, OctupleC x, OctupleC y)
        {
            Lib_OCplx_Add(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Add", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Add(IntPtr res, IntPtr x, IntPtr y);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/subtract/*' />
        public static OctupleC subtract(OctupleC x, OctupleC y)
        {
            return x - y;
        }
        public static OctupleC subtract(dynamic x, dynamic y)
        {
            return t(x) - t(y);
        }

        public static void rawsub(OctupleC res, OctupleC x, OctupleC y)
        {
            Lib_OCplx_Sub(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Sub", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Sub(IntPtr res, IntPtr x, IntPtr y);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/multiply/*' />
        public static OctupleC multiply(OctupleC x, OctupleC y)
        {
            return x * y;
        }
        public static OctupleC multiply(dynamic x, dynamic y)
        {
            return t(x) * t(y);
        }

        public static void rawmul(OctupleC res, OctupleC x, OctupleC y)
        {
            Lib_OCplx_Mul(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Mul", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Mul(IntPtr res, IntPtr x, IntPtr y);



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/divide/*' />
        public static OctupleC divide(OctupleC x, OctupleC y)
        {
            return x / y;
        }
        public static OctupleC divide(dynamic x, dynamic y)
        {
            return t(x) / t(y);
        }

        public static void rawdiv(OctupleC res, OctupleC x, OctupleC y)
        {
            Lib_OCplx_Div(res.mpPtr, x.mpPtr, y.mpPtr);
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Div", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Div(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/Cmp/*' />
        public static bool Cmp(OctupleC x, OctupleC y)
        {
            return true;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/CmpAbs/*' />
        public static bool CmpAbs(OctupleC x, OctupleC y)
        {
            return true;
        }




        #endregion



        #region Machine constants and properties of numbers


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isreal/*' />
        public static bool isreal(OctupleC z)
        {
            return (z.imag == oreal.t(0.0d));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/iszero/*' />
        public static bool iszero(OctupleC z)
        {
            return (z.real == oreal.t(0.0d)) && (z.imag == oreal.t(0.0d));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isone/*' />
        public static bool isone(OctupleC z)
        {
            return (z.real == oreal.t(1.0d)) && (z.imag == oreal.t(0.0d));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isinf/*' />
        public static bool isinf(OctupleC z)
        {
            return (oreal.isinf(z.real)) || (oreal.isinf(z.imag));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isnan/*' />
        public static bool isnan(OctupleC z)
        {
            return (oreal.isnan(z.real)) || (oreal.isnan(z.imag));
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/isfinite/*' />
        public static bool isfinite(OctupleC z)
        {
            return (oreal.isfinite(z.real)) && (oreal.isfinite(z.imag));
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/zero/*' />
        public static OctupleC zero()
        {
            return ocplx.t(0, 0);
        }


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/one/*' />
        public static OctupleC one()
        {
            return ocplx.t(1, 0);
        }




        ///// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/ImaginaryOne/*' />
        //public static OctupleC ImaginaryOne()
        //{
        //    return ocplx.t(0, 1);
        //}


        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/onej/*' />
        public static OctupleC onej()
        {
            return ocplx.t(0, 1);
        }



        /// <include file="docs.xml" path='docs/members[@name="ConstantsAndProperties"]/nan/*' />
        public static OctupleC nan()
        {
            return ocplx.t(oreal.nan(), oreal.nan());
        }




        #endregion



        #region Complex components



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Octuple abs(OctupleC z)
        {
            var res = new Octuple();
            Lib_OCplx_Abs(res.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Abs", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Abs(IntPtr res, IntPtr z);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/abs/*' />
        public static Octuple abs(dynamic z)
        {
            return abs(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Octuple fabs(OctupleC z)
        {
            var res = new Octuple();
            Lib_OCplx_Abs(res.mpPtr, z.mpPtr);
            return res;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/fabs/*' />
        public static Octuple fabs(dynamic z)
        {
            return fabs(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static OctupleC sign(OctupleC z)
        {
            if (iszero(z)) return zero();
            else return z / abs(z);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sign/*' />
        public static OctupleC sign(dynamic z)
        {
            return sign(t(z));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Octuple real(OctupleC z)
        {
            return z.real;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/real/*' />
        public static Octuple real(dynamic z)
        {
            return real(t(z));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Octuple imag(OctupleC z)
        {
            return z.imag;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/imag/*' />
        public static Octuple imag(dynamic z)
        {
            return imag(t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Octuple phase(OctupleC z)
        {
            return oreal.atan2(z.imag, z.real);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/phase/*' />
        public static Octuple phase(dynamic z)
        {
            return phase(t(z));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static OctupleC conj(OctupleC z)
        {
            var res = new OctupleC();
            Lib_OCplx_Conj(res.mpPtr, z.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Conj", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Conj(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/conj/*' />
        public static OctupleC conj(dynamic z)
        {
            return conj(t(z));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Octuple, Octuple> polar(OctupleC x)
        {
            return new Tuple<Octuple, Octuple>(abs(x), phase(x));
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/polar/*' />
        public static Tuple<Octuple, Octuple> polar(dynamic x)
        {
            return polar(ocplx.t(x));
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
        public static OctupleC sqrt(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Sqrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Sqrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Sqrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static OctupleC sqrt(dynamic x)
        {
            return sqrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static OctupleC sqrt1pm1(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Sqrt1pm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Sqrt1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Sqrt1pm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqrt/*' />
        public static OctupleC sqrt1pm1(dynamic x)
        {
            return sqrt1pm1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static OctupleC rsqrt(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Rsqrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Rsqrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Rsqrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/rsqrt/*' />
        public static OctupleC rsqrt(dynamic x)
        {
            return rsqrt(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static OctupleC cbrt(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Cbrt(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Cbrt", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Cbrt(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cbrt/*' />
        public static OctupleC cbrt(dynamic x)
        {
            return cbrt(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static OctupleC unitroot(Int32 k)
        {
            OctupleC ks = ocplx.t(k);
            return ocplx.pow(one(), one() / ks);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/unitroot/*' />
        public static OctupleC unitroot(dynamic x)
        {
            return unitroot(t(x));
        }




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static OctupleC root_si(OctupleC x, Int32 k)
        {
            var res = new OctupleC();
            Lib_OCplx_Root_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Root_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Root_Si(IntPtr res, IntPtr x, Int32 k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/root_si/*' />
        public static OctupleC root_si(dynamic x, Int32 k)
        {
            return root_si(t(x), k);
        }



        #region poly_equations

        public static OctupleC eval_quadratic(OctupleC x, OctupleC A, OctupleC B, OctupleC C)
        {
            return (A * x + B) * x + C;
        }

        public static OctupleC eval_quadratic(dynamic x, dynamic A, dynamic B, dynamic C)
        {
            return eval_quadratic(ocplx.t(x), ocplx.t(A), ocplx.t(B), ocplx.t(C));
        }


        // See also: Press, 3rd edition, page 227
        public static Tuple<OctupleC, OctupleC> quadratic_equation(OctupleC a, OctupleC b, OctupleC c)
        {
            OctupleC x1, x2;
            OctupleC D = ocplx.sqrt(b * b - 4 * a * c);
            OctupleC bStar = ocplx.conj(b);
            if ((bStar * D).real < oreal.t(0))
            {
                D = -D;
            }
            OctupleC q = -0.5 * (b + D);
            x1 = q / a;
            x2 = c / q;
            return new Tuple<OctupleC, OctupleC>(x1, x2);
        }
        public static Tuple<OctupleC, OctupleC> quadratic_equation(dynamic A, dynamic B, dynamic C)
        {
            return quadratic_equation(ocplx.t(A), ocplx.t(B), ocplx.t(C));
        }




        public static OctupleC eval_monic_cubic(OctupleC x, OctupleC a, OctupleC b, OctupleC c)
        {
            return ((x + a) * x + b) * x + c;
        }

        public static OctupleC eval_monic_cubic(dynamic x, dynamic a, dynamic b, dynamic c)
        {
            return eval_monic_cubic(ocplx.t(x), ocplx.t(a), ocplx.t(b), ocplx.t(c));
        }


        // See also: Press, 3rd edition, page 228
        public static Tuple<OctupleC, OctupleC, OctupleC> cubic_equation_monic(OctupleC a, OctupleC b, OctupleC c)
        {
            OctupleC x1, x2, x3;
            OctupleC Q = (a * a - 3 * b) / 9;
            OctupleC R = (2 * a * a * a - 9 * a * b + 27 * c) / 54;
            Octuple Qr = Q.real;
            Octuple Rr = R.real;
            if ((Q.imag == oreal.t(0.0)) && (R.imag == oreal.t(0.0)) && (Rr * Rr < Qr * Qr * Qr))
            {
                Console.WriteLine("In ocplx real Case");
                Octuple SqrtQr = oreal.sqrt(Qr);
                Octuple theta = oreal.acos(Rr / (SqrtQr * SqrtQr * SqrtQr));
                x1 = -2 * SqrtQr * oreal.cos((theta) / 3) - a / 3;
                x2 = -2 * SqrtQr * oreal.cos((theta + 2 * oreal.pi()) / 3) - a / 3;
                x3 = -2 * SqrtQr * oreal.cos((theta - 2 * oreal.pi()) / 3) - a / 3;
            }
            else
            {
                Console.WriteLine("In ocplx OctupleC Case");
                OctupleC D = ocplx.sqrt(R * R - Q * Q * Q);
                OctupleC RStar = ocplx.conj(R);
                if ((RStar * D).real < oreal.t(0))
                {
                    D = -D;
                }
                OctupleC A = -ocplx.cbrt(R + D);
                OctupleC B = ocplx.zero();
                if (A != ocplx.zero())
                {
                    B = Q / A;
                }
                Console.WriteLine("A: {0}", A);
                Console.WriteLine("B: {0}", B);

                x1 = (A + B) - a / 3;
                x2 = -0.5 * (A + B) - a / 3 + 0.5 * ocplx.onej() * oreal.sqrt(3) * (A - B);
                x3 = -0.5 * (A + B) - a / 3 - 0.5 * ocplx.onej() * oreal.sqrt(3) * (A - B);
            }
            return new Tuple<OctupleC, OctupleC, OctupleC>(x1, x2, x3);
        }
        public static Tuple<OctupleC, OctupleC, OctupleC> cubic_equation_monic(dynamic a, dynamic b, dynamic c)
        {
            return cubic_equation_monic(ocplx.t(a), ocplx.t(b), ocplx.t(c));
        }




        public static OctupleC eval_cubic(OctupleC x, OctupleC A, OctupleC B, OctupleC C, OctupleC D)
        {
            return ((A * x + B) * x + C) * x + D;
        }

        public static OctupleC eval_cubic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return eval_cubic(ocplx.t(x), ocplx.t(A), ocplx.t(B), ocplx.t(C), ocplx.t(D));
        }


        public static Tuple<OctupleC, OctupleC, OctupleC> cubic_equation(OctupleC A, OctupleC B, OctupleC C, OctupleC D)
        {
            return cubic_equation_monic(B / A, C / A, D / A);
        }
        public static Tuple<OctupleC, OctupleC, OctupleC> cubic_equation(dynamic A, dynamic B, dynamic C, dynamic D)
        {
            return cubic_equation(ocplx.t(A), ocplx.t(B), ocplx.t(C), ocplx.t(D));
        }



        public static OctupleC eval_quartic(OctupleC x, OctupleC A, OctupleC B, OctupleC C, OctupleC D, OctupleC E)
        {
            return (((A * x + B) * x + C) * x + D) * x + E;
        }

        public static OctupleC eval_quartic(dynamic x, dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return eval_quartic(ocplx.t(x), ocplx.t(A), ocplx.t(B), ocplx.t(C), ocplx.t(D), ocplx.t(E));
        }


        // See also: https://en.wikipedia.org/wiki/Quartic_equation#Summary_of_Ferrari's_method
        public static Tuple<OctupleC, OctupleC, OctupleC, OctupleC> quartic_equation(OctupleC A, OctupleC B, OctupleC C, OctupleC D, OctupleC E)
        {
            OctupleC x1, x2, x3, x4;
            OctupleC a = -(3 * B * B) / (8 * A * A) + C / A;
            OctupleC b = (B * B * B) / (8 * A * A * A) - (B * C) / (2 * A * A) + D / A;
            OctupleC c = -(3 * B * B * B * B) / (256 * A * A * A * A) + (C * B * B) / (16 * A * A * A) - (B * D) / (4 * A * A) + E / A;
            OctupleC V = -B / (4 * A);

            if (ocplx.iszero(b))
            {
                OctupleC W = ocplx.sqrt(a * a - 4 * c);
                OctupleC Z1 = ocplx.sqrt((-a + W) / 2);
                OctupleC Z2 = ocplx.sqrt((-a - W) / 2);
                x1 = V + Z1;
                x2 = V - Z1;
                x3 = V + Z2;
                x4 = V - Z2;
            }
            else
            {
                OctupleC e = 5 * a / 2;
                OctupleC f = 2 * a * a - c;
                OctupleC g = a * a * a / 2 - a * c / 2 - b * b / 8;
                var res = cubic_equation_monic(e, f, g);
                OctupleC y = res.Item1;
                OctupleC W = ocplx.sqrt(a + 2 * y);
                OctupleC Z1 = ocplx.sqrt(-(3 * a + 2 * y + 2 * b / W));
                OctupleC Z2 = ocplx.sqrt(-(3 * a + 2 * y - 2 * b / W));
                x1 = V + (W + Z1) / 2;
                x2 = V + (W - Z1) / 2;
                x3 = V - (W + Z2) / 2;
                x4 = V - (W - Z2) / 2;
            }
            return new Tuple<OctupleC, OctupleC, OctupleC, OctupleC>(x1, x2, x3, x4);
        }

        public static Tuple<OctupleC, OctupleC, OctupleC, OctupleC> quartic_equation(dynamic A, dynamic B, dynamic C, dynamic D, dynamic E)
        {
            return quartic_equation(ocplx.t(A), ocplx.t(B), ocplx.t(C), ocplx.t(D), ocplx.t(E));
        }

        #endregion








        #endregion



        #region Exponential and related functions



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static OctupleC exp(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Exp(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Exp", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Exp(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp/*' />
        public static OctupleC exp(dynamic x)
        {
            return exp(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static OctupleC expj(OctupleC x)
        {
            return cos(x) + onej() * sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expj/*' />
        public static OctupleC expj(dynamic x)
        {
            return expj(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static OctupleC expjpi(OctupleC x)
        {
            return cospi(x) + onej() * sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expjpi/*' />
        public static OctupleC expjpi(dynamic x)
        {
            return expjpi(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static OctupleC exp2(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Exp2(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Exp2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Exp2(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2/*' />
        public static OctupleC exp2(dynamic x)
        {
            return exp2(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static OctupleC exp10(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Exp10(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Exp10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Exp10(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10/*' />
        public static OctupleC exp10(dynamic x)
        {
            return exp10(t(x));
        }





        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static OctupleC expm1(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Expm1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Expm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Expm1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/expm1/*' />
        public static OctupleC expm1(dynamic x)
        {
            return expm1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static OctupleC exp2m1(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Exp2m1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Exp2m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Exp2m1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp2m1/*' />
        public static OctupleC exp2m1(dynamic x)
        {
            return exp2m1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static OctupleC exp10m1(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Exp10m1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Exp10m1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Exp10m1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/exp10m1/*' />
        public static OctupleC exp10m1(dynamic x)
        {
            return exp2m1(t(x));
        }








        #endregion



        #region Logarithms and related functions




        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static OctupleC log(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Log(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Log", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Log(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log/*' />
        public static OctupleC log(dynamic x)
        {
            return log(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static OctupleC log2(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Log2(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Log2", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Log2(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2/*' />
        public static OctupleC log2(dynamic x)
        {
            return log2(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static OctupleC log10(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Log10(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Log10", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Log10(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10/*' />
        public static OctupleC log10(dynamic x)
        {
            return log10(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static OctupleC log1p(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Log1p(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Log1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Log1p(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log1p/*' />
        public static OctupleC log1p(dynamic x)
        {
            return log1p(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static OctupleC log2p1(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Log2p1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Log2p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Log2p1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log2p1/*' />
        public static OctupleC log2p1(dynamic x)
        {
            return log2p1(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static OctupleC log10p1(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Log10p1(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Log10p1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Log10p1(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/log10p1/*' />
        public static OctupleC log10p1(dynamic x)
        {
            return log10p1(t(x));
        }






        #endregion



        #region Power functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static OctupleC sqr(OctupleC x)
        {
            return x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sqr/*' />
        public static OctupleC sqr(dynamic x)
        {
            return sqr(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static OctupleC cube(OctupleC x)
        {
            return x * x * x;
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cube/*' />
        public static OctupleC cube(dynamic x)
        {
            return cube(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static OctupleC hypot(OctupleC x, OctupleC y)
        {
            return sqrt(x * x + y * y);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/hypot/*' />
        public static OctupleC hypot(dynamic x, dynamic y)
        {
            return hypot(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static OctupleC pow(OctupleC x, OctupleC y)
        {
            var res = new OctupleC();
            Lib_OCplx_Pow(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Pow", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Pow(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow/*' />
        public static OctupleC pow(dynamic x, dynamic y)
        {
            return pow(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static OctupleC powm1(OctupleC x, OctupleC y)
        {
            var res = new OctupleC();
            Lib_OCplx_Powm1(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Powm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Powm1(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/powm1/*' />
        public static OctupleC powm1(dynamic x, dynamic y)
        {
            return powm1(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static OctupleC pow1p(OctupleC x, OctupleC y)
        {
            var res = new OctupleC();
            Lib_OCplx_Pow1p(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Pow1p", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Pow1p(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1p/*' />
        public static OctupleC pow1p(dynamic x, dynamic y)
        {
            return pow1p(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static OctupleC pow1pm1(OctupleC x, OctupleC y)
        {
            var res = new OctupleC();
            Lib_OCplx_Pow1pm1(res.mpPtr, x.mpPtr, y.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Pow1pm1", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Pow1pm1(IntPtr res, IntPtr x, IntPtr y);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow1pm1/*' />
        public static OctupleC pow1pm1(dynamic x, dynamic y)
        {
            return pow1pm1(t(x), t(y));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static OctupleC pow_si(OctupleC x, Int32 k)
        {
            var res = new OctupleC();
            Lib_OCplx_Pow_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Pow_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Pow_Si(IntPtr res, IntPtr x, Int32 k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/pow_si/*' />
        public static OctupleC pow_si(dynamic x, Int32 k)
        {
            return pow_si(t(x), k);
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static OctupleC compound_si(OctupleC x, Int32 k)
        {
            var res = new OctupleC();
            Lib_OCplx_Compound_Si(res.mpPtr, x.mpPtr, k);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Compound_Si", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Compound_Si(IntPtr res, IntPtr x, Int32 k);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/compound_si/*' />
        public static OctupleC compound_si(dynamic x, Int32 k)
        {
            return compound_si(t(x), k);
        }





        #endregion



        #region Trigonometric and related functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static OctupleC sin(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Sin(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Sin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Sin(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sin/*' />
        public static OctupleC sin(dynamic x)
        {
            return sin(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static OctupleC cos(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Cos(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Cos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Cos(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cos/*' />
        public static OctupleC cos(dynamic x)
        {
            return cos(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static OctupleC tan(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Tan(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Tan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Tan(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tan/*' />
        public static OctupleC tan(dynamic x)
        {
            return tan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static OctupleC csc(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Csc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Csc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Csc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csc/*' />
        public static OctupleC csc(dynamic x)
        {
            return csc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static OctupleC sec(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Sec(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Sec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Sec(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sec/*' />
        public static OctupleC sec(dynamic x)
        {
            return sec(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static OctupleC cot(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Cot(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Cot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Cot(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cot/*' />
        public static OctupleC cot(dynamic x)
        {
            return cot(t(x));
        }


        public static Tuple<Octuple, Octuple> divmod(Octuple a, Octuple b)
        {
            Octuple r = oreal.fmod(a, b);
            Octuple q = (a - r) / b;
            return new Tuple<Octuple, Octuple>(q, r);
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinpi/*' />
        public static OctupleC sinpi(OctupleC x)
        {
            if (x.real < 0) return -sinpi(-x);
            var n_r = divmod(x.real, oreal.t(0.5));
            x = ocplx.t(n_r.Item2, x.imag) * oreal.pi();
            Int32 n = oreal.lrint(oreal.fmod(n_r.Item1, 4));
            if (n == 0) return ocplx.sin(x);
            else if (n == 1) return ocplx.cos(x);
            else if (n == 2) return -ocplx.sin(x);
            else return -ocplx.cos(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinpi/*' />
        public static OctupleC sinpi(dynamic x)
        {
            return sinpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static OctupleC cospi(OctupleC x)
        {
            if (x.real < 0) x = -x;
            var n_r = divmod(x.real, oreal.t(0.5));
            x = ocplx.t(n_r.Item2, x.imag) * oreal.pi();
            Int32 n = oreal.lrint(oreal.fmod(n_r.Item1, 4));
            if (n == 0) return ocplx.cos(x);
            else if (n == 1) return -ocplx.sin(x);
            else if (n == 2) return -ocplx.cos(x);
            else return ocplx.sin(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cospi/*' />
        public static OctupleC cospi(dynamic x)
        {
            return cospi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static OctupleC tanpi(OctupleC x)
        {
            return ocplx.sinpi(x) / ocplx.cospi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanpi/*' />
        public static OctupleC tanpi(dynamic x)
        {
            return tanpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static OctupleC cscpi(OctupleC x)
        {
            return 1.0 / ocplx.sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cscpi/*' />
        public static OctupleC cscpi(dynamic x)
        {
            return cscpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static OctupleC secpi(OctupleC x)
        {
            return 1.0 / ocplx.cospi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/secpi/*' />
        public static OctupleC secpi(dynamic x)
        {
            return secpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cotpi/*' />
        public static OctupleC cotpi(OctupleC x)
        {
            return ocplx.cospi(x) / ocplx.sinpi(x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cotpi/*' />
        public static OctupleC cotpi(dynamic x)
        {
            return cotpi(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinc/*' />
        public static OctupleC sinc(OctupleC x)
        {
            if (ocplx.iszero(x)) return ocplx.t(1, 0);
            else return ocplx.sin(x) / (x);
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinc/*' />
        public static OctupleC sinc(dynamic x)
        {
            return sinc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static OctupleC sincpi(OctupleC x)
        {
            if (ocplx.iszero(x)) return ocplx.t(1, 0);
            else return ocplx.sinpi(x) / (x * oreal.pi());
        }

        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sincpi/*' />
        public static OctupleC sincpi(dynamic x)
        {
            return sincpi(t(x));
        }







        #endregion



        #region Hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static OctupleC sinh(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Sinh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Sinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Sinh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sinh/*' />
        public static OctupleC sinh(dynamic x)
        {
            return sinh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static OctupleC cosh(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Cosh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Cosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Cosh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/cosh/*' />
        public static OctupleC cosh(dynamic x)
        {
            return cosh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static OctupleC tanh(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Tanh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Tanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Tanh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/tanh/*' />
        public static OctupleC tanh(dynamic x)
        {
            return tanh(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static OctupleC csch(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Csch(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Csch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Csch(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/csch/*' />
        public static OctupleC csch(dynamic x)
        {
            return csch(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static OctupleC sech(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Sech(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Sech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Sech(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/sech/*' />
        public static OctupleC sech(dynamic x)
        {
            return sech(t(x));
        }


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static OctupleC coth(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Coth(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Coth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Coth(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/coth/*' />
        public static OctupleC coth(dynamic x)
        {
            return coth(t(x));
        }




        #endregion



        #region Inverse trigonometric functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static OctupleC asin(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Asin(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Asin", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Asin(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asin/*' />
        public static OctupleC asin(dynamic x)
        {
            return asin(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static OctupleC acos(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Acos(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Acos", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Acos(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acos/*' />
        public static OctupleC acos(dynamic x)
        {
            return acos(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static OctupleC atan(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Atan(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Atan", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Atan(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atan/*' />
        public static OctupleC atan(dynamic x)
        {
            return atan(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static OctupleC acsc(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Acsc(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Acsc", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Acsc(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsc/*' />
        public static OctupleC acsc(dynamic x)
        {
            return acsc(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static OctupleC asec(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Asec(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Asec", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Asec(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asec/*' />
        public static OctupleC asec(dynamic x)
        {
            return asec(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static OctupleC acot(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Acot(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Acot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Acot(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acot/*' />
        public static OctupleC acot(dynamic x)
        {
            return acot(t(x));
        }




        #endregion



        #region Inverse hyperbolic functions


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static OctupleC asinh(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Asinh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Asinh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Asinh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asinh/*' />
        public static OctupleC asinh(dynamic x)
        {
            return asinh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static OctupleC acosh(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Acosh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Acosh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Acosh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acosh/*' />
        public static OctupleC acosh(dynamic x)
        {
            return acosh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static OctupleC atanh(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Atanh(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Atanh", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Atanh(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/atanh/*' />
        public static OctupleC atanh(dynamic x)
        {
            return atanh(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static OctupleC acsch(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Acsch(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Acsch", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Acsch(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acsch/*' />
        public static OctupleC acsch(dynamic x)
        {
            return acsch(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static OctupleC asech(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Asech(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Asech", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Asech(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/asech/*' />
        public static OctupleC asech(dynamic x)
        {
            return asech(t(x));
        }



        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static OctupleC acoth(OctupleC x)
        {
            var res = new OctupleC();
            Lib_OCplx_Acoth(res.mpPtr, x.mpPtr);
            return res;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_OCplx_Acoth", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_OCplx_Acoth(IntPtr res, IntPtr x);


        /// <include file="docs.xml" path='docs/members[@name="ScalarAndArrayFunctions"]/acoth/*' />
        public static OctupleC acoth(dynamic x)
        {
            return acoth(t(x));
        }




        #endregion





        #region Matrix Creation



        public static OctupleMatC mat_t(OctupleC x)
        {
            var matA = new OctupleMatC();
            matA[0, 0] = x;
            return matA;
        }


        public static OctupleMatC mat_t(OctupleMat matA)
        {
            var x = mat_zeros(matA.rows, matA.cols);
            Lib_Eigen_OReal_ConvertRealCplx(matA.mpPtr, constants.mp_conv_set_to_complex_dbl, x.mpPtr);
            return x;
        }
        [DllImport(xcn.mpNum, EntryPoint = "Lib_Eigen_OReal_ConvertRealCplx", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Lib_Eigen_OReal_ConvertRealCplx(IntPtr RMat, int what, IntPtr CMat);


        /// <summary>
        /// Makes a deep copy from a complex matrix of type YCplxMatT
        /// </summary>
        public static OctupleMatC mat_t(OctupleMatC matA)
        {
            var matX = mat_zeros(matA.rows, matA.cols);
            matX = +matA;
            return matX;
        }

        public static OctupleMatC mat_zeros(int n, int m)
        {
            var resout = new OctupleMatC();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setZero, n, m);
            return resout;
        }

        /* *********************** */

        public static OctupleMatC mat_cplx_t(OctupleMatC matA)
        {
            return mat_t(matA);
        }


        public static OctupleMatC mat_cplx_zeros(int n, int m)
        {
            return mat_zeros(n, m);
        }

        /* *********************** */






        public static OctupleMatC mat_ones(int n, int m)
        {
            var resout = new OctupleMatC();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setOnes, n, m);
            return resout;
        }



        public static OctupleMatC mat_identity(int n, int m)
        {
            var resout = new OctupleMatC();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setIdentity, n, m);
            return resout;
        }



        public static OctupleMatC mat_random(int n, int m)
        {
            var resout = new OctupleMatC();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandom_nm, n, m);
            return resout;
        }



        public static OctupleMatC mat_random_symmetric(int n)
        {
            var resout = new OctupleMatC();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSymmetric, n, n);
            return resout;
        }



        public static OctupleMatC mat_random_selfadjoint(int n)
        {
            var resout = new OctupleMatC();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSA, n, n);
            return resout;
        }



        public static OctupleMatC mat_random_selfadjoint_posdef(int n)
        {
            var resout = new OctupleMatC();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_setRandomSAPosDef, n, n);
            return resout;
        }



        public static OctupleMatC mat_fill_linear(int n, int m)
        {
            var resout = new OctupleMatC();
            olib.Call_Eigen_SetSpecialValue(constants.mp_eigen, constants.mp_cplx, resout, constants.mp_FillLinear, n, m);
            return resout;
        }



        #endregion






    }








}