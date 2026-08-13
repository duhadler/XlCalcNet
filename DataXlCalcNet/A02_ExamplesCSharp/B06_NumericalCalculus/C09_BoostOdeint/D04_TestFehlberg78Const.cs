/* Render Ctx as class */

/* Uncomment one of the defines below to select the precision */
//#define UsingSingle
//#define UsingDouble
//#define UsingExtended
//#define UsingQuadruple
//#define UsingOctuple
#define UsingMpfr

#region Usings

using System;
using System.Diagnostics;

#if UsingSingle
/* No syntax highlighting if UsingSingle is undefined */
using Ctx = FixedPrecNet.sreal;
using CtxScalar = System.Single;
using CtxVec = FixedPrecNet.SingleVec;
#endif


#if UsingDouble
/* No syntax highlighting if UsingDouble is undefined */
using Ctx = FixedPrecNet.dreal;
using CtxScalar = System.Double;
using CtxVec = FixedPrecNet.DoubleVec;
#endif

#if UsingExtended
/* No syntax highlighting if UsingExtended is undefined */
using Ctx = FixedPrecNet.ereal;
using CtxScalar = FixedPrecNet.Extended;
using CtxVec = FixedPrecNet.ExtendedVec;
#endif

#if UsingQuadruple
/* No syntax highlighting if UsingQuadruple is undefined */
using Ctx = FixedPrecNet.qreal;
using CtxScalar = FixedPrecNet.Quadruple;
using CtxVec = FixedPrecNet.QuadrupleVec;
#endif

#if UsingOctuple
/* No syntax highlighting if UsingOctuple is undefined */
using Ctx = FixedPrecNet.oreal;
using CtxScalar = FixedPrecNet.Octuple;
using CtxVec = FixedPrecNet.OctupleVec;
#endif

#if UsingMpfr
/* No syntax highlighting if UsingMpfr is undefined */
using ArbPrecNet;
using Ctx = ArbPrecNet.mreal;
using CtxScalar = ArbPrecNet.Mpfr;
using CtxVec = ArbPrecNet.MpfrVec;
#endif


#endregion


static class Program
{

public static void MainTests()
{
#if UsingMpfr
/* No syntax highlighting if UsingMpfr is undefined */
    ArbPrec.SetDps(40);
#endif
    DemoFehlberg78Const();
}


#region DemoFehlberg78Const

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

