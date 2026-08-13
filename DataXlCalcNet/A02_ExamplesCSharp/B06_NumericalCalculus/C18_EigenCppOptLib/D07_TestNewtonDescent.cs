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
using CtxMat = FixedPrecNet.SingleMat;
#endif


#if UsingDouble
/* No syntax highlighting if UsingDouble is undefined */
using Ctx = FixedPrecNet.dreal;
using CtxScalar = System.Double;
using CtxVec = FixedPrecNet.DoubleVec;
using CtxMat = FixedPrecNet.DoubleMat;
#endif

#if UsingExtended
/* No syntax highlighting if UsingExtended is undefined */
using Ctx = FixedPrecNet.ereal;
using CtxScalar = FixedPrecNet.Extended;
using CtxVec = FixedPrecNet.ExtendedVec;
using CtxMat = FixedPrecNet.ExtendedMat;
#endif

#if UsingQuadruple
/* No syntax highlighting if UsingQuadruple is undefined */
using Ctx = FixedPrecNet.qreal;
using CtxScalar = FixedPrecNet.Quadruple;
using CtxVec = FixedPrecNet.QuadrupleVec;
using CtxMat = FixedPrecNet.QuadrupleMat;
#endif

#if UsingOctuple
/* No syntax highlighting if UsingOctuple is undefined */
using Ctx = FixedPrecNet.oreal;
using CtxScalar = FixedPrecNet.Octuple;
using CtxVec = FixedPrecNet.OctupleVec;
using CtxMat = FixedPrecNet.OctupleMat;
#endif

#if UsingMpfr
/* No syntax highlighting if UsingMpfr is undefined */
using ArbPrecNet;
using Ctx = ArbPrecNet.mreal;
using CtxScalar = ArbPrecNet.Mpfr;
using CtxVec = ArbPrecNet.MpfrVec;
using CtxMat = ArbPrecNet.MpfrMat;
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
    DemoNewtonDescentSolver();
}


#region DemoNewtonDescentSolver

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

