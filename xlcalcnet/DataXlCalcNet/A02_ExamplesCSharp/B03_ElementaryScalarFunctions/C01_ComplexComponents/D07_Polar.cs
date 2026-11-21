
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
    TestPolarReal();
    TestPolarCplx();
//    TestPolarRealImag();
}


#region TestPolarReal

public static void TestPolarReal()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestPolarReal" + "\"" + ">");
    double[] InputArray1 = { -4.333, 0.0, 4.333 };
    
    foreach (var x in InputArray1) {
    Console.WriteLine("<H2 Title=" + "\"" + "polar(x); " + "x={0}" + "\"" + ">", x);
    var res01 = math53.polar(x);
    Console.WriteLine("math53:  {0}", res01);
    var res02 = sreal.polar(x);
    Console.WriteLine(" sreal:  {0}", res02);
    var res03 = dreal.polar(x);
    Console.WriteLine(" dreal:  {0}", res03);
    var res04 = ereal.polar(x);
    Console.WriteLine(" ereal:  {0}", res04);
    var res05 = qreal.polar(x);
    Console.WriteLine(" qreal:  {0}", res05);
    var res06 = oreal.polar(x);
    Console.WriteLine(" oreal:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    var res07 = mreal.polar(x);
    Console.WriteLine(" mreal:  {0}", res07);
    var res08 = sflint.polar(x);
    Console.WriteLine("sflint:  {0}", res08);
    var res09 = dflint.polar(x);
    Console.WriteLine("dflint:  {0}", res09);
    var res10 = eflint.polar(x);
    Console.WriteLine("eflint:  {0}", res10);
    var res11 = qflint.polar(x);
    Console.WriteLine("qflint:  {0}", res11);
    var res12 = oflint.polar(x);
    Console.WriteLine("oflint:  {0}", res12);
    var res13 = mflint.polar(x);
    Console.WriteLine("mflint:  {0}", res13);
    var res16 = aflint.polar(x);
    Console.WriteLine("aflint: {0}", res16);
#endif

    Console.WriteLine("</H2>");
    Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestPolarCplx

public static void TestPolarCplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestPolarCplx" + "\"" + ">");
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};

    foreach (var x in InputArray1C) {
    Console.WriteLine("<H2 Title=" + "\"" + "polar(x); " + "x={0}" + "\"" + ">", x);
    var res01 = cmath53.polar(x);
    Console.WriteLine("cmath53:  {0}", res01);
    var res02 = scplx.polar(x);
    Console.WriteLine("  scplx:  {0}", res02);
    var res03 = dcplx.polar(x);
    Console.WriteLine("  dcplx:  {0}", res03);
    var res04 = ecplx.polar(x);
    Console.WriteLine("  ecplx:  {0}", res04);
    var res05 = qcplx.polar(x);
    Console.WriteLine("  qcplx:  {0}", res05);
    var res06 = ocplx.polar(x);
    Console.WriteLine("  ocplx:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    var res07 = mcplx.polar(x);
    Console.WriteLine("  mcplx:  {0}", res07);
    var res08 = sflintc.polar(x);
    Console.WriteLine("sflintc:  {0}", res08);
    var res09 = dflintc.polar(x);
    Console.WriteLine("dflintc:  {0}", res09);
    var res10 = eflintc.polar(x);
    Console.WriteLine("eflintc:  {0}", res10);
    var res11 = qflintc.polar(x);
    Console.WriteLine("qflintc:  {0}", res11);
    var res12 = oflintc.polar(x);
    Console.WriteLine("oflintc:  {0}", res12);
    var res13 = mflintc.polar(x);
    Console.WriteLine("mflintc:  {0}", res13);
    var res16 = aflintc.polar(x);
    Console.WriteLine("aflintc: {0}", res16);
#endif

    Console.WriteLine("</H2>");
    Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestPolarRealImag

//public static void TestPolarRealImag()
//{
//    Console.WriteLine("<H1 Title=" + "\"" + "TestPolarRealImag" + "\"" + ">");
//    bool[] ReImArray = {true, false};
//    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
//        dcplx.t(4.333, 1.0)};
//    foreach (var x in InputArray1C) {
//    foreach (var IsReal in ReImArray)
//    {
//        string ReIm = IsReal ? "Re(" : "Im(";
//        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "polar(x)); x={0}" + "\"" + ">", x);
//
//        Complex res01c = cmath53.polar(x); 
//        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
//        Console.WriteLine("cmath53:  {0}", res01);
//
//        SingleC res02c = scplx.polar(x);
//        Single res02 = IsReal ? res02c.real : res02c.imag;
//        Console.WriteLine("  scplx:  {0}", res02);
//
//        Complex res03c = dcplx.polar(x);
//        Double res03 = IsReal ? res03c.Real : res03c.Imaginary;
//        Console.WriteLine("  dcplx:  {0}", res03);
//
//        ExtendedC res04c = ecplx.polar(x);
//        Extended res04 = IsReal ? res04c.real : res04c.imag;
//        Console.WriteLine("  ecplx:  {0}", res04);
//
//        QuadrupleC res05c = qcplx.polar(x);
//        Quadruple res05 = IsReal ? res05c.real : res05c.imag;
//        Console.WriteLine("  qcplx:  {0}", res05);
//
//        OctupleC res06c = ocplx.polar(x);
//        Octuple res06 = IsReal ? res06c.real : res06c.imag;
//        Console.WriteLine("  ocplx:  {0}", res06);
//
//#if HasArbPrecNet
//        MpfrC res07c = mcplx.polar(x);
//        Mpfr res07 = IsReal ? res07c.real : res07c.imag;
//        Console.WriteLine("  mcplx:  {0}", res07);
//
//        SingleC res08c = sflintc.polar(x);
//        Single res08 = IsReal ? res08c.real : res08c.imag;
//        Console.WriteLine("sflintc:  {0}", res08);
//
//        Complex res09c = dflintc.polar(x);
//        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
//        Console.WriteLine("dflintc:  {0}", res09);
//
//        ExtendedC res10c = eflintc.polar(x);
//        Extended res10 = IsReal ? res10c.real : res10c.imag;
//        Console.WriteLine("eflintc:  {0}", res10);
//
//        QuadrupleC res11c = qflintc.polar(x);
//        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
//        Console.WriteLine("qflintc:  {0}", res11);
//
//        OctupleC res12c = oflintc.polar(x);
//        Octuple res12 = IsReal ? res12c.real : res12c.imag;
//        Console.WriteLine("oflintc:  {0}", res12);
//
//        MpfrC res13c = mflintc.polar(x);
//        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
//        Console.WriteLine("mflintc:  {0}", res13);
//
//        ArbC res16c = aflintc.polar(x);
//        Arb res16 = IsReal ? res16c.real : res16c.imag;
//        Console.WriteLine("aflintc: {0}", res16);
//#endif
//
//    Console.WriteLine("</H2>");
//    Console.WriteLine();
//    }
//    }
//    Console.WriteLine("</H1>");
//}

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

