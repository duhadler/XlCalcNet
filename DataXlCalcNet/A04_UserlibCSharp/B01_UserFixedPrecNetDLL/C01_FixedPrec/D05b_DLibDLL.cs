/* C# */


#define UsingDouble

#region Usings
using System;
using System.Diagnostics;
using FixedPrecNet;
using System.Numerics;


//using Ctx = FixedPrecNet.sreal;
//using CtxScalar = System.Single;
//using cb1SCtx1S =  FixedPrecNet.cb1SSingle1S;

using Ctx = FixedPrecNet.dreal;
using CtxScalar = System.Double;
using cb1SCtx1S =  FixedPrecNet.cb1SDouble1S;

//using Ctx = FixedPrecNet.ereal;
//using CtxScalar = FixedPrecNet.Extended;
//using cb1SCtx1S =  FixedPrecNet.cb1SExtended1S;

//using Ctx = FixedPrecNet.qreal;
//using CtxScalar = FixedPrecNet.Quadruple;
//using cb1SCtx1S =  FixedPrecNet.cb1SQuadruple1S;

//using Ctx = FixedPrecNet.oreal;
//using CtxScalar = FixedPrecNet.Octuple;
//using cb1SCtx1S =  FixedPrecNet.cb1SOctuple1S;

//#if HasArbPrecNet
//using Ctx = ArbPrecNet.mreal;
//using CtxScalar = ArbPrecNet.Mpfr;
//using cb1SCtx1S =  FixedPrecNet.cb1SMpfr1S;
//#endif
#endregion


namespace UserFixedPrecNet
{

    /// <summary>
    /// User defined functions based on the Double data type
    /// </summary>
    public partial class dlib
    {



#region Boost MCP



        internal static CtxScalar chidens(CtxScalar x, CtxScalar n)
        {
            CtxScalar t1 = Ctx.pow(n, n / 2) * Ctx.pow(x, n - 1) * Ctx.exp(-n * x * x / 2);
            CtxScalar t2 = Ctx.pow(2, (n - 1) / 2) * Ctx.real_gamma(n / 2);
            CtxScalar res = t1 / t2;
            res = res * Ctx.sqrt(2);
            return res;
        }





        public static CtxScalar nmax_pdf(CtxScalar x, int k)
        {
            CtxScalar res = k * Ctx.pow(Ctx.ndis(x), (k - 1)) * Ctx.ndens(x);
            return res;
        }


        public static CtxScalar nmax_cdf(CtxScalar x, int k)
        {
            CtxScalar res = Ctx.pow(Ctx.ndis(x), k);
            return res;
        }



        public static CtxScalar nmm_pdf(CtxScalar x, int k)
        {
            CtxScalar res = 2*k * Ctx.pow(2*Ctx.ndis(x)-1, (k - 1)) * Ctx.ndens(x);
            return res;
        }


        public static CtxScalar nmm_cdf(CtxScalar x, int k)
        {
            CtxScalar res = Ctx.pow(Ctx.ndis(x) - Ctx.ndis(-x), k);
            return res;
        }



        public static CtxScalar nmax_corr_pdf(CtxScalar x, int k, CtxScalar rho)
        {
            //cb1SCtx1S F2 = CtxScalar (CtxScalar y) =>
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar a1 = y * Ctx.sqrt(rho);
                CtxScalar b1 = Ctx.sqrt(1 - rho);
                CtxScalar z1 = (x + a1) / b1;
                CtxScalar d = Ctx.ndis(z1);
                d = Ctx.pow(d, k - 1);
                CtxScalar res = (k / b1) * d * Ctx.ndens(z1) * Ctx.ndens(y);
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: -Ctx.inf(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }



        public static CtxScalar nmax_corr_cdf(CtxScalar x, int k, CtxScalar rho)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar a = y * Ctx.sqrt(rho);
                CtxScalar b = Ctx.sqrt(1 - rho);
                CtxScalar z1 = (x + a) / b;
                CtxScalar d = Ctx.ndis(z1);
                d = Ctx.pow(d, k);
                CtxScalar res = d * Ctx.ndens(y);
                return res;
            };
            var cdf = Ctx.TanhSinh(F2, a: -Ctx.inf(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //Console.WriteLine("pdf (integral, error, cond.no., level): {0}", cdf);
            return cdf.Item1;
        }


#if UsingDouble
        public static CtxScalar nmax_neg_corr_cdf(CtxScalar x, int k, CtxScalar rho)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                Complex a = y * cmath53.sqrt(rho);
                CtxScalar b = Ctx.sqrt(1 - rho);
                Complex z1 = (x + a) / b;
                Complex d = FixedPrecNet.cmath53.ndis(z1);
                //Console.WriteLine("z1: {0}, d: {1}", z1, d);
                d = FixedPrecNet.dcplx.pow(d, k);
                CtxScalar res = d.Real * Ctx.ndens(y);
                if (Ctx.isnan(res)) res = 0;
                //Console.WriteLine("y: {0}, res: {1}", y, res);
                return res;
            };

            var cdf = Ctx.TanhSinh(F2, a: -Ctx.inf(), b: Ctx.inf(), tol: Ctx.t(0.0));
            Console.WriteLine("cdf (integral, error, cond.no., level): {0}", cdf);
            return cdf.Item1;
        }



