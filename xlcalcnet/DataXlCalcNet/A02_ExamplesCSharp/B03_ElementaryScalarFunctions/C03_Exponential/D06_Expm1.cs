
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
    TestExpm1Real();
    TestExpm1Cplx();
    TestExpm1RealImag();
}


#region TestExpm1Real

public static void TestExpm1Real()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExpm1Real" + "\"" + ">");
    double[] InputArray1 = { -4.333, 0.0, 4.333 };
    
    foreach (var x in InputArray1) {
        Console.WriteLine("<H2 Title=" + "\"" + "expm1(x); " + "x={0}" 
            + "\"" + ">", x);
        Double res01 = math53.expm1(x);
        Console.WriteLine("math53:  {0}", res01);
        Single res02 = sreal.expm1(x);
        Console.WriteLine(" sreal:  {0}", res02);
        Double res03 = dreal.expm1(x);
        Console.WriteLine(" dreal:  {0}", res03);
        Extended res04 = ereal.expm1(x);
        Console.WriteLine(" ereal:  {0}", res04);
        Quadruple res05 = qreal.expm1(x);
        Console.WriteLine(" qreal:  {0}", res05);
        Octuple res06 = oreal.expm1(x);
        Console.WriteLine(" oreal:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Mpfr res07 = mreal.expm1(x);
        Console.WriteLine(" mreal:  {0}", res07);
        Single res08 = sflint.expm1(x);
        Console.WriteLine("sflint:  {0}", res08);
        Double res09 = dflint.expm1(x);
        Console.WriteLine("dflint:  {0}", res09);
        Extended res10 = eflint.expm1(x);
        Console.WriteLine("eflint:  {0}", res10);
        Quadruple res11 = qflint.expm1(x);
        Console.WriteLine("qflint:  {0}", res11);
        Octuple res12 = oflint.expm1(x);
        Console.WriteLine("oflint:  {0}", res12);
        Mpfr res13 = mflint.expm1(x);
        Console.WriteLine("mflint:  {0}", res13);
        Arb res16 = aflint.expm1(x);
        Console.WriteLine("aflint: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExpm1Cplx

public static void TestExpm1Cplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExpm1Cplx" + "\"" + ">");
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};

    foreach (var x in InputArray1C) {
        Console.WriteLine("<H2 Title=" + "\"" + "expm1(x); " + "x={0}" + 
            "\"" + ">", x);
        Complex res01 = cmath53.expm1(x);
        Console.WriteLine("cmath53:  {0}", res01);
        SingleC res02 = scplx.expm1(x);
        Console.WriteLine("  scplx:  {0}", res02);
        Complex res03 = dcplx.expm1(x);
        Console.WriteLine("  dcplx:  {0}", res03);
        ExtendedC res04 = ecplx.expm1(x);
        Console.WriteLine("  ecplx:  {0}", res04);
        QuadrupleC res05 = qcplx.expm1(x);
        Console.WriteLine("  qcplx:  {0}", res05);
        OctupleC res06 = ocplx.expm1(x);
        Console.WriteLine("  ocplx:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        MpfrC res07 = mcplx.expm1(x);
        Console.WriteLine("  mcplx:  {0}", res07);
        SingleC res08 = sflintc.expm1(x);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.expm1(x);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.expm1(x);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.expm1(x);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.expm1(x);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.expm1(x);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.expm1(x);
        Console.WriteLine("aflintc: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExpm1RealImag

public static void TestExpm1RealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExpm1RealImag" + 
        "\"" + ">");
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    foreach (var x in InputArray1C) {
    foreach (var IsReal in ReImArray)
    {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "expm1(x)); x={0}" 
            + "\"" + ">", x);

        Complex res01c = cmath53.expm1(x); 
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);

        SingleC res02c = scplx.expm1(x);
        Single res02 = IsReal ? res02c.real : res02c.imag;
        Console.WriteLine("  scplx:  {0}", res02);

        Complex res03c = dcplx.expm1(x);
        Double res03 = IsReal ? res03c.Real : res03c.Imaginary;
        Console.WriteLine("  dcplx:  {0}", res03);

        ExtendedC res04c = ecplx.expm1(x);
        Extended res04 = IsReal ? res04c.real : res04c.imag;
        Console.WriteLine("  ecplx:  {0}", res04);

        QuadrupleC res05c = qcplx.expm1(x);
        Quadruple res05 = IsReal ? res05c.real : res05c.imag;
        Console.WriteLine("  qcplx:  {0}", res05);

        OctupleC res06c = ocplx.expm1(x);
        Octuple res06 = IsReal ? res06c.real : res06c.imag;
        Console.WriteLine("  ocplx:  {0}", res06);

#if HasArbPrecNet
        MpfrC res07c = mcplx.expm1(x);
        Mpfr res07 = IsReal ? res07c.real : res07c.imag;
        Console.WriteLine("  mcplx:  {0}", res07);

        SingleC res08c = sflintc.expm1(x);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.expm1(x);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.expm1(x);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.expm1(x);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.expm1(x);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.expm1(x);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.expm1(x);
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
<H1 Title="TestExpm1Real">
<H2 Title="expm1(x); x=-4.333">
math53:  -0.986871895957636
 sreal:  -0.9868719
 dreal:  -0.986871895957636
 ereal:  -0.98687189595763633151
 qreal:  -0.986871895957636331491894665772766
 oreal:  -0.9868718959576363314918946657727663393836882888779481072520175685537812
 mreal:  -0.9868718959576363314918946657727663393836882888779481072520175685537812001000308
sflint:  -0.9868719
dflint:  -0.986871895957636
eflint:  -0.98687189595763633151
qflint:  -0.986871895957636331491894665772766
oflint:  -0.9868718959576363314918946657727663393836882888779481072520175685537812
mflint:  -0.9868718959576363314918946657727663393836882888779481072520175685537812001000308
aflint: [-0.9868718959576363314918946657727663393836882888779481072520175685537812001000308 +/- 1.31e-80]
</H2>

<H2 Title="expm1(x); x=0">
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

<H2 Title="expm1(x); x=4.333">
math53:  75.1724615201902
 sreal:  75.17248
 dreal:  75.1724615201902
 ereal:  75.17246152019020345
 qreal:  75.1724615201902034530083631602067
 oreal:  75.172461520190203453008363160206665292325717803567092007188182036364935
 mreal:  75.17246152019020345300836316020666529232571780356709200718818203636493561899972
sflint:  75.17248
dflint:  75.1724615201902
eflint:  75.17246152019020345
qflint:  75.1724615201902034530083631602067
oflint:  75.172461520190203453008363160206665292325717803567092007188182036364935
mflint:  75.17246152019020345300836316020666529232571780356709200718818203636493561899972
aflint: [75.17246152019020345300836316020666529232571780356709200718818203636493561899972 +/- 2.39e-78]
</H2>

</H1>
<H1 Title="TestExpm1Cplx">
<H2 Title="expm1(x); x=(-4.333, 1)">
cmath53:  (-0.992906855114234, 0.0110469186371883)
  scplx:  (-0.9929069, 0.01104692)
  dcplx:  (-0.992906855114234, 0.0110469186371883)
  ecplx:  (-0.99290685511423406375, 0.011046918637188283221)
  qcplx:  (-0.992906855114234063723467088047618, 0.0110469186371882832201614097031261)
  ocplx:  (-0.99290685511423406372346708804761816587935483999875653856266172459409789, 0.0110469186371882832201614097031261270713302308515755023373461343641356)
  mcplx:  (-0.99290685511423406372346708804761816587935483999875653856266172459409788485221603, 0.011046918637188283220161409703126127071330230851575502337346134364135599723977506)
sflintc:  (-0.9929069, 0.01104692)
dflintc:  (-0.992906855114234, 0.0110469186371883)
eflintc:  (-0.99290685511423406375, 0.01104691863718828322)
qflintc:  (-0.992906855114234063723467088047618, 0.0110469186371882832201614097031261)
oflintc:  (-0.99290685511423406372346708804761816587935483999875653856266172459409789, 0.0110469186371882832201614097031261270713302308515755023373461343641356)
mflintc:  (-0.99290685511423406372346708804761816587935483999875653856266172459409788485221603, 0.011046918637188283220161409703126127071330230851575502337346134364135599723977506)
aflintc: ([-0.9929068551142340637234670880476181658793548399987565385626617245940978848522160 +/- 3.99e-80], [0.011046918637188283220161409703126127071330230851575502337346134364135599723977506 +/- 4.69e-82])
</H2>

<H2 Title="expm1(x); x=(0, 1)">
cmath53:  (-0.45969769413186, 0.841470984807897)
  scplx:  (-0.4596977, 0.841471)
  dcplx:  (-0.45969769413186, 0.841470984807897)
  ecplx:  (-0.45969769413186028259, 0.84147098480789650666)
  qcplx:  (-0.459697694131860282599063392557023, 0.841470984807896506652502321630299)
  ocplx:  (-0.45969769413186028259906339255702339626768957938207777232990274461889961, 0.84147098480789650665250232163029899962256306079837106567275170999191039)
  mcplx:  (-0.45969769413186028259906339255702339626768957938207777232990274461889960522552823, 0.84147098480789650665250232163029899962256306079837106567275170999191040439123967)
sflintc:  (-0.4596977, 0.841471)
dflintc:  (-0.45969769413186, 0.841470984807897)
eflintc:  (-0.45969769413186028259, 0.84147098480789650666)
qflintc:  (-0.459697694131860282599063392557023, 0.841470984807896506652502321630299)
oflintc:  (-0.45969769413186028259906339255702339626768957938207777232990274461889961, 0.84147098480789650665250232163029899962256306079837106567275170999191041)
mflintc:  (-0.45969769413186028259906339255702339626768957938207777232990274461889960522552823, 0.84147098480789650665250232163029899962256306079837106567275170999191040439123967)
aflintc: ([-0.45969769413186028259906339255702339626768957938207777232990274461889960522552823 +/- 7.24e-81], [0.8414709848078965066525023216302989996225630607983710656727517099919104043912397 +/- 4.16e-80])
</H2>

<H2 Title="expm1(x); x=(4.333, 1)">
cmath53:  (40.1561566030109, 64.0969162106361)
  scplx:  (40.15616, 64.09693)
  dcplx:  (40.1561566030109, 64.0969162106361)
  ecplx:  (40.15615660301091018, 64.096916210636051929)
  qcplx:  (40.1561566030109101819510191140896, 64.0969162106360519320469669199818)
  ocplx:  (40.156156603010910181951019114089589195574940851362764084058576043726435, 64.096916210636051932046966919981766482316288249294348552688812952153927)
  mcplx:  (40.156156603010910181951019114089589195574940851362764084058576043726435191938411, 64.096916210636051932046966919981766482316288249294348552688812952153927852487333)
sflintc:  (40.15616, 64.09693)
dflintc:  (40.1561566030109, 64.0969162106361)
eflintc:  (40.15615660301091018, 64.096916210636051929)
qflintc:  (40.1561566030109101819510191140896, 64.0969162106360519320469669199818)
oflintc:  (40.156156603010910181951019114089589195574940851362764084058576043726435, 64.096916210636051932046966919981766482316288249294348552688812952153927)
mflintc:  (40.156156603010910181951019114089589195574940851362764084058576043726435191938411, 64.096916210636051932046966919981766482316288249294348552688812952153927852487333)
aflintc: ([40.15615660301091018195101911408958919557494085136276408405857604372643519193841 +/- 2.09e-78], [64.096916210636051932046966919981766482316288249294348552688812952153927852487333 +/- 4.99e-79])
</H2>

</H1>
<H1 Title="TestExpm1RealImag">
<H2 Title="Re(expm1(x)); x=(-4.333, 1)">
cmath53:  -0.992906855114234
  scplx:  -0.9929069
  dcplx:  -0.992906855114234
  ecplx:  -0.99290685511423406375
  qcplx:  -0.992906855114234063723467088047618
  ocplx:  -0.99290685511423406372346708804761816587935483999875653856266172459409789
  mcplx:  -0.99290685511423406372346708804761816587935483999875653856266172459409788485221603
sflintc:  -0.9929069
dflintc:  -0.992906855114234
eflintc:  -0.99290685511423406375
qflintc:  -0.992906855114234063723467088047618
oflintc:  -0.99290685511423406372346708804761816587935483999875653856266172459409789
mflintc:  -0.99290685511423406372346708804761816587935483999875653856266172459409788485221603
aflintc: [-0.9929068551142340637234670880476181658793548399987565385626617245940978848522160 +/- 3.99e-80]
</H2>

<H2 Title="Im(expm1(x)); x=(-4.333, 1)">
cmath53:  0.0110469186371883
  scplx:  0.01104692
  dcplx:  0.0110469186371883
  ecplx:  0.011046918637188283221
  qcplx:  0.0110469186371882832201614097031261
  ocplx:  0.0110469186371882832201614097031261270713302308515755023373461343641356
  mcplx:  0.011046918637188283220161409703126127071330230851575502337346134364135599723977506
sflintc:  0.01104692
dflintc:  0.0110469186371883
eflintc:  0.01104691863718828322
qflintc:  0.0110469186371882832201614097031261
oflintc:  0.0110469186371882832201614097031261270713302308515755023373461343641356
mflintc:  0.011046918637188283220161409703126127071330230851575502337346134364135599723977506
aflintc: [0.011046918637188283220161409703126127071330230851575502337346134364135599723977506 +/- 4.69e-82]
</H2>

<H2 Title="Re(expm1(x)); x=(0, 1)">
cmath53:  -0.45969769413186
  scplx:  -0.4596977
  dcplx:  -0.45969769413186
  ecplx:  -0.45969769413186028259
  qcplx:  -0.459697694131860282599063392557023
  ocplx:  -0.45969769413186028259906339255702339626768957938207777232990274461889961
  mcplx:  -0.45969769413186028259906339255702339626768957938207777232990274461889960522552823
sflintc:  -0.4596977
dflintc:  -0.45969769413186
eflintc:  -0.45969769413186028259
qflintc:  -0.459697694131860282599063392557023
oflintc:  -0.45969769413186028259906339255702339626768957938207777232990274461889961
mflintc:  -0.45969769413186028259906339255702339626768957938207777232990274461889960522552823
aflintc: [-0.45969769413186028259906339255702339626768957938207777232990274461889960522552823 +/- 7.24e-81]
</H2>

<H2 Title="Im(expm1(x)); x=(0, 1)">
cmath53:  0.841470984807897
  scplx:  0.841471
  dcplx:  0.841470984807897
  ecplx:  0.84147098480789650666
  qcplx:  0.841470984807896506652502321630299
  ocplx:  0.84147098480789650665250232163029899962256306079837106567275170999191039
  mcplx:  0.84147098480789650665250232163029899962256306079837106567275170999191040439123967
sflintc:  0.841471
dflintc:  0.841470984807897
eflintc:  0.84147098480789650666
qflintc:  0.841470984807896506652502321630299
oflintc:  0.84147098480789650665250232163029899962256306079837106567275170999191041
mflintc:  0.84147098480789650665250232163029899962256306079837106567275170999191040439123967
aflintc: [0.8414709848078965066525023216302989996225630607983710656727517099919104043912397 +/- 4.16e-80]
</H2>

<H2 Title="Re(expm1(x)); x=(4.333, 1)">
cmath53:  40.1561566030109
  scplx:  40.15616
  dcplx:  40.1561566030109
  ecplx:  40.15615660301091018
  qcplx:  40.1561566030109101819510191140896
  ocplx:  40.156156603010910181951019114089589195574940851362764084058576043726435
  mcplx:  40.156156603010910181951019114089589195574940851362764084058576043726435191938411
sflintc:  40.15616
dflintc:  40.1561566030109
eflintc:  40.15615660301091018
qflintc:  40.1561566030109101819510191140896
oflintc:  40.156156603010910181951019114089589195574940851362764084058576043726435
mflintc:  40.156156603010910181951019114089589195574940851362764084058576043726435191938411
aflintc: [40.15615660301091018195101911408958919557494085136276408405857604372643519193841 +/- 2.09e-78]
</H2>

<H2 Title="Im(expm1(x)); x=(4.333, 1)">
cmath53:  64.0969162106361
  scplx:  64.09693
  dcplx:  64.0969162106361
  ecplx:  64.096916210636051929
  qcplx:  64.0969162106360519320469669199818
  ocplx:  64.096916210636051932046966919981766482316288249294348552688812952153927
  mcplx:  64.096916210636051932046966919981766482316288249294348552688812952153927852487333
sflintc:  64.09693
dflintc:  64.0969162106361
eflintc:  64.096916210636051929
qflintc:  64.0969162106360519320469669199818
oflintc:  64.096916210636051932046966919981766482316288249294348552688812952153927
mflintc:  64.096916210636051932046966919981766482316288249294348552688812952153927852487333
aflintc: [64.096916210636051932046966919981766482316288249294348552688812952153927852487333 +/- 4.99e-79]
</H2>

</H1>
<H1 Title="General Info">
Elapsed Time 00:00:00.17
------------------------------------------------
Memory used before collection:       4,856,096
Memory used after full collection:   4,796,832
------------------------------------------------

</H1>


*/
#endregion

