
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
    Test_Llround();
}


#region Test_Llround

public static void Test_Llround()
{
    Console.WriteLine("<H1 Title=" + "\"" + "Test_Llround" + "\"" + ">");
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    ArbPrec.SetDps(40);
#endif
    double[] InputArray1 = { -4.333, 0.0, 4.333 };
    foreach (var x in InputArray1)
    {
        Int64 res01 = math53.llround(x);
        Console.WriteLine("math53: llround(x={0}):  {1}", x, res01);
        Int64 res02 = sreal.llround(x);
        Console.WriteLine(" sreal: llround(x={0}):  {1}", x, res02);
        Int64 res03 = dreal.llround(x);
        Console.WriteLine(" dreal: llround(x={0}):  {1}", x, res03);
        Int64 res04 = ereal.llround(x);
        Console.WriteLine(" ereal: llround(x={0}):  {1}", x, res04);
        Int64 res05 = qreal.llround(x);
        Console.WriteLine(" qreal: llround(x={0}):  {1}", x, res05);
        Int64 res06 = oreal.llround(x);
        Console.WriteLine(" oreal: llround(x={0}):  {1}", x, res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Int64 res07 = mreal.llround(x);
        Console.WriteLine(" mreal: llround(x={0}):  {1}", x, res07);
        Int64 res08 = sflint.llround(x);
        Console.WriteLine("sflint: llround(x={0}):  {1}", x, res08);
        Int64 res09 = dflint.llround(x);
        Console.WriteLine("dflint: llround(x={0}):  {1}", x, res09);
        Int64 res10 = eflint.llround(x);
        Console.WriteLine("eflint: llround(x={0}):  {1}", x, res10);
        Int64 res11 = qflint.llround(x);
        Console.WriteLine("qflint: llround(x={0}):  {1}", x, res11);
        Int64 res12 = oflint.llround(x);
        Console.WriteLine("oflint: llround(x={0}):  {1}", x, res12);
        Int64 res13 = mflint.llround(x);
        Console.WriteLine("mflint: llround(x={0}):  {1}", x, res13);
        Int64 res16 = aflint.llround(x);
        Console.WriteLine("aflint: llround(x={0}): {1}", x, res16);
#endif
        Console.WriteLine();
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

