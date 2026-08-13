
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
    TestMEllipticPiReal();
    TestMEllipticPiCplx();
    TestMEllipticPiRealImag();
}


#region TestMEllipticPiReal

public static void TestMEllipticPiReal()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestMEllipticPiReal" + "\"" + ">");
    Double[] InputArray1 = { 0.0d, 0.75d, 1.5d };
    Double[] InputArray2 = { 0.0d, 0.5d, 1.0d };
    foreach (Double n in InputArray1) {
    foreach (Double m in InputArray2) {
        Console.WriteLine("<H2 Title=" + "\"" + "m_elliptic_pi(n, m); n={0}, m={1}" 
            + "\"" + ">", n, m);
        Double res01 = math53.m_elliptic_pi(n, m);
        Console.WriteLine("math53:  {0}", res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Single res08 = sflint.m_elliptic_pi(n, m);
        Console.WriteLine("sflint:  {0}", res08);
        Double res09 = dflint.m_elliptic_pi(n, m);
        Console.WriteLine("dflint:  {0}", res09);
        Extended res10 = eflint.m_elliptic_pi(n, m);
        Console.WriteLine("eflint:  {0}", res10);
        Quadruple res11 = qflint.m_elliptic_pi(n, m);
        Console.WriteLine("qflint:  {0}", res11);
        Octuple res12 = oflint.m_elliptic_pi(n, m);
        Console.WriteLine("oflint:  {0}", res12);
        Mpfr res13 = mflint.m_elliptic_pi(n, m);
        Console.WriteLine("mflint:  {0}", res13);
        Arb res16 = aflint.m_elliptic_pi(n, m);
        Console.WriteLine("aflint: {0}", res16);
#endif
    Console.WriteLine("</H2>");
    Console.WriteLine();
    } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestMEllipticPiCplx

public static void TestMEllipticPiCplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestMEllipticPiCplx" + "\"" + ">");
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    Complex[] InputArray2C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    foreach (Complex n in InputArray1C) {
    foreach (Complex m in InputArray2C) {
        Console.WriteLine("<H2 Title=" + "\"" + "m_elliptic_pi(n, m); n={0}, m={1}" 
        + "\"" + ">", n, m);
        Complex res01 = cmath53.m_elliptic_pi(n, m);
        Console.WriteLine("cmath53:  {0}", res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08 = sflintc.m_elliptic_pi(n, m);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.m_elliptic_pi(n, m);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.m_elliptic_pi(n, m);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.m_elliptic_pi(n, m);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.m_elliptic_pi(n, m);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.m_elliptic_pi(n, m);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.m_elliptic_pi(n, m);
        Console.WriteLine("aflintc: {0}", res16);
#endif
    Console.WriteLine("</H2>");
    Console.WriteLine();
    } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestMEllipticPiRealImag

public static void TestMEllipticPiRealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestMEllipticPiRealImag" + "\"" + ">");
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    Complex[] InputArray2C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    foreach (Complex n in InputArray1C) {
    foreach (Complex m in InputArray2C) {
    foreach (var IsReal in ReImArray) {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "m_elliptic_pi(n, m)); n={0}, m={1}" 
            + "\"" + ">", n, m);

        Complex res01c = cmath53.m_elliptic_pi(n, m);
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08c = sflintc.m_elliptic_pi(n, m);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.m_elliptic_pi(n, m);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.m_elliptic_pi(n, m);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.m_elliptic_pi(n, m);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.m_elliptic_pi(n, m);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.m_elliptic_pi(n, m);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.m_elliptic_pi(n, m);
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

