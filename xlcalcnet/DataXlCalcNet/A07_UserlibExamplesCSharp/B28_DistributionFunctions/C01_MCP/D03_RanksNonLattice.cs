
/* Uncomment exactly one of the defines below to select the data type */
#define UsingCmath53
//#define UsingSingle
//#define UsingDouble
//#define UsingExtended
//#define UsingQuadruple   // takes > 40s for all tests 
//#define UsingOctuple
//#define UsingMpfr  // requires ArbPrecNet


#region Usings

/* If defined includes code requiring UserFixedPrecNet. Is set automatically */
#define HasUserFixedPrecNet

/* If defined includes code requiring ArbPrecNet. Is set automatically */
#define HasArbPrecNet

/* If defined includes code requiring UserArbPrecNet. Is set automatically */
#define HasUserArbPrecNet


using System;
using System.Diagnostics;
using System.Numerics;
using FixedPrecNet;
using UserFixedPrecNet;


#if UsingCmath53
/* No syntax highlighting if UsingDouble is undefined */
    using CtxScalar = System.Double;
    using Ctx = FixedPrecNet.math53;
    using CtxLib = UserFixedPrecNet.m53lib;
#endif

#if UsingSingle
/* No syntax highlighting if UsingSingle is undefined */
    using CtxScalar = System.Single;
    using Ctx = FixedPrecNet.sreal;
    using CtxLib = UserFixedPrecNet.slib;
#endif

#if UsingDouble
/* No syntax highlighting if UsingDouble is undefined */
    using CtxScalar = System.Double;
    using Ctx = FixedPrecNet.dreal;
    using CtxLib = UserFixedPrecNet.dlib;
#endif

#if UsingExtended
/* No syntax highlighting if UsingExtended is undefined */
    using CtxScalar = FixedPrecNet.Extended;
    using Ctx = FixedPrecNet.ereal;
    using CtxLib = UserFixedPrecNet.elib;
#endif

#if UsingQuadruple
/* No syntax highlighting if UsingQuadruple is undefined */
    using CtxScalar = FixedPrecNet.Quadruple;
    using Ctx = FixedPrecNet.qreal;
    using CtxLib = UserFixedPrecNet.qlib;
#endif

#if UsingOctuple
/* No syntax highlighting if UsingOctuple is undefined */
    using CtxScalar = FixedPrecNet.Octuple;
    using Ctx = FixedPrecNet.oreal;
    using CtxLib = UserFixedPrecNet.olib;
#endif

#if UsingMpfr
/* No syntax highlighting if UsingMpfr is undefined */
    using ArbPrecNet;
    using UserArbPrecNet;
    using CtxScalar = ArbPrecNet.Mpfr;
    using Ctx = ArbPrecNet.mreal;
    using CtxLib = UserArbPrecNet.mlib;
#endif



#endregion


static class Program
{

public static void MainTests()
{
#if (UsingMpfr || UsingArb)
/* No syntax highlighting if none of the above is defined */
    ArbPrec.SetDps(40);
#endif
    demo_nmax_pdf_cdf();
    demo_nmm_pdf_cdf();

    Console.WriteLine("Ctx.prec : {0}", Ctx.prec);
    if (Ctx.prec <= 113)   //  equal or below quad precision
    {
        demo_nmax_corr_pdf();
        demo_nmax_corr_cdf();

        demo_nmm_corr_pdf();
        demo_nmm_corr_cdf();

    #if UsingDouble || UsingCmath53
        demo_nmax_neg_corr_cdf();
        demo_nmm_neg_corr_cdf();
    #endif

        demo_nrange_pdf();
        demo_nrange_cdf();

        demo_smax_pdf();
        demo_smax_cdf();

        demo_smm_pdf();
        demo_smm_cdf();

        demo_dunnett1_pdf();
        demo_dunnett1_cdf();

        demo_dunnett2_pdf();
        demo_dunnett2_cdf();
        demo_nelson2_cdf();

        demo_studentized_range_pdf();
        demo_studentized_range_cdf();
    }
    else
    {
        Console.WriteLine("skipped other tests because of precision");
    }

}


#region DemoMCP



        public static void demo_nmax_pdf_cdf()
        {
            int k = 8;
            CtxScalar x = Ctx.t(2.381);
            Console.WriteLine("demo_nmax_pdf_cdf: " + Ctx.name);
            var pdf = CtxLib.nmax_pdf(x, k);
            Console.WriteLine("pdf : {0}", pdf);
            var cdf = CtxLib.nmax_cdf(x, k);
            Console.WriteLine("cdf : {0}", cdf);
            Console.WriteLine();
        }


        public static void demo_nmm_pdf_cdf()
        {
            int k = 8;
            CtxScalar x = Ctx.t(2.381);
            Console.WriteLine("demo_nmm_pdf_cdf: " + Ctx.name);
            var pdf = CtxLib.nmm_pdf(x, k);
            Console.WriteLine("pdf : {0}", pdf);
            var cdf = CtxLib.nmm_cdf(x, k);
            Console.WriteLine("cdf : {0}", cdf);
            Console.WriteLine();
        }


