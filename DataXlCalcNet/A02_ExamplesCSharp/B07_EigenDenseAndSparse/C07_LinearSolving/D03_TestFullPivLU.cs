/* Render Ctx as class */

/* Uncomment the line below to select complex instead of real */
//#define UsingComplex

/* Uncomment one of the defines below to select the data type */
//#define UsingSingle
//#define UsingDouble
//#define UsingExtended
#define UsingQuadruple
//#define UsingOctuple
//#define UsingMpfr  // requires ArbPrecNet
//#define UsingArb  // requires ArbPrecNet


#region Usings

using System;
using System.Diagnostics;

#if UsingSingle
/* No syntax highlighting if UsingSingle is undefined */
    #if UsingComplex
    using Ctx = FixedPrecNet.scplx;
    #else
    using Ctx = FixedPrecNet.sreal;
    #endif
#endif

#if UsingDouble
/* No syntax highlighting if UsingDouble is undefined */
    #if UsingComplex
    using Ctx = FixedPrecNet.dcplx;
    #else
    using Ctx = FixedPrecNet.dreal;
    #endif
#endif

#if UsingExtended
/* No syntax highlighting if UsingExtended is undefined */
    #if UsingComplex
    using Ctx = FixedPrecNet.ecplx;
    #else
    using Ctx = FixedPrecNet.ereal;
    #endif
#endif

#if UsingQuadruple
/* No syntax highlighting if UsingQuadruple is undefined */
    #if UsingComplex
    using Ctx = FixedPrecNet.qcplx;
    #else
    using Ctx = FixedPrecNet.qreal;
    #endif
#endif

#if UsingOctuple
/* No syntax highlighting if UsingOctuple is undefined */
    #if UsingComplex
    using Ctx = FixedPrecNet.ocplx;
    #else
    using Ctx = FixedPrecNet.oreal;
    #endif
#endif

#if UsingMpfr
/* No syntax highlighting if UsingMpfr is undefined */
using ArbPrecNet;
    #if UsingComplex
    using Ctx = ArbPrecNet.mcplx;
    #else
    using Ctx = ArbPrecNet.mreal;
    #endif
#endif

#if UsingBigDecimal
/* No syntax highlighting if UsingBigDecimal is undefined */
using ArbPrecNet;
    #if UsingComplex
    using Ctx = ArbPrecNet.bflintc;
    #else
    using Ctx = ArbPrecNet.bflint;
    #endif
#endif

#if UsingArb
/* No syntax highlighting if UsingArb is undefined */
using ArbPrecNet;
    #if UsingComplex
    using Ctx = ArbPrecNet.aflintc;
    #else
    using Ctx = ArbPrecNet.aflint;
    #endif
#endif


#endregion


static class Program
{

public static void MainTests()
{
#if (UsingMpfr || UsingBigDecimal || UsingArb)
/* No syntax highlighting if none of the above is defined */
    ArbPrec.SetDps(40);
#endif
    DemoAnyMatFullPivLUCtx(); GC.Collect();
}


#region DemoAnyMatFullPivLUCtx

public static void DemoAnyMatFullPivLUCtx()
{
    Console.WriteLine("DemoAnyMatFullPivLUCtx: " + Ctx.name);
    int digits = 15;
    int m = 5;
    int n = 5;

    var A = Ctx.mat_random(n, m);
    A.Print("A: ", digits);
    var b1 = Ctx.mat_random(n, 1);
    b1.Print("B: ", digits);

    var res = A.FullPivLU("rcond, lu, p, q, isinjective, isinvertible, issurjective, det, x, inverse", b1);

    Console.WriteLine("det: {0}", res["det"][0, 0]);
    Console.WriteLine("rcond: {0}", res["rcond"][0, 0]);
    Console.WriteLine("isinjective: {0}", res["isinjective"][0, 0]);
    Console.WriteLine("isinvertible: {0}", res["isinvertible"][0, 0]);
    Console.WriteLine("issurjective: {0}", res["issurjective"][0, 0]);

    var LU1 = res["lu"];
    var P1 = res["p"];
    var Q1 = res["q"];
    LU1.Print("LU: ", digits);
    P1.Print("P: ", digits);
    Q1.Print("Q: ", digits);

    var inv1 = res["inverse"];
    inv1.Print("inv: ", digits);
    var Diff = A * inv1;
    Diff.Print("A * inv: ", digits);

    var x1 = res["x"];
    x1.Print("x: ", digits);
    var b2 = A * x1;
    b2.Print("b2 = A * x: ", digits);

    Diff = b1 - b2;
    Diff.Print("Diff = b2 - b: ", digits);
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

