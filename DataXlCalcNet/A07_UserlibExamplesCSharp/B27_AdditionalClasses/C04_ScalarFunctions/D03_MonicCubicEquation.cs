
/* Uncomment exactly one of the defines below to select the data type */
#define UsingCmath53
//#define UsingSingle
//#define UsingDouble
//#define UsingExtended
//#define UsingQuadruple
//#define UsingOctuple
//#define UsingMpfr  // requires ArbPrecNet
//#define UsingArb  // requires ArbPrecNet


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
/* No syntax highlighting if UsingCmath53 is undefined */
    using CtxScalar = System.Numerics.Complex;
    using Ctx = UserFixedPrecNet.m53libc;
#endif

#if UsingSingle
/* No syntax highlighting if UsingSingle is undefined */
    using CtxScalar = FixedPrecNet.SingleC;
    using Ctx = UserFixedPrecNet.slibc;
#endif

#if UsingDouble
/* No syntax highlighting if UsingDouble is undefined */
    using CtxScalar = System.Numerics.Complex;
    using Ctx = UserFixedPrecNet.dlibc;
#endif

#if UsingExtended
/* No syntax highlighting if UsingExtended is undefined */
    using CtxScalar = FixedPrecNet.ExtendedC;
    using Ctx = UserFixedPrecNet.elibc;
#endif

#if UsingQuadruple
/* No syntax highlighting if UsingQuadruple is undefined */
    using CtxScalar = FixedPrecNet.QuadrupleC;
    using Ctx = UserFixedPrecNet.qlibc;
#endif

#if UsingOctuple
/* No syntax highlighting if UsingOctuple is undefined */
    using CtxScalar = FixedPrecNet.OctupleC;
    using Ctx = UserFixedPrecNet.olibc;
#endif

#if UsingMpfr
/* No syntax highlighting if UsingMpfr is undefined */
    using ArbPrecNet;
    using CtxScalar = ArbPrecNet.MpfrC;
    using Ctx = UserArbPrecNet.mlibc;
#endif

#if UsingArb
/* No syntax highlighting if UsingSingle is undefined */
    using ArbPrecNet;
    using CtxScalar = ArbPrecNet.ArbC;
    using Ctx = UserArbPrecNet.aflibc;
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
    DemoSolveMonicCubicReal();
    DemoSolveMonicCubicCplx();
}


#region DemoSolveMonicCubic


public static void DemoSolveMonicCubicReal()
{
    Console.WriteLine("Hello DemoSolveMonicCubicReal: " + Ctx.name);

    var a = 0.441910366987445; 
    var b = -0.672187472645632; 
    var c = -0.198008526383064; 

    var res = Ctx.cubic_equation_monic(a, b, c);
    Console.WriteLine("x1: {0}, f(x1): {1}", res.Item1, Ctx.eval_monic_cubic(res.Item1, a, b, c));
    Console.WriteLine("x2: {0}, f(x2): {1}", res.Item2, Ctx.eval_monic_cubic(res.Item2, a, b, c));
    Console.WriteLine("x3: {0}, f(x3): {1}", res.Item3, Ctx.eval_monic_cubic(res.Item3, a, b, c));
}

public static void DemoSolveMonicCubicCplx()
{
    Console.WriteLine("Hello DemoSolveMonicCubicCplx: " + Ctx.name);

    var a = dcplx.t(0.206665783345176, 0.22633186596918);
    var b = dcplx.t(0.277883889299886, -0.767385695178652);
    var c = dcplx.t(0.373654914852069, -0.480864077812474);

    var res = Ctx.cubic_equation_monic(a, b, c);
    Console.WriteLine("x1: {0}, f(x1): {1}", res.Item1, Ctx.eval_monic_cubic(res.Item1, a, b, c));
    Console.WriteLine("x2: {0}, f(x2): {1}", res.Item2, Ctx.eval_monic_cubic(res.Item2, a, b, c));
    Console.WriteLine("x3: {0}, f(x3): {1}", res.Item3, Ctx.eval_monic_cubic(res.Item3, a, b, c));
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

