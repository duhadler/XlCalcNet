
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
    TestBernpolyReal();
    TestBernpolyCplx();
    TestBernpolyRealImag();
}


#region TestBernpolyReal

public static void TestBernpolyReal()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestBernpolyReal" + "\"" + ">");
    int[] InputArray1 = { 1, 2, 3, 4 };
    Double[] InputArray2 = { -0.333d, 0.0d, 0.333d };
    foreach (int n in InputArray1) {
    foreach (Double z in InputArray2) {
        Console.WriteLine("<H2 Title=" + "\"" + "bernpoly(z, n); n={0}, z={1}" 
            + "\"" + ">", n, z);
        Double res01 = math53.bernpoly(z, n);
        Console.WriteLine("math53:  {0}", res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Single res08 = sflint.bernpoly(z, n);
        Console.WriteLine("sflint:  {0}", res08);
        Double res09 = dflint.bernpoly(z, n);
        Console.WriteLine("dflint:  {0}", res09);
        Extended res10 = eflint.bernpoly(z, n);
        Console.WriteLine("eflint:  {0}", res10);
        Quadruple res11 = qflint.bernpoly(z, n);
        Console.WriteLine("qflint:  {0}", res11);
        Octuple res12 = oflint.bernpoly(z, n);
        Console.WriteLine("oflint:  {0}", res12);
        Mpfr res13 = mflint.bernpoly(z, n);
        Console.WriteLine("mflint:  {0}", res13);
        Arb res16 = aflint.bernpoly(z, n);
        Console.WriteLine("aflint: {0}", res16);
#endif
    Console.WriteLine("</H2>");
    Console.WriteLine();
    } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestBernpolyCplx

public static void TestBernpolyCplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestBernpolyCplx" + "\"" + ">");
    int[] InputArrayInt1 = { 1, 2, 3, 4 };
    Complex[] InputArray1C = { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), 
        dcplx.t(4.333d, 2) };
    foreach (int n in InputArrayInt1) {
    foreach (Complex z in InputArray1C) {
        Console.WriteLine("<H2 Title=" + "\"" + "bernpoly(z, n); n={0}, z={1}" 
        + "\"" + ">", n, z);
        Complex res01 = cmath53.bernpoly(z, n);
        Console.WriteLine("cmath53:  {0}", res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08 = sflintc.bernpoly(z, n);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.bernpoly(z, n);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.bernpoly(z, n);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.bernpoly(z, n);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.bernpoly(z, n);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.bernpoly(z, n);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.bernpoly(z, n);
        Console.WriteLine("aflintc: {0}", res16);
#endif
    Console.WriteLine("</H2>");
    Console.WriteLine();
    } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestBernpolyRealImag

public static void TestBernpolyRealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestBernpolyRealImag" + "\"" + ">");
    bool[] ReImArray = {true, false};
    int[] InputArrayInt1 = { 1, 2, 3, 4 };
    Complex[] InputArray1C = { dcplx.t(-4.333d, 2), dcplx.t(0.0d, 2), 
        dcplx.t(4.333d, 2) };
    foreach (int n in InputArrayInt1) {
    foreach (Complex z in InputArray1C) {
    foreach (var IsReal in ReImArray) {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "bernpoly(z, n)); n={0}, z={1}" 
            + "\"" + ">", n, z);

        Complex res01c = cmath53.bernpoly(z, n);
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08c = sflintc.bernpoly(z, n);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.bernpoly(z, n);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.bernpoly(z, n);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.bernpoly(z, n);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.bernpoly(z, n);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.bernpoly(z, n);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.bernpoly(z, n);
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

