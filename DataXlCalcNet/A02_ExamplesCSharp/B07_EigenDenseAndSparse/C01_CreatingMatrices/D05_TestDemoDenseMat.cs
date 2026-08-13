/* Render Ctx as class */

/* Uncomment the line below to select complex instead of real */
//#define UsingComplex

/* Uncomment one of the defines below to select the data type */
//#define UsingSingle
//#define UsingDouble
//#define UsingExtended
//#define UsingQuadruple
//#define UsingOctuple
//#define UsingMpfr  // requires ArbPrecNet
#define UsingArb  // requires ArbPrecNet


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
    DemoAnyMatCtx(); GC.Collect();
}


#region DemoAnyMatCtx


public static void DemoAnyMatCtx()
{
    Console.WriteLine("DemoAnyMatCtx: " + Ctx.name);
    int digits = 15;

    var x1 = Ctx.mat_random(4, 4);
    x1.Print("x1: ", digits);

    var d1 = x1;
    d1.Print("d1: ", digits);

    var d2 = Ctx.mat_random(4, 4);
    d2.Print("d2: ", digits);

    var x2 = d2;
    x2.Print("x2: ", digits);

    var z1 = x1.ConcatHorizontal(x2);
    z1.Print("z1 = x1.ConcatHorizontal(x2): ", digits);

    var z2 = x1.ConcatVertical(x2);
    z2.Print("z2 = x1.ConcatVertical(x2): ", digits);

    var y1 = x1.Inverse();
    y1.Print("y1: ", digits);

    z1 = x1 * y1;
    z1.Print("z1: ", digits);

    z2 = x1 / x2;
    z2.Print("z2: ", digits);

    var Coeff = x1[1, 1];
    Console.WriteLine("Coeff: {0}", Coeff);

    var Coeff2 = Ctx.t(1.11111111111d);
    Console.WriteLine("Coeff2: {0}", Coeff2);
    y1[1, 1] = Coeff2;
    y1.Print("y1: ", digits);

    Console.WriteLine("Rows: " + x1.rows);
    Console.WriteLine("Cols: " + x1.cols);
    Console.WriteLine("Size: " + x1.size);

    uint count = y1.GTcount(x1);
    Console.WriteLine("GT: " + count);

    z1 = x1.get_Block(0, 0, 1, 1);
    z1.Print("z1= x1.block(0, 0, 1, 1): ", digits);

    var A = Ctx.mat_random(3, 5);
    A.Print("A: ", digits);

    A.Resize(2, 4);
    A.Print("A: ", digits);

    x1.ConservativeResize(2, 5);
    x1.Print("x1: ", digits);
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

