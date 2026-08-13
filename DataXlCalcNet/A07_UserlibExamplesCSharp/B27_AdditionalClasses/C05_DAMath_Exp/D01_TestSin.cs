
#region Usings
/* If defined includes code requiring UserFixedPrecNet. Is set automatically */
#define HasUserFixedPrecNet
/* If defined includes code requiring ArbPrecNet. Is set automatically */
#define HasArbPrecNet
/* If defined includes code requiring UserArbPrecNet. Is set automatically */
#define HasUserArbPrecNet
using System;
using System.Numerics;
using FixedPrecNet;
#if HasUserFixedPrecNet
/* No syntax highlighting if HasUserFixedPrecNet is undefined */
using UserFixedPrecNet;
#endif
#if HasArbPrecNet
/* No syntax highlighting if HasUserArbPrecNet is undefined */
using ArbPrecNet;
#endif
#if HasUserArbPrecNet
/* No syntax highlighting if HasArbPrecNet is undefined */
using UserArbPrecNet;
#endif
#endregion


static class Program
{

public static void MainTests()
{
//    Test_DAMath_Exp();
    Test_DAMath_Trig();
}


#region Test_DAMath_Exp

public static void Test_DAMath_Exp()
{
    Double x, y, z, fr;


    x = 0.000001d;
    fr = math53.sqrt1pmx(x);
    Console.WriteLine("x: {0}, math53.Sqrt1pmx(x): {1}", x, fr);
    fr = m53lib.sqrt1pmx(x);
    Console.WriteLine("x: {0}, m53lib.Sqrt1pmx(x): {1}", x, fr);
    Console.WriteLine();


    var z1 = new Complex(8.34d, 1.23d);
    var z3 = Complex.Pow(z1, 1.0d / 3.0d);
    Console.WriteLine("z3 = Complex.Pow(z1, 1.0/3.0): {0}", z3);
    var z4 = cmath53.cuberoot(z1);
    Console.WriteLine("z4 = mathC53.cuberoot(z1, 3):       {0}", z4);
    var z5 = m53lib.cuberoot(z1);
    Console.WriteLine("z4 = m53lib.cuberoot(z1, 3) :       {0}", z5);
    Console.WriteLine();


    z1 = new Complex(8.34d, 1.23d);
    z3 = Complex.Pow(z1, 1.0d / 3.0d);
    Console.WriteLine("z3 = Complex.Pow(z1, 1.0/3.0): {0}", z3);
    z4 = cmath53.surd(z1, 3);
    Console.WriteLine("z4 = mathC53.Surd(z1, 3):       {0}", z4);
    z5 = m53lib.surd(z1, 3);
    Console.WriteLine("z4 = m53lib.Surd(z1, 3) :       {0}", z5);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.expmx2h(x);
    Console.WriteLine("x: {0}, math53.Expmx2h(x): {1}", x, fr);
    fr = m53lib.expmx2h(x);
    Console.WriteLine("x: {0}, m53lib.Expmx2h(x): {1}", x, fr);
    Console.WriteLine();

    x = 20.75d;
    fr = math53.exprel(x);
    Console.WriteLine("x: {0}, math53.Exprel(x): {1}", x, fr);
    fr = m53lib.exprel(x);
    Console.WriteLine("x: {0}, m53lib.Exprel(x): {1}", x, fr);
    Console.WriteLine();

    x = 20.75d;
    fr = math53.expx2(x);
    Console.WriteLine("x: {0}, math53.Expx2(x): {1}", x, fr);
    fr = m53lib.expx2(x);
    Console.WriteLine("x: {0}, m53lib.Expx2(x): {1}", x, fr);
    Console.WriteLine();

    x = 20.75d;
    fr = math53.logistic(x);
    Console.WriteLine("x: {0}, math53.Logistic(x): {1}", x, fr);
    fr = m53lib.logistic(x);
    Console.WriteLine("x: {0}, m53lib.Logistic(x): {1}", x, fr);
    Console.WriteLine();

    x = 2.1d;
    fr = math53.bring(x);
    Console.WriteLine("x: {0}, math53.Bring(x): {1}", x, fr);
    fr = m53lib.bring(x);
    Console.WriteLine("x: {0}, m53lib.Bring(x): {1}", x, fr);
    Console.WriteLine();


    Int32 n = 2;
    x = 3.4d;
    fr = math53.einstein(n, x);
    Console.WriteLine("n: {0}, x: {1}, math53.Einstein(n, x): {2}", n, x, fr);
    fr = m53lib.einstein(n, x);
    Console.WriteLine("n: {0}, x: {1}, m53lib.Einstein(n, x): {2}", n, x, fr);
    Console.WriteLine();


    x = -20.75d;
    fr = math53.log1mexp(x);
    Console.WriteLine("x: {0}, math53.log1mexp(x): {1}", x, fr);
    fr = m53lib.log1mexp(x);
    Console.WriteLine("x: {0}, m53lib.log1mexp(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.log1pexp(x);
    Console.WriteLine("x: {0}, math53.log1pexp(x): {1}", x, fr);
    fr = m53lib.log1pexp(x);
    Console.WriteLine("x: {0}, m53lib.log1pexp(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.log1pmx(x);
    Console.WriteLine("x: {0}, math53.log1pmx(x): {1}", x, fr);
    fr = m53lib.log1pmx(x);
    Console.WriteLine("x: {0}, m53lib.log1pmx(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.logcosh(x);
    Console.WriteLine("x: {0}, math53.logcosh(x): {1}", x, fr);
    fr = m53lib.logcosh(x);
    Console.WriteLine("x: {0}, m53lib.logcosh(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.logsinh(x);
    Console.WriteLine("x: {0}, math53.logsinh(x): {1}", x, fr);
    fr = m53lib.logsinh(x);
    Console.WriteLine("x: {0}, m53lib.logsinh(x): {1}", x, fr);
    Console.WriteLine();


    x = 4.5d;
    y = 7.3d;
    fr = math53.logaddexp(x, y);
    Console.WriteLine("x: {0}, y: {1}, math53.Logaddexp(x, y): {2}", x, y, fr);
    fr = m53lib.logaddexp(x, y);
    Console.WriteLine("x: {0}, y: {1}, m53lib.Logaddexp(x, y): {2}", x, y, fr);
    Console.WriteLine();


    x = 14.5d;
    y = 7.3d;
    fr = math53.logsubexp(x, y);
    Console.WriteLine("x: {0}, y: {1}, math53.Logsubexp(x, y): {2}", x, y, fr);
    fr = m53lib.logsubexp(x, y);
    Console.WriteLine("x: {0}, y: {1}, m53lib.Logsubexp(x, y): {2}", x, y, fr);
    Console.WriteLine();


    x = 0.51d;
    fr = math53.logit(x);
    Console.WriteLine("x: {0}, math53.Logit(x): {1}", x, fr);
    fr = m53lib.logit(x);
    Console.WriteLine("x: {0}, m53lib.Logit(x): {1}", x, fr);
    Console.WriteLine();


    x = 46.1d;
    fr = math53.wright_omega(x);
    Console.WriteLine("x: {0}, math53.WrightOmega(x): {1}", x, fr);
    fr = m53lib.wright_omega(x);
    Console.WriteLine("x: {0}, m53lib.WrightOmega(x): {1}", x, fr);
    Console.WriteLine();


    n = 20;
    x = 3.4d;
    fr = math53.fibpoly(n, x);
    Console.WriteLine("n: {0}, x: {1}, math53.Fibpoly(n, x): {2}", n, x, fr);
    fr = m53lib.fibpoly(n, x);
    Console.WriteLine("n: {0}, x: {1}, m53lib.Fibpoly(n, x): {2}", n, x, fr);
    Console.WriteLine();


    n = 20;
    x = 3.4d;
    fr = math53.lucpoly(n, x);
    Console.WriteLine("n: {0}, x: {1}, math53.Lucpoly(n, x): {2}", n, x, fr);
    fr = m53lib.lucpoly(n, x);
    Console.WriteLine("n: {0}, x: {1}, m53lib.Lucpoly(n, x): {2}", n, x, fr);
    Console.WriteLine();


    x = 4.5d;
    y = 7.3d;
    z = 11.3d;
    fr = math53.hypot3(x, y, z);
    Console.WriteLine("x: {0}, y: {1}, z: {2}, math53.Hypot3(x, y, z): {3}", x, y, z, fr);
    fr = m53lib.hypot3(x, y, z);
    Console.WriteLine("x: {0}, y: {1}, z: {2}, m53lib.Hypot3(x, y, z): {3}", x, y, z, fr);
    Console.WriteLine();

}

#endregion


#region Test_DAMath_Trig

public static void Test_DAMath_Trig()
{
    Double x, fr;
//    Double x, y, z, fr;


    x = 180.0d;
    fr = math53.sind(x);
    Console.WriteLine("x: {0}, math53.sind(x): {1}", x, fr);
    fr = m53lib.sind(x);
    Console.WriteLine("x: {0}, m53lib.sind(x): {1}", x, fr);
    Console.WriteLine();


    x = 0.75d;
    fr = math53.asind(x);
    Console.WriteLine("x: {0}, math53.asind(x): {1}", x, fr);
    fr = m53lib.asind(x);
    Console.WriteLine("x: {0}, m53lib.asind(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.cosd(x);
    Console.WriteLine("x: {0}, math53.cosd(x): {1}", x, fr);
    fr = m53lib.cosd(x);
    Console.WriteLine("x: {0}, m53lib.cosd(x): {1}", x, fr);
    Console.WriteLine();


    x = 0.75d;
    fr = math53.acosd(x);
    Console.WriteLine("x: {0}, math53.acosd(x): {1}", x, fr);
    fr = m53lib.acosd(x);
    Console.WriteLine("x: {0}, m53lib.acosd(x): {1}", x, fr);
    Console.WriteLine();


    x = 0.51d;
    fr = math53.tand(x);
    Console.WriteLine("x: {0}, math53.tand(x): {1}", x, fr);
    fr = m53lib.tand(x);
    Console.WriteLine("x: {0}, m53lib.tand(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.atand(x);
    Console.WriteLine("x: {0}, math53.atand(x): {1}", x, fr);
    fr = m53lib.atand(x);
    Console.WriteLine("x: {0}, m53lib.atand(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.Cotd(x);
    Console.WriteLine("x: {0}, math53.cotd(x): {1}", x, fr);
    fr = m53lib.Cotd(x);
    Console.WriteLine("x: {0}, m53lib.cotd(x): {1}", x, fr);
    Console.WriteLine();



    x = 20.75d;
    fr = math53.acotd(x);
    Console.WriteLine("x: {0}, math53.acotd(x): {1}", x, fr);
    fr = m53lib.acotd(x);
    Console.WriteLine("x: {0}, m53lib.acotd(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.acotc(x);
    Console.WriteLine("x: {0}, math53.acotc(x): {1}", x, fr);
    fr = m53lib.acotc(x);
    Console.WriteLine("x: {0}, m53lib.acotc(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.acotcd(x);
    Console.WriteLine("x: {0}, math53.acotcd(x): {1}", x, fr);
    fr = m53lib.acotcd(x);
    Console.WriteLine("x: {0}, m53lib.acotcd(x): {1}", x, fr);
    Console.WriteLine();



    x = 20.75d;
    fr = math53.covers(x);
    Console.WriteLine("x: {0}, math53.covers(x): {1}", x, fr);
    fr = m53lib.covers(x);
    Console.WriteLine("x: {0}, m53lib.covers(x): {1}", x, fr);
    Console.WriteLine();


    x = 0.51d;
    fr = math53.versint(x);
    Console.WriteLine("x: {0}, math53.versint(x): {1}", x, fr);
    fr = m53lib.versint(x);
    Console.WriteLine("x: {0}, m53lib.versint(x): {1}", x, fr);
    Console.WriteLine();


    x = 0.51d;
    fr = math53.vers(x);
    Console.WriteLine("x: {0}, math53.vers(x): {1}", x, fr);
    fr = m53lib.vers(x);
    Console.WriteLine("x: {0}, m53lib.vers(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.hav(x);
    Console.WriteLine("x: {0}, math53.hav(x): {1}", x, fr);
    fr = m53lib.hav(x);
    Console.WriteLine("x: {0}, m53lib.hav(x): {1}", x, fr);
    Console.WriteLine();


    Int32 n = 20;
    x = 3.4d;
    fr = math53.cosint(n, x);
    Console.WriteLine("n: {0}, x: {1}, math53.cosint(n, x): {2}", n, x, fr);
    fr = m53lib.cosint(n, x);
    Console.WriteLine("n: {0}, x: {1}, m53lib.cosint(n, x): {2}", n, x, fr);
    Console.WriteLine();


    n = 20;
    x = 3.4d;
    fr = math53.sinint(n, x);
    Console.WriteLine("n: {0}, x: {1}, math53.sinint(n, x): {2}", n, x, fr);
    fr = m53lib.sinint(n, x);
    Console.WriteLine("n: {0}, x: {1}, m53lib.sinint(n, x): {2}", n, x, fr);
    Console.WriteLine();


    var M = 0.75d;
    var e = 3.4d;
    fr = math53.kepler(M, e);
    Console.WriteLine("M: {0}, e: {1}, math53.kepler(M, e): {2}", M, e, fr);
    fr = m53lib.kepler(M, e);
    Console.WriteLine("M: {0}, e: {1}, m53lib.kepler(M, e): {2}", M, e, fr);
    Console.WriteLine();



    var v = 2.1d;
    x = 3.4d;
    fr = math53.fibfun(v, x);
    Console.WriteLine("v: {0}, x: {1}, math53.fibfun(v, x): {2}", v, x, fr);
    fr = m53lib.fibfun(v, x);
    Console.WriteLine("v: {0}, x: {1}, m53lib.fibfun(v, x): {2}", v, x, fr);
    Console.WriteLine();


    x = 0.51d;
    fr = math53.sinhc(x);
    Console.WriteLine("x: {0}, math53.sinhc(x): {1}", x, fr);
    fr = m53lib.sinhc(x);
    Console.WriteLine("x: {0}, m53lib.sinhc(x): {1}", x, fr);
    Console.WriteLine();


    x = 0.51d;
    fr = math53.sinhmx(x);
    Console.WriteLine("x: {0}, math53.sinhmx(x): {1}", x, fr);
    fr = m53lib.sinhmx(x);
    Console.WriteLine("x: {0}, m53lib.sinhmx(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.coshm1(x);
    Console.WriteLine("x: {0}, math53.coshm1(x): {1}", x, fr);
    fr = m53lib.coshm1(x);
    Console.WriteLine("x: {0}, m53lib.coshm1(x): {1}", x, fr);
    Console.WriteLine();


    x = 2.1d;
    fr = math53.langevinl(x);
    Console.WriteLine("x: {0}, math53.LangevinL(x): {1}", x, fr);
    fr = m53lib.langevinl(x);
    Console.WriteLine("x: {0}, m53lib.LangevinL(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.logcosh(x);
    Console.WriteLine("x: {0}, math53.logcosh(x): {1}", x, fr);
    fr = m53lib.logcosh(x);
    Console.WriteLine("x: {0}, m53lib.logcosh(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.logsinh(x);
    Console.WriteLine("x: {0}, math53.logsinh(x): {1}", x, fr);
    fr = m53lib.logsinh(x);
    Console.WriteLine("x: {0}, m53lib.logsinh(x): {1}", x, fr);
    Console.WriteLine();


    x = 0.000001d;
    fr = math53.acos1m(x);
    Console.WriteLine("x: {0}, math53.acos1m(x): {1}", x, fr);
    fr = m53lib.acos1m(x);
    Console.WriteLine("x: {0}, m53lib.acos1m(x): {1}", x, fr);
    Console.WriteLine();


    x = 20.75d;
    fr = math53.gudermann(x);
    Console.WriteLine("x: {0}, math53.gudermann(x): {1}", x, fr);
    fr = m53lib.gudermann(x);
    Console.WriteLine("x: {0}, m53lib.gudermann(x): {1}", x, fr);
    Console.WriteLine();


    x = 0.75d;
    fr = math53.archav(x);
    Console.WriteLine("x: {0}, math53.archav(x): {1}", x, fr);
    fr = m53lib.archav(x);
    Console.WriteLine("x: {0}, m53lib.archav(x): {1}", x, fr);
    Console.WriteLine();


    x = 0.000001d;
    fr = math53.acosh1p(x);
    Console.WriteLine("x: {0}, math53.acosh1p(x): {1}", x, fr);
    fr = m53lib.acosh1p(x);
    Console.WriteLine("x: {0}, m53lib.acosh1p(x): {1}", x, fr);
    Console.WriteLine();




    x = 0.75d;
    fr = math53.arcgudermann(x);
    Console.WriteLine("x: {0}, math53.arcgudermann(x): {1}", x, fr);
    fr = m53lib.arcgudermann(x);
    Console.WriteLine("x: {0}, m53lib.arcgudermann(x): {1}", x, fr);
    Console.WriteLine();




    x = 0.71d;
    fr = math53.langevinlinv(x);
    Console.WriteLine("x: {0}, math53.LangevinLInv(x): {1}", x, fr);
    fr = m53lib.langevinlinv(x);
    Console.WriteLine("x: {0}, m53lib.LangevinLInv(x): {1}", x, fr);
    Console.WriteLine();



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



