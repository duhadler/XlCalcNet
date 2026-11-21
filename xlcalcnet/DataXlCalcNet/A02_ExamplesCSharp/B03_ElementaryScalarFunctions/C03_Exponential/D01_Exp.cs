
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
    TestExpReal();
    TestExpCplx();
    TestExpRealImag();
}


#region TestExpReal

public static void TestExpReal()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExpReal" + "\"" + ">");
    double[] InputArray1 = { -4.333, 0.0, 4.333 };
    
    foreach (var x in InputArray1) {
        Console.WriteLine("<H2 Title=" + "\"" + "exp(x); " + "x={0}" 
            + "\"" + ">", x);
        Double res01 = math53.exp(x);
        Console.WriteLine("math53:  {0}", res01);
        Single res02 = sreal.exp(x);
        Console.WriteLine(" sreal:  {0}", res02);
        Double res03 = dreal.exp(x);
        Console.WriteLine(" dreal:  {0}", res03);
        Extended res04 = ereal.exp(x);
        Console.WriteLine(" ereal:  {0}", res04);
        Quadruple res05 = qreal.exp(x);
        Console.WriteLine(" qreal:  {0}", res05);
        Octuple res06 = oreal.exp(x);
        Console.WriteLine(" oreal:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        Mpfr res07 = mreal.exp(x);
        Console.WriteLine(" mreal:  {0}", res07);
        Single res08 = sflint.exp(x);
        Console.WriteLine("sflint:  {0}", res08);
        Double res09 = dflint.exp(x);
        Console.WriteLine("dflint:  {0}", res09);
        Extended res10 = eflint.exp(x);
        Console.WriteLine("eflint:  {0}", res10);
        Quadruple res11 = qflint.exp(x);
        Console.WriteLine("qflint:  {0}", res11);
        Octuple res12 = oflint.exp(x);
        Console.WriteLine("oflint:  {0}", res12);
        Mpfr res13 = mflint.exp(x);
        Console.WriteLine("mflint:  {0}", res13);
        Arb res16 = aflint.exp(x);
        Console.WriteLine("aflint: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExpCplx

public static void TestExpCplx()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExpCplx" + "\"" + ">");
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};

    foreach (var x in InputArray1C) {
        Console.WriteLine("<H2 Title=" + "\"" + "exp(x); " + "x={0}" + 
            "\"" + ">", x);
        Complex res01 = cmath53.exp(x);
        Console.WriteLine("cmath53:  {0}", res01);
        SingleC res02 = scplx.exp(x);
        Console.WriteLine("  scplx:  {0}", res02);
        Complex res03 = dcplx.exp(x);
        Console.WriteLine("  dcplx:  {0}", res03);
        ExtendedC res04 = ecplx.exp(x);
        Console.WriteLine("  ecplx:  {0}", res04);
        QuadrupleC res05 = qcplx.exp(x);
        Console.WriteLine("  qcplx:  {0}", res05);
        OctupleC res06 = ocplx.exp(x);
        Console.WriteLine("  ocplx:  {0}", res06);
#if HasArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
        MpfrC res07 = mcplx.exp(x);
        Console.WriteLine("  mcplx:  {0}", res07);
        SingleC res08 = sflintc.exp(x);
        Console.WriteLine("sflintc:  {0}", res08);
        Complex res09 = dflintc.exp(x);
        Console.WriteLine("dflintc:  {0}", res09);
        ExtendedC res10 = eflintc.exp(x);
        Console.WriteLine("eflintc:  {0}", res10);
        QuadrupleC res11 = qflintc.exp(x);
        Console.WriteLine("qflintc:  {0}", res11);
        OctupleC res12 = oflintc.exp(x);
        Console.WriteLine("oflintc:  {0}", res12);
        MpfrC res13 = mflintc.exp(x);
        Console.WriteLine("mflintc:  {0}", res13);
        ArbC res16 = aflintc.exp(x);
        Console.WriteLine("aflintc: {0}", res16);
#endif
        Console.WriteLine("</H2>");
        Console.WriteLine();
    }
    Console.WriteLine("</H1>");
}

#endregion


#region TestExpRealImag

