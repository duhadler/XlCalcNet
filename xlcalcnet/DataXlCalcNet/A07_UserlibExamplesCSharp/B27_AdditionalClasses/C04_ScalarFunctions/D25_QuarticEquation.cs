
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

#if UsingCmath53
/* No syntax highlighting if UsingDouble is undefined */
    using CtxScalar = System.Numerics.Complex;
    using Ctx = FixedPrecNet.cmath53;
#endif

#if UsingSingle
/* No syntax highlighting if UsingSingle is undefined */
    using CtxScalar = FixedPrecNet.SingleC;
    using Ctx = FixedPrecNet.scplx;
#endif

#if UsingDouble
/* No syntax highlighting if UsingDouble is undefined */
    using CtxScalar = System.Numerics.Complex;
    using Ctx = FixedPrecNet.dcplx;
#endif

#if UsingExtended
/* No syntax highlighting if UsingExtended is undefined */
    using CtxScalar = FixedPrecNet.ExtendedC;
    using Ctx = FixedPrecNet.ecplx;
#endif

#if UsingQuadruple
/* No syntax highlighting if UsingQuadruple is undefined */
    using CtxScalar = FixedPrecNet.QuadrupleC;
    using Ctx = FixedPrecNet.qcplx;
#endif

#if UsingOctuple
/* No syntax highlighting if UsingOctuple is undefined */
    using CtxScalar = FixedPrecNet.OctupleC;
    using Ctx = FixedPrecNet.ocplx;
#endif

#if UsingMpfr
/* No syntax highlighting if UsingMpfr is undefined */
    using ArbPrecNet;
    using CtxScalar = ArbPrecNet.MpfrC;
    using Ctx = ArbPrecNet.mcplx;
#endif

#if UsingArb
/* No syntax highlighting if UsingSingle is undefined */
    using ArbPrecNet;
    using CtxScalar = ArbPrecNet.ArbC;
    using Ctx = ArbPrecNet.aflintc;
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
    DemoSolveQuarticReal();
    DemoSolveQuarticCplx();
}


#region DemoSolveQuartic


public static void DemoSolveQuarticReal()
{
    Console.WriteLine("Hello DemoSolveQuadratic: " + Ctx.name);

    var A = 1;
    var B = -0.234714652820833;
    var C = -0.971195083461995; 
    var D = 0.256810335610663; 
    var E = 0.133977523086149; 

    var res = Ctx.quartic_equation(A, B, C, D, E);
    Console.WriteLine("x1: {0}, f(x1): {1}", res.Item1, Ctx.eval_quartic(res.Item1, A, B, C, D, E));
    Console.WriteLine("x2: {0}, f(x2): {1}", res.Item2, Ctx.eval_quartic(res.Item2, A, B, C, D, E));
    Console.WriteLine("x3: {0}, f(x3): {1}", res.Item3, Ctx.eval_quartic(res.Item3, A, B, C, D, E));
    Console.WriteLine("x4: {0}, f(x4): {1}", res.Item4, Ctx.eval_quartic(res.Item4, A, B, C, D, E));
}


public static void DemoSolveQuarticCplx()
{
    Console.WriteLine("Hello DemoSolveQuadratic: " + Ctx.name);

    var A = dcplx.t(0.206665783345176, 0.22633186596918);
    var B = dcplx.t(-0.264681838174667, 0.780524705654179);
    var C = dcplx.t(0.0550409643579374, -0.759533984539585);
    var D = dcplx.t(0.667954662116589, 0.0348426061121497);
    var E = dcplx.t(0.0903700734006817, 0.433731017675367);

    var res = Ctx.quartic_equation(A, B, C, D, E);
    Console.WriteLine("x1: {0}, f(x1): {1}", res.Item1, Ctx.eval_quartic(res.Item1, A, B, C, D, E));
    Console.WriteLine("x2: {0}, f(x2): {1}", res.Item2, Ctx.eval_quartic(res.Item2, A, B, C, D, E));
    Console.WriteLine("x3: {0}, f(x3): {1}", res.Item3, Ctx.eval_quartic(res.Item3, A, B, C, D, E));
    Console.WriteLine("x4: {0}, f(x4): {1}", res.Item4, Ctx.eval_quartic(res.Item4, A, B, C, D, E));
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

