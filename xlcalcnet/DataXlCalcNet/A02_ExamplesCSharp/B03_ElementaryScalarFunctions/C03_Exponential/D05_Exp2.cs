
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
    TestExp2Real();
    TestExp2Cplx();
    TestExp2RealImag();
}


#region TestExp2Real

public static void TestExp2Real()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExp2Real" + "\"" + ">");
    double[] InputArray1 = { -4.333, 0.0, 4.333 };
    
    foreach (var x in InputArray1) {
        Console.WriteLine("<H2 Title=" + "\"" + "exp2(x); " + "x={0}" 
            + "\"" + ">", x);
        Double res01 = math53.exp2(x);
        Console.WriteLine("math53:  {0}", res01);
        Single res02 = sreal.exp2(x);
        Console.WriteLine(" sreal:  {0}", res02);
        Double res03 = dreal.exp2(x);
        Console.WriteLine(" dreal:  {0}", res03);
        Extended res04 = ereal.exp2(x);
        Console.WriteLine(" ereal:  {0}", res04);
        Quadruple res05 = qreal.exp2(x);
        Console.WriteLine(" qreal:  {0}", res05);
        Octuple res06 = oreal.exp2(x);
        Console.WriteLine(" oreal:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Mpfr res07 = mreal.exp2(x);
        Console.WriteLine(" mreal:  {0}", res07);
        Single res08 = sflint.exp2(x);
        Console.WriteLine("sflint:  {0}", res08);
        Double res09 = dflint.exp2(x);
        Console.WriteLine("dflint:  {0}", res09);
        Extended res10 = eflint.exp2(x);
        Console.WriteLine("eflint:  {0}", res10);
        Quadruple res11 = qflint.exp2(x);
        Console.WriteLine("qflint:  {0}", res11);
        Octuple res12 = oflint.exp2(x);
        Console.WriteLine("oflint:  {0}", res12);
        Mpfr res13 = mflint.exp2(x);
        Console.WriteLine("mflint:  {0}", res13);
        Arb res16 = aflint.exp2(x);
        Console.WriteLine("aflint: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExp2Cplx

public static void TestExp2Cplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExp2Cplx" + "\"" + ">");
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};

    foreach (var x in InputArray1C) {
        Console.WriteLine("<H2 Title=" + "\"" + "exp2(x); " + "x={0}" + 
            "\"" + ">", x);
        Complex res01 = cmath53.exp2(x);
        Console.WriteLine("cmath53:  {0}", res01);
        SingleC res02 = scplx.exp2(x);
        Console.WriteLine("  scplx:  {0}", res02);
        Complex res03 = dcplx.exp2(x);
        Console.WriteLine("  dcplx:  {0}", res03);
        ExtendedC res04 = ecplx.exp2(x);
        Console.WriteLine("  ecplx:  {0}", res04);
        QuadrupleC res05 = qcplx.exp2(x);
        Console.WriteLine("  qcplx:  {0}", res05);
        OctupleC res06 = ocplx.exp2(x);
        Console.WriteLine("  ocplx:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        MpfrC res07 = mcplx.exp2(x);
        Console.WriteLine("  mcplx:  {0}", res07);
        SingleC res08 = sflintc.exp2(x);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.exp2(x);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.exp2(x);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.exp2(x);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.exp2(x);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.exp2(x);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.exp2(x);
        Console.WriteLine("aflintc: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExp2RealImag

public static void TestExp2RealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExp2RealImag" + 
        "\"" + ">");
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    foreach (var x in InputArray1C) {
    foreach (var IsReal in ReImArray)
    {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "exp2(x)); x={0}" 
            + "\"" + ">", x);

        Complex res01c = cmath53.exp2(x); 
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);

        SingleC res02c = scplx.exp2(x);
        Single res02 = IsReal ? res02c.real : res02c.imag;
        Console.WriteLine("  scplx:  {0}", res02);

        Complex res03c = dcplx.exp2(x);
        Double res03 = IsReal ? res03c.Real : res03c.Imaginary;
        Console.WriteLine("  dcplx:  {0}", res03);

        ExtendedC res04c = ecplx.exp2(x);
        Extended res04 = IsReal ? res04c.real : res04c.imag;
        Console.WriteLine("  ecplx:  {0}", res04);

        QuadrupleC res05c = qcplx.exp2(x);
        Quadruple res05 = IsReal ? res05c.real : res05c.imag;
        Console.WriteLine("  qcplx:  {0}", res05);

        OctupleC res06c = ocplx.exp2(x);
        Octuple res06 = IsReal ? res06c.real : res06c.imag;
        Console.WriteLine("  ocplx:  {0}", res06);

#if HasArbPrecNet
        MpfrC res07c = mcplx.exp2(x);
        Mpfr res07 = IsReal ? res07c.real : res07c.imag;
        Console.WriteLine("  mcplx:  {0}", res07);

        SingleC res08c = sflintc.exp2(x);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.exp2(x);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.exp2(x);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.exp2(x);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.exp2(x);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.exp2(x);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.exp2(x);
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
<H1 Title="TestExp2Real">
<H2 Title="exp2(x); x=-4.333">
math53:  0.0496177456832283
 sreal:  0.04961774
 dreal:  0.0496177456832283
 ereal:  0.049617745683228280787
 qreal:  0.0496177456832282807859457677485193
 oreal:  0.049617745683228280785945767748519326482796737735112799167030514293043514
 mreal:  0.049617745683228280785945767748519326482796737735112799167030514293043513864686821
sflint:  0.04961774
dflint:  0.0496177456832283
eflint:  0.049617745683228280787
qflint:  0.0496177456832282807859457677485193
oflint:  0.049617745683228280785945767748519326482796737735112799167030514293043514
mflint:  0.049617745683228280785945767748519326482796737735112799167030514293043513864686821
aflint: [0.04961774568322828078594576774851932648279673773511279916703051429304351386468682 +/- 4.39e-81]
</H2>

<H2 Title="exp2(x); x=0">
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

<H2 Title="exp2(x); x=4.333">
math53:  20.1540796791584
 sreal:  20.15408
 dreal:  20.1540796791584
 ereal:  20.154079679158389604
 qreal:  20.1540796791583896040750742811253
 oreal:  20.154079679158389604075074281125299605023496131781872961165915405711522
 mreal:  20.154079679158389604075074281125299605023496131781872961165915405711521827344194
sflint:  20.15408
dflint:  20.1540796791584
eflint:  20.154079679158389604
qflint:  20.1540796791583896040750742811253
oflint:  20.154079679158389604075074281125299605023496131781872961165915405711522
mflint:  20.154079679158389604075074281125299605023496131781872961165915405711521827344194
aflint: [20.15407967915838960407507428112529960502349613178187296116591540571152182734419 +/- 4.84e-78]
</H2>

</H1>
<H1 Title="TestExp2Cplx">
<H2 Title="exp2(x); x=(-4.333, 1)">
cmath53:  (0.0381679001775235, 0.0317038181095609)
  scplx:  (0.0381679, 0.03170381)
  dcplx:  (0.00491659337887185, 0.00765714050724217)
  ecplx:  (0.038167900177523493251, 0.031703818109560885891)
  qcplx:  (0.0381679001775234932562476890759258, 0.0317038181095608858911463963544357)
  ocplx:  (0.038167900177523493256247689075925836425219975440798758958711099481114517, 0.031703818109560885891146396354435658218365964389910936162571013151618572)
  mcplx:  (0.038167900177523493256247689075925836425219975440798758958711099481114517051910217, 0.031703818109560885891146396354435658218365964389910936162571013151618571963821601)
sflintc:  (0.03816789, 0.03170381)
dflintc:  (0.0381679001775235, 0.0317038181095609)
eflintc:  (0.038167900177523493257, 0.031703818109560885891)
qflintc:  (0.0381679001775234932562476890759258, 0.0317038181095608858911463963544357)
oflintc:  (0.038167900177523493256247689075925836425219975440798758958711099481114517, 0.031703818109560885891146396354435658218365964389910936162571013151618572)
mflintc:  (0.038167900177523493256247689075925836425219975440798758958711099481114517051910217, 0.031703818109560885891146396354435658218365964389910936162571013151618571963821601)
aflintc: ([0.03816790017752349325624768907592583642521997544079875895871109948111451705191022 +/- 6.21e-81], [0.03170381810956088589114639635443565821836596438991093616257101315161857196382160 +/- 4.28e-81])
</H2>

<H2 Title="exp2(x); x=(0, 1)">
cmath53:  (0.769238901363972, 0.638961276313635)
  scplx:  (0.7692389, 0.6389613)
  dcplx:  (0.374509019962538, 0.583263240642594)
  ecplx:  (0.76923890136397212656, 0.63896127631363480118)
  qcplx:  (0.769238901363972126578329993661271, 0.638961276313634801150032911464702)
  ocplx:  (0.76923890136397212657832999366127070144089599491196385316987150742908135, 0.63896127631363480115003291146470178425723053783057972949558695664632452)
  mcplx:  (0.76923890136397212657832999366127070144089599491196385316987150742908134680734078, 0.63896127631363480115003291146470178425723053783057972949558695664632452244854475)
sflintc:  (0.7692389, 0.6389613)
dflintc:  (0.769238901363972, 0.638961276313635)
eflintc:  (0.76923890136397212656, 0.63896127631363480113)
qflintc:  (0.769238901363972126578329993661271, 0.638961276313634801150032911464702)
oflintc:  (0.76923890136397212657832999366127070144089599491196385316987150742908135, 0.63896127631363480115003291146470178425723053783057972949558695664632452)
mflintc:  (0.76923890136397212657832999366127070144089599491196385316987150742908134680734078, 0.63896127631363480115003291146470178425723053783057972949558695664632452244854475)
aflintc: ([0.7692389013639721265783299936612707014408959949119638531698715074290813468073408 +/- 3.04e-80], [0.6389612763136348011500329114647017842572305378305797294955869566463245224485447 +/- 5.72e-80])
</H2>

<H2 Title="exp2(x); x=(4.333, 1)">
cmath53:  (15.5033021103978, 12.8776764747217)
  scplx:  (15.5033, 12.87768)
  dcplx:  (28.5272739120606, 44.4285967539894)
  ecplx:  (15.503302110397755466, 12.877676474721736003)
  qcplx:  (15.5033021103977554640209209895341, 12.8776764747217360000597048855729)
  ocplx:  (15.503302110397755464020920989534109673121892088890044103835087139016297, 12.877676474721736000059704885572874872067877375900804568471748802240913)
  mcplx:  (15.503302110397755464020920989534109673121892088890044103835087139016297354862877, 12.877676474721736000059704885572874872067877375900804568471748802240913456232493)
sflintc:  (15.5033, 12.87768)
dflintc:  (15.5033021103978, 12.8776764747217)
eflintc:  (15.503302110397755464, 12.877676474721736)
qflintc:  (15.5033021103977554640209209895341, 12.8776764747217360000597048855729)
oflintc:  (15.503302110397755464020920989534109673121892088890044103835087139016297, 12.877676474721736000059704885572874872067877375900804568471748802240913)
mflintc:  (15.503302110397755464020920989534109673121892088890044103835087139016297354862877, 12.877676474721736000059704885572874872067877375900804568471748802240913456232493)
aflintc: ([15.50330211039775546402092098953410967312189208889004410383508713901629735486288 +/- 4.89e-78], [12.87767647472173600005970488557287487206787737590080456847174880224091345623249 +/- 4.11e-78])
</H2>

</H1>
<H1 Title="TestExp2RealImag">
<H2 Title="Re(exp2(x)); x=(-4.333, 1)">
cmath53:  0.0381679001775235
  scplx:  0.0381679
  dcplx:  0.00491659337887185
  ecplx:  0.038167900177523493251
  qcplx:  0.0381679001775234932562476890759258
  ocplx:  0.038167900177523493256247689075925836425219975440798758958711099481114517
  mcplx:  0.038167900177523493256247689075925836425219975440798758958711099481114517051910217
sflintc:  0.03816789
dflintc:  0.0381679001775235
eflintc:  0.038167900177523493257
qflintc:  0.0381679001775234932562476890759258
oflintc:  0.038167900177523493256247689075925836425219975440798758958711099481114517
mflintc:  0.038167900177523493256247689075925836425219975440798758958711099481114517051910217
aflintc: [0.03816790017752349325624768907592583642521997544079875895871109948111451705191022 +/- 6.21e-81]
</H2>

<H2 Title="Im(exp2(x)); x=(-4.333, 1)">
cmath53:  0.0317038181095609
  scplx:  0.03170381
  dcplx:  0.00765714050724217
  ecplx:  0.031703818109560885891
  qcplx:  0.0317038181095608858911463963544357
  ocplx:  0.031703818109560885891146396354435658218365964389910936162571013151618572
  mcplx:  0.031703818109560885891146396354435658218365964389910936162571013151618571963821601
sflintc:  0.03170381
dflintc:  0.0317038181095609
eflintc:  0.031703818109560885891
qflintc:  0.0317038181095608858911463963544357
oflintc:  0.031703818109560885891146396354435658218365964389910936162571013151618572
mflintc:  0.031703818109560885891146396354435658218365964389910936162571013151618571963821601
aflintc: [0.03170381810956088589114639635443565821836596438991093616257101315161857196382160 +/- 4.28e-81]
</H2>

<H2 Title="Re(exp2(x)); x=(0, 1)">
cmath53:  0.769238901363972
  scplx:  0.7692389
  dcplx:  0.374509019962538
  ecplx:  0.76923890136397212656
  qcplx:  0.769238901363972126578329993661271
  ocplx:  0.76923890136397212657832999366127070144089599491196385316987150742908135
  mcplx:  0.76923890136397212657832999366127070144089599491196385316987150742908134680734078
sflintc:  0.7692389
dflintc:  0.769238901363972
eflintc:  0.76923890136397212656
qflintc:  0.769238901363972126578329993661271
oflintc:  0.76923890136397212657832999366127070144089599491196385316987150742908135
mflintc:  0.76923890136397212657832999366127070144089599491196385316987150742908134680734078
aflintc: [0.7692389013639721265783299936612707014408959949119638531698715074290813468073408 +/- 3.04e-80]
</H2>

<H2 Title="Im(exp2(x)); x=(0, 1)">
cmath53:  0.638961276313635
  scplx:  0.6389613
  dcplx:  0.583263240642594
  ecplx:  0.63896127631363480118
  qcplx:  0.638961276313634801150032911464702
  ocplx:  0.63896127631363480115003291146470178425723053783057972949558695664632452
  mcplx:  0.63896127631363480115003291146470178425723053783057972949558695664632452244854475
sflintc:  0.6389613
dflintc:  0.638961276313635
eflintc:  0.63896127631363480113
qflintc:  0.638961276313634801150032911464702
oflintc:  0.63896127631363480115003291146470178425723053783057972949558695664632452
mflintc:  0.63896127631363480115003291146470178425723053783057972949558695664632452244854475
aflintc: [0.6389612763136348011500329114647017842572305378305797294955869566463245224485447 +/- 5.72e-80]
</H2>

<H2 Title="Re(exp2(x)); x=(4.333, 1)">
cmath53:  15.5033021103978
  scplx:  15.5033
  dcplx:  28.5272739120606
  ecplx:  15.503302110397755466
  qcplx:  15.5033021103977554640209209895341
  ocplx:  15.503302110397755464020920989534109673121892088890044103835087139016297
  mcplx:  15.503302110397755464020920989534109673121892088890044103835087139016297354862877
sflintc:  15.5033
dflintc:  15.5033021103978
eflintc:  15.503302110397755464
qflintc:  15.5033021103977554640209209895341
oflintc:  15.503302110397755464020920989534109673121892088890044103835087139016297
mflintc:  15.503302110397755464020920989534109673121892088890044103835087139016297354862877
aflintc: [15.50330211039775546402092098953410967312189208889004410383508713901629735486288 +/- 4.89e-78]
</H2>

<H2 Title="Im(exp2(x)); x=(4.333, 1)">
cmath53:  12.8776764747217
  scplx:  12.87768
  dcplx:  44.4285967539894
  ecplx:  12.877676474721736003
  qcplx:  12.8776764747217360000597048855729
  ocplx:  12.877676474721736000059704885572874872067877375900804568471748802240913
  mcplx:  12.877676474721736000059704885572874872067877375900804568471748802240913456232493
sflintc:  12.87768
dflintc:  12.8776764747217
eflintc:  12.877676474721736
qflintc:  12.8776764747217360000597048855729
oflintc:  12.877676474721736000059704885572874872067877375900804568471748802240913
mflintc:  12.877676474721736000059704885572874872067877375900804568471748802240913456232493
aflintc: [12.87767647472173600005970488557287487206787737590080456847174880224091345623249 +/- 4.11e-78]
</H2>

</H1>
<H1 Title="General Info">
Elapsed Time 00:00:00.17
------------------------------------------------
Memory used before collection:       4,856,544
Memory used after full collection:   4,796,824
------------------------------------------------

</H1>


*/
#endregion

