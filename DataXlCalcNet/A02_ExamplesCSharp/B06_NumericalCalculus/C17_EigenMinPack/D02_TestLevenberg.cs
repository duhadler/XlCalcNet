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
    DemoLevenbergClass();
}


#region DemoLevenbergClass

public static void XmatLM(CtxMat x, CtxMat fvec)
{
    // Console.WriteLine("in matLM")
    double[] y = new[] { 0.14, 0.18, 0.22, 0.25, 0.29, 0.32, 0.35, 0.39, 0.37, 
        0.58, 0.73, 0.96, 1.34, 2.1, 4.39 };
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

