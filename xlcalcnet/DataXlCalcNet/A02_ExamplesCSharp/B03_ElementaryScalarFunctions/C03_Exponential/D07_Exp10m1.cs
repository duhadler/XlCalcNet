
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
    TestExp10m1Real();
    TestExp10m1Cplx();
    TestExp10m1RealImag();
}


#region TestExp10m1Real

public static void TestExp10m1Real()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExp10m1Real" + "\"" + ">");
    double[] InputArray1 = { -4.333, 0.0, 4.333 };
    
    foreach (var x in InputArray1) {
        Console.WriteLine("<H2 Title=" + "\"" + "exp10m1(x); " + "x={0}" 
            + "\"" + ">", x);
        Double res00 = math53.exp10(x) - 1;
        Console.WriteLine("math53:  {0}", res00);
        Double res01 = math53.exp10m1(x);
        Console.WriteLine("math53:  {0}", res01);
        Single res02 = sreal.exp10m1(x);
        Console.WriteLine(" sreal:  {0}", res02);
        Double res03 = dreal.exp10m1(x);
        Console.WriteLine(" dreal:  {0}", res03);
        Extended res04 = ereal.exp10m1(x);
        Console.WriteLine(" ereal:  {0}", res04);
        Quadruple res05 = qreal.exp10m1(x);
        Console.WriteLine(" qreal:  {0}", res05);
        Octuple res06 = oreal.exp10m1(x);
        Console.WriteLine(" oreal:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Mpfr res07 = mreal.exp10m1(x);
        Console.WriteLine(" mreal:  {0}", res07);
        Single res08 = sflint.exp10m1(x);
        Console.WriteLine("sflint:  {0}", res08);
        Double res09 = dflint.exp10m1(x);
        Console.WriteLine("dflint:  {0}", res09);
        Extended res10 = eflint.exp10m1(x);
        Console.WriteLine("eflint:  {0}", res10);
        Quadruple res11 = qflint.exp10m1(x);
        Console.WriteLine("qflint:  {0}", res11);
        Octuple res12 = oflint.exp10m1(x);
        Console.WriteLine("oflint:  {0}", res12);
        Mpfr res13 = mflint.exp10m1(x);
        Console.WriteLine("mflint:  {0}", res13);
        Arb res16 = aflint.exp10m1(x);
        Console.WriteLine("aflint: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExp10m1Cplx

public static void TestExp10m1Cplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExp10m1Cplx" + "\"" + ">");
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};

    foreach (var x in InputArray1C) {
        Console.WriteLine("<H2 Title=" + "\"" + "exp10m1(x); " + "x={0}" + 
            "\"" + ">", x);
        Complex res01 = cmath53.exp10m1(x);
        Console.WriteLine("cmath53:  {0}", res01);
        SingleC res02 = scplx.exp10m1(x);
        Console.WriteLine("  scplx:  {0}", res02);
        Complex res03 = dcplx.exp10m1(x);
        Console.WriteLine("  dcplx:  {0}", res03);
        ExtendedC res04 = ecplx.exp10m1(x);
        Console.WriteLine("  ecplx:  {0}", res04);
        QuadrupleC res05 = qcplx.exp10m1(x);
        Console.WriteLine("  qcplx:  {0}", res05);
        OctupleC res06 = ocplx.exp10m1(x);
        Console.WriteLine("  ocplx:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        MpfrC res07 = mcplx.exp10m1(x);
        Console.WriteLine("  mcplx:  {0}", res07);
        SingleC res08 = sflintc.exp10m1(x);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.exp10m1(x);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.exp10m1(x);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.exp10m1(x);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.exp10m1(x);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.exp10m1(x);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.exp10m1(x);
        Console.WriteLine("aflintc: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExp10m1RealImag

public static void TestExp10m1RealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExp10m1RealImag" + 
        "\"" + ">");
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    foreach (var x in InputArray1C) {
    foreach (var IsReal in ReImArray)
    {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "exp10m1(x)); x={0}" 
            + "\"" + ">", x);

        Complex res01c = cmath53.exp10m1(x); 
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);

        SingleC res02c = scplx.exp10m1(x);
        Single res02 = IsReal ? res02c.real : res02c.imag;
        Console.WriteLine("  scplx:  {0}", res02);

        Complex res03c = dcplx.exp10m1(x);
        Double res03 = IsReal ? res03c.Real : res03c.Imaginary;
        Console.WriteLine("  dcplx:  {0}", res03);

        ExtendedC res04c = ecplx.exp10m1(x);
        Extended res04 = IsReal ? res04c.real : res04c.imag;
        Console.WriteLine("  ecplx:  {0}", res04);

        QuadrupleC res05c = qcplx.exp10m1(x);
        Quadruple res05 = IsReal ? res05c.real : res05c.imag;
        Console.WriteLine("  qcplx:  {0}", res05);

        OctupleC res06c = ocplx.exp10m1(x);
        Octuple res06 = IsReal ? res06c.real : res06c.imag;
        Console.WriteLine("  ocplx:  {0}", res06);

#if HasArbPrecNet
        MpfrC res07c = mcplx.exp10m1(x);
        Mpfr res07 = IsReal ? res07c.real : res07c.imag;
        Console.WriteLine("  mcplx:  {0}", res07);

        SingleC res08c = sflintc.exp10m1(x);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.exp10m1(x);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.exp10m1(x);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.exp10m1(x);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.exp10m1(x);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.exp10m1(x);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.exp10m1(x);
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
<H1 Title="TestExp10m1Real">
<H2 Title="exp10m1(x); x=-4.333">
math53:  -0.999953548472478
 sreal:  -0.9999536
 dreal:  -0.999953548472478
 ereal:  -0.99995354847247772508
 qreal:  -0.999953548472477725057987616256406
 oreal:  -0.99995354847247772505798761625640625014436976299875827924411500096141786
 mreal:  -0.99995354847247772505798761625640625014436976299875827924411500096141786242032029
sflint:  -0.9999536
dflint:  -0.999953548472478
eflint:  -0.99995354847247772508
qflint:  -0.999953548472477725057987616256406
oflint:  -0.99995354847247772505798761625640625014436976299875827924411500096141786
mflint:  -0.99995354847247772505798761625640625014436976299875827924411500096141786242032029
aflint: [-0.9999535484724777250579876162564062501443697629987582792441150009614178624203203 +/- 2.62e-80]
</H2>

<H2 Title="exp10m1(x); x=0">
math53:  0
 sreal:  0
 dreal:  0
 ereal:  0
 qreal:  0
 oreal:  0
 mreal:  0
sflint:  0
dflint:  0
eflint:  0
qflint:  0
oflint:  0
mflint:  0
aflint:  0
</H2>

<H2 Title="exp10m1(x); x=4.333">
math53:  21526.8173472437
 sreal:  21526.82
 dreal:  21526.8173472438
 ereal:  21526.817347243728788
 qreal:  21526.8173472437287866789119314031
 oreal:  21526.817347243728786678911931403123965920782717120793340073009149403874
 mreal:  21526.817347243728786678911931403123965920782717120793340073009149403873574866621
sflint:  21526.83
dflint:  21526.8173472437
eflint:  21526.817347243728786
qflint:  21526.8173472437287866789119314031
oflint:  21526.817347243728786678911931403123965920782717120793340073009149403873
mflint:  21526.817347243728786678911931403123965920782717120793340073009149403873574866621
aflint: [21526.8173472437287866789119314031239659207827171207933400730091494038735748666 +/- 2.31e-74]
</H2>

</H1>
<H1 Title="TestExp10m1Cplx">
<H2 Title="exp10m1(x); x=(-4.333, 1)">
cmath53:  (-1.00003103898084, 3.45590230982123E-05)
  scplx:  (-1.000031, 3.455902E-05)
  dcplx:  (-1.00003103898084, 3.45590230982123E-05)
  ecplx:  (-1.000031038980841031, 3.4559023098212379996e-05)
  qcplx:  (-1.00003103898084103100194805811203, 3.45590230982123800016594692825887e-05)
  ocplx:  (-1.0000310389808410310019480581120303672558324992595264597690609076536237, 3.4559023098212380001659469282588701266270486936769096800970229029677712e-05)
  mcplx:  (-1.000031038980841031001948058112030367255832499259526459769060907653623655312275, 3.455902309821238000165946928258870126627048693676909680097022902967771183577978E-05)
sflintc:  (-1.000031, 3.455901E-05)
dflintc:  (-1.00003103898084, 3.45590230982124E-05)
eflintc:  (-1.000031038980841031, 3.4559023098212380003e-05)
qflintc:  (-1.00003103898084103100194805811203, 3.45590230982123800016594692825887e-05)
oflintc:  (-1.0000310389808410310019480581120303672558324992595264597690609076536237, 3.4559023098212380001659469282588701266270486936769096800970229029677713e-05)
mflintc:  (-1.000031038980841031001948058112030367255832499259526459769060907653623655312275, 3.455902309821238000165946928258870126627048693676909680097022902967771183577978E-05)
aflintc: ([-1.0000310389808410310019480581120303672558324992595264597690609076536236553122750 +/- 5.35e-80], [3.45590230982123800016594692825887012662704869367690968009702290296777118357798e-5 +/- 3.16e-83])
</H2>

<H2 Title="exp10m1(x); x=(0, 1)">
cmath53:  (-1.66820151019031, 0.743980336957493)
  scplx:  (-1.668201, 0.7439803)
  dcplx:  (-1.66820151019031, 0.743980336957493)
  ecplx:  (-1.6682015101903129462, 0.74398033695749318762)
  qcplx:  (-1.66820151019031294624233069665614, 0.743980336957493187658416406875514)
  ocplx:  (-1.6682015101903129462423306966561423582124743958440217334490291076816262, 0.74398033695749318765841640687551436862460001349130482739729321475966646)
  mcplx:  (-1.6682015101903129462423306966561423582124743958440217334490291076816262444729529, 0.74398033695749318765841640687551436862460001349130482739729321475966646555830412)
sflintc:  (-1.668202, 0.7439803)
dflintc:  (-1.66820151019031, 0.743980336957493)
eflintc:  (-1.6682015101903129462, 0.74398033695749318767)
qflintc:  (-1.66820151019031294624233069665614, 0.743980336957493187658416406875514)
oflintc:  (-1.6682015101903129462423306966561423582124743958440217334490291076816262, 0.74398033695749318765841640687551436862460001349130482739729321475966646)
mflintc:  (-1.6682015101903129462423306966561423582124743958440217334490291076816262444729529, 0.74398033695749318765841640687551436862460001349130482739729321475966646555830412)
aflintc: ([-1.6682015101903129462423306966561423582124743958440217334490291076816262444729529 +/- 7.66e-80], [0.7439803369574931876584164068755143686246000134913048273972932147596664655583041 +/- 5.51e-80])
</H2>

<H2 Title="exp10m1(x); x=(4.333, 1)">
cmath53:  (-14385.9200625295, 16016.2728039618)
  scplx:  (-14385.92, 16016.27)
  dcplx:  (-14385.9200625295, 16016.2728039618)
  ecplx:  (-14385.920062529476261, 16016.272803961756472)
  qcplx:  (-14385.9200625294762588100268183822, 16016.2728039617564717468009102051)
  ocplx:  (-14385.920062529476258810026818382212458384385235879270180825331836115954, 16016.272803961756471746800910205122976908573649176427332804838638421648)
  mcplx:  (-14385.920062529476258810026818382212458384385235879270180825331836115953695472635, 16016.272803961756471746800910205122976908573649176427332804838638421648477288957)
sflintc:  (-14385.93, 16016.28)
dflintc:  (-14385.9200625295, 16016.2728039618)
eflintc:  (-14385.920062529476259, 16016.272803961756471)
qflintc:  (-14385.9200625294762588100268183822, 16016.2728039617564717468009102051)
oflintc:  (-14385.920062529476258810026818382212458384385235879270180825331836115953, 16016.272803961756471746800910205122976908573649176427332804838638421648)
mflintc:  (-14385.920062529476258810026818382212458384385235879270180825331836115953695472635, 16016.272803961756471746800910205122976908573649176427332804838638421648477288957)
aflintc: ([-14385.92006252947625881002681838221245838438523587927018082533183611595369547264 +/- 9.73e-75], [16016.27280396175647174680091020512297690857364917642733280483863842164847728896 +/- 8.40e-75])
</H2>

</H1>
<H1 Title="TestExp10m1RealImag">
<H2 Title="Re(exp10m1(x)); x=(-4.333, 1)">
cmath53:  -1.00003103898084
  scplx:  -1.000031
  dcplx:  -1.00003103898084
  ecplx:  -1.000031038980841031
  qcplx:  -1.00003103898084103100194805811203
  ocplx:  -1.0000310389808410310019480581120303672558324992595264597690609076536237
  mcplx:  -1.000031038980841031001948058112030367255832499259526459769060907653623655312275
sflintc:  -1.000031
dflintc:  -1.00003103898084
eflintc:  -1.000031038980841031
qflintc:  -1.00003103898084103100194805811203
oflintc:  -1.0000310389808410310019480581120303672558324992595264597690609076536237
mflintc:  -1.000031038980841031001948058112030367255832499259526459769060907653623655312275
aflintc: [-1.0000310389808410310019480581120303672558324992595264597690609076536236553122750 +/- 5.35e-80]
</H2>

<H2 Title="Im(exp10m1(x)); x=(-4.333, 1)">
cmath53:  3.45590230982123E-05
  scplx:  3.455902E-05
  dcplx:  3.45590230982123E-05
  ecplx:  3.4559023098212379996e-05
  qcplx:  3.45590230982123800016594692825887e-05
  ocplx:  3.4559023098212380001659469282588701266270486936769096800970229029677712e-05
  mcplx:  3.455902309821238000165946928258870126627048693676909680097022902967771183577978E-05
sflintc:  3.455901E-05
dflintc:  3.45590230982124E-05
eflintc:  3.4559023098212380003e-05
qflintc:  3.45590230982123800016594692825887e-05
oflintc:  3.4559023098212380001659469282588701266270486936769096800970229029677713e-05
mflintc:  3.455902309821238000165946928258870126627048693676909680097022902967771183577978E-05
aflintc: [3.45590230982123800016594692825887012662704869367690968009702290296777118357798e-5 +/- 3.16e-83]
</H2>

<H2 Title="Re(exp10m1(x)); x=(0, 1)">
cmath53:  -1.66820151019031
  scplx:  -1.668201
  dcplx:  -1.66820151019031
  ecplx:  -1.6682015101903129462
  qcplx:  -1.66820151019031294624233069665614
  ocplx:  -1.6682015101903129462423306966561423582124743958440217334490291076816262
  mcplx:  -1.6682015101903129462423306966561423582124743958440217334490291076816262444729529
sflintc:  -1.668202
dflintc:  -1.66820151019031
eflintc:  -1.6682015101903129462
qflintc:  -1.66820151019031294624233069665614
oflintc:  -1.6682015101903129462423306966561423582124743958440217334490291076816262
mflintc:  -1.6682015101903129462423306966561423582124743958440217334490291076816262444729529
aflintc: [-1.6682015101903129462423306966561423582124743958440217334490291076816262444729529 +/- 7.66e-80]
</H2>

<H2 Title="Im(exp10m1(x)); x=(0, 1)">
cmath53:  0.743980336957493
  scplx:  0.7439803
  dcplx:  0.743980336957493
  ecplx:  0.74398033695749318762
  qcplx:  0.743980336957493187658416406875514
  ocplx:  0.74398033695749318765841640687551436862460001349130482739729321475966646
  mcplx:  0.74398033695749318765841640687551436862460001349130482739729321475966646555830412
sflintc:  0.7439803
dflintc:  0.743980336957493
eflintc:  0.74398033695749318767
qflintc:  0.743980336957493187658416406875514
oflintc:  0.74398033695749318765841640687551436862460001349130482739729321475966646
mflintc:  0.74398033695749318765841640687551436862460001349130482739729321475966646555830412
aflintc: [0.7439803369574931876584164068755143686246000134913048273972932147596664655583041 +/- 5.51e-80]
</H2>

<H2 Title="Re(exp10m1(x)); x=(4.333, 1)">
cmath53:  -14385.9200625295
  scplx:  -14385.92
  dcplx:  -14385.9200625295
  ecplx:  -14385.920062529476261
  qcplx:  -14385.9200625294762588100268183822
  ocplx:  -14385.920062529476258810026818382212458384385235879270180825331836115954
  mcplx:  -14385.920062529476258810026818382212458384385235879270180825331836115953695472635
sflintc:  -14385.93
dflintc:  -14385.9200625295
eflintc:  -14385.920062529476259
qflintc:  -14385.9200625294762588100268183822
oflintc:  -14385.920062529476258810026818382212458384385235879270180825331836115953
mflintc:  -14385.920062529476258810026818382212458384385235879270180825331836115953695472635
aflintc: [-14385.92006252947625881002681838221245838438523587927018082533183611595369547264 +/- 9.73e-75]
</H2>

<H2 Title="Im(exp10m1(x)); x=(4.333, 1)">
cmath53:  16016.2728039618
  scplx:  16016.27
  dcplx:  16016.2728039618
  ecplx:  16016.272803961756472
  qcplx:  16016.2728039617564717468009102051
  ocplx:  16016.272803961756471746800910205122976908573649176427332804838638421648
  mcplx:  16016.272803961756471746800910205122976908573649176427332804838638421648477288957
sflintc:  16016.28
dflintc:  16016.2728039618
eflintc:  16016.272803961756471
qflintc:  16016.2728039617564717468009102051
oflintc:  16016.272803961756471746800910205122976908573649176427332804838638421648
mflintc:  16016.272803961756471746800910205122976908573649176427332804838638421648477288957
aflintc: [16016.27280396175647174680091020512297690857364917642733280483863842164847728896 +/- 8.40e-75]
</H2>

</H1>
<H1 Title="General Info">
Elapsed Time 00:00:00.17
------------------------------------------------
Memory used before collection:       4,855,240
Memory used after full collection:   4,784,016
------------------------------------------------

</H1>


*/
#endregion

