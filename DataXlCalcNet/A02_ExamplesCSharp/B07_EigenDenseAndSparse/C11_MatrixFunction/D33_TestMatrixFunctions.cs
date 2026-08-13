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


#endregion


static class Program
{

public static void MainTests()
{
#if (UsingMpfr || UsingBigDecimal)
/* No syntax highlighting if none of the above is defined */
    ArbPrec.SetDps(40);
#endif
    DemoMatrixFunctions(); GC.Collect();
}


#region DemoMatrixFunctions


public static void DemoMatrixFunctions()
{
    Console.WriteLine("Hello DemoSMatrixMatrixFunctions: " + Ctx.name);
    var digits = 15;   // warning: variable is never used
    var n  = 4;

    var A = Ctx.mat_random_selfadjoint(n);

    A.Print("A: ");
    var B = A.ExpMat();
    B.Print("B = Exp(A): ");
    var C = B.LogMat();
    C.Print("C = Log(B): ");

    var D = B.SqrtMat();
    D.Print("D = Sqrt(B): ");
    var E = D * D;
    E.Print("E = D * D: ");

    B = A.SinMat();
    B.Print("B = Sin(A): ");
    C = A.CosMat();
    C.Print("C = Cos(A): ");
    D = B * B + C * C;
    D.Print("B * B + C * C: ");

    B = A.SinhMat();
    B.Print("B = Sinh(A): ");
    C = A.CoshMat();
    C.Print("C = Cosh(A): ");
    D = C * C - B * B;
    D.Print("C * C - B * B: ");

    var res = A.SelfAdjointEigenSystem("eval, evec");
    var Lambda = res["eval"];
    var Evec = res["evec"];
    Lambda.Print("Lambda: (Eigenvalues)");
    Evec.Print("Evec: (Eigenvectors)");
    var LambdaFunc = Ctx.mat_zeros(n, 1);

    var A2 = Evec * Lambda.AsDiagonal() * Evec.Inverse();
    A2.Print("A2");
    for (int i = 0; i < n; i++)
    {
        LambdaFunc[i] = Ctx.exp(Lambda[i]);
    }
    LambdaFunc.Print("exp(Lambda)");
    var A3 = Evec * LambdaFunc.AsDiagonal() * Evec.Inverse();
    A3.Print("A3");

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

