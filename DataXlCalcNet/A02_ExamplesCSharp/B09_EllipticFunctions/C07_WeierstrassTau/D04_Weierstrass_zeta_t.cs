
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
    TestWeierstrassZetaTauCplx();
    TestWeierstrassZetaTauRealImag();
}


#region TestWeierstrassZetaTauCplx

public static void TestWeierstrassZetaTauCplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestWeierstrassZetaTauCplx" + "\"" + ">");
    Complex[] InputArray1C = { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), 
        dcplx.t(4.333d, 2) };   // x
    Complex[] InputArray2C = { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), 
        dcplx.t(0.333d, 0.22) };  // tau
    foreach (Complex x in InputArray1C) {
    foreach (Complex tau in InputArray2C) {
        Console.WriteLine("<H2 Title=" + "\"" + "weierstrass_zeta_t(x, tau); x={0}, tau={1}" 
        + "\"" + ">", x, tau);
        Complex res01 = cmath53.weierstrass_zeta_t(x, tau);
        Console.WriteLine("cmath53:  {0}", res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08 = sflintc.weierstrass_zeta_t(x, tau);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.weierstrass_zeta_t(x, tau);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.weierstrass_zeta_t(x, tau);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.weierstrass_zeta_t(x, tau);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.weierstrass_zeta_t(x, tau);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.weierstrass_zeta_t(x, tau);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.weierstrass_zeta_t(x, tau);
        Console.WriteLine("aflintc: {0}", res16);
#endif
    Console.WriteLine("</H2>");
    Console.WriteLine();
    } }
    Console.WriteLine("</H1>");
}

#endregion


#region TestWeierstrassZetaTauRealImag

public static void TestWeierstrassZetaTauRealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestWeierstrassZetaTauRealImag" + "\"" + ">");
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = { dcplx.t(1.0d, 2), dcplx.t(1.5d, 2), 
        dcplx.t(4.333d, 2) };   // x
    Complex[] InputArray2C = { dcplx.t(0.0d, 0.2), dcplx.t(0.5d, 0.22), 
        dcplx.t(0.333d, 0.22) };  // tau
    foreach (Complex x in InputArray1C) {
    foreach (Complex tau in InputArray2C) {
    foreach (var IsReal in ReImArray) {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "weierstrass_zeta_t(x, tau)); x={0}, tau={1}" 
            + "\"" + ">", x, tau);

        Complex res01c = cmath53.weierstrass_zeta_t(x, tau);
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        SingleC res08c = sflintc.weierstrass_zeta_t(x, tau);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.weierstrass_zeta_t(x, tau);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.weierstrass_zeta_t(x, tau);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.weierstrass_zeta_t(x, tau);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.weierstrass_zeta_t(x, tau);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.weierstrass_zeta_t(x, tau);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.weierstrass_zeta_t(x, tau);
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

