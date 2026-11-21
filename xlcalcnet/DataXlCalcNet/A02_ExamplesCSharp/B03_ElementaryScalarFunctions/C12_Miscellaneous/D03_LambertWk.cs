
#region Usings
/* If defined includes code requiring ArbPrecNet. Is set automatically */
#define HasArbPrecNet
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
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    ArbPrec.SetDps(80);
#endif
    TestLambertWkReal();
    TestLambertWkCplx();
    TestLambertWkRealImag();
}


#region TestLambertWkReal

public static void TestLambertWkReal()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestLambertWkReal" + "\"" + ">");
    Double[] InputArray1 = { -0.333d, 0.0d, 0.333d, double.PositiveInfinity };
    Int32[] InputArray2 = { 0, 1, 2, 3, 4, 5, 6 };

    foreach (Double x in InputArray1) {
    foreach (Int32 n in InputArray2) {
        Console.WriteLine("<H2 Title=" + "\"" + "lambert_wk(x, n); x={0}, n={1}" 
            + "\"" + ">", x, n);
        Complex res01 = math53.lambert_wk(x, n);
        Console.WriteLine("math53:  {0}", res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08 = sflint.lambert_wk(x, n);
        Console.WriteLine("sflint:  {0}", res08);
        Complex res09 = dflint.lambert_wk(x, n);
        Console.WriteLine("dflint:  {0}", res09);
        ExtendedC res10 = eflint.lambert_wk(x, n);
        Console.WriteLine("eflint:  {0}", res10);
        QuadrupleC res11 = qflint.lambert_wk(x, n);
        Console.WriteLine("qflint:  {0}", res11);
        OctupleC res12 = oflint.lambert_wk(x, n);
        Console.WriteLine("oflint:  {0}", res12);
        MpfrC res13 = mflint.lambert_wk(x, n);
        Console.WriteLine("mflint:  {0}", res13);
        ArbC res16 = aflint.lambert_wk(x, n);
        Console.WriteLine("aflint: {0}", res16);
#endif
    Console.WriteLine();
    Console.WriteLine("</H2>");
    } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestLambertWkCplx

public static void TestLambertWkCplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestLambertWkCplx" + "\"" + ">");
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    Int32[] InputArray2 = { 0, 1, 2, 3, 4, 5, 6 };

    foreach (Complex x in InputArray1C) {
    foreach (Int32 n in InputArray2) {
    Console.WriteLine("<H2 Title=" + "\"" + "lambert_wk(x, n); x={0}, n={1}" 
        + "\"" + ">", x, n);
        Complex res01 = cmath53.lambert_wk(x, n);
        Console.WriteLine("cmath53:  {0}", res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        MpfrC res07 = mcplx.lambert_wk(x, n);
        Console.WriteLine("  mcplx:  {0}", res07);
        SingleC res08 = sflintc.lambert_wk(x, n);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.lambert_wk(x, n);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.lambert_wk(x, n);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.lambert_wk(x, n);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.lambert_wk(x, n);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.lambert_wk(x, n);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.lambert_wk(x, n);
        Console.WriteLine("aflintc: {0}", res16);
#endif
    Console.WriteLine("</H2>");
    Console.WriteLine();
    } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestLambertWkRealImag

public static void TestLambertWkRealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestLambertWkRealImag" + "\"" + ">");
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    Int32[] InputArray2 = { 0, 1, 2, 3, 4, 5, 6 };

    foreach (Complex x in InputArray1C) {
    foreach (Int32 n in InputArray2) {
    foreach (var IsReal in ReImArray) {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "lambert_wk(x, n)); x={0}, n={1}" 
            + "\"" + ">", x, n);

        Complex res01c = cmath53.lambert_wk(x, n);
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        MpfrC res07c = mcplx.lambert_wk(x, n);
        Mpfr res07 = IsReal ? res07c.real : res07c.imag;
        Console.WriteLine("  mcplx:  {0}", res07);

        SingleC res08c = sflintc.lambert_wk(x, n);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.lambert_wk(x, n);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.lambert_wk(x, n);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.lambert_wk(x, n);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.lambert_wk(x, n);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.lambert_wk(x, n);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.lambert_wk(x, n);
        Arb res16 = IsReal ? res16c.real : res16c.imag;
        Console.WriteLine("aflintc: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    } }
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

