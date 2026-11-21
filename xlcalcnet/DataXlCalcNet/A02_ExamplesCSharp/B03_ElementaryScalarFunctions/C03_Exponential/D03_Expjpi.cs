
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
    TestExpjpiReal();
    TestExpjpiCplx();
    TestExpjpiRealImag();
}


#region TestExpjpiReal

public static void TestExpjpiReal()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExpjpiReal" + "\"" + ">");
    double[] InputArray1 = { -4.333, 0.0, 4.333 };
    
    foreach (var x in InputArray1) {
        Console.WriteLine("<H2 Title=" + "\"" + "expjpi(x); " + "x={0}" 
            + "\"" + ">", x);
        Complex res01 = math53.expjpi(x);
        Console.WriteLine("math53:  {0}", res01);
        SingleC res02 = sreal.expjpi(x);
        Console.WriteLine(" sreal:  {0}", res02);
        Complex res03 = dreal.expjpi(x);
        Console.WriteLine(" dreal:  {0}", res03);
        ExtendedC res04 = ereal.expjpi(x);
        Console.WriteLine(" ereal:  {0}", res04);
        QuadrupleC res05 = qreal.expjpi(x);
        Console.WriteLine(" qreal:  {0}", res05);
        OctupleC res06 = oreal.expjpi(x);
        Console.WriteLine(" oreal:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        MpfrC res07 = mreal.expjpi(x);
        Console.WriteLine(" mreal:  {0}", res07);
        SingleC res08 = sflint.expjpi(x);
        Console.WriteLine("sflint:  {0}", res08);
        Complex res09 = dflint.expjpi(x);
        Console.WriteLine("dflint:  {0}", res09);
        ExtendedC res10 = eflint.expjpi(x);
        Console.WriteLine("eflint:  {0}", res10);
        QuadrupleC res11 = qflint.expjpi(x);
        Console.WriteLine("qflint:  {0}", res11);
        OctupleC res12 = oflint.expjpi(x);
        Console.WriteLine("oflint:  {0}", res12);
        MpfrC res13 = mflint.expjpi(x);
        Console.WriteLine("mflint:  {0}", res13);
        ArbC res16 = aflint.expjpi(x);
        Console.WriteLine("aflint: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExpjpiCplx

public static void TestExpjpiCplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExpjpiCplx" + "\"" + ">");
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};

    foreach (var x in InputArray1C) {
        Console.WriteLine("<H2 Title=" + "\"" + "expjpi(x); " + "x={0}" + 
            "\"" + ">", x);
        Complex res01 = cmath53.expjpi(x);
        Console.WriteLine("cmath53:  {0}", res01);
        SingleC res02 = scplx.expjpi(x);
        Console.WriteLine("  scplx:  {0}", res02);
        Complex res03 = dcplx.expjpi(x);
        Console.WriteLine("  dcplx:  {0}", res03);
        ExtendedC res04 = ecplx.expjpi(x);
        Console.WriteLine("  ecplx:  {0}", res04);
        QuadrupleC res05 = qcplx.expjpi(x);
        Console.WriteLine("  qcplx:  {0}", res05);
        OctupleC res06 = ocplx.expjpi(x);
        Console.WriteLine("  ocplx:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        MpfrC res07 = mcplx.expjpi(x);
        Console.WriteLine("  mcplx:  {0}", res07);
        SingleC res08 = sflintc.expjpi(x);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.expjpi(x);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.expjpi(x);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.expjpi(x);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.expjpi(x);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.expjpi(x);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.expjpi(x);
        Console.WriteLine("aflintc: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExpjpiRealImag

public static void TestExpjpiRealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExpjpiRealImag" + 
        "\"" + ">");
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    foreach (var x in InputArray1C) {
    foreach (var IsReal in ReImArray)
    {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "expjpi(x)); x={0}" 
            + "\"" + ">", x);

        Complex res01c = cmath53.expjpi(x); 
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);

        SingleC res02c = scplx.expjpi(x);
        Single res02 = IsReal ? res02c.real : res02c.imag;
        Console.WriteLine("  scplx:  {0}", res02);

        Complex res03c = dcplx.expjpi(x);
        Double res03 = IsReal ? res03c.Real : res03c.Imaginary;
        Console.WriteLine("  dcplx:  {0}", res03);

        ExtendedC res04c = ecplx.expjpi(x);
        Extended res04 = IsReal ? res04c.real : res04c.imag;
        Console.WriteLine("  ecplx:  {0}", res04);

        QuadrupleC res05c = qcplx.expjpi(x);
        Quadruple res05 = IsReal ? res05c.real : res05c.imag;
        Console.WriteLine("  qcplx:  {0}", res05);

        OctupleC res06c = ocplx.expjpi(x);
        Octuple res06 = IsReal ? res06c.real : res06c.imag;
        Console.WriteLine("  ocplx:  {0}", res06);

#if HasArbPrecNet
        MpfrC res07c = mcplx.expjpi(x);
        Mpfr res07 = IsReal ? res07c.real : res07c.imag;
        Console.WriteLine("  mcplx:  {0}", res07);

        SingleC res08c = sflintc.expjpi(x);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.expjpi(x);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.expjpi(x);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.expjpi(x);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.expjpi(x);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.expjpi(x);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.expjpi(x);
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
<H1 Title="TestExpjpiReal">
<H2 Title="expjpi(x); x=-4.333">
math53:  (0.500906625360709, -0.865501330253019)
 sreal:  (0.5009061, -0.8655016)
 dreal:  (0.500906625360709, -0.865501330253019)
 ereal:  (0.50090662536070989906, -0.86550133025301897489)
 qreal:  (0.50090662536070989905056525082958, -0.865501330253018974870235657992518)
 oreal:  (0.50090662536070989905056525082957981788155305671055069437802343708203359, -0.86550133025301897487023565799251835295709348063769300857400048798304712)
 mreal:  (0.50090662536070989905056525082957981788155305671055069437802343708203356834906849, -0.86550133025301897487023565799251835295709348063769300857400048798304713880303313)
sflint:  (0.5009061, -0.8655016)
dflint:  (0.500906625360709, -0.865501330253019)
eflint:  (0.50090662536070989906, -0.86550133025301897484)
qflint:  (0.50090662536070989905056525082958, -0.865501330253018974870235657992518)
oflint:  (0.50090662536070989905056525082957981788155305671055069437802343708203359, -0.86550133025301897487023565799251835295709348063769300857400048798304712)
mflint:  (0.50090662536070989905056525082957981788155305671055069437802343708203356834906849, -0.86550133025301897487023565799251835295709348063769300857400048798304713880303313)
aflint: ([0.5009066253607098990505652508295798178815530567105506943780234370820335683490685 +/- 4.46e-80], [-0.8655013302530189748702356579925183529570934806376930085740004879830471388030331 +/- 4.80e-80])
</H2>

<H2 Title="expjpi(x); x=0">
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

<H2 Title="expjpi(x); x=4.333">
math53:  (0.500906625360709, 0.865501330253019)
 sreal:  (0.5009061, 0.8655016)
 dreal:  (0.500906625360709, 0.865501330253019)
 ereal:  (0.50090662536070989906, 0.86550133025301897489)
 qreal:  (0.50090662536070989905056525082958, 0.865501330253018974870235657992518)
 oreal:  (0.50090662536070989905056525082957981788155305671055069437802343708203359, 0.86550133025301897487023565799251835295709348063769300857400048798304712)
 mreal:  (0.50090662536070989905056525082957981788155305671055069437802343708203356834906849, 0.86550133025301897487023565799251835295709348063769300857400048798304713880303313)
sflint:  (0.5009061, 0.8655016)
dflint:  (0.500906625360709, 0.865501330253019)
eflint:  (0.50090662536070989906, 0.86550133025301897484)
qflint:  (0.50090662536070989905056525082958, 0.865501330253018974870235657992518)
oflint:  (0.50090662536070989905056525082957981788155305671055069437802343708203359, 0.86550133025301897487023565799251835295709348063769300857400048798304712)
mflint:  (0.50090662536070989905056525082957981788155305671055069437802343708203356834906849, 0.86550133025301897487023565799251835295709348063769300857400048798304713880303313)
aflint: ([0.5009066253607098990505652508295798178815530567105506943780234370820335683490685 +/- 4.46e-80], [0.8655013302530189748702356579925183529570934806376930085740004879830471388030331 +/- 4.80e-80])
</H2>

</H1>
<H1 Title="TestExpjpiCplx">
<H2 Title="expjpi(x); x=(-4.333, 1)">
cmath53:  (0.021646137966111, -0.037401703742777)
  scplx:  (0.0216465, -0.0374012)
  dcplx:  (0.0216461379661199, -0.0374017037427397)
  ecplx:  (0.021646137966119705261, -0.037401703742740113889)
  qcplx:  (0.0216461379661197054976652662582966, -0.0374017037427401142960765601000233)
  ocplx:  (0.021646137966119705497665266258296922501223847425543152362859627018992703, -0.037401703742740114296076560100024689524780174372130204898070817887134774)
  mcplx:  (0.021646137966119705497665266258296922501223847425543152362859627018992696393081365, -0.037401703742740114296076560100024689524780174372130204898070817887134818675248167)
sflintc:  (0.02164612, -0.03740172)
dflintc:  (0.0216461379661197, -0.0374017037427401)
eflintc:  (0.021646137966119705498, -0.037401703742740114296)
qflintc:  (0.0216461379661197054976652662582969, -0.0374017037427401142960765601000247)
oflintc:  (0.021646137966119705497665266258296922501223847425543152362859627018992698, -0.037401703742740114296076560100024689524780174372130204898070817887134818)
mflintc:  (0.021646137966119705497665266258296922501223847425543152362859627018992696393081365, -0.037401703742740114296076560100024689524780174372130204898070817887134818675248167)
aflintc: ([0.02164613796611970549766526625829692250122384742554315236285962701899269639308137 +/- 7.15e-81], [-0.03740170374274011429607656010002468952478017437213020489807081788713481867524817 +/- 5.86e-81])
</H2>

<H2 Title="expjpi(x); x=(0, 1)">
cmath53:  (0.043213918263735, 0)
  scplx:  (0.04321384, 0)
  dcplx:  (0.0432139182637723, 0)
  ecplx:  (0.043213918263772249304, 0)
  qcplx:  (0.0432139182637722497744177371717278, 0)
  ocplx:  (0.043213918263772249774417737171728011275728109810633082980719687401050727, 0)
  mcplx:  (0.043213918263772249774417737171728011275728109810633082980719687401050765757017968, 0)
sflintc:  (0.04321392, 0)
dflintc:  (0.0432139182637723, 0)
eflintc:  (0.043213918263772249775, 0)
qflintc:  (0.043213918263772249774417737171728, 0)
oflintc:  (0.043213918263772249774417737171728011275728109810633082980719687401050766, 0)
mflintc:  (0.043213918263772249774417737171728011275728109810633082980719687401050765757017968, 0)
aflintc: ([0.04321391826377224977441773717172801127572810981063308298071968740105076575701797 +/- 3.73e-81],  0)
</H2>

<H2 Title="expjpi(x); x=(4.333, 1)">
cmath53:  (0.021646137966111, 0.037401703742777)
  scplx:  (0.0216465, 0.0374012)
  dcplx:  (0.0216461379661199, 0.0374017037427397)
  ecplx:  (0.021646137966119705261, 0.037401703742740113889)
  qcplx:  (0.0216461379661197054976652662582966, 0.0374017037427401142960765601000233)
  ocplx:  (0.021646137966119705497665266258296922501223847425543152362859627018992703, 0.037401703742740114296076560100024689524780174372130204898070817887134774)
  mcplx:  (0.021646137966119705497665266258296922501223847425543152362859627018992696393081365, 0.037401703742740114296076560100024689524780174372130204898070817887134818675248167)
sflintc:  (0.02164612, 0.03740172)
dflintc:  (0.0216461379661197, 0.0374017037427401)
eflintc:  (0.021646137966119705498, 0.037401703742740114296)
qflintc:  (0.0216461379661197054976652662582969, 0.0374017037427401142960765601000247)
oflintc:  (0.021646137966119705497665266258296922501223847425543152362859627018992698, 0.037401703742740114296076560100024689524780174372130204898070817887134818)
mflintc:  (0.021646137966119705497665266258296922501223847425543152362859627018992696393081365, 0.037401703742740114296076560100024689524780174372130204898070817887134818675248167)
aflintc: ([0.02164613796611970549766526625829692250122384742554315236285962701899269639308137 +/- 7.15e-81], [0.03740170374274011429607656010002468952478017437213020489807081788713481867524817 +/- 5.86e-81])
</H2>

</H1>
<H1 Title="TestExpjpiRealImag">
<H2 Title="Re(expjpi(x)); x=(-4.333, 1)">
cmath53:  0.021646137966111
  scplx:  0.0216465
  dcplx:  0.0216461379661199
  ecplx:  0.021646137966119705261
  qcplx:  0.0216461379661197054976652662582966
  ocplx:  0.021646137966119705497665266258296922501223847425543152362859627018992703
  mcplx:  0.021646137966119705497665266258296922501223847425543152362859627018992696393081365
sflintc:  0.02164612
dflintc:  0.0216461379661197
eflintc:  0.021646137966119705498
qflintc:  0.0216461379661197054976652662582969
oflintc:  0.021646137966119705497665266258296922501223847425543152362859627018992698
mflintc:  0.021646137966119705497665266258296922501223847425543152362859627018992696393081365
aflintc: [0.02164613796611970549766526625829692250122384742554315236285962701899269639308137 +/- 7.15e-81]
</H2>

<H2 Title="Im(expjpi(x)); x=(-4.333, 1)">
cmath53:  -0.037401703742777
  scplx:  -0.0374012
  dcplx:  -0.0374017037427397
  ecplx:  -0.037401703742740113889
  qcplx:  -0.0374017037427401142960765601000233
  ocplx:  -0.037401703742740114296076560100024689524780174372130204898070817887134774
  mcplx:  -0.037401703742740114296076560100024689524780174372130204898070817887134818675248167
sflintc:  -0.03740172
dflintc:  -0.0374017037427401
eflintc:  -0.037401703742740114296
qflintc:  -0.0374017037427401142960765601000247
oflintc:  -0.037401703742740114296076560100024689524780174372130204898070817887134818
mflintc:  -0.037401703742740114296076560100024689524780174372130204898070817887134818675248167
aflintc: [-0.03740170374274011429607656010002468952478017437213020489807081788713481867524817 +/- 5.86e-81]
</H2>

<H2 Title="Re(expjpi(x)); x=(0, 1)">
cmath53:  0.043213918263735
  scplx:  0.04321384
  dcplx:  0.0432139182637723
  ecplx:  0.043213918263772249304
  qcplx:  0.0432139182637722497744177371717278
  ocplx:  0.043213918263772249774417737171728011275728109810633082980719687401050727
  mcplx:  0.043213918263772249774417737171728011275728109810633082980719687401050765757017968
sflintc:  0.04321392
dflintc:  0.0432139182637723
eflintc:  0.043213918263772249775
qflintc:  0.043213918263772249774417737171728
oflintc:  0.043213918263772249774417737171728011275728109810633082980719687401050766
mflintc:  0.043213918263772249774417737171728011275728109810633082980719687401050765757017968
aflintc: [0.04321391826377224977441773717172801127572810981063308298071968740105076575701797 +/- 3.73e-81]
</H2>

<H2 Title="Im(expjpi(x)); x=(0, 1)">
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

<H2 Title="Re(expjpi(x)); x=(4.333, 1)">
cmath53:  0.021646137966111
  scplx:  0.0216465
  dcplx:  0.0216461379661199
  ecplx:  0.021646137966119705261
  qcplx:  0.0216461379661197054976652662582966
  ocplx:  0.021646137966119705497665266258296922501223847425543152362859627018992703
  mcplx:  0.021646137966119705497665266258296922501223847425543152362859627018992696393081365
sflintc:  0.02164612
dflintc:  0.0216461379661197
eflintc:  0.021646137966119705498
qflintc:  0.0216461379661197054976652662582969
oflintc:  0.021646137966119705497665266258296922501223847425543152362859627018992698
mflintc:  0.021646137966119705497665266258296922501223847425543152362859627018992696393081365
aflintc: [0.02164613796611970549766526625829692250122384742554315236285962701899269639308137 +/- 7.15e-81]
</H2>

<H2 Title="Im(expjpi(x)); x=(4.333, 1)">
cmath53:  0.037401703742777
  scplx:  0.0374012
  dcplx:  0.0374017037427397
  ecplx:  0.037401703742740113889
  qcplx:  0.0374017037427401142960765601000233
  ocplx:  0.037401703742740114296076560100024689524780174372130204898070817887134774
  mcplx:  0.037401703742740114296076560100024689524780174372130204898070817887134818675248167
sflintc:  0.03740172
dflintc:  0.0374017037427401
eflintc:  0.037401703742740114296
qflintc:  0.0374017037427401142960765601000247
oflintc:  0.037401703742740114296076560100024689524780174372130204898070817887134818
mflintc:  0.037401703742740114296076560100024689524780174372130204898070817887134818675248167
aflintc: [0.03740170374274011429607656010002468952478017437213020489807081788713481867524817 +/- 5.86e-81]
</H2>

</H1>
<H1 Title="General Info">
Elapsed Time 00:00:00.18
------------------------------------------------
Memory used before collection:       8,847,816
Memory used after full collection:   3,948,656
------------------------------------------------

</H1>


*/
#endregion

