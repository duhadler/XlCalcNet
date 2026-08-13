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
    DemoAnyJacobiSVDFullCtx(); GC.Collect();
}


#region DemoAnyJacobiSVDFullCtx


public static void DemoAnyJacobiSVDFullCtx()
{
    Console.WriteLine("DemoAnyJacobiSVDFullCtx: " + Ctx.name);
    int digits = 15;
    int m = 16;
    int n = 16;

    var A = Ctx.mat_random(n, m);
    A.Print("A: ", digits);
    var b1 = Ctx.mat_random(n, 1);
    b1.Print("B: ", digits);
    var res = A.JacobiSvdFull("rank, nonzeros, S, U, V, X, PseudoInverse, SPlus", b1);

    // Basic information
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Basic information");
    Console.WriteLine("rank: {0}", res["rank"][0, 0]);
    Console.WriteLine("nonzeros: {0}", res["nonzeros"][0, 0]);

    var S0 = res["s"];
    var U1 = res["u"];
    var V1 = res["v"];
    S0.Print("Singular values (descending): ", digits);


    // Least square solving
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Least square solving");
    var x1 = res["x"];
    x1.Print("x: ", digits);
    var b2 = A * x1;
    b2.Print("b2 = A * x: ", digits);
    var Diff = b1 - b2;
    Diff.Print("Diff = b2 - b: ", digits);


    // Confirming the validity of the decomposition
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Confirming the validity of the decomposition");
    U1.Print("Matrix U: ", digits);
    V1.Print("Matrix V: ", digits);
    var A1 = U1 * S0.AsDiagonal() * V1.Adjoint();
    A1.Print("A1 = U * S * V^T: ", digits);
    var F = A - A1;
    F.Print("Diff: A - A1: ", digits);


    // Confirming properties of the pseudoinverse
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Confirming properties of the pseudoinverse");
    var SPlus = +S0;
    for (int i = 0, loopTo = S0.rows - 1; i <= loopTo; i++)
    {
        if (S0[i] != Ctx.zero())
            SPlus[i] = Ctx.one() / S0[i];
        else
            SPlus[i] = Ctx.zero();
    }
    var Pinv = V1 * SPlus.AsDiagonal() * U1.Adjoint();
    Pinv.Print("Pinv = V * SPlus * U^T: ", digits);
    A1 = A - A * Pinv * A;
    A1.Print("A1 = A - A * Pinv * A: ", digits);


    // Confirming relationship to eigenvalues
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Confirming relationship to eigenvalues");
    var C = A;
    if (n > m)
    {
        C = A.Adjoint() * A;
        C.Print("C = A^H * A : ", digits);
    }
    else
    {
        C = A * A.Adjoint();
        C.Print("C = A * A^H: ", digits);
    }

    var es = C.SelfAdjointEigenSystem("eval");

    var D = es["eval"];

    D.Print("D = Eigenvalues of A^T * A (ascending): ", digits);
    var E = S0.CwiseProduct(S0);
    E = E.ReverseFull();
    E.Print("E = Square of singular values (ascending): ", digits);
    F = D - E;
    F.Print("Diff: D - E", digits);
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