public static void TestExpRealImag()
{
    Console.WriteLine("<H1 Title=" + "\"" + "TestExpRealImag" + 
        "\"" + ">");
    bool[] ReImArray = {true, false};
    Complex[] InputArray1C = {dcplx.t(-4.333, 1.0), dcplx.t(0.0, 1.0), 
        dcplx.t(4.333, 1.0)};
    foreach (var x in InputArray1C) {
    foreach (var IsReal in ReImArray)
    {
        string ReIm = IsReal ? "Re(" : "Im(";
        Console.WriteLine("<H2 Title=" + "\"" + ReIm + "exp(x)); x={0}" 
            + "\"" + ">", x);

        Complex res01c = cmath53.exp(x); 
        Double res01 = IsReal ? res01c.Real : res01c.Imaginary;
        Console.WriteLine("cmath53:  {0}", res01);

        SingleC res02c = scplx.exp(x);
        Single res02 = IsReal ? res02c.real : res02c.imag;
        Console.WriteLine("  scplx:  {0}", res02);

        Complex res03c = dcplx.exp(x);
        Double res03 = IsReal ? res03c.Real : res03c.Imaginary;
        Console.WriteLine("  dcplx:  {0}", res03);

        ExtendedC res04c = ecplx.exp(x);
        Extended res04 = IsReal ? res04c.real : res04c.imag;
        Console.WriteLine("  ecplx:  {0}", res04);

        QuadrupleC res05c = qcplx.exp(x);
        Quadruple res05 = IsReal ? res05c.real : res05c.imag;
        Console.WriteLine("  qcplx:  {0}", res05);

        OctupleC res06c = ocplx.exp(x);
        Octuple res06 = IsReal ? res06c.real : res06c.imag;
        Console.WriteLine("  ocplx:  {0}", res06);

#if HasArbPrecNet
        MpfrC res07c = mcplx.exp(x);
        Mpfr res07 = IsReal ? res07c.real : res07c.imag;
        Console.WriteLine("  mcplx:  {0}", res07);

        SingleC res08c = sflintc.exp(x);
        Single res08 = IsReal ? res08c.real : res08c.imag;
        Console.WriteLine("sflintc:  {0}", res08);

        Complex res09c = dflintc.exp(x);
        Double res09 = IsReal ? res09c.Real : res09c.Imaginary;
        Console.WriteLine("dflintc:  {0}", res09);

        ExtendedC res10c = eflintc.exp(x);
        Extended res10 = IsReal ? res10c.real : res10c.imag;
        Console.WriteLine("eflintc:  {0}", res10);

        QuadrupleC res11c = qflintc.exp(x);
        Quadruple res11 = IsReal ? res11c.real : res11c.imag;
        Console.WriteLine("qflintc:  {0}", res11);

        OctupleC res12c = oflintc.exp(x);
        Octuple res12 = IsReal ? res12c.real : res12c.imag;
        Console.WriteLine("oflintc:  {0}", res12);

        MpfrC res13c = mflintc.exp(x);
        Mpfr res13 = IsReal ? res13c.real : res13c.imag;
        Console.WriteLine("mflintc:  {0}", res13);

        ArbC res16c = aflintc.exp(x);
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
<H1 Title="TestExpReal">
<H2 Title="exp(x); x=-4.333">
math53:  0.0131281040423637
 sreal:  0.0131281
 dreal:  0.0131281040423637
 ereal:  0.013128104042363668508
 qreal:  0.0131281040423636685081053342272337
 oreal:  0.0131281040423636685081053342272336606163117111220518927479824314462188
 mreal:  0.013128104042363668508105334227233660616311711122051892747982431446218799899969193
sflint:  0.0131281
dflint:  0.0131281040423637
eflint:  0.013128104042363668508
qflint:  0.0131281040423636685081053342272337
oflint:  0.0131281040423636685081053342272336606163117111220518927479824314462188
mflint:  0.013128104042363668508105334227233660616311711122051892747982431446218799899969193
aflint: [0.013128104042363668508105334227233660616311711122051892747982431446218799899969193 +/- 4.36e-82]
</H2>

<H2 Title="exp(x); x=0">
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

<H2 Title="exp(x); x=4.333">
math53:  76.1724615201902
 sreal:  76.17248
 dreal:  76.1724615201902
 ereal:  76.17246152019020345
 qreal:  76.1724615201902034530083631602067
 oreal:  76.172461520190203453008363160206665292325717803567092007188182036364935
 mreal:  76.17246152019020345300836316020666529232571780356709200718818203636493561899972
sflint:  76.17248
dflint:  76.1724615201902
eflint:  76.17246152019020345
qflint:  76.1724615201902034530083631602067
oflint:  76.172461520190203453008363160206665292325717803567092007188182036364935
mflint:  76.17246152019020345300836316020666529232571780356709200718818203636493561899972
aflint: [76.17246152019020345300836316020666529232571780356709200718818203636493561899972 +/- 2.39e-78]
</H2>

</H1>
<H1 Title="TestExpCplx">
<H2 Title="exp(x); x=(-4.333, 1)">
cmath53:  (0.00709314488576594, 0.0110469186371883)
  scplx:  (0.007093143, 0.01104692)
  dcplx:  (0.00709314488576594, 0.0110469186371883)
  ecplx:  (0.007093144885765936277, 0.011046918637188283221)
  qcplx:  (0.00709314488576593627653291195238183, 0.0110469186371882832201614097031261)
  ocplx:  (0.0070931448857659362765329119523818341206451600012434614373382754059021151, 0.0110469186371882832201614097031261270713302308515755023373461343641356)
  mcplx:  (0.0070931448857659362765329119523818341206451600012434614373382754059021151477839603, 0.011046918637188283220161409703126127071330230851575502337346134364135599723977506)
sflintc:  (0.007093144, 0.01104692)
dflintc:  (0.00709314488576593, 0.0110469186371883)
eflintc:  (0.0070931448857659362766, 0.01104691863718828322)
qflintc:  (0.00709314488576593627653291195238183, 0.0110469186371882832201614097031261)
oflintc:  (0.0070931448857659362765329119523818341206451600012434614373382754059021152, 0.0110469186371882832201614097031261270713302308515755023373461343641356)
mflintc:  (0.0070931448857659362765329119523818341206451600012434614373382754059021151477839603, 0.011046918637188283220161409703126127071330230851575502337346134364135599723977506)
aflintc: ([0.007093144885765936276532911952381834120645160001243461437338275405902115147783960 +/- 4.01e-82], [0.011046918637188283220161409703126127071330230851575502337346134364135599723977506 +/- 6.70e-82])
</H2>

<H2 Title="exp(x); x=(0, 1)">
cmath53:  (0.54030230586814, 0.841470984807897)
  scplx:  (0.5403023, 0.841471)
  dcplx:  (0.54030230586814, 0.841470984807897)
  ecplx:  (0.54030230586813971741, 0.84147098480789650666)
  qcplx:  (0.540302305868139717400936607442977, 0.841470984807896506652502321630299)
  ocplx:  (0.54030230586813971740093660744297660373231042061792222767009725538110039, 0.84147098480789650665250232163029899962256306079837106567275170999191039)
  mcplx:  (0.54030230586813971740093660744297660373231042061792222767009725538110039477447177, 0.84147098480789650665250232163029899962256306079837106567275170999191040439123967)
sflintc:  (0.5403023, 0.841471)
dflintc:  (0.54030230586814, 0.841470984807897)
eflintc:  (0.54030230586813971741, 0.84147098480789650666)
qflintc:  (0.540302305868139717400936607442977, 0.841470984807896506652502321630299)
oflintc:  (0.54030230586813971740093660744297660373231042061792222767009725538110039, 0.84147098480789650665250232163029899962256306079837106567275170999191041)
mflintc:  (0.54030230586813971740093660744297660373231042061792222767009725538110039477447177, 0.84147098480789650665250232163029899962256306079837106567275170999191040439123967)
aflintc: ([0.54030230586813971740093660744297660373231042061792222767009725538110039477447176 +/- 9.42e-81], [0.8414709848078965066525023216302989996225630607983710656727517099919104043912397 +/- 4.12e-80])
</H2>

<H2 Title="exp(x); x=(4.333, 1)">
cmath53:  (41.1561566030109, 64.0969162106361)
  scplx:  (41.15616, 64.09693)
  dcplx:  (41.1561566030109, 64.0969162106361)
  ecplx:  (41.15615660301091018, 64.096916210636051929)
  qcplx:  (41.1561566030109101819510191140896, 64.0969162106360519320469669199818)
  ocplx:  (41.156156603010910181951019114089589195574940851362764084058576043726434, 64.096916210636051932046966919981766482316288249294348552688812952153927)
  mcplx:  (41.156156603010910181951019114089589195574940851362764084058576043726435191938412, 64.096916210636051932046966919981766482316288249294348552688812952153927852487333)
sflintc:  (41.15616, 64.09693)
dflintc:  (41.1561566030109, 64.0969162106361)
eflintc:  (41.15615660301091018, 64.096916210636051929)
qflintc:  (41.1561566030109101819510191140896, 64.0969162106360519320469669199818)
oflintc:  (41.156156603010910181951019114089589195574940851362764084058576043726435, 64.096916210636051932046966919981766482316288249294348552688812952153927)
mflintc:  (41.156156603010910181951019114089589195574940851362764084058576043726435191938412, 64.096916210636051932046966919981766482316288249294348552688812952153927852487333)
aflintc: ([41.15615660301091018195101911408958919557494085136276408405857604372643519193841 +/- 2.67e-78], [64.09691621063605193204696691998176648231628824929434855268881295215392785248733 +/- 4.90e-78])
</H2>

</H1>
<H1 Title="TestExpRealImag">
<H2 Title="Re(exp(x)); x=(-4.333, 1)">
cmath53:  0.00709314488576594
  scplx:  0.007093143
  dcplx:  0.00709314488576594
  ecplx:  0.007093144885765936277
  qcplx:  0.00709314488576593627653291195238183
  ocplx:  0.0070931448857659362765329119523818341206451600012434614373382754059021151
  mcplx:  0.0070931448857659362765329119523818341206451600012434614373382754059021151477839603
sflintc:  0.007093144
dflintc:  0.00709314488576593
eflintc:  0.0070931448857659362766
qflintc:  0.00709314488576593627653291195238183
oflintc:  0.0070931448857659362765329119523818341206451600012434614373382754059021152
mflintc:  0.0070931448857659362765329119523818341206451600012434614373382754059021151477839603
aflintc: [0.007093144885765936276532911952381834120645160001243461437338275405902115147783960 +/- 4.01e-82]
</H2>

<H2 Title="Im(exp(x)); x=(-4.333, 1)">
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
aflintc: [0.011046918637188283220161409703126127071330230851575502337346134364135599723977506 +/- 6.70e-82]
</H2>

<H2 Title="Re(exp(x)); x=(0, 1)">
cmath53:  0.54030230586814
  scplx:  0.5403023
  dcplx:  0.54030230586814
  ecplx:  0.54030230586813971741
  qcplx:  0.540302305868139717400936607442977
  ocplx:  0.54030230586813971740093660744297660373231042061792222767009725538110039
  mcplx:  0.54030230586813971740093660744297660373231042061792222767009725538110039477447177
sflintc:  0.5403023
dflintc:  0.54030230586814
eflintc:  0.54030230586813971741
qflintc:  0.540302305868139717400936607442977
oflintc:  0.54030230586813971740093660744297660373231042061792222767009725538110039
mflintc:  0.54030230586813971740093660744297660373231042061792222767009725538110039477447177
aflintc: [0.54030230586813971740093660744297660373231042061792222767009725538110039477447176 +/- 9.42e-81]
</H2>

<H2 Title="Im(exp(x)); x=(0, 1)">
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
aflintc: [0.8414709848078965066525023216302989996225630607983710656727517099919104043912397 +/- 4.12e-80]
</H2>

<H2 Title="Re(exp(x)); x=(4.333, 1)">
cmath53:  41.1561566030109
  scplx:  41.15616
  dcplx:  41.1561566030109
  ecplx:  41.15615660301091018
  qcplx:  41.1561566030109101819510191140896
  ocplx:  41.156156603010910181951019114089589195574940851362764084058576043726434
  mcplx:  41.156156603010910181951019114089589195574940851362764084058576043726435191938412
sflintc:  41.15616
dflintc:  41.1561566030109
eflintc:  41.15615660301091018
qflintc:  41.1561566030109101819510191140896
oflintc:  41.156156603010910181951019114089589195574940851362764084058576043726435
mflintc:  41.156156603010910181951019114089589195574940851362764084058576043726435191938412
aflintc: [41.15615660301091018195101911408958919557494085136276408405857604372643519193841 +/- 2.67e-78]
</H2>

<H2 Title="Im(exp(x)); x=(4.333, 1)">
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
aflintc: [64.09691621063605193204696691998176648231628824929434855268881295215392785248733 +/- 4.90e-78]
</H2>

</H1>
<H1 Title="General Info">
Elapsed Time 00:00:00.18
------------------------------------------------
Memory used before collection:       5,004,824
Memory used after full collection:   4,816,472
------------------------------------------------

</H1>
*/
#endregion

