
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
    Test_Real_Ibetac_Invb();
}


#region Test_Real_Ibetac_Invb

public static void Test_Real_Ibetac_Invb()
{
    Console.WriteLine("<H1 Title=" + "\"" + "Test_Real_Ibetac_Invb" + "\"" + ">");

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
    ArbPrec.SetDps(40);
#endif

    Double[] InputArray1 = { 1.5d, 12.5d, 441d, 713.5d };  // a > 0.0
    Double[] InputArray2 = { 0.1d, 0.5d, 0.7d }; // 0 < x < 1
    Double[] InputArray3 = { 0.01d, 0.5d, 1.0d - 0.001d }; // 0 < p < 1
    foreach (Double a in InputArray1) {
    foreach (Double x in InputArray2) {
    foreach (Double p in InputArray3) {
        Console.WriteLine("<H2 Title=" + "\"" + "a={0}, x={1}, p={2}" + "\"" 
            + ">", a, x, p);
        Double res01 = math53.ibetac_invb(a, x, p);
        Console.WriteLine("math53: ibetac_invb(a, x, p) =  {0}", res01);
        Single res02 = sreal.ibetac_invb(a, x, p);
        Console.WriteLine(" sreal: ibetac_invb(a, x, p) =  {0}", res02);
        Double res03 = dreal.ibetac_invb(a, x, p);
        Console.WriteLine(" dreal: ibetac_invb(a, x, p) =  {0}", res03);
        Extended res04 = ereal.ibetac_invb(a, x, p);
        Console.WriteLine(" ereal: ibetac_invb(a, x, p) =  {0}", res04);
        Quadruple res05 = qreal.ibetac_invb(a, x, p);
        Console.WriteLine(" qreal: ibetac_invb(a, x, p) =  {0}", res05);
        Octuple res06 = oreal.ibetac_invb(a, x, p);
        Console.WriteLine(" oreal: ibetac_invb(a, x, p) =  {0}", res06);

#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Mpfr res07 = mreal.ibetac_invb(a, x, p);
        Console.WriteLine(" mreal: ibetac_invb(a, x, p) =  {0}", res07);
//        Single res08 = sflint.ibetac_invb(a, x, p);
//        Console.WriteLine("sflint: ibetac_invb(a, x, p) =  {0}", res08);
//        Double res09 = dflint.ibetac_invb(a, x, p);
//        Console.WriteLine("dflint: ibetac_invb(a, x, p) =  {0}", res09);
//        Extended res10 = eflint.ibetac_invb(a, x, p);
//        Console.WriteLine("eflint: ibetac_invb(a, x, p) =  {0}", res10);
//        Quadruple res11 = qflint.ibetac_invb(a, x, p);
//        Console.WriteLine("qflint: ibetac_invb(a, x, p) =  {0}", res11);
//        Octuple res12 = oflint.ibetac_invb(a, x, p);
//        Console.WriteLine("oflint: ibetac_invb(a, x, p) =  {0}", res12);
//        Mpfr res13 = mflint.ibetac_invb(a, x, p);
//        Console.WriteLine("mflint: ibetac_invb(a, x, p) =  {0}", res13);
//        Arb res16 = aflint.ibetac_invb(a, x, p);
//        Console.WriteLine("aflint: ibetac_invb(a, x, p) = {0}", res16);
#endif
    Console.WriteLine();
    Console.WriteLine("</H2>");
    } } }
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

