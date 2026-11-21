
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
    TestGegenbauerCReal();
    TestGegenbauerCCplx();
    TestGegenbauerCRealImag();
}


#region TestGegenbauerCReal

public static void TestGegenbauerCReal()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestGegenbauerCReal" + "\"" + ">");
    int[] InputArray1 = { 0, 1, 2, 4, 6, 8, 10 };
    Double[] InputArray2 = { -0.333d, 0.0d, 0.333d };
    Double[] InputArray3 = { -0.333d, 0.0d, 0.333d };
    foreach (int n in InputArray1) {
    foreach (Double lambda1 in InputArray2) {
    foreach (Double x in InputArray3) {
        Console.WriteLine("<H2 Title=" + "\"" + "gegenbauer_c(n, lambda1, x); " + 
            "n={0}, lambda1={1}, x={2}" + "\"" + ">", n, lambda1, x);
        Double res01 = math53.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("math53:  {0}", res01);
        Single res02 = sreal.gegenbauer_c(n, lambda1, x);
        Console.WriteLine(" sreal:  {0}", res02);
        Double res03 = dreal.gegenbauer_c(n, lambda1, x);
        Console.WriteLine(" dreal:  {0}", res03);
        Extended res04 = ereal.gegenbauer_c(n, lambda1, x);
        Console.WriteLine(" ereal:  {0}", res04);
        Quadruple res05 = qreal.gegenbauer_c(n, lambda1, x);
        Console.WriteLine(" qreal:  {0}", res05);
        Octuple res06 = oreal.gegenbauer_c(n, lambda1, x);
        Console.WriteLine(" oreal:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Mpfr res07 = mreal.gegenbauer_c(n, lambda1, x);
        Console.WriteLine(" mreal:  {0}", res07);
        Single res08 = sflint.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("sflint:  {0}", res08);
        Double res09 = dflint.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("dflint:  {0}", res09);
        Extended res10 = eflint.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("eflint:  {0}", res10);
        Quadruple res11 = qflint.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("qflint:  {0}", res11);
        Octuple res12 = oflint.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("oflint:  {0}", res12);
        Mpfr res13 = mflint.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("mflint:  {0}", res13);
        Arb res16 = aflint.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("aflint: {0}", res16);
#endif
    Console.WriteLine("</H2>");
    Console.WriteLine();
    } } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestGegenbauerCCplx

public static void TestGegenbauerCCplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestGegenbauerCCplx" + "\"" + ">");
    Complex[] InputArray1C = { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), 
        dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
    Complex[] InputArray2C = { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), 
        dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
    Complex[] InputArray3C = {dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), 
        dcplx.t(1.5d, 2)  };
    foreach (Complex n in InputArray1C) {
    foreach (Complex lambda1 in InputArray2C) {
    foreach (Complex x in InputArray3C) {
        Console.WriteLine("<H2 Title=" + "\"" + "gegenbauer_c(n, lambda1, x); " + 
                "n={0}, lambda1={1}, x={2}" + "\"" + ">", n, lambda1, x);
        Complex res01 = cmath53.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("cmath53:  {0}", res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08 = sflintc.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.gegenbauer_c(n, lambda1, x);
        Console.WriteLine("aflintc: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    } } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestGegenbauerCRealImag

public static void TestGegenbauerCRealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestGegenbauerCRealImag" + "\"" 
        + ">");
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = { 1.5d, 2.5d, 13.5d, dcplx.t(1.5d, 2), 
        dcplx.t(2.5d, 2), dcplx.t(13.5d, 2) };
    Complex[] InputArray2C = { 2.000000001d, 12.1d, 53.5d, dcplx.t(2.1d, 2), 
        dcplx.t(12.1d, 2), dcplx.t(53.5d, 2) };
    Complex[] InputArray3C = {dcplx.t(-1.5d, 2), dcplx.t(0.0d, 2), 
        dcplx.t(1.5d, 2)  };
    foreach (Complex n in InputArray1C) {
    foreach (Complex lambda1 in InputArray2C) {
    foreach (Complex x in InputArray3C) {
    foreach (var IsReal in ReImArray){
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "gegenbauer_c(n, lambda1, x));"
            + " n={0}, lambda1={1}, x={2}" + "\"" + ">", n, lambda1, x);

        Complex res01c = cmath53.gegenbauer_c(n, lambda1, x);
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08c = sflintc.gegenbauer_c(n, lambda1, x);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.gegenbauer_c(n, lambda1, x);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.gegenbauer_c(n, lambda1, x);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.gegenbauer_c(n, lambda1, x);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.gegenbauer_c(n, lambda1, x);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.gegenbauer_c(n, lambda1, x);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.gegenbauer_c(n, lambda1, x);
        Arb res16 = IsReal ? res16c.real : res16c.imag;
        Console.WriteLine("aflintc: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    } } } }
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
        Console.WriteLine("Memory used before collection:      {0:N0}", 
            GC.GetTotalMemory(false));
        GC.Collect();
        Console.WriteLine("Memory used after full collection:  {0:N0}", 
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

