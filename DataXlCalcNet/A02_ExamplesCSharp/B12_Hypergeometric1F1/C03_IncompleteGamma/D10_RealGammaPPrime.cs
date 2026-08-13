
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
    Test_Real_Gamma_P_Prime();
}


#region Test_Real_Gamma_P_Prime

public static void Test_Real_Gamma_P_Prime()
{
    Console.WriteLine("<H1 Title=" + "\"" + "Test_Real_Gamma_P_Prime" + "\"" + ">");

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    ArbPrec.SetDps(40);
#endif

    Double[] InputArray1 = { 1.0d, 1.5d, 4.333d };
    Double[] InputArray2 = { 1.0d, 1.5d, 4.333d };
    foreach (Double a in InputArray1) {
    foreach (Double x in InputArray2) {
        Console.WriteLine("<H2 Title=" + "\"" + "a={0}, x={1}" + "\"" + ">", 
            a, x);
        Double res01 = math53.gamma_p_prime(a, x);
        Console.WriteLine("math53: gamma_p_prime(a, x) =  {0}", res01);
        Single res02 = sreal.gamma_p_prime(a, x);
        Console.WriteLine(" sreal: gamma_p_prime(a, x) =  {0}", res02);
        Double res03 = dreal.gamma_p_prime(a, x);
        Console.WriteLine(" dreal: gamma_p_prime(a, x) =  {0}", res03);
        Extended res04 = ereal.gamma_p_prime(a, x);
        Console.WriteLine(" ereal: gamma_p_prime(a, x) =  {0}", res04);
        Quadruple res05 = qreal.gamma_p_prime(a, x);
        Console.WriteLine(" qreal: gamma_p_prime(a, x) =  {0}", res05);
        Octuple res06 = oreal.gamma_p_prime(a, x);
        Console.WriteLine(" oreal: gamma_p_prime(a, x) =  {0}", res06);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Mpfr res07 = mreal.gamma_p_prime(a, x);
        Console.WriteLine(" mreal: gamma_p_prime(a, x) =  {0}", res07);
//        Single res08 = sflint.gamma_p_prime(a, x);
//        Console.WriteLine("sflint: gamma_p_prime(a, x) =  {0}", res08);
//        Double res09 = dflint.gamma_p_prime(a, x);
//        Console.WriteLine("dflint: gamma_p_prime(a, x) =  {0}", res09);
//        Extended res10 = eflint.gamma_p_prime(a, x);
//        Console.WriteLine("eflint: gamma_p_prime(a, x) =  {0}", res10);
//        Quadruple res11 = qflint.gamma_p_prime(a, x);
//        Console.WriteLine("qflint: gamma_p_prime(a, x) =  {0}", res11);
//        Octuple res12 = oflint.gamma_p_prime(a, x);
//        Console.WriteLine("oflint: gamma_p_prime(a, x) =  {0}", res12);
//        Mpfr res13 = mflint.gamma_p_prime(a, x);
//        Console.WriteLine("mflint: gamma_p_prime(a, x) =  {0}", res13);
        Arb res16 = aflint.gamma_p_prime(a, x);
        Console.WriteLine("aflint: gamma_p_prime(a, x) = {0}", res16);
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