        public static CtxScalar nmm_neg_corr_cdf(CtxScalar x, int k, CtxScalar rho)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                Complex a = y * cmath53.sqrt(rho);
                CtxScalar b = Ctx.sqrt(1 - rho);
                Complex z1 = (x + a) / b;
                Complex z2 = (-x + a) / b;
                Complex d = cmath53.ndis(z1) - cmath53.ndis(z2);
                //Console.WriteLine("z1: {0}, z2: {1}, d: {2}", z1, z2, d);
                d = dcplx.pow(d, k);
                CtxScalar res = d.Real * Ctx.ndens(y);
                if (Ctx.isnan(res)) res = 0;
                //Console.WriteLine("y: {0}, res: {1}", y, res);
                return res;
            };

            var cdf = Ctx.TanhSinh(F2, a: -Ctx.inf(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //Console.WriteLine("cdf (integral, error, cond.no., level): {0}", cdf);
            return cdf.Item1;
        }
#endif


        public static CtxScalar nmm_corr_pdf(CtxScalar x, int k, CtxScalar rho)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar a = y * Ctx.sqrt(rho);
                CtxScalar b = Ctx.sqrt(1 - rho);
                CtxScalar z1 = (x + a) / b;
                CtxScalar z2 = (-x + a) / b;
                CtxScalar d = Ctx.ndis(z1) - Ctx.ndis(z2);
                d = Ctx.pow(d, k - 1);
                CtxScalar res = (k / b) * d * (Ctx.ndens(z1) + Ctx.ndens(z2)) * Ctx.ndens(y);
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: -Ctx.inf(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }



        public static CtxScalar nmm_corr_cdf(CtxScalar x, int k, CtxScalar rho)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar a = y * Ctx.sqrt(rho);
                CtxScalar b = Ctx.sqrt(1 - rho);
                CtxScalar z1 = (x + a) / b;
                CtxScalar z2 = (-x + a) / b;
                CtxScalar d = Ctx.ndis(z1) - Ctx.ndis(z2);
                d = Ctx.pow(d, k);
                CtxScalar res = d * Ctx.ndens(y);
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: -Ctx.inf(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }




        public static CtxScalar nrange_pdf(CtxScalar x, int k)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar d1 = Ctx.ndis(y);
                CtxScalar d2 = Ctx.ndis(y - x); ;
                CtxScalar d = k * (k - 1) * Ctx.pow(d1 - d2, k - 2);
                CtxScalar res = d * Ctx.ndens(y) * Ctx.ndens(y - x);
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: -Ctx.inf(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }



        public static CtxScalar nrange_cdf(CtxScalar x, int k)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar d1 = Ctx.ndis(y);
                CtxScalar d2 = Ctx.ndis(y - x); ;
                CtxScalar d = k * Ctx.pow(d1 - d2, k - 1);
                CtxScalar res = d * Ctx.ndens(y);
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: -Ctx.inf(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }



        public static CtxScalar smax_pdf(CtxScalar x, int k, CtxScalar n)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar res = nmax_pdf(x * y, k) * chidens(y, n) * y;
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: Ctx.zero(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }



        public static CtxScalar smax_cdf(CtxScalar x, int k, CtxScalar n)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar res = nmax_cdf(x * y, k) * chidens(y, n);
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: Ctx.zero(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }



        public static CtxScalar smm_pdf(CtxScalar x, int k, CtxScalar n)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar res = nmm_pdf(x * y, k) * chidens(y, n) * y;
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: Ctx.zero(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }



        public static CtxScalar smm_cdf(CtxScalar x, int k, CtxScalar n)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar res = nmm_cdf(x * y, k) * chidens(y, n);
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: Ctx.zero(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }




        public static CtxScalar dunnett1_pdf(CtxScalar x, int k, CtxScalar n, CtxScalar rho)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar res = nmax_corr_pdf(x * y, k, rho) * chidens(y, n) * y;
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: Ctx.zero(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //var pdf = Ctx.TanhSinh(F2, a: Ctx.zero(), b: Ctx.inf(), tol: Ctx.t(1.0E-2));
            Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }



        public static CtxScalar dunnett1_cdf(CtxScalar x, int k, CtxScalar n, CtxScalar rho)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar res = nmax_corr_cdf(x * y, k, rho) * chidens(y, n);
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: Ctx.zero(), b: Ctx.inf(), tol: Ctx.t(0.0));
            Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }




        public static CtxScalar dunnett2_pdf(CtxScalar x, int k, CtxScalar n, CtxScalar rho)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar res = nmm_corr_pdf(x * y, k, rho) * chidens(y, n) * y;
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: Ctx.zero(), b: Ctx.inf(), tol: Ctx.t(0.0));
            Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }



        public static CtxScalar dunnett2_cdf(CtxScalar x, int k, CtxScalar n, CtxScalar rho)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar res = nmm_corr_cdf(x * y, k, rho) * chidens(y, n);
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: Ctx.zero(), b: Ctx.inf(), tol: Ctx.t(0.0));
            Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }


        public static CtxScalar studentized_range_pdf(CtxScalar x, int k, CtxScalar n)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar res = nrange_pdf(x * y, k) * chidens(y, n) * y;
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: Ctx.zero(), b: Ctx.inf(), tol: Ctx.t(0.0));
            Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }



        public static CtxScalar studentized_range_cdf(CtxScalar x, int k, CtxScalar n)
        {
            cb1SCtx1S F2 = (CtxScalar y) =>
            {
                CtxScalar res = nrange_cdf(x * y, k) * chidens(y, n);
                return res;
            };
            var pdf = Ctx.TanhSinh(F2, a: Ctx.zero(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //Console.WriteLine("pdf (integral, error, cond.no., level): {0}", pdf);
            return pdf.Item1;
        }






#endregion





    }
}




/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion





