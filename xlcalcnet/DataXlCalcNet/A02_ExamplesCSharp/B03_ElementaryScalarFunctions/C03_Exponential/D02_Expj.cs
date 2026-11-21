
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
    TestExpjReal();
    TestExpjCplx();
    TestExpjRealImag();
}


#region TestExpjReal

public static void TestExpjReal()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExpjReal" + "\"" + ">");
    double[] InputArray1 = { -4.333, 0.0, 4.333 };
    
    foreach (var x in InputArray1) {
        Console.WriteLine("<H2 Title=" + "\"" + "expj(x); " + "x={0}" 
            + "\"" + ">", x);
        Complex res01 = math53.expj(x);
        Console.WriteLine("math53:  {0}", res01);
        SingleC res02 = sreal.expj(x);
        Console.WriteLine(" sreal:  {0}", res02);
        Complex res03 = dreal.expj(x);
        Console.WriteLine(" dreal:  {0}", res03);
        ExtendedC res04 = ereal.expj(x);
        Console.WriteLine(" ereal:  {0}", res04);
        QuadrupleC res05 = qreal.expj(x);
        Console.WriteLine(" qreal:  {0}", res05);
        OctupleC res06 = oreal.expj(x);
        Console.WriteLine(" oreal:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        MpfrC res07 = mreal.expj(x);
        Console.WriteLine(" mreal:  {0}", res07);
        SingleC res08 = sflint.expj(x);
        Console.WriteLine("sflint:  {0}", res08);
        Complex res09 = dflint.expj(x);
        Console.WriteLine("dflint:  {0}", res09);
        ExtendedC res10 = eflint.expj(x);
        Console.WriteLine("eflint:  {0}", res10);
        QuadrupleC res11 = qflint.expj(x);
        Console.WriteLine("qflint:  {0}", res11);
        OctupleC res12 = oflint.expj(x);
        Console.WriteLine("oflint:  {0}", res12);
        MpfrC res13 = mflint.expj(x);
        Console.WriteLine("mflint:  {0}", res13);
        ArbC res16 = aflint.expj(x);
        Console.WriteLine("aflint: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExpjCplx

public static void TestExpjCplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExpjCplx" + "\"" + ">");
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};

    foreach (var x in InputArray1C) {
        Console.WriteLine("<H2 Title=" + "\"" + "expj(x); " + "x={0}" + 
            "\"" + ">", x);
        Complex res01 = cmath53.expj(x);
        Console.WriteLine("cmath53:  {0}", res01);
        SingleC res02 = scplx.expj(x);
        Console.WriteLine("  scplx:  {0}", res02);
        Complex res03 = dcplx.expj(x);
        Console.WriteLine("  dcplx:  {0}", res03);
        ExtendedC res04 = ecplx.expj(x);
        Console.WriteLine("  ecplx:  {0}", res04);
        QuadrupleC res05 = qcplx.expj(x);
        Console.WriteLine("  qcplx:  {0}", res05);
        OctupleC res06 = ocplx.expj(x);
        Console.WriteLine("  ocplx:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        MpfrC res07 = mcplx.expj(x);
        Console.WriteLine("  mcplx:  {0}", res07);
        SingleC res08 = sflintc.expj(x);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.expj(x);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.expj(x);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.expj(x);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.expj(x);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.expj(x);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.expj(x);
        Console.WriteLine("aflintc: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExpjRealImag

public static void TestExpjRealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExpjRealImag" + 
        "\"" + ">");
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    foreach (var x in InputArray1C) {
    foreach (var IsReal in ReImArray)
    {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "expj(x)); x={0}" 
            + "\"" + ">", x);

        Complex res01c = cmath53.expj(x); 
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);

        SingleC res02c = scplx.expj(x);
        Single res02 = IsReal ? res02c.real : res02c.imag;
        Console.WriteLine("  scplx:  {0}", res02);

        Complex res03c = dcplx.expj(x);
        Double res03 = IsReal ? res03c.Real : res03c.Imaginary;
        Console.WriteLine("  dcplx:  {0}", res03);

        ExtendedC res04c = ecplx.expj(x);
        Extended res04 = IsReal ? res04c.real : res04c.imag;
        Console.WriteLine("  ecplx:  {0}", res04);

        QuadrupleC res05c = qcplx.expj(x);
        Quadruple res05 = IsReal ? res05c.real : res05c.imag;
        Console.WriteLine("  qcplx:  {0}", res05);

        OctupleC res06c = ocplx.expj(x);
        Octuple res06 = IsReal ? res06c.real : res06c.imag;
        Console.WriteLine("  ocplx:  {0}", res06);

#if HasArbPrecNet
        MpfrC res07c = mcplx.expj(x);
        Mpfr res07 = IsReal ? res07c.real : res07c.imag;
        Console.WriteLine("  mcplx:  {0}", res07);

        SingleC res08c = sflintc.expj(x);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.expj(x);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.expj(x);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.expj(x);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.expj(x);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.expj(x);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.expj(x);
        Arb res16 = IsReal ? res16c.real : res16c.imag;
        Console.WriteLine("aflintc: {0}", res16);
#endif
        Console.WriteLine("</H2>");
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
// Expected results
/*
<H1 Title="TestExpjReal">
<H2 Title="expj(x); x=-4.333">
math53:  (-0.370352967899265, 0.928891101888809)
 sreal:  (-0.3703528, 0.9288912)
 dreal:  (-0.370352967899265, 0.928891101888809)
 ereal:  (-0.37035296789926491518, 0.92889110188880916598)
 qreal:  (-0.370352967899264915171359472895674, 0.928891101888809165960514617108752)
 oreal:  (-0.37035296789926491517135947289567381311168326104331418048135105101946464, 0.9288911018888091659605146171087520621464225359491860915736510902775277)
 mreal:  (-0.37035296789926491517135947289567381311168326104331418048135105101946462696242105, 0.9288911018888091659605146171087520621464225359491860915736510902775276973217576)
sflint:  (-0.3703528, 0.9288912)
dflint:  (-0.370352967899265, 0.928891101888809)
eflint:  (-0.37035296789926491518, 0.92889110188880916598)
qflint:  (-0.370352967899264915171359472895674, 0.928891101888809165960514617108752)
oflint:  (-0.37035296789926491517135947289567381311168326104331418048135105101946464, 0.9288911018888091659605146171087520621464225359491860915736510902775277)
mflint:  (-0.37035296789926491517135947289567381311168326104331418048135105101946462696242105, 0.9288911018888091659605146171087520621464225359491860915736510902775276973217576)
aflint: ([-0.3703529678992649151713594728956738131116832610433141804813510510194646269624211 +/- 5.60e-80], [0.9288911018888091659605146171087520621464225359491860915736510902775276973217576 +/- 1.23e-80])
</H2>

<H2 Title="expj(x); x=0">
math53:  (1, 0)
 sreal:  (1, 0)
 dreal:  (1, 0)
 ereal:  (1, 0)
 qreal:  (1, 0)
 oreal:  (1, 0)
 mreal:  (1, 0)
sflint:  (1, 0)
dflint:  (1, 0)
eflint:  (1, 0)
qflint:  (1, 0)
oflint:  (1, 0)
mflint:  (1, 0)
aflint: ( 1.0000000000000000000000000000000000000000000000000000000000000000000000000000000,  0)
</H2>

<H2 Title="expj(x); x=4.333">
math53:  (-0.370352967899265, -0.928891101888809)
 sreal:  (-0.3703528, -0.9288912)
 dreal:  (-0.370352967899265, -0.928891101888809)
 ereal:  (-0.37035296789926491518, -0.92889110188880916598)
 qreal:  (-0.370352967899264915171359472895674, -0.928891101888809165960514617108752)
 oreal:  (-0.37035296789926491517135947289567381311168326104331418048135105101946464, -0.9288911018888091659605146171087520621464225359491860915736510902775277)
 mreal:  (-0.37035296789926491517135947289567381311168326104331418048135105101946462696242105, -0.9288911018888091659605146171087520621464225359491860915736510902775276973217576)
sflint:  (-0.3703528, -0.9288912)
dflint:  (-0.370352967899265, -0.928891101888809)
eflint:  (-0.37035296789926491518, -0.92889110188880916598)
qflint:  (-0.370352967899264915171359472895674, -0.928891101888809165960514617108752)
oflint:  (-0.37035296789926491517135947289567381311168326104331418048135105101946464, -0.9288911018888091659605146171087520621464225359491860915736510902775277)
mflint:  (-0.37035296789926491517135947289567381311168326104331418048135105101946462696242105, -0.9288911018888091659605146171087520621464225359491860915736510902775276973217576)
aflint: ([-0.3703529678992649151713594728956738131116832610433141804813510510194646269624211 +/- 5.60e-80], [-0.9288911018888091659605146171087520621464225359491860915736510902775276973217576 +/- 1.23e-80])
</H2>

</H1>
<H1 Title="TestExpjCplx">
<H2 Title="expj(x); x=(-4.333, 1)">
cmath53:  (-0.136245242866967, 0.341719939471981)
  scplx:  (-0.1362452, 0.34172)
  dcplx:  (-0.136245242866967, 0.341719939471981)
  ecplx:  (-0.13624524286696669398, 0.34171993947198040723)
  qcplx:  (-0.136245242866966693930594609083618, 0.341719939471980407146472003818899)
  ocplx:  (-0.13624524286696669393059460908361784841415956471089564562478360996785313, 0.34171993947198040714647200381889888353859773981534512039281754202990226)
  mcplx:  (-0.13624524286696669393059460908361784841415956471089564562478360996785312633735398, 0.34171993947198040714647200381889888353859773981534512039281754202990227038563156)
sflintc:  (-0.1362452, 0.34172)
dflintc:  (-0.136245242866967, 0.34171993947198)
eflintc:  (-0.13624524286696669393, 0.34171993947198040715)
qflintc:  (-0.136245242866966693930594609083618, 0.341719939471980407146472003818899)
oflintc:  (-0.13624524286696669393059460908361784841415956471089564562478360996785313, 0.34171993947198040714647200381889888353859773981534512039281754202990227)
mflintc:  (-0.13624524286696669393059460908361784841415956471089564562478360996785312633735398, 0.34171993947198040714647200381889888353859773981534512039281754202990227038563156)
aflintc: ([-0.1362452428669666939305946090836178484141595647108956456247836099678531263373540 +/- 6.65e-80], [0.341719939471980407146472003818898883538597739815345120392817542029902270385632 +/- 5.36e-79])
</H2>

<H2 Title="expj(x); x=(0, 1)">
cmath53:  (0.367879441171442, 0)
  scplx:  (0.3678795, 0)
  dcplx:  (0.367879441171442, 0)
  ecplx:  (0.36787944117144232166, 0)
  qcplx:  (0.367879441171442321595523770161461, 0)
  ocplx:  (0.36787944117144232159552377016146086744581113103176783450783680169746149, 0)
  mcplx:  (0.36787944117144232159552377016146086744581113103176783450783680169746149574489981, 0)
sflintc:  (0.3678795, 0)
dflintc:  (0.367879441171442, 0)
eflintc:  (0.36787944117144232158, 0)
qflintc:  (0.367879441171442321595523770161461, 0)
oflintc:  (0.3678794411714423215955237701614608674458111310317678345078368016974615, 0)
mflintc:  (0.36787944117144232159552377016146086744581113103176783450783680169746149574489981, 0)
aflintc: ([0.3678794411714423215955237701614608674458111310317678345078368016974614957448998 +/- 4.35e-80],  0)
</H2>

<H2 Title="expj(x); x=(4.333, 1)">
cmath53:  (-0.136245242866967, -0.341719939471981)
  scplx:  (-0.1362452, -0.34172)
  dcplx:  (-0.136245242866967, -0.341719939471981)
  ecplx:  (-0.13624524286696669398, -0.34171993947198040723)
  qcplx:  (-0.136245242866966693930594609083618, -0.341719939471980407146472003818899)
  ocplx:  (-0.13624524286696669393059460908361784841415956471089564562478360996785313, -0.34171993947198040714647200381889888353859773981534512039281754202990226)
  mcplx:  (-0.13624524286696669393059460908361784841415956471089564562478360996785312633735398, -0.34171993947198040714647200381889888353859773981534512039281754202990227038563156)
sflintc:  (-0.1362452, -0.34172)
dflintc:  (-0.136245242866967, -0.34171993947198)
eflintc:  (-0.13624524286696669393, -0.34171993947198040715)
qflintc:  (-0.136245242866966693930594609083618, -0.341719939471980407146472003818899)
oflintc:  (-0.13624524286696669393059460908361784841415956471089564562478360996785313, -0.34171993947198040714647200381889888353859773981534512039281754202990227)
mflintc:  (-0.13624524286696669393059460908361784841415956471089564562478360996785312633735398, -0.34171993947198040714647200381889888353859773981534512039281754202990227038563156)
aflintc: ([-0.1362452428669666939305946090836178484141595647108956456247836099678531263373540 +/- 6.65e-80], [-0.341719939471980407146472003818898883538597739815345120392817542029902270385632 +/- 5.36e-79])
</H2>

</H1>
<H1 Title="TestExpjRealImag">
<H2 Title="Re(expj(x)); x=(-4.333, 1)">
cmath53:  -0.136245242866967
  scplx:  -0.1362452
  dcplx:  -0.136245242866967
  ecplx:  -0.13624524286696669398
  qcplx:  -0.136245242866966693930594609083618
  ocplx:  -0.13624524286696669393059460908361784841415956471089564562478360996785313
  mcplx:  -0.13624524286696669393059460908361784841415956471089564562478360996785312633735398
sflintc:  -0.1362452
dflintc:  -0.136245242866967
eflintc:  -0.13624524286696669393
qflintc:  -0.136245242866966693930594609083618
oflintc:  -0.13624524286696669393059460908361784841415956471089564562478360996785313
mflintc:  -0.13624524286696669393059460908361784841415956471089564562478360996785312633735398
aflintc: [-0.1362452428669666939305946090836178484141595647108956456247836099678531263373540 +/- 6.65e-80]
</H2>

<H2 Title="Im(expj(x)); x=(-4.333, 1)">
cmath53:  0.341719939471981
  scplx:  0.34172
  dcplx:  0.341719939471981
  ecplx:  0.34171993947198040723
  qcplx:  0.341719939471980407146472003818899
  ocplx:  0.34171993947198040714647200381889888353859773981534512039281754202990226
  mcplx:  0.34171993947198040714647200381889888353859773981534512039281754202990227038563156
sflintc:  0.34172
dflintc:  0.34171993947198
eflintc:  0.34171993947198040715
qflintc:  0.341719939471980407146472003818899
oflintc:  0.34171993947198040714647200381889888353859773981534512039281754202990227
mflintc:  0.34171993947198040714647200381889888353859773981534512039281754202990227038563156
aflintc: [0.341719939471980407146472003818898883538597739815345120392817542029902270385632 +/- 5.36e-79]
</H2>

<H2 Title="Re(expj(x)); x=(0, 1)">
cmath53:  0.367879441171442
  scplx:  0.3678795
  dcplx:  0.367879441171442
  ecplx:  0.36787944117144232166
  qcplx:  0.367879441171442321595523770161461
  ocplx:  0.36787944117144232159552377016146086744581113103176783450783680169746149
  mcplx:  0.36787944117144232159552377016146086744581113103176783450783680169746149574489981
sflintc:  0.3678795
dflintc:  0.367879441171442
eflintc:  0.36787944117144232158
qflintc:  0.367879441171442321595523770161461
oflintc:  0.3678794411714423215955237701614608674458111310317678345078368016974615
mflintc:  0.36787944117144232159552377016146086744581113103176783450783680169746149574489981
aflintc: [0.3678794411714423215955237701614608674458111310317678345078368016974614957448998 +/- 4.35e-80]
</H2>

<H2 Title="Im(expj(x)); x=(0, 1)">
cmath53:  0
  scplx:  0
  dcplx:  0
  ecplx:  0
  qcplx:  0
  ocplx:  0
  mcplx:  0
sflintc:  0
dflintc:  0
eflintc:  0
qflintc:  0
oflintc:  0
mflintc:  0
aflintc:  0
</H2>

<H2 Title="Re(expj(x)); x=(4.333, 1)">
cmath53:  -0.136245242866967
  scplx:  -0.1362452
  dcplx:  -0.136245242866967
  ecplx:  -0.13624524286696669398
  qcplx:  -0.136245242866966693930594609083618
  ocplx:  -0.13624524286696669393059460908361784841415956471089564562478360996785313
  mcplx:  -0.13624524286696669393059460908361784841415956471089564562478360996785312633735398
sflintc:  -0.1362452
dflintc:  -0.136245242866967
eflintc:  -0.13624524286696669393
qflintc:  -0.136245242866966693930594609083618
oflintc:  -0.13624524286696669393059460908361784841415956471089564562478360996785313
mflintc:  -0.13624524286696669393059460908361784841415956471089564562478360996785312633735398
aflintc: [-0.1362452428669666939305946090836178484141595647108956456247836099678531263373540 +/- 6.65e-80]
</H2>

<H2 Title="Im(expj(x)); x=(4.333, 1)">
cmath53:  -0.341719939471981
  scplx:  -0.34172
  dcplx:  -0.341719939471981
  ecplx:  -0.34171993947198040723
  qcplx:  -0.341719939471980407146472003818899
  ocplx:  -0.34171993947198040714647200381889888353859773981534512039281754202990226
  mcplx:  -0.34171993947198040714647200381889888353859773981534512039281754202990227038563156
sflintc:  -0.34172
dflintc:  -0.34171993947198
eflintc:  -0.34171993947198040715
qflintc:  -0.341719939471980407146472003818899
oflintc:  -0.34171993947198040714647200381889888353859773981534512039281754202990227
mflintc:  -0.34171993947198040714647200381889888353859773981534512039281754202990227038563156
aflintc: [-0.341719939471980407146472003818898883538597739815345120392817542029902270385632 +/- 5.36e-79]
</H2>

</H1>
<H1 Title="General Info">
Elapsed Time 00:00:00.16
------------------------------------------------
Memory used before collection:       7,463,368
Memory used after full collection:   3,787,288
------------------------------------------------

</H1>


*/
#endregion

