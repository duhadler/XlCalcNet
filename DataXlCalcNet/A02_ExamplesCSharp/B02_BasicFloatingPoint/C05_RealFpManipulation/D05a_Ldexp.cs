
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
    TestLdexp();
}


#region TestLdexp

public static void TestLdexp()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestLdexp" + "\"" + ">");

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    ArbPrec.SetDps(40);
#endif

    Double[] InputArray1 = { -4.333, 0.0, 4.333000001 };
    Int32[] InputArray2 = { -2, 0, 4 };
    foreach (Double x in InputArray1) {
    foreach (Int32 e in InputArray2) {
        Console.WriteLine("<H2 Title=" + "\"" + "x={0}, e={1}" + "\"" + ">", 
            x, e);
        Double res01 = math53.ldexp(x, e);
        Console.WriteLine("math53: ldexp(x, e) =  {0}", res01);
        Single res02 = sreal.ldexp(x, e);
        Console.WriteLine(" sreal: ldexp(x, e) =  {0}", res02);
        Double res03 = dreal.ldexp(x, e);
        Console.WriteLine(" dreal: ldexp(x, e) =  {0}", res03);
        Extended res04 = ereal.ldexp(x, e);
        Console.WriteLine(" ereal: ldexp(x, e) =  {0}", res04);
        Quadruple res05 = qreal.ldexp(x, e);
        Console.WriteLine(" qreal: ldexp(x, e) =  {0}", res05);
        Octuple res06 = oreal.ldexp(x, e);
        Console.WriteLine(" oreal: ldexp(x, e) =  {0}", res06);

#if HasArbPrecNet
/* No sentax highlighting if HasArbPrecNet is undefined */
        Mpfr res07 = mreal.ldexp(x, e);
        Console.WriteLine(" mreal: ldexp(x, e) =  {0}", res07);
        Single res08 = sflint.ldexp(x, e);
        Console.WriteLine("sflint: ldexp(x, e) =  {0}", res08);
        Double res09 = dflint.ldexp(x, e);
        Console.WriteLine("dflint: ldexp(x, e) =  {0}", res09);
        Extended res10 = eflint.ldexp(x, e);
        Console.WriteLine("eflint: ldexp(x, e) =  {0}", res10);
        Quadruple res11 = qflint.ldexp(x, e);
        Console.WriteLine("qflint: ldexp(x, e) =  {0}", res11);
        Octuple res12 = oflint.ldexp(x, e);
        Console.WriteLine("oflint: ldexp(x, e) =  {0}", res12);
        Mpfr res13 = mflint.ldexp(x, e);
        Console.WriteLine("mflint: ldexp(x, e) =  {0}", res13);
        Arb res16 = aflint.ldexp(x, e);
        Console.WriteLine("aflint: ldexp(x, e) = {0}", res16);
#endif
    Console.WriteLine();
    Console.WriteLine("</H2>");
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