        public static void demo_nmax_corr_pdf()
        {
            Console.WriteLine("demo_nmax_corr_pdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(2.381);
            CtxScalar rho = Ctx.t(0.5);
            var pdf = CtxLib.nmax_corr_pdf(x, k, rho);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_nmax_corr_cdf()
        {
            Console.WriteLine("demo_nmax_corr_cdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(2.381);
            CtxScalar rho = Ctx.t(0.5);
            var pdf = CtxLib.nmax_corr_cdf(x, k, rho);
            Console.WriteLine("cdf: {0}", pdf);
            Console.WriteLine();
        }


#if UsingDouble || UsingCmath53
        public static void demo_nmax_neg_corr_cdf()
        {
            Console.WriteLine("demo_nmax_neg_corr_cdf: " + Ctx.name);
            int k = 5;
            CtxScalar x = Ctx.t(2.08);
            CtxScalar rho = -Ctx.t(1) / Ctx.t(k-1);
            var pdf = CtxLib.nmax_neg_corr_cdf(x, k, rho);
            Console.WriteLine("cdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_nmm_neg_corr_cdf()
        {
            Console.WriteLine("demo_nmm_neg_corr_cdf: " + Ctx.name);
            int k = 5;
            CtxScalar x = Ctx.t(2.08);
            CtxScalar rho = -Ctx.t(1) / Ctx.t(k - 1);
            var pdf = CtxLib.nmm_neg_corr_cdf(x, k, rho);
            Console.WriteLine("cdf: {0}", pdf);
            Console.WriteLine();
        }
#endif

        public static void demo_nmm_corr_pdf()
        {
            Console.WriteLine("demo_nmm_corr_pdf: " + Ctx.name);
            int k = 6;
            CtxScalar x = Ctx.t(2.567);
            CtxScalar rho = Ctx.t(0.5);
            var pdf = CtxLib.nmm_corr_pdf(x, k, rho);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_nmm_corr_cdf()
        {
            Console.WriteLine("demo_nmm_corr_cdf: " + Ctx.name);
            int k = 6;
            CtxScalar x = Ctx.t(2.567);
            CtxScalar rho = Ctx.t(0.5);
            var pdf = CtxLib.nmm_corr_cdf(x, k, rho);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }



        public static void demo_nrange_pdf()
        {
            Console.WriteLine("demo_nrange_pdf: " + Ctx.name);
            int k = 4;
            CtxScalar x = Ctx.t(3.240);
            var pdf = CtxLib.nrange_pdf(x, k);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_nrange_cdf()
        {
            Console.WriteLine("demo_nrange_cdf: " + Ctx.name);
            int k = 4;
            CtxScalar x = Ctx.t(3.240);
            var pdf = CtxLib.nrange_cdf(x, k);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_smax_pdf()
        {
            Console.WriteLine("demo_smax_pdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(3.444);
            CtxScalar n = Ctx.t(20);
            var pdf = CtxLib.smax_pdf(x, k, n);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_smax_cdf()
        {
            Console.WriteLine("demo_smax_cdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(3.444);
            CtxScalar n = Ctx.t(20);
            var pdf = CtxLib.smax_cdf(x, k, n);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_smm_pdf()
        {
            Console.WriteLine("demo_smm_pdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(2.691);
            CtxScalar n = Ctx.t(20);
            var pdf = CtxLib.smm_pdf(x, k, n);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_smm_cdf()
        {
            Console.WriteLine("demo_smm_cdf: " + Ctx.name);
            int k = 8;
            CtxScalar x = Ctx.t(2.691);
            CtxScalar n = Ctx.t(20);
            var pdf = CtxLib.smm_cdf(x, k, n);
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
            var pdf = CtxLib.dunnett1_pdf(x, k, n, rho);
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
            var pdf = CtxLib.dunnett1_cdf(x, k, n, rho);
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
            var pdf = CtxLib.dunnett2_pdf(x, k, n, rho);
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
            var pdf = CtxLib.dunnett2_cdf(x, k, n, rho);
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
            var pdf = CtxLib.dunnett2_cdf(x, k, n, rho);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_studentized_range_pdf()
        {
            Console.WriteLine("demo_studentized_range_pdf: " + Ctx.name);
            int k = 4;
            CtxScalar x = Ctx.t(3.462);
            CtxScalar n = Ctx.t(20);
            var pdf = CtxLib.studentized_range_pdf(x, k, n);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }


        public static void demo_studentized_range_cdf()
        {
            Console.WriteLine("demo_studentized_range_cdf: " + Ctx.name);
            int k = 4;
            CtxScalar x = Ctx.t(3.462);
            CtxScalar n = Ctx.t(20);
            var pdf = CtxLib.studentized_range_cdf(x, k, n);
            Console.WriteLine("pdf: {0}", pdf);
            Console.WriteLine();
        }





#endregion



/* This region contains the program entry point. Do not change */
#region Main

public static void Main(string[] args)
{
    if (args.Length < 2)
    {
        Console.WriteLine(
            "This application needs to be started with 2 arguments;");
        Console.WriteLine("See the manual of xlcalcnet for details.");
    }
    else
    {
        _PythonRootDir = args[0];
        _PythonNetPyDll = args[1];
        _LocalAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder
            .LocalApplicationData);
        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.AssemblyResolve += 
            new ResolveEventHandler(LoadFromXlCalcNet);
        currentDomain.AssemblyResolve += 
            new ResolveEventHandler(LoadFromXlCalcNet2);
        currentDomain.AssemblyResolve += 
            new ResolveEventHandler(LoadFromPythonNet);
        currentDomain.AssemblyResolve += 
            new ResolveEventHandler(LoadFromAppLocal);
        System.Threading.Thread.CurrentThread.CurrentCulture = 
            new System.Globalization.CultureInfo("en-US");
        System.Threading.Thread.CurrentThread.CurrentUICulture = 
            new System.Globalization.CultureInfo("en-US");
        var ci = (System.Globalization.CultureInfo)System.Threading.Thread
            .CurrentThread.CurrentCulture.Clone();
        ci.NumberFormat.NegativeInfinitySymbol = "-Inf";
        ci.NumberFormat.PositiveInfinitySymbol = "+Inf";
        System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        var stopWatch = new System.Diagnostics.Stopwatch();
        stopWatch.Start();
        try
        {
            Environment.SetEnvironmentVariable("PYTHONHOME", _PythonRootDir);
            Environment.SetEnvironmentVariable("PYTHONPATH", _PythonRootDir);
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", 
                _PythonNetPyDll);
            MainTests();
        }
        catch (Exception Ex)
        {
            Console.Error.WriteLine(Ex.Message);
            Console.Error.WriteLine("$+$");
            Console.Error.WriteLine(Ex.StackTrace);
            Console.Error.WriteLine("$+$");
        }
        stopWatch.Stop();
        var ts = stopWatch.Elapsed;
        string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", 
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        Console.WriteLine("<H1 Title=" + "\"" + "General Info" + "\"" + ">");
        Console.WriteLine("Elapsed Time " + elapsedTime);
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Memory used before collection:       {0:N0}", 
            GC.GetTotalMemory(false));
        GC.Collect();
        Console.WriteLine("Memory used after full collection:   {0:N0}", 
            GC.GetTotalMemory(true));
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("");
        Console.WriteLine("</H1>");
    }

}

private static string _PythonRootDir;
private static string _PythonNetPyDll;
private static string _LocalAppDataDir;

static System.Reflection.Assembly LoadFromXlCalcNet(object sender, 
    ResolveEventArgs args)
{
    string folderPath2 = _PythonRootDir + 
        @"\Lib\site-packages\xlcalcnet\Addin\NET48\Bin";
    string assemblyPath = System.IO.Path.Combine(folderPath2, new System
        .Reflection.AssemblyName(args.Name).Name + ".dll");
    if (!System.IO.File.Exists(assemblyPath)) return null; 
    else return System.Reflection.Assembly.LoadFrom(assemblyPath);
}


static System.Reflection.Assembly LoadFromXlCalcNet2(object sender, 
    ResolveEventArgs args)
{
    string folderPath2 = _PythonRootDir + 
        @"\Lib\site-packages\xlcalcnet2\Addin\NET48\Bin";
    string assemblyPath = System.IO.Path.Combine(folderPath2, new System
        .Reflection.AssemblyName(args.Name).Name + ".dll");
    if (!System.IO.File.Exists(assemblyPath)) return null; 
    else return System.Reflection.Assembly.LoadFrom(assemblyPath);
}


static System.Reflection.Assembly LoadFromPythonNet(object sender, 
    ResolveEventArgs args)
{
    string folderPath2 = _PythonRootDir + 
        @"\Lib\site-packages\pythonnet\runtime";
    string assemblyPath = System.IO.Path.Combine(folderPath2, new System
        .Reflection.AssemblyName(args.Name).Name + ".dll");
    if (!System.IO.File.Exists(assemblyPath)) return null; 
    else return System.Reflection.Assembly.LoadFrom(assemblyPath);
}


static System.Reflection.Assembly LoadFromAppLocal(object sender, 
    ResolveEventArgs args)
{
    string folderPath2 = _LocalAppDataDir + @"\Local\XlCalcNetIDE\Bin";
    string assemblyPath = System.IO.Path.Combine(folderPath2, new System
        .Reflection.AssemblyName(args.Name).Name + ".dll");
    if (!System.IO.File.Exists(assemblyPath)) return null; 
    else return System.Reflection.Assembly.LoadFrom(assemblyPath);
}


#endregion


}

/* Do not remove. Do not add anything after this */
#region EOF
// Reserved
#endregion

