using System;
using System.Diagnostics;
using FixedPrecNet;
using System.Numerics;



#if HasArbPrecNet
using ArbPrecNet;
#endif

//using Ctx = FixedPrecNet.sreal;
//using CtxScalar = System.Single;
//using CtxVec = FixedPrecNet.SingleVec;
//using CtxMat = FixedPrecNet.SingleMat;

using Ctx = FixedPrecNet.dreal;
using CtxScalar = System.Double;
using CtxVec = FixedPrecNet.DoubleVec;
using CtxMat = FixedPrecNet.DoubleMat;
using cb1SCtx1S =  FixedPrecNet.cb1SDouble1S;

//using Ctx = FixedPrecNet.ereal;
//using CtxScalar = FixedPrecNet.Extended;
//using CtxVec = FixedPrecNet.ExtendedVec;
//using CtxMat = FixedPrecNet.ExtendedMat;

//using Ctx = FixedPrecNet.qreal;
//using CtxScalar = FixedPrecNet.Quadruple;
//using CtxVec = FixedPrecNet.QuadrupleVec;
//using CtxMat = FixedPrecNet.QuadrupleMat;

//using Ctx = FixedPrecNet.oreal;
//using CtxScalar = FixedPrecNet.Octuple;
//using CtxVec = FixedPrecNet.OctupleVec;
//using CtxMat = FixedPrecNet.OctupleMat;

//#if HasArbPrecNet
//using Ctx = ArbPrecNet.mreal;
//using CtxScalar = ArbPrecNet.Mpfr;
//using CtxVec = ArbPrecNet.MpfrVec;
//using CtxMat = ArbPrecNet.MpfrMat;
//#endif



namespace TestXlCalcNetPrecCS
{



    static partial class Tests
    {


        public static void RunTestsNumericalCalculus2()
        {
#if HasArbPrecNet
            ArbPrec.SetDps(64);
#endif

            RunTestsMCP();
            //RunTestsCalculus2();
            //RunTestsBoostOdeint2();
            //RunTestsEigenCalculus2();
            //DemoCtxOpt2();
        }



        #region Boost MCP



        internal static CtxScalar chidens(CtxScalar x, CtxScalar n)
        {
            CtxScalar t1 = Ctx.pow(n, n / 2) * Ctx.pow(x, n - 1) * Ctx.exp(-n * x * x / 2);
            CtxScalar t2 = Ctx.pow(2, (n - 1) / 2) * Ctx.gamma(n / 2);
            CtxScalar res = t1 / t2;
            res = res * Ctx.sqrt(2);
            return res;
        }





        internal static CtxScalar nmax_pdf(CtxScalar x, int k)
        {
            CtxScalar res = k * Ctx.pow(Ctx.ndis(x), (k - 1)) * Ctx.ndens(x);
            return res;
        }


        internal static CtxScalar nmax_cdf(CtxScalar x, int k)
        {
            CtxScalar res = Ctx.pow(Ctx.ndis(x), k);
            return res;
        }



        internal static CtxScalar nmm_pdf(CtxScalar x, int k)
        {
            CtxScalar res = 2*k * Ctx.pow(2*Ctx.ndis(x)-1, (k - 1)) * Ctx.ndens(x);
            return res;
        }


        internal static CtxScalar nmm_cdf(CtxScalar x, int k)
        {
            CtxScalar res = Ctx.pow(Ctx.ndis(x) - Ctx.ndis(-x), k);
            return res;
        }



        internal static CtxScalar nmax_corr_pdf(CtxScalar x, int k, CtxScalar rho)
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



        internal static CtxScalar nmax_corr_cdf(CtxScalar x, int k, CtxScalar rho)
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



        internal static CtxScalar nmax_neg_corr_cdf(CtxScalar x, int k, CtxScalar rho)
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

            //var a = Ctx.t(-6.0);
            //var b = Ctx.t(6.0);
            //var tol = Ctx.t(0.0);
            ////var cdf = Ctx.TanhSinh(F2, a, b, tol);
            //var cdf = Ctx.SinhSinh(F2);


            var cdf = Ctx.TanhSinh(F2, a: -Ctx.inf(), b: Ctx.inf(), tol: Ctx.t(0.0));
            Console.WriteLine("cdf (integral, error, cond.no., level): {0}", cdf);
            return cdf.Item1;
        }



        internal static CtxScalar nmm_neg_corr_cdf(CtxScalar x, int k, CtxScalar rho)
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

            //var a = Ctx.t(-6.0);
            //var b = Ctx.t(6.0);
            //var tol = Ctx.t(0.0);
            ////var cdf = Ctx.TanhSinh(F2, a, b, tol);
            //var cdf = Ctx.SinhSinh(F2);


