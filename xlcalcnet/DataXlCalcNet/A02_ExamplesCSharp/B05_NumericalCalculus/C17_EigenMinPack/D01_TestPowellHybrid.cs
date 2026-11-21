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
using CtxMat = FixedPrecNet.SingleMat;
#endif

#if UsingDouble
/* No syntax highlighting if UsingDouble is undefined */
using Ctx = FixedPrecNet.dreal;
using CtxScalar = System.Double;
using CtxMat = FixedPrecNet.DoubleMat;
#endif

#if UsingExtended
/* No syntax highlighting if UsingExtended is undefined */
using Ctx = FixedPrecNet.ereal;
using CtxScalar = FixedPrecNet.Extended;
using CtxMat = FixedPrecNet.ExtendedMat;
#endif

#if UsingQuadruple
/* No syntax highlighting if UsingQuadruple is undefined */
using Ctx = FixedPrecNet.qreal;
using CtxScalar = FixedPrecNet.Quadruple;
using CtxMat = FixedPrecNet.QuadrupleMat;
#endif

#if UsingOctuple
/* No syntax highlighting if UsingOctuple is undefined */
using Ctx = FixedPrecNet.oreal;
using CtxScalar = FixedPrecNet.Octuple;
using CtxMat = FixedPrecNet.OctupleMat;
#endif

#if UsingMpfr
/* No syntax highlighting if UsingMpfr is undefined */
using ArbPrecNet;
using Ctx = ArbPrecNet.mreal;
using CtxScalar = ArbPrecNet.Mpfr;
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
    DemoPowellHybrdClass();
}


#region DemoPowellHybrdClass

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

