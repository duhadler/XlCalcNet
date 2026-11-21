
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
    TestHyperg0F1rReal();
    TestHyperg0F1rCplxRp(); //real parameter b 
    TestHyperg0F1rRealImagRp(); //real parameter b 
    TestHyperg0F1rCplx();
    TestHyperg0F1rRealImag();
}


#region TestHyperg0F1rReal

public static void TestHyperg0F1rReal()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestHyperg0F1rReal" + "\"" + ">");
    Double[] InputArray1 = { 0.0d, 0.75d, 1.5d };
    Double[] InputArray2 = { 0.0d, 0.5d, 1.0d };
    foreach (Double b in InputArray1) {
    foreach (Double x in InputArray2) {
        Console.WriteLine("<H2 Title=" + "\"" + "hyperg_0f1r(b, x); b={0}, x={1}" 
            + "\"" + ">", b, x);
        Double res01 = math53.hyperg_0f1r(b, x);
        Console.WriteLine("math53:  {0}", res01);
        Single res02 = sreal.hyperg_0f1r(b, x);
        Console.WriteLine(" sreal:  {0}", res02);
        Double res03 = dreal.hyperg_0f1r(b, x);
        Console.WriteLine(" dreal:  {0}", res03);
        Extended res04 = ereal.hyperg_0f1r(b, x);
        Console.WriteLine(" ereal:  {0}", res04);
        Quadruple res05 = qreal.hyperg_0f1r(b, x);
        Console.WriteLine(" qreal:  {0}", res05);
        Octuple res06 = oreal.hyperg_0f1r(b, x);
        Console.WriteLine(" oreal:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Mpfr res07 = mreal.hyperg_0f1r(b, x);
        Console.WriteLine(" mreal:  {0}", res07);
        Single res08 = sflint.hyperg_0f1r(b, x);
        Console.WriteLine("sflint:  {0}", res08);
        Double res09 = dflint.hyperg_0f1r(b, x);
        Console.WriteLine("dflint:  {0}", res09);
        Extended res10 = eflint.hyperg_0f1r(b, x);
        Console.WriteLine("eflint:  {0}", res10);
        Quadruple res11 = qflint.hyperg_0f1r(b, x);
        Console.WriteLine("qflint:  {0}", res11);
        Octuple res12 = oflint.hyperg_0f1r(b, x);
        Console.WriteLine("oflint:  {0}", res12);
        Mpfr res13 = mflint.hyperg_0f1r(b, x);
        Console.WriteLine("mflint:  {0}", res13);
        Arb res16 = aflint.hyperg_0f1r(b, x);
        Console.WriteLine("aflint: {0}", res16);
#endif
    Console.WriteLine("</H2>");
    Console.WriteLine();
    } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestHyperg0F1rCplxRp

public static void TestHyperg0F1rCplxRp()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestHyperg0F1rCplxRp" + "\"" + ">");
    Double[] InputArray1 = { 0.1, 0.75d, 1.5d };
    Complex[] InputArray2C = { dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), 
        dcplx.t(1.5d, 2) };
    foreach (Double b in InputArray1) {
    foreach (Complex x in InputArray2C) {
        Console.WriteLine("<H2 Title=" + "\"" + "hyperg_0f1r(b, x); b={0}, x={1}" 
        + "\"" + ">", b, x);
        Complex res01 = cmath53.hyperg_0f1r(b, x);
        Console.WriteLine("cmath53:  {0}", res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08 = sflintc.hyperg_0f1r(b, x);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.hyperg_0f1r(b, x);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.hyperg_0f1r(b, x);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.hyperg_0f1r(b, x);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.hyperg_0f1r(b, x);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.hyperg_0f1r(b, x);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.hyperg_0f1r(b, x);
        Console.WriteLine("aflintc: {0}", res16);
#endif
    Console.WriteLine("</H2>");
    Console.WriteLine();
    } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestHyperg0F1rRealImagRp

public static void TestHyperg0F1rRealImagRp()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestHyperg0F1rRealImagRp" + "\"" + ">");
    bool[] ReImArray = {true, false};
    Double[] InputArray1 = { 0.1, 0.75d, 1.5d };
    Complex[] InputArray2C = { dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), 
        dcplx.t(1.5d, 2) };
    foreach (Double b in InputArray1) {
    foreach (Complex x in InputArray2C) {
    foreach (var IsReal in ReImArray) {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "hyperg_0f1r(b, x)); b={0}, x={1}" 
            + "\"" + ">", b, x);

        Complex res01c = cmath53.hyperg_0f1r(b, x);
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08c = sflintc.hyperg_0f1r(b, x);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.hyperg_0f1r(b, x);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.hyperg_0f1r(b, x);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.hyperg_0f1r(b, x);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.hyperg_0f1r(b, x);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.hyperg_0f1r(b, x);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.hyperg_0f1r(b, x);
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


#region TestHyperg0F1rCplx

public static void TestHyperg0F1rCplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestHyperg0F1rCplx" + "\"" + ">");
    Complex[] InputArray1C = { dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), 
        dcplx.t(1.5d, 2) };
    Complex[] InputArray2C = { dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), 
        dcplx.t(1.5d, 2) };
    foreach (Complex b in InputArray1C) {
    foreach (Complex x in InputArray2C) {
        Console.WriteLine("<H2 Title=" + "\"" + "hyperg_0f1r(b, x); b={0}, x={1}" 
        + "\"" + ">", b, x);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08 = sflintc.hyperg_0f1r(b, x);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.hyperg_0f1r(b, x);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.hyperg_0f1r(b, x);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.hyperg_0f1r(b, x);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.hyperg_0f1r(b, x);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.hyperg_0f1r(b, x);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.hyperg_0f1r(b, x);
        Console.WriteLine("aflintc: {0}", res16);
#endif
    Console.WriteLine("</H2>");
    Console.WriteLine();
    } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestHyperg0F1rRealImag

public static void TestHyperg0F1rRealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestHyperg0F1rRealImag" + "\"" + ">");
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = { dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), 
        dcplx.t(1.5d, 2) };
    Complex[] InputArray2C = { dcplx.t(0.0d, 2), dcplx.t(0.75d, 2), 
        dcplx.t(1.5d, 2) };
    foreach (Complex b in InputArray1C) {
    foreach (Complex x in InputArray2C) {
    foreach (var IsReal in ReImArray) {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "hyperg_0f1r(b, x)); b={0}, x={1}" 
            + "\"" + ">", b, x);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08c = sflintc.hyperg_0f1r(b, x);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.hyperg_0f1r(b, x);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.hyperg_0f1r(b, x);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.hyperg_0f1r(b, x);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.hyperg_0f1r(b, x);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.hyperg_0f1r(b, x);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.hyperg_0f1r(b, x);
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

