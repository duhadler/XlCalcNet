
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
    TestEllipticFReal();
    TestEllipticFCplx();
    TestEllipticFRealImag();
}


#region TestEllipticFReal

public static void TestEllipticFReal()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestEllipticFReal" + "\"" + ">");
    Double[] InputArray1 = { 0.0d, 0.75d, 1.5d };
    Double[] InputArray2 = { 0.0d, 0.5d, 1.0d };
    foreach (Double phi in InputArray1) {
    foreach (Double k in InputArray2) {
        Console.WriteLine("<H2 Title=" + "\"" + "elliptic_f(phi, k); phi={0}, k={1}" 
            + "\"" + ">", phi, k);
        Double res01 = math53.elliptic_f(phi, k);
        Console.WriteLine("math53:  {0}", res01);
        Single res02 = sreal.elliptic_f(phi, k);
        Console.WriteLine(" sreal:  {0}", res02);
        Double res03 = dreal.elliptic_f(phi, k);
        Console.WriteLine(" dreal:  {0}", res03);
        Extended res04 = ereal.elliptic_f(phi, k);
        Console.WriteLine(" ereal:  {0}", res04);
        Quadruple res05 = qreal.elliptic_f(phi, k);
        Console.WriteLine(" qreal:  {0}", res05);
        Octuple res06 = oreal.elliptic_f(phi, k);
        Console.WriteLine(" oreal:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Mpfr res07 = mreal.elliptic_f(phi, k);
        Console.WriteLine(" mreal:  {0}", res07);
        Single res08 = sflint.elliptic_f(phi, k);
        Console.WriteLine("sflint:  {0}", res08);
        Double res09 = dflint.elliptic_f(phi, k);
        Console.WriteLine("dflint:  {0}", res09);
        Extended res10 = eflint.elliptic_f(phi, k);
        Console.WriteLine("eflint:  {0}", res10);
        Quadruple res11 = qflint.elliptic_f(phi, k);
        Console.WriteLine("qflint:  {0}", res11);
        Octuple res12 = oflint.elliptic_f(phi, k);
        Console.WriteLine("oflint:  {0}", res12);
        Mpfr res13 = mflint.elliptic_f(phi, k);
        Console.WriteLine("mflint:  {0}", res13);
        Arb res16 = aflint.elliptic_f(phi, k);
        Console.WriteLine("aflint: {0}", res16);
#endif
    Console.WriteLine("</H2>");
    Console.WriteLine();
    } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestEllipticFCplx

public static void TestEllipticFCplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestEllipticFCplx" + "\"" + ">");
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    Complex[] InputArray2C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    foreach (Complex phi in InputArray1C) {
    foreach (Complex k in InputArray2C) {
        Console.WriteLine("<H2 Title=" + "\"" + "elliptic_f(phi, k); phi={0}, k={1}" 
        + "\"" + ">", phi, k);
        Complex res01 = cmath53.elliptic_f(phi, k);
        Console.WriteLine("cmath53:  {0}", res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08 = sflintc.elliptic_f(phi, k);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.elliptic_f(phi, k);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.elliptic_f(phi, k);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.elliptic_f(phi, k);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.elliptic_f(phi, k);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.elliptic_f(phi, k);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.elliptic_f(phi, k);
        Console.WriteLine("aflintc: {0}", res16);
#endif
    Console.WriteLine("</H2>");
    Console.WriteLine();
    } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestEllipticFRealImag

public static void TestEllipticFRealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestEllipticFRealImag" + "\"" + ">");
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    Complex[] InputArray2C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    foreach (Complex phi in InputArray1C) {
    foreach (Complex k in InputArray2C) {
    foreach (var IsReal in ReImArray) {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "elliptic_f(phi, k)); phi={0}, k={1}" 
            + "\"" + ">", phi, k);

        Complex res01c = cmath53.elliptic_f(phi, k);
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08c = sflintc.elliptic_f(phi, k);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.elliptic_f(phi, k);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.elliptic_f(phi, k);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.elliptic_f(phi, k);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.elliptic_f(phi, k);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.elliptic_f(phi, k);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.elliptic_f(phi, k);
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

