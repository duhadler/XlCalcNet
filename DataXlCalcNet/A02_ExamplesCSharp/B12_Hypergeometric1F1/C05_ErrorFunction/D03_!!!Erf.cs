

// Real example Crashes

/* If defined includes code requiring ArbPrecNet. Is set automatically */
#define HasArbPrecNet

#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
using ArbPrecNet;
#endif
#endregion


static class Program
{

public static void MainTests()
{
//    Test_TauFromQ_Real();
    Test_TauFromQ_Cplx();
    Test_TauFromQ_Cplx_Real_Imag();
}


#region Test_TauFromQ_Real

public static void Test_TauFromQ_Real()
{
    Console.WriteLine("<H1 Title=" + "\"" + "Test_TauFromQ_Real" + "\"" + ">");
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    ArbPrec.SetDps(40);
#endif
    double[] InputArray1 = { 0.1, 0.6, 0.7 }; // 0 < q < 1
    foreach (var q in InputArray1)
    {
        Complex res01 = cmath53.taufromq(q);
        Console.WriteLine("cmath53: taufromq(q={0}):  {1}", q, res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
//        Mpfr res07 = mreal.exp(x);
//        Console.WriteLine(" mreal: exp(x={0}):  {1}", x, res07);
//        Single res08 = sflint.exp(x);
//        Console.WriteLine("sflint: exp(x={0}):  {1}", x, res08);
//        Double res09 = dflint.exp(x);
//        Console.WriteLine("dflint: exp(x={0}):  {1}", x, res09);
//        Extended res10 = eflint.exp(x);
//        Console.WriteLine("eflint: exp(x={0}):  {1}", x, res10);
//        Quadruple res11 = qflint.exp(x);
//        Console.WriteLine("qflint: exp(x={0}):  {1}", x, res11);
//        Octuple res12 = oflint.exp(x);
//        Console.WriteLine("oflint: exp(x={0}):  {1}", x, res12);
//        Mpfr res13 = mflint.exp(x);
//        Console.WriteLine("mflint: exp(x={0}):  {1}", x, res13);
//        Arb res16 = aflint.exp(x);
//        Console.WriteLine("aflint: exp(x={0}): {1}", x, res16);
#endif
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region Test_TauFromQ_Cplx

public static void Test_TauFromQ_Cplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "Test_TauFromQ_Cplx" + "\"" + ">");
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    ArbPrec.SetDps(40);
#endif
    Complex[] InputArray1C = {dcplx.t(0.1, 0.1), dcplx.t(0.6, 0.1), 
        dcplx.t(0.7, 0.1)}; // 0 < abs(q) < 1
    foreach (var q in InputArray1C)
    {
        Complex res01 = cmath53.taufromq(q);
        Console.WriteLine("cmath53: taufromq(q={0}):  {1}", q, res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
//        MpfrC res07 = mcplx.exp(x);
//        Console.WriteLine("  mcplx: exp(x={0}):  {1}", x, res07);
//        SingleC res08 = sflintc.exp(x);
//        Console.WriteLine("sflintc: exp(x={0}):  {1}", x, res08);
//        Complex res09 = dflintc.exp(x);
//        Console.WriteLine("dflintc: exp(x={0}):  {1}", x, res09);
//        ExtendedC res10 = eflintc.exp(x);
//        Console.WriteLine("eflintc: exp(x={0}):  {1}", x, res10);
//        QuadrupleC res11 = qflintc.exp(x);
//        Console.WriteLine("qflintc: exp(x={0}):  {1}", x, res11);
//        OctupleC res12 = oflintc.exp(x);
//        Console.WriteLine("oflintc: exp(x={0}):  {1}", x, res12);
//        MpfrC res13 = mflintc.exp(x);
//        Console.WriteLine("mflintc: exp(x={0}):  {1}", x, res13);
//        ArbC res16 = aflintc.exp(x);
//        Console.WriteLine("aflintc: exp(x={0}): {1}", x, res16);
#endif
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region Test_TauFromQ_Cplx_Real_Imag

public static void Test_TauFromQ_Cplx_Real_Imag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "Test_TauFromQ_Cplx_Real_Imag" + "\"" + ">");
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    ArbPrec.SetDps(40);
#endif
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = {dcplx.t(0.1, 0.1), dcplx.t(0.6, 0.1), 
        dcplx.t(0.7, 0.1)}; // 0 < abs(q) < 1
    foreach (var q in InputArray1C)
    {
    foreach (var IsReal in ReImArray)
    {
        string ReIm = IsReal ? "Re(" : "Im(";

        Complex res01c = cmath53.taufromq(q);
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53: " + ReIm + "taufromq(x={0})):  {1}", q, res01);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
//        MpfrC res07c = mcplx.exp(x);
//        Mpfr res07 = IsReal ? res07c.real : res07c.imag;
//        Console.WriteLine("  mcplx: " + ReIm + "exp(x={0})):  {1}", x, res07);
//
//        SingleC res08c = sflintc.exp(x);
//        Single res08 = IsReal ? res08c.real : res08c.imag;
//        Console.WriteLine("sflintc: " + ReIm + "exp(x={0})):  {1}", x, res08);
//
//        Complex res09c = dflintc.exp(x);
//        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
//        Console.WriteLine("dflintc: " + ReIm + "exp(x={0})):  {1}", x, res09);
//
//        ExtendedC res10c = eflintc.exp(x);
//        Extended res10 = IsReal ? res10c.real : res10c.imag;
//        Console.WriteLine("eflintc: " + ReIm + "exp(x={0})):  {1}", x, res10);
//
//        QuadrupleC res11c = qflintc.exp(x);
//        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
//        Console.WriteLine("qflintc: " + ReIm + "exp(x={0})):  {1}", x, res11);
//
//        OctupleC res12c = oflintc.exp(x);
//        Octuple res12 = IsReal ? res12c.real : res12c.imag;
//        Console.WriteLine("oflintc: " + ReIm + "exp(x={0})):  {1}", x, res12);
//
//        MpfrC res13c = mflintc.exp(x);
//        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
//        Console.WriteLine("mflintc: " + ReIm + "exp(x={0})):  {1}", x, res13);
//
//        ArbC res16c = aflintc.exp(x);
//        Arb res16 = IsReal ? res16c.real : res16c.imag;
//        Console.WriteLine("aflintc: " + ReIm + "exp(x={0})): {1}", x, res16);
#endif
        Console.WriteLine();
    }
    }
    Console.WriteLine("</H1>");
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

