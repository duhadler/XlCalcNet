
/* If defined includes code requiring UserFixedPrecNet. Is set automatically */
#define HasUserFixedPrecNet

/* If defined includes code requiring ArbPrecNet. Is set automatically */
#define HasArbPrecNet

/* If defined includes code requiring UserArbPrecNet. Is set automatically */
#define HasUserArbPrecNet


#region Usings
using System;
using System.Numerics;
using FixedPrecNet;
#if HasUserFixedPrecNet
/* No syntax highlighting if HasUserFixedPrecNet is undefined */
using UserFixedPrecNet;
#endif
#if HasArbPrecNet
/* No syntax highlighting if HasUserArbPrecNet is undefined */
using ArbPrecNet;
#endif
#if HasUserArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
using UserArbPrecNet;
#endif
#endregion


static class Program
{

public static void MainTests()
{
    Test_Sin_Real();
    Test_Sin_Cplx();
    Test_Sin_Cplx_Real_Imag();
}


#region Test_Sin_Real

public static void Test_Sin_Real()
{
    Console.WriteLine("<H1 Title=" + "\"" + "Test_Sin_Real" + "\"" + ">");
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    ArbPrec.SetDps(40);
#endif
    double[] InputArray1 = { -4.333, 0.0, 4.333 };
    foreach (var x in InputArray1)
    {
        Double res01 = m53lib.sin(x);
        Console.WriteLine(" m53lib: sin(x={0}):  {1}", x, res01);
        Single res02 = slib.sin(x);
        Console.WriteLine("   slib: sin(x={0}):  {1}", x, res02);
        Double res03 = dlib.sin(x);
        Console.WriteLine("   dlib: sin(x={0}):  {1}", x, res03);
        Extended res04 = elib.sin(x);
        Console.WriteLine("   elib: sin(x={0}):  {1}", x, res04);
        Quadruple res05 = qlib.sin(x);
        Console.WriteLine("   qlib: sin(x={0}):  {1}", x, res05);
        Octuple res06 = olib.sin(x);
        Console.WriteLine("   olib: sin(x={0}):  {1}", x, res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Mpfr res07 = mlib.sin(x);
        Console.WriteLine("   mlib: sin(x={0}):  {1}", x, res07);
        Single res08 = sflib.sin(x);
        Console.WriteLine("  sflib: sin(x={0}):  {1}", x, res08);
        Double res09 = dflib.sin(x);
        Console.WriteLine("  dflib: sin(x={0}):  {1}", x, res09);
        Extended res10 = eflib.sin(x);
        Console.WriteLine("  eflib: sin(x={0}):  {1}", x, res10);
        Quadruple res11 = qflib.sin(x);
        Console.WriteLine("  qflib: sin(x={0}):  {1}", x, res11);
        Octuple res12 = oflib.sin(x);
        Console.WriteLine("  oflib: sin(x={0}):  {1}", x, res12);
        Mpfr res13 = mflib.sin(x);
        Console.WriteLine("  mflib: sin(x={0}):  {1}", x, res13);
        Arb res16 = aflib.sin(x);
        Console.WriteLine("  aflib: sin(x={0}): {1}", x, res16);
#endif
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region Test_Sin_Cplx

public static void Test_Sin_Cplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "Test_Sin_Cplx" + "\"" + ">");
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    ArbPrec.SetDps(40);
#endif
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    foreach (var x in InputArray1C)
    {
        Complex res01 = m53libc.sin(x);
        Console.WriteLine("m53libc: sin(x={0}):  {1}", x, res01);
        SingleC res02 = slibc.sin(x);
        Console.WriteLine("  slibc: sin(x={0}):  {1}", x, res02);
        Complex res03 = dlibc.sin(x);
        Console.WriteLine("  dlibc: sin(x={0}):  {1}", x, res03);
        ExtendedC res04 = elibc.sin(x);
        Console.WriteLine("  elibc: sin(x={0}):  {1}", x, res04);
        QuadrupleC res05 = qlibc.sin(x);
        Console.WriteLine("  qlibc: sin(x={0}):  {1}", x, res05);
        OctupleC res06 = olibc.sin(x);
        Console.WriteLine("  olibc: sin(x={0}):  {1}", x, res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        MpfrC res07 = mlibc.sin(x);
        Console.WriteLine("  mlibc: sin(x={0}):  {1}", x, res07);
        SingleC res08 = sflibc.sin(x);
        Console.WriteLine(" sflibc: sin(x={0}):  {1}", x, res08);
        Complex res09 = dflibc.sin(x);
        Console.WriteLine(" dflibc: sin(x={0}):  {1}", x, res09);
        ExtendedC res10 = eflibc.sin(x);
        Console.WriteLine(" eflibc: sin(x={0}):  {1}", x, res10);
        QuadrupleC res11 = qflibc.sin(x);
        Console.WriteLine(" qflibc: sin(x={0}):  {1}", x, res11);
        OctupleC res12 = oflibc.sin(x);
        Console.WriteLine(" oflibc: sin(x={0}):  {1}", x, res12);
        MpfrC res13 = mflibc.sin(x);
        Console.WriteLine(" mflibc: sin(x={0}):  {1}", x, res13);
        ArbC res16 = aflibc.sin(x);
        Console.WriteLine(" aflibc: sin(x={0}): {1}", x, res16);
#endif
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region Test_Sin_Cplx_Real_Imag

public static void Test_Sin_Cplx_Real_Imag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "Test_Sin_Cplx_Real_Imag" + "\"" + ">");
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    ArbPrec.SetDps(40);
#endif
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    foreach (var x in InputArray1C)
    {
    foreach (var IsReal in ReImArray)
    {
        string ReIm = IsReal ? "Re(" : "Im(";

        Complex res01c = m53libc.sin(x); 
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("m53libc: " + ReIm + "sin(x={0})):  {1}", x, res01);

        SingleC res02c = slibc.sin(x);
        Single res02 = IsReal ? res02c.real : res02c.imag;
        Console.WriteLine("  slibc: " + ReIm + "sin(x={0})):  {1}", x, res02);

        Complex res03c = dlibc.sin(x);
        Double res03 = IsReal ? res03c.Real : res03c.Imaginary;
        Console.WriteLine("  dlibc: " + ReIm + "sin(x={0})):  {1}", x, res03);

        ExtendedC res04c = elibc.sin(x);
        Extended res04 = IsReal ? res04c.real : res04c.imag;
        Console.WriteLine("  elibc: " + ReIm + "sin(x={0})):  {1}", x, res04);

        QuadrupleC res05c = qlibc.sin(x);
        Quadruple res05 = IsReal ? res05c.real : res05c.imag;
        Console.WriteLine("  qlibc: " + ReIm + "sin(x={0})):  {1}", x, res05);

        OctupleC res06c = olibc.sin(x);
        Octuple res06 = IsReal ? res06c.real : res06c.imag;
        Console.WriteLine("  olibc: " + ReIm + "sin(x={0})):  {1}", x, res06);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        MpfrC res07c = mlibc.sin(x);
        Mpfr res07 = IsReal ? res07c.real : res07c.imag;
        Console.WriteLine("  mlibc: " + ReIm + "sin(x={0})):  {1}", x, res07);

        SingleC res08c = sflibc.sin(x);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine(" sflibc: " + ReIm + "sin(x={0})):  {1}", x, res08);

        Complex res09c = dflibc.sin(x);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine(" dflibc: " + ReIm + "sin(x={0})):  {1}", x, res09);

        ExtendedC res10c = eflibc.sin(x);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine(" eflibc: " + ReIm + "sin(x={0})):  {1}", x, res10);

        QuadrupleC res11c = qflibc.sin(x);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine(" qflibc: " + ReIm + "sin(x={0})):  {1}", x, res11);

        OctupleC res12c = oflibc.sin(x);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine(" oflibc: " + ReIm + "sin(x={0})):  {1}", x, res12);

        MpfrC res13c = mflibc.sin(x);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine(" mflibc: " + ReIm + "sin(x={0})):  {1}", x, res13);

        ArbC res16c = aflibc.sin(x);
        Arb res16 = IsReal ? res16c.real : res16c.imag;
        Console.WriteLine(" aflibc: " + ReIm + "sin(x={0})): {1}", x, res16);
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