            var cdf = Ctx.TanhSinh(F2, a: -Ctx.inf(), b: Ctx.inf(), tol: Ctx.t(0.0));
            //Console.WriteLine("cdf (integral, error, cond.no., level): {0}", cdf);
            return cdf.Item1;
        }



        internal static CtxScalar nmm_corr_pdf(CtxScalar x, int k, CtxScalar rho)
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



        internal static CtxScalar nmm_corr_cdf(CtxScalar x, int k, CtxScalar rho)
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




        internal static CtxScalar nrange_pdf(CtxScalar x, int k)
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



        internal static CtxScalar nrange_cdf(CtxScalar x, int k)
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



        internal static CtxScalar smax_pdf(CtxScalar x, int k, CtxScalar n)
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



        internal static CtxScalar smax_cdf(CtxScalar x, int k, CtxScalar n)
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



        internal static CtxScalar smm_pdf(CtxScalar x, int k, CtxScalar n)
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



        internal static CtxScalar smm_cdf(CtxScalar x, int k, CtxScalar n)
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




        internal static CtxScalar dunnett1_pdf(CtxScalar x, int k, CtxScalar n, CtxScalar rho)
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



        internal static CtxScalar dunnett1_cdf(CtxScalar x, int k, CtxScalar n, CtxScalar rho)
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




        internal static CtxScalar dunnett2_pdf(CtxScalar x, int k, CtxScalar n, CtxScalar rho)
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



        internal static CtxScalar dunnett2_cdf(CtxScalar x, int k, CtxScalar n, CtxScalar rho)
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


        internal static CtxScalar studentized_range_pdf(CtxScalar x, int k, CtxScalar n)
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



        internal static CtxScalar studentized_range_cdf(CtxScalar x, int k, CtxScalar n)
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







        public static void demo_nmax_pdf_cdf()
        {
            int k = 8;
            CtxScalar x = Ctx.t(2.381);
            Console.WriteLine("demo_nmax_pdf_cdf: " + Ctx.name);
            var pdf = nmax_pdf(x, k);
            Console.WriteLine("pdf : {0}", pdf);
            var cdf = nmax_cdf(x, k);
            Console.WriteLine("cdf : {0}", cdf);
            Console.WriteLine();
        }


        public static void demo_nmm_pdf_cdf()
        {
            int k = 8;
            CtxScalar x = Ctx.t(2.381);
            Console.WriteLine("demo_nmm_pdf_cdf: " + Ctx.name);
            var pdf = nmm_pdf(x, k);
            Console.WriteLine("pdf : {0}", pdf);
            var cdf = nmm_cdf(x, k);
            Console.WriteLine("cdf : {0}", cdf);
            Console.WriteLine();
        }


        public static void demo_nmax_corr_pdf()
        {
            Console.WriteLine("demo_nmax_corr_pdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(2.381);
            CtxScalar rho = Ctx.t(0.5);
            var pdf = nmax_corr_pdf(x, k, rho);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_nmax_corr_cdf()
        {
            Console.WriteLine("demo_nmax_corr_cdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(2.381);
            CtxScalar rho = Ctx.t(0.5);
            var pdf = nmax_corr_cdf(x, k, rho);
            Console.WriteLine("cdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_nmax_neg_corr_cdf()
        {
            Console.WriteLine("demo_nmax_neg_corr_cdf: " + Ctx.name);
            int k = 5;
            CtxScalar x = Ctx.t(2.08);
            CtxScalar rho = -Ctx.t(1) / Ctx.t(k-1);
            var pdf = nmax_neg_corr_cdf(x, k, rho);
            Console.WriteLine("cdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_nmm_neg_corr_cdf()
        {
            Console.WriteLine("demo_nmm_neg_corr_cdf: " + Ctx.name);
            int k = 5;
            CtxScalar x = Ctx.t(2.08);
            CtxScalar rho = -Ctx.t(1) / Ctx.t(k - 1);
            var pdf = nmm_neg_corr_cdf(x, k, rho);
            Console.WriteLine("cdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_nmm_corr_pdf()
        {
            Console.WriteLine("demo_nmm_corr_pdf: " + Ctx.name);
            int k = 6;
            CtxScalar x = Ctx.t(2.567);
            CtxScalar rho = Ctx.t(0.5);
            var pdf = nmm_corr_pdf(x, k, rho);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_nmm_corr_cdf()
        {
            Console.WriteLine("demo_nmm_corr_cdf: " + Ctx.name);
            int k = 6;
            CtxScalar x = Ctx.t(2.567);
            CtxScalar rho = Ctx.t(0.5);
            var pdf = nmm_corr_cdf(x, k, rho);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }



        public static void demo_nrange_pdf()
        {
            Console.WriteLine("demo_nrange_pdf: " + Ctx.name);
            int k = 4;
            CtxScalar x = Ctx.t(3.240);
            var pdf = nrange_pdf(x, k);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_nrange_cdf()
        {
            Console.WriteLine("demo_nrange_cdf: " + Ctx.name);
            int k = 4;
            CtxScalar x = Ctx.t(3.240);
            var pdf = nrange_cdf(x, k);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_smax_pdf()
        {
            Console.WriteLine("demo_smax_pdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(3.444);
            CtxScalar n = Ctx.t(20);
            var pdf = smax_pdf(x, k, n);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_smax_cdf()
        {
            Console.WriteLine("demo_smax_cdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(3.444);
            CtxScalar n = Ctx.t(20);
            var pdf = smax_cdf(x, k, n);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_smm_pdf()
        {
            Console.WriteLine("demo_smm_pdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(2.691);
            CtxScalar n = Ctx.t(20);
            var pdf = smm_pdf(x, k, n);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_smm_cdf()
        {
            Console.WriteLine("demo_smm_cdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(2.691);
            CtxScalar n = Ctx.t(20);
            var pdf = smm_cdf(x, k, n);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_dunnett1_pdf()
        {
            Console.WriteLine("demo_dunnett1_pdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(3.337);
            CtxScalar n = Ctx.t(20);
            CtxScalar rho = Ctx.t(0.5);
            var pdf = dunnett1_pdf(x, k, n, rho);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_dunnett1_cdf()
        {
            Console.WriteLine("demo_dunnett1_cdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(3.337);
            CtxScalar n = Ctx.t(20);
            CtxScalar rho = Ctx.t(0.5);
            var pdf = dunnett1_cdf(x, k, n, rho);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }

        public static void demo_dunnett2_pdf()
        {
            Console.WriteLine("demo_dunnett2_pdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(3.651);
            CtxScalar n = Ctx.t(20);
            CtxScalar rho = Ctx.t(0.5);
            var pdf = dunnett2_pdf(x, k, n, rho);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_dunnett2_cdf()
        {
            Console.WriteLine("demo_dunnett2_cdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(3.651);
            CtxScalar n = Ctx.t(20);
            CtxScalar rho = Ctx.t(0.5);
            var pdf = dunnett2_cdf(x, k, n, rho);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_nelson2_cdf()
        {
            Console.WriteLine("demo_nelson2_cdf: " + Ctx.name);
            int k = 5;
            CtxScalar x = Ctx.t(3.53);
            CtxScalar n = Ctx.t(20);
            CtxScalar rho = Ctx.t(1) / Ctx.t(k-1);
            var pdf = dunnett2_cdf(x, k, n, rho);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_studentized_range_pdf()
        {
            Console.WriteLine("demo_studentized_range_pdf: " + Ctx.name);
            int k = 4;
            CtxScalar x = Ctx.t(3.462);
            CtxScalar n = Ctx.t(20);
            var pdf = studentized_range_pdf(x, k, n);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_studentized_range_cdf()
        {
            Console.WriteLine("demo_studentized_range_cdf: " + Ctx.name);
            int k = 4;
            CtxScalar x = Ctx.t(3.462);
            CtxScalar n = Ctx.t(20);
            var pdf = studentized_range_cdf(x, k, n);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }



        public static void RunTestsMCP()
        {
            //demo_nmax_pdf_cdf();
            //demo_nmm_pdf_cdf();

            demo_nmax_corr_pdf();
            //demo_nmax_corr_cdf();

            //demo_nmm_corr_pdf();
            //demo_nmm_corr_cdf();

            //demo_nmax_neg_corr_cdf();
            //demo_nmm_neg_corr_cdf();

            //demo_nrange_pdf();
            //demo_nrange_cdf();

            //demo_smax_pdf();
            //demo_smax_cdf();

            //demo_smm_pdf();
            //demo_smm_cdf();

            //demo_dunnett1_pdf();
            //demo_dunnett1_cdf();

            //demo_dunnett2_pdf();
            //demo_dunnett2_cdf();
            //demo_nelson2_cdf();

            //demo_studentized_range_pdf();
            //demo_studentized_range_cdf();

        }

        #endregion



        public static void RunTestsCalculus2()
        {
            //DemoBracketRoot();
            //DemoNewtonRaphson();
            //DemoHalley();
            //DemoSchroder();
            //DemoBrent_Minimum();

            //DemoTrapezoidal();
            //DemoGaussLegendre();
            //DemoGaussKronrod();
            //DemoTanhSinh();
            //DemoSinhSinh();
            //DemoExpSinh();

            //DemoOoura_Cos();
            //DemoOoura_Sin();
            //DemoOoura_Cos2();
            //DemoOoura_Sin2();

            //DemoOoura_Cos2_Chi2();
            //DemoOoura_Sin2_Chi2();

            //DemoOoura_Chi2();
            //DemoOoura_Chi2_PDF();

            DemoOoura_WilksLambda();
        }



        public static void RunTestsBoostOdeint2()
        {
            DemoRungeKutta4Const();
            DemoCashKarp54Const();
            DemoDormandPrince5Const();
            DemoFehlberg78Const();
            DemoAdamsBashforthMoultonConst();

            DemoDormandPrince5Adaptive();
            DemoCashKarp54Adaptive();
            DemoFehlberg78Adaptive();
            DemoBulirschStoerAdaptive();
        }



        public static void RunTestsEigenCalculus2()
        {
            DemoPowellHybrdClass();
            DemoLevenbergClass();
        }



        public static void DemoCtxOpt2()
        {
            DemoNelderMeadCtx();
            DemoCMAesSolver();

            DemoLbfgsSolverCtx();
            DemoBfgsSolverCtx();
            DemoGradientDescentSolverCtx();
            DemoConjugatedGradientDescentSolverCtx();

            DemoNewtonDescentSolver();
        }





        #region Boost Calculus Plain2


        public static CtxScalar f10(CtxScalar x)
        {
            var fx = Ctx.pow(x, 3) - 27;
            return fx;
        }

        public static CtxScalar df10(CtxScalar x)
        {
            var fx = 3 * x * x;
            return fx;
        }

        public static CtxScalar d2f10(CtxScalar x)
        {
            var fx = 6 * x;
            return fx;
        }


        public static void DemoBracketRoot()
        {
            Console.WriteLine("BracketRoot: " + Ctx.name);
            var guess = Ctx.t(2.33);
            var factor = Ctx.t(2.0);
            bool is_rising = true;
            int get_digits = Ctx.prec;
            uint maxit = 50U;
            var res1 = Ctx.BracketRoot(f10, guess, factor, is_rising, get_digits, maxit);
            Console.WriteLine("res1 (x0, error, iter): {0}", res1);
            Console.WriteLine();
        }


        public static void DemoNewtonRaphson()
        {
            Console.WriteLine("NewtonRaphson: " + Ctx.name);
            var guess = Ctx.t(2.33);
            var xmin = Ctx.t(1.0);
            var xmax = Ctx.t(4.0);
            var get_digits = Ctx.prec;
            uint maxit = 50U;
            var res1 = Ctx.NewtonRaphson(f10, df10, guess, xmin, xmax, get_digits, maxit);
            Console.WriteLine("res1 (x0, iter): {0}", res1);
            Console.WriteLine();
        }


        public static void DemoHalley()
        {
            Console.WriteLine("Halley: " + Ctx.name);
            var guess = Ctx.t(2.33);
            var xmin = Ctx.t(1.0);
            var xmax = Ctx.t(4.0);
            uint maxit = 50U;
            var get_digits = Ctx.prec;
            var res1 = Ctx.Halley(f10, df10, d2f10, guess, xmin, xmax, get_digits, maxit);
            Console.WriteLine("res1 (x0, iter): {0}", res1);
            Console.WriteLine();
        }


        public static void DemoSchroder()
        {
            Console.WriteLine("Schröder: " + Ctx.name);
            var guess = Ctx.t(2.33);
            var xmin = Ctx.t(1.0);
            var xmax = Ctx.t(4.0);
            uint maxit = 50U;
            var get_digits = Ctx.prec;
            var res1 = Ctx.Schroder(f10, df10, d2f10, guess, xmin, xmax, get_digits, maxit);
            Console.WriteLine("res1 (x0, iter): {0}", res1);
            Console.WriteLine();
        }



        public static CtxScalar f12(CtxScalar x)
        {
            var fx = (x + 3) * (x - 1) * (x - 1);
            return fx;
        }

        public static void DemoBrent_Minimum()
        {
            Console.WriteLine("Brent_Minimum: " + Ctx.name);
            var bracket_min = Ctx.t(0.5);
            var bracket_max = Ctx.t(1.5);
            var bits = Ctx.prec;
            uint maxit = 50U;
            var res1 = Ctx.Brent_Minimum(f12, bracket_min, bracket_max, bits, maxit);
            Console.WriteLine("res1 (x0, fx0, iter): {0}", res1);
            Console.WriteLine();
        }



        public static CtxScalar f13(CtxScalar x)
        {
            var fx = 1 / (5 - 4 * Ctx.cos(x));
            return fx;
        }

        public static void DemoTrapezoidal()
        {
            Console.WriteLine("Trapezoidal: " + Ctx.name);
            var a = Ctx.zero();
            var b = 2 * Ctx.pi();
            var res1 = Ctx.Trapezoidal(f13, a, b, tol: Ctx.zero());
            Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            Console.WriteLine();
        }



        public static CtxScalar f14(CtxScalar x)
        {
            var fx = x * x * Ctx.atan(x);
            return fx;
        }

        public static void DemoGaussLegendre()
        {
            Console.WriteLine("GaussLegendre: " + Ctx.name);
            var a = Ctx.t(0.0);
            var b = Ctx.t(1.0);
            var res1 = Ctx.GaussLegendre(f14, a, b);
            Console.WriteLine("res1 (integral, cond.no.): {0}", res1);
            Console.WriteLine();
        }



        public static CtxScalar f15(CtxScalar x)
        {
            var fx = Ctx.exp(-x * x / 2);
            return fx;
        }

        public static void DemoGaussKronrod()
        {
            Console.WriteLine("GaussKronrod: " + Ctx.name);
            var a = Ctx.t(0.0);
            var b = Ctx.inf();
            var tol = Ctx.t(0.0);
            var res1 = Ctx.GaussKronrod(f15, a, b, tol);
            Console.WriteLine("res1 (integral, error, cond.no.): {0}", res1);
            Console.WriteLine();
        }



        public static CtxScalar f16(CtxScalar x)
        {
            var fx = 5 * x + 7;
            return fx;
        }

        public static void DemoTanhSinh()
        {
            Console.WriteLine("TanhSinh: " + Ctx.name);
            var a = Ctx.t(-1.0);
            var b = Ctx.t(1.0);
            var tol = Ctx.t(0.0);
            var res1 = Ctx.TanhSinh(f16, a, b, tol);
            Console.WriteLine("res1 (integral, error, cond.no., level): {0}", res1);
            Console.WriteLine();
        }



        public static CtxScalar f17(CtxScalar x)
        {
            var fx = Ctx.exp(-x * x);
            return fx;
        }

        public static void DemoSinhSinh()
        {
            Console.WriteLine("SinhSinh: " + Ctx.name);
            var tol = Ctx.t(0.0);
            var res1 = Ctx.SinhSinh(f17, tol);
            Console.WriteLine("res1 (integral, error, cond.no., level): {0}", res1);
            Console.WriteLine();
        }



        public static CtxScalar f18(CtxScalar x)
        {
            var fx = Ctx.exp(-3 * x);
            return fx;
        }

        public static void DemoExpSinh()
        {
            Console.WriteLine("ExpSinh: " + Ctx.name);
            var tol = Ctx.t(0.0);
            var res1 = Ctx.ExpSinh(f18, tol);
            Console.WriteLine("res1 (integral, error, cond.no., level): {0}", res1);
            Console.WriteLine();
        }



        public static CtxScalar f19(CtxScalar x)
        {
            var fx = 1 / (x * x + 1f);
            return fx;
        }

        public static void DemoOoura_Cos()
        {
            Console.WriteLine("Ooura_Cos: " + Ctx.name);
            var res1 = Ctx.Ooura_Cos(f19);
            Console.WriteLine("res1 (integral, error): {0}", res1);
            Console.WriteLine();
        }

        public static void DemoOoura_Cos2()
        {
            Console.WriteLine("Ooura_Cos2: " + Ctx.name);
            Double omega = 1.0;
            var res1 = Ctx.Ooura_Cos2(f19, omega);
            Console.WriteLine("res1 (integral, error): {0}", res1);
            Console.WriteLine();
        }



        public static CtxScalar f20(CtxScalar x)
        {
            var fx = 1 / x;
            return fx;
        }

        public static void DemoOoura_Sin()
        {
            Console.WriteLine("Ooura_Sin: " + Ctx.name);
            var res1 = Ctx.Ooura_Sin(f20);
            Console.WriteLine("res1 (integral, error): {0}", res1);
            Console.WriteLine();
        }

        public static void DemoOoura_Sin2()
        {
            Console.WriteLine("Ooura_Sin2: " + Ctx.name);
            Double omega = 1.0;
            var res1 = Ctx.Ooura_Sin2(f20, omega);
            Console.WriteLine("res1 (integral, error): {0}", res1);
            Console.WriteLine();
        }



        public static Complex cd_chisquared(Double k, Double t)
        {
            return Complex.Pow(1 - 2 * t * Complex.ImaginaryOne, -k / 2);
        }


        public static Double g_chisquared_cdf_cos(Double t)
        {
            Double k = 5;
            Complex phi = cd_chisquared(k, t);
            Double result = phi.Imaginary / t;
            return result;
        }


        public static Double g_chisquared_cdf_sin(Double t)
        {
            Double k = 5;
            Complex phi = cd_chisquared(k, t);
            Double result = phi.Real / t;
            return result;
        }


        public static void DemoOoura_Chi2()
        {
            Console.WriteLine("Ooura_Chi2: " + Ctx.name);
            //Double k = 5;
            Double x = 10.0;
            Double omega = x;
            var CosInt = Ctx.Ooura_Cos2(g_chisquared_cdf_cos, omega);
            Console.WriteLine("CosInt (integral, error): {0}", CosInt);

            var SinInt = Ctx.Ooura_Sin2(g_chisquared_cdf_sin, omega);
            Console.WriteLine("SinInt (integral, error): {0}", SinInt);

            Double cdf = 0.5 - (CosInt.Item1 - SinInt.Item1) / dreal.pi();
            Console.WriteLine("cdf: {0}", cdf);
        }

        public static Double g_chisquared_pdf_cos(Double t)
        {
            Double k = 5;
            Complex phi = cd_chisquared(k, t);
            Double result = phi.Real;
            return result;
        }


        public static Double g_chisquared_pdf_sin(Double t)
        {
            Double k = 5;
            Complex phi = cd_chisquared(k, t);
            Double result = phi.Imaginary;
            return result;
        }


        public static void DemoOoura_Chi2_PDF()
        {
            Console.WriteLine("Ooura_Chi2_PDF: " + Ctx.name);
            //Double k = 5;
            Double x = 10.0;
            Double omega = x;
            var CosInt = Ctx.Ooura_Cos2(g_chisquared_pdf_cos, omega);
            Console.WriteLine("CosInt (integral, error): {0}", CosInt);

            var SinInt = Ctx.Ooura_Sin2(g_chisquared_pdf_sin, omega);
            Console.WriteLine("SinInt (integral, error): {0}", SinInt);

            Double pdf = (CosInt.Item1 + SinInt.Item1) / dreal.pi();
            Console.WriteLine("cdf: {0}", pdf);
        }





        public static Complex cd_WilksLambda(Double t, int p, int q, int n)
        {
            Complex result = Complex.Zero;
            for (int k0 = 0; k0 < p; k0++)
            {
                int k = k0 + 1;
                var g1 = cmath53.lgamma((n - k + 1) / 2.0 - Complex.ImaginaryOne * t);
                var g2 = cmath53.lgamma((n + q - k + 1) / 2.0);
                var g3 = cmath53.lgamma((n - k + 1) / 2.0);
                var g4 = cmath53.lgamma((n + q - k + 1) / 2.0 - Complex.ImaginaryOne * t);
                var sum1 = (g1 + g2) - (g3 + g4);
                result = result + sum1;
            }
            //Console.WriteLine("result: {0}", result);
            return Complex.Exp(result);
        }


        public static Double g_WilksLambda_cdf_cos(Double t)
        {
            int p = 4;
            int q = 7;
            int n = 20;
            Complex phi = cd_WilksLambda(t, p, q - 1, n - q);
            Double result = phi.Imaginary / t;
            return result;
        }


        public static Double g_WilksLambda_cdf_sin(Double t)
        {
            int p = 4;
            int q = 7;
            int n = 20;
            Complex phi = cd_WilksLambda(t, p, q - 1, n - q);
            Double result = phi.Real / t;
            return result;
        }


        public static void DemoOoura_WilksLambda()
        {
            Console.WriteLine("DemoOoura_WilksLambda: " + Ctx.name);
            Double x = 2.05292648821553;
            Double omega = x;
            var CosInt = Ctx.Ooura_Cos2(g_WilksLambda_cdf_cos, omega);
            Console.WriteLine("CosInt (integral, error): {0}", CosInt);

            var SinInt = Ctx.Ooura_Sin2(g_WilksLambda_cdf_sin, omega);
            Console.WriteLine("SinInt (integral, error): {0}", SinInt);

            Double cdf = 0.5 - (CosInt.Item1 - SinInt.Item1) / dreal.pi();
            Console.WriteLine("cdf: {0}", cdf);
        }





        #endregion





        #region Boost Calculus Odeint2




        public static void FmatLorenz(CtxScalar t, CtxVec x, CtxVec dxdt)
        {
            var sigma = Ctx.t(10);
            var R = Ctx.t(28);
            var b = Ctx.t(8) / 3f;
            dxdt[0] = sigma * (x[1] - x[0]);
            dxdt[1] = R * x[0] - x[1] - x[0] * x[2];
            dxdt[2] = -b * x[2] + x[0] * x[1];
        }

        public static void FmatLorenzObserve(CtxScalar t, CtxVec x)
        {
            Console.Write("t: {0},  ", t);
            for (int i = 0, loopTo = x.Size - 1; i <= loopTo; i++)
                Console.Write("x(" + i.ToString() + "): {0},  ", x[i]);
            Console.WriteLine();
        }




        public static void DemoRungeKutta4Const()
        {
            Console.WriteLine();
            Console.WriteLine("DemoRungeKutta4Const: " + Ctx.name);
            var StartTime = Ctx.t(0.0d);
            var EndTime = Ctx.t(1.01d);
            var dt = Ctx.t(0.01d);
            var InitialVec = Ctx.VecParams(10.0d, 10.0d, 10.0d);
            Ctx.RungeKutta4Const(FmatLorenz, FmatLorenzObserve, InitialVec, StartTime, EndTime, dt);
        }




        public static void DemoCashKarp54Const()
        {
            Console.WriteLine();
            Console.WriteLine("DemoCashKarp54Const: " + Ctx.name);
            var StartTime = Ctx.t(0.0d);
            var EndTime = Ctx.t(1.01d);
            var dt = Ctx.t(0.01d);
            var InitialVec = Ctx.VecParams(10.0d, 10.0d, 10.0d);
            Ctx.CashKarp54Const(FmatLorenz, FmatLorenzObserve, InitialVec, StartTime, EndTime, dt);
        }



        public static void DemoDormandPrince5Const()
        {
            Console.WriteLine();
            Console.WriteLine("DemoDormandPrince5Const: " + Ctx.name);
            var StartTime = Ctx.t(0.0d);
            var EndTime = Ctx.t(1.01d);
            var dt = Ctx.t(0.01d);
            var InitialVec = Ctx.VecParams(10.0d, 10.0d, 10.0d);
            Ctx.DormandPrince5Const(FmatLorenz, FmatLorenzObserve, InitialVec, StartTime, EndTime, dt);
        }


        public static void DemoFehlberg78Const()
        {
            Console.WriteLine();
            Console.WriteLine("DemoFehlberg78Const: " + Ctx.name);
            var StartTime = Ctx.t(0.0d);
            var EndTime = Ctx.t(1.01d);
            var dt = Ctx.t(0.01d);
            var InitialVec = Ctx.VecParams(10.0d, 10.0d, 10.0d);
            Ctx.Fehlberg78Const(FmatLorenz, FmatLorenzObserve, InitialVec, StartTime, EndTime, dt);
        }


        public static void DemoAdamsBashforthMoultonConst()
        {
            Console.WriteLine();
            Console.WriteLine("DemoAdamsBashforthMoultonConst: " + Ctx.name);
            var StartTime = Ctx.t(0.0d);
            var EndTime = Ctx.t(1.01d);
            var dt = Ctx.t(0.01d);
            var InitialVec = Ctx.VecParams(10.0d, 10.0d, 10.0d);
            Ctx.AdamsBashforthMoultonConst(FmatLorenz, FmatLorenzObserve, InitialVec, StartTime, EndTime, dt);
        }



        public static void DemoDormandPrince5Adaptive()
        {
            Console.WriteLine();
            Console.WriteLine("DemoDormandPrince5Adaptive: " + Ctx.name);
            var StartTime = Ctx.t(0.0d);
            var EndTime = Ctx.t(1.01d);
            var dt = Ctx.t(0.01d);
            var epsabs = Ctx.t(0.000001d);
            var epsrel = Ctx.t(epsabs);
            var InitialVec = Ctx.VecParams(10.0d, 10.0d, 10.0d);
            Ctx.DormandPrince5Adaptive(FmatLorenz, FmatLorenzObserve, InitialVec, StartTime, EndTime, dt, epsabs, epsrel);
        }



        public static void DemoCashKarp54Adaptive()
        {
            Console.WriteLine();
            Console.WriteLine("DemoCashKarp54Adaptive: " + Ctx.name);
            var StartTime = Ctx.t(0.0d);
            var EndTime = Ctx.t(1.01d);
            var dt = Ctx.t(0.01d);
            var epsabs = Ctx.t(0.000001d);
            var epsrel = Ctx.t(epsabs);
            var InitialVec = Ctx.VecParams(10.0d, 10.0d, 10.0d);
            Ctx.CashKarp54Adaptive(FmatLorenz, FmatLorenzObserve, InitialVec, StartTime, EndTime, dt, epsabs, epsrel);
        }



        public static void DemoFehlberg78Adaptive()
        {
            Console.WriteLine();
            Console.WriteLine("DemoFehlberg78Adaptive: " + Ctx.name);
            var StartTime = Ctx.t(0.0d);
            var EndTime = Ctx.t(1.01d);
            var dt = Ctx.t(0.01d);
            var epsabs = Ctx.t(0.000001d);
            var epsrel = Ctx.t(epsabs);
            var InitialVec = Ctx.VecParams(10.0d, 10.0d, 10.0d);
            Ctx.Fehlberg78Adaptive(FmatLorenz, FmatLorenzObserve, InitialVec, StartTime, EndTime, dt, epsabs, epsrel);
        }



        public static void DemoBulirschStoerAdaptive()
        {
            Console.WriteLine();
            Console.WriteLine("DemoBulirschStoerAdaptive: " + Ctx.name);
            var StartTime = Ctx.t(0.0d);
            var EndTime = Ctx.t(1.01d);
            var dt = Ctx.t(0.01d);
            var epsabs = Ctx.t(0.000001d);
            var epsrel = Ctx.t(epsabs);
            var InitialVec = Ctx.VecParams(10.0d, 10.0d, 10.0d);
            Ctx.BulirschStoerAdaptive(FmatLorenz, FmatLorenzObserve, InitialVec, StartTime, EndTime, dt, epsabs, epsrel);
        }








        #endregion





        #region Eigen Calculus2



        public static void XmatHybrd(CtxMat x, CtxMat fvec)
        {
            // Console.WriteLine("in matHybrd")
            int n = x.size;
            for (int k = 0; k <= n - 1; k++)
            {
                var temp = (Ctx.t(3.0) - Ctx.t(2.0) * x[k]) * x[k];
                var temp1 = Ctx.t(0.0);
                if (k != 0)
                    temp1 = x[k - 1];
                var temp2 = Ctx.t(0.0);
                if (k != n - 1)
                    temp2 = x[k + 1];
                fvec[k] = temp - temp1 - Ctx.t(2.0) * temp2 + Ctx.t(1.0);
            }
        }

        public static void XmatHybrdJ(CtxMat x, CtxMat jacobian)
        {
            // Console.WriteLine("in matHybrdJ")
            int n = x.size;
            for (int k = 0; k <= n - 1; k++)
            {
                for (int j = 0; j <= n - 1; j++)
                    jacobian[k, j] = Ctx.t(0.0);
                jacobian[k, k] = Ctx.t(3.0) - Ctx.t(4.0) * x[k];
                if (k != 0)
                    jacobian[k, k - 1] = Ctx.t(-1.0);
                if (k != n - 1)
                    jacobian[k, k + 1] = Ctx.t(-2.0);
            }
        }

        public static void DemoPowellHybrdClass()
        {
            Console.WriteLine("Hello DemoPowellHybrdClass: " + Ctx.name);
            int n = 9;
            var matInput = Ctx.mat_zeros(n, 1);
            matInput[0] = Ctx.t(1.0);
            matInput[1] = Ctx.t(2.0);  // entries 2 .. 8 are 0.

            var matX = Ctx.PowellHybrd(XmatHybrd, XmatHybrdJ, matInput);
            Console.WriteLine("");
            matX.Print("X (solution):", 10);
            var matEval = Ctx.mat_zeros(n, 1);
            XmatHybrd(matX, matEval);
            matEval.Print("matEval =  F(X=solution):", 10);
        }






        public static void XmatLM(CtxMat x, CtxMat fvec)
        {
            // Console.WriteLine("in matLM")
            Double[] y = new[] { 0.14, 0.18, 0.22, 0.25, 0.29, 0.32, 0.35, 0.39, 0.37, 0.58, 0.73, 0.96, 1.34, 2.1, 4.39 };
            int m = 15;
            int tmp1, tmp2, tmp3;
            for (int i = 0; i <= m - 1; i++)
            {
                tmp1 = i + 1;
                tmp2 = 15 - i;
                tmp3 = tmp1;
                if (i >= 8)
                    tmp3 = tmp2;
                fvec[i] = Ctx.t(y[i]) - (x[0] + tmp1 / (x[1] * tmp2 + x[2] * tmp3));
            }
        }

        public static void XmatLMJ(CtxMat x, CtxMat fjac)
        {
            // Console.WriteLine("in matLMJ")
            int m = 15;
            for (int i = 0; i <= m - 1; i++)
            {
                int tmp1 = i + 1;
                int tmp2 = 15 - i;
                int tmp3 = tmp1;
                if (i >= 8)
                    tmp3 = tmp2; // else tmp3 = tmp1
                var tmp4 = x[1] * tmp2 + x[2] * tmp3;
                tmp4 = tmp4 * tmp4;
                fjac[i, 0] = Ctx.t(-1);
                fjac[i, 1] = tmp1 * tmp2 / tmp4;
                fjac[i, 2] = tmp1 * tmp3 / tmp4;
            }
        }

        public static void DemoLevenbergClass()
        {
            Console.WriteLine("Hello DemoLevenbergClassSReal() ");
            int n = 3;
            int m = 15;
            var matInput = Ctx.mat_zeros(n, 1);
            matInput[0] = Ctx.t(1);
            matInput[1] = Ctx.t(2);
            matInput[2] = Ctx.t(0);

            var matX = Ctx.Levenberg(XmatLM, XmatLMJ, matInput, n, m);
            Console.WriteLine("");
            matX.Print("X (solution):", 10);
            var matEval = Ctx.mat_zeros(m, 1);
            XmatLM(matX, matEval);
            matEval.Print("matEval =  F(X=solution):", 10);
        }




        #endregion






        #region Boost Calculus Multidimensional Optimization



        public static CtxScalar CtxNormRosenthal(CtxVec x)
        {
            // Console.WriteLine("In CtxNormRosenthal")
            var t1 = 1f - x[0];
            var t2 = x[1] - x[0] * x[0];
            var norm = t1 * t1 + 100f * t2 * t2;
            // Console.WriteLine("norm: {0}", norm)
            return norm;
        }


        public static void CtxGradRosenthal(CtxVec x, CtxVec grad)
        {
            // Console.WriteLine("In CtxGradRosenthal")
            grad[0] = -2 * (1f - x[0]) + 200f * (x[1] - x[0] * x[0]) * (-2 * x[0]);
            grad[1] = 200f * (x[1] - x[0] * x[0]);
        }


        public static void CtxHessianRosenthal(CtxVec x, CtxMat hessian)
        {
            // Console.WriteLine("In CtxHessianRosenthal")
            hessian[0, 0] = 1200f * x[0] * x[0] - 400f * x[1] + 1f;
            hessian[0, 1] = -400 * x[0];
            hessian[1, 0] = -400 * x[0];
            hessian[1, 1] = Ctx.t(200);
        }




        public static void DemoNelderMeadCtx()
        {
            Console.WriteLine("NelderMead:" + Ctx.name);
            var InitialState = Ctx.VecParams(-1.0d, 2.0d);
            var matRes = Ctx.NelderMeadSolver(CtxNormRosenthal, InitialState);
            Console.WriteLine();
            Console.WriteLine("fx0: {0}", matRes[0]);
            Console.WriteLine("fx1: {0}", matRes[1]);
            var norm = CtxNormRosenthal(matRes);
            Console.WriteLine("Norm: {0}", norm);
            Console.WriteLine("");
        }


        public static void DemoCMAesSolver()
        {
            Console.WriteLine("CMAesSolver:" + Ctx.name);
            var InitialState = Ctx.VecParams(-1.0d, 2.0d);
            var matRes = Ctx.CMAesSolver(CtxNormRosenthal, InitialState);
            Console.WriteLine();
            Console.WriteLine("fx0: {0}", matRes[0]);
            Console.WriteLine("fx1: {0}", matRes[1]);
            var norm = CtxNormRosenthal(matRes);
            Console.WriteLine("Norm: {0}", norm);
            Console.WriteLine("");
        }



        public static void DemoLbfgsSolverCtx()
        {
            Console.WriteLine("LbfgsSolver:" + Ctx.name);
            var InitialState = Ctx.VecParams(-1.0d, 2.0d);
            var matRes = Ctx.LbfgsSolver(CtxNormRosenthal, CtxGradRosenthal, InitialState);
            Console.WriteLine();
            Console.WriteLine("fx0: {0}", matRes[0]);
            Console.WriteLine("fx1: {0}", matRes[1]);
            var norm = CtxNormRosenthal(matRes);
            Console.WriteLine("Norm: {0}", norm);
            Console.WriteLine("");
        }



        public static void DemoBfgsSolverCtx()
        {
            Console.WriteLine("BfgsSolver:" + Ctx.name);
            var InitialState = Ctx.VecParams(-1.0d, 2.0d);
            var matRes = Ctx.BfgsSolver(CtxNormRosenthal, CtxGradRosenthal, InitialState);
            Console.WriteLine();
            Console.WriteLine("fx0: {0}", matRes[0]);
            Console.WriteLine("fx1: {0}", matRes[1]);
            var norm = CtxNormRosenthal(matRes);
            Console.WriteLine("Norm: {0}", norm);
            Console.WriteLine("");
        }



        public static void DemoGradientDescentSolverCtx()
        {
            Console.WriteLine("GradientDescentSolverCtx:" + Ctx.name);
            var InitialState = Ctx.VecParams(-1.0d, 2.0d);
            var matRes = Ctx.GradientDescentSolver(CtxNormRosenthal, CtxGradRosenthal, InitialState);
            Console.WriteLine();
            Console.WriteLine("fx0: {0}", matRes[0]);
            Console.WriteLine("fx1: {0}", matRes[1]);
            var norm = CtxNormRosenthal(matRes);
            Console.WriteLine("Norm: {0}", norm);
            Console.WriteLine("");
        }



        public static void DemoConjugatedGradientDescentSolverCtx()
        {
            Console.WriteLine("ConjugatedGradientDescentSolver:" + Ctx.name);
            var InitialState = Ctx.VecParams(-1.0d, 2.0d);
            var matRes = Ctx.ConjugatedGradientDescentSolver(CtxNormRosenthal, CtxGradRosenthal, InitialState);
            Console.WriteLine();
            Console.WriteLine("fx0: {0}", matRes[0]);
            Console.WriteLine("fx1: {0}", matRes[1]);
            var norm = CtxNormRosenthal(matRes);
            Console.WriteLine("Norm: {0}", norm);
            Console.WriteLine("");
        }



        public static void DemoNewtonDescentSolver()
        {
            Console.WriteLine("DemoNewtonDescentSolver:" + Ctx.name);
            var InitialState = Ctx.VecParams(-1.0d, 2.0d);
            var matRes = Ctx.NewtonDescentSolver(CtxNormRosenthal, CtxGradRosenthal, CtxHessianRosenthal, InitialState);
            Console.WriteLine();
            Console.WriteLine("fx0: {0}", matRes[0]);
            Console.WriteLine("fx1: {0}", matRes[1]);
            var norm = CtxNormRosenthal(matRes);
            Console.WriteLine("Norm: {0}", norm);
            Console.WriteLine("");
        }





        #endregion





        public static void NumericalCalculus()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            try
            {
                RunTestsNumericalCalculus2();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10d);
            Console.WriteLine("Elapsed Time " + elapsedTime);
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Memory used before collection:       {0:N0}", GC.GetTotalMemory(false));
            GC.Collect();
            Console.WriteLine("Memory used after full collection:   {0:N0}", GC.GetTotalMemory(true));
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("");
        }




    }
}