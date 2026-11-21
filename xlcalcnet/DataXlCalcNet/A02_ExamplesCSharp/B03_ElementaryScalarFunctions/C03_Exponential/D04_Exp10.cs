
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
    TestExp10Real();
    TestExp10Cplx();
    TestExp10RealImag();
}


#region TestExp10Real

public static void TestExp10Real()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExp10Real" + "\"" + ">");
    double[] InputArray1 = { -4.333, 0.0, 4.333 };
    
    foreach (var x in InputArray1) {
        Console.WriteLine("<H2 Title=" + "\"" + "exp10(x); " + "x={0}" 
            + "\"" + ">", x);
        Double res01 = math53.exp10(x);
        Console.WriteLine("math53:  {0}", res01);
        Single res02 = sreal.exp10(x);
        Console.WriteLine(" sreal:  {0}", res02);
        Double res03 = dreal.exp10(x);
        Console.WriteLine(" dreal:  {0}", res03);
        Extended res04 = ereal.exp10(x);
        Console.WriteLine(" ereal:  {0}", res04);
        Quadruple res05 = qreal.exp10(x);
        Console.WriteLine(" qreal:  {0}", res05);
        Octuple res06 = oreal.exp10(x);
        Console.WriteLine(" oreal:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Mpfr res07 = mreal.exp10(x);
        Console.WriteLine(" mreal:  {0}", res07);
        Single res08 = sflint.exp10(x);
        Console.WriteLine("sflint:  {0}", res08);
        Double res09 = dflint.exp10(x);
        Console.WriteLine("dflint:  {0}", res09);
        Extended res10 = eflint.exp10(x);
        Console.WriteLine("eflint:  {0}", res10);
        Quadruple res11 = qflint.exp10(x);
        Console.WriteLine("qflint:  {0}", res11);
        Octuple res12 = oflint.exp10(x);
        Console.WriteLine("oflint:  {0}", res12);
        Mpfr res13 = mflint.exp10(x);
        Console.WriteLine("mflint:  {0}", res13);
        Arb res16 = aflint.exp10(x);
        Console.WriteLine("aflint: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExp10Cplx

public static void TestExp10Cplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExp10Cplx" + "\"" + ">");
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};

    foreach (var x in InputArray1C) {
        Console.WriteLine("<H2 Title=" + "\"" + "exp10(x); " + "x={0}" + 
            "\"" + ">", x);
        Complex res01 = cmath53.exp10(x);
        Console.WriteLine("cmath53:  {0}", res01);
        SingleC res02 = scplx.exp10(x);
        Console.WriteLine("  scplx:  {0}", res02);
        Complex res03 = dcplx.exp10(x);
        Console.WriteLine("  dcplx:  {0}", res03);
        ExtendedC res04 = ecplx.exp10(x);
        Console.WriteLine("  ecplx:  {0}", res04);
        QuadrupleC res05 = qcplx.exp10(x);
        Console.WriteLine("  qcplx:  {0}", res05);
        OctupleC res06 = ocplx.exp10(x);
        Console.WriteLine("  ocplx:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        MpfrC res07 = mcplx.exp10(x);
        Console.WriteLine("  mcplx:  {0}", res07);
        SingleC res08 = sflintc.exp10(x);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.exp10(x);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.exp10(x);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.exp10(x);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.exp10(x);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.exp10(x);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.exp10(x);
        Console.WriteLine("aflintc: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExp10RealImag

public static void TestExp10RealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExp10RealImag" + 
        "\"" + ">");
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    foreach (var x in InputArray1C) {
    foreach (var IsReal in ReImArray)
    {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "exp10(x)); x={0}" 
            + "\"" + ">", x);

        Complex res01c = cmath53.exp10(x); 
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);

        SingleC res02c = scplx.exp10(x);
        Single res02 = IsReal ? res02c.real : res02c.imag;
        Console.WriteLine("  scplx:  {0}", res02);

        Complex res03c = dcplx.exp10(x);
        Double res03 = IsReal ? res03c.Real : res03c.Imaginary;
        Console.WriteLine("  dcplx:  {0}", res03);

        ExtendedC res04c = ecplx.exp10(x);
        Extended res04 = IsReal ? res04c.real : res04c.imag;
        Console.WriteLine("  ecplx:  {0}", res04);

        QuadrupleC res05c = qcplx.exp10(x);
        Quadruple res05 = IsReal ? res05c.real : res05c.imag;
        Console.WriteLine("  qcplx:  {0}", res05);

        OctupleC res06c = ocplx.exp10(x);
        Octuple res06 = IsReal ? res06c.real : res06c.imag;
        Console.WriteLine("  ocplx:  {0}", res06);

#if HasArbPrecNet
        MpfrC res07c = mcplx.exp10(x);
        Mpfr res07 = IsReal ? res07c.real : res07c.imag;
        Console.WriteLine("  mcplx:  {0}", res07);

        SingleC res08c = sflintc.exp10(x);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.exp10(x);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.exp10(x);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.exp10(x);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.exp10(x);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.exp10(x);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.exp10(x);
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
<H1 Title="TestExp10Real">
<H2 Title="exp10(x); x=-4.333">
math53:  4.64515275222749E-05
 sreal:  4.645152E-05
 dreal:  4.64515275222749E-05
 ereal:  4.6451527522274942009e-05
 qreal:  4.64515275222749420123837435937498e-05
 oreal:  4.645152752227494201238374359374985563023700124172075588499903858213758e-05
 mreal:  4.6451527522274942012383743593749855630237001241720755884999038582137579679713306E-05
sflint:  4.645151E-05
dflint:  4.64515275222749E-05
eflint:  4.6451527522274942012e-05
qflint:  4.64515275222749420123837435937499e-05
oflint:  4.6451527522274942012383743593749855630237001241720755884999038582137581e-05
mflint:  4.6451527522274942012383743593749855630237001241720755884999038582137579679713306E-05
aflint: [4.64515275222749420123837435937498556302370012417207558849990385821375796797133e-5 +/- 2.95e-83]
</H2>

<H2 Title="exp10(x); x=0">
math53:  1
 sreal:  1
 dreal:  1
 ereal:  1
 qreal:  1
 oreal:  1
 mreal:  1
sflint:  1
dflint:  1
eflint:  1
qflint:  1
oflint:  1
mflint:  1
aflint:  1.0000000000000000000000000000000000000000000000000000000000000000000000000000000
</H2>

<H2 Title="exp10(x); x=4.333">
math53:  21527.8173472437
 sreal:  21527.82
 dreal:  21527.8173472438
 ereal:  21527.817347243728788
 qreal:  21527.8173472437287866789119314031
 oreal:  21527.817347243728786678911931403123965920782717120793340073009149403874
 mreal:  21527.817347243728786678911931403123965920782717120793340073009149403873574866621
sflint:  21527.83
dflint:  21527.8173472437
eflint:  21527.817347243728786
qflint:  21527.8173472437287866789119314031
oflint:  21527.817347243728786678911931403123965920782717120793340073009149403873
mflint:  21527.817347243728786678911931403123965920782717120793340073009149403873574866621
aflint: [21527.8173472437287866789119314031239659207827171207933400730091494038735748666 +/- 2.31e-74]
</H2>

</H1>
<H1 Title="TestExp10Cplx">
<H2 Title="exp10(x); x=(-4.333, 1)">
cmath53:  (-3.1038980841031E-05, 3.45590230982124E-05)
  scplx:  (-3.103898E-05, 3.455902E-05)
  dcplx:  (0.0163325696764116, 0.0254364701775078)
  ecplx:  (-3.1038980841031001948e-05, 3.4559023098212379996e-05)
  qcplx:  (-3.10389808410310019480581120303672e-05, 3.45590230982123800016594692825887e-05)
  ocplx:  (-3.1038980841031001948058112030367255832499259526459769060907653623655312e-05, 3.4559023098212380001659469282588701266270486936769096800970229029677712e-05)
  mcplx:  (-3.1038980841031001948058112030367255832499259526459769060907653623655312275047606E-05, 3.455902309821238000165946928258870126627048693676909680097022902967771183577978E-05)
sflintc:  (-3.103897E-05, 3.455901E-05)
dflintc:  (-3.1038980841031E-05, 3.45590230982124E-05)
eflintc:  (-3.1038980841031001948e-05, 3.4559023098212380003e-05)
qflintc:  (-3.10389808410310019480581120303673e-05, 3.45590230982123800016594692825887e-05)
oflintc:  (-3.1038980841031001948058112030367255832499259526459769060907653623655313e-05, 3.4559023098212380001659469282588701266270486936769096800970229029677713e-05)
mflintc:  (-3.1038980841031001948058112030367255832499259526459769060907653623655312275047606E-05, 3.455902309821238000165946928258870126627048693676909680097022902967771183577978E-05)
aflintc: ([-3.10389808410310019480581120303672558324992595264597690609076536236553122750476e-5 +/- 1.71e-83], [3.45590230982123800016594692825887012662704869367690968009702290296777118357798e-5 +/- 3.23e-83])
</H2>

<H2 Title="exp10(x); x=(0, 1)">
cmath53:  (-0.668201510190313, 0.743980336957493)
  scplx:  (-0.6682015, 0.7439803)
  dcplx:  (1.24409203520229, 1.93755854580568)
  ecplx:  (-0.66820151019031294627, 0.74398033695749318762)
  qcplx:  (-0.668201510190312946242330696656142, 0.743980336957493187658416406875514)
  ocplx:  (-0.66820151019031294624233069665614235821247439584402173344902910768162624, 0.74398033695749318765841640687551436862460001349130482739729321475966646)
  mcplx:  (-0.66820151019031294624233069665614235821247439584402173344902910768162624447295294, 0.74398033695749318765841640687551436862460001349130482739729321475966646555830412)
sflintc:  (-0.6682015, 0.7439803)
dflintc:  (-0.668201510190313, 0.743980336957493)
eflintc:  (-0.66820151019031294622, 0.74398033695749318767)
qflintc:  (-0.668201510190312946242330696656142, 0.743980336957493187658416406875514)
oflintc:  (-0.66820151019031294624233069665614235821247439584402173344902910768162624, 0.74398033695749318765841640687551436862460001349130482739729321475966646)
mflintc:  (-0.66820151019031294624233069665614235821247439584402173344902910768162624447295294, 0.74398033695749318765841640687551436862460001349130482739729321475966646555830412)
aflintc: ([-0.6682015101903129462423306966561423582124743958440217334490291076816262444729529 +/- 7.62e-80], [0.7439803369574931876584164068755143686246000134913048273972932147596664655583041 +/- 5.46e-80])
</H2>

<H2 Title="exp10(x); x=(4.333, 1)">
cmath53:  (-14384.9200625295, 16016.2728039618)
  scplx:  (-14384.92, 16016.27)
  dcplx:  (94.7655526790214, 147.588603773499)
  ecplx:  (-14384.920062529476261, 16016.272803961756472)
  qcplx:  (-14384.9200625294762588100268183822, 16016.2728039617564717468009102051)
  ocplx:  (-14384.920062529476258810026818382212458384385235879270180825331836115954, 16016.272803961756471746800910205122976908573649176427332804838638421648)
  mcplx:  (-14384.920062529476258810026818382212458384385235879270180825331836115953695472635, 16016.272803961756471746800910205122976908573649176427332804838638421648477288957)
sflintc:  (-14384.93, 16016.28)
dflintc:  (-14384.9200625295, 16016.2728039618)
eflintc:  (-14384.920062529476259, 16016.272803961756471)
qflintc:  (-14384.9200625294762588100268183822, 16016.2728039617564717468009102051)
oflintc:  (-14384.920062529476258810026818382212458384385235879270180825331836115953, 16016.272803961756471746800910205122976908573649176427332804838638421648)
mflintc:  (-14384.920062529476258810026818382212458384385235879270180825331836115953695472635, 16016.272803961756471746800910205122976908573649176427332804838638421648477288957)
aflintc: ([-14384.9200625294762588100268183822124583843852358792701808253318361159536954726 +/- 4.02e-74], [16016.27280396175647174680091020512297690857364917642733280483863842164847728896 +/- 9.03e-75])
</H2>

</H1>
<H1 Title="TestExp10RealImag">
<H2 Title="Re(exp10(x)); x=(-4.333, 1)">
cmath53:  -3.1038980841031E-05
  scplx:  -3.103898E-05
  dcplx:  0.0163325696764116
  ecplx:  -3.1038980841031001948e-05
  qcplx:  -3.10389808410310019480581120303672e-05
  ocplx:  -3.1038980841031001948058112030367255832499259526459769060907653623655312e-05
  mcplx:  -3.1038980841031001948058112030367255832499259526459769060907653623655312275047606E-05
sflintc:  -3.103897E-05
dflintc:  -3.1038980841031E-05
eflintc:  -3.1038980841031001948e-05
qflintc:  -3.10389808410310019480581120303673e-05
oflintc:  -3.1038980841031001948058112030367255832499259526459769060907653623655313e-05
mflintc:  -3.1038980841031001948058112030367255832499259526459769060907653623655312275047606E-05
aflintc: [-3.10389808410310019480581120303672558324992595264597690609076536236553122750476e-5 +/- 1.71e-83]
</H2>

<H2 Title="Im(exp10(x)); x=(-4.333, 1)">
cmath53:  3.45590230982124E-05
  scplx:  3.455902E-05
  dcplx:  0.0254364701775078
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
aflintc: [3.45590230982123800016594692825887012662704869367690968009702290296777118357798e-5 +/- 3.23e-83]
</H2>

<H2 Title="Re(exp10(x)); x=(0, 1)">
cmath53:  -0.668201510190313
  scplx:  -0.6682015
  dcplx:  1.24409203520229
  ecplx:  -0.66820151019031294627
  qcplx:  -0.668201510190312946242330696656142
  ocplx:  -0.66820151019031294624233069665614235821247439584402173344902910768162624
  mcplx:  -0.66820151019031294624233069665614235821247439584402173344902910768162624447295294
sflintc:  -0.6682015
dflintc:  -0.668201510190313
eflintc:  -0.66820151019031294622
qflintc:  -0.668201510190312946242330696656142
oflintc:  -0.66820151019031294624233069665614235821247439584402173344902910768162624
mflintc:  -0.66820151019031294624233069665614235821247439584402173344902910768162624447295294
aflintc: [-0.6682015101903129462423306966561423582124743958440217334490291076816262444729529 +/- 7.62e-80]
</H2>

<H2 Title="Im(exp10(x)); x=(0, 1)">
cmath53:  0.743980336957493
  scplx:  0.7439803
  dcplx:  1.93755854580568
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
aflintc: [0.7439803369574931876584164068755143686246000134913048273972932147596664655583041 +/- 5.46e-80]
</H2>

<H2 Title="Re(exp10(x)); x=(4.333, 1)">
cmath53:  -14384.9200625295
  scplx:  -14384.92
  dcplx:  94.7655526790214
  ecplx:  -14384.920062529476261
  qcplx:  -14384.9200625294762588100268183822
  ocplx:  -14384.920062529476258810026818382212458384385235879270180825331836115954
  mcplx:  -14384.920062529476258810026818382212458384385235879270180825331836115953695472635
sflintc:  -14384.93
dflintc:  -14384.9200625295
eflintc:  -14384.920062529476259
qflintc:  -14384.9200625294762588100268183822
oflintc:  -14384.920062529476258810026818382212458384385235879270180825331836115953
mflintc:  -14384.920062529476258810026818382212458384385235879270180825331836115953695472635
aflintc: [-14384.9200625294762588100268183822124583843852358792701808253318361159536954726 +/- 4.02e-74]
</H2>

<H2 Title="Im(exp10(x)); x=(4.333, 1)">
cmath53:  16016.2728039618
  scplx:  16016.27
  dcplx:  147.588603773499
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
aflintc: [16016.27280396175647174680091020512297690857364917642733280483863842164847728896 +/- 9.03e-75]
</H2>

</H1>
<H1 Title="General Info">
Elapsed Time 00:00:00.17
------------------------------------------------
Memory used before collection:       4,863,480
Memory used after full collection:   4,783,984
------------------------------------------------

</H1>


*/
#endregion

